using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 住院病历的打印工具类,Jacky-2003-6-10
	/// </summary>
	public class clsInPatientCaseHistoryPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
		private clsBaseCaseHistoryDomain m_objRecordsDomain;
		private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{		
			m_blnIsFromDataSource=true;//表明是从数据库读取
			clsPatient m_objPatient=p_objPatient;
			m_objPrintInfo=new clsPrintInfo_InPatientCaseHistory();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;	
		
			m_objPrintInfo.m_strBirthplace= m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrBirthPlace:"";//出生地
			m_objPrintInfo.m_strNativePlace= m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrNativePlace:"";//籍贯
			m_objPrintInfo.m_strOccupation=  m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrOccupation:"";//职业
			m_objPrintInfo.m_strMarried= m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrMarried:"";//婚否
			m_objPrintInfo.m_StrLinkManFirstName= m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrLinkManFirstName:"";//联系人
			m_objPrintInfo.m_strNationality= m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrNation:"";//民族
			m_objPrintInfo.m_strHomePhone=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrLinkManPhone:"";//电话
            m_objPrintInfo.m_strHomeAddress = m_objPatient != null ? (m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress) : "";//地址
            m_objPrintInfo.m_strHISInPatientID = p_objPatient!=null? p_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = p_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;

            m_mthGetPrintMarkConfig();
		}

        /// <summary>
        /// 获取打印修改痕迹设置
        /// </summary>
        private void m_mthGetPrintMarkConfig()
        {
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3012");
            if (intConfig == 0)
            {
                m_blnIsPrintMark = false;
            }
            else
            {
                m_blnIsPrintMark = true;
            }
        }

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{	
			m_blnWantInit=false;

			if(m_objPrintInfo==null)
			{
				MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
		
			if(m_objPrintInfo.m_strInPatentID !=""/* && m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue*/)
			{
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.InPatientCaseHistory);
				long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss")  ,/*m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),*/DateTime.MinValue,out m_objPrintInfo.m_objContent,out m_objPrintInfo.m_objPicValueArr,out m_objPrintInfo.m_dtmFirstPrintDate,out m_objPrintInfo.m_blnIsFirstPrint);
//				if(lngRes <= 0)
//					return ;
			}
			//设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
			m_mthSetPrintContent((clsInPatientCaseHistoryContent )m_objPrintInfo.m_objContent,m_objPrintInfo.m_dtmFirstPrintDate);		
				
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_InPatientCaseHistory")
			{
				MDIParent.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_InPatientCaseHistory)p_objPrintContent;

			m_mthSetPrintContent((clsInPatientCaseHistoryContent )m_objPrintInfo.m_objContent,m_objPrintInfo.m_dtmFirstPrintDate);
		}

		/// <summary>
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
			if(m_blnIsFromDataSource )
			{
				if(m_objPrintInfo==null)
				{
					MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
					return null;
				}

				if(m_blnWantInit)
					m_mthInitPrintContent();				
			}			
		
			//没有记录内容时，返回空
			if(m_objPrintInfo.m_objContent == null)
				return null;
			else
				return m_objPrintInfo;
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
		#region 有关打印初始化
				
			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotItemHead = new Font("",13,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,2);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();

		
		#endregion 有关打印初始化
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose() ;
			m_fotHeaderFont.Dispose() ;
			m_fotSmallFont.Dispose() ;
			m_GridPen.Dispose() ;
			m_slbBrush.Dispose() ;
		}

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{			
			m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
		}

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="") return; 
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrint)
			{
				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss")  ,m_objPrintInfo.m_dtmFirstPrintDate);
			}
		}	


	#region 打印

		// 设置打印内容。
		private  void m_mthSetPrintContent(clsInPatientCaseHistoryContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo(),
//										  new clsPrintInPatientCasePergAndBorn(),
										  new clsPrintInPatientCaseMain(),
										  new clsPrintInPatientCaseCurrent(),
//										  new clsPrintInPatientLCQK(),
										  new clsPrintInPatientBeforetimeStatus(),
//										  new clsPrintInPatientYJS(),
										  new clsPrintInPatientOwenStatus(),
										  new clsPrintInPatientMarriageStatus(),
//										  new clsPrintInPatientXBS(),
//										  new clsPrintInPatientOldMaternitySuffer(),
//										  new clsPrintInPatientShYS(),
//										  new clsPrintInPatientCQJC(),
										  new clsPrintInPatientCaseCatameniaHistory(),
										  new clsPrintInPatientFamilyStatus(),
										  new clsPrintInPatientBodyChekcFixStatus(),
										  new clsPrintInPatientProfessionalStatus(),
										  new clsPrintInPatientLabStatus(),
										  new clsPrintInPatientSummeryStatus(),
										  new clsPrintPatientDiagnoseTitleInfo(),
										  new clsPrintPatientPrimaryDiagnoseInfo(),
				//										  new clsPrintPatientPrimaryDiagnoseNameDateInfo(),
								
			});
			m_objPrintLineContext.m_ObjPrintSign =  new com.digitalwave.Utility.Controls.clsPrintRecordSign();

			object [] objData = new Object[2];
			objData[0] = m_objChangePrintTextColor(p_objContent);
			objData[1] = m_objPrintInfo;
		
			//设置打印信息，就是Set Value进去
			m_objPrintLineContext.m_ObjPrintLineInfo = objData;
			//将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
			m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
		}

		private clsInPatientCaseHistoryContent m_objChangePrintTextColor(clsInPatientCaseHistoryContent p_objclsInPatientCase)
		{
			if(p_objclsInPatientCase==null)
				return null;
			//把白色变为黑色
			clsXML_DataGrid objclsXML_DataGrid=new clsXML_DataGrid();
			p_objclsInPatientCase.m_strBeforetimeStatusXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strBeforetimeStatusXML);
			p_objclsInPatientCase.m_strBloodPressureUnitXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strBloodPressureUnitXML);

			p_objclsInPatientCase.m_strBreathXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strBreathXML);
			p_objclsInPatientCase.m_strConfirmReasonXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strConfirmReasonXML);
			p_objclsInPatientCase.m_strConfirmReasonXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strConfirmReasonXML);

			p_objclsInPatientCase.m_strCurrentStatusXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strCurrentStatusXML);
			p_objclsInPatientCase.m_strDiaXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strDiaXML);
			p_objclsInPatientCase.m_strFamilyHistoryXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strFamilyHistoryXML);

			p_objclsInPatientCase.m_strFinallyDiagnoseXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strFinallyDiagnoseXML);
			p_objclsInPatientCase.m_strLabCheckXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strLabCheckXML);
			p_objclsInPatientCase.m_strMainDescriptionXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMainDescriptionXML);

			p_objclsInPatientCase.m_strMarriageHistoryXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMarriageHistoryXML);
			p_objclsInPatientCase.m_strMedicalXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMedicalXML);
			p_objclsInPatientCase.m_strOwnHistoryXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strOwnHistoryXML);

			p_objclsInPatientCase.m_strPrimaryDiagnoseXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strPrimaryDiagnoseXML);
			p_objclsInPatientCase.m_strProfessionalCheckXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strProfessionalCheckXML);
			p_objclsInPatientCase.m_strPulseXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strPulseXML);

			p_objclsInPatientCase.m_strSummaryXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strSummaryXML);
			p_objclsInPatientCase.m_strSysXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strSysXML);
			p_objclsInPatientCase.m_strTemperatureXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strTemperatureXML);
		
			p_objclsInPatientCase.m_strCatameniaHistoryXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strCatameniaHistoryXML);
		
			return p_objclsInPatientCase;
		}


#region 有关打印的声明

		/// <summary>
		/// 打印一行的内容
		/// </summary>
		private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;	

		/// <summary>
		/// 打印边框的左边距
		/// </summary>
		private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
		private int m_intCurrentPage = 1;
		/// <summary>
		/// 标题的字体(20 bold)
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体(14 )
		/// </summary>
		private Font m_fotHeaderFont;
		/// <summary>
		/// 大项目的标题，如体格检查
		/// </summary>
		public static Font m_fotItemHead;
		/// <summary>
		/// 表内容的字体(11)
		/// </summary>
		private Font m_fotSmallFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush;
		/// <summary>
		/// 当前打印位置（Y）
		/// </summary>
		private int m_intYPos=155 ;//= (int)enmRectangleInfo.TopY+5;
	
		/// <summary>
		/// 格子的信息
		/// </summary>
		public enum enmRectangleInfo
		{

			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 150,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = clsPrintPosition.c_intLeftX,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = clsPrintPosition.c_intRightX,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 25,
			SmallRowStep=25,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 32,

			ColumnsMark1=35,

			/// <summary>
			/// CheckBox偏移右边文本的距离
			/// </summary>
			CheckShift=15,

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1025

		}

#endregion

		/// <summary>
		/// 打印元素
		/// </summary>
		private enum enmItemDefination
		{
			//基本元素
			InPatientID_Title,
			InPatientID,
			Name_Title,
			Name,
			Sex_Title,
			Sex,
			Age_Title,
			Age,
			Dept_Name_Title,
			Dept_Name,
			BedNo_Title,
			BedNo,
    
			Page_HospitalName,
			Page_Name_Title,
			Page_Title,
			Page_Num,
			Page_Of,
			Page_Count,
			
			Print_Date_Title,
			Print_Date,
			//填充表格元素
			RecordDate,
			RecordTime,
			RecordContent,
			RecordSign1,
			RecordSign2

		}
		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;

#region 定义打印各元素的坐标点
		protected class clsPrintPageSettingForRecord
		{	
			public clsPrintPageSettingForRecord(){}
	
			/// <summary>
			/// 获得坐标点
			/// </summary>
			/// <param name="p_intItemName">项目名称</param>
			/// <returns></returns>
			public PointF m_getCoordinatePoint(int p_intItemName)
			{
				float fltOffsetX=20;//X的偏移量
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{   
            
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(340f-fltOffsetX,40f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(280f-fltOffsetX,70f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(50f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(100f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(190f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(240f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(270f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(310f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(395f,110f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(445f,110f);
						break;
			
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(600f,110f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(650f,110f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(660f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(720f-fltOffsetX,110f);
						break;
									
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;

				}
				return m_fReturnPoint;
			}
		}

#endregion		

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRectangleInfoInPatientCaseInfo 
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 140,

			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 16,

			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 180+17,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 7,
			SmallRowStep=20,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 32,

			ColumnsMark1=35,

			/// <summary>
			/// CheckBox偏移右边文本的距离
			/// </summary>
			CheckShift=15,

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1024,

			PrintWidth = 670,
			PrintWidth2 = 710,

		}


		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{

		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			m_mthPrintTitleInfo(p_objPrintPageArg);
			m_mthPrintHeader(p_objPrintPageArg); 

			Font fntNormal = new Font("",10);

			while(m_objPrintLineContext.m_BlnHaveMoreLine)
			{
				//还有数据打印
				m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,p_objPrintPageArg.Graphics,fntNormal);

				if(m_intYPos > p_objPrintPageArg.PageBounds.Height-270
					&& m_objPrintLineContext.m_BlnHaveMoreLine)
				{
					//还有数据打印，但需要换页

					m_mthPrintFoot(p_objPrintPageArg);

					p_objPrintPageArg.HasMorePages = true;

					m_intYPos = 155;

					m_intCurrentPage++;

					return;
				}				
			}

			m_intYPos += 30;
			Font fntSign = new Font("",6);
			while(m_objPrintLineContext.m_BlnHaveMoreSign)
			{
				m_objPrintLineContext.m_mthPrintNextSign(30+10,m_intYPos,p_objPrintPageArg.Graphics,fntSign);

				m_intYPos += (int)enmRectangleInfo.RowStep-10;				
			}

			//全部打完			

			m_mthPrintFoot(p_objPrintPageArg);

			//			m_objPrintLineContext.m_mthReset();
			//
			//			m_intYPos = 145;
			//
			//			m_intCurrentPage = 1;
		}

		
#region PrintClasses
		private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
		{
			protected clsInPatientCaseHistoryContent  m_objContent;
			/// <summary>
			/// 文字距离左边的边距
			/// </summary>
			protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
			protected int m_intPatientInfoX = 70;
			protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
	
			public override object  m_ObjPrintLineInfo
			{
				get
				{
					return base.m_blnHaveMoreLine;
				}
				set
				{
					if(value == null)return;
					object [] objData = (object[])value;
					m_objContent = (clsInPatientCaseHistoryContent )objData[0];					
					m_objPrintInfo=(clsPrintInfo_InPatientCaseHistory )objData[1];
				}				
			}			
		}

		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		private class clsPrintPatientFixInfo : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//				p_intPosY += 30;
				p_objGrp.DrawString("住 院 病 历",clsInPatientCaseHistoryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+290,p_intPosY - 10);
		
				p_intPosY += 20;
				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
				p_intPosY += 20;
				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("病史陈述人和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
				p_intPosY += 20;
				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("病史记录者："+(m_objContent==null ? "" : /*m_objContent.m_strCreateName*/new clsEmployee(m_objContent.m_strModifyUserID).m_StrFirstName) ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);

				p_intPosY += 20;
				p_objGrp.DrawString("籍贯："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
				p_intPosY += 20;
				p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
				p_intPosY += 20;
				p_objGrp.DrawString("婚否："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("联系人："+m_objPrintInfo.m_StrLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);

				p_intPosY += 20;
				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
				p_intPosY += 20;
				if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
				{
					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy年MM月dd日 HH:mm"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
				}
				else
				{
					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				}

				//				p_objGrp.DrawString("地址："+m_objPrintInfo.m_strHomeAddress,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);

				m_objPrintContext.m_mthSetContextWithAllCorrect("地址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");

				//				if(m_objPrintContext.m_BlnHaveNextLine())
				//				{
				//					if(m_objPrintContext.m_BlnHaveNextLine())
				//					{
				//						m_objPrintContext.m_mthPrintLine(380,m_intPatientInfoX+350,p_intPosY,p_objGrp);
				//
				//						p_intPosY += 30;
				//					}
				//				}
				//				else
				//				{
				//					p_intPosY += 30;
				//				}

				//				if(m_objPrintContext.m_BlnHaveNextLine())
				//					m_blnHaveMoreLine = true;
				//				else 
				//				{
				//					m_blnHaveMoreLine = false;
				//					p_intPosY += 30;
				//				}

				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);

				p_intPosY += 30;
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}


		/// <summary>
		/// 孕次和产次(已停用)
		/// </summary>
//		private class clsPrintInPatientCasePergAndBorn : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//			private bool m_blnIsFirstPrint = true;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || MDIParent.m_EnmCaseType != frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					if(m_objContent!=null)
//					{
//						p_intPosY -= 10;
//						p_objGrp.DrawString("孕 ："+ (m_objContent==null ? "0": m_objContent.m_strPregTimes) + "  次",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//						p_objGrp.DrawString("产 ："+(m_objContent==null ? "0": m_objContent.m_strBornTimes) + "  次",p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//						p_intPosY += 20;
//						m_blnIsFirstPrint = false;	
//					}
//					m_blnHaveMoreLine = false;
//					return;
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//					m_blnHaveMoreLine = false;
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//				m_blnIsFirstPrint = true;
//				m_blnHaveMoreLine = true;
//			}
//		}

		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatientCaseMain : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strMainDescription == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("主诉：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					if(m_objContent!=null)
					{
						if(m_objContent.m_strMainDescriptionAll.Length == 0)
						{
							//							p_intPosY += 30;

							m_blnHaveMoreLine = false;

							return;
						}
					}

					/*将首次打印时间FirstPrintDate赋给m_dtmFirstPrintTime,以区分是否首次打印，
						* 如果FirstPrintDate为null,自动将系统时间赋给m_dtmFirstPrintTime
						*/
					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//					m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;

					//父类本身已经将m_dtmFirstPrintTime赋值

                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strMainDescriptionAll), (m_objContent == null ? "<root />" : m_objContent.m_strMainDescriptionXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("主诉：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strMainDescriptionAll), (m_objContent == null ? "<root />" : m_objContent.m_strMainDescriptionXML));
                    }

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+60,p_intPosY,p_objGrp);

					p_intPosY += 20;

					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(intLine == 1)
					//						p_intPosY += 30;
					//					if(intLine == 0)
					//						p_intPosY += 30;				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}
		}

		/// <summary>
		/// 现病史
		/// </summary>
		private class clsPrintInPatientCaseCurrent : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strCurrentStatus == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
				
					p_objGrp.DrawString("现病史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strCurrentStatusXAll.Length == 0)
						{
							//							p_intPosY += 30;

							m_blnHaveMoreLine = false;

							return;
						}
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strCurrentStatusXAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strCurrentStatusXML),m_dtmFirstPrintTime,m_objContent!=null);
					    m_mthAddSign2("现病史：",m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strCurrentStatusXAll), (m_objContent == null ? "<root />" : m_objContent.m_strCurrentStatusXML));
                    }
					

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 20;

					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(intLine == 1)
					//						p_intPosY += 30;
					//					if(intLine == 0)
					//						p_intPosY += 60;

					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}
		}

		/// <summary>
		/// 既往史
		/// </summary>
		private class clsPrintInPatientBeforetimeStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strBeforetimeStatus == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("既往史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strBeforetimeStatusAll.Length == 0)
						{
							//							p_intPosY += 30;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						//						p_intPosY += 30;

						m_blnHaveMoreLine = false;

						return;
					}
					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strBeforetimeStatusAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strBeforetimeStatusXML),m_dtmFirstPrintTime,m_objContent!=null);
                        m_mthAddSign2("既往史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strBeforetimeStatusAll), (m_objContent == null ? "<root />" : m_objContent.m_strBeforetimeStatusXML));
                    }

					m_blnIsFirstPrint = false;					
			
				}
			

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 20;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							p_intPosY += 30;
					//					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}

		/// <summary>
		/// 个人史
		/// </summary>
		private class clsPrintInPatientOwenStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strOwnHistory == "" || MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("个人史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strOwnHistoryAll.Length == 0)
						{
							//							p_intPosY += 60;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						//						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}
				
					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strOwnHistoryAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strOwnHistoryXML),m_dtmFirstPrintTime,m_objContent!=null);
                        m_mthAddSign2("个人史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strOwnHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strOwnHistoryXML));
                    }
					

					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 20;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							p_intPosY += 30;
					//					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 婚姻史
		/// </summary>
		private class clsPrintInPatientMarriageStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (m_objContent == null || m_objContent.m_strMarriageHistory == "" || m_objPrintInfo.m_strMarried.Trim() == "未婚")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("婚姻史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strMarriageHistoryAll.Length == 0)
						{
							//							p_intPosY += 60;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						//						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strMarriageHistoryAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strMarriageHistoryXML),m_dtmFirstPrintTime,m_objContent!=null);
                        m_mthAddSign2("婚姻史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strMarriageHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strMarriageHistoryXML));
                    }
					

					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 20;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							p_intPosY += 30;
					//					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}

		/// <summary>
		/// 妇产科月经史(已停用)
		/// </summary>
//		private class clsPrintInPatientYJS : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strYJS == "")
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("月经史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strYJS.Length == 0)
//						{
//							//							p_intPosY += 60;
//
//							m_blnHaveMoreLine = false;
//
//							return;
//						}
//					}
//					else
//					{
//						//						p_intPosY += 60;
//
//						m_blnHaveMoreLine = false;
//
//						return;
//					}
//
//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//					//					else 
//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strYJSAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strYJSXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("月经史：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					//					if(m_intTimes < 3)
//					//					{
//					//						p_intPosY += (3-m_intTimes)*30;
//					//
//					//						if(m_intTimes == 0)
//					//							p_intPosY += 30;
//					//					}
//				
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 妇科避孕情况(已停用)
		/// </summary>
//		private class clsPrintInPatientXBS : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strContraHistory == "" || MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("避孕情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strContraHistory.Length == 0)
//						{
//							//							p_intPosY += 60;
//
//							m_blnHaveMoreLine = false;
//
//							return;
//						}
//					}
//					else
//					{
//						//						p_intPosY += 60;
//
//						m_blnHaveMoreLine = false;
//
//						return;
//					}
//
//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//					//					else 
//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strContraHistoryAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strContraHistoryXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("避孕情况：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					//					if(m_intTimes < 3)
//					//					{
//					//						p_intPosY += (3-m_intTimes)*30;
//					//
//					//						if(m_intTimes == 0)
//					//							p_intPosY += 30;
//					//					}
//				
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 妇科以往妇科疾患(已停用)
		/// </summary>
//		private class clsPrintInPatientOldMaternitySuffer : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strOldMaternitySuffer == "" || MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("以往妇科疾患：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strOldMaternitySuffer.Length == 0)
//						{
//							m_blnHaveMoreLine = false;
//							return;
//						}
//					}
//					else
//					{
//						m_blnHaveMoreLine = false;
//						return;
//					}
//
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strOldMaternitySufferAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strOldMaternitySufferXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("以往妇科疾患：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 妇科生育史(已停用)
		/// </summary>
//		private class clsPrintInPatientShYS : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strShYS == "")
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("生育史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strShYS.Length == 0)
//						{
//							//							p_intPosY += 60;
//
//							m_blnHaveMoreLine = false;
//
//							return;
//						}
//					}
//					else
//					{
//						//						p_intPosY += 60;
//
//						m_blnHaveMoreLine = false;
//
//						return;
//					}
//
//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//					//					else 
//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strShYSAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strShYSXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("生育史：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					//					if(m_intTimes < 3)
//					//					{
//					//						p_intPosY += (3-m_intTimes)*30;
//					//
//					//						if(m_intTimes == 0)
//					//							p_intPosY += 30;
//					//					}
//				
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 临产情况(已停用)
		/// </summary>
//		private class clsPrintInPatientLCQK : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strLCQK == "" || MDIParent.m_EnmCaseType != frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("临产情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strLCQK.Length == 0)
//						{
//							//							p_intPosY += 60;
//
//							m_blnHaveMoreLine = false;
//
//							return;
//						}
//					}
//					else
//					{
//						//						p_intPosY += 60;
//
//						m_blnHaveMoreLine = false;
//
//						return;
//					}
//
//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//					//					else 
//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strLCQKAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strLCQKXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("临产情况：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					//					if(m_intTimes < 3)
//					//					{
//					//						p_intPosY += (3-m_intTimes)*30;
//					//
//					//						if(m_intTimes == 0)
//					//							p_intPosY += 30;
//					//					}
//				
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 产前检查(已停用)
		/// </summary>
//		private class clsPrintInPatientCQJC : clsPrintInPatientCaseInfo
//		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//
//			private int m_intTimes = 0;
//
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null || m_objContent.m_strCQJC == "" || MDIParent.m_EnmCaseType != frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}
//
//				if(m_blnIsFirstPrint)
//				{
//					p_objGrp.DrawString("产前检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//
//					p_intPosY += 20;
//
//					if(m_objContent!=null)
//					{
//						if(m_objContent.m_strCQJC.Length == 0)
//						{
//							//							p_intPosY += 60;
//
//							m_blnHaveMoreLine = false;
//
//							return;
//						}
//					}
//					else
//					{
//						//						p_intPosY += 60;
//
//						m_blnHaveMoreLine = false;
//
//						return;
//					}
//
//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//					//					else 
//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strCQJCAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strCQJCXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign2("产前检查：",m_objPrintContext.m_ObjModifyUserArr);
//
//					m_blnIsFirstPrint = false;					
//			
//				}
//			
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(650,m_intRecBaseX+50,p_intPosY,p_objGrp);
//
//					p_intPosY += 20;
//
//					m_intTimes++;
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//					m_blnHaveMoreLine = true;
//				else
//				{
//					//					if(m_intTimes < 3)
//					//					{
//					//						p_intPosY += (3-m_intTimes)*30;
//					//
//					//						if(m_intTimes == 0)
//					//							p_intPosY += 30;
//					//					}
//				
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//
//				m_blnIsFirstPrint = true;
//
//				m_blnHaveMoreLine = true;
//
//				m_intTimes = 0;
//			}
//		}

		/// <summary>
		/// 月经史
		/// </summary>
		private class clsPrintInPatientCaseCatameniaHistory : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			//			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_intSelectedMC == 0 || m_objPrintInfo.m_strSex.Trim() == "男")
				{
					m_blnHaveMoreLine = false;
					return;
				}

				p_objGrp.DrawString("月经生育史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
				p_intPosY += 30;
			
				string strLastTime = "";
				if(m_objContent.m_strCatameniaCase!="已绝经")
					strLastTime = m_objContent.m_dtmLastCatameniaTime.ToString("yyyy年M月d日")+"，";

				p_objGrp.DrawString(m_objContent.m_strFirstCatamenia+"                  "+strLastTime+m_objContent.m_strCatameniaCase+"，"+m_objContent.m_strCatameniaHistory,p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);

				p_objGrp.DrawLine(new Pen(Brushes.Black),m_intRecBaseX+90,p_intPosY+10,m_intRecBaseX+150,p_intPosY+10);

				p_objGrp.DrawString(m_objContent.m_strCatameniaLastTime,new Font("",8),Brushes.Black,m_intRecBaseX+100,p_intPosY - 5);
				p_objGrp.DrawString(m_objContent.m_strCatameniaCycle,new Font("",8),Brushes.Black,m_intRecBaseX+100,p_intPosY + 13);

				m_blnHaveMoreLine = false;

				p_intPosY += 40;

			#region old
				//				if(m_blnIsFirstPrint)
				//				{
				//					
				//					p_objGrp.DrawString("月经生育史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
				//
				//					p_intPosY += 20;
				//
				//					if(m_objContent!=null)
				//					{
				//						if(m_objContent.m_strCatameniaHistoryAll.Length == 0)
				//						{
				////							p_intPosY += 60;
				//
				//							m_blnHaveMoreLine = false;
				//
				//							return;
				//						}
				//					}
				//					else
				//					{
				////						p_intPosY += 60;
				//
				//						m_blnHaveMoreLine = false;
				//
				//						return;
				//					}
				//
				//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
				//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
				//					//					else 
				//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
				//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strCatameniaHistoryAll ) ,(m_objContent==null ? "<root />" : m_objContent.m_strCatameniaHistoryXML),m_dtmFirstPrintTime,m_objContent!=null);
				//					m_mthAddSign("月经生育史：",m_objPrintContext.m_ObjModifyUserArr);
				//
				//					m_blnIsFirstPrint = false;
				//				}
				//				
				//				int intLine = 0;
				//				if(m_objPrintContext.m_BlnHaveNextLine())
				//				{
				//					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
				//
				//					p_intPosY += 20;
				//
				//					intLine++;
				//				}	
				//		
				//				if(m_objPrintContext.m_BlnHaveNextLine())
				//					m_blnHaveMoreLine = true;
				//				else
				//				{	
				////					if(intLine == 1)
				////						p_intPosY += 30;
				//
				//					m_blnHaveMoreLine = false;
				//				}
			#endregion
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				//				m_blnIsFirstPrint = true;
			}
		}
	
		/// <summary>
		///家族史
		/// </summary>
		private class clsPrintInPatientFamilyStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strFamilyHistory == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("家族史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strFamilyHistoryAll.Length == 0)
						{
							//							p_intPosY += 60;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						//						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strFamilyHistoryAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strFamilyHistoryXML),m_dtmFirstPrintTime,m_objContent!=null);
                        m_mthAddSign2("家族史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strFamilyHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strFamilyHistoryXML));
                    }

					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 20;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							p_intPosY += 30;
					//					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 病历摘要
		/// </summary>
		private class clsPrintInPatientSummeryStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//不需要打印病历摘要
			
				m_blnHaveMoreLine = false;
				return;


//				if( m_objContent == null || m_objContent.m_strSummary == "")
//				{
//					m_blnHaveMoreLine = false;
//
//					return;
//				}

			
				//				if(m_blnIsFirstPrint)
				//				{
				//					p_objGrp.DrawString("病历摘要",clsInPatientCaseHistoryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+330,p_intPosY);
				//	
				//					p_intPosY += 30;
				//					if(m_objContent!=null)
				//					{
				//						if(m_objContent.m_strSummaryAll.Length == 0)
				//						{
				//							p_intPosY += 60;
				//
				//							m_blnHaveMoreLine = false;
				//
				//							return;
				//						}
				//					}
				//					else
				//					{
				//						p_intPosY += 60;
				//
				//						m_blnHaveMoreLine = false;
				//
				//						return;
				//					}
				//
				//					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
				//					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
				//					//					else 
				//					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
				//					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strSummaryAll ) ,(m_objContent==null ? "<root />" : m_objContent.m_strSummaryXML),m_dtmFirstPrintTime,m_objContent!=null);
				//					m_mthAddSign("病历摘要：",m_objPrintContext.m_ObjModifyUserArr);
				//
				//					m_blnIsFirstPrint = false;					
				//				
				//				}
				//				
				//				if(m_objPrintContext.m_BlnHaveNextLine())
				//				{
				//					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
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
				//					m_blnHaveMoreLine = false;
				//				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 辅助检查 
		/// </summary>
		private class clsPrintInPatientLabStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strLabCheck == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 30;
					p_objGrp.DrawString("辅助检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
				
					p_intPosY += 30;
					if(m_objContent!=null)
					{
						if(m_objContent.m_strLabCheckAll.Length == 0)
						{
							p_intPosY += 30;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						p_intPosY += 30;

						m_blnHaveMoreLine = false;

						return;
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                       m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strLabCheckAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strLabCheckXML),m_dtmFirstPrintTime,m_objContent!=null);
                       m_mthAddSign2("辅助检查：", m_objPrintContext.m_ObjModifyUserArr); 
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strLabCheckAll), (m_objContent == null ? "<root />" : m_objContent.m_strLabCheckXML));
                    }

					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);

					p_intPosY += 30;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							p_intPosY += 30;
					//					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		/// <summary>
		///体格检查内容
		/// </summary>
		private class clsPrintInPatientBodyChekcFixStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			private bool m_blnNeedNewPage = false;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//				if(m_blnNeedNewPage)
				//				{
				//					m_blnNeedNewPage = false;
				//
				//					if(p_intPosY > 145)
				//					{
				//						m_blnHaveMoreLine = true;
				//						p_intPosY = 970;
				//						return;
				//					}
				//				}

				if(m_objContent == null || m_objContent.m_strMedical == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 30;
					p_objGrp.DrawString("体 格 检 查",clsInPatientCaseHistoryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+330,p_intPosY);
			
					//					p_intPosY += 30;
					//					p_objGrp.DrawString("体温："+(m_objContent==null ? " " : m_objContent.m_strTemperature)+"度,"+
					//										"脉搏："+(m_objContent==null ? " " : m_objContent.m_strPulse)+"次/分,"+
					//										"呼吸："+(m_objContent==null ? " " : m_objContent.m_strBreath)+"次/分,"+
					//										"血压："+(m_objContent==null ? " " : m_objContent.m_strSys)+"/"+(m_objContent==null ? 
					//										" " : m_objContent.m_strDia),p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);

				
					if(m_objContent!=null)
					{
						p_intPosY += 30;
						string strAllText = "        体温："+(m_objContent==null ? " " : m_objContent.m_strTemperature)+"℃、"+
							"脉搏："+(m_objContent==null ? " " : m_objContent.m_strPulse)+"次/分、"+
							"呼吸："+(m_objContent==null ? " " : m_objContent.m_strBreath)+"次/分、"+
							"血压："+(m_objContent==null ? " " : m_objContent.m_strSys)+"/"+(m_objContent==null ? 
							" " : m_objContent.m_strDia)+"mmHg。"+(m_objContent==null ? "" : m_objContent.m_strMedicalAll);
						string strNormalXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("        体温："+(m_objContent==null ? " " : m_objContent.m_strTemperature)+"℃、"+
							"脉搏："+(m_objContent==null ? " " : m_objContent.m_strPulse)+"次/分、"+
							"呼吸："+(m_objContent==null ? " " : m_objContent.m_strBreath)+"次/分、"+
							"血压："+(m_objContent==null ? " " : m_objContent.m_strSys)+"/"+(m_objContent==null ? 
							" " : m_objContent.m_strDia)+"mmHg。",m_objContent.m_strCreateUserID,m_objContent.m_strCreateName,Color.Black);
						string strXml = ctlRichTextBox.s_strCombineXml(new string[]{strNormalXml,(m_objContent==null ? "<root />" : m_objContent.m_strMedicalXML)});
						//						if(m_objContent.m_strMedicalAll.Length == 0)
						//						{
						//							p_intPosY += 60;
						//
						//							m_blnHaveMoreLine = false;
						//
						//							return;
						//						}
                        if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText  ,strXml,m_dtmFirstPrintTime,m_objContent!=null);
                            m_mthAddSign2("体格检查：", m_objPrintContext.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext.m_mthSetContextWithAllCorrect(strAllText, strXml);
                        }

						m_blnIsFirstPrint = false;	
					}
					else
					{
						p_intPosY += 50;

						m_blnHaveMoreLine = false;

						return;
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
				
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);

					p_intPosY += 25;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					if(m_intTimes < 3)
					{
						p_intPosY += (3-m_intTimes)*25;

						if(m_intTimes == 0)
							p_intPosY += 25;
					}
				
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnNeedNewPage = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
	
		/// <summary>
		///专科检查 
		/// </summary>
		private class clsPrintInPatientProfessionalStatus : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			private int m_intCurrentPic = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strProfessionalCheck == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					if(p_intPosY != 145) p_intPosY += 30;

					p_objGrp.DrawString("专 科 检 查",clsInPatientCaseHistoryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+330,p_intPosY);
			
					p_intPosY += 30;

					if(m_objContent!=null)
					{
						if(m_objContent.m_strProfessionalCheckAll.Length == 0 && m_objPrintInfo.m_objPicValueArr==null)
						{
							p_intPosY += 60;

							m_blnHaveMoreLine = false;

							return;
						}
					}
					else
					{
						//						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//						m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
                    if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strProfessionalCheckAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strProfessionalCheckXML),m_dtmFirstPrintTime,m_objContent!=null);
                        m_mthAddSign2("专科检查：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strProfessionalCheckAll), (m_objContent == null ? "<root />" : m_objContent.m_strProfessionalCheckXML));
                    }				

					m_blnIsFirstPrint = false;
			
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);

					p_intPosY += 30;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					if(m_intTimes < 3)
					{
						p_intPosY += (3-m_intTimes)*30;

						if(m_intTimes == 0)
							p_intPosY -= 90;
					}
					m_blnHaveMoreLine = false;
				}

				if(m_blnHaveMoreLine==false)
				{
				#region 打印画图
					if(m_objPrintInfo.m_objPicValueArr!=null && m_objPrintInfo.m_objPicValueArr.Length>0)
					{
						int intPicHeight = m_objPrintInfo.m_objPicValueArr[0].intHeight;
						int intPicWidth = m_objPrintInfo.m_objPicValueArr[0].intWidth;

						if(p_intPosY+intPicHeight>844)
						{
							p_intPosY += intPicHeight;
							m_blnHaveMoreLine = true;
							return;
						}
						else
						{
							p_intPosY += 30;
							int intLeft = m_intRecBaseX+10;
							for(int i=m_intCurrentPic;i<m_objPrintInfo.m_objPicValueArr.Length;i++)
							{					
								System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objPicValueArr[i].m_bytImage);
								Image imgPrint = new Bitmap(objStream);

								p_objGrp.DrawImage(imgPrint,intLeft,p_intPosY);
								intLeft += m_objPrintInfo.m_objPicValueArr[i].intWidth+10;
						
								//还有图片要打
								if(i+1<m_objPrintInfo.m_objPicValueArr.Length)
								{
									//图片超过一行
									if((int)enmRectangleInfo.RightX - intLeft < intPicWidth)
									{
										m_blnHaveMoreLine = true;
										p_intPosY += intPicHeight;
										intLeft = m_intRecBaseX+10;
										m_intCurrentPic = i + 1;
										return;										
									}
								}
							}
						}
					
						p_intPosY += intPicHeight;
					
					}
				#endregion 
				}				
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;

				//打印预览或者打印后都得重置
				m_intCurrentPic = 0;
			}
		}
	
		/// <summary>
		///入院诊断与最后诊断     最后诊断不需要打印
		///2004-06-30加上治疗计划
		/// </summary>
		private class clsPrintPatientPrimaryDiagnoseInfo : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
//			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));
//			private clsPrintRichTextContext m_objPrintContext3 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;
		
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_objContent == null || m_objContent.m_strPrimaryDiagnoseAll == ""/* && m_objContent.m_strCarePlan == "")*/)
				{
					p_intPosY += 30;
					m_mthPrintDocSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnIsFirstPrint)
				{					
					//					if(m_objContent!=null)
					//					{
					//						if(m_objContent.m_strPrimaryDiagnoseAll == null || m_objContent.m_strPrimaryDiagnoseAll.Length == 0)
					//						{
					//							p_intPosY += 60;
					//
					//							m_blnHaveMoreLine = false;
					//
					//							return;
					//						}
					//					}
					//					else
					//					{
					//						p_intPosY += 60;
					//
					//						m_blnHaveMoreLine = false;
					//
					//						return;
					//					}

					//					if(m_objContent.m_dtmFirstPrintDate==DateTime.MinValue)
					//						m_dtmFirstPrintTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					//					else 
					//					m_dtmFirstPrintTime=m_objContent.m_dtmFirstPrintDate;
					if(m_objContent.m_strPrimaryDiagnoseAll != null && m_objContent.m_strPrimaryDiagnoseAll.Trim() != "")
					{
                        if (clsInPatientCaseHistoryPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext1.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strPrimaryDiagnoseAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strPrimaryDiagnoseXML),m_dtmFirstPrintTime,m_objContent!=null);
                            m_mthAddSign2("入院诊断：", m_objPrintContext1.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext1.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strPrimaryDiagnoseAll), (m_objContent == null ? "<root />" : m_objContent.m_strPrimaryDiagnoseXML));
                        }
						
					}
//					m_objPrintContext2.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strFinallyDiagnoseAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strFinallyDiagnoseXML),m_dtmFirstPrintTime,m_objContent!=null);
//					m_mthAddSign("最后诊断：",m_objPrintContext2.m_ObjModifyUserArr);m_objContent.m_strCarePlanAll == null || m_objContent.m_strCarePlanAll.Trim() == ""

//					if(m_objContent.m_strFinallyDiagnoseAll != null && m_objContent.m_strFinallyDiagnoseAll.Trim() != "")
//					{
//						m_objPrintContext2.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strFinallyDiagnoseAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strFinallyDiagnoseXML),m_dtmFirstPrintTime,m_objContent!=null);
//						m_mthAddSign("修正诊断：",m_objPrintContext2.m_ObjModifyUserArr);
//					}

//					if ((m_objContent.m_strCarePlanAll.Trim() != "") && (m_objContent.m_strCarePlanAll != null) && MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//					{
//						m_objPrintContext3.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strCarePlanAll)  ,(m_objContent==null ? "<root />" : m_objContent.m_strCarePlanXML),m_dtmFirstPrintTime,m_objContent!=null);
//						m_mthAddSign("治疗计划：",m_objPrintContext3.m_ObjModifyUserArr);
//					}
					m_blnIsFirstPrint = false;					
			
				}
			
				//				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				if(m_objPrintContext1.m_BlnHaveNextLine()/* || m_objPrintContext2.m_BlnHaveNextLine() */)
				{
					//				m_objPrintContext1.m_mthPrintLine(360,m_intRecBaseX+420,p_intPosY,p_objGrp);
					//				m_objPrintContext2.m_mthPrintLine(300,m_intRecBaseX+380,p_intPosY,p_objGrp);
//					if (m_objContent.m_strPrimaryDiagnoseAll != null && m_objContent.m_strPrimaryDiagnoseAll.Trim() != "")
//					{
//						if (m_objContent.m_strCarePlanAll.Trim() != "" && m_objContent.m_strCarePlanAll != null && MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//						{
							m_objPrintContext1.m_mthPrintLine(330,m_intRecBaseX+380,p_intPosY,p_objGrp);
//							m_objPrintContext2.m_mthPrintLine(300,m_intRecBaseX+380,p_intPosY,p_objGrp);
//							m_objPrintContext3.m_mthPrintLine(330,m_intRecBaseX+405,p_intPosY,p_objGrp);
//						}
//						else
//						{
//							m_objPrintContext1.m_mthPrintLine(310,m_intRecBaseX+40,p_intPosY,p_objGrp);
//							m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+405,p_intPosY,p_objGrp);
//						}
//					}
//					else if (MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//						m_objPrintContext3.m_mthPrintLine(330,m_intRecBaseX+405,p_intPosY,p_objGrp);
					p_intPosY += 20;

					m_intTimes++;
				}
			
				//				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				if(m_objPrintContext1.m_BlnHaveNextLine()/* || m_objPrintContext2.m_BlnHaveNextLine() */)
					m_blnHaveMoreLine = true;
				else
				{
					p_intPosY += 30;
					m_mthPrintDocSign(ref p_intPosY,p_objGrp,p_fntNormalText);

					//					if(m_intTimes < 3)
					//					{
					//						p_intPosY += (3-m_intTimes)*30;
					//
					//						if(m_intTimes == 0)
					//							
					//					}

					p_intPosY += 60;

					m_blnHaveMoreLine = false;
				}
			}
			
			private void m_mthPrintDocSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//产科相关已停用，无需考虑
//				if (m_objPrintInfo.m_strAreaName != "产科" && m_objPrintInfo.m_strAreaName != "妇科")
//				{
//					p_objGrp.DrawString("记录者签名："+(m_objContent==null ? "" : m_objContent.m_strCreateName) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
//
//				}
//				else
//				{
//					if(m_objPrintInfo.m_strAreaName == "产科" && MDIParent.m_EnmCaseType != frmInPatientCaseHistory.enmCaseType.妇科)
//					{
//						p_objGrp.DrawString("主治医师："+(m_objContent==null ? "" : m_objContent.m_strChargeDoctor) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//						p_objGrp.DrawString("住院医师："+(m_objContent==null ? "" : m_objContent.m_strCreateName) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+250,p_intPosY);
//						p_objGrp.DrawString("助产士："+(m_objContent==null ? "" : m_objContent.m_strMidWife) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
//					}
//					else
//					{
                        //p_objGrp.DrawString("主任医师："+(m_objContent==null ? "" : m_objContent.m_strDiretDoctor) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                        //p_objGrp.DrawString("主治医师："+(m_objContent==null ? "" : m_objContent.m_strChargeDoctor) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+250,p_intPosY);
						p_objGrp.DrawString("记录者签名："+(m_objContent==null ? "" : m_objContent.m_strCreateName) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);

//					}
//				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
//				m_objPrintContext2.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
	
		/// <summary>
		/// 入院诊断与最后诊断签名、时间
		/// </summary>
		private class clsPrintPatientPrimaryDiagnoseNameDateInfo : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//不需要打印入院诊断与最后诊断签名、时间
				//				string strPrimaryDoctorName = "";
				//				string strFinallyDoctorName = "";
				//				if(m_objContent!=null)
				//				{
				//					clsEmployee objEmplyee1 = new clsEmployee(m_objContent.m_strPrimaryDiagnoseDocID);
				//					clsEmployee objEmplyee2 = new clsEmployee(m_objContent.m_strFinallyDiagnoseDocID);
				//					strPrimaryDoctorName = objEmplyee1.m_StrFirstName;
				//					strFinallyDoctorName = objEmplyee2.m_StrFirstName;
				//				}
				//				p_objGrp.DrawString("入院诊断签名："+strPrimaryDoctorName ,p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
				//				p_objGrp.DrawString("最后诊断签名："+strFinallyDoctorName ,p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
				//				
				//				p_intPosY += 30;
				//				p_objGrp.DrawString("入院诊断日期："+(m_objContent==null ? "" : m_objContent.m_strPrimaryDiagnoseDate) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
				//				p_objGrp.DrawString("最后诊断日期："+(m_objContent==null ? "" : m_objContent.m_strFinallyDiagnoseDate) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}
	
	
		/// <summary>
		/// 诊断Title  //2004-06-30加上治疗计划Title
		/// </summary>
		private class clsPrintPatientDiagnoseTitleInfo : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_intPosY += 30;
				if (MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.妇科)
				{}
//				p_objGrp.DrawString("最后诊断",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
				if(m_objContent != null && m_objContent.m_strPrimaryDiagnoseAll != null && m_objContent.m_strPrimaryDiagnoseAll.Trim() != "")
				{
					if (m_objContent.m_strCarePlanAll == null || m_objContent.m_strCarePlanAll.Trim() == "" || MDIParent.m_EnmCaseType != frmInPatientCaseHistory.enmCaseType.产科)
					{
						p_objGrp.DrawString("入院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
//						p_objGrp.DrawString("修正诊断",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
					}
					else
					{
						p_objGrp.DrawString("入院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
//						p_objGrp.DrawString("修正诊断",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
						p_objGrp.DrawString("治疗计划：",p_fntNormalText,Brushes.Black,m_intRecBaseX+365,p_intPosY);
					}
				}
//				else if (m_objPrintInfo.m_strAreaName == "产科" && MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
//				{
//					try
//					{
//						if (!(m_objContent.m_strCarePlanAll == null || m_objContent.m_strCarePlanAll.Trim() == ""))
//							p_objGrp.DrawString("治疗计划：",p_fntNormalText,Brushes.Black,m_intRecBaseX+365,p_intPosY);
//					}
//					catch
//					{}
//				}
				p_intPosY += 20;
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}
	
	#endregion PrintClasses

	#region 标题文字部分
		/// <summary>
		/// 打印页脚
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			float fltOffsetX=20;//X的偏移量
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第    页",fntHeader,Brushes.Black,385-fltOffsetX,e.PageBounds.Height-175);
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,425-fltOffsetX,e.PageBounds.Height-175);			
		}
		//打印边框
		private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{			
			Font fntTitle = new Font("SimSun", 18,FontStyle.Bold );
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawRectangle(Pens.Black,m_intRecBaseX - 10,135,(int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10,e.PageBounds.Height-330);
		}
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("病     案     记     录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
		

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(m_objPrintInfo.m_strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
	
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strSex,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

            e.Graphics.DrawString("科室：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));	
		
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
		}
	#endregion

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{		
			m_mthResetWhenEndPrint();
		}

		/// <summary>
		/// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
		/// </summary>
		private void m_mthResetWhenEndPrint()
		{
			m_objPrintLineContext.m_mthReset();

			m_intYPos = 155;

			m_intCurrentPage = 1;
		}

	#endregion 打印
		//
		//		/// <summary>
		//		/// 打印信息.
		//		/// </summary>
		//		[Serializable]			
		//		private class clsPrintInfo_InPatientCaseHistory
		//		{
		//			public string m_strInPatentID;			
		//			public string m_strPatientName;
		//			public string m_strSex;
		//			public string m_strAge;
		//			public string m_strBedName;
		//			public string m_strDeptName;
		//			public string m_strAreaName;	
		//			public DateTime m_dtmInPatientDate;
		//			public DateTime m_dtmOpenDate;	
		//		
		//			public string m_strNativePlace;//籍贯
		//			public string m_strOccupation;//职业
		//			public string m_strMarried;//婚否
		//			public string m_StrLinkManFirstName;//联系人
		//			public string m_strNationality;//民族
		//			public string m_strHomePhone;//电话
		//			public string m_strHomeAddress;//地址
		//			
		//			public clsBaseCaseHistoryInfo m_objContent;
		//			public DateTime m_dtmFirstPrintDate;
		//			public bool m_blnIsFirstPrint;
		//		}

		#region 在外部测试本打印的演示实例.	
		//		using System.IO;
		//		using System.Runtime.Serialization;
		//		System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		//		private void m_mthfrmLoad()
		//		{	
		//			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
		//			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
		//			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
		//			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
		//		}
		//		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		//		{			
		//			objPrintTool.m_mthPrintPage(e);
		//		}
		//
		//		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		//		{
		//			objPrintTool.m_mthBeginPrint(e);				
		//		}
		//
		//		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		//		{
		//			objPrintTool.m_mthEndPrint(e);
		//		}
		//
		//		clsInPatientCaseHistoryPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsInPatientCaseHistoryPrintTool();
		//			objPrintTool.m_mthInitPrintTool(null);	
		//			if(m_objBaseCurrentPatient==null)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
		//			else if(this.trvTime.SelectedNode ==null || this.trvTime.SelectedNode==trvTime.Nodes[0]|| trvTime.SelectedNode.Tag==null)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
		//			else 
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse(trvTime.SelectedNode.Tag.ToString()));
														
		//			objPrintTool.m_mthInitPrintContent();	
		//					
		//			//保存到文件
		//			object objtemp=objPrintTool.m_objGetPrintInfo();
		//			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		//						
		//			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Create);
		//						
		//			objForm.Serialize(objStream,objtemp);
		//						
		//			objStream.Flush();
		//			objStream.Close();
		//								
		//			m_mthStartPrint();
		//		}
		//		private void m_mthDemoPrint_FromFile()
		//		{	
		//			objPrintTool=new clsInPatientCaseHistoryPrintTool();
		//			objPrintTool.m_mthInitPrintTool(null);	
		//		
		//			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		//			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Open);
		//			object objtemp = objForm.Deserialize(objStream);//
		//			objStream.Close();
		//				
		//			objPrintTool.m_mthSetPrintContent(objtemp);		
		//		
		//			m_mthStartPrint();
		//		}
		//		private void m_mthStartPrint()
		//		{			
		//			PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
		//			ppdPrintPreview.Document = m_pdcPrintDocument;
		//			ppdPrintPreview.ShowDialog();
		//		}
		//		bool bbb=true;
		//		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		//		{
		//			if(bbb)
		//				m_mthDemoPrint_FromDataSource();
		//			else m_mthDemoPrint_FromFile();
		//			bbb= !bbb;
		//			return 1;
		//		}
		#endregion 在外部测试本打印的演示实例.
	}	
}

