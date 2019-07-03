using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 转出记录信息。
    /// </summary>
    public class clsConveyInfo : clsDiseaseTrackInfo
    {
        clsPatient m_objCurrentPatient = null;
        public clsConveyInfo(clsPatient p_objPatient)
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

            clsConveyRecordContent objContent = ((clsConveyRecordContent)m_objRecordContent);
            string strText = m_strGetHeaderText();

            strText += "\n初步诊断:\n" + objContent.m_strOriginalDiagnose;
            strText += "\n转出诊断:\n" + objContent.m_strConveyDiagnose;
            strText += "\n病史简介:\n" + objContent.m_strCaseHistory;
            strText += "\n会诊情况:\n" + objContent.m_strConsultation;
            strText += "\n转出原因:\n" + objContent.m_strConveyReason;
            strText += "\n提请接收科室注意事项:\n" + objContent.m_strNotice;

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

            clsConveyRecordContent objContent = ((clsConveyRecordContent)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n初步诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n转出诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n病史简介:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n会诊情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n转出原因:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n提请接收科室注意事项:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strOriginalDiagnoseXML, strXML3, objContent.m_strConveyDiagnoseXML, strXML4, objContent.m_strCaseHistoryXML, strXML5, objContent.m_strConsultationXML, strXML6, objContent.m_strConveyReasonXML, strXML7, objContent.m_strNoticeXML });
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

            clsConveyRecordContent objContent = ((clsConveyRecordContent)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmConvey")) + "   " + "转出记录\n";
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
            TimeSpan ts = objContent.m_dtmCreateDate - m_objCurrentPatient.m_DtmSelectedHISInDate;

            strText += strInHospitalReason + m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日") + "入院.现住院第" + (ts.Days + 1).ToString() + "天。";
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.Convey;
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

    }// END CLASS DEFINITION clsConveyInfo

}
