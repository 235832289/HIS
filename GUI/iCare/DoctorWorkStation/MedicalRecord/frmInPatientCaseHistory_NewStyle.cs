using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
	public class frmInPatientCaseHistory_NewStyle : frmBaseCaseHistory
	{
		#region Varialbe
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
		protected System.Windows.Forms.Label lblFinallyDiagnose;
		private System.Windows.Forms.ListView m_lsvFinallyDiagnoseDocID;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFinallyDiagnoseDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpPrimaryDiagnoseDate;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPrimaryDiagnoseDocID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFinallyDiagnoseDocID;
		protected System.Windows.Forms.Label lblPrimaryDiagnoseDate;
        private System.Windows.Forms.Label lblFinallyDiagnoseDate;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button m_cmdFinallyDiagnoseDocID;
		private System.Windows.Forms.Button m_cmdPrimaryDiagnoseDocID;
        private clsEmployeeSignTool m_objSignTool;
        private System.Windows.Forms.GroupBox groupBox1;
		private clsCommonUseToolCollection m_objCUTC;
        //private Bitmap imgUserclose;
        //private Bitmap imgUseropen;
		private string m_strMedicalExam_ID = "";
		private string m_strCurrentOpenDate = "";
		private clsThreeMeasureShareDomain	m_objShareDomain = new clsThreeMeasureShareDomain();
		private frmMedicalExam001 m_objMedicalExamForm = new frmMedicalExam001 ();		//刘颖源，结构化检查
        private clsMedicalExamDomain m_objMedicalExamDomain = new clsMedicalExamDomain();
		private System.Windows.Forms.Label lblInPatientDate;
		private System.Windows.Forms.LinkLabel m_lklRecorder;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.LinkLabel m_lklInPatientDate;
		private System.Windows.Forms.Label m_lblPergCount;
		protected System.Windows.Forms.Label m_lblPreg;
		protected System.Windows.Forms.Label m_lblBorn;
		private System.Windows.Forms.Label m_lblBornCount;
//		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPregTimes;
//		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBornTimes;
//		protected System.Windows.Forms.Label m_lblLCQK;
//		protected com.digitalwave.controls.ctlRichTextBox m_txtLCQK;
//		protected System.Windows.Forms.Label m_lblYJS;
//		protected com.digitalwave.controls.ctlRichTextBox m_txtYJS;
//		protected System.Windows.Forms.Label m_lblShYS;
//		protected com.digitalwave.controls.ctlRichTextBox m_txtShYS;
//		protected System.Windows.Forms.Label m_lblCQJC;
        //		protected com.digitalwave.controls.ctlRichTextBox m_txtCQJC;
		protected System.Windows.Forms.Label m_lblContraHistory;
//		protected com.digitalwave.controls.ctlRichTextBox m_txtContraHistory;
//		protected com.digitalwave.controls.ctlRichTextBox m_txtOldMaternitySuffer;
		protected System.Windows.Forms.Label m_lblOldMaternitySuffer;
        private System.Windows.Forms.Button m_cmdGetDovueData;
//		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtChargeDoc;
        //		protected com.digitalwave.controls.ctlRichTextBox m_txtCareplan;
//		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDirectorDoc;
//		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMidwife;
		private System.Windows.Forms.Button m_cmdMidwife;
        protected com.digitalwave.controls.ctlRichTextBox m_txtSummary;
		private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox m_picRB;
        private System.Windows.Forms.Label m_lblArea;

		/// <summary>
		/// 关键字哈希表
		/// </summary>
		private Hashtable m_hasKeyword;
        private com.digitalwave.Utility.Controls.ctlCheckedListBox m_ctlCheckedList;
		private System.Windows.Forms.Label m_lblPhone;
        protected com.digitalwave.controls.ctlRichTextBox m_txtFinallyDiagnose_1;
        protected com.digitalwave.controls.ctlRichTextBox m_txtFinallyDiagnose;
        private TextBox txtSign;
        private CheckBox m_chkCatamenia;
        protected com.digitalwave.controls.ctlRichTextBox m_txtCurrentStatus;
        private Label m_lblMedicineCheckTitle;
        protected com.digitalwave.controls.ctlRichTextBox m_txtOwnHistory;
        protected com.digitalwave.controls.ctlRichTextBox m_txtBeforetimeStatus;
        protected com.digitalwave.controls.ctlRichTextBox m_txtPulse;
        protected com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
        protected com.digitalwave.controls.ctlRichTextBox m_txtFamilyHistory;
        protected com.digitalwave.controls.ctlRichTextBox m_txtMarriageHistory;
        protected com.digitalwave.controls.ctlRichTextBox m_txtSys;
        protected com.digitalwave.controls.ctlRichTextBox m_txtBreath;
        protected Label lblSys;
        private Label label17;
        private Label label18;
        private Label label19;
        private Panel m_pnlCatamenia;
        private Label label1;
        private Label label13;
        protected ctlComboBox m_cboFirstCatamenia;
        private Label label14;
        protected ctlComboBox m_cboCatameniaLastTime;
        private Label label15;
        protected ctlComboBox m_cboCatameniaCycle;
        public ctlTimePicker m_dtpLastCatameniaTime;
        protected ctlComboBox m_cboCatameniaCase;
        protected com.digitalwave.controls.ctlRichTextBox m_txtCatameniaHistory;
        private LinkLabel m_lklCatamenia;
        private Panel pnlFocus;
        protected Label label10;
        private LinkLabel m_lklMainDescription;
        private LinkLabel m_lklCurrentStatus;
        private LinkLabel m_lklBeforetimeStatus;
        private LinkLabel m_lklMarriageHistory;
        private LinkLabel m_lklOwnHistory;
        private LinkLabel m_lklFamilyHistory;
        private LinkLabel linkLabel7;
        private LinkLabel linkLabel8;
        private LinkLabel linkLabel9;
        private LinkLabel linkLabel10;
        private Label m_lblCatameniaBorn;
        private TextBox m_txtDirectorDoc;
        private TextBox m_txtChargeDoc;
        private LinkLabel m_cmdChargeDoc;
        private LinkLabel m_cmdDirectorDoc;
        protected Panel m_pnlContent1;
		private Control m_ctlTarget;
		#endregion FormDefines
        private Label label7;
        private RadioButton m_rdbLastCatameniaTime;
        private RadioButton m_rdbAmeniaAge;
        protected ctlComboBox m_cboAmeniaAge;
        private Label m_lblLastCatameniaTime;
        private LinkLabel linkLabel33;
        private FlowLayoutPanel m_pnlContent;
        protected com.digitalwave.controls.ctlRichTextBox m_txtMainDescription;
        protected com.digitalwave.controls.ctlRichTextBox m_txtDia;
        protected Label label8;
        private LinkLabel m_lklMedical;
        protected com.digitalwave.controls.ctlRichTextBox m_txtMedical;
        private LinkLabel m_lklProfessionalCheck;
        protected com.digitalwave.controls.ctlRichTextBox m_txtProfessionalCheck;
        private ctlPaintContainer ctlPaintContainer1;
        private LinkLabel linkLabel3;
        private LinkLabel m_lklLabCheck;
        protected com.digitalwave.controls.ctlRichTextBox m_txtLabCheck;
        private LinkLabel m_lklPrimaryDiagnose;
        protected com.digitalwave.controls.ctlRichTextBox m_txtPrimaryDiagnose;
        private LinkLabel m_lklModifyDiagnose;
        private LinkLabel m_cmdModifyDiagnoseDoctor;
        private TextBox m_txtModifyDiagnoseDoctor;
        private Label label2;
        public ctlTimePicker m_dtpModifyDiagnoseDate;
        private Label label5;
        private LinkLabel m_lklAddDiagnose;
        protected com.digitalwave.controls.ctlRichTextBox m_thtxtaddDiagnose;
        private LinkLabel m_cmdAddDiagnoseDoctor;
        private TextBox m_txtAddDiagnoseDoctor;
        private Label label3;
        public ctlTimePicker m_dtpAddDiagnoseDate;
        private Label label6;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        protected com.digitalwave.controls.ctlRichTextBox m_thtxtModifydiagnose;

        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		public frmInPatientCaseHistory_NewStyle()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                m_cmdDirectorDoc.Visible = true;
                m_txtDirectorDoc.Visible = true;
                m_cmdChargeDoc.Visible = true;
                m_txtChargeDoc.Visible = true;
                label7.Visible = true;
            }

            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440605001")//佛二
            {
                m_rdbAmeniaAge.Visible = true;
                m_rdbLastCatameniaTime.Visible = true;
                m_cboAmeniaAge.Visible = true;
                m_lblLastCatameniaTime.Visible = false;
            }
            else
            {
                m_rdbAmeniaAge.Visible = false;
                m_rdbLastCatameniaTime.Visible = false;
                m_cboAmeniaAge.Visible = false;
                m_lblLastCatameniaTime.Visible = true;
            }
			m_cboCatameniaCase.SelectedIndexChanged += new EventHandler(m_cboCatameniaCase_IndexChanged);			
			m_blnCanDoctorTextChanged = true;

		 
            //imgUserclose = new Bitmap(strGetFilePathHeader()+"picture\\"+ "CLSDFOLD.ICO");
            //imgUseropen= new Bitmap(strGetFilePathHeader()+"picture\\"+ "OPENFOLD.ICO");
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthUnEnableRichTextBox();

			m_txtPrimaryDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);
			m_txtFinallyDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);
			m_lsvFinallyDiagnoseDocID.LostFocus += new EventHandler(m_mthDoctorListControl);
           
            #region 新通用签名
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse,员工ID);
            //记录者签名
            m_objSign.m_mthBindEmployeeSign(m_lklRecorder, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //修正医师
            m_objSign.m_mthBindEmployeeSign(m_cmdModifyDiagnoseDoctor, m_txtModifyDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //补充医师
            m_objSign.m_mthBindEmployeeSign(m_cmdAddDiagnoseDoctor, m_txtAddDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主任医师
            m_objSign.m_mthBindEmployeeSign(m_cmdDirectorDoc, m_txtDirectorDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主治医师
            m_objSign.m_mthBindEmployeeSign(m_cmdChargeDoc, m_txtChargeDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);


            #endregion
			m_txtPulse.LostFocus += new EventHandler(m_mthSyncPluse);

			m_mthSetItemVisible();
			this.Name = "frmInPatientCaseHistory";
			m_objHighLight = new ctlHighLightFocus(Color.White);

            m_mthSetRTBEvent(m_pnlContent);
            //m_mthSetLinkLabelEvent(m_pnlContent);			
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
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInPatientCaseHistory_NewStyle));
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
            this.m_txtFinallyDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdMidwife = new System.Windows.Forms.Button();
            this.m_cmdGetDovueData = new System.Windows.Forms.Button();
            this.m_lblContraHistory = new System.Windows.Forms.Label();
            this.m_lblOldMaternitySuffer = new System.Windows.Forms.Label();
            this.m_lblPergCount = new System.Windows.Forms.Label();
            this.m_lblPreg = new System.Windows.Forms.Label();
            this.m_lblBorn = new System.Windows.Forms.Label();
            this.m_lblBornCount = new System.Windows.Forms.Label();
            this.lblFinallyDiagnose = new System.Windows.Forms.Label();
            this.m_cmdPrimaryDiagnoseDocID = new System.Windows.Forms.Button();
            this.lblPrimaryDiagnoseDate = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.m_cmdFinallyDiagnoseDocID = new System.Windows.Forms.Button();
            this.m_txtFinallyDiagnoseDocID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtPrimaryDiagnoseDocID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_dtpPrimaryDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_dtpFinallyDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblFinallyDiagnoseDate = new System.Windows.Forms.Label();
            this.m_lsvFinallyDiagnoseDocID = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_txtFinallyDiagnose_1 = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInPatientDate = new System.Windows.Forms.Label();
            this.m_lklRecorder = new System.Windows.Forms.LinkLabel();
            this.m_lblPhone = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lblArea = new System.Windows.Forms.Label();
            this.m_lklInPatientDate = new System.Windows.Forms.LinkLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.m_picRB = new System.Windows.Forms.PictureBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_chkCatamenia = new System.Windows.Forms.CheckBox();
            this.m_txtCurrentStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblMedicineCheckTitle = new System.Windows.Forms.Label();
            this.m_txtOwnHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBeforetimeStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFamilyHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMarriageHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSys = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.lblSys = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_pnlCatamenia = new System.Windows.Forms.Panel();
            this.m_lblLastCatameniaTime = new System.Windows.Forms.Label();
            this.m_rdbAmeniaAge = new System.Windows.Forms.RadioButton();
            this.m_rdbLastCatameniaTime = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_cboFirstCatamenia = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cboCatameniaLastTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_cboCatameniaCycle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_dtpLastCatameniaTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cboAmeniaAge = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboCatameniaCase = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtCatameniaHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklCatamenia = new System.Windows.Forms.LinkLabel();
            this.pnlFocus = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lklMainDescription = new System.Windows.Forms.LinkLabel();
            this.m_lklCurrentStatus = new System.Windows.Forms.LinkLabel();
            this.m_lklBeforetimeStatus = new System.Windows.Forms.LinkLabel();
            this.m_lklMarriageHistory = new System.Windows.Forms.LinkLabel();
            this.m_lklOwnHistory = new System.Windows.Forms.LinkLabel();
            this.m_lklFamilyHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.m_lblCatameniaBorn = new System.Windows.Forms.Label();
            this.m_txtDirectorDoc = new System.Windows.Forms.TextBox();
            this.m_txtChargeDoc = new System.Windows.Forms.TextBox();
            this.m_cmdChargeDoc = new System.Windows.Forms.LinkLabel();
            this.m_cmdDirectorDoc = new System.Windows.Forms.LinkLabel();
            this.m_pnlContent1 = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel33 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.m_txtDia = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lklMedical = new System.Windows.Forms.LinkLabel();
            this.m_txtMedical = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklProfessionalCheck = new System.Windows.Forms.LinkLabel();
            this.m_txtProfessionalCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.ctlPaintContainer1 = new com.digitalwave.Utility.Controls.ctlPaintContainer();
            this.m_lklLabCheck = new System.Windows.Forms.LinkLabel();
            this.m_txtLabCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklPrimaryDiagnose = new System.Windows.Forms.LinkLabel();
            this.m_txtPrimaryDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lklModifyDiagnose = new System.Windows.Forms.LinkLabel();
            this.m_thtxtModifydiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdModifyDiagnoseDoctor = new System.Windows.Forms.LinkLabel();
            this.m_txtModifyDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpModifyDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lklAddDiagnose = new System.Windows.Forms.LinkLabel();
            this.m_thtxtaddDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdAddDiagnoseDoctor = new System.Windows.Forms.LinkLabel();
            this.m_txtAddDiagnoseDoctor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpAddDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picRB)).BeginInit();
            this.m_pnlCatamenia.SuspendLayout();
            this.m_pnlContent1.SuspendLayout();
            this.m_pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCreateID.Location = new System.Drawing.Point(92, 62);
            this.m_cmdCreateID.Size = new System.Drawing.Size(60, 16);
            this.m_cmdCreateID.TabIndex = 70;
            // 
            // trvTime
            // 
            this.trvTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(188, 336);
            this.trvTime.Size = new System.Drawing.Size(200, 68);
            this.trvTime.TabIndex = 30;
            this.trvTime.Leave += new System.EventHandler(this.trvTime_Leave);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Transparent;
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(462, 141);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(216, 22);
            this.m_dtpCreateDate.TabIndex = 40;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.BackColor = System.Drawing.Color.White;
            this.lblCreateDate.ForeColor = System.Drawing.Color.Black;
            this.lblCreateDate.Location = new System.Drawing.Point(382, 144);
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.BackColor = System.Drawing.Color.White;
            this.lblNativePlace.ForeColor = System.Drawing.Color.Black;
            this.lblNativePlace.Location = new System.Drawing.Point(118, 216);
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.BackColor = System.Drawing.Color.White;
            this.m_lblNativePlace.ForeColor = System.Drawing.Color.Black;
            this.m_lblNativePlace.Location = new System.Drawing.Point(166, 216);
            this.m_lblNativePlace.Size = new System.Drawing.Size(172, 20);
            // 
            // lblOccupation
            // 
            this.lblOccupation.BackColor = System.Drawing.Color.White;
            this.lblOccupation.ForeColor = System.Drawing.Color.Black;
            this.lblOccupation.Location = new System.Drawing.Point(118, 240);
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.BackColor = System.Drawing.Color.White;
            this.m_lblOccupation.ForeColor = System.Drawing.Color.Black;
            this.m_lblOccupation.Location = new System.Drawing.Point(166, 240);
            this.m_lblOccupation.Size = new System.Drawing.Size(172, 20);
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.BackColor = System.Drawing.Color.White;
            this.m_lblMarriaged.ForeColor = System.Drawing.Color.Black;
            this.m_lblMarriaged.Location = new System.Drawing.Point(166, 264);
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.BackColor = System.Drawing.Color.White;
            this.lblMarriaged.ForeColor = System.Drawing.Color.Black;
            this.lblMarriaged.Location = new System.Drawing.Point(118, 264);
            // 
            // m_lblCreateUserName
            // 
            this.m_lblCreateUserName.BackColor = System.Drawing.Color.White;
            this.m_lblCreateUserName.Location = new System.Drawing.Point(596, 63);
            this.m_lblCreateUserName.Size = new System.Drawing.Size(60, 12);
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.BackColor = System.Drawing.Color.White;
            this.m_lblLinkMan.ForeColor = System.Drawing.Color.Black;
            this.m_lblLinkMan.Location = new System.Drawing.Point(462, 264);
            this.m_lblLinkMan.Size = new System.Drawing.Size(79, 20);
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.BackColor = System.Drawing.Color.White;
            this.lblLinkMan.ForeColor = System.Drawing.Color.Black;
            this.lblLinkMan.Location = new System.Drawing.Point(382, 264);
            this.lblLinkMan.Size = new System.Drawing.Size(70, 14);
            this.lblLinkMan.Text = "联 系 人:";
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.White;
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(382, 312);
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.BackColor = System.Drawing.Color.White;
            this.m_lblAddress.ForeColor = System.Drawing.Color.Black;
            this.m_lblAddress.Location = new System.Drawing.Point(430, 312);
            this.m_lblAddress.Size = new System.Drawing.Size(296, 40);
            // 
            // lblNation
            // 
            this.lblNation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNation.Location = new System.Drawing.Point(118, 285);
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(166, 285);
            this.m_lblNation.Size = new System.Drawing.Size(132, 16);
            // 
            // ppdPrintPreview
            // 
            this.ppdPrintPreview.ClientSize = new System.Drawing.Size(1024, 712);
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.Color.White;
            this.lblSex.Location = new System.Drawing.Point(166, 192);
            this.lblSex.Size = new System.Drawing.Size(44, 19);
            // 
            // lblAge
            // 
            this.lblAge.BackColor = System.Drawing.Color.White;
            this.lblAge.Location = new System.Drawing.Point(166, 168);
            this.lblAge.Size = new System.Drawing.Size(44, 19);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.BackColor = System.Drawing.Color.White;
            this.lblBedNoTitle.Location = new System.Drawing.Point(582, 216);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.BackColor = System.Drawing.Color.White;
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(382, 240);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.BackColor = System.Drawing.Color.White;
            this.lblNameTitle.Location = new System.Drawing.Point(118, 144);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.BackColor = System.Drawing.Color.White;
            this.lblSexTitle.Location = new System.Drawing.Point(118, 192);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.BackColor = System.Drawing.Color.White;
            this.lblAgeTitle.Location = new System.Drawing.Point(118, 168);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.BackColor = System.Drawing.Color.White;
            this.lblAreaTitle.Location = new System.Drawing.Point(156, 62);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(454, 248);
            this.m_lsvInPatientID.TabIndex = 5000;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInPatientID.Enabled = false;
            this.txtInPatientID.Location = new System.Drawing.Point(446, 240);
            this.txtInPatientID.Size = new System.Drawing.Size(76, 16);
            this.txtInPatientID.TabIndex = 25;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPatientName.Location = new System.Drawing.Point(166, 144);
            this.m_txtPatientName.Size = new System.Drawing.Size(112, 16);
            this.m_txtPatientName.TabIndex = 20;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBedNO.Enabled = false;
            this.m_txtBedNO.Location = new System.Drawing.Point(630, 216);
            this.m_txtBedNO.Size = new System.Drawing.Size(52, 16);
            this.m_txtBedNO.TabIndex = 10;
            // 
            // m_cboArea
            // 
            this.m_cboArea.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboArea.Location = new System.Drawing.Point(364, 62);
            this.m_cboArea.Size = new System.Drawing.Size(60, 23);
            this.m_cboArea.TabIndex = 700;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(492, 792);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(638, 248);
            this.m_lsvBedNO.Size = new System.Drawing.Size(72, 100);
            // 
            // m_cboDept
            // 
            this.m_cboDept.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboDept.Location = new System.Drawing.Point(300, 62);
            this.m_cboDept.Size = new System.Drawing.Size(60, 23);
            this.m_cboDept.TabIndex = 600;
            // 
            // lblDept
            // 
            this.lblDept.BackColor = System.Drawing.Color.White;
            this.lblDept.Location = new System.Drawing.Point(216, 62);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.BackColor = System.Drawing.Color.White;
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(645, 728);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.BackColor = System.Drawing.Color.White;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(268, 62);
            this.m_cmdNext.UseVisualStyleBackColor = false;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.BackColor = System.Drawing.Color.White;
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(36, 137);
            this.m_cmdPre.UseVisualStyleBackColor = false;
            this.m_cmdPre.Visible = true;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.AutoSize = true;
            this.m_lblForTitle.BackColor = System.Drawing.Color.White;
            this.m_lblForTitle.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblForTitle.ForeColor = System.Drawing.Color.Black;
            this.m_lblForTitle.Location = new System.Drawing.Point(313, 96);
            this.m_lblForTitle.Size = new System.Drawing.Size(219, 29);
            this.m_lblForTitle.Text = "住  院  病  历";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(531, 96);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(629, 94);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(79, 28);
            this.m_tipMain.SetToolTip(this.m_cmdModifyPatientInfo, "点击查看和修改患者详细信息(快捷键Alt+P)");
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pnlNewBase.Location = new System.Drawing.Point(30, 0);
            this.m_pnlNewBase.Size = new System.Drawing.Size(1188, 31);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(1186, 0);
            this.m_ctlPatientInfo.Visible = false;
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.BackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.BorderColor = System.Drawing.Color.White;
            this.m_cboRepresentor.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRepresentor.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRepresentor.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboRepresentor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboRepresentor.ForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRepresentor.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRepresentor.Location = new System.Drawing.Point(446, 165);
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
            this.lblRepresentor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblRepresentor.ForeColor = System.Drawing.Color.Black;
            this.lblRepresentor.Location = new System.Drawing.Point(382, 168);
            this.lblRepresentor.Name = "lblRepresentor";
            this.lblRepresentor.Size = new System.Drawing.Size(56, 14);
            this.lblRepresentor.TabIndex = 517;
            this.lblRepresentor.Text = "陈述者:";
            // 
            // m_cboCredibility
            // 
            this.m_cboCredibility.BackColor = System.Drawing.Color.White;
            this.m_cboCredibility.BorderColor = System.Drawing.Color.White;
            this.m_cboCredibility.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCredibility.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCredibility.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboCredibility.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboCredibility.ForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.ListBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCredibility.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCredibility.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCredibility.Location = new System.Drawing.Point(630, 165);
            this.m_cboCredibility.m_BlnEnableItemEventMenu = true;
            this.m_cboCredibility.Name = "m_cboCredibility";
            this.m_cboCredibility.SelectedIndex = -1;
            this.m_cboCredibility.SelectedItem = null;
            this.m_cboCredibility.SelectionStart = 0;
            this.m_cboCredibility.Size = new System.Drawing.Size(84, 23);
            this.m_cboCredibility.TabIndex = 60;
            this.m_cboCredibility.TextBackColor = System.Drawing.Color.White;
            this.m_cboCredibility.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblCredibility
            // 
            this.lblCredibility.AutoSize = true;
            this.lblCredibility.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblCredibility.ForeColor = System.Drawing.Color.Black;
            this.lblCredibility.Location = new System.Drawing.Point(566, 168);
            this.lblCredibility.Name = "lblCredibility";
            this.lblCredibility.Size = new System.Drawing.Size(56, 14);
            this.lblCredibility.TabIndex = 514;
            this.lblCredibility.Text = "可靠度:";
            // 
            // lblPrimaryDiagnose
            // 
            this.lblPrimaryDiagnose.Location = new System.Drawing.Point(16, 100);
            this.lblPrimaryDiagnose.Name = "lblPrimaryDiagnose";
            this.lblPrimaryDiagnose.Size = new System.Drawing.Size(80, 19);
            this.lblPrimaryDiagnose.TabIndex = 0;
            // 
            // m_picDiagnose
            // 
            this.m_picDiagnose.Location = new System.Drawing.Point(96, 20);
            this.m_picDiagnose.Name = "m_picDiagnose";
            this.m_picDiagnose.Size = new System.Drawing.Size(16, 16);
            this.m_picDiagnose.TabIndex = 0;
            this.m_picDiagnose.TabStop = false;
            // 
            // lblSummary
            // 
            this.lblSummary.Location = new System.Drawing.Point(28, 100);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(55, 19);
            this.lblSummary.TabIndex = 0;
            // 
            // m_picSummary
            // 
            this.m_picSummary.Location = new System.Drawing.Point(92, 100);
            this.m_picSummary.Name = "m_picSummary";
            this.m_picSummary.Size = new System.Drawing.Size(16, 16);
            this.m_picSummary.TabIndex = 0;
            this.m_picSummary.TabStop = false;
            // 
            // lblMedical
            // 
            this.lblMedical.Location = new System.Drawing.Point(16, 100);
            this.lblMedical.Name = "lblMedical";
            this.lblMedical.Size = new System.Drawing.Size(80, 19);
            this.lblMedical.TabIndex = 0;
            // 
            // lblFamilyHistory
            // 
            this.lblFamilyHistory.Location = new System.Drawing.Point(16, 100);
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
            this.lblProfessionalCheck.Location = new System.Drawing.Point(16, 100);
            this.lblProfessionalCheck.Name = "lblProfessionalCheck";
            this.lblProfessionalCheck.Size = new System.Drawing.Size(80, 19);
            this.lblProfessionalCheck.TabIndex = 0;
            // 
            // m_picProfessionalCheck
            // 
            this.m_picProfessionalCheck.Location = new System.Drawing.Point(96, 100);
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
            // m_txtFinallyDiagnose
            // 
            this.m_txtFinallyDiagnose.AccessibleDescription = "最后诊断";
            this.m_txtFinallyDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtFinallyDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtFinallyDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFinallyDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtFinallyDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFinallyDiagnose.Location = new System.Drawing.Point(36, 103);
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
            this.m_txtFinallyDiagnose.Name = "m_txtFinallyDiagnose";
            this.m_txtFinallyDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtFinallyDiagnose.Size = new System.Drawing.Size(24, 19);
            this.m_txtFinallyDiagnose.TabIndex = 310;
            this.m_txtFinallyDiagnose.Tag = "12";
            this.m_txtFinallyDiagnose.Text = "";
            this.m_txtFinallyDiagnose.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtSummary);
            this.groupBox1.Controls.Add(this.m_cmdMidwife);
            this.groupBox1.Controls.Add(this.m_cmdGetDovueData);
            this.groupBox1.Controls.Add(this.m_lblContraHistory);
            this.groupBox1.Controls.Add(this.m_lblOldMaternitySuffer);
            this.groupBox1.Controls.Add(this.m_lblPergCount);
            this.groupBox1.Controls.Add(this.m_lblPreg);
            this.groupBox1.Controls.Add(this.m_lblBorn);
            this.groupBox1.Controls.Add(this.m_lblBornCount);
            this.groupBox1.Controls.Add(this.lblFinallyDiagnose);
            this.groupBox1.Controls.Add(this.m_cmdPrimaryDiagnoseDocID);
            this.groupBox1.Controls.Add(this.lblPrimaryDiagnoseDate);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.m_cmdFinallyDiagnoseDocID);
            this.groupBox1.Controls.Add(this.m_txtFinallyDiagnoseDocID);
            this.groupBox1.Controls.Add(this.m_txtPrimaryDiagnoseDocID);
            this.groupBox1.Controls.Add(this.m_dtpPrimaryDiagnoseDate);
            this.groupBox1.Controls.Add(this.m_dtpFinallyDiagnoseDate);
            this.groupBox1.Controls.Add(this.lblFinallyDiagnoseDate);
            this.groupBox1.Controls.Add(this.m_lsvFinallyDiagnoseDocID);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(428, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 20);
            this.groupBox1.TabIndex = 10000094;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "no use";
            this.groupBox1.Visible = false;
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.AccessibleDescription = "摘要";
            this.m_txtSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtSummary.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSummary.Location = new System.Drawing.Point(12, 212);
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
            this.m_txtSummary.TabIndex = 10000128;
            this.m_txtSummary.Tag = "11";
            this.m_txtSummary.Text = "";
            this.m_txtSummary.Visible = false;
            // 
            // m_cmdMidwife
            // 
            this.m_cmdMidwife.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdMidwife.Location = new System.Drawing.Point(292, 180);
            this.m_cmdMidwife.Name = "m_cmdMidwife";
            this.m_cmdMidwife.Size = new System.Drawing.Size(84, 28);
            this.m_cmdMidwife.TabIndex = 10000125;
            this.m_cmdMidwife.Text = "助产士";
            this.m_cmdMidwife.Visible = false;
            // 
            // m_cmdGetDovueData
            // 
            this.m_cmdGetDovueData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdGetDovueData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdGetDovueData.Location = new System.Drawing.Point(280, 168);
            this.m_cmdGetDovueData.Name = "m_cmdGetDovueData";
            this.m_cmdGetDovueData.Size = new System.Drawing.Size(48, 4);
            this.m_cmdGetDovueData.TabIndex = 10000120;
            this.m_cmdGetDovueData.Text = "体格检查:";
            this.m_cmdGetDovueData.Visible = false;
            // 
            // m_lblContraHistory
            // 
            this.m_lblContraHistory.AutoSize = true;
            this.m_lblContraHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblContraHistory.Location = new System.Drawing.Point(356, 60);
            this.m_lblContraHistory.Name = "m_lblContraHistory";
            this.m_lblContraHistory.Size = new System.Drawing.Size(80, 16);
            this.m_lblContraHistory.TabIndex = 10000119;
            this.m_lblContraHistory.Tag = "4";
            this.m_lblContraHistory.Text = "避孕情况:";
            // 
            // m_lblOldMaternitySuffer
            // 
            this.m_lblOldMaternitySuffer.Location = new System.Drawing.Point(0, 0);
            this.m_lblOldMaternitySuffer.Name = "m_lblOldMaternitySuffer";
            this.m_lblOldMaternitySuffer.Size = new System.Drawing.Size(100, 23);
            this.m_lblOldMaternitySuffer.TabIndex = 10000129;
            // 
            // m_lblPergCount
            // 
            this.m_lblPergCount.AutoSize = true;
            this.m_lblPergCount.Location = new System.Drawing.Point(132, 120);
            this.m_lblPergCount.Name = "m_lblPergCount";
            this.m_lblPergCount.Size = new System.Drawing.Size(24, 16);
            this.m_lblPergCount.TabIndex = 10000107;
            this.m_lblPergCount.Tag = "13";
            this.m_lblPergCount.Text = "次";
            this.m_lblPergCount.Visible = false;
            // 
            // m_lblPreg
            // 
            this.m_lblPreg.AutoSize = true;
            this.m_lblPreg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPreg.Location = new System.Drawing.Point(8, 120);
            this.m_lblPreg.Name = "m_lblPreg";
            this.m_lblPreg.Size = new System.Drawing.Size(40, 16);
            this.m_lblPreg.TabIndex = 10000106;
            this.m_lblPreg.Tag = "13";
            this.m_lblPreg.Text = "孕 :";
            this.m_lblPreg.Visible = false;
            // 
            // m_lblBorn
            // 
            this.m_lblBorn.AutoSize = true;
            this.m_lblBorn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBorn.Location = new System.Drawing.Point(196, 120);
            this.m_lblBorn.Name = "m_lblBorn";
            this.m_lblBorn.Size = new System.Drawing.Size(40, 16);
            this.m_lblBorn.TabIndex = 10000104;
            this.m_lblBorn.Tag = "13";
            this.m_lblBorn.Text = "产 :";
            this.m_lblBorn.Visible = false;
            // 
            // m_lblBornCount
            // 
            this.m_lblBornCount.AutoSize = true;
            this.m_lblBornCount.Location = new System.Drawing.Point(320, 120);
            this.m_lblBornCount.Name = "m_lblBornCount";
            this.m_lblBornCount.Size = new System.Drawing.Size(24, 16);
            this.m_lblBornCount.TabIndex = 10000105;
            this.m_lblBornCount.Tag = "13";
            this.m_lblBornCount.Text = "次";
            this.m_lblBornCount.Visible = false;
            // 
            // lblFinallyDiagnose
            // 
            this.lblFinallyDiagnose.AutoSize = true;
            this.lblFinallyDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFinallyDiagnose.Location = new System.Drawing.Point(8, 24);
            this.lblFinallyDiagnose.Name = "lblFinallyDiagnose";
            this.lblFinallyDiagnose.Size = new System.Drawing.Size(80, 16);
            this.lblFinallyDiagnose.TabIndex = 583;
            this.lblFinallyDiagnose.Tag = "12";
            this.lblFinallyDiagnose.Text = "最后诊断:";
            this.lblFinallyDiagnose.Visible = false;
            // 
            // m_cmdPrimaryDiagnoseDocID
            // 
            this.m_cmdPrimaryDiagnoseDocID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrimaryDiagnoseDocID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrimaryDiagnoseDocID.Location = new System.Drawing.Point(8, 48);
            this.m_cmdPrimaryDiagnoseDocID.Name = "m_cmdPrimaryDiagnoseDocID";
            this.m_cmdPrimaryDiagnoseDocID.Size = new System.Drawing.Size(112, 28);
            this.m_cmdPrimaryDiagnoseDocID.TabIndex = 10000079;
            this.m_cmdPrimaryDiagnoseDocID.Text = "初步诊断签名:";
            this.m_cmdPrimaryDiagnoseDocID.Visible = false;
            // 
            // lblPrimaryDiagnoseDate
            // 
            this.lblPrimaryDiagnoseDate.AutoSize = true;
            this.lblPrimaryDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrimaryDiagnoseDate.Location = new System.Drawing.Point(8, 88);
            this.lblPrimaryDiagnoseDate.Name = "lblPrimaryDiagnoseDate";
            this.lblPrimaryDiagnoseDate.Size = new System.Drawing.Size(112, 16);
            this.lblPrimaryDiagnoseDate.TabIndex = 591;
            this.lblPrimaryDiagnoseDate.Tag = "12";
            this.lblPrimaryDiagnoseDate.Text = "初步诊断日期:";
            this.lblPrimaryDiagnoseDate.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(96, 28);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 599;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "11";
            this.pictureBox7.Visible = false;
            // 
            // m_cmdFinallyDiagnoseDocID
            // 
            this.m_cmdFinallyDiagnoseDocID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFinallyDiagnoseDocID.Location = new System.Drawing.Point(124, 24);
            this.m_cmdFinallyDiagnoseDocID.Name = "m_cmdFinallyDiagnoseDocID";
            this.m_cmdFinallyDiagnoseDocID.Size = new System.Drawing.Size(110, 28);
            this.m_cmdFinallyDiagnoseDocID.TabIndex = 10000080;
            this.m_cmdFinallyDiagnoseDocID.Text = "最后诊断签名:";
            this.m_cmdFinallyDiagnoseDocID.Visible = false;
            // 
            // m_txtFinallyDiagnoseDocID
            // 
            this.m_txtFinallyDiagnoseDocID.AccessibleName = "NoDefault";
            this.m_txtFinallyDiagnoseDocID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtFinallyDiagnoseDocID.BorderColor = System.Drawing.Color.White;
            this.m_txtFinallyDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFinallyDiagnoseDocID.ForeColor = System.Drawing.Color.White;
            this.m_txtFinallyDiagnoseDocID.Location = new System.Drawing.Point(240, 28);
            this.m_txtFinallyDiagnoseDocID.Name = "m_txtFinallyDiagnoseDocID";
            this.m_txtFinallyDiagnoseDocID.Size = new System.Drawing.Size(102, 26);
            this.m_txtFinallyDiagnoseDocID.TabIndex = 28;
            this.m_txtFinallyDiagnoseDocID.Tag = "12";
            this.m_txtFinallyDiagnoseDocID.Visible = false;
            // 
            // m_txtPrimaryDiagnoseDocID
            // 
            this.m_txtPrimaryDiagnoseDocID.AccessibleDescription = "初步诊断签名";
            this.m_txtPrimaryDiagnoseDocID.AccessibleName = "NoDefault";
            this.m_txtPrimaryDiagnoseDocID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtPrimaryDiagnoseDocID.BorderColor = System.Drawing.Color.White;
            this.m_txtPrimaryDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPrimaryDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrimaryDiagnoseDocID.ForeColor = System.Drawing.Color.White;
            this.m_txtPrimaryDiagnoseDocID.Location = new System.Drawing.Point(128, 60);
            this.m_txtPrimaryDiagnoseDocID.Name = "m_txtPrimaryDiagnoseDocID";
            this.m_txtPrimaryDiagnoseDocID.Size = new System.Drawing.Size(102, 26);
            this.m_txtPrimaryDiagnoseDocID.TabIndex = 27;
            this.m_txtPrimaryDiagnoseDocID.Tag = "12";
            this.m_txtPrimaryDiagnoseDocID.Visible = false;
            // 
            // m_dtpPrimaryDiagnoseDate
            // 
            this.m_dtpPrimaryDiagnoseDate.BorderColor = System.Drawing.Color.White;
            this.m_dtpPrimaryDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpPrimaryDiagnoseDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpPrimaryDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpPrimaryDiagnoseDate.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpPrimaryDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpPrimaryDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpPrimaryDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpPrimaryDiagnoseDate.Location = new System.Drawing.Point(128, 92);
            this.m_dtpPrimaryDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpPrimaryDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpPrimaryDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpPrimaryDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpPrimaryDiagnoseDate.Name = "m_dtpPrimaryDiagnoseDate";
            this.m_dtpPrimaryDiagnoseDate.ReadOnly = false;
            this.m_dtpPrimaryDiagnoseDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpPrimaryDiagnoseDate.TabIndex = 29;
            this.m_dtpPrimaryDiagnoseDate.Tag = "12";
            this.m_dtpPrimaryDiagnoseDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpPrimaryDiagnoseDate.TextForeColor = System.Drawing.Color.White;
            this.m_dtpPrimaryDiagnoseDate.Visible = false;
            // 
            // m_dtpFinallyDiagnoseDate
            // 
            this.m_dtpFinallyDiagnoseDate.BorderColor = System.Drawing.Color.White;
            this.m_dtpFinallyDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpFinallyDiagnoseDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpFinallyDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpFinallyDiagnoseDate.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpFinallyDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpFinallyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpFinallyDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFinallyDiagnoseDate.Location = new System.Drawing.Point(356, 32);
            this.m_dtpFinallyDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpFinallyDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpFinallyDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpFinallyDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpFinallyDiagnoseDate.Name = "m_dtpFinallyDiagnoseDate";
            this.m_dtpFinallyDiagnoseDate.ReadOnly = false;
            this.m_dtpFinallyDiagnoseDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpFinallyDiagnoseDate.TabIndex = 30;
            this.m_dtpFinallyDiagnoseDate.Tag = "12";
            this.m_dtpFinallyDiagnoseDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpFinallyDiagnoseDate.TextForeColor = System.Drawing.Color.White;
            this.m_dtpFinallyDiagnoseDate.Visible = false;
            // 
            // lblFinallyDiagnoseDate
            // 
            this.lblFinallyDiagnoseDate.AutoSize = true;
            this.lblFinallyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFinallyDiagnoseDate.Location = new System.Drawing.Point(384, 84);
            this.lblFinallyDiagnoseDate.Name = "lblFinallyDiagnoseDate";
            this.lblFinallyDiagnoseDate.Size = new System.Drawing.Size(112, 16);
            this.lblFinallyDiagnoseDate.TabIndex = 590;
            this.lblFinallyDiagnoseDate.Tag = "12";
            this.lblFinallyDiagnoseDate.Text = "最后诊断日期:";
            this.lblFinallyDiagnoseDate.Visible = false;
            // 
            // m_lsvFinallyDiagnoseDocID
            // 
            this.m_lsvFinallyDiagnoseDocID.BackColor = System.Drawing.Color.White;
            this.m_lsvFinallyDiagnoseDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvFinallyDiagnoseDocID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvFinallyDiagnoseDocID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvFinallyDiagnoseDocID.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lsvFinallyDiagnoseDocID.FullRowSelect = true;
            this.m_lsvFinallyDiagnoseDocID.GridLines = true;
            this.m_lsvFinallyDiagnoseDocID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvFinallyDiagnoseDocID.Location = new System.Drawing.Point(512, 20);
            this.m_lsvFinallyDiagnoseDocID.MultiSelect = false;
            this.m_lsvFinallyDiagnoseDocID.Name = "m_lsvFinallyDiagnoseDocID";
            this.m_lsvFinallyDiagnoseDocID.Size = new System.Drawing.Size(102, 105);
            this.m_lsvFinallyDiagnoseDocID.TabIndex = 27;
            this.m_lsvFinallyDiagnoseDocID.Tag = "12";
            this.m_lsvFinallyDiagnoseDocID.UseCompatibleStateImageBehavior = false;
            this.m_lsvFinallyDiagnoseDocID.View = System.Windows.Forms.View.Details;
            this.m_lsvFinallyDiagnoseDocID.Visible = false;
            this.m_lsvFinallyDiagnoseDocID.DoubleClick += new System.EventHandler(this.m_lsvDoctorList_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "编号";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "名称";
            this.columnHeader4.Width = 100;
            // 
            // m_txtFinallyDiagnose_1
            // 
            this.m_txtFinallyDiagnose_1.AccessibleDescription = "";
            this.m_txtFinallyDiagnose_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtFinallyDiagnose_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtFinallyDiagnose_1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFinallyDiagnose_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtFinallyDiagnose_1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFinallyDiagnose_1.Location = new System.Drawing.Point(66, 112);
            this.m_txtFinallyDiagnose_1.m_BlnIgnoreUserInfo = true;
            this.m_txtFinallyDiagnose_1.m_BlnPartControl = false;
            this.m_txtFinallyDiagnose_1.m_BlnReadOnly = false;
            this.m_txtFinallyDiagnose_1.m_BlnUnderLineDST = false;
            this.m_txtFinallyDiagnose_1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFinallyDiagnose_1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFinallyDiagnose_1.m_IntCanModifyTime = 6;
            this.m_txtFinallyDiagnose_1.m_IntPartControlLength = 0;
            this.m_txtFinallyDiagnose_1.m_IntPartControlStartIndex = 0;
            this.m_txtFinallyDiagnose_1.m_StrUserID = "";
            this.m_txtFinallyDiagnose_1.m_StrUserName = "";
            this.m_txtFinallyDiagnose_1.Multiline = false;
            this.m_txtFinallyDiagnose_1.Name = "m_txtFinallyDiagnose_1";
            this.m_txtFinallyDiagnose_1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFinallyDiagnose_1.Size = new System.Drawing.Size(10, 10);
            this.m_txtFinallyDiagnose_1.TabIndex = 26;
            this.m_txtFinallyDiagnose_1.Tag = "12";
            this.m_txtFinallyDiagnose_1.Text = "";
            this.m_txtFinallyDiagnose_1.Visible = false;
            // 
            // lblInPatientDate
            // 
            this.lblInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.lblInPatientDate.Location = new System.Drawing.Point(190, 312);
            this.lblInPatientDate.Name = "lblInPatientDate";
            this.lblInPatientDate.Size = new System.Drawing.Size(184, 20);
            this.lblInPatientDate.TabIndex = 10000024;
            // 
            // m_lklRecorder
            // 
            this.m_lklRecorder.AutoSize = true;
            this.m_lklRecorder.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklRecorder.Location = new System.Drawing.Point(382, 192);
            this.m_lklRecorder.Name = "m_lklRecorder";
            this.m_lklRecorder.Size = new System.Drawing.Size(84, 14);
            this.m_lklRecorder.TabIndex = 10000025;
            this.m_lklRecorder.TabStop = true;
            this.m_lklRecorder.Tag = "1";
            this.m_lklRecorder.Text = "病史记录者:";
            this.m_lklRecorder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // m_lblPhone
            // 
            this.m_lblPhone.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblPhone.ForeColor = System.Drawing.Color.Black;
            this.m_lblPhone.Location = new System.Drawing.Point(430, 288);
            this.m_lblPhone.Name = "m_lblPhone";
            this.m_lblPhone.Size = new System.Drawing.Size(112, 20);
            this.m_lblPhone.TabIndex = 10000027;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(382, 288);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(42, 14);
            this.lblPhone.TabIndex = 10000026;
            this.lblPhone.Text = "电话:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(382, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000028;
            this.label11.Text = "病区:";
            // 
            // m_lblArea
            // 
            this.m_lblArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblArea.ForeColor = System.Drawing.Color.Black;
            this.m_lblArea.Location = new System.Drawing.Point(430, 216);
            this.m_lblArea.Name = "m_lblArea";
            this.m_lblArea.Size = new System.Drawing.Size(148, 20);
            this.m_lblArea.TabIndex = 10000029;
            // 
            // m_lklInPatientDate
            // 
            this.m_lklInPatientDate.AutoSize = true;
            this.m_lklInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lklInPatientDate.LinkColor = System.Drawing.Color.Black;
            this.m_lklInPatientDate.Location = new System.Drawing.Point(118, 312);
            this.m_lklInPatientDate.Name = "m_lklInPatientDate";
            this.m_lklInPatientDate.Size = new System.Drawing.Size(70, 14);
            this.m_lklInPatientDate.TabIndex = 10000030;
            this.m_lklInPatientDate.TabStop = true;
            this.m_lklInPatientDate.Text = "入院日期:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(779, 62);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.TabIndex = 10000100;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(40, 64);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.TabIndex = 10000100;
            this.pictureBox8.TabStop = false;
            // 
            // m_picRB
            // 
            this.m_picRB.Image = ((System.Drawing.Image)(resources.GetObject("m_picRB.Image")));
            this.m_picRB.Location = new System.Drawing.Point(775, 1239);
            this.m_picRB.Name = "m_picRB";
            this.m_picRB.Size = new System.Drawing.Size(29, 32);
            this.m_picRB.TabIndex = 10000102;
            this.m_picRB.TabStop = false;
            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSign.Location = new System.Drawing.Point(465, 187);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(243, 19);
            this.txtSign.TabIndex = 10000104;
            // 
            // m_chkCatamenia
            // 
            this.m_chkCatamenia.Checked = true;
            this.m_chkCatamenia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_pnlContent.SetFlowBreak(this.m_chkCatamenia, true);
            this.m_chkCatamenia.Location = new System.Drawing.Point(115, 129);
            this.m_chkCatamenia.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.m_chkCatamenia.Name = "m_chkCatamenia";
            this.m_chkCatamenia.Size = new System.Drawing.Size(16, 24);
            this.m_chkCatamenia.TabIndex = 135;
            this.m_chkCatamenia.Tag = "5";
            this.m_chkCatamenia.CheckedChanged += new System.EventHandler(this.m_chkCatamenia_CheckedChanged);
            // 
            // m_txtCurrentStatus
            // 
            this.m_txtCurrentStatus.AccessibleDescription = "现病史";
            this.m_txtCurrentStatus.BackColor = System.Drawing.Color.White;
            this.m_txtCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtCurrentStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurrentStatus.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurrentStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurrentStatus.Location = new System.Drawing.Point(83, 37);
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
            this.m_txtCurrentStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtCurrentStatus.Name = "m_txtCurrentStatus";
            this.m_txtCurrentStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtCurrentStatus.Size = new System.Drawing.Size(580, 19);
            this.m_txtCurrentStatus.TabIndex = 100;
            this.m_txtCurrentStatus.Tag = "1";
            this.m_txtCurrentStatus.Text = "";
            // 
            // m_lblMedicineCheckTitle
            // 
            this.m_lblMedicineCheckTitle.AutoSize = true;
            this.m_pnlContent.SetFlowBreak(this.m_lblMedicineCheckTitle, true);
            this.m_lblMedicineCheckTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMedicineCheckTitle.ForeColor = System.Drawing.Color.Black;
            this.m_lblMedicineCheckTitle.Location = new System.Drawing.Point(330, 265);
            this.m_lblMedicineCheckTitle.Margin = new System.Windows.Forms.Padding(320, 0, 3, 20);
            this.m_lblMedicineCheckTitle.Name = "m_lblMedicineCheckTitle";
            this.m_lblMedicineCheckTitle.Size = new System.Drawing.Size(110, 21);
            this.m_lblMedicineCheckTitle.TabIndex = 10000021;
            this.m_lblMedicineCheckTitle.Tag = "8";
            this.m_lblMedicineCheckTitle.Text = "体格检查:";
            // 
            // m_txtOwnHistory
            // 
            this.m_txtOwnHistory.AccessibleDescription = "个人史";
            this.m_txtOwnHistory.BackColor = System.Drawing.Color.White;
            this.m_txtOwnHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtOwnHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOwnHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtOwnHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOwnHistory.Location = new System.Drawing.Point(83, 81);
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
            this.m_txtOwnHistory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtOwnHistory.Name = "m_txtOwnHistory";
            this.m_txtOwnHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtOwnHistory.Size = new System.Drawing.Size(580, 19);
            this.m_txtOwnHistory.TabIndex = 120;
            this.m_txtOwnHistory.Tag = "3";
            this.m_txtOwnHistory.Text = "";
            // 
            // m_txtBeforetimeStatus
            // 
            this.m_txtBeforetimeStatus.AccessibleDescription = "既往史";
            this.m_txtBeforetimeStatus.BackColor = System.Drawing.Color.White;
            this.m_txtBeforetimeStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBeforetimeStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeforetimeStatus.ForeColor = System.Drawing.Color.Black;
            this.m_txtBeforetimeStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBeforetimeStatus.Location = new System.Drawing.Point(83, 59);
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
            this.m_txtBeforetimeStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtBeforetimeStatus.Name = "m_txtBeforetimeStatus";
            this.m_txtBeforetimeStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtBeforetimeStatus.Size = new System.Drawing.Size(580, 19);
            this.m_txtBeforetimeStatus.TabIndex = 110;
            this.m_txtBeforetimeStatus.Tag = "2";
            this.m_txtBeforetimeStatus.Text = "";
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.Color.Black;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(243, 306);
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
            this.m_txtPulse.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtPulse.Size = new System.Drawing.Size(28, 21);
            this.m_txtPulse.TabIndex = 230;
            this.m_txtPulse.Tag = "8";
            this.m_txtPulse.Text = "";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.Color.White;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(121, 306);
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
            this.m_txtTemperature.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtTemperature.Size = new System.Drawing.Size(32, 21);
            this.m_txtTemperature.TabIndex = 220;
            this.m_txtTemperature.Tag = "8";
            this.m_txtTemperature.Text = "";
            // 
            // m_txtFamilyHistory
            // 
            this.m_txtFamilyHistory.AccessibleDescription = "家族史";
            this.m_txtFamilyHistory.BackColor = System.Drawing.Color.White;
            this.m_txtFamilyHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtFamilyHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFamilyHistory.ForeColor = System.Drawing.Color.White;
            this.m_txtFamilyHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFamilyHistory.Location = new System.Drawing.Point(83, 231);
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
            this.m_txtFamilyHistory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.m_txtFamilyHistory.Name = "m_txtFamilyHistory";
            this.m_txtFamilyHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtFamilyHistory.Size = new System.Drawing.Size(580, 19);
            this.m_txtFamilyHistory.TabIndex = 210;
            this.m_txtFamilyHistory.Tag = "7";
            this.m_txtFamilyHistory.Text = "";
            // 
            // m_txtMarriageHistory
            // 
            this.m_txtMarriageHistory.AccessibleDescription = "婚姻史";
            this.m_txtMarriageHistory.BackColor = System.Drawing.Color.White;
            this.m_txtMarriageHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtMarriageHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMarriageHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtMarriageHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMarriageHistory.Location = new System.Drawing.Point(83, 103);
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
            this.m_txtMarriageHistory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtMarriageHistory.Name = "m_txtMarriageHistory";
            this.m_txtMarriageHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtMarriageHistory.Size = new System.Drawing.Size(580, 19);
            this.m_txtMarriageHistory.TabIndex = 130;
            this.m_txtMarriageHistory.Tag = "5";
            this.m_txtMarriageHistory.Text = "";
            // 
            // m_txtSys
            // 
            this.m_txtSys.AccessibleDescription = "血压";
            this.m_txtSys.BackColor = System.Drawing.Color.White;
            this.m_txtSys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtSys.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSys.ForeColor = System.Drawing.Color.White;
            this.m_txtSys.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSys.Location = new System.Drawing.Point(519, 306);
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
            this.m_txtSys.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtSys.Multiline = false;
            this.m_txtSys.Name = "m_txtSys";
            this.m_txtSys.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtSys.Size = new System.Drawing.Size(28, 21);
            this.m_txtSys.TabIndex = 250;
            this.m_txtSys.Tag = "8";
            this.m_txtSys.Text = "";
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.AccessibleDescription = "呼吸";
            this.m_txtBreath.BackColor = System.Drawing.Color.White;
            this.m_txtBreath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.Color.Black;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(385, 306);
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
            this.m_txtBreath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtBreath.Multiline = false;
            this.m_txtBreath.Name = "m_txtBreath";
            this.m_txtBreath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtBreath.Size = new System.Drawing.Size(20, 21);
            this.m_txtBreath.TabIndex = 240;
            this.m_txtBreath.Tag = "8";
            this.m_txtBreath.Text = "";
            // 
            // lblSys
            // 
            this.lblSys.AutoSize = true;
            this.lblSys.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSys.ForeColor = System.Drawing.Color.Black;
            this.lblSys.Location = new System.Drawing.Point(553, 308);
            this.lblSys.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.lblSys.Name = "lblSys";
            this.lblSys.Size = new System.Drawing.Size(20, 19);
            this.lblSys.TabIndex = 561;
            this.lblSys.Tag = "8";
            this.lblSys.Text = "/";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(159, 308);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 10000091;
            this.label17.Tag = "8";
            this.label17.Text = "℃";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(277, 308);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 16);
            this.label18.TabIndex = 10000092;
            this.label18.Tag = "8";
            this.label18.Text = "次/分";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(411, 308);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 16);
            this.label19.TabIndex = 10000093;
            this.label19.Tag = "8";
            this.label19.Text = "次/分";
            // 
            // m_pnlCatamenia
            // 
            this.m_pnlCatamenia.Controls.Add(this.m_lblLastCatameniaTime);
            this.m_pnlCatamenia.Controls.Add(this.m_rdbAmeniaAge);
            this.m_pnlCatamenia.Controls.Add(this.m_rdbLastCatameniaTime);
            this.m_pnlCatamenia.Controls.Add(this.label1);
            this.m_pnlCatamenia.Controls.Add(this.label13);
            this.m_pnlCatamenia.Controls.Add(this.m_cboFirstCatamenia);
            this.m_pnlCatamenia.Controls.Add(this.label14);
            this.m_pnlCatamenia.Controls.Add(this.m_cboCatameniaLastTime);
            this.m_pnlCatamenia.Controls.Add(this.label15);
            this.m_pnlCatamenia.Controls.Add(this.m_cboCatameniaCycle);
            this.m_pnlCatamenia.Controls.Add(this.m_dtpLastCatameniaTime);
            this.m_pnlCatamenia.Controls.Add(this.m_cboAmeniaAge);
            this.m_pnlCatamenia.Controls.Add(this.m_cboCatameniaCase);
            this.m_pnlCatamenia.Controls.Add(this.m_txtCatameniaHistory);
            this.m_pnlCatamenia.Controls.Add(this.m_lklCatamenia);
            this.m_pnlContent.SetFlowBreak(this.m_pnlCatamenia, true);
            this.m_pnlCatamenia.Location = new System.Drawing.Point(13, 153);
            this.m_pnlCatamenia.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.m_pnlCatamenia.Name = "m_pnlCatamenia";
            this.m_pnlCatamenia.Size = new System.Drawing.Size(652, 68);
            this.m_pnlCatamenia.TabIndex = 140;
            // 
            // m_lblLastCatameniaTime
            // 
            this.m_lblLastCatameniaTime.AutoSize = true;
            this.m_lblLastCatameniaTime.Location = new System.Drawing.Point(411, 11);
            this.m_lblLastCatameniaTime.Name = "m_lblLastCatameniaTime";
            this.m_lblLastCatameniaTime.Size = new System.Drawing.Size(80, 16);
            this.m_lblLastCatameniaTime.TabIndex = 10000122;
            this.m_lblLastCatameniaTime.Text = "末次时间:";
            // 
            // m_rdbAmeniaAge
            // 
            this.m_rdbAmeniaAge.AutoSize = true;
            this.m_rdbAmeniaAge.Location = new System.Drawing.Point(393, 38);
            this.m_rdbAmeniaAge.Name = "m_rdbAmeniaAge";
            this.m_rdbAmeniaAge.Size = new System.Drawing.Size(98, 20);
            this.m_rdbAmeniaAge.TabIndex = 10000121;
            this.m_rdbAmeniaAge.Text = "闭经年龄:";
            this.m_rdbAmeniaAge.UseVisualStyleBackColor = true;
            this.m_rdbAmeniaAge.CheckedChanged += new System.EventHandler(this.m_rdbAmeniaAge_CheckedChanged);
            // 
            // m_rdbLastCatameniaTime
            // 
            this.m_rdbLastCatameniaTime.AutoSize = true;
            this.m_rdbLastCatameniaTime.Checked = true;
            this.m_rdbLastCatameniaTime.Location = new System.Drawing.Point(393, 9);
            this.m_rdbLastCatameniaTime.Name = "m_rdbLastCatameniaTime";
            this.m_rdbLastCatameniaTime.Size = new System.Drawing.Size(98, 20);
            this.m_rdbLastCatameniaTime.TabIndex = 10000120;
            this.m_rdbLastCatameniaTime.TabStop = true;
            this.m_rdbLastCatameniaTime.Text = "末次时间:";
            this.m_rdbLastCatameniaTime.UseVisualStyleBackColor = true;
            this.m_rdbLastCatameniaTime.CheckedChanged += new System.EventHandler(this.m_rdbLastCatameniaTime_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(248, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 10000119;
            this.label1.Text = "情况:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(4, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 10000081;
            this.label13.Text = "初潮:";
            // 
            // m_cboFirstCatamenia
            // 
            this.m_cboFirstCatamenia.BackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.BorderColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFirstCatamenia.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboFirstCatamenia.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFirstCatamenia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFirstCatamenia.ForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.ListBackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFirstCatamenia.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboFirstCatamenia.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.Location = new System.Drawing.Point(50, 5);
            this.m_cboFirstCatamenia.m_BlnEnableItemEventMenu = true;
            this.m_cboFirstCatamenia.Name = "m_cboFirstCatamenia";
            this.m_cboFirstCatamenia.SelectedIndex = -1;
            this.m_cboFirstCatamenia.SelectedItem = null;
            this.m_cboFirstCatamenia.SelectionStart = 0;
            this.m_cboFirstCatamenia.Size = new System.Drawing.Size(60, 26);
            this.m_cboFirstCatamenia.TabIndex = 150;
            this.m_cboFirstCatamenia.TextBackColor = System.Drawing.Color.White;
            this.m_cboFirstCatamenia.TextForeColor = System.Drawing.Color.Black;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(116, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 10000083;
            this.label14.Text = "经期:";
            // 
            // m_cboCatameniaLastTime
            // 
            this.m_cboCatameniaLastTime.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.BorderColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaLastTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaLastTime.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaLastTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaLastTime.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaLastTime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaLastTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.Location = new System.Drawing.Point(168, 7);
            this.m_cboCatameniaLastTime.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaLastTime.Name = "m_cboCatameniaLastTime";
            this.m_cboCatameniaLastTime.SelectedIndex = -1;
            this.m_cboCatameniaLastTime.SelectedItem = null;
            this.m_cboCatameniaLastTime.SelectionStart = 0;
            this.m_cboCatameniaLastTime.Size = new System.Drawing.Size(76, 26);
            this.m_cboCatameniaLastTime.TabIndex = 160;
            this.m_cboCatameniaLastTime.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaLastTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(248, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 10000085;
            this.label15.Text = "周期:";
            // 
            // m_cboCatameniaCycle
            // 
            this.m_cboCatameniaCycle.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.BorderColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaCycle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaCycle.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCycle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCycle.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCycle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaCycle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.Location = new System.Drawing.Point(300, 7);
            this.m_cboCatameniaCycle.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaCycle.Name = "m_cboCatameniaCycle";
            this.m_cboCatameniaCycle.SelectedIndex = -1;
            this.m_cboCatameniaCycle.SelectedItem = null;
            this.m_cboCatameniaCycle.SelectionStart = 0;
            this.m_cboCatameniaCycle.Size = new System.Drawing.Size(80, 26);
            this.m_cboCatameniaCycle.TabIndex = 170;
            this.m_cboCatameniaCycle.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCycle.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_dtpLastCatameniaTime
            // 
            this.m_dtpLastCatameniaTime.BorderColor = System.Drawing.Color.White;
            this.m_dtpLastCatameniaTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpLastCatameniaTime.DropButtonBackColor = System.Drawing.Color.White;
            this.m_dtpLastCatameniaTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpLastCatameniaTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpLastCatameniaTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpLastCatameniaTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpLastCatameniaTime.ForeColor = System.Drawing.Color.Black;
            this.m_dtpLastCatameniaTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpLastCatameniaTime.Location = new System.Drawing.Point(499, 9);
            this.m_dtpLastCatameniaTime.m_BlnOnlyTime = false;
            this.m_dtpLastCatameniaTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpLastCatameniaTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpLastCatameniaTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpLastCatameniaTime.Name = "m_dtpLastCatameniaTime";
            this.m_dtpLastCatameniaTime.ReadOnly = false;
            this.m_dtpLastCatameniaTime.Size = new System.Drawing.Size(140, 22);
            this.m_dtpLastCatameniaTime.TabIndex = 180;
            this.m_dtpLastCatameniaTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpLastCatameniaTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboAmeniaAge
            // 
            this.m_cboAmeniaAge.AccessibleDescription = "闭经年龄";
            this.m_cboAmeniaAge.BackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.BorderColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAmeniaAge.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAmeniaAge.Enabled = false;
            this.m_cboAmeniaAge.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAmeniaAge.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAmeniaAge.ForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.ListBackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAmeniaAge.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboAmeniaAge.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.Location = new System.Drawing.Point(499, 36);
            this.m_cboAmeniaAge.m_BlnEnableItemEventMenu = true;
            this.m_cboAmeniaAge.Name = "m_cboAmeniaAge";
            this.m_cboAmeniaAge.SelectedIndex = -1;
            this.m_cboAmeniaAge.SelectedItem = null;
            this.m_cboAmeniaAge.SelectionStart = 0;
            this.m_cboAmeniaAge.Size = new System.Drawing.Size(140, 26);
            this.m_cboAmeniaAge.TabIndex = 190;
            this.m_cboAmeniaAge.TextBackColor = System.Drawing.Color.White;
            this.m_cboAmeniaAge.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboCatameniaCase
            // 
            this.m_cboCatameniaCase.BackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.BorderColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.DropButtonBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCatameniaCase.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboCatameniaCase.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCase.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboCatameniaCase.ForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.ListBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.ListForeColor = System.Drawing.Color.Black;
            this.m_cboCatameniaCase.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboCatameniaCase.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.Location = new System.Drawing.Point(300, 36);
            this.m_cboCatameniaCase.m_BlnEnableItemEventMenu = true;
            this.m_cboCatameniaCase.Name = "m_cboCatameniaCase";
            this.m_cboCatameniaCase.SelectedIndex = -1;
            this.m_cboCatameniaCase.SelectedItem = null;
            this.m_cboCatameniaCase.SelectionStart = 0;
            this.m_cboCatameniaCase.Size = new System.Drawing.Size(80, 26);
            this.m_cboCatameniaCase.TabIndex = 190;
            this.m_cboCatameniaCase.TextBackColor = System.Drawing.Color.White;
            this.m_cboCatameniaCase.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtCatameniaHistory
            // 
            this.m_txtCatameniaHistory.AccessibleDescription = "生育史";
            this.m_txtCatameniaHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCatameniaHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtCatameniaHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCatameniaHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtCatameniaHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCatameniaHistory.Location = new System.Drawing.Point(72, 36);
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
            this.m_txtCatameniaHistory.Multiline = false;
            this.m_txtCatameniaHistory.Name = "m_txtCatameniaHistory";
            this.m_txtCatameniaHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCatameniaHistory.Size = new System.Drawing.Size(172, 24);
            this.m_txtCatameniaHistory.TabIndex = 200;
            this.m_txtCatameniaHistory.Tag = "6";
            this.m_txtCatameniaHistory.Text = "";
            // 
            // m_lklCatamenia
            // 
            this.m_lklCatamenia.AutoSize = true;
            this.m_lklCatamenia.BackColor = System.Drawing.Color.White;
            this.m_lklCatamenia.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lklCatamenia.ForeColor = System.Drawing.Color.White;
            this.m_lklCatamenia.Location = new System.Drawing.Point(4, 36);
            this.m_lklCatamenia.Name = "m_lklCatamenia";
            this.m_lklCatamenia.Size = new System.Drawing.Size(64, 16);
            this.m_lklCatamenia.TabIndex = 10000118;
            this.m_lklCatamenia.TabStop = true;
            this.m_lklCatamenia.Tag = "m_txtCatameniaHistory";
            this.m_lklCatamenia.Text = "生育史:";
            this.m_lklCatamenia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // pnlFocus
            // 
            this.pnlFocus.Location = new System.Drawing.Point(8, 8);
            this.pnlFocus.Name = "pnlFocus";
            this.pnlFocus.Size = new System.Drawing.Size(0, 0);
            this.pnlFocus.TabIndex = 10000107;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 308);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 10000108;
            this.label10.Tag = "7";
            this.label10.Text = "三测:";
            // 
            // m_lklMainDescription
            // 
            this.m_lklMainDescription.AutoSize = true;
            this.m_lklMainDescription.Location = new System.Drawing.Point(13, 15);
            this.m_lklMainDescription.Name = "m_lklMainDescription";
            this.m_lklMainDescription.Size = new System.Drawing.Size(48, 16);
            this.m_lklMainDescription.TabIndex = 0;
            this.m_lklMainDescription.TabStop = true;
            this.m_lklMainDescription.Tag = "m_txtMainDescription";
            this.m_lklMainDescription.Text = "主诉:";
            this.m_lklMainDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklCurrentStatus
            // 
            this.m_lklCurrentStatus.AutoSize = true;
            this.m_lklCurrentStatus.Location = new System.Drawing.Point(13, 37);
            this.m_lklCurrentStatus.Name = "m_lklCurrentStatus";
            this.m_lklCurrentStatus.Size = new System.Drawing.Size(64, 16);
            this.m_lklCurrentStatus.TabIndex = 0;
            this.m_lklCurrentStatus.TabStop = true;
            this.m_lklCurrentStatus.Tag = "m_txtCurrentStatus";
            this.m_lklCurrentStatus.Text = "现病史:";
            this.m_lklCurrentStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklBeforetimeStatus
            // 
            this.m_lklBeforetimeStatus.AutoSize = true;
            this.m_lklBeforetimeStatus.Location = new System.Drawing.Point(13, 59);
            this.m_lklBeforetimeStatus.Name = "m_lklBeforetimeStatus";
            this.m_lklBeforetimeStatus.Size = new System.Drawing.Size(64, 16);
            this.m_lklBeforetimeStatus.TabIndex = 0;
            this.m_lklBeforetimeStatus.TabStop = true;
            this.m_lklBeforetimeStatus.Tag = "m_txtBeforetimeStatus";
            this.m_lklBeforetimeStatus.Text = "既往史:";
            this.m_lklBeforetimeStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklMarriageHistory
            // 
            this.m_lklMarriageHistory.AutoSize = true;
            this.m_lklMarriageHistory.Location = new System.Drawing.Point(13, 103);
            this.m_lklMarriageHistory.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.m_lklMarriageHistory.Name = "m_lklMarriageHistory";
            this.m_lklMarriageHistory.Size = new System.Drawing.Size(64, 16);
            this.m_lklMarriageHistory.TabIndex = 0;
            this.m_lklMarriageHistory.TabStop = true;
            this.m_lklMarriageHistory.Tag = "m_txtMarriageHistory";
            this.m_lklMarriageHistory.Text = "婚姻史:";
            this.m_lklMarriageHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklOwnHistory
            // 
            this.m_lklOwnHistory.AutoSize = true;
            this.m_lklOwnHistory.Location = new System.Drawing.Point(13, 81);
            this.m_lklOwnHistory.Name = "m_lklOwnHistory";
            this.m_lklOwnHistory.Size = new System.Drawing.Size(64, 16);
            this.m_lklOwnHistory.TabIndex = 0;
            this.m_lklOwnHistory.TabStop = true;
            this.m_lklOwnHistory.Tag = "m_txtOwnHistory";
            this.m_lklOwnHistory.Text = "个人史:";
            this.m_lklOwnHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_lklFamilyHistory
            // 
            this.m_lklFamilyHistory.AutoSize = true;
            this.m_lklFamilyHistory.Location = new System.Drawing.Point(13, 231);
            this.m_lklFamilyHistory.Name = "m_lklFamilyHistory";
            this.m_lklFamilyHistory.Size = new System.Drawing.Size(64, 16);
            this.m_lklFamilyHistory.TabIndex = 0;
            this.m_lklFamilyHistory.TabStop = true;
            this.m_lklFamilyHistory.Tag = "m_txtFamilyHistory";
            this.m_lklFamilyHistory.Text = "家族史:";
            this.m_lklFamilyHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel7.LinkColor = System.Drawing.Color.Black;
            this.linkLabel7.Location = new System.Drawing.Point(67, 308);
            this.linkLabel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(48, 16);
            this.linkLabel7.TabIndex = 0;
            this.linkLabel7.Tag = "m_txtTemperature";
            this.linkLabel7.Text = "体温:";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel8.LinkColor = System.Drawing.Color.Black;
            this.linkLabel8.Location = new System.Drawing.Point(189, 308);
            this.linkLabel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(48, 16);
            this.linkLabel8.TabIndex = 0;
            this.linkLabel8.Tag = "m_txtPulse";
            this.linkLabel8.Text = "脉搏:";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel9.LinkColor = System.Drawing.Color.Black;
            this.linkLabel9.Location = new System.Drawing.Point(331, 308);
            this.linkLabel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(48, 16);
            this.linkLabel9.TabIndex = 0;
            this.linkLabel9.Tag = "m_txtBreath";
            this.linkLabel9.Text = "呼吸:";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel10.LinkColor = System.Drawing.Color.Black;
            this.linkLabel10.Location = new System.Drawing.Point(465, 308);
            this.linkLabel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(48, 16);
            this.linkLabel10.TabIndex = 0;
            this.linkLabel10.Tag = "m_txtSys";
            this.linkLabel10.Text = "血压:";
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // m_lblCatameniaBorn
            // 
            this.m_lblCatameniaBorn.AutoSize = true;
            this.m_lblCatameniaBorn.ForeColor = System.Drawing.Color.Black;
            this.m_lblCatameniaBorn.Location = new System.Drawing.Point(13, 129);
            this.m_lblCatameniaBorn.Name = "m_lblCatameniaBorn";
            this.m_lblCatameniaBorn.Size = new System.Drawing.Size(96, 16);
            this.m_lblCatameniaBorn.TabIndex = 10000117;
            this.m_lblCatameniaBorn.Text = "月经生育史:";
            // 
            // m_txtDirectorDoc
            // 
            this.m_txtDirectorDoc.BackColor = System.Drawing.Color.White;
            this.m_txtDirectorDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtDirectorDoc.Location = new System.Drawing.Point(100, 50);
            this.m_txtDirectorDoc.Name = "m_txtDirectorDoc";
            this.m_txtDirectorDoc.ReadOnly = true;
            this.m_txtDirectorDoc.Size = new System.Drawing.Size(100, 19);
            this.m_txtDirectorDoc.TabIndex = 10000124;
            this.m_txtDirectorDoc.Visible = false;
            // 
            // m_txtChargeDoc
            // 
            this.m_txtChargeDoc.BackColor = System.Drawing.Color.White;
            this.m_txtChargeDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtChargeDoc.Location = new System.Drawing.Point(547, 895);
            this.m_txtChargeDoc.Name = "m_txtChargeDoc";
            this.m_txtChargeDoc.ReadOnly = true;
            this.m_txtChargeDoc.Size = new System.Drawing.Size(100, 19);
            this.m_txtChargeDoc.TabIndex = 10000125;
            this.m_txtChargeDoc.Visible = false;
            // 
            // m_cmdChargeDoc
            // 
            this.m_cmdChargeDoc.AutoSize = true;
            this.m_cmdChargeDoc.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdChargeDoc.Location = new System.Drawing.Point(3, 31);
            this.m_cmdChargeDoc.Name = "m_cmdChargeDoc";
            this.m_cmdChargeDoc.Size = new System.Drawing.Size(80, 16);
            this.m_cmdChargeDoc.TabIndex = 10000110;
            this.m_cmdChargeDoc.TabStop = true;
            this.m_cmdChargeDoc.Text = "主治医师:";
            this.m_cmdChargeDoc.Visible = false;
            // 
            // m_cmdDirectorDoc
            // 
            this.m_cmdDirectorDoc.AutoSize = true;
            this.m_cmdDirectorDoc.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdDirectorDoc.Location = new System.Drawing.Point(50, 0);
            this.m_cmdDirectorDoc.Name = "m_cmdDirectorDoc";
            this.m_cmdDirectorDoc.Size = new System.Drawing.Size(80, 16);
            this.m_cmdDirectorDoc.TabIndex = 10000109;
            this.m_cmdDirectorDoc.TabStop = true;
            this.m_cmdDirectorDoc.Text = "主任医师:";
            this.m_cmdDirectorDoc.Visible = false;
            // 
            // m_pnlContent1
            // 
            this.m_pnlContent1.Controls.Add(this.linkLabel3);
            this.m_pnlContent1.Controls.Add(this.linkLabel33);
            this.m_pnlContent1.Controls.Add(this.label7);
            this.m_pnlContent1.Controls.Add(this.m_cmdDirectorDoc);
            this.m_pnlContent1.Controls.Add(this.m_cmdChargeDoc);
            this.m_pnlContent1.Controls.Add(this.m_txtChargeDoc);
            this.m_pnlContent1.Controls.Add(this.m_txtDirectorDoc);
            this.m_pnlContent1.Controls.Add(this.pnlFocus);
            this.m_pnlContent1.Location = new System.Drawing.Point(552, 256);
            this.m_pnlContent1.Name = "m_pnlContent1";
            this.m_pnlContent1.Size = new System.Drawing.Size(82, 70);
            this.m_pnlContent1.TabIndex = 500;
            this.m_pnlContent1.Visible = false;
            this.m_pnlContent1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(0, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(80, 16);
            this.linkLabel3.TabIndex = 10000130;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "m_txtMedical";
            this.linkLabel3.Text = "详细描述:";
            // 
            // linkLabel33
            // 
            this.linkLabel33.AutoSize = true;
            this.linkLabel33.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabel33.Location = new System.Drawing.Point(100, 0);
            this.linkLabel33.Name = "linkLabel33";
            this.linkLabel33.Size = new System.Drawing.Size(80, 16);
            this.linkLabel33.TabIndex = 10000129;
            this.linkLabel33.TabStop = true;
            this.linkLabel33.Text = "医师签名:";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(1, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 1);
            this.label7.TabIndex = 10000128;
            this.label7.Visible = false;
            // 
            // m_txtMainDescription
            // 
            this.m_txtMainDescription.AccessibleDescription = "主诉";
            this.m_txtMainDescription.BackColor = System.Drawing.Color.White;
            this.m_txtMainDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtMainDescription.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDescription.ForeColor = System.Drawing.Color.Black;
            this.m_txtMainDescription.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDescription.Location = new System.Drawing.Point(67, 15);
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
            this.m_txtMainDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtMainDescription.Name = "m_txtMainDescription";
            this.m_txtMainDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtMainDescription.Size = new System.Drawing.Size(596, 19);
            this.m_txtMainDescription.TabIndex = 90;
            this.m_txtMainDescription.Tag = "5";
            this.m_txtMainDescription.Text = "";
            // 
            // m_pnlContent
            // 
            this.m_pnlContent.Controls.Add(this.m_lklMainDescription);
            this.m_pnlContent.Controls.Add(this.m_txtMainDescription);
            this.m_pnlContent.Controls.Add(this.m_lklCurrentStatus);
            this.m_pnlContent.Controls.Add(this.m_txtCurrentStatus);
            this.m_pnlContent.Controls.Add(this.m_lklBeforetimeStatus);
            this.m_pnlContent.Controls.Add(this.m_txtBeforetimeStatus);
            this.m_pnlContent.Controls.Add(this.m_lklOwnHistory);
            this.m_pnlContent.Controls.Add(this.m_txtOwnHistory);
            this.m_pnlContent.Controls.Add(this.m_lklMarriageHistory);
            this.m_pnlContent.Controls.Add(this.m_txtMarriageHistory);
            this.m_pnlContent.Controls.Add(this.m_lblCatameniaBorn);
            this.m_pnlContent.Controls.Add(this.m_chkCatamenia);
            this.m_pnlContent.Controls.Add(this.m_pnlCatamenia);
            this.m_pnlContent.Controls.Add(this.m_lklFamilyHistory);
            this.m_pnlContent.Controls.Add(this.m_txtFamilyHistory);
            this.m_pnlContent.Controls.Add(this.m_lblMedicineCheckTitle);
            this.m_pnlContent.Controls.Add(this.label10);
            this.m_pnlContent.Controls.Add(this.linkLabel7);
            this.m_pnlContent.Controls.Add(this.m_txtTemperature);
            this.m_pnlContent.Controls.Add(this.label17);
            this.m_pnlContent.Controls.Add(this.linkLabel8);
            this.m_pnlContent.Controls.Add(this.m_txtPulse);
            this.m_pnlContent.Controls.Add(this.label18);
            this.m_pnlContent.Controls.Add(this.linkLabel9);
            this.m_pnlContent.Controls.Add(this.m_txtBreath);
            this.m_pnlContent.Controls.Add(this.label19);
            this.m_pnlContent.Controls.Add(this.linkLabel10);
            this.m_pnlContent.Controls.Add(this.m_txtSys);
            this.m_pnlContent.Controls.Add(this.lblSys);
            this.m_pnlContent.Controls.Add(this.m_txtDia);
            this.m_pnlContent.Controls.Add(this.label8);
            this.m_pnlContent.Controls.Add(this.m_lklMedical);
            this.m_pnlContent.Controls.Add(this.m_txtMedical);
            this.m_pnlContent.Controls.Add(this.m_lklProfessionalCheck);
            this.m_pnlContent.Controls.Add(this.m_txtProfessionalCheck);
            this.m_pnlContent.Controls.Add(this.ctlPaintContainer1);
            this.m_pnlContent.Controls.Add(this.m_lklLabCheck);
            this.m_pnlContent.Controls.Add(this.m_txtLabCheck);
            this.m_pnlContent.Controls.Add(this.m_lklPrimaryDiagnose);
            this.m_pnlContent.Controls.Add(this.m_txtPrimaryDiagnose);
            this.m_pnlContent.Controls.Add(this.m_lklModifyDiagnose);
            this.m_pnlContent.Controls.Add(this.m_thtxtModifydiagnose);
            this.m_pnlContent.Controls.Add(this.m_cmdModifyDiagnoseDoctor);
            this.m_pnlContent.Controls.Add(this.m_txtModifyDiagnoseDoctor);
            this.m_pnlContent.Controls.Add(this.label2);
            this.m_pnlContent.Controls.Add(this.m_dtpModifyDiagnoseDate);
            this.m_pnlContent.Controls.Add(this.label5);
            this.m_pnlContent.Controls.Add(this.m_lklAddDiagnose);
            this.m_pnlContent.Controls.Add(this.m_thtxtaddDiagnose);
            this.m_pnlContent.Controls.Add(this.m_cmdAddDiagnoseDoctor);
            this.m_pnlContent.Controls.Add(this.m_txtAddDiagnoseDoctor);
            this.m_pnlContent.Controls.Add(this.label3);
            this.m_pnlContent.Controls.Add(this.m_dtpAddDiagnoseDate);
            this.m_pnlContent.Controls.Add(this.label6);
            this.m_pnlContent.Location = new System.Drawing.Point(79, 354);
            this.m_pnlContent.Name = "m_pnlContent";
            this.m_pnlContent.Padding = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.m_pnlContent.Size = new System.Drawing.Size(677, 887);
            this.m_pnlContent.TabIndex = 10000130;
            // 
            // m_txtDia
            // 
            this.m_txtDia.AccessibleDescription = "血压";
            this.m_txtDia.BackColor = System.Drawing.Color.White;
            this.m_txtDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtDia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDia.ForeColor = System.Drawing.Color.Black;
            this.m_txtDia.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDia.Location = new System.Drawing.Point(579, 306);
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
            this.m_txtDia.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtDia.Multiline = false;
            this.m_txtDia.Name = "m_txtDia";
            this.m_txtDia.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtDia.Size = new System.Drawing.Size(28, 21);
            this.m_txtDia.TabIndex = 10000118;
            this.m_txtDia.Tag = "8";
            this.m_txtDia.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(613, 308);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 10000119;
            this.label8.Tag = "8";
            this.label8.Text = "mmHg";
            // 
            // m_lklMedical
            // 
            this.m_lklMedical.AutoSize = true;
            this.m_lklMedical.Location = new System.Drawing.Point(13, 330);
            this.m_lklMedical.Name = "m_lklMedical";
            this.m_lklMedical.Size = new System.Drawing.Size(80, 16);
            this.m_lklMedical.TabIndex = 10000120;
            this.m_lklMedical.TabStop = true;
            this.m_lklMedical.Tag = "m_txtMedical";
            this.m_lklMedical.Text = "详细描述:";
            this.m_lklMedical.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtMedical
            // 
            this.m_txtMedical.AccessibleDescription = "体格检查";
            this.m_txtMedical.BackColor = System.Drawing.Color.White;
            this.m_txtMedical.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtMedical.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedical.ForeColor = System.Drawing.Color.Black;
            this.m_txtMedical.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMedical.Location = new System.Drawing.Point(99, 330);
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
            this.m_txtMedical.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtMedical.Name = "m_txtMedical";
            this.m_txtMedical.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtMedical.Size = new System.Drawing.Size(564, 19);
            this.m_txtMedical.TabIndex = 300;
            this.m_txtMedical.Tag = "8";
            this.m_txtMedical.Text = "";
            // 
            // m_lklProfessionalCheck
            // 
            this.m_lklProfessionalCheck.AutoSize = true;
            this.m_lklProfessionalCheck.Location = new System.Drawing.Point(13, 352);
            this.m_lklProfessionalCheck.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.m_lklProfessionalCheck.Name = "m_lklProfessionalCheck";
            this.m_lklProfessionalCheck.Size = new System.Drawing.Size(80, 16);
            this.m_lklProfessionalCheck.TabIndex = 10000122;
            this.m_lklProfessionalCheck.TabStop = true;
            this.m_lklProfessionalCheck.Tag = "m_txtProfessionalCheck";
            this.m_lklProfessionalCheck.Text = "专科检查:";
            this.m_lklProfessionalCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtProfessionalCheck
            // 
            this.m_txtProfessionalCheck.AccessibleDescription = "专科检查";
            this.m_txtProfessionalCheck.BackColor = System.Drawing.Color.White;
            this.m_txtProfessionalCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtProfessionalCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProfessionalCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtProfessionalCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtProfessionalCheck.Location = new System.Drawing.Point(99, 352);
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
            this.m_txtProfessionalCheck.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtProfessionalCheck.Name = "m_txtProfessionalCheck";
            this.m_txtProfessionalCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtProfessionalCheck.Size = new System.Drawing.Size(564, 19);
            this.m_txtProfessionalCheck.TabIndex = 350;
            this.m_txtProfessionalCheck.Tag = "9";
            this.m_txtProfessionalCheck.Text = "";
            // 
            // ctlPaintContainer1
            // 
            this.ctlPaintContainer1.AutoScroll = true;
            this.ctlPaintContainer1.BackColor = System.Drawing.Color.White;
            this.ctlPaintContainer1.ForeColor = System.Drawing.Color.Black;
            this.ctlPaintContainer1.Location = new System.Drawing.Point(13, 381);
            this.ctlPaintContainer1.m_BlnCanAddImage = true;
            this.ctlPaintContainer1.m_BlnScaleSize = true;
            this.ctlPaintContainer1.m_ClrcmdRubber = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrcmdSelected = System.Drawing.Color.White;
            this.ctlPaintContainer1.m_ClrgpbTools = System.Drawing.Color.White;
            this.ctlPaintContainer1.m_ClrppgPicSize = System.Drawing.Color.White;
            this.ctlPaintContainer1.m_ClrrdbDash = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbLine = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbPen = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_ClrrdbText = System.Drawing.Color.Silver;
            this.ctlPaintContainer1.m_IntDefaultHeight = 253;
            this.ctlPaintContainer1.m_IntDefaultWidth = 320;
            this.ctlPaintContainer1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.ctlPaintContainer1.Name = "ctlPaintContainer1";
            this.ctlPaintContainer1.Size = new System.Drawing.Size(652, 244);
            this.ctlPaintContainer1.TabIndex = 400;
            this.ctlPaintContainer1.选择科室图片 = com.digitalwave.Utility.Controls.ctlPaintContainer.enmImageNames.无;
            // 
            // m_lklLabCheck
            // 
            this.m_lklLabCheck.AutoSize = true;
            this.m_lklLabCheck.Location = new System.Drawing.Point(13, 635);
            this.m_lklLabCheck.Name = "m_lklLabCheck";
            this.m_lklLabCheck.Size = new System.Drawing.Size(80, 16);
            this.m_lklLabCheck.TabIndex = 10000125;
            this.m_lklLabCheck.TabStop = true;
            this.m_lklLabCheck.Tag = "m_txtLabCheck";
            this.m_lklLabCheck.Text = "辅助检查:";
            this.m_lklLabCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtLabCheck
            // 
            this.m_txtLabCheck.AccessibleDescription = "辅助检查";
            this.m_txtLabCheck.BackColor = System.Drawing.Color.White;
            this.m_txtLabCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtLabCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLabCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtLabCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLabCheck.Location = new System.Drawing.Point(99, 635);
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
            this.m_txtLabCheck.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtLabCheck.Name = "m_txtLabCheck";
            this.m_txtLabCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtLabCheck.Size = new System.Drawing.Size(564, 21);
            this.m_txtLabCheck.TabIndex = 450;
            this.m_txtLabCheck.Tag = "10";
            this.m_txtLabCheck.Text = "";
            // 
            // m_lklPrimaryDiagnose
            // 
            this.m_lklPrimaryDiagnose.AutoSize = true;
            this.m_lklPrimaryDiagnose.Location = new System.Drawing.Point(13, 659);
            this.m_lklPrimaryDiagnose.Name = "m_lklPrimaryDiagnose";
            this.m_lklPrimaryDiagnose.Size = new System.Drawing.Size(80, 16);
            this.m_lklPrimaryDiagnose.TabIndex = 10000127;
            this.m_lklPrimaryDiagnose.TabStop = true;
            this.m_lklPrimaryDiagnose.Tag = "m_txtPrimaryDiagnose";
            this.m_lklPrimaryDiagnose.Text = "入院诊断:";
            this.m_lklPrimaryDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_txtPrimaryDiagnose
            // 
            this.m_txtPrimaryDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtPrimaryDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtPrimaryDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPrimaryDiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrimaryDiagnose.ForeColor = System.Drawing.Color.Red;
            this.m_txtPrimaryDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPrimaryDiagnose.Location = new System.Drawing.Point(99, 659);
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
            this.m_txtPrimaryDiagnose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtPrimaryDiagnose.MaxLength = 4000;
            this.m_txtPrimaryDiagnose.Name = "m_txtPrimaryDiagnose";
            this.m_txtPrimaryDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtPrimaryDiagnose.Size = new System.Drawing.Size(564, 21);
            this.m_txtPrimaryDiagnose.TabIndex = 500;
            this.m_txtPrimaryDiagnose.Tag = "10";
            this.m_txtPrimaryDiagnose.Text = "";
            // 
            // m_lklModifyDiagnose
            // 
            this.m_lklModifyDiagnose.AutoSize = true;
            this.m_lklModifyDiagnose.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lklModifyDiagnose.Location = new System.Drawing.Point(13, 683);
            this.m_lklModifyDiagnose.Name = "m_lklModifyDiagnose";
            this.m_lklModifyDiagnose.Size = new System.Drawing.Size(80, 16);
            this.m_lklModifyDiagnose.TabIndex = 10000129;
            this.m_lklModifyDiagnose.TabStop = true;
            this.m_lklModifyDiagnose.Text = "修正诊断:";
            this.m_lklModifyDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_thtxtModifydiagnose
            // 
            this.m_thtxtModifydiagnose.AccessibleDescription = "修正诊断";
            this.m_thtxtModifydiagnose.AccessibleName = "m_thtxtModifydiagnose";
            this.m_thtxtModifydiagnose.BackColor = System.Drawing.Color.White;
            this.m_thtxtModifydiagnose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_thtxtModifydiagnose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_thtxtModifydiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_thtxtModifydiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_thtxtModifydiagnose.Location = new System.Drawing.Point(99, 683);
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
            this.m_thtxtModifydiagnose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.m_thtxtModifydiagnose.MaxLength = 4000;
            this.m_thtxtModifydiagnose.Name = "m_thtxtModifydiagnose";
            this.m_thtxtModifydiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_thtxtModifydiagnose.Size = new System.Drawing.Size(564, 21);
            this.m_thtxtModifydiagnose.TabIndex = 550;
            this.m_thtxtModifydiagnose.Tag = "12";
            this.m_thtxtModifydiagnose.Text = "";
            // 
            // m_cmdModifyDiagnoseDoctor
            // 
            this.m_cmdModifyDiagnoseDoctor.AutoSize = true;
            this.m_cmdModifyDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdModifyDiagnoseDoctor.Location = new System.Drawing.Point(200, 724);
            this.m_cmdModifyDiagnoseDoctor.Margin = new System.Windows.Forms.Padding(190, 0, 3, 0);
            this.m_cmdModifyDiagnoseDoctor.Name = "m_cmdModifyDiagnoseDoctor";
            this.m_cmdModifyDiagnoseDoctor.Size = new System.Drawing.Size(80, 16);
            this.m_cmdModifyDiagnoseDoctor.TabIndex = 600;
            this.m_cmdModifyDiagnoseDoctor.TabStop = true;
            this.m_cmdModifyDiagnoseDoctor.Text = "医师签名:";
            this.m_cmdModifyDiagnoseDoctor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // m_txtModifyDiagnoseDoctor
            // 
            this.m_txtModifyDiagnoseDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtModifyDiagnoseDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtModifyDiagnoseDoctor.Location = new System.Drawing.Point(286, 724);
            this.m_txtModifyDiagnoseDoctor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtModifyDiagnoseDoctor.Name = "m_txtModifyDiagnoseDoctor";
            this.m_txtModifyDiagnoseDoctor.ReadOnly = true;
            this.m_txtModifyDiagnoseDoctor.Size = new System.Drawing.Size(76, 19);
            this.m_txtModifyDiagnoseDoctor.TabIndex = 10000132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(368, 726);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000133;
            this.label2.Text = "日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpModifyDiagnoseDate
            // 
            this.m_dtpModifyDiagnoseDate.BorderColor = System.Drawing.Color.Transparent;
            this.m_dtpModifyDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpModifyDiagnoseDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpModifyDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpModifyDiagnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpModifyDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpModifyDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpModifyDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpModifyDiagnoseDate.Location = new System.Drawing.Point(416, 724);
            this.m_dtpModifyDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpModifyDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpModifyDiagnoseDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_dtpModifyDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpModifyDiagnoseDate.Name = "m_dtpModifyDiagnoseDate";
            this.m_dtpModifyDiagnoseDate.ReadOnly = false;
            this.m_dtpModifyDiagnoseDate.Size = new System.Drawing.Size(213, 22);
            this.m_dtpModifyDiagnoseDate.TabIndex = 700;
            this.m_dtpModifyDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpModifyDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(200, 749);
            this.label5.Margin = new System.Windows.Forms.Padding(190, 0, 3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(438, 1);
            this.label5.TabIndex = 10000135;
            // 
            // m_lklAddDiagnose
            // 
            this.m_lklAddDiagnose.AutoSize = true;
            this.m_lklAddDiagnose.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lklAddDiagnose.Location = new System.Drawing.Point(13, 770);
            this.m_lklAddDiagnose.Name = "m_lklAddDiagnose";
            this.m_lklAddDiagnose.Size = new System.Drawing.Size(80, 16);
            this.m_lklAddDiagnose.TabIndex = 10000136;
            this.m_lklAddDiagnose.TabStop = true;
            this.m_lklAddDiagnose.Text = "补充诊断:";
            this.m_lklAddDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lklMain_LinkClicked);
            // 
            // m_thtxtaddDiagnose
            // 
            this.m_thtxtaddDiagnose.AccessibleDescription = "补充诊断";
            this.m_thtxtaddDiagnose.BackColor = System.Drawing.Color.White;
            this.m_thtxtaddDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_thtxtaddDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_thtxtaddDiagnose.ForeColor = System.Drawing.Color.Red;
            this.m_thtxtaddDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_thtxtaddDiagnose.Location = new System.Drawing.Point(99, 770);
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
            this.m_thtxtaddDiagnose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.m_thtxtaddDiagnose.MaxLength = 4000;
            this.m_thtxtaddDiagnose.Name = "m_thtxtaddDiagnose";
            this.m_thtxtaddDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_thtxtaddDiagnose.Size = new System.Drawing.Size(554, 21);
            this.m_thtxtaddDiagnose.TabIndex = 800;
            this.m_thtxtaddDiagnose.Tag = "12";
            this.m_thtxtaddDiagnose.Text = "";
            // 
            // m_cmdAddDiagnoseDoctor
            // 
            this.m_cmdAddDiagnoseDoctor.AutoSize = true;
            this.m_cmdAddDiagnoseDoctor.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdAddDiagnoseDoctor.Location = new System.Drawing.Point(200, 811);
            this.m_cmdAddDiagnoseDoctor.Margin = new System.Windows.Forms.Padding(190, 0, 3, 0);
            this.m_cmdAddDiagnoseDoctor.Name = "m_cmdAddDiagnoseDoctor";
            this.m_cmdAddDiagnoseDoctor.Size = new System.Drawing.Size(80, 16);
            this.m_cmdAddDiagnoseDoctor.TabIndex = 900;
            this.m_cmdAddDiagnoseDoctor.TabStop = true;
            this.m_cmdAddDiagnoseDoctor.Text = "医师签名:";
            this.m_cmdAddDiagnoseDoctor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // m_txtAddDiagnoseDoctor
            // 
            this.m_txtAddDiagnoseDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtAddDiagnoseDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtAddDiagnoseDoctor.Location = new System.Drawing.Point(286, 811);
            this.m_txtAddDiagnoseDoctor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_txtAddDiagnoseDoctor.Name = "m_txtAddDiagnoseDoctor";
            this.m_txtAddDiagnoseDoctor.ReadOnly = true;
            this.m_txtAddDiagnoseDoctor.Size = new System.Drawing.Size(76, 19);
            this.m_txtAddDiagnoseDoctor.TabIndex = 10000139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(368, 813);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000140;
            this.label3.Text = "日期:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpAddDiagnoseDate
            // 
            this.m_dtpAddDiagnoseDate.BorderColor = System.Drawing.Color.Transparent;
            this.m_dtpAddDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpAddDiagnoseDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpAddDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpAddDiagnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpAddDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpAddDiagnoseDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpAddDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAddDiagnoseDate.Location = new System.Drawing.Point(416, 811);
            this.m_dtpAddDiagnoseDate.m_BlnOnlyTime = false;
            this.m_dtpAddDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpAddDiagnoseDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.m_dtpAddDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpAddDiagnoseDate.Name = "m_dtpAddDiagnoseDate";
            this.m_dtpAddDiagnoseDate.ReadOnly = false;
            this.m_dtpAddDiagnoseDate.Size = new System.Drawing.Size(213, 22);
            this.m_dtpAddDiagnoseDate.TabIndex = 1000;
            this.m_dtpAddDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpAddDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(200, 836);
            this.label6.Margin = new System.Windows.Forms.Padding(190, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(438, 1);
            this.label6.TabIndex = 10000142;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gray;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 1319);
            this.pictureBox2.TabIndex = 10000131;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(821, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 1319);
            this.pictureBox1.TabIndex = 10000132;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox3.Location = new System.Drawing.Point(30, 1292);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(791, 27);
            this.pictureBox3.TabIndex = 10000133;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(36, 1250);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.TabIndex = 10000101;
            this.pictureBox4.TabStop = false;
            // 
            // frmInPatientCaseHistory_NewStyle
            // 
            this.AccessibleDescription = "住  院  病  历 1";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 458);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_pnlContent1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.lblInPatientDate);
            this.Controls.Add(this.m_lklInPatientDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.m_lklRecorder);
            this.Controls.Add(this.lblRepresentor);
            this.Controls.Add(this.lblCredibility);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_txtFinallyDiagnose);
            this.Controls.Add(this.m_lblArea);
            this.Controls.Add(this.m_lblPhone);
            this.Controls.Add(this.m_cboRepresentor);
            this.Controls.Add(this.m_cboCredibility);
            this.Controls.Add(this.m_txtFinallyDiagnose_1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.m_picRB);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.m_pnlContent);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInPatientCaseHistory_NewStyle";
            this.Text = "住院病历--自由录入风格";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmInPatientCaseHistory_NewStyle_Closing);
            this.Load += new System.EventHandler(this.frmInPatientCaseHistory_NewStyle_Load);
            this.Controls.SetChildIndex(this.m_pnlContent, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.m_picRB, 0);
            this.Controls.SetChildIndex(this.pictureBox8, 0);
            this.Controls.SetChildIndex(this.m_txtFinallyDiagnose_1, 0);
            this.Controls.SetChildIndex(this.m_cboCredibility, 0);
            this.Controls.SetChildIndex(this.m_cboRepresentor, 0);
            this.Controls.SetChildIndex(this.m_lblPhone, 0);
            this.Controls.SetChildIndex(this.m_lblArea, 0);
            this.Controls.SetChildIndex(this.m_txtFinallyDiagnose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.lblCredibility, 0);
            this.Controls.SetChildIndex(this.lblRepresentor, 0);
            this.Controls.SetChildIndex(this.m_lklRecorder, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.m_lklInPatientDate, 0);
            this.Controls.SetChildIndex(this.lblInPatientDate, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.m_pnlContent1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
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
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
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
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picRB)).EndInit();
            this.m_pnlCatamenia.ResumeLayout(false);
            this.m_pnlCatamenia.PerformLayout();
            this.m_pnlContent1.ResumeLayout(false);
            this.m_pnlContent1.PerformLayout();
            this.m_pnlContent.ResumeLayout(false);
            this.m_pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_mthSetTooltip()
		{
			this.m_tip.SetToolTip(this.m_picMainDescription ,"隐藏主诉"); 
			this.m_tip.SetToolTip(this.m_picCurrentStatus ,"隐藏现病史"); 
			this.m_tip.SetToolTip(this.m_picBeforetimeStatus ,"隐藏既往史");  
			this.m_tip.SetToolTip(this.m_picOwnHistory ,"隐藏个人史"); 
			this.m_tip.SetToolTip(this.m_picCatameniaHistory ,"隐藏月经史"); 
			this.m_tip.SetToolTip(this.m_picFamilyHistory ,"隐藏家族史"); 
			this.m_tip.SetToolTip(this.m_picMarriageHistory ,"隐藏婚姻史");
			this.m_tip.SetToolTip(this.m_picProfessionalCheck ,"隐藏专科检查");
			this.m_tip.SetToolTip(this.m_picSummary ,"隐藏摘要");
			this.m_tip.SetToolTip(this.m_picDiagnose ,"隐藏诊断");
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
			frmMedicalExam001 frmMedicalExam = (frmMedicalExam001)sender;
			if(frmMedicalExam.m_blnIsOK )
			{
				m_txtMedical.m_mthClearText();
				m_txtMedical.m_mthInsertText(m_objMedicalExamDomain.m_strGetMedicalExamUnitString (frmMedicalExam),0);
				//体格检查窗体上按确定后，提取画图信息
				//				m_objPicValueArr = frmMedicalExam.m_objPicValueArr;
			}
		}

		#endregion
		#region 载入数据,刘颖源,2003-5-29 21:07:52
		private void m_mthLoadMedicalExam()
		{
			m_objMedicalExamDomain.m_mthDisplayMedicalExamOptions (this,"00000000000000000001");
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
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);

			m_strCurrentOpenDate = "";

			this.m_txtBeforetimeStatus.m_mthClearText();
			this.m_txtBreath.m_mthClearText();
			this.m_txtCurrentStatus.m_mthClearText();
			this.m_txtDia.m_mthClearText();
			this.m_txtFamilyHistory.m_mthClearText();
			this.m_txtFinallyDiagnose.m_mthClearText();
			this.m_txtFinallyDiagnoseDocID.Text="";
			this.m_txtLabCheck.m_mthClearText();
			this.m_txtMainDescription .m_mthClearText();
			this.m_txtMarriageHistory.m_mthClearText();
			this.m_txtMedical.m_mthClearText();
			this.m_txtOwnHistory.m_mthClearText();
			this.m_txtPrimaryDiagnose.m_mthClearText();
			this.m_txtPrimaryDiagnoseDocID.Text="";
			this.m_txtProfessionalCheck.m_mthClearText() ;
			this.m_txtPulse.m_mthClearText();
			this.m_txtSummary.m_mthClearText();
			this.m_txtTemperature.m_mthClearText();
			this.m_txtSys.m_mthClearText();
			this.m_dtpFinallyDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
			this.m_dtpPrimaryDiagnoseDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
//			this.m_txtChargeDoc.Text = "";
//			this.m_txtMidwife.Text = "";
//			this.m_txtDirectorDoc.Text = "";
				
			m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );			
			m_strMedicalExam_ID ="";
			m_mthSetModifyControl(null,true);			
			
			m_dtpCreateDate.Enabled = true;
			m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");  

			//			m_mthClearAllPic(ctlPaintContainer1);
            ctlPaintContainer1.m_mthClear();
            m_cboFirstCatamenia.Text = "";
            m_cboCatameniaLastTime.Text = "";
            m_cboCatameniaCycle.Text = "";
            m_dtpLastCatameniaTime.Value = DateTime.Now;
            m_cboCatameniaCase.Text = "";

            if (m_objBaseCurrentPatient!=null && m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
            {
                m_mthEnableCatamenia(false);
            }
            m_rdbAmeniaAge.Checked = false;
            m_rdbLastCatameniaTime.Checked = false;
            m_cboAmeniaAge.Text = string.Empty;
            m_thtxtModifydiagnose.m_mthClearText();
            m_txtModifyDiagnoseDoctor.Text = string.Empty;
            m_txtModifyDiagnoseDoctor.Tag = null;
            m_dtpModifyDiagnoseDate.Value = DateTime.Now;
            m_thtxtaddDiagnose.m_mthClearText();
            m_txtAddDiagnoseDoctor.Text = string.Empty;
            m_txtAddDiagnoseDoctor.Tag = null;
            m_dtpAddDiagnoseDate.Value = DateTime.Now;
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
			if(p_blnEnable)
			{
				this.m_txtPrimaryDiagnoseDocID.Enabled =true;
				this.m_txtFinallyDiagnoseDocID.Enabled =true;

			}
			else
			{
				if(this.m_txtPrimaryDiagnoseDocID.Text !="")
					this.m_txtPrimaryDiagnoseDocID.Enabled =false;
				if(this.m_txtFinallyDiagnoseDocID.Text !="")
					this.m_txtFinallyDiagnoseDocID.Enabled =false;
			}

		}

	

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected override clsInPatientCaseHistoryContent m_objGetContentFromGUI()
		{
			clsInPatientCaseHistoryContent m_objContent=new clsInPatientCaseHistoryContent();

            m_objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
            m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;

            //获取签名
            m_objContent.objSignerArr = new clsEmrSigns_VO[1];
            m_objContent.objSignerArr[0] = new clsEmrSigns_VO();
            m_objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
            m_objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            m_objContent.objSignerArr[0].controlName = "txtSign";
            m_objContent.objSignerArr[0].m_strFORMID_VCHR = "frmInPatientCaseHistory";//注意大小写
            m_objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

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
			
			string strTemp=this.m_txtFinallyDiagnose.m_strGetRightText().Trim().Replace("；",";");
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
			
			strTemp=this.m_txtPrimaryDiagnose.m_strGetRightText().Trim().Replace("；",";");
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
			
			m_objContent.m_strFinallyDiagnoseDate=this.m_dtpFinallyDiagnoseDate.Text ;
			m_objContent.m_strPrimaryDiagnoseDate=this.m_dtpPrimaryDiagnoseDate.Text ;
			
			m_objContent.m_strPrimaryDiagnoseDocID =(this.m_txtPrimaryDiagnoseDocID .Text=="" ? "":(string)this.m_txtPrimaryDiagnoseDocID.Tag );
			
			m_objContent.m_strFinallyDiagnoseDocID =(m_txtFinallyDiagnoseDocID.Text =="" ? "" : (string)this.m_txtFinallyDiagnoseDocID.Tag); 
 
			m_objContent.m_strCreateName =MDIParent.OperatorName ;
			m_objContent.m_strPrimaryDiagnoseDocName =this.m_txtPrimaryDiagnoseDocID.Text ;
			m_objContent.m_strFinallyDiagnosDocName =this.m_txtFinallyDiagnoseDocID.Text ;

			//补充月经部分
			m_objContent.m_strFirstCatamenia =this.m_cboFirstCatamenia.Text ;
			m_objContent.m_strCatameniaLastTime =this.m_cboCatameniaLastTime.Text ;
			m_objContent.m_strCatameniaCycle =this.m_cboCatameniaCycle.Text ;
			m_objContent.m_dtmLastCatameniaTime =this.m_dtpLastCatameniaTime.Value ;
			m_objContent.m_strCatameniaCase =this.m_cboCatameniaCase.Text.Trim() ;

            m_objContent.m_intSelectedMC = m_chkCatamenia.Checked ? 1 : 0; 
			
//			m_objContent.m_strYJS		= m_txtYJS.m_strGetRightText();
//			m_objContent.m_strYJSAll	= m_txtYJS.Text;
//			m_objContent.m_strYJSXML	= m_txtYJS.m_strGetXmlText();

//			m_objContent.m_strContraHistory		= m_txtContraHistory.m_strGetRightText();
//			m_objContent.m_strContraHistoryAll	= m_txtContraHistory.Text;
//			m_objContent.m_strContraHistoryXML	= m_txtContraHistory.m_strGetXmlText();

//			m_objContent.m_strShYS		= m_txtShYS.m_strGetRightText();
//			m_objContent.m_strShYSAll	= m_txtShYS.Text;
//			m_objContent.m_strShYSXML	= m_txtShYS.m_strGetXmlText();

//			m_objContent.m_strLCQK		= m_txtLCQK.m_strGetRightText();
//			m_objContent.m_strLCQKAll	= m_txtLCQK.Text;
//			m_objContent.m_strLCQKXML	= m_txtLCQK.m_strGetXmlText();

//			m_objContent.m_strCQJC		= m_txtCQJC.m_strGetRightText();
//			m_objContent.m_strCQJCAll	= m_txtCQJC.Text;
//			m_objContent.m_strCQJCXML	= m_txtCQJC.m_strGetXmlText();

//			m_objContent.m_strPregTimes = m_cboPregTimes.Text;
//			m_objContent.m_strBornTimes = m_cboBornTimes.Text;
			
//			m_objContent.m_strCarePlan = this.m_txtCareplan.m_strGetRightText();
//			m_objContent.m_strCarePlanAll = this.m_txtCareplan.Text;
//			m_objContent.m_strCarePlanXML = this.m_txtCareplan.m_strGetXmlText();

//			m_objContent.m_strOldMaternitySuffer= this.m_txtOldMaternitySuffer.m_strGetRightText();
//			m_objContent.m_strOldMaternitySufferAll = this.m_txtOldMaternitySuffer.Text;
//			m_objContent.m_strOldMaternitySufferXML = this.m_txtOldMaternitySuffer.m_strGetXmlText();

//			m_objContent.m_strChargeDoctor = m_txtChargeDoc.Text;
//			m_objContent.m_strDiretDoctor = m_txtDirectorDoc.Text; 
//			m_objContent.m_strMidWife =  m_txtMidwife.Text;
			m_objContent.m_datModifyDiagnose=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objContent.m_datAddDiagnose=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
            m_objContent.m_strModifyDiagnose = this.m_thtxtModifydiagnose.m_strGetRightText();
            m_objContent.m_strModifyDiagnoseAll = this.m_thtxtModifydiagnose.Text;
            m_objContent.m_strModifyDiagnoseXML = this.m_thtxtModifydiagnose.m_strGetXmlText();
            if (this.m_txtModifyDiagnoseDoctor.Tag != null)
                m_objContent.m_strModifyDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtModifyDiagnoseDoctor.Tag).m_strEMPNO_CHR;
            m_objContent.m_datModifyDiagnose = DateTime.Parse(m_dtpModifyDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            //补充诊断
            //进行判断，一旦写入补充诊断则要求签名 否则
            if (this.m_thtxtaddDiagnose.Text.Trim().Length != 0)
            {
                if (m_txtAddDiagnoseDoctor.Text.Trim().Length == 0)
                {
                    MessageBox.Show("已进行补充诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            m_objContent.m_strAddDiagnose = this.m_thtxtaddDiagnose.m_strGetRightText();
            m_objContent.m_strAddDiagnoseALL = this.m_thtxtaddDiagnose.Text;
            m_objContent.m_strAddDiagnoseXML = this.m_thtxtaddDiagnose.m_strGetXmlText();
            if (this.m_txtAddDiagnoseDoctor.Tag != null)
                m_objContent.m_strAddDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtAddDiagnoseDoctor.Tag).m_strEMPNO_CHR;
            m_objContent.m_datAddDiagnose = DateTime.Parse(m_dtpAddDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            //主治医师
            if (this.m_txtChargeDoc.Tag != null)
                m_objContent.m_strChargeDoctor = ((clsEmrEmployeeBase_VO)this.m_txtChargeDoc.Tag).m_strEMPNO_CHR;
            //主任医师
            if (this.m_txtDirectorDoc.Tag != null)
                m_objContent.m_strDiretDoctor = ((clsEmrEmployeeBase_VO)this.m_txtDirectorDoc.Tag).m_strEMPNO_CHR;

            m_objContent.m_intSELECTEDLASTCATAMENIATIME = m_rdbLastCatameniaTime.Checked ? 1 : 0;
            m_objContent.m_intSELECTEDAMENIAAGE = m_rdbAmeniaAge.Checked ? 1 : 0;
            m_objContent.m_strAMENIAAGE = m_cboAmeniaAge.Text;

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
				m_strMedicalExam_ID =m_objMedicalExamDomain.strGetInPatientCaseMedicalExam_ID (p_objContent.m_strInPatientID,p_objContent.m_dtmInPatientDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_objContent.m_dtmOpenDate.ToString ("yyyy-MM-dd HH:mm:ss"));
			}
			else
			{
				m_strMedicalExam_ID ="";
			}
			this.m_txtMainDescription.m_mthSetNewText(p_objContent.m_strMainDescriptionAll ,p_objContent.m_strMainDescriptionXML );
			this.m_txtCurrentStatus.m_mthSetNewText(p_objContent.m_strCurrentStatusXAll,p_objContent.m_strCurrentStatusXML );
			this.m_txtBeforetimeStatus.m_mthSetNewText( p_objContent.m_strBeforetimeStatusAll,p_objContent.m_strBeforetimeStatusXML); 
			this.m_txtMarriageHistory.m_mthSetNewText(p_objContent.m_strMarriageHistoryAll,p_objContent.m_strMarriageHistoryXML  );
			this.m_txtOwnHistory.m_mthSetNewText(p_objContent.m_strOwnHistoryAll ,p_objContent.m_strOwnHistoryXML );
			this.m_txtFamilyHistory.m_mthSetNewText(p_objContent.m_strFamilyHistoryAll,p_objContent.m_strFamilyHistoryXML  );
			this.m_txtTemperature.m_mthSetNewText(p_objContent.m_strTemperatureAll ,p_objContent.m_strTemperatureXML );
			this.m_txtPulse.m_mthSetNewText(p_objContent.m_strPulseAll ,p_objContent.m_strPulseXML );
			this.m_txtBreath.m_mthSetNewText(p_objContent.m_strBreathAll, p_objContent.m_strBreathXML);   
			this.m_txtSys.m_mthSetNewText(p_objContent.m_strSysAll ,p_objContent.m_strSysXML );
			this.m_txtDia.m_mthSetNewText(p_objContent.m_strDiaAll ,p_objContent.m_strDiaXML );
			this.m_txtMedical.m_mthSetNewText(p_objContent.m_strMedicalAll ,p_objContent.m_strMedicalXML );
			this.m_txtProfessionalCheck.m_mthSetNewText(p_objContent.m_strProfessionalCheckAll ,p_objContent.m_strProfessionalCheckXML );
			this.m_txtLabCheck.m_mthSetNewText(p_objContent.m_strLabCheckAll ,p_objContent.m_strLabCheckXML );
			this.m_txtPrimaryDiagnose.m_mthSetNewText(p_objContent.m_strPrimaryDiagnoseAll ,p_objContent.m_strPrimaryDiagnoseXML );
			this.m_txtFinallyDiagnose.m_mthSetNewText(p_objContent.m_strFinallyDiagnoseAll,p_objContent.m_strFinallyDiagnoseXML  );
			this.m_txtSummary.m_mthSetNewText(p_objContent.m_strSummaryAll ,p_objContent.m_strSummaryXML );
			this.m_dtpFinallyDiagnoseDate .Text =(p_objContent.m_strFinallyDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strFinallyDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_dtpPrimaryDiagnoseDate .Text =(p_objContent.m_strPrimaryDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;
			if (p_objContent.m_strPrimaryDiagnoseDocID != null && p_objContent.m_strPrimaryDiagnoseDocID != string.Empty)
			{
				clsEmployee []  objPDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_objContent.m_strPrimaryDiagnoseDocID ,m_objCurrentContext.m_ObjDepartment);
				if(objPDoctorArr.Length !=0)
				{
					this.m_txtPrimaryDiagnoseDocID.Text =objPDoctorArr[0].m_StrFirstName; 
					this.m_txtPrimaryDiagnoseDocID.Tag =objPDoctorArr[0].m_StrEmployeeID; 
					p_objContent.m_strPrimaryDiagnoseDocName =objPDoctorArr[0].m_StrFirstName;
				}
			}
			if (p_objContent.m_strFinallyDiagnoseDocID != null && p_objContent.m_strFinallyDiagnoseDocID != string.Empty)
			{
				clsEmployee [] objFDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_objContent.m_strFinallyDiagnoseDocID ,m_objCurrentContext.m_ObjDepartment);
				if(objFDoctorArr.Length !=0)
				{
					this.m_txtFinallyDiagnoseDocID.Text =objFDoctorArr[0].m_StrFirstName;
					this.m_txtFinallyDiagnoseDocID.Tag =objFDoctorArr[0].m_StrEmployeeID;
					p_objContent.m_strFinallyDiagnosDocName =objFDoctorArr[0].m_StrFirstName;
			
				}
			}
			if(m_strMedicalExam_ID=="")
			{
				m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );  
			}
			else
				m_objMedicalExamDomain.m_mthDisplayMedicalExamOptions (this.m_objMedicalExamForm ,m_strMedicalExam_ID );


            //补充月经部分
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {
                this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
                this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                //if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                //    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                //if (m_cboCatameniaCase.Text.Equals("已绝经"))
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
            
            //m_chkCatamenia.Checked = !(m_txtCatameniaHistory.Text.Trim() == "");
			//补充妇产科部分
//			m_txtYJS.m_mthSetNewText(p_objContent.m_strYJSAll,p_objContent.m_strYJSXML);
//			m_txtContraHistory.m_mthSetNewText(p_objContent.m_strContraHistoryAll,p_objContent.m_strContraHistoryXML);
//			m_txtShYS.m_mthSetNewText(p_objContent.m_strShYSAll,p_objContent.m_strShYSXML);
//			m_txtLCQK.m_mthSetNewText(p_objContent.m_strLCQKAll,p_objContent.m_strLCQKXML);
//			m_txtCQJC.m_mthSetNewText(p_objContent.m_strCQJCAll,p_objContent.m_strCQJCXML);
//			m_txtCareplan.m_mthSetNewText(p_objContent.m_strCarePlanAll,p_objContent.m_strCarePlanXML);
//			m_cboPregTimes.Text = p_objContent.m_strPregTimes;
//			m_cboBornTimes.Text = p_objContent.m_strBornTimes;
//			m_txtChargeDoc.Text = p_objContent.m_strChargeDoctor;
//			m_txtDirectorDoc.Text = p_objContent.m_strDiretDoctor;
//			m_txtMidwife.Text = p_objContent.m_strMidWife;
//			m_txtOldMaternitySuffer.m_mthSetNewText(p_objContent.m_strOldMaternitySufferAll,p_objContent.m_strOldMaternitySufferXML);
            //this.m_thtxtModifydiagnose.m_mthSetNewText(p_objContent.m_strModifyDiagnoseAll, p_objContent.m_strModifyDiagnoseXML);
            //this.m_thtxtaddDiagnose.m_mthSetNewText(p_objContent.m_strAddDiagnoseALL, p_objContent.m_strAddDiagnoseXML);
            this.m_thtxtModifydiagnose.m_mthSetCustomNewText(p_objContent.m_strModifyDiagnoseAll, p_objContent.m_strModifyDiagnoseXML, Color.Red);
            this.m_thtxtaddDiagnose.m_mthSetCustomNewText(p_objContent.m_strAddDiagnoseALL, p_objContent.m_strAddDiagnoseXML, Color.Red);
            try
            {
                this.m_dtpModifyDiagnoseDate.Value = p_objContent.m_datModifyDiagnose;
                this.m_dtpAddDiagnoseDate.Value = p_objContent.m_datAddDiagnose;
            }
            catch (Exception ex)
            {
            }
            #region 签名赋值
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            if (p_objContent.m_strCreateUserID != null && p_objContent.m_strCreateUserID.Trim().Length != 0)
            {
                clsEmrEmployeeBase_VO objSign4 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strCreateUserID.Trim(), out objSign4);
                if (objSign4 != null)
                {
                    txtSign.Text = objSign4.m_strLASTNAME_VCHR;
                    txtSign.Tag = objSign4;
                    txtSign.Enabled = false;
                }

            }
            if (p_objContent.m_strModifyDiagnoseDoctorID != null && p_objContent.m_strModifyDiagnoseDoctorID.Trim().Length != 0)
            {
                clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strModifyDiagnoseDoctorID.Trim(), out objSign);
                if (objSign != null)
                {
                    m_txtModifyDiagnoseDoctor.Text = objSign.m_strLASTNAME_VCHR;
                    m_txtModifyDiagnoseDoctor.Tag = objSign;
                    m_txtModifyDiagnoseDoctor.Enabled = false;
                }

            }

            if (p_objContent.m_strAddDiagnoseDoctorID != null && p_objContent.m_strAddDiagnoseDoctorID.Trim().Length != 0)
            {
                clsEmrEmployeeBase_VO objSign1 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strAddDiagnoseDoctorID.Trim(), out objSign1);
                if (objSign1 != null)
                {
                    m_txtAddDiagnoseDoctor.Text = objSign1.m_strLASTNAME_VCHR;
                    m_txtAddDiagnoseDoctor.Tag = objSign1;
                    m_txtAddDiagnoseDoctor.Enabled = false;
                }

            }
            if (p_objContent.m_strDiretDoctor != null && p_objContent.m_strDiretDoctor.Trim().Length != 0)
            {
                clsEmrEmployeeBase_VO objSign2 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strDiretDoctor.Trim(), out objSign2);
                if (objSign2 != null)
                {
                    m_txtDirectorDoc.Text = objSign2.m_strLASTNAME_VCHR;
                    m_txtDirectorDoc.Tag = objSign2;
                    m_txtDirectorDoc.Enabled = false;
                }

            }
            if (p_objContent.m_strChargeDoctor != null && p_objContent.m_strChargeDoctor.Trim().Length != 0)
            {
                clsEmrEmployeeBase_VO objSign3 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strChargeDoctor.Trim(), out objSign3);
                if (objSign3 != null)
                {
                    m_txtChargeDoc.Text = objSign3.m_strLASTNAME_VCHR;
                    m_txtChargeDoc.Tag = objSign3;
                    m_txtChargeDoc.Enabled = false;
                }

            }

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
                if (m_ObjCurrentEmrPatientSession == null || string.IsNullOrEmpty(m_strCurrentOpenDate))
				{
					MDIParent.ShowInformationMessageBox("请先选择记录");
					return "";
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


		protected override void m_mthSetNewRecord()
		{
			if(m_objCurrentPatient != null)
			{			
				//签名默认值
				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtPrimaryDiagnoseDocID);
				clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtFinallyDiagnoseDocID);

				//默认值 m_IntCurCase
				new clsDefaultValueTool(this,m_objCurrentPatient).m_mthSetDefaultValue();
				//				new clsDefaultValueTool(m_objMedicalExamForm).m_mthSetDefaultValue();

				#region 三测数据
//				clsThreeMeasureShareDomain.stuFirstValue stuValue;
//				long lngRes = m_objShareDomain.m_lngGetFirstValue(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),out stuValue);
//
//				if(lngRes > 0)
//				{
//					m_txtTemperature.Text = stuValue.m_strTemperatureValue;
//					m_txtPulse.Text = stuValue.m_strPulseValue;
//					m_mthSyncPluse(null,EventArgs.Empty);
//					m_txtBreath.Text = stuValue.m_strBreathValue;
//
//					try
//					{
//						if(stuValue.m_strSystolicValue != "")
//						{
//							if(stuValue.m_strSystolicValue!="" || stuValue.m_strSystolicValue!=null)
//							{
//								m_txtSys.Text = float.Parse(stuValue.m_strSystolicValue).ToString("0");
//							}
//							if(stuValue.m_strDiastolicValue!="" || stuValue.m_strDiastolicValue!=null)
//							{
//								m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue).ToString("0");
//							}
//						
//						}
//						else
//						{
//							if(stuValue.m_strSystolicValue2!="" || stuValue.m_strSystolicValue2!=null)
//							{
//								m_txtSys.Text = float.Parse(stuValue.m_strSystolicValue2).ToString("0");
//							}
//							if(stuValue.m_strDiastolicValue2!="" || stuValue.m_strDiastolicValue!=null)
//							{
//								m_txtDia.Text = float.Parse(stuValue.m_strDiastolicValue2).ToString("0");
//							}
//						}
//					}
//					catch
//					{
//					}		
//				}//end if
				#endregion

				m_txtMainDescription.Focus();

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
			m_objMedicalExamDomain.m_mthSaveMedicalExamRecord (this.m_objMedicalExamForm,"001",objMedicalExamInHopital);
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
			m_objMedicalExamDomain.m_mthSaveMedicalExamRecord (this.m_objMedicalExamForm,"001",objMedicalExamInHopital);
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
				m_objMedicalExamDomain.m_mthClearMedicalExamControls (this.m_objMedicalExamForm );  
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
			m_strMedicalExam_ID =m_objMedicalExamDomain.strGetInPatientCaseMedicalExam_ID (m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"));
			m_objMedicalExamDomain.m_mthDisplayMedicalExamOptions (this.m_objMedicalExamForm ,m_strMedicalExam_ID );
						
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
			this.m_dtpFinallyDiagnoseDate .Text =(p_objContent.m_strFinallyDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strFinallyDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_dtpPrimaryDiagnoseDate .Text =(p_objContent.m_strPrimaryDiagnoseDate==null ? DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") : DateTime.Parse(p_objContent.m_strPrimaryDiagnoseDate).ToString("yyyy年MM月dd日 HH:mm:ss"));
			this.m_cboCredibility.Text =p_objContent.m_strCredibility;
			this.m_cboRepresentor.Text =p_objContent.m_strRepresentor;
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
//			this.m_txtYJS.Text = p_objContent.m_strYJS;
//			this.m_txtContraHistory.Text				= p_objContent.m_strContraHistory;
//			this.m_txtShYS.Text = p_objContent.m_strShYS;
//			this.m_txtLCQK.Text = p_objContent.m_strLCQK;
//			this.m_txtCQJC.Text = p_objContent.m_strCQJC;
//			this.m_txtCareplan.Text = p_objContent.m_strCarePlan;
//			this.m_cboPregTimes.Text = p_objContent.m_strPregTimes;
//			this.m_cboBornTimes.Text = p_objContent.m_strBornTimes;
//			this.m_txtOldMaternitySuffer.Text = p_objContent.m_strOldMaternitySuffer;
//			this.m_txtChargeDoc.Text = p_objContent.m_strChargeDoctor;
//			this.m_txtDirectorDoc.Text = p_objContent.m_strDiretDoctor;
//			this.m_txtMidwife.Text = p_objContent.m_strMidWife;
		}

		public override int m_IntFormID
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
					
					//					if(sender.GetType().Name!="ctlRichTextBox")
					//						SendKeys.Send(  "{tab}");
					if(((Control)sender).Name=="m_txtPrimaryDiagnoseDocID")
					{
						m_bytListOnDoctor = 0;
						m_mthGetDoctorList(m_txtPrimaryDiagnoseDocID.Text);

						if(this.m_lsvFinallyDiagnoseDocID .Items.Count==1 && (m_txtPrimaryDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[0].Text|| m_txtPrimaryDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[1].Text))
						{
							m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
							m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="m_txtFinallyDiagnoseDocID")
					{
						m_bytListOnDoctor = 1;
						m_mthGetDoctorList(m_txtFinallyDiagnoseDocID.Text);

						if(m_lsvFinallyDiagnoseDocID.Items.Count==1 && (m_txtFinallyDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[0].Text || m_txtFinallyDiagnoseDocID.Text==m_lsvFinallyDiagnoseDocID.Items[0].SubItems[1].Text))
						{
							m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
							m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="m_lsvFinallyDiagnoseDocID")
					{
						m_lsvFinallyDiagnoseDocID_DoubleClick(null,null);						
					}

					break;

				case 38:
				case 40:
					if(((Control)sender).Name=="m_txtPrimaryDiagnoseDocID")
					{
						if(m_txtPrimaryDiagnoseDocID.Text.Length>0)
						{	
							if(m_lsvFinallyDiagnoseDocID.Visible==false || m_lsvFinallyDiagnoseDocID.Items.Count==0)
							{
								m_bytListOnDoctor = 0;
								m_mthGetDoctorList(m_txtPrimaryDiagnoseDocID.Text);
							}

							m_lsvFinallyDiagnoseDocID.BringToFront();
							m_lsvFinallyDiagnoseDocID.Visible=true;
							m_lsvFinallyDiagnoseDocID.Focus();
							if( m_lsvFinallyDiagnoseDocID.Items.Count>0)
							{
								m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
								m_lsvFinallyDiagnoseDocID.Items[0].Focused=true;
							}	
						}
					}

					else if(((Control)sender).Name=="m_txtFinallyDiagnoseDocID" )
					{
						if(m_txtFinallyDiagnoseDocID.Text.Length>0)
						{	
							if(m_lsvFinallyDiagnoseDocID.Visible==false || m_lsvFinallyDiagnoseDocID.Items.Count==0)
							{
								m_bytListOnDoctor = 1;
								m_mthGetDoctorList(m_txtFinallyDiagnoseDocID.Text);
								//	m_lsvDoctorList.BringToFront();
								//	m_lsvDoctorList.Visible=true;
							}							
							m_lsvFinallyDiagnoseDocID.Focus();
							if( m_lsvFinallyDiagnoseDocID.Items.Count>0)
							{
								m_lsvFinallyDiagnoseDocID.Items[0].Selected=true;
								m_lsvFinallyDiagnoseDocID.Items[0].Focused=true;
							}	
						}
					}
					
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
				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

			if(objDoctorArr == null)
			{
				m_lsvFinallyDiagnoseDocID.Visible = false;
				return;
			}

			switch(m_bytListOnDoctor)
			{
				case 0:
					m_lsvFinallyDiagnoseDocID.Left = m_txtPrimaryDiagnoseDocID.Left ;
					m_lsvFinallyDiagnoseDocID.Top  = m_txtPrimaryDiagnoseDocID.Top +m_txtPrimaryDiagnoseDocID.Height ;
					break;
				case 1:
					m_lsvFinallyDiagnoseDocID.Left = m_txtFinallyDiagnoseDocID.Left  ;
					m_lsvFinallyDiagnoseDocID.Top  = m_txtFinallyDiagnoseDocID.Top +m_txtFinallyDiagnoseDocID.Height ;
					break;
			}			

			m_lsvFinallyDiagnoseDocID.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

				m_lsvFinallyDiagnoseDocID.Items.Add(lviDoctor);
			}

			//但显示的行数大于6时，减小最后一列的宽度，以显示滚动条
			m_mthChangeListViewLastColumnWidth(m_lsvFinallyDiagnoseDocID);

			m_lsvFinallyDiagnoseDocID.BringToFront();
			m_lsvFinallyDiagnoseDocID.Visible = true;
		}
		
		private void m_lsvDoctorList_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

			if(objEmp == null)
				return;

			//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
			//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtPrimaryDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
					//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
					m_txtFinallyDiagnoseDocID .Text = objEmp.m_StrLastName;
					m_txtFinallyDiagnoseDocID.Tag = objEmp.m_StrEmployeeID;
					//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		private void m_lsvFinallyDiagnoseDocID_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(m_lsvFinallyDiagnoseDocID.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvFinallyDiagnoseDocID.SelectedItems[0].Tag;

			if(objEmp == null)
				return;

			//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
			//				return;

			m_blnCanDoctorTextChanged = false;
			switch(m_bytListOnDoctor)
			{
				case 0:
					m_txtPrimaryDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtPrimaryDiagnoseDocID.Tag = (string)objEmp.m_StrEmployeeID;
					//					m_blnCanOperateDoctorSelect = true;
					break;
				case 1:
					m_txtFinallyDiagnoseDocID.Text = objEmp.m_StrLastName;
					m_txtFinallyDiagnoseDocID.Tag =(string)objEmp.m_StrEmployeeID;
					//					m_blnCanChargeDoctorSelect = true;
					break;
			}
			m_blnCanDoctorTextChanged = true;

			m_lsvFinallyDiagnoseDocID.Visible = false;
		}

		#endregion
	
		#region 显示/隐藏界面显示
		private void ControlVisableShow(string intControlIndex,int strLocationY)
		{
			foreach(Control control in this.m_pnlContent1.Controls )
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

			m_pnlContent1.Height +=strLocationY;
			
			
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
			m_pnlContent1.Height -=strLocationY;
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
						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtPrimaryDiagnoseDocID.Focused)
						{
							m_lsvFinallyDiagnoseDocID.Visible=false;
						}
						break;
					case 1:
						if(!m_lsvFinallyDiagnoseDocID.Focused && !m_txtFinallyDiagnoseDocID.Focused)
						{
							m_lsvFinallyDiagnoseDocID.Visible=false;
						}
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

		private void frmInPatientCaseHistory_NewStyle_Load(object sender, System.EventArgs e)
		{
			TreeNode tndInPatientDate=new TreeNode();
			tndInPatientDate.Text ="入院日期";
			this.trvTime.Nodes.Add(tndInPatientDate); 
			if(m_objCurrentPatient == null)
				this.trvTime.Visible = false;

            m_mthSetQuickKeys();

			m_dtpCreateDate.m_EnmVisibleFlag  = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			m_dtpCreateDate.m_mthResetSize();

			m_txtMainDescription.Focus();
//			new clsPublicFunction().m_mthSetControlEnter2Tab(new Control[]{m_txtTemperature,m_txtPulse,m_txtBreath,m_txtSys,m_txtDia,m_txtMainDescription});
//			com.digitalwave.controls.ctlRichTextBox.m_ClrDefaultViewText = Color.Black;

			m_hasKeyword = new Hashtable();
			m_hasKeyword.Add("意识","清晰|模糊|昏睡|轻度昏迷|中度昏迷|深度昏迷|嗜睡");
			m_ctlCheckedList = new com.digitalwave.Utility.Controls.ctlCheckedListBox();
			m_ctlCheckedList.Font = new System.Drawing.Font("Simsun",9);
			m_ctlCheckedList.m_evtAddClicked += new EventHandler(CheckedList_AddClicked);
			m_ctlCheckedList.m_evtReplaceClicked += new EventHandler(CheckedList_ReplaceClicked);			
			m_ctlCheckedList.Visible = false;
			m_ctlCheckedList.Leave += new EventHandler(CheckedList_Leave);
			m_pnlContent.Controls.Add(m_ctlCheckedList);
		}

		#region 隐藏控制		
		/// <summary>
		/// 设置月经生育史需不需要
		/// </summary>
		/// <param name="p_blnIfEnable"></param>
		private void m_mthEnableCatamenia(bool p_blnIfEnable)
		{
			int intOffset;
			if(p_blnIfEnable)
				intOffset = m_pnlCatamenia.Height;
			else
				intOffset = -m_pnlCatamenia.Height;
			foreach(Control ctl in m_pnlContent1.Controls)
			{
				if(ctl.Top > m_lblCatameniaBorn.Top)
					ctl.Top += intOffset;
			}
			m_pnlContent1.Height += intOffset;

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
				m_pnlCatamenia.Top = m_lblCatameniaBorn.Bottom + 5;
				m_txtCatameniaHistory.m_BlnReadOnly = false;
				this.m_cboFirstCatamenia.Text = "14岁";
				this.m_cboCatameniaLastTime.Text = "5-6天";
				this.m_cboCatameniaCycle.Text ="28-30天" ;
				this.m_cboCatameniaCase.Text = "经量正常";
				this.m_txtCatameniaHistory.Text = "G1P1，一男一女，健康";
			}

			m_pnlCatamenia.Visible = p_blnIfEnable;
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
			m_lblCatameniaBorn.Visible = false;
			m_chkCatamenia.Visible = false;
			m_pnlCatamenia.Visible = false;
            //m_objBorderTool.m_mthUnChangedControlBorder(m_txtCatameniaHistory);

			int intVSpace = m_pnlCatamenia.Height + m_lblCatameniaBorn.Height;
			foreach(Control ctlSub in m_pnlContent1.Controls)
				if(ctlSub.Top > m_pnlCatamenia.Top)
					ctlSub.Top -= intVSpace;
			m_pnlContent1.Height -= intVSpace;
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
			foreach(Control ctlSub in m_pnlContent1.Controls)
				if(ctlSub.Top > p_txtItem.Top)
					ctlSub.Top -= intVSpace;
			m_pnlContent1.Height -= intVSpace;
		}

		#endregion

//		private void m_cboPregTimes_DropDown(object sender, System.EventArgs e)
//		{
//			m_cboPregTimes.ClearItem();
//			for(int i=1; i<=4; i++)
//			{
//				m_cboPregTimes.AddItem(i.ToString());
//			}
//		}

//		private void m_cboBornTimes_DropDown(object sender, System.EventArgs e)
//		{
//			m_cboBornTimes.ClearItem();
//			for(int i=1; i<=4; i++)
//			{
//				m_cboBornTimes.AddItem(i.ToString());
//			}
//		}

		private void frmInPatientCaseHistory_NewStyle_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MDIParent.m_EnmCaseType = frmInPatientCaseHistory.enmCaseType.默认;
//			com.digitalwave.controls.ctlRichTextBox.m_ClrDefaultViewText = Color.White;
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

		
		private void m_mthSetItemVisible()
		{
			m_cmdCreateID.Visible = false;
			lblDept.Visible = false;
			m_cboDept.Visible = false;
			lblAreaTitle.Visible = false;
			m_cboArea.Visible = false;
//			trvTime.Visible = false;

            if (m_objBaseCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
			{
                string strAreaID = m_ObjCurrentEmrPatientSession.m_strAreaId;
			
				if(m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrSex=="男")
					m_mthHideCatameniaItem();
				if(m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrMarried == "未婚")
					m_mthHideItem(m_txtMarriageHistory,m_lklMarriageHistory);
			}
		}


		// 设置病人表单信息
        //protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        //{
        //    base.m_mthSetPatientFormInfo();
//			//判断病人信息是否为null，如果是，直接返回。
//			if(p_objSelectedPatient == null)
//				return;   	
//		
//			//清空病人记录信息
//			m_mthClearPatientRecordInfo();
//		
//			//记录病人信息
            //m_objCurrentPatient = p_objSelectedPatient;
            //this.m_lblAddress.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            //this.m_lblLinkMan.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;
            //this.m_lblMarriaged.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrMarried;
            //this.m_lblOccupation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
            //this.m_lblNation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrNation;
            //m_lblArea.Text = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName.Trim();
//			//			this.m_lblCreateUserName.Text =MDIParent.strOperatorName;
//			//籍贯在此为出生地
//			this.m_lblNativePlace.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeplace; 
//			lblInPatientDate.Text = m_objCurrentPatient.m_DtmLastInDate.ToString("yyyy年MM月dd日 HH:mm:ss"); 
//
//			//获取病人记录列表
//			string [] strInPatientDateListArr=null;
//			string [] strCreateTimeListArr=null;
//			string [] strOpenTimeListArr=null;
//			long lngRes = m_objDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrInPatientID,out strInPatientDateListArr, out strCreateTimeListArr,out strOpenTimeListArr);
//		
//			if(lngRes <= 0 )
//				return;			
//
//			//清空时间列表树的时间节点   
//			if(trvTime.Nodes.Count >0)
//				trvTime.Nodes.Clear();
//
//			for(int i=p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount()-1;i>=0;i--)
//			{			
//				TreeNode trnRecordDate = new TreeNode(p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmInDate.ToString("yyyy年MM月dd日 HH:mm:ss"));
//				if(strOpenTimeListArr!=null)
//				{
//					for(int j2=0;j2<strInPatientDateListArr.Length;j2++)
//					{
//						if(DateTime.Parse(strInPatientDateListArr[j2])== DateTime.Parse(trnRecordDate.Text))
//						{
//							trnRecordDate.Tag =(string)strOpenTimeListArr[j2];
//							break;
//						}
//					}
//				}
//				trvTime.Nodes.Add(trnRecordDate);	
//				trvTime.ExpandAll();
//			}
//
//			//选中默认节点
//			for(int i = 0; i < trvTime.Nodes.Count; i++)
//			{
//				if(trvTime.Nodes[i].Text == p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy年MM月dd日 HH:mm:ss"))
//					trvTime.SelectedNode = trvTime.Nodes[i];
//			}
//
//			if(!m_dtpCreateDate.Enabled)
//				m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;
//			
        //}

		protected override void m_mthDoAfterSelect()
		{
			trvTime.Visible = false;
            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                lblInPatientDate.Text = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_lblArea.Text = m_ObjCurrentEmrPatientSession.m_strAreaName;
                m_lblPhone.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
            }
		}

		private void m_lklInPatientDate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			trvTime.Visible = !trvTime.Visible;
		}

		private void m_lklInPatientDate_Leave(object sender, System.EventArgs e)
		{
			trvTime.Visible = false;
		}

		#region RTB Event
		private void m_mthSetRTBEvent(Control p_ctlParent)
		{
			if(!p_ctlParent.HasChildren && p_ctlParent is RichTextBox)
			{
				RichTextBox rtb = (RichTextBox)p_ctlParent;
				if(rtb.Multiline == true)//单行的不需要换行变化
				{
					rtb.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.RTB_ContentsResized);
				}
				rtb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
				rtb.TextChanged += new System.EventHandler(this.RTB_TextChanged);
			}
			for(int i=0;i<p_ctlParent.Controls.Count;i++)
				m_mthSetRTBEvent(p_ctlParent.Controls[i]);
		}

		private void RTB_ContentsResized(object sender, System.Windows.Forms.ContentsResizedEventArgs e)
		{
			RichTextBox rtb = (RichTextBox)sender;
			int intOffset = e.NewRectangle.Height - rtb.Height;
			rtb.Height = e.NewRectangle.Height;
			m_mthAdjustPositionBy(rtb,intOffset);
		}
			
		private void m_mthAdjustPositionBy(Control p_ctlChange,int p_intOffset)
		{
            m_pnlContent.Height += p_intOffset;

            this.pictureBox4.Top += p_intOffset;
            this.m_picRB.Top += p_intOffset;
            //for(int i=0;i<m_pnlContent1.Controls.Count;i++)
            //{
            //    if(m_pnlContent1.Controls[i].Top > p_ctlChange.Top)
            //        m_pnlContent1.Controls[i].Top += p_intOffset;
            //}
		}

		private void RTB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{			
			switch(e.KeyCode)
			{
				case Keys.Down:
					RichTextBox rtb = (RichTextBox)sender;
					System.Drawing.Point pt = rtb.GetPositionFromCharIndex(rtb.SelectionStart);
					if(rtb.Height - pt.Y < 22)
						SendKeys.Send("{tab}");
					break;
				case Keys.Up:
					RichTextBox rtb2 = (RichTextBox)sender;
					System.Drawing.Point pt2 = rtb2.GetPositionFromCharIndex(rtb2.SelectionStart);
					if(pt2.Y == 0)
						SendKeys.Send("+{tab}");
					break;
				case Keys.Left:	
					RichTextBox rtb3 = (RichTextBox)sender;
//					System.Drawing.Point pt3 = rtb.GetPositionFromCharIndex(rtb.SelectionStart);
					if(rtb3.SelectionStart == 0)
						SendKeys.Send("+{tab}");
					break;
				case Keys.Right:
					RichTextBox rtb4 = (RichTextBox)sender;
//					System.Drawing.Point pt4 = rtb.GetPositionFromCharIndex(rtb.SelectionStart);
					if(rtb4.SelectionStart == rtb4.Text.Length)
						SendKeys.Send("{tab}");
					break;
			}
		}

		private void RTB_TextChanged(object sender, System.EventArgs e)
		{
			RichTextBox rtb = (RichTextBox)sender;
			m_ctlTarget = rtb;
			int intStart = rtb.SelectionStart - 2;//关键字开始字符
			int intEnd = rtb.SelectionStart;
			while(intStart >= 0 && !Char.IsPunctuation(rtb.Text.Substring(intStart,1),0))//开始字符不是标点符号
			{
				string strKey = rtb.Text.Substring(intStart,rtb.SelectionStart - intStart);
				if(m_hasKeyword.Contains(strKey))
				{
					rtb.SelectionStart = intStart;
					rtb.SelectionLength = intEnd - intStart;
					rtb.SelectionColor = Color.Red;
					string[] strArr = m_hasKeyword[strKey].ToString().Split(new char[]{'|'});
					m_ctlCheckedList.m_mthClear();
					m_ctlCheckedList.m_mthAddRangeItems(strArr);
					System.Drawing.Point pt = rtb.GetPositionFromCharIndex(rtb.SelectionStart);
					m_ctlCheckedList.Left = rtb.Left + pt.X;
					m_ctlCheckedList.Top = rtb.Top + pt.Y + 19;
					m_ctlCheckedList.BringToFront();
					m_ctlCheckedList.Visible = true;
					m_ctlCheckedList.Focus();
					break;
				}
				intStart--;
			}
			
		}
		#endregion

		#region LinkLabel Event
		/// <summary>
		/// 设置超链接标签事件
		/// </summary>
		/// <param name="p_ctlParent"></param>
		private void m_mthSetLinkLabelEvent(Control p_ctlParent)
		{
			if(!p_ctlParent.HasChildren && p_ctlParent is LinkLabel)
			{
				LinkLabel lkl = (LinkLabel)p_ctlParent;
				lkl.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);
			}
			for(int i=0;i<p_ctlParent.Controls.Count;i++)
				m_mthSetLinkLabelEvent(p_ctlParent.Controls[i]);
		}

		private void LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            //LinkLabel lkl = (LinkLabel)sender;
            //if(lkl.Tag != null)
            //{
            //    RichTextBox rtb = m_txtGetRichTextBoxByName(lkl.Tag.ToString(),m_pnlContent);
            //    if(rtb != null)
            //    {
            //        m_objTempTool.m_ObjTransTemplate.m_mthSetCurRichTextBox(rtb);
            //        m_objTempTool.m_ObjTransTemplate.m_mthInvokeTemplate();
            //    }
            //}
		}

		private RichTextBox m_txtGetRichTextBoxByName(string p_strName,Control p_ctlParent)
		{
			foreach(Control ctl in p_ctlParent.Controls)
			{
				if(ctl is RichTextBox && ctl.Name == p_strName)
					return (RichTextBox)ctl;
				else if(ctl.HasChildren)
					m_txtGetRichTextBoxByName(p_strName,ctl);
			}

			return null;
		}
		#endregion

		#region CheckedList Event
		private void CheckedList_AddClicked(object sender,EventArgs e)
		{
			string strValue = "";
			for(int i=0;i<m_ctlCheckedList.CheckedItems.Count;i++)
				strValue += m_ctlCheckedList.CheckedItems[i].ToString() + "，";
			switch(m_ctlTarget.GetType().FullName)
			{
				case "com.digitalwave.controls.ctlRichTextBox":
					com.digitalwave.controls.ctlRichTextBox rtb = (com.digitalwave.controls.ctlRichTextBox)m_ctlTarget;
					rtb.m_mthInsertText(strValue,rtb.SelectionStart+rtb.SelectionLength);
					break;
				case "com.digitalwave.Utility.Controls.ctlRichTextBox":
					com.digitalwave.Utility.Controls.ctlRichTextBox rtb1 = (com.digitalwave.Utility.Controls.ctlRichTextBox)m_ctlTarget;
					rtb1.m_mthInsertText(strValue,rtb1.SelectionStart+rtb1.SelectionLength);
					break;
			}
            
			m_ctlCheckedList.Visible = false;
		}
		private void CheckedList_ReplaceClicked(object sender,EventArgs e)
		{
			string strValue = "";
			for(int i=0;i<m_ctlCheckedList.CheckedItems.Count;i++)
				strValue += m_ctlCheckedList.CheckedItems[i].ToString() + "，";
			switch(m_ctlTarget.GetType().FullName)
			{
				case "com.digitalwave.controls.ctlRichTextBox":
					((com.digitalwave.controls.ctlRichTextBox)m_ctlTarget).SelectedText = strValue;
					break;
				case "com.digitalwave.Utility.Controls.ctlRichTextBox":
					((com.digitalwave.Utility.Controls.ctlRichTextBox)m_ctlTarget).SelectedText = strValue;
					break;
			}

			m_ctlCheckedList.Visible = false;
		}
		private void CheckedList_Leave(object sender,EventArgs e)
		{
			((Control)sender).Visible = false;
		}
		#endregion

		protected override void m_mthSetFocusAfterSetPatientInfo()
		{
			this.m_txtMainDescription.Focus();
		}

		private void trvTime_Leave(object sender, System.EventArgs e)
		{
			this.trvTime.Visible=false;
		}


        protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            base.trvTime_AfterSelect(sender, e);

            this.m_thtxtModifydiagnose.m_ClrOldPartInsertText = Color.Red;
            this.m_thtxtaddDiagnose.m_ClrOldPartInsertText = Color.Red;
        }

        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            base.m_mthOnlySetPatientInfo(p_objSelectedPatient);

            if (p_objSelectedPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                m_txtPatientName.Text = p_objSelectedPatient.m_StrName;
                lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
                lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
                m_lblOccupation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
                m_lblNativePlace.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNativePlace;
                m_lblArea.Text = m_ObjCurrentEmrPatientSession.m_strAreaName;
                m_txtBedNO.Text = p_objSelectedPatient.m_strBedCode;
                txtInPatientID.Text = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_lblPhone.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
            }
        }

        private void m_rdbLastCatameniaTime_CheckedChanged(object sender, EventArgs e)
        {
            m_dtpLastCatameniaTime.Enabled = m_rdbLastCatameniaTime.Checked;
        }

        private void m_rdbAmeniaAge_CheckedChanged(object sender, EventArgs e)
        {
            m_cboAmeniaAge.Enabled = m_rdbAmeniaAge.Checked;
        }
        private void m_lklMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnklb = (LinkLabel)sender;
            switch (lnklb.Name.ToString())
            {
                case "m_lklMainDescription":
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
                case "m_lklCatamenia":
                    m_mth(m_txtCatameniaHistory);
                    break;
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
                    m_mth(m_thtxtModifydiagnose);
                    break;
                case "m_lklModifyDiagnose":
                    m_mth(m_txtPrimaryDiagnose);
                    break;
                case "m_lklAddDiagnose":
                    m_mth(m_thtxtaddDiagnose);
                    break;

            }

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


        //获取记录创建者
        protected override clsInPatientCaseHistoryContent m_objGetCreateUserFromGUI()
        {
            clsInPatientCaseHistoryContent m_objContent = new clsInPatientCaseHistoryContent();
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
                this.m_txtMainDescription.Text = p_objContent.m_strMainDescription;
                this.m_txtCurrentStatus.Text = p_objContent.m_strCurrentStatus;
                this.m_txtBeforetimeStatus.Text = p_objContent.m_strBeforetimeStatus;
                this.m_txtOwnHistory.Text = p_objContent.m_strOwnHistory;
                this.m_txtMarriageHistory.Text = p_objContent.m_strMarriageHistory;
                this.m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
                if (m_chkCatamenia.Checked)
                {
                    this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                    this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                    this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                    
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
                    //this.m_txtCatameniaHistory.Text = p_objContent.m_strCatameniaHistory;
                    this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
                    this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                }
                this.m_txtFamilyHistory.Text = p_objContent.m_strFamilyHistory;
                this.m_txtTemperature.Text = p_objContent.m_strTemperature;
                this.m_txtPulse.Text = p_objContent.m_strPulse;
                this.m_txtBreath.Text = p_objContent.m_strBreath;
                this.m_txtSys.Text = p_objContent.m_strSys;
                this.m_txtDia.Text = p_objContent.m_strDia;
                this.m_txtMedical.Text = p_objContent.m_strMedical;
                this.m_txtProfessionalCheck.Text = p_objContent.m_strProfessionalCheck;
                this.m_txtLabCheck.Text = p_objContent.m_strLabCheck;
                this.m_txtPrimaryDiagnose.Text = p_objContent.m_strDiagnoseOK;
                //this.m_txtPrimaryDiagnose.Text = p_objContent.m_strPrimaryDiagnoseArr;
                
                this.m_thtxtModifydiagnose.Text = p_objContent.m_strModifyDiagnose;
                this.m_txtModifyDiagnoseDoctor.Text = p_objContent.m_strModifyDiagnoseDoctorID;
                this.m_dtpModifyDiagnoseDate.Text = p_objContent.m_datModifyDiagnose.ToString("yyyy-MM-dd hh:mm:ss"); 
                
                this.m_thtxtaddDiagnose.Text=p_objContent.m_strAddDiagnose;
                this.m_txtAddDiagnoseDoctor.Text=p_objContent.m_strAddDiagnoseDoctorID;
                this.m_dtpAddDiagnoseDate.Text=p_objContent.m_datAddDiagnose.ToString("yyyy-MM-dd hh:mm:ss");

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

