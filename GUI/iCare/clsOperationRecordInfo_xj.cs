using System;
using iCareData;
using com.digitalwave.Utility.Controls;

namespace iCare
{
    /// <summary>
    /// 手术记录--新疆 信息。
    /// </summary>
    public class clsOperationRecordInfo_xj : clsDiseaseTrackInfo
    {

        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsOperationRecordContent_xj objContent = ((clsOperationRecordContent_xj)m_objRecordContent);
            string strText = m_strGetHeaderText();

            //strText += "\n　　心电图号:" + objContent.m_strHeartID;
            //strText += "\n　　X光号:" + objContent.m_strXRayID;
            strText += "\n　　手术名称:" + objContent.m_strInHospitalDiagnose;
            //strText += "\n　　西医入院诊断:" + objContent.m_strInHospitalDiagnoseXi;
            strText += "\n　　术前诊断:" + objContent.m_strOutHospitalDiagnose;
            //strText += "\n　　西医死亡诊断:" + objContent.m_strOutHospitalDiagnoseXi;
            strText += "\n　　签名:" + objContent.m_strMainDoctorName;
            strText += "\n　　手术者:" + objContent.m_strDoctorName;
            strText += "\n　　助手:" + objContent.m_strHelperName;
            strText += "\n　　麻醉方法:" + objContent.m_strInHospitalCase;
            //  strText += "\n　　诊疗经过:" + objContent.m_strInHospitalBy;
            strText += "\n　　术中诊断:" + objContent.m_strOutHospitalCase;
            strText += "\n　　手术经过:" + objContent.m_strOutHospitalAdvice;

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

            clsOperationRecordContent_xj objContent = ((clsOperationRecordContent_xj)m_objRecordContent);
            string strText = m_strGetHeaderText();

            string strCreateUserName = "";
            clsEmployee objEmployee = new clsEmployee(m_objRecordContent.m_strCreateUserID);
            if (objEmployee != null)
                strCreateUserName = objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML2 = ctlRichTextBox.s_strMakeTextXml("\n　　心电图号:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML3 = ctlRichTextBox.s_strMakeTextXml("\n　　X光号:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.s_strMakeTextXml("\n　　手术名称:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
           // string strXML3 = ctlRichTextBox.s_strMakeTextXml("\n　　西医入院诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.s_strMakeTextXml("\n　　术前诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
           // string strXML5 = ctlRichTextBox.s_strMakeTextXml("\n　　西医死亡诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.s_strMakeTextXml("\n　　签名:" + objContent.m_strMainDoctorName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.s_strMakeTextXml("\n　　手术者:" + objContent.m_strDoctorName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.s_strMakeTextXml("\n　　助手:" + objContent.m_strHelperName, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML7 = ctlRichTextBox.s_strMakeTextXml("\n　　麻醉方法:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML8 = ctlRichTextBox.s_strMakeTextXml("\n　　诊疗经过:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.s_strMakeTextXml("\n　　术中诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML9 = ctlRichTextBox.s_strMakeTextXml("\n　　手术经过:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.s_strCombineXml(new string[] { strXML1, strXML2, strXML3,objContent.m_strOutHospitalDiagnoseXML, strXML4, strXML5, strXML6, strXML7, strXML8, objContent.m_strOutHospitalCaseXML, strXML9, objContent.m_strOutHospitalAdviceXML });
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

            clsOperationRecordContent_xj objContent = ((clsOperationRecordContent_xj)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmOperationRecord_xj")) + "   " + "手术记录\n";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);
            if (objPatient != null && objPatient.m_ObjPeopleInfo != null)
                strText += "　　" + objPatient.m_ObjPeopleInfo.m_StrFirstName + "，" + objPatient.m_ObjPeopleInfo.m_StrSex + "，" + objPatient.m_ObjPeopleInfo.m_IntAge.ToString() + "岁，";
            else strText += "　　病人信息不详，";

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
            TimeSpan ts = objContent.m_dtmOutHospitalDate - objContent.m_dtmInPatientDate;

            //MM月->01月,M月->1月			只认英文字符
            strText += strInHospitalReason + objContent.m_dtmInPatientDate.ToString("yyyy年MM月dd日") + "入院，" + objContent.m_dtmOutHospitalDate.ToString("yyyy年MM月dd日") + "出院，共住院" + (ts.Days + 1).ToString() + "天。";
            return strText;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.OperationRecord_xj;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignText()
        {
            if (m_objRecordContent == null)
                return "";
            clsOperationRecordContent_xj objContent = ((clsOperationRecordContent_xj)m_objRecordContent);
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

    }// END CLASS DEFINITION clsOutHospitalInfo

}
