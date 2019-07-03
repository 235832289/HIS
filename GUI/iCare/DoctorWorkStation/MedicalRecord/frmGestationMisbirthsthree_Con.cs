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
using System.Text;
namespace iCare
{
    /// <summary>
    /// 新生儿情况记录
    /// </summary>
    public partial class frmGestationMisbirthsthree_Con : frmHRPBaseForm
    {
        
        #region 定义
        /// <summary>
        /// 签名变量
        /// </summary>
        private clsEmrSignToolCollection m_objSign;
        private bool m_blnIsNew;
        private string m_strMotherID;
        private string m_strBirthTime;
        private string m_strOpenTime;
        private string m_strInPatientDate;
        private clsGestationMisbirthsthreeDomain m_objDomain;
        private clsGestationMisbirthsthreeVO m_objCurrentRecord;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        #endregion
        
        #region　构造函数
        private string m_strRegisterID = string.Empty;
        public frmGestationMisbirthsthree_Con(bool blnIsNew, string strMotherID, string strInPatientDate, string strBirthTime, ref string strOpenDate)
		{
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.Size = new System.Drawing.Size(760, 472);
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            //指明医生工作站表单
            intFormType = 1;
            m_blnIsNew = blnIsNew;
            m_strMotherID = strMotherID;
            m_strBirthTime = strBirthTime;
            m_strOpenTime = strOpenDate;
            m_strInPatientDate = strInPatientDate;
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtDoctorSign);

            //new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdDoctorSign },
            //    new Control[]{this.m_txtDoctorSign},new int[]{1});
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            m_objDomain = new clsGestationMisbirthsthreeDomain();
            m_txtBLOODPRESSURE1.Focus();
		}
        #endregion

        #region 单击事件
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (m_txtSign.Text == "")
            {
                MessageBox.Show("请签名人签名！");
                return;
            }
            if (m_blnIsNew)
                m_mthAddNewRecord();
            else
                m_mthModifyRecord();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }
        #endregion

        private void m_mthModifyRecord()
        {
            if (m_objCurrentRecord == null)
                return;
            clsGestationMisbirthsthreeVO objNewRecord = m_objGetCircsRecordContentFromUI();

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
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
            clsGestationMisbirthsthreeVO objNewRecord = m_objGetCircsRecordContentFromUI();
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objNewRecord.m_strInPatientID = m_strMotherID;
            objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
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

        private void m_mthSetCircsRecordContentToUI(clsGestationMisbirthsthreeVO objRecord)
        {
            if (objRecord != null)
            {
                m_dtpRecordTime.Value = objRecord.m_dtmRecordDate;
                if (objRecord.m_strBLOODPRESSURE_VCHR != "")
                {
                    string[] strXY = objRecord.m_strBLOODPRESSURE_VCHR.Split('/');
                    m_txtBLOODPRESSURE1.Text = strXY[0].ToString();
                    m_txtBLOODPRESSURE2.Text = strXY[1].ToString();
                }
                m_txtTEMPERATURE.m_mthSetNewText(objRecord.m_strTEMPERATURE_VCHR, objRecord.m_strTEMPERATURE_XML);
                m_txtPULSE.m_mthSetNewText(objRecord.m_strPULSE_VCHR, objRecord.m_strPULSE_XML);
                m_txtCONTRACTIONS.m_mthSetNewText(objRecord.m_strCONTRACTIONS_VCHR, objRecord.m_strCONTRACTIONS_XML);
                m_txtBLEEDING.m_mthSetNewText(objRecord.m_strBLEEDING_VCHR, objRecord.m_strBLEEDING_XML);
                m_txtBROKENWATER.m_mthSetNewText(objRecord.m_strBROKENWATER_VCHR, objRecord.m_strBROKENWATER_XML);
                m_txtFETAL.m_mthSetNewText(objRecord.m_strFETAL_VCHR, objRecord.m_strFETAL_XML);
                m_txtSign.Text = objRecord.m_strSignUserName;
                m_txtMIYAGUCHISIZE.m_mthSetNewText(objRecord.m_strMIYAGUCHISIZE_VCHR, objRecord.m_strMIYAGUCHISIZE_XML);

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objRecord.m_strSignUserID, out objEmpVO);
                //if (objEmpVO != null)
                //{
                //    m_txtSign.Tag = objEmpVO;
                //    m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                //}
                if (objRecord.m_strSignUserName != "" && objRecord.m_strSignUserName != null && objRecord.m_strSignUserID != "" && objRecord.m_strSignUserID != null)
                {
                    m_txtSign.Text = objRecord.m_strSignUserName;

                    clsEmployee objEmp = new clsEmployee(objRecord.m_strSignUserID);
                    m_txtSign.Tag = objEmp;
                }
            }
            m_objCurrentRecord = objRecord;
        }

        private clsGestationMisbirthsthreeVO m_objGetCircsRecordContentFromUI()
        {
            clsGestationMisbirthsthreeVO objRecord = new clsGestationMisbirthsthreeVO();

            objRecord.m_dtmRecordDate = m_dtpRecordTime.Value;

            if (m_txtBLOODPRESSURE1.Text.Trim() != "" || m_txtBLOODPRESSURE2.Text.Trim() != "")
            {
                objRecord.m_strBLOODPRESSURE_VCHR = m_txtBLOODPRESSURE1.m_strGetRightText() + "/" + m_txtBLOODPRESSURE2.m_strGetRightText();
            }

            objRecord.m_strTEMPERATURE_VCHR = m_txtTEMPERATURE.m_strGetRightText();
            objRecord.m_strTEMPERATURE_XML = m_txtTEMPERATURE.m_strGetXmlText();

            objRecord.m_strPULSE_VCHR = m_txtPULSE.m_strGetRightText();
            objRecord.m_strPULSE_XML = m_txtPULSE.m_strGetXmlText();

            objRecord.m_strCONTRACTIONS_VCHR = m_txtCONTRACTIONS.m_strGetRightText();
            objRecord.m_strCONTRACTIONS_XML = m_txtCONTRACTIONS.m_strGetXmlText();

            objRecord.m_strBLEEDING_VCHR = m_txtBLEEDING.m_strGetRightText();
            objRecord.m_strBLEEDING_XML = m_txtBLEEDING.m_strGetXmlText();

            objRecord.m_strBROKENWATER_VCHR = m_txtBROKENWATER.m_strGetRightText();
            objRecord.m_strBROKENWATER_XML = m_txtBROKENWATER.m_strGetXmlText();

            objRecord.m_strFETAL_VCHR = m_txtFETAL.m_strGetRightText();
            objRecord.m_strFETAL_XML = m_txtFETAL.m_strGetXmlText();

            objRecord.m_strMIYAGUCHISIZE_VCHR = m_txtMIYAGUCHISIZE.m_strGetRightText();
            objRecord.m_strMIYAGUCHISIZE_XML = m_txtMIYAGUCHISIZE.m_strGetXmlText();

            if (m_txtSign.Tag != null)
            {
                //objRecord.m_strSignUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
                objRecord.m_strSignUserName = m_txtSign.Text;
            }

            return objRecord;
        }

        public clsGestationMisbirthsthreeVO m_objGetSingleContent()
        {
            clsGestationMisbirthsthreeVO objRecord = new clsGestationMisbirthsthreeVO();
            long lngRes = m_objDomain.m_lngGetCircsRecordContent(m_strMotherID, m_strInPatientDate, m_strOpenTime, out objRecord);
            return objRecord;
        }
        private void frmGestationMisbirthsthree_Con_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(650, 215);
            if (!m_blnIsNew)
            {
                clsGestationMisbirthsthreeVO objRecord = m_objGetSingleContent();
                m_mthSetCircsRecordContentToUI(objRecord);
                m_mthSetModifyControl(m_objCurrentRecord, false);
            }
            else
            {
                try
                {
                    //TimeSpan tsBirthDays = m_dtpRecordTime.Value - DateTime.Parse(m_strBirthTime);
                    //m_cboBirthDays.Text = (tsBirthDays.Days + 1).ToString();
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
        protected void m_mthSetModifyControl(clsGestationMisbirthsthreeVO p_objRecordContent, bool p_blnReset)
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
            //TimeSpan m_ts = m_dtpRecordTime.Value - Convert.ToDateTime(m_strBirthTime);
            //m_cboBirthDays.Text = Convert.ToString(m_ts.Days + 1);
        }
    }
}