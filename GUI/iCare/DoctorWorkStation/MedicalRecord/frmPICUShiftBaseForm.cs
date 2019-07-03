//#define Debug

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing ;

using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility.Controls;
using iCareData;
using System.Xml;
using com.digitalwave.DepartmentManagerService;
using iCare.ICU.Espial;

namespace iCare
{
	public class frmPICUShiftBaseForm : iCare.frmHRPBaseForm,PublicFunction//,infAutoTest
	{
		#region 界面控件
		protected System.Windows.Forms.Label m_lblAddress;
		protected System.Windows.Forms.Label lblAddress;
		protected System.Windows.Forms.Label lblInPatientDate;
		protected System.Windows.Forms.Label lblInDiagnose;
		protected System.Windows.Forms.Label lblOperationName;
		protected System.Windows.Forms.Label lblAnaesthesiaType;
		protected System.Windows.Forms.Label m_lblTurnBaseDept;
		protected System.Windows.Forms.Label m_lblTurnTime;
		protected System.Windows.Forms.Label lblTurnDiagnose;
		protected System.Windows.Forms.Label lblInDiagnoseCourse;
		protected com.digitalwave.controls.ctlRichTextBox m_txtInDiagnoseCourse;
		protected com.digitalwave.controls.ctlRichTextBox m_txtInDiagnose;
		protected com.digitalwave.controls.ctlRichTextBox m_txtAnaesthesiaType;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOperationName;
		protected com.digitalwave.controls.ctlRichTextBox m_txtTurnDiagnose;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTurnTime;
		protected System.Windows.Forms.Label m_lblTurnInfo;
		protected System.Windows.Forms.Label lblTemperature;
		protected com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		protected System.Windows.Forms.Label lblTemperatureUnit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		protected System.Windows.Forms.Label lblPulseUnit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSystolic;
		protected System.Windows.Forms.Label lblPressureSeperate;
		protected com.digitalwave.controls.ctlRichTextBox m_txtDiastolic;
		protected System.Windows.Forms.Label lblPressureUnit;
		protected System.Windows.Forms.Label lblPulse;
		protected System.Windows.Forms.Label lblPressure;
		protected System.Windows.Forms.Label lblMind;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMind;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPupilDiameterRight;
		protected System.Windows.Forms.Label lblPupilDiameter2;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPupilDiameterLeft;
		protected System.Windows.Forms.Label lblPupilDiameterUnit;
		protected System.Windows.Forms.Label lblPupilReflection1;
		protected System.Windows.Forms.Label lblPupilReflection2;
		protected System.Windows.Forms.Label lblPupilDiameter1;
		protected System.Windows.Forms.Label lblGlasgow1;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPupilReflectionRight;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPupilReflectionLeft;
		protected com.digitalwave.controls.ctlRichTextBox m_txtGlasgowValue;
		protected com.digitalwave.controls.ctlRichTextBox m_txtGlasgowOpenEye;
		protected System.Windows.Forms.Label lblGlasgow2;
		protected System.Windows.Forms.Label lblGlasgow3;
		protected com.digitalwave.controls.ctlRichTextBox m_txtGlasgowLanguage;
		protected com.digitalwave.controls.ctlRichTextBox m_txtGlasgowSport;
		protected System.Windows.Forms.Label lblGlasgow4;
		protected System.Windows.Forms.Label lblGlasgow5;
		protected com.digitalwave.controls.ctlRichTextBox m_txtOther;
		protected System.Windows.Forms.Label lblNewLabReport;
		protected System.Windows.Forms.Label lblHBUnit;
		protected System.Windows.Forms.Label lblHB;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHB;
		protected System.Windows.Forms.Label lblRBCUnit;
		protected System.Windows.Forms.Label lblRBC;
		protected com.digitalwave.controls.ctlRichTextBox m_txtRBC;
		protected System.Windows.Forms.Label lblRBCExp;
		protected System.Windows.Forms.Label lblWBC;
		protected com.digitalwave.controls.ctlRichTextBox m_txtWBC;
		protected System.Windows.Forms.Label lblWBCUnit;
		protected System.Windows.Forms.Label lblWBCExp;
		protected System.Windows.Forms.Label lblLeukocyteType;
		protected System.Windows.Forms.Label LymphocyteUnit;
		protected System.Windows.Forms.Label lblLymphocyte;
		protected com.digitalwave.controls.ctlRichTextBox m_txtLymphocyte;
		protected System.Windows.Forms.Label lblBandLeukocyte;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBandLeukocyte;
		protected System.Windows.Forms.Label lblBandLeukocyteUnit;
		protected System.Windows.Forms.Label lblDispartLeftLeukocyteUnit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtDispartLeftLeukocyte;
		protected System.Windows.Forms.Label lblAcidophil;
		protected com.digitalwave.controls.ctlRichTextBox m_txtAcidophil;
		protected System.Windows.Forms.Label lblAcidophilUnit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBasophil;
		protected System.Windows.Forms.Label lblBasophilUnit;
		protected System.Windows.Forms.Label lblBasophil;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBloodK;
		protected System.Windows.Forms.Label lblBloodKUnit;
		protected System.Windows.Forms.Label lblBloodK;
		protected System.Windows.Forms.Label lblBloodNaUnit;
		protected System.Windows.Forms.Label lblBloodNa;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBloodNa;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBloodCl;
		protected System.Windows.Forms.Label lblBloodClUnit;
		protected System.Windows.Forms.Label lblBloodCl;
		protected System.Windows.Forms.Label lblBloodSugarUnit;
		protected System.Windows.Forms.Label lblBloodSugar;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBloodSugar;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBloodCa;
		protected System.Windows.Forms.Label lblBUNUnit;
		protected System.Windows.Forms.Label lblBUN;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBUN;
		protected System.Windows.Forms.Label lblBloodCaUnit;
		protected System.Windows.Forms.Label lblBloodCa;
		protected System.Windows.Forms.Label lblBloodAnalyse;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPH;
		protected System.Windows.Forms.Label lblPH;
		protected System.Windows.Forms.Label lblPaO2Unit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPaO2;
		protected System.Windows.Forms.Label lblPaO2;
		protected System.Windows.Forms.Label lblPaCO2Unit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPaCO2;
		protected System.Windows.Forms.Label lblPaCO2;
		protected System.Windows.Forms.Label lblHCO3;
		protected System.Windows.Forms.Label lblHCO3Unit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHCO3;
		protected com.digitalwave.controls.ctlRichTextBox m_txtWoundInfo;
		protected System.Windows.Forms.Label lblWoundInfo;
		protected System.Windows.Forms.Label lblFromDeptDoctor;
		protected System.Windows.Forms.Label lblToDeptDoctor;
		protected System.Windows.Forms.Label lblDispartLeftLeukocyte;
		protected System.Windows.Forms.Label lblHeartRate;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHeartRate;
		protected System.Windows.Forms.Label lblHeartRateUnit;
		protected System.Windows.Forms.Label lblMonocyte;
		protected com.digitalwave.controls.ctlRichTextBox m_txtMonocyte;
		protected System.Windows.Forms.Label lblMonocyteUnit;
		protected System.Windows.Forms.Label m_lblTurnBaseDeptName;
		protected System.Windows.Forms.Label m_lblInPatientDate;
		protected System.Windows.Forms.Label m_lblToDeptDoctor;
		protected System.Windows.Forms.Label m_lblFromDeptDoctor;
		protected System.Windows.Forms.TreeView m_trvTime;
		protected System.Drawing.Printing.PrintDocument m_pdcRecord;
		protected System.Windows.Forms.PrintPreviewDialog m_ppdRecord;
		protected System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		protected System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label lblBEUnit;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBE;
		protected System.Windows.Forms.TreeView m_trvLabCheckSendTime;
		private PinkieControls.ButtonXP m_cmdSetLabCheckResult;
		private PinkieControls.ButtonXP m_cmdGetDovueData;
		private System.Windows.Forms.ListView m_lsvJY_ItemChoice;
		private System.Windows.Forms.ColumnHeader clmPat_c_name;
		private System.Windows.Forms.ColumnHeader clmSendDate;
		protected System.Windows.Forms.Label lblPltTilte;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPlt;
		protected System.Windows.Forms.Label lblPltTitle2;
		protected System.Windows.Forms.Label lblPltTitle3;
		private System.Windows.Forms.Label lblEmployeeSign;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		private System.ComponentModel.IContainer components = null;

		#endregion 界面控件
		public Crownwood.Magic.Controls.TabControl tabControl1;
		public Crownwood.Magic.Controls.TabPage tabPage1;
		public Crownwood.Magic.Controls.TabPage tabPage2;
		public Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.ImageList imageList1;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpGetDataTime;
		protected PinkieControls.ButtonXP m_cmdFromDoctor;
        protected TextBox txtFromDoctor;
        protected com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		protected string[] strDeptArr;
		public frmPICUShiftBaseForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            intFormType = 1;
			m_trvTime.HideSelection=false;
			// TODO: Add any initialization after the InitializeComponent call
			
			m_cboArea.Visible = false;
			lblAreaTitle.Visible = false;
			m_txtBedNO.Visible = false;
			lblBedNoTitle.Visible = false;

			m_lsvInPatientID.Visible = false;
			m_trnTimeRoot = new TreeNode("记录日期");
			m_trvTime.Nodes.Add(m_trnTimeRoot);

			//m_objBorderTool.m_mthChangedControlBorder(m_trvLabCheckSendTime);
			m_trnLabCheckSendTimeRoot = new TreeNode("实验室检验送检日期");
			m_trvLabCheckSendTime.Nodes.Add(m_trnLabCheckSendTimeRoot);

			m_objPrintLineContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  new clsPrintPatientFixInfo(),
										  new clsPrintPatientInDiagnoseInfo(),
										  new clsPrintPatientInDiagnoseCourseInfo(),
										  new clsPrintPatientCheckInfo(),
										  new clsPrintPatientOtherInfo(),
										  new clsPrintPatientLabReportInfo(),
										  new clsPrintPatientSignInfo()
									  });

			//	m_mthSetRichTextBoxAttribInControl(this);
			//			if(c_objLabCheckAliasArr ==null)
			//				m_objDomain_Lab.m_lngGetAllLabCheckAlias(out c_objLabCheckAliasArr);

		}

		//		/// <summary>
		//		/// 检验结果别名数组
		//		/// </summary>
		//		public static clsPublicIDAndName[] c_objLabCheckAliasArr=null; 


		protected clsPICUShiftInfo m_objCurrentShiftInfo;
		protected bool m_blnCanTreeNodeAfterSelectEventTakePlace=true;

		/// <summary>
		/// 边框颜色工具
		/// </summary>
        //protected clsBorderTool m_objBorderTool;

		/// <summary>
		/// 记录日期的树结点
		/// </summary>
		protected TreeNode m_trnTimeRoot;

		/// <summary>
		/// 实验室检验送检日期的树结点
		/// </summary>
		protected TreeNode m_trnLabCheckSendTimeRoot;

		/// <summary>
		/// PICU科室的ID，用来判断当前登录者是否PICU的员工。
		/// </summary>
		protected string m_strPICUDeptID = "1560000";

		/// <summary>
		/// 打印一行的内容
		/// </summary>
		private clsPrintContext m_objPrintLineContext;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPICUShiftBaseForm));
            this.m_lblAddress = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblInPatientDate = new System.Windows.Forms.Label();
            this.lblInDiagnose = new System.Windows.Forms.Label();
            this.lblOperationName = new System.Windows.Forms.Label();
            this.lblAnaesthesiaType = new System.Windows.Forms.Label();
            this.m_lblTurnBaseDept = new System.Windows.Forms.Label();
            this.m_lblTurnTime = new System.Windows.Forms.Label();
            this.lblTurnDiagnose = new System.Windows.Forms.Label();
            this.lblInDiagnoseCourse = new System.Windows.Forms.Label();
            this.m_txtInDiagnoseCourse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblTurnInfo = new System.Windows.Forms.Label();
            this.m_txtInDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAnaesthesiaType = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOperationName = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtTurnDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_dtpTurnTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTemperatureUnit = new System.Windows.Forms.Label();
            this.lblHeartRate = new System.Windows.Forms.Label();
            this.m_txtHeartRate = new com.digitalwave.controls.ctlRichTextBox();
            this.lblHeartRateUnit = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPulseUnit = new System.Windows.Forms.Label();
            this.m_txtSystolic = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPressureSeperate = new System.Windows.Forms.Label();
            this.m_txtDiastolic = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPressureUnit = new System.Windows.Forms.Label();
            this.lblPulse = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblMind = new System.Windows.Forms.Label();
            this.m_txtMind = new com.digitalwave.controls.ctlRichTextBox();
            this.lblGlasgow1 = new System.Windows.Forms.Label();
            this.m_txtPupilDiameterRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilDiameter2 = new System.Windows.Forms.Label();
            this.m_txtPupilDiameterLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilDiameterUnit = new System.Windows.Forms.Label();
            this.lblPupilReflection1 = new System.Windows.Forms.Label();
            this.m_txtPupilReflectionRight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPupilReflectionLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilReflection2 = new System.Windows.Forms.Label();
            this.m_txtGlasgowValue = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtGlasgowOpenEye = new com.digitalwave.controls.ctlRichTextBox();
            this.lblGlasgow2 = new System.Windows.Forms.Label();
            this.lblGlasgow3 = new System.Windows.Forms.Label();
            this.m_txtGlasgowLanguage = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtGlasgowSport = new com.digitalwave.controls.ctlRichTextBox();
            this.lblGlasgow4 = new System.Windows.Forms.Label();
            this.lblGlasgow5 = new System.Windows.Forms.Label();
            this.lblPupilDiameter1 = new System.Windows.Forms.Label();
            this.m_txtOther = new com.digitalwave.controls.ctlRichTextBox();
            this.lblNewLabReport = new System.Windows.Forms.Label();
            this.lblHBUnit = new System.Windows.Forms.Label();
            this.lblHB = new System.Windows.Forms.Label();
            this.m_txtHB = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRBCUnit = new System.Windows.Forms.Label();
            this.lblRBC = new System.Windows.Forms.Label();
            this.m_txtRBC = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRBCExp = new System.Windows.Forms.Label();
            this.lblWBC = new System.Windows.Forms.Label();
            this.m_txtWBC = new com.digitalwave.controls.ctlRichTextBox();
            this.lblWBCUnit = new System.Windows.Forms.Label();
            this.lblWBCExp = new System.Windows.Forms.Label();
            this.lblLeukocyteType = new System.Windows.Forms.Label();
            this.LymphocyteUnit = new System.Windows.Forms.Label();
            this.lblLymphocyte = new System.Windows.Forms.Label();
            this.m_txtLymphocyte = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBandLeukocyte = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBandLeukocyteUnit = new System.Windows.Forms.Label();
            this.lblBandLeukocyte = new System.Windows.Forms.Label();
            this.lblDispartLeftLeukocyteUnit = new System.Windows.Forms.Label();
            this.m_txtDispartLeftLeukocyte = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMonocyte = new System.Windows.Forms.Label();
            this.m_txtMonocyte = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMonocyteUnit = new System.Windows.Forms.Label();
            this.lblAcidophil = new System.Windows.Forms.Label();
            this.m_txtAcidophil = new com.digitalwave.controls.ctlRichTextBox();
            this.lblAcidophilUnit = new System.Windows.Forms.Label();
            this.m_txtBasophil = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBasophilUnit = new System.Windows.Forms.Label();
            this.lblBasophil = new System.Windows.Forms.Label();
            this.m_txtBloodK = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodKUnit = new System.Windows.Forms.Label();
            this.lblBloodK = new System.Windows.Forms.Label();
            this.lblBloodNaUnit = new System.Windows.Forms.Label();
            this.lblBloodNa = new System.Windows.Forms.Label();
            this.m_txtBloodNa = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodCl = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodClUnit = new System.Windows.Forms.Label();
            this.lblBloodCl = new System.Windows.Forms.Label();
            this.lblBloodSugarUnit = new System.Windows.Forms.Label();
            this.lblBloodSugar = new System.Windows.Forms.Label();
            this.m_txtBloodSugar = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodCa = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBUNUnit = new System.Windows.Forms.Label();
            this.lblBUN = new System.Windows.Forms.Label();
            this.m_txtBUN = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodCaUnit = new System.Windows.Forms.Label();
            this.lblBloodCa = new System.Windows.Forms.Label();
            this.lblBloodAnalyse = new System.Windows.Forms.Label();
            this.m_txtPH = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPH = new System.Windows.Forms.Label();
            this.lblPaO2Unit = new System.Windows.Forms.Label();
            this.m_txtPaO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPaO2 = new System.Windows.Forms.Label();
            this.lblPaCO2Unit = new System.Windows.Forms.Label();
            this.m_txtPaCO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPaCO2 = new System.Windows.Forms.Label();
            this.lblHCO3 = new System.Windows.Forms.Label();
            this.lblHCO3Unit = new System.Windows.Forms.Label();
            this.m_txtHCO3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtWoundInfo = new com.digitalwave.controls.ctlRichTextBox();
            this.lblWoundInfo = new System.Windows.Forms.Label();
            this.lblFromDeptDoctor = new System.Windows.Forms.Label();
            this.lblToDeptDoctor = new System.Windows.Forms.Label();
            this.lblDispartLeftLeukocyte = new System.Windows.Forms.Label();
            this.m_lblTurnBaseDeptName = new System.Windows.Forms.Label();
            this.m_lblInPatientDate = new System.Windows.Forms.Label();
            this.m_lblToDeptDoctor = new System.Windows.Forms.Label();
            this.m_lblFromDeptDoctor = new System.Windows.Forms.Label();
            this.m_trvTime = new System.Windows.Forms.TreeView();
            this.m_pdcRecord = new System.Drawing.Printing.PrintDocument();
            this.m_ppdRecord = new System.Windows.Forms.PrintPreviewDialog();
            this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBEUnit = new System.Windows.Forms.Label();
            this.m_txtBE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_trvLabCheckSendTime = new System.Windows.Forms.TreeView();
            this.m_cmdSetLabCheckResult = new PinkieControls.ButtonXP();
            this.m_cmdGetDovueData = new PinkieControls.ButtonXP();
            this.m_lsvJY_ItemChoice = new System.Windows.Forms.ListView();
            this.clmPat_c_name = new System.Windows.Forms.ColumnHeader();
            this.clmSendDate = new System.Windows.Forms.ColumnHeader();
            this.lblPltTilte = new System.Windows.Forms.Label();
            this.m_txtPlt = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPltTitle2 = new System.Windows.Forms.Label();
            this.lblPltTitle3 = new System.Windows.Forms.Label();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_dtpGetDataTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_cmdFromDoctor = new PinkieControls.ButtonXP();
            this.txtFromDoctor = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(288, 150);
            this.lblSex.Size = new System.Drawing.Size(28, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(284, 136);
            this.lblAge.Size = new System.Drawing.Size(28, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(253, 138);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(264, 138);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(278, 152);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(264, 155);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(264, 136);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(245, 152);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(228, 142);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(84, 104);
            this.m_lsvInPatientID.TabIndex = 2;
            this.m_lsvInPatientID.Visible = false;
            this.m_lsvInPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(263, 126);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.TabIndex = 1;
            this.txtInPatientID.Visible = false;
            this.txtInPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(260, 126);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(256, 138);
            this.m_txtBedNO.Size = new System.Drawing.Size(60, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(236, 126);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(274, 106);
            this.m_lsvPatientName.Size = new System.Drawing.Size(68, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(236, 106);
            this.m_lsvBedNO.Size = new System.Drawing.Size(84, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(236, 126);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(226, 138);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(248, 155);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(288, 131);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(256, 128);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(281, 116);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(459, 172);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(724, 39);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(64, 24);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cmdFromDoctor);
            this.m_pnlNewBase.Controls.Add(this.txtFromDoctor);
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(791, 85);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtFromDoctor, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdFromDoctor, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 29);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(597, 55);
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblAddress.Location = new System.Drawing.Point(164, 155);
            this.m_lblAddress.Name = "m_lblAddress";
            this.m_lblAddress.Size = new System.Drawing.Size(224, 24);
            this.m_lblAddress.TabIndex = 501;
            this.m_lblAddress.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.Location = new System.Drawing.Point(260, 152);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 14);
            this.lblAddress.TabIndex = 501;
            this.lblAddress.Text = "住 址:";
            this.lblAddress.Visible = false;
            // 
            // lblInPatientDate
            // 
            this.lblInPatientDate.AutoSize = true;
            this.lblInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInPatientDate.Location = new System.Drawing.Point(20, 16);
            this.lblInPatientDate.Name = "lblInPatientDate";
            this.lblInPatientDate.Size = new System.Drawing.Size(70, 14);
            this.lblInPatientDate.TabIndex = 501;
            this.lblInPatientDate.Text = "入院日期:";
            // 
            // lblInDiagnose
            // 
            this.lblInDiagnose.AutoSize = true;
            this.lblInDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInDiagnose.Location = new System.Drawing.Point(20, 52);
            this.lblInDiagnose.Name = "lblInDiagnose";
            this.lblInDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblInDiagnose.TabIndex = 501;
            this.lblInDiagnose.Text = "入院诊断:";
            // 
            // lblOperationName
            // 
            this.lblOperationName.AutoSize = true;
            this.lblOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationName.Location = new System.Drawing.Point(20, 80);
            this.lblOperationName.Name = "lblOperationName";
            this.lblOperationName.Size = new System.Drawing.Size(70, 14);
            this.lblOperationName.TabIndex = 501;
            this.lblOperationName.Text = "手术名称:";
            // 
            // lblAnaesthesiaType
            // 
            this.lblAnaesthesiaType.AutoSize = true;
            this.lblAnaesthesiaType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnaesthesiaType.Location = new System.Drawing.Point(20, 108);
            this.lblAnaesthesiaType.Name = "lblAnaesthesiaType";
            this.lblAnaesthesiaType.Size = new System.Drawing.Size(70, 14);
            this.lblAnaesthesiaType.TabIndex = 501;
            this.lblAnaesthesiaType.Text = "麻醉类型:";
            // 
            // m_lblTurnBaseDept
            // 
            this.m_lblTurnBaseDept.AutoSize = true;
            this.m_lblTurnBaseDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTurnBaseDept.Location = new System.Drawing.Point(20, 132);
            this.m_lblTurnBaseDept.Name = "m_lblTurnBaseDept";
            this.m_lblTurnBaseDept.Size = new System.Drawing.Size(70, 14);
            this.m_lblTurnBaseDept.TabIndex = 501;
            this.m_lblTurnBaseDept.Text = "转  科室:";
            // 
            // m_lblTurnTime
            // 
            this.m_lblTurnTime.AutoSize = true;
            this.m_lblTurnTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTurnTime.Location = new System.Drawing.Point(440, 132);
            this.m_lblTurnTime.Name = "m_lblTurnTime";
            this.m_lblTurnTime.Size = new System.Drawing.Size(70, 14);
            this.m_lblTurnTime.TabIndex = 501;
            this.m_lblTurnTime.Text = "转  时间:";
            // 
            // lblTurnDiagnose
            // 
            this.lblTurnDiagnose.AutoSize = true;
            this.lblTurnDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTurnDiagnose.Location = new System.Drawing.Point(20, 160);
            this.lblTurnDiagnose.Name = "lblTurnDiagnose";
            this.lblTurnDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblTurnDiagnose.TabIndex = 501;
            this.lblTurnDiagnose.Text = "转  诊断:";
            // 
            // lblInDiagnoseCourse
            // 
            this.lblInDiagnoseCourse.AutoSize = true;
            this.lblInDiagnoseCourse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInDiagnoseCourse.Location = new System.Drawing.Point(20, 215);
            this.lblInDiagnoseCourse.Name = "lblInDiagnoseCourse";
            this.lblInDiagnoseCourse.Size = new System.Drawing.Size(91, 14);
            this.lblInDiagnoseCourse.TabIndex = 501;
            this.lblInDiagnoseCourse.Text = "入院诊治经过";
            // 
            // m_txtInDiagnoseCourse
            // 
            this.m_txtInDiagnoseCourse.AccessibleDescription = "入院诊治经过";
            this.m_txtInDiagnoseCourse.BackColor = System.Drawing.Color.White;
            this.m_txtInDiagnoseCourse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtInDiagnoseCourse.ForeColor = System.Drawing.Color.Black;
            this.m_txtInDiagnoseCourse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInDiagnoseCourse.Location = new System.Drawing.Point(20, 232);
            this.m_txtInDiagnoseCourse.m_BlnIgnoreUserInfo = false;
            this.m_txtInDiagnoseCourse.m_BlnPartControl = false;
            this.m_txtInDiagnoseCourse.m_BlnReadOnly = false;
            this.m_txtInDiagnoseCourse.m_BlnUnderLineDST = false;
            this.m_txtInDiagnoseCourse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInDiagnoseCourse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInDiagnoseCourse.m_IntCanModifyTime = 6;
            this.m_txtInDiagnoseCourse.m_IntPartControlLength = 0;
            this.m_txtInDiagnoseCourse.m_IntPartControlStartIndex = 0;
            this.m_txtInDiagnoseCourse.m_StrUserID = "";
            this.m_txtInDiagnoseCourse.m_StrUserName = "";
            this.m_txtInDiagnoseCourse.Name = "m_txtInDiagnoseCourse";
            this.m_txtInDiagnoseCourse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.m_txtInDiagnoseCourse.Size = new System.Drawing.Size(708, 188);
            this.m_txtInDiagnoseCourse.TabIndex = 240;
            this.m_txtInDiagnoseCourse.Text = "";
            this.m_txtInDiagnoseCourse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_lblTurnInfo
            // 
            this.m_lblTurnInfo.AutoSize = true;
            this.m_lblTurnInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblTurnInfo.Location = new System.Drawing.Point(16, 424);
            this.m_lblTurnInfo.Name = "m_lblTurnInfo";
            this.m_lblTurnInfo.Size = new System.Drawing.Size(63, 14);
            this.m_lblTurnInfo.TabIndex = 501;
            this.m_lblTurnInfo.Text = "转  情况";
            // 
            // m_txtInDiagnose
            // 
            this.m_txtInDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInDiagnose.Location = new System.Drawing.Point(96, 48);
            this.m_txtInDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtInDiagnose.m_BlnPartControl = false;
            this.m_txtInDiagnose.m_BlnReadOnly = false;
            this.m_txtInDiagnose.m_BlnUnderLineDST = false;
            this.m_txtInDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInDiagnose.m_IntCanModifyTime = 6;
            this.m_txtInDiagnose.m_IntPartControlLength = 0;
            this.m_txtInDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtInDiagnose.m_StrUserID = "";
            this.m_txtInDiagnose.m_StrUserName = "";
            this.m_txtInDiagnose.Multiline = false;
            this.m_txtInDiagnose.Name = "m_txtInDiagnose";
            this.m_txtInDiagnose.Size = new System.Drawing.Size(636, 21);
            this.m_txtInDiagnose.TabIndex = 190;
            this.m_txtInDiagnose.Text = "";
            this.m_txtInDiagnose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtAnaesthesiaType
            // 
            this.m_txtAnaesthesiaType.AccessibleDescription = "麻醉类型";
            this.m_txtAnaesthesiaType.BackColor = System.Drawing.Color.White;
            this.m_txtAnaesthesiaType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaesthesiaType.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaesthesiaType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAnaesthesiaType.Location = new System.Drawing.Point(96, 104);
            this.m_txtAnaesthesiaType.m_BlnIgnoreUserInfo = false;
            this.m_txtAnaesthesiaType.m_BlnPartControl = false;
            this.m_txtAnaesthesiaType.m_BlnReadOnly = false;
            this.m_txtAnaesthesiaType.m_BlnUnderLineDST = false;
            this.m_txtAnaesthesiaType.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAnaesthesiaType.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAnaesthesiaType.m_IntCanModifyTime = 6;
            this.m_txtAnaesthesiaType.m_IntPartControlLength = 0;
            this.m_txtAnaesthesiaType.m_IntPartControlStartIndex = 0;
            this.m_txtAnaesthesiaType.m_StrUserID = "";
            this.m_txtAnaesthesiaType.m_StrUserName = "";
            this.m_txtAnaesthesiaType.Multiline = false;
            this.m_txtAnaesthesiaType.Name = "m_txtAnaesthesiaType";
            this.m_txtAnaesthesiaType.Size = new System.Drawing.Size(636, 21);
            this.m_txtAnaesthesiaType.TabIndex = 206;
            this.m_txtAnaesthesiaType.Text = "";
            this.m_txtAnaesthesiaType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "手术名称";
            this.m_txtOperationName.BackColor = System.Drawing.Color.White;
            this.m_txtOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOperationName.Location = new System.Drawing.Point(96, 76);
            this.m_txtOperationName.m_BlnIgnoreUserInfo = false;
            this.m_txtOperationName.m_BlnPartControl = false;
            this.m_txtOperationName.m_BlnReadOnly = false;
            this.m_txtOperationName.m_BlnUnderLineDST = false;
            this.m_txtOperationName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOperationName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOperationName.m_IntCanModifyTime = 6;
            this.m_txtOperationName.m_IntPartControlLength = 0;
            this.m_txtOperationName.m_IntPartControlStartIndex = 0;
            this.m_txtOperationName.m_StrUserID = "";
            this.m_txtOperationName.m_StrUserName = "";
            this.m_txtOperationName.Multiline = false;
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.Size = new System.Drawing.Size(636, 21);
            this.m_txtOperationName.TabIndex = 200;
            this.m_txtOperationName.Text = "";
            this.m_txtOperationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtTurnDiagnose
            // 
            this.m_txtTurnDiagnose.AccessibleDescription = "转  诊断";
            this.m_txtTurnDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtTurnDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTurnDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtTurnDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTurnDiagnose.Location = new System.Drawing.Point(96, 156);
            this.m_txtTurnDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtTurnDiagnose.m_BlnPartControl = false;
            this.m_txtTurnDiagnose.m_BlnReadOnly = false;
            this.m_txtTurnDiagnose.m_BlnUnderLineDST = false;
            this.m_txtTurnDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTurnDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTurnDiagnose.m_IntCanModifyTime = 6;
            this.m_txtTurnDiagnose.m_IntPartControlLength = 0;
            this.m_txtTurnDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtTurnDiagnose.m_StrUserID = "";
            this.m_txtTurnDiagnose.m_StrUserName = "";
            this.m_txtTurnDiagnose.Name = "m_txtTurnDiagnose";
            this.m_txtTurnDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.m_txtTurnDiagnose.Size = new System.Drawing.Size(636, 56);
            this.m_txtTurnDiagnose.TabIndex = 230;
            this.m_txtTurnDiagnose.Text = "";
            this.m_txtTurnDiagnose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_dtpTurnTime
            // 
            this.m_dtpTurnTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpTurnTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpTurnTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpTurnTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpTurnTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpTurnTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpTurnTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpTurnTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpTurnTime.Location = new System.Drawing.Point(516, 132);
            this.m_dtpTurnTime.m_BlnOnlyTime = false;
            this.m_dtpTurnTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpTurnTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpTurnTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpTurnTime.Name = "m_dtpTurnTime";
            this.m_dtpTurnTime.ReadOnly = false;
            this.m_dtpTurnTime.Size = new System.Drawing.Size(216, 22);
            this.m_dtpTurnTime.TabIndex = 220;
            this.m_dtpTurnTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpTurnTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpTurnTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperature.Location = new System.Drawing.Point(16, 48);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(21, 14);
            this.lblTemperature.TabIndex = 501;
            this.lblTemperature.Text = " T";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.Color.Black;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(40, 48);
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
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(44, 21);
            this.m_txtTemperature.TabIndex = 323;
            this.m_txtTemperature.Text = "";
            this.m_txtTemperature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblTemperatureUnit
            // 
            this.lblTemperatureUnit.AutoSize = true;
            this.lblTemperatureUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperatureUnit.Location = new System.Drawing.Point(88, 48);
            this.lblTemperatureUnit.Name = "lblTemperatureUnit";
            this.lblTemperatureUnit.Size = new System.Drawing.Size(21, 14);
            this.lblTemperatureUnit.TabIndex = 501;
            this.lblTemperatureUnit.Text = "℃";
            this.lblTemperatureUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeartRate
            // 
            this.lblHeartRate.AutoSize = true;
            this.lblHeartRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeartRate.Location = new System.Drawing.Point(120, 48);
            this.lblHeartRate.Name = "lblHeartRate";
            this.lblHeartRate.Size = new System.Drawing.Size(14, 14);
            this.lblHeartRate.TabIndex = 501;
            this.lblHeartRate.Text = "R";
            this.lblHeartRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtHeartRate
            // 
            this.m_txtHeartRate.BackColor = System.Drawing.Color.White;
            this.m_txtHeartRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHeartRate.ForeColor = System.Drawing.Color.Black;
            this.m_txtHeartRate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHeartRate.Location = new System.Drawing.Point(136, 48);
            this.m_txtHeartRate.m_BlnIgnoreUserInfo = false;
            this.m_txtHeartRate.m_BlnPartControl = false;
            this.m_txtHeartRate.m_BlnReadOnly = false;
            this.m_txtHeartRate.m_BlnUnderLineDST = false;
            this.m_txtHeartRate.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHeartRate.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHeartRate.m_IntCanModifyTime = 6;
            this.m_txtHeartRate.m_IntPartControlLength = 0;
            this.m_txtHeartRate.m_IntPartControlStartIndex = 0;
            this.m_txtHeartRate.m_StrUserID = "";
            this.m_txtHeartRate.m_StrUserName = "";
            this.m_txtHeartRate.Multiline = false;
            this.m_txtHeartRate.Name = "m_txtHeartRate";
            this.m_txtHeartRate.Size = new System.Drawing.Size(48, 21);
            this.m_txtHeartRate.TabIndex = 324;
            this.m_txtHeartRate.Text = "";
            this.m_txtHeartRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblHeartRateUnit
            // 
            this.lblHeartRateUnit.AutoSize = true;
            this.lblHeartRateUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeartRateUnit.Location = new System.Drawing.Point(188, 48);
            this.lblHeartRateUnit.Name = "lblHeartRateUnit";
            this.lblHeartRateUnit.Size = new System.Drawing.Size(42, 14);
            this.lblHeartRateUnit.TabIndex = 501;
            this.lblHeartRateUnit.Text = "次/分";
            this.lblHeartRateUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.Color.White;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(256, 48);
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
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(48, 21);
            this.m_txtPulse.TabIndex = 325;
            this.m_txtPulse.Text = "";
            this.m_txtPulse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPulseUnit
            // 
            this.lblPulseUnit.AutoSize = true;
            this.lblPulseUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulseUnit.Location = new System.Drawing.Point(308, 48);
            this.lblPulseUnit.Name = "lblPulseUnit";
            this.lblPulseUnit.Size = new System.Drawing.Size(42, 14);
            this.lblPulseUnit.TabIndex = 501;
            this.lblPulseUnit.Text = "次/分";
            this.lblPulseUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSystolic
            // 
            this.m_txtSystolic.BackColor = System.Drawing.Color.White;
            this.m_txtSystolic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSystolic.ForeColor = System.Drawing.Color.Black;
            this.m_txtSystolic.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSystolic.Location = new System.Drawing.Point(388, 48);
            this.m_txtSystolic.m_BlnIgnoreUserInfo = false;
            this.m_txtSystolic.m_BlnPartControl = false;
            this.m_txtSystolic.m_BlnReadOnly = false;
            this.m_txtSystolic.m_BlnUnderLineDST = false;
            this.m_txtSystolic.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSystolic.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSystolic.m_IntCanModifyTime = 6;
            this.m_txtSystolic.m_IntPartControlLength = 0;
            this.m_txtSystolic.m_IntPartControlStartIndex = 0;
            this.m_txtSystolic.m_StrUserID = "";
            this.m_txtSystolic.m_StrUserName = "";
            this.m_txtSystolic.Multiline = false;
            this.m_txtSystolic.Name = "m_txtSystolic";
            this.m_txtSystolic.Size = new System.Drawing.Size(48, 21);
            this.m_txtSystolic.TabIndex = 326;
            this.m_txtSystolic.Text = "";
            this.m_txtSystolic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPressureSeperate
            // 
            this.lblPressureSeperate.AutoSize = true;
            this.lblPressureSeperate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPressureSeperate.Location = new System.Drawing.Point(440, 48);
            this.lblPressureSeperate.Name = "lblPressureSeperate";
            this.lblPressureSeperate.Size = new System.Drawing.Size(14, 14);
            this.lblPressureSeperate.TabIndex = 501;
            this.lblPressureSeperate.Text = "/";
            this.lblPressureSeperate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDiastolic
            // 
            this.m_txtDiastolic.BackColor = System.Drawing.Color.White;
            this.m_txtDiastolic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiastolic.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiastolic.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiastolic.Location = new System.Drawing.Point(456, 48);
            this.m_txtDiastolic.m_BlnIgnoreUserInfo = false;
            this.m_txtDiastolic.m_BlnPartControl = false;
            this.m_txtDiastolic.m_BlnReadOnly = false;
            this.m_txtDiastolic.m_BlnUnderLineDST = false;
            this.m_txtDiastolic.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiastolic.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiastolic.m_IntCanModifyTime = 6;
            this.m_txtDiastolic.m_IntPartControlLength = 0;
            this.m_txtDiastolic.m_IntPartControlStartIndex = 0;
            this.m_txtDiastolic.m_StrUserID = "";
            this.m_txtDiastolic.m_StrUserName = "";
            this.m_txtDiastolic.Multiline = false;
            this.m_txtDiastolic.Name = "m_txtDiastolic";
            this.m_txtDiastolic.Size = new System.Drawing.Size(48, 21);
            this.m_txtDiastolic.TabIndex = 327;
            this.m_txtDiastolic.Text = "";
            this.m_txtDiastolic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            this.m_txtDiastolic.TextChanged += new System.EventHandler(this.m_txtDiastolic_TextChanged);
            // 
            // lblPressureUnit
            // 
            this.lblPressureUnit.AutoSize = true;
            this.lblPressureUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPressureUnit.Location = new System.Drawing.Point(508, 48);
            this.lblPressureUnit.Name = "lblPressureUnit";
            this.lblPressureUnit.Size = new System.Drawing.Size(35, 14);
            this.lblPressureUnit.TabIndex = 501;
            this.lblPressureUnit.Text = "mmHg";
            this.lblPressureUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPulse
            // 
            this.lblPulse.AutoSize = true;
            this.lblPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulse.Location = new System.Drawing.Point(244, 48);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(14, 14);
            this.lblPulse.TabIndex = 501;
            this.lblPulse.Text = "P";
            this.lblPulse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPressure.Location = new System.Drawing.Point(364, 48);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(21, 14);
            this.lblPressure.TabIndex = 501;
            this.lblPressure.Text = "Bp";
            this.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMind
            // 
            this.lblMind.AutoSize = true;
            this.lblMind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMind.Location = new System.Drawing.Point(548, 48);
            this.lblMind.Name = "lblMind";
            this.lblMind.Size = new System.Drawing.Size(35, 14);
            this.lblMind.TabIndex = 501;
            this.lblMind.Text = "神智";
            this.lblMind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtMind
            // 
            this.m_txtMind.BackColor = System.Drawing.Color.White;
            this.m_txtMind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMind.ForeColor = System.Drawing.Color.Black;
            this.m_txtMind.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMind.Location = new System.Drawing.Point(588, 48);
            this.m_txtMind.m_BlnIgnoreUserInfo = false;
            this.m_txtMind.m_BlnPartControl = false;
            this.m_txtMind.m_BlnReadOnly = false;
            this.m_txtMind.m_BlnUnderLineDST = false;
            this.m_txtMind.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMind.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMind.m_IntCanModifyTime = 6;
            this.m_txtMind.m_IntPartControlLength = 0;
            this.m_txtMind.m_IntPartControlStartIndex = 0;
            this.m_txtMind.m_StrUserID = "";
            this.m_txtMind.m_StrUserName = "";
            this.m_txtMind.Multiline = false;
            this.m_txtMind.Name = "m_txtMind";
            this.m_txtMind.Size = new System.Drawing.Size(136, 21);
            this.m_txtMind.TabIndex = 328;
            this.m_txtMind.Text = "";
            this.m_txtMind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblGlasgow1
            // 
            this.lblGlasgow1.AutoSize = true;
            this.lblGlasgow1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGlasgow1.Location = new System.Drawing.Point(16, 116);
            this.lblGlasgow1.Name = "lblGlasgow1";
            this.lblGlasgow1.Size = new System.Drawing.Size(112, 14);
            this.lblGlasgow1.TabIndex = 501;
            this.lblGlasgow1.Text = "Glasgow  计  分";
            this.lblGlasgow1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPupilDiameterRight
            // 
            this.m_txtPupilDiameterRight.BackColor = System.Drawing.Color.White;
            this.m_txtPupilDiameterRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilDiameterRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtPupilDiameterRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilDiameterRight.Location = new System.Drawing.Point(136, 80);
            this.m_txtPupilDiameterRight.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilDiameterRight.m_BlnPartControl = false;
            this.m_txtPupilDiameterRight.m_BlnReadOnly = false;
            this.m_txtPupilDiameterRight.m_BlnUnderLineDST = false;
            this.m_txtPupilDiameterRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilDiameterRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilDiameterRight.m_IntCanModifyTime = 6;
            this.m_txtPupilDiameterRight.m_IntPartControlLength = 0;
            this.m_txtPupilDiameterRight.m_IntPartControlStartIndex = 0;
            this.m_txtPupilDiameterRight.m_StrUserID = "";
            this.m_txtPupilDiameterRight.m_StrUserName = "";
            this.m_txtPupilDiameterRight.Multiline = false;
            this.m_txtPupilDiameterRight.Name = "m_txtPupilDiameterRight";
            this.m_txtPupilDiameterRight.Size = new System.Drawing.Size(48, 21);
            this.m_txtPupilDiameterRight.TabIndex = 329;
            this.m_txtPupilDiameterRight.Text = "";
            this.m_txtPupilDiameterRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPupilDiameter2
            // 
            this.lblPupilDiameter2.AutoSize = true;
            this.lblPupilDiameter2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilDiameter2.Location = new System.Drawing.Point(188, 84);
            this.lblPupilDiameter2.Name = "lblPupilDiameter2";
            this.lblPupilDiameter2.Size = new System.Drawing.Size(70, 14);
            this.lblPupilDiameter2.TabIndex = 501;
            this.lblPupilDiameter2.Text = "mm     左";
            this.lblPupilDiameter2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPupilDiameterLeft
            // 
            this.m_txtPupilDiameterLeft.BackColor = System.Drawing.Color.White;
            this.m_txtPupilDiameterLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilDiameterLeft.ForeColor = System.Drawing.Color.White;
            this.m_txtPupilDiameterLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilDiameterLeft.Location = new System.Drawing.Point(256, 80);
            this.m_txtPupilDiameterLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilDiameterLeft.m_BlnPartControl = false;
            this.m_txtPupilDiameterLeft.m_BlnReadOnly = false;
            this.m_txtPupilDiameterLeft.m_BlnUnderLineDST = false;
            this.m_txtPupilDiameterLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilDiameterLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilDiameterLeft.m_IntCanModifyTime = 6;
            this.m_txtPupilDiameterLeft.m_IntPartControlLength = 0;
            this.m_txtPupilDiameterLeft.m_IntPartControlStartIndex = 0;
            this.m_txtPupilDiameterLeft.m_StrUserID = "";
            this.m_txtPupilDiameterLeft.m_StrUserName = "";
            this.m_txtPupilDiameterLeft.Multiline = false;
            this.m_txtPupilDiameterLeft.Name = "m_txtPupilDiameterLeft";
            this.m_txtPupilDiameterLeft.Size = new System.Drawing.Size(48, 21);
            this.m_txtPupilDiameterLeft.TabIndex = 330;
            this.m_txtPupilDiameterLeft.Text = "";
            this.m_txtPupilDiameterLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPupilDiameterUnit
            // 
            this.lblPupilDiameterUnit.AutoSize = true;
            this.lblPupilDiameterUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilDiameterUnit.Location = new System.Drawing.Point(308, 84);
            this.lblPupilDiameterUnit.Name = "lblPupilDiameterUnit";
            this.lblPupilDiameterUnit.Size = new System.Drawing.Size(21, 14);
            this.lblPupilDiameterUnit.TabIndex = 501;
            this.lblPupilDiameterUnit.Text = "mm";
            this.lblPupilDiameterUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPupilReflection1
            // 
            this.lblPupilReflection1.AutoSize = true;
            this.lblPupilReflection1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilReflection1.Location = new System.Drawing.Point(372, 84);
            this.lblPupilReflection1.Name = "lblPupilReflection1";
            this.lblPupilReflection1.Size = new System.Drawing.Size(84, 14);
            this.lblPupilReflection1.TabIndex = 501;
            this.lblPupilReflection1.Text = "瞳孔反射:右";
            this.lblPupilReflection1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPupilReflectionRight
            // 
            this.m_txtPupilReflectionRight.BackColor = System.Drawing.Color.White;
            this.m_txtPupilReflectionRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilReflectionRight.ForeColor = System.Drawing.Color.White;
            this.m_txtPupilReflectionRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilReflectionRight.Location = new System.Drawing.Point(456, 80);
            this.m_txtPupilReflectionRight.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilReflectionRight.m_BlnPartControl = false;
            this.m_txtPupilReflectionRight.m_BlnReadOnly = false;
            this.m_txtPupilReflectionRight.m_BlnUnderLineDST = false;
            this.m_txtPupilReflectionRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilReflectionRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilReflectionRight.m_IntCanModifyTime = 6;
            this.m_txtPupilReflectionRight.m_IntPartControlLength = 0;
            this.m_txtPupilReflectionRight.m_IntPartControlStartIndex = 0;
            this.m_txtPupilReflectionRight.m_StrUserID = "";
            this.m_txtPupilReflectionRight.m_StrUserName = "";
            this.m_txtPupilReflectionRight.Multiline = false;
            this.m_txtPupilReflectionRight.Name = "m_txtPupilReflectionRight";
            this.m_txtPupilReflectionRight.Size = new System.Drawing.Size(48, 21);
            this.m_txtPupilReflectionRight.TabIndex = 331;
            this.m_txtPupilReflectionRight.Text = "";
            this.m_txtPupilReflectionRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtPupilReflectionLeft
            // 
            this.m_txtPupilReflectionLeft.BackColor = System.Drawing.Color.White;
            this.m_txtPupilReflectionLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilReflectionLeft.ForeColor = System.Drawing.Color.White;
            this.m_txtPupilReflectionLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilReflectionLeft.Location = new System.Drawing.Point(588, 80);
            this.m_txtPupilReflectionLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilReflectionLeft.m_BlnPartControl = false;
            this.m_txtPupilReflectionLeft.m_BlnReadOnly = false;
            this.m_txtPupilReflectionLeft.m_BlnUnderLineDST = false;
            this.m_txtPupilReflectionLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilReflectionLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilReflectionLeft.m_IntCanModifyTime = 6;
            this.m_txtPupilReflectionLeft.m_IntPartControlLength = 0;
            this.m_txtPupilReflectionLeft.m_IntPartControlStartIndex = 0;
            this.m_txtPupilReflectionLeft.m_StrUserID = "";
            this.m_txtPupilReflectionLeft.m_StrUserName = "";
            this.m_txtPupilReflectionLeft.Multiline = false;
            this.m_txtPupilReflectionLeft.Name = "m_txtPupilReflectionLeft";
            this.m_txtPupilReflectionLeft.Size = new System.Drawing.Size(48, 21);
            this.m_txtPupilReflectionLeft.TabIndex = 332;
            this.m_txtPupilReflectionLeft.Text = "";
            this.m_txtPupilReflectionLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPupilReflection2
            // 
            this.lblPupilReflection2.AutoSize = true;
            this.lblPupilReflection2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilReflection2.Location = new System.Drawing.Point(564, 80);
            this.lblPupilReflection2.Name = "lblPupilReflection2";
            this.lblPupilReflection2.Size = new System.Drawing.Size(21, 14);
            this.lblPupilReflection2.TabIndex = 501;
            this.lblPupilReflection2.Text = "左";
            this.lblPupilReflection2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtGlasgowValue
            // 
            this.m_txtGlasgowValue.BackColor = System.Drawing.Color.White;
            this.m_txtGlasgowValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGlasgowValue.ForeColor = System.Drawing.Color.Black;
            this.m_txtGlasgowValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGlasgowValue.Location = new System.Drawing.Point(136, 116);
            this.m_txtGlasgowValue.m_BlnIgnoreUserInfo = false;
            this.m_txtGlasgowValue.m_BlnPartControl = false;
            this.m_txtGlasgowValue.m_BlnReadOnly = false;
            this.m_txtGlasgowValue.m_BlnUnderLineDST = false;
            this.m_txtGlasgowValue.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGlasgowValue.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGlasgowValue.m_IntCanModifyTime = 6;
            this.m_txtGlasgowValue.m_IntPartControlLength = 0;
            this.m_txtGlasgowValue.m_IntPartControlStartIndex = 0;
            this.m_txtGlasgowValue.m_StrUserID = "";
            this.m_txtGlasgowValue.m_StrUserName = "";
            this.m_txtGlasgowValue.Multiline = false;
            this.m_txtGlasgowValue.Name = "m_txtGlasgowValue";
            this.m_txtGlasgowValue.Size = new System.Drawing.Size(48, 21);
            this.m_txtGlasgowValue.TabIndex = 333;
            this.m_txtGlasgowValue.Text = "";
            this.m_txtGlasgowValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtGlasgowOpenEye
            // 
            this.m_txtGlasgowOpenEye.BackColor = System.Drawing.Color.White;
            this.m_txtGlasgowOpenEye.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGlasgowOpenEye.ForeColor = System.Drawing.Color.White;
            this.m_txtGlasgowOpenEye.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGlasgowOpenEye.Location = new System.Drawing.Point(280, 116);
            this.m_txtGlasgowOpenEye.m_BlnIgnoreUserInfo = false;
            this.m_txtGlasgowOpenEye.m_BlnPartControl = false;
            this.m_txtGlasgowOpenEye.m_BlnReadOnly = false;
            this.m_txtGlasgowOpenEye.m_BlnUnderLineDST = false;
            this.m_txtGlasgowOpenEye.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGlasgowOpenEye.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGlasgowOpenEye.m_IntCanModifyTime = 6;
            this.m_txtGlasgowOpenEye.m_IntPartControlLength = 0;
            this.m_txtGlasgowOpenEye.m_IntPartControlStartIndex = 0;
            this.m_txtGlasgowOpenEye.m_StrUserID = "";
            this.m_txtGlasgowOpenEye.m_StrUserName = "";
            this.m_txtGlasgowOpenEye.Multiline = false;
            this.m_txtGlasgowOpenEye.Name = "m_txtGlasgowOpenEye";
            this.m_txtGlasgowOpenEye.Size = new System.Drawing.Size(48, 21);
            this.m_txtGlasgowOpenEye.TabIndex = 434;
            this.m_txtGlasgowOpenEye.Text = "";
            this.m_txtGlasgowOpenEye.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblGlasgow2
            // 
            this.lblGlasgow2.AutoSize = true;
            this.lblGlasgow2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGlasgow2.Location = new System.Drawing.Point(188, 116);
            this.lblGlasgow2.Name = "lblGlasgow2";
            this.lblGlasgow2.Size = new System.Drawing.Size(91, 14);
            this.lblGlasgow2.TabIndex = 501;
            this.lblGlasgow2.Text = "分（其中睁眼";
            this.lblGlasgow2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGlasgow3
            // 
            this.lblGlasgow3.AutoSize = true;
            this.lblGlasgow3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGlasgow3.Location = new System.Drawing.Point(332, 116);
            this.lblGlasgow3.Name = "lblGlasgow3";
            this.lblGlasgow3.Size = new System.Drawing.Size(77, 14);
            this.lblGlasgow3.TabIndex = 501;
            this.lblGlasgow3.Text = "分,   言语";
            this.lblGlasgow3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtGlasgowLanguage
            // 
            this.m_txtGlasgowLanguage.BackColor = System.Drawing.Color.White;
            this.m_txtGlasgowLanguage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGlasgowLanguage.ForeColor = System.Drawing.Color.White;
            this.m_txtGlasgowLanguage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGlasgowLanguage.Location = new System.Drawing.Point(412, 116);
            this.m_txtGlasgowLanguage.m_BlnIgnoreUserInfo = false;
            this.m_txtGlasgowLanguage.m_BlnPartControl = false;
            this.m_txtGlasgowLanguage.m_BlnReadOnly = false;
            this.m_txtGlasgowLanguage.m_BlnUnderLineDST = false;
            this.m_txtGlasgowLanguage.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGlasgowLanguage.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGlasgowLanguage.m_IntCanModifyTime = 6;
            this.m_txtGlasgowLanguage.m_IntPartControlLength = 0;
            this.m_txtGlasgowLanguage.m_IntPartControlStartIndex = 0;
            this.m_txtGlasgowLanguage.m_StrUserID = "";
            this.m_txtGlasgowLanguage.m_StrUserName = "";
            this.m_txtGlasgowLanguage.Multiline = false;
            this.m_txtGlasgowLanguage.Name = "m_txtGlasgowLanguage";
            this.m_txtGlasgowLanguage.Size = new System.Drawing.Size(48, 21);
            this.m_txtGlasgowLanguage.TabIndex = 435;
            this.m_txtGlasgowLanguage.Text = "";
            this.m_txtGlasgowLanguage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtGlasgowSport
            // 
            this.m_txtGlasgowSport.BackColor = System.Drawing.Color.White;
            this.m_txtGlasgowSport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGlasgowSport.ForeColor = System.Drawing.Color.White;
            this.m_txtGlasgowSport.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGlasgowSport.Location = new System.Drawing.Point(528, 116);
            this.m_txtGlasgowSport.m_BlnIgnoreUserInfo = false;
            this.m_txtGlasgowSport.m_BlnPartControl = false;
            this.m_txtGlasgowSport.m_BlnReadOnly = false;
            this.m_txtGlasgowSport.m_BlnUnderLineDST = false;
            this.m_txtGlasgowSport.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGlasgowSport.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGlasgowSport.m_IntCanModifyTime = 6;
            this.m_txtGlasgowSport.m_IntPartControlLength = 0;
            this.m_txtGlasgowSport.m_IntPartControlStartIndex = 0;
            this.m_txtGlasgowSport.m_StrUserID = "";
            this.m_txtGlasgowSport.m_StrUserName = "";
            this.m_txtGlasgowSport.Multiline = false;
            this.m_txtGlasgowSport.Name = "m_txtGlasgowSport";
            this.m_txtGlasgowSport.Size = new System.Drawing.Size(48, 21);
            this.m_txtGlasgowSport.TabIndex = 436;
            this.m_txtGlasgowSport.Text = "";
            this.m_txtGlasgowSport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblGlasgow4
            // 
            this.lblGlasgow4.AutoSize = true;
            this.lblGlasgow4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGlasgow4.Location = new System.Drawing.Point(464, 116);
            this.lblGlasgow4.Name = "lblGlasgow4";
            this.lblGlasgow4.Size = new System.Drawing.Size(63, 14);
            this.lblGlasgow4.TabIndex = 501;
            this.lblGlasgow4.Text = "分，运动";
            this.lblGlasgow4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGlasgow5
            // 
            this.lblGlasgow5.AutoSize = true;
            this.lblGlasgow5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGlasgow5.Location = new System.Drawing.Point(576, 116);
            this.lblGlasgow5.Name = "lblGlasgow5";
            this.lblGlasgow5.Size = new System.Drawing.Size(49, 14);
            this.lblGlasgow5.TabIndex = 501;
            this.lblGlasgow5.Text = "分）。";
            this.lblGlasgow5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPupilDiameter1
            // 
            this.lblPupilDiameter1.AutoSize = true;
            this.lblPupilDiameter1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilDiameter1.Location = new System.Drawing.Point(16, 84);
            this.lblPupilDiameter1.Name = "lblPupilDiameter1";
            this.lblPupilDiameter1.Size = new System.Drawing.Size(112, 14);
            this.lblPupilDiameter1.TabIndex = 501;
            this.lblPupilDiameter1.Text = "瞳孔直径:    右";
            this.lblPupilDiameter1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtOther
            // 
            this.m_txtOther.AccessibleDescription = "转  情况";
            this.m_txtOther.BackColor = System.Drawing.Color.White;
            this.m_txtOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOther.Location = new System.Drawing.Point(16, 152);
            this.m_txtOther.m_BlnIgnoreUserInfo = false;
            this.m_txtOther.m_BlnPartControl = false;
            this.m_txtOther.m_BlnReadOnly = false;
            this.m_txtOther.m_BlnUnderLineDST = false;
            this.m_txtOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOther.m_IntCanModifyTime = 6;
            this.m_txtOther.m_IntPartControlLength = 0;
            this.m_txtOther.m_IntPartControlStartIndex = 0;
            this.m_txtOther.m_StrUserID = "";
            this.m_txtOther.m_StrUserName = "";
            this.m_txtOther.Name = "m_txtOther";
            this.m_txtOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.m_txtOther.Size = new System.Drawing.Size(716, 288);
            this.m_txtOther.TabIndex = 500;
            this.m_txtOther.Text = "";
            this.m_txtOther.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblNewLabReport
            // 
            this.lblNewLabReport.AutoSize = true;
            this.lblNewLabReport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNewLabReport.Location = new System.Drawing.Point(12, 12);
            this.lblNewLabReport.Name = "lblNewLabReport";
            this.lblNewLabReport.Size = new System.Drawing.Size(105, 14);
            this.lblNewLabReport.TabIndex = 501;
            this.lblNewLabReport.Text = "最新实验室报告";
            // 
            // lblHBUnit
            // 
            this.lblHBUnit.AutoSize = true;
            this.lblHBUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHBUnit.Location = new System.Drawing.Point(104, 48);
            this.lblHBUnit.Name = "lblHBUnit";
            this.lblHBUnit.Size = new System.Drawing.Size(28, 14);
            this.lblHBUnit.TabIndex = 501;
            this.lblHBUnit.Text = "g/L";
            this.lblHBUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHB
            // 
            this.lblHB.AutoSize = true;
            this.lblHB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHB.Location = new System.Drawing.Point(12, 48);
            this.lblHB.Name = "lblHB";
            this.lblHB.Size = new System.Drawing.Size(21, 14);
            this.lblHB.TabIndex = 501;
            this.lblHB.Text = "HB";
            this.lblHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtHB
            // 
            this.m_txtHB.BackColor = System.Drawing.Color.White;
            this.m_txtHB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHB.ForeColor = System.Drawing.Color.Black;
            this.m_txtHB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHB.Location = new System.Drawing.Point(36, 48);
            this.m_txtHB.m_BlnIgnoreUserInfo = false;
            this.m_txtHB.m_BlnPartControl = false;
            this.m_txtHB.m_BlnReadOnly = false;
            this.m_txtHB.m_BlnUnderLineDST = false;
            this.m_txtHB.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHB.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHB.m_IntCanModifyTime = 6;
            this.m_txtHB.m_IntPartControlLength = 0;
            this.m_txtHB.m_IntPartControlStartIndex = 0;
            this.m_txtHB.m_StrUserID = "";
            this.m_txtHB.m_StrUserName = "";
            this.m_txtHB.Multiline = false;
            this.m_txtHB.Name = "m_txtHB";
            this.m_txtHB.Size = new System.Drawing.Size(68, 21);
            this.m_txtHB.TabIndex = 538;
            this.m_txtHB.Text = "";
            this.m_txtHB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblRBCUnit
            // 
            this.lblRBCUnit.AutoSize = true;
            this.lblRBCUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRBCUnit.Location = new System.Drawing.Point(272, 48);
            this.lblRBCUnit.Name = "lblRBCUnit";
            this.lblRBCUnit.Size = new System.Drawing.Size(56, 14);
            this.lblRBCUnit.TabIndex = 501;
            this.lblRBCUnit.Text = "X10  /L";
            this.lblRBCUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRBC
            // 
            this.lblRBC.AutoSize = true;
            this.lblRBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRBC.Location = new System.Drawing.Point(140, 48);
            this.lblRBC.Name = "lblRBC";
            this.lblRBC.Size = new System.Drawing.Size(28, 14);
            this.lblRBC.TabIndex = 501;
            this.lblRBC.Text = "RBC";
            this.lblRBC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtRBC
            // 
            this.m_txtRBC.BackColor = System.Drawing.Color.White;
            this.m_txtRBC.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRBC.ForeColor = System.Drawing.Color.Black;
            this.m_txtRBC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRBC.Location = new System.Drawing.Point(168, 48);
            this.m_txtRBC.m_BlnIgnoreUserInfo = false;
            this.m_txtRBC.m_BlnPartControl = false;
            this.m_txtRBC.m_BlnReadOnly = false;
            this.m_txtRBC.m_BlnUnderLineDST = false;
            this.m_txtRBC.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRBC.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRBC.m_IntCanModifyTime = 6;
            this.m_txtRBC.m_IntPartControlLength = 0;
            this.m_txtRBC.m_IntPartControlStartIndex = 0;
            this.m_txtRBC.m_StrUserID = "";
            this.m_txtRBC.m_StrUserName = "";
            this.m_txtRBC.Multiline = false;
            this.m_txtRBC.Name = "m_txtRBC";
            this.m_txtRBC.Size = new System.Drawing.Size(100, 21);
            this.m_txtRBC.TabIndex = 539;
            this.m_txtRBC.Text = "";
            this.m_txtRBC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblRBCExp
            // 
            this.lblRBCExp.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRBCExp.Location = new System.Drawing.Point(296, 44);
            this.lblRBCExp.Name = "lblRBCExp";
            this.lblRBCExp.Size = new System.Drawing.Size(16, 16);
            this.lblRBCExp.TabIndex = 501;
            this.lblRBCExp.Text = "12";
            this.lblRBCExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWBC
            // 
            this.lblWBC.AutoSize = true;
            this.lblWBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWBC.Location = new System.Drawing.Point(348, 48);
            this.lblWBC.Name = "lblWBC";
            this.lblWBC.Size = new System.Drawing.Size(28, 14);
            this.lblWBC.TabIndex = 501;
            this.lblWBC.Text = "WBC";
            this.lblWBC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtWBC
            // 
            this.m_txtWBC.BackColor = System.Drawing.Color.White;
            this.m_txtWBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWBC.ForeColor = System.Drawing.Color.Black;
            this.m_txtWBC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWBC.Location = new System.Drawing.Point(376, 48);
            this.m_txtWBC.m_BlnIgnoreUserInfo = false;
            this.m_txtWBC.m_BlnPartControl = false;
            this.m_txtWBC.m_BlnReadOnly = false;
            this.m_txtWBC.m_BlnUnderLineDST = false;
            this.m_txtWBC.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWBC.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWBC.m_IntCanModifyTime = 6;
            this.m_txtWBC.m_IntPartControlLength = 0;
            this.m_txtWBC.m_IntPartControlStartIndex = 0;
            this.m_txtWBC.m_StrUserID = "";
            this.m_txtWBC.m_StrUserName = "";
            this.m_txtWBC.Multiline = false;
            this.m_txtWBC.Name = "m_txtWBC";
            this.m_txtWBC.Size = new System.Drawing.Size(100, 21);
            this.m_txtWBC.TabIndex = 600;
            this.m_txtWBC.Text = "";
            this.m_txtWBC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblWBCUnit
            // 
            this.lblWBCUnit.AutoSize = true;
            this.lblWBCUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWBCUnit.Location = new System.Drawing.Point(476, 52);
            this.lblWBCUnit.Name = "lblWBCUnit";
            this.lblWBCUnit.Size = new System.Drawing.Size(49, 14);
            this.lblWBCUnit.TabIndex = 501;
            this.lblWBCUnit.Text = "X10 /L";
            this.lblWBCUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWBCExp
            // 
            this.lblWBCExp.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWBCExp.Location = new System.Drawing.Point(500, 48);
            this.lblWBCExp.Name = "lblWBCExp";
            this.lblWBCExp.Size = new System.Drawing.Size(10, 12);
            this.lblWBCExp.TabIndex = 501;
            this.lblWBCExp.Text = "9";
            this.lblWBCExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeukocyteType
            // 
            this.lblLeukocyteType.AutoSize = true;
            this.lblLeukocyteType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeukocyteType.Location = new System.Drawing.Point(12, 80);
            this.lblLeukocyteType.Name = "lblLeukocyteType";
            this.lblLeukocyteType.Size = new System.Drawing.Size(84, 14);
            this.lblLeukocyteType.TabIndex = 501;
            this.lblLeukocyteType.Text = "白细胞分类:";
            // 
            // LymphocyteUnit
            // 
            this.LymphocyteUnit.AutoSize = true;
            this.LymphocyteUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LymphocyteUnit.Location = new System.Drawing.Point(272, 84);
            this.LymphocyteUnit.Name = "LymphocyteUnit";
            this.LymphocyteUnit.Size = new System.Drawing.Size(14, 14);
            this.LymphocyteUnit.TabIndex = 501;
            this.LymphocyteUnit.Text = "%";
            this.LymphocyteUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLymphocyte
            // 
            this.lblLymphocyte.AutoSize = true;
            this.lblLymphocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLymphocyte.Location = new System.Drawing.Point(108, 80);
            this.lblLymphocyte.Name = "lblLymphocyte";
            this.lblLymphocyte.Size = new System.Drawing.Size(63, 14);
            this.lblLymphocyte.TabIndex = 501;
            this.lblLymphocyte.Text = "淋巴细胞";
            this.lblLymphocyte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtLymphocyte
            // 
            this.m_txtLymphocyte.BackColor = System.Drawing.Color.White;
            this.m_txtLymphocyte.ForeColor = System.Drawing.Color.Black;
            this.m_txtLymphocyte.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLymphocyte.Location = new System.Drawing.Point(168, 80);
            this.m_txtLymphocyte.m_BlnIgnoreUserInfo = false;
            this.m_txtLymphocyte.m_BlnPartControl = false;
            this.m_txtLymphocyte.m_BlnReadOnly = false;
            this.m_txtLymphocyte.m_BlnUnderLineDST = false;
            this.m_txtLymphocyte.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLymphocyte.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLymphocyte.m_IntCanModifyTime = 6;
            this.m_txtLymphocyte.m_IntPartControlLength = 0;
            this.m_txtLymphocyte.m_IntPartControlStartIndex = 0;
            this.m_txtLymphocyte.m_StrUserID = "";
            this.m_txtLymphocyte.m_StrUserName = "";
            this.m_txtLymphocyte.Multiline = false;
            this.m_txtLymphocyte.Name = "m_txtLymphocyte";
            this.m_txtLymphocyte.Size = new System.Drawing.Size(100, 21);
            this.m_txtLymphocyte.TabIndex = 641;
            this.m_txtLymphocyte.Text = "";
            this.m_txtLymphocyte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtBandLeukocyte
            // 
            this.m_txtBandLeukocyte.BackColor = System.Drawing.Color.White;
            this.m_txtBandLeukocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBandLeukocyte.ForeColor = System.Drawing.Color.Black;
            this.m_txtBandLeukocyte.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBandLeukocyte.Location = new System.Drawing.Point(392, 80);
            this.m_txtBandLeukocyte.m_BlnIgnoreUserInfo = false;
            this.m_txtBandLeukocyte.m_BlnPartControl = false;
            this.m_txtBandLeukocyte.m_BlnReadOnly = false;
            this.m_txtBandLeukocyte.m_BlnUnderLineDST = false;
            this.m_txtBandLeukocyte.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBandLeukocyte.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBandLeukocyte.m_IntCanModifyTime = 6;
            this.m_txtBandLeukocyte.m_IntPartControlLength = 0;
            this.m_txtBandLeukocyte.m_IntPartControlStartIndex = 0;
            this.m_txtBandLeukocyte.m_StrUserID = "";
            this.m_txtBandLeukocyte.m_StrUserName = "";
            this.m_txtBandLeukocyte.Multiline = false;
            this.m_txtBandLeukocyte.Name = "m_txtBandLeukocyte";
            this.m_txtBandLeukocyte.Size = new System.Drawing.Size(84, 21);
            this.m_txtBandLeukocyte.TabIndex = 642;
            this.m_txtBandLeukocyte.Text = "";
            this.m_txtBandLeukocyte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            this.m_txtBandLeukocyte.TextChanged += new System.EventHandler(this.m_txtBandLeukocyte_TextChanged);
            // 
            // lblBandLeukocyteUnit
            // 
            this.lblBandLeukocyteUnit.AutoSize = true;
            this.lblBandLeukocyteUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBandLeukocyteUnit.Location = new System.Drawing.Point(480, 80);
            this.lblBandLeukocyteUnit.Name = "lblBandLeukocyteUnit";
            this.lblBandLeukocyteUnit.Size = new System.Drawing.Size(14, 14);
            this.lblBandLeukocyteUnit.TabIndex = 501;
            this.lblBandLeukocyteUnit.Text = "%";
            this.lblBandLeukocyteUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBandLeukocyte
            // 
            this.lblBandLeukocyte.AutoSize = true;
            this.lblBandLeukocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBandLeukocyte.Location = new System.Drawing.Point(284, 84);
            this.lblBandLeukocyte.Name = "lblBandLeukocyte";
            this.lblBandLeukocyte.Size = new System.Drawing.Size(105, 14);
            this.lblBandLeukocyte.TabIndex = 501;
            this.lblBandLeukocyte.Text = "带状中性白细胞";
            this.lblBandLeukocyte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDispartLeftLeukocyteUnit
            // 
            this.lblDispartLeftLeukocyteUnit.AutoSize = true;
            this.lblDispartLeftLeukocyteUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDispartLeftLeukocyteUnit.Location = new System.Drawing.Point(688, 84);
            this.lblDispartLeftLeukocyteUnit.Name = "lblDispartLeftLeukocyteUnit";
            this.lblDispartLeftLeukocyteUnit.Size = new System.Drawing.Size(14, 14);
            this.lblDispartLeftLeukocyteUnit.TabIndex = 501;
            this.lblDispartLeftLeukocyteUnit.Text = "%";
            this.lblDispartLeftLeukocyteUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDispartLeftLeukocyte
            // 
            this.m_txtDispartLeftLeukocyte.BackColor = System.Drawing.Color.White;
            this.m_txtDispartLeftLeukocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDispartLeftLeukocyte.ForeColor = System.Drawing.Color.Black;
            this.m_txtDispartLeftLeukocyte.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDispartLeftLeukocyte.Location = new System.Drawing.Point(608, 80);
            this.m_txtDispartLeftLeukocyte.m_BlnIgnoreUserInfo = false;
            this.m_txtDispartLeftLeukocyte.m_BlnPartControl = false;
            this.m_txtDispartLeftLeukocyte.m_BlnReadOnly = false;
            this.m_txtDispartLeftLeukocyte.m_BlnUnderLineDST = false;
            this.m_txtDispartLeftLeukocyte.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDispartLeftLeukocyte.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDispartLeftLeukocyte.m_IntCanModifyTime = 6;
            this.m_txtDispartLeftLeukocyte.m_IntPartControlLength = 0;
            this.m_txtDispartLeftLeukocyte.m_IntPartControlStartIndex = 0;
            this.m_txtDispartLeftLeukocyte.m_StrUserID = "";
            this.m_txtDispartLeftLeukocyte.m_StrUserName = "";
            this.m_txtDispartLeftLeukocyte.Multiline = false;
            this.m_txtDispartLeftLeukocyte.Name = "m_txtDispartLeftLeukocyte";
            this.m_txtDispartLeftLeukocyte.Size = new System.Drawing.Size(76, 21);
            this.m_txtDispartLeftLeukocyte.TabIndex = 643;
            this.m_txtDispartLeftLeukocyte.Text = "";
            this.m_txtDispartLeftLeukocyte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblMonocyte
            // 
            this.lblMonocyte.AutoSize = true;
            this.lblMonocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonocyte.Location = new System.Drawing.Point(104, 108);
            this.lblMonocyte.Name = "lblMonocyte";
            this.lblMonocyte.Size = new System.Drawing.Size(63, 14);
            this.lblMonocyte.TabIndex = 501;
            this.lblMonocyte.Text = "单核细胞";
            this.lblMonocyte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtMonocyte
            // 
            this.m_txtMonocyte.BackColor = System.Drawing.Color.White;
            this.m_txtMonocyte.ForeColor = System.Drawing.Color.Black;
            this.m_txtMonocyte.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMonocyte.Location = new System.Drawing.Point(168, 104);
            this.m_txtMonocyte.m_BlnIgnoreUserInfo = false;
            this.m_txtMonocyte.m_BlnPartControl = false;
            this.m_txtMonocyte.m_BlnReadOnly = false;
            this.m_txtMonocyte.m_BlnUnderLineDST = false;
            this.m_txtMonocyte.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMonocyte.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMonocyte.m_IntCanModifyTime = 6;
            this.m_txtMonocyte.m_IntPartControlLength = 0;
            this.m_txtMonocyte.m_IntPartControlStartIndex = 0;
            this.m_txtMonocyte.m_StrUserID = "";
            this.m_txtMonocyte.m_StrUserName = "";
            this.m_txtMonocyte.Multiline = false;
            this.m_txtMonocyte.Name = "m_txtMonocyte";
            this.m_txtMonocyte.Size = new System.Drawing.Size(100, 21);
            this.m_txtMonocyte.TabIndex = 644;
            this.m_txtMonocyte.Text = "";
            this.m_txtMonocyte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblMonocyteUnit
            // 
            this.lblMonocyteUnit.AutoSize = true;
            this.lblMonocyteUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonocyteUnit.Location = new System.Drawing.Point(272, 108);
            this.lblMonocyteUnit.Name = "lblMonocyteUnit";
            this.lblMonocyteUnit.Size = new System.Drawing.Size(14, 14);
            this.lblMonocyteUnit.TabIndex = 501;
            this.lblMonocyteUnit.Text = "%";
            this.lblMonocyteUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcidophil
            // 
            this.lblAcidophil.AutoSize = true;
            this.lblAcidophil.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAcidophil.Location = new System.Drawing.Point(328, 108);
            this.lblAcidophil.Name = "lblAcidophil";
            this.lblAcidophil.Size = new System.Drawing.Size(63, 14);
            this.lblAcidophil.TabIndex = 501;
            this.lblAcidophil.Text = "嗜酸细胞";
            this.lblAcidophil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtAcidophil
            // 
            this.m_txtAcidophil.BackColor = System.Drawing.Color.White;
            this.m_txtAcidophil.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAcidophil.ForeColor = System.Drawing.Color.Black;
            this.m_txtAcidophil.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAcidophil.Location = new System.Drawing.Point(392, 104);
            this.m_txtAcidophil.m_BlnIgnoreUserInfo = false;
            this.m_txtAcidophil.m_BlnPartControl = false;
            this.m_txtAcidophil.m_BlnReadOnly = false;
            this.m_txtAcidophil.m_BlnUnderLineDST = false;
            this.m_txtAcidophil.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAcidophil.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAcidophil.m_IntCanModifyTime = 6;
            this.m_txtAcidophil.m_IntPartControlLength = 0;
            this.m_txtAcidophil.m_IntPartControlStartIndex = 0;
            this.m_txtAcidophil.m_StrUserID = "";
            this.m_txtAcidophil.m_StrUserName = "";
            this.m_txtAcidophil.Multiline = false;
            this.m_txtAcidophil.Name = "m_txtAcidophil";
            this.m_txtAcidophil.Size = new System.Drawing.Size(84, 21);
            this.m_txtAcidophil.TabIndex = 645;
            this.m_txtAcidophil.Text = "";
            this.m_txtAcidophil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblAcidophilUnit
            // 
            this.lblAcidophilUnit.AutoSize = true;
            this.lblAcidophilUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAcidophilUnit.Location = new System.Drawing.Point(480, 108);
            this.lblAcidophilUnit.Name = "lblAcidophilUnit";
            this.lblAcidophilUnit.Size = new System.Drawing.Size(14, 14);
            this.lblAcidophilUnit.TabIndex = 501;
            this.lblAcidophilUnit.Text = "%";
            this.lblAcidophilUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBasophil
            // 
            this.m_txtBasophil.BackColor = System.Drawing.Color.White;
            this.m_txtBasophil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBasophil.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBasophil.ForeColor = System.Drawing.Color.Black;
            this.m_txtBasophil.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBasophil.Location = new System.Drawing.Point(608, 104);
            this.m_txtBasophil.m_BlnIgnoreUserInfo = false;
            this.m_txtBasophil.m_BlnPartControl = false;
            this.m_txtBasophil.m_BlnReadOnly = false;
            this.m_txtBasophil.m_BlnUnderLineDST = false;
            this.m_txtBasophil.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBasophil.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBasophil.m_IntCanModifyTime = 6;
            this.m_txtBasophil.m_IntPartControlLength = 0;
            this.m_txtBasophil.m_IntPartControlStartIndex = 0;
            this.m_txtBasophil.m_StrUserID = "";
            this.m_txtBasophil.m_StrUserName = "";
            this.m_txtBasophil.Multiline = false;
            this.m_txtBasophil.Name = "m_txtBasophil";
            this.m_txtBasophil.Size = new System.Drawing.Size(76, 21);
            this.m_txtBasophil.TabIndex = 646;
            this.m_txtBasophil.Text = "";
            this.m_txtBasophil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblBasophilUnit
            // 
            this.lblBasophilUnit.AutoSize = true;
            this.lblBasophilUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBasophilUnit.Location = new System.Drawing.Point(688, 108);
            this.lblBasophilUnit.Name = "lblBasophilUnit";
            this.lblBasophilUnit.Size = new System.Drawing.Size(14, 14);
            this.lblBasophilUnit.TabIndex = 501;
            this.lblBasophilUnit.Text = "%";
            this.lblBasophilUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBasophil
            // 
            this.lblBasophil.AutoSize = true;
            this.lblBasophil.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBasophil.Location = new System.Drawing.Point(544, 108);
            this.lblBasophil.Name = "lblBasophil";
            this.lblBasophil.Size = new System.Drawing.Size(63, 14);
            this.lblBasophil.TabIndex = 501;
            this.lblBasophil.Text = "嗜碱细胞";
            this.lblBasophil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBloodK
            // 
            this.m_txtBloodK.BackColor = System.Drawing.Color.White;
            this.m_txtBloodK.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBloodK.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodK.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodK.Location = new System.Drawing.Point(36, 140);
            this.m_txtBloodK.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodK.m_BlnPartControl = false;
            this.m_txtBloodK.m_BlnReadOnly = false;
            this.m_txtBloodK.m_BlnUnderLineDST = false;
            this.m_txtBloodK.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodK.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodK.m_IntCanModifyTime = 6;
            this.m_txtBloodK.m_IntPartControlLength = 0;
            this.m_txtBloodK.m_IntPartControlStartIndex = 0;
            this.m_txtBloodK.m_StrUserID = "";
            this.m_txtBloodK.m_StrUserName = "";
            this.m_txtBloodK.Multiline = false;
            this.m_txtBloodK.Name = "m_txtBloodK";
            this.m_txtBloodK.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodK.TabIndex = 647;
            this.m_txtBloodK.Text = "";
            this.m_txtBloodK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblBloodKUnit
            // 
            this.lblBloodKUnit.AutoSize = true;
            this.lblBloodKUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodKUnit.Location = new System.Drawing.Point(108, 140);
            this.lblBloodKUnit.Name = "lblBloodKUnit";
            this.lblBloodKUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBloodKUnit.TabIndex = 501;
            this.lblBloodKUnit.Text = "mmol/L";
            this.lblBloodKUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodK
            // 
            this.lblBloodK.AutoSize = true;
            this.lblBloodK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodK.Location = new System.Drawing.Point(4, 144);
            this.lblBloodK.Name = "lblBloodK";
            this.lblBloodK.Size = new System.Drawing.Size(35, 14);
            this.lblBloodK.TabIndex = 501;
            this.lblBloodK.Text = "血钾";
            this.lblBloodK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodNaUnit
            // 
            this.lblBloodNaUnit.AutoSize = true;
            this.lblBloodNaUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodNaUnit.Location = new System.Drawing.Point(280, 140);
            this.lblBloodNaUnit.Name = "lblBloodNaUnit";
            this.lblBloodNaUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBloodNaUnit.TabIndex = 501;
            this.lblBloodNaUnit.Text = "mmol/L";
            this.lblBloodNaUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodNa
            // 
            this.lblBloodNa.AutoSize = true;
            this.lblBloodNa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodNa.Location = new System.Drawing.Point(172, 144);
            this.lblBloodNa.Name = "lblBloodNa";
            this.lblBloodNa.Size = new System.Drawing.Size(35, 14);
            this.lblBloodNa.TabIndex = 501;
            this.lblBloodNa.Text = "血钠";
            this.lblBloodNa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBloodNa
            // 
            this.m_txtBloodNa.BackColor = System.Drawing.Color.White;
            this.m_txtBloodNa.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBloodNa.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodNa.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodNa.Location = new System.Drawing.Point(208, 140);
            this.m_txtBloodNa.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodNa.m_BlnPartControl = false;
            this.m_txtBloodNa.m_BlnReadOnly = false;
            this.m_txtBloodNa.m_BlnUnderLineDST = false;
            this.m_txtBloodNa.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodNa.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodNa.m_IntCanModifyTime = 6;
            this.m_txtBloodNa.m_IntPartControlLength = 0;
            this.m_txtBloodNa.m_IntPartControlStartIndex = 0;
            this.m_txtBloodNa.m_StrUserID = "";
            this.m_txtBloodNa.m_StrUserName = "";
            this.m_txtBloodNa.Multiline = false;
            this.m_txtBloodNa.Name = "m_txtBloodNa";
            this.m_txtBloodNa.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodNa.TabIndex = 648;
            this.m_txtBloodNa.Text = "";
            this.m_txtBloodNa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtBloodCl
            // 
            this.m_txtBloodCl.BackColor = System.Drawing.Color.White;
            this.m_txtBloodCl.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBloodCl.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodCl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodCl.Location = new System.Drawing.Point(380, 140);
            this.m_txtBloodCl.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodCl.m_BlnPartControl = false;
            this.m_txtBloodCl.m_BlnReadOnly = false;
            this.m_txtBloodCl.m_BlnUnderLineDST = false;
            this.m_txtBloodCl.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodCl.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodCl.m_IntCanModifyTime = 6;
            this.m_txtBloodCl.m_IntPartControlLength = 0;
            this.m_txtBloodCl.m_IntPartControlStartIndex = 0;
            this.m_txtBloodCl.m_StrUserID = "";
            this.m_txtBloodCl.m_StrUserName = "";
            this.m_txtBloodCl.Multiline = false;
            this.m_txtBloodCl.Name = "m_txtBloodCl";
            this.m_txtBloodCl.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodCl.TabIndex = 649;
            this.m_txtBloodCl.Text = "";
            this.m_txtBloodCl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblBloodClUnit
            // 
            this.lblBloodClUnit.AutoSize = true;
            this.lblBloodClUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodClUnit.Location = new System.Drawing.Point(452, 140);
            this.lblBloodClUnit.Name = "lblBloodClUnit";
            this.lblBloodClUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBloodClUnit.TabIndex = 501;
            this.lblBloodClUnit.Text = "mmol/L";
            this.lblBloodClUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodCl
            // 
            this.lblBloodCl.AutoSize = true;
            this.lblBloodCl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodCl.Location = new System.Drawing.Point(344, 144);
            this.lblBloodCl.Name = "lblBloodCl";
            this.lblBloodCl.Size = new System.Drawing.Size(35, 14);
            this.lblBloodCl.TabIndex = 501;
            this.lblBloodCl.Text = "血氯";
            this.lblBloodCl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodSugarUnit
            // 
            this.lblBloodSugarUnit.AutoSize = true;
            this.lblBloodSugarUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodSugarUnit.Location = new System.Drawing.Point(624, 140);
            this.lblBloodSugarUnit.Name = "lblBloodSugarUnit";
            this.lblBloodSugarUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBloodSugarUnit.TabIndex = 501;
            this.lblBloodSugarUnit.Text = "mmol/L";
            this.lblBloodSugarUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodSugar
            // 
            this.lblBloodSugar.AutoSize = true;
            this.lblBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodSugar.Location = new System.Drawing.Point(516, 144);
            this.lblBloodSugar.Name = "lblBloodSugar";
            this.lblBloodSugar.Size = new System.Drawing.Size(35, 14);
            this.lblBloodSugar.TabIndex = 501;
            this.lblBloodSugar.Text = "血糖";
            this.lblBloodSugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBloodSugar
            // 
            this.m_txtBloodSugar.BackColor = System.Drawing.Color.White;
            this.m_txtBloodSugar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBloodSugar.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodSugar.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodSugar.Location = new System.Drawing.Point(552, 140);
            this.m_txtBloodSugar.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodSugar.m_BlnPartControl = false;
            this.m_txtBloodSugar.m_BlnReadOnly = false;
            this.m_txtBloodSugar.m_BlnUnderLineDST = false;
            this.m_txtBloodSugar.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodSugar.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodSugar.m_IntCanModifyTime = 6;
            this.m_txtBloodSugar.m_IntPartControlLength = 0;
            this.m_txtBloodSugar.m_IntPartControlStartIndex = 0;
            this.m_txtBloodSugar.m_StrUserID = "";
            this.m_txtBloodSugar.m_StrUserName = "";
            this.m_txtBloodSugar.Multiline = false;
            this.m_txtBloodSugar.Name = "m_txtBloodSugar";
            this.m_txtBloodSugar.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodSugar.TabIndex = 750;
            this.m_txtBloodSugar.Text = "";
            this.m_txtBloodSugar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtBloodCa
            // 
            this.m_txtBloodCa.BackColor = System.Drawing.Color.White;
            this.m_txtBloodCa.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBloodCa.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodCa.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodCa.Location = new System.Drawing.Point(208, 164);
            this.m_txtBloodCa.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodCa.m_BlnPartControl = false;
            this.m_txtBloodCa.m_BlnReadOnly = false;
            this.m_txtBloodCa.m_BlnUnderLineDST = false;
            this.m_txtBloodCa.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodCa.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodCa.m_IntCanModifyTime = 6;
            this.m_txtBloodCa.m_IntPartControlLength = 0;
            this.m_txtBloodCa.m_IntPartControlStartIndex = 0;
            this.m_txtBloodCa.m_StrUserID = "";
            this.m_txtBloodCa.m_StrUserName = "";
            this.m_txtBloodCa.Multiline = false;
            this.m_txtBloodCa.Name = "m_txtBloodCa";
            this.m_txtBloodCa.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodCa.TabIndex = 752;
            this.m_txtBloodCa.Text = "";
            this.m_txtBloodCa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblBUNUnit
            // 
            this.lblBUNUnit.AutoSize = true;
            this.lblBUNUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBUNUnit.Location = new System.Drawing.Point(108, 164);
            this.lblBUNUnit.Name = "lblBUNUnit";
            this.lblBUNUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBUNUnit.TabIndex = 501;
            this.lblBUNUnit.Text = "mmol/L";
            this.lblBUNUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBUN
            // 
            this.lblBUN.AutoSize = true;
            this.lblBUN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBUN.Location = new System.Drawing.Point(8, 164);
            this.lblBUN.Name = "lblBUN";
            this.lblBUN.Size = new System.Drawing.Size(28, 14);
            this.lblBUN.TabIndex = 501;
            this.lblBUN.Text = "BUN";
            this.lblBUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBUN
            // 
            this.m_txtBUN.BackColor = System.Drawing.Color.White;
            this.m_txtBUN.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBUN.ForeColor = System.Drawing.Color.Black;
            this.m_txtBUN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBUN.Location = new System.Drawing.Point(36, 164);
            this.m_txtBUN.m_BlnIgnoreUserInfo = false;
            this.m_txtBUN.m_BlnPartControl = false;
            this.m_txtBUN.m_BlnReadOnly = false;
            this.m_txtBUN.m_BlnUnderLineDST = false;
            this.m_txtBUN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBUN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBUN.m_IntCanModifyTime = 6;
            this.m_txtBUN.m_IntPartControlLength = 0;
            this.m_txtBUN.m_IntPartControlStartIndex = 0;
            this.m_txtBUN.m_StrUserID = "";
            this.m_txtBUN.m_StrUserName = "";
            this.m_txtBUN.Multiline = false;
            this.m_txtBUN.Name = "m_txtBUN";
            this.m_txtBUN.Size = new System.Drawing.Size(72, 21);
            this.m_txtBUN.TabIndex = 751;
            this.m_txtBUN.Text = "";
            this.m_txtBUN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblBloodCaUnit
            // 
            this.lblBloodCaUnit.AutoSize = true;
            this.lblBloodCaUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodCaUnit.Location = new System.Drawing.Point(280, 164);
            this.lblBloodCaUnit.Name = "lblBloodCaUnit";
            this.lblBloodCaUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBloodCaUnit.TabIndex = 501;
            this.lblBloodCaUnit.Text = "mmol/L";
            this.lblBloodCaUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodCa
            // 
            this.lblBloodCa.AutoSize = true;
            this.lblBloodCa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodCa.Location = new System.Drawing.Point(172, 168);
            this.lblBloodCa.Name = "lblBloodCa";
            this.lblBloodCa.Size = new System.Drawing.Size(35, 14);
            this.lblBloodCa.TabIndex = 501;
            this.lblBloodCa.Text = "血钙";
            this.lblBloodCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBloodAnalyse
            // 
            this.lblBloodAnalyse.AutoSize = true;
            this.lblBloodAnalyse.Location = new System.Drawing.Point(4, 212);
            this.lblBloodAnalyse.Name = "lblBloodAnalyse";
            this.lblBloodAnalyse.Size = new System.Drawing.Size(59, 12);
            this.lblBloodAnalyse.TabIndex = 501;
            this.lblBloodAnalyse.Text = "血气分析:";
            // 
            // m_txtPH
            // 
            this.m_txtPH.BackColor = System.Drawing.Color.White;
            this.m_txtPH.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPH.ForeColor = System.Drawing.Color.Black;
            this.m_txtPH.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPH.Location = new System.Drawing.Point(92, 212);
            this.m_txtPH.m_BlnIgnoreUserInfo = false;
            this.m_txtPH.m_BlnPartControl = false;
            this.m_txtPH.m_BlnReadOnly = false;
            this.m_txtPH.m_BlnUnderLineDST = false;
            this.m_txtPH.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPH.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPH.m_IntCanModifyTime = 6;
            this.m_txtPH.m_IntPartControlLength = 0;
            this.m_txtPH.m_IntPartControlStartIndex = 0;
            this.m_txtPH.m_StrUserID = "";
            this.m_txtPH.m_StrUserName = "";
            this.m_txtPH.Multiline = false;
            this.m_txtPH.Name = "m_txtPH";
            this.m_txtPH.Size = new System.Drawing.Size(68, 21);
            this.m_txtPH.TabIndex = 753;
            this.m_txtPH.Text = "";
            this.m_txtPH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPH.Location = new System.Drawing.Point(72, 212);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(21, 14);
            this.lblPH.TabIndex = 501;
            this.lblPH.Text = "PH";
            this.lblPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaO2Unit
            // 
            this.lblPaO2Unit.AutoSize = true;
            this.lblPaO2Unit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPaO2Unit.Location = new System.Drawing.Point(268, 212);
            this.lblPaO2Unit.Name = "lblPaO2Unit";
            this.lblPaO2Unit.Size = new System.Drawing.Size(35, 14);
            this.lblPaO2Unit.TabIndex = 501;
            this.lblPaO2Unit.Text = "mmHg";
            this.lblPaO2Unit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPaO2
            // 
            this.m_txtPaO2.BackColor = System.Drawing.Color.White;
            this.m_txtPaO2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPaO2.ForeColor = System.Drawing.Color.Black;
            this.m_txtPaO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPaO2.Location = new System.Drawing.Point(200, 212);
            this.m_txtPaO2.m_BlnIgnoreUserInfo = false;
            this.m_txtPaO2.m_BlnPartControl = false;
            this.m_txtPaO2.m_BlnReadOnly = false;
            this.m_txtPaO2.m_BlnUnderLineDST = false;
            this.m_txtPaO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPaO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPaO2.m_IntCanModifyTime = 6;
            this.m_txtPaO2.m_IntPartControlLength = 0;
            this.m_txtPaO2.m_IntPartControlStartIndex = 0;
            this.m_txtPaO2.m_StrUserID = "";
            this.m_txtPaO2.m_StrUserName = "";
            this.m_txtPaO2.Multiline = false;
            this.m_txtPaO2.Name = "m_txtPaO2";
            this.m_txtPaO2.Size = new System.Drawing.Size(68, 21);
            this.m_txtPaO2.TabIndex = 754;
            this.m_txtPaO2.Text = "";
            this.m_txtPaO2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPaO2
            // 
            this.lblPaO2.AutoSize = true;
            this.lblPaO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPaO2.Location = new System.Drawing.Point(164, 212);
            this.lblPaO2.Name = "lblPaO2";
            this.lblPaO2.Size = new System.Drawing.Size(35, 14);
            this.lblPaO2.TabIndex = 501;
            this.lblPaO2.Text = "PaO2";
            this.lblPaO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaCO2Unit
            // 
            this.lblPaCO2Unit.AutoSize = true;
            this.lblPaCO2Unit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPaCO2Unit.Location = new System.Drawing.Point(420, 212);
            this.lblPaCO2Unit.Name = "lblPaCO2Unit";
            this.lblPaCO2Unit.Size = new System.Drawing.Size(35, 14);
            this.lblPaCO2Unit.TabIndex = 501;
            this.lblPaCO2Unit.Text = "mmHg";
            this.lblPaCO2Unit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPaCO2
            // 
            this.m_txtPaCO2.BackColor = System.Drawing.Color.White;
            this.m_txtPaCO2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPaCO2.ForeColor = System.Drawing.Color.Black;
            this.m_txtPaCO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPaCO2.Location = new System.Drawing.Point(352, 212);
            this.m_txtPaCO2.m_BlnIgnoreUserInfo = false;
            this.m_txtPaCO2.m_BlnPartControl = false;
            this.m_txtPaCO2.m_BlnReadOnly = false;
            this.m_txtPaCO2.m_BlnUnderLineDST = false;
            this.m_txtPaCO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPaCO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPaCO2.m_IntCanModifyTime = 6;
            this.m_txtPaCO2.m_IntPartControlLength = 0;
            this.m_txtPaCO2.m_IntPartControlStartIndex = 0;
            this.m_txtPaCO2.m_StrUserID = "";
            this.m_txtPaCO2.m_StrUserName = "";
            this.m_txtPaCO2.Multiline = false;
            this.m_txtPaCO2.Name = "m_txtPaCO2";
            this.m_txtPaCO2.Size = new System.Drawing.Size(68, 21);
            this.m_txtPaCO2.TabIndex = 755;
            this.m_txtPaCO2.Text = "";
            this.m_txtPaCO2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblPaCO2
            // 
            this.lblPaCO2.AutoSize = true;
            this.lblPaCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPaCO2.Location = new System.Drawing.Point(308, 212);
            this.lblPaCO2.Name = "lblPaCO2";
            this.lblPaCO2.Size = new System.Drawing.Size(42, 14);
            this.lblPaCO2.TabIndex = 501;
            this.lblPaCO2.Text = "PaCO2";
            this.lblPaCO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHCO3
            // 
            this.lblHCO3.AutoSize = true;
            this.lblHCO3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHCO3.Location = new System.Drawing.Point(600, 212);
            this.lblHCO3.Name = "lblHCO3";
            this.lblHCO3.Size = new System.Drawing.Size(35, 14);
            this.lblHCO3.TabIndex = 501;
            this.lblHCO3.Text = "HCO3";
            this.lblHCO3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHCO3Unit
            // 
            this.lblHCO3Unit.AutoSize = true;
            this.lblHCO3Unit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHCO3Unit.Location = new System.Drawing.Point(700, 212);
            this.lblHCO3Unit.Name = "lblHCO3Unit";
            this.lblHCO3Unit.Size = new System.Drawing.Size(49, 14);
            this.lblHCO3Unit.TabIndex = 501;
            this.lblHCO3Unit.Text = "mmol/L";
            this.lblHCO3Unit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtHCO3
            // 
            this.m_txtHCO3.BackColor = System.Drawing.Color.White;
            this.m_txtHCO3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtHCO3.ForeColor = System.Drawing.Color.Black;
            this.m_txtHCO3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHCO3.Location = new System.Drawing.Point(632, 212);
            this.m_txtHCO3.m_BlnIgnoreUserInfo = false;
            this.m_txtHCO3.m_BlnPartControl = false;
            this.m_txtHCO3.m_BlnReadOnly = false;
            this.m_txtHCO3.m_BlnUnderLineDST = false;
            this.m_txtHCO3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHCO3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHCO3.m_IntCanModifyTime = 6;
            this.m_txtHCO3.m_IntPartControlLength = 0;
            this.m_txtHCO3.m_IntPartControlStartIndex = 0;
            this.m_txtHCO3.m_StrUserID = "";
            this.m_txtHCO3.m_StrUserName = "";
            this.m_txtHCO3.Multiline = false;
            this.m_txtHCO3.Name = "m_txtHCO3";
            this.m_txtHCO3.Size = new System.Drawing.Size(68, 21);
            this.m_txtHCO3.TabIndex = 856;
            this.m_txtHCO3.Text = "";
            this.m_txtHCO3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_txtWoundInfo
            // 
            this.m_txtWoundInfo.AccessibleDescription = "伤口、引流物情况";
            this.m_txtWoundInfo.BackColor = System.Drawing.Color.White;
            this.m_txtWoundInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtWoundInfo.ForeColor = System.Drawing.Color.Black;
            this.m_txtWoundInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWoundInfo.Location = new System.Drawing.Point(8, 268);
            this.m_txtWoundInfo.m_BlnIgnoreUserInfo = false;
            this.m_txtWoundInfo.m_BlnPartControl = false;
            this.m_txtWoundInfo.m_BlnReadOnly = false;
            this.m_txtWoundInfo.m_BlnUnderLineDST = false;
            this.m_txtWoundInfo.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWoundInfo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWoundInfo.m_IntCanModifyTime = 6;
            this.m_txtWoundInfo.m_IntPartControlLength = 0;
            this.m_txtWoundInfo.m_IntPartControlStartIndex = 0;
            this.m_txtWoundInfo.m_StrUserID = "";
            this.m_txtWoundInfo.m_StrUserName = "";
            this.m_txtWoundInfo.Name = "m_txtWoundInfo";
            this.m_txtWoundInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.m_txtWoundInfo.Size = new System.Drawing.Size(736, 172);
            this.m_txtWoundInfo.TabIndex = 957;
            this.m_txtWoundInfo.Text = "";
            this.m_txtWoundInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // lblWoundInfo
            // 
            this.lblWoundInfo.AutoSize = true;
            this.lblWoundInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWoundInfo.Location = new System.Drawing.Point(8, 248);
            this.lblWoundInfo.Name = "lblWoundInfo";
            this.lblWoundInfo.Size = new System.Drawing.Size(119, 14);
            this.lblWoundInfo.TabIndex = 501;
            this.lblWoundInfo.Text = "伤口、引流物情况";
            this.lblWoundInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromDeptDoctor
            // 
            this.lblFromDeptDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFromDeptDoctor.Location = new System.Drawing.Point(288, 572);
            this.lblFromDeptDoctor.Name = "lblFromDeptDoctor";
            this.lblFromDeptDoctor.Size = new System.Drawing.Size(128, 24);
            this.lblFromDeptDoctor.TabIndex = 501;
            this.lblFromDeptDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFromDeptDoctor.Visible = false;
            // 
            // lblToDeptDoctor
            // 
            this.lblToDeptDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToDeptDoctor.Location = new System.Drawing.Point(260, 572);
            this.lblToDeptDoctor.Name = "lblToDeptDoctor";
            this.lblToDeptDoctor.Size = new System.Drawing.Size(128, 24);
            this.lblToDeptDoctor.TabIndex = 501;
            this.lblToDeptDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDispartLeftLeukocyte
            // 
            this.lblDispartLeftLeukocyte.AutoSize = true;
            this.lblDispartLeftLeukocyte.BackColor = System.Drawing.Color.Transparent;
            this.lblDispartLeftLeukocyte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDispartLeftLeukocyte.ForeColor = System.Drawing.Color.Black;
            this.lblDispartLeftLeukocyte.Location = new System.Drawing.Point(500, 84);
            this.lblDispartLeftLeukocyte.Name = "lblDispartLeftLeukocyte";
            this.lblDispartLeftLeukocyte.Size = new System.Drawing.Size(105, 14);
            this.lblDispartLeftLeukocyte.TabIndex = 501;
            this.lblDispartLeftLeukocyte.Text = "分叶中性白细胞";
            this.lblDispartLeftLeukocyte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblTurnBaseDeptName
            // 
            this.m_lblTurnBaseDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTurnBaseDeptName.Location = new System.Drawing.Point(100, 132);
            this.m_lblTurnBaseDeptName.Name = "m_lblTurnBaseDeptName";
            this.m_lblTurnBaseDeptName.Size = new System.Drawing.Size(324, 24);
            this.m_lblTurnBaseDeptName.TabIndex = 210;
            // 
            // m_lblInPatientDate
            // 
            this.m_lblInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInPatientDate.Location = new System.Drawing.Point(96, 16);
            this.m_lblInPatientDate.Name = "m_lblInPatientDate";
            this.m_lblInPatientDate.Size = new System.Drawing.Size(636, 24);
            this.m_lblInPatientDate.TabIndex = 501;
            // 
            // m_lblToDeptDoctor
            // 
            this.m_lblToDeptDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblToDeptDoctor.Location = new System.Drawing.Point(396, 572);
            this.m_lblToDeptDoctor.Name = "m_lblToDeptDoctor";
            this.m_lblToDeptDoctor.Size = new System.Drawing.Size(88, 24);
            this.m_lblToDeptDoctor.TabIndex = 501;
            // 
            // m_lblFromDeptDoctor
            // 
            this.m_lblFromDeptDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblFromDeptDoctor.Location = new System.Drawing.Point(317, 571);
            this.m_lblFromDeptDoctor.Name = "m_lblFromDeptDoctor";
            this.m_lblFromDeptDoctor.Size = new System.Drawing.Size(88, 24);
            this.m_lblFromDeptDoctor.TabIndex = 501;
            this.m_lblFromDeptDoctor.Visible = false;
            // 
            // m_trvTime
            // 
            this.m_trvTime.BackColor = System.Drawing.Color.White;
            this.m_trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvTime.ForeColor = System.Drawing.Color.Black;
            this.m_trvTime.ItemHeight = 18;
            this.m_trvTime.Location = new System.Drawing.Point(6, 37);
            this.m_trvTime.Name = "m_trvTime";
            this.m_trvTime.ShowRootLines = false;
            this.m_trvTime.Size = new System.Drawing.Size(191, 54);
            this.m_trvTime.TabIndex = 103;
            this.m_trvTime.Visible = false;
            this.m_trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvTime_AfterSelect);
            this.m_trvTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_pdcRecord
            // 
            this.m_pdcRecord.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcRecord_PrintPage);
            // 
            // m_ppdRecord
            // 
            this.m_ppdRecord.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_ppdRecord.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_ppdRecord.ClientSize = new System.Drawing.Size(400, 300);
            this.m_ppdRecord.Document = this.m_pdcRecord;
            this.m_ppdRecord.Enabled = true;
            this.m_ppdRecord.Icon = ((System.Drawing.Icon)(resources.GetObject("m_ppdRecord.Icon")));
            this.m_ppdRecord.Name = "m_ppdRecord";
            this.m_ppdRecord.Visible = false;
            // 
            // m_cmuRichTextBoxMenu
            // 
            this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDoubleStrikeOutDelete});
            // 
            // mniDoubleStrikeOutDelete
            // 
            this.mniDoubleStrikeOutDelete.Index = 0;
            this.mniDoubleStrikeOutDelete.Text = "双划线删除";
            this.mniDoubleStrikeOutDelete.Click += new System.EventHandler(this.mniDoubleStrikeOutDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(460, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 504;
            this.label1.Text = "BE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBEUnit
            // 
            this.lblBEUnit.AutoSize = true;
            this.lblBEUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBEUnit.Location = new System.Drawing.Point(548, 212);
            this.lblBEUnit.Name = "lblBEUnit";
            this.lblBEUnit.Size = new System.Drawing.Size(49, 14);
            this.lblBEUnit.TabIndex = 503;
            this.lblBEUnit.Text = "mmol/L";
            this.lblBEUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBE
            // 
            this.m_txtBE.BackColor = System.Drawing.Color.White;
            this.m_txtBE.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtBE.ForeColor = System.Drawing.Color.Black;
            this.m_txtBE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBE.Location = new System.Drawing.Point(480, 212);
            this.m_txtBE.m_BlnIgnoreUserInfo = false;
            this.m_txtBE.m_BlnPartControl = false;
            this.m_txtBE.m_BlnReadOnly = false;
            this.m_txtBE.m_BlnUnderLineDST = false;
            this.m_txtBE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBE.m_IntCanModifyTime = 6;
            this.m_txtBE.m_IntPartControlLength = 0;
            this.m_txtBE.m_IntPartControlStartIndex = 0;
            this.m_txtBE.m_StrUserID = "";
            this.m_txtBE.m_StrUserName = "";
            this.m_txtBE.Multiline = false;
            this.m_txtBE.Name = "m_txtBE";
            this.m_txtBE.Size = new System.Drawing.Size(68, 21);
            this.m_txtBE.TabIndex = 802;
            this.m_txtBE.Text = "";
            // 
            // m_trvLabCheckSendTime
            // 
            this.m_trvLabCheckSendTime.BackColor = System.Drawing.Color.White;
            this.m_trvLabCheckSendTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvLabCheckSendTime.ForeColor = System.Drawing.Color.Black;
            this.m_trvLabCheckSendTime.ItemHeight = 18;
            this.m_trvLabCheckSendTime.Location = new System.Drawing.Point(246, 145);
            this.m_trvLabCheckSendTime.Name = "m_trvLabCheckSendTime";
            this.m_trvLabCheckSendTime.ShowRootLines = false;
            this.m_trvLabCheckSendTime.Size = new System.Drawing.Size(36, 24);
            this.m_trvLabCheckSendTime.TabIndex = 104;
            this.m_trvLabCheckSendTime.Visible = false;
            this.m_trvLabCheckSendTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthKeyDown);
            // 
            // m_cmdSetLabCheckResult
            // 
            this.m_cmdSetLabCheckResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSetLabCheckResult.DefaultScheme = true;
            this.m_cmdSetLabCheckResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSetLabCheckResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSetLabCheckResult.Hint = "";
            this.m_cmdSetLabCheckResult.Location = new System.Drawing.Point(124, 8);
            this.m_cmdSetLabCheckResult.Name = "m_cmdSetLabCheckResult";
            this.m_cmdSetLabCheckResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSetLabCheckResult.Size = new System.Drawing.Size(84, 32);
            this.m_cmdSetLabCheckResult.TabIndex = 510;
            this.m_cmdSetLabCheckResult.Text = "最新结果";
            this.m_cmdSetLabCheckResult.Click += new System.EventHandler(this.m_cmdSetLabCheckResult_Click);
            this.m_cmdSetLabCheckResult.Leave += new System.EventHandler(this.m_lsvJY_ItemChoice_Leave);
            // 
            // m_cmdGetDovueData
            // 
            this.m_cmdGetDovueData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdGetDovueData.DefaultScheme = true;
            this.m_cmdGetDovueData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetDovueData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdGetDovueData.Hint = "";
            this.m_cmdGetDovueData.Location = new System.Drawing.Point(12, 8);
            this.m_cmdGetDovueData.Name = "m_cmdGetDovueData";
            this.m_cmdGetDovueData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetDovueData.Size = new System.Drawing.Size(132, 32);
            this.m_cmdGetDovueData.TabIndex = 300;
            this.m_cmdGetDovueData.Text = "监护仪结果";
            this.m_cmdGetDovueData.Click += new System.EventHandler(this.m_cmdGetDovueData_Click);
            // 
            // m_lsvJY_ItemChoice
            // 
            this.m_lsvJY_ItemChoice.BackColor = System.Drawing.Color.White;
            this.m_lsvJY_ItemChoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvJY_ItemChoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPat_c_name,
            this.clmSendDate});
            this.m_lsvJY_ItemChoice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvJY_ItemChoice.ForeColor = System.Drawing.Color.Black;
            this.m_lsvJY_ItemChoice.FullRowSelect = true;
            this.m_lsvJY_ItemChoice.GridLines = true;
            this.m_lsvJY_ItemChoice.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvJY_ItemChoice.Location = new System.Drawing.Point(180, 84);
            this.m_lsvJY_ItemChoice.Name = "m_lsvJY_ItemChoice";
            this.m_lsvJY_ItemChoice.Size = new System.Drawing.Size(282, 106);
            this.m_lsvJY_ItemChoice.TabIndex = 10000002;
            this.m_lsvJY_ItemChoice.UseCompatibleStateImageBehavior = false;
            this.m_lsvJY_ItemChoice.View = System.Windows.Forms.View.Details;
            this.m_lsvJY_ItemChoice.DoubleClick += new System.EventHandler(this.m_lsvJY_ItemChoice_DoubleClick);
            this.m_lsvJY_ItemChoice.Leave += new System.EventHandler(this.m_lsvJY_ItemChoice_Leave);
            // 
            // clmPat_c_name
            // 
            this.clmPat_c_name.Text = "组合名称";
            this.clmPat_c_name.Width = 100;
            // 
            // clmSendDate
            // 
            this.clmSendDate.Text = "送检时间";
            this.clmSendDate.Width = 180;
            // 
            // lblPltTilte
            // 
            this.lblPltTilte.AutoSize = true;
            this.lblPltTilte.BackColor = System.Drawing.Color.Transparent;
            this.lblPltTilte.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPltTilte.ForeColor = System.Drawing.Color.Black;
            this.lblPltTilte.Location = new System.Drawing.Point(548, 52);
            this.lblPltTilte.Name = "lblPltTilte";
            this.lblPltTilte.Size = new System.Drawing.Size(35, 14);
            this.lblPltTilte.TabIndex = 10000003;
            this.lblPltTilte.Text = " plt";
            this.lblPltTilte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPlt
            // 
            this.m_txtPlt.BackColor = System.Drawing.Color.White;
            this.m_txtPlt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPlt.ForeColor = System.Drawing.Color.Black;
            this.m_txtPlt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPlt.Location = new System.Drawing.Point(584, 48);
            this.m_txtPlt.m_BlnIgnoreUserInfo = false;
            this.m_txtPlt.m_BlnPartControl = false;
            this.m_txtPlt.m_BlnReadOnly = false;
            this.m_txtPlt.m_BlnUnderLineDST = false;
            this.m_txtPlt.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPlt.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPlt.m_IntCanModifyTime = 6;
            this.m_txtPlt.m_IntPartControlLength = 0;
            this.m_txtPlt.m_IntPartControlStartIndex = 0;
            this.m_txtPlt.m_StrUserID = "";
            this.m_txtPlt.m_StrUserName = "";
            this.m_txtPlt.Multiline = false;
            this.m_txtPlt.Name = "m_txtPlt";
            this.m_txtPlt.Size = new System.Drawing.Size(100, 21);
            this.m_txtPlt.TabIndex = 601;
            this.m_txtPlt.Text = "";
            // 
            // lblPltTitle2
            // 
            this.lblPltTitle2.AutoSize = true;
            this.lblPltTitle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPltTitle2.Location = new System.Drawing.Point(688, 48);
            this.lblPltTitle2.Name = "lblPltTitle2";
            this.lblPltTitle2.Size = new System.Drawing.Size(49, 14);
            this.lblPltTitle2.TabIndex = 10000007;
            this.lblPltTitle2.Text = "X10 /L";
            this.lblPltTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPltTitle3
            // 
            this.lblPltTitle3.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPltTitle3.Location = new System.Drawing.Point(712, 44);
            this.lblPltTitle3.Name = "lblPltTitle3";
            this.lblPltTitle3.Size = new System.Drawing.Size(10, 12);
            this.lblPltTitle3.TabIndex = 10000006;
            this.lblPltTitle3.Text = "9";
            this.lblPltTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(588, 568);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000042;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 100;
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(632, 564);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 10000040;
            this.m_txtSign.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(5, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(789, 472);
            this.tabControl1.TabIndex = 10000043;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblInPatientDate);
            this.tabPage1.Controls.Add(this.m_lblInPatientDate);
            this.tabPage1.Controls.Add(this.lblInDiagnose);
            this.tabPage1.Controls.Add(this.m_txtInDiagnose);
            this.tabPage1.Controls.Add(this.lblOperationName);
            this.tabPage1.Controls.Add(this.m_txtOperationName);
            this.tabPage1.Controls.Add(this.lblAnaesthesiaType);
            this.tabPage1.Controls.Add(this.m_txtAnaesthesiaType);
            this.tabPage1.Controls.Add(this.m_lblTurnBaseDept);
            this.tabPage1.Controls.Add(this.m_lblTurnBaseDeptName);
            this.tabPage1.Controls.Add(this.m_lblTurnTime);
            this.tabPage1.Controls.Add(this.m_dtpTurnTime);
            this.tabPage1.Controls.Add(this.lblTurnDiagnose);
            this.tabPage1.Controls.Add(this.m_txtTurnDiagnose);
            this.tabPage1.Controls.Add(this.lblInDiagnoseCourse);
            this.tabPage1.Controls.Add(this.m_txtInDiagnoseCourse);
            this.tabPage1.Controls.Add(this.m_lblTurnInfo);
            this.tabPage1.ImageIndex = 8;
            this.tabPage1.ImageList = this.imageList1;
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(789, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "转情况";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_dtpGetDataTime);
            this.tabPage2.Controls.Add(this.m_cmdGetDovueData);
            this.tabPage2.Controls.Add(this.lblTemperature);
            this.tabPage2.Controls.Add(this.m_txtTemperature);
            this.tabPage2.Controls.Add(this.lblTemperatureUnit);
            this.tabPage2.Controls.Add(this.lblHeartRate);
            this.tabPage2.Controls.Add(this.m_txtHeartRate);
            this.tabPage2.Controls.Add(this.lblHeartRateUnit);
            this.tabPage2.Controls.Add(this.lblPulse);
            this.tabPage2.Controls.Add(this.m_txtPulse);
            this.tabPage2.Controls.Add(this.lblPulseUnit);
            this.tabPage2.Controls.Add(this.lblPressure);
            this.tabPage2.Controls.Add(this.m_txtSystolic);
            this.tabPage2.Controls.Add(this.lblPressureSeperate);
            this.tabPage2.Controls.Add(this.m_txtDiastolic);
            this.tabPage2.Controls.Add(this.lblPressureUnit);
            this.tabPage2.Controls.Add(this.lblMind);
            this.tabPage2.Controls.Add(this.m_txtMind);
            this.tabPage2.Controls.Add(this.lblPupilDiameter1);
            this.tabPage2.Controls.Add(this.m_txtPupilDiameterRight);
            this.tabPage2.Controls.Add(this.m_txtPupilDiameterLeft);
            this.tabPage2.Controls.Add(this.lblPupilDiameter2);
            this.tabPage2.Controls.Add(this.lblPupilDiameterUnit);
            this.tabPage2.Controls.Add(this.lblPupilReflection1);
            this.tabPage2.Controls.Add(this.m_txtPupilReflectionRight);
            this.tabPage2.Controls.Add(this.lblPupilReflection2);
            this.tabPage2.Controls.Add(this.m_txtPupilReflectionLeft);
            this.tabPage2.Controls.Add(this.lblGlasgow1);
            this.tabPage2.Controls.Add(this.m_txtGlasgowValue);
            this.tabPage2.Controls.Add(this.lblGlasgow2);
            this.tabPage2.Controls.Add(this.m_txtGlasgowOpenEye);
            this.tabPage2.Controls.Add(this.lblGlasgow3);
            this.tabPage2.Controls.Add(this.m_txtGlasgowLanguage);
            this.tabPage2.Controls.Add(this.lblGlasgow4);
            this.tabPage2.Controls.Add(this.m_txtGlasgowSport);
            this.tabPage2.Controls.Add(this.lblGlasgow5);
            this.tabPage2.Controls.Add(this.m_txtOther);
            this.tabPage2.ImageIndex = 8;
            this.tabPage2.ImageList = this.imageList1;
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(789, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Title = "监护情况";
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpGetDataTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpGetDataTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpGetDataTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpGetDataTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpGetDataTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpGetDataTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpGetDataTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(148, 12);
            this.m_dtpGetDataTime.m_BlnOnlyTime = false;
            this.m_dtpGetDataTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpGetDataTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpGetDataTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpGetDataTime.Name = "m_dtpGetDataTime";
            this.m_dtpGetDataTime.ReadOnly = false;
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(216, 22);
            this.m_dtpGetDataTime.TabIndex = 502;
            this.m_dtpGetDataTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpGetDataTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblWBCExp);
            this.tabPage3.Controls.Add(this.m_txtHCO3);
            this.tabPage3.Controls.Add(this.lblPltTitle3);
            this.tabPage3.Controls.Add(this.lblNewLabReport);
            this.tabPage3.Controls.Add(this.m_cmdSetLabCheckResult);
            this.tabPage3.Controls.Add(this.lblHB);
            this.tabPage3.Controls.Add(this.m_txtHB);
            this.tabPage3.Controls.Add(this.lblHBUnit);
            this.tabPage3.Controls.Add(this.lblRBC);
            this.tabPage3.Controls.Add(this.m_txtRBC);
            this.tabPage3.Controls.Add(this.lblRBCExp);
            this.tabPage3.Controls.Add(this.lblRBCUnit);
            this.tabPage3.Controls.Add(this.lblWBC);
            this.tabPage3.Controls.Add(this.m_txtWBC);
            this.tabPage3.Controls.Add(this.lblWBCUnit);
            this.tabPage3.Controls.Add(this.lblPltTilte);
            this.tabPage3.Controls.Add(this.m_txtPlt);
            this.tabPage3.Controls.Add(this.lblPltTitle2);
            this.tabPage3.Controls.Add(this.lblLeukocyteType);
            this.tabPage3.Controls.Add(this.m_txtLymphocyte);
            this.tabPage3.Controls.Add(this.LymphocyteUnit);
            this.tabPage3.Controls.Add(this.lblLymphocyte);
            this.tabPage3.Controls.Add(this.lblBandLeukocyte);
            this.tabPage3.Controls.Add(this.m_txtBandLeukocyte);
            this.tabPage3.Controls.Add(this.lblBandLeukocyteUnit);
            this.tabPage3.Controls.Add(this.lblDispartLeftLeukocyte);
            this.tabPage3.Controls.Add(this.m_txtDispartLeftLeukocyte);
            this.tabPage3.Controls.Add(this.lblDispartLeftLeukocyteUnit);
            this.tabPage3.Controls.Add(this.lblMonocyte);
            this.tabPage3.Controls.Add(this.m_txtMonocyte);
            this.tabPage3.Controls.Add(this.lblMonocyteUnit);
            this.tabPage3.Controls.Add(this.lblAcidophil);
            this.tabPage3.Controls.Add(this.m_txtAcidophil);
            this.tabPage3.Controls.Add(this.lblAcidophilUnit);
            this.tabPage3.Controls.Add(this.lblBasophil);
            this.tabPage3.Controls.Add(this.m_txtBasophil);
            this.tabPage3.Controls.Add(this.lblBasophilUnit);
            this.tabPage3.Controls.Add(this.m_txtBloodK);
            this.tabPage3.Controls.Add(this.lblBloodK);
            this.tabPage3.Controls.Add(this.lblBloodKUnit);
            this.tabPage3.Controls.Add(this.lblBloodNa);
            this.tabPage3.Controls.Add(this.m_txtBloodNa);
            this.tabPage3.Controls.Add(this.lblBloodNaUnit);
            this.tabPage3.Controls.Add(this.lblBloodCl);
            this.tabPage3.Controls.Add(this.m_txtBloodCl);
            this.tabPage3.Controls.Add(this.lblBloodClUnit);
            this.tabPage3.Controls.Add(this.lblBloodSugar);
            this.tabPage3.Controls.Add(this.m_txtBloodSugar);
            this.tabPage3.Controls.Add(this.lblBloodSugarUnit);
            this.tabPage3.Controls.Add(this.lblBUN);
            this.tabPage3.Controls.Add(this.m_txtBUN);
            this.tabPage3.Controls.Add(this.lblBUNUnit);
            this.tabPage3.Controls.Add(this.lblBloodCa);
            this.tabPage3.Controls.Add(this.m_txtBloodCa);
            this.tabPage3.Controls.Add(this.lblBloodCaUnit);
            this.tabPage3.Controls.Add(this.lblBloodAnalyse);
            this.tabPage3.Controls.Add(this.lblPH);
            this.tabPage3.Controls.Add(this.m_txtPH);
            this.tabPage3.Controls.Add(this.lblPaO2);
            this.tabPage3.Controls.Add(this.m_txtPaO2);
            this.tabPage3.Controls.Add(this.lblPaO2Unit);
            this.tabPage3.Controls.Add(this.lblPaCO2);
            this.tabPage3.Controls.Add(this.m_txtPaCO2);
            this.tabPage3.Controls.Add(this.lblPaCO2Unit);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.m_txtBE);
            this.tabPage3.Controls.Add(this.lblBEUnit);
            this.tabPage3.Controls.Add(this.lblHCO3);
            this.tabPage3.Controls.Add(this.lblHCO3Unit);
            this.tabPage3.Controls.Add(this.m_lsvJY_ItemChoice);
            this.tabPage3.Controls.Add(this.lblWoundInfo);
            this.tabPage3.Controls.Add(this.m_txtWoundInfo);
            this.tabPage3.ImageIndex = 5;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(789, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Title = "实验室报告";
            // 
            // m_cmdFromDoctor
            // 
            this.m_cmdFromDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdFromDoctor.DefaultScheme = true;
            this.m_cmdFromDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFromDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFromDoctor.Hint = "";
            this.m_cmdFromDoctor.Location = new System.Drawing.Point(551, 53);
            this.m_cmdFromDoctor.Name = "m_cmdFromDoctor";
            this.m_cmdFromDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFromDoctor.Size = new System.Drawing.Size(104, 28);
            this.m_cmdFromDoctor.TabIndex = 10000044;
            // 
            // txtFromDoctor
            // 
            this.txtFromDoctor.AccessibleDescription = "";
            this.txtFromDoctor.AccessibleName = "NoDefault";
            this.txtFromDoctor.BackColor = System.Drawing.Color.White;
            this.txtFromDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFromDoctor.ForeColor = System.Drawing.Color.Black;
            this.txtFromDoctor.Location = new System.Drawing.Point(659, 56);
            this.txtFromDoctor.MaxLength = 7;
            this.txtFromDoctor.Name = "txtFromDoctor";
            this.txtFromDoctor.ReadOnly = true;
            this.txtFromDoctor.Size = new System.Drawing.Size(104, 23);
            this.txtFromDoctor.TabIndex = 10000045;
            // 
            // frmPICUShiftBaseForm
            // 
            this.AutoScroll = false;
            this.AutoScrollMargin = new System.Drawing.Size(10, 20);
            this.ClientSize = new System.Drawing.Size(800, 673);
            this.Controls.Add(this.m_trvTime);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.m_lblAddress);
            this.Controls.Add(this.m_trvLabCheckSendTime);
            this.Controls.Add(this.lblToDeptDoctor);
            this.Controls.Add(this.m_lblToDeptDoctor);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.m_lblFromDeptDoctor);
            this.Controls.Add(this.lblFromDeptDoctor);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmPICUShiftBaseForm";
            this.Load += new System.EventHandler(this.frmPICUShiftBaseForm_Load);
            this.Controls.SetChildIndex(this.lblFromDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_lblFromDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_lblToDeptDoctor, 0);
            this.Controls.SetChildIndex(this.lblToDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_trvLabCheckSendTime, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_trvTime, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 清空所有内容
		/// </summary>
		private void m_mthClear()
		{
			//清空病人信息
			m_mthClearPatientBaseInfo();
			txtInPatientID.Tag = null;
			m_trnTimeRoot.Nodes.Clear();

			m_lblTurnBaseDeptName.Tag = null;

			m_mthClearAllShiftInfo();
			m_trnLabCheckSendTimeRoot.Nodes.Clear();
		}

		#region Override
		protected override void m_mthClearPatientBaseInfo()
		{
			base.m_mthClearPatientBaseInfo();			
			m_lblAddress.Text="";
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			/*
			 * PICU科室只能确认（签名）转入单和新开转出单；
			 * 非PICU科室只能新开转入单和确认（签名）转出单。
			 */
			if(strDeptArr == null)
			{
				clsPublicFunction.ShowInformationMessageBox("未在数据库查找到ICU科室，请联系数据库管理员进行相关配置！");
				return -5;
			}
			if(m_BlnIsShiftInRecord)
			{
//				//新增从配置文件获取部门ID tfzhang
//				string strPICUDepartmentID=m_strGetDeptID("ID");
//				if(m_objCurrentContext.m_ObjDepartment.m_StrDeptID == strPICUDepartmentID)
//				{
//#if !Debug
//					clsPublicFunction.ShowInformationMessageBox("PICU不能开转入记录表。");
//#endif
//					return -4;
//				}
				if (strDeptArr!= null)
				{
					bool blnIsSame = false;
					for(int i=0; i<strDeptArr.Length; i++)
					{
                        if (m_ObjCurrentArea.m_strDEPTID_CHR.Trim() == strDeptArr[i].Trim())
						{
							blnIsSame = true;
							break;
						}
					}
					if(blnIsSame)
					{
#if !Debug
						clsPublicFunction.ShowInformationMessageBox("PICU不能开转入记录表。");
#endif
						return -4;
					}
				}
			}
			else
			{
				//新增从配置文件获取部门ID tfzhang
//				string strPICUDepartmentID=m_strGetDeptID("ID");
//				if(m_objCurrentContext.m_ObjDepartment.m_StrDeptID != strPICUDepartmentID)
//				{
//#if !Debug
//					clsPublicFunction.ShowInformationMessageBox("非PICU不能开转出记录表。");
//#endif
//					return -4;
//				}
				if (strDeptArr!= null)
				{
					bool blnIsSame = false;
					for(int i=0; i<strDeptArr.Length; i++)
					{
                        if (m_ObjCurrentArea.m_strDEPTID_CHR.Trim() == strDeptArr[i].Trim())
						{
							blnIsSame = true;
							break;
						}
					}
					if(!blnIsSame)
					{					
#if !Debug
						clsPublicFunction.ShowInformationMessageBox("非PICU不能开转出记录表。");
#endif
						return -4;
					}
				}
			}

            clsPatient objPatient = m_objBaseCurrentPatient;//clsPatient objPatient = (clsPatient)txtInPatientID.Tag;            

			if(objPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("请选择病人");
#endif
				return -5;
			}

			bool blnIsAddNew;

            long lngRes = m_ObjShiftDomain.m_lngCheckNewCreateDate(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpTurnTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), out blnIsAddNew);

			if(lngRes <= 0)
			{
				return lngRes;
			}

			if(!blnIsAddNew)
			{
				if(m_BlnIsShiftInRecord)
				{
#if !Debug
					clsPublicFunction.ShowInformationMessageBox("该病人已经申请转入PICU。");
#endif
					return -6;
				}
				else
				{
#if !Debug
					clsPublicFunction.ShowInformationMessageBox("该病人已经申请转出PICU。");
#endif
					return -6;
				}
			}
			if(txtFromDoctor.Tag == null)
			{
				MDIParent.ShowInformationMessageBox("请医师签名！");
				return -5;
			}

			try
			{
				clsPICUShiftTurnInfo objTurnInfo = m_objGetShiftTurnInfo();
				m_mthSetShiftTurnInfo(objTurnInfo,objPatient);

				clsPICUShiftBaseInfo objBaseInfo = new clsPICUShiftBaseInfo();
				m_mthSetShiftBaseInfo(objBaseInfo);

				clsPICUShiftCheckInfo objCheckInfo = new clsPICUShiftCheckInfo();
				clsPICUShiftGlasgow objGlasgow = new clsPICUShiftGlasgow();
				objCheckInfo.m_objGlasgow = objGlasgow;
				m_mthSetShiftCheckInfo(objCheckInfo);

				clsPICUShiftLabReportInfo objLabReportInfo = new clsPICUShiftLabReportInfo();
				m_mthSetShiftLabReportInfo(objLabReportInfo);
			
				clsPICUShiftInfo objShiftInfo = new clsPICUShiftInfo();
				objShiftInfo.m_objTurnInfo = objTurnInfo;
				objShiftInfo.m_objBaseInfo = objBaseInfo;
				objShiftInfo.m_objPICUCheckInfo = objCheckInfo;
				objShiftInfo.m_objLabReportInfo = objLabReportInfo;
				objShiftInfo.m_dtmModifyDate = DateTime.Now;
                objShiftInfo.m_StrEmployeeID = clsEMRLogin.LoginInfo.m_strEmpNo;
				//电子签名 
				//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objPatient.m_StrInPatientID.Trim() + "-" + objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objShiftInfo, objSign_VO) == -1)
                    return -1;
			
				lngRes = m_ObjShiftDomain.m_lngAddNew(objShiftInfo);
			

				if(lngRes > 0)
				{
					m_mthResetRecordInfo();
                    m_trnTimeRoot.Nodes.Insert(0, new TreeNode(objTurnInfo.m_dtmTurnTime.ToString("yyyy-MM-dd HH:mm:ss")));
                    m_trnTimeRoot.ExpandAll();
                    //m_trvTime.SelectedNode = m_trnTimeRoot;
                    if (m_trnTimeRoot.Nodes.Count > 0)
                    {
                        m_trvTime.SelectedNode = m_trnTimeRoot.Nodes[0];
                    }
				}
			}
			catch
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("保存失败");//("测量值请输入数字。");
				return -7;
#endif
			}

			return lngRes;
		}
        /// <summary>
        /// 重写获取记录创建者属性
        /// 返回指定记录创建者ID
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (txtFromDoctor.Tag != null)
                    return ((clsEmrEmployeeBase_VO)txtFromDoctor.Tag).m_strEMPNO_CHR;
                return "";
            }
        }
		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null          
			if(m_objBaseCurrentPatient==null)
			{
				m_mthShowNoPatient();
				return -1;
			}
			//检查当前记录是否为null
			if(m_objCurrentShiftInfo==null)
			{				
				return -1;
			}
		
			
			//获取服务器时间      
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
			//设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
			m_objCurrentShiftInfo.m_dtmDeActivedDate=DateTime.Parse(strTimeNow);
			m_objCurrentShiftInfo.m_strDeActivedOperatorID=MDIParent.OperatorID;
		
			//设置p_objRecordContent对象的比要值
			clsTrackRecordContent p_objRecordContent=new clsTrackRecordContent();
			p_objRecordContent.m_strInPatientID=m_objCurrentShiftInfo.m_objTurnInfo.m_strInPatientID;
			p_objRecordContent.m_dtmInPatientDate=DateTime.Parse( m_objCurrentShiftInfo.m_objTurnInfo.m_strINPATIENTDATE);
			p_objRecordContent.m_dtmOpenDate=m_objCurrentShiftInfo.m_objTurnInfo.m_dtmTurnTime;
			p_objRecordContent.m_dtmCreateDate=p_objRecordContent.m_dtmOpenDate;
			p_objRecordContent.m_dtmModifyDate=m_objCurrentShiftInfo.m_dtmModifyDate;
			p_objRecordContent.m_dtmDeActivedDate=m_objCurrentShiftInfo.m_dtmDeActivedDate;
			p_objRecordContent.m_strDeActivedOperatorID=m_objCurrentShiftInfo.m_strDeActivedOperatorID;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;//((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_StrRecorder_ID, clsEMRLogin.LoginEmployee, intFormType);
            if (!blnIsAllow)
                return -1;

			//删除记录
			clsPreModifyInfo objModifyInfo=null;
			long lngRes = m_ObjShiftDomain.m_lngDeleteRecord(p_objRecordContent,out objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentShiftInfo = null;       
					
					m_blnCanTreeNodeAfterSelectEventTakePlace=false;
					//删除选中节点 
					m_trvTime.SelectedNode.Remove();
					//清空记录信息   
					m_mthClearAllShiftInfo();
					
					//选中根节点
					m_trvTime.SelectedNode=m_trvTime.Nodes[0];
					m_mthResetRecordInfo();
					m_blnCanTreeNodeAfterSelectEventTakePlace=true;
					break;  
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,删除失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Modify:
					if(objModifyInfo !=null)
						m_bolShowRecordModified(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;	
				case enmOperationResult.Record_Already_Delete:
					if(objModifyInfo !=null)
						m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;
				case enmOperationResult.Not_permission:
					m_mthShowNotPermitted();
					break;
					//...
			}  
		
			//返回结果
			return lngRes;			
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubModify()
		{
			/*
			 * PICU对转入单的修改就是签名，而转出单只是修改内容；
			 * 非PICU对转入单只是修改内容，而转出单的修改就是签名
			 */
            clsPatient objPatient = m_objBaseCurrentPatient;//clsPatient objPatient = (clsPatient)txtInPatientID.Tag;

			if(objPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("请选择病人");
#endif
				return -5;
			}

			clsPICUShiftInfo objShiftInfo = (clsPICUShiftInfo)m_lblTurnBaseDeptName.Tag;

			string strLastModifyDate = objShiftInfo.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
			
			bool blnIsLast;

            long lngRes = m_ObjShiftDomain.m_lngCheckLastModifyDate(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpTurnTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), strLastModifyDate, out blnIsLast);

			if(lngRes <= 0)
			{
				return lngRes;
			}

			if(!blnIsLast)
			{
#if !Debug
				//显示新内容
				m_mthAsk_Reload(objPatient,m_dtpTurnTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
#else
				m_strLastModifyDate = strLastModifyDate;
#endif
				return -3;
			}		

			DateTime dtmPreModifyDate = objShiftInfo.m_dtmModifyDate;
			clsEmployee objPreModifyUser = new clsEmployee( objShiftInfo.m_StrEmployeeID);
	
			try
			{
				m_mthSetShiftTurnInfo(objShiftInfo.m_objTurnInfo,objPatient);
				m_mthSetShiftBaseInfo(objShiftInfo.m_objBaseInfo);
				m_mthSetShiftCheckInfo(objShiftInfo.m_objPICUCheckInfo);
				m_mthSetShiftLabReportInfo(objShiftInfo.m_objLabReportInfo);
			
				objShiftInfo.m_dtmModifyDate = DateTime.Now;
				objShiftInfo.m_StrEmployeeID = clsEMRLogin.LoginInfo.m_strEmpNo;
			}
			catch
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("保存失败");//("测量值请输入数字。");
				return -7;
#endif
			}

			//电子签名 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objPatient.m_StrInPatientID.Trim() + "-" + objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objShiftInfo, objSign_VO) == -1)
                return -1;

			lngRes = m_ObjShiftDomain.m_lngModify(objShiftInfo);

			if(lngRes > 0)
			{
				m_mthResetRecordInfo();
                //m_trvTime.SelectedNode = m_trnTimeRoot;
			}
			else
			{
				objShiftInfo.m_dtmModifyDate = dtmPreModifyDate;
				objShiftInfo.m_StrEmployeeID = objPreModifyUser.m_StrEmployeeID;
			}

			return lngRes;
		}

		#region 在外部测试本打印的演示实例.	
				
		System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private void m_mthfrmLoad()
		{	
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
		
		clsPICUShiftBasePrintTool objPrintTool;
		private void m_mthDemoPrint_FromDataSource()
		{	
			objPrintTool=new clsPICUShiftBasePrintTool(m_BlnIsShiftInRecord);
			objPrintTool.m_mthInitPrintTool(null);	
            //if(m_lblInPatientDate.Text != "")
            //{
            //    m_objBaseCurrentPatient.m_DtmSelectedHISInDate = DateTime.Parse(m_lblInPatientDate.Text);
            //    m_objBaseCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
            //}
			if(m_objBaseCurrentPatient==null || m_ObjCurrentEmrPatientSession==null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
			else if(m_trvTime.SelectedNode==null || m_trvTime.SelectedNode==m_trvTime.Nodes[0] )
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
			else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.Parse(m_trvTime.SelectedNode.Text));
													
			objPrintTool.m_mthInitPrintContent();									
																	
			m_mthStartPrint();
		}
				
		private void m_mthStartPrint()
		{			
			if(m_blnDirectPrint)
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
		#endregion 在外部测试本打印的演示实例.

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected  long m_lngSubPrint1()
		{
			/*
			 * 需要提供打印空表单的功能
			 */
			//			if(m_lblTurnBaseDeptName.Tag == null)
			//			{
			//				clsPublicFunction.ShowInformationMessageBox("请先选择记录。");
			//				return -5;
			//			}		

			m_objPrintLineContext.m_ObjPrintLineInfo = m_lblTurnBaseDeptName.Tag;

			m_ppdRecord.ShowDialog();
			
			return 0;
		}

		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
            //txtInPatientID.Tag = p_objSelectedPatient;

            //m_lblAddress.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            if (m_ObjCurrentEmrPatientSession == null || p_objSelectedPatient == null)
            {
                return;
            }
            m_lblInPatientDate.Text = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm:ss");

            m_trnTimeRoot.Nodes.Clear();

            string[] strCreatDateArr = m_ObjShiftDomain.m_strGetCreateDateArr(p_objSelectedPatient);

            for (int i = 0; i < strCreatDateArr.Length; i++)
            {
                m_trnTimeRoot.Nodes.Add(DateTime.Parse(strCreatDateArr[i]).ToString("yyyy-MM-dd HH:mm:ss"));
            }

            m_trnTimeRoot.ExpandAll();

            m_mthResetRecordInfo();

            m_mthIsReadOnly();
            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();

            if (m_trnTimeRoot.Nodes.Count == 0)
                m_mthSetDefaultValue(p_objSelectedPatient);
            else
                m_trvTime.SelectedNode = m_trnTimeRoot.Nodes[0];

            m_mthSetLabCheckSendTime(p_objSelectedPatient);  
		}

		protected override bool m_BlnCanTextChanged
		{
			get
			{
				//对病人号的输入不作处理，所有不需要控制。
				return true;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				//选择的记录会被存放在m_lblTurnBaseDeptName.Tag
                //return (m_trvTime.SelectedNode == m_trvTime.Nodes[0] || m_trvTime.SelectedNode == null);//m_lblTurnBaseDeptName.Tag == null;
                return m_objCurrentShiftInfo == null;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return iCare.enmFormState.NowUser;			
			}
		}
		#endregion		

		/// <summary>
		/// 转入或转出的领域层
		/// </summary>
		protected virtual clsPICUShiftBaseDomain m_ObjShiftDomain
		{
			get
			{
				throw new Exception("没有实现 m_ObjShiftDomain 函数");
			}
		}

		/// <summary>
		/// 标记是否转入表单（true，转入；false，转出）
		/// </summary>
		protected virtual bool m_BlnIsShiftInRecord
		{
			get
			{
				throw new Exception("没有实现 m_BlnIsShiftInRecord 函数");
			}
		}

		/// <summary>
		/// 获取转入（转出）的目的信息
		/// </summary>
		/// <returns></returns>
		protected virtual clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
		{
			throw new Exception("没有实现 m_objGetShiftTurnInfo 函数");
		}

		/// <summary>
		/// 是否下载最新记录
		/// </summary>
		/// <param name="p_objSelectedPatient">病人信息</param>
		/// <param name="p_strCreateDate">创建时间</param>
		private void m_mthAsk_Reload(clsPatient p_objSelectedPatient,string p_strCreateDate)
		{
			if(clsPublicFunction.ShowQuestionMessageBox("记录已经被修改，是否下载最新记录？")
				== DialogResult.Yes)
			{
				m_mthSetPatientShiftInfo(p_objSelectedPatient,p_strCreateDate);
			}
		}

		/// <summary>
		/// 设置基本部门，缺省使用在转入单的转出部门，转出单需重载来使用转入部门
		/// </summary>
		/// <param name="p_objShiftInfo">转部门信息</param>
		protected virtual void m_mthSetBaseDept(clsPICUShiftInfo p_objShiftInfo)
		{
            if(m_ObjCurrentArea!=null)
                m_lblTurnBaseDeptName.Text = m_ObjCurrentArea.m_strDEPTNAME_VCHR;
		}

		/// <summary>
		/// 设置病人转移信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		/// <param name="p_strCreateDate">转移信息创建时间</param>
		private void m_mthSetPatientShiftInfo(clsPatient p_objSelectedPatient,string p_strCreateDate)
		{
           
			m_mthClearAllShiftInfo();

			m_strCurrentOpenDate = p_strCreateDate;

			clsPICUShiftInfo objShiftInfo = m_ObjShiftDomain.m_objGetPICUShiftInfo(p_objSelectedPatient,p_strCreateDate);
			m_objCurrentShiftInfo=objShiftInfo;
            
			if(objShiftInfo == null)
				return;

            m_mthSetBaseDept(objShiftInfo);
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeID, out objEmpVO);
            m_lblFromDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
            m_lblFromDeptDoctor.Tag = objEmpVO;
            txtFromDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
            txtFromDoctor.Tag = objEmpVO;

			if(objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID != null)
			{
				//已经签收，只能查看
                objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID, out objEmpVO);
                m_lblToDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_lblToDeptDoctor.Tag = objEmpVO;

				//设置为只读
				m_mthSetReadOnly(true);
			}
			else
			{
				//接收方缺省设置
				if((m_BlnIsShiftInRecord && m_objCurrentContext.m_ObjDepartment.m_StrDeptID == m_strPICUDeptID)
					|| (!m_BlnIsShiftInRecord && m_objCurrentContext.m_ObjDepartment.m_StrDeptID != m_strPICUDeptID))
				{
                    objEmployeeSign.m_lngGetEmpByNO(clsEMRLogin.LoginInfo.m_strEmpNo, out objEmpVO);
                    m_lblToDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_lblToDeptDoctor.Tag = objEmpVO;
				}

				m_mthSetReadOnly(false);
			}

			m_lblTurnBaseDeptName.Tag = objShiftInfo;

			if(objShiftInfo != null)
			{

				m_txtInDiagnose.Text = objShiftInfo.m_objBaseInfo.m_strInDiagnose;
				m_txtOperationName.Text = objShiftInfo.m_objBaseInfo.m_strOperationName;			
				m_txtAnaesthesiaType.Text = objShiftInfo.m_objBaseInfo.m_strAnaesthesiaType;
				m_dtpTurnTime.Value = objShiftInfo.m_objTurnInfo.m_dtmTurnTime;
				m_dtpTurnTime.Enabled = false;
				m_txtTurnDiagnose.Text = objShiftInfo.m_objBaseInfo.m_strTurnDiagnose;
				m_txtInDiagnoseCourse.Text = objShiftInfo.m_objBaseInfo.m_strInDiagnoseCourse;

				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltTemperature))
				{
					m_txtTemperature.Text = objShiftInfo.m_objPICUCheckInfo.m_fltTemperature.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate))
				{
					m_txtHeartRate.Text = objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPulse))
				{
					m_txtPulse.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPulse.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltSystolic))
				{
					m_txtSystolic.Text = objShiftInfo.m_objPICUCheckInfo.m_fltSystolic.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic))
				{
					m_txtDiastolic.Text = objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic.ToString("0.00");
				}
				m_txtMind.Text = objShiftInfo.m_objPICUCheckInfo.m_strMind;
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight))
				{
					m_txtPupilDiameterRight.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
				{
					m_txtPupilDiameterLeft.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft.ToString("0.00");
				}
				m_txtPupilReflectionRight.Text = objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;
				m_txtPupilReflectionLeft.Text = objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue))
				{
					m_txtGlasgowValue.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye))
				{
					m_txtGlasgowOpenEye.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage))
				{
					m_txtGlasgowLanguage.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport))
				{
					m_txtGlasgowSport.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport.ToString("0");
				}
				m_txtOther.Text = objShiftInfo.m_objPICUCheckInfo.m_strOther;
				
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltHB))
				{
					m_txtHB.Text = objShiftInfo.m_objLabReportInfo.m_fltHB.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltRBC))
				{
					m_txtRBC.Text = objShiftInfo.m_objLabReportInfo.m_fltRBC.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltWBC))
				{
					m_txtWBC.Text = objShiftInfo.m_objLabReportInfo.m_fltWBC.ToString("0.00");
				}

				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPlt))
				{
					m_txtPlt.Text = objShiftInfo.m_objLabReportInfo.m_fltPlt.ToString("0.00");
				}

				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltLymphocyte))
				{
					m_txtLymphocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltLymphocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte))
				{
					m_txtBandLeukocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte))
				{
					m_txtDispartLeftLeukocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltMonocyte))
				{
					m_txtMonocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltMonocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltAcidophil))
				{
					m_txtAcidophil.Text = objShiftInfo.m_objLabReportInfo.m_fltAcidophil.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBasophil))
				{
					m_txtBasophil.Text = objShiftInfo.m_objLabReportInfo.m_fltBasophil.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodK))
				{
					m_txtBloodK.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodK.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodNa))
				{
					m_txtBloodNa.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodNa.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodCl))
				{
					m_txtBloodCl.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodCl.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodSugar))
				{
					m_txtBloodSugar.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodSugar.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBUN))
				{
					m_txtBUN.Text = objShiftInfo.m_objLabReportInfo.m_fltBUN.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodCa))
				{
					m_txtBloodCa.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodCa.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPH))
				{
					m_txtPH.Text = objShiftInfo.m_objLabReportInfo.m_fltPH.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPaO2))
				{
					m_txtPaO2.Text = objShiftInfo.m_objLabReportInfo.m_fltPaO2.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPaCO2))
				{
					m_txtPaCO2.Text = objShiftInfo.m_objLabReportInfo.m_fltPaCO2.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBE))
				{
					m_txtBE.Text = objShiftInfo.m_objLabReportInfo.m_fltBE.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltHCO3))
				{
					m_txtHCO3.Text = objShiftInfo.m_objLabReportInfo.m_fltHCO3.ToString("0.00");
				}
				m_txtWoundInfo.Text = objShiftInfo.m_objLabReportInfo.m_strWoundInfo;
			}
		}
		
		#region 把界面信息设置到变量总
		/// <summary>
		/// 设置转移信息
		/// </summary>
		/// <param name="p_objTurnInfo">被设置的转移信息</param>
		/// <param name="p_objPatient">病人</param>
		protected virtual void m_mthSetShiftTurnInfo(clsPICUShiftTurnInfo p_objTurnInfo,clsPatient p_objPatient)
		{
            
			p_objTurnInfo.m_strInPatientID = p_objPatient.m_StrInPatientID;
            p_objTurnInfo.m_strINPATIENTDATE = p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

			p_objTurnInfo.m_dtmTurnTime = m_dtpTurnTime.Value;

//			if(m_lblFromDeptDoctor.Tag != null)
//				p_objTurnInfo.m_strTurnFromEmployeeID = ((clsEmployee)m_lblFromDeptDoctor.Tag).m_StrEmployeeID;
//			if(p_objTurnInfo.m_strTurnFromEmployeeID != null)
//				p_objTurnInfo.m_strTurnFromDeptID = p_objTurnInfo.m_objTurnFromDoctor.m_ObjDepartment;
            p_objTurnInfo.m_strTurnFromDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
			p_objTurnInfo.m_strTurnFromEmployeeID = ((clsEmrEmployeeBase_VO)txtFromDoctor.Tag).m_strEMPNO_CHR;

//			if(m_lblToDeptDoctor.Tag != null)
//				p_objTurnInfo.m_strTurnToEmployeeID = ( (clsEmployee)m_lblToDeptDoctor.Tag).m_StrEmployeeID;
//			if(p_objTurnInfo.m_strTurnToEmployeeID != null)
//				p_objTurnInfo.m_strTurnToDeptID = p_objTurnInfo.m_objTurnToDoctor.m_ObjDepartment;
			
		}

		/// <summary>
		/// 设置转移基本信息
		/// </summary>
		/// <param name="p_objBaseInfo">转移基本信息</param>
		protected void m_mthSetShiftBaseInfo(clsPICUShiftBaseInfo p_objBaseInfo)
		{
			p_objBaseInfo.m_strInDiagnose = m_txtInDiagnose.Text;
			p_objBaseInfo.m_strOperationName = m_txtOperationName.Text;
			p_objBaseInfo.m_strAnaesthesiaType = m_txtAnaesthesiaType.Text;
			p_objBaseInfo.m_strTurnDiagnose = m_txtTurnDiagnose.Text;
			p_objBaseInfo.m_strInDiagnoseCourse = m_txtInDiagnoseCourse.Text;            			
		}

		/// <summary>
		/// 设置转移检验信息
		/// </summary>
		/// <param name="p_objCheckInfo">转移检验信息</param>
		protected void m_mthSetShiftCheckInfo(clsPICUShiftCheckInfo p_objCheckInfo)
		{
			if(m_txtTemperature.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltTemperature = float.Parse(m_txtTemperature.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltTemperature = float.NaN;
			if(m_txtHeartRate.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltHeartRate = float.Parse(m_txtHeartRate.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltHeartRate = float.NaN;
			if(m_txtPulse.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltPulse = float.Parse(m_txtPulse.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltPulse = float.NaN;
			if(m_txtSystolic.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltSystolic = float.Parse(m_txtSystolic.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltSystolic = float.NaN;
			if(m_txtDiastolic.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltDiastolic = float.Parse(m_txtDiastolic.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltDiastolic = float.NaN;
			p_objCheckInfo.m_strMind = m_txtMind.Text;
			if(m_txtPupilDiameterRight.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltPupilDiameterRight = float.Parse(m_txtPupilDiameterRight.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltPupilDiameterRight = float.NaN;
			if(m_txtPupilDiameterLeft.Text.Trim() != "")
			{
				p_objCheckInfo.m_fltPupilDiameterLeft = float.Parse(m_txtPupilDiameterLeft.Text.Trim());
			}
			else
				p_objCheckInfo.m_fltPupilDiameterLeft = float.NaN;
			p_objCheckInfo.m_strPupilReflectionRight = m_txtPupilReflectionRight.Text;
			p_objCheckInfo.m_strPupilReflectionLeft = m_txtPupilReflectionLeft.Text;
			p_objCheckInfo.m_strOther = m_txtOther.Text;

			if(m_txtGlasgowValue.Text.Trim() != "")
			{
				p_objCheckInfo.m_objGlasgow.m_fltValue = float.Parse(m_txtGlasgowValue.Text.Trim());
			}
			else
				p_objCheckInfo.m_objGlasgow.m_fltValue = float.NaN;
			if(m_txtGlasgowOpenEye.Text.Trim() != "")
			{
				p_objCheckInfo.m_objGlasgow.m_fltOpenEye = float.Parse(m_txtGlasgowOpenEye.Text.Trim());
			}
			else
				p_objCheckInfo.m_objGlasgow.m_fltOpenEye = float.NaN;
			if(m_txtGlasgowLanguage.Text.Trim() != "")
			{
				p_objCheckInfo.m_objGlasgow.m_fltLanguage = float.Parse(m_txtGlasgowLanguage.Text.Trim());
			}
			else
				p_objCheckInfo.m_objGlasgow.m_fltLanguage = float.NaN;
			if(m_txtGlasgowSport.Text.Trim() != "")
			{
				p_objCheckInfo.m_objGlasgow.m_fltSport = float.Parse(m_txtGlasgowSport.Text.Trim());
			}
			else
				p_objCheckInfo.m_objGlasgow.m_fltSport = float.NaN;
		}

		/// <summary>
		/// 设置实验室检验信息
		/// </summary>
		/// <param name="p_objReportInfo">实验室检验信息</param>
		protected void m_mthSetShiftLabReportInfo(clsPICUShiftLabReportInfo p_objReportInfo)
		{			
			if(m_txtHB.Text.Trim() != "")
			{
				p_objReportInfo.m_fltHB = float.Parse(m_txtHB.Text.Trim());
			}
			else
				p_objReportInfo.m_fltHB = float.NaN;
			if(m_txtRBC.Text.Trim() != "")
			{
				p_objReportInfo.m_fltRBC = float.Parse(m_txtRBC.Text.Trim());
			}
			else
				p_objReportInfo.m_fltRBC = float.NaN;
			if(m_txtWBC.Text.Trim() != "")
			{
				p_objReportInfo.m_fltWBC = float.Parse(m_txtWBC.Text.Trim());
			}
			else
				p_objReportInfo.m_fltWBC = float.NaN;

			if(m_txtPlt.Text.Trim() != "")
			{
				p_objReportInfo.m_fltPlt = float.Parse(m_txtPlt.Text.Trim());
			}
			else
				p_objReportInfo.m_fltPlt = float.NaN;

			if(m_txtLymphocyte.Text.Trim() != "")
			{
				p_objReportInfo.m_fltLymphocyte = float.Parse(m_txtLymphocyte.Text.Trim());
			}
			else
				p_objReportInfo.m_fltLymphocyte = float.NaN;
			if(m_txtBandLeukocyte.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBandLeukocyte = float.Parse(m_txtBandLeukocyte.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBandLeukocyte = float.NaN;
			if(m_txtDispartLeftLeukocyte.Text.Trim() != "")
			{
				p_objReportInfo.m_fltDispartLeftLeukocyte = float.Parse(m_txtDispartLeftLeukocyte.Text.Trim());
			}
			else
				p_objReportInfo.m_fltDispartLeftLeukocyte = float.NaN;
			if(m_txtMonocyte.Text.Trim() != "")
			{
				p_objReportInfo.m_fltMonocyte = float.Parse(m_txtMonocyte.Text.Trim());
			}
			else
				p_objReportInfo.m_fltMonocyte = float.NaN;
			if(m_txtAcidophil.Text.Trim() != "")
			{
				p_objReportInfo.m_fltAcidophil = float.Parse(m_txtAcidophil.Text.Trim());
			}
			else
				p_objReportInfo.m_fltAcidophil = float.NaN;
			if(m_txtBasophil.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBasophil = float.Parse(m_txtBasophil.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBasophil = float.NaN;
			if(m_txtBloodK.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBloodK = float.Parse(m_txtBloodK.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBloodK = float.NaN;
			if(m_txtBloodNa.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBloodNa = float.Parse(m_txtBloodNa.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBloodNa = float.NaN;
			if(m_txtBloodCl.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBloodCl = float.Parse(m_txtBloodCl.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBloodCl = float.NaN;
			if(m_txtBloodSugar.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBloodSugar = float.Parse(m_txtBloodSugar.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBloodSugar = float.NaN;
			if(m_txtBUN.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBUN = float.Parse(m_txtBUN.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBUN = float.NaN;
			if(m_txtBloodCa.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBloodCa = float.Parse(m_txtBloodCa.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBloodCa = float.NaN;
			if(m_txtPH.Text.Trim() != "")
			{
				p_objReportInfo.m_fltPH = float.Parse(m_txtPH.Text.Trim());
			}
			else
				p_objReportInfo.m_fltPH = float.NaN;
			if(m_txtPaO2.Text.Trim() != "")
			{
				p_objReportInfo.m_fltPaO2 = float.Parse(m_txtPaO2.Text.Trim());
			}
			else
				p_objReportInfo.m_fltPaO2 = float.NaN;
			if(m_txtPaCO2.Text.Trim() != "")
			{
				p_objReportInfo.m_fltPaCO2 = float.Parse(m_txtPaCO2.Text.Trim());
			}
			else
				p_objReportInfo.m_fltPaCO2 = float.NaN;
			if(m_txtBE.Text.Trim() != "")
			{
				p_objReportInfo.m_fltBE = float.Parse(m_txtBE.Text.Trim());
			}
			else
				p_objReportInfo.m_fltBE = float.NaN;
			if(m_txtHCO3.Text.Trim() != "")
			{
				p_objReportInfo.m_fltHCO3 = float.Parse(m_txtHCO3.Text.Trim());
			}
			else
				p_objReportInfo.m_fltHCO3 = float.NaN;
			p_objReportInfo.m_strWoundInfo = m_txtWoundInfo.Text;
		}
		#endregion

		/// <summary>
		/// 重置部门的显示，转出单重载。
		/// </summary>
		protected virtual void m_mthResetBaseDept()
		{
			m_lblTurnBaseDeptName.Text = "";
		}

		/// <summary>
		/// 设置缺省的部门，转出单重载。
		/// </summary>
		protected virtual void m_mthSetDefaultBaseDept()
		{
			m_lblTurnBaseDeptName.Text = m_objCurrentContext.m_ObjDepartment.m_StrDeptName;
		}

		#region Clear
		/// <summary>
		/// 重置记录信息
		/// </summary>
		protected void m_mthResetRecordInfo()
		{
			m_mthClearAllShiftInfo();			
				
			m_lblTurnBaseDeptName.Tag = null;

            m_mthSetReadOnly(false);

            if (m_ObjCurrentEmrPatientSession == null)
            {
                return;
            }

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
			//只有是申请的科室才设置当前内容
			if(m_BlnIsShiftInRecord)
			{
                if (m_ObjCurrentEmrPatientSession.m_strAreaId == m_strPICUDeptID)
				{
					//PICU科室接收
					m_mthResetBaseDept();
				}
				else
				{
					//非PICU科室申请
					m_mthSetDefaultBaseDept();
					objEmployeeSign.m_lngGetEmpByNO(clsEMRLogin.LoginInfo.m_strEmpNo, out objEmpVO);
                    m_lblFromDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_lblFromDeptDoctor.Tag = objEmpVO;
				}
			}
			else
			{
                if (m_ObjCurrentEmrPatientSession.m_strAreaId != m_strPICUDeptID)
				{
					//非PICU科室接收
					m_mthResetBaseDept();
				}
				else
				{
					//PICU科室申请
					m_mthSetDefaultBaseDept();
                    objEmployeeSign.m_lngGetEmpByNO(clsEMRLogin.LoginInfo.m_strEmpNo, out objEmpVO);
                    m_lblFromDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_lblFromDeptDoctor.Tag = objEmpVO;
				}
			}
		}
		/// <summary>
		/// 清空所有转移信息
		/// </summary>
		protected void m_mthClearAllShiftInfo()
		{
			m_strCurrentOpenDate = "";

			m_lblFromDeptDoctor.Tag = null;
			m_lblToDeptDoctor.Tag = null;
			m_lblTurnBaseDeptName.Tag = null;//清空判断添加修改的标志
			m_lblToDeptDoctor.Text = "";

			//			m_trnLabCheckSendTimeRoot.Nodes.Clear();
			
			m_mthClearBaseInfo();
			m_mthClearCheckInfo();
			m_mthClearLabReportInfo();
			m_objCurrentShiftInfo=null;

            txtFromDoctor.Clear();
            txtFromDoctor.Tag = null;
		}

		/// <summary>
		/// 清空转移基本信息
		/// </summary>
		protected void m_mthClearBaseInfo()
		{
			m_txtInDiagnose.m_mthClearText();
			m_txtOperationName.m_mthClearText();
			m_txtAnaesthesiaType.m_mthClearText();
			m_dtpTurnTime.Value = DateTime.Now;
			m_dtpTurnTime.Enabled = true;
			m_txtTurnDiagnose.m_mthClearText();
			m_txtInDiagnoseCourse.m_mthClearText();
		}

		/// <summary>
		/// 清空转移检验信息
		/// </summary>
		protected void m_mthClearCheckInfo()
		{
			m_txtTemperature.m_mthClearText();
			m_txtHeartRate.m_mthClearText();
			m_txtPulse.m_mthClearText();
			m_txtSystolic.m_mthClearText();
			m_txtDiastolic.m_mthClearText();
			m_txtMind.m_mthClearText();
			m_txtPupilDiameterRight.m_mthClearText();
			m_txtPupilDiameterLeft.m_mthClearText();
			m_txtPupilReflectionRight.m_mthClearText();
			m_txtPupilReflectionLeft.m_mthClearText();
			m_txtGlasgowValue.m_mthClearText();
			m_txtGlasgowOpenEye.m_mthClearText();
			m_txtGlasgowLanguage.m_mthClearText();
			m_txtGlasgowSport.m_mthClearText();
			m_txtOther.m_mthClearText();
				
		}

		/// <summary>
		/// 清空实验室检验信息
		/// </summary>
		protected void m_mthClearLabReportInfo()
		{
			m_txtHB.m_mthClearText();
			m_txtRBC.m_mthClearText();
			m_txtWBC.m_mthClearText();
			m_txtPlt.m_mthClearText();
			m_txtLymphocyte.m_mthClearText();
			m_txtBandLeukocyte.m_mthClearText();
			m_txtDispartLeftLeukocyte.m_mthClearText();
			m_txtMonocyte.m_mthClearText();
			m_txtAcidophil.m_mthClearText();
			m_txtBasophil.m_mthClearText();
			m_txtBloodK.m_mthClearText();
			m_txtBloodNa.m_mthClearText();
			m_txtBloodCl.m_mthClearText();
			m_txtBloodSugar.m_mthClearText();
			m_txtBUN.m_mthClearText();
			m_txtBloodCa.m_mthClearText();
			m_txtPH.m_mthClearText();
			m_txtPaO2.m_mthClearText();
			m_txtPaCO2.m_mthClearText();
			m_txtBE.m_mthClearText();
			m_txtHCO3.m_mthClearText();
			m_txtWoundInfo.m_mthClearText();
		}
		#endregion

		/// <summary>
		/// 设置控件为只读
		/// </summary>
		/// <param name="p_blnReadOnly">是否只读</param>
		private void m_mthSetReadOnly(bool p_blnReadOnly)
		{
			for(int i=0;i<this.Controls.Count;i++)
			{
				if(this.Controls[i].GetType().Name == "ctlRichTextBox")
				{
					((com.digitalwave.controls.ctlRichTextBox)this.Controls[i]).m_BlnReadOnly = p_blnReadOnly;
				}
			}			
		}

        protected bool m_blnCanShowDiseaseTrack = true;
		private void m_trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_objBaseCurrentPatient == null || m_blnCanTreeNodeAfterSelectEventTakePlace==false)
				return;

			m_mthRecordChangedToSave();

			if(e.Node.Equals(m_trnTimeRoot))
			{
				m_mthResetRecordInfo();

				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);

                m_mthSetDefaultValue(m_objBaseCurrentPatient);

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			}
			else
			{
                clsPatient objPatient = m_objBaseCurrentPatient;

                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				this.Cursor = Cursors.WaitCursor;
				m_mthSetPatientShiftInfo(objPatient,e.Node.Text);
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_objCurrentShiftInfo.m_StrEmployeeID==MDIParent.OperatorID);

				this.Cursor = Cursors.Default;				

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}

			m_mthAddFormStatusForClosingSave();
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmLastInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}

			this.Cursor = Cursors.WaitCursor;
			m_mthSetDeletedPatientShiftInfo(m_objBaseCurrentPatient,p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"));
			m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
			m_mthSetRichTextCanModifyLast(this,true);
			this.m_dtpTurnTime.Value=DateTime.Now;
			this.m_dtpTurnTime.Enabled=true;
			this.Cursor = Cursors.Default;				
		}

		/// <summary>
		/// 设置病人转移信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		/// <param name="p_strCreateDate">转移信息创建时间</param>
		private void m_mthSetDeletedPatientShiftInfo(clsPatient p_objSelectedPatient,string p_strCreateDate)
		{
			this.m_trvTime.SelectedNode=m_trvTime.Nodes[0];
			m_mthClearAllShiftInfo();

			clsPICUShiftInfo objShiftInfo = m_ObjShiftDomain.m_objGetDeletedPICUShiftInfo(p_objSelectedPatient,p_strCreateDate);
			m_objCurrentShiftInfo=objShiftInfo;
			if(objShiftInfo == null)
				return;

			m_mthSetBaseDept(objShiftInfo);
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeID, out objEmpVO);
            m_lblFromDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
            m_lblFromDeptDoctor.Tag = objEmpVO;

			if(! string.IsNullOrEmpty(objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID))
			{
				//已经签收，只能查看
                objEmployeeSign.m_lngGetEmpByNO(objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeID, out objEmpVO);
                m_lblToDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_lblToDeptDoctor.Tag = objEmpVO;

				//设置为只读
				m_mthSetReadOnly(true);
			}
			else
			{
				//接收方缺省设置
				if((m_BlnIsShiftInRecord && m_objCurrentContext.m_ObjDepartment.m_StrDeptID == m_strPICUDeptID)
					|| (!m_BlnIsShiftInRecord && m_objCurrentContext.m_ObjDepartment.m_StrDeptID != m_strPICUDeptID))
				{
                    objEmployeeSign.m_lngGetEmpByNO(clsEMRLogin.LoginInfo.m_strEmpNo, out objEmpVO);
                    m_lblToDeptDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_lblToDeptDoctor.Tag = objEmpVO;
				}

				m_mthSetReadOnly(false);
			}

			m_lblTurnBaseDeptName.Tag = objShiftInfo;

			if(objShiftInfo != null)
			{
				m_txtInDiagnose.Text = objShiftInfo.m_objBaseInfo.m_strInDiagnose;
				m_txtOperationName.Text = objShiftInfo.m_objBaseInfo.m_strOperationName;			
				m_txtAnaesthesiaType.Text = objShiftInfo.m_objBaseInfo.m_strAnaesthesiaType;
				m_dtpTurnTime.Value = objShiftInfo.m_objTurnInfo.m_dtmTurnTime;
				m_dtpTurnTime.Enabled = false;
				m_txtTurnDiagnose.Text = objShiftInfo.m_objBaseInfo.m_strTurnDiagnose;
				m_txtInDiagnoseCourse.Text = objShiftInfo.m_objBaseInfo.m_strInDiagnoseCourse;

				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltTemperature))
				{
					m_txtTemperature.Text = objShiftInfo.m_objPICUCheckInfo.m_fltTemperature.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate))
				{
					m_txtHeartRate.Text = objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPulse))
				{
					m_txtPulse.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPulse.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltSystolic))
				{
					m_txtSystolic.Text = objShiftInfo.m_objPICUCheckInfo.m_fltSystolic.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic))
				{
					m_txtDiastolic.Text = objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic.ToString("0.00");
				}
				m_txtMind.Text = objShiftInfo.m_objPICUCheckInfo.m_strMind;
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight))
				{
					m_txtPupilDiameterRight.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
				{
					m_txtPupilDiameterLeft.Text = objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft.ToString("0.00");
				}
				m_txtPupilReflectionRight.Text = objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;
				m_txtPupilReflectionLeft.Text = objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue))
				{
					m_txtGlasgowValue.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye))
				{
					m_txtGlasgowOpenEye.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage))
				{
					m_txtGlasgowLanguage.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage.ToString("0");
				}
				if(!float.IsNaN(objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport))
				{
					m_txtGlasgowSport.Text = objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport.ToString("0");
				}
				m_txtOther.Text = objShiftInfo.m_objPICUCheckInfo.m_strOther;
				
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltHB))
				{
					m_txtHB.Text = objShiftInfo.m_objLabReportInfo.m_fltHB.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltRBC))
				{
					m_txtRBC.Text = objShiftInfo.m_objLabReportInfo.m_fltRBC.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltWBC))
				{
					m_txtWBC.Text = objShiftInfo.m_objLabReportInfo.m_fltWBC.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPlt))
				{
					m_txtPlt.Text = objShiftInfo.m_objLabReportInfo.m_fltPlt.ToString("0.00");
				}

				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltLymphocyte))
				{
					m_txtLymphocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltLymphocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte))
				{
					m_txtBandLeukocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte))
				{
					m_txtDispartLeftLeukocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltMonocyte))
				{
					m_txtMonocyte.Text = objShiftInfo.m_objLabReportInfo.m_fltMonocyte.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltAcidophil))
				{
					m_txtAcidophil.Text = objShiftInfo.m_objLabReportInfo.m_fltAcidophil.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBasophil))
				{
					m_txtBasophil.Text = objShiftInfo.m_objLabReportInfo.m_fltBasophil.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodK))
				{
					m_txtBloodK.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodK.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodNa))
				{
					m_txtBloodNa.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodNa.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodCl))
				{
					m_txtBloodCl.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodCl.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodSugar))
				{
					m_txtBloodSugar.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodSugar.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBUN))
				{
					m_txtBUN.Text = objShiftInfo.m_objLabReportInfo.m_fltBUN.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBloodCa))
				{
					m_txtBloodCa.Text = objShiftInfo.m_objLabReportInfo.m_fltBloodCa.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPH))
				{
					m_txtPH.Text = objShiftInfo.m_objLabReportInfo.m_fltPH.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPaO2))
				{
					m_txtPaO2.Text = objShiftInfo.m_objLabReportInfo.m_fltPaO2.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltPaCO2))
				{
					m_txtPaCO2.Text = objShiftInfo.m_objLabReportInfo.m_fltPaCO2.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltBE))
				{
					m_txtBE.Text = objShiftInfo.m_objLabReportInfo.m_fltBE.ToString("0.00");
				}
				if(!float.IsNaN(objShiftInfo.m_objLabReportInfo.m_fltHCO3))
				{
					m_txtHCO3.Text = objShiftInfo.m_objLabReportInfo.m_fltHCO3.ToString("0.00");
				}
				m_txtWoundInfo.Text = objShiftInfo.m_objLabReportInfo.m_strWoundInfo;
			}
		}
		
		
		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>
		public override int m_IntFormID
		{
			get
			{
				return m_IntSubFormID;
			}
		}
		protected virtual int m_IntSubFormID
		{
			get
			{
				return 25;
			}
		}

		private clsLabAnalysisOrderDomain m_objDomain_Lab=new clsLabAnalysisOrderDomain();
		private void m_mthSetLabCheckSendTime(clsPatient p_objPatient)
		{
			string [] strSendCheckTimeArr = null;//new string[]{"2003-1-1 16:24","2003-1-6 12:45","2003-7-7 21:21"};
			string [] strBarCodeArr = null;//new string[]{"2003-1-1 16:24","2003-1-6 12:45","2003-7-7 21:21"};
			
			long lngRes=m_objDomain_Lab.m_lngGetSendTimeAndBarCodeList(p_objPatient.m_StrInPatientID,DateTime.Parse( m_lblInPatientDate.Text).ToString("yyyy-MM-dd HH:mm:ss"),out strSendCheckTimeArr,out strBarCodeArr);
			if(lngRes<=0)
			{
				switch(lngRes)
				{
					case (long)iCareData.enmOperationResult.Not_permission:
						m_mthShowNotPermitted();
						break;
					case (long)iCareData.enmOperationResult.DB_Fail:
						m_mthShowDBError();
						break;
				}
				return;
			}
			m_trnLabCheckSendTimeRoot.Nodes.Clear();
			if(strSendCheckTimeArr==null || strBarCodeArr==null || strBarCodeArr.Length !=strSendCheckTimeArr.Length)
				return;
			for(int i=0;i<strSendCheckTimeArr.Length;i++)
			{
				TreeNode trnSendCheckTime = new TreeNode(DateTime.Parse(strSendCheckTimeArr[i]).ToString("yyyy-MM-dd HH:mm:ss"));
				trnSendCheckTime.Tag = strBarCodeArr[i];
	
				m_trnLabCheckSendTimeRoot.Nodes.Add(trnSendCheckTime);
			}

			m_trnLabCheckSendTimeRoot.ExpandAll();	
		}

		private void frmPICUShiftBaseForm_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || this.Site != null) return;
            strDeptArr = m_strGetDeptIDFromDetpConfig();
			this.m_lsvJY_ItemChoice.Visible=false;
			m_mthfrmLoad();
			m_lsvInPatientID.BringToFront();
			m_trvTime.Focus();
		}

		protected void m_mthKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Enter:// enter				
					if(((Control)sender).Name=="m_lsvJY_ItemChoice")
					{
						
						m_lsvJY_ItemChoice_DoubleClick(null,null);
					}			
					break;

				case Keys.F2:
					m_lngSave();
					break;
				case Keys.F3:
					m_lngDelete();
					break;
				case Keys.F4:
					m_lngPrint();
					break;
				case Keys.F5:
					m_mthClear();					
					break;
			}
		}

		#region 接口函数
		public void Delete()
		{
            intFormType = 1;
			long m_lngRe=m_lngDelete(); 
			if(m_lngRe>0)

			{	
				this.m_trvTime.SelectedNode=this.m_trvTime.Nodes[0];
				this.m_trvTime_AfterSelect(this.m_trvTime,new System.Windows.Forms.TreeViewEventArgs(this.m_trvTime.Nodes[0]));
			}

		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Print()
		{
			m_lngPrint();
		}

		public void Save()
		{
			long m_lngRe=m_lngSave();
            if (m_lngRe > 0)
            {
                m_blnNeedCheckArchive = false;
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                m_blnNeedCheckArchive = true;
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
            }
            
		}

		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Redo()
		{
		
		}
		public void Verify()
		{
			try
			{
				//检查当前病人变量是否为null          
				if(m_objBaseCurrentPatient==null)
				{
					clsPublicFunction.ShowInformationMessageBox("未选定病人,无法验证!");
				}
				 
				string strInPatientID =m_objCurrentShiftInfo.m_objTurnInfo.m_strInPatientID;
				string strInPatientDate =m_objCurrentShiftInfo.m_objTurnInfo.m_strINPATIENTDATE;
				string strRecordID=strInPatientID.Trim()+"-"+strInPatientDate;
				long lngRes=m_lngSignVerify(this.Name.Trim(),strRecordID);
			}
			catch (Exception exp)
			{ 
				MessageBox.Show("签名验证出现异常："+exp.Message,"Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void Undo()
		{
		
		}	
		#endregion

		#region ctlRichTextBox的双划线、其他属性设置
		/// <summary>
		/// 设置双划线
		/// </summary>
		protected void m_mthSetRichTextBoxDoubleStrike()
		{
			//获取RichTextBox        
			//ctlRichTextBox objRichTextBox = (ctlRichTextBox)m_ctmRichTextBoxMenu.SourceControl;
		
			//objRichTextBox.m_mthSelectionDoubleStrikeThough(true);
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(com.digitalwave.controls.ctlRichTextBox p_objRichTextBox)
		{
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
			//设置右键菜单			
			//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
			p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
			p_objRichTextBox.m_ClrDST = Color.Red;
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}	
		}
		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			m_mthSetRichTextBoxDoubleStrike();
		}
		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")			
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;				
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}	
		#endregion ctlRichTextBox的双划线、其他属性设置


		#region Print
		private int m_intYPos = 90;

		private void m_pdcRecord_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthPrintHeader(e);

			Font fntNormal = new Font("",12);

			while(m_objPrintLineContext.m_BlnHaveMoreLine)
			{
				//还有数据打印
				m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

				if(m_intYPos > 969+130
					&& m_objPrintLineContext.m_BlnHaveMoreLine)
				{
					//还有数据打印，但需要换页

					m_mthPrintFoot(e);

					e.HasMorePages = true;

					m_intYPos = 90;

					m_intCurrentPage++;

					return;
				}				
			}

			//全部打完

			m_mthPrintFoot(e);

			m_objPrintLineContext.m_mthReset();

			m_intYPos = 90;
		}

		private const int m_intRecBaseX = 30;

		private int m_intCurrentPage = 1;

		/// <summary>
		/// 打印页脚
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第      页",fntHeader,Brushes.Black,355,e.PageBounds.Height-50);
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,395,e.PageBounds.Height-50);			
		}
		
		/// <summary>
		/// 打印页头
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
		{			
			Font fntTitle = new Font("SimSun", 18,FontStyle.Bold );
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("佛山市第二人民医院",fntHeader,Brushes.Black,320,30);
			if(m_BlnIsShiftInRecord)
				e.Graphics.DrawString("转入记录表",fntHeader,Brushes.Black,355,55);
			else 
				e.Graphics.DrawString("转出记录表",fntHeader,Brushes.Black,355,55);

			e.Graphics.DrawRectangle(Pens.Black,m_intRecBaseX,80,770,e.PageBounds.Height-150);
		}

		protected clsLabAnalysisOrderDomain m_objCheckResultDomain=new clsLabAnalysisOrderDomain();
		private void m_cmdSetLabCheckResult_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient== null )
			{
				return;
			}
			m_lsvJY_ItemChoice.Visible=false;
			m_lsvJY_ItemChoice.Items.Clear();
			clsJY_ItemChoice[] objItemChoiceArr=null;
			long lngRes=m_objCheckResultDomain.m_lngGetLabCheckItemChoiceArr(this.m_objBaseCurrentPatient.m_StrInPatientID,m_dtpTurnTime.Value,out objItemChoiceArr);
			if(lngRes<=0)
			{
				m_mthShowDBError();
				return;
			}
			else 
			{
				if(objItemChoiceArr != null)
				{
					for(int i=0;i<objItemChoiceArr.Length;i++)
					{
						ListViewItem lviTemp= m_lsvJY_ItemChoice.Items.Add(objItemChoiceArr[i].m_strPat_c_name.Trim());
						lviTemp.SubItems.Add(objItemChoiceArr[i].m_dtmPat_sdate.ToString("yyyy-MM-dd HH:mm:ss"));
						lviTemp.Tag=objItemChoiceArr[i].m_strRes_id;
					}

					m_mthChangeListViewLastColumnWidth(m_lsvJY_ItemChoice);
					m_lsvJY_ItemChoice.Visible=true;
					m_lsvJY_ItemChoice.BringToFront();
				}
				else 
				{
					clsPublicFunction.ShowInformationMessageBox("当前没有最新检验结果出来！");
					return;
				}
			}	

	
		}
		private void m_lsvJY_ItemChoice_DoubleClick(object sender, System.EventArgs e)
		{
		
			m_lsvJY_ItemChoice.Visible=false;
			
			if(m_objBaseCurrentPatient== null || m_lsvJY_ItemChoice.SelectedItems.Count==0 || m_lsvJY_ItemChoice.SelectedItems[0].Tag==null)
			{
				return;
			}
			else
			{
				clsJY_JG[] objResultArr=null;
				long lngRes=m_objCheckResultDomain.m_lngGetLabCheckItemResultArr(m_lsvJY_ItemChoice.SelectedItems[0].Tag.ToString(),c_strNameArr,out objResultArr);
				if(lngRes<=0)
				{
					switch(lngRes)
					{
						case (long)iCareData.enmOperationResult.Not_permission:
							m_mthShowNotPermitted();
							break;
					}
					return;
				}				

				if(objResultArr==null || objResultArr.Length==0 || c_strNameArr==null)
					return;

				for(int i=0;i<c_strNameArr.Length;i++)
					for(int j=0;j<objResultArr.Length;j++)
					{
						if(c_strNameArr[i]==objResultArr[j].m_strRes_it_ecd || c_strNameArr[i]==objResultArr[j].m_strRes_name)
						{
							m_mthHandleLabCheckValue(c_strNameArr[i],objResultArr[j]);
						}
					}

				
				lblBloodAnalyse.Focus();
			}	
		}

		private void m_mthClearCheckResults()
		{
			m_txtHB.m_mthClearText();	
			m_txtRBC.m_mthClearText();
			m_txtWBC.m_mthClearText();
			m_txtPlt.m_mthClearText();
			m_txtLymphocyte.m_mthClearText();
			m_txtMonocyte.m_mthClearText();
			m_txtBandLeukocyte.m_mthClearText();
			m_txtDispartLeftLeukocyte.m_mthClearText();
			m_txtAcidophil.m_mthClearText();
			m_txtBasophil.m_mthClearText();
			m_txtBloodK.m_mthClearText();
			m_txtBloodNa.m_mthClearText();
			m_txtBloodCl.m_mthClearText();
			m_txtBloodSugar.m_mthClearText();
			m_txtBUN.m_mthClearText();
			m_txtBloodCa.m_mthClearText();
			m_txtPH.m_mthClearText();
			m_txtPaO2.m_mthClearText();
			m_txtPaCO2.m_mthClearText();
			m_txtBE.m_mthClearText();
			m_txtHCO3.m_mthClearText();

		}
		private string[] c_strNameArr = new string[]{"HB","RBC","WBC","plt","淋巴细胞","单核细胞","带状中性白细胞","分叶中性白细胞",
														"嗜酸细胞","嗜碱细胞","血钾","血钠","血氯","血糖","BUN",
														"血钙","PH","PaO2","PaCO2","BE","HCO3"};
		private void m_mthHandleLabCheckValue(string p_strName,clsJY_JG p_objResult)
		{
			switch(p_strName)
			{
				case "HB":
					m_mthSetLabCheckValue(m_txtHB,p_objResult);
					break;
				case "RBC":
					m_mthSetLabCheckValue(m_txtRBC,p_objResult);
					break;
				case "WBC":
					m_mthSetLabCheckValue(m_txtWBC,p_objResult);
					break;
				case "plt":
					m_mthSetLabCheckValue(m_txtPlt,p_objResult);
					break;
				case "淋巴细胞":				
					m_mthSetLabCheckValue(m_txtLymphocyte,p_objResult);
					break;
				case "单核细胞":
					m_mthSetLabCheckValue(m_txtMonocyte,p_objResult);
					break;
				case "带状中性白细胞":
					m_mthSetLabCheckValue(m_txtBandLeukocyte,p_objResult);
					break;
				case "分叶中性白细胞":
					m_mthSetLabCheckValue(m_txtDispartLeftLeukocyte,p_objResult);
					break;
				case "嗜酸细胞":
					m_mthSetLabCheckValue(m_txtAcidophil,p_objResult);
					break;
				case "嗜碱细胞":
					m_mthSetLabCheckValue(m_txtBasophil,p_objResult);
					break;
				case "血钾":
					m_mthSetLabCheckValue(m_txtBloodK,p_objResult);
					break;
				case "血钠":
					m_mthSetLabCheckValue(m_txtBloodNa,p_objResult);
					break;
				case "血氯":
					m_mthSetLabCheckValue(m_txtBloodCl,p_objResult);
					break;
				case "血糖":
					m_mthSetLabCheckValue(m_txtBloodSugar,p_objResult);
					break;
				case "BUN":
					m_mthSetLabCheckValue(m_txtBUN,p_objResult);
					break;
				case "血钙":
					m_mthSetLabCheckValue(m_txtBloodCa,p_objResult);
					break;
				case "PH":
					m_mthSetLabCheckValue(m_txtPH,p_objResult);
					break;
				case "PaO2":
					m_mthSetLabCheckValue(m_txtPaO2,p_objResult);
					break;					
				case "PaCO2":
					m_mthSetLabCheckValue(m_txtPaCO2,p_objResult);
					break;
				case "BE":
					m_mthSetLabCheckValue(m_txtBE,p_objResult);
					break;
				case "HCO3":
					m_mthSetLabCheckValue(m_txtHCO3,p_objResult);
					break;
				
			}
		}

		private void m_mthSetLabCheckValue(com.digitalwave.controls.ctlRichTextBox p_objText,clsJY_JG p_objResult)
		{			
			if(p_objResult.m_strRes_chr != null && p_objResult.m_strRes_chr.Trim() != "")
			{
				p_objText.Text = p_objResult.m_strRes_chr.Trim();
			}
			else if(p_objResult.m_strRes_chr1 != null && p_objResult.m_strRes_chr1.Trim() != "")
			{
				p_objText.Text = p_objResult.m_strRes_chr1.Trim();
			}
		}

		private void m_lsvJY_ItemChoice_Leave(object sender, System.EventArgs e)
		{
			if( !m_lsvJY_ItemChoice.Focused  && !m_cmdSetLabCheckResult.Focused)
				m_lsvJY_ItemChoice.Visible=false;
		}

		private void m_txtDiastolic_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtBandLeukocyte_TextChanged(object sender, System.EventArgs e)
		{
		
		}	
		

		#region Print Line Class
		private abstract class clsPrintShiftInfoBase : clsPrintLineBase
		{
			protected clsPICUShiftInfo m_objShiftInfo;

			protected int m_intRecBaseX = 30;

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return base.m_blnHaveMoreLine;
				}
				set
				{
					if(value == null)
						return;

					m_objShiftInfo = (clsPICUShiftInfo)value;					
				}
			}	
		}

		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		private class clsPrintPatientFixInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

//				p_objGrp.DrawString("姓名："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrFirstName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrFirstName,p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);
			
//				p_objGrp.DrawString("性别："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrSex),p_fntNormalText,Brushes.Black,m_intRecBaseX+130,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrSex,p_fntNormalText,Brushes.Black,m_intRecBaseX+180,p_intPosY);
			
//				p_objGrp.DrawString("年龄："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_IntAge.ToString()),p_fntNormalText,Brushes.Black,m_intRecBaseX+230,p_intPosY);
				//				p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_IntAge.ToString(),p_fntNormalText,Brushes.Black,m_intRecBaseX+280,p_intPosY);
			
				p_objGrp.DrawString("住址：",p_fntNormalText,Brushes.Black,m_intRecBaseX+330,p_intPosY);

//				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress),"<root />");

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(400,m_intRecBaseX+380,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}

				p_objGrp.DrawString("入院日期："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strINPATIENTDATE),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
			
				p_objGrp.DrawString("入院诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX+290,p_intPosY );
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strInDiagnose),"<root />");
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(400,m_intRecBaseX+380,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}

				p_objGrp.DrawString("手术名称：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
				m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strOperationName),"<root />");
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					while(m_objPrintContext.m_BlnHaveNextLine())
					{
						m_objPrintContext.m_mthPrintLine(670,m_intRecBaseX+90,p_intPosY,p_objGrp);

						p_intPosY += 30;
					}
				}
				else
				{
					p_intPosY += 30;
				}
			
				if(m_objShiftInfo==null)
				{
					p_objGrp.DrawString("转入科室：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					p_objGrp.DrawString("转出时间：",p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				}
				else if(m_objShiftInfo.m_objTurnInfo.m_BlnIsShiftIn)
				{
					p_objGrp.DrawString("转出科室："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnFromDeptName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					p_objGrp.DrawString("转入时间："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_dtmTurnTime.ToString("yyyy年MM月dd日 HH:mm:ss")),p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY);
				}
				else
				{
					p_objGrp.DrawString("转入科室："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnToDeptName),p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY );
					p_objGrp.DrawString("转出时间："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_dtmTurnTime.ToString("yyyy年MM月dd日 HH:mm:ss")),p_fntNormalText,Brushes.Black,m_intRecBaseX+300,p_intPosY );
				}
				p_intPosY += 30;

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}
		#endregion

		#region 打印转入（出）诊断
		private class clsPrintPatientInDiagnoseInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private bool m_blnIsFirstPrint = true;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsFirstPrint)
				{					
					if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_BlnIsShiftIn)
					{
						p_objGrp.DrawString("转入诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					}
					else
					{
						p_objGrp.DrawString("转出诊断：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
					}

					if(m_objShiftInfo ==null || m_objShiftInfo.m_objBaseInfo.m_strTurnDiagnose.Length == 0)
					{
						p_intPosY += 60;

						m_blnHaveMoreLine = false;

						return;
					}
					

					m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strTurnDiagnose),"<root />");

					m_blnIsFirstPrint = false;					
				}
				
				int intLine = 0;
				while(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(670,m_intRecBaseX+90,p_intPosY,p_objGrp);

					p_intPosY += 30;

					intLine++;
				}			
	
				if(intLine == 1)
					p_intPosY += 30;

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}
		}
		#endregion

		#region 打印入院诊治经过
		private class clsPrintPatientInDiagnoseCourseInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsFirstPrint)
				{
					p_objGrp.DrawString("入院治疗经过：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);

					p_intPosY += 30;
					
					m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objBaseInfo.m_strInDiagnoseCourse),"<root />");

					m_blnIsFirstPrint = false;
				}
				
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);

					p_intPosY += 30;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					if(m_intTimes < 4)
					{
						p_intPosY += (4-m_intTimes)*30;

						if(m_intTimes == 0)
							p_intPosY += 30;
					}
					
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		#endregion
		
		#region 打印转入（出）情况
		private class clsPrintPatientCheckInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private byte m_bytPrintIndex = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				switch(m_bytPrintIndex)
				{
					case 0:
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_BlnIsShiftIn)
						{
							p_objGrp.DrawString("转入情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						}
						else
						{
							p_objGrp.DrawString("转出情况：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						}
						m_blnHaveMoreLine = true;
						break;
					case 1:
						string strTemperature = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltTemperature))
							strTemperature = m_objShiftInfo.m_objPICUCheckInfo.m_fltTemperature.ToString("0.00");
						string strHeartRate = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate))
							strHeartRate = m_objShiftInfo.m_objPICUCheckInfo.m_fltHeartRate.ToString("0");
						string strPulse = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPulse))
							strPulse = m_objShiftInfo.m_objPICUCheckInfo.m_fltPulse.ToString("0");
						string strSystolic = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltSystolic))
							strSystolic = m_objShiftInfo.m_objPICUCheckInfo.m_fltSystolic.ToString("0");
						string strDiastolic = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic))
							strDiastolic = m_objShiftInfo.m_objPICUCheckInfo.m_fltDiastolic.ToString("0");

						p_objGrp.DrawString("         T "+ strTemperature +" ℃，R "
							+ strHeartRate+" 次/分，P "
							+ strPulse+" 次/分，Bp "
							+ strSystolic+" / "
							+strDiastolic+" mmHg，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 2:
						string strMind = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strMind.Length > 0)
							strMind = m_objShiftInfo.m_objPICUCheckInfo.m_strMind;
						string strPupilDiameterRight = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight) )
							strPupilDiameterRight = m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterRight.ToString("0.00");
						string strPupilDiameterLeft = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
							strPupilDiameterLeft = m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft.ToString("0.00");

						p_objGrp.DrawString("         神智 "
							+strMind+" ，瞳孔直径：右 "
							+strPupilDiameterRight+" mm，左 "
							+strPupilDiameterLeft+" mm。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 3:
						string strPupilReflectionRight = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight.Length > 0)
							strPupilReflectionRight = m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionRight;
						string strPupilReflectionLeft = "      ";
						if(m_objShiftInfo!=null && m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft.Length > 0)
							strPupilReflectionLeft = m_objShiftInfo.m_objPICUCheckInfo.m_strPupilReflectionLeft;
						string strGlasgowValue = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue))
							strGlasgowValue = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltValue.ToString("0");
						string strGlasgowOpenEyes = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye))
							strGlasgowOpenEyes = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltOpenEye.ToString("0");

						p_objGrp.DrawString("         瞳孔光反射：右 "
							+strPupilReflectionRight+" 左 "
							+strPupilReflectionLeft+" 。Glasgow计分 "
							+strGlasgowValue+" 分（其中：睁眼 "
							+strGlasgowOpenEyes+" 分，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 4:
						string strGlasgowLanguage = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage))
							strGlasgowLanguage = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltLanguage.ToString("0");
						string strGlasgowSport = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objPICUCheckInfo.m_fltPupilDiameterLeft))
							strGlasgowSport = m_objShiftInfo.m_objPICUCheckInfo.m_objGlasgow.m_fltSport.ToString("0");

						p_objGrp.DrawString("         语言 "
							+strGlasgowLanguage+" 分，运动 "
							+strGlasgowSport+" 分）。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = false;
						break;
				}

				p_intPosY += 30;
				m_bytPrintIndex++;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_bytPrintIndex = 0;
			}
		}
		#endregion

		#region 打印转入（出）情况下的空白
		private class clsPrintPatientOtherInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private bool m_blnIsFirstPrint = true;

			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsFirstPrint)
				{
					m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" : m_objShiftInfo.m_objPICUCheckInfo.m_strOther),"<root />");

					m_blnIsFirstPrint = false;
				}
				
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);

					p_intPosY += 30;

					m_intTimes++;
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					if(m_intTimes < 3)
					{
						p_intPosY += (3-m_intTimes)*30;

						if(m_intTimes == 0)
							p_intPosY += 30;
					}
					
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnIsFirstPrint = true;

				m_blnHaveMoreLine = true;

				m_intTimes = 0;
			}
		}
		#endregion
		
		#region 打印最新实验室报告
		private class clsPrintPatientLabReportInfo : clsPrintShiftInfoBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",12));

			private byte m_bytPrintIndex = 0;

			private Font m_fntSmallFont = new Font("",6.5f);	
		
			private int m_intWounderTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				switch(m_bytPrintIndex)
				{
					case 0:
						p_objGrp.DrawString("最新实验室报告：",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 1:
						string strHB = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltHB))
							strHB = m_objShiftInfo.m_objLabReportInfo.m_fltHB.ToString("0.00");
						string strRBC = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltRBC))
							strRBC = m_objShiftInfo.m_objLabReportInfo.m_fltRBC.ToString("0.00");
						string strWBC = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltWBC))
							strWBC = m_objShiftInfo.m_objLabReportInfo.m_fltWBC.ToString("0.00");
						string strLymphocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte))
							strLymphocyte = m_objShiftInfo.m_objLabReportInfo.m_fltLymphocyte.ToString("0.00");

						float fltWidth1 = 0;
						string strTempValue = "HB "+strHB+"g/L,RBC "
							+strRBC+"x10";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						SizeF szfBase1 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("12",m_fntSmallFont,Brushes.Black,m_intRecBaseX+szfBase1.Width-10,p_intPosY-3);
						fltWidth1 = m_intRecBaseX+szfBase1.Width;

						strTempValue = "/L,WBC "+strWBC+"x10";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth1,p_intPosY);
						szfBase1 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("9",m_fntSmallFont,Brushes.Black,fltWidth1+szfBase1.Width-10,p_intPosY-3);
						fltWidth1 = fltWidth1+szfBase1.Width;

						strTempValue = "/L,白细胞分类:淋巴细胞 "+strLymphocyte+"%,";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth1,p_intPosY);
						
						m_blnHaveMoreLine = true;
						break;
					case 2:
						string strBandLeukocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte))
							strBandLeukocyte = m_objShiftInfo.m_objLabReportInfo.m_fltBandLeukocyte.ToString("0.00");
						string strDispartLeftLeukocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte))
							strDispartLeftLeukocyte = m_objShiftInfo.m_objLabReportInfo.m_fltDispartLeftLeukocyte.ToString("0.00");
						string strMonocyte = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltMonocyte))
							strMonocyte = m_objShiftInfo.m_objLabReportInfo.m_fltMonocyte.ToString("0.00");

						p_objGrp.DrawString("带状中性白细胞 "
							+strBandLeukocyte+" %，分叶中性白细胞 "
							+strDispartLeftLeukocyte+" %，单核细胞 "
							+strMonocyte+" %，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 3:
						string strAcidophil = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltAcidophil))
							strAcidophil = m_objShiftInfo.m_objLabReportInfo.m_fltAcidophil.ToString("0.00");
						string strBasophil = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBasophil))
							strBasophil = m_objShiftInfo.m_objLabReportInfo.m_fltBasophil.ToString("0.00");
						string strBloodK = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodK))
							strBloodK = m_objShiftInfo.m_objLabReportInfo.m_fltBloodK.ToString("0.00");
						string strBloodNa = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodNa))
							strBloodNa = m_objShiftInfo.m_objLabReportInfo.m_fltBloodNa.ToString("0.00");

						p_objGrp.DrawString("嗜酸细胞 "
							+strAcidophil+" %，嗜碱细胞 "
							+strBasophil+" %。血钾 "
							+strBloodK+" mmol/L，血钠 "
							+strBloodNa+" mmol/L，"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 4:
						string strBloodCl = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodCl))
							strBloodCl = m_objShiftInfo.m_objLabReportInfo.m_fltBloodCl.ToString("0.00");
						string strBloodSugar = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodSugar))
							strBloodSugar = m_objShiftInfo.m_objLabReportInfo.m_fltBloodSugar.ToString("0.00");
						string strBUN = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBUN))
							strBUN = m_objShiftInfo.m_objLabReportInfo.m_fltBUN.ToString("0.00");
						string strBloodCa = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBloodCa))
							strBloodCa = m_objShiftInfo.m_objLabReportInfo.m_fltBloodCa.ToString("0.00");

						p_objGrp.DrawString("血氯 "
							+strBloodCl+" mmol/L，血糖 "
							+strBloodSugar+" mmol/L，BUN "
							+strBUN+" mmol/L，血钙"
							+strBloodCa+" mmol/L。"
							,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 5:
						string strPH = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPH))
							strPH = m_objShiftInfo.m_objLabReportInfo.m_fltPH.ToString("0.00");
						string strPaO2 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPaO2))
							strPaO2 = m_objShiftInfo.m_objLabReportInfo.m_fltPaO2.ToString("0.00");
						string strPaCO2 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltPaCO2))
							strPaCO2 = m_objShiftInfo.m_objLabReportInfo.m_fltPaCO2.ToString("0.00");
						string strBE = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltBE))
							strBE = m_objShiftInfo.m_objLabReportInfo.m_fltBE.ToString("0.00");
						string strHCO3 = "      ";
						if(m_objShiftInfo!=null && !float.IsNaN(m_objShiftInfo.m_objLabReportInfo.m_fltHCO3))
							strHCO3 = m_objShiftInfo.m_objLabReportInfo.m_fltHCO3.ToString("0.00");

						float fltWidth5 = 0;
						string strTempBloodValue = "血气分析：PH "+strPH+" ,PaO ";
						p_objGrp.DrawString(strTempBloodValue,p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);
						SizeF szfBase5 = p_objGrp.MeasureString(strTempBloodValue,p_fntNormalText);
						p_objGrp.DrawString("2",m_fntSmallFont,Brushes.Black,m_intRecBaseX+szfBase5.Width-5,p_intPosY+10);
						fltWidth5 = m_intRecBaseX+szfBase5.Width;

						strTempValue = " "+strPaO2+" mmHg,PaCO";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("2",m_fntSmallFont,Brushes.Black,fltWidth5+szfBase5.Width-5,p_intPosY+10);
						fltWidth5 = fltWidth5+szfBase5.Width;

						strTempValue = " "+strPaCO2+" mmHg,BE";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						fltWidth5 = fltWidth5+szfBase5.Width;						

						strTempValue = " "+strBE+" mmHg,HCO";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						szfBase5 = p_objGrp.MeasureString(strTempValue,p_fntNormalText);
						p_objGrp.DrawString("3",m_fntSmallFont,Brushes.Black,fltWidth5+szfBase5.Width-5,p_intPosY+10);
						fltWidth5 = fltWidth5+szfBase5.Width;

						strTempValue = " "+strHCO3+" mmHg/L。";
						p_objGrp.DrawString(strTempValue,p_fntNormalText,Brushes.Black,fltWidth5,p_intPosY);
						m_blnHaveMoreLine = true;
						break;
					case 6:
						p_objGrp.DrawString("伤口、引流物情况",p_fntNormalText,Brushes.Black,m_intRecBaseX,p_intPosY);

						m_objPrintContext.m_mthSetContextWithAllCorrect((m_objShiftInfo==null ? "" :  m_objShiftInfo.m_objLabReportInfo.m_strWoundInfo),"<root />");
						
						m_blnHaveMoreLine = true;
						break;
					case 7:
						if(m_objPrintContext.m_BlnHaveNextLine())
						{
							m_objPrintContext.m_mthPrintLine(770,m_intRecBaseX,p_intPosY,p_objGrp);

							m_bytPrintIndex--;

							m_intWounderTimes++;

							m_blnHaveMoreLine = true;
						}
						else
						{
							if(m_intWounderTimes < 3)
							{
								p_intPosY += (3-m_intWounderTimes-1)*30;
							}

							m_blnHaveMoreLine = false;
						}
						break;
				}

				p_intPosY += 30;
				m_bytPrintIndex++;
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_bytPrintIndex = 0;				
			}
		}
		#endregion

		#region 打印签名
		/// <summary>
		/// 打印签名
		/// </summary>
		private class clsPrintPatientSignInfo : clsPrintShiftInfoBase
		{
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_BlnIsShiftIn)
				{
					p_objGrp.DrawString("转出科医师："+(m_objShiftInfo==null ? "" : m_objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeName),p_fntNormalText,Brushes.Black,m_intRecBaseX+200,p_intPosY);
					//					p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_objTurnFromDoctor.m_StrFirstName,p_fntNormalText,Brushes.Black,m_intRecBaseX+310,p_intPosY);
			
					p_objGrp.DrawString("中心ICU医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
					if(m_objShiftInfo!=null && m_objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName != null)
						p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName,p_fntNormalText,Brushes.Black,m_intRecBaseX+530,p_intPosY);
				}
				else if(m_objShiftInfo!=null && !m_objShiftInfo.m_objTurnInfo.m_BlnIsShiftIn)
				{
					p_objGrp.DrawString("中心ICU医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+200,p_intPosY);
					p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnFromEmployeeName,p_fntNormalText,Brushes.Black,m_intRecBaseX+330,p_intPosY);
			
					p_objGrp.DrawString("转出科医师：",p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
					if(m_objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName != null)
						p_objGrp.DrawString(m_objShiftInfo.m_objTurnInfo.m_strTurnToEmployeeName,p_fntNormalText,Brushes.Black,m_intRecBaseX+510,p_intPosY);
				}

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
		}
		#endregion
		#endregion
		#endregion

		#region 测试函数
#if Debug
		private string m_strLastModifyDate = "";

		private void m_mthMakeBaseContent(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker)
		{
			m_txtInDiagnose.Text = p_objContentMaker.m_strNextTextValue(m_txtInDiagnose,p_objContentMaker.m_ObjStringValueType,3000,1000);
			m_txtOperationName.Text = p_objContentMaker.m_strNextTextValue(m_txtOperationName,p_objContentMaker.m_ObjStringValueType,100,50);
			m_txtAnaesthesiaType.Text = p_objContentMaker.m_strNextTextValue(m_txtAnaesthesiaType,p_objContentMaker.m_ObjStringValueType,100,50);
			m_txtTurnDiagnose.Text = p_objContentMaker.m_strNextTextValue(m_txtTurnDiagnose,p_objContentMaker.m_ObjStringValueType,3000,1000);
			m_txtInDiagnoseCourse.Text = p_objContentMaker.m_strNextTextValue(m_txtInDiagnoseCourse,p_objContentMaker.m_ObjStringValueType,3500,2000);
		}

		private void m_mthMakeCheckContent(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker)
		{
			m_txtTemperature.Text = p_objContentMaker.m_strNextTextValue(m_txtTemperature,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtHeartRate.Text = p_objContentMaker.m_strNextTextValue(m_txtHeartRate,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPulse.Text = p_objContentMaker.m_strNextTextValue(m_txtPulse,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtSystolic.Text = p_objContentMaker.m_strNextTextValue(m_txtSystolic,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtDiastolic.Text = p_objContentMaker.m_strNextTextValue(m_txtDiastolic,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPupilDiameterRight.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilDiameterRight,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPupilDiameterLeft.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilDiameterLeft,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtGlasgowValue.Text = p_objContentMaker.m_strNextTextValue(m_txtGlasgowValue,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtGlasgowOpenEye.Text = p_objContentMaker.m_strNextTextValue(m_txtGlasgowOpenEye,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtGlasgowLanguage.Text = p_objContentMaker.m_strNextTextValue(m_txtGlasgowLanguage,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtGlasgowSport.Text = p_objContentMaker.m_strNextTextValue(m_txtGlasgowSport,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			
			m_txtMind.Text = p_objContentMaker.m_strNextTextValue(m_txtMind,p_objContentMaker.m_ObjStringValueType,200,50);
			m_txtPupilReflectionRight.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilReflectionRight,p_objContentMaker.m_ObjStringValueType,200,50);
			m_txtPupilReflectionLeft.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilReflectionLeft,p_objContentMaker.m_ObjStringValueType,200,50);
			m_txtOther.Text = p_objContentMaker.m_strNextTextValue(m_txtOther,p_objContentMaker.m_ObjStringValueType,200,50);
			
		}

		private void m_mthMakeLabReportContent(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker)
		{
			m_txtHB.Text = p_objContentMaker.m_strNextTextValue(m_txtHB,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtRBC.Text = p_objContentMaker.m_strNextTextValue(m_txtRBC,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtWBC.Text = p_objContentMaker.m_strNextTextValue(m_txtWBC,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPlt.Text = p_objContentMaker.m_strNextTextValue(m_txtPlt,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtLymphocyte.Text = p_objContentMaker.m_strNextTextValue(m_txtLymphocyte,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBandLeukocyte.Text = p_objContentMaker.m_strNextTextValue(m_txtBandLeukocyte,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtDispartLeftLeukocyte.Text = p_objContentMaker.m_strNextTextValue(m_txtDispartLeftLeukocyte,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtMonocyte.Text = p_objContentMaker.m_strNextTextValue(m_txtMonocyte,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtAcidophil.Text = p_objContentMaker.m_strNextTextValue(m_txtAcidophil,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBasophil.Text = p_objContentMaker.m_strNextTextValue(m_txtBasophil,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBloodK.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodK,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBloodNa.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodNa,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBloodCl.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodCl,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBloodSugar.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodSugar,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBUN.Text = p_objContentMaker.m_strNextTextValue(m_txtBUN,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtBloodCa.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodCa,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPH.Text = p_objContentMaker.m_strNextTextValue(m_txtPH,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPaO2.Text = p_objContentMaker.m_strNextTextValue(m_txtPaO2,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtPaCO2.Text = p_objContentMaker.m_strNextTextValue(m_txtPaCO2,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			m_txtHCO3.Text = p_objContentMaker.m_strNextTextValue(m_txtHCO3,p_objContentMaker.m_ObjDigitalValueType,1000d,-1000d);
			
			m_txtWoundInfo.Text = p_objContentMaker.m_strNextTextValue(m_txtWoundInfo,p_objContentMaker.m_ObjStringValueType,200,50);
		}

		protected virtual void m_mthSetTestBaseDept(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker)
		{
		}

		/// <summary>
		/// 新增功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		public enmAutoTestResult i_enmTestAddNew(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{
			//使用模板
			//		m_txt.Text = p_objContentMaker.m_strNextTextValue(m_txt,p_objContentMaker.m_Obj);
			//		m_cbo.SelectedIndex = p_objContentMaker.m_intNextSelectIndex(m_cbo);
			//		m_trv.SelectedNode = p_objContentMaker.m_trnNextTreeViewNode(m_trv);

			string strPatientID = p_objContentMaker.m_strNextTextValue(txtInPatientID,p_objContentMaker.m_ObjDigitalStringValueType,"0000000",2,1);

			clsPatient objPatient = new clsPatient(strPatientID);

			m_mthSetPatientInfo(objPatient);

			m_mthSetTestBaseDept(p_objContentMaker);

			m_dtpTurnTime.Value = DateTime.Now.Date.AddSeconds(p_objContentMaker.m_intNextSelectIndex(m_dtpTurnTime,86400*50));

			m_mthMakeBaseContent(p_objContentMaker);
			m_mthMakeCheckContent(p_objContentMaker);
			m_mthMakeLabReportContent(p_objContentMaker);

			long lngRes = m_lngSave();

			p_strInnerMessage = lngRes.ToString("0 ");

			switch(lngRes)
			{
				case -4:
					p_strInnerMessage += "不能开记录表。";
					break;
				case -5:
					p_strInnerMessage += "请选择病人";
					break;
				case -6:
					p_strInnerMessage += "该病人已经申请转入(出)PICU。";
					break;
			}

			if(lngRes > 0)
				return enmAutoTestResult.Succeed;
			else
				return enmAutoTestResult.Failure;
		}
	
		/// <summary>
		/// 修改功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		public enmAutoTestResult i_enmTestModify(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{	
			//使用模板
			//		m_txt.Text = p_objContentMaker.m_strNextTextValue(m_txt,p_objContentMaker.m_Obj);	
			//		m_cbo.SelectedIndex = p_objContentMaker.m_intNextSelectIndex(m_cbo);
			//		m_trv.SelectedNode = p_objContentMaker.m_trnNextTreeViewNode(m_trv);

			string strPatientID = p_objContentMaker.m_strNextTextValue(txtInPatientID,p_objContentMaker.m_ObjDigitalStringValueType,"0000000",2,1);

			clsPatient objPatient = new clsPatient(strPatientID);

			m_mthSetPatientInfo(objPatient);

			TreeNode trnCreateDate = m_trnTimeRoot.Nodes[p_objContentMaker.m_intNextSelectIndex(m_trvTime,m_trnTimeRoot.Nodes.Count)];
			m_mthSetPatientShiftInfo(objPatient,trnCreateDate.Text);

//			m_dtpTurnTime.Value = DateTime.Now.Date.AddSeconds(p_objContentMaker.m_intNextSelectIndex(m_dtpTurnTime,86400*50));

			m_mthSetTestBaseDept(p_objContentMaker);

			m_mthMakeBaseContent(p_objContentMaker);
			m_mthMakeCheckContent(p_objContentMaker);
			m_mthMakeLabReportContent(p_objContentMaker);

			long lngRes = m_lngSave();

			p_strInnerMessage = lngRes.ToString("0 ");

			switch(lngRes)
			{
				case -3:
					p_strInnerMessage += "(!blnIsLast) "+m_strLastModifyDate;
					break;
				case -5:
					p_strInnerMessage += "请选择病人";
					return enmAutoTestResult.Succeed;
			}

			if(lngRes > 0)
				return enmAutoTestResult.Succeed;
			else
				return enmAutoTestResult.Failure;
		}

		/// <summary>
		/// 删除功能测试
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		public enmAutoTestResult i_enmTestDelete(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{
			//使用模板
			//		m_txt.Text = p_objContentMaker.m_strNextTextValue(m_txt,p_objContentMaker.m_Obj);
			//		m_cbo.SelectedIndex = p_objContentMaker.m_intNextSelectIndex(m_cbo);
			//		m_trv.SelectedNode = p_objContentMaker.m_trnNextTreeViewNode(m_trv);
		
			p_strInnerMessage = "";
			return enmAutoTestResult.Succeed;
		}

		/// <summary>
		/// 显示功能测试（不提供）
		/// </summary>
		/// <param name="p_objContentMaker">测试内容制造器</param>
		/// <param name="p_strInnerMessage">出错信息输出</param>
		/// <returns>
		/// 执行结果
		/// </returns>
		public enmAutoTestResult i_enmTestDisplay(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{
			p_strInnerMessage = "";
			return enmAutoTestResult.Succeed;
		}
#endif
		#endregion

		#region 审核
		private string m_strCurrentOpenDate = "";
		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return m_strCurrentOpenDate;

				//				if(this.m_trvTime.SelectedNode==null || this.m_trvTime.SelectedNode.Tag==null)
				//				{
				//					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
				//					return "";
				//				}
				//				return (string)this.m_trvTime.SelectedNode.Tag;
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

		#region 判断当前用户是否连接GE仪器
		private bool m_blnCurrApparatus()
		{
			string strGENo="";
			bool blnIsExist=false;
			new clsBedGEMaintenanceDomain().m_mthGetBedGEinf(MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID,ref strGENo,ref blnIsExist);	
			return blnIsExist;
		}
		#endregion 判断当前用户是否连接GE仪器

		#region 从监护仪获取数据
		private void GetData()
		{
			try
			{
				XmlDocument	objXMLDoc = new XmlDocument();

				clsCMSData			objCMSData;				//监护仪
				clsVentilatorData	objVentilatorData;		//呼吸机
				clsGECMSData objGECMSData=null;

				bool blnIsGE=m_blnCurrApparatus();

				m_mthGetICUDataByTime(m_dtpGetDataTime.Value,out objCMSData,out objVentilatorData);
				if (blnIsGE)
					m_mthGetICUGEDataByTime(m_dtpGetDataTime.Value,out objGECMSData);
				if (!blnIsGE)
				{
					if (objCMSData != null)
					{
						//脉搏
						if(objCMSData.m_strPulseRate == null || objCMSData.m_strPulseRate.Trim().Length == 0)
							m_txtPulse.Text = "";
						else
							m_txtPulse.Text = objCMSData.m_strPulseRate.Trim().Substring(0,objCMSData.m_strPulseRate.Trim().Length-3);
						
						//心率	
						if(objCMSData.m_strHeartRate == null || objCMSData.m_strHeartRate.Trim().Length == 0)
							m_txtHeartRate.Text = "";
						else
							m_txtHeartRate.Text = objCMSData.m_strHeartRate.Trim().Substring(0,objCMSData.m_strHeartRate.Trim().Length-3);

						//体温
						if(objCMSData.m_strTemp1 == null || objCMSData.m_strTemp1.Trim().Length == 0)
							m_txtTemperature.Text="";
						else
							m_txtTemperature.Text=objCMSData.m_strTemp1.Trim().Substring(objCMSData.m_strTemp1.Trim().Length-3);

						//收缩压
						if(objCMSData.m_strNPBSYSTOLIC == null || objCMSData.m_strNPBSYSTOLIC.Trim().Length == 0)
							m_txtSystolic.Text="";
						else
							m_txtSystolic.Text=objCMSData.m_strNPBSYSTOLIC;

						//舒张压
						if(objCMSData.m_strNPBDIASTOLIC == null || objCMSData.m_strNPBDIASTOLIC.Trim().Length == 0)
							m_txtDiastolic.Text="";
						else
							m_txtDiastolic.Text=objCMSData.m_strNPBDIASTOLIC;
					}
				}
				else
				{
					if (objGECMSData != null)
					{
						//脉搏
						if(objGECMSData.m_strPluse == null || objGECMSData.m_strPluse.Trim().Length == 0)
							m_txtPulse.Text = "";
						else
							m_txtPulse.Text = objGECMSData.m_strPluse;

						//心率
						if(objGECMSData.m_strHR  == null || objGECMSData.m_strHR.Trim().Length == 0)
							m_txtHeartRate.Text = "";
						else
							m_txtHeartRate.Text = objGECMSData.m_strHR;

						//体温
						if(objGECMSData.m_strTEMP1 == null || objGECMSData.m_strTEMP1.Trim().Length == 0)
							m_txtTemperature.Text="";
						else
							m_txtTemperature.Text=objGECMSData.m_strTEMP1;

						//收缩压
						if(objGECMSData.m_strNBPSystolic == null || objGECMSData.m_strNBPSystolic.Trim().Length == 0)
							m_txtSystolic.Text="";
						else
							m_txtSystolic.Text=objGECMSData.m_strNBPSystolic;

						//舒张压
						if(objGECMSData.m_strNBPDiastolic == null || objGECMSData.m_strNBPDiastolic.Trim().Length == 0)
							m_txtDiastolic.Text="";
						else
							m_txtDiastolic.Text=objGECMSData.m_strNBPDiastolic;
					}
				}
			}
			catch
			{
			}
		}

		private void m_mthGetICUDataByTime(DateTime p_dtmStart,out clsCMSData p_objCMSData,out clsVentilatorData p_objVentilatorData)
		{
			//病区ID用最后三位，不然会超过long的最大范围
			//string strLongBedID = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID.Substring(4)+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomID+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
			string strLongBedID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID+MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
			strLongBedID=strLongBedID.PadRight(17,'0');
			new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,strLongBedID).m_mthGetICUDataByTime("",p_dtmStart,out p_objCMSData,out p_objVentilatorData);
		}

		#region 获取ICU GE数据
		private void m_mthGetICUGEDataByTime(DateTime p_dtmStart,out clsGECMSData p_objGECMSData)
		{
			p_objGECMSData=null;	
			string strLongBedID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID+MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID.Substring(4)+MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomID+MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
			//			new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,strLongBedID).m_mthGetICUGEDataByTime(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,p_dtmStart,out p_objGECMSData);
		}
		#endregion 获取ICU GE数据

		#endregion 从监护仪获取数据

		private void m_cmdGetDovueData_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient==null)return;

			GetData();

			#region Old
			//			this.m_txtTemperature.Text="";
			//			this.m_txtHeartRate.Text="";
			//			this.m_txtPulse.Text="";			
			//			this.m_txtSystolic.Text="";
			//			this.m_txtDiastolic.Text="";
			//
			//			clsTrendDomain objDomain=new clsTrendDomain();
			//			string[] strEMFC_IDArr=new string[]{"100","40","40","89","90"};//体温，心率，脉搏，收缩压，舒张压
			//			string[] strResultArr;
			//			long lngRes=objDomain.m_lngGetDocvueResultArr(this.m_objBaseCurrentPatient.m_StrInPatientID,this.m_objBaseCurrentPatient.m_DtmLastInDate,strEMFC_IDArr,m_dtpTurnTime.Value,out strResultArr);
			//			if(lngRes<=0)
			//			{
			//				switch(lngRes)
			//				{
			//					case (long)(iCareData.enmOperationResult.Not_permission) :
			//						m_mthShowNotPermitted();break;
			//					case (long)(iCareData.enmOperationResult.DB_Fail) :
			//						m_mthShowDBError();break;
			//				}
			//			}
			//			else 
			//			{
			//				this.m_txtTemperature.Text=strResultArr[0];
			//				this.m_txtHeartRate.Text=strResultArr[1];
			//				this.m_txtPulse.Text=strResultArr[2];				
			//				this.m_txtSystolic.Text=strResultArr[3];
			//				this.m_txtDiastolic.Text=strResultArr[4];				
			//			}
			#endregion Old
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			//默认埴
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
			//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
			//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			//			{
			//				this.m_txtInDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;						
			//			}		
		}
		protected string m_strGetDeptID(string p_strParamID)
		{
			string strIniFile=".\\ID.ini";
			if(System.IO.File.Exists(strIniFile))
			{
				clsIniFile objIni=new clsIniFile(strIniFile);
				return objIni.ReadString("IcuDepartMentID",p_strParamID,"");
			}
			else
			{
				return "";
			}
		}

		protected string[] m_strGetDeptIDFromDetpConfig()
		{
			string[] strDeptArr = null;
            clsDepartmentManagerService objDetpServ =
                (clsDepartmentManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDepartmentManagerService));

			long lngRes = objDetpServ.m_lngGetDeptIDFromDetpConfig(1, out strDeptArr);
			return strDeptArr;
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (m_objBaseCurrentPatient == null || p_objSelectedSession == null)
            {
                return;
            }

            m_objBaseCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objBaseCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthSetPatientFormInfo(m_objBaseCurrentPatient);

        }
        
	}
}

