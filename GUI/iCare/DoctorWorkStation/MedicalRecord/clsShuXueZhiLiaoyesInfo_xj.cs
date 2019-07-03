using System;
using iCareData;
using System.Collections;
using System.Text;
using com.digitalwave.controls;
namespace iCare
{
    /// <summary>
    /// 输血治疗同意书----新疆 
    /// </summary>

    public class clsShuXueZhiLiaoyesInfo_xj : clsDiseaseTrackInfo
    {
        private const string c_strSplitText = "医生：";

        private const int c_intWhiteSpaceCount = 14;

        private const string c_strInsertTextWithEnter = "\n　　　              ";
        private const string c_strInsertText = "　　　              ";

        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsShuXueZhiLiaoyesContent_xj objContent = ((clsShuXueZhiLiaoyesContent_xj)m_objRecordContent);
            string strText = m_strGetHeaderText();

            // strText += "\n    死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分");
            strText += "\n    时间:" + objContent.m_dtmDoctorDate.ToString("yyyy年MM月dd日HH时mm分");
            strText += "\n　　输血目的:" + objContent.m_strShuXueMuDi;
            strText += "\n　　医师签字:" + objContent.m_strRecordName;
            //strText += "\n　　手术者:" + m_strGetName(objContent.m_strAttendeeNameArr);
            strText += "\n    输血成分:" + objContent.m_strShuXueChengFen;
            strText += "\n    临床诊断:" + objContent.m_strZhenDuan;
            //strText += "\n    记录者:" + objContent.m_strRecorderName;
            //strText += "\n    主持人审阅签名:" + objContent.m_strCompereName;
            return strText;
        }

        private string m_strGetName(string[] p_strNameArr)
        {
            string strName = "";
            if (p_strNameArr != null)
                for (int i = 0; i < p_strNameArr.Length; i++)
                {
                    if (i == 0)
                        strName += p_strNameArr[i].Trim();
                    else
                        strName += "、" + p_strNameArr[i].Trim();
                }
            return strName;
        }

        /// <summary>
        /// 特殊记录内容格式Xml的获取
        /// </summary>
        public override string m_strGetTrackXml()
        {
            if (m_objRecordContent == null)
                return "";

            clsShuXueZhiLiaoyesContent_xj objContent = ((clsShuXueZhiLiaoyesContent_xj)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            // string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    时间:" + objContent.m_dtmDoctorDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    输血目的:" + objContent.m_strShuXueMuDi, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　医师签字:" + objContent.m_strRecordName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
         //   string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　手术者:" + m_strGetName(objContent.m_strAttendeeNameArr), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　输血成分:" + objContent.m_strShuXueChengFen, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   临床诊断:" + objContent.m_strZhenDuan, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //  string strXML14 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   主持人审阅签名:" + objContent.m_strCompereName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.s_strCombineXml(new string[] { strXML1, strXML2, strXML3, objContent.m_strShuXueMuDiXML, strXML4, strXML5, objContent.m_strShuXueChengFenXML, strXML6, objContent.m_strZhenDuanXML });
            return strXML;
        }

        /// <summary>
        /// 提取表头基本信息
        /// </summary>
        /// <returns></returns>
        private string m_strGetHeaderText()
        {
            if (m_objRecordContent == null)
                return "";

            clsShuXueZhiLiaoyesContent_xj objContent = ((clsShuXueZhiLiaoyesContent_xj)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmShuXueZhiLiaoyes_xj")) + "   " + "输血治疗同意书";
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.ShuXueZhiLiaoyes_xj;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        //		public override string m_strGetSignText()
        //		{
        //			if(m_objRecordContent==null)
        //				return "";
        //			clsDeadCaseDiscussRecord_VO objContent=((clsDeadCaseDiscussRecord_VO)m_objRecordContent);
        //			return m_strGetName(objContent.m_strAttendeeNameArr);
        //			
        //		}

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignXml()
        {
            if (m_objRecordContent == null)
                return "";

            return "<Root />";
        }

        public void m_mthGetFormatTrackInfo(int p_intCharPerLine, out string p_strText, out string p_strXml)
        {
            m_mthGetFormatTrackInfo(p_intCharPerLine, false, DateTime.Now, out p_strText, out p_strXml);
        }

        public void m_mthGetFormatTrackInfo(int p_intCharPerLine, bool p_blnIsPrintCall, DateTime p_dtmSeperateTime, out string p_strText, out string p_strXml)
        {
            p_strText = "";
            p_strXml = "";

            if (m_objRecordContent == null)
                return;

            string strHeaderText = m_strGetHeaderText();

            clsShuXueZhiLiaoyesContent_xj objContent = ((clsShuXueZhiLiaoyesContent_xj)m_objRecordContent);
            p_strText = strHeaderText;


            //   p_strText += "\n    死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分");
            //p_strText += "\n    讨论时间:" + objContent.m_dtmDiscussDate.ToString("yyyy年MM月dd日HH时mm分");
            //p_strText += "\n　　讨论地点:" + objContent.m_strDiscussAddress;
            //p_strText += "\n　　主持人:" + objContent.m_strCompereName;
            //p_strText += "\n　　参加人员:" + m_strGetName(objContent.m_strAttendeeNameArr);

            p_strText += "\n    时间:" + objContent.m_dtmDoctorDate.ToString("yyyy年MM月dd日HH时mm分");
            p_strText += "\n　　输血目的:" + objContent.m_strShuXueMuDi;
            p_strText += "\n　　医师签字:" + objContent.m_strRecordName;
            //p_strText += "\n　　手术者:" + m_strGetName(objContent.m_strAttendeeNameArr);


            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            //string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strHeaderText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    讨论时间:" + objContent.m_dtmDiscussDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    讨论地点:" + objContent.m_strDiscussAddress, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　主持人:" + objContent.m_strCompereName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　参加人员:" + m_strGetName(objContent.m_strAttendeeNameArr), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　入院诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　发言记录:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML9 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　结论:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML10 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　 死亡诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML11 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　 死亡原因:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML12 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　 经验教训:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML13 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   记录者:" + objContent.m_strRecorderName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML14 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   主持人审阅签名:" + objContent.m_strCompereName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strHeaderText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            // string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    时间:" + objContent.m_dtmDoctorDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    输血目的:" + objContent.m_strShuXueMuDi, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　医师签字:" + objContent.m_strRecordName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
           // string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　手术者:" + m_strGetName(objContent.m_strAttendeeNameArr), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　 输血成分:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   临床诊断:" + objContent.m_strZhenDuan, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //  string strXML14 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n   主持人审阅签名:" + objContent.m_strCompereName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            ArrayList arlXml = new ArrayList();
            arlXml.AddRange(new string[] { strXML1, strXML2, strXML3, objContent.m_strShuXueMuDiXML, strXML4, strXML5, objContent.m_strShuXueChengFenXML, strXML6, objContent.m_strZhenDuanXML });

            //p_strText += "\n　　入院诊断:" + objContent.m_strInHospitalDiagnose;
            //p_strText += "\n    发言记录:" + objContent.m_strSpeakRecord;
            //p_strText += "\n    结论:" + objContent.m_strVerdict;
            //p_strText += "\n    死亡诊断:" + objContent.m_strDeadDiagnose;
            //p_strText += "\n    死亡原因:" + objContent.m_strDeadReason;
            //p_strText += "\n    经验教训:" + objContent.m_strExperience;
            //p_strText += "\n    记录者:" + objContent.m_strRecorderName;
            //p_strText += "\n    主持人审阅签名:" + objContent.m_strCompereName;


            //p_strText += "\n　　病史汇报:" + objContent.m_strHuiBao;
            //p_strText += "\n    讨论意见:" + objContent.m_strTaoLunYiJian;
            //p_strText += "\n    讨论小结:" + objContent.m_strTaoLunXiaoJie;
            //p_strText += "\n    科主任:" + objContent.m_strZhuRenName;
            //p_strText += "\n    管床医师:" + objContent.m_strGuanChuangName;
            //p_strText += "\n    记录者:" + objContent.m_strRecordName;

            //arlXml.AddRange(new string[]{strXML7,objContent.m_strHuiBaoXML,strXML8,objContent.m_strTaoLunYiJianXML,strXML9,objContent.m_strTaoLunXiaoJieXML,
            //                                                        strXML10,strXML11,strXML12 });

            p_strXml = ctlRichTextBox.s_strCombineXml((string[])arlXml.ToArray(typeof(string)));

        }

        private string m_strFormatText(string p_strText, string p_strOldXml, int p_intCharPerLine, ArrayList p_arlXml)
        {
            string strTemp = p_strText.Replace("医生:", "医生：");

            int intStarIndex = 0;

            int intPreDocIndex = strTemp.IndexOf(c_strSplitText, intStarIndex);

            if (intPreDocIndex < 0)
            {
                p_arlXml.Add(p_strOldXml);
                return p_strText;
            }

            int intPreRetIndex = strTemp.LastIndexOf('\n', intPreDocIndex);

            intStarIndex = intPreDocIndex + 3;

            ArrayList arlInsertIndex = new ArrayList();

            while (true)
            {
                int intDocIndex = strTemp.IndexOf(c_strSplitText, intStarIndex);

                if (intDocIndex >= 0)
                {
                    int intRetIndex = strTemp.LastIndexOf('\n', intDocIndex);

                    if (intRetIndex == -1)
                        intRetIndex = 0;

                    m_mthGetFormat(arlInsertIndex, p_strText, c_intWhiteSpaceCount, p_intCharPerLine, intStarIndex, intPreDocIndex, intPreRetIndex, intRetIndex);

                    intPreDocIndex = intDocIndex;
                    intPreRetIndex = intRetIndex;

                    intStarIndex = intPreDocIndex + 3;
                }
                else
                {
                    m_mthGetFormat(arlInsertIndex, p_strText, c_intWhiteSpaceCount, p_intCharPerLine, intStarIndex, intPreDocIndex, intPreRetIndex, -1);

                    break;
                }
            }

            return m_strFormat(arlInsertIndex, p_strText, p_strOldXml, c_intWhiteSpaceCount, p_arlXml);
        }

        private void m_mthGetFormat(ArrayList p_arlFormatInfo, string p_strText, int p_intWhiteSpaceCount, int p_intCharPerLine, int p_intStartIndex, int p_intPreDocIndex, int p_intPreRetIndex, int p_intRetIndex)
        {
            int intDocDescLength = p_intPreDocIndex + 3 - (p_intPreRetIndex + 1);
            int intTempWhiteSpace = p_intWhiteSpaceCount;

            for (int i = 0; i < intDocDescLength; i++)
            {
                if ((int)p_strText[i + p_intPreRetIndex + 1] < 255)
                    intTempWhiteSpace--;
                else
                    intTempWhiteSpace -= 2;
            }

            p_arlFormatInfo.Add(p_intPreRetIndex + 1 + 20000000 + intTempWhiteSpace * 10000);

            int intTextLength = 0;
            if (p_intRetIndex >= 0)
            {
                intTextLength = p_intRetIndex - p_intStartIndex + 1;
            }
            else
            {
                intTextLength = p_strText.Length - p_intStartIndex;
            }

            int intCountTemp = 0;

            for (int i = 0; i < intTextLength; i++)
            {
                if (p_strText[i + p_intStartIndex] != '\n')
                {
                    intCountTemp++;

                    if (intCountTemp == p_intCharPerLine)
                    {
                        p_arlFormatInfo.Add(p_intStartIndex + i + 1);
                        intCountTemp = 0;
                    }
                }
                else if (i != intTextLength - 1)
                {
                    p_arlFormatInfo.Add(p_intStartIndex + i + 1 + 10000);
                    intCountTemp = 0;
                }
            }
        }

        private string m_strFormat(ArrayList p_arlFormatInfo, string p_strText, string p_strOldXml, int p_intWhiteSpaceCount, ArrayList p_arlXml)
        {
            clsShuXueZhiLiaoyesContent_xj objContent = ((clsShuXueZhiLiaoyesContent_xj)m_objRecordContent);
            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strInsertTextWithEnterXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(c_strInsertTextWithEnter, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strInsertTextXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(c_strInsertText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            ctlRichTextBox.clsUserXMLInfo objUserXmlInfo = ctlRichTextBox.s_objGetUserXMLInfo(p_strOldXml);

            StringBuilder sbValue = new StringBuilder();
            int intPreIndex = 0;

            for (int i = 0; i < p_arlFormatInfo.Count; i++)
            {
                int intIndex = (int)p_arlFormatInfo[i];

                if (intIndex < 10000)
                {
                    sbValue.Append(p_strText.Substring(intPreIndex, intIndex - intPreIndex));
                    sbValue.Append(c_strInsertTextWithEnter);

                    p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo, intPreIndex, intIndex - 1));
                    p_arlXml.Add(strInsertTextWithEnterXml);

                    intPreIndex = intIndex;
                }
                else if (intIndex < 20000000)
                {
                    intIndex %= 10000;

                    sbValue.Append(p_strText.Substring(intPreIndex, intIndex - intPreIndex));
                    sbValue.Append(c_strInsertText);

                    p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo, intPreIndex, intIndex - 1));
                    p_arlXml.Add(strInsertTextXml);

                    intPreIndex = intIndex;
                }
                else
                {
                    intIndex %= 20000000;
                    int intWhiteCount = intIndex / 10000;
                    intIndex %= 10000;

                    string strWhiteSpace = "　　　";
                    for (int j2 = 0; j2 < intWhiteCount; j2++)
                    {
                        strWhiteSpace += " ";
                    }
                    string strWhiteSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strWhiteSpace, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

                    if (intIndex > 0)
                    {
                        sbValue.Append(p_strText.Substring(intPreIndex, intIndex - intPreIndex));
                        sbValue.Append(strWhiteSpace);

                        p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo, intPreIndex, intIndex - 1));
                        p_arlXml.Add(strWhiteSpaceXml);

                        intPreIndex = intIndex;
                    }
                    else if (intIndex == 0)
                    {
                        sbValue.Append(strWhiteSpace);
                        p_arlXml.Add(strWhiteSpaceXml);

                    }
                }
            }

            sbValue.Append(p_strText.Substring(intPreIndex));

            p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo, intPreIndex, p_strText.Length - 1));

            return sbValue.ToString();
        }

    }

}
