using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing;

using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// 
	/// </summary>
	public class clsLabAnalysisOrderPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsLabAnalysisOrderDomain m_objRecordsDomain;
		private clsPrintInfo_LabAnalysisOrder m_objPrintInfo;
		private clsLabCheckOrderContent m_objLabCheckOrderContent = null;
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate"></param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{		
			m_blnIsFromDataSource = true;//表明是从数据库读取
			clsPatient m_objPatient = p_objPatient;

			m_objPrintInfo = new clsPrintInfo_LabAnalysisOrder();
			m_objPrintInfo.m_strInPatentID = m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName = m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex = m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge = m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName = m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
			m_objPrintInfo. m_strAreaName = m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;	
			m_objPrintInfo.m_dtmCreateDate = p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
			m_objPrintInfo.m_strDiagnose = "";
			m_objPrintInfo.m_strSpecimen = "";
			m_objPrintInfo.m_strSDocName = "";
			m_objPrintInfo.m_strRecDocName = "";
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
			if(m_objPrintInfo.m_strInPatentID == "")
				m_objLabCheckOrderContent = null;				
			else
			{
				m_objRecordsDomain = new clsLabAnalysisOrderDomain();	
				long lngRes = m_objRecordsDomain.m_lngGetRecordContentWithServ(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objLabCheckOrderContent);
				if(lngRes <= 0)
					return ;   
			}
//			//设置表单内容到打印中	
			if(m_objLabCheckOrderContent!=null)
			{
				m_objPrintInfo.m_strSpecimen = m_objLabCheckOrderContent.m_strSpecimen;
				m_objPrintInfo.m_strDiagnose = m_objLabCheckOrderContent.m_strDignose;
				m_objPrintInfo.m_strSDocName = new clsEmployee( m_objLabCheckOrderContent.m_strSDocID).m_StrFirstName;
				m_objPrintInfo.m_strRecDocName = new clsEmployee( m_objLabCheckOrderContent.m_strRecDocID).m_StrFirstName;;
			}
			m_objPrintInfo.m_objLabCheckOrderContent = m_objLabCheckOrderContent;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_LabAnalysisOrder")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_LabAnalysisOrder)p_objPrintContent;
			m_objLabCheckOrderContent = m_objPrintInfo. m_objLabCheckOrderContent ;		
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

			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 14);
			m_fotSmallFont = new Font("SimSun",11);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();
			m_objCPaint=new clsPublicControlPaint();

			#region 打印行初始化

			#endregion 		 

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
		/// 
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{			

		}

		private  void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作
		}
		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs e)
		{
			e.HasMorePages =false;
			//打印固定内容
			m_mthPrintTitleInfo(e);

		}

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}		
		

		#region 打印
		#region 有关打印的声明

		private clsPublicControlPaint m_objCPaint;
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
			Specimen_Title,
			Specimen,
			Diagnose_Title,
			Diagnose,
			SDocName_Title,
			SDocName,
			RecDocName_Title,
			RecDocName,
			CreateDate_Title,
			CreateDate,
            
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
						m_fReturnPoint = new PointF(335f,35f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(320f,62f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(40f,130f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(90f,130f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(170f,130f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(220f,130f);
						break;

					case (int)enmItemDefination.Diagnose_Title :
						m_fReturnPoint = new PointF(250f,130f);
						break;

					case (int)enmItemDefination.Diagnose :
						m_fReturnPoint = new PointF(300f,130f);
						break;

					case (int)enmItemDefination.SDocName_Title :
						m_fReturnPoint = new PointF(40f,160f);
						break;

					case (int)enmItemDefination.SDocName :
						m_fReturnPoint = new PointF(110f,160f);
						break;

					case (int)enmItemDefination.RecDocName_Title :
						m_fReturnPoint = new PointF(190f,160f);
						break;

					case (int)enmItemDefination.RecDocName :
						m_fReturnPoint = new PointF(250f,160f);
						break;

					case (int)enmItemDefination.CreateDate_Title :
						m_fReturnPoint = new PointF(350f,160f);
						break;

					case (int)enmItemDefination.CreateDate :
						m_fReturnPoint = new PointF(420f,160f);
						break;

					case (int)enmItemDefination.Specimen_Title :
						m_fReturnPoint = new PointF(200f,100f);
						break;
					case (int)enmItemDefination.Specimen:
						m_fReturnPoint = new PointF(260f,100f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(470f,100f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(510f,100f);
						break;
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(640f,100f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(690f,100f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(40f,100f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(100f,100f);
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
		
		
		
		/// <summary>
		/// 给每一打印行的元素赋值
		/// </summary>
		private void m_mthSetPrintValue()
		{						
						
		}
				
		/// <summary>
		/// 打印一条水平线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		private void m_mthPrintOneHorizontalLine(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX ,
				p_intBottomY,
				(int)enmRectangleInfo.RightX,
				p_intBottomY);			
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{  
			Font fntBarCode = new System.Drawing.Font("3 of 9 Barcode", 18f, FontStyle.Regular);//, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

			string strBarCode = "";
			if(m_objLabCheckOrderContent != null)
			{
				strBarCode = "*" + m_objLabCheckOrderContent.m_strBarCode + "*";
				e.Graphics.DrawString(strBarCode,fntBarCode ,m_slbBrush,40 , 30);
			}

			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("检  验  单",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title  ));

			e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));

			e.Graphics.DrawString("检验物：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Specimen_Title ));
		
			e.Graphics.DrawString(m_objPrintInfo.m_strSpecimen ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Specimen ));
						
			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));

			e.Graphics.DrawString(m_objPrintInfo.m_strAreaName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strBedName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strPatientName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));

			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex ));

			e.Graphics.DrawString("诊断：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Diagnose_Title ));

			clsPrintRichTextContext objPrintContext = new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
			objPrintContext.m_mthSetContextWithAllCorrect(m_objPrintInfo.m_strDiagnose,"<root />");

			float fltX = m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Diagnose ).X;
			float fltY = m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Diagnose ).Y;
			float fltWidth = 820f-40f - fltX - 10;

			float fltStep = 20;

			while(objPrintContext.m_BlnHaveNextLine())
			{
				objPrintContext.m_mthPrintLine((int)fltWidth,(int)fltX,(int)fltY,e.Graphics);

				fltY += fltStep;
			}

			fltY += fltStep;
			
			e.Graphics.DrawString("送检医师：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.SDocName_Title ).X,fltY);
			e.Graphics.DrawString(m_objPrintInfo.m_strSDocName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.SDocName ).X,fltY);

			e.Graphics.DrawString("录入者：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.RecDocName_Title ).X,fltY);
			e.Graphics.DrawString(m_objPrintInfo.m_strRecDocName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.RecDocName).X,fltY);

			e.Graphics.DrawString("日期：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.CreateDate_Title ).X,fltY);
			e.Graphics.DrawString(m_objPrintInfo.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss") ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.CreateDate).X,fltY);

			fltY += fltStep;

			m_mthPrintOneHorizontalLine(e,(int)fltY);

			fltY += fltStep;

			e.Graphics.DrawString("检验项目：",m_fotSmallFont,m_slbBrush,40,fltY);

			int intTimes = 0;

			fltY += fltStep;

			if(m_objPrintInfo.m_objLabCheckOrderContent != null && m_objPrintInfo.m_objLabCheckOrderContent.m_strItem_NameArr != null && m_objPrintInfo.m_objLabCheckOrderContent.m_strItem_NameArr.Length != 0)
			{
				intTimes = m_objLabCheckOrderContent.m_strItem_NameArr.Length;
				for(int i = 0; i < m_objLabCheckOrderContent.m_strItem_NameArr.Length; i++)
				{
					string strItemName = m_objPrintInfo.m_objLabCheckOrderContent.m_strItem_NameArr[i];

					e.Graphics.DrawString(strItemName,m_fotSmallFont,m_slbBrush,140, fltY );

					fltY += 30;
				}
			}

			int intCount = 7;
			if(intTimes >= intCount)
			{
				//比预留的空格多
				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX ,
					fltY,
					(int)enmRectangleInfo.RightX,
					fltY);
			}
			else
			{
				fltY += (intCount-intTimes)*30;

				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX ,
					fltY,
					(int)enmRectangleInfo.RightX,
					fltY);
			}

			fltY += fltStep;

			e.Graphics.DrawString("备注：",m_fotSmallFont,m_slbBrush,40,fltY);
			fltY += fltStep;
			if(m_objPrintInfo.m_objLabCheckOrderContent != null && m_objPrintInfo.m_objLabCheckOrderContent.m_strRemark != null)
			{
				e.Graphics.DrawString(m_objPrintInfo.m_objLabCheckOrderContent.m_strRemark,m_fotSmallFont,m_slbBrush,40,fltY);
			}

		}
		
	
		#endregion		

		#endregion

//		/// <summary>
//		/// 
//		/// </summary>
//		[Serializable]			
//		private class clsPrintInfo_LabAnalysisOrder
//		{
//			public string m_strInPatentID;			
//			public string m_strPatientName;
//			public string m_strSex;
//			public string m_strAge;
//			public string m_strBedName;
//			public string m_strDeptName;
//			public string m_strAreaName;	
//			public DateTime m_dtmInPatientDate;
//			public DateTime m_dtmCreateDate;
//
//			public string m_strSpecimen;
//			public string m_strDiagnose;
//			public string m_strSDocName;
//			public string m_strRecDocName;
//
//			public clsLabCheckOrderContent m_objLabCheckOrderContent;			
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
		//		clsLabAnalysisOrderPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsLabAnalysisOrderPrintTool();
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
		//			objPrintTool=new clsLabAnalysisOrderPrintTool();
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



