using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 会诊记录的打印工具类,蔡沐忠-2003-7-1
	/// </summary>
	public class clsConsultationPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
		private clsConsultationDomain m_objRecordsDomain;
		private clsPrintInfo_Consultation m_objPrintInfo;
		public  clsConsultationRecordContent m_objRecordContent=null;
		
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
			m_objPrintInfo=new clsPrintInfo_Consultation();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
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
			m_blnWantInit=false;//
			if(m_objPrintInfo==null)
			{
				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_dtmOpenDate==DateTime.MinValue)
				m_objRecordContent=null;				
			else
			{
				m_objRecordsDomain=new clsConsultationDomain();	
				clsTrackRecordContent objContent=new clsTrackRecordContent();
				long lngRes=m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out objContent );
				if(lngRes <= 0  || objContent == null)
					return ;  
				m_objRecordContent=(clsConsultationRecordContent)objContent;

				if(m_objRecordContent.m_strMainDoctorID != null && m_objRecordContent.m_strMainDoctorID != "")
				{
					clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strMainDoctorID);
					m_objRecordContent.m_strMainDoctorName = objEmployee.m_StrLastName;
				}
				else
				{
					m_objRecordContent.m_strMainDoctorName = "";
				}
				
			}
			//设置表单内容到打印中			
			m_objPrintInfo.m_objRecordContent=m_objRecordContent;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			 		 

			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_Consultation")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_Consultation)p_objPrintContent;
			m_objRecordContent= m_objPrintInfo. m_objRecordContent ;		
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
					clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
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

			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
//			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
//			m_fotHeaderFont = new Font("SimSun", 14);
//			m_fotSmallFont = new Font("SimSun",11);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();

			#endregion
		}

		/// <summary>
		/// 释放打印变量，关闭窗体时调用
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont .Dispose();
			m_GridPen .Dispose();
			m_slbBrush .Dispose();
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
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_objRecordContent==null) return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue )
			{				
				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),dtmFirstPrintTime);//m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate);	
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
			string strConsultationDoctorName="";
			e.HasMorePages =false;
			m_mthPrintTitleInfo(e);
			Font fntNormal = new Font("SimSun",12);

			if(m_intPages==1)
			{				
				m_intYPos += (int)enmRectangleInfo.RowStep+5;						
			}
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY);
			
			while(m_objPrintContext.m_BlnHaveMoreLine)
			{
				m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

				if(m_intYPos >=(int)enmRectangleInfo.BottomY 
					&& m_objPrintContext.m_BlnHaveMoreLine)
				{					

					#region 换页处理
					e.HasMorePages = true;					
				
					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos);
					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos);
					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos,(int)enmRectangleInfo.RightX,m_intYPos);
			
					m_intPages++;	
					m_intYPos = (int)enmRectangleInfo.TopY;
					return;

					#endregion 换页处理 
				}				
				
			}

			#region 最后一页处理
			m_intYPos+=10;				
			e.Graphics.DrawString("会 诊 者:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,m_intYPos);
            if (m_objRecordContent != null)
            {
                if (m_objRecordContent.m_strConsultationDeptName != null && m_objRecordContent.m_strConsultationDeptName != string.Empty)
                    e.Graphics.DrawString(m_objRecordContent.m_strConsultationDeptName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 500 + (int)(5f * 17.5f), m_intYPos);
                else
                    e.Graphics.DrawString(m_objRecordContent.m_strOtherHospital_RIGHT, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 500 + (int)(5f * 17.5f), m_intYPos);
            }
			m_intYPos+=25;
			e.Graphics.DrawString("医 　 师:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,m_intYPos);
			if(m_objRecordContent!=null && m_objRecordContent.m_strConsultationDoctorNameArr!=null)
			{
				for(int i=0;i<m_objRecordContent.m_strConsultationDoctorNameArr.Length;i++)
				{
					strConsultationDoctorName+=m_objRecordContent.m_strConsultationDoctorNameArr[i];
		
				}
				e.Graphics.DrawString(strConsultationDoctorName,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+500+(int)(5f*17.5f),m_intYPos);
			}
			
			m_intYPos+=25;
			if(m_intYPos< (int)enmRectangleInfo.BottomY)
				m_intYPos=(int)enmRectangleInfo.BottomY;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos);
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos);
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos,(int)enmRectangleInfo.RightX,m_intYPos);
			
			#endregion 最后一页处理

			m_intYPos += (int)enmRectangleInfo.RowStep+15;
			Font fntSign = new Font("",6);
			while(m_objPrintContext.m_BlnHaveMoreSign)
			{
				m_objPrintContext.m_mthPrintNextSign((int)enmRectangleInfo.LeftX,m_intYPos,e.Graphics,fntSign);

				m_intYPos += (int)enmRectangleInfo.RowStep-10;				
			}

			//全部打完
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
		
		private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintContext;		
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
			LeftX = 40,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 820-40,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 30,
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

			HeartID_Title,
			HeartID,
			XRayID_Title,
			XRayID,
            
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
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{
                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(360f, 100f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(410f,100f);
                        break;
                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(555, 100f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(605, 100f);
                        break;
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(330f,30f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(280f,60f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(50f,100f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(100f,100f);
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
					
					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(655f,100f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(715f,100f);
						break;

					case (int)enmItemDefination.HeartID_Title:
						m_fReturnPoint = new PointF(500f,100f);
						break;
					case (int)enmItemDefination.HeartID :
						m_fReturnPoint = new PointF(570f,100f);
						break;

					case (int)enmItemDefination.XRayID_Title:
						m_fReturnPoint = new PointF(670f,100f);
						break;
					case (int)enmItemDefination.XRayID :
						m_fReturnPoint = new PointF(720f,100f);
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
		private clsPrintLine2 m_objLine2;
		#endregion
		
		private DateTime dtmFirstPrintTime;
		/// <summary>
		/// 给每一打印行的元素赋值
		/// </summary>
		private void m_mthSetPrintValue()
		{		
			#region  第一次打印时间赋值			
			dtmFirstPrintTime=DateTime.Now;
			if(m_objRecordContent!=null && m_objRecordContent.m_dtmFirstPrintDate !=DateTime.MinValue)
				dtmFirstPrintTime=m_objRecordContent.m_dtmFirstPrintDate;
			#endregion  第一次打印时间赋值

			#region 打印行初始化
			m_objLine1Arr = new clsPrintLine1[6];
			for(int i=0;i<m_objLine1Arr.Length;i++)
				m_objLine1Arr[i]=new clsPrintLine1();

			m_objLine2 = new clsPrintLine2();
						
			m_objPrintContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  m_objLine1Arr[0],m_objLine1Arr[1],m_objLine1Arr[2],m_objLine1Arr[3],m_objLine1Arr[4],
										  m_objLine2,m_objLine1Arr[5]
									  });
			m_objPrintContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
			#endregion
			
			#region 给每一行的元素赋值
			if(m_objRecordContent!=null )
			{
				///////////////1行/////////////////
                Object[] objData1=new object[4];
                //objData1[0]="";
                //objData1[1]="";
                objData1[2] = dtmFirstPrintTime;			
                //objData1[3]="　科别: "+m_objRecordContent.m_strAskConsultationDeptName+"     楼   "+m_objPrintInfo.m_strAreaName+"      房 "+m_objPrintInfo.m_strBedName+" 床";
                //m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;
				
				///////////////2行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                string ApplyDeptName = m_objRecordContent.m_strApplyConsultationDeptName;
                if (m_objRecordContent.m_strApplyConsultationDeptName == null || m_objRecordContent.m_strApplyConsultationDeptName == string.Empty)
                {
                    ApplyDeptName = m_objRecordContent.m_strOtherHospital_RIGHT;
                }
                objData1[3] = "　申请会诊科室: " + ApplyDeptName + "                   " + "日期:   " + m_objRecordContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmConsultation"));
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

				///////////////3行/////////////////
				objData1[0]=m_objRecordContent.m_strCaseHistory;
				objData1[1]=m_objRecordContent.m_strCaseHistoryXml;
				objData1[3]="　简要病历及会诊目的:" ;
				m_objLine1Arr[1].m_ObjPrintLineInfo =objData1;
				///////////////4行/////////////////
				objData1[0]=m_objRecordContent.m_strConsultationOrder;
				objData1[1]=m_objRecordContent.m_strConsultationOrderXml;
				objData1[3]="　目前诊断:";
				m_objLine1Arr[2].m_ObjPrintLineInfo =objData1;
				///////////////5行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　请求会诊科室:  "+(m_objRecordContent.m_strAskConsultationDeptName!=null? m_objRecordContent.m_strAskConsultationDeptName:"")+"        主治医师(科主任)：  "+m_objRecordContent.m_strMainDoctorName+"       住院医师：  "+(m_objRecordContent.m_strRequestDoctorNameArr!=null ? m_objRecordContent.m_strRequestDoctorNameArr[0] : "");
				m_objLine1Arr[3].m_ObjPrintLineInfo =objData1;
				Object[] objData2=new object[2];
				objData2[0]=m_objRecordContent.m_intConsultationTime;
				objData2[1]=dtmFirstPrintTime;
				m_objLine2.m_ObjPrintLineInfo = objData2;
				///////////////6行/////////////////				
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　会诊时间:"+"      请即来会诊"+"            "+"请在24小时内会诊"+"             一般会诊";
				m_objLine1Arr[4].m_ObjPrintLineInfo =objData1;
				///////////////7行/////////////////
				objData1[0]=m_objRecordContent.m_strConsultationIdea;
				objData1[1]=m_objRecordContent.m_strConsultationIdeaXml;
				objData1[3]="　会诊答复:                                  日期:";
				if(m_objRecordContent.m_strConsultationDoctorIDArr != null && m_objRecordContent.m_strConsultationDoctorIDArr.Length > 0)
					objData1[3] += m_objRecordContent.m_dtmConsultationDate.ToString("yyyy年M月d日 H时m分");
				m_objLine1Arr[5].m_ObjPrintLineInfo =objData1;
				///////////////8行/////////////////			
//				objData1[0]=m_objRecordContent.m_strOutHospitalAdvice;
//				objData1[1]=m_objRecordContent.m_strOutHospitalAdviceXML;
//				objData1[3]="　出院医嘱:" ;
//				m_objLine1Arr[7].m_ObjPrintLineInfo =objData1;
				
			}
			else 
			{
				///////////////1行/////////////////
                Object[] objData1=new object[4];
                //objData1[0]="";
                //objData1[1]="";
                objData1[2] = dtmFirstPrintTime;			
                //objData1[3]="　科别:"+"     楼"+"      区"+"      房"+"       床";
                //m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;
				
				///////////////2行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　申请会诊科室: "+"            "+"          日期:  ";
				m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;

				///////////////3行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　简要病历及会诊目的:" ;
				m_objLine1Arr[1].m_ObjPrintLineInfo =objData1;
				///////////////4行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　目前诊断:";
				m_objLine1Arr[2].m_ObjPrintLineInfo =objData1;
				///////////////5行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="请求会诊科室:"+"           科"+"        主治医师(科主任)：  "+"             住院医师：";
				m_objLine1Arr[3].m_ObjPrintLineInfo =objData1;
				///////////////6行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　会诊时间:"+"      请即来会诊"+"            "+"请在24小时内会诊"+"             一般会诊";
				m_objLine1Arr[4].m_ObjPrintLineInfo =objData1;
				///////////////7行/////////////////
				objData1[0]="";
				objData1[1]="";
				objData1[3]="　会诊答复:                                 日期:";
				m_objLine1Arr[5].m_ObjPrintLineInfo =objData1;
				///////////////8行/////////////////			
				//objData1[0]=m_objRecordContent.m_strOutHospitalAdvice;
				//objData1[1]=m_objRecordContent.m_strOutHospitalAdviceXML;
				//objData1[3]="　出院医嘱:" ;
				//m_objLine1Arr[7].m_ObjPrintLineInfo =objData1;
			}
			
			#endregion 
		}
		
		
		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("会     诊     记     录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			
			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));

			e.Graphics.DrawString(m_objPrintInfo.m_strPatientName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));

			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
		
			e.Graphics.DrawString(m_objPrintInfo.m_strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex ));
						
			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));

			e.Graphics.DrawString(m_objPrintInfo.m_strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));
            
            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
		}
		
	
		#endregion		
		
		#region print class 

		private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
		{
			private clsPrintRichTextContext m_objDiagnose;			
			private DateTime dtmFirstPrint;
//			private bool m_blnFirstPrint = true;
			private string m_strTitle;			

			public clsPrintLine1()
			{
				m_objDiagnose = new clsPrintRichTextContext(Color.Black,new Font("SimSun",12));
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				Font fntTitle = new Font("SimSun",12);
                if (m_strTitle.StartsWith("　申请"))
                {
                    p_intPosY -= 20;
                }
                ;
                p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
				if(m_strTitle!="　目前诊断:")
				{
					p_intPosY += 30;
				}				

				int intRealHeight;
				Rectangle rtgDianose = new Rectangle((int)enmRectangleInfo.LeftX+(int)enmRectangleInfo.ColumnsMark1-15,p_intPosY,(int)enmRectangleInfo.RightX- ((int)enmRectangleInfo.LeftX+(int)enmRectangleInfo.ColumnsMark1-15)-5,0);
				

				if(m_strTitle.StartsWith("　简要病历及会诊目的:"))
				{
					rtgDianose.Height = 9*(int)enmRectangleInfo.RowStep;							
					m_objDiagnose.m_blnPrintAllBySimSun(11,rtgDianose,p_objGrp,out intRealHeight,false);
					p_intPosY += 9*(int)enmRectangleInfo.RowStep;
				}
				else if(m_strTitle.StartsWith("　目前诊断:"))
				{
					rtgDianose.Height = 2*(int)enmRectangleInfo.RowStep;
					m_objDiagnose.m_blnPrintAllBySimSun(11,rtgDianose,p_objGrp,out intRealHeight,false);
					p_intPosY += 2*(int)enmRectangleInfo.RowStep;
				}
				else if(m_strTitle.StartsWith("　会诊答复:"))
				{
					rtgDianose.Height = 8*(int)enmRectangleInfo.RowStep;
					m_objDiagnose.m_blnPrintAllBySimSun(11,rtgDianose,p_objGrp,out intRealHeight,false);
					p_intPosY += 8*(int)enmRectangleInfo.RowStep;
				}

				fntTitle.Dispose();
				m_blnHaveMoreLine = false;
					
				#region old
//				p_intPosY +=5;
//				if(m_blnFirstPrint)
//				{
//					p_objGrp.DrawString(m_strTitle,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY+3);
//					m_blnFirstPrint = false;	
//
//					if(m_strTitle=="　简要病历及会诊目的:")
//						p_intPosY +=25;
//				}
//
//				if(m_objDiagnose.m_BlnHaveNextLine())
//					m_objDiagnose.m_mthPrintLine((int)enmRectangleInfo.RightX- ((int)enmRectangleInfo.LeftX+(int)enmRectangleInfo.ColumnsMark1+5)-5, (int)enmRectangleInfo.LeftX+(int)enmRectangleInfo.ColumnsMark1+5,p_intPosY,p_objGrp);
//				
//				if(m_objDiagnose.m_BlnHaveNextLine())//注意，此时与上一句的条件不能合并在一起
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					m_intTimes++;
//				}				
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					
//					if(m_strTitle=="　简要病历及会诊目的:")
//					{
//						//添加默认的打印宽度
//						if(m_intTimes < 4 && m_intTimes!=0)
//						{
//							p_intPosY += (4-m_intTimes)*(int)enmRectangleInfo.RowStep;
//
//						}
//					
//						else if(m_intTimes == 0)
//						{
//							p_intPosY +=4*(int)enmRectangleInfo.RowStep;
//						}
//						if(p_intPosY>=(int)enmRectangleInfo.BottomY)
//						{
//							p_intPosY=(int)enmRectangleInfo.BottomY;
//						}
//
//					}
//					else if(m_strTitle=="　目前诊断")
//					{
//						if(m_intTimes < 8 && m_intTimes!=0)
//						{
//							p_intPosY += (8-m_intTimes)*(int)enmRectangleInfo.RowStep;
//
//						}
//					
//						else if(m_intTimes == 0)
//						{
//							p_intPosY +=8*(int)enmRectangleInfo.RowStep;
//						}
//						if(p_intPosY>=(int)enmRectangleInfo.BottomY)
//						{
//							p_intPosY=(int)enmRectangleInfo.BottomY;
//						}
//
//					}
//					
//					else if(m_strTitle=="　会诊答复:")
//					{
//						if(m_intTimes < 4 && m_intTimes!=0)
//						{
//							p_intPosY += (4-m_intTimes)*(int)enmRectangleInfo.RowStep;
//
//						}
//					
//						else if(m_intTimes == 0)
//						{
//							p_intPosY +=4*(int)enmRectangleInfo.RowStep;
//						}
//						if(p_intPosY>=(int)enmRectangleInfo.BottomY)
//						{
//							p_intPosY=(int)enmRectangleInfo.BottomY;
//						}	
//					}
//					else 
//					{
//						if(m_intTimes < 1 && m_intTimes!=0)
//						{
//							p_intPosY += (1-m_intTimes)*(int)enmRectangleInfo.RowStep;
//
//						}
//					
//						else if(m_intTimes == 0)
//						{
//							p_intPosY +=1*(int)enmRectangleInfo.RowStep;
//						}
//						if(p_intPosY>=(int)enmRectangleInfo.BottomY)
//						{
//							p_intPosY=(int)enmRectangleInfo.BottomY;
//						}					
//						
//					}									
//				}
				#endregion

			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
//				m_blnFirstPrint = true;
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
						Object [] objData=(object[])value;
						m_strTitle=objData[3].ToString();
						dtmFirstPrint=(DateTime)objData[2];
                        if (clsConsultationPrintTool.m_blnIsPrintMark)
                        {
                            if (objData[1].ToString() == "")
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint);
                            }
                            else
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint, true);
                                m_mthAddSign2(m_strTitle, m_objDiagnose.m_ObjModifyUserArr);
                            }
                        }
                        else
                        {
                            m_objDiagnose.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
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
		/// <summary>
		/// 会诊时间打勾
		/// </summary>
		private class clsPrintLine2 : com.digitalwave.Utility.Controls.clsPrintLineBase
		{
			private int intConsultationTime;
			private DateTime dtmFirstPrint;
			private bool m_blnPrintFirst=true;			
//			private int m_intTimes = 0;

			public clsPrintLine2()
			{
			
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//打印会诊时间上下方的横线
				p_objGrp.DrawLine( new Pen(Color.Black,1),new Point((int)enmRectangleInfo.LeftX,p_intPosY-35),new Point((int)enmRectangleInfo.RightX,p_intPosY-35));
				p_objGrp.DrawLine( new Pen(Color.Black,1),new Point((int)enmRectangleInfo.LeftX,p_intPosY-5),new Point((int)enmRectangleInfo.RightX,p_intPosY-5));

				if(m_blnPrintFirst==true)
				{
					switch (intConsultationTime)
					{
						case 1:
							p_objGrp.DrawString("√",new Font("SimSun",36) ,Brushes.Black,210,p_intPosY-50);
							break;
						case 2:
							p_objGrp.DrawString("√",new Font("SimSun",36) ,Brushes.Black,420,p_intPosY-50);
							break;
						case 3:
							p_objGrp.DrawString("√",new Font("SimSun",36) ,Brushes.Black,650,p_intPosY-50);
							break;

					}
					m_blnPrintFirst=false;
				}
				p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
				m_blnHaveMoreLine = false;
			}
	
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
//				m_intTimes=0;
				m_blnPrintFirst=true;			
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
						Object[] objLine2=(Object[])value ;
						intConsultationTime=Convert.ToInt16(objLine2[0]);
						dtmFirstPrint=(DateTime)objLine2[1];
					}
				}
			}
	
		}
		#endregion

		#endregion

		//		/// <summary>
		//		/// 会诊记录的打印信息.
		//		/// </summary>
		//		[Serializable]			
		//		private class clsPrintInfo_OutHospital
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
		//			public clsOutHospitalRecordContent m_objRecordContent;			
		//		}

		#region 外部打印.	
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
		//		private bool m_blnHasInitPrintTool=false;
		//		clsOutHospitalPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			if(m_blnHasInitPrintTool==false)
		//			{
		//				objPrintTool=new clsOutHospitalPrintTool();
		//				objPrintTool.m_mthInitPrintTool(null);	
		//				m_blnHasInitPrintTool=true;
		//			}
		//			if(m_objBaseCurrentPatient==null)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
		//			else if(this.m_lblInHospitalDate.Text.Trim() !="")
		//			{
		//				if(this.m_trvCreateDate.SelectedNode==null||this.m_trvCreateDate.SelectedNode.Tag ==null)
		//					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.Parse( this.m_lblInHospitalDate.Text.Trim()),DateTime.MinValue);
		//				else 
		//					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.Parse( this.m_lblInHospitalDate.Text.Trim()),DateTime.Parse(this.m_trvCreateDate.SelectedNode.Tag.ToString()));
		//			}
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
		//			objPrintTool=new clsOutHospitalPrintTool();
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
		#endregion 外部打印.
	}	
}


