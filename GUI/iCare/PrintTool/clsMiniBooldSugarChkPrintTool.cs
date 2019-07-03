using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 快速微量血糖检测记录表打印工具
	/// </summary>
	public class clsMiniBooldSugarChkPrintTool : infPrintRecord
	{
		public clsMiniBooldSugarChkPrintTool()
		{
			
		}
		private clsMiniBooldSugarChkDomin m_objDomain;
		private clsPatient m_objPatient;
		private clsMiniBloodSugarChkValue[] m_objValues;
		
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{	
			m_objPatient=p_objPatient;
		}
		public void m_mthSetPrintInfo(clsPatient p_objPatient)
		 {	
			 m_objPatient=p_objPatient;
		 }

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{		
			if(m_objPatient==null)
			{
//				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPatient.m_StrInPatientID=="" || m_objPatient.m_DtmSelectedInDate==DateTime.MinValue)
				m_objValues=null;				
			else
			{
				m_objDomain=new clsMiniBooldSugarChkDomin();
				long lngRes=m_objDomain.m_lngGetRecoedByInPatient(m_objPatient.m_StrInPatientID,m_objPatient.m_DtmSelectedInDate,out m_objValues );
				if(lngRes <= 0 || m_objValues == null)
					return ;  
			}
			//设置表单内容到打印中			
           // m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{}

		/// <summary>
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{
            return m_objValues;
            
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			#region 有关打印初始化
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);

			#endregion
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont .Dispose();
			m_GridPen .Dispose();
			m_slbBrush .Dispose();
		}

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{}

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
		public void m_mthPrintPage()
		{
			frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
			frmPreview.m_evtBeginPrint +=new PrintEventHandler(frmPreview_m_evtBeginPrint);
			frmPreview.m_evtEndPrint +=new PrintEventHandler(frmPreview_m_evtEndPrint);
			frmPreview.m_evtPrintContent +=new PrintPageEventHandler(frmPreview_m_evtPrintContent);
			frmPreview.m_evtPrintFrame +=new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
			frmPreview.ShowDialog();
		}
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
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
		}
		#endregion

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
			m_intLines = 0;
			m_intPages = 1;
		}

		// 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
            try
            {
                p_objPrintPageArg.HasMorePages = false;
                m_mthPrintTitleInfo(p_objPrintPageArg);
                m_mthAddDataToGrid(p_objPrintPageArg);
                m_mthPrintRectangleInfo(p_objPrintPageArg);
                
            }
            catch (Exception err)
            {
                MDIParent.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
        }

		#region 打印

		#region 有关打印的声明
			
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

		private int m_intPages = 1;
		private int m_intLines=0;
		private int m_intLineStep = 135;
		private string m_strDateFormat = "yyyy年MM月dd日 HH时mm分ss秒";

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRectangleInfo
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
			RowStep = 25,

			BottomY=1024		
		}
		
		
		#endregion
				
		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, 320,30);
			e.Graphics.DrawString("快速微量血糖检测记录表",m_fotTitleFont,m_slbBrush,240,70);
			
			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+50,120,(int)enmRectangleInfo.LeftX+120,120);
            e.Graphics.DrawString((m_objPatient == null ? "" : m_objPatient.m_ObjPeopleInfo.m_StrFirstName), m_fotSmallFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 45, 120);

			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+125,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+165,120,(int)enmRectangleInfo.LeftX+185,120);
            e.Graphics.DrawString((m_objPatient == null ? "" : m_objPatient.m_ObjPeopleInfo.m_StrSex), m_fotSmallFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 165, 120);
						
			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+200,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+230,120,(int)enmRectangleInfo.LeftX+275,120);
			e.Graphics.DrawString((m_objPatient == null?"":m_objPatient.m_ObjPeopleInfo.m_StrAge) ,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+240,120);
	
            //e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+270,100);
            //e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+315,120,(int)enmRectangleInfo.LeftX+385,120);
            //e.Graphics.DrawString((m_objPatient == null?"":m_objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName.Trim()) ,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+315,100);

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+335,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+430,120,(int)enmRectangleInfo.LeftX+450,120);
            e.Graphics.DrawString((m_objPatient == null ? "" : m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(m_objPatient.m_DtmSelectedInDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName), m_fotSmallFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 375, 120);
						
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+605,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+560,120,(int)enmRectangleInfo.LeftX+640,120);
			e.Graphics.DrawString((m_objPatient == null?"":m_objPatient.m_StrInPatientID.Trim()) ,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+665,120);
	
			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+525,120);
			//e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+695,120,(int)enmRectangleInfo.LeftX+740,120);
			string strTemp;
			try
			{
				 strTemp=m_objPatient == null?"":m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName.ToString().Trim();
			}
			catch
			{
			strTemp="";
			}
			e.Graphics.DrawString(strTemp,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+565,120);
		}
		
	
		#endregion		

		private void m_mthPrintRectangleInfo(PrintPageEventArgs e)
		{
			int intYPos = 145;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,intYPos,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.BottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,intYPos,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.BottomY);

			int intXPos = 200;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+intXPos,intYPos,(int)enmRectangleInfo.LeftX+intXPos,(int)enmRectangleInfo.BottomY);
			e.Graphics.DrawString("     日    期",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX,148);
			e.Graphics.DrawString("早餐前(mmol/L)",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+intXPos+1,148);
			intXPos += m_intLineStep;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+intXPos,intYPos,(int)enmRectangleInfo.LeftX+intXPos,(int)enmRectangleInfo.BottomY);
			e.Graphics.DrawString("中餐前(mmol/L)",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+intXPos+1,148);
			intXPos += m_intLineStep;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+intXPos,intYPos,(int)enmRectangleInfo.LeftX+intXPos,(int)enmRectangleInfo.BottomY);
			e.Graphics.DrawString("晚餐前(mmol/L)",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+intXPos+1,148);
			intXPos += m_intLineStep;
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX+intXPos,intYPos,(int)enmRectangleInfo.LeftX+intXPos,(int)enmRectangleInfo.BottomY);
			e.Graphics.DrawString("临睡前(mmol/L)",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+intXPos+1,148);
			
			for(int i=0;i<37;i++)
			{
				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,intYPos,(int)enmRectangleInfo.RightX,intYPos);
				intYPos += (int)enmRectangleInfo.RowStep;
			}
			e.Graphics.DrawString("第 "+m_intPages.ToString()+" 页",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+600,intYPos+30);
		}
		private void m_mthAddDataToGrid(PrintPageEventArgs e)
		{
			if(m_objValues == null)
			{
				e.HasMorePages = false;
				return;
			}
			int intYPos = 172;
			for(;m_intLines <m_objValues.Length;)
			{
				e.Graphics.DrawString(m_objValues[m_intLines].m_dtmCreatedDate.ToString(m_strDateFormat),new Font("SimSun",10),m_slbBrush,(int)enmRectangleInfo.LeftX,intYPos);
				e.Graphics.DrawString(m_objValues[m_intLines].m_strBreakfast,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+201,intYPos);
				e.Graphics.DrawString(m_objValues[m_intLines].m_strLunch,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+336,intYPos);
				e.Graphics.DrawString(m_objValues[m_intLines].m_strSupper,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+471,intYPos);
				e.Graphics.DrawString(m_objValues[m_intLines].m_strPreRest,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+606,intYPos);
				intYPos += (int)enmRectangleInfo.RowStep;
				m_intLines++;
				if(m_intLines%35 == 0)
				{
					m_intPages++;
					e.HasMorePages = true;
					return;
				}
			}
			e.HasMorePages = false;
		}

		#endregion
	}
}
