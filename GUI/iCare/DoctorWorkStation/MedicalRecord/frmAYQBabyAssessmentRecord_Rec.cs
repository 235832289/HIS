using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.clsGeneralNurseRecord_GXService;
using com.digitalwave.Utility.Controls;
using iCare.iCareBaseForm;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    public partial class frmAYQBabyAssessmentRecord_Rec : frmHRPBaseForm
    {
        
        public frmAYQBabyAssessmentRecord_Rec(bool blnIsNew, string strMotherID, string strInPatientDate, string strBirthTime, ref string strOpenDate)
        {
            InitializeComponent();
            m_strMotherID = strMotherID;
            //指明医生工作站表单
            intFormType = 1;
            m_blnIsNew = blnIsNew;
            m_strOpenTime = strOpenDate;
            m_strInPatientDate = strInPatientDate;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objDomain = new clsAYQBabyAssessmentContentDomain();
        }
        
        private void m_cmdCancle_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void m_cmdOK_Click(object sender, System.EventArgs e)
        {
            if (m_blnIsNew)
                m_mthAddNewRecord();
            else
                m_mthModifyRecord();
        }

        private void m_mthModifyRecord()
        {
            if (m_objCurrentRecord == null)
                return;
            clsAYQBabyAssessmentContent objNewRecord = m_objGetCircsRecordContentFromUI();

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
            objNewRecord.m_dtmAssessmentDate = m_dtpRecordTime.Value;
            objNewRecord.m_dtmOpenDate = m_objCurrentRecord.m_dtmOpenDate;
            objNewRecord.m_strCreateUserID = m_objCurrentRecord.m_strCreateUserID;
            objNewRecord.m_dtmCreateDate = m_objCurrentRecord.m_dtmCreateDate;
            objNewRecord.m_strModifyUserID = MDIParent.OperatorID;
            objNewRecord.m_dtmModifyDate = DateTime.Parse(strNow);

            clsPreModifyInfo p_objModifyInfo = new clsPreModifyInfo();
            long lngRes = m_objDomain.m_lngModifyCircsRecord(m_objCurrentRecord, objNewRecord, out p_objModifyInfo);

            if (lngRes < 0)
                MDIParent.ShowInformationMessageBox("保存失败");
            else
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void m_mthAddNewRecord()
        {
            clsAYQBabyAssessmentContent objNewRecord = m_objGetCircsRecordContentFromUI();
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
            objNewRecord.m_dtmAssessmentDate = m_dtpRecordTime.Value;
            objNewRecord.m_dtmOpenDate = DateTime.Parse(strNow);
            objNewRecord.m_strCreateUserID = MDIParent.OperatorID;
            objNewRecord.m_dtmCreateDate = DateTime.Parse(strNow);
            objNewRecord.m_strModifyUserID = MDIParent.OperatorID;
            objNewRecord.m_dtmModifyDate = DateTime.Parse(strNow);

            clsPreModifyInfo p_objModifyInfo = new clsPreModifyInfo();
            long lngRes = m_objDomain.m_lngAddNewCircsRecord(objNewRecord, out p_objModifyInfo);

            if (lngRes < 0)
                MDIParent.ShowInformationMessageBox("保存失败");
            else
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void m_mthSetCircsRecordContentToUI(clsAYQBabyAssessmentContent objRecord)
        {
            if (objRecord != null)
            {
                m_dtpRecordTime.Value = objRecord.m_dtmRecordDate;
                this.m_ctlFaceColor.m_mthSetNewText(objRecord.m_strFacecolor, objRecord.m_strFacecolorXML);
                this.m_ctlHuXi.m_mthSetNewText(objRecord.m_strRespiration, objRecord.m_strRespirationXML);
                this.m_ctlFanYing.m_mthSetNewText(objRecord.m_strReaction, objRecord.m_strReactionXML);
                this.m_ctlJinShi.m_mthSetNewText(objRecord.m_strTakeFood, objRecord.m_strTakeFoodXML);
                this.m_ctlYeShi.m_mthSetNewText(objRecord.m_strArmpitWet, objRecord.m_strArmpitWetXML);
                this.m_ctlPiFu.m_mthSetNewText(objRecord.m_strDerm, objRecord.m_strDermXML);
                this.m_ctlHuangDan.m_mthSetNewText(objRecord.m_strAurigo, objRecord.m_strAurigoXML);
                this.m_ctlQiBu.m_mthSetNewText(objRecord.m_strUmbilicalRegion, objRecord.m_strUmbilicalRegionXML);
                this.m_ctlSiZhiHuoDong.m_mthSetNewText(objRecord.m_strLimbActivity, objRecord.m_strLimbActivityXML);
                this.m_ctlDaBian.m_mthSetNewText(objRecord.m_strStool, objRecord.m_strStoolXML);
                this.m_ctlXiaoBian.m_mthSetNewText(objRecord.m_strUrine, objRecord.m_strUrineXML);
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objRecord.m_strSignUserID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtDoctorSign.Tag = objEmpVO;
                    m_txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                }
            }

            m_objCurrentRecord = objRecord;
        }

        private clsAYQBabyAssessmentContent m_objGetCircsRecordContentFromUI()
        {
            clsAYQBabyAssessmentContent objRecord = new clsAYQBabyAssessmentContent();
            objRecord.m_dtmRecordDate = m_dtpRecordTime.Value;
            objRecord.m_strFacecolorRight = this.m_ctlFaceColor.m_strGetRightText();
            objRecord.m_strFacecolor = this.m_ctlFaceColor.Text;
            objRecord.m_strFacecolorXML = this.m_ctlFaceColor.m_strGetXmlText();

            objRecord.m_strRespirationRight = this.m_ctlHuXi.m_strGetRightText();
            objRecord.m_strRespiration = this.m_ctlHuXi.Text;
            objRecord.m_strRespirationXML = this.m_ctlHuXi.m_strGetXmlText();

            objRecord.m_strReactionRight = this.m_ctlFanYing.m_strGetRightText();
            objRecord.m_strReaction = this.m_ctlFanYing.Text;
            objRecord.m_strReactionXML = this.m_ctlFanYing.m_strGetXmlText();

            objRecord.m_strTakeFoodRight = this.m_ctlJinShi.m_strGetRightText();
            objRecord.m_strTakeFood = this.m_ctlJinShi.Text;
            objRecord.m_strTakeFoodXML = this.m_ctlJinShi.m_strGetXmlText();

            objRecord.m_strArmpitWetRight = this.m_ctlYeShi.m_strGetRightText();
            objRecord.m_strArmpitWet = this.m_ctlYeShi.Text;
            objRecord.m_strArmpitWetXML = this.m_ctlYeShi.m_strGetXmlText();

            objRecord.m_strDermRight = this.m_ctlPiFu.m_strGetRightText();
            objRecord.m_strDerm = this.m_ctlPiFu.Text;
            objRecord.m_strDermXML = this.m_ctlPiFu.m_strGetXmlText();

            objRecord.m_strAurigoRight = this.m_ctlHuangDan.m_strGetRightText();
            objRecord.m_strAurigo = this.m_ctlHuangDan.Text;
            objRecord.m_strAurigoXML = this.m_ctlHuangDan.m_strGetXmlText();

            objRecord.m_strUmbilicalRegionRight = this.m_ctlQiBu.m_strGetRightText();
            objRecord.m_strUmbilicalRegion = this.m_ctlQiBu.Text;
            objRecord.m_strUmbilicalRegionXML = this.m_ctlQiBu.m_strGetXmlText();

            objRecord.m_strLimbActivityRight = this.m_ctlSiZhiHuoDong.m_strGetRightText();
            objRecord.m_strLimbActivity = this.m_ctlSiZhiHuoDong.Text;
            objRecord.m_strLimbActivityXML = this.m_ctlSiZhiHuoDong.m_strGetXmlText();

            objRecord.m_strStoolRight = this.m_ctlDaBian.m_strGetRightText();
            objRecord.m_strStool = this.m_ctlDaBian.Text;
            objRecord.m_strStoolXML = this.m_ctlDaBian.m_strGetXmlText();

            objRecord.m_strUrineRight = this.m_ctlXiaoBian.m_strGetRightText();
            objRecord.m_strUrine = this.m_ctlXiaoBian.Text;
            objRecord.m_strUrineXML = this.m_ctlXiaoBian.m_strGetXmlText();

            if (m_txtDoctorSign.Tag != null)
            {
                objRecord.m_strSignUserName = m_txtDoctorSign.Text;

                objRecord.m_strSignUserID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPID_CHR;
            }

            return objRecord;
        }

        public clsAYQBabyAssessmentContent m_objGetSingleContent()
        {
            clsAYQBabyAssessmentContent objRecord = new clsAYQBabyAssessmentContent();
            long lngRes = m_objDomain.m_lngGetCircsRecordContent(m_strMotherID, m_strInPatientDate, m_strOpenTime, out objRecord);

            return objRecord;
        }

        private void frmAYQBabyAssessmentRecord_Rec_Load(object sender, System.EventArgs e)
        {
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
            if (!m_blnIsNew)
            {
                clsAYQBabyAssessmentContent objRecord = m_objGetSingleContent();

                m_mthSetCircsRecordContentToUI(objRecord);

                m_mthSetModifyControl(m_objCurrentRecord, false);
            }
            else
            {
                try
                {
                    m_mthSetDefaultValue();
                    m_mthSetModifyControl(null, true);
                }
                catch { }
            }
            m_cmdModifyPatientInfo.Visible = false;
        }

        private void m_mthSetDefaultValue()
        {
            m_ctlFaceColor.m_mthSetNewText("√","<root />");
            m_ctlHuXi.m_mthSetNewText("√", "<root />");
            m_ctlFanYing.m_mthSetNewText("√", "<root />");
            m_ctlJinShi.m_mthSetNewText("√", "<root />");
            m_ctlPiFu.m_mthSetNewText("√", "<root />");
            m_ctlHuangDan.m_mthSetNewText("√", "<root />");
            m_ctlSiZhiHuoDong.m_mthSetNewText("√", "<root />");
            m_ctlDaBian.m_mthSetNewText("√", "<root />");
            m_ctlXiaoBian.m_mthSetNewText("√", "<root />");
            MDIParent.m_mthSetDefaulEmployee(m_txtDoctorSign); 
        }

        public string m_StrCreateDate
        {
            get { return m_strOpenTime; }
        }


        /// <summary>
        /// 设置窗体中控件输入文本的颜色
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_clrColor"></param>
        private void m_mthSetRichTextModifyColor(Control p_ctlControl, System.Drawing.Color p_clrColor)
        {
            #region 设置控件输入文本的颜色,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.Utility.Controls.ctlRichTextBox")
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
            else if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextModifyColor(subcontrol, p_clrColor);
                }
            }
            #endregion
        }


        private void m_mthSetRichTextCanModifyLast(Control p_ctlControl, bool p_blnCanModifyLast)
        {
            #region 设置控件输入文本的是否最后修改,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.Utility.Controls.ctlRichTextBox")
            {
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }
            else if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextCanModifyLast(subcontrol, p_blnCanModifyLast);
                }
            }
            #endregion
        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(clsAYQBabyAssessmentContent p_objRecordContent, bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_blnReset == true)
            {
                m_mthSetRichTextModifyColor(this, clsHRPColor.s_ClrInputFore);
                m_mthSetRichTextCanModifyLast(this, true);
            }
            else if (p_objRecordContent != null)
            {
                m_mthSetRichTextModifyColor(this, Color.Red);
                m_mthSetRichTextCanModifyLast(this, m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
            }
        }

        /// <summary>
        /// 输入框内，内容颜色的设置方法
        /// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
        /// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
        /// </summary>
        /// <returns></returns>
        private bool m_blnGetCanModifyLast(string p_strModifyUserID)
        {
            if (p_strModifyUserID == null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
                return true;
            else
                return false;
        }

        private void m_cboFacecolor_Load(object sender, EventArgs e)
        {

        }
        
    }
}