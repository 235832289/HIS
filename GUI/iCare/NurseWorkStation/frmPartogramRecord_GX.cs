using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 孕妇产程记录（广西南宁版）
    /// </summary>
    public partial class frmPartogramRecord_GX : frmHRPBaseForm, PublicFunction
    {
        DateTime m_dtmNullDate = new DateTime(1900,1,1);
        private clsEmrSignToolCollection m_objSign;
        clsPartogramDomain m_objDomain;
        clsPartogramAll_VO m_objPartogramRecord;
        private bool m_blnIsEventChange = true;
        private infPrintRecord m_objPrintTool;

        private DateTime m_dtmFirstSave = new DateTime(1900, 1, 1);

        public frmPartogramRecord_GX()
        {
            InitializeComponent();
            //m_mthSetBindingSource();
            m_objSign = new clsEmrSignToolCollection();
            m_mthSetRichTextBoxAttribInControl(this);
            //m_mthBindEmployeeSign(按钮, 签名框, 医生1or护士2, 身份验证trueorfalse, 员工ID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDeliver, m_lsvDeliver, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAsst, m_txtAidUser, 1, false, clsEMRLogin.LoginInfo.m_strEmpID,true);
            m_objDomain = new clsPartogramDomain();
            intFormType = 2;
        }

        #region PublicFunction 成员

        public void Copy()
        {
            
        }

        public void Cut()
        {
            
        }

        public void Delete()
        {
            if (m_objBaseCurrentPatient == null || m_objPartogramRecord == null)
                return;
            long lngRes = m_lngDelete();
            if (lngRes > 0)
            {
                //m_tipMain.Show("删除成功！", this, panel2.PointToScreen(m_txtBreakTime.Location), 2000);
                clsPublicFunction.ShowInformationMessageBox("删除成功！");
            }
            else
            {
                //m_tipMain.Show("删除失败！", this, panel2.PointToScreen(m_txtBreakTime.Location), 2000);
                clsPublicFunction.ShowInformationMessageBox("删除失败！");
            }
        }

        public void Display(string cardno, string sendcheckdate)
        {
            
        }

        public void Display()
        {
            
        }

        public void Paste()
        {
            
        }

        public void Print()
        {
            m_mthDemoPrint_FromDataSource();
        }

        public void Redo()
        {
            
        }

        public void Save()
        {
            if (m_objBaseCurrentPatient == null)
                return;
            long lngRes = m_lngSave();
            if (lngRes > 0)
            {
                //m_tipMain.Show("保存成功！", this, panel2.PointToScreen(m_txtBreakTime.Location), 2000);
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
            }
            else
            {
                //m_tipMain.Show("保存失败！", this, panel2.PointToScreen(m_txtBreakTime.Location), 2000);
                clsPublicFunction.ShowInformationMessageBox("保存失败！");
            }
        }

        public void Undo()
        {
            
        }

        public void Verify()
        {
            
        }

        #endregion

        #region 导航控制 - 暂不用
        private void m_mthSetBindingSource()
        {
            //if (m_ctlPartogram.m_ObjPartogramManager != null)
            //{
            //    m_bidSource.Clear();
            //    int intSource = 0;
            //    int intMax = m_ctlPartogram.m_ObjPartogramManager.m_IntGetMaxRecordCount;
            //    int intTmp = intMax - 1;
            //    if (intTmp != 0)
            //        intSource = (intMax - 1) / 24 + 1;
            //    else
            //        intSource = 1;
            //    for (int i = 1 ; i <= intSource ; i++)
            //        m_bidSource.Add(i);
            //    m_bidSource.EndEdit();
            //    m_bidSource.MoveLast();
            //    if (intMax != 0)
            //        m_ctlPartogram.m_IntSelectPageNumber = intMax / 24;
            //    else
            //        m_ctlPartogram.m_IntSelectPageNumber = 0;
            //}
            //else
            //    m_bidSource.Add(1);
        }

        private void m_cmdFirst_Click(object sender, EventArgs e)
        {
            //m_ctlPartogram.m_IntSelectPageNumber = 0;
            //m_ctlPartogram.m_mthRefreshDispaly();
        }

        private void m_cmdPrevPage_Click(object sender, EventArgs e)
        {
            //int intNum = 0;
            //int.TryParse(m_navBar.PositionItem.Text.Trim(),out intNum);
            //intNum--;
            //m_ctlPartogram.m_IntSelectPageNumber = intNum;
            //m_ctlPartogram.m_mthRefreshDispaly();
        }

        private void m_txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            //int intNum = 0;
            //int.TryParse(m_navBar.PositionItem.Text.Trim(),out intNum);
            //intNum--;
            //if (intNum < 0)
            //    intNum = 0;
            //if (intNum > m_bidSource.Count)
            //    intNum = m_bidSource.Count - 1;
            //m_ctlPartogram.m_IntSelectPageNumber = intNum;
            //m_ctlPartogram.m_mthRefreshDispaly();
        }

        private void m_cmdAddPage_Click(object sender, EventArgs e)
        {
            //int intMax = m_ctlPartogram.m_IntMaxPageNumber;
            //if (m_ctlPartogram.m_IntMaxPageNumber+1 >= m_ctlPartogram.m_IntSelectPageNumber)
            //    m_ctlPartogram.m_IntSelectPageNumber = m_ctlPartogram.m_IntMaxPageNumber + 1;
            //else
            //{
            //    string str = "当前第"+(m_ctlPartogram.m_IntMaxPageNumber+2);
            //    for (int i = m_ctlPartogram.m_IntMaxPageNumber + 3 ; i < m_ctlPartogram.m_IntSelectPageNumber ; i++)
            //        str += "、" + i;
            //    str += "页还没有填写记录，是否继续添加新的空白页？";
            //    if (MessageBox.Show(this, str, "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //        m_ctlPartogram.m_IntSelectPageNumber++;
            //    else
            //    {
            //        m_bidSource.RemoveCurrent() ;
            //    }
            //}
            //m_ctlPartogram.m_mthRefreshDispaly();
        }



        #endregion 导航控制
        protected void m_mthSetRichTextBoxAttrib(Control p_objRichTextBox)
        {
            if (p_objRichTextBox.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                com.digitalwave.controls.ctlRichTextBox objRichTextBox = (com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox;

                objRichTextBox.m_StrUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim();
                objRichTextBox.m_StrUserName = clsEMRLogin.LoginEmployee.m_strLASTNAME_VCHR.Trim();

                objRichTextBox.m_ClrOldPartInsertText = Color.Black;
                objRichTextBox.m_ClrDST = Color.Red;
            }
        }

        protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
        {
            if (p_ctlControl.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                m_mthSetRichTextBoxAttrib(p_ctlControl);
            }

            if (p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextBoxAttribInControl(subcontrol);
                }
            }
        }
        private void m_cmdAddHourRec_Click(object sender, EventArgs e)
        {
            if(this.OwnedForms != null && this.OwnedForms.Length == 1)
            {
                this.OwnedForms[0].BringToFront();
                this.OwnedForms[0].Show();
                return;
            }
            if (m_objBaseCurrentPatient == null)
                return;
            //int[] intH = m_ctlPartogram.m_intGetAvailableHours();
            frmPartogramRecordContent_GX frmSub = new frmPartogramRecordContent_GX(true, DateTime.Now, m_objBaseCurrentPatient.m_StrRegisterId, DateTime.Now, m_txtGiveBirthTime.m_objGetValue());
            frmSub.m_mthSetPatient(m_objBaseCurrentPatient);
            frmSub.FormClosed += new FormClosedEventHandler(frmSub_FormClosed);
            frmSub.Show(this);
        }
        private clsPartogramMain_VO m_objGetMainContentFromGui(out clsPartogramContent_VO p_objContent)
        {
            p_objContent = null;
            clsPartogramMain_VO objMain = new clsPartogramMain_VO();
            DateTime dtmTemp = m_dtmNullDate;

            #region AddMain
            objMain.m_intIFCONFIRM_INT = 0;
            objMain.m_intMarkStatus = 0;
            objMain.m_intSTATUS_INT = 0;

            objMain.m_strALLPARTOGRAM_VCHR = m_txtAllPartogram.Text;
            objMain.m_strALLPARTOGRAM_XML_VCHR = "";
            objMain.m_strCHILDBEARINGWAY_VCHR = m_cboGravidWay.Text;
            objMain.m_strCREATEUSERID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objMain.m_strFIRSTPARTOGRAM_VCHR = m_txtFirstPartogram.Text;
            objMain.m_strFIRSTPARTOGRAM_XML_VCHR = m_txtFirstPartogram.m_strGetXmlText();
            objMain.m_strRECORDUSERID_VCHR = objMain.m_strCREATEUSERID_CHR;
            objMain.m_strSECONDPARTOGRAM_VCHR = m_txtSndPartogram.Text;
            objMain.m_strSECONDPARTOGRAM_XML_VCHR = m_txtSndPartogram.m_strGetXmlText();
            objMain.m_strTHIRDPARTOGRAM_VCHR = m_txtThreePartogram.Text;
            objMain.m_strTHIRDPARTOGRAM_XML_VCHR = m_txtThreePartogram.m_strGetXmlText();
            objMain.m_strRECORDUSERID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objMain.m_strAIDUSER_XML_VCHR = m_txtAidUser.m_strGetXmlText();
            objMain.m_strAIDUSER_VCHR = m_txtAidUser.Text;

            //获取签名
            string strUserIDList = "";
            string strUserNameList = "";
            m_mthGetSignArr(new Control[] { m_lsvDeliver }, ref objMain.objSignerArr, ref strUserIDList, ref strUserNameList);

            #endregion AddMain

            #region AddContent
            p_objContent = new clsPartogramContent_VO();
            DateTime.TryParse(m_txtBreakTime.m_objGetValue(),out dtmTemp);
            p_objContent.m_dtmBREAKTIME_DAT = dtmTemp;
            dtmTemp = m_dtmNullDate;
            DateTime.TryParse(m_txtGiveBirthTime.m_objGetValue(),out dtmTemp);
            p_objContent.m_dtmGIVEBIRTHTIME_DAT = dtmTemp;
            dtmTemp = m_dtmNullDate;
            DateTime.TryParse(m_txtExpectDate.m_objGetValue(), out dtmTemp);
            p_objContent.m_dtmEDC_DAT = dtmTemp;
            dtmTemp = m_dtmNullDate;
            DateTime.TryParse(m_txtMenses.m_objGetValue(), out dtmTemp);
            p_objContent.m_dtmLASTMENSES_DAT = dtmTemp;

            int intTemp = 0;
            int.TryParse(m_txtBorn.m_objGetValue(), out intTemp);
            p_objContent.m_intBORNCOUNT_INT = intTemp;
            intTemp = 0;
            int.TryParse(m_txtGravid.m_objGetValue(), out intTemp);
            p_objContent.m_intGRAVIDITYCOUNT_INT = intTemp;
            intTemp = 0;
            int.TryParse(m_txtHight.m_objGetValue(), out intTemp);
            p_objContent.m_intHEIGHT_INT = intTemp;
            intTemp = 0;
            int.TryParse(m_txtWeight.m_objGetValue(), out intTemp);
            p_objContent.m_intWEIGHT_INT = intTemp;
            p_objContent.m_intSTATUS_INT = 1;
            p_objContent.m_strALLPARTOGRAM_R_VCHR = m_txtAllPartogram.m_strGetRightText();
            p_objContent.m_strCHILDBEARINGWAY_R_VCHR = m_cboGravidWay.Text;
            p_objContent.m_strFIRSTPARTOGRAM_R_VCHR = m_txtFirstPartogram.m_strGetRightText();
            p_objContent.m_strREGISTERID_CHR = m_objBaseCurrentPatient.m_StrRegisterId;
            p_objContent.m_strMODIFYUSERID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
            p_objContent.m_strSECONDPARTOGRAM_R_VCHR = m_txtSndPartogram.m_strGetRightText();
            p_objContent.m_strSEX_VCHR = m_cboSex.Text;
            p_objContent.m_strTHIRDPARTOGRAM_R_VCHR = m_txtThreePartogram.m_strGetRightText();
            p_objContent.m_strAIDUSER_R_VCHR = m_txtAidUser.m_strGetRightText();
            #endregion AddContent

            return objMain;
        }
        #region Overide


        /// <summary>
        /// 病史记录者 
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (m_objPartogramRecord != null)
                {
                    if (m_objPartogramRecord.m_objPartogramMain != null)
                        return m_objPartogramRecord.m_objPartogramMain.m_strCREATEUSERID_CHR;
                }
                return "";
            }
        }
        private bool m_blnIsNew = true;
        protected override bool m_BlnIsAddNew
        {
            get
            {
                return m_blnIsNew;
            }
        }
        protected override long m_lngSubAddNew()
        {
            clsPartogramContent_VO objContent = null;
            clsPartogramMain_VO objMain = m_objGetMainContentFromGui(out objContent);
            if (objMain == null || objContent == null)
                return -1;
            objMain.m_dtmCREATEDATE_DAT = new clsPublicDomain().m_dtmGetServerTime();
            objMain.m_dtmRECORDDATE_DAT = objMain.m_dtmCREATEDATE_DAT;
            objMain.m_strREGISTERID_CHR = m_objBaseCurrentPatient.m_StrRegisterId;
            objContent.m_strREGISTERID_CHR = m_objBaseCurrentPatient.m_StrRegisterId;
            objContent.m_dtmCREATEDATE_DAT = objMain.m_dtmCREATEDATE_DAT;
            objContent.m_dtmMODIFYDATE_DAT = objMain.m_dtmCREATEDATE_DAT;
            //数字签名 兼容考虑 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_objBaseCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(new object[] { objMain, objContent }, objSign_VO) == -1)
                return -1;

            long lngRes = m_objDomain.m_lngAddNewMain(objMain,objContent);
            if (lngRes > 0)
            {
                m_blnIsNew = false;
                if (m_objPartogramRecord == null)
                    m_objPartogramRecord = new clsPartogramAll_VO();
                m_objPartogramRecord.m_objPartogramMain = objMain;
                m_objPartogramRecord.m_objPartogramContent = objContent;
            }
            return lngRes;
        }

        protected override long m_lngSubDelete()
        {
            if (m_objPartogramRecord == null)
                return -1;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentArea.m_strDEPTID_CHR;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_StrRecorder_ID, clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

            long lngRes = m_objDomain.m_lngDeleteMain(m_objPartogramRecord.m_objPartogramMain.m_strREGISTERID_CHR, m_objPartogramRecord.m_objPartogramMain.m_dtmCREATEDATE_DAT);
            if (lngRes > 0)
            {
                m_blnIsNew = true;
                m_objPartogramRecord.m_objPartogramMain = null;
                m_objPartogramRecord.m_objPartogramContent = null;
                m_mthClearAllInfo(null);
            }
            return lngRes;
        }
        protected override long m_lngSubModify()
        {
            clsPartogramContent_VO objContent = null;
            clsPartogramMain_VO objMain = m_objGetMainContentFromGui(out objContent);
            if (objMain == null || objContent == null || m_objPartogramRecord == null)
                return -1;
            objMain.m_dtmCREATEDATE_DAT = m_objPartogramRecord.m_objPartogramMain.m_dtmCREATEDATE_DAT;
            objMain.m_dtmRECORDDATE_DAT = objMain.m_dtmCREATEDATE_DAT;
            objMain.m_strREGISTERID_CHR = m_objBaseCurrentPatient.m_StrRegisterId;
            objContent.m_strREGISTERID_CHR = m_objBaseCurrentPatient.m_StrRegisterId;
            objContent.m_dtmCREATEDATE_DAT = objMain.m_dtmCREATEDATE_DAT;
            objContent.m_dtmMODIFYDATE_DAT = new clsPublicDomain().m_dtmGetServerTime();
            //数字签名 兼容考虑 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_objBaseCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(new object[] { objMain, objContent }, objSign_VO) == -1)
                return -1;

            long lngRes = m_objDomain.m_lngModifyMain(objMain, objContent);
            if (lngRes > 0)
            {
                m_blnIsNew = false;
                m_objPartogramRecord.m_objPartogramMain = objMain;
                m_objPartogramRecord.m_objPartogramContent = objContent;
            }
            return lngRes;
        }
        protected override long m_lngSubPrint()
        {
            return 0;
        }
        protected override void m_mthClearAllInfo(Control p_ctlControl)
        {
            if (m_ctlPartogram == null) return;
            m_txtGravid.m_mthClearValue();
            m_txtBorn.m_mthClearValue();
            m_txtMenses.m_mthClearValue();
            m_txtExpectDate.m_mthClearValue();
            m_txtBreakTime.m_mthClearValue();
            m_txtGiveBirthTime.m_mthClearValue();
            m_cboGravidWay.Text = string.Empty ;
            m_txtFirstPartogram.m_mthClearText();
            m_txtSndPartogram.m_mthClearText();
            m_txtThreePartogram.m_mthClearText();
            m_cboSex.Text = "";
            m_txtWeight.m_mthClearValue();
            m_txtHight.m_mthClearValue();
            m_lsvDeliver.Items.Clear();
            //m_lsvAssit.Items.Clear();
            m_txtAidUser.m_mthClearText();

            m_objPartogramRecord = null;
            m_bidSource.DataSource = 1;
            m_ctlPartogram.m_IntSelectPageNumber = 0;
            m_ctlPartogram.m_ObjPartogramManager.m_mthClear();
            m_blnIsNew = true;
        }
        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            if (p_objSelectedPatient == null)
                return;
            //if (p_objSelectedPatient.m_ObjPeopleInfo != null)
            //{
            //    lblOcupy.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
            //    lblNation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            //    lblNational.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNativePlace;
            //}

            //m_cboInpatientDate.Items.Clear();
            //for (int i = p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount() - 1; i >= 0; i--)
            //{
            //    m_cboInpatientDate.Items.Add(p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));
            //}
            //if (m_cboInpatientDate.Items.Count > 0)
            //    m_cboInpatientDate.SelectedIndex = 0;
        }
        public override string m_StrRecordID
        {
            get
            {
                return base.m_StrRecordID;
            }
        }
        #endregion Override

        #region Event
        void frmSub_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPartogramRecordContent_GX frm = (frmPartogramRecordContent_GX)sender;
            if (frm.DialogResult == DialogResult.OK)
            {
                clsPartogram_VO[] objContentArr = null;
                long lngRes = m_objDomain.m_lngGetAllHourValues(m_objBaseCurrentPatient.m_StrRegisterId,out objContentArr);
                if (lngRes > 0 && objContentArr != null)
                {
                    if (m_objPartogramRecord == null) m_objPartogramRecord = new clsPartogramAll_VO();
                    m_objPartogramRecord.m_ObjPartogramArr = objContentArr;
                    m_ctlPartogram.m_ObjPartogramManager.m_strReAddRange(objContentArr);
                    m_ctlPartogram.m_mthRefreshDispaly();
                }
                objContentArr = null;
            }
        }
        private void m_cboInpatientDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_mthClearAllInfo(this);

            #region Check Power
            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }
            #endregion Check Power

            clsPartogramAll_VO objPartogramAll = null;
            long lngRes = m_objDomain.m_lngGetValues(m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_cboInpatientDate.Items.Count - m_cboInpatientDate.SelectedIndex - 1).m_StrRegisterId, out objPartogramAll);
            if (lngRes <= 0 || objPartogramAll == null)
                return;
            if (objPartogramAll.m_objPartogramMain != null && objPartogramAll.m_objPartogramContent != null)
            {
                m_txtGravid.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intGRAVIDITYCOUNT_INT.ToString());
                m_txtBorn.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intBORNCOUNT_INT.ToString());
                m_txtMenses.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmLASTMENSES_DAT.ToString("yyyy年MM月dd日"));
                m_txtExpectDate.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmEDC_DAT.ToString("yyyy年MM月dd日"));
                m_txtBreakTime.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmBREAKTIME_DAT.ToString("yyyy年MM月dd日 HH时"));
                m_txtGiveBirthTime.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmGIVEBIRTHTIME_DAT.ToString("yyyy年MM月dd日 HH时mm分"));
                m_cboGravidWay.Text = objPartogramAll.m_objPartogramContent.m_strCHILDBEARINGWAY_R_VCHR;
                m_txtFirstPartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strFIRSTPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strFIRSTPARTOGRAM_XML_VCHR);
                m_txtSndPartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strSECONDPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strSECONDPARTOGRAM_XML_VCHR);
                m_txtThreePartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strTHIRDPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strTHIRDPARTOGRAM_XML_VCHR);
                m_txtAidUser.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strAIDUSER_VCHR, objPartogramAll.m_objPartogramMain.m_strAIDUSER_XML_VCHR);
                m_cboSex.Text = objPartogramAll.m_objPartogramContent.m_strSEX_VCHR;
                if (objPartogramAll.m_objPartogramContent.m_intWEIGHT_INT != 0)
                    m_txtWeight.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intWEIGHT_INT.ToString());
                if(objPartogramAll.m_objPartogramContent.m_intHEIGHT_INT != 0)
                    m_txtHight.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intHEIGHT_INT.ToString());
                m_mthAddSignToListView(m_lsvDeliver,objPartogramAll.m_objPartogramMain.objSignerArr);
                //m_mthAddSignToListView(m_lsvAssit, objPartogramAll.m_objPartogramMain.objSignerArr);
                m_blnIsNew = false;
                
            }
            m_ctlPartogram.m_ObjPartogramManager.m_mthClear();
            if (objPartogramAll.m_ObjPartogramArr != null)
            {
                m_ctlPartogram.m_ObjPartogramManager.m_strReAddRange(objPartogramAll.m_ObjPartogramArr);
                m_dtmFirstSave = objPartogramAll.m_dtmFirstSave;
            }
            //m_mthSetBindingSource();
            m_objPartogramRecord = objPartogramAll;
            objPartogramAll = null;
        }
        private void m_ctlPartogram_m_evnPartogramEveryHourMouseDown(object sender, EventArgs e)
        {
            if (this.OwnedForms != null && this.OwnedForms.Length == 1)
            {
                this.OwnedForms[0].BringToFront();
                this.OwnedForms[0].Show();
                return;
            }
            com.digitalwave.Utility.Controls.clsPartogramEveryHourEventArgs objArg = (com.digitalwave.Utility.Controls.clsPartogramEveryHourEventArgs)e;
            if (objArg.m_objPartogramArgs != null)
            {
                StringBuilder sb = new StringBuilder();
                #region make string
                sb.Append("当前检查时间的产程内容：");
                sb.AppendLine();
                sb.Append("血压："+objArg.m_objPartogramArgs.m_intSYSTOLICPRESSURE_INT+"/"+ objArg.m_objPartogramArgs.m_intDIASTOLICPRESSURE_INT);
                sb.AppendLine();
                sb.Append("宫缩：" + objArg.m_objPartogramArgs.m_intUTERINECONTRACTION_INT+"″/"+objArg.m_objPartogramArgs.m_intUTERINECONTRACTIONMIN_INT+"′");
                sb.AppendLine();
                sb.Append("胎心率：" + objArg.m_objPartogramArgs.m_intFETALRHYTHM_INT);
                sb.AppendLine();
                if (objArg.m_objPartogramArgs.m_ObjPointArr != null)
                {
                    string strU = "宫颈口开大：" + Environment.NewLine;
                    string strD = "胎儿头下降：" + Environment.NewLine;
                    for (int i = 0 ; i < objArg.m_objPartogramArgs.m_ObjPointArr.Length ; i++)
                    {
                        if(objArg.m_objPartogramArgs.m_ObjPointArr[i].m_intPointType_INT == 0 && objArg.m_objPartogramArgs.m_ObjPointArr[i].m_fltPointValue_INT != -1)
                            strU += "    " + objArg.m_objPartogramArgs.m_ObjPointArr[i].m_intPointMin_INT + "′/" + objArg.m_objPartogramArgs.m_ObjPointArr[i].m_fltPointValue_INT + "cm  (" + objArg.m_objPartogramArgs.m_ObjPointArr[i].m_dtmCheckDate.ToString("HH时mm分")+")" + Environment.NewLine;
                        else if (objArg.m_objPartogramArgs.m_ObjPointArr[i].m_intPointType_INT == 1 && objArg.m_objPartogramArgs.m_ObjPointArr[i].m_fltPointValue_INT != -10)
                            strD += "    "+objArg.m_objPartogramArgs.m_ObjPointArr[i].m_intPointMin_INT + "′/" + objArg.m_objPartogramArgs.m_ObjPointArr[i].m_fltPointValue_INT + "  (" + objArg.m_objPartogramArgs.m_ObjPointArr[i].m_dtmCheckDate.ToString("HH时mm分")+")" +Environment.NewLine;
                    }
                    sb.Append(strU+strD);
                }
                sb.Append("处理：" + objArg.m_objPartogramArgs.m_strPROCESS_R_VCHR);
                sb.AppendLine();
                sb.Append("检查时间："+objArg.m_objPartogramArgs.m_dtmCHECKDATE_DAT.ToString("yyyy年MM月dd日 HH时mm分"));
                sb.AppendLine();
                sb.Append("最后修改：" + objArg.m_objPartogramArgs.m_strMODIFYUSERNAME_VCHR); 
                sb.AppendLine();
                sb.Append("    是否修改或者删除？");
                #endregion make string
                using (frmPartogramSelected frm = new frmPartogramSelected(sb.ToString()))
                {
                    DialogResult re = frm.ShowDialog(this);
                    if (re == DialogResult.Yes)
                    {
                        frmPartogramRecordContent_GX frmSub = new frmPartogramRecordContent_GX(false, objArg.m_objPartogramArgs.m_dtmCHECKDATE_DAT, objArg.m_objPartogramArgs.m_strREGISTERID_CHR, objArg.m_objPartogramArgs.m_dtmCREATEDATE_DAT, m_txtGiveBirthTime.m_objGetValue());
                        frmSub.m_mthSetPatient(m_objBaseCurrentPatient);
                        frmSub.FormClosed +=  new FormClosedEventHandler(frmSub_FormClosed);
                        frmSub.Show(this);
                    }
                    else if (re == DialogResult.No)
                    {
                        //权限判断
                        string strDeptIDTemp = m_ObjCurrentArea.m_strDEPTID_CHR;
                        bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, objArg.m_objPartogramArgs.m_strCREATEUSERID_CHR, clsEMRLogin.LoginEmployee, intFormType);
                        if (!blnIsAllow)
                            return;

                        long lngRes = m_objDomain.m_lngDeleteHour(objArg.m_objPartogramArgs.m_strREGISTERID_CHR, objArg.m_objPartogramArgs.m_dtmCREATEDATE_DAT, objArg.m_objPartogramArgs.m_intPARTOGRAM_INT,
                            clsEMRLogin.LoginInfo.m_strEmpID,new clsPublicDomain().m_dtmGetServerTime());
                        if (lngRes > 0)
                        {
                            m_ctlPartogram.m_ObjPartogramManager.m_intRemove(objArg.m_objPartogramArgs.m_intPARTOGRAM_INT);
                        }
                        else
                            m_tipMain.Show("删除失败",this,m_ctlPartogram.Location,2000);
                    }
                }
            }
            m_ctlPartogram.m_mthRefreshDispaly();
        }

        private void m_ctlPartogram_m_evnPartogramPointMouseDown(object sender, EventArgs e)
        {
            if (this.OwnedForms != null && this.OwnedForms.Length == 1)
            {
                this.OwnedForms[0].BringToFront();
                this.OwnedForms[0].Show();
                return;
            }
            com.digitalwave.Utility.Controls.clsPartogramPointEventArgs objArg = (com.digitalwave.Utility.Controls.clsPartogramPointEventArgs)e;
            if (objArg.m_objArgsValueArr != null)
            {
                StringBuilder sb = new StringBuilder("第" + objArg.m_intHour+ "小时：");
                sb.AppendLine();
                #region make string
                if (objArg.m_objArgsValueArr != null)
                {
                    string strU = "宫颈口开大：" + Environment.NewLine;
                    string strD = "胎儿头下降：" + Environment.NewLine;
                    for (int i = 0 ; i < objArg.m_objArgsValueArr.Length ; i++)
                    {
                        if (objArg.m_objArgsValueArr[i].m_intPointType_INT == 0 && objArg.m_objArgsValueArr[i].m_fltPointValue_INT != -1)
                            strU += "    " + objArg.m_objArgsValueArr[i].m_intPointMin_INT + "′/" + objArg.m_objArgsValueArr[i].m_fltPointValue_INT + "cm" + Environment.NewLine;
                        else if (objArg.m_objArgsValueArr[i].m_intPointType_INT == 1 && objArg.m_objArgsValueArr[i].m_fltPointValue_INT != -10)
                            strD += "    " + objArg.m_objArgsValueArr[i].m_intPointMin_INT + "′/" + objArg.m_objArgsValueArr[i].m_fltPointValue_INT + Environment.NewLine;
                    }
                    if(strU != "宫颈口开大：" + Environment.NewLine)
                        sb.Append(strU);
                    if(strD != "胎儿头下降：" + Environment.NewLine)
                        sb.Append(strD);
                }
                sb.Append("是否修改或者删除？");
                #endregion make string
                if (MessageBox.Show(this, sb.ToString(), "修改或者删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (frmPartogramPoint_GX frmSub2 = new frmPartogramPoint_GX(objArg.m_objArgsValueArr, ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID, objArg.m_intHour))
                    {
                        frmSub2.m_StrInPatientIdAndDate = m_objBaseCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                        if (frmSub2.ShowDialog(this) == DialogResult.OK)
                        {
                            clsPartogram_Point[] objPointArr = null;
                            long lngRes = m_objDomain.m_lngGetOneHourPointValues(objArg.m_objArgsValueArr[0].m_strREGISTERID_CHR, objArg.m_intHour, out objPointArr);

                            clsPartogram_VO obj_VO = m_ctlPartogram.m_ObjPartogramManager.m_objGetRecord(objArg.m_intHour);
                            if (obj_VO != null)
                                obj_VO.m_ObjPointArr = objPointArr;

                        }
                    }
                }
            }
            m_ctlPartogram.m_mthRefreshDispaly();

        }

        #endregion Event

        #region Print

        private void m_mthDemoPrint_FromDataSource()
        {
            m_objPrintTool = new clsPartogramPrintTool();
            m_objPrintTool.m_mthInitPrintTool(null);
            //clsInBedSessionInfo objSession = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_cboInpatientDate.Items.Count - m_cboInpatientDate.SelectedIndex - 1);
            m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
            m_objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);

            m_objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint();
        }
        private void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
            {
                //m_objPrintTool.m_BlnPreview = false;
                //m_objPrintTool.m_BlnIsDummy = false;
                //m_pdcPrintDocument.Print();
                //if (clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint, MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    m_objPrintTool.m_BlnIsDummy = true;
                //    m_pdcPrintDocument.Print();
                //}
            }
            else
            {
                m_objPrintTool.m_mthPrintPage(null);
            }
        }

        private void m_pdmPrint_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void m_pdmPrint_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void m_pdmPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        #endregion 

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            m_mthClearAllInfo(this);

            if (p_objSelectedSession == null)
            {
                return;
            }
            #region Check Power
            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }
            #endregion Check Power

            clsPartogramAll_VO objPartogramAll = null;
            long lngRes = m_objDomain.m_lngGetValues(p_objSelectedSession.m_strRegisterId, out objPartogramAll);
            if (lngRes <= 0 || objPartogramAll == null)
                return;
            if (objPartogramAll.m_objPartogramMain != null && objPartogramAll.m_objPartogramContent != null)
            {
                m_txtGravid.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intGRAVIDITYCOUNT_INT.ToString());
                m_txtBorn.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intBORNCOUNT_INT.ToString());
                m_txtMenses.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmLASTMENSES_DAT.ToString("yyyy年MM月dd日"));
                m_txtExpectDate.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmEDC_DAT.ToString("yyyy年MM月dd日"));
                m_txtBreakTime.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmBREAKTIME_DAT.ToString("yyyy年MM月dd日 HH时"));
                m_txtGiveBirthTime.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_dtmGIVEBIRTHTIME_DAT.ToString("yyyy年MM月dd日 HH时mm分"));
                m_cboGravidWay.Text = objPartogramAll.m_objPartogramContent.m_strCHILDBEARINGWAY_R_VCHR;
                m_txtFirstPartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strFIRSTPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strFIRSTPARTOGRAM_XML_VCHR);
                m_txtSndPartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strSECONDPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strSECONDPARTOGRAM_XML_VCHR);
                m_txtThreePartogram.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strTHIRDPARTOGRAM_VCHR, objPartogramAll.m_objPartogramMain.m_strTHIRDPARTOGRAM_XML_VCHR);
                m_txtAidUser.m_mthSetNewText(objPartogramAll.m_objPartogramMain.m_strAIDUSER_VCHR, objPartogramAll.m_objPartogramMain.m_strAIDUSER_XML_VCHR);
                m_cboSex.Text = objPartogramAll.m_objPartogramContent.m_strSEX_VCHR;
                if (objPartogramAll.m_objPartogramContent.m_intWEIGHT_INT != 0)
                    m_txtWeight.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intWEIGHT_INT.ToString());
                if (objPartogramAll.m_objPartogramContent.m_intHEIGHT_INT != 0)
                    m_txtHight.m_mthSetValue(objPartogramAll.m_objPartogramContent.m_intHEIGHT_INT.ToString());
                m_mthAddSignToListView(m_lsvDeliver, objPartogramAll.m_objPartogramMain.objSignerArr);
                //m_mthAddSignToListView(m_lsvAssit, objPartogramAll.m_objPartogramMain.objSignerArr);
                m_blnIsNew = false;

            }
            m_ctlPartogram.m_ObjPartogramManager.m_mthClear();
            if (objPartogramAll.m_ObjPartogramArr != null)
            {
                m_ctlPartogram.m_ObjPartogramManager.m_strReAddRange(objPartogramAll.m_ObjPartogramArr);
                m_dtmFirstSave = objPartogramAll.m_dtmFirstSave;
            }
            //m_mthSetBindingSource();
            m_objPartogramRecord = objPartogramAll;
            objPartogramAll = null;
        }
    }
}