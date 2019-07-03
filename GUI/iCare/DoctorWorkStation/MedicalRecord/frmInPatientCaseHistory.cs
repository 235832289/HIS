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
	public class frmInPatientCaseHistory : iCare.frmBaseCaseHistory
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
		protected com.digitalwave.controls.ctlRichTextBox m_txtCurrentStatus;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBeforetimeStatus;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOwnHistory;
		protected System.Windows.Forms.Label lblTemperature;
		protected System.Windows.Forms.Label lblPulse;
		protected System.Windows.Forms.Label lblBreath;
		protected System.Windows.Forms.Label lblDia;
		protected System.Windows.Forms.Label lblSys;
		protected com.digitalwave.controls.ctlRichTextBox m_txtCatameniaHistory;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBreath;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSys;
		protected com.digitalwave.controls.ctlRichTextBox m_txtDia;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMarriageHistory;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFamilyHistory;
		protected com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		protected System.Windows.Forms.Label label8;
		protected com.digitalwave.controls.ctlRichTextBox m_txtProfessionalCheck;
		protected com.digitalwave.controls.ctlRichTextBox m_txtLabCheck;
		protected System.Windows.Forms.Label lblFinallyDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFinallyDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSummary;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPrimaryDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMedical;
		private System.Windows.Forms.PictureBox m_picLabCheck;
		private System.Windows.Forms.PictureBox m_picMedical;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox pictureBox10;
        protected com.digitalwave.controls.ctlRichTextBox m_txtMainDescription;
		private System.ComponentModel.IContainer components = null;
		#endregion FormDefines

		#region Member

		private com.digitalwave.Utility.Controls.ctlPaintContainer ctlPaintContainer1;
		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.Label label13;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboFirstCatamenia;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaLastTime;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaCycle;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpLastCatameniaTime;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCatameniaCase;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel pnlFocus;
		private System.Windows.Forms.CheckBox m_chkCatamenia;
		private System.Windows.Forms.Panel m_pnlContent;
		private System.Windows.Forms.GroupBox m_grbCatamenia;
		protected System.Windows.Forms.Label m_lblCarePlan;
		private clsCommonUseToolCollection m_objCUTC;
        //private Bitmap imgUserclose;
        //private Bitmap imgUseropen;
		private string m_strMedicalExam_ID = "";
		private string m_strCurrentOpenDate = "";
		private bool m_bolVisableMainDescription = true;
		private bool m_bolVisableCurrentStatus = true;
		private bool m_bolVisableBeforetimeStatus = true;
		private bool m_bolVisableOwnHistory = true;
		private bool m_bolVisableCatameniaHistory = true;
		private bool m_bolVisableFamilyHistory = true;
		private bool m_bolVisableLabCheck = true;
		private bool m_bolVisableMarriageHistory = true;
		private bool m_bolVisableMedical = true;
		private bool m_bolVisableProfessionalCheck	= true;
		private bool m_bolVisableSummary = true;
		private bool m_bolVisableDiagnose = true;

		//		private com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind;

		private clsThreeMeasureShareDomain	m_objShareDomain = new clsThreeMeasureShareDomain();
		//		private frmMedicalExam001 m_objMedicalExamForm = new frmMedicalExam001 ();		//刘颖源，结构化检查
		//		private clsMedicalExamDomain m_objMedicalExamDomain = new clsMedicalExamDomain ();
		private System.Windows.Forms.Button m_cmdICD10Seach;
        private PinkieControls.ButtonXP m_cmdAssistantDiagnose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private Crownwood.Magic.Controls.TabPage tabPage7;
		private System.Windows.Forms.Panel panel4;
		private Crownwood.Magic.Controls.TabPage tabPage8;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.LinkLabel m_lklMain;
		private System.Windows.Forms.LinkLabel m_lklCurrentStatus;
		private System.Windows.Forms.LinkLabel m_lklBeforetimeStatus;
		private System.Windows.Forms.LinkLabel m_lklOwnHistory;
		private System.Windows.Forms.LinkLabel m_lklMarriageHistory;
		private System.Windows.Forms.LinkLabel m_lklFamilyHistory;
		private System.Windows.Forms.LinkLabel m_lklMedical;
		private System.Windows.Forms.LinkLabel m_lklProfessionalCheck;
		private System.Windows.Forms.LinkLabel m_lklLabCheck;
		private System.Windows.Forms.LinkLabel m_lklPrimaryDiagnose;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		protected com.digitalwave.controls.ctlRichTextBox m_thtxtaddDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_thtxtModifydiagnose;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpModifyDiagnoseDate;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpAddDiagnoseDate;
        private PinkieControls.ButtonXP m_cmdModifyDiagnoseDoctor;
		private PinkieControls.ButtonXP m_cmdAddDiagnoseDoctor;
		private System.Windows.Forms.Panel panel6;
		private Crownwood.Magic.Controls.TabPage tabPage9;
        private PinkieControls.ButtonXP m_cmdDirectorDoc;
        private PinkieControls.ButtonXP m_cmdChargeDoc;

		/// <summary>
		/// 病历选择
		/// </summary>
		private enmCaseType m_enmCaseType = enmCaseType.默认;

		#endregion
        private TextBox txtSign;
        private TextBox m_txtDirectorDoc;
        private TextBox m_txtChargeDoc;
        private TextBox m_txtAddDiagnoseDoctor;
        private TextBox m_txtModifyDiagnoseDoctor;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		public frmInPatientCaseHistory()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                m_cmdDirectorDoc.Visible = true;
                m_txtDirectorDoc.Visible = true;
                m_cmdChargeDoc.Visible = true;
                m_txtChargeDoc.Visible = true;
            }

			m_mthInit();
			
			m_blnCanDoctorTextChanged = true;

 
            //this.m_tip.SetToolTip(this.m_picMainDescription ,"隐藏主诉"); 
            //this.m_tip.SetToolTip(this.m_picCurrentStatus ,"隐藏现病史"); 
            //this.m_tip.SetToolTip(this.m_picBeforetimeStatus ,"隐藏既往史");  
            //this.m_tip.SetToolTip(this.m_picOwnHistory ,"隐藏个人史"); 
            //this.m_tip.SetToolTip(this.m_picCatameniaHistory ,"隐藏月经史"); 
            //this.m_tip.SetToolTip(this.m_picFamilyHistory ,"隐藏家族史"); 
            //this.m_tip.SetToolTip(this.m_picLabCheck ,"隐藏实验室检查及特殊检查"); 
            //this.m_tip.SetToolTip(this.m_picMarriageHistory ,"隐藏婚姻史");
            //this.m_tip.SetToolTip(this.m_picMedical ,"隐藏体格检查");
            //this.m_tip.SetToolTip(this.m_picProfessionalCheck ,"隐藏专科检查");
            //this.m_tip.SetToolTip(this.m_picSummary ,"隐藏摘要");
            //this.m_tip.SetToolTip(this.m_picDiagnose ,"隐藏诊断");
			
            //imgUserclose = new Bitmap(strGetFilePathHeader()+"picture\\"+ "CLSDFOLD.ICO");
            //imgUseropen= new Bitmap(strGetFilePathHeader()+"picture\\"+ "OPENFOLD.ICO");
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthUnEnableRichTextBox();

 			
 
			m_txtPulse.LostFocus += new EventHandler(m_mthSyncPluse);

            //m_mthHideSomeItem(m_objCurrentPatient);
			
    
			if(clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
			{
				this.tabControl2.TabPages.Add(this.tabPage9);
			}
			
			//ICD10查询
			//			m_objIcd10Bind=new clsBindICD10();
			//			
			//			//m_objIcd10Bind.m_mthBindICD10(m_cmdAssistantDiagnose,m_txtPrimaryDiagnose,1,1,m_objCurrentPatient.m_StrInPatientID,(m_objCurrentPatient.m_DtmSelectedInDate).ToString());
			//			m_objIcd10Bind.m_mthBindICD10(button1,m_txtPrimaryDiagnose,1,1,"00001","2004-11-15");
			//			m_objIcd10Bind.m_evtInvokeTemplate += new InvokeTemplateHandle(m_mthInvokeTemplate);

            
            #region 新通用绑定签名
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse,员工ID);
            //记录者签名
            m_objSign.m_mthBindEmployeeSign(m_cmdCreateID, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //修正医师
            m_objSign.m_mthBindEmployeeSign(m_cmdModifyDiagnoseDoctor, m_txtModifyDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //补充医师
            m_objSign.m_mthBindEmployeeSign(m_cmdAddDiagnoseDoctor, m_txtAddDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主任医师
            m_objSign.m_mthBindEmployeeSign(m_cmdDirectorDoc, m_txtDirectorDoc,1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主治医师
            m_objSign.m_mthBindEmployeeSign(m_cmdChargeDoc, m_txtChargeDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            
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
		#endregion 属性

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInPatientCaseHistory));
            this.m_cboRepresentor = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblRepresentor = new System.Windows.Forms.Label();
            this.m_cboCredibility = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblCredibility = new System.Windows.Forms.Label();
            this.m_tip = new System.Windows.Forms.ToolTip(this.components);
            this.m_cmdICD10Seach = new System.Windows.Forms.Button();
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
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lklMain = new System.Windows.Forms.LinkLabel();
            this.m_txtCurrentStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBeforetimeStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOwnHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklCurrentStatus = new System.Windows.Forms.LinkLabel();
            this.m_lklBeforetimeStatus = new System.Windows.Forms.LinkLabel();
            this.m_lklOwnHistory = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_lklMarriageHistory = new System.Windows.Forms.LinkLabel();
            this.m_txtFamilyHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_chkCatamenia = new System.Windows.Forms.CheckBox();
            this.m_grbCatamenia = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_cboFirstCatamenia = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cboCatameniaLastTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_cboCatameniaCycle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_dtpLastCatameniaTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cboCatameniaCase = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtCatameniaHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMarriageHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklFamilyHistory = new System.Windows.Forms.LinkLabel();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtSys = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDia = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklMedical = new System.Windows.Forms.LinkLabel();
            this.lblPulse = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBreath = new System.Windows.Forms.Label();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblSys = new System.Windows.Forms.Label();
            this.m_picMedical = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtMedical = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtProfessionalCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.m_picLabCheck = new System.Windows.Forms.PictureBox();
            this.m_lklProfessionalCheck = new System.Windows.Forms.LinkLabel();
            this.tabPage8 = new Crownwood.Magic.Controls.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_lklLabCheck = new System.Windows.Forms.LinkLabel();
            this.m_txtPrimaryDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFinallyDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCarePlan = new System.Windows.Forms.Label();
            this.m_txtLabCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.pnlFocus = new System.Windows.Forms.Panel();
            this.lblFinallyDiagnose = new System.Windows.Forms.Label();
            this.m_lklPrimaryDiagnose = new System.Windows.Forms.LinkLabel();
            this.tabPage7 = new Crownwood.Magic.Controls.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctlPaintContainer1 = new com.digitalwave.Utility.Controls.ctlPaintContainer();
            this.tabPage9 = new Crownwood.Magic.Controls.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_txtDirectorDoc = new System.Windows.Forms.TextBox();
            this.m_txtChargeDoc = new System.Windows.Forms.TextBox();
            this.m_txtAddDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.m_txtModifyDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.m_dtpModifyDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_cmdAddDiagnoseDoctor = new PinkieControls.ButtonXP();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.m_thtxtModifydiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdModifyDiagnoseDoctor = new PinkieControls.ButtonXP();
            this.m_dtpAddDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_thtxtaddDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdDirectorDoc = new PinkieControls.ButtonXP();
            this.m_cmdChargeDoc = new PinkieControls.ButtonXP();
            this.m_txtSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdAssistantDiagnose = new PinkieControls.ButtonXP();
            this.txtSign = new System.Windows.Forms.TextBox();
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
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_grbCatamenia.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMedical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picLabCheck)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Location = new System.Drawing.Point(603, 116);
            this.m_cmdCreateID.Size = new System.Drawing.Size(76, 24);
            this.m_cmdCreateID.TabIndex = 70;
            this.m_cmdCreateID.Click += new System.EventHandler(this.m_cmdCreateID_Click);
            // 
            // trvTime
            // 
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(64, 219);
            this.trvTime.Size = new System.Drawing.Size(194, 58);
            this.trvTime.TabIndex = 30;
            this.trvTime.Visible = false;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(74, 118);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(215, 22);
            this.m_dtpCreateDate.TabIndex = 40;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(6, 121);
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Location = new System.Drawing.Point(61, 240);
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Location = new System.Drawing.Point(102, 239);
            this.m_lblNativePlace.Size = new System.Drawing.Size(85, 20);
            this.m_lblNativePlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(107, 261);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(155, 261);
            this.m_lblOccupation.Size = new System.Drawing.Size(144, 20);
            this.m_lblOccupation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(176, 249);
            this.m_lblMarriaged.Size = new System.Drawing.Size(146, 20);
            this.m_lblMarriaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(128, 250);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblCreateUserName
            // 
            this.m_lblCreateUserName.Location = new System.Drawing.Point(486, 2);
            this.m_lblCreateUserName.Size = new System.Drawing.Size(16, 3);
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(135, 258);
            this.m_lblLinkMan.Size = new System.Drawing.Size(90, 20);
            this.m_lblLinkMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(77, 259);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(74, 275);
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(113, 275);
            this.m_lblAddress.Size = new System.Drawing.Size(348, 20);
            this.m_lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblAddress.Visible = false;
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(155, 244);
            this.lblNation.Visible = false;
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(204, 244);
            this.m_lblNation.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(102, 185);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(157, 191);
            this.lblAge.Size = new System.Drawing.Size(30, 19);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(204, 162);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(176, 162);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(145, 195);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(91, 190);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(179, 177);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(145, 181);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(131, 225);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            this.m_lsvInPatientID.TabIndex = 5000;
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(142, 181);
            this.txtInPatientID.Size = new System.Drawing.Size(92, 23);
            this.txtInPatientID.TabIndex = 25;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(116, 255);
            this.m_txtPatientName.Size = new System.Drawing.Size(90, 23);
            this.m_txtPatientName.TabIndex = 20;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(179, 161);
            this.m_txtBedNO.Size = new System.Drawing.Size(70, 23);
            this.m_txtBedNO.TabIndex = 10;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(139, 196);
            this.m_cboArea.TabIndex = 700;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(131, 219);
            this.m_lsvPatientName.Size = new System.Drawing.Size(90, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(139, 219);
            this.m_lsvBedNO.Size = new System.Drawing.Size(78, 100);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(85, 190);
            this.m_cboDept.TabIndex = 600;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(102, 236);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(139, 287);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(179, 174);
            this.m_cmdNext.Size = new System.Drawing.Size(22, 21);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(158, 198);
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
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(417, 184);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 35);
            this.m_tipMain.SetToolTip(this.m_cmdModifyPatientInfo, "点击查看和修改患者详细信息(快捷键Alt+P)");
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cmdAssistantDiagnose);
            this.m_pnlNewBase.Controls.Add(this.m_cboRepresentor);
            this.m_pnlNewBase.Controls.Add(this.lblRepresentor);
            this.m_pnlNewBase.Controls.Add(this.lblCredibility);
            this.m_pnlNewBase.Controls.Add(this.m_cboCredibility);
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(790, 138);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cboCredibility, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblCredibility, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblRepresentor, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cboRepresentor, 0);
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
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(788, 107);
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
            this.m_cboRepresentor.Location = new System.Drawing.Point(497, 111);
            this.m_cboRepresentor.m_BlnEnableItemEventMenu = true;
            this.m_cboRepresentor.Name = "m_cboRepresentor";
            this.m_cboRepresentor.SelectedIndex = -1;
            this.m_cboRepresentor.SelectedItem = null;
            this.m_cboRepresentor.SelectionStart = 0;
            this.m_cboRepresentor.Size = new System.Drawing.Size(92, 23);
            this.m_cboRepresentor.TabIndex = 50;
            this.m_cboRepresentor.TextBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblRepresentor
            // 
            this.lblRepresentor.AutoSize = true;
            this.lblRepresentor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepresentor.Location = new System.Drawing.Point(444, 115);
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
            this.m_cboCredibility.Location = new System.Drawing.Point(348, 111);
            this.m_cboCredibility.m_BlnEnableItemEventMenu = true;
            this.m_cboCredibility.Name = "m_cboCredibility";
            this.m_cboCredibility.SelectedIndex = -1;
            this.m_cboCredibility.SelectedItem = null;
            this.m_cboCredibility.SelectionStart = 0;
            this.m_cboCredibility.Size = new System.Drawing.Size(90, 23);
            this.m_cboCredibility.TabIndex = 60;
            this.m_cboCredibility.TextBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblCredibility
            // 
            this.lblCredibility.AutoSize = true;
            this.lblCredibility.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCredibility.Location = new System.Drawing.Point(290, 115);
            this.lblCredibility.Name = "lblCredibility";
            this.lblCredibility.Size = new System.Drawing.Size(56, 14);
            this.lblCredibility.TabIndex = 514;
            this.lblCredibility.Text = "可靠度:";
            // 
            // m_cmdICD10Seach
            // 
            this.m_cmdICD10Seach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdICD10Seach.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdICD10Seach.Location = new System.Drawing.Point(126, 359);
            this.m_cmdICD10Seach.Name = "m_cmdICD10Seach";
            this.m_cmdICD10Seach.Size = new System.Drawing.Size(70, 22);
            this.m_cmdICD10Seach.TabIndex = 10000103;
            this.m_cmdICD10Seach.Text = "ICD10查询";
            this.m_tip.SetToolTip(this.m_cmdICD10Seach, "国际疾病查询");
            this.m_cmdICD10Seach.Visible = false;
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
            this.m_picMainDescription.Click += new System.EventHandler(this.m_picMainDescription_Click);
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
            this.m_picCurrentStatus.Click += new System.EventHandler(this.m_picCurrentStatus_Click);
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
            this.m_pnlContent.Controls.Add(this.tabControl2);
            this.m_pnlContent.Location = new System.Drawing.Point(4, 146);
            this.m_pnlContent.Name = "m_pnlContent";
            this.m_pnlContent.Size = new System.Drawing.Size(790, 452);
            this.m_pnlContent.TabIndex = 500;
            this.m_pnlContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.m_pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.m_pnlContent_Paint);
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(3, 2);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 3;
            this.tabControl2.SelectedTab = this.tabPage8;
            this.tabControl2.Size = new System.Drawing.Size(782, 445);
            this.tabControl2.TabIndex = 10000105;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4,
            this.tabPage5,
            this.tabPage6,
            this.tabPage8,
            this.tabPage7,
            this.tabPage9});
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(782, 420);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "病史一";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_lklMain);
            this.panel1.Controls.Add(this.m_txtCurrentStatus);
            this.panel1.Controls.Add(this.m_txtBeforetimeStatus);
            this.panel1.Controls.Add(this.m_txtMainDescription);
            this.panel1.Controls.Add(this.m_txtOwnHistory);
            this.panel1.Controls.Add(this.m_lklCurrentStatus);
            this.panel1.Controls.Add(this.m_lklBeforetimeStatus);
            this.panel1.Controls.Add(this.m_lklOwnHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 420);
            this.panel1.TabIndex = 10000091;
            // 
            // m_lklMain
            // 
            this.m_lklMain.AutoSize = true;
            this.m_lklMain.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMain.Location = new System.Drawing.Point(8, 14);
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
            this.m_txtCurrentStatus.Location = new System.Drawing.Point(68, 47);
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
            this.m_txtCurrentStatus.Size = new System.Drawing.Size(670, 189);
            this.m_txtCurrentStatus.TabIndex = 100;
            this.m_txtCurrentStatus.Tag = "1";
            this.m_txtCurrentStatus.Text = "";
            // 
            // m_txtBeforetimeStatus
            // 
            this.m_txtBeforetimeStatus.AccessibleDescription = "既往史";
            this.m_txtBeforetimeStatus.BackColor = System.Drawing.Color.White;
            this.m_txtBeforetimeStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeforetimeStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBeforetimeStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBeforetimeStatus.Location = new System.Drawing.Point(68, 240);
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
            this.m_txtBeforetimeStatus.Size = new System.Drawing.Size(670, 86);
            this.m_txtBeforetimeStatus.TabIndex = 110;
            this.m_txtBeforetimeStatus.Tag = "2";
            this.m_txtBeforetimeStatus.Text = "";
            // 
            // m_txtMainDescription
            // 
            this.m_txtMainDescription.AccessibleDescription = "主诉";
            this.m_txtMainDescription.AutoSize = true;
            this.m_txtMainDescription.BackColor = System.Drawing.Color.White;
            this.m_txtMainDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDescription.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMainDescription.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDescription.Location = new System.Drawing.Point(68, 12);
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
            this.m_txtMainDescription.Size = new System.Drawing.Size(670, 23);
            this.m_txtMainDescription.TabIndex = 90;
            this.m_txtMainDescription.Tag = "0";
            this.m_txtMainDescription.Text = "";
            // 
            // m_txtOwnHistory
            // 
            this.m_txtOwnHistory.AccessibleDescription = "个人史";
            this.m_txtOwnHistory.BackColor = System.Drawing.Color.White;
            this.m_txtOwnHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOwnHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOwnHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOwnHistory.Location = new System.Drawing.Point(68, 328);
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
            this.m_txtOwnHistory.Size = new System.Drawing.Size(670, 72);
            this.m_txtOwnHistory.TabIndex = 120;
            this.m_txtOwnHistory.Tag = "3";
            this.m_txtOwnHistory.Text = "";
            // 
            // m_lklCurrentStatus
            // 
            this.m_lklCurrentStatus.AutoSize = true;
            this.m_lklCurrentStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklCurrentStatus.Location = new System.Drawing.Point(8, 48);
            this.m_lklCurrentStatus.Name = "m_lklCurrentStatus";
            this.m_lklCurrentStatus.Size = new System.Drawing.Size(56, 14);
            this.m_lklCurrentStatus.TabIndex = 576;
            this.m_lklCurrentStatus.TabStop = true;
            this.m_lklCurrentStatus.Text = "现病史:";
            this.m_lklCurrentStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklBeforetimeStatus
            // 
            this.m_lklBeforetimeStatus.AutoSize = true;
            this.m_lklBeforetimeStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklBeforetimeStatus.Location = new System.Drawing.Point(8, 242);
            this.m_lklBeforetimeStatus.Name = "m_lklBeforetimeStatus";
            this.m_lklBeforetimeStatus.Size = new System.Drawing.Size(56, 14);
            this.m_lklBeforetimeStatus.TabIndex = 576;
            this.m_lklBeforetimeStatus.TabStop = true;
            this.m_lklBeforetimeStatus.Text = "既往史:";
            this.m_lklBeforetimeStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklOwnHistory
            // 
            this.m_lklOwnHistory.AutoSize = true;
            this.m_lklOwnHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklOwnHistory.Location = new System.Drawing.Point(8, 332);
            this.m_lklOwnHistory.Name = "m_lklOwnHistory";
            this.m_lklOwnHistory.Size = new System.Drawing.Size(56, 14);
            this.m_lklOwnHistory.TabIndex = 576;
            this.m_lklOwnHistory.TabStop = true;
            this.m_lklOwnHistory.Text = "个人史:";
            this.m_lklOwnHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.ImageIndex = 0;
            this.tabPage5.ImageList = this.imageList1;
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(782, 420);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Title = "病史二";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.m_lklMarriageHistory);
            this.panel4.Controls.Add(this.m_txtFamilyHistory);
            this.panel4.Controls.Add(this.m_chkCatamenia);
            this.panel4.Controls.Add(this.m_grbCatamenia);
            this.panel4.Controls.Add(this.m_txtMarriageHistory);
            this.panel4.Controls.Add(this.m_lklFamilyHistory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(782, 420);
            this.panel4.TabIndex = 0;
            // 
            // m_lklMarriageHistory
            // 
            this.m_lklMarriageHistory.AutoSize = true;
            this.m_lklMarriageHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMarriageHistory.Location = new System.Drawing.Point(12, 8);
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
            this.m_txtFamilyHistory.Location = new System.Drawing.Point(74, 304);
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
            this.m_txtFamilyHistory.Size = new System.Drawing.Size(634, 102);
            this.m_txtFamilyHistory.TabIndex = 150;
            this.m_txtFamilyHistory.Tag = "7";
            this.m_txtFamilyHistory.Text = "";
            // 
            // m_chkCatamenia
            // 
            this.m_chkCatamenia.Checked = true;
            this.m_chkCatamenia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCatamenia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCatamenia.Location = new System.Drawing.Point(10, 120);
            this.m_chkCatamenia.Name = "m_chkCatamenia";
            this.m_chkCatamenia.Size = new System.Drawing.Size(112, 24);
            this.m_chkCatamenia.TabIndex = 10000090;
            this.m_chkCatamenia.Tag = "5";
            this.m_chkCatamenia.Text = "月经生育史";
            this.m_chkCatamenia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkCatamenia.CheckedChanged += new System.EventHandler(this.m_chkCatamenia_CheckedChanged);
            // 
            // m_grbCatamenia
            // 
            this.m_grbCatamenia.Controls.Add(this.label13);
            this.m_grbCatamenia.Controls.Add(this.m_cboFirstCatamenia);
            this.m_grbCatamenia.Controls.Add(this.label14);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaLastTime);
            this.m_grbCatamenia.Controls.Add(this.label15);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaCycle);
            this.m_grbCatamenia.Controls.Add(this.label16);
            this.m_grbCatamenia.Controls.Add(this.m_dtpLastCatameniaTime);
            this.m_grbCatamenia.Controls.Add(this.m_cboCatameniaCase);
            this.m_grbCatamenia.Controls.Add(this.m_txtCatameniaHistory);
            this.m_grbCatamenia.Location = new System.Drawing.Point(10, 150);
            this.m_grbCatamenia.Name = "m_grbCatamenia";
            this.m_grbCatamenia.Size = new System.Drawing.Size(698, 150);
            this.m_grbCatamenia.TabIndex = 10000090;
            this.m_grbCatamenia.TabStop = false;
            this.m_grbCatamenia.Tag = "5";
            this.m_grbCatamenia.Enter += new System.EventHandler(this.m_grbCatamenia_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(14, 34);
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
            this.m_cboFirstCatamenia.Location = new System.Drawing.Point(65, 30);
            this.m_cboFirstCatamenia.m_BlnEnableItemEventMenu = true;
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
            this.label14.Location = new System.Drawing.Point(214, 34);
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
            this.m_cboCatameniaLastTime.Location = new System.Drawing.Point(264, 30);
            this.m_cboCatameniaLastTime.m_BlnEnableItemEventMenu = true;
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
            this.label15.Location = new System.Drawing.Point(214, 62);
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
            this.m_cboCatameniaCycle.Location = new System.Drawing.Point(264, 58);
            this.m_cboCatameniaCycle.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaCycle.Name = "m_cboCatameniaCycle";
            this.m_cboCatameniaCycle.SelectedIndex = -1;
            this.m_cboCatameniaCycle.SelectedItem = null;
            this.m_cboCatameniaCycle.SelectionStart = 0;
            this.m_cboCatameniaCycle.Size = new System.Drawing.Size(140, 23);
            this.m_cboCatameniaCycle.TabIndex = 10000086;
            this.m_cboCatameniaCycle.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.TextForeColor = System.Drawing.Color.Black;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(413, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000087;
            this.label16.Text = "末次时间:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.m_dtpLastCatameniaTime.Location = new System.Drawing.Point(492, 31);
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
            this.m_cboCatameniaCase.Location = new System.Drawing.Point(492, 58);
            this.m_cboCatameniaCase.m_BlnEnableItemEventMenu = true;
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
            this.m_txtCatameniaHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCatameniaHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCatameniaHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCatameniaHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCatameniaHistory.Location = new System.Drawing.Point(64, 88);
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
            this.m_txtCatameniaHistory.Size = new System.Drawing.Size(634, 48);
            this.m_txtCatameniaHistory.TabIndex = 140;
            this.m_txtCatameniaHistory.Tag = "6";
            this.m_txtCatameniaHistory.Text = "";
            // 
            // m_txtMarriageHistory
            // 
            this.m_txtMarriageHistory.AccessibleDescription = "婚姻史";
            this.m_txtMarriageHistory.BackColor = System.Drawing.Color.White;
            this.m_txtMarriageHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMarriageHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMarriageHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMarriageHistory.Location = new System.Drawing.Point(74, 6);
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
            this.m_txtMarriageHistory.Size = new System.Drawing.Size(634, 106);
            this.m_txtMarriageHistory.TabIndex = 130;
            this.m_txtMarriageHistory.Tag = "5";
            this.m_txtMarriageHistory.Text = "";
            // 
            // m_lklFamilyHistory
            // 
            this.m_lklFamilyHistory.AutoSize = true;
            this.m_lklFamilyHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklFamilyHistory.Location = new System.Drawing.Point(12, 308);
            this.m_lklFamilyHistory.Name = "m_lklFamilyHistory";
            this.m_lklFamilyHistory.Size = new System.Drawing.Size(56, 14);
            this.m_lklFamilyHistory.TabIndex = 10000091;
            this.m_lklFamilyHistory.TabStop = true;
            this.m_lklFamilyHistory.Text = "家族史:";
            this.m_lklFamilyHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel2);
            this.tabPage6.ImageIndex = 1;
            this.tabPage6.ImageList = this.imageList1;
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(782, 420);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Title = "各项检查一";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_txtSys);
            this.panel2.Controls.Add(this.m_txtDia);
            this.panel2.Controls.Add(this.m_lklMedical);
            this.panel2.Controls.Add(this.lblPulse);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.m_txtBreath);
            this.panel2.Controls.Add(this.lblBreath);
            this.panel2.Controls.Add(this.lblDia);
            this.panel2.Controls.Add(this.lblSys);
            this.panel2.Controls.Add(this.m_picMedical);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pictureBox10);
            this.panel2.Controls.Add(this.lblTemperature);
            this.panel2.Controls.Add(this.m_txtTemperature);
            this.panel2.Controls.Add(this.m_txtPulse);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.m_txtMedical);
            this.panel2.Controls.Add(this.m_txtProfessionalCheck);
            this.panel2.Controls.Add(this.pictureBox9);
            this.panel2.Controls.Add(this.m_picLabCheck);
            this.panel2.Controls.Add(this.m_lklProfessionalCheck);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 420);
            this.panel2.TabIndex = 10000095;
            // 
            // m_txtSys
            // 
            this.m_txtSys.AccessibleDescription = "血压";
            this.m_txtSys.BackColor = System.Drawing.Color.White;
            this.m_txtSys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSys.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtSys.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSys.Location = new System.Drawing.Point(536, 18);
            this.m_txtSys.m_BlnIgnoreUserInfo = false;
            this.m_txtSys.m_BlnPartControl = false;
            this.m_txtSys.m_BlnReadOnly = false;
            this.m_txtSys.m_BlnUnderLineDST = false;
            this.m_txtSys.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSys.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSys.m_IntCanModifyTime = 6;
            this.m_txtSys.m_IntPartControlLength = 0;
            this.m_txtSys.m_IntPartControlStartIndex = 0;
            this.m_txtSys.m_StrUserID = "";
            this.m_txtSys.m_StrUserName = "";
            this.m_txtSys.MaxLength = 20;
            this.m_txtSys.Multiline = false;
            this.m_txtSys.Name = "m_txtSys";
            this.m_txtSys.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSys.Size = new System.Drawing.Size(52, 21);
            this.m_txtSys.TabIndex = 190;
            this.m_txtSys.Tag = "8";
            this.m_txtSys.Text = "";
            // 
            // m_txtDia
            // 
            this.m_txtDia.AccessibleDescription = "血压";
            this.m_txtDia.BackColor = System.Drawing.Color.White;
            this.m_txtDia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDia.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtDia.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDia.Location = new System.Drawing.Point(600, 18);
            this.m_txtDia.m_BlnIgnoreUserInfo = false;
            this.m_txtDia.m_BlnPartControl = false;
            this.m_txtDia.m_BlnReadOnly = false;
            this.m_txtDia.m_BlnUnderLineDST = false;
            this.m_txtDia.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDia.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDia.m_IntCanModifyTime = 6;
            this.m_txtDia.m_IntPartControlLength = 0;
            this.m_txtDia.m_IntPartControlStartIndex = 0;
            this.m_txtDia.m_StrUserID = "";
            this.m_txtDia.m_StrUserName = "";
            this.m_txtDia.MaxLength = 20;
            this.m_txtDia.Multiline = false;
            this.m_txtDia.Name = "m_txtDia";
            this.m_txtDia.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDia.Size = new System.Drawing.Size(52, 21);
            this.m_txtDia.TabIndex = 200;
            this.m_txtDia.Tag = "8";
            this.m_txtDia.Text = "";
            // 
            // m_lklMedical
            // 
            this.m_lklMedical.AutoSize = true;
            this.m_lklMedical.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklMedical.Location = new System.Drawing.Point(32, 20);
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
            this.lblPulse.Location = new System.Drawing.Point(226, 18);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(42, 14);
            this.lblPulse.TabIndex = 560;
            this.lblPulse.Tag = "8";
            this.lblPulse.Text = "脉搏:";
            this.lblPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(206, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 14);
            this.label17.TabIndex = 10000091;
            this.label17.Tag = "8";
            this.label17.Text = "℃";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.AccessibleDescription = "呼吸";
            this.m_txtBreath.BackColor = System.Drawing.Color.White;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(402, 18);
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
            // lblBreath
            // 
            this.lblBreath.AutoSize = true;
            this.lblBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreath.Location = new System.Drawing.Point(360, 18);
            this.lblBreath.Name = "lblBreath";
            this.lblBreath.Size = new System.Drawing.Size(42, 14);
            this.lblBreath.TabIndex = 559;
            this.lblBreath.Tag = "8";
            this.lblBreath.Text = "呼吸:";
            this.lblBreath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDia.Location = new System.Drawing.Point(494, 18);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(42, 14);
            this.lblDia.TabIndex = 562;
            this.lblDia.Tag = "8";
            this.lblDia.Text = "血压:";
            this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSys
            // 
            this.lblSys.AutoSize = true;
            this.lblSys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSys.Location = new System.Drawing.Point(587, 21);
            this.lblSys.Name = "lblSys";
            this.lblSys.Size = new System.Drawing.Size(14, 14);
            this.lblSys.TabIndex = 561;
            this.lblSys.Tag = "8";
            this.lblSys.Text = "/";
            this.lblSys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_picMedical
            // 
            this.m_picMedical.Image = ((System.Drawing.Image)(resources.GetObject("m_picMedical.Image")));
            this.m_picMedical.Location = new System.Drawing.Point(6, 18);
            this.m_picMedical.Name = "m_picMedical";
            this.m_picMedical.Size = new System.Drawing.Size(16, 16);
            this.m_picMedical.TabIndex = 602;
            this.m_picMedical.TabStop = false;
            this.m_picMedical.Tag = "8";
            this.m_picMedical.Visible = false;
            this.m_picMedical.Click += new System.EventHandler(this.m_picMedical_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(650, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 578;
            this.label8.Tag = "8";
            this.label8.Text = "mmHg";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(8, 114);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(16, 16);
            this.pictureBox10.TabIndex = 599;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "12";
            this.pictureBox10.Visible = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperature.Location = new System.Drawing.Point(112, 18);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(42, 14);
            this.lblTemperature.TabIndex = 565;
            this.lblTemperature.Tag = "8";
            this.lblTemperature.Text = "体温:";
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(156, 18);
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
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(268, 18);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(452, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 14);
            this.label19.TabIndex = 10000093;
            this.label19.Tag = "8";
            this.label19.Text = "次/分";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(318, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 14);
            this.label18.TabIndex = 10000092;
            this.label18.Tag = "8";
            this.label18.Text = "次/分";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtMedical
            // 
            this.m_txtMedical.AccessibleDescription = "体格检查";
            this.m_txtMedical.BackColor = System.Drawing.Color.White;
            this.m_txtMedical.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedical.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMedical.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMedical.Location = new System.Drawing.Point(102, 48);
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
            this.m_txtMedical.Size = new System.Drawing.Size(582, 224);
            this.m_txtMedical.TabIndex = 210;
            this.m_txtMedical.Tag = "8";
            this.m_txtMedical.Text = "";
            // 
            // m_txtProfessionalCheck
            // 
            this.m_txtProfessionalCheck.AccessibleDescription = "专科检查";
            this.m_txtProfessionalCheck.BackColor = System.Drawing.Color.White;
            this.m_txtProfessionalCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProfessionalCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtProfessionalCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtProfessionalCheck.Location = new System.Drawing.Point(102, 284);
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
            this.m_txtProfessionalCheck.Size = new System.Drawing.Size(582, 112);
            this.m_txtProfessionalCheck.TabIndex = 220;
            this.m_txtProfessionalCheck.Tag = "9";
            this.m_txtProfessionalCheck.Text = "";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(4, 60);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(16, 20);
            this.pictureBox9.TabIndex = 603;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Tag = "9";
            this.pictureBox9.Visible = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // m_picLabCheck
            // 
            this.m_picLabCheck.Image = ((System.Drawing.Image)(resources.GetObject("m_picLabCheck.Image")));
            this.m_picLabCheck.Location = new System.Drawing.Point(6, 92);
            this.m_picLabCheck.Name = "m_picLabCheck";
            this.m_picLabCheck.Size = new System.Drawing.Size(16, 16);
            this.m_picLabCheck.TabIndex = 603;
            this.m_picLabCheck.TabStop = false;
            this.m_picLabCheck.Tag = "10";
            this.m_picLabCheck.Visible = false;
            this.m_picLabCheck.Click += new System.EventHandler(this.m_picLabCheck_Click);
            // 
            // m_lklProfessionalCheck
            // 
            this.m_lklProfessionalCheck.AutoSize = true;
            this.m_lklProfessionalCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklProfessionalCheck.Location = new System.Drawing.Point(26, 286);
            this.m_lklProfessionalCheck.Name = "m_lklProfessionalCheck";
            this.m_lklProfessionalCheck.Size = new System.Drawing.Size(70, 14);
            this.m_lklProfessionalCheck.TabIndex = 10000094;
            this.m_lklProfessionalCheck.TabStop = true;
            this.m_lklProfessionalCheck.Text = "专科检查:";
            this.m_lklProfessionalCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel5);
            this.tabPage8.ImageIndex = 1;
            this.tabPage8.ImageList = this.imageList1;
            this.tabPage8.Location = new System.Drawing.Point(0, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(782, 420);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Title = "各项检查二";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.m_lklLabCheck);
            this.panel5.Controls.Add(this.m_txtPrimaryDiagnose);
            this.panel5.Controls.Add(this.m_txtFinallyDiagnose);
            this.panel5.Controls.Add(this.m_cmdICD10Seach);
            this.panel5.Controls.Add(this.m_lblCarePlan);
            this.panel5.Controls.Add(this.m_txtLabCheck);
            this.panel5.Controls.Add(this.pnlFocus);
            this.panel5.Controls.Add(this.lblFinallyDiagnose);
            this.panel5.Controls.Add(this.m_lklPrimaryDiagnose);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(782, 420);
            this.panel5.TabIndex = 10000104;
            // 
            // m_lklLabCheck
            // 
            this.m_lklLabCheck.AutoSize = true;
            this.m_lklLabCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklLabCheck.Location = new System.Drawing.Point(12, 14);
            this.m_lklLabCheck.Name = "m_lklLabCheck";
            this.m_lklLabCheck.Size = new System.Drawing.Size(70, 14);
            this.m_lklLabCheck.TabIndex = 10000104;
            this.m_lklLabCheck.TabStop = true;
            this.m_lklLabCheck.Text = "辅助检查:";
            this.m_lklLabCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtPrimaryDiagnose
            // 
            this.m_txtPrimaryDiagnose.AccessibleDescription = "初步诊断";
            this.m_txtPrimaryDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrimaryDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtPrimaryDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPrimaryDiagnose.Location = new System.Drawing.Point(10, 230);
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
            this.m_txtPrimaryDiagnose.Size = new System.Drawing.Size(686, 178);
            this.m_txtPrimaryDiagnose.TabIndex = 250;
            this.m_txtPrimaryDiagnose.Tag = "12";
            this.m_txtPrimaryDiagnose.Text = "";
            // 
            // m_txtFinallyDiagnose
            // 
            this.m_txtFinallyDiagnose.AccessibleDescription = "最后诊断";
            this.m_txtFinallyDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtFinallyDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFinallyDiagnose.ForeColor = System.Drawing.Color.White;
            this.m_txtFinallyDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFinallyDiagnose.Location = new System.Drawing.Point(632, 380);
            this.m_txtFinallyDiagnose.m_BlnIgnoreUserInfo = true;
            this.m_txtFinallyDiagnose.m_BlnPartControl = false;
            this.m_txtFinallyDiagnose.m_BlnReadOnly = false;
            this.m_txtFinallyDiagnose.m_BlnUnderLineDST = false;
            this.m_txtFinallyDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFinallyDiagnose.m_IntCanModifyTime = 6;
            this.m_txtFinallyDiagnose.m_IntPartControlLength = 0;
            this.m_txtFinallyDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtFinallyDiagnose.m_StrUserID = "";
            this.m_txtFinallyDiagnose.m_StrUserName = "";
            this.m_txtFinallyDiagnose.Multiline = false;
            this.m_txtFinallyDiagnose.Name = "m_txtFinallyDiagnose";
            this.m_txtFinallyDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFinallyDiagnose.Size = new System.Drawing.Size(64, 28);
            this.m_txtFinallyDiagnose.TabIndex = 26;
            this.m_txtFinallyDiagnose.Tag = "12";
            this.m_txtFinallyDiagnose.Text = "";
            this.m_txtFinallyDiagnose.Visible = false;
            // 
            // m_lblCarePlan
            // 
            this.m_lblCarePlan.AutoSize = true;
            this.m_lblCarePlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblCarePlan.Location = new System.Drawing.Point(200, 362);
            this.m_lblCarePlan.Name = "m_lblCarePlan";
            this.m_lblCarePlan.Size = new System.Drawing.Size(70, 14);
            this.m_lblCarePlan.TabIndex = 584;
            this.m_lblCarePlan.Tag = "12";
            this.m_lblCarePlan.Text = "治疗计划:";
            this.m_lblCarePlan.Visible = false;
            // 
            // m_txtLabCheck
            // 
            this.m_txtLabCheck.AccessibleDescription = "实验室检查";
            this.m_txtLabCheck.BackColor = System.Drawing.Color.White;
            this.m_txtLabCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLabCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtLabCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLabCheck.Location = new System.Drawing.Point(10, 38);
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
            this.m_txtLabCheck.Size = new System.Drawing.Size(686, 156);
            this.m_txtLabCheck.TabIndex = 240;
            this.m_txtLabCheck.Tag = "10";
            this.m_txtLabCheck.Text = "";
            // 
            // pnlFocus
            // 
            this.pnlFocus.Location = new System.Drawing.Point(196, 22);
            this.pnlFocus.Name = "pnlFocus";
            this.pnlFocus.Size = new System.Drawing.Size(0, 0);
            this.pnlFocus.TabIndex = 10000095;
            // 
            // lblFinallyDiagnose
            // 
            this.lblFinallyDiagnose.AutoSize = true;
            this.lblFinallyDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFinallyDiagnose.Location = new System.Drawing.Point(556, 386);
            this.lblFinallyDiagnose.Name = "lblFinallyDiagnose";
            this.lblFinallyDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblFinallyDiagnose.TabIndex = 583;
            this.lblFinallyDiagnose.Tag = "12";
            this.lblFinallyDiagnose.Text = "修正诊断:";
            this.lblFinallyDiagnose.Visible = false;
            // 
            // m_lklPrimaryDiagnose
            // 
            this.m_lklPrimaryDiagnose.AutoSize = true;
            this.m_lklPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklPrimaryDiagnose.Location = new System.Drawing.Point(12, 204);
            this.m_lklPrimaryDiagnose.Name = "m_lklPrimaryDiagnose";
            this.m_lklPrimaryDiagnose.Size = new System.Drawing.Size(70, 14);
            this.m_lklPrimaryDiagnose.TabIndex = 10000104;
            this.m_lklPrimaryDiagnose.TabStop = true;
            this.m_lklPrimaryDiagnose.Text = "入院诊断:";
            this.m_lklPrimaryDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel3);
            this.tabPage7.ImageIndex = 2;
            this.tabPage7.ImageList = this.imageList1;
            this.tabPage7.Location = new System.Drawing.Point(0, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Selected = false;
            this.tabPage7.Size = new System.Drawing.Size(782, 420);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Title = "图片信息";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ctlPaintContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 420);
            this.panel3.TabIndex = 10000096;
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
            this.ctlPaintContainer1.Size = new System.Drawing.Size(778, 416);
            this.ctlPaintContainer1.TabIndex = 230;
            this.ctlPaintContainer1.选择科室图片 = com.digitalwave.Utility.Controls.ctlPaintContainer.enmImageNames.无;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel6);
            this.tabPage9.Location = new System.Drawing.Point(0, 25);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Selected = false;
            this.tabPage9.Size = new System.Drawing.Size(782, 420);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Title = "其他";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_txtDirectorDoc);
            this.panel6.Controls.Add(this.m_txtChargeDoc);
            this.panel6.Controls.Add(this.m_txtAddDiagnoseDoctor);
            this.panel6.Controls.Add(this.m_txtModifyDiagnoseDoctor);
            this.panel6.Controls.Add(this.m_dtpModifyDiagnoseDate);
            this.panel6.Controls.Add(this.linkLabel1);
            this.panel6.Controls.Add(this.m_cmdAddDiagnoseDoctor);
            this.panel6.Controls.Add(this.linkLabel2);
            this.panel6.Controls.Add(this.m_thtxtModifydiagnose);
            this.panel6.Controls.Add(this.m_cmdModifyDiagnoseDoctor);
            this.panel6.Controls.Add(this.m_dtpAddDiagnoseDate);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.m_thtxtaddDiagnose);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.m_cmdDirectorDoc);
            this.panel6.Controls.Add(this.m_cmdChargeDoc);
            this.panel6.Location = new System.Drawing.Point(8, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(730, 408);
            this.panel6.TabIndex = 10000022;
            // 
            // m_txtDirectorDoc
            // 
            this.m_txtDirectorDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtDirectorDoc.Location = new System.Drawing.Point(346, 365);
            this.m_txtDirectorDoc.Name = "m_txtDirectorDoc";
            this.m_txtDirectorDoc.ReadOnly = true;
            this.m_txtDirectorDoc.Size = new System.Drawing.Size(100, 21);
            this.m_txtDirectorDoc.TabIndex = 10000120;
            this.m_txtDirectorDoc.Visible = false;
            // 
            // m_txtChargeDoc
            // 
            this.m_txtChargeDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtChargeDoc.Location = new System.Drawing.Point(604, 365);
            this.m_txtChargeDoc.Name = "m_txtChargeDoc";
            this.m_txtChargeDoc.ReadOnly = true;
            this.m_txtChargeDoc.Size = new System.Drawing.Size(100, 21);
            this.m_txtChargeDoc.TabIndex = 10000119;
            this.m_txtChargeDoc.Visible = false;
            // 
            // m_txtAddDiagnoseDoctor
            // 
            this.m_txtAddDiagnoseDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtAddDiagnoseDoctor.Location = new System.Drawing.Point(346, 324);
            this.m_txtAddDiagnoseDoctor.Name = "m_txtAddDiagnoseDoctor";
            this.m_txtAddDiagnoseDoctor.ReadOnly = true;
            this.m_txtAddDiagnoseDoctor.Size = new System.Drawing.Size(100, 21);
            this.m_txtAddDiagnoseDoctor.TabIndex = 10000118;
            // 
            // m_txtModifyDiagnoseDoctor
            // 
            this.m_txtModifyDiagnoseDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtModifyDiagnoseDoctor.Location = new System.Drawing.Point(346, 154);
            this.m_txtModifyDiagnoseDoctor.Name = "m_txtModifyDiagnoseDoctor";
            this.m_txtModifyDiagnoseDoctor.ReadOnly = true;
            this.m_txtModifyDiagnoseDoctor.Size = new System.Drawing.Size(100, 21);
            this.m_txtModifyDiagnoseDoctor.TabIndex = 10000117;
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
            this.m_dtpModifyDiagnoseDate.Location = new System.Drawing.Point(490, 152);
            this.m_dtpModifyDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpModifyDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpModifyDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.Name = "m_dtpModifyDiagnoseDate";
            this.m_dtpModifyDiagnoseDate.ReadOnly = false;
            this.m_dtpModifyDiagnoseDate.Size = new System.Drawing.Size(214, 22);
            this.m_dtpModifyDiagnoseDate.TabIndex = 10000109;
            this.m_dtpModifyDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpModifyDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.linkLabel1.Location = new System.Drawing.Point(18, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 14);
            this.linkLabel1.TabIndex = 10000108;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修正诊断:";
            // 
            // m_cmdAddDiagnoseDoctor
            // 
            this.m_cmdAddDiagnoseDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddDiagnoseDoctor.DefaultScheme = true;
            this.m_cmdAddDiagnoseDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddDiagnoseDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddDiagnoseDoctor.Hint = "";
            this.m_cmdAddDiagnoseDoctor.Location = new System.Drawing.Point(266, 318);
            this.m_cmdAddDiagnoseDoctor.Name = "m_cmdAddDiagnoseDoctor";
            this.m_cmdAddDiagnoseDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddDiagnoseDoctor.Size = new System.Drawing.Size(80, 30);
            this.m_cmdAddDiagnoseDoctor.TabIndex = 10000114;
            this.m_cmdAddDiagnoseDoctor.Text = "医师签名:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.linkLabel2.Location = new System.Drawing.Point(18, 174);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(70, 14);
            this.linkLabel2.TabIndex = 10000107;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "补充诊断:";
            // 
            // m_thtxtModifydiagnose
            // 
            this.m_thtxtModifydiagnose.AccessibleDescription = "修正诊断";
            this.m_thtxtModifydiagnose.BackColor = System.Drawing.Color.White;
            this.m_thtxtModifydiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_thtxtModifydiagnose.ForeColor = System.Drawing.Color.Red;
            this.m_thtxtModifydiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_thtxtModifydiagnose.Location = new System.Drawing.Point(18, 26);
            this.m_thtxtModifydiagnose.m_BlnIgnoreUserInfo = false;
            this.m_thtxtModifydiagnose.m_BlnPartControl = false;
            this.m_thtxtModifydiagnose.m_BlnReadOnly = false;
            this.m_thtxtModifydiagnose.m_BlnUnderLineDST = false;
            this.m_thtxtModifydiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_thtxtModifydiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_thtxtModifydiagnose.m_IntCanModifyTime = 6;
            this.m_thtxtModifydiagnose.m_IntPartControlLength = 0;
            this.m_thtxtModifydiagnose.m_IntPartControlStartIndex = 0;
            this.m_thtxtModifydiagnose.m_StrUserID = "";
            this.m_thtxtModifydiagnose.m_StrUserName = "";
            this.m_thtxtModifydiagnose.MaxLength = 4000;
            this.m_thtxtModifydiagnose.Name = "m_thtxtModifydiagnose";
            this.m_thtxtModifydiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_thtxtModifydiagnose.Size = new System.Drawing.Size(686, 120);
            this.m_thtxtModifydiagnose.TabIndex = 10000105;
            this.m_thtxtModifydiagnose.Tag = "10";
            this.m_thtxtModifydiagnose.Text = "";
            // 
            // m_cmdModifyDiagnoseDoctor
            // 
            this.m_cmdModifyDiagnoseDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyDiagnoseDoctor.DefaultScheme = true;
            this.m_cmdModifyDiagnoseDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModifyDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdModifyDiagnoseDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdModifyDiagnoseDoctor.Hint = "";
            this.m_cmdModifyDiagnoseDoctor.Location = new System.Drawing.Point(264, 150);
            this.m_cmdModifyDiagnoseDoctor.Name = "m_cmdModifyDiagnoseDoctor";
            this.m_cmdModifyDiagnoseDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModifyDiagnoseDoctor.Size = new System.Drawing.Size(80, 30);
            this.m_cmdModifyDiagnoseDoctor.TabIndex = 10000112;
            this.m_cmdModifyDiagnoseDoctor.Text = "医师签名:";
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
            this.m_dtpAddDiagnoseDate.Location = new System.Drawing.Point(492, 322);
            this.m_dtpAddDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpAddDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpAddDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.Name = "m_dtpAddDiagnoseDate";
            this.m_dtpAddDiagnoseDate.ReadOnly = false;
            this.m_dtpAddDiagnoseDate.Size = new System.Drawing.Size(214, 22);
            this.m_dtpAddDiagnoseDate.TabIndex = 10000110;
            this.m_dtpAddDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpAddDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(448, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000116;
            this.label2.Text = "日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_thtxtaddDiagnose
            // 
            this.m_thtxtaddDiagnose.AccessibleDescription = "补充诊断";
            this.m_thtxtaddDiagnose.BackColor = System.Drawing.Color.White;
            this.m_thtxtaddDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_thtxtaddDiagnose.ForeColor = System.Drawing.Color.Red;
            this.m_thtxtaddDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_thtxtaddDiagnose.Location = new System.Drawing.Point(18, 194);
            this.m_thtxtaddDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_thtxtaddDiagnose.m_BlnPartControl = false;
            this.m_thtxtaddDiagnose.m_BlnReadOnly = false;
            this.m_thtxtaddDiagnose.m_BlnUnderLineDST = false;
            this.m_thtxtaddDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_thtxtaddDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_thtxtaddDiagnose.m_IntCanModifyTime = 6;
            this.m_thtxtaddDiagnose.m_IntPartControlLength = 0;
            this.m_thtxtaddDiagnose.m_IntPartControlStartIndex = 0;
            this.m_thtxtaddDiagnose.m_StrUserID = "";
            this.m_thtxtaddDiagnose.m_StrUserName = "";
            this.m_thtxtaddDiagnose.MaxLength = 4000;
            this.m_thtxtaddDiagnose.Name = "m_thtxtaddDiagnose";
            this.m_thtxtaddDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_thtxtaddDiagnose.Size = new System.Drawing.Size(686, 120);
            this.m_thtxtaddDiagnose.TabIndex = 10000106;
            this.m_thtxtaddDiagnose.Tag = "12";
            this.m_thtxtaddDiagnose.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(450, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000115;
            this.label1.Text = "日期:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdDirectorDoc
            // 
            this.m_cmdDirectorDoc.AccessibleDescription = "";
            this.m_cmdDirectorDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDirectorDoc.DefaultScheme = true;
            this.m_cmdDirectorDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDirectorDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirectorDoc.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDirectorDoc.Hint = "";
            this.m_cmdDirectorDoc.Location = new System.Drawing.Point(266, 360);
            this.m_cmdDirectorDoc.Name = "m_cmdDirectorDoc";
            this.m_cmdDirectorDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDirectorDoc.Size = new System.Drawing.Size(80, 30);
            this.m_cmdDirectorDoc.TabIndex = 10000114;
            this.m_cmdDirectorDoc.Text = "主任医师:";
            this.m_cmdDirectorDoc.Visible = false;
            // 
            // m_cmdChargeDoc
            // 
            this.m_cmdChargeDoc.AccessibleDescription = "";
            this.m_cmdChargeDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdChargeDoc.DefaultScheme = true;
            this.m_cmdChargeDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdChargeDoc.ForeColor = System.Drawing.Color.Black;
            this.m_cmdChargeDoc.Hint = "";
            this.m_cmdChargeDoc.Location = new System.Drawing.Point(520, 362);
            this.m_cmdChargeDoc.Name = "m_cmdChargeDoc";
            this.m_cmdChargeDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeDoc.Size = new System.Drawing.Size(80, 30);
            this.m_cmdChargeDoc.TabIndex = 10000114;
            this.m_cmdChargeDoc.Text = "主治医师:";
            this.m_cmdChargeDoc.Visible = false;
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
            this.m_cmdAssistantDiagnose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAssistantDiagnose.DefaultScheme = true;
            this.m_cmdAssistantDiagnose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAssistantDiagnose.Hint = "";
            this.m_cmdAssistantDiagnose.Location = new System.Drawing.Point(680, 79);
            this.m_cmdAssistantDiagnose.Name = "m_cmdAssistantDiagnose";
            this.m_cmdAssistantDiagnose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAssistantDiagnose.Size = new System.Drawing.Size(96, 28);
            this.m_cmdAssistantDiagnose.TabIndex = 10000021;
            this.m_cmdAssistantDiagnose.Text = "辅助诊疗";
            this.m_cmdAssistantDiagnose.Click += new System.EventHandler(this.m_cmdAssistantDiagnose_Click);
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(685, 117);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(97, 23);
            this.txtSign.TabIndex = 10000022;
            // 
            // frmInPatientCaseHistory
            // 
            this.AccessibleDescription = "住  院  病  历 1";
            this.ClientSize = new System.Drawing.Size(828, 547);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_pnlContent);
            this.Controls.Add(this.m_txtSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInPatientCaseHistory";
            this.Text = "住  院  病  历";
            this.Closed += new System.EventHandler(this.frmInPatientCaseHistory_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmInPatientCaseHistory_Closing);
            this.Load += new System.EventHandler(this.frmInPatientCaseHistory_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
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
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblLinkMan, 0);
            this.Controls.SetChildIndex(this.lblMarriaged, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
            this.Controls.SetChildIndex(this.m_pnlContent, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
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
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.m_grbCatamenia.ResumeLayout(false);
            this.m_grbCatamenia.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMedical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picLabCheck)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
			this.m_txtDia.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtFamilyHistory.m_BlnReadOnly=! p_blnEnabled;
			this.m_txtFinallyDiagnose.m_BlnReadOnly=! p_blnEnabled;	
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
			this.m_txtSys.m_BlnReadOnly=! p_blnEnabled;			
			this.m_txtCatameniaHistory.m_BlnReadOnly=! p_blnEnabled;
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
			this.m_txtDia.m_mthClearText();
			this.m_txtFamilyHistory.m_mthClearText();
			this.m_txtFinallyDiagnose.m_mthClearText();
			//			this.m_txtFinallyDiagnoseDocID.Text="";
			this.m_txtLabCheck.m_mthClearText();
			this.m_txtMainDescription .m_mthClearText();
			this.m_txtMarriageHistory.m_mthClearText();
			this.m_txtMedical.m_mthClearText();
			this.m_txtOwnHistory.m_mthClearText();
			this.m_txtPrimaryDiagnose.m_mthClearText();
			//			this.m_txtPrimaryDiagnoseDocID.Text="";
			this.m_txtProfessionalCheck.m_mthClearText() ;
			this.m_txtPulse.m_mthClearText();
			this.m_txtSummary.m_mthClearText();
			this.m_txtTemperature.m_mthClearText();
			this.m_txtSys.m_mthClearText();
			//			this.m_dtpFinallyDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
			//			this.m_dtpPrimaryDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			this.m_cboCredibility.SelectedIndex=-1;
			this.m_cboRepresentor.SelectedIndex=-1;
			this.m_txtCatameniaHistory.m_mthClearText();
			//			this.m_txtYJS.m_mthClearText();
			//			this.m_txtContraHistory.m_mthClearText();
			//			this.m_txtShYS.m_mthClearText();
			//			this.m_txtLCQK.m_mthClearText();
			//			this.m_txtCQJC.m_mthClearText();
			//			this.m_cboPregTimes.SelectedIndex=-1;
			//			this.m_cboBornTimes.SelectedIndex=-1;
			//			this.m_txtCareplan.m_mthClearText();
			//			this.m_txtOldMaternitySuffer.m_mthClearText();
			this.m_txtChargeDoc.Text = "";
            m_txtChargeDoc.Enabled = true;
			this.m_txtChargeDoc.Tag = null;
			//			this.m_txtMidwife.Text = "";
			this.m_txtDirectorDoc.Text = "";
            m_txtDirectorDoc.Enabled = true;
			this.m_txtDirectorDoc.Tag = null;

			this.m_thtxtModifydiagnose.m_mthClearText();
			this.m_thtxtaddDiagnose.m_mthClearText();
			this.m_txtModifyDiagnoseDoctor.Text="";
            m_txtModifyDiagnoseDoctor.Enabled = true;
			this.m_txtModifyDiagnoseDoctor.Tag=null;
			this.m_txtAddDiagnoseDoctor.Text="";
            m_txtAddDiagnoseDoctor.Enabled = true;
			this.m_txtAddDiagnoseDoctor.Tag=null;
					
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

            if (m_objBaseCurrentPatient != null && m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
            {
                m_mthEnableCatamenia( false);
            }
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
			//			if(p_blnEnable)
			//			{
			//				this.m_txtPrimaryDiagnoseDocID.Enabled =true;
			//				this.m_txtFinallyDiagnoseDocID.Enabled =true;
			//
			//			}
			//			else
			//			{
			//				if(this.m_txtPrimaryDiagnoseDocID.Text !="")
			//					this.m_txtPrimaryDiagnoseDocID.Enabled =false;
			//				if(this.m_txtFinallyDiagnoseDocID.Text !="")
			//					this.m_txtFinallyDiagnoseDocID.Enabled =false;
			//			}

		}

	    //获取记录创建者
        protected override clsInPatientCaseHistoryContent m_objGetCreateUserFromGUI()
        {
            clsInPatientCaseHistoryContent m_objContent=new clsInPatientCaseHistoryContent();
			try
			{
                m_objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return m_objContent;
        }

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected override clsInPatientCaseHistoryContent m_objGetContentFromGUI()
		{
			clsInPatientCaseHistoryContent m_objContent=new clsInPatientCaseHistoryContent();
			try
			{
                m_objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;

                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref m_objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //m_objContent.objSignerArr = new clsEmrSigns_VO[1];
                //m_objContent.objSignerArr[0] = new clsEmrSigns_VO();
                //m_objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
                //m_objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //m_objContent.objSignerArr[0].controlName = "txtSign";
                //m_objContent.objSignerArr[0].m_strFORMID_VCHR = "frmInPatientCaseHistory";//注意大小写
                //m_objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

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
			
				m_objContent.m_strDia=this.m_txtDia.m_strGetRightText()  ;
				m_objContent.m_strDiaAll=this.m_txtDia.Text   ;
				m_objContent.m_strDiaXML=this.m_txtDia.m_strGetXmlText()  ;
			
				m_objContent.m_strFamilyHistory=this.m_txtFamilyHistory.m_strGetRightText()  ;
				m_objContent.m_strFamilyHistoryAll=this.m_txtFamilyHistory.Text   ;
				m_objContent.m_strFamilyHistoryXML=this.m_txtFamilyHistory.m_strGetXmlText()  ;
			
				string strTemp=this.m_txtFinallyDiagnose.m_strGetRightText();
				m_objContent.m_strFinallyDiagnoseArr=strTemp.Split(MDIParent.c_chrSplitChars) ;
				m_objContent.m_strFinallyDiagnoseAll=this.m_txtFinallyDiagnose.Text   ;
				m_objContent.m_strFinallyDiagnoseXML=this.m_txtFinallyDiagnose.m_strGetXmlText() ;
			
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
			
				strTemp=this.m_txtPrimaryDiagnose.m_strGetRightText().Trim();
				m_objContent.m_strPrimaryDiagnoseArr=strTemp.Split(MDIParent.c_chrSplitChars);
				m_objContent.m_strPrimaryDiagnoseAll=this.m_txtPrimaryDiagnose.Text   ;
				m_objContent.m_strPrimaryDiagnoseXML=this.m_txtPrimaryDiagnose.m_strGetXmlText()  ;
			
				m_objContent.m_strProfessionalCheck=this.m_txtProfessionalCheck.m_strGetRightText()  ;
				m_objContent.m_strProfessionalCheckAll=this.m_txtProfessionalCheck.Text   ;
				m_objContent.m_strProfessionalCheckXML=this.m_txtProfessionalCheck.m_strGetXmlText()  ;
			
				m_objContent.m_strPulse=this.m_txtPulse.m_strGetRightText()  ;
				m_objContent.m_strPulseAll=this.m_txtPulse.Text   ;
				m_objContent.m_strPulseXML=this.m_txtPulse.m_strGetXmlText()  ;
			
				m_objContent.m_strRepresentor=this.m_cboRepresentor.Text  ;
			
				m_objContent.m_strSummary=this.m_txtSummary.m_strGetRightText()  ;
				m_objContent.m_strSummaryAll=this.m_txtSummary.Text   ;
				m_objContent.m_strSummaryXML=this.m_txtSummary.m_strGetXmlText()  ;
			
				m_objContent.m_strSys=this.m_txtSys.m_strGetRightText()  ;
				m_objContent.m_strSysAll=this.m_txtSys.Text   ;
				m_objContent.m_strSysXML=this.m_txtSys.m_strGetXmlText()  ;
			
				m_objContent.m_strTemperature=this.m_txtTemperature.m_strGetRightText()  ;
				m_objContent.m_strTemperatureAll=this.m_txtTemperature.Text   ;
				m_objContent.m_strTemperatureXML=this.m_txtTemperature.m_strGetXmlText()  ;
			
				m_objContent.m_strFinallyDiagnoseDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				m_objContent.m_strPrimaryDiagnoseDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				//修正诊断
                //进行判断，一旦写入修正诊断则要求签名 否则
                if (this.m_thtxtModifydiagnose.Text.Trim().Length != 0)
                {
                    if (m_txtModifyDiagnoseDoctor.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("已进行修正诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
				m_objContent.m_strModifyDiagnose=this.m_thtxtModifydiagnose.m_strGetRightText();
				m_objContent.m_strModifyDiagnoseAll=this.m_thtxtModifydiagnose.Text;
				m_objContent.m_strModifyDiagnoseXML=this.m_thtxtModifydiagnose.m_strGetXmlText();
				if (this.m_txtModifyDiagnoseDoctor.Tag!=null)
                    m_objContent.m_strModifyDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtModifyDiagnoseDoctor.Tag).m_strEMPNO_CHR;
				m_objContent.m_datModifyDiagnose=DateTime.Parse(m_dtpModifyDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
				//补充诊断
                //进行判断，一旦写入补充诊断则要求签名 否则
                if (this.m_thtxtaddDiagnose.Text.Trim().Length != 0)
                {
                    if (m_txtAddDiagnoseDoctor.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("已进行补充诊断，必须有医师签名","iCare Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return null;
                    }
                }
				m_objContent.m_strAddDiagnose=this.m_thtxtaddDiagnose.m_strGetRightText();
				m_objContent.m_strAddDiagnoseALL=this.m_thtxtaddDiagnose.Text;
				m_objContent.m_strAddDiagnoseXML=this.m_thtxtaddDiagnose.m_strGetXmlText();
				if (this.m_txtAddDiagnoseDoctor.Tag!=null)
                    m_objContent.m_strAddDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtAddDiagnoseDoctor.Tag).m_strEMPNO_CHR;
				m_objContent.m_datAddDiagnose=DateTime.Parse(m_dtpAddDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

				//主治医师
				if (this.m_txtChargeDoc.Tag!=null)
                    m_objContent.m_strChargeDoctor = ((clsEmrEmployeeBase_VO)this.m_txtChargeDoc.Tag).m_strEMPNO_CHR;
				//主任医师
				if (this.m_txtDirectorDoc.Tag!=null)
                    m_objContent.m_strDiretDoctor = ((clsEmrEmployeeBase_VO)this.m_txtDirectorDoc.Tag).m_strEMPNO_CHR;
			
				//			m_objContent.m_strPrimaryDiagnoseDocID =(this.m_txtPrimaryDiagnoseDocID .Text=="" ? "":(string)this.m_txtPrimaryDiagnoseDocID.Tag );
				//			m_objContent.m_strFinallyDiagnoseDocID =(m_txtFinallyDiagnoseDocID.Text =="" ? "" : (string)this.m_txtFinallyDiagnoseDocID.Tag); 
 
				m_objContent.m_strCreateName =MDIParent.OperatorName ;
				//			m_objContent.m_strPrimaryDiagnoseDocName =this.m_txtPrimaryDiagnoseDocID.Text ;
				//			m_objContent.m_strFinallyDiagnosDocName =this.m_txtFinallyDiagnoseDocID.Text ;

				//补充月经部分
				m_objContent.m_strFirstCatamenia =this.m_cboFirstCatamenia.Text ;
				m_objContent.m_strCatameniaLastTime =this.m_cboCatameniaLastTime.Text ;
				m_objContent.m_strCatameniaCycle =this.m_cboCatameniaCycle.Text ;
				m_objContent.m_dtmLastCatameniaTime =this.m_dtpLastCatameniaTime.Value ;
				m_objContent.m_strCatameniaCase =this.m_cboCatameniaCase.Text.Trim() ;
                m_objContent.m_intSelectedMC = m_chkCatamenia.Checked ? 1 : 0; 
				
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
			//体格检查中的图片信息
			//			m_objMedicalExamForm.m_objPicValueArr = p_objPicValueArr;//
			//			m_objMedicalExamForm.m_mthSetPicValue(p_objPicValueArr);

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
			this.m_txtDia.m_mthSetNewText(p_objContent.m_strDiaAll ,p_objContent.m_strDiaXML );
			this.m_txtFamilyHistory.m_mthSetNewText(p_objContent.m_strFamilyHistoryAll,p_objContent.m_strFamilyHistoryXML  );
			this.m_txtFinallyDiagnose.m_mthSetNewText(p_objContent.m_strFinallyDiagnoseAll,p_objContent.m_strFinallyDiagnoseXML  );
			this.m_txtLabCheck.m_mthSetNewText(p_objContent.m_strLabCheckAll ,p_objContent.m_strLabCheckXML );
			this.m_txtMainDescription.m_mthSetNewText(p_objContent.m_strMainDescriptionAll ,p_objContent.m_strMainDescriptionXML );
			this.m_txtMarriageHistory.m_mthSetNewText(p_objContent.m_strMarriageHistoryAll,p_objContent.m_strMarriageHistoryXML  );
			this.m_txtMedical.m_mthSetNewText(p_objContent.m_strMedicalAll ,p_objContent.m_strMedicalXML );
			this.m_txtOwnHistory.m_mthSetNewText(p_objContent.m_strOwnHistoryAll ,p_objContent.m_strOwnHistoryXML );
			this.m_txtPrimaryDiagnose.m_mthSetNewText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.m_mthSetNewText(p_objContent.m_strProfessionalCheckAll ,p_objContent.m_strProfessionalCheckXML );
			this.m_txtPulse.m_mthSetNewText(p_objContent.m_strPulseAll ,p_objContent.m_strPulseXML );
			this.m_txtSummary.m_mthSetNewText(p_objContent.m_strSummaryAll ,p_objContent.m_strSummaryXML );
			this.m_txtSys.m_mthSetNewText(p_objContent.m_strSysAll ,p_objContent.m_strSysXML );
			this.m_txtTemperature.m_mthSetNewText(p_objContent.m_strTemperatureAll ,p_objContent.m_strTemperatureXML );
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;

            //补充月经部分
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {                
                this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
			    this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
			    this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
			    this.m_cboCatameniaCycle.Text =p_objContent.m_strCatameniaCycle ;
			    if(!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
				    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
			    this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
			    if(m_cboCatameniaCase.Text.Equals("已绝经"))
				    this.m_dtpLastCatameniaTime.Enabled = false;
            }
            this.m_thtxtModifydiagnose.m_mthSetCustomNewText(p_objContent.m_strModifyDiagnoseAll, p_objContent.m_strModifyDiagnoseXML,Color.Red);
            this.m_thtxtaddDiagnose.m_mthSetCustomNewText(p_objContent.m_strAddDiagnoseALL, p_objContent.m_strAddDiagnoseXML, Color.Red);
			try
			{
				this.m_dtpModifyDiagnoseDate.Value=p_objContent.m_datModifyDiagnose;
				this.m_dtpAddDiagnoseDate.Value=p_objContent.m_datAddDiagnose;
			}
			catch(Exception ex)
			{
			}

            #region 签名赋值
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, m_txtModifyDiagnoseDoctor, m_txtAddDiagnoseDoctor, m_txtDirectorDoc, m_txtChargeDoc },
                new string[] { p_objContent.m_strCreateUserID, p_objContent.m_strModifyDiagnoseDoctorID, p_objContent.m_strAddDiagnoseDoctorID, p_objContent.m_strDiretDoctor, p_objContent.m_strChargeDoctor },
                new bool[] { false, false, false, false, false });
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            
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

				if(lngRes > 0)
				{
					m_txtTemperature.Text = stuValue.m_strTemperatureValue;
					m_txtPulse.Text = stuValue.m_strPulseValue;
					m_mthSyncPluse(null,EventArgs.Empty);
					m_txtBreath.Text = stuValue.m_strBreathValue;

					try
					{
						if(stuValue.m_strSystolicValue != "")
						{
							if(stuValue.m_strSystolicValue!="" || stuValue.m_strSystolicValue!=null)
							{
								m_txtSys.Text = float.Parse(stuValue.m_strSystolicValue).ToString("0");
							}
							if(stuValue.m_strDiastolicValue!="" || stuValue.m_strDiastolicValue!=null)
							{
								m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue).ToString("0");
							}
						
						}
						else
						{
							if(stuValue.m_strSystolicValue2!="" || stuValue.m_strSystolicValue2!=null)
							{
								m_txtSys.Text = float.Parse(stuValue.m_strSystolicValue2).ToString("0");
							}
							if(stuValue.m_strDiastolicValue2!="" || stuValue.m_strDiastolicValue!=null)
							{
								m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue2).ToString("0");
							}
						}
					}
					catch
					{
					}
		
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
			this.m_txtDia.Text=p_objContent.m_strDia;
			this.m_txtFamilyHistory.Text=p_objContent.m_strFamilyHistory;
			this.m_txtFinallyDiagnose.Text= com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( p_objContent.m_strFinallyDiagnoseAll,p_objContent.m_strFinallyDiagnoseXML);
			this.m_txtLabCheck.Text=p_objContent.m_strLabCheck;
			this.m_txtMainDescription.Text=p_objContent.m_strMainDescription;
			this.m_txtMarriageHistory.Text=p_objContent.m_strMarriageHistory;
			this.m_txtMedical.Text=p_objContent.m_strMedical;
			this.m_txtOwnHistory.Text=p_objContent.m_strOwnHistory;
			this.m_txtPrimaryDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtProfessionalCheck.Text=p_objContent.m_strProfessionalCheck;
			this.m_txtPulse.Text=p_objContent.m_strPulse;
			this.m_txtSummary.Text=p_objContent.m_strSummary;
			this.m_txtSys.Text=p_objContent.m_strSys;
			this.m_txtTemperature.Text=p_objContent.m_strTemperature;
//			this.m_dtpFinallyDiagnoseDate .Text =(p_objContent.m_strFinallyDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strFinallyDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
//			this.m_dtpPrimaryDiagnoseDate .Text =(p_objContent.m_strPrimaryDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
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

		//		private bool m_blnCanOperateDoctorSelect;
		//
		//		private bool m_blnCanChargeDoctorSelect;

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
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					break;

				case 38:
				case 40:
				
					break;	

				
				case 113://save
					this.m_lngSave(); 
					break;
				case 114://del
					this.m_lngDelete(); 
					break;
				case 115://print
					this.m_lngPrint();
					break;
				case 116://refresh
					m_mthClearAll();
					m_mthClearPatientBaseInfo();
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
			if(!m_blnCanDoctorTextChanged)
				return;

			if(p_strDoctorNameLike.Length == 0)
			{
//				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

			if(objDoctorArr == null)
			{
//				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			switch(m_bytListOnDoctor)
			{
				case 0:
//					m_lsvFinallyDiagnoseDocID.Left = m_txtPrimaryDiagnoseDocID.Left ;
//					m_lsvFinallyDiagnoseDocID.Top  = m_txtPrimaryDiagnoseDocID.Top +m_txtPrimaryDiagnoseDocID.Height ;
					break;
				case 1:
//					m_lsvFinallyDiagnoseDocID.Left = m_txtFinallyDiagnoseDocID.Left  ;
//					m_lsvFinallyDiagnoseDocID.Top  = m_txtFinallyDiagnoseDocID.Top +m_txtFinallyDiagnoseDocID.Height ;
					break;
			}			

//			m_lsvFinallyDiagnoseDocID.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

//				m_lsvFinallyDiagnoseDocID.Items.Add(lviDoctor);
			}

			//但显示的行数大于6时，减小最后一列的宽度，以显示滚动条
//			m_mthChangeListViewLastColumnWidth(m_lsvFinallyDiagnoseDocID);

//			m_lsvFinallyDiagnoseDocID.BringToFront();
//			m_lsvFinallyDiagnoseDocID.Visible = true;
		}
		
		private void m_lsvDoctorList_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
//			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
				return;

//			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

//			if(objEmp == null)
//				return;

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
//					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
//					m_txtPrimaryDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
					//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
//					m_txtFinallyDiagnoseDocID .Text = objEmp.m_StrLastName;
//					m_txtFinallyDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
					//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

//			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		private void m_lsvFinallyDiagnoseDocID_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
//			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
//				return;

//			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

//			if(objEmp == null)
//				return;

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
//					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
//					m_txtPrimaryDiagnoseDocID.Tag = (string)objEmp.m_StrEmployeeID;
					//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
//					m_txtFinallyDiagnoseDocID.Text = objEmp.m_StrLastName;
//					m_txtFinallyDiagnoseDocID.Tag =(string)objEmp.m_StrEmployeeID;
					//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

//			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		#endregion
	
		#region 显示/隐藏界面显示
		private void ControlVisableShow(string intControlIndex,int strLocationY)
		{
			foreach(Control control in this.m_pnlContent.Controls )
			{		
				switch(control.GetType().Name)
				{
					case "PictureBox":
						
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{		
						 
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
						}
						break;
					case "Label":
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{		
							string s=control.Name ;
						
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
						}	

						break;
					case "ctlRichTextBox":
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{	
	
                            //m_objBorderTool.m_mthUnChangedControlBorder(control );
						
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
							
                            //if(control.Visible ==true)
                            //    m_objBorderTool.m_mthChangedControlBorder(control );
						}
						break;
					case "ctlTimePicker":
						if(control.Name =="m_dtpPrimaryDiagnoseDate" || control.Name =="m_dtpFinallyDiagnoseDate" )
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
						
						}
						break;
					case"ListView":
						if(control.Name =="m_lsvFinallyDiagnoseDocID" )
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
						
						}
						break;
					case "ctlBorderTextBox" :
						if(control.Name =="m_txtPrimaryDiagnoseDocID" || control.Name =="m_txtFinallyDiagnoseDocID")
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 
						
						}
						break;						
					case "Button" :
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex) && control.Name =="m_cmdGetDovueData")
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y+strLocationY); 							
						}
						break;
				}
			} 

			m_pnlContent.Height +=strLocationY;
			
			
		}

		/// <summary>
		/// 隐藏
		/// </summary>
		/// <param name="strestimate"></param>判断字符串
		private void ControlVisableHide(string intControlIndex,int strLocationY)
		{
			
			foreach(Control control in this.m_pnlContent.Controls )
			{		
				switch(control.GetType().Name)
				{
					case "PictureBox":
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{		
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
						}
						break;
					case "Label":
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{		
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
						}
						break;
					case "ctlRichTextBox":
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{	
							string s=control.Name ;
							//								if(control.Visible =true)
                            //m_objBorderTool.m_mthUnChangedControlBorder(control );
							
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
                            //if(control.Visible ==true)
                            //    m_objBorderTool.m_mthChangedControlBorder(control );
						}
						break;
					case "ctlTimePicker":
						if(control.Name =="m_dtpPrimaryDiagnoseDate" || control.Name =="m_dtpFinallyDiagnoseDate" )
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
							
						}
						break;
					case"ListView":
						if(control.Name =="m_lsvFinallyDiagnoseDocID" )
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
							
						}
						break;
					case "ctlBorderTextBox" :
						if(control.Name =="m_txtPrimaryDiagnoseDocID" || control.Name =="m_txtFinallyDiagnoseDocID")
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
							
						}
						break;
					case "Button" :
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex) && control.Name =="m_cmdGetDovueData")
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
							
						}
						break;
					case "GroupBox" :
						if(int.Parse (control.Tag.ToString())  > int.Parse( intControlIndex))
						{	
							control.Location =new System.Drawing.Point(control.Location.X ,control.Location.Y-strLocationY); 
							
						}
						break;
				}
			} 
			m_pnlContent.Height -=strLocationY;
		}
		private string strGetFilePathHeader()//提取文件绝对路径的上级目录,Jacky-2002-11-30
		{
			string [] strFilePathAll =  Application.ExecutablePath.Split('\\') ;
			string strFilePathHeader="";
			if(strFilePathAll!=null)
				for(int i=0;i<strFilePathAll.Length-3;i++)
					strFilePathHeader+=strFilePathAll[i]+"\\\\";
			return strFilePathHeader;
		}
		
		/// <summary>
		/// 主诉 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_picMainDescription_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableMainDescription)
			{
//				this.pictureBox1.Image=imgUserclose;	
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtMainDescription);
				this.m_txtMainDescription.Visible =false;
				
				this.ControlVisableHide("1",m_txtMainDescription.Height); 

				this.m_bolVisableMainDescription =false;
//				this.m_tip.SetToolTip(this.pictureBox1 ,"显示主诉");  
				this.Refresh();
			}
			else//主诉显示
			{	
					
				m_txtMainDescription.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtMainDescription );
				
				this.ControlVisableShow("1",m_txtMainDescription.Height); 
				
//				this.pictureBox1.Image=imgUseropen;	
				this.m_bolVisableMainDescription =true;
//				this.m_tip.SetToolTip(this.pictureBox1  ,"隐藏主诉");  
				this.Refresh();
			}

			
		}

		/// <summary>
		/// 现病史
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_picCurrentStatus_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableCurrentStatus)
			{
//				this.pictureBox2.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtCurrentStatus);
				this.m_txtCurrentStatus.Visible =false;
				
				this.ControlVisableHide("2",m_txtCurrentStatus.Height ); 

				this.m_bolVisableCurrentStatus =false;
//				this.m_tip.SetToolTip(this.pictureBox2 ,"显示现病史");  
				this.Refresh();
			}
			else//显示
			{	
//				this.pictureBox2.Image=imgUseropen;	
				m_txtCurrentStatus.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtCurrentStatus );
				
				this.ControlVisableShow("2",m_txtCurrentStatus.Height ); 

				this.m_bolVisableCurrentStatus =true;
//				this.m_tip.SetToolTip(this.pictureBox2 ,"隐藏现病史");  
				this.Refresh();
			}

		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableBeforetimeStatus)
			{
//				this.pictureBox3.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtBeforetimeStatus);
				this.m_txtBeforetimeStatus.Visible =false;
				
				this.ControlVisableHide("3",m_txtBeforetimeStatus.Height ); 

				this.m_bolVisableBeforetimeStatus =false;
//				this.m_tip.SetToolTip(this.pictureBox3 ,"显示过去史");  
				this.Refresh();
			}
			else//显示
			{	
//				this.pictureBox3.Image=imgUseropen;	
				m_txtBeforetimeStatus.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtBeforetimeStatus);
				
				this.ControlVisableShow("3",m_txtBeforetimeStatus.Height ); 

				this.m_bolVisableBeforetimeStatus =true;
//				this.m_tip.SetToolTip(this.pictureBox3 ,"隐藏过去史");  
				this.Refresh();
			}
		}

		private void m_lblOwnHistory_Click(object sender, System.EventArgs e)
		{
//			if(m_bolVisableOwnHistory)
//			{
//				this.m_lblOwnHistory.Image=imgUserclose;
//				m_objBorderTool.m_mthUnChangedControlBorder(m_txtOwnHistory);
//				this.m_txtOwnHistory.Visible =false;
//				
//				this.ControlVisableHide("4",m_txtOwnHistory.Height ); 
//
//				this.m_bolVisableOwnHistory =false;
//				this.m_tip.SetToolTip(this.m_lblOwnHistory ,"显示个人史");  
//				this.Refresh();
//			}
//			else//显示
//			{	
//				this.m_lblOwnHistory.Image=imgUseropen;	
//				m_txtOwnHistory.Visible=true;
//				m_objBorderTool.m_mthChangedControlBorder(m_txtOwnHistory);
//				
//				this.ControlVisableShow("4",m_txtOwnHistory.Height ); 
//
//				this.m_bolVisableOwnHistory =true;
//				this.m_tip.SetToolTip(this.m_lblOwnHistory ,"隐藏个人史");  
//				this.Refresh();
//			}
		}

		private void pictureBox4_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableMarriageHistory)
			{
//				this.pictureBox4.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtMarriageHistory);
				this.m_txtMarriageHistory.Visible =false;
				
				this.ControlVisableHide("5",m_txtMarriageHistory.Height ); 

				this.m_bolVisableMarriageHistory =false;
//				this.m_tip.SetToolTip(this.pictureBox4 ,"显示婚姻史");  
				this.Refresh();
			}
			else//显示
			{	
//				this.pictureBox4.Image=imgUseropen;	
				m_txtMarriageHistory.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtMarriageHistory);
				
				this.ControlVisableShow("5",m_txtMarriageHistory.Height ); 

				this.m_bolVisableMarriageHistory=true;
//				this.m_tip.SetToolTip(this.pictureBox4 ,"隐藏婚姻史");  
				this.Refresh();
			}
		}

		private void pictureBox5_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableCatameniaHistory)
			{
//				this.pictureBox5.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtCatameniaHistory);
				this.m_txtCatameniaHistory.Visible =false;
				
				this.ControlVisableHide("6",m_txtCatameniaHistory.Height ); 

				this.m_bolVisableCatameniaHistory =false;
//				this.m_tip.SetToolTip(this.pictureBox5 ,"显示月经史");  
				this.Refresh();
			}
			else//显示
			{	
//				this.pictureBox5.Image=imgUseropen;	
				m_txtCatameniaHistory.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtCatameniaHistory);
				
				this.ControlVisableShow("6",m_txtCatameniaHistory.Height ); 

				this.m_bolVisableCatameniaHistory=true;
//				this.m_tip.SetToolTip(this.pictureBox5 ,"隐藏月经史");  
				this.Refresh();
			}
		}

//		private void pictureBox6_Click(object sender, System.EventArgs e)
//		{
//			if(m_bolVisableFamilyHistory)
//			{
//				this.pictureBox6.Image=imgUserclose;
//				m_objBorderTool.m_mthUnChangedControlBorder(m_txtFamilyHistory);
//				this.m_txtFamilyHistory.Visible =false;
//				
//				this.ControlVisableHide("7",m_txtFamilyHistory.Height ); 
//
//				this.m_bolVisableFamilyHistory =false;
//				this.m_tip.SetToolTip(this.pictureBox6,"显示家族史");  
//				this.Refresh();
//			}
//			else//显示
//			{	
//				this.pictureBox6.Image=imgUseropen;	
//				m_txtFamilyHistory.Visible=true;
//				m_objBorderTool.m_mthChangedControlBorder(m_txtFamilyHistory);
//				
//				this.ControlVisableShow("7",m_txtFamilyHistory.Height ); 
//
//				this.m_bolVisableFamilyHistory=true;
//				this.m_tip.SetToolTip(this.pictureBox6 ,"隐藏家族史");  
//				this.Refresh();
//			}
//		}

		private void m_picMedical_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableMedical)
			{
                //this.m_picMedical.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtMedical);
				this.m_txtMedical.Visible =false;
				
				this.ControlVisableHide("8",m_txtMedical.Height ); 

				this.m_bolVisableMedical=false;
				this.m_tip.SetToolTip(this.m_picMedical,"显示体格检查");  
				this.Refresh();
			}
			else//显示
			{	
                //this.m_picMedical.Image=imgUseropen;	
				m_txtMedical.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtMedical);
				
				this.ControlVisableShow("8",m_txtMedical.Height ); 

				this.m_bolVisableMedical=true;
				this.m_tip.SetToolTip(this.m_picMedical ,"隐藏体格检查");  
				this.Refresh();
			}
		}

		private void pictureBox9_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableProfessionalCheck)
			{
                //this.pictureBox9.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtProfessionalCheck);
				this.m_txtProfessionalCheck.Visible =false;
				
				this.ControlVisableHide("9",m_txtProfessionalCheck.Height ); 

				this.m_bolVisableProfessionalCheck=false;
				this.m_tip.SetToolTip(this.pictureBox9,"显示专科检查");  
				this.Refresh();
			}
			else//显示
			{	
                //this.pictureBox9.Image=imgUseropen;
				m_txtProfessionalCheck.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtProfessionalCheck);
				
				this.ControlVisableShow("9",m_txtProfessionalCheck.Height ); 

				this.m_bolVisableProfessionalCheck=true;
				this.m_tip.SetToolTip(this.pictureBox9,"隐藏专科检查");  
				this.Refresh();
			}
		}

		private void m_picLabCheck_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableLabCheck)
			{
                //this.m_picLabCheck.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtLabCheck);
				this.m_txtLabCheck.Visible =false;
				
				this.ControlVisableHide("10",m_txtLabCheck.Height ); 

				this.m_bolVisableLabCheck=false;
				this.m_tip.SetToolTip(this.m_picLabCheck,"显示实验室及特殊检查");  
				this.Refresh();
			}
			else//显示
			{	
                //this.m_picLabCheck.Image=imgUseropen;
				m_txtLabCheck.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtLabCheck);
				
				this.ControlVisableShow("10",m_txtLabCheck.Height ); 

				this.m_bolVisableLabCheck=true;
				this.m_tip.SetToolTip(this.m_picLabCheck,"隐藏实验室及特殊检查");  
				this.Refresh();
			}
		}

		private void pictureBox7_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableSummary)
			{
//				this.pictureBox7.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtSummary);
				this.m_txtSummary.Visible =false;
				
				this.ControlVisableHide("11",m_txtSummary.Height ); 

				this.m_bolVisableSummary=false;
//				this.m_tip.SetToolTip(this.pictureBox7,"显示摘要");  
				this.Refresh();
			}
			else//显示
			{	
//				this.pictureBox7.Image=imgUseropen;
				m_txtSummary.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtSummary);
				
				this.ControlVisableShow("11",m_txtSummary.Height ); 

				this.m_bolVisableSummary=true;
//				this.m_tip.SetToolTip(this.pictureBox7,"隐藏摘要");  
				this.Refresh();
			}
		}

		private void pictureBox10_Click(object sender, System.EventArgs e)
		{
			if(m_bolVisableDiagnose)
			{
                //this.pictureBox10.Image=imgUserclose;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtPrimaryDiagnose );
				this.m_txtPrimaryDiagnose.Visible =false;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_txtFinallyDiagnose);
				this.m_txtFinallyDiagnose.Visible =false;
				this.lblFinallyDiagnose.Visible=false;

				this.ControlVisableHide("12",m_txtPrimaryDiagnose.Height ); 
//				this.lblPrimaryDiagnoseDate.Location =new System.Drawing.Point(lblPrimaryDiagnoseDate.Location.X ,lblPrimaryDiagnoseDate.Location.Y -this.m_txtPrimaryDiagnose.Height ); 	
				this.lblFinallyDiagnose .Location =new System.Drawing.Point(lblFinallyDiagnose.Location.X ,lblFinallyDiagnose.Location.Y -this.m_txtPrimaryDiagnose.Height ); 	
//				this.m_cmdFinallyDiagnoseDocID .Location =new System.Drawing.Point(m_cmdFinallyDiagnoseDocID.Location.X ,m_cmdFinallyDiagnoseDocID.Location.Y -this.m_txtPrimaryDiagnose.Height ); 	
//				this.lblFinallyDiagnoseDate.Location =new System.Drawing.Point(lblFinallyDiagnoseDate.Location.X ,lblFinallyDiagnoseDate.Location.Y -this.m_txtPrimaryDiagnose.Height ); 	
//				this.m_cmdPrimaryDiagnoseDocID.Location =new System.Drawing.Point(m_cmdPrimaryDiagnoseDocID.Location.X ,m_cmdPrimaryDiagnoseDocID.Location.Y -this.m_txtPrimaryDiagnose.Height ); 	
				
				this.m_bolVisableDiagnose=false;
				this.m_tip.SetToolTip(this.pictureBox10,"显示诊断");  
				this.Refresh();
			}
			else//显示
			{	
                //this.pictureBox10.Image=imgUseropen;
				m_txtPrimaryDiagnose.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtPrimaryDiagnose);
				m_txtFinallyDiagnose.Visible=true;
                //m_objBorderTool.m_mthChangedControlBorder(m_txtFinallyDiagnose);
				this.lblFinallyDiagnose.Visible=true;
				this.ControlVisableShow("12",m_txtPrimaryDiagnose.Height ); 
				
//				this.lblPrimaryDiagnoseDate.Location =new System.Drawing.Point(lblPrimaryDiagnoseDate.Location.X ,lblPrimaryDiagnoseDate.Location.Y +this.m_txtPrimaryDiagnose.Height ); 	
				this.lblFinallyDiagnose .Location =new System.Drawing.Point(lblFinallyDiagnose.Location.X ,lblFinallyDiagnose.Location.Y +this.m_txtPrimaryDiagnose.Height ); 	
//				this.m_cmdFinallyDiagnoseDocID .Location =new System.Drawing.Point(m_cmdFinallyDiagnoseDocID.Location.X ,m_cmdFinallyDiagnoseDocID.Location.Y +this.m_txtPrimaryDiagnose.Height ); 	
//				this.lblFinallyDiagnoseDate .Location =new System.Drawing.Point(lblFinallyDiagnoseDate.Location.X ,lblFinallyDiagnoseDate.Location.Y +this.m_txtPrimaryDiagnose.Height ); 	
//				this.m_cmdPrimaryDiagnoseDocID.Location =new System.Drawing.Point(m_cmdPrimaryDiagnoseDocID.Location.X ,m_cmdPrimaryDiagnoseDocID.Location.Y +this.m_txtPrimaryDiagnose.Height ); 	
				
				this.m_bolVisableDiagnose=true;
				this.m_tip.SetToolTip(this.pictureBox10,"隐藏诊断");  
				this.Refresh();
			}
		}

		#endregion 显示/隐藏界面显示
        
		private void m_cboCatameniaCase_IndexChanged(object sender,EventArgs e)
		{
			m_dtpLastCatameniaTime.Enabled = !m_cboCatameniaCase.Text.Trim().Equals("已绝经");
		}
		
		private void m_mthDoctorListControl(object sender,EventArgs e)
		{
			/*
			 * 控制选择医生的ListView是否隐藏
			 */
			try
			{
				switch(m_bytListOnDoctor)
				{
					case 0:
//						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtPrimaryDiagnoseDocID.Focused)
//						{
//							m_lsvFinallyDiagnoseDocID.Visible=false;
//						}
						break;
					case 1:
//						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtFinallyDiagnoseDocID.Focused)
//						{
////							m_lsvFinallyDiagnoseDocID.Visible=false;
//						}
						break;
				}
			}
			catch{}
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
				if(strResultArr[3]!=null)
				{
					this.m_txtSys.Text=strResultArr[3];
				}
				if(strResultArr[4]!=null )
				{
					this.m_txtDia.Text=strResultArr[4];
				}
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
			TreeNode tndInPatientDate=new TreeNode();
			tndInPatientDate.Text ="入院日期";
			this.trvTime.Nodes.Add(tndInPatientDate); 
			m_mthSetQuickKeys();

			m_dtpCreateDate.m_EnmVisibleFlag  = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			m_dtpCreateDate.m_mthResetSize();

			m_txtMainDescription.Focus();
			new clsPublicFunction().m_mthSetControlEnter2Tab(new Control[]{m_txtTemperature,m_txtPulse,m_txtBreath,m_txtSys,m_txtDia,m_txtMainDescription});
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
		/// 隐藏月经生育史项目
		/// </summary>
		private void m_mthHideCatameniaItem()
		{
			m_txtCatameniaHistory.m_mthClearText();
			this.m_cboFirstCatamenia.Text = "";
			this.m_cboCatameniaLastTime.Text = "";
			this.m_cboCatameniaCycle.Text ="" ;
			this.m_cboCatameniaCase.Text = "";
            m_chkCatamenia.Enabled = false;
            m_grbCatamenia.Enabled = false;
            //m_objBorderTool.m_mthUnChangedControlBorder(m_txtCatameniaHistory);

			int intVSpace = m_grbCatamenia.Height;
            //foreach(Control ctlSub in tabPage1.Controls)
            //    if(ctlSub.Top > m_grbCatamenia.Top)
            //        ctlSub.Top -= intVSpace;
		}

		/// <summary>
		/// 隐藏婚姻史项目
		/// </summary>
		private void m_mthHideMarry()
		{
			m_txtMarriageHistory.m_mthClearText();
            m_txtMarriageHistory.Enabled = false;
            m_lklMarriageHistory.Enabled = false;
            m_txtMarriageHistory.Text = "未婚。";
            //m_objBorderTool.m_mthUnChangedControlBorder(m_txtMarriageHistory);

			int intVSpace = m_txtMarriageHistory.Bottom - m_lklMarriageHistory.Top+8;
            //foreach(Control ctlSub in tabPage1.Controls)
            //    if(ctlSub.Top > m_txtMarriageHistory.Top)
            //        ctlSub.Top -= intVSpace;
		}

		/// <summary>
		/// 设置产科入院诊断以及主治医师签名的的位置
		/// </summary>
		/// <param name="p_blnLeftOff"></param>
		private void m_mthSetPrimaryDiagnoseItem()
		{
			m_txtPrimaryDiagnose.Location = new System.Drawing.Point(16,m_txtPrimaryDiagnose.Location.Y);
			m_lklPrimaryDiagnose.Location = new System.Drawing.Point(16,m_lklPrimaryDiagnose.Location.Y);
//			m_cmdChargeDoc.Location = new System.Drawing.Point(500,m_cmdChargeDoc.Location.Y);
//			m_txtChargeDoc.Location = new System.Drawing.Point(596,m_txtChargeDoc.Location.Y);
		}
		/// <summary>
		/// 设置治疗计划项目的显示
		/// </summary>
		/// <param name="p_blnHide"></param>
		private void m_mthSetCarePlanVisible()
		{
//			m_txtCareplan.Visible = true;
			m_lblCarePlan.Visible = true;
		}
		/// <summary>
		/// 设置孕次和产次的显示
		/// </summary>
		/// <param name="p_blnHide"></param>
		private void m_mthSetPergAndBornVisible()
		{
//			m_cboPregTimes.Visible = true;
//			m_lblPreg.Visible = true;
//			m_lblPergCount.Visible = true;
//			m_cboBornTimes.Visible = true;
//			m_lblBorn.Visible = true;
//			m_lblBornCount.Visible = true;
		}
		/// <summary>
		/// 设置医师签名的显示
		/// </summary>
		/// <param name="p_blnHide"></param>
		private void m_mthSetDocVisible(bool p_blnHide)
		{
//			m_cmdChargeDoc.Visible = true;
//			m_txtChargeDoc.Visible = true;
//			m_cmdDirectorDoc.Visible = !p_blnHide;
//			m_txtDirectorDoc.Visible = !p_blnHide;
//			m_cmdMidwife.Visible = p_blnHide;
//			m_txtMidwife.Visible = p_blnHide;
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

		private void m_cboPregTimes_DropDown(object sender, System.EventArgs e)
		{
//			m_cboPregTimes.ClearItem();
//			for(int i=1; i<=4; i++)
//			{
//				m_cboPregTimes.AddItem(i.ToString());
//			}
		}

//		private void m_cboBornTimes_DropDown(object sender, System.EventArgs e)
//		{
//			m_cboBornTimes.ClearItem();
//			for(int i=1; i<=4; i++)
//			{
//				m_cboBornTimes.AddItem(i.ToString());
//			}
//		}

		private void frmInPatientCaseHistory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MDIParent.m_EnmCaseType = frmInPatientCaseHistory.enmCaseType.默认;
		}

		#region Alex Mark 2003-5-16

		//		// 设置是否控制修改（修改留痕迹）。
		//		protected override void m_mthSetModifyControl(clsInPatientCaseHistoryContent p_objRecordContent,
		//			bool p_blnReset)
		//		{
		//			if(p_objRecordContent==null)
		//				return ;
		//
		//			clsBaseCaseHistoryInfo m_objBaseInfo = (clsBaseCaseHistoryInfo)p_objRecordContent;
		//			if(p_blnReset==false)
		//			{
		//				this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtBreath.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtCurrentStatus.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtDia.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtFamilyHistory.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtLabCheck.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtMainDescription.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtMarriageHistory.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtMedical.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtOwnHistory.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtProfessionalCheck.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtPulse.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtSummary.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtTemperature.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtSys.m_ClrOldPartInsertText = Color.Red;
		//				this.m_txtCatameniaHistory .m_ClrOldPartInsertText = Color.Red;
		//			}
		//			else
		//			{
		//				this.m_txtBeforetimeStatus.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtBreath.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtCurrentStatus.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtDia.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtFamilyHistory.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtFinallyDiagnose.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtLabCheck.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtMainDescription.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtMarriageHistory.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtMedical.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtOwnHistory.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtPrimaryDiagnose.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtProfessionalCheck.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtPulse.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtSummary.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtTemperature.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtSys.m_ClrOldPartInsertText = Color.White;
		//				this.m_txtCatameniaHistory .m_ClrOldPartInsertText = Color.White;
		//			}
		//
		//			if(m_objBaseInfo.m_strModifyUserID == MDIParent.OperatorID)
		//			{
		//				m_txtBeforetimeStatus.m_BlnCanModifyLast = true;
		//				this.m_txtBreath.m_BlnCanModifyLast = true;
		//				this.m_txtCurrentStatus.m_BlnCanModifyLast = true;
		//				this.m_txtDia.m_BlnCanModifyLast = true;
		//				this.m_txtFamilyHistory.m_BlnCanModifyLast = true;
		//				this.m_txtFinallyDiagnose.m_BlnCanModifyLast = true;
		//				this.m_txtLabCheck.m_BlnCanModifyLast = true;
		//				this.m_txtMainDescription.m_BlnCanModifyLast = true;
		//				this.m_txtMarriageHistory.m_BlnCanModifyLast = true;
		//				this.m_txtMedical.m_BlnCanModifyLast = true;
		//				this.m_txtOwnHistory.m_BlnCanModifyLast = true;
		//				this.m_txtPrimaryDiagnose.m_BlnCanModifyLast = true;
		//				this.m_txtProfessionalCheck.m_BlnCanModifyLast = true;
		//				this.m_txtPulse.m_BlnCanModifyLast = true;
		//				this.m_txtSummary.m_BlnCanModifyLast = true;
		//				this.m_txtTemperature.m_BlnCanModifyLast = true;
		//				this.m_txtSys.m_BlnCanModifyLast = true;
		//				this.m_txtCatameniaHistory.m_BlnCanModifyLast = true;
		//			}
		//			else
		//			{
		//				m_txtBeforetimeStatus.m_BlnCanModifyLast = false;
		//				this.m_txtBreath.m_BlnCanModifyLast = false;
		//				this.m_txtCurrentStatus.m_BlnCanModifyLast = false;
		//				this.m_txtDia.m_BlnCanModifyLast = false;
		//				this.m_txtFamilyHistory.m_BlnCanModifyLast = false;
		//				this.m_txtFinallyDiagnose.m_BlnCanModifyLast = false;
		//				this.m_txtLabCheck.m_BlnCanModifyLast = false;
		//				this.m_txtMainDescription.m_BlnCanModifyLast = false;
		//				this.m_txtMarriageHistory.m_BlnCanModifyLast = false;
		//				this.m_txtMedical.m_BlnCanModifyLast = false;
		//				this.m_txtOwnHistory.m_BlnCanModifyLast = false;
		//				this.m_txtPrimaryDiagnose.m_BlnCanModifyLast = false;
		//				this.m_txtProfessionalCheck.m_BlnCanModifyLast = false;
		//				this.m_txtPulse.m_BlnCanModifyLast = false;
		//				this.m_txtSummary.m_BlnCanModifyLast = false;
		//				this.m_txtTemperature.m_BlnCanModifyLast = false;
		//				this.m_txtSys.m_BlnCanModifyLast = false;
		//				this.m_txtCatameniaHistory.m_BlnCanModifyLast = false;
		//			}
		//		}
		#endregion

		#region 显示专科病历
		/// <summary>
		/// 显示妇产科病历
		/// </summary>
		private void m_mthShowGynecologic()
		{
			if(m_enmCaseType == enmCaseType.妇科)//如果是妇科
			{
				m_mthSetDocVisible(false);
			}
			else if(m_enmCaseType == enmCaseType.产科)//如果是产科
			{
				m_mthHideItem(m_txtOwnHistory,m_lklOwnHistory);
				m_mthSetPrimaryDiagnoseItem();
				m_mthSetCarePlanVisible();
				m_mthSetPergAndBornVisible();
				m_mthSetDocVisible(true);
			}
		}

		/// <summary>
		/// 根据病人情况隐藏一些项目
		/// </summary>
		private void m_mthHideSomeItem(clsPatient p_objPatient)
		{
			if(p_objPatient == null)
				return;

            if (p_objPatient.m_ObjPeopleInfo.m_StrSex == "男")
                m_mthHideCatameniaItem();
            else
            {
                m_chkCatamenia.Enabled = true;
                m_grbCatamenia.Enabled = true;
            }
            if (p_objPatient.m_ObjPeopleInfo.m_StrMarried == "未婚")
                m_mthHideMarry();
            else
            {
                m_txtMarriageHistory.Enabled = true;
                m_lklMarriageHistory.Enabled = true;
            }
		}

		#endregion 			

		private void m_mthInvokeTemplate(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_objValue)
		{
			frmInvokeTemplateByICD10 frmTemp=new frmInvokeTemplateByICD10(p_objValue,this,true,m_txtPrimaryDiagnose);
			frmTemp.ShowDialog();
		}

		private void m_cmdCreateID_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_pnlContent_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void m_grbCatamenia_Enter(object sender, System.EventArgs e)
		{
		
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

		/// <summary>
		/// 住院病历类型
		/// </summary>
		public enum enmCaseType
		{
			默认 = 1,
			产科,
			妇科
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

				case "m_lklLabCheck":
					m_mth(m_txtLabCheck);
					break;
				case "m_lklPrimaryDiagnose":
					m_mth(m_txtPrimaryDiagnose);
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
            if (this.m_txtSys.Text.Trim() != string.Empty && this.m_txtSys.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtSys.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        +this.m_txtSys.AccessibleDescription
                        +"须为数字！");
                    return false;
                }
            }
            if (this.m_txtDia.Text.Trim() != string.Empty && this.m_txtDia.m_strGetRightText() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_txtDia.m_strGetRightText(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("体格检查中的"
                        + this.m_txtDia.AccessibleDescription
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

		private void tabControl2_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmInPatientCaseHistory_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

        protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            base.trvTime_AfterSelect(sender,e);

            this.m_thtxtModifydiagnose.m_ClrOldPartInsertText = Color.Red;
            this.m_thtxtaddDiagnose.m_ClrOldPartInsertText = Color.Red;
        }

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            base.m_mthPerformSessionChanged(p_objSelectedSession, p_intIndex);

            if (m_thtxtaddDiagnose != null && m_thtxtModifydiagnose != null)
            {
                this.m_thtxtModifydiagnose.m_ClrOldPartInsertText = Color.Red;
                this.m_thtxtaddDiagnose.m_ClrOldPartInsertText = Color.Red;
            }
        }

        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            base.m_mthSetPatientFormInfo(p_objSelectedPatient);

            m_mthHideSomeItem(p_objSelectedPatient);
        }
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
                this.m_txtDia.Text = p_objContent.m_strDia;
                this.m_txtFamilyHistory.Text = p_objContent.m_strFamilyHistory;
                this.m_txtFinallyDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strFinallyDiagnoseAll, p_objContent.m_strFinallyDiagnoseXML);
                this.m_txtLabCheck.Text = p_objContent.m_strLabCheck;
                this.m_txtMainDescription.Text = p_objContent.m_strMainDescription;
                this.m_txtMarriageHistory.Text = p_objContent.m_strMarriageHistory;
                this.m_txtMedical.Text = p_objContent.m_strMedical;
                this.m_txtOwnHistory.Text = p_objContent.m_strOwnHistory;
                this.m_txtPrimaryDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(p_objContent.m_strPrimaryDiagnoseAll, p_objContent.m_strPrimaryDiagnoseXML);
                this.m_txtProfessionalCheck.Text = p_objContent.m_strProfessionalCheck;
                this.m_txtPulse.Text = p_objContent.m_strPulse;
                this.m_txtSummary.Text = p_objContent.m_strSummary;
                this.m_txtSys.Text = p_objContent.m_strSys;
                this.m_txtTemperature.Text = p_objContent.m_strTemperature;
                this.m_cboCredibility.Text = p_objContent.m_strCredibility;
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
                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一
            {
                objPrintTool = new clsInPatientCaseHistoryPrintTool();
            }
            else// if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                objPrintTool = new clsInPatientCaseHistory_GXPrintTool();
            }
            //else//其他
            //{
            //    objPrintTool = new clsInPatientCaseHistory_F2PrintTool();
            //}

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

                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

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
    }
	
}

