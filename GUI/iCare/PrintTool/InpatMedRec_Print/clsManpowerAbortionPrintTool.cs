
using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
	/// <summary>
	/// 人工流产及结扎输卵管记录表
	/// </summary>
	public class clsManpowerAbortionPrintTool : clsInpatMedRecPrintBase
	{
		public clsManpowerAbortionPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("人工流产及结扎输卵管记录",250),
																		   new clsPrint2(),
																		   new clsPrint3(),
//																		   new clsPrint4(),
//																		   new clsPrint5(),
//																		   new clsPrint6(),
																		   new clsPrint7(),
																		   new clsPrint8(),
																		   new clsPrint9()
//																		   new clsPrint10(),
//																		   new clsPrint11()
																	   });			
		}

		
		#region 打印实现

		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
//        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
//        {
//            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

//            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//            {
//                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
//                p_objGrp.DrawString("人工流产及结扎输卵管记录表",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,330-30,70);
				
			
//                p_objGrp.DrawString("住院号：",p_fntNormalText,Brushes.Black,550,110);
//p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
//                p_intPosY =150;
//                m_blnHaveMoreLine = false;

				#region backup
//				p_objGrp.DrawString("人工流产及结扎输卵管记录表",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
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
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}

		#endregion
		#region 重载
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#endregion
		#region 打印从单位至过去史症状
		/// <summary>
		/// 打印从单位至过去史症状
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
			private string[] m_strKeysArr01  = {"爱人姓名","工作单位","早孕门诊次数","尿妊娠试验结果"};
			private string[] m_strKeysArr101 = {"爱人姓名：","工作单位：","\n早孕门诊次数：","尿妊娠试验结果："};
			private string[] m_strKeysArr02  = {"","怀孕原因>>避孕失败>>方法","怀孕原因>>避孕失败>>原因","怀孕原因>>扎管失败>>扎管日期","怀孕原因>>放环失败>>脱落于放环后>>月","怀孕原因>>放环失败>>未脱落怀孕于放环后>>月"};
			private string[] m_strKeysArr102 = {"\n怀孕原因：无避孕：","\n        避孕失败:方法：","原因：","\n        扎管失败：扎管日期：","\n        放环失败：脱落于放环后月数：","未脱落怀孕于放环后月数："};
			private string[] m_strKeysArr03  = {"过去接受宣教情况：","过去接受宣教情况>>未听过","过去接受宣教情况>>已听过"};
			private string[] m_strKeysArr103 = {"\n过去接受宣教情况：","过去接受宣教情况>>未听过","过去接受宣教情况>>已听过"};
			private string[] m_strKeysArr04  = {"地点：","过去接受宣教情况>>单位","过去接受宣教情况>>街坊","过去接受宣教情况>>本院"};
			private string[] m_strKeysArr104 = {"地点：","过去接受宣教情况>>单位","过去接受宣教情况>>街坊","过去接受宣教情况>>本院"};
			private string[] m_strKeysArr05  = {"主诉>>停经",""};
			private string[] m_strKeysArr105 = {"\n主诉：停经天数："," "};
			private string[] m_strKeysArr06  = {"","主诉>>要求人工流产","主诉>>绝育"};
			private string[] m_strKeysArr106 = {"","主诉>>要求人工流产","主诉>>绝育"};
			private string[] m_strKeysArr07  = {"现在史>>停经",""};
			private string[] m_strKeysArr107 = {"\n现病史：停经天数："," "};
			private string[] m_strKeysArr08  = {"自觉症状：","现在史>>恶心","现在史>>呕吐","现在史>>胃纳差","现在史>>厌食","现在史>>怕冷感","胎膜破裂时间>>自然"};
			private string[] m_strKeysArr108 = {"自觉症状：","现在史>>恶心","现在史>>呕吐","现在史>>胃纳差","现在史>>厌食","现在史>>怕冷感","胎膜破裂时间>>自然"};
			private string[] m_strKeysArr09  = {"\n过去史：","过去史>>伤寒","过去史>>胃病","过去史>>肺结核","过去史>>过敏史","过去史>>心脏病","过去史>>剖腹手术","过去史>>其他"};
			private string[] m_strKeysArr109 = {"\n过去史：","过去史>>伤寒","过去史>>胃病","过去史>>肺结核","过去史>>过敏史","过去史>>心脏病","过去史>>剖腹手术","过去史>>其他"};

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
                        //m_mthMakeText(new string []{"门诊号："},new string []{"门诊号"},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"；姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；","籍贯："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strNationality)+"；","职业："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strNativePlace)+"；","工作单位："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strOfficeName)+"；","住址："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strHomeAddress+"；")},new string[]{"","","","","",""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"\n入院日期："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"))+"；"},new string[]{""},ref strAllText,ref strXml);
					
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
//						
						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);

						m_mthMakeCheckText(m_strKeysArr103,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr05) != false)
							m_mthMakeText(m_strKeysArr105,m_strKeysArr05,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr106,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr07) != false)
							m_mthMakeText(m_strKeysArr107,m_strKeysArr07,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr108,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr109,ref strAllText,ref strXml);
						
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

		#region 生育史至妇检
		/// <summary>
		/// 生育史至妇检
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
			private string[] m_strKeysArr01  = {"","生育史>>足月产","生育史>>早产","生育史>>现存孩子","生育史>>最幼者","生育史>>流产者","生育史>>人工流产","生育史>>末次人流日期"};
			private string[] m_strKeysArr101 = {"生育史：","足月产次数：","早产次数：","现存孩子人数：","最幼者岁数：","流产次数：","人工流产次数：","末次人流日期："};
			private string[] m_strKeysArr02  = {"月经史>>初潮","月经史>>周期","月经史>>持久","月经史>>排量","月经史>>血块","月经史>>经痛","月经史>>前次月经","月经史>>末次月经"};
			private string[] m_strKeysArr102 = {"\n月经史：初潮：","周期：","持久：","排量：","血块：","经痛：","\n        前次月经：","末次月经："};
			private string[] m_strKeysArr03  = {"检查>>一般情况>>心","检查>>一般情况>>肺","检查>>一般情况>>脾","检查>>一般情况>>肝","检查>>一般情况>>皮肤","检查>>一般情况>>血压","检查>>一般情况>>四肢","检查>>一般情况>>其他"};
			private string[] m_strKeysArr103 = {"\n检查：一般情况：心：","肺：","脾：","肝：","皮肤：","血压：","四肢：","其他："};
			private string[] m_strKeysArr04  = {"妇检>>外阴","妇检>>阴道","妇检>>孑宫颈","妇检>>孑宫体","妇检>>附件","妇检>>血常规","妇检>>血型","妇检>>尿常规"};
			private string[] m_strKeysArr104 = {"\n妇检：外阴：","阴道：","孑宫颈：","\n        孑宫体：","附件：","\n        血常规：","血型：","尿常规："};
			private string[] m_strKeysArr05  = {"阴液检查>>清洁度","阴液检查>>滴虫","阴液检查>>淋菌","阴液检查>>念珠菌"};
			private string[] m_strKeysArr105 = {"\n阴液检查：清洁度","滴虫：","淋菌：","念珠菌："};

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
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr05) != false)
							m_mthMakeText(m_strKeysArr105,m_strKeysArr05,ref strAllText,ref strXml);
			
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

		#region 诊    断
		/// <summary>
		/// 诊    断
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
					if(m_hasItems.Contains("诊    断"))
						objItemContent = m_hasItems["诊    断"] as clsInpatMedRec_Item;
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
					m_mthAddSign2("诊断",m_objPrintContext.m_ObjModifyUserArr);
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

		#region 计划治疗
		/// <summary>
		/// 计划治疗
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
					if(m_hasItems.Contains("计划治疗"))
						objItemContent = m_hasItems["计划治疗"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("计划治疗：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("计划治疗",m_objPrintContext.m_ObjModifyUserArr);
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

		#region 主治医师
		/// <summary>
		///  主治医师
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
			private string[] m_strKeysArr01 = {"主治医师","住院医师","实习医师"};
			private string[] m_strKeysArr101 = {"      主治医师：","                         住院医师：","                         实习医师："};
			private string[] m_strKeysArr02 = {"生育史>>人工流产日期"};
			private string[] m_strKeysArr102 = {"\n                                                                                                                           日  期："};


 
			
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
