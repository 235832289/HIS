using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using com.digitalwave.OperationAgreedRecordServ;
using System.Drawing;

namespace iCare
{
	/// <summary>
	///  手术（麻醉，介入治疗）前签字同意书打印工具类
	/// </summary>
	public class clsOperationAgreedRecordPrintTool : infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;
		//中间层
        //private clsOperationAgreedRecordServ m_objRecordsDomain;
		//打印的基本信息 即名字年龄性别
		private string m_strPrintPatientName;
		private string m_strPrintPatientID;
		private DateTime m_dtRecordCreateDate;
		//具体的打印信息
		private clsOpraAnaSignAgree m_objRecordContent=null;
        
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{	
			m_blnIsFromDataSource=true;//表明是从数据库读取
			m_strPrintPatientID=p_objPatient.m_StrInPatientID;
			m_strPrintPatientName=p_objPatient.m_StrName;
			m_dtRecordCreateDate=p_dtmOpenDate;
			//从传入的病人对象获取病人的基本打印信息并传到m_objprintinfo对象
			//			clsPatient m_objPatient=p_objPatient;
			//			m_objPrintInfo=new clsPrintInfo_OutHospital();
			//			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			//			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			//			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			//			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			//			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			//			m_objPrintInfo. m_strDeptName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName :"";
			//			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName:"";			
			//			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			//			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{		
			m_blnWantInit=false;
			//如果没有病人或者病人不存在则相应的打印详细信息也为空
			if(m_strPrintPatientID==null)
			{
				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_strPrintPatientID=="")
				m_objRecordContent=null;				
			else
			{
				//反之存在病人则去数据库中获取详细的信息
                clsOperationAgreedRecordServ m_objRecordsDomain =
                    (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

				clsOpraAnaSignAgree objContent=new clsOpraAnaSignAgree();
				long lngRes=m_objRecordsDomain.m_lngGetItemRecord(m_strPrintPatientID,m_dtRecordCreateDate,out objContent );
				//没有记录则返回null
				if(lngRes <= 0)
					return ;  
				//这里的转换是否获取到足够信息？？？
				m_objRecordContent=objContent;
			}
			//设置表单内容到打印中			
//			m_objPrintInfo.m_objRecordContent=m_objRecordContent;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			 		 

			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_OutHospital")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
				return;
			}
//			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
//			m_objPrintInfo=(clsPrintInfo_OutHospital)p_objPrintContent;
//			m_objRecordContent= m_objPrintInfo. m_objRecordContent ;		
//			m_mthSetPrintValue();			
		}

		/// <summary>
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
			if(m_blnIsFromDataSource )
			{
				if(m_strPrintPatientID==null)
				{
					clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
					return null;
				}

				if(m_blnWantInit)
					m_mthInitPrintContent();				
			}			
			
			return m_objRecordContent;
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			#region 有关打印初始化
			m_fotTitleFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();

			#endregion
		}

		/// <summary>
		/// 释放打印变量
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
			if(m_blnIsFromDataSource==false || m_strPrintPatientID=="" ) return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
//			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue )
//			{				
//				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),dtmFirstPrintTime);//蔡沐忠改m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate);	
//			}                          
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
			m_intYPos+=550;				
			e.Graphics.DrawString("家属签名:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+30,m_intYPos);
            e.Graphics.DrawString(m_objRecordContent == null ? "":m_objRecordContent.m_strRelationSign, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 110, m_intYPos);
			e.Graphics.DrawString("时间:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+220,m_intYPos);
            if (m_objRecordContent != null && m_objRecordContent.m_strRelationSign.Length != 0)
				e.Graphics.DrawString(m_objRecordContent.m_dtRelationSignDate.ToString("yyyy-MM-dd"),new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+265,m_intYPos);
			e.Graphics.DrawString("单位领导签名:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+370,m_intYPos);
            e.Graphics.DrawString(m_objRecordContent == null ? "" : m_objRecordContent.m_strLeadsign, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 490, m_intYPos);
			e.Graphics.DrawString("时间:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560,m_intYPos);
            if (m_objRecordContent != null && m_objRecordContent.m_strLeadsign.Length != 0)
				e.Graphics.DrawString(m_objRecordContent.m_dtLeadSignDate.ToString("yyyy-MM-dd"),new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+605,m_intYPos);
			m_intYPos+=30;				
			e.Graphics.DrawString("医师签名:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+30,m_intYPos);
            e.Graphics.DrawString(m_objRecordContent == null ? "" : m_objRecordContent.m_strDoctorName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 110, m_intYPos);
			e.Graphics.DrawString("时间:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+220,m_intYPos);
            if (m_objRecordContent != null && m_objRecordContent.m_strDoctorSign.Length != 0)
				e.Graphics.DrawString(m_objRecordContent.m_strDoctorSignDate.ToString("yyyy-MM-dd"),new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+265,m_intYPos);
			e.Graphics.DrawString("科主任签名:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+370,m_intYPos);
            e.Graphics.DrawString(m_objRecordContent == null ? "" : m_objRecordContent.m_strDirectorName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 470, m_intYPos);
			e.Graphics.DrawString("时间:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560,m_intYPos);
            if (m_objRecordContent != null && m_objRecordContent.m_strDirectorSign.Length != 0)
				e.Graphics.DrawString(m_objRecordContent.m_dtDirectorSignDate.ToString("yyyy-MM-dd"),new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+605,m_intYPos);

//			if(m_objRecordContent!=null)
//				e.Graphics.DrawString(m_objRecordContent.m_strDoctorSign,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560+(int)(5f*17.5f),m_intYPos);
			//			m_intYPos+=25;
			//			e.Graphics.DrawString("工　　号:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560,m_intYPos);
			//			if(m_objRecordContent!=null)
			//				e.Graphics.DrawString(m_objRecordContent.m_strDoctorID,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560+(int)(5f*17.5f),m_intYPos);
			
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
            
			Page_HospitalName,
			Page_Name_Title,
			
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
						m_fReturnPoint = new PointF(330f,50f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(200f,80f);
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
		
		private DateTime dtmFirstPrintTime;
		/// <summary>
		/// 给每一打印行的元素赋值
		/// </summary>
		private void m_mthSetPrintValue()
		{		
			#region  第一次打印时间赋值			
			dtmFirstPrintTime=DateTime.Now;
//			if(m_objRecordContent!=null && m_objRecordContent.m_dtmFirstPrintDate !=DateTime.MinValue)
//				dtmFirstPrintTime=m_objRecordContent.m_dtmFirstPrintDate;
			#endregion  第一次打印时间赋值

			#region 打印行初始化
			m_objLine1Arr = new clsPrintLine1[1];
			for(int i=0;i<m_objLine1Arr.Length;i++)
				m_objLine1Arr[i]=new clsPrintLine1();
			
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1Arr[0]
									  });
			m_objPrintContext.m_ObjPrintSign = new clsPrintRecordSign();
			#endregion
			
			#region 给每一行的元素赋值
			if(m_objRecordContent!=null )
			{
				///////////////1行/////////////////
				Object[] objData1=new object[4];
				objData1[0]="　 患者"+m_strPrintPatientName+"经我院医生全面认真检查，诊断为"+m_objRecordContent.m_strStateOfIllness+"。根据病情（手术）的需要，拟于近期（急诊）实施"+m_objRecordContent.m_strAction+"。由于患者术前存在"+m_objRecordContent.m_strBadFactor+"等不利因素，大大地增加了本次手术（麻醉，介入治疗）的危险性，我们将充分做好各项准备工作，另外，即使患者不存在上述不利因素，手术（麻醉，介入治疗）的风险仍不能完全避免，可能出现意外及并发症附后，如家属以及单位领导对此表示理解并同意进行本次手术（麻醉，介入治疗），请签字。 \n　 手术（麻醉，介入治疗）中可能出现的意外以及并发症有："+m_objRecordContent.m_strSyndrome;;
				objData1[1]="";
				objData1[2]=dtmFirstPrintTime;			
				objData1[3]=" ";
				m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;
				
				
				
			}
			else 
			{
				///////////////1行/////////////////
				Object[] objData1=new object[4];
				objData1[0]="";
				objData1[1]="";
				objData1[2]=dtmFirstPrintTime ;	
				objData1[3]=" ";
				m_objLine1Arr[0].m_ObjPrintLineInfo =objData1;


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
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));
		
			e.Graphics.DrawString("手术（麻醉，介入治疗）前签字同意书",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			


		}
		
	
		#endregion		
		
		#region print class 

		private class clsPrintLine1 : clsPrintLineBase
		{
			private clsPrintRichTextContext m_objDiagnose;			
			private DateTime dtmFirstPrint;
			//			private bool m_blnFirstPrint = true;
			private string m_strTitle;

//			/// <summary>
//			/// 日期
//			/// </summary>
//			private const int c_intTop1 = 155;
//			/// <summary>
//			/// 诊断
//			/// </summary>
//			private const int c_intTop2 = 205;
//			/// <summary>
//			/// 病区、主治医师
//			/// </summary>
//			private const int c_intTop3 = 255;
			/// <summary>
			/// 入院情况
			/// </summary>
			private const int c_intTop4 = 305;
			/// <summary>
			/// 诊疗经过
			/// </summary>
			private const int c_intTop5 = 500;
//			/// <summary>
//			/// 出院情况
//			/// </summary>
//			private const int c_intTop6 = 660;
//			/// <summary>
//			/// 出院医瞩
//			/// </summary>
//			private const int c_intTop7 = 790;
			/// <summary>
			/// 一行的高度
			/// </summary>
			private const int c_intOneRowHeight = 40;

			public clsPrintLine1()
			{
				m_objDiagnose = new clsPrintRichTextContext(Color.Black,new Font("SimSun",12));
			}

			//			private int m_intTimes = 0;

			/// <summary>
			/// 格子超出部分偏移量
			/// </summary>
			private static int s_intHeightMargin;
			/// <summary>
			/// 暂存的偏移量
			/// </summary>
			private static int s_intMarginTemp = 0;
			/// <summary>
			/// 打印下一行
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				//画框
				Rectangle rtgDianose = new Rectangle(
					(int)enmRectangleInfo.LeftX,
					p_intPosY,
					0,
					0);
				bool blnMiddle = true;
				//计算的行数
				int intSwitchNumber = 0;
				// 原定固定的高度
				int intPegPosY = 0;
				//进行换行处理
				rtgDianose.X += (int)enmRectangleInfo.LeftX;
				rtgDianose.Y += 50;
				rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
				blnMiddle = false;
				if((rtgDianose.Height =((c_intTop5-c_intTop4-40) - s_intHeightMargin)) < c_intOneRowHeight)
				{
					if (rtgDianose.Height < 0)
						s_intHeightMargin = Math.Abs(rtgDianose.Height);
					rtgDianose.Height = c_intOneRowHeight;
				}
				intPegPosY = c_intTop5;

				int intRealHeight;
				m_objDiagnose.m_blnPrintAllBySimSun(12,rtgDianose,p_objGrp,out intRealHeight,blnMiddle);

				if(intRealHeight > rtgDianose.Height)
				{
					p_intPosY += intRealHeight + 5;
				}
				else
				{
					p_intPosY += rtgDianose.Height;
				}
				if (intSwitchNumber == 0) p_intPosY += 40;

				if (p_intPosY > intPegPosY) 
					s_intHeightMargin += p_intPosY - intPegPosY;
				else
					s_intHeightMargin = 0;

				if(intSwitchNumber == 2)
				{
					s_intMarginTemp = s_intHeightMargin;
					s_intHeightMargin = 0;
					if(intRealHeight > rtgDianose.Height)
						p_intPosY -= (intRealHeight + 40);
					else
						p_intPosY -=  rtgDianose.Height;
				}
				if (intSwitchNumber == 3)
				{
					if (s_intHeightMargin < s_intMarginTemp)
					{
						p_intPosY += s_intMarginTemp - s_intHeightMargin;
						s_intHeightMargin = s_intMarginTemp;
					}
				}


				m_blnHaveMoreLine = false;
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
						if(objData[1].ToString() == "")
						{
							m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),dtmFirstPrint);
						}
						else
						{
							m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),dtmFirstPrint,true);
							m_mthAddSign(m_strTitle.Trim(),m_objDiagnose.m_ObjModifyUserArr);
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



	}
}
