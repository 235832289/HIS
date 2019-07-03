using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using com.digitalwave.clsGeneralNurseRecord_GXService ;
namespace iCare
{
	/// <summary>ma
    /// 一 般患者护理记录打印工具类(新版)摘要说明。
	/// </summary>
	public class clsGeneralNurseRecord_GXPrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;               //表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;	                   //是否需要初始化	
		private clsRecordsDomain m_objRecordsDomain;           //记录域
		private clsPrintInfo_GeneralNurseGX m_objPrintInfo;     //打印内容
		private string strCurrentClass;                        //当前班次默认为空
		private int intCaseRowCount;                           //当前病程记录的最大行数
		private string[] strCurrentCaseTextArr;                //当前病程记录内容数组
		private string[] strCurrentCaseXmlArr;                 //当前病程记录痕迹数组
		private string[] strCurrentCaseCreateDateArr;          //当前病程记录创建时间
		private object [][] objDataArr;
	
		private string strDiagnose;
		private object[] objtest1;

		private string[] m_strCustomColumn;
	

		private bool m_bSummaryRow=false;
		

		public clsGeneralNurseRecord_GXPrintTool(string[] m_strColumnName)
		{
		   
			//
			// TODO: 在此处添加构造函数逻辑
			m_strCustomColumn=m_strColumnName;
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
			m_objPrintInfo=new  clsPrintInfo_GeneralNurseGX ();
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
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.GeneralNurseRecord_GXRec);
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
		private string strTempDate=string.Empty;

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
            if (m_objPrintInfo.m_objTransDataArr == null || m_objPrintInfo.m_objTransDataArr.Length == 0)
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
			m_fotHosNameFont= new Font("SimSun",14f);
			m_fotTinyFont=new Font("SimSun",9f);

			m_GridPen = new Pen(Color.Black,1);
			m_GridRedPen = new Pen(Color.Red ,2);

			m_slbBrush = new SolidBrush(Color.Black);
			m_objPageSetting = new clsPrintPageSettingForRecord();
            m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fotSmallFont);			
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
                        if (m_objPrintInfo.m_objTransDataArr[i] != null)
                        {
                            //更新记录，只需使用新的首次打印时间作为有效的输入参数。
                            //存放记录类型
                            arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
                            //存放记录的OpenDate
                            arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);
                            intUpdateIndex = i;
                        }
					}
				}   

				if(intUpdateIndex >= 0)
				{
					m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),(int[])arlRecordType.ToArray(typeof(int)),(DateTime[])arlOpenDate.ToArray(typeof(DateTime)),m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
				}
				#region 如果是预览，则不应该执行，否则预览后打印会出错，因为没有重新初始化
//				m_objPrintInfo.m_objTransDataArr = null;
//				m_objPrintInfo.m_blnIsFirstPrintArr = null;
				#endregion
			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
		}	
	
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_GeneralNurseGX")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_GeneralNurseGX)p_objPrintContent;
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
			intNowPage=1;
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
		private clsGeneralNurseRecordContent_GXDataInfo[] m_objPrintDataArr;

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
		/// 医院的名称
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
			TopY = 150,

			/// <summary>
			/// 表头第一条分割线
			/// </summary>
			RowsMark1=30,
			/// <summary>
			/// 表头第二条分割线
			/// </summary>
			RowsMark2=90,
	

			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 10,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 790,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 38,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 23,	
			/// <summary>
			/// 文字在格子中相对格子顶端的垂直偏移
			/// </summary>
			VOffSet = 20,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=10,
			/// <summary>
			/// 第一条间隔线(X),时间（起点线）
			/// </summary>			
			ColumnsMark1=80,

			/// <summary>
			/// 第二条间隔线(X)，T（起点线）
			/// </summary>
			ColumnsMark2=130,

			/// <summary>
			/// 第3条间隔线(X)，P（起点线）
			/// </summary>
			ColumnsMark3=180,

			/// <summary>
			/// R（起点线）
			/// </summary>
			ColumnsMark4=230,

			/// <summary>
			/// 心率（起点线）
			/// </summary>
			ColumnsMark5=280,

			/// <summary>
			/// BP（起点线）
			/// </summary>
			ColumnsMark6=330,

			/// <summary>
			///自定义1（起点线）
			/// </summary>
			ColumnsMark7=380,

			/// <summary>
			/// 自定义2（起点线）
			/// </summary>
			ColumnsMark8=420,

			/// <summary>
			/// 签名（起点线）
			/// </summary>
			ColumnsMark9=460,

			/// <summary>
			/// 病情记录
			/// </summary>
			ColumnsMark10=520,
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
						m_fReturnPoint = new PointF(190f,70f);
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
						m_fReturnPoint = new PointF(650f,120f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(710f,120f);
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
		
            

            //m_mthDrawMultiString(this.m_fotHosNameFont ,(int)enmRecordRectangleInfo.LeftX ,50,(int)enmRecordRectangleInfo.RightX ,100,1,1,clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,e);
				
            //m_mthDrawMultiString(this.m_fotTitleFont ,(int)enmRecordRectangleInfo.LeftX ,100,(int)enmRecordRectangleInfo.RightX ,150,1,1,"一  般  患  者  护  理  记  录",e);

            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("一  般  患  者  护  理  记  录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,365,120);
			e.Graphics.DrawString(m_objPrintInfo.m_strDeptName,m_fotSmallFont,m_slbBrush,415,120);

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,570,120);
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo  ,m_fotSmallFont,m_slbBrush,620,120);	
			
			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,20 ,120);
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName ,m_fotSmallFont,m_slbBrush,70,120);

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, 160, 120);
            e.Graphics.DrawString(objEveryRecordPageInfo.strSex, m_fotSmallFont, m_slbBrush, 210, 120);

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 240, 120);
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 280, 120);
		
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,650,120);
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID  ,m_fotSmallFont,m_slbBrush,710,120);	
			
		
            //e.Graphics.DrawString("日期：",m_fotSmallFont,m_slbBrush,(float)enmRecordRectangleInfo.RightX -180 ,150);
            //e.Graphics.DrawString(DateTime.Now.ToString("yyyy年MM月dd日"),m_fotSmallFont,m_slbBrush,(float)enmRecordRectangleInfo.RightX -140,150);	
		}
		#endregion
		private void m_mthDrawMultiString(Font fotNormal,Font fotSmall,int iLimitLenth,float x,float y,float x1,float y1,float xOff,float yOff,string strContent,System.Drawing.Printing.PrintPageEventArgs e)
		{
		
			RectangleF drawRect=new RectangleF(x,y+1,x1-x,y1-y);
			RectangleF drawRectNormal=new RectangleF(x,y+yOff,x1-x,y1-y);

			StringFormat strFormat=new StringFormat();
			strFormat.Alignment =System.Drawing.StringAlignment.Center ;
			strFormat.FormatFlags=System.Drawing.StringFormatFlags.LineLimit;   
  
			if(strContent.Length >iLimitLenth)
			{
                if (strContent.Length > iLimitLenth + 1)
                {
                    e.Graphics.DrawString(strContent, fotSmall, m_slbBrush, drawRect, strFormat);
                }
                else//因为字体变小，只多出一字时未超出一行，此时无需上移
                {
                    e.Graphics.DrawString(strContent, fotSmall, m_slbBrush, drawRectNormal, strFormat);
                }
			}
			else
			{
				e.Graphics.DrawString(strContent,fotNormal,m_slbBrush,drawRectNormal,strFormat);
				
			}
        
		}
		private void m_mthDrawMultiString(Font fotNormal,float x,float y,float x1,float y1,float xOff,float yOff,string strContent,System.Drawing.Printing.PrintPageEventArgs e)
		{
		
			RectangleF drawRect=new RectangleF(x,y+yOff,x1-x,y1-y);
			StringFormat strFormat=new StringFormat();
			strFormat.Alignment =System.Drawing.StringAlignment.Center ;
			strFormat.FormatFlags=System.Drawing.StringFormatFlags.LineLimit;   
  
			e.Graphics.DrawString(strContent, fotNormal,m_slbBrush,drawRect,strFormat);
			
        
		}

		#region 画标题的栏目
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
            e.Graphics.DrawString("日期",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+20,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-2);
			e.Graphics.DrawString("时间",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+5, (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-2);
			
			//T.
			e.Graphics.DrawString("T: C、P:次/分、R: 次/分、BP:mmHg",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2 +20,(int)enmRecordRectangleInfo.TopY+10);
			e.Graphics.DrawString("T",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2 +20,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep  +10);
			e.Graphics.DrawString("P",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3 +20,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep +10);
			e.Graphics.DrawString("R",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4 +20,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep +10);
			e.Graphics.DrawString("心率",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5 +5,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep +10);
			e.Graphics.DrawString("BP",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6 +10,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep +10);
			//T.自定义
			m_mthDrawMultiString(m_fotHeaderFont,m_fotHeaderFont,3,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep*2),10,10,"",e);
			
            //e.Graphics.DrawString(m_strCustomColumn[1].ToString() ,m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8 +10,
            //    (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep+5);

            StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
            m_sfmPrint.Alignment = StringAlignment.Near;
            string strCustomColumn0 = m_strCustomColumn[0].ToString().Replace("\r\n", "");
            if (strCustomColumn0.Length > 4)
            {
                e.Graphics.DrawString(strCustomColumn0, m_fotTinyFont, m_slbBrush,
                    new RectangleF((int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep, 60, 40), m_sfmPrint);
            }
            else
            {
                e.Graphics.DrawString(strCustomColumn0, m_fotHeaderFont, m_slbBrush,
                    new RectangleF((int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep, 40, 40), m_sfmPrint);
            }

            string strCustomColumn1 = m_strCustomColumn[1].ToString().Replace("\r\n", "");
            if (strCustomColumn1.Length > 4)
            {
                e.Graphics.DrawString(strCustomColumn1, m_fotTinyFont, m_slbBrush,
                new RectangleF((int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep, 60, 40), m_sfmPrint);
            }
            else
            {
                e.Graphics.DrawString(strCustomColumn1, m_fotHeaderFont, m_slbBrush,
                    new RectangleF((int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep, 40, 40), m_sfmPrint);
            }
			//签名
			e.Graphics.DrawString("签名",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9 +10,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-2);
			//病情记录
			e.Graphics.DrawString("病情记录",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10 +70,
				(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep-2);
		
		}
		#endregion

		#region 画格子
		/// <summary>
		///  画格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			
				
			#region//画格子横线
			//画格子横线
			for(int i1=0;i1<=(int)enmRecordRectangleInfo.RowLinesNum  ;i1++)
			{
				if(i1==0)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY);
				else if(i1==1)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark2,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark9,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep) ;
				else //if(i1==2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep * i1),
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep * i1));
			}
			
			#endregion 画格子横线
			#region 画格子竖线
			int intHeight=(int)enmRecordRectangleInfo.RowStep *23;
			//画左边沿线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画时间左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画T左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画p左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画R左边线 
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画心率左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画BP左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画自定义1左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画自定义2左边线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画签名 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);
			//画病情记录左边线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			//画右边沿线 顶起
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY,
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
			string strRecord="";			
			string strRecordXML="";			
			DateTime dtmFlagTime;
			/*记录该页当前的打印的行*/
			intNowRow=1; 			
			
			int iTemp=(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum))+20;
            m_mthDrawMultiString(this.m_fotSmallFont ,(int)enmRecordRectangleInfo.LeftX ,iTemp,(int)enmRecordRectangleInfo.RightX ,iTemp+50,1,1,"（第"+intNowPage.ToString()+"页）",e);
			//	if(m_objPrintInfo.m_strInPatentID ==""|| m_objPrintDataArr==null)return;
			if(m_objPrintInfo.m_strInPatentID =="")return;

			m_intCurrentRecord=0;

			//打印主循环


			for(int i1=m_intMainCurrentContentRow;i1<m_objPrintInfo.m_objTransDataArr.Length ;i1++)
			{ 
	
			   
              
				clsGeneralNurseRecordContent_GXDataInfo clsGereralData=new clsGeneralNurseRecordContent_GXDataInfo ();
				clsGereralData =(clsGeneralNurseRecordContent_GXDataInfo) m_objPrintInfo.m_objTransDataArr [i1];

				objDataArr = m_objGetRecordsValueArr(clsGereralData);
			   
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
                    
					strTemp= objclsDSTRichTextBoxValue.m_strText!=null? objclsDSTRichTextBoxValue.m_strText:"";				
					
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
			if(m_intCurrentPagePrintRow>((int)enmRecordRectangleInfo.RowLinesNum-3)/*除去表头2行外总有效行数*/) 
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
			//string [] strValueArr = p_strValueArr[p_intIndex];
			
			string strTemp;
			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
								
			if(m_blnCheckPageChange(e)==true) //每打印一行之前都要检查是否换页
			{
				return enmReturnValue.enmNeedNextPage;
				//换页
					
			}

			     
			    
			 
			//日期
			int m_intPosX=(int)enmRecordRectangleInfo.LeftX;//当前的X坐标
			int m_intPosX1=0;
			int m_intPosY=(int)enmRecordRectangleInfo.TopY+((m_intCurrentPagePrintRow+2)*(int)enmRecordRectangleInfo.RowStep);
			int m_intPosY1=(int)enmRecordRectangleInfo.TopY+((m_intCurrentPagePrintRow+3)*(int)enmRecordRectangleInfo.RowStep);;
			int m_intXOff=1;
			int m_intYOff=15;

			int intTempColumn=4;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			
			if(strTemp.Trim().Length != 0)
			{
				e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX, m_intPosY+15);
				strTempDate=strTemp;
			}
			//换行时第一行的日期不能省去,前数值不为空，现数值为空，且处于第一行
			if(strTempDate.Trim().Length != 0&&m_intCurrentPagePrintRow==0&&strTemp.Trim().Length == 0)
			{
				e.Graphics.DrawString(strTempDate,m_fotSmallFont,Brushes.Black,m_intPosX+1, m_intPosY+15);
				strTempDate=strTemp;
			}
			//时间
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
			  
			intTempColumn=5;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				e.Graphics.DrawString(strTemp,m_fotSmallFont,Brushes.Black,m_intPosX,m_intPosY+15);
			}
			//T
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标

			intTempColumn=6;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			
			if(strTemp.Trim().Length != 0)
			{
				//m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
				m_mthDrawMultiString(this.m_fotSmallFont,this.m_fotSmallFont ,6, m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e) ;
			}
			
			//P
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			intTempColumn=7;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
				m_mthDrawMultiString(this.m_fotSmallFont,this.m_fotSmallFont ,6, m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e) ;
			}
			
			m_bSummaryRow=false;

			//R
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			intTempColumn=8;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
				m_mthDrawMultiString(this.m_fotSmallFont,this.m_fotSmallFont ,6, m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e) ;
				
			}

			//心率
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			intTempColumn=9;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
				//m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
				m_mthDrawMultiString(this.m_fotSmallFont,this.m_fotSmallFont ,6, m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e) ;
				
			}
			//BP 1
			
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
			m_intXOff=10;
			intTempColumn=10;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			strTemp=strTemp+"/";
			//BP 2
			
			intTempColumn=11;
			strTemp=strTemp+m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if(strTemp.Trim ()!="/")
            {
				//m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
                m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
			}

            //自定义1
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
            intTempColumn = 12;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                //m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
                m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }

            m_bSummaryRow = false;

            //自定义2
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
            intTempColumn = 13;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                //m_mthDrawMultiString(m_fotSmallFont,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,m_intXOff,m_intYOff,strTemp,e);
                m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }

            m_bSummaryRow = false;

			//签名
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			intTempColumn=14;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
			   m_mthDrawMultiString(m_fotSmallFont,m_fotSmallFont,3,m_intPosX,m_intPosY,m_intPosX1,m_intPosY1,0,m_intYOff,strTemp,e);
			}
			//病情记录
			m_intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			m_intPosX1=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.RightX ;//当前的X坐标
			intTempColumn=15;
			strTemp=m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
			if(strTemp.Trim().Length != 0)
			{
			  e.Graphics.DrawString(strTemp,m_fotSmallFont,m_slbBrush,m_intPosX,m_intPosY+m_intYOff);
			}
			
	
			m_intCurrentContentRow++;
			m_intCurrentPagePrintRow++;
			
			
			#endregion

			return enmReturnValue.enmSuccessed;
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
		
		private void m_mthSetOtherDetail(object[] objDetail, int intCurrentDetail,int intRowOfCurrentDetail,clsGeneralNurseRecordContent_GX objCurrent, out object[] objOtherDetail)
		{
			objOtherDetail = new object[18];
			string strText = ((string[])(objDetail[0]))[intRowOfCurrentDetail];
			//string strXml = ((string[])(objDetail[1]))[intRowOfCurrentDetail];;
			//clsDSTRichTextBoxValue objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			//objclsDSTRichTextBoxValue.m_strText=strText;						
			//objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
            objOtherDetail[15] = strText;
			objOtherDetail[16] = (DateTime)objDetail[3];
			if(objCurrent != null)
				objOtherDetail[17] = objCurrent.m_strCreateUserID+"★"+objDetail[6].ToString();
			else
				objOtherDetail[17] = " ★"+objDetail[6].ToString();
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
                ArrayList arlDetail = new ArrayList();//存放病情记录
                int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引
                int intRecordCount = 0;
                bool blnIsSameClass = false;//判断是否为同一班次

                clsGeneralNurseRecordContent_GXDataInfo objGNRCInfo = new clsGeneralNurseRecordContent_GXDataInfo();
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                objGNRCInfo = (clsGeneralNurseRecordContent_GXDataInfo)p_objTransDataInfo;

                if (objGNRCInfo.m_objRecordArr == null && objGNRCInfo.m_objDetailArr == null)
                    return null;

                #region 对病情记录进行处理
                if (objGNRCInfo.m_objDetailArr != null)
                {
                    string strDetail = "";
                    string strDetailXML = "";
                    for (int n = 0; n < objGNRCInfo.m_objDetailArr.Length; n++)
                    {
                        clsGeneralNurseRecordContent_GXDetail objDetail = objGNRCInfo.m_objDetailArr[n];
                        object[] objTemp = new object[7];
                        strDetail = objDetail.m_strRECORDCONTENT_RIGHT;
                        strDetailXML = objDetail.m_strRECORDCONTENTXML;
                        string[] strDetailArrTemp;
                        string[] strDetailXMLArrTemp;
                        //将病情记录分为行。
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strDetail, strDetailXML, 31, out strDetailArrTemp, out strDetailXMLArrTemp);
                        string[] strDetailArr, strDetailXMLArr;
                        if (strDetail != string.Empty)
                        {
                            strDetailArr = new string[strDetailArrTemp.Length + 2];//存放添加日期和签名后病情记录
                            strDetailXMLArr = new string[strDetailXMLArrTemp.Length + 2];//存放添加日期和签名后病情记录XML

                            //将日期和签名添加进病情记录
                            strDetailArr[0] = objDetail.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm");
                            strDetailArr[1] = strDetailArrTemp[0];
                            for (int i = 2; i < strDetailArr.Length - 1; i++)
                            {
                                strDetailArr[i] = strDetailArrTemp[i - 1];
                            }
                            strDetailArr[strDetailArr.Length - 1] = "                   " + objDetail.m_strDetailCreateUserName;

                            strDetailXMLArr[0] = strDetailXMLArr[strDetailXMLArr.Length - 1] = "";
                            for (int i = 1; i < strDetailXMLArr.Length - 1; i++)
                            {
                                strDetailXMLArr[i] = strDetailXMLArrTemp[i - 1];
                            }

                            objTemp[0] = strDetailArr;
                            objTemp[1] = strDetailXMLArr;
                            objTemp[2] = strDetailArr.Length;
                            objTemp[3] = objDetail.m_dtmRECORDDATE;
                            objTemp[4] = objDetail.m_intClass;
                            objTemp[5] = objDetail.m_strDetailCreateUserName;
                            objTemp[6] = objDetail.m_strCREATERECORDUSERID;
                            arlDetail.Add(objTemp);
                        }
                    }
                }
                #endregion

                if (objGNRCInfo.m_objRecordArr != null)
                    intRecordCount = objGNRCInfo.m_objRecordArr.Length;
                int intRowOfCurrentDetail = 0;

                #region 获取修改限定时间
                int intCanModifyTime = 0;
                
                #endregion

                for (int i = 0; i < intRecordCount; i++)
                {
                    objData = new object[18];
                    clsGeneralNurseRecordContent_GX objCurrent = objGNRCInfo.m_objRecordArr[i];
                    clsGeneralNurseRecordContent_GX objNext = new clsGeneralNurseRecordContent_GX();//下一条护理记录
                    if (i < intRecordCount - 1)
                        objNext = objGNRCInfo.m_objRecordArr[i + 1];

                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                   // if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim())
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    {
                     //   TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                     //   if ((int)tsModify.TotalHours < intCanModifyTime)
                            continue;
                    }

                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRECORDDATE;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.GeneralNurseRecord_GXRec;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRECORDDATE.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRECORDDATE)
                            objData[5] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                    #endregion ;

                    #region 存放单项信息
                    //体温
                    objData[6] = objCurrent.m_strTEMPERATURE_RIGHT;//T
                    //脉搏
                    objData[7] = objCurrent.m_strPULSE_RIGHT;//HR

                    //呼吸
                    objData[8] = objCurrent.m_strRESPIRATION_RIGHT;//P

                    //心率
                    objData[9] = objCurrent.m_strHEARTRATE_RIGHT;//HR


                    //血压A
                    objData[10] = objCurrent.m_strBLOODPRESSURES_RIGHT;//保存进数据库时已将A与S对调

                    //血压S
                    objData[11] = objCurrent.m_strBLOODPRESSUREA_RIGHT;//

                    //自定义列1
                    objData[12] = objCurrent.m_strCUSTOM1_RIGHT;//

                    //自定义列2
                    objData[13] = objCurrent.m_strCUSTOM2_RIGHT;//

                    //签名
                    objData[14] = objCurrent.m_strContentCreateUserName;

                    //病情记录
                    if (arlDetail != null && intCurrentDetail < arlDetail.Count && arlDetail.Count > 0)
                    {
                        int intClass = (int)(((object[])(arlDetail[intCurrentDetail]))[4]);
                        DateTime dtDetailRecordTime = (DateTime)(((object[])(arlDetail[intCurrentDetail]))[3]);
                        //如为旧记录未有保存班次信息，重新进行判断
                        if (objCurrent.m_intClass == 0 || objCurrent.m_intClass == 1 || intClass == 0)
                            blnIsSameClass = m_blnIsSameClass(objCurrent.m_dtmRECORDDATE, dtDetailRecordTime);
                        else
                            blnIsSameClass = objCurrent.m_intClass == intClass ? true : false;
                        //如果是一班次，直接填充
                        if (blnIsSameClass)
                        {
                            strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[intRowOfCurrentDetail];
                            //strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[intRowOfCurrentDetail]; ;
                           // objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            //objclsDSTRichTextBoxValue.m_strText = strText;
                           // objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objData[15] = strText;
                            objData[16] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                            objData[17] = objCurrent.m_strCreateUserID + "★" + (((object[])arlDetail[intCurrentDetail])[3]).ToString();

                            if (intRowOfCurrentDetail == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                            {
                                intRowOfCurrentDetail = 0;
                                intCurrentDetail++;
                            }
                            else
                                intRowOfCurrentDetail++;
                            objReturnData.Add(objData);
                        }
                        else if (objNext != null)
                        {
                            while (arlDetail != null &&
                                intCurrentDetail < arlDetail.Count &&
                                intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length &&
                                (DateTime)(((object[])arlDetail[intCurrentDetail])[3]) <= objCurrent.m_dtmRECORDDATE)
                            {
                                //如为旧记录未有保存班次信息，重新进行判断
                                if (objNext.m_intClass == 0 || objNext.m_intClass == 1 || (int)(((object[])arlDetail[intCurrentDetail])[4]) == 0)
                                    blnIsSameClass = m_blnIsSameClass(objCurrent.m_dtmRECORDDATE, (DateTime)(((object[])arlDetail[intCurrentDetail])[3]));
                                else
                                    blnIsSameClass = objNext.m_intClass == (int)(((object[])arlDetail[intCurrentDetail])[4]) ? true : false;

                                if (!blnIsSameClass)
                                {
                                    for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                                    {
                                        object[] objOtherDetail = new object[18];
                                        m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, m, objCurrent, out objOtherDetail);
                                        objReturnData.Add(objOtherDetail);
                                    }

                                    intCurrentDetail++;
                                    intRowOfCurrentDetail = 0;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    if (objData != null && objData[15] == null)
                        objReturnData.Add(objData);
                    #endregion
                }

                //如果病情记录未显示完而其它护理记录已全部显示完，则继续输出剩余部分
                while (arlDetail != null && intCurrentDetail < arlDetail.Count && arlDetail.Count > 0)
                {
                    if (intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                    {
                        for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                        {
                            object[] objOtherDetail = new object[18];
                            m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, m, null, out objOtherDetail);
                            objReturnData.Add(objOtherDetail);
                        }

                        intCurrentDetail++;
                        intRowOfCurrentDetail = 0;
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