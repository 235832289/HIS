using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 中期妊娠引产手术记录打印工具类
	/// </summary>
	public class clsIMR_GestationMisbirth_1PrintTool : clsInpatMedRecPrintBase
	{
		public clsIMR_GestationMisbirth_1PrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
		}




		
		
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			#region Define
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strSpecialTitle = "";
			private string m_strTitle = "";
			private string m_strText = "";
			private string m_strTextXml = "";
			private bool m_blnNoContent = false;
			private bool m_blnNoPrint = true;
			private clsInpatMedRec_Item m_objItemContent = null;

			private int m_intPrintXPos = 0;
			private int m_intPrintwidth = 0;
			#endregion

			public clsPrintInPatMedRecItem()
			{
				m_intPrintXPos = m_intRecBaseX;
				m_intPrintwidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnNoContent == true && m_blnNoPrint == true || m_hasItems == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "" && m_objItemContent != null)
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intPrintXPos+10,p_intPosY);
						p_intPosY += 30;
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent.m_strItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent.m_strItemContentXml==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						//m_mthAddSign(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 30;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_BurnSuergeryPrintTool.m_fotItemHead,Brushes.Black,m_intPrintXPos+300,p_intPosY);
							p_intPosY += 30;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						//m_mthAddSign(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine(m_intPrintwidth,m_intPrintXPos+50,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine(m_intPrintwidth+40,m_intPrintXPos+10,p_intPosY,p_objGrp);
					p_intPosY += 30;

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
			/// <summary>
			/// 设置选择项的打印
			/// </summary>
			/// <param name="p_strKeyArr"></param>
			public void m_mthSetCheckPrintValue(string[] p_strKeyArr)
			{
				if(p_strKeyArr == null )
				{
				
					return;
				}
				//判断对应子段是否有内容
				if(m_blnHavePrintInfo(p_strKeyArr)==true)
					m_mthMakeCheckText(p_strKeyArr,ref m_strText,ref m_strTextXml);
			}


			/// <summary>
			/// 设置多项打印内容
			/// </summary>
			/// <param name="p_strKeyArr">打印内容的哈希键数组</param>
			/// <param name="p_strTitleArr">小标题数组(即对应于窗体Lable但不存储于数据库的需打印的内容)</param>
			public void m_mthSetPrintValue(string[] p_strKeyArr,string[] p_strTitleArr)
			{
				if(p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
				{
					m_blnNoContent = true;
					return;
				}
				m_blnNoPrint = false;
				if(m_blnHavePrintInfo(p_strKeyArr) == true)
					m_mthMakeText(p_strTitleArr,p_strKeyArr,ref m_strText,ref m_strTextXml);
			}
			/// <summary>
			/// 设置单项打印内容
			/// </summary>
			/// <param name="p_strKey">哈希键</param>
			/// <param name="p_strTitle">小标题</param>
			public void m_mthSetPrintValue(string p_strKey,string p_strTitle)
			{
				if(m_hasItems != null && p_strKey != null)
					if(m_hasItems.Contains(p_strKey))
						m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
				m_strTitle = p_strTitle;
			}
			/// <summary>
			/// 设置大标题如“体格检查”
			/// </summary>
			/// <param name="p_strTitle"></param>
			public void m_mthSetSpecialTitleValue(string p_strTitle)
			{
				m_strSpecialTitle = p_strTitle;
			}
		}

		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;

		protected override void m_mthSetPrintLineArr()
		{
			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("中期妊娠引产记录",290),
								
							    		   m_objPrintMultiItemArr[0],
				                         new clsPrintRemark(),
				                         m_objPrintMultiItemArr[1]
										 
			});			
		}

		


		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{			            
        //}

        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        p_objGrp.DrawString("广州市第一人民医院",p_fntNormalText,Brushes.Black,m_intRecBaseX+290,p_intPosY-30) ;
        //        p_intPosY += 20;
        //        p_objGrp.DrawString("中  期  妊  娠  引  产  记  录",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY);    
        //        p_intPosY += 50;		
        //        p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY );	
        //        p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intRecBaseX+180,p_intPosY);	
        //        p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);	
        //        p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
        //        p_intPosY += 30;
        //        if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //        {
        //            p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);			
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
        //        }			
		
        //        p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				
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
		//		p_intPosY +=20;

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}

	

	
		protected override void m_mthSetSubPrintInfo()
		{
	

			#region 中期引产记录
	
		//	m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"\n既往史： 病历有","既往史>>麻疹肺炎","既往史>>百日咳","既往史>>哮喘","既往史>>肺炎","既往史>>肺结核","既往史>>鼻窦炎","既往史>>过敏性鼻炎"});
		
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"手术日期","术前阴道准备>>次数","术前阴道准备>>次数"},new string[]{"\n手术时期","\n术前阴道准备","#次"});
			m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"       引产方法：","引产方法>>药物","引产方法>>水囊"});
		
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","穿刺引产手术步聚>>药物名称","穿刺引产手术步聚>>药物剂量","穿刺引产手术步聚>>药物剂量","穿刺引产手术步聚>>稀释液及量","穿刺引产手术步聚>>稀释液及量","穿刺引产手术步聚>>用药批号"},new string[]{"\n穿刺引产手术步聚:","\n药物名称:","    剂量$$","#mg","         稀释液及量$$","#ml","    用药批号"});
		
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","","穿刺引产手术步聚>>腹部穿刺>>部位","穿刺引产手术步聚>>号套针","穿刺引产手术步聚>>号套针","穿刺引产手术步聚>>穿刺次数","穿刺引产手术步聚>>穿刺次数","穿刺引产手术步聚>>抽出羊水","穿刺引产手术步聚>>抽出羊水","穿刺引产手术步聚>>色泽"},new string[]{"\n给药途径：腹部羊膜空穿刺$$","\n腹部穿刺:$$"," 部位:$$","$$","#    号套针","    穿刺:$$","#次","    抽出羊水:$$","#毫升","    色泽:$$"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"穿刺引产手术步聚>>其他","","放置水囊手术步骤>>经阴道宫颈","放置水囊手术步骤>>经阴道宫颈","放置水囊手术步骤>>插入深度","放置水囊手术步骤>>插入深度","放置水囊手术步骤>>注入生理盐水（+美兰）","放置水囊手术步骤>>注入生理盐水（+美兰）","放置水囊手术步骤>>阴道置纱布","放置水囊手术步骤>>阴道置纱布"},new string[]{"\n其他:$$","\n放置水囊手术步骤:$$","\n经阴道宫颈：$$","#号导管","    插入$$","#cm","    注入生理盐水（+美兰）$$","#ml","\n阴道置纱布:$$","#块$$"});
		
			m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"\n手术经过:","手术经过>>顺利","手术经过>>较困难","手术经过>>困难"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"手术经过>>出血","手术经过>>出血","取水囊时间","取水囊时间>>取出情况"},new string[]{"    出血$$","#ml","\n取水囊时间:","    取出情况:"});
			
			#endregion

			
            
	
			#region 医师签名
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"手术者"},new string[]{"\n                                                                                                                           手术者:  $$"});
			

			#endregion


			
		}


		private void m_mthInitPrintLineArr()
		{
			//			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[7];
			//			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
			//				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();
			//
			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[2];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

		}

	
		/// <summary>
		/// 取水囊时间>>备注
		/// </summary>
		private class clsPrintRemark : clsIMR_PrintLineBase
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
					if(m_hasItems.Contains("备注"))
						objItemContent = m_hasItems["备注"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					

					p_objGrp.DrawString("备注：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 30;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("备注：",m_objPrintContext.m_ObjModifyUserArr);


					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+60,p_intPosY,p_objGrp);

					p_intPosY += 30;

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

	
	
	



	







	
	}
}
