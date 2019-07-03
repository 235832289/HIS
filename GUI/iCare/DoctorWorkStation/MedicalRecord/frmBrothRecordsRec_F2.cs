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
    public partial class frmBrothRecordsRec_F2 : frmHRPBaseForm
    {

        private clsEmployeeSignTool m_objSignTool;
        private clsBrothRecords_F2Domain m_objDomain;
        private clsBrothRecords_F2Rec m_objCurrentRecord;
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private bool m_blnIsNew;
        private string m_strMotherID;
        private string m_strBirthTime;
        private string m_strOpenTime;
        private string m_strInPatientDate;


        public frmBrothRecordsRec_F2(bool blnIsNew, string strMotherID, string strInPatientDate, string strBirthTime, ref string strOpenDate)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(760, 472);

            intFormType = 1;
            m_blnIsNew = blnIsNew;
            m_strMotherID = strMotherID;
            m_strBirthTime = strBirthTime;
            m_strOpenTime = strOpenDate;
            m_strInPatientDate = strInPatientDate;
            
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            m_objDomain = new clsBrothRecords_F2Domain();
        }

        private void m_cmdCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
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
            clsBrothRecords_F2Rec objNewRecord = m_objGetCircsRecordContentFromUI();

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
       //     objNewRecord.m_dtmBIRTHTIME = DateTime.Parse(m_strBirthTime);
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
            clsBrothRecords_F2Rec objNewRecord = m_objGetCircsRecordContentFromUI();
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
          //  objNewRecord.m_dtmBIRTHTIME = DateTime.Parse(m_strBirthTime);
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


        private void m_mthSetCircsRecordContentToUI(clsBrothRecords_F2Rec objRecord)
        {
            if (objRecord != null)
            {
                m_dtpRecordTime.Value = objRecord.m_dtmRecordDate;
              //  m_cboBirthDays.Text = objRecord.m_strBIRTHDAYS == null ? "" : objRecord.m_strBIRTHDAYS.Trim();
                m_txtxueya.m_mthSetNewText(objRecord.str_XUEYA, objRecord.str_XUEYAXML);
                m_txtCgongsuojianxie.m_mthSetNewText(objRecord.str_GONGSUOJIANXUE, objRecord.str_GONGSUOJIANXUEXML);
                m_txtgongsuotimes.m_mthSetNewText(objRecord.str_GONGSUOTIME, objRecord.str_GONGSUOTIMEXML);
                m_txttaixin.m_mthSetNewText(objRecord.str_TAIXIN, objRecord.str_TAIXINXML);
                m_txtgongkoukaida.m_mthSetNewText(objRecord.str_GONGKOU, objRecord.str_GONGKOUXML);
                m_txttaimoqingkuang.m_mthSetNewText(objRecord.str_TAIMO, objRecord.str_TAIMOXML);
                m_txtxianlugaodi.m_mthSetNewText(objRecord.str_XIANLU, objRecord.str_XIANLUXML);
                m_txtjianchafa.m_mthSetNewText(objRecord.str_JIANCHAFA, objRecord.str_JIANCHAFAXML);
                m_txtgongdijisizhou.m_mthSetNewText(objRecord.str_GONGDIJIZHOU, objRecord.str_GONGDIJIZHOUXML);
                m_yindaofenmiwu.m_mthSetNewText(objRecord.str_FENMIWU, objRecord.str_FENMIWUXML);
                //m_txtAGNAIL.m_mthSetNewText(objRecord.m_strAGNAIL, objRecord.m_strAGNAILXML);
                //m_txtREDSTERN.m_mthSetNewText(objRecord.m_strREDSTERN, objRecord.m_strREDSTERNXML);
                //m_txtSTERNSKIN.m_mthSetNewText(objRecord.m_strSTERNSKIN, objRecord.m_strSTERNSKINXML);
                //m_txtHEARTLUNG.m_mthSetNewText(objRecord.m_strHEARTLUNG, objRecord.m_strHEARTLUNGXML);
                //m_txtABDOMEN.m_mthSetNewText(objRecord.m_strABDOMEN, objRecord.m_strABDOMENXML);
                //m_txtRemark.m_mthSetNewText(objRecord.m_strREMARK, objRecord.m_strREMARKXML);

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objRecord.m_strSignUserID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtDoctorSign.Tag = objEmpVO;
                    m_txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                }

                //if(objRecord.m_strSignUserName != "" && objRecord.m_strSignUserName != null && objRecord.m_strSignUserID != "" &&objRecord.m_strSignUserID != null)
                //{
                //    m_txtDoctorSign.Text = objRecord.m_strSignUserName;

                //    clsEmployee objEmp = new clsEmployee(objRecord.m_strSignUserID);
                //    m_txtDoctorSign.Tag = objEmp;
                //}
            }

            m_objCurrentRecord = objRecord;
        }

        private clsBrothRecords_F2Rec m_objGetCircsRecordContentFromUI()
        {
            clsBrothRecords_F2Rec objRecord = new clsBrothRecords_F2Rec();

            objRecord.m_dtmRecordDate = m_dtpRecordTime.Value;


            objRecord.str_XUEYA = m_txtxueya.m_strGetRightText();
            objRecord.str_XUEYAXML = m_txtxueya.m_strGetXmlText();

            objRecord.str_GONGSUOJIANXUE = m_txtCgongsuojianxie.m_strGetRightText();
            objRecord.str_GONGSUOJIANXUEXML = m_txtCgongsuojianxie.m_strGetXmlText();

            objRecord.str_GONGSUOTIME = m_txtgongsuotimes.m_strGetRightText();
            objRecord.str_GONGSUOTIMEXML = m_txtgongsuotimes.m_strGetXmlText();

            objRecord.str_TAIXIN = m_txttaixin.m_strGetRightText();
            objRecord.str_TAIXINXML = m_txttaixin.m_strGetXmlText();

            objRecord.str_GONGKOU = m_txtgongkoukaida.m_strGetRightText();
            objRecord.str_GONGKOUXML = m_txtgongkoukaida.m_strGetXmlText();

            objRecord.str_TAIMO = m_txttaimoqingkuang.m_strGetRightText();
            objRecord.str_TAIMOXML = m_txttaimoqingkuang.m_strGetXmlText();

            objRecord.str_XIANLU = m_txtxianlugaodi.m_strGetRightText();
            objRecord.str_XIANLUXML = m_txtxianlugaodi.m_strGetXmlText();

            objRecord.str_JIANCHAFA = m_txtjianchafa.m_strGetRightText();
            objRecord.str_JIANCHAFAXML = m_txtjianchafa.m_strGetXmlText();

            objRecord.str_GONGDIJIZHOU = m_txtgongdijisizhou.m_strGetRightText();
            objRecord.str_GONGDIJIZHOUXML = m_txtgongdijisizhou.m_strGetXmlText();

            objRecord.str_FENMIWU = m_yindaofenmiwu.m_strGetRightText();
            objRecord.str_FENMIWUXML = m_yindaofenmiwu.m_strGetXmlText();

            //objRecord.m_strAGNAIL = m_txtAGNAIL.m_strGetRightText();
            //objRecord.m_strAGNAILXML = m_txtAGNAIL.m_strGetXmlText();

            //objRecord.m_strREDSTERN = m_txtREDSTERN.m_strGetRightText();
            //objRecord.m_strREDSTERNXML = m_txtREDSTERN.m_strGetXmlText();

            //objRecord.m_strSTERNSKIN = m_txtSTERNSKIN.m_strGetRightText();
            //objRecord.m_strSTERNSKINXML = m_txtSTERNSKIN.m_strGetXmlText();

            //objRecord.m_strHEARTLUNG = m_txtHEARTLUNG.m_strGetRightText();
            //objRecord.m_strHEARTLUNGXML = m_txtHEARTLUNG.m_strGetXmlText();

            //objRecord.m_strABDOMEN = m_txtABDOMEN.m_strGetRightText();
            //objRecord.m_strABDOMENXML = m_txtABDOMEN.m_strGetXmlText();

            //objRecord.m_strREMARK = m_txtRemark.m_strGetRightText();
            //objRecord.m_strREMARKXML = m_txtRemark.m_strGetXmlText();

            if (m_txtDoctorSign.Tag != null)
            {
                objRecord.m_strSignUserName = m_txtDoctorSign.Text;

                objRecord.m_strSignUserID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPID_CHR;
            }

            return objRecord;
        }


        public clsBrothRecords_F2Rec m_objGetSingleContent()
        {
            clsBrothRecords_F2Rec objRecord = new clsBrothRecords_F2Rec();
            long lngRes = m_objDomain.m_lngGetCircsRecordContent(m_strMotherID, m_strInPatientDate, m_strOpenTime, out objRecord);

            return objRecord;
        }

        private void frmBrothRecordsRec_F2_Load(object sender, EventArgs e)
        {
            if (!m_blnIsNew)
            {
                clsBrothRecords_F2Rec objRecord = m_objGetSingleContent();

                m_mthSetCircsRecordContentToUI(objRecord);

                m_mthSetModifyControl(m_objCurrentRecord, false);
            }
            else
            {
                try
                {
                    TimeSpan tsBirthDays = m_dtpRecordTime.Value - DateTime.Parse(m_strBirthTime);
                  //  m_cboBirthDays.Text = (tsBirthDays.Days + 1).ToString();
                    m_mthSetModifyControl(null, true);
                }
                catch { }
            }
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
        protected void m_mthSetModifyControl(clsBrothRecords_F2Rec p_objRecordContent, bool p_blnReset)
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

        private void m_dtpRecordTime_evtValueChanged(object sender, EventArgs e)
        {
            if (m_dtpRecordTime.Value < Convert.ToDateTime(m_strBirthTime))
            {
                MessageBox.Show("记录时间小于出生时间，请输入正确的时间！");
                return;
            }
            TimeSpan m_ts = m_dtpRecordTime.Value - Convert.ToDateTime(m_strBirthTime);
           // m_cboBirthDays.Text = Convert.ToString(m_ts.Days + 1);
        }












    }
}