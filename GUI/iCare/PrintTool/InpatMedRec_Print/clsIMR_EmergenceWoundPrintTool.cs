using System;
using iCareData;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 急诊创伤留观病历的打印工具类  liuyingrui 2006-1-26
	/// </summary>
	public class clsIMR_EmergenceWoundPrintTool:clsInpatMedRecPrintBase
	{
		
		public   clsIMR_EmergenceWoundPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		 
		}
		protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{			
            
			e.Graphics.DrawRectangle(Pens.Black,m_intRecBaseX+5,115,(int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX+15,e.PageBounds.Height-315);
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{　
																		   new clsPrintPatientFixInfo("急诊创伤留观病历",290),
																		   new clsPrintInPatMedRecHospitalizedType(),
																		   new clsPrintInPatMedRecInjured(),
																		   new clsPrintInPatMedRecInOutHospitalTime(),
																		   new clsPrintInPatMedRecCurrentSituation(),
																		   new clsPrintInPatMedRecCaseMain(),
																		   new clsPrintInPatMedRecCurrentDiseaseHistory(),
																		   new clsPrintInPatMedRecPassedHistory(),
																		   new clsPrintInPatMedRecOtherHistory(),
																		   new clsPrintInPatMedRecBodyCheck(),
																		   new clsPrintInPatMedRecSkin(),
																		   new clsPrintInPatMedRecFacePart(),
																		   new clsPrintInPatMedRecNeckPart(),
																		   new clsPrintInPatMedRecCheastPart(),
																		   new clsPrintInPatMedRecVenterPart(),
																		   new clsPrintInPatMedRecSpine(),
																		   new clsPrintInPatMedRecLimb(),
																		   new clsPrintInPatMedRecSpecializedSituation(),
																		   new clsPrintInPatMedRecPrimaryDiagnosis(),
																		   new clsPrintInPatMedRecLeaveDiagnosis()									       
																	   });		

		}
		/// <summary>
		/// 就医类别
		/// </summary>
		private class clsPrintInPatMedRecHospitalizedType:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private string[] p_strKeysArr01={"就医类别>>自费","就医类别>>公费","就医类别>>医保"};
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			    
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,20,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
			
					switch(m_mthKeyCheck(p_strKeysArr01))
					{   
						case 0: strPrintText+="自费 ";break;
						case 1: strPrintText+="公费 ";break;
						case 2: strPrintText+="医保 ";break;
						case -1: break;
					}
				
					if(strPrintText!="         ")
					{
						p_objGrp.DrawString("就医类别:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						if(m_hasItemDetail.Contains("医保号"))
						{
								p_objGrp.DrawString("医保号:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+200,p_intPosY-20);
							strPrintText=m_hasItemDetail["医保号"].ToString();
							p_objGrp.DrawString(strPrintText,p_fntNormal,Brushes.Black,m_intRecBaseX+260,p_intPosY-20);
						}
					}
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 受伤原因&受伤类型
		/// </summary>
		private class clsPrintInPatMedRecInjured:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"受伤原因>>车祸","受伤原因>>工伤","受伤原因>>纠纷","受伤原因>>意外","受伤原因>>其他"};
			private string[] p_strKeysArr02={"受伤种类>>刺伤","受伤种类>>跌伤","受伤种类>>烧伤","受伤种类>>腐蚀","受伤种类>>其他"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					
					switch(m_mthKeyCheck(p_strKeysArr01))
					{
						case 0: strPrintText+="车祸";break;
						case 1: strPrintText+="工伤";break;
						case 2: strPrintText+="纠纷";break;
						case 3: strPrintText+="意外";break;
						case 4: strPrintText+="其他";
							if(m_hasItemDetail.Contains("受伤原因>>其他1")) 
								strPrintText+=":"+m_hasItemDetail["受伤原因>>其他1"];
							break;
						case -1: break;
						
					}
					if(strPrintText!="         ")
					{
						p_objGrp.DrawString("受伤原因:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					strPrintText="         ";
					switch(m_mthKeyCheck(p_strKeysArr02))
					{
						case 0: strPrintText+="刺伤";break;
						case 1: strPrintText+="跌伤";break;
						case 2: strPrintText+="烧伤";break;
						case 3: strPrintText+="腐蚀";break;
						case 4: strPrintText+="其他";
							if(m_hasItemDetail.Contains("受伤种类>>其他1")) 
								strPrintText+=":"+m_hasItemDetail["受伤种类>>其他1"];
							break;
						case -1: break;
						
					}
					if(strPrintText!="         ")
					{   
						p_objGrp.DrawString("受伤种类:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 入观/出观时间
		/// </summary>
		private class clsPrintInPatMedRecInOutHospitalTime:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private string[] p_strKeysArr01={"入院方式>>步行","入院方式>>抬入","入院方式>>120"};
			private string[] p_strKeysArr02={"出院情况>>治愈","出院情况>>好转","出院情况>>未愈","出院情况>>死亡"};
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
				    
					if(m_hasItemDetail.Contains("入观时间"))
					{   
						p_objGrp.DrawString("入观时间:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						strPrintText+=DateTime.Parse(m_hasItemDetail["入观时间"].ToString()).ToString("yyyy年MM月dd日HH时mm分")+"　 ";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					strPrintText="";
					switch(m_mthKeyCheck(p_strKeysArr01))
					{
						case 0: strPrintText+="步行";break;
						case 1: strPrintText+="抬入";break;
						case 2: strPrintText+="120";break;
						case -1: break;
				
					}
					if(strPrintText!="") 
					{
							p_objGrp.DrawString("入院方式:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+300,p_intPosY-20);
						p_objGrp.DrawString(strPrintText,p_fntNormal,Brushes.Black,m_intRecBaseX+380,p_intPosY-20);
					}

					
					strPrintText="         ";
					if(m_hasItemDetail.Contains("出观时间"))
					{
							p_objGrp.DrawString("出观时间:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						strPrintText+=DateTime.Parse(m_hasItemDetail["出观时间"].ToString()).ToString("yyyy年MM月dd日HH时mm分")+" 　";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					strPrintText="";
					switch(m_mthKeyCheck(p_strKeysArr02))
					{
						case 0: strPrintText+="治愈";break;
						case 1: strPrintText+="好转";break;
						case 2: strPrintText+="未愈";break;
						case 3: strPrintText+="死亡";break;
						case -1: break;
				
					}
					if(strPrintText!="") 
					{
						p_objGrp.DrawString("出院情况:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+300,p_intPosY-20);
						p_objGrp.DrawString(strPrintText,p_fntNormal,Brushes.Black,m_intRecBaseX+380,p_intPosY-20);
					}
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 去向&转院
		/// </summary>
		private class clsPrintInPatMedRecCurrentSituation:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private string[] p_strKeysArr01={"去向>>出观","去向>>自动离院","去向>>入院"};
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr) 
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i])) 
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
				
					switch(m_mthKeyCheck(p_strKeysArr01))
					{
						case 0: strPrintText+="出观";break;
						case 1: strPrintText+="自动离院";break;
						case 2: strPrintText+="入院";
							if(m_hasItemDetail.Contains("入院>>科"))
								strPrintText+="("+m_hasItemDetail["入院>>科"]+" 科 ";
							if(m_hasItemDetail.Contains("入院>>床"))
								strPrintText+=m_hasItemDetail["入院>>床"]+" 床)";
							break;
						case -1: break;
						
				
					}
					if(strPrintText!="         ")
					{                        
						p_objGrp.DrawString("去    向:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					if(m_hasItemDetail.Contains("转院至"))
					{
						p_objGrp.DrawString("转院至:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						strPrintText="        ";
						strPrintText+=m_hasItemDetail["转院至"];
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 主诉
		/// </summary>
		private class clsPrintInPatMedRecCaseMain:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="        ";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);		
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
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					
					p_objGrp.DrawString("主  诉:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("主诉"))
						strPrintText+=m_hasItemDetail["主诉"];
					if(strPrintText!="        ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		private class clsPrintInPatMedRecCurrentDiseaseHistory:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint= true;
			private string strPrintText="       ";
			private clsInpatMedRec_Item objItemContent = null;
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
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
					if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("现病史:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("现病史"))
						strPrintText+=m_hasItemDetail["现病史"];
					if(strPrintText!="       ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 既往史
		/// </summary>
		private class clsPrintInPatMedRecPassedHistory:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="       ";
			private clsInpatMedRec_Item objItemContent = null;		
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
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
					if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("既往史:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("既往史"))
						strPrintText+=m_hasItemDetail["既往史"];
					if(strPrintText!="       ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 药敏及其它史
		/// </summary>
		private class clsPrintInPatMedRecOtherHistory:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="             ";
			private clsInpatMedRec_Item objItemContent = null;	
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("药敏及其它史"))
						objItemContent = m_hasItems["药敏及其它史"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
				
					p_objGrp.DrawString("药敏及其它史:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("药敏及其它史"))
						strPrintText+=m_hasItemDetail["药敏及其它史"];
					if(strPrintText!="             ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 体格检查
		/// </summary>
		private class clsPrintInPatMedRecBodyCheck:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"神志>>清楚","神志>>模糊","神志>>嗜睡","神志>>昏睡","神志>>昏迷"};
			private string[] p_strKeysArr02={"表情>>自如","表情>痛苦","表情>>忧虑","表情>>淡漠"};
			private string[] p_strKeysArr03={"体位>>自动体位","体位>>被动体位","体位>>左侧位","体位>>右侧位","体位>>屈曲位"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("体      格      检       查",new Font("SimSun", 14),Brushes.Black,m_intRecBaseX+200,p_intPosY);
					p_intPosY += 25;
					if(m_hasItemDetail.Contains("体检>>T"))
						strPrintText+="T:"+m_hasItemDetail["体检>>T"]+"℃      ";
					if(m_hasItemDetail.Contains("体检>>P"))
						strPrintText+="P:"+m_hasItemDetail["体检>>P"]+"次/分      ";
					if(m_hasItemDetail.Contains("体检>>R"))
						strPrintText+="R:"+m_hasItemDetail["体检>>R"]+"次/分      ";
					if(m_hasItemDetail.Contains("体检>>BP"))
						strPrintText+="Bp:"+m_hasItemDetail["体检>>BP"]+"mmHg";
					if(strPrintText!="")
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

					strPrintText="     ";
					switch(m_mthKeyCheck(p_strKeysArr01))
					{
						case 0: strPrintText+="清醒 ";
							if(m_hasItemDetail.Contains("神志>>清楚1"))       
								strPrintText+=m_hasItemDetail["神志>>清楚1"];
							break;
						case 1: strPrintText+="模糊 ";
							if(m_hasItemDetail.Contains("神志>>模糊1"))
								strPrintText+=m_hasItemDetail["神志>>模糊1"];
							break;
						case 2: strPrintText+="嗜睡 ";
							if(m_hasItemDetail.Contains("神志>>嗜睡1"))
								strPrintText+=m_hasItemDetail["神志>>嗜睡1"];
							break;
						case 3: strPrintText+="昏睡 ";
							if(m_hasItemDetail.Contains("神志>>昏睡1"))
								strPrintText+=m_hasItemDetail["神志>>昏睡1"];
							break; 
						case 4: strPrintText+="昏迷 ";
							if(m_hasItemDetail.Contains("神志>>昏迷1"))
								strPrintText+=m_hasItemDetail["神志>>昏迷1"];
							break;
						case -1:break;	   	
					}
					if(strPrintText!="     ")
					{   
						p_objGrp.DrawString("神志:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}

					strPrintText="     ";
					switch(m_mthKeyCheck(p_strKeysArr02))
					{
						case 0: strPrintText+="自如 ";
							if(m_hasItemDetail.Contains("表情>>自如1"))       
								strPrintText+=m_hasItemDetail["表情>>自如1"];
							break;
						case 1: strPrintText+="痛苦 ";
							if(m_hasItemDetail.Contains("表情>>痛苦1"))
								strPrintText+=m_hasItemDetail["表情>>痛苦1"];
							break;
						case 2: strPrintText+="忧虑 ";
							if(m_hasItemDetail.Contains("表情>>忧虑1"))
								strPrintText+=m_hasItemDetail["表情>>忧虑1"];
							break;
						case 3: strPrintText+="淡漠";
							if(m_hasItemDetail.Contains("表情>>淡漠1"))
								strPrintText+=m_hasItemDetail["表情>>淡漠1"];
							break;
						case -1:break;	   	
					}
					if(strPrintText!="     ")
					{   
						p_objGrp.DrawString("表情:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}

					strPrintText="     ";
					switch(m_mthKeyCheck(p_strKeysArr03))
					{
						case 0: strPrintText+="自动体位 ";
							if(m_hasItemDetail.Contains("体位>>自动体位1"))       
								strPrintText+=m_hasItemDetail["体位>>自动体位1"];
							break;
						case 1: strPrintText+="被动体位 ";
							if(m_hasItemDetail.Contains("体位>>被动体位1"))
								strPrintText+=m_hasItemDetail["体位>>被动体位1"];
							break;
						case 2: strPrintText+="左侧位 ";
							if(m_hasItemDetail.Contains("体位>>左侧位1"))
								strPrintText+=m_hasItemDetail["体位>>左侧位1"];
							break;
						case 3: strPrintText+="右侧位 ";
							if(m_hasItemDetail.Contains("体位>>右侧位1"))
								strPrintText+=m_hasItemDetail["体位>>右侧位1"];
							break;
						case 4: strPrintText+="屈曲位 ";
							if(m_hasItemDetail.Contains("体位>>屈曲位1"))
								strPrintText+=m_hasItemDetail["体位>>屈曲位1"];
							break;
						case -1:break;	   	
					}
					if(strPrintText!="     ")
					{   
						p_objGrp.DrawString("体位:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					}
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 体格检查>>皮肤
		/// </summary>
		private class clsPrintInPatMedRecSkin:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="      ";
			private clsInpatMedRec_Item objItemContent = null;	
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);	
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{   
				if(m_hasItems != null)
					if(m_hasItems.Contains("皮肤"))
						objItemContent = m_hasItems["皮肤"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					
					p_objGrp.DrawString("皮肤:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("皮肤"))
						strPrintText+=m_hasItemDetail["皮肤"];
					if(strPrintText!="      ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 头面部
		/// </summary>
		private class clsPrintInPatMedRecFacePart:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);		
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_hasItemDetail.Contains("头颅")||m_hasItemDetail.Contains("眼")||m_hasItemDetail.Contains("瞳孔")||m_hasItemDetail.Contains("耳")||m_hasItemDetail.Contains("唇")||m_hasItemDetail.Contains("咽")||m_hasItemDetail.Contains("舌")||m_hasItemDetail.Contains("齿"))
				{
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
					
						p_objGrp.DrawString("头面部:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
						if(m_hasItemDetail.Contains("头颅"))
							strPrintText="头颅:"+m_hasItemDetail["头颅"]+" ";
						if(m_hasItemDetail.Contains("眼"))
							strPrintText+="眼:"+m_hasItemDetail["眼"]+" ";
						if(m_hasItemDetail.Contains("瞳孔"))
							strPrintText+="瞳孔:"+m_hasItemDetail["瞳孔"]+" ";
						if(m_hasItemDetail.Contains("耳"))
							strPrintText+="耳:"+m_hasItemDetail["耳"]+" ";
						if(m_hasItemDetail.Contains("唇"))
							strPrintText+="唇:"+m_hasItemDetail["唇"];
						if(strPrintText!="")
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

						strPrintText="";
						if(m_hasItemDetail.Contains("咽"))
							strPrintText="咽:"+m_hasItemDetail["咽"]+" ";
						if(m_hasItemDetail.Contains("舌"))
							strPrintText+="舌:"+m_hasItemDetail["舌"]+" ";
						if(m_hasItemDetail.Contains("齿"))
							strPrintText+="齿:"+m_hasItemDetail["齿"];
						if(strPrintText!="")
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
					}
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 颈部
		/// </summary>
		private class clsPrintInPatMedRecNeckPart:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="";
			private bool m_added=false;
			private string[] p_strKeysArr01={"颈部>>软","颈部>>硬"};
			private string[] p_strKeysArr02={"甲状腺>>正常","甲状腺>>肿大"};
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItemDetail.Contains("气管")||m_hasItemDetail.Contains("颈部>>软")||m_hasItemDetail.Contains("颈部>>硬")||m_hasItemDetail.Contains("甲状腺>>正常")||m_hasItemDetail.Contains("甲状腺>>肿大"))
				{
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
					
						p_objGrp.DrawString("颈部:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY += 20;
						if(m_hasItemDetail.Contains("气管"))
						{
								p_objGrp.DrawString("气管:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							strPrintText="     "+m_hasItemDetail["气管"];
							p_objGrp.DrawString(strPrintText,p_fntNormal,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_added=true;
							
						}
						strPrintText="";
						switch(m_mthKeyCheck(p_strKeysArr01))
						{
							case 0: strPrintText+="软 ";
								if(m_hasItemDetail.Contains("颈部>>软1"))       
									strPrintText+=m_hasItemDetail["颈部>>软1"];
								break;
							case 1: strPrintText+="硬 ";
								if(m_hasItemDetail.Contains("颈部>>硬1"))
									strPrintText+=m_hasItemDetail["颈部>>硬1"];
								break;
							case -1:break;	   	
						}
						if(strPrintText!="") 
						{
							p_objGrp.DrawString("颈部:",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_objGrp.DrawString(strPrintText,p_fntNormal,Brushes.Black,m_intRecBaseX+350,p_intPosY);
							m_added=true;
						}

			
						strPrintText="       ";
						switch(m_mthKeyCheck(p_strKeysArr02))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("甲状腺>>正常1"))       
									strPrintText+=m_hasItemDetail["甲状腺>>正常1"];
								break;
							case 1: strPrintText+="肿大 ";
								if(m_hasItemDetail.Contains("甲状腺>>肿大1"))
									strPrintText+=m_hasItemDetail["甲状腺>>肿大1"]+" 度";
								break;
							case -1: break;	   	
						}
						if(strPrintText!="       ")
						{   
							if(m_added)
								p_intPosY+=20;
							p_objGrp.DrawString("甲状腺:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
					}
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 胸部
		/// </summary>
		private class clsPrintInPatMedRecCheastPart:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="      ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"胸部>>形态>>正常","胸部>>形态>>血胸","胸部>>形态>>气胸"};
			private string[] p_strKeysArr02={"呼吸运动>>正常","呼吸运动>>受限"};
			private string[] p_strKeysArr03={"勒骨>>正常","勒骨>>骨折"};
			private string[] p_strKeysArr04={"肺部>>呼吸音","肺部>>清晰","肺部>>罗音","肺部>>摩擦音"};
			private string[] p_strKeysArr05={"心脏>>心音","心脏>>正常"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if (m_hasItemDetail.Contains("胸部>>形态>>正常") || m_hasItemDetail.Contains("胸部>>形态>>血胸") || m_hasItemDetail.Contains("胸部>>形态>>气胸") || m_hasItemDetail.Contains("呼吸运动>>正常") || m_hasItemDetail.Contains("呼吸运动>>受限") || m_hasItemDetail.Contains("勒骨>>正常") || m_hasItemDetail.Contains("勒骨>>骨折") || m_hasItemDetail.Contains("肺部>>呼吸音") || m_hasItemDetail.Contains("肺部>>清晰") || m_hasItemDetail.Contains("肺部>>罗音") || m_hasItemDetail.Contains("肺部>>摩擦音") || m_hasItemDetail.Contains("心脏>>心音") || m_hasItemDetail.Contains("心脏>>正常"))
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						p_objGrp.DrawString("胸部:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY += 20;
						switch(m_mthKeyCheck(p_strKeysArr01))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("胸部>>形态>>正常1"))       
									strPrintText+=m_hasItemDetail["胸部>>形态>>正常1"];
								break;
							case 1: strPrintText+="血胸 ";
								if(m_hasItemDetail.Contains("胸部>>形态>>血胸1"))
									strPrintText+=m_hasItemDetail["胸部>>形态>>血胸1"];
								break;
							case 2: strPrintText+="气胸 ";
								if(m_hasItemDetail.Contains("胸部>>形态>>气胸1"))
									strPrintText+=m_hasItemDetail["胸部>>形态>>气胸1"];
								break;
							case -1:break;	   	
						}
						switch(m_mthKeyCheck(p_strKeysArr02))
						{
							case 0: strPrintText+="    呼吸运动:正常 ";
								if(m_hasItemDetail.Contains("呼吸运动>>正常1"))       
									strPrintText+=m_hasItemDetail["呼吸运动>>正常1"];
								break;
							case 1: strPrintText+="    呼吸运动:受限 ";
								if(m_hasItemDetail.Contains("呼吸运动>>受限1"))
									strPrintText+=m_hasItemDetail["呼吸运动>>受限1"];
								break;
							case -1:break;	   	
						} 
						if(strPrintText!="      ")
						{ 
							p_objGrp.DrawString("形态:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
				
						strPrintText="      ";
						switch(m_mthKeyCheck(p_strKeysArr03))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("勒骨>>正常1"))
									strPrintText+=m_hasItemDetail["勒骨>>正常1"];
								break;
							case 1: strPrintText+="骨折 ";
								if(m_hasItemDetail.Contains("勒骨>>骨折1"))
									strPrintText+="  第 "+m_hasItemDetail["勒骨>>骨折1"]+" 肋";
								break;
							case -1:break;	   	
						}
						if(strPrintText!="      ")
						{   
							p_objGrp.DrawString("肋骨:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

						strPrintText="     ";
						switch(m_mthKeyCheck(p_strKeysArr04))
						{
							case 0: strPrintText+="呼吸音 ";
								if(m_hasItemDetail.Contains("肺部>>呼吸音1"))       
									strPrintText+=m_hasItemDetail["肺部>>呼吸音1"];
								break;
							case 1: strPrintText+="清晰 ";
								if(m_hasItemDetail.Contains("肺部>>清晰1"))
									strPrintText+=m_hasItemDetail["肺部>>清晰1"];
								break;
							case 2: strPrintText+="罗音 ";
								if(m_hasItemDetail.Contains("肺部>>罗音1"))
									strPrintText+=m_hasItemDetail["肺部>>罗音1"];
								break;
							case 3: strPrintText+="摩擦音 ";
								if(m_hasItemDetail.Contains("肺部>>摩擦音1"))
									strPrintText+=m_hasItemDetail["肺部>>摩擦音1"];
								break;
							case -1:
								break;	   	
						}
						if (strPrintText != "     ")
						{   
							p_objGrp.DrawString("肺部:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

					
						strPrintText="      ";
						switch(m_mthKeyCheck(p_strKeysArr05))
						{
							case 0: strPrintText+="心音 ";
								if(m_hasItemDetail.Contains("心脏>>心音1"))       
									strPrintText+=m_hasItemDetail["心脏>>心音1"];
								break;
							case 1: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("心脏>>正常1"))
									strPrintText+=m_hasItemDetail["心脏>>正常1"];
								break;
							case -1:break;	   	
						}
						if(strPrintText!="      ")
						{   
							p_objGrp.DrawString("心脏:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
					}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 腹部
		/// </summary>
		private class clsPrintInPatMedRecVenterPart:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="      ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"腹部>>形态>>正常","腹部>>形态>>膨隆","腹部>>形态>>舟状腹","腹部>>形态>>肠型"};
			private string[] p_strKeysArr02={"腹壁>>柔软","腹壁>>紧张","腹壁>>板状腹"};
			private string[] p_strKeysArr03={"肝浊音界>>正常","肝浊音界>>缩小","肝浊音界>>消失"};
			private string[] p_strKeysArr04={"移动性浊音>>有","移动性浊音>>无"};
			private string[] p_strKeysArr05={"肾区叩痛>>有","肾区叩痛>>无"};
			private string[] p_strKeysArr06={"肠鸣音>>正常","肠鸣音>>亢进","肠鸣音>>减弱"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if (m_hasItemDetail.Contains("腹部>>形态>>正常") || m_hasItemDetail.Contains("腹部>>形态>>膨隆") || m_hasItemDetail.Contains("腹部>>形态>>舟状腹") || m_hasItemDetail.Contains("腹部>>形态>>肠型") ||
					m_hasItemDetail.Contains("腹壁>>柔软") || m_hasItemDetail.Contains("腹壁>>紧张") || m_hasItemDetail.Contains("腹壁>>板状腹")
					|| m_hasItemDetail.Contains("肝浊音界>>正常") || m_hasItemDetail.Contains("肝浊音界>>缩小") || m_hasItemDetail.Contains("肝浊音界>>消失")
					|| m_hasItemDetail.Contains("肾区叩痛>>无") || m_hasItemDetail.Contains("肠鸣音>>正常") || m_hasItemDetail.Contains("肠鸣音>>亢进")
					|| m_hasItemDetail.Contains("移动性浊音>>有") || m_hasItemDetail.Contains("移动性浊音>>无") || m_hasItemDetail.Contains("肾区叩痛>>有") || m_hasItemDetail.Contains("肠鸣音>>减弱"))
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
				
						p_objGrp.DrawString("腹部:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY += 20;
						switch(m_mthKeyCheck(p_strKeysArr01))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("腹部>>形态>>正常1"))       
									strPrintText+=m_hasItemDetail["腹部>>形态>>正常1"];
								break;
							case 1: strPrintText+="膨隆 ";
								if(m_hasItemDetail.Contains("腹部>>形态>>膨隆1"))
									strPrintText+=m_hasItemDetail["腹部>>形态>>膨隆1"];
								break;
							case 2: strPrintText+="舟状腹 ";
								if(m_hasItemDetail.Contains("腹部>>形态>>舟状腹1"))
									strPrintText+=m_hasItemDetail["腹部>>形态>>舟状腹1"];
								break;
							case 3: strPrintText+="肠型 ";
								if(m_hasItemDetail.Contains("腹部>>形态>>肠型1"))
									strPrintText+=m_hasItemDetail["腹部>>形态>>肠型1"];
								break;
							case -1:break;	   	
						}
						if(strPrintText!="      ")
						{   
							p_objGrp.DrawString("形态:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

						strPrintText="      ";
						switch(m_mthKeyCheck(p_strKeysArr02))
						{
							case 0: strPrintText+="柔软 ";
								if(m_hasItemDetail.Contains("腹壁>>柔软1"))       
									strPrintText+=m_hasItemDetail["腹壁>>柔软1"]+"    ";
								break;
							case 1: strPrintText+="紧张 ";
								if(m_hasItemDetail.Contains("腹壁>>紧张1"))
									strPrintText+=m_hasItemDetail["腹壁>>紧张1"]+"    ";
								break;
				
							case 2: strPrintText+="板状腹";
								if(m_hasItemDetail.Contains("腹壁>>板状腹1"))
									strPrintText+=m_hasItemDetail["腹壁>>板状腹1"]+"    ";
								break;   
							case -1:break;	   	
						}
			
						if(m_hasItemDetail.Contains("压痛"))
							strPrintText+="压痛:"+m_hasItemDetail["压痛"];
						if(m_hasItemDetail.Contains("反压痛"))
							strPrintText+="反压痛:"+m_hasItemDetail["反压痛"];
						if(strPrintText!="      ")
						{   
							p_objGrp.DrawString("腹壁:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);

						}
						strPrintText="        ";
						if(m_hasItemDetail.Contains("肝胆脾>>正常"))
						{ 
							strPrintText+="正常 ";
							if(m_hasItemDetail.Contains("肝胆脾>>正常1"))
								strPrintText+=m_hasItemDetail["肝胆脾>>正常1"]+"   ";
						}
						switch(m_mthKeyCheck(p_strKeysArr03))
						{
							case 0: strPrintText+="肝浊音界:正常 ";
								if(m_hasItemDetail.Contains("肝浊音界>>正常1"))       
									strPrintText+=m_hasItemDetail["肝浊音界>>正常1"];
								break;
							case 1: strPrintText+="肝浊音界:缩小 ";
								if(m_hasItemDetail.Contains("肝浊音界>>缩小1"))
									strPrintText+=m_hasItemDetail["肝浊音界>>缩小1"];
								break;
							case 2: strPrintText+="肝浊音界:消失 ";
								if(m_hasItemDetail.Contains("肝浊音界>>消失1"))
									strPrintText+=m_hasItemDetail["肝浊音界>>消失1"];
								break;
							case -1:
								break;	   	
						}
						if(strPrintText!="        ")
						{
							p_objGrp.DrawString("肝胆脾:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

						strPrintText="           ";
						switch(m_mthKeyCheck(p_strKeysArr04))
						{
							case 0: strPrintText+="有 ";
								if(m_hasItemDetail.Contains("移动性浊音>>有1"))       
									strPrintText+=m_hasItemDetail["移动性浊音>>有1"]+"    ";
								break;
							case 1: strPrintText+="无 ";
								if(m_hasItemDetail.Contains("移动性浊音>>无1"))
									strPrintText+=m_hasItemDetail["移动性浊音>>无1"]+"    ";
								break;
							case -1:break;	   	
						}
					
						switch(m_mthKeyCheck(p_strKeysArr05))
						{
							case 0: strPrintText+="肾区叩痛:有 ";
								if(m_hasItemDetail.Contains("肾区叩痛>>有1"))       
									strPrintText+=m_hasItemDetail["肾区叩痛>>有1"];
								break;
							case 1: strPrintText+="肾区叩痛:无 ";
								if(m_hasItemDetail.Contains("肾区叩痛>>无1"))
									strPrintText+=m_hasItemDetail["肾区叩痛>>无1"];
								break;
							case -1:break;	   	
						}
						if(strPrintText!="           ")
						{    
						
							p_objGrp.DrawString("移动性浊音:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
				
						strPrintText="       ";
						switch(m_mthKeyCheck(p_strKeysArr06))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("肠鸣音>>正常1"))       
									strPrintText+=m_hasItemDetail["肠鸣音>>正常1"];
								break;
							case 1: strPrintText+="亢进 ";
								if(m_hasItemDetail.Contains("肠鸣音>>亢进1"))
									strPrintText+=m_hasItemDetail["肠鸣音>>亢进1"];
								break;
							case 2: strPrintText+="减弱 ";
								if(m_hasItemDetail.Contains("肠鸣音>>减弱1"))
									strPrintText+=m_hasItemDetail["肠鸣音>>减弱1"];
								break;
							case -1:break;	   	
						}
						if(strPrintText!="       ")
						{   
							p_objGrp.DrawString("肠鸣音:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

					
						if(m_hasItemDetail.Contains("肛门外生殖器"))
						{
							strPrintText="            ";
							p_objGrp.DrawString("肛门外生殖器:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							strPrintText+=m_hasItemDetail["肛门外生殖器"];
							strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
				
					}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 脊柱
		/// </summary>
		private class clsPrintInPatMedRecSpine:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="      ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"脊柱>>形态>>正常","脊柱>>形态>>弯畸形"};
			private string[] p_strKeysArr02={"生理曲度>>存在","生理曲度>>消失"};
			private string[] p_strKeysArr03={"活动度>>正常","活动度>>受限"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItemDetail.Contains("脊柱>>形态>>正常")||m_hasItemDetail.Contains("脊柱>>形态>>弯畸形")||m_hasItemDetail.Contains("生理曲度>>存在")||m_hasItemDetail.Contains("生理曲度>>消失")||m_hasItemDetail.Contains("活动度>>正常")||m_hasItemDetail.Contains("活动度>>受限"))
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						p_objGrp.DrawString("脊柱:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY += 20;
						switch(m_mthKeyCheck(p_strKeysArr01))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("脊柱>>形态>>正常1"))       
									strPrintText+=m_hasItemDetail["脊柱>>形态>>正常1"]+"      ";
								break;
							case 1: strPrintText+="弯畸形 ";
								if(m_hasItemDetail.Contains("脊柱>>形态>>弯畸形1"))
									strPrintText+=m_hasItemDetail["脊柱>>形态>>弯畸形1"]+"      ";
								break;
							case -1:break;	   	
						}
	
						switch(m_mthKeyCheck(p_strKeysArr02))
						{
							case 0: strPrintText+="生理曲度:存在 ";
								if(m_hasItemDetail.Contains("生理曲度>>存在1"))       
									strPrintText+=m_hasItemDetail["生理曲度>>存在1"];
								break;
							case 1: strPrintText+="生理曲度:消失 ";
								if(m_hasItemDetail.Contains("生理曲度>>消失1"))
									strPrintText+=m_hasItemDetail["生理曲度>>消失1"];
								break;
							case -1:
								break;	   	
						}
						if(strPrintText!="      ")
						{   
							p_objGrp.DrawString("形态:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

						strPrintText="          ";
						switch(m_mthKeyCheck(p_strKeysArr03))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("活动度>>正常1"))       
									strPrintText+=m_hasItemDetail["活动度>>正常1"];
								break;
							case 1: strPrintText+="受限 ";
								if(m_hasItemDetail.Contains("活动度>>受限1"))
									strPrintText+=m_hasItemDetail["活动度>>受限1"];
								break;
							case -1:break;	   	
						}
						if (strPrintText != "          ")
						{  
							p_objGrp.DrawString("活动度:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
					}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 四肢
		/// </summary>
		private class clsPrintInPatMedRecLimb:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="             ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private string[] p_strKeysArr01={"神经及肌腱>>正常","神经及肌腱>>受损"};
			private string[] p_strKeysArr02={"肌力>>正常","肌力>>改变"};
			private string[] p_strKeysArr03={"关节形态及活动>>正常","关节形态及活动>>受限"};
			private string[] p_strKeysArr04={"指(趾)端血运>>正常","指(趾)端血运>>异常"};
			private string[] p_strKeysArr05={"感觉>>正常","感觉>>异常"};
			/// <summary>
			/// 获得键值数组选中的索引
			/// </summary>
			/// <param name="p_strKeysArr"></param>
			/// <returns></returns>
			public int m_mthKeyCheck(string [] p_strKeysArr)
			{
				if(m_hasItems == null || m_hasItems.Count < 1)
					return -1;
				for(int i=0; i <p_strKeysArr.Length; i++)
				{
					if(m_hasItems.Contains(p_strKeysArr[i]))
						return i;
				}
				return -1;
			}
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if (m_hasItemDetail.Contains("神经及肌腱>>正常") || m_hasItemDetail.Contains("神经及肌腱>>受损") || m_hasItemDetail.Contains("肌力>>正常") || m_hasItemDetail.Contains("肌力>>改变") ||
					m_hasItemDetail.Contains("关节形态及活动>>正常") || m_hasItemDetail.Contains("关节形态及活动>>受限") || m_hasItemDetail.Contains("指(趾)端血运>>正常")
					|| m_hasItemDetail.Contains("指(趾)端血运>>异常") || m_hasItemDetail.Contains("感觉>>正常") || m_hasItemDetail.Contains("感觉>>异常"))
					if(m_blnIsFirstPrint)
					{   
						if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
					
						p_objGrp.DrawString("四肢:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY += 20;
						switch(m_mthKeyCheck(p_strKeysArr01))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("神经及肌腱>>正常1"))       
									strPrintText+=m_hasItemDetail["神经及肌腱>>正常1"];
								break;
							case 1: strPrintText+="受损 ";
								if(m_hasItemDetail.Contains("神经及肌腱>>受损1"))
									strPrintText+=m_hasItemDetail["神经及肌腱>>受损1"];
								break;
							case -1:
								break;	   	
						}
						if(strPrintText!="             ")
						{
							p_objGrp.DrawString("神经及肌腱:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}

						strPrintText="      ";
						switch(m_mthKeyCheck(p_strKeysArr02))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("肌力>>正常1"))       
									strPrintText+=m_hasItemDetail["肌力>>正常1"];
								break;
							case 1: strPrintText+="改变 ";
								if(m_hasItemDetail.Contains("肌力>>改变1"))
									strPrintText+=m_hasItemDetail["肌力>>改变1"];
								break;
							case -1:
								break;	   	
						}
						if(strPrintText!="      ")
						{
							p_objGrp.DrawString("肌力:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						strPrintText="                   ";
						switch(m_mthKeyCheck(p_strKeysArr03))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("关节形态及活动>>正常1"))       
									strPrintText+=m_hasItemDetail["关节形态及活动>>正常1"];
								break;
							case 1: strPrintText+="受限 ";
								if(m_hasItemDetail.Contains("关节形态及活动>>受限1"))
									strPrintText+=m_hasItemDetail["关节形态及活动>>受限1"];
								break;
							case -1:strPrintText="";
								break;	   	
						}
						if(strPrintText!="")
						{
							p_objGrp.DrawString("关节形态及活动: ",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						strPrintText="              ";
						switch(m_mthKeyCheck(p_strKeysArr04))
						{
							case 0: strPrintText+="正常 ";
								if(m_hasItemDetail.Contains("指(趾)端血运>>正常1"))       
									strPrintText+=m_hasItemDetail["指(趾)端血运>>正常1"]+"    ";
								break;
							case 1: strPrintText+="异常 ";
								if(m_hasItemDetail.Contains("指(趾)端血运>>异常1"))
									strPrintText+=m_hasItemDetail["指(趾)端血运>>异常1"]+"    ";
								break;
							case -1:
								break;	   	
						}
		

						switch(m_mthKeyCheck(p_strKeysArr05))
						{
							case 0: strPrintText+="感觉: 正常 ";
								if(m_hasItemDetail.Contains("感觉>>正常1"))       
									strPrintText+=m_hasItemDetail["感觉>>正常1"];
								break;
							case 1: strPrintText+="感觉: 异常 ";
								if(m_hasItemDetail.Contains("感觉>>异常1"))
									strPrintText+=m_hasItemDetail["感觉>>异常1"];
								break;
							case -1:
								break;	   	
						}
						if(strPrintText!="              ")
						{
							p_objGrp.DrawString("指(趾)端血运: ",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
							m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
						}
						p_fntNormal.Dispose();
						m_blnIsFirstPrint = false;					
					}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 专科情况
		/// </summary>
		private class clsPrintInPatMedRecSpecializedSituation:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private clsInpatMedRec_Item objItemContent = null;	
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_hasItems != null)
					if(m_hasItems.Contains("专科情况"))
						objItemContent = m_hasItems["专科情况"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					
					p_objGrp.DrawString("专科情况:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("专科情况"))
						strPrintText+=m_hasItemDetail["专科情况"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 初步诊断
		/// </summary>
		private class clsPrintInPatMedRecPrimaryDiagnosis:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			private clsInpatMedRec_Item objItemContent = null;			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{   
				if(m_hasItems != null)
					if(m_hasItems.Contains("初步诊断"))
						objItemContent = m_hasItems["初步诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("初步诊断:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("初步诊断"))
						strPrintText+=m_hasItemDetail["初步诊断"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					string p_strText="医生签名：    ";
					if(m_hasItemDetail.Contains("医师签名1"))
						p_strText+=m_hasItemDetail["医师签名1"]+" ";
					else
						p_strText+="      ";
					if(m_hasItemDetail.Contains("医师签名1>>日期"))
						p_strText+=DateTime.Parse(m_hasItemDetail["医师签名1>>日期"].ToString()).ToString("yyyy年MM月dd日");
					else
						p_strText+="200　年　月　日";
					p_objGrp.DrawString(p_strText,p_fntNormal,Brushes.Black,(int)enmRectangleInfo.RightX-300,p_intPosY);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
		/// 离院诊断
		/// </summary>
		private class clsPrintInPatMedRecLeaveDiagnosis:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
			private clsInpatMedRec_Item objItemContent = null;	
			private Font p_fntNormal=new Font("SimSun", 12,FontStyle.Bold);
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_hasItems != null)
					if(m_hasItems.Contains("离院诊断"))
						objItemContent = m_hasItems["离院诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_intPosY+=20;
					p_objGrp.DrawString("离院诊断:",new Font("SimSun", 12),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_hasItemDetail.Contains("离院诊断"))
						strPrintText+=m_hasItemDetail["离院诊断"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
					string p_strText="上级医生签名:";
					if(m_hasItemDetail.Contains("上级医师签名1"))
						p_strText+=m_hasItemDetail["上级医师签名1"]+" ";
					else
						p_strText+="     ";
					if(m_hasItemDetail.Contains("上级医师签名1>>日期"))
						p_strText+=DateTime.Parse(m_hasItemDetail["上级医师签名1>>日期"].ToString()).ToString("yyyy年MM月dd日");
					else
						p_strText+="200　年　月　日";
					p_objGrp.DrawString(p_strText,p_fntNormal,Brushes.Black,(int)enmRectangleInfo.RightX-300,p_intPosY);
					p_fntNormal.Dispose();
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+70,p_intPosY,p_objGrp);

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
