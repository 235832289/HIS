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
	/// 呼吸内科住院病历打印工具类
	/// </summary>
	public class clsIMR_BreathPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_BreathPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("呼吸内科住院病历",290),
																		   new clsPrintInPatientCaseMain(),
																		   new clsPrintInPatientCaseCurrent(),
																		   new clsPrintInPatMedRecHistory(),
																		   new clsPrintInPatientFamily(),
																		   new clsPrintInPatMedRecMedical(),
																		   new clsPrintLab(),
																		   new clsPrintInPatMedRecPic(),
																		   new clsPrintPatientPrimaryDiagnoseInfo(),
																		   new clsPrintOutDiagnose(),
                                                                            new clsPrint1(),
																		   new clsPrintInPatMedRecSign(),
                                                                            new clsPrint2()
																	   });
		}
	
		#region Print Class
		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatientCaseMain : clsIMR_PrintLineBase
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
					p_intPosY += 20;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					p_objGrp.DrawString("主诉：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
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
		private class clsPrintInPatientCaseCurrent : clsIMR_PrintLineBase
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
					p_objGrp.DrawString("现病史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
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
		/// 签名和日期
		/// </summary>
		private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] objSignContent = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                objSignContent = m_objGetContentFromItemArr(new string[] { "主治医师签名", "记录医师", "签字时间" });
				if(objSignContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 40;
                p_objGrp.DrawString("主治医师签名：" + (objSignContent[0] != null ? (objSignContent[0].m_strItemContent == null ? "" : objSignContent[0].m_strItemContent) : ""), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                
                p_objGrp.DrawString("记录医师：" + (objSignContent[1] != null ? (objSignContent[1].m_strItemContent == null ? "" : objSignContent[1].m_strItemContent) : ""), p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);

                try
                {

                    p_objGrp.DrawString("日期：" + (objSignContent[2] != null ? (objSignContent[2].m_strItemContent == null ? "" : DateTime.Parse(objSignContent[2].m_strItemContent).ToString("yyyy年MM月dd日")) : ""), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);

                }
                catch { }

                p_intPosY += 20;
				
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}

		}

        private class clsPrint1 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtFinallySignature")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("主治医师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 100, p_intPosY, p_objGrp);
                   // p_intPosY += 20;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
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
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtOnDoc")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("记录医师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 300, p_intPosY, p_objGrp);
                  //  p_intPosY += 20;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
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
      

		/// <summary>
		/// 病史
		/// </summary>
		private class clsPrintInPatMedRecHistory : clsIMR_PrintLineBase
		{
//			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
//			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true};
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private Font m_fotFont = new Font("SimSun", 14,FontStyle.Bold);

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if(m_hasItems == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				#region 打印病史－要求有没有内容都打印
				string strValue = "";
				int intHeight = 0;
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,80))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("既往史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					p_objGrp.DrawString("有□麻疹肺炎,□百日咳,□哮喘,□肺炎,□肺结核,□鼻窦炎,□过敏性鼻炎病史",p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);
					p_objGrp.DrawString("  "+m_strIsExit("既往史>>麻疹肺炎")+"       "+m_strIsExit("既往史>>百日咳")+"     "+m_strIsExit("既往史>>哮喘")+"    "+m_strIsExit("既往史>>肺炎")
						+"   "+m_strIsExit("既往史>>肺结核")+"     "+m_strIsExit("既往史>>鼻窦炎")+"      "+m_strIsExit("既往史>>过敏性鼻炎"),m_fotFont,Brushes.Black,m_intRecBaseX+50,p_intPosY);
					p_intPosY += 20;
					strValue = "慢性咳嗽"+m_strGetItemContent("慢性咳嗽>>年")+"年,痰"+m_strGetItemContent("慢性咳嗽>>色")+"色，";
					int intLen = Convert.ToInt32(p_objGrp.MeasureString(strValue,p_fntNormalText).Width+5);
					p_objGrp.DrawString(strValue,p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_objGrp.DrawString("□粘稠,□稀",p_fntNormalText,Brushes.Black,m_intRecBaseX+20+intLen,p_intPosY);
					p_objGrp.DrawString(m_strIsExit("慢性咳嗽>>粘稠")+"   "+m_strIsExit("慢性咳嗽>>稀"),m_fotFont,Brushes.Black,m_intRecBaseX+20+intLen,p_intPosY);
					
					p_objGrp.DrawString(", 气味:□无,□恶臭",p_fntNormalText,Brushes.Black,m_intRecBaseX+130+intLen,p_intPosY);
					p_objGrp.DrawString("     "+m_strIsExit("慢性咳嗽>>无")+"  "+m_strIsExit("慢性咳嗽>>恶臭"),m_fotFont,Brushes.Black,m_intRecBaseX+130+intLen,p_intPosY);
					
					p_objGrp.DrawString("  痰量:"+m_strGetItemContent("慢性咳嗽>>毫升/日")+"毫升/日",p_fntNormalText,Brushes.Black,m_intRecBaseX+280+intLen,p_intPosY);
					p_intPosY +=20;
					strValue = "    有无咯血、呼吸困难、浮肿、紫绀症状："+m_strGetItemContent("有无咯血、呼吸困难、浮肿、紫绀症状")+"; \n    其它:"+m_strGetItemContent("既往史>>其它");
//					strValue += "\n ";
					m_mthPrintDioa(ref p_intPosY, p_objGrp,p_fntNormalText,strValue);
					m_blnIsPrint[0] = false;
				}
				if(m_blnIsPrint[1])
				{
					if(m_blnCheckBottom(ref p_intPosY,40))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("过敏史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY +=20;
					p_objGrp.DrawString("    对□花粉,□虾蟹,□药物"+m_strGetItemContent("过敏史>>药物说明")+",其他:"+m_strGetItemContent("过敏史>>其他"),p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_objGrp.DrawString("    "+m_strIsExit("过敏史>>花粉")+"    "+m_strIsExit("过敏史>>虾蟹")+"    "+m_strIsExit("过敏史>>药物"),m_fotFont,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_intPosY +=20;
					m_blnIsPrint[1] = false;
				}
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,60))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("个人史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY +=20;
					strValue = "    吸烟";
					if(m_strGetItemContent("个人史>>吸烟>>无").Trim().ToLower() == "true")
					{
						strValue += "无";
					}
					else
					{
						strValue += m_strGetItemContent("个人史>>吸烟>>年")+"年,"+m_strGetItemContent("个人史>>吸烟>>支/日")+"支/日";
					}
					strValue += ";饮酒";
					if(m_strGetItemContent("个人史>>饮酒>>无").Trim().ToLower() == "true")
					{
						strValue += "无。";
					}
					else
					{
						strValue += m_strGetItemContent("个人史>>饮酒>>年")+"年,"+m_strGetItemContent("个人史>>饮酒>>毫升/日")+"毫升/日。";
					}
					strValue += "工作生活环境("+m_strIsExit("工作生活环境>>潮湿","●","○")+"潮湿,"+m_strIsExit("工作生活环境>>一般","●","○")+"一般,"+m_strIsExit("工作生活环境>>良好","●","○")+"良好),";	
					
					strValue += "粉尘接触("+m_strIsExit("工作生活环境>>粉尘接触>>有","●","○")+"有,"+m_strIsExit("工作生活环境>>粉尘接触>>无","●","○")+"无"+")";
					m_mthPrintDioa(ref p_intPosY, p_objGrp,p_fntNormalText,strValue);
					m_blnIsPrint[2] = false;
				
				}
				if(m_blnIsPrint[3] && m_hasItems.ContainsKey("月经生育史"))
				{
					if(m_blnCheckBottom(ref p_intPosY,40))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("月经生育史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 30;
			
					string strLastTime = "";
					if(m_strGetItemContent("月经生育史>>月经情况")!="已绝经")
						strLastTime = m_strGetItemContent("月经生育史>>Lmp>>年")+"/"+m_strGetItemContent("月经生育史>>Lmp>>月")+"/"+m_strGetItemContent("月经生育史>>Lmp>>日")+",";

					p_objGrp.DrawString(m_strGetItemContent("月经生育史>>初潮")+"            "+strLastTime+m_strGetItemContent("月经生育史>>月经情况")+"；生育情况: 孕"+m_strGetItemContent("月经生育史>>生育情况>>孕")+" 产"+m_strGetItemContent("月经生育史>>生育情况>>产")+" 流"+m_strGetItemContent("月经生育史>>生育情况>>流"),p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);

					p_objGrp.DrawLine(new Pen(Brushes.Black),m_intRecBaseX+90,p_intPosY+10,m_intRecBaseX+150,p_intPosY+10);

					p_objGrp.DrawString(m_strGetItemContent("月经生育史>>经期"),new Font("",8),Brushes.Black,m_intRecBaseX+100,p_intPosY - 5);
					p_objGrp.DrawString(m_strGetItemContent("月经生育史>>周期"),new Font("",8),Brushes.Black,m_intRecBaseX+100,p_intPosY + 13);

					p_intPosY += 30;
					m_mthPrintDioa(ref p_intPosY, p_objGrp,p_fntNormalText,m_strGetItemContent("月经生育史>>月经史"));
					m_blnIsPrint[3] = false;
				}
				#endregion
				int intLine = 0;
					m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
				for(int i=0;i<m_blnIsPrint.Length;i++)
					m_blnIsPrint[i] = true;

			}
			
			private string m_strGetItemContent(string p_strKey)
			{
				if(m_hasItems.ContainsKey(p_strKey))
				{
					clsInpatMedRec_Item objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
					if(objItemContent != null)
					{
						if(objItemContent.m_strItemContent != null)
							return objItemContent.m_strItemContent;
					}
				}
				return "    ";
			}
			private string m_strIsExit(string p_strKey)
			{
				if(m_hasItems.ContainsKey(p_strKey))
					return "√";
				return "  ";
			}
			private string m_strIsExit(string p_strKey,string p_strTrue,string p_strFalse)
			{
				if(m_hasItems.ContainsKey(p_strKey))
					return p_strTrue;
				return p_strFalse;
			}			/// <summary>
			/// 检测是否需要换页
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			/// <param name="p_intHeight"></param>
			/// <returns></returns>
			private bool m_blnCheckBottom(ref int p_intPosY,int p_intHeight)
			{
				if(p_intPosY+p_intHeight+20 > ((int)enmRectangleInfo.BottomY -50))
				{
					p_intPosY += 500;
					return true;
				}
				return false;
			}
			/// <summary>
			/// 诊断打印
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			/// <param name="p_strTextArr">标题</param>
			/// <param name="p_strFirstCont">初步诊断</param>
			/// <param name="p_strLastCont">最后诊断</param>
			private void m_mthPrintDioa(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText)
			{
//new Rectangle(m_intRecBaseX+20,p_intPosY,620,20)

				RectangleF rtg = new RectangleF(m_intRecBaseX+20,p_intPosY,700,20);
				string strText = p_strText;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				rtg.Y = p_intPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				p_intPosY += Convert.ToInt32(rtg.Height);
			}
		}

		/// <summary>
		/// 家族史
		/// </summary>
		private class clsPrintInPatientFamily : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("家族史"))
						objItemContent = m_hasItems["家族史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					p_objGrp.DrawString("家族史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
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

		/// 体格检查
		/// </summary>
		private class clsPrintInPatMedRecMedical : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
			private int m_intTimes = 0;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				string strPrintText = "";
				#region Print
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,80,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_intPosY += 20;
					p_objGrp.DrawString("体 格 检 查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 40;
					p_objGrp.DrawString("一般情况: T         P            R            BP:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_objGrp.DrawString(m_strGetValue("一般情况>>T",1)+"℃,",p_fntNormalText,Brushes.Black,m_intRecBaseX+95,p_intPosY);
					//					if(m_hasItemDetail.Contains("一般情况>>P"))
					p_objGrp.DrawString(m_strGetValue("一般情况>>P",2)+"次/分,",p_fntNormalText,Brushes.Black,m_intRecBaseX+180,p_intPosY);
					//					if(m_hasItemDetail.Contains("一般情况>>R"))
					p_objGrp.DrawString(m_strGetValue("一般情况>>R",2)+"次/分,",p_fntNormalText,Brushes.Black,m_intRecBaseX+270,p_intPosY);
					//					if(m_hasItemDetail.Contains("一般情况>>BP1"))
					strPrintText += m_strGetValue("一般情况>>BP1",2)+"/";
					//					if(m_hasItemDetail.Contains("一般情况>>BP2"))
					strPrintText += m_strGetValue("一般情况>>BP2",2)+"mmHg。";
					p_objGrp.DrawString(strPrintText,p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
					
					p_intPosY += 20;
					strPrintText = "    发育( ";
					strPrintText += m_strGetCheckValue("一般情况>>发育>>好")+"好、";
					strPrintText += m_strGetCheckValue("一般情况>>发育>>中")+"中、";
					strPrintText += m_strGetCheckValue("一般情况>>发育>>差")+"差), 营养(";
					strPrintText += m_strGetCheckValue("一般情况>>营养>>好")+"好、";
					strPrintText += m_strGetCheckValue("一般情况>>营养>>中")+"中、";
					strPrintText += m_strGetCheckValue("一般情况>>营养>>差")+"差), ";
					strPrintText += "神志"+m_strGetValue("一般情况>>神志",3)+",";
					strPrintText += "对答"+m_strGetValue("一般情况>>对答",3)+",";
					strPrintText += "面容"+m_strGetValue("一般情况>>面容",3)+",";
					strPrintText += "体位"+m_strGetValue("一般情况>>体位",3)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
					m_blnIsPrint[0] = false;
				}
				if(m_blnIsPrint[1])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("皮肤：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "     ";
					strPrintText += "黄疸"+m_strGetValue("皮肤>>黄疸",3)+",";
					strPrintText += "紫绀"+m_strGetValue("皮肤>>紫绀",3)+",";
					strPrintText += "色泽干湿"+m_strGetValue("皮肤>>色泽干湿",3)+",";
					strPrintText += "瘀点瘀斑"+m_strGetValue("皮肤>>瘀点瘀斑",3)+",";
					strPrintText += "水肿"+m_strGetValue("皮肤>>水肿",3)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
					p_objGrp.DrawString("淋巴结:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText,"       "+ m_strGetValue("淋巴结",1)+"。");
					m_blnIsPrint[1] = false;
				}
				
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("头颈部:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
					strPrintText += "眼睑"+m_strGetValue("头颈部>>眼睑",3)+",";
					strPrintText += "结膜巩膜黄染"+m_strGetValue("头颈部>>结膜巩膜黄染",3)+",";
					strPrintText += "瞳孔左"+m_strGetValue("头颈部>>瞳孔左",1)+"mm,";
					strPrintText += "右"+m_strGetValue("头颈部>>瞳孔右",1)+"mm,";
					strPrintText += "对光反射"+m_strGetValue("头颈部>>对光反射",3)+",";
					strPrintText += "耳"+m_strGetValue("头颈部>>耳",3)+",";
					strPrintText += "鼻"+m_strGetValue("头颈部>>鼻",3)+",";
					strPrintText += "颈静脉"+m_strGetValue("头颈部>>颈静脉",3)+",";
					strPrintText += "肝颈征"+m_strGetValue("头颈部>>肝颈征",3)+",";
					strPrintText += "甲状腺"+m_strGetValue("头颈部>>甲状腺",3)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[2] = false;
				}
				
				if(m_blnIsPrint[3])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "";
					strPrintText += "气管("+m_strGetCheckValue("头颈部>>气管>>居中")+"居中、";
					strPrintText += m_strGetCheckValue("头颈部>>气管>>偏右")+"偏右、";
					strPrintText += m_strGetCheckValue("头颈部>>气管>>偏左")+"偏左)。";
					strPrintText += "\n扁桃腺：左(";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>正常")+"正常,";
					strPrintText += m_strGetValue("头颈部>>扁桃腺>>左>>正常描述",3)+"、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>肿大")+"肿大(";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>肿大>>Ⅰ")+"Ⅰ、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>肿大>>Ⅱ")+"Ⅱ、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>肿大>>Ⅲ")+"Ⅲ)、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>左>>化脓")+"化脓)";
					strPrintText += "\n        右(";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>正常")+"正常,";
					strPrintText += m_strGetValue("头颈部>>扁桃腺>>右>>正常描述",3)+"、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>肿大")+"肿大(";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>肿大>>Ⅰ")+"Ⅰ、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>肿大>>Ⅱ")+"Ⅱ、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>肿大>>Ⅲ")+"Ⅲ)、";
					strPrintText += m_strGetCheckValue("头颈部>>扁桃腺>>右>>化脓")+"化脓)";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[3] = false;
				}
				
				if(m_blnIsPrint[4])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("胸廓:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
					strPrintText += m_strGetCheckValue2("胸廓>>形状正常")+"形状正常、";
					strPrintText += m_strGetCheckValue2("胸廓>>桶状胸")+"桶状胸、";
					strPrintText += m_strGetCheckValue2("胸廓>>扁平胸")+"扁平胸、";
					strPrintText += m_strGetCheckValue2("胸廓>>鸡胸")+"鸡胸、";
					strPrintText += m_strGetCheckValue2("胸廓>>漏斗胸")+"漏斗胸;";
					strPrintText += m_strGetCheckValue2("胸廓>>胸壁饱满")+"胸壁饱满、";
					strPrintText += m_strGetCheckValue2("胸廓>>凹陷")+"凹陷(";
					strPrintText += m_strGetCheckValue2("胸廓>>凹陷>>左")+"左、";
					strPrintText += m_strGetCheckValue2("胸廓>>凹陷>>右")+"右)";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[4] = false;
				}
				
				if(m_blnIsPrint[5])
				{
					if(m_blnCheckBottom(ref p_intPosY,50,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("肺脏：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					Font fon = new Font("SimSun", 10.5f,FontStyle.Italic|FontStyle.Bold);
					p_objGrp.DrawString("望诊：",fon,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "     ";
					strPrintText += "呼吸运动"+m_strGetCheckValue("肺脏>>望诊>>呼吸运动>>正常")+"正常、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸运动>>异常")+"异常：";
					strPrintText += m_strGetCheckValue2("肺脏>>望诊>>呼吸运动>>左")+"左、";
					strPrintText += m_strGetCheckValue2("肺脏>>望诊>>呼吸运动>>右")+"右(";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸运动>>增强")+"增强、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸运动>>减弱")+"减弱)；";
					strPrintText += "呼吸方式("+m_strGetCheckValue("肺脏>>望诊>>呼吸方式>>胸式")+"胸式、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸方式>>腹式")+"腹式、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸方式>>胸腹式")+"胸腹式)；";
					strPrintText += "呼吸节律("+m_strGetCheckValue("肺脏>>望诊>>呼吸节律>>规则")+"规则、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>呼吸节律>>不规则")+"不规则)；";
					strPrintText += "肋间隙("+m_strGetCheckValue("肺脏>>望诊>>肋间隙>>正常")+"正常、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>肋间隙>>增宽")+"增宽、";
					strPrintText += m_strGetCheckValue("肺脏>>望诊>>肋间隙>>变窄")+"变窄,";
					strPrintText += "部位："+m_strGetValue("肺脏>>望诊>>部位",4)+")。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[5] = false;
					fon.Dispose();
				}
				if(m_blnIsPrint[6])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					Font fon = new Font("SimSun", 10.5f,FontStyle.Italic|FontStyle.Bold);
					p_objGrp.DrawString("触诊：",fon,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "     ";
					strPrintText += "语颤"+m_strGetCheckValue("肺脏>>触诊>>语颤>>正常")+"正常、";
					strPrintText += m_strGetCheckValue("肺脏>>触诊>>语颤>>增强")+"增强、";
					strPrintText += m_strGetCheckValue("肺脏>>触诊>>语颤>>减弱")+"减弱(";
					strPrintText += m_strGetCheckValue2("肺脏>>触诊>>语颤>>左")+"左、";
					strPrintText += m_strGetCheckValue2("肺脏>>触诊>>语颤>>右")+"右)；";
					strPrintText += "胸膜摩擦感("+m_strGetCheckValue("肺脏>>触诊>>胸膜摩擦感>>无")+"无、";
					strPrintText += m_strGetCheckValue("肺脏>>触诊>>胸膜摩擦感>>有")+"有：";
					strPrintText += "部位： "+m_strGetValue("肺脏>>触诊>>胸膜摩擦感>>部位",4)+")；";
					strPrintText += "皮下捻发感("+m_strGetCheckValue("肺脏>>触诊>>皮下捻发感>>无")+"无、";
					strPrintText += m_strGetCheckValue("肺脏>>触诊>>皮下捻发感>>有")+"有：";
					strPrintText += "部位："+m_strGetValue("肺脏>>触诊>>皮下捻发感>>部位",4)+")。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[6] = false;
					fon.Dispose();
				}
				if(m_blnIsPrint[7])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					Font fon = new Font("SimSun", 10.5f,FontStyle.Italic|FontStyle.Bold);
					p_objGrp.DrawString("叩诊：",fon,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "     ";
					strPrintText += "左侧"+m_strGetCheckValue2("肺脏>>叩诊>>正常清音")+"正常清音、";
					strPrintText += m_strGetCheckValue2("肺脏>>叩诊>>浊音")+"浊音、";
					strPrintText += m_strGetCheckValue2("肺脏>>叩诊>>实音")+"实音、";
					strPrintText += m_strGetCheckValue2("肺脏>>叩诊>>过清音")+"过清音、";
					strPrintText += m_strGetCheckValue2("肺脏>>叩诊>>鼓音")+"鼓音，";
					strPrintText += "(部位："+m_strGetValue("肺脏>>叩诊>>部位",4)+")；";
					strPrintText += "\n     右侧：肺下界肩胛线：右"+m_strGetValue("肺脏>>叩诊>>肺下界肩胛线>>右肋间",2)+"肋间，";
					strPrintText += "左"+m_strGetValue("肺脏>>叩诊>>肺下界肩胛线>>左肋间",2)+"肋间，";
					strPrintText += "运动度：右"+m_strGetValue("肺脏>>叩诊>>运动度>>右",1)+"mm，";
					strPrintText += "左"+m_strGetValue("肺脏>>叩诊>>运动度>>左",1)+"mm。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[7] = false;
					fon.Dispose();
				}
				if(m_blnIsPrint[8])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					Font fon = new Font("SimSun", 10.5f,FontStyle.Italic|FontStyle.Bold);
					p_objGrp.DrawString("听诊：",fon,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "     ";
					strPrintText += "呼吸音：左"+m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>左>>清")+"清、";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>左>>增粗")+"增粗、";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>左>>减弱")+"减弱；";
					strPrintText += "右"+m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>右>>清")+"清、";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>右>>增粗")+"增粗、";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>呼吸音>>右>>减弱")+"减弱；";
					strPrintText += "罗音"+m_strGetCheckValue("肺脏>>听诊>>罗音>>无")+"无、";
					strPrintText += m_strGetCheckValue("肺脏>>听诊>>罗音>>有")+"有(";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>罗音>>干性")+"干性(";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>罗音>>鼾音")+"鼾音、";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>罗音>>哨笛音")+"哨笛音)，";
					strPrintText += "量"+m_strGetValue("肺脏>>听诊>>罗音>>干性>>量",2)+"，";
					strPrintText += "部位"+m_strGetValue("肺脏>>听诊>>罗音>>干性>>部位",4)+")；";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>罗音>>湿性")+"湿性(";
					strPrintText += "水泡音"+m_strGetValue("肺脏>>听诊>>罗音>>水泡音>>水泡音",3)+"，";
					strPrintText += "量"+m_strGetValue("肺脏>>听诊>>罗音>>水泡音>>量",2)+"，";
					strPrintText += "部位"+m_strGetValue("肺脏>>听诊>>罗音>>水泡音>>部位",4)+")；";
					strPrintText += m_strGetCheckValue2("肺脏>>听诊>>罗音>>湿性>>捻发音>>有")+"捻发音,";
					strPrintText += "部位"+m_strGetValue("肺脏>>听诊>>罗音>>湿性>>捻发音>>部位",4)+")；";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[8] = false;
					fon.Dispose();
				}
				if(m_blnIsPrint[9])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "     ";
					strPrintText += "语音传导"+m_strGetCheckValue("肺脏>>听诊>>语音传导>>正常")+"正常、";
					strPrintText += m_strGetCheckValue("肺脏>>听诊>>语音传导>>减弱")+"减弱、";
					strPrintText += m_strGetCheckValue("肺脏>>听诊>>语音传导>>增强")+"增强(";
					strPrintText += "部位："+m_strGetValue("肺脏>>听诊>>语音传导>>部位",4)+")；";
					strPrintText += "胸膜摩擦音"+m_strGetCheckValue("肺脏>>听诊>>胸膜摩擦音>>无")+"无、";
					strPrintText += m_strGetCheckValue("肺脏>>听诊>>胸膜摩擦音>>有")+"有(";
					strPrintText += "部位："+m_strGetValue("肺脏>>听诊>>胸膜摩擦音>>部位",4)+")。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[9] = false;
				}
				if(m_blnIsPrint[10])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("心脏：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
					strPrintText += "心界"+m_strGetValue("心脏>>心界",4)+"，";
					strPrintText += "心尖搏动部位"+m_strGetValue("心脏>>心尖搏动部位",4)+"，";
					strPrintText += "心率"+m_strGetValue("心脏>>心率",1)+"次/分，";
					strPrintText += "心律"+m_strGetValue("心脏>>心律",4)+"，";
					strPrintText += "S1最响部位"+m_strGetValue("心脏>>S1最响部位",4)+"，";
					strPrintText += "P2("+m_strGetCheckValue2("心脏>>P2>>亢进")+"亢进、";
					strPrintText += m_strGetCheckValue2("心脏>>P2>>S2分裂")+"S2分裂、";
					strPrintText += m_strGetCheckValue2("心脏>>P2>>减弱")+"减弱、";
					strPrintText += m_strGetCheckValue2("心脏>>P2>>消失")+"消失)，";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[10] = false;
				}
				if(m_blnIsPrint[11])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					strPrintText = "杂音"+m_strGetValue("心脏>>杂音",8)+"，";
					strPrintText += "心包磨擦音"+m_strGetValue("心脏>>心包磨擦音",6)+"，";
					strPrintText += "其他心音"+m_strGetValue("心脏>>其他心音",6)+"。";
					strPrintText += "其他"+m_strGetValue("心脏>>其他",4)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[11] = false;
				}
				if(m_blnIsPrint[12])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("腹部：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
					strPrintText += "腹壁"+m_strGetValue("腹部>>腹壁",3)+"，";
					strPrintText += "肝上界:右锁骨中线第"+m_strGetValue("腹部>>肝上界",1)+"肋间，肋下";
					strPrintText += m_strGetValue("腹部>>肋下",2)+"，";
					strPrintText += "脾"+m_strGetValue("腹部>>脾",3)+"，";
					strPrintText += "腹水征"+m_strGetValue("腹部>>腹水征",3)+"，";
					strPrintText += "包块"+m_strGetCheckValue("腹部>>包块>>无")+"无、";
					strPrintText += m_strGetCheckValue("腹部>>包块>>有")+"有(";
					strPrintText += "性质、部位"+m_strGetValue("腹部>>包块>>部位",3)+")，";
					strPrintText += "肝区叩痛"+m_strGetValue("腹部>>肝区叩痛",3)+"，";
					strPrintText += "Murphy氏征"+m_strGetValue("腹部>>Murphy氏征",3)+"，";
					strPrintText += "肠鸣音"+m_strGetValue("腹部>>肠鸣音",3)+"，";
					strPrintText += "肾区叩痛"+m_strGetValue("腹部>>肾区叩痛",3)+"，";
					strPrintText += "输尿管行程压痛"+m_strGetValue("腹部>>输尿管行程压痛",3)+"，";
					strPrintText += "其他"+m_strGetValue("腹部>>其他",3)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[12] = false;
				}
				if(m_blnIsPrint[13])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("四肢：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
					strPrintText += "关节"+m_strGetValue("四肢>>关节",4)+"，";
					strPrintText += "杵状指（趾）"+m_strGetValue("四肢>>杵状指（趾）",4)+"，";
					strPrintText += "畸形"+m_strGetValue("四肢>>畸形",4)+"，";
					strPrintText += "其他"+m_strGetValue("四肢>>其他",4)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[13] = false;
				}
				if(m_blnIsPrint[14])
				{
					if(m_blnCheckBottom(ref p_intPosY,30,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("脊柱：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      "+m_strGetValue("体格检查>>脊柱",4)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[14] = false;
				}
				if(m_blnIsPrint[15])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("神经反射：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "          "+m_strGetValue("体格检查>>神经反射",4)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[15] = false;
				}
				if(m_blnIsPrint[16])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("其他：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      "+m_strGetValue("体格检查其他",4)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[16] = false;
				}
				#endregion Print


				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsPrint = new Boolean[]{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
			private string m_strGetValue(string p_strKeyValue,int p_intBrankCount)
			{
				if(m_hasItemDetail.Contains(p_strKeyValue))
					return m_hasItemDetail[p_strKeyValue]+"";
				string str = "　";
				for(int i=1;i<p_intBrankCount;i++)
					str += str;
				return str;
			}
			private string m_strGetCheckValue(string p_strKeyValue)
			{
				if(m_hasItemDetail.Contains(p_strKeyValue))
					return "●";
				return "○";
			}
			private string m_strGetCheckValue2(string p_strKeyValue)
			{
				if(m_hasItemDetail.Contains(p_strKeyValue))
					return "[√]";
				return "□";
			}

		}
		/// <summary>
		/// 实验室和有关辅助检查结果
		/// </summary>
		private class clsPrintLab : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("实验室和有关辅助检查结果"))
						objItemContent = m_hasItems["实验室和有关辅助检查结果"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					p_objGrp.DrawString("实验室和有关辅助检查结果：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("实验室和有关辅助检查结果：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("实验室和有关辅助检查结果：",m_objPrintContext.m_ObjModifyUserArr);
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
					p_objGrp.DrawString("胸部X线征：",p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
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
		///修正诊断与初步诊断
		///	</summary>
		private class clsPrintPatientPrimaryDiagnoseInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;
			private clsInpatMedRec_Item[] objChekcContent = null;
		
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objChekcContent = m_objGetContentFromItemArr(new string[]{"修正诊断","初步诊断"});
			
				if(objChekcContent == null || m_hasItems == null)
				{
					p_intPosY += 40;
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnIsFirstPrint)
				{	
					p_intPosY += 20;
					p_objGrp.DrawString("修正诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_objGrp.DrawString("初步诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+360,p_intPosY);
					p_intPosY += 20;
					if(objChekcContent[0] != null)
					{
						m_objPrintContext1.m_mthSetContextWithCorrectBefore((objChekcContent[0].m_strItemContent==null ? "" : objChekcContent[0].m_strItemContent)  ,(objChekcContent[0].m_strItemContentXml==null ? "<root />" : objChekcContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objChekcContent[0]!=null);
						m_mthAddSign2("修正诊断：",m_objPrintContext1.m_ObjModifyUserArr);
					}
					else
						p_intPosY += 20;
					if (objChekcContent[1] != null)
					{
						m_objPrintContext2.m_mthSetContextWithCorrectBefore((objChekcContent[1].m_strItemContent==null ? "" : objChekcContent[1].m_strItemContent)  ,(objChekcContent[1].m_strItemContentXml==null ? "<root />" : objChekcContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objChekcContent[1]!=null);
						m_mthAddSign2("初步诊断：",m_objPrintContext2.m_ObjModifyUserArr);
					}
					else
						p_intPosY += 20;
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

					m_blnHaveMoreLine = false;
				}
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

		/// <summary>
		/// 出院诊断
		/// </summary>
		private class clsPrintOutDiagnose : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("出院诊断"))
						objItemContent = m_hasItems["出院诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					p_objGrp.DrawString("出院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("出院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("出院诊断：",m_objPrintContext.m_ObjModifyUserArr);
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

		#endregion


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
			if(p_objItemArr == null)
				return null;
			Hashtable hasItem = new Hashtable(400);
			m_hasItemDetail = new Hashtable(400);
			foreach(clsInpatMedRec_Item objItem in p_objItemArr)
			{
				try
				{
					if(objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
					{
						continue;
						//						m_hasItemDetail.Add(objItem.m_strItemName,"");
					}
					else
					{
						m_hasItemDetail.Add(objItem.m_strItemName,objItem.m_strItemContent);
						hasItem.Add(objItem.m_strItemName,objItem);
					}
				}
				catch{continue;}
			}
			return hasItem;
		}
		

	}
}
