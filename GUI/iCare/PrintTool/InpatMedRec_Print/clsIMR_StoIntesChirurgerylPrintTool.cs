using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Resources ;

namespace iCare
{
	/// <summary>
	/// 胃肠外科病案记录打印工具类
	/// </summary>
	public class clsIMR_StoIntesChirurgerylPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_StoIntesChirurgerylPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;

		protected override void m_mthSetPrintLineArr()
		{
			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("胃肠外科住院病历",295),
										  m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],
										  m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[1],
										  m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],
										  m_objPrintMultiItemArr[4],
										  m_objPrintOneItemArr[2],
										  m_objPrintOneItemArr[3],m_objPrintOneItemArr[4],
										  m_objPrintOneItemArr[5],m_objPrintSignArr[0],m_objPrintSignArr[1],
                    m_objPrintOneItemArr[6], m_objPrintSignArr[2],  m_objPrintOneItemArr[7],  m_objPrintSignArr[3]
										  
									  });
		}

		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[8];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[5];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();
 
			m_objPrintSignArr = new clsPrintInPatMedRecSign[4];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}

		protected override void m_mthSetSubPrintInfo()
		{
			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("专科情况","专科情况：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("诊断","诊断：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("治疗计划","治疗计划：");
			m_objPrintOneItemArr[5].m_mthSetPrintValue("最后诊断","最后诊断：");
			//m_objPrintOneItemArr[6].m_mthSetPrintValue("体格检查"," ");
			#endregion	
		
			#region 既往史
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","既往史>>心脏病","既往史>>心脏病",
																			"既往史>>高血压","既往史>>高血压",
																			"既往史>>肝炎","既往史>>肝炎",
																			"既往史>>肺结核","既往史>>肺结核",
																			"既往史>>肾病","既往史>>肾病",
																			"既往史>>糖尿病","既往史>>糖尿病"},
														 new string[]{"既往史：","心脏病(","#)",
																	  "高血压(","#)",
																	  "肝炎(","#)","肺结核(","#)","肾病(","#)","糖尿病(","#)"});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"既往史>>药物过敏","既往史>>药物过敏",
																		 "既往史>>食物过敏","既往史>>食物过敏",
																		 "既往史>>手术史","既往史>>手术史",
																		 "既往史>>外伤史","既往史>>外伤史",
																		 "既往史>>其它"},
														 new string[]{"\n                药物过敏(","#)",
																	  "食物过敏(","#)",
																	  "手术史(","#)",
																	  "外伤史(","#)",
																	  "其它："});

			#endregion

			#region 个人史
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","个人史>>嗜烟","个人史>>嗜烟",
																		 "个人史>>嗜酒","个人史>>嗜酒",
																		 "个人史>>其它"},
				new string[]{"个人史：","嗜烟(","#)",
								"嗜酒(","#)",
								"其它："});

			#endregion
		
			#region 月经史
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","月经史>>末次月经时间",
																		 "月经史>>月经周期","月经史>>月经周期"},
				new string[]{"月经史：","末次月经时间(或绝经年龄",
								"#       月经周期","#天)"});

			#endregion
		
			#region 家族史
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"","家族史>>糖尿病","家族史>>糖尿病",
																		 "家族史>>精神病","家族史>>精神病",
																		 "家族史>>其它"},
				new string[]{"家族史：","糖尿病(","#)",
								"精神病(","#)",
								"其它："});

			#endregion
		
			#region 体格检查
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"","体格检查>>T","体格检查>>T",
																		 "体格检查>>P","体格检查>>P",
																		 "体格检查>>R","体格检查>>R",
																		 "体格检查>>BP","体格检查>>BP",
																		 "体格检查>>Kpa","体格检查>>Kpa","体格检查"},
				new string[]{"体格检查：","T","#℃",
								"P","#分/次",
								"R","#分/次",
								"BP","#/","#","#Kpa","\n"});

			#endregion
		
			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"医生签字"},new string[]{"医  生签字："});
			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"主治医生签字"},new string[]{"主治医生签字："});
			//			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"康复治疗计划>>医师","康复治疗计划>>时间"},new string[]{"医师：","日期："});
			#endregion

            #region 修正/补充诊断以及签名
            m_objPrintOneItemArr[6].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[7].m_mthSetPrintValue("补充诊断", "补充诊断：");
            m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            m_objPrintSignArr[3].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            #endregion
		}

		#region Print Class

		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
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

			public clsPrintInPatMedRecItem()
			{}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnNoContent == true && m_blnNoPrint == true)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "")
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 20;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_HerbalismPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_intPosY += 40;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
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

		/// <summary>
		/// 签名和日期
		/// </summary>
		private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] objSignContent = null;
			private string[] m_strTitleArr = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(objSignContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 40;
				for(int i=0; i<objSignContent.Length; i++)
				{
					if(m_strTitleArr[i].IndexOf("日期") < 0)
					{
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
				}
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
			/// <summary>
			/// 设置签名和日期值
			/// </summary>
			/// <param name="p_strkeyArr">值</param>
			/// <param name="p_strTitleArr">标题</param>
			public void m_mthSetPrintSignValue(string[] p_strkeyArr,string[] p_strTitleArr)
			{
				if(p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
					return;
				objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
				m_strTitleArr = p_strTitleArr;
			}

		}

		#endregion
	}
}
