using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.PatientManagerService;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    /// 手术记录----新疆
    /// </summary>
    public partial class frmOperationRecord_xj : iCare.frmDiseaseTrackBase
    {
        #region
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        // protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutHospitalDate;
        private System.Windows.Forms.Label lblInHospitalDateTitle;
        private System.Windows.Forms.Label m_lblInHospitalDate;
        //private System.Windows.Forms.ColumnHeader columnHeader1;
        //private System.Windows.Forms.ColumnHeader columnHeader2;        
        //private System.Windows.Forms.ColumnHeader columnHeader3;
        //private System.Windows.Forms.ColumnHeader columnHeader4;
      //  private TextBox m_txtDoctorSign;
        //private PinkieControls.ButtonXP cmdConfirm;   
        private System.Windows.Forms.Label lblEmployeeIDTitle;
        private System.Windows.Forms.Label lblEmployeeID;
        //private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.Label lblEmployeeSign;
        //private System.Windows.Forms.ColumnHeader columnHeader6;
        //private System.Windows.Forms.ColumnHeader columnHeader7;
        //private System.ComponentModel.IContainer components = null;
        //private PinkieControls.ButtonXP m_cmdMainDoctorSign;
      //  private PinkieControls.ButtonXP m_cmdDoctorSign;
        private clsEmrSignToolCollection m_objSign;
        private DateTime m_dtmOutHospitalDate;
        #endregion

        public frmOperationRecord_xj()
        {
            InitializeComponent();

            //指明医生工作站表单
            intFormType = 1;           

            m_mthSetRichTextBoxAttribInControl(this);

            this.Text = "手术记录";
            this.m_lblForTitle.Text = this.Text;

            m_objSign = new clsEmrSignToolCollection();
            //签名
            m_objSign.m_mthBindEmployeeSign(m_cmdMainDoctorSign, m_txtMainDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //手术者
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //助手
            m_objSign.m_mthBindEmployeeSign(m_cmdHelperSign, m_txtHelperSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

        }


        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsOperationRecordInfo_xj objTrackInfo = new clsOperationRecordInfo_xj();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            //设置m_strTitle和m_dtmRecordTime
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "手术记录";

            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容	
            m_lblInHospitalDate.Text = "";// m_objBaseCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_strCurrentOpenDate = "";

            //m_txtHeartID.m_mthClearText();
            //m_txtXRayID.m_mthClearText();
            m_txtInHospitalDiagnose.m_mthClearText();
            m_txtOutHospitalDiagnose.m_mthClearText();
            m_txtInHospitalCase.m_mthClearText();
            //  m_txtInHospitalBy.m_mthClearText();
            m_txtOutHospitalCase.m_mthClearText();
            m_txtOutHospitalAdvice.m_mthClearText();

            m_txtMainDoctorSign.Text = "";
            m_txtMainDoctorSign.Tag = null;
            m_txtDoctorSign.Text = "";
            m_txtDoctorSign.Tag = null;
            m_txtHelperSign.Text = "";
            m_txtHelperSign.Tag = null;

            m_txtYiBao.Text = "";
            //m_txtDoctorSign.Enabled = true; 
            //m_txtDoctorSign.Text = "";
            //m_txtDoctorSign.Tag = null;
            // lblEmployeeID.Text = "";
        }


        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            m_blnIsMainWindow = false;
            this.MaximizeBox = false;
            if (p_blnEnable == false)
            {
                foreach (Control control in this.Controls)
                {
                    control.Top = control.Top - 100;
                }

                //cmdConfirm.Visible = true;
                //m_cmdClose.Visible = true;

                int intLeft = 248;
                lblInHospitalDateTitle.Left -= intLeft;
                lblOutHospitalDate.Left -= intLeft;
                lblCreateDateTitle.Left -= intLeft;
                m_lblInHospitalDate.Left -= intLeft;
                m_dtpCreateDate.Left -= intLeft;
                m_dtpOutHospitalDate.Left -= intLeft;
                //lblHeart.Left -= intLeft;
                //lblXRay.Left -= intLeft;
                m_cmdMainDoctorSign.Left -= intLeft;
                //m_txtHeartID.Left -= intLeft;
                //m_txtXRayID.Left -= intLeft;
                m_txtMainDoctorSign.Left -= intLeft;
                m_txtDoctorSign.Left -= intLeft;
                m_txtHelperSign.Left -= intLeft;

                this.Size = new Size(this.Size.Width, this.Size.Height - 110);
                this.CenterToParent();
            }
            m_intFormID = 15;
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
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;

            //从界面获取表单值
            clsOperationRecordContent_xj objContent = new clsOperationRecordContent_xj();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            if (m_dtpOutHospitalDate.Visible && m_dtpOutHospitalDate.Enabled)
            {
                objContent.m_dtmOutHospitalDate = m_dtpOutHospitalDate.Value;
            }
            else
            {
                objContent.m_dtmOutHospitalDate = DateTime.MinValue;
            }

            //objContent.m_strHeartID_Right = m_txtHeartID.m_strGetRightText();
            //objContent.m_strHeartID = m_txtHeartID.Text;
            //objContent.m_strHeartIDXML = m_txtHeartID.m_strGetXmlText();

            //objContent.m_strXRayID_Right = m_txtXRayID.m_strGetRightText();
            //objContent.m_strXRayID = m_txtXRayID.Text;
            //objContent.m_strXRayIDXML = m_txtXRayID.m_strGetXmlText(); 

            objContent.m_strInHospitalDiagnose_Right = m_txtInHospitalDiagnose.m_strGetRightText();
            objContent.m_strInHospitalDiagnose = m_txtInHospitalDiagnose.Text;
            //objContent.m_strInHospitalDiagnoseXML = m_txtInHospitalDiagnose.m_strGetXmlText();

            //objContent.m_strInHospitalDiagnoseXi_Right = m_txtInXiYiDiagnose.m_strGetRightText();
            //objContent.m_strInHospitalDiagnoseXi = m_txtInXiYiDiagnose.Text;
            //objContent.m_strInHospitalDiagnoseXiXML = m_txtInXiYiDiagnose.m_strGetXmlText();


            objContent.m_strOutHospitalDiagnose_Right = m_txtOutHospitalDiagnose.m_strGetRightText();
            objContent.m_strOutHospitalDiagnose = m_txtOutHospitalDiagnose.Text;
            objContent.m_strOutHospitalDiagnoseXML = m_txtOutHospitalDiagnose.m_strGetXmlText();


            //objContent.m_strOutHospitalDiagnoseXi_Right = m_txtOutXiYiDiagnose.m_strGetRightText();
            //objContent.m_strOutHospitalDiagnoseXi = m_txtOutXiYiDiagnose.Text;
            //objContent.m_strOutHospitalDiagnoseXiXML = m_txtOutXiYiDiagnose.m_strGetXmlText();

            objContent.m_strInHospitalCase_Right = m_txtInHospitalCase.m_strGetRightText();
            objContent.m_strInHospitalCase = m_txtInHospitalCase.Text;
            //objContent.m_strInHospitalCaseXML = m_txtInHospitalCase.m_strGetXmlText();


            objContent.m_strOutHospitalCase_Right = m_txtOutHospitalCase.m_strGetRightText();
            objContent.m_strOutHospitalCase = m_txtOutHospitalCase.Text;
            objContent.m_strOutHospitalCaseXML = m_txtOutHospitalCase.m_strGetXmlText();

            objContent.m_strOutHospitalAdvice_Right = m_txtOutHospitalAdvice.m_strGetRightText();
            objContent.m_strOutHospitalAdvice = m_txtOutHospitalAdvice.Text;
            objContent.m_strOutHospitalAdviceXML = m_txtOutHospitalAdvice.m_strGetXmlText();
            objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;

            objContent.m_strYiBao = m_txtYiBao.Text;

            if (m_txtMainDoctorSign.Tag != null && m_txtMainDoctorSign.Text.Trim() != "")
            {
                objContent.m_strMainDoctorID = ((clsEmrEmployeeBase_VO)m_txtMainDoctorSign.Tag).m_strEMPNO_CHR.Trim();
                objContent.m_strMainDoctorName = ((clsEmrEmployeeBase_VO)m_txtMainDoctorSign.Tag).m_strLASTNAME_VCHR;
            }
            else
            {
                objContent.m_strMainDoctorID = "";
                objContent.m_strMainDoctorName = "";
                //				clsPublicFunction.ShowInformationMessageBox("必须主治医师签名!");
                //				return null;
            }

            //if (m_txtDoctorSign.Tag != null && m_txtDoctorSign.Text.Trim() != "")
            //{
            //    objContent.m_strDoctorID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
            //    objContent.m_strDoctorName = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strLASTNAME_VCHR;
            //}
            //else
            //{
            //    clsPublicFunction.ShowInformationMessageBox("必须经治医师签名!");
            //    return null;
            //}
            if (m_txtDoctorSign.Tag != null && m_txtDoctorSign.Text.Trim() != "")
            {
                objContent.m_strDoctorID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
                objContent.m_strDoctorName = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strLASTNAME_VCHR;
            }
            else
            {
                //objContent.m_strMainDoctorID = "";
                //objContent.m_strMainDoctorName = "";
                clsPublicFunction.ShowInformationMessageBox("必须手术者签名!");
                return null;
            }

            if (m_txtHelperSign.Tag != null && m_txtHelperSign.Text.Trim() != "")
            {
                objContent.m_strHelperID = ((clsEmrEmployeeBase_VO)m_txtHelperSign.Tag).m_strEMPNO_CHR.Trim();
                objContent.m_strHelperName = ((clsEmrEmployeeBase_VO)m_txtHelperSign.Tag).m_strLASTNAME_VCHR;
            }
            else
            {
                objContent.m_strHelperID = "";
                objContent.m_strHelperName = "";
                //clsPublicFunction.ShowInformationMessageBox("必须手术者签名!");
              //  return null;
            }

            return objContent;
        }



        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsOperationRecordContent_xj objContent = (clsOperationRecordContent_xj)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dtmOut = m_dtmOutHospitalDate;
            m_dtpOutHospitalDate.Enabled = false;
            if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")
            {
                if (objContent.m_dtmOutHospitalDate != DateTime.MinValue)
                {
                    dtmOut = objContent.m_dtmOutHospitalDate;
                }
            }
            else
            {
                dtmOut = m_ObjCurrentEmrPatientSession.m_dtmOutDate;
            }
            if (dtmOut != DateTime.MinValue && dtmOut != new DateTime(1900, 1, 1))
            {
                m_dtpOutHospitalDate.Value = dtmOut;
                m_dtpOutHospitalDate.Visible = true;
                if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")
                    m_dtpOutHospitalDate.Enabled = true;
            }
            else
            {
                m_dtpOutHospitalDate.Visible = false;
            }
            m_dtmOutHospitalDate = dtmOut;

            //			m_dtpOutHospitalDate.Value = objContent.m_dtmOutHospitalDate;
            //m_txtHeartID.m_mthSetNewText(objContent.m_strHeartID, objContent.m_strHeartIDXML);
            //m_txtXRayID.m_mthSetNewText(objContent.m_strXRayID, objContent.m_strXRayIDXML);
            m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strInHospitalDiagnose, null );
           // m_txtInXiYiDiagnose.m_mthSetNewText(objContent.m_strInHospitalDiagnoseXi, objContent.m_strInHospitalDiagnoseXiXML);

            m_txtOutHospitalDiagnose.m_mthSetNewText(objContent.m_strOutHospitalDiagnose, objContent.m_strOutHospitalDiagnoseXML);
          //  m_txtOutXiYiDiagnose.m_mthSetNewText(objContent.m_strOutHospitalDiagnoseXi, objContent.m_strOutHospitalDiagnoseXiXML);

            m_txtInHospitalCase.m_mthSetNewText(objContent.m_strInHospitalCase, null );
            //m_txtInHospitalBy.m_mthSetNewText(objContent.m_strInHospitalBy, objContent.m_strInHospitalByXML);
            m_txtOutHospitalCase.m_mthSetNewText(objContent.m_strOutHospitalCase, objContent.m_strOutHospitalCaseXML);
            m_txtOutHospitalAdvice.m_mthSetNewText(objContent.m_strOutHospitalAdvice, objContent.m_strOutHospitalAdviceXML);

            m_txtYiBao.Text = objContent.m_strYiBao;

            #region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strMainDoctorID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtMainDoctorSign.Tag = objEmpVO;
                m_txtMainDoctorSign.Text = objEmpVO.m_strGetTechnicalRankAndName;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDoctorID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objEmpVO.m_strGetTechnicalRankAndName;
                //m_txtDoctorSign.Enabled = false;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strHelperID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtHelperSign.Tag = objEmpVO;
                m_txtHelperSign.Text = objEmpVO.m_strGetTechnicalRankAndName;
                //m_txtHelperSign.Enabled = false;
            }

            //    lblEmployeeID.Text = objContent.m_strDoctorID;
            #endregion 签名

            //			#region 入院原因(主诉)
            //			clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"));
            //			if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
            //			{
            //				m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
            //			}
            //			#endregion 入院原因(主诉)

        }


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
                m_mthSetDeletedGUIFromContent(objContent);
            }

        }

        private int m_intFormID = 195;
        public override int m_IntFormID
        {
            get
            {
                return m_intFormID;
            }
        }

        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsOperationRecordContent_xj objContent = (clsOperationRecordContent_xj)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            //			m_dtpOutHospitalDate.Value = objContent.m_dtmOutHospitalDate;
            m_mthGetSetlectedOutDate();
            if (m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_dtmOutHospitalDate == DateTime.MinValue)
                m_dtpOutHospitalDate.Visible = false;
            else
            {
                m_dtpOutHospitalDate.Visible = true;
                m_dtpOutHospitalDate.Value = m_dtmOutHospitalDate;
                if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")//非南宁
                {
                    m_dtpOutHospitalDate.Enabled = true;
                }
                else
                {
                    m_dtpOutHospitalDate.Enabled = false;
                }
            }

            //m_txtHeartID.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strHeartID, objContent.m_strHeartIDXML);
            //m_txtXRayID.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXRayID, objContent.m_strXRayIDXML);
            m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose, null);
         //   m_txtInXiYiDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnoseXi, objContent.m_strInHospitalDiagnoseXiXML);


            m_txtOutHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalDiagnose, objContent.m_strOutHospitalDiagnoseXML);
           // m_txtOutXiYiDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalDiagnoseXi, objContent.m_strOutHospitalDiagnoseXiXML);

            m_txtInHospitalCase.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase, null );
            //m_txtInHospitalBy.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalBy, objContent.m_strInHospitalByXML);
            m_txtOutHospitalCase.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalCase, objContent.m_strOutHospitalCaseXML);
            m_txtOutHospitalAdvice.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalAdvice, objContent.m_strOutHospitalAdviceXML);

            m_txtYiBao.Text = objContent.m_strYiBao;
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.OperationRecord_xj);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsOperationRecordContent_xj objContent = (clsOperationRecordContent_xj)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现

            //m_txtHeartID.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strHeartID, objContent.m_strHeartIDXML);
            //m_txtXRayID.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strXRayID, objContent.m_strXRayIDXML);

            m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose,null  );
          //  m_txtInXiYiDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnoseXi, objContent.m_strInHospitalDiagnoseXiXML);


            m_txtOutHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalDiagnose, objContent.m_strOutHospitalDiagnoseXML);
         //   m_txtOutXiYiDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalDiagnoseXi, objContent.m_strOutHospitalDiagnoseXiXML);


            m_txtInHospitalCase.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase, null );
            //m_txtInHospitalBy.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalBy, objContent.m_strInHospitalByXML);
            m_txtOutHospitalCase.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalCase, objContent.m_strOutHospitalCaseXML);
            m_txtOutHospitalAdvice.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutHospitalAdvice, objContent.m_strOutHospitalAdviceXML);

            m_txtYiBao.Text = objContent.m_strYiBao;
        }

        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "手术记录";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {
            #region 初步诊断默认值
            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                DateTime dtmInDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
                if (m_ObjLastEmrPatientSession != null)
                {
                    dtmInDate = m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate;
                }
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, dtmInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
                {
                    m_txtInHospitalDiagnose.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
                }
            }
            #endregion 初步诊断默认值
        }

        #region 审核
        private string m_strCurrentOpenDate = "";
        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (m_strCurrentOpenDate == "")
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return "";
                }
                return m_strCurrentOpenDate;

                //				if(this.m_trvCreateDate.SelectedNode==null || this.m_trvCreateDate.SelectedNode.Tag==null)
                //				{
                //					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                //					return "";
                //				}
                //				return (string)this.m_trvCreateDate.SelectedNode.Tag;
            }
        }

        protected override bool m_BlnCanApprove
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region 医师签名
        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:// enter
                    break;

                case 38:
                case 40:
                    break;
                case 113://save
                    this.Save();
                    break;
                case 114://del
                    this.Delete();
                    break;
                case 115://print
                    this.Print();
                    break;
                case 116://refresh
                    m_mthClearUp();
                    break;
                case 117://Search					
                    break;
            }
        }

        #endregion 医师签名oll.,

        private void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private bool m_blnIsMainWindow = true;

        private void frmOperationRecord_xj_Load(object sender, EventArgs e)
        {
            m_mthfrmLoad();

            //m_cmdNewTemplate.Left = cmdConfirm.Left - m_cmdNewTemplate.Width + (cmdConfirm.Right - m_cmdClose.Left);
            //m_cmdNewTemplate.Top = cmdConfirm.Top;

            if (m_blnIsMainWindow == true)
                m_mthSetQuickKeys();
            else
            {
                //				m_cmdNewTemplate.Visible=true;
            }

            if (m_objCurrentPatient != null)
            {
                m_lblInHospitalDate.Text = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss");
                m_dtpOutHospitalDate.Value = (m_objCurrentPatient.m_DtmLastOutDate != new DateTime(1900, 1, 1) && m_objCurrentPatient.m_DtmLastOutDate != m_objCurrentPatient.m_DtmLastInDate) ? m_objCurrentPatient.m_DtmLastOutDate : DateTime.Now;
            }

            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            m_trvCreateDate.Focus();
        }


        protected override void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
        {
            //判断病人信息是否为null，如果是，直接返回。
            if (p_objSelectedPatient == null)
                return;

            //记录病人信息
            m_objCurrentPatient = p_objSelectedPatient;
            m_lblInHospitalDate.Text = m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss");
            //m_dtpOutHospitalDate.Value = (m_objCurrentPatient.m_DtmLastOutDate != new DateTime(1900,1,1) && m_objCurrentPatient.m_DtmLastOutDate!=m_objCurrentPatient.m_DtmLastInDate) ? m_objCurrentPatient.m_DtmLastOutDate : DateTime.Now;
            m_mthGetSetlectedOutDate();
            if (m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_dtmOutHospitalDate == DateTime.MinValue)
                m_dtpOutHospitalDate.Visible = false;
            else
            {
                m_dtpOutHospitalDate.Visible = true;
                m_dtpOutHospitalDate.Value = m_dtmOutHospitalDate;
                if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")//非南宁
                {
                    m_dtpOutHospitalDate.Enabled = true;
                }
                else
                {
                    m_dtpOutHospitalDate.Enabled = false;
                }
            }
        }



        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
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

        private bool m_blnHasInitPrintTool = false;
        clsOperationRecordPrintTool_xj objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new clsOperationRecordPrintTool_xj();
                objPrintTool.m_mthInitPrintTool(null);
                m_blnHasInitPrintTool = true;
            }
            objPrintTool.m_mthSetOutDateValue(m_dtmOutHospitalDate);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, m_objCurrentRecordContent.m_dtmOpenDate);
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
        #endregion 外部打印.

        #region 添加键盘快捷键
        private void m_mthSetQuickKeys()
        {
            m_mthSetControlEvent(this);
        }

        private void m_mthSetControlEvent(Control p_ctlControl)
        {
            #region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName != "Lable" && strTypeName != "Button")
            {
                p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        m_mthSetControlEvent(subcontrol);
                    }
                }
            }
            #endregion
        }

        private void m_mthClearUpInControl(Control p_ctlControl)
        {
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
            else if (strTypeName == "ctlBorderTextBox")
                ((ctlBorderTextBox)p_ctlControl).Text = "";
            else if (strTypeName == "TreeView")
            {
                if (((TreeView)p_ctlControl).Nodes.Count > 0)
                    ((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
            }
            else if (strTypeName == "ListView")
                ((ListView)p_ctlControl).Items.Clear();
            else if (strTypeName == "DateTimePicker")
                ((DateTimePicker)p_ctlControl).Value = DateTime.Now;

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthClearUpInControl(subcontrol);
                }
            }
        }

        private void m_mthClearUp()
        {
            m_mthClearUpInControl(this);
            m_lblInHospitalDate.Text = "";
            m_mthClearPatientBaseInfo();
        }

        #endregion



        private void m_mthEvent_KeyDown1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (m_blnIsMainWindow)
                return;

            switch (e.KeyValue)
            {
                case 13:// enter

                    break;

                case 38://up
                case 40://down			
                    break;
            }
        }

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString());
            if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
            {
                this.m_txtInHospitalDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
                this.m_txtOutHospitalDiagnose.Text = objInPatientCaseDefaultValue[0].m_strFinallyDiagnose != "" ? objInPatientCaseDefaultValue[0].m_strFinallyDiagnose : objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            }
        }



        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        //protected override string m_StrRecorder_ID
        //{
        //    get
        //    {
        //        if (m_txtDoctorSign.Tag != null)
        //            return ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
        //        return "";
        //    }
        //}
        #endregion 属性

        /// <summary>
        /// 获取病人出院时间，暂时先在各个窗体查询
        /// </summary>
        /// <returns></returns>
        private long m_mthGetSetlectedOutDate()
        {
            m_dtmOutHospitalDate = new DateTime(1900, 1, 1);
            string strRegisterID = "";
            long lngRes = 0;
            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));


            //lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);

            lngRes = objServ.m_lngGetOutHospitalDate(MDIParent.m_objCurrentPatient.m_strREGISTERID_CHR, out m_dtmOutHospitalDate);

            if (m_dtmOutHospitalDate == DateTime.MinValue || m_dtmOutHospitalDate == new DateTime(1900, 1, 1))
            {
                lngRes = objServ.m_lngGetPrepOutHospitalDate(strRegisterID, out m_dtmOutHospitalDate);
            }
            objServ = null;
            return lngRes;
        }


        protected override void m_mthAfterSuccessfulSave()
        {
            //if (!m_dtpOutHospitalDate.Visible || !m_dtpOutHospitalDate.Enabled)
            //{
            //    return;
            //}
            //if (m_dtpOutHospitalDate.Value.ToString("yyyy-MM-dd HH:mm:ss") != m_dtmOutHospitalDate.ToString("yyyy-MM-dd HH:mm:ss"))
            //{
            //    try
            //    {
            //        clsOutHospitalDomain objDomain = new clsOutHospitalDomain();
            //        long lngRes = objDomain.m_lngUpdateOutDate(MDIParent.m_objCurrentPatient.m_strREGISTERID_CHR, Convert.ToDateTime(m_dtpOutHospitalDate.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            //        objDomain = null;
            //    }
            //    catch (Exception Ex)
            //    {
            //        string strEx = Ex.Message;
            //    }                
            //}
        }



        /// <summary>
        /// 设置各种类型的默认值
        /// </summary>
        /// <param name="p_objPatient"></param>
        protected override void m_mthSetDefaultValue(clsPatient p_objPatient)
        {
            base.m_mthSetDefaultValue(p_objPatient);

            try
            {
                if (p_objPatient == null)
                {
                    return;
                }
                clsOperationRecordDomain_xj objDomain = new clsOperationRecordDomain_xj ();
                DataTable dtbOrder = null;
                long lngRes = objDomain.m_lngGetOutOrderByRegID(p_objPatient.m_StrRegisterId, out dtbOrder);

                if (dtbOrder != null)
                {
                    int intRowsCount = dtbOrder.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        System.Text.StringBuilder stbOutOrder = new System.Text.StringBuilder(100);
                        DataRow drTemp = null;
                        for (int i = 0; i < intRowsCount; i++)
                        {
                            drTemp = dtbOrder.Rows[i];
                            stbOutOrder.Append(drTemp["NAME_VCHR"].ToString());
                            stbOutOrder.Append("    ");
                            stbOutOrder.Append(drTemp["REMARK_VCHR"].ToString());
                            stbOutOrder.Append(Environment.NewLine);
                        }
                        this.m_txtOutHospitalAdvice.Text = stbOutOrder.ToString();
                    }
                }
            }
            catch (Exception Ex)
            {

                string strEx = Ex.Message;
            }
        }

        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsOperationRecordContent_xj();

                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objContent);
                if (lngRes <= 0 || m_objContent == null)
                {
                    switch (lngRes)
                    {
                        case (long)(iCareData.enmOperationResult.Not_permission):
                            m_mthShowNotPermitted(); break;
                        case (long)(iCareData.enmOperationResult.DB_Fail):
                            m_mthShowDBError(); break;
                    }
                    return blnIsOK;
                }
                clsOperationRecordContent_xj p_objContent = (clsOperationRecordContent_xj)m_objContent;
                this.m_dtpOutHospitalDate.Text = p_objContent.m_dtmOutHospitalDate.ToString("yyyy-MM-dd hh:mm:ss");
                this.m_txtMainDoctorSign.Text = p_objContent.m_strMainDoctorName;
                // this.m_txtDoctorSign.Text = p_objContent.m_strDoctorName;
               // this.m_txtInXiYiDiagnose.Text = p_objContent.m_strInHospitalDiagnoseXi;
                this.m_txtInHospitalDiagnose.Text = p_objContent.m_strInHospitalDiagnose;
                this.m_txtOutHospitalDiagnose.Text = p_objContent.m_strOutHospitalDiagnose;
               // this.m_txtOutXiYiDiagnose.Text = p_objContent.m_strOutHospitalDiagnoseXi;
                this.m_txtInHospitalCase.Text = p_objContent.m_strInHospitalCase;
                //this.m_txtInHospitalBy.Text = p_objContent.m_strInHospitalBy;
                this.m_txtOutHospitalCase.Text = p_objContent.m_strOutHospitalCase;
                this.m_txtOutHospitalAdvice.Text = p_objContent.m_strOutHospitalAdvice;

                //clsEmrSignToolCollection m_objSign = new clsEmrSignToolCollection();
                this.m_txtDoctorSign.Text = p_objContent.m_strDoctorName;
                this.m_txtHelperSign.Text = p_objContent.m_strHelperName;

                m_txtYiBao.Text = p_objContent.m_strYiBao;

                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsOperationRecordPrintTool_xj();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);

                //clsPrintInfo_Consultation objPrintInfo = new clsPrintInfo_Consultation();
                clsPrintInfo_OperationRecord_xj objPrintInfo = new clsPrintInfo_OperationRecord_xj();

                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                objPrintInfo.m_strInPatentID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=


                clsTrackRecordContent p_objContent = new clsOperationRecordContent_xj();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsOperationRecordContent_xj objContent = (clsOperationRecordContent_xj)p_objContent;
                //objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_objRecordContent = objContent;
                //objPrintInfo.m_blnIsFirstPrint = false;

                objPrintTool.m_mthSetPrintContent(objPrintInfo);

                m_mthStartPrint();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;

            new clsOperationRecordDomain_xj().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做



    }
}