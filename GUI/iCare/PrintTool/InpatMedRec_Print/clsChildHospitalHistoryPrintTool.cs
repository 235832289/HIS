using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// clsChildHospitalHistoryPrintTool 的摘要说明。
	/// </summary>
	public class clsChildHospitalHistoryPrintTool: clsInpatMedRecPrintBase
	{
		public clsChildHospitalHistoryPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
																		   new clsPrintChildHospitalHistory(),	
					                                                       new clsSignNameAndDate()													  
																		
																	   });			
		}
		#region 入院诊断---诊疗计划
		/// <summary>
		/// 入院诊断---诊疗计划
		/// </summary>
		private class clsPrintChildHospitalHistory : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
			//	private string[] m_strKeysArr1 = {"手术日期","手术日期>>至"};
//			private string[] m_strKeysArr2 = {"√","拟施手术名称>>超声乳化白内障摘除术"};
//			private string[] m_strKeysArr02 = {" 超声乳化白内障摘除术"};
			#region 生成CheckBox的打印文本
			/// <summary>
			/// 生成CheckBox的打印文本
			/// </summary>
			/// <param name="p_hasItem">哈希表</param>
			/// <param name="p_strName">内容数组，数组第一项为标识，从第二项开始才是键</param>
			/// <param name="p_strTextAll">正常文本</param>
			/// <param name="p_strTextXML">XML文本</param>
			protected  void m_mthMakeCheckText(string[] p_strName,ref string p_strTextAll, ref string p_strTextXML)
			{
				if(m_hasItems == null || m_hasItems.Count < 1 || p_strName == null)
					return;
				bool blnPrintFirst = false;
				string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
				string strDH_XML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("、",m_objContent.m_strCreateUserID,strFirstName,Color.Black,m_strMakedate);
				p_strTextAll += p_strName[0];
				string strXML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[0],m_objContent.m_strCreateUserID,strFirstName,Color.Black,m_strMakedate);
				if(p_strTextXML != "")
					p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[]{p_strTextXML,strXML});
				else
					p_strTextXML = strXML;
				for(int i =1; i < p_strName.Length; i++)
				{
					if(m_hasItems.Contains(p_strName[i]) == true)
					{
						int index = p_strName[i].LastIndexOf(">");
						string strText = p_strName[i];
						if (index > 0)
							strText = p_strName[i].Substring(index+1);
						p_strTextAll += (blnPrintFirst == true ? "、" : "") + strText;
						p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[]{p_strTextXML,(blnPrintFirst == true ? strDH_XML : "<root />"),ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText,m_objContent.m_strCreateUserID,strFirstName,Color.Black,m_strMakedate)});
						blnPrintFirst = true;
					}
				}
				//p_strTextAll += "；";
				p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[]{p_strTextXML,ctlRichTextBox.clsXmlTool.s_strMakeTextXml("；",m_objContent.m_strCreateUserID,strFirstName,Color.Black,m_strMakedate)});
			}	
			#endregion 
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				//				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
				//				{
				//					m_blnHaveMoreLine = false;
				//					return;
				//				}
				if(m_blnIsFirstPrint)
				{
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						#region 入院诊断--家族史有无特殊
						m_mthMakeText(new string[]{"入院诊断："},new string[]{"入院诊断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n出院诊断："},new string[]{"出院诊断"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n并发病："},new string[]{"并发病"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n出院状况：","出院状况>>愈","出院状况>>好转","出院状况>>无变化","出院状况>>恶化","出院状况>>未治疗","出院状况>>自动出院","出院状况>>死亡"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n主诉："},new string[]{"主诉"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n现病史："},new string[]{"现病史"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n过去史："},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"平时健康情况：","过去史>>平时健康情况>>一般","过去史>>平时健康情况>>良好","过去史>>平时健康情况>>差"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；曾","过去史>>传染病史>>有","过去史>>无传染病史"},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string []{"过去史>>传染病史>>有"}) != false)
						m_mthMakeText(new string[]{"","传染病史$$"},new string[]{"过去史>>传染病史",""},ref strAllText,ref strXml);
						
						m_mthMakeCheckText(new string []{"；","过去史>>有外伤、高热惊厥史","过去史>>无外伤、高热惊厥史"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","过去史>>过敏吏>>有","过去史>>无过敏吏"},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string []{"过去史>>过敏吏>>有"}) != false)						
						m_mthMakeText(new string[]{"","过敏吏$$"},new string[]{"过去史>>过敏吏",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；其他："},new string[]{"过去史>>其他"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n个人史：第","胎；$$"},new string[]{"个人史>>胎",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"第","产；$$"},new string[]{"个人史>>产",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","个人史>>足月","个人史>>早产","个人史>>难产","个人史>>新接生法","个人史>>旧接生法"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；出生时","个人史>>有窒息","个人史>>无窒息"},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string []{"个人史>>有窒息"}) != false)						
							m_mthMakeCheckText(new string []{"","个人史>>窒息轻","个人史>>窒息重"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","个人史>>有产伤","个人史>>无产伤"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","个人史>>胎膜早破","个人史>>无胎膜早破"},ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(new string []{"个人史>>胎膜早破"}) != false)
							m_mthMakeText(new string[]{"","小时$$"},new string[]{"个人史>>胎膜早破>>小时",""},ref strAllText,ref strXml);

						m_mthMakeCheckText(new string []{"；","个人史>>羊水混浊","个人史>>无羊水混浊"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","个人史>>脐带绕颈","个人史>>无脐带绕颈"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","个人史>>有黄疸","个人史>>无黄疸"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；","个人史>>母乳","个人史>>人工喂养"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"；","月会坐；$$"},new string[]{"个人史>>月会坐",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","岁会走路；$$"},new string[]{"个人史>>岁会走路",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","岁会说话；$$"},new string[]{"个人史>>岁会说话",""},ref strAllText,ref strXml);
						
						m_mthMakeCheckText(new string []{"","个人史>>嗜好>>有","个人史>>嗜好>>无嗜好"},ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(new string []{"个人史>>嗜好>>有"}) != false)
							m_mthMakeText(new string[]{"","嗜好$$"},new string[]{"个人史>>嗜好",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；学习成绩：","个人史>>学习成绩>>优","个人史>>学习成绩>>良","个人史>>学习成绩>>差"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；预防接种情况：","预防接种情况>>卡介苗","预防接种情况>>小儿麻痹糖丸","预防接种情况>>白日破","预防接种情况>>麻疹","预防接种情况>>乙肝疫苗甲肝疫苗"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n其他："},new string[]{"预防接种情况>>其他"},ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n家族史：家中父、母"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","家族史>>近亲婚配>>是近亲婚配","家族史>>近亲婚配>>不是近亲婚配"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；有"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","兄、$$"},new string[]{"家族史>>兄",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","弟、$$"},new string[]{"家族史>>弟",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","姐、$$"},new string[]{"家族史>>姐",""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"","妹、$$"},new string[]{"家族史>>妹",""},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"","家族史>>遗传史>>有遗传史","家族史>>遗传史>>无遗传史"},ref strAllText,ref strXml);
						
						if(m_blnHavePrintInfo(new string []{"家族史>>遗传史>>有遗传史"}) != false)
							m_mthMakeText(new string[]{"："},new string[]{"家族史>>遗传史"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"\n家族史：","家族史>>有特殊","家族史>>无特殊"},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string []{"家族史>>有特殊"}) != false)						
						m_mthMakeText(new string[]{"："},new string[]{"家族史>>特殊"},ref strAllText,ref strXml);
						#endregion

						m_mthMakeText(new string[]{"\n                                                     体  格  检  查"},new string[]{""},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n体温：","℃；$$","脉搏：","次/分；$$"},new string[]{"体格检查>>体温","","体格检查>>脉搏",""},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"呼吸：","次/分；$$","血压：","kpa；$$"},new string[]{"体格检查>>呼吸","","体格检查>>血压",""},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"体重：","kg；$$","头围：","cm；$$","身长:","cm；$$"},new string[]{"体格检查>>体重","","体格检查>>头围","","体格检查>>身长",""},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n一般情况：发育：","营养："},new string[]{"体格检查>>一般情况>>发育","体格检查>>一般情况>>营养"},ref strAllText,ref strXml);					
						m_mthMakeCheckText(new string []{"；神志：","体格检查>>神志>>清醒","体格检查>>神志>>嗜睡","体格检查>>神志>>恍忽","体格检查>>神志>>瞻妄","体格检查>>神志>>昏睡","体格检查>>神志>>昏迷"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；精神：","体格检查>>精神>>好","体格检查>>精神>>不振","体格检查>>精神>>烦躁","体格检查>>精神>>淡漠"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；病容：","体位："},new string[]{"体格检查>>病容","体格检查>>体位"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n皮肤粘膜：","\n皮下脂肪："},new string[]{"体格检查>>皮肤粘膜","体格检查>>皮下脂肪"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n残表淋巴结："},new string[]{"体格检查>>残表淋巴结"},ref strAllText,ref strXml);					
						
						m_mthMakeText(new string[]{"\n头颈部：头颅：","骨缝：","前囟：","后囟："},new string[]{"体格检查>>头颈部>>头颅","体格检查>>头颈部>>骨缝","体格检查>>头颈部>>前囟","体格检查>>头颈部>>后囟"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             眼眶：","眼睑：","球结膜：","巩膜：","眼球："},new string[]{"体格检查>>头颈部>>眼眶","体格检查>>头颈部>>眼睑","体格检查>>头颈部>>球结膜","体格检查>>头颈部>>巩膜","体格检查>>头颈部>>眼球"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             瞳孔：","光反射："},new string[]{"体格检查>>头颈部>>瞳孔","体格检查>>头颈部>>光反射"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             耳：","乳突：","鼻：","口周：","唇：","咽："},new string[]{"体格检查>>头颈部>>耳","体格检查>>头颈部>>乳突","体格检查>>头颈部>>鼻","体格检查>>头颈部>>口周","体格检查>>头颈部>>唇","体格检查>>头颈部>>咽"},ref strAllText,ref strXml);					

						m_mthMakeText(new string[]{"\n             口腔粘膜：","牙：","牙龈：","扁桃体：","舌："},new string[]{"体格检查>>头颈部>>口腔粘膜","体格检查>>头颈部>>牙","体格检查>>头颈部>>牙龈","体格检查>>头颈部>>扁桃体","体格检查>>头颈部>>舌"},ref strAllText,ref strXml);					
						m_mthMakeCheckText(new string []{"\n             颈：","体格检查>>头颈部>>有抵抗","体格检查>>头颈部>>无抵抗"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；气管："},new string[]{"体格检查>>头颈部>>气管"},ref strAllText,ref strXml);					
						m_mthMakeCheckText(new string []{"；颈静脉：","体格检查>>头颈部>>有恕张","体格检查>>头颈部>>无恕张"},ref strAllText,ref strXml);

						m_mthMakeCheckText(new string []{"；肝颈静脉回流征：","体格检查>>头颈部>>肝颈静脉回流征>>阳性","体格检查>>头颈部>>肝颈静脉回流征>>阴性"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；"},new string[]{"体格检查>>头颈部>>肝颈静脉回流征"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；甲状腺："},new string[]{"体格检查>>头颈部>>甲状腺"},ref strAllText,ref strXml);					
						
						m_mthMakeText(new string[]{"\n胸部：胸廓："},new string[]{""},ref strAllText,ref strXml);					
						m_mthMakeCheckText(new string []{"","胸部>>胸廓>>畸形","胸部>>胸廓>>鸡胸","胸部>>胸廓>>漏斗胸","胸部>>胸廓>>赫氏沟","胸部>>胸廓>>胁串珠","胸部>>胸廓>>胁外翻"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"     其他："},new string[]{"胸部>>胸廓>>其他"},ref strAllText,ref strXml);					
					
						m_mthMakeText(new string[]{"\n肺脏：望———"},new string[]{"体格检查>>肺脏>>望"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             触———"},new string[]{"体格检查>>肺脏>>触"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             叩———"},new string[]{"体格检查>>肺脏>>叩"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n             听———"},new string[]{"体格检查>>肺脏>>听"},ref strAllText,ref strXml);					

						m_mthMakeText(new string[]{"\n心脏：望———"},new string[]{"体格检查>>心脏>>望"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            触———"},new string[]{"体格检查>>心脏>>触"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            叩———"},new string[]{"体格检查>>心脏>>叩"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            听———"},new string[]{"体格检查>>心脏>>听"},ref strAllText,ref strXml);					
						
						m_mthMakeText(new string[]{"\n腹部：望———"},new string[]{"体格检查>>腹部>>望"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            触———"},new string[]{"体格检查>>腹部>>触"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            叩———"},new string[]{"体格检查>>腹部>>叩"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n            听———"},new string[]{"体格检查>>腹部>>听"},ref strAllText,ref strXml);					
						
						m_mthMakeText(new string[]{"\n脊柱四肢："},new string[]{"体格检查>>脊柱四肢"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n肛门：外生殖器："},new string[]{"体格检查>>外生殖器"},ref strAllText,ref strXml);					

						m_mthMakeText(new string[]{"\n神经系统："},new string[]{""},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"觅食反射："},new string[]{"体格检查>>神经系统>>觅食反射"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；吸吮反射："},new string[]{"体格检查>>神经系统>>吸吮反射"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；握持反射：","拥抱反射："},new string[]{"体格检查>>神经系统>>握持反射","体格检查>>神经系统>>拥抱反射"},ref strAllText,ref strXml);					
						
						m_mthMakeText(new string[]{"\n角膜反射："},new string[]{"体格检查>>神经系统>>角膜反射"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；腹壁反射："},new string[]{"体格检查>>神经系统>>腹壁反射"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；提睾反射：","膝反射："},new string[]{"体格检查>>神经系统>>提睾反射","体格检查>>神经系统>>膝反射"},ref strAllText,ref strXml);					
					
						m_mthMakeText(new string[]{"\nBabinski's Sign："},new string[]{""},ref strAllText,ref strXml);					
						m_mthMakeCheckText(new string []{"","体格检查>>神经系统>>Babinski's Sign>>左","体格检查>>神经系统>>Babinski's Sign>>右"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；Oppenheim's Sign：","体格检查>>神经系统>>Oppenheim's Sign>>左","体格检查>>神经系统>>Oppenheim's Sign>>右"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；Gordon's Sign：","体格检查>>神经系统>>Gordon's Sign>>左","体格检查>>神经系统>>Gordon's Sign>>右"},ref strAllText,ref strXml);
						m_mthMakeCheckText(new string []{"；Chaddock's Sign：","体格检查>>神经系统>>Chaddock's Sign>>左","体格检查>>神经系统>>Chaddock's Sign>>右"},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"；\nKeznig's Sign：","Brudzinskig's Sign："},new string[]{"体格检查>>神经系统>>Keznig's Sign","体格检查>>神经系统>>Brudzinskig's Sign"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"；其他："},new string[]{"体格检查>>神经系统>>其他"},ref strAllText,ref strXml);					

						m_mthMakeText(new string[]{"\n实验室及其他检查："},new string[]{"体格检查>>神经系统>>实验室及其他检查"},ref strAllText,ref strXml);					

						m_mthMakeText(new string[]{"\n摘要："},new string[]{"体格检查>>神经系统>>摘要"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n诊断依据："},new string[]{"诊断依据"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n初步诊断："},new string[]{"初步诊断"},ref strAllText,ref strXml);					
						m_mthMakeText(new string[]{"\n诊疗计划："},new string[]{"诊疗计划"},ref strAllText,ref strXml);					

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
		#region 签名 和 日期
		/// <summary>
		/// 签名 和 日期
		/// </summary>
		private class clsSignNameAndDate : clsIMR_PrintLineBase
		{
			#region 无用代码
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//
//			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
//			/// <summary>
//			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
//			/// </summary>
//			private bool m_blnIsFirstPrint = true;
//			private bool blnNextPage = true;
//			private string[] m_strKeysArr01 = {"医师签名"};
//			private string[] m_strKeysArr101 = {"\n                                                                                        医师签名："};
//	
//			private string[] m_strKeysArr02 = {"日期"};
//			private string[] m_strKeysArr102 = {"                   日 期："};		
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null|| m_objContent.m_objItemContents == null)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
//				
//				//				if(blnNextPage)
//				//				{
//				//					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
//				//					m_blnHaveMoreLine = true;
//				//					blnNextPage = false;
//				//					p_intPosY += 1500;
//				//					return;
//				//				}
//				if(m_blnIsFirstPrint)
//				{
//					//					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
//					//					p_intPosY += 20;
//					//					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
//					//					p_intPosY += 20;
//					string strAllText = "";
//					string strXml = "";
//					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
//					if(m_objContent!=null)
//					{
//						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
//							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
//						else
//							m_mthMakeText(m_strKeysArr101,new string[]{""},ref strAllText,ref strXml);
//
//						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
//							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
//			
//			
//								
//					}
//					else
//					{
//						m_blnHaveMoreLine = false;
//						return;
//					}
//					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
//					m_mthAddSign2("医师签名",m_objPrintContext.m_ObjModifyUserArr);
//					m_blnIsFirstPrint = false;					
//				}
//
//				//int intLine = 0;
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
//					p_intPosY += 20;
//				}
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//				m_blnHaveMoreLine = true;
//				m_blnIsFirstPrint = true;
//			}
          # 	endregion


			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private clsInpatMedRec_Item[] objItemContent;
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				objItemContent = m_objGetContentFromItemArr(new string[]{"医师签名","日期"});
				
//				if(objItemContent == null ||objItemContent[0] == null)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
				if(p_intPosY+20>clsPrintPosition.c_intBottomY-20)
				{
				  m_blnHaveMoreLine = true;
					return;
				}
				if(m_blnIsFirstPrint)
				{
					if(objItemContent!=null)
					{
						p_objGrp.DrawString("医师签名："+(objItemContent[0]==null ? "" : objItemContent[0].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+260,p_intPosY);
						//p_intPosY += 20;
						p_objGrp.DrawString("       日期："+ (objItemContent[1] == null ? "" :DateTime.Parse( objItemContent[1].m_strItemContent).ToString("yyyy年MM月dd日HH时mm分")),p_fntNormalText,Brushes.Black,m_intRecBaseX+420,p_intPosY);
						m_blnIsFirstPrint = false;
					}
				}

			//	int intLine = 0;
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine(330,m_intRecBaseX+405,p_intPosY,p_objGrp);
//					p_intPosY += 20;
//					intLine++;
//				}			

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
	}
}
