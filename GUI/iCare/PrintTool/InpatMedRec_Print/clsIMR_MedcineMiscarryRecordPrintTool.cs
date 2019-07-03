using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
namespace iCare
{
	/// <summary>
	/// 药物流产记录表 的摘要说明。
	/// </summary>
	public class clsIMR_MedcineMiscarryRecordPrintTool :clsInpatMedRecPrintBase
	{
		public clsIMR_MedcineMiscarryRecordPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("药物流产记录表",295),
																		   new clsPrintInPatMedMiscarryMain(),
																	       new clsPrintInPatMedGetSignName(),
				                                                           new clsPrintInPatMedMiscarrySecord(),
																		   new clsPrintInPatMedGetSignNameSec(),
																		   

																	   });			
		}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            //{
				#region
//				p_objGrp.DrawString("药物流产记录表",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
//		
//				p_intPosY += 20;
//				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//		
//				p_intPosY += 20;
//				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//		
//				p_intPosY += 20;
//				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
//				p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
//
//				p_intPosY += 20;
//				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//		
//				p_intPosY += 20;
//				p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//		
//				p_intPosY += 20;
//				p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
//
//				p_intPosY += 20;
//				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
//		
//				p_intPosY += 20;
//				if(m_objPrintInfo.m_dtmInPatientDate != System.DateTime.MinValue)
//				{
//					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
//				}
//				else
//				{
//					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				}				
//			
//				m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
//				int intRealHeight;
//				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
//				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
//								
//				p_intPosY += 30;
//				m_blnHaveMoreLine = false;
				#endregion
        //        p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,45);
		
        //        p_objGrp.DrawString("药 物 流 产 记 录 表",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,330,75);
        //        p_intPosY =130;
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}

		#endregion
		#region 重载
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#endregion
		#region 姓名---诊断
		/// <summary>
		/// 孕/产次---诊断
		/// </summary>
		private class clsPrintInPatMedMiscarryMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string[] m_strKeysArr1 = {"孕/产次>>孕","","孕/产次>>产次"};	
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{   
                        //m_mthMakeText(new string[]{"姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","  年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},new string [] {"",""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"   职业："+ m_objPrintInfo.m_strOccupation+"；","  日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString()+"；"},new string [] {"",""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"\n单位："+ m_objPrintInfo.m_strOfficeName+"；"},new string []{""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{ "  家庭住址："+ m_objPrintInfo.m_strHomeAddress+"；"," 电话："+ m_objPrintInfo.m_strHomePhone+"；"},new string [] {"",""},ref strAllText,ref strXml);
	
						m_mthMakeText(new string[]{"孕/产次：","/$$",""},m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n末次妊娠终止日期："},new string[]{"末次妊娠终止日期"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n末次妊娠终止结局："},new string[]{"末次妊娠终止结局"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；    哺乳：","哺乳>>否","哺乳>>是"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n月经史："},new string[]{""},ref strAllText,ref strXml);

						m_mthMakeText(new string[]{"经期/周期：","/；$$",""},new string[]{"月经史>>经期","","月经史>>周期"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"    经量：","月经史>>经量>>多","月经史>>经量>>中","月经史>>经量>>少"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"    痛经：","月经史>>痛经>>无","月经史>>痛经>>轻","月经史>>痛经>>重"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"末次月经：","停经天数：","天$$"},new string[]{"月经史>>末次月经","月经史>>停经天数",""},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n既往史："},new string[]{"既往史"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n药物过敏史："},new string[]{"药物过敏史"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n体格检查：血压：","/$$","mmHg; $$","脉搏:","次/分; $$","体温:","度;$$"},
							          new string[]{"体格检查>>血压>>mm","体格检查>>血压>>Hg","","体格检查>>脉搏","","体格检查>>体温",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"  心：","肺："},new string[]{"体格检查>>心","体格检查>>肺"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n妇科检查：外阴：","阴道：","宫颈：","子宫大小：","周; $$","\n      附件:"},
							          new string[]{"妇科检查>>外阴","妇科检查>>阴道","妇科检查>>宫颈","妇科检查>>子宫大小","","妇科检查>>附件"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n辅助检查：血常规：","尿妊娠试验：","性; $$","滴虫：","念珠菌：$$","性; $$","清洁度：","度","B超胚囊大小平均直径:","mm$$"},
							new string[]{"辅助检查>>血常规","辅助检>>尿妊娠试验查","","辅助检查>>滴虫","辅助检查>>念珠菌","","辅助检查>>清洁度","","辅助检查>>B超胚囊大小平均直径",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n诊断："},new string[]{"诊断"},ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					//m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
		#region 签名
		/// <summary>
		/// 修正诊断&初步诊断（诊断）
		/// </summary>
		private class clsPrintInPatMedGetSignName : clsIMR_PrintLineBase
		{
			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                objItemContent = m_objGetContentFromItemArr(new string[] { "修正诊断", "初步诊断", "手术者", "助手", "医生签名1" });
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
					m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				}
				
				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
							m_objPrintContext1.m_mthPrintLine(320,m_intRecBaseX+30,p_intPosY,p_objGrp);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+400,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_intPosY += 20;
					m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
				}
			}

			private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems == null)
					return;
				p_intPosY += 20;
//				p_objGrp.DrawString("手术者："+(objItemContent[2]==null ? "" : (objItemContent[2].m_strItemContent == null ? "":objItemContent[2].m_strItemContent)) ,m_fontItemMidHead,Brushes.Black,m_intRecBaseX+20,p_intPosY);
//				p_objGrp.DrawString("助手："+ (objItemContent[3] == null ? "" :(objItemContent[3].m_strItemContent == null ? "":objItemContent[3].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				p_objGrp.DrawString("医师签名："+ (objItemContent[4] == null ? "" :(objItemContent[4].m_strItemContent == null ? "":objItemContent[4].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+500,p_intPosY);
				
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
		#region 给药方法---刮出病理
		/// <summary>
		/// 孕/产次---诊断
		/// </summary>
		private class clsPrintInPatMedMiscarrySecord : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage=true;
			private string[] m_strKeysArr1 = {"米非司酮药物>>服药日期","给药方法>>米非司酮药物>>总剂量",""};	
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				if(m_blnIsFirstPrint)
				{
					if(blnNextPage)
					{
						//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
						m_blnHaveMoreLine = true;
						blnNextPage = false;
						p_intPosY += 50;
						return;
					}
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"给药方法："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n1、米非司酮药物："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"服药日期：","总剂量：","mg； $$"},m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"    用法：","给药方法>>米非司酮药物>>用法>>顿服","给药方法>>米非司酮药物>>用法>>分服"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n2、前列腺素类药物："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"药物："," 剂量：","mg；$$"},new string[]{"给药方法>>前列腺素类药物>>药物","给药方法>>前列腺素类药物>>剂量",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"    用法：","给药方法>>前列腺素类药物>>用法>>口服","给药方法>>前列腺素类药物>>用法>>阴道穹隆"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                                 给药时间："},new string[]{"给药方法>>前列腺素类药物>>给药时间"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n留院观察：","小时；  $$"},new string[]{"留院观察>>小时",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"观察时间内特殊情况："},new string[]{"观察时间内特殊情况"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n开始出血时间：","总出血天数：","天；$$"},new string[]{"开始出血时间","总出血天数",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"  出血量(与平时月经量相比)：","出血量(与平时月经量相比)>>很多","出血量(与平时月经量相比)>>多","出血量(与平时月经量相比)>>相似","出血量(与平时月经量相比)>>少"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n胚囊排出时间：","胚囊大小：","mm；$$"},new string[]{"胚囊排出时间","胚囊大小",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n副反应：呕吐：","次；$$","腹泻：","次；$$"},new string[]{"副反应>>呕吐","","副反应>>腹泻",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"  腹痛：","副反应>>腹痛>>轻","副反应>>腹痛>>中","副反应>>腹痛>>重"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"  其他："},new string[]{"副反应>>其他"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n清宫：","清宫>>未","清宫>>是"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"  原因：","日期："},new string[]{"原因","清宫>>日期"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n 刮出物病理：","刮出物病理>>未","刮出物病理>>是"},ref strAllText,ref strXml);
						
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					//m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
		#region 签名
		/// <summary>
		/// 修正诊断&初步诊断（诊断）
		/// </summary>
		private class clsPrintInPatMedGetSignNameSec : clsIMR_PrintLineBase
		{
			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                objItemContent = m_objGetContentFromItemArr(new string[] { "修正诊断", "初步诊断", "手术者", "助手", "医生签名" });
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
					m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				}
				
				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
							m_objPrintContext1.m_mthPrintLine(320,m_intRecBaseX+30,p_intPosY,p_objGrp);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+400,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_intPosY += 20;
					m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
				}
			}

			private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems == null)
					return;
				p_intPosY += 20;
				//				p_objGrp.DrawString("手术者："+(objItemContent[2]==null ? "" : (objItemContent[2].m_strItemContent == null ? "":objItemContent[2].m_strItemContent)) ,m_fontItemMidHead,Brushes.Black,m_intRecBaseX+20,p_intPosY);
				//				p_objGrp.DrawString("助手："+ (objItemContent[3] == null ? "" :(objItemContent[3].m_strItemContent == null ? "":objItemContent[3].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				p_objGrp.DrawString("医师签名："+ (objItemContent[4] == null ? "" :(objItemContent[4].m_strItemContent == null ? "":objItemContent[4].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+500,p_intPosY);
				
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
	}
}
