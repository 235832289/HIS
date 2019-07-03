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
    //脑血管病病历打印类
    public class clsIMR_CerebrovascularPrintTool : clsInpatMedRecPrintBase, IDisposable
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
        /// 构造函数
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_CerebrovascularPrintTool(string p_strTypeID)
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
                    new clsPrintPatientFixInfo("脑血管病病历",310),//该类为已定义好的用来打印标准专科病历头病人信息的类，在该类能够满足信息需要的情况下不需要重定义直接使用即可。
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
                                "℃$$"}//14
                                                                        );

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n体型：", null, new string[] {  "体格检查>>体型>>肥胖型", 
                                                                                                        "体格检查>>体型>>健康型",
                                                                                                        "体格检查>>体型>>瘦弱型",
                                                                                                        "体格检查>>体型>>其他" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] { "体格检查>>体型>>其他>>内容" },
                                                                        new string[] { "：" });

            this.m_objPrintContents[5].m_mthPrintValueForCheckControl("\n营养：", null, new string[] {  "体格检查>>营养>>良好", 
                                                                                                        "体格检查>>营养>>正常","体格检查>>营养>>不良" });
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(
                        new string[]{   "",//1
                                        "体格检查>>一般情况>>发育",//2
                                        "体格检查>>一般情况>>营养",//3
                                        "体格检查>>一般情况>>病容",//4
                                        //"",
                                        //"体格检查>>皮肤>>血管痣",//5
                                        //"体格检查>>皮肤>>咖啡斑",//6
                                        //"体格检查>>皮肤>>皮下结节",//7
                                        //"体格检查>>皮肤>>色泽",//8
                                        //"体格检查>>皮肤>>脱水征",//9
                                        //"体格检查>>皮肤>>瘢痕",//10
                                        //"体格检查>>皮肤>>毛发",//11
                                        //"体格检查>>皮肤>>其他"//12
                                        "体格检查>>皮肤"
                                    },

                        new string[] {  "\n一般情况：$$", //1
                                        "发育：$$", //2
                                        "    营养：$$", //3
                                        "    病容：$$", //4
                                        //"\n皮肤：$$",
                                        //"血管痣：$$", //5
                                        //"  咖啡斑：$$", //6
                                        //"  皮下结节：$$", //7
                                        //"\n      色泽：$$", //8
                                        //"  脱水征：$$",//9
                                        //"  瘢痕：$$" ,//10
                                        //"\n      毛发：$$",//11
                                        //"  其他：$$"//12
                                        "\n皮肤：$$"
                                }
                                                            );
            //this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] {  },
            //                                                            new string[] {  });
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
}
