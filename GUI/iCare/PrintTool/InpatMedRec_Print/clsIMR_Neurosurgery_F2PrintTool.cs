using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 神经外科入院纪录---佛山 打印工具类
    /// 盛光怀 2008/1/28
	/// </summary>
	public class clsIMR_Neurosurgery_F2PrintTool : clsInpatMedRecPrintBase
	{
        public clsIMR_Neurosurgery_F2PrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
		}
        /// <summary>
        /// 
        /// </summary>
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("神经外科住院病历",206),
										  new clsPrintInPatMedRecCaseMain(),
										  new clsPrintInPatMedRecCaseCurrent(),
										  new clsPrintInPatMedRecBeforetimeStatus(),
                                          //new clsPrintInPatMedRecIndividual(),
                                          //new clsPrintInPatMedRecFamily(),
										  new clsPrintInPatMedRecMedical(),
										  new clsPrintInPatMedRecGeneralNerves(),
										 // new clsPrintInPatMedRecHeadNerves(),
										  new clsPrintInPatMedRecPic4(false),
										  new clsPrintInPatMedRecReflect(),
										  new clsPrintInPatMedRecPic4(false),
				                          new clsPrintInPatMedRecPlant(),
                                          new clsPrintInSpCheck(),
										  new clsPrintInPatMedRecPic4(false),
				                        //  new clsPrintInPatMedRecLab(),
										  new clsPrintInPatMedRecPic4(false),
				                          new clsPrintInPatMedRecDiagnostic(),
                                          new clsPrintInSing(),
										  new clsPrintInPatMedRecPic4(true),
                                          //new clsPrintInPatMedRecLastDiag(),
                                          //new clsPrintInSing2()
			});			
		}

		#region 打印实现
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        p_objGrp.DrawString("神经内科住院病历",m_fotItemHead,Brushes.Black,m_intRecBaseX+290,p_intPosY - 10);
		
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
        //        p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
		
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
		
        //        p_intPosY += 20;
        //        if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //        {
        //            p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
        //        }				
			
        //        m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
        //        int intRealHeight;
        //        Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
        //        m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
								
        //        p_intPosY += 30;
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}




		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
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
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;

					p_objGrp.DrawString("主诉：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,false);
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
		private class clsPrintInPatMedRecCaseCurrent : clsIMR_PrintLineBase
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
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("现病史：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,false);
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
		/// 过去史 
		/// </summary>
        private class clsPrintInPatMedRecBeforetimeStatus : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool[] m_blnIsPrint = new Boolean[] { true, true, true, true, true };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                string strPrintText = "";
                #region Print
                if (m_blnIsPrint[0])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("过去史:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    strPrintText = "      ";
                    if (m_hasItemDetail.Contains("过去史>>传染病或慢性病史"))
                        strPrintText += "传染病或慢性病史" + m_hasItemDetail["过去史>>传染病或慢性病史"] + ",";
                    if (m_hasItemDetail.Contains("过去史>>预防接种"))
                        strPrintText += "预防接种" + m_hasItemDetail["过去史>>预防接种"] + ",";
                    if (m_hasItemDetail.Contains("过去史>>药物或食物过敏史"))
                        strPrintText += "药物或食物过敏史" + m_hasItemDetail["过去史>>药物或食物过敏史"] + ",";
                    if (m_hasItemDetail.Contains("过去史>>外伤与手术史"))
                        strPrintText += "外伤与手术史" + m_hasItemDetail["过去史>>外伤与手术史"] + ",";
                    if (m_hasItemDetail.Contains("过去史>>输血及血制品史"))
                        strPrintText += "输血及血制品史" + m_hasItemDetail["过去史>>输血及血制品史"] + ",";
                    if (m_hasItemDetail.Contains("过去史>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["过去史>>其他"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[0] = false;
                }
                if (m_blnIsPrint[1])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("个人史:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("居住地地方病情况"))
                        strPrintText += "居住地地方病情况" + m_hasItemDetail["居住地地方病情况"] + ",";
                    //else if (m_hasItemDetail.Contains("脑膜刺激征>>无颈强直"))
                    //    strPrintText += "无颈强直,";
                    if (m_hasItemDetail.Contains("不良嗜好"))
                        strPrintText += "不良嗜好" + m_hasItemDetail["不良嗜好"] + ",";
                    if (m_hasItemDetail.Contains("疫水接触史"))
                        strPrintText += "疫水接触史" + m_hasItemDetail["疫水接触史"] + ",";
                    if (m_hasItemDetail.Contains("食鱼生史"))
                        strPrintText += "食鱼生史" + m_hasItemDetail["食鱼生史"] + ",";
                    if (m_hasItemDetail.Contains("个人史>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["个人史>>其他"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[1] = false;
                }

                if (m_blnIsPrint[2])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("孕育史:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("结婚年龄"))
                        strPrintText += "" + m_hasItemDetail["结婚年龄"] + ",";
                    if (m_hasItemDetail.Contains("配偶情况"))
                        strPrintText += "配偶情况" + m_hasItemDetail["配偶情况"] + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[2] = false;
                }

                if (m_blnIsPrint[3])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("月经史:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("月经史"))
                        strPrintText += "" + m_hasItemDetail["月经史"] + "。";
                    //if (m_hasItemDetail.Contains("配偶情况"))
                    //    strPrintText += "配偶情况" + m_hasItemDetail["配偶情况"] + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[3] = false;
                }

                if (m_blnIsPrint[4])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("家族史:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("父"))
                        strPrintText += "父" + m_hasItemDetail["父"] + ",";
                    if (m_hasItemDetail.Contains("母"))
                        strPrintText += "母" + m_hasItemDetail["母"] + ",";
                    if (m_hasItemDetail.Contains("兄弟姐妹"))
                        strPrintText += "兄弟姐妹" + m_hasItemDetail["兄弟姐妹"] + ",";
                    if (m_hasItemDetail.Contains("子女及其他"))
                        strPrintText += "子女及其他" + m_hasItemDetail["子女及其他"] + "。";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);


                    m_blnIsPrint[4] = false;
                }
                #endregion Print
                m_blnHaveMoreLine = false;

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsPrint = new Boolean[] { true, true, true, true, true };
            }
        }

        #region 
        /// <summary>
		/// 个人生活史(包括月经史、生育史)
		/// </summary>
        //private class clsPrintInPatMedRecIndividual : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private int m_intTimes = 0;
        //    private clsInpatMedRec_Item objItemContent = null;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if(m_hasItems != null)
        //            if (m_hasItems.Contains("个人史"))
        //                objItemContent = m_hasItems["个人史"] as clsInpatMedRec_Item;
        //        if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if(m_blnIsFirstPrint)
        //        {
        //            p_objGrp.DrawString("个人史：", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_intPosY += 20;
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,false);
        //            m_mthAddSign2("个人史：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;	
        //        }

        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
        //            p_intPosY += 20;
        //            m_intTimes++;
        //        }
        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();
        //        m_blnIsFirstPrint = true;
        //        m_blnHaveMoreLine = true;
        //        m_intTimes = 0;
        //    }
        //}
		/// <summary>
		/// 家族史
		/// </summary>
        //private class clsPrintInPatMedRecFamily : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private int m_intTimes = 0;
        //    private clsInpatMedRec_Item objItemContent = null;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if(m_hasItems != null)
        //            if(m_hasItems.Contains("家族史"))
        //                objItemContent = m_hasItems["家族史"] as clsInpatMedRec_Item;
        //        if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;

        //            return;
        //        }

        //        if(m_blnIsFirstPrint)
        //        {
        //            p_objGrp.DrawString("家族史：",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //            p_intPosY += 20;
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,false);
        //            m_mthAddSign2("家族史：",m_objPrintContext.m_ObjModifyUserArr);


        //            m_blnIsFirstPrint = false;					
        //        }

        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
        //            p_intPosY += 20;
        //            m_intTimes++;
        //        }

        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();
        //        m_blnIsFirstPrint = true;
        //        m_blnHaveMoreLine = true;
        //        m_intTimes = 0;
        //    }
        //}
        #endregion 
        /// <summary>
		/// 体格检查
		/// </summary>
		private class clsPrintInPatMedRecMedical : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true};
			private int m_intTimes = 0;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
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
					p_objGrp.DrawString("体温       脉搏            呼吸               血压:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>T"))
						p_objGrp.DrawString(m_hasItemDetail["体格检查>>一般情况>>T"]+"℃",p_fntNormalText,Brushes.Black,m_intRecBaseX+45,p_intPosY);
					if(m_hasItemDetail.Contains("体格检查>>一般情况>>P"))
						p_objGrp.DrawString(m_hasItemDetail["体格检查>>一般情况>>P"]+"次/分",p_fntNormalText,Brushes.Black,m_intRecBaseX+130,p_intPosY);
					if(m_hasItemDetail.Contains("体格检查>>一般情况>>R"))
						p_objGrp.DrawString(m_hasItemDetail["体格检查>>一般情况>>R"]+"次/分",p_fntNormalText,Brushes.Black,m_intRecBaseX+255,p_intPosY);
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>BP右S"))
                        strPrintText += "" + m_hasItemDetail["体格检查>>一般情况>>BP右S"] + "/";
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>BP右A"))
                        strPrintText += m_hasItemDetail["体格检查>>一般情况>>BP右A"] + "mmHg";
                    //if(m_hasItemDetail.Contains("体格检查>>一般情况>>BP左S"))
                    //    strPrintText += ",左"+m_hasItemDetail["体格检查>>一般情况>>BP左S"]+"/";
                    //if(m_hasItemDetail.Contains("体格检查>>一般情况>>BP左A"))
                    //    strPrintText += m_hasItemDetail["体格检查>>一般情况>>BP左A"]+"mmHg ；";
					p_objGrp.DrawString(strPrintText,p_fntNormalText,Brushes.Black,m_intRecBaseX+410,p_intPosY);
					
					p_intPosY += 20;
					strPrintText = "        ";
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>BP左A"))
                        strPrintText += "一般情况" + m_hasItemDetail["体格检查>>一般情况>>BP左A"] + ",";
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>发育"))
                        strPrintText += "发育" + m_hasItemDetail["体格检查>>一般情况>>发育"] + ",";
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>营养"))
                        strPrintText += "营养" + m_hasItemDetail["体格检查>>一般情况>>营养"] + ",";
                    if (m_hasItemDetail.Contains("体格检查>>一般情况>>面容"))
                        strPrintText += "面容" + m_hasItemDetail["体格检查>>一般情况>>面容"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
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
					p_objGrp.DrawString("皮肤:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					strPrintText = "      ";
                    if (m_hasItemDetail.Contains("血管痣"))
                        strPrintText += "血管痣" + m_hasItemDetail["血管痣"] + ",";
                    if (m_hasItemDetail.Contains("啡斑"))
                        strPrintText += "啡斑" + m_hasItemDetail["啡斑"] + ",";
                    if (m_hasItemDetail.Contains("皮下结节"))
                        strPrintText += "皮下结节" + m_hasItemDetail["皮下结节"] + ",";
                    if (m_hasItemDetail.Contains("黄染"))
                        strPrintText += "黄染" + m_hasItemDetail["黄染"] + ",";
                    if (m_hasItemDetail.Contains("脱水症"))
                        strPrintText += "脱水症" + m_hasItemDetail["脱水症"] + ",";
                    if (m_hasItemDetail.Contains("疤痕"))
                        strPrintText += "疤痕" + m_hasItemDetail["疤痕"] + ",";
                    if (m_hasItemDetail.Contains("毛发"))
                        strPrintText += "毛发" + m_hasItemDetail["毛发"] + ",";
                    if (m_hasItemDetail.Contains("皮肤>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["皮肤>>其他"] + ",";
                    if (m_hasItemDetail.Contains("淋巴结"))
                        strPrintText += "淋巴结" + m_hasItemDetail["淋巴结"] + ",";
                    if (m_hasItemDetail.Contains("五官"))
                        strPrintText += "五官" + m_hasItemDetail["五官"] + ",";
                    if (m_hasItemDetail.Contains("肺脏"))
                        strPrintText += "肺脏" + m_hasItemDetail["肺脏"] + ",";
                    if (m_hasItemDetail.Contains("心脏"))
                        strPrintText += "心脏" + m_hasItemDetail["心脏"] + ",";
                    if (m_hasItemDetail.Contains("腹腔"))
                        strPrintText += "腹腔" + m_hasItemDetail["腹腔"] + ",";
                    if (m_hasItemDetail.Contains("脊椎"))
                        strPrintText += "脊椎" + m_hasItemDetail["脊椎"] + ",";
                    if (m_hasItemDetail.Contains("四肢"))
                        strPrintText += "四肢" + m_hasItemDetail["四肢"] + ",";
                    if (m_hasItemDetail.Contains("性征发育"))
                        strPrintText += "性征发育" + m_hasItemDetail["性征发育"] + ",";
                    if (m_hasItemDetail.Contains("体格检查>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["体格检查>>其他"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
                    //p_objGrp.DrawString("浅表淋巴结:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[1] = false;
				}
				
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("检查合作情况:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "           ";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>检查合作情况"))
                        strPrintText += "检查合作情况" + m_hasItemDetail["神经系统检查>>一般情况>>检查合作情况"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>神志"))
                        strPrintText += "神志" + m_hasItemDetail["神经系统检查>>神志"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>情感反应"))
                        strPrintText += "情感反应" + m_hasItemDetail["神经系统检查>>一般情况>>情感反应"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>定向力"))
                        strPrintText += "定向力" + m_hasItemDetail["神经系统检查>>一般情况>>定向力"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>计算力"))
                        strPrintText += "计算力" + m_hasItemDetail["神经系统检查>>一般情况>>计算力"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>记忆力"))
                        strPrintText += "记忆力" + m_hasItemDetail["神经系统检查>>一般情况>>记忆力"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>幻觉"))
                        strPrintText += "幻觉" + m_hasItemDetail["神经系统检查>>一般情况>>幻觉"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>一般情况>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["神经系统检查>>一般情况>>其他"] + ",";                   
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    //p_objGrp.DrawString("颈部:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText,"     "+ m_hasItemDetail["体格检查>>颈部"]+"。");
					
					m_blnIsPrint[2] = false;
				}
				
				if(m_blnIsPrint[3])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("语言:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "     ";
                    if (m_hasItemDetail.Contains("神经系统检查>>语言"))
                        strPrintText += "语言" + m_hasItemDetail["神经系统检查>>语言"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>小脑语言"))
                        strPrintText += "小脑语言" + m_hasItemDetail["神经系统检查>>小脑语言"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>语言其他"))
                        strPrintText += "其他" + m_hasItemDetail["神经系统检查>>语言其他"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    p_objGrp.DrawString("头颅:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "       ";
                    if (m_hasItemDetail.Contains("神经系统检查>>头颅"))
                        strPrintText += "头颅" + m_hasItemDetail["神经系统检查>>头颅"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>头皮异常"))
                        strPrintText += "头皮异常" + m_hasItemDetail["神经系统检查>>头皮异常"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>破壶音"))
                        strPrintText += "破壶音" + m_hasItemDetail["神经系统检查>>破壶音"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>头颅强迫头位"))
                        strPrintText += "强迫头位" + m_hasItemDetail["神经系统检查>>头颅强迫头位"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>头皮听诊"))
                        strPrintText += "听诊" + m_hasItemDetail["神经系统检查>>头皮听诊"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>颈抵抗"))
                        strPrintText += "脑膜刺激征;颈抵抗" + m_hasItemDetail["神经系统检查>>颈抵抗"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>Kerning征"))
                        strPrintText += "Kerning征" + m_hasItemDetail["神经系统检查>>Kerning征"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[3] = false;
                }

                #region
                //if(m_blnIsPrint[4])
                //{
                //    if(m_blnCheckBottom(ref p_intPosY,50,p_intPosY))
                //    {
                //        m_blnHaveMoreLine = true;
                //        return;
                //    }
                //    p_objGrp.DrawString("心脏:",m_fotHead,Brushes.Black,m_intRecBaseX+30,p_intPosY);
                //    strPrintText = "      ";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>心前区"))
                //        strPrintText += "心前区"+m_hasItemDetail["体格检查>>胸部>>心前区"]+",";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>心尖搏动点"))
                //        strPrintText += "心尖搏动点"+m_hasItemDetail["体格检查>>胸部>>心尖搏动点"]+",";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>心相对浊音界"))
                //        strPrintText += "心相对浊音界"+m_hasItemDetail["体格检查>>胸部>>心相对浊音界"]+",";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>心率"))
                //        strPrintText += "心率"+m_hasItemDetail["体格检查>>胸部>>心率"]+"次/分,";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>心率(说明)"))
                //        strPrintText += ""+m_hasItemDetail["体格检查>>胸部>>心率(说明)"]+",";
                //    if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                //    p_objGrp.DrawString("血管:",m_fotHead,Brushes.Black,m_intRecBaseX+30,p_intPosY);
                //    strPrintText = "      ";
                //    if(m_hasItemDetail.Contains("体格检查>>胸部>>血管"))
                //        strPrintText += ""+m_hasItemDetail["体格检查>>胸部>>血管"]+"。";
                //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                //    m_blnIsPrint[4] = false;
                //}
				
                //if(m_blnIsPrint[5])
                //{
                //    if(m_blnCheckBottom(ref p_intPosY,50,p_intPosY))
                //    {
                //        m_blnHaveMoreLine = true;
                //        return;
                //    }
                //    p_objGrp.DrawString("腹部:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                //    strPrintText = "     ";
                //    if(m_hasItemDetail.Contains("体格检查>>腹部"))
                //        strPrintText += ""+m_hasItemDetail["体格检查>>腹部"]+"。";
                //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                //    p_objGrp.DrawString("泌尿生殖系统:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                //    strPrintText = "            ";
                //    if(m_hasItemDetail.Contains("体格检查>>泌尿生殖系统"))
                //        strPrintText += ""+m_hasItemDetail["体格检查>>泌尿生殖系统"]+"。";
                //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                //    p_objGrp.DrawString("脊柱四肢:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
                //    strPrintText = "         ";
                //    if(m_hasItemDetail.Contains("体格检查>>脊柱四肢>>脊柱"))
                //        strPrintText += "脊柱"+m_hasItemDetail["体格检查>>脊柱四肢>>脊柱"]+",";
                //    if(m_hasItemDetail.Contains("体格检查>>脊柱四肢>>四肢"))
                //        strPrintText += "四肢"+m_hasItemDetail["体格检查>>脊柱四肢>>四肢"]+",";
                //    if(m_hasItemDetail.Contains("体格检查>>脊柱四肢>>骨盆"))
                //        strPrintText += "骨盆"+m_hasItemDetail["体格检查>>脊柱四肢>>骨盆"]+",";
                //    if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                //    m_blnIsPrint[5] = false;
                //}
                #endregion 

                #endregion Print


                m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsPrint = new Boolean[]{true,true,true,true};
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}

		}

		/// <summary>
		/// 神经系统检查:一般情况+颅神经
		/// </summary>
		private class clsPrintInPatMedRecGeneralNerves : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true,true,true,true,true,true,true,true,true};

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				string strPrintText = "";
				#region Print
				if(m_blnIsPrint[11])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_intPosY += 20;
					p_objGrp.DrawString("神 经 系 统 检 查",m_fotItemHead,Brushes.Black,m_intRecBaseX+270,p_intPosY);
					p_intPosY += 40;
					m_blnIsPrint[11] = false;
				}
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("颅神经:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					p_intPosY += 20;
                    p_objGrp.DrawString("Ⅰ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "       ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅰ对>>嗅觉"))
                        strPrintText += "嗅觉" + m_hasItemDetail["颅神经>>Ⅰ对>>嗅觉"] + ";";
                    //if(m_hasItemDetail.Contains("神经系统检查>>一般情况>>检查合作情况"))
                    //    strPrintText += "检查合作情况"+m_hasItemDetail["神经系统检查>>一般情况>>检查合作情况"]+";";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
                    //p_objGrp.DrawString("GCS评分:",m_fotHead,Brushes.Black,m_intRecBaseX+30,p_intPosY);
                    //strPrintText = "          ";
                    //if(m_hasItemDetail.Contains("神经系统检查>>一般情况>>GCS评分"))
                    //    strPrintText += ""+m_hasItemDetail["神经系统检查>>一般情况>>GCS评分"]+"。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
					m_blnIsPrint[0] = false;
				}
				if(m_blnIsPrint[1])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅱ对:视力", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "           ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>左侧近视力"))
                        strPrintText += "左侧" + m_hasItemDetail["颅神经>>Ⅱ对>>左侧近视力"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>右侧近视力"))
                        strPrintText += "右侧" + m_hasItemDetail["颅神经>>Ⅱ对>>右侧近视力"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>视野"))
                        strPrintText += "视野" + m_hasItemDetail["颅神经>>Ⅱ对>>视野"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>左侧眼底"))
                        strPrintText += "眼底:左侧" + m_hasItemDetail["颅神经>>Ⅱ对>>左侧眼底"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>右侧眼底"))
                        strPrintText += "右侧" + m_hasItemDetail["颅神经>>Ⅱ对>>右侧眼底"] + ",";
                    //if (m_hasItemDetail.Contains("精神状态>>妄想"))
                    //    strPrintText += "妄想" + m_hasItemDetail["精神状态>>妄想"] + ",";					
                    //if(m_hasItemDetail.Contains("神经系统检查>>一般情况>>自知力"))
                    //    strPrintText += "自知力"+m_hasItemDetail["神经系统检查>>一般情况>>自知力"]+",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[1] = false;
					
				}
				
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅲ.Ⅳ.Ⅵ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>左眼"))
                        strPrintText += "左眼" + m_hasItemDetail["颅神经>>Ⅱ对>>左眼"] + ",";
                    if (m_hasItemDetail.Contains("左眼睑下垂"))
                        strPrintText += "眼睑下垂" + m_hasItemDetail["左眼睑下垂"] + ",";
                    if (m_hasItemDetail.Contains("左眼球突出"))
                        strPrintText += "眼球突出" + m_hasItemDetail["左眼球突出"] + ",";
                    if (m_hasItemDetail.Contains("左眼球内陷"))
                        strPrintText += "眼球内陷" + m_hasItemDetail["左眼球内陷"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅱ对>>右眼"))
                        strPrintText += "右眼" + m_hasItemDetail["颅神经>>Ⅱ对>>右眼"] + ",";
                    if (m_hasItemDetail.Contains("右眼睑下垂"))
                        strPrintText += "眼睑下垂" + m_hasItemDetail["右眼睑下垂"] + ",";
                    if (m_hasItemDetail.Contains("右眼球突出"))
                        strPrintText += "眼球突出" + m_hasItemDetail["右眼球突出"] + ",";
                    if (m_hasItemDetail.Contains("右眼球内陷"))
                        strPrintText += "眼球内陷" + m_hasItemDetail["右眼球内陷"] + ",";                    

					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    //strPrintText = "";
                    //if (m_hasItemDetail.Contains("利手"))
                    //    strPrintText += "利手" + m_hasItemDetail["利手"] + "。";
                    ////else if(m_hasItemDetail.Contains("神经系统检查>>一般情况>>右利手"))
                    ////    strPrintText += "右利手,";
                    //p_objGrp.DrawString(strPrintText,p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
                    //p_intPosY += 20;

					m_blnIsPrint[2] = false;
				}
				
				if(m_blnIsPrint[3])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					//p_objGrp.DrawString("颅神经:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					//p_intPosY += 20;
                    p_objGrp.DrawString("Ⅶ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "      ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直径"))
                        strPrintText += "左瞳孔直径" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直径"] + "mm ,";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>形状"))
                        strPrintText += "形状" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>形状"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直接对光反射"))
                        strPrintText += "直接对光反射" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直接对光反射"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>间接对光反射"))
                        strPrintText += "间接对光反射" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>间接对光反射"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直径"))
                        strPrintText += "右瞳孔直径" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直径"] + "mm ,";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>形状"))
                        strPrintText += "形状" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>形状"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直接对光反射"))
                        strPrintText += "直接对光反射" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直接对光反射"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>间接对光反射"))
                        strPrintText += "间接对光反射" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>间接对光反射"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>调节反射"))
                        strPrintText += "调节反射" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>调节反射"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼姿"))
                        strPrintText += "眼姿" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼姿"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球分离"))
                        strPrintText += "眼球分离" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球分离"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>同向凝视"))
                        strPrintText += "同向凝视" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>同向凝视"] + ",";
                    if (m_hasItemDetail.Contains("眼球震颤"))
                        strPrintText += "眼球震颤" + m_hasItemDetail["眼球震颤"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球浮动"))
                        strPrintText += "眼球浮动" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球浮动"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球运动"))
                        strPrintText += "眼球运动" + m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球运动"] + ",";
                    if (m_hasItemDetail.Contains("复视"))
                        strPrintText += "复视" + m_hasItemDetail["复视"] + ",";       

					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[3] = false;
				}
				
				if(m_blnIsPrint[4])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅴ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>面部感觉"))
                        strPrintText += "面部感觉" + m_hasItemDetail["颅神经>>Ⅴ对>>面部感觉"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>左侧角膜反射"))
                        strPrintText += "角膜反射" + m_hasItemDetail["颅神经>>Ⅴ对>>左侧角膜反射"] + ",";
					//if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";

                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>张口"))
                        strPrintText += "张口" + m_hasItemDetail["颅神经>>Ⅴ对>>张口"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>咀嚼肌力"))
                        strPrintText += "咀嚼肌" + m_hasItemDetail["颅神经>>Ⅴ对>>咀嚼肌力"] + ",";
					//if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅱ对>>视野"))
                    //    strPrintText += "视野:"+m_hasItemDetail["颅神经>>Ⅱ对>>视野"]+"。";

                    //if(m_hasItemDetail.Contains("颅神经>>Ⅱ对>>左侧眼底"))
                    //    strPrintText += "眼底:左侧"+m_hasItemDetail["颅神经>>Ⅱ对>>左侧眼底"]+";";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅱ对>>右侧眼底"))
                    //    strPrintText += "右侧"+m_hasItemDetail["颅神经>>Ⅱ对>>右侧眼底"]+";";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

					m_blnIsPrint[4] = false;
				}
				
				if(m_blnIsPrint[5])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅶ对:面瘫:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "           ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>中枢性"))
                        strPrintText += "中枢性" + m_hasItemDetail["颅神经>>Ⅴ对>>中枢性"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>面肌抽搐"))
                        strPrintText += "面肌抽搐" + m_hasItemDetail["颅神经>>Ⅴ对>>面肌抽搐"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>安全性"))
                        strPrintText += "安全性" + m_hasItemDetail["颅神经>>Ⅴ对>>安全性"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅴ对>>味觉"))
                        strPrintText += "味觉" + m_hasItemDetail["颅神经>>Ⅴ对>>味觉"] + ",";
                    #region 
                    //strPrintText += "右眼";
                    //if (m_hasItemDetail.Contains("右眼睑下垂"))
                    //    strPrintText += "眼睑下垂" + m_hasItemDetail["右眼睑下垂"] + ",";
                    //if (m_hasItemDetail.Contains("右眼球突出"))
                    //    strPrintText += "眼球突出" + m_hasItemDetail["右眼球突出"] + ",";
                    //if (m_hasItemDetail.Contains("右眼球内陷"))
                    //    strPrintText += "及眼球内陷" + m_hasItemDetail["右眼球内陷"] + ",";
                   
                    //if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直径"))
                    //    strPrintText += "左瞳孔直径"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直径"]+"mm,";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>形状"))
                    //    strPrintText += "形状"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>形状"]+",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直接对光反射"))
                    //    strPrintText += "直接对光反射"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>直接对光反射"]+",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>间接对光反射"))
                    //    strPrintText += "间接对光反射"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>左瞳孔>>间接对光反射"]+";";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直径"))
                    //    strPrintText += "右瞳孔直径"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直径"]+"mm,";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>形状"))
                    //    strPrintText += "形状"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>形状"]+",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直接对光反射"))
                    //    strPrintText += "直接对光反射"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>直接对光反射"]+",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>间接对光反射"))
                    //    strPrintText += "间接对光反射"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>右瞳孔>>间接对光反射"]+";";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>调节反射"))
                    //    strPrintText += "调节反射"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>调节反射"]+",";
                    //if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼位"))
                    //    strPrintText += "眼位"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼位"]+"斜视,";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>同向凝视"))
                    //    strPrintText += ""+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>同向凝视"]+"同向凝视,";
                    //if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球运动"))
                    //    strPrintText += "眼球运动"+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>眼球运动"]+",";
                    //if (m_hasItemDetail.Contains("眼球震颤"))
                    //    strPrintText += "眼球震颤" + m_hasItemDetail["眼球震颤"] + ",";
                    ////else if (m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>无眼球震颤"))
                    ////    strPrintText += "无眼球震颤,";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>上视障碍"))
                    //    strPrintText += ""+m_hasItemDetail["颅神经>>Ⅲ.Ⅳ.Ⅵ对>>上视障碍"]+"上视障碍,";
                    //if (m_hasItemDetail.Contains("复视"))
                    //    strPrintText += "复视" + m_hasItemDetail["复视"] + ",";
                    //else if(m_hasItemDetail.Contains("颅神经>>Ⅲ.Ⅳ.Ⅵ对>>无复视"))
                    //    strPrintText += "无复视,";
                    #endregion 
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);


					m_blnIsPrint[5] = false;
				}
				
				if(m_blnIsPrint[6])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅷ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "       ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅷ对>>左耳听力"))
                        strPrintText += "左耳听力" + m_hasItemDetail["颅神经>>Ⅷ对>>左耳听力"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅷ对>>左耳Rinne试验气导"))
                        strPrintText += "左耳Rinne试验气导" + m_hasItemDetail["颅神经>>Ⅷ对>>左耳Rinne试验气导"] + "骨导,";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅷ对>>右耳听力"))
                        strPrintText += "右耳听力" + m_hasItemDetail["颅神经>>Ⅷ对>>右耳听力"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅷ对>>右耳Rinne试验气导"))
                        strPrintText += "右耳Rinne试验气导" + m_hasItemDetail["颅神经>>Ⅷ对>>右耳Rinne试验气导"] + ",";
					//if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //strPrintText += "角膜反射:";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅴ对>>左侧角膜反射"))
                    //    strPrintText += "左侧"+m_hasItemDetail["颅神经>>Ⅴ对>>左侧角膜反射"]+",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅴ对>>右侧角膜反射"))
                    //    strPrintText += "右侧"+m_hasItemDetail["颅神经>>Ⅴ对>>右侧角膜反射"]+",";
                    //if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    //strPrintText += "下颌反射:";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅴ对>>左侧下颌反射"))
                    //    strPrintText += "左侧"+m_hasItemDetail["颅神经>>Ⅴ对>>左侧下颌反射"]+",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅷ对>>Weber试验"))
                        strPrintText += "Weber试验" + m_hasItemDetail["颅神经>>Ⅷ对>>Weber试验"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[6] = false;
				}
				
				if(m_blnIsPrint[7])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅸ.Ⅹ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>发音"))
                        strPrintText += "发音" + m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>发音"] + "，";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>吞咽"))
                        strPrintText += "吞咽" + m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>吞咽"] + "，";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>软腭及悬雍垂"))
                        strPrintText += "软腭及悬雍垂" + m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>软腭及悬雍垂"] + "，";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>咽反射"))
                        strPrintText += "咽反射" + m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>咽反射"] + "，";
                    //if (m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>发音"))
                    //    strPrintText += "发音" + m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>发音"] + "，";

					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[7] = false;
				}
				
				if(m_blnIsPrint[8])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅺ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "       ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅺ对>>耸肩"))
                        strPrintText += "耸肩" + m_hasItemDetail["颅神经>>Ⅺ对>>耸肩"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅺ对>>胸锁乳突肌萎缩"))
                        strPrintText += "胸锁乳突肌萎缩" + m_hasItemDetail["颅神经>>Ⅺ对>>胸锁乳突肌萎缩"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅺ对>>转颈"))
                        strPrintText += "转颈无力" + m_hasItemDetail["颅神经>>Ⅺ对>>转颈"] + ",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅷ对>>右耳Rinne试验气导"))
                    //    strPrintText += "Rinne试验气导"+m_hasItemDetail["颅神经>>Ⅷ对>>右耳Rinne试验气导"]+"骨导,";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅷ对>>Weber试验"))
                    //    strPrintText += "Weber试验"+m_hasItemDetail["颅神经>>Ⅷ对>>Weber试验"]+",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[8] = false;
				}
				
				if(m_blnIsPrint[9])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("Ⅻ对:", m_fotHead, Brushes.Black, m_intRecBaseX + 30, p_intPosY);
					strPrintText = "        ";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅻ对>>舌在口中位置"))
                        strPrintText += "舌在口中位置" + m_hasItemDetail["颅神经>>Ⅻ对>>舌在口中位置"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅻ对>>伸舌偏向"))
                        strPrintText += "伸舌偏向" + m_hasItemDetail["颅神经>>Ⅻ对>>伸舌偏向"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅻ对>>舌肌纤动"))
                        strPrintText += "舌肌萎缩" + m_hasItemDetail["颅神经>>Ⅻ对>>舌肌纤动"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅻ对>>舌肌震颤"))
                        strPrintText += "舌肌震颤" + m_hasItemDetail["颅神经>>Ⅻ对>>舌肌震颤"] + ",";
                    if (m_hasItemDetail.Contains("颅神经>>Ⅻ对>>舌肌纤颤"))
                        strPrintText += "舌肌纤颤" + m_hasItemDetail["颅神经>>Ⅻ对>>舌肌纤颤"] + ",";
                    //if(m_hasItemDetail.Contains("颅神经>>Ⅸ.Ⅹ对>>舌后1/3味觉"))
                    //    strPrintText += "舌后1/3味觉"+m_hasItemDetail["颅神经>>Ⅸ.Ⅹ对>>舌后1/3味觉"]+",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
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
                    p_objGrp.DrawString("运动系统:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "       ";
                    if (m_hasItemDetail.Contains("肌萎缩"))
                        strPrintText += "肌萎缩" + m_hasItemDetail["肌萎缩"] + ",";
                    if (m_hasItemDetail.Contains("肌张力"))
                        strPrintText += "肌张力" + m_hasItemDetail["肌张力"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    p_objGrp.DrawString("肌力(0-V):", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("左上肢远端"))
                        strPrintText += "左上肢远端" + m_hasItemDetail["左上肢远端"] + ",";
                    if (m_hasItemDetail.Contains("左上肢近端"))
                        strPrintText += "左上肢近端" + m_hasItemDetail["左上肢近端,"]+ ",";
                    if (m_hasItemDetail.Contains("左下肢远端"))
                        strPrintText += "左下肢远端" + m_hasItemDetail["左下肢远端"] + ",";
                    if (m_hasItemDetail.Contains("左下肢近端"))
                        strPrintText += "左下肢近端" + m_hasItemDetail["左下肢近端"] + ",";
                    if (m_hasItemDetail.Contains("右上肢远端"))
                        strPrintText += "右上肢远端" + m_hasItemDetail["右上肢远端"] + ",";
                    if (m_hasItemDetail.Contains("右上肢近端"))
                        strPrintText += "右上肢近端" + m_hasItemDetail["右上肢近端"] + ",";
                    if (m_hasItemDetail.Contains("右上肢远端"))
                        strPrintText += "右上肢远端" + m_hasItemDetail["右上肢远端"] + ",";
                    if (m_hasItemDetail.Contains("右上肢近端"))
                        strPrintText += "右上肢近端" + m_hasItemDetail["右上肢近端"] + ",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					m_blnIsPrint[10] = false;
				}
				#endregion Print
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsPrint = new Boolean[]{true,true,true,true,true,true,true,true,true,true,true,true};
				m_blnHaveMoreLine = true;
			}

		}

		
        
        
        /// <summary>
		/// 神经系统检查>>运动系统~
		/// </summary>
        //private class clsPrintInPatMedRecHeadNerves : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
        //    private string[] m_strKeysArr3 = {"运动>>肩>>内收>>左","运动>>肩>>内收>>右","运动>>肩>>外展>>左","运动>>肩>>外展>>右"};
        //    private string[] m_strKeysArr4 = {"运动>>肘>>屈>>左","运动>>肘>>屈>>右","运动>>肘>>伸>>左","运动>>肘>>伸>>右"};
        //    private string[] m_strKeysArr5 = {"运动>>腕>>屈>>左","运动>>腕>>屈>>右","运动>>腕>>伸>>左","运动>>腕>>伸>>右"};
        //    private string[] m_strKeysArr6 = {"运动>>指>>屈>>左","运动>>指>>屈>>右","运动>>指>>伸>>左","运动>>指>>伸>>右"};
        //    private string[] m_strKeysArr7 = {"运动>>髋>>屈>>左","运动>>髋>>屈>>右","运动>>髋>>伸>>左","运动>>髋>>伸>>右"};
        //    private string[] m_strKeysArr8 = {"运动>>膝>>屈>>左","运动>>膝>>屈>>右","运动>>膝>>伸>>左","运动>>膝>>伸>>右"};
        //    private string[] m_strKeysArr9 = {"运动>>踝>>屈>>左","运动>>踝>>屈>>右","运动>>踝>>伸>>左","运动>>踝>>伸>>右"};
        //    private string[] m_strKeysArr10 = {"运动>>趾>>屈>>左","运动>>趾>>屈>>右","运动>>趾>>伸>>左","运动>>趾>>伸>>右"};
        //    private bool[] m_blnIsPrint = new Boolean[]{true,true,true,true,true,true};
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        string strPrintText = "";
        //        #region Print
        //        if(m_blnIsPrint[0])
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }
        //            p_objGrp.DrawString("运动系统:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //            strPrintText = "         ";
        //            if(m_hasItemDetail.Contains("运动系统>>肌营养"))
        //                strPrintText += "肌营养"+m_hasItemDetail["运动系统>>肌营养"]+",";
        //            if(m_hasItemDetail.Contains("运动系统>>肌张力"))
        //                strPrintText += "肌张力"+m_hasItemDetail["运动系统>>肌张力"]+",";
        //            if(m_hasItemDetail.Contains("运动系统>>有扣击性肌强直"))
        //                strPrintText += "有扣击性肌强直,";
        //            else if(m_hasItemDetail.Contains("运动系统>>无扣击性肌强直"))
        //                strPrintText += "无扣击性肌强直,";
        //            if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
        //            if(m_hasItemDetail.Contains("运动系统>>不自主运动"))
        //                strPrintText += "不自主运动"+m_hasItemDetail["运动系统>>不自主运动"]+",";
        //            if(m_hasItemDetail.Contains("运动系统>>肌力"))
        //                strPrintText += "肌力"+m_hasItemDetail["运动系统>>肌力"]+",";
        //            if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
        //            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
        //            m_blnIsPrint[0] = false;
        //        }
        //        if(m_blnIsPrint[1])
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY,100,p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }
        //            m_mthPrintSportTable(ref p_intPosY, p_objGrp, p_fntNormalText);
        //            p_intPosY += 20;
        //            m_blnIsPrint[1] = false;
        //        }
				
        //        if(m_blnIsPrint[2])
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }
        //            p_objGrp.DrawString("共济运动:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //            strPrintText = "        ";
        //            if(m_hasItemDetail.Contains("共济运动>>指鼻试验"))
        //                strPrintText += "指鼻试验"+m_hasItemDetail["共济运动>>指鼻试验"]+",";
        //            if(m_hasItemDetail.Contains("共济运动>>快复轮替试验"))
        //                strPrintText += "快复轮替试验"+m_hasItemDetail["共济运动>>快复轮替试验"]+",";
        //            if(m_hasItemDetail.Contains("共济运动>>眼球震颤"))
        //                strPrintText += "眼球震颤"+m_hasItemDetail["共济运动>>眼球震颤"]+",";
        //            if(m_hasItemDetail.Contains("共济运动>>Romberg征"))
        //                strPrintText += "Romberg's征"+m_hasItemDetail["共济运动>>Romberg征"]+",";
        //            if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
        //            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

        //            m_blnIsPrint[2] = false;
        //        }
				
        //        if(m_blnIsPrint[3])
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }
        //            p_objGrp.DrawString("姿势步态:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //            strPrintText = "        ";
        //            if(m_hasItemDetail.Contains("神经系统检查>>姿势步态"))
        //                strPrintText += ""+m_hasItemDetail["神经系统检查>>姿势步态"]+"。";
        //            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

        //            m_blnIsPrint[3] = false;
        //        }
				
        //        if(m_blnIsPrint[4])
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY,20,p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }
        //            p_objGrp.DrawString("联带动作:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //            strPrintText = "        ";
        //            if(m_hasItemDetail.Contains("神经系统检查>>联带动作"))
        //                strPrintText += ""+m_hasItemDetail["神经系统检查>>联带动作"]+"。";
        //            m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

        //            m_blnIsPrint[4] = false;
        //        }
				
        //        //if(m_blnIsPrint[5])
        //        //{
        //        //    if(m_blnCheckBottom(ref p_intPosY,20,p_intPosY))
        //        //    {
        //        //        m_blnHaveMoreLine = true;
        //        //        return;
        //        //    }
        //        //    p_objGrp.DrawString("感觉系统:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //        //    strPrintText = "        ";
        //        //    if(m_hasItemDetail.Contains("神经系统检查>>感觉系统>>感觉系统"))
        //        //        strPrintText += ""+m_hasItemDetail["神经系统检查>>感觉系统>>感觉系统"]+",";
        //        //    if(m_hasItemDetail.Contains("神经系统检查>>感觉系统>>皮层觉"))
        //        //        strPrintText += "皮层觉"+m_hasItemDetail["神经系统检查>>感觉系统>>皮层觉"]+",";
        //        //    if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
        //        //    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);


        //        //    m_blnIsPrint[5] = false;
        //        //}
        //        #endregion Print
        //        m_blnHaveMoreLine = false;

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();
        //        m_blnHaveMoreLine = true;
        //        m_blnIsPrint = new Boolean[]{true,true,true,true,true,true};
        //    }
        //    #region 打印表格
        //    private void m_mthPrintSportTable(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
        //        int intRowStep = m_intRecBaseX + 10;
        //        int intPosY = p_intPosY;
        //        p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep + intLineWidth,intPosY);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep+20,intPosY+20,intRowStep + intLineWidth,intPosY+20);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+40,intRowStep + intLineWidth,intPosY+40);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY,intRowStep,intPosY+80);
        //        p_objGrp.DrawString("左",p_fntNormalText,Brushes.Black,intRowStep+1,intPosY+41);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+60,intRowStep + intLineWidth,intPosY+60);
        //        p_objGrp.DrawString("右",p_fntNormalText,Brushes.Black,intRowStep+1,intPosY+61);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep,intPosY+80,intRowStep + intLineWidth ,intPosY+80);
        //        p_objGrp.DrawLine(Pens.Black,intRowStep +intLineWidth,p_intPosY,intRowStep +intLineWidth,p_intPosY+80);
        //        intRowStep += 20;
        //        m_mthPrintSubItem(new string[]{"肩","内收","外展"},m_strKeysArr3,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"肘","屈","伸"},m_strKeysArr4,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"腕","屈","伸"},m_strKeysArr5,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"指","屈","伸"},m_strKeysArr6,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"髋","屈","伸"},m_strKeysArr7,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"膝","屈","伸"},m_strKeysArr8,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"踝","屈","伸"},m_strKeysArr9,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        m_mthPrintSubItem(new string[]{"趾","屈","伸"},m_strKeysArr10,ref intRowStep,p_intPosY, p_objGrp, p_fntNormalText);
        //        p_intPosY += 80;
        //    }

        //    private void m_mthPrintSubItem(string[] p_strTitleArr,string[] p_strKeyArr,ref int p_intRow,int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
        //        if(objConArr == null || objConArr.Length != 4 || p_strTitleArr == null)
        //            return;
        //        string[] strConArr = new String[objConArr.Length];
        //        for(int i=0;i<objConArr.Length; i++)
        //        {
        //            strConArr[i] = "";
        //            if(objConArr[i] != null)
        //                if(objConArr[i].m_strItemContent != null)
        //                    strConArr[i] = objConArr[i].m_strItemContent;
        //        }
        //        p_objGrp.DrawLine(Pens.Black,p_intRow,p_intPosY,p_intRow,p_intPosY+80);
        //        int intLenth = Convert.ToInt32( Math.Max( p_objGrp.MeasureString(strConArr[0],p_fntNormalText).Width,p_objGrp.MeasureString(strConArr[1],p_fntNormalText).Width));
        //        p_objGrp.DrawString(p_strTitleArr[0],p_fntNormalText,Brushes.Black,p_intRow+20,p_intPosY+1);
        //        p_objGrp.DrawString(p_strTitleArr[1],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+21);
        //        p_objGrp.DrawString(strConArr[0],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+41);
        //        p_objGrp.DrawString(strConArr[1],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+61);
        //        p_intRow += Math.Max(intLenth,40);
        //        p_objGrp.DrawLine(Pens.Black,p_intRow,p_intPosY+20,p_intRow,p_intPosY+80);
        //        intLenth = Convert.ToInt32( Math.Max( p_objGrp.MeasureString(strConArr[2],p_fntNormalText).Width,p_objGrp.MeasureString(strConArr[3],p_fntNormalText).Width));
        //        p_objGrp.DrawString(p_strTitleArr[2],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+21);
        //        p_objGrp.DrawString(strConArr[2],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+41);
        //        p_objGrp.DrawString(strConArr[3],p_fntNormalText,Brushes.Black,p_intRow+1,p_intPosY+61);
        //        p_intRow += Math.Max(intLenth,40);
        //    }
        //    #endregion
        //}
		/// <summary>
		/// 神经系统检查>>反射
		/// </summary>
		private class clsPrintInPatMedRecReflect : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private clsInpatMedRec_Item[] objItemContent;
			private int m_intIndex = 0;
			private bool blnIsRight = true;
            private string[] strTitleArr = new string[]{"肱二头","","腹壁  上","","Babinski's征","","肱三头","","      中","","Chaddock's征","","桡骨膜","","      下","",
								"Hoffmann's征","","膝腱","","提睾反射","","其他","","跟腱","","足石反射","","","","阵挛","","肛门反射","","",""};
            private string[] m_strKeyArr = {"反射>>肱二头>>左","反射>>肱二头>>右","反射>>腹壁上>>左","反射>>腹壁上>>右","反射>>Babinski>>左","反射>>Babinski>>右","反射>>肱三头>>左","反射>>肱三头>>右"
											   ,"反射>>腹壁中>>左","反射>>腹壁中>>右","反射>>Chaddock>>左","反射>>Chaddock>> 右","反射>>桡骨膜>>左","反射>>桡骨膜>>右","反射>>腹壁下>>左","反射>>腹壁下>>右"
											   ,"反射>>Hoffmann>>左","反射>>Hoffmann>>右","反射>>膝腱>>左","反射>>膝腱>>右","反射>>提睾反射>>左","反射>>提睾反射>>右","反射>>其他>>左","反射>>其他>>右"
											   ,"反射>>跟腱>>左","反射>>跟腱>>右","反射>>足石反射>>左","反射>>足石反射>>右","反射>>>左","反射>>>右","反射>>踝膝阵挛>>左","反射>>踝膝阵挛>>右",
												"反射>>肛门反射>>左","反射>>肛门反射>>右","反射>>Rossolimo>>左","反射>>Rossolimo>>右"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnHavePrintInfo(m_strKeyArr) == false)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				objItemContent = m_objGetContentFromItemArr(m_strKeyArr);
				if(objItemContent == null || objItemContent.Length <= 0)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					if(m_intIndex == 0)
					{
//						p_intPosY += 20;
                        p_objGrp.DrawString("反射:(阵挛++++)亢进(+++)正常(++)减退(+)消失(-))", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
						p_intPosY += 20;
					}
					p_objGrp.DrawString("左      右                  左      右                     左      右",p_fntNormalText,Brushes.Black,m_intRecBaseX+95,p_intPosY);
					p_intPosY += 20;
					for(int i = m_intIndex; i < objItemContent.Length; i++)
					{
						if((p_intPosY+20) > ((int)enmRectangleInfo.BottomY -50))
						{
							m_blnHaveMoreLine = true;
							p_intPosY += 100;
							m_intIndex = i;
							return;
						}
						blnIsRight = !blnIsRight;
//						if(objItemContent[i] == null && objItemContent[i+1] == null)
//						{
//							i++;
//							continue;
//						}
						m_mthPrintTable(strTitleArr[i],objItemContent[i],objItemContent[++i],blnIsRight,ref p_intPosY,p_objGrp,p_fntNormalText);
					}
//					p_intPosY += 20;
					m_blnIsFirstPrint = false;					
				}
				m_blnHaveMoreLine = false;
			}

			private int index = 0;
			private int intPos = 0;
			private int intRight = 0;
			private int intLeft= 0;
			private void m_mthPrintTable(string p_strTitle,clsInpatMedRec_Item p_objItemLeft,clsInpatMedRec_Item p_objItemRight,bool p_blnIsRight,ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(index == 0)
				{
					intPos = m_intRecBaseX+20;
					intLeft= intPos + 70;
					intRight = intLeft + 70;
				}
				
				else if(index == 1)
				{
					intPos += 220;
					intLeft= intPos + 95;
					intRight = intLeft + 70;
				}
				else
				{
					intPos += 220;
					intLeft= intPos + 130;
					intRight = intLeft + 70;
				}
				p_objGrp.DrawString(p_strTitle,p_fntNormalText,Brushes.Black,intPos,p_intPosY);
				if(p_objItemLeft!= null)
					p_objGrp.DrawString((p_objItemLeft.m_strItemContent == null ?"" :p_objItemLeft.m_strItemContent),p_fntNormalText,Brushes.Black,intLeft,p_intPosY);
				if(p_objItemRight!= null)
					p_objGrp.DrawString((p_objItemRight.m_strItemContent == null ?"" :p_objItemRight.m_strItemContent),p_fntNormalText,Brushes.Black,intRight,p_intPosY);

				
				++ index;
				if(index == 3)
				{
					index = 0;
					p_intPosY += 20;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
			}
		}

		/// <summary>
		/// 神经系统检查>>植物神经系统~其他
		/// </summary>
		private class clsPrintInPatMedRecPlant : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
            private bool[] m_blnIsPrint = new Boolean[] { true, true, true, true };
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
                if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				string strPrintText = "";
				#region Print
				if(m_blnIsPrint[0])
				{
					if(m_blnCheckBottom(ref p_intPosY,60,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
                    p_objGrp.DrawString("不随意运动:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("不随意运动>>种类"))
                        strPrintText += "种类" + m_hasItemDetail["不随意运动>>种类"] + ",";
                    if (m_hasItemDetail.Contains("不随意运动>>部位"))
                        strPrintText += "部位" + m_hasItemDetail["不随意运动>>部位"] + ",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>皮肤营养"))
                    //    strPrintText += "皮肤营养"+m_hasItemDetail["植物神经系统>>皮肤营养"]+",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>皮肤划痕征"))
                    //    strPrintText += "皮肤划痕征"+m_hasItemDetail["植物神经系统>>皮肤划痕征"]+",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>括约肌"))
                    //    strPrintText += "括约肌"+m_hasItemDetail["植物神经系统>>括约肌"]+",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>其他"))
                    //    strPrintText += "其他"+m_hasItemDetail["植物神经系统>>其他"]+",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
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
					p_objGrp.DrawString("共济运动:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY-2);
					strPrintText = "         ";
                    if (m_hasItemDetail.Contains("不随意运动>>指鼻试验"))
                        strPrintText += "指鼻试验" + m_hasItemDetail["不随意运动>>指鼻试验"] + ",";
                    //else if (m_hasItemDetail.Contains("脑膜刺激征>>无颈强直"))
                    //    strPrintText += "无颈强直,";
                    if (m_hasItemDetail.Contains("不随意运动>>轮替试验"))
                        strPrintText += "轮替试验" + m_hasItemDetail["不随意运动>>轮替试验"] + ",";
                    if (m_hasItemDetail.Contains("不随意运动>>跟膝胫试验"))
                        strPrintText += "跟膝胫试验" + m_hasItemDetail["不随意运动>>跟膝胫试验"] + ",";
                    if (m_hasItemDetail.Contains("不随意运动>>Rombrg征"))
                        strPrintText += "Rombrg征" + m_hasItemDetail["不随意运动>>Rombrg征"] + ",";
                    //if(m_hasItemDetail.Contains("脑膜刺激征>>Lasegue征"))
                    //    strPrintText += "Lasegue's征"+m_hasItemDetail["脑膜刺激征>>Lasegue征"]+",";
					if(strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length-1,1)+"。";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
					m_blnIsPrint[1] = false;
				}
				
				if(m_blnIsPrint[2])
				{
					if(m_blnCheckBottom(ref p_intPosY,40,p_intPosY))
					{
						m_blnHaveMoreLine = true;
						return;
					}
					p_objGrp.DrawString("植物神经系统:",m_fotHead,Brushes.Black,m_intRecBaseX+10,p_intPosY-2);
					strPrintText = "           ";
                    if (m_hasItemDetail.Contains("体格检查>>汗腺分泌"))
                        strPrintText += "汗腺分泌" + m_hasItemDetail["体格检查>>汗腺分泌"] + "，";
                    if (m_hasItemDetail.Contains("体格检查>>皮肤划痕"))
                        strPrintText += "皮肤划痕" + m_hasItemDetail["体格检查>>皮肤划痕"] + "，";
                    if (m_hasItemDetail.Contains("植物神经系统>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["植物神经系统>>其他"] + "，";
					m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
					
					m_blnIsPrint[2] = false;
				}
                if (m_blnIsPrint[3])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("其他:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "      ";
                    if (m_hasItemDetail.Contains("神经系统检查>>其他"))
                        strPrintText += "" + m_hasItemDetail["神经系统检查>>其他"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>感觉系统>>感觉系统"))
                        strPrintText += "感觉系统" + m_hasItemDetail["神经系统检查>>感觉系统>>感觉系统"] + ",";
                    if (m_hasItemDetail.Contains("神经系统检查>>感觉系统>>皮层觉"))
                        strPrintText += "皮层觉" + m_hasItemDetail["神经系统检查>>感觉系统>>皮层觉"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    
                    m_blnIsPrint[3] = false;
                }
				#endregion Print
				m_blnHaveMoreLine = false;

			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsPrint = new Boolean[]{true,true,true};
			}
        }
        #region
        /// <summary>
		/// 神经系统检查>>实验室及其他特殊检查
		/// </summary>
        //private class clsPrintInPatMedRecLab : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private bool blnNextPage = true;
        //    private string[] m_strKeysArr1 = {"实验室及其他特殊检查"};

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if(m_objContent == null|| m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if(m_blnHavePrintInfo(m_strKeysArr1) == false )
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if(m_blnIsFirstPrint)
        //        {
        //            p_objGrp.DrawString("实验室及其他特殊检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
        //            p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if(m_objContent!=null)
        //            {
        //                if(m_blnHavePrintInfo(m_strKeysArr1) != false)
        //                    m_mthMakeText(new string[]{""},m_strKeysArr1,ref strAllText,ref strXml);
						
        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
        //            m_mthAddSign2("实验室及其他特殊检查：",m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;					
        //        }

        //        int intLine = 0;
        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
        //            p_intPosY += 20;
        //        }
        //        if(m_objPrintContext.m_BlnHaveNextLine())
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
        //}  ;
        #endregion

        /// <summary>
        /// 特殊检查
        /// </summary>
        private class clsPrintInSpCheck : clsIMR_PrintLineBase 
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool[] m_blnIsPrint = new Boolean[] { true, true, true, true, true, true };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null || m_hasItemDetail == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                string strPrintText = "";
                #region Print
                if (m_blnIsPrint[0])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("X线平片:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    strPrintText = "           ";
                    if (m_hasItemDetail.Contains("特殊检查>>X线平片号码"))
                        strPrintText += "号码" + m_hasItemDetail["特殊检查>>X线平片号码"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>X线平片日期"))
                        strPrintText += "日期" + m_hasItemDetail["特殊检查>>X线平片日期"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>X线平片结果"))
                        strPrintText += "结果" + m_hasItemDetail["特殊检查>>X线平片结果"] + ",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>皮肤划痕征"))
                    //    strPrintText += "皮肤划痕征"+m_hasItemDetail["植物神经系统>>皮肤划痕征"]+",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>括约肌"))
                    //    strPrintText += "括约肌"+m_hasItemDetail["植物神经系统>>括约肌"]+",";
                    //if(m_hasItemDetail.Contains("植物神经系统>>其他"))
                    //    strPrintText += "其他"+m_hasItemDetail["植物神经系统>>其他"]+",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[0] = false;
                }
                if (m_blnIsPrint[1])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("闹血管造影:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "          ";
                    if (m_hasItemDetail.Contains("特殊检查>>闹血管造影号码"))
                        strPrintText += "号码" + m_hasItemDetail["特殊检查>>闹血管造影号码"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>闹血管造影日期"))
                        strPrintText += "日期" + m_hasItemDetail["特殊检查>>闹血管造影日期"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>闹血管造影结果"))
                        strPrintText += "结果" + m_hasItemDetail["特殊检查>>闹血管造影结果"] + ",";
                    //if(m_hasItemDetail.Contains("脑膜刺激征>>Lasegue征"))
                    //    strPrintText += "Lasegue's征"+m_hasItemDetail["脑膜刺激征>>Lasegue征"]+",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[1] = false;
                }

                if (m_blnIsPrint[2])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("CT扫描:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("特殊检查>>CT扫描结果号码"))
                        strPrintText += "号码" + m_hasItemDetail["特殊检查>>CT扫描结果号码"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>CT扫描日期"))
                        strPrintText += "日期" + m_hasItemDetail["特殊检查>>CT扫描日期"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>CT扫描结果"))
                        strPrintText += "结果" + m_hasItemDetail["特殊检查>>CT扫描结果"] + ",";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[2] = false;
                }
                if (m_blnIsPrint[3])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("MRI:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "      ";
                    if (m_hasItemDetail.Contains("特殊检查>>MRI号码"))
                        strPrintText += "号码" + m_hasItemDetail["特殊检查>>MRI号码"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>MRI日期"))
                        strPrintText += "日期" + m_hasItemDetail["特殊检查>>MRI日期"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>MRI结果"))
                        strPrintText += "结果" + m_hasItemDetail["特殊检查>>MRI结果"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[3] = false;
                }

                if (m_blnIsPrint[4])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("EEG:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "        ";
                    if (m_hasItemDetail.Contains("特殊检查>>EEG号码"))
                        strPrintText += "号码" + m_hasItemDetail["特殊检查>>EEG号码"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>EEG日期"))
                        strPrintText += "日期" + m_hasItemDetail["特殊检查>>EEG日期"] + ",";
                    if (m_hasItemDetail.Contains("特殊检查>>EEG结果"))
                        strPrintText += "结果" + m_hasItemDetail["特殊检查>>EEG结果"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[4] = false;
                }

                if (m_blnIsPrint[5])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("腰穿:", m_fotHead, Brushes.Black, m_intRecBaseX + 10, p_intPosY - 2);
                    strPrintText = "       ";
                    if (m_hasItemDetail.Contains("腰穿日期"))
                        strPrintText += "日期" + m_hasItemDetail["腰穿日期"] + ",";
                    if (m_hasItemDetail.Contains("CSP压力"))
                        strPrintText += "CSP压力" + m_hasItemDetail["CSP压力"] + ",";
                    if (m_hasItemDetail.Contains("kpa（mmH2O）外观"))
                        strPrintText += "kpa（mmH2O）外观" + m_hasItemDetail["kpa（mmH2O）外观"] + ",";
                    if (m_hasItemDetail.Contains("WBC"))
                        strPrintText += "WBC" + m_hasItemDetail["WBC"] + ",";
                    if (m_hasItemDetail.Contains("糖"))
                        strPrintText += "糖" + m_hasItemDetail["糖"] + ",";
                    if (m_hasItemDetail.Contains("蛋白"))
                        strPrintText += "蛋白" + m_hasItemDetail["蛋白"] + ",";
                    if (m_hasItemDetail.Contains("氯化物"))
                        strPrintText += "氯化物" + m_hasItemDetail["氯化物"] + ",";
                    if (m_hasItemDetail.Contains("腰穿>>其他"))
                        strPrintText += "其他" + m_hasItemDetail["腰穿>>其他"] + ",";
                    if (m_hasItemDetail.Contains("腰穿>>动力试验"))
                        strPrintText += "动力试验" + m_hasItemDetail["腰穿>>动力试验"] + ",";
                    if (strPrintText.Length > 0) strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);

                    m_blnIsPrint[5] = false;
                }

                #endregion Print
                m_blnHaveMoreLine = false;

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsPrint = new Boolean[] { true, true, true, true, true, true };
            }
        }

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
                objItemContent = m_objGetContentFromItemArr(new string[] { "最后诊断", "初步诊断", "修正诊断医师签名", "初步诊断医师签名" });
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
                    p_objGrp.DrawString("诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                  //  p_objGrp.DrawString("入院诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);

                    p_intPosY += 40; 
				//	m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				} 
				if(m_blnIsFirstPrint)
				{
                    p_objGrp.DrawString("诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                   // p_objGrp.DrawString("入院诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
					p_intPosY += 20;
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
						{
							m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[1].m_strItemContent ,(objItemContent[1]==null ? "<root />" : objItemContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[1]!=null);
                            m_mthAddSign2("诊断：", m_objPrintContext1.m_ObjModifyUserArr);
						}
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
						{
							m_objPrintContext2.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
                            m_mthAddSign2("入院诊断：", m_objPrintContext2.m_ObjModifyUserArr);
						}
                 //   m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);

					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							m_objPrintContext1.m_mthPrintLine(705,m_intRecBaseX+30,p_intPosY,p_objGrp);
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
							m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+400,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
                    //p_intPosY += 20;
                   // m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);
					m_blnHaveMoreLine = false;
				}
			}

            //private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            //{
            //    if (m_hasItems == null)
            //        return;
            //    p_intPosY += 20;
            //    p_objGrp.DrawString("签名：" + (objItemContent[3] == null ? "" : (objItemContent[3].m_strItemContent == null ? "" : objItemContent[3].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
            //    p_objGrp.DrawString("签名：" + (objItemContent[2] == null ? "" : (objItemContent[2].m_strItemContent == null ? "" : objItemContent[2].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);

            //}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}

        /// <summary>
        /// 签名
        /// </summary>
        private class clsPrintInSing : clsIMR_PrintLineBase
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
				objItemContent = m_objGetContentFromItemArr(new string[]{"修正诊断医师签名","初步诊断医师签名"});
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
                    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    p_objGrp.DrawString("主治医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
					
					p_intPosY += 40;
				//	m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
					m_blnHaveMoreLine = false;
					return;
				} 
				if(m_blnIsFirstPrint)
				{
                    //p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    //p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
					p_intPosY += 20;
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
						{
							m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[1].m_strItemContent ,(objItemContent[1]==null ? "<root />" : objItemContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[1]!=null);
                            m_mthAddSign2("住院医师签名：", m_objPrintContext1.m_ObjModifyUserArr);
						}
                    if (objItemContent[0] != null)
                        if (objItemContent[0].m_strItemContent != null)
                        {
                            m_objPrintContext2.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent, (objItemContent[0] == null ? "<root />" : objItemContent[0].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent[0] != null);
                            m_mthAddSign2("主治医师签名：", m_objPrintContext2.m_ObjModifyUserArr);
                        }
                    //m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);

					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
                    //if (objItemContent[1] != null)
                    //    if (objItemContent[1].m_strItemContent != null)
                    //        m_objPrintContext1.m_mthPrintLine(320,m_intRecBaseX+30,p_intPosY,p_objGrp);
                    //if (objItemContent[0] != null)
                    //    if (objItemContent[0].m_strItemContent != null)
                    //        m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+400,p_intPosY,p_objGrp);
                    p_objGrp.DrawString("住院医师签名：" + (objItemContent[1] == null ? "" : (objItemContent[1].m_strItemContent == null ? "" : objItemContent[1].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                    p_objGrp.DrawString("主治医师签名：" + (objItemContent[0] == null ? "" : (objItemContent[0].m_strItemContent == null ? "" : objItemContent[0].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                    m_blnHaveMoreLine = false;

                    p_intPosY += 20;
                    return;
                   // intLine++;

				}

                if (m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_intPosY += 20;
                    //m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHaveMoreLine = false;
                }
			}

            //private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            //{
            //    if (m_hasItems == null)
            //        return;
            //    p_intPosY += 20;
            //    p_objGrp.DrawString("签名：" + (objItemContent[3] == null ? "" : (objItemContent[3].m_strItemContent == null ? "" : objItemContent[3].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
            //    p_objGrp.DrawString("签名：" + (objItemContent[2] == null ? "" : (objItemContent[2].m_strItemContent == null ? "" : objItemContent[2].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);

            //}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
        }
       
#region 
        /// <summary>
        /// 修正诊断
		/// </summary>
        //private class clsPrintInPatMedRecLastDiag : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private bool blnNextPage = true;
        //    private string[] m_strKeysArr1 = { "修正诊断" };

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if(m_objContent == null|| m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if(m_blnHavePrintInfo(m_strKeysArr1) == false )
        //        {
        //            p_intPosY += 30;
        //            p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if(m_blnIsFirstPrint)
        //        {
        //            p_intPosY += 30;
        //            p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
        //            p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if(m_objContent!=null)
        //            {
        //                if(m_blnHavePrintInfo(m_strKeysArr1) != false)
        //                    m_mthMakeText(new string[]{""},m_strKeysArr1,ref strAllText,ref strXml);
						
        //            }
        //            else
        //            {
        //            p_intPosY += 20;
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
        //            m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;					
        //        }

        //        int intLine = 0;
        //        if(m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+ 420,p_intPosY,p_objGrp);
        //            p_intPosY += 20;
        //        }
        //        if(m_objPrintContext.m_BlnHaveNextLine())
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
        /// <summary>
        /// 修正诊断医师签名
        /// </summary>
        #region
        //private class clsPrintInSing2 : clsIMR_PrintLineBase
        //{
        //    private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
        //    private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
        //    private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private clsInpatMedRec_Item[] objItemContent;
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        objItemContent = m_objGetContentFromItemArr(new string[] { "修正诊断医师签名", "初步诊断医师签名" });
        //        if (objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
        //        {
        //            p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
        //         //   p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);

        //            p_intPosY += 40;
        //            //	m_mthPrintSign(ref p_intPosY,p_objGrp,p_fntNormalText);
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            //p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
        //            //p_objGrp.DrawString("签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
        //            p_intPosY += 20;
        //            //if (objItemContent[1] != null)
        //            //    if (objItemContent[1].m_strItemContent != null)
        //            //    {
        //            //        m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[1].m_strItemContent, (objItemContent[1] == null ? "<root />" : objItemContent[1].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent[1] != null);
        //            //        m_mthAddSign2("签名：", m_objPrintContext1.m_ObjModifyUserArr);
        //            //    }
        //            if (objItemContent[0] != null)
        //                if (objItemContent[0].m_strItemContent != null)
        //                {
        //                    m_objPrintContext2.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent, (objItemContent[0] == null ? "<root />" : objItemContent[0].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent[0] != null);
        //                    m_mthAddSign2("签名：", m_objPrintContext2.m_ObjModifyUserArr);
        //                }
        //            //m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);

        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
        //        {
        //            //if (objItemContent[1] != null)
        //            //    if (objItemContent[1].m_strItemContent != null)
        //            //        m_objPrintContext1.m_mthPrintLine(320,m_intRecBaseX+30,p_intPosY,p_objGrp);
        //            //if (objItemContent[0] != null)
        //            //    if (objItemContent[0].m_strItemContent != null)
        //            //        m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+400,p_intPosY,p_objGrp);
        //          //  p_objGrp.DrawString("签名：" + (objItemContent[1] == null ? "" : (objItemContent[1].m_strItemContent == null ? "" : objItemContent[1].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
        //            p_objGrp.DrawString("签名：" + (objItemContent[0] == null ? "" : (objItemContent[0].m_strItemContent == null ? "" : objItemContent[0].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
        //            m_blnHaveMoreLine = false;

        //            p_intPosY += 20;
        //            return;
        //            // intLine++;

        //        }

        //        if (m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            p_intPosY += 20;
        //            //m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);
        //            m_blnHaveMoreLine = false;
        //        }
        //    }

        //    //private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    //{
        //    //    if (m_hasItems == null)
        //    //        return;
        //    //    p_intPosY += 20;
        //    //    p_objGrp.DrawString("签名：" + (objItemContent[3] == null ? "" : (objItemContent[3].m_strItemContent == null ? "" : objItemContent[3].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
        //    //    p_objGrp.DrawString("签名：" + (objItemContent[2] == null ? "" : (objItemContent[2].m_strItemContent == null ? "" : objItemContent[2].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);

        //    //}

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext1.m_mthRestartPrint();
        //        m_objPrintContext2.m_mthRestartPrint();
        //        m_blnHaveMoreLine = true;
        //        m_blnIsFirstPrint = true;
        //    }
        //}

        #endregion

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
		/// <summary>
		/// 打印画图
		/// </summary>
		internal class clsPrintInPatMedRecPic4 : clsInpatMedRecPrintBase.clsIMR_PrintLineBase
		{
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intCurrentPic = 0;
			public static bool m_blnIsPrinted = false;
			public bool m_blnMustPrinted = false;
            public clsPrintInPatMedRecPic4(bool p_blnMustPrinted)
			{
				m_blnMustPrinted = p_blnMustPrinted;
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || m_objPrintInfo.m_objContent.m_objPics == null|| m_objPrintInfo.m_objContent.m_objPics.Length < 1 || m_blnIsPrinted == true)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				m_blnHaveMoreLine = false;
				if(m_blnIsFirstPrint)
				{
					int intPicHeight = m_objPrintInfo.m_objContent.m_objPics[0].intHeight;
					int intPicWidth = m_objPrintInfo.m_objContent.m_objPics[0].intWidth;

					if(p_intPosY+intPicHeight>844)
					{
						m_blnHaveMoreLine = false;
						if(m_blnMustPrinted)
						{
							p_intPosY += intPicHeight;
							m_blnHaveMoreLine = true;
						}
						return;
					}
					else
					{
						p_intPosY += 20;
						int intLeft = m_intRecBaseX+10;
						for(int i=m_intCurrentPic;i<m_objPrintInfo.m_objContent.m_objPics.Length;i++)
						{					
							System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[i].m_bytImage);
							Image imgPrint = new Bitmap(objStream);

							p_objGrp.DrawImage(imgPrint,intLeft,p_intPosY,m_objPrintInfo.m_objContent.m_objPics[i].intWidth,m_objPrintInfo.m_objContent.m_objPics[i].intHeight);
							intLeft += m_objPrintInfo.m_objContent.m_objPics[i].intWidth+10;
							intPicHeight = Math.Max(intPicHeight,m_objPrintInfo.m_objContent.m_objPics[i].intHeight);
						
							//还有图片要打
							if(i+1<m_objPrintInfo.m_objContent.m_objPics.Length)
							{
								//图片超过一行
								if((int)enmRectangleInfo.RightX - intLeft < intPicWidth)
								{
									m_blnHaveMoreLine = true;
									p_intPosY += intPicHeight;
									intLeft = m_intRecBaseX+10;
									m_intCurrentPic = i + 1;
									return;										
								}
							}
						}
					}
					p_intPosY += intPicHeight+20;
					m_blnIsFirstPrint = false;	
				}
				m_blnIsPrinted = true;
			}
			public override void m_mthReset()
			{
				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				//打印预览或者打印后都得重置
				m_intCurrentPic = 0;

				m_blnIsPrinted = false;
			}
		}
		
}
