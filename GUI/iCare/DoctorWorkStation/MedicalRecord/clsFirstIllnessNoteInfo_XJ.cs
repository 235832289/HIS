using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 首次病程记录信息---新疆
    /// </summary>
    public class clsFirstIllnessNoteInfo_XJ : clsDiseaseTrackInfo
    {
        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsFirstIllnessNoteRecordContent_XJ objContent = ((clsFirstIllnessNoteRecordContent_XJ)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote_XJ")) + "   " + "首次病程记录";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);

            //strText += "\n" + objContent.m_strMostlyContent;
            strText += "\n(一)病例特点:\n" + objContent.m_strBingLiTeDian;
            //if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
                strText += "\n(二)中医辩病辨证依据:\n" + objContent.m_strZhongYiBianBing;
           // else
                strText += "\n(三)西医诊断依据:\n" + objContent.m_strXiYiZhenDuanYiJu;
            strText += "\n(四)中医鉴别诊断:\n" + objContent.m_strZhongYiJianBie;
            strText += "\n(五)西医鉴别诊断:\n" + objContent.m_strXiYiJianBie;
            strText += "\n(六)中医初步诊断:\n" + objContent.m_strZhongYiChuBu;
            strText += "\n(七)西医初步诊断:\n" + objContent.m_strXiYiChuBu;
            strText += "\n(八)诊疗计划:\n" + objContent.m_strZhenLiaoJiHua;

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

            clsFirstIllnessNoteRecordContent_XJ objContent = ((clsFirstIllnessNoteRecordContent_XJ)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote")) + "   " + "首次病程记录";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);

            string strCreateUserName = m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
           // string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(一)病例特点:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(二)诊断与鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
           // string strXML5 = "";
           // if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(二)中医辩病辨证依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
          //  else 
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(三)西医诊断依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(四)中医鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(五)西医鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(六)中医初步诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML9 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(七)西医初步诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML10 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(八)诊疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML3, objContent.m_strBingLiTeDianXML, strXML4, objContent.m_strZhongYiBianBingXML, strXML5, objContent.m_strXiYiZhenDuanYiJuXML, strXML6, objContent.m_strZhongYiJianBieXML, strXML7, objContent.m_strXiYiJianBieXML, strXML8, objContent.m_strZhongYiChuBuXML, strXML9, objContent.m_strXiYiChuBuXML, strXML10, objContent.m_strZhenLiaoJiHuaXML });
            return strXML;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.FirstIllnessNote_XJ;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignText()
        {
            if (m_objRecordContent == null)
                return "";
            //获取签名
            string strSigns = "";
            bool blnFirst = false;
            if (m_objRecordContent.objSignerArr != null)
            {
                for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
                {
                    if (m_objRecordContent.objSignerArr[i].controlName == "lsvSign")
                    {
                        //名称
                        if (!blnFirst)
                        {
                            strSigns = m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                            blnFirst = true;
                        }
                        else
                            strSigns = strSigns + "、" + m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
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
