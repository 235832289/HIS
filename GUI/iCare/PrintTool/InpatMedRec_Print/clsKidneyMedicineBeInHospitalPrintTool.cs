
using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
	/// <summary>
	/// 肾内科住院病历
	/// </summary>
	public class clsKidneyMedicineBeInHospitalPrintTool : clsInpatMedRecPrintBase
	{
		public clsKidneyMedicineBeInHospitalPrintTool(string p_strTypeID) : base(p_strTypeID)
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
																		   new clsPrint2(),
																		   new clsPrint3(),
																		   new clsPrint4(),
																		   new clsPrint5(),
																		   new clsPrint6(),
																		   new clsPrint7(),
																		   new clsPrint8(),
																		   new clsPrint9(),
																		   new clsPrint10(),
																		   new clsPrint11(),
																		   new clsPrint12(),
																		   new clsPrint13(),
																		   new clsPrint14(),
																		   new clsPrint15(),
																		   new clsPrint16(),
																		   new clsPrint17()
																	   });			
		}

		
		#region 打印实现

		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_objGrp.DrawString("肾内科住院病历",m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY - 10);
		
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
				if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
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
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}

		#endregion

		#region 打印电话 邮编  民族
		/// <summary>
		/// 打印电话 邮编  民族
		/// </summary>
		private class clsPrint2 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"电话","邮编","民族"};
			private string[] m_strKeysArr101 = {"电话：","          邮编：","          民族："};

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						
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

		#region 主诉
		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrint3 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("主诉"))
						objItemContent = m_hasItems["主诉"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("主诉：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("主诉",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 现病史
		/// <summary>
		/// 现病史
		/// </summary>
		private class clsPrint4 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("现病史"))
						objItemContent = m_hasItems["现病史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("现病史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("现病史",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 既往史
		/// <summary>
		/// 既往史
		/// </summary>
		private class clsPrint5 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","既往史>>腰痛","既往史>>部位","既往史>>性质","既往史>>伴发症状","既往史>>水肿","既往史>>水肿>>部位","既往史>>尿水","既往史>>尿少>>伴发症状","既往史>>排尿困难"};
			private string[] m_strKeysArr101 = {"既往史：","\n            腰痛年数：","部位：","性质：","伴发症状：","水肿年数：","水肿部位：","尿水：","伴发症状：","排尿困难："};
			private string[] m_strKeysArr02  = {"","既往史>>尿频","既往史>>尿急","既往史>>尿痛"};
			private string[] m_strKeysArr102 = {"","既往史>>尿频","既往史>>尿急","既往史>>尿痛"};
			private string[] m_strKeysArr03  = {"既往史>>尿>>年"};
			private string[] m_strKeysArr103 = {"年数："};
			private string[] m_strKeysArr04  = {"既往史>>血尿","既往史>>夜尿增多","既往史>>高血压","既往史>>糖尿病","既往史>>其他","既往史>>手术史","既往史>>过敏史","既往史>>过敏源","既往史>>症状"};
			private string[] m_strKeysArr104 = {"血尿：","夜尿增多：","高血压：","糖尿病：","其他：","手术史：","过敏史：","过敏源：","症状："};
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
						
			
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

		#region 个人史
		/// <summary>
		/// 个人史
		/// </summary>
		private class clsPrint6 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {""};
			private string[] m_strKeysArr101 = {"个人史："};
			private string[] m_strKeysArr010  = {""};
			private string[] m_strKeysArr1010 = {"\n            吸烟："};

			private string[] m_strKeysArr02  = {"有无吸烟：","个人史>>吸烟>>有","个人史>>吸烟>>无"};
			private string[] m_strKeysArr102 = {"有无吸烟：","个人史>>吸烟>>有","个人史>>吸烟>>无"};
			private string[] m_strKeysArr03  = {"个人史>>吸烟>>年","个人史>>吸烟>>支/日"};
			private string[] m_strKeysArr103 = {"吸烟年数：","吸烟数(单位:支/日)："};
			private string[] m_strKeysArr04  = {"；工作生活环境：","个人史>>工作生活环境>>潮湿","个人史>>工作生活环境>>一般","个人史>>工作生活环境>>良好"};
			private string[] m_strKeysArr104 = {"；工作生活环境：","个人史>>工作生活环境>>潮湿","个人史>>工作生活环境>>一般","个人史>>工作生活环境>>良好"};
			private string[] m_strKeysArr05  = {"有无喝酒：","个人史>>喝酒>>有","个人史>>喝酒>>无"};
			private string[] m_strKeysArr105 = {"有无喝酒：","个人史>>喝酒>>有","个人史>>喝酒>>无"};
			private string[] m_strKeysArr06  = {"个人史>>喝酒>>年","个人史>>喝酒>>毫升/日"};
			private string[] m_strKeysArr106 = {"喝酒年数：","喝酒数(单位:毫升/日)："};
			private string[] m_strKeysArr07  = {"个人史>>夜游史","个人史>>其他"};
			private string[] m_strKeysArr107 = {"夜游史：","其他："};

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
			 
						m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						m_mthMakeText(m_strKeysArr1010,m_strKeysArr010,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr105,ref strAllText,ref strXml);
					
						if(m_blnHavePrintInfo(m_strKeysArr06) != false)
							m_mthMakeText(m_strKeysArr106,m_strKeysArr06,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr07) != false)
							m_mthMakeText(m_strKeysArr107,m_strKeysArr07,ref strAllText,ref strXml);
			
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

		#region 月经史
		/// <summary>
		/// 月经史
		/// </summary>
		private class clsPrint7 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("月经史"))
						objItemContent = m_hasItems["月经史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("月经史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("月经史",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 家族史
		/// <summary>
		/// 家族史
		/// </summary>
		private class clsPrint8 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("家族史"))
						objItemContent = m_hasItems["家族史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("家族史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("家族史",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 打印 体格检查>>生命体征 到  淋巴结
		/// <summary>
		/// 打印 体格检查>>生命体征 到  淋巴结
		/// </summary>
		private class clsPrint9 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","体格检查>>一般情况>>T","体格检查>>一般情况>>P","体格检查>>一般情况>>R","体格检查>>一般情况>>BP"};
			private string[] m_strKeysArr101 = {"生命体征:","\n        T(摄氏度)：","P(次/分)：","R(次/分)：","BP(mmHg)："};
			private string[] m_strKeysArr02  = {"","体格检查>>一般情况>>神志","体格检查>>一般情况>>精神","体格检查>>一般情况>>体位","体格检查>>一般情况>>发育","体格检查>>一般情况>>营养发育","体格检查>>一般情况>>体重"};
			private string[] m_strKeysArr102 = {"\n一般情况:","\n        神志：","精神：","体位：","发育：","营养：","体重："};
			private string[] m_strKeysArr03  = {"","体格检查>>皮肤>>色泽","体格检查>>皮肤>>皮疹","体格检查>>皮肤>>皮下出血","体格检查>>皮肤>>蜘蛛痣","体格检查>>皮肤>>皮肤弹性","体格检查>>皮肤>>部位","体格检查>>皮肤>>其他","体格检查>>皮肤>>水肿"};
			private string[] m_strKeysArr103 = {"\n皮肤：","\n        色泽：","皮疹：","皮下出血：","蜘蛛痣：","皮肤弹性：","部位：","其他：","水肿："};
			private string[] m_strKeysArr04  = {"体格检查>>淋巴结"};
			private string[] m_strKeysArr104 = {"\n        淋巴结："};
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;					
					p_objGrp.DrawString("体格检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 20;
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{					
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
						
			
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

		#region 打印 头颈部:
		/// <summary>
		/// 打印头颈部:
		/// </summary>
		private class clsPrint10 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","体格检查>>头颈部>>头颅","体格检查>>头颈部>>眼脸","体格检查>>头颈部>>结膜","体格检查>>头颈部>>巩膜","体格检查>>头颈部>>瞳孔","体格检查>>头颈部>>耳","体格检查>>头颈部>>鼻","体格检查>>头颈部>>牙","体格检查>>头颈部>>舌","体格检查>>头颈部>>口腔粘膜","体格检查>>头颈部>>扁桃体","体格检查>>头颈部>>颈静脉","体格检查>>头颈部>>肝项征","体格检查>>头颈部>>甲状腺","体格检查>>头颈部>>气管"};
			private string[] m_strKeysArr101 = {"头颈部:","\n        头颅：","眼脸：","结膜：","巩膜：","瞳孔：","耳：","鼻：","牙：","舌：","口腔粘膜：","扁桃体：","颈静脉：","肝项征：","甲状腺：","气管："};
	
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						
			
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

		#region 打印 胸部与心脏
		/// <summary>
		/// 胸部与心脏:
		/// </summary>
		private class clsPrint11 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","体格检查>>胸部>>胸廊","体格检查>>胸部>>呼吸方式","体格检查>>胸部>>胸骨压痛","体格检查>>胸部>>肺"};
			private string[] m_strKeysArr101 = {"胸部:","\n        胸廊形状：","呼吸方式：","胸骨压痛：","肺："};
			private string[] m_strKeysArr02  = {"","体格检查>>心脏>>心尖搏动","体格检查>>心脏>>心界","体格检查>>心脏>>心率","体格检查>>心脏>>心律","体格检查>>心脏>>心脏杂音","体格检查>>心脏>>其他"};
			private string[] m_strKeysArr102 = {"\n心脏:","\n        心尖搏动：","心界：","心率：","心律：","心脏杂音：","其他："};
	
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
			
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

		#region 打印 腹部
		/// <summary>
		/// 腹部:
		/// </summary>
		private class clsPrint12 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","体格检查>>腹部>>压痛","体格检查>>腹部>>反跳痛","体格检查>>腹部>>肝","体格检查>>腹部>>脾","体格检查>>腹部>>胆囊","体格检查>>腹部>>包块","体格检查>>腹部>>肠鸣音","体格检查>>腹部>>腹水征","体格检查>>腹部>>外形","体格检查>>腹部>>其他","体格检查>>腹部>>肾","体格检查>>腹部>>质地","体格检查>>腹部>>移动度","体格检查>>腹部>>肾压痛","体格检查>>腹部>>输尿管点压痛"};
			private string[] m_strKeysArr101 = {"腹部:","\n        压痛：","反跳痛：","肝：","脾：","胆囊：","包块：","肠鸣音：","腹水征：","外形：","其他：","肾：","质地：","移动度：","肾压痛：","输尿管点压痛："};
			private string[] m_strKeysArr02  = {"肾区叩痛:","体格检查>>腹部>>肾区叩痛>>肋腰点","体格检查>>腹部>>肾区叩痛>>肋棘点"};
			private string[] m_strKeysArr102 = {"肾区叩痛:","体格检查>>腹部>>肾区叩痛>>肋腰点","体格检查>>腹部>>肾区叩痛>>肋棘点"};
			private string[] m_strKeysArr03  = {"体格检查>>腹部>>肾区叩痛>>肋棘点2"};
			private string[] m_strKeysArr103 = {""};
			private string[] m_strKeysArr04  = {"体格检查>>肛门及外生殖器"};
			private string[] m_strKeysArr104 = {"\n肛门及外生殖器："};
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
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

		#region 打印 脊  柱: 四肢肌肉: 神经系统:
		/// <summary>
		///  脊  柱: 四肢肌肉: 神经系统:
		/// </summary>
		private class clsPrint13 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			//			private string[] m_strKeysArr01  = {"","","","","",};
			//			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
			//          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
			private string[] m_strKeysArr01  = {"","体格检查>>脊柱>>外形","体格检查>>脊柱>>棘突压、叩痛","体格检查>>脊柱>>部位","体格检查>>脊柱>>活动度"};
			private string[] m_strKeysArr101 = {"脊柱:","\n        外形：","棘突压、叩痛：","部位：","活动度："};
			private string[] m_strKeysArr02  = {"","体格检查>>四肢肌肉>>外形","体格检查>>四肢肌肉>>关节"};
			private string[] m_strKeysArr102 = {"\n四肢肌肉:","\n        外形","关节"};
			private string[] m_strKeysArr03  = {"","体格检查>>神经系统>>肌力","体格检查>>神经系统>>肌张力","体格检查>>神经系统>>生理反射","体格检查>>神经系统>>病理反射"};
			private string[] m_strKeysArr103 = {"\n        神经系统：","\n        肌力：","肌张力：","生理反射：","病理反射："};

			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
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
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
					if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						
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

		#region 体格检查辅助检查
		/// <summary>
		/// 体格检查辅助检查
		/// </summary>
		private class clsPrint14 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("体格检查>>辅助检查"))
						objItemContent = m_hasItems["体格检查>>辅助检查"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("辅助检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("辅助检查",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 出院诊断
		/// <summary>
		/// 出院诊断病史
		/// </summary>
		private class clsPrint15 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("体格检查>>出院诊断"))
						objItemContent = m_hasItems["体格检查>>出院诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("出院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("出院诊断",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion

		#region 初步诊断
		/// <summary>
		/// 初步诊断
		/// </summary>
		private class clsPrint16 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("体格检查>>初步诊断"))
						objItemContent = m_hasItems["体格检查>>初步诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("初步诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("初步诊断",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;	
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					p_intPosY += 20;
					m_intTimes++;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		#endregion


		#region 主治医师
		/// <summary>
		///  主治医师
		/// </summary>
		private class clsPrint17 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
			private string[] m_strKeysArr01 = {"主治医师","住院医师"};
			private string[] m_strKeysArr101 = {"                              主治医师：","                                                  住院医师："};
	


 
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				//				if(blnNextPage)
				//				{
				//					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
				//					m_blnHaveMoreLine = true;
				//					blnNextPage = false;
				//					p_intPosY += 1500;
				//					return;
				//				}
				if(m_blnIsFirstPrint)
				{
					//					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					//					p_intPosY += 20;
					//					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
					//					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
			
								
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("检查者签字",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
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

	
		#endregion
	}

}

