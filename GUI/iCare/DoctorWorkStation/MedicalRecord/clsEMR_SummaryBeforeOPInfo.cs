using System;
using System.Collections.Generic;
using System.Text;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 术前小结信息
    /// </summary>
    public class clsEMR_SummaryBeforeOPInfo : clsDiseaseTrackInfo
    {
        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsEMR_SummaryBeforeOPValue objContent = ((clsEMR_SummaryBeforeOPValue)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmRECORDDATE.ToString("yyyy年MM月dd日") + "   " + "术前小结";
            
            strText += "\n病情摘要:\n" + objContent.m_strDISEASESUMMARY;
            strText += "\n术前诊断:\n" + objContent.m_strDIAGNOSISBEFOREOP;
            strText += "\n诊断依据:\n" + objContent.m_strDIAGNOSISGIST;
            strText += "\n手术指征:\n" + objContent.m_strOPINDICATION;
            strText += "\n手术方式:\n" + objContent.m_strOPMODE;
            strText += "\n麻醉方式:\n" + objContent.m_strANAMODE;
            strText += "\n注意事项(术前、术中、术后):\n" + objContent.m_strPROCEEDING;
            strText += "\n术前准备:\n" + objContent.m_strPREPAREBEFOREOP;

            return strText;
        }

        /// <summary>
        /// 特殊记录内容格式Xml的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackXml()
        {
            if (m_objRecordContent == null)
                return "";

            clsEMR_SummaryBeforeOPValue objContent = ((clsEMR_SummaryBeforeOPValue)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmRECORDDATE.ToString("yyyy年MM月dd日") + "   " + "术前小结";
            string strCreateUserName = m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n病情摘要:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White );
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n术前诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊断依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n手术指征:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n手术方式:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n麻醉方式:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n注意事项(术前、术中、术后):\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML9 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n术前准备:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strDISEASESUMMARYXML, strXML3, objContent.m_strDIAGNOSISBEFOREOPXML, 
                strXML4, objContent.m_strDIAGNOSISGISTXML, strXML5, objContent.m_strOPINDICATIONXML, strXML6, objContent.m_strOPMODEXML, strXML7,objContent.m_strANAMODEXML,
                strXML8,objContent.m_strPROCEEDINGXML,strXML9,objContent.m_strPREPAREBEFOREOPXML});
            return strXML;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.EMR_SummaryBeforeOP;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignText()
        {
            if (m_objRecordContent == null)
                return "";
            string strSigns = "";
            //显示签名者
            if (m_objRecordContent.objSignerArr != null)
            {
                for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
                {
                    if (m_objRecordContent.objSignerArr[i].controlName == "lsvSign")
                    {
                        //名称
                        strSigns = strSigns + " " + m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                    }
                }
            }

            return strSigns;

        }

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
    }
}
