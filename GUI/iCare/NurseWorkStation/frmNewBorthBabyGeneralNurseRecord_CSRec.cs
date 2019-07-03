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
using com.digitalwave.clsGeneralNurseRecord_CSService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 新生儿科一般患者护理记录--护理记录子窗体
    /// </summary>
    public partial class frmNewBorthBabyGeneralNurseRecord_CSRec : frmDiseaseTrackBase
    {
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private DataTable m_dtbInceptInfo = null;
        private DataTable m_dtbEductionInfo = null;
        public frmNewBorthBabyGeneralNurseRecord_CSRec()
        {
            InitializeComponent();
            m_mthInitDataTable();
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
        private void frmNewBorthBabyGeneralNurseRecord_CSRec_Load(object sender, System.EventArgs e)
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
            this.m_txtBoxTemperature.m_mthClearText();
            this.m_txtTemperature.m_mthClearText();
            this.m_txtRespiration.m_mthClearText();
            this.m_txtSaO2.m_mthClearText();
            this.m_txtHeartRate.m_mthClearText();
            this.m_txtBloodPress.m_mthClearText();
            this.m_cboMind.Text = "";
            this.m_cboFace.Text = "";
            this.m_cboQianlu.Text = "";
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
            clsGeneralNurseRecordContent_CS objContent = (clsGeneralNurseRecordContent_CS)p_objContent;

            //把表单值赋值到界面，由子窗体重载实现			
            this.m_mthClearRecordInfo();
            this.m_txtBoxTemperature.m_mthSetNewText(objContent.m_strBOXTEMPERATUREALL, objContent.m_strBOXTEMPERATUREXML);
            this.m_txtTemperature.m_mthSetNewText(objContent.m_strTEMPERATUREAll, objContent.m_strTEMPERATUREXML);
            this.m_txtHeartRate.m_mthSetNewText(objContent.m_strHEARTRATE, objContent.m_strHEARTRATEXML);
            this.m_txtRespiration.m_mthSetNewText(objContent.m_strRESPIRATION, objContent.m_strRESPIRATIONXML);
            this.m_txtBloodPress.m_mthSetNewText(objContent.m_strBLOODPRESSURES, objContent.m_strBLOODPRESSURESXML);
            this.m_txtSaO2.m_mthSetNewText(objContent.m_strSAO2, objContent.m_strSAO2XML);
            this.m_cboMind.Text = objContent.m_strMind;
            this.m_cboFace.Text = objContent.m_dtcFace;
            this.m_cboQianlu.Text = objContent.m_dtcQianlu;
            m_dtbInceptInfo.Clear();
            m_dtbEductionInfo.Clear();
            object[] m_objTemp = new object[2];
            if (objContent.m_objInpectArr != null)
            {
                m_dtbInceptInfo.BeginLoadData();
                for (int i = 0; i < objContent.m_objInpectArr.Length; i++)
                {
                    m_objTemp[0] = objContent.m_objInpectArr[i].m_strINPECT_KIND;
                    m_objTemp[1] = objContent.m_objInpectArr[i].m_strINPECT_METE;
                    m_dtbInceptInfo.LoadDataRow(m_objTemp, true);
                }
                m_dtbInceptInfo.EndLoadData();
            }
            if (objContent.m_objEductionArr != null)
            {
                m_dtbEductionInfo.BeginLoadData();
                for (int i = 0; i < objContent.m_objEductionArr.Length; i++)
                {
                    m_objTemp[0] = objContent.m_objEductionArr[i].m_strEDUCTION_KIND;
                    m_objTemp[1] = objContent.m_objEductionArr[i].m_strEDUCTION_METE;
                    m_dtbEductionInfo.LoadDataRow(m_objTemp, true);
                }
                m_dtbEductionInfo.EndLoadData();
            }
            m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            this.m_dtpCreateDate.Enabled = false;
        }

        protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
        {
            clsGeneralNurseRecordContent_CS objContent = (clsGeneralNurseRecordContent_CS)p_objContent;

            //把表单值赋值到界面，由子窗体重载实现			
            this.m_mthClearRecordInfo();
            this.m_txtBoxTemperature.m_mthSetNewText(objContent.m_strBOXTEMPERATUREALL, objContent.m_strBOXTEMPERATUREXML);
            this.m_txtTemperature.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strTEMPERATUREAll, objContent.m_strTEMPERATUREXML);
            this.m_txtHeartRate.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strHEARTRATE, objContent.m_strHEARTRATEXML);
            this.m_txtRespiration.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strRESPIRATION, objContent.m_strRESPIRATIONXML);
            this.m_txtBloodPress.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSURES, objContent.m_strBLOODPRESSURESXML);
            this.m_txtSaO2.m_mthSetNewText(objContent.m_strSAO2, objContent.m_strSAO2XML);
            this.m_cboMind.Text = objContent.m_strMind;
            this.m_cboFace.Text = objContent.m_dtcFace;
            this.m_cboQianlu.Text = objContent.m_dtcQianlu;
        }

        protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
                return null;

            #region 处理同一个窗体内的病情记录

            #endregion

            //从界面获取表单值		
            clsGeneralNurseRecordContent_CS objContent = new clsGeneralNurseRecordContent_CS();
            try
            {
                objContent.m_dtmCreateDate = DateTime.Now;

                objContent.m_strBOXTEMPERATURE_RIGHT = this.m_txtBoxTemperature.m_strGetRightText();
                objContent.m_strBOXTEMPERATUREALL = this.m_txtBoxTemperature.Text;
                objContent.m_strBOXTEMPERATUREXML = this.m_txtBoxTemperature.m_strGetXmlText();

                objContent.m_strTEMPERATURE_RIGHT = this.m_txtTemperature.m_strGetRightText();
                objContent.m_strTEMPERATUREAll = this.m_txtTemperature.Text;
                objContent.m_strTEMPERATUREXML = this.m_txtTemperature.m_strGetXmlText();

                objContent.m_strHEARTRATE_RIGHT = this.m_txtHeartRate.m_strGetRightText();
                objContent.m_strHEARTRATE = this.m_txtHeartRate.Text;
                objContent.m_strHEARTRATEXML = this.m_txtHeartRate.m_strGetXmlText();

                objContent.m_strRESPIRATION_RIGHT = this.m_txtRespiration.m_strGetRightText();
                objContent.m_strRESPIRATION = this.m_txtRespiration.Text;
                objContent.m_strRESPIRATIONXML = this.m_txtRespiration.m_strGetXmlText();

                objContent.m_strBLOODPRESSURES_RIGHT = this.m_txtBloodPress.m_strGetRightText();
                objContent.m_strBLOODPRESSURES = this.m_txtBloodPress.Text;
                objContent.m_strBLOODPRESSURESXML = this.m_txtBloodPress.m_strGetXmlText();

                objContent.m_strSAO2_RIGHT = this.m_txtSaO2.m_strGetRightText();
                objContent.m_strSAO2 = this.m_txtSaO2.Text;
                objContent.m_strSAO2XML = this.m_txtSaO2.m_strGetXmlText();

                objContent.m_strMind = this.m_cboMind.Text;
                objContent.m_dtcFace = this.m_cboFace.Text;
                objContent.m_dtcQianlu = this.m_cboQianlu.Text;

                objContent.m_objInpectArr = m_objGetInceptInfoArr();
                objContent.m_objEductionArr = m_objGetEductionInfoArr();

                objContent.m_strCreateUserID = MDIParent.OperatorID;
                objContent.m_dtmModifyDate = DateTime.Now;
                objContent.m_strModifyUserID = MDIParent.OperatorID;
                objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;
                objContent.m_intMarkStatus = chkModifyWithoutMatk.Checked ? 0 : 1;

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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.NewBorthBabyGeneralNurseRecord_CS);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsGeneralNurseRecordContent_CS objContent = (clsGeneralNurseRecordContent_CS)p_objRecordContent;
        }

        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现

            return "新生儿科一般患者护理记录";
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
               new Control[]{m_txtBoxTemperature,m_txtTemperature,m_txtHeartRate,m_txtRespiration,m_txtBloodPress,m_txtSaO2,
								 m_cboMind,m_cboFace,m_cboQianlu,lsvSign}, Keys.Enter);                 
        }
        #endregion

        #region 获得摄入内容
        /// <summary>
        /// 获得摄入内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        private clsNurseRecordInpectInfo[] m_objGetInceptInfoArr()
        {
            int m_intRows = m_dtbInceptInfo.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsNurseRecordInpectInfo[] m_objInceptInfoArr = new clsNurseRecordInpectInfo[m_intRows];
            try
            {
                for (int i1 = 0; i1 < m_intRows; i1++)
                {
                    m_objInceptInfoArr[i1] = new clsNurseRecordInpectInfo();
                    m_objInceptInfoArr[i1].m_strFORMID = this.Name;
                    m_objInceptInfoArr[i1].m_strINPECT_KIND = m_dtbInceptInfo.Rows[i1][0].ToString();
                    m_objInceptInfoArr[i1].m_strINPECT_METE = m_dtbInceptInfo.Rows[i1][1].ToString();
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objInceptInfoArr;
        }
        #endregion
        #region 获得排出内容
        /// <summary>
        /// 获得排出内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        private clsNurseRecordEductionInfo[] m_objGetEductionInfoArr()
        {
            int m_intRows = m_dtbEductionInfo.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsNurseRecordEductionInfo[] m_objEductionInfoArr = new clsNurseRecordEductionInfo[m_intRows];
            try
            {
                for (int i1 = 0; i1 < m_intRows; i1++)
                {
                    m_objEductionInfoArr[i1] = new clsNurseRecordEductionInfo();
                    m_objEductionInfoArr[i1].m_strFORMID = this.Name;
                    m_objEductionInfoArr[i1].m_strEDUCTION_KIND = m_dtbEductionInfo.Rows[i1][0].ToString();
                    m_objEductionInfoArr[i1].m_strEDUCTION_METE = m_dtbEductionInfo.Rows[i1][1].ToString();
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objEductionInfoArr;
        }
        #endregion
        private void m_mthInitDataTable()
        {
            DataColumn dtcTemp;

            #region 摄入
            m_dtbInceptInfo = new DataTable("InceptInfo");
            DataColumn dcInceptKind = this.m_dtbInceptInfo.Columns.Add("inceptkind");
            dcInceptKind.DefaultValue = "";
            DataColumn dcInceptMete = this.m_dtbInceptInfo.Columns.Add("inceptmete");
            dcInceptMete.DefaultValue = "";
            dataGrid1.DataSource = m_dtbInceptInfo;
            #endregion

            #region 排出
            m_dtbEductionInfo = new DataTable("EductionInfo");
            DataColumn dcEductionKind = this.m_dtbEductionInfo.Columns.Add("eductionkind");
            dcEductionKind.DefaultValue = "";
            DataColumn dcEductionMete = this.m_dtbEductionInfo.Columns.Add("eductionmete");
            dcEductionMete.DefaultValue = "";
            dataGrid2.DataSource = m_dtbEductionInfo;
            #endregion
        }
    }
}


