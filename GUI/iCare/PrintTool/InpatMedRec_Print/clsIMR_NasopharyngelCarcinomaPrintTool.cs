using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 鼻咽癌病历打印工具类
    /// </summary>
    public class clsIMR_NasopharyngelCarcinomaPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_NasopharyngelCarcinomaPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
        }

        private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
        private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
        private clsPrintInPatMedRecSign[] m_objPrintSignArr;

        protected override void m_mthSetPrintLineArr()
        {
            m_mthInitPrintLineArr();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                    new clsPrintPatientFixInfo("鼻咽癌病历",320),
                    m_objPrintMultiItemArr[0],
                    new clsPrintNowMedRecord(),
                    m_objPrintMultiItemArr[1],
                    new clsPrintMCRecord(),
                    m_objPrintMultiItemArr[2],
                    m_objPrintMultiItemArr[3],
                    m_objPrintMultiItemArr[4],
                    new clsNoseAndThroatCheck(),
                    m_objPrintMultiItemArr[5],
                    m_objPrintMultiItemArr[6],
                    new clsNeckLymphCheck(),
                    m_objPrintMultiItemArr[7],
                    new clsSkullNerveCheck(),
                    m_objPrintMultiItemArr[8],
                    new clsPrintGeneralBlood(),
                    m_objPrintMultiItemArr[9],
                    new clsUltrasonicNeck(),
                    new clsCTCheck(),
					new clsMRICheck(),
                    m_objPrintMultiItemArr[10],
                    m_objPrintMultiItemArr[11],
                    m_objPrintMultiItemArr[12],
                m_objPrintSignArr[0],
                m_objPrintOneItemArr[0],
                m_objPrintSignArr[1],
                m_objPrintOneItemArr[1],
                m_objPrintSignArr[2]});
        }

        private void m_mthInitPrintLineArr()
        {
            m_objPrintOneItemArr = new clsPrintInPatMedRecItem[7];
            for (int i1 = 0; i1 < m_objPrintOneItemArr.Length; i1++)
                m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

            m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[28];
            for (int j2 = 0; j2 < m_objPrintMultiItemArr.Length; j2++)
                m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

            m_objPrintSignArr = new clsPrintInPatMedRecSign[3];
            for (int k3 = 0; k3 < m_objPrintSignArr.Length; k3++)
                m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
        }

        /// <summary>
        /// 把所有项按描述为键放入Hastable
        /// </summary>
        /// <param name="p_hasItem"></param>
        /// <param name="p_ctlItem"></param>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            if (p_objItemArr == null)
                return null;
            Hashtable hasItem = new Hashtable(300);
            foreach (clsInpatMedRec_Item objItem in p_objItemArr)
            {
                if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
                    continue;
                try
                {
                    hasItem.Add(objItem.m_strItemName, objItem);
                }
                catch
                {
                    continue;
                }
            }
            return hasItem;
        }

        protected override void m_mthSetSubPrintInfo()
        {
            #region 主诉
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "主诉" }, new string[] { "主诉：" }); 
            #endregion

            #region 病史
            m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[] { "既往史", "个人史", "婚姻史" },
                    new string[] { "既往史：", "\n个人史：", "\n婚姻史：" });
            m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[] { "家族史" }, new string[] { "家族史：" }); 
            #endregion

            #region 体格检查
            m_objPrintMultiItemArr[3].m_mthSetSpecialTitleValue("体格检查");
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "体温", "体温", "脉搏", "脉搏", "呼吸", "呼吸", "血压>>收缩压", "血压>>舒张压", "", "疼痛评分" },
                new string[] { "体温：", "#℃", "脉搏：", "#次/min", "呼吸：", "#次/min", "血压：", "/$$",  "mmHg；$$", "疼痛评分：" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "", "发育>>正常", "发育>>不良", "发育>>超常" },
                new string[] { "\n发育：", "#正常", "#不良", "#超常" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "", "营养>>良好", "营养>>中等", "营养>>不良", "营养>>恶液质" },
                new string[] { "\n营养：", "#良好", "#中等", "#不良", "#恶液质" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "", "表情>>自如", "表情>>痛苦", "表情>>忧虑", "表情>>恐惧", "表情>>淡漠" },
                new string[] { "\n表情：", "#自如", "#痛苦", "#忧虑", "#恐惧", "#淡漠" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "", "神志>>清楚", "神志>>嗜睡", "神志>>模糊", "神志>>昏睡", "神志>>昏迷", "神志>>谵妄" },
                new string[] { "\n神志：", "#清楚", "#嗜睡", "#模糊", "#昏睡", "#昏迷", "#谵妄" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"皮肤粘膜","浅表淋巴结","头颅五官","体格检查>>耳","体格检查>>鼻","体格检查>>咽喉",
            "颈部","胸廓","肺","心","腹部","肛门","直肠","外生殖器","脊柱四肢","神经系统"},
            new string[] { "\n皮肤粘膜：", "\n浅表淋巴结：", "\n头颅五官：", "耳：", "鼻：", "咽喉：", "\n颈部：", "\n胸廓：", "\n肺：", "\n心：",
                "\n腹部：", "\n肛门：", "\n直肠：", "\n外生殖器：", "\n脊柱四肢：", "\n神经系统：" }); 
            #endregion

            #region 鼻咽部
            m_objPrintMultiItemArr[4].m_mthSetSpecialTitleValue("专科情况");
            m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[] { "专科情况>>鼻咽部描述", "" },
                new string[] { "鼻咽部：", "\n    肿瘤部位：" });
            m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[] { "", "肿瘤部位>>肿瘤形状>>结节型", "肿瘤部位>>肿瘤形状>>粘膜下型", "肿瘤部位>>肿瘤形状>>溃疡型", "肿瘤部位>>肿瘤形状>>菜花型" },
                new string[] { "    肿瘤形状：", "#结节型", "#    粘膜下型", "#    溃疡型", "#    菜花型" }); 
            #endregion

            #region 颈淋巴结
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[] { "专科情况>>颈淋巴结描述" },
                   new string[] { "\n颈淋巴结：" }); 
            #endregion

            #region 颅神经累犯情况
            m_objPrintMultiItemArr[7].m_mthSetPrintValue(new string[] { "专科情况>>颅神经累犯情况描述" },
                   new string[] { "\n颅神经累犯情况：" });
            #endregion

            #region 实验室及器械检查
            m_objPrintMultiItemArr[8].m_mthSetSpecialTitleValue("实验室及器械检查");
            m_objPrintMultiItemArr[9].m_mthSetPrintValue(new string[] { "尿常规", "EB病毒血清检查>>IgA/VCA", "EB病毒血清检查>>IgA/EA", "T淋巴细胞亚群检查测>>CD2+", "T淋巴细胞亚群检查测>>CD2+", 
                "T淋巴细胞亚群检查测>>CD4+", "T淋巴细胞亚群检查测>>CD4+","T淋巴细胞亚群检查测>>CD8+","T淋巴细胞亚群检查测>>CD8+","T淋巴细胞亚群检查测>>CD4+/CD+","T淋巴细胞亚群检查测>>CD4+/CD+",
            "X线检查","B超检查","胸片"}, new string[] { "尿常规：", "\nEB病毒血清检查：IgA/VCA", "    IgA/EA", "\nT淋巴细胞亚群检查测：CD2+", "#%", "    CD4+", "#%", "    CD8+", "#%", "    CD4+/CD+", "#%",
            "\nX线检查：","\nB超检查：","\n胸片："});
            #endregion

            #region 骨ECT扫描
            m_objPrintMultiItemArr[10].m_mthSetPrintValue(new string[] { "骨ECT扫描" },
                   new string[] { "骨ECT扫描：" });
            #endregion

            #region 病理
            m_objPrintMultiItemArr[11].m_mthSetPrintValue(new string[] { "病理结果", "病理号", "病检日期", "报告单位" },
                   new string[] { "病理结果：", "\n病理号：", "\n病检日期：", "\n报告单位：" });
            #endregion

            #region 初步诊断及诊疗计划
            m_objPrintMultiItemArr[12].m_mthSetPrintValue(new string[] { "初步诊断", "诊疗计划" },
                   new string[] { "初步诊断：", "\n诊疗计划：" });
            #endregion

            #region 签名和日期
            m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "住院医师签名" }, 
                new string[] { "住院医师：" });
            #endregion

            #region 修正/补充诊断以及签名
            m_objPrintOneItemArr[0].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[1].m_mthSetPrintValue("补充诊断", "补充诊断：");
            m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            #endregion
        }

        // <summary>
        /// 项目打印
        /// </summary>
        private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

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
            { }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnNoContent && m_blnNoPrint)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    if (m_strTitle != "")
                    {
                        p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_intPosY += 20;
                        //判断是否修正/补充诊断
                        if (m_strTitle == "修正诊断：" || m_strTitle == "补充诊断：")
                            m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null, Color.Red);
                        else
                            m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null);
                        m_mthAddSign2(m_strTitle, m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        if (m_strSpecialTitle != "")
                        {
                            p_objGrp.DrawString(m_strSpecialTitle, clsIMR_HerbalismPrintTool.m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                            p_intPosY += 20;
                        }
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                        m_mthAddSign2(m_strSpecialTitle, m_objPrintContext.m_ObjModifyUserArr);
                    }

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_strTitle != "")
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    else
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 20, p_intPosY, p_objGrp);
                    p_intPosY += 20;

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
                if (objSignContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                p_intPosY += 40;
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
            public void m_mthSetPrintSignValue(string[] p_strkeyArr, string[] p_strTitleArr)
            {
                if (p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
                    return;
                objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
                m_strTitleArr = p_strTitleArr;
            }
        }

        #region 现病史
        /// <summary>
        /// 现病史
        /// </summary>
        private class clsPrintNowMedRecord : clsIMR_PrintLineBase
        {
            public clsPrintNowMedRecord()
            {
            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    #region 现病史
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 10, (float)p_intPosY);

                    p_objGrp.DrawRectangle(PrintPenInf, m_intRecBaseX + 80, p_intPosY, 600, 340);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 220, (float)p_intPosY, (float)m_intRecBaseX + 220, (float)p_intPosY + 340);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 420, (float)p_intPosY, (float)m_intRecBaseX + 420, (float)p_intPosY + 340);

                    p_objGrp.DrawString("症  状", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 120, (float)p_intPosY + 14);
                    p_objGrp.DrawString("出 现 时 间", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 270, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 220, (float)p_intPosY + 20, (float)m_intRecBaseX + 420, (float)p_intPosY + 20);
                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 260, (float)p_intPosY + 23);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY + 20, (float)m_intRecBaseX + 320, (float)p_intPosY + 40);
                    p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 360, (float)p_intPosY + 23);
                    p_objGrp.DrawString("详 细 描 述", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 500, (float)p_intPosY + 14);
                    p_intPosY += 40;
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 80, (float)p_intPosY, (float)m_intRecBaseX + 680, (float)p_intPosY);

                    for (int i = 0; i < 15; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 80, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 420, (float)p_intPosY + i * 20);
                    }

                    p_objGrp.DrawString("鼻塞", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("鼻塞出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("鼻塞出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("涕血", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("涕血出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("抽吸性血痰", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 100, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("抽吸性血痰出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("耳鸣", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("耳鸣出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("耳鸣出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("听力下降", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("听力下降出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("听力下降出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("头痛", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("头痛出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("头痛出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("面麻", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("面麻出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("面麻出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("视朦", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("视朦出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("复视", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("复视出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("眼睑下垂", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("眼睑下垂出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("眼睑下垂出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("舌歪", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 130, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("舌歪出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("舌歪出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("张口困难", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("张口困难出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("说话不清", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("说话不清出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("吞咽困难", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("吞咽困难出现时间"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_intPosY += 20;

                    p_objGrp.DrawString("颈部肿块", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                    p_objGrp.DrawString(m_strGetRightStr("颈部肿块出现时间>>左"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 225, (float)p_intPosY + 3);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 320, (float)p_intPosY, (float)m_intRecBaseX + 320, (float)p_intPosY + 20);
                    p_objGrp.DrawString(m_strGetRightStr("颈部肿块出现时间>>右"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 325, (float)p_intPosY + 3);

                    p_objGrp.DrawString(m_strGetRightStr("现病史"), p_fntNormalText, Brushes.Black, new RectangleF((float)m_intRecBaseX + 422, (float)p_intPosY - 278, 260f, 340f));
                    #endregion
                    p_intPosY += 30;
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        } 
        #endregion

        #region 月经生育史
        /// <summary>
        /// 月经生育史
        /// </summary>
        private class clsPrintMCRecord : clsIMR_PrintLineBase
        {
            public clsPrintMCRecord()
            {
            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    if (m_hasItems.Contains("月经生育史"))
                    {
                        p_intPosY += 10;
                        clsInpatMedRec_Item objItem = m_hasItems["月经生育史"] as clsInpatMedRec_Item;
                        if (objItem == null || objItem.m_strItemContent == "False")
                        {
                            m_blnHaveMoreLine = false;
                            return;
                        }

                        p_objGrp.DrawString("月经生育史:", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 3);
                        p_objGrp.DrawString("初潮" + m_strGetRightStr("初潮") + "岁,", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 110, (float)p_intPosY + 3);
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 210, (float)p_intPosY + 10, (float)m_intRecBaseX + 350, (float)p_intPosY + 10);
                        p_objGrp.DrawString("每次持续" + m_strGetRightStr("月经持续时间") + "天", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 210, (float)p_intPosY - 12);
                        p_objGrp.DrawString("周期" + m_strGetRightStr("月经周期") + "天", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 230, (float)p_intPosY + 12);
                        p_objGrp.DrawString("末次月经" + Convert.ToDateTime(m_strGetRightStr("末次月经时间")).ToString("yyyy年MM月dd日") + ","
                            + m_strGetRightStr("绝经时间") + "岁绝经，经量" + m_strGetCheckStr("经量>>少", "少")
                            + m_strGetCheckStr("经量>>一般", "一般") + m_strGetCheckStr("经量>>多", "多") + ",", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 355, (float)p_intPosY + 3);
                        p_intPosY += 30;
                        p_objGrp.DrawString(m_strGetCheckStr("痛经史>>有", "有") + m_strGetCheckStr("痛经史>>无", "无") + "痛经史，"
                        + "经期" + m_strGetCheckStr("经期>>规则", "规则") + m_strGetCheckStr("经期>>不规则", "不规则")
                        + "，" + m_strGetRightStr("其它月经生育史"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 40, (float)p_intPosY + 3);
                        p_intPosY += 20;
                    }
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey, string p_strCheckContent)
            {
                if (string.IsNullOrEmpty(p_strCheckKey) || string.IsNullOrEmpty(p_strCheckContent))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return p_strCheckContent;
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        } 
        #endregion

        #region 血常规
        /// <summary>
        /// 血常规
        /// </summary>
        private class clsPrintGeneralBlood : clsIMR_PrintLineBase
        {
            public clsPrintGeneralBlood()
            {
            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;
            Font m_fotUpFont = new Font("SimSun", 8);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    p_intPosY += 10;

                    p_objGrp.DrawString("血常规：", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 3);
                    int intCurrent = m_intRecBaseX + 20 + 60;
                    p_objGrp.DrawString("WBC " + m_strGetRightStr("血常规>>WBC"), p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    intCurrent += 60;
                    p_objGrp.DrawString("×10 /L", p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    p_objGrp.DrawString("9", m_fotUpFont, Brushes.Black, intCurrent + 35, p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("RBC " + m_strGetRightStr("血常规>>RBC"), p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    intCurrent += 60;
                    p_objGrp.DrawString("×10 /L", p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    p_objGrp.DrawString("12", m_fotUpFont, Brushes.Black, intCurrent + 35, p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("HGB " + m_strGetRightStr("血常规>>HGB") + "g/L", p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    intCurrent += 130;
                    p_objGrp.DrawString("HCT " + m_strGetRightStr("血常规>>HCT"), p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    intCurrent += 130;
                    p_objGrp.DrawString("PLT " + m_strGetRightStr("血常规>>PLT"), p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    intCurrent += 60;
                    p_objGrp.DrawString("×10 /L", p_fntNormalText, Brushes.Black, intCurrent, (float)p_intPosY + 3);
                    p_objGrp.DrawString("9", m_fotUpFont, Brushes.Black, intCurrent + 35, p_intPosY + 3);
                    intCurrent += 50;
                    p_intPosY += 25;
                   
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        #endregion

        #region 鼻咽部
        /// <summary>
        /// 鼻咽部
        /// </summary>
        private class clsNoseAndThroatCheck : clsIMR_PrintLineBase
        {
            public clsNoseAndThroatCheck()
            {
            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotSmallerFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                    }

                    for (int i = 0; i < 11; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20 + i * 70, (float)p_intPosY, (float)m_intRecBaseX + 20 + i * 70, (float)p_intPosY + 60);
                        if (i < 10)
                        {
                            p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20 + i * 70 + 8, (float)p_intPosY + 23);
                        }
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 55 + i * 70, (float)p_intPosY + 20, (float)m_intRecBaseX + 55 + i * 70, (float)p_intPosY + 60);
                        p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 55 + i * 70 + 8, (float)p_intPosY + 23);
                    }

                    int intCurrent = m_intRecBaseX + 20;
                    p_objGrp.DrawString("前壁", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("顶后壁", p_fntNormalText, Brushes.Black, (float)intCurrent + 5, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("咽隐窝", p_fntNormalText, Brushes.Black, (float)intCurrent + 5, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("咽圆枕隆突", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("鼻腔", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("软腭", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("硬腭", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("口咽后壁", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 3, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("口咽侧壁", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 3, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("喉咽", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);

                    p_intPosY += 40;
                    intCurrent = m_intRecBaseX + 20;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>前壁>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>前壁>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>顶后壁>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>顶后壁>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>咽隐窝>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>咽隐窝>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>咽圆枕隆突>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>咽圆枕隆突>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>鼻腔>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>鼻腔>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>软腭>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>软腭>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>硬腭>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>硬腭>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>口咽后壁>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>口咽后壁>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>口咽侧壁>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>口咽侧壁>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>喉咽>>左"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    intCurrent += 35;
                    p_objGrp.DrawString(m_strGetCheckStr("肿瘤部位>>喉咽>>右"), p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 3);
                    p_intPosY += 25;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey)
            {
                if (string.IsNullOrEmpty(p_strCheckKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return "√";
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        } 
        #endregion

        #region 颈淋巴结
        /// <summary>
        /// 颈淋巴结
        /// </summary>
        private class clsNeckLymphCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotSmallerFont = new Font("SimSun", 8);
            Font m_fotGridContentFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        if (i == 1)
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 72, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                        }
                        else
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                        }
                    }

                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX, (float)p_intPosY, (float)m_intRecBaseX, (float)p_intPosY + 140);

                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 0 || i == 6 || i == 12)
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 140);
                        }
                        else
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 20, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 140);
                        }
                    }

                    int intCurrent = m_intRecBaseX;
                    p_objGrp.DrawString("部位", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 13);
                    p_objGrp.DrawString("大小(cm)", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 40 + 3);
                    p_objGrp.DrawString("活动度", p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 60 + 3);
                    p_objGrp.DrawString("硬度", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 80 + 3);
                    p_objGrp.DrawString("累及皮肤", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 100 + 3);
                    p_objGrp.DrawString("触压痛", p_fntNormalText, Brushes.Black, (float)intCurrent + 10, (float)p_intPosY + 120 + 3);

                    intCurrent += 20;
                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)intCurrent + 210, (float)p_intPosY + 3);
                    p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)intCurrent + 535, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (float)intCurrent + 74, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (float)intCurrent + 128, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (float)intCurrent + 182, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, (float)intCurrent + 236, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅴ", p_fntNormalText, Brushes.Black, (float)intCurrent + 290, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, (float)intCurrent + 344, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (float)intCurrent + 398, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (float)intCurrent + 452, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (float)intCurrent + 506, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, (float)intCurrent + 560, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅴ", p_fntNormalText, Brushes.Black, (float)intCurrent + 614, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, (float)intCurrent + 668, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent += 52;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>大小>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>活动度>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>硬度>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>累及皮肤>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左1"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左2"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左3"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左4"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左5"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>左6"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右1"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右2"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右3"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右4"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右5"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈淋巴结>>触压痛>>右6"), m_fotGridContentFont, Brushes.Black, new RectangleF((float)intCurrent, (float)p_intPosY, 70, 30));
                    p_intPosY += 20;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        } 
        #endregion

        #region 颅神经累犯情况
        /// <summary>
        /// 颅神经累犯情况
        /// </summary>
        private class clsSkullNerveCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                    }

                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY, (float)m_intRecBaseX + 20, (float)p_intPosY + 60);
                    for (int i = 0; i < 15; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 76 + i * 46, (float)p_intPosY , (float)m_intRecBaseX + 76 + i * 46, (float)p_intPosY + 60);
                    }

                    int intCurrent = m_intRecBaseX + 20 + 70;
                    p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, (float)intCurrent , (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅴ1.", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅴ2.", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅴ3.", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅶ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅷ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅸ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅹ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅺ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString("Ⅻ", p_fntNormalText, Brushes.Black, (float)intCurrent, (float)p_intPosY + 3);

                    intCurrent = m_intRecBaseX + 20;
                    p_intPosY += 20;
                    p_objGrp.DrawString("左：", p_fntNormalText, Brushes.Black, (float)intCurrent + 14, (float)p_intPosY + 3);
                    intCurrent += 56;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左1"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左2"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左3"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左4"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左5_1"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左5_2"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左5_3"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左6"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左7"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左8"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左9"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左10"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左11"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>左12"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);

                    intCurrent = m_intRecBaseX + 20;
                    p_intPosY += 20;
                    p_objGrp.DrawString("右：", p_fntNormalText, Brushes.Black, (float)intCurrent + 14, (float)p_intPosY + 3);
                    intCurrent += 56;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右1"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右2"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右3"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右4"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右5_1"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右5_2"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右5_3"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右6"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右7"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右8"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右9"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右10"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右11"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    intCurrent += 46;
                    p_objGrp.DrawString(m_strGetCheckStr("颅神经累犯情况>>右12"), p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                    p_intPosY += 30;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey)
            {
                if (string.IsNullOrEmpty(p_strCheckKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return "√";
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        } 
        #endregion

        #region 血常规
        /// <summary>
        /// 血常规
        /// </summary>
        private class clsBloodGeneral : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotSmallerFont = new Font("SimSun", 8);
            Font m_fotGridContentFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    int intCurrent = m_intRecBaseX + 20;
                    p_objGrp.DrawString("血常规：", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 3);
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        #endregion

        #region 颈部彩超
        /// <summary>
        /// 颈部彩超
        /// </summary>
        private class clsUltrasonicNeck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotSmallerFont = new Font("SimSun", 8);
            Font m_fotGridContentFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(m_strGetCheckStr("选择颈部彩超")))
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    p_objGrp.DrawString("颈部彩超:" + m_strGetRightStr("颈部彩超描述"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 13);
                    p_intPosY += 30;

                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 1)
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 72, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                        }
                        else
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                        }
                    }

                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX, (float)p_intPosY, (float)m_intRecBaseX, (float)p_intPosY + 120);

                    for (int i = 0; i < 13; i++)
                    {
                        if (i == 0 || i == 6 || i == 12)
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 120);
                        }
                        else
                        {
                            p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 20, (float)m_intRecBaseX + 20 + 52 + i * 54, (float)p_intPosY + 120);
                        }
                    }

                    int intCurrent = m_intRecBaseX;
                    p_objGrp.DrawString("部位", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 13);
                    p_objGrp.DrawString("大小(cm)", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 40 + 3);
                    p_objGrp.DrawString("数量(个)", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 60 + 3);
                    p_objGrp.DrawString("边界", p_fntNormalText, Brushes.Black, (float)intCurrent + 15, (float)p_intPosY + 80 + 3);
                    p_objGrp.DrawString("坏死液化", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 100 + 3);
                    
                    intCurrent += 20;
                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)intCurrent + 210, (float)p_intPosY + 3);
                    p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)intCurrent + 535, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (float)intCurrent + 74, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (float)intCurrent + 128, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (float)intCurrent + 182, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, (float)intCurrent + 236, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅴ", p_fntNormalText, Brushes.Black, (float)intCurrent + 290, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, (float)intCurrent + 344, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (float)intCurrent + 398, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (float)intCurrent + 452, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (float)intCurrent + 506, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, (float)intCurrent + 560, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅴ", p_fntNormalText, Brushes.Black, (float)intCurrent + 614, (float)p_intPosY + 3);
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, (float)intCurrent + 668, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent += 52;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>大小>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>数量>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>边界>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 72;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>左6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右1"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右2"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右3"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右4"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右5"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 54;
                    p_objGrp.DrawString(m_strGetRightStr("颈部彩超>>坏死液化>>右6"), m_fotGridContentFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);

                    p_intPosY += 20;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey)
            {
                if (string.IsNullOrEmpty(p_strCheckKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return "√";
                    }
                }
                return "";
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        #endregion

        #region CT检查
        /// <summary>
        /// CT检查
        /// </summary>
        private class clsCTCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotMidFont = new Font("SimSun", 11);
            Font m_fotSmallerFont = new Font("SimSun", 9);
            Font m_fotGridContentFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(m_strGetCheckStr("是否有CT检查")))
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    p_objGrp.DrawString("CT检查:" + m_strGetRightStr("CT检查描述"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 13);
                    p_intPosY += 20;
                    p_objGrp.DrawString("  检查日期:" + m_strGetRightStr("CT检查>>检查日期"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 13);
                    p_objGrp.DrawString("CT号码:" + m_strGetRightStr("颈淋CT检查>>CT号码"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 320, (float)p_intPosY + 13);
                    p_intPosY += 30;

                    for (int i = 0; i < 4; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                    }

                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY, (float)m_intRecBaseX + 20, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 55, (float)p_intPosY, (float)m_intRecBaseX + 55, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 105, (float)p_intPosY, (float)m_intRecBaseX + 105, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 175, (float)p_intPosY, (float)m_intRecBaseX + 175, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 245, (float)p_intPosY, (float)m_intRecBaseX + 245, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 295, (float)p_intPosY, (float)m_intRecBaseX + 295, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 345, (float)p_intPosY, (float)m_intRecBaseX + 345, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 395, (float)p_intPosY, (float)m_intRecBaseX + 395, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 445, (float)p_intPosY, (float)m_intRecBaseX + 445, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 490, (float)p_intPosY, (float)m_intRecBaseX + 490, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 535, (float)p_intPosY, (float)m_intRecBaseX + 535, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 585, (float)p_intPosY, (float)m_intRecBaseX + 585, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 630, (float)p_intPosY, (float)m_intRecBaseX + 630, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 675, (float)p_intPosY, (float)m_intRecBaseX + 675, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 720, (float)p_intPosY, (float)m_intRecBaseX + 720, (float)p_intPosY + 60);

                    float intCurrent = m_intRecBaseX + 20;
                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)intCurrent + 8, (float)p_intPosY + 20 + 3);
                    p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)intCurrent + 8, (float)p_intPosY + 40 + 3);

                    intCurrent += 35;
                    p_objGrp.DrawString("头长肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("咽旁前间隙", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("咽旁后间隙", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("翼内肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("翼外肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("颞下窝", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("上颌窦", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("筛窦", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("碟窦", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("颅底骨", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("颅内", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("口咽", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("眼框", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 55;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左头长肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左咽旁前间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左咽旁后间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左翼内肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左翼外肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左颞下窝"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左上颌窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左筛窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左蝶窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左颅底骨"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左颅内"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左口咽"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>左眼框"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 55;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右头长肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右咽旁前间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右咽旁后间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右翼内肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右翼外肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右颞下窝"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右上颌窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右筛窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右蝶窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右颅底骨"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右颅内"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右口咽"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("CT检查>>右眼框"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    p_intPosY += 20;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey)
            {
                if (string.IsNullOrEmpty(p_strCheckKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return "√";
                    }
                }
                return "";
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        #endregion

        #region MRI检查
        /// <summary>
        /// MRI检查
        /// </summary>
        private class clsMRICheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Pen PrintPenInf = new Pen(Color.Black, 1);
            private bool m_blnIsFirstPrint = true;

            Font m_fotMidFont = new Font("SimSun", 11);
            Font m_fotSmallerFont = new Font("SimSun", 9);
            Font m_fotGridContentFont = new Font("SimSun", 10);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_hasItems == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(m_strGetCheckStr("是否有MRI检查")))
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }

                    p_objGrp.DrawString("MRI检查:" + m_strGetRightStr("MRI检查描述"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 13);
                    p_intPosY += 20;
                    p_objGrp.DrawString("  检查日期:" + m_strGetRightStr("MRI检查>>检查日期"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 20, (float)p_intPosY + 13);
                    p_objGrp.DrawString("MRI号码:" + m_strGetRightStr("MRI检查>>MRI号码"), p_fntNormalText, Brushes.Black, (float)m_intRecBaseX + 320, (float)p_intPosY + 13);
                    p_intPosY += 30;

                    for (int i = 0; i < 4; i++)
                    {
                        p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY + i * 20, (float)m_intRecBaseX + 720, (float)p_intPosY + i * 20);
                    }

                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 20, (float)p_intPosY, (float)m_intRecBaseX + 20, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 55, (float)p_intPosY, (float)m_intRecBaseX + 55, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 105, (float)p_intPosY, (float)m_intRecBaseX + 105, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 175, (float)p_intPosY, (float)m_intRecBaseX + 175, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 245, (float)p_intPosY, (float)m_intRecBaseX + 245, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 295, (float)p_intPosY, (float)m_intRecBaseX + 295, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 345, (float)p_intPosY, (float)m_intRecBaseX + 345, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 395, (float)p_intPosY, (float)m_intRecBaseX + 395, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 445, (float)p_intPosY, (float)m_intRecBaseX + 445, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 490, (float)p_intPosY, (float)m_intRecBaseX + 490, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 535, (float)p_intPosY, (float)m_intRecBaseX + 535, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 585, (float)p_intPosY, (float)m_intRecBaseX + 585, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 630, (float)p_intPosY, (float)m_intRecBaseX + 630, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 675, (float)p_intPosY, (float)m_intRecBaseX + 675, (float)p_intPosY + 60);
                    p_objGrp.DrawLine(PrintPenInf, (float)m_intRecBaseX + 720, (float)p_intPosY, (float)m_intRecBaseX + 720, (float)p_intPosY + 60);

                    float intCurrent = m_intRecBaseX + 20;
                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)intCurrent + 8, (float)p_intPosY + 20 + 3);
                    p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, (float)intCurrent + 8, (float)p_intPosY + 40 + 3);

                    intCurrent += 35;
                    p_objGrp.DrawString("头长肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("咽旁前间隙", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("咽旁后间隙", m_fotSmallerFont, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString("翼内肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("翼外肌", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("颞下窝", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("上颌窦", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("筛窦", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("碟窦", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("颅底骨", m_fotMidFont, Brushes.Black, (float)intCurrent + 1, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString("颅内", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("口咽", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);
                    intCurrent += 45;
                    p_objGrp.DrawString("眼框", p_fntNormalText, Brushes.Black, (float)intCurrent + 2, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 55;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左头长肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左咽旁前间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左咽旁后间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左翼内肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左翼外肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左颞下窝"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左上颌窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左筛窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左蝶窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左颅底骨"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左颅内"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左口咽"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>左眼框"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);

                    p_intPosY += 20;
                    intCurrent = m_intRecBaseX + 55;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右头长肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右咽旁前间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右咽旁后间隙"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 70f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右翼内肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右翼外肌"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右颞下窝"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右上颌窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右筛窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右蝶窦"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右颅底骨"), p_fntNormalText, Brushes.Black, (float)intCurrent + 20, (float)p_intPosY + 3);
                    intCurrent += 50f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右颅内"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右口咽"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    intCurrent += 45f;
                    p_objGrp.DrawString(m_strGetCheckStr("MRI检查>>右眼框"), p_fntNormalText, Brushes.Black, (float)intCurrent + 18, (float)p_intPosY + 3);
                    p_intPosY += 25;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            /// <summary>
            /// 返回选项类的内容
            /// </summary>
            /// <param name="p_strCheckKey">控件描述</param>
            /// <param name="p_strCheckContent">内容</param>
            /// <returns></returns>
            private string m_strGetCheckStr(string p_strCheckKey)
            {
                if (string.IsNullOrEmpty(p_strCheckKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strCheckKey))
                    {
                        objItemContent = m_hasItems[p_strCheckKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null && objItemContent.m_strItemContent == "True")
                    {
                        return "√";
                    }
                }
                return "";
            }

            private string m_strGetRightStr(string p_strKey)
            {
                if (string.IsNullOrEmpty(p_strKey))
                {
                    return "";
                }
                clsInpatMedRec_Item objItemContent = null;
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(p_strKey))
                    {
                        objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
                    }
                    if (objItemContent != null)
                    {
                        return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.
                            s_strGetRightText(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml);
                    }
                }
                return "";
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
