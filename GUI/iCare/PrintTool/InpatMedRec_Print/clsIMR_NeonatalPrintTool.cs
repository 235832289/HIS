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
	/// 新生儿科住院病历打印工具类.
	/// </summary>
	public class clsIMR_NeonatalPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_NeonatalPrintTool(string p_strTypeID) :base(p_strTypeID)
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
										  new clsPrintPatientFixInfo("新生儿住院病历",295),
										  m_objPrintMultiItemArr[0],m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],
										  m_objPrintMultiItemArr[1],m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],
										  m_objPrintOneItemArr[2],m_objPrintMultiItemArr[4],m_objPrintMultiItemArr[5],
										  new clsPrintSubInf(),m_objPrintMultiItemArr[6],m_objPrintOneItemArr[4],m_objPrintSignArr[1],
                                          m_objPrintOneItemArr[3], m_objPrintSignArr[0]
									  });
		}

		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[5];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[7];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();
 
			m_objPrintSignArr = new clsPrintInPatMedRecSign[2];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}




		protected override void m_mthSetSubPrintInfo()
		{
			#region 开头部分信息
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"日龄","日龄","入院日期","出生时间",
																	  "父姓名","父工作单位","父职业","父电话",
																	  "母姓名","母工作单位","母职业","母电话"},
														 new string[]{"日龄：","#天","入院日期：","出生时间：",
																	  "\n父姓名：","工作单位：","职业：","联系电话：",
																	  "\n母姓名：","工作单位：","职业：","联系电话："});


			#endregion

			#region 单个项目
            m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉", "主诉：");
            m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史", "\n现病史：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("过去疾病","过去疾病：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("三日内主治医师诊断","三日内主治医师诊断：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("入院诊断","入院诊断：");
//			m_objPrintOneItemArr[5].m_mthSetPrintValue("过敏史","过敏史：");
//			m_objPrintOneItemArr[6].m_mthSetPrintValue("个人史","个人史：");
//			m_objPrintOneItemArr[7].m_mthSetPrintValue("联系电话","联系电话：");
			//			m_objPrintOneItemArr[8].m_mthSetPrintValue("入院诊断","入院诊断：");
			#endregion	

			#region 个人史
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","个人史>>母孕期情况>>发烧、泌感、妊毒症"},
												 	 	 new string[]{"个人史：","母孕期情况：","发烧、泌感、妊毒症："});

			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","个人史>>出生史>>胎","个人史>>出生史>>胎",
																		 "个人史>>出生史>>产","个人史>>出生史>>产",
																		 "个人史>>出生史>>妊娠周数","个人史>>出生史>>（早产、足月产、过期产）",
																		 "个人史>>出生史>>双胎","个人史>>出生史>>分娩方式","个人史>>出生史>>羊水早破","个人史>>出生史>>羊水早破",
																		 "个人史>>出生史>>羊水性质","个人史>>出生史>>产程延长","个人史>>出生史>>产程延长","个人史>>出生史>>胎盘异带","个人史>>出生史>>脐带异常",},
													     new string[]{"\n出生史：","第：","#胎","第：","#产","妊娠周数：","",
																	  "双胎","分娩方式",
																	  "羊水早破:","#小时（天）","羊水性质：","产程延长：","#小时",
																	  "胎盘异带：","脐带异常："});

			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"个人史>>出生史>>分娩前有无用药","个人史>>出生史>>宫内窒息","个人史>>出生史>>分娩地点","个人史>>出生史>>早产原因"},
														 new string[]{"\n分娩前有无用药：","宫内窒息：","\n分娩地点：","早产原因："});


			#endregion

			#region 新生婴儿情况
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"","新生儿情况>>出生体重","新生儿情况>>出生体重","新生儿情况>>呼吸开始时间","新生儿情况>>哭声",
																	  "新生儿情况>>皮肤颜色","新生儿情况>>四肢张力","新生儿情况>>羊水吸入史","",
																	  "新生儿情况>>一分钟","新生儿情况>>五分钟","新生儿情况>>十分钟","新生儿情况>>窒息",
																	  "新生儿情况>>窒息原因","新生儿情况>>抢救措施","新生儿情况>>插管","新生儿情况>>黄疸","新生儿情况>>黄疸",
																	  "新生儿情况>>天高峰","新生儿情况>>天高峰","新生儿情况>>天消失","新生儿情况>>天消失","新生儿情况>>程度",
																	  "新生儿情况>>脐带","新生儿情况>>脐带","新生儿情况>>胎便","新生儿情况>>胎便","新生儿情况>>排完","新生儿情况>>排完"},
														 new string[]{"新生儿状况：","出生体重：","#公斤","呼吸开始时间：","哭声：","皮肤颜色：","\n四肢张力：","羊水吸入史：",
																	  "\nAPgar评分：","一分钟：","五分钟：","十分钟：","窒息：","\n窒息原因：","抢救措施：","插管：",
																	  "\n黄疸第：","#天出现","第：","#天高峰","第：","#天消失","程度：","\n脐带第：","#天脱落","胎便第：","#天排","第：","#天排完"});


			#endregion

			#region 喂养史和接种史
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"","喂养史和接种史>>开奶时间","喂养史和接种史>>方式","喂养史和接种史>>卡介苗接种"},
														 new string[]{"喂养史和接种史：","开奶时间：","方式:","卡介苗接种："});
		    #endregion
		
			#region 家族史
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"","家族史>>父亲龄","家族史>>父亲龄","家族史>>父亲健康情况","家族史>>父血型"},
				new string[]{"家族史：","\n父年龄：","#岁，","健康情况：","血型："});
			
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"家族史>>母亲龄","家族史>>母亲龄","家族史>>母亲健康情况","家族史>>父血型"},
				new string[]{"\n母年龄：","#岁，","健康情况：","血型："});

			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"家族史>>妊娠次数","家族史>>流产","家族史>>流产","家族史>>死胎","家族史>>死产",
																	  "家族史>>婚配","家族史>>同胞年龄及健康情况"},
				new string[]{"\n妊娠次数：","流产：","#次","死胎","死产","\n婚配：","\n同胞年龄及健康情况:"});
			
			#endregion

			#region 体格检查1
			m_objPrintMultiItemArr[5].m_mthSetSpecialTitleValue("体 格 检 查");
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>一般测量>>体温","体格检查>>一般测量>>体温",
																	  "体格检查>>一般测量>>呼吸","体格检查>>一般测量>>呼吸",
																	  "体格检查>>一般测量>>脉搏","体格检查>>一般测量>>脉搏",
																	  "体格检查>>一般测量>>血压","体格检查>>一般测量>>血压",
																	  "体格检查>>一般测量>>体重","体格检查>>一般测量>>体重"},
														 new string[]{"一般测量：","体温：","#℃","呼吸：","#分/次","脉搏","#分/次","血压","#mmHg","体重","Kg"});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>一般测量>>身高","体格检查>>一般测量>>身高",
																	  "体格检查>>一般测量>>头围","体格检查>>一般测量>>头围",
																	  "体格检查>>一般测量>>胸围","体格检查>>一般测量>>胸围",
																	  "体格检查>>一般测量>>其它"},
														 new string[]{"身高：","#Cm","头围：","#Cm","胸围:","Cm","其它:"});
			
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>一般外表>>发育","体格检查>>一般外表>>营养","体格检查>>一般外表>>面色","体格检查>>一般外表>>哭声"},
														 new string[]{"\n一般外表：","发育：","营养：","面色：","哭声"});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>皮肤>>皮疹及部位","体格检查>>皮肤>>黄疸",
																	  "体格检查>>皮肤>>部位","体格检查>>皮肤>>硬肿","体格检查>>皮肤>>部位1","体格检查>>皮肤>>水肿",
																	  "体格检查>>皮肤>>脱皮","体格检查>>皮肤>>皮下脂肪","体格检查>>皮肤>>皮肤弹性"},
               new string[]{"\n皮  肤：","皮疹及部位：","黄疸:","部位:","硬肿:","部位:","水肿:","脱皮:","皮下脂肪:","皮肤弹性:"});

			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>淋巴系统"},
							                             new string[]{"\n淋巴系统："});

//			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"","体格检查>>头部>>颅骨","体格检查>>头部>>对边","体格检查>>头部>>眼","体格检查>>头部>>耳、鼻","体格检查>>头部>>咽、口腔","体格检查>>颈部","体格检查>>胸部:胸廓","体格检查>>肺脏","体格检查>>心脏","体格检查>>腹部","体格检查>>肝","体格检查>>脾","体格检查>>四肢骨骼","体格检查>>神经系统","体格检查>>肛门生殖器","体格检查>>初步诊断"},
//				new string[]{"\n头部：","颅骨：","前囱：对边：","\n眼：","\n耳、鼻：","\n咽，口腔：","\n颈部：","\n胸部：胸廓：","\n肺脏：","\n心脏","\n腹部：","\n肝：","\n脾：","\n四肢骨骼：","\n神经系：","\n肛门生殖器：","\n初步诊断"});

//		    PringSub(
			

		
			#endregion
		
			#region  体格检查2
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","体格检查>>骨骼系统>>头颅外形","体格检查>>骨骼系统>>先锋头","体格检查>>骨骼系统>>血肿",
																		 "体格检查>>骨骼系统>>头发","体格检查>>骨骼系统>>颅骨软化","体格检查>>骨骼系统>>前囱",
																		 "体格检查>>骨骼系统>>厘米","体格检查>>骨骼系统>>膨隆","体格检查>>骨骼系统>>凹陷",
																		 "体格检查>>骨骼系统>>后囱","体格检查>>骨骼系统>>骨缝"},
				new string[]{"\n骨骼系统：","头颅外形：","先锋头：","血肿：","头发：","颅骨软化：","前囱：","厘米：",
								"膨隆：","凹陷：","后囱：","骨缝："});
			
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","体格检查>>呼吸系统>>节律","体格检查>>呼吸系统>>呼吸暂停","体格检查>>呼吸系统>>呻吟",
																		 "体格检查>>呼吸系统>>吐沫","体格检查>>呼吸系统>>口周、唇发绀","体格检查>>呼吸系统>>鼻扇",
																		 "体格检查>>呼吸系统>>三凹征","体格检查>>呼吸系统>>胸廓","体格检查>>呼吸系统>>听诊"},
				new string[]{"\n呼吸系统：","节律：","呼吸暂停：","呻吟：","吐沫：","口周、唇发绀：","鼻扇：","三凹征：",
								"\n胸廓：","听诊："});

			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","体格检查>>循环系统>>望诊","体格检查>>循环系统>>触诊","体格检查>>循环系统>>心界",
																		 "体格检查>>循环系统>>心率","体格检查>>循环系统>>心律","体格检查>>循环系统>>心音",
																		 "体格检查>>循环系统>>杂音","体格检查>>循环系统>>末梢循环情况"},
				new string[]{"\n循环系统：","望诊：","触诊：","心界：","心率：","心律：","心音：","杂音：",
								"\n末梢循环情况："});

			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","体格检查>>消化系统>>口腔粘膜","体格检查>>消化系统>>咽","体格检查>>消化系统>>舌苔",
																		 "体格检查>>消化系统>>腹部>>软、膨胀、紧张、肠形","体格检查>>消化系统>>腹部>>肠鸣音","体格检查>>消化系统>>腹部>>包块",
																		 "体格检查>>消化系统>>肝助下","体格检查>>消化系统>>肝助下","体格检查>>消化系统>>剑下",
																		 "体格检查>>消化系统>>剑下","体格检查>>消化系统>>脾助下","体格检查>>消化系统>>脾助下","体格检查>>消化系统>>肛门"},
				new string[]{"\n消化系统：","口腔粘膜：","咽：","舌苔：","\n软、膨胀、紧张、肠形：","肠鸣音：","包块：",
								"肝助下：","#Cm：","剑下：","#Cm：","脾助下：","#cm","肛门："});
			
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","体格检查>>神经系统>>颈抵抗","体格检查>>神经系统>>反射、舌咽","体格检查>>神经系统>>吸吮",
																		 "体格检查>>神经系统>>食觅","体格检查>>神经系统>>握持","体格检查>>神经系统>>拥抱",
																		 "体格检查>>神经系统>>膝腱","体格检查>>神经系统>>肌张力","","体格检查>>眼>>凝视",
																		 "体格检查>>眼>>震颤","体格检查>>眼>>瞳孔对光反射"},
				new string[]{"\n神经系统：","颈抵抗：","反射、舌咽：","吸吮：","食觅：","握持：","拥抱：","膝腱：",
								"肌张力：","\n眼：","凝视：","震颤：","瞳孔对光反射"});
			
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"体格检查>>泌尿系统","体格检查>>四肢","体格检查>>其它","体格检查>>门诊化验"},
				new string[]{"\n泌尿系统：","四肢：","\n其它：","\n门诊化验："});			
			#endregion

			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"主治医师签名","签名日期"},new string[]{"主治医师签名：","签名日期："});
			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"住院医师签名"},new string[]{"住院医师签名："});
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

		
		#region 表格打印
		/// <summary>
		/// 表格打印
		/// </summary>
		private class clsPrintSubInf : clsIMR_PrintLineBase
		{
			#region Define

			private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black,new Font("",10));
//			private string m_strTitle = "";
//			private string[] m_strTitleArr = null;
     		private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";

			/// <summary>
			/// 格子高度
			/// </summary>
			private const int c_intHeight = 40;
			/// <summary>
			/// 左竖线X轴
			/// </summary>
			private const int c_intShortLeft = 140;
			/// <summary>
			/// 右竖线X轴
			/// </summary>
			private const int c_intShortRight = 463;
			/// <summary>
			/// 打印内容格子宽度
			/// </summary>
			//private const int c_intWidth = 323;
			private const int c_intWidth = 107;
			/// <summary>
			/// 打印小标题宽度
			/// </summary>
			private const int c_intTitleWidth = 80;
//			private int m_intLongLineTop = 150;
			/// <summary>
			/// 打印横线的X坐标
			/// </summary>
//			private int m_intLeftX = (int)enmRectangleInfo.LeftX -10;

//			private int m_intIndex = 0;
//			int m_intPosY;

//			private bool m_IsPrintCol0=false;
			private bool m_IsPrintCol1=false;
			private bool m_IsPrintCol2=false;
			private bool m_IsPrintCol3=false;
			private bool m_IsPrintCol4=false;
			private bool m_IsPrintCol5=false;
			private bool m_IsPrintCol6=false;
			private Pen PrintPenInf =new Pen(Color.Black ,1);

//			private bool m_IsPrintCol7=false;

			#endregion

			public clsPrintSubInf()
			{}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				int ColHeight;
				p_objGrp.DrawString ("身体的成熟度：（一周以内填写）",p_fntNormalText,Brushes.Black,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY);
//				p_intPosY+=20;
				ColHeight=30;
				p_intPosY+=30;

				if (m_mthIsPage(p_intPosY,ColHeight)) {return;}
//				#region 最上面得线
////				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY-10);
//				#endregion
                System.Drawing.Font p_TsFont=new Font (p_fntNormalText.Name ,p_fntNormalText.Size -3);
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_TsFont,"     评分                    体征",ColHeight,-1,-1,"");
				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.LeftX+80) ,(float)p_intPosY+ColHeight+10);
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   0   ",ColHeight,0,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   1   ",ColHeight,1,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   2   ",ColHeight,2,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   3   ",ColHeight,3,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   4   ",ColHeight,4,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   5   ",ColHeight,5,-1,"");

				ColHeight=80;
				if (m_IsPrintCol1==false)
				{
					//换页线
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"皮肤",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"胶粘透明红色",ColHeight,0,-1,"身体的成熟度>>皮肤0");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"光滑粉红可见",ColHeight,1,-1,"身体的成熟度>>皮肤1");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"表面脱或者少许静脉",ColHeight,2,-1,"身体的成熟度>>皮肤2");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"表皮裂痕，皮肤部分转白，罕见静脉",ColHeight,3,-1,"身体的成熟度>>皮肤3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"皮肤稍厚，呈羊皮纸样，裂痕深，无血管",ColHeight,4,-1,"身体的成熟度>>皮肤4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"皮肤厚，呈皮革样，有裂痕破坏",ColHeight,5,-1,"身体的成熟度>>皮肤5");
					m_IsPrintCol1=true;
				}

				ColHeight=20;
				if (m_IsPrintCol2==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"胎毛",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"无",ColHeight,0,-1,"身体的成熟度>>胎毛0");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"多",ColHeight,1,-1,"身体的成熟度>>胎毛1");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"少",ColHeight,2,-1,"身体的成熟度>>胎毛2");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"部分秃",ColHeight,3,-1,"身体的成熟度>>胎毛3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"大部分秃",ColHeight,4,-1,"身体的成熟度>>胎毛4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
					m_IsPrintCol2=true;
				}

				ColHeight=40;
				if (m_IsPrintCol3==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
                    m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText, "足底纹理", ColHeight, -1, -1, "");
                    m_mthPrintDetail(ref p_intPosY, p_objGrp, p_fntNormalText, "无", ColHeight, 0, -1, "身体的成熟度>>足底纹理0");
                    m_mthPrintDetail(ref p_intPosY, p_objGrp, p_fntNormalText, "细红痕", ColHeight, 1, -1, "身体的成熟度>>足底纹理1");
                    m_mthPrintDetail(ref p_intPosY, p_objGrp, p_fntNormalText, "前部有横裂痕", ColHeight, 2, -1, "身体的成熟度>>足底纹理2");
                    m_mthPrintDetail(ref p_intPosY, p_objGrp, p_fntNormalText, "前2/3可见裂痕", ColHeight, 3, -1, "身体的成熟度>>足底纹理3");
                    m_mthPrintDetail(ref p_intPosY, p_objGrp, p_fntNormalText, "全足底见裂痕", ColHeight, 4, -1, "身体的成熟度>>足底纹理4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
					m_IsPrintCol3=true;
				}

				ColHeight=40;
				if (m_IsPrintCol4==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
                    m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText, "乳房结节", ColHeight, -1, -1, "");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"难以触及",ColHeight,0,-1,"身体的成熟度>>乳房结节0");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"平",ColHeight,1,-1,"身体的成熟度>>乳房结节1");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳晕花瓣状<1-2mm",ColHeight,2,-1,"身体的成熟度>>乳房结节2");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳晕隆起，3-4mm",ColHeight,3,-1,"身体的成熟度>>乳房结节3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"丰满，5-10mm",ColHeight,4,-1,"身体的成熟度>>乳房结节4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
					m_IsPrintCol4=true;
				}

				ColHeight=60;
				if (m_IsPrintCol5==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"耳  ",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"耳翼平坦易折叠",ColHeight,0,-1,"身体的成熟度>>耳0");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"轻度弯曲，软，折叠后恢复缓慢",ColHeight,1,-1,"身体的成熟度>>耳1");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"耳翼弯曲良好，折叠后易恢复",ColHeight,2,-1,"身体的成熟度>>耳2");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"耳廊形成，质软折叠后立即恢复",ColHeight,3,-1,"身体的成熟度>>耳3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"耳廊软骨变厚，质硬",ColHeight,4,-1,"身体的成熟度>>耳4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
					m_IsPrintCol5=true;
				}

				ColHeight=40;
				if (m_IsPrintCol6==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   男",ColHeight,-1,-1,"");
					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15+40),(float)p_intPosY-10,(float)(enmRectangleInfo.LeftX+15+40),(float)p_intPosY+ColHeight+10);
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"外生殖器",100,-2,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"阴囊空虚无皱襞",ColHeight,0,-1,"身体的成熟度>>男0");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"睾丸下降，少许皱襞",ColHeight,2,-1,"身体的成熟度>>男2");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"睾丸下降，皱襞良好",ColHeight,3,-1,"身体的成熟度>>男3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"睾丸悬垂、皱襞深",ColHeight,4,-1,"身体的成熟度>>男4");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
					m_IsPrintCol6=true;
				}

				ColHeight=40;
				if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"   女",ColHeight,-1,(int)(enmRectangleInfo.LeftX+15+40),"");
				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15+40),(float)p_intPosY-10,(float)(enmRectangleInfo.LeftX+15+40),(float)p_intPosY+ColHeight+10);
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"阴蒂及小阴唇半外露",ColHeight,0,-1,"身体的成熟度>>女0");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,1,-1,"");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"小阴唇外露",ColHeight,2,-1,"身体的成熟度>>女2");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"小阴唇部分外露",ColHeight,3,-1,"身体的成熟度>>女3");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"大阴唇完全遮盖阴蒂和小阴唇",ColHeight,4,-1,"身体的成熟度>>女4");
				m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,5,-1,"");
				#region 画底线
				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
				#endregion
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_objDiagnoseR.m_mthRestartPrint();	
				m_objDiagnoseL.m_mthRestartPrint();	
			}

			private void m_mthPrintDetail(ref int p_intPosY, System.Drawing.Graphics p_objGrp, 
										  System.Drawing.Font p_fntNormalText,
										  string PrintStr,int CellHeight,int Col,int p_LineX,string p_Key)
			{
				StringFormat p_StrFormat=new StringFormat ();
				p_StrFormat.FormatFlags =StringFormatFlags.FitBlackBox;
				

				Rectangle rtgCellinf = new Rectangle(0,0,0,0);
//				Pen PrintPenInf =new Pen(Color.Black ,1);
				if (Col==-1) 
				{
					#region 根据最左端得列画横线
					if (p_LineX==-1)
					{
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
					}
					else
					{
						p_objGrp.DrawLine (PrintPenInf,p_LineX,(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
					}
					#endregion
					p_intPosY+=10;

					#region 画最左边的竖线
					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)(p_intPosY-10) ,(float)(enmRectangleInfo.LeftX+15) ,(float)(p_intPosY+CellHeight+10));
					#endregion
					
				}
				
				switch (Col)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						#region 除去第一列根据每列画竖线
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+20,(float)(p_intPosY-10) ,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+20 ,(float)(p_intPosY+CellHeight+10));
						#endregion
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+20,p_intPosY,c_intWidth,CellHeight);
						break;
					case -2:
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+20)+5,p_intPosY,20,CellHeight);
						break;
					default:
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+10)+5,p_intPosY,c_intWidth,CellHeight);
						#region 画最右边得竖线
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.RightX-20),(float)(p_intPosY-10) ,(float)(enmRectangleInfo.RightX-20) ,(float)(p_intPosY+CellHeight+10));
						#endregion 
						break;
			
				}

				if(m_hasItems.Contains(p_Key))
				{
                    p_objGrp.DrawString("√" + PrintStr, p_fntNormalText, Brushes.Black, rtgCellinf, p_StrFormat);
                   // p_objGrp.DrawString(PrintStr, p_fntNormalText, Brushes.Black, rtgCellinf, p_StrFormat);
				}
				else
				{
					p_objGrp.DrawString (PrintStr,p_fntNormalText,Brushes.Black,rtgCellinf,p_StrFormat);
				}
                if (Col == 5)
				{
					p_intPosY=p_intPosY+CellHeight+10;
//					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col),(float)(p_intPosY-10) ,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col) ,(float)(p_intPosY+CellHeight+10));
				}
			}

			private bool m_mthIsPage(int p_intPosY,int p_ColHeight)
			{
				if(p_intPosY+40+p_ColHeight > ((int)enmRectangleInfo.BottomY -50))
				{
					m_blnHaveMoreLine = true;
					
					p_intPosY += 500;
					return true;
				}
				else
				{
					return false;
				}

			}

		}

		#endregion
	}
}
