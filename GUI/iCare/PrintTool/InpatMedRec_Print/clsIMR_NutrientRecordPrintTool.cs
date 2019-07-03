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
    public class clsIMR_NutrientRecordPrintTool : clsInpatMedRecPrintBase,IDisposable
    {
        #region 字段
        /// <summary>
        /// 一般的不包含图片、表格的可自动换行的语句或段落打印对象
        /// </summary>
        private clsPrintInPatMedRecItem[] m_objPrintContents = null;
        #endregion

        #region static Object
        public static Font m_fontHeader = new Font("Simsun", 18);
        public static Font m_fontConent = new Font("Simsun", 12);
        public static Font m_fontFooter = new Font("Simsun", 12);
        public static Font m_fontSign = new Font("Simsun", 8);
        #endregion 

        public clsIMR_NutrientRecordPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            base.m_mthPrintHeader(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            base.m_mthPrintTitleInfo(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override System.Collections.Hashtable m_mthSetHashItem(iCareData.clsInpatMedRec_Item[] p_objItemArr)
        {
            return base.m_mthSetHashItem(p_objItemArr);
        }
        /// <summary>
        /// 
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
                new clsPrintInPatMedRecItem(), new clsPrintInPatMedRecItem()
            };
            //把对象放入打印队列开始执行打印
            base.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { 
                    new clsPatientFixInfo("营 养 病 历 首 页",null),//该类为已定义好的用来打印标准专科病历头病人信息的类，在该类能够满足信息需要的情况下不需要重定义直接使用即可。
                    this.m_objPrintContents[0], this.m_objPrintContents[1],
                    this.m_objPrintContents[2], this.m_objPrintContents[3],
                    this.m_objPrintContents[4], this.m_objPrintContents[5],
                    this.m_objPrintContents[6], this.m_objPrintContents[7],
                    this.m_objPrintContents[8], this.m_objPrintContents[9],
                    this.m_objPrintContents[10], this.m_objPrintContents[11]
                }
                );

            base.m_mthSetPrintLineArr();
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void m_mthSetSubPrintInfo()
        {
            this.m_objPrintContents[0].m_mthSetPrintValueForTextControl(new string[] { "营养病历号", "营养治疗开始时间", "","营养治疗结束时间" },
                                                                        new string[] { "营养病历号：", "        营养治疗起止时间：$$", " 至 $$", "$$" });
            this.m_objPrintContents[1].m_mthSetPrintValueForTextControl("病史摘要" , "病史摘要：" );
            this.m_objPrintContents[2].m_mthSetPrintValueForTextControl("主要临床诊断", "主要临床诊断：");
            this.m_objPrintContents[3].m_mthSetPrintValueForTextControl("营养制剂", "营养制剂：");
            this.m_objPrintContents[4].m_mthSetPrintValueForTextControl(new string[] { "", "饮食史>>食欲", "饮食史>>口味", "饮食史>>忌食或不耐受食品", "劳动强度" },
                                                                        new string[] { "饮 食 史：\n", "      食欲：$$", "      口味：$$", "      忌食或不耐受食品：$$", "\n劳动强度：$$" });
            
            this.m_objPrintContents[5].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "营养评价指标>>身高",
                                                                                        "",//3
                                                                                        "营养评价指标>>体重",
                                                                                        "",//5
                                                                                        "营养评价指标>>理想体重",
                                                                                        ""},//7
                                                                        new string[] {  "营养评价指标：\n     身        高：$$", //1
                                                                                        "$$", 
                                                                                        " cm            体       重：$$",//3
                                                                                        "$$",
                                                                                        " kg    理  想 体 重：$$",//5
                                                                                        "$$",
                                                                                        " kg$$"});//7


            this.m_objPrintContents[6].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "营养评价指标>>实际体重/理想体重",
                                                                                        "",//3
                                                                                        "营养评价指标>>体质指数",
                                                                                        "",//5
                                                                                        "营养评价指标>>血红蛋白",
                                                                                        ""},//7
                                                                        new string[] {  "     实际体重/理想体重=$$", //1
                                                                                        "$$", 
                                                                                        " %        体质指数（BMI）=$$",//3
                                                                                        "$$",
                                                                                        "     血 红 蛋 白：$$",//5
                                                                                        "$$",
                                                                                        " g/1$$"});//7
            this.m_objPrintContents[7].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "营养评价指标>>三头肌皮褶厚度",
                                                                                        "",//3
                                                                                        "营养评价指标>>三头肌皮褶厚度达标准值的百分数",
                                                                                        "",//5
                                                                                        "营养评价指标>>前白蛋白"},//7
                                                                        new string[] {  "     三头肌皮褶厚度(TSF)：$$", //1
                                                                                        "$$", 
                                                                                        " cm     达标准值的：$$",//3
                                                                                        "$$",
                                                                                        " %      前 白 蛋 白：$$",//5
                                                                                        "$$"});//7
            this.m_objPrintContents[8].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "营养评价指标>>上臂围",
                                                                                        "",//3
                                                                                        "营养评价指标>>上臂围达标准值的百分数",
                                                                                        "",//5
                                                                                        "营养评价指标>>血清白蛋白",
                                                                                        ""},//7
                                                                        new string[] {  "     上  臂  围  (MAC)：$$", //1
                                                                                        "$$", 
                                                                                        " cm      达标准值的：$$",//3
                                                                                        "$$",
                                                                                        " %     血清白蛋白：$$",//5
                                                                                        "$$",
                                                                                        " g/1$$"});//7

            this.m_objPrintContents[9].m_mthSetPrintValueForTextControl(new string[] {  "",//1
                                                                                        "营养评价指标>>上臂肌围",
                                                                                        "",//3
                                                                                        "营养评价指标>>上臂肌围达标准值的百分数",
                                                                                        "",//5
                                                                                        "营养评价指标>>淋巴细胞总数",
                                                                                        ""},//7
                                                                        new string[] {  "     上 臂 肌 围(MAMC)：$$", //1
                                                                                        "$$", 
                                                                                        " cm      达标准值的：$$",//3
                                                                                        "$$",
                                                                                        " %      淋巴细胞总数：$$",//5
                                                                                        "$$",
                                                                                        " 个/1$$"});//7


            this.m_objPrintContents[10].m_mthSetPrintValueForTextControl("逐步营养评价" ,"逐步营养评价：" );
            this.m_objPrintContents[11].m_mthSetPrintValueForTextControl("营养师签名" ,"营养师签名：" );

            base.m_mthSetSubPrintInfo();
        }


        #region IDisposable 成员

        public void Dispose()
        {
            GC.Collect();
        }

        #endregion
    }
}