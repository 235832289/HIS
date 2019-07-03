using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.controls;
using System.Data;
using HRP;
using System.Xml;
using com.digitalwave.clsGeneralNurseRecord_CSObstetricNewChildService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 茶山一般患者护理记录(产科新生儿)--护理记录子窗体
    /// </summary>
    public partial class frmGeneralNurse_ObstetricNewChildRec : frmDiseaseTrackBase
    {
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        public frmGeneralNurse_ObstetricNewChildRec()
        {
            InitializeComponent();
            m_mthSetRichTextBoxAttribInControl(this);
            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
        }
        public override int m_IntFormID
        {
            get
            {
                return 84;
            }
        }
        private void frmGeneralNurse_ObstetricNewChildRec_Load(object sender, System.EventArgs e)
        {
            m_txtTemperature.Focus();
        }

        public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = this.m_lblForTitle.Text;

            //设置m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
            }
            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容				
            this.m_txtTemperature.m_mthClearText();
            this.m_txtRespiration.m_mthClearText();
            this.m_txtHeartRate.m_mthClearText();
            this.m_cboFontanel.Text = "";
            this.m_cboCaputsuccedaneum.Text = "";
            this.m_cboBloodEdema.Text = "";
            this.m_cboFaceColor.Text = "";
            this.m_cboCry.Text = "";
            this.m_cboSuckPower.Text = "";
            this.m_cboUmbilicalRegion.Text = "";
            this.m_txtStool.m_mthClearText();
            this.m_txtUrine.m_mthClearText();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);
            m_cmdModifyPatientInfo.Visible = false;
        }

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            if (p_blnEnable == false)
            {
                m_cmdOK.Visible = true;
                this.CenterToParent();
            }
            this.MaximizeBox = false;
        }

        /// <summary>
        /// 具体记录的特殊控制,根据子窗体的需要重载实现
        /// </summary>
        /// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {

        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
        ///如果为true，忽略记录内容，把界面控制设置为不控制；
        ///否则根据记录内容进行设置。
        ///</param>
        protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制

        }

        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsGeneralNurseRecordContent_ObstetricNewChild objContent = (clsGeneralNurseRecordContent_ObstetricNewChild)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现			
            this.m_mthClearRecordInfo();
            this.m_txtTemperature.m_mthSetNewText(objContent.m_strTEMPERATUREAll, objContent.m_strTEMPERATUREXML);
            this.m_txtHeartRate.m_mthSetNewText(objContent.m_strHEARTRATE, objContent.m_strHEARTRATEXML);
            this.m_txtRespiration.m_mthSetNewText(objContent.m_strRESPIRATION, objContent.m_strRESPIRATIONXML);
            this.m_cboFontanel.Text = objContent.m_strFONTANEL;
            this.m_cboCaputsuccedaneum.Text = objContent.m_strCAPUTSUCCEDANEUM;
            this.m_cboBloodEdema.Text = objContent.m_strBLOODEDEMA;
            this.m_cboFaceColor.Text = objContent.m_strFACECOLOR;
            this.m_cboCry.Text = objContent.m_strCRY;
            this.m_cboSuckPower.Text = objContent.m_strSUCKPOWER;
            this.m_cboUmbilicalRegion.Text = objContent.m_strUMBILICALREGION;
            this.m_txtStool.m_mthSetNewText(objContent.m_strSTOOL, objContent.m_strSTOOLXML);
            this.m_txtUrine.m_mthSetNewText(objContent.m_strURINE, objContent.m_strURINEXML);
            m_mthAddSignToListView(new ListView[] { lsvSign}, objContent.objSignerArr);
            this.m_dtpCreateDate.Enabled = false;
        }

        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsGeneralNurseRecordContent_ObstetricNewChild objContent = (clsGeneralNurseRecordContent_ObstetricNewChild)p_objContent;

            //把表单值赋值到界面，由子窗体重载实现			
            this.m_mthClearRecordInfo();
            this.m_txtTemperature.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strTEMPERATUREAll, objContent.m_strTEMPERATUREXML);
            this.m_txtHeartRate.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strHEARTRATE, objContent.m_strHEARTRATEXML);
            this.m_txtRespiration.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strRESPIRATION, objContent.m_strRESPIRATIONXML);
            this.m_cboFontanel.Text = objContent.m_strFONTANEL;
            this.m_cboCaputsuccedaneum.Text = objContent.m_strCAPUTSUCCEDANEUM;
            this.m_cboBloodEdema.Text = objContent.m_strBLOODEDEMA;
            this.m_cboFaceColor.Text = objContent.m_strFACECOLOR;
            this.m_cboCry.Text = objContent.m_strCRY;
            this.m_cboSuckPower.Text = objContent.m_strSUCKPOWER;
            this.m_cboUmbilicalRegion.Text = objContent.m_strUMBILICALREGION;
            this.m_txtStool.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strSTOOL, objContent.m_strSTOOLXML);
            this.m_txtUrine.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strURINE, objContent.m_strURINEXML);

        }

        protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
        {

            //界面参数校验
            if (m_objCurrentPatient == null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
                return null;

            #region 处理同一个窗体内的病情记录

            #endregion

            //从界面获取表单值		
            clsGeneralNurseRecordContent_ObstetricNewChild objContent = new clsGeneralNurseRecordContent_ObstetricNewChild();
            try
            {
                objContent.m_dtmCreateDate = DateTime.Now;

                objContent.m_strTEMPERATURE_RIGHT = this.m_txtTemperature.m_strGetRightText();
                objContent.m_strTEMPERATUREAll = this.m_txtTemperature.Text;
                objContent.m_strTEMPERATUREXML = this.m_txtTemperature.m_strGetXmlText();

                objContent.m_strHEARTRATE_RIGHT = this.m_txtHeartRate.m_strGetRightText();
                objContent.m_strHEARTRATE = this.m_txtHeartRate.Text;
                objContent.m_strHEARTRATEXML = this.m_txtHeartRate.m_strGetXmlText();

                objContent.m_strRESPIRATION_RIGHT = this.m_txtRespiration.m_strGetRightText();
                objContent.m_strRESPIRATION = this.m_txtRespiration.Text;
                objContent.m_strRESPIRATIONXML = this.m_txtRespiration.m_strGetXmlText();

                objContent.m_strFONTANEL = this.m_cboFontanel.Text;
                objContent.m_strCAPUTSUCCEDANEUM = this.m_cboCaputsuccedaneum.Text;
                objContent.m_strBLOODEDEMA = this.m_cboBloodEdema.Text;
                objContent.m_strFACECOLOR = this.m_cboFaceColor.Text;
                objContent.m_strCRY = this.m_cboCry.Text;
                objContent.m_strSUCKPOWER = this.m_cboSuckPower.Text;
                objContent.m_strUMBILICALREGION = this.m_cboUmbilicalRegion.Text;

                objContent.m_strSTOOL_RIGHT = this.m_txtStool.m_strGetRightText();
                objContent.m_strSTOOL = this.m_txtStool.Text;
                objContent.m_strSTOOLXML = this.m_txtStool.m_strGetXmlText();

                objContent.m_strURINE_RIGHT = this.m_txtUrine.m_strGetRightText();
                objContent.m_strURINE = this.m_txtUrine.Text;
                objContent.m_strURINEXML = this.m_txtUrine.m_strGetXmlText();

                objContent.m_strCreateUserID = MDIParent.OperatorID;
                objContent.m_dtmModifyDate = DateTime.Now;
                objContent.m_strModifyUserID = MDIParent.OperatorID;
                objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;

                //获取签名s
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return (objContent);
        }

        protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChild);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsGeneralNurseRecordContent_ObstetricNewChild objContent = (clsGeneralNurseRecordContent_ObstetricNewChild)p_objRecordContent;
        }

        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现

            return "一般患者护理记录";
        }

        private void m_cmdOK_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void m_cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        #region Jump Control
        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this,
                new Control[]{m_txtTemperature,m_txtHeartRate,m_txtRespiration,m_cboFontanel,m_cboCaputsuccedaneum,
								 m_cboBloodEdema,m_cboFaceColor,m_cboCry,m_cboSuckPower,m_cboUmbilicalRegion,
                                m_txtStool,m_txtUrine,m_cmbsign,lsvSign,m_cmdOK,m_cmdCancel}, Keys.Enter);
        }
        #endregion
    }
}


