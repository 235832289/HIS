using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 新生儿入室记录打印工具类
	/// </summary>
	public class clsNewBabyInRoomPrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
		private clsBaseCaseHistoryDomain m_objRecordsDomain;
		private clsNewBabyInRoomRecordDomain m_objInRoomDomain;

		public clsNewBabyInRoomPrintTool()
		{
			m_objInRoomDomain = new clsNewBabyInRoomRecordDomain();
		}

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
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrLastName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID =m_objPatient!=null?  p_objPatient.m_StrHISInPatientID:"";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;		
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{	
			m_blnWantInit=false;
			clsNewBabyCircsRecord[] objRecordArr = null;

			if(m_objPrintInfo==null)
			{
				MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}	
		
			if(m_objPrintInfo.m_strInPatentID !="")
			{
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.NewBabyInRoomRecord);
				long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss")  ,DateTime.MinValue,out m_objPrintInfo.m_objContent,out m_objPrintInfo.m_objPicValueArr,out m_objPrintInfo.m_dtmFirstPrintDate,out m_objPrintInfo.m_blnIsFirstPrint);

				if(m_objPrintInfo.m_objContent != null)
				{
					lngRes = m_objInRoomDomain.m_lngGetAllModifiedCircsRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss") ,((clsNewBabyInRoomRecord )(m_objPrintInfo.m_objContent)).m_dtmBIRTHTIME.ToString("yyyy-MM-dd HH:mm:ss"),out objRecordArr);
				}
			}
			//设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
			m_mthSetPrintContent((clsNewBabyInRoomRecord )m_objPrintInfo.m_objContent,objRecordArr,m_objPrintInfo.m_dtmFirstPrintDate);		
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

			m_mthSetPrintContent((clsNewBabyInRoomRecord )m_objPrintInfo.m_objContent,null,m_objPrintInfo.m_dtmFirstPrintDate);
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

		
		#region 打印

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
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="") 
				return; 
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrint)
			{
				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss")  ,m_objPrintInfo.m_dtmFirstPrintDate);
			}
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
		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{

		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			m_mthPrintTitleInfo(p_objPrintPageArg);

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
		}

		// 设置打印内容。
		private  void m_mthSetPrintContent(clsNewBabyInRoomRecord p_objContent,clsNewBabyCircsRecord[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		new clsPrintMom_Child(),
																		new  clsPrintChildBearing(),
																		new clsPrintNormalInstance(),
																		new clsPrintSkin(),
																		new clsPrintHead(),
																		new clsPrintFontanel(),
																		new clsPrintFacialfeatures(),
																		new clsPrintBosom(),
																		new clsPrintAbdomen(),
																		new clsPrintLimb(),
																		new clsPrintGenitalia(),
																		new clsPrintOtherRecord(),
																		new clsPrintRecordTime_Sign(),
																		new clsPrintCircsRecordHeader(),
																		new clsPrintCircsRecordContent(),
																		new clsPrintOutHospitalCheck(),
																		new clsPrintCheckDoc_Sign()
																	   });
			m_objPrintLineContext.m_ObjPrintSign =  new com.digitalwave.Utility.Controls.clsPrintRecordSign();

			object [] objData = new Object[3];
			objData[0] = m_objChangePrintTextColor(p_objContent);
			objData[1] = m_objPrintInfo;
			objData[2] = p_objCircsContentArr;
		
			//设置打印信息，就是Set Value进去
			m_objPrintLineContext.m_ObjPrintLineInfo = objData;
			//将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
			m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
		}

		private clsNewBabyInRoomRecord m_objChangePrintTextColor(clsNewBabyInRoomRecord p_objclsInPatientCase)
		{
			if(p_objclsInPatientCase==null)
				return null;
			//把白色变为黑色
			clsXML_DataGrid objclsXML_DataGrid=new clsXML_DataGrid();
			p_objclsInPatientCase.m_strOTHERCHECKXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);
			p_objclsInPatientCase.m_strOTHERCHECKXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);

			p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML);
			p_objclsInPatientCase.m_strDEALWITHXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strDEALWITHXML);
					
			return p_objclsInPatientCase;
		}

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
			BabySex_Title,
			BabySex,
			BirthTime_Title,
			Birth,
    
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
						m_fReturnPoint = new PointF(130f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.BabySex_Title :
						m_fReturnPoint = new PointF(250f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.BabySex :
						m_fReturnPoint = new PointF(330f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.BirthTime_Title :
						m_fReturnPoint = new PointF(400f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Birth:
						m_fReturnPoint = new PointF(500f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(610f-fltOffsetX,75f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(680f-fltOffsetX,75f);
						break;
									
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;

				}
				return m_fReturnPoint;
			}
		}

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

			PrintWidth = 630,
			PrintWidth2 = 710,

		}

		#endregion
	
		#region PrintClasses
		private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
		{
			protected clsNewBabyInRoomRecord  m_objContent;			
			protected Pen m_GridPen = new Pen(Color.Black);
			/// <summary>
			/// 文字距离左边的边距
			/// </summary>
			protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
			protected int m_intPatientInfoX = 70;
			protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
			protected clsNewBabyCircsRecord[] m_objPrintCircsArr;
	
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
					m_objContent = (clsNewBabyInRoomRecord )objData[0];					
					m_objPrintInfo=(clsPrintInfo_InPatientCaseHistory )objData[1];
					m_objPrintCircsArr = (clsNewBabyCircsRecord[])objData[2];
				}				
			}			
		}

		/// <summary>
		/// 分娩方式
		/// </summary>
		private class clsPrintChildBearing : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_strCHILDBEARING == "")
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("分娩方式：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					string strChildBearing0 = m_objContent.m_strCHILDBEARING[0].ToString();//顺产
					string strChildBearing1 = m_objContent.m_strCHILDBEARING[1].ToString();//钳产
					string strChildBearing2 = m_objContent.m_strCHILDBEARING[2].ToString();//吸引产
					string strChildBearing3 = m_objContent.m_strCHILDBEARING[3].ToString();//剖宫
					string strChildBearing4 = m_objContent.m_strCHILDBEARING[4].ToString();//臀位产
					string strChildBearing5 = m_objContent.m_strCHILDBEARING[5].ToString();//自然
					string strChildBearing6 = m_objContent.m_strCHILDBEARING[6].ToString();//半臀牵引
					string strChildBearing7 = m_objContent.m_strCHILDBEARING[7].ToString();//臀牵引

                    string strPrint = (strChildBearing0 == "0" ? "" : "顺产") + (strChildBearing1 == "0" ? "" : "钳产") + (strChildBearing2 == "0" ? "" : "吸引产") +
                        (strChildBearing3 == "0" ? "" : "剖宫") + (strChildBearing4 == "0" ? "" : "臀位产");

                    if (strChildBearing5 != "0" || strChildBearing6 != "0" || strChildBearing7 != "0")
                    {
                        strPrint += "（" + (strChildBearing5 == "0" ? "" : " 自然 ") + (strChildBearing6 == "0" ? "" : " 半臀牵引 ") + (strChildBearing7 == "0" ? "" : " 臀牵引 ") + "）";
                    }
                    strPrint += "        孕周：" + (m_objContent.m_strPREGNANTTIME==null?"":m_objContent.m_strPREGNANTTIME);
					
					p_objGrp.DrawString(strPrint,p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 一般情况
		/// </summary>
		private class clsPrintNormalInstance : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("一般情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("反应 " + (m_objContent.m_strREACTION==null?"":m_objContent.m_strREACTION) + "；肌张力 "  + (m_objContent.m_strMUSCLESTRAIN==null?"":m_objContent.m_strMUSCLESTRAIN) + "；哭声 " +
						(m_objContent.m_strCRYVOICE==null?"":m_objContent.m_strCRYVOICE) + "；水肿 " + (m_objContent.m_strDROPSY==null?"":m_objContent.m_strDROPSY) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 皮肤
		/// </summary>
		private class clsPrintSkin : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null )
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("皮        肤：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("色泽 " + (m_objContent.m_strSKINCOLOR==null?"":m_objContent.m_strSKINCOLOR) + "；弹性 "  + (m_objContent.m_strELASTICITY==null?"":m_objContent.m_strELASTICITY) + "；胎脂黄染 " +
						(m_objContent.m_strICTERUS==null?"":m_objContent.m_strICTERUS) + "；色素病 " + (m_objContent.m_strPIGMENT==null?"":m_objContent.m_strPIGMENT) +
						"；瘀点 " + (m_objContent.m_strPETECHIA==null?"":m_objContent.m_strPETECHIA),p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 头颅
		/// </summary>
		private class clsPrintHead : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("头        颅：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("产瘤 " + (m_objContent.m_strBIRTHBURL==null?"":m_objContent.m_strBIRTHBURL) + "cm，血肿 "  + (m_objContent.m_strHAEMATOMA==null?"":m_objContent.m_strHAEMATOMA) + "cm，颅骨软化 " +
						(m_objContent.m_strSKULLSOFT==null?"":m_objContent.m_strSKULLSOFT) + "；骨缝 " + (m_objContent.m_strBONESEW==null?"":m_objContent.m_strBONESEW) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 前囟&头围
		/// </summary>
		private class clsPrintFontanel : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null )
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("前        囟：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					string strFontanel0 = m_objContent.m_strFONTANEL[0].ToString();
					string strFontanel1 = m_objContent.m_strFONTANEL[1].ToString();
					string strFontanel2 = m_objContent.m_strFONTANEL[2].ToString();
					string strFontanel3 = m_objContent.m_strFONTANEL[3].ToString();

					p_objGrp.DrawString((strFontanel0=="0"?"":"√") + "突、"  + (strFontanel1=="0"?"":"√") + "饱满、" + (strFontanel2=="0"?"":"√") + "低、" + 
						(strFontanel3=="0"?"":"√") +"平。        头围" + (m_objContent.m_strHEADROUND==null?"":m_objContent.m_strHEADROUND) + "cm." ,p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 五官
		/// </summary>
		private class clsPrintFacialfeatures : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null )
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("五        官：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString((m_objContent.m_strFACIALFEATURES==null?"":m_objContent.m_strFACIALFEATURES) + "；口腔 "  + (m_objContent.m_strMOUTH==null?"":m_objContent.m_strMOUTH),p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 胸部
		/// </summary>
		private class clsPrintBosom : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null )
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("胸        部：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("心 " + (m_objContent.m_strHEART==null?"":m_objContent.m_strHEART) + "；肺 "  + (m_objContent.m_strLUNG==null?"":m_objContent.m_strLUNG) + "；胸廓 " +
						(m_objContent.m_strCHEST==null?"":m_objContent.m_strCHEST),p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 腹部
		/// </summary>
		private class clsPrintAbdomen : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("腹        部：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("静脉怒张 " + (m_objContent.m_strVEIN==null?"":m_objContent.m_strVEIN) + "；肝 "  + (m_objContent.m_strLIVER==null?"":m_objContent.m_strLIVER) + "；脾 " +
						(m_objContent.m_strSPLEEN==null?"":m_objContent.m_strSPLEEN) + "；脐部 " + (m_objContent.m_strHILUM==null?"":m_objContent.m_strHILUM),p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 四肢
		/// </summary>
		private class clsPrintLimb : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("四        肢：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString("活动 " + (m_objContent.m_strACTIVITY==null?"":m_objContent.m_strACTIVITY) + "；关节 "  + (m_objContent.m_strARTHROSIS==null?"":m_objContent.m_strARTHROSIS) + "；畸形 " +
						(m_objContent.m_strABNORMALITY==null?"":m_objContent.m_strABNORMALITY),p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 外生殖器
		/// </summary>
		private class clsPrintGenitalia : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null )
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("外生殖器：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					
					p_objGrp.DrawString((m_objContent.m_strGENITALIA==null?"":m_objContent.m_strGENITALIA) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+90,p_intPosY);
				
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
		/// 其它
		/// </summary>
		private class clsPrintOtherRecord : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("其        它：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent==null ? "" : m_objContent.m_strOTHERRECORD)  ,(m_objContent==null ? "<root />" : m_objContent.m_strOTHERRECORDXML),m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("其它：",m_objPrintContext.m_ObjModifyUserArr);

					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+90,p_intPosY,p_objGrp);

					p_intPosY += 20;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
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
		/// 检查日期及签名
		/// </summary>
		private class clsPrintRecordTime_Sign : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("检查日期：",p_fntNormalText,Brushes.Black,m_intRecBaseX+100,p_intPosY);

					//p_objGrp.DrawString(m_objContent.m_dtmCHECKDATE.ToString("yyyy年MM月dd日") + "    签名：" + m_objContent.m_strINROOMCHECKDOCName,p_fntNormalText,Brushes.Black,m_intRecBaseX+180,p_intPosY);
                    p_objGrp.DrawString(m_objContent.m_dtmCHECKDATE.ToString("yyyy年MM月dd日") + "    签名：" , p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);

                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_objContent.m_strINROOMCHECKDOCName);
                    if (imgEmpSig != null)
                    {
                        //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 268);
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 350, p_intPosY - 5, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_objContent.m_strINROOMCHECKDOCName, p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);
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
		/// 母亲及婴儿资料
		/// </summary>
		private class clsPrintMom_Child : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY -= 50;

					p_objGrp.DrawString("母亲姓名：" + m_objPrintInfo.m_strPatientName + "      婴儿性别：" + m_objContent.m_strBABYSEX + "      出生时间：" + m_objContent.m_dtmBIRTHTIME.ToString("yyyy年MM月dd日 HH时mm分"),p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
				
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
		/// 画新生儿情况记录标题及表格标头
		/// </summary>
		private class clsPrintCircsRecordHeader : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",8));
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private Font m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
			private Font m_fotContentFont = new Font("SimSun", 10);
			private PointF m_fReturnPoint;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objPrintCircsArr == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{			
					p_intPosY += 30;
					m_fReturnPoint = new PointF(260f,p_intPosY);
					p_objGrp.DrawString("  新 生 儿 情 况 记 录",m_fotTitleFont,Brushes.Black,m_fReturnPoint);
					p_intPosY += 25;

					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY,m_intRecBaseX+744,p_intPosY);
					
					#region 画表格标头
					int intPosX = m_intRecBaseX-10;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//0 
					p_objGrp.DrawString("日  期",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+20f,p_intPosY+20,20,80));
					intPosX += 60;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//1					
					p_objGrp.DrawString("出生天数",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+3f,p_intPosY+2,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//2				
					p_objGrp.DrawString("产瘤",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//3		
					p_objGrp.DrawString("血肿",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));					
					p_objGrp.DrawString("头",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+2,19,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//4		
					p_objGrp.DrawString("前囟",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//5		
					p_objGrp.DrawString("结膜充血",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawString("眼",m_fotContentFont,Brushes.Black,new RectangleF(intPosX-9f,p_intPosY+2,20,80));
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//6		
					p_objGrp.DrawString("分泌物",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//7		
					p_objGrp.DrawString("咽充血",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawString("口",m_fotContentFont,Brushes.Black,new RectangleF(intPosX-9f,p_intPosY+2,20,80));
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//8		
					p_objGrp.DrawString("白点",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//9							
					p_objGrp.DrawString("黄疸",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					p_objGrp.DrawString("皮肤",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+2,p_intPosY+2,38,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//10		
					p_objGrp.DrawString("脓疮",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//11		
					p_objGrp.DrawString("出血",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawString("脐",m_fotContentFont,Brushes.Black,new RectangleF(intPosX-5f,p_intPosY+2,20,80));
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//12		
					p_objGrp.DrawString("发炎",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//13		
					p_objGrp.DrawString("红",m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY+17,20,80));
					intPosX += 20;
					p_objGrp.DrawString("臀",m_fotContentFont,Brushes.Black,new RectangleF(intPosX-2f,p_intPosY+2,20,80));
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY+17,intPosX,p_intPosY+80);//14		
					p_objGrp.DrawString("皮肤",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+10f,p_intPosY+17,20,80));
					intPosX += 38;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//15
					p_objGrp.DrawString("心肺",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+10f,p_intPosY+2,20,80));
					intPosX += 38;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//16
					p_objGrp.DrawString("腹部",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+10f,p_intPosY+2,20,80));
					intPosX += 38;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//17
					p_objGrp.DrawString("备注",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+100,p_intPosY+2,20,80));
					intPosX += 245;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//18
					p_objGrp.DrawString("签名",m_fotContentFont,Brushes.Black,new RectangleF(intPosX+10f,p_intPosY+2,65f,80f));
					intPosX += 75;
					p_objGrp.DrawLine(m_GridPen,intPosX,p_intPosY,intPosX,p_intPosY+80);//19

					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+70,p_intPosY+17,intPosX-396,p_intPosY+17);
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY+80,m_intRecBaseX+744,p_intPosY+80);
					#endregion

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
		/// 新生儿情况记录表格内容
		/// </summary>
		private class clsPrintCircsRecordContent : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private Font m_fotContentFont = new Font("SimSun", 9);
			private Font m_fotTimetFont = new Font("SimSun", 8);

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objPrintCircsArr == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				p_intPosY += 80;
				
				if(m_blnIsFirstPrint)
				{
					for(int i=0; i<m_objPrintCircsArr.Length; i++)
					{
						int intThisLows = 0;
						string strArrTemp="";
                        string strTemp = "";
						string[] strXMLArrTemp;
						p_intPosY += 2;
						#region 打印表格内容
						int intTempX = m_intRecBaseX-9;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("yyyy.MM.dd"),m_fotTimetFont,Brushes.Black,intTempX,p_intPosY);
						intTempX +=60;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBIRTHDAYS,m_fotContentFont,Brushes.Black,intTempX,p_intPosY);
						intTempX += 20;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strBIRTHBURL,m_objPrintCircsArr[i].m_strBIRTHBURLXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strBIRTHBURL, m_objPrintCircsArr[i].m_strBIRTHBURLXML);
                        strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBIRTHBURL,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strHAEMATOMA,m_objPrintCircsArr[i].m_strHAEMATOMAXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strHAEMATOMA, m_objPrintCircsArr[i].m_strHAEMATOMAXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strHAEMATOMA,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strFONTANEL,m_objPrintCircsArr[i].m_strFONTANELXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strFONTANEL, m_objPrintCircsArr[i].m_strFONTANELXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strFONTANEL,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strCONJUNCTIVA,m_objPrintCircsArr[i].m_strCONJUNCTIVAXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strCONJUNCTIVA, m_objPrintCircsArr[i].m_strCONJUNCTIVAXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strCONJUNCTIVA,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strSECRETION,m_objPrintCircsArr[i].m_strSECRETIONXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strSECRETION, m_objPrintCircsArr[i].m_strSECRETIONXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSECRETION,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strPHARYNX,m_objPrintCircsArr[i].m_strPHARYNXXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strPHARYNX, m_objPrintCircsArr[i].m_strPHARYNXXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strPHARYNX,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strWHITEPOINT,m_objPrintCircsArr[i].m_strWHITEPOINTXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strWHITEPOINT, m_objPrintCircsArr[i].m_strWHITEPOINTXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strWHITEPOINT,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strICTERUS,m_objPrintCircsArr[i].m_strICTERUSXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strICTERUS, m_objPrintCircsArr[i].m_strICTERUSXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strICTERUS,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strFESTER,m_objPrintCircsArr[i].m_strFESTERXML,3,out strArrTemp,out strXMLArrTemp);
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strFESTER, m_objPrintCircsArr[i].m_strFESTERXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strFESTER,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strBLEEDING,m_objPrintCircsArr[i].m_strBLEEDINGXML,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strBLEEDING, m_objPrintCircsArr[i].m_strBLEEDINGXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBLEEDING,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strAGNAIL,m_objPrintCircsArr[i].m_strAGNAILXML,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strAGNAIL, m_objPrintCircsArr[i].m_strAGNAILXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strAGNAIL,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strREDSTERN,m_objPrintCircsArr[i].m_strREDSTERN,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strREDSTERN, m_objPrintCircsArr[i].m_strREDSTERN);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strREDSTERN,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 20;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strSTERNSKIN,m_objPrintCircsArr[i].m_strSTERNSKINXML,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strSTERNSKIN, m_objPrintCircsArr[i].m_strSTERNSKINXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSTERNSKIN,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,20,100));
						intTempX += 38;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strHEARTLUNG,m_objPrintCircsArr[i].m_strHEARTLUNGXML,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strHEARTLUNG, m_objPrintCircsArr[i].m_strHEARTLUNGXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strHEARTLUNG,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,38,100));
						intTempX += 38;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strABDOMEN,m_objPrintCircsArr[i].m_strABDOMENXML,3,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strABDOMEN, m_objPrintCircsArr[i].m_strABDOMENXML);
                         strTemp=(strArrTemp.Length +1)/ 2+"";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strABDOMEN,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,38,100));
						intTempX += 38;
						strArrTemp = null;
						strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strREMARK,m_objPrintCircsArr[i].m_strREMARKXML,5,out strArrTemp,out strXMLArrTemp);
                        //if(intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        strArrTemp = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintCircsArr[i].m_strREMARK, m_objPrintCircsArr[i].m_strREMARKXML);
                        strTemp = (strArrTemp.Length +2.1)/ 3 + "";
                        if (intThisLows < int.Parse(strTemp.Substring(0, 1)))
                            intThisLows = int.Parse(strTemp.Substring(0, 1));
						p_objGrp.DrawString(m_objPrintCircsArr[i].m_strREMARK,m_fotContentFont,Brushes.Black,new RectangleF(intTempX,p_intPosY,245,100));
						intTempX += 245;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strSignUserName, "", 4, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < m_objPrintCircsArr[i].m_strSignUserName.Length / 5 + 1)
                        intThisLows = m_objPrintCircsArr[i].m_strSignUserName.Length / 5 + 1;
                        //if (intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;

                        com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                        clsEmrEmployeeBase_VO objEmpVO = null;
                        objEmployeeSign.m_lngGetEmpByNO(m_objPrintCircsArr[i].m_strCreateUserID, out objEmpVO);
                        if (objEmpVO != null)
                        {
                            Image imgEmpSig = ImageSignature.GetEmpSigImage(objEmpVO.m_strLASTNAME_VCHR);
                            if (imgEmpSig != null)
                            {
                                //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 238);
                                //p_objGrp.DrawString(objEmpVO.m_strTechnicalRank, new Font("SimSun", 12, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, p_intPosY);
                                p_objGrp.DrawImage(imgEmpSig, intTempX, p_intPosY - 2, 60, 26);
                            }
                            else
                            {
                                p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSignUserName, new Font("Simsun", 8.0f), Brushes.Black, new RectangleF(intTempX, p_intPosY, 75, 100));
                            }
                        }
                         

						#endregion 

						#region 打印该行表格框架
						int intPosX = m_intRecBaseX-10;
						int intThisLowHeight = intThisLows * 15;
						p_intPosY -= 2;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 60;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 20;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 38;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 38;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 38;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 245;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );
						intPosX += 75;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight );

						p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY+intThisLowHeight,m_intRecBaseX+744,p_intPosY+intThisLowHeight);
						
						p_intPosY += intThisLowHeight;
						#endregion
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
		#endregion

		/// <summary>
		/// 出院检查表格内容
		/// </summary>
		private class clsPrintOutHospitalCheck : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private Font m_fotContentFont = new Font("SimSun", 10);

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objPrintCircsArr == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
							
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 40;					
					int intPosX = m_intRecBaseX-10;

					int intThisLowHeight = 0;
					int intHeightSum = 0;
					int intFirstPosY = p_intPosY;
					string[] strArrTemp;
					string[] strXMLArrTemp;

					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY,m_intRecBaseX+744,p_intPosY);
//					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY,m_intRecBaseX-10,p_intPosY+150);
//					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50,p_intPosY,m_intRecBaseX+50,p_intPosY+150);
                    string m_strTitle = "";
                    string m_strYiZhu = "";
                    string m_strdTtitle = "";
                    string m_dtmOutTime = "";
                    if (m_objContent.m_strCHECKEDCHANGE == "2")
                    {
                        m_strTitle = "转  科  检  查";
                        m_strdTtitle = "转科日期：";
                        m_strYiZhu = "转科医嘱：";
                    }
                    else
                    {
                        m_strTitle = "出  院  检  查";
                        m_strdTtitle = "出院日期：";
                        m_strYiZhu = "出院医嘱：";
                    }
                    p_objGrp.DrawString(m_strTitle, m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 20f, p_intPosY + 50, 30, 80));
					intPosX += 62;
					p_intPosY += 2;
                    if (m_objContent.m_dtOUTHOSPITALDATE > DateTime.MinValue && m_objContent.m_dtOUTHOSPITALDATE != DateTime.Parse("1900-01-01 00:00:00"))
                    {
                        m_dtmOutTime = m_objContent.m_dtOUTHOSPITALDATE.ToString("yyyy-MM-dd");
                    }
                    else if (MDIParent.s_ObjCurrentPatient.m_DtmLastOutDate > DateTime.MinValue && MDIParent.s_ObjCurrentPatient.m_DtmLastOutDate != DateTime.Parse("1900-01-01 00:00:00"))
                    {
                        m_dtmOutTime = MDIParent.s_ObjCurrentPatient.m_DtmLastOutDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        m_dtmOutTime = "";
                    }


                    p_objGrp.DrawString(m_strdTtitle + m_dtmOutTime, m_fotContentFont, Brushes.Black, intPosX, p_intPosY);
					intPosX += 171;
//					p_objGrp.DrawLine(m_GridPen,intPosX-2,p_intPosY-2,intPosX-2,p_intPosY+148);
					p_objGrp.DrawString("心："+m_objContent.m_strHEART_OUTHOSPITAL,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
//					p_objGrp.DrawLine(m_GridPen,intPosX-2,p_intPosY-2,intPosX-2,p_intPosY+148);
					p_objGrp.DrawString("臀部："+m_objContent.m_strBUTTOCKS,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
//					p_objGrp.DrawLine(m_GridPen,intPosX-2,p_intPosY-2,intPosX-2,p_intPosY+148);
					p_objGrp.DrawString("乙肝疫苗："+m_objContent.m_strBLIVERBACTERIN,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,180,100));
					intPosX += 171;
//					p_objGrp.DrawLine(m_GridPen,intPosX+8,p_intPosY-2,intPosX+8,p_intPosY+148);
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50,p_intPosY+28,m_intRecBaseX+744,p_intPosY+28);
					intHeightSum += 30;

					intPosX = m_intRecBaseX + 52;
					p_intPosY += 30;
                    string m_strInhospitalNum = "";
                    DateTime dtmInHospitalDate = MDIParent.s_ObjCurrentPatient.m_DtmLastInDate;
                    DateTime dtmOutHospitalDate = MDIParent.s_ObjCurrentPatient.m_DtmLastOutDate;
                    TimeSpan tmp;
                    if (dtmOutHospitalDate > DateTime.MinValue && dtmOutHospitalDate != DateTime.Parse("1900-01-01 00:00:00"))
                    {
                        tmp = dtmOutHospitalDate - dtmInHospitalDate;
                    }
                    else
                        tmp = DateTime.Now - dtmInHospitalDate;
                    if (string.IsNullOrEmpty(m_objContent.m_strINHOSPITALDAYS))
                    {
                        m_strInhospitalNum = (tmp.Days + 1).ToString();
                    }
                    else
                    {
                        m_strInhospitalNum = m_objContent.m_strINHOSPITALDAYS;
                    }
                    p_objGrp.DrawString("住院天数：" + m_strInhospitalNum, m_fotContentFont, Brushes.Black, intPosX, p_intPosY);
					intPosX += 171;
					p_objGrp.DrawString("肺："+m_objContent.m_strLUNG_OUTHOSPITAL,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					p_objGrp.DrawString("四肢："+m_objContent.m_strLIMB,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					ctlRichTextBox.m_mthSplitXml(m_objContent.m_strOTHERCHECK,m_objContent.m_strOTHERCHECKXML,15,out strArrTemp,out strXMLArrTemp);
					intThisLowHeight = strArrTemp.Length * 17;
					if(intThisLowHeight < 28)
						intThisLowHeight = 28;
					p_objGrp.DrawString("其他："+m_objContent.m_strOTHERCHECK,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,180,100));
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50,p_intPosY+intThisLowHeight-2,m_intRecBaseX+744,p_intPosY+intThisLowHeight-2);
					intHeightSum += intThisLowHeight;

					intPosX = m_intRecBaseX + 52;
					p_intPosY += intThisLowHeight;
					p_objGrp.DrawString("体重："+m_objContent.m_strWEIGHT+"kg",m_fotContentFont,Brushes.Black,intPosX,p_intPosY);
					intPosX += 171;
					p_objGrp.DrawString("生殖器："+m_objContent.m_strGENITALIA_OUTHOSPITAL,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					p_objGrp.DrawString("一般情况："+m_objContent.m_strNORMALCIRCS,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					strArrTemp = null;
					strXMLArrTemp = null;
					ctlRichTextBox.m_mthSplitXml(m_objContent.m_strOUTHOSPITALADVICE,m_objContent.m_strOUTHOSPITALADVICEXML,15,out strArrTemp,out strXMLArrTemp);
					intThisLowHeight = strArrTemp.Length * 17;
					if(intThisLowHeight < 28)
						intThisLowHeight = 28;
                    p_objGrp.DrawString(m_strYiZhu + m_objContent.m_strOUTHOSPITALADVICE, m_fotContentFont, Brushes.Black, new RectangleF(intPosX, p_intPosY, 180, 100));
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50,p_intPosY+intThisLowHeight-2,m_intRecBaseX+744,p_intPosY+intThisLowHeight-2);
					intHeightSum += intThisLowHeight;

					intPosX = m_intRecBaseX + 52;
					p_intPosY += intThisLowHeight;
					p_objGrp.DrawString("头部："+m_objContent.m_strHEAD,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					p_objGrp.DrawString("腹部："+m_objContent.m_strABDOMEN,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					p_objGrp.DrawString("哺乳情况："+m_objContent.m_strLACTATION,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					strArrTemp = null;
					strXMLArrTemp = null;
					ctlRichTextBox.m_mthSplitXml(m_objContent.m_strDEALWITH,m_objContent.m_strDEALWITHXML,15,out strArrTemp,out strXMLArrTemp);
					intThisLowHeight = strArrTemp.Length * 17;
					if(intThisLowHeight < 28)
						intThisLowHeight = 28;
					p_objGrp.DrawString("处理："+m_objContent.m_strDEALWITH,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,180,100));
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50,p_intPosY+intThisLowHeight-2,m_intRecBaseX+744,p_intPosY+intThisLowHeight-2);
					intHeightSum += intThisLowHeight;

					intPosX = m_intRecBaseX + 52;
					p_intPosY += intThisLowHeight;
					p_objGrp.DrawString("皮肤："+m_objContent.m_strSKIN,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					p_objGrp.DrawString("脐带(脱脐日期)：",m_fotContentFont,Brushes.Black,intPosX,p_intPosY);
                    p_objGrp.DrawString(m_objContent.m_dtmUMBILICALCORDLEFTTIME, m_fotContentFont, Brushes.Black, intPosX + 40, p_intPosY + 15);
					intPosX += 171;
					p_objGrp.DrawString("卡介苗："+m_objContent.m_strBCGVACCINE,m_fotContentFont,Brushes.Black,new RectangleF(intPosX,p_intPosY,171,100));
					intPosX += 171;
					
					intPosX += 171;
					intHeightSum += 30;
					p_objGrp.DrawLine(m_GridPen, m_intRecBaseX-10, intFirstPosY, m_intRecBaseX-10, intFirstPosY+intHeightSum);
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+50, intFirstPosY, m_intRecBaseX+50, intFirstPosY+intHeightSum);
					intPosX = m_intRecBaseX + 50;
					p_objGrp.DrawLine(m_GridPen,intPosX,intFirstPosY,intPosX,intFirstPosY+intHeightSum);
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,intPosX,intFirstPosY,intPosX,intFirstPosY+intHeightSum);
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,intPosX,intFirstPosY,intPosX,intFirstPosY+intHeightSum);
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,intPosX,intFirstPosY,intPosX,intFirstPosY+intHeightSum);
					intPosX += 171;
					p_objGrp.DrawLine(m_GridPen,intPosX+10,intFirstPosY,intPosX+10,intFirstPosY+intHeightSum);
//					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,p_intPosY+28,m_intRecBaseX+744,p_intPosY+28);
					p_objGrp.DrawLine(m_GridPen,m_intRecBaseX-10,intFirstPosY+intHeightSum,m_intRecBaseX+744,intFirstPosY+intHeightSum);
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
		/// 医生签名
		/// </summary>
		private class clsPrintCheckDoc_Sign : clsPrintInPatientCaseInfo
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
                  
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 60;

					p_objGrp.DrawString("医生签名：",p_fntNormalText,Brushes.Black,m_intRecBaseX+100,p_intPosY);

                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_objContent.m_strRECORDSIGNDOCName);
                    if (imgEmpSig != null)
                    {
                        //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 268);
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 180, p_intPosY - 5, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_objContent.m_strRECORDSIGNDOCName, p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
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

		#region 标题文字部分
		/// <summary>
		/// 打印页脚
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			float fltOffsetX=20;//X的偏移量
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第      页",fntHeader,Brushes.Black,385-fltOffsetX,e.PageBounds.Height-175);
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,425-fltOffsetX,e.PageBounds.Height-175);			
		}
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("新 生 儿 入 室 记 录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
		
			e.Graphics.DrawString("住院号：",m_fotItemHead,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
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
		
		#endregion
	}
}
