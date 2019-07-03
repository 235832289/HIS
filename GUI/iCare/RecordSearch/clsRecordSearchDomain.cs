using System;
using System.Data;
using com.digitalwave.StatisticsService;
//using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.DepartmentManagerService;
using com.digitalwave.InHospitalMainRecord;
using com.digitalwave.iCare.ValueObject;
using iCare.ICU.Evaluation;

namespace iCare.RecordSearch
{
	/// <summary>
	/// Summary description for clsRecordSearchDomain.
	/// </summary>
	public class clsRecordSearchDomain
	{
        //private clsRecordSearchService m_objService;
        //private CustomFromService.clsMinElementColServ m_objServ;
        //private clsDepartmentHandlerService m_objDeptServ;

		public clsRecordSearchDomain()
		{
            //m_objService = new clsRecordSearchService();
            //m_objServ = new CustomFromService.clsMinElementColServ();
            //m_objDeptServ = new clsDepartmentHandlerService();
		}

		/// <summary>
		/// 获取表单信息
		/// </summary>
		/// <returns></returns>
		public clsFormInfo [] m_objGetFormInfoArr()
		{
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetFormInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }

			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return null;

			clsFormInfo [] objFormInfoArr = new clsFormInfo[dtResult.Rows.Count];
            DataRow objRow = null;
			for(int i=0;i<dtResult.Rows.Count;i++)
			{
                objRow = dtResult.Rows[i];
                clsFormInfo objFormInfo = new clsFormInfo();
                objFormInfo.m_strFormName = objRow["FORMNAME"].ToString();
                objFormInfo.m_strSearchInfoType = objRow["SEARCHINFOTYPE"].ToString();
                objFormInfo.m_strMainSearchInfo = objRow["MAINSEARCHINFO"].ToString();
                objFormInfoArr[i] = objFormInfo;
			}
			
			return objFormInfoArr;
		}

		/// <summary>
		/// 获取表单的字段信息
		/// </summary>
		/// <param name="p_objFormInfo">表单信息</param>
		public void m_objGetFieldInfoArr(ref clsFormInfo p_objFormInfo)
		{
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetFieldInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objFormInfo.m_strFormName,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return ;

            clsFieldInfo[] objFieldInfoArr = new clsFieldInfo[dtResult.Rows.Count];
            DataRow objRow = null;
			for(int i=0;i<dtResult.Rows.Count;i++)
            {
                objRow = dtResult.Rows[i];
                clsFieldInfo objFieldInfo = new clsFieldInfo();
				objFieldInfo.m_strFieldName = objRow["FIELDNAME"].ToString();
				objFieldInfo.m_strConditionFieldType = objRow["CONDITIONFIELDTYPE"].ToString();
				objFieldInfo.m_strConditionFieldName = objRow["CONDITIONFIELDNAME"].ToString();
				objFieldInfoArr[i] = objFieldInfo;
			}			

			p_objFormInfo.m_objFieldInfoArr = objFieldInfoArr;
		}

		public clsPatientList[] m_objGetPatientListArr(iCareData.clsRecordSearch_SearchInfo p_objSearchInfo)
		{
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetPatientList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objSearchInfo,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return null;

			clsPatientList [] objPatientListArr = new clsPatientList[dtResult.Rows.Count];
            DataRow objRow = null;
			for(int i=0;i<dtResult.Rows.Count;i++)
            {
                objRow = dtResult.Rows[i];
                clsPatientList objPatientList = new clsPatientList();
				objPatientList.m_strInPatientNO = objRow["INPATIENTID"].ToString();
				objPatientList.m_strInPatientDate= objRow["INPATIENTDATE"].ToString();
				objPatientList.m_strOpenDate = objRow["OPENDATE"].ToString();
				objPatientList.m_strFirstName = objRow["FIRSTNAME"].ToString();
				objPatientList.m_strSex = objRow["SEX"].ToString();
				objPatientList.m_strAge = objRow["AGE"].ToString();
				objPatientList.m_strCreateDate = objRow["CREATEDATE"].ToString();
				objPatientList.m_strCreateUserID = objRow["CREATEUSERID"].ToString();
				objPatientList.m_strCreateUserName = objRow["CREATEUSERNAME"].ToString();
                objPatientListArr[i] = objPatientList;
			}
			
			return objPatientListArr;			
		}

		/// <summary>
		/// 查询病人记录信息
		/// </summary>
		/// <param name="p_strInPatientNO"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_dtbResult"></param>
		/// <returns></returns>
		public long m_lngGetPatientRecordCount(string p_strTypeID, string p_strTypeName, string p_strInPatientNO,string p_strInPatientDate, iCareData.clsCustom_SubmitValue[] p_objCustomForms,out DataTable p_dtbResult)
		{
            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetPatientRecordCount(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,p_strTypeName,p_strInPatientNO,p_strInPatientDate,p_objCustomForms,out p_dtbResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取专科病历表单（新专科病历用）
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_objFormInfoArr"></param>
		/// <returns></returns>
		public long m_lngIMR_GetFormInfo(string p_strDeptID,out clsFormInfo[] p_objFormInfoArr)
		{
			p_objFormInfoArr = null;
			DataTable dtResult;
			string strSearchInfoSql=null;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
			{
				 strSearchInfoSql = @"select distinct PBI.FirstName,PBI.Sex,DATEDIFF(year, convert(datetime,PBI.Birth,120), getdate()) as Age,
						b.InPatientID,b.InPatientDate,b.OpenDate,EBI_Record.FirstName as CreateUserName,
						b.OpenDate as CreateDate,a.CreateUserID
						from InpatMedRec a inner join InpatMedRec_Item b
						on a.TypeID = b.TypeID
						and a.InPatientID = b.InPatientID
						and a.InPatientDate = b.InpatientDate
						and a.OpenDate = b.OpenDate
						inner join PatientBaseInfo PBI
						on a.InPatientID = PBI.InPatientID
						inner join EmployeeBaseInfo EBI_Record
						on a.CreateUserID = EBI_Record.EmployeeID
						inner join Dept_Employee DE
						on a.CreateUserID = DE.EmployeeID and DE.EndDate = $NULLDate$
						where a.Status = 0
						and a.TypeID = $TypeID$
						and DE.DeptID = $DeptID$
						and ";
			}
			else
			{
					 strSearchInfoSql = @"select distinct PBI.FirstName,PBI.Sex,to_number(To_Char(sysdate,'YYYY'))-to_number(To_Char(PBI.Birth,'YYYY')) as Age,
					b.InPatientID,b.InPatientDate,b.OpenDate,EBI_Record.FirstName as CreateUserName,
					b.OpenDate as CreateDate,a.CreateUserID
					from InpatMedRec a inner join InpatMedRec_Item b
					on a.TypeID = b.TypeID
					and a.InPatientID = b.InPatientID
					and a.InPatientDate = b.InpatientDate
					and a.OpenDate = b.OpenDate
					inner join PatientBaseInfo PBI
					on a.InPatientID = PBI.InPatientID
					inner join EmployeeBaseInfo EBI_Record
					on a.CreateUserID = EBI_Record.EmployeeID
					inner join Dept_Employee DE
					on a.CreateUserID = DE.EmployeeID and DE.EndDate = $NULLDate$
					where a.Status = 0
					and a.TypeID = $TypeID$
					and DE.DeptID = $DeptID$
					and ";
				
			}

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngIMR_GetFormInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return lngRes;

			p_objFormInfoArr = new clsFormInfo[dtResult.Rows.Count];
            DataRow objRow = null;
			for(int i=0;i<dtResult.Rows.Count;i++)
            {
                clsFormInfo objFormInfo = new clsFormInfo();
                objRow = dtResult.Rows[i];
                objFormInfo.m_strFormID = objRow["TYPEID"].ToString();
                objFormInfo.m_strFormName = objRow["TYPENAME"].ToString();
                objFormInfo.m_strSearchInfoType = "AND";
                objFormInfo.m_strMainSearchInfo = strSearchInfoSql;
                p_objFormInfoArr[i] = objFormInfo;
			}
			return lngRes;
		}

		/// <summary>
		/// 获取表单的字段信息（新专科病历用）
		/// </summary>
		/// <param name="p_objFormInfo">表单信息</param>
		public void m_mthIMR_GetFieldInfo(ref clsFormInfo p_objFormInfo)
		{
			if(p_objFormInfo == null || p_objFormInfo.m_strFormName == null)
				return;
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngIMR_GetFieldInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objFormInfo.m_strFormID,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return ;

			clsFieldInfo [] objFieldInfoArr = new clsFieldInfo[dtResult.Rows.Count+5];

			#region 固定内容
			objFieldInfoArr[0] = new clsFieldInfo();
			objFieldInfoArr[0].m_strFieldName = "住院号";
			objFieldInfoArr[0].m_strConditionFieldType = "text";
			objFieldInfoArr[0].m_strConditionFieldName = "b.InPatientID";

			objFieldInfoArr[1] = new clsFieldInfo();
			objFieldInfoArr[1].m_strFieldName = "患者姓名";
			objFieldInfoArr[1].m_strConditionFieldType = "text";
			objFieldInfoArr[1].m_strConditionFieldName = "PBI.FirstName";

			objFieldInfoArr[2] = new clsFieldInfo();
			objFieldInfoArr[2].m_strFieldName = "性别";
			objFieldInfoArr[2].m_strConditionFieldType = "text";
			objFieldInfoArr[2].m_strConditionFieldName = "PBI.Sex";

			objFieldInfoArr[3] = new clsFieldInfo();
			objFieldInfoArr[3].m_strFieldName = "年龄";
			objFieldInfoArr[3].m_strConditionFieldType = "number";
			objFieldInfoArr[3].m_strConditionFieldName = "datediff(year,PBI.Birth,getdate())";

			objFieldInfoArr[4] = new clsFieldInfo();
			objFieldInfoArr[4].m_strFieldName = "入院日期";
			objFieldInfoArr[4].m_strConditionFieldType = "date";
			objFieldInfoArr[4].m_strConditionFieldName = "b.InPatientDate";
			#endregion

			for(int i=0;i<dtResult.Rows.Count;i++)
			{
				objFieldInfoArr[i+5] = new clsFieldInfo();
				objFieldInfoArr[i+5].m_strFieldName = dtResult.Rows[i]["ITEMNAME"].ToString();
				switch(dtResult.Rows[i]["ITEMTYPE"].ToString().Trim())
				{
					case "RichTextBox":
					case "ctlBorderTextBox":
					case "ctlComboBox":
					case "ctlRichTextBox":
					default:
						objFieldInfoArr[i+5].m_strConditionFieldType = "text";
						break;
					case "ctlTimePicker":
						objFieldInfoArr[i+5].m_strConditionFieldType = "date";
						break;
					case "RadioButton":
					case "CheckBox":
						objFieldInfoArr[i+5].m_strConditionFieldType = "truefalse";
						break;
				}
				objFieldInfoArr[i+5].m_strConditionFieldName = @"b.ItemID = '" + dtResult.Rows[i]["ITEMID"].ToString() + "' and b.ItemContent";
			}			

			p_objFormInfo.m_objFieldInfoArr = objFieldInfoArr;
		}
		/// <summary>
		///  获取科室下专科病历表单（数据检索用）
		/// </summary>
		/// <param name="p_strDeptID"></param>
		/// <param name="p_objFormInfoArr"></param>
		/// <returns></returns>
		public long m_lngIMR_NewGetFormInfo(/*string p_strDeptID,*/out iCareData.clsInpatMedRec_Type[] p_objFormInfoArr)
		{
			p_objFormInfoArr = null;
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngIMR_GetFormInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial/*,p_strDeptID*/,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return lngRes;

			p_objFormInfoArr = new iCareData.clsInpatMedRec_Type[dtResult.Rows.Count];

			for(int i=0;i<dtResult.Rows.Count;i++)
			{
				p_objFormInfoArr[i] = new iCareData.clsInpatMedRec_Type();
				p_objFormInfoArr[i].m_strTypeID = dtResult.Rows[i]["TYPEID"].ToString();
				p_objFormInfoArr[i].m_strTypeName = dtResult.Rows[i]["TYPENAME"].ToString();
			}
			return lngRes;
		}
		/// <summary>
		/// 获取表单的字段信息（数据检索用）
		/// </summary>
		/// <param name="p_strFormID"></param>
		/// <param name="p_objItemInfo"></param>
		public void m_mthIMR_NewGetItemInfo(string p_strFormID,out iCareData.clsInpatMedRec_Type_Item[] p_objItemInfo)
		{
			p_objItemInfo = null;
			if(p_strFormID == null || p_strFormID == "")
				return;
			DataTable dtResult;

            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngIMR_GetFieldInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strFormID,out dtResult);
            }
            finally
            {
                //m_objService.Dispose();
            }
			if(lngRes <= 0 || dtResult.Rows.Count == 0)
				return ;
			p_objItemInfo = new iCareData.clsInpatMedRec_Type_Item[dtResult.Rows.Count];
            DataRow objRow = null;
			for(int i=0;i<dtResult.Rows.Count;i++)
			{
                objRow = dtResult.Rows[i];
                iCareData.clsInpatMedRec_Type_Item objItemInfo = new iCareData.clsInpatMedRec_Type_Item();
                objItemInfo.m_strTypeID = p_strFormID;
                objItemInfo.m_strItemID = objRow["ITEMID"].ToString();
                objItemInfo.m_strItemName = objRow["ITEMNAME"].ToString();
                objItemInfo.m_strItemType = objRow["ITEMTYPE"].ToString();
                p_objItemInfo[i] = objItemInfo;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strSQL"></param>
		/// <param name="p_dtbValues"></param>
		/// <returns></returns>
		public long m_lngSearchesBySQL(string p_strSQL,ref DataTable p_dtbValues)
		{
            clsRecordSearchService m_objService =
                (clsRecordSearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRecordSearchService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngSearchesBySQL(p_strSQL,ref p_dtbValues);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 获取指定的窗体
		/// </summary>
		/// <param name="p_mniForm"></param>
		/// <returns></returns>
		public System.Windows.Forms.Form m_frmGetForm(System.Windows.Forms.MenuItem p_mniForm)
		{
			#region 右键菜单全部窗体

			switch(p_mniForm.Text) 
			{
				case "住院病历":
				case "住院病历(自由录入风格)":
					return new frmInPatientCaseHistory();			
				case "住院病历模式2":
					return new frmInPatientCaseHistoryMode1();					
				case "病程记录":
					return new frmSubDiseaseTrack();					
				case "SPECT检查申请单":
					return new frmSPECT();					
				case "高压氧治疗申请单":
					return new frmHighOxygen();					
				case "B型超声显像检查申请单":
					return new frmBUltrasonicCheckOrder();
				case "CT检查申请单":
					return new frmCTCheckOrder();
				case "X线申请单":
					return new frmXRayCheckOrder();
				case "病理活体组织送检单":
					return new frmPathologyOrgCheckOrder();
				case "MRI申请单":
					return new frmMRIApply();
				case "实验室检验申请单":
					return new frmLabAnalysisOrder();
				case "实验室检验报告单":
					return new frmLabCheckReport();
				case "术前小结":
					return new frmBeforeOperationSummary();
				case "手术记录单":
					return new frmOperationRecordDoctor();
				case "ICU转入记录":
					return new frmPICUShiftInForm();
				case "ICU转出记录":
					return new frmPICUShiftOutForm();
				case "SIRS诊断评分":
					return new frmSIRSEvaluation();
				case "改良Glasgow昏迷评分":
					return new frmImproveGlasgowComaEvaluation();
				case "急性肺损伤评分":
					return new frmLungInjuryEvaluation();
				case "新生儿危重病例评分":
					return new frmNewBabyInjuryCaseEvaluation();
				case "小儿危重病例评分":
					return new frmBabyInjuryCaseEvaluation();
				case "APACHEII 评分":
					return new frmAPACHEIIValuation();
				case "APACHEIII 评分":
					return new frmAPACHEIIIValuation();
				case "TISS-28评分":
					return new frmTISSValuation();
				case "趋势分析":
					return new frmICUTrend();
				case "住院病案首页":
					if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")//判断医院名称，暂时直接用硬代码比较
					{
						return new frmInHospitalMainRecord_GX();
					}
					else
					{
						return new frmInHospitalMainRecord();
					}
				case "病案质量评分表":
					return new frmQCRecord();
				case "入院病人评估":
                    //return new frmInPatientEvaluate();
                    return new frmEMR_InPatientEvaluate();
				case "三 测 表":
					if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")//判断医院名称，暂时直接用硬代码比较
					{
						return new frmThreeMeasureRecordGN();
					}
					else
					{
						return new frmThreeMeasureRecord();
					}
				case "一般护理记录":
					return new frmMainGeneralNurseRecord();
				case "观察项目记录表":
					return new frmWatchItemTrack();
				case "危重患者护理记录":
					if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")//判断医院名称，暂时直接用硬代码比较
					{
						return new frmIntensiveTendMain_GX();
					}
					else
					{
						return new frmIntensiveTendMain_FC();
					}
				case "ICU危重患者护理记录":
					return new frmICUIntensiveTendRecord();
				case "手术护理记录":
					return new frmOperationRecord();
				case "手术器械、敷料点数表":
					return new frmOperationEquipmentQty();
				case "出院记录":
					return new frmOutHospital();
				case "会诊记录":
					return new frmConsultation();
				case "危重症监护中心特护记录单":
					return new frmMainICUIntensiveTend();
				case "中心ICU呼吸机治疗监护记录单":
					return new frmMainICUBreath();
				case "影像报告单":
					return new frmImageReport();
				case "影像预约查询":
					return new frmImageBookingSearch();	
				case "心电图申请单":
					return new iCare.frmEKGOrder();
				case "电脑多导睡眠图检查申请单":
					return new iCare.frmNuclearOrder();
				case "核医学检查申请单":
					return new iCare.frmPSGOrder();
				case "病人入院评估表":
					return new frmEMR_InPatientEvaluate();
                //case "手术通知单":
                //    return new frmOperationRequisition();
				case "手术知情同意书":
					return new frmOpraAnaSignAgree();
				case "术前术后访视单":
					return new frmIMR_PrePostOperateSee();
                //case "麻醉记录单":
                //    return new frmAnaParamSetting();
				case "一般患者护理记录":
					return new frmGeneralNurseRecord_GX();
				case "ICU护理记录":
					return new frmICUNurseRecord_GX();
				case "心血管外科护理记录":
					return new frmCardiovascularTendMain_GX();
				case "快速微量血糖检测记录表":
					return new frmMiniBooldSugarChk_GX();
				case "外科ICU监护记录":
					return new frmSurgeryICUWardship();
				case "死亡记录":
					return new frmDeathRecord();
				case "死亡病例讨论记录":
					return new frmDeathCaseDiscuss();
				case "24小时内入出院记录":
					return new frmEMR_OutHospitalIn24Hours();
				case "入院24小时内死亡记录":
					return new frmDeathRecordIn24Hours();
				default :
					break;
			}
			#endregion 右键菜单全部窗体

			return null;
		}
		/// <summary>
		/// 获取控件的相关模板
		/// </summary>
		/// <param name="p_strFormID"></param>
		/// <param name="p_strControlID"></param>
		/// <param name="p_objTemplateInfoArr"></param>
		/// <returns></returns>
		public long m_lngGetTemplateName(string p_strFormID,string p_strControlID,out iCareData.clsTemplateInfo[] p_objTemplateInfoArr)
		{
            CustomFromService.clsMinElementColServ m_objServ =
                (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

            long lngRes = 0;
            try
            {
                lngRes =m_objServ.m_lngGetTemplateName(p_strFormID,p_strControlID,out p_objTemplateInfoArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 获取控件元素
		/// </summary>
		/// <param name="p_objTextTemp"></param>
		/// <returns></returns>
		public long m_lngGetTemplateControls(string strTemplateID,out iCareData.clsTemplateControlValue[] arrItems)
		{
            CustomFromService.clsMinElementColServ m_objServ =
                (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetTemplateControls( strTemplateID,out  arrItems);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

        /// <summary>
        /// 获取医嘱状态
        /// </summary>
        /// <param name="p_objStatus">医嘱状态</param>
        /// <returns></returns>
        public long m_lngGetOrderStatusDicMap(out clsOrderStatus_VO p_objStatus)
        {
            long lngRes = 0;

            clsQuery8iServ m_objServ =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            lngRes = m_objServ.m_lngGetOrderStatusDicMap(out  p_objStatus);
            return lngRes;
        }

        /// <summary>
        /// 查询符合条件的医嘱病人
        /// </summary>
        /// <param name="p_strSQL">查询语句</param>
        /// <param name="p_dtbPatient">病人</param>
        /// <returns></returns>
        public long m_lngGetOrdersPatient(string p_strSQL, out DataTable p_dtbPatient)
        {
            clsQuery8iServ m_objServ =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = m_objServ.m_lngGetOrdersPatient(p_strSQL, out  p_dtbPatient);
            return lngRes;
        }

		#region Class
        [Serializable]
		public class clsFormInfo
		{
			public string m_strFormID;

			public string m_strFormName;

			public string m_strSearchInfoType;

			public string m_strMainSearchInfo;

			public clsFieldInfo[] m_objFieldInfoArr;

			public override string ToString()
			{
				return m_strFormName;
			}
		}

        [Serializable]
		public class clsFieldInfo
		{
			/// <summary>
			/// 控件描述，对应ItemName
			/// </summary>
			public string m_strFieldName;
			/// <summary>
			/// 控件类型，对应ItemType
			/// </summary>
			public string m_strConditionFieldType;
			/// <summary>
			/// 控件ID，对应ItemID
			/// </summary>
			public string m_strConditionFieldName;

			public override string ToString()
			{
				int intIndex = m_strFieldName.LastIndexOf(">>");
				if( intIndex > 0)
					return m_strFieldName.Substring(intIndex +2);
				return m_strFieldName;
			}
		}

        [Serializable]
		public class clsPatientList
		{
			public string m_strInPatientNO;

			public string m_strInPatientDate;

			public string m_strOpenDate;

			public string m_strCreateUserID;

			public string m_strCreateUserName;

			public string m_strCreateDate;

			public string m_strFirstName;

			public string m_strSex;

			public string m_strAge;
		}
		#endregion
	}
}
