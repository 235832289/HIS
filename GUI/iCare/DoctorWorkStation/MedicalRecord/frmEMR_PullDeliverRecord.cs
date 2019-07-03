using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 阴道胎头吸引器助产手术记录
    /// </summary>
    public partial class frmEMR_PullDeliverRecord : frmDiseaseTrackBase
    {
        #region 全局变量
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;

        private long m_lngCurrentEMR_SEQ = -1;
        #endregion

        #region 构造函数
        public frmEMR_PullDeliverRecord()
        {
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            m_mthSetRichTextBoxAttribInControl(this);

            #region 电子签名
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdRecorder, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
           // m_objSign.m_mthBindEmployeeSign(m_cmdOperator, m_txtOperator, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAssistant, m_lsvAssistant, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
           // m_objSign.m_mthBindEmployeeSign(m_cmdAnaesthetist, m_txtAnaesthetist, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOperator, m_lsvAction, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAnaesthetist, m_lismazui, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            #endregion
        } 
        #endregion

        #region 方法
        #region 清空特殊记录信息
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);

            if (m_objBaseCurrentPatient != null)
            {
                m_lblInPatientDate.Text = m_objBaseCurrentPatient.m_DtmLastHISInDate.ToString("yyyy-MM-dd HH:mm:ss");
            }            

            m_dtpOPDate.Value = DateTime.Now;

            m_txtDiagnosisBeforeOP.m_mthClearText();
            m_txtOPIndication.m_mthClearText();
            m_txtDiagnosisAfterOP.m_mthClearText();
            m_txtAnaMode.m_mthClearText();
            //m_txtAnaesthetist.Text = "";
            //m_txtAnaesthetist.Tag = null;

            m_txtUterueHeight.m_mthClearText();
            m_txtAbdomenRound.m_mthClearText();
            m_txtPresentation.m_mthClearText();
            m_txtFetusWeight.m_mthClearText();

            m_chkLinkup1.Checked = false;
            m_chkLinkup2.Checked = false;
            m_chkLinkup3.Checked = false;

            m_chkIschialSpine1.Checked = false;
            m_chkIschialSpine2.Checked = false;
            m_chkIschialSpine3.Checked = false;

            m_chkCoccyxRadian1.Checked = false;
            m_chkCoccyxRadian2.Checked = false;
            m_chkCoccyxRadian3.Checked = false;

            m_chkIshiumNotch1.Checked = false;
            m_chkIshiumNotch2.Checked = false;
            m_chkIshiumNotch3.Checked = false;

            m_txtDC.m_mthClearText();
            m_txtUterusora.m_mthClearText();

            m_chkAmniocentesis1.Checked = false;
            m_chkAmniocentesis2.Checked = false;
            m_chkAmniocentesis3.Checked = false;
            m_chkAmniocentesis4.Checked = false;

            m_txtFetusPlace.m_mthClearText();
            m_txtPresentationHeight.m_mthClearText();

            m_chkSkull1.Checked = false;
            m_chkSkull2.Checked = false;

            m_txtCaputSuccedaneumSize.m_mthClearText();
            m_txtCaputSuccedaneumPlace.m_mthClearText();

            m_txtUterusoraOpen.m_mthClearText();
            m_txtPresentationPlace.m_mthClearText();
            m_txtLateralincisorANA.m_mthClearText();
            m_txtMiunsPress.m_mthClearText();
            m_txtPullTime.m_mthClearText();
            m_txtApgar1.m_mthClearText();
            m_txtApgar2.m_mthClearText();
            m_txtAfterChildBearing.m_mthClearText();
            m_txtBleedingInOP.m_mthClearText();

            //m_txtOperator.Text = "";
            //m_txtOperator.Tag = null;

            m_cboLayTimes.Text = "";
            m_cboPregnantTimes.Text = "";

            m_lsvAssistant.Items.Clear();
            m_lismazui.Items.Clear();
            m_lsvAction.Items.Clear();
        }
        #endregion

        #region 从界面获取特殊记录的值
        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;

            if (txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请记录者签名！");
                return null;
            }

            clsEMR_PullDeliverRecordvalue objRecord = new clsEMR_PullDeliverRecordvalue();
            objRecord.m_dtmRECORDDATE = m_dtpCreateDate.Value;
            clsEmrEmployeeBase_VO objCreat = txtSign.Tag as clsEmrEmployeeBase_VO;
            if (objCreat != null)
            {
                objRecord.m_strCreateUserID = objCreat.m_strEMPID_CHR;
            }
            objRecord.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objRecord.m_intMarkStatus = 0;
            else
                objRecord.m_intMarkStatus = 1;
            #endregion
            #region 获取签名集合
            int intSignCount = 0;

            intSignCount = m_lsvAssistant.Items.Count + 1;
            intSignCount += m_lsvAction.Items.Count + 1;
            intSignCount += m_lismazui.Items.Count + 1;
            //if (m_txtAnaesthetist.Tag != null)
            //{
            //    intSignCount++;
            //}
            //if (m_txtOperator.Tag != null)
            //{
            //    intSignCount++;
            //}
            objRecord.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
          //  m_mthGetSignArr(new Control[] { m_lsvAssistant, txtSign, m_txtAnaesthetist, m_txtOperator }, ref objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            m_mthGetSignArr(new Control[] { m_lsvAssistant, txtSign, m_lsvAction, m_lismazui }, ref objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            //int currentSignCount = 0;
            //for (int i = 0; i < m_lsvAssistant.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvAssistant.Items[i].Tag);
            //    objRecord.objSignerArr[i].controlName = "m_lsvAssistant";
            //    objRecord.objSignerArr[i].m_strFORMID_VCHR = "frmEMR_PullDeliverRecord";
            //    objRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount = m_lsvAssistant.Items.Count;

            //objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            //objRecord.objSignerArr[currentSignCount].controlName = "txtSign";
            //objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_PullDeliverRecord";
            //objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //currentSignCount++;

            //if (m_txtAnaesthetist.Tag != null)
            //{
            //    objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(m_txtAnaesthetist.Tag);
            //    objRecord.objSignerArr[currentSignCount].controlName = "m_txtAnaesthetist";
            //    objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_PullDeliverRecord";
            //    objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    currentSignCount++;
            //}

            //if (m_txtOperator.Tag != null)
            //{
            //    objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(m_txtOperator.Tag);
            //    objRecord.objSignerArr[currentSignCount].controlName = "m_txtOperator";
            //    objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_PullDeliverRecord";
            //    objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            #endregion

            objRecord.m_dtmRECORDDATE = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objRecord.m_dtmOPDATE = Convert.ToDateTime(m_dtpOPDate.Value.ToString("yyyy-MM-dd 00:00:00"));

            try
            {
                if (string.IsNullOrEmpty(m_cboPregnantTimes.Text))
                {
                    objRecord.m_intPREGNANTTIMES = -1;
                }
                else
                {
                    objRecord.m_intPREGNANTTIMES = int.Parse(m_cboPregnantTimes.Text);
                }
                if (string.IsNullOrEmpty(m_cboLayTimes.Text))
                {
                    objRecord.m_intLAYTIMES = -1;
                }
                else
                {
                    objRecord.m_intLAYTIMES = int.Parse(m_cboLayTimes.Text);
                }
            }
            catch
            {
                clsPublicFunction.ShowInformationMessageBox("孕、产次中填入了非整数！");
                return null ;
            }
            if (objRecord.m_intPREGNANTTIMES > 99 || objRecord.m_intLAYTIMES > 99)
            {
                clsPublicFunction.ShowInformationMessageBox("孕、产次中的数值过大！");
                return null;
            }

            objRecord.m_strDIAGNOSISBEFOREOP = m_txtDiagnosisBeforeOP.Text;
            objRecord.m_strDIAGNOSISBEFOREOP_RIGHT = m_txtDiagnosisBeforeOP.m_strGetRightText();
            objRecord.m_strDIAGNOSISBEFOREOPXML = m_txtDiagnosisBeforeOP.m_strGetXmlText();

            objRecord.m_strOPINDICATION = m_txtOPIndication.Text;
            objRecord.m_strOPINDICATION_RIGHT = m_txtOPIndication.m_strGetRightText();
            objRecord.m_strOPINDICATIONXML = m_txtOPIndication.m_strGetXmlText();

            objRecord.m_strDIAGNOSISAFTEROP = m_txtDiagnosisAfterOP.Text;
            objRecord.m_strDIAGNOSISAFTEROP_RIGHT = m_txtDiagnosisAfterOP.m_strGetRightText();
            objRecord.m_strDIAGNOSISAFTEROPXML = m_txtDiagnosisAfterOP.m_strGetXmlText();

            objRecord.m_strANAMODE = m_txtAnaMode.Text;
            objRecord.m_strANAMODE_RIGHT = m_txtAnaMode.m_strGetRightText();
            objRecord.m_strANAMODEXML = m_txtAnaMode.m_strGetXmlText();

            objRecord.m_strUTERUSHEIGHT = m_txtUterueHeight.Text;
            objRecord.m_strUTERUSHEIGHT_RIGHT = m_txtUterueHeight.m_strGetRightText();
            objRecord.m_strUTERUSHEIGHTXML = m_txtUterueHeight.m_strGetXmlText();

            objRecord.m_strABDOMENROUND = m_txtAbdomenRound.Text;
            objRecord.m_strABDOMENROUND_RIGHT = m_txtAbdomenRound.m_strGetRightText();
            objRecord.m_strABDOMENROUNDXML = m_txtAbdomenRound.m_strGetXmlText();

            objRecord.m_strPRESENTATION = m_txtPresentation.Text;
            objRecord.m_strPRESENTATION_RIGHT = m_txtPresentation.m_strGetRightText();
            objRecord.m_strPRESENTATIONXML = m_txtPresentation.m_strGetXmlText();

            string strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkLinkup1.Checked) + m_strBoolean(m_chkLinkup2.Checked) 
                + m_strBoolean(m_chkLinkup3.Checked);
            objRecord.m_strLINKUP = strCheck;

            objRecord.m_strFETUSWEIGHT = m_txtFetusWeight.Text;
            objRecord.m_strFETUSWEIGHT_RIGHT = m_txtFetusWeight.m_strGetRightText();
            objRecord.m_strFETUSWEIGHTXML = m_txtFetusWeight.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkIschialSpine1.Checked) + m_strBoolean(m_chkIschialSpine2.Checked)
            + m_strBoolean(m_chkIschialSpine3.Checked);
            objRecord.m_strISCHIALSPINE = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkCoccyxRadian1.Checked) + m_strBoolean(m_chkCoccyxRadian2.Checked)
            + m_strBoolean(m_chkCoccyxRadian3.Checked);
            objRecord.m_strCOCCYXRADIAN = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkIshiumNotch1.Checked) + m_strBoolean(m_chkIshiumNotch2.Checked)
            + m_strBoolean(m_chkIshiumNotch3.Checked);
            objRecord.m_strISCHIUMNOTCH = strCheck;

            objRecord.m_strDC = m_txtDC.Text;
            objRecord.m_strDC_RIGHT = m_txtDC.m_strGetRightText();
            objRecord.m_strDCXML = m_txtDC.m_strGetXmlText();

            objRecord.m_strUTERUSORA = m_txtUterusora.Text;
            objRecord.m_strUTERUSORA_RIGHT = m_txtUterusora.m_strGetRightText();
            objRecord.m_strUTERUSORAXML = m_txtUterusora.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkAmniocentesis1.Checked) + m_strBoolean(m_chkAmniocentesis2.Checked)
            + m_strBoolean(m_chkAmniocentesis3.Checked) + m_strBoolean(m_chkAmniocentesis4.Checked);
            objRecord.m_strAMNIOCENTESIS = strCheck;

            objRecord.m_strFETUSPLACE = m_txtFetusPlace.Text;
            objRecord.m_strFETUSPLACE_RIGHT = m_txtFetusPlace.m_strGetRightText();
            objRecord.m_strFETUSPLACEXML = m_txtFetusPlace.m_strGetXmlText();

            objRecord.m_strPRESENTATIONHEITHT = m_txtPresentationHeight.Text;
            objRecord.m_strPRESENTATIONHEITHT_RIGHT = m_txtPresentationHeight.m_strGetRightText();
            objRecord.m_strPRESENTATIONHEITHTXML = m_txtPresentationHeight.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkull1.Checked) + m_strBoolean(m_chkSkull2.Checked);
            objRecord.m_strSKULL = strCheck;

            objRecord.m_strCAPUTSUCCEDANEUMSIZE = m_txtCaputSuccedaneumSize.Text;
            objRecord.m_strCAPUTSUCCEDANEUMSIZE_RIGHT = m_txtCaputSuccedaneumSize.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMSIZEXML = m_txtCaputSuccedaneumSize.m_strGetXmlText();

            objRecord.m_strCAPUTSUCCEDANEUMPLACE = m_txtCaputSuccedaneumPlace.Text;
            objRecord.m_strCAPUTSUCCEDANEUMPLACE_RIGHT = m_txtCaputSuccedaneumPlace.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMPLACEXML = m_txtCaputSuccedaneumPlace.m_strGetXmlText();

            objRecord.m_strUTERUSORAOPEN = m_txtUterusoraOpen.Text;
            objRecord.m_strUTERUSORAOPEN_RIGHT = m_txtUterusoraOpen.m_strGetRightText();
            objRecord.m_strUTERUSORAOPENXML = m_txtUterusoraOpen.m_strGetXmlText();

            objRecord.m_strPRESENTATIONPLACE = m_txtPresentationPlace.Text;
            objRecord.m_strPRESENTATIONPLACE_RIGHT = m_txtPresentationPlace.m_strGetRightText();
            objRecord.m_strPRESENTATIONPLACEXML = m_txtPresentationPlace.m_strGetXmlText();

            objRecord.m_strLATERALINCISORANA = m_txtLateralincisorANA.Text;
            objRecord.m_strLATERALINCISORANA_RIGHT = m_txtLateralincisorANA.m_strGetRightText();
            objRecord.m_strLATERALINCISORANAXML = m_txtLateralincisorANA.m_strGetXmlText();

            objRecord.m_strMINUSPRESS = m_txtMiunsPress.Text;
            objRecord.m_strMINUSPRESS_RIGHT = m_txtMiunsPress.m_strGetRightText();
            objRecord.m_strMINUSPRESSXML = m_txtMiunsPress.m_strGetXmlText();

            objRecord.m_strPULLTIME = m_txtPullTime.Text;
            objRecord.m_strPULLTIME_RIGHT = m_txtPullTime.m_strGetRightText();
            objRecord.m_strPULLTIMEXML = m_txtPullTime.m_strGetXmlText();

            objRecord.m_strAPGAR1 = m_txtApgar1.Text;
            objRecord.m_strAPGAR1_RIGHT = m_txtApgar1.m_strGetRightText();
            objRecord.m_strAPGAR1XML = m_txtApgar1.m_strGetXmlText();

            objRecord.m_strAPGAR2 = m_txtApgar2.Text;
            objRecord.m_strAPGAR2_RIGHT = m_txtApgar2.m_strGetRightText();
            objRecord.m_strAPGAR2XML = m_txtApgar2.m_strGetXmlText();

            objRecord.m_strAFTERCHILDBEARING = m_txtAfterChildBearing.Text;
            objRecord.m_strAFTERCHILDBEARING_RIGHT = m_txtAfterChildBearing.m_strGetRightText();
            objRecord.m_strAFTERCHILDBEARINGXML = m_txtAfterChildBearing.m_strGetXmlText();

            objRecord.m_strBLEEDINGINOP = m_txtBleedingInOP.Text;
            objRecord.m_strBLEEDINGINOP_RIGHT = m_txtBleedingInOP.m_strGetRightText();
            objRecord.m_strBLEEDINGINOPXML = m_txtBleedingInOP.m_strGetXmlText();

            objRecord.m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            objRecord.m_lngEMR_SEQ = m_lngCurrentEMR_SEQ;
            return objRecord;
        } 
        #endregion

        #region 将布尔值转换为"1"或"0"
        /// <summary>
        /// 将布尔值转换为"1"或"0"
        /// </summary>
        /// <param name="p_blnBool">布尔值</param>
        /// <returns></returns>
        private string m_strBoolean(bool p_blnBool)
        {
            if (p_blnBool)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        } 
        #endregion

        #region 将"0"和"1"转换为布尔值
        /// <summary>
        /// 将"0"和"1"转换为布尔值
        /// </summary>
        /// <param name="p_strNum">0或1</param>
        /// <returns></returns>
        private bool m_blnGetBooleanBy01(string p_strNum)
        {
            if (p_strNum == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region 把特殊记录的值显示到界面上
        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;

            clsEMR_PullDeliverRecordvalue objRecord = p_objContent as clsEMR_PullDeliverRecordvalue;
            if (objRecord == null) return;
            m_dtpCreateDate.Value = objRecord.m_dtmRECORDDATE;
            m_lngCurrentEMR_SEQ = objRecord.m_lngEMR_SEQ;

            #region 签名集合
            if (objRecord.objSignerArr != null)
            {
                m_mthAddSignToListView(new ListView[] { m_lsvAssistant, m_lsvAction, m_lismazui }, objRecord.objSignerArr);

            //    m_mthAddSignToTextBoxBase(new TextBoxBase[] { txtSign, m_txtOperator, m_txtAnaesthetist }, objRecord.objSignerArr, new bool[] { true, true, true }, false);
                //m_lsvAssistant.Items.Clear();
                //txtSign.Tag = null;
                //txtSign.Clear();
                //m_txtOperator.Tag = null;
                //m_txtOperator.Clear();
                //m_txtAnaesthetist.Tag = null;
                //m_txtAnaesthetist.Clear();

                //for (int i = 0; i < objRecord.objSignerArr.Length; i++)
                //{
                //    if (objRecord.objSignerArr[i].controlName == "m_lsvAssistant")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvAssistant.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "txtSign")
                //    {
                //        txtSign.Text = objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        txtSign.Tag = objRecord.objSignerArr[i].objEmployee;
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_txtOperator")
                //    {
                //        m_txtOperator.Text = objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        m_txtOperator.Tag = objRecord.objSignerArr[i].objEmployee;
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_txtAnaesthetist")
                //    {
                //        m_txtAnaesthetist.Text = objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        m_txtAnaesthetist.Tag = objRecord.objSignerArr[i].objEmployee;
                //    }
                //}
            }
            #endregion

            m_lblInPatientDate.Text = m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss");
            m_dtpOPDate.Value = objRecord.m_dtmOPDATE;

            m_txtDiagnosisBeforeOP.m_mthSetNewText(objRecord.m_strDIAGNOSISBEFOREOP, objRecord.m_strDIAGNOSISBEFOREOPXML);
            m_txtOPIndication.m_mthSetNewText(objRecord.m_strOPINDICATION, objRecord.m_strOPINDICATIONXML);
            m_txtDiagnosisAfterOP.m_mthSetNewText(objRecord.m_strDIAGNOSISAFTEROP, objRecord.m_strDIAGNOSISAFTEROPXML);
            m_txtAnaMode.m_mthSetNewText(objRecord.m_strANAMODE, objRecord.m_strANAMODEXML);
            m_txtUterueHeight.m_mthSetNewText(objRecord.m_strUTERUSHEIGHT, objRecord.m_strUTERUSHEIGHTXML);
            m_txtAbdomenRound.m_mthSetNewText(objRecord.m_strABDOMENROUND, objRecord.m_strABDOMENROUNDXML);
            m_txtPresentation.m_mthSetNewText(objRecord.m_strPRESENTATION, objRecord.m_strPRESENTATIONXML);

            m_cboLayTimes.Text = objRecord.m_intLAYTIMES == -1 ? "" : objRecord.m_intLAYTIMES.ToString();
            m_cboPregnantTimes.Text = objRecord.m_intPREGNANTTIMES == -1 ? "" : objRecord.m_intPREGNANTTIMES.ToString();

            m_chkLinkup1.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(0, 1));
            m_chkLinkup2.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(1, 1));
            m_chkLinkup3.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(2, 1));

            m_txtFetusWeight.m_mthSetNewText(objRecord.m_strFETUSWEIGHT, objRecord.m_strFETUSWEIGHTXML);

            m_chkIschialSpine1.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(0, 1));
            m_chkIschialSpine2.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(1, 1));
            m_chkIschialSpine3.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(2, 1));

            m_chkCoccyxRadian1.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(0, 1));
            m_chkCoccyxRadian2.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(1, 1));
            m_chkCoccyxRadian3.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(2, 1));

            m_chkIshiumNotch1.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(0, 1));
            m_chkIshiumNotch2.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(1, 1));
            m_chkIshiumNotch3.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(2, 1));

            m_txtDC.m_mthSetNewText(objRecord.m_strDC, objRecord.m_strDCXML);
            m_txtUterusora.m_mthSetNewText(objRecord.m_strUTERUSORA, objRecord.m_strUTERUSORAXML);

            m_chkAmniocentesis1.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS.Substring(0, 1));
            m_chkAmniocentesis2.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS.Substring(1, 1));
            m_chkAmniocentesis3.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS.Substring(2, 1));
            m_chkAmniocentesis4.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS.Substring(3, 1));

            m_txtFetusPlace.m_mthSetNewText(objRecord.m_strFETUSPLACE, objRecord.m_strFETUSPLACEXML);
            m_txtPresentationHeight.m_mthSetNewText(objRecord.m_strPRESENTATIONHEITHT, objRecord.m_strPRESENTATIONHEITHTXML);

            m_chkSkull1.Checked = m_blnGetBooleanBy01(objRecord.m_strSKULL.Substring(0, 1));
            m_chkSkull2.Checked = m_blnGetBooleanBy01(objRecord.m_strSKULL.Substring(1, 1));

            m_txtCaputSuccedaneumSize.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMSIZE, objRecord.m_strCAPUTSUCCEDANEUMSIZEXML);
            m_txtCaputSuccedaneumPlace.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMPLACE, objRecord.m_strCAPUTSUCCEDANEUMPLACEXML);
            m_txtUterusoraOpen.m_mthSetNewText(objRecord.m_strUTERUSORAOPEN, objRecord.m_strUTERUSORAOPENXML);
            m_txtPresentationPlace.m_mthSetNewText(objRecord.m_strPRESENTATIONPLACE, objRecord.m_strPRESENTATIONPLACEXML);
            m_txtLateralincisorANA.m_mthSetNewText(objRecord.m_strLATERALINCISORANA, objRecord.m_strLATERALINCISORANAXML);
            m_txtMiunsPress.m_mthSetNewText(objRecord.m_strMINUSPRESS, objRecord.m_strMINUSPRESSXML);
            m_txtPullTime.m_mthSetNewText(objRecord.m_strPULLTIME, objRecord.m_strPULLTIMEXML);
            m_txtApgar1.m_mthSetNewText(objRecord.m_strAPGAR1, objRecord.m_strAPGAR1XML);
            m_txtApgar2.m_mthSetNewText(objRecord.m_strAPGAR2, objRecord.m_strAPGAR2XML);
            m_txtAfterChildBearing.m_mthSetNewText(objRecord.m_strAFTERCHILDBEARING, objRecord.m_strAFTERCHILDBEARINGXML);
            m_txtBleedingInOP.m_mthSetNewText(objRecord.m_strBLEEDINGINOP, objRecord.m_strBLEEDINGINOPXML);

            m_cmdRecorder.Enabled = false;
            m_dtpCreateDate.Enabled = false;
        } 
        #endregion

        #region 获取当前病人的作废内容
        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue || p_dtmRecordDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误！");
                return;
            }

            clsTrackRecordContent objContent = null;
            long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
            if (lngRes > 0 && objContent != null)
            {
                m_objCurrentRecordContent = objContent;
                m_mthSetDeletedGUIFromContent(objContent);
            }
        }
        #endregion

        #region m_IntFormID
        public override int m_IntFormID
        {
            get
            {
                return 131;
            }
        }
        #endregion

        #region 显示已删除记录
        /// <summary>
        /// 显示已删除记录
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;

            m_mthSetGUIFromContent(p_objContent);
        }
        #endregion

        #region 获取领域层实例
        /// <summary>
        /// 获取领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_PullDeliverRecord);
        }
        #endregion

        #region 把选择时间记录内容重新整理为完全正确的内容
        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            m_mthSetGUIFromContent(p_objRecordContent);
        }
        #endregion

        #region m_strReloadFormTitle
        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "阴道胎头吸引器助产手术记录";
        }
        #endregion

        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.Nurses; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (txtSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPID_CHR.Trim();
                return "";
            }
        }
        #endregion 属性
        #endregion

        #region 事件
        #region 实现指定CheckBox单选
        private void m_chkSingle_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkCurrent = sender as CheckBox;
            if (chkCurrent == null)
                return;

            if (chkCurrent.Checked)
            {
                Panel pnlParent = chkCurrent.Parent as Panel;
                if (pnlParent == null)
                    return;

                foreach (Control ctl in pnlParent.Controls)
                {
                    if (ctl is CheckBox && ctl.Name != chkCurrent.Name)
                    {
                        ((CheckBox)ctl).Checked = false;
                    }
                }
            }
        }
        #endregion

        private void frmEMR_PullDeliverRecord_Load(object sender, EventArgs e)
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }

        //		private bool m_blnHasInitPrintTool=false;
        clsEMR_PullDeliverRecordPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            //			if(m_blnHasInitPrintTool==false)
            //			{
            objPrintTool = new clsEMR_PullDeliverRecordPrintTool();
            objPrintTool.m_mthInitPrintTool(null);
            //				m_blnHasInitPrintTool=true;
            //			}
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        }

        private void m_mthStartPrint_this()
        {
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion
    }
}