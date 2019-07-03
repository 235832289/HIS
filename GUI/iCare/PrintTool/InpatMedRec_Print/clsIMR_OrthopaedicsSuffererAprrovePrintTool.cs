using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
namespace iCare
{
	/// <summary>
	/// 骨科(创伤与显微手术外科)手术知情同意书 打印 的摘要说明。
	/// </summary>
	public class clsIMR_OrthopaedicsSuffererAprrovePrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_OrthopaedicsSuffererAprrovePrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("骨科(创伤与显微手术外科)手术知情同意书",195),
																		   new clsPrintInPatOrthopaedicsSuffererMain(),																	  
																		   //new  clsPrintInPatMedDoctorAndDate(),
																		  // new  clsPrintInPatMedDoctorAndDate1()
																		   //  new clsPrintInPatMedRecDiagnostic()
																	   });			
		}
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {

        //        p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
        //        p_objGrp.DrawString("骨科(创伤与显微手术外科)手术知情同意书",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,250,70);
			
				//				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,350,110);
				//				p_objGrp.DrawString("母亲住院号：",p_fntNormalText,Brushes.Black,550,110);
				//p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
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
		#region 患者术前诊断---患方意见及签名
		/// <summary>
		/// 患者术前诊断---患方意见及签名
		/// </summary>
		private class clsPrintInPatOrthopaedicsSuffererMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
				private string[] m_strKeysArr1 = {"患者术前诊断"};
			    private string[] m_strKeysArr2 = {"建议患者进行"};
			    private string[] m_strKeysArr3 = {"可能出现的意外说明如下"};
				private string[] m_strKeysArr4 = {"患者本人签名"};
			    private string[] m_strKeysArr5 = {"患者家属签名"};
				private string[] m_strKeysArr6 = {"签名人与患者的关系"};
				private string[] m_strKeysArr7 = {"签名人的身份证号码"};

				private string[] m_strKeysArr8 = {"谈话医生签名"};

						
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				//				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
				//				{
				//					m_blnHaveMoreLine = false;
				//					return;
				//				}
				if(m_blnIsFirstPrint)
				{
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
                        //m_mthMakeText(new string[]{"患者姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","  性别："+ m_objPrintInfo.m_strSex.Trim()+"；" ,"  年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},
                        //    new string [] {"","",""},ref strAllText,ref strXml);
						
						//m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"  病区-床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName+"；"},new string []{""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"   住院号："+m_objPrintInfo.m_strInPatientID+""},new string []{""},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"姓名："},new string []{"m_objPrintInfo.m_strPatientName"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   床号："},new string []{"m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   住院号："},new string []{"m_objPrintInfo.m_strInPatientID"},ref strAllText,ref strXml);
						//m_mthMakeText(new string[]{"\n手术日期:","    至   $$"},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"\n\n患者术前诊断："},m_strKeysArr1,ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n\n患者术前诊断："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"\n建议患者进行："},new string[]{"建议患者进行"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n建议患者进行："},new string[]{""},ref strAllText,ref strXml);

							m_mthMakeText(new string[]{"\n         本专科医生本着向患者及其家属负责的精神，严肃认真地进行手术。并在手术前将本次手术的有关情况、危险性、可能出现的意外、合并症和后遗症等相关事宜向患者及家属说明如下："},new string[]{""},ref strAllText,ref strXml);
							m_mthMakeText(new string[]{"\n         本次手术需在麻醉下进行。有关施行麻醉过程中可能发生的麻醉意外等情况将由麻醉医生进行解释和签名。"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeText(new string[]{"\n       "},m_strKeysArr3,ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"},new string[]{""},ref strAllText,ref strXml);

							

						#region 患方意见及签名
							m_mthMakeText(new string[]{"\n         患方意见及签名："},new string[]{""},ref strAllText,ref strXml);
							m_mthMakeText(new string[]{"\n         我（家属）已认真看过以上告知内容，上述打V的内容医生已作过详细解释，经慎重考虑，我（家属）决定："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string [] {"手术治疗",""}) != false)
							m_mthMakeText(new string[]{"\n         同意接受","手术治疗，并且同意使用($$"},new string[]{"手术治疗",""},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n         同意接受___________________手术治疗，并且同意使用("},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","国产"}) != false)
							m_mthMakeCheckText(new string []{"√","国产"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"国产/  "},new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(new string[]{"","进口"}) != false)
							m_mthMakeCheckText(new string []{"√","进口"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"进口/  "},new string[]{""},ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(new string[]{"","合资"}) != false)
							m_mthMakeCheckText(new string []{"√","合资"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"合资/  "},new string[]{""},ref strAllText,ref strXml);

							m_mthMakeText(new string[]{")植入物，"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"人民币>>元",""}) != false)
							m_mthMakeText(new string[]{"价格约人民币（大写）","元。$$"},new string[]{"人民币>>元",""},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"价格约人民币（大写）___________________________________元。$$"},new string[]{""},ref strAllText,ref strXml);
						#region 签名
						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeText(new string[]{"\n\n              患者本人签名："},m_strKeysArr4,ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n\n              患者本人签名：____________________"},new string[]{""},ref strAllText,ref strXml);
	
						if(m_blnHavePrintInfo(m_strKeysArr5) != false)
							m_mthMakeText(new string[]{"\n\n              患者家属签名："},m_strKeysArr5,ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"\n\n              患者家属签名：_____________________"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr6) != false)
						{
							if(m_blnHavePrintInfo(m_strKeysArr5) != false)//格式控制
								m_mthMakeText(new string[]{"                              签名人与患者的关系："},m_strKeysArr6,ref strAllText,ref strXml);
							else
								m_mthMakeText(new string[]{"  签名人与患者的关系：____________________"},m_strKeysArr6,ref strAllText,ref strXml);
						}
						else
						{
							if(m_blnHavePrintInfo(m_strKeysArr5) != false)
							m_mthMakeText(new string[]{"                              签名人与患者的关系：____________________"},new string[]{""},ref strAllText,ref strXml);
						    else
								m_mthMakeText(new string[]{"  签名人与患者的关系：____________________"},new string[]{""},ref strAllText,ref strXml);

						}
						if(m_blnHavePrintInfo(new string []{"患者联系电话"}) != false)
						{
							m_mthMakeText(new string[]{"\n\n              患者联系电话："},new string[]{"患者联系电话"},ref strAllText,ref strXml);
							if(m_blnHavePrintInfo(m_strKeysArr7) != false)
								m_mthMakeText(new string[]{"          签名人的身份证号码："},new string[]{"签名人的身份证号码"},ref strAllText,ref strXml);
						    else
								m_mthMakeText(new string[]{"          签名人的身份证号码：____________________"},new string[]{"签名人的身份证号码"},ref strAllText,ref strXml);

						}
						else
						{
							m_mthMakeText(new string[]{"\n\n              患者联系电话：____________________"},new string[]{""},ref strAllText,ref strXml);
							if(m_blnHavePrintInfo(m_strKeysArr7) != false)
								m_mthMakeText(new string[]{"  签名人的身份证号码："},new string[]{"签名人的身份证号码"},ref strAllText,ref strXml);
							else
								m_mthMakeText(new string[]{"  签名人的身份证号码：____________________"},new string[]{""},ref strAllText,ref strXml);

						}
	                  if(m_blnHavePrintInfo(m_strKeysArr8) != false) 
						   m_mthMakeText(new string[]{"\n\n              谈话医生签名：","                        签名日期："},new string[]{"谈话医生签名","签名日期"},ref strAllText,ref strXml);
					  else
						   m_mthMakeText(new string[]{"\n\n              谈话医生签名：____________________","  签名日期："},new string[]{"","签名日期"},ref strAllText,ref strXml);
						#endregion 签名
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
	}
}
