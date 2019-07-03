using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 接班记录信息--新疆
    /// </summary>
    public class clsHandOverInfo_XJ : clsDiseaseTrackInfo
    {
        clsPatient m_objCurrentPatient = null;
        public clsHandOverInfo_XJ(clsPatient p_objPatient)
        {
            m_objCurrentPatient = p_objPatient;
        }
        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsHandOverRecordContent_XJ objContent = ((clsHandOverRecordContent_XJ)m_objRecordContent);
            string strText = m_strGetHeaderText();

            strText += "\n入院情况:\n" + objContent.m_strRuYuanQingKuang;
            strText += "\n中医入院诊断:\n" + objContent.m_strZhongYiRuYuan;
            strText += "\n西医入院诊断:\n" + objContent.m_strXiYiRuYuan;
            strText += "\n诊疗经过:\n" + objContent.m_strZhenLiaoJingGuo;
            strText += "\n目前情况:\n" + objContent.m_strMuQianQingKuang;

            strText += "\n中医目前诊断:\n" + objContent.m_strZhongYiMuQian;
            strText += "\n西医目前诊断:\n" + objContent.m_strXiYiMuQian;
            strText += "\n诊疗计划:\n" + objContent.m_strZhenLiaoJiHua;

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

            clsHandOverRecordContent_XJ objContent = ((clsHandOverRecordContent_XJ)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = m_strGetSignText(); 

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n入院情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n中医入院诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n西医入院诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊疗经过:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n目前情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n中医目前诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n西医目前诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML9 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strRuYuanQingKuangXML, strXML3, objContent.m_strZhongYiRuYuanXML, strXML4, objContent.m_strXiYiRuYuanXML, strXML5, objContent.m_strZhenLiaoJingGuoXML, strXML6, objContent.m_strMuQianQingKuangXML, strXML7, objContent.m_strZhongYiMuQianXML, strXML8, objContent.m_strXiYiMuQianXML, strXML9, objContent.m_strZhenLiaoJiHuaXML });
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

            clsHandOverRecordContent_XJ objContent = ((clsHandOverRecordContent_XJ)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmHandOver_XJ")) + "   " + "接班记录\n";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);

            string strInHospitalReason = "";
            #region 入院原因(主诉)
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(objContent.m_strInPatientID, objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
            {
                strInHospitalReason = objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
            }
            #endregion 入院原因(主诉)

            string strLastChar = "";
            if (strInHospitalReason != null && strInHospitalReason.Length > 0)
                strLastChar = strInHospitalReason.Substring(strInHospitalReason.Length - 1, 1);
            if (strLastChar == "." || strLastChar == "," || strLastChar == "，" || strLastChar == "。")//去掉最后的标点
                strInHospitalReason = strInHospitalReason.Substring(0, strInHospitalReason.Length - 1);
            if (strInHospitalReason != null && strInHospitalReason.Trim() != "")
                strInHospitalReason = "因" + strInHospitalReason + "，";
            strText += strInHospitalReason + (m_objCurrentPatient == null ? "" : (m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日") + "入院。"));
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.HandOver_XJ;
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

    }// END CLASS DEFINITION clsHandOverInfo

}