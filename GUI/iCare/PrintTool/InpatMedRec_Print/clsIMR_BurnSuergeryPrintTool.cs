using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
	/// <summary>
	/// 外科住院病历打印工具类
	/// </summary>
	public class clsIMR_BurnSuergeryPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_BurnSuergeryPrintTool(string p_strTypeID) :base(p_strTypeID)
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
										  new clsPrintPatientFixInfo("烧伤外科住院病历",290),
										  new clsPrintSubTime(),
										  m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],m_objPrintOneItemArr[2],m_objPrintOneItemArr[3],
										  m_objPrintOneItemArr[4],m_objPrintOneItemArr[5],m_objPrintOneItemArr[6],
										  m_objPrintMultiItemArr[0],
										  new clsPrintInPatMedRecPic(),
										  new clsPrintSubInf(),m_objPrintOneItemArr[7],m_objPrintSignArr[0],m_objPrintOneItemArr[8],m_objPrintSignArr[1]
									  });
		}

		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[9];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[1];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

            m_objPrintSignArr = new clsPrintInPatMedRecSign[2];
            for (int k3 = 0; k3 < m_objPrintSignArr.Length; k3++)
                m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}




		protected override void m_mthSetSubPrintInfo()
		{
			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("烧伤原因与经过","烧伤原因与经过(致伤物、温度、受伤空间、衣着、灭火方法)：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("入院前病情及处理","入院前病情及处理(处理开始时间，病情，抢救抗休克、创面处理等)：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("后送(工具、时间、途中处理)","后送(工具、时间、途中处理)：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("合并伤、中毒","合并伤、中毒：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("过去史","过去史：");
			m_objPrintOneItemArr[5].m_mthSetPrintValue("个人史","个人史(含月经、生育史)：");
			m_objPrintOneItemArr[6].m_mthSetPrintValue("家族史","家族史：");
            m_objPrintOneItemArr[7].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[8].m_mthSetPrintValue("补充诊断", "补充诊断：");
			#endregion	
            
            #region 修正/补充诊断以及签名
            m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            #endregion

			#region 体检
			m_objPrintMultiItemArr[0].m_mthSetSpecialTitleValue("体 检");
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体检>>体重","体检>>体温", "体检>>脉搏","体检>>呼吸", "体检>>血压"},
				new string[]{"体重：","体温：","脉搏：","呼吸：","血压："});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体检>>发育","体检>>营养", "体检>>肤色","体检>>发绀","体检>>意识","体检>>表情", "体检>>口渴"},
				new string[]{"\n发育：","营养：","肤色：","发绀：","\n意识：","表情：","口渴："});
			
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体检>>末梢微血管充盈","体检>>桡动脉搏动","体检>>足背动脉搏动"},
				new string[]{"\n末梢微血管充盈：","桡动脉搏动：","足背动脉搏动："});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体检>>头面颈","体检>>胸部","体检>>腹部", "体检>>脊柱四肢"},
				new string[]{"\n头面颈：","\n胸部：","\n腹部：","\n脊柱四肢："});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体检>>特殊部位煤伤>>角膜","体检>>特殊部位煤伤>>耳廓","体检>>特殊部位煤伤>>鼻毛烧焦","体检>>特殊部位煤伤>>声嘶","体检>>特殊部位煤伤>>呼吸道梗阻"},
				new string[]{"\n特殊部位煤伤：","角膜：","耳廓：","鼻毛烧焦：","\n声嘶：","呼吸道梗阻："});

			#endregion

			#region 初步诊断
//			m_objPrintMultiItemArr[1].m_IntPrintXPos = 360;
//			m_objPrintMultiItemArr[1].m_IntPrintwidth = 200;
//			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","","初步诊断>>烧伤总面积"
//																		 ,"","初步诊断>>Ⅰ度","","初步诊断>>浅Ⅱ度"
//																	 ,"初步诊断>>深Ⅱ度","","","初步诊断>>Ⅲ度"
//																	 ,"","","",""},
//				new string[]{"\n初步诊断：","\n　 烧伤原因：","\n　 烧伤总面积：","#%",
//								"\n　 Ⅰ度：","#%","\n　 浅Ⅱ度：","#%","\n　 深Ⅱ度：","#%","\n　 Ⅲ度：","#%",
//								"\n　 呼吸道烧伤：","\n　 合并伤、中毒：","\n　 其他：","\n　 签  名："});
//
//			#endregion
//
//			#region 最后诊断
//			m_objPrintMultiItemArr[2].m_IntPrintXPos = 590;
//			m_objPrintMultiItemArr[2].m_IntPrintwidth = 120;
//			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","最后诊断>>烧伤原因","最后诊断>>烧伤总面积","最后诊断>>烧伤总面积"
//																		 ,"最后诊断>>Ⅰ度","最后诊断>>Ⅰ度","最后诊断>>浅Ⅱ度","最后诊断>>浅Ⅱ度"
//																		 ,"最后诊断>>深Ⅱ度","最后诊断>>深Ⅱ度","最后诊断>>Ⅲ度","最后诊断>>Ⅲ度"
//																		 ,"最后诊断>>呼吸道烧伤","最后诊断>>合并伤、中毒","最后诊断>>其他","最后诊断>>签名"},
//				new string[]{"\n最后诊断：","\n","\n","#%","\n","#%","\n","#%","\n","#%","\n","#%","\n","\n","\n","\n"});

			#endregion
			
		}


		#region print Class

		
		/// <summary>
		/// 项目打印
		/// </summary>
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
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
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
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
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
		/// 烧伤时间与入院时间
		/// </summary>
		private class clsPrintSubTime : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] m_objContentArr;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_objContentArr = m_objGetContentFromItemArr(new string[]{"烧伤时间","入院时间","伤后天数","伤后时数"});
				if(m_objContentArr == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 10;
				if(m_objContentArr[0] != null)
					if(m_objContentArr[0].m_strItemContent != null && m_objContentArr[0].m_strItemContent != "")
						p_objGrp.DrawString("烧伤时间：" +m_mthSetDateTimeFormat( m_objContentArr[0].m_strItemContent),p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
				p_intPosY += 25;
				if(m_objContentArr[1] != null)
					if(m_objContentArr[1].m_strItemContent != null && m_objContentArr[1].m_strItemContent != "")
						p_objGrp.DrawString("入院时间：" +m_mthSetDateTimeFormat( m_objContentArr[1].m_strItemContent),p_fntNormalText,Brushes.Black,m_intRecBaseX+30,p_intPosY);
				p_objGrp.DrawString("(伤后",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				if(m_objContentArr[2] != null)
					if(m_objContentArr[2].m_strItemContent != null && m_objContentArr[2].m_strItemContent != "")
						p_objGrp.DrawString(m_objContentArr[2].m_strItemContent + "天",p_fntNormalText,Brushes.Black,m_intRecBaseX+360,p_intPosY);
				if(m_objContentArr[3] != null)
					if(m_objContentArr[3].m_strItemContent != null && m_objContentArr[3].m_strItemContent != "")
						p_objGrp.DrawString(m_objContentArr[3].m_strItemContent + "小时)",p_fntNormalText,Brushes.Black,m_intRecBaseX+410,p_intPosY);
				p_intPosY += 25;
				m_blnHaveMoreLine = false;
			}
			public override void m_mthReset()
			{
			
			}
			private string m_mthSetDateTimeFormat(string p_strDataTime)
			{
				DateTime dtTime = DateTime.Parse(p_strDataTime);
				return dtTime.ToString("yyyy年MM月dd日") + dtTime.Hour + "时" +dtTime.Minute + "分";
			}
		}

	

		/// <summary>
		/// 表格,初步诊断,最后诊断打印
		/// </summary>
		private class clsPrintSubInf : clsIMR_PrintLineBase
		{
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private clsInpatMedRec_Item[] m_objItemArr = null;
			private clsInpatMedRec_Item[] m_objFirstArr = null;
			private clsInpatMedRec_Item[] m_objLastArr = null;
			private int m_intYPos = 10;
			private int m_intXPos = (int)enmRectangleInfo.LeftX+10;
			private bool[] m_blnPrintCol = new Boolean[]{true,true,true,true,true,true,true};

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsFirstPrint)
				{
					m_objItemArr = m_objGetContentFromItemArr(new string[]{"伤员各部烧伤面积>>头颈部","伤员各部烧伤面积>>躯干","伤员各部烧伤面积>>双上臂","伤员各部烧伤面积>>双前臂","伤员各部烧伤面积>>双手","伤员各部烧伤面积>>双臂","伤员各部烧伤面积>>腿部"});
					m_objFirstArr = m_objGetContentFromItemArr(new string[]{"初步诊断>>烧伤原因","初步诊断>>烧伤总面积","初步诊断>>Ⅰ度","初步诊断>>浅Ⅱ度","初步诊断>>深Ⅱ度","初步诊断>>Ⅲ度","初步诊断>>呼吸道烧伤","初步诊断>>合并伤、中毒","初步诊断>>其他","初步诊断>>签名","初步诊断>>初步诊断日期"});
					m_objLastArr = m_objGetContentFromItemArr(new string[]{"最后诊断>>烧伤原因","最后诊断>>烧伤总面积","最后诊断>>Ⅰ度","最后诊断>>浅Ⅱ度","最后诊断>>深Ⅱ度","最后诊断>>Ⅲ度","最后诊断>>呼吸道烧伤","最后诊断>>合并伤、中毒","最后诊断>>其他","最后诊断>>签名","最后诊断>>最后诊断日期"});
					if(m_objItemArr == null && m_objFirstArr == null && m_objLastArr == null  || m_hasItems == null)
					{
						m_blnHaveMoreLine = false;
						return;
					}
				}
				#region Printting
				if(m_blnPrintCol[0] == true)
				{
					if(m_blnCheckBottom(ref p_intPosY,p_objGrp, p_fntNormalText,130))
					{
						m_intYPos = 155;
						return;
					}
					else if(m_blnIsFirstPrint == true)
					{
						m_mthDrawTitle(p_intPosY, p_objGrp, p_fntNormalText);
						p_objGrp.DrawString("初步诊断：",p_fntNormalText,Brushes.Black,m_intXPos+360,p_intPosY+5);
						p_objGrp.DrawString("最后诊断：",p_fntNormalText,Brushes.Black,m_intXPos+590,p_intPosY+5);
						p_intPosY += 45;
					}
					p_objGrp.DrawString("头     6",p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+2);
					p_objGrp.DrawString("颈     3",p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+52);
					p_objGrp.DrawString("}",new Font("SimSun",44),Brushes.Black,m_intXPos+60,m_intYPos+4);
					p_objGrp.DrawString("9＋(12－年龄)",p_fntNormalText,Brushes.Black,m_intXPos+85,m_intYPos+27);
					p_objGrp.DrawString((m_objItemArr[0] == null?"":(m_objItemArr[0].m_strItemContent == null?"":m_objItemArr[0].m_strItemContent)),p_fntNormalText,Brushes.Black,m_intXPos+240,m_intYPos+27);
					p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+75);
					p_objGrp.DrawLine(Pens.Black,m_intXPos+200,m_intYPos,m_intXPos+200,m_intYPos+75);
					p_objGrp.DrawLine(Pens.Black,m_intXPos+300,m_intYPos,m_intXPos+300,m_intYPos+75);
					string strTemp = "烧伤原因：";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp,(m_objFirstArr[0] == null?"":m_objFirstArr[0].m_strItemContent),(m_objLastArr[0] == null?"":m_objLastArr[0].m_strItemContent));
					strTemp = "烧伤总面积：";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp,(m_objFirstArr[1] == null?"":m_objFirstArr[1].m_strItemContent),(m_objLastArr[1] == null?"":m_objLastArr[1].m_strItemContent));
					m_intYPos += 75;
					m_blnPrintCol[0] = false;
				}
				string[] strTempArr = {"","Ⅰ度：","浅Ⅱ度：","深Ⅱ度：","Ⅲ度：","呼吸道烧伤："};
				string[] strTextArr = {"","躯  干27(含会阴1％)","双上臂 7","双前臂 6","双  手 5","双  臂 5"};
				for(int i=1;i<m_blnPrintCol.Length-1;i++)
				{
					if(m_blnPrintCol[i] == true)
					{
						if(m_blnCheckBottom(ref p_intPosY,p_objGrp, p_fntNormalText,40))
						{
							p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos+300,m_intYPos);
							m_intYPos = 155;
							return;
						}
						else if(m_blnIsFirstPrint == true)
							m_mthDrawTitle(p_intPosY, p_objGrp, p_fntNormalText);
						p_objGrp.DrawString(strTextArr[i],p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+2);
						p_objGrp.DrawString((m_objItemArr[i] == null?"":(m_objItemArr[i].m_strItemContent == null?"":m_objItemArr[i].m_strItemContent)),p_fntNormalText,Brushes.Black,m_intXPos+240,m_intYPos+2);
						p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+25);
						p_objGrp.DrawLine(Pens.Black,m_intXPos+200,m_intYPos,m_intXPos+200,m_intYPos+25);
						p_objGrp.DrawLine(Pens.Black,m_intXPos+300,m_intYPos,m_intXPos+300,m_intYPos+25);
						m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTempArr[i],(m_objFirstArr[i+1] == null?"":m_objFirstArr[i+1].m_strItemContent),(m_objLastArr[i+1] == null?"":m_objLastArr[i+1].m_strItemContent));
						m_intYPos += 25;
						m_blnPrintCol[i] = false;
					}
				}
				if(m_blnPrintCol[6] == true)
				{
					if(m_blnCheckBottom(ref p_intPosY,p_objGrp, p_fntNormalText,75))
					{
						p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos+300,m_intYPos);
						m_intYPos = 155;
						return;
					}
					else if(m_blnIsFirstPrint == true)
						m_mthDrawTitle(p_intPosY, p_objGrp, p_fntNormalText);
					p_objGrp.DrawString("双大腿21",p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+2);
					p_objGrp.DrawString("双小腿13",p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+27);
					p_objGrp.DrawString("双  足 7",p_fntNormalText,Brushes.Black,m_intXPos,m_intYPos+52);
					p_objGrp.DrawString("}",new Font("SimSun",44),Brushes.Black,m_intXPos+60,m_intYPos+4);
					p_objGrp.DrawString("41-(12-年龄)",p_fntNormalText,Brushes.Black,m_intXPos+85,m_intYPos+27);
					p_objGrp.DrawString((m_objItemArr[6] == null?"":(m_objItemArr[6].m_strItemContent == null?"":m_objItemArr[6].m_strItemContent)),p_fntNormalText,Brushes.Black,m_intXPos+240,m_intYPos+27);
					p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+75);
					p_objGrp.DrawLine(Pens.Black,m_intXPos+200,m_intYPos,m_intXPos+200,m_intYPos+75);
					p_objGrp.DrawLine(Pens.Black,m_intXPos+300,m_intYPos,m_intXPos+300,m_intYPos+75);
					string strTemp3 = "合并伤、中毒：";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp3,(m_objFirstArr[7] == null?"":m_objFirstArr[7].m_strItemContent),(m_objLastArr[7] == null?"":m_objLastArr[7].m_strItemContent));
					strTemp3 = "其他：";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp3,(m_objFirstArr[8] == null?"":m_objFirstArr[8].m_strItemContent),(m_objLastArr[8] == null?"":m_objLastArr[8].m_strItemContent));
					strTemp3 = "签名：";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp3,(m_objFirstArr[9] == null?"":m_objFirstArr[9].m_strItemContent),(m_objLastArr[9] == null?"":m_objLastArr[9].m_strItemContent));
					strTemp3 = "";
					m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText,strTemp3,(m_objFirstArr[10] == null?"":m_mthSetDateTimeFormat(m_objFirstArr[10].m_strItemContent,true)),(m_objLastArr[10] == null?"":m_mthSetDateTimeFormat(m_objLastArr[10].m_strItemContent,false)));
					m_intYPos += 75;
					p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos+300,m_intYPos);
					m_blnPrintCol[6] = false;
				}
				p_intPosY = m_intYPos > p_intPosY ? m_intYPos+20 : p_intPosY+20;
				#endregion
				m_blnHaveMoreLine = false;
			}
			/// <summary>
			/// 输出日期打印格式
			/// </summary>
			/// <param name="p_strDataTime"></param>
			/// <param name="p_blnText"></param>
			/// <returns></returns>
			private string m_mthSetDateTimeFormat(string p_strDataTime,bool p_blnText)
			{
				if(p_strDataTime == null)
					return "";
				DateTime dtTime = DateTime.Parse(p_strDataTime);
				return dtTime.ToString("yyyy年MM月dd日") +( p_blnText ?dtTime.Hour + "时":"");
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
			/// <summary>
			/// 打印标题
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			private void m_mthDrawTitle(int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_intYPos = p_intPosY+10;
				RectangleF rtgf = new RectangleF(m_intXPos,m_intYPos,100,45);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos+300,m_intYPos);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+45);
				p_objGrp.DrawLine(Pens.Black,m_intXPos+100,m_intYPos,m_intXPos+100,m_intYPos+45);
				p_objGrp.DrawLine(Pens.Black,m_intXPos+200,m_intYPos,m_intXPos+200,m_intYPos+45);
				p_objGrp.DrawLine(Pens.Black,m_intXPos+300,m_intYPos,m_intXPos+300,m_intYPos+45);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+45,m_intXPos+300,m_intYPos+45);
				p_objGrp.DrawString("成人各部体表面积％",p_fntNormalText,Brushes.Black,rtgf);
				rtgf.X = m_intXPos+100;
				p_objGrp.DrawString("小儿各部体表面积％",p_fntNormalText,Brushes.Black,rtgf);
				rtgf.X = m_intXPos+200;
				p_objGrp.DrawString("伤员各部烧伤面积％",p_fntNormalText,Brushes.Black,rtgf);
				m_intYPos += 45;
				m_blnIsFirstPrint = false;
			}
			/// <summary>
			/// 检测是否需要换页
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			/// <param name="p_intHeight"></param>
			/// <returns></returns>
			private bool m_blnCheckBottom(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intHeight)
     		{
				if(m_intYPos+p_intHeight+20 > ((int)enmRectangleInfo.BottomY -50))
				{
					m_blnHaveMoreLine = true;
					m_blnIsFirstPrint = true;
					p_intPosY += 500;
					return true;
				}
				return false;
			}
			/// <summary>
			/// 诊断打印
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			/// <param name="p_strTextArr">标题</param>
			/// <param name="p_strFirstCont">初步诊断</param>
			/// <param name="p_strLastCont">最后诊断</param>
			private void m_mthPrintDioa(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText,string p_strFirstCont,string p_strLastCont)
			{
				if(p_strFirstCont == null)
					return;
				int intTemp = 0;
				RectangleF rtg = new RectangleF(m_intXPos+380,p_intPosY,200,20);
				string strText = p_strText+p_strFirstCont;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				rtg.Y = p_intPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				intTemp += Convert.ToInt32(rtg.Height);
			
				rtg = new RectangleF(m_intXPos+590,p_intPosY,140,20);
				strText = (p_strLastCont ==null?"":p_strLastCont);
				szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				rtg.Y = p_intPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				if(intTemp > Convert.ToInt32(rtg.Height))
					p_intPosY += intTemp;
				else
					p_intPosY += Convert.ToInt32(rtg.Height);
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
                if (objSignContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                p_intPosY += 40;
                for (int i = 0; i < objSignContent.Length; i++)
                {
                    if (m_strTitleArr[i].IndexOf("日期") < 0)
                    {
                        p_objGrp.DrawString(m_strTitleArr[i] + (objSignContent[i] == null ? "" : objSignContent[i].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                        p_intPosY += 20;
                    }
                    else
                    {
                        p_objGrp.DrawString(m_strTitleArr[i] + (objSignContent[i] == null ? "" : DateTime.Parse(objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
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
            public void m_mthSetPrintSignValue(string[] p_strkeyArr, string[] p_strTitleArr)
            {
                if (p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
                    return;
                objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
                m_strTitleArr = p_strTitleArr;
            }


        }
		#endregion
	
	}
}
