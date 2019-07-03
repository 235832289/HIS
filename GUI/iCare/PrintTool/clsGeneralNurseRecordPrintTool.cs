using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 一般护理记录的打印工具类,Jacky-2003-6-5
	/// </summary>
	public class clsGeneralNurseRecordPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsRecordsDomain m_objRecordsDomain;
		private clsPrintInfo_GeneralNurseRecord m_objPrintInfo;
		
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
			m_objPrintInfo=new clsPrintInfo_GeneralNurseRecord();
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
				MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatentID=="")
				return;
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.GeneralNurseRecord);
				
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
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_GeneralNurseRecord")
			{
				MDIParent.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_GeneralNurseRecord)p_objPrintContent;
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
					MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
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
			m_fotHeaderFont = new Font("SimSun", 18);
			m_fotSmallFont = new Font("SimSun",12);
			
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
		
			m_objPageSetting = new clsPrintPageSettingForRecord();

            m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fotSmallFont);

			intCurrentRecord=0;
			intNowPage=0;
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

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
			intNowPage = 0;
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
				m_objPrintInfo.m_objTransDataArr = null;		
				m_objPrintInfo.m_blnIsFirstPrintArr = null;
			}
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

		#region 有关打印的声明	
		/// <summary>
		/// 所有打印的数据
		/// </summary>
		private clsPrintData_GeneralNurseRecord[] m_objPrintDataArr;
		/// <summary>
		/// 存储每条记录所具有的空行数量
		/// </summary>
		private ArrayList m_arlBlockCount=new ArrayList();

        private com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext;
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
		/// 记录打印到第几页
		/// </summary>
		private int intNowPage;
		/// <summary>
		/// 当前打印的护理记录
		/// </summary>
		private int intCurrentRecord;
		/// <summary>
		/// 准备打印一条新记录(若存在上条记录,则上条记录打完)
		/// </summary>
		private bool blnBeginPrintNewRecord=true;		
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
			public string strDeptName;
			public string strInPatientID;
			//			public int intCurrentPage;
			//			public int intTotalPages;
			//			public string strPrintDate;
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
			LeftX = 40,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 827-45,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 40,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 21,
			/// <summary>
			/// 病程记录每行的pixel长度
			/// </summary>
			RecordLineLength=480,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=3,
			/// <summary>
			/// 第一条间隔线(X)
			/// </summary>
			ColumnsMark1=185,
			/// <summary>
			/// 第二条间隔线(X)
			/// </summary>
			ColumnsMark2=650
				
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
			RecordSign2
		
		}
	  
	
		#endregion

		#region 打印		
		/// <summary>
		/// 设置打印内容。
		/// </summary>
		/// <param name="p_objTransDataArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDate)
		{
			int intBlankCount=0;
			if(p_objTransDataArr==null || p_dtmFirstPrintDate==null ||p_objTransDataArr.Length !=p_dtmFirstPrintDate.Length)
			{
				MDIParent.ShowInformationMessageBox("打印数据有误!");
				return;
			}			

			//根据不同的表单类型，获取对应的clsDiseaseTrackInfo
			clsDiseaseTrackInfo objTrackInfo=null;
			m_objPrintDataArr = new clsPrintData_GeneralNurseRecord[p_objTransDataArr.Length];
			System.Data.DataTable dtbBlankRecord = null;
			new clsDiseaseTrackAddBlankDomain().m_lngGetBlankRecordContent(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate,out dtbBlankRecord);
			for(int i=0;i<p_objTransDataArr.Length;i++)
			{

				intBlankCount=0;
				objTrackInfo = new clsGeneralNurseRecordInfo();
		
				//设置clsDiseaseTrackInfo的内容
				objTrackInfo.m_ObjRecordContent = p_objTransDataArr[i].m_objRecordContent;
		
				m_objPrintDataArr[i]=new clsPrintData_GeneralNurseRecord();
				//根据 clsDiseaseTrackInfo 获得的文本和Xml
				m_objPrintDataArr[i].m_strCreateDate = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate.ToString();
				m_objPrintDataArr[i].m_strContent = objTrackInfo.m_strGetTrackText(); 
				m_objPrintDataArr[i].m_strContentXml = objTrackInfo.m_strGetTrackXml();
				
				string strSignText=objTrackInfo.m_strGetSignText();

				m_objPrintDataArr[i].m_strSign =  strSignText;				
				
				m_objPrintDataArr[i].m_dtmFirstPrintDate=p_dtmFirstPrintDate[i];
				//设置分页标志
				m_objPrintDataArr[i].m_strPagiNation=objTrackInfo.m_ObjRecordContent.m_StrPagination.ToString();
				if(dtbBlankRecord != null && dtbBlankRecord.Rows.Count > 0)
				{
					foreach(System.Data.DataRow drtAdd in dtbBlankRecord.Rows)
					{
						if (DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == objTrackInfo.m_ObjRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"))
						{
							int intBlankLine = Int32.Parse( drtAdd[3].ToString());
							intBlankCount=intBlankLine;
							m_objPrintDataArr[i].m_intBlankCount = intBlankLine;
							for(int j2 = 0;j2<intBlankLine;j2++)
							{
								m_objPrintDataArr[i].m_strContent = "\n" + m_objPrintDataArr[i].m_strContent;
							}
							break;
						}
					}
				}
				m_arlBlockCount.Add(intBlankCount);//保存每条记录实际空行数量
			}
		}

		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{	
			try
			{
				p_objPrintPageArg.HasMorePages =false;
				m_mthPrintTitleInfo(p_objPrintPageArg);	
				m_mthAddDataToGrid(p_objPrintPageArg);
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);
			}
			catch(Exception err)
			{
				MDIParent.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
			}
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
			objEveryRecordPageInfo.strDeptName=m_objPrintInfo.m_strDeptName;
			objEveryRecordPageInfo.strBedNo =m_objPrintInfo.m_strBedName;
			//objEveryRecordPageInfo.strAreaName=m_objPrintInfo.m_strAreaName;
			objEveryRecordPageInfo.strSex=m_objPrintInfo.m_strSex;
			objEveryRecordPageInfo.strInPatientID=m_objPrintInfo.m_strHISInPatientID;
			//objEveryRecordPageInfo.strPrintDate=( m_objPrintInfo.m_strInPatentID!="")? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		
			

            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("一   般   护   理   记   录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strAreaName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
		}
		#endregion		

		#region 画标题的栏目
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			e.Graphics.DrawString("记录时间",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+30,
				(int)enmRecordRectangleInfo.TopY+7);
		     
			e.Graphics.DrawString("护 理 记 录",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+185, (int)enmRecordRectangleInfo.TopY+7);
	
			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1,(int)enmRecordRectangleInfo.TopY+7);
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
				e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
					(int)enmRecordRectangleInfo.RightX,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1);
			}

			//画格子竖线
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			
			//页脚//////////////////////////////////////////////////////////////
			e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2 ,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum+1)-20 );
		}

						
		#endregion

		#region 填充数据到表格
		private int m_intBlankCount = -1;
		/// <summary>
		/// 填充数据到表格
		/// </summary>
		/// <param name="e"></param>
		private void m_mthAddDataToGrid(System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				//int intPrintLenth=(int) ((float)enmRecordRectangleInfo.RecordLineLength/17.5)+1; /*每行显示的汉字的数目*/				
				string strRecord="";
				string strRecordXML="";				
				DateTime dtmFlagTime;
			
				int intNowRow=1; /*记录该页当前的打印的行*/
				bool blnIsPrintDate = false;

      
				if(m_objPrintInfo.m_strInPatentID =="" || m_objPrintDataArr == null)	return;
				for(;intCurrentRecord<m_objPrintDataArr.Length;intCurrentRecord++)	//不作初始化
				{	

					#region 如果是新记录，打印日期，设置打印数据值
					if(blnBeginPrintNewRecord)
					{
//						if(m_intBlankCount == -1)
							m_intBlankCount = m_objPrintDataArr[intCurrentRecord].m_intBlankCount;
//						if(m_intBlankCount == -1)
//							m_intBlankCount = -2;

                            strRecord = m_objPrintDataArr[intCurrentRecord].m_strContent.TrimEnd(new char[] { '\n','\r'}) + "\r";
						strRecordXML=m_objPrintDataArr[intCurrentRecord].m_strContentXml;
					
						//打印一条记录/////////////////////////////////////////////////////////////////////
						/*修改打印内容方式（以第一次打印时间为分割，该时间后的所有修改的痕迹都要保留，如从未打印过则显示正确的记录）*/				
						if(m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate==DateTime.MinValue)
							dtmFlagTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
						else 
							dtmFlagTime=m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate;
											
						m_objPrintContext.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
						
						com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr = m_objPrintContext.m_ObjModifyUserArr;

						for(int i=0;i< m_objModifyUserArr.Length;i++)
						{
							if(m_objModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
							{
								m_objModifyUserArr[i].m_clrText = Color.Black;
							}
						}

					}
					#endregion

					#region 将当前记录除签名外全部打完或中途换页跳出	
					while(m_objPrintContext.m_BlnHaveNextLine())//判断该条记录是否还有下一行
					{
						if(intNowRow < (int)enmRecordRectangleInfo.RowLinesNum)
						{
							//打印日期
							//如果此记录前有空行日期打印的位置就要向下移动对应的行数
//							if (m_arlBlockCount[intCurrentRecord].ToString()=="0" && !blnIsPrintDate)
//							{
//								blnIsPrintDate = true;
//								e.Graphics.DrawString(DateTime.Parse(m_objPrintDataArr[intCurrentRecord].m_strCreateDate).ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmGeneralNurseRecord")),m_fotSmallFont ,m_slbBrush,
//									(int)enmRecordRectangleInfo.LeftX+1, 
//									(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20);
//							}
//							else 
							if(m_intBlankCount == 0)
							{
								//								int p=int.Parse(m_arlBlockCount[intCurrentRecord].ToString());
								e.Graphics.DrawString(DateTime.Parse(m_objPrintDataArr[intCurrentRecord].m_strCreateDate).ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmGeneralNurseRecord")),m_fotSmallFont ,m_slbBrush,
									(int)enmRecordRectangleInfo.LeftX+1, 
									(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*(intNowRow/*+p*/) + 20);
								--m_intBlankCount;
							}
						}
						/* 
						 * 如果最后一行打印的刚好是一条记录的标题，
						 * 则从新的一页开始打
						 */
						if(intNowRow == (int)enmRecordRectangleInfo.RowLinesNum)
						{
							if(m_objPrintContext.m_IntCurrentIndex == 0)
							{
								e.HasMorePages =true;
								intNowPage ++;
								return;
							}
						}
						
						
						if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
						{
							//如果还没打到指定记录，清空。注意：该记录还没打完
//							if(intCurrentRecord < m_intFromRecord)
//							{
//								e.Graphics.Clear(Color.White);
//								m_mthPrintTitleInfo(e);
//								m_mthPrintRectangleInfo(e);
//								m_mthAddDataToGrid(e);
//							}
							return;
						}

						m_objPrintContext.m_mthPrintLine((int)enmRecordRectangleInfo.RecordLineLength,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1, 
							(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20,e.Graphics);
											

						//当至少有一行有数据没有打完时，当前行才增加
						if(m_objPrintContext.m_BlnHaveNextLine())
						{
							blnBeginPrintNewRecord=false;//当前记录没有打完
//							if(--m_intBlankCount == -1)
//								m_intBlankCount = -2;
							--m_intBlankCount;
							intNowRow ++;//向下滚行
						}
					}					
					#endregion
					
					#region 签名
                    //intNowRow++;
                    //if (intNowRow == (int)enmRecordRectangleInfo.RowLinesNum)
                    //{
                        
                    //    e.HasMorePages = true;
                    //    intNowPage++;
                    //    return;
                        
                    //}
                    //if (intNowRow == 2 && intNowPage != 0)
                    //    intNowRow = 1;
					e.Graphics.DrawString(m_objPrintDataArr[intCurrentRecord].m_strSign,m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+1, 
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20);//+8);					
					blnBeginPrintNewRecord=true;  //当前记录打完	
					intNowRow ++;//向下滚行
					#endregion

					#region 如果还没打印到指定记录，将之前的清空
//					if(intCurrentRecord < m_intFromRecord)
//					{
//						e.Graphics.Clear(Color.White);//清空
//
//						//如果这条记录刚好占一页
//						if(intNowRow>(int)enmRecordRectangleInfo.RowLinesNum)
//						{
//							//如果是指定记录的前一条，则先打印一空页（因为用户塞的是之前打印的那张纸）
//							if(intCurrentRecord == m_intFromRecord - 1)
//							{
//								intCurrentRecord++;
//								e.HasMorePages = true;
//								return;
//							}
//
//							//如果不是，则从这一页的顶端继续打，并且需要打页头和页脚
//							m_mthPrintTitleInfo(e);
//							m_mthPrintRectangleInfo(e);
//							intNowRow = 1;
//							//页脚//////////////////////////////////////////////////////////////
//							e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2 ,
//								(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum+1)+10 );
//						}						
//					}
					#endregion

					#region 是否换页打印

					#endregion

					m_intBlankCount = -1;
					blnIsPrintDate = false;
					//检查下一页是否设置分页标志，如果设置分页则换页打印
					if(intCurrentRecord<m_objPrintDataArr.Length )
					{
						if (intCurrentRecord==m_objPrintDataArr.Length-1) 
						{
							if (m_objPrintDataArr[intCurrentRecord].m_strPagiNation=="1")
							{
								intNowRow +=(int)enmRecordRectangleInfo.RowLinesNum;
								e.HasMorePages =true;
//								intNowPage ++;
							}
						}
						else
						{
							if (m_objPrintDataArr[intCurrentRecord+1].m_strPagiNation=="1")
							{
								intNowRow +=(int)enmRecordRectangleInfo.RowLinesNum;
								e.HasMorePages =true;
//								intNowPage ++;
							}
						}
					}

				}
				
				#region 打印完毕，ReSet(复位)操作
				if(intCurrentRecord==m_objPrintDataArr.Length)
				{				
					intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
					blnBeginPrintNewRecord=true;//复位
					intNowPage++;
//					intNowPage=0;//复位						
				}
				#endregion//打印完成，没下页了。因为在for循环中e.HasMorePages的值可能已被改为true
				e.HasMorePages = false;
			}
			catch(Exception err)
			{
				MDIParent.ShowInformationMessageBox(err.Message + "\r\n" +err.StackTrace);
			}
		}	

		/// <summary>
		/// 检查是否换页,true:换页，false:不换页
		/// </summary>
		/// <param name="p_intNowRow">当前打印行，第p_intNowRow行</param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool m_blnCheckPageChange(int p_intNowRow,System.Drawing.Printing.PrintPageEventArgs e)
		{
			//当当前行超过最后一行（即 >页总行数）时换页
			if(p_intNowRow>(int)enmRecordRectangleInfo.RowLinesNum-1/*除去表头1行外总有效行数*/) 
			{
				e.HasMorePages =true;
				intNowPage ++;

				return true;
			}
			else return false;
		}

		
		#endregion 


	
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
				float fltOffsetX=0;//X的偏移量
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{   
                    
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(320f-fltOffsetX,60f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(200f-fltOffsetX,85f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(40f-fltOffsetX,120f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(90f-fltOffsetX,120f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(160f-fltOffsetX,120f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(210f-fltOffsetX,120f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(265f-fltOffsetX-25,120f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(315f-fltOffsetX-35,120f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(365f-fltOffsetX,120f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(415f-fltOffsetX,120f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(570f-fltOffsetX,120f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(620f-fltOffsetX,120f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(650f-fltOffsetX,120f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(710f-fltOffsetX,120f);
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
		//		clsGeneralNurseRecordPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsGeneralNurseRecordPrintTool();
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
		//			objPrintTool=new clsGeneralNurseRecordPrintTool();
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
}



