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
	/// 产科普通住院病历打印
	/// </summary>
	public class clsObstetricCaseHisPrintTool: clsInpatMedRecPrintBase
	{
		public clsObstetricCaseHisPrintTool(string p_strTypeID) :base(p_strTypeID)
		{}
		
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		protected override void m_mthSetPrintLineArr()
		{
			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("产科住院病历",310),
										  new clsPrintInPatMedRecMain(),
										  m_objPrintOneItemArr[0],
										  m_objPrintOneItemArr[1],
										  m_objPrintOneItemArr[2],
										  m_objPrintOneItemArr[3],
										  m_objPrintOneItemArr[4],
										  m_objPrintOneItemArr[5],
										  m_objPrintOneItemArr[6],
										  m_objPrintOneItemArr[7],
										  new clsPrintInPatientBodyChekcFixStatus(),
										  m_objPrintOneItemArr[8],
										  new clsPrintInPatMedRecPic(),
										  m_objPrintOneItemArr[9],
										  new clsPrintPatientPrimaryDiagnoseInfo()
									  });
		}
		
		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[10];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

		}
		protected override void m_mthSetSubPrintInfo()
		{
			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("现病史","现病史：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("临产情况","临产情况：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("既往史","既往史：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("月经史","月经史：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("婚姻史","婚姻史：");
			m_objPrintOneItemArr[5].m_mthSetPrintValue("生育史","生育史：");
			m_objPrintOneItemArr[6].m_mthSetPrintValue("产前检查情况","产前检查情况：");
			m_objPrintOneItemArr[7].m_mthSetPrintValue("家族史","家族史：");
			m_objPrintOneItemArr[8].m_mthSetPrintValue("专科检查","专科检查：");
			m_objPrintOneItemArr[9].m_mthSetPrintValue("辅助检查","辅助检查：");
			#endregion	
		}
		#region Print Class

		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatMedRecMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			private clsInpatMedRec_Item objItemContent = null;
			private clsInpatMedRec_Item[] objItemContentArr = null;
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_mthPrintPregnantAndBirth(ref p_intPosY,p_objGrp,p_fntNormalText);
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
					p_intPosY += 20;

					p_objGrp.DrawString("主诉：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("主诉：",m_objPrintContext.m_ObjModifyUserArr);


					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+60,p_intPosY,p_objGrp);

					p_intPosY += 20;

					intLine++;
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

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}

			private void m_mthPrintPregnantAndBirth(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContentArr = m_objGetContentFromItemArr(new string[]{"孕次","产次"});
				if(objItemContentArr == null)
				{
					p_objGrp.DrawString("孕：    次" ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
					p_objGrp.DrawString("产：    次" ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
					return;
				}
				if(objItemContentArr[0] != null)
					p_objGrp.DrawString("孕："+(objItemContentArr[0]==null ? "    " : objItemContentArr[0].m_strItemContent) +"次",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				if(objItemContentArr[1] != null)
					p_objGrp.DrawString("产："+(objItemContentArr[1]==null ? "    " : objItemContentArr[1].m_strItemContent)  +"次",p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
			}
		}
		/// <summary>
		///体格检查内容
		/// </summary>
		private class clsPrintInPatientBodyChekcFixStatus : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;
			
			private clsInpatMedRec_Item objItemContent = null;
			private clsInpatMedRec_Item[] objChekcContent = null;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("体格检查"))
						objItemContent = m_hasItems["体格检查"] as clsInpatMedRec_Item;
				objChekcContent = m_objGetContentFromItemArr(new string[]{"体温","脉搏","呼吸","收缩压","舒张压"});

				if(m_hasItems == null && objItemContent == null && objChekcContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 10;
					if((p_intPosY+10) > 940)
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("体 格 检 查",clsObstetricCaseHisPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+320,p_intPosY);
			

					if(objChekcContent!=null)
					{
						p_intPosY += 30;
						string strAllText = "        体温："+(objChekcContent[0]==null ? " " : objChekcContent[0].m_strItemContent)+"℃、"+
							"脉搏："+(objChekcContent[1]==null ? " " : objChekcContent[1].m_strItemContent)+"次/分、"+
							"呼吸："+(objChekcContent[2]==null ? " " : objChekcContent[2].m_strItemContent)+"次/分、"+
							"血压："+(objChekcContent[3]==null ? " " : objChekcContent[3].m_strItemContent)+"/"+(objChekcContent[4]==null ? 
							" " : objChekcContent[4].m_strItemContent)+"mmHg。";
						if(objItemContent != null)
							strAllText += objItemContent.m_strItemContent;
						string strNormalXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("        体温："+(objChekcContent[0]==null ? " " : objChekcContent[0].m_strItemContent)+"℃、"+
							"脉搏："+(objChekcContent[1]==null ? " " : objChekcContent[1].m_strItemContent)+"次/分、"+
							"呼吸："+(objChekcContent[2]==null ? " " : objChekcContent[2].m_strItemContent)+"次/分、"+
							"血压："+(objChekcContent[3]==null ? " " : objChekcContent[3].m_strItemContent)+"/"+(objChekcContent[4]==null ? 
							" " : objChekcContent[4].m_strItemContent)+"mmHg。",m_objContent.m_strCreateUserID,new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName,Color.Black);
						string strXml = ctlRichTextBox.s_strCombineXml(new string[]{strNormalXml,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml)});

						m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText  ,strXml,m_dtmFirstPrintTime,m_objContent!=null);

				

						m_mthAddSign2("体格检查：",m_objPrintContext.m_ObjModifyUserArr);

						m_blnIsFirstPrint = false;	
					}
					else
					{
						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}

				}
			
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);

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
	

		/// <summary>
		///入院诊断与治疗计划   
		/// </summary>
		private class clsPrintPatientPrimaryDiagnoseInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;
			private clsInpatMedRec_Item[] objChekcContent = null;
		
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objChekcContent = m_objGetContentFromItemArr(new string[]{"入院诊断","治疗计划","主治医师","助产士"});
			
				if(objChekcContent == null || m_hasItems == null)
				{
					p_intPosY += 20;
                    p_objGrp.DrawString("记录者签名：" + ((m_objContent==null || m_objContent.m_strCreateUserID == null) ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
                    

					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnIsFirstPrint)
				{	
					p_intPosY += 20;
					p_objGrp.DrawString("入院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_objGrp.DrawString("治疗计划：",p_fntNormalText,Brushes.Black,m_intRecBaseX+360,p_intPosY);
					p_intPosY += 20;
					if(objChekcContent[0] != null)
					{
						m_objPrintContext1.m_mthSetContextWithCorrectBefore((objChekcContent[0].m_strItemContent==null ? "" : objChekcContent[0].m_strItemContent)  ,(objChekcContent[0].m_strItemContentXml==null ? "<root />" : objChekcContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objChekcContent[0]!=null);
						m_mthAddSign2("入院诊断：",m_objPrintContext1.m_ObjModifyUserArr);
					}
					if (objChekcContent[1] != null)
					{
						m_objPrintContext2.m_mthSetContextWithCorrectBefore((objChekcContent[1].m_strItemContent==null ? "" : objChekcContent[1].m_strItemContent)  ,(objChekcContent[1].m_strItemContentXml==null ? "<root />" : objChekcContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objChekcContent[1]!=null);
						m_mthAddSign2("治疗计划：",m_objPrintContext2.m_ObjModifyUserArr);
					}
					m_blnIsFirstPrint = false;					
			
				}
			
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine() )
				{
					m_objPrintContext1.m_mthPrintLine(330,m_intRecBaseX+50,p_intPosY,p_objGrp);
					m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+380,p_intPosY,p_objGrp);
					p_intPosY += 20;

					m_intTimes++;
				}
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine() )
					m_blnHaveMoreLine = true;
				else
				{
					p_intPosY += 20;
					if(m_objContent != null)
						p_objGrp.DrawString("记录者签名："+(m_objContent.m_strCreateUserID==null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);


					p_intPosY += 60;

					m_blnHaveMoreLine = false;
				}
			}
			
			private void m_mthPrintDocSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

//				if(objChekcContent[2] != null)
//				{
//					p_objGrp.DrawString("主治医师："+(objChekcContent[2].m_strItemContent==null ? "" : objChekcContent[2].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
//				}
				p_objGrp.DrawString("住院医师："+(m_objContent==null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+250,p_intPosY);
				
//				if(objChekcContent[2] != null)
//				{
//					p_objGrp.DrawString("助产士："+(objChekcContent[3].m_strItemContent==null ? "" : objChekcContent[3].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
//				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}

		#region print Class

		
		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			#region Define
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strTitle = "";
			private clsInpatMedRec_Item m_objItemContent = null;

			private int m_intPrintXPos = 0;
			private int m_intPrintwidth = 0;
			#endregion

			public clsPrintInPatMedRecItem()
			{
				m_intPrintXPos = m_intRecBaseX;
				m_intPrintwidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objItemContent == null || m_hasItems == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "" && m_objItemContent != null)
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intPrintXPos+10,p_intPosY);
						p_intPosY += 20;
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent.m_strItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent.m_strItemContentXml==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(m_intPrintwidth,m_intPrintXPos+50,p_intPosY,p_objGrp);
					p_intPosY += 20;

					intLine++;
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

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}

			/// <summary>
			/// 设置单项打印内容
			/// </summary>
			/// <param name="p_strKey">哈希键</param>
			/// <param name="p_strTitle">小标题</param>
			public void m_mthSetPrintValue(string p_strKey,string p_strTitle)
			{
				if(m_hasItems != null && p_strKey != null)
					if(m_hasItems.Contains(p_strKey))
						m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
				m_strTitle = p_strTitle;
			}

		}
		#endregion
		#endregion Print Class
	}
}
