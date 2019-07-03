using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 手术敷料的打印工具类,Jacky-2003-6-9
	/// </summary>
	public class clsOperationEquipmentQtyPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsOperationEqipmentQtyDomain m_objRecordsDomain;
		private clsPrintInfo_OperationEquipmentQty m_objPrintInfo;
		private clsOperationEquipmentPackage m_objCurrentPackage=null;
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，本类是一次打印一条记录表单的类型,不能忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{		
			m_blnIsFromDataSource=true;//表明是从数据库读取
			clsPatient m_objPatient=p_objPatient;
			m_objPrintInfo=new clsPrintInfo_OperationEquipmentQty();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
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
				m_objCurrentPackage=null;				
			else
			{
				m_objRecordsDomain=new clsOperationEqipmentQtyDomain();	
				long lngRes=m_objRecordsDomain.lngSelectDisply(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objCurrentPackage );
				if(lngRes <= 0)
					return ;   
				lngRes=m_objRecordsDomain.m_lngGetOperation_Nurse(m_objCurrentPackage.m_objOperationEqipmentQtyXML.strInPatientID,m_objCurrentPackage.m_objOperationEqipmentQtyXML.strInPatientDate,m_objCurrentPackage.m_objOperationEqipmentQtyXML.strOpenDate,out m_objCurrentPackage.m_objOperationNurse);
				if(lngRes <= 0)
					return ;   
			}
			//设置表单内容到打印中			
			m_objPrintInfo.m_objCurrentPackage=m_objCurrentPackage;
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_blnWantInit=false;
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_OperationEquipmentQty")
			{
				MDIParent.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_OperationEquipmentQty)p_objPrintContent;
			m_objCurrentPackage= m_objPrintInfo. m_objCurrentPackage ;		
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
			m_fotTitleFont = new Font("SimSun", 16);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);

			m_intYPos=(int)enmRecordRectangleInfo.TopY ;			

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
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="" || m_objPrintInfo.m_objCurrentPackage==null) return;
			//手术敷料暂时没有首次打印时间的支持.
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
//			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFirstPrintDate != null && m_objPrintInfo.m_objCurrentPackage.m_objOperationEquipmentQty.strFirstPrintDate != "")
//			{				
//				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));	
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
			m_mthSheetTitleInfo(e);

			Font fntNormal = new Font("SimSun",11);
			
			while(m_objPrintContext.m_BlnHaveMoreLine)
			{
				m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);
				#region 换页处理
				if(m_intYPos >=(int)enmRecordRectangleInfo.BottomY 
					&& m_objPrintContext.m_BlnHaveMoreLine)
				{
					e.HasMorePages = true;
					
					#region 画格子竖线,底线
			
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX,m_intYPos);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,m_intYPos);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,m_intYPos);
         
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,m_intYPos);

					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,m_intYPos);

					e.Graphics.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,m_intYPos,(int)enmRecordRectangleInfo.RightX,m_intYPos);

					#endregion 

					m_intPages++;
					return;
				}
				#endregion 
				
			}

			m_intYPos += (int)enmRectangleInfo.RowStep+15;
			Font fntSign = new Font("",6);
			while(m_objPrintContext.m_BlnHaveMoreSign)
			{
				m_objPrintContext.m_mthPrintNextSign((int)enmRectangleInfo.LeftX,m_intYPos,e.Graphics,fntSign);

				m_intYPos += (int)enmRectangleInfo.RowStep-10;				
			}

			//全部打完
			e.Graphics.DrawString("植入物标示粘贴处:",new Font("SimSun",16,FontStyle.Bold) ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+3,m_intYPos+50);

			m_objPrintContext.m_mthReset();
			m_intPages=1;
			m_intYPos=(int)enmRecordRectangleInfo.TopY ;
		}

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}		
		

		#region  打印

		private void m_mthSetPrintValue()
		{
			#region 打印行初始化
			m_objLineArr = new clsPrintLine[41];
			for(int i=0;i<m_objLineArr.Length;i++)
				m_objLineArr[i]=new clsPrintLine();

			m_objLineNurse=new clsPrintNurse[2];
			m_objLineNurse[0]=new clsPrintNurse();
			m_objLineNurse[1]=new clsPrintNurse();

			m_objLineOperationName=new clsPrintOperationName();
	
							
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLineOperationName,
										  m_objLineArr[0],
										  m_objLineArr[1],
										  m_objLineArr[2],
										  m_objLineArr[3],
										  m_objLineArr[4],
										  m_objLineArr[5],
										  m_objLineArr[6],
										  m_objLineArr[7],
										  m_objLineArr[8],
										  m_objLineArr[9],
										  m_objLineArr[10],
										  m_objLineArr[11],
										  m_objLineArr[12],
										  m_objLineArr[13],
										  m_objLineArr[14],
										  m_objLineArr[15],
										  m_objLineArr[16],
										  m_objLineArr[17],
										  m_objLineArr[18],
										  m_objLineArr[19],
										  m_objLineArr[20],
										  m_objLineArr[21],
										  m_objLineArr[22],
										  m_objLineArr[23],
										  m_objLineArr[24],
										  m_objLineArr[25],
										  m_objLineArr[26],
										  m_objLineArr[27],
										  m_objLineArr[28],
										  m_objLineArr[29],
										  m_objLineArr[30],
										  m_objLineArr[31],
										  m_objLineArr[32],
										  m_objLineArr[33],
										  m_objLineArr[34],
										  m_objLineArr[35],
										  m_objLineArr[36],
										  m_objLineArr[37],
										  m_objLineArr[38],
										  m_objLineArr[39],
										  m_objLineArr[40],
										  m_objLineNurse[0],m_objLineNurse[1],
																				 
										
			});
			m_objPrintContext.m_ObjPrintSign = new clsPrintRecordSign();
			#endregion 		 

			if(m_objCurrentPackage!=null &&
				m_objCurrentPackage.m_objOperationEqipmentQtyContent!=null &&
				m_objCurrentPackage.m_objOperationEqipmentQtyXML!=null)
			{
				#region 赋值


				Object[] objData=new object[2];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strOperationName;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strOperationNameXML;
				m_objLineOperationName.m_ObjPrintLineInfo=objData ;
				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenZhi125;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenZhi125XML;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenZhi125Before;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenZhi125BeforeXML ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenZhi125After;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenZhi125AfterXML;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNianMoQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNianMoQianXML;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNianMoQianBefore ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNianMoQianBeforeXML ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNianMoQianAfter ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNianMoQianAfterXML;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingTuJian;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingTuJianXML;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingTuJianBefore ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingTuJianBeforeXML ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingTuJianAfter ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingTuJianAfterXML;
				objData[18]="蚊直（12.5cm）";
				objData[19]="粘膜钳";
				objData[20]="棘突剪";
				m_objLineArr[0].m_ObjPrintLineInfo=objData;
				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenWan125;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenWan125XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenWan125Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenWan125BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWenWan125After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWenWan125AfterXML;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaLiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaLiQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaLiQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaLiQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaLiQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaLiQianAfterXML;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQi;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQiBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQiAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiAfterXML;
				objData[18]="蚊弯（12.5cm）";
				objData[19]="纱粒钳";
				objData[20]="椎板剥离器";
				m_objLineArr[1].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoZhi14;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoZhi14XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoZhi14Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoZhi14BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoZhi14After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoZhi14AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoQianXML;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianBoLiZi ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianBoLiZiXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianBoLiZiBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianBoLiZiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianBoLiZiAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianBoLiZiAfterXML ;
				objData[18]="小直（14cm）";
				objData[19]="直角钳";
				objData[20]="腱剥离子";
				m_objLineArr[2].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoWan14;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoWan14XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoWan14Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoWan14BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaoWan14After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaoWan14AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaZhiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaZhiQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaZhiQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaZhiQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaZhiQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaZhiQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQiangZhuangNie ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQiangZhuangNieXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQiangZhuangNieBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQiangZhuangNieBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQiangZhuangNieAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQiangZhuangNieAfterXML;
				objData[18]="小弯（14cm）";
				objData[19]="大直钳";
				objData[20]="枪状镊";
				m_objLineArr[3].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongZhi16;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongZhi16XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongZhi16Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongZhi16BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongZhi16After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongZhi16AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaWanXueGuanQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaWanXueGuanQianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaWanXueGuanQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaWanXueGuanQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaWanXueGuanQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaWanXueGuanQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBaiShiQianKaiQi ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBaiShiQianKaiQiXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBaiShiQianKaiQiBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBaiShiQianKaiQiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBaiShiQianKaiQiAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBaiShiQianKaiQiAfterXML ;
				objData[18]="中直（16cm）";
				objData[19]="大弯血管钳";
				objData[20]="拜氏牵开器";
				m_objLineArr[4].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongWan16;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongWan16XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongWan16Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongWan16BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongWan16After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongWan16AfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenDiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenDiQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenDiQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenDiQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenDiQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenDiQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMian ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMianBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMianAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianAfterXML ;
				objData[18]="中弯（16cm）";
				objData[19]="肾蒂钳";
				objData[20]="开颅棉";
				m_objLineArr[5].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPiQian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPiQianXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPiQianBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPiQianBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPiQianAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPiQianAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianZhi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianZhiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianZhiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianZhiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianZhiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianZhiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTouPiJianQian ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTouPiJianQianXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTouPiJianQianBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTouPiJianQianBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTouPiJianQianAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTouPiJianQianAfterXML ;
				objData[18]="皮钳";
				objData[19]="肠钳（直）";
				objData[20]="头皮夹钳";
				m_objLineArr[6].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiYouChiXueGuanQian ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianWan ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianWanXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianWanBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianWanBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianWanAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianWanAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXianJuDaoYinZi ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXianJuDaoYinZiXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXianJuDaoYinZiBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXianJuDaoYinZiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXianJuDaoYinZiAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXianJuDaoYinZiAfterXML ;
				objData[18]="直有齿血管钳";
				objData[19]="肠钳（弯）";
				objData[20]="线锯导引子";
				m_objLineArr[7].m_ObjPrintLineInfo=objData;


				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanQian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanQianXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanQianBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanQianBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanQianAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanQianAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShiQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShiQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShiQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShiQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShiQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErLaGou ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErLaGouXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErLaGouBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErLaGouBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErLaGouAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErLaGouAfterXML ;
				objData[18]="圈钳";
				objData[19]= "石钳";
				objData[20]="心耳拉勾";
				m_objLineArr[8].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinQian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinQianXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinQianBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinQianBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinQianAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinQianAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWeiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWeiQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWeiQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWeiQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWeiQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWeiQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiBanQian ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiBanQianXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiBanQianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiBanQianBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiBanQianAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiBanQianAfterXML ;
				objData[18]="巾钳";
				objData[19]="胃钳";
				objData[20]="持瓣钳";
				m_objLineArr[9].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiZhenQian18 ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiZhenQian18XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiZhenQian18Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiZhenQian18BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiZhenQian18After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiZhenQian18AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErQiaBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErQiaBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinErQiaAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinErQiaAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinFangLaGou;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinFangLaGouXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinFangLaGouBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinFangLaGouBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinFangLaGouAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinFangLaGouAfterXML ;
				objData[18]="持针钳（18cm）";
				objData[19]="心耳钳";
				objData[20]="心房拉勾";
				m_objLineArr[10].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouChiNie;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouChiNieXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouChiNieBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouChiNieBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouChiNieAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouChiNieAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErYanHouChongXiQi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErYanHouChongXiQiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErYanHouChongXiQiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErYanHouChongXiQiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErYanHouChongXiQiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErYanHouChongXiQiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNaoMoGou ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNaoMoGouXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNaoMoGouBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNaoMoGouBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNaoMoGouAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNaoMoGouAfterXML ;
				objData[18]= "有齿镊";
				objData[19]="耳咽管冲洗器";
				objData[20]="脑膜钩";
				m_objLineArr[11].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChiNie;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChiNieXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChiNieBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChiNieBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChiNieAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChiNieAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenChu ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenChuXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenChuBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenChuBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenChuAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenChuAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChuanCiZhen ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChuanCiZhenXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChuanCiZhenBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChuanCiZhenBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChuanCiZhenAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChuanCiZhenAfterXML ;
				objData[18]="无齿镊";
				objData[19]= "探针（粗）";
				objData[20]="穿刺针";
				m_objLineArr[12].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaBan;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaBanXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaBanBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaBanBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaBanAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaBanAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenXi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenXiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenXiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenXiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTanZhenXiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTanZhenXiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDingQian ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDingQianXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDingQianBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDingQianBeforeXML ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDingQianAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDingQianAfterXML ;
				objData[18]="肠压板";
				objData[19]="探针（细）";
				objData[20]="银钉钳";
				m_objLineArr[13].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing3;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing3XML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing3Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing3BeforeXML ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing3After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing3AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanDaoTanTiao ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanDaoTanTiaoXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanDaoTanTiaoBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanDaoTanTiaoBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanDaoTanTiaoAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanDaoTanTiaoAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFeiYeDangBan;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFeiYeDangBanXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFeiYeDangBanBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFeiYeDangBanBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFeiYeDangBanAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFeiYeDangBanAfterXML ;
				objData[18]= "刀柄（3号）";
				objData[19]="胆道探条";
				objData[20]="肺叶挡板";
				m_objLineArr[14].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing4;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing4XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing4Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing4BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing4After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing4AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQianKaiQi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQianKaiQiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQianKaiQiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQianKaiQiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQianKaiQiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQianKaiQiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAZhuDuanQian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuAZhuDuanQianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAZhuDuanQianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuAZhuDuanQianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAZhuDuanQianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiAfterXML  ;
				objData[18]="刀柄（4号）";
				objData[19]="肋骨牵开器";
				objData[20]="主A阻断钳";
				m_objLineArr[15].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing7;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing7XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing7Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing7BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoBing7After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoBing7AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strHeLongQi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strHeLongQiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strHeLongQiBefore ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strHeLongQiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strHeLongQiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strHeLongQiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAYouLiQian ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuAYouLiQianXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAYouLiQianBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuAYouLiQianBeforeXML ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuAYouLiQianAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuAYouLiQianAfterXML ;
				objData[18]="刀柄（7号）";
				objData[19]="合笼器";
				objData[20]="主A游离钳";
				m_objLineArr[16].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanZhuZhiJian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanZhuZhiJianXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanZhuZhiJianBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanZhuZhiJianBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanZhuZhiJianAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanZhuZhiJianAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianJiaGuLaGou;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianJiaGuLaGouXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianJiaGuLaGouBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianJiaGuLaGouBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJianJiaGuLaGouAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJianJiaGuLaGouAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuACeBiQian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuACeBiQianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuACeBiQiBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuACeBiQiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuACeBiQiAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuACeBiQiAfterXML  ;
				objData[18]="弯组织剪";
				objData[19]="肩胛骨拉勾";
				objData[20]="主A侧壁钳";
				m_objLineArr[17].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiZhuZhiJian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiZhuZhiJianXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiZhuZhiJianBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiZhuZhiJianBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiZhuZhiJianAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiZhuZhiJianAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQiZi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQianKaiQiXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQiZiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQiZiBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLeiGuQiZiAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLeiGuQiZiAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErJianBanKuoZhangQi  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErJianBanKuoZhangQiXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErJianBanKuoZhangQiBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErJianBanKuoZhangQiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strErJianBanKuoZhangQiAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strErJianBanKuoZhangQiAfterXML  ;
				objData[18]="直组织剪";
				objData[19]="肋骨起子";
				objData[20]="二尖瓣扩张器";
				m_objLineArr[18].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianTaoXianJian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianTaoXianJianXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianTaoXianJianBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianTaoXianJianBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianTaoXianJianAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianTaoXianJianAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaGuJian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaGuJianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaGuJianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaGuJianBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaGuJianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaGuJianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strCeBanQi  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strCeBanQiXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strCeBanQiBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strCeBanQiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strCeBanQiAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strCeBanQiAfterXML  ;
				objData[18]="扁桃腺剪";
				objData[19]="大骨钳";
				objData[20]="测瓣器";
				m_objLineArr[19].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiongQiangJian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiongQiangJianXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiongQiangJianBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiongQiangJianBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiongQiangJianAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiongQiangJianAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDiErLeiGuJian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDiErLeiGuJianXML   ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDiErLeiGuJianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDiErLeiGuJianBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDiErLeiGuJianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDiErLeiGuJianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGou  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouAfterXML  ;
				objData[18]="胸腔剪";
				objData[19]="第二肋骨钳";
				objData[20]="心内直角拉钩";
				m_objLineArr[20].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGou;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFangTouYaoGuQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFangTouYaoGuQianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFangTouYaoGuQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFangTouYaoGuQianBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFangTouYaoGuQianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFangTouYaoGuQianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGou ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGouBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGouAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouAfterXML  ;
				objData[18]="直角小拉勾";
				objData[19]="方头咬骨钳";
				objData[20]="导线钩";
				m_objLineArr[21].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLanWeiLaGou;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLanWeiLaGouXML   ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLanWeiLaGouBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLanWeiLaGouBeforeXML    ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLanWeiLaGouAfter   ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLanWeiLaGouAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYaoGuQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYaoGuQianXML    ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYaoGuQianBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYaoGuQianBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYaoGuQianAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYaoGuQianAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChuangNie  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChuangNieXML   ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChuangNieBefore    ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChuangNieBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuChuangNieAfter    ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuChuangNieAfterXML  ;
				objData[18]="阑尾拉勾";
				objData[19]="咬骨钳";
				objData[20]="无齿镊";
				m_objLineArr[22].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongFuGou;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongFuGouXML   ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongFuGouBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongFuGouBeforeXML    ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhongFuGouAfter   ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhongFuGouAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuMoBoLiQi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuMoBoLiQiXML     ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuMoBoLiQiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuMoBoLiQiBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuMoBoLiQiAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuMoBoLiQiAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaChi  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaChiXML   ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaChiBefore    ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaChiBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaChiAfter    ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaChiAfterXML   ;
				objData[18]="中腹勾";
				objData[19]="骨膜剥离器";
				objData[20]="卡尺";
				m_objLineArr[23].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaGou;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaGouXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaGouBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaGouBeforeXML    ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangYaGouAfter   ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangYaGouAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuDao ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuDaoXML    ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuDaoBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuDaoBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuDaoAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuDaoAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenJingLaGou   ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenJingLaGouXML   ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenJingLaGouBefore    ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenJingLaGouBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShenJingLaGouAfter    ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShenJingLaGouAfterXML  ;
				objData[18]="肠压勾";
				objData[19]="骨刀";
				objData[20]="神经拉钩";
				m_objLineArr[24].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoGou;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoGouXML   ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoGouBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoGouBeforeXML    ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhiJiaoGouAfter   ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhiJiaoGouAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuZao;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuZaoXML    ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuZaoBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuZaoBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuZaoAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuZaoAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXueGuanJia  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXueGuanJiaXML   ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXueGuanJiaBefore    ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXueGuanJiaBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXueGuanJiaAfter    ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXueGuanJiaAfterXML   ;
				objData[18]="直角勾";
				objData[19]="骨凿";
				objData[20]="血管夹";
				m_objLineArr[25].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaFuBuQianKaiQi;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiXML   ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiBefore   ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiBeforeXML    ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiAfter   ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoShi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoShiXML    ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoShiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoShiBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoShiAfter    ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoShiAfterXML   ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianDai  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianDaiXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianDaiBefore    ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianDaiBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strBianDaiAfter    ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strBianDaiAfterXML   ;
				objData[18]="下腹部牵开器";
				objData[19]="括匙";
				objData[20]="边带";
				m_objLineArr[26].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTongQuan;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTongQuanXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTongQuanBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTongQuanBeforeXML ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strTongQuanAfter;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strTongQuanAfterXML;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuChui;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuChuiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuChuiBefore ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuChuiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGuChuiAfter ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGuChuiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianTao;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianTaoXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianTaoBefore ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianTaoBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangQianTaoAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangQianTaoAfterXML ;
				objData[18]="铜圈";
				objData[19]="骨锤";
				objData[20]="肠钳套";
				m_objLineArr[27].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiYeGuan;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiYeGuanXML;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiYeGuanBefore;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiYeGuanBeforeXML ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strXiYeGuanAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strXiYeGuanAfterXML;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiGuQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiGuQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiGuQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiGuQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChiGuQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChiGuQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNiaoGuan ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNiaoGuanXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNiaoGuanBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNiaoGuanBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strNiaoGuanAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strNiaoGuanAfterXML ;
				objData[18]="吸液管";
				objData[19]="持骨钳";
				objData[20]="尿管";
				m_objLineArr[28].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFengZhen;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFengZhenXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFengZhenBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFengZhenBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFengZhenAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFengZhenAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingGuQiZi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingGuQiZiXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingGuQiZiBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingGuQiZiBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJingGuQiZiAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJingGuQiZiAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaQiu;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaQiuXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaQiuBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaQiuBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaQiuAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaQiuAfterXML ;
				objData[18]="缝针";
				objData[19]="径骨起子";
				objData[20]="纱球";
				m_objLineArr[29].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoPian;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoPianXML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoPianBefore ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoPianBeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoPianAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoPianAfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanChiLaGou ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanChiLaGouXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanChiLaGouBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanChiLaGouBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDanChiLaGouAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDanChiLaGouAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaKuai;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaKuaiXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaKuaiBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaKuaiBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShaKuaiAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShaKuaiAfterXML ;
				objData[18]="刀片";
				objData[19]="单齿拉钩";
				objData[20]="纱块";
				m_objLineArr[30].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian18;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian18XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian18Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian18BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian18After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian18AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLaoHuQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLaoHuQianXML ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLaoHuQianBefore  ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLaoHuQianBeforeXML  ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLaoHuQianAfter  ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLaoHuQianAfterXML ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWangSha ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWangShaXML ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWangShaBefore  ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWangShaBeforeXML  ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWangShaAfter  ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWangShaAfterXML ;
				objData[18]="弯血管钳(18cm)";
				objData[19]="老虎钳";
				objData[20]="网纱";
				m_objLineArr[31].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian20;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian20XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian20Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian20BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian20After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian20AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPingHengFuWeiQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPingHengFuWeiQianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPingHengFuWeiQianBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPingHengFuWeiQianBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strPingHengFuWeiQianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strPingHengFuWeiQianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanGongSha  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanGongShaXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanGongShaBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanGongShaBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strQuanGongShaAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strQuanGongShaAfterXML  ;
				objData[18]="弯血管钳(20cm)";
				objData[19]="平衡复位钳";
				objData[20]="全宫纱";
				m_objLineArr[32].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian22;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian22XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian22Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian22BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian22After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian22AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLuoSiQiZi;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLuoSiQiZiXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLuoSiQiZiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLuoSiQiZiBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strLuoSiQiZiAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strLuoSiQiZiAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKaiLuMianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKaiLuMianAfterXML  ;
				objData[18]="弯血管钳(22cm)";
				objData[19]="螺丝起子";
				objData[20]="开颅棉";
				m_objLineArr[33].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian25;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian25XML ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian25Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian25BeforeXML  ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWanXueGuanQian25After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWanXueGuanQian25AfterXML ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGou;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGouBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strDaoXianGouAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strDaoXianGouAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuNieYinLiu  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuNieYinLiuXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuNieYinLiuBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuNieYinLiuBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuNieYinLiuAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuNieYinLiuAfterXML  ;
				objData[18]="弯血管钳(25cm)";
				objData[19]="阴道拉钩";
				objData[20]="腹内引流";
				m_objLineArr[34].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangChiZhenQian25;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangChiZhenQian25XML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangChiZhenQian25Before ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangChiZhenQian25BeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strChangChiZhenQian25After ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strChangChiZhenQian25AfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiBeforeXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strZhuiBanBoLiQiAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strZhuiBanBoLiQiAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiChangDian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiChangDianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiChangDianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiChangDianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiChangDianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiChangDianAfterXML  ;
				objData[18]="长持针钳(25cm)";
				objData[19]="椎板剥离器";
				objData[20]="无带长垫";
				m_objLineArr[35].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuKui ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuKuiXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuKuiBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuKuiBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuKuiAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuKuiAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShuiHeQian;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShuiHeQianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShuiHeQianBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShuiHeQianBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strShuiHeQianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strShuiHeQianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiChangDian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiChangDianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiChangDianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiChangDianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiChangDianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiChangDianAfterXML  ;
				objData[18]="妇窥";
				objData[19]="髓核钳";
				objData[20]="有带长垫";
				m_objLineArr[36].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongChi;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongChiXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongChiBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongChiBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongChiAfter ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongChiAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDaoLaGou;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDaoLaGouXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDaoLaGouBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDaoLaGouBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYinDaoLaGouAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYinDaoLaGouAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiFangDian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiFangDianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiChangDianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiFangDianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strWuDaiChangDianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strWuDaiChangDianAfterXML  ;
				objData[18]="宫尺";
				objData[19]="阴道拉钩";
				objData[20]="无带方垫";
				m_objLineArr[37].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongGuaShi ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongGuaShiXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongGuaShiBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongGuaShiBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongGuaShiAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongGuaShiAfterXML   ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strRenDaiQian ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strRenDaiQianXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strRenDaiQianBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strRenDaiQianBeforeXML    ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strRenDaiQianAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strRenDaiQianAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiFangDian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiFangDianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiFangDianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiFangDianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strYouDaiFangDianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strYouDaiFangDianAfterXML  ;
				objData[18]="宫刮尺";
				objData[19]="韧带钳";
				objData[20]="有带方垫";
				m_objLineArr[38].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongJingQian ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongJingQianXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongJingQianBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongJingQianBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strGongJingQianAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strGongJingQianAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJiLiuBoLiZi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJiLiuBoLiZiXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJiLiuBoLiZiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJiLiuBoLiZiBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJiLiuBoLiZiAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJiLiuBoLiZiAfterXML  ;
				objData[12]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuGuoQian  ;
				objData[13]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuGuoQianXML  ;
				objData[14]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuGuoQianBefore   ;
				objData[15]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuGuoQianBeforeXML   ;
				objData[16]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strFuGuoQianAfter   ;
				objData[17]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strFuGuoQianAfterXML  ;
				objData[18]="宫颈钳";
				objData[19]="肌瘤剥离子";
				objData[20]="敷裹钳";
				m_objLineArr[39].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				objData[0]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinShuNiaoGou ;
				objData[1]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinShuNiaoGouXML  ;
				objData[2]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinShuNiaoGouBefore  ;
				objData[3]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinShuNiaoGouBeforeXML   ;
				objData[4]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strJinShuNiaoGouAfter  ;
				objData[5]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strJinShuNiaoGouAfterXML  ;
				objData[6]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoGongQi ;
				objData[7]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoGongQiXML  ;
				objData[8]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoGongQiBefore   ;
				objData[9]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoGongQiBeforeXML   ;
				objData[10]=m_objCurrentPackage.m_objOperationEqipmentQtyContent.strKuoGongQiAfter   ;
				objData[11]=m_objCurrentPackage.m_objOperationEqipmentQtyXML.strKuoGongQiAfterXML  ;
				objData[12]="";
				objData[13]="" ;
				objData[14]=""  ;
				objData[15]=""  ;
				objData[16]=""  ;
				objData[17]="" ;
				objData[18]="金属尿管";
				objData[19]="括宫器";
				objData[20]="";
				m_objLineArr[40].m_ObjPrintLineInfo=objData;

				#endregion 

			}
			else 
			{
				#region 赋值 空表
				///


				Object[] objData=new object[2];
				objData[0]="";
				objData[1]="";

				m_objLineOperationName.m_ObjPrintLineInfo=objData ;
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="蚊直（12.5cm）";
				objData[19]="粘膜钳";
				objData[20]="棘突剪";
				m_objLineArr[0].m_ObjPrintLineInfo=objData;
				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="蚊弯（12.5cm）";
				objData[19]="纱粒钳";
				objData[20]="椎板剥离器";
				m_objLineArr[1].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="小直（14cm）";
				objData[19]="直角钳";
				objData[20]="腱剥离子";
				m_objLineArr[2].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="小弯（14cm）";
				objData[19]="大直钳";
				objData[20]="枪状镊";
				m_objLineArr[3].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="中直（16cm）";
				objData[19]="大弯血管钳";
				objData[20]="拜氏牵开器";
				m_objLineArr[4].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="中弯（16cm）";
				objData[19]="肾蒂钳";
				objData[20]="开颅棉";
				m_objLineArr[5].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="皮钳";
				objData[19]="肠钳（直）";
				objData[20]="头皮夹钳";
				m_objLineArr[6].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="直有齿血管钳";
				objData[19]="肠钳（弯）";
				objData[20]="线锯导引子";
				m_objLineArr[7].m_ObjPrintLineInfo=objData;


				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="圈钳";
				objData[19]= "石钳";
				objData[20]="心耳拉勾";
				m_objLineArr[8].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="巾钳";
				objData[19]="胃钳";
				objData[20]="持瓣钳";
				m_objLineArr[9].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="持针钳（18cm）";
				objData[19]="心耳钳";
				objData[20]="心房拉勾";
				m_objLineArr[10].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]= "有齿镊";
				objData[19]="耳咽管冲洗器";
				objData[20]="脑膜钩";
				m_objLineArr[11].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="无齿镊";
				objData[19]= "探针（粗）";
				objData[20]="穿刺针";
				m_objLineArr[12].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="肠压板";
				objData[19]="探针（细）";
				objData[20]="银钉钳";
				m_objLineArr[13].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]= "刀柄（3号）";
				objData[19]="胆道探条";
				objData[20]="肺叶挡板";
				m_objLineArr[14].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="刀柄（4号）";
				objData[19]="肋骨牵开器";
				objData[20]="主A阻断钳";
				m_objLineArr[15].m_ObjPrintLineInfo=objData;

				///
				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="刀柄（7号）";
				objData[19]="合笼器";
				objData[20]="主A游离钳";
				m_objLineArr[16].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="弯组织剪";
				objData[19]="肩胛骨拉勾";
				objData[20]="主A侧壁钳";
				m_objLineArr[17].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="直组织剪";
				objData[19]="肋骨起子";
				objData[20]="二尖瓣扩张器";
				m_objLineArr[18].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="扁桃腺剪";
				objData[19]="大骨钳";
				objData[20]="测瓣器";
				m_objLineArr[19].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="胸腔剪";
				objData[19]="第二肋骨钳";
				objData[20]="心内直角拉钩";
				m_objLineArr[20].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="直角小拉勾";
				objData[19]="方头咬骨钳";
				objData[20]="导线钩";
				m_objLineArr[21].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="阑尾拉勾";
				objData[19]="咬骨钳";
				objData[20]="无齿镊";
				m_objLineArr[22].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="中腹勾";
				objData[19]="骨膜剥离器";
				objData[20]="卡尺";
				m_objLineArr[23].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="肠压勾";
				objData[19]="骨刀";
				objData[20]="神经拉钩";
				m_objLineArr[24].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="直角勾";
				objData[19]="骨凿";
				objData[20]="血管夹";
				m_objLineArr[25].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="下腹部牵开器";
				objData[19]="括匙";
				objData[20]="边带";
				m_objLineArr[26].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="铜圈";
				objData[19]="骨锤";
				objData[20]="肠钳套";
				m_objLineArr[27].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="吸液管";
				objData[19]="持骨钳";
				objData[20]="尿管";
				m_objLineArr[28].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="缝针";
				objData[19]="径骨起子";
				objData[20]="纱球";
				m_objLineArr[29].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="刀片";
				objData[19]="单齿拉钩";
				objData[20]="纱块";
				m_objLineArr[30].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="弯血管钳(18cm)";
				objData[19]="老虎钳";
				objData[20]="网纱";
				m_objLineArr[31].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="弯血管钳(20cm)";
				objData[19]="平衡复位钳";
				objData[20]="全宫纱";
				m_objLineArr[32].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="弯血管钳(22cm)";
				objData[19]="螺丝起子";
				objData[20]="开颅棉";
				m_objLineArr[33].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="弯血管钳(25cm)";
				objData[19]="阴道拉钩";
				objData[20]="腹内引流";
				m_objLineArr[34].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="长持针钳(25cm)";
				objData[19]="椎板剥离器";
				objData[20]="无带长垫";
				m_objLineArr[35].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="妇窥";
				objData[19]="髓核钳";
				objData[20]="有带长垫";
				m_objLineArr[36].m_ObjPrintLineInfo=objData;


				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="宫尺";
				objData[19]="阴道拉钩";
				objData[20]="无带方垫";
				m_objLineArr[37].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="宫刮尺";
				objData[19]="韧带钳";
				objData[20]="有带方垫";
				m_objLineArr[38].m_ObjPrintLineInfo=objData;

				objData=new object[21];
				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				objData[18]="宫颈钳";
				objData[19]="肌瘤剥离子";
				objData[20]="敷裹钳";
				m_objLineArr[39].m_ObjPrintLineInfo=objData;

				objData=new object[21];

				for(int i=0;i<18;i++)
				{
					objData[i]="";
				}
				
				objData[18]="金属尿管";
				objData[19]="括宫器";
				objData[20]="";
				m_objLineArr[40].m_ObjPrintLineInfo=objData;

				#endregion 
			}
			#region 洗手护士
			ArrayList[] arlNurse=new ArrayList[9];
			for(int i=0;i<arlNurse.Length;i++)
				arlNurse[i]=new ArrayList();
			Object[] objWashNurse=new object[10];
			if(m_objCurrentPackage!=null && m_objCurrentPackage.m_objOperationNurse!=null)
			{
				for(int i=0;i<m_objCurrentPackage.m_objOperationNurse.Length;i++)
				{
					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="0"&& (arlNurse[0].Count==arlNurse[3].Count)&& arlNurse[0].Count==arlNurse[6].Count)
						arlNurse[0].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="0"&&arlNurse[0].Count>arlNurse[3].Count && arlNurse[3].Count==arlNurse[6].Count)
						arlNurse[3].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="0"&&arlNurse[0].Count==arlNurse[3].Count && arlNurse[3].Count>arlNurse[6].Count)
						arlNurse[6].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="1"&&( arlNurse[1].Count==arlNurse[4].Count)&& arlNurse[1].Count==arlNurse[7].Count)
						arlNurse[1].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="1"&&arlNurse[1].Count>arlNurse[4].Count && arlNurse[4].Count==arlNurse[7].Count)
						arlNurse[4].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="1"&&arlNurse[1].Count==arlNurse[4].Count && arlNurse[4].Count>arlNurse[7].Count)
						arlNurse[7].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="2"&& arlNurse[2].Count==arlNurse[5].Count&& arlNurse[2].Count==arlNurse[8].Count)
						arlNurse[2].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="2"&&arlNurse[2].Count>arlNurse[5].Count && arlNurse[5].Count==arlNurse[8].Count)
						arlNurse[5].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="2"&&arlNurse[2].Count==arlNurse[5].Count && arlNurse[5].Count>arlNurse[8].Count)
						arlNurse[8].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

				}
				
				for(int k=0;k<arlNurse.Length;k++)
				{
					Object[] strTemp=arlNurse[k].ToArray();
					if(strTemp.Length!=0)
					{
						for(int j=0;j<strTemp.Length;j++)
						{
							objWashNurse[k]=strTemp[j].ToString()+" ";

						}
					}
					else
					{
						objWashNurse[k]="";

					}
					
					
				}
				objWashNurse[9]="洗手护士";
			}
			else 
			{
				for(int i=0;i<objWashNurse.Length-1;i++)
				{
					objWashNurse[i]="";
				}
				objWashNurse[9]="洗手护士";
			}
			m_objLineNurse[0].m_ObjPrintLineInfo=objWashNurse ;
			#endregion

			#region 巡回护士
			arlNurse=new ArrayList[9];
			for(int i=0;i<arlNurse.Length;i++)
				arlNurse[i]=new ArrayList();
			Object[] objCircuitNurse=new object[10];
			if(m_objCurrentPackage!=null && m_objCurrentPackage.m_objOperationNurse!=null)
			{
				for(int i=0;i<m_objCurrentPackage.m_objOperationNurse.Length;i++)
				{
					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="3"&& arlNurse[0].Count==arlNurse[3].Count&& arlNurse[0].Count==arlNurse[6].Count)
						arlNurse[0].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="3"&&arlNurse[0].Count>arlNurse[3].Count && arlNurse[3].Count==arlNurse[6].Count)
						arlNurse[3].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="3"&&arlNurse[0].Count==arlNurse[3].Count && arlNurse[3].Count>arlNurse[6].Count)
						arlNurse[6].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="4"&& arlNurse[1].Count==arlNurse[4].Count&& arlNurse[1].Count==arlNurse[7].Count)
						arlNurse[1].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="4"&&arlNurse[1].Count>arlNurse[4].Count && arlNurse[4].Count==arlNurse[7].Count)
						arlNurse[4].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="4"&&arlNurse[1].Count==arlNurse[4].Count && arlNurse[4].Count>arlNurse[7].Count)
						arlNurse[7].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

					if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="5"&& arlNurse[2].Count==arlNurse[5].Count&& arlNurse[2].Count==arlNurse[8].Count)
						arlNurse[2].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="5"&& arlNurse[2].Count>arlNurse[5].Count && arlNurse[5].Count==arlNurse[8].Count)
						arlNurse[5].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);
					else if(m_objCurrentPackage.m_objOperationNurse[i].strNurseFlag=="5"&& arlNurse[2].Count==arlNurse[5].Count && arlNurse[5].Count>arlNurse[8].Count)
						arlNurse[8].Add(m_objCurrentPackage.m_objOperationNurse[i].strNurseName);

				}
				
				for(int k=0;k<arlNurse.Length;k++)
				{
					Object[] strTemp=arlNurse[k].ToArray();
					if(strTemp.Length!=0)
					{
						for(int j=0;j<strTemp.Length;j++)
						{
							objCircuitNurse[k]=strTemp[j].ToString()+ " ";

						}
					}
					else 
					{
						objCircuitNurse[k]= "";

					}
					
				}
				objCircuitNurse[9]="巡回护士";
			}
			else 
			{
				for(int i=0;i<objCircuitNurse.Length-1;i++)
				{
					objCircuitNurse[i]="";
				}
				objCircuitNurse[9]="巡回护士";
			}
			m_objLineNurse[1].m_ObjPrintLineInfo=objCircuitNurse ;
			#endregion

		}
	

		#region 有关打印的声明
		//打印行
		private clsPrintLine[] m_objLineArr;
		private clsPrintNurse[] m_objLineNurse;
		private clsPrintOperationName m_objLineOperationName;

		private clsPrintContext m_objPrintContext;
		/// <summary>
		/// 标题的字体(20 bold)
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体(14 )
		/// </summary>
		private Font m_fotHeaderFont;
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
		private int m_intYPos = 125;
		/// <summary>
		/// 打印的第几个栏目
		/// </summary>
		private int m_intPages=1;
	
		/// <summary>
		/// 格子的信息
		/// </summary>
		public enum enmRecordRectangleInfo
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 145,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 10,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 827-40,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 20,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 38,
			/// <summary>
			/// 病程记录每行的pixel长度
			/// </summary>
			RecordLineLength=520,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=12,
			/// <summary>
			/// 第一条间隔线(X)
			/// </summary>
			ColumnsMark1=129,
			/// <summary>
			/// 第二条间隔线(X)
			/// </summary>
			ColumnsMark2=173,
			ColumnsMark3=215,
			ColumnsMark4=259,

			ColumnsMark5=388,
			ColumnsMark6=431,
			ColumnsMark7=474,
			ColumnsMark8=517,

			ColumnsMark9=647,
			ColumnsMark10=689,
			ColumnsMark11=733,

			BottomY=1024,
			SmallRowStep=20,
				
		}		
     	#endregion		
		
		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
            float fltOffsetX=0;//X的偏移量
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotHeaderFont ,m_slbBrush,250f-fltOffsetX,30f);
		
			e.Graphics.DrawString("手术器械、敷料点数表",m_fotTitleFont,m_slbBrush,300f-fltOffsetX,60f);
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,20f-fltOffsetX,100f);
			e.Graphics.DrawString(m_objPrintInfo.m_strPatientName ,m_fotSmallFont,m_slbBrush,60f-fltOffsetX,100f);
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,160f-fltOffsetX,100f);
			e.Graphics.DrawString(m_objPrintInfo.m_strSex ,m_fotSmallFont,m_slbBrush,205f-fltOffsetX,100f);

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,240f-fltOffsetX,100f);
			e.Graphics.DrawString(m_objPrintInfo.m_strAge ,m_fotSmallFont,m_slbBrush,285f-fltOffsetX,100f);

			e.Graphics.DrawString("日期：",m_fotSmallFont,m_slbBrush,330f-fltOffsetX,100f);
			if(m_objPrintInfo.m_objCurrentPackage !=null && m_objPrintInfo.m_objCurrentPackage.m_objOperationEqipmentQtyXML !=null)
				e.Graphics.DrawString(DateTime.Parse(m_objPrintInfo.m_objCurrentPackage.m_objOperationEqipmentQtyXML.strCreateDate).ToString((MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmOperationEquipmentQty"))) ,
					m_fotSmallFont,m_slbBrush,380f-fltOffsetX,100f);
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,650f-fltOffsetX,100f);
			e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID,m_fotSmallFont,m_slbBrush,710f-fltOffsetX,100f);	
		}
		#endregion		

		#region 表格头脚信息
		private void m_mthSheetTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			int m_intTop=(int)enmRecordRectangleInfo.TopY;
			//画格子横线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
				m_intTop,
				(int)enmRecordRectangleInfo.RightX,
				m_intTop);
			m_intTop=m_intTop+(int)enmRecordRectangleInfo.RowStep*2;
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
				m_intTop,
				(int)enmRecordRectangleInfo.RightX,
				m_intTop);
			
			//画格子竖线
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX,m_intTop);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,m_intTop);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,m_intTop);
         
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,m_intTop);

			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.RightX,m_intTop);

			//画斜线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,m_intTop);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,m_intTop);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,m_intTop-(int)enmRecordRectangleInfo.RowStep*2,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,m_intTop);

			//表头
			e.Graphics.DrawString("数量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+65,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("术前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关后",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("数量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+65,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("术前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关后",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("数量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+65,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("术前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关前",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);
			e.Graphics.DrawString("关后",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+5);

			e.Graphics.DrawString("名称",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("清点",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("名称",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("清点",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("名称",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("清点",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("核对",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11+3,
				m_intTop-(int)enmRecordRectangleInfo.RowStep*2+(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("（第" +m_intPages+ "页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+650 ,
				1040 );
			m_intYPos=m_intTop;
			
		}

		#endregion 

		public class clsPrintOperationName : clsPrintLineBase
		{
			private clsPrintRichTextContext m_objText0;
		
			private bool m_blnFirstPrint = true;

			public clsPrintOperationName()
			{
				m_objText0 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				
			}

			

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString("手术名称：",new Font("SimSun",11) ,Brushes.Black,20f,125);
		        
					m_blnFirstPrint = false;
				}

				#region 添值

				
				m_objText0.m_mthPrintLine((int)enmRecordRectangleInfo.RightX-(int)enmRecordRectangleInfo.LeftX-120 ,120,125,p_objGrp);
				#endregion 


				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText0.m_mthRestartPrint();
								
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
						m_objText0.m_mthSetContextWithCorrectBefore(objData[0].ToString(),objData[1].ToString(),m_dtmFirstPrintTime,true);
						m_mthAddSign("手术名称：",m_objText0.m_ObjModifyUserArr);
						if(m_objText0.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText0.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText0.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText0.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}
					
					}
				}
			}
		}
	

		public class clsPrintLine : clsPrintLineBase
		{
			private clsPrintRichTextContext m_objText0;
			private clsPrintRichTextContext m_objText1;
			private clsPrintRichTextContext m_objText2;
			private clsPrintRichTextContext m_objText3;
			private clsPrintRichTextContext m_objText4;
			private clsPrintRichTextContext m_objText5;
			private clsPrintRichTextContext m_objText6;
			private clsPrintRichTextContext m_objText7;
			private clsPrintRichTextContext m_objText8;
			private Pen m_GridPen;

			private string strName0;
			private string strName1;
			private string strName2;

			private bool m_blnFirstPrint = true;

			public clsPrintLine()
			{
				m_GridPen = new Pen(Color.Black,1);
				m_objText0 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText1 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText3 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText4 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText5 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText6 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText7 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText8 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
	
			}

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_intPosY=p_intPosY+5;
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString(strName0,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+3,p_intPosY);
					p_objGrp.DrawString(strName1,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+3,p_intPosY);
					p_objGrp.DrawString(strName2,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+3,p_intPosY);

			        
					m_blnFirstPrint = false;
				}

				#region 添值

				
				m_objText0.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark2-(int)enmRecordRectangleInfo.ColumnsMark1-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+3,p_intPosY,p_objGrp);
				m_objText1.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark3-(int)enmRecordRectangleInfo.ColumnsMark2-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+3,p_intPosY,p_objGrp);
				m_objText2.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark4-(int)enmRecordRectangleInfo.ColumnsMark3-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3+3,p_intPosY,p_objGrp);
				m_objText3.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark6-(int)enmRecordRectangleInfo.ColumnsMark5-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+3,p_intPosY,p_objGrp);
				m_objText4.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark7-(int)enmRecordRectangleInfo.ColumnsMark6-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+3,p_intPosY,p_objGrp);
				m_objText5.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark8-(int)enmRecordRectangleInfo.ColumnsMark7-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+3,p_intPosY,p_objGrp);
				m_objText6.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark10-(int)enmRecordRectangleInfo.ColumnsMark9-3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9+3,p_intPosY,p_objGrp);
				m_objText7.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark11-(int)enmRecordRectangleInfo.ColumnsMark10-3 ,(int)enmRecordRectangleInfo.ColumnsMark10+3,p_intPosY,p_objGrp);
				m_objText8.m_mthPrintLine((int)enmRecordRectangleInfo.RightX-(int)enmRecordRectangleInfo.ColumnsMark11-3,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11+3,p_intPosY,p_objGrp);
				#endregion 

				if(m_objText0.m_BlnHaveNextLine()||m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()
					||m_objText3.m_BlnHaveNextLine()||m_objText4.m_BlnHaveNextLine()||m_objText5.m_BlnHaveNextLine()
					||m_objText6.m_BlnHaveNextLine()||m_objText7.m_BlnHaveNextLine()||m_objText8.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
					p_intPosY +=(int)enmRecordRectangleInfo.SmallRowStep ;
					m_intTimes++;
				}
				else
				{
					m_blnHaveMoreLine = false;
					p_intPosY += (int)enmRecordRectangleInfo.RowStep;

					#region 画格子竖线,底线
			
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY);
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY);
         
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,p_intPosY);

					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

					#endregion 
				}

			}

			public override void m_mthReset()
			{
				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText0.m_mthRestartPrint();
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
				m_objText3.m_mthRestartPrint();
				m_objText4.m_mthRestartPrint();
				m_objText5.m_mthRestartPrint();
				m_objText6.m_mthRestartPrint();
				m_objText7.m_mthRestartPrint();
				m_objText8.m_mthRestartPrint();
					
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
						strName0=objData[18].ToString();
						strName1=objData[19].ToString();
						strName2=objData[20].ToString();
						m_objText0.m_mthSetContextWithCorrectBefore(objData[0].ToString(),objData[1].ToString(),m_dtmFirstPrintTime);
						m_objText1.m_mthSetContextWithCorrectBefore(objData[2].ToString(),objData[3].ToString(),m_dtmFirstPrintTime);
						m_objText2.m_mthSetContextWithCorrectBefore(objData[4].ToString(),objData[5].ToString(),m_dtmFirstPrintTime);
						m_objText3.m_mthSetContextWithCorrectBefore(objData[6].ToString(),objData[7].ToString(),m_dtmFirstPrintTime);
						m_objText4.m_mthSetContextWithCorrectBefore(objData[8].ToString(),objData[9].ToString(),m_dtmFirstPrintTime);
						m_objText5.m_mthSetContextWithCorrectBefore(objData[10].ToString(),objData[11].ToString(),m_dtmFirstPrintTime);
						m_objText6.m_mthSetContextWithCorrectBefore(objData[12].ToString(),objData[13].ToString(),m_dtmFirstPrintTime);
						m_objText7.m_mthSetContextWithCorrectBefore(objData[14].ToString(),objData[15].ToString(),m_dtmFirstPrintTime);
						m_objText8.m_mthSetContextWithCorrectBefore(objData[16].ToString(),objData[17].ToString(),m_dtmFirstPrintTime);
				
						if(m_objText0.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText0.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText0.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText0.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}
			
						if(m_objText1.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText1.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText1.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText1.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText2.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText2.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText2.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText2.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText3.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText3.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText3.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText3.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText4.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText4.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText4.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText4.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText5.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText5.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText5.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText5.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText6.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText6.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText6.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText6.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText7.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText7.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText7.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText7.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						if(m_objText8.m_ObjModifyUserArr !=null)
							for(int i=0;i<m_objText8.m_ObjModifyUserArr.Length;i++)
							{
								if(m_objText8.m_ObjModifyUserArr[i].m_clrText.ToArgb()==Color.White.ToArgb())
									m_objText8.m_ObjModifyUserArr[i].m_clrText=Color.Black;
							}	
						
				
					}
				}
			}
		}
	
 
		public class clsPrintNurse : clsPrintLineBase
		{
			private clsPrintRichTextContext m_objText0;
			private clsPrintRichTextContext m_objText1;
			private clsPrintRichTextContext m_objText2;
			private clsPrintRichTextContext m_objText3;
			private clsPrintRichTextContext m_objText4;
			private clsPrintRichTextContext m_objText5;
			private clsPrintRichTextContext m_objText6;
			private clsPrintRichTextContext m_objText7;
			private clsPrintRichTextContext m_objText8;
			private Pen m_GridPen;

			private string strName0;
		
			private bool m_blnFirstPrint = true;

			public clsPrintNurse()
			{
				m_GridPen = new Pen(Color.Black,1);
				m_objText0 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText1 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText2 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText3 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText4 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText5 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText6 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText7 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				m_objText8 = new clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
	
			}

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_intPosY=p_intPosY+5;
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString(strName0,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+3,p_intPosY);
					p_objGrp.DrawString(strName0,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+3,p_intPosY);
					p_objGrp.DrawString(strName0,new Font("SimSun",11) ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+3,p_intPosY);
			        
					m_blnFirstPrint = false;
				}

				#region 添值

				
				m_objText0.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark2-(int)enmRecordRectangleInfo.ColumnsMark1 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,p_objGrp);
				m_objText1.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark3-(int)enmRecordRectangleInfo.ColumnsMark2 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,p_objGrp);
				m_objText2.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark4-(int)enmRecordRectangleInfo.ColumnsMark3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY,p_objGrp);
				m_objText3.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark6-(int)enmRecordRectangleInfo.ColumnsMark5 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY,p_objGrp);
				m_objText4.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark7-(int)enmRecordRectangleInfo.ColumnsMark6 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY,p_objGrp);
				m_objText5.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark8-(int)enmRecordRectangleInfo.ColumnsMark7 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY,p_objGrp);
				m_objText6.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark10-(int)enmRecordRectangleInfo.ColumnsMark9+3 ,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY,p_objGrp);
				m_objText7.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark11-(int)enmRecordRectangleInfo.ColumnsMark10+3 ,(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,p_objGrp);
				m_objText8.m_mthPrintLine((int)enmRecordRectangleInfo.RightX-(int)enmRecordRectangleInfo.ColumnsMark11+3,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY,p_objGrp);
				#endregion 

				if(m_objText0.m_BlnHaveNextLine()||m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()
					||m_objText3.m_BlnHaveNextLine()||m_objText4.m_BlnHaveNextLine()||m_objText5.m_BlnHaveNextLine()
					||m_objText6.m_BlnHaveNextLine()||m_objText7.m_BlnHaveNextLine()||m_objText8.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
					p_intPosY +=(int)enmRecordRectangleInfo.SmallRowStep ;
					m_intTimes++;
				}
				else
				{
					m_blnHaveMoreLine = false;
					p_intPosY += (int)enmRecordRectangleInfo.RowStep;

					#region 画格子竖线,底线
			
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX,p_intPosY);
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY);
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY);
         
					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY);

					p_objGrp.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,p_intPosY);

					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

					#endregion 
				}

			}

			public override void m_mthReset()
			{
				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText0.m_mthRestartPrint();
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
				m_objText3.m_mthRestartPrint();
				m_objText4.m_mthRestartPrint();
				m_objText5.m_mthRestartPrint();
				m_objText6.m_mthRestartPrint();
				m_objText7.m_mthRestartPrint();
				m_objText8.m_mthRestartPrint();
					
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
						strName0=objData[9].ToString();
						m_objText0.m_mthSetContextWithAllCorrect(objData[0].ToString(),"");
						m_objText1.m_mthSetContextWithAllCorrect(objData[1].ToString(),"");
						m_objText2.m_mthSetContextWithAllCorrect(objData[2].ToString(),"");
						m_objText3.m_mthSetContextWithAllCorrect(objData[3].ToString(),"");
						m_objText4.m_mthSetContextWithAllCorrect(objData[4].ToString(),"");
						m_objText5.m_mthSetContextWithAllCorrect(objData[5].ToString(),"");
						m_objText6.m_mthSetContextWithAllCorrect(objData[6].ToString(),"");
						m_objText7.m_mthSetContextWithAllCorrect(objData[7].ToString(),"");
						m_objText8.m_mthSetContextWithAllCorrect(objData[8].ToString(),"");
					}
				}
			}
		}
	
	
		#endregion 
//
//		/// <summary>
//		/// 危重护理的打印信息.
//		/// </summary>
//		[Serializable]			
//		private class clsPrintInfo_OperationEquipmentQty
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
//			public clsOperationEquipmentPackage m_objCurrentPackage;			
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
		//		clsOperationEquipmentQtyPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsOperationEquipmentQtyPrintTool();
		//			objPrintTool.m_mthInitPrintTool(null);	
		//			if(m_objBaseCurrentPatient==null)
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
		//			else if(this.trvTime.SelectedNode ==null || this.trvTime.SelectedNode==trvTime.Nodes[0])
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
		//			else 
		//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse(trvTime.SelectedNode.Tag.ToString()));
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
		//			objPrintTool=new clsOperationEquipmentQtyPrintTool();
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