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
	/// 按新规范
	/// 新生儿科科住院病历打印工具类.
	/// </summary>
	public class clsIMR_NewChildPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_NewChildPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		//private clsPrintInPatMedRecSign[] m_objPrintSignArr;
	
		protected override void m_mthSetPrintLineArr()
		{

			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("新生儿科入院记录",320),
										  m_objPrintMultiItemArr[0],m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],
										  m_objPrintMultiItemArr[1],
										  m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
										  m_objPrintMultiItemArr[5],m_objPrintMultiItemArr[6],m_objPrintMultiItemArr[7],
										  m_objPrintMultiItemArr[8],m_objPrintMultiItemArr[9],m_objPrintMultiItemArr[10],
										  m_objPrintMultiItemArr[11],m_objPrintMultiItemArr[12],m_objPrintMultiItemArr[13],
										  m_objPrintMultiItemArr[14],m_objPrintMultiItemArr[15],m_objPrintMultiItemArr[16],
										  m_objPrintMultiItemArr[17],m_objPrintMultiItemArr[18],m_objPrintMultiItemArr[19],
										  m_objPrintMultiItemArr[20],m_objPrintMultiItemArr[21],
										  m_objPrintOneItemArr[2],m_objPrintOneItemArr[3],m_objPrintOneItemArr[4]
									  });
		}
	
		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[5];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[22];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

            //m_objPrintSignArr = new clsPrintInPatMedRecSign[1];
            //for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
            //    m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}

		protected override void m_mthSetSubPrintInfo()
		{
			#region 抬头信息
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"联系电话","出生年月",
																		 "父姓名","父年龄","父职业","父联系电话",
																		 "母姓名","母年龄","母职业","母联系电话",""},
				new string[]{"联系电话：","出生年月：",
								"\n父姓名：","年龄：","职业：","联系电话：",
								"\n母姓名：","年龄：","职业：","联系电话：",""});
		
		#endregion

			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
			
			
		
			#endregion	

			#region 分娩情况
            string m_strExpecteDate = "预产期：";
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("分娩情况>>预产期>>不详"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>预产期>>不详"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    {
                        m_strExpecteDate += "不详；";
                    }
                }
                else if (m_hasItems.Contains("分娩情况>>孕次>>预产期"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>孕次>>预产期"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    {
                        m_strExpecteDate += Convert.ToDateTime(objInpatItem.m_strItemContent).ToString("yyyy年MM月dd日")+"；";
                    }
                }
            }
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{
																	"",
																	"分娩情况>>孕次",
																	"分娩情况>>孕次>>产次",
                                                                    "",
																	"分娩情况>>孕次>>分娩期",
																	"分娩情况>>孕次>>孕周",""},
				new string[]{
							"\n分娩情况：",
							"\n        孕次：",
							"产次：",
							m_strExpecteDate,
							"分娩期：",
							"孕周：",""});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{
																"",
																"分娩情况>>分娩方式>>顺产",
																"分娩情况>>分娩方式>>吸引产",
																"分娩情况>>分娩方式>>底/中位钳产",
																"分娩情况>>分娩方式>>臀位",
																"分娩情况>>分娩方式>>剖腹产",
																"分娩情况>>分娩方式>>其他",
																"分娩情况>>分娩方式>>其他方式",
																"",
																"分娩情况>>分娩方式>>胎腊早破",
																"",
																//"",
																"分娩情况>>宫内窘迫",
																"",
																//"",
																"分娩情况>>母用镇静剂（产前面小时内）或麻醉剂",
																"",
																"分娩情况>>分娩方式>>胎心音",
																"",
																"分娩情况>>脐带>>正常",
																"分娩情况>>脐带>>异常",
																"分娩情况>>脐带>>打结",
																"分娩情况>>脐带>>水肿",
                                                                "分娩情况>>脐带>>绕颈",
																"分娩情况>>脐带>>绕颈周数",
                                                                "分娩情况>>脐带>>绕颈周数",
																"",
																"分娩情况>>羊水>>正常",
																"分娩情况>>羊水>>过多",
																"分娩情况>>羊水>>过少",
																"分娩情况>>羊水>>清",
																"分娩情况>>羊水>>混浊",
																"分娩情况>>羊水>>浑浊",
																"分娩情况>>羊水>>浑浊",
																"",
                                                                "分娩情况>>胎盘>>正常",
																"分娩情况>>胎盘>>前置",
																"分娩情况>>胎盘>>早剥",
																"分娩情况>>胎盘>>异常梗塞",
																"分娩情况>>胎盘>>钙化" },
				new string[]{
								"\n        分娩方式：",
								"#顺产",
								"#吸引产",
								"#低/中位钳产",
								"#臀位",
								"#剖腹产",
								"#其他：$$",
								"$$",
								"胎膜早破：",
								"",
								//"小时；$$",
								"宫内窘迫：",
								"",
								//"小时；$$",
								"\n        母用镇静剂(产前4小时内)或麻醉剂：",
								"",
								"\n        胎心音：",
								"",
								"脐带：",
                                "#正常",
								"#异常",
								"#打结",
								"#水肿",
								"#绕颈",
								"$$",
								"#周",
								"羊水：",
								"#正常",
								"#过多",
								"#过少",
								"#清",
								"#混浊（",
								"$$",
								"#度）",
								"胎盘：",
                                "#正常；",
								"#前置；",
								"#早剥；",
								"#异常梗塞；",
								"#钙化；", 
								});

            
            string strDT = "#多胎：";
            string strST = "双胎：";
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("分娩情况>>新生儿出生时>>双胎>>多胎"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>新生儿出生时>>多胎"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    {
                        strDT = strDT + objInpatItem.m_strItemContent + "；";
                        strST = "";
                    }
                }
            }

			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{
																	"",
																	"",
																	"分娩情况>>其他>>羊水吸收史",
																	"",
																	"分娩情况>>其他>>开始时间",
																	"",
																	"分娩情况>>其他>>方式",
																	"",
																	"分娩情况>>黄疸",
																	"",
																	"",
																	"分娩情况>>其他>>胎粪",
																	//"",
																	"",
																	"分娩情况>>新生儿筛查>>G-6PD；",
																	"分娩情况>>新生儿筛查>>PKU；",
																	"分娩情况>>新生儿筛查>>甲状腺功能低下症；",
																	"分娩情况>>新生儿筛查>>地中海贫血；",
																	"分娩情况>>新生儿筛查>>听力；",
																	"",
																	"",
																	"分娩情况>>新生儿出生时>>体重",
																	"",
																	"",
																	"分娩情况>>新生儿出生时>>身长",
																	"",
																	"",
                                                                    "分娩情况>>新生儿出生时>>双胎>>无；",
																	"分娩情况>>新生儿出生时>>双胎>>大；",
																	"分娩情况>>新生儿出生时>>双胎>>小；",
																	"分娩情况>>新生儿出生时>>双胎>>单卵双胎",
																	"分娩情况>>新生儿出生时>>双胎>>双卵双胎",
																	"分娩情况>>新生儿出生时>>双胎>>多胎"
																	},
				new string[]{
							"\n        其他：",
							"羊水的吸收史：",
							"",
							"开奶时间：",
							"",
							"方式：",
							"",
							"黄疸第",
							"",
							"天出现；$$",
							"胎粪排净时间：",
							"$$",
							//"天排净；$$",
							"\n        新生儿筛查：",
							"#G-6PD；",
							"#PKU；",
							"#甲状腺功能低下症；",
							"#地中海贫血；",
							"#听力；",
							"\n        新生儿出生时：$$",
							"体重：",
							"",
							"kg；$$",
							"身长：",
							"",
							"cm；$$",
							strST,
                            "#无；",
							"#大；",
							"#小；",
							"#单卵双胎；",
							"#双卵双胎；",
							strDT});


			#endregion

			#region 新生儿急救
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new String[]{
																"",
																"",
																"新生儿急救>>急救>>有",
																"新生儿急救>>急救>>无",
																"",
																"新生儿急救>>Apgar评分>>生出后1分钟",
																"",
																"",
																"新生儿急救>>Apgar评分>>生出后5分钟",
																"",
																"",
																"新生儿急救>>Apgar评分>>生出后n分钟",
																"",
																"新生儿急救>>Apgar评分>>生出后n分钟n分",
																"",
																"",
																"新生儿急救>>口腔吸出物性质>>无",
																"新生儿急救>>口腔吸出物性质>>血性",
																"新生儿急救>>口腔吸出物性质>>胎粪",
																"新生儿急救>>口腔吸出物性质>>羊水",
																"新生儿急救>>口腔吸出物性质>>其他",
																"新生儿急救>>口腔吸出物性质>>其他内容",
																"",
																"新生儿急救>>心肺复苏术>>无",
																"新生儿急救>>心肺复苏术>>有",
																"新生儿急救>>心肺复苏术>>有内容",
                                                                "新生儿急救>>心肺复苏术>>有",
																"",
																"新生儿急救>>气管插管>>有",
																"新生儿急救>>气管插管>>无",
																"",
																"新生儿急救>>心肺复苏术>>抢救用药",""},
				new String[]{
						"\n新生儿急救：",
						"\n        急救：",
						"#有",
						"#无",
						"Apgar评分：生后1分钟（",
						"",
						"）分；$$",
						"生后5分钟（",
						"",
						"）分；$$",
						"生后",
						"",
						"分钟（$$",
						"",
						"）分；$$",
						"\n        口腔吸出物性质：",
						"#无",
						"#血性",
						"#胎粪",
						"#羊水",
						"#其他",
						"",
						"心肺复苏术：",
						"#无",
						"#有（",
						"$$",
                        "#）",
						"气管插管：",
						"#有",
						"#无",
						"抢救用药：",
						"",""});
			#endregion

			#region 家族史
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new String[]{
														"",
														"",
														"",
                                                        "家族史>>本次妊娠情况>>母体疾病>>无疾病；",
														"家族史>>本次妊娠情况>>母体疾病>>妊娠水肿；",
														"家族史>>本次妊娠情况>>母体疾病>>妊娠高血压；",
														"家族史>>本次妊娠情况>>母体疾病>>先兆子痫/子痫；",
														"家族史>>本次妊娠情况>>母体疾病>>蛋白尿；",
														"家族史>>本次妊娠情况>>母体疾病>>惊厥糖尿病；",
														"家族史>>本次妊娠情况>>母体疾病>>接触毒物；",
														"家族史>>本次妊娠情况>>母体疾病>>孕早、中、后期细菌/病毒感染；",
														"",
														"家族史>>本次妊娠情况>>孕期用药情况>>无",
														"家族史>>本次妊娠情况>>孕期用药情况>>有",
														"家族史>>本次妊娠情况>>孕期用药情况",
                                                        "家族史>>本次妊娠情况>>孕期用药情况>>有",
														"",
														"家族史>>本次妊娠情况>>其他母史>>上胎溶血史；",
														"家族史>>本次妊娠情况>>其他母史>>习惯流产史；",
														"家族史>>本次妊娠情况>>其他母史>>剖腹史；",
														"家族史>>本次妊娠情况>>其他母史>>死胎/畸胎史；",
														"家族史>>本次妊娠情况>>其他母史>>出血史；",
														"家族史>>本次妊娠情况>>其他母史>>其他；",
														"家族史>>本次妊娠情况>>其他母史>>其他>>酗酒；",
														"家族史>>本次妊娠情况>>其他母史>>其他>>吸烟；",
														"家族史>>本次妊娠情况>>其他母史>>其他>>其他；",
														"家族史>>本次妊娠情况>>其他母史>>其他>>其他内容",
                                                        "家族史>>本次妊娠情况>>其他母史>>其他；"},
				new String[]{
								"\n家族史：",
								"\n        本次妊娠情况：",
								"\n        母体疾病：",
                                "#无疾病；",
								"#妊娠水肿；",
								"#妊娠高血压；",
								"#先兆子痫/子痫；",
								"#蛋白尿；",
								"#惊厥糖尿病；",
								"#接触毒物；",
								"#孕早、中、后期细菌/病毒感染；",
								"\n        孕期用药情况：$$",
								"#无",
								"#有（$$",
								"$$",
                                "#）",
								"\n        其他母史：",
								"#上胎溶血史；",
								"#习惯流产史；",
								"#剖腹史；",
								"#死胎/畸胎史；",
								"#出血史；",
								"#其他（",
								"#酗酒；",
								"#吸烟；",
								"#其他：",
								"$$","#）"});
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new String[]{
																	"",
																	"",
																	"家族史>>本次妊娠情况>>近亲结婚>>无",
																	"家族史>>本次妊娠情况>>近亲结婚>>有",
																	"",
																	"家族史>>传染病",
																	"",
																	"家族史>>遗传病",
																	"",
                                                                    "家族史>>本次妊娠情况>>其他病>>无",
																	"家族史>>本次妊娠情况>>其他病>>心脏病；",
																	"家族史>>本次妊娠情况>>其他病>>肾脏病；",
																	"家族史>>本次妊娠情况>>其他病>>慢性高血压；",
																	"家族史>>本次妊娠情况>>其他病>>贫血及血液病；",
																	"家族史>>本次妊娠情况>>其他病>>肝病；",
																	"家族史>>本次妊娠情况>>其他病>>肺病；",
																	"家族史>>本次妊娠情况>>其他病>>癫痫或精神病；",
																	"家族史>>本次妊娠情况>>其他病>>甲状腺病；",
																	"家族史>>本次妊娠情况>>其他病>>风疹；",
																	"家族史>>本次妊娠情况>>其他病>>其他；",
																	"家族史>>本次妊娠情况>>其他病>>其他内容",
                                                                    "家族史>>本次妊娠情况>>其他病>>其他；",
																	"",
																	"家族史>>父血型",
																	"",
																	"家族史>>母血型",
																	"",
																	"家族史>>家庭其他成员类似病史>>无",
																	"家族史>>家庭其他成员类似病史>>有",
																	"家族史>>其他",""},
				new String[]{
							"\n        父母情况：",
							"近亲结婚：",
							"#无",
							"#有",
							"传染病：",
							"",
							"遗传病：",
							"",
							"其他病：",
                            "#无；",
							"#心脏病；",
							"#肾脏病；",
							"#慢性高血压；",
							"#贫血及血液病；",
							"#肝病；",
							"#肺病；",
							"#癫痫或精神病；",
							"#甲状腺病；",
							"#风诊；",
							"#其他：",
							"$$",
                            "#；",
							"\n        父血型：$$",
							"",
							"母血型：",
							"",
							"家庭其他成员类似病史：",
							"#无",
							"#有",
							"其他：",""});
			#endregion

			#region 药物及其过敏史
            m_objPrintMultiItemArr[4].m_mthSetPrintValue(new String[] { "", "药物及其过敏史>>未发现", "药物及其过敏史>>有", "药物及其过敏史>>有内容", "药物及其过敏史>>有" },
				new String[]{"药物及其过敏史：","#未发现","#有（","$$","#）"});
			#endregion

			#region 体格检查
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{
																		 "",
																		 "体格检查>>体温",
																		 "",
																		 "体格检查>>呼吸",
																		 "",
																		 "体格检查>>脉搏",
																		 "",
																		 "体格检查>>血压1",
																		 "",
																		 "体格检查>>血压2",
																		 "",
																		 "体格检查>>体重",
																		 "",
																		 "体格检查>>身高",
																		 "",
																		 "体格检查>>头围",
																		 ""
																		},
				new string[]{
								"\n体格检查：",
								"\n        体温：",
								"℃；$$",
								"呼吸：",
								"次/分；$$",
								"脉搏：",
								"次/分；$$",
								"血压：",
								"/$$",
								"$$",
								"mmHg；$$",
								"\n        体重：",
								"kg；$$",
								"身高：",
								"cm；$$",
								"头围：",
								"cm；$$"});


			#endregion

			#region 一般情况
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new String[]{
																		 "",
																		 "",
																		 "一般情况>>反应",
																		 "",
																		 "一般情况>>神志",
																		 "",
																		 "一般情况>>外貌",
																		 "",
																		 "一般情况>>哭声>>响亮",
																		 "一般情况>>哭声>>尖叫",
																		 "一般情况>>哭声>>低弱",
																		 "一般情况>>哭声>>呻吟",
																		 "一般情况>>哭声>>无",
																		 "一般情况>>哭声>>其他",
																		 "一般情况>>哭声>>其他内容",""
																		 },
				new String[]{
								"一般情况：", 
								"\n        反应：",
								"",
								"神志：",
								"",
								"外貌：",
								"",
								"哭声：",
								"#响亮",
								"#尖叫",
								"#低弱",
								"#呻吟",
								"#无",
								"#其他：",
								"$$",""});
	
			#endregion

			#region 皮肤

            //string strSkinOther = string.Empty;
            //string strSkinDropsy = string.Empty;
            //string strHardTurgescence = string.Empty;
            //if (m_hasItems != null)
            //{
            //    clsInpatMedRec_Item objInpat = null;
            //    if (m_hasItems.Contains("皮肤>>皮疹>>其他"))
            //    {
            //        objInpat = m_hasItems["皮肤>>皮疹>>其他>>部位"] as clsInpatMedRec_Item;
            //        if (objInpat != null)
            //            strSkinOther = "#其他：  部位： " + objInpat.m_strItemContent;
            //    }
            //    if (m_hasItems.Contains("皮肤>>水肿>>有"))
            //    {
            //        objInpat = m_hasItems["皮肤>>水肿>>有部位"] as clsInpatMedRec_Item;
            //        if(objInpat != null)
            //            strSkinDropsy = "部位： " + objInpat.m_strItemContent + "； ";
            //    }
            //    if (!m_hasItems.Contains("皮肤>>硬肿>>无") && m_hasItems.Contains("皮肤>>硬肿>>有"))
            //    {
            //        objInpat = m_hasItems["皮肤>>硬肿>>有>>部位"] as clsInpatMedRec_Item;
            //        if (objInpat != null)
            //            strHardTurgescence = "部位： " + objInpat.m_strItemContent;

            //        objInpat = m_hasItems["皮肤>>硬肿>>有>>面积"] as clsInpatMedRec_Item;
            //        if (objInpat != null)
            //            strHardTurgescence += "  面积： " + objInpat.m_strItemContent;

            //        objInpat = m_hasItems["皮肤>>硬肿>>有>>度"] as clsInpatMedRec_Item;
            //        if (objInpat != null)
            //            strHardTurgescence += "  度： " + objInpat.m_strItemContent + "；";
            //    }
            //}
			m_objPrintMultiItemArr[7].m_mthSetPrintValue(new String[]{
"",
"",
"皮肤>>肤泽>>正常",
"皮肤>>肤泽>>发绀",
"皮肤>>肤泽>>苍白",
"皮肤>>肤泽>>紫红",
"皮肤>>肤泽>>黄疸",
"皮肤>>肤泽>>黄疸>>轻",
"皮肤>>肤泽>>黄疸>>中",
"皮肤>>肤泽>>黄疸>>重",
"",
"皮肤>>皮肤花纹",
"",
"皮肤>>肢体温度>>发热",
"皮肤>>肢体温度>>温暖",
"皮肤>>肢体温度>>冰冷", 
"",
"皮肤>>弹性>>良好",
"皮肤>>弹性>>中等",
"皮肤>>弹性>>松弛",
"",
"皮肤>>皮疹>>无",
"皮肤>>皮疹>>出血点",
"皮肤>>皮疹>>瘀斑",
"皮肤>>皮疹>>湿疹",
"皮肤>>皮疹>>脓疱疹",
"皮肤>>皮疹>>脱皮",
"皮肤>>皮疹>>脱皮>>无",
"皮肤>>皮疹>>脱皮>>有",
"皮肤>>皮疹>>其他",
"皮肤>>皮疹>>其他>>部位",
"",
"皮肤>>水肿>>无",
"皮肤>>水肿>>有",
"皮肤>>水肿>>有部位",
"皮肤>>水肿>>有",
"皮肤>>水肿>>有>>轻",
"皮肤>>水肿>>有>>中",
"皮肤>>水肿>>有>>重",
"",
"皮肤>>硬肿>>无",
"皮肤>>硬肿>>有",
"皮肤>>硬肿>>有>>部位",
"皮肤>>硬肿>>有",
"皮肤>>硬肿>>有>>面积",
"皮肤>>硬肿>>有",
"皮肤>>硬肿>>有>>度",
"皮肤>>硬肿>>有"
},
				new String[]{
"皮肤：",
"\n        肤泽：",
"#正常",
"#发绀",
"#苍白",
"#紫红",
"#黄疸",
"#轻",
"#中",
"#重",
"皮肤花纹：",
"",
"肢体温度：",
"#发热",
"#温暖",
"#冰冷", 
"弹性：",
"#良好",
"#中等",
"#松弛",
"皮疹：",
"#无；",
"#出血点；",
"#瘀斑；",
"#湿疹；",
"#脓疱疹；",
"#脱皮：",
"#无；",
"#有；",
"其他：$$",
"部位：",
"\n        水肿：",
"#无",
"#有（部位：$$",
"$$",
"#）",
"#轻",
"#中",
"#重",
"皮肤硬肿：",
"#无",
"#有（部位：$$",
"$$",
"#；面积：",
"$$",
"#；度：",
"$$",
"#）"
});
			#endregion

			#region 淋巴结
			m_objPrintMultiItemArr[8].m_mthSetPrintValue(new String[]{
																		  "",
																		  "体格检查>>淋巴结>>未能触及",
																		  "体格检查>>淋巴结>>肿大",
																		  "体格检查>>淋巴结>>肿大部位",
																		  "体格检查>>淋巴结>>肿大大小",
																		  "体格检查>>淋巴结>>肿大形状",""},
				new String[]{
								"淋巴结：",
								"#未能触及",
								"#肿大；",
								"部位：$$",
								"大小：",
								"形状：",""});

			#endregion

			#region 头部


            string strHeadCM = string.Empty;
            string strHeadBW = string.Empty;
            if (m_hasItems != null)
            {
                if (!m_hasItems.Contains("头部>>形态>>正常") && m_hasItems.Contains("头部>>形态>>血肿"))
                {
                    strHeadCM = "cm；$$";
                    strHeadBW = "部位：";
                }
            }

            string strHeadQX = string.Empty;
            if (m_hasItems != null)
            {
                if (!m_hasItems.Contains("头部>>前囟>>平坦") && (m_hasItems.Contains("头部>>前囟>>凹陷") || m_hasItems.Contains("头部>>前囟>>隆起")))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["头部>>前囟>>大小"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strHeadQX += objInpatItem.m_strItemContent + "$$" + "cm；$$";
                }
            }
			//头颅
			m_objPrintMultiItemArr[9].m_mthSetPrintValue(new String[]{
"",
"",
"头部>>形态>>正常",
"头部>>形态>>产瘤",
"头部>>形态>>血肿",
"头部>>形态>>血肿内容",
"",
"",
"头部>>形态>>血肿部位",
"",
"头部>>形态>>骨缝>>正常",
"头部>>形态>>骨缝>>重叠",
"头部>>形态>>骨缝>>裂开",
"",
"头部>>畸形>>无",
"头部>>畸形>>有",
"头部>>畸形>>有内容",
"",
"头部>>前囟>>平坦",
"头部>>前囟>>凹陷",
"头部>>前囟>>隆起",
"头部>>前囟>>大小",
"头部>>前囟>>大小",
"头部>>后囟",""},
				new String[]{
"头部：",
"\n        形态：",
"#正常",
"#产瘤",
"#血肿$$",
"$$",
strHeadCM,
strHeadBW,
"",
" 骨缝：",
"#正常",
"#重叠",
"#裂开",
"畸形：",
"#无",
"#有：",
"$$",
"前囟：",
"#平坦",
"#凹陷",
"#隆起，",
"大小：$$",
"#cm$$",
"后囟：",""
});
			//眼部
			m_objPrintMultiItemArr[10].m_mthSetPrintValue(new String[]{
"",
"",
"头部>>眼部>>眼眶>>正常",
"头部>>眼部>>眼眶>>凹陷",
"",
"头部>>眼部>>眼脸>>正常",
"头部>>眼部>>眼脸>>浮肿",
"#头部>>眼部>>眼脸>>下垂",
"",
"头部>>眼部>>眼球>>正常",
"头部>>眼部>>眼球>>凸出",
"头部>>眼部>>眼球>>运动",
"头部>>眼部>>眼球>>震颤",
"",
"头部>>眼部>>结膜>>正常",
"头部>>眼部>>结膜>>充血",
"头部>>眼部>>结膜>>苍白",
"头部>>眼部>>结膜>>滤泡",
"",
"头部>>眼部>>巩膜>>正常",
"头部>>眼部>>巩膜>>黄染",
"头部>>眼部>>巩膜>>出血",
"",
"头部>>眼部>>角膜>>正常",
"头部>>眼部>>角膜>>其它",
"头部>>眼部>>角膜>>其他内容",
"",
"头部>>瞳孔>>左直径",
"",
"",
"头部>>瞳孔>>右直径",
"",
"",
"头部>>眼部>>对光反射>>存在",
"头部>>眼部>>对光反射>>迟缓",
"头部>>眼部>>对光反射>>消失",
			},
				new String[]{
"眼部：",
"\n        眼眶：",
"#正常",
"#凹陷",
"眼脸：",
"#正常",
"#浮肿",
"#下垂",
"眼球：",
"#正常",
"#凸出",
"#运动",
"#震颤",
"结膜：",
"#正常",
"#充血",
"#苍白",
"#滤泡",
"巩膜：",
"#正常",
"#黄染",
"#出血",
"角膜：",
"#正常",
"#其它",
"",
"\n        瞳孔：左直径",
"",
"mm；$$",
"右直径",
"",
"mm；$$",
"对光反射：",
"#存在；",
"#迟缓；",
"#消失；",
});
			//耳部 鼻部 口腔
			m_objPrintMultiItemArr[10].m_mthSetPrintValue(new String[]{
"",
"头部>>耳部>>正常",
"头部>>耳部>>其他",
"头部>>耳部>>其他内容",
"",
"头部>>鼻部>>正常",
"头部>>鼻部>>其他",
"头部>>鼻部>>其他内容",
"",
"",
"头部>>口腔>>唇>>红润",
"头部>>口腔>>唇>>发绀",
"头部>>口腔>>唇>>干燥",
"头部>>口腔>>唇>>苍白",
"头部>>口腔>>唇>>皲裂",
"",
"头部>>口腔>>上颚>>正常",
"头部>>口腔>>上颚>>高腭弓",
"头部>>口腔>>上颚>>腭裂",
"",
"头部>>口腔>>舌",
"",
"头部>>口腔>>颊粘膜>>正常",
"头部>>口腔>>颊粘膜>>溃烂",
"头部>>口腔>>颊粘膜>>鹅口疮",
"",
"头部>>口腔>>吐沫",""},
			new String[]{
"耳部：",
"#正常",
"#其他",
"",
"\n鼻部：",
"#正常",
"#其他：",
"$$",
"\n口腔：",
"\n        唇：",
"#红润",
"#发绀",
"#干燥",
"#苍白",
"#皲裂",
"上颚：",
"#正常",
"#高腭弓",
"#腭裂",
"舌：",
"",
"颊粘膜：",
"#正常",
"#溃烂",
"#鹅口疮",
"吐沫：",
"",""});


			#endregion

			#region 面部
			m_objPrintMultiItemArr[11].m_mthSetPrintValue(new String[]{
"",
"面部>>正常",
"面部>>异常",
"面部>>异常内容",""},
				new String[]{
"面部：",
"#正常",
"#异常：",
"$$",""});
			#endregion

			#region 颈部

            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("颈部>>正常"))
                {
                    m_objPrintMultiItemArr[12].m_mthSetPrintValue(new String[]{
																		  "",
																		  "颈部>>正常"}, new string[] {"颈部：","#正常；" });
                }
                else
                m_objPrintMultiItemArr[12].m_mthSetPrintValue(new String[]{
																		  "",
                                                                          //"颈部>>正常",
																		  "",
																		  "颈部>>强直>>有",
																		  "颈部>>强直>>无",
																		  "",
																		  "颈部>>气管>>居中",
																		  "颈部>>气管>>偏移",
																		  "颈部>>气管>>偏移内容",
                                                                          "颈部>>气管>>偏移",
																		  "",
																		  "颈部>>胸锁乳突肌血肿>>无",
																		  "颈部>>胸锁乳突肌血肿>>有",
																		  "颈部>>胸锁乳突肌血肿>>有>>左",
																		  "颈部>>胸锁乳突肌血肿>>有>>右","颈部>>胸锁乳突肌血肿>>有",
																		  "",
																		  "颈部>>锁骨骨折>>无",
																		  "颈部>>锁骨骨折>>有",
																		  "颈部>>锁骨骨折>>有>>左",
																		  "颈部>>锁骨骨折>>有>>右","颈部>>锁骨骨折>>有"},
                    new String[]{
"颈部：",
//"#正常",
"强直：",
"#有",
"#无",
"气管：",
"#居中",
"#偏移（",
"$$",
"#）$$",
"胸锁乳突肌血肿：",
"#无",
"#有（",
"#左",
"#；右",
"#）$$",
"锁骨骨折：",
"#无；",
"#有（",
"#左",
"#；右","#）；$$"
							});
            }

			#endregion

			#region 胸部

            string strHearSound = string.Empty;
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("胸部>>心脏>>心脏杂音>>有"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["胸部>>心脏>>心脏杂音>>有（性质）"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strHearSound += "；性质：" + objInpatItem.m_strItemContent + "；$$";
                }
            }
                     
			m_objPrintMultiItemArr[13].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "胸部>>胸廓>>正常",
																		  "胸部>>胸廓>>异常",
                                                                          "胸部>>胸廓>>异常内容",
                                                                          "胸部>>胸廓>>异常",
																		  "",
																		  "",
																		  "胸部>>心脏>>心率",
																		  "",
																		  "",
																		  "胸部>>心脏>>心律>>齐",
																		  "胸部>>心脏>>心律>>不齐",
																		  "",
																		  "胸部>>心脏>>心音>>有力",
																		  "胸部>>心脏>>心音>>减弱",
                                                                          "胸部>>心脏>>心音>>无",
																		  "",
																		  "胸部>>心脏>>心脏杂音>>无",
																		  "胸部>>心脏>>心脏杂音>>有",
																		  "",
																		  "",
																		  "胸部>>心脏>>心尖搏动位置",
																		  ""},
				new String[]{
"胸部：",
"\n        胸廓：",
"#正常",
"#异常（$$",
"$$",
"#）$$",
"\n        心脏：",
"心率：",
"",
"次/分；$$",
"心律：",
"#齐",
"#不齐",
"心音：",
"#有力",
"#减弱",
"#无",
"\n        心脏杂音：",
"#无",
"#有",
strHearSound,
"心尖搏动位置：",
"",
""});

			m_objPrintMultiItemArr[13].m_mthSetPrintValue(new String[]{
																		  "",
                                                                          //"",
                                                                          //"胸部>>肺部>>望诊>>触诊",
                                                                          //"胸部>>肺部>>望诊>>叩诊",
                                                                          //"胸部>>肺部>>望诊>>听诊",
																		  "",
																		  "胸部>>肺部>>呼吸>>平静",
																		  "胸部>>肺部>>呼吸>>急促",
																		  "胸部>>肺部>>呼吸>>浅弱",
																		  "胸部>>肺部>>呼吸>>暂停呼吸",
																		  "胸部>>肺部>>呼吸>>三凹征",
																		  "胸部>>肺部>>呼吸>>鼻翼扇动",
																		  "胸部>>肺部>>呼吸>>潮式呼吸",
																		  "胸部>>肺部>>呼吸>>呻吟",
																		  "",
																		  "胸部>>肺部>>呼吸>>双侧呼吸音>>对称",
																		  "胸部>>肺部>>呼吸>>双侧呼吸音>>粗",
																		  "胸部>>肺部>>呼吸>>双侧呼吸音>>清",
																		  "胸部>>肺部>>呼吸>>双侧呼吸音>>减弱",
																		  "",
																		  "胸部>>肺部>>呼吸>>罗音>>无",
																		  "胸部>>肺部>>呼吸>>罗音>>有",
																		  "胸部>>肺部>>呼吸>>罗音>>有内容",
																		  "",
																		  "胸部>其他",""},
				new String[]{
"\n        肺部：",
//"望诊：",
//"#触诊",
//"#叩诊",
//"#听诊",
"呼吸：",
"#平静；",
"#急促；",
"#浅弱；",
"#呼吸暂停；",
"#三凹征；",
"#鼻翼煽动；",
"#潮式呼吸；",
"#呻吟；",
"双侧呼吸音：$$",
"#对称；",
"#粗；",
"#清；",
"#减弱；",
"罗音：$$",
"#无",
"#有：",
"$$",
"其他：",
"",""});


			#endregion

			#region 腹部

            string strVenterWallAche = string.Empty;
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("腹部>>腹壁>>于部位有触痛"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["腹部>>腹壁>>于部位有触痛内容"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strVenterWallAche += "#于" + objInpatItem.m_strItemContent + " 部位有触痛";
                }
            }

            string strbVenterPackage = string.Empty;
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("腹部>>腹部包块>>有"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["腹部>>腹部包块>>位置"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strbVenterPackage += "（位置：" + objInpatItem.m_strItemContent + "；";

                    objInpatItem = m_hasItems["腹部>>腹部包块>>性状"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strbVenterPackage += "性状：" + objInpatItem.m_strItemContent + "；";

                    objInpatItem = m_hasItems["腹部>>腹部包块>>大小"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                    strbVenterPackage += "大小：" + objInpatItem.m_strItemContent + "cm）；$$";
                }
            }

			m_objPrintMultiItemArr[14].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "腹部>>望诊>>外观正常",
																		  "腹部>>望诊>>膨隆",
																		  "腹部>>望诊>>凹陷",
																		  "腹部>>望诊>>胃肠蠕动波",
																		  "",
																		  "腹部>>脐>>正常",
																		  "腹部>>脐>>脐息肉",
																		  "腹部>>脐>>出血",
																		  "腹部>>脐>>脐疝",
																		  "腹部>>脐>>脐膨出",
                                                                          "腹部>>脐>>分泌物",
																		  "腹部>>脐>>分泌物内容",
                                                                          "腹部>>脐>>分泌物内容",
																		  "腹部>>脐>>脐带",
																		  "腹部>>脐>>已脱",
																		  "腹部>>脐>>脐带>>未脱",
																		  "",
																		  "腹部>>腹壁静脉怒张、潮红",
                                                                          "",
                                                                          "腹部>>触诊",
                                                                          "",
																		  "腹部>>腹壁>>柔软",
																		  "腹部>>腹壁>>紧张",
																		  "腹部>>腹壁>>于部位有触痛",
																		  "",
																		  "腹部>>腹部包块>>无",
																		  "腹部>>腹部包块>>有",
																		  "",
                                                                          "",
                                                                          "腹部>>肝脏>>未触及",
                                                                        "腹部>>肝脏>>触及",
                                                                        "腹部>>肝脏>>触及",
                                                                        "腹部>>肝脏>>肋下",
                                                                        "腹部>>肝脏>>触及",
                                                                        "腹部>>肝脏>>剑突下",
                                                                        "腹部>>肝脏>>触及",
                                                                        "腹部>>肝脏>>触及>>质地>>软",
                                                                        "腹部>>肝脏>>触及>>质地>>中",
                                                                        "腹部>>肝脏>>触及>>质地>>硬",
                                                                        "腹部>>肝脏>>触及",
                                                                        "",
                                                                        "腹部>>脾脏>>未触及",
                                                                        "腹部>>脾脏>>触及",
                                                                        "腹部>>脾脏>>触及",
                                                                        "腹部>>脾脏>>肋下",
                                                                        "腹部>>脾脏>>触及",
                                                                        "腹部>>脾脏>>触及>>质地>>坚实",
                                                                        "腹部>>脾脏>>触及>>质地>>柔软",
                                                                        "腹部>>脾脏>>触及",
                                                                        "",
                                                                        "腹部>>肾脏",""
                                                                          },
				new String[]{
"腹部：",
"\n        望诊：",
"#外观正常",
"#膨隆",
"#凹陷",
"#胃肠蠕动波",
"脐：",
"#正常",
"#脐息肉",
"#出血",
"#脐疝",
"#脐膨出",
"#分泌物（$$",
"$$",
"#性）",
"#脐带",
"#已脱",
"#未脱",
"腹壁静脉怒张、潮红：",
"$$",
"\n        触诊：",
"$$",
"腹壁：",
"#柔软",
"#紧张",
strVenterWallAche,
"\n                    腹部包块：",
"#无",
"#有",
strbVenterPackage,
"\n                    肝脏：",
"#未触及",
"#触及（",
"#肋下$$",
"$$",
"#cm；剑突下$$",
"$$",
"#cm；质地：$$",
"#软$$",
"#中$$",
"#硬$$",
"#）",
"\n                    脾脏：",
"#未触及",
"#触及（",
"#肋下$$",
"$$",
"#cm；质地：$$",
"#坚实$$",
"#柔软$$",
"#）",
"\n                    肾脏：",
"$$",
""                });
			m_objPrintMultiItemArr[14].m_mthSetPrintValue(new String[]{
																		  "",
																		  "腹部>>叩诊>>正常",
																		  "腹部>>叩诊>>移动性浊音",
																		  "腹部>>叩诊>>鼓音",
																		  "",
                                                                          "腹部>>肠鸣音>>正常",
																		  "腹部>>肠鸣音>>亢进",
																		  "腹部>>肠鸣音>>减弱",
																		  "腹部>>肠鸣音>>消失",
                                                                          "",
																		  "腹部>>听诊",
                                                                          ""																		  
																		  },
				new String[]{
"\n        叩诊：",
"#正常",
"#移动性浊音",
"#鼓音",
"肠鸣音：",  
"#正常",
"#亢进",
"#减弱",
"#消失",                    
"\n        听诊：",
"$$",
""});

			#endregion

			#region 腹股沟

            string strGroinInclined = "#斜疝；";
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("腹股沟>>斜疝"))
                {

                    clsInpatMedRec_Item objInpatItem = m_hasItems["腹部沟>>斜疝内容"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                        strGroinInclined = "#斜疝（" + objInpatItem.m_strItemContent + "侧）；$$";
                }
            }
            string strGroinStraight = "#直疝；";
            if(m_hasItems != null)
            {
                if (m_hasItems.Contains("腹股沟>>直疝"))
                {
                    clsInpatMedRec_Item objInpatItem = m_hasItems["腹部沟>>直疝内容"] as clsInpatMedRec_Item;
                    if (objInpatItem != null)
                        strGroinStraight = "#直疝（" + objInpatItem.m_strItemContent + "侧）；$$";
                }
            }
            
			m_objPrintMultiItemArr[15].m_mthSetPrintValue(new String[]{
																		  "",
																		  "腹股沟>>正常",
																		  "腹股沟>>斜疝",
                                                                          //"腹部沟>>斜疝内容",
                                                                          //"",
																		  "腹股沟>>直疝",
                                                                          //"腹部沟>>直疝内容",
                                                                          //""
                                                                          },
				new String[]{
"腹股沟：",
"#正常；",
strGroinInclined,
//"#斜疝",
//"$$",
//"侧",
strGroinStraight,
//"#直疝",
//"$$",
//"侧"
                });

			#endregion

			#region 肛门
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(new String[]{
																		  "",
																		  "肛门>>正常",
																		  "肛门>>闭锁",
																		  "肛门>>闭锁内容",
                                                                          "肛门>>闭锁",
																		  "肛门>>肛周皮肤",
																		  "肛门>>肛周皮肤内容","肛门>>肛周皮肤",""},
				new String[]{
"肛门：",
"#正常",
"#闭锁（",
"$$",
"#）$$",
"#肛周皮肤（",
"$$","#）$$",""});

			#endregion

			#region 外生殖器
            string strSpermaryNoDown = string.Empty;
            if (m_objPrintInfo.m_strSex.Trim() == "男")
            {
                //if (m_hasItems != null)
                //{
                //    if (m_hasItems.Contains("外生殖器>>男>>睾丸>>未下降"))
                //        strSpermaryNoDown += "侧）";
                //}
                m_objPrintMultiItemArr[17].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "外生殖器>>会阴>>正常",
																		  "外生殖器>>会阴>>其他",
																		  "外生殖器>>会阴>>其他内容",
                                                                          "外生殖器>>会阴>>其他",
																		  "",
																		  "外生殖器>>男>>阴茎>>正常",
																		  "外生殖器>>男>>阴茎>>畸形",
																		  "外生殖器>>男>>阴茎>>畸形内容",
                                                                          "外生殖器>>男>>阴茎>>畸形",
																		  "",
																		  "外生殖器>>男>>阴囊>>正常",
																		  "外生殖器>>男>>阴囊>>水肿",
																		  "外生殖器>>男>>阴囊>>色素沉着",
																		  "",
																		  "外生殖器>>男>>睾丸>>下降",
																		  "外生殖器>>男>>睾丸>>未下降",
																		  "外生殖器>>男>>睾丸>>未下降内容",
																		  "外生殖器>>男>>睾丸>>未下降",
																		  "",
																		  "外生殖器>>男>>睾丸>>积液>>有",
																		  "外生殖器>>男>>睾丸>>积液>>无"},
                    new String[]{
"外生殖器：",
"\n        会阴部：",
"#正常",
"#其他（",
"$$",
"#）$$",
"\n        男：阴茎：",
"#正常",
"#畸形（",
"$$",
"#）$$",
"阴囊：",
"#正常",
"#水肿",
"#色素沉着",
"睾丸：",
"#下降",
"#未下降（",
"$$",
"#侧）；$$",
"积液：$$",
"#有；",
"#无；"});
            }
            else
            {
                m_objPrintMultiItemArr[17].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "外生殖器>>会阴>>正常",
																		  "外生殖器>>会阴>>其他",
																		  "外生殖器>>会阴>>其他内容",
																		  "",
																		  "外生殖器>>女>>外阴部>>正常",
																		  "外生殖器>>女>>外阴部>>水肿",
																		  "外生殖器>>女>>外阴部>>阴道分泌物",
																		  "外生殖器>>女>>外阴部>>阴道分泌物内容",
                                                                          "外生殖器>>女>>外阴部>>阴道分泌物",
																		  "",
																		  "外生殖器>>女>>外阴部>>大阴唇盖小阴唇>>未",
																		  "外生殖器>>女>>外阴部>>大阴唇盖小阴唇>>已"},
                      new String[]{
"外生殖器：",
"\n        会阴部：",
"#正常",
"#其他：",
"$$",
"\n        女：外阴部：",
"#正常",
"#水肿",
"#阴道分泌物（",
"$$",
"#）$$",
"大阴唇盖小阴唇：",
"#未；",
"#已；"}); 
            }
			#endregion

			#region 四肢
			m_objPrintMultiItemArr[18].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "四肢>>活动>>正常",
																		  "四肢>>活动>>减弱",
																		  "四肢>>活动>>减弱内容",
																		  "四肢>>活动>>震颤、抽搐部位",
																		  "四肢>>活动>>震颤、抽搐部位内容",
                                                                          "四肢>>活动>>震颤、抽搐部位",
																		  "四肢>>活动>>瘫痪部位",
																		  "四肢>>活动>>瘫痪部位内容",
                                                                          "四肢>>活动>>瘫痪部位",
																		  "",
																		  "四肢>>肌张力>>正常",
																		  "四肢>>肌张力>>增高",
																		  "四肢>>肌张力>>减弱",
																		  "",
																		  "四肢>>畸形>>无",
																		  "四肢>>畸形>>有",
																		  "四肢>>畸形>>有内容","四肢>>畸形>>有",""},
				new String[]{
"四肢：",
"活动：",
"#正常",
"#减弱：",
"$$",
"#震颤、抽搐（部位：",
"$$",
"#）$$",
"#瘫痪（部位：",
"$$",
"#）$$",
"肌张力：",
"#正常",
"#增高",
"#减弱",
"畸形：",
"#无",
"#有（",
"$$","#）$$",""});

			#endregion

			#region 脊柱
			m_objPrintMultiItemArr[19].m_mthSetPrintValue(new String[]{
																		  "",
																		  "脊柱>>畸形>>正常",
																		  "脊柱>>畸形>>畸形",
																		  "脊柱>>畸形>>畸形内容", "脊柱>>畸形>>畸形",""},
				new String[]{
"脊柱：",
"#正常",
"#畸形（",
"$$","#）$$",""});

			#endregion

			#region 神经反射
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "神经反射>>拥抱反射",
																		  "",
																		  "神经反射>>吮吸反射",
																		  "",
																		  "神经反射>>觅食反射",
																		  "",
																		  "神经反射>>握持反射",
																		  "",
                                                                          "",
																		  "神经反射>>巴氏征>>左",
                                                                          "",
																		  "神经反射>>巴氏征>>右",
																		  "",
                                                                          "",
																		  "神经反射>>布氏征>>左",
                                                                          "",
																		  "神经反射>>布氏征>>右",
                                                                          "",
                                                                          "",
																		  "神经反射>>克氏征>>左",
                                                                          "",
																		  "神经反射>>克氏征>>右",
																		  ""},
				new String[]{
"神经反射：",
"\n        拥抱反射：",
"",
"吮吸反射：",
"",
"觅食反射：",
"",
"握持反射：",
"",
"\n        巴氏征（",
"左：",
"$$",
"；右：$$",
"$$",
"）；布氏征（$$",
"左：",
"$$",
"；右：$$",
"$$",
"）；克氏征（$$",
"左：",
"$$",
"；右：$$",
"$$",
"）；$$"});

			#endregion

			#region 胎龄评估
            int intPoint1 = 0;
            int intPoint2 = 0;
            int intPoint3 = 0;
            int intPoint4 = 0;
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("胎龄评价>>足底纹理>>0"))
                    intPoint1 = 0;
                else if (m_hasItems.Contains("胎龄评价>>足底纹理>>1"))
                    intPoint1 = 1;
                else if (m_hasItems.Contains("胎龄评价>>足底纹理>>2"))
                    intPoint1 = 2;
                else if (m_hasItems.Contains("胎龄评价>>足底纹理>>3"))
                    intPoint1 = 3;
                else if (m_hasItems.Contains("胎龄评价>>足底纹理>>4"))
                    intPoint1 = 4;

                if (m_hasItems.Contains("胎龄评价>>乳头形式>>0"))
                    intPoint2 = 0;
                else if (m_hasItems.Contains("胎龄评价>>乳头形式>>1"))
                    intPoint2 = 1;
                else if (m_hasItems.Contains("胎龄评价>>乳头形式>>2"))
                    intPoint2 = 2;
                else if (m_hasItems.Contains("胎龄评价>>乳头形式>>3"))
                    intPoint2 = 3;
                else if (m_hasItems.Contains("胎龄评价>>乳头形式>>4"))
                    intPoint2 = 4;

                if (m_hasItems.Contains("胎龄评价>>指甲>>0"))
                    intPoint3 = 0;
                else if (m_hasItems.Contains("胎龄评价>>指甲>>1"))
                    intPoint3 = 1;
                else if (m_hasItems.Contains("胎龄评价>>指甲>>2"))
                    intPoint3 = 2;
                else if (m_hasItems.Contains("胎龄评价>>指甲>>3"))
                    intPoint3 = 3;
                else if (m_hasItems.Contains("胎龄评价>>指甲>>4"))
                    intPoint3 = 4;

                if (m_hasItems.Contains("胎龄评价>>皮肤组织>>0"))
                    intPoint4 = 0;
                else if (m_hasItems.Contains("胎龄评价>>皮肤组织>>1"))
                    intPoint4 = 1;
                else if (m_hasItems.Contains("胎龄评价>>皮肤组织>>2"))
                    intPoint4 = 2;
                else if (m_hasItems.Contains("胎龄评价>>皮肤组织>>3"))
                    intPoint4 = 3;
                else if (m_hasItems.Contains("胎龄评价>>皮肤组织>>4"))
                    intPoint4 = 4;
            }
            int intPoints = intPoint1 + intPoint2 + intPoint3 + intPoint4;
            int intWeeks = intPoints + 27;
            string strTemp = "\n        新生儿胎龄评估表（胎龄周数＝总分＋27＝" + intWeeks.ToString() + "周），出生七天内者评分";
			m_objPrintMultiItemArr[21].m_mthSetPrintValue(new String[]{
																		  "",
																		  "",
																		  "",
																		  "",
																		  "",
																		  "",
																		  "",
																		  "",
																		  "",
																		  "胎龄评价>>足底纹理>>0",
																		  "胎龄评价>>足底纹理>>1",
																		  "胎龄评价>>足底纹理>>2",
																		  "胎龄评价>>足底纹理>>3",
																		  "胎龄评价>>足底纹理>>4",
																		  "",
																		  "胎龄评价>>乳头形式>>0",
																		  "胎龄评价>>乳头形式>>1",
																		  "胎龄评价>>乳头形式>>2",
																		  "胎龄评价>>乳头形式>>3",
																		  "胎龄评价>>乳头形式>>4",
																		  "",
																		  "胎龄评价>>指甲>>0",
																		  "胎龄评价>>指甲>>1",
																		  "胎龄评价>>指甲>>2",
																		  "胎龄评价>>指甲>>3",
																		  "胎龄评价>>指甲>>4",
																		  "",
																		  "胎龄评价>>皮肤组织>>0",
																		  "胎龄评价>>皮肤组织>>1",
																		  "胎龄评价>>皮肤组织>>2",
																		  "胎龄评价>>皮肤组织>>3",
																		  "胎龄评价>>皮肤组织>>4",""},
				new String[]{
"\n胎龄评估：",
strTemp,
"\n体征    ",
"   0分",
"   1分",
"   2分",
"   3分",
"   4分",
"\n足底纹理：",
"#0",
"#1",
"#2",
"#3",
"#4",
"\n乳头形式：",
"#0",
"#1",
"#2",
"#3",
"#4",
"\n指甲：",
"#0",
"#1",
"#2",
"#3",
"#4",
"\n 皮肤组织：",
"#0",
"#1",
"#2",
"#3",
"#4",""});

			#endregion

			#region 重点补充
				m_objPrintOneItemArr[2].m_mthSetPrintValue("重点补充","重点补充：");
			#endregion

			#region 辅助检查
				m_objPrintOneItemArr[3].m_mthSetPrintValue("辅助检查","辅助检查：");
			#endregion

            /*
			#region 诊断
                m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "诊断", "诊断医师签名", "诊断签名日期" }, 
                                    new string[] { "诊断：", "\n                                                  医师签名：$$", "      签名日期：$$" });
			#endregion

			#region 签名和日期
                m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "住院医师签名", "上级医师签名", "签名日期" }, new string[] { "住院医师签名：", "上级医师签名：", "日期：" });
			#endregion
            */
            #region 诊断
                if (m_hasItems != null && m_hasItems.Contains("诊断"))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "诊断" }, new string[] { "\n诊断：" });
                    if (m_hasItems.Contains("诊断医师签名"))
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "诊断医师签名", "诊断签名日期" },
                                    new string[] { "\n                                                            医师签名：", "                 日期：$$" });
                    }
                    else
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "诊断" },
                                    new string[] { "#\n                                                            医师签名：                             日期：" });
                    }
                }

            #endregion
            #region 补充诊断

                if (m_hasItems != null && m_hasItems.Contains("补充诊断"))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "补充诊断" }, new string[] { "\n\n补充诊断：" });
                    if (m_hasItems.Contains("补充诊断医师签名"))
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "补充诊断医师签名", "补充诊断签名日期" },
                                    new string[] { "\n                                                            医师签名：", "                 日期：$$" });
                    }
                    else
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "补充诊断" },
                                    new string[] { "#\n                                                            医师签名：                             日期：" });
                    }
                }

            #endregion
            
			#region 修正诊断

                if (m_hasItems != null && m_hasItems.Contains("修正诊断"))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "修正诊断" }, new string[] { "\n\n修正诊断：" });
                    if (m_hasItems.Contains("修正诊断医师签名"))
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "修正诊断医师签名", "修正诊断签名日期" },
                                    new string[] { "\n                                                            医师签名：", "                 日期：$$" });
                    }
                    else
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "修正诊断" },
                                    new string[] { "#\n                                                            医师签名：                             日期：" });
                    }
                }
				
			#endregion

			#region 最后诊断
                if (m_hasItems != null && m_hasItems.Contains("最后诊断"))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "最后诊断" }, new string[] { "\n\n最后诊断：" });
                    if (m_hasItems.Contains("最后诊断医师签名"))
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "最后诊断医师签名", "最后诊断签名日期" },
                                    new string[] { "\n                                                            医师签名：", "                 日期：$$" });
                    }
                    else
                    {
                        m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "最后诊断" },
                                    new string[] { "#\n                                                            医师签名：                             日期：" });
                    }
                }

			#endregion
			
			#region 签名和日期
                if (m_hasItems != null && (m_hasItems.Contains("住院医师签名") || m_hasItems.Contains("上级医师签名")))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "", "住院医师签名", "", "住院医师签名日期", "", "上级医师签名", "", "上级医师签名日期" },
                        new string[]{"\n\n                                                                                      住院医师签名：","$$",  
                                         "\n                                                                                      签名日期：$$","$$",
                                         "\n                                                                                      上级医师签名：$$","$$",
                                         "\n                                                                                      签名日期：$$","$$"});
                }
                else
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue(new string[] { "上级医师签名日期", "上级医师签名日期", "上级医师签名日期", "上级医师签名日期" },
                            new string[]{"#\n\n                                                                                   住院医师签名：",
                                         "#\n                                                                                   签名日期：$$",
                                         "#\n                                                                                   上级医师签名：$$",
                                         "#\n                                                                                   签名日期：$$"});
                }
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
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+420,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+420,p_intPosY);
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
