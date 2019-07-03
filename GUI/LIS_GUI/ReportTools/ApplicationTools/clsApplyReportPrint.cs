using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Xml;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsApplyReportPrint 的摘要说明。
	/// </summary>
	public class clsApplyReportPrintTool: com.digitalwave.GUI_Base.clsController_Base, infPrintRecord
	{
		#region inital
		private Font m_fntTitle;
		private Font m_fntSmallBold;
		private Font m_fntSmallNotBold;
		private Font m_fntSmall2NotBold;
		private Font m_fntMiddleNotBold;

		//边框画笔
		private Pen m_GridPen;

		float m_fltPrintWidth;      //打印的宽度
		float m_fltPrintHeight;     //打印的高度

		long m_lngTitleTop = 30;    //打印标题的高度
		long m_lngY;                //打印时的高度定位
		long m_lngVerticalLineStart; //竖线打印的起始位置
		long m_lngVerticalLineEnd;   //竖线打印的结束位置
		#endregion

        public clsApplyReportPrintTool()
        {
            m_strTitle = this.m_objComInfo.m_strGetHospitalTitle();
        }

		#region 打印数据
		string m_strTitle = ""; // "佛山市第二人民医院检验申请单";
		string m_strOutPatientNO = "";
		string m_strPatientInHospitalNO;// = "00000001";
		string m_strApplicationNO;// = "00000001";
		string m_strPatientName;// = "小李子";
		string m_strSex;// = "男";
		string m_strAge;// = "20";
		string m_strSampleType;// = "血液";
		string m_strCollector;// = "陈笑";
		string m_strCollectDat;// = "2004-10-06";
		string m_strApplyer;// = "王军";
		string m_strApplyDat;// = "2004-10-06";
		string m_strApplyDept;// = "内科";
		string m_strBedNO;// = "12-12";
		string m_strCheckItem;// = "血常规";
		string m_strChargeInfo;// = "血常规 10,血型 20.5"
		string m_strDiagnose;// = "脑梗";
		string m_strChargeState;
        string m_strBarCode = ""; //xing.chen add for print barcode
		#endregion

		#region 打印报告的标题及基本信息
		private void m_mthPrintReportTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
		{
			m_lngY = m_lngTitleTop;
			if(m_fltPrintWidth == 0)
				m_fltPrintWidth = p_objPrintArgs.PageBounds.Width*0.8f;
			SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle,m_fntTitle);
			float fltCurrentX = (p_objPrintArgs.PageBounds.Width-sfTitle.Width)/2;

			p_objPrintArgs.Graphics.DrawString(m_strTitle,m_fntTitle,Brushes.Black,fltCurrentX,m_lngTitleTop);
			
			//门诊号
			SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("门诊号:",m_fntSmallNotBold);
			m_lngY = m_lngY + (long)sfTitle.Height - (long)sfWords.Height;
			fltCurrentX = m_fltPrintWidth*0.08f;

			p_objPrintArgs.Graphics.DrawString("门诊号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			fltCurrentX += sfWords.Width;
			p_objPrintArgs.Graphics.DrawString(m_strOutPatientNO,m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			//住院号
			m_lngY += (long)sfWords.Height + 10;
			fltCurrentX = m_fltPrintWidth*0.08f;

			p_objPrintArgs.Graphics.DrawString("住院号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			fltCurrentX += sfWords.Width;
			p_objPrintArgs.Graphics.DrawString(m_strPatientInHospitalNO,m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			//科室
			fltCurrentX = m_fltPrintWidth*0.36f;
			sfWords = p_objPrintArgs.Graphics.MeasureString("科室:",m_fntSmallNotBold);

			p_objPrintArgs.Graphics.DrawString("科室:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			fltCurrentX += sfWords.Width;
			p_objPrintArgs.Graphics.DrawString(m_strApplyDept,m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			//床号
			fltCurrentX = m_fltPrintWidth*0.66f;

			p_objPrintArgs.Graphics.DrawString("床号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			fltCurrentX += sfWords.Width;
			p_objPrintArgs.Graphics.DrawString(m_strBedNO,m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			//申请单号
			fltCurrentX = m_fltPrintWidth*0.88f;
			sfWords = p_objPrintArgs.Graphics.MeasureString("申请单号:",m_fntSmallNotBold);

			p_objPrintArgs.Graphics.DrawString("申请单号:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			
			fltCurrentX += sfWords.Width;
			p_objPrintArgs.Graphics.DrawString(m_strApplicationNO,m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

            //xing.chen add for print barcode
            if (m_strBarCode != null && m_strBarCode.Trim() != "")
            {
                System.Configuration.ConfigXmlDocument xmlConfig = new System.Configuration.ConfigXmlDocument();
                string strPath = System.AppDomain.CurrentDomain.BaseDirectory;
                strPath += "LoginFile.xml";
                xmlConfig.Load(strPath);
                string strBarCodeFont = xmlConfig["Main"]["lisBarCodeName"].Value;
                m_strBarCode = "*" + m_strBarCode + "*";
                p_objPrintArgs.Graphics.DrawString(m_strBarCode, new Font(strBarCodeFont, 32.00f), Brushes.Black, fltCurrentX - 50, m_lngY - 60);
            }
			
			//底端的Y坐标
			m_lngY += (long)sfWords.Height;
		}

		//画横线
		private void m_mthPrintTopLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
		{
			m_lngY += 3;
			m_lngVerticalLineStart = m_lngY;
			p_objPrintArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.08f,m_lngY,p_objPrintArgs.PageBounds.Width*0.96f,m_lngY);
		}
		#endregion

		#region 打印报告单的左边信息
		public void m_mthPrintReportLeft(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			float fltCurrentX = m_fltPrintWidth*0.08f;
			m_lngY += 5;
			SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("姓名:",m_fntSmallNotBold);

			//姓名
			p_objPrintPageArgs.Graphics.DrawString("姓名:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strPatientName,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//性别
			m_lngY += (long)sfWords.Height+5;
			p_objPrintPageArgs.Graphics.DrawString("性别:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strSex,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//年龄
			m_lngY += (long)sfWords.Height+5;
			p_objPrintPageArgs.Graphics.DrawString("年龄:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strAge,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//检验标本
			m_lngY += (long)sfWords.Height+5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("检验标本:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("检验标本:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strSampleType,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//临床诊断
			m_lngY += (long)sfWords.Height+5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("临床诊断:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("临床诊断:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);

			m_lngY += (long)sfWords.Height+5;
			RectangleF rectF = new RectangleF(fltCurrentX,m_lngY,m_fltPrintWidth*0.12f,9*sfWords.Height);
			p_objPrintPageArgs.Graphics.DrawString(m_strDiagnose,m_fntSmallNotBold,Brushes.Black,rectF);

			//采样人员
			m_lngY += 9*(long)sfWords.Height + 5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("采样人员:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("采样人员:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strCollector,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//采样时间
			m_lngY += (long)sfWords.Height + 5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("采样时间:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("采样时间:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strCollectDat,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			m_lngY += (long)sfWords.Height;
		}
		#endregion

		#region 打印报告单底部的线
		private void m_mthPrintBottomLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			m_lngY += 5;
			m_lngVerticalLineEnd = m_lngY;
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.08f,m_lngY,p_objPrintPageArgs.PageBounds.Width*0.96f,m_lngY);
		}
		#endregion

		#region 打印报告单底部信息
		private void m_mthPrintReportBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			m_lngY += 5;
			float fltCurrentX = m_fltPrintWidth*0.08f;

			//送检时间
			SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("送检时间:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("送检时间:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strApplyDat,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

			//送检医生
			fltCurrentX = m_fltPrintWidth*0.46f;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("送检医生:",m_fntSmallNotBold);
			p_objPrintPageArgs.Graphics.DrawString("送检医生:",m_fntSmallNotBold,Brushes.Black,fltCurrentX,m_lngY);
			p_objPrintPageArgs.Graphics.DrawString(m_strApplyer,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);
		}
		#endregion

		#region 打印报告单的分割线
		private void m_mthPrintReportVerticalLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.38f,m_lngVerticalLineStart,m_fltPrintWidth*0.38f,m_lngVerticalLineEnd);
		}
		#endregion

		#region 打印报告单右边信息
		private void m_mthPrintReportRight(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
		{
			long lngY = m_lngVerticalLineStart+15;
			float fltCurrentX = m_fltPrintWidth*0.42f;
			SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("检验目的:",m_fntMiddleNotBold);
			p_objPrintPageArgs.Graphics.DrawString("检验目的:",m_fntMiddleNotBold,Brushes.Black,fltCurrentX,lngY);

			lngY += (long)sfWords.Height+5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("检验目的:",m_fntSmallNotBold);
			RectangleF rectF = new RectangleF(fltCurrentX+10,lngY,m_fltPrintWidth*0.76f,sfWords.Height*6);
			p_objPrintPageArgs.Graphics.DrawString(m_strCheckItem,m_fntSmallNotBold,Brushes.Black,rectF);

			lngY += (long)rectF.Height+10;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("收费信息: ", m_fntMiddleNotBold);
			p_objPrintPageArgs.Graphics.DrawString("收费信息: ", m_fntMiddleNotBold,Brushes.Black,fltCurrentX,lngY);

			lngY += (long)sfWords.Height+5;
			sfWords = p_objPrintPageArgs.Graphics.MeasureString("收费信息:",m_fntSmallNotBold);
			rectF = new RectangleF(fltCurrentX+10,lngY,m_fltPrintWidth*0.76f,sfWords.Height*8);
			p_objPrintPageArgs.Graphics.DrawString(m_strChargeInfo,m_fntSmallNotBold,Brushes.Black,rectF);
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
			m_fntTitle= new Font("SimSun", 16,FontStyle.Bold);
			m_fntSmallBold= new Font("SimSun",11,FontStyle.Bold);
			m_fntSmallNotBold=new Font("SimSun",10f,FontStyle.Regular);
			m_fntSmall2NotBold=new Font("SimSun",9f,FontStyle.Regular);
			m_fntMiddleNotBold = new Font("SimSun",11f,FontStyle.Regular);

			m_GridPen = new Pen(Color.Black,1);

			#region 打印设置
			try
			{
				PaperSize ps = null;
				foreach(PaperSize objPs in ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.PaperSizes)
				{
					if(objPs.PaperName == "LIS_Apply_Report")
					{
						ps = objPs;
						break;
					}
				}
				if(ps != null)
				{
					((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.PaperSize = ps;
                    m_fltPrintWidth = ps.Width * 0.8f;
					m_fltPrintHeight = ps.Height;
				}
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
			m_mthInitalPrintInfo((clsLisApplyReportInfo_VO)p_objPrintArg);
		}
        //xing.chen add for print barcode
        public void m_mthBeginPrint(object p_objPrintArg,string p_strBarCode)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthBeginPrint 实现
            m_mthInitalPrintInfo((clsLisApplyReportInfo_VO)p_objPrintArg,p_strBarCode);
        }

		public void m_mthPrintPage(object p_objPrintArg)
		{
			m_mthPrintReportTop((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintTopLine((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportLeft((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintBottomLine((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportBotton((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportVerticalLine((PrintPageEventArgs)p_objPrintArg);
			m_mthPrintReportRight((PrintPageEventArgs)p_objPrintArg);
		}

		public void m_mthEndPrint(object p_objPrintArg)
		{
			// TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
		}

		#endregion

		#region 初始化打印数据
		public void m_mthInitalPrintInfo(clsLisApplyReportInfo_VO objReportInfo)
		{
			if(objReportInfo == null)
				return;
			m_strPatientInHospitalNO = objReportInfo.m_strPatientInHospitalNO;
			if(objReportInfo.m_strApplicationNO.Length > 8)
			{
				//取后面8位
				m_strApplicationNO = objReportInfo.m_strApplicationNO.Substring(objReportInfo.m_strApplicationNO.Length-9,8);
			}
			else
			{
				m_strApplicationNO = objReportInfo.m_strApplicationNO;
			}
			m_strPatientName = objReportInfo.m_strPatientName;
			m_strSex = objReportInfo.m_strSex;
			m_strAge = objReportInfo.m_strAge;
			m_strSampleType = objReportInfo.m_strSampleType;
			m_strCollector = objReportInfo.m_strCollector;
			if(objReportInfo.m_strCollectDat != null && objReportInfo.m_strCollectDat != "")
			{
				m_strCollectDat = DateTime.Parse(objReportInfo.m_strCollectDat).ToShortDateString();
			}
			else
			{
				m_strCollectDat = objReportInfo.m_strCollectDat;
			}
			m_strApplyer = objReportInfo.m_strApplyer;
			if(objReportInfo.m_strApplyDat != null && objReportInfo.m_strApplyDat != "")
			{
				m_strApplyDat = DateTime.Parse(objReportInfo.m_strApplyDat).ToString("yyyy-MM-dd HH:mm");
			}
			else
			{
				m_strApplyDat = objReportInfo.m_strApplyDat;
			}
			m_strApplyDept = objReportInfo.m_strApplyDept;
			m_strBedNO = objReportInfo.m_strBedNO;
			m_strCheckItem = objReportInfo.m_strCheckContent;
			m_strDiagnose = objReportInfo.m_strDiagnose;
			string strChargeInfo = "";
			if(objReportInfo.m_strChargeInfo != null)
			{
				strChargeInfo = objReportInfo.m_strChargeInfo.Replace("|",", ");
				strChargeInfo = strChargeInfo.Replace(">"," ");
			}
			m_strChargeInfo = strChargeInfo;
			m_strChargeState = objReportInfo.m_strChargeState;
		}

        //xing.chen add for print barcode
        public void m_mthInitalPrintInfo(clsLisApplyReportInfo_VO objReportInfo,string p_strBarCode)
        {
            if (objReportInfo == null)
                return;
            m_strPatientInHospitalNO = objReportInfo.m_strPatientInHospitalNO;
            if (objReportInfo.m_strApplicationNO.Length > 8)
            {
                //取后面8位
                m_strApplicationNO = objReportInfo.m_strApplicationNO.Substring(objReportInfo.m_strApplicationNO.Length - 9, 8);
            }
            else
            {
                m_strApplicationNO = objReportInfo.m_strApplicationNO;
            }
            m_strPatientName = objReportInfo.m_strPatientName;
            m_strSex = objReportInfo.m_strSex;
            m_strAge = objReportInfo.m_strAge;
            m_strSampleType = objReportInfo.m_strSampleType;
            m_strCollector = objReportInfo.m_strCollector;
            if (objReportInfo.m_strCollectDat != null && objReportInfo.m_strCollectDat != "")
            {
                m_strCollectDat = DateTime.Parse(objReportInfo.m_strCollectDat).ToShortDateString();
            }
            else
            {
                m_strCollectDat = objReportInfo.m_strCollectDat;
            }
            m_strApplyer = objReportInfo.m_strApplyer;
            if (objReportInfo.m_strApplyDat != null && objReportInfo.m_strApplyDat != "")
            {
                m_strApplyDat = DateTime.Parse(objReportInfo.m_strApplyDat).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                m_strApplyDat = objReportInfo.m_strApplyDat;
            }
            m_strApplyDept = objReportInfo.m_strApplyDept;
            m_strBedNO = objReportInfo.m_strBedNO;
            m_strCheckItem = objReportInfo.m_strCheckContent;
            m_strDiagnose = objReportInfo.m_strDiagnose;
            string strChargeInfo = "";
            if (objReportInfo.m_strChargeInfo != null)
            {
                strChargeInfo = objReportInfo.m_strChargeInfo.Replace("|", ", ");
                strChargeInfo = strChargeInfo.Replace(">", " ");
            }
            m_strChargeInfo = strChargeInfo;
            m_strChargeState = objReportInfo.m_strChargeState;
            m_strBarCode = p_strBarCode;
        }
		#endregion
	}
}
