
using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
	/// <summary>
	/// 新生儿转科记录
	/// </summary>
	public class clsIMR_ChildbirthTransitSectionPrintTool : clsInpatMedRecPrintBase
	{
		public clsIMR_ChildbirthTransitSectionPrintTool(string p_strTypeID) : base(p_strTypeID)
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
																		   new clsPrint9()
																		   
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
				p_objGrp.DrawString("新生儿转科病历",m_fotItemHead,Brushes.Black,m_intRecBaseX+295,p_intPosY - 10);
		
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

		#region 打印新生儿父亲姓名 ------- 孕产期用药情况 
		/// <summary>
		/// 打印新生儿父亲姓名 ------- 孕产期用药情况 
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
			private string[] m_strKeysArr01  = {"新生儿父亲姓名","年龄","新生儿父亲血型"};
			private string[] m_strKeysArr101 = {"新生儿父亲姓名：","年龄：","新生儿父亲血型："};
			private string[] m_strKeysArr02  = {"产妇的孕次","产次","产妇血型","地贫","G-6PD","ABO抗体水平","HB5AG","分娩日期"};
			private string[] m_strKeysArr102 = {"\n产妇的孕次：","产次：","产妇血型：","地贫：","G-6PD：","ABO抗体水平：","HB5AG：","\n分娩日期："};
			private string[] m_strKeysArr03  = {"\n分娩方式：","分娩方式>>顺产","分娩方式>>吸引产","分娩方式>>钳产","分娩方式>>剖宫产","分娩方式>>臀助产术","分娩方式>>臀牵引术","分娩方式>>其他"};
			private string[] m_strKeysArr103 = {"\n分娩方式：","分娩方式>>顺产","分娩方式>>吸引产","分娩方式>>钳产","分娩方式>>剖宫产","分娩方式>>臀助产术","分娩方式>>臀牵引术","分娩方式>>其他"};
			private string[] m_strKeysArr04  = {"手术产指征"};
			private string[] m_strKeysArr104 = {"\n手术产指征："};
			private string[] m_strKeysArr05  = {"产时情况：","产时情况>>急产","产时情况>>滞产","产时情况>>第二产程延长","产时情况>>胎膜早破"};
			private string[] m_strKeysArr105 = {"产时情况：","产时情况>>急产","产时情况>>滞产","产时情况>>第二产程延长","产时情况>>胎膜早破"};
			private string[] m_strKeysArr06  = {"产时情况>>胎膜早破>>小时",""};
			private string[] m_strKeysArr106 = {"","小时$$"};
			private string[] m_strKeysArr07  = {"羊水情况"};
			private string[] m_strKeysArr107 = {"羊水情况："};
			private string[] m_strKeysArr08  = {"脐带情况","脐带情况>>脐血PH值"};
			private string[] m_strKeysArr108 = {"\n脐带情况：","脐血PH值："};
			private string[] m_strKeysArr09  = {"脐带有无绕颈","脐带情况>>脐带绕颈>>无","脐带情况>>脐带绕颈>>有"};
			private string[] m_strKeysArr109 = {"脐带有无绕颈：","脐带情况>>脐带绕颈>>无","脐带情况>>脐带绕颈>>有"};
			private string[] m_strKeysArr10  = {"脐带情况>>脐带绕颈>>有>>周","脐带情况>>扭转>>周"};
			private string[] m_strKeysArr110 = {"脐带绕颈周数：","扭转周数："};
			private string[] m_strKeysArr11  = {"\n胎盘情况：","胎盘情况>>前置","胎盘情况>>早剥","胎盘情况>>钙化","胎盘情况>>其他"};
			private string[] m_strKeysArr111 =  {"\n胎盘情况：","胎盘情况>>前置","胎盘情况>>早剥","胎盘情况>>钙化","胎盘情况>>其他"};
			private string[] m_strKeysArr12  = {"胎盘情况>>其他>>其他"};
			private string[] m_strKeysArr112 = {"其他："};
			private string[] m_strKeysArr13  = {"病理产科情况"};
			private string[] m_strKeysArr113 = {"\n病理产科情况："};
			private string[] m_strKeysArr14  = {"孕产期用药情况"};
			private string[] m_strKeysArr114 = {"\n孕产期用药情况："};
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
						m_mthMakeCheckText(m_strKeysArr103,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr105,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr06) != false)
							m_mthMakeText(m_strKeysArr106,m_strKeysArr06,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr07) != false)
							m_mthMakeText(m_strKeysArr107,m_strKeysArr07,ref strAllText,ref strXml);
					
						if(m_blnHavePrintInfo(m_strKeysArr08) != false)
							m_mthMakeText(m_strKeysArr108,m_strKeysArr08,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr109,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr10) != false)
							m_mthMakeText(m_strKeysArr110,m_strKeysArr10,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr11,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr12) != false)
							m_mthMakeText(m_strKeysArr112,m_strKeysArr12,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr13) != false)
							m_mthMakeText(m_strKeysArr113,m_strKeysArr13,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr14) != false)
							m_mthMakeText(m_strKeysArr114,m_strKeysArr14,ref strAllText,ref strXml);
//			
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



		#region 新生儿情况--出生体重 至硬肿程度
		/// <summary>
		/// 新生儿情况--出生体重 至硬肿程度
		/// </summary>
		private class clsPrint3 : clsIMR_PrintLineBase
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
			private string[] m_strKeysArr01  = {"","新生儿情况>>出生体重>>kg","新生儿情况>>身长","新生儿情况>>Apgar评分>>1分","新生儿情况>>Apgar评分>>5分","新生儿情况>>窒息时间>>分钟"};
			private string[] m_strKeysArr101 = {"出生体重(kg)：","","身长：","Apgar评分(1分)：","Apgar评分(5分)：","窒息时间："};
			private string[] m_strKeysArr02  = {"\n黄疸：","新生儿情况>>黄疸>>轻","新生儿情况>>黄疸>>中","新生儿情况>>黄疸>>重"};
			private string[] m_strKeysArr102 = {"\n黄疸：","新生儿情况>>黄疸>>轻","新生儿情况>>黄疸>>中","新生儿情况>>黄疸>>重"};
			private string[] m_strKeysArr03  = {"新生儿情况>>皮测胆红素>>U","新生儿情况>>微量胆红素"};
			private string[] m_strKeysArr103 = {"皮测胆红素（U）：","微量胆红素："};
			private string[] m_strKeysArr04  = {"\n面色：","新生儿情况>>面色>>红润","新生儿情况>>面色>>青紫","新生儿情况>>面色>>苍白","新生儿情况>>面色>>灰暗"};
			private string[] m_strKeysArr104 = {"\n面色：","新生儿情况>>面色>>红润","新生儿情况>>面色>>青紫","新生儿情况>>面色>>苍白","新生儿情况>>面色>>灰暗"};
			private string[] m_strKeysArr05  = {"\n皮肤：","新生儿情况>>皮肤>>正常","新生儿情况>>皮肤>>花纹","新生儿情况>>皮肤>>皮疹","新生儿情况>>皮肤>>出血点","新生儿情况>>皮肤>>其它"};
			private string[] m_strKeysArr105 = {"\n皮肤：","新生儿情况>>皮肤>>正常","新生儿情况>>皮肤>>花纹","新生儿情况>>皮肤>>皮疹","新生儿情况>>皮肤>>出血点","新生儿情况>>皮肤>>其它"};
			private string[] m_strKeysArr06  = {"新生儿情况>>皮肤>>其它"};
			private string[] m_strKeysArr106 = {"其它："};
			private string[] m_strKeysArr07  = {"\n硬肿程度：","新生儿情况>>硬肿程度>>Ⅰ度","新生儿情况>>硬肿程度>>Ⅲ度"};
			private string[] m_strKeysArr107 = {"\n硬肿程度：","新生儿情况>>硬肿程度>>Ⅰ度","新生儿情况>>硬肿程度>>Ⅲ度"};
			private string[] m_strKeysArr08  = {"新生儿情况>>硬肿程度>>部位","新生儿情况>>硬肿程度>>面积","新生儿情况>>硬肿程度>>其他"};
			private string[] m_strKeysArr108 = {"部位：","面积：","其他："};
		
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
					p_objGrp.DrawString("新生儿情况",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 20;
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
						m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr105,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr06) != false)
							m_mthMakeText(m_strKeysArr106,m_strKeysArr06,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr107,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr08) != false)
							m_mthMakeText(m_strKeysArr108,m_strKeysArr08,ref strAllText,ref strXml);
					
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

		#region 体格检查:-------杂音
		/// <summary>
		/// 体格检查:-------杂音
		/// </summary>
		private class clsPrint4 : clsIMR_PrintLineBase
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
			private string[] m_strKeysArr101 = {"体格检查："};
		
			private string[] m_strKeysArr02  = {"头颅五官外观：","新生儿情况>>体格检查>>头颅五官外观>>正常","新生儿情况>>体格检查>>头颅五官外观>>异常"};
			private string[] m_strKeysArr102 = {"头颅五官外观：","新生儿情况>>体格检查>>头颅五官外观>>正常","新生儿情况>>体格检查>>头颅五官外观>>异常"};
			private string[] m_strKeysArr03  = {"新生儿情况>>体格检查>>异常>>异常","新生儿情况>>体格检查>>产瘤部位","新生儿情况>>体格检查>>大小>>平方米",""};
			private string[] m_strKeysArr103 = {"","产瘤部位：","大小(平方米)：","；"};
			private string[] m_strKeysArr04  = {"\n        血肿：","新生儿情况>>体格检查>>血肿>>无血肿","新生儿情况>>体格检查>>血肿>>有血肿"};
			private string[] m_strKeysArr104 = {"\n        血肿：","新生儿情况>>体格检查>>血肿>>无血肿","新生儿情况>>体格检查>>血肿>>有血肿"};
			private string[] m_strKeysArr05  = {"新生儿情况>>体格检查>>血肿部位","新生儿情况>>体格检查>>大小>>立方米","新生儿情况>>体格检查>>前卤>>平方米"};
			private string[] m_strKeysArr105 = {"血肿部位：","大小(立方米)","\n        前卤(平方米)"};
			private string[] m_strKeysArr06  = {"","新生儿情况>>体格检查>>膨满","新生儿情况>>体格检查>>波动","新生儿情况>>体格检查>>凹陷"};
			private string[] m_strKeysArr106 = {"","新生儿情况>>体格检查>>膨满","新生儿情况>>体格检查>>波动","新生儿情况>>体格检查>>凹陷"};
			private string[] m_strKeysArr07  = {"\n胸廓：","新生儿情况>>胸廓>>对称","新生儿情况>>胸廓>>凸起","新生儿情况>>胸廓>>漏斗胸","新生儿情况>>胸廓>>三凹征"};
			private string[] m_strKeysArr107 = {"\n胸廓：","新生儿情况>>胸廓>>对称","新生儿情况>>胸廓>>凸起","新生儿情况>>胸廓>>漏斗胸","新生儿情况>>胸廓>>三凹征"};
			private string[] m_strKeysArr08  = {"新生儿情况>>胸廓>>呼吸节律>>次/分","新生儿情况>>呼吸音","新生儿情况>>罗音"};
			private string[] m_strKeysArr108 = {"呼吸节律(次/分)：","呼吸音：","罗音："};
			private string[] m_strKeysArr09  = {"有无吸暂停：","新生儿情况>>吸暂停>>无","新生儿情况>>吸暂停>>有"};
			private string[] m_strKeysArr109 = {"有无吸暂停：","新生儿情况>>吸暂停>>无","新生儿情况>>吸暂停>>有"};
			private string[] m_strKeysArr10  = {"新生儿情况>>心率>>次/分","新生儿情况>>心率>>心律"};
			private string[] m_strKeysArr110 = {"\n心率(次/分)：","心律："};
			private string[] m_strKeysArr11  = {"杂音：","新生儿情况>>杂音>>无杂音","新生儿情况>>杂音>>有杂音"};
			private string[] m_strKeysArr111 = {"杂音：","新生儿情况>>杂音>>无杂音","新生儿情况>>杂音>>有杂音"};
			private string[] m_strKeysArr12  = {"新生儿情况>>杂音>>有"};
			private string[] m_strKeysArr112 = {""};
			
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
						
						 m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
																		
						if(m_blnHavePrintInfo(m_strKeysArr05) != false)
							m_mthMakeText(m_strKeysArr105,m_strKeysArr05,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr106,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr107,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr08) != false)
							m_mthMakeText(m_strKeysArr108,m_strKeysArr08,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr109,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr10) != false)
							m_mthMakeText(m_strKeysArr110,m_strKeysArr10,ref strAllText,ref strXml);
						 m_mthMakeCheckText(m_strKeysArr111,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr112) != false)
							m_mthMakeText(m_strKeysArr112,m_strKeysArr12,ref strAllText,ref strXml);
				
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


		#region 打印 腹部---------
		/// <summary>
		/// 腹部---------
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
			private string[] m_strKeysArr01  = {"\n腹部：","新生儿情况>>腹部>>平坦","新生儿情况>>腹部>>凹陷","新生儿情况>>腹部>>隆起"};
			private string[] m_strKeysArr101 = {"\n腹部：","新生儿情况>>腹部>>平坦","新生儿情况>>腹部>>凹陷","新生儿情况>>腹部>>隆起"};
			private string[] m_strKeysArr02  = {"腹部包块：","新生儿情况>>腹部>>腹部包块>>无腹部包块","新生儿情况>>腹部>>腹部包块>>有腹部包块"};
			private string[] m_strKeysArr102 = {"腹部包块：","新生儿情况>>腹部>>腹部包块>>无腹部包块","新生儿情况>>腹部>>腹部包块>>有腹部包块"};
			private string[] m_strKeysArr03  = {"新生儿情况>>腹部>>腹部包块>>有"};
			private string[] m_strKeysArr103 = {""};
			private string[] m_strKeysArr04  = {"脐带：","新生儿情况>>脐带>>已脱","新生儿情况>>脐带>>未脱"};
			private string[] m_strKeysArr104 = {"脐带：","新生儿情况>>脐带>>已脱","新生儿情况>>脐带>>未脱"};
			private string[] m_strKeysArr05  = {"脐分泌物：","新生儿情况>>脐带>>脐分泌物>>正常","新生儿情况>>脐带>>脐分泌物>>异常"};
			private string[] m_strKeysArr105 = {"脐分泌物：","新生儿情况>>脐带>>脐分泌物>>正常","新生儿情况>>脐带>>脐分泌物>>异常"};
			private string[] m_strKeysArr06  = {"新生儿情况>>脐带>>脐分泌物>>异常>>异常"};
			private string[] m_strKeysArr106 = {""};
			private string[] m_strKeysArr07  = {"\n脊柱四肢：","新生儿情况>>脊柱四肢>>正常","新生儿情况>>脊柱四肢>>侧弯","新生儿情况>>脊柱四肢>>后凸"};
			private string[] m_strKeysArr107 = {"\n脊柱四肢：","新生儿情况>>脊柱四肢>>正常","新生儿情况>>脊柱四肢>>侧弯","新生儿情况>>脊柱四肢>>后凸"};
			private string[] m_strKeysArr08  = {"肌张力：","新生儿情况>>脊柱四肢>>肌张力>>正常","新生儿情况>>脊柱四肢>>肌张力>>减弱","新生儿情况>>脊柱四肢>>肌张力>>增强"};
			private string[] m_strKeysArr108 = {"肌张力：","新生儿情况>>脊柱四肢>>肌张力>>正常","新生儿情况>>脊柱四肢>>肌张力>>减弱","新生儿情况>>脊柱四肢>>肌张力>>增强"};
			private string[] m_strKeysArr09  = {"肛门：","新生儿情况>>肛门>>正常","新生儿情况>>肛门>>闭锁"};
			private string[] m_strKeysArr109 = {"肛门：","新生儿情况>>肛门>>正常","新生儿情况>>肛门>>闭锁"};
			private string[] m_strKeysArr10  = {"\n睾丸：","新生儿情况>>睾    丸>>已降","新生儿情况>>睾    丸>>未降"};
			private string[] m_strKeysArr110 = {"\n睾丸：","新生儿情况>>睾    丸>>已降","新生儿情况>>睾    丸>>未降"};
			private string[] m_strKeysArr11  = {"神经反射：","新生儿情况>>神经反射>>觅食反射","新生儿情况>>神经反射>>吸吮反射","新生儿情况>>神经反射>>拥抱反射","新生儿情况>>神经反射>>握持反射"};
			private string[] m_strKeysArr111 = {"神经反射：","新生儿情况>>神经反射>>觅食反射","新生儿情况>>神经反射>>吸吮反射","新生儿情况>>神经反射>>拥抱反射","新生儿情况>>神经反射>>握持反射"};
		
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
						
						m_mthMakeCheckText(m_strKeysArr101,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr103,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr105,ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(m_strKeysArr06) != false)
							m_mthMakeText(m_strKeysArr106,m_strKeysArr06,ref strAllText,ref strXml);
						
						m_mthMakeCheckText(m_strKeysArr107,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr108,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr109,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr110,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr111,ref strAllText,ref strXml);
						
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


		#region 新生儿情况>>特殊检查
		/// <summary>
		/// 新生儿情况>>特殊检查
		/// </summary>
		private class clsPrint6 : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("新生儿情况>>特殊检查"))
						objItemContent = m_hasItems["新生儿情况>>特殊检查"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("特殊检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("特殊检查",m_objPrintContext.m_ObjModifyUserArr);
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
					if(m_hasItems.Contains("新生儿情况>>初步诊断"))
						objItemContent = m_hasItems["新生儿情况>>初步诊断"] as clsInpatMedRec_Item;
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

		#region 新生儿情况>>转科原因
		/// <summary>
		/// 新生儿情况>>转科原因
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
					if(m_hasItems.Contains("新生儿情况>>转科原因"))
						objItemContent = m_hasItems["新生儿情况>>转科原因"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("转科原因：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("转科原因",m_objPrintContext.m_ObjModifyUserArr);
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

		#region 新生儿情况>>医生签名
		/// <summary>
		///  新生儿情况>>医生签名
		/// </summary>
		private class clsPrint9 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
			private string[] m_strKeysArr01 = {"新生儿情况>>医生签名"};
			private string[] m_strKeysArr101 = {"                                                                                                         医生签名："};
	
			private string[] m_strKeysArr02 = {"日期"};
			private string[] m_strKeysArr102 = {"\n                                                                                                        日 期："};
	


 
			
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
						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
			
			
								
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

