using System;
using iCareData;
using System.Collections;
using System.ComponentModel;

namespace iCare
{
	/// <summary>
	/// Summary description for clsDataSearchesMake.
	/// </summary>
	public class clsDataSearchesMake
	{
		private Hashtable m_hstMainSql = new Hashtable();
        private bool m_blnIsSpesifyDept = false;
        private string m_strDeptID = "";
        private frmDataSearches m_frmDataSearch = null;
		public clsDataSearchesMake()
		{
			m_mthInitArray();
		}

        /// <summary>
        /// 生成检索条件
        /// </summary>
        /// <param name="p_blnIsSpesifyDept">是否指定查询科室</param>
        /// <param name="p_strDeptID">指定查询科室ID(如果指定查询科室，此参数值须有效)</param>
        /// <param name="p_intDeptAttribute">指定查询科室类型(如果指定查询科室，此参数值须有效)</param>
        /// <param name="p_frmDataSearch">数据检索窗体</param>
        public clsDataSearchesMake(bool p_blnIsSpesifyDept, string p_strDeptID,int p_intDeptAttribute, frmDataSearches p_frmDataSearch)
        {
            m_blnIsSpesifyDept = p_blnIsSpesifyDept;
            m_strDeptID = p_strDeptID;
            m_frmDataSearch = p_frmDataSearch;
            m_intDeptAttribute = p_intDeptAttribute;
            m_mthInitArray();
        }

		public void m_mthMakeFieldSql()
		{}

		private void m_mthInitArray()
		{
//			string strSql = @"select distinct b.inpatientid,b.inpatientdate,a.FirstName
//from PatientBaseInfo a inner join  InDeptInfo b 
//on a.inpatientid = b.inpatientid 
//inner join InPatientDateInfo c on b.inpatientid = c.inpatientid and b.inpatientdate = c.inpatientdate
//where  (" + m_mthGetAllManageDept("b") + ")";
//            string strSql = @"select distinct a.INPATIENTID_CHR as inpatientid,
//											b.INPATIENT_DAT   as inpatientdate,
//											a.LASTNAME_VCHR   as FirstName,
//											d.modify_dat      as OutDate,
//											b.deptid_chr      as deptid,
//											b.areaid_chr      as areaid
//							from T_BSE_PATIENT a
//							inner join T_OPR_BIH_REGISTER b on a.PATIENTID_CHR = b.PATIENTID_CHR
//							inner join T_BSE_DEPTDESC c on b.DEPTID_CHR = c.DEPTID_CHR
//							left outer join (select * from T_OPR_BIH_LEAVE where status_int = 1) d on d.REGISTERID_CHR = b.REGISTERID_CHR
//							where (" + m_mthGetAllRelationDept("c") + ")";
            //主SQL
            string strSql = @"select rehis.hisinpatientid_chr inpatientid,
               rehis.hisinpatientdate inpatientdate,
                                            pa.LASTNAME_VCHR   FirstName,
                                            le.modify_dat      OutDate,
                                            re.deptid_chr      deptid,
                                            re.areaid_chr      areaid,
                                            re.EXTENDID_VCHR,
                                            rehis.EMRINPATIENTID,  
                                            rehis.EMRINPATIENTDATE,
               re.registerid_chr
                              from t_opr_bih_registerdetail pa
                             inner join T_OPR_BIH_REGISTER re on pa.registerid_chr = re.registerid_chr and re.STATUS_INT <> 0 and re.PSTATUS_INT <> 0 and re.bedid_chr is not null
                             inner join T_BSE_HISEMR_RELATION rehis on rehis.registerid_chr = re.registerid_chr
                             inner join T_OPR_BIH_TRANSFER tr on tr.registerid_chr = re.registerid_chr
                              left outer join (select * from T_OPR_BIH_LEAVE where status_int = 1) le on le.REGISTERID_CHR =
                                                                                                         re.REGISTERID_CHR
                             where (" + m_mthGetRelationDept("tr") + ")";
			m_hstMainSql.Add("S1",strSql);
            //手术记录
			strSql = @"SELECT distinct ORD.InPatientID, ORD.InPatientDate
FROM OperationRecordDoctor ORD INNER JOIN
      OperationRecordContenDoctor ORCD ON 
      ORD.InPatientID = ORCD.InPatientID AND 
      ORD.InPatientDate = ORCD.InPatientDate AND
       ORD.OpenDate = ORCD.OpenDate
where ORCD.LastModifyDate = (select max(LastModifyDate) from OperationRecordContenDoctor ORCD2 where ORCD2.InPatientID = ORCD.InPatientID AND 
      ORCD2.InPatientDate = ORCD.InPatientDate AND
       ORCD2.OpenDate = ORCD.OpenDate) ";
			m_hstMainSql.Add("S2",strSql);
            //普通住院病历
			strSql = @"select distinct IPH.inpatientid ,IPH.inpatientdate from InPatientCaseHistory_History IPH
inner join IPCASEHISTORY_HISTORYCONTENT IPHC
on IPH.inpatientid = IPHC.inpatientid and IPH.inpatientdate = IPHC.inpatientdate and IPH.opendate = IPHC.opendate
where IPHC.LastModifyDate = (select max(LastModifyDate) from IPCASEHISTORY_HISTORYCONTENT
where inpatientid = IPHC.inpatientid and inpatientdate = IPHC.inpatientdate and opendate = IPHC.opendate) ";
			m_hstMainSql.Add("S3",strSql);
            //专科病历
			strSql = @"select DISTINCT IMR.InPatientID, IMR.InPatientDate from InpatMedRec IMR where 1=1";
			m_hstMainSql.Add("S4",strSql);
            //最小元素集
            strSql = @"SELECT DISTINCT hr.emrinpatientid inpatientid,
                             hr.emrinpatientdate inpatientdate
  FROM min_elementcol_valuemain mv inner join t_bse_hisemr_relation hr
  on mv.registerid_chr = hr.registerid_chr
 where 1 = 1";
			m_hstMainSql.Add("S41",strSql);
			
			#region 住院病案首页
			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from INHOSPITALMAINRECORD_CONTENT IHMC
						left Outer join (select a.*
											from IHMainRecord_OtherDiagnosis a
											where a.LastModifyDate =
												(select max(LastModifyDate)
													from IHMainRecord_OtherDiagnosis
													where inpatientid = a.inpatientid
													and inpatientdate = a.inpatientdate
													and opendate = a.opendate)) ss1 on ss1.inpatientid =
																						IHMC.inpatientid
																					and ss1.inpatientdate =
																						IHMC.inpatientdate
																					and ss1.opendate =
																						IHMC.opendate
						where IHMC.STATUS <> -1";//加一个主表中明显成立的字段条件
			m_hstMainSql.Add("S5",strSql);

			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from INHOSPITALMAINRECORD_CONTENT IHMC
						left Outer join (select b.*
											from InHospitalMainRecord_Operation b
											where b.LastModifyDate =
												(select max(LastModifyDate)
													from InHospitalMainRecord_Operation
													where inpatientid = b.inpatientid
													and inpatientdate = b.inpatientdate
													and opendate = b.opendate)) ss2 on ss2.inpatientid =
																						IHMC.inpatientid
																					and ss2.inpatientdate =
																						IHMC.inpatientdate
																					and ss2.opendate =
																						IHMC.opendate
						where IHMC.STATUS <> -1";//加一个主表中明显成立的字段条件
			m_hstMainSql.Add("S6",strSql);

			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from INHOSPITALMAINRECORD_CONTENT IHMC
						left Outer join (select c.*
											from InHospitalMainRecord_Baby c
											where c.LastModifyDate =
												(select max(LastModifyDate)
													from InHospitalMainRecord_Baby
													where inpatientid = c.inpatientid
													and inpatientdate = c.inpatientdate
													and opendate = c.opendate)) ss3 on ss3.inpatientid =
																						IHMC.inpatientid
																					and ss3.inpatientdate =
																						IHMC.inpatientdate
																					and ss3.opendate =
																						IHMC.opendate
						where IHMC.STATUS <> -1";//加一个主表中明显成立的字段条件
			m_hstMainSql.Add("S7",strSql);

			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from INHOSPITALMAINRECORD_CONTENT IHMC
						left Outer join (select d.*
											from IHMainRecord_Chemotherapy d
											where d.LastModifyDate =
												(select max(LastModifyDate)
													from IHMainRecord_Chemotherapy
													where inpatientid = d.inpatientid
													and inpatientdate = d.inpatientdate
													and opendate = d.opendate)) ss4 on ss4.inpatientid =
																						IHMC.inpatientid
																					and ss4.inpatientdate =
																						IHMC.inpatientdate
																					and ss4.opendate =
																						IHMC.opendate
						where IHMC.STATUS <> -1";//加一个主表中明显成立的字段条件
			m_hstMainSql.Add("S8",strSql);
			#endregion

			#region 住院病案首页(广西)
			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXCON IHMC
						where IHMC.STATUS <> -1";
			m_hstMainSql.Add("S9",strSql);

			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXCON IHMC
						left outer join T_EMR_INHOSPITALMAINREC_GXOD IHMD on IHMC.emr_seq =
																			IHMD.emr_seq
						where IHMC.STATUS <> -1";
			m_hstMainSql.Add("S10",strSql);

			strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXCON IHMC
						left outer join T_EMR_INHOSPITALMAINREC_GXOP IHMO on IHMC.emr_seq =
																			IHMO.emr_seq
						where IHMC.STATUS <> -1";
			m_hstMainSql.Add("S11",strSql);

            strSql = @"select distinct IHMC.inpatientid, IHMC.inpatientdate
						from T_EMR_INHOSPITALMAINREC_GXCON IHMC
						left outer join T_EMR_INHOSPITALMAINREC_GXID IHID on IHMC.emr_seq =
																			IHID.emr_seq
						where IHMC.STATUS <> -1";
            m_hstMainSql.Add("S15", strSql);
			#endregion

			#region 24小时内入出院记录
			strSql = @"select distinct OH24.INPATIENTID, OH24.Inpatientdate
						from T_EMR_OUTHOSPITALIN24HOURS OH24
						where OH24.Status <> -1";
			m_hstMainSql.Add("S12",strSql);
			#endregion

			#region 入院24小时内死亡记录
			strSql = @"select distinct DH24.INPATIENTID, DH24.Inpatientdate
						from T_EMR_DEATHRECORDIN24HOURS DH24
						where DH24.Status <> -1";
			m_hstMainSql.Add("S13",strSql);
			#endregion

            #region 医嘱查询
            DateTime dtmStartTime = DateTime.Now.AddMonths(-6);
//            strSql = @"SELECT distinct DocOrder.patient_id, DocOrder.visit_id, Pat.admission_date_time
//                      FROM doctor_orders         DocOrder,
//                           order_clinic_classmap OrderMap,
//                           order_class_dict      OrderDict,
//                           orders                ,
//                           pat_visit             Pat
//                     WHERE DocOrder.patient_id = Pat.patient_id
//                       AND DocOrder.visit_id = Pat.visit_id
//                       AND (DocOrder.start_stop_indicator = 1 OR (DocOrder.start_stop_indicator = 0" + m_strFindOrderSQL() + @"))
//                       AND DocOrder.order_class = OrderMap.item_class_code(+)
//                       AND OrderMap.order_class_code = OrderDict.order_class_code(+)
//                       AND DocOrder.patient_id = orders.patient_id(+)
//                       AND DocOrder.visit_id = orders.visit_id(+)
//                       AND DocOrder.related_order_no = orders.order_no(+)
//                       AND DocOrder.related_order_sub_no = orders.order_sub_no(+)";
            strSql = @"SELECT tr.patient_id, tr.visit_id
  FROM transfer tr
 WHERE " + m_mthGetExtendDeptID("tr") + @"
   and exists
 (select docorder.patient_id, docorder.visit_id
          FROM doctor_orders docorder, orders
         where docorder.patient_id = tr.patient_id
           and docorder.visit_id = tr.visit_id
           and docorder.patient_id = orders.patient_id(+)
           AND docorder.visit_id = orders.visit_id(+)
           AND docorder.related_order_no = orders.order_no(+)
           AND docorder.related_order_sub_no = orders.order_sub_no(+)
           and docorder.start_date_time >
               To_date('" + dtmStartTime.ToString("yyyy-MM-dd") + @"', 'yyyy-mm-dd hh24:mi:ss')
           AND (docorder.start_stop_indicator = 1 OR
               (docorder.start_stop_indicator = 0 " + m_strFindOrderSQL() + @"))) ";
            m_hstMainSql.Add("S14", strSql); 
            #endregion
		}

        private string m_strFindOrderSQL()
        {
            string strTemp = "";
            if (m_frmDataSearch != null)
            {
                strTemp = m_frmDataSearch.m_StrFindOrderSQL;
            }
            return strTemp;
        }

		public string m_strGetMainSQL(string p_strKey)
		{
			if(m_hstMainSql.Contains(p_strKey))
				return m_hstMainSql[p_strKey] as string;
			return null;
		}

		public clsExpressionInfo[] m_objGetExpItemArr(string p_strType)
		{
			clsExpressionInfo[] obj = null;
			string[] strItemArr = null;
			string[] strConditionArr = null;
			switch(p_strType)
			{
				case "STRING":
					strItemArr = new string[]{"内容是","内容开头是","内容包含","内容结尾是"};
					strConditionArr = new String[strItemArr.Length];
					strConditionArr[0] = @" = '<CONTENT>'";
					strConditionArr[1] = @" like '<CONTENT>%'";
					strConditionArr[2] = @" like '%<CONTENT>%'";
					strConditionArr[3] = @" like '%<CONTENT>'";
					obj = new clsExpressionInfo[strItemArr.Length];
					for(int i=0;i<strItemArr.Length;i++)
					{
						obj[i] = new clsExpressionInfo();
						obj[i].m_strType = strItemArr[i];
						obj[i].m_strExpressionArr = strConditionArr[i];
					}
					return obj;
				case "INT":
					strItemArr = new string[]{"等于","范围","大于","大于等于","小于","小于等于","不等于"};
					strConditionArr = new String[strItemArr.Length];
					strConditionArr[0] = @" = '<FIRSTNUMBER>'";
					strConditionArr[1] = @" between '<FIRSTNUMBER>' and '<ENDNUMBER>' ";
					strConditionArr[2] = @" > '<FIRSTNUMBER>'";
					strConditionArr[3] = @" >= '<FIRSTNUMBER>'";
					strConditionArr[4] = @" < '<FIRSTNUMBER>'";
					strConditionArr[5] = @" <= '<FIRSTNUMBER>'";
					strConditionArr[6] = @"<> '<FIRSTNUMBER>'";
					obj = new clsExpressionInfo[strItemArr.Length];
					for(int k=0;k<strItemArr.Length;k++)
					{
						obj[k] = new clsExpressionInfo();
						obj[k].m_strType = strItemArr[k];
						obj[k].m_strExpressionArr = strConditionArr[k];
					}
					return obj;
				case "DATE":
					strItemArr = new string[]{"日期是","日期范围"};
					strConditionArr = new String[strItemArr.Length];
					strConditionArr[1] = " between <FIRSTDATE> and <ENDDATE> ";
                    strConditionArr[0] = " between <FIRSTDATE> and <ENDDATE> ";
					obj = new clsExpressionInfo[strItemArr.Length];
					for(int j=0;j<strItemArr.Length;j++)
					{
						obj[j] = new clsExpressionInfo();
						obj[j].m_strType = strItemArr[j];
						obj[j].m_strExpressionArr = strConditionArr[j];
					}
					return obj;
				default :
					break;
			}
			return null;
		}
		public string m_mthGetAllManageDept(string p_strShortNo)
		{
			string strSql = "";
			clsDept_Desc[] objDeptArr = null;
			long lngRes = new clsDepartmentManager().m_lngGetDeptArr_EmployeeCanManage(null,clsEMRLogin.LoginInfo.m_strEmpNo,out objDeptArr);
			if(lngRes > 0 && objDeptArr != null && objDeptArr.Length > 0)
			{
				strSql = " "+p_strShortNo+".SHORTNO_CHR = '"+objDeptArr[0].m_strShortNO.Trim()+"' ";
				for(int i=1;i<objDeptArr.Length;i++)
				{
					strSql += " or "+p_strShortNo+".SHORTNO_CHR = '"+objDeptArr[i].m_strShortNO.Trim()+"' ";
				}
				return strSql + " ";
			}
			else
				return " "+p_strShortNo+".SHORTNO_CHR = '' ";
		}

		public string m_mthGetExtendDeptID(string p_strShortNo)
		{
            long lngRes = 0;
            if (m_blnIsSpesifyDept)
            {
                string strExtendID = string.Empty;
                lngRes = new clsDepartmentManager().m_lngGetExtendDeptID(m_strDeptID, out strExtendID);
                if (strExtendID == null)
                    strExtendID = "";
                return "" + p_strShortNo + ".dept_stayed = '" + strExtendID.Trim() + "'";
            }
            else
            {
                string strSql = "";
                string[] strExtendIDArr = null;

                com.digitalwave.DepartmentManagerService.clsDepartmentManagerService objService =
                    (com.digitalwave.DepartmentManagerService.clsDepartmentManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DepartmentManagerService.clsDepartmentManagerService));

                lngRes = objService.m_lngGetExtendDeptIDArr(clsEMRLogin.LoginInfo.m_strEmpID, out strExtendIDArr);
                if (lngRes > 0 && strExtendIDArr != null && strExtendIDArr.Length > 0)
                {
                    if (strExtendIDArr.Length > 1)
                        strSql += " (";
                    strSql += p_strShortNo + ".dept_stayed = '" + strExtendIDArr[0] + "' ";
                    for (int i = 1; i < strExtendIDArr.Length; i++)
                    {
                        strSql += " or " + p_strShortNo + ".dept_stayed = '" + strExtendIDArr[i] + "' ";
                        if (i == strExtendIDArr.Length - 1)
                            strSql += ")";
                    }
                    return strSql + " ";
                }
                else
                    return " " + p_strShortNo + ".dept_stayed = '' ";
            }
		}

        /// <summary>
        /// 科室类型(1：部门；2：科室；3：病区)，默认为科室
        /// </summary>
        private int m_intDeptAttribute = 2;

        /// <summary>
        /// 获取或设置科室类型(1：部门；2：科室；3：病区)
        /// </summary>
        public int m_DeptAttribute
        {
            get
            {
                return m_intDeptAttribute;
            }
            set
            {
                m_intDeptAttribute = value;
            }
        }

        public string m_mthGetRelationDept(string p_strShortNo)
        {
            if (m_blnIsSpesifyDept)
            {
                if (m_intDeptAttribute == 3)
                {
                    if (m_strDeptID == null)
                        return "(" + p_strShortNo + ".SOURCEAREAID_CHR = '' or " + p_strShortNo + ".TARGETAREAID_CHR = '') ";
                    else
                        return "(" + p_strShortNo + ".SOURCEAREAID_CHR = '" + m_strDeptID.Trim()
                            + "' or " + p_strShortNo + ".TARGETAREAID_CHR = '" + m_strDeptID.Trim() + "')";
                }
                else
                {
                    if (m_strDeptID == null)
                        return "(" + p_strShortNo + ".sourcedeptid_chr = '' or " + p_strShortNo + ".targetdeptid_chr = '') ";
                    else
                        return "(" + p_strShortNo + ".sourcedeptid_chr = '" + m_strDeptID.Trim()
                            + "' or " + p_strShortNo + ".targetdeptid_chr = '" + m_strDeptID.Trim() + "')";
                }
            }
            else
            {
                string strSql = "";
                strSql += @"(exists
                        (select deptid_chr
                           from t_bse_deptemp b
                          where b.empid_chr = '" + clsEMRLogin.LoginInfo.m_strEmpID + @"'
                            and b.deptid_chr = " + p_strShortNo + @".SOURCEAREAID_CHR) or exists
                        (select deptid_chr
                           from t_bse_deptemp b
                          where b.empid_chr = '" + clsEMRLogin.LoginInfo.m_strEmpID + @"'
                            and b.deptid_chr = " + p_strShortNo + @".TARGETAREAID_CHR) or exists
                        (select deptid_chr
                           from t_bse_deptemp a
                          where a.empid_chr = '" + clsEMRLogin.LoginInfo.m_strEmpID + @"'
                            and a.deptid_chr = " + p_strShortNo + @".targetdeptid_chr) or exists
                        (select deptid_chr
                           from t_bse_deptemp b
                          where b.empid_chr = '" + clsEMRLogin.LoginInfo.m_strEmpID + @"'
                            and b.deptid_chr = " + p_strShortNo + @".sourcedeptid_chr))";
                return strSql + " ";
            }
        }
		
	}

    [Serializable]
	public class clsKeyAndFormName
	{
		public clsKeyAndFormName(string p_strSQLKey,string p_strFormID,string p_strTemplate)
		{
			m_strSQLKey = p_strSQLKey;
			m_strFormID = p_strFormID;
			m_strTemplateID = p_strTemplate;
		}
		/// <summary>
		/// 获取主SQL的键
		/// </summary>
		public string m_strSQLKey = "";
		/// <summary>
		/// 窗体ID
		/// </summary>
		public string m_strFormID = "";
		/// <summary>
		/// 模板ID
		/// </summary>
		public string m_strTemplateID = "";
    }
    [Serializable]
	public class clsDataSearchesType
	{
		/// <summary>
		/// 数据类型
		/// </summary>
		public string m_strDataType;
		/// <summary>
		/// 对应字段名称
		/// </summary>
		public string m_strFieldName;
		/// <summary>
		/// 控件名称
		/// </summary>
		public string m_strItemID;
		/// <summary>
		/// 控件描述
		/// </summary>
		public string m_strItemDesc = "";
		/// <summary>
		/// 控件类型
		/// </summary>
		public string m_strItemType = "";
	}

    [Serializable]
	public class clsExpressionInfo
	{
		/// <summary>
		/// 条件类型
		/// </summary>
		public string m_strType;
		/// <summary>
		/// SQL表达式
		/// </summary>
		public string m_strExpressionArr;

		public override string ToString()
		{
			return m_strType;
		}
    }
    [Serializable]
	public class clsDateSearchesCondition
	{
		/// <summary>
		/// 获取主SQL的键
		/// </summary>
		public string m_strSQLKey;
		/// <summary>
		/// 树结点路径，即查找序列
		/// </summary>
		public string m_strName = "";
		/// <summary>
		/// 表达式类型
		/// </summary>
		public clsExpressionInfo m_objSelectedItem = null;
		/// <summary>
		/// 第一个值
		/// </summary>
		public string m_strFirstValue = "";
		/// <summary>
		/// 第二个值
		/// </summary>
		public string m_strSecondValue = "";
		/// <summary>
		/// Bool值
		/// </summary>
		public bool m_blnBoolValue;
		/// <summary>
		/// 一个条件的SQL
		/// </summary>
		public string m_strSearchesSQL;
        /// <summary>
        /// 连接类型描述
        /// </summary>
        public string m_strConnTypeDesc = "";

		public override string ToString()
		{
			int intIndex = m_strName.LastIndexOf(">>");
			string strName = m_strName;
			if(intIndex >=0)
				strName = m_strName.Substring(intIndex+2);
			string temp = "";
			if(m_strFirstValue == "" && m_strSecondValue == "")
				temp = (m_blnBoolValue?"为真":"为假");
			else
			{
				temp = (m_strSecondValue == ""?m_strFirstValue.Replace("<FIRST>",""):m_strFirstValue.Replace("<FIRST>","从")+ m_strSecondValue.Replace("<SECOND>","到"));
			}
            return m_strConnTypeDesc  + strName + ": " + (m_objSelectedItem == null ? "" : m_objSelectedItem.ToString()) + temp;
		}
    }
    [Serializable]
	public class clsCustomSearchesCondition : clsDateSearchesCondition
	{
		public CustomForm.clsCustomSyncField m_objSyncField;
	}
}
