using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 危重护理的打印工具类,Jacky-2003-6-5
	/// </summary>
	/// 


/*谢桂军  
 * 打印部分的基本思想如下：
 *1、填充打印数护(m_intSetPrintOneValueRows)：摄入，排出在打印时可能占用多行，为了打印方便在内存中填充了
 *二维数组m_strValueArr。打印时直接输出数组中的值（含空白值）
 * 2、记录打印：(m_mthAddDataToGrid)控制所有记录的打印，换页
 * (m_blnPrintOneValue)打印一条记录。
 * (m_blnPrintOneRowValue)被m_blnPrintOneValue调用，打印一条主记录及其轨迹
 * （m_blnPrintOneRowValueOfSummary）被m_blnPrintOneRowValue调用,打印统计信息
 * 
 * */
	public class clsIntensiveTendMainPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsRecordsDomain m_objRecordsDomain;
		private clsPrintInfo_IntensiveTend m_objPrintInfo;
		
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
			m_objPrintInfo=new clsPrintInfo_IntensiveTend();
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
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{			
			if(m_objPrintInfo==null)
			{
				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatentID=="")
				return;
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.IntensiveTend);
				
			long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_objTransDataArr,out m_objPrintInfo.m_dtmFirstPrintDateArr,out m_objPrintInfo.m_blnIsFirstPrintArr);
			if(lngRes <= 0)
				return ;   

			//按记录时间(CreateDate)排序 
			m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
			//设置表单内容到打印中
			m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr,m_objPrintInfo.m_dtmFirstPrintDateArr);			
			m_objPrintInfo.m_objPrintDataArr=m_objPrintDataArr;
			m_blnWantInit=false;
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_IntensiveTend")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_IntensiveTend)p_objPrintContent;
			m_objPrintDataArr= m_objPrintInfo. m_objPrintDataArr ;		
			
			m_blnWantInit=false;
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

			//没有记录内容时，返回空
			if(m_objPrintInfo.m_objPrintDataArr == null || m_objPrintInfo.m_objPrintDataArr.Length == 0)
				return null;
			else
				return m_objPrintInfo;
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 15f);
			m_fotSmallFont = new Font("SimSun",12f);
			m_fotTinyFont=new Font("SimSun",9f);

			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
		
			m_objPageSetting = new clsPrintPageSettingForRecord();

            m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fotSmallFont);			
		
			m_objPrintLenth=new clsPrintLenth_IntensiveTendRecord();
			m_objPrintLenth.m_intPrintLenth_BloodPressure = (int) ((float)(enmRecordRectangleInfo.ColumnsMark6-enmRecordRectangleInfo.ColumnsMark5)/2/8.75)+1;//血压，先分一半，添充字母
			m_objPrintLenth.m_intPrintLenth_Breath = (int) ((float)(enmRecordRectangleInfo.ColumnsMark5-enmRecordRectangleInfo.ColumnsMark4)/8.75)+1;
			m_objPrintLenth.m_intPrintLenth_Echo = (int) ((float)(enmRecordRectangleInfo.ColumnsMark9-enmRecordRectangleInfo.ColumnsMark8)/8.75)+1;		
			m_objPrintLenth.m_intPrintLenth_In = (int) ((float)(enmRecordRectangleInfo.ColumnsMark12-enmRecordRectangleInfo.ColumnsMark11)/8.75)+1;		
			m_objPrintLenth.m_intPrintLenth_Out = (int) ((float)(enmRecordRectangleInfo.ColumnsMark14-enmRecordRectangleInfo.ColumnsMark13)/8.75)+1;
			m_objPrintLenth.m_intPrintLenth_Pulse = (int) ((float)(enmRecordRectangleInfo.ColumnsMark4-enmRecordRectangleInfo.ColumnsMark3)/8.75)+1;
			m_objPrintLenth.m_intPrintLenth_Pupil = (int) ((float)(enmRecordRectangleInfo.ColumnsMark7-enmRecordRectangleInfo.ColumnsMark6)/8.75)+1;
			m_objPrintLenth.m_intPrintLenth_RecordContent = (int) ((float)(enmRecordRectangleInfo.ColumnsMark15-enmRecordRectangleInfo.ColumnsMark14-6)/17.5)+1;//病程记录，填充汉字
			m_objPrintLenth.m_intPrintLenth_Temperature = (int) ((float)(enmRecordRectangleInfo.ColumnsMark3-enmRecordRectangleInfo.ColumnsMark2)/8.75)+1;
					
			m_intCurrentRecord=0;
			intNowPage=1;
			blnBeginPrintNewRecord=true;

		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont.Dispose();
			m_fotTinyFont.Dispose();
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
			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
		}
		
		public void m_mthPrintPage()
		{
			frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
			frmPreview.m_evtBeginPrint +=new PrintEventHandler(frmPreview_m_evtBeginPrint);
			frmPreview.m_evtEndPrint +=new PrintEventHandler(frmPreview_m_evtEndPrint);
			frmPreview.m_evtPrintContent +=new PrintPageEventHandler(frmPreview_m_evtPrintContent);
			frmPreview.m_evtPrintFrame +=new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
			frmPreview.ShowDialog();
		}
		#region  续打事件
		private void frmPreview_m_evtBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthBeginPrint(e);
		}
		private void frmPreview_m_evtEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthEndPrint(e);
		}
		private void frmPreview_m_evtPrintContent(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthAddDataToGrid(e);
		}
		private void frmPreview_m_evtPrintFrame(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthPrintTitleInfo(e);	
			m_mthPrintRectangleInfo(e);	
			m_mthPrintHeaderInfo(e);
		}
		#endregion

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{			
			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="") return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrintArr != null)
			{
				ArrayList arlRecordType = new ArrayList();
				ArrayList arlOpenDate = new ArrayList();
				int intUpdateIndex = -1;//若没有任何记录
				for(int i=0;i<m_objPrintInfo.m_blnIsFirstPrintArr.Length;i++)
				{
					if(m_objPrintInfo.m_blnIsFirstPrintArr[i])
					{    
						//更新记录，只需使用新的首次打印时间作为有效的输入参数。
						//存放记录类型
						arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
						//存放记录的OpenDate
						arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);			
						intUpdateIndex = i;
					}
				}   

				if(intUpdateIndex >= 0)
				{
					m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),(int[])arlRecordType.ToArray(typeof(int)),(DateTime[])arlOpenDate.ToArray(typeof(DateTime)),m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
				}
				#region 如果是预览，则不应该执行，否则预览后打印会出错，因为没有重新初始化
				m_objPrintInfo.m_objTransDataArr = null;
				m_objPrintInfo.m_blnIsFirstPrintArr = null;
				#endregion
			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
		}	
	
		private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDate)
		{
			try
			{
				if(p_objTransDataArr==null || p_dtmFirstPrintDate==null ||p_objTransDataArr.Length !=p_dtmFirstPrintDate.Length)
				{
					clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
					return;
				}			

				//根据不同的表单类型，获取对应的clsDiseaseTrackInfo
				clsDiseaseTrackInfo objTrackInfo=null;
				m_objPrintDataArr = new clsIntensiveTendDataInfo[p_objTransDataArr.Length];		
//				m_objPrintDataArr=(clsIntensiveTendDataInfo[])(p_objTransDataArr.Clone());
				ArrayList arlTemp = new ArrayList();
				arlTemp.AddRange(p_objTransDataArr);
				m_objPrintDataArr = (clsIntensiveTendDataInfo[])arlTemp.ToArray(typeof(clsIntensiveTendDataInfo));
				
				//System.Data.DataTable dtbBlankRecord = null;
				//new clsDiseaseTrackAddBlankDomain().m_lngGetBlankRecordContent(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate,out dtbBlankRecord);

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
//			for(int i=0;i<p_objTransDataArr.Length;i++)
//			{				
//				objTrackInfo = new clsIntensiveRecordInfo();				
//		
//				//设置clsDiseaseTrackInfo的内容
//				objTrackInfo.m_ObjRecordContent = p_objTransDataArr[i].m_objRecordContent;
//		
//				m_objPrintDataArr[i]=new clsIntensiveTendDataInfo();
//				m_objPrintDataArr[i].m_objRecordContent.m_dtmCreateDate=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
//				//根据 clsDiseaseTrackInfo 获得的文本和Xml
//				m_objPrintDataArr[i].m_objRecordContent.m_strContent = objTrackInfo.m_strGetTrackText(); 
//				m_objPrintDataArr[i].m_strContentXml = objTrackInfo.m_strGetTrackXml();
//				
//				clsEmployee objEmployee= new clsEmployee(objTrackInfo.m_ObjRecordContent.m_strModifyUserID);
//				string strSignText="";
//				if(objEmployee !=null)
//					strSignText = objEmployee.m_StrLastName;
//
//				m_objPrintDataArr[i].m_strSign = strSignText;
//				m_objPrintDataArr[i].m_strSignXml = "<Root />";
//				
//				m_objPrintDataArr[i].m_objRecordContent.m_dtmFirstPrintDate=p_dtmFirstPrintDate[i];
//			}
		}

		/// <summary>
		/// 按记录顺序(CreateDate)把输入的p_objTansDataInfoArr排序
		/// </summary>
		/// <param name="p_objTansDataInfoArr"></param>
		private void m_mthSortTransData(ref clsTransDataInfo[] p_objTansDataInfoArr)
		{
			ArrayList m_arlSort = new ArrayList(p_objTansDataInfoArr);
			m_arlSort.Sort();
			p_objTansDataInfoArr = (clsTransDataInfo[])m_arlSort.ToArray(typeof(clsTransDataInfo));
		}

		private  void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			if(m_objPrintInfo.m_objTransDataArr == null)
				m_mthInitPrintContent();
		}
		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			try
			{
				p_objPrintPageArg.HasMorePages =false;
				m_mthPrintTitleInfo(p_objPrintPageArg);
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);
				m_mthAddDataToGrid(p_objPrintPageArg);
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

			}
		}

		

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			m_intCurrentRecord=0;
			intNowPage=1;
			blnBeginPrintNewRecord=true;
			m_intRowNumberForPrintData = 0;
			m_intPosY = (int)enmRecordRectangleInfo.TopY+130;
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsEveryRecordPageInfo objEveryRecordPageInfo=new clsEveryRecordPageInfo ();
			//************************************************			
			objEveryRecordPageInfo.strAge =m_objPrintInfo.m_strAge;
			objEveryRecordPageInfo.strPatientName=m_objPrintInfo.m_strPatientName;
			objEveryRecordPageInfo.strBedNo =m_objPrintInfo.m_strBedName;
			objEveryRecordPageInfo.strAreaName=m_objPrintInfo.m_strAreaName;
			objEveryRecordPageInfo.strSex=m_objPrintInfo.m_strSex;
			objEveryRecordPageInfo.strInPatientID=m_objPrintInfo.m_strHISInPatientID;
			objEveryRecordPageInfo.strPrintDate=( m_objPrintInfo.m_strInPatentID!="")? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		
			
            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("危 重 患 者 护 理 记 录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAreaName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
			
			//在最后一行下面打印说明部分
			e.Graphics.DrawString("出入量代码:U--尿 S--大便 V--呕吐物 E--引流液 D--进食 I--输液",m_fotSmallFont,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark2,
				(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*((int)enmRecordRectangleInfo.RowLinesNum+1)-20);

		}
		#endregion
		
		#region 画标题的栏目
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			e.Graphics.DrawString("日期",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+15,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
		     
			e.Graphics.DrawString("时间",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);

			//体温 C			
			e.Graphics.DrawString("体",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+2);
			e.Graphics.DrawString("温",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawString("。",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY-10+2*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawString("C",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+9, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+1);

			//脉搏(次/分)
			e.Graphics.DrawString("脉",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+1, (int)enmRecordRectangleInfo.TopY+2);
			e.Graphics.DrawString("搏",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+10);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+5, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep-9);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+11);

			//呼吸(次/分)
			e.Graphics.DrawString("呼",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+2);
			e.Graphics.DrawString("吸",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+10);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+5, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep-9);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+11);

			//血压(mmHg)
			e.Graphics.DrawString("血压",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+8, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
	
			e.Graphics.DrawString(" 瞳 孔",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+31, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("大小",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+10, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5-10);
			e.Graphics.DrawString("(mm)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+10, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5+10);
			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);


			e.Graphics.DrawString("反射",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+18, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("摄入",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+1, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("种",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("类",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark11+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("ml",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark11+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);


			e.Graphics.DrawString("排出",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+1, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("种",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("类",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("ml",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);


			e.Graphics.DrawString("病 程 记 录",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+25, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
	
			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
		
		
		}
		#endregion

		#region 画格子
		/// <summary>
		///  画格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			
			//画格子横线
			for(int i1=0;i1<=(int)enmRecordRectangleInfo.RowLinesNum ;i1++)
			{
				if(i1 !=1 && i1 !=2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1);
				else if(i1==1)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1-8,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark14,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1-8);
				else //if(i1==2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark10,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1);
			}
			
			#region 画格子竖线
			int intHeight=((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep;
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY+intHeight);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+intHeight);						
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+intHeight);
			#endregion

			//画对角线（血压）
			for(int i1=3;i1<(int)enmRecordRectangleInfo.RowLinesNum ;i1++)//斜线只需要从第四行开始到倒数第二行
			{
				e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark6,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
					(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark5,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*(i1+1));					
			}	
			
		}

						
		#endregion
		
		#region 设置当前要打印的一条记录数据
		/// <summary>
		/// 设置当前要打印的一条记录数据
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private int m_intSetPrintOneValueRows(PrintPageEventArgs e,ref int p_intBottomY)
		{			
			if(m_objPrintDataArr==null || m_intCurrentRecord>= m_objPrintDataArr.Length)
				return 0;
	
			int intRowsOfOneRecord;
			string strModifyDate;
		
			try
			{
				#region 如果是新记录，判断是否保留痕迹
				int intLenth;
				if(m_blnBeginPrintNewRecord==true) 
				{									
					#region 当前记录数组赋值
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.IntensiveTend && 
						m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
					{
						intLenth = 2;
						intRowsOfOneRecord = intLenth;
						strModifyDate = "";
						m_strValueArr=new string[intLenth][];
						m_strValueArr[0]=new string[14];
						m_strValueArr[0][0]="";
						m_strValueArr[0][1]="";
						m_strValueArr[0][2]="";
						m_strValueArr[0][3]="";
						m_strValueArr[0][4]="";
						
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == 
							DateTime.MaxValue)
							m_strValueArr[0][5]="合共";
						else
							m_strValueArr[0][5]="按日";
						m_strValueArr[0][6]="分类";
						m_strValueArr[0][7]="总计:";
						m_strValueArr[0][8]="摄入";
						m_strValueArr[0][9]= (m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In.ToString());
						m_strValueArr[0][10]="排出";
						m_strValueArr[0][11]= (m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out.ToString());
						m_strValueArr[0][12]="";
						m_strValueArr[0][13]="";
					
						return intLenth;
					}
					else
					{
						intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;

						strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].
									  m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
						intLenth=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;

						//临时存储数据
						ArrayList m_RecordInfo=new ArrayList();
						int m_intAllRecords=0;
						for(int k1=0;k1<intLenth;k1++)
						{
							clsIntensiveTendRecordContent1 m_objCurrent=
								m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1];

							//以下三个变量分别记载了摄入，排出，病程记录的记录数
							int intIn_Count=0;
							int intOut_Count=0;
							int intContent_Count=0;
							int intMaxCount=0;
					
							ArrayList objIn=new ArrayList();
							ArrayList objOut=new ArrayList();

					#region 获得当前记录的最大行数
							//进食
							string[] strInfo0=new String[3];
							if(m_objCurrent.m_intInD!=0)
							{
								strInfo0[0]="D";
								strInfo0[1]=(m_objCurrent.m_intInD == 0?"":m_objCurrent.m_intInD.ToString()) ;
								strInfo0[2]=m_objCurrent.m_strInDXML;

								objIn.Add(strInfo0);

								intIn_Count++;
							}
				 
							//输液
							string[] strInfo1=new String[3];
							if(m_objCurrent.m_intInI!=0)
							{
								strInfo1[0]="I";
								strInfo1[1]=(m_objCurrent.m_intInI == 0?"":m_objCurrent.m_intInI.ToString());
								strInfo1[2]=m_objCurrent.m_strInIXML;

								objIn.Add(strInfo1);

								intIn_Count++;
							}

							//引流液
							string[] strInfo2=new String[3];
							if(m_objCurrent.m_intOutE!=0)
							{
								strInfo2[0]="E";
								strInfo2[1]=(m_objCurrent.m_intOutE == 0?"":m_objCurrent.m_intOutE.ToString()) ;
								strInfo2[2]=m_objCurrent.m_strOutEXML;

								objOut.Add(strInfo2);

								intOut_Count++;
							}
			
							//大便
							string[] strInfo3=new String[3];
							if(m_objCurrent.m_intOutS!=0)
							{
								strInfo3[0]="S";
								strInfo3[1]=(m_objCurrent.m_intOutS == 0?"":m_objCurrent.m_intOutS.ToString()) ;
								strInfo3[2]=m_objCurrent.m_strOutSXML;

								objOut.Add(strInfo3);

								intOut_Count++;
							}

							//尿
							string[] strInfo4=new String[3];
							if(m_objCurrent.m_intOutU!=0)
							{
								strInfo4[0]="U";
								strInfo4[1]=(m_objCurrent.m_intOutU == 0?"":m_objCurrent.m_intOutU.ToString()) ;
								strInfo4[2]=m_objCurrent.m_strOutUXML;

								objOut.Add(strInfo4);

								intOut_Count++;
							}

							//呕吐物
							string[] strInfo5=new String[3];
							if(m_objCurrent.m_intOutV!=0)
							{
								strInfo5[0]="V";
								strInfo5[1]=(m_objCurrent.m_intOutV == 0?"":m_objCurrent.m_intOutV.ToString());
								strInfo5[2]=m_objCurrent.m_strOutVXML;

								objOut.Add(strInfo5);

								intOut_Count++;
							}

							//病程记录
							//string strCase = m_objCurrent.m_strRecordContent ;
							string strCase="";
							//只显示原始值，没有则为空。tfzhang 更改 2005-7-19 9:57:08
//							if (m_objCurrent.m_strRecordContent_Right.Trim().Length==0 || m_objCurrent.m_strRecordContent==m_objCurrent.m_strRecordContent_Right)
//								strCase = m_objCurrent.m_strRecordContent ;
//							else
                            strCase = "";// m_objCurrent.m_strRecordContent_Right;
                            string strCaseXML = "";//m_objCurrent.m_strRecordContentXml ;
							string[] strCaseTextArr,strCaseXmlArr;
							com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml(strCase,strCaseXML,10,out strCaseTextArr,out strCaseXmlArr);
							int intCaseCount = strCaseTextArr.Length;
							intContent_Count=intCaseCount;

							if(intMaxCount<intIn_Count)
								intMaxCount=intIn_Count;
							if(intMaxCount<intOut_Count)
								intMaxCount=intOut_Count;
							if(intMaxCount<intContent_Count)
								intMaxCount=intContent_Count;
			
							if(intMaxCount == 0)
								intMaxCount = 1;

							///累计行数
							m_intAllRecords+=intMaxCount;

					#endregion

							for(int k2=0;k2<intMaxCount;k2++)
							{
								//m_strValue[14]用来判断记录是否是新记录
								string[] m_strValue=new String[15];
								if(k2>0)
								{
									m_strValue[0]="";
									m_strValue[1]="";
									m_strValue[2]="";
									m_strValue[3]="";
									m_strValue[4]="";
									m_strValue[5]="";
									m_strValue[6]="";
									m_strValue[7]="";
									m_strValue[8]="";
									
								}
								else
								{
									m_strValue[0]=m_objCurrent.m_strTemperature;
									m_strValue[1]=m_objCurrent.m_strPulse;
									m_strValue[2]=m_objCurrent.m_strBreath;
									m_strValue[3]=m_objCurrent.m_strBloodPressureS;
									m_strValue[4]=m_objCurrent.m_strBloodPressureA;
									m_strValue[5]=m_objCurrent.m_strPupilLeft;
									m_strValue[6]=m_objCurrent.m_strPupilRight;
									m_strValue[7]=m_objCurrent.m_strEchoLeft;
									m_strValue[8]=m_objCurrent.m_strEchoRight;
								}

								if(k2<intIn_Count)
								{
									m_strValue[9]=((string[])objIn[k2])[0];
									m_strValue[10]=((string[])objIn[k2])[1];
								}
								else
								{
									m_strValue[9]="";
									m_strValue[10]="";
								
								}
								if(k2<intOut_Count)
								{
									m_strValue[11]=((string[])objOut[k2])[0];
									m_strValue[12]=((string[])objOut[k2])[1];
								}
								else
								{
									m_strValue[11]="";
									m_strValue[12]="";

								}
								if(k2 < intCaseCount)
								{
									m_strValue[13]=strCaseTextArr[k2]==null?"": strCaseTextArr[k2];
									
								}
								else
								{
									m_strValue[13]="";
								}

								if(k2==0)
									m_strValue[14]="1";
								else
									m_strValue[14]="0";
								m_RecordInfo.Add(m_strValue);

							}
						}


						m_strValueArr=new string[m_intAllRecords][];
						for(int m=0;m<m_intAllRecords ;m++)
							m_strValueArr[m]=(string[])m_RecordInfo[m];
						
						return intLenth;
					}
					#endregion
				}
				else 
					return 0;
				#endregion
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
				return 1;
			}			
		}
		#endregion
	
		/*记录该页当前的打印的行*/
		int intNowRow=1; 

		/*记录当前打印的主记录在m_objPrintDataArr中的序号，便于换页后接着打印*/
		private int m_intRowNumberForPrintData=0;
		
		#region 填充数据到表格		
		/// <summary>
		/// 填充数据到表格
		/// </summary>
		/// <param name="e"></param>
		private void m_mthAddDataToGrid(System.Drawing.Printing.PrintPageEventArgs e)
		{  
			string strRecord="";			
			string strRecordXML="";			
			DateTime dtmFlagTime;
			/*记录该页当前的打印的行*/
			intNowRow=1; 			

			
			//页脚//////////////////////////////////////////////////////////////
//			e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
//				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*((
//				int)enmRecordRectangleInfo.RowLinesNum+1)+(int)enmRecordRectangleInfo.VOffSet );
			e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
				(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*((int)enmRecordRectangleInfo.RowLinesNum+1)-20);
           		
			if(m_objPrintInfo.m_strInPatentID ==""|| m_objPrintDataArr==null)return;

			m_intCurrentRecord=0;

			//打印主循环
			for(m_intCurrentRecord=m_intRowNumberForPrintData;m_intCurrentRecord<m_objPrintDataArr.Length ;m_intCurrentRecord++)
			{
			
				if(blnBeginPrintNewRecord)
					m_intSetPrintOneValueRows(e,ref m_intPosY);
				enmReturnValue m_enmRe= m_blnPrintOneValue(e, m_intPosY);	

				//根据返回值处理换页情况
				if (m_enmRe == enmReturnValue.enmFaild)
						e.HasMorePages=false;
				if(m_enmRe==enmReturnValue.enmNeedNextPage)
				{
					m_intRowNumberForPrintData=m_intCurrentRecord;
					 m_intPosY = (int)enmRecordRectangleInfo.TopY+130;
					e.HasMorePages=true;
					return;
				}

				if(m_enmRe==enmReturnValue.enmSuccessed)
				{
					e.HasMorePages=false;
					blnBeginPrintNewRecord=true;
				}

				try
				{
					#region 如果是新记录，打印日期，设置打印数据值
					if(blnBeginPrintNewRecord)
					{
						
						//打印一条记录/////////////////////////////////////////////////////////////////////
						/*修改打印内容方式（以第一次打印时间为分割，该时间后的所有修改的痕迹都要保留，
						 * 如从未打印过则显示正确的记录）*/				
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmFirstPrintDate==
							DateTime.MinValue)
							dtmFlagTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
						else 
							dtmFlagTime=m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmFirstPrintDate;
						
						m_objPrintContext.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);

                        com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr =
							m_objPrintContext.m_ObjModifyUserArr;

						for(int i=0;i< m_objModifyUserArr.Length;i++)
						{
							if(m_objModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
							{
								m_objModifyUserArr[i].m_clrText = Color.Black;
							}
						}

					}
					#endregion
				}
				catch(Exception ex)
				{
					clsPublicFunction.ShowInformationMessageBox(ex.Message);
				}					
			
//			#region 打印完毕，ReSet(复位)操作
//			if(m_intCurrentRecord==m_objPrintDataArr.Length)
//			{				
//				m_intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
//				blnBeginPrintNewRecord=true;//复位
//				intNowPage=1;//复位						
//			}
//			
//			#endregion
			}	
		}

		
		#region 只打印一行
		/// <summary>
		/// 只打印一行
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private enmReturnValue m_blnPrintOneValue(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			//m_intPosY +=(int)enmRecordRectangleInfo.VOffSet;
			#region 如果是新记录，打印日期

			if(m_blnBeginPrintNewRecord==true) 
				{
					m_intNowRowInOneRecord=0;

					//读出日期
					string strCreateDate;
					string strCreateTime;
					string strCreateDateTime;
				
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.IntensiveTend && 
						m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
					{
						strCreateDate = "";
						strCreateTime = "";
						strCreateDateTime = "";
					}
					else
					{
						strCreateDateTime=m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate.
							ToString("yyyy-MM-dd HH:mm:ss");
						try
						{
							strCreateDate=DateTime.Parse(strCreateDateTime).ToString("yyyy-M-d");
							strCreateTime=DateTime.Parse(strCreateDateTime).ToString("HH:mm");
						}
						catch
						{strCreateDate="不详";strCreateTime="不详";}	
					}
					//开始打印一条新记录/////////////////////////////////////////////////////////////////////
					e.Graphics.DrawString(strCreateDate,m_fotSmallFont ,m_slbBrush,
						(int)enmRecordRectangleInfo.LeftX, 
						m_intPosY);	
					e.Graphics.DrawString(strCreateTime,m_fotSmallFont ,m_slbBrush,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+1, 
						m_intPosY );	
				}
			#endregion			
			
			enmReturnValue enmIsRecordFinish=m_blnPrintOneRowValue(m_strValueArr,m_intNowRowInOneRecord,e);
			
			if(enmIsRecordFinish!=enmReturnValue.enmNeedNextPage)
			{
				m_intRowNumberInValueArr=0;
				m_intRowNumberInTempArr=0;
			}

//			#region 签名（作过修改的人签名）
//				string strSign;
//			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && 
//				m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
//				strSign = "";
//			else
//			{
//				strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].
//					m_strModifyUserName;			
//				m_intPosY += intTempDeltaY;
//			}
//			
//			
//				e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
//					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+1, 
//					m_intPosY);
//			#endregion

//			m_blnBeginPrintNewRecord=blnIsRecordFinish;//当前记录是否打完					
			m_intNowRowInOneRecord++;
			
			return enmIsRecordFinish;			
		}

		#endregion
	

		/// <summary>
		/// 检查是否换页,true:换页，false:不换页
		/// </summary>
		/// <param name="p_intNowRow">当前打印行，第p_intNowRow行</param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool m_blnCheckPageChange(int p_intNowRow,System.Drawing.Printing.PrintPageEventArgs e)
		{
			//当当前行超过最后一行（即 >页总行数）时换页
			if(p_intNowRow>(int)enmRecordRectangleInfo.RowLinesNum-3/*除去表头3行外总有效行数*/) 
			{
				intNowPage ++;

				return true;
			}
			else return false;
		}
 
		#endregion 						

		#region 有关打印的声明
		/// <summary>
		/// 所有打印的数据
		/// </summary>
		private clsIntensiveTendDataInfo[] m_objPrintDataArr;

		/// <summary>
		/// （基于危重护理记录的）打印上下文的类
		/// </summary>		
        private com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext;
		/// <summary>
		/// 每行显示的汉字（病程记录）或字母（其他）的数目
		/// </summary>
		private class clsPrintLenth_IntensiveTendRecord
		{
			public int m_intPrintLenth_RecordContent;
			public int m_intPrintLenth_Temperature;
			public int m_intPrintLenth_Breath;
			public int m_intPrintLenth_Pulse;
			public int m_intPrintLenth_BloodPressure;			
			public int m_intPrintLenth_Pupil;	//瞳孔（大小）		
			public int m_intPrintLenth_Echo;	//反射		
			public int m_intPrintLenth_In;//摄入
			public int m_intPrintLenth_Out;	//排出		
		}

		/// <summary>
		/// 当前行的Y坐标
		/// </summary>
		int m_intPosY = (int)enmRecordRectangleInfo.TopY+130;
		/// <summary>
		/// 每行数据行的高度
		/// </summary>
		int intTempDeltaY = 40;	


		private clsPrintLenth_IntensiveTendRecord m_objPrintLenth;
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
		/// 最小的字体
		/// </summary>
		private Font m_fotTinyFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush;
		/// <summary>
		/// 记录打印到第几页
		/// </summary>
		private int intNowPage=1;
		/// <summary>
		/// 当前打印的记录的序号
		/// </summary>
		private int m_intCurrentRecord=0;  
		
		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool m_blnBeginPrintNewRecord=true;		

		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool blnBeginPrintNewRecord=true;	
	
		/// <summary>
		/// 当前记录的行序数（修改的次第数）
		/// </summary>
		private int m_intNowRowInOneRecord=0; 	

		/// <summary>
		/// （若要保留历史痕迹）当前记录内容
		/// </summary>
		private string[][] m_strValueArr;

		/// <summary>
		/// 要打印的所有的护理记录
		/// </summary>
		//private clsIntensiveTendRecord [] objGeneralTendRecordForPrint=null;
		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;
		/// <summary>
		/// 打印的病人基本信息类
		/// </summary>
		private class clsEveryRecordPageInfo
		{
			public string strPatientName;
			public string strSex;
			public string strAge;
			public string strBedNo;
			public string strAreaName;
			public string strInPatientID;
			//public int intCurrentPate;
			//public int intTotalPages;
			public string strPrintDate;
		}

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRecordRectangleInfo
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 150,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 8,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 820-32,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 40,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 21,			
			/// <summary>
			/// 文字在格子中相对格子顶端的垂直偏移
			/// </summary>
			VOffSet = 22,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=16,
			/// <summary>
			/// 第一条间隔线(X)
			/// </summary>
			ColumnsMark1=85,
			/// <summary>
			/// 第二条间隔线(X)
			/// </summary>
			ColumnsMark2=135,
			ColumnsMark3=170,
			ColumnsMark4=200,
			ColumnsMark5=230,
			ColumnsMark6=290,
			ColumnsMark7=325,
			ColumnsMark8=360,
			ColumnsMark9=400,
			ColumnsMark10=440,
			ColumnsMark11=465,
			ColumnsMark12=495,
			ColumnsMark13=520,
			ColumnsMark14=550,
			ColumnsMark15=725				
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
			//填充表格元素
			RecordDate,
			RecordTime,
			RecordContent,
			RecordSign1,
			RecordSign2,			
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
						m_fReturnPoint = new PointF(320f,30f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(225f,70f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(20f,120f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(70f,120f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(160f,120f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(210f,120f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(240f,120f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(280f,120f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(365f,120f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(415f,120f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(570f,120f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(620f,120f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(660f,120f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(720f,120f);
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


		//以下两个变量用来与m_intRowNumberForPrintData配合起来，控制系统在换页后继续上一页的打印
		/// <summary>
		/// 记录在新的一页需要打印的第一条记录在打印数组strValueArr中的序号
		/// </summary>
		private int m_intRowNumberInValueArr=0;

		/// <summary>
		/// 记录在新的一页需要打印的第一条记录在TempArr数中组的序号
		/// </summary>
		private int m_intRowNumberInTempArr=0;
		
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private enmReturnValue m_blnPrintOneRowValue(string [][] p_strValueArr,int p_intIndex,
			System.Drawing.Printing.PrintPageEventArgs e)
		{			
			//string [] strValueArr = p_strValueArr[p_intIndex];
			string[][] strValueArr = p_strValueArr;

			if(p_strValueArr[0][7] == "总计:")
			{
				return m_blnPrintOneRowValueOfSummary(p_strValueArr,e,m_intPosY);
			}

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			#region 打印一条记录占用几行的情况
			clsIntensiveTendDataInfo m_objTemp=(clsIntensiveTendDataInfo)m_objPrintInfo.m_objTransDataArr[m_intCurrentRecord];

			//n用来维护与报表中的二维表格相对应的内存数据行。
			for(int n=m_intRowNumberInValueArr,m=m_intRowNumberInTempArr;n<strValueArr.GetLength(0) && m<m_objTemp.m_objTransDataArr.Length;n++)
			{
									
				if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
				{
					m_intRowNumberInValueArr=n;
					m_intRowNumberInTempArr=m;

					return enmReturnValue.enmNeedNextPage;
					//换页
					
				}
				
				//检测是否已碰到新记录。碰到则加1
				if(n>0 && strValueArr[n][14]=="1")
				{
					m++;
				}

				int intTempColumn=0;//当前的列数（相对）
				int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
				//体温
			#region 打印一格，（以下完全相同）
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					//以下代码是用来设置修改痕迹
					if(m+1< m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strTemperature)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn=1;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
				//脉搏
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPulse)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn=2;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标

				//呼吸
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strBreath)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn=3;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
						
				bool blnIsLastModify=false;
				if( m == m_objTemp.m_objTransDataArr.Length-1 || (strValueArr[n][3] == m_objTemp.m_objTransDataArr[m+1].
					m_strBloodPressureA && 
					strValueArr[n][4] == m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureA && 
					strValueArr[n][3] == m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureS && 
					strValueArr[n][4] ==m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureA ))

				{// 当存在下一行，并且当前元素 != 下一行此元素				
					blnIsLastModify=true;					
				}
				//血压(收缩压)
				if(strValueArr[n][3].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,m_intPosY-7);
					if( ! blnIsLastModify)
					{					
						rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;
						rtfText.Y = m_intPosY-15;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
							rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);
	
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,
							rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3+6,
							rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3+6);
					
					}
				}	
			
				//血压(舒张压)
				if(strValueArr[n][4].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn+1],m_fotSmallFont,Brushes.Black,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+30,m_intPosY+5);
					if( ! blnIsLastModify)
					{					
						rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+30;
						rtfText.Y = m_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[n][intTempColumn+1].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn+1],m_fotSmallFont,
							rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+4,
							rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+4);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3+4,
						    rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3+4);
					
					}
				}

				intTempColumn=5;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
				//瞳孔大小（左）
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPupilLeft)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
				//瞳孔大小（右）
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPupilRight)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
				//瞳孔反射（左）
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strEchoLeft)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
				//瞳孔反射（右）
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strEchoRight)
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		
			
				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
		
				//摄入类型
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					
				}
			#endregion	打印一格					

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
				//摄入数量
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if((strValueArr[n][intTempColumn-1]=="D" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intInD.ToString()) || 
							(strValueArr[n][intTempColumn-1]=="I" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intInI.ToString()))
						{
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
				//排出类型
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
				//排出数量
			#region 打印一格
				if(strValueArr[n][intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					if(m+1 < m_objTemp.m_objTransDataArr.Length)
					{
						if((strValueArr[n][intTempColumn-1]=="U" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutU.ToString()) || 
							(strValueArr[n][intTempColumn-1]=="V" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutV.ToString()) ||
							(strValueArr[n][intTempColumn-1]=="S" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutS.ToString()) ||
							(strValueArr[n][intTempColumn-1]=="E" && 
							strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutE.ToString()))
						{
								
						
							rtfText.X = intPosX;
							rtfText.Y = m_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
								rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
													e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
														rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
				//病程记录

			#region 打印一格
                //if(strValueArr[n][intTempColumn].Trim().Length != 0)
                //{
                //    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
                //    if(m+1 < m_objTemp.m_objTransDataArr.Length)
                //    {
                //        if(strValueArr[n][intTempColumn] !=m_objTemp.m_objTransDataArr[m+1].m_strRecordContent)
                //        {
                //            rtfText.X = intPosX;
                //            rtfText.Y = m_intPosY;

                //            rgnDSTArr[0].First = 0;
                //            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

                //            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

                //            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
                //                rtfText,stfMeasure);

                //            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                //                                    e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
                //                                        rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
                //                                    e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
                //                                        rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
                //        }
                //    }
                //}
			#endregion

		#region 签名（作过修改的人签名）
			if( n<strValueArr.GetLength(0)-1)
				{
					if((strValueArr[n][14]=="0" && strValueArr[n+1][14]=="1"))
					{
														
						string strSign;
						if(m_objTemp.m_intFlag != (int)enmRecordsType.IntensiveTend && 
							m_objTemp.m_objTransDataArr == null)
							strSign = "";
						else
						{
							strSign = m_objTemp.m_objTransDataArr[m].m_strModifyUserName;			
						}
							
						e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
							(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+1, 
							m_intPosY);

					}
				}
			else
			{
				string strSign;
				if(m_objTemp.m_intFlag != (int)enmRecordsType.IntensiveTend && 
					m_objTemp.m_objTransDataArr == null)
					strSign = "";
				else
				{
					strSign = m_objTemp.m_objTransDataArr[m].m_strModifyUserName;			
				}
							
				e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+1, 
					m_intPosY);

			}
			#endregion				


				if(n<strValueArr.GetLength(0))
					m_intPosY +=intTempDeltaY;

				//打印行增加，用来控制在适当的时候换页
				intNowRow ++;
				
			}
			#endregion

			return enmReturnValue.enmSuccessed;
		}
	
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private enmReturnValue m_blnPrintOneRowValueOfSummary(string [][] p_strValueArr,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			

			if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
			{
				//换页
				return enmReturnValue.enmNeedNextPage;
				
			}


			string [] strValueArr = p_strValueArr[0];

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=0;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			//体温

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			//脉搏

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			//呼吸

			intTempColumn+=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			//瞳孔大小（左）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
			//瞳孔大小（右）
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
			}

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			//瞳孔反射（左）
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
			}

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			//瞳孔反射（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			//摄入类型
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
				
			}
			#endregion	打印一格					

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
			//摄入数量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX+5,m_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = m_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,
					rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,
					rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,
					rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
			//排出类型
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
			//排出数量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX+5,m_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = m_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);

				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
	

			//设置下一行的打印坐标
			m_intPosY+=intTempDeltaY;

			//记录当前已打印的行数
			intNowRow ++;
			return enmReturnValue.enmSuccessed;
		}
	


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
//		clsIntensiveTendMainPrintTool objPrintTool;
//		private void m_mthDemoPrint_FromDataSource()
//		{	
//			objPrintTool=new clsIntensiveTendMainPrintTool();
//			objPrintTool.m_mthInitPrintTool(null);	
//			if(m_objBaseCurrentPatient==null)
//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
//			else 
//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
//						
//			objPrintTool.m_mthInitPrintContent();	
	
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
//			objPrintTool=new clsIntensiveTendMainPrintTool();
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
		#endregion 在外部测试本打印的演示实例.
	}	

	public enum enmReturnValue
	{
		enmSuccessed=1,
		enmFaild=-1,
		enmNeedNextPage=2,
		
	}

}

