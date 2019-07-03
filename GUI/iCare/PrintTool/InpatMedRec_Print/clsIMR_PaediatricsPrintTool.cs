using System;
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
	/// 儿科科住院病历打印工具类..
	/// </summary>
	public class clsIMR_PaediatricsPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_PaediatricsPrintTool(string p_strTypeID) :base(p_strTypeID)
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
										  new clsPrintPatientFixInfo("儿科住院病历",310),
										  m_objPrintOneItemArr[7],
										  m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],m_objPrintOneItemArr[2],
										  m_objPrintOneItemArr[3],m_objPrintOneItemArr[4],m_objPrintMultiItemArr[0],
										  m_objPrintOneItemArr[5],m_objPrintOneItemArr[6],m_objPrintMultiItemArr[1],
										  m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
										  m_objPrintMultiItemArr[5],m_objPrintSignArr[0]
									  });
		}
	
		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[8];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[6];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

			m_objPrintSignArr = new clsPrintInPatMedRecSign[1];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}

		protected override void m_mthSetSubPrintInfo()
		{
			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("过去史","过去史：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("过去患病情况","过去患病情况：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("传染病接触史","传染病接触史：");
			m_objPrintOneItemArr[5].m_mthSetPrintValue("过敏史","过敏史：");
			m_objPrintOneItemArr[6].m_mthSetPrintValue("个人史","个人史：");
			m_objPrintOneItemArr[7].m_mthSetPrintValue("联系电话","联系电话：");
//			m_objPrintOneItemArr[8].m_mthSetPrintValue("泌尿系统","泌尿系统：");
//			m_objPrintOneItemArr[9].m_mthSetPrintValue("辅助检查","辅助检查：");
//			m_objPrintOneItemArr[8].m_mthSetPrintValue("入院诊断","入院诊断：");
			#endregion	
		
			#region 预防接种史
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","预防接种史>>卡介苗","预防接种史>>牛痘","预防接种史>>白、百、破三联","预防接种史>>麻疹疫苗","预防接种史>>脊髓灰质炎疫苗","预防接种史>>流脑细菌","预防接种史>>乙脑疫苗","预防接种史>>其它"}
				                                        ,new string[]{"预防接种史：","卡介苗：","牛痘：","白、百、破三联：","麻疹疫苗：","脊髓灰质炎疫苗：","流脑细菌：","乙脑疫苗：","其它："});


			#endregion
			
			#region 发育史
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","发育史>>胎次","发育史>>足月","发育史>>早产","发育史>>妊娠","发育史>>妊娠","发育史>>出生体重","发育史>>母孕期健康","发育史>>分娩经过"},
													     new string[]{"发育史：","胎次：","足月：","早产：","妊娠：","#周","初生体重：","母孕期健康：","分娩经过："});
			
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","发育史>>新生儿情况>>初生","发育史>>新生儿情况>>24小时","发育史>>新生儿情况>>7天"},
														 new string[]{"\n新生儿情况：","初生：","24小时：","7天"});
			
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","发育史>>神经精神发育>>月开始抬头","发育史>>神经精神发育>>月开始抬头",
																		 "发育史>>神经精神发育>>月会坐","发育史>>神经精神发育>>月会坐",
																		 "发育史>>神经精神发育>>月会站","发育史>>神经精神发育>>月会站",
																		 "发育史>>神经精神发育>>月会走","发育史>>神经精神发育>>月会走",
																		 "发育史>>神经精神发育>>月出牙","发育史>>神经精神发育>>月出牙",
																		 "发育史>>神经精神发育>>月会笑","发育史>>神经精神发育>>月会笑",
																		 "发育史>>神经精神发育>>月认人","发育史>>神经精神发育>>月认人",
																	     "发育史>>神经精神发育>>月说话","发育史>>神经精神发育>>月说话",
																		 "发育史>>神经精神发育>>其它"},
														 new string[]{"\n神经精神发育：",
																	  "","#月开始抬头",
																	  "","#月会坐",
																	  "","#月会站",
																	  "","#月会走",
																	  "","#月出牙",
																	  "","#月会笑",
																	  "","#月认人",
																	  "","#月说话。",
																	  "其它"});
			#endregion
		
			#region 营养史
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","","营养史>>婴儿期喂养>>母乳","营养史>>婴儿期喂养>>母乳时间","营养史>>婴儿期喂养>>人工","营养史>>婴儿期喂养>>人工时间","营养史>>婴儿期喂养>>混合","营养史>>婴儿期喂养>>混合时间"},
				new string[]{"营养史：","婴儿期喂养：","母乳：","时间：","\n                    人工：","时间：","\n                    混合：","时间："});
			
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","营养史>>辅食添加>>维生素D","营养史>>辅食添加>>维生素C生","营养史>>辅食添加>>粥","营养史>>辅食添加>>蛋黄","营养史>>辅食添加>>菜泥","营养史>>辅食添加>>其它"},
				new string[]{"\n辅食添加：","维生素D：","维生素C生：","粥","蛋黄","菜泥","其它"});
			
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","营养史>>现在开始喂养"},
				new string[]{"\n（注明开始月龄）","\n现在喂养",});
			#endregion

			#region 生活环境
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"","生活环境>>住家中","生活环境>>托幼机构>>日托","生活环境>>托幼机构>>全托","生活环境>>托幼机构"},
				new string[]{"生活环境：","住家中：","托幼机构：日托：","全托：","",});
			
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"生活环境>>居住条件","生活环境>>当地有何地方病"},
				new string[]{"\n居住条件：","\n当地有何地方病："});
			
			#endregion

			#region 家族史
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"","家族史>>父亲龄","家族史>>父亲龄","家族史>>父亲健康情况","家族史>>父亲职业性质"},
				new string[]{"家族史：","\n父亲年龄：","#岁，","健康情况：","职业："});
			
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"家族史>>母亲龄","家族史>>母亲龄","家族史>>母亲健康情况","家族史>>母亲职业性质"},
				new string[]{"\n母亲年龄：","#岁，","健康情况：","职业："});

			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"家族史>>母妊娠史","家族史>>同胞年龄及健康情况","家族史>>家庭中传染性及遗传性疾病"},
				new string[]{"\n母妊娠史：","\n同胞年龄及健康情况：","\n家庭中传染性及遗传性疾病"});
			
			#endregion
		
			#region 体格检查
			m_objPrintMultiItemArr[5].m_mthSetSpecialTitleValue("体 格 检 查");
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>一般测量>>体温","体格检查>>一般测量>>体温","体格检查>>一般测量>>呼吸","体格检查>>一般测量>>呼吸","体格检查>>一般测量>>脉搏","体格检查>>一般测量>>脉搏","体格检查>>一般测量>>血压1","体格检查>>一般测量>>血压2","体格检查>>一般测量>>血压2"},
				new string[]{"一般测量：","体温：","#℃","呼吸：","#次/分","脉搏","#次/分","血压","/","#Kpa"});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>一般测量>>体重","体格检查>>一般测量>>体重","体格检查>>一般测量>>身高","体格检查>>一般测量>>身高","体格检查>>一般测量>>头围","体格检查>>一般测量>>头围","体格检查>>一般测量>>胸围","体格检查>>一般测量>>胸围"},
				new string[]{"\n体重：","#公斤","身高：","#厘米","头围：","#厘米","胸围:","厘米"});
			
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>一般外表>>发育","体格检查>>一般外表>>营养","体格检查>>一般外表>>病容","体格检查>>一般外表>>精神状态"},
				new string[]{"\n一般外表：","发育：","营养：","病容：","\n精神状态"});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>皮肤下脂肪","体格检查>>淋巴系统"},
				new string[]{"\n皮肤下脂肪：","\n淋巴系统：",});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>头部>>颅骨","体格检查>>头部>>对边","体格检查>>头部>>眼","体格检查>>头部>>耳、鼻","体格检查>>头部>>咽、口腔","体格检查>>颈部","体格检查>>胸部:胸廓","体格检查>>肺脏","体格检查>>心脏","体格检查>>腹部","体格检查>>肝","体格检查>>脾","体格检查>>四肢骨骼","体格检查>>神经系统","体格检查>>肛门生殖器","泌尿系统","辅助检查","体格检查>>初步诊断"},
				new string[]{"\n头部：","颅骨：","前囱：对边：","\n眼：","\n耳、鼻：","\n咽，口腔：","\n颈部：","\n胸部：胸廓：","\n      肺脏：","\n      心脏","\n      腹部：","\n          肝：","\n          脾：","\n四肢骨骼：","\n神经系统：","\n肛门生殖器：","\n泌尿系统：","\n辅助检查：","\n初步诊断"});

//			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>皮肤下脂肪","体格检查>>淋巴系统","","体格检查>>头部>>颅骨","体格检查>>头部>>对边","体格检查>>头部>>眼","体格检查>>头部>>耳、鼻","体格检查>>头部>>咽、口腔","体格检查>>颈部","体格检查>>胸部:胸廓","体格检查>>肺脏","体格检查>>心脏","体格检查>>腹部","体格检查>>肝","体格检查>>脾","体格检查>>四肢骨骼","体格检查>>神经系统","体格检查>>肛门生殖器","体格检查>>初步诊断"},
//				new string[]{"\n皮肤下脂肪：","\n淋巴系统：","\n头部：","颅骨：","前囱：对边：","\n眼：","\n耳、鼻：","\n咽，口腔：","\n颈部：","\n胸部：胸廓：","\n肺脏：","\n腹部：","\n肝：","\n脾：","\n四肢骨骼：","\n神经系：","\n肛门生殖器：","\n初步诊断"});
			
			#endregion
			
			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"签名","上级医师签名","日期"},new string[]{"签名：","上级医师签名：","日期："});
//			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"住院医师","主治医师","日期"},new string[]{"住院医师：","主治医师：","日期："});
//			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"康复治疗计划>>医师","康复治疗计划>>时间"},new string[]{"医师：","日期："});
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
