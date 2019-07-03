using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using iCareData;
using System.Drawing.Printing;

namespace iCare
{
    /// <summary>
    /// 剖宫产手术记录
    /// </summary>
    public partial class frmEMR_CesareanRecord : frmDiseaseTrackBase
    {
        #region 全局变量
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;

        private long m_lngCurrentEMR_SEQ = -1;
        /// <summary>
        /// 
        /// </summary>
        private clsEMR_CesareanRecordPrintTool objPrintTool;
        #endregion

        #region 构造函数
        public frmEMR_CesareanRecord()
        {
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            #region 电子签名
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdRecorder, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOperator, m_txtOperator, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAssistant1, m_lsvAssistant1, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAssistant2, m_lsvAssistant2, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAnaesthetist, m_txtAnaesthetist, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            #endregion
        } 
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

        #region 使两处的手术时间保持一致
        private void m_dtpOPDate_evtValueChanged(object sender, EventArgs e)
        {
            //if (m_dtpOPDate.Focused)
            //{
            //    m_dtpOPTime.Value = m_dtpOPDate.Value;
            //}
        }

        private void m_dtpOPTime_evtValueChanged(object sender, EventArgs e)
        {
            //if (m_dtpOPTime.Focused)
            //{
            //    m_dtpOPDate.Value = m_dtpOPTime.Value;
            //}
        } 
        #endregion

        #region 术前阴查是否未检
        private void m_chkUnCheckBeforeOP_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkUnCheckBeforeOP.Checked)
            {
                panel2.Enabled = false;
                m_mthClearControls(panel2);
            }
            else
            {
                panel2.Enabled = true;
            }
        } 
        #endregion
        #endregion

        #region 方法
        #region 清空指定控件中的内容
        /// <summary>
        /// 清空指定控件中的内容
        /// </summary>
        /// <param name="p_ctlParent">父控件</param>
        private void m_mthClearControls(Control p_ctlParent)
        {
            if (p_ctlParent == null)
                return;

            foreach (Control ctl in p_ctlParent.Controls)
            {
                string strControlName = ctl.Name;
                if (strControlName == "CheckBox")
                {
                    ((CheckBox)ctl).Checked = false;
                }
                else if (strControlName == "ctlRichTextBox")
                {
                    ((com.digitalwave.controls.ctlRichTextBox)ctl).m_mthClearText();
                }
                else if (strControlName == "TextBox")
                {
                    ((TextBox)ctl).Clear();
                }

                if (ctl.HasChildren)
                {
                    m_mthClearControls(ctl);
                }
            }
        }
         #endregion 

        #region 清空特殊记录信息
        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);

            m_lblInPatientDate.Text = "";// m_objBaseCurrentPatient.m_DtmLastHISInDate.ToString("yyyy-MM-dd HH:mm:ss");
            m_dtpOPDate.Value = DateTime.Now;

            m_cboLayTimes.Text = "";
            m_cboPregnantTimes.Text = "";
            m_txtDiagnosisBeforeOP.m_mthClearText();
            m_txtOPIndication.m_mthClearText();
            m_txtDiagnosisAfterOP.m_mthClearText();
            m_txtOPName.m_mthClearText();
            m_txtAnaMode.m_mthClearText();
            m_txtAnaesthetist.Text = "";
            m_txtAnaesthetist.Tag = null;

            m_txtUterueHeight.m_mthClearText();
            m_txtAbdomenRound.m_mthClearText();
            m_txtPresentation1.m_mthClearText();
            m_mthClearControls(panel1);
            m_txtFetusWeight.m_mthClearText();
            m_chkUnCheckBeforeOP.Checked = false;
            m_mthClearControls(panel2);

            m_txtAbdominalWall_V.m_mthClearText();
            m_txtAbdominalWall_H.m_mthClearText();

            m_chkFascia1.Checked = false;
            m_chkFascia2.Checked = false;
            m_chkFascia3.Checked = false;
            m_chkFascia4.Checked = false;

            m_chkPeritoneum1.Checked = false;
            m_chkPeritoneum2.Checked = false;
            m_chkPeritoneum3.Checked = false;
            m_chkPeritoneum4.Checked = false;
            m_chkPeritoneum5.Checked = false;
            m_chkPeritoneum6.Checked = false;

            m_chkUterus1.Checked = false;
            m_chkUterus2.Checked = false;
            m_chkUterus3.Checked = false;
            m_chkUterus4.Checked = false;

            m_txtFetusPlace2.m_mthClearText();

            m_chkEngagement1.Checked = false;
            m_chkEngagement2.Checked = false;
            m_chkEngagement3.Checked = false;

            m_chkPresentatonExpulsion1.Checked = false;
            m_chkPresentatonExpulsion2.Checked = false;
            m_chkPresentatonExpulsion3.Checked = false;

            m_dtpExpulsionTime.Value = DateTime.Now;
            m_chkBabySex1.Checked = false;
            m_chkBabySex2.Checked = false;
            m_txtBabyWeight.m_mthClearText();
            m_txtApgar.m_mthClearText();
            m_txtFetusFacies.m_mthClearText();
            m_txtCaputsuccedaneumSezeX.m_mthClearText();
            m_txtCaputsuccedaneumSezeY.m_mthClearText();
            m_txtCaputSuccedaneumPlace2.m_mthClearText();

            m_chkAmniocentesis21.Checked = false;
            m_chkAmniocentesis22.Checked = false;
            m_chkAmniocentesis23.Checked = false;
            m_chkAmniocentesis24.Checked = false;

            m_txtAmniocentesisBulk.m_mthClearText();

            m_chkEmbryolemmaCircs1.Checked = false;
            m_chkEmbryolemmaCircs2.Checked = false;
            m_chkOviductCircs1L.Checked = false;
            m_chkOviductCircs2L.Checked = false;
            this.m_chkOviductCircs1R.Checked = false;
            this.m_chkOviductCircs2R.Checked = false;
            m_chkOvaryCircs1L.Checked = false;
            m_chkOvaryCircs2L.Checked = false;
            this.m_chkOvaryCircs1R.Checked = false;
            this.m_chkOvaryCircs2R.Checked = false;

            this.chkHasSuccedaneum1.Checked = false;
            this.chkNoSuccedaneum1.Checked = true;
            this.chkHasSuccedaneum2.Checked = false;
            this.chkNoSuccedaneum2.Checked = true;

            this.m_txtCaputSuccedaneumSize.Enabled = false;
            this.m_txtCaputsuccedaneumSezeX.Enabled = false;
            this.m_txtCaputsuccedaneumSezeY.Enabled = false;

            m_txtSutureUterus.m_mthClearText();
            m_txtSutureAbdominalWall.m_mthClearText();
            m_txtOxytocinIMIv.m_mthClearText();
            //m_txtiv.m_mthClearText();
            //m_txtIM.m_mthClearText();
            m_txtOtherMedicine.m_mthClearText();
            m_txtPiss.m_mthClearText();
            m_txtBleeding.m_mthClearText();
            m_txtTransfuse.m_mthClearText();
            m_cboANATime.Text = string.Empty;
            m_cboOPTime.Text = string.Empty;

            m_txtOperator.Clear();
            m_txtOperator.Tag = null;

            m_lsvAssistant1.Clear();
            m_lsvAssistant2.Clear();

            m_txtPLACENTA.m_mthClearText();
            m_txtUMBILICALCORD.m_mthClearText();
            m_txtSumary4.m_mthClearText();
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

            clsEMR_CesareanRecordValue objRecord = new clsEMR_CesareanRecordValue();
            objRecord.m_dtmRECORDDATE = m_dtpCreateDate.Value;
            clsEmrEmployeeBase_VO objCreat = txtSign.Tag as clsEmrEmployeeBase_VO;
            if (objCreat != null)
            {
                objRecord.m_strCreateUserID = objCreat.m_strEMPID_CHR;
            }
            objRecord.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;

            #region 获取签名集合
            int intSignCount = 3;
            if (m_txtAnaesthetist.Tag != null)
            {
                intSignCount++;
            }
            if (m_txtOperator.Tag != null)
            {
                intSignCount++;
            }
            objRecord.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { txtSign, m_txtAnaesthetist, m_txtOperator }, ref objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            //int currentSignCount = 0;
            //for (int i = 0; i < m_lsvAssistant1.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvAssistant1.Items[i].Tag);
            //    objRecord.objSignerArr[i].controlName = "m_lsvAssistant1";
            //    objRecord.objSignerArr[i].m_strFORMID_VCHR = "frmEMR_CesareanRecord";
            //    objRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount = m_lsvAssistant1.Items.Count;

            //for (int i = 0; i < m_lsvAssistant2.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvAssistant2.Items[i].Tag);
            //    objRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvAssistant2";
            //    objRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmEMR_CesareanRecord";
            //    objRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvAssistant2.Items.Count;

            //objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            //objRecord.objSignerArr[currentSignCount].controlName = "txtSign";
            //objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_CesareanRecord";
            //objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //currentSignCount++;

            //if (m_txtAnaesthetist.Tag != null)
            //{
            //    objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(m_txtAnaesthetist.Tag);
            //    objRecord.objSignerArr[currentSignCount].controlName = "m_txtAnaesthetist";
            //    objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_CesareanRecord";
            //    objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    currentSignCount++;
            //}

            //if (m_txtOperator.Tag != null)
            //{
            //    objRecord.objSignerArr[currentSignCount] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount].objEmployee = (clsEmrEmployeeBase_VO)(m_txtOperator.Tag);
            //    objRecord.objSignerArr[currentSignCount].controlName = "m_txtOperator";
            //    objRecord.objSignerArr[currentSignCount].m_strFORMID_VCHR = "frmEMR_CesareanRecord";
            //    objRecord.objSignerArr[currentSignCount].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            #endregion

            objRecord.m_dtmRECORDDATE = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objRecord.m_dtmOPDATE = Convert.ToDateTime(m_dtpOPDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objRecord.m_intMarkStatus = 0;
            else
                objRecord.m_intMarkStatus = 1;
            #endregion
            try
            {
                if (string.IsNullOrEmpty(m_cboPregnantTimes.Text))
                {
                    //objRecord.m_intPREGNANTTIMES = -1;
                }
                else
                {
                    int i = -1;
                    if (Int32.TryParse(this.m_cboPregnantTimes.Text.Trim(), out i) && i >= 0)
                        objRecord.m_intPREGNANTTIMES = i;
                    //objRecord.m_intPREGNANTTIMES = int.Parse(m_cboPregnantTimes.Text);
                    else
                    {
                        this.m_cboPregnantTimes.Text = "";
                        this.m_cboPregnantTimes.Focus();
                    }
                }
                if (string.IsNullOrEmpty(m_cboLayTimes.Text))
                {
                    //objRecord.m_intLAYTIMES = -1;
                }
                else
                {
                    int j = -1;
                    if (Int32.TryParse(this.m_cboLayTimes.Text.Trim(), out j) && j >= 0)
                        objRecord.m_intLAYTIMES = j;
                    //objRecord.m_intLAYTIMES = int.Parse(m_cboLayTimes.Text);
                    else
                    {
                        this.m_cboLayTimes.Text = "";
                        this.m_cboLayTimes.Focus();
                    }
                }
            }
            catch
            {
                clsPublicFunction.ShowInformationMessageBox("孕、产次中填入了非整数！");
                return null;
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

            objRecord.m_strOPNAME = m_txtOPName.Text;
            objRecord.m_strOPNAME_RIGHT = m_txtOPName.m_strGetRightText();
            objRecord.m_strOPNAMEXML = m_txtOPName.m_strGetXmlText();

            objRecord.m_strANAMODE = m_txtAnaMode.Text;
            objRecord.m_strANAMODE_RIGHT = m_txtAnaMode.m_strGetRightText();
            objRecord.m_strANAMODEXML = m_txtAnaMode.m_strGetXmlText();

            objRecord.m_strUTERUSHEIGHT = m_txtUterueHeight.Text;
            objRecord.m_strUTERUSHEIGHT_RIGHT = m_txtUterueHeight.m_strGetRightText();
            objRecord.m_strUTERUSHEIGHTXML = m_txtUterueHeight.m_strGetXmlText();

            objRecord.m_strABDOMENROUND = m_txtAbdomenRound.Text;
            objRecord.m_strABDOMENROUND_RIGHT = m_txtAbdomenRound.m_strGetRightText();
            objRecord.m_strABDOMENROUNDXML = m_txtAbdomenRound.m_strGetXmlText();

            objRecord.m_strPRESENTATION1 = m_txtPresentation1.Text;
            objRecord.m_strPRESENTATION1_RIGHT = m_txtPresentation1.m_strGetRightText();
            objRecord.m_strPRESENTATION1XML = m_txtPresentation1.m_strGetXmlText();

            string strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkLinkup1.Checked) + m_strBoolean(m_chkLinkup2.Checked)
                + m_strBoolean(m_chkLinkup3.Checked);
            objRecord.m_strLINKUP = strCheck;

            objRecord.m_strFETUSWEIGHT = m_txtFetusWeight.Text;
            objRecord.m_strFETUSWEIGHT_RIGHT = m_txtFetusWeight.m_strGetRightText();
            objRecord.m_strFETUSWEIGHTXML = m_txtFetusWeight.m_strGetXmlText();

            objRecord.m_strUnCheckBeforeOP = m_strBoolean(m_chkUnCheckBeforeOP.Checked);

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

            objRecord.m_strPUBICARCH = m_txtPubicArch.Text;
            objRecord.m_strPUBICARCH_RIGHT = m_txtPubicArch.m_strGetRightText();
            objRecord.m_strPUBICARCHXML = m_txtPubicArch.m_strGetXmlText();

            objRecord.m_strDC = m_txtDC.Text;
            objRecord.m_strDC_RIGHT = m_txtDC.m_strGetRightText();
            objRecord.m_strDCXML = m_txtDC.m_strGetXmlText();

            objRecord.m_strUTERUSORA = m_txtUterusora.Text;
            objRecord.m_strUTERUSORA_RIGHT = m_txtUterusora.m_strGetRightText();
            objRecord.m_strUTERUSORAXML = m_txtUterusora.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkAmniocentesis11.Checked) + m_strBoolean(m_chkAmniocentesis12.Checked)
            + m_strBoolean(m_chkAmniocentesis13.Checked) + m_strBoolean(m_chkAmniocentesis14.Checked);
            objRecord.m_strAMNIOCENTESIS1 = strCheck;

            objRecord.m_strPRESENTATION2 = m_txtPresentation2.Text;
            objRecord.m_strPRESENTATION2_RIGHT = m_txtPresentation2.m_strGetRightText();
            objRecord.m_strPRESENTATION2XML = m_txtPresentation2.m_strGetXmlText();

            objRecord.m_strFETUSPLACE1 = m_txtFetusPlace1.Text;
            objRecord.m_strFETUSPLACE1_RIGHT = m_txtFetusPlace1.m_strGetRightText();
            objRecord.m_strFETUSPLACE1XML = m_txtFetusPlace1.m_strGetXmlText();

            objRecord.m_strPRESENTATIONHEITHT = m_txtPresentationHeight.Text;
            objRecord.m_strPRESENTATIONHEITHT_RIGHT = m_txtPresentationHeight.m_strGetRightText();
            objRecord.m_strPRESENTATIONHEITHTXML = m_txtPresentationHeight.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkull1.Checked) + m_strBoolean(m_chkSkull2.Checked);
            objRecord.m_strSKULL = strCheck;

            objRecord.m_strCAPUTSUCCEDANEUMSIZE = m_txtCaputSuccedaneumSize.Text;
            objRecord.m_strCAPUTSUCCEDANEUMSIZE_RIGHT = m_txtCaputSuccedaneumSize.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMSIZEXML = m_txtCaputSuccedaneumSize.m_strGetXmlText();

            objRecord.m_strCAPUTSUCCEDANEUMPLACE1 = m_txtCaputSuccedaneumPlace1.Text;
            objRecord.m_strCAPUTSUCCEDANEUMPLACE1_RIGHT = m_txtCaputSuccedaneumPlace1.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMPLACE1XML = m_txtCaputSuccedaneumPlace1.m_strGetXmlText();

            objRecord.m_strABDOMINALWALL_V = m_txtAbdominalWall_V.Text;
            objRecord.m_strABDOMINALWALL_V_RIGHT = m_txtAbdominalWall_V.m_strGetRightText();
            objRecord.m_strABDOMINALWALL_VXML = m_txtAbdominalWall_V.m_strGetXmlText();

            objRecord.m_strABDOMINALWALL_H = m_txtAbdominalWall_H.Text;
            objRecord.m_strABDOMINALWALL_H_RIGHT = m_txtAbdominalWall_H.m_strGetRightText();
            objRecord.m_strABDOMINALWALL_HXML = m_txtAbdominalWall_H.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkFascia1.Checked) + m_strBoolean(m_chkFascia2.Checked)
            + m_strBoolean(m_chkFascia3.Checked) + m_strBoolean(m_chkFascia4.Checked);
            objRecord.m_strFASCIA = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkPeritoneum1.Checked) + m_strBoolean(m_chkPeritoneum2.Checked)
            + m_strBoolean(m_chkPeritoneum3.Checked) + m_strBoolean(m_chkPeritoneum4.Checked)
            + m_strBoolean(m_chkPeritoneum5.Checked) + m_strBoolean(m_chkPeritoneum6.Checked);
            objRecord.m_strPERITONEUM = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkUterus1.Checked) + m_strBoolean(m_chkUterus2.Checked)
            + m_strBoolean(m_chkUterus3.Checked) + m_strBoolean(m_chkUterus4.Checked);
            objRecord.m_strUTERUS = strCheck;

            objRecord.m_strFETUSPLACE2 = m_txtFetusPlace2.Text;
            objRecord.m_strFETUSPLACE2_RIGHT = m_txtFetusPlace2.m_strGetRightText();
            objRecord.m_strFETUSPLACE2XML = m_txtFetusPlace2.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkEngagement1.Checked) + m_strBoolean(m_chkEngagement2.Checked)
            + m_strBoolean(m_chkEngagement3.Checked);
            objRecord.m_strENGAGEMENT = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkPresentatonExpulsion1.Checked) + m_strBoolean(m_chkPresentatonExpulsion2.Checked)
            + m_strBoolean(m_chkPresentatonExpulsion3.Checked);
            objRecord.m_strPRESENTATIONEXPULSION = strCheck;

            objRecord.m_dtmEXPULSIONTIME = Convert.ToDateTime(m_dtpExpulsionTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkBabySex1.Checked) + m_strBoolean(m_chkBabySex2.Checked);
            objRecord.m_strBABYSEX = strCheck;

            objRecord.m_strBABYWEIGHT = m_txtBabyWeight.Text;
            objRecord.m_strBABYWEIGHT_RIGHT = m_txtBabyWeight.m_strGetRightText();
            objRecord.m_strBABYWEIGHTXML = m_txtBabyWeight.m_strGetXmlText();

            objRecord.m_strAPGAR = m_txtApgar.Text;
            objRecord.m_strAPGAR_RIGHT = m_txtApgar.m_strGetRightText();
            objRecord.m_strAPGARXML = m_txtApgar.m_strGetXmlText();

            objRecord.m_strFETUSFACIES = m_txtFetusFacies.Text;
            objRecord.m_strFETUSFACIES_RIGHT = m_txtFetusFacies.m_strGetRightText();
            objRecord.m_strFETUSFACIESXML = m_txtFetusFacies.m_strGetXmlText();

            objRecord.m_strCAPUTSUCCEDANEUMSIZEX = m_txtCaputsuccedaneumSezeX.Text;
            objRecord.m_strCAPUTSUCCEDANEUMSIZEX_RIGHT = m_txtCaputsuccedaneumSezeX.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMSIZEXXML = m_txtCaputsuccedaneumSezeX.m_strGetXmlText();

            objRecord.m_strCAPUTSUCCEDANEUMSIZEY = m_txtCaputsuccedaneumSezeY.Text;
            objRecord.m_strCAPUTSUCCEDANEUMSIZEY_RIGHT = m_txtCaputsuccedaneumSezeY.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMSIZEYXML = m_txtCaputsuccedaneumSezeY.m_strGetXmlText();

            objRecord.m_strCAPUTSUCCEDANEUMPLACE2 = m_txtCaputSuccedaneumPlace2.Text;
            objRecord.m_strCAPUTSUCCEDANEUMPLACE2_RIGHT = m_txtCaputSuccedaneumPlace2.m_strGetRightText();
            objRecord.m_strCAPUTSUCCEDANEUMPLACE2XML = m_txtCaputSuccedaneumPlace2.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkAmniocentesis21.Checked) + m_strBoolean(m_chkAmniocentesis22.Checked)
            + m_strBoolean(m_chkAmniocentesis23.Checked) + m_strBoolean(m_chkAmniocentesis24.Checked);
            objRecord.m_strAMNIOCENTESIS2 = strCheck;

            objRecord.m_strAMNIOCENTESISBULK = m_txtAmniocentesisBulk.Text;
            objRecord.m_strAMNIOCENTESISBULK_RIGHT = m_txtAmniocentesisBulk.m_strGetRightText();
            objRecord.m_strAMNIOCENTESISBULKXML = m_txtAmniocentesisBulk.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkEmbryolemmaCircs1.Checked) + m_strBoolean(m_chkEmbryolemmaCircs2.Checked);
            objRecord.m_strEMBRYOLEMMACIRCS = strCheck;

            strCheck = string.Empty;
            strCheck += this.m_strBoolean(this.m_chkOviductCircs1L.Checked) + this.m_strBoolean(this.m_chkOviductCircs2L.Checked) + this.m_strBoolean(this.m_chkOviductCircs1R.Checked) + this.m_strBoolean(this.m_chkOviductCircs2R.Checked);
            objRecord.m_strOVIDUCTCIRCS = strCheck;

            strCheck = string.Empty;
            strCheck += this.m_strBoolean(this.m_chkOvaryCircs1L.Checked) + this.m_strBoolean(this.m_chkOvaryCircs2L.Checked) + this.m_strBoolean(this.m_chkOvaryCircs1R.Checked) + this.m_strBoolean(this.m_chkOvaryCircs2R.Checked);
            objRecord.m_strOVARYCIRCS = strCheck;

            strCheck = string.Empty;
            strCheck += this.m_strBoolean(this.chkHasSuccedaneum1.Checked) + this.m_strBoolean(this.chkNoSuccedaneum1.Checked);
            objRecord.m_strCAPUTSUCCEDANEUMSIZE_YN = strCheck;

            strCheck = string.Empty;
            strCheck += this.m_strBoolean(this.chkHasSuccedaneum2.Checked) + this.m_strBoolean(this.chkNoSuccedaneum2.Checked);
            objRecord.m_strCAPUTSUCCEDANEUMSIZEY_YN = strCheck;


            objRecord.m_strSUTUREUTERUS = m_txtSutureUterus.Text;
            objRecord.m_strSUTUREUTERUS_RIGHT = m_txtSutureUterus.m_strGetRightText();
            objRecord.m_strSUTUREUTERUSXML = m_txtSutureUterus.m_strGetXmlText();

            objRecord.m_strSUTUREABDOMINALWALL = m_txtSutureAbdominalWall.Text;
            objRecord.m_strSUTUREABDOMINALWALL_RIGHT = m_txtSutureAbdominalWall.m_strGetRightText();
            objRecord.m_strSUTUREABDOMINALWALLXML = m_txtSutureAbdominalWall.m_strGetXmlText();

            objRecord.m_strOXYTOCIN = m_txtOxytocinIMIv.Text;
            objRecord.m_strOXYTOCIN_RIGHT = m_txtOxytocinIMIv.m_strGetRightText();
            objRecord.m_strOXYTOCINXML = m_txtOxytocinIMIv.m_strGetXmlText();

            //objRecord.m_strIM = m_txtIM.Text;
            //objRecord.m_strIM_RIGHT = m_txtIM.m_strGetRightText();
            //objRecord.m_strIMXML = m_txtIM.m_strGetXmlText();

            //objRecord.m_strIV = m_txtiv.Text;
            //objRecord.m_strIV_RIGHT = m_txtiv.m_strGetRightText();
            //objRecord.m_strIVXML = m_txtiv.m_strGetXmlText();

            objRecord.m_strOTHERMEDICINE = m_txtOtherMedicine.Text;
            objRecord.m_strOTHERMEDICINE_RIGHT = m_txtOtherMedicine.m_strGetRightText();
            objRecord.m_strOTHERMEDICINEXML = m_txtOtherMedicine.m_strGetXmlText();

            objRecord.m_strPISS = m_txtPiss.Text;
            objRecord.m_strPISS_RIGHT = m_txtPiss.m_strGetRightText();
            objRecord.m_strPISSXML = m_txtPiss.m_strGetXmlText();

            objRecord.m_strBLEEDING = m_txtBleeding.Text;
            objRecord.m_strBLEEDING_RIGHT = m_txtBleeding.m_strGetRightText();
            objRecord.m_strBLEEDINGXML = m_txtBleeding.m_strGetXmlText();

            objRecord.m_strTRANSFUSE = m_txtTransfuse.Text;
            objRecord.m_strTRANSFUSE_RIGHT = m_txtTransfuse.m_strGetRightText();
            objRecord.m_strTRANSFUSEXML = m_txtTransfuse.m_strGetXmlText();

            objRecord.m_strANATIME = m_cboANATime.Text;
            objRecord.m_strOPTime = m_cboOPTime.Text;

            objRecord.m_strPLACENTA = m_txtPLACENTA.Text;
            objRecord.m_strPLACENTA_RIGHT = m_txtPLACENTA.m_strGetRightText();
            objRecord.m_strPLACENTAXML = m_txtPLACENTA.m_strGetXmlText();

            objRecord.m_strUMBILICALCORD = m_txtUMBILICALCORD.Text;
            objRecord.m_strUMBILICALCORD_RIGHT = m_txtUMBILICALCORD.m_strGetRightText();
            objRecord.m_strUMBILICALCORDXML = m_txtUMBILICALCORD.m_strGetXmlText();

            objRecord.m_strFETALHEARTSOUND = string.Empty;
            objRecord.m_strFETALHEARTSOUND_RIGHT = string.Empty;
            objRecord.m_strFETALHEARTSOUNDXML = string.Empty;

            objRecord.m_strBP = string.Empty;
            objRecord.m_strBP_RIGHT = string.Empty;
            objRecord.m_strBPXML = string.Empty;

            objRecord.m_strPLACENTACIRCSAFTEROP = string.Empty;
            objRecord.m_strPLACENTACIRCSAFTEROP_RIGHT = string.Empty;
            objRecord.m_strPLACENTACIRCSAFTEROPXML = string.Empty;

            objRecord.m_strSUMARY4 = m_txtSumary4.Text;
            objRecord.m_strSUMARY4_RIGHT = m_txtSumary4.m_strGetRightText();
            objRecord.m_strSUMARY4XML = m_txtSumary4.m_strGetXmlText();

            objRecord.m_strASSISTANT1 = m_lsvAssistant1.Text;
            objRecord.m_strASSISTANT2 = m_lsvAssistant2.Text;

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

            clsEMR_CesareanRecordValue objRecord = p_objContent as clsEMR_CesareanRecordValue;
            if (objRecord == null) return;
            m_dtpCreateDate.Value = objRecord.m_dtmRECORDDATE;
            m_lngCurrentEMR_SEQ = objRecord.m_lngEMR_SEQ;

            #region 签名集合
            if (objRecord.objSignerArr != null)
            {
                m_mthAddSignToTextBoxBase(new TextBoxBase[] { m_lsvAssistant1, m_lsvAssistant2, txtSign, m_txtOperator, m_txtAnaesthetist }, objRecord.objSignerArr, new bool[] { true, true, true, true, true }, false);

                //m_lsvAssistant1.Items.Clear();
                //m_lsvAssistant2.Items.Clear();
                //txtSign.Tag = null;
                //txtSign.Clear();
                //m_txtOperator.Tag = null;
                //m_txtOperator.Clear();
                //m_txtAnaesthetist.Tag = null;
                //m_txtAnaesthetist.Clear();

                //for (int i = 0; i < objRecord.objSignerArr.Length; i++)
                //{
                //    if (objRecord.objSignerArr[i].controlName == "m_lsvAssistant1")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvAssistant1.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_lsvAssistant2")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvAssistant2.Items.Add(lviNewItem);
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
            m_cboLayTimes.Text = objRecord.m_intLAYTIMES < 0 ? "" : objRecord.m_intLAYTIMES.ToString();
            m_cboPregnantTimes.Text = objRecord.m_intPREGNANTTIMES < 0 ? "" : objRecord.m_intPREGNANTTIMES.ToString();
            //m_cboLayTimes.Text = objRecord.m_intLAYTIMES == -1 ? "" : objRecord.m_intLAYTIMES.ToString();
            //m_cboPregnantTimes.Text = objRecord.m_intPREGNANTTIMES == -1 ? "" : objRecord.m_intPREGNANTTIMES.ToString(); 
            
            m_txtDiagnosisBeforeOP.m_mthSetNewText(objRecord.m_strDIAGNOSISBEFOREOP, objRecord.m_strDIAGNOSISBEFOREOPXML);
            m_txtOPIndication.m_mthSetNewText(objRecord.m_strOPINDICATION, objRecord.m_strOPINDICATIONXML);
            m_txtDiagnosisAfterOP.m_mthSetNewText(objRecord.m_strDIAGNOSISAFTEROP, objRecord.m_strDIAGNOSISAFTEROPXML);
            m_txtOPName.m_mthSetNewText(objRecord.m_strOPNAME, objRecord.m_strOPNAMEXML);
            m_txtAnaMode.m_mthSetNewText(objRecord.m_strANAMODE, objRecord.m_strANAMODEXML);
            m_txtUterueHeight.m_mthSetNewText(objRecord.m_strUTERUSHEIGHT, objRecord.m_strUTERUSHEIGHTXML);
            m_txtAbdomenRound.m_mthSetNewText(objRecord.m_strABDOMENROUND, objRecord.m_strABDOMENROUNDXML);
            m_txtPresentation1.m_mthSetNewText(objRecord.m_strPRESENTATION1, objRecord.m_strPRESENTATION1XML);

            m_chkLinkup1.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(0, 1));
            m_chkLinkup2.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(1, 1));
            m_chkLinkup3.Checked = m_blnGetBooleanBy01(objRecord.m_strLINKUP.Substring(2, 1));

            m_txtFetusWeight.m_mthSetNewText(objRecord.m_strFETUSWEIGHT, objRecord.m_strFETUSWEIGHTXML);

            m_chkUnCheckBeforeOP.Checked = m_blnGetBooleanBy01(objRecord.m_strUnCheckBeforeOP);

            m_chkIschialSpine1.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(0, 1));
            m_chkIschialSpine2.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(1, 1));
            m_chkIschialSpine3.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIALSPINE.Substring(2, 1));

            m_chkCoccyxRadian1.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(0, 1));
            m_chkCoccyxRadian2.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(1, 1));
            m_chkCoccyxRadian3.Checked = m_blnGetBooleanBy01(objRecord.m_strCOCCYXRADIAN.Substring(2, 1));

            m_chkIshiumNotch1.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(0, 1));
            m_chkIshiumNotch2.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(1, 1));
            m_chkIshiumNotch3.Checked = m_blnGetBooleanBy01(objRecord.m_strISCHIUMNOTCH.Substring(2, 1));

            m_txtPubicArch.m_mthSetNewText(objRecord.m_strPUBICARCH, objRecord.m_strPUBICARCHXML);
            m_txtDC.m_mthSetNewText(objRecord.m_strDC, objRecord.m_strDCXML);
            m_txtUterusora.m_mthSetNewText(objRecord.m_strUTERUSORA, objRecord.m_strUTERUSORAXML);

            m_chkAmniocentesis11.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS1.Substring(0, 1));
            m_chkAmniocentesis12.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS1.Substring(1, 1));
            m_chkAmniocentesis13.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS1.Substring(2, 1));
            m_chkAmniocentesis14.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS1.Substring(3, 1));

            m_txtPresentation1.m_mthSetNewText(objRecord.m_strPRESENTATION1, objRecord.m_strPRESENTATION1XML);
            m_txtFetusPlace1.m_mthSetNewText(objRecord.m_strFETUSPLACE1, objRecord.m_strFETUSPLACE1XML);
            m_txtPresentationHeight.m_mthSetNewText(objRecord.m_strPRESENTATIONHEITHT, objRecord.m_strPRESENTATIONHEITHTXML);

            m_chkSkull1.Checked = m_blnGetBooleanBy01(objRecord.m_strSKULL.Substring(0, 1));
            m_chkSkull2.Checked = m_blnGetBooleanBy01(objRecord.m_strSKULL.Substring(1, 1));

            m_txtCaputSuccedaneumSize.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMSIZE, objRecord.m_strCAPUTSUCCEDANEUMSIZEXML);
            m_txtCaputSuccedaneumPlace1.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMPLACE1, objRecord.m_strCAPUTSUCCEDANEUMPLACE1XML);
            m_txtAbdominalWall_V.m_mthSetNewText(objRecord.m_strABDOMINALWALL_V, objRecord.m_strABDOMINALWALL_VXML);
            m_txtAbdominalWall_H.m_mthSetNewText(objRecord.m_strABDOMINALWALL_H, objRecord.m_strABDOMINALWALL_HXML);

            m_chkFascia1.Checked = m_blnGetBooleanBy01(objRecord.m_strFASCIA.Substring(0, 1));
            m_chkFascia2.Checked = m_blnGetBooleanBy01(objRecord.m_strFASCIA.Substring(1, 1));
            m_chkFascia3.Checked = m_blnGetBooleanBy01(objRecord.m_strFASCIA.Substring(2, 1));
            m_chkFascia4.Checked = m_blnGetBooleanBy01(objRecord.m_strFASCIA.Substring(3, 1));

            m_chkPeritoneum1.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(0, 1));
            m_chkPeritoneum2.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(1, 1));
            m_chkPeritoneum3.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(2, 1));
            m_chkPeritoneum4.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(3, 1));
            m_chkPeritoneum5.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(4, 1));
            m_chkPeritoneum6.Checked = m_blnGetBooleanBy01(objRecord.m_strPERITONEUM.Substring(5, 1));

            m_chkUterus1.Checked = m_blnGetBooleanBy01(objRecord.m_strUTERUS.Substring(0, 1));
            m_chkUterus2.Checked = m_blnGetBooleanBy01(objRecord.m_strUTERUS.Substring(1, 1));
            m_chkUterus3.Checked = m_blnGetBooleanBy01(objRecord.m_strUTERUS.Substring(2, 1));
            m_chkUterus4.Checked = m_blnGetBooleanBy01(objRecord.m_strUTERUS.Substring(3, 1));

            m_txtFetusPlace2.m_mthSetNewText(objRecord.m_strFETUSPLACE2, objRecord.m_strFETUSPLACE2XML);

            m_chkEngagement1.Checked = m_blnGetBooleanBy01(objRecord.m_strENGAGEMENT.Substring(0, 1));
            m_chkEngagement2.Checked = m_blnGetBooleanBy01(objRecord.m_strENGAGEMENT.Substring(1, 1));
            m_chkEngagement3.Checked = m_blnGetBooleanBy01(objRecord.m_strENGAGEMENT.Substring(2, 1));

            m_chkPresentatonExpulsion1.Checked = m_blnGetBooleanBy01(objRecord.m_strPRESENTATIONEXPULSION.Substring(0, 1));
            m_chkPresentatonExpulsion2.Checked = m_blnGetBooleanBy01(objRecord.m_strPRESENTATIONEXPULSION.Substring(1, 1));
            m_chkPresentatonExpulsion3.Checked = m_blnGetBooleanBy01(objRecord.m_strPRESENTATIONEXPULSION.Substring(2, 1));

            m_dtpExpulsionTime.Value = objRecord.m_dtmEXPULSIONTIME;

            m_chkBabySex1.Checked = m_blnGetBooleanBy01(objRecord.m_strBABYSEX.Substring(0, 1));
            m_chkBabySex2.Checked = m_blnGetBooleanBy01(objRecord.m_strBABYSEX.Substring(1, 1));

            m_txtBabyWeight.m_mthSetNewText(objRecord.m_strBABYWEIGHT, objRecord.m_strBABYWEIGHTXML);
            m_txtApgar.m_mthSetNewText(objRecord.m_strAPGAR, objRecord.m_strAPGARXML);
            m_txtFetusFacies.m_mthSetNewText(objRecord.m_strFETUSFACIES, objRecord.m_strFETUSFACIESXML);
            m_txtCaputsuccedaneumSezeX.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMSIZEX, objRecord.m_strCAPUTSUCCEDANEUMSIZEXXML);
            m_txtCaputsuccedaneumSezeY.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMSIZEY, objRecord.m_strCAPUTSUCCEDANEUMSIZEYXML);
            m_txtCaputSuccedaneumPlace2.m_mthSetNewText(objRecord.m_strCAPUTSUCCEDANEUMPLACE2, objRecord.m_strCAPUTSUCCEDANEUMPLACE2XML);

            m_chkAmniocentesis21.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS2.Substring(0, 1));
            m_chkAmniocentesis22.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS2.Substring(1, 1));
            m_chkAmniocentesis23.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS2.Substring(2, 1));
            m_chkAmniocentesis24.Checked = m_blnGetBooleanBy01(objRecord.m_strAMNIOCENTESIS2.Substring(3, 1));

            m_txtAmniocentesisBulk.m_mthSetNewText(objRecord.m_strAMNIOCENTESISBULK, objRecord.m_strAMNIOCENTESISBULKXML);         
           
            m_chkEmbryolemmaCircs1.Checked = m_blnGetBooleanBy01(objRecord.m_strEMBRYOLEMMACIRCS.Substring(0, 1));
            m_chkEmbryolemmaCircs2.Checked = m_blnGetBooleanBy01(objRecord.m_strEMBRYOLEMMACIRCS.Substring(1, 1));

            m_chkOviductCircs1L.Checked = m_blnGetBooleanBy01(objRecord.m_strOVIDUCTCIRCS.Substring(0, 1));
            m_chkOviductCircs2L.Checked = m_blnGetBooleanBy01(objRecord.m_strOVIDUCTCIRCS.Substring(1, 1));
            this.m_chkOviductCircs1R.Checked = this.m_blnGetBooleanBy01(objRecord.m_strOVIDUCTCIRCS.Substring(2, 1));
            this.m_chkOviductCircs2R.Checked = this.m_blnGetBooleanBy01(objRecord.m_strOVIDUCTCIRCS.Substring(3, 1));

            m_chkOvaryCircs1L.Checked = m_blnGetBooleanBy01(objRecord.m_strOVARYCIRCS.Substring(0, 1));
            m_chkOvaryCircs2L.Checked = m_blnGetBooleanBy01(objRecord.m_strOVARYCIRCS.Substring(1, 1));
            this.m_chkOvaryCircs1R.Checked = this.m_blnGetBooleanBy01(objRecord.m_strOVARYCIRCS.Substring(2, 1));
            this.m_chkOvaryCircs2R.Checked = this.m_blnGetBooleanBy01(objRecord.m_strOVARYCIRCS.Substring(3, 1));

            m_txtSutureUterus.m_mthSetNewText(objRecord.m_strSUTUREUTERUS, objRecord.m_strSUTUREUTERUSXML);
            m_txtSutureAbdominalWall.m_mthSetNewText(objRecord.m_strSUTUREABDOMINALWALL, objRecord.m_strSUTUREABDOMINALWALLXML);
            m_txtOxytocinIMIv.m_mthSetNewText(objRecord.m_strOXYTOCIN, objRecord.m_strOXYTOCINXML);
            //m_txtIM.m_mthSetNewText(objRecord.m_strIM, objRecord.m_strIMXML);
            //m_txtiv.m_mthSetNewText(objRecord.m_strIV, objRecord.m_strIVXML);
            this.chkHasSuccedaneum1.Checked = this.m_blnGetBooleanBy01(objRecord.m_strCAPUTSUCCEDANEUMSIZE_YN.Substring(0, 1));
            this.chkNoSuccedaneum1.Checked = this.m_blnGetBooleanBy01(objRecord.m_strCAPUTSUCCEDANEUMSIZE_YN.Substring(1, 1));
            this.chkHasSuccedaneum2.Checked = this.m_blnGetBooleanBy01(objRecord.m_strCAPUTSUCCEDANEUMSIZEY_YN.Substring(0, 1));
            this.chkNoSuccedaneum2.Checked = this.m_blnGetBooleanBy01(objRecord.m_strCAPUTSUCCEDANEUMSIZEY_YN.Substring(1, 1));


            m_txtOtherMedicine.m_mthSetNewText(objRecord.m_strOTHERMEDICINE, objRecord.m_strOTHERMEDICINEXML);
            m_txtPiss.m_mthSetNewText(objRecord.m_strPISS, objRecord.m_strPISSXML);
            m_txtBleeding.m_mthSetNewText(objRecord.m_strBLEEDING, objRecord.m_strBLEEDINGXML);
            m_txtTransfuse.m_mthSetNewText(objRecord.m_strTRANSFUSE, objRecord.m_strTRANSFUSEXML);

            m_cboOPTime.Text = objRecord.m_strOPTime;
            m_cboANATime.Text = objRecord.m_strANATIME;

            m_txtPLACENTA.m_mthSetNewText(objRecord.m_strPLACENTA, objRecord.m_strPLACENTAXML);
            m_txtUMBILICALCORD.m_mthSetNewText(objRecord.m_strUMBILICALCORD, objRecord.m_strUMBILICALCORDXML);

            bool blnIsOldData = false;//是否是旧数据
            if (!string.IsNullOrEmpty(objRecord.m_strFETALHEARTSOUND))
            {
                blnIsOldData = true;
                m_txtSumary4.Text += "麻醉成功后，手术台上听胎心音" + objRecord.m_strFETALHEARTSOUND_RIGHT + "次/ 分。" ;
            }
            if (!string.IsNullOrEmpty(objRecord.m_strBP))
            {
                blnIsOldData = true;
                m_txtSumary4.Text += System.Environment.NewLine + "手术经过顺利，麻醉满意，术中母婴在手术室已行早接触，产妇回病房时过床血压"
                    + objRecord.m_strBP_RIGHT + "mmHg，并行早吸吮30分钟。" ;
            }
            if (!string.IsNullOrEmpty(objRecord.m_strMEDICINEAFTEROP))
            {
                blnIsOldData = true;
                m_txtSumary4.Text += System.Environment.NewLine + "因剖宫产为II类切口，术中断脐后即予" + objRecord.m_strMEDICINEAFTEROP 
                    + "静脉滴注预防感染，术后继续抗炎治疗";
            }
            if (!string.IsNullOrEmpty(objRecord.m_strPLACENTACIRCSAFTEROP))
            {
                blnIsOldData = true;
                m_txtSumary4.Text += "因胎盘，" + objRecord.m_strPLACENTACIRCSAFTEROP + "，术后胎盘胎膜送病理检查以明确诊断。";
            }
            if (blnIsOldData && !string.IsNullOrEmpty(objRecord.m_strSUMARY4))
            {
                m_txtSumary4.Text += System.Environment.NewLine + objRecord.m_strSUMARY4_RIGHT;
            }
            else if (!blnIsOldData)
            {
                m_txtSumary4.m_mthSetNewText(objRecord.m_strSUMARY4, objRecord.m_strSUMARY4XML);
            }
            
            if (string.IsNullOrEmpty(m_lsvAssistant2.Text.Trim()))
            {
                m_lsvAssistant2.Text = objRecord.m_strASSISTANT2;
            }
            if (string.IsNullOrEmpty(m_lsvAssistant1.Text.Trim()))
            {
                m_lsvAssistant1.Text = objRecord.m_strASSISTANT1;
            }

            #region 获取旧数据
            if (string.IsNullOrEmpty(m_txtPLACENTA.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(objRecord.m_strPLACENTASIZEX_RIGHT)
                    || !string.IsNullOrEmpty(objRecord.m_strPLACENTASIZEY_RIGHT)
                    || !string.IsNullOrEmpty(objRecord.m_strPLACENTASIZEZ_RIGHT))
                {
                    m_txtPLACENTA.Text += objRecord.m_strPLACENTASIZEX_RIGHT + "×"
                        + objRecord.m_strPLACENTASIZEY_RIGHT + "×"
                        + objRecord.m_strPLACENTASIZEZ_RIGHT + "cm";
                }

                if (!string.IsNullOrEmpty(objRecord.m_strPLACENTASIZEWEIGHT_RIGHT))
                {
                    m_txtPLACENTA.Text += ",重" + objRecord.m_strPLACENTASIZEWEIGHT_RIGHT + "g";
                }
                if (!string.IsNullOrEmpty(objRecord.m_strPLACENTACALCIFY))
                {
                    if (objRecord.m_strPLACENTACALCIFY[0].ToString() == "1")
                    {
                        m_txtPLACENTA.Text += ",有钙化";
                    }
                    else if (objRecord.m_strPLACENTACALCIFY[1].ToString() == "1")
                    {
                        m_txtPLACENTA.Text += ",无钙化";
                    }
                }
            }
            if (string.IsNullOrEmpty(m_txtUMBILICALCORD.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(objRecord.m_strUMBILICALCORDLENGTH_RIGHT))
                {
                    m_txtUMBILICALCORD.Text += "长" + objRecord.m_strUMBILICALCORDLENGTH_RIGHT + "cm";
                }
                if (!string.IsNullOrEmpty(objRecord.m_strUMBILICALCORDCIRCS))
                {
                    if (objRecord.m_strUMBILICALCORDCIRCS[0].ToString() == "1")
                    {
                        m_txtUMBILICALCORD.Text += ",有";
                    }
                    else if (objRecord.m_strUMBILICALCORDCIRCS[1].ToString() == "1")
                    {
                        m_txtUMBILICALCORD.Text += ",无";
                    }

                    if (objRecord.m_strUMBILICALCORDCIRCS[2].ToString() == "1")
                    {
                        m_txtUMBILICALCORD.Text += "假结";
                    }
                    if (objRecord.m_strUMBILICALCORDCIRCS[3].ToString() == "1")
                    {
                        m_txtUMBILICALCORD.Text += "、真结";
                    }
                    if (objRecord.m_strUMBILICALCORDCIRCS[4].ToString() == "1")
                    {
                        m_txtUMBILICALCORD.Text += "、扭转";
                    }
                }
            } 
            #endregion
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
                return 133;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_CesareanRecord);
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
            return "剖宫产手术记录";
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHasSuccedaneum1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHasSuccedaneum1.Checked)
            {
                this.m_txtCaputSuccedaneumSize.Enabled = true;
                this.m_txtCaputSuccedaneumSize.Focus();
                this.m_txtCaputSuccedaneumSize.SelectAll();
                this.chkNoSuccedaneum1.Checked = false;
            }
            else
            {
                this.m_txtCaputSuccedaneumSize.Clear();
                this.m_txtCaputSuccedaneumSize.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNoSuccedaneum1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNoSuccedaneum1.Checked)
            {
                this.m_txtCaputSuccedaneumSize.Clear();
                this.m_txtCaputSuccedaneumSize.Enabled = false;
                this.chkHasSuccedaneum1.Checked = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHasSuccedaneum2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHasSuccedaneum2.Checked)
            {
                this.m_txtCaputsuccedaneumSezeX.Enabled = true;
                this.m_txtCaputsuccedaneumSezeY.Enabled = true;
                this.m_txtCaputsuccedaneumSezeX.Focus();
                this.m_txtCaputsuccedaneumSezeX.SelectAll();
                this.chkNoSuccedaneum2.Checked = false;
            }
            else
            {
                this.m_txtCaputsuccedaneumSezeX.Clear();
                this.m_txtCaputsuccedaneumSezeY.Clear();
                this.m_txtCaputsuccedaneumSezeX.Enabled = false;
                this.m_txtCaputsuccedaneumSezeY.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNoSuccedaneum2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNoSuccedaneum2.Checked)
            {
                this.m_txtCaputsuccedaneumSezeX.Clear();
                this.m_txtCaputsuccedaneumSezeY.Clear();
                this.m_txtCaputsuccedaneumSezeX.Enabled = false;
                this.m_txtCaputsuccedaneumSezeY.Enabled = false;
                this.chkHasSuccedaneum2.Checked = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEMR_CesareanRecord_Load(object sender, EventArgs e)
        {
            this.IniPrinter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubPrint()
        {
            this.StartToPrint();
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        private void StartToPrint()
        {
            this.objPrintTool = new clsEMR_CesareanRecordPrintTool();

            this.objPrintTool.m_mthInitPrintTool(null);
            if (base.m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                this.objPrintTool.m_mthSetPrintInfo(base.m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(base.m_objBaseCurrentPatient, base.m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                {
                    base.m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                    this.objPrintTool.m_mthSetPrintInfo(base.m_objBaseCurrentPatient, base.m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
                }
            }
            this.objPrintTool.m_mthInitPrintContent();

            if (m_blnDirectPrint)
            {
               base.m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = this.m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
            //m_mthStartPrint_this();
        }
        /// <summary>
        /// 
        /// </summary>
        private void IniPrinter()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_pdcPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            this.objPrintTool.m_mthBeginPrint(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_pdcPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.objPrintTool.m_mthPrintPage(e);
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_pdcPrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            this.objPrintTool.m_mthEndPrint(e);
        } 
    }
}