using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 术前小结的打印工具类,Jacky-2003-6-6
	/// </summary>
	public class clsBeforeOperationSummaryLJPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsBeforeOperationSummaryDomain m_objRecordsDomain;
		private clsPrintInfo_BeforeOperationSummary m_objPrintInfo;
		private clsBeforeOperationSummary_All m_objclsBeforeOperationSummary_All=null;
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmCreateDate">CreateDate，如果是一次打印多次记录表单的类型（如病案记录），忽略CreateDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmCreateDate)
		{		
			m_blnIsFromDataSource=true;//表明是从数据库读取
			clsPatient m_objPatient=p_objPatient;
			m_objPrintInfo=new clsPrintInfo_BeforeOperationSummary();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName: "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmCreateDate;//这里的m_dtmOpenDate实际上就是CreateDate,结构上需要改动	
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";		
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{		
			m_blnWantInit=false;//
			if(m_objPrintInfo==null)
			{
				MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_dtmOpenDate==DateTime.MinValue)
				m_objclsBeforeOperationSummary_All=null;				
			else
			{
				m_objRecordsDomain=new clsBeforeOperationSummaryDomain();	
				long lngRes=m_objRecordsDomain.m_lngGetSummary_All(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objclsBeforeOperationSummary_All );
				if(lngRes <= 0)
					return ;   
			}
			//设置表单内容到打印中			
			m_objPrintInfo.m_objclsBeforeOperationSummary_All=m_objclsBeforeOperationSummary_All;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			 		 

			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_BeforeOperationSummary")
			{
				MDIParent.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_BeforeOperationSummary)p_objPrintContent;
			m_objclsBeforeOperationSummary_All= m_objPrintInfo. m_objclsBeforeOperationSummary_All ;		
			m_mthSetPrintValue();			
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
			
			return m_objPrintInfo;
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			#region 有关打印初始化

			m_fotHospitalNameFont = new Font("SimSun", 16,FontStyle.Bold );
			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 18);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();
			m_objCPaint=new clsPublicControlPaint();			

			#endregion
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
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_objclsBeforeOperationSummary_All==null) return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objclsBeforeOperationSummary_All.m_strFirstPrintDate != null && m_objPrintInfo.m_objclsBeforeOperationSummary_All.m_strFirstPrintDate == "")
			{				
				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),dtmFirstPrintTime.ToString("yyyy-MM-dd HH:mm:ss"));//m_objPrintInfo.m_objclsBeforeOperationSummary_All.m_strFirstPrintDate);	
			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
		}

		private  void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作
		}
		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs e)
		{
			e.HasMorePages =false;
			m_mthPrintTitleInfo(e);
            m_mthPrintHeader(e); 
			Font fntNormal = new Font("SimSun",12);
            m_intYPos += 20;
			while(m_objPrintContext.m_BlnHaveMoreLine)
			{
				m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

                if (m_intYPos >= e.PageBounds.Height - 220
					&& m_objPrintContext.m_BlnHaveMoreLine)
				{
					#region 换页处理
                    m_mthPrintFoot(e);
					e.HasMorePages = true;					
					m_intPages++;	
					m_intYPos = (int)enmRectangleInfo.TopY;
					return;
					#endregion 换页处理 
				}				
			}

			#region 最后一页处理		
			e.Graphics.DrawString("主刀医师签名：",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+6,m_intYPos+10);
			if(m_objclsBeforeOperationSummary_All!=null)
				e.Graphics.DrawString(m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperateDoctorName,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+6+(int)(7*17.5),m_intYPos+10);	
			e.Graphics.DrawString("经管医师签名：",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+360,m_intYPos+10);
			if(m_objclsBeforeOperationSummary_All!=null)
				e.Graphics.DrawString(m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strChargeDoctorName,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+360+(int)(7*17.5),m_intYPos+10);	
			#endregion 最后一页处理

			m_intYPos += (int)enmRectangleInfo.RowStep+15;
			Font fntSign = new Font("",6);
			while(m_objPrintContext.m_BlnHaveMoreSign)
			{
				m_objPrintContext.m_mthPrintNextSign((int)enmRectangleInfo.LeftX,m_intYPos,e.Graphics,fntSign);

				m_intYPos += (int)enmRectangleInfo.RowStep-10;				
			}
			//全部打完
            m_mthPrintFoot(e);
			m_objPrintContext.m_mthReset();
			m_intPages=1;			
			m_intYPos = (int)enmRectangleInfo.TopY;			
		}

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}		
		

		#region 打印
		#region 有关打印的声明

		private clsPublicControlPaint m_objCPaint;
		private clsPrintContext m_objPrintContext;
		/// <summary>
		/// 医院名称的字体
		/// </summary>
		private Font m_fotHospitalNameFont;
		/// <summary>
		/// 标题的字体
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体
		/// </summary>
		private Font m_fotHeaderFont;
		/// <summary>
		/// 表内容的字体
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
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;
		/// <summary>
		/// 打印的病人基本信息类
		/// </summary>
		/// 
		private int m_intYPos = (int)enmRectangleInfo.TopY+5;
		private int m_intPages=1;		

		/// <summary>
		/// 格子的信息
		/// </summary>
		public enum enmRectangleInfo
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 130,
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
			RowStep = 20,
			SmallRowStep=20,			

			ColumnsMark1=110,			

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1024		
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
			
		}		
	
		#region 定义打印各元素的坐标点
		private class clsPrintPageSettingForRecord
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
						m_fReturnPoint = new PointF(340f-fltOffsetX,30f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(280f-fltOffsetX,60f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(65f-fltOffsetX,100f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(115f-fltOffsetX,100f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(185f,100f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(230f,100f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(260f,100f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(305f,100f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(380f-fltOffsetX,100f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(430f-fltOffsetX,100f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(575f-fltOffsetX,100f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(625f-fltOffsetX,100f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(660f-fltOffsetX,100f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(720f-fltOffsetX,100f);
						break;
					
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;
	
				}
				return m_fReturnPoint;
			}
		}

	    #endregion
		#endregion
		
		#region 打印行定义
		private clsPrintLine1[] m_objLine1Arr;		
		#endregion
        #region 格子的信息
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
            RightX = 180 + 17,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 7,
            SmallRowStep = 20,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,
            ColumnsMark1 = 35,
            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,
            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,
            BottomY = 1024,
            PrintWidth = 670,
            PrintWidth2 = 710,

        }
        #endregion
        private DateTime dtmFirstPrintTime;
        #region 给每一打印行的元素赋值
        /// <summary>
		/// 给每一打印行的元素赋值
		/// </summary>
		private void m_mthSetPrintValue()
		{		
			#region  第一次打印时间赋值			
			dtmFirstPrintTime=DateTime.Now;
			if(m_objclsBeforeOperationSummary_All!=null && m_objclsBeforeOperationSummary_All.m_strFirstPrintDate !=null && m_objclsBeforeOperationSummary_All.m_strFirstPrintDate.Trim()!="")
				dtmFirstPrintTime=DateTime.Parse(m_objclsBeforeOperationSummary_All.m_strFirstPrintDate);
			#endregion  第一次打印时间赋值

			#region 打印行初始化
			m_objLine1Arr = new clsPrintLine1[10];
			for(int i=0;i<m_objLine1Arr.Length;i++)
				m_objLine1Arr[i]=new clsPrintLine1();
			
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1Arr[0],m_objLine1Arr[1],m_objLine1Arr[2],m_objLine1Arr[3],m_objLine1Arr[4],
										  m_objLine1Arr[5],m_objLine1Arr[6],m_objLine1Arr[7],m_objLine1Arr[8],m_objLine1Arr[9]
									  });
			m_objPrintContext.m_ObjPrintSign =  new clsPrintRecordSign();
			#endregion
			
			#region 给每一行的元素赋值
			if(m_objclsBeforeOperationSummary_All!=null && 
				m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo!=null &&
				m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo!=null)
			{
				///////////////1行/////////////////
				Object[] objData1=new object[4];
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnose;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseXml;

				objData1[2]=dtmFirstPrintTime ;
				objData1[3]=" 诊  断:" ;
				m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;

				///////////////2行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnoseGist;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseGistXml;
				objData1[3]=" 诊断依据:" ;
				m_objLine1Arr[1].m_ObjPrintLineInfo =objData1;

				///////////////3行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strBodyInfo;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strBodyInfoXml;
				objData1[3]="手术适应症:" ;
				m_objLine1Arr[2].m_ObjPrintLineInfo =objData1;
				///////////////4行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strSpecialHandle;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strSpecialHandleXml;
				objData1[3]="拟行手术方式术中注意事项及特殊情况的预防及处理:" ;
				m_objLine1Arr[3].m_ObjPrintLineInfo =objData1;
				///////////////5行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPreparation;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPreparationXml;
				objData1[3]=" 术前准备:" ;
				m_objLine1Arr[4].m_ObjPrintLineInfo =objData1;
				///////////////6行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPatientNotion;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPatientNotionXml;
				objData1[3]="患者及家属单位对手术意见:" ;
				m_objLine1Arr[5].m_ObjPrintLineInfo =objData1;
				///////////////7行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAnaesthesia;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAnaesthesiaXml;
				objData1[3]=" 拟行麻醉:" ;
				m_objLine1Arr[6].m_ObjPrintLineInfo =objData1;
				///////////////8行/////////////////			
				objData1[0]=DateTime.Parse(m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperationDate).ToString("yyyy年M月d日");
				objData1[1]="";
				objData1[3]=" 手术日期:" ;
				m_objLine1Arr[7].m_ObjPrintLineInfo =objData1;
				///////////////9行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAfterNotice;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAfterNoticeXml;
				objData1[3]=" 术后注意:" ;
				m_objLine1Arr[8].m_ObjPrintLineInfo =objData1;
				///////////////10行/////////////////
				objData1[0]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiscussNotion;
				objData1[1]=m_objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiscussNotionXml;
				objData1[3]="术前讨论意见:" ;
				m_objLine1Arr[9].m_ObjPrintLineInfo =objData1;
			}
			else 
			{
				///////////////1行/////////////////
				Object[] objData1=new object[4];
				objData1[0]="";
				objData1[1]="";

				objData1[2]=dtmFirstPrintTime ;
				objData1[3]=" 诊  断" ;
				m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;

				///////////////2行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]=" 诊断依据" ;
				m_objLine1Arr[1].m_ObjPrintLineInfo =objData1;

				///////////////3行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="手术适应症" ;
				m_objLine1Arr[2].m_ObjPrintLineInfo =objData1;
				///////////////4行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="拟行手术方式术中注意事项及特殊情况的预防及处理" ;
				m_objLine1Arr[3].m_ObjPrintLineInfo =objData1;
				///////////////5行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]=" 术前准备" ;
				m_objLine1Arr[4].m_ObjPrintLineInfo =objData1;
				///////////////6行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="患者及家属单位对手术意见" ;
				m_objLine1Arr[5].m_ObjPrintLineInfo =objData1;
				///////////////7行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]=" 拟行麻醉" ;
				m_objLine1Arr[6].m_ObjPrintLineInfo =objData1;
				///////////////8行/////////////////			
				objData1[0]="";
				objData1[1]="";
				objData1[3]=" 手术日期" ;
				m_objLine1Arr[7].m_ObjPrintLineInfo =objData1;
				///////////////9行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]=" 术后注意" ;
				m_objLine1Arr[8].m_ObjPrintLineInfo =objData1;
				///////////////10行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="术前讨论意见" ;
				m_objLine1Arr[9].m_ObjPrintLineInfo =objData1;

			}
			
			#endregion 
        }
        #endregion
        #region 页脚
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            Font fntHeader = new Font("SimSun", 12);
            e.Graphics.DrawString("第    页", fntHeader, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 175);
            e.Graphics.DrawString(m_intPages.ToString(), fntHeader, Brushes.Black, 412 - fltOffsetX, e.PageBounds.Height - 175);
        }
        #endregion
        #region 边框
        /// <summary>
        /// 打印边框
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            Font fntHeader = new Font("SimSun", 12);
            e.Graphics.DrawRectangle(Pens.Black, (int)enmRectangleInfo.LeftX - 10, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, e.PageBounds.Height - 330);
        }
        #endregion
        #region 标题文字部分
        /// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));
		
			e.Graphics.DrawString("术     前     小     结",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));	
            
		}
		#endregion		
		
		#region print class 

		private class clsPrintLine1 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objDiagnose;			
			private DateTime dtmFirstPrint;
            private bool m_blnFirstPrint = true;
			private string m_strTitle;
            private Object[] objData;

			public clsPrintLine1()
			{
				m_objDiagnose = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",12));
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (objData == null || objData[0] == "")
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnFirstPrint)
                {
                    p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, clsPrintPosition.c_intLeftX, p_intPosY);
                    p_intPosY += 20;
                    m_blnFirstPrint = false;
                }
                if (m_objDiagnose.m_BlnHaveNextLine())
                {
                    m_objDiagnose.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, clsPrintPosition.c_intLeftX + 60, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                if (m_objDiagnose.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {				
                    m_blnHaveMoreLine = false;
                }
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
                m_blnFirstPrint = true;
				m_objDiagnose.m_mthRestartPrint();	
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						objData=(object[])value;
						m_strTitle=objData[3].ToString();
						dtmFirstPrint=(DateTime)objData[2];						

						if(objData[1].ToString() == "")
						{
							m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),dtmFirstPrint);
						}
						else
						{
							m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),dtmFirstPrint,true);
							m_mthAddSign2(m_strTitle+":",m_objDiagnose.m_ObjModifyUserArr);
						}
						if(m_objDiagnose.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objDiagnose.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objDiagnose.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objDiagnose.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}					
					}
				}
			}
		}		
		#endregion

		#endregion

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
		//		clsBeforeOperationSummaryLJPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsBeforeOperationSummaryLJPrintTool();
		//			objPrintTool.m_mthInitPrintTool(null);	
		//			if(m_objBaseCurrentPatient==null)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
		//			else if(this.m_trvInOperationDate.SelectedNode ==null || this.m_trvInOperationDate.SelectedNode==m_trnRoot)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
		//			else 
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,m_dtpOeprationTime.Value);
		//								
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
		//			objPrintTool=new clsBeforeOperationSummaryLJPrintTool();
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


