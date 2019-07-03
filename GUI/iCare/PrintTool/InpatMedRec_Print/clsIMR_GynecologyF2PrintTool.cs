using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 妇科打印工具
    /// </summary>
    public class clsIMR_GynecologyF2PrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_GynecologyF2PrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
        }    

        private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
        private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
        private clsPrintInPatMedRecSign[] m_objPrintSignArr; 


        private clsPrintInPatMedRecCurePlan[] m_objPrintCurePlanArr;

        protected override void m_mthSetPrintLineArr()
        {
            m_mthInitPrintLineArr();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("妇科住院病历",310),
										  m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],
										  m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[5],m_objPrintMultiItemArr[1],m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
										  m_objPrintOneItemArr[2],m_objPrintOneItemArr[3],
										  m_objPrintMultiItemArr[6],m_objPrintMultiItemArr[7],
										 new clsPrintInPatMedRecPic(),	
					                   m_objPrintOneItemArr[4],/* m_objPrintOneItemArr[8],*/m_objPrintSignArr[0],m_objPrintOneItemArr[12],m_objPrintOneItemArr[13],
                                         /* m_objPrintOneItemArr[7], m_objPrintOneItemArr[10], m_objPrintOneItemArr[11], m_objPrintOneItemArr[9],*/m_objPrintOneItemArr[5],m_objPrintSignArr[1],
                                        m_objPrintOneItemArr[6],m_objPrintSignArr[2],m_objPrintOneItemArr[14],m_objPrintSignArr[3]
                                        //m_objPrintCurePlanArr[1],m_objPrintCurePlanArr[0],m_objPrintCurePlanArr[4],m_objPrintCurePlanArr[2],m_objPrintCurePlanArr[3],
                                        //m_objPrintSignArr[1],m_objPrintSignArr[2]
                                        ////m_objPrintCurePlanArr[2],m_objPrintCurePlanArr[0],m_objPrintCurePlanArr[5],m_objPrintCurePlanArr[3],m_objPrintCurePlanArr[4],
                                        ////m_objPrintSignArr[1],m_objPrintSignArr[2],  m_objPrintOneItemArr[4],m_objPrintOneItemArr[5],m_objPrintSignArr[3],m_objPrintOneItemArr[6],m_objPrintSignArr[4],m_objPrintSignArr[0],
			});
        }

        private void m_mthInitPrintLineArr()
        {
            m_objPrintOneItemArr = new clsPrintInPatMedRecItem[15];
            for (int i1 = 0; i1 < m_objPrintOneItemArr.Length; i1++)
                m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

            m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[9];
            for (int j2 = 0; j2 < m_objPrintMultiItemArr.Length; j2++)
                m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

            m_objPrintSignArr = new clsPrintInPatMedRecSign[4];
            for (int k3 = 0; k3 < m_objPrintSignArr.Length; k3++)
                m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();

            m_objPrintCurePlanArr = new clsPrintInPatMedRecCurePlan[5];
            for (int m4 = 0; m4 < m_objPrintCurePlanArr.Length; m4++)
                m_objPrintCurePlanArr[m4] = new clsPrintInPatMedRecCurePlan();
        }
        /// <summary>
        /// 判断打印内容是否为空
        /// </summary>
        /// <param name="p_strKeysArr">哈希键数组</param>
        /// <returns></returns>
        protected bool m_blnHavePrintInfo(string[] p_strKeysArr)
        {
            if (m_hasItems == null || m_hasItems.Count < 1)
                return false;
            for (int i = 0; i < p_strKeysArr.Length; i++)
            {
                if (m_hasItems.Contains(p_strKeysArr[i]))
                    return true;
            }
            return false;
        }

        protected override void m_mthSetSubPrintInfo()
        {
            #region 单个项目
            m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉", "主诉：");
            m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史", "现病史：");
            m_objPrintOneItemArr[2].m_mthSetPrintValue("以往妇科疾患", "以往妇科疾患：");
            m_objPrintOneItemArr[3].m_mthSetPrintValue("家族史", "家族史：");

            //if (m_hasItems != null)
            //    if (m_hasItems.Contains("病史与体检小结"))
            //        objItemContent = m_hasItems["病史与体检小结"] as clsInpatMedRec_Item;

            if (m_hasItems != null)
                if (m_hasItems.Contains("初步诊断"))
                {
                    m_objPrintOneItemArr[4].m_mthSetPrintValue("初步诊断", "入院诊断：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("修正诊断"))
                {
                    m_objPrintOneItemArr[5].m_mthSetPrintValue("修正诊断", "修正诊断：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("补充诊断"))
                {
                    m_objPrintOneItemArr[6].m_mthSetPrintValue("补充诊断", "补充诊断：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("诊疗计划>>入院诊断"))
                {
                    m_objPrintOneItemArr[7].m_mthSetPrintValue("诊疗计划>>入院诊断", "院诊断：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("诊疗计划>>诊断根据"))
                {
                    m_objPrintOneItemArr[8].m_mthSetPrintValue("诊疗计划>>诊断根据", "诊断根据：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("诊疗计划>>鉴别诊断"))
                {
                    m_objPrintOneItemArr[9].m_mthSetPrintValue("诊疗计划>>鉴别诊断", "鉴别诊断：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("诊疗计划>>入院后拟行检查项目"))
                {
                    m_objPrintOneItemArr[10].m_mthSetPrintValue("诊疗计划>>入院后拟行检查项目", "入院后拟行检查项目：");
                }
            if (m_hasItems != null)
                if (m_hasItems.Contains("诊疗计划>>诊疗计划"))
                {
                    m_objPrintOneItemArr[11].m_mthSetPrintValue("诊疗计划>>诊疗计划", "诊疗计划：");
                }
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("实验室检查"))
                {
                    m_objPrintOneItemArr[12].m_mthSetSpecialTitleValue("实验室检查", "");
                    m_objPrintOneItemArr[13].m_mthSetPrintValue("实验室检查", " ");
                }
            }
            if (m_hasItems != null)
                if (m_hasItems.Contains("最后诊断"))
                {
                    m_objPrintOneItemArr[14].m_mthSetPrintValue("最后诊断", "最后诊断：");
                }

            //m_objPrintOneItemArr[4].m_mthSetPrintValue("初步诊断", "初步诊断：");
            //m_objPrintOneItemArr[5].m_mthSetPrintValue("修正诊断", "修正诊断：");
            //m_objPrintOneItemArr[6].m_mthSetPrintValue("补充诊断", "补充诊断：");
            //m_objPrintOneItemArr[7].m_mthSetPrintValue("诊疗计划>>入院诊断", "入院诊断：");
            //m_objPrintOneItemArr[8].m_mthSetPrintValue("诊疗计划>>诊断根据", "诊断根据：");
            //m_objPrintOneItemArr[9].m_mthSetPrintValue("诊疗计划>>鉴别诊断", "鉴别诊断：");
            //m_objPrintOneItemArr[10].m_mthSetPrintValue("诊疗计划>>入院后拟行检查项目", "入院后拟行检查项目：");
            //m_objPrintOneItemArr[11].m_mthSetPrintValue("诊疗计划>>诊疗计划", "诊疗计划：");


            #endregion

            #region 月经史
            m_objPrintMultiItemArr[0].m_mthSetSpecialTitleValue("", "月经史：");
           // p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "", "月经史>>初潮>>初潮", "月经史>>初潮>>周期", "月经史>>初潮>>持续", "月经史>>初潮>>排量", "月经史>>初潮>>血块" }
				, new string[] { "初潮：", "", "周期：", "持续：", "经量：", "血块：" });
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "", "月经史>>痛经>>发生年龄", "", "月经史>>痛经>>经前", "月经史>>痛经>>经期", "月经史>>痛经>>经后", "月经史>>痛经>>腹痛", "月经史>>痛经>>腰痛", "月经史>>痛经>>呕吐", "月经史>>痛经>>其他", "月经史>>痛经>>程度" }
				, new string[] { "\n痛经：", "发生年龄：", "发生时期：", "经前：", "经期：", "经后：", "腹痛：", "腰痛：", "呕吐：", "其他：", "程度：" });
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "", "月经史>>末次月经>>末次月经", "月经史>>末次月经>>排量", "月经史>>末次月经>>颜色", "月经史>>末次月经>>日数" }
				, new string[] { "\n末次月经：", "", "经量：", "颜色：", "日数：" });
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "", "月经史>>末次前月经>>末次前月经", "月经史>>末次前月经>>排量", "月经史>>末次前月经>>颜色", "月经史>>末次前月经>>日数" }
				, new string[] { "\n末次前月经：", "", "经量：", "颜色：", "日数：" });
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "", "月经史>>白带>>量", "月经史>>白带>>色", "月经史>>白带>>嗅" }
				, new string[] { "\n白带：", "量：", "色：", "嗅：" });
            #endregion

            #region 个人史及结婚史,生育史,避孕情况,既往史
            m_objPrintMultiItemArr[1].m_mthSetSpecialTitleValue("", "结婚史：");
            m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[] { "个人及结婚史>>婚次", "个人及结婚史>>结婚年龄", "个人及结婚史>>爱人现年", "个人及结婚史>>健康情况", "个人及结婚史>>性病史" }
				, new string[] { "婚次：", "结婚年龄：", "爱人现年：", "健康情况：", "性病史：" });

            m_objPrintMultiItemArr[2].m_mthSetSpecialTitleValue("", "生育史：");
            m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[] { "生育史>>足月产", "生育史>>早产", "生育史>>自然流产", "生育史>>人工流产", "生育史>>末次产", "生育史>>产后情况", "", "生育史>>子", "生育史>>女", "生育史>>其它" }
				, new string[] { "足月产：", "早产：", "自然流产：", "人工流产：", "末次产：", "产后情况：", "  现存：", "子：", "女：", "\n其他(病理及手术情况)：" });

            m_objPrintMultiItemArr[3].m_mthSetSpecialTitleValue("", "避孕情况：");
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "避孕情况>>避孕情况", "避孕情况>>避孕方法", "避孕情况>>计划生育措施" }
				, new string[] { "避孕情况：", "避孕方法：", "计划生育措施：" });

            m_objPrintMultiItemArr[4].m_mthSetSpecialTitleValue("", "既往史：");
            m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[] { "既往史>>心脏病", "既往史>>结核", "既往史>>肝炎", "既往史>>肾炎", "既往史>>性病", "既往史>>其它" }
				, new string[] { "心脏病：", "结核：", "肝炎：", "肾炎：", "性病：", "其它：" });

            m_objPrintMultiItemArr[5].m_mthSetSpecialTitleValue("", "个人史：");
            m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[] { "个人>>出生地", "个人史>>经历地", "个人史>>居留地", "个人史>>嗜好" }
				, new string[] { "出生地：", "经历地：", "居留地：", "嗜好：" });

            #endregion

            #region 体格检查
            Boolean blnMedical = false;
            if (m_blnHavePrintInfo(new string[] { "体格检查>>体温", "体格检查>>脉搏", "体格检查>>呼吸", "体格检查>>血压", "体格检查>>体重" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>一般情况>>发育", "体格检查>>一般情况>>营养", "体格检查>>一般情况>>表情", "体格检查>>一般情况>>神智", "体格检查>>一般情况>>合作" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>皮肤>>黄疸", "体格检查>>皮肤>>斑疹", "体格检查>>皮肤>>失水", "体格检查>>皮肤>>其他" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>淋巴腺>>锁骨窝", "体格检查>>淋巴腺>>腋下", "体格检查>>淋巴腺>>腹股沟", "体格检查>>淋巴腺>>其他", "体格检查>>头部", "体格检查>>颈部" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>胸部>>胸廓", "体格检查>>胸部>>心脏", "体格检查>>胸部>>肺", "体格检查>>胸部>>乳房", "体格检查>>胸部>>其他" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>腹部>>腹壁", "体格检查>>腹部>>压痛", "体格检查>>腹部>>肝", "体格检查>>腹部>>脾", "体格检查>>腹部>>肾", "体格检查>>腹部>>波动感", "体格检查>>腹部>>肠蠕动", "体格检查>>腹部>>肿物" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>脊柱>>畸形", "体格检查>>脊柱>>活动度", "体格检查>>脊柱>>叩击痛", "体格检查>>脊柱>>其他" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "体格检查>>四肢>>畸形", "体格检查>>四肢>>活动度", "体格检查>>四肢>>膝反射" }) == true)
            {
                blnMedical = true;
            }
            if (m_blnHavePrintInfo(new string[] { "", "神经系统>>膝反射", "神经反射>>病理神经反射" }) == true)
            {
                blnMedical = true;
            }
            if (blnMedical == true)
            {
                m_objPrintMultiItemArr[6].m_mthSetSpecialTitleValue("体格检查", "");
            }
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "体格检查>>体温", "体格检查>>脉搏", "体格检查>>呼吸", "体格检查>>血压", "体格检查>>体重","" }
				, new string[] { "体温：", "℃   脉搏：$$", "次/分   呼吸：$$", "次/分   血压：$$", "mmHg   体重：$$" ,"Kg$$"});
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>一般情况>>发育", "体格检查>>一般情况>>营养", "体格检查>>一般情况>>表情", "体格检查>>一般情况>>神智", "体格检查>>一般情况>>合作" }
				, new string[] { "\n一般情况：", "发育：", "营养：", "表情：", "神智：", "合作：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>皮肤>>黄疸", "体格检查>>皮肤>>斑疹", "体格检查>>皮肤>>失水", "体格检查>>皮肤>>其他" }
				, new string[] { "\n皮肤：", "黄疸：", "斑疹：", "失水：", "其他：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>淋巴腺>>锁骨窝", "体格检查>>淋巴腺>>腋下", "体格检查>>淋巴腺>>腹股沟", "体格检查>>淋巴腺>>其他", "体格检查>>头部", "体格检查>>颈部" }
				, new string[] { "\n淋巴腺：", "锁骨窝：", "腋下：", "腹股沟：", "其他：", "\n头部：", "颈部：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>胸部>>胸廓", "体格检查>>胸部>>心脏", "体格检查>>胸部>>肺", "体格检查>>胸部>>乳房", "体格检查>>胸部>>其他" }
				, new string[] { "\n胸部：", "胸廓：", "心脏：", "肺：", "乳房：", "其他" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>腹部>>腹壁", "体格检查>>腹部>>压痛", "体格检查>>腹部>>肝", "体格检查>>腹部>>脾", "体格检查>>腹部>>肾", "体格检查>>腹部>>波动感", "体格检查>>腹部>>肠蠕动", "体格检查>>腹部>>肿物" }
				, new string[] { "\n腹部：", "腹壁：", "压痛：", "肝：", "脾：", "肾：", "波动感：", "肠蠕动：", "肿物：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>脊柱>>畸形", "体格检查>>脊柱>>活动度", "体格检查>>脊柱>>叩击痛", "体格检查>>脊柱>>其他" }
				, new string[] { "\n脊柱：", "畸形：", "活动度：", "叩击痛：", "其他：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "体格检查>>四肢>>畸形", "体格检查>>四肢>>活动度", "体格检查>>四肢>>膝反射" }
				, new string[] { "\n四肢：", "畸形：", "活动度：", "膝反射：" });
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "", "神经系统>>膝反射", "神经反射>>病理神经反射" }
				, new string[] { "\n神经反射：", "膝反射: ", "病理神经反射：" });
            #endregion

            #region 妇科检查
            Boolean blnGynecology = false;
            if (m_blnHavePrintInfo(new string[] { "妇科检查>>外阴", "妇科检查>>阴道", "妇科检查>>穹隆", "妇科检查>>孑宫颈", "妇科检查>>孑宫体", "妇科检查>>附件", "妇科检查>>孑宫旁组织" }) == true)
            {
                blnGynecology = true;
            }
            if (blnGynecology == true)
            {
                m_objPrintMultiItemArr[7].m_mthSetSpecialTitleValue("妇科检查", "");
            }
            m_objPrintMultiItemArr[7].m_mthSetPrintValue(new string[] { "妇科检查>>外阴", "妇科检查>>阴道", "妇科检查>>穹隆", "妇科检查>>孑宫颈", "妇科检查>>孑宫体", "妇科检查>>附件", "妇科检查>>孑宫旁组织" }
				, new string[] { "外阴：", "\n阴道：", "\n穹隆：", "\n子宫颈：", "\n子宫体：", "\n附件：", "\n子宫旁组织：" });
            #endregion

            #region 实验室检查
            //Boolean blnLab = false;
            //if (m_blnHavePrintInfo(new string[] { "诊疗计划>>实验室检查>>血色素","诊疗计划>>实验室检查>>红血球","诊疗计划>>实验室检查>>白血球","诊疗计划>>实验室检查>>血型","诊疗计划>>实验室检查>>小便检查","诊疗计划>>实验室检查>>阴液","诊疗计划>>实验室检查>>细胞涂片","诊疗计划>>实验室检查>>肝胃功能","诊疗计划>>实验室检查>>胸部Ⅹ线检查","诊疗计划>>实验室检查>>病理诊断"}) == true)
            //{
            //    blnLab = true;
            //}
            //if (blnLab == true)
            //{
            //    m_objPrintMultiItemArr[8].m_mthSetSpecialTitleValue("实验室检查", "");
            //}
            //m_objPrintMultiItemArr[8].m_mthSetPrintValue(new string[] { "诊疗计划>>实验室检查>>血色素","诊疗计划>>实验室检查>>红血球","诊疗计划>>实验室检查>>白血球","诊疗计划>>实验室检查>>血型","诊疗计划>>实验室检查>>小便检查"
            //                                                            ,"诊疗计划>>实验室检查>>阴液","诊疗计划>>实验室检查>>细胞涂片","诊疗计划>>实验室检查>>肝胃功能","诊疗计划>>实验室检查>>胸部Ⅹ线检查","诊疗计划>>实验室检查>>病理诊断"}
            //    , new string[] { "血色素：", "红血球：", "白血球：", "血型：", "\n小便检查：", "\n阴液：", "细胞涂片：", "\n肝胃功能：", "\n胸部Ⅹ线检查：", "病理诊断：" });
            #endregion

            #region 签名和日期
            m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "主任医师", "主治医师", "住院医师", "实习医师" }, new string[] { "主任医师：", "主治医师：", "住院医师：", "实习医师：" }, true);
            //m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "诊疗计划>>主治医生", "诊疗计划>>住院医生" }, new string[] { "主治医生：", "住院医生：" }, true);
            //m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "诊疗计划>>日期" }, new string[] { "" }, false);
            #region 修正/补充诊断以及签名
            m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" }, true);
            m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" }, true);
            #endregion
            m_objPrintSignArr[3].m_mthSetPrintSignValue(new string[] { "最后诊断医师签名", "最后诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" }, true);
            #endregion

            #region 诊疗计划
            //m_objPrintCurePlanArr[0].m_BlnPrintInNextPage = true;
            //m_objPrintCurePlanArr[0].m_IntCurrentHeight = 100;
            //m_objPrintCurePlanArr[0].m_mthSetPrintValue("诊疗计划>>诊断根据", "诊断根据");
            //m_objPrintCurePlanArr[1].m_IntCurrentHeight = 100;
            //m_objPrintCurePlanArr[1].m_mthSetPrintValue(new string[]{"诊疗计划>>实验室检查>>血色素","诊疗计划>>实验室检查>>红血球","诊疗计划>>实验室检查>>白血球","诊疗计划>>实验室检查>>血型","诊疗计划>>实验室检查>>小便检查"
            //   ,"诊疗计划>>实验室检查>>阴液","诊疗计划>>实验室检查>>细胞涂片","诊疗计划>>实验室检查>>肝胃功能","诊疗计划>>实验室检查>>胸部Ⅹ线检查","诊疗计划>>实验室检查>>病理诊断"}
            //, new string[] { "血色素：", "红血球：", "白血球：", "血型：", "\n小便检查：", "\n阴液：", "细胞涂片：", "\n肝胃功能：", "\n胸部Ⅹ线检查：", "病理诊断：" }, "实验室检查");
            //  m_objPrintCurePlanArr[1].m_BlnPrintInNextPage = true;
            //m_objPrintCurePlanArr[1].m_IntCurrentHeight = 60;
            //m_objPrintCurePlanArr[1].m_mthSetPrintValue("诊疗计划>>入院诊断", "入院诊断");
            //m_objPrintCurePlanArr[2].m_IntCurrentHeight = 100;
            //m_objPrintCurePlanArr[2].m_mthSetPrintValue("诊疗计划>>入院后拟行检查项目", "入院后拟行检查项目");
            //m_objPrintCurePlanArr[3].m_IntCurrentHeight = 100;
            //m_objPrintCurePlanArr[3].m_mthSetPrintValue("诊疗计划>>诊疗计划", "诊疗计划");
            //m_objPrintCurePlanArr[4].m_IntCurrentHeight = 100;
            //m_objPrintCurePlanArr[4].m_mthSetPrintValue("诊疗计划>>鉴别诊断", "鉴别诊断");
            #endregion
        }

        #region print class

        /// <summary>
        /// 项目打印
        /// </summary>
        private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 居中打印的粗体标题
            /// </summary>
            private string m_strSpecialTitle = "";
            /// <summary>
            /// 居左打印的小标题
            /// </summary>
            private string m_strLeftTitle = "";
            /// <summary>
            /// 单项打印的小标题
            /// </summary>
            private string m_strTitle = "";
            private string m_strText = "";
            private string m_strTextXml = "";
            private bool m_blnNoContent = false;
            private bool m_blnNoPrint = true;
            private clsInpatMedRec_Item m_objItemContent = null;
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            public clsPrintInPatMedRecItem()
            { }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnNoContent == true && m_blnNoPrint == true)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    if (m_strTitle != "")
                    {
                        if (p_intPosY >= 1025)
                        {
                            p_intPosY = 2000;
                            return;
                        }
                        if(m_strTitle == "入院诊断：")
                            p_intPosY += 20;
                        p_objGrp.DrawString(m_strTitle, m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_intPosY += 20;
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null);
                        m_mthAddSign2(m_strTitle, m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        if (m_strSpecialTitle != "")
                        {
                            p_intPosY += 20;
                            if (p_intPosY >= 1025)
                            {
                                p_intPosY = 2000;
                                return;
                            }
                            p_objGrp.DrawString(m_strSpecialTitle, clsIMR_HerbalismPrintTool.m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                            p_intPosY += 20;
                            if (p_intPosY >= 1025)
                            {
                                p_intPosY = 2000;
                                m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                                m_mthAddSign2((m_strSpecialTitle == "" ? m_strLeftTitle : m_strSpecialTitle), m_objPrintContext.m_ObjModifyUserArr);
                                m_blnIsFirstPrint = false;
                                return;
                            }

                        }
                        if (m_strLeftTitle != "")
                        {
                            p_intPosY += 20;
                            if (p_intPosY >= 1025)
                            {
                                p_intPosY = 2000;
                                return;
                            }
                            ///////////////////////////////////////////////
                            p_objGrp.DrawString(m_strLeftTitle, m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_intPosY += 20;
                            if (p_intPosY >= 1025)
                            {
                                p_intPosY = 2000;
                                m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                                m_mthAddSign2((m_strSpecialTitle == "" ? m_strLeftTitle : m_strSpecialTitle), m_objPrintContext.m_ObjModifyUserArr);
                                m_blnIsFirstPrint = false;
                                return;
                            }
                        }
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                        //m_mthAddSign2((m_strSpecialTitle == "" ? m_strLeftTitle : m_strSpecialTitle), m_objPrintContext.m_ObjModifyUserArr);
                    }

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_strTitle != "" || m_strLeftTitle != "")
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
                    else
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    if (p_intPosY >= 1025)
                    {
                        p_intPosY = 2000;
                        return;
                    }
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
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
            public void m_mthSetPrintValue(string[] p_strKeyArr, string[] p_strTitleArr)
            {
                if (p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
                {
                    m_blnNoContent = true;
                    return;
                }
                m_blnNoPrint = false;
                if (m_blnHavePrintInfo(p_strKeyArr) == true)
                    m_mthMakeText(p_strTitleArr, p_strKeyArr, ref m_strText, ref m_strTextXml);
            }
            /// <summary>
            /// 设置单项打印内容
            /// </summary>
            /// <param name="p_strKey">哈希键</param>
            /// <param name="p_strTitle">小标题</param>
            public void m_mthSetPrintValue(string p_strKey, string p_strTitle)
            {
                if (m_hasItems != null && p_strKey != null)
                    if (m_hasItems.Contains(p_strKey))
                        m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                m_strTitle = p_strTitle;
            }
            /// <summary>
            /// 设置标题“体格检查”、“月经史”等
            /// </summary>
            /// <param name="p_strBigTitle">居中打印的标题，没有的置空""，而不是null</param>
            /// <param name="p_strSTitle">居左打印的小标题，没有的置空""，而不是null</param>
            public void m_mthSetSpecialTitleValue(string p_strBigTitle, string p_strSTitle)
            {
                m_strSpecialTitle = p_strBigTitle;
                m_strLeftTitle = p_strSTitle;
            }

        }

        /// <summary>
        /// 签名和日期
        /// </summary>
        private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
        {
            private clsInpatMedRec_Item[] objSignContent = null;
            private string[] m_strTitleArr = null;
            private bool m_blnPrintInOneLine = false;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (objSignContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (objSignContent != null)
                {
                    p_intPosY += 30;
                    if (m_blnPrintInOneLine)
                        m_mthPrintInOneLine(ref p_intPosY, p_objGrp, p_fntNormalText);
                    else
                        m_mthPrintInMultiLine(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHaveMoreLine = false;
                }

            }
            //			public void clsPrintInPatMedRecSign()
            //			{}
            private void m_mthPrintInOneLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                int intLeft = m_intRecBaseX + 20;
                int intStep = 250;
                if (objSignContent.Length >= 3)
                {
                    intLeft += 200;
                }
                if (objSignContent.Length <= 2)
                {
                    intLeft += 200;
                }
                int intTemp = 0;
                for (int i = 0; i < objSignContent.Length; i++)
                {
                    if (objSignContent[i] == null) continue;
                    
                    if (intTemp == 2)//3个，4个签名分两行打印
                    {
                        p_intPosY += 20;
                    }
                    if (intTemp >= 2)
                        intTemp -= 2;//第二行左起开始打印
                    if (m_strTitleArr[i].IndexOf("日期") < 0)
                    {
                        p_objGrp.DrawString(m_strTitleArr[i] + (objSignContent[i] == null ? "" : objSignContent[i].m_strItemContent), p_fntNormalText, Brushes.Black, intLeft + intTemp * intStep, p_intPosY);
                    }
                    else if (i > 0 && objSignContent[i - 1] != null)
                    {
                        p_objGrp.DrawString(m_strTitleArr[i] + (objSignContent[i] == null ? "" : DateTime.Parse(objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, intLeft + intTemp * intStep, p_intPosY);
                    }
                    intTemp++;
                }
                p_intPosY += 20;
            }

            private void m_mthPrintInMultiLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
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
            public void m_mthSetPrintSignValue(string[] p_strkeyArr, string[] p_strTitleArr, bool p_blnPrintInOneLine)
            {
                if (p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
                    return;
                objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
                m_strTitleArr = p_strTitleArr;
                m_blnPrintInOneLine = p_blnPrintInOneLine;
            }



        }

        /// <summary>
        /// 诊疗计划
        /// </summary>
        private class clsPrintInPatMedRecCurePlan : clsIMR_PrintLineBase
        {
            #region Define

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private string m_strTitle = "";
            private clsInpatMedRec_Item m_objItemContent = null;
            private bool m_blnIsFirstPrint = true;
            private bool m_blnHasPrintTitle = false;
            /// <summary>
            /// 格子高度
            /// </summary>
            private const int c_intHeight = 60;
            /// <summary>
            /// 中间竖线X轴
            /// </summary>
            private const int c_intShortLeft = (int)enmRectangleInfo.LeftX + 110;
            /// <summary>
            /// 打印内容格子宽度
            /// </summary>
            private const int c_intWidth = (int)enmRectangleInfo.RightX - c_intShortLeft;
            /// <summary>
            /// 打印小标题宽度
            /// </summary>
            private const int c_intTitleWidth = 120;
            private int m_intLongLineTop = 150;
            /// <summary>
            /// 打印横线的X坐标
            /// </summary>
            private int m_intLeftX = (int)enmRectangleInfo.LeftX - 10;

            private int m_intCurrentHeight = 100;
            public int m_IntCurrentHeight
            {
                set { m_intCurrentHeight = value; }
            }
            int m_intPosY;

            private string m_strText = "";
            private string m_strTextXml = "";

            private bool m_blnPrintInNextPage = false;
            /// <summary>
            /// 是否换页打印
            /// </summary>
            public bool m_BlnPrintInNextPage
            {
                set { m_blnPrintInNextPage = value; }
            }

            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY == m_intLongLineTop + 5 && m_blnHasPrintTitle == false)
                {
                    m_mthPrintTitle(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHasPrintTitle = true;
                }
                Rectangle rtgTitle = new Rectangle(m_intLeftX, p_intPosY + 5, c_intTitleWidth, c_intHeight);
                Rectangle rtgTitle2 = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth, 10);

                StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
                Font fntTitle = new Font("SimSun", 12);

                int intRealHeight = 0;
                m_intPosY = p_intPosY;
                if (m_blnPrintInNextPage == true)
                {
                    p_intPosY += 1169;
                    m_blnHaveMoreLine = true;
                    m_blnPrintInNextPage = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (p_intPosY + 40 > ((int)enmRectangleInfo.BottomY - 50))
                    {
                        m_blnHaveMoreLine = true;
                        p_intPosY += 500;
                        return;
                    }
                    if (m_strTitle != "")
                        p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle, stfTitle);
                    //p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY+20);
                    if (m_objItemContent != null)
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : (m_objItemContent.m_strItemContent == null ? "" : m_objItemContent.m_strItemContent))
                            , (m_objItemContent == null ? "<root />" : (m_objItemContent.m_strItemContentXml == null ? "<root />" : m_objItemContent.m_strItemContentXml)), m_dtmFirstPrintTime, m_objItemContent == null);
                    else
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_strText == "");
                    m_mthAddSign2(m_strTitle, m_objPrintContext.m_ObjModifyUserArr);

                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgTitle2, p_objGrp, out intRealHeight, false);
                    int intYTemp = p_intPosY;
                    if (intRealHeight > m_intCurrentHeight)
                        p_intPosY += intRealHeight + 5;
                    else
                        p_intPosY += intRealHeight + 5; // 修改
                    //   p_intPosY += m_intCurrentHeight + 5;
                    //p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, m_intLeftX, intYTemp, m_intLeftX, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, c_intShortLeft, intYTemp, c_intShortLeft, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.RightX, intYTemp, (int)enmRectangleInfo.RightX, p_intPosY);
                    if (m_strTitle == "鉴别诊断")
                    {
                        //p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY + 50, (int)enmRectangleInfo.RightX, p_intPosY + 50);
                        //p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, m_intLeftX, p_intPosY + 50);
                        //p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.RightX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY + 50);
                    }
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }
            }
            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
            }

            /// <summary>
            /// 打印顶部直线和标题
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            private void m_mthPrintTitle(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                Brush slbBtush = new SolidBrush(Color.Black);
                p_objGrp.Clear(Color.White);
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim() + "妇科诊疗计划", new Font("", 16, FontStyle.Bold), slbBtush, 200, 40);

                p_objGrp.DrawString("住院号：", p_fntNormalText, slbBtush, 660, 80);
                p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID, p_fntNormalText, slbBtush, 720, 80);

                p_objGrp.DrawLine(Pens.Black, m_intLeftX, 110, (int)enmRectangleInfo.RightX, 110);

                p_objGrp.DrawString("姓名：", p_fntNormalText, slbBtush, 50, 115);
                p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, p_fntNormalText, slbBtush, 100, 115);

                p_objGrp.DrawString("年龄：", p_fntNormalText, slbBtush, 300, 115);
                p_objGrp.DrawString(m_objPrintInfo.m_strAge, p_fntNormalText, slbBtush, 350, 115);

                p_objGrp.DrawString("入院日期：", p_fntNormalText, slbBtush, 500, 115);
                p_objGrp.DrawString(m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日"), p_fntNormalText, slbBtush, 600, 115);

                p_objGrp.DrawLine(Pens.Black, m_intLeftX, 140, (int)enmRectangleInfo.RightX, 140);
                p_objGrp.DrawLine(Pens.Black, m_intLeftX, 110, m_intLeftX, 155);
                p_objGrp.DrawLine(Pens.Black, c_intShortLeft, 140, c_intShortLeft, 155);
                p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.RightX, 110, (int)enmRectangleInfo.RightX, 155);
            }

            /// <summary>
            /// 设置多项打印内容
            /// </summary>
            /// <param name="p_strKeyArr">打印内容的哈希键数组</param>
            /// <param name="p_strTitleArr">小标题数组(即对应于窗体Lable但不存储于数据库的需打印的内容)</param>
            public void m_mthSetPrintValue(string[] p_strKeyArr, string[] p_strTitleArr, string p_strTitle)
            {
                m_strTitle = p_strTitle;
                if (p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
                    return;
                if (m_blnHavePrintInfo(p_strKeyArr) == true)
                    m_mthMakeText(p_strTitleArr, p_strKeyArr, ref m_strText, ref m_strTextXml);
            }
            /// <summary>
            /// 设置单项打印内容
            /// </summary>
            /// <param name="p_strKey">哈希键</param>
            /// <param name="p_strTitle">小标题</param>
            public void m_mthSetPrintValue(string p_strKey, string p_strTitle)
            {
                if (m_hasItems != null && p_strKey != null)
                    if (m_hasItems.Contains(p_strKey))
                        m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                m_strTitle = p_strTitle;
            }
        }
        #endregion
    }
}
