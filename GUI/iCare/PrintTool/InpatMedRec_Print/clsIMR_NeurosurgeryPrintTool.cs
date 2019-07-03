using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 神经外科住院病历打印工具类
	/// </summary>
	public class clsIMR_NeurosurgeryPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_NeurosurgeryPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("神经外科住院病历",290),
										  new clsPrintInPatMedRecCaseMain(),
										  new clsPrintInPatMedRecCaseCurrent(),
										  new clsPrintInPatMedRecBeforetimeStatus(),
										  new clsPrintInPatMedRecIndividual(),
										  new clsPrintInPatMedRecFamily(),
										  new clsPrintInPatMedRecMedical(),
										  new clsPrintInPatMedRecFellCheck(),
										  new clsPrintInPatMedRecPic(),
										  new clsPrintInPatMedRecCranialNerves(),
										  new clsPrintInPatMedRecSport1(),
										  new clsPrintInPatMedRecSport2(),
										  new clsPrintInPatMedRecReflect(),
										  new clsPrintInPatMedRecBotanic(),
										  new clsPrintInPatMedRecMeninges(),
										  new clsPrintInPatMedRecOther(),
										  new clsPrintInPatMedRecHistory(),
										  new clsPrintInPatMedRecDiagnostic()
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
		/// 过去史
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
					if(m_hasItems.Contains("过去史"))
						objItemContent = m_hasItems["过去史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("过去史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("过去史：",m_objPrintContext.m_ObjModifyUserArr);
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
		/// 个人史(月经史、生育史)
		/// </summary>
		private class clsPrintInPatMedRecIndividual : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("个人史(月经史、生育史)"))
						objItemContent = m_hasItems["个人史(月经史、生育史)"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("个人史(月经史、生育史)：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("个人史(月经史、生育史)：",m_objPrintContext.m_ObjModifyUserArr);
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
			private string[] m_strKeysArr1 = {"","体格检查>>一般情况>>T","体格检查>>一般情况>>T","体格检查>>一般情况>>P","体格检查>>一般情况>>P","体格检查>>一般情况>>R","体格检查>>一般情况>>R","体格检查>>一般情况>>BP","体格检查>>一般情况>>BP","体格检查>>一般情况>>发育","体格检查>>一般情况>>皮肤","体格检查>>一般情况>>褥疮"};
			private string[] m_strKeysArr2 = {"","体格检查>>头部>>头形","体格检查>>头部>>头围","体格检查>>头部>>头皮","体格检查>>头部>>颅骨","体格检查>>头部>>眼","体格检查>>头部>>耳","体格检查>>头部>>鼻","体格检查>>头部>>口腔"};
			private string[] m_strKeysArr3 = {"体格检查>>颈部"};
			private string[] m_strKeysArr4 = {"","体格检查>>胸部>>心脏","体格检查>>胸部>>肺"};
			private string[] m_strKeysArr5 = {"体格检查>>腹部","体格检查>>泌尿生殖器","体格检查>>四肢","体格检查>>脊柱","体格检查>>骨盆"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false && m_blnHavePrintInfo(m_strKeysArr4) == false 
					&& m_blnHavePrintInfo(m_strKeysArr5) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("体 格 检 查",clsIMR_NeurosurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"一般情况：","T ：","#℃","P ：","#/min","R ：","#/min","BP：","#Kpa","发育：","皮肤：","褥疮："},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\n头部：","头形：","头围：","头皮：","颅骨：","眼：","耳：","鼻：","口腔："},m_strKeysArr2,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n颈部："},m_strKeysArr3,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeText(new string[]{"\n胸部：","心脏：","肺："},m_strKeysArr4,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n腹部：","泌尿生殖器：","四肢：","脊柱：","骨盆："},m_strKeysArr5,ref strAllText,ref strXml);
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
		/// 感觉检查记录
		/// </summary>
		private class clsPrintInPatMedRecFellCheck : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null || m_objPrintInfo.m_objContent.m_objPics == null|| m_objPrintInfo.m_objContent.m_objPics.Length < 1)
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
						p_intPosY += 1500;
						return;
					}
					else
					{
						p_objGrp.DrawString("感 觉 检 查 记 录",clsIMR_NeurosurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
						
					}
					p_intPosY += 100;
					m_blnIsFirstPrint = false;	
				}
					m_blnHaveMoreLine = false;
			}
			
			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
			}
		}
		/// <summary>
		/// 神经系统检查>>脑神经
		/// </summary>
		private class clsPrintInPatMedRecCranialNerves : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool m_blnPrintTitle = true; 
			private bool blnNextPage = true;
			private string[] m_strKeysArr1 = {"意识(格拉斯哥记分)","左右利手"};
			private string[] m_strKeysArr2 = {"","脑神经>>嗅觉>>右","脑神经>>嗅觉>>左"};
			private string[] m_strKeysArr3 = {"","脑神经>>视力>>右","脑神经>>视力>>左","脑神经>>视野(粗试)","脑神经>>眼底"};
			private string[] m_strKeysArr4 = {"","脑神经>>睑下垂>>右","脑神经>>睑下垂>>左","脑神经>>眼球凹凸>>右","脑神经>>眼球凹凸>>左","脑神经>>斜视>>右","脑神经>>斜视>>左"};
			private string[] m_strKeysArr5 = {"","脑神经>>瞳孔>>右","脑神经>>瞳孔>>右","脑神经>>瞳孔>>左","脑神经>>瞳孔>>左","脑神经>>瞳孔>>形状"};
			private string[] m_strKeysArr6 = {"","","脑神经>>光反射>>直接>>右","脑神经>>光反射>>直接>>左","","脑神经>>光反射>>间接>>右","脑神经>>光反射>>间接>>左","","脑神经>>光反射>>调节反射>>右","脑神经>>光反射>>调节反射>>左"};
			private string[] m_strKeysArr7 = {"","脑神经>>III运动>>右","脑神经>>III运动>>左","脑神经>>复视","脑神经>>眼球震颤",""};
			private string[] m_strKeysArr8 = {"","脑神经>>感觉>>右","脑神经>>感觉>>左","","脑神经>>角膜反射>>右","脑神经>>角膜反射>>左"};
			private string[] m_strKeysArr9 = {"","","脑神经>>运动>>颞咬肌萎缩>>右:","脑神经>>运动>>颞咬肌萎缩>>左","","脑神经>>运动>>咀嚼肌力>>右","脑神经>>运动>>咀嚼肌力>>左"};
			private string[] m_strKeysArr10 = {"\n下颌位置：","脑神经>>运动>>下颚位置>>偏右","脑神经>>运动>>下颚位置>>偏左"};
			private string[] m_strKeysArr11 = {"脑神经>>运动>>张口","脑神经>>运动>>下颚反射"};
			private string[] m_strKeysArr12 = {"","脑神经>>皱额>>右","脑神经>>皱额>>左","","脑神经>>闭眼>>右","脑神经>>闭眼>>左","","脑神经>>眼裂>>右","脑神经>>眼裂>>左","","脑神经>>鼻唇沟>>右","脑神经>>鼻唇沟>>左","","脑神经>>露齿>>右","脑神经>>露齿>>左","","脑神经>>鼓气>>右","脑神经>>鼓气>>左"};
			private string[] m_strKeysArr13 = {"","脑神经>>听力>>右","脑神经>>听力>>左"};
			private string[] m_strKeysArr14 = {"","","脑神经>>咽反射>>右","脑神经>>咽反射>>左","脑神经>>软腭运动","脑神经>>发音","脑神经>>吞咽"};
			private string[] m_strKeysArr15 = {"","","脑神经>>耸肩>>右","脑神经>>耸肩>>左","","脑神经>>转颈>>向右","脑神经>>转颈>>向左"};
			private string[] m_strKeysArr16 = {"","脑神经>>伸舌","","脑神经>>舌肌束颤>>右","脑神经>>舌肌束颤>>左","脑神经>>舌肌萎缩"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false && m_blnHavePrintInfo(m_strKeysArr4) == false 
					&& m_blnHavePrintInfo(m_strKeysArr5) == false && m_blnHavePrintInfo(m_strKeysArr6) == false && m_blnHavePrintInfo(m_strKeysArr7) == false && m_blnHavePrintInfo(m_strKeysArr8) == false
					&& m_blnHavePrintInfo(m_strKeysArr9) == false && m_blnHavePrintInfo(m_strKeysArr10) == false && m_blnHavePrintInfo(m_strKeysArr11) == false && m_blnHavePrintInfo(m_strKeysArr12) == false
					&& m_blnHavePrintInfo(m_strKeysArr13) == false && m_blnHavePrintInfo(m_strKeysArr14) == false && m_blnHavePrintInfo(m_strKeysArr15) == false && m_blnHavePrintInfo(m_strKeysArr16) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(blnNextPage)
				{
					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
					m_blnHaveMoreLine = true;
					blnNextPage = false;
					p_intPosY += 1500;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("神经系统检查：",clsIMR_NeurosurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					string strAllText2 = "";
					string strXml2 = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"意识(格拉斯哥记分)：","左右利手："},m_strKeysArr1,ref strAllText2,ref strXml2);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\nⅠ.嗅觉：","右：","左："},m_strKeysArr2,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeText(new string[]{"\nⅡ.视力：","右：","左：","视野(粗试)：","眼底："},m_strKeysArr3,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\nⅢ.Ⅳ.Ⅵ.","睑下垂：","右：","左：","眼球凹凸：","右：","左：","斜视：","右：","左："},m_strKeysArr4,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr5) != false)
							m_mthMakeText(new string[]{"\n     瞳孔：","右：","#毫米<＝>","","#毫米","形状："},m_strKeysArr5,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr6) != false)
							m_mthMakeText(new string[]{"\n     光反射：","直接：","右：","左：","间接：","右：","左：","调节反射：","右：","左："},m_strKeysArr6,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n   运动：","右：","左：","复视：","眼球震颤：","\nⅤ.："},m_strKeysArr7,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr8) != false)
							m_mthMakeText(new string[]{"感觉：","右：","左：","角膜反射：","右：","左："},m_strKeysArr8,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr9) != false)
							m_mthMakeText(new string[]{"\n     运动","颞咬肌萎缩：","右：","左：","咀嚼肌力：","右：","左："},m_strKeysArr9,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr10,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"张口：","下颌反射："},m_strKeysArr11,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\nⅦ. 皱额：","右：","左：","闭眼：","右：","左：","眼裂：","右：","左：","鼻唇沟：","右：","左：","露齿：","右：","左：","鼓气：","右：","左："},m_strKeysArr12,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr13) != false)
							m_mthMakeText(new string[]{"\nⅧ. 听力：","右：","左："},m_strKeysArr13,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr14) != false)
							m_mthMakeText(new string[]{"\nⅣ.Ⅹ.：","咽反射：","右：","左：","软腭运动：","发音：","吞咽："},m_strKeysArr14,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr15) != false)
							m_mthMakeText(new string[]{"\nⅨ.：","耸肩：","右：","左：","转颈：","向右：","向左："},m_strKeysArr15,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr16) != false)
							m_mthMakeText(new string[]{"\nⅦ.：","伸舌：","舌肌束颤：","右：","左：","舌肌萎缩："},m_strKeysArr16,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext2.m_mthSetContextWithCorrectBefore(strAllText2,strXml2,m_dtmFirstPrintTime,false);
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("神经系统检查：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext2.m_BlnHaveNextLine())
				{
					m_objPrintContext2.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext2.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					if(m_blnPrintTitle)
					{
						p_objGrp.DrawString("脑神经：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
						m_blnPrintTitle = false;
					}
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
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}

		/// <summary>
		/// 神经系统检查>>运动
		/// </summary>
		private class clsPrintInPatMedRecSport1 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"运动>>姿势步态","运动>>肌张力","","运动>>肌营养>>萎缩","运动>>肌营养>>肥大","运动>>肌营养>>挛缩","运动>>肌肉(0-5)度","","运动>>握力>>右","运动>>握力>>右","运动>>握力>>左","运动>>握力>>左"};
			private string[] m_strKeysArr1 = {"运动>>肩>>内收>>左","运动>>肩>>内收>>右","运动>>肩>>外展>>左","运动>>肩>>外展>>右"};
			private string[] m_strKeysArr2 = {"运动>>肘>>屈>>左","运动>>肘>>屈>>右","运动>>肘>>伸>>左","运动>>肘>>伸>>右"};
			private string[] m_strKeysArr3 = {"运动>>腕>>屈>>左","运动>>腕>>屈>>右","运动>>腕>>伸>>左","运动>>腕>>伸>>右"};
			private string[] m_strKeysArr4 = {"运动>>指>>屈>>左","运动>>指>>屈>>右","运动>>指>>伸>>左","运动>>指>>伸>>右"};
			private string[] m_strKeysArr5 = {"运动>>髋>>屈>>左","运动>>髋>>屈>>右","运动>>髋>>伸>>左","运动>>髋>>伸>>右"};
			private string[] m_strKeysArr6 = {"运动>>膝>>屈>>左","运动>>膝>>屈>>右","运动>>膝>>伸>>左","运动>>膝>>伸>>右"};
			private string[] m_strKeysArr7 = {"运动>>踝>>屈>>左","运动>>踝>>屈>>右","运动>>踝>>伸>>左","运动>>踝>>伸>>右"};
			private string[] m_strKeysArr8 = {"运动>>趾>>屈>>左","运动>>趾>>屈>>右","运动>>趾>>伸>>左","运动>>趾>>伸>>右"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false && !(m_blnHavePrintInfo(m_strKeysArr1) == true || m_blnHavePrintInfo(m_strKeysArr2) == true 
					|| m_blnHavePrintInfo(m_strKeysArr3) == true|| m_blnHavePrintInfo(m_strKeysArr4) == true|| m_blnHavePrintInfo(m_strKeysArr5) == true
					|| m_blnHavePrintInfo(m_strKeysArr6) == true|| m_blnHavePrintInfo(m_strKeysArr7) == true|| m_blnHavePrintInfo(m_strKeysArr8) == true))
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("运动：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"姿势步态：","肌张力：","肌营养：","萎缩：","肥大：","挛缩：","肌力(0-5度)：","握力：","右：","#斤","左：","#斤"},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("运动：",m_objPrintContext.m_ObjModifyUserArr);

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
					p_intPosY += 10;
					m_mthPrintSportTable(ref p_intPosY, p_objGrp, p_fntNormalText);
					m_blnHaveMoreLine = false;
				}
			}
			#region 打印表格
			private void m_mthPrintSportTable(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth+20;
				int intRowStep = m_intRecBaseX + 5;
				int intPosY = p_intPosY;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);
				p_objGrp.DrawLine(Pens.Black,intRowStep+20,intPosY+20,intRowStep + intLineWidth,intPosY+20);
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+40,intRowStep + intLineWidth,intPosY+40);
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep,intPosY+80);
				p_objGrp.DrawString("左",p_fntNormalText,Brushes.Black,intRowStep+1,intPosY+41);
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+60,intRowStep + intLineWidth,intPosY+60);
				p_objGrp.DrawString("右",p_fntNormalText,Brushes.Black,intRowStep+1,intPosY+61);
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+80,intRowStep + intLineWidth ,intPosY+80);
				p_objGrp.DrawLine(Pens.Black,intRowStep +intLineWidth,p_intPosY,intRowStep +intLineWidth,p_intPosY+80);
				intRowStep += 20;
				m_mthPrintSubItem(new string[]{"肩","内收","外展"},m_strKeysArr1,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"肘","屈","伸"},m_strKeysArr2,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"腕","屈","伸"},m_strKeysArr3,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"指","屈","伸"},m_strKeysArr4,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"髋","屈","伸"},m_strKeysArr5,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"膝","屈","伸"},m_strKeysArr6,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"踝","屈","伸"},m_strKeysArr7,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				m_mthPrintSubItem(new string[]{"趾","屈","伸"},m_strKeysArr8,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
				p_intPosY += 80;
			}

			private void m_mthPrintSubItem(string[] p_strTitleArr,string[] p_strKeyArr,ref int p_intRow,int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
				if(objConArr == null || objConArr.Length != 4 || p_strTitleArr == null)
					return;
				string[] strConArr = new String[objConArr.Length];
				for(int i=0;i<objConArr.Length; i++)
				{
                    if (objConArr[i] != null)
                    {
                        if (objConArr[i].m_strItemContent != null)
                            strConArr[i] = objConArr[i].m_strItemContent;
                        else
                            strConArr[i] = "";
                    }
                    else
                        strConArr[i] = "";
				}
				p_objGrp.DrawLine(Pens.Black,p_intRow,p_intPosY,p_intRow,p_intPosY+80);
				int intLenth = Convert.ToInt32( Math.Max( p_objGrp.MeasureString(strConArr[0],p_fntNormalText).Width,p_objGrp.MeasureString(strConArr[1],p_fntNormalText).Width));
				p_objGrp.DrawString(p_strTitleArr[0],p_fntNormalText,Brushes.Black,p_intRow+20,p_intPosY+1);
				p_objGrp.DrawString(p_strTitleArr[1],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+21);
				p_objGrp.DrawString(strConArr[0],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+41);
				p_objGrp.DrawString(strConArr[1],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+61);
				p_intRow += Math.Max(intLenth,40);
				p_objGrp.DrawLine(Pens.Black,p_intRow,p_intPosY+20,p_intRow,p_intPosY+80);
				intLenth = Convert.ToInt32( Math.Max( p_objGrp.MeasureString(strConArr[2],p_fntNormalText).Width,p_objGrp.MeasureString(strConArr[3],p_fntNormalText).Width));
				p_objGrp.DrawString(p_strTitleArr[2],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+21);
				p_objGrp.DrawString(strConArr[2],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+41);
				p_objGrp.DrawString(strConArr[3],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+61);
				p_intRow += Math.Max(intLenth,40);
			}
			#endregion

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 神经系统检查>>运动>>共济
		/// </summary>
		private class clsPrintInPatMedRecSport2 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {""};
			private string[] m_strKeysArr2 = {"","运动>>共济>>指鼻,指指测验>>右","运动>>共济>>指鼻,指指测验>>左"};
			private string[] m_strKeysArr3 = {"","运动>>共济>>指鼻,指纹测验>>正常"};
			private string[] m_strKeysArr4 = {"","运动>>共济>>跟膝胫测验>>右","运动>>共济>>跟膝胫测验>>左"};
			private string[] m_strKeysArr5 = {"","运动>>共济>>跟膝胫测验>>正常"};
			private string[] m_strKeysArr6 = {"","运动>>共济>>回缩现象>>右","运动>>共济>>回缩现象>>左"};
			private string[] m_strKeysArr7 = {"","运动>>共济>>回缩现象>>正常"};
			private string[] m_strKeysArr8 = {"","运动>>共济>>快复动作>>右","运动>>共济>>快复动作>>右"};
			private string[] m_strKeysArr9 = {"","运动>>共济>>快复动作>>正常"};
			private string[] m_strKeysArr10 = {"运动>>共济>>闭眼难立征","运动>>共济>>不自主运动","运动>>共济>>肌纤维束震颤"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false && m_blnHavePrintInfo(m_strKeysArr4) == false 
					&& m_blnHavePrintInfo(m_strKeysArr5) == false&& m_blnHavePrintInfo(m_strKeysArr6) == false&& m_blnHavePrintInfo(m_strKeysArr7) == false&& m_blnHavePrintInfo(m_strKeysArr8) == false
					&& m_blnHavePrintInfo(m_strKeysArr9) == false&& m_blnHavePrintInfo(m_strKeysArr10) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"\n共济："},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false || m_blnHavePrintInfo(m_strKeysArr3) != false)
						{
							m_mthMakeText(new string[]{"指鼻，指指测验：","右：","左："},m_strKeysArr2,ref strAllText,ref strXml);
							m_mthMakeCheckText(m_strKeysArr3,ref strAllText,ref strXml);
						}
						if(m_blnHavePrintInfo(m_strKeysArr4) != false || m_blnHavePrintInfo(m_strKeysArr5) != false)
						{
							m_mthMakeText(new string[]{"；跟膝胫测验：","右：","左："},m_strKeysArr4,ref strAllText,ref strXml);
							m_mthMakeCheckText(m_strKeysArr5,ref strAllText,ref strXml);
						}
						if(m_blnHavePrintInfo(m_strKeysArr6) != false || m_blnHavePrintInfo(m_strKeysArr7) != false)
						{
							m_mthMakeText(new string[]{"\n回缩现象：","右：","左："},m_strKeysArr6,ref strAllText,ref strXml);
							m_mthMakeCheckText(m_strKeysArr7,ref strAllText,ref strXml);
						}
						if(m_blnHavePrintInfo(m_strKeysArr8) != false || m_blnHavePrintInfo(m_strKeysArr9) != false)
						{
							m_mthMakeText(new string[]{"\n快复动作：","右：","左："},m_strKeysArr8,ref strAllText,ref strXml);
							m_mthMakeCheckText(m_strKeysArr9,ref strAllText,ref strXml);
						}
						m_mthMakeText(new string[]{"\n闭眼难立征：","不自主运动：","肌纤维束震颤："},m_strKeysArr10,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("运动：",m_objPrintContext.m_ObjModifyUserArr);

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
		/// 神经系统检查>>反射
		/// </summary>
		private class clsPrintInPatMedRecReflect : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private clsInpatMedRec_Item[] objItemContent;
			private int m_intIndex = 0;
			private bool blnIsRight = true;
			private string[] strTitleArr = new string[]{"二头","","膝","","三头","","踝","","挠","","跖","","霍夫曼","","戈登","","腹壁","","奥本海姆","","","","查多克","","提睾","","巴彬斯基"};
			private string[] m_strKeyArr = {"反射>>二头>>右","反射>>二头>>左","反射>>膝>>右","反射>>膝>>左","反射>>三头>>右","反射>>三头>>左","反射>>踝>>右","反射>>踝>>左"
																		,"反射>>挠>>右","反射>>挠>>左","反射>>跖>>右","反射>>跖>>左","反射>>霍夫曼>>右","反射>>霍夫曼>>左","反射>>戈登>>右","反射>>戈登>>左"
																		,"反射>>腹壁>>右上","反射>>腹壁>>左上","反射>>奥本海姆>>右","反射>>奥本海姆>>左","反射>>腹壁>>右下","反射>>腹壁>>左下","反射>>查多克>>右","反射>>查多克>>左"
																		,"反射>>提睾>>右","反射>>提睾>>左","反射>>巴彬斯基>>右","反射>>巴彬斯基>>左"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnHavePrintInfo(m_strKeyArr) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				objItemContent = m_objGetContentFromItemArr(m_strKeyArr);
				if(objItemContent == null || objItemContent.Length <= 0)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					if(m_intIndex == 0)
					{
						p_intPosY += 20;
						p_objGrp.DrawString("反射:(-无，±迟钝，+中等，++轻度增强，+++中等增强，++++极强。)",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
					}
					p_objGrp.DrawString("右               左                       右               左",p_fntNormalText,Brushes.Black,m_intRecBaseX+115,p_intPosY);
					p_intPosY += 20;
					for(int i = m_intIndex; i < objItemContent.Length; i++)
					{
						if((p_intPosY+20) > ((int)enmRectangleInfo.BottomY -50))
						{
							m_blnHaveMoreLine = true;
							p_intPosY += 100;
							m_intIndex = i;
							return;
						}
						blnIsRight = !blnIsRight;
						if(objItemContent[i] == null && objItemContent[i+1] == null)
						{
							i++;
							continue;
						}
						m_mthPrintTable(strTitleArr[i],objItemContent[i],objItemContent[++i],blnIsRight,ref p_intPosY,p_objGrp,p_fntNormalText);
					}
					p_intPosY += 20;
					m_blnIsFirstPrint = false;					
				}
				m_blnHaveMoreLine = false;
			}

			private void m_mthPrintTable(string p_strTitle,clsInpatMedRec_Item p_objItemRight,clsInpatMedRec_Item p_objItemLeft,bool p_blnIsRight,ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				int intPos = m_intRecBaseX+20;
				int intRight = intPos + 60;
				int intLeft= intRight + 150;
				if(p_blnIsRight)
				{
					intPos += 350;
					intRight = intPos + 80;
					intLeft= intRight + 150;
				}
				p_objGrp.DrawString(p_strTitle,p_fntNormalText,Brushes.Black,intPos,p_intPosY);
				if(p_objItemRight!= null)
					p_objGrp.DrawString((p_objItemRight.m_strItemContent == null ?"" :p_objItemRight.m_strItemContent),p_fntNormalText,Brushes.Black,intRight,p_intPosY);
				if(p_objItemLeft!= null)
					p_objGrp.DrawString((p_objItemLeft.m_strItemContent == null ?"" :p_objItemLeft.m_strItemContent),p_fntNormalText,Brushes.Black,intLeft,p_intPosY);
				if(p_blnIsRight)
					p_intPosY += 20;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
			}
		}
		/// <summary>
		/// 神经系统检查>>植物神经机能
		/// </summary>
		private class clsPrintInPatMedRecBotanic : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"植物神经机能>>霍纳氏征","植物神经机能>>括约肌(大小便)","植物神经机能>>皮肤营养、颜色、温度","植物神经机能>>皮肤划纹反应","植物神经机能>>出汗"};
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
					p_intPosY += 20;
					p_objGrp.DrawString("植物神经机能",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"霍纳氏征：","括约肌(大小便)：","皮肤营养、颜色、温度：","皮肤划纹反应：","出汗："},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("植物神经机能：",m_objPrintContext.m_ObjModifyUserArr);

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

			private void m_mthPrintSportTable(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
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
		/// 神经系统检查>>脑膜刺激征
		/// </summary>
		private class clsPrintInPatMedRecMeninges : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"脑膜刺激征>>颈强直","脑膜刺激征>>克尼格氏征","脑膜刺激征>>布鲁金斯基氏征"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("脑膜刺激征",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"颈强直：","克尼格氏征：","布鲁金斯基氏征："},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("脑膜刺激征：",m_objPrintContext.m_ObjModifyUserArr);

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
		/// 神经系统检查>>其他
		/// </summary>
		private class clsPrintInPatMedRecOther : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("神经系统检查>>其他"))
						objItemContent = m_hasItems["神经系统检查>>其他"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("其他：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("其他：",m_objPrintContext.m_ObjModifyUserArr);


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
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
			}
		}
		/// <summary>
		/// 病史与体检小结
		/// </summary>
		private class clsPrintInPatMedRecHistory : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
//			private int m_intTimes = 0;
			private clsInpatMedRec_Item objItemContent = null;
			
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("病史与体检小结"))
						objItemContent = m_hasItems["病史与体检小结"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("病史与体检小结：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("病史与体检小结：",m_objPrintContext.m_ObjModifyUserArr);


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
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
//				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 修正诊断&初步诊断（诊断）
		/// </summary>
		private class clsPrintInPatMedRecDiagnostic : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                objItemContent = m_objGetContentFromItemArr(new string[] { "修正诊断", "初步诊断(诊断)", "修正诊断医师签名", "医师" });
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
					m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					if (objItemContent[0] != null)
						if(objItemContent[0].m_strItemContent != null)
							p_objGrp.DrawString("修正诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							p_objGrp.DrawString("初步诊断(诊断)：",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
					p_intPosY += 20;
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
						{
							m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
							m_mthAddSign2("修正诊断：",m_objPrintContext1.m_ObjModifyUserArr);
						}
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
						{
							m_objPrintContext2.m_mthSetContextWithCorrectBefore(objItemContent[1].m_strItemContent ,(objItemContent[1]==null ? "<root />" : objItemContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[1]!=null);
							m_mthAddSign2("初步诊断(诊断)：",m_objPrintContext2.m_ObjModifyUserArr);
						}
					m_blnIsFirstPrint = false;					
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
				p_objGrp.DrawString("主治医师："+(objItemContent[2]==null ? "" : (objItemContent[2].m_strItemContent == null ? "":objItemContent[2].m_strItemContent)) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
				p_objGrp.DrawString("医师："+ (objItemContent[3] == null ? "" :(objItemContent[3].m_strItemContent == null ? "":objItemContent[3].m_strItemContent)),p_fntNormalText,Brushes.Black,m_intRecBaseX+450,p_intPosY);
				
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
