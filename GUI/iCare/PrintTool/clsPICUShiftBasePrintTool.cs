using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// ICU转入、转出记录
	/// </summary>
	public class clsPICUShiftBasePrintTool : infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsPICUShiftBaseDomain m_objPICUShiftDomain;
		private clsPrintInfo_PICUShiftInfo m_objPrintInfo;
		private iCare.clsPICUShiftBaseDomain m_ObjShiftDomain
		{
			get
			{
				return m_objPICUShiftDomain;
			}
		}
		private bool m_blnIsShiftIn=true;
		private bool m_BlnIsShiftInRecord
		{
			get
			{
				return m_blnIsShiftIn;
			}
		}        
		
		public clsPICUShiftBasePrintTool(bool p_blnIsShiftIn)
		{
			//
			// TODO: Add constructor logic here
			//
			m_blnIsShiftIn=p_blnIsShiftIn;
			if(m_blnIsShiftIn)
			{
				m_objPICUShiftDomain=new clsPICUShiftInDomain();
			}
			else
			{
				m_objPICUShiftDomain=new clsPICUShiftOutDomain();
			}

			#region 打印
//			clsPrintRecordSign objSign = new clsPrintRecordSign();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo(),
										  new clsPrintPatientInDiagnoseInfo(),
										  new clsPrintPatientInDiagnoseCourseInfo(),
										  new clsPrintPatientCheckInfo(),
										  new clsPrintPatientOtherInfo(),
										  new clsPrintPatientLabReportInfo(),
										  new clsPrintPatientSignInfo(),
//										  objSign
									  });
			#endregion
		}

        /// <summary>
        /// 当前病人
        /// </summary>
        private clsPatient m_objPatient = null;
		/// <summary>
		/// 设置打印信息
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmCreateDate)
		{
			m_blnIsFromDataSource=true;//表明是从数据库读取
			m_objPatient=p_objPatient;
			m_objPrintInfo=new clsPrintInfo_PICUShiftInfo();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo.m_strHomeAddress=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmCreateDate=p_dtmCreateDate;	

            m_objPrintInfo.m_strHISInPatientID = m_objPatient!=null? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。
		/// </summary>
		public void m_mthInitPrintContent()
		{
			if(m_objPrintInfo==null)
			{
//				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatentID=="")
				return;
			
			//m_objPICUShiftDomain=m_ObjShiftDomain;
            clsPICUShiftInfo objShiftInfo = m_objPICUShiftDomain.m_objGetPICUShiftInfo(m_objPatient, m_objPrintInfo.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
			if(objShiftInfo == null)	return ; 

			#region 提取数据库信息到自定义的结构体

			m_objPrintInfo.m_objTurnInfo=new clsPrintInfo_TurnInfo();

			//谢桂军添加了下面这一行：设置转出/转入布尔变量
			m_objPrintInfo.m_objTurnInfo.m_blnIsShiftIn=this.m_BlnIsShiftInRecord;

			m_objPrintInfo.m_objBaseInfo=new clsPrintInfo_BaseInfo();
			m_objPrintInfo.m_objPICUCheckInfo=new clsPrintInfo_PICUCheckInfo();
			m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow=new clsPrintInfo_Glasgow();
			m_objPrintInfo.m_objLabReportInfo=new clsPrintInfo_LabReportInfo();
			m_objPrintInfo.m_dtmModifyDate=objShiftInfo.m_dtmModifyDate;
			m_objPrintInfo.m_strModifyUserID=objShiftInfo.m_StrEmployeeID;
		
			if(objShiftInfo.m_objTurnInfo.m_strTurnFromDeptID!=null)
			{
				m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptID=
					objShiftInfo.m_objTurnInfo.m_strTurnFromDeptID;

			
				m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptName=
					objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName;
			}
			if(objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeID!=null)
			{
				m_objPrintInfo.m_objTurnInfo.m_strTurnFromDoctorID=
                    objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeID; ;
                clsEmployee objEMP = new clsEmployee(objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeID);
				m_objPrintInfo.m_objTurnInfo.m_strTurnFromDoctorName=
                    objEMP.m_StrLastName;
			}
			if(objShiftInfo.m_objTurnInfo.m_strTurnToDeptID!=null)
			{
				m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptID=
					objShiftInfo.m_objTurnInfo.m_strTurnToDeptID;

			
				m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptName=
					objShiftInfo.m_objTurnInfo.m_strTurnToDeptName;
			}
            if (objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID != null)
            {
                m_objPrintInfo.m_objTurnInfo.m_strTurnToDoctorID =
                    objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID;
                m_objPrintInfo.m_objTurnInfo.m_strTurnToDoctorName =
                    objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName;
            }
			
				m_objPrintInfo.m_objTurnInfo.m_dtmTurnTime=
			objShiftInfo.m_objTurnInfo.m_dtmTurnTime;

			if(objShiftInfo.m_objTurnInfo.m_strInPatientID!=null)
			{
				m_objPrintInfo.m_objTurnInfo.m_strPatientID=
					objShiftInfo.m_objTurnInfo.m_strInPatientID;
			}
			
				m_objPrintInfo.m_objBaseInfo.m_strInDiagnose=
			objShiftInfo.m_objBaseInfo.m_strInDiagnose;

			
				 m_objPrintInfo.m_objBaseInfo.m_strOperationName=
			objShiftInfo.m_objBaseInfo.m_strOperationName;

			
				 m_objPrintInfo.m_objBaseInfo.m_strAnaesthesiaType=
			objShiftInfo.m_objBaseInfo.m_strAnaesthesiaType;

			
				 m_objPrintInfo.m_objBaseInfo.m_strTurnDiagnose=
			objShiftInfo.m_objBaseInfo.m_strTurnDiagnose;

			
				 m_objPrintInfo.m_objBaseInfo.m_strInDiagnoseCourse=
			objShiftInfo.m_objBaseInfo.m_strInDiagnoseCourse;


			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltTemperature=
			objShiftInfo.m_objPICUCheckInfo.m_fltTemperature;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltHeartRate=
			objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltPulse=
			objShiftInfo.m_objPICUCheckInfo.m_fltPulse;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltSystolic=
			objShiftInfo.m_objPICUCheckInfo.m_fltSystolic;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltDiastolic=
			objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_strMind=
			objShiftInfo.m_objPICUCheckInfo.m_strMind;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight=
			objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft=
			objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_strPupilReflectionRight=
			objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft=
			objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_strOther=
			objShiftInfo.m_objPICUCheckInfo.m_strOther;



			
				 m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage=
			objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye=
			objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye;

			
				 m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport=
			objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport;
			
			
				 m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue=
			objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue;

			

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltHB=
			objShiftInfo.m_objLabReportInfo.m_fltHB;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltRBC=
			objShiftInfo.m_objLabReportInfo.m_fltRBC;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltWBC=
			objShiftInfo.m_objLabReportInfo.m_fltWBC;

			m_objPrintInfo.m_objLabReportInfo.m_fltPlt=
				objShiftInfo.m_objLabReportInfo.m_fltPlt;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltLymphocyte=
			objShiftInfo.m_objLabReportInfo.m_fltLymphocyte;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBandLeukocyte=
			objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte=
			objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltMonocyte=
			objShiftInfo.m_objLabReportInfo.m_fltMonocyte;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltAcidophil=
			objShiftInfo.m_objLabReportInfo.m_fltAcidophil;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBasophil=
			objShiftInfo.m_objLabReportInfo.m_fltBasophil;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBloodK=
			objShiftInfo.m_objLabReportInfo.m_fltBloodK;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBloodNa=
			objShiftInfo.m_objLabReportInfo.m_fltBloodNa;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBloodCl=
			objShiftInfo.m_objLabReportInfo.m_fltBloodCl;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBloodSugar=
			objShiftInfo.m_objLabReportInfo.m_fltBloodSugar;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBUN=
			objShiftInfo.m_objLabReportInfo.m_fltBUN;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltBloodCa=
			objShiftInfo.m_objLabReportInfo.m_fltBloodCa;

			
			 m_objPrintInfo.m_objLabReportInfo.m_fltPH=
			objShiftInfo.m_objLabReportInfo.m_fltPH;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltPaO2=
			objShiftInfo.m_objLabReportInfo.m_fltPaO2;

			
				 m_objPrintInfo.m_objLabReportInfo.m_fltPaCO2=
			objShiftInfo.m_objLabReportInfo.m_fltPaCO2;

			m_objPrintInfo.m_objLabReportInfo.m_fltBE=
				objShiftInfo.m_objLabReportInfo.m_fltBE;
			
				 m_objPrintInfo.m_objLabReportInfo.m_fltHCO3=
			objShiftInfo.m_objLabReportInfo.m_fltHCO3;

			
				 m_objPrintInfo.m_objLabReportInfo.m_strWoundInfo=
			objShiftInfo.m_objLabReportInfo.m_strWoundInfo;
			#endregion
			
			//各处无需先设置打印内容，因为未必打印，但既然帅哥这样设置了，还是和他统一为好
			m_mthSetPrintContent(m_objPrintInfo);
			m_blnWantInit=false;

		}

		/// <summary>
		/// 设置打印内容。当数据已经存在时使用。
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_PICUShiftInfo")
			{
//				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_PICUShiftInfo)p_objPrintContent;
			m_objPrintLineContext.m_ObjPrintLineInfo=m_objPrintInfo;
			//m_objPrintLineContext.m_ObjPrintLineInfo=m_objPrintInfo.m_objShiftInfo;

			#region 设置打印内容( 已注释掉)
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).=
//				m_objPrintInfo.m_objTurnInfo.m_blnIsShiftIn;
//			m_objPrintLineContext.m_ObjPrintLineInfo=new clsPrintInfo_PICUShiftInfo();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo=new clsPrintInfo_TurnInfo();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo=new clsPrintInfo_BaseInfo();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo=new clsPrintInfo_PICUCheckInfo();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_objGlasgow=new clsPICUShiftGlasgow();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo=new clsPrintInfo_LabReportInfo();
//			((clsPrintInfo_PICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_dtmModifyDate=m_objPrintInfo.m_dtmModifyDate;
//			//((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objModifyUser=new clsEmployee(m_objPrintInfo.m_strModifyUserID);
			
			
//			if(m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptID!=null && m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptName!=null)
//			{
//				((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_objTurnFromDept
//					=new clsDepartment(m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptID,m_objPrintInfo.m_objTurnInfo.m_strTurnFromDeptName);
//			}
//			if(m_objPrintInfo.m_objTurnInfo.m_strTurnFromDoctorID!=null)
//			{
//				((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_objTurnFromDoctor
//					=new clsEmployee(m_objPrintInfo.m_objTurnInfo.m_strTurnFromDoctorID);
//			}
//			if(m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptID!=null && m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptName!=null)
//			{
//				((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_objTurnToDept
//					=new clsDepartment(m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptID,m_objPrintInfo.m_objTurnInfo.m_strTurnToDeptName);
//			}
//			if(m_objPrintInfo.m_objTurnInfo.m_strTurnToDoctorID!=null)
//			{
//				((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_objTurnToDoctor
//					=new clsEmployee(m_objPrintInfo.m_objTurnInfo.m_strTurnToDoctorID);
//			}
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_dtmTurnTime
//				=m_objPrintInfo.m_objTurnInfo.m_dtmTurnTime;
//
//			if(m_objPrintInfo.m_objTurnInfo.m_strPatientID!=null)
//			{
//				((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objTurnInfo.m_objPatient
//					=new clsPatient(m_objPrintInfo.m_objTurnInfo.m_strPatientID);
//			}
//
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo.m_strInDiagnose
//				=m_objPrintInfo.m_objBaseInfo.m_strInDiagnose;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo.m_strOperationName
//				= m_objPrintInfo.m_objBaseInfo.m_strOperationName;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo.m_strAnaesthesiaType
//				= m_objPrintInfo.m_objBaseInfo.m_strAnaesthesiaType;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo.m_strTurnDiagnose
//				= m_objPrintInfo.m_objBaseInfo.m_strTurnDiagnose;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objBaseInfo.m_strInDiagnoseCourse
//				= m_objPrintInfo.m_objBaseInfo.m_strInDiagnoseCourse;
//
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltTemperature
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltTemperature;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltHeartRate
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltHeartRate;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltPulse
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltPulse;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltSystolic
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltSystolic;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltDiastolic
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltDiastolic;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_strMind
//				= m_objPrintInfo.m_objPICUCheckInfo.m_strMind;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltPupilDiameterRight
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_fltPupilDiameterLeft
//				= m_objPrintInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_strPupilReflectionRight
//				= m_objPrintInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_strPupilReflectionLeft
//				= m_objPrintInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_strOther
//				= m_objPrintInfo.m_objPICUCheckInfo.m_strOther;
//
//
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage
//				= m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye
//				= m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_objGlasgow.m_fltSport
//				= m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport;
//			
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objPICUCheckInfo.m_objGlasgow.m_fltValue
//				= m_objPrintInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue;
//
//			
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltHB
//				= m_objPrintInfo.m_objLabReportInfo.m_fltHB;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltRBC
//				= m_objPrintInfo.m_objLabReportInfo.m_fltRBC;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltWBC
//				= m_objPrintInfo.m_objLabReportInfo.m_fltWBC;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltLymphocyte
//				= m_objPrintInfo.m_objLabReportInfo.m_fltLymphocyte;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBandLeukocyte
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBandLeukocyte;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltDispartLeftLeukocyte
//				= m_objPrintInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltMonocyte
//				= m_objPrintInfo.m_objLabReportInfo.m_fltMonocyte;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltAcidophil
//				= m_objPrintInfo.m_objLabReportInfo.m_fltAcidophil;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBasophil
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBasophil;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBloodK
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBloodK;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBloodNa
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBloodNa;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBloodCl
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBloodCl;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBloodSugar
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBloodSugar;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBUN
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBUN;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltBloodCa
//				= m_objPrintInfo.m_objLabReportInfo.m_fltBloodCa;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltPH
//				= m_objPrintInfo.m_objLabReportInfo.m_fltPH;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltPaO2
//				= m_objPrintInfo.m_objLabReportInfo.m_fltPaO2;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltPaCO2
//				= m_objPrintInfo.m_objLabReportInfo.m_fltPaCO2;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_fltHCO3
//				= m_objPrintInfo.m_objLabReportInfo.m_fltHCO3;
//
//			((clsPICUShiftInfo)m_objPrintLineContext.m_ObjPrintLineInfo).m_objLabReportInfo.m_strWoundInfo
//				= m_objPrintInfo.m_objLabReportInfo.m_strWoundInfo;

			#endregion


			m_blnWantInit=false;
			
			
		}

		/// <summary>
		/// 获取打印内容
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{
			if(m_blnIsFromDataSource )
			{
				if(m_objPrintInfo==null)
				{
//					clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
					return null;
				}

				if(m_blnWantInit) m_mthInitPrintContent();				
			}			
			
			return m_objPrintInfo;
		}
		
		/// <summary>
		/// 初始化打印变量
		/// </summary>
		/// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
		public void m_mthInitPrintTool(object p_objArg)
		{
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		/// <param name="p_objArg">外部使用到的变量，根据不同的实现使用</param>
		public void m_mthDisposePrintTools(object p_objArg)
		{
		}

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{
		}

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
		}

		
		private iCare.clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
		{
			if(m_blnIsShiftIn)
			{
				return new clsPICUShiftInTurnInfo();
			}	
			return new clsPICUShiftOutTurnInfo();
		}




		#region Print
		private int m_intYPos = 90;

		private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;

		private void m_mthPrintPageSub(System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthPrintHeader(e);

			Font fntNormal = new Font("",9);

			while(m_objPrintLineContext.m_BlnHaveMoreLine)
			{
				//还有数据打印
				m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

				if(m_intYPos > 969+130
					&& m_objPrintLineContext.m_BlnHaveMoreLine)
				{
					//还有数据打印，但需要换页

					m_mthPrintFoot(e);

					e.HasMorePages = true;

					m_intYPos = 90;

					m_intCurrentPage++;

					return;
				}				
			}

			//全部打完

			m_mthPrintFoot(e);

			m_objPrintLineContext.m_mthReset();

			m_intYPos = 90;
		}

		private const int m_intRecBaseX = 10;

		private int m_intCurrentPage = 1;

		/// <summary>
		/// 打印页脚
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font fntHeader = new Font("SimSun", 9);

			e.Graphics.DrawString("第      页",fntHeader,Brushes.Black,355,e.PageBounds.Height-50);
			//e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,395,e.PageBounds.Height-50);			
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,385,e.PageBounds.Height-50);			
		}
		
		/// <summary>
		/// 打印页头
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{			
			Font fntTitle = new Font("SimSun", 11,FontStyle.Bold );
			Font fntHeader = new Font("SimSun", 13,FontStyle.Bold);

			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,fntTitle,Brushes.Black,325,30);
			if(m_BlnIsShiftInRecord)
				e.Graphics.DrawString("转入记录表",fntHeader,Brushes.Black,355,55);

			else 
				e.Graphics.DrawString("转出记录表",fntHeader,Brushes.Black,355,55);

			fntTitle.Dispose();
			fntHeader.Dispose();

			e.Graphics.DrawRectangle(Pens.Black,m_intRecBaseX,80,770,e.PageBounds.Height-150);
		}

		#region Print Line Class
		private abstract class clsPrintShiftInfoBase : com.digitalwave.Utility.Controls.clsPrintLineBase
		{
			protected clsPrintInfo_PICUShiftInfo m_objShiftInfo;

			protected int m_intRecBaseX = 10+15;

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return base.m_blnHaveMoreLine;
				}
				set
				{
					if(value == null)
						return;

					m_objShiftInfo = (clsPrintInfo_PICUShiftInfo)value;					
				}
			}	
		}

		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		private class clsPrintPatientFixInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",9));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_objGrp.DrawString("姓名："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_strPatientName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrFirstName,p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);
			
				p_objGrp.DrawString("性别："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_strSex),p_fntNormalText,Brushes.Black,m_intRecBaseX+130,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrSex,p_fntNormalText,Brushes.Black,m_intRecBaseX+180,p_intPosY);
			
				p_objGrp.DrawString("年龄："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intRecBaseX+230,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_IntAge.ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+280,p_intPosY);
			
				p_objGrp.DrawString("住址：",p_fntNormalText,Brushes.Black,m_intRecBaseX+330,p_intPosY);

				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_strHomeAddress),"<root />");
				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intRecBaseX+380,p_intPosY,230,15);
				bool blnTextOut = m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
					
				p_objGrp.DrawString("住院号："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_strHISInPatientID),p_fntNormalText,Brushes.Black,m_intRecBaseX+620,p_intPosY);
				if(blnTextOut) p_intPosY += 35;
				else p_intPosY += 30;

				/* 换行打印
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_strHomeAddress),"<root />");

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(400,m_intRecBaseX+380,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}
				*/
                string strInDate = "";
                if (m_objShiftInfo != null && m_objShiftInfo.m_dtmHISInDate != DateTime.MinValue)
                {
                    strInDate = m_objShiftInfo.m_dtmHISInDate.ToString("yyyy年MM月dd HH:mm:ss");
                }
                p_objGrp.DrawString("入院日期：" + strInDate, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);			

				p_objGrp.DrawString("入院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY );						
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strInDiagnose),"<root />");				
				
				rtgBlock = new Rectangle(m_intRecBaseX+370,p_intPosY,400,15);
				if(m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true))
					p_intPosY += 35;
				else p_intPosY += 30;
				
				/* 换行打印
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(400,m_intRecBaseX+380,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}
				*/

				p_objGrp.DrawString("手术名称：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strOperationName),"<root />");
				rtgBlock = new Rectangle(m_intRecBaseX+70,p_intPosY,250,15);
				bool blnTextOut1 = m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
				
				//p_objGrp.DrawString("麻醉类型：",p_fntNormalText,Brushes.Black,m_intRecBaseX+370,p_intPosY);

				p_objGrp.DrawString("麻醉类型：",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strAnaesthesiaType),"<root />");
				
				rtgBlock = new Rectangle(m_intRecBaseX+300+70,p_intPosY,250,15);
				bool blnTextOut2 = m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
				
				if(blnTextOut1 || blnTextOut2) p_intPosY += 35;
				else p_intPosY += 30;

				/* 换行打印
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(670,m_intRecBaseX+90,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}
				*/
			
				if(m_objShiftInfo==null)
				{
					p_objGrp.DrawString("原转入科室：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					p_objGrp.DrawString("转出时间：",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				}
				else if(m_objShiftInfo.m_objTurnInfo.m_blnIsShiftIn)
				{
					p_objGrp.DrawString("转出科室："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnFromDeptName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					p_objGrp.DrawString("转入时间："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_dtmTurnTime.ToString("yyyy年MM月dd日 HH:mm:ss")),p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				}
				else
				{
					p_objGrp.DrawString("原转入科室："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnToDeptName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY );
					p_objGrp.DrawString("转出时间："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_dtmTurnTime.ToString("yyyy年MM月dd日 HH:mm:ss")),p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY );
				}
				p_intPosY += 30;

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}
		#endregion

		#region 打印转入（出）诊断
		private class clsPrintPatientInDiagnoseInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

//			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
//				if(m_blnIsFirstPrint)
//				{					
				if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_blnIsShiftIn)
				{
					p_objGrp.DrawString("转入诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				}
				else
				{
					p_objGrp.DrawString("转出诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				}

				if(m_objShiftInfo ==null || m_objShiftInfo.m_objBaseInfo.m_strTurnDiagnose.Length == 0)
				{
					p_intPosY += 60;

					m_blnHaveMoreLine = false;

					return;
				}				

				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strTurnDiagnose),"<root />");
				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intRecBaseX+70,p_intPosY,670,30);
				if(m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false))
					p_intPosY += 65;
				else p_intPosY += 60;

//				m_blnIsFirstPrint = false;					
//				}
				
//				int intLine = 0;
//				while(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(670,m_intRecBaseX+90,p_intPosY,p_objGrp);
//
//					p_intPosY += 30;
//
//					intLine++;
//				}			
//	
//				if(intLine == 1)
//					p_intPosY += 30;

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

//				m_blnIsFirstPrint = true;
			}
		}
		#endregion

		#region 打印入院诊治经过
		private class clsPrintPatientInDiagnoseCourseInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

//			private bool m_blnIsFirstPrint = true;

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
//				if(m_blnIsFirstPrint)
//				{

				p_objGrp.DrawString("入院治疗经过：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				p_intPosY += 30;				
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strInDiagnoseCourse),"<root />");
				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intRecBaseX+40,p_intPosY,680,150);
				if(m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false))
					p_intPosY += 165;
				else p_intPosY += 160;

//				m_blnIsFirstPrint = false;
//				}
				
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);
//
//					p_intPosY += 30;
//
//					m_intTimes++;
//				}

//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					if(m_intTimes < 4)
//					{
//						p_intPosY += (4-m_intTimes)*30;
//
//						if(m_intTimes == 0)
//							p_intPosY += 30;
//					}
//					
					m_blnHaveMoreLine = false;
//				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

//				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

//				m_intTimes = 0;
			}
		}
		#endregion
		
		#region 打印转入（出）情况
		private class clsPrintPatientCheckInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private byte m_bytPrintIndex = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				switch(m_bytPrintIndex)
				{
					case 0:
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_blnIsShiftIn)
						{
							p_objGrp.DrawString("转入情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						}
						else
						{
							p_objGrp.DrawString("转出情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						}
						p_intPosY -= 10;
						m_blnHaveMoreLine = true;
						break;
					case 1:
						string strTemperature = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltTemperature))
							strTemperature = m_objShiftInfo.m_objPICUCheckInfo.m_fltTemperature.ToString("0.00");
						string strHeartRate = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate))
							strHeartRate = m_objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate.ToString("0");
						string strPulse = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPulse))
							strPulse = m_objShiftInfo.m_objPICUCheckInfo.m_fltPulse.ToString("0");
						string strSystolic = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltSystolic))
							strSystolic = m_objShiftInfo.m_objPICUCheckInfo.m_fltSystolic.ToString("0");
						string strDiastolic = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic))
							strDiastolic = m_objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic.ToString("0");

						p_objGrp.DrawString("         T "+ strTemperature +" ℃，R "
							+ strHeartRate+" 次/分，P "
							+ strPulse+" 次/分，Bp "
							+ strSystolic+" / "
							+strDiastolic+" mmHg，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						p_intPosY -= 10;
						m_blnHaveMoreLine = true;
						break;
					case 2:
						string strMind = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strMind.Length > 0)
							strMind = m_objShiftInfo.m_objPICUCheckInfo.m_strMind;
						string strPupilDiameterRight = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight) )
							strPupilDiameterRight = m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight.ToString("0.00");
						string strPupilDiameterLeft = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
							strPupilDiameterLeft = m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft.ToString("0.00");

						p_objGrp.DrawString("         神智 "
							+strMind+" ，瞳孔直径：右 "
							+strPupilDiameterRight+" mm，左 "
							+strPupilDiameterLeft+" mm。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						p_intPosY -= 10;
						m_blnHaveMoreLine = true;
						break;
					case 3:
						string strPupilReflectionRight = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight.Length > 0)
							strPupilReflectionRight = m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;
						string strPupilReflectionLeft = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft.Length > 0)
							strPupilReflectionLeft = m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;
						string strGlasgowValue = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue))
							strGlasgowValue = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue.ToString("0");
						string strGlasgowOpenEyes = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye))
							strGlasgowOpenEyes = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye.ToString("0");

						p_objGrp.DrawString("         瞳孔光反射：右 "
							+strPupilReflectionRight+" 左 "
							+strPupilReflectionLeft+" 。Glasgow计分 "
							+strGlasgowValue+" 分（其中：睁眼 "
							+strGlasgowOpenEyes+" 分，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						p_intPosY -= 10;
						m_blnHaveMoreLine = true;
						break;
					case 4:
						string strGlasgowLanguage = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage))
							strGlasgowLanguage = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage.ToString("0");
						string strGlasgowSport = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
							strGlasgowSport = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport.ToString("0");

						p_objGrp.DrawString("         语言 "+strGlasgowLanguage+" 分，运动 "+strGlasgowSport+" 分）。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = false;
						break;
				}

				p_intPosY += 30;
				m_bytPrintIndex++;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_bytPrintIndex = 0;
			}
		}
		#endregion

		#region 打印转入（出）情况下的空白
		private class clsPrintPatientOtherInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

//			private bool m_blnIsFirstPrint = true;

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
//				if(m_blnIsFirstPrint)
//				{
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objPICUCheckInfo.m_strOther),"<root />");

				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intRecBaseX+40,p_intPosY,720,80);
				if(m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false))
					p_intPosY += 155;
				else p_intPosY += 150;

//					m_blnIsFirstPrint = false;
//				}
				
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);
//
//					p_intPosY += 30;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					if(m_intTimes < 3)
//					{
//						p_intPosY += (3-m_intTimes)*30;
//
//						if(m_intTimes == 0)
//							p_intPosY += 30;
//					}
//					
					m_blnHaveMoreLine = false;
//				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

//				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

//				m_intTimes = 0;
			}
		}
		#endregion
		
		#region 打印最新实验室报告
		private class clsPrintPatientLabReportInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",9));

			private byte m_bytPrintIndex = 0;

			private Font m_fntSmallFont = new Font("",7);	
		
//			private int m_intWounderTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				switch(m_bytPrintIndex)
				{
					case 0:
						p_objGrp.DrawString("最新实验室报告：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						p_intPosY -= 10;
						break;
					case 1:
						string strHB = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltHB))
							strHB = m_objShiftInfo.m_objLabReportInfo.m_fltHB.ToString("0.00");
						string strRBC = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltRBC))
							strRBC = m_objShiftInfo.m_objLabReportInfo.m_fltRBC.ToString("0.00");
						string strWBC = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltWBC))
							strWBC = m_objShiftInfo.m_objLabReportInfo.m_fltWBC.ToString("0.00");
						string strPlt = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPlt))
							strPlt = m_objShiftInfo.m_objLabReportInfo.m_fltPlt.ToString("0.00");

//						string strLymphocyte = "      ";
//						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte))
//							strLymphocyte = m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte.ToString("0.00");

						float fltWidth1 = 0;
						string strTempValue = "         HB "+strHB+"g/L,RBC "
							+strRBC+"x10";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						SizeF szfBase1 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("12",m_fntSmallFont,Brushes.Black,m_intRecBaseX+szfBase1.Width-10,p_intPosY-3);
						fltWidth1 = m_intRecBaseX+szfBase1.Width;

						strTempValue = "/L,WBC "+strWBC+"x10";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth1,p_intPosY);
						szfBase1 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("9",m_fntSmallFont,Brushes.Black,fltWidth1+szfBase1.Width-10,p_intPosY-3);
						fltWidth1 = fltWidth1+szfBase1.Width;

						strTempValue = "/L,Plt "+strPlt+"x10";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth1,p_intPosY);
						szfBase1 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("9",m_fntSmallFont,Brushes.Black,fltWidth1+szfBase1.Width-10,p_intPosY-3);
						fltWidth1 = fltWidth1+szfBase1.Width;


						strTempValue = "/L,白细胞分类:淋巴细胞 ";//+strLymphocyte+"%,";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth1,p_intPosY);
						
						p_intPosY -= 10;
						m_blnHaveMoreLine = true;
						break;
					case 2:
						string strLymphocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte))
							strLymphocyte = m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte.ToString("0.00");

						string strBandLeukocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte))
							strBandLeukocyte = m_objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte.ToString("0.00");
						string strDispartLeftLeukocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte))
							strDispartLeftLeukocyte = m_objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte.ToString("0.00");
						string strMonocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltMonocyte))
							strMonocyte = m_objShiftInfo.m_objLabReportInfo.m_fltMonocyte.ToString("0.00");

						p_objGrp.DrawString("         "+strLymphocyte + "%, 带状中性白细胞 "
							+strBandLeukocyte+" %，分叶中性白细胞 "
							+strDispartLeftLeukocyte+" %，单核细胞 "
							+strMonocyte+" %，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						p_intPosY -= 10;
						break;
					case 3:
						string strAcidophil = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltAcidophil))
							strAcidophil = m_objShiftInfo.m_objLabReportInfo.m_fltAcidophil.ToString("0.00");
						string strBasophil = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBasophil))
							strBasophil = m_objShiftInfo.m_objLabReportInfo.m_fltBasophil.ToString("0.00");
						string strBloodK = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodK))
							strBloodK = m_objShiftInfo.m_objLabReportInfo.m_fltBloodK.ToString("0.00");
						string strBloodNa = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodNa))
							strBloodNa = m_objShiftInfo.m_objLabReportInfo.m_fltBloodNa.ToString("0.00");

						p_objGrp.DrawString("         嗜酸细胞 "
							+strAcidophil+" %，嗜碱细胞 "
							+strBasophil+" %。血钾 "
							+strBloodK+" mmol/L，血钠 "
							+strBloodNa+" mmol/L，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						p_intPosY -= 10;
						break;
					case 4:
						string strBloodCl = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodCl))
							strBloodCl = m_objShiftInfo.m_objLabReportInfo.m_fltBloodCl.ToString("0.00");
						string strBloodSugar = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodSugar))
							strBloodSugar = m_objShiftInfo.m_objLabReportInfo.m_fltBloodSugar.ToString("0.00");
						string strBUN = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBUN))
							strBUN = m_objShiftInfo.m_objLabReportInfo.m_fltBUN.ToString("0.00");
						string strBloodCa = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodCa))
							strBloodCa = m_objShiftInfo.m_objLabReportInfo.m_fltBloodCa.ToString("0.00");

						p_objGrp.DrawString("         血氯 "
							+strBloodCl+" mmol/L，血糖 "
							+strBloodSugar+" mmol/L，BUN "
							+strBUN+" mmol/L，血钙"
							+strBloodCa+" mmol/L。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						p_intPosY -= 10;
						break;
					case 5:
						string strPH = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPH))
							strPH = m_objShiftInfo.m_objLabReportInfo.m_fltPH.ToString("0.00");
						string strPaO2 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPaO2))
							strPaO2 = m_objShiftInfo.m_objLabReportInfo.m_fltPaO2.ToString("0.00");
						string strPaCO2 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPaCO2))
							strPaCO2 = m_objShiftInfo.m_objLabReportInfo.m_fltPaCO2.ToString("0.00");
						string strBE = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBE))
							strBE = m_objShiftInfo.m_objLabReportInfo.m_fltBE.ToString("0.00");
						string strHCO3 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltHCO3))
							strHCO3 = m_objShiftInfo.m_objLabReportInfo.m_fltHCO3.ToString("0.00");

						float fltWidth5 = 0;
						string strTempBloodValue = "         血气分析：PH "+strPH+" ,PaO ";
						p_objGrp.DrawString(strTempBloodValue,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						SizeF szfBase5 = p_objGrp.MeasureString(strTempBloodValue,p_fntNormalText);
						p_objGrp.DrawString("2",m_fntSmallFont,Brushes.Black,m_intRecBaseX+szfBase5.Width-5,p_intPosY+7);
						fltWidth5 = m_intRecBaseX+szfBase5.Width;

						strTempValue = " "+strPaO2+"mmHg,PaCO";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("2",m_fntSmallFont,Brushes.Black,fltWidth5+szfBase5.Width-5,p_intPosY+7);
						fltWidth5 = fltWidth5+szfBase5.Width;

						strTempValue = " "+strPaCO2+" mmHg,BE";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						fltWidth5 = fltWidth5+szfBase5.Width;

						strTempValue = " "+strBE+" mmHg,HCO";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("3",m_fntSmallFont,Brushes.Black,fltWidth5+szfBase5.Width-5,p_intPosY+7);
						fltWidth5 = fltWidth5+szfBase5.Width;

						p_intPosY += 20;
						strTempValue =strHCO3+" mmHg/L。";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,m_intRecBaseX+40,p_intPosY);
						m_blnHaveMoreLine = true;
						p_intPosY -= 10;
						break;
					case 6:
						p_objGrp.DrawString("伤口、引流物情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);

						p_intPosY += 30;

						m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" :  m_objShiftInfo.m_objLabReportInfo.m_strWoundInfo),"<root />");

						int intRealHeight;
						Rectangle rtgBlock = new Rectangle(m_intRecBaseX+40,p_intPosY,680,80);
						if(m_objPrintContext.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false))
							p_intPosY += 155;
						else p_intPosY += 150;
						
						m_blnHaveMoreLine = false;
						break;
//					case 7:
//						if(m_objPrintContext.m_BlnHaveNextLine())
//						{
//							m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);
//
//							m_bytPrintIndex--;
//
//							m_intWounderTimes++;
//
//							m_blnHaveMoreLine = true;
//						}
//						else
//						{
//							if(m_intWounderTimes < 3)
//							{
//								p_intPosY += (3-m_intWounderTimes-1)*30;
//							}
//
//							m_blnHaveMoreLine = false;
//						}
//						break;
				}

				p_intPosY += 30;
				m_bytPrintIndex++;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_bytPrintIndex = 0;				
			}
		}
		#endregion

		#region 打印签名
		/// <summary>
		/// 打印签名
		/// </summary>
		private class clsPrintPatientSignInfo : clsPrintShiftInfoBase
		{
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_blnIsShiftIn)
				{
					p_objGrp.DrawString("转出科医师："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnFromDoctorName),p_fntNormalText,Brushes.Black,m_intRecBaseX+200,p_intPosY);
					//					p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objTurnFromDoctor.m_StrFirstName,p_fntNormalText,Brushes.Black,m_intRecBaseX+310,p_intPosY);
			
					p_objGrp.DrawString("中心ICU医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
					if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_strTurnToDoctorName != null)
						p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnToDoctorName,p_fntNormalText,Brushes.Black,m_intRecBaseX+530,p_intPosY);
				}
				else if(m_objShiftInfo!=null && !m_objShiftInfo.m_objTurnInfo.m_blnIsShiftIn)
				{
					p_objGrp.DrawString("中心ICU医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+200,p_intPosY);
					p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnFromDoctorName,p_fntNormalText,Brushes.Black,m_intRecBaseX+330,p_intPosY);
			
					p_objGrp.DrawString("接收科医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
					if(m_objShiftInfo.m_objTurnInfo.m_strTurnToDoctorName != null)
						p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnToDoctorName,p_fntNormalText,Brushes.Black,m_intRecBaseX+510,p_intPosY);
				}

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
		}
		#endregion
		#endregion
		#endregion


		#region Remark
//		/// <summary>
//		/// 转入或转出的领域层
//		/// </summary>
//		protected virtual clsPICUShiftBaseDomain m_ObjShiftDomain
//		{
//			get
//			{
//				throw new Exception("没有实现 m_ObjShiftDomain 函数");
//			}
//		}
//
//		/// <summary>
//		/// 标记是否转入表单（true，转入；false，转出）
//		/// </summary>
//		protected virtual bool m_BlnIsShiftInRecord
//		{
//			get
//			{
//				throw new Exception("没有实现 m_BlnIsShiftInRecord 函数");
//			}
//		}
//
//		/// <summary>
//		/// 获取转入（转出）的目的信息
//		/// </summary>
//		/// <returns></returns>
//		protected virtual clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
//		{
//			throw new Exception("没有实现 m_objGetShiftTurnInfo 函数");
//		}
//


		//Value Object 类应该可以直接用它原来那个啊。
//		[Serializable]
//		private class clsPrintInfo_PICUShiftInfo
//		{		
//			public string m_strInPatentID;			
//			public string m_strPatientName;
//			public string m_strSex;
//			public string m_strAge;
//			public string m_strHomeAddress;
//			public string m_strBedName;
//			public string m_strDeptName;
//			public string m_strAreaName;	
//			public DateTime m_dtmInPatientDate;
//			public DateTime m_dtmCreateDate;
//
//			public DateTime m_dtmModifyDate;
//
//			public string m_strModifyUserID;
//
//			public clsPrintInfo_TurnInfo m_objTurnInfo;
//
//			public clsPrintInfo_BaseInfo m_objBaseInfo;
//
//			public clsPrintInfo_PICUCheckInfo m_objPICUCheckInfo;
//
//			public clsPrintInfo_LabReportInfo m_objLabReportInfo;
//
//			//public clsTransDataInfo[] m_objTransDataArr;			
//			//public DateTime[] m_dtmFirstPrintDateArr;
//			//public bool[] m_blnIsFirstPrintArr;
//			
//		}
//		[Serializable]
//		private class clsPrintInfo_TurnInfo
//		{
//			public bool m_blnIsShiftIn=true;
//		
//			public string m_strTurnFromDeptID;
//			public string m_strTurnFromDeptName;
//
//			public string m_strTurnFromDoctorID;
//			public string m_strTurnFromDoctorName;
//
//			public string m_strTurnToDeptID;
//			public string m_strTurnToDeptName;
//
//			public string m_strTurnToDoctorID;
//			public string m_strTurnToDoctorName;
//
//			public DateTime m_dtmTurnTime;
//
//			public string m_strPatientID;
//
//		}
//		[Serializable]
//		private class clsPrintInfo_BaseInfo
//		{
//			public string m_strInDiagnose;
//
//			public string m_strOperationName;
//
//			public string m_strAnaesthesiaType;
//
//			public string m_strTurnDiagnose;
//
//			public string m_strInDiagnoseCourse;
//		}
//		[Serializable]
//		private class clsPrintInfo_PICUCheckInfo
//		{
//			public float m_fltTemperature;
//
//			public float m_fltHeartRate;
//
//			public float m_fltPulse;
//
//			public float m_fltSystolic;
//
//			public float m_fltDiastolic;
//
//			public string m_strMind;
//
//			public float m_fltPupilDiameterRight;
//
//			public float m_fltPupilDiameterLeft;
//
//			public string m_strPupilReflectionRight;
//
//			public string m_strPupilReflectionLeft;
//
//			public clsPrintInfo_Glasgow m_objGlasgow;
//
//			public string m_strOther;
//		}
//		[Serializable]
//		private class clsPrintInfo_LabReportInfo
//		{
//			public float m_fltHB;
//
//			public float m_fltRBC;
//
//			public float m_fltWBC;
//
//			public float m_fltLymphocyte;
//
//			public float m_fltBandLeukocyte;
//
//			public float m_fltDispartLeftLeukocyte;
//
//			public float m_fltMonocyte;
//
//			public float m_fltAcidophil;
//
//			public float m_fltBasophil;
//
//			public float m_fltBloodK;
//
//			public float m_fltBloodNa;
//
//			public float m_fltBloodCl;
//
//			public float m_fltBloodSugar;
//
//			public float m_fltBUN;
//
//			public float m_fltBloodCa;
//
//			public float m_fltPH;
//
//			public float m_fltPaO2;
//
//			public float m_fltPaCO2;
//
//			public float m_fltHCO3;
//
//			public string m_strWoundInfo;
//		}
//		[Serializable]
//		private class clsPrintInfo_Glasgow
//		{
//			public float m_fltValue;
//
//			public float m_fltOpenEye;
//
//			public float m_fltLanguage;
//
//			public float m_fltSport;
//		}

		#endregion
	}
	#region  Remark
//
//	public class clsPICUShiftInPrintTool : clsPICUShiftBasePrintTool
//	{
//		private clsPICUShiftInDomain m_objShiftInDomain;
//		public clsPICUShiftInPrintTool()
//		{
//			m_objShiftInDomain = new clsPICUShiftInDomain();
//		}
//		protected override iCare.clsPICUShiftBaseDomain m_ObjShiftDomain
//		{
//			get
//			{
//				return m_objShiftInDomain;
//			}
//		}
//
//		protected override bool m_BlnIsShiftInRecord
//		{
//			get
//			{
//				return true;
//			}
//		}
//
//		protected override iCare.clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
//		{
//			return new clsPICUShiftInTurnInfo();
//		}
//	}
//
//	public class clsPICUShiftOutPrintTool : clsPICUShiftBasePrintTool
//	{
//		private clsPICUShiftOutDomain m_objShiftOutDomain;
//		public clsPICUShiftOutPrintTool()
//		{
//			m_objShiftOutDomain = new clsPICUShiftOutDomain();
//		}
//		protected override iCare.clsPICUShiftBaseDomain m_ObjShiftDomain
//		{
//			get
//			{
//				return m_objShiftOutDomain;
//			}
//		}
//
//		protected override bool m_BlnIsShiftInRecord
//		{
//			get
//			{
//				return false;
//			}
//		}
//
//		protected override iCare.clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
//		{
//			return new clsPICUShiftOutTurnInfo();
//		}
//	}
	#endregion

}
