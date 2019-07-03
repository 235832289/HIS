using System;
using iCareData;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 术前术后访视单的打印工具类  liuyingrui 2006-1-20
	/// </summary>
	public class clsIMR_PrePostOperateSeePrintTool:clsInpatMedRecPrintBase
	{
	     public  clsIMR_PrePostOperateSeePrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		    
		}
		
		/// <summary>
		/// 相同的标题只打印一次
		/// </summary>
        private string  strPrintText="";
		protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{  
				int m_intPosY=60;
				Font p_fntNormalText=new Font("SimSun",12);
				e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,new Font("SimSun",14),Brushes.Black,clsPrintPosition.c_intLeftX+240,m_intPosY);  
				m_intPosY+=40;
				e.Graphics.DrawString("术前术后访视单",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,clsPrintPosition.c_intLeftX+245,m_intPosY);
				m_intPosY+=40;
				strPrintText="姓名:"+m_objPrintInfo.m_strPatientName+"  "+"性别:"+m_objPrintInfo.m_strSex;
				e.Graphics.DrawString(strPrintText,p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX,m_intPosY);
				strPrintText="年龄:"+m_objPrintInfo.m_strAge+"  "+"科室:"+m_objPrintInfo.m_strDeptName+"  "+"床号:"+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName+"  "+"ID号:"+m_objPrintInfo.m_strHISInPatientID;
				e.Graphics.DrawString(strPrintText,p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX+210,m_intPosY);
				m_intPosY+=20;
				e.Graphics.DrawLine(Pens.Black,clsPrintPosition.c_intLeftX,m_intPosY,(int)enmRectangleInfo.RightX,m_intPosY);
				e.Graphics.DrawLine(Pens.Black,clsPrintPosition.c_intLeftX,m_intPosY+1,(int)enmRectangleInfo.RightX,m_intPosY+1);
		
		}
	
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
								          new clsPrintInPatMedRecEspecialHistory(),
									      new clsPrintInPatMedRecMasculineCharacter(),
										  new clsPrintInPatMedRecCheckResult(),
										  new clsPrintInPatMedRecOther(),
										  new clsPrintInPatMedRecOpinion(),
										  new clsPrintInPatMedRecAnaesthesiaSummary(),
  						                  new clsPrintInPatMedRecOperateDealwith(),
										  new clsPrintInPatMedRecPatientWard(),
										  new clsPrintInPatMedRecPostOperationSee(),
										  new clsPrintInPatMedRecPostOperateDoIdea()
																	   });		

		}
		protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{			
		}
		#region 打印实现  
		/// <summary>
		/// 术前访视>>特殊病史
		/// </summary>
		private class clsPrintInPatMedRecEspecialHistory:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			
				if(m_blnIsFirstPrint)
				{
                    p_intPosY = 180;
					p_objGrp.DrawString("术前访视",new Font("SimSun", 12,FontStyle.Bold),Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY-10);
                    
					p_intPosY += 10;
					p_objGrp.DrawString("特殊病史:",p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY);
                    if (m_hasItemDetail!=null && m_hasItemDetail.Contains("特殊病史"))
						strPrintText+=m_hasItemDetail["特殊病史"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,clsPrintPosition.c_intLeftX+70,p_intPosY,p_objGrp);

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
		/// 术前访视>>阳性体征
		/// </summary>
		private class  clsPrintInPatMedRecMasculineCharacter:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
				    p_objGrp.DrawString("阳性体征:",p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY);
                    if (m_hasItemDetail!=null && m_hasItemDetail.Contains("阳性体征"))
						    strPrintText+=m_hasItemDetail["阳性体征"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,clsPrintPosition.c_intLeftX+70,p_intPosY,p_objGrp);

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
		/// 术前访视>>辅助检查结果
		/// </summary>
		private class clsPrintInPatMedRecCheckResult : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool m_blnIsPrint=true;
			private string p_strText="";
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsPrint)
				{   
					
					if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("辅助检查结果：",p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>WBC"))
						p_objGrp.DrawString("ASA分级:"+m_hasItemDetail["辅助检查结果>>WBC"]+"急诊",p_fntNormalText,Brushes.Black,(int)enmRectangleInfo.RightX-150,p_intPosY);

					p_intPosY += 20;
					p_objGrp.DrawString("                           12                  9                                            9",new Font ("SimSun",8),Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY-8);
					p_objGrp.DrawString("Hb        RBC   10/L,WBC     10/L,分类N     HCT      PLT   10/L,APTT       TT",p_fntNormalText,Brushes.Black,clsPrintPosition.c_intLeftX+20,p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>Hb"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>Hb"]+"g/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+40,p_intPosY);
					else
					p_objGrp.DrawString("  g/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+40,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>RBC"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>RBC"].ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+135,p_intPosY);
					else
					p_objGrp.DrawString("   ",p_fntNormalText,Brushes.Black,m_intRecBaseX+135,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>WBC"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>WBC"].ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+230,p_intPosY);
					else
					p_objGrp.DrawString("  ",p_fntNormalText,Brushes.Black,m_intRecBaseX+230,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>分类N"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>分类N"]+"%,",p_fntNormalText,Brushes.Black,m_intRecBaseX+360,p_intPosY);
					else
					p_objGrp.DrawString("  %,",p_fntNormalText,Brushes.Black,m_intRecBaseX+360,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>HCT"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>HCT"]+"%,",p_fntNormalText,Brushes.Black,m_intRecBaseX+425,p_intPosY);
					else
					p_objGrp.DrawString("  %,",p_fntNormalText,Brushes.Black,m_intRecBaseX+425,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>PLT"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>PLT"].ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
					else
					p_objGrp.DrawString("  ",p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>APTT"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>APTT"]+"sec,",p_fntNormalText,Brushes.Black,m_intRecBaseX+600,p_intPosY);
					else 
					p_objGrp.DrawString("  sec,",p_fntNormalText,Brushes.Black,m_intRecBaseX+600,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>TT"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>TT"]+"sec",p_fntNormalText,Brushes.Black,m_intRecBaseX+680,p_intPosY);
					else
						p_objGrp.DrawString("  sec",p_fntNormalText,Brushes.Black,m_intRecBaseX+680,p_intPosY);
		
					p_intPosY += 20;
					p_objGrp.DrawString("                  +             +              -",new Font ("SimSun",10),Brushes.Black,m_intRecBaseX+20,p_intPosY-5);
					p_objGrp.DrawString("尿Rt        血K           Na           CI            BUN             COCP",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_objGrp.DrawString("                                                                                                        2",new Font ("SimSun",8),Brushes.Black,m_intRecBaseX+20,p_intPosY+10);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>尿Rt"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>尿Rt"].ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+70,p_intPosY);
					else
						p_objGrp.DrawString("       ",p_fntNormalText,Brushes.Black,m_intRecBaseX+70,p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>血K"))
					
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>血K"]+"mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+155,p_intPosY);
					else
					p_objGrp.DrawString("   mmol/L，",p_fntNormalText,Brushes.Black,m_intRecBaseX+155,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>Na"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>Na"]+"mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+265,p_intPosY);
					else
					p_objGrp.DrawString("   mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+265,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>CI"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>CI"]+" mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+370,p_intPosY);
					else
					p_objGrp.DrawString( "  mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+370,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>BUN"))
						p_objGrp.DrawString( m_hasItemDetail["辅助检查结果>>BUN"]+" mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
					else
					p_objGrp.DrawString("   mmol/L,",p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>CO2CP"))
						p_objGrp.DrawString(m_hasItemDetail["辅助检查结果>>CO2CP"]+" mmol/L",p_fntNormalText,Brushes.Black,m_intRecBaseX+640,p_intPosY);
					 else
						p_objGrp.DrawString("   mmol/L",p_fntNormalText,Brushes.Black,m_intRecBaseX+640,p_intPosY);
			
					p_intPosY += 20;
					p_strText="肝炎系列:";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>肝炎系列"))
					 p_strText+=m_hasItemDetail["辅助检查结果>>肝炎系列"].ToString()+" ";
					else
					 p_strText+="                 ";
                 if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>TTT"))
					 p_strText+="TTT "+m_hasItemDetail["辅助检查结果>>TTT"]+" u/L,";
					else
					 p_strText+="TTT   u/L,";
                 if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>ALT"))
					 p_strText+="ALT "+m_hasItemDetail["辅助检查结果>>ALT"]+"u/L,";
					else
					 p_strText+="ALT   u/L,";
                 if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>AST"))
					  p_strText+="AST "+m_hasItemDetail["辅助检查结果>>AST"]+"u/L,";
					else
					  p_strText+="AST   u/L,";
                  if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>血糖"))
					  p_strText+="血糖 "+m_hasItemDetail["辅助检查结果>>血糖"]+" mmol/L ";
					else
					  p_strText+="血糖    mmol/L ";
                  if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>血型"))
					  p_strText+="血型 "+m_hasItemDetail["辅助检查结果>>血型"];
					else
					  p_strText+="血型   ";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, p_strText);
			
					p_strText="ECG：";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>ECG"))
					 p_strText+=m_hasItemDetail["辅助检查结果>>ECG"]+"    ";
					else
					 p_strText+="                                   ";
                 if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>胸透"))
					 p_strText+="胸透(X线胸片)："+m_hasItemDetail["辅助检查结果>>胸透"];
					else
					 p_strText+="                                   ";
					 m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, p_strText);
						
					m_blnIsPrint=false;
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
				m_blnIsPrint = true;
				m_blnHaveMoreLine = true;
			
			}

		}
		/// <summary>
		/// 术前访视>>其他
		/// </summary>
		private class clsPrintInPatMedRecOther:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="     ";
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				

				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
		            p_objGrp.DrawString("其他:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>其他"))
						strPrintText+=m_hasItemDetail["辅助检查结果>>其他"];
					if(strPrintText!="     ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
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
		/// 术前访视>>意见
		/// </summary>
		private class clsPrintInPatMedRecOpinion:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="     ";
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					 p_objGrp.DrawString("意见:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
                     if (m_hasItemDetail != null && m_hasItemDetail.Contains("辅助检查结果>>意见"))
						strPrintText+=m_hasItemDetail["辅助检查结果>>意见"];
					if(strPrintText!="     ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					string p_strText="麻醉科医生:";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("麻醉科医生1"))
					p_strText+=m_hasItemDetail["麻醉科医生1"]+" ";
					else
					p_strText+="          ";
                if (m_hasItemDetail != null && m_hasItemDetail.Contains("术前访视>>日期"))
					p_strText+=DateTime.Parse(m_hasItemDetail["术前访视>>日期"].ToString()).ToString("yyyy年MM月dd日");
					else
					p_strText+="200　年　月　日";
					p_objGrp.DrawString(p_strText,p_fntNormalText,Brushes.Black,(int)enmRectangleInfo.RightX-300,p_intPosY);
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
		/// 麻醉总结
		/// </summary>
		private class clsPrintInPatMedRecAnaesthesiaSummary : clsIMR_PrintLineBase
		{
			
		  private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
		  private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true,true};
		  private string[] p_strKeysArr01={"患者入室>>清醒","患者入室>>嗜睡","患者入室>>昏迷"};
		  private string[] p_strKeysArr02={"麻醉诱导>>平稳","麻醉诱导>>尚平稳","麻醉诱导>>欠平稳","麻醉诱导>>不平稳"};
	      private string[] p_strKeysArr03={"麻醉维持>>平稳","麻醉维持>>尚平稳","麻醉维持>>欠平稳","麻醉维持>>不平稳"};
		  private string[] p_strKeysArr04={"气管插管经过>>顺利","气管插管经过>>困难"};
		  private string[] p_strKeysArr05={"穿刺过程>>顺利","穿刺过程>>困难"};
		  private string[] p_strKeysArr06={"置管>>顺利","置管>>困难"};	
		  private string[] p_strKeysArr07={"蛛网膜下腔麻醉>>脑脊液>>流畅","蛛网膜下腔麻醉>>脑脊液>>不流畅"};
		  private string[] p_strKeysArr08={"静脉复合麻醉>>使用目的>>全凭静脉麻醉","静脉复合麻醉>>使用目的>>消除紧张","静脉复合麻醉>>使用目的>>加强原麻醉作用","静脉复合麻醉>>使用目的>>原麻醉效果差"};
		  private string[] p_strKeysArr09={"术后苏醒期>>平稳","术后苏醒期>>尚平稳","术后苏醒期>>欠平稳","术后苏醒期>>不平稳"};
		  private string[] p_strKeysArr10={"CVP>>右","CVP>>左"};
		  private string[] p_strKeysArr11={"CVP>>单腔","CVP>>双腔","CVP>>漂浮导管"};
		  private string[] p_strKeysArr12={"MAP>>右","MAP>>左"};
		  private string strPrintText="";
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
			
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,80,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_intPosY += 10;
					p_objGrp.DrawString("麻醉总结",new Font("SimSun", 12,FontStyle.Bold),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_intPosY += 20;
					switch(m_mthKeyCheck(p_strKeysArr01))
					{ 
						case 0:p_objGrp.DrawString("  患者入室:√清醒,嗜睡,昏迷",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);break;
						case 1:p_objGrp.DrawString("  患者入室:清醒,√嗜睡,昏迷",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);break;
						case 2:p_objGrp.DrawString("  患者入室:清醒,嗜睡,√昏迷",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);break;
						case -1:p_objGrp.DrawString("  患者入室:清醒,嗜睡,昏迷",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);break;
					}
					p_intPosY+=20;
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("气管内插管全麻"))
					{ 
						strPrintText="√气管内插管全麻:";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						switch(m_mthKeyCheck(p_strKeysArr02))
						{ 
							case 0:strPrintText+="麻醉诱导:√平稳,  尚平稳,  欠平稳,  不平稳;";break;

							case 1:strPrintText+="麻醉诱导:  平稳,√尚平稳,  欠平稳,  不平稳;";break;
							case 2:strPrintText+="麻醉诱导:  平稳,  尚平稳,√欠平稳,  不平稳;";break;
							case 3:strPrintText+="麻醉诱导:  平稳,  尚平稳,  欠平稳,√不平稳;";break;
						   case -1:strPrintText+="麻醉诱导:  平稳,  尚平稳,  欠平稳,  不平稳;";break;
						}
						switch(m_mthKeyCheck(p_strKeysArr03))
						{
							case 0:strPrintText+="麻醉维持:√平稳,  尚平稳,  欠平稳,  不平稳;";break;
							case 1:strPrintText+="麻醉维持:  平稳,√尚平稳,  欠平稳,  不平稳;";break;
							case 2:strPrintText+="麻醉维持:  平稳,  尚平稳,√欠平稳,  不平稳;";break;
							case 3:strPrintText+="麻醉维持:  平稳,  尚平稳,  欠平稳,√不平稳;";break;
							case -1:strPrintText+="麻醉维持: 平稳,  尚平稳,  欠平稳,  不平稳;";break;
						}
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

				        
						switch(m_mthKeyCheck(p_strKeysArr04))
						{
							case 0:strPrintText="  气管插管经过(√顺利,困难),插管困难的原因:";break;
							case 1:strPrintText="  气管插管经过(顺利,√困难),插管困难的原因:";
							       if(m_hasItemDetail.Contains("插管困难的原因"))
								    strPrintText+=m_hasItemDetail["插管困难的原因"]; break;
							case -1:strPrintText="  气管插管经过(顺利,困难),插管困难的原因:";break;
						}
	
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{
						if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						strPrintText="□气管内插管全麻:麻醉诱导:平稳,尚平稳,欠平稳,不平稳;麻醉维持:平稳,尚平稳,欠平稳,不平稳";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
						strPrintText="  气管插管经过(顺利,困难),插管困难的原因: ";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}

					m_blnIsPrint[0]=false;
				}
				if(m_blnIsPrint[1])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("硬膜外麻醉"))
					{
						strPrintText="√硬膜外麻醉：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						switch(m_mthKeyCheck(p_strKeysArr05))
						{
							case 0:strPrintText+="穿刺过程(√顺利，困难)；";break;
							case 1:strPrintText+="穿刺过程(顺利，√困难)；";break;
							case -1:strPrintText+="穿刺过程(顺利，困难)；";break;
						}
						switch(m_mthKeyCheck(p_strKeysArr06))
						{
							case 0:strPrintText+="置管(√顺利，困难) 更换间隙情况:";break;
							case 1:strPrintText+="置管(顺利，√困难) 更换间隙情况:";break;
							case -1:strPrintText+="置管(顺利，困难) 更换间隙情况:";break;
						}
						if(m_hasItemDetail.Contains("更换间隙情况"))
							strPrintText+=m_hasItemDetail["更换间隙情况"];
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

						strPrintText="  注射量期间情况：";
						if(m_hasItemDetail.Contains("注初量期间情况"))
						  strPrintText+=m_hasItemDetail["注初量期间情况"]+" 特殊情况：";
						else
						  strPrintText+="                      特殊情况：";
						if(m_hasItemDetail.Contains("特殊情况："))
						  strPrintText+=m_hasItemDetail["特殊情况："];
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					}
					else
					{ 
						
						if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
					  strPrintText="□硬膜外麻醉：穿刺过程(顺利，困难)；置管(顺利，困难) 更换间隙情况:";
					  m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					  strPrintText=" 注射量期间情况：                             特殊情况：";
					  m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
                  m_blnIsPrint[1]=false;
				}
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,20,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("蛛网膜下腔麻醉"))
					{
						strPrintText="√蛛网膜下腔麻醉：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						switch(m_mthKeyCheck(p_strKeysArr07))
						{
							case 0:strPrintText+="脑脊液(√流畅，不流畅)；";break;
							case 1:strPrintText+="脑脊液(流畅，√不流畅)；";break;
							case -1:strPrintText+="置管(顺利，困难)；";break;
						}
						if(m_hasItemDetail.Contains("蛛网膜下腔麻醉>>注药"))
						   strPrintText+="注药"+m_hasItemDetail["蛛网膜下腔麻醉>>注药"].ToString()+" ml，";
						else
						   strPrintText+="注药   ml，";
						if(m_hasItemDetail.Contains("蛛网膜下腔麻醉>>在>>sec内注完"))
						   strPrintText+="在"+m_hasItemDetail["蛛网膜下腔麻醉>>在>>sec内注完"].ToString()+" sec内注完。";
						else
							strPrintText+="在   sec内注完。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{
						if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						strPrintText="□蛛网膜下腔麻醉：脑脊液（流畅，不流畅）；注药   ml，在   sec内完成。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					m_blnIsPrint[2]=false;
				}
				if(m_blnIsPrint[3])
				{
					if(m_blnCheckBottom(ref p_intPosY,20,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("神经阻滞麻醉"))
					{
					    strPrintText="√神经阻滞麻醉：阻滞部位及路径：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("神经阻滞麻醉>>阻滞部位及路径"))
							strPrintText+=m_hasItemDetail["神经阻滞麻醉>>阻滞部位及路径"].ToString();
						else
							strPrintText+="                          ";
						if(m_hasItemDetail.Contains("神经阻滞麻醉>>特殊情况"))
							strPrintText+=" 特殊情况："+m_hasItemDetail["神经阻滞麻醉>>特殊情况"].ToString();
						else
							strPrintText+=" 特殊情况：                              ";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{
						
						if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						strPrintText="□神经阻滞麻醉：阻滞部位及路径：                           特殊情况：";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					m_blnIsPrint[3]=false;
				}
				if(m_blnIsPrint[4])
				{
					if(m_blnCheckBottom(ref p_intPosY,80,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("静脉复合麻醉"))
					{
						strPrintText="√静脉复合麻醉：使用目的";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("静脉复合麻醉>>使用目的>>全凭静脉麻醉"))
							strPrintText+="(√全凭静脉麻醉，";
						else
							strPrintText+="(全凭静脉麻醉，";
						if(m_hasItemDetail.Contains("静脉复合麻醉>>使用目的>>消除紧张"))
							strPrintText+="√消除紧张，";
						else
							strPrintText+="消除紧张，";
						if(m_hasItemDetail.Contains("静脉复合麻醉>>使用目的>>加强原麻醉作用"))
							strPrintText+="√加强原麻醉作用，";
						else
							strPrintText+="加强原麻醉作用，";
						if(m_hasItemDetail.Contains("静脉复合麻醉>>使用目的>>原麻醉效果差"))
							strPrintText+="√原麻醉效果差)";
						else
							strPrintText+="原麻醉效果差)";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

						strPrintText="术后苏醒期：";
						switch(m_mthKeyCheck(p_strKeysArr09))
						{
							case 0:strPrintText+="√平稳，尚平稳，欠平稳，不平稳；";break;
							case 1:strPrintText+="平稳，√尚平稳，欠平稳，不平稳；";break;
						    case 2:strPrintText+="平稳，尚平稳，√欠平稳，不平稳；";break;
							case 3:strPrintText+="平稳，尚平稳，欠平稳，√不平稳；";break;
						    case -1:strPrintText+="平稳，尚平稳，欠平稳，不平稳；";break;
						}
						if(m_hasItemDetail.Contains("术后苏醒期>>清醒时间在术后"))
						  strPrintText+="清醒时间在术后"+m_hasItemDetail["术后苏醒期>>清醒时间在术后"].ToString()+" 小时，";
						else
						  strPrintText+="清醒时间在术后   小时，";
						if(m_hasItemDetail.Contains("术后苏醒期>>特殊情况"))
						  strPrintText+="特殊情况："+m_hasItemDetail["术后苏醒期>>特殊情况"].ToString();
						else
						  strPrintText+="特殊情况：                            ";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

						strPrintText="CVP：";
						switch(m_mthKeyCheck(p_strKeysArr10))
						{ 
							case 0:strPrintText+="√右，左，";break;
							case 1:strPrintText+="右，√左，";break;
							case -1:strPrintText+="右，左，";break;
						}
						if(m_hasItemDetail.Contains("CVP>>颈内"))
						  strPrintText+="√颈内，";
						else
							strPrintText+="颈内，";
						if(m_hasItemDetail.Contains("CVP>>锁骨下V"))
						  strPrintText+="√锁骨下V，";
						else
							strPrintText+="锁骨下V，";
						if(m_hasItemDetail.Contains("CVP>>股V"))
							strPrintText+="√股V，";
						else
							strPrintText+="股V，";
						if(m_hasItemDetail.Contains("CVP>>颈外V"))
							strPrintText+="√颈外V";
						else 
							strPrintText+="颈外V";
						switch(m_mthKeyCheck(p_strKeysArr11))
						{
							case 0:strPrintText+="(√单腔，双腔，漂浮导管)";break;
							case 1:strPrintText+="(单腔，√双腔，漂浮导管)";break;
							case 2:strPrintText+="(单腔，双腔，√漂浮导管)";break;
							case -1:strPrintText+="(单腔，双腔，漂浮导管)";break;
						}
						if(m_hasItemDetail.Contains("CVP>>特殊情况"))
						   strPrintText+="特殊情况:"+m_hasItemDetail["CVP>>特殊情况"].ToString();
						else
							strPrintText+="特殊情况:";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

						strPrintText="MAP：";
						switch(m_mthKeyCheck(p_strKeysArr12))
						{ 
							case 0:strPrintText+="√右，左，";break;
							case 1:strPrintText+="右，√左，";break;
							case -1:strPrintText+="右，左，";break;
						}
						if(m_hasItemDetail.Contains("MAP>>挠A"))
						 strPrintText+="√挠A，";
						else
						  strPrintText+="挠A，";
						if(m_hasItemDetail.Contains("MAP>>股A"))
						 strPrintText+="√股A";
						else
						 strPrintText+="股A";
						if(m_hasItemDetail.Contains("MAP>>足背A"))
						 strPrintText+="√足背A ";
						else
						 strPrintText+="足背A ";
						if(m_hasItemDetail.Contains("MAP>>特殊情况"))
						 strPrintText+="特殊情况："+m_hasItemDetail["MAP>>特殊情况"].ToString();
						else
						 strPrintText+="特殊情况：";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					}
					else
					{   
						if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
						{
							m_blnHaveMoreLine = true;
							return;
						}
						strPrintText="□蛛网膜下腔麻醉：脑脊液（流畅，不流畅）；注药   ml，在   sec内完成。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					m_blnIsPrint[4]=false;
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
				m_blnIsPrint = new Boolean[]{true,true,true,true,true};
				m_blnHaveMoreLine = true;
			}

		}
		/// <summary>
		/// 麻醉总结>>术中情况及处理
		/// </summary>
		private class clsPrintInPatMedRecOperateDealwith:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="               ";		
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("术中情况及处理:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItems != null && m_hasItems.Contains("术中情况及处理"))
					  strPrintText+=m_hasItemDetail["术中情况及处理"];
			 	if(strPrintText!="               ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+40,p_intPosY,p_objGrp);

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
		/// 麻醉总结>>患者人病房时交班情况
		/// </summary>
		private class clsPrintInPatMedRecPatientWard:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="患者入病房时交班情况：";
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
			

				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					string p_strText="麻醉科医生:";
                    if (m_hasItems != null && m_hasItems.Contains("患者入病房时交班情况"))
					{
						strPrintText+=m_hasItemDetail["患者入病房时交班情况"];
					}
					if(strPrintText!="患者入病房时交班情况：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("麻醉科医生2"))
						p_strText+=m_hasItemDetail["麻醉科医生2"]+" ";
					else
						p_strText+="          ";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("麻醉总结>>日期"))
						p_strText+=DateTime.Parse(m_hasItemDetail["麻醉总结>>日期"].ToString()).ToString("yyyy年MM月dd日");
					else
						p_strText+="200　年　月　日";
					p_objGrp.DrawString(p_strText,p_fntNormalText,Brushes.Black,(int)enmRectangleInfo.RightX-300,p_intPosY);
					m_blnIsFirstPrint = false;					
				}
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+40,p_intPosY,p_objGrp);

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
		/// 术后访视
		/// </summary>
		private class clsPrintInPatMedRecPostOperationSee:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true,true,true};	
			private string strPrintText="";
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_intPosY += 15;
					p_objGrp.DrawString("术后访视",new Font("SimSun", 12,FontStyle.Bold),Brushes.Black,m_intRecBaseX+20,p_intPosY);
					p_intPosY += 20;
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>气管内插管全麻并发症"))
					{ 
						strPrintText="√气管内插管全麻并发症：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
				        if(m_hasItemDetail.Contains("术后访视>>气管内插管全麻并发症1"))
						strPrintText+=m_hasItemDetail["术后访视>>气管内插管全麻并发症1"].ToString();
						if(strPrintText!="√气管内插管全麻并发症：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{  
						p_objGrp.DrawString("□气管内插管全麻并发症：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
					 
					}

					m_blnIsPrint[0]=false;
				}
				if(m_blnIsPrint[1])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>硬膜外麻醉并发症"))
					{ 
						strPrintText="√硬膜外麻醉并发症：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("术后访视>>硬膜外麻醉并发症1"))
							strPrintText+=m_hasItemDetail["术后访视>>硬膜外麻醉并发症1"].ToString();
						if(strPrintText!="√硬膜外麻醉并发症：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{   
						p_objGrp.DrawString("□硬膜外麻醉并发症：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
						
					}

					m_blnIsPrint[1]=false;
				}
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>蛛网膜下腔麻醉并发症"))
					{ 
						strPrintText="√蛛网膜下腔麻醉并发症：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("术后访视>>蛛网膜下腔麻醉并发症1"))
							strPrintText+=m_hasItemDetail["术后访视>>蛛网膜下腔麻醉并发症1"].ToString();
						if(strPrintText!="√蛛网膜下腔麻醉并发症：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{   
						p_objGrp.DrawString("□蛛网膜下腔麻醉并发症：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
						
					}

					m_blnIsPrint[2]=false;
				}
				if(m_blnIsPrint[3])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>神经阻滞麻醉并发症"))
					{ 
						strPrintText="√神经阻滞麻醉并发症：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("术后访视>>神经阻滞麻醉并发症1"))
							strPrintText+=m_hasItemDetail["术后访视>>神经阻滞麻醉并发症1"].ToString();
						if(strPrintText!="√神经阻滞麻醉并发症：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{   
						p_objGrp.DrawString("□神经阻滞麻醉并发症：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
						
					}

					m_blnIsPrint[3]=false;
				}
				if(m_blnIsPrint[4])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>静脉复合麻醉并发症"))
					{ 
						strPrintText="√静脉复合麻醉并发症：";
						
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("术后访视>>静脉复合麻醉并发症1"))
							strPrintText+=m_hasItemDetail["术后访视>>静脉复合麻醉并发症1"].ToString();
						if(strPrintText!="√静脉复合麻醉并发症：") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{   
						p_objGrp.DrawString("□静脉复合麻醉并发症：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
				        p_intPosY+=20;
					}

					m_blnIsPrint[4]=false;
				}
				if(m_blnIsPrint[5])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>PCA"))
					{ 
						strPrintText="√PCA：";
						p_objGrp.DrawString("□",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						if(m_hasItemDetail.Contains("术后访视>>PCA1"))
							strPrintText+=m_hasItemDetail["术后访视>>PCA1"].ToString();
						else
							strPrintText+="                              ";
						if(m_hasItemDetail.Contains("术后访视>>其它"))
							strPrintText+="   其它:"+m_hasItemDetail["术后访视>>其它"].ToString();
						else
							strPrintText+="   其它:";
						m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					}
					else
					{   
						p_objGrp.DrawString("□PCA：                             其他：",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
						p_intPosY+=20;
		
				}

					m_blnIsPrint[5]=false;
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

				m_blnIsPrint = new Boolean[]{true,true,true,true,true,true};
			}
		}
		/// <summary>
		/// 术后访视>>处理意见
		/// </summary>
		private class clsPrintInPatMedRecPostOperateDoIdea:clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string strPrintText="         ";
					
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				if(m_blnIsFirstPrint)
				{   
					if(m_blnCheckBottom(ref p_intPosY,120,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("处理意见:",p_fntNormalText,Brushes.Black,m_intRecBaseX+20,p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后访视>>处理意见"))
						strPrintText+=m_hasItemDetail["术后访视>>处理意见"];
					if(strPrintText!="         ") strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					string p_strText="麻醉科医生：";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("麻醉科医生3"))
						p_strText+=m_hasItemDetail["麻醉科医生3"]+" ";
					else
						p_strText+="          ";
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("术前访视>>日期"))
						p_strText+=DateTime.Parse(m_hasItemDetail["术前访视>>日期"].ToString()).ToString("yyyy年MM月dd日");
					else
						p_strText+="200　年　月　日";
					p_objGrp.DrawString(p_strText,p_fntNormalText,Brushes.Black,(int)enmRectangleInfo.RightX-300,p_intPosY);
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
