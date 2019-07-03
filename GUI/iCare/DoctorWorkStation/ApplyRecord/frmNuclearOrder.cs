using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls ;
using iCareData;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	public class frmNuclearOrder : iCare.frmHRPBaseForm,PublicFunction
	{
     #region define
		private System.Windows.Forms.TreeView trvTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpLastCheck;
		protected System.Windows.Forms.Label lblLastCheck;
		protected System.Windows.Forms.Label lblVocation;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtVocation;
		protected System.Windows.Forms.Label lblAddress;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtAddress;
		protected System.Windows.Forms.Label lblTelephone;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtTelephone;
		protected System.Windows.Forms.Label lblNoseSnore;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rdbNoseSnore;
		private System.Windows.Forms.RadioButton rdbNoNoseSnore;
		protected System.Windows.Forms.Label label4;
		protected System.Windows.Forms.Label label5;
		protected System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel4;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		protected System.Windows.Forms.Label lblMainDescription;
		protected System.Windows.Forms.Label lblDisease;
		protected com.digitalwave.controls.ctlRichTextBox txtMainDescription;
		private System.Windows.Forms.RadioButton rdbNoseSnoreLitter;
		protected System.Windows.Forms.Label lblNoseSnoreLevel;
		private System.Windows.Forms.RadioButton rdbNoseSnoreSome;
		private System.Windows.Forms.RadioButton rdbNoseSnoreMany;
		protected System.Windows.Forms.Label lblNoseSnoreBegin;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtNoseSnoreBeginYear;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtNoseSnoreBeginMonth;
		protected System.Windows.Forms.Label lblSnooze;
		private System.Windows.Forms.RadioButton rdbNoSnooze;
		private System.Windows.Forms.RadioButton rdbSnooze;
		private System.Windows.Forms.RadioButton rdbSnoozeMany;
		private System.Windows.Forms.RadioButton rdbSnoozeSome;
		private System.Windows.Forms.RadioButton rdbSnoozeLitter;
		protected System.Windows.Forms.Label lblSnoozeLevel;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtSnoozeBeginMonth;
		protected System.Windows.Forms.Label lblSnoozeBegin;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtSnoozeBeginYear;
		protected System.Windows.Forms.Label lblGoWithSymptom;
		protected System.Windows.Forms.Label lblDiseaseHistory;
        private PinkieControls.ButtonXP cmdRequesterSign;
		protected System.Windows.Forms.Label lblRequestDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpRequestDate;
		protected System.Windows.Forms.Label lblSleep;
		protected com.digitalwave.controls.ctlRichTextBox txtLastMedicines;
		protected com.digitalwave.controls.ctlRichTextBox txtIrritability;
		private System.Windows.Forms.Label lblIrritability;
		private System.Windows.Forms.Label chkPhysique;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtHeight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtWeight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtBloodPressure;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtHeart;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtLung;
		private System.Windows.Forms.Label lblClinicalDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox txtClinicalDiagnose;
		private System.Windows.Forms.Label lblLastMedicines;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpBespeak;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblNumber;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtNumber;
		private System.ComponentModel.IContainer components = null;

		#endregion define

		
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
		private bool blnCanSearch=true;
        private iCare.clsNuclearOrderDomain m_objDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private bool blnCanDelete=true;              //是否可以执行删除操作
		private clsCommonUseToolCollection m_objCUTC;
		private clsNuclearOrder m_objNuclear=null;
		private clsNuclearOrder[] m_objNuclearArr;
		private clsPatient m_objCurrentPatient=null;

		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.Panel pnlNoseSnoreLevel;
		private System.Windows.Forms.Panel pnlNoseSnoreBeginTime;
		private System.Windows.Forms.Panel pnlSnoozeLevel;
		private System.Windows.Forms.Panel pnlSnoozeBeginTime;
		private System.Windows.Forms.CheckBox chkGoWithSymptom0;
		private System.Windows.Forms.CheckBox chkGoWithSymptom1;
		private System.Windows.Forms.CheckBox chkGoWithSymptom3;
		private System.Windows.Forms.CheckBox chkGoWithSymptom2;
		private System.Windows.Forms.CheckBox chkGoWithSymptom4;
		private System.Windows.Forms.CheckBox chkSleep4;
		private System.Windows.Forms.CheckBox chkSleep3;
		private System.Windows.Forms.CheckBox chkSleep2;
		private System.Windows.Forms.CheckBox chkSleep1;
		private System.Windows.Forms.CheckBox chkSleep0;
		private System.Windows.Forms.CheckBox chkOther3;
		private System.Windows.Forms.CheckBox chkOther2;
		private System.Windows.Forms.CheckBox chkOther1;
		private System.Windows.Forms.CheckBox chkOther0;
		protected System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.CheckBox chkDiseaseHistory7;
		private System.Windows.Forms.CheckBox chkDiseaseHistory9;
		private System.Windows.Forms.CheckBox chkDiseaseHistory6;
		private System.Windows.Forms.CheckBox chkDiseaseHistory5;
		private System.Windows.Forms.CheckBox chkDiseaseHistory4;
		private System.Windows.Forms.CheckBox chkDiseaseHistory2;
		private System.Windows.Forms.CheckBox chkDiseaseHistory3;
		private System.Windows.Forms.CheckBox chkDiseaseHistory1;
		private System.Windows.Forms.CheckBox ChkDiseaseHistory0;
		private System.Windows.Forms.CheckBox chkDiseaseHistory8;
		private System.Windows.Forms.Label lblHeadNeck;
		private System.Windows.Forms.CheckBox chkHeadNeck4;
		private System.Windows.Forms.CheckBox chkHeadNeck3;
		private System.Windows.Forms.CheckBox chkHeadNeck2;
		private System.Windows.Forms.CheckBox chkHeadNeck1;
		private System.Windows.Forms.CheckBox chkHeadNeck0;
		private System.Windows.Forms.CheckBox chkGoWithSymptom5;
		private System.Windows.Forms.Panel pnlDiseaseHistory;
		private System.Windows.Forms.Panel pnlOther;
		private System.Windows.Forms.Panel pnlSleep;
		private System.Windows.Forms.Panel pnlGoWithSymptom;
		private System.Windows.Forms.Panel pnlHeadNeck;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtOtherPart;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		private System.Windows.Forms.CheckBox chkHeadNeck5;
		private System.Windows.Forms.CheckBox chkHeadNeck6;
		protected System.Windows.Forms.Label label2;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox txtHeadNeckOther;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
        private TextBox m_txtRequesterSign;
        private DataSet m_dtsRept;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		public frmNuclearOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(this.m_txtRequesterSign);

            m_objDomain = new iCare.clsNuclearOrderDomain(); 

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.trvTime
            //                                                             ,this.txtMainDescription 
            //                                                             ,this.txtIrritability
            //                                                             ,this.txtClinicalDiagnose
            //                                                             ,this.txtLastMedicines });	


			this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);

			m_dtsRept = m_dtsInitdsNuclearOrderDataSet();
			
			trvTime.HideSelection=false;

            ////签名常用值
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.cmdRequesterSign },
            //    new Control[]{this.m_txtRequesterSign },new int[]{1});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(cmdRequesterSign, m_txtRequesterSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuclearOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblLastCheck = new System.Windows.Forms.Label();
            this.dtpLastCheck = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblVocation = new System.Windows.Forms.Label();
            this.txtVocation = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblMainDescription = new System.Windows.Forms.Label();
            this.lblDisease = new System.Windows.Forms.Label();
            this.txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
            this.lblNoseSnore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbNoNoseSnore = new System.Windows.Forms.RadioButton();
            this.rdbNoseSnore = new System.Windows.Forms.RadioButton();
            this.pnlNoseSnoreLevel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbNoseSnoreMany = new System.Windows.Forms.RadioButton();
            this.rdbNoseSnoreSome = new System.Windows.Forms.RadioButton();
            this.rdbNoseSnoreLitter = new System.Windows.Forms.RadioButton();
            this.lblNoseSnoreLevel = new System.Windows.Forms.Label();
            this.pnlNoseSnoreBeginTime = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoseSnoreBeginMonth = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoseSnoreBegin = new System.Windows.Forms.Label();
            this.txtNoseSnoreBeginYear = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblSnooze = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdbNoSnooze = new System.Windows.Forms.RadioButton();
            this.rdbSnooze = new System.Windows.Forms.RadioButton();
            this.pnlSnoozeLevel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.rdbSnoozeMany = new System.Windows.Forms.RadioButton();
            this.rdbSnoozeSome = new System.Windows.Forms.RadioButton();
            this.rdbSnoozeLitter = new System.Windows.Forms.RadioButton();
            this.lblSnoozeLevel = new System.Windows.Forms.Label();
            this.pnlSnoozeBeginTime = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSnoozeBeginMonth = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSnoozeBegin = new System.Windows.Forms.Label();
            this.txtSnoozeBeginYear = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblGoWithSymptom = new System.Windows.Forms.Label();
            this.chkGoWithSymptom0 = new System.Windows.Forms.CheckBox();
            this.chkGoWithSymptom1 = new System.Windows.Forms.CheckBox();
            this.chkGoWithSymptom3 = new System.Windows.Forms.CheckBox();
            this.chkGoWithSymptom2 = new System.Windows.Forms.CheckBox();
            this.chkGoWithSymptom5 = new System.Windows.Forms.CheckBox();
            this.chkGoWithSymptom4 = new System.Windows.Forms.CheckBox();
            this.lblSleep = new System.Windows.Forms.Label();
            this.chkSleep4 = new System.Windows.Forms.CheckBox();
            this.chkSleep3 = new System.Windows.Forms.CheckBox();
            this.chkSleep2 = new System.Windows.Forms.CheckBox();
            this.chkSleep1 = new System.Windows.Forms.CheckBox();
            this.chkSleep0 = new System.Windows.Forms.CheckBox();
            this.chkOther3 = new System.Windows.Forms.CheckBox();
            this.chkOther2 = new System.Windows.Forms.CheckBox();
            this.chkOther1 = new System.Windows.Forms.CheckBox();
            this.chkOther0 = new System.Windows.Forms.CheckBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblDiseaseHistory = new System.Windows.Forms.Label();
            this.chkDiseaseHistory7 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory9 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory6 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory5 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory4 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory2 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory3 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory1 = new System.Windows.Forms.CheckBox();
            this.ChkDiseaseHistory0 = new System.Windows.Forms.CheckBox();
            this.chkDiseaseHistory8 = new System.Windows.Forms.CheckBox();
            this.txtLastMedicines = new com.digitalwave.controls.ctlRichTextBox();
            this.txtIrritability = new com.digitalwave.controls.ctlRichTextBox();
            this.lblIrritability = new System.Windows.Forms.Label();
            this.chkPhysique = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHeight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtWeight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtBloodPressure = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.lblHeadNeck = new System.Windows.Forms.Label();
            this.chkHeadNeck4 = new System.Windows.Forms.CheckBox();
            this.chkHeadNeck3 = new System.Windows.Forms.CheckBox();
            this.chkHeadNeck2 = new System.Windows.Forms.CheckBox();
            this.chkHeadNeck1 = new System.Windows.Forms.CheckBox();
            this.chkHeadNeck0 = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtHeart = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtLung = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtOtherPart = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblClinicalDiagnose = new System.Windows.Forms.Label();
            this.txtClinicalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.lblLastMedicines = new System.Windows.Forms.Label();
            this.cmdRequesterSign = new PinkieControls.ButtonXP();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.dtpRequestDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpBespeak = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.pnlDiseaseHistory = new System.Windows.Forms.Panel();
            this.pnlOther = new System.Windows.Forms.Panel();
            this.pnlSleep = new System.Windows.Forms.Panel();
            this.pnlGoWithSymptom = new System.Windows.Forms.Panel();
            this.pnlHeadNeck = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeadNeckOther = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.chkHeadNeck5 = new System.Windows.Forms.CheckBox();
            this.chkHeadNeck6 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtRequesterSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlNoseSnoreLevel.SuspendLayout();
            this.pnlNoseSnoreBeginTime.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlSnoozeLevel.SuspendLayout();
            this.pnlSnoozeBeginTime.SuspendLayout();
            this.pnlDiseaseHistory.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.pnlSleep.SuspendLayout();
            this.pnlGoWithSymptom.SuspendLayout();
            this.pnlHeadNeck.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(311, 268);
            this.lblSex.Size = new System.Drawing.Size(26, 19);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(280, 289);
            this.lblAge.Size = new System.Drawing.Size(38, 19);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(280, 290);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(250, 299);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(280, 281);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(272, 264);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(295, 258);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(272, 299);
            this.lblAreaTitle.Visible = false;
            this.lblAreaTitle.Click += new System.EventHandler(this.lblAreaTitle_Click);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(283, 250);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(60, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(262, 286);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(269, 270);
            this.m_txtPatientName.Size = new System.Drawing.Size(62, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(270, 281);
            this.m_txtBedNO.Size = new System.Drawing.Size(66, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(275, 299);
            this.m_cboArea.Size = new System.Drawing.Size(88, 23);
            this.m_cboArea.Visible = false;
            this.m_cboArea.Load += new System.EventHandler(this.m_cboArea_Load);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(275, 250);
            this.m_lsvPatientName.Size = new System.Drawing.Size(62, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(268, 250);
            this.m_lsvBedNO.Size = new System.Drawing.Size(60, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(268, 290);
            this.m_cboDept.Size = new System.Drawing.Size(88, 23);
            this.m_cboDept.Visible = false;
            this.m_cboDept.Load += new System.EventHandler(this.m_cboDept_Load);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(265, 299);
            this.lblDept.Visible = false;
            this.lblDept.Click += new System.EventHandler(this.lblDept_Click);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(268, 281);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(290, 288);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(290, 288);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(75, 342);
            this.m_lblForTitle.Size = new System.Drawing.Size(36, 26);
            this.m_lblForTitle.Text = "电脑多导睡眠图检查申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(458, 299);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(725, 35);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.lblAddress);
            this.m_pnlNewBase.Controls.Add(this.txtAddress);
            this.m_pnlNewBase.Controls.Add(this.lblTelephone);
            this.m_pnlNewBase.Controls.Add(this.txtTelephone);
            this.m_pnlNewBase.Location = new System.Drawing.Point(8, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(796, 83);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtTelephone, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblTelephone, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtAddress, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblAddress, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 28);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(601, 53);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(9, 36);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(190, 53);
            this.trvTime.TabIndex = 10;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lblLastCheck
            // 
            this.lblLastCheck.AutoSize = true;
            this.lblLastCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastCheck.Location = new System.Drawing.Point(5, 99);
            this.lblLastCheck.Name = "lblLastCheck";
            this.lblLastCheck.Size = new System.Drawing.Size(98, 14);
            this.lblLastCheck.TabIndex = 1000000004;
            this.lblLastCheck.Text = "上次检查日期:";
            // 
            // dtpLastCheck
            // 
            this.dtpLastCheck.BorderColor = System.Drawing.Color.Black;
            this.dtpLastCheck.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpLastCheck.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpLastCheck.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpLastCheck.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpLastCheck.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpLastCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLastCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLastCheck.Location = new System.Drawing.Point(108, 96);
            this.dtpLastCheck.m_BlnOnlyTime = false;
            this.dtpLastCheck.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpLastCheck.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLastCheck.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLastCheck.Name = "dtpLastCheck";
            this.dtpLastCheck.ReadOnly = false;
            this.dtpLastCheck.Size = new System.Drawing.Size(214, 22);
            this.dtpLastCheck.TabIndex = 50;
            this.dtpLastCheck.TextBackColor = System.Drawing.Color.White;
            this.dtpLastCheck.TextForeColor = System.Drawing.Color.Black;
            this.dtpLastCheck.Load += new System.EventHandler(this.dtpLastCheck_Load);
            // 
            // lblVocation
            // 
            this.lblVocation.AutoSize = true;
            this.lblVocation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVocation.Location = new System.Drawing.Point(289, 286);
            this.lblVocation.Name = "lblVocation";
            this.lblVocation.Size = new System.Drawing.Size(42, 14);
            this.lblVocation.TabIndex = 1000000006;
            this.lblVocation.Text = "职业:";
            this.lblVocation.Visible = false;
            // 
            // txtVocation
            // 
            this.txtVocation.BackColor = System.Drawing.Color.White;
            this.txtVocation.BorderColor = System.Drawing.Color.White;
            this.txtVocation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVocation.ForeColor = System.Drawing.Color.Black;
            this.txtVocation.Location = new System.Drawing.Point(274, 273);
            this.txtVocation.Name = "txtVocation";
            this.txtVocation.ReadOnly = true;
            this.txtVocation.Size = new System.Drawing.Size(62, 23);
            this.txtVocation.TabIndex = 20;
            this.txtVocation.TabStop = false;
            this.txtVocation.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.Location = new System.Drawing.Point(196, 56);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(70, 26);
            this.lblAddress.TabIndex = 1000000008;
            this.lblAddress.Text = "通讯地址:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(266, 56);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 23);
            this.txtAddress.TabIndex = 40;
            // 
            // lblTelephone
            // 
            this.lblTelephone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTelephone.Location = new System.Drawing.Point(516, 28);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(42, 26);
            this.lblTelephone.TabIndex = 1000000010;
            this.lblTelephone.Text = "电话:";
            this.lblTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.Color.White;
            this.txtTelephone.BorderColor = System.Drawing.Color.White;
            this.txtTelephone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTelephone.ForeColor = System.Drawing.Color.Black;
            this.txtTelephone.Location = new System.Drawing.Point(559, 30);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ReadOnly = true;
            this.txtTelephone.Size = new System.Drawing.Size(107, 23);
            this.txtTelephone.TabIndex = 30;
            // 
            // lblMainDescription
            // 
            this.lblMainDescription.AutoSize = true;
            this.lblMainDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainDescription.Location = new System.Drawing.Point(40, 15);
            this.lblMainDescription.Name = "lblMainDescription";
            this.lblMainDescription.Size = new System.Drawing.Size(42, 14);
            this.lblMainDescription.TabIndex = 1000000012;
            this.lblMainDescription.Text = "主诉:";
            this.lblMainDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisease
            // 
            this.lblDisease.AutoSize = true;
            this.lblDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDisease.Location = new System.Drawing.Point(26, 42);
            this.lblDisease.Name = "lblDisease";
            this.lblDisease.Size = new System.Drawing.Size(56, 14);
            this.lblDisease.TabIndex = 1000000013;
            this.lblDisease.Text = "现病史:";
            this.lblDisease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMainDescription
            // 
            this.txtMainDescription.AccessibleDescription = "主诉";
            this.txtMainDescription.BackColor = System.Drawing.Color.White;
            this.txtMainDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMainDescription.ForeColor = System.Drawing.Color.Black;
            this.txtMainDescription.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMainDescription.Location = new System.Drawing.Point(96, 13);
            this.txtMainDescription.m_BlnIgnoreUserInfo = true;
            this.txtMainDescription.m_BlnPartControl = false;
            this.txtMainDescription.m_BlnReadOnly = false;
            this.txtMainDescription.m_BlnUnderLineDST = false;
            this.txtMainDescription.m_ClrDST = System.Drawing.Color.Red;
            this.txtMainDescription.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtMainDescription.m_IntCanModifyTime = 6;
            this.txtMainDescription.m_IntPartControlLength = 0;
            this.txtMainDescription.m_IntPartControlStartIndex = 0;
            this.txtMainDescription.m_StrUserID = "";
            this.txtMainDescription.m_StrUserName = "";
            this.txtMainDescription.Multiline = false;
            this.txtMainDescription.Name = "txtMainDescription";
            this.txtMainDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtMainDescription.Size = new System.Drawing.Size(518, 21);
            this.txtMainDescription.TabIndex = 90;
            this.txtMainDescription.Tag = "1";
            this.txtMainDescription.Text = "";
            // 
            // lblNoseSnore
            // 
            this.lblNoseSnore.AutoSize = true;
            this.lblNoseSnore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoseSnore.Location = new System.Drawing.Point(26, 118);
            this.lblNoseSnore.Name = "lblNoseSnore";
            this.lblNoseSnore.Size = new System.Drawing.Size(56, 14);
            this.lblNoseSnore.TabIndex = 1000000015;
            this.lblNoseSnore.Text = "打鼻鼾:";
            this.lblNoseSnore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbNoNoseSnore);
            this.panel1.Controls.Add(this.rdbNoseSnore);
            this.panel1.Location = new System.Drawing.Point(98, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 30);
            this.panel1.TabIndex = 95;
            // 
            // rdbNoNoseSnore
            // 
            this.rdbNoNoseSnore.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoNoseSnore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoNoseSnore.ForeColor = System.Drawing.Color.Black;
            this.rdbNoNoseSnore.Location = new System.Drawing.Point(52, 4);
            this.rdbNoNoseSnore.Name = "rdbNoNoseSnore";
            this.rdbNoNoseSnore.Size = new System.Drawing.Size(34, 22);
            this.rdbNoNoseSnore.TabIndex = 110;
            this.rdbNoNoseSnore.Text = "否";
            this.rdbNoNoseSnore.UseVisualStyleBackColor = false;
            this.rdbNoNoseSnore.CheckedChanged += new System.EventHandler(this.rdbNoNoseSnore_CheckedChanged);
            // 
            // rdbNoseSnore
            // 
            this.rdbNoseSnore.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoseSnore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoseSnore.ForeColor = System.Drawing.Color.Black;
            this.rdbNoseSnore.Location = new System.Drawing.Point(6, 4);
            this.rdbNoseSnore.Name = "rdbNoseSnore";
            this.rdbNoseSnore.Size = new System.Drawing.Size(34, 22);
            this.rdbNoseSnore.TabIndex = 100;
            this.rdbNoseSnore.Text = "是";
            this.rdbNoseSnore.UseVisualStyleBackColor = false;
            this.rdbNoseSnore.CheckedChanged += new System.EventHandler(this.rdbNoseSnore_CheckedChanged);
            // 
            // pnlNoseSnoreLevel
            // 
            this.pnlNoseSnoreLevel.Controls.Add(this.label4);
            this.pnlNoseSnoreLevel.Controls.Add(this.rdbNoseSnoreMany);
            this.pnlNoseSnoreLevel.Controls.Add(this.rdbNoseSnoreSome);
            this.pnlNoseSnoreLevel.Controls.Add(this.rdbNoseSnoreLitter);
            this.pnlNoseSnoreLevel.Controls.Add(this.lblNoseSnoreLevel);
            this.pnlNoseSnoreLevel.Location = new System.Drawing.Point(200, 114);
            this.pnlNoseSnoreLevel.Name = "pnlNoseSnoreLevel";
            this.pnlNoseSnoreLevel.Size = new System.Drawing.Size(204, 30);
            this.pnlNoseSnoreLevel.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(174, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 22);
            this.label4.TabIndex = 140;
            this.label4.Text = ")";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbNoseSnoreMany
            // 
            this.rdbNoseSnoreMany.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoseSnoreMany.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoseSnoreMany.ForeColor = System.Drawing.Color.Black;
            this.rdbNoseSnoreMany.Location = new System.Drawing.Point(134, 4);
            this.rdbNoseSnoreMany.Name = "rdbNoseSnoreMany";
            this.rdbNoseSnoreMany.Size = new System.Drawing.Size(34, 22);
            this.rdbNoseSnoreMany.TabIndex = 140;
            this.rdbNoseSnoreMany.Text = "重";
            this.rdbNoseSnoreMany.UseVisualStyleBackColor = false;
            // 
            // rdbNoseSnoreSome
            // 
            this.rdbNoseSnoreSome.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoseSnoreSome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoseSnoreSome.ForeColor = System.Drawing.Color.Black;
            this.rdbNoseSnoreSome.Location = new System.Drawing.Point(94, 4);
            this.rdbNoseSnoreSome.Name = "rdbNoseSnoreSome";
            this.rdbNoseSnoreSome.Size = new System.Drawing.Size(34, 22);
            this.rdbNoseSnoreSome.TabIndex = 130;
            this.rdbNoseSnoreSome.Text = "中";
            this.rdbNoseSnoreSome.UseVisualStyleBackColor = false;
            // 
            // rdbNoseSnoreLitter
            // 
            this.rdbNoseSnoreLitter.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoseSnoreLitter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoseSnoreLitter.ForeColor = System.Drawing.Color.Black;
            this.rdbNoseSnoreLitter.Location = new System.Drawing.Point(54, 4);
            this.rdbNoseSnoreLitter.Name = "rdbNoseSnoreLitter";
            this.rdbNoseSnoreLitter.Size = new System.Drawing.Size(34, 22);
            this.rdbNoseSnoreLitter.TabIndex = 120;
            this.rdbNoseSnoreLitter.Text = "轻";
            this.rdbNoseSnoreLitter.UseVisualStyleBackColor = false;
            // 
            // lblNoseSnoreLevel
            // 
            this.lblNoseSnoreLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoseSnoreLevel.Location = new System.Drawing.Point(6, 4);
            this.lblNoseSnoreLevel.Name = "lblNoseSnoreLevel";
            this.lblNoseSnoreLevel.Size = new System.Drawing.Size(42, 22);
            this.lblNoseSnoreLevel.TabIndex = 1000000018;
            this.lblNoseSnoreLevel.Text = "程度(";
            this.lblNoseSnoreLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNoseSnoreBeginTime
            // 
            this.pnlNoseSnoreBeginTime.Controls.Add(this.label7);
            this.pnlNoseSnoreBeginTime.Controls.Add(this.txtNoseSnoreBeginMonth);
            this.pnlNoseSnoreBeginTime.Controls.Add(this.label5);
            this.pnlNoseSnoreBeginTime.Controls.Add(this.lblNoseSnoreBegin);
            this.pnlNoseSnoreBeginTime.Controls.Add(this.txtNoseSnoreBeginYear);
            this.pnlNoseSnoreBeginTime.Location = new System.Drawing.Point(410, 114);
            this.pnlNoseSnoreBeginTime.Name = "pnlNoseSnoreBeginTime";
            this.pnlNoseSnoreBeginTime.Size = new System.Drawing.Size(215, 30);
            this.pnlNoseSnoreBeginTime.TabIndex = 145;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(180, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 1000000021;
            this.label7.Text = "月)";
            // 
            // txtNoseSnoreBeginMonth
            // 
            this.txtNoseSnoreBeginMonth.BackColor = System.Drawing.Color.White;
            this.txtNoseSnoreBeginMonth.BorderColor = System.Drawing.Color.White;
            this.txtNoseSnoreBeginMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoseSnoreBeginMonth.ForeColor = System.Drawing.Color.Black;
            this.txtNoseSnoreBeginMonth.Location = new System.Drawing.Point(152, 5);
            this.txtNoseSnoreBeginMonth.MaxLength = 2;
            this.txtNoseSnoreBeginMonth.Name = "txtNoseSnoreBeginMonth";
            this.txtNoseSnoreBeginMonth.Size = new System.Drawing.Size(26, 23);
            this.txtNoseSnoreBeginMonth.TabIndex = 160;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(130, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 1000000019;
            this.label5.Text = "年";
            // 
            // lblNoseSnoreBegin
            // 
            this.lblNoseSnoreBegin.AutoSize = true;
            this.lblNoseSnoreBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoseSnoreBegin.Location = new System.Drawing.Point(6, 7);
            this.lblNoseSnoreBegin.Name = "lblNoseSnoreBegin";
            this.lblNoseSnoreBegin.Size = new System.Drawing.Size(70, 14);
            this.lblNoseSnoreBegin.TabIndex = 1000000018;
            this.lblNoseSnoreBegin.Text = "出现时间(";
            // 
            // txtNoseSnoreBeginYear
            // 
            this.txtNoseSnoreBeginYear.BackColor = System.Drawing.Color.White;
            this.txtNoseSnoreBeginYear.BorderColor = System.Drawing.Color.White;
            this.txtNoseSnoreBeginYear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoseSnoreBeginYear.ForeColor = System.Drawing.Color.Black;
            this.txtNoseSnoreBeginYear.Location = new System.Drawing.Point(86, 5);
            this.txtNoseSnoreBeginYear.MaxLength = 4;
            this.txtNoseSnoreBeginYear.Name = "txtNoseSnoreBeginYear";
            this.txtNoseSnoreBeginYear.Size = new System.Drawing.Size(42, 23);
            this.txtNoseSnoreBeginYear.TabIndex = 150;
            // 
            // lblSnooze
            // 
            this.lblSnooze.AutoSize = true;
            this.lblSnooze.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSnooze.Location = new System.Drawing.Point(14, 152);
            this.lblSnooze.Name = "lblSnooze";
            this.lblSnooze.Size = new System.Drawing.Size(70, 14);
            this.lblSnooze.TabIndex = 1000000019;
            this.lblSnooze.Text = "白天瞌睡:";
            this.lblSnooze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdbNoSnooze);
            this.panel4.Controls.Add(this.rdbSnooze);
            this.panel4.Location = new System.Drawing.Point(98, 146);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 30);
            this.panel4.TabIndex = 165;
            // 
            // rdbNoSnooze
            // 
            this.rdbNoSnooze.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNoSnooze.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbNoSnooze.ForeColor = System.Drawing.Color.Black;
            this.rdbNoSnooze.Location = new System.Drawing.Point(52, 6);
            this.rdbNoSnooze.Name = "rdbNoSnooze";
            this.rdbNoSnooze.Size = new System.Drawing.Size(34, 22);
            this.rdbNoSnooze.TabIndex = 180;
            this.rdbNoSnooze.Text = "否";
            this.rdbNoSnooze.UseVisualStyleBackColor = false;
            this.rdbNoSnooze.CheckedChanged += new System.EventHandler(this.rdbNoSnooze_CheckedChanged);
            // 
            // rdbSnooze
            // 
            this.rdbSnooze.BackColor = System.Drawing.SystemColors.Control;
            this.rdbSnooze.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbSnooze.ForeColor = System.Drawing.Color.Black;
            this.rdbSnooze.Location = new System.Drawing.Point(6, 6);
            this.rdbSnooze.Name = "rdbSnooze";
            this.rdbSnooze.Size = new System.Drawing.Size(34, 22);
            this.rdbSnooze.TabIndex = 170;
            this.rdbSnooze.Text = "是";
            this.rdbSnooze.UseVisualStyleBackColor = false;
            this.rdbSnooze.CheckedChanged += new System.EventHandler(this.rdbSnooze_CheckedChanged);
            // 
            // pnlSnoozeLevel
            // 
            this.pnlSnoozeLevel.Controls.Add(this.label9);
            this.pnlSnoozeLevel.Controls.Add(this.rdbSnoozeMany);
            this.pnlSnoozeLevel.Controls.Add(this.rdbSnoozeSome);
            this.pnlSnoozeLevel.Controls.Add(this.rdbSnoozeLitter);
            this.pnlSnoozeLevel.Controls.Add(this.lblSnoozeLevel);
            this.pnlSnoozeLevel.Location = new System.Drawing.Point(200, 146);
            this.pnlSnoozeLevel.Name = "pnlSnoozeLevel";
            this.pnlSnoozeLevel.Size = new System.Drawing.Size(204, 30);
            this.pnlSnoozeLevel.TabIndex = 185;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(174, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 22);
            this.label9.TabIndex = 210;
            this.label9.Text = ")";
            // 
            // rdbSnoozeMany
            // 
            this.rdbSnoozeMany.BackColor = System.Drawing.SystemColors.Control;
            this.rdbSnoozeMany.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbSnoozeMany.ForeColor = System.Drawing.Color.Black;
            this.rdbSnoozeMany.Location = new System.Drawing.Point(134, 6);
            this.rdbSnoozeMany.Name = "rdbSnoozeMany";
            this.rdbSnoozeMany.Size = new System.Drawing.Size(34, 22);
            this.rdbSnoozeMany.TabIndex = 2;
            this.rdbSnoozeMany.Text = "重";
            this.rdbSnoozeMany.UseVisualStyleBackColor = false;
            // 
            // rdbSnoozeSome
            // 
            this.rdbSnoozeSome.BackColor = System.Drawing.SystemColors.Control;
            this.rdbSnoozeSome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbSnoozeSome.ForeColor = System.Drawing.Color.Black;
            this.rdbSnoozeSome.Location = new System.Drawing.Point(94, 6);
            this.rdbSnoozeSome.Name = "rdbSnoozeSome";
            this.rdbSnoozeSome.Size = new System.Drawing.Size(34, 22);
            this.rdbSnoozeSome.TabIndex = 200;
            this.rdbSnoozeSome.Text = "中";
            this.rdbSnoozeSome.UseVisualStyleBackColor = false;
            // 
            // rdbSnoozeLitter
            // 
            this.rdbSnoozeLitter.BackColor = System.Drawing.SystemColors.Control;
            this.rdbSnoozeLitter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbSnoozeLitter.ForeColor = System.Drawing.Color.Black;
            this.rdbSnoozeLitter.Location = new System.Drawing.Point(54, 6);
            this.rdbSnoozeLitter.Name = "rdbSnoozeLitter";
            this.rdbSnoozeLitter.Size = new System.Drawing.Size(34, 22);
            this.rdbSnoozeLitter.TabIndex = 190;
            this.rdbSnoozeLitter.Text = "轻";
            this.rdbSnoozeLitter.UseVisualStyleBackColor = false;
            // 
            // lblSnoozeLevel
            // 
            this.lblSnoozeLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSnoozeLevel.Location = new System.Drawing.Point(6, 6);
            this.lblSnoozeLevel.Name = "lblSnoozeLevel";
            this.lblSnoozeLevel.Size = new System.Drawing.Size(42, 22);
            this.lblSnoozeLevel.TabIndex = 1000000018;
            this.lblSnoozeLevel.Text = "程度(";
            // 
            // pnlSnoozeBeginTime
            // 
            this.pnlSnoozeBeginTime.Controls.Add(this.label11);
            this.pnlSnoozeBeginTime.Controls.Add(this.txtSnoozeBeginMonth);
            this.pnlSnoozeBeginTime.Controls.Add(this.label12);
            this.pnlSnoozeBeginTime.Controls.Add(this.lblSnoozeBegin);
            this.pnlSnoozeBeginTime.Controls.Add(this.txtSnoozeBeginYear);
            this.pnlSnoozeBeginTime.Location = new System.Drawing.Point(410, 146);
            this.pnlSnoozeBeginTime.Name = "pnlSnoozeBeginTime";
            this.pnlSnoozeBeginTime.Size = new System.Drawing.Size(215, 30);
            this.pnlSnoozeBeginTime.TabIndex = 215;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(180, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 1000000021;
            this.label11.Text = "月)";
            // 
            // txtSnoozeBeginMonth
            // 
            this.txtSnoozeBeginMonth.BackColor = System.Drawing.Color.White;
            this.txtSnoozeBeginMonth.BorderColor = System.Drawing.Color.White;
            this.txtSnoozeBeginMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSnoozeBeginMonth.ForeColor = System.Drawing.Color.Black;
            this.txtSnoozeBeginMonth.Location = new System.Drawing.Point(152, 6);
            this.txtSnoozeBeginMonth.MaxLength = 2;
            this.txtSnoozeBeginMonth.Name = "txtSnoozeBeginMonth";
            this.txtSnoozeBeginMonth.Size = new System.Drawing.Size(26, 23);
            this.txtSnoozeBeginMonth.TabIndex = 230;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(130, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 1000000019;
            this.label12.Text = "年";
            // 
            // lblSnoozeBegin
            // 
            this.lblSnoozeBegin.AutoSize = true;
            this.lblSnoozeBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSnoozeBegin.Location = new System.Drawing.Point(6, 9);
            this.lblSnoozeBegin.Name = "lblSnoozeBegin";
            this.lblSnoozeBegin.Size = new System.Drawing.Size(70, 14);
            this.lblSnoozeBegin.TabIndex = 1000000018;
            this.lblSnoozeBegin.Text = "出现时间(";
            // 
            // txtSnoozeBeginYear
            // 
            this.txtSnoozeBeginYear.BackColor = System.Drawing.Color.White;
            this.txtSnoozeBeginYear.BorderColor = System.Drawing.Color.White;
            this.txtSnoozeBeginYear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSnoozeBeginYear.ForeColor = System.Drawing.Color.Black;
            this.txtSnoozeBeginYear.Location = new System.Drawing.Point(86, 6);
            this.txtSnoozeBeginYear.MaxLength = 4;
            this.txtSnoozeBeginYear.Name = "txtSnoozeBeginYear";
            this.txtSnoozeBeginYear.Size = new System.Drawing.Size(42, 23);
            this.txtSnoozeBeginYear.TabIndex = 220;
            // 
            // lblGoWithSymptom
            // 
            this.lblGoWithSymptom.AutoSize = true;
            this.lblGoWithSymptom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGoWithSymptom.Location = new System.Drawing.Point(14, 186);
            this.lblGoWithSymptom.Name = "lblGoWithSymptom";
            this.lblGoWithSymptom.Size = new System.Drawing.Size(70, 14);
            this.lblGoWithSymptom.TabIndex = 1000000023;
            this.lblGoWithSymptom.Text = "伴随症状:";
            this.lblGoWithSymptom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkGoWithSymptom0
            // 
            this.chkGoWithSymptom0.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom0.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom0.Location = new System.Drawing.Point(6, 6);
            this.chkGoWithSymptom0.Name = "chkGoWithSymptom0";
            this.chkGoWithSymptom0.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom0.TabIndex = 240;
            this.chkGoWithSymptom0.Tag = "0";
            this.chkGoWithSymptom0.Text = "晨起头痛";
            this.chkGoWithSymptom0.UseVisualStyleBackColor = false;
            // 
            // chkGoWithSymptom1
            // 
            this.chkGoWithSymptom1.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom1.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom1.Location = new System.Drawing.Point(92, 6);
            this.chkGoWithSymptom1.Name = "chkGoWithSymptom1";
            this.chkGoWithSymptom1.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom1.TabIndex = 250;
            this.chkGoWithSymptom1.Tag = "1";
            this.chkGoWithSymptom1.Text = "容易困倦";
            this.chkGoWithSymptom1.UseVisualStyleBackColor = false;
            // 
            // chkGoWithSymptom3
            // 
            this.chkGoWithSymptom3.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom3.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom3.Location = new System.Drawing.Point(264, 6);
            this.chkGoWithSymptom3.Name = "chkGoWithSymptom3";
            this.chkGoWithSymptom3.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom3.TabIndex = 270;
            this.chkGoWithSymptom3.Tag = "3";
            this.chkGoWithSymptom3.Text = "反应迟钝";
            this.chkGoWithSymptom3.UseVisualStyleBackColor = false;
            // 
            // chkGoWithSymptom2
            // 
            this.chkGoWithSymptom2.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom2.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom2.Location = new System.Drawing.Point(178, 6);
            this.chkGoWithSymptom2.Name = "chkGoWithSymptom2";
            this.chkGoWithSymptom2.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom2.TabIndex = 260;
            this.chkGoWithSymptom2.Tag = "2";
            this.chkGoWithSymptom2.Text = "性格改变";
            this.chkGoWithSymptom2.UseVisualStyleBackColor = false;
            // 
            // chkGoWithSymptom5
            // 
            this.chkGoWithSymptom5.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom5.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom5.Location = new System.Drawing.Point(436, 6);
            this.chkGoWithSymptom5.Name = "chkGoWithSymptom5";
            this.chkGoWithSymptom5.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom5.TabIndex = 290;
            this.chkGoWithSymptom5.Tag = "5";
            this.chkGoWithSymptom5.Text = "性欲减退";
            this.chkGoWithSymptom5.UseVisualStyleBackColor = false;
            // 
            // chkGoWithSymptom4
            // 
            this.chkGoWithSymptom4.BackColor = System.Drawing.SystemColors.Control;
            this.chkGoWithSymptom4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGoWithSymptom4.ForeColor = System.Drawing.Color.Black;
            this.chkGoWithSymptom4.Location = new System.Drawing.Point(350, 6);
            this.chkGoWithSymptom4.Name = "chkGoWithSymptom4";
            this.chkGoWithSymptom4.Size = new System.Drawing.Size(82, 22);
            this.chkGoWithSymptom4.TabIndex = 280;
            this.chkGoWithSymptom4.Tag = "4";
            this.chkGoWithSymptom4.Text = "记忆衰退";
            this.chkGoWithSymptom4.UseVisualStyleBackColor = false;
            // 
            // lblSleep
            // 
            this.lblSleep.AutoSize = true;
            this.lblSleep.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSleep.Location = new System.Drawing.Point(14, 222);
            this.lblSleep.Name = "lblSleep";
            this.lblSleep.Size = new System.Drawing.Size(70, 14);
            this.lblSleep.TabIndex = 1000000031;
            this.lblSleep.Text = "睡眠行为:";
            this.lblSleep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSleep4
            // 
            this.chkSleep4.BackColor = System.Drawing.SystemColors.Control;
            this.chkSleep4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSleep4.ForeColor = System.Drawing.Color.Black;
            this.chkSleep4.Location = new System.Drawing.Point(246, 6);
            this.chkSleep4.Name = "chkSleep4";
            this.chkSleep4.Size = new System.Drawing.Size(54, 22);
            this.chkSleep4.TabIndex = 340;
            this.chkSleep4.Tag = "4";
            this.chkSleep4.Text = "遗尿";
            this.chkSleep4.UseVisualStyleBackColor = false;
            // 
            // chkSleep3
            // 
            this.chkSleep3.BackColor = System.Drawing.SystemColors.Control;
            this.chkSleep3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSleep3.ForeColor = System.Drawing.Color.Black;
            this.chkSleep3.Location = new System.Drawing.Point(186, 6);
            this.chkSleep3.Name = "chkSleep3";
            this.chkSleep3.Size = new System.Drawing.Size(54, 22);
            this.chkSleep3.TabIndex = 330;
            this.chkSleep3.Tag = "3";
            this.chkSleep3.Text = "惊叫";
            this.chkSleep3.UseVisualStyleBackColor = false;
            // 
            // chkSleep2
            // 
            this.chkSleep2.BackColor = System.Drawing.SystemColors.Control;
            this.chkSleep2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSleep2.ForeColor = System.Drawing.Color.Black;
            this.chkSleep2.Location = new System.Drawing.Point(126, 6);
            this.chkSleep2.Name = "chkSleep2";
            this.chkSleep2.Size = new System.Drawing.Size(54, 22);
            this.chkSleep2.TabIndex = 320;
            this.chkSleep2.Tag = "2";
            this.chkSleep2.Text = "多梦";
            this.chkSleep2.UseVisualStyleBackColor = false;
            // 
            // chkSleep1
            // 
            this.chkSleep1.BackColor = System.Drawing.SystemColors.Control;
            this.chkSleep1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSleep1.ForeColor = System.Drawing.Color.Black;
            this.chkSleep1.Location = new System.Drawing.Point(66, 6);
            this.chkSleep1.Name = "chkSleep1";
            this.chkSleep1.Size = new System.Drawing.Size(54, 22);
            this.chkSleep1.TabIndex = 310;
            this.chkSleep1.Tag = "1";
            this.chkSleep1.Text = "抽搐";
            this.chkSleep1.UseVisualStyleBackColor = false;
            // 
            // chkSleep0
            // 
            this.chkSleep0.BackColor = System.Drawing.SystemColors.Control;
            this.chkSleep0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSleep0.ForeColor = System.Drawing.Color.Black;
            this.chkSleep0.Location = new System.Drawing.Point(6, 6);
            this.chkSleep0.Name = "chkSleep0";
            this.chkSleep0.Size = new System.Drawing.Size(54, 22);
            this.chkSleep0.TabIndex = 300;
            this.chkSleep0.Tag = "0";
            this.chkSleep0.Text = "憋醒";
            this.chkSleep0.UseVisualStyleBackColor = false;
            // 
            // chkOther3
            // 
            this.chkOther3.BackColor = System.Drawing.SystemColors.Control;
            this.chkOther3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOther3.ForeColor = System.Drawing.Color.Black;
            this.chkOther3.Location = new System.Drawing.Point(264, 4);
            this.chkOther3.Name = "chkOther3";
            this.chkOther3.Size = new System.Drawing.Size(82, 22);
            this.chkOther3.TabIndex = 380;
            this.chkOther3.Tag = "3";
            this.chkOther3.Text = "夜间心悸";
            this.chkOther3.UseVisualStyleBackColor = false;
            // 
            // chkOther2
            // 
            this.chkOther2.BackColor = System.Drawing.SystemColors.Control;
            this.chkOther2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOther2.ForeColor = System.Drawing.Color.Black;
            this.chkOther2.Location = new System.Drawing.Point(178, 4);
            this.chkOther2.Name = "chkOther2";
            this.chkOther2.Size = new System.Drawing.Size(82, 22);
            this.chkOther2.TabIndex = 370;
            this.chkOther2.Tag = "2";
            this.chkOther2.Text = "夜间胸痛";
            this.chkOther2.UseVisualStyleBackColor = false;
            // 
            // chkOther1
            // 
            this.chkOther1.BackColor = System.Drawing.SystemColors.Control;
            this.chkOther1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOther1.ForeColor = System.Drawing.Color.Black;
            this.chkOther1.Location = new System.Drawing.Point(92, 4);
            this.chkOther1.Name = "chkOther1";
            this.chkOther1.Size = new System.Drawing.Size(82, 22);
            this.chkOther1.TabIndex = 360;
            this.chkOther1.Tag = "1";
            this.chkOther1.Text = "夜间喘息";
            this.chkOther1.UseVisualStyleBackColor = false;
            // 
            // chkOther0
            // 
            this.chkOther0.BackColor = System.Drawing.SystemColors.Control;
            this.chkOther0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOther0.ForeColor = System.Drawing.Color.Black;
            this.chkOther0.Location = new System.Drawing.Point(6, 4);
            this.chkOther0.Name = "chkOther0";
            this.chkOther0.Size = new System.Drawing.Size(82, 22);
            this.chkOther0.TabIndex = 350;
            this.chkOther0.Tag = "0";
            this.chkOther0.Text = "夜间咳嗽";
            this.chkOther0.UseVisualStyleBackColor = false;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOther.Location = new System.Drawing.Point(14, 256);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(70, 14);
            this.lblOther.TabIndex = 1000000037;
            this.lblOther.Text = "其他症状:";
            this.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiseaseHistory
            // 
            this.lblDiseaseHistory.AutoSize = true;
            this.lblDiseaseHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiseaseHistory.Location = new System.Drawing.Point(28, 294);
            this.lblDiseaseHistory.Name = "lblDiseaseHistory";
            this.lblDiseaseHistory.Size = new System.Drawing.Size(56, 14);
            this.lblDiseaseHistory.TabIndex = 1000000042;
            this.lblDiseaseHistory.Text = "即往史:";
            this.lblDiseaseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDiseaseHistory7
            // 
            this.chkDiseaseHistory7.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory7.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory7.Location = new System.Drawing.Point(198, 40);
            this.chkDiseaseHistory7.Name = "chkDiseaseHistory7";
            this.chkDiseaseHistory7.Size = new System.Drawing.Size(82, 22);
            this.chkDiseaseHistory7.TabIndex = 460;
            this.chkDiseaseHistory7.Tag = "7";
            this.chkDiseaseHistory7.Text = "慢性鼻炎";
            this.chkDiseaseHistory7.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory9
            // 
            this.chkDiseaseHistory9.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory9.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory9.Location = new System.Drawing.Point(338, 8);
            this.chkDiseaseHistory9.Name = "chkDiseaseHistory9";
            this.chkDiseaseHistory9.Size = new System.Drawing.Size(54, 22);
            this.chkDiseaseHistory9.TabIndex = 480;
            this.chkDiseaseHistory9.Tag = "9";
            this.chkDiseaseHistory9.Text = "甲减";
            this.chkDiseaseHistory9.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory6
            // 
            this.chkDiseaseHistory6.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory6.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory6.Location = new System.Drawing.Point(97, 40);
            this.chkDiseaseHistory6.Name = "chkDiseaseHistory6";
            this.chkDiseaseHistory6.Size = new System.Drawing.Size(92, 22);
            this.chkDiseaseHistory6.TabIndex = 450;
            this.chkDiseaseHistory6.Tag = "6";
            this.chkDiseaseHistory6.Text = "肢端肥大症";
            this.chkDiseaseHistory6.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory5
            // 
            this.chkDiseaseHistory5.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory5.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory5.Location = new System.Drawing.Point(6, 40);
            this.chkDiseaseHistory5.Name = "chkDiseaseHistory5";
            this.chkDiseaseHistory5.Size = new System.Drawing.Size(82, 22);
            this.chkDiseaseHistory5.TabIndex = 440;
            this.chkDiseaseHistory5.Tag = "5";
            this.chkDiseaseHistory5.Text = "高脂血症";
            this.chkDiseaseHistory5.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory4
            // 
            this.chkDiseaseHistory4.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory4.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory4.Location = new System.Drawing.Point(278, 8);
            this.chkDiseaseHistory4.Name = "chkDiseaseHistory4";
            this.chkDiseaseHistory4.Size = new System.Drawing.Size(54, 22);
            this.chkDiseaseHistory4.TabIndex = 430;
            this.chkDiseaseHistory4.Tag = "4";
            this.chkDiseaseHistory4.Text = "糖尿病";
            this.chkDiseaseHistory4.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory2
            // 
            this.chkDiseaseHistory2.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory2.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory2.Location = new System.Drawing.Point(156, 8);
            this.chkDiseaseHistory2.Name = "chkDiseaseHistory2";
            this.chkDiseaseHistory2.Size = new System.Drawing.Size(54, 22);
            this.chkDiseaseHistory2.TabIndex = 410;
            this.chkDiseaseHistory2.Tag = "2";
            this.chkDiseaseHistory2.Text = "COPD";
            this.chkDiseaseHistory2.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory3
            // 
            this.chkDiseaseHistory3.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory3.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory3.Location = new System.Drawing.Point(217, 8);
            this.chkDiseaseHistory3.Name = "chkDiseaseHistory3";
            this.chkDiseaseHistory3.Size = new System.Drawing.Size(54, 22);
            this.chkDiseaseHistory3.TabIndex = 420;
            this.chkDiseaseHistory3.Tag = "3";
            this.chkDiseaseHistory3.Text = "哮喘";
            this.chkDiseaseHistory3.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory1
            // 
            this.chkDiseaseHistory1.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory1.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory1.Location = new System.Drawing.Point(81, 8);
            this.chkDiseaseHistory1.Name = "chkDiseaseHistory1";
            this.chkDiseaseHistory1.Size = new System.Drawing.Size(68, 22);
            this.chkDiseaseHistory1.TabIndex = 400;
            this.chkDiseaseHistory1.Tag = "1";
            this.chkDiseaseHistory1.Text = "高血压";
            this.chkDiseaseHistory1.UseVisualStyleBackColor = false;
            // 
            // ChkDiseaseHistory0
            // 
            this.ChkDiseaseHistory0.BackColor = System.Drawing.SystemColors.Control;
            this.ChkDiseaseHistory0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkDiseaseHistory0.ForeColor = System.Drawing.Color.Black;
            this.ChkDiseaseHistory0.Location = new System.Drawing.Point(6, 8);
            this.ChkDiseaseHistory0.Name = "ChkDiseaseHistory0";
            this.ChkDiseaseHistory0.Size = new System.Drawing.Size(68, 22);
            this.ChkDiseaseHistory0.TabIndex = 390;
            this.ChkDiseaseHistory0.Tag = "0";
            this.ChkDiseaseHistory0.Text = "冠心病 ";
            this.ChkDiseaseHistory0.UseVisualStyleBackColor = false;
            // 
            // chkDiseaseHistory8
            // 
            this.chkDiseaseHistory8.BackColor = System.Drawing.SystemColors.Control;
            this.chkDiseaseHistory8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDiseaseHistory8.ForeColor = System.Drawing.Color.Black;
            this.chkDiseaseHistory8.Location = new System.Drawing.Point(289, 40);
            this.chkDiseaseHistory8.Name = "chkDiseaseHistory8";
            this.chkDiseaseHistory8.Size = new System.Drawing.Size(98, 22);
            this.chkDiseaseHistory8.TabIndex = 470;
            this.chkDiseaseHistory8.Tag = "8";
            this.chkDiseaseHistory8.Text = "慢性咽喉炎";
            this.chkDiseaseHistory8.UseVisualStyleBackColor = false;
            // 
            // txtLastMedicines
            // 
            this.txtLastMedicines.AccessibleDescription = "主诉";
            this.txtLastMedicines.BackColor = System.Drawing.Color.White;
            this.txtLastMedicines.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLastMedicines.ForeColor = System.Drawing.Color.Black;
            this.txtLastMedicines.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLastMedicines.Location = new System.Drawing.Point(88, 354);
            this.txtLastMedicines.m_BlnIgnoreUserInfo = true;
            this.txtLastMedicines.m_BlnPartControl = false;
            this.txtLastMedicines.m_BlnReadOnly = false;
            this.txtLastMedicines.m_BlnUnderLineDST = false;
            this.txtLastMedicines.m_ClrDST = System.Drawing.Color.Red;
            this.txtLastMedicines.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtLastMedicines.m_IntCanModifyTime = 6;
            this.txtLastMedicines.m_IntPartControlLength = 0;
            this.txtLastMedicines.m_IntPartControlStartIndex = 0;
            this.txtLastMedicines.m_StrUserID = "";
            this.txtLastMedicines.m_StrUserName = "";
            this.txtLastMedicines.Name = "txtLastMedicines";
            this.txtLastMedicines.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLastMedicines.Size = new System.Drawing.Size(680, 44);
            this.txtLastMedicines.TabIndex = 620;
            this.txtLastMedicines.Tag = "1";
            this.txtLastMedicines.Text = "";
            // 
            // txtIrritability
            // 
            this.txtIrritability.AccessibleDescription = "主诉";
            this.txtIrritability.BackColor = System.Drawing.Color.White;
            this.txtIrritability.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIrritability.ForeColor = System.Drawing.Color.Black;
            this.txtIrritability.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtIrritability.Location = new System.Drawing.Point(98, 367);
            this.txtIrritability.m_BlnIgnoreUserInfo = true;
            this.txtIrritability.m_BlnPartControl = false;
            this.txtIrritability.m_BlnReadOnly = false;
            this.txtIrritability.m_BlnUnderLineDST = false;
            this.txtIrritability.m_ClrDST = System.Drawing.Color.Red;
            this.txtIrritability.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtIrritability.m_IntCanModifyTime = 6;
            this.txtIrritability.m_IntPartControlLength = 0;
            this.txtIrritability.m_IntPartControlStartIndex = 0;
            this.txtIrritability.m_StrUserID = "";
            this.txtIrritability.m_StrUserName = "";
            this.txtIrritability.Name = "txtIrritability";
            this.txtIrritability.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtIrritability.Size = new System.Drawing.Size(518, 44);
            this.txtIrritability.TabIndex = 490;
            this.txtIrritability.Tag = "1";
            this.txtIrritability.Text = "";
            // 
            // lblIrritability
            // 
            this.lblIrritability.AutoSize = true;
            this.lblIrritability.BackColor = System.Drawing.SystemColors.Control;
            this.lblIrritability.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIrritability.ForeColor = System.Drawing.Color.Black;
            this.lblIrritability.Location = new System.Drawing.Point(26, 367);
            this.lblIrritability.Name = "lblIrritability";
            this.lblIrritability.Size = new System.Drawing.Size(56, 14);
            this.lblIrritability.TabIndex = 1000000053;
            this.lblIrritability.Text = "过敏史:";
            this.lblIrritability.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkPhysique
            // 
            this.chkPhysique.AutoSize = true;
            this.chkPhysique.BackColor = System.Drawing.SystemColors.Control;
            this.chkPhysique.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPhysique.ForeColor = System.Drawing.Color.Black;
            this.chkPhysique.Location = new System.Drawing.Point(12, 13);
            this.chkPhysique.Name = "chkPhysique";
            this.chkPhysique.Size = new System.Drawing.Size(70, 14);
            this.chkPhysique.TabIndex = 1000000056;
            this.chkPhysique.Text = "体格检查:";
            this.chkPhysique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(89, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 14);
            this.label20.TabIndex = 1000000057;
            this.label20.Text = "身高";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.White;
            this.txtHeight.BorderColor = System.Drawing.Color.White;
            this.txtHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeight.ForeColor = System.Drawing.Color.Black;
            this.txtHeight.Location = new System.Drawing.Point(130, 13);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(42, 23);
            this.txtHeight.TabIndex = 500;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(179, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 14);
            this.label21.TabIndex = 1000000059;
            this.label21.Text = "cm";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(296, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 14);
            this.label22.TabIndex = 1000000062;
            this.label22.Text = "kg";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.Color.White;
            this.txtWeight.BorderColor = System.Drawing.Color.White;
            this.txtWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWeight.ForeColor = System.Drawing.Color.Black;
            this.txtWeight.Location = new System.Drawing.Point(247, 13);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(42, 23);
            this.txtWeight.TabIndex = 510;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(206, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 1000000060;
            this.label23.Text = "体重";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(499, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 14);
            this.label24.TabIndex = 1000000065;
            this.label24.Text = "mmHg";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBloodPressure
            // 
            this.txtBloodPressure.BackColor = System.Drawing.Color.White;
            this.txtBloodPressure.BorderColor = System.Drawing.Color.White;
            this.txtBloodPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBloodPressure.ForeColor = System.Drawing.Color.Black;
            this.txtBloodPressure.Location = new System.Drawing.Point(364, 13);
            this.txtBloodPressure.Name = "txtBloodPressure";
            this.txtBloodPressure.Size = new System.Drawing.Size(129, 23);
            this.txtBloodPressure.TabIndex = 520;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(323, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 14);
            this.label25.TabIndex = 1000000063;
            this.label25.Text = "血压";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeadNeck
            // 
            this.lblHeadNeck.AutoSize = true;
            this.lblHeadNeck.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeadNeck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeadNeck.ForeColor = System.Drawing.Color.Black;
            this.lblHeadNeck.Location = new System.Drawing.Point(41, 47);
            this.lblHeadNeck.Name = "lblHeadNeck";
            this.lblHeadNeck.Size = new System.Drawing.Size(42, 14);
            this.lblHeadNeck.TabIndex = 1000000066;
            this.lblHeadNeck.Text = "头颈:";
            this.lblHeadNeck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkHeadNeck4
            // 
            this.chkHeadNeck4.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck4.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck4.Location = new System.Drawing.Point(376, 6);
            this.chkHeadNeck4.Name = "chkHeadNeck4";
            this.chkHeadNeck4.Size = new System.Drawing.Size(82, 22);
            this.chkHeadNeck4.TabIndex = 570;
            this.chkHeadNeck4.Tag = "4";
            this.chkHeadNeck4.Text = "右扁桃体 ";
            this.chkHeadNeck4.UseVisualStyleBackColor = false;
            // 
            // chkHeadNeck3
            // 
            this.chkHeadNeck3.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck3.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck3.Location = new System.Drawing.Point(287, 6);
            this.chkHeadNeck3.Name = "chkHeadNeck3";
            this.chkHeadNeck3.Size = new System.Drawing.Size(82, 22);
            this.chkHeadNeck3.TabIndex = 560;
            this.chkHeadNeck3.Tag = "3";
            this.chkHeadNeck3.Text = "左扁桃体";
            this.chkHeadNeck3.UseVisualStyleBackColor = false;
            // 
            // chkHeadNeck2
            // 
            this.chkHeadNeck2.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck2.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck2.Location = new System.Drawing.Point(184, 6);
            this.chkHeadNeck2.Name = "chkHeadNeck2";
            this.chkHeadNeck2.Size = new System.Drawing.Size(96, 22);
            this.chkHeadNeck2.TabIndex = 550;
            this.chkHeadNeck2.Tag = "2";
            this.chkHeadNeck2.Text = "悬雍垂肥大";
            this.chkHeadNeck2.UseVisualStyleBackColor = false;
            // 
            // chkHeadNeck1
            // 
            this.chkHeadNeck1.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck1.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck1.Location = new System.Drawing.Point(95, 6);
            this.chkHeadNeck1.Name = "chkHeadNeck1";
            this.chkHeadNeck1.Size = new System.Drawing.Size(82, 22);
            this.chkHeadNeck1.TabIndex = 540;
            this.chkHeadNeck1.Tag = "1";
            this.chkHeadNeck1.Text = "咽喉狭窄";
            this.chkHeadNeck1.UseVisualStyleBackColor = false;
            // 
            // chkHeadNeck0
            // 
            this.chkHeadNeck0.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck0.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck0.Location = new System.Drawing.Point(6, 6);
            this.chkHeadNeck0.Name = "chkHeadNeck0";
            this.chkHeadNeck0.Size = new System.Drawing.Size(82, 22);
            this.chkHeadNeck0.TabIndex = 530;
            this.chkHeadNeck0.Tag = "0";
            this.chkHeadNeck0.Text = "鼻甲肥大";
            this.chkHeadNeck0.UseVisualStyleBackColor = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(41, 119);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 14);
            this.label27.TabIndex = 1000000072;
            this.label27.Text = "心脏:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeart
            // 
            this.txtHeart.BackColor = System.Drawing.Color.White;
            this.txtHeart.BorderColor = System.Drawing.Color.White;
            this.txtHeart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeart.ForeColor = System.Drawing.Color.Black;
            this.txtHeart.Location = new System.Drawing.Point(88, 117);
            this.txtHeart.Name = "txtHeart";
            this.txtHeart.Size = new System.Drawing.Size(680, 23);
            this.txtHeart.TabIndex = 580;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(55, 147);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 14);
            this.label28.TabIndex = 1000000074;
            this.label28.Text = "肺:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLung
            // 
            this.txtLung.BackColor = System.Drawing.Color.White;
            this.txtLung.BorderColor = System.Drawing.Color.White;
            this.txtLung.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLung.ForeColor = System.Drawing.Color.Black;
            this.txtLung.Location = new System.Drawing.Point(88, 147);
            this.txtLung.Name = "txtLung";
            this.txtLung.Size = new System.Drawing.Size(680, 23);
            this.txtLung.TabIndex = 590;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(41, 177);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 14);
            this.label29.TabIndex = 1000000076;
            this.label29.Text = "其他:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOtherPart
            // 
            this.txtOtherPart.BackColor = System.Drawing.Color.White;
            this.txtOtherPart.BorderColor = System.Drawing.Color.White;
            this.txtOtherPart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOtherPart.ForeColor = System.Drawing.Color.Black;
            this.txtOtherPart.Location = new System.Drawing.Point(88, 177);
            this.txtOtherPart.Name = "txtOtherPart";
            this.txtOtherPart.Size = new System.Drawing.Size(680, 23);
            this.txtOtherPart.TabIndex = 600;
            // 
            // lblClinicalDiagnose
            // 
            this.lblClinicalDiagnose.AutoSize = true;
            this.lblClinicalDiagnose.BackColor = System.Drawing.SystemColors.Control;
            this.lblClinicalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.lblClinicalDiagnose.Location = new System.Drawing.Point(12, 205);
            this.lblClinicalDiagnose.Name = "lblClinicalDiagnose";
            this.lblClinicalDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblClinicalDiagnose.TabIndex = 1000000077;
            this.lblClinicalDiagnose.Text = "临床诊断:";
            this.lblClinicalDiagnose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClinicalDiagnose
            // 
            this.txtClinicalDiagnose.AccessibleDescription = "主诉";
            this.txtClinicalDiagnose.BackColor = System.Drawing.Color.White;
            this.txtClinicalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClinicalDiagnose.Location = new System.Drawing.Point(88, 207);
            this.txtClinicalDiagnose.m_BlnIgnoreUserInfo = true;
            this.txtClinicalDiagnose.m_BlnPartControl = false;
            this.txtClinicalDiagnose.m_BlnReadOnly = false;
            this.txtClinicalDiagnose.m_BlnUnderLineDST = false;
            this.txtClinicalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalDiagnose.m_IntCanModifyTime = 6;
            this.txtClinicalDiagnose.m_IntPartControlLength = 0;
            this.txtClinicalDiagnose.m_IntPartControlStartIndex = 0;
            this.txtClinicalDiagnose.m_StrUserID = "";
            this.txtClinicalDiagnose.m_StrUserName = "";
            this.txtClinicalDiagnose.Name = "txtClinicalDiagnose";
            this.txtClinicalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalDiagnose.Size = new System.Drawing.Size(680, 117);
            this.txtClinicalDiagnose.TabIndex = 610;
            this.txtClinicalDiagnose.Tag = "1";
            this.txtClinicalDiagnose.Text = "";
            // 
            // lblLastMedicines
            // 
            this.lblLastMedicines.AutoSize = true;
            this.lblLastMedicines.BackColor = System.Drawing.SystemColors.Control;
            this.lblLastMedicines.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastMedicines.ForeColor = System.Drawing.Color.Black;
            this.lblLastMedicines.Location = new System.Drawing.Point(12, 327);
            this.lblLastMedicines.Name = "lblLastMedicines";
            this.lblLastMedicines.Size = new System.Drawing.Size(266, 14);
            this.lblLastMedicines.TabIndex = 1000000079;
            this.lblLastMedicines.Text = "近期使用的药物:(药名、剂量及使用时间)";
            this.lblLastMedicines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRequesterSign
            // 
            this.cmdRequesterSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdRequesterSign.DefaultScheme = true;
            this.cmdRequesterSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRequesterSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRequesterSign.Hint = "";
            this.cmdRequesterSign.Location = new System.Drawing.Point(460, 402);
            this.cmdRequesterSign.Name = "cmdRequesterSign";
            this.cmdRequesterSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRequesterSign.Size = new System.Drawing.Size(84, 24);
            this.cmdRequesterSign.TabIndex = 630;
            this.cmdRequesterSign.Tag = "1";
            this.cmdRequesterSign.Text = "申请医生:";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRequestDate.Location = new System.Drawing.Point(375, 99);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(70, 14);
            this.lblRequestDate.TabIndex = 1000000084;
            this.lblRequestDate.Text = "申请日期:";
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.BorderColor = System.Drawing.Color.Black;
            this.dtpRequestDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpRequestDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpRequestDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpRequestDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpRequestDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpRequestDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(451, 96);
            this.dtpRequestDate.m_BlnOnlyTime = false;
            this.dtpRequestDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpRequestDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpRequestDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.ReadOnly = false;
            this.dtpRequestDate.Size = new System.Drawing.Size(141, 22);
            this.dtpRequestDate.TabIndex = 60;
            this.dtpRequestDate.TextBackColor = System.Drawing.Color.White;
            this.dtpRequestDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // dtpBespeak
            // 
            this.dtpBespeak.BorderColor = System.Drawing.Color.Black;
            this.dtpBespeak.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpBespeak.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpBespeak.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpBespeak.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpBespeak.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpBespeak.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBespeak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBespeak.Location = new System.Drawing.Point(108, 124);
            this.dtpBespeak.m_BlnOnlyTime = false;
            this.dtpBespeak.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpBespeak.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBespeak.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBespeak.Name = "dtpBespeak";
            this.dtpBespeak.ReadOnly = false;
            this.dtpBespeak.Size = new System.Drawing.Size(214, 22);
            this.dtpBespeak.TabIndex = 70;
            this.dtpBespeak.TextBackColor = System.Drawing.Color.White;
            this.dtpBespeak.TextForeColor = System.Drawing.Color.Black;
            this.dtpBespeak.Load += new System.EventHandler(this.dtpBespeak_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1000000086;
            this.label1.Text = "预约:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumber.ForeColor = System.Drawing.Color.Black;
            this.lblNumber.Location = new System.Drawing.Point(375, 125);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(70, 14);
            this.lblNumber.TabIndex = 1000000087;
            this.lblNumber.Text = "申请单号:";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.White;
            this.txtNumber.BorderColor = System.Drawing.Color.White;
            this.txtNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNumber.ForeColor = System.Drawing.Color.Black;
            this.txtNumber.Location = new System.Drawing.Point(451, 123);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(141, 23);
            this.txtNumber.TabIndex = 80;
            // 
            // pnlDiseaseHistory
            // 
            this.pnlDiseaseHistory.Controls.Add(this.ChkDiseaseHistory0);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory1);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory2);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory3);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory4);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory5);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory6);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory7);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory8);
            this.pnlDiseaseHistory.Controls.Add(this.chkDiseaseHistory9);
            this.pnlDiseaseHistory.Location = new System.Drawing.Point(98, 286);
            this.pnlDiseaseHistory.Name = "pnlDiseaseHistory";
            this.pnlDiseaseHistory.Size = new System.Drawing.Size(528, 68);
            this.pnlDiseaseHistory.TabIndex = 389;
            // 
            // pnlOther
            // 
            this.pnlOther.Controls.Add(this.chkOther0);
            this.pnlOther.Controls.Add(this.chkOther1);
            this.pnlOther.Controls.Add(this.chkOther2);
            this.pnlOther.Controls.Add(this.chkOther3);
            this.pnlOther.Location = new System.Drawing.Point(98, 250);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(528, 30);
            this.pnlOther.TabIndex = 349;
            // 
            // pnlSleep
            // 
            this.pnlSleep.Controls.Add(this.chkSleep0);
            this.pnlSleep.Controls.Add(this.chkSleep1);
            this.pnlSleep.Controls.Add(this.chkSleep2);
            this.pnlSleep.Controls.Add(this.chkSleep3);
            this.pnlSleep.Controls.Add(this.chkSleep4);
            this.pnlSleep.Location = new System.Drawing.Point(98, 216);
            this.pnlSleep.Name = "pnlSleep";
            this.pnlSleep.Size = new System.Drawing.Size(528, 30);
            this.pnlSleep.TabIndex = 299;
            // 
            // pnlGoWithSymptom
            // 
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom0);
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom1);
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom2);
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom3);
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom4);
            this.pnlGoWithSymptom.Controls.Add(this.chkGoWithSymptom5);
            this.pnlGoWithSymptom.Location = new System.Drawing.Point(98, 180);
            this.pnlGoWithSymptom.Name = "pnlGoWithSymptom";
            this.pnlGoWithSymptom.Size = new System.Drawing.Size(528, 30);
            this.pnlGoWithSymptom.TabIndex = 239;
            // 
            // pnlHeadNeck
            // 
            this.pnlHeadNeck.Controls.Add(this.label2);
            this.pnlHeadNeck.Controls.Add(this.txtHeadNeckOther);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck5);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck6);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck0);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck1);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck2);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck3);
            this.pnlHeadNeck.Controls.Add(this.chkHeadNeck4);
            this.pnlHeadNeck.Location = new System.Drawing.Point(88, 41);
            this.pnlHeadNeck.Name = "pnlHeadNeck";
            this.pnlHeadNeck.Size = new System.Drawing.Size(694, 68);
            this.pnlHeadNeck.TabIndex = 529;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(155, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 1000000012;
            this.label2.Text = "其他:";
            // 
            // txtHeadNeckOther
            // 
            this.txtHeadNeckOther.BackColor = System.Drawing.Color.White;
            this.txtHeadNeckOther.BorderColor = System.Drawing.Color.White;
            this.txtHeadNeckOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeadNeckOther.ForeColor = System.Drawing.Color.Black;
            this.txtHeadNeckOther.Location = new System.Drawing.Point(201, 37);
            this.txtHeadNeckOther.Name = "txtHeadNeckOther";
            this.txtHeadNeckOther.Size = new System.Drawing.Size(479, 23);
            this.txtHeadNeckOther.TabIndex = 1000000011;
            // 
            // chkHeadNeck5
            // 
            this.chkHeadNeck5.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck5.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck5.Location = new System.Drawing.Point(6, 38);
            this.chkHeadNeck5.Name = "chkHeadNeck5";
            this.chkHeadNeck5.Size = new System.Drawing.Size(58, 22);
            this.chkHeadNeck5.TabIndex = 571;
            this.chkHeadNeck5.Tag = "5";
            this.chkHeadNeck5.Text = "小颌";
            this.chkHeadNeck5.UseVisualStyleBackColor = false;
            // 
            // chkHeadNeck6
            // 
            this.chkHeadNeck6.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeadNeck6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeadNeck6.ForeColor = System.Drawing.Color.Black;
            this.chkHeadNeck6.Location = new System.Drawing.Point(75, 38);
            this.chkHeadNeck6.Name = "chkHeadNeck6";
            this.chkHeadNeck6.Size = new System.Drawing.Size(69, 22);
            this.chkHeadNeck6.TabIndex = 572;
            this.chkHeadNeck6.Tag = "6";
            this.chkHeadNeck6.Text = "颈粗短";
            this.chkHeadNeck6.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblMainDescription);
            this.panel2.Controls.Add(this.txtMainDescription);
            this.panel2.Controls.Add(this.lblDisease);
            this.panel2.Controls.Add(this.lblNoseSnore);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pnlNoseSnoreLevel);
            this.panel2.Controls.Add(this.pnlNoseSnoreBeginTime);
            this.panel2.Controls.Add(this.lblSnooze);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pnlSnoozeLevel);
            this.panel2.Controls.Add(this.pnlSnoozeBeginTime);
            this.panel2.Controls.Add(this.lblGoWithSymptom);
            this.panel2.Controls.Add(this.pnlGoWithSymptom);
            this.panel2.Controls.Add(this.lblSleep);
            this.panel2.Controls.Add(this.pnlSleep);
            this.panel2.Controls.Add(this.lblOther);
            this.panel2.Controls.Add(this.pnlOther);
            this.panel2.Controls.Add(this.lblDiseaseHistory);
            this.panel2.Controls.Add(this.pnlDiseaseHistory);
            this.panel2.Controls.Add(this.lblIrritability);
            this.panel2.Controls.Add(this.txtIrritability);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 442);
            this.panel2.TabIndex = 1000000089;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_txtRequesterSign);
            this.panel3.Controls.Add(this.chkPhysique);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtHeight);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.txtWeight);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.txtBloodPressure);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.lblHeadNeck);
            this.panel3.Controls.Add(this.pnlHeadNeck);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.txtHeart);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.txtLung);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.txtOtherPart);
            this.panel3.Controls.Add(this.lblClinicalDiagnose);
            this.panel3.Controls.Add(this.txtClinicalDiagnose);
            this.panel3.Controls.Add(this.lblLastMedicines);
            this.panel3.Controls.Add(this.txtLastMedicines);
            this.panel3.Controls.Add(this.cmdRequesterSign);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 442);
            this.panel3.TabIndex = 1000000090;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(9, 152);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 1;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(795, 468);
            this.tabControl2.TabIndex = 1000000089;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(795, 442);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "病史";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(795, 442);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "体检与其他";
            // 
            // m_txtRequesterSign
            // 
            this.m_txtRequesterSign.Location = new System.Drawing.Point(556, 402);
            this.m_txtRequesterSign.Name = "m_txtRequesterSign";
            this.m_txtRequesterSign.ReadOnly = true;
            this.m_txtRequesterSign.Size = new System.Drawing.Size(100, 24);
            this.m_txtRequesterSign.TabIndex = 1000000080;
            // 
            // frmNuclearOrder
            // 
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(812, 657);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.lblVocation);
            this.Controls.Add(this.lblLastCheck);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.dtpBespeak);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.txtVocation);
            this.Controls.Add(this.dtpLastCheck);
            this.Controls.Add(this.trvTime);
            this.Name = "frmNuclearOrder";
            this.Text = "电脑多导睡眠图检查申请单";
            this.Load += new System.EventHandler(this.frmNuclearOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.dtpLastCheck, 0);
            this.Controls.SetChildIndex(this.txtVocation, 0);
            this.Controls.SetChildIndex(this.dtpRequestDate, 0);
            this.Controls.SetChildIndex(this.dtpBespeak, 0);
            this.Controls.SetChildIndex(this.txtNumber, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
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
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblLastCheck, 0);
            this.Controls.SetChildIndex(this.lblVocation, 0);
            this.Controls.SetChildIndex(this.lblRequestDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblNumber, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlNoseSnoreLevel.ResumeLayout(false);
            this.pnlNoseSnoreBeginTime.ResumeLayout(false);
            this.pnlNoseSnoreBeginTime.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.pnlSnoozeLevel.ResumeLayout(false);
            this.pnlSnoozeBeginTime.ResumeLayout(false);
            this.pnlSnoozeBeginTime.PerformLayout();
            this.pnlDiseaseHistory.ResumeLayout(false);
            this.pnlOther.ResumeLayout(false);
            this.pnlSleep.ResumeLayout(false);
            this.pnlGoWithSymptom.ResumeLayout(false);
            this.pnlHeadNeck.ResumeLayout(false);
            this.pnlHeadNeck.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	
		#region 重载窗体基类
		
		public void Save()
		{
			if(m_objCurrentPatient==null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
				return ;
			}
			m_lngSave();

		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Display()
		{
					

		}
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(string cardno,string sendcheckdate){}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{

			long m_lngRe=m_objDomain.GetNuclearOrder( strInPatientID,strInPatientDate,strCreateDate,out m_objNuclear);
			if(m_lngRe<0) 
				return ;

			if(m_objNuclear.strCreateUserID.Trim()!=clsEMRLogin.LoginEmployee.m_strEMPID_CHR)
			{
				m_mthReadOnly(true);
			}
			else
			{
				m_mthReadOnly(false);
			}

			//this.lblApplyDotorID.Text =new clsEmployee(m_objNuclear.strApplyDotorID).m_StrFirstName;

            //m_objSignTool.m_mtSetSpecialEmployee(m_objNuclear.m_strRequesterSign );

			//this.lblApplyDotorID.Tag=m_objNuclear.strApplyDotorID;
            if (m_objCurrentPatient != null)
            {
                this.txtVocation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
                this.txtTelephone.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
                this.txtAddress.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            }
            else
            {
                this.txtVocation.Text = string.Empty;
                this.txtTelephone.Text = string.Empty;
                this.txtAddress.Text = string.Empty;
            }
			

			this.dtpLastCheck.Value=DateTime.Parse(m_objNuclear.m_strLastCheck);
			this.dtpBespeak.Value=DateTime.Parse(m_objNuclear.m_strBespeak);
			this.dtpRequestDate.Value=DateTime.Parse(m_objNuclear.m_strRequestDate );
			this.txtNumber.Text=m_objNuclear.m_strNumber;
			this.txtMainDescription.Text=m_objNuclear.m_strMainDescription;
			this.txtIrritability.Text=m_objNuclear.m_strIrritability;
			this.txtHeight.Text=m_objNuclear.m_strHeight;
			this.txtWeight.Text=m_objNuclear.m_strWeight;
			this.txtBloodPressure.Text=m_objNuclear.m_strBloodPressure;
			this.txtHeadNeckOther.Text=m_objNuclear.m_strHeadNeckOther ;
			this.txtHeart.Text=m_objNuclear.m_strHeart;
			this.txtLung.Text=m_objNuclear.m_strLung;
			this.txtOtherPart.Text=m_objNuclear.m_strOtherPart;
			this.txtClinicalDiagnose.Text=m_objNuclear.m_strClinicalDiagnose;
			this.txtLastMedicines.Text=m_objNuclear.m_strLastMedicines;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objNuclear.m_strRequesterSign, out objEmpVO);
            if (objEmpVO != null)
            {
                this.m_txtRequesterSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                this.m_txtRequesterSign.Tag = objEmpVO;
            }

			if(m_objNuclear.m_blnIsNoseSnore==true)
			{
				//设置控件的默认值
				this.rdbNoseSnore.Checked=true;
				this.rdbNoNoseSnore.Checked=false;
				this.rdbNoseSnoreLitter.Checked =false;
				this.rdbNoseSnoreSome.Checked =false;
				this.rdbNoseSnoreMany.Checked =false;

				switch (m_objNuclear.m_enmNoseSnoreLevel)
				{
					case enmLevel.enmLitter:
                        rdbNoseSnoreLitter.Checked=true;
						break;

					case enmLevel.enmSome:
						rdbNoseSnoreSome.Checked=true;
						break;
					case enmLevel.enmMany:
						rdbNoseSnoreMany.Checked=true;
						break;
				}

				this.txtNoseSnoreBeginMonth.Text =m_objNuclear.m_strNoseSnoreBeginMonth ;
				this.txtNoseSnoreBeginYear.Text =m_objNuclear.m_strNoseSnoreBeginYear;

				//设置控件的Enable属性
				this.rdbNoseSnore.Enabled =true;
				this.rdbNoNoseSnore.Enabled =true;
				this.rdbNoseSnoreLitter.Enabled=true;
				this.rdbNoseSnoreSome.Enabled=true;
				this.rdbNoseSnoreMany.Enabled=true;
				this.txtNoseSnoreBeginMonth.Enabled=true;
				this.txtNoseSnoreBeginYear.Enabled=true;

			}
			else
			{
				//设置控件的默认值
				this.rdbNoNoseSnore.Checked=true;
				this.rdbNoseSnore.Checked=false;

				this.rdbNoseSnoreLitter.Checked =false;
				this.rdbNoseSnoreSome.Checked =false;
				this.rdbNoseSnoreMany.Checked =false;
				this.txtNoseSnoreBeginMonth.Text ="";
				this.txtNoseSnoreBeginYear.Text ="";

				//设置控件的Enable属性
				this.rdbNoseSnore.Enabled =true;
				this.rdbNoNoseSnore.Enabled =true;
				this.rdbNoseSnoreLitter.Enabled=false;
				this.rdbNoseSnoreSome.Enabled=false;
				this.rdbNoseSnoreMany.Enabled=false;
				this.txtNoseSnoreBeginMonth.Enabled=false;
				this.txtNoseSnoreBeginYear.Enabled=false;
				
			}


			if(m_objNuclear.m_blnIsSnooze==true)
			{
				//设置控件的默认值
				this.rdbSnooze.Checked=true;
				this.rdbNoSnooze.Checked=false;

				this.rdbSnoozeLitter.Checked =false;
				this.rdbSnoozeSome.Checked =false;
				this.rdbSnoozeMany.Checked =false;

				switch(m_objNuclear.m_enmSnoozeLevel )
				{
					case enmLevel.enmLitter :
						this.rdbSnoozeLitter .Checked=true;
						break;
					case enmLevel.enmMany:
						this.rdbSnoozeMany.Checked=true;
						break;
					case enmLevel.enmSome:
						this.rdbSnoozeSome.Checked=true;
						break;

				}
				this.txtSnoozeBeginMonth.Text =m_objNuclear.m_strSnoozeBeginMonth ;
				this.txtSnoozeBeginYear.Text =m_objNuclear.m_strSnoozeBeginYear ;

				//设置控件的Enable属性
				this.rdbSnooze.Enabled =true;
				this.rdbNoSnooze.Enabled =true;
				this.rdbSnoozeLitter.Enabled=true;
				this.rdbSnoozeSome.Enabled=true;
				this.rdbSnoozeMany.Enabled=true;
				this.txtSnoozeBeginMonth.Enabled=true;
				this.txtSnoozeBeginYear.Enabled=true;

			}
			else
			{
				//设置控件的默认值
				this.rdbNoSnooze.Checked=true;
				this.rdbSnooze.Checked=false;

				this.rdbSnoozeLitter.Checked =false;
				this.rdbSnoozeSome.Checked =false;
				this.rdbSnoozeMany.Checked =false;
				this.txtSnoozeBeginMonth.Text ="";
				this.txtSnoozeBeginYear.Text ="";

				//设置控件的Enable属性
				this.rdbSnooze.Enabled =true;
				this.rdbNoSnooze.Enabled =true;
				this.rdbSnoozeLitter.Enabled=false;
				this.rdbSnoozeSome.Enabled=false;
				this.rdbSnoozeMany.Enabled=false;
				this.txtSnoozeBeginMonth.Enabled=false;
				this.txtSnoozeBeginYear.Enabled=false;
				
			}
			this.m_lngSetControlValFromCheckPartSelectionStr(m_objNuclear.m_strSleep,this.pnlSleep);
			this.m_lngSetControlValFromCheckPartSelectionStr(m_objNuclear.m_strOther,this.pnlOther);
			this.m_lngSetControlValFromCheckPartSelectionStr(m_objNuclear.m_strDiseaseHistory ,this.pnlDiseaseHistory );
			this.m_lngSetControlValFromCheckPartSelectionStr(m_objNuclear.m_strGoWithSymptom ,this.pnlGoWithSymptom);
			this.m_lngSetControlValFromCheckPartSelectionStr(m_objNuclear.m_strHeadNeck ,this.pnlHeadNeck);

		}

		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{
			m_lngPrint();
		}
		
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return blnCanSearch;
			}
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;			
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objNuclear =null;

            //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString();
            //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;

			this.txtVocation.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
			this.txtTelephone.Text  = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
			this.txtAddress.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress ;

            //m_objCurrentPatient=p_objSelectedPatient;
            //m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
			
		}


		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(dtpRequestDate .Enabled==true)////Add New
					return true;
				else 
					return false;
		
			}
		}

		protected override long m_lngSubModify()
		{
			if(m_objNuclear==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
			if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objNuclear.strCreateUserID.Trim())
			{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}

			m_objNuclear=objNuclearCheckOrderContent(false);

            if (m_objNuclear == null)
            {
                return -1;
            }

			long lngSave=m_objDomain.lngSave(false,m_objNuclear); 
			if(lngSave>0)
            {
                clsPublicFunction.ShowInformationMessageBox("修改成功！");
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("修改失败！");
				return -5;
			}

			
		}


		protected override long m_lngSubAddNew()
		{

			m_objNuclear=new clsNuclearOrder ();

			m_objNuclear=objNuclearCheckOrderContent(true);

            if (m_objNuclear == null)
            {
                return -1;
            }

			long lngSave=m_objDomain.lngSave(true,m_objNuclear); 

			if(lngSave>0)
			{
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
				m_mthAddNodeToTrv(this.dtpRequestDate.Value);
				
//				string strBookingInfo = "申请单号："+m_strApplicationID+"\r\n姓名："+m_objImageRequest.m_strPatientName+"\r\n住院号："+m_objImageRequest.m_strInPatientID+"\r\n检查目的："+m_objImageRequest.m_strCheckPurpose;
//
//				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(1),strBookingInfo);	
//			
//				if(!blnSendRes)
//					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
				return -5;
			}
			
		}
		

		protected override long m_lngSubPrint()
		{
			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptPSGRequest.rpt");
			}

			m_mthAddNewDataFordsNuclearOrderDataSet(m_dtsRept);
			
			if(m_blnDirectPrint)
			{
				m_rpdOrderRept.PrintToPrinter(1,true,1,100);
			}
			else
			{
				frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//				objView.MdiParent = this.MdiParent;
				objView.ShowDialog();
			}

			return 1;
		


		}

		protected override long m_lngSubDelete()
		{
			if(blnCanDelete==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,无权删除他人的记录!");
				return 1;
			}
            if (m_objNuclear == null || m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objNuclear.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

			//设置删除日期和删除者ID
			m_objNuclear.m_dtmDeActivedDate=DateTime.Now;
			m_objNuclear.m_strDeActivedOperatorID=MDIParent.OperatorID;

			long lngRes=m_objDomain.lngDelete(m_objNuclear);

			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(DateTime.Parse(trnNode.Tag.ToString())==DateTime.Parse(m_objNuclear.strCreateDate))
					{
						trnNode.Remove();
						break;
					}
				}
				m_mthClearUpSheet();
				m_mthReadOnly(false);
			}
			return lngRes ;
		}

		#endregion 

		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			try
			{
				if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
				string[] m_strAll;
				m_strAll=m_objDomain.lngGetNuclearOrderArrByPatientID(p_strInPatientID ,p_strInPatientDate );
				if(m_strAll.Length>0)
				{

					this.trvTime.Nodes[0].Nodes.Clear();
					foreach(string m_strTemp in m_strAll)
					{
			
						string strDate=DateTime.Parse(m_strTemp).ToString("yyyy年MM月dd日 HH:mm:ss");
						TreeNode trnDate=new TreeNode(strDate);
						trnDate.Tag =m_strTemp;
						this.trvTime.Nodes[0].Nodes.Add(trnDate );
					
					}
				
				}
				else
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
					return;
				}
			
				this.trvTime.ExpandAll();
				this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];	
			}
			catch//(System.Exception ex)
			{
//				MessageBox.Show(ex.Message);
			}
		}

		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			string strDate=p_dtmAdd.ToString("yyyy年MM月dd日 HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmAdd;
			if(trvTime.Nodes[0].Nodes.Count==0)
				trvTime.Nodes[0].Nodes.Add(trnDate);
			else 
			{
				for(int i=0;i<trvTime.Nodes[0].Nodes.Count;i++)
				{
					if(trnDate.Text.CompareTo (trvTime.Nodes[0].Nodes[i].Text)>0)
					{
						trvTime.Nodes[0].Nodes.Insert(i,trnDate);
						break;
					}
				}
			}
			trvTime.SelectedNode=trnDate ;
			this.trvTime.ExpandAll();

		}

		private clsNuclearOrder objNuclearCheckOrderContent(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                return null;
            }

            if (m_txtRequesterSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请医生签名");
                return null;
            }

            m_objNuclear.m_strRequesterSign = ((clsEmrEmployeeBase_VO)m_txtRequesterSign.Tag).m_strEMPID_CHR;
			if(blnIsAddNew==true)
			{
                m_objNuclear.strCreateUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                m_objNuclear.strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objNuclear.strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
				m_objNuclear.strCreateDate =this.dtpRequestDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); 
				//				if(lblApplyDotorID.Tag!=null)
				//				   m_objCT.strApplyDotorID=this.lblApplyDotorID.Tag.ToString();
				//				else 
				//				   m_objCT.strApplyDotorID="";
			}
		
			m_objNuclear.m_strTelephone =this.txtTelephone.Text.Trim();
			m_objNuclear.m_strAddress =this.txtAddress.Text.Trim();
			m_objNuclear.m_strLastCheck=this.dtpLastCheck.Value.ToString();
			m_objNuclear.m_strRequestDate=this.dtpRequestDate.Value.ToString();
			m_objNuclear.m_strBespeak=this.dtpBespeak.Value.ToString();
			m_objNuclear.m_strNumber=this.txtNumber.Text.Trim() ;
			m_objNuclear.m_strMainDescription=this.txtMainDescription.Text.Trim();
			m_objNuclear.m_strHeadNeckOther =this.txtHeadNeckOther.Text.Trim();

 			//设置是否打鼻鼾和打鼾程度,开始时间
			m_objNuclear.m_blnIsNoseSnore=this.rdbNoseSnore.Checked;
			if(this.rdbNoseSnore.Checked==true)
			{
				if(this.rdbNoseSnoreLitter.Checked==true)
					m_objNuclear.m_enmNoseSnoreLevel=enmLevel.enmLitter;
				if(this.rdbNoseSnoreSome.Checked==true)
					m_objNuclear.m_enmNoseSnoreLevel=enmLevel.enmSome;
				if(this.rdbNoseSnoreMany.Checked==true)
					m_objNuclear.m_enmNoseSnoreLevel=enmLevel.enmMany;

				m_objNuclear.m_strNoseSnoreBeginMonth=this.txtNoseSnoreBeginMonth.Text.Trim();
				m_objNuclear.m_strNoseSnoreBeginYear=this.txtNoseSnoreBeginYear.Text.Trim();

			}
			else
			{
				m_objNuclear.m_enmNoseSnoreLevel=enmLevel.enmNone;
				
				m_objNuclear.m_strNoseSnoreBeginMonth="";
				m_objNuclear.m_strNoseSnoreBeginYear="";

			}
			

			//设置是否白天打瞌睡和打瞌睡程度,开始时间
			m_objNuclear.m_blnIsSnooze=this.rdbSnooze.Checked;
			if(this.rdbNoSnooze.Checked==false)
			{
				if(this.rdbSnoozeLitter.Checked==true)
					m_objNuclear.m_enmSnoozeLevel=enmLevel.enmLitter ;
				if(this.rdbSnoozeSome.Checked==true)
					m_objNuclear.m_enmSnoozeLevel=enmLevel.enmSome;
				if(this.rdbSnoozeMany.Checked==true)
					m_objNuclear.m_enmSnoozeLevel=enmLevel.enmMany ;

				m_objNuclear.m_strSnoozeBeginMonth =this.txtSnoozeBeginMonth.Text.Trim();
				m_objNuclear.m_strSnoozeBeginYear=this.txtSnoozeBeginYear.Text.Trim();
			}
			else
			{
				m_objNuclear.m_enmSnoozeLevel=enmLevel.enmNone;
				m_objNuclear.m_strSnoozeBeginMonth ="";
				m_objNuclear.m_strSnoozeBeginYear="";
			}


			long m_lngRe ;
			//设置伴随症状的值
			string[] strGoWithSymptom;
			m_lngRe =this.m_lngGetCheckPartSelectionStrFromControl(6,out strGoWithSymptom,this.pnlGoWithSymptom);
			m_objNuclear.m_strGoWithSymptom=string.Join("",strGoWithSymptom);

			//睡眠行为
			string[] strSleep;
			m_lngRe=this.m_lngGetCheckPartSelectionStrFromControl(5,out strSleep,this.pnlSleep);
			m_objNuclear.m_strSleep=string.Join("",strSleep );

			//其他症状
			string[] strOther;
			m_lngRe=this.m_lngGetCheckPartSelectionStrFromControl(4,out strOther,this.pnlOther);
			m_objNuclear.m_strOther =string.Join("",strOther);


			//即往史
			string[] strDiseaseHistory;
			m_lngRe=this.m_lngGetCheckPartSelectionStrFromControl(10,out strDiseaseHistory,this.pnlDiseaseHistory);
			m_objNuclear.m_strDiseaseHistory=string.Join("",strDiseaseHistory);

			//头颈
			string[] strHeadNeck;
			m_lngRe=this.m_lngGetCheckPartSelectionStrFromControl(7,out strHeadNeck,this.pnlHeadNeck );
			m_objNuclear.m_strHeadNeck =string.Join("",strHeadNeck);


			m_objNuclear.m_strIrritability=txtIrritability.Text.Trim();
			m_objNuclear.m_strHeight=txtHeight.Text.Trim();
			m_objNuclear.m_strWeight=txtWeight.Text.Trim();
			m_objNuclear.m_strBloodPressure=txtBloodPressure.Text.Trim();
			m_objNuclear.m_strHeart=txtHeart.Text.Trim();
			m_objNuclear.m_strLung=txtLung.Text.Trim();
			m_objNuclear.m_strOtherPart=txtOtherPart.Text.Trim();
			m_objNuclear.m_strClinicalDiagnose=txtClinicalDiagnose.Text.Trim();
			m_objNuclear.m_strLastMedicines=txtLastMedicines.Text.Trim();
            //m_objNuclear.m_strRequesterSign  = ((clsEmployee)m_txtRequesterSign.Tag).m_StrEmployeeID;

			return m_objNuclear;
		}

		
		//将从数据库读取过来的由0，1组成的字符串赋给相应的CheckBox控件
		private long m_lngSetControlValFromCheckPartSelectionStr(string p_strCheckPartSelection,Panel pnlControl)
		{	
			try
			{	
				if (p_strCheckPartSelection!=null)
				{
					if (p_strCheckPartSelection.Length==0) 
						return 0;

					char[] m_CheckPartSelection=new char[p_strCheckPartSelection.Length ];

					m_CheckPartSelection=p_strCheckPartSelection.ToCharArray();

					//					Control objCheckBox;
					
					foreach(Control objCheckBox in pnlControl.Controls )
					{
						if (objCheckBox.GetType()==typeof(CheckBox))
						{
							bool mValue=false;
							if(m_CheckPartSelection[int.Parse((string)(objCheckBox.Tag))]=='1')
							{
								mValue=true;
								((CheckBox)objCheckBox).Checked=mValue;
							}
							
						}
						
					}

					return 1;
				}
				else
					return 0;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
				return 0;
			}


		}


		//将界面中的各个CHECKBOX框的值转化为用0,1表示的字符串

		private long m_lngGetCheckPartSelectionStrFromControl(int p_lngLength,out string[] p_strCheckPartSelection,Panel m_ctlPnl)
		{
			try
			{

				string[] m_strCheckPartSelection=new string[p_lngLength];
				for(int i=0;i<p_lngLength;i++)
					m_strCheckPartSelection[i]="0";
				
				//				Control objCheckBox;
				foreach(Control objCheckBox in m_ctlPnl.Controls)
				{
					if(objCheckBox.GetType()==typeof(CheckBox))
					{
						string mValue="0";
						if(((CheckBox)(objCheckBox)).Checked)
						{
							mValue="1";			    
							m_strCheckPartSelection[int.Parse((string)(objCheckBox.Tag))]=mValue;
						}
						
												
					}
				}
				p_strCheckPartSelection=m_strCheckPartSelection;
				return 1;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
				p_strCheckPartSelection=new string[10];
				return 0;
			}
			
		}

		private void m_mthClearUpSheet()
		{
			foreach(Control ctlTemp in this.Controls)
			{
				if(ctlTemp.GetType().Name=="Panel")
				{
					foreach(Control ctlSub in ctlTemp.Controls )
					{
						if(ctlSub.GetType().Name=="ctlBorderTextBox")
							ctlSub.Text="";
						if(ctlSub.GetType().Name=="CheckBox")
                            ((CheckBox)ctlSub).Checked=false;

						if(ctlSub.GetType().Name=="RadioButton")
							((RadioButton)ctlSub).Checked=false;
					}
				}

				if((ctlTemp.GetType().Name =="ctlBorderTextBox" || ctlTemp.GetType().Name=="RichTextBox" )&& ctlTemp.Name!="txtInPatientID" && ctlTemp.Name!="m_txtPatientName" && ctlTemp.Name!="m_txtBedNO")
					ctlTemp.Text="";
				else if(ctlTemp.GetType().Name=="ctlRichTextBox")
                    ((com.digitalwave.controls.ctlRichTextBox)ctlTemp).m_mthClearText();	
			

			}

			m_mthClear_Recursive(this.tabControl2,null);

			this.dtpRequestDate.Value=DateTime.Now;
			this.dtpBespeak.Value=DateTime.Now;
			this.dtpLastCheck.Value=DateTime.Now;
            dtpRequestDate.Enabled = true;

//			this.lblApplyDotorID.Text=MDIParent.OperatorName;
//			this.lblApplyDotorID.Tag=MDIParent.OperatorID;

            MDIParent.m_mthSetDefaulEmployee(m_txtRequesterSign);
		}

		private void frmNuclearOrder_Load(object sender, System.EventArgs e)
		{
            //m_lsvEmployee.Visible=false;
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			this.trvTime.SelectedNode=this.trvTime.Nodes[0];

			this.dtpRequestDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpRequestDate.m_mthResetSize();

			this.txtAddress.ReadOnly=true;
			this.txtVocation.ReadOnly=true;
			this.txtTelephone.ReadOnly=true;
		}


		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
//				this.m_txtParticular.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.m_txtClinic.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}		
		}


		private void NoseSnoreCheckedChange()
		{
			if(rdbNoseSnore.Checked==false)
			{
				this.rdbNoseSnoreLitter.Enabled=false;
				this.rdbNoseSnoreSome.Enabled=false;
				this.rdbNoseSnoreMany.Enabled=false;
				this.txtNoseSnoreBeginYear.Enabled=false;
				this.txtNoseSnoreBeginMonth.Enabled=false;

				this.rdbNoseSnoreLitter.Checked=false;
				this.rdbNoseSnoreSome.Checked=false;
				this.rdbNoseSnoreMany.Checked=false;

				this.txtNoseSnoreBeginYear.Text="";
				this.txtNoseSnoreBeginMonth.Text="";
			}
			else
			{
				this.rdbNoseSnoreLitter.Enabled=true;
				this.rdbNoseSnoreSome.Enabled=true;
				this.rdbNoseSnoreMany.Enabled=true;
				this.txtNoseSnoreBeginYear.Enabled=true;
				this.txtNoseSnoreBeginMonth.Enabled=true;

			}
		}

		private void rdbNoseSnore_CheckedChanged(object sender, System.EventArgs e)
		{
			NoseSnoreCheckedChange();
		}

		private void rdbNoNoseSnore_CheckedChanged(object sender, System.EventArgs e)
		{
			NoseSnoreCheckedChange();
		}

		private void SnoozeCheckedChange()
		{
			if(rdbSnooze.Checked==false)
			{
				this.rdbSnoozeLitter.Enabled=false;
				this.rdbSnoozeSome.Enabled=false;
				this.rdbSnoozeMany.Enabled=false;
				this.txtSnoozeBeginMonth.Enabled=false;
				this.txtSnoozeBeginYear.Enabled=false;
            
				this.rdbSnoozeLitter.Checked=false;
				this.rdbSnoozeSome.Checked=false;
				this.rdbSnoozeMany.Checked=false;

				this.txtSnoozeBeginMonth.Text="";
				this.txtSnoozeBeginYear.Text="";

			}
			else
			{
				this.rdbSnoozeLitter.Enabled=true;
				this.rdbSnoozeSome.Enabled=true;
				this.rdbSnoozeMany.Enabled=true;
				this.txtSnoozeBeginMonth.Enabled=true;
				this.txtSnoozeBeginYear.Enabled=true;
            	
			}
		}

		private void rdbSnooze_CheckedChanged(object sender, System.EventArgs e)
		{
			SnoozeCheckedChange();
		}

		private void rdbNoSnooze_CheckedChanged(object sender, System.EventArgs e)
		{
			SnoozeCheckedChange();
		}


		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objNuclear   =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpRequestDate.Enabled =true;
            if (this.trvTime.SelectedNode.Tag.ToString() != "0" && m_ObjCurrentEmrPatientSession != null)
			{
                Display(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), trvTime.SelectedNode.Tag.ToString());
				this.dtpRequestDate.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpRequestDate.Enabled =false;
				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpRequestDate.Value=DateTime.Now;
				//				this.lblApplyDotorID.Text=MDIParent.OperatorName;
				//				this.lblApplyDotorID.Tag=MDIParent.OperatorID;
				this.dtpRequestDate.Enabled =true;

				if(m_objCurrentPatient != null && txtInPatientID.Tag != null)
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
				}
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				
			}

			m_mthAddFormStatusForClosingSave();
		
		}

		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
//					
//					if(((Control)sender).Name=="m_lsvJY_ItemChoice")
//					{
//						
//						m_lsvJY_ItemChoice_DoubleClick(null,null);
//					}

			
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
					blnCanSearch =false;
					this.txtInPatientID.Text ="";
					blnCanSearch =true;
					this.txtAddress.Text="";
					this.txtTelephone.Text="";
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_mthReadOnly(false);
					m_objNuclear =null;
					m_objCurrentPatient=null;
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		
		private void m_mthReadOnly(bool blnIsReadOnly)
		{			
			foreach(Control ctlRichText in this.Controls )
			{
				string typeName = ctlRichText.GetType().Name;
				if(typeName =="CheckBox")
				{
					((CheckBox)ctlRichText).Enabled= ! blnIsReadOnly;
						 
				}
				else if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID" && 
						ctlRichText.Name!="m_txtBedNO" && ctlRichText.Name!="m_txtPatientName" && 
						ctlRichText.Name != "m_txtApplicationID" && ctlRichText.Name!="txtTelephone" &&
						ctlRichText.Name!="txtAddress" && ctlRichText.Name!="txtVocation")

					((ctlBorderTextBox)ctlRichText).ReadOnly=blnIsReadOnly;

				else if(typeName =="RichTextBox")
					((RichTextBox)ctlRichText).ReadOnly=blnIsReadOnly;
				else if(typeName =="ctlRichTextBox")
                    ((com.digitalwave.controls.ctlRichTextBox)ctlRichText).m_BlnReadOnly = blnIsReadOnly;
				
				blnCanDelete= ! blnIsReadOnly;
			}			
		}
       
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}

		
		#region 打印

		/*
		* DataSet : dsNuclearOrder
		* DataTable : dtNuclearOrder
		* 	DataColumn : BedNo(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : Vocation(string)
		* 	DataColumn : Telephone(string)
		* 	DataColumn : Address(string)
		* 	DataColumn : LastCheck(string)
		* 	DataColumn : RequestDate(string)
		* 	DataColumn : Bespeak(string)
		* 	DataColumn : Number(string)
		* 	DataColumn : MainDescription(string)
		* 	DataColumn : NoseSnoreBeginYear(string)
		* 	DataColumn : NoseSnoreBeginMonth(string)
		* 	DataColumn : SnoozeBeginYear(string)
		* 	DataColumn : SnoozeBeginMonth(string)
		* 	DataColumn : Height(string)
		* 	DataColumn : Weight(string)
		* 	DataColumn : BloodPressure(string)
		* 	DataColumn : Irritability(string)
		* 	DataColumn : Heart(string)
		* 	DataColumn : Lung(string)
		* 	DataColumn : OtherPart(string)
		* 	DataColumn : ClinicalDiagnose(string)
		* 	DataColumn : LastMedicines(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : NoseSnore(string)
		* 	DataColumn : NoNoseSnore(string)
		* 	DataColumn : NoseSnoreLitter(string)
		* 	DataColumn : NoseSnoreSome(string)
		* 	DataColumn : NoseSnoreMany(string)
		* 	DataColumn : Snooze(string)
		* 	DataColumn : NoSnooze(string)
		* 	DataColumn : SnoozeLitter(string)
		* 	DataColumn : SnoozeSome(string)
		* 	DataColumn : SnoozeMany(string)
		* 	DataColumn : GoWithSymptom1(string)
		* 	DataColumn : GoWithSymptom2(string)
		* 	DataColumn : GoWithSymptom3(string)
		* 	DataColumn : GoWithSymptom4(string)
		* 	DataColumn : GoWithSymptom5(string)
		* 	DataColumn : GoWithSymptom6(string)
		* 	DataColumn : Sleep1(string)
		* 	DataColumn : Sleep2(string)
		* 	DataColumn : Sleep3(string)
		* 	DataColumn : Sleep4(string)
		* 	DataColumn : Sleep5(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* 	DataColumn : DiseaseHistory1(string)
		* 	DataColumn : DiseaseHistory2(string)
		* 	DataColumn : DiseaseHistory3(string)
		* 	DataColumn : DiseaseHistory4(string)
		* 	DataColumn : DiseaseHistory5(string)
		* 	DataColumn : DiseaseHistory6(string)
		* 	DataColumn : DiseaseHistory7(string)
		* 	DataColumn : DiseaseHistory8(string)
		* 	DataColumn : DiseaseHistory9(string)
		* 	DataColumn : DiseaseHistory10(string)
		* 	DataColumn : HeadNeck1(string)
		* 	DataColumn : HeadNeck2(string)
		* 	DataColumn : HeadNeck3(string)
		* 	DataColumn : HeadNeck4(string)
		* 	DataColumn : HeadNeck5(string)
		* 	DataColumn : InPatientID(string)
		* DataTable : dtNuclearOrderEx
		* 	DataColumn : Field1(string)
		* 	DataColumn : Field2(string)
		* 	DataColumn : Field3(string)
		* 	DataColumn : Field4(string)
		* 	DataColumn : Field5(string)
		* 	DataColumn : Field6(string)
		* 	DataColumn : Field7(string)
		* 	DataColumn : Field8(string)
		* 	DataColumn : Field9(string)
		* 	DataColumn : Field10(string)
		* DataTable : Temp
		*/ 
		private DataSet m_dtsInitdsNuclearOrderDataSet()
		{
			DataSet dsdsNuclearOrder = new DataSet("dsNuclearOrder");

			DataTable dtdtNuclearOrder = new DataTable("dtNuclearOrder");

			DataColumn dcdtNuclearOrderBedNo = new DataColumn("BedNo",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderBedNo);

			DataColumn dcdtNuclearOrderPatientName = new DataColumn("PatientName",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderPatientName);

			DataColumn dcdtNuclearOrderPatientSex = new DataColumn("PatientSex",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderPatientSex);

			DataColumn dcdtNuclearOrderPatientAge = new DataColumn("PatientAge",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderPatientAge);

			DataColumn dcdtNuclearOrderVocation = new DataColumn("Vocation",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderVocation);

			DataColumn dcdtNuclearOrderTelephone = new DataColumn("Telephone",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderTelephone);

			DataColumn dcdtNuclearOrderAddress = new DataColumn("Address",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderAddress);

			DataColumn dcdtNuclearOrderLastCheck = new DataColumn("LastCheck",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderLastCheck);

			DataColumn dcdtNuclearOrderRequestDate = new DataColumn("RequestDate",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderRequestDate);

			DataColumn dcdtNuclearOrderBespeak = new DataColumn("Bespeak",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderBespeak);

			DataColumn dcdtNuclearOrderNumber = new DataColumn("Number",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNumber);

			DataColumn dcdtNuclearOrderMainDescription = new DataColumn("MainDescription",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderMainDescription);

			DataColumn dcdtNuclearOrderNoseSnoreBeginYear = new DataColumn("NoseSnoreBeginYear",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnoreBeginYear);

			DataColumn dcdtNuclearOrderNoseSnoreBeginMonth = new DataColumn("NoseSnoreBeginMonth",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnoreBeginMonth);

			DataColumn dcdtNuclearOrderSnoozeBeginYear = new DataColumn("SnoozeBeginYear",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnoozeBeginYear);

			DataColumn dcdtNuclearOrderSnoozeBeginMonth = new DataColumn("SnoozeBeginMonth",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnoozeBeginMonth);

			DataColumn dcdtNuclearOrderHeight = new DataColumn("Height",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeight);

			DataColumn dcdtNuclearOrderWeight = new DataColumn("Weight",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderWeight);

			DataColumn dcdtNuclearOrderBloodPressure = new DataColumn("BloodPressure",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderBloodPressure);

			DataColumn dcdtNuclearOrderIrritability = new DataColumn("Irritability",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderIrritability);

			DataColumn dcdtNuclearOrderHeart = new DataColumn("Heart",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeart);

			DataColumn dcdtNuclearOrderLung = new DataColumn("Lung",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderLung);

			DataColumn dcdtNuclearOrderOtherPart = new DataColumn("OtherPart",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderOtherPart);

			DataColumn dcdtNuclearOrderClinicalDiagnose = new DataColumn("ClinicalDiagnose",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderClinicalDiagnose);

			DataColumn dcdtNuclearOrderLastMedicines = new DataColumn("LastMedicines",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderLastMedicines);

			DataColumn dcdtNuclearOrderRequesterSign = new DataColumn("RequesterSign",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderRequesterSign);

			DataColumn dcdtNuclearOrderNoseSnore = new DataColumn("NoseSnore",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnore);

			DataColumn dcdtNuclearOrderNoNoseSnore = new DataColumn("NoNoseSnore",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoNoseSnore);

			DataColumn dcdtNuclearOrderNoseSnoreLitter = new DataColumn("NoseSnoreLitter",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnoreLitter);

			DataColumn dcdtNuclearOrderNoseSnoreSome = new DataColumn("NoseSnoreSome",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnoreSome);

			DataColumn dcdtNuclearOrderNoseSnoreMany = new DataColumn("NoseSnoreMany",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoseSnoreMany);

			DataColumn dcdtNuclearOrderSnooze = new DataColumn("Snooze",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnooze);

			DataColumn dcdtNuclearOrderNoSnooze = new DataColumn("NoSnooze",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderNoSnooze);

			DataColumn dcdtNuclearOrderSnoozeLitter = new DataColumn("SnoozeLitter",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnoozeLitter);

			DataColumn dcdtNuclearOrderSnoozeSome = new DataColumn("SnoozeSome",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnoozeSome);

			DataColumn dcdtNuclearOrderSnoozeMany = new DataColumn("SnoozeMany",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSnoozeMany);

			DataColumn dcdtNuclearOrderGoWithSymptom1 = new DataColumn("GoWithSymptom1",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom1);

			DataColumn dcdtNuclearOrderGoWithSymptom2 = new DataColumn("GoWithSymptom2",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom2);

			DataColumn dcdtNuclearOrderGoWithSymptom3 = new DataColumn("GoWithSymptom3",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom3);

			DataColumn dcdtNuclearOrderGoWithSymptom4 = new DataColumn("GoWithSymptom4",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom4);

			DataColumn dcdtNuclearOrderGoWithSymptom5 = new DataColumn("GoWithSymptom5",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom5);

			DataColumn dcdtNuclearOrderGoWithSymptom6 = new DataColumn("GoWithSymptom6",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderGoWithSymptom6);

			DataColumn dcdtNuclearOrderSleep1 = new DataColumn("Sleep1",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSleep1);

			DataColumn dcdtNuclearOrderSleep2 = new DataColumn("Sleep2",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSleep2);

			DataColumn dcdtNuclearOrderSleep3 = new DataColumn("Sleep3",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSleep3);

			DataColumn dcdtNuclearOrderSleep4 = new DataColumn("Sleep4",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSleep4);

			DataColumn dcdtNuclearOrderSleep5 = new DataColumn("Sleep5",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderSleep5);

			DataColumn dcdtNuclearOrderOther1 = new DataColumn("Other1",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderOther1);

			DataColumn dcdtNuclearOrderOther2 = new DataColumn("Other2",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderOther2);

			DataColumn dcdtNuclearOrderOther3 = new DataColumn("Other3",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderOther3);

			DataColumn dcdtNuclearOrderOther4 = new DataColumn("Other4",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderOther4);

			DataColumn dcdtNuclearOrderDiseaseHistory1 = new DataColumn("DiseaseHistory1",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory1);

			DataColumn dcdtNuclearOrderDiseaseHistory2 = new DataColumn("DiseaseHistory2",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory2);

			DataColumn dcdtNuclearOrderDiseaseHistory3 = new DataColumn("DiseaseHistory3",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory3);

			DataColumn dcdtNuclearOrderDiseaseHistory4 = new DataColumn("DiseaseHistory4",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory4);

			DataColumn dcdtNuclearOrderDiseaseHistory5 = new DataColumn("DiseaseHistory5",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory5);

			DataColumn dcdtNuclearOrderDiseaseHistory6 = new DataColumn("DiseaseHistory6",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory6);

			DataColumn dcdtNuclearOrderDiseaseHistory7 = new DataColumn("DiseaseHistory7",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory7);

			DataColumn dcdtNuclearOrderDiseaseHistory8 = new DataColumn("DiseaseHistory8",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory8);

			DataColumn dcdtNuclearOrderDiseaseHistory9 = new DataColumn("DiseaseHistory9",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory9);

			DataColumn dcdtNuclearOrderDiseaseHistory10 = new DataColumn("DiseaseHistory10",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderDiseaseHistory10);

			DataColumn dcdtNuclearOrderHeadNeck1 = new DataColumn("HeadNeck1",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeadNeck1);

			DataColumn dcdtNuclearOrderHeadNeck2 = new DataColumn("HeadNeck2",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeadNeck2);

			DataColumn dcdtNuclearOrderHeadNeck3 = new DataColumn("HeadNeck3",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeadNeck3);

			DataColumn dcdtNuclearOrderHeadNeck4 = new DataColumn("HeadNeck4",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeadNeck4);

			DataColumn dcdtNuclearOrderHeadNeck5 = new DataColumn("HeadNeck5",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderHeadNeck5);

			DataColumn dcdtNuclearOrderInPatientID = new DataColumn("InPatientID",typeof(string));

			dtdtNuclearOrder.Columns.Add(dcdtNuclearOrderInPatientID);

			dsdsNuclearOrder.Tables.Add(dtdtNuclearOrder);

			DataTable dtdtNuclearOrderEx = new DataTable("dtNuclearOrderEx");

			DataColumn dcdtNuclearOrderExField1 = new DataColumn("Field1",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField1);

			DataColumn dcdtNuclearOrderExField2 = new DataColumn("Field2",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField2);

			DataColumn dcdtNuclearOrderExField3 = new DataColumn("Field3",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField3);

			DataColumn dcdtNuclearOrderExField4 = new DataColumn("Field4",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField4);

			DataColumn dcdtNuclearOrderExField5 = new DataColumn("Field5",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField5);

			DataColumn dcdtNuclearOrderExField6 = new DataColumn("Field6",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField6);

			DataColumn dcdtNuclearOrderExField7 = new DataColumn("Field7",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField7);

			DataColumn dcdtNuclearOrderExField8 = new DataColumn("Field8",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField8);

			DataColumn dcdtNuclearOrderExField9 = new DataColumn("Field9",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField9);

			DataColumn dcdtNuclearOrderExField10 = new DataColumn("Field10",typeof(string));

			dtdtNuclearOrderEx.Columns.Add(dcdtNuclearOrderExField10);

			dsdsNuclearOrder.Tables.Add(dtdtNuclearOrderEx);

			return dsdsNuclearOrder;
		}

		/*
		* DataSet : dsNuclearOrder
		* DataTable : dtNuclearOrder
		* 	DataColumn : BedNo(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : Vocation(string)
		* 	DataColumn : Telephone(string)
		* 	DataColumn : Address(string)
		* 	DataColumn : LastCheck(string)
		* 	DataColumn : RequestDate(string)
		* 	DataColumn : Bespeak(string)
		* 	DataColumn : Number(string)
		* 	DataColumn : MainDescription(string)
		* 	DataColumn : NoseSnoreBeginYear(string)
		* 	DataColumn : NoseSnoreBeginMonth(string)
		* 	DataColumn : SnoozeBeginYear(string)
		* 	DataColumn : SnoozeBeginMonth(string)
		* 	DataColumn : Height(string)
		* 	DataColumn : Weight(string)
		* 	DataColumn : BloodPressure(string)
		* 	DataColumn : Irritability(string)
		* 	DataColumn : Heart(string)
		* 	DataColumn : Lung(string)
		* 	DataColumn : OtherPart(string)
		* 	DataColumn : ClinicalDiagnose(string)
		* 	DataColumn : LastMedicines(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : NoseSnore(string)
		* 	DataColumn : NoNoseSnore(string)
		* 	DataColumn : NoseSnoreLitter(string)
		* 	DataColumn : NoseSnoreSome(string)
		* 	DataColumn : NoseSnoreMany(string)
		* 	DataColumn : Snooze(string)
		* 	DataColumn : NoSnooze(string)
		* 	DataColumn : SnoozeLitter(string)
		* 	DataColumn : SnoozeSome(string)
		* 	DataColumn : SnoozeMany(string)
		* 	DataColumn : GoWithSymptom1(string)
		* 	DataColumn : GoWithSymptom2(string)
		* 	DataColumn : GoWithSymptom3(string)
		* 	DataColumn : GoWithSymptom4(string)
		* 	DataColumn : GoWithSymptom5(string)
		* 	DataColumn : GoWithSymptom6(string)
		* 	DataColumn : Sleep1(string)
		* 	DataColumn : Sleep2(string)
		* 	DataColumn : Sleep3(string)
		* 	DataColumn : Sleep4(string)
		* 	DataColumn : Sleep5(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* 	DataColumn : DiseaseHistory1(string)
		* 	DataColumn : DiseaseHistory2(string)
		* 	DataColumn : DiseaseHistory3(string)
		* 	DataColumn : DiseaseHistory4(string)
		* 	DataColumn : DiseaseHistory5(string)
		* 	DataColumn : DiseaseHistory6(string)
		* 	DataColumn : DiseaseHistory7(string)
		* 	DataColumn : DiseaseHistory8(string)
		* 	DataColumn : DiseaseHistory9(string)
		* 	DataColumn : DiseaseHistory10(string)
		* 	DataColumn : HeadNeck1(string)
		* 	DataColumn : HeadNeck2(string)
		* 	DataColumn : HeadNeck3(string)
		* 	DataColumn : HeadNeck4(string)
		* 	DataColumn : HeadNeck5(string)
		* 	DataColumn : InPatientID(string)
		* DataTable : dtNuclearOrderEx
		* 	DataColumn : Field1(string)
		* 	DataColumn : Field2(string)
		* 	DataColumn : Field3(string)
		* 	DataColumn : Field4(string)
		* 	DataColumn : Field5(string)
		* 	DataColumn : Field6(string)
		* 	DataColumn : Field7(string)
		* 	DataColumn : Field8(string)
		* 	DataColumn : Field9(string)
		* 	DataColumn : Field10(string)
		* DataTable : Temp
		*/ 
		private void m_mthAddNewDataFordsNuclearOrderDataSet(DataSet dsdsNuclearOrder)
		{
			DataTable dtdtNuclearOrder = dsdsNuclearOrder.Tables["DTNUCLEARORDER"];
			dtdtNuclearOrder.Rows.Clear();

			object [] objdtNuclearOrderDatas = new object[67];

			if(m_objNuclear!=null && m_objCurrentPatient!=null)
			{
                if (m_ObjCurrentBed != null)
                {
                    objdtNuclearOrderDatas[0] = m_ObjCurrentBed.m_strCODE_CHR;
                }
                else
                {
                    objdtNuclearOrderDatas[0] = string.Empty;
                }
			objdtNuclearOrderDatas[1] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;
			objdtNuclearOrderDatas[2] =  m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
			objdtNuclearOrderDatas[3] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
			objdtNuclearOrderDatas[4] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation ;
			objdtNuclearOrderDatas[5] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
			objdtNuclearOrderDatas[6] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress  ;
			objdtNuclearOrderDatas[7] =DateTime.Parse(m_objNuclear.m_strLastCheck).ToString("yyyy年MM月dd日");
			objdtNuclearOrderDatas[8] = DateTime.Parse(m_objNuclear.m_strRequestDate).ToString("yyyy年MM月dd日 HH:mm");
			objdtNuclearOrderDatas[9] = DateTime.Parse(m_objNuclear.m_strBespeak).ToString("yyyy年MM月dd日 HH时mm分");
			objdtNuclearOrderDatas[10] = m_objNuclear.m_strNumber ;
			objdtNuclearOrderDatas[11] = m_objNuclear.m_strMainDescription ;
			objdtNuclearOrderDatas[12] = m_objNuclear.m_strNoseSnoreBeginYear  ;
			objdtNuclearOrderDatas[13] = m_objNuclear.m_strNoseSnoreBeginMonth ;
			objdtNuclearOrderDatas[14] = m_objNuclear.m_strSnoozeBeginYear ;
			objdtNuclearOrderDatas[15] = m_objNuclear.m_strSnoozeBeginMonth ;
			objdtNuclearOrderDatas[16] = m_objNuclear.m_strHeight ;
			objdtNuclearOrderDatas[17] = m_objNuclear.m_strWeight ;
			objdtNuclearOrderDatas[18] = m_objNuclear.m_strBloodPressure ;
			objdtNuclearOrderDatas[19] = m_objNuclear.m_strIrritability ;
			objdtNuclearOrderDatas[20] = m_objNuclear.m_strHeart  ;
			objdtNuclearOrderDatas[21] = m_objNuclear.m_strLung ;
			objdtNuclearOrderDatas[22] = m_objNuclear.m_strOtherPart ;
			objdtNuclearOrderDatas[23] = m_objNuclear.m_strClinicalDiagnose ;
			objdtNuclearOrderDatas[24] = m_objNuclear.m_strLastMedicines  ;
			objdtNuclearOrderDatas[25] = m_txtRequesterSign.Text;
			objdtNuclearOrderDatas[26] = (m_objNuclear.m_blnIsNoseSnore ? "√" : "");
			objdtNuclearOrderDatas[27] = (!m_objNuclear.m_blnIsNoseSnore ? "√" : "");
			objdtNuclearOrderDatas[28] = (m_objNuclear.m_enmNoseSnoreLevel==enmLevel.enmLitter ? "√" : "");
			objdtNuclearOrderDatas[29] = (m_objNuclear.m_enmNoseSnoreLevel==enmLevel.enmSome  ? "√" : "");
			objdtNuclearOrderDatas[30] = (m_objNuclear.m_enmNoseSnoreLevel==enmLevel.enmMany  ? "√" : "");
			objdtNuclearOrderDatas[31] =(m_objNuclear.m_blnIsSnooze ? "√" : "");
			objdtNuclearOrderDatas[32] = (!m_objNuclear.m_blnIsSnooze ? "√" : "");
			objdtNuclearOrderDatas[33] = (m_objNuclear.m_enmSnoozeLevel==enmLevel.enmLitter  ? "√" : "");
			objdtNuclearOrderDatas[34] = (m_objNuclear.m_enmSnoozeLevel==enmLevel.enmSome  ? "√" : "");
			objdtNuclearOrderDatas[35] = (m_objNuclear.m_enmSnoozeLevel==enmLevel.enmMany  ? "√" : "");
			objdtNuclearOrderDatas[36] = (m_objNuclear.m_strGoWithSymptom[0]=='1' ? "√" : "");
			objdtNuclearOrderDatas[37] = (m_objNuclear.m_strGoWithSymptom[1]=='1' ? "√" : "");
			objdtNuclearOrderDatas[38] = (m_objNuclear.m_strGoWithSymptom[2]=='1' ? "√" : "");
			objdtNuclearOrderDatas[39] = (m_objNuclear.m_strGoWithSymptom[3]=='1' ? "√" : "");
			objdtNuclearOrderDatas[40] = (m_objNuclear.m_strGoWithSymptom[4]=='1' ? "√" : "");
			objdtNuclearOrderDatas[41] = (m_objNuclear.m_strGoWithSymptom[5]=='1' ? "√" : "");
			objdtNuclearOrderDatas[42] = (m_objNuclear.m_strSleep[0]=='1' ? "√" : "");
			objdtNuclearOrderDatas[43] = (m_objNuclear.m_strSleep[1]=='1' ? "√" : "");
			objdtNuclearOrderDatas[44] = (m_objNuclear.m_strSleep[2]=='1' ? "√" : "");
			objdtNuclearOrderDatas[45] = (m_objNuclear.m_strSleep[3]=='1' ? "√" : "");
			objdtNuclearOrderDatas[46] = (m_objNuclear.m_strSleep[4]=='1' ? "√" : "");
			objdtNuclearOrderDatas[47] = (m_objNuclear.m_strOther[0]=='1' ? "√" : "");
			objdtNuclearOrderDatas[48] = (m_objNuclear.m_strOther[1]=='1' ? "√" : "");
			objdtNuclearOrderDatas[49] = (m_objNuclear.m_strOther[2]=='1' ? "√" : "");
			objdtNuclearOrderDatas[50] = (m_objNuclear.m_strOther[3]=='1' ? "√" : "");
			objdtNuclearOrderDatas[51] = (m_objNuclear.m_strDiseaseHistory[0]=='1' ? "√" : "");
			objdtNuclearOrderDatas[52] = (m_objNuclear.m_strDiseaseHistory[1]=='1' ? "√" : "");
			objdtNuclearOrderDatas[53] = (m_objNuclear.m_strDiseaseHistory[2]=='1' ? "√" : "");
			objdtNuclearOrderDatas[54] = (m_objNuclear.m_strDiseaseHistory[3]=='1' ? "√" : "");
			objdtNuclearOrderDatas[55] = (m_objNuclear.m_strDiseaseHistory[4]=='1' ? "√" : "");
			objdtNuclearOrderDatas[56] = (m_objNuclear.m_strDiseaseHistory[5]=='1' ? "√" : "");
			objdtNuclearOrderDatas[57] = (m_objNuclear.m_strDiseaseHistory[6]=='1' ? "√" : "");
			objdtNuclearOrderDatas[58] = (m_objNuclear.m_strDiseaseHistory[7]=='1' ? "√" : "");
			objdtNuclearOrderDatas[59] = (m_objNuclear.m_strDiseaseHistory[8]=='1' ? "√" : "");
			objdtNuclearOrderDatas[60] = (m_objNuclear.m_strDiseaseHistory[9]=='1' ? "√" : "");
			objdtNuclearOrderDatas[61] = (m_objNuclear.m_strHeadNeck[0]=='1' ? "√" : "");
			objdtNuclearOrderDatas[62] = (m_objNuclear.m_strHeadNeck[1]=='1' ? "√" : "");
			objdtNuclearOrderDatas[63] = (m_objNuclear.m_strHeadNeck[2]=='1' ? "√" : "");
			objdtNuclearOrderDatas[64] = (m_objNuclear.m_strHeadNeck[3]=='1' ? "√" : "");
			objdtNuclearOrderDatas[65] = (m_objNuclear.m_strHeadNeck[4]=='1' ? "√" : "");
            if (m_ObjCurrentEmrPatientSession != null)
            {
                objdtNuclearOrderDatas[66] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
            }
            else
            {
                objdtNuclearOrderDatas[66] = string.Empty;
            }
			}
			else 
			{
				for(int i=0;i<objdtNuclearOrderDatas.Length-1;i++)
					objdtNuclearOrderDatas[i]="";
			}

			dtdtNuclearOrder.Rows.Add(objdtNuclearOrderDatas);
			
			
			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();
			DataTable dtdtNuclearOrderEx = dsdsNuclearOrder.Tables["DTNUCLEARORDEREX"];
			dtdtNuclearOrderEx.Rows.Clear();

			object [] objdtNuclearOrderExDatas = new object[10];
			
			if(m_objNuclear!=null && m_objCurrentPatient!=null)
			{
				objdtNuclearOrderExDatas[0] =(m_objNuclear.m_strHeadNeck[5]=='1' ? "√" : "") ;
				objdtNuclearOrderExDatas[1] =(m_objNuclear.m_strHeadNeck[6]=='1' ? "√" : "") ;
				objdtNuclearOrderExDatas[2] =m_objNuclear.m_strHeadNeckOther;
				objdtNuclearOrderExDatas[3] = "";
				objdtNuclearOrderExDatas[4] = "";
				objdtNuclearOrderExDatas[5] = "";
				objdtNuclearOrderExDatas[6] = "";
				objdtNuclearOrderExDatas[7] = "";
				objdtNuclearOrderExDatas[8] = "";
				objdtNuclearOrderExDatas[9] = "";
			}
			dtdtNuclearOrderEx.Rows.Add(objdtNuclearOrderExDatas);


			m_rpdOrderRept.Database.Tables["DTNUCLEARORDER"].SetDataSource(dsdsNuclearOrder);

			m_rpdOrderRept.Refresh();

			//.Database.Tables["DTNUCLEARORDEREX"].SetDataSource(dtdtNuclearOrderEx);

			//.Refresh();

			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();
//			DataTable dtTemp = dsdsNuclearOrder.Tables["TEMP"];
//			//dtTemp.Rows.Clear();
//
//			object [] objTempDatas = new object[0];
//
//			dtTemp.Rows.Add(objTempDatas);
//			//.Database.Tables["TEMP"].SetDataSource(dtTemp);

			//.Refresh();

			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();
		}
		#endregion

		private void lblDept_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboDept_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_cboArea_Load(object sender, System.EventArgs e)
		{
		
		}

		private void lblAreaTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void dtpBespeak_Load(object sender, System.EventArgs e)
		{
		
		}

		private void dtpLastCheck_Load(object sender, System.EventArgs e)
		{
		
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthClearUpSheet();

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objCurrentPatient = m_objBaseCurrentPatient;

            m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllTimeOfAPatient(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }
	}
}

