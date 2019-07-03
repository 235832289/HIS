using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// 胸外科住院病历打印工具类
	/// </summary>
	public class clsIMR_ChestSurgeryPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_ChestSurgeryPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
		}

		protected override void m_mthSetPrintLineArr()
		{
            
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("胸外科住院病历",300),
										  new clsPrintInPatientCaseMain(),
										  new clsPrintInPatientCaseCurrent(),
										  new clsPrintInPatientBeforetimeStatus(),
										  new clsPrintInPatientIndividual(),
										  new clsPrintInPatientFamily(),
										  new clsPrintInPatientMedical(),
										  new clsPrintInPatientSpecial_I(),
										  new clsPrintInPatientSpecial_II(),
										  new clsPrintInPatientSpecial_III(),
										  new clsPrintInPatMedRecPic(),
										  new clsPrintInPatientPreliminaryDia(),
										  new clsPrintInPatientDiagnosticThere(),
										  new clsPrintInPatientDifferentialDia(),
										  new clsPrintInPatientTherapyPlan(),
										  new clsPrintInPatientFinallyDia(),
                                            new clsPrint1(),
                                            new clsPrint2()
									  });
		}

		#region  Print Class

		/// <summary>
		/// 主诉
		/// </summary>
		private class clsPrintInPatientCaseMain : clsIMR_PrintLineBase
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
					p_objGrp.DrawString("主诉：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent != null);
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
		private class clsPrintInPatientCaseCurrent : clsIMR_PrintLineBase
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
					p_objGrp.DrawString("现病史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
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
		/// 既往史
		/// </summary>
		private class clsPrintInPatientBeforetimeStatus : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"既往史>>肿瘤病史(良、恶性)","既往史>>心血管病史","既往史>>呼吸系统病史","既往史>>食管及胃肠病史","既往史>>传染病史","既往史>>外伤或手术史","既往史>>食物或药物过敏史","既往史>>其它重要病史"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("既往史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"肿瘤病史(良、恶性)：","心血管病史：","呼吸系统病史：","食管及胃肠病史：","传染病史：","外伤或手术史：","食物或药物过敏史：","其它重要病史："},
							m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("既往史：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 个人史
		/// </summary>
		private class clsPrintInPatientIndividual : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"个人史>>过去主要职业","个人史>>长期生活地区","个人史>>饮食习惯>>主粮"};
			private string[] m_strKeysArr2 = {"；嗜：","个人史>>饮食习惯>>嗜食>>速食","个人史>>饮食习惯>>嗜食>>热食","个人史>>饮食习惯>>嗜食>>辛辣食"};
			private string[] m_strKeysArr3 = {"个人史>>饮食习惯>>其它","","个人史>>饮酒习惯","个人史>>饮酒习惯>>数量","个人史>>饮酒习惯>>持续时间","","个人史>>吸烟习惯","个人史>>吸烟习惯>>数量","个人史>>吸烟习惯>>吸烟年限","个人史>>吸烟习惯>>戒烟年限","个人史>>月经婚姻生育情况"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("个人史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"过去主要职业：","长期生活地区：","饮食习惯："},m_strKeysArr1,ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) == true)
							m_mthMakeCheckText(m_strKeysArr2,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"其它：","饮酒习惯：","","每日每次(两)：","持续：","吸烟习惯：","","每天：","期限：","已戒烟：","月经婚姻生育情况："},m_strKeysArr3,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("个人史：",m_objPrintContext.m_ObjModifyUserArr);
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
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 家族史
		/// </summary>
		private class clsPrintInPatientFamily : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"家族史>>家人健康情况","家族史>>肿瘤病史生存情况","家族史>>遗传病史"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("家族史：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);

					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"家人健康情况：","肿瘤病史生存情况：","遗传病史："},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("家族史：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 体格检查
		/// </summary>
		private class clsPrintInPatientMedical : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"体格检查>>体温","体格检查>>体温","体格检查>>脉搏","体格检查>>脉搏","体格检查>>呼吸","体格检查>>呼吸","体格检查>>血压高","体格检查>>血压低","体格检查>>血压低","体格检查>>体重","体格检查>>体重","体格检查>>发育","体格检查>>营养","体格检查>>面容","体格检查>>表情","体格检查>>体位","体格检查>>步态",
												"体格检查>>神智","体格检查>>检查合作","体格检查>>皮肤粘膜","体格检查>>全身浅表淋巴结","体格检查>>头颅形态","体格检查>>五官","体格检查>>瞳孔左","体格检查>>瞳孔右","体格检查>>对光反射","体格检查>>伸舌","体格检查>>颈静脉","体格检查>>气管","体格检查>>甲状腺",
												"体格检查>>胸廓形态","体格检查>>呼吸方式","体格检查>>胸壁包块","体格检查>>胸壁压痛","体格检查>>胸壁静脉怒张","体格检查>>肺呼吸音左","体格检查>>肺呼吸音右","体格检查>>干囉音","体格检查>>湿囉音","体格检查>>心室率","体格检查>>心室率","体格检查>>心律","体格检查>>心瓣膜杂音","体格检查>>心包摩擦音","体格检查>>心前区弥漫搏动","体格检查>>心前区震颤",
												"体格检查>>腹部形态","体格检查>>腹肌张力","体格检查>>腹压痛","体格检查>>反跳痛","体格检查>>腹部包块","体格检查>>肝下界","体格检查>>肝叩击痛","体格检查>>脾下界","体格检查>>腹水征","体格检查>>腹壁静脉曲张","体格检查>>肠鸣音","体格检查>>肾区叩击痛","体格检查>>输尿管行程压痛",
												"体格检查>>膀胱部压痛","体格检查>>前列腺检查","体格检查>>肛门直肠下段指检","体格检查>>四肢关节","体格检查>>杵状指(趾)","体格检查>>脊柱","体格检查>>神经反射","体格检查>>其它"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("体 格 检 查",clsIMR_ChestSurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"T：","#℃","P：","#/min","R：","#/min","BP：","/","#Kpa","W：","#KG","发育：","营养：","面容：","表情：","体位：","步态：",
													  "神智：","检查合作：","皮肤粘膜：","全身浅表淋巴结：","头颅形态：","五官：","瞳孔： 左：","，右：","对光反射：","伸舌：","颈静脉：","气管：","甲状腺：",
													  "胸廓形态：","呼吸方式：","胸壁包块：","胸壁压痛：","胸壁静脉怒张：","肺呼吸音： 左：","右：","干囉音：","湿囉音：","心室率：","#/min：","心律：","心瓣膜杂音：","心包摩擦音：","心前区弥漫搏动：","心前区震颤：",
													  "腹部形态：","腹肌张力：","腹压痛：","反跳痛：","腹部包块：","肝下界：","肝叩击痛：","脾下界：","腹水征：","腹壁静脉曲张：","肠鸣音：","肾区叩击痛：","输尿管行程压痛：",
													  "膀胱部压痛：","前列腺检查：","肛门直肠下段指检：","四肢关节：","杵状指(趾)：","脊柱：","神经反射：","其它："},m_strKeysArr,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("体格检查：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 食管贲门膈疾病专页
		/// </summary>
		private class clsPrintInPatientSpecial_I : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"症状：","食管贲门膈疾病专页>>症状>>吞咽不顺","食管贲门膈疾病专页>>症状>>吞咽梗阻","食管贲门膈疾病专页>>症状>>吞咽疼痛","食管贲门膈疾病专页>>症状>>吞咽呛咳","食管贲门膈疾病专页>>症状>>进食后呕吐","食管贲门膈疾病专页>>症状>>吐粘液","食管贲门膈疾病专页>>症状>>吐宿食","食管贲门膈疾病专页>>症状>>吐血"
												 ,"食管贲门膈疾病专页>>症状>>恶心呕吐","食管贲门膈疾病专页>>症状>>胸骨后不适","食管贲门膈疾病专页>>症状>>胸痛","食管贲门膈疾病专页>>症状>>背痛","食管贲门膈疾病专页>>症状>>上腹痛","食管贲门膈疾病专页>>症状>>反酸","食管贲门膈疾病专页>>症状>>黑便","食管贲门膈疾病专页>>症状>>呼吸困难","食管贲门膈疾病专页>>症状>>声嘶","食管贲门膈疾病专页>>症状>>消瘦"};
			private string[] m_strKeysArr2 = {"食管贲门膈疾病专页>>症状>>其它","食管贲门膈疾病专页>>口腔卫生习惯","食管贲门膈疾病专页>>入院时进食情况","","食管贲门膈疾病专页>>检查>>身高","食管贲门膈疾病专页>>检查>>身高","食管贲门膈疾病专页>>检查>>体重","食管贲门膈疾病专页>>检查>>体重","食管贲门膈疾病专页>>检查>>占正常预计体重"
												 ,"食管贲门膈疾病专页>>检查>>占正常预计体重","食管贲门膈疾病专页>>检查>>皮肤弹性","食管贲门膈疾病专页>>检查>>脱水征","食管贲门膈疾病专页>>检查>>肩三头肌表皮折叠","食管贲门膈疾病专页>>检查>>肩三头肌表皮折叠","食管贲门膈疾病专页>>检查>>上腹压痛","食管贲门膈疾病专页>>检查>>腹部包块","食管贲门膈疾病专页>>检查>>双锁骨上淋巴结","食管贲门膈疾病专页>>检查>>肛检"};
			private string[] m_strKeysArr3 = {"\n辅助检查：","食管贲门膈疾病专页>>辅助检查>>纤维胃镜","食管贲门膈疾病专页>>辅助检查>>上消化道钡餐","食管贲门膈疾病专页>>辅助检查>>胸片","食管贲门膈疾病专页>>辅助检查>>腹胸CT","食管贲门膈疾病专页>>辅助检查>>腔内B超","食管贲门膈疾病专页>>辅助检查>>其它"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || clsIMR_ChestSurgeryPrintTool.m_StrTypeID != "frmIMR_ChestSurgery_I"|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("食管贲门膈疾病专页",clsIMR_ChestSurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+275,p_intPosY);

					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeCheckText(m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"其它：","口腔卫生习惯：","入院时进食情况：","\n检查：","身高：","#cm","体重：","#KG","占正常预计体重：","#%","皮肤弹性：","脱水征：","肩三头肌表皮折叠：","#cm","上腹压痛：","腹部包块：","双锁骨上淋巴结：","肛检："},
							m_strKeysArr2,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr3,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("食管贲门膈疾病专页：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}

			//			private void m_mthPrintAsissCheck(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			//			{
			//				if(((clsInpatMedRec_Item)m_hasItem["纤维胃镜"]).m_strItemContent != "False" || ((clsInpatMedRec_Item)m_hasItem["上消化道钡餐"]).m_strItemContent != "False" ||
			//					((clsInpatMedRec_Item)m_hasItem["胸片"]).m_strItemContent != "False" || ((clsInpatMedRec_Item)m_hasItem["腹胸CT"]).m_strItemContent != "False" ||
			//					((clsInpatMedRec_Item)m_hasItem["腔内B超"]).m_strItemContent != "False" || ((clsInpatMedRec_Item)m_hasItem["其它"]).m_strItemContent != "False")
			//				p_objGrp.DrawString("辅助检查：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
			//
			//			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 胸肺纵隔病专页
		/// </summary>
		private class clsPrintInPatientSpecial_II : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr1 = {"症状：","胸肺纵隔病专页>>咳嗽","胸肺纵隔病专页>>咯呛味痰","胸肺纵隔病专页>>咯脓性痰","胸肺纵隔病专页>>咯血丝痰","胸肺纵隔病专页>>干咳","胸肺纵隔病专页>>声嘶","胸肺纵隔病专页>>胸闷","胸肺纵隔病专页>>胸痛(左)","胸肺纵隔病专页>>胸痛(右)","胸肺纵隔病专页>>平静时气促","胸肺纵隔病专页>>轻活动气促","胸肺纵隔病专页>>卧床气促","胸肺纵隔病专页>>端坐呼吸","胸肺纵隔病专页>>间歇喘气","胸肺纵隔病专页>>咯血","胸肺纵隔病专页>>消瘦"};
			private string[] m_strKeysArr2 = {"胸肺纵隔病专页>>小关节疼痛","胸肺纵隔病专页>>小关节肿胀","胸肺纵隔病专页>>其它","胸肺纵隔病专页>>双锁骨上淋巴结"};
			private string[] m_strKeysArr3 = {"\n辅助检查：","胸肺纵隔病专页>>辅助检查>>胸片","胸肺纵隔病专页>>辅助检查>>CT","胸肺纵隔病专页>>辅助检查>>MRI","胸肺纵隔病专页>>辅助检查>>纤支镜","胸肺纵隔病专页>>辅助检查>>骨扫描"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || clsIMR_ChestSurgeryPrintTool.m_StrTypeID != "frmIMR_ChestSurgery_II"|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("胸肺纵隔病专页",clsIMR_ChestSurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);

					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeCheckText(m_strKeysArr1,ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n小关节疼痛：","小关节肿胀：","其它：","双锁骨上淋巴结："},m_strKeysArr2,ref strAllText,ref strXml);
						m_mthMakeCheckText(m_strKeysArr3,ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("胸肺纵隔病专页：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}
			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 乳腺病专页
		/// </summary>
		private class clsPrintInPatientSpecial_III : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private int m_intTimes = 0;
			private string[] m_strKeysArr = {"乳腺病专页>>初潮","乳腺病专页>>周期","乳腺病专页>>持续","乳腺病专页>>末次月经","乳腺病专页>>绝经年龄","乳腺病专页>>经量","乳腺病专页>>痛经","乳腺病专页>>经期","乳腺病专页>>妊娠年龄","乳腺病专页>>妊娠"
												,"乳腺病专页>>顺产","乳腺病专页>>流产","乳腺病专页>>哺乳时间","乳腺病专页>>哺乳时间","乳腺病专页>>哺乳时间天数","乳腺病专页>>哺乳时间天数","乳腺病专页>>自诉","乳腺病专页>>起止胀痛时间","乳腺病专页>>溢液性质","乳腺病专页>>创伤原因","乳腺病专页>>感染","乳腺病专页>>右乳","乳腺病专页>>左乳","乳腺病专页>>曾作治疗"
												,"乳腺病专页>>乳房肿块发现时间","乳腺病专页>>初始大小","乳腺病专页>>变化情况","乳腺病专页>>双侧乳房对称","乳腺病专页>>皮肤水肿范围","乳腺病专页>>皮肤水肿范围","乳腺病专页>>桔皮样观","乳腺病专页>>静脉曲张","乳腺病专页>>乳头凹陷","乳腺病专页>>乳头溢液","乳腺病专页>>肿块位置","乳腺病专页>>大小"
											,"乳腺病专页>>形态","乳腺病专页>>硬度","乳腺病专页>>活度","乳腺病专页>>与表皮粘连","乳腺病专页>>与胸大肌粘连","乳腺病专页>>浸润胸壁","乳腺病专页>>溃疡","乳腺病专页>>溃疡","乳腺病专页>>腋下淋巴结大小数目活动度-左","乳腺病专页>>腋下淋巴结大小数目活动度-右"
											,"乳腺病专页>>锁骨上淋巴结大小数目活动度-左","乳腺病专页>>锁骨上淋巴结大小数目活动度-右"};
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null || clsIMR_ChestSurgeryPrintTool.m_StrTypeID != "frmIMR_ChestSurgery_III"|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;

					return;
				}
				if(m_blnHavePrintInfo(m_strKeysArr) == false) 
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					p_intPosY += 20;
					p_objGrp.DrawString("乳腺病专页",clsIMR_ChestSurgeryPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+305,p_intPosY);

					p_intPosY += 40;
					string strAllText = "";
					string strXml = "";
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"初潮：","周期：","持续：","末次月经：","绝经年龄：","经量：","痛经：","经期：","妊娠年龄：","妊娠："
													  ,"顺产：","流产：","哺乳时间：","#月 ","","#天 ","自诉：","起止胀痛时间：","溢液性质：","创伤原因：","感染：","右乳：","左乳：","曾作治疗："
													  ,"乳房肿块发现时间：","初始大小：","变化情况：","双侧乳房对称：","皮肤水肿范围：","#cm","桔皮样观：","静脉曲张：","乳头凹陷：","乳头溢液：","肿块位置：","大小："
												  ,"形态：","硬度：","活度：","与表皮粘连：","与胸大肌粘连：","浸润胸壁：","溃疡：","#cm","腋下淋巴结大小数目活动度-左：","右："
												  ,"锁骨上淋巴结大小数目活动度-左：","右："},	m_strKeysArr,ref strAllText,ref strXml);
						
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent!=null);
					m_mthAddSign2("乳腺病专页：",m_objPrintContext.m_ObjModifyUserArr);

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
					m_blnHaveMoreLine = false;
				}
			}
			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnIsFirstPrint = true;
				m_blnHaveMoreLine = true;
				m_intTimes = 0;
			}
		}
		/// <summary>
		/// 初步诊断
		/// </summary>
		private class clsPrintInPatientPreliminaryDia : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"初步诊断>>初步诊断","初步诊断>>CTNM","初步诊断>>签名","初步诊断>>日期"});
				
				if(objItemContent == null ||objItemContent[0] == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("初步诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0]==null ? "" : objItemContent[0].m_strItemContent)  ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
					m_mthAddSign2("初步诊断：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_objGrp.DrawString("CTNM(临床分期)："+(objItemContent[1]==null ? "" : objItemContent[1].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+410,p_intPosY);
					p_intPosY += 20;
					p_objGrp.DrawString("签名："+(objItemContent[2]==null ? "" : objItemContent[2].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
					p_intPosY += 20;
					p_objGrp.DrawString("日期："+ (objItemContent[3] == null ? "" :DateTime.Parse( objItemContent[3].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
					p_intPosY += 20;
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
		/// 诊断依据
		/// </summary>
		private class clsPrintInPatientDiagnosticThere : clsIMR_PrintLineBase
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
				if(m_hasItems.Contains("诊断依据"))
					objItemContent = m_hasItems["诊断依据"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("诊断依据：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("诊断依据：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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
		/// 鉴别诊断
		/// </summary>
		private class clsPrintInPatientDifferentialDia : clsIMR_PrintLineBase
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
				if(m_hasItems.Contains("鉴别诊断"))
					objItemContent = m_hasItems["鉴别诊断"] as clsInpatMedRec_Item;
				if(objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("鉴别诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent==null ? "" : objItemContent.m_strItemContent)  ,(objItemContent==null ? "<root />" : objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,objItemContent!=null);
					m_mthAddSign2("鉴别诊断：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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
		/// 诊疗计划
		/// </summary>
		private class clsPrintInPatientTherapyPlan : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"诊疗计划","修正诊断>>修正诊断","修正诊断>>签名","修正诊断>>日期"});
				if(objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
				{
					m_blnHaveMoreLine = false;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					if (objItemContent[0] != null)
						if(objItemContent[0].m_strItemContent != null)
							p_objGrp.DrawString("诊疗计划：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							p_objGrp.DrawString("修正诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+380,p_intPosY);
					p_intPosY += 20;
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
						{
							m_objPrintContext1.m_mthSetContextWithCorrectBefore(objItemContent[0].m_strItemContent ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
							m_mthAddSign2("诊疗计划：",m_objPrintContext1.m_ObjModifyUserArr);
						}
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
						{
							m_objPrintContext2.m_mthSetContextWithCorrectBefore(objItemContent[1].m_strItemContent ,(objItemContent[1]==null ? "<root />" : objItemContent[1].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[1]!=null);
							m_mthAddSign2("修正诊断：",m_objPrintContext2.m_ObjModifyUserArr);
						}
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
				{
					if (objItemContent[0] != null)
						if (objItemContent[0].m_strItemContent != null)
                            m_objPrintContext1.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
					if (objItemContent[1] != null)
						if (objItemContent[1].m_strItemContent != null)
							m_objPrintContext2.m_mthPrintLine(330,m_intRecBaseX+405,p_intPosY,p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					if (objItemContent[1] != null)
					{
						p_objGrp.DrawString("签名："+(objItemContent[2]==null ? "" : objItemContent[2].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+390,p_intPosY);
						p_objGrp.DrawString("日期："+ (objItemContent[3] == null ? "" :DateTime.Parse( objItemContent[3].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
					}
					p_intPosY += 20;
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext1.m_mthRestartPrint();
				m_objPrintContext2.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		/// <summary>
		/// 最后诊断
		/// </summary>
		private class clsPrintInPatientFinallyDia : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"最后诊断>>最后诊断","最后诊断>>PTNM","最后诊断>>签名","最后诊断>>日期"});
				if(objItemContent == null || objItemContent[0] == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("最后诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
					p_intPosY += 20;
					m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0]==null ? "" : objItemContent[0].m_strItemContent)  ,(objItemContent[0]==null ? "<root />" : objItemContent[0].m_strItemContentXml),m_dtmFirstPrintTime,objItemContent[0]!=null);
					m_mthAddSign2("最后诊断：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
					p_intPosY += 20;
					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					p_objGrp.DrawString("PTNM(临床分期)："+(objItemContent[1]==null ? "" : objItemContent[1].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+390,p_intPosY);
					p_intPosY += 20;
					p_objGrp.DrawString("签名："+(objItemContent[2]==null  ? "" : (objItemContent[2].m_strItemContent == null ? "" :objItemContent[2].m_strItemContent)) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+350,p_intPosY);
					p_objGrp.DrawString("日期："+ (objItemContent[3] == null ? "" :DateTime.Parse( objItemContent[3].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+550,p_intPosY);
					p_intPosY += 20;
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
        /// 修正诊断
        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item[] objItemContent;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                objItemContent = m_objGetContentFromItemArr(new string[] { "修正诊断", "修正诊断医师签名", "修正诊断医师签名日期" });
                if (objItemContent == null || objItemContent[0] == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent), (objItemContent[0] == null ? "<root />" : objItemContent[0].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent[0] != null);
                    m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    //p_objGrp.DrawString("PTNM(临床分期)：" + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
                    //p_intPosY += 20;
                    p_objGrp.DrawString("签名：" + (objItemContent[1] == null ? "" : (objItemContent[1].m_strItemContent == null ? "" : objItemContent[1].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                    p_objGrp.DrawString("日期：" + (objItemContent[2] == null ? "" : DateTime.Parse(objItemContent[2].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);
                    p_intPosY += 20;
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
        /// 补充诊断
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item[] objItemContent;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                objItemContent = m_objGetContentFromItemArr(new string[] { "补充诊断", "补充诊断医师签名", "补充诊断医师签名日期" });
                if (objItemContent == null || objItemContent[0] == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("补充诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent), (objItemContent[0] == null ? "<root />" : objItemContent[0].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent[0] != null);
                    m_mthAddSign2("补充诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 40, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    //p_objGrp.DrawString("PTNM(临床分期)：" + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
                    //p_intPosY += 20;
                    p_objGrp.DrawString("签名：" + (objItemContent[1] == null ? "" : (objItemContent[1].m_strItemContent == null ? "" : objItemContent[1].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                    p_objGrp.DrawString("日期：" + (objItemContent[2] == null ? "" : DateTime.Parse(objItemContent[2].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);
                    p_intPosY += 20;
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
