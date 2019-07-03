using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
	/// <summary>
	/// 分娩记录
	/// </summary>
	public class clsIMR_childbirthPrintTool : clsInpatMedRecPrintBase
	{
		public clsIMR_childbirthPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("分 娩 记 录",320),
																		   new clsPrintInPatMedRecCaseMain(),
																		   new clsPrintadscript(),
																		   new clsPrint1(),
																		   new clsPrint2(),
																		   new clsPrintInPatApgar(),new clsPrintInPatMedDocAndDate()
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
//                #region 注译
////				p_objGrp.DrawString("分娩记录",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
////		
////				p_intPosY += 20;
////				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
////		
////				p_intPosY += 20;
////				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
////		
////				p_intPosY += 20;
////				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
////				p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
////
////				p_intPosY += 20;
////				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
////		
////				p_intPosY += 20;
////				p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
////		
////				p_intPosY += 20;
////				p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
////
////				p_intPosY += 20;
////				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
////		
////				p_intPosY += 20;
////				if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
////				{
////					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
////				}
////				else
////				{
////					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
////				}				
////			
////				m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
////				int intRealHeight;
////				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
////				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
////								
////				p_intPosY += 30;
////				m_blnHaveMoreLine = false;
//                #endregion

//                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
//                p_objGrp.DrawString("分 娩 记 录",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,360,70);
			
//                p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,350,110);
//                p_objGrp.DrawString("母亲住院号：",p_fntNormalText,Brushes.Black,550,110);
//                p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
//                p_intPosY =150;
//                m_blnHaveMoreLine = false;
//            }

//            public override void m_mthReset()
//            {
//                m_objPrintContext.m_mthRestartPrint();

//                m_blnHaveMoreLine = true;
//            }
//        }

		#endregion

		#region 重载
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#endregion


		#region 打印前段资料
		/// <summary>
		/// 打印前段资料
		/// </summary>
		private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
			private string[] m_strKeysArr1 = {"","孕/产次","预产期","孕周"};
			//private string[] m_strKeysArr2 = {"","临 产 时 间>>年","","临 产 时 间>>月","","临 产 时 间>>日","","临 产 时 间>>午","","临 产 时 间>>时","","临 产 时 间>>分",""};
			//private string[] m_strKeysArr3 = {"","胎膜破裂时间>>年","","胎膜破裂时间>>月","","胎膜破裂时间>>日","","胎膜破裂时间>>午","","胎膜破裂时间>>时","","胎膜破裂时间>>分","","胎膜破裂时间>>前羊水性状","胎膜破裂时间>>前羊水量",""};
            //private string[] m_strKeysArr4 = {"","胎儿娩出时间>>年","","胎儿娩出时间>>月","","胎膜破裂时间>>日","","胎儿娩出时间>>午","","胎儿娩出时间>>时","","胎儿娩出时间>>分",""};
			//private string[] m_strKeysArr5 = {"","宫口开全时间>>年","","宫口开全时间>>月","","宫口开全时间>>日","","宫口开全时间>>午","","宫口开全时间>>时","","宫口开全时间>>分",""};
            //private string[] m_strKeysArr6 = {"","胎盘娩出时间>>年","","胎盘娩出时间>>月","","胎盘娩出时间>>日","","胎盘娩出时间>>午","","胎盘娩出时间>>时","","胎盘娩出时间>>分",""};
		


			//m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);
						
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
	
				if(m_blnIsFirstPrint)
				{
                    string strTime1 = "";
                    string strTime2 = "";
                    string strTime3 = "";
                    string strTime4 = "";
                    string strTime5 = "";
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{

                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("分娩>>临产时间"))
                            {
                                objItemContent = m_hasItems["分娩>>临产时间"] as clsInpatMedRec_Item;
                                strTime1 = objItemContent.m_strItemContent + "$$";
                            }
                            if (m_hasItems.Contains("分娩>>胎膜破裂时间"))
                            {
                                objItemContent = m_hasItems["分娩>>胎膜破裂时间"] as clsInpatMedRec_Item;
                                strTime2 = objItemContent.m_strItemContent + "$$";
                            }
                            if (m_hasItems.Contains("分娩>>胎儿娩出时间"))
                            {
                                objItemContent = m_hasItems["分娩>>胎儿娩出时间"] as clsInpatMedRec_Item;
                                strTime4 = objItemContent.m_strItemContent + "$$";
                            }
                            if (m_hasItems.Contains("分娩>>胎盘娩出时间"))
                            {
                                objItemContent = m_hasItems["分娩>>胎盘娩出时间"] as clsInpatMedRec_Item;
                                strTime5 = objItemContent.m_strItemContent + "$$";
                            }
                            if (m_hasItems.Contains("分娩>>宫口开全时间"))
                            {
                                objItemContent = m_hasItems["分娩>>宫口开全时间"] as clsInpatMedRec_Item;
                                strTime3 = objItemContent.m_strItemContent + "$$";
                            }

                        }
                           m_mthMakeText(new string[]{"\n", "孕/产次：","预产期：","孕周："},m_strKeysArr1,ref strAllText,ref strXml);
                        //if(m_blnHavePrintInfo(m_strKeysArr2) != false)
                           m_mthMakeText(new string[] { "\n临产时间：", strTime1 }, new string[] { "", "" }, ref strAllText, ref strXml);
						//if(m_blnHavePrintInfo(m_strKeysArr3) != false)
                           m_mthMakeText(new string[] { "\n胎膜破裂时间：", strTime2, "前羊水性状：", "前羊水量：", "#ml$$" }, new string[] { "", "", "胎膜破裂时间>>前羊水性状", "胎膜破裂时间>>前羊水量", "胎膜破裂时间>>前羊水量" }, ref strAllText, ref strXml);
						m_mthMakeCheckText(new string[]{"；破裂方式：","胎膜破裂时间>>人工","胎膜破裂时间>>自然"},ref strAllText,ref strXml);
						//if(m_blnHavePrintInfo(m_strKeysArr5) != false)
                        m_mthMakeText(new string[] { "\n宫口开全时间：", strTime3 }, new string[] { "", "" }, ref strAllText, ref strXml);
                            //if (m_blnHavePrintInfo(m_strKeysArr4) != false)
                        m_mthMakeText(new string[] { "\n胎儿娩出时间：", strTime4 }, new string[] { "", "" }, ref strAllText, ref strXml);
						m_mthMakeCheckText(new string[]{"\n胎儿娩出方式：","胎儿娩出方式>>顺产","胎儿娩出方式>>吸引产","胎儿娩出方式>>钳产","胎儿娩出方式>>剖宫产","胎儿娩出方式>>助产","胎儿娩出方式>>牵引"},ref strAllText,ref strXml);
						
							m_mthMakeText(new string[]{"胎方位："},new string[]{"胎儿娩出方式>>胎方位"},ref strAllText,ref strXml);				
						
						
						//if(m_blnHavePrintInfo(m_strKeysArr6) != false)
                            m_mthMakeText(new string[] { "\n胎盘娩出时间：", strTime5 }, new string[] { "", "" }, ref strAllText, ref strXml);				
						m_mthMakeCheckText(new string[]{"；","胎儿娩出时间>>子面","胎儿娩出时间>>母面"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string[]{"","胎儿娩出时间>>人工","胎儿娩出时间>>自然"},ref strAllText,ref strXml);

				
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

		#region 打印胎儿附属器情况
		/// <summary>
		/// 打印胎儿附属器情况
		/// </summary>
		private class clsPrintadscript : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
	
			private string[] m_strKeysArr01 = {""};
			private string[] m_strKeysArr101 = {"\n胎儿附属器情况:"};
			private string[] m_strKeysArr02 = {"","胎儿附属器情况>>胎盘完整","胎儿附属器情况>>长","胎儿附属器情况>>宽","胎儿附属器情况>>厚","胎儿附属器情况>>重量",""};//"","胎儿附属器情况>>胎膜完整","胎儿附属器情况>>脐带长","","胎儿附属器情况>>脐带情况","胎儿附属器情况>>周",""};
            private string[] m_strKeysArr102 = { "\n        ", "胎盘完整:", "体积(cm)长:", "宽:", "厚:", "重量:", "g$$" };//,"胎膜完整:","脐带长:","cm$$","；脐带情况:","","周$$"};
			private string[] m_strKeysArr022 = {"","胎儿附属器情况>>胎膜完整","胎儿附属器情况>>脐带长","","胎儿附属器情况>>脐带情况","胎儿附属器情况>>周",""};
			private string[] m_strKeysArr1022 = {"\n        ","胎膜完整:","脐带长:","cm$$","；脐带情况:","","周$$"};
			private string[] m_strKeysArr03 = {"","胎儿附属器情况>>松紧","胎儿附属器情况>>圈","","胎儿附属器情况>>真结假结","胎儿附属器情况>>其它情况","胎儿附属器情况>>附着",""};//"胎儿附属器情况>>后羊水性质量","胎儿附属器情况>>总羊水量"};
			private string[] m_strKeysArr103 = {"\n        ","松紧度:","扭转:","圈$$","；真结假结情况:","其它情况:","附着:","$$"};//,"后羊水性质量:","总羊水量"};
			private string[] m_strKeysArr04 = {"","胎儿附属器情况>>后羊水性质量","胎儿附属器情况>>总羊水量"};
			private string[] m_strKeysArr104 = {"\n        ","后羊水性质量:","总羊水量"};


			//m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);
						
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

						//						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
						m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr022) != false)
							m_mthMakeText(m_strKeysArr1022,m_strKeysArr022,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr03) != false)
							m_mthMakeText(m_strKeysArr103,m_strKeysArr03,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr04) != false)
							m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
						
				
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

		#region 打印宫颈情况，会阴情况，产后出血，产程时间，手术名称，产妇情况，
		/// <summary>
		/// 打印宫颈情况，会阴情况，产后出血，产程时间，手术名称，产妇情况，
		/// </summary>
		private class clsPrint1 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
	
			private string[] m_strKeysArr01 = {"宫 颈 情 况"};
			private string[] m_strKeysArr101 = {"\n宫颈情况："};
            private string[] m_strKeysArr02 = { "", "会阴情况>>外缝"};
            private string[] m_strKeysArr102 ={ "\n会阴情况：", "$$"};
            //private string[] m_strKeysArr02 = { "\n会阴情况：", "会阴情况>>完整", "会阴情况>>直开", "会阴情况>>侧切" };
            //private string[] m_strKeysArr102 ={ "\n会阴情况：", "会阴情况>>完整", "会阴情况>>直开", "会阴情况>>侧切" };
            //private string[] m_strKeysArr03 = {"会阴破裂情况：","会阴情况>>破裂Ⅰ度","会阴情况>>破裂Ⅱ度","会阴情况>>破裂Ⅲ度"};
            //private string[] m_strKeysArr103 =  {"会阴破裂情况：","会阴情况>>破裂Ⅰ度","会阴情况>>破裂Ⅱ度","会阴情况>>破裂Ⅲ度"};
            //private string[] m_strKeysArr04 = {"会阴情况>>外缝",""};
            //private string[] m_strKeysArr104 =  {"外缝：","针$$"};
			private string[] m_strKeysArr05 = {"","产后出血>>产后出血","","产后出血>>产后2小时内出血","","产后出血>>评估方法","产后出血>>宫缩剂"};
			private string[] m_strKeysArr105 =  {"\n","产后出血：","ml$$","产后2小时内出血：","ml$$","评估方法:","宫缩剂:"};
			private string[] m_strKeysArr06 = {"","","产程时间>>第一程>>时","","产程时间>>第一程>>分","","","产程时间>>第二程>>时","","产程时间>>第二程>>分","","产程时间>>第三程>>时","","产程时间>>第三程>>分"};
			private string[] m_strKeysArr106 =  {"\n产程时间：","第一程：","","时$$","","分","第二程：","","时$$","","分","第三程：","","时$$","","分"};
			private string[] m_strKeysArr07 = {"手术名称","手术指行征"};
			private string[] m_strKeysArr107 =  {"\n手术名称：","手术指行征："};
			private string[] m_strKeysArr08 = {"产妇情况","产妇情况>>产后血压","","产妇情况>>产后2小时血压","","产妇情况>>脉搏","产妇情况>>产后宫缩","产妇情况>>宫底高度"};
			private string[] m_strKeysArr108 =  {"\n产妇情况：","产后血压：","mmHg$$","；产后2小时血压：","mmHg$$","；脉搏：","产后宫缩:","宫底高度:"};

			//m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);
						
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
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(m_strKeysArr103,ref strAllText,ref strXml);
                        //if(m_blnHavePrintInfo(m_strKeysArr04) != false)
                        //    m_mthMakeText(m_strKeysArr104,m_strKeysArr04,ref strAllText,ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr07) != false)
							m_mthMakeText(m_strKeysArr107,m_strKeysArr07,ref strAllText,ref strXml);
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

		#region 打印新生儿情况，产后诊断，附注
		/// <summary>
		/// 打印新生儿情况，产后诊断，附注
		/// </summary>
		private class clsPrint2 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
	
			private string[] m_strKeysArr01 = {""};
			private string[] m_strKeysArr101 = {"\n新生儿情况:"};
			private string[] m_strKeysArr02 = {"\n        性别：","新生儿情况>>性别>>男","新生儿情况>>性别>>女"};
			private string[] m_strKeysArr102 ={"\n        性别：","新生儿情况>>性别>>男","新生儿情况>>性别>>女"};
			private string[] m_strKeysArr03 = {"出生时情况；","新生儿情况>>出生时情况>>成熟","新生儿情况>>出生时情况>>早产","新生儿情况>>出生时情况>>活产","新生儿情况>>出生时情况>>死产","新生儿情况>>出生时情况>>死胎"};
			private string[] m_strKeysArr103 =  {"出生时情况；","新生儿情况>>出生时情况>>成熟","新生儿情况>>出生时情况>>早产","新生儿情况>>出生时情况>>活产","新生儿情况>>出生时情况>>死产","新生儿情况>>出生时情况>>死胎"};
			private string[] m_strKeysArr04 = {"\n        呼吸：","新生儿情况>>呼吸>>自然","新生儿情况>>呼吸>>人工"};
			private string[] m_strKeysArr104 =  {"\n        呼吸：","新生儿情况>>呼吸>>自然","新生儿情况>>呼吸>>人工"};
			private string[] m_strKeysArr05  = {"新生儿室息：","新生儿情况>>新生儿室息>>无","新生儿情况>>新生儿室息>>轻度","新生儿情况>>新生儿室息>>重度"};
			private string[] m_strKeysArr105 = {"新生儿室息：","新生儿情况>>新生儿室息>>无","新生儿情况>>新生儿室息>>轻度","新生儿情况>>新生儿室息>>重度"};
			private string[] m_strKeysArr06  = {"","新生儿情况>>复苏方法","新生儿情况>>出生体重","","新生儿情况>>出生体重>>身长","","新生儿情况>>出生体重>>头围","","新生儿情况>>出生体重>>产瘤位置","新生儿情况>>出生体重>>大小","新生儿情况>>畸形和特殊标志","新生儿情况>>产后诊断"};
			private string[] m_strKeysArr106 = {"\n        ","复苏方法：","出生体重：","g$$","；身长：","cm$$","；头围：","cm$$","产瘤位置：","大小：","畸形和特殊标志：","产后诊断："};
			private string[] m_strKeysArr07  = {"","新生儿情况>>出生体重","","新生儿情况>>出生体重>>身长","","新生儿情况>>出生体重>>头围","","新生儿情况>>出生体重>>产瘤位置","新生儿情况>>出生体重>>大小","新生儿情况>>畸形和特殊标志","新生儿情况>>产后诊断"};
			private string[] m_strKeysArr107 = {"\n        ","出生体重：","g$$","；身长：","cm$$","；头围：","cm$$","；产瘤位置：","大小：","畸形和特殊标志：","产后诊断："};
			private string[] m_strKeysArr08  = {"","新生儿情况>>畸形和特殊标志","新生儿情况>>产后诊断","新生儿情况>>附注"};
			private string[] m_strKeysArr108 = {"\n        ","畸形和特殊标志：","\n产后诊断：","\n附注："};
			
			//m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);
						
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
						 
						m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr103,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr104,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr105,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr06) != false)
							m_mthMakeText(m_strKeysArr106,m_strKeysArr06,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr07) != false)
							m_mthMakeText(m_strKeysArr107,m_strKeysArr07,ref strAllText,ref strXml);
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

		#region Apgar评分表
		/// <summary>
		/// Apgar评分表
		/// </summary>
		private class clsPrintInPatApgar : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			private Font m_fontItem = new Font("宋体",10);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool blnNextPage = true;
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"Apgar评分表>>心率/分钟>>0","Apgar评分表>>心率/分钟>>小于100次","Apgar评分表>>心率/分钟>>大于100次"};
			private string[] m_strKeysArr2 = {"Apgar评分表>>呼吸>>0 ","Apgar评分表>>呼吸>>浅慢不规则","Apgar评分表>>呼吸>>佳哭声呼"};
			private string[] m_strKeysArr3 = {"Apgar评分表>>肌张力>>松驰","Apgar评分表>>肌张力>>四肢屈曲","Apgar评分表>>肌张力>>四肢活动"};
			private string[] m_strKeysArr4 = {"Apgar评分表>>刺激反射>>无反应","Apgar评分表>>刺激反射>>有些动作","Apgar评分表>>刺激反射>>哭喷噎"};
			private string[] m_strKeysArr5 = {"Apgar评分表>>皮肤颜色>>青紫苍白","Apgar评分表>>皮肤颜色>>躯干红四肢紫","Apgar评分表>>皮肤颜色>>全身红润"};
			private string[] m_strKeysArr6 = { "Apgar评分表>>总分>>总分", "Apgar评分表>>总分>>一评","Apgar评分表>>总分>>二评","Apgar评分表>>总分>>三评"};
            //private string[] m_strKeysArr7 = {"Apgar评分表>>总分>>总分"};
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if( !(m_blnHavePrintInfo(m_strKeysArr1) == true || m_blnHavePrintInfo(m_strKeysArr2) == true 
					|| m_blnHavePrintInfo(m_strKeysArr3) == true|| m_blnHavePrintInfo(m_strKeysArr4) == true|| m_blnHavePrintInfo(m_strKeysArr5) == true
					|| m_blnHavePrintInfo(m_strKeysArr6) == true))
				{
					m_blnHaveMoreLine = false;
					return;
				}
                if (p_intPosY + 210 > clsPrintPosition.c_intBottomY)
                {
                    m_blnHaveMoreLine = true;
                    p_intPosY += 1500;
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
					SizeF size = p_objGrp.MeasureString("Apgar评分表",m_fontItemMidHead);
					int intMiddle = (clsPrintPosition.c_intRightX - clsPrintPosition.c_intLeftX)/2 - Convert.ToInt32(size.Width/2);
					p_intPosY += 20;
					p_objGrp.DrawString("Apgar评分表",m_fontItemMidHead,Brushes.Black,intMiddle,p_intPosY);
					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						//						if(m_blnHavePrintInfo(m_strKeysArr) != false)
						//							m_mthMakeText(new string[]{"肌营养：","肌张力："},m_strKeysArr,ref strAllText,ref strXml);
						////						m_mthMakeCheckText(m_strKeysArr1,ref strAllText,ref strXml);
						//						if(m_blnHavePrintInfo(m_strKeysArr) != false)
						//							m_mthMakeText(new string[]{"不自主运动：","肌力："},m_strKeysArr2,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("Apgar评分表",m_objPrintContext.m_ObjModifyUserArr);

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
				
				int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
				int intRowStep = m_intRecBaseX + 10;
				int intPosY = p_intPosY;
				int inttempY = p_intPosY;
				int intInTableInitY = p_intPosY; //用于传递给画数据库内容函数的初始坐标
				int intDiv = intLineWidth/5;
				int intPing = intDiv/3;
				int intRowHeigth = 30;

				int int2Score =0;
				int int3Score =0;
				int X=0;
				int Y=0;
				string printStr = "";

				#region 画行线
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);

				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth/5*4,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth/5*4,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth/5*4,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth/5*4,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);
				intPosY += intRowHeigth;
				p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);

				#endregion 

				#region 取出数据
				clsInpatMedRec_Item[] strRet1 = m_mthPrintSubItem(new string[]{"","",""},m_strKeysArr1);
				clsInpatMedRec_Item[] strRet2 = m_mthPrintSubItem(new string[]{"","",""},m_strKeysArr2);
				clsInpatMedRec_Item[] strRet3 = m_mthPrintSubItem(new string[]{"","",""},m_strKeysArr3);
				clsInpatMedRec_Item[] strRet4 = m_mthPrintSubItem(new string[]{"","",""},m_strKeysArr4);
				clsInpatMedRec_Item[] strRet5 = m_mthPrintSubItem(new string[]{"","",""},m_strKeysArr5);
				string[] strRet6 = m_mthPrintTextItem(new string[]{"","","", ""},m_strKeysArr6);
                //string[] strRet7 = m_mthPrintTextItem(new string[] { "" }, m_strKeysArr7);
				#endregion 

				#region 画坚线
				p_objGrp.DrawLine(Pens.Black,intRowStep,p_intPosY,intRowStep ,intPosY);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv,p_intPosY,intRowStep + intDiv,intPosY);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*2,p_intPosY,intRowStep + intDiv*2,intPosY - intRowHeigth);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*3,p_intPosY,intRowStep + intDiv*3,intPosY - intRowHeigth);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*4,p_intPosY,intRowStep + intDiv*4,intPosY);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*5,p_intPosY,intRowStep + intDiv*5,intPosY);

				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*4 + intPing,p_intPosY,intRowStep + intDiv*4 +intPing,intPosY);
				p_objGrp.DrawLine(Pens.Black,intRowStep + intDiv*4 + intPing*2,p_intPosY,intRowStep + intDiv*4 +intPing*2,intPosY);
				#endregion 
	
				#region 画实体第一行
				printStr = "体征";
				SizeF size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "0分";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "1分";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv*2 + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "2分";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv*3 + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "一评";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "二评";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv*4 + intPing +intPing/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				int2Score = X;

				printStr = "三评";
				size = p_objGrp.MeasureString(printStr,m_fontItem);				
				X = intRowStep + intDiv*4 + intPing*2 + intPing/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				int3Score = X;
				//
				inttempY  = inttempY + intRowHeigth;
				//

				#endregion 

				#region 第一列
				printStr = "心率/分钟";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				//打第相应行数据
				m_mthPrintStr(Y,strRet1,p_objGrp,new string[]{"0","<100分钟",">100分钟"});
				//
	
				inttempY  = inttempY + intRowHeigth;
				//
				printStr = "呼吸";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);
				//打第相应行数据
				m_mthPrintStr(Y,strRet2,p_objGrp,new string[]{"0","浅慢不规则","佳哭声呼"});
				//
				//
				inttempY  = inttempY + intRowHeigth;
				//
				printStr = "肌张力";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);
				//打第相应行数据
				m_mthPrintStr(Y,strRet3,p_objGrp,new string[]{"松驰","四肢屈曲","四肢活动"});
				//
				//
				inttempY  = inttempY + intRowHeigth;
				//
				printStr = "刺激反射";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);
				//打第相应行数据
				m_mthPrintStr(Y,strRet4,p_objGrp,new string[]{"无反应","有动作皱眉","哭喷噎"});
				//
				//
				inttempY  = inttempY + intRowHeigth;
				//
				printStr = "皮肤颜色";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);
				//打第相应行数据
				m_mthPrintStr(Y,strRet5,p_objGrp,new string[]{"青紫苍白","躯干红四肢紫","全身红润"});
				//
				//
				inttempY  = inttempY + intRowHeigth;
				//
				printStr = "总分";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				Y = intRowHeigth/2 + inttempY - Convert.ToInt32(size.Height/2);
				X = intRowStep + intDiv/2 - Convert.ToInt32(size.Width/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);
				//打第相应行数据
				int tX = intRowStep + intDiv + intDiv*3/2 - Convert.ToInt32(size.Width/4);

				p_objGrp.DrawString(strRet6[0].ToString(),m_fontItem,Brushes.Black,tX,Y);
				tX = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/4);
				p_objGrp.DrawString(strRet6[1].ToString(),m_fontItem,Brushes.Black,tX,Y);
				tX = intRowStep + intDiv*4 + intPing/2 + intPing - Convert.ToInt32(size.Width/4);
				p_objGrp.DrawString(strRet6[2].ToString(),m_fontItem,Brushes.Black,tX,Y);
				tX = intRowStep + intDiv*4 + intPing/2 + intPing*2 - Convert.ToInt32(size.Width/4);
				p_objGrp.DrawString(strRet6[3].ToString(),m_fontItem,Brushes.Black,tX,Y);
				
				//
				
				#endregion 

				#region 画最后三列(出生一分钟评分）
				int intZiHeight = Convert.ToInt32(size.Height*1);
				int2Score = intRowStep + intDiv*4 + intPing + intPing/2 - Convert.ToInt32(size.Width/2);
				int3Score = intRowStep + intDiv*4 + intPing*2 + intPing/2 - Convert.ToInt32(size.Width/2);
				printStr = "分";
				size = p_objGrp.MeasureString(printStr,m_fontItem);
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);

				printStr = "一";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) - intZiHeight;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				printStr = "五";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) - intZiHeight;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);

				printStr = "十";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) - intZiHeight;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);


				printStr = "生";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) - intZiHeight*2;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);

				printStr = "出";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) - intZiHeight*3;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);

				printStr = "钟";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) + intZiHeight;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);

				printStr = "评";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) + intZiHeight*2;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);

				printStr = "分";				
				X = intRowStep + intDiv*4 + intPing/2 - Convert.ToInt32(size.Width/2);
				Y = inttempY - intRowHeigth*5 /2 - Convert.ToInt32(size.Height/2) + intZiHeight*3;
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,X,Y);

				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int2Score,Y);
				p_objGrp.DrawString(printStr,m_fontItem,Brushes.Black,int3Score,Y);


				#endregion 

				p_intPosY += intRowHeigth * 8 ;
			}

			private void m_mthPrintStr(int p_intY,clsInpatMedRec_Item[] p_strPrintArr,System.Drawing.Graphics p_objGrp,string[] strText)
			{
				
				int intX = 0;
				int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
				int intDiv = intLineWidth/5;
				for(int i=0;i<p_strPrintArr.Length; i++)
				{
					clsInpatMedRec_Item strTemp = p_strPrintArr[i];
					if(strTemp != null)
					{
						SizeF size = p_objGrp.MeasureString(strText[i].ToString(),m_fontItem);
						intX = m_intRecBaseX + 10 + intDiv*(i+1) + intDiv/2 - Convert.ToInt32(size.Width/2);
						p_objGrp.DrawString(strText[i].ToString()+" √",m_fontItem,Brushes.Black,intX,p_intY);
					}
					else
					{
						SizeF size2 = p_objGrp.MeasureString(strText[i].ToString(),m_fontItem);
						intX = m_intRecBaseX + 10 + intDiv*(i+1) + intDiv/2 - Convert.ToInt32(size2.Width/2);
						p_objGrp.DrawString(strText[i].ToString(),m_fontItem,Brushes.Black,intX,p_intY);
				
					}
				}
			}
			private clsInpatMedRec_Item[] m_mthPrintSubItem(string[] p_strTitleArr,string[] p_strKeyArr)
			{
				clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
				if(objConArr == null || objConArr.Length != 3 || p_strTitleArr == null)
					return null;
				//
				//				clsInpatMedRec_Item[] strConArr = new clsInpatMedRec_Item[objConArr.Length];
				//				for(int i=0;i<objConArr.Length; i++)
				//				{
				//					if(objConArr[i]!=null)
				//					if(objConArr[i].m_strItemContent != null)
				//						strConArr[i].m_strItemContent = objConArr[i].m_strItemContent;
				//					else
				//						strConArr[i].m_strItemContent = "";
				//				}				
				//				return strConArr;
				return objConArr;
			}

			private string[] m_mthPrintTextItem(string[] p_strTitleArr,string[] p_strKeyArr)
			{
				clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
				if(objConArr == null || objConArr.Length != p_strKeyArr.Length || p_strTitleArr == null)
					return null;
				
				string[] strConArr = new string[objConArr.Length];
				for(int i=0;i<objConArr.Length; i++)
				{
					if(objConArr[i]!=null)
					{
						if(objConArr[i].m_strItemContent != null)
							strConArr[i] = objConArr[i].m_strItemContent;
						else
							strConArr[i] = "";
					}
					else
						strConArr[i] = "";
				}				
				return strConArr;
		
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

		#endregion

		#region 指印与检查医师，记录日期
		/// <summary>
		///  指印与检查医师，记录日期
		/// </summary>
		private class clsPrintInPatMedDocAndDate : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
			private string[] m_strKeysArr1 = {"指导者签字"};
			private string[] m_strKeysArr2 = {"手术者签字"};
			private string[] m_strKeysArr3 = {"护婴者签字"};
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false )
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
	
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr1) != false)
							m_mthMakeText(new string[]{"        指导者:"},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
							m_mthMakeText(new string[]{"        手术者:"},m_strKeysArr2,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
							m_mthMakeText(new string[]{"        护婴者:"},m_strKeysArr3,ref strAllText,ref strXml);
					
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("医生签字：",m_objPrintContext.m_ObjModifyUserArr);
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
