using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using com.digitalwave.controls;
using com.digitalwave.common.ICD10.Tool;
using com.digitalwave.Emr.Signature_gui;
using System.Text.RegularExpressions;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    /// 普通住院病历
    /// </summary>
	public class frmInPatientCaseHistory_F2 : iCare.frmBaseCaseHistory
	{
		#region FormDefines
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRepresentor;
		private System.Windows.Forms.Label lblRepresentor;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCredibility;
		private System.Windows.Forms.Label lblCredibility;
		private System.Windows.Forms.ToolTip m_tip;
		protected System.Windows.Forms.Label lblPrimaryDiagnose;
		private System.Windows.Forms.PictureBox m_picDiagnose;
		protected System.Windows.Forms.Label lblSummary;
		private System.Windows.Forms.PictureBox m_picSummary;
		protected System.Windows.Forms.Label lblMedical;
		protected System.Windows.Forms.Label lblFamilyHistory;
		private System.Windows.Forms.PictureBox m_picFamilyHistory;
		protected System.Windows.Forms.Label lblCatameniaHistory;
		private System.Windows.Forms.PictureBox m_picCatameniaHistory;
		protected System.Windows.Forms.Label lblMarriageHistory;
		private System.Windows.Forms.PictureBox m_picMarriageHistory;
		protected System.Windows.Forms.Label lblOwnHistory;
		private System.Windows.Forms.PictureBox m_picOwnHistory;
		protected System.Windows.Forms.Label lblBeforetimeStatus;
		private System.Windows.Forms.PictureBox m_picBeforetimeStatus;
		protected System.Windows.Forms.Label lblMainDescription;
		private System.Windows.Forms.PictureBox m_picMainDescription;
		protected System.Windows.Forms.Label lblProfessionalCheck;
		private System.Windows.Forms.PictureBox m_picProfessionalCheck;
		private System.Windows.Forms.PictureBox m_picCurrentStatus;
		protected System.Windows.Forms.Label lblCurrentStatus;
        protected System.Windows.Forms.Label m_lblBloodPressureUnit;
        protected com.digitalwave.controls.ctlRichTextBox m_txtSummary;
        private System.ComponentModel.IContainer components = null;
        private clsEmployeeSignTool m_objSignTool;
        private System.Windows.Forms.Panel m_pnlContent;
		private clsCommonUseToolCollection m_objCUTC;
		private string m_strMedicalExam_ID = "";
		private string m_strCurrentOpenDate = "";

		private clsThreeMeasureShareDomain	m_objShareDomain = new clsThreeMeasureShareDomain();
        private ExternalControlsLib.XPButton m_cmdAssistantDiagnose;
        private System.Windows.Forms.ImageList imageList1;
        private TextBox txtSign;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private LinkLabel m_lklMain;
        protected ctlRichTextBox m_txtCurrentStatus;
        private LinkLabel m_lklOwnHistory;
        protected ctlRichTextBox m_txtBeforetimeStatus;
        private LinkLabel m_lklBeforetimeStatus;
        protected ctlRichTextBox m_txtMainDescription;
        private LinkLabel m_lklCurrentStatus;
        protected ctlRichTextBox m_txtOwnHistory;
        private TabPage tabPage10;
        private CheckBox m_chkCatamenia;
        private LinkLabel m_lklMarriageHistory;
        protected ctlRichTextBox m_txtFamilyHistory;
        private LinkLabel m_lklFamilyHistory;
        protected ctlRichTextBox m_txtMarriageHistory;
        private GroupBox m_grbCatamenia;
        private Panel panel1;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpLastCatameniaTime;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAmeniaAge;
        private RadioButton m_rdbLastCatameniaTime;
        private RadioButton m_rdbAmeniaAge;
        private Label label13;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFirstCatamenia;
        private Label label14;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaLastTime;
        private Label label15;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaCycle;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaCase;
        protected ctlRichTextBox m_txtCatameniaHistory;
        private TabPage tabPage2;
        protected ctlRichTextBox m_txtProfessionalCheck;
        private LinkLabel m_lklProfessionalCheck;
        private LinkLabel m_lklMedical;
        protected Label lblPulse;
        protected ctlRichTextBox m_txtMedical;
        private Label label17;
        private Label label18;
        protected ctlRichTextBox m_txtBreath;
        private Label label19;
        protected Label lblBreath;
        protected ctlRichTextBox m_txtPulse;
        protected Label lblDia;
        protected ctlRichTextBox m_txtTemperature;
        protected Label lblTemperature;
        private TabPage tabPage11;
        private LinkLabel m_lklLabCheck;
        private Panel pnlFocus;
        protected ctlRichTextBox m_txtLabCheck;
        private TabPage tabPage12;
        private TextBox m_txtPrimaryDoc;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpPrimaryDoc;
        private ExternalControlsLib.XPButton m_cmdPrimaryDoc;
        private Label label3;
        protected ctlRichTextBox m_txtModifydiagnose;
        private TextBox m_txtDirectorDoc;
        private TextBox m_txtModifyDiagnoseDoctor;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpModifyDiagnoseDate;
        private LinkLabel m_lklModifydiagnose;
        private ExternalControlsLib.XPButton m_cmdModifyDiagnoseDoctor;
        private Label label2;
        private ExternalControlsLib.XPButton m_cmdDirectorDoc;
        protected ctlRichTextBox m_txtPrimaryDiagnose;
        private LinkLabel m_lklPrimaryDiagnose;
        private TabPage tabPage3;
        private com.digitalwave.Utility.Controls.ctlPaintContainer ctlPaintContainer1;
        private Label m_lbDiagnoseDate;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpDiagnosedoc;
        private TextBox m_txtDiagnosedoc;
        private ExternalControlsLib.XPButton m_cmdDiagnose;
        protected ctlRichTextBox m_txtDiagnose;
        private LinkLabel m_lbDiagnose;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBloodPressure;
        protected ctlRichTextBox m_txtWeight;
        protected Label label5;
        protected Label label4;
        private ListView m_lsvLISContent;
        private ColumnHeader columnHeader1;
        private Panel panel2;
        private TextBox m_txtLISContent;
        private Button m_cmdUseSelectedContent;
        private Button m_cmdUseAllContent;
        private Button m_cmdSeeCheckResult;
        private BackgroundWorker m_bgwGetLIS;
        private TabPage tabPage4;
        protected ctlRichTextBox m_cltbuchong;
        private TextBox m_txtBuchongDoctor;
        private ExternalControlsLib.XPButton m_cmdBuchongDoctor;
        private LinkLabel linkLabel1;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpBuchongDate;
        private Label label6;
        protected ctlRichTextBox m_txtAddDiagnose;
        private TextBox m_txtChargeDoc;
        private TextBox m_txtAddDiagnoseDoctor;
        private ExternalControlsLib.XPButton m_cmdAddDiagnoseDoctor;
        private LinkLabel m_lklAddDiagnose;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpAddDiagnoseDate;
        private Label label1;
        private ExternalControlsLib.XPButton m_cmdChargeDoc;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;



		#endregion

        public frmInPatientCaseHistory_F2()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            if (clsEMRLogin.m_StrCurrentHospitalNO != "450101001")//不是南宁
            {
                this.m_txtModifydiagnose.m_ClrOldPartInsertText = Color.Black;
                this.m_txtModifydiagnose.ForeColor = Color.Black;
                this.m_txtAddDiagnose.m_ClrOldPartInsertText = Color.Black;
                this.m_txtAddDiagnose.ForeColor = Color.Black;
            }
			m_mthInit();
			
			m_blnCanDoctorTextChanged = true;

			m_mthSetRichTextBoxAttribInControl(this);
			m_mthUnEnableRichTextBox();
			m_txtPulse.LostFocus += new EventHandler(m_mthSyncPluse);

            #region 新通用绑定签名
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse,员工ID);
            //记录者签名
            m_objSign.m_mthBindEmployeeSign(m_cmdCreateID, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //修正医师
            m_objSign.m_mthBindEmployeeSign(m_cmdModifyDiagnoseDoctor, m_txtModifyDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //最后医师
            m_objSign.m_mthBindEmployeeSign(m_cmdAddDiagnoseDoctor, m_txtAddDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主任医师
            //m_objSign.m_mthBindEmployeeSign(m_cmdDirectorDoc, m_txtDirectorDoc,1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            ////主治医师
            //m_objSign.m_mthBindEmployeeSign(m_cmdChargeDoc, m_txtChargeDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //初步诊断医师
            m_objSign.m_mthBindEmployeeSign(m_cmdPrimaryDoc, m_txtPrimaryDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //诊断
            m_objSign.m_mthBindEmployeeSign(m_cmdDiagnose, m_txtDiagnosedoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //补充医师
            m_objSign.m_mthBindEmployeeSign(m_cmdBuchongDoctor, m_txtBuchongDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            
            #endregion
        }
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
				m_objShareDomain = null;
			}
			base.Dispose( disposing );
		}

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(txtSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
				return "";
			}
		}
        //private frmPrintPreviewDialogPF ppdPrintPreview;
		#endregion 属性

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInPatientCaseHistory_F2));
            this.m_cboRepresentor = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblRepresentor = new System.Windows.Forms.Label();
            this.m_cboCredibility = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblCredibility = new System.Windows.Forms.Label();
            this.m_tip = new System.Windows.Forms.ToolTip(this.components);
            this.lblPrimaryDiagnose = new System.Windows.Forms.Label();
            this.m_picDiagnose = new System.Windows.Forms.PictureBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.m_picSummary = new System.Windows.Forms.PictureBox();
            this.lblMedical = new System.Windows.Forms.Label();
            this.lblFamilyHistory = new System.Windows.Forms.Label();
            this.m_picFamilyHistory = new System.Windows.Forms.PictureBox();
            this.lblCatameniaHistory = new System.Windows.Forms.Label();
            this.m_picCatameniaHistory = new System.Windows.Forms.PictureBox();
            this.lblMarriageHistory = new System.Windows.Forms.Label();
            this.m_picMarriageHistory = new System.Windows.Forms.PictureBox();
            this.lblOwnHistory = new System.Windows.Forms.Label();
            this.m_picOwnHistory = new System.Windows.Forms.PictureBox();
            this.lblBeforetimeStatus = new System.Windows.Forms.Label();
            this.m_picBeforetimeStatus = new System.Windows.Forms.PictureBox();
            this.lblMainDescription = new System.Windows.Forms.Label();
            this.m_picMainDescription = new System.Windows.Forms.PictureBox();
            this.lblProfessionalCheck = new System.Windows.Forms.Label();
            this.m_picProfessionalCheck = new System.Windows.Forms.PictureBox();
            this.m_picCurrentStatus = new System.Windows.Forms.PictureBox();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.m_lblBloodPressureUnit = new System.Windows.Forms.Label();
            this.m_pnlContent = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lklMain = new System.Windows.Forms.LinkLabel();
            this.m_txtCurrentStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklOwnHistory = new System.Windows.Forms.LinkLabel();
            this.m_txtBeforetimeStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklBeforetimeStatus = new System.Windows.Forms.LinkLabel();
            this.m_txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklCurrentStatus = new System.Windows.Forms.LinkLabel();
            this.m_txtOwnHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.m_chkCatamenia = new System.Windows.Forms.CheckBox();
            this.m_lklMarriageHistory = new System.Windows.Forms.LinkLabel();
            this.m_txtFamilyHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklFamilyHistory = new System.Windows.Forms.LinkLabel();
            this.m_txtMarriageHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_grbCatamenia = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dtpLastCatameniaTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cboAmeniaAge = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_rdbLastCatameniaTime = new System.Windows.Forms.RadioButton();
            this.m_rdbAmeniaAge = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.m_cboFirstCatamenia = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cboCatameniaLastTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_cboCatameniaCycle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboCatameniaCase = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtCatameniaHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_txtProfessionalCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklProfessionalCheck = new System.Windows.Forms.LinkLabel();
            this.m_lklMedical = new System.Windows.Forms.LinkLabel();
            this.lblPulse = new System.Windows.Forms.Label();
            this.m_txtMedical = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtWeight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblBreath = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDia = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.m_cboBloodPressure = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmdSeeCheckResult = new System.Windows.Forms.Button();
            this.m_cmdUseSelectedContent = new System.Windows.Forms.Button();
            this.m_cmdUseAllContent = new System.Windows.Forms.Button();
            this.m_txtLISContent = new System.Windows.Forms.TextBox();
            this.m_lsvLISContent = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_lklLabCheck = new System.Windows.Forms.LinkLabel();
            this.m_txtLabCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.pnlFocus = new System.Windows.Forms.Panel();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.m_lbDiagnose = new System.Windows.Forms.LinkLabel();
            this.m_lbDiagnoseDate = new System.Windows.Forms.Label();
            this.m_dtpDiagnosedoc = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtDiagnosedoc = new System.Windows.Forms.TextBox();
            this.m_cmdDiagnose = new ExternalControlsLib.XPButton();
            this.m_txtDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPrimaryDoc = new System.Windows.Forms.TextBox();
            this.m_dtpPrimaryDoc = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdPrimaryDoc = new ExternalControlsLib.XPButton();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtModifydiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDirectorDoc = new System.Windows.Forms.TextBox();
            this.m_txtModifyDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.m_dtpModifyDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lklModifydiagnose = new System.Windows.Forms.LinkLabel();
            this.m_cmdModifyDiagnoseDoctor = new ExternalControlsLib.XPButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdDirectorDoc = new ExternalControlsLib.XPButton();
            this.m_txtPrimaryDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklPrimaryDiagnose = new System.Windows.Forms.LinkLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_cltbuchong = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBuchongDoctor = new System.Windows.Forms.TextBox();
            this.m_cmdBuchongDoctor = new ExternalControlsLib.XPButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_dtpBuchongDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtAddDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtChargeDoc = new System.Windows.Forms.TextBox();
            this.m_txtAddDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.m_cmdAddDiagnoseDoctor = new ExternalControlsLib.XPButton();
            this.m_lklAddDiagnose = new System.Windows.Forms.LinkLabel();
            this.m_dtpAddDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdChargeDoc = new ExternalControlsLib.XPButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctlPaintContainer1 = new com.digitalwave.Utility.Controls.ctlPaintContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_txtSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdAssistantDiagnose = new ExternalControlsLib.XPButton();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_bgwGetLIS = new System.ComponentModel.BackgroundWorker();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picDiagnose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFamilyHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCatameniaHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarriageHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picOwnHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBeforetimeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMainDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picProfessionalCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCurrentStatus)).BeginInit();
            this.m_pnlContent.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.m_grbCatamenia.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Location = new System.Drawing.Point(629, 116);
            this.m_cmdCreateID.Size = new System.Drawing.Size(76, 24);
            this.m_cmdCreateID.TabIndex = 70;
            // 
            // trvTime
            // 
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(262, 172);
            this.trvTime.Size = new System.Drawing.Size(10, 10);
            this.trvTime.TabIndex = 30;
            this.trvTime.Visible = false;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(68, 116);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(215, 22);
            this.m_dtpCreateDate.TabIndex = 40;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(3, 121);
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Location = new System.Drawing.Point(206, 168);
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Location = new System.Drawing.Point(224, 179);
            this.m_lblNativePlace.Size = new System.Drawing.Size(24, 10);
            this.m_lblNativePlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(254, 180);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(240, 183);
            this.m_lblOccupation.Size = new System.Drawing.Size(10, 10);
            this.m_lblOccupation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(240, 183);
            this.m_lblMarriaged.Size = new System.Drawing.Size(10, 10);
            this.m_lblMarriaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(236, 173);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblCreateUserName
            // 
            this.m_lblCreateUserName.Location = new System.Drawing.Point(486, -7);
            this.m_lblCreateUserName.Size = new System.Drawing.Size(16, 3);
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(236, 187);
            this.m_lblLinkMan.Size = new System.Drawing.Size(14, 10);
            this.m_lblLinkMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(224, 163);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(214, 182);
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(214, 184);
            this.m_lblAddress.Size = new System.Drawing.Size(16, 10);
            this.m_lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblAddress.Visible = false;
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(251, 163);
            this.lblNation.Visible = false;
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(262, 172);
            this.m_lblNation.Size = new System.Drawing.Size(69, 10);
            this.m_lblNation.Visible = false;
            // 
            // ppdPrintPreview
            // 
            this.ppdPrintPreview.ClientSize = new System.Drawing.Size(1024, 721);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(236, 175);
            this.lblSex.Size = new System.Drawing.Size(44, 10);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(251, 176);
            this.lblAge.Size = new System.Drawing.Size(56, 10);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(251, 175);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(237, 168);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(254, 164);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(240, 168);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(240, 169);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(231, 163);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(262, 186);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(16, 10);
            this.m_lsvInPatientID.TabIndex = 5000;
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(239, 164);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.TabIndex = 25;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(217, 168);
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.TabIndex = 20;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(254, 168);
            this.m_txtBedNO.Size = new System.Drawing.Size(18, 23);
            this.m_txtBedNO.TabIndex = 10;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(270, 181);
            this.m_cboArea.Size = new System.Drawing.Size(19, 23);
            this.m_cboArea.TabIndex = 700;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(279, 179);
            this.m_lsvPatientName.Size = new System.Drawing.Size(10, 10);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(284, 185);
            this.m_lsvBedNO.Size = new System.Drawing.Size(12, 11);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(254, 178);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.TabIndex = 600;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(214, 155);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(267, 170);
            this.m_cmdNext.Size = new System.Drawing.Size(22, 10);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(210, 183);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 10);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(194, 0);
            this.m_lblForTitle.Size = new System.Drawing.Size(0, 0);
            this.m_lblForTitle.Text = "住  院  病  历";
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(695, 165);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(718, 83);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 27);
            this.m_tipMain.SetToolTip(this.m_cmdModifyPatientInfo, "点击查看和修改患者详细信息");
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cmdAssistantDiagnose);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 1);
            this.m_pnlNewBase.Size = new System.Drawing.Size(797, 112);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdAssistantDiagnose, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowOffice = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationPhone = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(795, 81);
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.BackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.BorderColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRepresentor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRepresentor.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRepresentor.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.ForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRepresentor.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRepresentor.Location = new System.Drawing.Point(358, 117);
            this.m_cboRepresentor.m_BlnEnableItemEventMenu = true;
            this.m_cboRepresentor.MaxLength = 32767;
            this.m_cboRepresentor.Name = "m_cboRepresentor";
            this.m_cboRepresentor.SelectedIndex = -1;
            this.m_cboRepresentor.SelectedItem = null;
            this.m_cboRepresentor.SelectionStart = 0;
            this.m_cboRepresentor.Size = new System.Drawing.Size(99, 23);
            this.m_cboRepresentor.TabIndex = 50;
            this.m_cboRepresentor.TextBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblRepresentor
            // 
            this.lblRepresentor.AutoSize = true;
            this.lblRepresentor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepresentor.Location = new System.Drawing.Point(301, 121);
            this.lblRepresentor.Name = "lblRepresentor";
            this.lblRepresentor.Size = new System.Drawing.Size(56, 14);
            this.lblRepresentor.TabIndex = 517;
            this.lblRepresentor.Text = "陈述者:";
            // 
            // m_cboCredibility
            // 
            this.m_cboCredibility.BackColor = System.Drawing.Color.White;
            this.m_cboCredibility.BorderColor = System.Drawing.Color.Black;
            this.m_cboCredibility.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCredibility.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCredibility.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCredibility.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCredibility.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCredibility.ForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.ListBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCredibility.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCredibility.Location = new System.Drawing.Point(526, 117);
            this.m_cboCredibility.m_BlnEnableItemEventMenu = true;
            this.m_cboCredibility.MaxLength = 32767;
            this.m_cboCredibility.Name = "m_cboCredibility";
            this.m_cboCredibility.SelectedIndex = -1;
            this.m_cboCredibility.SelectedItem = null;
            this.m_cboCredibility.SelectionStart = 0;
            this.m_cboCredibility.Size = new System.Drawing.Size(97, 23);
            this.m_cboCredibility.TabIndex = 60;
            this.m_cboCredibility.TextBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblCredibility
            // 
            this.lblCredibility.AutoSize = true;
            this.lblCredibility.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCredibility.Location = new System.Drawing.Point(465, 121);
            this.lblCredibility.Name = "lblCredibility";
            this.lblCredibility.Size = new System.Drawing.Size(56, 14);
            this.lblCredibility.TabIndex = 514;
            this.lblCredibility.Text = "可靠度:";
            // 
            // lblPrimaryDiagnose
            // 
            this.lblPrimaryDiagnose.Location = new System.Drawing.Point(16, 2312);
            this.lblPrimaryDiagnose.Name = "lblPrimaryDiagnose";
            this.lblPrimaryDiagnose.Size = new System.Drawing.Size(80, 19);
            this.lblPrimaryDiagnose.TabIndex = 0;
            // 
            // m_picDiagnose
            // 
            this.m_picDiagnose.Location = new System.Drawing.Point(96, 2316);
            this.m_picDiagnose.Name = "m_picDiagnose";
            this.m_picDiagnose.Size = new System.Drawing.Size(16, 16);
            this.m_picDiagnose.TabIndex = 0;
            this.m_picDiagnose.TabStop = false;
            // 
            // lblSummary
            // 
            this.lblSummary.Location = new System.Drawing.Point(28, 2120);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(55, 19);
            this.lblSummary.TabIndex = 0;
            // 
            // m_picSummary
            // 
            this.m_picSummary.Location = new System.Drawing.Point(92, 2120);
            this.m_picSummary.Name = "m_picSummary";
            this.m_picSummary.Size = new System.Drawing.Size(16, 16);
            this.m_picSummary.TabIndex = 0;
            this.m_picSummary.TabStop = false;
            // 
            // lblMedical
            // 
            this.lblMedical.Location = new System.Drawing.Point(16, 1148);
            this.lblMedical.Name = "lblMedical";
            this.lblMedical.Size = new System.Drawing.Size(80, 19);
            this.lblMedical.TabIndex = 0;
            // 
            // lblFamilyHistory
            // 
            this.lblFamilyHistory.Location = new System.Drawing.Point(16, 880);
            this.lblFamilyHistory.Name = "lblFamilyHistory";
            this.lblFamilyHistory.Size = new System.Drawing.Size(63, 19);
            this.lblFamilyHistory.TabIndex = 0;
            // 
            // m_picFamilyHistory
            // 
            this.m_picFamilyHistory.Location = new System.Drawing.Point(80, 880);
            this.m_picFamilyHistory.Name = "m_picFamilyHistory";
            this.m_picFamilyHistory.Size = new System.Drawing.Size(16, 16);
            this.m_picFamilyHistory.TabIndex = 0;
            this.m_picFamilyHistory.TabStop = false;
            // 
            // lblCatameniaHistory
            // 
            this.lblCatameniaHistory.Location = new System.Drawing.Point(12, 824);
            this.lblCatameniaHistory.Name = "lblCatameniaHistory";
            this.lblCatameniaHistory.Size = new System.Drawing.Size(63, 19);
            this.lblCatameniaHistory.TabIndex = 0;
            // 
            // m_picCatameniaHistory
            // 
            this.m_picCatameniaHistory.Location = new System.Drawing.Point(76, 824);
            this.m_picCatameniaHistory.Name = "m_picCatameniaHistory";
            this.m_picCatameniaHistory.Size = new System.Drawing.Size(16, 16);
            this.m_picCatameniaHistory.TabIndex = 0;
            this.m_picCatameniaHistory.TabStop = false;
            // 
            // lblMarriageHistory
            // 
            this.lblMarriageHistory.Location = new System.Drawing.Point(16, 768);
            this.lblMarriageHistory.Name = "lblMarriageHistory";
            this.lblMarriageHistory.Size = new System.Drawing.Size(63, 19);
            this.lblMarriageHistory.TabIndex = 0;
            // 
            // m_picMarriageHistory
            // 
            this.m_picMarriageHistory.Location = new System.Drawing.Point(80, 768);
            this.m_picMarriageHistory.Name = "m_picMarriageHistory";
            this.m_picMarriageHistory.Size = new System.Drawing.Size(16, 16);
            this.m_picMarriageHistory.TabIndex = 0;
            this.m_picMarriageHistory.TabStop = false;
            // 
            // lblOwnHistory
            // 
            this.lblOwnHistory.Location = new System.Drawing.Point(16, 668);
            this.lblOwnHistory.Name = "lblOwnHistory";
            this.lblOwnHistory.Size = new System.Drawing.Size(63, 19);
            this.lblOwnHistory.TabIndex = 0;
            // 
            // m_picOwnHistory
            // 
            this.m_picOwnHistory.Location = new System.Drawing.Point(80, 668);
            this.m_picOwnHistory.Name = "m_picOwnHistory";
            this.m_picOwnHistory.Size = new System.Drawing.Size(16, 16);
            this.m_picOwnHistory.TabIndex = 0;
            this.m_picOwnHistory.TabStop = false;
            // 
            // lblBeforetimeStatus
            // 
            this.lblBeforetimeStatus.Location = new System.Drawing.Point(16, 524);
            this.lblBeforetimeStatus.Name = "lblBeforetimeStatus";
            this.lblBeforetimeStatus.Size = new System.Drawing.Size(63, 19);
            this.lblBeforetimeStatus.TabIndex = 0;
            // 
            // m_picBeforetimeStatus
            // 
            this.m_picBeforetimeStatus.Location = new System.Drawing.Point(80, 714);
            this.m_picBeforetimeStatus.Name = "m_picBeforetimeStatus";
            this.m_picBeforetimeStatus.Size = new System.Drawing.Size(16, 16);
            this.m_picBeforetimeStatus.TabIndex = 0;
            this.m_picBeforetimeStatus.TabStop = false;
            // 
            // lblMainDescription
            // 
            this.lblMainDescription.Location = new System.Drawing.Point(0, 0);
            this.lblMainDescription.Name = "lblMainDescription";
            this.lblMainDescription.Size = new System.Drawing.Size(100, 23);
            this.lblMainDescription.TabIndex = 0;
            // 
            // m_picMainDescription
            // 
            this.m_picMainDescription.Location = new System.Drawing.Point(72, 260);
            this.m_picMainDescription.Name = "m_picMainDescription";
            this.m_picMainDescription.Size = new System.Drawing.Size(100, 50);
            this.m_picMainDescription.TabIndex = 0;
            this.m_picMainDescription.TabStop = false;
            // 
            // lblProfessionalCheck
            // 
            this.lblProfessionalCheck.Location = new System.Drawing.Point(16, 1548);
            this.lblProfessionalCheck.Name = "lblProfessionalCheck";
            this.lblProfessionalCheck.Size = new System.Drawing.Size(80, 19);
            this.lblProfessionalCheck.TabIndex = 0;
            // 
            // m_picProfessionalCheck
            // 
            this.m_picProfessionalCheck.Location = new System.Drawing.Point(96, 1552);
            this.m_picProfessionalCheck.Name = "m_picProfessionalCheck";
            this.m_picProfessionalCheck.Size = new System.Drawing.Size(16, 16);
            this.m_picProfessionalCheck.TabIndex = 0;
            this.m_picProfessionalCheck.TabStop = false;
            // 
            // m_picCurrentStatus
            // 
            this.m_picCurrentStatus.Location = new System.Drawing.Point(80, 372);
            this.m_picCurrentStatus.Name = "m_picCurrentStatus";
            this.m_picCurrentStatus.Size = new System.Drawing.Size(16, 16);
            this.m_picCurrentStatus.TabIndex = 0;
            this.m_picCurrentStatus.TabStop = false;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Location = new System.Drawing.Point(16, 372);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentStatus.TabIndex = 0;
            // 
            // m_lblBloodPressureUnit
            // 
            this.m_lblBloodPressureUnit.Location = new System.Drawing.Point(928, 680);
            this.m_lblBloodPressureUnit.Name = "m_lblBloodPressureUnit";
            this.m_lblBloodPressureUnit.Size = new System.Drawing.Size(39, 19);
            this.m_lblBloodPressureUnit.TabIndex = 0;
            // 
            // m_pnlContent
            // 
            this.m_pnlContent.AutoScroll = true;
            this.m_pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlContent.Controls.Add(this.tabControl1);
            this.m_pnlContent.Location = new System.Drawing.Point(5, 144);
            this.m_pnlContent.Name = "m_pnlContent";
            this.m_pnlContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_pnlContent.Size = new System.Drawing.Size(796, 446);
            this.m_pnlContent.TabIndex = 500;
            this.m_pnlContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 444);
            this.tabControl1.TabIndex = 10000104;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.m_lklMain);
            this.tabPage1.Controls.Add(this.m_txtCurrentStatus);
            this.tabPage1.Controls.Add(this.m_lklOwnHistory);
            this.tabPage1.Controls.Add(this.m_txtBeforetimeStatus);
            this.tabPage1.Controls.Add(this.m_lklBeforetimeStatus);
            this.tabPage1.Controls.Add(this.m_txtMainDescription);
            this.tabPage1.Controls.Add(this.m_lklCurrentStatus);
            this.tabPage1.Controls.Add(this.m_txtOwnHistory);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(786, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "病史一";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_lklMain
            // 
            this.m_lklMain.AutoSize = true;
            this.m_lklMain.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMain.Location = new System.Drawing.Point(3, 5);
            this.m_lklMain.Name = "m_lklMain";
            this.m_lklMain.Size = new System.Drawing.Size(56, 14);
            this.m_lklMain.TabIndex = 576;
            this.m_lklMain.TabStop = true;
            this.m_lklMain.Text = "主  诉:";
            this.m_lklMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtCurrentStatus
            // 
            this.m_txtCurrentStatus.AccessibleDescription = "现病史";
            this.m_txtCurrentStatus.BackColor = System.Drawing.Color.White;
            this.m_txtCurrentStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurrentStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCurrentStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurrentStatus.Location = new System.Drawing.Point(63, 33);
            this.m_txtCurrentStatus.m_BlnIgnoreUserInfo = false;
            this.m_txtCurrentStatus.m_BlnPartControl = false;
            this.m_txtCurrentStatus.m_BlnReadOnly = false;
            this.m_txtCurrentStatus.m_BlnUnderLineDST = false;
            this.m_txtCurrentStatus.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCurrentStatus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCurrentStatus.m_IntCanModifyTime = 6;
            this.m_txtCurrentStatus.m_IntPartControlLength = 0;
            this.m_txtCurrentStatus.m_IntPartControlStartIndex = 0;
            this.m_txtCurrentStatus.m_StrUserID = "";
            this.m_txtCurrentStatus.m_StrUserName = "";
            this.m_txtCurrentStatus.Name = "m_txtCurrentStatus";
            this.m_txtCurrentStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCurrentStatus.Size = new System.Drawing.Size(710, 177);
            this.m_txtCurrentStatus.TabIndex = 100;
            this.m_txtCurrentStatus.Tag = "1";
            this.m_txtCurrentStatus.Text = "";
            // 
            // m_lklOwnHistory
            // 
            this.m_lklOwnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklOwnHistory.AutoSize = true;
            this.m_lklOwnHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklOwnHistory.Location = new System.Drawing.Point(3, 317);
            this.m_lklOwnHistory.Name = "m_lklOwnHistory";
            this.m_lklOwnHistory.Size = new System.Drawing.Size(56, 14);
            this.m_lklOwnHistory.TabIndex = 576;
            this.m_lklOwnHistory.TabStop = true;
            this.m_lklOwnHistory.Text = "个人史:";
            this.m_lklOwnHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtBeforetimeStatus
            // 
            this.m_txtBeforetimeStatus.AccessibleDescription = "既往史";
            this.m_txtBeforetimeStatus.BackColor = System.Drawing.Color.White;
            this.m_txtBeforetimeStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeforetimeStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBeforetimeStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBeforetimeStatus.Location = new System.Drawing.Point(63, 218);
            this.m_txtBeforetimeStatus.m_BlnIgnoreUserInfo = false;
            this.m_txtBeforetimeStatus.m_BlnPartControl = false;
            this.m_txtBeforetimeStatus.m_BlnReadOnly = false;
            this.m_txtBeforetimeStatus.m_BlnUnderLineDST = false;
            this.m_txtBeforetimeStatus.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBeforetimeStatus.m_IntCanModifyTime = 6;
            this.m_txtBeforetimeStatus.m_IntPartControlLength = 0;
            this.m_txtBeforetimeStatus.m_IntPartControlStartIndex = 0;
            this.m_txtBeforetimeStatus.m_StrUserID = "";
            this.m_txtBeforetimeStatus.m_StrUserName = "";
            this.m_txtBeforetimeStatus.Name = "m_txtBeforetimeStatus";
            this.m_txtBeforetimeStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBeforetimeStatus.Size = new System.Drawing.Size(710, 88);
            this.m_txtBeforetimeStatus.TabIndex = 110;
            this.m_txtBeforetimeStatus.Tag = "2";
            this.m_txtBeforetimeStatus.Text = "";
            // 
            // m_lklBeforetimeStatus
            // 
            this.m_lklBeforetimeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklBeforetimeStatus.AutoSize = true;
            this.m_lklBeforetimeStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklBeforetimeStatus.Location = new System.Drawing.Point(3, 218);
            this.m_lklBeforetimeStatus.Name = "m_lklBeforetimeStatus";
            this.m_lklBeforetimeStatus.Size = new System.Drawing.Size(56, 14);
            this.m_lklBeforetimeStatus.TabIndex = 576;
            this.m_lklBeforetimeStatus.TabStop = true;
            this.m_lklBeforetimeStatus.Text = "既往史:";
            this.m_lklBeforetimeStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtMainDescription
            // 
            this.m_txtMainDescription.AccessibleDescription = "主诉";
            this.m_txtMainDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMainDescription.AutoSize = true;
            this.m_txtMainDescription.BackColor = System.Drawing.Color.White;
            this.m_txtMainDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDescription.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMainDescription.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtMainDescription.Location = new System.Drawing.Point(63, 3);
            this.m_txtMainDescription.m_BlnIgnoreUserInfo = false;
            this.m_txtMainDescription.m_BlnPartControl = false;
            this.m_txtMainDescription.m_BlnReadOnly = false;
            this.m_txtMainDescription.m_BlnUnderLineDST = false;
            this.m_txtMainDescription.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMainDescription.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMainDescription.m_IntCanModifyTime = 6;
            this.m_txtMainDescription.m_IntPartControlLength = 0;
            this.m_txtMainDescription.m_IntPartControlStartIndex = 0;
            this.m_txtMainDescription.m_StrUserID = "";
            this.m_txtMainDescription.m_StrUserName = "";
            this.m_txtMainDescription.MaxLength = 100;
            this.m_txtMainDescription.Multiline = false;
            this.m_txtMainDescription.Name = "m_txtMainDescription";
            this.m_txtMainDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMainDescription.Size = new System.Drawing.Size(710, 23);
            this.m_txtMainDescription.TabIndex = 90;
            this.m_txtMainDescription.Tag = "0";
            this.m_txtMainDescription.Text = "";
            // 
            // m_lklCurrentStatus
            // 
            this.m_lklCurrentStatus.AutoSize = true;
            this.m_lklCurrentStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklCurrentStatus.Location = new System.Drawing.Point(3, 35);
            this.m_lklCurrentStatus.Name = "m_lklCurrentStatus";
            this.m_lklCurrentStatus.Size = new System.Drawing.Size(56, 14);
            this.m_lklCurrentStatus.TabIndex = 576;
            this.m_lklCurrentStatus.TabStop = true;
            this.m_lklCurrentStatus.Text = "现病史:";
            this.m_lklCurrentStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtOwnHistory
            // 
            this.m_txtOwnHistory.AccessibleDescription = "个人史";
            this.m_txtOwnHistory.BackColor = System.Drawing.Color.White;
            this.m_txtOwnHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOwnHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOwnHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOwnHistory.Location = new System.Drawing.Point(63, 314);
            this.m_txtOwnHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtOwnHistory.m_BlnPartControl = false;
            this.m_txtOwnHistory.m_BlnReadOnly = false;
            this.m_txtOwnHistory.m_BlnUnderLineDST = false;
            this.m_txtOwnHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOwnHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOwnHistory.m_IntCanModifyTime = 6;
            this.m_txtOwnHistory.m_IntPartControlLength = 0;
            this.m_txtOwnHistory.m_IntPartControlStartIndex = 0;
            this.m_txtOwnHistory.m_StrUserID = "";
            this.m_txtOwnHistory.m_StrUserName = "";
            this.m_txtOwnHistory.Name = "m_txtOwnHistory";
            this.m_txtOwnHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOwnHistory.Size = new System.Drawing.Size(710, 94);
            this.m_txtOwnHistory.TabIndex = 120;
            this.m_txtOwnHistory.Tag = "3";
            this.m_txtOwnHistory.Text = "";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.m_chkCatamenia);
            this.tabPage10.Controls.Add(this.m_lklMarriageHistory);
            this.tabPage10.Controls.Add(this.m_txtFamilyHistory);
            this.tabPage10.Controls.Add(this.m_lklFamilyHistory);
            this.tabPage10.Controls.Add(this.m_txtMarriageHistory);
            this.tabPage10.Controls.Add(this.m_grbCatamenia);
            this.tabPage10.ImageIndex = 0;
            this.tabPage10.Location = new System.Drawing.Point(4, 23);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(786, 417);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "病史二";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // m_chkCatamenia
            // 
            this.m_chkCatamenia.Checked = true;
            this.m_chkCatamenia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCatamenia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCatamenia.Location = new System.Drawing.Point(11, 135);
            this.m_chkCatamenia.Name = "m_chkCatamenia";
            this.m_chkCatamenia.Size = new System.Drawing.Size(112, 24);
            this.m_chkCatamenia.TabIndex = 10000090;
            this.m_chkCatamenia.Tag = "5";
            this.m_chkCatamenia.Text = "月经生育史";
            this.m_chkCatamenia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkCatamenia.CheckedChanged += new System.EventHandler(this.m_chkCatamenia_CheckedChanged);
            // 
            // m_lklMarriageHistory
            // 
            this.m_lklMarriageHistory.AutoSize = true;
            this.m_lklMarriageHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMarriageHistory.Location = new System.Drawing.Point(7, 8);
            this.m_lklMarriageHistory.Name = "m_lklMarriageHistory";
            this.m_lklMarriageHistory.Size = new System.Drawing.Size(56, 14);
            this.m_lklMarriageHistory.TabIndex = 10000091;
            this.m_lklMarriageHistory.TabStop = true;
            this.m_lklMarriageHistory.Text = "婚姻史:";
            this.m_lklMarriageHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtFamilyHistory
            // 
            this.m_txtFamilyHistory.AccessibleDescription = "家族史";
            this.m_txtFamilyHistory.BackColor = System.Drawing.Color.White;
            this.m_txtFamilyHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFamilyHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtFamilyHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFamilyHistory.Location = new System.Drawing.Point(69, 296);
            this.m_txtFamilyHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtFamilyHistory.m_BlnPartControl = false;
            this.m_txtFamilyHistory.m_BlnReadOnly = false;
            this.m_txtFamilyHistory.m_BlnUnderLineDST = false;
            this.m_txtFamilyHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFamilyHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFamilyHistory.m_IntCanModifyTime = 6;
            this.m_txtFamilyHistory.m_IntPartControlLength = 0;
            this.m_txtFamilyHistory.m_IntPartControlStartIndex = 0;
            this.m_txtFamilyHistory.m_StrUserID = "";
            this.m_txtFamilyHistory.m_StrUserName = "";
            this.m_txtFamilyHistory.Name = "m_txtFamilyHistory";
            this.m_txtFamilyHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFamilyHistory.Size = new System.Drawing.Size(702, 104);
            this.m_txtFamilyHistory.TabIndex = 150;
            this.m_txtFamilyHistory.Tag = "7";
            this.m_txtFamilyHistory.Text = "";
            // 
            // m_lklFamilyHistory
            // 
            this.m_lklFamilyHistory.AutoSize = true;
            this.m_lklFamilyHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklFamilyHistory.Location = new System.Drawing.Point(7, 302);
            this.m_lklFamilyHistory.Name = "m_lklFamilyHistory";
            this.m_lklFamilyHistory.Size = new System.Drawing.Size(56, 14);
            this.m_lklFamilyHistory.TabIndex = 10000091;
            this.m_lklFamilyHistory.TabStop = true;
            this.m_lklFamilyHistory.Text = "家族史:";
            this.m_lklFamilyHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtMarriageHistory
            // 
            this.m_txtMarriageHistory.AccessibleDescription = "婚姻史";
            this.m_txtMarriageHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMarriageHistory.BackColor = System.Drawing.Color.White;
            this.m_txtMarriageHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMarriageHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMarriageHistory.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtMarriageHistory.Location = new System.Drawing.Point(69, 6);
            this.m_txtMarriageHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtMarriageHistory.m_BlnPartControl = false;
            this.m_txtMarriageHistory.m_BlnReadOnly = false;
            this.m_txtMarriageHistory.m_BlnUnderLineDST = false;
            this.m_txtMarriageHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMarriageHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMarriageHistory.m_IntCanModifyTime = 6;
            this.m_txtMarriageHistory.m_IntPartControlLength = 0;
            this.m_txtMarriageHistory.m_IntPartControlStartIndex = 0;
            this.m_txtMarriageHistory.m_StrUserID = "";
            this.m_txtMarriageHistory.m_StrUserName = "";
            this.m_txtMarriageHistory.Name = "m_txtMarriageHistory";
            this.m_txtMarriageHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMarriageHistory.Size = new System.Drawing.Size(702, 123);
            this.m_txtMarriageHistory.TabIndex = 130;
            this.m_txtMarriageHistory.Tag = "5";
            this.m_txtMarriageHistory.Text = "";
            // 
            // m_grbCatamenia
            // 
            this.m_grbCatamenia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_grbCatamenia.Controls.Add(this.panel1);
            this.m_grbCatamenia.Controls.Add(this.label13);
            this.m_grbCatamenia.Controls.Add(this.m_cboFirstCatamenia);
            this.m_grbCatamenia.Controls.Add(this.label14);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaLastTime);
            this.m_grbCatamenia.Controls.Add(this.label15);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaCycle);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaCase);
            this.m_grbCatamenia.Controls.Add(this.m_txtCatameniaHistory);
            this.m_grbCatamenia.Location = new System.Drawing.Point(5, 140);
            this.m_grbCatamenia.Name = "m_grbCatamenia";
            this.m_grbCatamenia.Size = new System.Drawing.Size(766, 150);
            this.m_grbCatamenia.TabIndex = 10000090;
            this.m_grbCatamenia.TabStop = false;
            this.m_grbCatamenia.Tag = "5";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_dtpLastCatameniaTime);
            this.panel1.Controls.Add(this.m_cboAmeniaAge);
            this.panel1.Controls.Add(this.m_rdbLastCatameniaTime);
            this.panel1.Controls.Add(this.m_rdbAmeniaAge);
            this.panel1.Location = new System.Drawing.Point(391, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 33);
            this.panel1.TabIndex = 10000091;
            // 
            // m_dtpLastCatameniaTime
            // 
            this.m_dtpLastCatameniaTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpLastCatameniaTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpLastCatameniaTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpLastCatameniaTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpLastCatameniaTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpLastCatameniaTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpLastCatameniaTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpLastCatameniaTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpLastCatameniaTime.Location = new System.Drawing.Point(87, 5);
            this.m_dtpLastCatameniaTime.m_BlnOnlyTime = false;
            this.m_dtpLastCatameniaTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpLastCatameniaTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpLastCatameniaTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpLastCatameniaTime.Name = "m_dtpLastCatameniaTime";
            this.m_dtpLastCatameniaTime.ReadOnly = false;
            this.m_dtpLastCatameniaTime.Size = new System.Drawing.Size(140, 22);
            this.m_dtpLastCatameniaTime.TabIndex = 10000088;
            this.m_dtpLastCatameniaTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpLastCatameniaTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboAmeniaAge
            // 
            this.m_cboAmeniaAge.AccessibleDescription = "闭经年龄";
            this.m_cboAmeniaAge.BackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.BorderColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAmeniaAge.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAmeniaAge.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAmeniaAge.Enabled = false;
            this.m_cboAmeniaAge.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAmeniaAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAmeniaAge.ForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.ListBackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAmeniaAge.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.Location = new System.Drawing.Point(315, 5);
            this.m_cboAmeniaAge.m_BlnEnableItemEventMenu = true;
            this.m_cboAmeniaAge.MaxLength = 32767;
            this.m_cboAmeniaAge.Name = "m_cboAmeniaAge";
            this.m_cboAmeniaAge.SelectedIndex = -1;
            this.m_cboAmeniaAge.SelectedItem = null;
            this.m_cboAmeniaAge.SelectionStart = 0;
            this.m_cboAmeniaAge.Size = new System.Drawing.Size(46, 23);
            this.m_cboAmeniaAge.TabIndex = 10000089;
            this.m_cboAmeniaAge.TextBackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_rdbLastCatameniaTime
            // 
            this.m_rdbLastCatameniaTime.AccessibleDescription = "末次月经时间";
            this.m_rdbLastCatameniaTime.AutoSize = true;
            this.m_rdbLastCatameniaTime.Checked = true;
            this.m_rdbLastCatameniaTime.Location = new System.Drawing.Point(4, 7);
            this.m_rdbLastCatameniaTime.Name = "m_rdbLastCatameniaTime";
            this.m_rdbLastCatameniaTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_rdbLastCatameniaTime.Size = new System.Drawing.Size(88, 18);
            this.m_rdbLastCatameniaTime.TabIndex = 10000090;
            this.m_rdbLastCatameniaTime.TabStop = true;
            this.m_rdbLastCatameniaTime.Text = "末次时间:";
            this.m_rdbLastCatameniaTime.UseVisualStyleBackColor = true;
            this.m_rdbLastCatameniaTime.CheckedChanged += new System.EventHandler(this.m_rdbLastCatameniaTime_CheckedChanged);
            // 
            // m_rdbAmeniaAge
            // 
            this.m_rdbAmeniaAge.AccessibleDescription = "闭经年龄";
            this.m_rdbAmeniaAge.AutoSize = true;
            this.m_rdbAmeniaAge.Location = new System.Drawing.Point(233, 7);
            this.m_rdbAmeniaAge.Name = "m_rdbAmeniaAge";
            this.m_rdbAmeniaAge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_rdbAmeniaAge.Size = new System.Drawing.Size(88, 18);
            this.m_rdbAmeniaAge.TabIndex = 10000090;
            this.m_rdbAmeniaAge.Text = "闭经年龄:";
            this.m_rdbAmeniaAge.UseVisualStyleBackColor = true;
            this.m_rdbAmeniaAge.CheckedChanged += new System.EventHandler(this.m_rdbAmenia_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(6, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000081;
            this.label13.Text = "初潮:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cboFirstCatamenia
            // 
            this.m_cboFirstCatamenia.AccessibleDescription = "月经生育史>> 初潮";
            this.m_cboFirstCatamenia.BackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.BorderColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFirstCatamenia.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFirstCatamenia.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboFirstCatamenia.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFirstCatamenia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFirstCatamenia.ForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.ListBackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboFirstCatamenia.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.Location = new System.Drawing.Point(52, 30);
            this.m_cboFirstCatamenia.m_BlnEnableItemEventMenu = true;
            this.m_cboFirstCatamenia.MaxLength = 32767;
            this.m_cboFirstCatamenia.Name = "m_cboFirstCatamenia";
            this.m_cboFirstCatamenia.SelectedIndex = -1;
            this.m_cboFirstCatamenia.SelectedItem = null;
            this.m_cboFirstCatamenia.SelectionStart = 0;
            this.m_cboFirstCatamenia.Size = new System.Drawing.Size(140, 23);
            this.m_cboFirstCatamenia.TabIndex = 10000082;
            this.m_cboFirstCatamenia.TextBackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.TextForeColor = System.Drawing.Color.Black;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(198, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 10000083;
            this.label14.Text = "经期:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cboCatameniaLastTime
            // 
            this.m_cboCatameniaLastTime.AccessibleDescription = "月经生育史>> 经期";
            this.m_cboCatameniaLastTime.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.BorderColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCatameniaLastTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaLastTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaLastTime.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaLastTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaLastTime.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaLastTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.Location = new System.Drawing.Point(245, 30);
            this.m_cboCatameniaLastTime.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaLastTime.MaxLength = 32767;
            this.m_cboCatameniaLastTime.Name = "m_cboCatameniaLastTime";
            this.m_cboCatameniaLastTime.SelectedIndex = -1;
            this.m_cboCatameniaLastTime.SelectedItem = null;
            this.m_cboCatameniaLastTime.SelectionStart = 0;
            this.m_cboCatameniaLastTime.Size = new System.Drawing.Size(140, 23);
            this.m_cboCatameniaLastTime.TabIndex = 10000084;
            this.m_cboCatameniaLastTime.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(198, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 10000085;
            this.label15.Text = "周期:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cboCatameniaCycle
            // 
            this.m_cboCatameniaCycle.AccessibleDescription = "月经生育史>> 周期";
            this.m_cboCatameniaCycle.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.BorderColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCatameniaCycle.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaCycle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaCycle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCycle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCycle.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaCycle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.Location = new System.Drawing.Point(245, 58);
            this.m_cboCatameniaCycle.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaCycle.MaxLength = 32767;
            this.m_cboCatameniaCycle.Name = "m_cboCatameniaCycle";
            this.m_cboCatameniaCycle.SelectedIndex = -1;
            this.m_cboCatameniaCycle.SelectedItem = null;
            this.m_cboCatameniaCycle.SelectionStart = 0;
            this.m_cboCatameniaCycle.Size = new System.Drawing.Size(140, 23);
            this.m_cboCatameniaCycle.TabIndex = 10000086;
            this.m_cboCatameniaCycle.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboCatameniaCase
            // 
            this.m_cboCatameniaCase.AccessibleDescription = "月经生育史>> 月经情况";
            this.m_cboCatameniaCase.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.BorderColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboCatameniaCase.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaCase.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaCase.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCase.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaCase.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.Location = new System.Drawing.Point(479, 58);
            this.m_cboCatameniaCase.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaCase.MaxLength = 32767;
            this.m_cboCatameniaCase.Name = "m_cboCatameniaCase";
            this.m_cboCatameniaCase.SelectedIndex = -1;
            this.m_cboCatameniaCase.SelectedItem = null;
            this.m_cboCatameniaCase.SelectionStart = 0;
            this.m_cboCatameniaCase.Size = new System.Drawing.Size(140, 23);
            this.m_cboCatameniaCase.TabIndex = 10000089;
            this.m_cboCatameniaCase.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtCatameniaHistory
            // 
            this.m_txtCatameniaHistory.AccessibleDescription = "月经史";
            this.m_txtCatameniaHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCatameniaHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCatameniaHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCatameniaHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCatameniaHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCatameniaHistory.Location = new System.Drawing.Point(9, 88);
            this.m_txtCatameniaHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtCatameniaHistory.m_BlnPartControl = false;
            this.m_txtCatameniaHistory.m_BlnReadOnly = false;
            this.m_txtCatameniaHistory.m_BlnUnderLineDST = false;
            this.m_txtCatameniaHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCatameniaHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCatameniaHistory.m_IntCanModifyTime = 6;
            this.m_txtCatameniaHistory.m_IntPartControlLength = 0;
            this.m_txtCatameniaHistory.m_IntPartControlStartIndex = 0;
            this.m_txtCatameniaHistory.m_StrUserID = "";
            this.m_txtCatameniaHistory.m_StrUserName = "";
            this.m_txtCatameniaHistory.Name = "m_txtCatameniaHistory";
            this.m_txtCatameniaHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCatameniaHistory.Size = new System.Drawing.Size(751, 56);
            this.m_txtCatameniaHistory.TabIndex = 140;
            this.m_txtCatameniaHistory.Tag = "6";
            this.m_txtCatameniaHistory.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_txtProfessionalCheck);
            this.tabPage2.Controls.Add(this.m_lklProfessionalCheck);
            this.tabPage2.Controls.Add(this.m_lklMedical);
            this.tabPage2.Controls.Add(this.lblPulse);
            this.tabPage2.Controls.Add(this.m_txtMedical);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.m_txtWeight);
            this.tabPage2.Controls.Add(this.m_txtBreath);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.lblBreath);
            this.tabPage2.Controls.Add(this.m_txtPulse);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lblDia);
            this.tabPage2.Controls.Add(this.m_txtTemperature);
            this.tabPage2.Controls.Add(this.lblTemperature);
            this.tabPage2.Controls.Add(this.m_cboBloodPressure);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(786, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "体格检查";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_txtProfessionalCheck
            // 
            this.m_txtProfessionalCheck.AccessibleDescription = "专科检查";
            this.m_txtProfessionalCheck.BackColor = System.Drawing.Color.White;
            this.m_txtProfessionalCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProfessionalCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtProfessionalCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtProfessionalCheck.Location = new System.Drawing.Point(13, 238);
            this.m_txtProfessionalCheck.m_BlnIgnoreUserInfo = false;
            this.m_txtProfessionalCheck.m_BlnPartControl = false;
            this.m_txtProfessionalCheck.m_BlnReadOnly = false;
            this.m_txtProfessionalCheck.m_BlnUnderLineDST = false;
            this.m_txtProfessionalCheck.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtProfessionalCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtProfessionalCheck.m_IntCanModifyTime = 6;
            this.m_txtProfessionalCheck.m_IntPartControlLength = 0;
            this.m_txtProfessionalCheck.m_IntPartControlStartIndex = 0;
            this.m_txtProfessionalCheck.m_StrUserID = "";
            this.m_txtProfessionalCheck.m_StrUserName = "";
            this.m_txtProfessionalCheck.Name = "m_txtProfessionalCheck";
            this.m_txtProfessionalCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtProfessionalCheck.Size = new System.Drawing.Size(751, 159);
            this.m_txtProfessionalCheck.TabIndex = 10000107;
            this.m_txtProfessionalCheck.Tag = "9";
            this.m_txtProfessionalCheck.Text = "";
            // 
            // m_lklProfessionalCheck
            // 
            this.m_lklProfessionalCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lklProfessionalCheck.AutoSize = true;
            this.m_lklProfessionalCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklProfessionalCheck.Location = new System.Drawing.Point(16, 217);
            this.m_lklProfessionalCheck.Name = "m_lklProfessionalCheck";
            this.m_lklProfessionalCheck.Size = new System.Drawing.Size(70, 14);
            this.m_lklProfessionalCheck.TabIndex = 10000108;
            this.m_lklProfessionalCheck.TabStop = true;
            this.m_lklProfessionalCheck.Text = "专科检查:";
            // 
            // m_lklMedical
            // 
            this.m_lklMedical.AutoSize = true;
            this.m_lklMedical.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMedical.Location = new System.Drawing.Point(16, 16);
            this.m_lklMedical.Name = "m_lklMedical";
            this.m_lklMedical.Size = new System.Drawing.Size(70, 14);
            this.m_lklMedical.TabIndex = 10000094;
            this.m_lklMedical.TabStop = true;
            this.m_lklMedical.Text = "体格检查:";
            this.m_lklMedical.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // lblPulse
            // 
            this.lblPulse.AutoSize = true;
            this.lblPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulse.Location = new System.Drawing.Point(210, 16);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(42, 14);
            this.lblPulse.TabIndex = 560;
            this.lblPulse.Tag = "8";
            this.lblPulse.Text = "脉搏:";
            this.lblPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtMedical
            // 
            this.m_txtMedical.AccessibleDescription = "体格检查";
            this.m_txtMedical.BackColor = System.Drawing.Color.White;
            this.m_txtMedical.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedical.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMedical.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMedical.Location = new System.Drawing.Point(13, 40);
            this.m_txtMedical.m_BlnIgnoreUserInfo = false;
            this.m_txtMedical.m_BlnPartControl = false;
            this.m_txtMedical.m_BlnReadOnly = false;
            this.m_txtMedical.m_BlnUnderLineDST = false;
            this.m_txtMedical.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMedical.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMedical.m_IntCanModifyTime = 6;
            this.m_txtMedical.m_IntPartControlLength = 0;
            this.m_txtMedical.m_IntPartControlStartIndex = 0;
            this.m_txtMedical.m_StrUserID = "";
            this.m_txtMedical.m_StrUserName = "";
            this.m_txtMedical.Name = "m_txtMedical";
            this.m_txtMedical.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMedical.Size = new System.Drawing.Size(754, 166);
            this.m_txtMedical.TabIndex = 210;
            this.m_txtMedical.Tag = "8";
            this.m_txtMedical.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(190, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 14);
            this.label17.TabIndex = 10000091;
            this.label17.Tag = "8";
            this.label17.Text = "℃";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(302, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 14);
            this.label18.TabIndex = 10000092;
            this.label18.Tag = "8";
            this.label18.Text = "次/分";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "体重";
            this.m_txtWeight.BackColor = System.Drawing.Color.White;
            this.m_txtWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWeight.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWeight.Location = new System.Drawing.Point(672, 12);
            this.m_txtWeight.m_BlnIgnoreUserInfo = false;
            this.m_txtWeight.m_BlnPartControl = false;
            this.m_txtWeight.m_BlnReadOnly = false;
            this.m_txtWeight.m_BlnUnderLineDST = false;
            this.m_txtWeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWeight.m_IntCanModifyTime = 6;
            this.m_txtWeight.m_IntPartControlLength = 0;
            this.m_txtWeight.m_IntPartControlStartIndex = 0;
            this.m_txtWeight.m_StrUserID = "";
            this.m_txtWeight.m_StrUserName = "";
            this.m_txtWeight.MaxLength = 20;
            this.m_txtWeight.Multiline = false;
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtWeight.Size = new System.Drawing.Size(60, 21);
            this.m_txtWeight.TabIndex = 180;
            this.m_txtWeight.Tag = "8";
            this.m_txtWeight.Text = "";
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.AccessibleDescription = "呼吸";
            this.m_txtBreath.BackColor = System.Drawing.Color.White;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(386, 13);
            this.m_txtBreath.m_BlnIgnoreUserInfo = false;
            this.m_txtBreath.m_BlnPartControl = false;
            this.m_txtBreath.m_BlnReadOnly = false;
            this.m_txtBreath.m_BlnUnderLineDST = false;
            this.m_txtBreath.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreath.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreath.m_IntCanModifyTime = 6;
            this.m_txtBreath.m_IntPartControlLength = 0;
            this.m_txtBreath.m_IntPartControlStartIndex = 0;
            this.m_txtBreath.m_StrUserID = "";
            this.m_txtBreath.m_StrUserName = "";
            this.m_txtBreath.MaxLength = 20;
            this.m_txtBreath.Multiline = false;
            this.m_txtBreath.Name = "m_txtBreath";
            this.m_txtBreath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBreath.Size = new System.Drawing.Size(52, 21);
            this.m_txtBreath.TabIndex = 180;
            this.m_txtBreath.Tag = "8";
            this.m_txtBreath.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(436, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 14);
            this.label19.TabIndex = 10000093;
            this.label19.Tag = "8";
            this.label19.Text = "次/分";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBreath
            // 
            this.lblBreath.AutoSize = true;
            this.lblBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreath.Location = new System.Drawing.Point(344, 16);
            this.lblBreath.Name = "lblBreath";
            this.lblBreath.Size = new System.Drawing.Size(42, 14);
            this.lblBreath.TabIndex = 559;
            this.lblBreath.Tag = "8";
            this.lblBreath.Text = "呼吸:";
            this.lblBreath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(252, 13);
            this.m_txtPulse.m_BlnIgnoreUserInfo = false;
            this.m_txtPulse.m_BlnPartControl = false;
            this.m_txtPulse.m_BlnReadOnly = false;
            this.m_txtPulse.m_BlnUnderLineDST = false;
            this.m_txtPulse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPulse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPulse.m_IntCanModifyTime = 6;
            this.m_txtPulse.m_IntPartControlLength = 0;
            this.m_txtPulse.m_IntPartControlStartIndex = 0;
            this.m_txtPulse.m_StrUserID = "";
            this.m_txtPulse.m_StrUserName = "";
            this.m_txtPulse.MaxLength = 20;
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPulse.Size = new System.Drawing.Size(52, 21);
            this.m_txtPulse.TabIndex = 170;
            this.m_txtPulse.Tag = "8";
            this.m_txtPulse.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(737, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 562;
            this.label5.Tag = "8";
            this.label5.Text = "Kg";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(631, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 562;
            this.label4.Tag = "8";
            this.label4.Text = "体重:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDia.Location = new System.Drawing.Point(478, 16);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(42, 14);
            this.lblDia.TabIndex = 562;
            this.lblDia.Tag = "8";
            this.lblDia.Text = "血压:";
            this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtTemperature.Location = new System.Drawing.Point(140, 13);
            this.m_txtTemperature.m_BlnIgnoreUserInfo = false;
            this.m_txtTemperature.m_BlnPartControl = false;
            this.m_txtTemperature.m_BlnReadOnly = false;
            this.m_txtTemperature.m_BlnUnderLineDST = false;
            this.m_txtTemperature.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTemperature.m_IntCanModifyTime = 6;
            this.m_txtTemperature.m_IntPartControlLength = 0;
            this.m_txtTemperature.m_IntPartControlStartIndex = 0;
            this.m_txtTemperature.m_StrUserID = "";
            this.m_txtTemperature.m_StrUserName = "";
            this.m_txtTemperature.MaxLength = 20;
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtTemperature.Size = new System.Drawing.Size(52, 21);
            this.m_txtTemperature.TabIndex = 160;
            this.m_txtTemperature.Tag = "8";
            this.m_txtTemperature.Text = "";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperature.Location = new System.Drawing.Point(96, 16);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(42, 14);
            this.lblTemperature.TabIndex = 565;
            this.lblTemperature.Tag = "8";
            this.lblTemperature.Text = "体温:";
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cboBloodPressure
            // 
            this.m_cboBloodPressure.AccessibleDescription = "血压";
            this.m_cboBloodPressure.BackColor = System.Drawing.Color.White;
            this.m_cboBloodPressure.BorderColor = System.Drawing.Color.Black;
            this.m_cboBloodPressure.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBloodPressure.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBloodPressure.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBloodPressure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBloodPressure.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBloodPressure.ForeColor = System.Drawing.Color.Black;
            this.m_cboBloodPressure.ListBackColor = System.Drawing.Color.White;
            this.m_cboBloodPressure.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBloodPressure.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBloodPressure.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBloodPressure.Location = new System.Drawing.Point(522, 11);
            this.m_cboBloodPressure.m_BlnEnableItemEventMenu = true;
            this.m_cboBloodPressure.MaxLength = 32767;
            this.m_cboBloodPressure.Name = "m_cboBloodPressure";
            this.m_cboBloodPressure.SelectedIndex = -1;
            this.m_cboBloodPressure.SelectedItem = null;
            this.m_cboBloodPressure.SelectionStart = 0;
            this.m_cboBloodPressure.Size = new System.Drawing.Size(99, 23);
            this.m_cboBloodPressure.TabIndex = 50;
            this.m_cboBloodPressure.TextBackColor = System.Drawing.Color.White;
            this.m_cboBloodPressure.TextForeColor = System.Drawing.Color.Black;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.panel2);
            this.tabPage11.Controls.Add(this.m_lklLabCheck);
            this.tabPage11.Controls.Add(this.m_txtLabCheck);
            this.tabPage11.Controls.Add(this.pnlFocus);
            this.tabPage11.ImageIndex = 1;
            this.tabPage11.Location = new System.Drawing.Point(4, 23);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(786, 417);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "辅助检查";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmdSeeCheckResult);
            this.panel2.Controls.Add(this.m_cmdUseSelectedContent);
            this.panel2.Controls.Add(this.m_cmdUseAllContent);
            this.panel2.Controls.Add(this.m_txtLISContent);
            this.panel2.Controls.Add(this.m_lsvLISContent);
            this.panel2.Location = new System.Drawing.Point(11, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 373);
            this.panel2.TabIndex = 10000106;
            // 
            // m_cmdSeeCheckResult
            // 
            this.m_cmdSeeCheckResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSeeCheckResult.Font = new System.Drawing.Font("宋体", 9F);
            this.m_cmdSeeCheckResult.Location = new System.Drawing.Point(7, 348);
            this.m_cmdSeeCheckResult.Name = "m_cmdSeeCheckResult";
            this.m_cmdSeeCheckResult.Size = new System.Drawing.Size(190, 25);
            this.m_cmdSeeCheckResult.TabIndex = 10000108;
            this.m_cmdSeeCheckResult.Text = "查看病人记录";
            this.m_cmdSeeCheckResult.UseVisualStyleBackColor = true;
            this.m_cmdSeeCheckResult.Click += new System.EventHandler(this.m_cmdSeeCheckResult_Click);
            // 
            // m_cmdUseSelectedContent
            // 
            this.m_cmdUseSelectedContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdUseSelectedContent.Font = new System.Drawing.Font("宋体", 9F);
            this.m_cmdUseSelectedContent.Location = new System.Drawing.Point(101, 319);
            this.m_cmdUseSelectedContent.Name = "m_cmdUseSelectedContent";
            this.m_cmdUseSelectedContent.Size = new System.Drawing.Size(94, 25);
            this.m_cmdUseSelectedContent.TabIndex = 10000107;
            this.m_cmdUseSelectedContent.Text = "使用选中内容";
            this.m_cmdUseSelectedContent.UseVisualStyleBackColor = true;
            this.m_cmdUseSelectedContent.Click += new System.EventHandler(this.m_cmdUseSelectedContent_Click);
            // 
            // m_cmdUseAllContent
            // 
            this.m_cmdUseAllContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdUseAllContent.Font = new System.Drawing.Font("宋体", 9F);
            this.m_cmdUseAllContent.Location = new System.Drawing.Point(7, 319);
            this.m_cmdUseAllContent.Name = "m_cmdUseAllContent";
            this.m_cmdUseAllContent.Size = new System.Drawing.Size(95, 25);
            this.m_cmdUseAllContent.TabIndex = 10000107;
            this.m_cmdUseAllContent.Text = "使用全部内容";
            this.m_cmdUseAllContent.UseVisualStyleBackColor = true;
            this.m_cmdUseAllContent.Click += new System.EventHandler(this.m_cmdUseAllContent_Click);
            // 
            // m_txtLISContent
            // 
            this.m_txtLISContent.HideSelection = false;
            this.m_txtLISContent.Location = new System.Drawing.Point(5, 193);
            this.m_txtLISContent.Multiline = true;
            this.m_txtLISContent.Name = "m_txtLISContent";
            this.m_txtLISContent.ReadOnly = true;
            this.m_txtLISContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_txtLISContent.Size = new System.Drawing.Size(192, 124);
            this.m_txtLISContent.TabIndex = 10000106;
            // 
            // m_lsvLISContent
            // 
            this.m_lsvLISContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvLISContent.GridLines = true;
            this.m_lsvLISContent.HideSelection = false;
            this.m_lsvLISContent.Location = new System.Drawing.Point(5, 3);
            this.m_lsvLISContent.MultiSelect = false;
            this.m_lsvLISContent.Name = "m_lsvLISContent";
            this.m_lsvLISContent.Size = new System.Drawing.Size(192, 191);
            this.m_lsvLISContent.TabIndex = 10000105;
            this.m_lsvLISContent.UseCompatibleStateImageBehavior = false;
            this.m_lsvLISContent.View = System.Windows.Forms.View.Details;
            this.m_lsvLISContent.SelectedIndexChanged += new System.EventHandler(this.m_lsvLISContent_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验内容";
            this.columnHeader1.Width = 177;
            // 
            // m_lklLabCheck
            // 
            this.m_lklLabCheck.AutoSize = true;
            this.m_lklLabCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklLabCheck.Location = new System.Drawing.Point(21, 10);
            this.m_lklLabCheck.Name = "m_lklLabCheck";
            this.m_lklLabCheck.Size = new System.Drawing.Size(70, 14);
            this.m_lklLabCheck.TabIndex = 10000104;
            this.m_lklLabCheck.TabStop = true;
            this.m_lklLabCheck.Text = "辅助检查:";
            this.m_lklLabCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtLabCheck
            // 
            this.m_txtLabCheck.AccessibleDescription = "实验室检查";
            this.m_txtLabCheck.BackColor = System.Drawing.Color.White;
            this.m_txtLabCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLabCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtLabCheck.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtLabCheck.Location = new System.Drawing.Point(217, 27);
            this.m_txtLabCheck.m_BlnIgnoreUserInfo = false;
            this.m_txtLabCheck.m_BlnPartControl = false;
            this.m_txtLabCheck.m_BlnReadOnly = false;
            this.m_txtLabCheck.m_BlnUnderLineDST = false;
            this.m_txtLabCheck.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLabCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLabCheck.m_IntCanModifyTime = 6;
            this.m_txtLabCheck.m_IntPartControlLength = 0;
            this.m_txtLabCheck.m_IntPartControlStartIndex = 0;
            this.m_txtLabCheck.m_StrUserID = "";
            this.m_txtLabCheck.m_StrUserName = "";
            this.m_txtLabCheck.Name = "m_txtLabCheck";
            this.m_txtLabCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtLabCheck.Size = new System.Drawing.Size(552, 372);
            this.m_txtLabCheck.TabIndex = 240;
            this.m_txtLabCheck.Tag = "10";
            this.m_txtLabCheck.Text = "";
            // 
            // pnlFocus
            // 
            this.pnlFocus.Location = new System.Drawing.Point(202, 15);
            this.pnlFocus.Name = "pnlFocus";
            this.pnlFocus.Size = new System.Drawing.Size(0, 0);
            this.pnlFocus.TabIndex = 10000095;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.m_lbDiagnose);
            this.tabPage12.Controls.Add(this.m_lbDiagnoseDate);
            this.tabPage12.Controls.Add(this.m_dtpDiagnosedoc);
            this.tabPage12.Controls.Add(this.m_txtDiagnosedoc);
            this.tabPage12.Controls.Add(this.m_cmdDiagnose);
            this.tabPage12.Controls.Add(this.m_txtDiagnose);
            this.tabPage12.Controls.Add(this.m_txtPrimaryDoc);
            this.tabPage12.Controls.Add(this.m_dtpPrimaryDoc);
            this.tabPage12.Controls.Add(this.m_cmdPrimaryDoc);
            this.tabPage12.Controls.Add(this.label3);
            this.tabPage12.Controls.Add(this.m_txtModifydiagnose);
            this.tabPage12.Controls.Add(this.m_txtDirectorDoc);
            this.tabPage12.Controls.Add(this.m_txtModifyDiagnoseDoctor);
            this.tabPage12.Controls.Add(this.m_dtpModifyDiagnoseDate);
            this.tabPage12.Controls.Add(this.m_lklModifydiagnose);
            this.tabPage12.Controls.Add(this.m_cmdModifyDiagnoseDoctor);
            this.tabPage12.Controls.Add(this.label2);
            this.tabPage12.Controls.Add(this.m_cmdDirectorDoc);
            this.tabPage12.Controls.Add(this.m_txtPrimaryDiagnose);
            this.tabPage12.Controls.Add(this.m_lklPrimaryDiagnose);
            this.tabPage12.ImageIndex = 3;
            this.tabPage12.Location = new System.Drawing.Point(4, 23);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(786, 417);
            this.tabPage12.TabIndex = 5;
            this.tabPage12.Text = "诊断（一）";
            this.tabPage12.UseVisualStyleBackColor = true;
            this.tabPage12.Click += new System.EventHandler(this.tabPage12_Click);
            // 
            // m_lbDiagnose
            // 
            this.m_lbDiagnose.AutoSize = true;
            this.m_lbDiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lbDiagnose.Location = new System.Drawing.Point(13, 148);
            this.m_lbDiagnose.Name = "m_lbDiagnose";
            this.m_lbDiagnose.Size = new System.Drawing.Size(70, 14);
            this.m_lbDiagnose.TabIndex = 10000148;
            this.m_lbDiagnose.TabStop = true;
            this.m_lbDiagnose.Text = "诊    断:";
            this.m_lbDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lbDiagnoseDate
            // 
            this.m_lbDiagnoseDate.AutoSize = true;
            this.m_lbDiagnoseDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbDiagnoseDate.Location = new System.Drawing.Point(289, 262);
            this.m_lbDiagnoseDate.Name = "m_lbDiagnoseDate";
            this.m_lbDiagnoseDate.Size = new System.Drawing.Size(42, 14);
            this.m_lbDiagnoseDate.TabIndex = 10000147;
            this.m_lbDiagnoseDate.Text = "日期:";
            this.m_lbDiagnoseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpDiagnosedoc
            // 
            this.m_dtpDiagnosedoc.BorderColor = System.Drawing.Color.Black;
            this.m_dtpDiagnosedoc.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpDiagnosedoc.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpDiagnosedoc.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpDiagnosedoc.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpDiagnosedoc.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpDiagnosedoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDiagnosedoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDiagnosedoc.Location = new System.Drawing.Point(333, 259);
            this.m_dtpDiagnosedoc.m_BlnOnlyTime = false;
            this.m_dtpDiagnosedoc.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpDiagnosedoc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpDiagnosedoc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDiagnosedoc.Name = "m_dtpDiagnosedoc";
            this.m_dtpDiagnosedoc.ReadOnly = false;
            this.m_dtpDiagnosedoc.Size = new System.Drawing.Size(214, 22);
            this.m_dtpDiagnosedoc.TabIndex = 10000146;
            this.m_dtpDiagnosedoc.TextBackColor = System.Drawing.Color.White;
            this.m_dtpDiagnosedoc.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtDiagnosedoc
            // 
            this.m_txtDiagnosedoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtDiagnosedoc.Location = new System.Drawing.Point(183, 258);
            this.m_txtDiagnosedoc.Name = "m_txtDiagnosedoc";
            this.m_txtDiagnosedoc.ReadOnly = true;
            this.m_txtDiagnosedoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtDiagnosedoc.TabIndex = 10000145;
            // 
            // m_cmdDiagnose
            // 
            this.m_cmdDiagnose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdDiagnose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDiagnose.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdDiagnose.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDiagnose.Location = new System.Drawing.Point(91, 254);
            this.m_cmdDiagnose.Name = "m_cmdDiagnose";
            this.m_cmdDiagnose.Size = new System.Drawing.Size(82, 30);
            this.m_cmdDiagnose.TabIndex = 10000144;
            this.m_cmdDiagnose.Text = "医师签名:";
            this.m_cmdDiagnose.UseVisualStyleBackColor = false;
            // 
            // m_txtDiagnose
            // 
            this.m_txtDiagnose.AccessibleDescription = "诊断";
            this.m_txtDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnose.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtDiagnose.Location = new System.Drawing.Point(89, 147);
            this.m_txtDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnose.m_BlnPartControl = false;
            this.m_txtDiagnose.m_BlnReadOnly = false;
            this.m_txtDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnose.m_IntCanModifyTime = 6;
            this.m_txtDiagnose.m_IntPartControlLength = 0;
            this.m_txtDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnose.m_StrUserID = "";
            this.m_txtDiagnose.m_StrUserName = "";
            this.m_txtDiagnose.Name = "m_txtDiagnose";
            this.m_txtDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnose.Size = new System.Drawing.Size(673, 101);
            this.m_txtDiagnose.TabIndex = 10000143;
            this.m_txtDiagnose.Tag = "12";
            this.m_txtDiagnose.Text = "";
            // 
            // m_txtPrimaryDoc
            // 
            this.m_txtPrimaryDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtPrimaryDoc.Location = new System.Drawing.Point(175, 117);
            this.m_txtPrimaryDoc.Name = "m_txtPrimaryDoc";
            this.m_txtPrimaryDoc.ReadOnly = true;
            this.m_txtPrimaryDoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtPrimaryDoc.TabIndex = 10000142;
            // 
            // m_dtpPrimaryDoc
            // 
            this.m_dtpPrimaryDoc.BorderColor = System.Drawing.Color.Black;
            this.m_dtpPrimaryDoc.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpPrimaryDoc.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpPrimaryDoc.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpPrimaryDoc.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpPrimaryDoc.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpPrimaryDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpPrimaryDoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpPrimaryDoc.Location = new System.Drawing.Point(331, 117);
            this.m_dtpPrimaryDoc.m_BlnOnlyTime = false;
            this.m_dtpPrimaryDoc.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpPrimaryDoc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpPrimaryDoc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpPrimaryDoc.Name = "m_dtpPrimaryDoc";
            this.m_dtpPrimaryDoc.ReadOnly = false;
            this.m_dtpPrimaryDoc.Size = new System.Drawing.Size(214, 22);
            this.m_dtpPrimaryDoc.TabIndex = 10000139;
            this.m_dtpPrimaryDoc.TextBackColor = System.Drawing.Color.White;
            this.m_dtpPrimaryDoc.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdPrimaryDoc
            // 
            this.m_cmdPrimaryDoc.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdPrimaryDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrimaryDoc.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdPrimaryDoc.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdPrimaryDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrimaryDoc.ForeColor = System.Drawing.Color.Black;
            this.m_cmdPrimaryDoc.Location = new System.Drawing.Point(87, 112);
            this.m_cmdPrimaryDoc.Name = "m_cmdPrimaryDoc";
            this.m_cmdPrimaryDoc.Size = new System.Drawing.Size(82, 30);
            this.m_cmdPrimaryDoc.TabIndex = 10000140;
            this.m_cmdPrimaryDoc.Text = "医师签名:";
            this.m_cmdPrimaryDoc.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(283, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000141;
            this.label3.Text = "日期:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtModifydiagnose
            // 
            this.m_txtModifydiagnose.AccessibleDescription = "修正诊断";
            this.m_txtModifydiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtModifydiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtModifydiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtModifydiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtModifydiagnose.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtModifydiagnose.Location = new System.Drawing.Point(91, 287);
            this.m_txtModifydiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtModifydiagnose.m_BlnPartControl = false;
            this.m_txtModifydiagnose.m_BlnReadOnly = false;
            this.m_txtModifydiagnose.m_BlnUnderLineDST = false;
            this.m_txtModifydiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtModifydiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtModifydiagnose.m_IntCanModifyTime = 6;
            this.m_txtModifydiagnose.m_IntPartControlLength = 0;
            this.m_txtModifydiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtModifydiagnose.m_StrUserID = "";
            this.m_txtModifydiagnose.m_StrUserName = "";
            this.m_txtModifydiagnose.Name = "m_txtModifydiagnose";
            this.m_txtModifydiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtModifydiagnose.Size = new System.Drawing.Size(673, 82);
            this.m_txtModifydiagnose.TabIndex = 10000138;
            this.m_txtModifydiagnose.Tag = "12";
            this.m_txtModifydiagnose.Text = "";
            // 
            // m_txtDirectorDoc
            // 
            this.m_txtDirectorDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDirectorDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtDirectorDoc.Location = new System.Drawing.Point(674, 167);
            this.m_txtDirectorDoc.Name = "m_txtDirectorDoc";
            this.m_txtDirectorDoc.ReadOnly = true;
            this.m_txtDirectorDoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtDirectorDoc.TabIndex = 10000136;
            this.m_txtDirectorDoc.Visible = false;
            // 
            // m_txtModifyDiagnoseDoctor
            // 
            this.m_txtModifyDiagnoseDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtModifyDiagnoseDoctor.Location = new System.Drawing.Point(186, 378);
            this.m_txtModifyDiagnoseDoctor.Name = "m_txtModifyDiagnoseDoctor";
            this.m_txtModifyDiagnoseDoctor.ReadOnly = true;
            this.m_txtModifyDiagnoseDoctor.Size = new System.Drawing.Size(100, 23);
            this.m_txtModifyDiagnoseDoctor.TabIndex = 10000133;
            // 
            // m_dtpModifyDiagnoseDate
            // 
            this.m_dtpModifyDiagnoseDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpModifyDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpModifyDiagnoseDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpModifyDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpModifyDiagnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpModifyDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpModifyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpModifyDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpModifyDiagnoseDate.Location = new System.Drawing.Point(335, 378);
            this.m_dtpModifyDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpModifyDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpModifyDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.Name = "m_dtpModifyDiagnoseDate";
            this.m_dtpModifyDiagnoseDate.ReadOnly = false;
            this.m_dtpModifyDiagnoseDate.Size = new System.Drawing.Size(214, 22);
            this.m_dtpModifyDiagnoseDate.TabIndex = 10000125;
            this.m_dtpModifyDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpModifyDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lklModifydiagnose
            // 
            this.m_lklModifydiagnose.AutoSize = true;
            this.m_lklModifydiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklModifydiagnose.Location = new System.Drawing.Point(13, 292);
            this.m_lklModifydiagnose.Name = "m_lklModifydiagnose";
            this.m_lklModifydiagnose.Size = new System.Drawing.Size(70, 14);
            this.m_lklModifydiagnose.TabIndex = 10000124;
            this.m_lklModifydiagnose.TabStop = true;
            this.m_lklModifydiagnose.Text = "修正诊断:";
            this.m_lklModifydiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_cmdModifyDiagnoseDoctor
            // 
            this.m_cmdModifyDiagnoseDoctor.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdModifyDiagnoseDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyDiagnoseDoctor.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdModifyDiagnoseDoctor.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdModifyDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdModifyDiagnoseDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdModifyDiagnoseDoctor.Location = new System.Drawing.Point(91, 376);
            this.m_cmdModifyDiagnoseDoctor.Name = "m_cmdModifyDiagnoseDoctor";
            this.m_cmdModifyDiagnoseDoctor.Size = new System.Drawing.Size(82, 30);
            this.m_cmdModifyDiagnoseDoctor.TabIndex = 10000127;
            this.m_cmdModifyDiagnoseDoctor.Text = "医师签名:";
            this.m_cmdModifyDiagnoseDoctor.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(287, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000132;
            this.label2.Text = "日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdDirectorDoc
            // 
            this.m_cmdDirectorDoc.AccessibleDescription = "";
            this.m_cmdDirectorDoc.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdDirectorDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDirectorDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDirectorDoc.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdDirectorDoc.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdDirectorDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirectorDoc.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDirectorDoc.Location = new System.Drawing.Point(556, 167);
            this.m_cmdDirectorDoc.Name = "m_cmdDirectorDoc";
            this.m_cmdDirectorDoc.Size = new System.Drawing.Size(80, 30);
            this.m_cmdDirectorDoc.TabIndex = 10000129;
            this.m_cmdDirectorDoc.Text = "主任医师:";
            this.m_cmdDirectorDoc.UseVisualStyleBackColor = false;
            this.m_cmdDirectorDoc.Visible = false;
            // 
            // m_txtPrimaryDiagnose
            // 
            this.m_txtPrimaryDiagnose.AccessibleDescription = "初步诊断";
            this.m_txtPrimaryDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPrimaryDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrimaryDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtPrimaryDiagnose.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtPrimaryDiagnose.Location = new System.Drawing.Point(89, 4);
            this.m_txtPrimaryDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtPrimaryDiagnose.m_BlnPartControl = false;
            this.m_txtPrimaryDiagnose.m_BlnReadOnly = false;
            this.m_txtPrimaryDiagnose.m_BlnUnderLineDST = false;
            this.m_txtPrimaryDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPrimaryDiagnose.m_IntCanModifyTime = 6;
            this.m_txtPrimaryDiagnose.m_IntPartControlLength = 0;
            this.m_txtPrimaryDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtPrimaryDiagnose.m_StrUserID = "";
            this.m_txtPrimaryDiagnose.m_StrUserName = "";
            this.m_txtPrimaryDiagnose.Name = "m_txtPrimaryDiagnose";
            this.m_txtPrimaryDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPrimaryDiagnose.Size = new System.Drawing.Size(673, 102);
            this.m_txtPrimaryDiagnose.TabIndex = 10000121;
            this.m_txtPrimaryDiagnose.Tag = "12";
            this.m_txtPrimaryDiagnose.Text = "";
            // 
            // m_lklPrimaryDiagnose
            // 
            this.m_lklPrimaryDiagnose.AutoSize = true;
            this.m_lklPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklPrimaryDiagnose.Location = new System.Drawing.Point(13, 12);
            this.m_lklPrimaryDiagnose.Name = "m_lklPrimaryDiagnose";
            this.m_lklPrimaryDiagnose.Size = new System.Drawing.Size(70, 14);
            this.m_lklPrimaryDiagnose.TabIndex = 10000122;
            this.m_lklPrimaryDiagnose.TabStop = true;
            this.m_lklPrimaryDiagnose.Text = "初步诊断:";
            this.m_lklPrimaryDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_cltbuchong);
            this.tabPage4.Controls.Add(this.m_txtBuchongDoctor);
            this.tabPage4.Controls.Add(this.m_cmdBuchongDoctor);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.m_dtpBuchongDate);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.m_txtAddDiagnose);
            this.tabPage4.Controls.Add(this.m_txtChargeDoc);
            this.tabPage4.Controls.Add(this.m_txtAddDiagnoseDoctor);
            this.tabPage4.Controls.Add(this.m_cmdAddDiagnoseDoctor);
            this.tabPage4.Controls.Add(this.m_lklAddDiagnose);
            this.tabPage4.Controls.Add(this.m_dtpAddDiagnoseDate);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.m_cmdChargeDoc);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(786, 417);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Text = "诊断（二）";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // m_cltbuchong
            // 
            this.m_cltbuchong.AccessibleDescription = "补充诊断";
            this.m_cltbuchong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cltbuchong.BackColor = System.Drawing.Color.White;
            this.m_cltbuchong.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cltbuchong.ForeColor = System.Drawing.Color.Black;
            this.m_cltbuchong.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_cltbuchong.Location = new System.Drawing.Point(81, 19);
            this.m_cltbuchong.m_BlnIgnoreUserInfo = false;
            this.m_cltbuchong.m_BlnPartControl = false;
            this.m_cltbuchong.m_BlnReadOnly = false;
            this.m_cltbuchong.m_BlnUnderLineDST = false;
            this.m_cltbuchong.m_ClrDST = System.Drawing.Color.Red;
            this.m_cltbuchong.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_cltbuchong.m_IntCanModifyTime = 6;
            this.m_cltbuchong.m_IntPartControlLength = 0;
            this.m_cltbuchong.m_IntPartControlStartIndex = 0;
            this.m_cltbuchong.m_StrUserID = "";
            this.m_cltbuchong.m_StrUserName = "";
            this.m_cltbuchong.Name = "m_cltbuchong";
            this.m_cltbuchong.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_cltbuchong.Size = new System.Drawing.Size(673, 178);
            this.m_cltbuchong.TabIndex = 10000168;
            this.m_cltbuchong.Tag = "12";
            this.m_cltbuchong.Text = "";
            // 
            // m_txtBuchongDoctor
            // 
            this.m_txtBuchongDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtBuchongDoctor.Location = new System.Drawing.Point(170, 206);
            this.m_txtBuchongDoctor.Name = "m_txtBuchongDoctor";
            this.m_txtBuchongDoctor.ReadOnly = true;
            this.m_txtBuchongDoctor.Size = new System.Drawing.Size(100, 23);
            this.m_txtBuchongDoctor.TabIndex = 10000167;
            // 
            // m_cmdBuchongDoctor
            // 
            this.m_cmdBuchongDoctor.AccessibleDescription = "补充诊断";
            this.m_cmdBuchongDoctor.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdBuchongDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdBuchongDoctor.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdBuchongDoctor.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdBuchongDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBuchongDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdBuchongDoctor.Location = new System.Drawing.Point(78, 203);
            this.m_cmdBuchongDoctor.Name = "m_cmdBuchongDoctor";
            this.m_cmdBuchongDoctor.Size = new System.Drawing.Size(80, 30);
            this.m_cmdBuchongDoctor.TabIndex = 10000165;
            this.m_cmdBuchongDoctor.Text = "医师签名:";
            this.m_cmdBuchongDoctor.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.linkLabel1.Location = new System.Drawing.Point(3, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 14);
            this.linkLabel1.TabIndex = 10000163;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "补充诊断:";
            // 
            // m_dtpBuchongDate
            // 
            this.m_dtpBuchongDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpBuchongDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpBuchongDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpBuchongDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpBuchongDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpBuchongDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpBuchongDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpBuchongDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpBuchongDate.Location = new System.Drawing.Point(322, 206);
            this.m_dtpBuchongDate.m_BlnOnlyTime = false;
            this.m_dtpBuchongDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpBuchongDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpBuchongDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpBuchongDate.Name = "m_dtpBuchongDate";
            this.m_dtpBuchongDate.ReadOnly = false;
            this.m_dtpBuchongDate.Size = new System.Drawing.Size(214, 22);
            this.m_dtpBuchongDate.TabIndex = 10000164;
            this.m_dtpBuchongDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpBuchongDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(274, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10000166;
            this.label6.Text = "日期:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtAddDiagnose
            // 
            this.m_txtAddDiagnose.AccessibleDescription = "最后诊断";
            this.m_txtAddDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAddDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtAddDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAddDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtAddDiagnose.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtAddDiagnose.Location = new System.Drawing.Point(80, 242);
            this.m_txtAddDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtAddDiagnose.m_BlnPartControl = false;
            this.m_txtAddDiagnose.m_BlnReadOnly = false;
            this.m_txtAddDiagnose.m_BlnUnderLineDST = false;
            this.m_txtAddDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAddDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAddDiagnose.m_IntCanModifyTime = 6;
            this.m_txtAddDiagnose.m_IntPartControlLength = 0;
            this.m_txtAddDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtAddDiagnose.m_StrUserID = "";
            this.m_txtAddDiagnose.m_StrUserName = "";
            this.m_txtAddDiagnose.Name = "m_txtAddDiagnose";
            this.m_txtAddDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAddDiagnose.Size = new System.Drawing.Size(673, 119);
            this.m_txtAddDiagnose.TabIndex = 10000162;
            this.m_txtAddDiagnose.Tag = "12";
            this.m_txtAddDiagnose.Text = "";
            // 
            // m_txtChargeDoc
            // 
            this.m_txtChargeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtChargeDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtChargeDoc.Location = new System.Drawing.Point(656, 65);
            this.m_txtChargeDoc.Name = "m_txtChargeDoc";
            this.m_txtChargeDoc.ReadOnly = true;
            this.m_txtChargeDoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtChargeDoc.TabIndex = 10000161;
            this.m_txtChargeDoc.Visible = false;
            // 
            // m_txtAddDiagnoseDoctor
            // 
            this.m_txtAddDiagnoseDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtAddDiagnoseDoctor.Location = new System.Drawing.Point(170, 372);
            this.m_txtAddDiagnoseDoctor.Name = "m_txtAddDiagnoseDoctor";
            this.m_txtAddDiagnoseDoctor.ReadOnly = true;
            this.m_txtAddDiagnoseDoctor.Size = new System.Drawing.Size(100, 23);
            this.m_txtAddDiagnoseDoctor.TabIndex = 10000160;
            // 
            // m_cmdAddDiagnoseDoctor
            // 
            this.m_cmdAddDiagnoseDoctor.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddDiagnoseDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddDiagnoseDoctor.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddDiagnoseDoctor.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAddDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddDiagnoseDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddDiagnoseDoctor.Location = new System.Drawing.Point(78, 369);
            this.m_cmdAddDiagnoseDoctor.Name = "m_cmdAddDiagnoseDoctor";
            this.m_cmdAddDiagnoseDoctor.Size = new System.Drawing.Size(80, 30);
            this.m_cmdAddDiagnoseDoctor.TabIndex = 10000158;
            this.m_cmdAddDiagnoseDoctor.Text = "医师签名:";
            this.m_cmdAddDiagnoseDoctor.UseVisualStyleBackColor = false;
            // 
            // m_lklAddDiagnose
            // 
            this.m_lklAddDiagnose.AutoSize = true;
            this.m_lklAddDiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklAddDiagnose.Location = new System.Drawing.Point(2, 245);
            this.m_lklAddDiagnose.Name = "m_lklAddDiagnose";
            this.m_lklAddDiagnose.Size = new System.Drawing.Size(70, 14);
            this.m_lklAddDiagnose.TabIndex = 10000155;
            this.m_lklAddDiagnose.TabStop = true;
            this.m_lklAddDiagnose.Text = "最后诊断:";
            // 
            // m_dtpAddDiagnoseDate
            // 
            this.m_dtpAddDiagnoseDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpAddDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpAddDiagnoseDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpAddDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpAddDiagnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpAddDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpAddDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpAddDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAddDiagnoseDate.Location = new System.Drawing.Point(322, 373);
            this.m_dtpAddDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpAddDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpAddDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.Name = "m_dtpAddDiagnoseDate";
            this.m_dtpAddDiagnoseDate.ReadOnly = false;
            this.m_dtpAddDiagnoseDate.Size = new System.Drawing.Size(214, 22);
            this.m_dtpAddDiagnoseDate.TabIndex = 10000156;
            this.m_dtpAddDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpAddDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(274, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000159;
            this.label1.Text = "日期:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdChargeDoc
            // 
            this.m_cmdChargeDoc.AccessibleDescription = "";
            this.m_cmdChargeDoc.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdChargeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdChargeDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdChargeDoc.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdChargeDoc.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdChargeDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdChargeDoc.ForeColor = System.Drawing.Color.Black;
            this.m_cmdChargeDoc.Location = new System.Drawing.Point(572, 61);
            this.m_cmdChargeDoc.Name = "m_cmdChargeDoc";
            this.m_cmdChargeDoc.Size = new System.Drawing.Size(80, 30);
            this.m_cmdChargeDoc.TabIndex = 10000157;
            this.m_cmdChargeDoc.Text = "主治医师:";
            this.m_cmdChargeDoc.UseVisualStyleBackColor = false;
            this.m_cmdChargeDoc.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.ctlPaintContainer1);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(786, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "图片信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctlPaintContainer1
            // 
            this.ctlPaintContainer1.AutoScroll = true;
            this.ctlPaintContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ctlPaintContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlPaintContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlPaintContainer1.ForeColor = System.Drawing.Color.White;
            this.ctlPaintContainer1.Location = new System.Drawing.Point(0, 0);
            this.ctlPaintContainer1.m_BlnCanAddImage = true;
            this.ctlPaintContainer1.m_BlnScaleSize = true;
            this.ctlPaintContainer1.m_ClrcmdRubber = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrcmdSelected = System.Drawing.Color.White;
            this.ctlPaintContainer1.m_ClrgpbTools = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ctlPaintContainer1.m_ClrppgPicSize = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ctlPaintContainer1.m_ClrrdbDash = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbLine = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbPen = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbText = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_IntDefaultHeight = 253;
            this.ctlPaintContainer1.m_IntDefaultWidth = 320;
            this.ctlPaintContainer1.Name = "ctlPaintContainer1";
            this.ctlPaintContainer1.Size = new System.Drawing.Size(782, 413);
            this.ctlPaintContainer1.TabIndex = 230;
            this.ctlPaintContainer1.选择科室图片 = com.digitalwave.Utility.Controls.ctlPaintContainer.enmImageNames.无;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "听筒.ico");
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.AccessibleDescription = "摘要";
            this.m_txtSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtSummary.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSummary.Location = new System.Drawing.Point(476, 396);
            this.m_txtSummary.m_BlnIgnoreUserInfo = true;
            this.m_txtSummary.m_BlnPartControl = false;
            this.m_txtSummary.m_BlnReadOnly = true;
            this.m_txtSummary.m_BlnUnderLineDST = false;
            this.m_txtSummary.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSummary.m_IntCanModifyTime = 6;
            this.m_txtSummary.m_IntPartControlLength = 0;
            this.m_txtSummary.m_IntPartControlStartIndex = 0;
            this.m_txtSummary.m_StrUserID = "";
            this.m_txtSummary.m_StrUserName = "";
            this.m_txtSummary.Multiline = false;
            this.m_txtSummary.Name = "m_txtSummary";
            this.m_txtSummary.ReadOnly = true;
            this.m_txtSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSummary.Size = new System.Drawing.Size(104, 24);
            this.m_txtSummary.TabIndex = 24;
            this.m_txtSummary.Tag = "11";
            this.m_txtSummary.Text = "";
            this.m_txtSummary.Visible = false;
            // 
            // m_cmdAssistantDiagnose
            // 
            this.m_cmdAssistantDiagnose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAssistantDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAssistantDiagnose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAssistantDiagnose.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAssistantDiagnose.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAssistantDiagnose.Location = new System.Drawing.Point(620, 81);
            this.m_cmdAssistantDiagnose.Name = "m_cmdAssistantDiagnose";
            this.m_cmdAssistantDiagnose.Size = new System.Drawing.Size(74, 27);
            this.m_cmdAssistantDiagnose.TabIndex = 10000021;
            this.m_cmdAssistantDiagnose.Text = "辅助诊疗";
            this.m_cmdAssistantDiagnose.UseVisualStyleBackColor = false;
            this.m_cmdAssistantDiagnose.Click += new System.EventHandler(this.m_cmdAssistantDiagnose_Click);
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(704, 117);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(97, 23);
            this.txtSign.TabIndex = 10000022;
            // 
            // m_bgwGetLIS
            // 
            this.m_bgwGetLIS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetLIS_DoWork);
            this.m_bgwGetLIS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetLIS_RunWorkerCompleted);
            // 
            // frmInPatientCaseHistory_F2
            // 
            this.AccessibleDescription = "住  院  病  历 1";
            this.ClientSize = new System.Drawing.Size(832, 606);
            this.Controls.Add(this.m_pnlContent);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_txtSummary);
            this.Controls.Add(this.lblCredibility);
            this.Controls.Add(this.lblRepresentor);
            this.Controls.Add(this.m_cboRepresentor);
            this.Controls.Add(this.m_cboCredibility);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInPatientCaseHistory_F2";
            this.Text = "住  院  病  历";
            this.Load += new System.EventHandler(this.frmInPatientCaseHistory_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.m_cboCredibility, 0);
            this.Controls.SetChildIndex(this.m_cboRepresentor, 0);
            this.Controls.SetChildIndex(this.lblRepresentor, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblCredibility, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.m_txtSummary, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
            this.Controls.SetChildIndex(this.lblMarriaged, 0);
            this.Controls.SetChildIndex(this.lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_pnlContent, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picDiagnose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFamilyHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCatameniaHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarriageHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picOwnHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBeforetimeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMainDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picProfessionalCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCurrentStatus)).EndInit();
            this.m_pnlContent.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.m_grbCatamenia.ResumeLayout(false);
            this.m_grbCatamenia.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		private void m_mthInit()
		{
			m_cboCatameniaCase.SelectedIndexChanged += new EventHandler(m_cboCatameniaCase_IndexChanged);
		}

		private void m_mthEnableRichTextBox(bool p_blnEnabled)
		{
			this.m_txtBeforetimeStatus.m_BlnReadOnly= ! p_blnEnabled;
			this.m_txtBreath.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtCurrentStatus.m_BlnReadOnly=! p_blnEnabled;	
			//this.m_txtDia.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtFamilyHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtLabCheck.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMainDescription .m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMarriageHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtMedical.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtOwnHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtPrimaryDiagnose.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtProfessionalCheck.m_BlnReadOnly=! p_blnEnabled ;
			this.m_txtPulse.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtSummary.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtTemperature.m_BlnReadOnly=! p_blnEnabled;
			//this.m_txtSys.m_BlnReadOnly=! p_blnEnabled;			
			this.m_txtCatameniaHistory.m_BlnReadOnly=! p_blnEnabled;
            this.m_txtDiagnose.m_BlnReadOnly = !p_blnEnabled;
		}

		#region 增加弹出体格检查窗体,刘颖源,2003-6-2 14:53:23
		private void m_txtMedical_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void m_mthShowMedicalExam(frmMedicalExam001 p_frmMedicalExam)
		{
			p_frmMedicalExam.m_EvtHide += new EventHandler(m_mthMedicalExamHide);

			p_frmMedicalExam.TopMost = true;
			p_frmMedicalExam.Show();
		}

		private void m_mthMedicalExamHide(object sender,EventArgs e)
		{
		}

		#endregion
		#region 载入数据,刘颖源,2003-5-29 21:07:52
		private void m_mthLoadMedicalExam()
		{
		}
		#endregion

		#region OVERRIDE function
		// 获取选择已经删除记录的窗体标题
		public    override void m_strReloadFormTitle()
		{
		
		}

		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{
			//m_objSignTool.m_mthSetDefaulEmployee();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);

			m_strCurrentOpenDate = "";

			this.m_txtBeforetimeStatus.m_mthClearText();
			this.m_txtBreath.m_mthClearText();
			this.m_txtCurrentStatus.m_mthClearText();
			//this.m_txtDia.m_mthClearText();
			this.m_txtFamilyHistory.m_mthClearText();
			this.m_txtLabCheck.m_mthClearText();
			this.m_txtMainDescription .m_mthClearText();
			this.m_txtMarriageHistory.m_mthClearText();
			this.m_txtMedical.m_mthClearText();
			this.m_txtOwnHistory.m_mthClearText();
            this.m_txtDiagnose.m_mthClearText();
			this.m_txtPrimaryDiagnose.m_mthClearText();
			this.m_txtProfessionalCheck.m_mthClearText() ;
			this.m_txtPulse.m_mthClearText();
			this.m_txtSummary.m_mthClearText();
			this.m_txtTemperature.m_mthClearText();
			//this.m_txtSys.m_mthClearText();
			this.m_cboCredibility.SelectedIndex=-1;
			this.m_cboRepresentor.SelectedIndex=-1;
			this.m_txtCatameniaHistory.m_mthClearText();

			this.m_txtChargeDoc.Text = "";
            m_txtChargeDoc.Enabled = true;
			this.m_txtChargeDoc.Tag = null;
			//			this.m_txtMidwife.Text = "";
			this.m_txtDirectorDoc.Text = "";
            m_txtDirectorDoc.Enabled = true;
			this.m_txtDirectorDoc.Tag = null;

			this.m_txtModifydiagnose.m_mthClearText();
			this.m_txtAddDiagnose.m_mthClearText();
			this.m_txtModifyDiagnoseDoctor.Text="";
            m_txtModifyDiagnoseDoctor.Enabled = true;
			this.m_txtModifyDiagnoseDoctor.Tag=null;
			this.m_txtAddDiagnoseDoctor.Text="";
            m_txtAddDiagnoseDoctor.Enabled = true;
			this.m_txtAddDiagnoseDoctor.Tag=null;
            this.m_txtBuchongDoctor.Text = "";
            this.m_cltbuchong.m_mthClearText();
			m_mthSetModifyControl(null,true);			
			
			m_dtpCreateDate.Enabled = true;
			m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");  
			m_dtpModifyDiagnoseDate.Value=DateTime.Now;
			m_dtpAddDiagnoseDate.Value=DateTime.Now;

			//			m_mthClearAllPic(ctlPaintContainer1);
			ctlPaintContainer1.m_mthClear();
            m_cboFirstCatamenia.Text = "";
            m_cboCatameniaLastTime.Text = "";
            m_cboCatameniaCycle.Text = "";
            m_dtpLastCatameniaTime.Value = DateTime.Now;
            m_cboCatameniaCase.Text = "";

            m_chkCatamenia.Checked = false;
            m_rdbAmeniaAge.Checked = false;
            m_rdbLastCatameniaTime.Checked = false;
            m_cboAmeniaAge.Text = string.Empty;

            m_txtPrimaryDoc.Text = string.Empty;
            m_txtPrimaryDoc.Enabled = true;
            m_txtPrimaryDoc.Tag = null;
            m_dtpPrimaryDoc.Value = DateTime.Now;
            this.m_txtDiagnosedoc.Clear();

            this.m_dtpAddDiagnoseDate.Value = DateTime.Now;
            this.m_txtWeight.Text = "";
            this.m_cboBloodPressure.Text = "";

            m_lsvLISContent.Items.Clear();
            m_txtLISContent.Clear();
		}

		protected override void m_mthClearPatientBaseInfo()
		{
			base.m_mthClearPatientBaseInfo();
			m_lblLinkMan.Text="";
			m_lblOccupation.Text="";
			m_lblMarriaged.Text="";
			m_lblCreateUserName.Text="";
			m_lblNativePlace.Text="";
			m_lblAddress.Text="";
            m_lblNation.Text = "";
		}

		protected override void m_mthUnEnableRichTextBox()
		{
			m_mthEnableRichTextBox(false);
		}

		protected override void m_mthEnableRichTextBox()
		{			
			m_mthEnableRichTextBox(true);
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		// 是否允许修改特殊记录的记录信息。
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{


		}

	

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected override clsInPatientCaseHistoryContent m_objGetContentFromGUI()
		{
			clsInPatientCaseHistoryContent m_objContent=new clsInPatientCaseHistoryContent();
			try
			{
                if (!string.IsNullOrEmpty(m_txtPrimaryDiagnose.Text) && m_txtPrimaryDoc.Tag == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("已进行初步诊断，必须有医师签名");                    
                     return null;
                }
                m_objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;

                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref m_objContent.objSignerArr, ref strUserIDList, ref strUserNameList);

				m_objContent.m_strBeforetimeStatusAll=this.m_txtBeforetimeStatus.Text ;
				m_objContent.m_strBeforetimeStatusXML=this.m_txtBeforetimeStatus.m_strGetXmlText();
				m_objContent.m_strBeforetimeStatus=this.m_txtBeforetimeStatus.m_strGetRightText()  ;

				m_objContent.m_strBreath=this.m_txtBreath.m_strGetRightText() ;
				m_objContent.m_strBreathAll=this.m_txtBreath.Text  ;
				m_objContent.m_strBreathXML=this.m_txtBreath.m_strGetXmlText()  ;
			
				m_objContent.m_strCatameniaHistory=this.m_txtCatameniaHistory.m_strGetRightText() ;
				m_objContent.m_strCatameniaHistoryAll=this.m_txtCatameniaHistory.Text  ;
				m_objContent.m_strCatameniaHistoryXML=this.m_txtCatameniaHistory.m_strGetXmlText()  ;
			
				m_objContent.m_strCredibility=this.m_cboCredibility.Text  ;
			
				m_objContent.m_strCurrentStatus=this.m_txtCurrentStatus.m_strGetRightText()  ;
				m_objContent.m_strCurrentStatusXAll=this.m_txtCurrentStatus.Text   ;
				m_objContent.m_strCurrentStatusXML=this.m_txtCurrentStatus.m_strGetXmlText()  ;
			
                //m_objContent.m_strDia=this.m_txtDia.m_strGetRightText()  ;
                //m_objContent.m_strDiaAll=this.m_txtDia.Text   ;
                //m_objContent.m_strDiaXML=this.m_txtDia.m_strGetXmlText()  ;

                //血压
                m_objContent.m_strBloodPressure = this.m_cboBloodPressure.Text;
                
                //体重
                m_objContent.m_strWeight = this.m_txtWeight.m_strGetRightText();
                m_objContent.m_strWeightAll = this.m_txtWeight.Text;
                m_objContent.m_strWeightXML = this.m_txtWeight.m_strGetXmlText();


				m_objContent.m_strFamilyHistory=this.m_txtFamilyHistory.m_strGetRightText()  ;
				m_objContent.m_strFamilyHistoryAll=this.m_txtFamilyHistory.Text   ;
				m_objContent.m_strFamilyHistoryXML=this.m_txtFamilyHistory.m_strGetXmlText()  ;
			
				m_objContent.m_strLabCheck=this.m_txtLabCheck.m_strGetRightText()  ;
				m_objContent.m_strLabCheckAll=this.m_txtLabCheck.Text   ;
				m_objContent.m_strLabCheckXML=this.m_txtLabCheck.m_strGetXmlText()  ;

				m_objContent.m_strMainDescription=this.m_txtMainDescription.m_strGetRightText()  ;
				m_objContent.m_strMainDescriptionAll=this.m_txtMainDescription.Text   ;
				m_objContent.m_strMainDescriptionXML=this.m_txtMainDescription.m_strGetXmlText()  ;
			
				m_objContent.m_strMarriageHistory=this.m_txtMarriageHistory.m_strGetRightText()  ;
				m_objContent.m_strMarriageHistoryAll=this.m_txtMarriageHistory.Text   ;
				m_objContent.m_strMarriageHistoryXML=this.m_txtMarriageHistory.m_strGetXmlText()  ;
			
				m_objContent.m_strMedical=this.m_txtMedical.m_strGetRightText()  ;
				m_objContent.m_strMedicalAll=this.m_txtMedical.Text   ;
				m_objContent.m_strMedicalXML=this.m_txtMedical.m_strGetXmlText()  ;
			
				m_objContent.m_strOwnHistory=this.m_txtOwnHistory.m_strGetRightText()  ;
				m_objContent.m_strOwnHistoryAll=this.m_txtOwnHistory.Text   ;
				m_objContent.m_strOwnHistoryXML=this.m_txtOwnHistory.m_strGetXmlText()  ;
			
				string strTemp=this.m_txtPrimaryDiagnose.m_strGetRightText().Trim();
				m_objContent.m_strPrimaryDiagnoseArr=strTemp.Split(MDIParent.c_chrSplitChars);
				m_objContent.m_strPrimaryDiagnoseAll=this.m_txtPrimaryDiagnose.Text   ;
				m_objContent.m_strPrimaryDiagnoseXML=this.m_txtPrimaryDiagnose.m_strGetXmlText()  ;
			
				m_objContent.m_strProfessionalCheck=this.m_txtProfessionalCheck.m_strGetRightText()  ;
				m_objContent.m_strProfessionalCheckAll=this.m_txtProfessionalCheck.Text   ;
				m_objContent.m_strProfessionalCheckXML=this.m_txtProfessionalCheck.m_strGetXmlText()  ;

                m_objContent.m_strPulse = this.m_txtPulse.m_strGetRightText();
				m_objContent.m_strPulseAll=this.m_txtPulse.Text   ;
				m_objContent.m_strPulseXML=this.m_txtPulse.m_strGetXmlText()  ;
			
				m_objContent.m_strRepresentor=this.m_cboRepresentor.Text  ;
			
				m_objContent.m_strSummary=this.m_txtSummary.m_strGetRightText()  ;
				m_objContent.m_strSummaryAll=this.m_txtSummary.Text   ;
				m_objContent.m_strSummaryXML=this.m_txtSummary.m_strGetXmlText()  ;
			
                //m_objContent.m_strSys=this.m_txtSys.m_strGetRightText()  ;
                //m_objContent.m_strSysAll=this.m_txtSys.Text   ;
                //m_objContent.m_strSysXML=this.m_txtSys.m_strGetXmlText()  ;
			
				m_objContent.m_strTemperature=this.m_txtTemperature.m_strGetRightText()  ;
				m_objContent.m_strTemperatureAll=this.m_txtTemperature.Text   ;
				m_objContent.m_strTemperatureXML=this.m_txtTemperature.m_strGetXmlText()  ;
			
				m_objContent.m_strFinallyDiagnoseDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                m_objContent.m_strPrimaryDiagnoseDate = m_dtpPrimaryDoc.Value.ToString("yyyy-MM-dd HH:mm:ss");

                //m_objContent.m_strDiagnoseOK = this.m_txtDiagnose.Text;
               
                //m_objContent.m_strDiagnoseAll = this.m_txtDiagnose.m_strGetRightText();
                //m_objContent.m_strDiagnosetxtXML = this.m_txtDiagnose.m_strGetXmlText();

               

                //普通诊断
                //进行判断，一旦写入诊断则要求签名 否则
                if (this.m_txtDiagnose.Text.Trim().Length != 0)
                {
                    if (this.m_txtDiagnosedoc.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("已进行诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                    m_objContent.m_dtDiagnoseDate = DateTime.Parse(this.m_dtpDiagnosedoc.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    m_objContent.m_dtDiagnoseDate = new DateTime(1900, 1, 1);
                m_objContent.m_strDiagnoseOK = this.m_txtDiagnose.Text;
                m_objContent.m_strDiagnoseAll = this.m_txtDiagnose.m_strGetRightText();
                m_objContent.m_strDiagnosetxtXML = this.m_txtDiagnose.m_strGetXmlText();
                if (this.m_txtDiagnosedoc.Tag != null)
                    m_objContent.m_strDiagnoseDoc = ((clsEmrEmployeeBase_VO)this.m_txtDiagnosedoc.Tag).m_strEMPNO_CHR;

				//修正诊断
                //进行判断，一旦写入修正诊断则要求签名 否则
                if (this.m_txtModifydiagnose.Text.Trim().Length != 0)
                {
                    if (m_txtModifyDiagnoseDoctor.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("已进行诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                    m_objContent.m_datModifyDiagnose = DateTime.Parse(m_dtpModifyDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    m_objContent.m_datModifyDiagnose = new DateTime(1900,1,1);
				    m_objContent.m_strModifyDiagnose=this.m_txtModifydiagnose.m_strGetRightText();
				    m_objContent.m_strModifyDiagnoseAll=this.m_txtModifydiagnose.Text;
				    m_objContent.m_strModifyDiagnoseXML=this.m_txtModifydiagnose.m_strGetXmlText();
				if (this.m_txtModifyDiagnoseDoctor.Tag!=null)
                    m_objContent.m_strModifyDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtModifyDiagnoseDoctor.Tag).m_strEMPNO_CHR;
                //最后诊断
                //进行判断，一旦写入补充诊断则要求签名 否则
                if (this.m_txtAddDiagnose.Text.Trim().Length != 0)
                {
                    if (m_txtAddDiagnoseDoctor.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("已进行最后诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                    m_objContent.m_datAddDiagnose = DateTime.Parse(m_dtpAddDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    m_objContent.m_datAddDiagnose = new DateTime(1900,1,1);
				    m_objContent.m_strAddDiagnose=this.m_txtAddDiagnose.m_strGetRightText();
				    m_objContent.m_strAddDiagnoseALL=this.m_txtAddDiagnose.Text;
				    m_objContent.m_strAddDiagnoseXML=this.m_txtAddDiagnose.m_strGetXmlText();
				if (this.m_txtAddDiagnoseDoctor.Tag!=null)
                    m_objContent.m_strAddDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtAddDiagnoseDoctor.Tag).m_strEMPNO_CHR;

				//主治医师
                //if (this.m_txtChargeDoc.Tag!=null)
                //    m_objContent.m_strChargeDoctor = ((clsEmrEmployeeBase_VO)this.m_txtChargeDoc.Tag).m_strEMPNO_CHR;
                ////主任医师
                //if (this.m_txtDirectorDoc.Tag!=null)
                //    m_objContent.m_strDiretDoctor = ((clsEmrEmployeeBase_VO)this.m_txtDirectorDoc.Tag).m_strEMPNO_CHR;

                m_objContent.m_strPrimaryDiagnoseDocID = (this.m_txtPrimaryDoc.Tag == null ? "" : ((clsEmrEmployeeBase_VO)this.m_txtPrimaryDoc.Tag).m_strEMPNO_CHR);
				//			m_objContent.m_strFinallyDiagnoseDocID =(m_txtFinallyDiagnoseDocID.Text =="" ? "" : (string)this.m_txtFinallyDiagnoseDocID.Tag); 
 
				m_objContent.m_strCreateName =MDIParent.OperatorName ;
                m_objContent.m_strPrimaryDiagnoseDocName = this.m_txtPrimaryDoc.Text;
                //m_objContent.m_strPrimaryDiagnoseDate = this.m_txtFinallyDiagnoseDocID.Text;

				//补充月经部分
				m_objContent.m_strFirstCatamenia =this.m_cboFirstCatamenia.Text ;
				m_objContent.m_strCatameniaLastTime =this.m_cboCatameniaLastTime.Text ;
				m_objContent.m_strCatameniaCycle =this.m_cboCatameniaCycle.Text ;
				m_objContent.m_dtmLastCatameniaTime =this.m_dtpLastCatameniaTime.Value ;
				m_objContent.m_strCatameniaCase =this.m_cboCatameniaCase.Text.Trim() ;
                m_objContent.m_intSelectedMC = m_chkCatamenia.Checked ? 1 : 0;

                m_objContent.m_intSELECTEDLASTCATAMENIATIME = m_rdbLastCatameniaTime.Checked ? 1 : 0;
                m_objContent.m_intSELECTEDAMENIAAGE = m_rdbAmeniaAge.Checked ? 1 : 0;
                m_objContent.m_strAMENIAAGE = m_cboAmeniaAge.Text;

                //补充诊断签名ID
                m_objContent.m_strBuChongDoctorID = (this.m_txtBuchongDoctor.Tag == null ? "" : ((clsEmrEmployeeBase_VO)this.m_txtBuchongDoctor.Tag).m_strEMPNO_CHR);
                //日期
                m_objContent.m_dateBuChong = DateTime.Parse(m_dtpBuchongDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objContent.m_strBuChongALL = this.m_cltbuchong.Text;
                m_objContent.m_strBuChongXML = this.m_cltbuchong.m_strGetXmlText();
                m_objContent.m_strBuChong = this.m_cltbuchong.m_strGetRightText();
                
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message,"Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			return m_objContent;

			
		}

		//		public clsPictureBoxValue[] m_objPicValueArr = null;
		protected override clsPictureBoxValue[] m_objGetPicContentFromGUI()
		{			
			return ctlPaintContainer1.m_objGetPicValue();
		}

		// 把特殊记录的值显示到界面上。
		protected override void m_mthSetGUIFromContent(clsInPatientCaseHistoryContent p_objContent,clsPictureBoxValue[] p_objPicValueArr)
		{
			ctlPaintContainer1.m_mthSetPicValue(p_objPicValueArr);

			if( p_objContent.m_strInPatientID !=null && p_objContent.m_strInPatientID !="")
			{
				m_strCurrentOpenDate = p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				m_strMedicalExam_ID ="";
			}
			this.m_txtBreath.m_mthSetNewText(p_objContent.m_strBreathAll, p_objContent.m_strBreathXML);   
			this.m_txtBeforetimeStatus.m_mthSetNewText( p_objContent.m_strBeforetimeStatusAll,p_objContent.m_strBeforetimeStatusXML); 
			this.m_txtCurrentStatus.m_mthSetNewText(p_objContent.m_strCurrentStatusXAll,p_objContent.m_strCurrentStatusXML );
			//this.m_txtDia.m_mthSetNewText(p_objContent.m_strDiaAll ,p_objContent.m_strDiaXML );
			this.m_txtFamilyHistory.m_mthSetNewText(p_objContent.m_strFamilyHistoryAll,p_objContent.m_strFamilyHistoryXML  );
			this.m_txtLabCheck.m_mthSetNewText(p_objContent.m_strLabCheckAll ,p_objContent.m_strLabCheckXML );
			this.m_txtMainDescription.m_mthSetNewText(p_objContent.m_strMainDescriptionAll ,p_objContent.m_strMainDescriptionXML );
			this.m_txtMarriageHistory.m_mthSetNewText(p_objContent.m_strMarriageHistoryAll,p_objContent.m_strMarriageHistoryXML  );
			this.m_txtMedical.m_mthSetNewText(p_objContent.m_strMedicalAll ,p_objContent.m_strMedicalXML );
			this.m_txtOwnHistory.m_mthSetNewText(p_objContent.m_strOwnHistoryAll ,p_objContent.m_strOwnHistoryXML );
			this.m_txtPrimaryDiagnose.m_mthSetNewText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.m_mthSetNewText(p_objContent.m_strProfessionalCheckAll ,p_objContent.m_strProfessionalCheckXML );
			this.m_txtPulse.m_mthSetNewText(p_objContent.m_strPulseAll ,p_objContent.m_strPulseXML );
			this.m_txtSummary.m_mthSetNewText(p_objContent.m_strSummaryAll ,p_objContent.m_strSummaryXML );
			//this.m_txtSys.m_mthSetNewText(p_objContent.m_strSysAll ,p_objContent.m_strSysXML );
			this.m_txtTemperature.m_mthSetNewText(p_objContent.m_strTemperatureAll ,p_objContent.m_strTemperatureXML );
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;
            this.m_txtDiagnose.m_mthSetNewText(p_objContent.m_strDiagnoseOK, p_objContent.m_strDiagnosetxtXML);
            this.m_txtWeight.m_mthSetNewText(p_objContent.m_strWeightAll, p_objContent.m_strWeightXML);
            this.m_cboBloodPressure.Text = p_objContent.m_strBloodPressure;
            m_chkCatamenia.Enabled = true;
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {                
                this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
			    this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
			    this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
			    this.m_cboCatameniaCycle.Text =p_objContent.m_strCatameniaCycle ;
                //if(!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                //    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
			    this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                //if(m_cboCatameniaCase.Text.Equals("已绝经"))
                //    this.m_dtpLastCatameniaTime.Enabled = false;

                if (p_objContent.m_intSELECTEDAMENIAAGE == 1)
                {
                    m_cboAmeniaAge.Text = p_objContent.m_strAMENIAAGE;
                    m_rdbAmeniaAge.Checked = true;
                }
                else if (p_objContent.m_intSELECTEDLASTCATAMENIATIME == 1)
                {
                    if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                    {
                        this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                    }
                    m_rdbLastCatameniaTime.Checked = true;
                }
            }
            this.m_cltbuchong.m_mthSetNewText(p_objContent.m_strBuChongALL, p_objContent.m_strBuChongXML);
            this.m_txtModifydiagnose.m_mthSetNewText(p_objContent.m_strModifyDiagnoseAll, p_objContent.m_strModifyDiagnoseXML);
            this.m_txtAddDiagnose.m_mthSetNewText(p_objContent.m_strAddDiagnoseALL, p_objContent.m_strAddDiagnoseXML);
			try
			{
                if (p_objContent.m_datModifyDiagnose == new DateTime(1900, 1, 1) || this.m_txtModifydiagnose.Text == "")
                    this.m_dtpModifyDiagnoseDate.Value = DateTime.Now; 
                else
                    this.m_dtpModifyDiagnoseDate.Value = p_objContent.m_datModifyDiagnose;
                if (p_objContent.m_datAddDiagnose == new DateTime(1900, 1, 1) || this.m_txtAddDiagnose.Text == "")
                    this.m_dtpModifyDiagnoseDate.Value = DateTime.Now;
                else
				    this.m_dtpAddDiagnoseDate.Value=p_objContent.m_datAddDiagnose;

                 if (p_objContent.m_dateBuChong == new DateTime(1900, 1, 1) || this.m_cltbuchong.Text == "")
                    this.m_dtpBuchongDate.Value = DateTime.Now;
                else
				    this.m_dtpBuchongDate.Value=p_objContent.m_dateBuChong;
			}
			catch(Exception ex)
			{
			}
            try
            {
                if (string.IsNullOrEmpty(p_objContent.m_strPrimaryDiagnoseDate) || DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate) == new DateTime(1900, 1, 1) || this.m_txtPrimaryDiagnose.Text == "")
                    this.m_dtpPrimaryDoc.Value = DateTime.Now;
                else
                    this.m_dtpPrimaryDoc.Value = DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate);
            }
            catch { }
            try
            {
                if ((string.IsNullOrEmpty(p_objContent.m_dtDiagnoseDate.ToString())) || p_objContent.m_dtDiagnoseDate == new DateTime(1900, 1, 1) || (string.IsNullOrEmpty(this.m_txtDiagnose.Text)))
                    this.m_dtpDiagnosedoc.Value = DateTime.Now;
                else
                    this.m_dtpDiagnosedoc.Value = p_objContent.m_dtDiagnoseDate;
                }
            catch
            { }

            #region 签名赋值
                m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, m_txtModifyDiagnoseDoctor, m_txtAddDiagnoseDoctor, m_txtDirectorDoc, m_txtChargeDoc, m_txtPrimaryDoc, m_txtDiagnosedoc, m_txtBuchongDoctor },
                new string[] { p_objContent.m_strCreateUserID, p_objContent.m_strModifyDiagnoseDoctorID, p_objContent.m_strAddDiagnoseDoctorID, p_objContent.m_strDiretDoctor, p_objContent.m_strChargeDoctor, p_objContent.m_strPrimaryDiagnoseDocID, p_objContent.m_strDiagnoseDoc, p_objContent.m_strBuChongDoctorID },

                new bool[] { false, true, true, true, true, true, true, true });
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

            #endregion
			
		}

		// 获取病程记录的领域层实例
		protected override clsBaseCaseHistoryDomain  m_objGetDomain()
		{
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.InPatientCaseHistory);
		}

		// 把选择时间记录内容重新整理为完全正确的内容。
		protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
		{
		
		}		

		protected override void m_mthHandleAddRecordSucceed()
		{
			if(trvTime.SelectedNode != null)
				trvTime.SelectedNode.Tag =(string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") ;
		}
		
		//审核
		protected override string m_StrCurrentOpenDate
		{
			get
			{
                //if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
                //{
                //    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                //    return "";
                //}
                //return (string)this.trvTime.SelectedNode.Tag;
                if (string.IsNullOrEmpty(m_strCurrentOpenDate))
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return string.Empty;
                }
                return m_strCurrentOpenDate;
			}
		}

		protected override bool m_BlnCanApprove
		{
			get
			{
				return true;
			}
		}		
		//~审核
		protected override void m_mthSetNewRecord()
		{
			if(m_objCurrentPatient != null)
			{			
				//签名默认值
//				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtPrimaryDiagnoseDocID);
//				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtFinallyDiagnoseDocID);

				//默认值 m_IntCurCase
				new clsDefaultValueTool(this,m_objCurrentPatient).m_mthSetDefaultValue();
				//				new clsDefaultValueTool(m_objMedicalExamForm).m_mthSetDefaultValue();

				clsThreeMeasureShareDomain.stuFirstValue stuValue;
				long lngRes = m_objShareDomain.m_lngGetFirstValue(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),out stuValue);
                if (m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
                {
                    m_chkCatamenia.Checked = false;
                    m_chkCatamenia.Enabled = false;
                }
                else
                {
                    m_chkCatamenia.Enabled = true;
                    m_chkCatamenia.Checked = true;
                }
				if(lngRes > 0)
				{
					m_txtTemperature.Text = stuValue.m_strTemperatureValue;
					m_txtPulse.Text = stuValue.m_strPulseValue;
					m_mthSyncPluse(null,EventArgs.Empty);
					m_txtBreath.Text = stuValue.m_strBreathValue;
                    
                    //try
                    //{
                    //    if (stuValue.m_strSystolicValue != "")
                    //    {
                    //        if (stuValue.m_strSystolicValue != "" || stuValue.m_strSystolicValue != null)
                    //        {
                    //            m_strSys.Text = float.Parse(stuValue.m_strSystolicValue).ToString("0");
                    //        }
                    //        if (stuValue.m_strDiastolicValue != "" || stuValue.m_strDiastolicValue != null)
                    //        {
                    //            m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue).ToString("0");
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (stuValue.m_strSystolicValue2 != "" || stuValue.m_strSystolicValue2 != null)
                    //        {
                    //            m_txtSys.Text = float.Parse(stuValue.m_strSystolicValue2).ToString("0");
                    //        }
                    //        if (stuValue.m_strDiastolicValue2 != "" || stuValue.m_strDiastolicValue != null)
                    //        {
                    //            m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue2).ToString("0");
                    //        }
                    //    }
                    //}
                    //catch
                    //{
                    //}
		
				}

				//设完默认值后回到光标床号
				m_txtBedNO.Focus();

			}
		}

		protected override void m_mthLoadRecord(string p_strInPatientDate, string p_strOpenDate)
		{
			m_mthSetSelectedRecord(m_objCurrentPatient);
		}

		protected override long m_lngSubAddNewRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
		{
			clsMedicalExamInHospital_TargetValue objMedicalExamInHopital=new clsMedicalExamInHospital_TargetValue ();
			objMedicalExamInHopital.m_strInPatientDate =p_objNewContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strInPatientID =p_objNewContent.m_strInPatientID ;
			objMedicalExamInHopital.m_strItemID = "1";
			objMedicalExamInHopital.m_strMedicalExam_ID ="";
			objMedicalExamInHopital.m_strModifyDate =p_objNewContent.m_dtmModifyDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strOpenDate =p_objNewContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"); 
			return 1;
		}

		protected override long m_lngSubModifyRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
		{
			clsMedicalExamInHospital_TargetValue objMedicalExamInHopital=new clsMedicalExamInHospital_TargetValue ();
			objMedicalExamInHopital.m_strInPatientDate =p_objNewContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strInPatientID =p_objNewContent.m_strInPatientID ;
			objMedicalExamInHopital.m_strItemID = "1";
			objMedicalExamInHopital.m_strMedicalExam_ID =m_strMedicalExam_ID.Trim () ;
			objMedicalExamInHopital.m_strModifyDate =p_objNewContent.m_dtmModifyDate.ToString ("yyyy-MM-dd HH:mm:ss");
			objMedicalExamInHopital.m_strOpenDate =p_objNewContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"); 
			return 1;
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			clsInPatientCaseHistoryContent p_objContent=new clsInPatientCaseHistoryContent();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue)
			{
				m_strMedicalExam_ID ="";
				return ;
			}
		
			long lngRes=m_objGetDomain().m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"),out p_objContent);
			if(lngRes<=0 || p_objContent==null)
			{
				switch(lngRes)
				{
					case (long)(iCareData.enmOperationResult.Not_permission) :
						m_mthShowNotPermitted();break;
					case (long)(iCareData.enmOperationResult.DB_Fail) :
						m_mthShowDBError();break;
				}
				return;
			}
						
			this.m_txtBreath.Text=p_objContent.m_strBreath;   
			this.m_txtBeforetimeStatus.Text= p_objContent.m_strBeforetimeStatus; 
			this.m_txtCurrentStatus.Text=p_objContent.m_strCurrentStatus;
			//this.m_txtDia.Text=p_objContent.m_strDia;
			this.m_txtFamilyHistory.Text=p_objContent.m_strFamilyHistory;
			this.m_txtLabCheck.Text=p_objContent.m_strLabCheck;
			this.m_txtMainDescription.Text=p_objContent.m_strMainDescription;
			this.m_txtMarriageHistory.Text=p_objContent.m_strMarriageHistory;
			this.m_txtMedical.Text=p_objContent.m_strMedical;
			this.m_txtOwnHistory.Text=p_objContent.m_strOwnHistory;
			this.m_txtPrimaryDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.Text=p_objContent.m_strProfessionalCheck;
			this.m_txtPulse.Text=p_objContent.m_strPulse;
			this.m_txtSummary.Text=p_objContent.m_strSummary;
			//this.m_txtSys.Text=p_objContent.m_strSys;
			this.m_txtTemperature.Text=p_objContent.m_strTemperature;
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
            this.m_cboRepresentor.Text = p_objContent.m_strRepresentor;
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {
                this.m_txtCatameniaHistory.Text = p_objContent.m_strCatameniaHistory;
                this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                if (m_cboCatameniaCase.Text.Equals("已绝经"))
                    this.m_dtpLastCatameniaTime.Enabled = false;
            }
			if(p_objContent.m_strChargeDoctor != null && p_objContent.m_strChargeDoctor != string.Empty)
			{
				clsEmployee objEmpCharge = new clsEmployee(p_objContent.m_strChargeDoctor);
				this.m_txtChargeDoc.Text = objEmpCharge.m_StrLastName;
				this.m_txtChargeDoc.Tag = objEmpCharge;
			}
			if(p_objContent.m_strDiretDoctor != null && p_objContent.m_strDiretDoctor !=string.Empty)
			{
				clsEmployee objEmpDir = new clsEmployee(p_objContent.m_strDiretDoctor);
				this.m_txtDirectorDoc.Text = objEmpDir.m_StrLastName;
				this.m_txtDirectorDoc.Tag = objEmpDir;
			}		
		}

		public	  override int m_IntFormID
		{
			get
			{
				return 19;
			}
		}

		#endregion override function
		
		#region 添加键盘快捷键

		private byte m_bytListOnDoctor;
		/// <summary>
		/// 是否处理医生的TextChanged事件
		/// </summary>
		private bool m_blnCanDoctorTextChanged;

		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
            {//F1 112  帮助, F2 113 Save，F3  114 Print，F4 115 Del，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					break;

				case 38:
				case 40:
				
					break;	

				
				case 113://save
					this.m_lngSave(); 
					break;
				case 114://print
					this.m_lngPrint();
					break;
				case 115://del
					this.m_lngDelete(); 
					break;
				case 116://refresh
					m_mthClearAll();
					m_mthClearPatientBaseInfo();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion
	


		private string strGetFilePathHeader()//提取文件绝对路径的上级目录,Jacky-2002-11-30
		{
			string [] strFilePathAll =  Application.ExecutablePath.Split('\\') ;
			string strFilePathHeader="";
			if(strFilePathAll!=null)
				for(int i=0;i<strFilePathAll.Length-3;i++)
					strFilePathHeader+=strFilePathAll[i]+"\\\\";
			return strFilePathHeader;
		}
        
		private void m_cboCatameniaCase_IndexChanged(object sender,EventArgs e)
		{
			m_dtpLastCatameniaTime.Enabled = !m_cboCatameniaCase.Text.Trim().Equals("已绝经");
		}
		
		private void m_cmdGetDovueData_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient==null)return;

//			this.m_txtTemperature.Text="";
//			this.m_txtPulse.Text="";
//			this.m_txtBreath.Text="";
//			this.m_txtSys.Text="";
//			this.m_txtDia.Text="";

			clsTrendDomain objDomain=new clsTrendDomain();
			string[] strEMFC_IDArr=new string[]{"100","40","92","89","90"};//体温，脉搏，呼吸，收缩压，舒张压
			string[] strResultArr;
			long lngRes=objDomain.m_lngGetDocvueResultArr(this.m_objBaseCurrentPatient.m_StrInPatientID,this.m_objBaseCurrentPatient.m_DtmLastInDate,strEMFC_IDArr,m_dtpCreateDate.Value,out strResultArr);
			if(lngRes<=0)
			{
				switch(lngRes)
				{
					case (long)(iCareData.enmOperationResult.Not_permission) :
						m_mthShowNotPermitted();break;
					case (long)(iCareData.enmOperationResult.DB_Fail) :
						m_mthShowDBError();break;
				}
			}
			else 
			{
				if(strResultArr[0]!= null)
				{
					this.m_txtTemperature.Text=strResultArr[0];
				}
				if(strResultArr[1]!=null)
				{
					this.m_txtPulse.Text=strResultArr[1];
				}

				if(strResultArr[2]!=null)
				{
					this.m_txtBreath.Text=strResultArr[2];
				}
                //if(strResultArr[3]!=null)
                //{
                //    this.m_txtSys.Text=strResultArr[3];
                //}
                //if(strResultArr[4]!=null )
                //{
                //    this.m_txtDia.Text=strResultArr[4];
                //}
			}
		}

		private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pnlFocus.Location = new Point(e.X - 10,e.Y - 10);
			pnlFocus.Focus();
		}

		private void m_chkCatamenia_CheckedChanged(object sender, System.EventArgs e)
		{
			m_mthEnableCatamenia(m_chkCatamenia.Checked);
		}

		private void m_mthSyncPluse(object sender,EventArgs e)// 脉搏与心率一致
		{
			int intIndex1 = m_txtMedical.Text.IndexOf("心率");
			if(intIndex1>0)
			{
				int intIndex2 = m_txtMedical.Text.IndexOf("次",intIndex1);
				if(intIndex2 - intIndex1 > 2)
				{
					m_txtMedical.m_mthDeleteText(intIndex2-intIndex1-2,intIndex1+2);
				}
				m_txtMedical.m_mthInsertText(m_txtPulse.Text.Trim(),intIndex1+2);

				m_txtBreath.Focus();
			}
		}

		private void frmInPatientCaseHistory_Load(object sender, System.EventArgs e)
		{
            //m_mthfrmLoad();
			TreeNode tndInPatientDate=new TreeNode();
			tndInPatientDate.Text ="入院日期";
			this.trvTime.Nodes.Add(tndInPatientDate); 
			m_mthSetQuickKeys();

			m_dtpCreateDate.m_EnmVisibleFlag  = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			m_dtpCreateDate.m_mthResetSize();

			m_txtMainDescription.Focus();
			new clsPublicFunction().m_mthSetControlEnter2Tab(new Control[]{m_txtTemperature,m_txtPulse,m_txtBreath,m_cboBloodPressure,m_txtWeight,m_txtMainDescription});
		}

		#region 隐藏控制
		
		/// <summary>
		/// 设置月经生育史可不可用
		/// </summary>
		/// <param name="p_blnIfEnable"></param>
		private void m_mthEnableCatamenia(bool p_blnIfEnable)
		{
			m_grbCatamenia.Enabled = p_blnIfEnable;
			if(!p_blnIfEnable)
			{
				m_txtCatameniaHistory.m_mthClearText();
				this.m_cboFirstCatamenia.Text = "";
				this.m_cboCatameniaLastTime.Text = "";
				this.m_cboCatameniaCycle.Text ="" ;
				this.m_cboCatameniaCase.Text = "";
			}
			else
			{
				m_txtCatameniaHistory.m_BlnReadOnly = false;
				this.m_cboFirstCatamenia.Text = "14岁";
				this.m_cboCatameniaLastTime.Text = "5-6天";
				this.m_cboCatameniaCycle.Text ="28-30天" ;
				this.m_cboCatameniaCase.Text = "经量正常";
				this.m_txtCatameniaHistory.Text = "G1P1，一男一女，健康";
			}
		}

		/// <summary>
		/// 隐藏项目
		/// </summary>
		/// <param name="p_txtItem"></param>
		private void m_mthHideItem(com.digitalwave.controls.ctlRichTextBox p_txtItem,Label p_lblItem)
		{
			p_txtItem.m_mthClearText();
			p_txtItem.Visible = false;
			p_lblItem.Visible = false;
            //m_objBorderTool.m_mthUnChangedControlBorder(p_txtItem);

			int intVSpace = p_txtItem.Bottom - p_lblItem.Top+8;
			foreach(Control ctlSub in m_pnlContent.Controls)
				if(ctlSub.Top > p_txtItem.Top)
					ctlSub.Top -= intVSpace;
			m_pnlContent.Height -= intVSpace;
		}

		#endregion	

		private void m_mthInvokeTemplate(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_objValue)
		{
			frmInvokeTemplateByICD10 frmTemp=new frmInvokeTemplateByICD10(p_objValue,this,true,m_txtPrimaryDiagnose);
			frmTemp.ShowDialog();
		}

		private void m_cmdAssistantDiagnose_Click(object sender, System.EventArgs e)
		{
			if(m_objCurrentPatient==null)
				return;
			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind=new clsBindICD10();
			com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] objIcd10inf=null;
			m_objIcd10Bind.m_mthICD10FZZD(m_txtPrimaryDiagnose,1,1,m_objCurrentPatient.m_StrInPatientID,(m_objCurrentPatient.m_DtmSelectedInDate).ToString(),ref objIcd10inf);
			if(objIcd10inf!=null)
				m_mthInvokeTemplate(objIcd10inf);

//			frmInvokeTemplateByICD10 frmTemp=new frmInvokeTemplateByICD10();
//			frmTemp.Show();

		
		}

		#region 调用模板
        private void m_mth(com.digitalwave.controls.ctlRichTextBox p_ctlSource)
		{
            iCare.CustomForm.clsExteriorFunctionInterface.m_ObjUserInfo = clsEMRLogin.LoginInfo;
            iCare.CustomForm.clsExteriorFunctionInterface.s_ObjCurrentPatient = MDIParent.s_ObjCurrentPatient;
            int intSelectedStart = (p_ctlSource.SelectionStart < 0 ? p_ctlSource.Text.Length : p_ctlSource.SelectionStart);
            using (iCare.CustomForm.frmTextTemplate frm = new iCare.CustomForm.frmTextTemplate(p_ctlSource, this.Name, p_ctlSource.Name, intSelectedStart, m_dtmCreatedDate))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m_arlMinElementColValue.AddRange((clsMinElementValues[])frm.m_ArlTextTemplate.ToArray(typeof(clsMinElementValues)));
                }
            }
		}
		#endregion 调用模板

		private void m_lklMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel lnklb=(LinkLabel)sender;
			switch(lnklb.Name.ToString())
			{
                case "":
                    m_mth(null);
                    break;
				case "m_lklMain":
					m_mth(m_txtMainDescription);
					break;
				case "m_lklCurrentStatus":
					m_mth(m_txtCurrentStatus);
					break;
				case "m_lklBeforetimeStatus":
					m_mth(m_txtBeforetimeStatus);
					break;
				case "m_lklOwnHistory":
					m_mth(m_txtOwnHistory);
					break;
				case "m_lklMarriageHistory":
					m_mth(m_txtMarriageHistory);
					break;
				case "m_lklFamilyHistory":
					m_mth(m_txtFamilyHistory);
					break;
//				case "linkLabel_txtCatameniaHistory":
//					m_mth(m_txtCatameniaHistory);
//					break;
				case "m_lklMedical":
					m_mth(m_txtMedical);
					break;
				case "m_lklProfessionalCheck":
					m_mth(m_txtProfessionalCheck);
					break;

                case "m_lbDiagnose":
                    m_mth(m_txtDiagnose);
                    break;
				case "m_lklLabCheck":
					m_mth(m_txtLabCheck);
					break;
				case "m_lklPrimaryDiagnose":
					m_mth(m_txtPrimaryDiagnose);
                    break;
                case "m_lklModifydiagnose":
                    m_mth(m_txtModifydiagnose);
                    break;
                case "m_lklAddDiagnose":
                    m_mth(m_txtAddDiagnose);
                    break;

			}
		
		}
        
        #region 限制只能输入数字
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubAddNew()
        {
            if (!m_blnCheckIsNum())
            {
                return 99;
            }
            return base.m_lngSubAddNew();
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubModify()
        {
            if (!m_blnCheckIsNum())
            {
                return 99;
            }
            return base.m_lngSubModify();
        }

        /// <summary>
        /// 通过正则表达式判断
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckIsNum()
        {
            string RegexText = @"^(-?\d+)(\.\d+)?$";
            //if (this.m_txtSys.Text.Trim() != string.Empty && this.m_txtSys.m_strGetRightText() != string.Empty)
            //{
            //    if (!Regex.IsMatch(this.m_txtSys.m_strGetRightText(), RegexText))
            //    {
            //        clsPublicFunction.ShowInformationMessageBox("体格检查中的"
            //            +this.m_txtSys.AccessibleDescription
            //            +"须为数字！");
            //        return false;
            //    }
            //}
            //if (this.m_txtDia.Text.Trim() != string.Empty && this.m_txtDia.m_strGetRightText() != string.Empty)
            //{
            //    if (!Regex.IsMatch(this.m_txtDia.m_strGetRightText(), RegexText))
            //    {
            //        clsPublicFunction.ShowInformationMessageBox("体格检查中的"
            //            + this.m_txtDia.AccessibleDescription
            //            + "须为数字！");
            //        return false;
            //    }
            //}
            if (this.m_txtWeight.Text.Trim() != string.Empty && this.m_txtWeight.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtWeight.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        + this.m_txtWeight.AccessibleDescription
                        + "须为数字！");
                    return false;
                }
            }
            if (this.m_txtBreath.Text.Trim() != string.Empty && this.m_txtBreath.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtBreath.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        + this.m_txtBreath.AccessibleDescription
                        + "须为数字！");
                    return false;
                }
            }
            if (this.m_txtTemperature.Text.Trim() != string.Empty && this.m_txtTemperature.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtTemperature.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        + this.m_txtTemperature.AccessibleDescription
                        + "须为数字！");
                    return false;
                }
            }
            if (this.m_txtPulse.Text.Trim() != string.Empty && this.m_txtPulse.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtPulse.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        + this.m_txtPulse.AccessibleDescription
                        + "须为数字！");
                    return false;
                }
            }
            return true;
        } 
        #endregion

        protected override void trvTime_AfterSelect(object sender, TreeViewEventArgs e)
        {
            base.trvTime_AfterSelect(sender, e);

            if (m_objBaseCurrentPatient != null && m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
            {
                m_chkCatamenia.Checked = false;
                m_chkCatamenia.Enabled = false;
            }
            else
            {
                m_chkCatamenia.Enabled = true;
                m_chkCatamenia.Checked = true;
            }
        }

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            base.m_mthPerformSessionChanged(p_objSelectedSession, p_intIndex);
            if (m_objBaseCurrentPatient != null)
            {
                if (m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
                {
                    m_chkCatamenia.Checked = false;
                    m_chkCatamenia.Enabled = false;
                }
                if (m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrMarried == "未婚")
                {
                    m_txtMarriageHistory.Enabled = true;
                    m_lklMarriageHistory.Enabled = true;
                }
                else
                {
                    m_txtMarriageHistory.Enabled = true;
                    m_lklMarriageHistory.Enabled = true;
                }
            }

            if (m_lsvLISContent.Items.Count == 0 && m_ObjCurrentEmrPatient != null && !m_bgwGetLIS.IsBusy)
            {
                m_bgwGetLIS.RunWorkerAsync();
            }
        }

        private void m_rdbLastCatameniaTime_CheckedChanged(object sender, EventArgs e)
        {
            m_dtpLastCatameniaTime.Enabled = m_rdbLastCatameniaTime.Checked;
        }

        private void m_rdbAmenia_CheckedChanged(object sender, EventArgs e)
        {
            m_cboAmeniaAge.Enabled = m_rdbAmeniaAge.Checked;
        }

        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        //private void m_mthfrmLoad()
        //{
        //    if (m_pdcPrintDocument == null)
        //        this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
        //    this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
        //    this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
        //    this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        //}
        protected override void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        }

        protected override void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        protected override void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }

        private bool m_blnHasInitPrintTool = false;
        clsInPatientCaseHistory_F2PrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new clsInPatientCaseHistory_F2PrintTool();
                objPrintTool.m_mthInitPrintTool(null);
                m_blnHasInitPrintTool = true;
            }
            //objPrintTool.m_mthSetOutDateValue(m_dtmOutHospitalDate);
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
                frmPrintPreviewDialogPF ppdPrintPreview = new frmPrintPreviewDialogPF();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //if (ppdPrintPreview == null)
                //    this.ppdPrintPreview = new System.Drawing.Printing.PrintDocument();
                ppdPrintPreview.m_evtBeginPrint += new PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
                ppdPrintPreview.m_evtEndPrint += new PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
                ppdPrintPreview.m_evtPrintFrame += new PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
       
                ppdPrintPreview.ShowDialog();
            }
        }

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }

        #endregion 外部打印.

        #region 作废重做
        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsInPatientCaseHistoryContent p_objContent = new clsInPatientCaseHistoryContent();

                long lngRes = m_objGetDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                if (lngRes <= 0 || p_objContent == null)
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
                this.m_txtBreath.Text = p_objContent.m_strBreath;
                this.m_txtBeforetimeStatus.Text = p_objContent.m_strBeforetimeStatus;
                this.m_txtCurrentStatus.Text = p_objContent.m_strCurrentStatus;
                //this.m_txtDia.Text = p_objContent.m_strDia;
                this.m_txtFamilyHistory.Text = p_objContent.m_strFamilyHistory;
                //this.m_txtFinallyDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strFinallyDiagnoseAll, p_objContent.m_strFinallyDiagnoseXML);
                this.m_txtLabCheck.Text = p_objContent.m_strLabCheck;
                this.m_txtMainDescription.Text = p_objContent.m_strMainDescription;
                this.m_txtMarriageHistory.Text = p_objContent.m_strMarriageHistory;
                this.m_txtMedical.Text = p_objContent.m_strMedical;
                this.m_txtOwnHistory.Text = p_objContent.m_strOwnHistory;
                this.m_txtPrimaryDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strPrimaryDiagnoseAll, p_objContent.m_strPrimaryDiagnoseXML);
                this.m_txtProfessionalCheck.Text = p_objContent.m_strProfessionalCheck;
                this.m_txtPulse.Text = p_objContent.m_strPulse;
                this.m_txtSummary.Text = p_objContent.m_strSummary;
                //this.m_txtSys.Text = p_objContent.m_strSys;
                this.m_txtTemperature.Text = p_objContent.m_strTemperature;
                this.m_cboCredibility.Text = p_objContent.m_strCredibility;
                this.m_cboRepresentor.Text = p_objContent.m_strRepresentor;
                m_txtDiagnose.Text = p_objContent.m_strDiagnoseOK;
                m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
                if (m_chkCatamenia.Checked)
                {
                    this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
                    this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                    this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                    this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                    this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;

                    if (p_objContent.m_intSELECTEDAMENIAAGE == 1)
                    {
                        m_cboAmeniaAge.Text = p_objContent.m_strAMENIAAGE;
                        m_rdbAmeniaAge.Checked = true;
                    }
                    else if (p_objContent.m_intSELECTEDLASTCATAMENIATIME == 1)
                    {
                        if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                        {
                            this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                        }
                        m_rdbLastCatameniaTime.Checked = true;
                    }
                }
                this.m_txtModifydiagnose.Text = p_objContent.m_strModifyDiagnose;
                this.m_txtAddDiagnose.Text = p_objContent.m_strAddDiagnose;
			
                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsInPatientCaseHistory_F2PrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_InPatientCaseHistory objPrintInfo = new clsPrintInfo_InPatientCaseHistory();
                objPrintInfo.m_strInPatentID = m_objBaseCurrentPatient.m_StrInPatientID;
                objPrintInfo.m_strPatientName = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
                objPrintInfo.m_strSex = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrSex;
                objPrintInfo.m_strAge = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objPrintInfo.m_strBedName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
                objPrintInfo.m_strDeptName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName;
                objPrintInfo.m_strAreaName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName;
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;

                objPrintInfo.m_strBirthplace = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrBirthPlace;//出生地
                objPrintInfo.m_strNativePlace = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrNativePlace;//籍贯
                objPrintInfo.m_strOccupation = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;//职业
                objPrintInfo.m_strMarried = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrMarried;//婚否
                objPrintInfo.m_StrLinkManFirstName = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;//联系人
                objPrintInfo.m_strNationality = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrNation;//民族
                objPrintInfo.m_strHomePhone = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrLinkManPhone;//电话
                objPrintInfo.m_strHomeAddress = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;//地址

                objPrintInfo.m_strHISInPatientID = m_objBaseCurrentPatient.m_StrHISInPatientID;
                objPrintInfo.m_dtmHISInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedHISInDate;
                clsInPatientCaseHistoryContent objContent = null;
                long lngRes = m_objGetDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_blnIsFirstPrint = false;
                objPrintTool.m_mthSetPrintContent(objPrintInfo);

                //m_mthStartPrint();

                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

   

        //protected override infPrintRecord m_objGetPrintTool()
        //{
        //    return new clsSubDiseaseTrackPrintTool();
        //}
        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;
            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做

        #region 获取检验检查内容
        private void m_bgwGetLIS_DoWork(object sender, DoWorkEventArgs e)
        {
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objA =
               (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));

            com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO[] LisVO = null;
            objA.m_lngGetResultInfo(null, m_ObjCurrentEmrPatient.m_strEMRInPatientID, m_ObjCurrentEmrPatient.m_dtmEMRInDate.ToString(), null, out LisVO);
            e.Result = LisVO;
        }

        private void m_bgwGetLIS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO[] LisVO = e.Result as com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO[];
            if (LisVO == null || LisVO.Length == 0)
            {
                return;
            }

            ListViewItem lv = null;
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO AMVO = null;
            for (int i = 0; i < LisVO.Length; i++)
            {
                AMVO = LisVO[i].m_objApp;
                if (AMVO != null)
                {
                    lv = new ListViewItem(AMVO.m_strCheckContent);
                    lv.Tag = LisVO[i];
                    this.m_lsvLISContent.Items.Add(lv);
                }
            }
        }

        private void m_lsvLISContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_txtLISContent.Clear();

            if (this.m_lsvLISContent.SelectedItems.Count <= 0)
            {
                return;
            }
            com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO obj = this.m_lsvLISContent.SelectedItems[0].Tag as com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO;
            if (obj == null)
            {
                return;
            }

            com.digitalwave.iCare.ValueObject.clsCheckResult_VO[] CRVO = obj.m_objResults;
            if (CRVO != null)
            {
                System.Text.StringBuilder stbLis = new System.Text.StringBuilder(100);
                for (int i = 0; i < CRVO.Length; i++)
                {
                    if (CRVO[i] == null)
                        continue;

                    stbLis.Append(CRVO[i].m_strCheck_Item_Name);
                    stbLis.Append(CRVO[i].m_strResult);
                    stbLis.Append(CRVO[i].m_strUnit);
                    if (i < CRVO.Length - 1)
                    {
                        stbLis.Append(Environment.NewLine);
                    }
                }
                m_txtLISContent.Text = stbLis.ToString();
            }
        }

        private void m_cmdUseAllContent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_txtLISContent.Text))
            {
                m_txtLabCheck.m_mthInsertText(Environment.NewLine + m_txtLISContent.Text + Environment.NewLine, m_txtLISContent.SelectionStart);
            }
        }

        private void m_cmdUseSelectedContent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_txtLISContent.SelectedText))
            {
                m_txtLabCheck.m_mthInsertText(Environment.NewLine + m_txtLISContent.SelectedText + Environment.NewLine, m_txtLISContent.SelectionStart);
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("未选择任何内容");
            }
        }

        private void m_cmdSeeCheckResult_Click(object sender, EventArgs e)
        {
            if (m_ObjCurrentEmrPatient == null)
            {
                return;
            }

            com.digitalwave.iCare.gui.HIS.frmShowReports objfrmSR = new com.digitalwave.iCare.gui.HIS.frmShowReports();
            objfrmSR.InHospitalNO = m_ObjCurrentEmrPatient.m_strINPATIENTID_CHR.Trim();
            objfrmSR.PatientName = m_ObjCurrentEmrPatient.m_strLASTNAME_VCHR.Trim();
            objfrmSR.PatientSex = m_ObjCurrentEmrPatient.m_strSEX_CHR.Trim();
            objfrmSR.PatientAge = m_ObjCurrentEmrPatient.m_strMARRIED_CHR.Trim();
            objfrmSR.ShowDialog();
        }        
        #endregion

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
        
	}
	
}

