using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
    /// 负压吸宫钳刮术手术记录打印工具类
	/// </summary>
	public class clsIMR_GestationMisbirth_3PrintTool : clsInpatMedRecPrintBase
	{
		public clsIMR_GestationMisbirth_3PrintTool(string p_strTypeID) : base(p_strTypeID)
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
						p_intPosY += 20;
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent.m_strItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent.m_strItemContentXml==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						//m_mthAddSign(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 20;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_BurnSuergeryPrintTool.m_fotItemHead,Brushes.Black,m_intPrintXPos+300,p_intPosY);
							p_intPosY += 40;
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
										  new clsPrintPatientFixInfo("负压吸宫钳刮术手术记录",260),
										//  new clsPrintInPatMedRecCaseMain(),
					                   //   new clsPrintMisbirthBasic(),
							    		   m_objPrintMultiItemArr[0],
				                         new clsPrintRemark(),
				                         m_objPrintMultiItemArr[1]
										 
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
        //        p_intPosY = 80;
        //        p_objGrp.DrawString("负压吸宫钳刮术手术记录",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
		     
        //        p_intPosY += 20;
				
        //        System.Drawing.RectangleF theRectangle=new RectangleF(new System.Drawing.PointF(m_intPatientInfoX+10,p_intPosY),new System.Drawing.SizeF(150,40));
				
        //        p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,theRectangle);
        //        theRectangle.X=theRectangle.X+155;
        //        p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,theRectangle);
        //        theRectangle.X=theRectangle.X+155;
        //        theRectangle.Width=theRectangle.Width+100;
        //        p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,theRectangle);
        //        theRectangle.X=theRectangle.X+155;
        //        p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,theRectangle);
        //        theRectangle.Y += 20;
        //        theRectangle.X=m_intPatientInfoX+10;
        //        theRectangle.Width=theRectangle.Width+100;
        //        if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //        {
        //            p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,theRectangle);			
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,theRectangle);
        //        }			
        //        theRectangle.X=theRectangle.X+250;
        //        p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,theRectangle);
				
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
        //        p_intPosY =(int)theRectangle.Y+20;
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
	

			#region 
	
		//	m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"\n既往史： 病历有","既往史>>麻疹肺炎","既往史>>百日咳","既往史>>哮喘","既往史>>肺炎","既往史>>肺结核","既往史>>鼻窦炎","既往史>>过敏性鼻炎"});
		
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"孕/产次1","孕/产次2","孕/产次2","末次妊娠终止日期","末次妊娠结局"},new string[]{"孕/产次: $$","#/$$","$$","  末次妊娠终止日期:","\n末次妊娠结局:"});
			m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"  哺乳:","哺乳>>否","哺乳>>是"});
		
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"月经史>>经期","月经史>>周期"},new string[]{"\n月经史:经期/周期 $$","/$$"});
			m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"  经量:","月经史>>经量>>多","月经史>>经量>>中","月经史>>经量>>少"});
			m_objPrintMultiItemArr[0].m_mthSetCheckPrintValue(new string[]{"  经痛:","月经史>>经痛>>无","月经史>>经痛>>轻","月经史>>经痛>>重"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"月经史>>末次月经","避孕史","既往史","药物过敏史"},new string[]{"  末次月经:","\n避孕史:","\n既往史:","     药物过敏史:"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体格检查>>血压1","体格检查>>血压2","体格检查>>血压2","体格检查>>脉搏","体格检查>>脉搏","体格检查>>体温","体格检查>>体温","体格检查>>心","体格检查>>肺"},new string[]{"\n体格检查: 血压:$$","/$$","# mmHg","  脉搏:","#次/分","  体温:","#C","  心:","  肺:"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"妇科检查>>外阴","妇科检查>>阴道","妇科检查>>宫颈","妇科检查>>子宫大小","妇科检查>>子宫大小","妇科检查>>附件"},new string[]{"\n妇科检查: 外阴:","  阴道","  宫颈","\n                  子宫大小","#周","  附件:"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"辅助检查>>血常规","辅助检查>>尿妊娠试验","辅助检查>>尿妊娠试验","辅助检查>>滴虫","辅助检查>>念珠菌","辅助检查>>念珠菌","辅助检查>>清洁度","辅助检查>>清洁度","辅助检查>>B超胚囊平均直径","辅助检查>>B超胚囊平均直径"},new string[]{"\n辅助检查: 血常规:","  尿妊娠试验:","#性","  滴虫:","  念珠菌:","#性","\n                  清洁度:","#度","  B超胚囊平均直径:","#mm"});
		   
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"检查者 签字"},new string[]{"检查者 :$$"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"手术日期"},new string[]{"\n手术日期:"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"术时情况>>子宫","术时情况>>子宫","术时情况>>子宫大小","术时情况>>宫腔深度>>术前","术时情况>>宫腔深度>>术前","术时情况>>宫腔深度>>术后","术时情况>>宫腔深度>>术后","术时情况>>扩张宫颈1","术时情况>>扩张宫颈2","术时情况>>扩张宫颈2","术时情况>>吸管号>>负压","术时情况>>吸管号>>量","术时情况>>吸管号>>量","术时情况>>吸出物"},new string[]{"\n术时情况: 子宫","#位","  子宫大小:","  宫腔深度: 术前","#cm "," 术后","#cm ","  扩张宫颈:","号至$$","#号","\n                  吸管号:$$","  负压:","#mmHg","  吸出物:"});

            m_objPrintMultiItemArr[1].m_mthSetCheckPrintValue(new string[] { "\n                  绒毛:", "术时情况>>绒毛>>见", "术时情况>>绒毛>>未见" });
			m_objPrintMultiItemArr[1].m_mthSetCheckPrintValue(new string[]{"   胚囊:","术时情况>>胚囊>>未见","术时情况>>胚囊>>见"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"术时情况>>吸出胚囊大小","术时情况>>出血量","术时情况>>出血量"},new string[]{"   吸出胚囊大小:"," 出血量","#ml"});
            m_objPrintMultiItemArr[1].m_mthSetCheckPrintValue(new string[]{"   刮宫:","术时情况>>刮宫>>无","术时情况>>刮宫>>有"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"术时情况>>术中用药","术时情况>>术中特殊情况"},new string[]{"\n                  术中用药:","\n                  术中特殊情况:"});
            m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[] { "处理>>药物", "处理>>休假天数", "处理>>休假天数", "处理>>人流后放置宫内节育器>>名称", "处理>>人流后放置宫内节育器>>型号", "处理>>人流后放置宫内节育器>>规格", "处理>>人流后放置宫内节育器>>其他", "手术者 签字" }, new string[] { "\n处理: 药物: ", "\n           休假:", "#天", "\n           人流后放置宫内节育器", "  型号:", "  规格:", "  其他", "\n手术者:  " });
          
			
			
			
			#endregion

			
            
	
			#region 医师签名
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"手术者  签字"},new string[]{"手术者 :$$"});
			

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
		/// 辅助检查>>诊断
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
					if(m_hasItems.Contains("辅助检查>>诊断"))
						objItemContent = m_hasItems["辅助检查>>诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					

					p_objGrp.DrawString("诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+80,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
					m_mthAddSign2("诊断：",m_objPrintContext.m_ObjModifyUserArr);


					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+130,p_intPosY,p_objGrp);

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
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    PointF m_fReturnPoint = new PointF(340f,40f);
        //    Font m_fotSmallFont = new Font("SimSun",12);
        //    SolidBrush m_slbBrush = new SolidBrush(Color.Black);
        //    e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_fReturnPoint);
        //}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
	}
}
