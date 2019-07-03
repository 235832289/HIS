using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsLisApplyReportPrint 的摘要说明。
	/// </summary>
	public class clsMarrowReportPrintTool:infPrintRecord
	{
		#region inital

		private Font m_fntTitle;
		private Font m_fntSmallBold;
		private Font m_fntSmallNotBold;
		private Font m_fntSmall2NotBold;
		private Font m_fntMiddleNotBold;
		private Font m_fntSmallBold2;

		//边框画笔
		private Pen m_GridPen;

		float m_fltPrintWidth;      //打印的宽度
		float m_fltPrintHeight;     //打印的高度

		long m_lngTitleTop = 30;    //打印标题的高度
		long m_lngY;                //打印时的高度定位
		long m_lngVerticalLineStart; //竖线打印的起始位置
		long m_lngVerticalLineEnd;   //竖线打印的结束位置
				
		string m_stName;//姓名
		string m_strTitle;//标题
		string m_strSex; //性别
		string m_strAge ; //年龄
		string m_strOpenItemNO ; //住院号
		string m_strDepName ; //科别	
		string m_strCheckOut; //临床诊断
		string m_strComeFrom; //骨髓来源
		string m_strSuggest; //意见
		string m_strChecker; //检验者
		string m_strYear2 ; //回报年
		string m_strMonth2; //回报月
		string m_strDay2 ; //回报日

		string m_strbedno ; //床号
		string m_strSAMPLE_TYPE_DESC; //样本类型
		string m_strapplication_id ; //申请单号
		string m_strcheck_no ; //检验编号
		string m_strapplyer; //送检医生
		string m_straccept_dat; //送检时间

	
		string[]  m_strBloodArr = new string[55];	//血片	
		string[] m_streFrangeArr= new string[55];  //正常范围
		string[] m_streNarrowArr= new string[55];  //髓片
		string[] m_streUNIT= new string[55];  //单位
        /// <summary>
        /// 是否打印诊断
        /// </summary>
        public static bool blnSurePrintDiagnose = false;
		#endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsMarrowReportPrintTool()
        {
            //if (p_strParmValue == "1")
            //{
            //    blnSurePrintDiagnose = true;

            //}
            //else
            //{
            //    blnSurePrintDiagnose = false;
            //}
        }
        #endregion

        #region 打印报告的标题及基本信息
        private void m_mthPrintReportTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
		{
			//报告的标题
			m_lngY = m_lngTitleTop;
			if(m_fltPrintWidth == 0)
				m_fltPrintWidth = p_objPrintArgs.PageBounds.Width*0.8f;
			SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle,m_fntTitle);
			float fltCurrentX = (p_objPrintArgs.PageBounds.Width-sfTitle.Width)/2;
			p_objPrintArgs.Graphics.DrawString(m_strTitle,m_fntTitle,Brushes.Black,fltCurrentX,m_lngY);
			
			//底端的Y坐标
			m_lngY += (long)sfTitle.Height+25;
		}


		#endregion

		#region 打印报告单的左边信息
		public void m_mthPrintReportLeft(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			m_lngVerticalLineStart = m_lngY;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngVerticalLineStart,m_fltPrintWidth*0.04f,m_lngVerticalLineStart+m_fltPrintHeight*0.854f);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngVerticalLineStart,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngVerticalLineStart+m_fltPrintHeight*0.854f);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.182f,m_lngVerticalLineStart,p_objPrintPageArgs.PageBounds.Width*0.182f,m_lngVerticalLineStart+m_fltPrintHeight*0.788f);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.245f,m_lngVerticalLineStart,p_objPrintPageArgs.PageBounds.Width*0.245f,m_lngVerticalLineStart+m_fltPrintHeight*0.854f);
			float fltCurrentX = m_fltPrintWidth*0.04f;
			m_lngY += 4;
			fltCurrentX += 8;
			SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("细 胞名 称",m_fntSmallNotBold);

			//细胞名称  血片 髓片
			p_objPrintPageArgs.Graphics.DrawString("细 胞 名 称",m_fntSmallNotBold,Brushes.Black,fltCurrentX+10,m_lngY+10);
			p_objPrintPageArgs.Graphics.DrawString("血  片",m_fntSmallNotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("髓       片",m_fntSmallNotBold,Brushes.Black,fltCurrentX+200,m_lngY);
			
			//-----------------------
			m_lngY += (long)sfWords.Height+2;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.182f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.4f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.4f,m_lngY+m_fltPrintHeight*0.833f);
			
			//正常范围
			p_objPrintPageArgs.Graphics.DrawString("正常范围",m_fntSmallNotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.280f,m_lngY+6);

			//-------------------------
			m_lngY += (long)sfWords.Height+8;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);


			//原 始 血 细 胞
			m_lngY +=+4;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("原 始 血 细 胞",m_fntSmall2NotBold);
			p_objPrintPageArgs.Graphics.DrawString("原 始 血 细 胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[1],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[1],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[1],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[1],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,m_fltPrintWidth*0.086f,m_lngY+m_fltPrintHeight*0.700f);

			//原 始 粒 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("始",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("粒",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("粒",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+38);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+38*2);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+38*3);
			p_objPrintPageArgs.Graphics.DrawString("系",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+38*4);
			p_objPrintPageArgs.Graphics.DrawString("统",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+38*5);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[2],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[2],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[2],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[2],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			
			//早 幼 粒 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("早",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("粒",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[3],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[3],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[3],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[3],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,m_fltPrintWidth*0.142f,m_lngY+m_fltPrintHeight*0.195f);
		
			//中  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("中  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[4],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[4],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[4],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[4],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("中  性",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+20);
			p_objPrintPageArgs.Graphics.DrawString("料细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+40);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//晚  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("晚  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[5],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[5],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[5],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[5],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
		
			//杆状核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("杆状核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[6],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[6],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[6],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[6],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//分叶核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("分叶核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[7],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[7],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[7],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[7],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//中  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("中  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[8],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[8],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[8],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[8],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("嗜  酸",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+20);
			p_objPrintPageArgs.Graphics.DrawString("料细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+40);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//晚  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("晚  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[9],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[9],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[9],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[9],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
		
			//杆状核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("杆状核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[10],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[10],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[10],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[10],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//分叶核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("分叶核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[11],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[11],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[11],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[11],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//中  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("中  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[12],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[12],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[12],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[12],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("嗜  硷",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+20);
			p_objPrintPageArgs.Graphics.DrawString("料细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+27,m_lngY+40);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//晚  幼	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("晚  幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[13],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[13],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[13],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[13],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
		
			//杆状核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("杆状核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[14],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[14],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[14],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[14],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.142f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//分叶核	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("分叶核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+71,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[15],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[15],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[15],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[15],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//原 始 红 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("始",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[16],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[16],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[16],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[16],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+18);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+18*2);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+18*3);
			p_objPrintPageArgs.Graphics.DrawString("系",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+18*4);
			p_objPrintPageArgs.Graphics.DrawString("统",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+18*5);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//早 幼 红 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("早",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[17],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[17],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[17],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[17],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//中 幼 红 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("中",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[18],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[18],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[18],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[18],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//晚 幼 红 细 胞		
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("晚",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[19],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[19],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[19],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[19],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//早 巨 红 细 胞		
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("早",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("巨",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[20],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[20],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[20],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[20],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//中 巨 红 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("中",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("巨",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[21],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[21],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[21],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[21],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//晚 巨 红 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("晚",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("巨",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("红",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[22],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[22],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[22],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[22],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);


			//原始淋巴细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原始淋巴细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[23],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[23],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[23],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[23],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("淋胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+1);
			p_objPrintPageArgs.Graphics.DrawString("巴系",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+17);
			p_objPrintPageArgs.Graphics.DrawString("细统",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+32);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//幼稚淋巴细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("幼稚淋巴细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[24],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[24],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[24],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[24],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//淋 巴 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("淋",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("巴",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[25],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[25],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[25],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[25],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//原始单核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原始单核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[26],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[26],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[26],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[26],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("单胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+2);
			p_objPrintPageArgs.Graphics.DrawString("核系",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+19);
			p_objPrintPageArgs.Graphics.DrawString("细统",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+35);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//幼稚单核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("幼稚单核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[27],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[27],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[27],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[27],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//单 核 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("单",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[28],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[28],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[28],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[28],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			
			//原 始 浆 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("始",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("浆",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[29],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[29],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[29],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[29],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("浆系",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+2);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+19);
			p_objPrintPageArgs.Graphics.DrawString("胞统",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-5,m_lngY+35);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//幼 稚 浆 细 胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("幼",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("稚",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+47,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("浆",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+63,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+79,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[30],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[30],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[30],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[30],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//浆  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("浆   细   胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[31],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[31],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[31],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[31],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//网  状  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("网",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("状",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[32],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[32],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[32],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[32],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			
			p_objPrintPageArgs.Graphics.DrawString("其",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+22);
			p_objPrintPageArgs.Graphics.DrawString("他",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+22*2);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+22*3);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+22*4);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//内  皮  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("内",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("皮",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[33],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[33],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[33],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[33],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//巨  核  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("巨",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[34],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[34],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[34],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[34],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//吞  噬  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("吞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("噬",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[35],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[35],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[35],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[35],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//组织嗜硷细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("组织嗜硷细胞	",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[36],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[36],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[36],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[36],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//组织嗜酸细胞		
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("组织嗜酸细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[37],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[37],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[37],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[37],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//脂  肪  细  胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("脂",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("肪",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+52,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+74,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+95,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[38],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[38],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[38],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[38],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//分类不明细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("分类不明细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[39],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[39],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[39],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[39],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//原始巨核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("原始巨核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[40],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[40],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[40],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[40],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			p_objPrintPageArgs.Graphics.DrawString("巨",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+10);
			p_objPrintPageArgs.Graphics.DrawString("核",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+14*2);
			p_objPrintPageArgs.Graphics.DrawString("细",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+14*3);
			p_objPrintPageArgs.Graphics.DrawString("胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX-1,m_lngY+14*4);
			

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//幼稚巨核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("幼稚巨核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[41],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[41],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[41],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[41],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//颗粒巨核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("颗粒巨核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[42],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[42],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[42],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[42],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//产板巨核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("产板巨核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[43],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[43],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[43],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[43],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.086f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//裸核巨核细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("裸核巨核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX+31,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[44],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[44],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[44],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[44],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);
			

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			
			
			//分裂细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("分裂细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[45],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[45],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[45],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[45],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);
			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//退化细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("退化细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strBloodArr[46],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+116,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[46],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[46],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[46],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,p_objPrintPageArgs.PageBounds.Width*0.4f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.4f,m_lngY+18);
		
			//粒细胞系统:有核红细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("粒细胞系统:有核红细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[47],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[47],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[47],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);
			
			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//血片共数白细胞	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("血片共数白细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[48],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[48],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[48],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//骨髓片共数有核细胞
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("骨髓片共数有核细胞",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[49],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[49],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[49],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);

			//骨髓有胲细胞总数	
			m_lngY +=+4;
			p_objPrintPageArgs.Graphics.DrawString("骨髓有胲细胞总数",m_fntSmall2NotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streFrangeArr[50],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.230f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streUNIT[50],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.333f,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_streNarrowArr[50],m_fntSmall2NotBold,Brushes.Black,fltCurrentX+m_fltPrintWidth*0.40f,m_lngY);

			//------------------------	
			m_lngY += (long)sfWords.Height;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.04f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.47f,m_lngY);
		


		}
		#endregion

		#region 打印报告单底部信息
		private void m_mthPrintReportBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			long lngY = m_lngVerticalLineStart+950;
			float fltCurrentX = m_fltPrintWidth*0.71f;

			//检 验 者
			SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("检 验 者 ",m_fntMiddleNotBold);
			p_objPrintPageArgs.Graphics.DrawString("检 验 者",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strChecker,m_fntSmallNotBold,Brushes.Black,fltCurrentX+65,lngY);
			//下画线
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,fltCurrentX+60,lngY+sfWords.Height-3,fltCurrentX+220,lngY+sfWords.Height-3);
			
			//回报取日期
			lngY +=30;
			p_objPrintPageArgs.Graphics.DrawString("回报日期       年     月     日",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strYear2,m_fntSmallNotBold,Brushes.Black,fltCurrentX+65,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strMonth2,m_fntSmallNotBold,Brushes.Black,fltCurrentX+128,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strDay2,m_fntSmallNotBold,Brushes.Black,fltCurrentX+178,lngY);
			//下画线
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,fltCurrentX+58,lngY+sfWords.Height-3,fltCurrentX+108,lngY+sfWords.Height-3);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,fltCurrentX+123,lngY+sfWords.Height-3,fltCurrentX+153,lngY+sfWords.Height-3);
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,fltCurrentX+169,lngY+sfWords.Height-3,fltCurrentX+200,lngY+sfWords.Height-3);

			
		}
		#endregion

		#region 打印报告单右边信息
		private void m_mthPrintReportRight(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			float lngY = m_lngVerticalLineStart;
			float fltCurrentX = m_fltPrintWidth*0.56f;
			//姓名
			SizeF	sfWords = p_objPrintPageArgs.Graphics.MeasureString("姓名xx",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("姓名:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);						
			p_objPrintPageArgs.Graphics.DrawString(m_stName,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
						
					
			//性别
					
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("性别:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strSex,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			
			//年龄
						
			lngY+= sfWords.Height+10;
			
			p_objPrintPageArgs.Graphics.DrawString("年龄:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strAge,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
						
			//科区
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("科区:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strDepName,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
						
			//床号
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("床号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strbedno,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
						
			//样本类型
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("样本类型:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strSAMPLE_TYPE_DESC,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width+20,lngY);

            if (blnSurePrintDiagnose)
            {
                //临床诊断
                lngY += sfWords.Height + 10;
                p_objPrintPageArgs.Graphics.DrawString("临床诊断:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, lngY);
                p_objPrintPageArgs.Graphics.DrawString(m_strCheckOut, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width + 20, lngY);
            }

				
			//意见
			lngY+= sfWords.Height+10;
			
			p_objPrintPageArgs.Graphics.DrawString("特征和意见:",m_fntSmallBold2,Brushes.Black,fltCurrentX-10,lngY);
			Rectangle rect=new Rectangle(420,310,370,710);
			p_objPrintPageArgs.Graphics.DrawString(m_strSuggest,m_fntMiddleNotBold,Brushes.Black,rect);

			//右边
			lngY = m_lngVerticalLineStart;
			fltCurrentX = m_fltPrintWidth*0.77f;
			//住院号	
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("住 院 号:d",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("住 院 号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);		
			p_objPrintPageArgs.Graphics.DrawString(m_strOpenItemNO,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			//申请单号	
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("申请单号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);		
			p_objPrintPageArgs.Graphics.DrawString(m_strapplication_id,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			//检验编号	
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("检验编号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);		
			p_objPrintPageArgs.Graphics.DrawString(m_strcheck_no,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			//送检医生	
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("送检医生:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);		
			p_objPrintPageArgs.Graphics.DrawString(m_strapplyer,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			//送检时间	
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("送检时间:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);		
			p_objPrintPageArgs.Graphics.DrawString(m_straccept_dat,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,lngY);
			//取材部位
			lngY+= sfWords.Height+10;
			p_objPrintPageArgs.Graphics.DrawString("取材部位:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strComeFrom,m_fntSmallNotBold,Brushes.Black,fltCurrentX+70,lngY);
						
		}
		#endregion

		#region infPrintRecord 成员

		public void m_mthInitPrintContent()
		{
			// TODO:  添加 clsLisApplyReportPrint.m_mthInitPrintContent 实现
		}

		/// <summary>
		/// 初始化打印变量
		/// </summary>
		/// <param name="p_objArg"></param>
		public void m_mthInitPrintTool(object p_objArg)
		{
			m_fntTitle= new Font("楷体_GB2312", 20,FontStyle.Bold);
			m_fntSmallBold= new Font("楷体_GB2312",14,FontStyle.Bold);
			m_fntSmallBold2= new Font("SimSun",11,FontStyle.Bold);
			m_fntSmallNotBold=new Font("SimSun",10f,FontStyle.Regular);
			m_fntSmall2NotBold=new Font("SimSun",9f,FontStyle.Regular);
			m_fntMiddleNotBold = new Font("SimSun",11f,FontStyle.Regular);

			m_GridPen = new Pen(Color.Black,1);

			#region 打印设置
			try
			{
//				PaperSize ps = null;//new PaperSize("GSReport",740,1024);
//				foreach(PaperSize objPs in ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.PaperSizes)
//				{
//					if(objPs.PaperName == "LIS_Apply_Report")
//					{
//						ps = objPs;
//						break;
//					}
//				}
//				if(ps != null)
//				{
//				ps = ((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.PaperSize;
				m_fltPrintWidth = ((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.Bounds.Width*0.9f;
				m_fltPrintHeight = ((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.Bounds.Height;
//				}
			}
			catch
			{
				MessageBox.Show("打印机故障！","iCare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}	
			#endregion
		}

		public void m_mthDisposePrintTools(object p_objArg)
		{
			// TODO:  添加 clsLisApplyReportPrint.m_mthDisposePrintTools 实现
		}

		public void m_mthBeginPrint(object p_objPrintArg)
		{
			// TODO:  添加 clsLisApplyReportPrint.m_mthBeginPrint 实现
			clsPrintValuePara objPrintInfo = (clsPrintValuePara)p_objPrintArg;
			m_mthFillData(objPrintInfo.m_dtbBaseInfo,objPrintInfo.m_dtbResult);
		}

		public void m_mthPrintPage(object p_objPrintArg)
		{
//			DataTable  p_dtRpt = new DataTable();
//			m_mthFilData(p_dtRpt);
			m_mthPrintReportTop((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportLeft((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportBotton((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportRight((PrintPageEventArgs)p_objPrintArg);
		}

		public void m_mthEndPrint(object p_dtBaseDate)
		{
			// TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
		}

		#endregion

		#region  填充数据
		public void m_mthFillData( DataTable p_dtBaseDate , DataTable p_DatDetail)
		{

			#region 基本资料
			System.DateTime m_dtSAMPLING ;//送检时间
			System.DateTime m_CONFIRM_DAT ;//标本采样时间

			 m_dtSAMPLING = Convert.ToDateTime(p_dtBaseDate.Rows[0]["accept_dat"].ToString());
		     m_CONFIRM_DAT = Convert.ToDateTime(p_dtBaseDate.Rows[0]["CONFIRM_DAT"].ToString());
			
			 m_strbedno =p_dtBaseDate.Rows[0]["bedno_chr"].ToString() ; //床号
			 m_strSAMPLE_TYPE_DESC =p_dtBaseDate.Rows[0]["SAMPLE_TYPE_DESC_VCHR"].ToString(); //样本类型
			 m_strapplication_id =p_dtBaseDate.Rows[0]["application_id_chr"].ToString().Substring(10,8); //申请单号
			
			 m_strcheck_no =p_dtBaseDate.Rows[0]["check_no_chr"].ToString(); //检验编号
			 m_strapplyer=p_dtBaseDate.Rows[0]["applyer"].ToString(); //送检医生
			 m_straccept_dat=m_dtSAMPLING.ToShortDateString();//送检时间

             m_strTitle = p_dtBaseDate.Rows[0]["print_title_vchr"].ToString(); //标题
             //if (p_dtBaseDate.Rows[0]["report_print_chr"] != System.DBNull.Value)
             //{
             //    string strTime = p_dtBaseDate.Rows[0]["report_print_chr"].ToString().Trim();
             //    int intTime = 0;
             //    try
             //    {
             //        intTime = Convert.ToInt32(strTime);
             //        if (intTime > 0)
             //        {
             //            m_strTitle = p_dtBaseDate.Rows[0]["print_title_vchr"].ToString() + "(重打)";
             //        }
             //    }
             //    catch
             //    { }
             //}
			 m_stName = p_dtBaseDate.Rows[0]["patient_name_vchr"].ToString();//姓名
			 m_strSex =p_dtBaseDate.Rows[0]["sex_chr"].ToString(); //性别
			 m_strAge  =p_dtBaseDate.Rows[0]["age_chr"].ToString() ; //年龄
			 m_strOpenItemNO = p_dtBaseDate.Rows[0]["PATIENT_INHOSPITALNO_CHR"].ToString(); //住院号
			// m_strDarItemNO = "";// p_dtBaseDate.Rows[0]["PATIENT_INHOSPITALNO_CHR"].ToString();//门诊号
			 //m_strApplicationNO = ""; //血液室号
			 //m_strhospinalName  = ""; //院别
			 m_strDepName  = p_dtBaseDate.Rows[0]["deptname_vchr"].ToString(); //科别
			 //m_strIllArea  =""; //病区
			 m_strCheckOut  =  p_dtBaseDate.Rows[0]["diagnose_vchr"].ToString(); //临床诊断
			
			 m_strComeFrom  = p_dtBaseDate.Rows[0]["application_summary"].ToString(); //骨髓来源
			 m_strSuggest  = p_dtBaseDate.Rows[0]["SUMMARY_VCHR"].ToString(); //意见
			 m_strChecker  = p_dtBaseDate.Rows[0]["reportor"].ToString(); //检验者
			 m_strYear2  = m_CONFIRM_DAT.Year.ToString(); //回报年
			 m_strMonth2  = m_CONFIRM_DAT.Month.ToString(); //回报月
			 m_strDay2  = m_CONFIRM_DAT.Day.ToString(); //回报日
			#endregion

			DataView dtvDetail = new DataView(p_DatDetail);
			dtvDetail.Sort= "report_print_seq_int,sample_print_seq_int";
			#region 详细资料
			int i;
			for(i=0;i<=46;i++)
			{				
				m_streFrangeArr[i+1] = dtvDetail[i]["refrange_vchr"].ToString() + " " + dtvDetail[i]["UNIT_VCHR"].ToString();
				m_streNarrowArr[i+1] = dtvDetail[i]["result_vchr"].ToString();				
			}
			
			for(i=47;i<=48;i++)
			{
				m_streFrangeArr[i+2] = dtvDetail[i]["refrange_vchr"].ToString()+ " " + dtvDetail[i]["UNIT_VCHR"].ToString();
				m_streNarrowArr[i+2] = dtvDetail[i]["result_vchr"].ToString();
			}
			for(i=49;i<=94;i++)
			{
				m_strBloodArr[i-48]=dtvDetail[i]["result_vchr"].ToString();
			}
	
			m_streFrangeArr[48] = dtvDetail[95]["refrange_vchr"].ToString()+ " " + 	dtvDetail[95]["UNIT_VCHR"].ToString();		
			m_streNarrowArr[48] = dtvDetail[95]["result_vchr"].ToString();

			#endregion
			
			}
		#endregion
	}
}
