using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
namespace iCare
{
	/// <summary>
	///  MODS器官系统功能临床研究观察登记表 打印的摘要说明。
	/// </summary>
	public class cls_MODS_ApparatusObservePrintTool: clsInpatMedRecPrintBase
	{
		public cls_MODS_ApparatusObservePrintTool(string p_strTypeID) : base(p_strTypeID)
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
																		   new clsPrintInPatApparatusObserveGeneral(),
				                                                           new  clsPrintInPatApparatusObserveCheck(),
				                                                           new  clsPrintInPatApparatusObserveEvaluate(),
                                                                           new  clsPrintInPatApparatusObserve()
																		  
				
				//  new clsPrintInPatMedRecDiagnostic()
			});			
		}
		protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{}
		protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{
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
				//				p_objGrp.DrawString("剖宫产手术记录",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
				//		
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				//		
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				//		
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
				//				p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
				//
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				//		
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				//		
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				//
				//				p_intPosY += 20;
				//				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
				//		
				//				p_intPosY += 20;
				//				if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
				//				{
				//					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
				//				}
				//				else
				//				{
				//					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				//				}				
				//			
				//				m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
				//				int intRealHeight;
				//				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
				//				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
				//								
				//				p_intPosY += 30;
				//				m_blnHaveMoreLine = false;
				#endregion
				p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
				p_objGrp.DrawString("MODS器官系统功能临床研究观察登记表",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,250,70);
			
				//				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,350,110);
				//				p_objGrp.DrawString("母亲住院号：",p_fntNormalText,Brushes.Black,550,110);
				//p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
				p_intPosY =130;
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}

		#endregion
		#region 一般资料---
		/// <summary>
		/// 一般资料
		/// </summary>
		private class clsPrintInPatApparatusObserveGeneral: clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
			
			private string[] m_strKeysArr2 = {" √","出院方式>>治愈"};
			private string[] m_strKeysArr02 = {"  治愈"};

			private string[] m_strKeysArr3 = {"    √","出院方式>>好转"};
			private string[] m_strKeysArr03 = {"    好转"};
			
			private string[] m_strKeysArr4 = {"    √","出院方式>>恶化"};
			private string[] m_strKeysArr04 = {"    恶化"};
			
			private string[] m_strKeysArr5 = {"    √","出院方式>>死亡"};
			private string[] m_strKeysArr05 = {"    死亡"};

						
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
						m_mthMakeText(new string[]{"姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","	  性别："+ m_objPrintInfo.m_strSex.Trim()+"；" ,"   年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},
							new string [] {"","",""},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"	 科别："+m_objPrintInfo.m_strDeptName+"；"},new string []{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"	 住院号："+m_objPrintInfo.m_strInPatientID+""},new string []{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n入院时间："+m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时")+"；"},new string []{""},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"	 住院天数："},new string[]{"住院天数"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；	  入选时间：入院：","天$$"},new string[]{"入选时间>>入院",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n入院诊断："},new string[]{"入院诊断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n出院诊断："},new string[]{"出院诊断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n出院方式："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeCheckText(m_strKeysArr2,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr02,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeCheckText(m_strKeysArr3,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeCheckText(m_strKeysArr4,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr04,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr5) != false)
							m_mthMakeCheckText(m_strKeysArr5,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr05,ref strAllText,ref strXml);
					
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
		#region 常规检查
		/// <summary>
		/// 常规检查
		/// </summary>
		private class clsPrintInPatApparatusObserveCheck: clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;			
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
			p_intPosY+=3;
				if(m_blnIsFirstPrint)
				{
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;

					//p_objGrp.DrawString("常 规 检 查",new Font("宋体", 12),Brushes.Black,280,p_intPosY);

					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"生命体征："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"呼吸：","次/分；$$"},new string[]{"生命体征>>呼吸",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"心率：","次/分；$$"},new string[]{"生命体征>>心率",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"体温：","℃；$$"},new string[]{"生命体征>>体温",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"血压：","kPa/mmHg；$$"},new string[]{"生命体征>>血压",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"体重：","Kg；$$"},new string[]{"生命体征>>体重",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n心功能："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"    CK(u/L)："},new string[]{"心功能>>CK(u/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    CK-MB(u/L)："},new string[]{"心功能>>CK-MB(u/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    LDH(u/L)："},new string[]{"心功能>>LDH(u/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    CVP/MAP："},new string[]{"心功能>>CVP/MAP"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n肺功能："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"    PaO2(kPa/mmHg)："},new string[]{"肺功能>>PaO2(kPa/mmHg)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    PaCO2(kPa/mmHg)："},new string[]{"肺功能>>PaCO2(kPa/mmHg)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    PaO2/FiO2："},new string[]{"肺功能>>PaO2/FiO2"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n呼吸机参数："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{" 模式："},new string[]{"呼吸机参数>>模式"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    MAP(cmH2O)："},new string[]{"呼吸机参数>>MAP(cmH2O)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    PEEP(cmH2O)："},new string[]{"呼吸机参数>>PEEP(cmH2O)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Ti(秒)："},new string[]{"呼吸机参数>>Ti(秒)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     MV(L/min)："},new string[]{"呼吸机参数>>MV(L/min)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    RR(bpm)："},new string[]{"呼吸机参数>>RR(bpm)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Cd(mL/cmH2O)："},new string[]{"呼吸机参数>>Cd(mL/cmH2O)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Cs(mL/cmH2O)："},new string[]{"呼吸机参数>>Cs(mL/cmH2O)"},ref strAllText,ref strXml);
					
						m_mthMakeText(new string[]{"\n肝功能："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"    ALT(u/L)："},new string[]{"肝功能>>ALT(u/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    总胆红素(umol/L)："},new string[]{"肝功能>>总胆红素(umol/L)"},ref strAllText,ref strXml);

						m_mthMakeText(new string[]{"\n肾功能："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"    血Cr(umol/L)："},new string[]{"肾功能>>血Cr(umol/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    BUN(mmol/L)："},new string[]{"肾功能>>BUN(mmol/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    尿比重："},new string[]{"肾功能>>尿比重"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    尿量："},new string[]{"肾功能>>尿量"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n凝血功能："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{" TT："},new string[]{"凝血功能>>TT"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    PT："},new string[]{"凝血功能>>PT"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    APPT："},new string[]{"凝血功能>>APPT"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Fg："},new string[]{"凝血功能>>Fg"},ref strAllText,ref strXml);

						m_mthMakeText(new string[]{"\n内分泌："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"    pH："},new string[]{"内分泌>>pH"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    血糖(mmol/L)："},new string[]{"内分泌>>血糖(mmol/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    血钠(mmol/L)："},new string[]{"内分泌>>血钠(mmol/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    血钙(mmol/L)："},new string[]{"内分泌>>血钙(mmol/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    其他："},new string[]{"内分泌>>其他"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                    胰岛素："},new string[]{"内分泌>>胰岛素"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    C肽："},new string[]{"内分泌>>C肽"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    皮质醇："},new string[]{"内分泌>>皮质醇"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                    甲旁素："},new string[]{"内分泌>>甲旁素"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    ACTH："},new string[]{"内分泌>>ACTH"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    GH："},new string[]{"内分泌>>GH"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    IGF："},new string[]{"内分泌>>IGF"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    IgG："},new string[]{"内分泌>>IgG"},ref strAllText,ref strXml);

						m_mthMakeText(new string[]{"\n免疫："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"       IgA："},new string[]{"免疫>>IgA"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    IgM："},new string[]{"免疫>>IgM"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    C3："},new string[]{"免疫>>C3"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    C4："},new string[]{"免疫>>C4"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                    CD3："},new string[]{"免疫>>CD3"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    CD4+："},new string[]{"免疫>>CD4+"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    CD8+："},new string[]{"免疫>>CD8+"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    CD16+56+："},new string[]{"免疫>>CD16+56+"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n血常规："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"   白细胞数(109/L)："},new string[]{"血常规>>白细胞数(109/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    杆状分类(％)："},new string[]{"血常规>>杆状分类(％)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Hb(g/L)："},new string[]{"血常规>>Hb(g/L)"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；    Plt(109/L)："},new string[]{"血常规>>Plt(109/L)"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n病原学：  "},new string[]{"病原学"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\nX线：(放射号：",")：$$"},new string[]{"X线>>放射号",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{""},new string[]{"X线>>放射"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n其他：CRP/HCRP："},new string[]{"其他>>CRP/HCRP"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n器官功能评估："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"	受损器官："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"		受损程度："},new string[]{""},ref strAllText,ref strXml);
						
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
	
		#region 器官功能评估---
		/// <summary>
		/// 器官功能评估
		/// </summary>
		private class clsPrintInPatApparatusObserveEvaluate: clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
			
			private string[] m_strKeysArr6 = {"\n          		 √ ","器官功能评估>>受损器官>>循环"};
			private string[] m_strKeysArr06 = {"\n                                  循环"};

			private string[] m_strKeysArr7 = {"\n          		 √ ","器官功能评估>>受损器官>>肺"};
			private string[] m_strKeysArr07 = {"\n                                  肺"};
			
			private string[] m_strKeysArr8 = {"\n          		 √ ","器官功能评估>>受损器官>>肝"};
			private string[] m_strKeysArr08 = {"\n                                  肝"};
			
			private string[] m_strKeysArr9 = {"\n          		 √ ","器官功能评估>>受损器官>>肾"};
			private string[] m_strKeysArr09 = {"\n                                  肾"};
			
			private string[] m_strKeysArr10 = {"\n          		 √ ","器官功能评估>>受损器官>>胃肠"};
			private string[] m_strKeysArr010 = {"\n                                  胃肠"};
			
			private string[] m_strKeysArr11 = {"\n          		 √ ","器官功能评估>>受损器官>>血液"};
			private string[] m_strKeysArr011 = {"\n                                  血液"};
			
			private string[] m_strKeysArr12 = {"\n          		 √ ","器官功能评估>>受损器官>>代谢"};
			private string[] m_strKeysArr012 = {"\n                                  代谢"};
			
			private string[] m_strKeysArr13 = {"\n          		 √ ","器官功能评估>>受损器官>>脑"};
			private string[] m_strKeysArr013 = {"\n                                  脑"};
			
			private string[] m_strKeysArr14 = {"\n          		 √ ","器官功能评估>>受损器官>>免疫"};
			private string[] m_strKeysArr014 = {"\n                                  免疫"};
			
			private string[] m_strKeysArr61 = {"              √ ","器官功能评估>>受损程度>>循环>>1"};
			private string[] m_strKeysArr061 = {"              1；"};
			private string[] m_strKeysArr61a = {"                √ ","器官功能评估>>受损程度>>循环>>1"};
			private string[] m_strKeysArr061a = {"                 1；"};

		
			private string[] m_strKeysArr62= {"            √ ","器官功能评估>>受损程度>>循环>>2"};
			private string[] m_strKeysArr062 = {"            2；"};
			
			private string[] m_strKeysArr63= {"            √ ","器官功能评估>>受损程度>>循环>>3"};
			private string[] m_strKeysArr063 = {"            3；"};

			private string[] m_strKeysArr71 = {"                  √ ","器官功能评估>>受损程度>>肺>>1"};
			private string[] m_strKeysArr071 = {"                  1；"};
			private string[] m_strKeysArr71a = {"                       √ ","器官功能评估>>受损程度>>肺>>1"};
			private string[] m_strKeysArr071a = {"                       1；"};
		
			private string[] m_strKeysArr72= {"              √ ","器官功能评估>>受损程度>>肺>>2"};
			private string[] m_strKeysArr072 = {"            2；"};
			
			private string[] m_strKeysArr73= {"            √ ","器官功能评估>>受损程度>>肺>>3"};
			private string[] m_strKeysArr073 = {"            3；"};

			private string[] m_strKeysArr81 = {"                  √ ","器官功能评估>>受损程度>>肝>>1"};
			private string[] m_strKeysArr081 = {"                  1；"};
			private string[] m_strKeysArr81a = {"                       √ ","器官功能评估>>受损程度>>肝>>1"};
			private string[] m_strKeysArr081a = {"                       1；"};
		
			private string[] m_strKeysArr82= {"              √ ","器官功能评估>>受损程度>>肝>>2"};
			private string[] m_strKeysArr082 = {"            2；"};
			
			private string[] m_strKeysArr83= {"            √ ","器官功能评估>>受损程度>>肝>>3"};
			private string[] m_strKeysArr083 = {"            3；"};

			private string[] m_strKeysArr91 = {"                  √ ","器官功能评估>>受损程度>>肾>>1"};
			private string[] m_strKeysArr091 = {"                  1；"};
			private string[] m_strKeysArr91a = {"                       √ ","器官功能评估>>受损程度>>肾>>1"};
			private string[] m_strKeysArr091a = {"                       1；"};
		
			private string[] m_strKeysArr92= {"              √ ","器官功能评估>>受损程度>>肾>>2"};
			private string[] m_strKeysArr092 = {"            2；"};
			
			private string[] m_strKeysArr93= {"            √ ","器官功能评估>>受损程度>>肾>>3"};
			private string[] m_strKeysArr093 = {"            3；"};

			private string[] m_strKeysArr101 = {"              √ ","器官功能评估>>受损程度>>胃肠>>1"};
			private string[] m_strKeysArr0101 = {"               1；"};
			private string[] m_strKeysArr0101a = {"                √ ","器官功能评估>>受损程度>>胃肠>>1"};
			private string[] m_strKeysArr00101a = {"                  1；"};

			private string[] m_strKeysArr102= {"            √ ","器官功能评估>>受损程度>>胃肠>>2"};
			private string[] m_strKeysArr0102 = {"            2；"};
			
			private string[] m_strKeysArr103= {"            √ ","器官功能评估>>受损程度>>胃肠>>3"};
			private string[] m_strKeysArr0103 = {"            3；"};


			private string[] m_strKeysArr111 = {"              √ ","器官功能评估>>受损程度>>血液>>1"};
			private string[] m_strKeysArr0111 = {"               1；"};
			private string[] m_strKeysArr0111a = {"                √ ","器官功能评估>>受损程度>>血液>>1"};
			private string[] m_strKeysArr00111a = {"                  1；"};

			private string[] m_strKeysArr112= {"            √ ","器官功能评估>>受损程度>>血液>>2"};
			private string[] m_strKeysArr0112 = {"            2；"};
			
			private string[] m_strKeysArr113= {"            √ ","器官功能评估>>受损程度>>血液>>3"};
			private string[] m_strKeysArr0113 = {"            3；"};



			private string[] m_strKeysArr121 = {"              √ ","器官功能评估>>受损程度>>代谢>>1"};
			private string[] m_strKeysArr0121 = {"               1；"};
			private string[] m_strKeysArr0121a = {"                √ ","器官功能评估>>受损程度>>代谢>>1"};
			private string[] m_strKeysArr00121a = {"                  1；"};

			private string[] m_strKeysArr122= {"            √ ","器官功能评估>>受损程度>>代谢>>2"};
			private string[] m_strKeysArr0122 = {"            2；"};
			
			private string[] m_strKeysArr123= {"            √ ","器官功能评估>>受损程度>>代谢>>3"};
			private string[] m_strKeysArr0123 = {"            3；"};

			private string[] m_strKeysArr131 = {"                  √ ","器官功能评估>>受损程度>>脑>>1"};
			private string[] m_strKeysArr0131 = {"                  1；"};
			private string[] m_strKeysArr0131a = {"                       √ ","器官功能评估>>受损程度>>脑>>1"};
			private string[] m_strKeysArr00131a = {"                       1；"};

		
			private string[] m_strKeysArr132= {"            √ ","器官功能评估>>受损程度>>脑>>2"};
			private string[] m_strKeysArr0132 = {"            2；"};
			
			private string[] m_strKeysArr133= {"            √ ","器官功能评估>>受损程度>>脑>>3"};
			private string[] m_strKeysArr0133 = {"            3；"};


			private string[] m_strKeysArr141 = {"              √ ","器官功能评估>>受损程度>>免疫>>1"};
			private string[] m_strKeysArr0141 = {"              1；"};
			private string[] m_strKeysArr0141a = {"                √ ","器官功能评估>>受损程度>>免疫>>1"};
			private string[] m_strKeysArr00141a = {"                  1；"};

			private string[] m_strKeysArr142= {"            √ ","器官功能评估>>受损程度>>免疫>>2"};
			private string[] m_strKeysArr0142 = {"            2；"};
			
			private string[] m_strKeysArr143= {"            √ ","器官功能评估>>受损程度>>免疫>>3"};
			private string[] m_strKeysArr0143 = {"            3；"};
				
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
				p_intPosY+=2;
				if(m_blnIsFirstPrint)
				{
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
//						m_mthMakeText(new string[]{"\n器官功能评估："},new string[]{""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"	受损器官："},new string[]{""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"		受损程度："},new string[]{""},ref strAllText,ref strXml);
//						
						// p_intPosY=p_intPosY+40;
						int x=16;
				

						#region 6
											if(m_blnHavePrintInfo(m_strKeysArr6) != false)
						                         p_objGrp.DrawString("√ 循环",p_fntNormalText,Brushes.Black,150,p_intPosY);
												 //m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
											else
												p_objGrp.DrawString(" 循环",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
												if(m_blnHavePrintInfo(m_strKeysArr61) != false)
												{
													p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
												}
												else
												{
													p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
												}
												if(m_blnHavePrintInfo(m_strKeysArr62) != false)
													p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
												else
													p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
												if(m_blnHavePrintInfo(m_strKeysArr63) != false)
													p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
												else
													p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
                                       p_intPosY+=20;
												;
						#endregion
						#region 7
						if(m_blnHavePrintInfo(m_strKeysArr7) != false)
							p_objGrp.DrawString("√ 肺",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 肺",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						p_objGrp.DrawString("1、器官功能障碍",p_fntNormalText,Brushes.Black,550,p_intPosY);
						
						if(m_blnHavePrintInfo(m_strKeysArr71) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr72) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr73) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						 p_intPosY+=20;
						#endregion
						
						#region 8
						if(m_blnHavePrintInfo(m_strKeysArr8) != false)
							p_objGrp.DrawString("√ 肝",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 肝",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
						p_objGrp.DrawString("2、严重器官功能障碍",p_fntNormalText,Brushes.Black,550,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr81) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr82) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr83) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
                             p_intPosY+=20;
                      #endregion
						#region 9
						if(m_blnHavePrintInfo(m_strKeysArr9) != false)
							p_objGrp.DrawString("√ 肾",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 肾",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
						
						p_objGrp.DrawString("3、器官衰竭",p_fntNormalText,Brushes.Black,550,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr91) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr92) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr93) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
                         p_intPosY+=20;
						#endregion
						#region 10
						if(m_blnHavePrintInfo(m_strKeysArr10) != false)
							p_objGrp.DrawString("√ 胃肠",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 胃肠",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr101) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr102) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr103) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						p_intPosY+=20;
						#endregion
						#region 11
						if(m_blnHavePrintInfo(m_strKeysArr11) != false)
							p_objGrp.DrawString("√ 血液",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 血液",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr111) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr112) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr113) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						p_intPosY+=20;
						#endregion
						#region 12
						if(m_blnHavePrintInfo(m_strKeysArr12) != false)
							p_objGrp.DrawString("√ 代谢",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 代谢",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr121) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr122) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr123) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						p_intPosY+=20;
						#endregion
						#region 13
						if(m_blnHavePrintInfo(m_strKeysArr13) != false)
							p_objGrp.DrawString("√ 脑",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 脑",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr131) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr132) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr133) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						p_intPosY+=20;
						#endregion
						#region 14
						if(m_blnHavePrintInfo(m_strKeysArr14) != false)
							p_objGrp.DrawString("√ 免疫",p_fntNormalText,Brushes.Black,150,p_intPosY);
							//m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							p_objGrp.DrawString(" 免疫",p_fntNormalText,Brushes.Black,150+x,p_intPosY);
												
						
						if(m_blnHavePrintInfo(m_strKeysArr141) != false)
						{
							p_objGrp.DrawString("√1",p_fntNormalText,Brushes.Black,270,p_intPosY);	
						}
						else
						{
							p_objGrp.DrawString("1",p_fntNormalText,Brushes.Black,270+x,p_intPosY);
						}
						if(m_blnHavePrintInfo(m_strKeysArr142) != false)
							p_objGrp.DrawString("√2",p_fntNormalText,Brushes.Black,350,p_intPosY);	
						else
							p_objGrp.DrawString("2",p_fntNormalText,Brushes.Black,350+x,p_intPosY);
						if(m_blnHavePrintInfo(m_strKeysArr143) != false)
							p_objGrp.DrawString("√3",p_fntNormalText,Brushes.Black,420,p_intPosY);
													
						else
							p_objGrp.DrawString("3",p_fntNormalText,Brushes.Black,420+x,p_intPosY);
						p_intPosY+=20;
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
		#region 观察指标---
		/// <summary>
		/// 观察指标
		/// </summary>
		private class clsPrintInPatApparatusObserve: clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
			private string[] m_strKeysArr15 = {" √","观察指标>>预警指标"};
			private string[] m_strKeysArr015 = {"  预警指标"};

			private string[] m_strKeysArr16 = {"    √","观察指标>>内分泌"};
			private string[] m_strKeysArr016 = {"    内分泌"};
			
			private string[] m_strKeysArr17 = {"    √","观察指标>>胃肠道"};
			private string[] m_strKeysArr017 = {"    胃肠道"};
			
			private string[] m_strKeysArr18 = {"    √","观察指标>>肺部"};
			private string[] m_strKeysArr018 = {"    肺部"};
			
			private string[] m_strKeysArr19 = {"    √","观察指标>>铁相关蛋白"};
			private string[] m_strKeysArr019 = {"    铁相关蛋白"};
		
			private string[] m_strKeysArr20 = {"    √","观察指标>>免疫"};
			private string[] m_strKeysArr020 = {"    免疫"};

			private string[] m_strKeysArr21 = {"    √","干预措施>>1，6-二磷酸果糖"};
			private string[] m_strKeysArr021 = {" 1，6-二磷酸果糖"};

			private string[] m_strKeysArr22 = {"    √","干预措施>>肠干预"};
			private string[] m_strKeysArr022 = {"    肠干预"};
		
			private string[] m_strKeysArr23 = {"    √","干预措施>>肾替代疗法"};
			private string[] m_strKeysArr023 = {"    肾替代疗法"};
		
			private string[] m_strKeysArr24 = {"    √","干预措施>>抗炎"};
			private string[] m_strKeysArr024 = {"    干预措施>>抗炎"};
						
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
												#region 观察指标————受损器官个数
												m_mthMakeText(new string[]{"\n观察指标："},new string[]{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr15) != false)
													m_mthMakeCheckText(m_strKeysArr15,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr015,new string []{""},ref strAllText,ref strXml);
						
												if(m_blnHavePrintInfo(m_strKeysArr16) != false)
													m_mthMakeCheckText(m_strKeysArr16,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr016,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr17) != false)
													m_mthMakeCheckText(m_strKeysArr17,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr017,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr18) != false)
													m_mthMakeCheckText(m_strKeysArr18,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr018,new string []{""},ref strAllText,ref strXml);
						
												if(m_blnHavePrintInfo(m_strKeysArr19) != false)
													m_mthMakeCheckText(m_strKeysArr19,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr020,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr20) != false)
													m_mthMakeCheckText(m_strKeysArr20,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr020,new string []{""},ref strAllText,ref strXml);
												
												
												m_mthMakeText(new string[]{"\n干预措施："},new string[]{""},ref strAllText,ref strXml);
						
												if(m_blnHavePrintInfo(m_strKeysArr21) != false)
													m_mthMakeCheckText(m_strKeysArr21,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr021,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr22) != false)
													m_mthMakeCheckText(m_strKeysArr22,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr022,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr23) != false)
													m_mthMakeCheckText(m_strKeysArr23,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr023,new string []{""},ref strAllText,ref strXml);
												if(m_blnHavePrintInfo(m_strKeysArr24) != false)
													m_mthMakeCheckText(m_strKeysArr24,ref strAllText,ref strXml);
												else
													m_mthMakeText(m_strKeysArr024,new string []{""},ref strAllText,ref strXml);
						
												m_mthMakeText(new string[]{"\n受损器官个数（自动统计上面打勾的器官）："},new string[]{"受损器官个数"},ref strAllText,ref strXml);
						
						
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
