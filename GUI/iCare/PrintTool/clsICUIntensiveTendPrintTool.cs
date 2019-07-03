using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// ICU危重的打印工具类,Jacky-2003-7-7
	/// </summary>
	public class clsICUIntensiveTendPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsRecordsDomain m_objRecordsDomain;
		private clsPrintInfo_ICUIntensiveTend m_objPrintInfo;
		
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
			m_objPrintInfo=new clsPrintInfo_ICUIntensiveTend();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;	
			m_objPrintInfo.m_strWeight	= m_objPatient!=null? "50": "";//待定
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
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.ICUIntensiveTend);

			long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_objTransDataArr,out m_objPrintInfo.m_dtmFirstPrintDateArr,out m_objPrintInfo.m_blnIsFirstPrintArr);
			if(lngRes <= 0)
				return ;   

			//按记录时间(CreateDate)排序 
			m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
			//设置表单内容到打印中
			m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr,m_objPrintInfo.m_dtmFirstPrintDateArr);			
			m_objPrintInfo.m_objPrintDataArr=m_objPrintDataArr;

			m_mthSetMultiLinePrintValues();
			m_blnWantInit=false;
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_ICUIntensiveTend")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_ICUIntensiveTend)p_objPrintContent;
			m_objPrintDataArr= m_objPrintInfo. m_objPrintDataArr ;		
			m_mthSetMultiLinePrintValues();
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
			m_fotHeaderFont = new Font("SimSun", 12f);
			m_fotSmallFont = new Font("SimSun",10.5f);
			m_fotTinyFont=new Font("SimSun",8f);		
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
	
			m_objPageSetting = new clsPrintPageSettingForRecord();
			
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_objPageSetting = null;
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
			m_mthPrintPageSub(e);
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
				m_objPrintInfo.m_objTransDataArr = null;		
				m_objPrintInfo.m_blnIsFirstPrintArr = null;
			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
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
		/// 药品、剂量、口服类型、口服药名、口服性质、口服量、皮肤情况、病情记录 8列的打印内容对象数组
		/// </summary>
		private clsPrintContentForICU[] m_objPrintContextArr;
		/// <summary>
		/// 当前行的Y坐标
		/// </summary>
		private int m_intPosY = (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4;
		/// <summary>
		/// 每行数据行的高度
		/// </summary>
		int intTempDeltaY = 38;	
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
		private int m_intNowPage=1;
		/// <summary>
		/// 当前打印的记录的序号
		/// </summary>
		private int m_intCurrentRecord=0;  
		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool m_blnBeginPrintNewRecord=true;		

		/// <summary>
		/// （若要保留历史痕迹）当前记录内容
		/// </summary>
		private string[][] m_strValueArr;

		/// <summary>
		/// 当前记录的行序数（修改的次第数）
		/// </summary>
		private int m_intNowRowInOneRecord=0; 	

		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;
		
		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRecordRectangleInfo
		{//A3纸张，横向 ：1620*1024 Size
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 200,

			/// <summary>
			/// 表头第一条分割线
			/// </summary>
			RowsMark1=60,
			/// <summary>
			/// 表头第二条分割线
			/// </summary>
			RowsMark2=90,
			/// <summary>
			/// 表头第三条分割线
			/// </summary>
			RowsMark3=120,
			/// <summary>
			/// 表头第四条分割线（表中用户数据的起点线）
			/// </summary>
			RowsMark4=210,

			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 30,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 1620-34,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 38,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 17,	
			/// <summary>
			/// 文字在格子中相对格子顶端的垂直偏移
			/// </summary>
			VOffSet = 20,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=19,
			/// <summary>
			/// 第一条间隔线(X),时间（起点线）
			/// </summary>			
			ColumnsMark1=75,

			/// <summary>
			/// 第二条间隔线(X)，T（起点线）
			/// </summary>
			ColumnsMark2=120,

			/// <summary>
			/// 第3条间隔线(X)，HR（起点线）
			/// </summary>
			ColumnsMark3=150,

			/// <summary>
			/// P（起点线）
			/// </summary>
			ColumnsMark4=180,

			/// <summary>
			/// R（起点线）
			/// </summary>
			ColumnsMark5=210,

			/// <summary>
			/// Bp（起点线）
			/// </summary>
			ColumnsMark6=240,

			/// <summary>
			/// CVP（起点线）
			/// </summary>
			ColumnsMark7=270,

			/// <summary>
			/// 血糖（起点线）
			/// </summary>
			ColumnsMark8=300,

			/// <summary>
			/// 神志（起点线）
			/// </summary>
			ColumnsMark9=330,

			/// <summary>
			/// 瞳孔大小　左（起点线）
			/// </summary>
			ColumnsMark10=370,

			/// <summary>
			/// 瞳孔大小　右（起点线）
			/// </summary>
			ColumnsMark11=400,

			/// <summary>
			/// 对光反射　左（起点线）
			/// </summary>
			ColumnsMark12=430,

			/// <summary>
			/// 对光反射　右（起点线）
			/// </summary>
			ColumnsMark13=460,

			/// <summary>
			/// 肌力（起点线）
			/// </summary>
			ColumnsMark14=490,

			/// <summary>
			/// 入量：输入液量：药名（起点线）
			/// </summary>
			ColumnsMark15=530,

			/// <summary>
			/// 入量：输入液量：剂量（起点线）
			/// </summary>
			ColumnsMark16=570,

			/// <summary>
			/// 入量：输入液量：总量（起点线）
			/// </summary>
			ColumnsMark17=600,

			/// <summary>
			/// 入量：胃管 ：通畅（起点线）
			/// </summary>
			ColumnsMark18=630,

			/// <summary>
			/// 入量：胃管 ：胃液性质（起点线）
			/// </summary>
			ColumnsMark19=690,

			/// <summary>
			/// 入量：胃管 ：量（起点线）
			/// </summary>
			ColumnsMark20=740,	
			/// <summary>
			/// 入量：口服：类型（起点线）
			/// </summary>
			ColumnsMark21=770,
			/// <summary>
			/// 入量：口服：药名（起点线）
			/// </summary>
			ColumnsMark22=800,
			/// <summary>
			/// 入量：口服：性质（起点线）
			/// </summary>
			ColumnsMark23=850,
			/// <summary>
			/// 入量：口服：量（起点线）
			/// </summary>
			ColumnsMark24=890,
			/// <summary>
			/// 入量：进食量：总量（起点线）
			/// </summary>
			ColumnsMark25=920,
			/// <summary>
			/// 出量：尿管：通畅（起点线）
			/// </summary>
			ColumnsMark26=950,
			/// <summary>
			/// 出量：尿管：尿液性质（起点线）
			/// </summary>
			ColumnsMark27=990,
			/// <summary>
			/// 出量：尿管：量（起点线）
			/// </summary>
			ColumnsMark28=1030,
			/// <summary>
			/// 出量：大便：性质（起点线）
			/// </summary>
			ColumnsMark29=1060,
			/// <summary>
			/// 出量：大便：次数（起点线）
			/// </summary>
			ColumnsMark30=1100,
			/// <summary>
			/// 出量：大便：量（起点线）
			/// </summary>
			ColumnsMark31=1130,
			/// <summary>
			/// 出量：引流管：通畅（起点线）
			/// </summary>
			ColumnsMark32=1160,
			/// <summary>
			/// 出量：引流管：性质（起点线）
			/// </summary>
			ColumnsMark33=1220,
			/// <summary>
			/// 出量：引流管：量（起点线）
			/// </summary>
			ColumnsMark34=1260,
			/// <summary>
			/// 痰：性质（起点线）
			/// </summary>
			ColumnsMark35=1290,
			/// <summary>
			/// 痰：量（起点线）
			/// </summary>
			ColumnsMark36=1330,
			/// <summary>
			/// 皮肤情况（起点线）
			/// </summary>
			ColumnsMark37=1360,
			/// <summary>
			/// 病情记录（起点线）
			/// </summary>
			ColumnsMark38=1410,
			/// <summary>
			/// 签名（起点线）
			/// </summary>
			ColumnsMark39=1510,
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
			Weight_Title,
			Weight,

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
						m_fReturnPoint = new PointF(720f,60f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(543f,100f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(213f,150f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(263f,150f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(550f,150f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(600f,150f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(380f,150f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(430f,150f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(480f,150f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(530f,150f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(700f,150f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(750f,150f);
						break;

					case (int)enmItemDefination.Weight_Title:
						m_fReturnPoint = new PointF(850f,150f);
						break;
					case (int)enmItemDefination.Weight:
						m_fReturnPoint = new PointF(900f,150f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(1050f,150f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(1120f,150f);
						break;
					case (int)enmItemDefination.Print_Date_Title:
						m_fReturnPoint = new PointF(1230f,150f);
						break;
					case (int)enmItemDefination.Print_Date :
						m_fReturnPoint = new PointF(1310f,150f);
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

		#region 打印
		private clsICUIntensiveTendDataInfo[] m_objPrintDataArr;
		/// <summary>
		/// 设置打印内容。
		/// </summary>
		/// <param name="p_objTransDataArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDate)
		{
			if(p_objTransDataArr==null || p_dtmFirstPrintDate==null ||p_objTransDataArr.Length !=p_dtmFirstPrintDate.Length)
			{
				clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
				return;
			}
			ArrayList m_arlTemp = new ArrayList();
			for(int i1=0;i1<p_objTransDataArr.Length;i1++)
			{
				//if(p_objTransDataArr[i1].m_intFlag==(int)enmRecordsType.ICUIntensiveTend)
					m_arlTemp.Add(p_objTransDataArr[i1]);
				
			}
			m_objPrintDataArr = (clsICUIntensiveTendDataInfo[])m_arlTemp.ToArray(typeof(clsICUIntensiveTendDataInfo));

			
		}

		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			
		}

		// 打印页，每打印一页，调用一次，是打印中最根本的函数。
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			try
			{
				p_objPrintPageArg.HasMorePages =false;
				m_mthPrintTitleInfo(p_objPrintPageArg);
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);

				if(m_objPrintInfo.m_strInPatentID =="" || m_objPrintDataArr==null || m_objPrintDataArr.Length==0)
					return;
				while(m_intCurrentRecord < m_objPrintDataArr.Length)
				{				
					if(m_intCurrentRecord==0)
						m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
					
					if(m_blnCheckPageChange(m_intPosY + intTempDeltaY,p_objPrintPageArg)==true)
						return;
					m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intPosY);	
				
					if(m_blnBeginPrintNewRecord)
					{
						m_intCurrentRecord++;
					
						m_mthPrintOneHorizontalLine(p_objPrintPageArg,m_intPosY);

						int intMaxRows=m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
						if(m_blnCheckPageChange(m_intPosY + intMaxRows*intTempDeltaY,p_objPrintPageArg)==true)
							return;
					}					
				
				}
				m_mthPrintVLines(p_objPrintPageArg,m_intPosY);
//				页脚//////////////////////////////////////////////////////////////
				p_objPrintPageArg.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39-10 ,
					1038/*m_intPosY+(int)enmRecordRectangleInfo.VOffSet*/ );
			
				#region 打印完毕，ReSet(复位)操作
				if(m_intCurrentRecord==m_objPrintDataArr.Length)
				{	
					m_intPosY = (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4;
					m_intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
					m_blnBeginPrintNewRecord=true;//复位
					m_intNowPage=1;//复位
				}
				#endregion				
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

			}
		}

		/// <summary>
		/// 检查是否换页,true:换页，false:不换页
		/// </summary>
		/// <param name="p_intYBottom">要检测的底线Y坐标</param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool m_blnCheckPageChange(int p_intYBottom,System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(p_intYBottom >= 1050)
			{
				e.HasMorePages = true;				

				//Print VLine
				m_mthPrintVLines(e,m_intPosY);
				m_mthPrintOneHorizontalLine(e,m_intPosY);

				//页脚//////////////////////////////////////////////////////////////
				e.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39-10,
					1038/*m_intPosY+(int)enmRecordRectangleInfo.VOffSet */);
           

				m_intPosY = (int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4;
				m_intNowPage++;
				return true;
					
			}
			else return false;			
		}

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{		
			if(m_objPrintContextArr != null)
			{
				for(int i=0;i<m_objPrintContextArr.Length;i++)
				{
					if(m_objPrintContextArr[i] != null)
					{
						m_objPrintContextArr[i].m_mthReset();
					}
				}
			}
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{	
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("ICU 危 重 监 护 中 心 特 护 记 录 单",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(m_objPrintInfo.m_strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

//			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
//			e.Graphics.DrawString(m_objPrintInfo.m_strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));
//
//			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,new PointF(430f,150f));
//			e.Graphics.DrawString(m_objPrintInfo.m_strAreaName ,m_fotSmallFont,m_slbBrush,new PointF(480f,150f));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strBedName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("体重：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Weight_Title ));
			e.Graphics.DrawString((m_objPrintInfo.m_strWeight==null||m_objPrintInfo.m_strWeight=="") ? "     kg" : m_objPrintInfo.m_strWeight +"   kg" ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Weight ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
			
			e.Graphics.DrawString("打印日期：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Print_Date_Title ));
			e.Graphics.DrawString(( m_objPrintInfo.m_strInPatentID!="")? DateTime.Now.ToString("yyyy年MM月dd日") :"    年  月  日" ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Print_Date ));

            //管床护士签名
            //e.Graphics.DrawString("管床护士：____________", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.RightX - 170,
             //   (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * ((int)enmRecordRectangleInfo.RowLinesNum + 1) +185);

            //e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.RightX - 100,
            //           ((int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * ((int)enmRecordRectangleInfo.RowLinesNum + 1)+220),
            //           (int)enmRecordRectangleInfo.RightX,
            //           (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * ((int)enmRecordRectangleInfo.RowLinesNum + 1)+220);
            ////---------------
	
		}
		#endregion

		#region 画表头格子
		/// <summary>
		///  画表头格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			
			
			#region 画格子横线
			for(int i1=0;i1<5 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
			{
				if(i1 ==0)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY);
				else if(i1==1)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark2,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark9,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1);	
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark10,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark14,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark15,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark35,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1);
				}
				else if(i1==2)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark18,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark26,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2);					
				}	
				else if(i1==3)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark15,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark25,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark26,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark37,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3);
				}
				else
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4);
				
			}
			#endregion 画格子横线
			
			#region 画格子竖线
			int intXPos=(int)enmRecordRectangleInfo.LeftX;
			int intYTop=(int)enmRecordRectangleInfo.TopY;
			int intYBottom=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4;
			
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;			
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;		
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;		
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;		
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;		
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;		
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark23;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark24;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark26;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark28;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark31;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark33;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark34;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark36;
			intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark37;
			intYTop=(int)enmRecordRectangleInfo.TopY;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark38;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			//画右边沿线
			intXPos=(int)enmRecordRectangleInfo.RightX;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);	
			
			#endregion				
			
		}

						
		#endregion		

		#region 画标题的栏目		
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{		
			///标题栏目的各行字的Y坐标（共分为8行）
			int[] intYPosFontArr=new int[8]{ (int)enmRecordRectangleInfo.TopY + 10,//入量 :0
											   (int)enmRecordRectangleInfo.TopY + 35,//(ml):1
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1+10,//输入液量 :2
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2+10,//胃管 ：3
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+10,//胃:4
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+25,//液 ：5
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+45,//性 ：6
											   (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+65,//质：7  
											};
			e.Graphics.DrawString("日",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+25,(int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1);
			e.Graphics.DrawString("期",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+25,(int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+20);
		     
			e.Graphics.DrawString("时",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+15,(int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1);
			e.Graphics.DrawString("间",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+15,(int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3+20);

			e.Graphics.DrawString("生命体征",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,intYPosFontArr[0]);
			e.Graphics.DrawString("T",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+5,intYPosFontArr[3]);
			e.Graphics.DrawString("℃",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+5,intYPosFontArr[4]);

			e.Graphics.DrawString("HR",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3+5,intYPosFontArr[3]);
			e.Graphics.DrawString("bpm",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3+2,intYPosFontArr[4]);
			
			e.Graphics.DrawString("P",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+5,intYPosFontArr[3]);
			e.Graphics.DrawString("bpm",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4+2,intYPosFontArr[4]);
			
			e.Graphics.DrawString("R",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+5,intYPosFontArr[3]);
			e.Graphics.DrawString("bpm",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+2,intYPosFontArr[4]);
			
			e.Graphics.DrawString("Bp",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+5,intYPosFontArr[3]);
			e.Graphics.DrawString("mmHg",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6+2,intYPosFontArr[4]);
			
			e.Graphics.DrawString("CVP",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+1,intYPosFontArr[3]);
			e.Graphics.DrawString("cmH2O",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+1,intYPosFontArr[4]);
			
			e.Graphics.DrawString("血",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+5,intYPosFontArr[3]);
			e.Graphics.DrawString("糖",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8+5,intYPosFontArr[4]);
			e.Graphics.DrawString("mmol/L",m_fotTinyFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,intYPosFontArr[5]+10);			
			
			e.Graphics.DrawString("神",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9+10,intYPosFontArr[1]);
			e.Graphics.DrawString("志",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9+10,intYPosFontArr[3]);			
			
			e.Graphics.DrawString("瞳孔",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+15,intYPosFontArr[0]);
			e.Graphics.DrawString("大小",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+15,intYPosFontArr[1]);
			e.Graphics.DrawString("左",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+10,intYPosFontArr[2]);
			e.Graphics.DrawString("右",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11+10,intYPosFontArr[2]);

			e.Graphics.DrawString("对光",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12+10,intYPosFontArr[0]);
			e.Graphics.DrawString("反射",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12+10,intYPosFontArr[1]);
			e.Graphics.DrawString("左",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12+5,intYPosFontArr[2]);
			e.Graphics.DrawString("右",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13+5,intYPosFontArr[2]);

			e.Graphics.DrawString("肌",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14+10,intYPosFontArr[1]);
			e.Graphics.DrawString("力",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14+10,intYPosFontArr[3]);

			e.Graphics.DrawString("入    量",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,intYPosFontArr[0]);
			e.Graphics.DrawString("  (ml)",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,intYPosFontArr[1]);
			e.Graphics.DrawString("输入液量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+20,intYPosFontArr[2]);
			e.Graphics.DrawString("药",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+15,intYPosFontArr[4]);
			e.Graphics.DrawString("名",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15+15,intYPosFontArr[5]);
			e.Graphics.DrawString("剂",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16+10,intYPosFontArr[4]);
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16+10,intYPosFontArr[5]);
			e.Graphics.DrawString("总",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17+5,intYPosFontArr[4]);
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17+5,intYPosFontArr[5]);

			e.Graphics.DrawString("进 食 量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21,intYPosFontArr[2]);
			e.Graphics.DrawString("胃 管",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,intYPosFontArr[3]);
			e.Graphics.DrawString("通",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18+20,intYPosFontArr[4]);
			e.Graphics.DrawString("畅",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18+20,intYPosFontArr[5]);
			
			e.Graphics.DrawString("胃",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19+20,intYPosFontArr[4]);
			e.Graphics.DrawString("液",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19+20,intYPosFontArr[5]);
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19+20,intYPosFontArr[6]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19+20,intYPosFontArr[7]);
			
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("口 服",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22+5,intYPosFontArr[3]);
			e.Graphics.DrawString("类",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21+5,intYPosFontArr[4]);
			e.Graphics.DrawString("型",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21+5,intYPosFontArr[5]);
			e.Graphics.DrawString("药",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22+15,intYPosFontArr[4]);
			e.Graphics.DrawString("名",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22+15,intYPosFontArr[5]);
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark23+10,intYPosFontArr[4]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark23+10,intYPosFontArr[5]);
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark24+5,intYPosFontArr[4]);	
		
			e.Graphics.DrawString("总",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25+5,intYPosFontArr[3]);
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("出  量",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30,intYPosFontArr[0]);
			e.Graphics.DrawString(" (ml)",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30,intYPosFontArr[1]);
			
			e.Graphics.DrawString("尿 管",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27,intYPosFontArr[2]);
			e.Graphics.DrawString("通",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark26+10,intYPosFontArr[4]);
			e.Graphics.DrawString("畅",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark26+10,intYPosFontArr[5]);
			
			e.Graphics.DrawString("尿",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27+10,intYPosFontArr[4]);
			e.Graphics.DrawString("液",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27+10,intYPosFontArr[5]);
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27+10,intYPosFontArr[6]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27+10,intYPosFontArr[7]);
			
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark28+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("大 便",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29+25,intYPosFontArr[2]);
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29+10,intYPosFontArr[4]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29+10,intYPosFontArr[5]);

			e.Graphics.DrawString("次",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30+5,intYPosFontArr[4]);
			e.Graphics.DrawString("数",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30+5,intYPosFontArr[5]);
			
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark31+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("引 流 管",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32+25,intYPosFontArr[2]);
			e.Graphics.DrawString("通",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32+15,intYPosFontArr[4]);
			e.Graphics.DrawString("畅",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32+15,intYPosFontArr[5]);
			
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark33+5,intYPosFontArr[4]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark33+5,intYPosFontArr[5]);
			
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark34+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("痰",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35+20,intYPosFontArr[0]);
			e.Graphics.DrawString("(ml)",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35+15,intYPosFontArr[1]);
			
			e.Graphics.DrawString("性",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35+10,intYPosFontArr[4]);
			e.Graphics.DrawString("质",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35+10,intYPosFontArr[5]);
			
			e.Graphics.DrawString("量",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark36+5,intYPosFontArr[4]);
			
			e.Graphics.DrawString("皮肤",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark37+10,intYPosFontArr[0]);
			e.Graphics.DrawString("情况",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark37+10,intYPosFontArr[1]);
			
			e.Graphics.DrawString("病 情 记 录",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark38+5,intYPosFontArr[0]);
			
			e.Graphics.DrawString("签名",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39+5,intYPosFontArr[0]);
				
		}
		#endregion

		#region 打印所有的垂直线
		/// <summary>
		/// 打印所有的垂直线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intPageBottomY"></param>
		private void m_mthPrintVLines(PrintPageEventArgs e,int p_intPageBottomY)
		{	
			#region 画格子竖线			
			int intXPos=(int)enmRecordRectangleInfo.LeftX;
			int intYTop=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark4;
			int intYBottom=p_intPageBottomY;
			
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);			
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark23;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark24;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark26;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark28;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark31;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark33;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark34;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark36;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark37;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark38;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.RightX;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);			
			
			#endregion							
		}
		#endregion

		#region 打印一条水平线
		/// <summary>
		/// 打印一条水平线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		private void m_mthPrintOneHorizontalLine(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
				p_intBottomY,
				(int)enmRecordRectangleInfo.RightX,
				p_intBottomY);			
		}
		#endregion

		#region 打印一行数值,并判断当前记录是否打印完
		/// <summary>
		/// 打印一行数值,并判断当前记录是否打印完
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private bool m_blnPrintOneValue(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			p_intBottomY +=(int)enmRecordRectangleInfo.VOffSet;
			#region 如果是新记录，打印日期
			if(m_blnBeginPrintNewRecord==true) 
			{
				m_intNowRowInOneRecord=0;

				//读出日期
				string strCreateDate;
				string strCreateTime;
				string strCreateDateTime;
				
				if( m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
				{
					strCreateDate = "";
					strCreateTime = "";
					strCreateDateTime = "";
				}
				else
				{
					strCreateDateTime=m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
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
					p_intBottomY);	
				e.Graphics.DrawString(strCreateTime,m_fotSmallFont ,m_slbBrush,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+1, 
					p_intBottomY );	
			}
			#endregion		
			
			
			
			#region 按修改顺序打印当前记录的某一行	
			bool blnIsRecordFinish=m_blnPrintOneRowValue(m_strValueArr,m_intNowRowInOneRecord,e,p_intBottomY);
					

			#region 签名（作过修改的人签名）
			string strSign;
			if( m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null
				|| m_intNowRowInOneRecord > m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length-1)
				strSign = "";
			else
				strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName;			
			//			clsEmployee objclsEmployee=new clsEmployee(m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[m_intNowRowInOneRecord].m_strModifyUserID);
			//			if(objclsEmployee!=null)
			//				strSign=objclsEmployee.m_StrFirstName;			
			e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark39+1, 
				p_intBottomY);
			#endregion

			m_blnBeginPrintNewRecord=blnIsRecordFinish;//当前记录是否打完					
			m_intNowRowInOneRecord++;
			#endregion

			m_intPosY += intTempDeltaY;
			return blnIsRecordFinish;			
		}

		
		#endregion 打印一行数值,并判断当前记录是否打印完
	
		#region 打印一行数值
		/// <summary>
		/// 打印一行数值
		/// </summary>
		/// <param name="p_strValueArr">数值(从“T”到“病情记录”，共37个)</param>
		/// <param name="p_intNowRowInOneRecord">第几次的结果:等价于NowRowInOneRecord</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValue(string [][] p_strValueArr,int p_intNowRowInOneRecord,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{		
			#region 打印每次修改的单行记录
			if(p_intNowRowInOneRecord<p_strValueArr.Length)
			{
				string [] strValueArr = p_strValueArr[p_intNowRowInOneRecord];

				if(p_strValueArr[0][12].IndexOf("总计:")>=4)
				{
					return m_blnPrintOneRowValueOfSummary(p_strValueArr,p_intNowRowInOneRecord,e,p_intPosY);
				}

				CharacterRange []rgnDSTArr = new CharacterRange[1];
				rgnDSTArr[0] = new CharacterRange(0,0);			
				
				RectangleF rtfText = new RectangleF(0,0,10000,100);

				StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

				RectangleF rtfBounds;

				Region [] rgnDST;

				int intTempColumn=0;//当前的列数（相对）（指除去日期和时间两列之后的相对列序号）
				int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
				
				//T
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
				//HR
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
				//P
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
				//R
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格				

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
				//Bp
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
				//CVP
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
				//血糖
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
				//神志
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		
			
				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
				//瞳孔大小左
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		
			
				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
				//瞳孔大小右
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格		

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
				//反射左
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格					

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
				//反射右
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
				//肌力
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
				//输入液量:药名
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
				//输入液量:剂量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
				//输入液量:总量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;//当前的X坐标
				//胃管通畅
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;//当前的X坐标
				//胃管性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20;//当前的X坐标
				//胃管量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark21;//当前的X坐标
				//口服类型
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark22;//当前的X坐标
				//口服药名
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark23;//当前的X坐标
				//口服性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark24;//当前的X坐标
				//口服量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25;//当前的X坐标
				//进食总量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark26;//当前的X坐标
				//尿管通畅
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark27;//当前的X坐标
				//尿管性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark28;//当前的X坐标
				//尿管量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark29;//当前的X坐标
				//大便性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark30;//当前的X坐标
				//大便次数
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark31;//当前的X坐标
				//大便量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark32;//当前的X坐标
				//引流管通畅
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark33;//当前的X坐标
				//引流管性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark34;//当前的X坐标
				//引流管量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark35;//当前的X坐标
				//痰性质
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark36;//当前的X坐标
				//痰量
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark37;//当前的X坐标
				//皮肤情况
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格								

				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark38;//当前的X坐标
				//病情记录
			#region 打印一格
				if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
				{
					e.Graphics.DrawString(strValueArr[intTempColumn],m_fotTinyFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intNowRowInOneRecord+1 < p_strValueArr.Length)
					{
						if(strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord+1][intTempColumn])
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotTinyFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(e.Graphics);

							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格	

			}
			#endregion 打印每次修改的单行记录
			
			#region 打印保留痕迹的5列			
//			if( m_objPrintContextArr[m_intCurrentRecord] !=null && ! m_objPrintContextArr[m_intCurrentRecord].m_blnIsRecordFinshed(p_intNowRowInOneRecord))
//			{
				m_objPrintContextArr[m_intCurrentRecord].m_mthPrintOneRow(p_intNowRowInOneRecord,p_intPosY,e.Graphics);				
//			}
			#endregion 打印保留痕迹的5列	
			
			if( (m_objPrintContextArr[m_intCurrentRecord] ==null || m_objPrintContextArr[m_intCurrentRecord].m_blnIsRecordFinshed(p_intNowRowInOneRecord+1))
				&& p_intNowRowInOneRecord>=p_strValueArr.Length-1)
				return true;
			else return false;
		}
		
		#endregion 打印一行数值

		#region 完成一行统计的打印
		/// <summary>
		/// 完成一行统计的打印
		/// </summary>
		/// <param name="p_strValueArr">数值(从“通气方式”到“病情记录”，共32个)</param>
		/// <param name="p_intNowRowInOneRecord">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValueOfSummary(string [][] p_strValueArr,int p_intNowRowInOneRecord,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			string [] strValueArr = p_strValueArr[p_intNowRowInOneRecord];

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=12;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			//打印统计标题			
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}			

			intTempColumn=15;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
			//输入液量：总量
			#region 打印一格
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				rtfText.X = intPosX;
				rtfText.Y = p_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);

				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格					

			intTempColumn=23;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark25;//当前的X坐标
			//进食总量
			#region 打印一格
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = p_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								
			
			intTempColumn=26;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark28;//当前的X坐标
			//出量：尿管量
			#region 打印一格
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = p_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);

				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn=29;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark31;//当前的X坐标
			//出量：大便量
			#region 打印一格
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = p_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);

				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn=32;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark34;//当前的X坐标
			//出量：引流量
			#region 打印一格
			if(strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

				rtfText.X = intPosX;
				rtfText.Y = p_intPosY;

				rgnDSTArr[0].First = 0;
				rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

				stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

				rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

				rtfBounds = rgnDST[0].GetBounds(e.Graphics);

				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
				e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			return p_intNowRowInOneRecord==p_strValueArr.Length-1;
		}
		#endregion 完成一行统计的打印

		/// <summary>
		/// 通过拆分XML，取当前记录的最后修改记录的多次输入药名和剂量
		/// </summary>
		/// <param name="p_strDrugNameAll">药名</param>
		/// <param name="p_strDrugNameXMLAll">药名XML格式</param>
		/// <param name="p_strDrugDosageAll">剂量</param>
		/// <param name="p_strDrugDosageXMLAll">剂量XML格式</param>
		/// <returns></returns>
		private clsICUIntensiveTendInLiquidContent[] m_objGetInLiquidArr(string p_strDrugNameAll,string p_strDrugNameXMLAll,string p_strDrugDosageAll,string p_strDrugDosageXMLAll)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
			doc1.LoadXml(p_strDrugNameAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugNameXMLAll);
			System.Xml.XmlNode root2  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageXMLAll);
			System.Xml.XmlNode root4  = doc1.FirstChild;

			int intInLiquidLength = root1.ChildNodes.Count;
			if(intInLiquidLength <= 0)
				return null;
			
			clsICUIntensiveTendInLiquidContent[] objContentArr = new clsICUIntensiveTendInLiquidContent[intInLiquidLength];
			for(int i1=0;i1<intInLiquidLength;i1++)
			{				
				objContentArr[i1] = new clsICUIntensiveTendInLiquidContent();
				objContentArr[i1].m_strDrugName = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugNameXML = root2.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strDrugDosage = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugDosageXML = root4.ChildNodes[i1].InnerXml;
			}
			return objContentArr;
		}

		/// <summary>
		/// 通过拆分XML，取当前记录的最后修改记录的多次口服
		/// </summary>
		/// <param name="p_strInOralAll">口服</param>
		/// <param name="p_strInOralXML">口服XML格式</param>
		/// <returns></returns>
		private clsICUIntensiveTendInOralContent[] m_objGetInOralArr(string p_strInOralTypeAll,string p_strInOralTypeXML,string p_strInOralAll,string p_strInOralXML,string p_strInOralPropertyAll,string p_strInOralPropertyXML,string p_strInOralQuantityAll,string p_strInOralQuantityXML)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
			doc1.LoadXml(p_strInOralTypeAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralTypeXML);
			System.Xml.XmlNode root2  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralXML);
			System.Xml.XmlNode root4  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralPropertyAll);
			System.Xml.XmlNode root5  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralPropertyXML);
			System.Xml.XmlNode root6  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralQuantityAll);
			System.Xml.XmlNode root7  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralQuantityXML);
			System.Xml.XmlNode root8  = doc1.FirstChild;
			
			int intInOralLength = root1.ChildNodes.Count;
			if(intInOralLength <= 0)
				return null;
			
			clsICUIntensiveTendInOralContent[] objContentArr = new clsICUIntensiveTendInOralContent[intInOralLength];
			for(int i1=0;i1<intInOralLength;i1++)
			{				
				objContentArr[i1] = new clsICUIntensiveTendInOralContent();
				objContentArr[i1].m_strInOralType = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralTypeXML = root2.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strInOral = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralXML = root4.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strInOralProperty = root5.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralPropertyXML = root6.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strInOralQuantity = root7.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralQuantityXML = root8.ChildNodes[i1].InnerXml;
			}
			return objContentArr;
		}	
		
		/// <summary>
		/// 设置保留痕迹的5列
		/// </summary>
		private void m_mthSetMultiLinePrintValues()
		{
			if(m_objPrintDataArr==null)return;		

			#region 保留痕迹的8列

				DateTime dtmFlagTime;
				
				com.digitalwave.Utility.Controls.ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr=null;
				string strRecord ="";
				string strRecordXML="";
				m_objPrintContextArr=new clsPrintContentForICU[m_objPrintDataArr.Length];
				for(int i=0;i<m_objPrintContextArr.Length;i++)//i表示IndexOfRecord,即第i条记录
				{		
					if(m_objPrintDataArr[i].m_objTransDataArr==null)
						continue;
					//提取首次打印时间
					if(m_objPrintDataArr[i].m_objTransDataArr[0].m_dtmFirstPrintDate==DateTime.MinValue)
						dtmFlagTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
					else 
						dtmFlagTime=m_objPrintDataArr[i].m_objTransDataArr[0].m_dtmFirstPrintDate;

					//提取多行的6列数组					
					string strDrugName = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strDrugName;
					string strDrugNameXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strDrugNameXML;
					string strDrugDosage = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strDrugDosage;
					string strDrugDosageXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strDrugDosageXML;
					clsICUIntensiveTendInLiquidContent [] objInLiquidArr = m_objGetInLiquidArr(strDrugName,strDrugNameXML,strDrugDosage,strDrugDosageXML);

					string strInOralType = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralType;
					string strInOralTypeXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralTypeXML;
					string strInOral = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOral;
					string strInOralXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralXML;
					string strInOralProperty = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralProperty;
					string strInOralPropertyXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralPropertyXML;
					string strInOralQuantity = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralQuantity;
					string strInOralQuantityXML = m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strInOralQuantityXML;
					clsICUIntensiveTendInOralContent [] objInOralArr = m_objGetInOralArr(strInOralType,strInOralTypeXML,strInOral,strInOralXML,strInOralProperty,strInOralPropertyXML,strInOralQuantity,strInOralQuantityXML);
		

					m_objPrintContextArr[i]= new clsPrintContentForICU();//
					if(objInLiquidArr !=null && objInLiquidArr.Length !=0)
					{
						m_objPrintContextArr[i].m_objContent_MedicineNameArr=new clsPrintRichTextContext[objInLiquidArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_MedicineNameArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_MedicineNameArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条药品信息
							strRecord =objInLiquidArr[j2].m_strDrugName;
							strRecordXML=objInLiquidArr[j2].m_strDrugNameXML;
											
							m_objPrintContextArr[i].m_objContent_MedicineNameArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_MedicineNameArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条药品信息
						}
							
						
						m_objPrintContextArr[i].m_objContent_MedicineQuantityArr=new clsPrintRichTextContext[objInLiquidArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_MedicineQuantityArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_MedicineQuantityArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条药品的剂量信息
							strRecord =objInLiquidArr[j2].m_strDrugDosage;
							strRecordXML=objInLiquidArr[j2].m_strDrugDosageXML;
											
							m_objPrintContextArr[i].m_objContent_MedicineQuantityArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_MedicineQuantityArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条药品的剂量信息
						}
					}

					if(objInOralArr !=null && objInOralArr.Length !=0)
					{
						m_objPrintContextArr[i].m_objContent_InMouthTypeArr=new clsPrintRichTextContext[objInOralArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_InMouthTypeArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_InMouthTypeArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条口服类型信息
							strRecord =objInOralArr[j2].m_strInOralType;
							strRecordXML=objInOralArr[j2].m_strInOralTypeXML;
											
							m_objPrintContextArr[i].m_objContent_InMouthTypeArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_InMouthTypeArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条口服类型信息
						}

						m_objPrintContextArr[i].m_objContent_InMouthArr=new clsPrintRichTextContext[objInOralArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_InMouthArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_InMouthArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条口服药名信息
							strRecord =objInOralArr[j2].m_strInOral;
							strRecordXML=objInOralArr[j2].m_strInOralXML;
											
							m_objPrintContextArr[i].m_objContent_InMouthArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_InMouthArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条口服药名信息
						}

						m_objPrintContextArr[i].m_objContent_InMouthPropertyArr=new clsPrintRichTextContext[objInOralArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_InMouthPropertyArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_InMouthPropertyArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条口服性质信息
							strRecord =objInOralArr[j2].m_strInOralProperty;
							strRecordXML=objInOralArr[j2].m_strInOralPropertyXML;
											
							m_objPrintContextArr[i].m_objContent_InMouthPropertyArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_InMouthPropertyArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条口服性质信息
						}

						m_objPrintContextArr[i].m_objContent_InMouthQuantityArr=new clsPrintRichTextContext[objInOralArr.Length];
						for(int j2=0;j2<m_objPrintContextArr[i].m_objContent_InMouthQuantityArr.Length;j2++)
						{
							m_objPrintContextArr[i].m_objContent_InMouthQuantityArr[j2]=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						#region 一条口服量信息
							strRecord =objInOralArr[j2].m_strInOralQuantity;
							strRecordXML=objInOralArr[j2].m_strInOralQuantityXML;
											
							m_objPrintContextArr[i].m_objContent_InMouthQuantityArr[j2].m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
							m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_InMouthQuantityArr[j2].m_ObjModifyUserArr;

							for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
							{
								if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									m_objModifyUserArr[k3].m_clrText = Color.Black;
								}
							}
						#endregion 一条口服量信息
						}
					}

				#region 皮肤情况
					m_objPrintContextArr[i].m_objContent_Skin=new clsPrintRichTextContext(Color.Black,m_fotSmallFont);
						
					strRecord =m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strSkin;
					strRecordXML=m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strSkinXML;
											
					m_objPrintContextArr[i].m_objContent_Skin.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
				
					m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_Skin.m_ObjModifyUserArr;

					for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
					{
						if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
						{
							m_objModifyUserArr[k3].m_clrText = Color.Black;
						}
					}
				#endregion 皮肤情况

				#region 病情记录
					m_objPrintContextArr[i].m_objContent_SicknessRecord=new clsPrintRichTextContext(Color.Black,m_fotTinyFont);							

					strRecord =m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strCaseHistory;
					strRecordXML=m_objPrintDataArr[i].m_objTransDataArr[m_objPrintDataArr[i].m_objTransDataArr.Length-1].m_strCaseHistoryXML;
											
					m_objPrintContextArr[i].m_objContent_SicknessRecord.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					

					m_objModifyUserArr = m_objPrintContextArr[i].m_objContent_SicknessRecord.m_ObjModifyUserArr;

					for(int k3=0;k3< m_objModifyUserArr.Length;k3++)
					{
						if(m_objModifyUserArr[k3].m_clrText.ToArgb() == Color.White.ToArgb())
						{
							m_objModifyUserArr[k3].m_clrText = Color.Black;
						}
					}
				#endregion 病情记录
				}
						
						
			#endregion 保留痕迹的8列
			
		}

		#region 设置当前要打印的一条记录数据
		/// <summary>
		/// 设置当前要打印的一条记录数据,返回：该条记录的最大打印行数(除多行打印的5列外)
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private int m_intSetPrintOneValueRows(PrintPageEventArgs e,ref int p_intBottomY)
		{			
			if(m_objPrintDataArr==null || m_intCurrentRecord>= m_objPrintDataArr.Length)
				return 0;
			
			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag == (int)enmRecordsType.ICUIntensiveTend && (m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr==null || m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length==0))
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
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.ICUIntensiveTend && ( m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null || m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length==0))
					{
						intLenth = 2;
						intRowsOfOneRecord = intLenth;
						strModifyDate = "";
						m_strValueArr=new string[intLenth][];
						m_strValueArr[0]=new string[37];

						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[0][12]="合共单项总计:";
						else
							m_strValueArr[0][12]="按日单项总计:";

						m_strValueArr[0][15]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTransfusion_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTransfusion_Total.ToString());

						m_strValueArr[0][23]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTakeFood_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTakeFood_Total.ToString());

						m_strValueArr[0][26]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutPeeQuantity_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutPeeQuantity_Total.ToString());

						m_strValueArr[0][29]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutDefecateQuantity_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutDefecateQuantity_Total.ToString());

						m_strValueArr[0][32]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutLeadQuantity_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intOutLeadQuantity_Total.ToString());

						m_strValueArr[1]=new string[37];

						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[1][12]="合共分类总计:";
						else
							m_strValueArr[1][12]="按日分类总计:";						

						m_strValueArr[1][15]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTotal_In == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTotal_In.ToString());
						
						m_strValueArr[1][26]=(m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTotal_Out == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objICUSummary.m_intTotal_Out.ToString());
						
						return intLenth;
					}
					else
					{
						intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
						strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
						intLenth=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
						m_strValueArr=new string[intLenth][];
						for(int k1=0;k1<intLenth;k1++)
						{
							m_strValueArr[k1]=new string[37];
							m_strValueArr[k1][0]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strT_Last;
							m_strValueArr[k1][1]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strHR_Last;
							m_strValueArr[k1][2]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strP_Last;
							m_strValueArr[k1][3]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strR_Last;
							m_strValueArr[k1][4]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBp_Last;
							m_strValueArr[k1][5]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strCVP_Last;
							m_strValueArr[k1][6]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodSugar_Last;
							m_strValueArr[k1][7]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strConsciousness_Last;
							m_strValueArr[k1][8]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilSizeLeft_Last;
							m_strValueArr[k1][9]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilSizeRight_Last;
							m_strValueArr[k1][10]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strReflectLeft_Last;
							m_strValueArr[k1][11]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strReflectRight_Last;
							m_strValueArr[k1][12]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPower_Last;
							m_strValueArr[k1][13]="";//输入液量：药品（与时间一对多关系,按照实际的条数打印，每条之间不考虑换行情况）m_objInLiquidArr
							m_strValueArr[k1][14]="";//输入液量：剂量（与药品相同)m_objInLiquidArr
							m_strValueArr[k1][15]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTransfusionTotal_Last;

							if(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachPipe_Last!="")
							{
								m_strValueArr[k1][16]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachDirection_Last+"("+m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachPipe_Last+")";			
							}
							else
								m_strValueArr[k1][16]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachDirection_Last;
							m_strValueArr[k1][17]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachProperty_Last;
							m_strValueArr[k1][18]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strStomachQuantity_Last;
							m_strValueArr[k1][19]="";//口服类型 m_objInOralArr
							m_strValueArr[k1][20]="";//口服药名 m_objInOralArr
							m_strValueArr[k1][21]="";//口服性质 m_objInOralArr
							m_strValueArr[k1][22]="";//口服量 m_objInOralArr
	
							m_strValueArr[k1][23]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTakeFoodTotal_Last;

							m_strValueArr[k1][24]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPeeDirection_Last;
							m_strValueArr[k1][25]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPeeProperty_Last;
							m_strValueArr[k1][26]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPeeQuantity_Last;
							m_strValueArr[k1][27]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strDefecateProperty_Last;
							m_strValueArr[k1][28]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strDefecateTimes_Last;
							m_strValueArr[k1][29]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strDefecateQuantity_Last;

							if(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadPipe_Last!="")
							{
								m_strValueArr[k1][30]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadDirection_Last+"("+m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadPipe_Last+")";
							}
							else
								m_strValueArr[k1][30]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadDirection_Last;
							
							m_strValueArr[k1][31]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadProperty_Last;
							m_strValueArr[k1][32]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strLeadQuantity_Last;
							m_strValueArr[k1][33]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strSputumProperty_Last;
							m_strValueArr[k1][34]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strSputumQuantity_Last;
							m_strValueArr[k1][35]="";//皮肤情况(与时间一对一关系,要考虑换行情况)m_strSkin,m_strSkinXML
							m_strValueArr[k1][36]="";//病情记录(与时间一对一关系,要考虑换行情况)m_strCaseHistory,m_strCaseHistoryXML

						
						}						

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
		#endregion

//		/// <summary>
//		/// 打印信息.
//		/// </summary>
//		[Serializable]			
//		private class clsPrintInfo_ICUIntensiveTend
//		{
//			public string m_strInPatentID;	
//			public DateTime m_dtmInPatientDate;
//			public string m_strWeight;
//			public string m_strPatientName;
//			public string m_strSex;
//			public string m_strAge;
//			public string m_strBedName;
//			public string m_strDeptName;
//			public string m_strAreaName;			
//			public DateTime m_dtmOpenDate;
//
//			public clsTransDataInfo[] m_objTransDataArr;			
//			public DateTime[] m_dtmFirstPrintDateArr;//Length与m_dtmFirstPrintDateArr.Length相同.
//			public bool[] m_blnIsFirstPrintArr;//Length与m_dtmFirstPrintDateArr.Length相同.
//			
//			public clsICUIntensiveTendDataInfo[] m_objPrintDataArr;
//		}


		private class clsPrintContentForICU
		{
			public clsPrintRichTextContext[] m_objContent_MedicineNameArr;
			public clsPrintRichTextContext[] m_objContent_MedicineQuantityArr;
			public clsPrintRichTextContext[] m_objContent_InMouthTypeArr;
			public clsPrintRichTextContext[] m_objContent_InMouthArr;
			public clsPrintRichTextContext[] m_objContent_InMouthPropertyArr;
			public clsPrintRichTextContext[] m_objContent_InMouthQuantityArr;
			public clsPrintRichTextContext m_objContent_Skin;
			public clsPrintRichTextContext m_objContent_SicknessRecord;

			/// <summary>
			/// 当前记录是否打印完成,true:完成
			/// </summary>
			/// <param name="p_intCurrentRowInOneRecord">当前记录的打印行序数（从0开始计数）</param>
			/// <returns></returns>
			public bool m_blnIsRecordFinshed(int p_intCurrentRowInOneRecord)
			{
				
				if(m_objContent_Skin.m_BlnHaveNextLine() || m_objContent_SicknessRecord.m_BlnHaveNextLine()
					||( m_objContent_MedicineNameArr !=null && p_intCurrentRowInOneRecord < m_objContent_MedicineNameArr.Length )
					||( m_objContent_MedicineQuantityArr !=null && p_intCurrentRowInOneRecord < m_objContent_MedicineQuantityArr.Length )
					||( m_objContent_InMouthTypeArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthTypeArr.Length )
					||( m_objContent_InMouthArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthArr.Length )
					||( m_objContent_InMouthPropertyArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthPropertyArr.Length )
					||( m_objContent_InMouthQuantityArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthQuantityArr.Length )
					)								
					return false;				
				else return true;				
			}

			/// <summary>
			/// 打印当前五列的一行
			/// </summary>
			/// <param name="p_intCurrentRowInOneRecord"></param>
			/// <param name="p_intWithOfSkin"></param>
			/// <param name="p_intWithOfSicknessRecord"></param>
			/// <param name="p_intY"></param>
			/// <param name="p_objGrp"></param>
			public void m_mthPrintOneRow(int p_intCurrentRowInOneRecord,int p_intY,System.Drawing.Graphics p_objGrp)
			{
				if( m_objContent_MedicineNameArr !=null && p_intCurrentRowInOneRecord < m_objContent_MedicineNameArr.Length)
				{
					m_objContent_MedicineNameArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark15+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_MedicineQuantityArr !=null && p_intCurrentRowInOneRecord < m_objContent_MedicineQuantityArr.Length)
				{
					m_objContent_MedicineQuantityArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark16+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_InMouthTypeArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthTypeArr.Length)
				{
					m_objContent_InMouthTypeArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark21+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_InMouthArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthArr.Length)
				{
					m_objContent_InMouthArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark22+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_InMouthPropertyArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthPropertyArr.Length)
				{
					m_objContent_InMouthPropertyArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark23+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_InMouthQuantityArr !=null && p_intCurrentRowInOneRecord < m_objContent_InMouthQuantityArr.Length)
				{
					m_objContent_InMouthQuantityArr[p_intCurrentRowInOneRecord].m_mthPrintLine(99999,(int)enmRecordRectangleInfo.ColumnsMark24+(int)enmRecordRectangleInfo.LeftX+1,p_intY,p_objGrp);
				}
				if( m_objContent_Skin.m_BlnHaveNextLine())
				{
					m_objContent_Skin.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark38-(int)enmRecordRectangleInfo.ColumnsMark37,(int)enmRecordRectangleInfo.ColumnsMark37+(int)enmRecordRectangleInfo.LeftX,p_intY,p_objGrp);
				}
				if( m_objContent_SicknessRecord.m_BlnHaveNextLine())
				{
					m_objContent_SicknessRecord.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark39-(int)enmRecordRectangleInfo.ColumnsMark38,(int)enmRecordRectangleInfo.ColumnsMark38+(int)enmRecordRectangleInfo.LeftX,p_intY,p_objGrp);
//					m_objContent_SicknessRecord.m_mthPrintLine((int)enmRecordRectangleInfo.ColumnsMark38+(int)enmRecordRectangleInfo.LeftX,p_intY,p_objGrp,20);
				}
			}

			/// <summary>
			/// 由于调用clsPrintRichTextContext进行打印，须将m_intCurrentIndex、m_intCurrentDSTIndex设为0
			/// </summary>
			public void m_mthReset()
			{
				if(m_objContent_MedicineNameArr!=null)
				{
					for(int i=0;i<m_objContent_MedicineNameArr.Length;i++)
					{
						if(m_objContent_MedicineNameArr[i]!=null)
							m_objContent_MedicineNameArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_MedicineQuantityArr!=null)
				{
					for(int i=0;i<m_objContent_MedicineQuantityArr.Length;i++)
					{
						if(m_objContent_MedicineQuantityArr[i]!=null)
							m_objContent_MedicineQuantityArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_InMouthTypeArr!=null)
				{
					for(int i=0;i<m_objContent_InMouthTypeArr.Length;i++)
					{
						if(m_objContent_InMouthTypeArr[i]!=null)
							m_objContent_InMouthTypeArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_InMouthArr!=null)
				{
					for(int i=0;i<m_objContent_InMouthArr.Length;i++)
					{
						if(m_objContent_InMouthArr[i]!=null)
							m_objContent_InMouthArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_InMouthPropertyArr!=null)
				{
					for(int i=0;i<m_objContent_InMouthPropertyArr.Length;i++)
					{
						if(m_objContent_InMouthPropertyArr[i]!=null)
							m_objContent_InMouthPropertyArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_InMouthQuantityArr!=null)
				{
					for(int i=0;i<m_objContent_InMouthQuantityArr.Length;i++)
					{
						if(m_objContent_InMouthQuantityArr[i]!=null)
							m_objContent_InMouthQuantityArr[i].m_mthRestartPrint();
					}
				}
				if(m_objContent_SicknessRecord!=null)
					m_objContent_SicknessRecord.m_mthRestartPrint();
				if(m_objContent_Skin!=null)
					m_objContent_Skin.m_mthRestartPrint();
			}
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
		//		clsICUIntensiveTendPrintTool objPrintTool;
		//		private void m_mthDemoPrint_FromDataSource()
		//		{	
		//			objPrintTool=new clsICUIntensiveTendPrintTool();
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
		//			objPrintTool=new clsICUIntensiveTendPrintTool();
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