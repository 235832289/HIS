using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 心血管外科住院病历打印工具类
	/// </summary>
	public class clsIMR_CardiovascularPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_CardiovascularPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
		}

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("心血管外科住院病历",280),
										  new clsPrintInPatMedRecCaseMain(),
										  new clsPrintInPatMedRecCaseCurrent(),
										  new clsPrintInPatMedRecCardiovascular(),
										  new clsPrintInPatMedRecBeforetimeStatus(),
										  new clsPrintInPatMedRecIndividual(),
										  new clsPrintInPatMedRecBirthHist(),
										  new clsPrintInPatMedRecFamily(),
										  new clsPrintInPatMedRecMedical(),
										  new clsPrintInPatMedRecSurgery(),
								new clsPrintInPatMedRecPic(),
										  new clsPrintInPatMedRecDiagnostic(),
										  new clsPrintInPatMedRecCurePaln(),
                    new clsPrintInPatMedRecDia2(),
                    new clsPrintInPatMedRecDia3()
									  });
        }

		#region print class

		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

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
		}

		/// <summary>
		/// 现病史
		/// </summary>
		private class clsPrintInPatMedRecCaseCurrent : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item objItemContent = null;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

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
					m_mthAddSign2("现病史：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
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
		}

		/// <summary>
		/// 心血管病症状摘要
		/// </summary>
		private class clsPrintInPatMedRecCardiovascular : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"","心血管病症状摘要>>心前区痛>>开始出现时间","心血管病症状摘要>>心前区痛>>诱因","心血管病症状摘要>>心前区痛>>部位","心血管病症状摘要>>心前区痛>>性质","心血管病症状摘要>>心前区痛>>持续时间"
												 ,"心血管病症状摘要>>心前区痛>>放射部位","心血管病症状摘要>>心前区痛>>频度","心血管病症状摘要>>心前区痛>>缓解方法"};
			private string[] m_strKeysArr2 = {"心血管病症状摘要>>心悸","心血管病症状摘要>>劳力性气促","心血管病症状摘要>>休息时气促","心血管病症状摘要>>夜间阵发呼吸困难","心血管病症状摘要>>咳嗽","心血管病症状摘要>>咯血","心血管病症状摘要>>浮肿"
											 ,"心血管病症状摘要>>腹涨","心血管病症状摘要>>咽喉痛","心血管病症状摘要>>关节痛(炎)","心血管病症状摘要>>眩晕(晕厥)","心血管病症状摘要>>紫绀","心血管病症状摘要>>蹲踞现象","心血管病症状摘要>>其他"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("心血管病症状摘要：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"\n心前区痛：","开始出现时间：","诱因：","部位：","性质：","持续时间：","放射部位：","频度：","缓解方法："},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\n心悸：","劳力性气促：","休息时气促：","夜间阵发呼吸困难：","咳嗽：","咯血：","浮肿："
														  ,"腹涨：","咽喉痛：","关节痛(炎)：","眩晕(晕厥)：","紫绀：","蹲踞现象：","其他"},m_strKeysArr2,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("心血管病症状摘要：",m_objPrintContext.m_ObjModifyUserArr);

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
		/// <summary>
		/// 既往史
		/// </summary>
		private class clsPrintInPatMedRecBeforetimeStatus : clsIMR_PrintLineBase
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
				if(m_hasItems.Contains("既往史"))
					objItemContent = m_hasItems["既往史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("既往史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("既往史：",m_objPrintContext.m_ObjModifyUserArr);
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
		/// <summary>
		/// 个人史
		/// </summary>
		private class clsPrintInPatMedRecIndividual : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"","个人史>>吸烟年数","个人史>>吸烟数量","","个人史>>饮酒年数","个人史>>饮酒数量","个人史>>运动","个人史>>工作环境"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false ) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("个人史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"吸烟：","","每日：","饮酒：","","量：","运动：","工作环境："},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("个人史：",m_objPrintContext.m_ObjModifyUserArr);
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
		/// <summary>
		/// 月经生育史
		/// </summary>
		private class clsPrintInPatMedRecBirthHist : clsIMR_PrintLineBase
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
				if(m_hasItems.Contains("月经生育史"))
					objItemContent = m_hasItems["月经生育史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("月经生育史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("月经生育史：",m_objPrintContext.m_ObjModifyUserArr);


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
		/// <summary>
		/// 家族史
		/// </summary>
		private class clsPrintInPatMedRecFamily : clsIMR_PrintLineBase
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
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("家族史：",m_objPrintContext.m_ObjModifyUserArr);


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
		/// <summary>
		/// 体格检查
		/// </summary>
		private class clsPrintInPatMedRecMedical : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"","体格检查>>一般情况>>体温","体格检查>>一般情况>>体温","体格检查>>一般情况>>脉搏","体格检查>>一般情况>>脉搏","体格检查>>一般情况>>呼吸","体格检查>>一般情况>>呼吸","","体格检查>>一般情况>>血压>>左上肢高","体格检查>>一般情况>>血压>>左上肢高"
											,"体格检查>>一般情况>>血压>>左上肢低","体格检查>>一般情况>>血压>>左上肢低","体格检查>>一般情况>>血压>>右上肢高","体格检查>>一般情况>>血压>>右上肢高","体格检查>>一般情况>>血压>>右上肢低","体格检查>>一般情况>>血压>>右上肢低","体格检查>>一般情况>>血压>>左下肢高","体格检查>>一般情况>>血压>>左下肢高","体格检查>>一般情况>>血压>>左下肢低","体格检查>>一般情况>>血压>>左下肢低"
											,"体格检查>>一般情况>>血压>>右下肢高","体格检查>>一般情况>>血压>>右下肢高","体格检查>>一般情况>>血压>>右下肢低","体格检查>>一般情况>>血压>>右下肢低","体格检查>>一般情况>>体位","体格检查>>一般情况>>发育","体格检查>>一般情况>>营养","体格检查>>一般情况>>身高","体格检查>>一般情况>>身高","体格检查>>一般情况>>体重","体格检查>>一般情况>>体重"};
			private string[] m_strKeysArr2 = {"","体格检查>>皮肤>>黄疸","体格检查>>皮肤>>紫绀","体格检查>>皮肤>>水肿","体格检查>>皮肤>>其他","体格检查>>皮肤>>淤点淤斑","体格检查>>皮肤>>皮下结节","体格检查>>皮肤>>环形红斑"};
			private string[] m_strKeysArr3 = {"体格检查>>淋巴结"};
			private string[] m_strKeysArr4 = {"","体格检查>>头颈部>>眼睑","体格检查>>头颈部>>结膜","体格检查>>头颈部>>巩膜","体格检查>>头颈部>>扁桃体","体格检查>>头颈部>>颈静脉","体格检查>>头颈部>>肝颈征","体格检查>>头颈部>>气管"};
			private string[] m_strKeysArr5 = {"","体格检查>>胸廓","体格检查>>呼吸方式","体格检查>>肺",""};
			private string[] m_strKeysArr6 = {"","体格检查>>腹部>>肝","体格检查>>腹部>>脾","体格检查>>腹部>>肾","体格检查>>腹部>>输尿管","体格检查>>腹部>>血管杂音","体格检查>>腹部>>腹水征"};
			private string[] m_strKeysArr7 = {"","体格检查>>四肢>>杵状指(趾)","体格检查>>四肢>>畸形","体格检查>>四肢>>活动障碍","体格检查>>脊柱","体格检查>>肛门及外生殖器","体格检查>>神经反射"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false && m_blnHavePrintInfo(m_strKeysArr4) == false 
					&& m_blnHavePrintInfo(m_strKeysArr5) == false && m_blnHavePrintInfo(m_strKeysArr6) == false && m_blnHavePrintInfo(m_strKeysArr7) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("体 格 检 查",clsIMR_CardiovascularPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"一般情况：","体温：","#℃","脉率：","#次/分","呼吸：","#次/分","血压：","左上肢：","#/","","#Kpa","右上肢：","#/" ,"","#Kpa","左下肢：","#/" ,"","#Kpa"
													,"左下肢：","#/" ,"","#Kpa","体位：","发育：","营养：","身高：","#cm","体重：","#Kg"},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\n皮肤：","黄疸：","紫绀：","水肿：","其它：","淤点淤斑：","皮下结节：","环形红斑："},m_strKeysArr2,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeText(new string[]{"\n淋巴结："},m_strKeysArr3,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeText(new string[]{"\n头颈部：","眼睑：","结膜：","巩膜：","扁桃体：","颈静脉：","肝颈征：","气管："},m_strKeysArr4,ref strAllText,ref strXml);
//						if(m_blnHavePrintInfo(m_strKeysArr5) != false)
							m_mthMakeText(new string[]{"\n胸部：","胸廓：","呼吸方式：","肺：","心脏：（详见外科情况）"},m_strKeysArr5,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr6) != false)
							m_mthMakeText(new string[]{"\n腹部：","肝：","脾：","肾：","输尿管：","血管杂音：","腹水征："},m_strKeysArr6,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr7) != false)
							m_mthMakeText(new string[]{"\n四肢：","杵状指(趾)：","畸形：","活动障碍：","脊柱：","肛门及外生殖器：","神经反射："},m_strKeysArr7,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("体格检查：",m_objPrintContext.m_ObjModifyUserArr);

					m_blnIsFirstPrint = false;	
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
		/// 外科情况
		/// </summary>
		private class clsPrintInPatMedRecSurgery : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private int m_intLineYPos = 0;
			private string[] m_strKeysArr1 = {"外科情况>>紫绀","外科情况>>黄疸","外科情况>>浮肿","外科情况>>颈静脉","外科情况>>肝颈征"};
			private string[] m_strKeysArr2 = {"","外科情况>>望诊>>心尖搏动","外科情况>>望诊>>心尖搏动"};
			private string[] m_strKeysArr3 = {"","外科情况>>触诊>>心尖搏动性质","外科情况>>触诊>>震颤","外科情况>>触诊>>心包摩擦感"};
			private string[] m_strKeysArr4 = {"","外科情况>>叩诊>>前正中线至锁骨中线距离","外科情况>>叩诊>>前正中线至锁骨中线距离"};
			private string[] m_strKeysArr5 = {"","外科情况>>听诊>>心率","外科情况>>听诊>>心率","外科情况>>听诊>>心律"};
			private string[] m_strKeysArr6 = {"","外科情况>>听诊>>心音>>S1 最响部分","外科情况>>听诊>>心音>>S1响度","外科情况>>听诊>>心音>>S1分裂"};
			private string[] m_strKeysArr7 = {"","","外科情况>>听诊>>心音>>S2>>A2 响度","外科情况>>听诊>>心音>>S2>>A2分裂","","外科情况>>听诊>>心音>>S2>>P2 响度","外科情况>>听诊>>心音>>S2>>P2分裂","外科情况>>听诊>>心音>>S2>>A2"
											,"外科情况>>听诊>>心音>>S2>>A2","外科情况>>听诊>>心音>>额外心音","外科情况>>听诊>>心音>>奔马律","外科情况>>听诊>>心音>>附加音"};
			private string[] m_strKeysArr8 = {"","外科情况>>听诊>>杂音>>二尖瓣区","外科情况>>听诊>>杂音>>主动脉瓣区","外科情况>>听诊>>杂音>>肺动脉瓣区","外科情况>>听诊>>杂音>>三尖瓣区","外科情况>>听诊>>杂音>>胸骨左缘","外科情况>>听诊>>杂音>>心包摩擦音"};
			private string[] m_strKeysArr9 = {"","外科情况>>周围血管征>>枪击音","外科情况>>周围血管征>>水冲脉","外科情况>>周围血管征>>交替脉","外科情况>>周围血管征>>毛细血管搏动","","外科情况>>腹部>>肝","外科情况>>腹部>>腹水征","","外科情况>>四肢>>杵状指(趾)"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("外科情况",clsIMR_CardiovascularPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);

					p_intPosY += 40;
					m_intLineYPos = p_intPosY;
					if((m_intLineYPos+200) <= ((int)enmRectangleInfo.BottomY -50) && m_blnHavePrintInfo(m_strKeysArr4) != false)
					{
						m_mthDrawline(p_objGrp, p_fntNormalText);
					}
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"紫绀：","黄疸：","浮肿：","颈静脉：","肝颈征："},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\n心脏：","#\n望诊：","心尖搏动："},m_strKeysArr2,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeText(new string[]{"\n触诊：","心尖搏动性质：","震颤：","心包摩擦感："},m_strKeysArr3,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeText(new string[]{"\n叩诊：心界如右图：(","前正中线至锁骨中线距离","#cm)"},m_strKeysArr4,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr5) != false || m_blnHavePrintInfo(m_strKeysArr6) != false || m_blnHavePrintInfo(m_strKeysArr7) != false || m_blnHavePrintInfo(m_strKeysArr8) != false)
							m_mthMakeText(new string[]{"\n听诊：","心率：","#次/分","心律："},m_strKeysArr5,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr6) != false || m_blnHavePrintInfo(m_strKeysArr7) != false)
							m_mthMakeText(new string[]{"\n         心音：","S1最响部位：","响度：","分裂："},m_strKeysArr6,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr7) != false)
							m_mthMakeText(new string[]{"\n                      S2：","A2：","响度：","分裂：","\n                             P2：","响度：","分裂：","\n                             A2：","#P2","\n             额外心音：","奔马律：","附加音："},m_strKeysArr7,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr8) != false)
							m_mthMakeText(new string[]{"\n         杂音：(部位、时期、性质、强度、传导)","二尖瓣区：","主动脉瓣区：","肺动脉瓣区：","三尖瓣区：","胸骨左缘：","心包摩擦音："},m_strKeysArr8,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr9) != false)
							m_mthMakeText(new string[]{"\n周围血管征：","枪击音：","水冲脉：","交替脉：","毛细血管搏动：","\n腹部：","肝：","腹水征：","\n四肢：","杵状指(趾)："},m_strKeysArr9,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("外科情况：",m_objPrintContext.m_ObjModifyUserArr);

					m_blnIsFirstPrint = false;	
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
					if((m_intLineYPos+200) > ((int)enmRectangleInfo.BottomY -50) && m_blnHavePrintInfo(m_strKeysArr4) != false)
					{
						m_intLineYPos = 155-100;
						m_mthDrawline(p_objGrp, p_fntNormalText);
						p_intPosY += m_intLineYPos + 200;
					}
					m_blnHaveMoreLine = false;
				}
			}
			private void m_mthDrawline(System.Drawing.Graphics p_objGrp,System.Drawing.Font p_fntNormalText)
			{
				clsInpatMedRec_Item[] objItemContentArr = null;
				objItemContentArr = m_objGetContentFromItemArr(new string[]{"外科情况>>叩诊>>心界图>>II>>左","外科情况>>叩诊>>心界图>>II>>右","外科情况>>叩诊>>心界图>>III>>左","外科情况>>叩诊>>心界图>>III>>右"
																		   ,"外科情况>>叩诊>>心界图>>IV>>左","外科情况>>叩诊>>心界图>>IV>>右","外科情况>>叩诊>>心界图>>V>>左","外科情况>>叩诊>>心界图>>V>>右"
																		   ,"外科情况>>叩诊>>心界图>>IV>>左","外科情况>>叩诊>>心界图>>IV>>右"});
				if(objItemContentArr != null)
				{
					#region 打印心电图表
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+100 ,775,m_intLineYPos+100);
					p_objGrp.DrawString((objItemContentArr[0] == null ? "" :(objItemContentArr[0].m_strItemContent == null ? "" : objItemContentArr[0].m_strItemContent)),p_fntNormalText,Brushes.Black,625,m_intLineYPos+102);
					p_objGrp.DrawString("Ⅱ",p_fntNormalText,Brushes.Black,687,m_intLineYPos+102);
					p_objGrp.DrawString((objItemContentArr[1] == null ? "" :(objItemContentArr[1].m_strItemContent == null ? "" : objItemContentArr[1].m_strItemContent)),p_fntNormalText,Brushes.Black,716,m_intLineYPos+102);
					
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+120 ,775,m_intLineYPos+120);
					p_objGrp.DrawString((objItemContentArr[2] == null ? "" :(objItemContentArr[2].m_strItemContent == null ? "" : objItemContentArr[2].m_strItemContent)),p_fntNormalText,Brushes.Black,625,m_intLineYPos+122);
					p_objGrp.DrawString("Ⅲ",p_fntNormalText,Brushes.Black,687,m_intLineYPos+122);
					p_objGrp.DrawString((objItemContentArr[3] == null ? "" :(objItemContentArr[3].m_strItemContent == null ? "" : objItemContentArr[3].m_strItemContent)),p_fntNormalText,Brushes.Black,716,m_intLineYPos+122);
					
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+140 ,775,m_intLineYPos+140);
					p_objGrp.DrawString((objItemContentArr[4] == null ? "" :(objItemContentArr[4].m_strItemContent == null ? "" : objItemContentArr[4].m_strItemContent)),p_fntNormalText,Brushes.Black,625,m_intLineYPos+142);
					p_objGrp.DrawString("Ⅳ",p_fntNormalText,Brushes.Black,687,m_intLineYPos+142);
					p_objGrp.DrawString((objItemContentArr[5] == null ? "" :(objItemContentArr[5].m_strItemContent == null ? "" : objItemContentArr[5].m_strItemContent)),p_fntNormalText,Brushes.Black,716,m_intLineYPos+142);
					
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+160 ,775,m_intLineYPos+160);
					p_objGrp.DrawString((objItemContentArr[6] == null ? "" :(objItemContentArr[6].m_strItemContent == null ? "" : objItemContentArr[6].m_strItemContent)),p_fntNormalText,Brushes.Black,625,m_intLineYPos+162);
					p_objGrp.DrawString("Ⅴ",p_fntNormalText,Brushes.Black,687,m_intLineYPos+162);
					p_objGrp.DrawString((objItemContentArr[7] == null ? "" :(objItemContentArr[7].m_strItemContent == null ? "" : objItemContentArr[7].m_strItemContent)),p_fntNormalText,Brushes.Black,716,m_intLineYPos+162);
					
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+180 ,775,m_intLineYPos+180);
					p_objGrp.DrawString((objItemContentArr[8] == null ? "" :(objItemContentArr[8].m_strItemContent == null ? "" : objItemContentArr[8].m_strItemContent)),p_fntNormalText,Brushes.Black,625,m_intLineYPos+182);
					p_objGrp.DrawString("Ⅵ",p_fntNormalText,Brushes.Black,687,m_intLineYPos+182);
					p_objGrp.DrawString((objItemContentArr[9] == null ? "" :(objItemContentArr[9].m_strItemContent == null ? "" : objItemContentArr[9].m_strItemContent)),p_fntNormalText,Brushes.Black,716,m_intLineYPos+182);
					
					p_objGrp.DrawLine(Pens.Black,625,m_intLineYPos+200 ,775,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,685,m_intLineYPos+100 ,685,m_intLineYPos+200);
					p_objGrp.DrawLine(Pens.Black,715,m_intLineYPos+100 ,715,m_intLineYPos+200);
					#endregion
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
		/// 诊断
		/// </summary>
		private class clsPrintInPatMedRecDiagnostic : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item objItemContent = null;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
				if(m_hasItems.Contains("诊断"))
					objItemContent = m_hasItems["诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("诊断：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(330,m_intRecBaseX+40,p_intPosY,p_objGrp);
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
		}

		/// <summary>
		/// 诊疗计划
		/// </summary>
		private class clsPrintInPatMedRecCurePaln : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item objItemContent1 = null;
			private clsInpatMedRec_Item objItemContent2 = null;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
				{
					if(m_hasItems.Contains("诊疗计划"))
						objItemContent1 = m_hasItems["诊疗计划"] as clsInpatMedRec_Item;
					if(m_hasItems.Contains("记录医师"))
						objItemContent2 = m_hasItems["记录医师"] as clsInpatMedRec_Item;
				}
				if(objItemContent1 == null)
				{
					if(m_hasItems != null)
						p_objGrp.DrawString("记录医师：  "+(objItemContent2==null ? "" : (objItemContent2.m_strItemContent == null ? "" :objItemContent2.m_strItemContent)) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+450,p_intPosY);
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("诊疗计划：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1==null ? "" : objItemContent1.m_strItemContent)  ,(objItemContent1==null ? "<root />" : objItemContent1.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent1!=null);
					m_mthAddSign2("诊疗计划：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(320,m_intRecBaseX+40,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_objGrp.DrawString("记录医师：  "+((objItemContent2==null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+450,p_intPosY);
					p_intPosY += 20;
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

        /// <summary>
        /// 修正诊断
        /// </summary>
        private class clsPrintInPatMedRecDia2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("修正诊断"))
                        objItemContent1 = m_hasItems["修正诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名"))
                        objItemContent2 = m_hasItems["修正诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名日期"))
                        objItemContent3 = m_hasItems["修正诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent)+
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }

        /// <summary>
        /// 补充诊断
        /// </summary>
        private class clsPrintInPatMedRecDia3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("补充诊断"))
                        objItemContent1 = m_hasItems["修正诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名"))
                        objItemContent2 = m_hasItems["补充诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名日期"))
                        objItemContent3 = m_hasItems["补充诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("补充诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("补充诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }

		#endregion
	}
}

