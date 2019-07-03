using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using com.digitalwave.clsIntensiveTendRecord_GXService;
namespace iCare
{
	/// <summary>
	/// 危重患者护理记录打印工具类(新版)摘要说明。
	/// </summary>
	public class clsIntensiveTendMain_GX_PrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;               //表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;	                   //是否需要初始化	
		private clsRecordsDomain m_objRecordsDomain;           //记录域
		private clsPrintInfo_IntensiveTendGX m_objPrintInfo;     //打印内容
		private string strCurrentClass;                        //当前班次默认为空
		private int intCaseRowCount;                           //当前病程记录的最大行数
		private string[] strCurrentCaseTextArr;                //当前病程记录内容数组
		private string[] strCurrentCaseXmlArr;                 //当前病程记录痕迹数组
		private string[] strCurrentCaseCreateDateArr;          //当前病程记录创建时间
		private object [][] objDataArr;
	
		private string strDiagnose;
		private object[] objtest1;

		private string[] m_strCustomColumn;
		private string m_strDiagnose;
        
        private string strTempDate=string.Empty; 
	     private bool m_bSummaryRow=false;
		

		public clsIntensiveTendMain_GX_PrintTool(string[] strColumnName)
		{
		   
			//从Form传过来的自定义列名
			for(int i1=0;i1<4;i1++)
			{
             strColumnName[i1]=strColumnName[i1].Replace("\r\n","");
			}
			m_strCustomColumn=strColumnName;
			m_strDiagnose=strColumnName[4];
			

			//
		}
		/// 获取总入量
		/// </summary>
		/// <param name="dtStartTime"></param>
		/// 
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		
		
		#region 打印初始化、事件
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		/// p_objPatient
		
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{		
			m_blnIsFromDataSource=true;//表明是从数据库读取
			clsPatient m_objPatient=p_objPatient;
			m_objPrintInfo=new  clsPrintInfo_IntensiveTendGX ();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo.m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo.m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			
			m_objPrintInfo.m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
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
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.IntensiveTendRecord_GX);
				
			long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo .m_objTransDataArr,out m_objPrintInfo.m_dtmFirstPrintDateArr,out m_objPrintInfo.m_blnIsFirstPrintArr);
			if(lngRes <= 0)
				return ;   
    		m_blnWantInit=false;

		}
		private DateTime m_dtmPreRecordDate;
		private cltDataGridDSTRichTextBox m_dtcINITEM;
		public cltDataGridDSTRichTextBox m_dtcINFACT;
		public cltDataGridDSTRichTextBox m_dtcOUTPISS;
		public cltDataGridDSTRichTextBox m_dtcOUTSTOOL;
		private cltDataGridDSTRichTextBox m_dtcCHECKT;
		private cltDataGridDSTRichTextBox m_dtcCHECKP;
		private cltDataGridDSTRichTextBox m_dtcCHECKR;
		private cltDataGridDSTRichTextBox m_dtcCHECKBP;

		

		private int m_intCurrentPagePrintRow=0;
		private int m_intCurrentContentRow=0;

		private int m_intMainCurrentPagePrintRow=0;
		private int m_intMainCurrentContentRow=0;
		
		


		
		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>


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
			m_fotHeaderFont = new Font("SimSun", 12f);
			m_fotSmallFont = new Font("SimSun",10.5f);
			m_fotHosNameFont = new Font("SimSun",14f);
			m_fotTinyFont=new Font("SimSun",8f);

			m_GridPen = new Pen(Color.Black,1);
			m_GridRedPen = new Pen(Color.Red ,2);

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
			m_GridRedPen.Dispose();
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
		
		public void m_mthPrintPage(PageSettings p_pstDefault)
		{
			frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
			frmPreview.m_evtBeginPrint +=new PrintEventHandler(frmPreview_m_evtBeginPrint);
			frmPreview.m_evtEndPrint +=new PrintEventHandler(frmPreview_m_evtEndPrint);
			frmPreview.m_evtPrintContent +=new PrintPageEventHandler(frmPreview_m_evtPrintContent);
			frmPreview.m_evtPrintFrame +=new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
			frmPreview.m_pstDefaultPageSettings = p_pstDefault;
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
	
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_IntensiveTend")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_IntensiveTendGX)p_objPrintContent;
			//m_objPrintDataArr= m_objPrintInfo. m_objPrintDataArr ;		
			
			m_blnWantInit=false;
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
			m_intCurrentRecord=0;
			m_intCurrentContentRow=0;
			m_intMainCurrentContentRow=0;
			m_intCurrentPagePrintRow=0;
			intNowPage=1;
			blnBeginPrintNewRecord=true;
			m_intRowNumberForPrintData = 0;
			m_intPosY = (int)enmRecordRectangleInfo.TopY+130;
		}
		


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
		/// 表内容的字体
		/// </summary>
		private Font m_fotHosNameFont;
		/// <summary>
		/// 最小的字体
		/// </summary>
		private Font m_fotTinyFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		private Pen m_GridRedPen;
		
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
			TopY = 180,

			/// <summary>
			/// 表头第一条分割线
			/// </summary>
			RowsMark1=60,
			/// <summary>
			/// 表头第二条分割线
			/// </summary>
			RowsMark2=90,
	

			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 30,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 1110,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 38,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 12,	
			/// <summary>
			/// 文字在格子中相对格子顶端的垂直偏移
			/// </summary>
			VOffSet = 20,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=16,
			/// <summary>
			/// 第一条间隔线(X),时间（起点线）
			/// </summary>			
			ColumnsMark1=80,
			/// <summary>
			/// 第二条间隔线(X)，T（起点线）
			/// </summary>
			ColumnsMark2=120,

			/// <summary>
			/// 第3条间隔线(X)，HR（起点线）
			/// </summary>
			ColumnsMark3=210,

			/// <summary>
			/// P（起点线）
			/// </summary>
			ColumnsMark4=270,

			/// <summary>
			/// R（起点线）
			/// </summary>
			ColumnsMark5=308,

			/// <summary>
			/// Bp（起点线）
			/// </summary>
			ColumnsMark6=346,

			/// <summary>
			/// CVP（起点线）
			/// </summary>
			ColumnsMark7=394,

			/// <summary>
			/// 血糖（起点线）
			/// </summary>
			ColumnsMark8=443,

			/// <summary>
			/// 神志（起点线）
			/// </summary>
			ColumnsMark9=483,

			/// <summary>
			/// 瞳孔大小　左（起点线）
			/// </summary>
			ColumnsMark10=523,

			/// <summary>
			/// 瞳孔大小　右（起点线）
			/// </summary>
			ColumnsMark11=563,

			/// <summary>
			/// 对光反射　左（起点线）
			/// </summary>
			ColumnsMark12=613,

			/// <summary>
			/// 对光反射　右（起点线）
			/// </summary>
			ColumnsMark13=673,

			/// <summary>
			/// 肌力（起点线）
			/// </summary>
			ColumnsMark14=743,

			/// <summary>
			/// 入量：输入液量：药名（起点线）
			/// </summary>
			ColumnsMark15=810,		
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
			
            
			//e.Graphics.DrawString(,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
		
			int leftpos=(int)(512-(12.8*8/2));
			

		 	
			m_mthDrawMultiSstring(this.m_fotHosNameFont ,(int)enmRecordRectangleInfo.LeftX ,50,(int)enmRecordRectangleInfo.RightX ,100,1,1,clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,e);
			
			m_mthDrawMultiSstring(this.m_fotTitleFont ,(int)enmRecordRectangleInfo.LeftX ,100,(int)enmRecordRectangleInfo.RightX ,138,1,1,"危  重  患  者  护  理  记  录",e);
			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+30,150);
			e.Graphics.DrawString(m_objPrintInfo.m_strDeptName,m_fotSmallFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+70,150);

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,200,150);
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo  ,m_fotSmallFont,m_slbBrush,240,150);	
			
			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,340,150);
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName ,m_fotSmallFont,m_slbBrush,380,150);
		
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,450,150);
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID  ,m_fotSmallFont,m_slbBrush,520,150);	

			e.Graphics.DrawString("诊断：",m_fotSmallFont,m_slbBrush,640,150);
			e.Graphics.DrawString(m_strDiagnose,m_fotSmallFont,m_slbBrush,680,150);
			
			e.Graphics.DrawString("打印日期：",m_fotSmallFont,m_slbBrush,900,150);
			e.Graphics.DrawString(DateTime.Now.ToString("yyyy年MM月dd日"),m_fotSmallFont,m_slbBrush,970,150);	
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
			//入量
			e.Graphics.DrawString("入量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+60, (int)enmRecordRectangleInfo.TopY+25);
			e.Graphics.DrawString("项目",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+30,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);
			e.Graphics.DrawString("实入量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+3,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);
			//出量
			e.Graphics.DrawString("出量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4 +60,(int)enmRecordRectangleInfo.TopY+25);

			e.Graphics.DrawString("小便",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+ 1,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);

			e.Graphics.DrawString("大便",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5 +1,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);

			if(m_strCustomColumn[0].ToString().Trim().Length != 0)
			{
				m_mthDrawMultiSstring(this.m_fotHeaderFont ,this.m_fotTinyFont,3,(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark6,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark1,+
					 (float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark7,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark2,+
					1,5,m_strCustomColumn[0].ToString().Trim(),e);
			}
			
			//自定义2
			if(m_strCustomColumn[1].ToString().Trim().Length != 0)
			{
             
				m_mthDrawMultiSstring(this.m_fotHeaderFont ,this.m_fotTinyFont,3,(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark7,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark1,+
					(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark8,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark2,+
					1,5,m_strCustomColumn[1].ToString().Trim(),e);
			}
	
	
			//T.
			e.Graphics.DrawString("T: C、P:次/分、",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8 +3,(int)enmRecordRectangleInfo.TopY+15);
			e.Graphics.DrawString("R: 次/分、BP:mmHg",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8 +3,(int)enmRecordRectangleInfo.TopY+35);
			e.Graphics.DrawString("T",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8 +6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);
			e.Graphics.DrawString("P",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9 +6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);
			e.Graphics.DrawString("R",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10 +6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);
			e.Graphics.DrawString("BP",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark11 +6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1 +5);

			
			//自定义3
			if(m_strCustomColumn[2].ToString().Trim().Length != 0)
			{
		
				m_mthDrawMultiSstring(this.m_fotHeaderFont ,this.m_fotHeaderFont,3,(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark12,(float)enmRecordRectangleInfo.TopY,+
					(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark13,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark2,+
					1,(int)enmRecordRectangleInfo.RowStep,m_strCustomColumn[2].ToString().Trim(),e);
			}
			
			//自定义4
			if(m_strCustomColumn[3].ToString().Trim().Length != 0)
			{
				//e.Graphics.DrawString(m_strCustomColumn[3].ToString().Trim(),m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13 +10,
				//	(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);

				m_mthDrawMultiSstring(this.m_fotHeaderFont ,this.m_fotHeaderFont,3,(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark13,(float)enmRecordRectangleInfo.TopY,+
					(float)enmRecordRectangleInfo.LeftX+(float)enmRecordRectangleInfo.ColumnsMark14,(float)enmRecordRectangleInfo.TopY+(float)enmRecordRectangleInfo.RowsMark2,+
					1,(int)enmRecordRectangleInfo.RowStep,m_strCustomColumn[3].ToString().Trim(),e);

				
			}
			
			//签名
			e.Graphics.DrawString("签名",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14 +10,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
			//病情记录
			e.Graphics.DrawString("病情记录",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15 +80,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);
		
		}
		#endregion
		private void m_mthDrawMultiSstring(Font fotNormal,Font fotSmall,int iLimitLenth,float x,float y,float x1,float y1,float xOff,float yOff,string strContent,System.Drawing.Printing.PrintPageEventArgs e)
		{
		
			RectangleF drawRect=new RectangleF(x,y+1,x1-x,y1-y);
			RectangleF drawRectNormal=new RectangleF(x,y+yOff,x1-x,y1-y);

			StringFormat strFormat=new StringFormat();
			strFormat.Alignment =System.Drawing.StringAlignment.Center ;
			strFormat.FormatFlags=System.Drawing.StringFormatFlags.LineLimit;   
  
			if(strContent.Length >iLimitLenth)
			{
				 e.Graphics.DrawString(strContent,fotSmall,m_slbBrush,drawRect,strFormat);
			}
			else
		    {
                e.Graphics.DrawString(strContent,fotNormal,m_slbBrush,drawRectNormal,strFormat);
				
		     }
        
		}
		private void m_mthDrawMultiSstring(Font fotNormal,float x,float y,float x1,float y1,float xOff,float yOff,string strContent,System.Drawing.Printing.PrintPageEventArgs e)
		{
		
			RectangleF drawRect=new RectangleF(x,y+yOff,x1-x,y1-y);
			StringFormat strFormat=new StringFormat();
			strFormat.Alignment =System.Drawing.StringAlignment.Center ;
			strFormat.FormatFlags=System.Drawing.StringFormatFlags.LineLimit;   
  
			e.Graphics.DrawString(strContent, fotNormal,m_slbBrush,drawRect,strFormat);
			
        
		}

		#region 画格子
		/// <summary>
		///  画格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			
				
			#region//画格子横线
			//画格子横线
			for(int i1=0;i1<=(int)enmRecordRectangleInfo.RowLinesNum+2 ;i1++)
			{
				if(i1==0)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY);
				else if(i1 !=1 && i1 !=2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int)enmRecordRectangleInfo.RowStep)*(i1-2),
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int)enmRecordRectangleInfo.RowStep)*(i1-2));
				else if(i1==1)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark2,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark12,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1) ;
				else //if(i1==2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2 );
			}
			
			#endregion 画格子横线
			#region 画格子竖线
			int intHeight=(int)enmRecordRectangleInfo.RowsMark2+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep;

			//画日期左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画时间左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画入量项目左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画 出入量左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画小便左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画大便左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画呕吐左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画出量自定义左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画T左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画P左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画/r左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画BP左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画空格左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画自定义2左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画自定义3左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画签名左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画病情记录左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY+intHeight);

			#endregion
		}

						
		#endregion

		#region 打印具体实现
		
	
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
					
			DateTime dtmFlagTime;
			/*记录该页当前的打印的行*/
			intNowRow=1; 			

	       int iTemp=(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum+1))+70;


			m_mthDrawMultiSstring(this.m_fotSmallFont ,(int)enmRecordRectangleInfo.LeftX ,iTemp,(int)enmRecordRectangleInfo.RightX ,iTemp+70,1,1,"（第"+intNowPage.ToString()+"页）",e);

			if(m_objPrintInfo.m_strInPatentID =="")return;

			m_intCurrentRecord=0;

			//打印主循环
			for(int i1=m_intMainCurrentContentRow;i1<m_objPrintInfo.m_objTransDataArr.Length ;i1++)
			{ 
				clsIntensiveTendRecord_GXDataInfo aa=new clsIntensiveTendRecord_GXDataInfo ();
				aa =(clsIntensiveTendRecord_GXDataInfo) m_objPrintInfo.m_objTransDataArr [i1];
				objDataArr = m_objGetRecordsValueArr(aa);
				if(objDataArr==null)
                  continue;
				for(m_intCurrentRecord=m_intCurrentContentRow;m_intCurrentRecord<objDataArr.Length ;m_intCurrentRecord++)
				{
			     

					enmReturnValue m_enmRe= m_blnPrintOneValueGX(e, m_intPosY);	

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
  
					  
				}
			
				
			  m_intMainCurrentContentRow++;
			
			}	
		}

		
		
	
		#region 只打印一行
		/// <summary>
		/// 只打印一行
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private enmReturnValue m_blnPrintOneValueGX(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			//m_intPosY +=(int)enmRecordRectangleInfo.VOffSet;
			enmReturnValue enmIsRecordFinish=m_blnPrintOneRowValueGX(e);
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
		private string m_strConvertObjectValue(object obj)
		{
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
			string strTemp="";
			if(obj==null)
			{
				strTemp="";
			}
			else
			{
				if(obj.GetType().Name =="clsDSTRichTextBoxValue")
				{
					objclsDSTRichTextBoxValue=(clsDSTRichTextBoxValue)obj;
					if(objclsDSTRichTextBoxValue.m_blnUnderDST==true)
					{
                       m_bSummaryRow=true;
					}
                    
					strTemp= objclsDSTRichTextBoxValue.m_strText;  
				}
				else
				{
					strTemp=obj.ToString();
				}
			}
			return strTemp;
		}
		private bool m_blnCheckPageChange(System.Drawing.Printing.PrintPageEventArgs e)
		{
			//当当前行超过最后一行（即 >页总行数）时换页
			if(m_intCurrentPagePrintRow>((int)enmRecordRectangleInfo.RowLinesNum-1)/*除去表头3行外总有效行数*/) 
			{
				m_intCurrentPagePrintRow=0;
				intNowPage ++;

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
		
		
	
		private enmReturnValue m_blnPrintOneRowValueGX(System.Drawing.Printing.PrintPageEventArgs e)
		{			
    		string strTemp;
			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;
	
								
			if(m_blnCheckPageChange(e)==true) //每打印一行之前都要检查是否换页
			{
				return enmReturnValue.enmNeedNextPage;
				//换页
					
			}

			     
			    
			 
			//日期
			int m_intPosX=(int)enmRecordRectangleInfo.LeftX;//当前的X坐标
			int m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
			int m_intPosY=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int) m_intCurrentPagePrintRow*(int)enmRecordRectangleInfo.RowStep);
			int m_intPosY1=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+(((int) m_intCurrentPagePrintRow+1)*(int)enmRecordRectangleInfo.RowStep);
            int m_intXOff=1;
			int m_intYOff=15;
			int intTempColumn=4;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX+, m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
				strTempDate=strTemp;
			}
			//换行时第一行的日期不能省去,前数值不为空，现数值为空，且处于第一行
			if(strTempDate.Trim().Length != 0&&m_intCurrentPagePrintRow==0&&strTemp.Trim().Length == 0)
			{
				strTemp=strTempDate;
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}

			//时间
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标 
			intTempColumn=5;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY+15);
				//m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,0,m_intYOff,strTemp,e);
			}
			//项目
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标 
			intTempColumn=6;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			
			if(strTemp.Trim().Length != 0)
			{
				
				m_mthDrawMultiSstring(m_fotSmallFont,m_fotSmallFont,5,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			
			//实入量
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标 
			intTempColumn=7;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
           //画统计线
			if(m_bSummaryRow==true)
			{
				e.Graphics.DrawLine(m_GridRedPen,((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2),
					(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int) m_intCurrentPagePrintRow*(int)enmRecordRectangleInfo.RowStep),
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,
					(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int) m_intCurrentPagePrintRow*(int)enmRecordRectangleInfo.RowStep));
				e.Graphics.DrawLine(m_GridRedPen,((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2),
					(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int) (m_intCurrentPagePrintRow+1)*(int)enmRecordRectangleInfo.RowStep),
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,
					(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2+((int) (m_intCurrentPagePrintRow+1)*(int)enmRecordRectangleInfo.RowStep));
				

			}
			m_bSummaryRow=false;

			//小便
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标 
			intTempColumn=8;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);

			}

			//大便
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标 
			intTempColumn=9;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			//画呕吐左边线
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标 
			intTempColumn=10;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}

			//出量自定义
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标 
			intTempColumn=11;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_fotSmallFont,3,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);

			}

			//T
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标 
			intTempColumn=12;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);

			}
			//P
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标 
			intTempColumn=13;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			//r
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标 
			intTempColumn=14;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			//BP
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标 
			intTempColumn=15;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring (this.m_fotSmallFont,m_intPosX, m_intPosY,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,m_intPosY+38,1,1,strTemp,e);
			}
			
		
			//定义2
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标 
			intTempColumn=16;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				//m_mthDrawMultiSstring (this.m_fotSmallFont,m_intPosX, m_intPosY,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,m_intPosY+38,1,1,strTemp,e);
				m_mthDrawMultiSstring(m_fotSmallFont,m_fotSmallFont,5,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);

			}

			//自定义3左边线
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标 
			intTempColumn=17;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{

				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_fotSmallFont,5,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			//签名
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标 
			intTempColumn=18;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY);
				m_mthDrawMultiSstring(m_fotSmallFont,m_fotSmallFont,4,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
			}
			//病情记录
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
			m_intPosX1 =(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.RightX;//当前的X坐标 
			intTempColumn=19;
			
			try
			{
				strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
				if(strTemp.Trim().Length != 0)
				{
					e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY+15);
				}
			}
			catch(Exception ex)
			{
              
			}


			
			m_intCurrentContentRow++;
			m_intCurrentPagePrintRow++;
			
			
			#endregion

			return enmReturnValue.enmSuccessed;
		}
	
		
	
		private double m_dblGetInSum(DateTime dtStartTime, DateTime dtEndTime)
		{
			double dblInSum = 0;

            clsIntensiveTendRecord_GXService objServ =
                (clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecord_GXService));

			double[] dblInSumArr = null;
		   
			long lngRes = objServ.m_lngGetInSum(m_objPrintInfo.m_strInPatentID , m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"), out dblInSumArr);

			if(lngRes > 0 && dblInSumArr != null)
			{
				for(int i=0; i<dblInSumArr.Length; i++)
				{
					dblInSum += dblInSumArr[i];
				}
			}
			return dblInSum;
		}

		/// <summary>
		/// 获取总出量
		/// </summary>
		/// <param name="dtStartTime"></param>
		private double m_dblGetOutSum(DateTime dtStartTime, DateTime dtEndTime)
		{
            double dblOutSum = 0;
            clsIntensiveTendRecord_GXService objServ =
                (clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecord_GXService));

			double[] dblOutPissArr = null;
			double[] dblOutStoolArr = null;
			double[] p_dblCustom1Arr = null;
			double[] p_dblCustom2Arr = null;
			long lngRes = objServ.m_lngGetOutSum(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"), out dblOutPissArr, out dblOutStoolArr,out p_dblCustom1Arr,out p_dblCustom2Arr);

			if(lngRes > 0 && dblOutPissArr != null && dblOutStoolArr!=null && p_dblCustom1Arr!=null && p_dblCustom2Arr != null)
			{
				for(int i=0; i<dblOutPissArr.Length; i++)
				{
					dblOutSum += dblOutPissArr[i];
				}
				for(int i=0; i<dblOutStoolArr.Length; i++)
				{
					dblOutSum += dblOutStoolArr[i];
				}
				for(int i=0; i<p_dblCustom1Arr.Length; i++)
				{
					dblOutSum += p_dblCustom1Arr[i];
				}
				for(int i=0; i<p_dblCustom2Arr.Length; i++)
				{
					dblOutSum += p_dblCustom2Arr[i];
				}
			}
			return dblOutSum;
		}
		private int m_intGetClass(DateTime dtmRecordDate)
		{
			string strDate = dtmRecordDate.Year.ToString()+dtmRecordDate.Month.ToString()+dtmRecordDate.Day.ToString();
			string strYesterday = dtmRecordDate.Year.ToString()+dtmRecordDate.Month.ToString()+dtmRecordDate.AddDays(-1).Day.ToString();
			DateTime dtClass= DateTime.Parse(dtmRecordDate.ToString("yyyy-MM-dd HH:mm:00"));
			DateTime dtDt0 = dtmRecordDate.Date;
			DateTime dt1=dtDt0.AddHours(2).AddMinutes(1);
			DateTime dt2=dtDt0.AddHours(8);
			DateTime dt3=dtDt0.AddHours(14).AddMinutes(31);
			DateTime dt4=dtDt0.AddHours(18).AddMinutes(1);
			DateTime dt5=dtDt0.AddHours(26).AddMinutes(1);

			if(dtmRecordDate >= dt1 && dtmRecordDate < dt2)
				return Convert.ToInt32(strDate + "0");
			else if(dtmRecordDate >= dt2 && dtmRecordDate < dt3)
				return Convert.ToInt32(strDate + "1");
			else if(dtmRecordDate >= dt3 && dtmRecordDate < dt4)
				return Convert.ToInt32(strDate + "2");
			else if(dtmRecordDate >= dt4 && dtmRecordDate < dt5)
				return Convert.ToInt32(strDate + "3");
			else if(dtmRecordDate < dt1)
				return Convert.ToInt32(strYesterday + "3");
			return 0;
		}
		private bool m_blnIsSameClass(DateTime p_dtmMainRecord, DateTime p_dtmDetail)
		{
			if(m_intGetClass(p_dtmMainRecord) == m_intGetClass(p_dtmDetail))
				return true;
			else
				return false;
		}
        private object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
        {
            com.digitalwave.controls.ctlRichTextBox m_txtTemp = new com.digitalwave.controls.ctlRichTextBox();
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();
                ArrayList arlDetail = new ArrayList();//存放病情记录fjf
                int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引
                //				bool blnIsAddBlank = false;//是否在该行病情记录显示完后填入空行
                //				int intBlankRows = 0;//在该行病情记录后填入的空行数量
                bool blnIsFirst = true;//是否是统计时间段的第一条有效记录
                DateTime dtmBegin = DateTime.MinValue;//统计时间段的开始时间
                bool blnIsSameClass = false;
                int intRecordCount = 0;

                clsIntensiveTendRecord_GXDataInfo objITRCInfo = new clsIntensiveTendRecord_GXDataInfo();
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                objITRCInfo = (clsIntensiveTendRecord_GXDataInfo)p_objTransDataInfo;

                if (objITRCInfo.m_objRecordArr == null && objITRCInfo.m_objDetailArr == null)
                    return null;

                #region 获取修改限定时间
                int intCanModifyTime = 0;
                
                #endregion

                #region 对病情记录进行处理
                if (objITRCInfo.m_objDetailArr != null)
                {
                    string strDetail = "";
                    string strDetailXML = "";
                    for (int n = 0; n < objITRCInfo.m_objDetailArr.Length; n++)
                    {
                        clsIntensiveTendRecordDetail_GX objDetail = objITRCInfo.m_objDetailArr[n];
                        object[] objTemp = new object[7];
                        strDetail = objDetail.m_strDETAILCONTENT;
                        strDetailXML = objDetail.m_strDETAILCONTENTXML;
                        m_txtTemp.m_mthSetNewText(strDetail, strDetailXML);
                        string[] strDetailArrTemp;
                        string[] strDetailXMLArrTemp;
                        //将病情记录分行。
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(m_txtTemp.m_strGetRightText(), strDetailXML, 34, out strDetailArrTemp, out strDetailXMLArrTemp);
                        string[] strDetailArr, strDetailXMLArr;
                        if (strDetail != string.Empty)
                        {
                            strDetailArr = new string[strDetailArrTemp.Length + 2];//存放添加日期和签名后病情记录
                            strDetailXMLArr = new string[strDetailXMLArrTemp.Length + 2];//存放添加日期和签名后病情记录XML

                            //将日期和签名添加进病情记录
                            strDetailArr[0] = objDetail.m_dtmDETAILRECORDDATE.ToString("yyyy-MM-dd HH:mm");
                            strDetailArr[1] = strDetailArrTemp[0];
                            for (int i = 2; i < strDetailArr.Length - 1; i++)
                            {
                                strDetailArr[i] = strDetailArrTemp[i - 1];
                            }
                            strDetailArr[strDetailArr.Length - 1] = "                         " + objDetail.m_strDETAILSIGNNAME;

                            strDetailXMLArr[0] = strDetailXMLArr[strDetailXMLArr.Length - 1] = "";
                            for (int i = 1; i < strDetailXMLArr.Length - 1; i++)
                            {
                                strDetailXMLArr[i] = strDetailXMLArrTemp[i - 1];
                            }

                            objTemp[0] = strDetailArr;
                            objTemp[1] = strDetailXMLArr;
                            objTemp[2] = strDetailArr.Length;
                            objTemp[3] = objDetail.m_dtmDETAILRECORDDATE;
                            objTemp[4] = objDetail.m_intSTAT_STATUS;
                            objTemp[5] = objDetail.m_strDETAILSIGNNAME;
                            objTemp[6] = objDetail.m_strDETAILSIGNID;
                            arlDetail.Add(objTemp);
                        }
                    }
                }
                #endregion

                if (objITRCInfo.m_objRecordArr != null)
                    intRecordCount = objITRCInfo.m_objRecordArr.Length;
                int intRowOfCurrentDetail = 0;

                for (int i = 0; i < intRecordCount; i++)
                {
                    objData = new object[22];
                    clsIntensiveTendRecord_GX objCurrent = objITRCInfo.m_objRecordArr[i];
                    clsIntensiveTendRecord_GX objNext = new clsIntensiveTendRecord_GX();//下一条护理记录
                    if (i < intRecordCount - 1)
                        objNext = objITRCInfo.m_objRecordArr[i + 1];

                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                   // if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim())
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    {
                      //  TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                      //  if ((int)tsModify.TotalHours < intCanModifyTime)
                            continue;
                    }

                    //this.m_txtDiagnose.Text = objCurrent.m_strDIAGNOSE;//将诊断显示到界面

                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRECORDDATE;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.IntensiveTendRecord_GX;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一天则只在第一行显示日期
                        if (objCurrent.m_dtmRECORDDATE.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRECORDDATE)
                            objData[5] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串
                        //						if(blnIsFirst )
                        //						{
                        //							dtmBegin = objCurrent.m_dtmRECORDDATE;
                        //							blnIsFirst = false;
                        //						}
                        //						if(objCurrent.m_intSTAT_STATUS == 1)
                        //						{
                        //							blnIsFirst = true;
                        //							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                        //								blnIsFirst = false;
                        //						}

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                    #endregion ;

                    #region 存放单项信息
                    //入量>>项目
                    objData[6] = objCurrent.m_strINITEM_RIGHT;

                    //入量>>实入量
                    objData[7] = objCurrent.m_strINFACT_RIGHT; ;

                    //出量>>小便
                    objData[8] = objCurrent.m_strOUTPISS_RIGHT;

                    //出量>>大便
                    objData[9] = objCurrent.m_strOUTSTOOL_RIGHT;

                    //出量>>自定义列1
                    objData[10] = objCurrent.m_strCUSTOM1_RIGHT;

                    //出量>>自定义列2
                    
                    objData[11] = objCurrent.m_strCUSTOM2_RIGHT;

                    //体温T
                    objData[12] = objCurrent.m_strCHECKT_RIGHT;

                    //脉搏P
                    objData[13] = objCurrent.m_strCHECKP_RIGHT;

                    //呼吸R
                    objData[14] = objCurrent.m_strCHECKR_RIGHT;

                    //血压BP
                    strText = objCurrent.m_strCHECKBPA_RIGHT + "/" + objCurrent.m_strCHECKBPS_RIGHT;
                    if ((objCurrent.m_strCHECKBPA_RIGHT == null || objCurrent.m_strCHECKBPA_RIGHT == "") && (objCurrent.m_strCHECKBPS_RIGHT == null || objCurrent.m_strCHECKBPS_RIGHT == ""))
                        strText = "";
                    string strNextText = "";
                    if (objNext != null)
                    {
                        strNextText = objNext.m_strCHECKBPA_RIGHT + "/" + objNext.m_strCHECKBPS_RIGHT;
                        if ((objNext.m_strCHECKBPA_RIGHT == null || objNext.m_strCHECKBPA_RIGHT == "") && (objNext.m_strCHECKBPS_RIGHT == null || objNext.m_strCHECKBPS_RIGHT == ""))
                            strNextText = "";
                    }
                    objData[15] = strText;

                    //自定义列3
       
                    objData[16] = objCurrent.m_strCUSTOM3_RIGHT;

                    //自定义列4
         
                    objData[17] = objCurrent.m_strCUSTOM4_RIGHT;

                    //签名	
                    //if(objCurrent.m_strNURSESIGNID != "" && objCurrent.m_strNURSESIGNID != null)
                    //{
                    //    clsEmployee objEmp = new clsEmployee(objCurrent.m_strNURSESIGNID);
                    //    objData[18] = objEmp.m_StrLastName;
                    //}
                    objData[18] = objCurrent.m_strNURSESIGNNAME;

                    //病情记录
                    if (arlDetail != null && intCurrentDetail < arlDetail.Count &&
                        arlDetail.Count > 0)
                    {
                        //如为旧记录未有保存班次信息，重新进行判断
                        if (objCurrent.m_intSTAT_STATUS == 0 || objCurrent.m_intSTAT_STATUS == 1 || (int)(((object[])arlDetail[intCurrentDetail])[4]) == 0)
                            blnIsSameClass = m_blnIsSameClass(objCurrent.m_dtmRECORDDATE, (DateTime)(((object[])arlDetail[intCurrentDetail])[3]));
                        else
                            blnIsSameClass = objCurrent.m_intSTAT_STATUS == (int)(((object[])arlDetail[intCurrentDetail])[4]) ? true : false;
                        if (blnIsSameClass)
                        {
                            strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[intRowOfCurrentDetail];
                            strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[intRowOfCurrentDetail];
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objData[19] = strText;
                            objData[20] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                            objData[21] = objCurrent.m_strCreateUserID + "★" + (((object[])arlDetail[intCurrentDetail])[6]).ToString();

                            if (intRowOfCurrentDetail == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                            {
                                intRowOfCurrentDetail = 0;
                                intCurrentDetail++;
                            }
                            else
                                intRowOfCurrentDetail++;

                            objReturnData.Add(objData);
                        }
                        else if (objNext != null)//如果该条病情记录未完全显示完且下一条护理记录的班次跟当前记录的班次不同，则先将病情记录全部显示
                        {
                            while (arlDetail != null &&
                                intCurrentDetail < arlDetail.Count &&
                                intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length &&
                                (DateTime)(((object[])arlDetail[intCurrentDetail])[3]) <= objCurrent.m_dtmRECORDDATE)
                            {
                                //如为旧记录未有保存班次信息，重新进行判断
                                if (objNext.m_intSTAT_STATUS == 0 || objNext.m_intSTAT_STATUS == 1 || (int)(((object[])arlDetail[intCurrentDetail])[4]) == 0)
                                    blnIsSameClass = m_blnIsSameClass(objCurrent.m_dtmRECORDDATE, (DateTime)(((object[])arlDetail[intCurrentDetail])[3]));
                                else
                                    blnIsSameClass = objNext.m_intSTAT_STATUS == (int)(((object[])arlDetail[intCurrentDetail])[4]) ? true : false;

                                if (!blnIsSameClass)
                                {
                                    object[] objInstance = null;
                                    for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                                    {
                                        objInstance = new object[22];
                                        strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                                        strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                        objclsDSTRichTextBoxValue.m_strText = strText;
                                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                        objInstance[19] = strText;
                                        objInstance[20] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                                        objInstance[21] = objCurrent.m_strCreateUserID + "★" + (((object[])arlDetail[intCurrentDetail])[6]).ToString();
                                        objReturnData.Add(objInstance);

                                        if (m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                                        {
                                            intRowOfCurrentDetail = 0;
                                            intCurrentDetail++;
                                            break;
                                        }
                                    }
                                }
                                else
                                    break;
                            }
                        }

                    }
                    if (objData != null && objData[19] == null)
                        objReturnData.Add(objData);

                    if (blnIsFirst)
                    {
                        blnIsFirst = false;
                        string strBegin = objCurrent.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm:00");
                        dtmBegin = DateTime.Parse(strBegin);
                    }
                    #region 当m_intISSTAT==-1时表示旧的统计信息，暂用旧的显示方法
                    if (objCurrent.m_intISSTAT == -1 && objNext != null && objNext.m_intISSTAT != 1 &&
                        ((objCurrent.m_dtmRECORDDATE.Hour < 8 && objNext.m_dtmRECORDDATE.Hour >= 8) ||
                        ((objNext.m_dtmRECORDDATE.Date - objCurrent.m_dtmRECORDDATE.Date).Days >= 1 && objNext.m_dtmRECORDDATE.Hour >= 8)))//每天早上8点进行统计
                    {
                        if (objNext.m_dtmCreateDate != objCurrent.m_dtmCreateDate)
                        {
                            if (intRowOfCurrentDetail != 0 && arlDetail != null && intCurrentDetail < arlDetail.Count && intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                            {
                                object[] objInstance = null;
                                for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                                {
                                    objInstance = new object[22];
                                    strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                                    strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objInstance[19] = strText;
                                    objInstance[20] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                                    objInstance[21] = objCurrent.m_strCreateUserID + "★" + (((object[])arlDetail[intCurrentDetail])[6]).ToString();
                                    objReturnData.Add(objInstance);

                                    if (m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                                    {
                                        intRowOfCurrentDetail = 0;
                                        intCurrentDetail++;
                                        break;
                                    }
                                }
                                //								blnIsAddBlank = false;
                            }
                            double dblInSum = 0;
                            double dblOutSum = 0;
                            double dblSubHours = 0;
                            TimeSpan ts = objCurrent.m_dtmRECORDDATE - dtmBegin;
                            if (ts.TotalHours < 24)
                            {
                                if (objCurrent.m_dtmRECORDDATE.Hour >= 0 && objCurrent.m_dtmRECORDDATE.Hour < 8)
                                {
                                    ts = objCurrent.m_dtmRECORDDATE.Date.AddHours(8) - dtmBegin;
                                }
                                else
                                {
                                    ts = objCurrent.m_dtmRECORDDATE.Date.AddDays(1).AddHours(8) - dtmBegin;
                                }
                                dblSubHours = ts.TotalHours;
                                dblInSum = m_dblGetInSum(dtmBegin, objCurrent.m_dtmRECORDDATE);
                                dblOutSum = m_dblGetOutSum(dtmBegin, objCurrent.m_dtmRECORDDATE);
                            }
                            else
                            {
                                dblSubHours = 24;
                                if (objCurrent.m_dtmRECORDDATE.Hour >= 0 && objCurrent.m_dtmRECORDDATE.Hour < 8)
                                {
                                    dblInSum = m_dblGetInSum(objCurrent.m_dtmRECORDDATE.Date.AddDays(-1).AddHours(8), objCurrent.m_dtmRECORDDATE);
                                    dblOutSum = m_dblGetOutSum(objCurrent.m_dtmRECORDDATE.Date.AddDays(-1).AddHours(8), objCurrent.m_dtmRECORDDATE);
                                }
                                else
                                {
                                    dblInSum = m_dblGetInSum(objCurrent.m_dtmRECORDDATE.Date.AddHours(8), objCurrent.m_dtmRECORDDATE);
                                    dblOutSum = m_dblGetOutSum(objCurrent.m_dtmRECORDDATE.Date.AddHours(8), objCurrent.m_dtmRECORDDATE);
                                }
                            }
                            object[] objSum = null;
                            objSum = new object[22];
                            strText = ((int)dblSubHours).ToString() + " h总入量：";
                            strXml = "<root />";
                            strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                            objSum[6] = objclsDSTRichTextBoxValue;

                            strText = dblInSum.ToString();
                            strXml = "<root />";
                            strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                            objSum[7] = objclsDSTRichTextBoxValue;
                            objReturnData.Add(objSum);


                            objSum = new object[19];
                            strText = ((int)dblSubHours).ToString() + " h总出量：";
                            strXml = "<root />";
                            strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                            objSum[6] = objclsDSTRichTextBoxValue;

                            strText = dblOutSum.ToString();
                            strXml = "<root />";
                            strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                            objSum[7] = objclsDSTRichTextBoxValue;
                            if (objCurrent.m_strNURSESIGNID != "" && objCurrent.m_strNURSESIGNID != null)
                            {
                                clsEmployee objEmp = new clsEmployee(objCurrent.m_strNURSESIGNID);
                                objSum[18] = objEmp.m_StrLastName;
                            }
                            objReturnData.Add(objSum);
                        }
                    }
                    #endregion
                    if (objCurrent.m_intISSTAT == 1)
                    {
                        //如果该记录只记录了统计信息，则将上面已添加的该记录删除
                        bool isOnlySum = true;
                        String strTemp = "";
                        for (int n = 6; n <= 17; n++)
                        {
                            //							strTemp = ((clsDSTRichTextBoxValue)((object[])objReturnData[objReturnData.Count-1])[n]).m_strText;
                            //							if(strTemp != ""&& strTemp!=null)
                            //								isOnlySum = false;
                            if (((object[])objReturnData[objReturnData.Count - 1])[n] != null)
                                isOnlySum = false;
                        }
                        if (isOnlySum)
                        {
                            //当该记录只记录了统计信时不再显示该记录的时间及签名
                            ((object[])objReturnData[objReturnData.Count - 1])[5] = null;
                            ((object[])objReturnData[objReturnData.Count - 1])[18] = null;
                        }

                        if (intRowOfCurrentDetail != 0 && arlDetail != null && intCurrentDetail < arlDetail.Count && intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                        {
                            object[] objInstance = null;
                            for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                            {
                                objInstance = new object[22];
                                strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                                strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                                objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                objclsDSTRichTextBoxValue.m_strText = strText;
                                objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                objInstance[19] = strText;
                                objInstance[20] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                                objInstance[21] = objCurrent.m_strCreateUserID + "★" + (((object[])arlDetail[intCurrentDetail])[6]).ToString();
                                objReturnData.Add(objInstance);

                                if (m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                                {
                                    intRowOfCurrentDetail = 0;
                                    intCurrentDetail++;
                                    break;
                                }
                            }
                        }
                        object[] objSum = null;
                        objSum = new object[22];
                        strText = objCurrent.m_intSUMINTIME.ToString() + " h总入量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strSUMIN;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objReturnData.Add(objSum);


                        objSum = new object[19];
                        strText = objCurrent.m_intSUMOUTTIME.ToString() + " h总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strSUMOUT;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        if (objCurrent.m_strNURSESIGNID != "" && objCurrent.m_strNURSESIGNID != null)
                        {
                            clsEmployee objEmp = new clsEmployee(objCurrent.m_strNURSESIGNID);
                            objSum[18] = objEmp.m_StrLastName;
                        }
                        objReturnData.Add(objSum);
                    }
                    #endregion
                }
                //如果病情记录未显示完而其它护理记录已全部显示完，则继续输出剩余部分
                while (arlDetail != null && intCurrentDetail < arlDetail.Count && arlDetail.Count > 0)
                {
                    if (intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                    {
                        object[] objInstance = null;
                        for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                        {
                            objInstance = new object[22];
                            strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                            strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objInstance[19] = strText;
                            objInstance[20] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                            objInstance[21] = (((object[])arlDetail[intCurrentDetail])[6]).ToString();
                            objReturnData.Add(objInstance);

                            if (m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                            {
                                intRowOfCurrentDetail = 0;
                                intCurrentDetail++;
                                break;
                            }
                        }
                    }
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                    m_objRe[m] = (object[])objReturnData[m];
                return m_objRe;
            }
            catch (Exception ex)
            {
               
                return null;
            }
            #endregion
        }

	}

		 

}
#endregion