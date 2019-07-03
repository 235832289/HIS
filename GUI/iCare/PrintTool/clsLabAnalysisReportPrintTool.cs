using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing;

using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// Summary description for clsLabAnalysisReportPrintTool.
	/// </summary>
	public class clsLabAnalysisReportPrintTool //: infPrintRecord
	{
		
		private clsPrintInfo_LabAnalysisReport m_objPrintInfo;

		public clsLabAnalysisReportPrintTool()
		{
			m_objPrintInfo = new clsPrintInfo_LabAnalysisReport();
		}

		#region Interface Function Impletement
		public void m_mthBeginPrint(object p_objPrintArg)
		{

		}

		public void m_mthDisposePrintTools(object p_objArg)
		{
		
		}

		public void m_mthEndPrint(object p_objPrintArg)
		{
		
		}

		public void m_mthInitPrintContent()
		{
			
			
			if(m_objPrintInfo.m_strBarCode == "")
				m_objPrintInfo.m_objJY_BRZL = null;				
			else
			{
				clsLabAnalysisOrderDomain objLabAnalysisReportDomain = new clsLabAnalysisOrderDomain();
				
				
				long lngRes = objLabAnalysisReportDomain.m_lngGetReportInfomation(m_objPrintInfo.m_strBarCode
																				,out m_objPrintInfo.m_objJY_BRZL
																				,out m_objPrintInfo.m_objJY_JGArr
																				,out m_objPrintInfo.m_objJY_QXArr
																				,out m_objPrintInfo.m_objJY_DYArr);
				if(lngRes <= 0)
					return ;   
			}
		}

		public void m_mthInitPrintTool(object p_objArg)
		{
		
		}

		public void m_mthPrintPage(object p_objPrintArg)
		{
			PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

			e.HasMorePages =false;

			m_mthPrintHeader(e);

			m_mthPrintDetail(e);

			m_mthPrintFooter(e);
		}

		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			m_objPrintInfo = (clsPrintInfo_LabAnalysisReport)p_objPrintContent;
			
		}

		public void m_mthSetPrintInfo(string p_strBarCode)
		{
			if(p_strBarCode != null && p_strBarCode != "")
				m_objPrintInfo.m_strBarCode = p_strBarCode;



		}

		public object m_objGetPrintInfo()
		{
			return null;
		}
		#endregion


		#region Private Function
		/// <summary>
		/// 打印表头
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		private void m_mthPrintHeader(PrintPageEventArgs e)
		{
			Font fntTitle = new Font("SimSun", 18,FontStyle.Bold );
			Font fntPrintDate = new Font("SimSun", 10);
			Font fntText = new Font("SimSun", 12);

			Font fntBarCode = new System.Drawing.Font("3 of 9 Barcode", 18f, FontStyle.Regular);//, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

			//不显示BarCode
//			string strBarCode = "";
//			if(m_objPrintInfo.m_strBarCode != null && m_objPrintInfo.m_strBarCode != "") 
//			{
//				strBarCode = "*" + m_objPrintInfo.m_strBarCode + "*";
//				e.Graphics.DrawString(strBarCode,fntBarCode ,Brushes.Black,40 , 30);
//			}

			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle+"检验报告单",fntTitle,Brushes.Black,230,30);

			e.Graphics.DrawString(((m_objPrintInfo.m_objJY_BRZL == null) ? "" : ("("+m_objPrintInfo.m_objJY_BRZL.m_strPat_c_name+")")),fntText,Brushes.Black,360,60);
			e.Graphics.DrawString("打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),fntPrintDate,Brushes.Black,530,60);

			e.Graphics.DrawString("姓名：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_name)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY);

			e.Graphics.DrawString("性别：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_sex)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 200,(int)enmRectangleInfo.TopY);

			e.Graphics.DrawString("年　龄：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_age)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 400,(int)enmRectangleInfo.TopY);

			e.Graphics.DrawString("样本号：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_sid)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 600,(int)enmRectangleInfo.TopY);

			e.Graphics.DrawString("科别：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_d_name)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX ,(int)enmRectangleInfo.TopY + 30);

			e.Graphics.DrawString("床号：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_bed_no)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 200,(int)enmRectangleInfo.TopY + 30);

			e.Graphics.DrawString("病历号："+ ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_in_no)) ,fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 400,(int)enmRectangleInfo.TopY + 30);

			e.Graphics.DrawString("送检者：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_doct)) ,fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 600,(int)enmRectangleInfo.TopY + 30);

			e.Graphics.DrawString("检验者：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_I_name)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX ,(int)enmRectangleInfo.TopY + 60);

			e.Graphics.DrawString("诊断：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_diag)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 200,(int)enmRectangleInfo.TopY + 60);

			e.Graphics.DrawString("审核者：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_chk)),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 600,(int)enmRectangleInfo.TopY + 60);


			m_mthPrintOneHorizontalLine(e, (int)enmRectangleInfo.TopY + 80);

			e.Graphics.DrawString(((m_objPrintInfo.m_objJY_BRZL == null) ? "项　目" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_c_name)), fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 50,(int)enmRectangleInfo.TopY + 90);
			e.Graphics.DrawString("结  果", fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 280,(int)enmRectangleInfo.TopY + 90);
			e.Graphics.DrawString("单  位", fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 450,(int)enmRectangleInfo.TopY + 90);
			e.Graphics.DrawString("参 考 值", fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 560,(int)enmRectangleInfo.TopY + 90);

			m_mthPrintOneHorizontalLine(e,(int)enmRectangleInfo.TopY + 110);

			e.Graphics.DrawString("标本类别：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_strPat_s_name)), fntText, Brushes.Black,(int)enmRectangleInfo.LeftX ,(int)enmRectangleInfo.TopY + 120);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintDetail(PrintPageEventArgs e)
		{
			Font fntText = new Font("SimSun", 12);

			if(m_objPrintInfo.m_objJY_JGArr == null || m_objPrintInfo.m_objJY_JGArr.Length == 0)
				return ;

			int intYPos = (int)enmRectangleInfo.TopY + 150;

			for(int i = 0; i < m_objPrintInfo.m_objJY_JGArr.Length; i++)
			{
				if(m_objPrintInfo.m_objJY_JGArr[i] == null)
					continue;

				e.Graphics.DrawString(m_objPrintInfo.m_objJY_JGArr[i].m_strRes_name + "  (" + m_objPrintInfo.m_objJY_JGArr[i].m_strRes_it_ecd + ")", fntText, Brushes.Black,(int)enmRectangleInfo.LeftX ,intYPos);
				e.Graphics.DrawString(m_objPrintInfo.m_objJY_JGArr[i].m_strRes_exp + " "+ m_objPrintInfo.m_objJY_JGArr[i].m_strRes_chr+ " "+ m_objPrintInfo.m_objJY_JGArr[i].m_strRes_chr1, fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 250,intYPos);
				//e.Graphics.DrawString(m_objPrintInfo.m_objJY_JGArr[i].m_strRes_chr, fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 280,intYPos);
				e.Graphics.DrawString(m_objPrintInfo.m_objJY_JGArr[i].m_strRes_unit, fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 450,intYPos);
				e.Graphics.DrawString(m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref1 
					+ (m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref2.Trim()==""? "": " - " + m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref2) 
					+ (m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref3.Trim()==""? "": " - " + m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref3)
					+ (m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref4.Trim()==""? "": " - " + m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref4) , fntText, Brushes.Black,(int)enmRectangleInfo.LeftX + 560,intYPos);

				intYPos += 30;

				//换页
				if(intYPos >= e.PageBounds.Bottom - 60 && i < m_objPrintInfo.m_objJY_JGArr.Length)
				{
					e.HasMorePages = true;
					m_mthPrintHeader(e);

					intYPos = (int)enmRectangleInfo.TopY + 150;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFooter(PrintPageEventArgs e)
		{
			Font fntText = new Font("SimSun", 12);

			m_mthPrintOneHorizontalLine(e, e.PageBounds.Bottom - 60);//m_objPrintInfo.m_objJY_JGArr[i].m_strRes_ref1

			e.Graphics.DrawString("送检日期：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_dtmPat_sdate).ToString("yyyy-MM-dd")),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX, e.PageBounds.Bottom - 50);
			e.Graphics.DrawString("送检时间：" + ((m_objPrintInfo.m_objJY_BRZL == null) ? "" : (m_objPrintInfo.m_objJY_BRZL.m_dtmPat_sdate).ToString("HH:mm:ss")),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 200, e.PageBounds.Bottom - 50);
			e.Graphics.DrawString("报告日期：" + ((m_objPrintInfo.m_objJY_JGArr == null || m_objPrintInfo.m_objJY_JGArr.Length==0 || m_objPrintInfo.m_objJY_JGArr[0]==null) ? "" : (m_objPrintInfo.m_objJY_JGArr[0].m_dtmRes_date).ToString("yyyy-MM-dd"))  ,fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 400, e.PageBounds.Bottom - 50);
			e.Graphics.DrawString("报告时间：" + ((m_objPrintInfo.m_objJY_JGArr == null || m_objPrintInfo.m_objJY_JGArr.Length==0 || m_objPrintInfo.m_objJY_JGArr[0]==null) ? "" : (m_objPrintInfo.m_objJY_JGArr[0].m_dtmRes_date).ToString("HH:mm:ss")),fntText,Brushes.Black,(int)enmRectangleInfo.LeftX + 600,e.PageBounds.Bottom - 50);
		}


		/// <summary>
		/// 打印一条水平线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		private void m_mthPrintOneHorizontalLine(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{	
			Pen LinePen = new Pen(Color.Black);

			e.Graphics.DrawLine(LinePen,(int)enmRectangleInfo.LeftX ,
				p_intBottomY,
				(int)enmRectangleInfo.RightX,
				p_intBottomY);			
		}
		#endregion

//		#region 枚举和类
//		/// <summary>
//		/// 格子的信息
//		/// </summary>
//		public enum enmRectangleInfo
//		{
//			/// <summary>
//			/// 格子的顶端
//			/// </summary>
//			TopY = 100,
//			///<summary>
//			/// 格子的左端
//			/// </summary>
//			LeftX = 40,
//			/// <summary>
//			/// 格子的右端
//			/// </summary>
//			RightX = 820-40,
//			/// <summary>
//			/// 格子每行的步长
//			/// </summary>
//			RowStep = 20,
//			SmallRowStep=20,			
//
//			ColumnsMark1=110,			
//
//			/// <summary>
//			/// 底划线偏移文本顶点的距离
//			/// </summary>
//			BottomLineShift=15,
//
//			BottomY=1024		
//		}
//
//
//		[Serializable]
//		/// <summary>
//		/// 
//		/// </summary>
//		private class clsPrintInfo_LabAnalysisReport
//		{
////			public string m_strInPatentID;			
////			public string m_strPatientName;
////			public string m_strSex;
////			public string m_strAge;
////			public string m_strBedName;
////			public string m_strDeptName;
////			public string m_strAreaName;
//
//			public string m_strBarCode;
//
//			public clsJY_BRZL m_objJY_BRZL;
//			public clsJY_JG[] m_objJY_JGArr;
//			public clsJY_QXJG[] m_objJY_QXArr;
//			public clsJY_DYJG[] m_objJY_DYArr;
//		}
//		#endregion
	}
}
