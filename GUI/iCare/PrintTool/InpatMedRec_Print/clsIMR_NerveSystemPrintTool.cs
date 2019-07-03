using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.controls;
using iCareData;
using System.Collections;
using System.IO;

namespace iCare
{
    public class clsIMR_NerveSystemPrintTool : clsInpatMedRecPrintBase,IDisposable
    {
        #region 字段
        /// <summary>
        /// 一般的不包含图片、表格的可自动换行的语句或段落打印对象

        /// </summary>
        private clsPrintInPatMedRecItem[] m_objPrintContents = null;
        private clsPrinTable[] m_objPrintTables = null;
        private clsPrintPic m_objPic = null;
        #endregion

        #region static Object
        public static Font m_fontHeader = new Font("Simsun", 18);
        public static Font m_fontConent = new Font("Simsun", 12);
        public static Font m_fontFooter = new Font("Simsun", 12);
        public static Font m_fontSign = new Font("Simsun", 8);
        #endregion

        /// <summary>
        /// 静态构造函数，构造静态成员

        /// </summary>
        static clsIMR_NerveSystemPrintTool()
        {
            //clsIMR_NerveSystemPrintTool.m_fontHeader = new Font("Simsun", 18);
            //clsIMR_NerveSystemPrintTool.m_fontConent = new Font("Simsun", 12);
            //clsIMR_NerveSystemPrintTool.m_fontFooter = new Font("Simsun", 12);
            //clsIMR_NerveSystemPrintTool.m_fontSign = new Font("Simsun", 8);
        }
        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_NerveSystemPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {

        }

        #region override the base object
        /// <summary>
        /// 打印标题除文字部分的其他部分
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintHeader(PrintPageEventArgs e)
        {
            base.m_mthPrintHeader(e);
        }
        /// <summary>
        /// 打印标题文字部分
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintTitleInfo(PrintPageEventArgs e)
        {
            base.m_mthPrintTitleInfo(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            return base.m_mthSetHashItem(p_objItemArr);
        }
        /// <summary>
        /// 初始化打印内容对象

        /// </summary>
        protected override void m_mthSetPrintLineArr()
        {
            //一般打印的对象
            this.m_objPrintContents = new clsPrintInPatMedRecItem[]
            {
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem()
            };
            //表格打印对象
            this.m_objPrintTables = new clsPrinTable[]
            {
                new clsPrinTable(50),
                new clsPrinTable(50),
                new clsPrinTable(50)
            };
            //图片打印对象
            this.m_objPic = new clsPrintPic(true);
            //把对象放入打印队列开始执行打印

            base.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { 
                    new clsPrintPatientFixInfo("神经肿瘤病历",310),//该类为已定义好的用来打印标准专科病历头病人信息的类，在该类能够满足信息需要的情况下不需要重定义直接使用即可。

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
                    this.m_objPic,
                    this.m_objPrintContents[9],
                    this.m_objPrintTables[2],
                    this.m_objPrintContents[10],
                    this.m_objPrintContents[11],
                    this.m_objPrintContents[12],
                    this.m_objPrintTables[1],
                    this.m_objPrintContents[13],
                    this.m_objPrintContents[14],
                    this.m_objPrintContents[15],
                    this.m_objPrintContents[16],
                    this.m_objPrintContents[17]
                }
                );
            base.m_mthSetPrintLineArr();
        }
        /// <summary>
        /// 根据控件描述返回控件所携带的值

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
        /// <summary>
        /// 填充打印对象内容
        /// </summary>
        protected override void m_mthSetSubPrintInfo()
        {
            #region 病史ok
            this.m_objPrintContents[0].m_mthSetSpecialTitleValue("      病 史      ");
            this.m_objPrintContents[0].m_mthSetPrintValueForTextControl("主诉", "主诉：");
            this.m_objPrintContents[1].m_mthSetPrintValueForTextControl("现病史", "现病史：");
            this.m_objPrintContents[2].m_mthSetPrintValueForTextControl("既往史", "既往史：");
            this.m_objPrintContents[3].m_mthSetPrintValueForTextControl("个人史", "个人史：");
            this.m_objPrintContents[4].m_mthSetPrintValueForTextControl("家族史", "家族史：");
            #endregion

            #region 一般体格检查ok

            //第一部分
            #region
            this.m_objPrintContents[5].m_mthSetSpecialTitleValue("一 般 体 格 检 查");
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(
                new string[] {  "", //1
                                "体格检查>>血压>>kPa值", //2
                                "", //3
                                "体格检查>>血压>>收缩压", //4
                                "",//5
                                "体格检查>>血压>>舒张压P", //6
                                "",//7
                                "",//8
                                "体格检查>>脉搏", //9
                                "",//10
                                "体格检查>>呼吸", //11
                                "",//12
                                "体格检查>>体温", //13
                                "" },//14

                new string[] {  "血压：", //1
                                "", //2
                                "kPa($$",//3
                                "",//4
                                "/$$", //5
                                "", //6
                                "mmHg)  ", //7
                                "脉搏：$$", //8
                                "",//9
                                "次/分 呼吸：$$", //10
                                "",//11
                                "次/分 体温：$$",//12
                                "",//13
                                "℃\n$$"}//14
                                                                        );

            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(
                        new string[]{   "",//1
                                        "体格检查>>一般情况>>发育",//2
                                        "体格检查>>一般情况>>营养",//3
                                        "体格检查>>一般情况>>病容",//4
                                        "",
                                        "体格检查>>皮肤>>血管痣",//5
                                        "体格检查>>皮肤>>咖啡斑",//6
                                        "体格检查>>皮肤>>皮下结节",//7
                                        "体格检查>>皮肤>>色泽",//8
                                        "体格检查>>皮肤>>脱水征",//9
                                        "体格检查>>皮肤>>瘢痕",//10
                                        "体格检查>>皮肤>>毛发",//11
                                        "体格检查>>皮肤>>其他"//12
                                    },

                        new string[] {  "一般情况：", //1
                                        "发育：$$", //2
                                        "    营养：$$", //3
                                        "    病容：$$", //4
                                        "\n皮肤：$$",
                                        "血管痣：$$", //5
                                        "  咖啡斑：$$", //6
                                        "  皮下结节：$$", //7
                                        "\n      色泽：$$", //8
                                        "  脱水征：$$",//9
                                        "  瘢痕：$$" ,//10
                                        "\n      毛发：$$",//11
                                        "  其他：$$"//12
                                }
                                                            );

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n淋巴结：", null, new string[] { "体格检查>>淋巴结>>不大", "体格检查>>淋巴结>>增大部位" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>淋巴结>>增大部位描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n五官：", null, new string[] { "体格检查>>五官>>正常", "体格检查>>五官>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>五官>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n心脏：", null, new string[] { "体格检查>>心脏>>正常", "体格检查>>心脏>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>心脏>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n肺脏：", null, new string[] { "体格检查>>肺脏>>正常", "体格检查>>肺脏>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>肺脏>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n腹部：", null, new string[] { "体格检查>>腹部>>正常", "体格检查>>腹部>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>腹部>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n脊柱：", null, new string[] { "体格检查>>脊柱>>正常", "体格检查>>脊柱>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>脊柱>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n四肢：", null, new string[] { "体格检查>>四肢>>正常", "体格检查>>四肢>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>四肢>>异常描述" }, new string[] { " $$" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n性征发育：", null, new string[] { "体格检查>>性征发育>>正常", "体格检查>>性征发育>>异常" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>性征发育>>异常描述" }, new string[] { " $$" });

            #endregion

            //第二部分ok
            #region 
            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl("体格检查>>其他", "\n其他：");

            #endregion

            #endregion

            #region 神经系统检查


            //第一部分ok
            #region
            this.m_objPrintContents[7].m_mthSetSpecialTitleValue("神 经 系 统 检 查");
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("检查合作情况：", null, new string[] {    "神经系统检查>>检查合作情况>>合作", 
                                                                                                    "神经系统检查>>检查合作情况>>欠合作", 
                                                                                                    "神经系统检查>>检查合作情况>>不合作" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n神志：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>神志>>清醒", 
                                                                                                    "神经系统检查>>神志>>嗜睡", 
                                                                                                    "神经系统检查>>神志>>朦胧", 
                                                                                                    "神经系统检查>>神志>>躁动", 
                                                                                                    "神经系统检查>>神志>>浅昏迷", 
                                                                                                    "神经系统检查>>神志>>中昏迷", 
                                                                                                    "神经系统检查>>神志>>深昏迷" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n精神状态：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>精神状态>>正常" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>精神状态>>情感反应" },
                                                                        new string[] { "  情感反应：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>精神状态>>定时定向" },
                                                                        new string[] { "  定时定向：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>精神状态>>幻觉" },
                                                                        new string[] { "  幻觉：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>精神状态>>其他" },
                                                                        new string[] { "  其他：" });

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "\n语言：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>语言>>正常", 
                                                                                                    "神经系统检查>>语言>>失语>>失语"});
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("(", ") ",new string[] {   "神经系统检查>>语言>>失语>>运动性", 
                                                                                                    "神经系统检查>>语言>>失语>>感觉性", 
                                                                                                    "神经系统检查>>语言>>失语>>命名性", 
                                                                                                    "神经系统检查>>语言>>失语>>混合性" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "神经系统检查>>语言>>小脑语言", 
                                                                                        "", 
                                                                                        "神经系统检查>>精神状态>>其他", 
                                                                                        "神经系统检查>>姿势及步态", "" },
                                                                        new string[] {  "", 
                                                                                        "\n小脑语言：$$", 
                                                                                        "其他：$$", 
                                                                                        "\n姿势及步态：$$", 
                                                                                        "\n头颅：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>头颅>>正常", "体格检查>>性征发育>>异常" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "",
                                                                                        "神经系统检查>>头颅>>头围",
                                                                                        "",
                                                                                        "", 
                                                                                        "神经系统检查>>头颅>>头皮异常" },
                                                                        new string[] {  "增大(头围：$$",
                                                                                        " ", 
                                                                                        "cm) $$",
                                                                                        "  头皮异常：$$",
                                                                                        "" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("\n      强迫头位：", null, new string[] {    "神经系统检查>>头颅>>强迫头位>>左侧卧", 
                                                                                                                    "神经系统检查>>头颅>>强迫头位>>右侧卧", 
                                                                                                                    "神经系统检查>>头颅>>强迫头位>>膝胸卧位" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>头颅>>听诊" },
                                                                        new string[] { "\n      听诊：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑膜刺激征>>颈抵抗" },
                                                                        new string[] { "\n脑膜刺激征：颈抵抗：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑膜刺激征>>Kernig" },
                                                                        new string[] { "Kernig：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n脑神经：" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅠ：\n" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("    嗅觉：", null, new string[] {    "神经系统检查>>脑神经>>I.  嗅觉>>正常", 
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>迟钝", 
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>迟钝>>左", 
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>迟钝>>右", 
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>消失", 
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>消失>>左",
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>消失>>右",
                                                                                                        "神经系统检查>>脑神经>>I.  嗅觉>>无法检查"});

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅡ：\n" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("    视力：", null, new string[] {    "神经系统检查>>脑神经>>Ⅱ. 视力>>正常", 
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>减退", 
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>减退>>左", 
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>减退>>右", 
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>失明", 
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>失明>>左",
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>失明>>右",
                                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>无法检查"});

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "",
                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>眼底>>左",
                                                                                        "",
                                                                                        "神经系统检查>>脑神经>>Ⅱ. 视力>>眼底>>右" },
                                                                        new string[] {  "\n    眼底：左：$$",
                                                                                        "", 
                                                                                        "\n          右：$$",
                                                                                        ""});

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅢ、Ⅳ、Ⅴ、Ⅵ：\n" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("    眼睑下垂(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼睑下垂>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼睑下垂>>右" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("眼球陷入(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼球陷入>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼球陷入>>右" });
            #endregion                                                                                            

            //第二部分 打印(表格)
            #region
            clsRectangleStorage m_recObj = new clsRectangleStorage();
            m_recObj.Add("瞳孔", 70, 0, 100, 30);
            m_recObj.Add("直径（mm）", 70, 0, 120, 30);
            m_recObj.Add("形状", 70, 0, 120, 30);
            m_recObj.Add("直接光反应", 70, 0, 120, 30);
            m_recObj.Add("间接光反应", 70, 0, 120, 30);
            m_recObj.Add("调节反应", 70, 0, 120, 30);
            m_recObj.Add("\n", 70, 0, 120, 30);

            m_recObj.Add("左", 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>左>>直径"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>左>>形状"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>左>>直接光反应"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>左>>间接光反应"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>左>>调节反应"), 70, 0, 120, 30);

            m_recObj.Add("\n", 70, 0, 50, 30);

            m_recObj.Add("右", 70, 0, 100, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>右>>直径"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>右>>形状"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>右>>直接光反应"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>右>>间接光反应"), 70, 0, 120, 30);
            m_recObj.Add(this.m_mthGetControlValue("神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>瞳孔>>右>>调节反应"), 70, 0, 120, 30);
            m_recObj.Add("\n", 70, 0, 50, 30);
            m_recObj.Add("（灵敏++迟钝+丧失0）", 70, 0, 700, 30);

            this.m_objPrintTables[0].m_mthSetPrintValue(m_recObj);
            #endregion
            
            //第三部分
            #region 
            
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n    眼姿：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>正常",
                                                                                                    "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>斜视" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>斜视>>描述" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>眼球分离" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>眼球分离>>描述" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>同向凝视" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>同向凝视>>左", "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼姿>>同向凝视>>右" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    眼震：", null, new string[] {    "神经系统检查>>眼震>>水平", 
                                                                                                            "神经系统检查>>眼震>>垂直", 
                                                                                                            "神经系统检查>>眼震>>旋转" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼球浮动" },
                                                                        new string[] { "    眼球浮动：" });

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅲ、Ⅳ、Ⅴ、Ⅵ>>眼球运动" },
                                                                        new string[] { "\n    眼球运动：" });
            //Ⅴ、面部感觉

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅤ：\n    面部感觉：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>正常", 
                                                                                                    "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>异常" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")  第 ", new string[] { "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>异常>>左", 
                                                                                                    "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>异常>>右" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>异常>>支数","" },
                                                                        new string[] { "", "支$$" });

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n    角膜反射：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>正常", 
                                                                                                    "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>迟钝" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>迟钝>>左", 
                                                                                                    "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>迟钝>>右"});

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] { "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>消失" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>消失>>左", 
                                                                                                   "神经系统检查>>脑神经>>Ⅴ>>角膜反射>>消失>>右" });
            //张口
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n    张口：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null, new string[] {   "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>张口>>正常", 
                                                                                                   "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>张口>>偏斜" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "", "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>张口>>偏斜方向", "" },
                                                                        new string[] { "(", "$$", ")    $$" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("咀嚼肌：", null, new string[] {    "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>咀嚼肌>>萎缩", 
                                                                                                           "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>咀嚼肌>>无力"});

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>咀嚼肌>>无力>>左", 
                                                                                                   "神经系统检查>>脑神经>>Ⅴ>>面部感觉>>咀嚼肌>>无力>>右" });
            //Ⅶ、面瘫:
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅦ：\n    面瘫：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("中枢性：(", ")    ", new string[] {    "神经系统检查>>脑神经>>Ⅶ、面瘫>>中枢性>>轻", 
                                                                                                            "神经系统检查>>脑神经>>Ⅶ、面瘫>>中枢性>>重", 
                                                                                                            "神经系统检查>>脑神经>>Ⅶ、面瘫>>中枢性>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅶ、面瘫>>中枢性>>右" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("面肌抽搐：(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅶ、面瘫>>面肌抽搐>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅶ、面瘫>>面肌抽搐>>右" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("\n          周围性：(", ")    ", new string[] {    "神经系统检查>>脑神经>>Ⅶ、面瘫>>周围性>>不全", 
                                                                                                                        "神经系统检查>>脑神经>>Ⅶ、面瘫>>周围性>>完全", 
                                                                                                                        "神经系统检查>>脑神经>>Ⅶ、面瘫>>周围性>>左", 
                                                                                                                        "神经系统检查>>脑神经>>Ⅶ、面瘫>>周围性>>右" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅶ、面瘫>>面肌抽搐>>味觉" },
                                                                        new string[] { "味觉：$$" });

            //\n Ⅷ、Weber试验_Rinne试验：气导>骨导(
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\nⅧ：\n    Weber试验_Rinne试验：" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("气导>骨导：(", ")    ", new string[] {   "神经系统检查>>脑神经>>Ⅷ、Weber试验_Rinne试验>>气导>骨导>>左", 
                                                                                                                "神经系统检查>>脑神经>>Ⅷ、Weber试验_Rinne试验>>气导>骨导>>右"});

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("骨导>气导：(", ")    ", new string[] {   "神经系统检查>>脑神经>>Ⅷ、Weber试验_Rinne试验>>骨导>气导>>左", 
                                                                                                                "神经系统检查>>脑神经>>Ⅷ、Weber试验_Rinne试验>>右"});
            //庭功能检查

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>脑神经>>Ⅷ、Weber试验_Rinne试验>>前庭功能检查" },
                                                                        new string[] { "\n    庭功能检查：$$" });
            //Ⅸ、Ⅹ
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                                    new string[] { "\nⅨ、Ⅹ：\n        " });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("发音：(", ")    ", new string[] {    "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>发音>>正常", 
                                                                                                            "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>发音>>嘶哑",
                                                                                                            "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>发音>>构音不良"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("吞咽：(", ")    ", new string[] {    "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>吞咽>>正常", 
                                                                                                            "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>吞咽>>发呛",
                                                                                                            "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>吞咽>>不能"});
            //软腭及腭垂偏向(
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n        " });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("软腭及腭垂偏向：(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>软腭及腭垂偏向>>左", 
                                                                                                                    "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>软腭及腭垂偏向>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("咽反射：", null, new string[] {  "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>正常", 
                                                                                                        "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>迟钝"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>迟钝>>左",
                                                                                                    "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>迟钝>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl(null, null,  new string[] { "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>消失"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("(", ")    ",  new string[] { "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>消失>>左",
                                                                                                    "神经系统检查>>脑神经>>Ⅸ、Ⅹ>>咽反射>>消失>>右"});
            //神经系统检查>>脑神经>>Ⅺ>>耸肩
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "",              "神经系统检查>>脑神经>>Ⅺ>>耸肩" },
                                                                        new string[] { "\nⅪ、Ⅻ：\n", "        耸肩：" });

            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("        转肩无力：(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅺ>>转肩无力>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅺ>>转肩无力>>右"});
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("舌在口中位置：(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅻ>>舌在口中位置>>正中", 
                                                                                                                "神经系统检查>>脑神经>>Ⅻ>>舌在口中位置>>左",
                                                                                                                "神经系统检查>>脑神经>>Ⅻ>>舌在口中位置>>右"});
            //伸舌偏向
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n        " });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("伸舌偏向：(", ")    ", new string[] {  "神经系统检查>>脑神经>>Ⅻ>>伸舌偏向>>左", 
                                                                                                            "神经系统检查>>脑神经>>Ⅻ>>伸舌偏向>>右"});
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "神经系统检查>>脑神经>>Ⅺ>>舌肌震颤",
                                                                                        "",//3
                                                                                        "神经系统检查>>脑神经>>Ⅺ>>舌肌纤颤", 
                                                                                        "",//5
                                                                                        "神经系统检查>>脑神经>>Ⅺ>>舌肌萎缩",
                                                                                        "" },//7
                                                                        new string[] {  "舌肌震颤：(", //1
                                                                                        "",
                                                                                        " ) 舌肌纤颤：($$", //3
                                                                                        "",
                                                                                        " ) 舌肌萎缩：($$", //5
                                                                                        "",
                                                                                        " )$$" });//7

            #endregion

            //第四部分 打印(图片)
            #region
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" }, new string[] { "\n\n感觉系统：感觉异常发布图：\n" });
            this.m_objPic.m_blnMustPrinted = true;
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] {  "",
                                                                                        "" },
                                                                        new string[] {  "注：各种浅感觉缺失  振动觉缺失●  定位觉减退△  分离性感觉障碍",
                                                                                      "\n    各种浅感觉减退  振动觉减退○  定位觉缺失±   感觉过敏++++   ++++" });
            #endregion

            //第五部分
            #region
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "神经系统检查>>感觉系统>>感觉检查结果","" },
                                                                        new string[] { "\n\n感觉检查结果：", "\n运动系统：$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] {    "神经系统检查>>运动系统>>左利", 
                                                                                                    "神经系统检查>>运动系统>>右利" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] {  "",
                                                                                        "神经系统检查>>运动系统>>肌萎缩", 
                                                                                        "神经系统检查>>运动系统>>肌张力", 
                                                                                        "",
                                                                                        "神经系统检查>>运动系统>>肌力>>左上肢", 
                                                                                        "神经系统检查>>运动系统>>肌力>>左下肢", 
                                                                                        "神经系统检查>>运动系统>>肌力>>右上肢", 
                                                                                        "神经系统检查>>运动系统>>肌力>>右下肢",
                                                                                        ""},
                                                                        new string[] {  "\n",
                                                                                        "    肌萎缩：$$", 
                                                                                        "    肌张力：$$", 
                                                                                        "\n$$",
                                                                                        "    肌力（0～Ⅴ）：左上肢：$$", 
                                                                                        "    左下肢：$$", 
                                                                                        "    右上肢：$$", 
                                                                                        "    右下肢：$$",
                                                                                        "\n\n反射活动:（亢进+++正常或阳性++减退或可疑阳性+消失或阴性○）\n$$"});
            #endregion

            //第六部分 打印(表格)
            #region
            clsRectangleStorage m_recObj3 = new clsRectangleStorage();
            m_recObj3.Add("浅反射", 70, 0, 100, 60);
            m_recObj3.Add("腹壁反射", 70, 0, 300, 30);
            m_recObj3.Add("足反射", 70, 0, 100, 60);
            m_recObj3.Add("提睾反射", 70, 0, 100, 60);
            m_recObj3.Add("肛门反射", 70, 0, 100, 60);
            m_recObj3.Add("\n", 70, 0, 100, 30);

            m_recObj3.Add("", 70, 0, 100, 0);
            m_recObj3.Add("上", 70, 0, 100, 30);
            m_recObj3.Add("中", 70, 0, 100, 30);
            m_recObj3.Add("下", 70, 0, 100, 30);
            m_recObj3.Add("", 70, 0, 100, 0);
            m_recObj3.Add("", 70, 0, 100, 0);
            m_recObj3.Add("", 70, 0, 100, 0);
            m_recObj3.Add("\n", 70, 0, 100, 30);

            m_recObj3.Add("左", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>左>>上"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>左>>中"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>左>>下"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>足反射>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>提睾反射>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>肛门反射>>左"), 70, 0, 100, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("右", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>右>>上"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>右>>中"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>浅反射>>腹壁反射>>右>>下"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>足反射>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>提睾反射>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>肛门反射>>右"), 70, 0, 100, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("深感觉", 70, 0, 100, 30);
            m_recObj3.Add("肱二头肌", 70, 0, 100, 30);
            m_recObj3.Add("肱三头肌", 70, 0, 100, 30);
            m_recObj3.Add("桡骨", 70, 0, 100, 30);
            m_recObj3.Add("膝腱", 70, 0, 100, 30);
            m_recObj3.Add("跟腱", 70, 0, 100, 30);
            m_recObj3.Add("阵挛", 70, 0, 100, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("左", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>肱二头肌>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>肱三头肌>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>桡骨>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>膝腱>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>跟腱>>左"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>阵挛>>左"), 70, 0, 100, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("右", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>肱二头肌>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>肱三头肌>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>桡骨>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>膝腱>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>跟腱>>右"), 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>深感觉>>阵挛>>右"), 70, 0, 100, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("病理反射", 70, 0, 100, 30);
            m_recObj3.Add("Babinski 征", 70, 0, 150, 30);
            m_recObj3.Add("Chaddock 征", 70, 0, 150, 30);
            m_recObj3.Add("Hoffmann 征", 70, 0, 150, 30);
            m_recObj3.Add("其他", 70, 0, 150, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("左", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Babinski 征>>左"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Chaddock 征>>左"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Hoffmann 征>>左"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>其他>>左"), 70, 0, 150, 30);
            m_recObj3.Add("\n", 70, 0, 50, 30);

            m_recObj3.Add("右", 70, 0, 100, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Babinski 征>>右"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Chaddock 征>>右"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>Hoffmann 征>>右"), 70, 0, 150, 30);
            m_recObj3.Add(this.m_mthGetControlValue("神经系统检查>>反射活动>>病理反射>>其他>>右"), 70, 0, 150, 30);

            this.m_objPrintTables[2].m_mthSetPrintValue(m_recObj3);
            this.m_objPrintTables[2].MaxLineHeight = 60;


            #endregion

            //第七部分
            #region
            //不随意运动

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "不随意运动：" });
            this.m_objPrintContents[10].m_mthPrintValueForCheckControl(null, null, new string[] {   "神经系统检查>>不随意运动>>无", 
                                                                                                    "神经系统检查>>不随意运动>>有" });
            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] {     "",//1
                                                                                            "神经系统检查>>不随意运动>>有>>种类", //2
                                                                                            "神经系统检查>>不随意运动>>有>>部位",//3
                                                                                            "",//4
                                                                                            "神经系统检查>>共济运动>>指鼻试验",//5
                                                                                            "神经系统检查>>共济运动>>轮替试验",//6
                                                                                            "神经系统检查>>共济运动>>跟膝试验"},//7
                                                                            new string[] {  "  (",//1
                                                                                            "种类：$$",//2 
                                                                                            "  部位：$$", //3
                                                                                            ")\n共济运动：$$",//4
                                                                                            "指鼻试验：",//5
                                                                                            "\n          轮替试验：$$",//6
                                                                                            "\n          跟膝试验：$$"});//7
            //Romberg征(
            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("\n          Romberg征：(", ")    ", new string[] {    "神经系统检查>>共济运动>>Romberg征>>睁眼", 
                                                                                                                            "神经系统检查>>共济运动>>Romberg征>>闭眼",
                                                                                                                            "神经系统检查>>共济运动>>Romberg征>>加强",
                                                                                                                            "神经系统检查>>共济运动>>Romberg征>>阴性 " });
            //自主神经系统
            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "", 
                                                                                        "神经系统检查>>自主神经系统>>汗腺分泌",
                                                                                        "神经系统检查>>自主神经系统>>皮肤划痕"},
                                                                        new string[] {  "\n自主神经系统：", 
                                                                                        "\n             汗腺分泌：$$", 
                                                                                        "\n             皮肤划痕：$$"});
            #endregion

            //第八部分
            #region
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl("神经系统检查>>其他", "其他：");
            #endregion

            #endregion

            #region 特殊检查


            //第一部分ok
            #region
            this.m_objPrintContents[12].m_mthSetSpecialTitleValue("特 殊 检 查");
            
            #endregion

            //第二部分 打印(表格)ok
            #region
            clsRectangleStorage m_recObj2 = new clsRectangleStorage();
            m_recObj2.Add("项目", 70, 0, 100, 30);
            m_recObj2.Add("号码", 70, 0, 100, 30);
            m_recObj2.Add("检查日期", 70, 0, 150, 30);
            m_recObj2.Add("结论", 70, 0, 350, 30);
            m_recObj2.Add("\n", 70, 0, 50, 30);

            m_recObj2.Add("X线平片", 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>X线平片>>号码"), 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>X线平片>>检查日期"), 70, 0, 150, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>X线平片>>结论"), 70, 0, 350, 30);
            m_recObj2.Add("\n", 70, 0, 50, 30);

            m_recObj2.Add("CT扫描", 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>CT扫描>>号码"), 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>CT扫描>>检查日期"), 70, 0, 150, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>CT扫描>>结论"), 70, 0, 350, 30);
            m_recObj2.Add("\n", 70, 0, 50, 30);

            m_recObj2.Add("MRI扫描", 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>MRI扫描>>号码"), 70, 0, 100, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>MRI扫描>>检查日期"), 70, 0, 150, 30);
            m_recObj2.Add(this.m_mthGetControlValue("特殊检查>>MRI扫描>>结论"), 70, 0, 350, 30);

            this.m_objPrintTables[1].m_mthSetPrintValue(m_recObj2);
            #endregion

            //第三部分ok
            #region
            //腰穿
            this.m_objPrintContents[13].m_mthSetPrintValueForTextControl("特殊检查>>腰穿", "腰穿：");

            #endregion

            //第四部分ok
            #region
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl("特殊检查>>其他", "其他：");
            this.m_objPrintContents[15].m_mthSetPrintValueForTextControl("总结", "总结：");
            this.m_objPrintContents[16].m_mthSetPrintValueForTextControl("诊断", "诊断：");
            this.m_objPrintContents[17].m_mthSetPrintValueForTextControl("医师签名", "医师：");
            #endregion

            #endregion

            #region "m_mthSetPrintValue" Example:
            //this.m_objPrintContents[0].m_mthSetPrintValue(  new string[] {  "胸部>>胸廓",         "胸部>>肺脏",       "胸部>>心脏" },
            //                                                new string[] {  "\n         胸廓：",  "\n         肺脏：  ", "\n         心脏："  }
            //                                                );

            //this.m_objPrintContents[0].m_mthSetPrintValue(new string[] { "血管",        "腹部",     "外生殖器、肛门、会阴",     "脊柱四肢",     "神经系统",     "体格检查>>其它" },
            //                                              new string[] { "\n血管：",    "\n腹部：", "\n外生殖器、肛门、会阴:",  "\n脊柱四肢:",  "\n神经系统:",  "\n其它:" });
            #endregion

            //执行基类方法过程
            base.m_mthSetSubPrintInfo();
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 垃圾回收
        /// </summary>
        public void Dispose()
        {
            GC.Collect();//强制来及回收，回收所有代
        }

        #endregion
    }
    #region PrintingContents
    /// <summary>
    /// 专科打印的病人信息部分打印类
    /// </summary>
    internal class clsPatientFixInfo : iCare.clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        /// <summary>
        /// 标题内容
        /// </summary>
        private string strheaderText = null;
        /// <summary>
        /// 标题所使用的默认字体

        /// </summary>
        private Font m_fotItemHead = new Font("Simsun", 15, FontStyle.Bold);
        /// <summary>
        /// 标题风格
        /// </summary>
        private StringFormat m_stringFormat = null;
        /// <summary>
        /// 打印上下文对象

        /// </summary>
        private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("Simsun", 10));

        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="headerText">标题内容</param>
        /// <param name="headerFont">标题所使用的字体</param>
        public clsPatientFixInfo(string headerText,Font headerFont)
        {
            this.strheaderText = headerText;
            if (headerFont != null)
                this.m_fotItemHead = headerFont;
            this.m_stringFormat = new StringFormat();
            this.m_stringFormat.Alignment = StringAlignment.Center;
            this.m_stringFormat.LineAlignment = StringAlignment.Center;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_intPosY"></param>
        /// <param name="p_objGrp"></param>
        /// <param name="p_fntNormalText"></param>
        public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        {
            if (!string.IsNullOrEmpty(this.strheaderText))
            {
                p_objGrp.DrawString(this.strheaderText, this.m_fotItemHead, Brushes.Black, base.m_intRecBaseX + 350, p_intPosY, this.m_stringFormat);
                p_intPosY += 30;
            }
            p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("病史陈述人和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("病史记录者：" + (m_objContent == null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 300, p_intPosY);

            p_intPosY += 20;
            if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            }
            else
            {
                p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 50, p_intPosY);
            }

            m_objPrintContext.m_mthSetContextWithAllCorrect("地址：" + m_objPrintInfo.m_strHomeAddress, "<root />");

            int intRealHeight;
            Rectangle rtgBlock = new Rectangle(base.m_intRecBaseX + 300, p_intPosY, (int)enmRectangleInfo.RightX - (base.m_intRecBaseX + 300), 30);
            m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

            p_intPosY += 30;
            base.m_blnHaveMoreLine = false;
        }
        /// <summary>
        /// 重至参数值

        /// </summary>
        public override void m_mthReset()
        {
            this.m_objPrintContext.m_mthRestartPrint();
            base.m_blnHaveMoreLine = true;
        }
    }
    /// <summary>
    /// 一般的不包含图片、表格的可自动换行的语句或段落的打印类

    /// </summary>
    internal class clsPrintInPatMedRecItem : iCare.clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        #region Object
        /// <summary>
        /// 打印块上下文对象
        /// </summary>
        private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsIMR_NerveSystemPrintTool.m_fontConent);
        /// <summary>
        /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        /// </summary>
        private bool m_blnIsFirstPrint = true;
        /// <summary>
        /// 大标题

        /// </summary>
        private string m_strSpecialTitle = null;
        /// <summary>
        /// 小标题

        /// </summary>
        private string m_strTitle = null;
        /// <summary>
        /// 内容
        /// </summary>
        private string m_strText = "";
        /// <summary>
        /// 内容的xml描述信息
        /// </summary>
        private string m_strTextXml = "";
        /// <summary>
        /// 标识是否打印
        /// </summary>
        private bool m_blnNoPrint = true;
        /// <summary>
        /// 
        /// </summary>
        private const Int32 printWidth = 670;
        /// <summary>
        /// 
        /// </summary>
        private const Int32 printWidth2 = 710;
        /// <summary>
        /// 专科打印内容，源数据
        /// </summary>
        private clsInpatMedRec_Item m_objItemContent = null;
        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_intPosY">纵坐标</param>
        /// <param name="p_objGrp">绘图对象</param>
        /// <param name="p_fntNormalText">使用的字体</param>
        public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        {
            if (this.m_blnNoPrint)
            {
                //打印错误提示
                p_objGrp.DrawString("//没有内容可以打印.", p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 10, p_intPosY);
                p_intPosY += 20;
                base.m_blnHaveMoreLine = false;
                return;
            }

            if (this.m_blnIsFirstPrint)
            {
                //打印项目大标题

                if (!string.IsNullOrEmpty(this.m_strSpecialTitle))
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString(this.m_strSpecialTitle, clsInpatMedRecPrintBase.m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    p_intPosY += 40;
                }

                if (!string.IsNullOrEmpty(this.m_strTitle))
                {//打印有且只有一个段落的内容
                    //绘制项目名称
                    p_objGrp.DrawString(this.m_strTitle, p_fntNormalText, Brushes.Black, base.m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    //设置项目内容
                    this.m_objPrintContext.m_mthSetContextWithCorrectBefore((this.m_objItemContent == null ? "" : this.m_objItemContent.m_strItemContent),
                                                                            (this.m_objItemContent == null ? "<root />" : this.m_objItemContent.m_strItemContentXml),
                                                                             this.m_dtmFirstPrintTime, m_objItemContent != null);
                    base.m_mthAddSign2(this.m_strTitle, this.m_objPrintContext.m_ObjModifyUserArr);
                }
                else
                {//打印由多个段落合并而成的内容

                    if (this.m_strText != null && this.m_strTextXml != null)
                        this.m_objPrintContext.m_mthSetContextWithCorrectBefore(this.m_strText, this.m_strTextXml, this.m_dtmFirstPrintTime, true);
                    base.m_mthAddSign2(this.m_strSpecialTitle, this.m_objPrintContext.m_ObjModifyUserArr);
                }
                this.m_blnIsFirstPrint = false;
            }
            //执行打印操作
            //enmRectangleInfoInPatientCaseInfo 枚举定义于clsInpatMedRecPrintBase 类

            if (this.m_objPrintContext.m_BlnHaveNextLine())
            {
                if (!string.IsNullOrEmpty(this.m_strTitle))
                    m_objPrintContext.m_mthPrintLine(printWidth, base.m_intRecBaseX + 50, p_intPosY, p_objGrp);
                else
                    m_objPrintContext.m_mthPrintLine(printWidth2, base.m_intRecBaseX + 10, p_intPosY, p_objGrp);
                p_intPosY += 20;
            }
            else
                base.m_blnHaveMoreLine = false;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public override void m_mthReset()
        {
            this.m_objPrintContext.m_mthRestartPrint();
            base.m_blnHaveMoreLine = true;
            this.m_blnIsFirstPrint = true;
            this.m_strSpecialTitle = null;
            this.m_strTitle = null;
            this.m_strText = null;
            this.m_strTextXml = null;
        }

        #region 设置多项，可叠加打印的内容，可以将多项的内容进行重整打印
        /// <summary>
        /// 设置多项打印内容
        /// </summary>
        /// <param name="p_strKeyArr">哈希键对应于控件的描述(数组)</param>
        /// <param name="p_strTitleArr">小标题(数组),待打印内容</param>
        public void m_mthSetPrintValueForTextControl(string[] p_strKeyArr, string[] p_strTitleArr)
        {
            if (p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
            {
                this.m_blnNoPrint = true;//设置为不能打印

            }
            else
            {
                this.m_blnNoPrint = false;//设置为可以打印

                //if (base.m_blnHavePrintInfo(p_strKeyArr))
                    base.m_mthMakeText(p_strTitleArr, p_strKeyArr, ref this.m_strText, ref this.m_strTextXml);
            }
        }
        /// <summary>
        /// 打印含有单选或多选的选择控件的内容

        /// </summary>
        /// <param name="strHeader">文本头</param>
        /// <param name="strFooter">文本尾</param>
        /// <param name="p_strKeyArr">Check控件的描述</param>
        public void m_mthPrintValueForCheckControl(string strHeader,string strFooter,string[] p_strKeyArr)
        {
            if (p_strKeyArr != null)
            {
                this.m_blnNoPrint = false;
                if (base.m_blnHavePrintInfo(p_strKeyArr))
                    base.m_mthMakeCheckText(strHeader, strFooter, p_strKeyArr, ref this.m_strText, ref this.m_strTextXml);
                    //base.m_mthMakeCheckText(p_strKeyArr, ref this.m_strText, ref this.m_strTextXml);
            }
            else
                this.m_blnNoPrint = true;
        }
        #endregion

        #region 设置该对象的单次打印内容，理论上使用这些方法的对象只能一次打印一项

        /// <summary>
        /// 设置单项打印内容
        /// </summary>
        /// <param name="p_strKey">哈希键对应于控件的描述</param>
        /// <param name="p_strTitle">小标题(待打印内容)</param>
        public void m_mthSetPrintValueForTextControl(string p_strKey, string p_strTitle)
        {
            if (base.m_hasItems != null && p_strKey != null)
            {
                if (base.m_hasItems.Contains(p_strKey))
                    this.m_objItemContent = base.m_hasItems[p_strKey] as clsInpatMedRec_Item;
            }
            if (!string.IsNullOrEmpty(p_strTitle))
            {
                this.m_blnNoPrint = false;
                this.m_strTitle = p_strTitle;
            }
        }
        /// <summary>
        /// 设置大标题如“体格检查”

        /// </summary>
        /// <param name="p_strTitle"></param>
        public void m_mthSetSpecialTitleValue(string p_strTitle)
        {
            if (!string.IsNullOrEmpty(p_strTitle))
            {
                this.m_blnNoPrint = false;
                this.m_strSpecialTitle = p_strTitle;
            }
        }
        #endregion
    }
    /// <summary>
    /// 打印表格类

    /// </summary>
    internal class clsPrinTable : iCare.clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        #region Object
        /// <summary>
        /// 标识是否打印
        /// </summary>
        private bool m_blnIsFirstPrint = true;
        /// <summary>
        /// 绘制格子边框的画笔

        /// </summary>
        private Pen m_penDrawPen = null;
        /// <summary>
        /// 下一个打印方格的左X坐标
        /// </summary>
        private Int32 m_intPrintX;
        /// <summary>
        /// 表格左边框到页面最左边的距离

        /// </summary>
        private Int32 m_intStartX = 70;
        /// <summary>
        /// 在此次打印的表格中最高的格子的高度

        /// </summary>
        private Int32 m_intMaxLineHeight = 30;
        /// <summary>
        /// 当前打印的格子信息对象的序号
        /// </summary>
        private Int32 m_intCurrentPrintIndex = 0;
        /// <summary>
        /// 格子信息存储对象
        /// </summary>
        private clsRectangleStorage m_objForPrint = null;
        /// <summary>
        /// 信息在格子中显示的格式

        /// </summary>
        private StringFormat m_stringFormat = null;

        #endregion
        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="m_intStartX">表格左边框离页面最左的距离</param>
        public clsPrinTable(Int32 m_intStartX)
        {
            if (m_intStartX != -1)
                this.m_intStartX = m_intStartX;
            this.m_penDrawPen = new Pen(Brushes.Black);
            this.m_penDrawPen.Width = 1;
            this.m_stringFormat = new StringFormat();
            this.m_stringFormat.Alignment = StringAlignment.Center;
            this.m_stringFormat.LineAlignment = StringAlignment.Center;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_intPosY">纵坐标</param>
        /// <param name="p_objGrp">绘图对象</param>
        /// <param name="p_fntNormalText">使用的字体</param>
        public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        {
            for (int i = m_intCurrentPrintIndex; m_intCurrentPrintIndex < this.m_objForPrint.Count; )
            {
                base.m_blnHaveMoreLine = true;
                if (!this.m_objForPrint.NewLine())//不需要换行时
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        if ((p_intPosY + this.m_intMaxLineHeight + 30) > 950)
                        {
                            p_intPosY += (this.m_intMaxLineHeight + 30);
                            return;
                        }
                        this.m_intPrintX = this.m_intStartX;
                        this.m_blnIsFirstPrint = false;
                    }

                    clsRectangleInfo m_RecInfo = this.m_objForPrint.ReadNext();
                    if (m_RecInfo != null)
                    {
                        Rectangle m_Rec = m_RecInfo.Rectang;
                        string printValue = m_RecInfo.Value;
                        if (printValue == null)
                            printValue = "";
                        m_Rec.X = m_intPrintX;
                        m_Rec.Y = p_intPosY;

                        if (m_Rec.Height > 0)
                        {
                            p_objGrp.DrawString(printValue, clsIMR_NerveSystemPrintTool.m_fontConent, Brushes.Black, m_Rec, this.m_stringFormat);
                            p_objGrp.DrawRectangle(this.m_penDrawPen, m_Rec);
                        }
                        i = ++this.m_intCurrentPrintIndex;
                        this.m_intPrintX += m_Rec.Width;//设置下一个元素打印的开始坐标的X坐标值

                    }
                }
                else//需要换行时
                {
                    this.m_intCurrentPrintIndex++;
                    this.m_intPrintX = this.m_intStartX;//重置下一行第一个打印元素的X坐标
                    p_intPosY += 30;//设置下一行的Y坐标
                    if ((p_intPosY + this.m_intMaxLineHeight) > 950)
                        return;
                }
            }
            p_intPosY += 40;//设置下一行的Y坐标
            base.m_blnHaveMoreLine = false;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public override void m_mthReset()
        {
            base.m_blnHaveMoreLine = true;
            this.m_blnIsFirstPrint = true;
            this.m_intCurrentPrintIndex = 0;
            this.m_intMaxLineHeight = 30;
            this.m_intPrintX = 0;
        }
        /// <summary>
        /// 设置单项打印内容
        /// </summary>
        /// <param name="p_strKey">哈希键对应于控件的描述</param>
        /// <param name="p_strTitle">小标题(待打印内容)</param>
        public void m_mthSetPrintValue(clsRectangleStorage m_objForPrint)
        {
            if (m_objForPrint != null && m_objForPrint.Count > 0)
                this.m_objForPrint = m_objForPrint;
        }
        /// <summary>
        /// 设置此次表格打印中最大的格子的高度

        /// </summary>
        public Int32 MaxLineHeight
        {
            set
            {
                this.m_intMaxLineHeight = value;
            }
            get
            {
                return this.m_intMaxLineHeight;
            }
        }
    }
    /// <summary>
    /// 打印图片类

    /// </summary>
    internal class clsPrintPic : iCare.clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        #region 字段
        /// <summary>
        /// 当前打印的图片序号

        /// </summary>
        private int m_intCurrentPic = 0;
        /// <summary>
        /// 控制图片是否必须被打印出来

        /// </summary>
        public bool m_blnMustPrinted = false;
        /// <summary>
        /// 下一张图片打印的开始位置的X坐标
        /// </summary>
        private Int32 m_intNextPicX = 0;
        #endregion

        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="p_blnMustPrinted">控制图片是否必须被打印出来</param>
        public clsPrintPic(bool p_blnMustPrinted)
        {
            this.m_blnMustPrinted = p_blnMustPrinted;
            this.m_intNextPicX = base.m_intRecBaseX + 10;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_intPosY"></param>
        /// <param name="p_objGrp"></param>
        /// <param name="p_fntNormalText"></param>
        public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        {
            if (base.m_objContent == null || base.m_objPrintInfo.m_objContent.m_objPics == null || base.m_objPrintInfo.m_objContent.m_objPics.Length < 1)
            {
                base.m_blnHaveMoreLine = false;
                return;
            }

            if (base.m_blnHaveMoreLine)
            {
                int intPicHeight = this.m_objPrintInfo.m_objContent.m_objPics[this.m_intCurrentPic].intHeight;
                int intPicWidth = this.m_objPrintInfo.m_objContent.m_objPics[this.m_intCurrentPic].intWidth;

                if ((p_intPosY + intPicHeight) > 900)
                {
                    if (this.m_blnMustPrinted)
                    {
                        p_intPosY += intPicHeight;//让当前行号大于最大行号

                        base.m_blnHaveMoreLine = true;//设置为还有需要打印(即换页打印)
                    }
                    else
                        base.m_blnHaveMoreLine = false;

                    return;
                }
                else
                {
                    p_intPosY += 20;//换行

                    int m_PicArrayLength = base.m_objPrintInfo.m_objContent.m_objPics.Length;

                    if ((this.m_intCurrentPic + 1) == m_PicArrayLength)
                    {
                        this.m_intNextPicX = ((int)enmRectangleInfo.RightX + base.m_intRecBaseX - intPicWidth) / 2;
                    }

                    for (int i = this.m_intCurrentPic; i < m_PicArrayLength; )
                    {
                        int picWidth = this.m_objPrintInfo.m_objContent.m_objPics[i].intWidth;
                        int picHeight = this.m_objPrintInfo.m_objContent.m_objPics[i].intHeight;

                        MemoryStream objStream = new MemoryStream(base.m_objPrintInfo.m_objContent.m_objPics[i].m_bytImage);
                        Image imgPrint = new Bitmap(objStream);
                        p_objGrp.DrawImage(imgPrint, this.m_intNextPicX, p_intPosY, picWidth, picHeight);
                        //计算多张图片并排打印时最大的高度，这个高度将作为下一行打印的行号(行位置)
                        intPicHeight = Math.Max(intPicHeight, picHeight);
                        //还有图片要打
                        if (++i < m_PicArrayLength)
                        {
                            this.m_intNextPicX += (picWidth + 10);
                            //多张图片并排的宽度比行宽大则不打印

                            if ((int)enmRectangleInfo.RightX < (this.m_intNextPicX + this.m_objPrintInfo.m_objContent.m_objPics[i].intWidth))
                            {
                                this.m_intCurrentPic = i;
                                this.m_intNextPicX = base.m_intRecBaseX + 10;
                                p_intPosY += intPicHeight;
                                base.m_blnHaveMoreLine = true;
                                return;
                            }
                        }
                    }
                }
                p_intPosY += (intPicHeight + 20);//换行
            }
            base.m_blnHaveMoreLine = false;
        }
        /// <summary>
        /// 重置参数值

        /// </summary>
        public override void m_mthReset()
        {
            //打印预览或者打印后都得重置
            base.m_blnHaveMoreLine = true;
            this.m_intCurrentPic = 0;
            this.m_intNextPicX = base.m_intRecBaseX + 10;
        }
    }
    #endregion

    #region PrintingHelper
    /// <summary>
    /// 格子信息存储器类
    /// </summary>
    public class clsRectangleStorage
    {
        #region 字段
        /// <summary>
        /// 下一个格子信息在该表格信息存储器中的序号
        /// </summary>
        private Int32 m_intIndex = 0;
        /// <summary>
        /// 当前指向的格子信息所在位置的序号
        /// </summary>
        private Int32 m_intReadIndex = 0;
        /// <summary>
        /// 存放所有格子信息的哈西表

        /// </summary>
        private Dictionary<Int32, clsRectangleInfo> m_haRecInfos = null;
        #endregion

        /// <summary>
        /// 构造函数

        /// </summary>
        public clsRectangleStorage()
        {
            this.m_intIndex = 0;
            this.m_intReadIndex = 0;
            this.m_haRecInfos = new Dictionary<Int32, clsRectangleInfo>();
        }
        /// <summary>
        /// 添加格子信息
        /// </summary>
        /// <param name="value">格子中的内容</param>
        /// <param name="x">格子左边的X坐标</param>
        /// <param name="y">格子左边的Y坐标</param>
        /// <param name="width">格子的宽度</param>
        /// <param name="height">格子的高度</param>
        public void Add(string value, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            clsRectangleInfo rec = new clsRectangleInfo(x, y, width, height);
            rec.Value = value;
            this.m_haRecInfos.Add(this.m_intIndex++, rec);
        }
        /// <summary>
        /// 获取或设置对应序号的格子信息对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public clsRectangleInfo this[Int32 index]
        {
            get
            {
                if (this.m_haRecInfos != null && this.m_haRecInfos.ContainsKey(index))
                    return this.m_haRecInfos[index];
                else
                    return null;
            }
        }
        /// <summary>
        /// 判断是否下一个元素标识为换行，是返回 true,否则返回false
        /// </summary>
        /// <returns></returns>
        public bool NewLine()
        {
            if (this.m_haRecInfos != null &&
                this.m_haRecInfos.ContainsKey(this.m_intReadIndex) &&
                this.m_haRecInfos[this.m_intReadIndex] != null)
            {
                clsRectangleInfo temp = this.m_haRecInfos[this.m_intReadIndex];
                if (temp.Value.Equals("\n", StringComparison.OrdinalIgnoreCase))
                {
                    this.m_intReadIndex++;
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// 读取下一个打印元素，不存在将返回 NULL
        /// </summary>
        /// <returns></returns>
        public clsRectangleInfo ReadNext()
        {
            if (this.m_haRecInfos != null &&
                this.m_haRecInfos.ContainsKey(this.m_intReadIndex))
            {
                return this.m_haRecInfos[this.m_intReadIndex++];
            }
            else
                return null;
        }
        /// <summary>
        /// 获取格子信息存储器中格子信息的数量

        /// </summary>
        public Int32 Count
        {
            get
            {
                if (this.m_haRecInfos != null)
                    return this.m_haRecInfos.Count;
                else
                    return 0;
            }
        }
    }
    /// <summary>
    /// 格子信息类(包含格子长、宽、高，格子内容等信息)
    /// </summary>
    public class clsRectangleInfo
    {
        #region 字段
        /// <summary>
        /// 格子的内容

        /// </summary>
        private string m_strName = null;
        /// <summary>
        /// 格子对象
        /// </summary>
        private Rectangle m_recRec;
        #endregion

        /// <summary>
        /// 构造函数

        /// </summary>
        public clsRectangleInfo()
        {
            this.m_recRec = new Rectangle();
        }
        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="x">矩形左上角的X坐标</param>
        /// <param name="y">矩形左上角的Y坐标</param>
        /// <param name="width">矩形的宽度</param>
        /// <param name="height">矩形的高度</param>
        public clsRectangleInfo(int x, int y, int width, int height)
        {
            this.m_recRec = new Rectangle(x, y, width, height);
        }
        /// <summary>
        /// 获取或者设置格子内容

        /// </summary>
        public string Value
        {
            get
            {
                if (this.m_strName == null)
                    return string.Empty;
                else
                    return this.m_strName;
            }
            set
            {
                this.m_strName = value;
            }
        }
        /// <summary>
        /// 获取或者设置格子对象

        /// </summary>
        public Rectangle Rectang
        {
            get
            {
                return this.m_recRec;
            }
            set
            {
                this.m_recRec = value;
            }
        }
    }
    #endregion
}