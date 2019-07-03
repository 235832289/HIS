using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;//多签名
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.iCare.RemindMessage;
using System.Threading;
using com.digitalwave.emr.AssistModuleVO;


namespace iCare
{
    public class frmConsultation : iCare.frmDiseaseTrackBase
    {
        #region declare
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaseHistory;
        private com.digitalwave.controls.ctlRichTextBox m_txtConsultationOrder;
        private com.digitalwave.controls.ctlRichTextBox m_txtConsultationIdea;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpConsultationDate;
        private PinkieControls.ButtonXP cmdConfirm;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDoctorSign;
        protected System.Windows.Forms.ListView m_lsvEmployeeDoctor;
        protected System.Windows.Forms.ListView m_lsvDoctorList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCurrentDiagnose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdbGeneral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdbOneDay;
        private System.Windows.Forms.RadioButton rdbRightNow;
        private System.Windows.Forms.GroupBox gpbConsultationTime;
        private System.Windows.Forms.Label lblApply;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.Label lblEmployeeSign;
        protected System.Windows.Forms.ListView m_lsvEmployee_New;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
        private System.ComponentModel.IContainer components = null;
        private PinkieControls.ButtonXP m_cmdMainDoctor;
        private PinkieControls.ButtonXP m_cmdRequestSign;
        #endregion
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private PinkieControls.ButtonXP m_cmdDoctorSign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        protected com.digitalwave.Utility.Controls.ctlTimePicker ctlTimePicker1;
        private Label label2;
        private GroupBox groupBox1;
        private Label m_lblOtherHopitalApply;
        private TextBox m_txtOtherHospitalApply;
        private Label m_lblOtherHopital;
        private com.digitalwave.controls.ctlRichTextBox m_txtOtherHospital;
        private TextBox m_txtMainDoctor;
        private TextBox m_txtRequestSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private TextBox m_txtApplyConsultationDept;
        private Button m_cmdShowAllDept;
        private TextBox m_txtConsulter;
        private Panel m_pnlSearchWindow;
        private TextBox m_txtSearchDept;
        private ImageList imageList1;
        private Label label8;
        private ListView m_lsvDeptList;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader8;
        private TextBox m_txtAsker;
        private Label label11;
        private Label label10;
        private clsConsultationDomain m_objDomain;

        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (m_txtRequestSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)m_txtRequestSign.Tag).m_strEMPNO_CHR.Trim();
                //					return ((clsEmployee)m_txtRequestSign.Tag).m_StrEmployeeID;
                return "";
            }
        }

        #endregion 属性
        public frmConsultation()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            // TODO: Add any initialization after the InitializeComponent call	初始化那些控件后再初始化的东东
            //this.m_trvCreateDate.Location = new System.Drawing.Point(9, 36);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] { m_lsvEmployeeDoctor });

            m_mthSetRichTextBoxAttribInControl(this);			//改变RichTextBox的边框
            m_objDomain = new clsConsultationDomain();
            //m_txtMainDoctor.LostFocus +=new EventHandler(m_lsvDoctorList_LostFocus);
            //m_txtRequestSign.LostFocus +=new EventHandler(m_lsvDoctorList_LostFocus);

            //m_txtDoctorSign.LostFocus +=new EventHandler(m_lsvDoctorList_LostFocus);
            //m_lsvDoctorList.LostFocus +=new EventHandler(m_lsvDoctorList_LostFocus);

            cmdConfirm.Visible = false;
            m_cmdClose.Visible = false;
            
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdMainDoctor, m_txtMainDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdRequestSign, m_txtRequestSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultation));
            this.lblApply = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentDiagnose = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpConsultationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtCaseHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtConsultationOrder = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtConsultationIdea = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_lsvEmployeeDoctor = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.m_txtDoctorSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.gpbConsultationTime = new System.Windows.Forms.GroupBox();
            this.rdbGeneral = new System.Windows.Forms.RadioButton();
            this.rdbOneDay = new System.Windows.Forms.RadioButton();
            this.rdbRightNow = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lsvDoctorList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_lsvEmployee_New = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cmdMainDoctor = new PinkieControls.ButtonXP();
            this.m_cmdRequestSign = new PinkieControls.ButtonXP();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctlTimePicker1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblOtherHopitalApply = new System.Windows.Forms.Label();
            this.m_txtOtherHospitalApply = new System.Windows.Forms.TextBox();
            this.m_lblOtherHopital = new System.Windows.Forms.Label();
            this.m_txtOtherHospital = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMainDoctor = new System.Windows.Forms.TextBox();
            this.m_txtRequestSign = new System.Windows.Forms.TextBox();
            this.m_txtApplyConsultationDept = new System.Windows.Forms.TextBox();
            this.m_cmdShowAllDept = new System.Windows.Forms.Button();
            this.m_txtConsulter = new System.Windows.Forms.TextBox();
            this.m_pnlSearchWindow = new System.Windows.Forms.Panel();
            this.m_lsvDeptList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSearchDept = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_txtAsker = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.gpbConsultationTime.SuspendLayout();
            this.m_pnlSearchWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(9, 36);
            this.m_trvCreateDate.Size = new System.Drawing.Size(187, 66);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(203, 72);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(272, 69);
            this.m_dtpCreateDate.TabIndex = 100;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(140, 163);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(38, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(156, 171);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(245, 160);
            this.lblSex.Size = new System.Drawing.Size(28, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(228, 158);
            this.lblAge.Size = new System.Drawing.Size(10, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(205, 163);
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(212, 167);
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(245, 160);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(239, 160);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(231, 160);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(212, 163);
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(227, 171);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(12, 10);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(208, 167);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(227, 160);
            this.m_txtPatientName.Size = new System.Drawing.Size(12, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(215, 154);
            this.m_txtBedNO.Size = new System.Drawing.Size(10, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(210, 163);
            this.m_cboArea.Size = new System.Drawing.Size(11, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(184, 170);
            this.m_lsvPatientName.Size = new System.Drawing.Size(11, 11);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(156, 174);
            this.m_lsvBedNO.Size = new System.Drawing.Size(22, 11);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(210, 162);
            this.m_cboDept.Size = new System.Drawing.Size(11, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(224, 163);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(648, 664);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 28);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(231, 160);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(242, 160);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(287, 157);
            this.m_lblForTitle.Text = "会 诊 记 录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(630, 171);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(556, 147);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cmdShowAllDept);
            this.m_pnlNewBase.Controls.Add(this.m_txtApplyConsultationDept);
            this.m_pnlNewBase.Controls.Add(this.lblApply);
            this.m_pnlNewBase.Controls.Add(this.m_lblOtherHopital);
            this.m_pnlNewBase.Controls.Add(this.m_txtOtherHospital);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(795, 101);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtOtherHospital, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblOtherHopital, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblApply, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtApplyConsultationDept, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdShowAllDept, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(194, 32);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(599, 68);
            // 
            // lblApply
            // 
            this.lblApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApply.AutoSize = true;
            this.lblApply.BackColor = System.Drawing.Color.Transparent;
            this.lblApply.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApply.ForeColor = System.Drawing.Color.Black;
            this.lblApply.Location = new System.Drawing.Point(516, 37);
            this.lblApply.Name = "lblApply";
            this.lblApply.Size = new System.Drawing.Size(98, 14);
            this.lblApply.TabIndex = 6089;
            this.lblApply.Text = "申请会诊科室:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 6091;
            this.label1.Text = "简要病历及会诊目的:";
            // 
            // lblCurrentDiagnose
            // 
            this.lblCurrentDiagnose.AutoSize = true;
            this.lblCurrentDiagnose.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentDiagnose.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentDiagnose.Location = new System.Drawing.Point(12, 203);
            this.lblCurrentDiagnose.Name = "lblCurrentDiagnose";
            this.lblCurrentDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblCurrentDiagnose.TabIndex = 6093;
            this.lblCurrentDiagnose.Text = "目前诊断:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(13, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6097;
            this.label4.Text = "会诊答复:";
            // 
            // m_dtpConsultationDate
            // 
            this.m_dtpConsultationDate.BackColor = System.Drawing.SystemColors.Window;
            this.m_dtpConsultationDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpConsultationDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpConsultationDate.DropButtonBackColor = System.Drawing.Color.LightGray;
            this.m_dtpConsultationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpConsultationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpConsultationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpConsultationDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpConsultationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpConsultationDate.Location = new System.Drawing.Point(104, 555);
            this.m_dtpConsultationDate.m_BlnOnlyTime = false;
            this.m_dtpConsultationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpConsultationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpConsultationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpConsultationDate.Name = "m_dtpConsultationDate";
            this.m_dtpConsultationDate.ReadOnly = false;
            this.m_dtpConsultationDate.Size = new System.Drawing.Size(188, 22);
            this.m_dtpConsultationDate.TabIndex = 170;
            this.m_dtpConsultationDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpConsultationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtCaseHistory
            // 
            this.m_txtCaseHistory.AccessibleDescription = "简要病历";
            this.m_txtCaseHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCaseHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseHistory.Location = new System.Drawing.Point(8, 138);
            this.m_txtCaseHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseHistory.m_BlnPartControl = false;
            this.m_txtCaseHistory.m_BlnReadOnly = false;
            this.m_txtCaseHistory.m_BlnUnderLineDST = false;
            this.m_txtCaseHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseHistory.m_IntCanModifyTime = 6;
            this.m_txtCaseHistory.m_IntPartControlLength = 0;
            this.m_txtCaseHistory.m_IntPartControlStartIndex = 0;
            this.m_txtCaseHistory.m_StrUserID = "";
            this.m_txtCaseHistory.m_StrUserName = "";
            this.m_txtCaseHistory.Name = "m_txtCaseHistory";
            this.m_txtCaseHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseHistory.Size = new System.Drawing.Size(772, 56);
            this.m_txtCaseHistory.TabIndex = 110;
            this.m_txtCaseHistory.Text = "";
            this.m_txtCaseHistory.TextChanged += new System.EventHandler(this.m_txtCaseHistory_TextChanged);
            // 
            // m_txtConsultationOrder
            // 
            this.m_txtConsultationOrder.AccessibleDescription = "会诊目的";
            this.m_txtConsultationOrder.BackColor = System.Drawing.Color.White;
            this.m_txtConsultationOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtConsultationOrder.ForeColor = System.Drawing.Color.Black;
            this.m_txtConsultationOrder.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtConsultationOrder.Location = new System.Drawing.Point(8, 220);
            this.m_txtConsultationOrder.m_BlnIgnoreUserInfo = false;
            this.m_txtConsultationOrder.m_BlnPartControl = false;
            this.m_txtConsultationOrder.m_BlnReadOnly = false;
            this.m_txtConsultationOrder.m_BlnUnderLineDST = false;
            this.m_txtConsultationOrder.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtConsultationOrder.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtConsultationOrder.m_IntCanModifyTime = 6;
            this.m_txtConsultationOrder.m_IntPartControlLength = 0;
            this.m_txtConsultationOrder.m_IntPartControlStartIndex = 0;
            this.m_txtConsultationOrder.m_StrUserID = "";
            this.m_txtConsultationOrder.m_StrUserName = "";
            this.m_txtConsultationOrder.Name = "m_txtConsultationOrder";
            this.m_txtConsultationOrder.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtConsultationOrder.Size = new System.Drawing.Size(772, 98);
            this.m_txtConsultationOrder.TabIndex = 120;
            this.m_txtConsultationOrder.Text = "";
            // 
            // m_txtConsultationIdea
            // 
            this.m_txtConsultationIdea.AccessibleDescription = "会诊意见";
            this.m_txtConsultationIdea.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtConsultationIdea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtConsultationIdea.ForeColor = System.Drawing.Color.Black;
            this.m_txtConsultationIdea.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtConsultationIdea.Location = new System.Drawing.Point(9, 407);
            this.m_txtConsultationIdea.m_BlnIgnoreUserInfo = false;
            this.m_txtConsultationIdea.m_BlnPartControl = false;
            this.m_txtConsultationIdea.m_BlnReadOnly = true;
            this.m_txtConsultationIdea.m_BlnUnderLineDST = false;
            this.m_txtConsultationIdea.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtConsultationIdea.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtConsultationIdea.m_IntCanModifyTime = 6;
            this.m_txtConsultationIdea.m_IntPartControlLength = 0;
            this.m_txtConsultationIdea.m_IntPartControlStartIndex = 0;
            this.m_txtConsultationIdea.m_StrUserID = "";
            this.m_txtConsultationIdea.m_StrUserName = "";
            this.m_txtConsultationIdea.Name = "m_txtConsultationIdea";
            this.m_txtConsultationIdea.ReadOnly = true;
            this.m_txtConsultationIdea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtConsultationIdea.Size = new System.Drawing.Size(772, 112);
            this.m_txtConsultationIdea.TabIndex = 180;
            this.m_txtConsultationIdea.Text = "";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(604, 608);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 220;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_lsvEmployeeDoctor
            // 
            this.m_lsvEmployeeDoctor.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployeeDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.m_lsvEmployeeDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployeeDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_lsvEmployeeDoctor.FullRowSelect = true;
            this.m_lsvEmployeeDoctor.GridLines = true;
            this.m_lsvEmployeeDoctor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployeeDoctor.Location = new System.Drawing.Point(104, 583);
            this.m_lsvEmployeeDoctor.Name = "m_lsvEmployeeDoctor";
            this.m_lsvEmployeeDoctor.Size = new System.Drawing.Size(680, 21);
            this.m_lsvEmployeeDoctor.TabIndex = 210;
            this.m_lsvEmployeeDoctor.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployeeDoctor.View = System.Windows.Forms.View.SmallIcon;
            this.m_lsvEmployeeDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleName = "NoDefault";
            this.m_txtDoctorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtDoctorSign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctorSign.ForeColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(419, 545);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(100, 26);
            this.m_txtDoctorSign.TabIndex = 200;
            this.m_txtDoctorSign.Visible = false;
            this.m_txtDoctorSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown1);
            // 
            // gpbConsultationTime
            // 
            this.gpbConsultationTime.Controls.Add(this.rdbGeneral);
            this.gpbConsultationTime.Controls.Add(this.rdbOneDay);
            this.gpbConsultationTime.Controls.Add(this.rdbRightNow);
            this.gpbConsultationTime.Controls.Add(this.label11);
            this.gpbConsultationTime.Location = new System.Drawing.Point(110, 342);
            this.gpbConsultationTime.Name = "gpbConsultationTime";
            this.gpbConsultationTime.Size = new System.Drawing.Size(312, 40);
            this.gpbConsultationTime.TabIndex = 160;
            this.gpbConsultationTime.TabStop = false;
            this.gpbConsultationTime.Tag = "";
            this.gpbConsultationTime.Enter += new System.EventHandler(this.rdbIfEmergencyYes_CheckedChanged);
            // 
            // rdbGeneral
            // 
            this.rdbGeneral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbGeneral.Location = new System.Drawing.Point(210, 12);
            this.rdbGeneral.Name = "rdbGeneral";
            this.rdbGeneral.Size = new System.Drawing.Size(92, 24);
            this.rdbGeneral.TabIndex = 163;
            this.rdbGeneral.Text = "一般会诊";
            this.rdbGeneral.CheckedChanged += new System.EventHandler(this.rdbGeneral_CheckedChanged);
            // 
            // rdbOneDay
            // 
            this.rdbOneDay.Checked = true;
            this.rdbOneDay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbOneDay.Location = new System.Drawing.Point(100, 12);
            this.rdbOneDay.Name = "rdbOneDay";
            this.rdbOneDay.Size = new System.Drawing.Size(120, 24);
            this.rdbOneDay.TabIndex = 162;
            this.rdbOneDay.TabStop = true;
            this.rdbOneDay.Text = "请在24小时";
            this.rdbOneDay.CheckedChanged += new System.EventHandler(this.rdbOneDay_CheckedChanged);
            // 
            // rdbRightNow
            // 
            this.rdbRightNow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbRightNow.Location = new System.Drawing.Point(4, 12);
            this.rdbRightNow.Name = "rdbRightNow";
            this.rdbRightNow.Size = new System.Drawing.Size(104, 24);
            this.rdbRightNow.TabIndex = 161;
            this.rdbRightNow.Text = "请即来会诊";
            this.rdbRightNow.CheckedChanged += new System.EventHandler(this.rdbIfEmergencyYes_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(-98, -30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 29161;
            this.label11.Text = "请求会诊科室:";
            // 
            // m_lsvDoctorList
            // 
            this.m_lsvDoctorList.BackColor = System.Drawing.Color.White;
            this.m_lsvDoctorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvDoctorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvDoctorList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvDoctorList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvDoctorList.FullRowSelect = true;
            this.m_lsvDoctorList.GridLines = true;
            this.m_lsvDoctorList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDoctorList.Location = new System.Drawing.Point(492, 343);
            this.m_lsvDoctorList.Name = "m_lsvDoctorList";
            this.m_lsvDoctorList.Size = new System.Drawing.Size(102, 72);
            this.m_lsvDoctorList.TabIndex = 141;
            this.m_lsvDoctorList.UseCompatibleStateImageBehavior = false;
            this.m_lsvDoctorList.View = System.Windows.Forms.View.Details;
            this.m_lsvDoctorList.Visible = false;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 29159;
            this.label6.Text = "会诊日期:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 29161;
            this.label7.Text = "请求会诊科室:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(19, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 29166;
            this.label9.Text = "会诊者:";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(696, 608);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 221;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(538, 545);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000030;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // m_lsvEmployee_New
            // 
            this.m_lsvEmployee_New.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployee_New.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvEmployee_New.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader7});
            this.m_lsvEmployee_New.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployee_New.ForeColor = System.Drawing.Color.Black;
            this.m_lsvEmployee_New.FullRowSelect = true;
            this.m_lsvEmployee_New.GridLines = true;
            this.m_lsvEmployee_New.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployee_New.Location = new System.Drawing.Point(684, 343);
            this.m_lsvEmployee_New.Name = "m_lsvEmployee_New";
            this.m_lsvEmployee_New.Size = new System.Drawing.Size(102, 105);
            this.m_lsvEmployee_New.TabIndex = 10000029;
            this.m_lsvEmployee_New.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee_New.View = System.Windows.Forms.View.Details;
            this.m_lsvEmployee_New.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_txtSign
            // 
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(578, 545);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(100, 26);
            this.m_txtSign.TabIndex = 10000028;
            this.m_txtSign.Visible = false;
            // 
            // m_cmdMainDoctor
            // 
            this.m_cmdMainDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdMainDoctor.DefaultScheme = true;
            this.m_cmdMainDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdMainDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdMainDoctor.Hint = "";
            this.m_cmdMainDoctor.Location = new System.Drawing.Point(352, 322);
            this.m_cmdMainDoctor.Name = "m_cmdMainDoctor";
            this.m_cmdMainDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdMainDoctor.Size = new System.Drawing.Size(135, 24);
            this.m_cmdMainDoctor.TabIndex = 130;
            this.m_cmdMainDoctor.Text = "主治医师(科主任):";
            // 
            // m_cmdRequestSign
            // 
            this.m_cmdRequestSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRequestSign.DefaultScheme = true;
            this.m_cmdRequestSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRequestSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRequestSign.Hint = "";
            this.m_cmdRequestSign.Location = new System.Drawing.Point(596, 322);
            this.m_cmdRequestSign.Name = "m_cmdRequestSign";
            this.m_cmdRequestSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRequestSign.Size = new System.Drawing.Size(82, 24);
            this.m_cmdRequestSign.TabIndex = 145;
            this.m_cmdRequestSign.Tag = "1";
            this.m_cmdRequestSign.Text = "住院医师:";
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Enabled = false;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(9, 580);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(84, 24);
            this.m_cmdDoctorSign.TabIndex = 195;
            this.m_cmdDoctorSign.Text = "会诊医师:";
            this.m_cmdDoctorSign.Click += new System.EventHandler(this.m_cmdDoctorSign_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(13, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 6097;
            this.label3.Text = "会诊答复:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(440, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 29159;
            this.label5.Text = "申请会诊日期:";
            this.label5.Visible = false;
            // 
            // ctlTimePicker1
            // 
            this.ctlTimePicker1.BorderColor = System.Drawing.Color.Black;
            this.ctlTimePicker1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.ctlTimePicker1.DropButtonBackColor = System.Drawing.Color.White;
            this.ctlTimePicker1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.ctlTimePicker1.DropButtonForeColor = System.Drawing.Color.White;
            this.ctlTimePicker1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.ctlTimePicker1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctlTimePicker1.Location = new System.Drawing.Point(552, 365);
            this.ctlTimePicker1.m_BlnOnlyTime = false;
            this.ctlTimePicker1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.ctlTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ctlTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ctlTimePicker1.Name = "ctlTimePicker1";
            this.ctlTimePicker1.ReadOnly = true;
            this.ctlTimePicker1.Size = new System.Drawing.Size(188, 22);
            this.ctlTimePicker1.TabIndex = 170;
            this.ctlTimePicker1.TextBackColor = System.Drawing.Color.White;
            this.ctlTimePicker1.TextForeColor = System.Drawing.Color.Black;
            this.ctlTimePicker1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000031;
            this.label2.Text = "会诊时间:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(8, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 3);
            this.groupBox1.TabIndex = 10000032;
            this.groupBox1.TabStop = false;
            // 
            // m_lblOtherHopitalApply
            // 
            this.m_lblOtherHopitalApply.AutoSize = true;
            this.m_lblOtherHopitalApply.Location = new System.Drawing.Point(300, 529);
            this.m_lblOtherHopitalApply.Name = "m_lblOtherHopitalApply";
            this.m_lblOtherHopitalApply.Size = new System.Drawing.Size(112, 14);
            this.m_lblOtherHopitalApply.TabIndex = 10000033;
            this.m_lblOtherHopitalApply.Text = "会诊医院及科室:";
            this.m_lblOtherHopitalApply.Visible = false;
            // 
            // m_txtOtherHospitalApply
            // 
            this.m_txtOtherHospitalApply.AccessibleDescription = "会诊答复>>会诊医院及科室";
            this.m_txtOtherHospitalApply.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtOtherHospitalApply.Location = new System.Drawing.Point(419, 525);
            this.m_txtOtherHospitalApply.Name = "m_txtOtherHospitalApply";
            this.m_txtOtherHospitalApply.ReadOnly = true;
            this.m_txtOtherHospitalApply.Size = new System.Drawing.Size(193, 23);
            this.m_txtOtherHospitalApply.TabIndex = 10000034;
            this.m_txtOtherHospitalApply.Visible = false;
            // 
            // m_lblOtherHopital
            // 
            this.m_lblOtherHopital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblOtherHopital.AutoSize = true;
            this.m_lblOtherHopital.Location = new System.Drawing.Point(482, 67);
            this.m_lblOtherHopital.Name = "m_lblOtherHopital";
            this.m_lblOtherHopital.Size = new System.Drawing.Size(112, 14);
            this.m_lblOtherHopital.TabIndex = 10000033;
            this.m_lblOtherHopital.Text = "会诊医院及科室:";
            this.m_lblOtherHopital.Visible = false;
            // 
            // m_txtOtherHospital
            // 
            this.m_txtOtherHospital.AccessibleDescription = "会诊医院及科室";
            this.m_txtOtherHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOtherHospital.BackColor = System.Drawing.Color.White;
            this.m_txtOtherHospital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOtherHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherHospital.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherHospital.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherHospital.Location = new System.Drawing.Point(598, 63);
            this.m_txtOtherHospital.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherHospital.m_BlnPartControl = false;
            this.m_txtOtherHospital.m_BlnReadOnly = false;
            this.m_txtOtherHospital.m_BlnUnderLineDST = false;
            this.m_txtOtherHospital.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherHospital.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherHospital.m_IntCanModifyTime = 6;
            this.m_txtOtherHospital.m_IntPartControlLength = 0;
            this.m_txtOtherHospital.m_IntPartControlStartIndex = 0;
            this.m_txtOtherHospital.m_StrUserID = "";
            this.m_txtOtherHospital.m_StrUserName = "";
            this.m_txtOtherHospital.Multiline = false;
            this.m_txtOtherHospital.Name = "m_txtOtherHospital";
            this.m_txtOtherHospital.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOtherHospital.Size = new System.Drawing.Size(191, 23);
            this.m_txtOtherHospital.TabIndex = 10000035;
            this.m_txtOtherHospital.Text = "";
            this.m_txtOtherHospital.Visible = false;
            this.m_txtOtherHospital.TextChanged += new System.EventHandler(this.m_txtOtherHospital_TextChanged);
            // 
            // m_txtMainDoctor
            // 
            this.m_txtMainDoctor.Location = new System.Drawing.Point(490, 322);
            this.m_txtMainDoctor.Name = "m_txtMainDoctor";
            this.m_txtMainDoctor.Size = new System.Drawing.Size(100, 23);
            this.m_txtMainDoctor.TabIndex = 140;
            // 
            // m_txtRequestSign
            // 
            this.m_txtRequestSign.Location = new System.Drawing.Point(684, 322);
            this.m_txtRequestSign.Name = "m_txtRequestSign";
            this.m_txtRequestSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtRequestSign.TabIndex = 150;
            // 
            // m_txtApplyConsultationDept
            // 
            this.m_txtApplyConsultationDept.AccessibleDescription = "申请会诊科室";
            this.m_txtApplyConsultationDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtApplyConsultationDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtApplyConsultationDept.Location = new System.Drawing.Point(618, 34);
            this.m_txtApplyConsultationDept.Name = "m_txtApplyConsultationDept";
            this.m_txtApplyConsultationDept.Size = new System.Drawing.Size(152, 23);
            this.m_txtApplyConsultationDept.TabIndex = 10000036;
            this.m_txtApplyConsultationDept.Leave += new System.EventHandler(this.m_txtApplyConsultationDept_Leave);
            this.m_txtApplyConsultationDept.TextChanged += new System.EventHandler(this.m_txtApplyConsultationDept_TextChanged);
            // 
            // m_cmdShowAllDept
            // 
            this.m_cmdShowAllDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowAllDept.Location = new System.Drawing.Point(769, 34);
            this.m_cmdShowAllDept.Name = "m_cmdShowAllDept";
            this.m_cmdShowAllDept.Size = new System.Drawing.Size(20, 23);
            this.m_cmdShowAllDept.TabIndex = 10000037;
            this.m_cmdShowAllDept.Text = "↓";
            this.m_cmdShowAllDept.UseVisualStyleBackColor = true;
            this.m_cmdShowAllDept.Click += new System.EventHandler(this.m_cmdShowAllDept_Click);
            // 
            // m_txtConsulter
            // 
            this.m_txtConsulter.AccessibleDescription = "会诊者";
            this.m_txtConsulter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtConsulter.Enabled = false;
            this.m_txtConsulter.Location = new System.Drawing.Point(104, 525);
            this.m_txtConsulter.Name = "m_txtConsulter";
            this.m_txtConsulter.Size = new System.Drawing.Size(190, 23);
            this.m_txtConsulter.TabIndex = 10000038;
            // 
            // m_pnlSearchWindow
            // 
            this.m_pnlSearchWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlSearchWindow.Controls.Add(this.m_lsvDeptList);
            this.m_pnlSearchWindow.Controls.Add(this.m_txtSearchDept);
            this.m_pnlSearchWindow.Controls.Add(this.label8);
            this.m_pnlSearchWindow.Location = new System.Drawing.Point(592, 108);
            this.m_pnlSearchWindow.Name = "m_pnlSearchWindow";
            this.m_pnlSearchWindow.Size = new System.Drawing.Size(192, 165);
            this.m_pnlSearchWindow.TabIndex = 10000039;
            this.m_pnlSearchWindow.Visible = false;
            // 
            // m_lsvDeptList
            // 
            this.m_lsvDeptList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader8});
            this.m_lsvDeptList.FullRowSelect = true;
            this.m_lsvDeptList.GridLines = true;
            this.m_lsvDeptList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDeptList.Location = new System.Drawing.Point(-1, 24);
            this.m_lsvDeptList.MultiSelect = false;
            this.m_lsvDeptList.Name = "m_lsvDeptList";
            this.m_lsvDeptList.Size = new System.Drawing.Size(192, 140);
            this.m_lsvDeptList.TabIndex = 2;
            this.m_lsvDeptList.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeptList.View = System.Windows.Forms.View.Details;
            this.m_lsvDeptList.DoubleClick += new System.EventHandler(this.m_lsvDeptList_DoubleClick);
            this.m_lsvDeptList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvDeptList_KeyDown);
            this.m_lsvDeptList.Leave += new System.EventHandler(this.m_lsvDeptList_Leave);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 100;
            // 
            // m_txtSearchDept
            // 
            this.m_txtSearchDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtSearchDept.Location = new System.Drawing.Point(30, 0);
            this.m_txtSearchDept.Name = "m_txtSearchDept";
            this.m_txtSearchDept.Size = new System.Drawing.Size(160, 23);
            this.m_txtSearchDept.TabIndex = 0;
            this.m_txtSearchDept.Leave += new System.EventHandler(this.m_txtSearchDept_Leave);
            this.m_txtSearchDept.TextChanged += new System.EventHandler(this.m_txtSearchDept_TextChanged);
            this.m_txtSearchDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSearchDept_KeyDown);
            // 
            // label8
            // 
            this.label8.ImageIndex = 0;
            this.label8.ImageList = this.imageList1;
            this.label8.Location = new System.Drawing.Point(-1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 24);
            this.label8.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // m_txtAsker
            // 
            this.m_txtAsker.AccessibleDescription = "请求会诊科室";
            this.m_txtAsker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtAsker.Enabled = false;
            this.m_txtAsker.Location = new System.Drawing.Point(114, 324);
            this.m_txtAsker.Name = "m_txtAsker";
            this.m_txtAsker.Size = new System.Drawing.Size(216, 23);
            this.m_txtAsker.TabIndex = 10000036;
            this.m_txtAsker.Leave += new System.EventHandler(this.m_txtApplyConsultationDept_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 29161;
            this.label10.Text = "请求会诊科室:";
            // 
            // frmConsultation
            // 
            this.AccessibleDescription = "会诊记录";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(807, 671);
            this.Controls.Add(this.m_pnlSearchWindow);
            this.Controls.Add(this.m_txtCaseHistory);
            this.Controls.Add(this.m_txtConsultationOrder);
            this.Controls.Add(this.m_txtConsulter);
            this.Controls.Add(this.m_txtMainDoctor);
            this.Controls.Add(this.m_txtRequestSign);
            this.Controls.Add(this.m_txtOtherHospitalApply);
            this.Controls.Add(this.m_lblOtherHopitalApply);
            this.Controls.Add(this.m_lsvEmployee_New);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            //this.Controls.Add(this.m_txtConsultationIdea);
            this.Controls.Add(this.m_lsvDoctorList);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCurrentDiagnose);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.m_cmdRequestSign);
            this.Controls.Add(this.m_cmdMainDoctor);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_txtAsker);
            this.Controls.Add(this.gpbConsultationTime);
            this.Controls.Add(this.m_lsvEmployeeDoctor);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_dtpConsultationDate);
            this.Controls.Add(this.ctlTimePicker1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConsultation";
            this.Text = "会诊记录";
            this.Load += new System.EventHandler(this.frmConsultation_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ctlTimePicker1, 0);
            this.Controls.SetChildIndex(this.m_dtpConsultationDate, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvEmployeeDoctor, 0);
            this.Controls.SetChildIndex(this.gpbConsultationTime, 0);
            this.Controls.SetChildIndex(this.m_txtAsker, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdMainDoctor, 0);
            this.Controls.SetChildIndex(this.m_cmdRequestSign, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblCurrentDiagnose, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_lsvDoctorList, 0);
            //this.Controls.SetChildIndex(this.m_txtConsultationIdea, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.m_lsvEmployee_New, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_lblOtherHopitalApply, 0);
            this.Controls.SetChildIndex(this.m_txtOtherHospitalApply, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtRequestSign, 0);
            this.Controls.SetChildIndex(this.m_txtMainDoctor, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtConsulter, 0);
            this.Controls.SetChildIndex(this.m_txtConsultationOrder, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_txtCaseHistory, 0);
            this.Controls.SetChildIndex(this.m_pnlSearchWindow, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.gpbConsultationTime.ResumeLayout(false);
            this.gpbConsultationTime.PerformLayout();
            this.m_pnlSearchWindow.ResumeLayout(false);
            this.m_pnlSearchWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsConsultationInfo objTrackInfo = new clsConsultationInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "会诊记录";

            //设置m_strTitle和m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                //				m_txtRecordTitle.Text=((clsGeneralDiseaseRecordContent)m_objCurrentRecordContent).m_strRecordTitle;//objTrackInfo.m_StrTitle;
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
            }
            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            m_strCurrentOpenDate = "";

            //清空具体记录内容
            m_txtApplyConsultationDept.Clear();
            m_txtApplyConsultationDept.Tag = null;
            m_txtCaseHistory.m_mthClearText();
            m_txtConsultationOrder.m_mthClearText();
            m_txtConsultationIdea.m_mthClearText();
            m_lsvEmployeeDoctor.Items.Clear();
            m_txtMainDoctor.Text = "";
            m_txtMainDoctor.Tag = null;
            m_txtRequestSign.Text = "";
            m_txtRequestSign.Tag = null;
            m_dtpConsultationDate.Value = System.DateTime.Now;
            rdbOneDay.Checked = true;

            m_txtApplyConsultationDept.Enabled = true;
            m_cmdShowAllDept.Enabled = true;

            if (m_dtbDept != null && m_dtbDept.Rows.Count > 0 && m_ObjCurrentArea != null)
            {
                for (int i = 0; i < m_dtbDept.Rows.Count; i++)
                {
                    if (m_dtbDept.Rows[i]["DeptID"].ToString() == m_ObjCurrentArea.m_strDEPTID_CHR)
                    {
                        m_txtAsker.Text = m_ObjCurrentArea.m_strDEPTNAME_VCHR;
                        m_txtAsker.Tag = m_ObjCurrentArea.m_strDEPTID_CHR;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        /// 从病程记录窗体添加或修改时调到
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
                    control.Top = control.Top - 150;
                    control.Left = control.Left - 10;
                }

                cmdConfirm.Visible = true;
                m_cmdClose.Visible = true;

                int intTop = 45;
                lblApply.Top += intTop;
                lblCreateDateTitle.Top += intTop;
                //m_cboApplyConsultationDept.Top += intTop;
                m_dtpCreateDate.Top += intTop;

                this.Size = new Size(this.Size.Width, this.Size.Height - 150);
                this.CenterToParent();
            }
            m_intFormID = 1;
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

            if (m_txtApplyConsultationDept.Tag == null && m_txtApplyConsultationDept.Text != "外院会诊")
            {
                clsPublicFunction.ShowInformationMessageBox("请选择会诊科室!");
                return null;
            }

            if (m_txtAsker.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择请求会诊者!");
                return null;
            }

            if (m_txtMainDoctor.Tag == null && m_txtRequestSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("须主治医师(科主任)或住院医生任一人签名！");
                return null;
            }
        
            //从界面获取表单值
            clsConsultationRecordContent objContent = new clsConsultationRecordContent();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            if (gpbConsultationTime.Tag != null && gpbConsultationTime.Tag.ToString() != "")
            {
                objContent.m_intConsultationTime = Convert.ToInt16(gpbConsultationTime.Tag);
            }
            else
            {
                objContent.m_intConsultationTime = 1;
            }

            if (m_txtApplyConsultationDept.Tag != null)
            {
                objContent.m_strApplyConsultationDeptID = m_txtApplyConsultationDept.Tag.ToString();
            }
            objContent.m_strApplyConsultationDeptName = m_txtApplyConsultationDept.Text;

            objContent.m_strAskConsultationDeptID = m_txtAsker.Tag.ToString();
            objContent.m_strAskConsultationDeptName = m_txtAsker.Text;

            if (m_txtConsulter.Tag != null)
            {
                objContent.m_strConsultationDeptID = m_txtConsulter.Tag.ToString();
            }
            objContent.m_strConsultationDeptName = m_txtConsulter.Text;

            if (m_txtOtherHospital.Visible)
            {
                objContent.m_strOtherHospital_RIGHT = m_txtOtherHospital.m_strGetRightText();
                objContent.m_strOtherHospital = m_txtOtherHospital.Text;
                objContent.m_strOtherHospitalXML = m_txtOtherHospital.m_strGetXmlText();
            }

            objContent.m_strCaseHistory_Right = m_txtCaseHistory.m_strGetRightText();
            objContent.m_strCaseHistory = m_txtCaseHistory.Text;
            objContent.m_strCaseHistoryXml = m_txtCaseHistory.m_strGetXmlText();

            objContent.m_strConsultationOrder_Right = m_txtConsultationOrder.m_strGetRightText();
            objContent.m_strConsultationOrder = m_txtConsultationOrder.Text;
            objContent.m_strConsultationOrderXml = m_txtConsultationOrder.m_strGetXmlText();

            objContent.m_strConsultationIdea_Right = m_txtConsultationIdea.m_strGetRightText();
            objContent.m_strConsultationIdea = m_txtConsultationIdea.Text;
            objContent.m_strConsultationIdeaXml = m_txtConsultationIdea.m_strGetXmlText();

            if (string.IsNullOrEmpty(m_txtConsultationIdea.Text))
            {
                objContent.m_intHASREPLIED = 0;
            }
            else
            {
                objContent.m_intHASREPLIED = 1;
            }

            if (m_txtRequestSign.Text != "" && m_txtRequestSign.Tag != null)
            {
                objContent.m_strRequestDoctorIDArr = new string[1];
                objContent.m_strRequestDoctorNameArr = new string[1];
                objContent.m_strRequestDoctorIDArr[0] = ((clsEmrEmployeeBase_VO)m_txtRequestSign.Tag).m_strEMPNO_CHR;
                objContent.m_strRequestDoctorNameArr[0] = m_txtRequestSign.Text;
            }
            if (m_lsvEmployeeDoctor.Items.Count > 0)
            {
                objContent.m_strConsultationDoctorIDArr = new string[m_lsvEmployeeDoctor.Items.Count];
                objContent.m_strConsultationDoctorNameArr = new string[m_lsvEmployeeDoctor.Items.Count];
                for (int i = 0; i < m_lsvEmployeeDoctor.Items.Count; i++)
                {
                    objContent.m_strConsultationDoctorIDArr[i] = m_lsvEmployeeDoctor.Items[i].SubItems[1].Text;
                    objContent.m_strConsultationDoctorNameArr[i] = m_lsvEmployeeDoctor.Items[i].SubItems[0].Text;
                }
            }
            //			else
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("请至少一个会诊医生签名!");
            //				return null;
            //			}

            objContent.m_dtmConsultationDate = m_dtpConsultationDate.Value;
            if (m_txtMainDoctor.Tag != null)
            {
                objContent.m_strMainDoctorID = ((clsEmrEmployeeBase_VO)m_txtMainDoctor.Tag).m_strEMPNO_CHR;
            }
            else
                objContent.m_strMainDoctorID = "";
            return objContent;
        }

        private void rdbIfEmergencyYes_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbRightNow.Checked)
                gpbConsultationTime.Tag = "1";
            //			else if(rdbOneDay.Checked)
            //				gpbConsultationTime.Tag = "2";
            //			else if(rdbGeneral.Checked)
            //				gpbConsultationTime.Tag = "3";
        }

        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            clsConsultationRecordContent objContent = (clsConsultationRecordContent)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现

            m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (objContent.m_strApplyConsultationDeptID != null)
            {
                this.m_txtApplyConsultationDept.Tag = objContent.m_strApplyConsultationDeptID;
                this.m_txtApplyConsultationDept.Text = objContent.m_strApplyConsultationDeptName;
            }
            else
            {
                this.m_txtApplyConsultationDept.Text = "外院会诊";
            }
            if (objContent.m_strAskConsultationDeptID != null)
            {
                this.m_txtAsker.Tag = objContent.m_strAskConsultationDeptID;
                this.m_txtAsker.Text = objContent.m_strAskConsultationDeptName;
            }
            if (objContent.m_strConsultationDeptID != null)
            {
                this.m_txtConsulter.Tag = objContent.m_strConsultationDeptID;
                this.m_txtConsulter.Text = objContent.m_strConsultationDeptName;
            }
            else
            {
                this.m_txtConsulter.Text = "外院会诊";
            }

            if ((objContent.m_strApplyConsultationDeptID == null || objContent.m_strApplyConsultationDeptID == string.Empty)
                && (objContent.m_strConsultationDeptID == null || objContent.m_strConsultationDeptID == string.Empty))
            {
                m_txtApplyConsultationDept.Tag = null;
                m_txtApplyConsultationDept.Text = "外院会诊";
                m_txtConsulter.Tag = null;
                m_txtConsulter.Text = "外院会诊";
                m_txtOtherHospital.m_mthSetNewText(objContent.m_strOtherHospital, objContent.m_strOtherHospitalXML);
                m_txtOtherHospitalApply.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOtherHospital, objContent.m_strOtherHospitalXML);
            }
            gpbConsultationTime.Tag = objContent.m_intConsultationTime;
            if ((int)gpbConsultationTime.Tag == 1)
                rdbRightNow.Checked = true;
            else if ((int)gpbConsultationTime.Tag == 2)
                rdbOneDay.Checked = true;
            else if ((int)gpbConsultationTime.Tag == 3)
                rdbGeneral.Checked = true;

            m_txtCaseHistory.m_mthClearText();
            m_txtCaseHistory.m_mthSetNewText(objContent.m_strCaseHistory, objContent.m_strCaseHistoryXml);

            m_txtConsultationOrder.m_mthClearText();
            m_txtConsultationOrder.m_mthSetNewText(objContent.m_strConsultationOrder, objContent.m_strConsultationOrderXml);

            m_txtConsultationIdea.m_mthClearText();
            m_txtConsultationIdea.m_mthSetNewText(objContent.m_strConsultationIdea, objContent.m_strConsultationIdeaXml);
            string[] strArr2 = new string[2];
            if(objContent.m_strRequestDoctorIDArr != null)
                strArr2[0] = objContent.m_strRequestDoctorIDArr[0];
            strArr2[1] = objContent.m_strMainDoctorID;
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { m_txtRequestSign, m_txtMainDoctor }, strArr2, new bool[] { true,true });
            //clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            //if (objContent.m_strRequestDoctorIDArr != null)
            //{
            //    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRequestDoctorIDArr[0], out objEmpVO);
            //    m_txtRequestSign.Text = objContent.m_strRequestDoctorNameArr[0];
            //    m_txtRequestSign.Tag = objEmpVO;
            //}

            if (objContent.m_strConsultationDoctorIDArr != null)
            {
                for (int i = 0 ; i < objContent.m_strConsultationDoctorIDArr.Length ; i++)
                {
                    ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strConsultationDoctorNameArr[i], objContent.m_strConsultationDoctorIDArr[i] });
                    m_lsvEmployeeDoctor.Items.Add(lviNewItem);
                }
            }
            //if (objContent.m_strMainDoctorID != "")
            //{
            //    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strMainDoctorID, out objEmpVO);
            //    m_txtMainDoctor.Text = objContent.m_strMainDoctorName;
            //    m_txtMainDoctor.Tag = objEmpVO;
            //}

            m_dtpConsultationDate.Value = objContent.m_dtmConsultationDate;

            m_txtApplyConsultationDept.Enabled = false;
            m_cmdShowAllDept.Enabled = false;
            //if (m_txtApplyConsultationDept.Text == "外院会诊")
            //{
            //    m_txtConsultationIdea.ReadOnly = false;
            //    m_dtpConsultationDate.Enabled = true;
            //}
            //else
            //{
            //    m_txtConsultationIdea.ReadOnly = true;
            //    m_dtpConsultationDate.Enabled = false;
            //}
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

        private int m_intFormID = 21;
        public override int m_IntFormID
        {
            get
            {
                return m_intFormID;
            }
        }

        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            clsConsultationRecordContent objContent = (clsConsultationRecordContent)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            if (objContent.m_strApplyConsultationDeptID != null)
            {
                this.m_txtApplyConsultationDept.Tag = objContent.m_strApplyConsultationDeptID;
                this.m_txtApplyConsultationDept.Text = objContent.m_strApplyConsultationDeptName;
            }
            else
            {
                this.m_txtApplyConsultationDept.Text = "外院会诊";
            }
            if (objContent.m_strAskConsultationDeptID != null)
            {
                this.m_txtAsker.Tag = objContent.m_strAskConsultationDeptID;
                this.m_txtAsker.Text = objContent.m_strAskConsultationDeptName;
            }
            if (objContent.m_strConsultationDeptID != null)
            {
                this.m_txtConsulter.Tag = objContent.m_strConsultationDeptID;
                this.m_txtConsulter.Text = objContent.m_strConsultationDeptName;
            }
            else
            {
                this.m_txtConsulter.Text = "外院会诊";
            }

            if ((objContent.m_strApplyConsultationDeptID == null || objContent.m_strApplyConsultationDeptID == string.Empty)
                && (objContent.m_strConsultationDeptID == null || objContent.m_strConsultationDeptID == string.Empty))
            {
                m_txtApplyConsultationDept.Tag = null;
                m_txtApplyConsultationDept.Text = "外院会诊";
                m_txtConsulter.Tag = null;
                m_txtConsulter.Text = "外院会诊";
                m_txtOtherHospital.m_mthSetNewText(objContent.m_strOtherHospital, objContent.m_strOtherHospitalXML);
                m_txtOtherHospitalApply.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOtherHospital, objContent.m_strOtherHospitalXML);
            }

            gpbConsultationTime.Tag = objContent.m_intConsultationTime;
            if ((int)gpbConsultationTime.Tag == 1)
                rdbRightNow.Checked = true;
            else if ((int)gpbConsultationTime.Tag == 2)
                rdbOneDay.Checked = true;
            else if ((int)gpbConsultationTime.Tag == 3)
                rdbGeneral.Checked = true;

            m_txtCaseHistory.m_mthClearText();
            m_txtCaseHistory.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseHistory, objContent.m_strCaseHistoryXml);

            m_txtConsultationOrder.m_mthClearText();
            m_txtConsultationOrder.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strConsultationOrder, objContent.m_strConsultationOrderXml);

            m_txtConsultationIdea.m_mthClearText();
            m_txtConsultationIdea.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strConsultationIdea, objContent.m_strConsultationIdeaXml);
        }

        /// <summary>
        /// 获取会诊记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取会诊记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.Consultation);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsConsultationRecordContent objContent = (clsConsultationRecordContent)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现		
            m_txtApplyConsultationDept.Text = objContent.m_strApplyConsultationDeptName;
            gpbConsultationTime.Tag = objContent.m_intConsultationTime;

            m_txtCaseHistory.m_mthClearText();
            m_txtCaseHistory.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseHistory, objContent.m_strCaseHistoryXml);

            m_txtConsultationOrder.m_mthClearText();
            m_txtConsultationOrder.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strConsultationOrder, objContent.m_strConsultationOrderXml);

            m_txtConsultationIdea.m_mthClearText();
            m_txtConsultationIdea.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strConsultationIdea, objContent.m_strConsultationIdeaXml);

            if (objContent.m_strRequestDoctorIDArr != null)
            {
                m_txtRequestSign.Text = objContent.m_strRequestDoctorNameArr[0];
            }

            if (objContent.m_strConsultationDoctorIDArr != null)
            {
                for (int i = 0; i < objContent.m_strRequestDoctorIDArr.Length; i++)
                {
                    ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strConsultationDoctorNameArr[i], objContent.m_strConsultationDoctorIDArr[i] });
                    m_lsvEmployeeDoctor.Items.Add(lviNewItem);
                }
            }

            m_dtpConsultationDate.Value = objContent.m_dtmConsultationDate;
            m_txtMainDoctor.Text = objContent.m_strMainDoctorName;
        }

        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "会诊记录";
        }


        #region 添加键盘快捷键
        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //switch(e.KeyCode)
            //case Keys.Enter
            switch (e.KeyValue)
            {
                case 13:// enter						
                    //else if(((Control)sender).Name=="m_lsvDoctorList")
                    //{
                    //    m_lsvDoctorList_DoubleClick(sender,null);						
                    //}

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

        /// <summary>
        /// 显示医生列表
        /// </summary>
        /// <param name="p_strDoctorNameLike">医生号</param>
        private void m_mthGetDoctorList(string p_strDoctorNameLike)
        {

            /*
             * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
             * 在相应的位置显示ListView。
             */

            if (p_strDoctorNameLike.Length == 0)
            {
                m_lsvDoctorList.Visible = false;
                return;
            }

            clsEmployee[] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike, m_objCurrentContext.m_ObjDepartment);

            if (objDoctorArr == null)
            {
                m_lsvDoctorList.Visible = false;
                return;
            }

            m_lsvDoctorList.Items.Clear();

            for (int i = 0; i < objDoctorArr.Length; i++)
            {
                ListViewItem lviDoctor = new ListViewItem(
                    new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
                lviDoctor.Tag = objDoctorArr[i];

                m_lsvDoctorList.Items.Add(lviDoctor);
            }

            m_mthChangeListViewLastColumnWidth(m_lsvDoctorList);
            m_lsvDoctorList.BringToFront();
            m_lsvDoctorList.Visible = true;
        }


        #region m_lsvDoctorList事件，无用去除
        //        private void m_lsvDoctorList_DoubleClick(object sender, System.EventArgs e)
        //        {
        //            if(sender==null)
        //            {
        //                clsPublicFunction.ShowInformationMessageBox("参数错误!");						
        //                return;
        //            }

        //            /*
        //             * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
        //             */
        //            if(m_lsvDoctorList.SelectedItems.Count <= 0)
        //                return;

        //            clsEmployee objEmp = (clsEmployee)m_lsvDoctorList.SelectedItems[0].Tag;

        //            if(objEmp == null)
        //                return;

        ////			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
        ////				return;

        //            m_lsvDoctorList.Visible = false;

        //            if((((Control)sender).Top==m_txtMainDoctor.Bottom && ((Control)sender).Left==m_txtMainDoctor.Left) || ((Control)sender).Name=="m_txtMainDoctor")
        //            {
        //                m_txtMainDoctor.Text=objEmp.m_StrLastName;
        //                m_txtMainDoctor.Tag= objEmp.m_strEmployeeNewID;
        //                m_txtMainDoctor.Focus();
        //            }
        //            else if((((Control)sender).Top==m_txtRequestSign.Bottom && ((Control)sender).Left==m_txtRequestSign.Left) || ((Control)sender).Name=="m_txtRequestSign")
        //            {
        //                m_txtRequestSign.Text=objEmp.m_StrLastName;
        //                m_txtRequestSign.Tag= objEmp.m_strEmployeeNewID;
        //                m_txtRequestSign.Focus();
        //            }
        //            else if((((Control)sender).Bottom==m_txtDoctorSign.Top && ((Control)sender).Left==m_txtDoctorSign.Left) || ((Control)sender).Name=="m_txtDoctorSign")
        //            {
        //                for(int i=0;i<m_lsvEmployeeDoctor.Items.Count;i++)
        //                {
        //                    if(m_lsvEmployeeDoctor.Items[i].SubItems[1].Text==objEmp.m_StrEmployeeID)
        //                    {
        //                        clsPublicFunction.ShowInformationMessageBox("对不起,医生不能重复签名!");
        //                        return;
        //                    }
        //                }
        //                ListViewItem lviNewItem=m_lsvEmployeeDoctor.Items.Add(objEmp.m_StrLastName);
        //                lviNewItem.SubItems.Add(objEmp.m_strEmployeeNewID);					

        //                m_lsvDoctorList.Visible = false;
        //                m_txtDoctorSign.Text="";//清空
        //                m_txtDoctorSign.Focus();
        //            }
        //        }

        //private void m_lsvDoctorList_LostFocus(object sender,EventArgs e)
        //{					
        //    if(!((Control)sender).Focused && !m_lsvDoctorList.Focused)
        //    {
        //        m_lsvDoctorList.Visible=false;				
        //    }				
        //}	
        #endregion
        #endregion

        private void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private bool m_blnIsMainWindow = true;
        private clsDepartment[] objDeptArr;
        private DataTable m_dtbDept;
        private void frmConsultation_Load(object sender, System.EventArgs e)
        {
            m_mthfrmLoad();
            if (m_blnIsMainWindow == true)
                m_mthSetQuickKeys();
            else
            {
                //				m_cmdNewTemplate.Visible = true;
            }

            gpbConsultationTime.Tag = false;
            m_lsvDoctorList.Visible = false;

            long lngRes = m_objDomain.m_lngGetAllDept(out m_dtbDept);

            object[] objTemp = new object[4];
            objTemp[0] = string.Empty;
            objTemp[1] = string.Empty;
            objTemp[2] = "外院会诊";
            objTemp[3] = string.Empty;
            m_dtbDept.Rows.Add(objTemp);

            if (m_dtbDept != null && m_dtbDept.Rows.Count > 0)
            {
                for (int i = 0; i < m_dtbDept.Rows.Count; i++)
                {
                    if (m_dtbDept.Rows[i]["DeptName"].ToString() == m_cboDept.Text)
                    {
                        m_txtAsker.Text = m_cboDept.Text;
                        m_txtAsker.Tag = m_dtbDept.Rows[i]["DeptID"].ToString();
                        break;
                    }
                }
            }
            gpbConsultationTime.Tag = "1";

            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            this.m_dtpConsultationDate.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Minute;
            this.m_dtpConsultationDate.m_mthResetSize();
            m_txtCaseHistory.Focus(); 
            //避免在会诊答复里出现右键菜单
            this.Controls.Add(this.m_txtConsultationIdea); 
            this.Controls.SetChildIndex(this.m_txtConsultationIdea, 0);
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("复制(&C)", new EventHandler(m_mthCopy)));
            m_txtConsultationIdea.ContextMenu = cm;
          
        }
        private void m_mthCopy(object sender, EventArgs e)
        {
            Copy();
        }
        private void m_txtCaseHistory_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void m_lsvEmployeeRequest_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected override void m_trvCreateDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (m_blnCanTreeNodeAfterSelectEventTakePlace == false)
                return;

            m_mthRecordChangedToSave();
            m_mthSetApplyReadOnly();

            m_mthClearPatientRecordInfo();
            m_blnIsNoMainDoctorBefore = true;
            m_mthSetControlReadOnly(this, false);

            if (m_trvCreateDate.SelectedNode == m_trnRoot)
            {
                m_mthSelectRootNode();
                if (m_objCurrentPatient != null)
                {
                    m_mthSetDefaultValue(m_objCurrentPatient);
                }

                //当前处于新增记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
            }
            else if (m_trvCreateDate.SelectedNode.Tag != null)
            {
                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthSetSelectedRecord(m_objCurrentPatient, m_trvCreateDate.SelectedNode.Tag.ToString());

                //当前处于修改记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                if (m_objCurrentRecordContent != null)
                {
                    clsConsultationRecordContent objContent = (clsConsultationRecordContent)m_objCurrentRecordContent;
                    if (!string.IsNullOrEmpty(objContent.m_strMainDoctorID))
                    {
                        m_blnIsNoMainDoctorBefore = false;
                    }
                    if ((objContent.m_strConsultationIdea != null && objContent.m_strConsultationIdea != string.Empty)
                        || (objContent.m_strConsultationDoctorIDArr != null && objContent.m_strConsultationDoctorIDArr.Length > 0))
                    {
                        //如果已回复会诊通知，则窗体处于禁止输入状态
                        m_mthSetControlReadOnly(this, true);
                    }
                }
            }

            m_mthAddFormStatusForClosingSave();
            m_mthSetApplyReadOnly();

            if (m_txtApplyConsultationDept.Text == "外院会诊")
            {
                m_txtConsultationIdea.m_BlnReadOnly = false;
                m_dtpConsultationDate.Enabled = true;
            }
            else
            {
                m_txtConsultationIdea.m_BlnReadOnly = true;
                m_dtpConsultationDate.Enabled = false;
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
        clsConsultationPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new clsConsultationPrintTool();
                objPrintTool.m_mthInitPrintTool(null);
                m_blnHasInitPrintTool = true;
            }
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
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
                    if (((Control)sender).Name == "m_lsvDoctorList")
                    {
                        //m_lsvDoctorList_DoubleClick(sender,null);						
                    }

                    break;

                case 38:

                case 40:
                    break;
            }
        }

        private void rdbOneDay_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbOneDay.Checked)
                gpbConsultationTime.Tag = "2";
        }

        private void rdbGeneral_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbGeneral.Checked)
                gpbConsultationTime.Tag = "3";
        }

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
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



        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            //			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
            //			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
            //			{
            //				this.m_txtCaseHistory.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
            //				this.m_txtConsultationOrder.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            //			}

            //暂在此设置默认签名
        }

        private void m_cmdDoctorSign_Click(object sender, System.EventArgs e)
        {
            if (m_txtConsulter.Tag != null)
            {
                string strDeptID = m_txtConsulter.Tag.ToString();

                new clsCommonUseTool(this).m_mthShowSpecialEmployeeSign(this, m_lsvEmployeeDoctor, clsCommonUseTool.enmEmployeeType.SpecialDeptDoctor, strDeptID, true);
            }
        }

        private void m_txtOtherHospital_TextChanged(object sender, EventArgs e)
        {
            m_txtOtherHospitalApply.Text = m_txtOtherHospital.m_strGetRightText();
        }

        private void m_mthSetApplyReadOnly()
        {
            m_txtConsulter.Enabled = false;
            m_lsvEmployeeDoctor.Enabled = false;
            m_txtMainDoctor.ReadOnly = true;
            m_txtRequestSign.ReadOnly = true;
        }

        /// <summary>
        /// 原记录是否没有科主任签名
        /// </summary>
        private bool m_blnIsNoMainDoctorBefore = true;
        protected override void m_mthAfterSuccessfulSave()
        {
            if (!string.IsNullOrEmpty(((clsConsultationRecordContent)m_objCurrentRecordContent).m_strApplyConsultationDeptID)
                && !string.IsNullOrEmpty(((clsConsultationRecordContent)m_objCurrentRecordContent).m_strMainDoctorID))
            {
                if (!m_blnIsNoMainDoctorBefore)
                    return;

                string strReturnSetting = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3009").ToString();
                clsAnalyseMessage objAnalyse = new clsAnalyseMessage();
                string strBroadCastingMessage = objAnalyse.m_strSetBroadCastingMessage(enmVisibleLevel.DEPT,
                    enmMessageItemType.Consultation, ((clsConsultationRecordContent)m_objCurrentRecordContent).m_strApplyConsultationDeptID, strReturnSetting);

                clsEMR_RemindMessageClient.Instance().m_mthSendRemindMessage(strBroadCastingMessage);
            }
        }

        /// <summary>
        /// 显示所有科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdShowAllDept_Click(object sender, EventArgs e)
        {
            if (m_dtbDept != null)
            {
                try
                {
                    m_lsvDeptList.BeginUpdate();
                    m_lsvDeptList.Items.Clear();
                    for (int i = 0; i < m_dtbDept.Rows.Count; i++)
                    {
                        ListViewItem lsi = new ListViewItem(new string[] { m_dtbDept.Rows[i]["code_vchr"].ToString(),
                        m_dtbDept.Rows[i]["DeptName"].ToString()});
                        lsi.Tag = m_dtbDept.Rows[i]["DEPTID"].ToString();
                        m_lsvDeptList.Items.Add(lsi);
                    }
                }
                finally
                {
                    m_lsvDeptList.EndUpdate();
                }
                m_pnlSearchWindow.Location = new System.Drawing.Point(m_txtApplyConsultationDept.Location.X,
                    m_txtApplyConsultationDept.Location.Y + m_txtApplyConsultationDept.Size.Height);
                m_pnlSearchWindow.Visible = true;
                m_txtSearchDept.Focus();
            }
        }

        private void m_txtApplyConsultationDept_Leave(object sender, EventArgs e)
        {
            m_pnlSearchWindow.Visible = false;
        }

        private void m_txtSearchDept_Leave(object sender, EventArgs e)
        {
            if (!m_lsvDeptList.Focused && !m_txtApplyConsultationDept.Focused)
            {
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_lsvDeptList_Leave(object sender, EventArgs e)
        {
            if (!m_txtSearchDept.Focused && !m_txtApplyConsultationDept.Focused)
            {
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_txtSearchDept_TextChanged(object sender, EventArgs e)
        {
            if (m_dtbDept != null)
            {
                DataView dtvDept = new DataView(m_dtbDept);
                string strF = "code_vchr like '" + m_txtSearchDept.Text.Trim()
                    + "%' or DeptName like '" + m_txtSearchDept.Text.Trim() + "%' or PYCODE_CHR like '" + m_txtSearchDept.Text.Trim() + "%'";
                dtvDept.RowFilter = strF;
                try
                {
                    m_lsvDeptList.BeginUpdate();
                    m_lsvDeptList.Items.Clear();
                    for (int i = 0; i < dtvDept.Count; i++)
                    {
                        ListViewItem lsi = new ListViewItem(new string[] { dtvDept[i]["code_vchr"].ToString(),
                        dtvDept[i]["DeptName"].ToString()});
                        lsi.Tag = dtvDept[i]["DEPTID"].ToString();
                        m_lsvDeptList.Items.Add(lsi);
                    }
                }
                finally
                {
                    m_lsvDeptList.EndUpdate();
                }
                m_txtSearchDept.Focus();
            }
        }

        private void m_lsvDeptList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_lsvDeptList_DoubleClick(null, null);
            }
        }

        private void m_lsvDeptList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvDeptList.SelectedItems.Count > 0)
            {
                m_txtApplyConsultationDept.Text = m_lsvDeptList.SelectedItems[0].SubItems[1].Text;
                m_txtConsulter.Text = m_lsvDeptList.SelectedItems[0].SubItems[1].Text;
                if (m_lsvDeptList.SelectedItems[0].SubItems[1].Text == "外院会诊")
                {
                    m_txtApplyConsultationDept.Tag = null;
                    m_txtConsulter.Tag = null;
                }
                else
                {
                    m_txtApplyConsultationDept.Tag = m_lsvDeptList.SelectedItems[0].Tag;
                    m_txtConsulter.Tag = m_lsvDeptList.SelectedItems[0].Tag;
                }
                m_txtSearchDept.Text = string.Empty;
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_txtApplyConsultationDept_TextChanged(object sender, EventArgs e)
        {
            m_txtConsulter.Text = m_txtApplyConsultationDept.Text;
            m_txtConsulter.Tag = m_txtApplyConsultationDept.Tag;
            if (m_txtApplyConsultationDept.Text == "外院会诊")
            {
                m_lblOtherHopital.Visible = true;
                m_lblOtherHopitalApply.Visible = true;
                m_txtOtherHospital.Visible = true;
                m_txtOtherHospitalApply.Visible = true;
                m_txtConsultationIdea.ReadOnly = false;
                m_dtpConsultationDate.Enabled = true;
            }
            else
            {
                m_lblOtherHopital.Visible = false;
                m_lblOtherHopitalApply.Visible = false;
                m_txtOtherHospital.Visible = false;
                m_txtOtherHospitalApply.Visible = false;
                m_txtOtherHospital.m_mthClearText();
                m_txtOtherHospitalApply.Clear();
                m_txtConsultationIdea.ReadOnly = true;
                m_dtpConsultationDate.Enabled = false;
            }
        }

        private void m_txtSearchDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && m_lsvDeptList.Items.Count > 0)
            {
                m_lsvDeptList.Focus();
                m_lsvDeptList.Items[0].Selected = true;
            }
        }


        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsConsultationRecordContent();

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
                clsConsultationRecordContent p_objContent = (clsConsultationRecordContent)m_objContent;
                this.m_txtCaseHistory.Text = p_objContent.m_strCaseHistory;
                this.m_txtConsultationOrder.Text = p_objContent.m_strConsultationOrder;
                this.m_txtAsker.Text = p_objContent.m_strAskConsultationDeptName;
                this.m_txtMainDoctor.Text = p_objContent.m_strMainDoctorName;
                ////this.m_txtRequestSign.Text = p_objContent.m_strRequestDoctorNameArr;
                //string strMainDoctor="";
                //string[] strMainDoctorArr=p_objContent.m_strRequestDoctorNameArr;
                //foreach (string i in strMainDoctorArr)
                //{
                //    strMainDoctor = strMainDoctor + " " + i.ToString();
                //}
                //this.m_txtRequestSign.Text=strMainDoctor;

                m_objSign.m_mthBindEmployeeSign(m_cmdMainDoctor, m_txtMainDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
                m_objSign.m_mthBindEmployeeSign(m_cmdRequestSign, m_txtRequestSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

                if (p_objContent.m_intConsultationTime == 1)
                {
                    this.rdbRightNow.Checked = true;
                }
                else if (p_objContent.m_intConsultationTime == 2)
                {
                    this.rdbOneDay.Checked = true;
                }
                else if (p_objContent.m_intConsultationTime == 3)
                {
                    this.rdbGeneral.Checked = true;
                }
                this.m_txtConsultationIdea.Text = p_objContent.m_strConsultationIdea;
                this.m_txtConsulter.Text = p_objContent.m_strConsultationDeptName;
                this.m_dtpConsultationDate.Text = p_objContent.m_dtmConsultationDate.ToString("yyyy-MM-dd hh:mm:ss");

                
                ////this.m_lsvEmployeeDoctor.Items.AddRange(p_objContent.m_strConsultationDoctorNameArr);
                //this.m_lsvEmployeeDoctor.Items.Clear();
                //string[] strEmployeeDoctorArr = p_objContent.m_strConsultationDoctorNameArr;
                //ListViewItem lviEmployeeDoctor=null;
                //foreach (string j in strEmployeeDoctorArr)
                //{
                //    lviEmployeeDoctor =new ListViewItem();
                //    lviEmployeeDoctor.Text=j.ToString();
                //    this.m_lsvEmployeeDoctor.Items.Add(lviEmployeeDoctor);
                //}


                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsConsultationPrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_Consultation objPrintInfo = new clsPrintInfo_Consultation();


                ////objPrintInfo.m_strInPatentID = m_objBaseCurrentPatient.m_StrInpatientId;
                ////objPrintInfo.m_strPatientName = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
                ////objPrintInfo.m_strSex = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrSex;
                ////objPrintInfo.m_strAge = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                ////objPrintInfo.m_strBedName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
                ////objPrintInfo.m_strDeptName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName;
                ////objPrintInfo.m_strAreaName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName;
                ////objPrintInfo.m_dtmInPatientDate = m_objBaseCurrentPatient.m_DtmInpatientDate;
                ////objPrintInfo.m_dtmOpenDate = m_objBaseCurrentPatient.m_DtmOpenDate;
                //////m_objBaseCurrentPatient


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


                ////objPrintInfo.m_strHISInPatientID = m_objBaseCurrentPatient.m_StrHISInPatientID;
                //objPrintInfo.m_dtmHISInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedHISInDate;
                clsTrackRecordContent p_objContent = new clsConsultationRecordContent();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsConsultationRecordContent objContent = (clsConsultationRecordContent)p_objContent;
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
            new clsConsultationDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做
    }
}

