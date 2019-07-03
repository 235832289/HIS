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
	///  打印产钳手术记录的摘要说明。
	/// </summary>
	public class clsIMR_ForpecsRecordPrintTool :clsInpatMedRecPrintBase
	{
		public clsIMR_ForpecsRecordPrintTool(string p_strTypeID) : base(p_strTypeID)
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("产钳手术记录",310),
																		   new clsPrintInPatForpecsRecordMain(),
																		   new clsPrintInPatMedSignName(),
                                                                           new clsPrint11(),
                                                                           new clsPrint12(),
                                                                           new clsPrint13()
																	   });			
		}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
				#region 注译
				//				p_objGrp.DrawString("分娩记录",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
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

                //p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
                //p_objGrp.DrawString("产钳手术记录",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,360,75);
			
//				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,350,110);
//				p_objGrp.DrawString("母亲住院号：",p_fntNormalText,Brushes.Black,550,110);
//				p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
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

        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#region 手术日期---术后诊断
		/// <summary>
		/// 手术日期---术后诊断
		/// </summary>
		private class clsPrintInPatForpecsRecordMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			
			private bool m_blnIsFirstPrint = true;
			private string[] m_strKeysArr1 = {"手术日期"};	
			private string[] m_strKeysArr2 = {"手术日期>>至"};
		
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
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
//						m_mthMakeText(new string[]{""姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"："},new string []{"m_objPrintInfo==null ? : m_objPrintInfo.m_strPatientName"},ref strAllText,ref strXml);
						//m_mthMakeText(new string[]{"姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","              年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；"},new string [] {"",""},ref strAllText,ref strXml);
						
						//m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
						//m_mthMakeText(new string[]{"              床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName+""},new string []{""},ref strAllText,ref strXml);
						//m_mthMakeText(new string[]{"                  住院号："+m_objPrintInfo.m_strInPatientID+""},new string []{""},ref strAllText,ref strXml);
                        
						m_strDateType = "yyyy年MM月dd日HH时mm分";
						m_mthMakeText(new string[]{"\n手术日期："},m_strKeysArr1,ref strAllText,ref strXml);
						m_strDateType = "dd日HH时mm分";
						m_mthMakeText(new string[]{"  至  $$"},m_strKeysArr2,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n术前诊断："},new string[]{"术前诊断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n手术指征："},new string[]{"手术指征"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n手术类型："},new string[]{"手术类型"},ref strAllText,ref strXml);
                        m_mthMakeCheckText(new string[] { "  ", "手术类型>>低位", "手术类型>>出口" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "其它：" }, new string[] { "手术类型>>其它" }, ref strAllText, ref strXml);
						m_mthMakeCheckText(new string []{"\n       麻醉：","麻醉>>无","麻醉>>有"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"阴部神经阻滞麻：","麻醉>>阴部神经阻滞麻>>左","麻醉>>阴部神经阻滞麻>>右"},ref strAllText,ref strXml);
                        m_mthMakeText(new string[]{"局部浸润麻药：","量："},new string[]{"麻醉>>局部浸润麻药","麻醉>>量"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       导尿：量：","ml；$$","色：","其它："},new string[]{"导尿>>量","","导尿>>色","导尿>>其它"},ref strAllText,ref strXml);
						#region 术前阴检情况
						m_mthMakeText(new string[]{"\n术前阴检情况："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       外阴："},new string[]{"术前阴检情况>>外阴"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       阴道："},new string[]{"术前阴检情况>>阴道"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       宫颈："},new string[]{"术前阴检情况>>宫颈"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       羊水："},new string[]{"术前阴检情况>>羊水"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       胎位：","先露高低","产瘤：","部位：","大小：","头逢重叠："},
							          new string[]{"术前阴检情况>>胎位","术前阴检情况>>先露高低","术前阴检情况>>产瘤","术前阴检情况>>部位","术前阴检情况>>大小","术前阴检情况>>头逢重叠"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n       骶骨弧度：","术前阴检情况>>骶骨弧度>>深弧","术前阴检情况>>骶骨弧度>>中弧","术前阴检情况>>骶骨弧度>>浅弧"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"       骶棘韧带宽度：","术前阴检情况>>骶棘韧带宽度>>大于3cm","术前阴检情况>>骶棘韧带宽度>>小于3cm"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n       坐骨棘：","术前阴检情况>>坐骨棘>>突","术前阴检情况>>坐骨棘>>不突"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"         骶尾关节：","术前阴检情况>>骶尾关节>>活动好","术前阴检情况>>骶尾关节>>欠佳","术前阴检情况>>骶尾关节>>不活动"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"         趾骨角度：","术前阴检情况>>趾骨角度>>大于90度","术前阴检情况>>趾骨角度>>小于90度"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n       胎心音：置钳前：","次/分；$$","置钳后：","次/分$$"},new string[]{"术前阴检情况>>胎心音>>置钳前","","术前阴检情况>>胎心音>>置钳后",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n回转胎头：","回转胎头>>无","回转胎头>>有","回转胎头>>徒手","回转胎头>>产钳","回转胎头>>顺时针","回转胎头>>逆时针"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","度  $$"},new string[]{"回转胎头>>度",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","回转胎头>>难","回转胎头>>易"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n产钳置入："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"先","产钳置入>>先>>左","产钳置入>>先>>右"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"扣合：","产钳置入>>扣合>>难","产钳置入>>扣合>>易"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"      产钳牵引：","次 $$"},new string[]{"产钳牵引>>次",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n钳痕位置：","钳痕位置>>正","钳痕位置>>偏"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"      软产道检查情况："},new string[]{"软产道检查情况"},ref strAllText,ref strXml);
  						#endregion 
						#region 新生婴儿情况
						m_mthMakeText(new string []{"\n新生婴儿情况："},new string [] {""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"评分1'：","评分5'："},new string[]{"新生婴儿情况>>评分1'","新生婴儿情况>>评分5'"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                            急救处理："},new string[]{"新生婴儿情况>>急救处理"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                            体重：","g；$$","身长：","cm；$$","头围：","cm；$$"},new string[]{"新生婴儿情况>>体重","","新生婴儿情况>>身长","","新生婴儿情况>>头围",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"肩围：","cm；$$","\n                            畸形："," 死亡："},new string[]{"新生婴儿情况>>肩围","","新生婴儿情况>>畸形","新生婴儿情况>>死亡"},ref strAllText,ref strXml);
						m_mthMakeText(new string []{"\n附注："},new string [] {"附注"},ref strAllText,ref strXml);
//						m_mthMakeText(new string []{"\n术后诊断："},new string [] {"术后诊断"},ref strAllText,ref strXml);
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
		
		/// <summary>
		/// 修正诊断&初步诊断（诊断）
		/// </summary>
		private class clsPrintInPatMedSignName : clsIMR_PrintLineBase
		{
			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			private Font m_fontContent = new Font("",10);
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"术后诊断"});
				if(objItemContent == null || objItemContent[0] == null)
				{
					//m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				}
				
				if(m_blnIsFirstPrint)
				{
					if (objItemContent[0] != null)
						if(objItemContent[0].m_strItemContent != null)
							p_objGrp.DrawString("术后诊断：",m_fontContent,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
						{
							m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
							m_mthAddSign2("术后诊断：",m_objPrintContext1.m_ObjModifyUserArr);
						}
					m_blnIsFirstPrint = false;
				}

				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
							m_objPrintContext1.m_mthPrintLine(640,m_intRecBaseX+40,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_intPosY += 20;
					//m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
				}
			}

            //private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            //{
            //    if(m_hasItems == null)
            //        return;
            //    p_intPosY += 20;
            //    p_objGrp.DrawString("手术者："+(objItemContent[1]==null ? "" : (objItemContent[1].m_strItemContent == null ? "":objItemContent[1].m_strItemContent)) ,m_fontItemMidHead,Brushes.Black,m_intRecBaseX+20,p_intPosY);
            //    p_objGrp.DrawString("助手："+ (objItemContent[2] == null ? "" :(objItemContent[2].m_strItemContent == null ? "":objItemContent[2].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
            //    p_objGrp.DrawString("记录者："+ (objItemContent[3] == null ? "" :(objItemContent[3].m_strItemContent == null ? "":objItemContent[3].m_strItemContent)),m_fontItemMidHead,Brushes.Black,m_intRecBaseX+530,p_intPosY);
				
            //}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}


        #region 打印签名
        /// <summary>
        ///手术者 签名
        /// </summary>
        private class clsPrint11 : clsIMR_PrintLineBase
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("手术者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        /// <summary>
        ///助手 签名
        /// </summary>
        private class clsPrint12 : clsIMR_PrintLineBase
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvhelper")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("助手：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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



        /// <summary>
        ///记录者 签名
        /// </summary>
        private class clsPrint13 : clsIMR_PrintLineBase
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvAnaesthetist")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("记录者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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


        #endregion



	}
}
