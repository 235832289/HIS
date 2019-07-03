using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 观察项目的打印工具类,Jacky-2003-6-5
	/// </summary>
	public class clsWatchItemTrackPrintTool: infPrintRecord
	{	
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsRecordsDomain m_objRecordsDomain;
		private clsPrintInfo_WatchItem m_objPrintInfo;
		
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
			m_objPrintInfo=new clsPrintInfo_WatchItem();
			m_objPrintInfo.m_strInPatentID=m_objPatient!=null? m_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo. m_strSex=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo. m_strAge=m_objPatient!=null? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo. m_strBedName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo. m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName :"";
			m_objPrintInfo. m_strAreaName=m_objPatient!=null? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName:"";			
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;

            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
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
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.WatchItem);
				
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
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_WatchItem")
			{
				MDIParent.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_WatchItem)p_objPrintContent;
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
		/// 当前行的Y坐标
		/// </summary>
		private int m_intPosY = (int)enmRecordRectangleInfo.TopY+150;
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
		/// 打印的病人基本信息类
		/// </summary>
		private class clsEveryRecordPageInfo
		{
			public string strPatientName;
			public string strSex;
			public string strAge;
			public string strBedNo;
			public string strAreaName;
			public string strDeptName;
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
			TopY = 200,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 5,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 820-35,
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
			/// 第二条间隔线(X)，体温（起点线）
			/// </summary>
			ColumnsMark2=120,

			/// <summary>
			/// 第3条间隔线(X)，心律（起点线）
			/// </summary>
			ColumnsMark3=154,

			/// <summary>
			/// 心率 次/分（起点线）
			/// </summary>
			ColumnsMark4=194,

			/// <summary>
			/// 脉搏（起点线）
			/// </summary>
			ColumnsMark5=224,

			/// <summary>
			/// 呼吸（起点线）
			/// </summary>
			ColumnsMark6=254,

			/// <summary>
			/// 血压（起点线）
			/// </summary>
			ColumnsMark7=284,

			/// <summary>
			/// 瞳孔大小 左（起点线）
			/// </summary>
			ColumnsMark8=340,

			/// <summary>
			/// 瞳孔大小 右（起点线）
			/// </summary>
			ColumnsMark9=370,

			/// <summary>
			/// 反射 左（起点线）
			/// </summary>
			ColumnsMark10=400,

			/// <summary>
			/// 反射 右（起点线）
			/// </summary>
			ColumnsMark11=440,

			/// <summary>
			/// 血氧饱和度（起点线）
			/// </summary>
			ColumnsMark12=480,

			/// <summary>
			/// 床边血糖（起点线）
			/// </summary>
			ColumnsMark13=510,

			/// <summary>
			/// 输液量（起点线）
			/// </summary>
			ColumnsMark14=550,

			/// <summary>
			/// 进食量（起点线）
			/// </summary>
			ColumnsMark15=580,

			/// <summary>
			/// 引流量（起点线）
			/// </summary>
			ColumnsMark16=610,

			/// <summary>
			/// 尿 量（起点线）
			/// </summary>
			ColumnsMark17=640,

			ColumnsMark18=670,

			ColumnsMark19=700,

			/// <summary>
			/// 签名（起点线）
			/// </summary>
			ColumnsMark20=730	
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
						m_fReturnPoint = new PointF(60f,150f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(130f,150f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(170f,150f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(200f,150f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(240f,150f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(280f,150f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(320f,150f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(600f,150f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(640f,150f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(680f,150f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(740f,150f);
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
		private clsWatchItemDataInfo[] m_objPrintDataArr;
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
				MDIParent.ShowInformationMessageBox("打印数据有误!");
				return;
			}
			ArrayList m_arlTemp = new ArrayList();
			for(int i1=0;i1<p_objTransDataArr.Length;i1++)
			{
				m_arlTemp.Add(p_objTransDataArr[i1]);
			}
			m_objPrintDataArr = (clsWatchItemDataInfo[])m_arlTemp.ToArray(typeof(clsWatchItemDataInfo));
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
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);

				while(m_intCurrentRecord < m_objPrintDataArr.Length)
				{				
					if(m_intCurrentRecord==0)
						m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
					m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intPosY);	
				
					//斜线
					p_objPrintPageArg.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8 ,
						m_intPosY-intTempDeltaY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,
						m_intPosY);			

					if(m_blnBeginPrintNewRecord)
					{
						m_intCurrentRecord++;
					
						m_mthPrintOneHorizontalLine(p_objPrintPageArg,m_intPosY);

						int intMaxRows=m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
						if(m_intPosY + intMaxRows*intTempDeltaY >= 1100	&& m_intCurrentRecord < m_objPrintDataArr.Length)
						{
							p_objPrintPageArg.HasMorePages = true;				

							//Print VLine
							m_mthPrintVLines(p_objPrintPageArg,m_intPosY);
							m_mthPrintOneHorizontalLine(p_objPrintPageArg,m_intPosY);

							//页脚//////////////////////////////////////////////////////////////
							p_objPrintPageArg.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
								1092/*m_intPosY+(int)enmRecordRectangleInfo.VOffSet*/ );
           

							m_intPosY = (int)enmRecordRectangleInfo.TopY+150;
							m_intNowPage++;
							return;
					
						}
					}					
				
				}
				m_mthPrintVLines(p_objPrintPageArg,m_intPosY);
				//页脚//////////////////////////////////////////////////////////////
				p_objPrintPageArg.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
					1092/*m_intPosY+(int)enmRecordRectangleInfo.VOffSet*/ );
			
				#region 打印完毕，ReSet(复位)操作
				if(m_intCurrentRecord==m_objPrintDataArr.Length)
				{	
					m_intPosY = (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep;
					m_intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
					m_blnBeginPrintNewRecord=true;//复位
					m_intNowPage=1;//复位						
				}
				#endregion				
			}
			catch(Exception err)
			{
				MDIParent.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

			}
		}

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{		
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsEveryRecordPageInfo objEveryRecordPageInfo=new clsEveryRecordPageInfo();
			//************************************************			
			objEveryRecordPageInfo.strAge =m_objPrintInfo.m_strAge;
			objEveryRecordPageInfo.strPatientName=m_objPrintInfo.m_strPatientName;
			objEveryRecordPageInfo.strDeptName=m_objPrintInfo.m_strDeptName;
			objEveryRecordPageInfo.strBedNo =m_objPrintInfo.m_strBedName;
			objEveryRecordPageInfo.strAreaName=m_objPrintInfo.m_strAreaName;
			objEveryRecordPageInfo.strSex=m_objPrintInfo.m_strSex;
			objEveryRecordPageInfo.strInPatientID=m_objPrintInfo.m_strHISInPatientID;
			objEveryRecordPageInfo.strPrintDate=( m_objPrintInfo.m_strInPatentID!="")? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		
			

			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("观 察 项 目 记 录 单",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,new PointF(440f,150f));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAreaName ,m_fotSmallFont,m_slbBrush,new PointF(480f,150f));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
						
		}
		#endregion

		#region 画表头格子
		/// <summary>
		///  画表头格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			int m_intHeaderRowStep=50;
			
			//画格子横线
			for(int i1=0;i1<4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
			{
				if(i1 !=1 && i1 !=2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1);
				else if(i1==1)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark8,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark12,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark14,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark20,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5);
				}
				else //if(i1==2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark8,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark12,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1);
			}
			
			#region 画格子竖线
			int intHeight=3*m_intHeaderRowStep;
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
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY+intHeight);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+intHeight);
			#endregion				

			#region 打印空报表
			if(m_objPrintInfo.m_strInPatentID =="" || m_objPrintDataArr==null || m_objPrintDataArr.Length==0)
			{					
				while(m_intPosY < 1060)
				{
					m_intPosY += (int)enmRecordRectangleInfo.RowStep;

					//斜线
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8 ,
						m_intPosY-intTempDeltaY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,
						m_intPosY);		

					//水平线
					m_mthPrintOneHorizontalLine(e,m_intPosY);
				}
	
				//Print VLine
				m_mthPrintVLines(e,m_intPosY);
				m_mthPrintOneHorizontalLine(e,m_intPosY);

				//页脚//////////////////////////////////////////////////////////////
				e.Graphics.DrawString("（第 1 页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
					m_intPosY+(int)enmRecordRectangleInfo.VOffSet );
	
				//复位
				m_intPosY = (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep;
						
				return;
			}
			#endregion
			
		}

						
		#endregion		

		#region 画标题的栏目
		private int m_intHeaderRowStep=50;
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			
		
			e.Graphics.DrawString("日期",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+15,
				(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
		     
			e.Graphics.DrawString("时间",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);

			//体温 C			
			e.Graphics.DrawString("体",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("温",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("。",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY-10+2*m_intHeaderRowStep+5);
			e.Graphics.DrawString("C",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+9, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+1+5);

			// 心律			
			e.Graphics.DrawString("心",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+5, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("律",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+5, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			
			//心率(次/分)
			e.Graphics.DrawString("心",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("率",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//脉搏(次/分)
			e.Graphics.DrawString("脉",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("搏",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//呼吸(次/分)
			e.Graphics.DrawString("呼",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("吸",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//血压(mmHg)
			e.Graphics.DrawString("血压",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+8, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-15);
			e.Graphics.DrawString("mmHg",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+8, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-10);
	
			e.Graphics.DrawString(" 瞳 孔",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+31, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("大小",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+10, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5-5);
			e.Graphics.DrawString("(mm)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+10, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5+15);
			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);


			e.Graphics.DrawString("反射",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+18, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);

			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark11+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			//血氧饱和度(%)
			e.Graphics.DrawString("血",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("氧",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*1/6);
			e.Graphics.DrawString("饱",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*2/6);
			e.Graphics.DrawString("和",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*3/6);
			e.Graphics.DrawString("度",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*4/6);
			e.Graphics.DrawString("(%)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*5/6);

			//床边血糖(mmol/L)
			e.Graphics.DrawString("床",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("边",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*1/6);
			e.Graphics.DrawString("血",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*2/6);
			e.Graphics.DrawString("糖",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*3/6);
			e.Graphics.DrawString("mmol",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*4/6);
			e.Graphics.DrawString("/L",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*5/6);


			e.Graphics.DrawString("摄入",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15-20, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("(ml)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15-20, (int)enmRecordRectangleInfo.TopY+25);
			e.Graphics.DrawString("输",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("液",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);

			e.Graphics.DrawString("进",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("食",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);


			e.Graphics.DrawString("排出",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18-20, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("(ml)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18-20, (int)enmRecordRectangleInfo.TopY+25);
			e.Graphics.DrawString("引",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("流",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);

			e.Graphics.DrawString("尿",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark17+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark17+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);

			e.Graphics.DrawString("大",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("便",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);

			e.Graphics.DrawString("呕",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("吐",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("物",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);


			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark20+1,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
		
		
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
			int intContentTopY=(int)enmRecordRectangleInfo.TopY+ 150;
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPageBottomY);
			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPageBottomY);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPageBottomY);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPageBottomY);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPageBottomY);
			
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPageBottomY);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,p_intPageBottomY);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,intContentTopY,
				(int)enmRecordRectangleInfo.RightX,p_intPageBottomY);
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

		#region 只打印一行
		/// <summary>
		/// 只打印一行
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
				
				if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
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
			string strSign = "";
			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
				strSign = "";
//			else if((m_intNowRowInOneRecord+1 <m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length))
//			{
//				if((m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName) != (m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord+1].m_strModifyUserName))
//					strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName;
//				
//			}
			else
				strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName;
				//			clsEmployee objclsEmployee=new clsEmployee(m_objclsWatchItemRecordContent_AllArr[m_intCurrentRecord].m_objclsWatchItemRecordContentArr[m_intNowRowInOneRecord].m_strModifyUserID);
			//			if(objclsEmployee!=null)
			//				strSign=objclsEmployee.m_StrFirstName;			
			e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20+1, 
				p_intBottomY);
			#endregion

			m_blnBeginPrintNewRecord=blnIsRecordFinish;//当前记录是否打完					
			m_intNowRowInOneRecord++;
			#endregion

			m_intPosY += intTempDeltaY;
			return blnIsRecordFinish;			
		}

		#endregion
	
		#region Liyi
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValue(string [][] p_strValueArr,int p_intIndex,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			string [] strValueArr = p_strValueArr[p_intIndex];

			if(p_strValueArr[0][12] == "总计:")
			{
				return m_blnPrintOneRowValueOfSummary(p_strValueArr,p_intIndex,e,p_intPosY);
			}

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=0;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			//体温
			#region 打印一格，（以下完全相同）
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			intTempColumn=1;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			//心律
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			intTempColumn=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			//心率
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			intTempColumn=3;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			//脉搏
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			intTempColumn=4;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			//呼吸
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			
			bool blnIsLastModify=false;
			if( p_intIndex == p_strValueArr.Length-1 || (strValueArr[5] == p_strValueArr[p_intIndex+1][5] && strValueArr[6] == p_strValueArr[p_intIndex+1][6] && strValueArr[5] == p_strValueArr[p_strValueArr.Length-1][5] && strValueArr[6] == p_strValueArr[p_strValueArr.Length-1][6] ))
			{// 当存在下一行，并且当前元素 != 下一行此元素				
				blnIsLastModify=true;					
			}
			//血压(收缩压)
			if(strValueArr[5].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[5],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY-15);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;
					rtfText.Y = p_intPosY-15;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[5].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[5],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}	
			
			//血压(舒张压)
			if(strValueArr[6].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[6],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+30,p_intPosY);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+30;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[6].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[6],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}

			intTempColumn=7;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			//瞳孔大小（左）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//瞳孔大小（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//瞳孔反射（左）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//瞳孔反射（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//血氧饱和度
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//床边血糖
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//输入液量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//进食量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//引流量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//尿量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//大便
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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
			//呕吐物
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
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

			return p_intIndex==p_strValueArr.Length-1;
		}
		#endregion


		#region Alex
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValueOfSummary(string [][] p_strValueArr,int p_intIndex,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			string [] strValueArr = p_strValueArr[p_intIndex];

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=0;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			//体温

			intTempColumn=1;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			//心律

			intTempColumn=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			//心率

			intTempColumn=3;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			//脉搏
			intTempColumn=4;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			//呼吸

			intTempColumn=7;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			//瞳孔大小（左）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			//瞳孔大小（右）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			//瞳孔反射（左）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
			//瞳孔反射（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
			//血氧饱和度
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
			//床边血糖
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			//输入液量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
			//进食量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
			//引流量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
			//尿量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;//当前的X坐标
			//大便
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;//当前的X坐标
			//呕吐物
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
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

			return p_intIndex==p_strValueArr.Length-1;
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
			//
			//			if(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr==null || m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length==0)
			//				return 0;

			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag == (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr==null)
				return 0;
			//			int intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
			//			string strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss") ;

			int intRowsOfOneRecord;
			string strModifyDate;
		
			try
			{
				#region 如果是新记录，判断是否保留痕迹
				int intLenth;
				if(m_blnBeginPrintNewRecord==true) 
				{									
					#region 当前记录数组赋值
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
					{
						intLenth = 2;
						intRowsOfOneRecord = intLenth;
						strModifyDate = "";
						m_strValueArr=new string[intLenth][];
						m_strValueArr[0]=new string[19];
						m_strValueArr[0][0]="";
						m_strValueArr[0][1]="";
						m_strValueArr[0][2]="";
						m_strValueArr[0][3]="";
						m_strValueArr[0][4]="";
						m_strValueArr[0][5]="";
						m_strValueArr[0][6]="";
						m_strValueArr[0][7]="";
						m_strValueArr[0][8]="";
						m_strValueArr[0][9]="";
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[0][10]="合共";
						else
							m_strValueArr[0][10]="按日";
						m_strValueArr[0][11]="单项";
						m_strValueArr[0][12]="总计:";
						m_strValueArr[0][13]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInI_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInI_Total.ToString());
						m_strValueArr[0][14]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInD_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInD_Total.ToString());
						m_strValueArr[0][15]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutE_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutE_Total.ToString());
						m_strValueArr[0][16]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutU_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutU_Total.ToString());
						m_strValueArr[0][17]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutS_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutS_Total.ToString());
						m_strValueArr[0][18]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutV_Total == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutV_Total.ToString());
					
						m_strValueArr[1]=new string[19];
						m_strValueArr[1][0]="";
						m_strValueArr[1][1]="";
						m_strValueArr[1][2]="";
						m_strValueArr[1][3]="";
						m_strValueArr[1][4]="";
						m_strValueArr[1][5]="";
						m_strValueArr[1][6]="";
						m_strValueArr[1][7]="";
						m_strValueArr[1][8]="";
						m_strValueArr[1][9]="";
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[1][10]="合共";
						else
							m_strValueArr[1][10]="按日";
						m_strValueArr[1][11]="分类";
						m_strValueArr[1][12]="总计:";
						m_strValueArr[1][13]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In.ToString());
						m_strValueArr[1][14]="";
						m_strValueArr[1][15]=(m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out.ToString());
						m_strValueArr[1][16]="";
						m_strValueArr[1][17]="";
						m_strValueArr[1][18]="";
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
							m_strValueArr[k1]=new string[19];
							m_strValueArr[k1][0]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTemperature;
							m_strValueArr[k1][1]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strHeartRhythm;
							m_strValueArr[k1][2]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strHeartFrequency;
							m_strValueArr[k1][3]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPulse;
							m_strValueArr[k1][4]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBreath;
							m_strValueArr[k1][5]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodPressureS;
							m_strValueArr[k1][6]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodPressureA;
							m_strValueArr[k1][7]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilLeft;
							m_strValueArr[k1][8]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilRight;
							m_strValueArr[k1][9]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strEchoLeft;
							m_strValueArr[k1][10]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strEchoRight;
							m_strValueArr[k1][11]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodOxygenSaturation;
							m_strValueArr[k1][12]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBedsideBloodSugar;
							m_strValueArr[k1][13]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInI == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInI.ToString());
							m_strValueArr[k1][14]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInD == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInD.ToString());
							m_strValueArr[k1][15]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutE == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutE.ToString());
							m_strValueArr[k1][16]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutU == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutU.ToString());
							m_strValueArr[k1][17]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutS == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutS.ToString());
							m_strValueArr[k1][18]=(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutV == 0?"":m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutV.ToString());
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
				MDIParent.ShowInformationMessageBox(ex.Message);
				return 1;
			}			
		}
		#endregion
		#endregion

//		/// <summary>
//		/// 打印信息.
//		/// </summary>
//		[Serializable]			
//		private class clsPrintInfo_WatchItem
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
//			public clsTransDataInfo[] m_objTransDataArr;			
//			public DateTime[] m_dtmFirstPrintDateArr;//Length与m_dtmFirstPrintDateArr.Length相同.
//			public bool[] m_blnIsFirstPrintArr;//Length与m_dtmFirstPrintDateArr.Length相同.
//			
//			public clsWatchItemDataInfo[] m_objPrintDataArr;
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
//		clsWatchItemTrackPrintTool objPrintTool;
//		private void m_mthDemoPrint_FromDataSource()
//		{	
//			objPrintTool=new clsWatchItemTrackPrintTool();
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
//			objPrintTool=new clsWatchItemTrackPrintTool();
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


