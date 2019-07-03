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
    /// 手术护理记录
    /// </summary>
    public partial class frmEMR_OPNurseRecord_GX : iCare.frmDiseaseTrackBase
    {
        #region 全局变量
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;

        private long m_lngCurrentEMR_SEQ = -1;

        private clsEMR_OPNurseRecordPrintTool objPrintTool;
        #endregion

        #region 构造函数
        public frmEMR_OPNurseRecord_GX()
        {
            InitializeComponent();

            m_mthSetRichTextBoxAttribInControl(this);

            #region 电子签名
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdRecorder, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOperationer, m_lsvOperationer, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAnaDocSign, m_lsvAnaDocSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdWashNurseSign, m_lsvWashNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdCircuitNurseSign, m_lsvCircuitNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID); 
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

            m_cmdRecorder.Enabled = true;
            m_cboOPName.SelectedIndex = -1;
            m_cboOPName.Text = "";

            m_lsvOperationer.Clear();

            m_cboAnaName.SelectedIndex = -1;
            m_cboAnaName.Text = "";

            m_lsvAnaDocSign.Clear();

            m_chkLifeSignAfterOP0.Checked = false;
            m_chkLifeSignAfterOP1.Checked = false;
            m_chkLifeSignAfterOP2.Checked = false;
            m_chkLifeSignAfterOP3.Checked = false;
            m_chkLifeSignAfterOP4.Checked = false;
            m_chkLifeSignAfterOP5.Checked = false;
            m_chkLifeSignAfterOP6.Checked = false;

            m_chkSkinFull0.Checked = false;
            m_chkSkinFull1.Checked = false;

            m_chkSeepBlood0.Checked = false;
            m_chkSeepBlood1.Checked = false;

            m_chkPosture0.Checked = false;
            m_chkPosture1.Checked = false;
            m_chkPosture2.Checked = false;
            m_chkPosture3.Checked = false;
            m_chkPosture4.Checked = false;

            m_chkStanchStrap0.Checked = false;
            m_chkStanchStrap1.Checked = false;
            m_chkStanchStrap2.Checked = false;
            m_chkStanchStrap3.Checked = false;

            m_chkFoley0.Checked = false;
            m_chkFoley1.Checked = false;
            m_chkFoley2.Checked = false;
            m_chkFoley3.Checked = false;
            m_chkFoley4.Checked = false;
            m_chkFoley5.Checked = false;

            m_chkSkinAntisepsis0.Checked = false;
            m_chkSkinAntisepsis1.Checked = false;
            m_chkSkinAntisepsis2.Checked = false;
            m_chkSkinAntisepsis3.Checked = false;
            m_chkSkinAntisepsis4.Checked = false;
            m_chkSkinAntisepsis5.Checked = false;
            m_chkSkinAntisepsis6.Checked = false;

            m_txtWholeBlood.m_mthClearText();
            m_txtRedCell.m_mthClearText();
            m_txtPlasm.m_mthClearText();
            m_txtSelfBlood.m_mthClearText();
            m_txtPlatelet.m_mthClearText();
            m_txtColdDeposit.m_mthClearText();
            m_txtOtherBlood.m_mthClearText();

            m_txtInliquid.m_mthClearText();
            m_txtPiss.m_mthClearText();

            m_chkDrain0.Checked = false;
            m_chkDrain1.Checked = false;

            m_chkSkinBeforeOP0.Checked = false;
            m_chkSkinBeforeOP1.Checked = false;

            m_cboSkinBeforeOP_Desc.SelectedIndex = -1;
            m_cboSkinBeforeOP_Desc.Text = "";

            m_cboSkinBeforeOP_Desc2.SelectedIndex = -1;
            m_cboSkinBeforeOP_Desc2.Text = "";

            m_chkSkinAfterOP0.Checked = false;
            m_chkSkinAfterOP1.Checked = false;
            m_chkSkinAfterOP2.Checked = false;

            m_chkSample0.Checked = false;
            m_chkSample1.Checked = false;
            m_chkSample2.Checked = false;
            m_chkSample3.Checked = false;
            m_chkSample4.Checked = false;

            m_chkAfterOPSend0.Checked = false;
            m_chkAfterOPSend1.Checked = false;
            m_chkAfterOPSend2.Checked = false;

            m_chkGuiding0.Checked = false;
            m_chkGuiding1.Checked = false;

            m_chkHealthEdu0.Checked = false;
            m_chkHealthEdu1.Checked = false;

            m_cboAxenicBag.SelectedIndex = -1;
            m_cboAxenicBag.Text = "";

            m_cboEmbedded.SelectedIndex = -1;
            m_cboEmbedded.Text = "";

            m_txtOPRecord.m_mthClearText();

            m_lsvWashNurseSign.Clear();
            m_lsvCircuitNurseSign.Clear();

            m_mthInitDataGridView();
            m_lngCurrentEMR_SEQ = -1;
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
            if (m_objCurrentPatient == null || this.txtInPatientID.Text != this.m_objCurrentPatient.m_StrHISInPatientID
                || txtInPatientID.Text == "")
                return null;

            if (txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请记录者签名！");
                return null;
            }

            clsEMR_OperationRecord_GX objRecord = new clsEMR_OperationRecord_GX();
            objRecord.m_dtmRecordDate = m_dtpCreateDate.Value;
            clsEmrEmployeeBase_VO objCreat = txtSign.Tag as clsEmrEmployeeBase_VO;
            if (objCreat != null)
            {
                objRecord.m_strCreateUserID = objCreat.m_strEMPNO_CHR;
            }
            objRecord.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            #region 获取签名集合
            int intSignCount = 0;

            intSignCount = m_lsvOperationer.Items.Count + m_lsvAnaDocSign.Items.Count
                + m_lsvWashNurseSign.Items.Count + m_lsvCircuitNurseSign.Items.Count + 1;
            objRecord.objSignerArr = new clsEmrSigns_VO[intSignCount];
            m_mthGetSignArr(new Control[] { m_lsvOperationer, m_lsvAnaDocSign, m_lsvWashNurseSign, m_lsvCircuitNurseSign, txtSign }, ref objRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            //int currentSignCount = 0;
            //for (int i = 0; i < m_lsvOperationer.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvOperationer.Items[i].Tag);
            //    objRecord.objSignerArr[i].controlName = "m_lsvOperationer";
            //    objRecord.objSignerArr[i].m_strFORMID_VCHR = "frmEMR_OPNurseRecord_GX";
            //    objRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount = m_lsvOperationer.Items.Count;

            //for (int i = 0; i < m_lsvAnaDocSign.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvAnaDocSign.Items[i].Tag);
            //    objRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvAnaDocSign";
            //    objRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmEMR_OPNurseRecord_GX";
            //    objRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvAnaDocSign.Items.Count;

            //for (int i = 0; i < m_lsvWashNurseSign.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvWashNurseSign.Items[i].Tag);
            //    objRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvWashNurseSign";
            //    objRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmEMR_OPNurseRecord_GX";
            //    objRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvWashNurseSign.Items.Count;

            //for (int i = 0; i < m_lsvCircuitNurseSign.Items.Count; i++)
            //{
            //    objRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvCircuitNurseSign.Items[i].Tag);
            //    objRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvCircuitNurseSign";
            //    objRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmEMR_OPNurseRecord_GX";
            //    objRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}

            //objRecord.objSignerArr[intSignCount - 1] = new clsEmrSigns_VO();
            //objRecord.objSignerArr[intSignCount - 1].objEmployee = new clsEmrEmployeeBase_VO();
            //objRecord.objSignerArr[intSignCount - 1].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            //objRecord.objSignerArr[intSignCount - 1].controlName = "txtSign";
            //objRecord.objSignerArr[intSignCount - 1].m_strFORMID_VCHR = "frmEMR_OPNurseRecord_GX";
            //objRecord.objSignerArr[intSignCount - 1].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            #endregion

            #region 获取DataGrid内容
            dataGridView1.EndEdit();
            int intRowNum = dataGridView1.Rows.Count;
            objRecord.m_objLimbInfoArr = new clsEMR_OperationRecordLimb_GX[intRowNum];
            string strTimeNow = new clsPublicDomain().m_strGetServerTime();
            for (int i = 0; i < intRowNum; i++)
            {
                objRecord.m_objLimbInfoArr[i] = new clsEMR_OperationRecordLimb_GX();
                objRecord.m_objLimbInfoArr[i].m_dtmInPatientDate = this.m_objCurrentPatient.m_DtmSelectedInDate;
                objRecord.m_objLimbInfoArr[i].m_strInPatientID = this.m_objCurrentPatient.m_StrInPatientID;
                objRecord.m_objLimbInfoArr[i].m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
                objRecord.m_objLimbInfoArr[i].m_dtmModifyDate = DateTime.Parse(strTimeNow);
                objRecord.m_objLimbInfoArr[i].m_dtmOpenDate = DateTime.Parse(strTimeNow);
                objRecord.m_objLimbInfoArr[i].m_strCUBITUS = m_strBoolean(dataGridView1.Rows[i].Cells[0].Value.ToString());
                objRecord.m_objLimbInfoArr[i].m_strLEG = m_strBoolean(dataGridView1.Rows[i].Cells[1].Value.ToString());
                objRecord.m_objLimbInfoArr[i].m_strLEFT = m_strBoolean(dataGridView1.Rows[i].Cells[2].Value.ToString());
                objRecord.m_objLimbInfoArr[i].m_strRIGHT = m_strBoolean(dataGridView1.Rows[i].Cells[3].Value.ToString());
                if (dataGridView1.Rows[i].Cells[4].Value == null)
                    objRecord.m_objLimbInfoArr[i].m_strCHARGETIME = "";
                else
                    objRecord.m_objLimbInfoArr[i].m_strCHARGETIME = dataGridView1.Rows[i].Cells[4].Value.ToString();
                if (dataGridView1.Rows[i].Cells[5].Value == null)
                    objRecord.m_objLimbInfoArr[i].m_strDEFLATETIME = "";
                else
                    objRecord.m_objLimbInfoArr[i].m_strDEFLATETIME = dataGridView1.Rows[i].Cells[5].Value.ToString();
                if (dataGridView1.Rows[i].Cells[6].Value == null)
                    objRecord.m_objLimbInfoArr[i].m_strALLTIME = "";
                else
                    objRecord.m_objLimbInfoArr[i].m_strALLTIME = dataGridView1.Rows[i].Cells[6].Value.ToString();
                if (dataGridView1.Rows[i].Cells[7].Value == null)
                    objRecord.m_objLimbInfoArr[i].m_strPRESS = "";
                else
                    objRecord.m_objLimbInfoArr[i].m_strPRESS = dataGridView1.Rows[i].Cells[7].Value.ToString();
                objRecord.m_objLimbInfoArr[i].m_intOrderID = i;
            }
            #endregion

            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objRecord.m_intMarkStatus = 0;
            else
                objRecord.m_intMarkStatus = 1;
            #endregion
            objRecord.m_strOPNAME = m_cboOPName.Text;
            objRecord.m_strOPNAME_RIGHT = m_cboOPName.Text;

            objRecord.m_strANANAME = m_cboAnaName.Text;
            objRecord.m_strANANAME_RIGHT = m_cboAnaName.Text;

            string strCheck = string.Empty;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkLifeSignAfterOP0.Checked) + m_strBoolean(m_chkLifeSignAfterOP1.Checked)
            + m_strBoolean(m_chkLifeSignAfterOP2.Checked) + m_strBoolean(m_chkLifeSignAfterOP3.Checked)
            + m_strBoolean(m_chkLifeSignAfterOP4.Checked) + m_strBoolean(m_chkLifeSignAfterOP5.Checked)
            + m_strBoolean(m_chkLifeSignAfterOP6.Checked);
            objRecord.m_strLIFTSIGNAFTEROP = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkinFull0.Checked) + m_strBoolean(m_chkSkinFull1.Checked);
            objRecord.m_strSKINFULL = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSeepBlood0.Checked) + m_strBoolean(m_chkSeepBlood1.Checked);
            objRecord.m_strSEEPBLOOD = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkPosture0.Checked) + m_strBoolean(m_chkPosture1.Checked)
            + m_strBoolean(m_chkPosture2.Checked) + m_strBoolean(m_chkPosture3.Checked) + m_strBoolean(m_chkPosture4.Checked);
            objRecord.m_strPOSTURE = strCheck;
            objRecord.m_strOTHERPOSTURE = m_txtOtherPostrue.Text;
            objRecord.m_strOTHERPOSTURE_RIGHT = m_txtOtherPostrue.m_strGetRightText();
            objRecord.m_strOTHERPOSTUREXML = m_txtOtherPostrue.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkStanchStrap0.Checked) + m_strBoolean(m_chkStanchStrap1.Checked)
            + m_strBoolean(m_chkStanchStrap2.Checked) + m_strBoolean(m_chkStanchStrap3.Checked);
            objRecord.m_strSTANCHSTRAP = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkFoley0.Checked) + m_strBoolean(m_chkFoley1.Checked) + m_strBoolean(m_chkFoley2.Checked)
            + m_strBoolean(m_chkFoley3.Checked) + m_strBoolean(m_chkFoley4.Checked) + m_strBoolean(m_chkFoley5.Checked);
            objRecord.m_strFOLEY = strCheck;
            objRecord.m_strOTHERFOLEY = m_txtOtherFoley.Text;
            objRecord.m_strOTHERFOLEY_RIGHT = m_txtOtherFoley.m_strGetRightText();
            objRecord.m_strOTHERFOLEYXML = m_txtOtherFoley.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkinAntisepsis0.Checked) + m_strBoolean(m_chkSkinAntisepsis1.Checked)
            + m_strBoolean(m_chkSkinAntisepsis2.Checked) + m_strBoolean(m_chkSkinAntisepsis3.Checked)
            + m_strBoolean(m_chkSkinAntisepsis4.Checked) + m_strBoolean(m_chkSkinAntisepsis5.Checked)
            + m_strBoolean(m_chkSkinAntisepsis6.Checked);
            objRecord.m_strSKINANTISEPSIS = strCheck;
            objRecord.m_strOTHERSKINANTISEPSIS = m_txtOtherSkinAntisepsis.Text;
            objRecord.m_strOTHERSKINANTISEPSIS_RIGHT = m_txtOtherSkinAntisepsis.m_strGetRightText();
            objRecord.m_strOTHERSKINANTISEPSISXML = m_txtOtherSkinAntisepsis.m_strGetXmlText();

            objRecord.m_strWHOLEBLOOD = m_txtWholeBlood.Text;
            objRecord.m_strWHOLEBLOOD_RIGHT = m_txtWholeBlood.m_strGetRightText();
            objRecord.m_strWHOLEBLOODXML = m_txtWholeBlood.m_strGetXmlText();

            objRecord.m_strREDCELL = m_txtRedCell.Text;
            objRecord.m_strREDCELL_RIGHT = m_txtRedCell.m_strGetRightText();
            objRecord.m_strREDCELLXML = m_txtRedCell.m_strGetXmlText();

            objRecord.m_strPLASM = m_txtPlasm.Text;
            objRecord.m_strPLASM_RIGHT = m_txtPlasm.m_strGetRightText();
            objRecord.m_strPLASMXML = m_txtPlasm.m_strGetXmlText();

            objRecord.m_strSELFBLOOD = m_txtSelfBlood.Text;
            objRecord.m_strSELFBLOOD_RIGHT = m_txtSelfBlood.m_strGetRightText();
            objRecord.m_strSELFBLOODXML = m_txtSelfBlood.m_strGetXmlText();

            objRecord.m_strPLATELET = m_txtPlatelet.Text;
            objRecord.m_strPLATELET_RIGHT = m_txtPlatelet.m_strGetRightText();
            objRecord.m_strPLATELETXML = m_txtPlatelet.m_strGetXmlText();

            objRecord.m_strCOLDDEPOSIT = m_txtColdDeposit.Text;
            objRecord.m_strCOLDDEPOSIT_RIGHT = m_txtColdDeposit.m_strGetRightText();
            objRecord.m_strCOLDDEPOSITXML = m_txtColdDeposit.m_strGetXmlText();

            objRecord.m_strOTHERBLOOD = m_txtOtherBlood.Text;
            objRecord.m_strOTHERBLOOD_RIGHT = m_txtOtherBlood.m_strGetRightText();
            objRecord.m_strOTHERBLOODXML = m_txtOtherBlood.m_strGetXmlText();

            objRecord.m_strINLIQUID = m_txtInliquid.Text;
            objRecord.m_strINLIQUID_RIGHT = m_txtInliquid.m_strGetRightText();
            objRecord.m_strINLIQUIDXML = m_txtInliquid.m_strGetXmlText();

            objRecord.m_strPISS = m_txtPiss.Text;
            objRecord.m_strPISS_RIGHT = m_txtPiss.m_strGetRightText();
            objRecord.m_strPISSXML = m_txtPiss.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkDrain0.Checked) + m_strBoolean(m_chkDrain1.Checked);
            objRecord.m_strDRAIN = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkinBeforeOP0.Checked) + m_strBoolean(m_chkSkinBeforeOP1.Checked);
            objRecord.m_strSKINBEFOREOP = strCheck;
            objRecord.m_strSKINBEFOREOP_DESC = m_cboSkinBeforeOP_Desc.Text;
            objRecord.m_strSKINBEFOREOP_DESC_RIGHT = m_cboSkinBeforeOP_Desc.Text;
            objRecord.m_strSKINBEFOREOP_DESC2 = m_cboSkinBeforeOP_Desc2.Text;
            objRecord.m_strSKINBEFOREOP_DESC2_RIGHT = m_cboSkinBeforeOP_Desc2.Text;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSkinAfterOP0.Checked) + m_strBoolean(m_chkSkinAfterOP1.Checked)
            + m_strBoolean(m_chkSkinAfterOP2.Checked);
            objRecord.m_strSKINAFTEROP = strCheck;
            objRecord.m_strSKINAFTEROP_DESC = m_cboSkinAfterOP_Desc.Text;
            objRecord.m_strSKINAFTEROP_DESC_RIGHT = m_cboSkinAfterOP_Desc.Text;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkSample0.Checked) + m_strBoolean(m_chkSample1.Checked) + m_strBoolean(m_chkSample2.Checked)
            + m_strBoolean(m_chkSample3.Checked) + m_strBoolean(m_chkSample4.Checked);
            objRecord.m_strSAMPLE = strCheck;
            objRecord.m_strOTHERSAMPLE = m_txtOtherSample.Text;
            objRecord.m_strOTHERSAMPLE_RIGHT = m_txtOtherSample.m_strGetRightText();
            objRecord.m_strOTHERSAMPLEXML = m_txtOtherSample.m_strGetXmlText();

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkAfterOPSend0.Checked) + m_strBoolean(m_chkAfterOPSend1.Checked)
            + m_strBoolean(m_chkAfterOPSend2.Checked);
            objRecord.m_strAFTEROPSEND = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkGuiding0.Checked) + m_strBoolean(m_chkGuiding1.Checked);
            objRecord.m_strGUIDING = strCheck;

            strCheck = string.Empty;
            strCheck += m_strBoolean(m_chkHealthEdu0.Checked) + m_strBoolean(m_chkHealthEdu1.Checked);
            objRecord.m_strHEALTHEDU = strCheck;

            objRecord.m_strAXENICBAG = m_cboAxenicBag.Text;
            objRecord.m_strAXENICBAG_RIGHT = m_cboAxenicBag.Text;

            objRecord.m_strEMBEDDED = m_cboEmbedded.Text;
            objRecord.m_strEMBEDDED_RIGHT = m_cboEmbedded.Text;

            objRecord.m_strOPRECORD = m_txtOPRecord.Text;
            objRecord.m_strOPRECORD_RIGHT = m_txtOPRecord.m_strGetRightText();
            objRecord.m_strOPRECORDXML = m_txtOPRecord.m_strGetXmlText();

            objRecord.m_lngEMR_SEQ = m_lngCurrentEMR_SEQ;
            return objRecord;
        }
        #endregion

        #region 将布尔值转换为1或0
        /// <summary>
        /// 将字符串形式的布尔值转换为1或0
        /// </summary>
        /// <param name="p_strBool">布尔值</param>
        /// <returns></returns>
        private string m_strBoolean(string p_strBool)
        {
            if (p_strBool.ToUpper() == "TRUE")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 将布尔值转换为1或0
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

        #region 将0和1转换为布尔值
        /// <summary>
        /// 将0和1转换为字符形式的布尔值
        /// </summary>
        /// <param name="p_strNum">0或1</param>
        /// <returns></returns>
        private string m_strGetBooeanBy01(string p_strNum)
        {
            if (p_strNum == "1")
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        /// <summary>
        /// 将0和1转换为布尔值
        /// </summary>
        /// <param name="p_strNum">0或1</param>
        /// <returns></returns>
        private bool m_blnGetBooeanBy01(string p_strNum)
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

            clsEMR_OperationRecord_GX objRecord = p_objContent as clsEMR_OperationRecord_GX;
            if (objRecord == null) return;
            m_dtpCreateDate.Value = objRecord.m_dtmRecordDate;
            m_lngCurrentEMR_SEQ = objRecord.m_lngEMR_SEQ;

            #region 签名集合
            if (objRecord.objSignerArr != null)
            {
                m_mthAddSignToTextBoxBase(new TextBoxBase[] { txtSign }, objRecord.objSignerArr, new bool[] { true }, false);
                m_mthAddSignToListView(m_lsvOperationer, objRecord.objSignerArr);
                m_mthAddSignToListView(m_lsvAnaDocSign, objRecord.objSignerArr);
                m_mthAddSignToListView(m_lsvWashNurseSign, objRecord.objSignerArr);
                m_mthAddSignToListView(m_lsvCircuitNurseSign, objRecord.objSignerArr);
                //m_lsvOperationer.Items.Clear();
                //m_lsvAnaDocSign.Items.Clear();
                //m_lsvWashNurseSign.Clear();
                //m_lsvCircuitNurseSign.Clear();
                //txtSign.Tag = null;
                //txtSign.Clear();

                //for (int i = 0; i < objRecord.objSignerArr.Length; i++)
                //{
                //    if (objRecord.objSignerArr[i].controlName == "m_lsvOperationer")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvOperationer.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_lsvAnaDocSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvAnaDocSign.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_lsvWashNurseSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvWashNurseSign.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "m_lsvCircuitNurseSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objRecord.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvCircuitNurseSign.Items.Add(lviNewItem);
                //    }
                //    else if (objRecord.objSignerArr[i].controlName == "txtSign")
                //    {
                //        txtSign.Text = objRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        txtSign.Tag = objRecord.objSignerArr[i].objEmployee;
                //    }
                //}
            }
            #endregion

            #region 显示数据到DataGrid
            if (objRecord.m_objLimbInfoArr != null && objRecord.m_objLimbInfoArr.Length > 0)
            {
                dataGridView1.Rows.Clear();
                string[] strRow = new string[8];
                for (int i = 0; i < objRecord.m_objLimbInfoArr.Length; i++)
                {
                    strRow[0] = m_strGetBooeanBy01(objRecord.m_objLimbInfoArr[i].m_strCUBITUS);
                    strRow[1] = m_strGetBooeanBy01(objRecord.m_objLimbInfoArr[i].m_strLEG);
                    strRow[2] = m_strGetBooeanBy01(objRecord.m_objLimbInfoArr[i].m_strLEFT);
                    strRow[3] = m_strGetBooeanBy01(objRecord.m_objLimbInfoArr[i].m_strRIGHT);
                    strRow[4] = objRecord.m_objLimbInfoArr[i].m_strCHARGETIME;
                    strRow[5] = objRecord.m_objLimbInfoArr[i].m_strDEFLATETIME;
                    strRow[6] = objRecord.m_objLimbInfoArr[i].m_strALLTIME;
                    strRow[7] = objRecord.m_objLimbInfoArr[i].m_strPRESS;
                    dataGridView1.Rows.Add(strRow);
                }

                if (objRecord.m_objLimbInfoArr.Length < 5)
                {
                    strRow = new string[8];
                    strRow[0] = "false";
                    strRow[1] = "false";
                    strRow[2] = "false";
                    strRow[3] = "false";
                    for (int i = 0; i < 5 - objRecord.m_objLimbInfoArr.Length; i++)
                    {
                        dataGridView1.Rows.Add(strRow);
                    }
                }
            }
            #endregion

            m_cboOPName.Text = objRecord.m_strOPNAME;

            m_cboAnaName.Text = objRecord.m_strANANAME;

            m_chkLifeSignAfterOP0.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(0, 1));
            m_chkLifeSignAfterOP1.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(1, 1));
            m_chkLifeSignAfterOP2.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(2, 1));
            m_chkLifeSignAfterOP3.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(3, 1));
            m_chkLifeSignAfterOP4.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(4, 1));
            m_chkLifeSignAfterOP5.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(5, 1));
            m_chkLifeSignAfterOP6.Checked = m_blnGetBooeanBy01(objRecord.m_strLIFTSIGNAFTEROP.Substring(6, 1));

            m_chkSkinFull0.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINFULL.Substring(0, 1));
            m_chkSkinFull1.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINFULL.Substring(1, 1));

            m_chkSeepBlood0.Checked = m_blnGetBooeanBy01(objRecord.m_strSEEPBLOOD.Substring(0, 1));
            m_chkSeepBlood1.Checked = m_blnGetBooeanBy01(objRecord.m_strSEEPBLOOD.Substring(1, 1));

            m_chkPosture0.Checked = m_blnGetBooeanBy01(objRecord.m_strPOSTURE.Substring(0, 1));
            m_chkPosture1.Checked = m_blnGetBooeanBy01(objRecord.m_strPOSTURE.Substring(1, 1));
            m_chkPosture2.Checked = m_blnGetBooeanBy01(objRecord.m_strPOSTURE.Substring(2, 1));
            m_chkPosture3.Checked = m_blnGetBooeanBy01(objRecord.m_strPOSTURE.Substring(3, 1));
            m_chkPosture4.Checked = m_blnGetBooeanBy01(objRecord.m_strPOSTURE.Substring(4, 1));
            m_txtOtherPostrue.m_mthSetNewText(objRecord.m_strOTHERPOSTURE, objRecord.m_strOTHERPOSTUREXML);

            m_chkStanchStrap0.Checked = m_blnGetBooeanBy01(objRecord.m_strSTANCHSTRAP.Substring(0, 1));
            m_chkStanchStrap1.Checked = m_blnGetBooeanBy01(objRecord.m_strSTANCHSTRAP.Substring(1, 1));
            m_chkStanchStrap2.Checked = m_blnGetBooeanBy01(objRecord.m_strSTANCHSTRAP.Substring(2, 1));
            m_chkStanchStrap3.Checked = m_blnGetBooeanBy01(objRecord.m_strSTANCHSTRAP.Substring(3, 1));

            m_chkFoley0.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(0, 1));
            m_chkFoley1.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(1, 1));
            m_chkFoley2.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(2, 1));
            m_chkFoley3.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(3, 1));
            m_chkFoley4.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(4, 1));
            m_chkFoley5.Checked = m_blnGetBooeanBy01(objRecord.m_strFOLEY.Substring(5, 1));
            m_txtOtherFoley.m_mthSetNewText(objRecord.m_strOTHERFOLEY, objRecord.m_strOTHERFOLEYXML);

            m_chkSkinAntisepsis0.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(0, 1));
            m_chkSkinAntisepsis1.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(1, 1));
            m_chkSkinAntisepsis2.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(2, 1));
            m_chkSkinAntisepsis3.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(3, 1));
            m_chkSkinAntisepsis4.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(4, 1));
            m_chkSkinAntisepsis5.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(5, 1));
            m_chkSkinAntisepsis6.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINANTISEPSIS.Substring(6, 1));
            m_txtOtherSkinAntisepsis.m_mthSetNewText(objRecord.m_strOTHERSKINANTISEPSIS, objRecord.m_strOTHERSKINANTISEPSISXML);

            m_txtWholeBlood.m_mthSetNewText(objRecord.m_strWHOLEBLOOD, objRecord.m_strWHOLEBLOODXML);
            m_txtRedCell.m_mthSetNewText(objRecord.m_strREDCELL, objRecord.m_strREDCELLXML);
            m_txtPlasm.m_mthSetNewText(objRecord.m_strPLASM, objRecord.m_strPLASMXML);
            m_txtSelfBlood.m_mthSetNewText(objRecord.m_strSELFBLOOD, objRecord.m_strSELFBLOODXML);
            m_txtPlatelet.m_mthSetNewText(objRecord.m_strPLATELET, objRecord.m_strPLATELETXML);
            m_txtColdDeposit.m_mthSetNewText(objRecord.m_strCOLDDEPOSIT, objRecord.m_strCOLDDEPOSITXML);
            m_txtOtherBlood.m_mthSetNewText(objRecord.m_strOTHERBLOOD, objRecord.m_strOTHERBLOODXML);
            m_txtInliquid.m_mthSetNewText(objRecord.m_strINLIQUID, objRecord.m_strINLIQUIDXML);
            m_txtPiss.m_mthSetNewText(objRecord.m_strPISS, objRecord.m_strPISSXML);

            m_chkDrain0.Checked = m_blnGetBooeanBy01(objRecord.m_strDRAIN.Substring(0, 1));
            m_chkDrain1.Checked = m_blnGetBooeanBy01(objRecord.m_strDRAIN.Substring(1, 1));

            m_chkSkinBeforeOP0.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINBEFOREOP.Substring(0, 1));
            m_chkSkinBeforeOP1.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINBEFOREOP.Substring(1, 1));
            m_cboSkinBeforeOP_Desc.Text = objRecord.m_strSKINBEFOREOP_DESC;
            m_cboSkinBeforeOP_Desc2.Text = objRecord.m_strSKINBEFOREOP_DESC2;

            m_chkSkinAfterOP0.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINAFTEROP.Substring(0, 1));
            m_chkSkinAfterOP1.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINAFTEROP.Substring(1, 1));
            m_chkSkinAfterOP2.Checked = m_blnGetBooeanBy01(objRecord.m_strSKINAFTEROP.Substring(2, 1));
            m_cboSkinAfterOP_Desc.Text = objRecord.m_strSKINAFTEROP_DESC;

            m_chkSample0.Checked = m_blnGetBooeanBy01(objRecord.m_strSAMPLE.Substring(0, 1));
            m_chkSample1.Checked = m_blnGetBooeanBy01(objRecord.m_strSAMPLE.Substring(1, 1));
            m_chkSample2.Checked = m_blnGetBooeanBy01(objRecord.m_strSAMPLE.Substring(2, 1));
            m_chkSample3.Checked = m_blnGetBooeanBy01(objRecord.m_strSAMPLE.Substring(3, 1));
            m_chkSample4.Checked = m_blnGetBooeanBy01(objRecord.m_strSAMPLE.Substring(4, 1));
            m_txtOtherSample.m_mthSetNewText(objRecord.m_strOTHERSAMPLE, objRecord.m_strOTHERSAMPLEXML);

            m_chkAfterOPSend0.Checked = m_blnGetBooeanBy01(objRecord.m_strAFTEROPSEND.Substring(0, 1));
            m_chkAfterOPSend1.Checked = m_blnGetBooeanBy01(objRecord.m_strAFTEROPSEND.Substring(1, 1));
            m_chkAfterOPSend2.Checked = m_blnGetBooeanBy01(objRecord.m_strAFTEROPSEND.Substring(2, 1));

            m_chkGuiding0.Checked = m_blnGetBooeanBy01(objRecord.m_strGUIDING.Substring(0, 1));
            m_chkGuiding1.Checked = m_blnGetBooeanBy01(objRecord.m_strGUIDING.Substring(1, 1));

            m_chkHealthEdu0.Checked = m_blnGetBooeanBy01(objRecord.m_strHEALTHEDU.Substring(0, 1));
            m_chkHealthEdu1.Checked = m_blnGetBooeanBy01(objRecord.m_strHEALTHEDU.Substring(1, 1));

            m_cboEmbedded.Text = objRecord.m_strEMBEDDED;
            m_cboAxenicBag.Text = objRecord.m_strAXENICBAG;

            m_txtOPRecord.m_mthSetNewText(objRecord.m_strOPRECORD, objRecord.m_strOPRECORDXML);

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
                return 128;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_OPNurseRecord);
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
            return "手术护理记录";
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
                    return ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR.Trim();
                return "";
            }
        }
        #endregion 属性

        #region 初始化DataGridView
        /// <summary>
        /// 初始化DataGridView(默认5行)
        /// </summary>
        private void m_mthInitDataGridView()
        {
            dataGridView1.Rows.Clear();
            string[] strRow = new string[8];
            strRow[0] = "false";
            strRow[1] = "false";
            strRow[2] = "false";
            strRow[3] = "false";
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add(strRow);
            }
        } 
        #endregion

        #region 外部打印.
        #region 绑定PrintDocument的事件
        /// <summary>
        /// 绑定PrintDocument的事件
        /// </summary>
        private void m_mthfrmLoad()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        } 
        #endregion

        #region 设置打印内容
        /// <summary>
        /// 设置打印内容
        /// </summary>
        private void m_mthDemoPrint_FromDataSource()
        {
            objPrintTool = new clsEMR_OPNurseRecordPrintTool();
            objPrintTool.m_mthInitPrintTool(null);

            if (m_objBaseCurrentPatient == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                if (this.m_trvCreateDate.SelectedNode == null || this.m_trvCreateDate.SelectedNode.Tag == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmLastInDate, DateTime.MinValue);
                else
                {
                    m_objBaseCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.Parse(this.m_trvCreateDate.SelectedNode.Tag.ToString()));
                }
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        } 
        #endregion

        #region 开始打印
        /// <summary>
        /// 开始打印
        /// </summary>
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
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubPrint()
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        } 
        #endregion
        #endregion .
        #endregion

        #region 事件
        #region 实现指定CheckBox单选
        private void m_chkSingle_CheckedChanged(object sender, System.EventArgs e)
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

                if (chkCurrent.Name == "m_chkLifeSignAfterOP3")
                {
                    panel6.Enabled = true;
                }
            }
            else
            {
                if (chkCurrent.Name == "m_chkLifeSignAfterOP3")
                {
                    panel6.Enabled = false;
                    m_chkLifeSignAfterOP4.Checked = false;
                    m_chkLifeSignAfterOP5.Checked = false;
                    m_chkLifeSignAfterOP6.Checked = false;
                }
            }
        }
        #endregion

        #region 其它手术体位
        private void m_chkPosture4_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkPosture4.Checked)
            {
                m_txtOtherPostrue.Enabled = true;
            }
            else
            {
                m_txtOtherPostrue.Enabled = false;
                m_txtOtherPostrue.Clear();
            }
        }
        #endregion

        #region 无Foley氏尿管
        private void m_chkFoley0_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkFoley0.Checked)
            {
                m_chkFoley1.Checked = false;
                m_chkFoley2.Checked = false;
                m_chkFoley3.Checked = false;
                m_chkFoley4.Checked = false;
                m_chkFoley5.Checked = false;

                m_chkFoley1.Enabled = false;
                m_chkFoley2.Enabled = false;
                m_chkFoley3.Enabled = false;
                m_chkFoley4.Enabled = false;
                m_chkFoley5.Enabled = false;
            }
            else
            {
                m_chkFoley1.Enabled = true;
                m_chkFoley2.Enabled = true;
                m_chkFoley3.Enabled = true;
                m_chkFoley4.Enabled = true;
                m_chkFoley5.Enabled = true;
            }
        }
        #endregion

        #region 其它Foley氏尿管
        private void m_chkFoley5_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkFoley5.Checked)
            {
                m_txtOtherFoley.Enabled = true;
            }
            else
            {
                m_txtOtherFoley.Enabled = false;
                m_txtOtherFoley.Clear();
            }
        }
        #endregion

        #region 其它皮肤消毒
        private void m_chkSkinAntisepsis6_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSkinAntisepsis6.Checked)
            {
                m_txtOtherSkinAntisepsis.Enabled = true; ;
            }
            else
            {
                m_txtOtherSkinAntisepsis.Enabled = false;
                m_txtOtherSkinAntisepsis.Clear();
            }
        }
        #endregion

        #region 其它标本
        private void m_chkSample4_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSample4.Checked)
            {
                m_txtOtherSample.Enabled = true;
            }
            else
            {
                m_txtOtherSample.Enabled = false;
                m_txtOtherSample.Clear();
            }
        }
        #endregion 

        #region 插入数据到DataGridView
        private void m_cmdInsert_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选中一行有效数据！");
                return;
            }
            string[] strRow = new string[8];
            strRow[0] = "false";
            strRow[1] = "false";
            strRow[2] = "false";
            strRow[3] = "false";
            dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index, strRow);
        } 
        #endregion

        #region 追加数据到DataGridView
        private void m_cmdSuperadd_Click(object sender, EventArgs e)
        {
            string[] strRow = new string[8];
            strRow[0] = "false";
            strRow[1] = "false";
            strRow[2] = "false";
            strRow[3] = "false";
            dataGridView1.Rows.Add(strRow);
        } 
        #endregion

        #region 从DataGridView删除整行数据
        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选中一行有效数据！");
                return;
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        } 
        #endregion

        #region 清空整个DataGridView
        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_mthInitDataGridView();
        }
        #endregion

        #region 选择DataGridView不同行
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 5)
            {
                m_cmdDelete.Enabled = false;
            }
            else
            {
                m_cmdDelete.Enabled = true;
            }
        } 
        #endregion

        #region 无止血带
        private void m_chkStanchStrap3_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkStanchStrap3.Checked)
            {
                m_chkStanchStrap0.Checked = false;
                m_chkStanchStrap1.Checked = false;
                m_chkStanchStrap2.Checked = false;

                m_chkStanchStrap0.Enabled = false;
                m_chkStanchStrap1.Enabled = false;
                m_chkStanchStrap2.Enabled = false;
            }
            else
            {
                m_chkStanchStrap0.Enabled = true;
                m_chkStanchStrap1.Enabled = true;
                m_chkStanchStrap2.Enabled = true;
            }
        } 
        #endregion

        #region 术后全身皮肤情况同术前
        private void m_chkSkinAfterOP2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSkinAfterOP2.Checked)
            {
                m_cboSkinAfterOP_Desc.SelectedIndex = -1;
                m_cboSkinAfterOP_Desc.Text = "";
                m_cboSkinAfterOP_Desc.Enabled = false;
            }
            else
            {
                m_cboSkinAfterOP_Desc.Enabled = true;
            }
        } 
        #endregion

        #region 无标本
        private void m_chkSample3_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSample3.Checked)
            {
                m_chkSample0.Checked = false;
                m_chkSample1.Checked = false;
                m_chkSample2.Checked = false;
                m_chkSample4.Checked = false;

                m_chkSample0.Enabled = false;
                m_chkSample1.Enabled = false;
                m_chkSample2.Enabled = false;
                m_chkSample4.Enabled = false;
            }
            else
            {
                m_chkSample0.Enabled = true;
                m_chkSample1.Enabled = true;
                m_chkSample2.Enabled = true;
                m_chkSample4.Enabled = true;
            }
        } 
        #endregion

        #region Load窗体
        private void frmEMR_OPNurseRecord_GX_Load(object sender, EventArgs e)
        {
            m_mthInitDataGridView();
            m_mthfrmLoad();
        } 
        #endregion


        #region 打印页
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        } 
        #endregion

        #region 开始打印
        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }        
        #endregion

        #region 结束打印
        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        } 
        #endregion
        #endregion
    }
}