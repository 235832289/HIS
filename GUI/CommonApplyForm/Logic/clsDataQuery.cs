using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using com.digitalwave.GLS_WS.VO;
using System.Text;
using com.digitalwave.GLS_WS.ApplyReportServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS.Logic
{
    /// <summary>
    /// clsDataQuery 的摘要说明。
    /// </summary>
    public class clsDataQuery
    {
        private DataProcess dp; //= new com.digitalwave.GLS_WS.Data.DataProcess();

        public clsDataQuery()
        {
            dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
        }

        /// <summary>
        /// 返回所有检查类型
        /// </summary>
        /// <returns></returns>
        public clsCheckType[] GetAllCheckTypes()
        {
            DataTable ds = dp.SqlSelect("select * from AR_APPLY_TYPELIST");

            if (ds.Rows.Count < 1)
            {
                return null;
            }

            clsCheckType[] checks = new clsCheckType[ds.Rows.Count];

            int i = 0;
            foreach (DataRow dr in ds.Rows)
            {
                checks[i] = new clsCheckType();
                checks[i].m_strTypeID = dr["TypeID"].ToString().ToString();
                checks[i].m_strTypeName = dr["TypeText"].ToString().ToString();
                i++;
            }

            return checks;
        }

        /// <summary>
        /// 返回指定检查类型
        /// </summary>
        /// <param name="p_strARTypeArr"></param>
        /// <returns></returns>
        public clsCheckType[] GetSpecCheckTypes(string[] p_strARTypeArr)
        {
            string strSQL = "";

            string strAR = "";
            if (p_strARTypeArr == null || p_strARTypeArr.Length <= 0)
            {
                strSQL = "select * from AR_APPLY_TYPELIST";
            }
            else
            {
                for (int j = 0; j < p_strARTypeArr.Length; j++)
                {
                    if (j == 0)
                        strAR = "TYPEID = " + p_strARTypeArr[j];
                    else
                        strAR += " or TYPEID = " + p_strARTypeArr[j];
                }

                strSQL = "select * from AR_APPLY_TYPELIST where ";
            }
            DataTable ds = dp.SqlSelect(strSQL + strAR);

            if (ds.Rows.Count < 1)
            {
                return null;
            }

            clsCheckType[] checks = new clsCheckType[ds.Rows.Count];

            int i = 0;
            foreach (DataRow dr in ds.Rows)
            {
                checks[i] = new clsCheckType();
                checks[i].m_strTypeID = dr["TypeID"].ToString().ToString();
                checks[i].m_strTypeName = dr["TypeText"].ToString().ToString();
                i++;
            }

            return checks;
        }

        public clsApplyRecord[] GetApplyRecord(DateTime fromDate, DateTime toDate, string typeID)
        {
            string m_strSQL = string.Empty;
            if (typeID != null && typeID != string.Empty)
            {
                //注意，此处因为t_opr_attachrelation表中attachid_vchr的值分两种，有的会在前面补零，有的不会，当补零的值转换成Integer时如果和原来没补零的值相同，会导致关联出多条信息，所以必须将integer强行转成char再关联 
                //by haozhong.liu 2009.06.12
                m_strSQL = @"select   /*+ use_hash(a,b)*/
                                     a.*, b.attarelaid_chr, b.sysfrom_int, b.attachtype_int,
                                     b.sourceitemid_vchr, b.attachid_vchr, b.urgency_int,
                                     b.status_int as status_int1, b.isgreen_int
                                from ar_common_apply a, t_opr_attachrelation b
                               where (a.deleted <> 1)
                                 and a.applydate between to_date ('{0}', 'yyyy.mm.dd hh24:mi:ss')
                                                     and to_date ('{1}', 'yyyy.mm.dd hh24:mi:ss')
                                 and a.typeid in (" + typeID + @")
                                 and to_char(a.applyid) = b.attachid_vchr
                                 and a.submitted = 1
                            order by a.applydate";
            }
            else
            {
                m_strSQL = @"select   /*+ use_hash(a,b)*/
                                     a.*, b.attarelaid_chr, b.sysfrom_int, b.attachtype_int,
                                     b.sourceitemid_vchr, b.attachid_vchr, b.urgency_int,
                                     b.status_int as status_int1, b.isgreen_int
                                from ar_common_apply a, t_opr_attachrelation b
                               where (a.deleted <> 1)
                                 and (a.applydate between to_date ('{0}', 'yyyy.mm.dd hh24:mi:ss')
                                                      and to_date ('{1}', 'yyyy.mm.dd hh24:mi:ss')
                                     )
                                 and to_char(a.applyid) = b.attachid_vchr
                                 and a.submitted = 1
                            order by a.applydate";
            }
            m_strSQL = string.Format(m_strSQL, fromDate.ToString(), toDate.ToString());
            DataTable ds = dp.SqlSelect(m_strSQL);

            if (ds.Rows.Count < 1)
            {
                return null;
            }

            clsApplyRecord[] rs = new clsApplyRecord[ds.Rows.Count];

            int i = 0;
            foreach (DataRow dr in ds.Rows)
            {
                rs[i] = new clsApplyRecord();

                rs[i].m_strDeposit = dr["DEPOSIT"].ToString();
                rs[i].m_strBalance = dr["BALANCE"].ToString();
                rs[i].m_strCheckNO = dr["CHECKNO"].ToString();
                rs[i].m_strClinicNO = dr["CLINICNO"].ToString();
                rs[i].m_strBIHNO = dr["BIHNO"].ToString();
                rs[i].m_strName = dr["NAME"].ToString();
                rs[i].m_strSex = dr["SEX"].ToString();
                rs[i].m_strAge = dr["AGE"].ToString();
                rs[i].m_strArea = dr["AREA"].ToString();
                rs[i].m_strBedNO = dr["BEDNO"].ToString();
                rs[i].m_strTel = dr["TEL"].ToString();
                rs[i].m_strAddress = dr["ADDRESS"].ToString();
                rs[i].m_strSummary = dr["SUMMARY"].ToString();
                rs[i].m_strDiagnose = dr["DIAGNOSE"].ToString();
                rs[i].m_strDoctorName = dr["DOCTORNAME"].ToString();
                rs[i].m_strDoctorNO = dr["DOCTORNO"].ToString();
                rs[i].m_strExtraNO = dr["EXTRANO"].ToString();
                rs[i].m_strCardNO = dr["CARDNO"].ToString();
                rs[i].m_strDepartment = dr["DEPARTMENT"].ToString();
                rs[i].m_strChargeDetail = dr["CHARGEDETAIL"].ToString();
                rs[i].m_datFinishDate = DateTime.Parse(dr["FINISHDATE"].ToString());
                rs[i].m_datApplyDate = DateTime.Parse(dr["APPLYDATE"].ToString());
                rs[i].m_intDeleted = int.Parse("0" + dr["Deleted"].ToString());
                rs[i].m_strApplyTitle = dr["ApplyTitle"].ToString();
                rs[i].m_strDiagnoseAim = dr["DIAGNOSEAIM"].ToString();
                rs[i].m_strDiagnosePart = dr["DIAGNOSEPART"].ToString();
                rs[i].m_strApplyID = dr["ApplyID"].ToString();
                rs[i].m_strTypeID = dr["TypeID"].ToString();
                rs[i].m_intSubmitted = int.Parse("0" + dr["Submitted"].ToString());
                rs[i].m_intChargeStatus = int.Parse("0" + dr["CHARGESTATUS_INT"].ToString());
                rs[i].m_strSTATUS_INT = dr["STATUS_INT"].ToString();
                rs[i].m_strUrgent = dr["URGENCY_INT"].ToString();
                rs[i].m_strStatus_int1 = dr["status_int1"].ToString();
                int.TryParse(dr["sysfrom_int"].ToString(), out rs[i].m_objAttachRelation.m_intSysFrom);
                //添加是否是先诊疗后结算的标示
                int.TryParse(dr["isgreen_int"].ToString().Trim(), out rs[i].m_intIsGreen);

                i++;
            }

            return rs;
        }

        public clsApplyRecord[] GetApplyRecordByConditions(string fromDate, string toDate, string p_strPatientNo, string p_strInPatientNo, string p_strPatientName, string p_strDept, string strApplyPart, bool m_blnFinished)
        {
            List<clsApplyRecord> lstRec = null;

            #region Sql 1
            StringBuilder sbSql = new StringBuilder(@"select distinct  a.*, b.attarelaid_chr, b.sysfrom_int, b.attachtype_int,
                             b.sourceitemid_vchr, b.attachid_vchr, b.urgency_int, b.status_int as status_int1, b.isgreen_int
                             from ar_common_apply a ,t_opr_attachrelation b
                             where (a.deleted <> 1)
                             and (a.applydate between to_date ('" + fromDate + @"',
                                     'yyyy.mm.dd hh24:mi:ss'
                                    )
                             and to_date ('" + toDate + @"',
                                     'yyyy.mm.dd hh24:mi:ss'
                                    )
                                    )
                             and a.typeid=2
                             and a.applyid=b.attachid_vchr ");
            if (p_strPatientNo.Trim() != string.Empty)
            {
                p_strPatientNo = p_strPatientNo.PadLeft(10, '0');
                sbSql = sbSql.Append(" and a.cardno='" + p_strPatientNo + "'");
            }
            if (p_strInPatientNo.Trim() != string.Empty)
            {
                sbSql = sbSql.Append(" and a.bihno='" + p_strInPatientNo + "'");
            }
            if (p_strPatientName.Trim() != string.Empty)
            {
                sbSql = sbSql.Append(" and a.name like '%" + p_strPatientName + "%'");
            }
            if (p_strDept.Trim() != string.Empty)
            {
                sbSql = sbSql.Append(" and (a.department like'" + p_strDept + "%' or a.area like'" + p_strDept + "%')");
            }
            if (strApplyPart.Trim() != string.Empty)
            {
                sbSql = sbSql.Append(" and a.diagnosepart like'%" + strApplyPart + "%'");
            }
            if (m_blnFinished == false)
            {
                sbSql = sbSql.Append(" and a.status_int<>2 ");
            }
            sbSql = sbSql.Append("  order by a.applydate,a.cardno");
            #endregion

            #region set value 1
            DataTable dt = dp.SqlSelect(sbSql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                lstRec = new List<clsApplyRecord>();
                clsApplyRecord vo = null;
                foreach (DataRow dr in dt.Rows)
                {
                    vo = new clsApplyRecord();
                    vo.m_strDeposit = dr["deposit"].ToString();
                    vo.m_strBalance = dr["balance"].ToString();
                    vo.m_strCheckNO = dr["checkno"].ToString();
                    vo.m_strClinicNO = dr["clinicno"].ToString();
                    vo.m_strBIHNO = dr["bihno"].ToString();
                    vo.m_strName = dr["name"].ToString();
                    vo.m_strSex = dr["sex"].ToString();
                    vo.m_strAge = dr["age"].ToString();
                    vo.m_strArea = dr["area"].ToString();
                    vo.m_strBedNO = dr["bedno"].ToString();
                    vo.m_strTel = dr["tel"].ToString();
                    vo.m_strAddress = dr["address"].ToString();
                    vo.m_strSummary = dr["summary"].ToString();
                    vo.m_strDiagnose = dr["diagnose"].ToString();
                    vo.m_strDoctorName = dr["doctorname"].ToString();
                    vo.m_strDoctorNO = dr["doctorno"].ToString();
                    vo.m_strExtraNO = dr["extrano"].ToString();
                    vo.m_strCardNO = dr["cardno"].ToString();
                    vo.m_strDepartment = dr["department"].ToString();
                    vo.m_strChargeDetail = dr["chargedetail"].ToString();
                    vo.m_datFinishDate = DateTime.Parse(dr["finishdate"].ToString());
                    vo.m_datApplyDate = DateTime.Parse(dr["applydate"].ToString());
                    vo.m_intDeleted = int.Parse("0" + dr["deleted"].ToString());
                    vo.m_strApplyTitle = dr["applytitle"].ToString();
                    vo.m_strDiagnoseAim = dr["diagnoseaim"].ToString();
                    vo.m_strDiagnosePart = dr["diagnosepart"].ToString();
                    vo.m_strApplyID = dr["applyid"].ToString();
                    vo.m_strTypeID = dr["typeid"].ToString();
                    vo.m_intSubmitted = int.Parse("0" + dr["submitted"].ToString());
                    vo.m_intChargeStatus = int.Parse("0" + dr["chargestatus_int"].ToString());
                    vo.m_strSTATUS_INT = dr["status_int"].ToString();
                    vo.m_strUrgent = dr["urgency_int"].ToString();
                    vo.m_strStatus_int1 = dr["status_int1"].ToString();
                    int.TryParse(dr["sysfrom_int"].ToString(), out vo.m_objAttachRelation.m_intSysFrom);
                    //添加是否是先诊疗后结算的标示
                    int.TryParse(dr["isgreen_int"].ToString().Trim(), out vo.m_intIsGreen);
                    lstRec.Add(vo);
                }
            }
            #endregion

            #region part 2

            string Sql = @"select a.*, b.appdate, b.classCode, b.sourceId   
                              from eafInterface a
                             inner join eafApplication b
                                on a.requisitionID = b.appId
                             where b.status = 1
                               and b.classCode in ('0006', '0007') 
                               and (b.appdate between to_date('{0}', 'yyyy.mm.dd hh24:mi:ss') and to_date('{1}', 'yyyy.mm.dd hh24:mi:ss'))  
                               {2}
                             order by b.appdate, a.cardnumber";

            string subSql = string.Empty;
            if (p_strPatientNo.Trim() != string.Empty)
            {
                p_strPatientNo = p_strPatientNo.PadLeft(10, '0');
                subSql += string.Format(" and a.cardnumber = '{0}' ", p_strPatientNo);
            }
            if (p_strInPatientNo.Trim() != string.Empty)
            {
                subSql += string.Format(" and a.inhospitalnum = '{0}' ", p_strInPatientNo);
            }
            if (p_strPatientName.Trim() != string.Empty)
            {
                subSql += string.Format(" and a.patientname like '%{0}%' ", p_strPatientName);
            }
            if (p_strDept.Trim() != string.Empty)
            {
                subSql += string.Format(" and a.sentbydepartment like '%{0}%' ", p_strDept);
            }
            if (strApplyPart.Trim() != string.Empty)
            {
                subSql += string.Format(" and a.examineparts like '%{0}%' ", strApplyPart);
            }
            Sql = string.Format(Sql, fromDate, toDate, subSql);

            #endregion

            #region set value 2
            dt = dp.SqlSelect(Sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (lstRec == null)
                    lstRec = new List<clsApplyRecord>();
                clsApplyRecord vo = null;
                foreach (DataRow dr in dt.Rows)
                {
                    vo = new clsApplyRecord();
                    //vo.m_strDeposit = dr["deposit"].ToString();
                    //vo.m_strBalance = dr["balance"].ToString();
                    vo.m_strCheckNO = dr["patient_uid"].ToString();
                    vo.m_strClinicNO = dr["clinicalNum"].ToString();
                    vo.m_strBIHNO = dr["inHospitalNum"].ToString();
                    vo.m_strName = dr["patientName"].ToString();
                    vo.m_strSex = dr["patientSex"].ToString();
                    if(dr["patientBirthday"]!= DBNull.Value)
                        vo.m_strAge = (new com.digitalwave.iCare.ValueObject.clsBrithdayToAge()).m_strGetLongAge(Convert.ToDateTime(dr["patientBirthday"]));
                    vo.m_strArea = dr["hospitalDistrictNum"].ToString();
                    vo.m_strBedNO = dr["bedNum"].ToString();
                    vo.m_strTel = dr["patientTelephone"].ToString();
                    vo.m_strAddress = dr["patientAddress"].ToString();
                    vo.m_strSummary = dr["chargeDesc"].ToString();
                    vo.m_strDiagnose = dr["clinicalDiagnosis"].ToString();
                    vo.m_strDoctorName = dr["sentByDoctor"].ToString();
                    //vo.m_strDoctorNO = dr["doctorno"].ToString();
                    //vo.m_strExtraNO = dr["extrano"].ToString();
                    vo.m_strCardNO = dr["cardNumber"].ToString();
                    vo.m_strDepartment = dr["sentByDepartment"].ToString();
                    vo.m_strChargeDetail = dr["chargeDesc"].ToString();
                    //vo.m_datFinishDate = DateTime.Parse(dr["doctorChargesTime"].ToString());
                    vo.m_datApplyDate = DateTime.Parse(dr["appdate"].ToString());
                    //vo.m_intDeleted = int.Parse("0" + dr["deleted"].ToString());
                    vo.m_strApplyTitle = dr["examineType"].ToString();
                    //vo.m_strDiagnoseAim = dr["diagnoseaim"].ToString();
                    vo.m_strDiagnosePart = dr["examineParts"].ToString();
                    vo.m_strApplyID = dr["requisitionID"].ToString();
                    vo.m_strTypeID = dr["classCode"].ToString();
                    vo.m_intSubmitted = 1;
                    vo.m_intChargeStatus = 2;
                    vo.m_strSTATUS_INT = "1";
                    if (dr["acuteLevelDiagnosis"] != DBNull.Value && dr["acuteLevelDiagnosis"].ToString().IndexOf("急") >= 0)
                        vo.m_strUrgent = "1";
                    else
                        vo.m_strUrgent = "0";
                    vo.m_strStatus_int1 = "1";  // 已收费
                    int.TryParse(dr["sourceId"].ToString(), out vo.m_objAttachRelation.m_intSysFrom);
                    ////添加是否是先诊疗后结算的标示
                    //int.TryParse(dr["isgreen_int"].ToString().Trim(), out vo.m_intIsGreen);
                    lstRec.Add(vo);
                }
            }
            #endregion

            if (lstRec == null)
                return null;
            else
                return lstRec.ToArray();
        }

        public clsApplyRecord GetApplySingleRecord(string typeID)
        {

            string sql = @"select * from AR_COMMON_APPLY where APPLYID='" + typeID + "'";


            long lngRes = 0;
            clsApplyRecord rs = null;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            DataTable dt = new DataTable("dt");
            lngRes = objHRPSvc.DoGetDataTable(sql, ref dt);

            if (dt.Rows.Count > 0)
            {
                rs = new clsApplyRecord();
                rs.m_strDeposit = dt.Rows[0]["DEPOSIT"].ToString();
                rs.m_strBalance = dt.Rows[0]["BALANCE"].ToString();
                rs.m_strCheckNO = dt.Rows[0]["CHECKNO"].ToString();
                rs.m_strClinicNO = dt.Rows[0]["CLINICNO"].ToString();
                rs.m_strBIHNO = dt.Rows[0]["BIHNO"].ToString();
                rs.m_strName = dt.Rows[0]["NAME"].ToString();
                rs.m_strSex = dt.Rows[0]["SEX"].ToString();
                rs.m_strAge = dt.Rows[0]["AGE"].ToString();
                rs.m_strArea = dt.Rows[0]["AREA"].ToString();
                rs.m_strBedNO = dt.Rows[0]["BEDNO"].ToString();
                rs.m_strTel = dt.Rows[0]["TEL"].ToString();
                rs.m_strAddress = dt.Rows[0]["ADDRESS"].ToString();
                rs.m_strSummary = dt.Rows[0]["SUMMARY"].ToString();
                rs.m_strDiagnose = dt.Rows[0]["DIAGNOSE"].ToString();
                rs.m_strDoctorName = dt.Rows[0]["DOCTORNAME"].ToString();
                rs.m_strDoctorNO = dt.Rows[0]["DOCTORNO"].ToString();
                rs.m_strExtraNO = dt.Rows[0]["EXTRANO"].ToString();
                rs.m_strCardNO = dt.Rows[0]["CARDNO"].ToString();
                rs.m_strDepartment = dt.Rows[0]["DEPARTMENT"].ToString();
                rs.m_strChargeDetail = dt.Rows[0]["CHARGEDETAIL"].ToString();
                rs.m_datFinishDate = DateTime.Parse(dt.Rows[0]["FINISHDATE"].ToString());
                rs.m_datApplyDate = DateTime.Parse(dt.Rows[0]["APPLYDATE"].ToString());
                rs.m_intDeleted = int.Parse("0" + dt.Rows[0]["Deleted"].ToString());
                rs.m_strApplyTitle = dt.Rows[0]["ApplyTitle"].ToString();
                rs.m_strDiagnoseAim = dt.Rows[0]["DIAGNOSEAIM"].ToString();
                rs.m_strDiagnosePart = dt.Rows[0]["DIAGNOSEPART"].ToString();
                rs.m_strApplyID = dt.Rows[0]["ApplyID"].ToString();
                rs.m_strTypeID = dt.Rows[0]["TypeID"].ToString();
                rs.m_intSubmitted = int.Parse("0" + dt.Rows[0]["Submitted"].ToString());
                rs.m_intChargeStatus = int.Parse("0" + dt.Rows[0]["CHARGESTATUS_INT"].ToString());
                rs.m_strSTATUS_INT = dt.Rows[0]["STATUS_INT"].ToString();
            }
            else
            {

                rs = new clsApplyRecord();
                rs.m_strDeposit = "";
                rs.m_strBalance = "";
                rs.m_strCheckNO = "";
                rs.m_strClinicNO = "";
                rs.m_strBIHNO = "";
                rs.m_strName = "";
                rs.m_strSex = "";
                rs.m_strAge = "";
                rs.m_strArea = "";
                rs.m_strBedNO = "";
                rs.m_strTel = "";
                rs.m_strAddress = "";
                rs.m_strSummary = "";
                rs.m_strDiagnose = "";
                rs.m_strDoctorName = "";
                rs.m_strDoctorNO = "";
                rs.m_strExtraNO = "";
                rs.m_strCardNO = "";
                rs.m_strDepartment = "";
                rs.m_strChargeDetail = "";
                rs.m_datFinishDate = DateTime.Now;
                rs.m_datApplyDate = DateTime.Now;
                rs.m_intDeleted = 0;
                rs.m_strApplyTitle = "";
                rs.m_strDiagnoseAim = "";
                rs.m_strDiagnosePart = "";
                rs.m_strApplyID = "";
                rs.m_strTypeID = "";
                rs.m_intSubmitted = 0;
                rs.m_intChargeStatus = 0;
                rs.m_strSTATUS_INT = "";

            }


            //objHRPSvc.Dispose();
            return rs;



        }
        /// <summary>
        /// 根据检查单号获取VO
        /// </summary>
        /// <param name="applyID">检查单号</param>
        /// <returns></returns>
        public clsApplyRecord objGetVO(string applyID)
        {
            string sql = @"select * from AR_COMMON_APPLY where ApplyID = " + applyID;

            DataTable ds = dp.SqlSelect(sql);
            DataRow dr = ds.Rows[0];

            if (ds.Rows.Count < 1)
            {
                return null;
            }

            clsApplyRecord rs = new clsApplyRecord();


            rs.m_strDeposit = dr["DEPOSIT"].ToString();
            rs.m_strBalance = dr["BALANCE"].ToString();
            rs.m_strCheckNO = dr["CHECKNO"].ToString();
            rs.m_strClinicNO = dr["CLINICNO"].ToString();
            rs.m_strBIHNO = dr["BIHNO"].ToString();
            rs.m_strName = dr["NAME"].ToString();
            rs.m_strSex = dr["SEX"].ToString();
            rs.m_strAge = dr["AGE"].ToString();
            rs.m_strArea = dr["AREA"].ToString();
            rs.m_strBedNO = dr["BEDNO"].ToString();
            rs.m_strTel = dr["TEL"].ToString();
            rs.m_strAddress = dr["ADDRESS"].ToString();
            rs.m_strSummary = dr["SUMMARY"].ToString();
            rs.m_strDiagnose = dr["DIAGNOSE"].ToString();
            rs.m_strDoctorName = dr["DOCTORNAME"].ToString();
            rs.m_strDoctorNO = dr["DOCTORNO"].ToString();
            rs.m_strExtraNO = dr["EXTRANO"].ToString();
            rs.m_strCardNO = dr["CARDNO"].ToString();
            rs.m_strDepartment = dr["DEPARTMENT"].ToString();
            rs.m_strChargeDetail = dr["CHARGEDETAIL"].ToString();
            rs.m_datFinishDate = DateTime.Parse(dr["FINISHDATE"].ToString());
            rs.m_datApplyDate = DateTime.Parse(dr["APPLYDATE"].ToString());
            rs.m_intDeleted = int.Parse("0" + dr["Deleted"].ToString());
            rs.m_strApplyTitle = dr["ApplyTitle"].ToString();
            rs.m_strDiagnoseAim = dr["DIAGNOSEAIM"].ToString();
            rs.m_strDiagnosePart = dr["DIAGNOSEPART"].ToString();
            rs.m_strApplyID = dr["ApplyID"].ToString();
            rs.m_strTypeID = dr["TypeID"].ToString();
            rs.m_intSubmitted = int.Parse("0" + dr["Submitted"].ToString());
            rs.m_intChargeStatus = int.Parse("0" + dr["CHARGESTATUS_INT"].ToString());


            return rs;
        }

        /// <summary>
        /// 申请单交费状态修改
        /// </summary>
        /// <param name="sysFromID">来源 {1=门诊;2=住院;3=电子病历;4=其它}</param>
        /// <param name="sourceItemID">源id {if (门诊) = 处方id; if (住院) = 医嘱id}</param>
        /// <param name="newChargeStatus">缴费信息 0-不记录缴费信息 1-未缴费 2-已缴费 3-已退费</param>
        public void SetChargeStatus(string sysFromID, string sourceItemID, string newChargeStatus)
        {
            string sql = "select * from T_OPR_ATTACHRELATION where SYSFROM_INT = {0} and SOURCEITEMID_VCHR = '{1}'";
            DataTable ds = dp.SqlSelect(string.Format(sql, sysFromID, sourceItemID));
            string ids = "";

            foreach (DataRow dr in ds.Rows)
            {
                ids += dr["ATTACHID_VCHR"].ToString().Trim() + ",";
            }

            if (ids.EndsWith(",")) ids = ids.TrimEnd(',');
            if (ids == "") return;

            string updateSql = "update AR_COMMON_APPLY set CHARGESTATUS_INT = " + newChargeStatus +
                               " where ApplyID IN (" + ids + ")";
            dp.SqlExecute(updateSql);
        }
    }
}
