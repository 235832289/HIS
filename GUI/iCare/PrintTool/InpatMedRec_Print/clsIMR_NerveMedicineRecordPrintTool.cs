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
    public class clsIMR_NerveMedicineRecordPrintTool : clsInpatMedRecPrintBase, IDisposable
    {
        #region 字段
        /// <summary>
        /// 一般的不包含图片、表格的可自动换行的语句或段落打印对象

        /// </summary>
        private clsPrintInPatMedRecItem[] m_objPrintContents = null;
        private clsPrinTable[] m_objPrintTables = null;
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
        public clsIMR_NerveMedicineRecordPrintTool(string p_strTypeID)
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
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem(),
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem()
            };
            //表格打印对象
            this.m_objPrintTables = new clsPrinTable[]
            {
                new clsPrinTable(50), new clsPrinTable(50),
                new clsPrinTable(50), new clsPrinTable(50)
            };
            //把对象放入打印队列开始执行打印

            base.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { 
                    new clsPrintPatientFixInfo("神经内科住院病历", 310),//该类为已定义好的用来打印标准专科病历头病人信息的类，在该类能够满足信息需要的情况下不需要重定义直接使用即可。

                    this.m_objPrintContents[0], this.m_objPrintContents[1],
                    this.m_objPrintContents[2], this.m_objPrintContents[3],
                    this.m_objPrintContents[4], this.m_objPrintContents[5],
                    this.m_objPrintContents[6], this.m_objPrintContents[7],
                    this.m_objPrintContents[8], this.m_objPrintContents[9],
                    this.m_objPrintContents[10], this.m_objPrintContents[11],
                    this.m_objPrintContents[12], this.m_objPrintContents[13],
                    this.m_objPrintTables[0], this.m_objPrintContents[14],
                    this.m_objPrintTables[1], this.m_objPrintTables[2],
                    this.m_objPrintTables[3], this.m_objPrintContents[15],
                    this.m_objPrintContents[16], this.m_objPrintContents[17],
                    this.m_objPrintContents[18], this.m_objPrintContents[19],
                    this.m_objPrintContents[20], this.m_objPrintContents[21]
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
            this.m_objPrintContents[3].m_mthSetPrintValueForTextControl(new string[] { "" }, new string[] { "个人史：$$" });
            this.m_objPrintContents[3].m_mthPrintValueForCheckControl("\n      性格：", "    ", new string[] { "个人史>>性格>>急躁", 
                                                                                                                "个人史>>性格>>随和", 
                                                                                                                "个人史>>性格>>内向", 
                                                                                                                "个人史>>性格>>外向", 
                                                                                                                "个人史>>疫苗接种史" });
            this.m_objPrintContents[3].m_mthSetPrintValueForTextControl(new string[] {  "个人史>>吸烟", 
                                                                                        "个人史>>饮酒", 
                                                                                        "个人史>>疫水接触史", 
                                                                                        "个人史>>毒物接触史",
                                                                                        "个人史>>疫苗接种史" },
                                                                        new string[] {  "\n      吸烟：$$", 
                                                                                        "\n      饮酒：$$", 
                                                                                        "\n      疫水接触史：$$", 
                                                                                        "\n      毒物接触史：$$", 
                                                                                        "\n      疫苗接种史：$$" });
            this.m_objPrintContents[4].m_mthSetPrintValueForTextControl("婚姻史", "婚姻史：");
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl("月经生育史", "月经生育史：");
            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl("家族史", "家族史：");
            #endregion

            #region 一般体格检查ok

            //第一部分ok
            #region
            this.m_objPrintContents[7].m_mthSetSpecialTitleValue("体 格 检 查");
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(
                new string[] {  "", //1
                                "体温", //2
                                "", //3
                                "脉搏", //4
                                "",//5
                                "呼吸", //6
                                "",//7
                                "血压>>收缩压",//8
                                "血压>>舒张压", //9
                                ""},//10

                new string[] {  "体温：$$", //1
                                "$$", //2
                                "℃  脉搏：$$",//3
                                "$$",//4
                                "次/分钟  呼吸：$$", //5
                                "$$", //6
                                "次/分钟 血压：$$", //7
                                "$$", //8
                                "/$$",//9
                                "mmHg\n$$"}//10
                                                                        );

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "" }, new string[] { "一般情况：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("\n        体型：", "    ", new string[] { "体型>>瘦长型", "体型>>超力型", "体型>>正力型" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("营养：", null, new string[] { "营养>>良好", "营养>>中度", "营养>>不良" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "", 
                                                                                        "面容", 
                                                                                        "体位", 
                                                                                        "", 
                                                                                        "步态", 
                                                                                        "合作情况" },
                                                                        new string[] {  "\n        $$", 
                                                                                        "面容：$$", 
                                                                                        "    体位：$$", 
                                                                                        "\n        $$", 
                                                                                        "步态：$$", 
                                                                                        "    合作情况：$$" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "", //1
                                                                                        "皮肤粘膜>>颜色", 
                                                                                        "皮肤粘膜>>湿度", "", //3
                                                                                        "",
                                                                                        "皮肤粘膜>>弹性", //5
                                                                                        "皮肤粘膜>>皮疹", 
                                                                                        "",//7
                                                                                        "皮肤粘膜>>浮肿", 
                                                                                        "皮肤粘膜>>血管痣 ", //9
                                                                                        "",
                                                                                        "皮肤粘膜>>皮下结节", //11
                                                                                        "皮肤粘膜>>其他"},
                                                                        new string[] {  "\n皮肤粘膜：\n        $$", //1
                                                                                        "颜色：$$", 
                                                                                        "    湿度：$$", //3
                                                                                        "\n        $$", 
                                                                                        "弹性：$$", //5
                                                                                        "    皮疹：$$", 
                                                                                        "\n        $$",//7
                                                                                        "浮肿：$$", 
                                                                                        "    血管痣：$$", //9
                                                                                        "\n        $$",
                                                                                        "皮下结节：$$", //11
                                                                                        "    其他：$$"});

            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "淋巴结" },
                                                                        new string[] { "\n淋巴结：$$" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "", 
                                                                                        "头颅>>大小及形态", 
                                                                                        "头颅>>包块", 
                                                                                        "",
                                                                                        "头颅>>压痛", 
                                                                                        "头颅>>头发"},
                                                                        new string[] {  "\n头    颅：\n      $$", 
                                                                                        "大小及形态：$$", 
                                                                                        "    包块：$$", 
                                                                                        "\n      $$",
                                                                                        "压痛：$$", 
                                                                                        "    头发：$$" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "", 
                                                                                        "五官>>眼>>眼睑", 
                                                                                        "五官>>眼>>眼裂", 
                                                                                        "", 
                                                                                        "五官>>眼>>结膜", 
                                                                                        "五官>>眼>>巩膜", 
                                                                                        "",
                                                                                        "五官>>眼>>角膜" },
                                                                        new string[] {  "\n五    官：\n      眼：$$", 
                                                                                        "眼睑：$$", 
                                                                                        "    眼裂：$$", 
                                                                                        "\n          $$", 
                                                                                        "结膜：$$", 
                                                                                        "    巩膜：$$", 
                                                                                        "\n          $$", 
                                                                                        "角膜：$$" });
            this.m_objPrintContents[7].m_mthPrintValueForCheckControl("    K-F环：", null, new string[] { "五官>>眼>>无K-F环", "五官>>眼>>有K-F环", "" });
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] { "五官>>眼>>K-F环情况" },
                                                                        new string[] { " $$" });

            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "      耳：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("外耳:分泌物：", null, new string[] { "五官>>耳>>无外耳分泌物", "五官>>耳>>有外耳分泌物" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>耳>>外耳分泌物情况", "" },
                                                                        new string[] { " $$", "    $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("乳突压痛：", null, new string[] { "五官>>耳>>无乳突压痛", "五官>>耳>>有乳突压痛" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>耳>>乳突压痛情况", "" },
                                                                        new string[] { " $$", "\n      鼻：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    鼻翼扇动：", "    ", new string[] {  "五官>>鼻>>无鼻翼扇动", 
                                                                                                                "五官>>鼻>>有鼻翼扇动" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("畸形：", null, new string[] {   "五官>>鼻>>无畸形", 
                                                                                                        "五官>>鼻>>有畸形" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>鼻>>畸形情况", "" },
                                                                        new string[] { " $$", "\n      口：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    唇：", null, new string[] { "五官>>口>>唇正常", "五官>>口>>唇异常" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>口>>唇异常情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    粘膜：", null, new string[] { "五官>>口>>粘膜正常", "五官>>口>>粘膜异常" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>口>>粘膜异常情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "舌", "牙龈", "牙齿", "" },
                                                                        new string[] { "\n      舌：$$", "  牙龈：$$", "  牙齿：$$", "\n      扁桃体：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    肿大：", "    ", new string[] { "五官>>扁桃体>>无肿大", "五官>>扁桃体>>肿大" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("充血：", null, new string[] { "五官>>扁桃体>>无充血", "五官>>扁桃体>>充血" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>扁桃体>>充血情况", "五官>>其他", "" },
                                                                        new string[] { " $$", "\n      其他：$$", "\n颈    部：\n      $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("对称：", "    ", new string[] { "五官>>颈部>>对称", 
                                                                                                        "五官>>颈部>>不对称" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("颈静脉怒张：", "    ", new string[] {  "五官>>颈部>>颈静脉怒张", 
                                                                                                                "五官>>颈部>>颈静脉不怒张" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("气管：", null, new string[] {   "五官>>颈部>>气管居中", 
                                                                                                        "五官>>颈部>>气管偏左",
                                                                                                        "五官>>颈部>>气管偏右" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("\n      甲状腺：", null, new string[] {    "五官>>颈部>>甲状腺正常", 
                                                                                                                    "五官>>颈部>>甲状腺异常" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "五官>>颈部>>甲状腺异常情况", "" },
                                                                        new string[] { " $$", "    $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("血管杂音：", null, new string[] {  "五官>>颈部>>无血管杂音", 
                                                                                                           "五官>>颈部>>有血管杂音" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "\n胸    部：\n$$", "      胸壁：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("异常静脉：", "    ", new string[] {    "胸部>>胸壁>>有异常静脉", 
                                                                                                                "胸部>>胸壁>>无异常静脉" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("皮下气肿：", "    ", new string[] {    "胸部>>胸壁>>有皮下气肿", 
                                                                                                                "胸部>>胸壁>>无皮下气肿" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("胸壁压痛：", "\n      ", new string[] {     "胸部>>胸壁>>有胸壁压痛", 
                                                                                                                    "胸部>>胸壁>>无胸壁压痛" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("胸廓：", null, new string[] {   "胸部>>胸廓>>对称", 
                                                                                                        "胸部>>胸廓>>畸形" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>胸廓>>畸形情况", "" },
                                                                        new string[] { " $$", "    $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("乳房肿块：", null, new string[] { "胸部>>乳房肿块>>无", "胸部>>乳房肿块>>有" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>乳房肿块情况", "" },
                                                                        new string[] { " $$", "\n      肺脏：$$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("    呼吸运动：", null, new string[] {  "胸部>>肺脏>>呼吸运动对称", 
                                                                                                                "胸部>>肺脏>>呼吸运动不对称" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] {  "胸部>>肺脏>>呼吸运动不对称情况", 
                                                                                        "胸部>>呼吸节律",
                                                                                        "" },
                                                                        new string[] {  " $$", 
                                                                                        "    呼吸节律：$$",
                                                                                        "\n      $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("触觉语颤：", "    ", new string[] { "胸部>>触觉语颤>>正常", "胸部>>触觉语颤>>减弱", "胸部>>触觉语颤>>增强" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("胸膜摩擦感：", null, new string[] {    "胸部>>胸膜摩擦感>>无", 
                                                                                                                "胸部>>胸膜摩擦感>>有" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>胸膜摩擦感情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("叩诊音：", "    ", new string[] {  "胸部>>叩诊音>>过清", 
                                                                                                            "胸部>>叩诊音>>清","胸部>>叩诊音>>浊","胸部>>叩诊音>>实","胸部>>叩诊音>>鼓" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>呼吸音" },
                                                                        new string[] { "呼吸音：$$" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n      $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("干罗音：", "    ", new string[] {  "胸部>>干罗音>>无", 
                                                                                                            "胸部>>干罗音>>有" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>干罗音情况", "" },
                                                                        new string[] { " $$", "    $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("湿罗音：", null, new string[] { "胸部>>湿罗音>>无", 
                                                                                                        "胸部>>湿罗音>>有" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>湿罗音情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[8].m_mthPrintValueForCheckControl("胸膜摩擦音：", "    ", new string[] {  "胸部>>胸膜摩擦音>>无", 
                                                                                                                "胸部>>胸膜摩擦音>>有" });
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] { "胸部>>胸膜摩擦音情况", "胸部>>其他" },
                                                                        new string[] { " $$", "    其他：$$" });


            #endregion

            //第二部分ok
            #region
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "心    脏：\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("心前区隆起：", null, new string[] { "心脏>>心前区隆起>>有", "心脏>>心前区隆起>>无" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "心脏>>心尖搏动位置>>肋骨", "" },
                                                                        new string[] { "\n      心尖搏动位置：第 $$", " 肋$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(" (", ")", new string[] { "心脏>>心尖搏动位置>>是否在肋骨间" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("(", ")", new string[] {  "心脏>>心尖搏动位置>>与锁骨中线交点内", 
                                                                                                "心脏>>心尖搏动位置>>与锁骨中线交点外" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "心脏>>心尖搏动位置>>与交点距离", "", "" },
                                                                        new string[] { "", " CM$$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("心包摩擦感：", "    ", new string[] { "心脏>>心包摩擦感>>有", "心脏>>心包摩擦感>>无" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] {  "心脏>>心界", 
                                                                                        "", 
                                                                                        "心脏>>心率", 
                                                                                        "次/分", 
                                                                                        "心脏>>心律",
                                                                                        "" },
                                                                        new string[] {  "  心界：$$", 
                                                                                        "\n      心率：$$", 
                                                                                        " $$", 
                                                                                        " $$", 
                                                                                        "    心律：$$", 
                                                                                        "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("杂音：", null, new string[] {   "心脏>>心杂音>>无", 
                                                                                                        "心脏>>心杂音>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "心脏>>心杂音情况", "心脏>>其他", "" },
                                                                        new string[] { " $$", "    其他：$$", "\n      血管：$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("毛细血管搏动征：", null, new string[] { "心脏>>毛细血管搏动征>>无", 
                                                                                                                 "心脏>>毛细血管搏动征>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "心脏>>毛细血管搏动征情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("\n            浅表动脉搏动对称：", null, new string[] { "心脏>>线表动脉搏动对称>>是", 
                                                                                                                            "心脏>>线表动脉搏动对称>>否" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "心脏>>线表动脉搏动对称情况", "" },
                                                                        new string[] { " $$", "\n腹    部：$$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl(null, null, new string[] { "腹部>>平坦", "腹部>>隆起", "腹部>>凹陷", "腹部>>软", "腹部>>硬" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>软硬情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    压痛触痛反跳痛：", null, new string[] { "腹部>>压痛触痛反跳痛>>无", "腹部>>压痛触痛反跳痛>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>压痛触痛反跳痛情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("包块：", null, new string[] { "腹部>>包块>>无", 
                                                                                                    "腹部>>包块>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>包块情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    肝脏：", null, new string[] { "腹部>>肝脏>>正常", 
                                                                                                         "腹部>>肝脏>>异常" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>肝脏情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("胆囊：", null, new string[] {   "腹部>>胆囊>>正常", 
                                                                                                        "腹部>>胆囊>>异常" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>胆囊情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    脾脏：", null, new string[] {   "腹部>>脾脏>>正常", 
                                                                                                            "腹部>>脾脏>>异常" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>脾脏情况", "" },
                                                                        new string[] { " $$", "\n      $$" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("肾脏及尿路：", null, new string[] {    "腹部>>肾脏及尿路>>正常", 
                                                                                                                "腹部>>肾脏及尿路>>异常" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>肾脏及尿路情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    肠鸣音：", null, new string[] { "腹部>>肠鸣音>>正常", 
                                                                                                            "腹部>>肠鸣音>>增强",
                                                                                                            "腹部>>肠鸣音>>减弱" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>肠鸣音情况", "" },
                                                                        new string[] { "# 次/分$$", "\n      $$" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("血管杂音：", null, new string[] {   "腹部>>血管杂音>>无", 
                                                                                                            "腹部>>血管杂音>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "腹部>>血管杂音情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    振水音：", null, new string[] { "腹部>>振水音>>无", 
                                                                                                            "腹部>>振水音>>有" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] {  "腹部>>振水音情况", 
                                                                                        "",
                                                                                        "" },
                                                                        new string[] {  " $$", 
                                                                                        "\n肛    门：$$", 
                                                                                        "\n      $$" });

            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("畸形：", null, new string[] { "肛门>>畸形>>无", "肛门>>畸形>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "肛门>>畸形情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    括约肌松弛：", null, new string[] { "肛门>>括约肌松弛>>无", "肛门>>括约肌松弛>>有" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "肛门>>括约肌松弛情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("痔疮：", null, new string[] { "肛门>>痔疮>>无", "肛门>>痔疮>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "肛门>>痔疮情况况", "", "" },
                                                                        new string[] { " $$", "\n外生殖器：$$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("畸形：", null, new string[] { "外生殖器>>畸形>>无", "外生殖器>>畸形>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "外生殖器>>畸形情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    溃疡：", null, new string[] { "外生殖器>>溃疡>>无", "外生殖器>>溃疡>>有" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "外生殖器>>溃疡情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("疤痕：", null, new string[] { "外生殖器>>疤痕>>无", "外生殖器>>疤痕>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "外生殖器>>疤痕情况" },
                                                                        new string[] { " $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("    异常分泌物：", null, new string[] { "外生殖器>>异常分泌物>>无", "外生殖器>>异常分泌物>>有" });
            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "外生殖器>>异常分泌物情况", "" },
                                                                        new string[] { " $$", "\n      $$" });
            this.m_objPrintContents[9].m_mthPrintValueForCheckControl("肿物：", null, new string[] { "外生殖器>>肿物>>无", "外生殖器>>肿物>>有" });

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] { "外生殖器>>肿物情况" },
                                                                        new string[] { " $$" });

            #endregion

            //第三部分ok
            #region

            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "脊柱及四肢：\n$$" });
            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("      生理弯曲：", null, new string[] { "脊柱及四肢>>生理弯曲异常>>正常", "脊柱及四肢>>生理弯曲异常>>异常" });
            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(new string[] { "脊柱及四肢>>生理弯曲异常情况" }, new string[] { " $$" });

            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("      压痛：", null, new string[] { "脊柱及四肢>>压痛>>无", "脊柱及四肢>>压痛>>有" });
            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(   new string[] { "脊柱及四肢>>压痛情况", "" },
                                                                            new string[] { " $$", "\n$$" });

            this.m_objPrintContents[10].m_mthPrintValueForCheckControl("      强迫头位：", null, new string[] { "脊柱及四肢>>强迫头位>>无", "脊柱及四肢>>强迫头位>>有" });
            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl(   new string[] { "脊柱及四肢>>强迫头位异常情况", "脊柱及四肢>>其他" },
                                                                            new string[] { " $$", "      其他：$$" });

            #endregion

            #endregion

            #region 神经系统检查


            //第一部分ok
            #region
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "神经系统查体：\n$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("      意识状态：", null, new string[] { "神经系统查体>>意识状态>>清楚", "神经系统查体>>意识状态>>谵妄", 
                                                                                                                "神经系统查体>>意识状态>>嗜睡","神经系统查体>>意识状态>>昏迷" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统查体>>意识状态>>昏迷>>浅", "神经系统查体>>意识状态>>昏迷>>中",
                                                                                                    "神经系统查体>>意识状态>>昏迷>>深" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("\n      语言情况：", null, new string[] { "神经系统查体>>语言情况>>不合作", 
                                                                                                                    "神经系统查体>>语言情况>>无法查", 
                                                                                                                    "神经系统查体>>语言情况>>正常", 
                                                                                                                    "神经系统查体>>语言情况>>沟通障碍", 
                                                                                                                    "神经系统查体>>语言情况>>失语" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统查体>>语言情况>>失语>>完全", 
                                                                                                   "神经系统查体>>语言情况>>失语>>不完全" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统查体>>语言情况>>失语>>运动性", 
                                                                                                   "神经系统查体>>语言情况>>失语>>感觉性右","神经系统查体>>语言情况>>失语>>混合性" });

            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "\n      智能：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("计算力：", "    ", new string[] { "神经系统查体>>计算力>>正常", "神经系统查体>>计算力>>减退", "神经系统查体>>计算力>>差" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("记忆力：", null, new string[] {    "神经系统查体>>记忆力>>正常", 
                                                                                                            "神经系统查体>>记忆力>>减退",
                                                                                                            "神经系统查体>>记忆力>>差" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统查体>>记忆力>>差>>瞬间", 
                                                                                                    "神经系统查体>>记忆力>>差>>近时","神经系统查体>>记忆力>>差>>远时" });

            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "\n      $$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("定向力：", " ", new string[] { "神经系统查体>>定向力>>正常", 
                                                                                                        "神经系统查体>>定向力>>减退","神经系统查体>>定向力>>差" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "神经系统查体>>定向力>>差>>时间", 
                                                                                                   "神经系统查体>>定向力>>差>>人物","神经系统查体>>定向力>>差>>地点" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("理解判断力：", null, new string[] {   "神经系统查体>>理解判断力>>正常", 
                                                                                                                "神经系统查体>>理解判断力>>减退","神经系统查体>>理解判断力>>差" });

            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "神经系统查体>>其他", "" },
                                                                            new string[] { "\n      其他：$$", "\n颅 神 经：\n$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("      嗅    觉：", null, new string[] { "颅神经>>嗅觉>>灵敏" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")  ", new string[] {   "颅神经>>嗅觉>>灵敏>>左", 
                                                                                                    "颅神经>>嗅觉>>灵敏>>右" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗅觉>>下降" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")  ", new string[] {   "颅神经>>嗅觉>>下降>>左", 
                                                                                                    "颅神经>>嗅觉>>下降>>右" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗅觉>>丧失" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")", new string[] { "颅神经>>嗅觉>>丧失>>左", 
                                                                                                "颅神经>>嗅觉>>丧失>>右" });





            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "", "颅神经>>视力>>左", "颅神经>>视力>>右" },
                                                                            new string[] { "\n      视 神 经：视力：$$", " 左：$$", "    右：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("\n                视野：", "", new string[] { "颅神经>>视野>>正常", "颅神经>>视野>>缺损" });


            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "颅神经>>视野缺损情况", "" },
                                                                            new string[] { "  $$", "\n                眼底：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("左：", null, new string[] {    "颅神经>>眼底>>未窥入", 
                                                                                                        "颅神经>>眼底>>视乳头边界" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("(", ")", new string[] { "颅神经>>眼底>>视乳头边界>>清楚", 
                                                                                                "颅神经>>眼底>>视乳头边界>>不清楚" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("    颜色：", null, new string[] {      "颅神经>>眼底>>橘红色", 
                                                                                                                "颅神经>>眼底>>苍白",
                                                                                                                "颅神经>>眼底>>其他颜色" });
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "颅神经>>眼底>>其他颜色描述", "" },
                                                                            new string[] { " $$", "\n$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("      眼球位置：", null, new string[] {    "颅神经>>眼球位置>>正常", 
                                                                                                                    "颅神经>>眼球位置>>异常" });
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(new string[] { "颅神经>>眼球位置异常情况", //1
                                                                                        "", 
                                                                                        "颅神经>>左瞳孔", //3
                                                                                        "", 
                                                                                        "颅神经>>右瞳孔",//5
                                                                                        ""},
                                                                        new string[] {  " $$", //1
                                                                                        "    瞳孔：左：$$", 
                                                                                        "$$", //3
                                                                                        "mm    右：$$",
                                                                                        "$$",//5
                                                                                        "mm\n$$"});
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "颅神经>>视神经>>眼裂" },
                                                                            new string[] { "      眼裂：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("    复视：", null, new string[] {   "颅神经>>复视>>无", 
                                                                                                            "颅神经>>复视>>有" });
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "颅神经>>复视情况", "" },
                                                                            new string[] { " $$", "\n三叉神经：\n      角膜反射：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("左：", "    ", new string[] {  "颅神经>>角膜反射>>左>>灵敏", 
                                                                                                        "颅神经>>角膜反射>>左>>迟钝","颅神经>>角膜反射>>左>>丧失" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("右：", null, new string[] { "颅神经>>角膜反射>>右>>灵敏", 
                                                                                                    "颅神经>>角膜反射>>右>>迟钝","颅神经>>角膜反射>>右>>丧失" });
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "" },
                                                                            new string[] { "\n      面部感觉：$$" });
            this.m_objPrintContents[11].m_mthPrintValueForCheckControl("针刺觉：", null, new string[] {    "颅神经>>面部感觉>>针刺觉>>正常", 
                                                                                                            "颅神经>>面部感觉>>针刺觉>>异常" });
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl(   new string[] { "颅神经>>面部感觉>>针刺觉异常情况" },
                                                                            new string[] { " $$" });

            #endregion

            //第二部分ok
            #region
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                            new string[] { "      嗫肌功能：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("张口：", null, new string[] { "颅神经>>嗫肌功能>>张口>>正常", "颅神经>>嗫肌功能>>张口>>偏斜" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "颅神经>>嗫肌功能>>张口>>偏斜>>向左", 
                                                                                                    "颅神经>>嗫肌功能>>张口>>偏斜>>向右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("颞肌：", null, new string[] { "颅神经>>嗫肌功能>>颞肌>>正常", "颅神经>>嗫肌功能>>颞肌>>萎缩" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>嗫肌功能>>颞肌>>萎缩>>左", 
                                                                                                    "颅神经>>嗫肌功能>>颞肌>>萎缩>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗫肌功能>>颞肌>>无力" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>嗫肌功能>>颞肌>>无力>>左", 
                                                                                                    "颅神经>>嗫肌功能>>颞肌>>无力>>右"});

            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n                咬肌：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗫肌功能>>咬肌>>正常", "颅神经>>嗫肌功能>>咬肌>>萎缩" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {   "颅神经>>嗫肌功能>>咬肌>>萎缩>>左", 
                                                                                                    "颅神经>>嗫肌功能>>咬肌>>萎缩>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>嗫肌功能>>咬肌>>无力" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>嗫肌功能>>咬肌>>无力>>左", 
                                                                                                    "颅神经>>嗫肌功能>>咬肌>>无力>>右"});
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n面 神 经：\n      额纹：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>额纹>>对称" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")侧浅    ", new string[] {  "颅神经>>额纹>>左侧浅", 
                                                                                                        "颅神经>>额纹>>右侧浅"});

            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { " 闭目：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>闭目>>对称有力", "颅神经>>闭目>>力弱" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>闭目>>力弱>>左", 
                                                                                                    "颅神经>>力弱>>右"});

            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n      $$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("示齿：", null, new string[] { "颅神经>>示齿>>对称" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")侧浅    ", new string[] {    "颅神经>>示齿>>左侧浅", 
                                                                                                            "颅神经>>示齿>>右侧浅"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("面肌抽搐：", null, new string[] { "颅神经>>面肌抽搐>>无", "颅神经>>面肌抽搐>>有" });
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "颅神经>>面肌抽搐情况", "" },
                                                                        new string[] { "", "\n听 神 经：(有意识障碍时检查听反射)\n      $$" });

            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("听力：", null, new string[] { "听神经>>听力>>正常", "听神经>>听力>>下降" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] { "听神经>>听力>>下降>>左", "听神经>>听力>>下降>>右" });

            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("    眼球震颤：", null, new string[] {"颅神经>>眼球震颤>>无", 
                                                                                                            "颅神经>>眼球震颤>>有"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>眼球震颤>>有>>水平", 
                                                                                                    "颅神经>>眼球震颤>>有>>旋转",
                                                                                                    "颅神经>>眼球震颤>>有>>垂直"});


            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("\n      Weber Test：", null, new string[] {   "颅神经>>WeberTest>>正中", 
                                                                                                                        "颅神经>>WeberTest>>偏左",
                                                                                                                        "颅神经>>WeberTest>>偏右"});

            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] {  "", 
                                                                                        "颅神经>>RinneTest>>左", 
                                                                                        "颅神经>>RinneTest>>右",
                                                                                        "" },
                                                                        new string[] {  "\n      Rinne Test：$$", 
                                                                                        "左：$$",
                                                                                        "\n                  右：$$",
                                                                                        "\n舌咽迷走神经：\n      软腭运动：$$" });

            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>软腭运动>>正常", "颅神经>>软腭运动>>减弱" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>软腭运动>>减弱>>左", 
                                                                                                    "颅神经>>减弱>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>软腭运动>>丧失" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>软腭运动>>丧失>>左", 
                                                                                                    "颅神经>>软腭运动>>丧失>>右"});
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n      $$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("悬雍垂：", null, new string[] {    "颅神经>>WeberTest>>正中", 
                                                                                                            "颅神经>>WeberTest>>偏左", 
                                                                                                            "颅神经>>WeberTest>>偏右" });
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "    $$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("咽反射：", null, new string[] { "颅神经>>咽反射>>正常", "颅神经>>咽反射>>减弱" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {   "颅神经>>咽反射>>减弱>>左", 
                                                                                                    "颅神经>>咽反射>>减弱>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>咽反射>>丧失" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>咽反射>>丧失>>左", 
                                                                                                    "颅神经>>咽反射>>丧失>>右"});
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "\n副 神 经：$$", "\n      转项运动：$$" });

            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>转项运动>>正常", "颅神经>>转项运动>>减弱" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>转项运动>>减弱>>左", 
                                                                                                    "颅神经>>转项运动>>减弱>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>转项运动>>丧失" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "颅神经>>转项运动>>丧失>>左", 
                                                                                                    "颅神经>>转项运动>>丧失>>右"});
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n      耸肩运动：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] {    "颅神经>>耸肩运动>>正中", 
                                                                                                    "颅神经>>耸肩运动>>偏左", 
                                                                                                    "颅神经>>耸肩运动>>偏右" });

            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "\n舌下神经：$$", "\n      伸舌：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] {    "颅神经>>舌下神经>>伸舌>>正中", 
                                                                                                    "颅神经>>舌下神经>>伸舌>>偏左",
                                                                                                    "颅神经>>舌下神经>>伸舌>>偏右"});
            this.m_objPrintContents[12].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "\n      舌肌：$$" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>舌下神经>>舌肌>>正常", "颅神经>>舌下神经>>舌肌>>萎缩" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", ")    ", new string[] {     "颅神经>>舌下神经>>舌肌>>萎缩>>左", 
                                                                                                        "颅神经>>舌下神经>>舌肌>>萎缩>>右"});
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl(null, null, new string[] { "颅神经>>舌下神经>>舌肌>>纤颤" });
            this.m_objPrintContents[12].m_mthPrintValueForCheckControl("(", null, new string[] {    "颅神经>>舌下神经>>舌肌>>纤颤>>左", 
                                                                                                    "颅神经>>舌下神经>>舌肌>>纤颤>>右"});
            #endregion

            //第三部分
            #region
            this.m_objPrintContents[13].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "运动系统：$$" });
            this.m_objPrintContents[13].m_mthPrintValueForCheckControl(null, null, new string[] {    "运动系统>>左利", 
                                                                                                    "运动系统>>右利" });
            this.m_objPrintContents[13].m_mthSetPrintValueForTextControl(new string[] { "运动系统>>肌张力", 
                                                                                        "运动系统>>肌容积", 
                                                                                        "运动系统>>不自主运动",
                                                                                        "运动系统>>步态"},
                                                                        new string[] {  "\n      肌张力：$$", 
                                                                                        "\n      肌容积：$$", 
                                                                                        "\n      不自主运动：$$",
                                                                                        "\n      步态：$$"});
            #endregion

            //第四部分 打印(表格)ok
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

            this.m_objPrintTables[0].MaxLineHeight = 60;
            this.m_objPrintTables[0].m_mthSetPrintValue(m_recObj1);
            #endregion

            //第五部分ok
            #region
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "", "共济运动>>步态", "" },
                                                                        new string[] { "\n共济运动：$$", "\n      步态：$$", "\n      指鼻试验：$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>正常" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>正常>>左", 
                                                                                                    "共济运动>>指鼻试验>>正常>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>不稳" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>不稳>>左", 
                                                                                                    "共济运动>>指鼻试验>>不稳>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>指鼻试验>>不合作" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>指鼻试验>>不合作>>左", 
                                                                                                    "共济运动>>指鼻试验>>不合作>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "$$", "\n      跟膝胫试验：$$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>正常" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>正常>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>正常>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>不稳" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>不稳>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>不稳>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>跟膝胫试验>>不合作" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>跟膝胫试验>>不合作>>左", 
                                                                                                    "共济运动>>跟膝胫试验>>不合作>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "$$", "\n      快速轮替试验：$$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>快速轮替试验>>正常" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>正常>>左", 
                                                                                                    "共济运动>>快速轮替试验>>正常>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>快速轮替试验>>笨拙" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>笨拙>>左", 
                                                                                                    "共济运动>>快速轮替试验>>笨拙>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共共济运动>>快速轮替试验>>不合作" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>快速轮替试验>>不合作>>左", 
                                                                                                    "共济运动>>快速轮替试验>>不合作>>右"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "", "" },
                                                                        new string[] { "$$", "\n      Romberg氏症：$$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>稳" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>Romberg氏症>>稳>>睁眼", 
                                                                                                    "共济运动>>Romberg氏症>>稳>>闭眼"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>不稳" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("(", ")    ", new string[] {  "共济运动>>Romberg氏症>>不稳>>睁眼", 
                                                                                                    "共济运动>>Romberg氏症>>不稳>>闭眼"});
            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                        new string[] { "$$" });
            this.m_objPrintContents[14].m_mthPrintValueForCheckControl(null, null, new string[] { "共济运动>>Romberg氏症>>不合作" });

            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "" },
                                                                         new string[] { "\n感觉系统：$$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("\n      浅感觉：", null, new string[] { "感觉系统>>浅感觉>>正常", "感觉系统>>浅感觉>>异常" });

            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>浅感觉>>异常情况", "" },
                                                                         new string[] { "$$", "          $$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("    深感觉：", null, new string[] { "感觉系统>>深感觉>>正常", "感觉系统>>深感觉>>异常" });

            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>深感觉>>异常情况" },
                                                                         new string[] { "$$" });

            this.m_objPrintContents[14].m_mthPrintValueForCheckControl("\n      皮层感觉：", null, new string[] { "感觉系统>>皮层感觉>>正常", "感觉系统>>皮层感觉>>异常" });

            this.m_objPrintContents[14].m_mthSetPrintValueForTextControl(new string[] { "感觉系统>>皮层感觉>>异常情况", "", "" },
                                                                         new string[] { "$$", "\n反射：$$", "\n$$" });
            #endregion

            //第六部分 打印(表格)
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

            this.m_objPrintTables[1].m_mthSetPrintValue(m_recObj2);
            this.m_objPrintTables[1].MaxLineHeight = 60;
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

            this.m_objPrintTables[2].m_mthSetPrintValue(m_recObj3);
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
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Babinski>>右"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Pussep>>右"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Gordon>>右"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>Oppenheim>>右"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>掌颌反射>>右"), 70, 0, 100, 30);
            m_recObj4.Add(this.m_mthGetControlValue("反射>>病理反射>>吸吮反射>>右"), 70, 0, 100, 30);

            this.m_objPrintTables[3].m_mthSetPrintValue(m_recObj4);
            #endregion

            //第七部分ok
            #region
            this.m_objPrintContents[15].m_mthSetPrintValueForTextControl(new string[] {  "",
                                                                                            "脑膜刺激征>>颈项强直", 
                                                                                            "脑膜刺激征>>KernigSign", 
                                                                                            "脑膜刺激征>>植物系统检查" },
                                                                            new string[] {  "\n脑膜刺激征：$$",
                                                                                            "颈项强直：$$", 
                                                                                            "    Kernig Sign：$$", 
                                                                                            "\n            植物系统检查：$$" });
            #endregion

            #endregion

            #region 特殊检查


            //第一部分ok
            #region
            string m_strDiagnoseBegin = "";
            string m_strDiagnoseModify = "";
            string m_strDiagnoseAdd = "";
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("初步诊断住院医师签名") || m_hasItems.Contains("初步诊断主治医师签名"))
                    m_strDiagnoseBegin = "初步诊断医师签名日期";

                if (m_hasItems.Contains("修正诊断住院医师签名") || m_hasItems.Contains("修正诊断主治医师签名"))
                    m_strDiagnoseModify = "修正诊断医师签名日期";

                if (m_hasItems.Contains("补充诊断住院医师签名") || m_hasItems.Contains("补充诊断主治医师签名"))
                    m_strDiagnoseAdd = "补充诊断医师签名日期";
            }

            this.m_objPrintContents[16].m_mthSetSpecialTitleValue("辅 助 检 查");

            this.m_objPrintContents[16].m_mthSetPrintValueForTextControl("初步诊断", "初步诊断：");
            this.m_objPrintContents[17].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "初步诊断住院医师签名", 
                                                                                        "初步诊断主治医师签名", 
                                                                                        m_strDiagnoseBegin },
                                                                         new string[] {  "          $$",
                                                                                         "住院医师：$$", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            this.m_objPrintContents[18].m_mthSetPrintValueForTextControl("修正诊断", "修正诊断：");
            this.m_objPrintContents[19].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "修正诊断住院医师签名", 
                                                                                        "修正诊断主治医师签名", 
                                                                                        m_strDiagnoseModify },
                                                                         new string[] {  "          $$",
                                                                                         "住院医师：$$", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            this.m_objPrintContents[20].m_mthSetPrintValueForTextControl("补充诊断", "补充诊断：");
            this.m_objPrintContents[21].m_mthSetPrintValueForTextControl(new string[] { "",
                                                                                        "补充诊断住院医师签名", 
                                                                                        "补充诊断主治医师签名", 
                                                                                        m_strDiagnoseAdd },
                                                                         new string[] {  "          $$",
                                                                                         "住院医师：$$", 
                                                                                         "  主治医师：$$", 
                                                                                         "  签名日期：$$" });
            #endregion
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
            GC.Collect();//强制垃圾回收，回收所有代
        }

        #endregion
    }
}