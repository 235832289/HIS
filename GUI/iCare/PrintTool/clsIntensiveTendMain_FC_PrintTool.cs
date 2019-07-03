using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 危重患者护理记录打印工具类(新版)摘要说明。
	/// </summary>
	public class clsIntensiveTendMain_FC_PrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;               //表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;	                   //是否需要初始化	
		private clsRecordsDomain m_objRecordsDomain;           //记录域
		private clsPrintInfo_IntensiveTend m_objPrintInfo;     //打印内容
		private string strCurrentClass;                        //当前班次默认为空
		private int intCaseRowCount;                           //当前病程记录的最大行数
		private string[] strCurrentCaseTextArr;                //当前病程记录内容数组
		private string[] strCurrentCaseXmlArr;                 //当前病程记录痕迹数组
		private string[] strCurrentCaseCreateDateArr;          //当前病程记录创建时间
        private string strPerRecordDate = "";                  //上一条记录的记录日期。如果前后两条记录日期相同，则后一条记录不打印日期

		public clsIntensiveTendMain_FC_PrintTool()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 打印初始化、事件
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
			m_objPrintInfo.m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo.m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo.m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo.m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{	//m_objprintinfo为空表明未设置打印内容		
			if(m_objPrintInfo==null)
			{
				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			//病人为空
			if(m_objPrintInfo.m_strInPatentID=="")
				return;
			//获取打印内容
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.IntensiveTend);
				
			long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_objTransDataArr,out m_objPrintInfo.m_dtmFirstPrintDateArr,out m_objPrintInfo.m_blnIsFirstPrintArr);
			if(lngRes <= 0)
				return ;   

			//按记录时间(CreateDate)排序 
//			m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
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
		
		#endregion ;

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
			public int m_intPrintLenth_RecordContent;		//病程记录
			public int m_intPrintLenth_Temperature;			//体温
			public int m_intPrintLenth_Breath;				//呼吸
			public int m_intPrintLenth_Mind;				//神志
			public int m_intPrintLenth_Pulse;				//脉搏
			public int m_intPrintLenth_BloodPressure;		//血压	
			public int m_intPrintLenth_Pupil;				//瞳孔（大小）		
			public int m_intPrintLenth_Echo;				//反射		
			public int m_intPrintLenth_In;					//摄入
			public int m_intPrintLenth_Out;					//排出		
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
		/// 当前打印的记录的序号（第几条记录）
		/// </summary>
		private int m_intCurrentRecord=0;
        /// <summary>
        /// 当前打印记录的行号（第几条记录的第几行）
        /// </summary>
        private int m_intCurrentRecordRowIndex = 0;
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
			TopY = 170,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 40,
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
			ColumnsNum=17,
			/// <summary>
			/// 第一条间隔线(X)
			/// </summary>
			ColumnsMark1=70,
			/// <summary>
			/// 第二条间隔线(X)
			/// </summary>
			ColumnsMark2=105,
			ColumnsMark3=145,
			ColumnsMark4=170,
			ColumnsMark5=200,
			ColumnsMark6=230,
			ColumnsMark7=290,
			ColumnsMark8=315,
			ColumnsMark9=340,
			ColumnsMark10=365,
			ColumnsMark11=390,
			ColumnsMark12=420,
			ColumnsMark13=445,
			ColumnsMark14=470,
			ColumnsMark15=495,
            ColumnsMark16 = 520,
			ColumnsMark17=755				
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
						m_fReturnPoint = new PointF(320f,60f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(225f,100f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(20f,150f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(70f,150f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(150f,150f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(200f,150f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(250f,150f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(300f,150f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(350f,150f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(400f,150f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(550f,150f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(600f,150f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(650f,150f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(720f,150f);
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
		     
			e.Graphics.DrawString("时",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+4, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("间", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark1+4, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep );

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

			//神志
			e.Graphics.DrawString("神",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+2);
			e.Graphics.DrawString("志",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep);

			//血压(mmHg)
			e.Graphics.DrawString("血",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+12, (int)enmRecordRectangleInfo.TopY+2);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark6+12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawString("mmHg",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+8, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep);

			e.Graphics.DrawString(" 瞳 孔",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+15, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("大小",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+5, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5-10);
			e.Graphics.DrawString("(mm)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+5, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5+10);
			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);


			e.Graphics.DrawString("反射",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9+3, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);
            Font m_fotTemp = new Font("Simsun", 10f);
            e.Graphics.DrawString(" 血", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString(" 氧", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 20);
            e.Graphics.DrawString(" 饱", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 40);
            e.Graphics.DrawString(" 和", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 60);
            e.Graphics.DrawString(" 度", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 80);
            e.Graphics.DrawString(" %", m_fotTemp, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 100);



			e.Graphics.DrawString("摄入",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+3, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("种",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("类",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("ml",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);


			e.Graphics.DrawString("排出",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+5);
			e.Graphics.DrawString("种",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("类",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			e.Graphics.DrawString("ml",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

            //e.Graphics.DrawString("签名", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
            //    (int)enmRecordRectangleInfo.ColumnsMark16 + 1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);


			e.Graphics.DrawString(" 病情、护理措施、",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+20, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
            e.Graphics.DrawString("  效果及签名", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
				(int)enmRecordRectangleInfo.ColumnsMark16+30, (int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep+5);

//			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
//				(int)enmRecordRectangleInfo.ColumnsMark16+1,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
		
		
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
                else if (i1 == 1)
                {
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8);

                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8);
                }
                else //if(i1==2)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1);
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
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+intHeight);

			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+2*(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+intHeight);
            //血氧饱和度
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY + intHeight);
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY+intHeight);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-8,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY+intHeight);
            //签名
            //e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, (int)enmRecordRectangleInfo.TopY,
            //    (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, (int)enmRecordRectangleInfo.TopY + intHeight);						
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+intHeight);
			#endregion

			//画对角线（血压）
			for(int i1=3;i1<(int)enmRecordRectangleInfo.RowLinesNum ;i1++)//斜线只需要从第四行开始到倒数第二行
			{
				e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark7,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
					(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark6,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*(i1+1));					
			}	
			
		}

						
		#endregion

		#region 打印具体实现
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
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag == 0)
					{
						#region "统计信息"
						m_strValueArr=new string[1][];
						m_strValueArr[0]=new string[18];
						m_strValueArr[0][0]="";
						m_strValueArr[0][1]="";
						m_strValueArr[0][2]="";
						m_strValueArr[0][3]="";
						m_strValueArr[0][4]="";
						m_strValueArr[0][5]="";
                        m_strValueArr[0][6] = "";
                        m_strValueArr[0][7] = "  24";
                        m_strValueArr[0][8] = "小时";
                        m_strValueArr[0][9] = "总计:";
                        m_strValueArr[0][10] = "摄入";
                        m_strValueArr[0][11] = (m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In == 0 ? "" : m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In.ToString());
                        m_strValueArr[0][12] = "排出";
                        m_strValueArr[0][13] = (m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out == 0 ? "" : m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out.ToString());
                        m_strValueArr[0][14] = "";
                        m_strValueArr[0][15] = "";
                        m_strValueArr[0][16] = "";
                        m_strValueArr[0][17] = "";
						return 1;
						#endregion
					}
					else
					{
						#region "正常记录"
							intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;

							strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].
								m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
							intLenth=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;

							//临时存储数据
							ArrayList m_RecordInfo=new ArrayList();
							int m_intAllRecords=0;
                            for (int k1 = intLenth-1; k1 < intLenth; k1++)
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
                                #region 病程记录内容处理--wf20080117
                                //病程记录内容处理
                                ArrayList arlRecordContent = new ArrayList();
                                ArrayList arlRecordContentXML = new ArrayList();
                                for (int k = 0; k < m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr.Length; k++)
                                {
                                    if (m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr[k].m_strDiseasesRecordContent.Trim().Length != 0)
                                    {
                                        arlRecordContent.Add(m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr[k].m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                        arlRecordContentXML.Add("<root />");
                                        string strCase = m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr[k].m_strDiseasesRecordContent;
                                        string strCaseXML = m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr[k].m_strDiseasesRecordContentXml;
                                        string[] strCaseTextArr, strCaseXmlArr;
                                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strCase, strCaseXML, 36, out strCaseTextArr, out strCaseXmlArr);
                                        for (int k2 = 0; k2 < strCaseTextArr.Length; k2++)
                                        {
                                            arlRecordContent.Add(strCaseTextArr[k2]);
                                            arlRecordContentXML.Add(strCaseXmlArr[k2]);
                                        }
                                        arlRecordContent.Add("                        --" + m_objPrintDataArr[m_intCurrentRecord].m_objCourseDiseasesRecordArr[k].m_strModifyUserName);
                                        arlRecordContentXML.Add("<root />");
                                    }
                                }
                                intContent_Count = arlRecordContent.Count + 1;
                                #endregion
                                #region 屏蔽--wf20080117
                                /*
								//病程记录只显示一条
								if (m_objCurrent.m_strRecordContent.Trim().Length!=0)
								{
									string[] strCurrentCaseTextArrTemp=null;                //当前病程记录内容数组(临时)
									string[] strCurrentCaseXmlArrTemp=null;                 //当前病程记录痕迹数组(临时)
									string[] strCurrentCaseCreateDateArrTemp=null;          //当前病程记录创建时间数组(临时)
                        

									if (intCaseRowCount==0)
									{
										strCurrentCaseTextArr=null;
										strCurrentCaseXmlArr=null;
										strCurrentCaseCreateDateArr=null;
										intCaseRowCount=0;
									}
									else
									{
										strCurrentCaseTextArrTemp=strCurrentCaseTextArr;                 
										strCurrentCaseXmlArrTemp=strCurrentCaseXmlArr;                 
										strCurrentCaseCreateDateArrTemp=strCurrentCaseCreateDateArr;          
										strCurrentCaseTextArr=null;
										strCurrentCaseXmlArr=null;
										strCurrentCaseCreateDateArr=null;
									}
//									strCurrentCaseTextArr=null;
//									strCurrentCaseXmlArr=null;
//									intCaseRowCount=0;
									string strCase="";
									strCase = m_objCurrent.m_strRecordContent;

									string strCaseXML =m_objCurrent.m_strRecordContentXml ;
									string[] strCaseTextArr,strCaseXmlArr;
									com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml(strCase,strCaseXML,14,out strCaseTextArr,out strCaseXmlArr);
									int intCaseCount = strCaseTextArr.Length;
									if (intCaseRowCount>0)//追加到后面
									{
										int intOldCaseCount=strCurrentCaseTextArrTemp.Length;
										strCurrentCaseTextArr=new string[intCaseCount+intOldCaseCount+1];
										strCurrentCaseXmlArr=new string[intCaseCount+intOldCaseCount+1];
										strCurrentCaseCreateDateArr=new string[intCaseCount+intOldCaseCount+1];
										for (int i = 0; i <intOldCaseCount; i++)
										{
											strCurrentCaseTextArr[i]=strCurrentCaseTextArrTemp[i];
											strCurrentCaseXmlArr[i]=strCurrentCaseXmlArrTemp[i];
											strCurrentCaseCreateDateArr[i]=strCurrentCaseCreateDateArrTemp[i];
										}
										for (int j = 0; j <intCaseCount; j++)
										{
											strCurrentCaseTextArr[j+intOldCaseCount]=strCaseTextArr[j];
											strCurrentCaseXmlArr[j+intOldCaseCount]=strCaseXmlArr[j];
											strCurrentCaseCreateDateArr[j+intOldCaseCount]=m_objCurrent.m_dtContentCreateDate.ToString();
										}
										//添加签名
										strCurrentCaseTextArr[intCaseCount+intOldCaseCount]="            --"+ m_objCurrent.m_strContentModifyUserName;
										strCurrentCaseXmlArr[intCaseCount+intOldCaseCount]=strCaseXmlArr[intCaseCount-1];
										strCurrentCaseCreateDateArr[intCaseCount+intOldCaseCount]=m_objCurrent.m_dtContentCreateDate.ToString();

										//病程记录最大行
										intCaseRowCount=intCaseRowCount+intCaseCount+1;
										intContent_Count=intCaseRowCount;
									}
									else
									{
										strCurrentCaseTextArr=new string[intCaseCount+1];
										strCurrentCaseXmlArr=new string[intCaseCount+1];
										strCurrentCaseCreateDateArr=new string[intCaseCount+1];
										for (int i = 0; i <intCaseCount; i++)
										{
											strCurrentCaseTextArr[i]=strCaseTextArr[i];
											strCurrentCaseXmlArr[i]=strCaseXmlArr[i];
											strCurrentCaseCreateDateArr[i]=m_objCurrent.m_dtContentCreateDate.ToString();
										}
										//添加签名
										strCurrentCaseTextArr[intCaseCount]="            --"+ m_objCurrent.m_strContentModifyUserName;
										strCurrentCaseXmlArr[intCaseCount]=strCaseXmlArr[intCaseCount-1];
										strCurrentCaseCreateDateArr[intCaseCount]=m_objCurrent.m_dtContentCreateDate.ToString();
										//病程记录最大行
										intCaseRowCount=intCaseCount+1;
										intContent_Count=intCaseCount+1;
									}
						
									strCurrentClass=m_objCurrent.m_strClass;
//									//病程记录最大行
//									intCaseRowCount=intCaseCount;
//									intContent_Count=intCaseCount;
//									//内容
//									strCurrentCaseTextArr=strCaseTextArr;
//									strCurrentCaseXmlArr=strCaseXmlArr;
//									strCurrentClass=m_objCurrent.m_strClass;
								}
                                */
                                #endregion
                                if (intMaxCount<intIn_Count)
									intMaxCount=intIn_Count;
								if(intMaxCount<intOut_Count)
									intMaxCount=intOut_Count;
                                if (intMaxCount < intContent_Count)
                                    intMaxCount = intContent_Count;
				
								if(intMaxCount == 0)
									intMaxCount = 1;

								///累计行数
								m_intAllRecords+=intMaxCount;

								#endregion

								for(int k2=0;k2<intMaxCount;k2++)
								{
									//m_strValue[14]用来记录签名，获取的数据已做处理，
									//只会显示当前班次的最后签名
									//m_strValue[16]标志一条记录
									string[] m_strValue=new String[18];
									#region 初始化全为空
									for (int i = 0; i <m_strValue.Length; i++)
									{
										m_strValue[i]="";
									}
									#endregion
									if(k2<=0)
									{
										m_strValue[0]=(m_objCurrent.m_strTemperature==null? "": m_objCurrent.m_strTemperature);
										m_strValue[1]=(m_objCurrent.m_strPulse==null? "" :m_objCurrent.m_strPulse);
										m_strValue[2]=(m_objCurrent.m_strBreath==null? "" :m_objCurrent.m_strBreath);
										m_strValue[3]=(m_objCurrent.m_strMind==null? "" :m_objCurrent.m_strMind);
										m_strValue[4]=(m_objCurrent.m_strBloodPressureS==null? "" :m_objCurrent.m_strBloodPressureS);
										m_strValue[5]=(m_objCurrent.m_strBloodPressureA==null? "" :m_objCurrent.m_strBloodPressureA);
										m_strValue[6]=(m_objCurrent.m_strPupilLeft==null? "" :m_objCurrent.m_strPupilLeft);
										m_strValue[7]=(m_objCurrent.m_strPupilRight==null? "" :m_objCurrent.m_strPupilRight);
										m_strValue[8]=(m_objCurrent.m_strEchoLeft==null? "" :m_objCurrent.m_strEchoLeft);
										m_strValue[9]=(m_objCurrent.m_strEchoRight==null? "" :m_objCurrent.m_strEchoRight);
                                        m_strValue[10] = (m_objCurrent.m_strBloodOxygenSaturation == null ? "" : m_objCurrent.m_strBloodOxygenSaturation);
									}

									if(k2<intIn_Count)
									{
										m_strValue[11]=((string[])objIn[k2])[0];
										m_strValue[12]=((string[])objIn[k2])[1];
									}
									else
									{
										m_strValue[11]="";
										m_strValue[12]="";
									
									}
									if(k2<intOut_Count)
									{
										m_strValue[13]=((string[])objOut[k2])[0];
										m_strValue[14]=((string[])objOut[k2])[1];
									}
									else
									{
										m_strValue[13]="";
										m_strValue[14]="";

									}
                                    if (arlRecordContent.Count > 0 && k2 != 0)
                                    {
                                        m_strValue[15] = arlRecordContent[k2 - 1].ToString();
                                    }
                                    else if (k2 == 0)
                                    {
                                        m_strValue[15] = m_objCurrent.m_strModifyUserName;//护理记录的签名显示在病程记录列;
                                    }
                                    m_strValue[16] = "";
									if (k2==0)
										//一条记录
										m_strValue[17]="1";
									else
										m_strValue[17]="0";
									m_RecordInfo.Add(m_strValue);

								}
							}
							m_strValueArr=new string[m_intAllRecords][];
							for(int m=0;m<m_intAllRecords ;m++)
								m_strValueArr[m]=(string[])m_RecordInfo[m];
							
							return intLenth;
						#endregion

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
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17-70 ,
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
//					if(blnBeginPrintNewRecord)
//					{
//						
//						//打印一条记录/////////////////////////////////////////////////////////////////////
//						/*修改打印内容方式（以第一次打印时间为分割，该时间后的所有修改的痕迹都要保留，
//						 * 如从未打印过则显示正确的记录）*/				
//						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmFirstPrintDate==
//							DateTime.MinValue)
//							dtmFlagTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
//						else 
//							dtmFlagTime=m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmFirstPrintDate;
//						
//						m_objPrintContext.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
//					
//						com.digitalwave.Utility.Controls.ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr =
//							m_objPrintContext.m_ObjModifyUserArr;
//
//						for(int i=0;i< m_objModifyUserArr.Length;i++)
//						{
//							if(m_objModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
//							{
//								m_objModifyUserArr[i].m_clrText = Color.Black;
//							}
//						}
//
//					}
					#endregion
				}
				catch(Exception ex)
				{
					clsPublicFunction.ShowInformationMessageBox(ex.Message);
				}					
			
			}
            strPerRecordDate = "";//所有记录打印完重置此变量以避免先预览后打印日期不显示
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
		    //读出日期
			string strCreateDate;
			string strCreateTime;
			string strCreateDateTime;
			
			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag == 0)
			{
				strCreateDate = "";
				strCreateTime = "";
				strCreateDateTime = "";
			}
			else
			{
				if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate!=DateTime.MinValue)
				{
                    strCreateDateTime = m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");	
					try
					{
						strCreateDate=DateTime.Parse(strCreateDateTime).ToString("yyyy-M-d");
						strCreateTime=DateTime.Parse(strCreateDateTime).ToString("HH:mm");
                        if (strCreateDate == strPerRecordDate)
                        {
                            strCreateDate = "";
                        }
                        else
                            strPerRecordDate = strCreateDate;
					}
					catch
					{
                        strCreateDate="不详";
                        strCreateTime="不详";
                    }	
				}
				else
				{
					strCreateDate = "";
					strCreateTime = "";
					strCreateDateTime = "";
				}
            }
			//开始打印一条新记录/////////////////////////////////////////////////////////////////////
			e.Graphics.DrawString(strCreateDate,m_fotTinyFont ,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX, 
				m_intPosY);
            e.Graphics.DrawString(strCreateTime, m_fotTinyFont, m_slbBrush,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1 + 1,
                m_intPosY);	
			
			enmReturnValue enmIsRecordFinish=m_blnPrintOneRowValue(m_strValueArr,m_intNowRowInOneRecord,e);
			
			if(enmIsRecordFinish!=enmReturnValue.enmNeedNextPage)
			{
				m_intRowNumberInValueArr=0;
				m_intRowNumberInTempArr=0;
			}					
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
				return true;
			}
			else return false;
		}
 
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
			string[][] strValueArr = p_strValueArr;

			#region  判断是否统计记录
			bool blnIsSummary=false;                
			for( int i=0;i<p_strValueArr.Length;i++)
			{
				if(p_strValueArr[i][9] == "总计:")
				{
					blnIsSummary=true;
					break;
				}
			}
			//统计记录打印
			if(blnIsSummary)
			{
                if (p_strValueArr[0][11].ToString() == "" && p_strValueArr[0][13].ToString() == "")
                    return enmReturnValue.enmSuccessed;
                else
				    return m_blnPrintOneRowValueOfSummary(p_strValueArr,e,ref m_intPosY);
			}
			#endregion

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

            for (int i = m_intCurrentRecordRowIndex; i < strValueArr.Length; i++)
            {
                //体温
                int intTempColumn = 0;//当前的列数（相对）
                int intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //脉搏
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //呼吸
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //神志
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //血压(收缩压)
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY - 7);
                }
                //血压(舒张压)
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6 + 30;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY + 5);
                }
                //瞳孔大小（左）
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //瞳孔大小（右）
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //瞳孔反射（左)
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);
                }
                //瞳孔反射（右）
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);
                }
                //血氧饱和度
                intTempColumn ++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //摄入类型
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //摄入数量
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //排出类型
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //排出数量
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
                }
                //病程记录或者护理记录签名
                intTempColumn++;//当前的列数（相对）
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
                if (strValueArr[i][intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[i][intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);
                }
                if (m_blnCheckPageChange(++intNowRow, e) == true) //每打印完一行检查下一行是否需要换页
                {
                    m_intCurrentRecordRowIndex++;
                    //换页
                    return enmReturnValue.enmNeedNextPage;
                }
                else
                {
                    m_intPosY += intTempDeltaY;
                }
            }
            #region 打印一条记录占用几行的情况 屏蔽--wf20080121
            
//            clsIntensiveTendDataInfo m_objTemp=(clsIntensiveTendDataInfo)m_objPrintInfo.m_objTransDataArr[m_intCurrentRecord];

//            //n用来维护与报表中的二维表格相对应的内存数据行。
//            for(int n=m_intRowNumberInValueArr,m=m_intRowNumberInTempArr;n<strValueArr.GetLength(0) && m<m_objTemp.m_objTransDataArr.Length;n++)
//            {					
//                if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
//                {
//                    m_intRowNumberInValueArr=n;
//                    m_intRowNumberInTempArr=m;
//                    //换页
//                    return enmReturnValue.enmNeedNextPage;
//                }
				
//                //检测是否已碰到新记录。碰到则加1
//                if(n>0 && strValueArr[n][16]=="1")
//                {
//                    m++;
//                }

//                int intTempColumn=0;//当前的列数（相对）
//                int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
//                //体温
//                #region 打印一格，（以下完全相同）
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    //以下代码是用来设置修改痕迹
//                    /*不要痕迹
//                    if(m+1< m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strTemperature)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn=1;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
//                //脉搏
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPulse)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn=2;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标

//                //呼吸
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strBreath)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn=3;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
//                //神志
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    if (strValueArr[n][intTempColumn].ToString().Length>3)
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
//                    else
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strMind)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn=4;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标

						
//                bool blnIsLastModify=false;
//                if( m == m_objTemp.m_objTransDataArr.Length-1 || (strValueArr[n][4] == m_objTemp.m_objTransDataArr[m+1].
//                    m_strBloodPressureA && 
//                    strValueArr[n][5] == m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureA && 
//                    strValueArr[n][4] == m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureS && 
//                    strValueArr[n][5] ==m_objTemp.m_objTransDataArr[m+1].m_strBloodPressureA ))

//                {// 当存在下一行，并且当前元素 != 下一行此元素				
//                    blnIsLastModify=true;					
//                }
//                //血压(收缩压)
//                #region 打印一格
//                if(strValueArr[n][4].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,
//                        (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,m_intPosY-7);
//                    /*不要痕迹
//                    if( ! blnIsLastModify)
//                    {					
//                        rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;
//                        rtfText.Y = m_intPosY-15;

//                        rgnDSTArr[0].First = 0;
//                        rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                        stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                        rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                            rtfText,stfMeasure);

//                        rtfBounds = rgnDST[0].GetBounds(e.Graphics);
	
//                        e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,
//                            rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
//                        e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3+6,
//                            rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3+6);
					
//                    }
//                     * */
//                }	
				
//                #endregion ;
			
//                //血压(舒张压)
//                #region 打印一格
//                if(strValueArr[n][5].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn+1],m_fotSmallFont,Brushes.Black,
//                        (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+30,m_intPosY+5);
//                    /*不要痕迹
//                    if( ! blnIsLastModify)
//                    {					
//                        rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+30;
//                        rtfText.Y = m_intPosY;

//                        rgnDSTArr[0].First = 0;
//                        rgnDSTArr[0].Length = strValueArr[n][intTempColumn+1].Length;

//                        stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                        rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn+1],m_fotSmallFont,
//                            rtfText,stfMeasure);

//                        rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                        e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+4,
//                            rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+4);
//                        e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3+4,
//                            rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3+4);
					
//                    }*/
//                }

				
//                #endregion ;
//                intTempColumn=6;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
//                //瞳孔大小（左）
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPupilLeft)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
//                //瞳孔大小（右）
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strPupilRight)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
//                //瞳孔反射（左）
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    if(strValueArr[n][intTempColumn].Length > 1)
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
//                    else
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strEchoLeft)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格		

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
//                //瞳孔反射（右）
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    if (strValueArr[n][intTempColumn].Length > 1)
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);
//                    else
//                        e.Graphics.DrawString(strValueArr[n][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if(strValueArr[n][intTempColumn] != m_objTemp.m_objTransDataArr[m+1].m_strEchoRight)
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格		
			
//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
//                //血氧饱和度
//                #region 打印一格
//                if (strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, m_intPosY);

//                }
//                #endregion	打印一格

//                intTempColumn++;
//                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
//                //摄入类型
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					
//                }
//                #endregion	打印一格					

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
//                //摄入数量
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if((strValueArr[n][intTempColumn-1]=="D" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intInD.ToString()) || 
//                            (strValueArr[n][intTempColumn-1]=="I" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intInI.ToString()))
//                        {
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格								

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
//                //排出类型
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
					
//                }
//                #endregion	打印一格								

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
//                //排出数量
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,m_intPosY);
//                    /*不要痕迹
//                    if(m+1 < m_objTemp.m_objTransDataArr.Length)
//                    {
//                        if((strValueArr[n][intTempColumn-1]=="U" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutU.ToString()) || 
//                            (strValueArr[n][intTempColumn-1]=="V" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutV.ToString()) ||
//                            (strValueArr[n][intTempColumn-1]=="S" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutS.ToString()) ||
//                            (strValueArr[n][intTempColumn-1]=="E" && 
//                            strValueArr[n][intTempColumn]!=m_objTemp.m_objTransDataArr[m+1].m_intOutE.ToString()))
//                        {
								
						
//                            rtfText.X = intPosX;
//                            rtfText.Y = m_intPosY;

//                            rgnDSTArr[0].First = 0;
//                            rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;

//                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

//                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
//                                rtfText,stfMeasure);

//                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//                            e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//                                rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
//                        }
//                    }*/
//                }
//                #endregion	打印一格								

//                intTempColumn++;
//                intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16 + 1;//当前的X坐标
//                //病程记录
//                #region 打印一格
//                if(strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
////					if(m+1 < m_objTemp.m_objTransDataArr.Length)
////					{
////						if(strValueArr[n][intTempColumn] !=m_objTemp.m_objTransDataArr[m+1].m_strRecordContent)
////						{
////							rtfText.X = intPosX;
////							rtfText.Y = m_intPosY;
////
////							rgnDSTArr[0].First = 0;
////							rgnDSTArr[0].Length = strValueArr[n][intTempColumn].Length;
////
////							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					
////
////							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[n][intTempColumn],m_fotSmallFont,
////								rtfText,stfMeasure);
////
////							rtfBounds = rgnDST[0].GetBounds(e.Graphics);
////
////							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
////								rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
////							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
////								rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
////						}
////					}
//                }
//                #endregion

//                intTempColumn++;
//                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 1;//当前的X坐标
//                #region 签名（作过修改的人签名）
//                if (strValueArr[n][intTempColumn].Trim().Length != 0)
//                {
//                    e.Graphics.DrawString(strValueArr[n][intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);
//                }
//                #endregion	

//                if(n<strValueArr.GetLength(0))
//                    m_intPosY +=intTempDeltaY;

//                //打印行增加，用来控制在适当的时候换页
//                intNowRow ++;
				
//            }
//*/
            #endregion
            m_intCurrentRecordRowIndex = 0;//当一条记录所有行打印完，重置此变量
			return enmReturnValue.enmSuccessed;
		}
	
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private enmReturnValue m_blnPrintOneRowValueOfSummary(string [][] p_strValueArr,System.Drawing.Printing.PrintPageEventArgs e,ref int p_intPosY)
        {
            #region 屏蔽--wf20080121
            /*
            for (int i=0;i<p_strValueArr.Length-1;i++)
			{
				if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
				{
					//若有未打病程记录，还原
					if(strCurrentCaseTextArr != null)
					    intCaseRowCount+=strCurrentCaseTextArr.Length-2-i;

					//换页
					return enmReturnValue.enmNeedNextPage;
				
				}
				string [] strValueArr = p_strValueArr[i];

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

				intTempColumn+=3;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
				//瞳孔大小（左）

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8-1;//当前的X坐标
				//瞳孔大小（右）
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
				}

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
				//瞳孔反射（左）
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
				}

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
				//瞳孔反射（右）
				#region 打印一格
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
				}
				#endregion	打印一格		
				
                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
                //血氧饱和度
                #region 打印一格
                if (strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotTinyFont, Brushes.Black, intPosX, m_intPosY);

                }
                #endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
				//摄入类型
				#region 打印一格
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);
					
				}
				#endregion	打印一格					

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
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
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
				//排出类型
				#region 打印一格
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,m_intPosY);

				}
				#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
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
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
				
				//病程记录（如果有）
				#region 打印一格
				if(strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX+5,m_intPosY);
					rtfText.X = intPosX;
					rtfText.Y = m_intPosY;

//					rgnDSTArr[0].First = 0;
//					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;
//
//					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					
//
//					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);
//
//					rtfBounds = rgnDST[0].GetBounds(e.Graphics);
//
//
//					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,
//						rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
//					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,
//						rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
 				}
				#endregion


				//设置下一行的打印坐标
				m_intPosY+=intTempDeltaY;

				//记录当前已打印的行数
				intNowRow ++;
            }
            */
            #endregion
            string[] strValueArr = p_strValueArr[0];
            CharacterRange[] rgnDSTArr = new CharacterRange[1];
            rgnDSTArr[0] = new CharacterRange(0, 0);	
            RectangleF rtfText = new RectangleF(0, 0, 10000, 100);
            StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);
            RectangleF rtfBounds;
            Region[] rgnDST;
            //24小时
            int intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 1;
            e.Graphics.DrawString(strValueArr[7], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
            //分类
            intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 1;
            e.Graphics.DrawString(strValueArr[8], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
            //总计
            intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 1;
            e.Graphics.DrawString(strValueArr[9], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
            //摄入
            intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 1;
            e.Graphics.DrawString(strValueArr[10], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
            //红色双下划线
            rtfText.X = intPosX;
            rtfText.Y = m_intPosY;
            rgnDSTArr[0].First = 0;
            rgnDSTArr[0].Length = strValueArr[10].Length;
            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);
            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[10], m_fotSmallFont,
                rtfText, stfMeasure);
            rtfBounds = rgnDST[0].GetBounds(e.Graphics);
            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 6,
                rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 6);
            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 9,
                rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 9);
            //摄入量
            if (strValueArr[11] != "")
            {
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 1;
                e.Graphics.DrawString(strValueArr[11], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
                //红色双下划线
                rtfText.X = intPosX;
                rtfText.Y = m_intPosY;
                rgnDSTArr[0].First = 0;
                rgnDSTArr[0].Length = strValueArr[11].Length;
                stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);
                rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[11], m_fotSmallFont,
                    rtfText, stfMeasure);
                rtfBounds = rgnDST[0].GetBounds(e.Graphics);
                e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 6,
                    rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 6);
                e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 9,
                    rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 9);
            }
            //排出
            intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 1;
            e.Graphics.DrawString(strValueArr[12], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
            //红色双下划线
            rtfText.X = intPosX;
            rtfText.Y = m_intPosY;
            rgnDSTArr[0].First = 0;
            rgnDSTArr[0].Length = strValueArr[12].Length;
            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);
            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[12], m_fotSmallFont,
                rtfText, stfMeasure);
            rtfBounds = rgnDST[0].GetBounds(e.Graphics);
            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 6,
                rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 6);
            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 9,
                rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 9);
            //排出量
            if (strValueArr[13] != "")
            {
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 1;
                e.Graphics.DrawString(strValueArr[13], m_fotTinyFont, Brushes.Black, intPosX, p_intPosY);
                //红色双下划线
                rtfText.X = intPosX;
                rtfText.Y = m_intPosY;
                rgnDSTArr[0].First = 0;
                rgnDSTArr[0].Length = strValueArr[13].Length;
                stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);
                rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[13], m_fotSmallFont,
                    rtfText, stfMeasure);
                rtfBounds = rgnDST[0].GetBounds(e.Graphics);
                e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 6,
                    rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 6);
                e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 9,
                    rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 9);
            }
            intNowRow++;
            p_intPosY += intTempDeltaY; 
            return enmReturnValue.enmSuccessed;
		}
	


	}
//	public enum enmReturnValue
//	{
//		enmSuccessed=1,
//		enmFaild=-1,
//		enmNeedNextPage=2,
//		
//	}
		#endregion ;
		


}
