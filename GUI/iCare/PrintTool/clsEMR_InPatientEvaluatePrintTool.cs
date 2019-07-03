using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using System.Xml;
using System.Text;

namespace iCare
{
	/// <summary>
	/// 病人入院评估表
	/// </summary>
	public class clsEMR_InPatientEvaluatePrintTool:infPrintRecord
	{
		public clsEMR_InPatientEvaluatePrintTool()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsEMR_InPatientEvaluateDomain m_objRecordsDomain;
		private clsPrintInfo_InPatientEvaluate m_objPrintInfo;
		private clsEMR_InPatientEvaluate_All m_objInPatientEvaluate_All=null;
        private int intInhospitalDays = 0;
		private bool m_blnPreview = true;
        private XmlParserContext m_objXmlParser = new XmlParserContext(null, null, null, XmlSpace.None, Encoding.Unicode);
		/// <summary>
		/// 是否预览
		/// </summary>
		public bool m_BlnPreview
		{
			set
			{
				m_blnPreview = value;
			}
		}

		private bool m_blnIsDummy = false;
		/// <summary>
		/// 是否套打
		/// </summary>
		public bool m_BlnIsDummy
		{
			set 
			{
				m_blnIsDummy = value;
			}
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
			m_objPrintInfo=new clsPrintInfo_InPatientEvaluate();

			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
			
			m_objPrintInfo. m_strOccupation=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";//职业
			m_objPrintInfo. m_strNationnality=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrNation : "";//民族
            //m_objPrintInfo.m_strHometown = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrHomeplace : "";//籍贯m_StrNativePlace
            m_objPrintInfo.m_strHometown = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNativePlace : "";//籍贯
			m_objPrintInfo.m_strHomeAddress = m_objPatient!=null?m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress : "";//住址

            if (m_objPatient.m_DtmLastOutDate == DateTime.Parse("1900-01-01 00:00:00") || m_objPatient.m_DtmLastOutDate == DateTime.MinValue)
            {
                intInhospitalDays = (DateTime.Now - m_objPatient.m_DtmSelectedHISInDate).Days + 1;
            }
            else
            {
                intInhospitalDays = (m_objPatient.m_DtmLastOutDate - m_objPatient.m_DtmLastInDate).Days + 1;
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
			if(m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_dtmInPatientDate==DateTime.MinValue)
				m_objInPatientEvaluate_All=null;

			else
			{
				m_objRecordsDomain=new clsEMR_InPatientEvaluateDomain();	
				long lngRes=m_objRecordsDomain.m_lngGetLatestRecord_All(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objInPatientEvaluate_All );
				if(lngRes <= 0)
					return ;   

				#region  第一次打印时间赋值
				string strFirstPrintDate="";
				m_objRecordsDomain.m_strGetFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out strFirstPrintDate);
			
				DateTime dtmFirstPrintTime;
				if(strFirstPrintDate==null ||strFirstPrintDate.Trim()=="")
					dtmFirstPrintTime=DateTime.Now;
				else 
					dtmFirstPrintTime=DateTime.Parse(strFirstPrintDate);
				#endregion  第一次打印时间赋值	
		
				m_objPrintInfo.m_dtmFirstPrintTime=dtmFirstPrintTime;

			}

			//设置表单内容到打印中			
			m_objPrintInfo.m_objEmrInPatientEvaluate_All=m_objInPatientEvaluate_All;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_InPatientEvaluate")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_InPatientEvaluate)p_objPrintContent;
			m_objInPatientEvaluate_All= m_objPrintInfo. m_objEmrInPatientEvaluate_All ;		
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
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 14);
			m_fotSmallFont = new Font("SimSun",11);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();
			m_objCPaint=new clsPublicControlPaint();			
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont.Dispose();
			m_GridPen.Dispose();
			m_slbBrush.Dispose();			
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
			//			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
			PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

			if(m_blnPreview)
			{
				m_mthPrintPageSub(e);
			}
			else
			{
				if(m_blnIsDummy)
				{				
					m_mthPrintPageSub(e);   
					e.HasMorePages = false;
					return;
					//					e.Graphics.Clear(Color.White);
				}
				else
				{
					m_mthPrintPageSub(e);  
					//e.HasMorePages = false;
				}
				//				m_mthResetWhenEndPrint();
			}
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{			
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_objEmrInPatientEvaluate_All==null) return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_dtmFirstPrintTime != DateTime.MinValue)
			{				
				long lngRes=m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"));	
				if(lngRes<=0)
				{
					switch(lngRes)
					{
						case (long)iCareData.enmOperationResult.Not_permission:
							clsPublicFunction.s_mthShowNotPermitMessage();
							break;
						case (long)iCareData.enmOperationResult.DB_Fail://如果不是首次打印则返回值为0，因此此处不能加此判断							
							break;
						default : 
							clsPublicFunction.ShowInformationMessageBox("更新打印时间失败");
							break;

					}	
					return;
				}
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
			if(m_intPages == 1)
				m_mthPrintTitleInfo(e);
			Font fntNormal = new Font("SimSun",12);

			if(m_intPages!=1)
				m_intYPos=m_intYPos+5;

			while(m_objPrintContext.m_BlnHaveMoreLine)
			{
				m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

				if(m_intYPos >1110 && m_objPrintContext.m_BlnHaveMoreLine)
				{
					e.HasMorePages = true;
					m_intPreY=(int)enmRectangleInfo.TopY;

					m_intPages++;
					m_intYPos=(int)enmRectangleInfo.TopY+5;					

					return;
				}
			}

			if(m_intPages == 2)
				m_mthPrintTitleInfo_Health_Out(e);

			

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
			m_intEndIndex=0;
			m_intYPos = (int)enmRectangleInfo.TopY+5;
			m_intPreY=(int)enmRectangleInfo.TopY;
		}

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}
	
		#region 有关打印的声明

		private clsPublicControlPaint m_objCPaint;
		private clsPrintContext m_objPrintContext;		
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
		private int m_intPreY = (int)enmRectangleInfo.TopY;
		private int m_intEndIndex = 0;
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
			RightX = 827-55,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 18,
			SmallRowStep=18,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 32,

			ColumnsMark1=50,

			/// <summary>
			/// CheckBox偏移右边文本的距离
			/// </summary>
			CheckShift=15,

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1024
		
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
                    
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(320f,60f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(260f,85f);
						break;
					
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;
	
				}
				return m_fReturnPoint;
			}
		}

		#endregion

		#region 打印行定义
		private clsPrintLine1 m_objLine1;
		private clsPrintLine2 m_objLine2;
		private clsPrintLine3 m_objLine3;
		private clsPrintLine4 m_objLine4;
		private clsPrintLine5 m_objLine5;
		private clsPrintLine6 m_objLine6;
		private clsPrintLine7 m_objLine7;
		private clsPrintLine8 m_objLine8;
		private clsPrintLine9 m_objLine9;
		private clsPrintLine10 m_objLine10;
		private clsPrintLine11 m_objLine11;
		private clsPrintLine12 m_objLine12;
		private clsPrintLine13 m_objLine13;
		private clsPrintLine14 m_objLine14;
		private clsPrintLine15 m_objLine15;
		private clsPrintLine16 m_objLine16;
		private clsPrintLine17 m_objLine17;
		private clsPrintLine18 m_objLine18;
		private clsPrintLine19 m_objLine19;
		private clsPrintLine20 m_objLine20;
		private clsPrintLine21 m_objLine21;
		private clsPrintLine22 m_objLine22;
		private clsPrintLine23 m_objLine23;
		private clsPrintLine24 m_objLine24;
		private clsPrintLine25 m_objLine25;
		private clsPrintLine26 m_objLine26;
		private clsPrintLine27 m_objLine27;
		private clsPrintLine28 m_objLine28;
		private clsPrintLine29 m_objLine29;
		private clsPrintLine30 m_objLine30;
		private clsPrintLine31 m_objLine31;
		private clsPrintLine2_1 m_objLine2_1;
		private clsPrintLine2_2 m_objLine2_2;
		private clsPrintLine2_3 m_objLine2_3;
		private clsPrintLine2_4 m_objLine2_4;
		private clsPrintLine2_5 m_objLine2_5;
		private clsPrintLine2_6 m_objLine2_6;
		private clsPrintLine2_7 m_objLine2_7;
		private clsPrintLine2_8 m_objLine2_8;
		private clsPrintLine2_9 m_objLine2_9;
		private clsPrintLine2_10 m_objLine2_10;
		private clsPrintLine2_11 m_objLine2_11;
		private clsPrintLine2_12 m_objLine2_12;
		private clsPrintLine2_13 m_objLine2_13;
		private clsPrintLine2_14 m_objLine2_14;
		#endregion

		private object [] m_objInitObject(int p_intLenth,DateTime p_dtmFirstPrintTime)
		{
			object[] objData=new object[p_intLenth];	
			for(int k=0;k<objData.Length-1;k++)			
				objData[k]="";
			objData[objData.Length-1]=p_dtmFirstPrintTime;
			return objData;
		}
        /// <summary>
        /// 获取去除双划线后的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string m_mthGetValueWithoutDI(string p_strValue, string p_strValueXML)
        {
            if (p_strValue == "" || p_strValueXML == "")
                return p_strValue;
            XmlTextReader objReader = new XmlTextReader(p_strValueXML, XmlNodeType.Element, m_objXmlParser);
            objReader.WhitespaceHandling = WhitespaceHandling.None;
            string m_strValue = p_strValue;
            try
            {
                int intBeginIndex = 0;
                int intEndIndex = 0;
                string strInsertString = "";//用于填充被remove掉的字符
                while (objReader.Read())
                {
                    switch (objReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (objReader.HasAttributes && objReader.Name == "DI")
                            {
                                intBeginIndex = Convert.ToInt32(objReader.GetAttribute("S"));
                                intEndIndex = Convert.ToInt32(objReader.GetAttribute("E"));
                                m_strValue = m_strValue.Remove(intBeginIndex, intEndIndex - intBeginIndex + 1);
                                for (int i = 0; i < intEndIndex - intBeginIndex + 1; i++)
                                    strInsertString += "き";
                                m_strValue = m_strValue.Insert(intBeginIndex, strInsertString);
                                strInsertString = "";
                            }
                            break;
                    }
                }
                return m_strValue.Replace("き", "");
            }
            catch (Exception ex)
            {
                string strError = ex.ToString();
                return m_strValue;
            }
        }
		private void m_mthSetPrintValue()
		{
			#region 打印行初始化
			m_objLine1 = new clsPrintLine1();
			m_objLine2 = new clsPrintLine2();
			m_objLine3 = new clsPrintLine3();
			m_objLine4 = new clsPrintLine4();
			m_objLine5 = new clsPrintLine5();
			m_objLine6 = new clsPrintLine6();
			m_objLine7 = new clsPrintLine7();
			m_objLine8 = new clsPrintLine8();
			m_objLine9 = new clsPrintLine9();
			m_objLine10 = new clsPrintLine10();
			m_objLine11 = new clsPrintLine11();
			m_objLine12 = new clsPrintLine12();
			m_objLine13 = new clsPrintLine13();
			m_objLine14 = new clsPrintLine14();
			m_objLine15 = new clsPrintLine15();
			m_objLine16 = new clsPrintLine16();
			m_objLine17 = new clsPrintLine17();
			m_objLine18 = new clsPrintLine18();
			m_objLine19 = new clsPrintLine19();
			m_objLine20 = new clsPrintLine20();
			m_objLine21 = new clsPrintLine21();
			m_objLine22 = new clsPrintLine22();
			m_objLine23 = new clsPrintLine23();
			m_objLine24 = new clsPrintLine24();
			m_objLine25 = new clsPrintLine25();
			m_objLine26 = new clsPrintLine26();
			m_objLine27 = new clsPrintLine27();
			m_objLine28 = new clsPrintLine28();
			m_objLine29 = new clsPrintLine29();
			m_objLine30 = new clsPrintLine30();
			m_objLine31 = new clsPrintLine31();
			m_objLine2_1 = new clsPrintLine2_1();
			m_objLine2_2 = new clsPrintLine2_2();
			m_objLine2_3 = new clsPrintLine2_3();
			m_objLine2_4 = new clsPrintLine2_4();
			m_objLine2_5 = new clsPrintLine2_5();
			m_objLine2_6 = new clsPrintLine2_6();
			m_objLine2_7 = new clsPrintLine2_7();
			m_objLine2_8 = new clsPrintLine2_8();
			m_objLine2_9 = new clsPrintLine2_9();
			m_objLine2_10 = new clsPrintLine2_10();
			m_objLine2_11 = new clsPrintLine2_11();
			m_objLine2_12 = new clsPrintLine2_12();
			m_objLine2_13 = new clsPrintLine2_13();
			m_objLine2_14 = new clsPrintLine2_14();

			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
										  m_objLine3,
										  m_objLine4,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
										  m_objLine8,
										  m_objLine9,
										  m_objLine10,
										  m_objLine11,
										  m_objLine12,
										  m_objLine13,
										  m_objLine14,
										  m_objLine15,
										  m_objLine16,
										  m_objLine17,
										  m_objLine18,
										  m_objLine19,
										  m_objLine20,
										  m_objLine21,
										  m_objLine22,
										  m_objLine23,
										  m_objLine24,
										  m_objLine25,
										  m_objLine26,
										  m_objLine27,
										  m_objLine28,
										  m_objLine29,
										  m_objLine30,
										  m_objLine31,
										  m_objLine2_1,
										  m_objLine2_2,
										  m_objLine2_3,
										  m_objLine2_4,
										  m_objLine2_5,
										  m_objLine2_6,
										  m_objLine2_7,
										  m_objLine2_8,
										  m_objLine2_9,
										  m_objLine2_10,
										  m_objLine2_11,
										  m_objLine2_12,
										  m_objLine2_13,
										  m_objLine2_14
									  });
			m_objPrintContext.m_ObjPrintSign =  new clsPrintRecordSign();
			#endregion 

			if(m_objPrintInfo.m_strInPatentID !="" && m_objInPatientEvaluate_All !=null && m_objInPatientEvaluate_All.m_objclsInPatientEvaluate !=null && m_objInPatientEvaluate_All.m_objclsInPatientHealth_VO != null && m_objInPatientEvaluate_All.m_objInPatientOutEvaluate_VO != null)
			{	
				clsEMR_InPatientEvaluate objclsInPatientEvaluate=m_objInPatientEvaluate_All.m_objclsInPatientEvaluate;
				clsEMR_InPatientHealth_VO objclsInPatientHeslth = m_objInPatientEvaluate_All.m_objclsInPatientHealth_VO;
				clsEMR_InPatientOutEvaluate_VO objclsInPatientOut = m_objInPatientEvaluate_All.m_objInPatientOutEvaluate_VO;
						
				DateTime dtmFirstPrintTime=m_objPrintInfo.m_dtmFirstPrintTime;

				#region 给每一行赋值
				///////////////1行/////////////////
				Object[] objData1=new object[2];
				objData1[0]=m_objPrintInfo;//改为传递打印信息对象替换病人类型的对象.
				objData1[1]=dtmFirstPrintTime ;
				m_objLine1.m_ObjPrintLineInfo =objData1;

				///////////////2行/////////////////
				Object[] objData2=new object[4];
				objData2[0]=m_objPrintInfo;
				objData2[1]=dtmFirstPrintTime ;
				objData2[2]=objclsInPatientEvaluate.m_strEducationDegree;
                objData2[3] = objclsInPatientEvaluate.m_strPaymentMethod;
				m_objLine2.m_ObjPrintLineInfo =objData2;

				///////////////3行/////////////////
				Object[] objData3=new object[2];
				objData3[0]=m_objPrintInfo;
				objData3[1]=dtmFirstPrintTime ;
				m_objLine3.m_ObjPrintLineInfo =objData3;

				///////////////4行/////////////////
				Object[] objData4=new object[3];
				objData4[0]=objclsInPatientEvaluate.m_strInHospitalMethod;
                objData4[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strInHospitalDiagnose,objclsInPatientEvaluate.m_strInHospitalDiagnoseXML);
				objData4[2]= dtmFirstPrintTime ;
				m_objLine4.m_ObjPrintLineInfo =objData4;

				///////////////5行/////////////////
				Object[] objData5=new object[3];
                objData5[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strCaseHistory,objclsInPatientEvaluate.m_strCaseHistoryXML);
                objData5[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strFamilyHistory,objclsInPatientEvaluate.m_strFamilyHistoryXML);
				objData5[2]= dtmFirstPrintTime ;
				m_objLine5.m_ObjPrintLineInfo =objData5;

				///////////////6行/////////////////
				Object[] objData6=new object[2];
                objData6[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strChiefComplain,objclsInPatientEvaluate.m_strChiefComplainXML);
				objData6[1]= dtmFirstPrintTime ;
				m_objLine6.m_ObjPrintLineInfo =objData6;

				///////////////7行/////////////////
				Object[] objData7=new object[3];
				objData7[0]=objclsInPatientEvaluate.m_strSensitiveHistory;
                objData7[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strSensitiveHistory_Other,objclsInPatientEvaluate.m_strSensitiveHistory_OtherXML);
				objData7[2]= dtmFirstPrintTime ;
				m_objLine7.m_ObjPrintLineInfo =objData7;

				///////////////8行/////////////////
				///输出"一、体格检查"

				///////////////9行/////////////////
				Object[] objData9=new object[8];
                objData9[0] = objclsInPatientEvaluate.m_strBodyTemperature;
				objData9[1] = objclsInPatientEvaluate.m_strPulse;
				objData9[2]= objclsInPatientEvaluate.m_strHeartPhythm ;
				objData9[3] = objclsInPatientEvaluate.m_strBP_Shrink;
				objData9[4] = objclsInPatientEvaluate.m_strBP_Extend;
				objData9[5] = objclsInPatientEvaluate.m_strAvoirdupois;
				objData9[6] = dtmFirstPrintTime;
                objData9[7] = objclsInPatientEvaluate.m_strShengao;
				m_objLine9.m_ObjPrintLineInfo =objData9;

				///////////////10行/////////////////
				Object[] objData10=new object[3];
				objData10[0]=objclsInPatientEvaluate.m_strConsciousness;
				objData10[1] = objclsInPatientEvaluate.m_strComplexion;
				objData10[2] = dtmFirstPrintTime;
				m_objLine10.m_ObjPrintLineInfo =objData10;

				///////////////11行/////////////////
				Object[] objData11=new object[4];
				objData11[0]=objclsInPatientEvaluate.m_strPhysique;
                objData11[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strPhysique_Other,objclsInPatientEvaluate.m_strPhysique_OtherXML);
				objData11[2] = dtmFirstPrintTime;
				objData11[3] = objclsInPatientEvaluate.m_strEmotion;
				m_objLine11.m_ObjPrintLineInfo =objData11;

				///////////////12行/////////////////
				Object[] objData12=new object[3];
				objData12[0]=objclsInPatientEvaluate.m_strSkin;
                objData12[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strSkin_Other,objclsInPatientEvaluate.m_strSkin_OtherXML);
				objData12[2] = dtmFirstPrintTime;
				m_objLine12.m_ObjPrintLineInfo =objData12;

				///////////////13行/////////////////
				Object[] objData13=new object[3];
				objData13[0]=objclsInPatientEvaluate.m_strLimbsactivity;
                objData13[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strLimbsactivity_Other,objclsInPatientEvaluate.m_strLimbsactivity_OtherXML);
				objData13[2] = dtmFirstPrintTime;
				m_objLine13.m_ObjPrintLineInfo =objData13;

				///////////////14行/////////////////
				///输出"二、生活状况及自理程度"
				
				///////////////15行/////////////////
				Object[] objData15=new object[2];
				objData15[0]=objclsInPatientEvaluate.m_strBiteSup;
				objData15[1] = dtmFirstPrintTime;
				m_objLine15.m_ObjPrintLineInfo =objData15;

				///////////////16行/////////////////
				Object[] objData16=new object[3];
				objData16[0]=objclsInPatientEvaluate.m_strAppetite;
				objData16[1] = objclsInPatientEvaluate.m_strSleep;
				objData16[2] = dtmFirstPrintTime;
				m_objLine16.m_ObjPrintLineInfo =objData16;

				///////////////17行/////////////////
				Object[] objData17=new object[5];
				objData17[0]=objclsInPatientEvaluate.m_strStool;
				objData17[1] = objclsInPatientEvaluate.m_strAstriction;
				objData17[2] = objclsInPatientEvaluate.m_strDiarrhea;
                objData17[3] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strStool_Other,objclsInPatientEvaluate.m_strStool_OtherXML);
				objData17[4] = dtmFirstPrintTime;
				m_objLine17.m_ObjPrintLineInfo =objData17;

				///////////////18行/////////////////
				Object[] objData18=new object[2];
				objData18[0]=objclsInPatientEvaluate.m_strPee;
				objData18[1] = dtmFirstPrintTime;
				m_objLine18.m_ObjPrintLineInfo =objData18;

				///////////////19行/////////////////
				Object[] objData19=new object[4];
				objData19[0]=objclsInPatientEvaluate.m_strHobby;
                objData19[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strHobby_Other,objclsInPatientEvaluate.m_strHobby_OtherXML);
				objData19[2] = dtmFirstPrintTime;
				objData19[3] = objclsInPatientEvaluate.m_strSelfSolve;
				m_objLine19.m_ObjPrintLineInfo =objData19;

				///////////////20行/////////////////
				///输出"二、心理社会方面"
				
				///////////////21行/////////////////
				Object[] objData21=new object[2];
				objData21[0]=objclsInPatientEvaluate.m_strFeeling;
				objData21[1]=dtmFirstPrintTime ;
				m_objLine21.m_ObjPrintLineInfo =objData21;

				///////////////22行/////////////////
				Object[] objData22=new object[2];
				objData22[0]=objclsInPatientEvaluate.m_strJob;
				objData22[1]=dtmFirstPrintTime ;
				m_objLine22.m_ObjPrintLineInfo =objData22;

				///////////////23行/////////////////
				Object[] objData23=new object[3];
				objData23[0]=objclsInPatientEvaluate.m_strInHospitalWorry;
                objData23[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strInHospitalWorry_Other,objclsInPatientEvaluate.m_strInHospitalWorryXML);
				objData23[2] = dtmFirstPrintTime;
				m_objLine23.m_ObjPrintLineInfo =objData23;

				///////////////24行/////////////////
				Object[] objData24=new object[3];
				objData24[0]=objclsInPatientEvaluate.m_strFamilyForm;
                objData24[1] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strFamilyForm_Other,objclsInPatientEvaluate.m_strFamilyForm_OtherXML);
				objData24[2] = dtmFirstPrintTime;
				m_objLine24.m_ObjPrintLineInfo =objData24;

				///////////////25行/////////////////
				Object[] objData25=new object[2];
				objData25[0]=objclsInPatientEvaluate.m_strHealthNeed;
				objData25[1] = dtmFirstPrintTime;
				m_objLine25.m_ObjPrintLineInfo =objData25;

				///////////////26行/////////////////
				Object[] objData26=new object[2];
				objData26[0]=objclsInPatientEvaluate.m_strKnowDisease;
				objData26[1] = dtmFirstPrintTime;
				m_objLine26.m_ObjPrintLineInfo =objData26;

				///////////////27行/////////////////
				Object[] objData27=new object[2];
                objData27[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strSpecializedCheck,objclsInPatientEvaluate.m_strSpecializedCheckXML);
				objData27[1]= dtmFirstPrintTime ;
				m_objLine27.m_ObjPrintLineInfo =objData27;

				///////////////28行/////////////////
				Object[] objData28=new object[2];
                objData28[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strPipInstance,objclsInPatientEvaluate.m_strPipInstanceXML);
				objData28[1]= dtmFirstPrintTime ;
				m_objLine28.m_ObjPrintLineInfo =objData28;

				///////////////29行/////////////////
				Object[] objData29=new object[2];
                objData29[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strWoodInstance,objclsInPatientEvaluate.m_strWoodInstanceXML);
				objData29[1]= dtmFirstPrintTime ;
				m_objLine29.m_ObjPrintLineInfo =objData29;

				///////////////30行/////////////////
				Object[] objData30=new object[2];
                objData30[0] = m_mthGetValueWithoutDI(objclsInPatientEvaluate.m_strTendPlan,objclsInPatientEvaluate.m_strTendPlanXML);
				objData30[1]= dtmFirstPrintTime ;
				m_objLine30.m_ObjPrintLineInfo =objData30;

				///////////////31行/////////////////
				Object[] objData31=new object[2];
				objData31[0]=new clsEmployee(objclsInPatientEvaluate.m_strModifyUserID).m_StrFirstName.Trim();
				objData31[1]= dtmFirstPrintTime ;
				m_objLine31.m_ObjPrintLineInfo =objData31;

				///////////////2_1行/////////////////
				Object[] objData2_1=new object[2];
				objData2_1[0]=objclsInPatientHeslth.m_dtmWriteFormDate;
				objData2_1[1]= dtmFirstPrintTime ;
				m_objLine2_1.m_ObjPrintLineInfo =objData2_1;

				///////////////2_2行/////////////////
				///打印表格顶格元素
				
				///////////////2_3(打印表格内容)/////////////////
				Object[] objData2_3=new object[4];
				objData2_3[0]=objclsInPatientHeslth.m_strHEDU_First;
				objData2_3[1]=objclsInPatientHeslth.m_strHEDU_Second;
				objData2_3[2]=objclsInPatientHeslth.m_strHEDU_Three;
				objData2_3[3]= dtmFirstPrintTime ;
				m_objLine2_3.m_ObjPrintLineInfo =objData2_3;

				///////////////2_4行/////////////////
				Object[] objData2_4=new object[2];
                objData2_4[0] = intInhospitalDays;
				objData2_4[1]= dtmFirstPrintTime ;
				m_objLine2_4.m_ObjPrintLineInfo =objData2_4;

				///////////////2_5行/////////////////
				Object[] objData2_5=new object[2];
                objData2_5[0] = m_mthGetValueWithoutDI(objclsInPatientOut.m_strOutHospitalDiagnose,objclsInPatientOut.m_strOutHospitalDiagnoseXML);
				objData2_5[1]= dtmFirstPrintTime ;
				m_objLine2_5.m_ObjPrintLineInfo =objData2_5;

				///////////////2_6行/////////////////
				Object[] objData2_6=new object[2];
				objData2_6[0]=objclsInPatientOut.m_strLiveAbility;
				objData2_6[1]= dtmFirstPrintTime ;
				m_objLine2_6.m_ObjPrintLineInfo =objData2_6;

				///////////////2_7行/////////////////
				Object[] objData2_7=new object[2];
				objData2_7[0]=objclsInPatientOut.m_strDieteticCircs;
				objData2_7[1]= dtmFirstPrintTime ;
				m_objLine2_7.m_ObjPrintLineInfo =objData2_7;

				///////////////2_8行/////////////////
				Object[] objData2_8=new object[2];
				objData2_8[0]=objclsInPatientOut.m_strOutHospitalMode;
				objData2_8[1]= dtmFirstPrintTime ;
				m_objLine2_8.m_ObjPrintLineInfo =objData2_8;

				///////////////2_9行/////////////////
				Object[] objData2_9=new object[3];
				objData2_9[0]=objclsInPatientOut.m_strIsNurseSyndrome;
                objData2_9[1] = m_mthGetValueWithoutDI(objclsInPatientOut.m_strNurseSyndrome,objclsInPatientOut.m_strNurseSyndromeXML);
				objData2_9[2]= dtmFirstPrintTime ;
				m_objLine2_9.m_ObjPrintLineInfo =objData2_9;

				///////////////2_10行/////////////////
				Object[] objData2_10=new object[3];
				objData2_10[0]=objclsInPatientOut.m_strIsNurseIssue;
                objData2_10[1] = m_mthGetValueWithoutDI(objclsInPatientOut.m_strNurseIssue,objclsInPatientOut.m_strNurseIssueXML);
				objData2_10[2]= dtmFirstPrintTime ;
				m_objLine2_10.m_ObjPrintLineInfo =objData2_10;

				///////////////2_11行/////////////////
				Object[] objData2_11=new object[2];
				objData2_11[0]=objclsInPatientOut.m_strCommonlyCoach;
				objData2_11[1]= dtmFirstPrintTime ;
				m_objLine2_11.m_ObjPrintLineInfo =objData2_11;

				///////////////2_12行/////////////////
				Object[] objData2_12=new object[2];
				objData2_12[0]=objclsInPatientOut.m_strAdviceDrug;
				objData2_12[1]= dtmFirstPrintTime ;
				m_objLine2_12.m_ObjPrintLineInfo =objData2_12;

				///////////////2_13行/////////////////
				Object[] objData2_13=new object[3];
				objData2_13[0]=objclsInPatientOut.m_strIsSpecialtiesCoach;
                objData2_13[1] = m_mthGetValueWithoutDI(objclsInPatientOut.m_strSpecialtiesCoach,objclsInPatientOut.m_strSpecialtiesCoachXML);
				objData2_13[2]= dtmFirstPrintTime ;
				m_objLine2_13.m_ObjPrintLineInfo =objData2_13;

				///////////////2_14行/////////////////
				Object[] objData2_14=new object[3];
				objData2_14[0]=new clsEmployee(objclsInPatientOut.m_strNurseSign_ID).m_StrFirstName.Trim();
				objData2_14[1]=new clsEmployee(objclsInPatientOut.m_strChargeNurse_ID).m_StrFirstName.Trim();
				objData2_14[2]= dtmFirstPrintTime ;
				m_objLine2_14.m_ObjPrintLineInfo =objData2_14;
				#endregion
			}
		}

		private void pdcOperation_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{ 
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("病 人 入 院 评 估 表",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
		}

		private void m_mthPrintTitleInfo_Health_Out(System.Drawing.Printing.PrintPageEventArgs e)
		{
            e.Graphics.DrawString("(病人健康教育评估表)", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).X, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).Y - 30);
			e.Graphics.DrawString("(病人出院评估及指导)",m_fotTitleFont,m_slbBrush,260,450);
		}
		#endregion

		#region print class 

		private class clsPrintLine1 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strDept;
			private string strBedID;
			private string strInPatientID;
			private string strHomeTown;
			private string strNation;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine1()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("科室",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+40,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+150,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("床号",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+155,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+195,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+240,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("住院号",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+245,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+300,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+380,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("籍贯",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+385,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+425,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+570,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("民族",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+580,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+620,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+720,p_intPosY +(int)enmRectangleInfo.RowStep);
                    //p_objGrp.DrawString("医疗保险", fntText, Brushes.Black, (int)enmRectangleInfo.LeftX + 625, p_intPosY);
                    //System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 695, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    //p_objGrp.DrawString("自费", fntText, Brushes.Black, (int)enmRectangleInfo.LeftX + 715, p_intPosY);
                    //System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 750, p_intPosY), System.Windows.Forms.ButtonState.Flat);


                    p_objGrp.DrawString(strDept, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 40, p_intPosY);
                    p_objGrp.DrawString(strBedID, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 195, p_intPosY);
                    p_objGrp.DrawString(strInPatientID, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 300, p_intPosY);
                    p_objGrp.DrawString(strHomeTown, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 425, p_intPosY);
                    p_objGrp.DrawString(strNation, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 620, p_intPosY);           

					fntText.Dispose();
					fntValueText.Dispose();  
					fntCheck.Dispose();
                     
					m_blnFirstPrint = false;
				}

				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+15;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;			
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
						dtmFirstPrint=(DateTime)objData[1];
						if(objData[0]==null)
						{
							strDept = "";
							strBedID = "";
							strInPatientID = "";
							strHomeTown ="" ;
							strNation = "";
						}	
						else
						{
							clsPrintInfo_InPatientEvaluate objPrintInfo = (clsPrintInfo_InPatientEvaluate)objData[0];	//传入对象从病人对象改变为打印信息对象.
							strDept = objPrintInfo.m_strDeptName;
							strBedID = objPrintInfo.m_strBedName;
							strHomeTown = objPrintInfo.m_strHometown;
							strInPatientID = objPrintInfo.m_strHISInPatientID;
							strNation = objPrintInfo.m_strNationnality;
							
						}	
						
					}
				}
			}
		}

        /// <summary>
        /// 姓名————文化程度
        /// </summary>
		private class clsPrintLine2 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			private string strPatientName;
            private string strPayMethod = "00";
			private string strSex;
			private string strAge;
			private string strOccupation;
			private string strEduDegree;
            private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2()
			{
                m_objCPaint = new clsPublicControlPaint();
			}

			private bool m_blnFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
                    Font fntCheck = new Font("SimSun", 18);

					p_objGrp.DrawString("姓名",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+40,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+130,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("性别",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+135,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+175,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+210,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("年龄",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+220,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+260,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+310,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("职业",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+315,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+355,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+440,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("文化程度",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+515,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+580,p_intPosY +(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("医疗保险", fntText, Brushes.Black, (int)enmRectangleInfo.LeftX + 585, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 655, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("自费", fntText, Brushes.Black, (int)enmRectangleInfo.LeftX + 675, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 710, p_intPosY), System.Windows.Forms.ButtonState.Flat);

					p_objGrp.DrawString(strPatientName,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+40,p_intPosY);
					p_objGrp.DrawString(strSex,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+195,p_intPosY);
					p_objGrp.DrawString(strAge,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY);
					p_objGrp.DrawString(strOccupation,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+375,p_intPosY);
					p_objGrp.DrawString(strEduDegree,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+535,p_intPosY);
                    if (strPayMethod[0].ToString() == "1")
                        p_objGrp.DrawString("√", fntCheck, Brushes.Black, (int)enmRectangleInfo.LeftX + 645, p_intPosY-8);
                    if (strPayMethod[1].ToString() == "1")
                        p_objGrp.DrawString("√", fntCheck, Brushes.Black, (int)enmRectangleInfo.LeftX + 700, p_intPosY-8);
					fntText.Dispose();
					fntValueText.Dispose();
                    fntCheck.Dispose();
					m_blnFirstPrint = false;
				}

				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+15;

			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						if(objData[0]==null)
						{
							strPatientName = "";
							strSex = "";
							strAge = "";
							strOccupation ="" ;
						}	
						else
						{
							clsPrintInfo_InPatientEvaluate objPrintInfo = (clsPrintInfo_InPatientEvaluate)objData[0];	//传入对象从病人对象改变为打印信息对象.
							strPatientName = objPrintInfo.m_strPatientName;
							strSex = objPrintInfo.m_strSex;
							strAge = objPrintInfo.m_strAge;
							strOccupation = objPrintInfo.m_strOccupation;
						}
						strEduDegree = objData[2].ToString();
                        strPayMethod = objData[3].ToString();
					}
				}
			}
		}
        /// <summary>
        /// 住址，入院时间
        /// </summary>
		private class clsPrintLine3 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			private string strHomeAddress;
			private string strInPatientDate;

			public clsPrintLine3()
			{
			
			}

			private bool m_blnFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("住址",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+40,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+420,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("入院时间",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+425,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+495,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+730,p_intPosY +(int)enmRectangleInfo.RowStep);

					p_objGrp.DrawString(strHomeAddress,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+40,p_intPosY);
					p_objGrp.DrawString(strInPatientDate,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+15;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						if(objData[0]==null)
						{
							strHomeAddress = "";
							strInPatientDate = "";
						}	
						else
						{
							clsPrintInfo_InPatientEvaluate objPrintInfo = (clsPrintInfo_InPatientEvaluate)objData[0];	//传入对象从病人对象改变为打印信息对象.
							strHomeAddress = objPrintInfo.m_strHomeAddress;
                            strInPatientDate = objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy年MM月dd日 HH时mm分");
						}					
					}
				}
			}
		}
        /// <summary>
        /// 入院方式————入院诊断
        /// </summary>
		private class clsPrintLine4 : clsPrintLineBase
		{
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strInHospitalMethod="000000";
            //private string strPayMethod = "00";
			private string strInHospitalDiagnose;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine4()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("入院方式: 步行",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("扶行",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+140,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +180,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("轮椅",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+200,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +240,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("平车",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+260,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +300,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("背",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+320,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +340,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("抱入",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+360,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +400,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("入院诊断",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+425,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+495,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+730,p_intPosY +(int)enmRectangleInfo.RowStep);
                    

                    //if (strPayMethod[0].ToString() == "1")
                    //    p_objGrp.DrawString("√", fntCheck, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY - 8);
                    //if (strPayMethod[1].ToString() == "1")
                    //    p_objGrp.DrawString("√", fntCheck, Brushes.Black, (int)enmRectangleInfo.LeftX + 115, p_intPosY - 8);
					if(strInHospitalMethod[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strInHospitalMethod[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY-8);
					if(strInHospitalMethod[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-8); 
					if(strInHospitalMethod[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+290,p_intPosY-8); 
					if(strInHospitalMethod[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+330,p_intPosY-8); 
					if(strInHospitalMethod[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+390,p_intPosY-8); 
					p_objGrp.DrawString(strInHospitalDiagnose,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+495,p_intPosY,255,(int)enmRectangleInfo.RowStep+15),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY +=(int)enmRectangleInfo.RowStep + 15;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strInHospitalMethod = objData[0].ToString();
						strInHospitalDiagnose = objData[1].ToString();				
					}
				}
			}
		}
        /// <summary>
        /// 既往史，家族史
        /// </summary>
		private class clsPrintLine5 : clsPrintLineBase
		{
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strCaseHistory;
			private string strFamilyHistory;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine5()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					p_objGrp.DrawString("既往史:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+60,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+440,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("家族史:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY);
					//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+495,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+770,p_intPosY +(int)enmRectangleInfo.RowStep);

					p_objGrp.DrawString(strCaseHistory,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+55,p_intPosY,380,(int)enmRectangleInfo.RowStep+15),m_sfmPrint);
					p_objGrp.DrawString(strFamilyHistory,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+505,p_intPosY,255,(int)enmRectangleInfo.RowStep+15),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*(int)enmRectangleInfo.RowStep+15;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strCaseHistory = objData[0].ToString();
						strFamilyHistory = objData[1].ToString();				
					}
				}
			}
		}

		private class clsPrintLine6 : clsPrintLineBase
		{       			
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			
			private string strChiefComplain;

			private bool m_blnFirstPrint = true;

			public clsPrintLine6()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					p_objGrp.DrawString("主诉(症状与体征):",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					
					p_objGrp.DrawString("                   "+strChiefComplain,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX,p_intPosY,750,2*((int)enmRectangleInfo.RowStep+10)),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strChiefComplain = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine7 : clsPrintLineBase
		{	  
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strSensitiveHistory="0000";
			private string strSensitiveHistoryOther;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine7()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("药物过敏史:  无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +125,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("青霉素",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+150,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +205,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("链霉素",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +285,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("磺胺类",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+310,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +365,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+400,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+440,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+730,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strSensitiveHistory[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+115,p_intPosY-8); 
					if(strSensitiveHistory[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+195,p_intPosY-8);
					if(strSensitiveHistory[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+275,p_intPosY-8); 
					if(strSensitiveHistory[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+355,p_intPosY-8);
					p_objGrp.DrawString(strSensitiveHistoryOther,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+440,p_intPosY,330,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);
					
					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strSensitiveHistory = objData[0].ToString();
						strSensitiveHistoryOther = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine8 : clsPrintLineBase
		{
			private bool m_blnFirstPrint = true;
			public clsPrintLine8()
			{
				
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					p_objGrp.DrawString("一、体格检查",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);

					fntText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+6;
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
			}
		}

		private class clsPrintLine9 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strTempr;
			private string strPulse;
			private string strRhythm;
			private string strBP_shink;
			private string strBP_Extend;
			private string strAvoi;
            private string strShengao;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine9()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("T",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+55,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("℃    P",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+60,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+115,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+155,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("次/分    R",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+160,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+250,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+295,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("次/分    Bp",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+300,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+390,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+430,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("/",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+435,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+485,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("mmHg    体重",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+470,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+565,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+600,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("kg 身高",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+600,p_intPosY);

                    p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 655, p_intPosY + (int)enmRectangleInfo.RowStep, (int)enmRectangleInfo.LeftX + 685, p_intPosY + (int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("cm", fntText, Brushes.Black, (int)enmRectangleInfo.LeftX + 695, p_intPosY);


					p_objGrp.DrawString(strTempr,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY);
					p_objGrp.DrawString(strPulse,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+115,p_intPosY);
					p_objGrp.DrawString(strRhythm,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+250,p_intPosY);
					p_objGrp.DrawString(strBP_shink,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+390,p_intPosY);
					p_objGrp.DrawString(strBP_Extend,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY);
					p_objGrp.DrawString(strAvoi,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+565,p_intPosY);
                    p_objGrp.DrawString(strShengao, fntValueText, Brushes.Black, (int)enmRectangleInfo.LeftX + 655, p_intPosY);
					
					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[6];
						strTempr = objData[0].ToString();
						strPulse = objData[1].ToString();
						strRhythm = objData[2].ToString();
						strBP_shink = objData[3].ToString();
						strBP_Extend = objData[4].ToString();
						strAvoi = objData[5].ToString();
                        strShengao = objData[7].ToString();
					}
				}
			}
		}

		private class clsPrintLine10 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strConsciousness="00000";
			private string strComplexion="0000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine10()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("意识状态:  清醒",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("模糊",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+150,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +185,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("嗜睡",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+215,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +250,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("谵妄",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +315,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("昏迷",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+345,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +380,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					p_objGrp.DrawString("面色: 正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+435,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +515,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("潮红",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+545,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +580,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("苍白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+610,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +645,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("黄染",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+675,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +710,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strConsciousness[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strConsciousness[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+175,p_intPosY-8);
					if(strConsciousness[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+240,p_intPosY-8); 
					if(strConsciousness[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+305,p_intPosY-8);
					if(strConsciousness[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+370,p_intPosY-8);

					if(strComplexion[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+505,p_intPosY-8); 
					if(strComplexion[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+570,p_intPosY-8);
					if(strComplexion[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+635,p_intPosY-8); 
					if(strComplexion[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+700,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strConsciousness = objData[0].ToString();
						strComplexion = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine11 : clsPrintLineBase
		{
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strPhysique="000";
			private string strPhysiqueOther;
			private string strEmotion="000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine11()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("体    形:  一般",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("消瘦",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+150,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +185,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("肥胖",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+215,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +250,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+320,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+400,p_intPosY +(int)enmRectangleInfo.RowStep);

					p_objGrp.DrawString("情绪: 正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+435,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +515,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("淡漠",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+545,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +580,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("痛苦面容",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+610,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +680,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strPhysique[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strPhysique[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+175,p_intPosY-8);
					if(strPhysique[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+240,p_intPosY-8);
					p_objGrp.DrawString(strPhysiqueOther,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+320,p_intPosY,90,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);

					if(strEmotion[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+505,p_intPosY-8); 
					if(strEmotion[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+570,p_intPosY-8);
					if(strEmotion[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+670,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strPhysique = objData[0].ToString();
						strPhysiqueOther = objData[1].ToString();
						strEmotion = objData[3].ToString();
					}
				}
			}
		}

		private class clsPrintLine12 : clsPrintLineBase
		{
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strSkin="000000000";
			private string strSkinOther;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine12()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("皮    肤:  正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("潮红",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +180,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("苍白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+205,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +240,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("发绀",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+265,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +300,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("黄染",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+325,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +360,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("消肿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+385,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +420,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("失水",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +480,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("疖肿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+505,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +540,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("皮疹",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+565,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +600,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+625,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+660,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+730,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strSkin[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strSkin[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY-8);
					if(strSkin[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-8);
					if(strSkin[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+290,p_intPosY-8); 
					if(strSkin[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,p_intPosY-8);
					if(strSkin[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+410,p_intPosY-8);
					if(strSkin[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+470,p_intPosY-8); 
					if(strSkin[7].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+530,p_intPosY-8);
					if(strSkin[8].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY-8);
					p_objGrp.DrawString(strSkinOther,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+660,p_intPosY,90,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strSkin = objData[0].ToString();
						strSkinOther = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine13 : clsPrintLineBase
		{
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;
			
			private string strLimbsactivity="0000000";
			private string strLimbsactivityOther;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine13()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("四肢活动:  自如",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("障碍",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +180,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("(进食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+205,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +245,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("洗漱",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+268,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +303,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("排泄",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+328,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +363,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString(")",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+375,p_intPosY);
					p_objGrp.DrawString("偏瘫",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+390,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +425,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("畸形",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+450,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +485,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+510,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+545,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+730,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strLimbsactivity[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strLimbsactivity[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY-8);
					if(strLimbsactivity[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY-8);
					if(strLimbsactivity[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+293,p_intPosY-8); 
					if(strLimbsactivity[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+353,p_intPosY-8);
					if(strLimbsactivity[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+415,p_intPosY-8);
					if(strLimbsactivity[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+475,p_intPosY-8); 
					p_objGrp.DrawString(strLimbsactivityOther,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+545,p_intPosY,205,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+10;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strLimbsactivity = objData[0].ToString();
						strLimbsactivityOther = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine14 : clsPrintLineBase
		{
			private bool m_blnFirstPrint = true;
			public clsPrintLine14()
			{
				
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					p_objGrp.DrawString("二、生活状况及自理程度",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);

					fntText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+6;
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
			}
		}

		private class clsPrintLine15 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strBitsup="0000000000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine15()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("饮食: 普食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +78,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("半流",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +130,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("全流",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+152,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +187,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("鼻饲",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+209,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +244,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("禁食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+266,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +301,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("治疗饮食(低盐",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+336,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +441,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("低脂",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+463,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +498,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("低胆固醇",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +590,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("低糖",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+612,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +647,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("高蛋白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+669,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +721,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString(")",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+739,p_intPosY);

					if(strBitsup[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+68,p_intPosY-8); 
					if(strBitsup[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+120,p_intPosY-8);
					if(strBitsup[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+177,p_intPosY-8);
					if(strBitsup[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+234,p_intPosY-8); 
					if(strBitsup[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+291,p_intPosY-8);
					if(strBitsup[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+429,p_intPosY-8);
					if(strBitsup[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+486,p_intPosY-8);
					if(strBitsup[7].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+580,p_intPosY-8);
					if(strBitsup[8].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+637,p_intPosY-8);
					if(strBitsup[9].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+711,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strBitsup = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine16 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strAppetite="000000";
			private string strSleep = "00000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine16()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("食欲: 正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +78,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("增加",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +130,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("亢进",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+152,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +187,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("下降",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+204,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +239,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("厌食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+256,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +291,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+308,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +328,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("睡眠:正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+355,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +430,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("入睡困难",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+446,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +512,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("易多梦",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+525,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +576,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("失眠",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +625,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("需用药入睡",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+642,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +723,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strAppetite[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+68,p_intPosY-8); 
					if(strAppetite[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+120,p_intPosY-8);
					if(strAppetite[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+177,p_intPosY-8);
					if(strAppetite[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+229,p_intPosY-8); 
					if(strAppetite[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+281,p_intPosY-8);
					if(strAppetite[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+318,p_intPosY-8);
					if(strSleep[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+420,p_intPosY-8);
					if(strSleep[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+502,p_intPosY-8);
					if(strSleep[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+566,p_intPosY-8);
					if(strSleep[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+615,p_intPosY-8);
					if(strSleep[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+713,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strAppetite = objData[0].ToString();
						strSleep = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine17 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strStool="0";
			private string strAstriction;
			private string strDiarrhea;
			private string strStool_Other;
			private clsPublicControlPaint m_objCPaint;

			string strAstrictionTimes;
			string strAstrictionDays;
			string strDiarrheaTimes;
			string strDiarrheaDays;
	

			private bool m_blnFirstPrint = true;

			public clsPrintLine17()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(strAstriction == null)
				{
					strAstrictionTimes = "";
					strAstrictionDays = "";
				}
				else
				{
					string [] split = strAstriction.Split(new Char [] {'次'},2);
					strAstrictionTimes = split[0];
					strAstrictionDays = split[1];
				}
				if(strDiarrhea == null)
				{
					strDiarrheaTimes = "";
					strDiarrheaDays = "";
				}
				else
				{
					string [] split1 = strDiarrhea.Split(new Char [] {'次'},2);
					strDiarrheaTimes = split1[0];
					strDiarrheaDays = split1[1];
				}
				
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18); 

					p_objGrp.DrawString("排泄:  大便正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("便秘",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+150,p_intPosY);
					p_objGrp.DrawString("次/",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+220,p_intPosY);
					p_objGrp.DrawString("天；  腹泻",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY);
					p_objGrp.DrawString("次/",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+390,p_intPosY);
					p_objGrp.DrawString("天；  其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+450,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+530,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+650,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strStool.Trim() == "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8);
					p_objGrp.DrawString(strAstrictionTimes,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+190,p_intPosY);
					p_objGrp.DrawString(strAstrictionDays,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+250,p_intPosY);
					p_objGrp.DrawString(strDiarrheaTimes,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+360,p_intPosY);
					p_objGrp.DrawString(strDiarrheaDays,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+420,p_intPosY);
					p_objGrp.DrawString(strStool_Other,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+530,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[4];
						strStool = objData[0].ToString();
						strAstriction = objData[1].ToString();
						strDiarrhea = objData[2].ToString();
						strStool_Other = objData[3].ToString();
					}
				}
			}
		}

		private class clsPrintLine18 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strPee="0000000000";
			private clsPublicControlPaint m_objCPaint;
	

			private bool m_blnFirstPrint = true;

			public clsPrintLine18()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);
				   
					p_objGrp.DrawString("       小便正常",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿频",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +180,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿急",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+205,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +240,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿痛",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+265,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +300,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("血尿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+325,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +360,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("多尿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+385,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +420,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("少尿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+445,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +480,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿潴留",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+505,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +555,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿失禁",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+580,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +630,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("尿管",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+655,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +690,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strPee[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strPee[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY-8);
					if(strPee[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-8);
					if(strPee[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+290,p_intPosY-8); 
					if(strPee[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,p_intPosY-8);
					if(strPee[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+410,p_intPosY-8);
					if(strPee[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+470,p_intPosY-8);
					if(strPee[7].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+545,p_intPosY-8);
					if(strPee[8].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+620,p_intPosY-8);
					if(strPee[9].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+680,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strPee = objData[0].ToString(); 
					}
				}
			}
		}

		private class clsPrintLine19 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strHobby="00000";
			private string strHobbyOther;
			private string strSelfSolve="000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine19()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("嗜好:无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +63,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("烟",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+83,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +103,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("酒",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+123,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +143,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("甜食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+163,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +198,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("咸食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+218,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +253,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+273,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+308,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+410,p_intPosY +(int)enmRectangleInfo.RowStep);
					p_objGrp.DrawString("生活自理能力:自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+420,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +560,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("半自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+580,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +632,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("不能自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+657,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +727,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strHobby[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+53,p_intPosY-8); 
					if(strHobby[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+93,p_intPosY-8);
					if(strHobby[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+133,p_intPosY-8);
					if(strHobby[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+188,p_intPosY-8);
					if(strHobby[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+243,p_intPosY-8);
					p_objGrp.DrawString(strHobbyOther,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+308,p_intPosY);
					if(strSelfSolve[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+550,p_intPosY-8);
					if(strSelfSolve[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+622,p_intPosY-8);
					if(strSelfSolve[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+717,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+10;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strHobby = objData[0].ToString();
						strHobbyOther = objData[1].ToString();
						strSelfSolve = objData[3].ToString();
					}
				}
			}
		}

		private class clsPrintLine20 : clsPrintLineBase
		{
			private bool m_blnFirstPrint = true;
			public clsPrintLine20()
			{
				
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					p_objGrp.DrawString("三、心理社会方面",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);

					fntText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+10;
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
			}
		}

		private class clsPrintLine21 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strFeeling="000000000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine21()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("情    绪:  稳定",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +120,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("易激动",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +200,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("焦虑",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+225,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +260,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("恐惧",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+285,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +320,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("孤独无助感",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+345,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +425,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("压抑",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+450,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +485,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("悲哀",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +555,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("开朗",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+580,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +615,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+640,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +660,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strFeeling[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY-8); 
					if(strFeeling[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+190,p_intPosY-8);
					if(strFeeling[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+250,p_intPosY-8);
					if(strFeeling[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+310,p_intPosY-8);
					if(strFeeling[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+415,p_intPosY-8);
					if(strFeeling[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+475,p_intPosY-8);
					if(strFeeling[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+545,p_intPosY-8);
					if(strFeeling[7].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+605,p_intPosY-8);
					if(strFeeling[8].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+650,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strFeeling = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine22 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strJob="0000000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine22()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("就业状态:  固定职业",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +155,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("短期丧失劳动力",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+180,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +295,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("长期丧失劳动力",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+320,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +435,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("失业",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+460,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +495,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无职业",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +575,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("退休",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+610,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +645,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("个体户",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+670,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +725,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strJob[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY-8); 
					if(strJob[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+285,p_intPosY-8);
					if(strJob[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+425,p_intPosY-8);
					if(strJob[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+485,p_intPosY-8);
					if(strJob[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+565,p_intPosY-8);
					if(strJob[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+635,p_intPosY-8);
					if(strJob[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+715,p_intPosY-8);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strJob = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine23 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strInHospitalWorry="000";
			private string strInHospitalWorryOther;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine23()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("住院顾虑:  无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +105,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("经济困难",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+130,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +200,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("疾病预后",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+225,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +295,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+320,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+355,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+700,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strInHospitalWorry[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY-8); 
					if(strInHospitalWorry[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+190,p_intPosY-8);
					if(strInHospitalWorry[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+285,p_intPosY-8);
					p_objGrp.DrawString(strInHospitalWorryOther,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+355,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strInHospitalWorry = objData[0].ToString();
						strInHospitalWorryOther = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine24 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strFamilyForm="0000";
			private string strFamilyFormOther;
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine24()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("家庭同住人口构成:  父母",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +180,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("独居",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+205,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +240,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("配偶",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+265,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +300,p_intPosY),System.Windows.Forms.ButtonState.Flat); 
					p_objGrp.DrawString("子女",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+325,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +360,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("其它",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+385,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+420,p_intPosY +(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.LeftX+700,p_intPosY +(int)enmRectangleInfo.RowStep);

					if(strFamilyForm[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY-8); 
					if(strFamilyForm[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-8);
					if(strFamilyForm[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+290,p_intPosY-8);  
					if(strFamilyForm[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,p_intPosY-8);
					p_objGrp.DrawString(strFamilyFormOther,fntValueText ,Brushes.Black,(int)enmRectangleInfo.LeftX+420,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strFamilyForm = objData[0].ToString();
						strFamilyFormOther = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine25 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strHealthNeed="00000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine25()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);
					p_objGrp.DrawString("家庭对患者的健康需要:  能满足",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +230,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("不能满足",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+255,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +325,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("忽视",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+350,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +385,p_intPosY),System.Windows.Forms.ButtonState.Flat); 
					p_objGrp.DrawString("寻求帮助",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+410,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +480,p_intPosY),System.Windows.Forms.ButtonState.Flat);  
					p_objGrp.DrawString("过于关心",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+505,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +575,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strHealthNeed[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+220,p_intPosY-8); 
					if(strHealthNeed[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+315,p_intPosY-8);
					if(strHealthNeed[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+375,p_intPosY-8);  
					if(strHealthNeed[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+470,p_intPosY-8);  
					if(strHealthNeed[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+565,p_intPosY-8);


					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strHealthNeed = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine26 : clsPrintLineBase
		{
			private DateTime dtmFirstPrint;
			
			private string strKnowDiease="0000";
			private clsPublicControlPaint m_objCPaint;
		

			private bool m_blnFirstPrint = true;

			public clsPrintLine26()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("对疾病的认识:  明白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +155,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("一知半解",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+180,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +250,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("不知",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+275,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +310,p_intPosY),System.Windows.Forms.ButtonState.Flat); 
					p_objGrp.DrawString("基本清楚",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+335,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +405,p_intPosY),System.Windows.Forms.ButtonState.Flat);

					if(strKnowDiease[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+145,p_intPosY-8); 
					if(strKnowDiease[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+240,p_intPosY-8);
					if(strKnowDiease[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+300,p_intPosY-8);  
					if(strKnowDiease[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+395,p_intPosY-8); 

					fntText.Dispose();
					fntValueText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+10;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strKnowDiease = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine27 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string strSpecilizedCheck;

			private bool m_blnFirstPrint = true;

			public clsPrintLine27()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					p_objGrp.DrawString("专科检查:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
							           
					p_objGrp.DrawString("          "+strSpecilizedCheck,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX,p_intPosY,790,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+10;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strSpecilizedCheck = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine28 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string strPipInstance;

			private bool m_blnFirstPrint = true;

			public clsPrintLine28()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("各种导管情况:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
							           
					p_objGrp.DrawString("               "+strPipInstance,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX,p_intPosY,790,2*((int)enmRectangleInfo.RowStep)),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+10;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strPipInstance = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine29 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string strWoodInstance;

			private bool m_blnFirstPrint = true;

			public clsPrintLine29()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("伤口情况:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
							           
					p_objGrp.DrawString("          "+strWoodInstance,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX,p_intPosY,790,2*((int)enmRectangleInfo.RowStep)+10),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep+10)+8;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strWoodInstance = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine30 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string strTentPlan;

			private bool m_blnFirstPrint = true;

			public clsPrintLine30()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("实施护理计划:",fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX,p_intPosY);
							           
					p_objGrp.DrawString("              "+strTentPlan,fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX,p_intPosY,790,3*((int)enmRectangleInfo.RowStep)+10),m_sfmPrint);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep+10);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strTentPlan = objData[0].ToString();				
					}
				}
			}
		}
        /// <summary>
        /// 负责护士签名
        /// </summary>
		private class clsPrintLine31 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string strNurse = "";

			private bool m_blnFirstPrint = true;

			public clsPrintLine31()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",12);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("负责护士签名："+strNurse,fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+1000;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strNurse = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine2_1 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string  strWriterFormDate;

			private bool m_blnFirstPrint = true;

			public clsPrintLine2_1()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				p_intPosY = 70;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",12);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString(strWriterFormDate,fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+600,p_intPosY);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						DateTime dtmTemp = (DateTime)objData[0];
						strWriterFormDate = dtmTemp.ToString("yyyy年MM月dd日");				
					}
				}
			}
        }

        #region 健康教育评估
        private class clsPrintLine2_2 : clsPrintLineBase
		{ 
			private bool m_blnFirstPrint = true;

			public clsPrintLine2_2()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
					p_objGrp.DrawString("教育项目",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+23,p_intPosY+12);

					p_objGrp.DrawString("第一次完成",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY+2);
					p_objGrp.DrawString("教育项目",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+105,p_intPosY+20);
					p_objGrp.DrawString("护士签名",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY+20);
					p_objGrp.DrawString(" 日  期",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY+20);

					p_objGrp.DrawString("第二次完成",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+380,p_intPosY+2);
					p_objGrp.DrawString("教育项目",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+302,p_intPosY+20);
					p_objGrp.DrawString("护士签名",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+370,p_intPosY+20);
					p_objGrp.DrawString(" 日  期",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+438,p_intPosY+20);

					p_objGrp.DrawString("第三次完成",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+595,p_intPosY+2);
					p_objGrp.DrawString("教育项目",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY+20);
					p_objGrp.DrawString("护士签名",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY+20);
					p_objGrp.DrawString(" 日  期",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+660,p_intPosY+20);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+38,(int)enmRectangleInfo.RightX,p_intPosY+38);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY,(int)enmRectangleInfo.LeftX+15,p_intPosY+304);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+105,p_intPosY,(int)enmRectangleInfo.LeftX+105,p_intPosY+304);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+170,p_intPosY+38,(int)enmRectangleInfo.LeftX+170,p_intPosY+304);					
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+228,p_intPosY+38,(int)enmRectangleInfo.LeftX+228,p_intPosY+304);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+302,p_intPosY,(int)enmRectangleInfo.LeftX+302,p_intPosY+304);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+370,p_intPosY+38,(int)enmRectangleInfo.LeftX+370,p_intPosY+304);					
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+436,p_intPosY+38,(int)enmRectangleInfo.LeftX+436,p_intPosY+304);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+304);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY+38,(int)enmRectangleInfo.LeftX+590,p_intPosY+304);					
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+657,p_intPosY+38,(int)enmRectangleInfo.LeftX+657,p_intPosY+304);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+304);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+2;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
			}
		}

		private class clsPrintLine2_3 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private XmlParserContext m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Default);
			private DateTime dtmFirstPrint;	
			private string  strEDU_First;
			private string strEDU_Second;
			private string strEDU_Third;

			private bool m_blnFirstPrint = true;

			public clsPrintLine2_3()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				ArrayList arrList1 = new ArrayList();
				m_mthXMLToForm(out arrList1,strEDU_First);
				ArrayList arrList2 = new ArrayList();
				m_mthXMLToForm(out arrList2,strEDU_Second);
				ArrayList arrList3 = new ArrayList();
				m_mthXMLToForm(out arrList3,strEDU_Third);

				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("1.入院宣教",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+17,p_intPosY+12);
					p_objGrp.DrawString(arrList1[0].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+2,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[1].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+2,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[2].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+2,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[0].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+2,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[1].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+2,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[2].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+2,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[0].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+2,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[1].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+2,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[2].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+2,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+38,(int)enmRectangleInfo.RightX,p_intPosY+38);

					p_objGrp.DrawString("2.检查前解释与交代",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+40,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[3].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+40,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[4].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+40,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[5].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+40,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[3].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+40,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[4].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+40,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[5].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+40,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[3].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+40,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[4].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+40,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[5].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+40,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+76,(int)enmRectangleInfo.RightX,p_intPosY+76);

					p_objGrp.DrawString("3.主要药物的服用方法",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+78,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[6].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+78,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[7].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+78,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[8].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+78,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[6].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+78,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[7].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+78,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[8].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+78,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[6].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+78,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[7].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+78,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[8].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+78,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+114,(int)enmRectangleInfo.RightX,p_intPosY+114);

					p_objGrp.DrawString("4.手术前后的注意事项",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+116,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[9].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+116,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[10].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+116,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[11].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+116,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[9].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+116,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[10].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+116,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[11].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+116,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[9].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+116,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[10].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+116,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[11].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+116,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+152,(int)enmRectangleInfo.RightX,p_intPosY+152);

					p_objGrp.DrawString("5.饮食、疾病有关知识",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+154,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[12].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+154,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[13].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+154,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[14].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+154,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[12].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+154,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[13].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+154,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[14].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+154,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[12].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+154,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[13].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+154,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[14].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+154,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+190,(int)enmRectangleInfo.RightX,p_intPosY+190);

					p_objGrp.DrawString("6.康复指导、家属指导",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+192,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[15].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+192,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[16].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+192,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[17].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+192,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[15].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+192,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[16].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+192,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[17].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+192,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[15].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+192,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[16].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+192,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[17].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+192,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+228,(int)enmRectangleInfo.RightX,p_intPosY+228);

					p_objGrp.DrawString("7.其他",fntText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+240,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[18].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+105,p_intPosY+230,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[19].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+170,p_intPosY+230,72,38),m_sfmPrint);
					p_objGrp.DrawString(arrList1[20].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+228,p_intPosY+230,90,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[18].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+304,p_intPosY+230,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[19].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+373,p_intPosY+230,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList2[20].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+434,p_intPosY+230,100,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[18].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+520,p_intPosY+230,75,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[19].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+590,p_intPosY+230,77,38),m_sfmPrint);
					p_objGrp.DrawString(arrList3[20].ToString(),fntValueText ,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+655,p_intPosY+230,90,38),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+266,(int)enmRectangleInfo.RightX,p_intPosY+266);

					p_objGrp.DrawString("注:1.根据病人的需要及住院时间可分阶段完成，每次不宜过多内容。并在相应项目用V标识。",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+17,p_intPosY+272);
					p_objGrp.DrawString("   2.具体的教育内容可以记录于护理记录单上，护长、组长检查。",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+17,p_intPosY+290);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 290;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[3];
						strEDU_First = objData[0].ToString();
						strEDU_Second = objData[1].ToString();
						strEDU_Third = objData[2].ToString();
					}
				}
			}  

			#region 对病人健康教育评估表数据处理
			private void m_mthXMLToForm(out ArrayList arrL,string strDate)
			{	
				arrL = new ArrayList();
				if(strDate == null)
				{
					for(int i=0; i<21; i++)
					{
						arrL.Add("");
					}
					return;
				}
				XmlTextReader objReader = new XmlTextReader(strDate,XmlNodeType.Element,m_objXmlParser);

				while (objReader.Read())
				{
					if (objReader.IsStartElement())
					{
						if (objReader.IsEmptyElement)
							arrL.Add("");
							//						break;
						else
						{
							if(objReader.Name == "eduitem")
								arrL.Add(objReader.ReadString());
							if(objReader.Name == "nursesign")
								arrL.Add(objReader.ReadString());
							if(objReader.Name == "date")
								arrL.Add(objReader.ReadString());
						}
					}
				}
			}
			#endregion
        }

        #endregion 

        /// <summary>
        /// 住院天数
        /// </summary>
		private class clsPrintLine2_4 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string  strInHospitalDays;

			private bool m_blnFirstPrint = true;

			public clsPrintLine2_4()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				p_intPosY = 450;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("住院( "+strInHospitalDays+" )天",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+620,p_intPosY+18);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strInHospitalDays = objData[0].ToString();				
					}
				}
			}
        }

        #region 病人出院评估及指导
        private class clsPrintLine2_5 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strInHospitalDiagnose="";
			private int intStrLength = 0;

			private bool m_blnFirstPrint = true;

			public clsPrintLine2_5()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",13);
					Font fntValueText = new Font("SimSun",10);

					if(strInHospitalDiagnose.Length > 94)
						intStrLength = p_intPosY+2;
					else
						intStrLength = p_intPosY+15;

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
					p_objGrp.DrawString("出院诊断:",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+20,p_intPosY+15);
					p_objGrp.DrawString(strInHospitalDiagnose,fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+100,intStrLength,686,60),m_sfmPrint);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+50,(int)enmRectangleInfo.RightX,p_intPosY+50);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+20;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strInHospitalDiagnose = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine2_6 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string  strLiveAbility = "000";

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_6()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("生活能力:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY+12);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +150,p_intPosY+12),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+165,p_intPosY+12);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +220,p_intPosY+12),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("部分自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY+12);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +325,p_intPosY+12),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("不能自理",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+340,p_intPosY+12);

					if(strLiveAbility[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+140,p_intPosY+4);
					if(strLiveAbility[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY+4);
					if(strLiveAbility[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+315,p_intPosY+4);

					fntText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+12;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strLiveAbility = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine2_7 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strDieteticCircs = "0000000";

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_7()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					m_sfmPrint.Alignment = StringAlignment.Near;
					Font fntText = new Font("SimSun",11);
					Font fntCheck = new Font("SimSun",18);
					Font fntTitle = new Font("SimSun",12);

					p_objGrp.DrawString("饮食状况:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +150,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("普食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+165,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +220,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("软食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +290,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("治疗饮食",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+305,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +395,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("鼻饲",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+410,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +465,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("少吃多餐",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+480,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +570,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("自流",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+585,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +640,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("全流",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+655,p_intPosY);

					if(strDieteticCircs[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+140,p_intPosY-8);
					if(strDieteticCircs[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY-8);
					if(strDieteticCircs[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY-8);
					if(strDieteticCircs[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+385,p_intPosY-8);
					if(strDieteticCircs[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+455,p_intPosY-8);
					if(strDieteticCircs[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+560,p_intPosY-8);
					if(strDieteticCircs[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+630,p_intPosY-8);

					p_objGrp.DrawString("出院病人护理评价",fntTitle,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY+15,40,100),m_sfmPrint);

					fntText.Dispose();
					fntCheck.Dispose();
					fntTitle.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strDieteticCircs = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine2_8 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string  strOutHospitalMode = "00000";

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_8()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("出院方式:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +150,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("步行",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+165,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +220,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("轮椅",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +290,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("平车",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+305,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +360,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("抱婴儿",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+375,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +450,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("拐杖",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+465,p_intPosY);

					if(strOutHospitalMode[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+140,p_intPosY-8);
					if(strOutHospitalMode[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY-8);
					if(strOutHospitalMode[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY-8);
					if(strOutHospitalMode[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,p_intPosY-8);
					if(strOutHospitalMode[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+440,p_intPosY-8);

					fntText.Dispose();
					fntCheck.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strOutHospitalMode = objData[0].ToString();				
					}
				}
			}
		}

		private class clsPrintLine2_9 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strIsNurseSym = "00";
			private string strNurseSym;

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_9()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("护理并发症:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +170,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+185,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +220,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("有:",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+265,p_intPosY+(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.RightX-30,p_intPosY+(int)enmRectangleInfo.RowStep);

					if(strIsNurseSym[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+160,p_intPosY-8);
					if(strIsNurseSym[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY-8);
					p_objGrp.DrawString(strNurseSym,fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+265,p_intPosY,490,38),m_sfmPrint);

					fntText.Dispose();
					fntCheck.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strIsNurseSym = objData[0].ToString();
						strNurseSym = objData[1].ToString();
					}
				}
			}
		}

		private class clsPrintLine2_10 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strIsNurseIssue = "00";
			private string strNurseIssue;

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_10()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("现存或潜在的护理问题:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +240,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+255,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +290,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("有:",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+305,p_intPosY);
					//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+335,p_intPosY+(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.RightX-30,p_intPosY+(int)enmRectangleInfo.RowStep);

					if(strIsNurseIssue[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-8);
					if(strIsNurseIssue[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY-8);
					p_objGrp.DrawString(strNurseIssue,fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+335,p_intPosY,410,38),m_sfmPrint);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+(int)enmRectangleInfo.RowStep+20,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.RowStep+20);

					fntText.Dispose();
					fntCheck.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep)+20;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strIsNurseIssue = objData[0].ToString();
						strNurseIssue = objData[1].ToString();
					}
				}
			}
        }

        #region 出院病人健康指导
        private class clsPrintLine2_11 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strCommonlyCoach = "00000000";

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_11()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",12);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("一、一般指导",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					p_intPosY += 40;
					p_objGrp.DrawString("1.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +80,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("休养环境应清洁舒适，保持室内空气新鲜",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					p_objGrp.DrawString("2.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+485,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +500,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("稳定情绪有利健康",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+515,p_intPosY);
					if(strCommonlyCoach[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+70,p_intPosY-8);
					if(strCommonlyCoach[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+490,p_intPosY-8);

					p_intPosY += 36;
					p_objGrp.DrawString("3.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +80,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("根据自身情况适当锻炼，增强体质",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					p_objGrp.DrawString("4.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+485,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +500,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("注重营养饮食，有利机体康复",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+515,p_intPosY);
					if(strCommonlyCoach[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+70,p_intPosY-8);
					if(strCommonlyCoach[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+490,p_intPosY-8);

					p_objGrp.DrawString("出院",fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY-20,40,20),m_sfmPrint);

					p_intPosY += 36;
					p_objGrp.DrawString("5.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +80,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("按医生预约时间复诊",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					p_objGrp.DrawString("6.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+485,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +500,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("如有不适随时就诊",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+515,p_intPosY);
					if(strCommonlyCoach[4].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+70,p_intPosY-8);
					if(strCommonlyCoach[5].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+490,p_intPosY-8);

					p_objGrp.DrawString("病人",fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY-20,40,20),m_sfmPrint);

					p_intPosY += 36;
					p_objGrp.DrawString("7.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +80,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("适当休息，避免刺激性活动",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+95,p_intPosY);
					p_objGrp.DrawString("8.",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+485,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +500,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("按时服药",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+515,p_intPosY);
					if(strCommonlyCoach[6].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+70,p_intPosY-8);
					if(strCommonlyCoach[7].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+490,p_intPosY-8);

					p_objGrp.DrawString("健康",fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY-20,40,20),m_sfmPrint);

					fntText.Dispose();
					fntCheck.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strCommonlyCoach = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine2_12 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strAdviceDrug = "0000";

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_12()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntCheck = new Font("SimSun",18);
					Font fntValueText = new Font("SimSun",12);

					p_objGrp.DrawString("二、按医嘱用药:  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +195,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("明白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +265,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("不明白",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +355,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("交待家属",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+370,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +460,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无药",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+475,p_intPosY);

					if(strAdviceDrug[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+185,p_intPosY-8);
					if(strAdviceDrug[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+255,p_intPosY-8);
					if(strAdviceDrug[2].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+345,p_intPosY-8);
					if(strAdviceDrug[3].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+450,p_intPosY-8);

					p_objGrp.DrawString("指导",fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+17,p_intPosY-20,40,20),m_sfmPrint);

					fntText.Dispose();
					fntCheck.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[1];
						strAdviceDrug = objData[0].ToString();
					}
				}
			}
		}

		private class clsPrintLine2_13 : clsPrintLineBase
		{ 
			private StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
			private DateTime dtmFirstPrint;	
			private string  strIsSpecialtiesCoach = "00";
			private string strSpecialtiesCoach;

			private bool m_blnFirstPrint = true;
			private clsPublicControlPaint m_objCPaint;

			public clsPrintLine2_13()
			{
				m_objCPaint=new clsPublicControlPaint();
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				m_sfmPrint.Alignment = StringAlignment.Near;
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",11);
					Font fntValueText = new Font("SimSun",10);
					Font fntCheck = new Font("SimSun",18);

					p_objGrp.DrawString("三、专科指导  ",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+65,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +170,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("无",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+185,p_intPosY);
					System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp,m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX +220,p_intPosY),System.Windows.Forms.ButtonState.Flat);
					p_objGrp.DrawString("有:",fntText,Brushes.Black,(int)enmRectangleInfo.LeftX+235,p_intPosY);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+265,p_intPosY+(int)enmRectangleInfo.RowStep,(int)enmRectangleInfo.RightX-30,p_intPosY+(int)enmRectangleInfo.RowStep);

					if(strIsSpecialtiesCoach[0].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+160,p_intPosY-8);
					if(strIsSpecialtiesCoach[1].ToString()== "1")
						p_objGrp.DrawString("√",fntCheck ,Brushes.Black,(int)enmRectangleInfo.LeftX+210,p_intPosY-8);
					p_objGrp.DrawString(strSpecialtiesCoach,fntValueText,Brushes.Black,new RectangleF((int)enmRectangleInfo.LeftX+265,p_intPosY,490,38),m_sfmPrint);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY+(int)enmRectangleInfo.RowStep+20,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.RowStep+20);

					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+15,p_intPosY-(24*((int)enmRectangleInfo.RowStep)+56),(int)enmRectangleInfo.LeftX+15,p_intPosY+(int)enmRectangleInfo.RowStep+20);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX+61,p_intPosY-(24*((int)enmRectangleInfo.RowStep)+6),(int)enmRectangleInfo.LeftX+61,p_intPosY+(int)enmRectangleInfo.RowStep+20);
					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.RightX,p_intPosY-(24*((int)enmRectangleInfo.RowStep)+56),(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.RowStep+20);

					fntText.Dispose();
					fntCheck.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += 2*((int)enmRectangleInfo.RowStep);
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strIsSpecialtiesCoach = objData[0].ToString();
						strSpecialtiesCoach = objData[1].ToString();
					}
				}
			}
        }
        #endregion

        #endregion


        /// <summary>
        /// 责任护士签名,护长签名
        /// </summary>
        private class clsPrintLine2_14 : clsPrintLineBase
		{ 
			private DateTime dtmFirstPrint;	
			private string strNurse_ID = "";
			private string strChargeNurseID = "";

			private bool m_blnFirstPrint = true;

			public clsPrintLine2_14()
			{
			}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{  
				if(m_blnFirstPrint)
				{
					Font fntText = new Font("SimSun",12);
					Font fntValueText = new Font("SimSun",10);

					p_objGrp.DrawString("责任护士签名："+strNurse_ID,fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+90,p_intPosY+15);
					p_objGrp.DrawString("护长签名："+strChargeNurseID,fntText ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,p_intPosY+15);

					fntText.Dispose();
					fntValueText.Dispose();
					m_blnFirstPrint = false;
				}
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
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
						dtmFirstPrint=(DateTime)objData[2];
						strNurse_ID = objData[0].ToString();
						strChargeNurseID = objData[1].ToString();
					}
				}
			}
		}
		#endregion
	}
}
