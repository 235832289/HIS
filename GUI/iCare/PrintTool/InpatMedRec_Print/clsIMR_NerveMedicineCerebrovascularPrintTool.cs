using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using iCareData;

namespace iCare
{
    //神经肿瘤病历打印类
    public class clsIMR_NerveMedicineCerebrovascularPrintTool : clsInpatMedRecPrintBase,IDisposable
    {
        #region 字段
        /// <summary>
        /// 一般的不包含图片、表格的可自动换行的语句或段落打印对象
        /// </summary>
        private iCare.clsPrintInPatMedRecItem[] m_objPrintContents = null;
        private iCare.clsPrinTable[] m_objPrintTables = null;
        #endregion

        public clsIMR_NerveMedicineCerebrovascularPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {

        }
        protected override void m_mthPrintHeader(PrintPageEventArgs e)
        {
            base.m_mthPrintHeader(e);
        }
        protected override void m_mthPrintTitleInfo(PrintPageEventArgs e)
        {
            base.m_mthPrintTitleInfo(e);
        }
        protected override System.Collections.Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            return base.m_mthSetHashItem(p_objItemArr);
        }
        /// <summary>
        /// 初始化打印内容对象
        /// </summary>
        protected override void m_mthSetPrintLineArr()
        {
            //一般打印的对象
            this.m_objPrintContents = new iCare.clsPrintInPatMedRecItem[]
            {
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem(),
                new iCare.clsPrintInPatMedRecItem()
            };
            //表格打印对象
            this.m_objPrintTables = new iCare.clsPrinTable[]
            {
                new iCare.clsPrinTable(50),
                new iCare.clsPrinTable(50),
                new iCare.clsPrinTable(50),
                new iCare.clsPrinTable(50),
                new iCare.clsPrinTable(50)
            };
            //把对象放入打印队列开始执行打印
            base.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { 
                    new clsPrintPatientFixInfo("神经内科脑血管病病历",290),//该类为已定义好的用来打印标准专科病历头病人信息的类，在该类能够满足信息需要的情况下不需要重定义直接使用即可。
                    this.m_objPrintContents[0],
                    this.m_objPrintContents[1],
                    this.m_objPrintContents[2],
                    this.m_objPrintContents[3],
                    this.m_objPrintContents[4],
                    this.m_objPrintContents[5],
                    this.m_objPrintContents[6],
                    this.m_objPrintContents[7],
                    this.m_objPrintTables[0],
                    this.m_objPrintContents[8],
                    this.m_objPrintTables[1],
                    this.m_objPrintContents[9],
                    this.m_objPrintContents[10],
                    this.m_objPrintTables[2],
                    this.m_objPrintTables[3],
                    this.m_objPrintTables[4],
                    this.m_objPrintContents[11],
                    this.m_objPrintContents[12],
                    this.m_objPrintContents[13],
                    this.m_objPrintContents[14],
                    this.m_objPrintContents[15],
                    this.m_objPrintContents[16],
                    this.m_objPrintContents[17],
                    this.m_objPrintContents[18]
                }
                );

            base.m_mthSetPrintLineArr();
        }
        /// <summary>
        /// 填充打印对象内容
        /// </summary>
        protected override void m_mthSetSubPrintInfo()
        {
            #region 病史记录 ok
            this.m_objPrintContents[0].m_mthSetSpecialTitleValue("病 史 记 录");
            this.m_objPrintContents[0].m_mthSetPrintValueForTextControl("主诉", "主诉：");
            this.m_objPrintContents[1].m_mthSetPrintValueForTextControl("现病史", "现病史：");
            this.m_objPrintContents[2].m_mthSetPrintValueForTextControl("既往史", "既往史：");
            this.m_objPrintContents[3].m_mthSetPrintValueForTextControl("个人史", "个人史：");
            this.m_objPrintContents[4].m_mthSetPrintValueForTextControl("月经生育史", "月经生育史：");
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl("家族史", "家族史：");
            #endregion

            #region 体格检查 ok

            //第一部分ok
            #region
            this.m_objPrintContents[6].m_mthSetSpecialTitleValue("体 格 检 查");
            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl(
                new string[] {  "", //1
                                "体温", //2
                                "", //3
                                "脉搏", //4
                                "",//5
                                "呼吸", //6
                                "",//7
                                "血压>>收缩压",//8
                                "", //9
                                "血压>>舒张压",//10
                                ""},//11

                new string[] {  "T：", //1
                                "", //2
                                "℃  P：$$",//3
                                "",//4
                                "次/min  HR：$$", //5
                                "", //6
                                "次/min  BP：$$", //7
                                "", //8
                                "/$$",//9
                                "", //10
                                "mmHg$$"}//11
                                                                        );

            this.m_objPrintContents[6].m_mthPrintValueForCheckControl("\n体型：", null, new string[] { "体型>>肥胖型", "体型>>瘦弱型", "体型>>健康型", "体型>>其他" });
            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl(new string[] { "体型>>其他" }, new string[] { "$$" });

            this.m_objPrintContents[6].m_mthPrintValueForCheckControl("    合作情况：", null, new string[] { "合作情况>>合作", "合作情况>>欠合作", "合作情况>>不合作" });
            this.m_objPrintContents[6].m_mthPrintValueForCheckControl("\n血管：两侧颞动脉搏动：", null, new string[] { "两侧颞动脉搏动>>等", "两侧颞动脉搏动>>不等" });
            this.m_objPrintContents[6].m_mthPrintValueForCheckControl("    颈部杂音：", null, new string[] { "颈部杂音>>无", "颈部杂音>>有" });

            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl(new string[] {  "四肢血管",  //1    
                                                                                        "",//2
                                                                                        "心率",//3
                                                                                        "心脏杂音",//4
                                                                                        "心律",//5
                                                                                        "心脏>>其他",//6
                                                                                        "","呼吸音",//7
                                                                                        "干湿罗音",//8
                                                                                        "肺脏>>其他",//9
                                                                                        "腹部",//10
                                                                                        "",//11
                                                                                        "脊柱及四肢",//12
                                                                                        "体格检查>>其他"},//13

                                                                        new string[] {  "\n四肢血管：$$",//1  
                                                                                        "\n胸部：心脏：$$",//2
                                                                                        "心率：$$",//3
                                                                                        "\n            杂音：$$",//4
                                                                                        "\n            心律：$$",//5
                                                                                        "\n            其他：$$",//6
                                                                                        "\n      肺脏：$$",//7
                                                                                        "呼吸音：$$",//8
                                                                                        "\n            干湿罗音：$$",//9
                                                                                        "\n            其他：$$",//10
                                                                                        "\n腹    部：$$",//11
                                                                                        "\n脊柱及四肢(强迫头位，畸形，压痛)：$$",//12
                                                                                        "\n      ","\n其    他：$$"});//13


            #endregion

            #endregion

            #region 神经系统查体 ok

            //第一部分ok
            #region
            this.m_objPrintContents[7].m_mthSetSpecialTitleValue("神 经 系 统 查 体");
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "意识状态：" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null,null,new string[] {  "神经系统查体>>意识状态>>清楚", 
                                                                                                "神经系统查体>>意识状态>>谵妄", 
                                                                                                "神经系统查体>>意识状态>>嗜睡",
                                                                                                "神经系统查体>>意识状态>>昏迷" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "神经系统查体>>意识状态>>昏迷>>浅", 
                                                                                                    "神经系统查体>>意识状态>>昏迷>>中", 
                                                                                                    "神经系统查体>>意识状态>>昏迷>>深" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n言语情况：" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null,null,new string[] {  "神经系统查体>>语言情况>>正常", 
                                                                                                "神经系统查体>>语言情况>>构音障碍", 
                                                                                                "神经系统查体>>语言情况>>失语"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ") ", new string[] {  "神经系统查体>>语言情况>>失语>>完全", 
                                                                                                    "神经系统查体>>语言情况>>失语>>不完全"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(" ,")    ",new string[] {   "神经系统查体>>语言情况>>失语>>运动性", 
                                                                                                    "神经系统查体>>语言情况>>失语>>感觉性",
                                                                                                    "神经系统查体>>语言情况>>失语>>混合性"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                            new string[] { "\n智能：" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("计算力：", null, new string[] {  "神经系统查体>>计算力>>正常", 
                                                                                                        "神经系统查体>>计算力>>减退", 
                                                                                                        "神经系统查体>>计算力>>差" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("  记忆力：", null,new string[] { "神经系统查体>>记忆力>>正常", 
                                                                                                        "神经系统查体>>记忆力>>减退", 
                                                                                                        "神经系统查体>>记忆力>>差" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "神经系统查体>>记忆力>>差>>瞬间", 
                                                                                                    "神经系统查体>>记忆力>>差>>近时",
                                                                                                    "神经系统查体>>记忆力>>差>>远时"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("      定向力：", null, new string[] {    "神经系统查体>>定向力>>正常", 
                                                                                                                "神经系统查体>>定向力>>减退", 
                                                                                                                "神经系统查体>>定向力>>差" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(",")    ",new string[] {"神经系统查体>>定向力>>差>>时间", 
                                                                                                "神经系统查体>>定向力>>差>>人物",
                                                                                                "神经系统查体>>定向力>>差>>地点"});

            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("理解判断力：", null,new string[] {   "神经系统查体>>理解判断力>>正常", 
                                                                                                            "神经系统查体>>理解判断力>>减退", 
                                                                                                            "神经系统查体>>理解判断力>>差" });

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "神经系统查体>>其他",
                                                                                        "","" },
                                                                        new string[] {  "\n      其他：", 
                                                                                        "\n颅 神 经：$$","\n         嗅    觉：" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗅觉>>灵敏" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "颅神经>>嗅觉>>灵敏>>左", "颅神经>>嗅觉>>灵敏>>右" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗅觉>>下降" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ", new string[] {"颅神经>>嗅觉>>下降>>左", "颅神经>>嗅觉>>下降>>右" });

            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗅觉>>丧失" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ",new string[] {"颅神经>>嗅觉>>丧失>>左","颅神经>>嗅觉>>丧失>>右" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "", "颅神经>>视力>>左", "颅神经>>视力>>右" },
                                                                        new string[] { "\n         视 神 经：$$", "视力：       左：$$", "     右：$$" });

            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("\n                  视野：", null,new string[] {  "颅神经>>视野>>正常", 
                                                                                                                         "颅神经>>视野>>缺损"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n         眼底：" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("左：", null,new string[]   { "颅神经>>眼底>>左>>未窥入", 
                                                                                                    "颅神经>>眼底>>左>>视乳头边界"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "颅神经>>眼底>>左>>视乳头边界>>清楚", 
                                                                                                    "颅神经>>眼底>>左>>视乳头边界>>不清楚"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("  A:V= 颜色：", null, new string[] {  "颅神经>>眼底>>左>>橘红色", 
                                                                                                           "颅神经>>眼底>>左>>苍白",
                                                                                                           "颅神经>>眼底>>左>>其他颜色"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "颅神经>>眼底>>左>>其他颜色描述" },
                                                                        new string[] { "  " });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("\n               右：", null, new string[] {  "颅神经>>眼底>>右>>未窥入", 
                                                                                                                     "颅神经>>眼底>>右>>视乳头边界"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "颅神经>>眼底>>右>>视乳头边界>>清楚", 
                                                                                                    "颅神经>>眼底>>右>>视乳头边界>>不清楚"});
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("  A:V= 颜色：", null, new string[] {  "颅神经>>眼底>>右>>橘红色", 
                                                                                                           "颅神经>>眼底>>右>>苍白",
                                                                                                           "颅神经>>眼底>>右>>其他颜色"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "颅神经>>眼底>>右>>其他颜色描述",    "" },
                                                                        new string[] { "  ",                                "\n         眼球位置：$$" });

            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] {"颅神经>>眼球位置>>正常", 
                                                                                                "颅神经>>眼球位置>>异常"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "颅神经>>眼球位置异常情况",//1
                                                                                        "",//2
                                                                                        "颅神经>>左瞳孔",//3
                                                                                        "",//4
                                                                                        "颅神经>>右瞳孔",//5
                                                                                        "",//6
                                                                                        "颅神经>>视神经>>眼裂",//7
                                                                                        ""},//8
                                                                        new string[] {  "", //1
                                                                                        "    瞳孔：左：$$",//2
                                                                                        "#mm",//3
                                                                                        "    右：$$" ,//4
                                                                                        "#mm",//5
                                                                                        "\n         眼裂：$$",//6
                                                                                        "",//7
                                                                                        "  复视：$$"});//8

            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] {    "颅神经>>复视>>无", 
                                                                                                    "颅神经>>复视>>有"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "颅神经>>复视情况" },
                                                                        new string[] { "" });
            #endregion

            //第二部分 打印(表格)ok
            #region
            clsRectangleStorage m_recObj = new clsRectangleStorage();
            m_recObj.Add("光反应", 70, 0, 100, 90);
            m_recObj.Add("直接对光反应", 70, 0, 200, 30);
            m_recObj.Add("间接对光反应", 70, 0, 200, 30);
            m_recObj.Add("调节反应", 70, 0, 200, 30);
            m_recObj.Add("\n", 70, 0, 50, 30);

            m_recObj.Add("", 70, 0, 100, 0);
            m_recObj.Add("左", 70, 0, 100, 30);
            m_recObj.Add("右", 70, 0, 100, 30);
            m_recObj.Add("左", 70, 0, 100, 30);
            m_recObj.Add("右", 70, 0, 100, 30);
            m_recObj.Add("左", 70, 0, 100, 30);
            m_recObj.Add("右", 70, 0, 100, 30);
            m_recObj.Add("\n", 70, 0, 50, 30);

            m_recObj.Add("", 70, 0, 100, 0);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>直接对光反应>>左"), 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>直接对光反应>>右"), 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>间接对光反应>>左"), 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>间接对光反应>>右"), 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>调节反应>>左"), 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("光反应>>调节反应>>右"), 70, 0, 100, 30);

            this.m_objPrintTables[0].MaxLineHeight = 90;
            this.m_objPrintTables[0].m_mthSetPrintValue(m_recObj);
            #endregion

            //第三部分ok
            #region

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "三叉神经：", "角膜反射：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("左：", null, new string[] {  "三叉神经>>角膜反射>>左>>灵敏",
                                                                                                    "三叉神经>>角膜反射>>左>>迟钝","三叉神经>>角膜反射>>左>>丧失" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("   右：", null, new string[] {   "三叉神经>>角膜反射>>右>>灵敏", 
                                                                                                        "三叉神经>>角膜反射>>右>>迟钝","三叉神经>>角膜反射>>右>>丧失"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n          面部感觉：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("针刺觉：", null, new string[] {  "三叉神经>>面部感觉>>针刺觉>>正常", 
                                                                                                        "三叉神经>>面部感觉>>针刺觉>>异常"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "三叉神经>>面部感觉>>针刺觉异常情况", "" },
                                                                        new string[] { "", "\n          嗫肌功能：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("张口：", null, new string[] { "三叉神经>>嗫肌功能>>张口>>正常", "三叉神经>>嗫肌功能>>张口>>偏斜" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "三叉神经>>嗫肌功能>>张口>>偏斜>>向左", 
                                                                                                    "三叉神经>>嗫肌功能>>张口>>偏斜>>向右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "   颞肌：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "三叉神经>>嗫肌功能>>颞肌>>正常", "三叉神经>>嗫肌功能>>颞肌>>萎缩" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "三叉神经>>嗫肌功能>>颞肌>>萎缩>>左", 
                                                                                                    "三叉神经>>嗫肌功能>>颞肌>>萎缩>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "三叉神经>>嗫肌功能>>颞肌>>无力" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "三叉神经>>嗫肌功能>>颞肌>>无力>>左", 
                                                                                                    "三叉神经>>嗫肌功能>>颞肌>>无力>>右"});

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n                    咬肌：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "三叉神经>>嗫肌功能>>咬肌>>正常", "三叉神经>>嗫肌功能>>咬肌>>萎缩" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "三叉神经>>嗫肌功能>>咬肌>>萎缩>>左", 
                                                                                                    "三叉神经>>嗫肌功能>>咬肌>>萎缩>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "三叉神经>>嗫肌功能>>咬肌>>无力" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "三叉神经>>嗫肌功能>>咬肌>>无力>>左", 
                                                                                                    "三叉神经>>嗫肌功能>>咬肌>>无力>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n面 神 经：\n         额纹：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "面神经>>额纹>>对称" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")侧浅    ", new string[] {  "面神经>>额纹>>左侧浅", 
                                                                                                        "面神经>>额纹>>右侧浅"});

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { " 闭目：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "面神经>>闭目>>对称有力", "面神经>>闭目>>力弱" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "面神经>>闭目>>力弱>>左", 
                                                                                                    "面神经>>闭目>>力弱>>右"});

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n         示齿：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "面神经>>示齿>>对称" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")侧浅    ", new string[] {  "面神经>>示齿>>左侧浅", 
                                                                                                        "面神经>>示齿>>右侧浅"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("面肌抽搐：", null, new string[] {    "面神经>>面肌抽搐>>无", 
                                                                                                            "面神经>>面肌抽搐>>有"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "面神经>>面肌抽搐情况", "" },
                                                                        new string[] { "", "\n听 神 经：(有意识障碍时检查听反射)\n         $$" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("听力：", null, new string[] {    "听神经>>听力>>正常", 
                                                                                                        "听神经>>听力>>下降"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "听神经>>听力>>下降>>左", 
                                                                                                    "听神经>>听力>>下降>>右"});

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    眼球震颤：", null, new string[] {"听神经>>眼球震颤>>无", 
                                                                                                            "听神经>>眼球震颤>>有"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "听神经>>眼球震颤>>有>>水平", 
                                                                                                    "听神经>>眼球震颤>>有>>旋转",
                                                                                                    "听神经>>眼球震颤>>有>>垂直"});


            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("\n         Weber Test：", null, new string[] {   "听神经>>WeberTest>>正中", 
                                                                                                                        "听神经>>WeberTest>>偏左",
                                                                                                                        "听神经>>WeberTest>>偏右"});

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] {  "", 
                                                                                        "听神经>>RinneTest>>左", 
                                                                                        "听神经>>RinneTest>>右",
                                                                                        "" },
                                                                        new string[] {  "\n         Rinne Test：", 
                                                                                        "左：",
                                                                                        "\n                     右：$$",
                                                                                        "\n舌咽迷走神经：\n         软腭运动：$$" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "舌咽迷走神经>>软腭运动>>正常", "舌咽迷走神经>>软腭运动>>减弱" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "舌咽迷走神经>>软腭运动>>减弱>>左", 
                                                                                                    "舌咽迷走神经>>软腭运动>>减弱>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "舌咽迷走神经>>软腭运动>>丧失" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "舌咽迷走神经>>软腭运动>>丧失>>左", 
                                                                                                    "舌咽迷走神经>>软腭运动>>丧失>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n         " });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("悬雍垂：", null, new string[] {  "舌咽迷走神经>>悬雍垂>>居中", 
                                                                                                        "舌咽迷走神经>>悬雍垂>>偏左", 
                                                                                                        "舌咽迷走神经>>悬雍垂>>偏右" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "    " });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("咽反射：", null, new string[] { "舌咽迷走神经>>咽反射>>正常", "舌咽迷走神经>>咽反射>>减弱" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "舌咽迷走神经>>咽反射>>减弱>>左", 
                                                                                                    "舌咽迷走神经>>咽反射>>减弱>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "舌咽迷走神经>>咽反射>>丧失" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "舌咽迷走神经>>咽反射>>丧失>>左", 
                                                                                                    "舌咽迷走神经>>咽反射>>丧失>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "","" },
                                                                        new string[] { "\n副 神 经：", "\n         转项运动：" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "副神经>>转项运动>>正常", "副神经>>转项运动>>减弱" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ",new string[] {   "副神经>>转项运动>>减弱>>左", 
                                                                                                    "副神经>>转项运动>>减弱>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "副神经>>转项运动>>丧失" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "副神经>>转项运动>>丧失>>左", 
                                                                                                    "副神经>>转项运动>>丧失>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n         耸肩运动：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {    "副神经>>耸肩运动>>正中", 
                                                                                                    "副神经>>耸肩运动>>偏左", 
                                                                                                    "副神经>>耸肩运动>>偏右" });
            #endregion

            //第四部分ok
            #region
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "","" },
                                                                        new string[] { "\n舌下神经：", "\n         伸舌：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {    "颅神经>>舌下神经>>伸舌>>正中", 
                                                                                                    "颅神经>>舌下神经>>伸舌>>偏左",
                                                                                                    "颅神经>>舌下神经>>伸舌>>偏右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n         舌肌：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>舌下神经>>舌肌>>正常", "颅神经>>舌下神经>>舌肌>>萎缩" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>舌下神经>>舌肌>>萎缩>>左", 
                                                                                                    "颅神经>>舌下神经>>舌肌>>萎缩>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>舌下神经>>舌肌>>纤颤" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>舌下神经>>舌肌>>纤颤>>左", 
                                                                                                    "颅神经>>舌下神经>>舌肌>>纤颤>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n运动系统：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "运动系统>>左利", "运动系统>>右利" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "运动系统>>肌张力", "运动系统>>肌容积", "运动系统>>不自主运动", "运动系统>>步态" },
                                                                        new string[] { "\n     肌张力：$$", "\n     肌容积：$$", "\n     不自主运动：$$", "\n     步态：$$" });
            #endregion

            //第五部分 打印(表格)ok
            #region
            clsRectangleStorage m_recObj1 = new clsRectangleStorage();
            m_recObj1.Add("肌力", 70, 0, 100, 60);
            m_recObj1.Add("左侧", 70, 0, 300, 30);
            m_recObj1.Add("右侧", 70, 0, 300, 30);
            m_recObj1.Add("\n", 70, 0, 50, 30);

            m_recObj1.Add("", 70, 0, 100, 0);
            m_recObj1.Add("上肢", 70, 0, 150, 30);
            m_recObj1.Add("下肢", 70, 0, 150, 30);
            m_recObj1.Add("上肢", 70, 0, 150, 30);
            m_recObj1.Add("下肢", 70, 0, 150, 30);
            m_recObj1.Add("\n", 70, 0, 50, 30);

            m_recObj1.Add("远端", 70, 0, 100, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>左侧>>上肢>>远端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>左侧>>下肢>>远端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>右侧>>上肢>>远端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>右侧>>下肢>>远端"), 70, 0, 150, 30);
            m_recObj1.Add("\n", 70, 0, 50, 30);

            m_recObj1.Add("近端", 70, 0, 100, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>左侧>>上肢>>近端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>左侧>>下肢>>近端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>右侧>>上肢>>近端"), 70, 0, 150, 30);
            m_recObj1.Add(this.m_mthGetControlValue("运动系统>>肌力>>右侧>>下肢>>近端"), 70, 0, 150, 30);

            this.m_objPrintTables[1].MaxLineHeight = 60;
            this.m_objPrintTables[1].m_mthSetPrintValue(m_recObj1);
            #endregion

            //第六部分ok
            #region
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "\n共济运动：", "\n         指鼻试验：" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>正常" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>正常>>左", 
                                                                                                    "共济运动>>指鼻试验>>正常>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>不稳" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>不稳>>左", 
                                                                                                    "共济运动>>指鼻试验>>不稳>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>不合作" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>不合作>>左", 
                                                                                                    "共济运动>>指鼻试验>>不合作>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "$$", "\n         跟膝胫试验：" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>正常" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>正常>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>正常>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>不稳" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>不稳>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>不稳>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>不合作" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>不合作>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>不合作>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "","" },
                                                                        new string[] { "$$","\n         快速轮替试验：" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>快速轮替试验>>正常" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>正常>>左", 
                                                                                                    "共济运动>>快速轮替试验>>正常>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>快速轮替试验>>笨拙" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>笨拙>>左", 
                                                                                                    "共济运动>>快速轮替试验>>笨拙>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共共济运动>>快速轮替试验>>不合作" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>不合作>>左", 
                                                                                                    "共济运动>>快速轮替试验>>不合作>>右"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "","" },
                                                                        new string[] { "$$","\n         Romberg氏症：" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>稳" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>Romberg氏症>>稳>>睁眼", 
                                                                                                    "共济运动>>Romberg氏症>>稳>>闭眼"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>不稳" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>Romberg氏症>>不稳>>睁眼", 
                                                                                                    "共济运动>>Romberg氏症>>不稳>>闭眼"});
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>不合作" });
            #endregion

            //第七部分ok
            #region

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                         new string[] { "\n感觉系统：" });

            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("浅感觉：", null, new string[] { "感觉系统>>浅感觉>>正常", "感觉系统>>浅感觉>>异常" });

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>浅感觉>>异常情况","" },
                                                                         new string[] { "","          $$" });

            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("深感觉：", null, new string[] { "感觉系统>>深感觉>>正常", "感觉系统>>深感觉>>异常" });

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>深感觉>>异常情况" },
                                                                         new string[] { "$$" });

            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("\n          皮层感觉：", null, new string[] { "感觉系统>>皮层感觉>>正常", "感觉系统>>皮层感觉>>异常" });

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>皮层感觉>>异常情况", "", "" },
                                                                         new string[] { "", "\n反射：$$", "\n" });
            #endregion

            //第八部分 打印(表格)ok
            #region
            clsRectangleStorage m_recObj2 = new clsRectangleStorage();
            m_recObj2.Add("浅反射", 70, 0, 100, 60);
            m_recObj2.Add("腹壁反射", 70, 0, 360, 30);
            m_recObj2.Add("提睾反射", 70, 0, 120, 60);
            m_recObj2.Add("足反射", 70, 0, 120, 60);
            m_recObj2.Add("\n", 70, 0, 100, 30);

            m_recObj2.Add("", 70, 0, 100, 0);
            m_recObj2.Add("上", 70, 0, 120, 30);
            m_recObj2.Add("中", 70, 0, 120, 30);
            m_recObj2.Add("下", 70, 0, 120, 30);
            m_recObj2.Add("", 70, 0, 120, 0);
            m_recObj2.Add("", 70, 0, 120, 0);
            m_recObj2.Add("\n", 70, 0, 100, 30);

            m_recObj2.Add("左", 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>上>>左"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>中>>左"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>下>>左"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>提睾反射>>左"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>足跖反射>>左"), 70, 0, 120, 30);
            m_recObj2.Add("\n", 70, 0, 50, 30);

            m_recObj2.Add("右", 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>上>>右"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>中>>右"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>腹壁反射>>下>>右"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>提睾反射>>右"), 70, 0, 120, 30);
            m_recObj2.Add(this.m_mthGetControlValue("反射>>浅反射>>足跖反射>>右"), 70, 0, 120, 30);

            this.m_objPrintTables[2].m_mthSetPrintValue(m_recObj2);
            this.m_objPrintTables[2].MaxLineHeight = 60;
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            clsRectangleStorage m_recObj3 = new clsRectangleStorage();
            m_recObj3.Add("深反射", 70, 0, 70, 30);
            m_recObj3.Add("挠骨膜", 70, 0, 90, 30);
            m_recObj3.Add("三头肌", 70, 0, 90, 30);
            m_recObj3.Add("二头肌", 70, 0, 90, 30);
            m_recObj3.Add("Hoffmann", 70, 0, 90, 30);
            m_recObj3.Add("Rossolimo", 70, 0, 90, 30);
            m_recObj3.Add("膝反射", 70, 0, 90, 30);
            m_recObj3.Add("跟腱反射", 70, 0, 90, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("左", 70, 0, 70, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>挠骨膜>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>三头肌>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>二头肌>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>二头肌>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>Rossolimo>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>膝反射>>左"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>跟腱反射>>左"), 70, 0, 90, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("右", 70, 0, 70, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>挠骨膜>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>三头肌>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>二头肌>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>二头肌>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>Rossolimo>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>膝反射>>右"), 70, 0, 90, 30);
            m_recObj3.Add(this.m_mthGetControlValue("反射>>深反射>>跟腱反射>>右"), 70, 0, 90, 30); 

            this.m_objPrintTables[3].m_mthSetPrintValue(m_recObj3);
            //--------------------------------------------------------------
            //--------------------------------------------------------------
            clsRectangleStorage m_recObj4 = new clsRectangleStorage();
            m_recObj4.Add("病理反射", 70, 0, 100, 30);
            m_recObj4.Add("Babinski", 70, 0, 100, 30);
            m_recObj4.Add("Pussep", 70, 0, 100, 30);
            m_recObj4.Add("Gordon", 70, 0, 100, 30);
            m_recObj4.Add("Oppenheim", 70, 0, 100, 30);
            m_recObj4.Add("掌颌反射", 70, 0, 100, 30);
            m_recObj4.Add("吸吮反射", 70, 0, 100, 30);
            m_recObj4.Add("\n", 70, 0, 50, 30);

            m_recObj4.Add("左", 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Babinski>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Pussep>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Gordon>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Oppenheim>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>掌颌反射>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>吸吮反射>>左"), 70, 0, 100, 30);
            m_recObj4.Add("\n", 70, 0, 50, 30);

            m_recObj4.Add("右", 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Babinski>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Pussep>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Gordon>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Oppenheim>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>掌颌反射>>左"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>吸吮反射>>左"), 70, 0, 100, 30);

            this.m_objPrintTables[4].m_mthSetPrintValue(m_recObj4);
            #endregion

            //第九部分ok
            #region
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] {  "",
                                                                                            "脑膜刺激征>>颈项强直", 
                                                                                            "脑膜刺激征>>KernigSign", 
                                                                                            "脑膜刺激征>>植物系统检查" },
                                                                            new string[] {  "\n脑膜刺激征：",
                                                                                            "颈项强直：", 
                                                                                            "    Kernig Sign：$$", 
                                                                                            "\n            植物系统检查：$$" });
            #endregion

            #endregion

            #region 辅助检查 ok

            //第一部分ok
            #region
            this.m_objPrintContents[12].m_mthSetSpecialTitleValue("辅 助 检 查");
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "", //1
                                                                                        "头颅CT检查时间",//2 
                                                                                        "头颅CT检查号",//3
                                                                                        "头颅CT检查结果",//4
                                                                                        "",//5
                                                                                        "头颅MRIMRA检查时间",//6
                                                                                        "头颅MRIMRA检查号",//7
                                                                                        "头颅MRIMRA检查结果",//8
                                                                                        "",//9
                                                                                        "全脑血管造影检查时间",//10
                                                                                        "全脑血管造影检查号",//11
                                                                                        "全脑血管造影结果" },//12
                                                                         new string[] { "\n头颅CT：", //1
                                                                                        "检查时间：", //2
                                                                                        "    检查号：$$", //3
                                                                                        "\n       结    果：$$",//4
                                                                                        "\n头颅MRI、MRA：$$",//5
                                                                                        "检查时间：",//6
                                                                                        "    检查号：$$",//7
                                                                                        "\n       结    果：$$",//8
                                                                                        "\n全脑血管造影：$$",//9
                                                                                        "检查时间：",//10
                                                                                        "    检查号：$$" ,//11
                                                                                        "\n       结    果：$$"});//12

            this.m_objPrintContents[13].m_mthSetPrintValueForTextControl("初步诊断", "初步诊断：");
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "初步诊断住院医师签名", 
                                                                                        "初步诊断主治医师签名", 
                                                                                        "初步诊断医师签名日期" },
                                                                         new string[] {  "          ",
                                                                                         "住院医师：", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            this.m_objPrintContents[15].m_mthSetPrintValueForTextControl("修正诊断", "修正诊断：");
            this.m_objPrintContents[16].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "修正诊断住院医师签名", 
                                                                                        "修正诊断主治医师签名", 
                                                                                        "修正诊断医师签名日期" },
                                                                         new string[] {  "          ",
                                                                                         "住院医师：", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            this.m_objPrintContents[17].m_mthSetPrintValueForTextControl("补充诊断", "补充诊断：");
            this.m_objPrintContents[18].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "补充诊断住院医师签名", 
                                                                                        "补充诊断主治医师签名", 
                                                                                        "补充诊断医师签名日期" },
                                                                         new string[] {  "          ",
                                                                                         "住院医师：", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            #endregion

            #endregion

            base.m_mthSetSubPrintInfo();
        }
        /// <summary>
        /// 根据控件描述返回空间所携带的值
        /// </summary>
        /// <param name="controlDescription"></param>
        /// <returns></returns>
        protected string m_mthGetControlValue(string controlDescription)
        {
            if (m_hasItems != null &&
                m_hasItems.Contains(controlDescription) &&
                m_hasItems[controlDescription] != null)
            {
                clsInpatMedRec_Item tempItem = (clsInpatMedRec_Item)m_hasItems[controlDescription];
                return tempItem.m_strItemContent;
            }
            else
                return string.Empty;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            GC.Collect();//强制垃圾回收，回收所有代
        }

        #endregion
    }
}