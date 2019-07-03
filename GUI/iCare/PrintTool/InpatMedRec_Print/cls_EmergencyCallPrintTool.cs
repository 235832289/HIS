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
	/// 急诊病历打印的摘要说明。
	/// </summary>
	public class cls_EmergencyCallPrintTool:clsInpatMedRecPrintBase
	{
		public cls_EmergencyCallPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
     
		}
		protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{

			e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 5, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 15, e.PageBounds.Height - 315);
		}
		protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			int p_intPosY = 40;
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), Brushes.Black, 340, p_intPosY);
			p_intPosY += 30;
			e.Graphics.DrawString("急     诊     病     历", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 280, p_intPosY);
		}
   
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{　
																		   new clsPrintFixInfo(),
																
																		   new clsPrintInPatMedRecCaseMain(),
																		   new clsPrintInPatMedRecCurrentDiseaseHistory(),
																		   new clsPrintInPatMedRecPassedHistory(),
															
																		   new clsPrintInPatMedRecBodyCheck(),
																		   new clsPrintInPatNose (),
                                                                 
																		   new clsPrintInPatMedRecPressPain(),
																		   new clsPrintInPatMedRecMuscle(),
																		   new clsPrintInPatMedRecRossolimo(),
																		   new clsPrintInPatMedRecAnormal(),
																		   new clsPrintInPatMedRecSpecializedSituation(),
																		   new clsPrintInPatMedRecPrimaryDiagnosis()
				                                             								       
																	   });

		}
		/// <summary>
		/// 打印科别到留观天数
		/// </summary>
		private  class clsPrintFixInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strPrintText = "";
			private string[] p_strKeysArr01 ={ "去向>>离院", "去向>>转院", "去向>>入院" };
			private string[] p_strKeysArr02 ={ "治疗效果>>治愈", "治疗效果>>好转", "治疗效果>>未愈", "治疗效果>>死亡" };
			private Font p_fntNormal = new Font("SimSun", 12);
			public int m_mthKeyCheck(string[] p_strKeysArr)
			{
				if (m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for (int i = 0; i < p_strKeysArr.Length; i++)
				{
					if (m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if (m_blnIsFirstPrint)
				{
                    Font m_fotSmallFont = new Font("SimSun",12);
                    SolidBrush m_slbBrush = new SolidBrush(Color.Black);
					p_intPosY = 110;
					//p_objGrp.DrawString("科别：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strDeptName), p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    p_objGrp.DrawString("姓名：", m_fotSmallFont, m_slbBrush, 50, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, 100, p_intPosY);

                    p_objGrp.DrawString("性别：", m_fotSmallFont, m_slbBrush, 185, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, 230, p_intPosY);

                    p_objGrp.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 260, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 305, p_intPosY);

                    p_objGrp.DrawString("病区：", m_fotSmallFont, m_slbBrush, 360, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 410, p_intPosY);

                    p_objGrp.DrawString("床号：", m_fotSmallFont, m_slbBrush, 555, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 605, p_intPosY);

                    p_objGrp.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 655, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 715, p_intPosY);	

					p_intPosY += 30;

                    p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, m_fotSmallFont, m_slbBrush, 60, p_intPosY);
                    p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, m_fotSmallFont, m_slbBrush, 170, p_intPosY);
                    p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 400, p_intPosY);
                    p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, m_fotSmallFont, m_slbBrush, 550, p_intPosY);
                    //m_strPrintText = "姓    名:";
                    //if (m_objPrintInfo.m_strPatientName.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strPatientName + "  性别:";
                    //if (m_objPrintInfo.m_strSex.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strSex + "年龄:";
                    //else
                    //    m_strPrintText += "年龄:";
                    //if (m_objPrintInfo.m_strAge.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strAge + " 婚否:";
                    //else
                    //    m_strPrintText = " 婚否:";
                    //if (m_objPrintInfo.m_strMarried.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strMarried + "  籍贯:";
                    //else
                    //    m_strPrintText += "  籍贯:";
                    //if (m_objPrintInfo.m_strNativePlace.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strNativePlace + "  职业:";
                    //else
                    //    m_strPrintText += "  职业:";
                    //if (m_objPrintInfo.m_strOccupation.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strOccupation+ "  住址:";
                    p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

                    //p_intPosY += 20;
                    //m_strPrintText = "住    址:";
                    //if (m_objPrintInfo.m_strHomeAddress.Trim() != "")
                    //    m_strPrintText += m_objPrintInfo.m_strHomeAddress;
                    //p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
					p_intPosY += 20;
					if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					m_strPrintText = "         ";
					switch (m_mthKeyCheck(p_strKeysArr01))
					{
						case 0: m_strPrintText += "离院 "; break;
						case 1: m_strPrintText += "转院 "; break;
						case 2: m_strPrintText += "入院 "; break;
						case -1: break;
					}

					if (m_strPrintText != "         ")
					{
						p_objGrp.DrawString("去    向:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, m_strPrintText);
					}
					m_strPrintText = "         ";
					switch (m_mthKeyCheck(p_strKeysArr02))
					{
						case 0: m_strPrintText += "治愈 "; break;
						case 1: m_strPrintText += "好转 "; break;
						case 2: m_strPrintText += "未愈 "; break;
						case 3: m_strPrintText += "死亡 "; break;
						case -1: break;
					}

					if (m_strPrintText != "         ")
					{
						p_objGrp.DrawString("治疗效果:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, m_strPrintText);
					}
					m_strPrintText = "         ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("留观时间"))
                        {
                            p_objGrp.DrawString("留观时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_strPrintText += DateTime.Parse(m_hasItemDetail["留观时间"].ToString()).ToString("yyyy年MM月dd日");
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, m_strPrintText);
                        }
                        if (m_hasItemDetail.Contains("出观时间"))
                        {
                            p_objGrp.DrawString("出观时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY - 25);
                            m_strPrintText = DateTime.Parse(m_hasItemDetail["出观时间"].ToString()).ToString("yyyy年MM月dd日");
                            p_objGrp.DrawString(m_strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 330, p_intPosY - 25);
                        }
                        if (m_hasItemDetail.Contains("留观天数"))
                        {
                            p_objGrp.DrawString("留观天数:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY - 25);
                            m_strPrintText = m_hasItemDetail["留观天数"] + " 天";
                            p_objGrp.DrawString(m_strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 630, p_intPosY - 25);
                        }
                    }
                     
					p_fntNormal.Dispose();


					m_blnHaveMoreLine = false;
				}
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		/// 主诉
		/// </summary>
		private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText = "  　";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal = new Font("SimSun", 12 );
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{


				if (m_hasItems != null)
					if (m_hasItems.Contains("主诉"))
						objItemContent = m_hasItems["主诉"] as clsInpatMedRec_Item;
				if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if (m_blnIsFirstPrint)
				{
					if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}

					p_objGrp.DrawString("主 　 诉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail!=null && m_hasItemDetail.Contains("主诉"))
					{
						strPrintText += m_hasItemDetail["主诉"];
						p_intPosY += 20;
					}
					if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		/// 简要病史
		/// </summary>
		private class clsPrintInPatMedRecCurrentDiseaseHistory : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText = "  　";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal = new Font("SimSun", 12);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{


				if (m_hasItems != null)
					if (m_hasItems.Contains("简要病史"))
						objItemContent = m_hasItems["简要病史"] as clsInpatMedRec_Item;
				if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if (m_blnIsFirstPrint)
				{
					if (m_blnCheckBottom(ref p_intPosY, 120, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("简要病史:", new Font("SimSun", 12), Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("简要病史"))
					{
						strPrintText += m_hasItemDetail["简要病史"];
						p_intPosY += 20;
					}
					//if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		/// 过去病史
		/// </summary>
		private class clsPrintInPatMedRecPassedHistory : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText = "  　";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal = new Font("SimSun", 12);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_hasItems != null)
					if (m_hasItems.Contains("过去病史"))
						objItemContent = m_hasItems["过去病史"] as clsInpatMedRec_Item;
				if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if (m_blnIsFirstPrint)
				{
					if (m_blnCheckBottom(ref p_intPosY, 120, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("过去病史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("过去病史"))
					{
						strPrintText += m_hasItemDetail["过去病史"];
						p_intPosY += 20;
					}
					//if (strPrintText != "   ") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		/// 体征
		/// </summary>
		private class clsPrintInPatMedRecBodyCheck : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true };
			private string strPrintText = "  　 　　    ";
			private Font p_fntNormal = new Font("SimSun", 12);
			private int m_intFlag = 0;
            

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_blnIsFirstPrint[0])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if(m_hasItemDetail!=null)
                    {
					if (m_hasItemDetail.Contains("体征>>T"))
						strPrintText += "T:" + m_hasItemDetail["体征>>T"] + "℃      ";
					if (m_hasItemDetail.Contains("体征>>P"))
						strPrintText += "P:" + m_hasItemDetail["体征>>P"] + "次/分      ";
					if (m_hasItemDetail.Contains("体征>>R"))
						strPrintText += "R:" + m_hasItemDetail["体征>>R"] + "次/分      ";
					if (m_hasItemDetail.Contains("体征>>BP"))
						strPrintText += "Bp:" + m_hasItemDetail["体征>>BP"] + "mmHg";
                    }
					if (strPrintText != "  　 　　    ")
					{
						p_objGrp.DrawString("体    征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					m_blnIsFirstPrint[0] = false;
				}
				if(m_blnIsFirstPrint[1])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "  　     ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("神志>>清醒"))
                            strPrintText += "清醒   ";
                        if (m_hasItemDetail.Contains("神志>>模糊"))
                            strPrintText += "模糊   ";
                        if (m_hasItemDetail.Contains("神志>>昏迷"))
                            strPrintText += "昏迷   ";
                        if (m_hasItemDetail.Contains("抽搐"))
                            strPrintText += "抽搐   ";
                        if (m_hasItemDetail.Contains("黄疸"))
                            strPrintText += "黄疸   ";
                        if (m_hasItemDetail.Contains("贫血"))
                            strPrintText += "贫血   ";
                        if (m_hasItemDetail.Contains("出血1"))
                            strPrintText += m_hasItemDetail["出血1"];
                        if (m_hasItemDetail.Contains("出血"))
                            strPrintText += "出血   ";
                        if (m_hasItemDetail.Contains("淋巴节肿大1"))
                            strPrintText += m_hasItemDetail["淋巴节肿大1"];
                        if (m_hasItemDetail.Contains("淋巴节肿大"))
                            strPrintText += "淋巴节肿大";
                    }
					if(strPrintText!="  　     ")
					{
						p_objGrp.DrawString("神    志:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					m_blnIsFirstPrint[1] = false;
				}
				if (m_blnIsFirstPrint[2])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "  　     ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("瞳孔>>左"))
                            strPrintText += "左:" + m_hasItemDetail["瞳孔>>左"] + " mm "; ;
                        if (m_hasItemDetail.Contains("瞳孔>>右"))
                            strPrintText += "右:" + m_hasItemDetail["瞳孔>>右"] + " mm";
                    }
					if (strPrintText != "  　     ")
					{
						p_objGrp.DrawString("瞳    孔:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						m_intFlag++;
					}
					strPrintText = "";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("对光反射>>存在"))
                            strPrintText += "存在";
                        if (m_hasItemDetail.Contains("对光反射>>消失"))
                            strPrintText += "消失";
                    }
					if (strPrintText != "")
					{
						if (m_intFlag == 1)
						{
							p_objGrp.DrawString("对光反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 20);
							p_objGrp.DrawString(strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 380, p_intPosY - 20);
						}
						else
						{
							p_objGrp.DrawString("对光反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
							p_objGrp.DrawString(strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
							p_intPosY += 20;
						}
					}
					m_blnIsFirstPrint[2] = false;
				}
				p_fntNormal.Dispose();
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
				m_blnIsFirstPrint=new Boolean[]{true,true,true};
           
			}
		}
		/// <summary>
		/// 侧鼻唇沟变浅
		/// </summary>
        private class clsPrintInPatNose : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true };
            private string strPrintText = "  　 　　    ";
            private Font p_fntNormal = new Font("SimSun", 12 );
            private int m_intFlag = 0;


            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_blnIsFirstPrint[0])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("侧鼻唇沟变浅1"))
                        {
                            if (m_hasItemDetail.Contains("伸舌"))
                            {
                                if (m_hasItemDetail.Contains("气管居中>>移"))
                                {
                                    p_objGrp.DrawString(m_hasItemDetail["侧鼻唇沟变浅1"] + "侧鼻唇沟变浅", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);


                                    p_objGrp.DrawString("伸舌:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_objGrp.DrawString("     " + m_hasItemDetail["伸舌"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_objGrp.DrawString("气管居中 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                                    p_objGrp.DrawString("         " + m_hasItemDetail["气管居中>>移"] + " 移", p_fntNormal, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                                    p_intPosY += 20;
                                }
                                else
                                {
                                    p_objGrp.DrawString(m_hasItemDetail["侧鼻唇沟变浅1"] + "侧鼻唇沟变浅", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);


                                    p_objGrp.DrawString("伸舌:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_objGrp.DrawString("    " + m_hasItemDetail["伸舌"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_intPosY += 20;
                                }
                            }

                            else
                            {
                                if (m_hasItemDetail.Contains("气管居中>>移"))
                                {
                                    p_objGrp.DrawString(m_hasItemDetail["侧鼻唇沟变浅1"] + "侧鼻唇沟变浅", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

                                    p_objGrp.DrawString("气管居中 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_objGrp.DrawString("         " + m_hasItemDetail["气管居中>>移"] + " 移", p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_intPosY += 20;
                                }
                                else
                                {
                                    p_objGrp.DrawString(m_hasItemDetail["侧鼻唇沟变浅1"] + "侧鼻唇沟变浅", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_intPosY += 20;
                                }
                            }

                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("伸舌"))
                            {
                                if (m_hasItemDetail.Contains("气管居中>>移"))
                                {
                                    p_objGrp.DrawString("伸舌:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_objGrp.DrawString("    " + m_hasItemDetail["伸舌"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_objGrp.DrawString("气管居中 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 5300, p_intPosY);
                                    p_objGrp.DrawString("         " + m_hasItemDetail["气管居中>>移"] + " 移", p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                    p_intPosY += 20;
                                }
                                else
                                {
                                    p_objGrp.DrawString("伸舌:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_objGrp.DrawString("    " + m_hasItemDetail["伸舌"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_intPosY += 20;
                                }
                            }

                            else
                            {
                                if (m_hasItemDetail.Contains("气管居中>>移"))
                                {
                                    p_objGrp.DrawString("气管居中 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_objGrp.DrawString("         " + m_hasItemDetail["气管居中>>移"] + " 移", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                    p_intPosY += 20;
                                }

                            }
                        }
                    }
                    m_blnIsFirstPrint[0] = false;

                }

                if (m_blnIsFirstPrint[1])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    strPrintText = "    ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("颈>>软"))
                            strPrintText += "软";
                        if (m_hasItemDetail.Contains("颈>>硬"))
                            strPrintText += "硬";
                    }
                    if (strPrintText != "    ")
                    {
                        p_objGrp.DrawString("颈:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                        m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                    }
                    strPrintText = "  　     ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("心脏"))
                        {
                            strPrintText += m_hasItemDetail["心脏"];
                            p_objGrp.DrawString("心    脏:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            if (m_hasItemDetail.Contains("肺部"))
                            {
                                p_objGrp.DrawString("肺部:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 20);
                                p_objGrp.DrawString("     " + m_hasItemDetail["肺部"].ToString(), p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 20);
                            }
                        }
                        else
                            if (m_hasItemDetail.Contains("肺部"))
                            {
                                strPrintText += m_hasItemDetail["肺部"];
                                p_objGrp.DrawString("肺    部:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                        m_blnIsFirstPrint[1] = false;
                    }
                }

                if (m_blnIsFirstPrint[2])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    strPrintText = "  　     ";
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("腹壁>>软"))
                            strPrintText += "软";
                        if (m_hasItemDetail.Contains("腹壁>>硬"))
                            strPrintText += "硬";
                    }
                    if (strPrintText != "  　     ")
                    {
                        p_objGrp.DrawString("腹　　壁:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                        m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                    }
                    m_blnIsFirstPrint[2] = false;
                }

                p_fntNormal.Dispose();
                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
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

                m_blnIsFirstPrint = new Boolean[] { true, true, true };
            }
        }
		/// <summary>
		/// 压痛
		/// </summary>
		private class clsPrintInPatMedRecPressPain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true };
			private string strPrintText = "  　 　　    ";
			private Font p_fntNormal = new Font("SimSun", 12 );
			private int m_intFlag = 0;


			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (m_blnIsFirstPrint[0])
                    {
                        if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                        {
                            m_blnHaveMoreLine = true;
                            return;
                        }


                        strPrintText = "";
                        if (m_hasItemDetail != null)
                        {
                    
                        if (m_hasItemDetail.Contains("部位压痛1"))
                            strPrintText += m_hasItemDetail["部位压痛1"];
                        if (m_hasItemDetail.Contains("部位压痛"))
                            strPrintText += "部位压痛     ";
                        if (m_hasItemDetail.Contains("部位反跳痛1"))
                            strPrintText += m_hasItemDetail["部位反跳痛1"];
                        if (m_hasItemDetail.Contains("部位反跳痛"))
                            strPrintText += "部位反跳痛";
                        if (strPrintText != "")
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        }
                        m_blnIsFirstPrint[0] = false;
                    }
                    if (m_blnIsFirstPrint[1])
                    {
                        if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                        {
                            m_blnHaveMoreLine = true;
                            return;
                        }
                        if (m_hasItemDetail != null)
                        {
                            if (m_hasItemDetail.Contains("肝大右肋下缘"))
                            {
                                if (m_hasItemDetail.Contains("脾大左肋缘下"))
                                {
                                    if (m_hasItemDetail.Contains("腹水征"))
                                    {
                                        p_objGrp.DrawString("肝大右肋下缘:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["肝大右肋下缘"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("脾大左肋缘下:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["脾大左肋缘下"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_objGrp.DrawString("腹水征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                                        p_objGrp.DrawString("       " + m_hasItemDetail["腹水征"], p_fntNormal, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                    else
                                    {
                                        p_objGrp.DrawString("肝大右肋下缘:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["肝大右肋下缘"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("脾大左肋缘下:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["脾大左肋缘下"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                }

                                else
                                {
                                    if (m_hasItemDetail.Contains("腹水征"))
                                    {
                                        p_objGrp.DrawString("肝大右肋下缘:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["肝大右肋下缘"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("腹水征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_objGrp.DrawString("       " + m_hasItemDetail["腹水征"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                    else
                                    {
                                        p_objGrp.DrawString("肝大右肋下缘:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["肝大右肋下缘"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                }
                            }
                            else
                            {
                                if (m_hasItemDetail.Contains("脾大左肋缘下"))
                                {
                                    if (m_hasItemDetail.Contains("腹水征"))
                                    {
                                        p_objGrp.DrawString("脾大左肋缘下:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["脾大左肋缘下"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("腹水征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_objGrp.DrawString("       " + m_hasItemDetail["腹水征"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                    else
                                    {
                                        p_objGrp.DrawString("脾大左肋缘下:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("             " + m_hasItemDetail["脾大左肋缘下"] + " mm", p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_intPosY += 20;
                                    }
                                }
                                else
                                {
                                    if (m_hasItemDetail.Contains("腹水征"))
                                    {
                                        p_objGrp.DrawString("腹水征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_objGrp.DrawString("       " + m_hasItemDetail["腹水征"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                        p_intPosY += 20;
                                    }

                                }
                            }
                        
                        m_blnIsFirstPrint[1] = false;
                    }
                    if (m_blnIsFirstPrint[2])
                    {
                        if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                        {
                            m_blnHaveMoreLine = true;
                            return;
                        }
                        strPrintText = "       ";
                        if (m_hasItemDetail != null)
                        {
                            if (m_hasItemDetail.Contains("肠鸣音>>存在"))
                            {
                                strPrintText += "存在";
                                p_objGrp.DrawString("肠鸣音:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                            if (m_hasItemDetail.Contains("肠鸣音>>消失"))
                            {
                                strPrintText += "消失";
                                p_objGrp.DrawString("肠鸣音:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                            if (m_hasItemDetail.Contains("肾区压叩痛"))
                            {
                                p_objGrp.DrawString("肾区压叩痛:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["肾区压叩痛"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                            strPrintText = "       ";
                            if (m_hasItemDetail.Contains("脊柱>>正常"))
                            {
                                strPrintText += "正常";
                                p_objGrp.DrawString("脊柱:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                            if (m_hasItemDetail.Contains("脊柱>>畸形"))
                            {
                                strPrintText += "畸形";
                                p_objGrp.DrawString("脊柱:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                            strPrintText = "        ";
                            if (m_hasItemDetail.Contains("肌张力>>左"))
                                strPrintText += "左:" + m_hasItemDetail["肌张力>>左"] + "  ";
                            if (m_hasItemDetail.Contains("肌张力>>右"))
                                strPrintText += "右:" + m_hasItemDetail["肌张力>>右"];
                            if (strPrintText != "        ")
                            {
                                p_objGrp.DrawString("肌张力:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                            }
                        }
                        m_blnIsFirstPrint[2] = false;
                    }
                }
				p_fntNormal.Dispose();
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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

				m_blnIsFirstPrint=new Boolean[] { true, true, true };
			}
		}
		/// <summary>
		/// 肌力
		/// </summary>
		private class clsPrintInPatMedRecMuscle : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true };
			private string strPrintText = "  　 　　    ";
			private Font p_fntNormal = new Font("SimSun", 12 );
			private int m_intFlag = 0;


			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_blnIsFirstPrint[0])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}

                   
					strPrintText = "       ";
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("肌力>>左上肢"))
                            strPrintText += "左上肢:" + m_hasItemDetail["肌力>>左上肢"] + "  ";
                        if (m_hasItemDetail.Contains("肌力>>左下肢"))
                            strPrintText += "左下肢:" + m_hasItemDetail["肌力>>左下肢"] + "   ";
                        if (m_hasItemDetail.Contains("肌力>>右上肢"))
                            strPrintText += "右上肢:" + m_hasItemDetail["肌力>>右上肢"] + "  ";
                        if (m_hasItemDetail.Contains("肌力>>右下肢"))
                            strPrintText += "右下肢:" + m_hasItemDetail["肌力>>右下肢"];
                        if (strPrintText != "       ")
                        {
                            p_objGrp.DrawString("肌力:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        }
                    }
					m_blnIsFirstPrint[0] = false;
				}
				if(m_blnIsFirstPrint[1])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("二头肌反射"))
                        {
                            if (m_hasItemDetail.Contains("三头肌反射"))
                            {
                                p_objGrp.DrawString("二头肌反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["二头肌反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("三头肌反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["三头肌反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("二头肌反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["二头肌反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("三头肌反射"))
                            {
                                p_objGrp.DrawString("三头肌反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["三头肌反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[1] = false;
				}
				if(m_blnIsFirstPrint[2])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("膝反射"))
                        {
                            if (m_hasItemDetail.Contains("踝反射"))
                            {
                                p_objGrp.DrawString("膝反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("           " + m_hasItemDetail["膝反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("踝反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("       " + m_hasItemDetail["踝反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("膝反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("       " + m_hasItemDetail["膝反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("踝反射"))
                            {
                                p_objGrp.DrawString("踝反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("       " + m_hasItemDetail["踝反射"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[2]= false;
				}
				p_fntNormal.Dispose();
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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

				m_blnIsFirstPrint = new Boolean[] { true, true, true };
			}
		}
		/// <summary>
		/// Rossolimo's征
		/// </summary>
		private class clsPrintInPatMedRecRossolimo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true ,true};
			private string strPrintText = "  　 　　    ";
			private Font p_fntNormal = new Font("SimSun", 12 );
			private int m_intFlag = 0;


			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_blnIsFirstPrint[0])
				{
					if (m_blnCheckBottom(ref p_intPosY,20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("Rossolimo's征:>>左"))
                        {
                            if (m_hasItemDetail.Contains("Rossolimo's征:>>右"))
                            {
                                p_objGrp.DrawString("Rossolimo's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("                 " + m_hasItemDetail["Rossolimo's征:>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("Rossolimo's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("                 " + m_hasItemDetail["Rossolimo's征:>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("Rossolimo's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("                 " + m_hasItemDetail["Rossolimo's征:>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("Rossolimo's征:>>右"))
                            {
                                p_objGrp.DrawString("Rossolimo's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("                 " + m_hasItemDetail["Rossolimo's征:>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[0] = false;
				}
				if(m_blnIsFirstPrint[1])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("Hoffman's征>>左"))
                        {
                            if (m_hasItemDetail.Contains("Hoffman's征>>右"))
                            {
                                p_objGrp.DrawString("Hoffman's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("               " + m_hasItemDetail["Hoffman's征>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("Hoffman's征:右", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("              " + m_hasItemDetail["Hoffman's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("Hoffman's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("               " + m_hasItemDetail["Hoffman's征:左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("Hoffman's征>>右"))
                            {
                                p_objGrp.DrawString("Hoffman's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("               " + m_hasItemDetail["Hoffman's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[1] = false;
				}
				if(   m_blnIsFirstPrint[2])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("Babinski's征>>左"))
                        {
                            if (m_hasItemDetail.Contains("Babinski's征>>右"))
                            {
                                p_objGrp.DrawString("Babinski's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("                " + m_hasItemDetail["Babinski's征>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("Babinski's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("                " + m_hasItemDetail["Babinski's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("Babinski's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("               " + m_hasItemDetail["Babinski's征>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("Babinski's征>>右"))
                            {
                                p_objGrp.DrawString("Babinski's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("                " + m_hasItemDetail["Babinski's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[2] = false;
				}
				if(   m_blnIsFirstPrint[3] )
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("Kernig's征>>左"))
                        {
                            if (m_hasItemDetail.Contains("Kernig's征>>右"))
                            {
                                p_objGrp.DrawString("Kernig's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("              " + m_hasItemDetail["Kernig's征>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("Kernig's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_objGrp.DrawString("              " + m_hasItemDetail["Kernig's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                                p_intPosY += 20;
                            }
                            else
                            {
                                p_objGrp.DrawString("Kernig's征:左:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("              " + m_hasItemDetail["Kernig's征>>左"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                        else
                        {
                            if (m_hasItemDetail.Contains("Kernig's征>>右"))
                            {
                                p_objGrp.DrawString("Kernig's征:右:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_objGrp.DrawString("              " + m_hasItemDetail["Kernig's征>>右"], p_fntNormal, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                                p_intPosY += 20;
                            }
                        }
                    }
					m_blnIsFirstPrint[3] = false;
				}
				p_fntNormal.Dispose();
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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

				m_blnIsFirstPrint = new Boolean[] { true, true, true, true };
			}
		}
		/// <summary>
		/// 共济失调
		/// </summary>
		private class clsPrintInPatMedRecAnormal : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true};
			private Font p_fntNormal = new Font("SimSun", 12);
			private int m_intFlag = 0;
			private string  strPrintText="";


			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_blnIsFirstPrint[0])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}

					strPrintText = "         ";
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("共济失调"))
                        {
                            strPrintText += m_hasItemDetail["共济失调"];
                            p_objGrp.DrawString("共济失调:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

                        }
                    }
					m_blnIsFirstPrint[0] = false;
				}
				if(m_blnIsFirstPrint[1])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "         ";
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("深浅感觉"))
                        {
                            strPrintText += m_hasItemDetail["深浅感觉"];
                            p_objGrp.DrawString("深浅感觉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

                        }
                    }
					m_blnIsFirstPrint[1] = false;

				}
				if(m_blnIsFirstPrint[2])
				{
					if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "         ";
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("下肢浮肿"))
                        {
                            strPrintText += m_hasItemDetail["下肢浮肿"];
                            p_objGrp.DrawString("下肢浮肿:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

                        }
                    }
					m_blnIsFirstPrint[2] = false;
				}
				p_fntNormal.Dispose();
				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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

				m_blnIsFirstPrint = new Boolean[] { true, true, true };
			}
		}
		/// <summary>
		/// 专科情况
		/// </summary>
		private class clsPrintInPatMedRecSpecializedSituation : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText = "    ";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal = new Font("SimSun", 12);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if (m_hasItems != null)
					if (m_hasItems.Contains("专科情况"))
						objItemContent = m_hasItems["专科情况"] as clsInpatMedRec_Item;
				if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if (m_blnIsFirstPrint)
				{
					if (m_blnCheckBottom(ref p_intPosY, 120, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}

					p_objGrp.DrawString("专科情况:", new Font("SimSun", 12), Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail != null)
                    {
                        if (m_hasItemDetail.Contains("专科情况"))
                        {
                            strPrintText += m_hasItemDetail["专科情况"];
                            p_intPosY += 20;
                        }
                    }
					//if (strPrintText != "    ") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		/// 初步诊断
		/// </summary>
		private class clsPrintInPatMedRecPrimaryDiagnosis : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText = "  　";
			private Font p_fntNormal = new Font("SimSun", 12);
			private clsInpatMedRec_Item objItemContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if (m_hasItems != null)
					if (m_hasItems.Contains("初步诊断"))
						objItemContent = m_hasItems["初步诊断"] as clsInpatMedRec_Item;
				if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if (m_blnIsFirstPrint)
				{
					if (m_blnCheckBottom(ref p_intPosY, 120, p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("初步诊断:", new Font("SimSun", 12), Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail != null)
                    {

                        if (m_hasItemDetail.Contains("初步诊断"))
                        {
                            strPrintText += m_hasItemDetail["初步诊断"];
                            p_intPosY += 20;
                        }
                    }
					//if (strPrintText != "   ") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					string p_strText = "医生签名： ";
					if (m_hasItemDetail != null && m_hasItemDetail.Contains("医师签名"))
						p_strText += m_hasItemDetail["医师签名"] + " ";
					else
						p_strText += "      ";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("日期"))
						p_strText += DateTime.Parse(m_hasItemDetail["日期"].ToString()).ToString("yyyy年MM月dd日");
					else
						p_strText += "200　年　月　日";
					p_objGrp.DrawString(p_strText, p_fntNormal, Brushes.Black, (int)enmRectangleInfo.RightX - 300, p_intPosY);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if (m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

					p_intPosY += 20;

					intLine++;
				}

				if (m_objPrintContext.m_BlnHaveNextLine())
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
		internal static Hashtable m_hasItemDetail;
		/// <summary>
		/// 把所有项按描述为键放入Hastable
		/// </summary>
		/// <param name="p_hasItem"></param>
		/// <param name="p_ctlItem"></param>
		/// <param name="p_objItemArr"></param>
		/// <returns></returns>
		protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
		{
			if (p_objItemArr == null)
				return null;
			Hashtable hasItem = new Hashtable(400);
			m_hasItemDetail = new Hashtable(400);
			foreach (clsInpatMedRec_Item objItem in p_objItemArr)
			{
				try
				{
					if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
					{
						continue;
					}
					else
					{
						m_hasItemDetail.Add(objItem.m_strItemName, objItem.m_strItemContent);
						hasItem.Add(objItem.m_strItemName, objItem);

					}
				}
				catch { continue; }
			}
			return hasItem;
		}
	}
}
