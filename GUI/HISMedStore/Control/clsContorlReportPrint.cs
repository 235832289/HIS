using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsContorlReportPrint 的摘要说明。
	/// </summary>
	public class clsContorlReportPrint : com.digitalwave.GUI_Base.clsController_Base
	{
		public clsContorlReportPrint()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 变量
		int currPage=2;
		float x1;
		float x2;
		float fwidth;
		float width;
		Pen blackPen = new Pen(Color.Black, 1);
		System.Drawing.Font TextFont=new Font("宋体",14);//文字使用的字体
		System.Drawing.Font DigFont=new Font("宋体",16,System.Drawing.FontStyle.Bold);
		System.Drawing.Font DigFontText=new Font("宋体",14,System.Drawing.FontStyle.Bold);
		
		SizeF szPerWord;//每个字的宽度
		SizeF szPerStr;//字符串的宽度
		int RowHight;
		int StartRow;
		#endregion

		#region 西药的表头
		private  void m_mthPrintTitleEN(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart)
		{
			System.Drawing.Font LFont=new Font("宋体",11);
			x1=50.0F;
			x2 = 800.0F;
			fwidth=50;
			//			height=100;
			RowHight=25;
			StartRow=18;
			width=fwidth;
			int RowHight1=20;
			szPerWord = e.Graphics.MeasureString("三",TextFont);//获取一个字符的宽度
			e.Graphics.DrawString("西药方"+"（"+ReportSendMedStart.m_strInternalEN+"）",DigFont,Brushes.Black,400,StartRow);
			StartRow+=RowHight1*2;
			
			e.Graphics.DrawString("姓名：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("姓名：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strname,LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strname,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("年龄：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("年龄：",LFont);
			width+=szPerStr.Width;
			if(ReportSendMedStart.m_strAge=="")
			{
				e.Graphics.DrawString("不详",LFont,Brushes.Black,width,StartRow);
			}
			else
			{
				e.Graphics.DrawString(ReportSendMedStart.m_strAge,LFont,Brushes.Black,width,StartRow);
			}
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strAge,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("性别：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("性别：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strsex,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strsex,LFont);
			width+=szPerStr.Width+130;
			e.Graphics.DrawString("主诊医生:",LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString("主诊医生:",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strDoctorName,LFont,Brushes.Black,width,StartRow);
			StartRow+=RowHight1;
			width=fwidth;
			e.Graphics.DrawString("就诊卡号：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊卡号：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPatCardID,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strPatCardID,LFont);
			width+=szPerStr.Width+110;
			e.Graphics.DrawString("就诊时间：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊时间：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strRegisterdate,LFont,Brushes.Black,width,StartRow);
			width+=150;
			e.Graphics.DrawString("打印时间：",LFont,Brushes.Black,width,StartRow);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPintdate,LFont,Brushes.Black,width,StartRow);

			StartRow+=15;
			e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
			StartRow+=15;
				width=fwidth;
				e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
				e.Graphics.DrawString("规格",TextFont,Brushes.Black,width+300,StartRow);
				e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+520,StartRow);
				e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+580,StartRow);
				e.Graphics.DrawString("总数",TextFont,Brushes.Black,width+700,StartRow);

		}
		#endregion

		#region 中药的表头
		private  void m_mthPrintTitleCH(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart)
		{
			System.Drawing.Font LFont=new Font("宋体",11);
			x1=50.0F;
			x2 = 800.0F;
			fwidth=50;
			RowHight=25;
			StartRow=18;
			width=fwidth;
			int RowHight1=20;
			szPerWord = e.Graphics.MeasureString("三",TextFont);//获取一个字符的宽度
			e.Graphics.DrawString("中药方"+"（"+ReportSendMedStart.m_strInternalCH+"）",DigFont,Brushes.Black,400,StartRow);
			StartRow+=RowHight1*2;
			
			e.Graphics.DrawString("姓名：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("姓名：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strname,LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strname,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("年龄：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("年龄：",LFont);
			width+=szPerStr.Width;
			if(ReportSendMedStart.m_strAge=="")
			{
				e.Graphics.DrawString("不详",LFont,Brushes.Black,width,StartRow);
			}
			else
			{
				e.Graphics.DrawString(ReportSendMedStart.m_strAge,LFont,Brushes.Black,width,StartRow);
			}
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strAge,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("性别：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("性别：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strsex,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strsex,LFont);
			width+=szPerStr.Width+130;
			e.Graphics.DrawString("主诊医生:",LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString("主诊医生:",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strDoctorName,LFont,Brushes.Black,width,StartRow);
			StartRow+=RowHight1;
			width=fwidth;
			e.Graphics.DrawString("就诊卡号：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊卡号：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPatCardID,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strPatCardID,LFont);
			width+=szPerStr.Width+110;
			e.Graphics.DrawString("就诊时间：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊时间：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strRegisterdate,LFont,Brushes.Black,width,StartRow);
			width+=150;
			e.Graphics.DrawString("打印时间：",LFont,Brushes.Black,width,StartRow);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPintdate,LFont,Brushes.Black,width,StartRow);

			StartRow+=15;
			e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
		}
		#endregion

		#region 页尾
		private void m_printEend(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart)
		{
			float StartRow1;
			float width1;
			int pageHight=e.PageBounds.Height;
			StartRow1=pageHight-50;
			e.Graphics.DrawLine(blackPen, x1, StartRow1, x2, StartRow1);
			StartRow1+=3;
			width1=fwidth;
			e.Graphics.DrawString("配药人：",TextFont,Brushes.Black,width1,StartRow1);
			szPerStr=e.Graphics.MeasureString("配药人：",TextFont);
			width1+=250;
			e.Graphics.DrawString("复核人：",TextFont,Brushes.Black,width1,StartRow1);
			width1+=230;
			e.Graphics.DrawString("合计金额：",TextFont,Brushes.Black,width1,StartRow1);
			szPerStr=e.Graphics.MeasureString("合计金额：",TextFont);
			width1+=szPerStr.Width;
			e.Graphics.DrawString("￥"+ReportSendMedStart.m_strTotalMoney+"元",TextFont,Brushes.Black,width1,StartRow1);
		}
		#endregion

		#region 打印西药数据
		private void m_printMedEN(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMed_VO[] sendMedEN,int currRow,int endRow)
		{
			width=fwidth;
			StartRow+=RowHight;
			if(sendMedEN.Length < 14)
			{
				for(int i1=currRow;i1<endRow;i1++)
				{
					if(e.Graphics.MeasureString(sendMedEN[i1].m_strMedName,TextFont).Width>307)
					{
						StartRow+=10;
						string str1=sendMedEN[i1].m_strMedName.Substring(0,15);
						string str2=sendMedEN[i1].m_strMedName.Substring(15);
						e.Graphics.DrawString(str1,TextFont,Brushes.Black,width,StartRow-13);
						e.Graphics.DrawString(str2,TextFont,Brushes.Black,width,StartRow+2);
					}
					else
					{
						e.Graphics.DrawString(sendMedEN[i1].m_strMedName,TextFont,Brushes.Black,width,StartRow);
					}
					e.Graphics.DrawString(sendMedEN[i1].m_strMedSpace,TextFont,Brushes.Black,width+300,StartRow);
					if(sendMedEN[i1].m_strdosage.Trim()!="")
						e.Graphics.DrawString(sendMedEN[i1].m_strdosage.Trim()+sendMedEN[i1].m_strdosageUnit,TextFont,Brushes.Black,width+520,StartRow);
					e.Graphics.DrawString(sendMedEN[i1].m_strUseName.Trim(),TextFont,Brushes.Black,width+580,StartRow);
					e.Graphics.DrawString(sendMedEN[i1].m_strTotal+sendMedEN[i1].m_strMedUnit,TextFont,Brushes.Black,width+700,StartRow);
					StartRow+=RowHight;
				}
			}
			else
			{
				for(int i1=currRow;i1<endRow;i1++)
				{
					if(e.Graphics.MeasureString(sendMedEN[i1].m_strMedName,TextFont).Width>307)
					{
						StartRow+=10;
						string str1=sendMedEN[i1].m_strMedName.Substring(0,15);
						string str2=sendMedEN[i1].m_strMedName.Substring(15);
						e.Graphics.DrawString(str1,TextFont,Brushes.Black,width,StartRow-13);
						e.Graphics.DrawString(str2,TextFont,Brushes.Black,width,StartRow+2);
					}
					else
					{
						e.Graphics.DrawString(sendMedEN[i1].m_strMedName,TextFont,Brushes.Black,width,StartRow);
					}
					e.Graphics.DrawString(sendMedEN[i1].m_strMedSpace,TextFont,Brushes.Black,width+300,StartRow);
					if(sendMedEN[i1].m_strdosage.Trim()!="")
						e.Graphics.DrawString(sendMedEN[i1].m_strdosage.Trim()+sendMedEN[i1].m_strdosageUnit,TextFont,Brushes.Black,width+520,StartRow);
					e.Graphics.DrawString(sendMedEN[i1].m_strUseName.Trim(),TextFont,Brushes.Black,width+580,StartRow);
					e.Graphics.DrawString(sendMedEN[i1].m_strTotal+sendMedEN[i1].m_strMedUnit,TextFont,Brushes.Black,width+700,StartRow);
					StartRow+=RowHight;
				}
			}
//			e.HasMorePages=false;
		}
		#endregion

		#region 打印中药数据
		private void m_printMedCH(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMed_VO[] sendMedCH,clsReportSendMedStart_VO ReportSendMedStart,int currRow,int endRow,string strMedType)
		{
			if(currRow==0&&strMedType=="3")
			{
				StartRow+=15;
				width=fwidth;
				e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
				e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+150,StartRow);
				e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+250,StartRow);
				width+=400;
				e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
				e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+150,StartRow);
				e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+250,StartRow);
				StartRow+=RowHight;
			}
			width=fwidth;


			if(strMedType=="2"&&currRow==0)
			{
				StartRow+=10;
				e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
				e.Graphics.DrawString("规格",TextFont,Brushes.Black,width+300,StartRow);
				e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+520,StartRow);
				e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+580,StartRow);
				e.Graphics.DrawString("总数",TextFont,Brushes.Black,width+700,StartRow);
			}
			if(strMedType=="3")
			{
				if(sendMedCH.Length<26)
				{
					for(int i1=0;i1<endRow;i1++)
					{
						e.Graphics.DrawString(sendMedCH[i1].m_strMedName,TextFont,Brushes.Black,width,StartRow);
						e.Graphics.DrawString(sendMedCH[i1].m_strdosage+sendMedCH[i1].m_strdosageUnit,TextFont,Brushes.Black,width+150,StartRow);
						e.Graphics.DrawString(sendMedCH[i1].m_strUseName,TextFont,Brushes.Black,width+250,StartRow);
						if(i1+1<endRow)
						{
							float tempWith=width+400;
							e.Graphics.DrawString(sendMedCH[i1+1].m_strMedName,TextFont,Brushes.Black,tempWith,StartRow);
							e.Graphics.DrawString(sendMedCH[i1+1].m_strdosage+sendMedCH[i1+1].m_strdosageUnit,TextFont,Brushes.Black,tempWith+150,StartRow);
							e.Graphics.DrawString(sendMedCH[i1+1].m_strUseName,TextFont,Brushes.Black,tempWith+250,StartRow);
							i1++;
						}
						StartRow+=RowHight;
					}
				}
				else
				{
				
					for(int i1=currRow;i1<endRow;i1++)
					{
						e.Graphics.DrawString(sendMedCH[i1].m_strMedName,TextFont,Brushes.Black,width,StartRow);
						e.Graphics.DrawString(sendMedCH[i1].m_strdosage+sendMedCH[i1].m_strdosageUnit,TextFont,Brushes.Black,width+150,StartRow);
						e.Graphics.DrawString(sendMedCH[i1].m_strUseName,TextFont,Brushes.Black,width+250,StartRow);
						if(i1+1<sendMedCH.Length)
						{
							float tempWith=width+400;
							e.Graphics.DrawString(sendMedCH[i1+1].m_strMedName,TextFont,Brushes.Black,tempWith,StartRow);
							e.Graphics.DrawString(sendMedCH[i1+1].m_strdosage+sendMedCH[i1+1].m_strdosageUnit,TextFont,Brushes.Black,tempWith+150,StartRow);
							e.Graphics.DrawString(sendMedCH[i1+1].m_strUseName,TextFont,Brushes.Black,tempWith+250,StartRow);
							i1++;
						}
						StartRow+=RowHight;
					}
				}

				
				int pgHight=e.PageBounds.Height;
				float StartRow1=pgHight-70;
				float width1=fwidth;
				e.Graphics.DrawString("剂数：",DigFontText,Brushes.Black,width1,StartRow1);
				e.Graphics.DrawString("整剂用法：",TextFont,Brushes.Black,width1+200,StartRow1);
				try
				{
					if(sendMedCH.Length > 0)
					{
						szPerStr=e.Graphics.MeasureString("整剂用法：",TextFont);
						e.Graphics.DrawString(ReportSendMedStart.m_strUseNameAll,TextFont,Brushes.Black,width+200+szPerStr.Width,StartRow1);
						szPerStr=e.Graphics.MeasureString("剂数：",DigFont);
						width1+=szPerStr.Width;
						e.Graphics.DrawString(ReportSendMedStart.m_strSun.Trim(),DigFontText,Brushes.Black,width1,StartRow1);
					}

				}
				catch
				{
				}

			}
			else
			{
				m_printMedEN(e,sendMedCH,currRow,endRow);
			}
		}
		#endregion

		#region 中药的表头
		private  void m_mthPrintTitleCHPage(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart,string strPage)
		{
			System.Drawing.Font LFont=new Font("宋体",11);
			x1=50.0F;
			x2 = 800.0F;
			fwidth=50;
			RowHight=25;
			StartRow=18;
			width=fwidth;
			int RowHight1=20;
			szPerWord = e.Graphics.MeasureString("三",TextFont);//获取一个字符的宽度
			e.Graphics.DrawString("中药方"+"（"+ReportSendMedStart.m_strInternalCH+"）",DigFont,Brushes.Black,350,StartRow);
			e.Graphics.DrawString(strPage+"页",DigFont,Brushes.Black,600,StartRow);
			StartRow+=RowHight1*2;
			
			e.Graphics.DrawString("姓名：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("姓名：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strname,LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strname,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("年龄：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("年龄：",LFont);
			width+=szPerStr.Width;
			if(ReportSendMedStart.m_strAge=="")
			{
				e.Graphics.DrawString("不详",LFont,Brushes.Black,width,StartRow);
			}
			else
			{
				e.Graphics.DrawString(ReportSendMedStart.m_strAge,LFont,Brushes.Black,width,StartRow);
			}
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strAge,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("性别：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("性别：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strsex,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strsex,LFont);
			width+=szPerStr.Width+130;
			e.Graphics.DrawString("主诊医生:",LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString("主诊医生:",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strDoctorName,LFont,Brushes.Black,width,StartRow);
			StartRow+=RowHight1;
			width=fwidth;
			e.Graphics.DrawString("就诊卡号：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊卡号：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPatCardID,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strPatCardID,LFont);
			width+=szPerStr.Width+110;
			e.Graphics.DrawString("就诊时间：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊时间：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strRegisterdate,LFont,Brushes.Black,width,StartRow);
			width+=150;
			e.Graphics.DrawString("打印时间：",LFont,Brushes.Black,width,StartRow);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPintdate,LFont,Brushes.Black,width,StartRow);

			StartRow+=15;
			e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
		}
		#endregion

		#region 西药的表头
		private  void m_mthPrintTitleENPage(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart,string strPage)
		{
			System.Drawing.Font LFont=new Font("宋体",11);
			x1=50.0F;
			x2 = 800.0F;
			fwidth=50;
			//			height=100;
			RowHight=25;
			StartRow=18;
			width=fwidth;
			int RowHight1=20;
			szPerWord = e.Graphics.MeasureString("三",TextFont);//获取一个字符的宽度
			e.Graphics.DrawString("西药方"+"（"+ReportSendMedStart.m_strInternalEN+"）",DigFont,Brushes.Black,350,StartRow);

			e.Graphics.DrawString(strPage+"页",DigFont,Brushes.Black,600,StartRow);
			StartRow+=RowHight1*2;
			
			e.Graphics.DrawString("姓名：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("姓名：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strname,LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strname,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("年龄：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("年龄：",LFont);
			width+=szPerStr.Width;
			if(ReportSendMedStart.m_strAge=="")
			{
				e.Graphics.DrawString("不详",LFont,Brushes.Black,width,StartRow);
			}
			else
			{
				e.Graphics.DrawString(ReportSendMedStart.m_strAge,LFont,Brushes.Black,width,StartRow);
			}
			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strAge,LFont);
			width+=szPerStr.Width+100;
			e.Graphics.DrawString("性别：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("性别：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strsex,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strsex,LFont);
			width+=szPerStr.Width+130;
			e.Graphics.DrawString("主诊医生:",LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString("主诊医生:",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strDoctorName,LFont,Brushes.Black,width,StartRow);
			StartRow+=RowHight1;
			width=fwidth;
			e.Graphics.DrawString("就诊卡号：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊卡号：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPatCardID,LFont,Brushes.Black,width,StartRow);

			szPerStr=e.Graphics.MeasureString(ReportSendMedStart.m_strPatCardID,LFont);
			width+=szPerStr.Width+110;
			e.Graphics.DrawString("就诊时间：",LFont,Brushes.Black,width,StartRow);
			szPerStr=e.Graphics.MeasureString("就诊时间：",LFont);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strRegisterdate,LFont,Brushes.Black,width,StartRow);
			width+=150;
			e.Graphics.DrawString("打印时间：",LFont,Brushes.Black,width,StartRow);
			width+=szPerStr.Width;
			e.Graphics.DrawString(ReportSendMedStart.m_strPintdate,LFont,Brushes.Black,width,StartRow);

			StartRow+=15;
			e.Graphics.DrawLine(blackPen, x1, StartRow, x2, StartRow);
			StartRow+=15;
			width=fwidth;
			e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
			e.Graphics.DrawString("规格",TextFont,Brushes.Black,width+300,StartRow);
			e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+520,StartRow);
			e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+580,StartRow);
			e.Graphics.DrawString("总数",TextFont,Brushes.Black,width+700,StartRow);

		}
		#endregion

		#region 开始打印事件
		int currRow=0;
		int endRow=14;
		int pageint=1;
		int totailPage=0;

		int currRowCH=0;
		int endRowCH=26;
		int pageintCH=1;
		int totailPageCH=0;
		int endRowENCH=14;
		int currRowENCH=0;
		int pageChang=0;
		int t1=0;
		int PageCH=0;
		int k2=0;
//		int currRow=0;
		public  void m_lngPrint(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMedStart_VO ReportSendMedStart,clsReportSendMed_VO[] sendMedEN,clsReportSendMed_VO[] sendMedCH)
		{
			if(sendMedCH!=null&&sendMedCH.Length!=0&&currPage==2)
			{
				clsReportSendMed_VO[] sendMedCHAndEN=new clsReportSendMed_VO[sendMedCH.Length];//保存中成药数据
				clsReportSendMed_VO[] sendMedCH1=new clsReportSendMed_VO[sendMedCH.Length];//保存中药数据
				int intCount=0;//保存中成药的数量
				int intCount1=0;//保存中药的数量
				for(int i1=0;i1<sendMedCH.Length;i1++)
				{
					if(sendMedCH[i1].m_strMedType=="2")
					{
						sendMedCHAndEN[intCount]=new clsReportSendMed_VO();
						sendMedCHAndEN[intCount].m_strdosage=sendMedCH[i1].m_strdosage;
						sendMedCHAndEN[intCount].m_strdosageUnit=sendMedCH[i1].m_strdosageUnit;
						sendMedCHAndEN[intCount].m_strMedName=sendMedCH[i1].m_strMedName;
						sendMedCHAndEN[intCount].m_strMedSpace=sendMedCH[i1].m_strMedSpace;
						sendMedCHAndEN[intCount].m_strMedType=sendMedCH[i1].m_strMedType;
						sendMedCHAndEN[intCount].m_strMedUnit=sendMedCH[i1].m_strMedUnit;
						sendMedCHAndEN[intCount].m_strTotal=sendMedCH[i1].m_strTotal;
						sendMedCHAndEN[intCount].m_strUseName=sendMedCH[i1].m_strUseName;
						intCount++;
					}
					else
					{
						sendMedCH1[intCount1]=new clsReportSendMed_VO();
						sendMedCH1[intCount1].m_strdosage=sendMedCH[i1].m_strdosage;
						sendMedCH1[intCount1].m_strdosageUnit=sendMedCH[i1].m_strdosageUnit;
						sendMedCH1[intCount1].m_strMedName=sendMedCH[i1].m_strMedName;
						sendMedCH1[intCount1].m_strMedSpace=sendMedCH[i1].m_strMedSpace;
						sendMedCH1[intCount1].m_strMedType=sendMedCH[i1].m_strMedType;
						sendMedCH1[intCount1].m_strMedUnit=sendMedCH[i1].m_strMedUnit;
						sendMedCH1[intCount1].m_strTotal=sendMedCH[i1].m_strTotal;
						sendMedCH1[intCount1].m_strUseName=sendMedCH[i1].m_strUseName;
						intCount1++;
					}
				}
				for(int i1=0;i1<intCount;i1++)
				{
					sendMedCH1[intCount1+i1]=new clsReportSendMed_VO();
					sendMedCH1[intCount1+i1].m_strdosage=sendMedCHAndEN[i1].m_strdosage;
					sendMedCH1[intCount1+i1].m_strdosageUnit=sendMedCHAndEN[i1].m_strdosageUnit;
					sendMedCH1[intCount1+i1].m_strMedName=sendMedCHAndEN[i1].m_strMedName;
					sendMedCH1[intCount1+i1].m_strMedSpace=sendMedCHAndEN[i1].m_strMedSpace;
					sendMedCH1[intCount1+i1].m_strMedType=sendMedCHAndEN[i1].m_strMedType;
					sendMedCH1[intCount1+i1].m_strMedUnit=sendMedCHAndEN[i1].m_strMedUnit;
					sendMedCH1[intCount1+i1].m_strTotal=sendMedCHAndEN[i1].m_strTotal;
					sendMedCH1[intCount1+i1].m_strUseName=sendMedCHAndEN[i1].m_strUseName;

				}
//				m_mthPrintTitleCHPage(e,ReportSendMedStart,pageint.ToString()+"/"+totailPageCH.ToString());
//				width=fwidth;
//				for(int f2=currRow;f2<sendMedCH1.Length;f2++)
//				{
//					if(sendMedCH1[f2].m_strMedType=="3")
//					{
//						if(f2+1<sendMedCH1.Length&&sendMedCH1[f2+1].m_strMedType=="3")
//						{
//							if(StartRow+RowHight<=e.PageBounds.Height)
//							{
//								m_printNew(e,sendMedCH1[f2],sendMedCH1[f2+1],ReportSendMedStart,width,StartRow);
//								StartRow+=RowHight;
//								f2++;
//							}
//							else
//							{
//								pageint++;
//								currRow=f2;
//								e.HasMorePages=true;
//								return;
//							}
//						}
//
//					}
//				}
//				m_printEend(e,ReportSendMedStart);

						
				if(intCount*2+intCount1<26)
				{
					if(intCount==0)//只有中药
					{
						m_mthPrintTitleCH(e,ReportSendMedStart);
						m_printMedCH(e,sendMedCH,ReportSendMedStart,0,sendMedCH.Length,"3");
						currPage=1;
						m_printEend(e,ReportSendMedStart);
					}
					else if(intCount1==0)//只有中成药
					{
						m_mthPrintTitleCH(e,ReportSendMedStart);
						currPage=1;
						m_printMedCH(e,sendMedCHAndEN,ReportSendMedStart,0,intCount+1,"2");
						m_printEend(e,ReportSendMedStart);
					}
					else//有中成药和中药
					{
						m_mthPrintTitleCH(e,ReportSendMedStart);
						m_printMedCH(e,sendMedCH1,ReportSendMedStart,0,intCount1,"3");
						m_printMedCH(e,sendMedCHAndEN,ReportSendMedStart,0,intCount,"2");
						currPage=1;
						m_printEend(e,ReportSendMedStart);
					}
				}
				else
				{
					
					double kk=sendMedCH.Length/26;
					totailPageCH=int.Parse(kk.ToString());
					if(sendMedCH.Length%26!=0)
					{
						totailPageCH++;
					}
					for(int k1=pageintCH;k1<=totailPageCH;k1++)
					{
						if(intCount1!=0&&intCount==0)
						{
							m_mthPrintTitleCHPage(e,ReportSendMedStart,k1.ToString()+"/"+totailPageCH.ToString());
							m_printMedCH(e,sendMedCH1,ReportSendMedStart,currRowCH,endRowCH,"3");
							m_printEend(e,ReportSendMedStart);
							currRowCH=26*pageint;
							if(currRowCH+26>sendMedCH.Length)
							{
								endRowCH=sendMedCH.Length;
							}
							else
							{
								endRowCH=currRowCH+26;
							}
							pageintCH++;
							if(pageintCH<=totailPageCH)
							{
								e.HasMorePages=true;
								break;
							}
							currPage=1;
						}
						if(intCount1==0&&intCount!=0)
						{
							m_mthPrintTitleCHPage(e,ReportSendMedStart,k1.ToString()+"/"+totailPageCH.ToString());
							m_printMedCH(e,sendMedCHAndEN,ReportSendMedStart,currRowCH,endRow,"2");
							m_printEend(e,ReportSendMedStart);
							currRowCH=14*pageint;
							if(currRowCH+14>intCount)
							{
								endRow=intCount;
							}
							else
							{
								endRow=currRowCH+14;
							}
							pageintCH++;
							if(pageintCH<=totailPageCH)
							{
								e.HasMorePages=true;
								break;
							}
							currPage=1;
						}
						if(intCount1!=0&&intCount!=0)
						{
							double kk1=(intCount1/2+intCount)/14;
							totailPageCH=int.Parse(kk1.ToString());
							if((intCount1/2+intCount)%14!=0)
							{
								totailPageCH++;
							}

							if(t1!=2)
							{
								if(intCount1<=endRowCH)
									endRowCH=intCount1;
								PageCH=intCount1/26;
								if(intCount1%26!=0)
									PageCH++;
								m_mthPrintTitleCHPage(e,ReportSendMedStart,k1.ToString()+"/"+totailPageCH.ToString());
								m_printMedCH(e,sendMedCH1,ReportSendMedStart,currRowCH,endRowCH,"3");
								m_printEend(e,ReportSendMedStart);
								currRowCH=26*pageint;
								if(currRowCH+26>intCount1)
								{
									t1++;
									endRowCH=intCount1-1;
									endRowENCH=12-intCount1/32;
									pageint++;
								}
								else
								{
									endRowCH=currRowCH+26;
								}
								if(intCount1>26)
								        pageintCH++;
								if(pageintCH<=PageCH||endRowENCH==0)
								{
									if(intCount1<26)
										pageintCH++;
									e.HasMorePages=true;
									break;
								}
								
								
							}
							if(t1==2)
							{
								if(pageChang>0||endRowENCH==0)
								   m_mthPrintTitleCHPage(e,ReportSendMedStart,k1.ToString()+"/"+totailPageCH.ToString());
								
								m_printMedCH(e,sendMedCHAndEN,ReportSendMedStart,currRowENCH,endRowENCH,"2");
								m_printEend(e,ReportSendMedStart);
								currRowENCH=endRowENCH;

								if(currRowENCH+14>intCount)
								{
									endRowENCH=intCount;
								}
								else
								{
									endRowENCH=currRowENCH+14;
								}
								pageintCH++;
								if(pageintCH<=totailPageCH||k2==0)
								{
//									pageChang++;
									e.HasMorePages=true;
									break;
								}
							}
							currPage=1;
						}
					}
				}
			}
			if(sendMedEN!=null&&sendMedEN.Length!=0&&currPage>=1||sendMedCH.Length==0)
			{
				if(currPage==1)
				{
					currPage++;
					e.HasMorePages=true;
				}
				else
				{
					if(sendMedEN.Length<14)
					{
						m_mthPrintTitleEN(e,ReportSendMedStart);
						m_printMedEN(e,sendMedEN,0,sendMedEN.Length);
						m_printEend(e,ReportSendMedStart);
					}
					else
					{
						double kk=sendMedEN.Length/14;
						totailPage=int.Parse(kk.ToString());
						if(sendMedEN.Length%14!=0)
						{
							totailPage++;
						}
						for(int k1=pageint;k1<=totailPage;k1++)
						{
							m_mthPrintTitleENPage(e,ReportSendMedStart,k1.ToString()+"/"+totailPage.ToString());
							m_printMedEN(e,sendMedEN,currRow,endRow);
							m_printEend(e,ReportSendMedStart);
							currRow=14*pageint;
							if(currRow+14>sendMedEN.Length)
							{
								endRow=sendMedEN.Length;
							}
							else
							{
								endRow=currRow+14;
							}
							pageint++;
							if(pageint<=totailPage)
							{
								e.HasMorePages=true;
								break;
							}
						}
					}
				}

			}
			
		}
		#endregion

		#region 新的打印方法
		int currRow1=0;

		#region 画中药数据
		private void m_printNew(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMed_VO sendMedCH,clsReportSendMed_VO sendMedCHNext,clsReportSendMedStart_VO ReportSendMedStart,float width,float StartRow)
		{

						e.Graphics.DrawString(sendMedCH.m_strMedName,TextFont,Brushes.Black,width,StartRow);
						e.Graphics.DrawString(sendMedCH.m_strdosage+sendMedCH.m_strdosageUnit,TextFont,Brushes.Black,width+150,StartRow);
						e.Graphics.DrawString(sendMedCH.m_strUseName,TextFont,Brushes.Black,width+250,StartRow);
						if(sendMedCHNext!=null)
						{
							float tempWith=width+400;
							e.Graphics.DrawString(sendMedCHNext.m_strMedName,TextFont,Brushes.Black,tempWith,StartRow);
							e.Graphics.DrawString(sendMedCHNext.m_strdosage+sendMedCHNext.m_strdosageUnit,TextFont,Brushes.Black,tempWith+150,StartRow);
							e.Graphics.DrawString(sendMedCHNext.m_strUseName,TextFont,Brushes.Black,tempWith+250,StartRow);
						}
		}
     
        #endregion

		#region 画西药列头
		private void m_printENCol(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMed_VO sendMedCH,float width,float StartRow)
		{
			StartRow+=15;
			width=fwidth;
			e.Graphics.DrawString("药品名称",TextFont,Brushes.Black,width,StartRow);
			e.Graphics.DrawString("规格",TextFont,Brushes.Black,width+300,StartRow);
			e.Graphics.DrawString("剂量",TextFont,Brushes.Black,width+520,StartRow);
			e.Graphics.DrawString("用法",TextFont,Brushes.Black,width+580,StartRow);
			e.Graphics.DrawString("总数",TextFont,Brushes.Black,width+700,StartRow);

		}

		#endregion

		#region 画西药数据
		private void m_printEN(System.Drawing.Printing.PrintPageEventArgs e,clsReportSendMed_VO sendMedCH,float width,float StartRow)
		{
						if(e.Graphics.MeasureString(sendMedCH.m_strMedName,TextFont).Width>307)
						{
							StartRow+=10;
							string str1=sendMedCH.m_strMedName.Substring(0,15);
							string str2=sendMedCH.m_strMedName.Substring(15);
							e.Graphics.DrawString(str1,TextFont,Brushes.Black,width,StartRow-13);
							e.Graphics.DrawString(str2,TextFont,Brushes.Black,width,StartRow+2);
						}
						else
						{
							e.Graphics.DrawString(sendMedCH.m_strMedName,TextFont,Brushes.Black,width,StartRow);
						}
						e.Graphics.DrawString(sendMedCH.m_strMedSpace,TextFont,Brushes.Black,width+300,StartRow);
						if(sendMedCH.m_strdosage.Trim()!="")
							e.Graphics.DrawString(sendMedCH.m_strdosage.Trim()+sendMedCH.m_strdosageUnit,TextFont,Brushes.Black,width+520,StartRow);
						e.Graphics.DrawString(sendMedCH.m_strUseName.Trim(),TextFont,Brushes.Black,width+580,StartRow);
						e.Graphics.DrawString(sendMedCH.m_strTotal+sendMedCH.m_strMedUnit,TextFont,Brushes.Black,width+700,StartRow);
//HasMorePages=true;

		}

		#endregion

		#endregion

	}
}
