using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Collections.Generic;

namespace iCare
{
	/// <summary>
	/// frmIMR_CesareanRecordPrintTool 打印剖宫产记录的摘要说明。
	/// </summary>
	public class clsIMR_CesareanRecordPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_CesareanRecordPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo("剖宫产手术记录",300),
																		   new clsPrintInPatCesareanRecordMain(),
//																		   new clsPrintInPatApgar(),
																	    // new  clsPrintInPatMedDocAndDate()
				                                                          // new clsPrintInPatMedRecDiagnostic()
                                                                          // new clsPrintInPatMedDocAndDate()
                                                                          new clsPrint10()
																	   });			
		}
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		
		#region 打印实现

		#region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            public clsPrintPatientFixInfo() { }
            public clsPrintPatientFixInfo(string p_strChildTitleName, int p_intChildTitleNameOffSetX)
            {
                m_strChildTitleName = p_strChildTitleName;
                m_intChildTitleNameOffSetX = p_intChildTitleNameOffSetX;

            }
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strBirthPlace = "";
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("出生地"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["出生地"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strBirthPlace = objInpatItem.m_strItemContent;
                        }
                    }
                    else m_strBirthPlace = m_objPrintInfo.m_strHomeplace;
                }
                else m_strBirthPlace = m_objPrintInfo.m_strHomeplace;
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("出生地：" + m_strBirthPlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH:mm"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }

                p_intPosY += 20;
                p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmRecordDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("病史陈述人：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

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

		#region 手术日期---术前阴检情况
		/// <summary>
		/// 手术日期---术前阴检情况
		/// </summary>
		private class clsPrintInPatCesareanRecordMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
			private string[] m_strKeysArr1 = {"手术日期","手术日期>>至"};
			
						
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
                    string strIsTime;
                    string strTime="#";
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
                        //m_mthMakeText(new string[]{"姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","              年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},new string [] {"",""},ref strAllText,ref strXml);
						
						//m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"              床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName+""},new string []{""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"                  住院号："+m_objPrintInfo.m_strInPatientID+""},new string []{""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"姓名："},new string []{"m_objPrintInfo.m_strPatientName"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"   床号："},new string []{"m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"   住院号："},new string []{"m_objPrintInfo.m_strInPatientID"},ref strAllText,ref strXml);
                        string strOperationDate = "\n手术日期：";
                        if (m_hasItems.ContainsKey("手术日期"))
                        {
                            strOperationDate += ((clsInpatMedRec_Item)m_hasItems["手术日期"]).m_strItemContent;
                        }
                        if (m_hasItems.ContainsKey("手术日期>>至"))
                        {
                            strOperationDate += " 至 "+((clsInpatMedRec_Item)m_hasItems["手术日期>>至"]).m_strItemContent;
                        }
                        strOperationDate += "$$";
                        m_mthMakeText(new string[] { strOperationDate }, new string[]{""}, ref strAllText, ref strXml);
						
						m_mthMakeText(new string[]{"\n术前诊断：","\n手术指征：","\n手术名称：","\n术后诊断："},new string[]{"术前诊断","手术指征","手术名称","术后诊断"},ref strAllText,ref strXml);


						m_mthMakeText(new string[]{"\n手术者："," 第一助手："," 第二助手："," 第三助手：","\n麻醉方法：","麻药（量）：","效果：","麻醉师：","器械士：","\n切口部位及方式：","切口长度：","腹壁脂肪层厚","cm； 腹膜外：$$","  腹膜分离"},
							new string[]{"手术者","第一助手","第二助手","第三助手","麻醉方法","麻药（量）","效果","麻醉师","器械士","切口部位及方式","切口长度","腹壁脂肪层厚","",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","腹膜分离>>困难","腹膜分离>>顺利"},ref strAllText,ref strXml);
                        
						m_mthMakeText(new string[]{"\n腹腔情况："},new string[]{""},ref strAllText,ref strXml);
                        m_mthMakeCheckText(new string []{"","腹腔情况>>有腹水","腹腔情况>>无腹水"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"腹水量：$$","色","质","粘连情况：","\n子宫情况：","宫体下段静脉曲张：","颜色：","右偏：","   下推膀胱："},
							new string[]{"腹腔情况>>腹水量","腹腔情况>>色","腹腔情况>>质","腹腔情况>>粘连情况","","子宫情况>>宫体下段静脉曲张","子宫情况>>颜色","子宫情况>>右偏",""},ref strAllText,ref strXml);
											
						m_mthMakeCheckText(new string []{"","子宫情况>>下推膀胱>>困难","子宫情况>>下推膀胱>>顺利"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n子宫切口："},new string[]{""},ref strAllText,ref strXml);
                        m_mthMakeCheckText(new string []{"","子宫切口>>宫体","子宫切口>>下段","子宫切口>>剪","子宫切口>>撕"},ref strAllText,ref strXml);
                        m_mthMakeText(new string[]{"$$"," 形长：","#cm"," 厚：","#cm"},//," 撕裂"," 位置"," 长度","cm$$","\n切开子宫所见：","胎方位"," 切口下见："," 羊水量","ml; $$"," 性状","\n手术娩出胎儿的过程："," 娩出胎儿","部$$"},
                                      new string[] { "子宫切口>>1", "子宫切口>>形长", "子宫切口>>形长", "子宫切口>>厚", "子宫切口>>厚" }, ref strAllText, ref strXml);//,"子宫切口>>撕裂","子宫切口>>位置","子宫切口>>长度","","","切开子宫所见>>胎方位","切开子宫所见>>切口下见","切开子宫所见>>羊水量","","切开子宫所见>>性状","","手术娩出胎儿的过程>>娩出胎儿",""},ref strAllText,ref strXml);

                        m_mthMakeCheckText(new string[] { "撕裂：", "撕裂>>有", "撕裂>>无" }, ref strAllText, ref strXml);
                        //"$$", " 形长", "cm; $$", "厚", "cm; $$", " 撕裂",
                        m_mthMakeText(new string[] {  " 位置", " 长度", "#cm", "\n切开子宫所见：", "胎方位", " 切口下见：", " 羊水量", "ml； $$", " 性状", "\n手术娩出胎儿的过程：", " 娩出胎儿", "部（$$" },
                                     new string[] { "子宫切口>>位置", "子宫切口>>长度", "子宫切口>>长度", "", "切开子宫所见>>胎方位", "切开子宫所见>>切口下见", "切开子宫所见>>羊水量", "", "切开子宫所见>>性状", "", "手术娩出胎儿的过程>>娩出胎儿", "" }, ref strAllText, ref strXml);
                        //"子宫切口>>1", "子宫切口>>形长", "", "子宫切口>>厚", "", "子宫切口>>撕裂", 

                       m_mthMakeCheckText(new string []{"","娩出胎儿>>易","娩出胎儿>>难"},ref strAllText,ref strXml);

                       m_mthMakeText(new string[] {")"},
                                   new string[] { "" }, ref strAllText, ref strXml);

                       if (m_hasItems.ContainsKey("手术娩出胎儿的过程>>方法>>产钳") || m_hasItems.ContainsKey("手术娩出胎儿的过程>>方法>>胎吸"))
                       {
                        m_mthMakeCheckText(new string[] { "方法：", "手术娩出胎儿的过程>>方法>>产钳", "手术娩出胎儿的过程>>方法>>胎吸" }, ref strAllText, ref strXml);
                       }
                       if (m_hasItems.ContainsKey("手术娩出胎儿的过程>>手法>>推压宫底") || m_hasItems.ContainsKey("手术娩出胎儿的过程>>手法>>阴道推先露") || m_hasItems.ContainsKey("手术娩出胎儿的过程>>手法>>臀牵引"))
                       {
                       m_mthMakeCheckText(new string[] { "手法：", "手术娩出胎儿的过程>>手法>>推压宫底", "手术娩出胎儿的过程>>手法>>阴道推先露", "手术娩出胎儿的过程>>手法>>臀牵引" }, ref strAllText, ref strXml);
                       }
						m_mthMakeText(new string[]{"\n胎盘脐带情况："},new string[]{""},ref strAllText,ref strXml);
                        m_mthMakeCheckText(new string []{"\n              胎盘：","胎盘脐带情况胎盘>>自娩","胎盘脐带情况胎盘>>人工分离","胎盘脐带情况胎盘>>人工分离>>完整","胎盘脐带情况胎盘>>人工分离>>不完整","胎盘脐带情况胎盘>>黄染"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"   胎膜：","胎盘脐带情况>>胎膜>>完整","胎盘脐带情况>>胎膜>>不完整"},ref strAllText,ref strXml);
                        m_mthMakeText(new string[]{"体积：","重量","g; $$","其它","\n              脐带长：","#cm；"},
                            new string[] { "胎盘脐带情况>>胎膜>>体积", "胎盘脐带情况>>胎膜>>重量", "", "胎盘脐带情况>>胎膜>>其它：", "胎盘脐带情况>>脐带长", "胎盘脐带情况>>脐带长" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "胎盘脐带情况>>脐带>>绕颈", "胎盘脐带情况>>脐带>>绕手", "胎盘脐带情况>>脐带>>绕腿" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$", "#周 " }, new string[] { "胎盘脐带情况>>脐带>>周", "胎盘脐带情况>>脐带>>周" }, ref strAllText, ref strXml);
						m_mthMakeCheckText(new string []{"","胎盘脐带情况>>脐带>>真结","胎盘脐带情况>>脐带>>假结","胎盘脐带情况>>脐带>>紧","胎盘脐带情况>>脐带>>松"},ref strAllText,ref strXml);
                        m_mthMakeText(new string[] { "扭转：", "周；$$", "其它：" }, new string[] { "胎盘脐带情况>>脐带>>扭转>>周", "", "胎盘脐带情况>>脐带>>其它" }, ref strAllText, ref strXml);
                       
						//m_mthMakeCheckText(new string []{"\n新生婴儿情况：","新生婴儿情况>>男","新生婴儿情况>>女"},ref strAllText,ref strXml);
                        m_mthMakeText(new string[] { "\n新生婴儿情况：","男婴$$","#个$$"," 女婴$$","#个$$","Apgar评分1：'", "5'：", "体重：", "#g； " },
                            new string[] { "", "新生婴儿情况>>男婴个数", "新生婴儿情况>>男婴个数", "新生婴儿情况>>女婴个数", "新生婴儿情况>>女婴个数", "新生婴儿情况>>评分1' ", "新生婴儿情况>>5' ", "新生婴儿情况>>体重", "新生婴儿情况>>体重" }, ref strAllText, ref strXml);
                        
                        if (m_hasItems.ContainsKey("急救>>吸痰") || m_hasItems.ContainsKey("急救>>插管") || m_hasItems.ContainsKey("急救>>给氧"))
                        {
                            m_mthMakeCheckText(new string[] { "  急救：", "急救>>吸痰", "急救>>插管", "急救>>给氧" }, ref strAllText, ref strXml);
                        }
                        
                        if (m_hasItems.ContainsKey("新生婴儿情况>>是否转儿科时间"))
                        {
                            //是否选择转儿科时间
                            strIsTime = ((clsInpatMedRec_Item)m_hasItems["新生婴儿情况>>是否转儿科时间"]).m_strItemContent;
                            //如果不选择转儿科时间，则不打印转儿科时间
                            if (strIsTime == "True")
                                strTime = "转儿科时间：";
                        }

                        base.m_strDateType = "yyyy-MM-dd HH:mm:ss";
                        m_mthMakeText(new string[] { strTime, "\n子宫壁缝合：", "分", "层；用$$", "号$$", "线$$", "缝合$$", "连续； $$", "褥式:", "\n缝合膀胱腹膜反折：" },
							new string[]{"新生婴儿情况>>转儿科时间","","子宫壁缝合>>层","子宫壁缝合>>号","子宫壁缝合>>线","子宫壁缝合>>缝合","子宫壁缝合>>连续","","子宫壁缝合>>褥式","缝合膀胱腹膜反折"},ref strAllText,ref strXml);
                                               
						m_mthMakeCheckText(new string []{"\n  子宫收缩：","子宫收缩>>好","子宫收缩>>欠佳","子宫收缩>>差"},ref strAllText,ref strXml);
                        
						m_mthMakeText(new string[]{"    术中用药：","量:","\n腹腔探查：","子宫：","\n                      附件：","\n附加手术：","\n腹壁缝合：","腹壁缝层用：","号；$$","线 $$"," $$"},
							new string[]{"术中用药","术中用药>>量","","腹腔探查>>子宫","腹腔探查>>附件","附加手术","","腹壁缝合>>腹壁缝层>>号","腹壁缝合>>腹壁缝层>>线","腹壁缝合>>腹壁缝层>>缝合",""},ref strAllText,ref strXml);

						#region 腹壁缝合
						m_mthMakeCheckText(new string []{"  缝合  ","腹壁缝合>>腹壁缝层>>连续","腹壁缝合>>腹壁缝层>>间断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     腹直肌筋膜用：","号；$$","线 $$"," $$"},new string[]{"腹壁缝合>>腹直肌筋膜>>号","腹壁缝合>>腹直肌筋膜>>线","腹壁缝合>>腹直肌筋膜>>缝合",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"  缝合  ","腹壁缝合>>腹直肌筋膜>>连续","腹壁缝合>>腹直肌筋膜>>间断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                     脂肪层用：","号；$$","线 $$"," 缝合$$","针；$$","\n                     皮肤用：","号；$$","线 $$"," $$"},
                            new string[] { "腹壁缝合>>脂肪层>>号", "腹壁缝合>>脂肪层>>线", "腹壁缝合>>脂肪层>>缝合", "腹壁缝合>>脂肪层>>针", "", "皮肤>>号", "皮肤>>线", "皮肤>>缝合", "" }, ref strAllText, ref strXml);
						m_mthMakeCheckText(new string []{"  缝合  ","腹壁缝合>>皮肤>>埋缝","腹壁缝合>>皮肤>>间断"},ref strAllText,ref strXml);
						#endregion 腹壁缝合
						#region 手术时产妇情况
						m_mthMakeText(new string[]{"\n手术时产妇情况："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","手术时产妇情况>>安静","手术时产妇情况>>烦躁","手术时产妇情况>>呼叫","手术时产妇情况>>稳定","手术时产妇情况>>休克"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","\n估计手术时总失血量：","ml:$$","\n术时输液量:","ml；$$","  输血成份：","单位","  输血量:","ml；$$"," 供氧：","小时；$$","  术后血压：","mmHg；$$","\n其他用药："," \n送病理标本名称：","  术中尿量","ml；$$","  色","\n清点器械敷料情况：","  其他情况"},
							new string[]{"手术时产妇情况>>休克情况","估计手术时总失学量","","术时输液量","","输血成份","","输血量","","供氧","","术后血压","","其他用药","送病理标本名称","术中尿量","","术中尿>>色","清点器械敷料情况","其他情况"},ref strAllText,ref strXml);

						#endregion 手术时产妇情况

                        
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
		#region 指印与检查医师，记录日期
//		/// <summary>
//		///  指印与检查医师，记录日期
//		/// </summary> 
        //private class clsPrintInPatMedDocAndDate : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private bool blnNextPage = true;
        //    private string[] m_strKeysArr1 = { "签名" };
        //    //private string[] m_strKeysArr2 = {"记录日期"};
			
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_objContent == null || m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        //if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false )

        //        if (m_blnHavePrintInfo(m_strKeysArr1) == false)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        //				if(blnNextPage)
        //        //				{
        //        //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
        //        //					m_blnHaveMoreLine = true;
        //        //					blnNextPage = false;
        //        //					p_intPosY += 1500;
        //        //					return;
        //        //				}
        //        if (m_blnIsFirstPrint)
        //        {
        //            //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
        //            //					p_intPosY += 20;
        //            //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
        //            //					p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if (m_objContent != null)
        //            {
        //                if (m_blnHavePrintInfo(m_strKeysArr1) != false)
        //                    m_mthMakeText(new string[] { "签名：" }, m_strKeysArr1, ref strAllText, ref strXml);
        //                //						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
        //                //							m_mthMakeText(new string[]{"\n记录日期"},m_strKeysArr2,ref strAllText,ref strXml);

        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
        //            //					m_mthAddSign2("医生签字：",m_objPrintContext.m_ObjModifyUserArr);

        //            m_mthAddSign2("签名：",m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
        //            p_intPosY += 20;
        //        }
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_blnHaveMoreLine = true;
        //        }
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();
        //        m_blnHaveMoreLine = true;
        //        m_blnIsFirstPrint = true;
        //    }
        //}
		#endregion
		#region
		/// <summary>
		/// 修正诊断&初步诊断（诊断）
		/// </summary>
		private class clsPrintInPatMedRecDiagnostic : clsIMR_PrintLineBase
		{
			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"修正诊断","初步诊断","签名","签名"});
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
							p_objGrp.DrawString("修正诊断：",m_fontItemMidHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							p_objGrp.DrawString("初步诊断：",m_fontItemMidHead,Brushes.Black,m_intRecBaseX+380,p_intPosY);
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
							m_mthAddSign2("初步诊断：",m_objPrintContext2.m_ObjModifyUserArr);
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
				//p_objGrp.DrawString("签名："+(objItemContent[2]==null ? "" : (objItemContent[2].m_strItemContent == null ? "":objItemContent[2].m_strItemContent)) ,m_fontItemMidHead,Brushes.Black,m_intRecBaseX+20,p_intPosY);
				p_objGrp.DrawString("签名："+ (objItemContent[3] == null ? "" :(objItemContent[3].m_strItemContent == null ? "":objItemContent[3].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+450,p_intPosY);
				
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


        /// <summary>
        ///  术者签名
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
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
                    List<string> lstSignName = new List<string>();
                    List<string> lstSignRank = new List<string>();

                    if (m_objContent.objSignerArr != null)
                    {
                        for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                        {
                            if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                            {
                                strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                                lstSignRank.Add(m_objContent.objSignerArr[i].objEmployee.m_strTechnicalRank);
                                lstSignName.Add(m_objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                            }
                                
                        }
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        int x = m_intRecBaseX + 100;
                        
                        //string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        for(int sI = 0;sI<lstSignName.Count;sI++)
                        {
                            Image imgEmpSig = ImageSignature.GetEmpSigImage(lstSignName[sI]);

                            if (imgEmpSig != null)
                            {
                                //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 268);
                                p_objGrp.DrawString(lstSignRank[sI], p_fntNormalText, Brushes.Black, x, p_intPosY);
                                x +=  90;
                                p_objGrp.DrawImage(imgEmpSig, x, p_intPosY -5, 70, 30);
                                x +=  90;
                            }
                            else
                            {
                                p_objGrp.DrawString(lstSignRank[sI] + "  " + lstSignName[sI], p_fntNormalText, Brushes.Black, x, p_intPosY);
                                x += 180;
                            }
                        }

                        //m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                    p_intPosY += 20;
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
    
		#endregion
	}
}
