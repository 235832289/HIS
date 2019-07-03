using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 术前小结
    /// </summary>
    public partial class frmEMR_SummaryBeforeOP : frmDiseaseTrackBase
    {
        #region 全局变量
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;

        private long m_lngCurrentEMR_SEQ = -1;
        #endregion

        #region 构造函数
        public frmEMR_SummaryBeforeOP()
        {
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            // 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、输入字体颜色，双画线颜色）
            m_mthSetRichTextBoxAttribInControl(this);
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
        } 
        #endregion

        #region 方法
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsEMR_SummaryBeforeOPInfo objTrackInfo = new clsEMR_SummaryBeforeOPInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "术前小结";

            //设置m_strTitle和m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = ((clsEMR_SummaryBeforeOPValue)objTrackInfo.m_ObjRecordContent).m_dtmRECORDDATE;
                m_dtpCreateDate.Refresh();
            }
            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容		
            m_dtpCreateDate.Value = DateTime.Now;
            m_txtDiseaseSummary.m_mthClearText();
            m_txtDiagnoseBeforeOP.m_mthClearText();
            m_txtDiagnosisGist.m_mthClearText();
            m_txtOPIndication.m_mthClearText();
            m_txtOPMode.m_mthClearText();
            m_txtAnaMode.m_mthClearText();
            m_txtProceeding.m_mthClearText();
            m_txtPrepareBeforeOP.m_mthClearText();

            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

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
            int intSignCount = lsvSign.Items.Count;

            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null || intSignCount == 0)
                return null;
            //从界面获取表单值
            clsEMR_SummaryBeforeOPValue objContent = new clsEMR_SummaryBeforeOPValue();

            //获取lsvsign签名
            objContent.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i] = new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName = "lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR = "frmEMR_SummaryBeforeOP";
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,
            //    strUserIDList = strUserIDList + objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim() + ",";
            //    strUserNameList = strUserNameList + objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim() + ",";
            //}
            objContent.m_strModifyUserID = strUserIDList;

            //设置Richtextbox的modifyuserID 和modifyuserName
            m_mthSetRichTextBoxAttribInControlWithIDandName(this);
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;

            objContent.m_strDISEASESUMMARY = m_txtDiseaseSummary.Text;
            objContent.m_strDISEASESUMMARY_RIGHT = m_txtDiseaseSummary.m_strGetRightText();
            objContent.m_strDISEASESUMMARYXML = m_txtDiseaseSummary.m_strGetXmlText();

            objContent.m_strDIAGNOSISBEFOREOP = m_txtDiagnoseBeforeOP.Text;
            objContent.m_strDIAGNOSISBEFOREOP_RIGHT = m_txtDiagnoseBeforeOP.m_strGetRightText();
            objContent.m_strDIAGNOSISBEFOREOPXML = m_txtDiagnoseBeforeOP.m_strGetXmlText();

            objContent.m_strDIAGNOSISGIST = m_txtDiagnosisGist.Text;
            objContent.m_strDIAGNOSISGIST_RIGHT = m_txtDiagnosisGist.m_strGetRightText();
            objContent.m_strDIAGNOSISGISTXML = m_txtDiagnosisGist.m_strGetXmlText();

            objContent.m_strOPINDICATION = m_txtOPIndication.Text;
            objContent.m_strOPINDICATION_RIGHT = m_txtOPIndication.m_strGetRightText();
            objContent.m_strOPINDICATIONXML = m_txtOPIndication.m_strGetXmlText();

            objContent.m_strOPMODE = m_txtOPMode.Text;
            objContent.m_strOPMODE_RIGHT = m_txtOPMode.m_strGetRightText();
            objContent.m_strOPMODEXML = m_txtOPMode.m_strGetXmlText();

            objContent.m_strANAMODE = m_txtAnaMode.Text;
            objContent.m_strANAMODE_RIGHT = m_txtAnaMode.m_strGetRightText();
            objContent.m_strANAMODEXML = m_txtAnaMode.m_strGetXmlText();

            objContent.m_strPROCEEDING = m_txtProceeding.Text;
            objContent.m_strPROCEEDING_RIGHT = m_txtProceeding.m_strGetRightText();
            objContent.m_strPROCEEDINGXML = m_txtProceeding.m_strGetXmlText();

            objContent.m_strPREPAREBEFOREOP = m_txtPrepareBeforeOP.Text;
            objContent.m_strPREPAREBEFOREOP_RIGHT = m_txtPrepareBeforeOP.m_strGetRightText();
            objContent.m_strPREPAREBEFOREOPXML = m_txtPrepareBeforeOP.m_strGetXmlText();

            objContent.m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            objContent.m_lngEMR_SEQ = m_lngCurrentEMR_SEQ;
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
            clsEMR_SummaryBeforeOPValue objContent = (clsEMR_SummaryBeforeOPValue)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
            m_txtDiseaseSummary.m_mthSetNewText(objContent.m_strDISEASESUMMARY, objContent.m_strDISEASESUMMARYXML);
            m_txtDiagnoseBeforeOP.m_mthSetNewText(objContent.m_strDIAGNOSISBEFOREOP, objContent.m_strDIAGNOSISBEFOREOPXML);
            m_txtDiagnosisGist.m_mthSetNewText(objContent.m_strDIAGNOSISGIST, objContent.m_strDIAGNOSISGISTXML);
            m_txtOPIndication.m_mthSetNewText(objContent.m_strOPINDICATION, objContent.m_strOPINDICATIONXML);
            m_txtOPMode.m_mthSetNewText(objContent.m_strOPMODE, objContent.m_strOPMODEXML);
            m_txtAnaMode.m_mthSetNewText(objContent.m_strANAMODE, objContent.m_strANAMODEXML);
            m_txtProceeding.m_mthSetNewText(objContent.m_strPROCEEDING, objContent.m_strPROCEEDINGXML);
            m_txtPrepareBeforeOP.m_mthSetNewText(objContent.m_strPREPAREBEFOREOP, objContent.m_strPREPAREBEFOREOPXML);
            m_lngCurrentEMR_SEQ = objContent.m_lngEMR_SEQ;
            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName == "lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvSign.Items.Add(lviNewItem);

                //    }
                //}
            }
            #endregion 签名

        }

        public override int m_IntFormID
        {
            get
            {
                return 134;
            }
        }

        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsEMR_SummaryBeforeOPValue objContent = (clsEMR_SummaryBeforeOPValue)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_lngCurrentEMR_SEQ = objContent.m_lngEMR_SEQ;
            m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
            m_txtDiseaseSummary.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDISEASESUMMARY, objContent.m_strDISEASESUMMARYXML);
            m_txtDiagnoseBeforeOP.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSISBEFOREOP, objContent.m_strDIAGNOSISBEFOREOPXML);
            m_txtDiagnosisGist.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSISGIST, objContent.m_strDIAGNOSISGISTXML);
            m_txtOPIndication.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOPINDICATION, objContent.m_strOPINDICATIONXML);
            m_txtOPMode.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOPMODE, objContent.m_strOPMODEXML);
            m_txtAnaMode.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strANAMODE, objContent.m_strANAMODEXML);
            m_txtProceeding.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPROCEEDING, objContent.m_strPROCEEDINGXML);
            m_txtPrepareBeforeOP.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPREPAREBEFOREOP, objContent.m_strPREPAREBEFOREOPXML);

            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_SummaryBeforeOP);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            if (p_objRecordContent == null)
                return;
            clsEMR_SummaryBeforeOPValue objContent = (clsEMR_SummaryBeforeOPValue)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_lngCurrentEMR_SEQ = objContent.m_lngEMR_SEQ;
            m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
            m_txtDiseaseSummary.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDISEASESUMMARY, objContent.m_strDISEASESUMMARYXML);
            m_txtDiagnoseBeforeOP.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSISBEFOREOP, objContent.m_strDIAGNOSISBEFOREOPXML);
            m_txtDiagnosisGist.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSISGIST, objContent.m_strDIAGNOSISGISTXML);
            m_txtOPIndication.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOPINDICATION, objContent.m_strOPINDICATIONXML);
            m_txtOPMode.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOPMODE, objContent.m_strOPMODEXML);
            m_txtAnaMode.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strANAMODE, objContent.m_strANAMODEXML);
            m_txtProceeding.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPROCEEDING, objContent.m_strPROCEEDINGXML);
            m_txtPrepareBeforeOP.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPREPAREBEFOREOP, objContent.m_strPREPAREBEFOREOPXML);
        }

        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "术前小结";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {

        } 
        #endregion

        #region 事件
        private void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmEMR_SummaryBeforeOP_Load(object sender, EventArgs e)
        {
            m_txtDiseaseSummary.Focus();
        } 
        #endregion
    }
}