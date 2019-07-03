using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
namespace iCare
{
	/// <summary>
	/// clsBornSchedulePrintTool 的摘要说明。
	/// </summary>
	public class clsBornSchedulePrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		
		private clsPrintInfo_ThreeMeasureRecord m_objPrintInfo;

		public clsBornSchedulePrintTool()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{		
//			m_blnWantInit=false;//
//			if(m_objPrintInfo==null)
//			{
//				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
//				return;
//			}

			//设置表单内容到打印中			
			m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
		}
		private void m_mthSetPrintValue()
		{
			
		}


		#region 打印

		private com.digitalwave.Utility.Controls.ctlBornScheduleRecordPrintTool m_objPrintRecordTool;
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，本类忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,System.DateTime p_dtInPateintDate, System.DateTime p_dtOpenDate)
		{	
			
			m_objPrintRecordTool = new  com.digitalwave.Utility.Controls.ctlBornScheduleRecordPrintTool();	
			m_objPrintRecordTool.m_StrWoman = p_objPatient.m_StrName;
			m_objPrintRecordTool.m_StrBedNo = p_objPatient.m_strBedCode;
			m_objPrintRecordTool.m_StrAge = p_objPatient.m_ObjPeopleInfo.m_StrAge;
            m_objPrintRecordTool.m_StrHospitalName = clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle;
			
		}

		public  void  m_mthSetPrintInfo(clsPatient p_objPatient,clsBornRecordManager p_objBornRecordManager,clsBornScheduleEveryDay p_objBornScheduleEveryDay)
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
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
//			if(m_blnIsFromDataSource )
//			{
//				if(m_objPrintInfo==null)
//				{
//					clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
//					return null;
//				}
//
//				if(m_blnWantInit)
//					m_mthInitPrintContent();				
//			}			
//
//			//没有记录内容时，返回空
//			if(m_objPrintInfo.m_objRecordArr == null || m_objPrintInfo.m_objRecordArr.Length == 0)
//				return null;
//			else
//				return m_objPrintInfo;

			return null;
		}	
		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			ArrayList arlContent=(ArrayList)p_objPrintContent;
			m_objPrintRecordTool.m_clsBornRecordManager = (clsBornRecordManager)arlContent[0];
			m_objPrintRecordTool.m_clsCurrentDay = (clsBornScheduleEveryDay)arlContent[1];

//			m_blnWantInit=false;
//			if(p_objPrintContent.GetType().Name !="clsPrintInfo_ThreeMeasureRecord")
//			{
//				clsPublicFunction.ShowInformationMessageBox("参数错误");
//			}
//			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
//			m_objPrintInfo=(clsPrintInfo_ThreeMeasureRecord)p_objPrintContent;					
//			m_mthSetPrintValue();			
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
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			
		}


		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{			
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel)
			{				
				m_intStartDate = 0;
				m_intWeek = 0;
				m_intItemIndex = int.MaxValue;
				m_intPageNum = 0;		

			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
		}

		private  void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作
			m_intStartDate = 0;
			m_intWeek = 0;
			m_intItemIndex = int.MaxValue;
		}

		private int m_intStartDate;		
		private int m_intWeek;
		private int m_intItemIndex;
		private int m_intPageNum;	
		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs e)
		{
			int intStartY = 0;//m_intPrintHeader(e);
			bool blnHasMoreDate=false;
			int intRecordEndY;

			
			int m_intItemIndex=int.MaxValue;
			bool blnIsAppend = m_intItemIndex != int.MaxValue;
		
			if(!blnIsAppend)
			{
				/*
				 * 打印正页
				 */
				m_objPrintRecordTool.m_mthPrintRecord(100,intStartY+40,980,e,m_intStartDate,7,out blnHasMoreDate,out intRecordEndY,out m_intItemIndex);
				//				m_objPrintRecordTool.m_C

				m_intWeek++;
				m_intPageNum++;

				if(m_intItemIndex == int.MaxValue)
				{
					//没有附页
					m_intStartDate += 7;
					e.HasMorePages = blnHasMoreDate;

					//m_mthPrintWeek(intRecordEndY+10,e,m_intWeek);
					//Modify By LiChengZhang 2004-12-2
					//m_mthPrintPageNum(intRecordEndY+20,e,m_intPageNum,blnIsAppend);
					//m_mthPrintPageNum(intRecordEndY+10,e,m_intPageNum,blnIsAppend);
					//Modify END
					

					if(!blnHasMoreDate)
					{
						//所有日期已经打印完
						m_intStartDate = 0;
						m_intWeek = 0;
						m_intItemIndex = int.MaxValue;
						m_intPageNum = 0;
					}
				}
				else
				{
					//有附页

					m_mthPrintWeek(intRecordEndY+10,e,m_intWeek);

					m_mthPrintPageNum(intRecordEndY+20,e,m_intPageNum,blnIsAppend);

					e.HasMorePages = true;
				}
			}
			else
			{
				//打印附页
				//m_objPrintRecordTool.m_mthPrintLeftRecord(m_intItemIndex,80,120,e,m_intStartDate,7,out intRecordEndY,out blnHasMoreDate);

				m_intItemIndex = int.MaxValue;

				m_intStartDate += 7;
				e.HasMorePages = blnHasMoreDate;	
			
//				m_mthPrintWeek(intRecordEndY+10,e,m_intWeek);
//
//				m_mthPrintPageNum(intRecordEndY+20,e,m_intPageNum,blnIsAppend);
			
				if(!blnHasMoreDate)
				{
					//所有日期已经打印完
					m_intStartDate = 0;
					m_intWeek = 0;
					m_intItemIndex = int.MaxValue;
					m_intPageNum = 0;
				}
			}
		}

		// 打印结束时的操作
		private  void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{			
			
		}	

		private void m_mthPrintWeek(int p_intStartY,System.Drawing.Printing.PrintPageEventArgs e,int p_intWeek)
		{		
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第   页",fntHeader,Brushes.Black,360,p_intStartY);
			e.Graphics.DrawString(p_intWeek.ToString(),fntHeader,Brushes.Blue,385,p_intStartY);
		}
		/// <summary>
		/// 打印页数
		/// </summary>
		/// <param name="p_intStartY"></param>
		/// <param name="e"></param>
		/// <param name="p_intPageNum"></param>
		/// <param name="p_blnIsAppend"></param>
		private void m_mthPrintPageNum(int p_intStartY,System.Drawing.Printing.PrintPageEventArgs e,int p_intPageNum,bool p_blnIsAppend)
		{		
			Font fntHeader = new Font("SimSun", 9);

			//			if(!p_blnIsAppend)
			//				e.Graphics.DrawString("第    页",fntHeader,Brushes.Black,650,p_intStartY);
			//			else
			//				e.Graphics.DrawString("第    页附页",fntHeader,Brushes.Black,650,p_intStartY);
			//			e.Graphics.DrawString(p_intPageNum.ToString(),fntHeader,Brushes.Blue,675,p_intStartY);
		}

		#endregion

		#region 在外部测试本打印的演示实例.	
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
			m_mthPrintPage(e);
			//
			//			if(ppdPrintPreview != null)
			//				while(!ppdPrintPreview.m_blnHandlePrint(e))
			//					objPrintTool.m_mthPrintPage(e);
			//		}
			//			m_mthAddDataToGrid(e);
		}
		private void frmPreview_m_evtPrintFrame(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//			m_mthPrintTitleInfo(e);	
			//			m_mthPrintRectangleInfo(e);	
			//			m_mthPrintHeaderInfo(e);
		}
		#endregion
	
		#endregion 在外部测试本打印的演示实例.
	}
}
