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
	///打印心脏病住院记录 的摘要说明。
	/// </summary>
	public class clsIMR_HeartHospitalRecordPrintTool:clsInpatMedRecPrintBase
	{
		public clsIMR_HeartHospitalRecordPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
																		   new clsPrintInPatHeartHospitalMain(),
																		   new clsPrintInPatHeartHospitalSecord(),
                                                                           new clsPrintInPatHeartHospitalSecord1(),
																		   new clsPrintInPatMedGetSignName()

			});			
		}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				#region
								p_objGrp.DrawString("心脏病住院记录",m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY - 10);
						
								p_intPosY += 20;
								p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
								p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
				
								p_intPosY += 20;
								p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				
								p_intPosY += 20;
								p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
						
								p_intPosY += 20;
								if(m_objPrintInfo.m_dtmInPatientDate != System.DateTime.MinValue)
								{
									p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
								}
								else
								{
									p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								}				
							
								m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
								int intRealHeight;
								Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
								m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
												
								p_intPosY += 30;
								m_blnHaveMoreLine = false;
				#endregion
//				p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,45);
//		
//				p_objGrp.DrawString("药 物 流 产 记 录 表",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,330,75);
//				p_intPosY =130;
//				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}

		#endregion
		#region ECG号---家族史
		/// <summary>
		/// ECG号---家族史
		/// </summary>
		private class clsPrintInPatHeartHospitalMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string[] m_strKeysArr1 = {"ECG号","UCG号","X光号","其他"};	
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
//						m_mthMakeText(new string[]{"姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","  年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},new string [] {"",""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"   职业："+ m_objPrintInfo.m_strOccupation+"；","  日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString()+"；"},new string [] {"",""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n单位："+ m_objPrintInfo.m_strOfficeName+"；"},new string []{""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{ "  家庭住址："+ m_objPrintInfo.m_strHomeAddress+"；"," 电话："+ m_objPrintInfo.m_strHomePhone+"；"},new string [] {"",""},ref strAllText,ref strXml);
						#region 
						m_mthMakeText(new string[]{"\nECG号：","UCG号：","X光号：","其他："},m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n主   诉："},new string[]{"主诉"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n现病史："},new string[]{"现病史"},ref strAllText,ref strXml);
						#endregion

						#region 心血管病症状摘要及既往史
						m_mthMakeText(new string[]{"\n心血管病症状摘要及既往史（第一次出现时间及演变经过）："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n心前区痛："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"开始出现时间："," 诱因："," 部位："," 性质："," 持续时间："},
							          new string[]{"心前区痛>>开始出现时间","心前区痛>>诱因","心前区痛>>部位","心前区痛>>性质","心前区痛>>持续时间"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     放射部位："," 频度："," 缓解方法："},new string[]{"心前区痛>>放射部位","心前区痛>>频度","心前区痛>>缓解方法"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n心   悸："},new string[]{"心悸"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n劳力性呼吸困难："},new string[]{"劳力性呼吸困难"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n休息时呼吸困难："},new string[]{"休息时呼吸困难"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n夜间阵发性呼吸困难："},new string[]{"夜间阵发性呼吸困难"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n咳   嗽："},new string[]{"咳嗽"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n咯   血："},new string[]{"咯血"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n浮   肿："},new string[]{"浮肿"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n腹   胀："},new string[]{"腹胀"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n咽喉痛："},new string[]{"咽喉痛"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n关节痛(炎)："},new string[]{"关节痛(炎)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n眩晕(晕厥)："},new string[]{"眩晕(晕厥)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n紫   绀："},new string[]{"紫绀"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n蹲踞现象："},new string[]{"蹲踞现象"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n其   他："},new string[]{"其它"},ref strAllText,ref strXml);
						#endregion

						#region 个人史
						m_mthMakeText(new string[]{"\n个人史："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n        吸烟：","年 $$","","支/日 $$"},new string[]{"个人史>>吸烟>>年","","个人史>>吸烟>>支/日",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","个人史>>吸烟>>无"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"  饮酒：","年 $$","量："},new string[]{"个人史>>饮酒>>年","","个人史>>饮酒>>量"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","个人史>>饮酒>>无"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"  运动：","个人史>>运动>>经常","个人史>>运动>>一般","个人史>>运动>>少"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"  工作生活环境：","个人史>>工作生活环境>>潮湿","个人史>>工作生活环境>>一般","个人史>>工作生活环境>>良好"},ref strAllText,ref strXml);
						#endregion 个人史

                        #region 月经生育史
						m_mthMakeText(new string[]{"\n月经生育史：(包括历次妊娠、分娩过程心功能情况)"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n        "},new string[]{"月经生育史"},ref strAllText,ref strXml);
						
						#endregion 月经生育史

						#region 家族史：
						m_mthMakeText(new string[]{"\n家族史：(着重与遗传有关的疾病)"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       "},new string[]{"家族史"},ref strAllText,ref strXml);
						#endregion 家族史：             
						
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
		#region 体格检查---扣诊
		/// <summary>
		///  体格检查---诊断
		/// </summary>
		private class clsPrintInPatHeartHospitalSecord : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage=true;
			private int m_intLineYPos = 0;
			private string[] m_strKeysArr1 = {"一般情况>>体温","一般情况>>脉率","一般情况>>呼吸"};
			private string[] m_strKeysArr4 = {"心>>前正中线至锁骨中线距离"};
	
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
						p_intPosY += 20;
						return;
					}
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						p_objGrp.DrawString( "体  格  检  查",new Font("宋体",16),Brushes.Black,350,p_intPosY);

						//m_mthMakeText(new string[]{"                                                              体  格  检  查："},new string[]{""},ref strAllText,ref strXml);
						#region 一般情况
						m_mthMakeText(new string[]{"\n\n一般情况："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"体温："," 脉率："," 呼吸："},m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     血压：左上肢：","mmHg；$$","右上肢：","mmHg；$$","左下肢：","mmHg；$$","右下肢：","mmHg；$$"},
							          new string[]{"一般情况>>血压>>左上肢","","一般情况>>血压>>右上肢","","一般情况>>血压>>左下肢","","一般情况>>血压>>右下肢",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     体位："},new string[]{"一般情况>>体位"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{" 发育："," 营养："," 身高：","cm；$$","体重：","kg；$$"},new string[]{"一般情况>>发育","一般情况>>营养","一般情况>>身高>>cm","","一般情况>>体重>>g",""},ref strAllText,ref strXml);
						#endregion
						#region 皮  肤
						m_mthMakeText(new string[]{"\n皮  肤："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"面容："," 黄疸："," 紫绀："," 淤点淤斑："," 皮下结节："},new string[]{"皮肤>>面容","皮肤>>黄疸","皮肤>>紫绀","皮肤>>淤点淤斑","皮肤>>皮下结点"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n              环形红斑："," 水肿："," 其他："},new string[]{"皮肤>>环形红斑","皮肤>>水肿","皮肤>>其他"},ref strAllText,ref strXml);
						#endregion 
						#region 淋巴结
						m_mthMakeText(new string[]{"\n淋巴结："},new string[]{"淋巴结"},ref strAllText,ref strXml);
						#endregion
						#region 头颈部
						m_mthMakeText(new string[]{"\n头颈部："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"眼睑："," 结膜："," 巩膜："," 瞳孔："," 耳：", " 鼻："},new string[]{"头颈部>>眼睑","头颈部>>结膜","头颈部>>巩膜","头颈部>>瞳孔","头颈部>>耳","头颈部>>鼻"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                   舌："," 龋齿："," 颈静脉："," 肝颈征："," 甲状腺："," 甲状腺："},
							          new string[]{"头颈部>>舌","头颈部>>龋齿","头颈部>>颈静脉","头颈部>>肝颈征","头颈部>>甲状腺","头颈部>>甲状腺"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{" 气管："," 其他："},new string[]{"头颈部>>气管","头颈部>>其他"},ref strAllText,ref strXml);
						#endregion 
						#region 胸部、肺
						m_mthMakeText(new string[]{"\n胸部："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"胸廓形状："," 呼吸方式："},new string[]{"胸部>>胸廓形状","胸部>>呼吸方式"},ref strAllText,ref strXml);   
						m_mthMakeText(new string[]{"\n肺："},new string[]{"肺"},ref strAllText,ref strXml);
						#endregion
						#region 心
						m_mthMakeText(new string[]{"\n心：望诊：心尖搏动( 部位、范围、反常搏动)："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                 "},new string[]{"心>>望诊>>心尖搏动"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n          触诊：心尖搏动："},new string[]{"心>>触诊>>心尖搏动"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；  抬举性搏动：","心>>触诊>>抬举性搏动>>有","心>>触诊>>抬举性搏动>>无"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n              震颤(部位、时期)："},new string[]{"心>>震颤(部位、时期)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n              瓣膜关闭震荡："},new string[]{"心>>瓣膜关闭震荡"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；  心包摩擦感：","心包摩擦感>>有","心包摩擦感>>无"},ref strAllText,ref strXml);
						
					
						#endregion 
						
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
//					
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
		#region 扣诊---诊断
		/// <summary>
		///  体格检查---诊断
		/// </summary>
		private class clsPrintInPatHeartHospitalSecord1 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage=true;
			private int m_intLineYPos = 0;
			private string[] m_strKeysArr1 = {"一般情况>>体温","一般情况>>脉率","一般情况>>呼吸"};
			private string[] m_strKeysArr4 = {"心>>前正中线至锁骨中线距离"};
	
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
						//p_intPosY += 20;
						return;
					}
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"          叩诊：心界如右图，前正中线至锁骨中线距离：","cm$$"},new string[]{"心>>前正中线至锁骨中线距离",""},ref strAllText,ref strXml);
						
						#region 画心界图
						if( m_blnHavePrintInfo(m_strKeysArr4)!= false)
						{  
							if((p_intPosY+200) < ((int)enmRectangleInfo.BottomY -50))
								m_intLineYPos=p_intPosY-110;
							else 
								m_intLineYPos=p_intPosY-110;
							m_mthDrawline(p_objGrp, p_fntNormalText);//画心界图
						}
						#endregion
						#region 听诊
						m_mthMakeText(new string[]{"\n          听诊：心率："," 心律："},new string[]{"心>>听诊>>心率","心>>听诊>>心律"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                心音：S1最响部位："},new string[]{"心>>听诊>>心音>>S1最响部位"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"； 亢进：","心>>听诊>>心音>>亢进>>是","心>>听诊>>心音>>亢进>>否"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n                           减弱：","心>>听诊>>心音>>减弱>>是","心>>听诊>>心音>>减弱>>否"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"分裂：","心>>听诊>>心音>>分裂>>是","心>>听诊>>心音>>分裂>>否"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string[]{"\n                S2：A2：","心>>听诊>>心音>>S2>>A2>>亢进","心>>听诊>>心音>>S2>>A2>>减弱","心>>听诊>>心音>>S2>>A2>>消失","心>>听诊>>心音>>S2>>A2>>分裂"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string[]{" P2：","心>>听诊>>心音>>S2>>P2>>亢进","心>>听诊>>心音>>S2>>P2>>减弱","心>>听诊>>心音>>S2>>P2>>消失","心>>听诊>>心音>>S2>>P2>>分裂"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                S3："},new string[]{"心>>听诊>>心音>>S3"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                S4："},new string[]{"心>>听诊>>心音>>S4"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                奔马律：(部位、房性、室性)："},new string[]{"心>>听诊>>奔马律"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                附加音：(包括喷射音、喀刺音、拍击音、扑落音等的部位、时期)："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     "},new string[]{"心>>听诊>>附加音"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                杂音：(部位、时期、性质、强度、传导、与呼吸及 体位的关系)："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                二尖瓣区："},new string[]{"心>>听诊>>杂音>>二尖瓣区"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                主动脉瓣区："},new string[]{"心>>听诊>>杂音>>主动脉瓣区"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                肺动脉瓣区："},new string[]{"心>>听诊>>杂音>>肺动脉瓣区"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                三尖瓣区："},new string[]{"心>>听诊>>杂音>>三尖瓣区"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                胸骨左缘："},new string[]{"心>>听诊>>杂音>>胸骨左缘"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                心包摩擦音："," 其他："},new string[]{"心>>听诊>>杂音>>心包摩擦音","心>>听诊>>杂音>>其他"},ref strAllText,ref strXml);
						#endregion 听诊
						m_mthMakeText(new string[]{"\n周围血管征：枪击音："," 水冲脉："},new string[]{"周围血管征>>枪击音","周围血管征>>水冲脉"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；交替脉："," 毛细血管搏动："," 其他："},new string[]{"周围血管征>>交替脉","周围血管征>>毛细血管搏动","周围血管征>>其他1"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n腹    部： 肝："},new string[]{"腹部>>肝"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                脾："," 肾："},new string[]{"腹部>>脾","腹部>>肾"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                血管杂音：","腹水怔："},new string[]{"腹部>>血管杂音","腹部>>腹水怔"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                其他："},new string[]{"腹部>>其他"},ref strAllText,ref strXml);
						
						#region 四肢--诊断
						m_mthMakeText(new string[]{"\n四    肢：杵状指(趾)：","畸形：","其他："},new string[]{"四肢>>杵状指(趾)","四肢>>畸形","四肢>>其他"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n脊    柱："},new string[]{"脊柱"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n神经反射："},new string[]{"神经反射"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n心血管外科情况："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       "},new string[]{"心血管外科情况"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n诊断：(包括病因、病理解剖、病理生理、功能分级、并发症及伴发症)"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       "},new string[]{"诊断"},ref strAllText,ref strXml);
						#endregion 四肢--诊断
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
					//					
					m_blnHaveMoreLine = false;
				}
			}
			private void m_mthDrawline(System.Drawing.Graphics p_objGrp,System.Drawing.Font p_fntNormalText)
			{
					//m_intLineYPos += 20;
				clsInpatMedRec_Item[] objItemContentArr = null;
				objItemContentArr = m_objGetContentFromItemArr(new string[]{"外科情况>>叩诊>>心界图>>II>>左","外科情况>>叩诊>>心界图>>II>>右","外科情况>>叩诊>>心界图>>III>>左","外科情况>>叩诊>>心界图>>III>>右"
																			   ,"外科情况>>叩诊>>心界图>>IV>>左","外科情况>>叩诊>>心界图>>IV>>右","外科情况>>叩诊>>心界图>>V>>左","外科情况>>叩诊>>心界图>>V>>右"
																			   ,"外科情况>>叩诊>>心界图>>IV>>左","外科情况>>叩诊>>心界图>>IV>>右"});
				if(objItemContentArr != null)
				{
					#region 打印心电图表
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+100 ,768-3,m_intLineYPos+100);
					p_objGrp.DrawString((objItemContentArr[0] == null ? "" :(objItemContentArr[0].m_strItemContent == null ? "" : objItemContentArr[0].m_strItemContent)),p_fntNormalText,Brushes.Black,625-3,m_intLineYPos+102);
					p_objGrp.DrawString("Ⅱ",p_fntNormalText,Brushes.Black,687-3,m_intLineYPos+102);
					p_objGrp.DrawString((objItemContentArr[1] == null ? "" :(objItemContentArr[1].m_strItemContent == null ? "" : objItemContentArr[1].m_strItemContent)),p_fntNormalText,Brushes.Black,716-3,m_intLineYPos+102);
					
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+120 ,768-3,m_intLineYPos+120);
					p_objGrp.DrawString((objItemContentArr[2] == null ? "" :(objItemContentArr[2].m_strItemContent == null ? "" : objItemContentArr[2].m_strItemContent)),p_fntNormalText,Brushes.Black,625-3,m_intLineYPos+122);
					p_objGrp.DrawString("Ⅲ",p_fntNormalText,Brushes.Black,687-3,m_intLineYPos+122);
					p_objGrp.DrawString((objItemContentArr[3] == null ? "" :(objItemContentArr[3].m_strItemContent == null ? "" : objItemContentArr[3].m_strItemContent)),p_fntNormalText,Brushes.Black,716-3,m_intLineYPos+122);
					
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+140 ,768-3,m_intLineYPos+140);
					p_objGrp.DrawString((objItemContentArr[4] == null ? "" :(objItemContentArr[4].m_strItemContent == null ? "" : objItemContentArr[4].m_strItemContent)),p_fntNormalText,Brushes.Black,625-3,m_intLineYPos+142);
					p_objGrp.DrawString("Ⅳ",p_fntNormalText,Brushes.Black,687-3,m_intLineYPos+142);
					p_objGrp.DrawString((objItemContentArr[5] == null ? "" :(objItemContentArr[5].m_strItemContent == null ? "" : objItemContentArr[5].m_strItemContent)),p_fntNormalText,Brushes.Black,716-3,m_intLineYPos+142);
					
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+160 ,768-3,m_intLineYPos+160);
					p_objGrp.DrawString((objItemContentArr[6] == null ? "" :(objItemContentArr[6].m_strItemContent == null ? "" : objItemContentArr[6].m_strItemContent)),p_fntNormalText,Brushes.Black,625-3,m_intLineYPos+162);
					p_objGrp.DrawString("Ⅴ",p_fntNormalText,Brushes.Black,687-3,m_intLineYPos+162);
					p_objGrp.DrawString((objItemContentArr[7] == null ? "" :(objItemContentArr[7].m_strItemContent == null ? "" : objItemContentArr[7].m_strItemContent)),p_fntNormalText,Brushes.Black,716-3,m_intLineYPos+162);
					
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+180 ,768-3,m_intLineYPos+180);
					p_objGrp.DrawString((objItemContentArr[8] == null ? "" :(objItemContentArr[8].m_strItemContent == null ? "" : objItemContentArr[8].m_strItemContent)),p_fntNormalText,Brushes.Black,625-3,m_intLineYPos+182);
					p_objGrp.DrawString("Ⅵ",p_fntNormalText,Brushes.Black,687-3,m_intLineYPos+182);
					p_objGrp.DrawString((objItemContentArr[9] == null ? "" :(objItemContentArr[9].m_strItemContent == null ? "" : objItemContentArr[9].m_strItemContent)),p_fntNormalText,Brushes.Black,716-3,m_intLineYPos+182);
					
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+200 ,768-3,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,685-3,m_intLineYPos+100 ,685-3,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,715-3,m_intLineYPos+100 ,715-3,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,625-3,m_intLineYPos+100 ,625-3,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,768-3,m_intLineYPos+100 ,768-3,m_intLineYPos+200);


					#endregion
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
				objItemContent = m_objGetContentFromItemArr(new string[]{"修正诊断","初步诊断","手术者","助手","记录医生"});
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
				p_objGrp.DrawString("记录医生："+ (objItemContent[4] == null ? "" :(objItemContent[4].m_strItemContent == null ? "":objItemContent[4].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+500,p_intPosY);
				
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
