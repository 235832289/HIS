using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace iCare
{
	/// <summary>
	/// Summary description for clsBUltrasonicCheckOrderPrintTool.
	/// </summary>
	public class clsBUltrasonicCheckOrderPrintTool : infPrintRecord
	{
		
		private clsBUltrasonicCheckOrder m_objPrintInfo;
		private clsPatient m_objPatient;
		private	DateTime m_dtmInPatientDate;
		private	DateTime m_dtmOpenDate;
		private bool m_blnWantInit=true;

		/// <summary>
		/// 出报表的DataSet
		/// </summary>
		private DataSet m_dtsRept;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;

		/// <summary>
		/// 设置打印信息
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{
			m_objPrintInfo=null;
			m_objPatient=p_objPatient;
			m_dtmInPatientDate=p_dtmInPatientDate;
			m_dtmOpenDate=p_dtmOpenDate;
			m_blnWantInit=true;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。
		/// </summary>
		public void m_mthInitPrintContent()
		{
			if(m_objPatient !=null && m_dtmOpenDate!=DateTime.MinValue)
				m_objPrintInfo=new clsBUltrasonicCheckOrderDomain().m_objGetBUltrasonicCheckOrder(m_objPatient.m_StrInPatientID,m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
			m_blnWantInit=false;
		}

		/// <summary>
		/// 设置打印内容。当数据已经存在时使用。
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_objPrintInfo=(clsBUltrasonicCheckOrder)p_objPrintContent;
			m_blnWantInit=false;
		}

		/// <summary>
		/// 获取打印内容
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
			if(m_blnWantInit)
				m_mthInitPrintContent();
			return m_objPrintInfo;
		}

		/// <summary>
		/// 初始化打印变量,(用CrystalReport打印)本例要求传入对象为ReportDocument类型的非空对象.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{	
			if(p_objArg.GetType().Name != "ReportDocument")			
			{
				clsPublicFunction.ShowInformationMessageBox("调用clsBUltrasonicCheckOrderPrintTool.m_mthInitPrintTool参数错误!");
				return;
			}
			m_rpdOrderRept = (ReportDocument)p_objArg;
			m_rpdOrderRept.Load(m_strGetFilePathHeader() + "Templates\\\\"  + "rptBUltrasonicCheckOrder.rpt");

			m_dtsRept = InitdtsBUltrasoniceCheckOrderDataSet();	
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
		}

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{			
			AddNewDataFordtsBUltrasoniceCheckOrderDataSet(m_dtsRept);			
		}

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
		}

		public string m_strGetFilePathHeader() 
		{
			string [] strFilePathAll =  System.Windows.Forms.Application.ExecutablePath.Split('\\') ;
			string strFilePathHeader="";
			if(strFilePathAll!=null)
				for(int i=0;i<strFilePathAll.Length-3;i++)
					strFilePathHeader+=strFilePathAll[i]+"\\\\";
			return strFilePathHeader;
		}

		/*
		* DataSet : dtsBUltrasoniceCheckOrder
		* DataTable : Record
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : InPatientDate(string)
		* 	DataColumn : CreateDate(string)
		* 	DataColumn : ModifyDate(string)
		* 	DataColumn : CreateUserID(string)
		* 	DataColumn : IfConfirm(string)
		* 	DataColumn : ConfirmReason(string)
		* 	DataColumn : FirstPrintDate(string)
		* 	DataColumn : History(string)
		* 	DataColumn : BodyCheck(string)
		* 	DataColumn : XRay(string)
		* 	DataColumn : XRayDate(string)
		* 	DataColumn : XRayNumber(string)
		* 	DataColumn : LabCheck(string)
		* 	DataColumn : OtherCheck(string)
		* 	DataColumn : ClinicalDisgonse(string)
		* 	DataColumn : CheckPlace(string)
		* 	DataColumn : PatholyDisgonseDate(string)
		* 	DataColumn : OperationDate(string)
		* 	DataColumn : OperationInformation(string)
		* 	DataColumn : CreateUserDeptID(string)
		* 	DataColumn : CreateUserName(string)
		* 	DataColumn : CreateUserDeptName(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : PatientArea(string)
		* 	DataColumn : PatientRoom(string)
		* 	DataColumn : PatientBed(string)
		* 	DataColumn : PatientAddress(string)
		*/ 
		private DataSet InitdtsBUltrasoniceCheckOrderDataSet()
		{
			DataSet dsdtsBUltrasoniceCheckOrder = new DataSet("dtsBUltrasoniceCheckOrder");

			DataTable dtRecord = new DataTable("Record");

			DataColumn dcRecordInPatientID = new DataColumn("InPatientID",typeof(string));

			dtRecord.Columns.Add(dcRecordInPatientID);

			DataColumn dcRecordInPatientDate = new DataColumn("InPatientDate",typeof(string));

			dtRecord.Columns.Add(dcRecordInPatientDate);

			DataColumn dcRecordCreateDate = new DataColumn("CreateDate",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateDate);

			DataColumn dcRecordModifyDate = new DataColumn("ModifyDate",typeof(string));

			dtRecord.Columns.Add(dcRecordModifyDate);

			DataColumn dcRecordCreateUserID = new DataColumn("CreateUserID",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserID);

			DataColumn dcRecordIfConfirm = new DataColumn("IfConfirm",typeof(string));

			dtRecord.Columns.Add(dcRecordIfConfirm);

			DataColumn dcRecordConfirmReason = new DataColumn("ConfirmReason",typeof(string));

			dtRecord.Columns.Add(dcRecordConfirmReason);

			DataColumn dcRecordFirstPrintDate = new DataColumn("FirstPrintDate",typeof(string));

			dtRecord.Columns.Add(dcRecordFirstPrintDate);

			DataColumn dcRecordHistory = new DataColumn("History",typeof(string));

			dtRecord.Columns.Add(dcRecordHistory);

			DataColumn dcRecordBodyCheck = new DataColumn("BodyCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordBodyCheck);

			DataColumn dcRecordXRay = new DataColumn("XRay",typeof(string));

			dtRecord.Columns.Add(dcRecordXRay);

			DataColumn dcRecordXRayDate = new DataColumn("XRayDate",typeof(string));

			dtRecord.Columns.Add(dcRecordXRayDate);

			DataColumn dcRecordXRayNumber = new DataColumn("XRayNumber",typeof(string));

			dtRecord.Columns.Add(dcRecordXRayNumber);

			DataColumn dcRecordLabCheck = new DataColumn("LabCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordLabCheck);

			DataColumn dcRecordOtherCheck = new DataColumn("OtherCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordOtherCheck);

			DataColumn dcRecordClinicalDisgonse = new DataColumn("ClinicalDisgonse",typeof(string));

			dtRecord.Columns.Add(dcRecordClinicalDisgonse);

			DataColumn dcRecordCheckPlace = new DataColumn("CheckPlace",typeof(string));

			dtRecord.Columns.Add(dcRecordCheckPlace);

			DataColumn dcRecordPatholyDisgonseDate = new DataColumn("PatholyDisgonseDate",typeof(string));

			dtRecord.Columns.Add(dcRecordPatholyDisgonseDate);

			DataColumn dcRecordOperationDate = new DataColumn("OperationDate",typeof(string));

			dtRecord.Columns.Add(dcRecordOperationDate);

			DataColumn dcRecordOperationInformation = new DataColumn("OperationInformation",typeof(string));

			dtRecord.Columns.Add(dcRecordOperationInformation);

			DataColumn dcRecordCreateUserDeptID = new DataColumn("CreateUserDeptID",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserDeptID);

			DataColumn dcRecordCreateUserName = new DataColumn("CreateUserName",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserName);

			DataColumn dcRecordCreateUserDeptName = new DataColumn("CreateUserDeptName",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserDeptName);

			DataColumn dcRecordPatientName = new DataColumn("PatientName",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientName);

			DataColumn dcRecordPatientSex = new DataColumn("PatientSex",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientSex);

			DataColumn dcRecordPatientAge = new DataColumn("PatientAge",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientAge);

			DataColumn dcRecordPatientArea = new DataColumn("PatientArea",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientArea);

			DataColumn dcRecordPatientRoom = new DataColumn("PatientRoom",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientRoom);

			DataColumn dcRecordPatientBed = new DataColumn("PatientBed",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientBed);

			DataColumn dcRecordPatientAddress = new DataColumn("PatientAddress",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientAddress);

			dsdtsBUltrasoniceCheckOrder.Tables.Add(dtRecord);

			return dsdtsBUltrasoniceCheckOrder;
		}

		
		private void AddNewDataFordtsBUltrasoniceCheckOrderDataSet(DataSet dsdtsBUltrasoniceCheckOrder)
		{
			DataTable dtRecord = dsdtsBUltrasoniceCheckOrder.Tables["RECORD"];
			dtRecord.Rows.Clear();

			object [] objRecordDatas = new object[30];
			if(m_objPatient !=null)
			{
				objRecordDatas[0] = m_objPatient.m_StrInPatientID;
				//			objRecordDatas[1] = ;
				if(m_objPrintInfo != null)
				{
					objRecordDatas[2] = ( m_objPrintInfo.m_strCreateDate!=null && m_objPrintInfo.m_strCreateDate != "") ? DateTime.Parse(m_objPrintInfo.m_strCreateDate).ToString("D") : "";
					objRecordDatas[3] =m_objPrintInfo.m_strCheckNumber; //txtCheckNumber.Text.Trim();
					//			objRecordDatas[4] = ;
					//			objRecordDatas[5] = ;
					//			objRecordDatas[6] = ;
					//			objRecordDatas[7] = ;
					objRecordDatas[8] = m_objPrintInfo.m_strHistory;//txtHistory.Text.Trim();
					objRecordDatas[9] = m_objPrintInfo.m_strBodyCheck;//txtBodyCheck.Text.Trim();
					objRecordDatas[10] = m_objPrintInfo.m_strXRay;//txtXRayCheck.Text.Trim();
					objRecordDatas[11] = (m_objPrintInfo.m_strXRayDate != null && m_objPrintInfo.m_strXRayDate != "") ? DateTime.Parse(m_objPrintInfo.m_strXRayDate).ToString("D") : "";//(m_strInPatientID != null && m_strInPatientID != "") ? dtpXRayDate.Value.ToString("D") : "";
					objRecordDatas[12] =	m_objPrintInfo.m_strXRayNumber;// txtXRayNumber.Text.Trim();
					objRecordDatas[13] = m_objPrintInfo.m_strLabCheck;//txtLabCheck.Text.Trim();
					objRecordDatas[14] = m_objPrintInfo.m_strOtherCheck;//txtOtherCheck.Text.Trim();
					objRecordDatas[15] = m_objPrintInfo.m_strClinicalDisgonse;//txtClinicalDisgonse.Text.Trim();
					objRecordDatas[16] = m_objPrintInfo.m_strCheckPlace;//txtCheckPlace.Text.Trim();
					objRecordDatas[17] = (m_objPrintInfo.m_strPatholyDisgonseDate != null && m_objPrintInfo.m_strPatholyDisgonseDate != "") ? DateTime.Parse(m_objPrintInfo.m_strPatholyDisgonseDate).ToString("D") : "";//(m_strInPatientID != null && m_strInPatientID != "") ? dtpDisgnoseDate.Value.ToString("D") : "";
					objRecordDatas[18] = (m_objPrintInfo.m_strOperationDate != null && m_objPrintInfo.m_strOperationDate != "") ? DateTime.Parse(m_objPrintInfo.m_strOperationDate).ToString("D") : "";//(m_strInPatientID != null && m_strInPatientID != "") ? dtpOperationDate.Value.ToString("D") : "";
					objRecordDatas[19] = m_objPrintInfo.m_strOperationInformation;//txtOperationInformation.Text.Trim();
					//			objRecordDatas[20] = ;
				
					objRecordDatas[21] = (m_objPatient.m_StrInPatientID != null && m_objPatient.m_StrInPatientID != "") ? new clsEmployee( m_objPrintInfo.m_strCreateUserID).m_StrFirstName : "";//(m_strInPatientID != null && m_strInPatientID != "") ? lblDoctor.Text.Trim() : "";
				}
				objRecordDatas[22] = (m_objPatient.m_StrInPatientID != null && m_objPatient.m_StrInPatientID != "") ? m_objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName: "";// lblDept.Text.Trim() : "";
				objRecordDatas[23] = m_objPatient.m_ObjPeopleInfo.m_StrFirstName;//m_txtPatientName.Text.Trim();
				objRecordDatas[24] = m_objPatient.m_ObjPeopleInfo.m_StrSex;//lblSex.Text.Trim();
				objRecordDatas[25] = m_objPatient.m_ObjPeopleInfo.m_StrAge;//lblAge.Text.Trim();
				objRecordDatas[26] = m_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;//m_cboArea.Text.Trim();
				objRecordDatas[27] = m_objPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomName;//lblSickRoom.Text.Trim();
				objRecordDatas[28] = m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;//m_txtBedNO.Text.Trim();
				objRecordDatas[29] =  m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress;//lblAddress.Text.Trim();
			}
			dtRecord.Rows.Add(objRecordDatas);

			m_rpdOrderRept.Database.Tables["RECORD"].SetDataSource(dtRecord);

			m_rpdOrderRept.Refresh();

		}


		#region 在外部测试本打印的演示实例.
//		private void m_mthDemoPrint()
//		{
//			m_rpdOrderRept = new ReportDocument();
//			clsBUltrasonicCheckOrderPrintTool objPrintTool=new clsBUltrasonicCheckOrderPrintTool();
//			objPrintTool.m_mthInitPrintTool(m_rpdOrderRept);	
//			if(m_objBaseCurrentPatient==null)
//			objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
//			else if(m_strCreateDate==null || m_strCreateDate=="")
//			objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
//			else 
//			objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse( m_strCreateDate));
//						
//			objPrintTool.m_mthInitPrintContent();
//			objPrintTool.m_mthBeginPrint(null);
//
//			frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//			objView.MdiParent = this.MdiParent;
//			objView.Show();
//
//		}
		#endregion 在外部测试本打印的演示实例.
	}	
}
