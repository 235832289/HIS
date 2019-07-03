using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
    /// <summary>
    /// 死亡记录信息。
    /// </summary>
    public class clsDeadRecordInfo : clsDiseaseTrackInfo
    {
        clsPatient m_objCurrentPatient = null;
        public clsDeadRecordInfo(clsPatient p_objPatient)
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

            clsDeadRecordContent objContent = ((clsDeadRecordContent)m_objRecordContent);
            string strText = m_strGetHeaderText();

            strText += "\n死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分");
            strText += "\n入院情况:" + objContent.m_strInHospitalCase;
            strText += "\n初步诊断:" + objContent.m_strOriginalDiagnose;
            strText += "\n诊治经过:" + objContent.m_strDiagnoseBy;
            strText += "\n死亡疾病诊断:" + objContent.m_strDeadDiagnose;
            strText += "\n死亡原因:" + objContent.m_strDeadReason;
            strText += "\n经验教训:" + objContent.m_strExperience;

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

            clsDeadRecordContent objContent = ((clsDeadRecordContent)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n入院情况:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n初步诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊治经过:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n死亡疾病诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n死亡原因:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n经验教训:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, strXML3, objContent.m_strInHospitalCaseXML, strXML4, objContent.m_strOriginalDiagnoseXML, strXML5, objContent.m_strDiagnoseByXML, strXML6, objContent.m_strDeadDiagnoseXML, strXML7, objContent.m_strDeadReasonXML, strXML8, objContent.m_strExperienceXML });
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

            clsDeadRecordContent objContent = ((clsDeadRecordContent)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmDeadRecord")) + "   " + "死亡记录\n";
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
            if (strInHospitalReason != "")
                strInHospitalReason = "因" + strInHospitalReason + "，";
            TimeSpan ts = objContent.m_dtmDeadDate - m_objCurrentPatient.m_DtmSelectedHISInDate;

            strText += strInHospitalReason + (m_objCurrentPatient == null ? "" : (m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日") + "入院")) + "," + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分") + "死亡，共住院" + (ts.Days + 1).ToString() + "天。";
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.Dead;
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

    }// END CLASS DEFINITION clsDeadInfo	

    /// <summary>
    /// 死亡记录信息(新加)
    /// </summary>
    public class clsDeathRecordInfo : clsDiseaseTrackInfo
    {

        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsDeadRecord_VO objContent = ((clsDeadRecord_VO)m_objRecordContent);
            string strText = m_strGetHeaderText();

            strText += "\n    心电图号:" + objContent.m_strCardiogramID;
            strText += "\n    X光号:" + objContent.m_strXRayID;
            strText += "\n    超声波号:" + objContent.m_strUltrasonicID;
            strText += "\n    MRI号:" + objContent.m_strMRIID;
            strText += "\n    脑电波号:" + objContent.m_strBrainWaveID;
            strText += "\n　　死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分");
            strText += "\n    手术名称:" + objContent.m_strOperationName;
            strText += "\n    手术日期:" + objContent.m_dtmOperationDate.ToString("yyyy年MM月dd日");
            strText += "\n　　入院诊断:" + objContent.m_strInHospitalDiagnose;
            strText += "\n　　住院经过:" + objContent.m_strInHospitalProcess;
            strText += "\n　　死亡经过:" + objContent.m_strDeadProcess;
            strText += "\n　　死后诊断:" + objContent.m_strDeadDiagnose;
            strText += "\n　　死亡讨论结论:" + objContent.m_strDeadVerdict;

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

            clsDeadRecord_VO objContent = ((clsDeadRecord_VO)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    心电图号:" + objContent.m_strCardiogramID, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    X光号:" + objContent.m_strXRayID, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    超声波号:" + objContent.m_strUltrasonicID, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    MRI号:" + objContent.m_strMRIID, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    脑电波号:" + objContent.m_strBrainWaveID, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　死亡时间:" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　手术名称:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML9 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    手术日期:" + objContent.m_dtmOperationDate, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML10 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　入院诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML11 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　住院经过:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML12 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　死亡经过:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML13 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　死后诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML14 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　死亡讨论结论:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, strXML3, strXML4, strXML5, strXML6, strXML7, strXML8, objContent.m_strOperationNameXML, strXML9, strXML10, objContent.m_strInHospitalDiagnoseXML, strXML11, objContent.m_strInHospitalProcessXML, strXML12, objContent.m_strDeadProcessXML, strXML13, objContent.m_strDeadDiagnoseXML, strXML14, objContent.m_strDeadVerdictXML });
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

            clsDeadRecord_VO objContent = ((clsDeadRecord_VO)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmDeathRecord")) + "   " + "死亡记录\n";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);
            if (objPatient != null && objPatient.m_ObjPeopleInfo != null)
                strText += "　　" + objPatient.m_ObjPeopleInfo.m_StrFirstName + "，" + objPatient.m_ObjPeopleInfo.m_StrSex + "，" + objPatient.m_ObjPeopleInfo.m_IntAge.ToString() + "岁，";
            else strText += "　　病人信息不详，";

            TimeSpan ts = objContent.m_dtmDeadDate - objContent.m_dtmInPatientDate;

            strText +=/*strInHospitalReason + */objContent.m_dtmInPatientDate.ToString("yyyy年MM月dd日") + "入院，" + objContent.m_dtmDeadDate.ToString("yyyy年MM月dd日HH时mm分") + "死亡，共住院" + (ts.Days + 1).ToString() + "天。";
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.Death;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignText()
        {
            if (m_objRecordContent == null)
                return "";
            clsDeadRecord_VO objContent = ((clsDeadRecord_VO)m_objRecordContent);
            return objContent.m_strDoctorName;


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

    }// END CLASS DEFINITION clsDeadInfo
}
