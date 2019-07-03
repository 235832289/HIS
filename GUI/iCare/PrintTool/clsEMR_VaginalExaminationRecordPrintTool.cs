using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 阴道检查记录表打印类
    /// </summary>
    public class clsEMR_VaginalExaminationRecordPrintTool : infPrintRecord, IDisposable
    {
        #region 变量
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        /// <summary>
        /// 表明此次打印是外部赋值(false)还是类内部自动从数据库提取数据(true)
        /// </summary>
        private bool m_blnIsFromDataSource = true;
        /// <summary>
        /// 标识打印对象在邦定打印数据之前是否初始化
        /// </summary>
        private bool m_blnWantInit = true;
        /// <summary>
        /// 打印页计时器，标识当前第几页
        /// </summary>
        private int m_intCurrentPage = 1;
        /// <summary>
        /// 打印的数据对象
        /// </summary>
        private clsPrintInfo_EMR_VaginalExaminationRecord m_objPrintInfo = null;
        /// <summary>
        /// 打印帮助类
        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext = null;
        /// <summary>
        /// 当前打印位置（Y）
        /// </summary>
        private int m_intYPos = 130;//155;

        /// <summary>
        /// 医院标题字体
        /// </summary>
        private static Font m_fotHospitalTitle = null;
        /// <summary>
        /// 表单标题字体
        /// </summary>
        public static Font m_fotHeader = null;
        /// <summary>
        /// 页脚字体
        /// </summary>
        public static Font m_fotFooter = null;
        /// <summary>
        /// 正文字体
        /// </summary>
        public static Font m_fotContent = null;
        /// <summary>
        /// 签名字体
        /// </summary>
        public static Font m_fotSign = null;
        ///// <summary>
        ///// 获取坐标的类
        ///// </summary>
        //private clsPrintPageSettingForRecord m_objPageSetting;
        #endregion
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static clsEMR_VaginalExaminationRecordPrintTool()
        {
            clsEMR_VaginalExaminationRecordPrintTool.m_fotHospitalTitle = new Font("Simsun", 15);
            clsEMR_VaginalExaminationRecordPrintTool.m_fotHeader = new Font("Simsun", 18);
            clsEMR_VaginalExaminationRecordPrintTool.m_fotFooter = new Font("Simsun", 12);
            clsEMR_VaginalExaminationRecordPrintTool.m_fotContent = new Font("Simsun", 12);
            clsEMR_VaginalExaminationRecordPrintTool.m_fotSign = new Font("Simsun", 10);
        }

        /// <summary>
        /// 获取打印修改痕迹设置
        /// </summary>
        private void m_mthGetPrintMarkConfig()
        {
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3012");
            if (intConfig == 0)
            {
                m_blnIsPrintMark = false;
            }
            else
            {
                m_blnIsPrintMark = true;
            }
        }

        #region 格子的信息
        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRectangleInfoEMR_VaginalExaminationRecord
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 140,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 60,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 180,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 7,
            SmallRowStep = 20,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,

            ColumnsMark1 = 35,
            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,
            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1024,

            PrintWidth = 690,
            PrintWidth2 = 600,//710,
            PrintHeight = 920
        }
        #endregion

        #region 打印内容类
        /// <summary>
        /// 打印内容之父类
        /// </summary>
        private abstract class clsEMR_VaginalExaminationRecordInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            /// <summary>
            /// 文字距离左边的边距 
            /// </summary>
            protected int m_intPatientInfoX = 70;
            /// <summary>
            /// 病人信息
            /// </summary>
            protected clsPrintInfo_EMR_VaginalExaminationRecord m_objPrintInfo;

            /// <summary>
            /// 
            /// </summary>
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return base.m_blnHaveMoreLine;
                }
                set
                {
                    if (value != null)
                    {
                        this.m_objPrintInfo = (clsPrintInfo_EMR_VaginalExaminationRecord)value;
                    }
                }
            }

            /// <summary>
            /// 生成打印内容文本块（p_strName长度必须和p_strKey长度一致）
            /// </summary>
            /// <param name="p_strName">
            /// 打印字段名称数组，长度必须和p_strKey长度一致。
            /// 1：附加的字段以#开头，因以键作判断，但不打印键的内容；
            /// 2：只打印内容不打印字段的置空，如""
            /// </param>
            /// <param name="p_strKey">打印内容</param>
            /// <param name="p_strKeyXml">打印内容对应的XML</param>
            /// <param name="p_strTextAll">正常文本</param>
            /// <param name="p_strTextXML">XML文本</param>
            protected void m_mthMakeText(string[] p_strName, string[] p_strKey, string[] p_strKeyXml, ref string p_strTextAll, ref string p_strTextXML)
            {
                if (p_strName == null || p_strKey == null || p_strKeyXml == null || p_strKeyXml.Length != p_strKey.Length || p_strKeyXml.Length != p_strName.Length || p_strKey.Length != p_strName.Length)
                    return;

                string m_strCreadUserID = m_objPrintInfo.m_objRecordContent.m_strCreateUserID;
                string strFirstName = new clsEmployee(m_strCreadUserID).m_StrFirstName;
                string strSemicolonXML = "<root/>";
                bool blnIsFirst = true;
                string strXML = "";

                string m_strDateType = "";
                //专科病历中的ctlRichTextBox在该表单新添记录一段时间后打印也会出现蓝色修改标记，
                //暂先通过给m_strMakedate重新赋值解决

                string m_strMakedate = m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate.ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 0; i < p_strName.Length; i++)
                {
                    string strSam = "；";
                    if (p_strName[i].EndsWith("$$"))
                    {
                        strSam = "";
                        p_strName[i] = p_strName[i].Substring(0, p_strName[i].Length - 2);
                    }
                    strSemicolonXML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strSam, m_strCreadUserID, strFirstName, Color.Black, m_strMakedate);
                    if (p_strKey[i] != "")
                    {

                        string m_strKey = p_strKey[i];
                        string m_strKeyXml = p_strKeyXml[i];
                        if (p_strName[i].StartsWith("#") == true)
                        {
                            p_strTextAll += p_strName[i].Substring(1);
                            strXML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[i].Substring(1), m_strCreadUserID, strFirstName, Color.Black, m_strMakedate);
                            if (p_strTextXML != "")
                                p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, strXML });
                            else
                                p_strTextXML = strXML;
                            blnIsFirst = false;
                        }
                        else
                        {
                            if (m_strKeyXml == null || m_strKeyXml == "")
                            {
                                string strContent = "";
                                if (m_strDateType == "")
                                    strContent = m_strCheckDateType(m_strKey);
                                else
                                {
                                    strContent = m_strCheckDateType(m_strKey, m_strDateType);
                                    m_strDateType = "";
                                }
                                p_strTextAll += (blnIsFirst ? "" : strSam) + p_strName[i] + strContent;
                                strXML = blnIsFirst ? ctlRichTextBox.clsXmlTool.s_strMakeTextXml((p_strName[i] + strContent), m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) :
                                    ctlRichTextBox.s_strCombineXml(new string[] { strSemicolonXML, ctlRichTextBox.clsXmlTool.s_strMakeTextXml((p_strName[i] + strContent), m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) });
                                if (p_strTextXML != "")
                                    p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, strXML });
                                else
                                    p_strTextXML = strXML;
                            }
                            else
                            {
                                p_strTextAll += ((blnIsFirst || p_strName[i] == "") ? "" : strSam) + p_strName[i] + m_strKey;
                                strXML = (blnIsFirst || p_strName[i] == "") ? ctlRichTextBox.s_strCombineXml(new string[] { ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[i], m_strCreadUserID, strFirstName, Color.Black, m_strMakedate), m_strKeyXml }) :
                                    ctlRichTextBox.s_strCombineXml(new string[] { strSemicolonXML, ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[i], m_strCreadUserID, strFirstName, Color.Black, m_strMakedate), m_strKeyXml });
                                if (p_strTextXML != "")
                                    p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, strXML });
                                else
                                    p_strTextXML = strXML;
                            }
                            blnIsFirst = false;
                        }


                    }
                    else
                    {
                        p_strTextAll += (blnIsFirst ? "" : strSam) + p_strName[i];
                        strXML = blnIsFirst ? ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[i], m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) :
                            ctlRichTextBox.s_strCombineXml(new string[] { strSemicolonXML, ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[i], m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) });
                        if (p_strTextXML != "")
                            p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, strXML });
                        else
                            p_strTextXML = strXML;
                        blnIsFirst = true;
                    }
                }
            }

            /// <summary>
            /// 生成CheckBox的打印文本（p_strName长度必须比p_blnChecked长度大一）
            /// </summary>
            /// <param name="p_strName">CheckBox内容数组，数组第一项为标识，从第二项开始才是键</param>
            /// <param name="p_blnChecked"></param>
            /// <param name="p_strTextAll">正常文本</param>
            /// <param name="p_strTextXML">XML文本</param>
            protected void m_mthMakeCheckText(string[] p_strName, bool[] p_blnChecked, ref string p_strTextAll, ref string p_strTextXML)
            {
                if (p_strName == null || p_blnChecked == null || p_strName.Length <= 2 || p_blnChecked.Length <= 1)
                    return;
                bool blnPrintFirst = false;
                string m_strMakedate = m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate.ToString("yyyy-MM-dd HH:mm:ss");
                string m_strCreadUserID = m_objPrintInfo.m_objRecordContent.m_strCreateUserID;
                string strFirstName = new clsEmployee(m_strCreadUserID).m_StrFirstName;
                string strDH_XML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("、", m_strCreadUserID, strFirstName, Color.Black, m_strMakedate);
                p_strTextAll += p_strName[0];
                string strXML = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(p_strName[0], m_strCreadUserID, strFirstName, Color.Black, m_strMakedate);
                if (p_strTextXML != "")
                    p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, strXML });
                else
                    p_strTextXML = strXML;
                for (int i = 1; i < p_strName.Length; i++)
                {
                    if (p_blnChecked[i - 1] == true)
                    {
                        string strText = p_strName[i];

                        p_strTextAll += (blnPrintFirst == true ? "、" : "") + strText;
                        p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, (blnPrintFirst == true ? strDH_XML : "<root />"), ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) });
                        blnPrintFirst = true;
                    }
                }
                p_strTextAll += "；";
                p_strTextXML = ctlRichTextBox.s_strCombineXml(new string[] { p_strTextXML, ctlRichTextBox.clsXmlTool.s_strMakeTextXml("；", m_strCreadUserID, strFirstName, Color.Black, m_strMakedate) });
            }

            /// <summary>
            /// 返回日期格式
            /// </summary>
            /// <param name="p_strValue"></param>
            /// <returns></returns>
            private string m_strCheckDateType(string p_strValue)
            {
                if (p_strValue.Length < 8)
                    return p_strValue;
                string str = "";
                try
                {
                    str = DateTime.Parse(p_strValue).ToString("yyyy年MM月dd日");
                }
                catch { return p_strValue; }
                return str;
            }


            /// <summary>
            /// 根据要求返回所需日期格式
            /// </summary>
            /// <param name="p_strValue"></param>
            /// <param name="p_strDateType"></param>
            /// <returns></returns>
            private string m_strCheckDateType(string p_strValue, string p_strDateType)
            {
                if (p_strValue.Length < 8)
                    return p_strValue;
                string str = "";
                try
                {
                    str = DateTime.Parse(p_strValue).ToString(p_strDateType);
                }
                catch { return p_strValue; }
                return str;
            }
        }
        /// <summary>
        /// 标题及病人基本信息
        /// </summary>
        private class clsEMR_VaginalExaminationRecordFixInfo : clsEMR_VaginalExaminationRecordInfo
        {
            /// <summary>
            /// 是否第一次打印该类中的内容
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objPrintInfo != null && this.m_blnIsFirstPrint)
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.LineAlignment = StringAlignment.Center;
                    // 医院标题

                    p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHospitalTitle, Brushes.Black, new PointF(330f, 100f), stringFormat);
                    // 表单标题
                    p_objGrp.DrawString("阴道检查记录表", m_fotHeader, Brushes.Black, base.m_intPatientInfoX + 270, p_intPosY, stringFormat);
                    p_intPosY += 30;
                    stringFormat.Dispose();

                    p_objGrp.DrawString("姓名：" + base.m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);//115
                    p_objGrp.DrawString("性别：" + base.m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 115, p_intPosY); // 90
                    p_objGrp.DrawString("年龄：" + (base.m_objPrintInfo.m_strAge == null ? "   岁" : base.m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 205, p_intPosY);//90

                    p_objGrp.DrawString("病区：" + base.m_objPrintInfo.m_strAreaName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 295, p_intPosY); // 150
                    p_objGrp.DrawString("床号：" + base.m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 445, p_intPosY); // 85
                    p_objGrp.DrawString("住院号：" + (base.m_objPrintInfo.m_strInPatentID == null ? "" : base.m_objPrintInfo.m_strInPatentID), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 530, p_intPosY);//700
                    p_intPosY += 25;
                    // 打印边框
                    p_objGrp.DrawRectangle(Pens.Black, (int)enmRectangleInfoEMR_VaginalExaminationRecord.LeftX, p_intPosY, (int)enmRectangleInfoEMR_VaginalExaminationRecord.PrintWidth, (int)enmRectangleInfoEMR_VaginalExaminationRecord.PrintHeight);
                    
                    this.m_blnIsFirstPrint = false;
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 打印主要信息
        /// </summary>
        private class clsEMR_VaginalExaminationRecordMain : clsEMR_VaginalExaminationRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                string m_strAllText = "";
                string m_strAllXml = "";
                if (this.m_blnIsFirstPrint)
                {
                    clsEMR_VaginalExaminationValue m_objValue = m_objPrintInfo.m_objRecordContent;

                    m_mthMakeText(new string[] { "\n阴查时间：", " 阴查原因：", "\n1.宫口扩张：", "cm；$$", "  先露：", "  先露高低：", "  方位：", " \n  （", "）颅骨重叠：$$", "产瘤：" },
                        new string[] { m_objValue.m_dtmEXAMINATIONTIME_DAT.ToString("yyyy年MM月dd日 hh:mm"), // 阴查时间
                                       m_objValue.m_strEXAMINATIONREASON_VCHR, // 阴查原因
                                       m_objValue.m_strMETREURYSIS_VCHR, // 宫口扩张
                                       "",      // cm
                                       m_objValue.m_strPRESENTATION_VCHR, // 先露
                                       m_objValue.m_strPRESENTATIONHEIGHT_VCHR, // 先露高低
                                       m_objValue.m_strPRESENTATIONORIENTATION_VCHR, // 方位
                                       m_objValue.m_strSKULL_VCHR,          // 颅骨重叠
                                       m_objValue.m_strOVERLAPPING_VCHR, // 颅骨重叠情况
                                       m_objValue.m_strCAPUTSUCCEDANEUM_VCHR // 产瘤
                        },
                        new string[]{ "", m_objValue.m_strEXAMINATIONREASON_XML, // 阴查原因Xml
                                          m_objValue.m_strMETREURYSIS_XML, // 宫口扩张Xml
                                          "",                   // cm
                                          m_objValue.m_strPRESENTATION_XML, // 先露Xml
                                          m_objValue.m_strPRESENTATIONHEIGHT_XML, // 先露高低Xml
                                          m_objValue.m_strPRESENTATIONORIENTATION_XML, // 先露方位Xml
                                          m_objValue.m_strSKULL_XML, // 颅骨重叠XML
                                          m_objValue.m_strOVERLAPPING_XML, //  颅骨重叠情况XML
                                          m_objValue.m_strCAPUTSUCCEDANEUM_XML  // 产瘤XML
                                      
                        }, ref m_strAllText, ref m_strAllXml);

                    string m_strTemp;
                    string m_strTemp2;
                    string m_strTemp3;
                    if (m_objValue.m_strRUPTUREDFETALMEMBRANES_CHR == "10")
                    {
                        m_strTemp = " 已破";
                        if (m_objValue.m_strRUPTUREDMODE_CHR == "10")
                            m_strTemp2 = " 自然";
                        else if (m_objValue.m_strRUPTUREDMODE_CHR == "01")
                            m_strTemp2 = " 人工";
                        else m_strTemp2 = "";

                        m_strTemp3 = m_objValue.m_dtmRUPTURETIME_DAT.ToString("yyyy年MM月dd日 hh:mm");
                    }
                    else if (m_objValue.m_strRUPTUREDFETALMEMBRANES_CHR == "01")
                    {
                        m_strTemp = " 未破";
                        m_strTemp2 = "";
                        m_strTemp3 = "";
                    }
                    else
                    {
                        m_strTemp = "";
                        m_strTemp2 = "";
                        m_strTemp3 = "";
                    }
                    m_mthMakeText(new string[] { "\n2.胎膜：", "破膜：", "破膜时间：" }, new string[] { m_strTemp, m_strTemp2, m_strTemp3 }, new string[] { "", "", "" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeText(new string[] { "\n  羊水量：$$", "ml； $$", "性状：", " FHR：", "次/分$$" },
                                  new string[] { m_objValue.m_strAMNIOTICFLUID_VCHR, "", m_objValue.m_strAMNIOTICFLUIDCHARACTER_VCHR, m_objValue.m_strFHR_VCHR, "" },
                                  new string[] { m_objValue.m_strAMNIOTICFLUID_XML, "", m_objValue.m_strAMNIOTICFLUIDCHARACTER_XML, m_objValue.m_strFHR_XML, "" },
                                  ref m_strAllText, ref m_strAllXml);

                    m_strTemp = "";
                    m_strTemp2 = "";
                    m_strTemp3 = "";

                    if (m_objValue.m_strCOCCYX_CHR == "100")
                        m_strTemp = " 低";
                    else if (m_objValue.m_strCOCCYX_CHR == "010")
                        m_strTemp = " 中";
                    else if (m_objValue.m_strCOCCYX_CHR == "001")
                        m_strTemp = " 高";

                    if (m_objValue.m_strURETHRALCATHETERIZATION_CHR == "10")
                        m_strTemp2 = " 无";
                    else if (m_objValue.m_strURETHRALCATHETERIZATION_CHR == "01")
                        m_strTemp2 = " 有";
                    m_mthMakeText(new string[] { "\n3.骨盆:坐骨棘：", "尾骨弧度：", "骶骨活动度：", " 耻骨弓：", "度$$", "\n  DC径：", "cm；$$", "坐骨切迹：", " 导尿：", "（$$", "   ml 性状：$$", "）" },
                                  new string[] { m_objValue.m_strISCHIALSPINE_VCHR, m_strTemp, m_objValue.m_strSACRALBONE_VCHR, m_objValue.m_strPUBICARCH_VCHR, "", m_objValue.m_strDC_VCHR, "", m_objValue.m_strISCHIUMNOTCH_VCHR, m_strTemp2, m_objValue.m_strPISS_VCHR, m_objValue.m_strUCCHARACTER_VCHR, "" },
                                  new string[] { m_objValue.m_strISCHIALSPINE_XML, "", m_objValue.m_strSACRALBONE_XML, m_objValue.m_strPUBICARCH_XML, "", m_objValue.m_strDC_XML, "", m_objValue.m_strISCHIUMNOTCH_XML, "", m_objValue.m_strPISS_XML, m_objValue.m_strUCCHARACTER_XML, "" },
                                  ref m_strAllText, ref m_strAllXml);

                    m_mthMakeText(new string[] { "\n处理计划：" }, new string[] { m_objValue.m_strPROJECT_VCHR }, new string[] { m_objValue.m_strPROJECT_XML }, ref m_strAllText, ref m_strAllXml);
                                        
                    this.m_blnIsFirstPrint = false;
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strAllText, m_strAllXml, m_objPrintInfo.m_dtmFirstPrintDate);
                //m_mthAddSign2("检查者：", m_objPrintContext.m_ObjModifyUserArr);

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    int m_intRealHeight;
                    Rectangle m_printRtg = new Rectangle(base.m_intPatientInfoX + 30, p_intPosY, (int)enmRectangleInfoEMR_VaginalExaminationRecord.PrintWidth2, 30);
                    this.m_objPrintContext.m_blnPrintAllBySimSun(12, m_printRtg, p_objGrp, out m_intRealHeight,false);  //  .m_mthPrintLine((int)enmRectangleInfoEMR_VaginalExaminationRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    if (m_intRealHeight > 30)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 30;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }

        private class clsEMR_VaginalExaminationRecordSign : clsEMR_VaginalExaminationRecordInfo
        {
            /// <summary>
            /// 是否第一次打印该类中的内容
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    string m_strSign = "检查者：";
                    p_objGrp.DrawString(m_strSign, m_fotSign, Brushes.Black, (float)(enmRectangleInfoEMR_VaginalExaminationRecord.LeftX + 400), (float)p_intPosY);
                    if(m_objPrintInfo.m_objRecordContent.objSignerArr != null && m_objPrintInfo.m_objRecordContent.objSignerArr.Length > 0)
                    {
                        clsEmrSigns_VO[] m_objSignArr = m_objPrintInfo.m_objRecordContent.objSignerArr;
                        m_strSign = "";
                        for (int i = 0; i < m_objSignArr.Length; i++)
                        {
                            if (i < m_objSignArr.Length - 1)
                            {
                                m_strSign += m_objSignArr[i].objEmployee.ToString() + "，\n";
                            }
                            else
                            {
                                m_strSign += m_objSignArr[i].objEmployee.ToString();
                            }
                        }
                        p_objGrp.DrawString(m_strSign, m_fotSign, Brushes.Black, (float)(enmRectangleInfoEMR_VaginalExaminationRecord.LeftX + 450), (float)p_intPosY);
                    } 
                    m_blnIsFirstPrint = false;
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        #endregion PrintClasses

        #region infPrintRecord 成员

        /// <summary>
        /// 初始化打印所用到的病人信息
        /// </summary>
        /// <param name="p_objPatient"></param>
        /// <param name="p_dtmInPatientDate"></param>
        /// <param name="p_dtmOpenDate"></param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            this.m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            this.m_objPrintInfo = new clsPrintInfo_EMR_VaginalExaminationRecord();
            this.m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            this.m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            this.m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            this.m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            this.m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            this.m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            this.m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            this.m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            this.m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            this.m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            this.m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            this.m_objPrintInfo.m_strRegisterId = p_objPatient.m_StrRegisterId;
        }
        /// <summary>
        /// 打印 1 初始化打印内容
        /// 打印从数据库读取得内容
        /// </summary>
        public void m_mthInitPrintContent()
        {
            this.m_blnWantInit = false;
            if (this.m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("在执行m_mthInitPrintContent之前请先执行m_mthSetPrintInfo函数");
                return;
            }

            clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_VaginalExamination);

            //if (!string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID) && this.m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue)
            if (!string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID))
            {
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                //从数据库读取打印所需数据
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(this.m_objPrintInfo.m_strInPatentID, this.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), this.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);

                if (lngRes <= 0)
                    return;
                this.m_objPrintInfo.m_objRecordContent = objContent as clsEMR_VaginalExaminationValue;
            }
            //m_objRecordsDomain = null;
            //设置表单内容到打印中			
            this.m_mthSetPrintContent(this.m_objPrintInfo.m_objRecordContent, this.m_objPrintInfo.m_dtmFirstPrintDate);
        }
        /// <summary>
        /// 设置打印内容
        /// </summary>
        /// <param name="p_objContent"></param>
        /// <param name="p_dtmFirstPrintDate"></param>
        private void m_mthSetPrintContent(clsEMR_VaginalExaminationValue p_objContent, DateTime p_dtmFirstPrintDate)
        {
            this.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext
                (
                    new com.digitalwave.Utility.Controls.clsPrintLineBase[]
                    {
                       new clsEMR_VaginalExaminationRecordFixInfo(),
                       new clsEMR_VaginalExaminationRecordMain(),
                       new clsEMR_VaginalExaminationRecordSign()
                    }
                );
            this.m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
            //设置打印信息，就是Set Value进去

            this.m_objPrintLineContext.m_ObjPrintLineInfo = this.m_objPrintInfo;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
            this.m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
        }
        /// <summary>
        /// 打印 2 初始化打印内容
        /// 打印不需要从数据库读取且已存在的数据，与“打印 1” 的过程不同时执行
        /// </summary>
        /// <param name="p_objPrintContent"></param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            //this.m_blnWantInit = false;
            //if (p_objPrintContent.GetType().Name != "clsPrintInfo_EMR_CesareanRecord")
            //{
            //    MDIParent.ShowInformationMessageBox("参数错误");
            //}
            //m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            //this.m_objPrintInfo.m_objRecordContent = (clsPrintInfo_EMR_CesareanRecord)p_objPrintContent;

            //m_mthSetPrintContent(m_objPrintInfo.m_objRecordContent, m_objPrintInfo.m_dtmFirstPrintDate);
        }
        /// <summary>
        /// 获取该打印对象实例的打印内容
        /// </summary>
        /// <returns></returns>
        public object m_objGetPrintInfo()
        {
            if (this.m_blnIsFromDataSource)
            {
                if (this.m_objPrintInfo == null)
                {
                    MDIParent.ShowInformationMessageBox("打印尚未初始化，请先执行m_mthSetPrintInfo函数。");
                    return null;
                }

                if (this.m_blnWantInit)
                    this.m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (this.m_objPrintInfo.m_objRecordContent == null)
                return null;
            else
                return this.m_objPrintInfo;
        }
        /// <summary>
        /// 初始化打印工具类的一些属性，如：打印过程中所使用的字体、画刷等
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            //this.m_objPageSetting = new clsPrintPageSettingForRecord();
        }
        /// <summary>
        /// 垃圾回收
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthDisposePrintTools(object p_objArg)
        {
        }
        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            //m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            this.m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }
        /// <summary>
        /// 结束打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            this.m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (!this.m_blnIsFromDataSource || string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID))
                return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && this.m_objPrintInfo.m_blnIsFirstPrint)
            {
                clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_VaginalExamination);
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(this.m_objPrintInfo.m_strInPatentID,
                                                                    this.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                                                    this.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                                                    this.m_objPrintInfo.m_dtmFirstPrintDate);
            }
        }

        #endregion

        #region 打印方法
        /// <summary>
        /// 打印内容
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            //可在此添加打印标头页尾的代码
            //逐行打印
            while (this.m_objPrintLineContext.m_BlnHaveMoreLine)
            {
                //换页打印，条件：还有打印行，但该页已打满
                // p_objPrintPageArg.MarginBounds.Height PageBounds
                if ((this.m_intYPos > (p_objPrintPageArg.PageBounds.Height - 150)) && this.m_objPrintLineContext.m_BlnHaveMoreLine)
                {
                    this.m_mthPrintFoot(p_objPrintPageArg);
                    p_objPrintPageArg.HasMorePages = true;
                    this.m_intYPos = 130;//155;
                    this.m_intCurrentPage++;
                    return;
                }
                //打印行
                Pen newPen = new Pen(Brushes.Black);
                newPen.Width = 2;
                //打印边框
                //p_objPrintPageArg.Graphics.DrawRectangle(newPen, 50, 129, p_objPrintPageArg.PageBounds.Right - 50, p_objPrintPageArg.PageBounds.Bottom - 100);
                this.m_objPrintLineContext.m_mthPrintNextLine(ref this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_VaginalExaminationRecordPrintTool.m_fotContent);
            }
            //打印签名
            this.m_intYPos += 20;
            while (this.m_objPrintLineContext.m_BlnHaveMoreSign)
            {
                this.m_objPrintLineContext.m_mthPrintNextSign(70 + 10, this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_VaginalExaminationRecordPrintTool.m_fotSign);
                m_intYPos += 20;
            }

            //打印页脚，至此该文档全部打完	
            this.m_mthPrintFoot(p_objPrintPageArg);
        }
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            e.Graphics.DrawString("第      页", clsEMR_VaginalExaminationRecordPrintTool.m_fotFooter, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 70);
            e.Graphics.DrawString(this.m_intCurrentPage.ToString(), clsEMR_VaginalExaminationRecordPrintTool.m_fotFooter, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 70);
        }
        /// <summary>
        /// 重置参数
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            this.m_objPrintLineContext.m_mthReset();
            this.m_intYPos = 155;
            this.m_intCurrentPage = 1;
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            GC.Collect();//强制执行垃圾回收
        }

        #endregion
    }
}
