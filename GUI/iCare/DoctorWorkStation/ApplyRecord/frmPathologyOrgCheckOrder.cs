using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;


namespace iCare
{
	public class frmPathologyOrgCheckOrder : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Windows Generate
		private System.Windows.Forms.TreeView trvTime;
		protected System.Windows.Forms.Label label1;
		private com.digitalwave.controls.ctlRichTextBox txtHistory;
		protected System.Windows.Forms.Label label2;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalInfo;
		protected System.Windows.Forms.Label label3;
		private com.digitalwave.controls.ctlRichTextBox txtOperationInfo;
		protected System.Windows.Forms.Label label4;
		protected System.Windows.Forms.Label label5;
		private com.digitalwave.controls.ctlRichTextBox txtCheckAim;
		private com.digitalwave.controls.ctlRichTextBox txtBiologyChemistry;
		protected System.Windows.Forms.Label label6;
		private com.digitalwave.controls.ctlRichTextBox txtBlood;
		protected System.Windows.Forms.Label label7;
		private com.digitalwave.controls.ctlRichTextBox txtXRay;
		protected System.Windows.Forms.Label label8;
		private com.digitalwave.controls.ctlRichTextBox txtBloodSerum;
		protected System.Windows.Forms.Label label9;
		private com.digitalwave.controls.ctlRichTextBox txtOther;
		protected System.Windows.Forms.Label label10;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalDignose;
		private System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label label12;
		protected System.Windows.Forms.Label label16;
		protected System.Windows.Forms.Label label17;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpSendDate;
		protected System.Windows.Forms.Label label18;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpReceiveDate;
		protected System.Windows.Forms.Label label19;
		protected System.Windows.Forms.Label label20;
		protected System.Windows.Forms.Label label21;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpReportDate;
		protected System.Windows.Forms.Label label22;
		protected System.Windows.Forms.Label lblNativePlace;
		protected System.Windows.Forms.Label label23;
		protected System.Windows.Forms.Label lblOccupation;
		protected System.Windows.Forms.Label label24;
		protected System.Windows.Forms.Label lblMarrige;
		protected System.Windows.Forms.Label label25;
		protected System.Windows.Forms.Label lblDept_Local ;
		protected System.Windows.Forms.Label label26;
		private com.digitalwave.controls.ctlRichTextBox txtColorAndSlice;
		private com.digitalwave.controls.ctlRichTextBox txtEyeCheck;
		private System.Windows.Forms.DataGrid dtgChecker;
		private System.Windows.Forms.DataGrid dtgMaker;
		private System.Windows.Forms.GroupBox grpOrg;
		public com.digitalwave.controls.ctlRichTextBox txtHospitalName;
		protected System.Windows.Forms.Label label27;
		public com.digitalwave.controls.ctlRichTextBox txtLastCheckNumber;
		protected System.Windows.Forms.Label label28;
		public com.digitalwave.controls.ctlRichTextBox txtSendThing;
		protected System.Windows.Forms.Label label29;
		public com.digitalwave.controls.ctlRichTextBox txtFromBody;
		protected System.Windows.Forms.Label label30;
		public com.digitalwave.controls.ctlRichTextBox txtSickenPeriod;
		private com.digitalwave.controls.ctlRichTextBox txtPathologyDignose;
		private System.Windows.Forms.DataGrid dtgReporter;
		private System.Windows.Forms.RadioButton rdbOrganiseBuryFull;
		private System.Windows.Forms.RadioButton rdbOrganiseStay;
		private System.Windows.Forms.RadioButton rdbEyeSample;
		private System.Windows.Forms.DataGridTableStyle dtbCheckerStyle;
		private System.Windows.Forms.DataGridTextBoxColumn dcmCheckerID;
		private System.Windows.Forms.DataGridTextBoxColumn dcmCheckerName;
		private System.Windows.Forms.DataGridTableStyle dtbMakerStyle;
		private System.Windows.Forms.DataGridTextBoxColumn dcmMakerID;
		private System.Windows.Forms.DataGridTextBoxColumn dcmMakerName;
		private System.Windows.Forms.DataGridTableStyle dtbReporterStyle;
		private System.Windows.Forms.DataGridTextBoxColumn dcmReporterID;
		private System.Windows.Forms.DataGridTextBoxColumn dcmReporterName;
		protected System.Windows.Forms.Label label31;
		protected System.Windows.Forms.Label lblSickRoom;
		private System.Windows.Forms.ListView lsvLike;
		private System.Windows.Forms.ColumnHeader clmEmployeeID;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.GroupBox grpMap;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox7;
		protected System.Windows.Forms.Label label34;
        public com.digitalwave.controls.ctlRichTextBox txtMedicalCheckNo;
		private System.ComponentModel.IContainer components = null;
		#endregion
		private PinkieControls.ButtonXP m_cmdEmployeeSign;

		#region Constructor
		private clsEmployeeSignTool m_objSignTool;
		private clsEmployeeSignTool m_objSignTool2;
        private PinkieControls.ButtonXP m_cmdDoctor;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView lsvLike1;
        private Panel panel4;
        private TextBox m_txtDoctor;
        private TextBox m_txtSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		public frmPathologyOrgCheckOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee,false);
            //m_objSignTool.m_mthAddControl(m_txtSign);

            //m_objSignTool2 = new clsEmployeeSignTool(m_lsvDoctor );
            //m_objSignTool2.m_mthAddControl(m_txtDoctor );

			m_objDomain = new clsPathologyOrgCheckOrderDomain();

			#region White Border
            //m_objBorderTool = new clsBorderTool(Color.White);

            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
                //if(typeName == "ctlRichTextBox" )
                //{
                //    m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlControl ,
                //    });
                //}
                //if(typeName == "DataGrid")
                //{
                //    m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlControl ,
                //    });
                //    ((DataGrid)ctlControl).AllowSorting =false ;
                //}

                //if(typeName =="TreeView")
                //{
                //    m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlControl ,
                //    });
                //}

                //if(typeName == "GroupBox")
                //{
                //    foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
                //    {
                //        string strSubTypeName = ctlGrp.GetType().Name;
                //        if(strSubTypeName == "PictureBox")
                //        {
                //            m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlGrp ,
                //            });
                //        }
                //    }
                //}
            //}
			#endregion

			#region DataGrid 的初始化
			dtbChecker = new DataTable("dtbChecker");
			dtbMaker = new DataTable("dtbMaker");
			dtbReporter = new DataTable("dtbReporter");

			dtbChecker.Columns.Add("检查人ID");
			dtbChecker.Columns.Add("检查人姓名");
			dtgChecker.DataSource = dtbChecker;

			dtbMaker.Columns.Add("制片人ID");
			dtbMaker.Columns.Add("制片人姓名");
			dtgMaker.DataSource = dtbMaker;

			dtbReporter.Columns.Add("报告者ID");
			dtbReporter.Columns.Add("报告者姓名");
			dtgReporter.DataSource = dtbReporter;

			m_objGridListView0 = new clsGridListView(dtgChecker,dcmCheckerID,lsvLike,new EventHandler(m_objAddListViewItemArr));
			m_objGridListView1 = new clsGridListView(dtgMaker,dcmMakerID,lsvLike,new EventHandler(m_objAddListViewItemArr));
			m_objGridListView2 = new clsGridListView(dtgReporter,dcmReporterID,lsvLike1,new EventHandler(m_objAddListViewItemArr));

			dtgChecker.GotFocus += new EventHandler(m_mthChecker_GotFocus);
			dtgMaker.GotFocus += new EventHandler(m_mthMaker_GotFocus);
			dtgReporter.GotFocus += new EventHandler(m_mthReporter_GotFocus);

			dtgChecker.Focus();
			txtInPatientID.Focus();
			dtgMaker.Focus();
			txtInPatientID.Focus();
			dtgReporter.Focus();
			txtInPatientID.Focus();
			#endregion

			//			m_arlChecker = new ArrayList();
			//			m_arlMaker = new ArrayList();
			//			m_arlReporter = new ArrayList();

			m_dtsRept = InitdtsPathologyOrgCheckOrderDataSet();

			//			m_rpdOrderRept = new ReportDocument();
			//			m_rpdOrderRept.Load(m_strTemplatePath + "rptPathologyOrgCheckOrder.rpt");

			m_mthSetQuickKeys();

            ////签名常用值
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.m_cmdEmployeeSign,this.m_cmdDoctor },
            //    new Control[] { this.m_txtSign, this.m_txtDoctor }, new int[] { 1, 1 });
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctor, m_txtDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}
		#endregion

		#region Member
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private clsBorderTool  m_objBorderTool;

		private bool m_blnCanSearch = true;

		private clsPatient m_objSelectedPatient;

		private string m_strInPatientID;

		private string m_strInPatientDate;

		private clsPathologyOrgCheckOrderDomain m_objDomain;

		private DataTable dtbChecker;
		private DataTable dtbMaker;
		private DataTable dtbReporter;

		private int m_intColumnNumber;
		private int m_intRowNumber;
		private string m_strSenderName = "";

		//		private ArrayList m_arlChecker;
		//		private ArrayList m_arlMaker;
		//		private ArrayList m_arlReporter;

		private clsGridListView m_objGridListView0;
		private clsGridListView m_objGridListView1;
		private clsGridListView m_objGridListView2;

		private clsPathologyOrgCheckOrderInfo m_objPathologyOrgCheckOrder;

		private clsPathologyOrgCheckOperatorID[] m_objOperator;

		private string m_strCreateDate = "";

		private bool blnCanDelete = true;

		/// <summary>
		/// 出报表的DataSet
		/// </summary>
		private DataSet m_dtsRept;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		#endregion

		#region Dispose
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPathologyOrgCheckOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClinicalInfo = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOperationInfo = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckAim = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBiologyChemistry = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBlood = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtXRay = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBloodSerum = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOther = new com.digitalwave.controls.ctlRichTextBox();
            this.txtClinicalDignose = new com.digitalwave.controls.ctlRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpSendDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpReceiveDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtColorAndSlice = new com.digitalwave.controls.ctlRichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEyeCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.dtgChecker = new System.Windows.Forms.DataGrid();
            this.dtbCheckerStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmCheckerID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmCheckerName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgMaker = new System.Windows.Forms.DataGrid();
            this.dtbMakerStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmMakerID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmMakerName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grpOrg = new System.Windows.Forms.GroupBox();
            this.rdbEyeSample = new System.Windows.Forms.RadioButton();
            this.rdbOrganiseStay = new System.Windows.Forms.RadioButton();
            this.rdbOrganiseBuryFull = new System.Windows.Forms.RadioButton();
            this.txtPathologyDignose = new com.digitalwave.controls.ctlRichTextBox();
            this.dtgReporter = new System.Windows.Forms.DataGrid();
            this.dtbReporterStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmReporterID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmReporterName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpReportDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.lblNativePlace = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblMarrige = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblDept_Local = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtHospitalName = new com.digitalwave.controls.ctlRichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtLastCheckNumber = new com.digitalwave.controls.ctlRichTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSendThing = new com.digitalwave.controls.ctlRichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtFromBody = new com.digitalwave.controls.ctlRichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtSickenPeriod = new com.digitalwave.controls.ctlRichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lblSickRoom = new System.Windows.Forms.Label();
            this.lsvLike = new System.Windows.Forms.ListView();
            this.clmEmployeeID = new System.Windows.Forms.ColumnHeader();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.label33 = new System.Windows.Forms.Label();
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtMedicalCheckNo = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_cmdDoctor = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvLike1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtDoctor = new System.Windows.Forms.TextBox();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChecker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaker)).BeginInit();
            this.grpOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporter)).BeginInit();
            this.grpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(242, 167);
            this.lblSex.Size = new System.Drawing.Size(20, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(257, 178);
            this.lblAge.Size = new System.Drawing.Size(32, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(247, 181);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(208, 178);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(268, 176);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(213, 156);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(247, 185);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(247, 202);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(250, 188);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(224, 188);
            this.txtInPatientID.Size = new System.Drawing.Size(76, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(250, 171);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(250, 173);
            this.m_txtBedNO.Size = new System.Drawing.Size(56, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(224, 206);
            this.m_cboArea.Size = new System.Drawing.Size(132, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(250, 188);
            this.m_lsvPatientName.Size = new System.Drawing.Size(72, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(250, 188);
            this.m_lsvBedNO.Size = new System.Drawing.Size(68, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(211, 208);
            this.m_cboDept.Size = new System.Drawing.Size(132, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(214, 206);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(250, 235);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(279, 179);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(232, 208);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(251, 178);
            this.m_lblForTitle.Text = "病理活体组织送验单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(105, 205);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(726, 61);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 29);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.txtHospitalName);
            this.m_pnlNewBase.Controls.Add(this.txtSickenPeriod);
            this.m_pnlNewBase.Controls.Add(this.label30);
            this.m_pnlNewBase.Controls.Add(this.label26);
            this.m_pnlNewBase.Controls.Add(this.trvTime);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 8);
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 85);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.trvTime, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label26, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label30, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtSickenPeriod, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtHospitalName, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(192, 29);
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(604, 55);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(0, 29);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(190, 53);
            this.trvTime.TabIndex = 504;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 14);
            this.label1.TabIndex = 1295;
            this.label1.Text = "病历撮要:（妇产科标本请注明末次月经日期、产次、经初潮日期及妇科之内外检结果）";
            // 
            // txtHistory
            // 
            this.txtHistory.AccessibleDescription = "病历摘要";
            this.txtHistory.BackColor = System.Drawing.Color.White;
            this.txtHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHistory.ForeColor = System.Drawing.Color.Black;
            this.txtHistory.Location = new System.Drawing.Point(8, 28);
            this.txtHistory.m_BlnPartControl = false;
            this.txtHistory.m_BlnReadOnly = false;
            this.txtHistory.m_BlnUnderLineDST = false;
            this.txtHistory.m_ClrDST = System.Drawing.Color.Red;
            this.txtHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtHistory.m_IntCanModifyTime = 6;
            this.txtHistory.m_IntPartControlLength = 0;
            this.txtHistory.m_IntPartControlStartIndex = 0;
            this.txtHistory.m_StrUserID = "";
            this.txtHistory.m_StrUserName = "";
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtHistory.Size = new System.Drawing.Size(740, 56);
            this.txtHistory.TabIndex = 606;
            this.txtHistory.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1297;
            this.label2.Text = "临床所见:";
            // 
            // txtClinicalInfo
            // 
            this.txtClinicalInfo.AccessibleDescription = "临床所见";
            this.txtClinicalInfo.BackColor = System.Drawing.Color.White;
            this.txtClinicalInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalInfo.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalInfo.Location = new System.Drawing.Point(8, 108);
            this.txtClinicalInfo.m_BlnPartControl = false;
            this.txtClinicalInfo.m_BlnReadOnly = false;
            this.txtClinicalInfo.m_BlnUnderLineDST = false;
            this.txtClinicalInfo.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalInfo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalInfo.m_IntCanModifyTime = 6;
            this.txtClinicalInfo.m_IntPartControlLength = 0;
            this.txtClinicalInfo.m_IntPartControlStartIndex = 0;
            this.txtClinicalInfo.m_StrUserID = "";
            this.txtClinicalInfo.m_StrUserName = "";
            this.txtClinicalInfo.Name = "txtClinicalInfo";
            this.txtClinicalInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalInfo.Size = new System.Drawing.Size(328, 44);
            this.txtClinicalInfo.TabIndex = 607;
            this.txtClinicalInfo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(340, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 14);
            this.label3.TabIndex = 1299;
            this.label3.Text = "手术所见:(肿瘤标本请注明肿瘤大小、肿瘤位置、有无转移性瘤)";
            // 
            // txtOperationInfo
            // 
            this.txtOperationInfo.AccessibleDescription = "手术所见";
            this.txtOperationInfo.BackColor = System.Drawing.Color.White;
            this.txtOperationInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperationInfo.ForeColor = System.Drawing.Color.Black;
            this.txtOperationInfo.Location = new System.Drawing.Point(339, 108);
            this.txtOperationInfo.m_BlnPartControl = false;
            this.txtOperationInfo.m_BlnReadOnly = false;
            this.txtOperationInfo.m_BlnUnderLineDST = false;
            this.txtOperationInfo.m_ClrDST = System.Drawing.Color.Red;
            this.txtOperationInfo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOperationInfo.m_IntCanModifyTime = 6;
            this.txtOperationInfo.m_IntPartControlLength = 0;
            this.txtOperationInfo.m_IntPartControlStartIndex = 0;
            this.txtOperationInfo.m_StrUserID = "";
            this.txtOperationInfo.m_StrUserName = "";
            this.txtOperationInfo.Name = "txtOperationInfo";
            this.txtOperationInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOperationInfo.Size = new System.Drawing.Size(408, 44);
            this.txtOperationInfo.TabIndex = 608;
            this.txtOperationInfo.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(5, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 1301;
            this.label4.Text = "申请检验目的:";
            // 
            // txtCheckAim
            // 
            this.txtCheckAim.AccessibleDescription = "申请检验目的";
            this.txtCheckAim.BackColor = System.Drawing.Color.White;
            this.txtCheckAim.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckAim.ForeColor = System.Drawing.Color.Black;
            this.txtCheckAim.Location = new System.Drawing.Point(7, 172);
            this.txtCheckAim.m_BlnPartControl = false;
            this.txtCheckAim.m_BlnReadOnly = false;
            this.txtCheckAim.m_BlnUnderLineDST = false;
            this.txtCheckAim.m_ClrDST = System.Drawing.Color.Red;
            this.txtCheckAim.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCheckAim.m_IntCanModifyTime = 6;
            this.txtCheckAim.m_IntPartControlLength = 0;
            this.txtCheckAim.m_IntPartControlStartIndex = 0;
            this.txtCheckAim.m_StrUserID = "";
            this.txtCheckAim.m_StrUserName = "";
            this.txtCheckAim.Name = "txtCheckAim";
            this.txtCheckAim.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCheckAim.Size = new System.Drawing.Size(328, 44);
            this.txtCheckAim.TabIndex = 609;
            this.txtCheckAim.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(340, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 1303;
            this.label5.Text = "生        化:";
            // 
            // txtBiologyChemistry
            // 
            this.txtBiologyChemistry.AccessibleDescription = "生化";
            this.txtBiologyChemistry.BackColor = System.Drawing.Color.White;
            this.txtBiologyChemistry.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBiologyChemistry.ForeColor = System.Drawing.Color.Black;
            this.txtBiologyChemistry.Location = new System.Drawing.Point(340, 172);
            this.txtBiologyChemistry.m_BlnPartControl = false;
            this.txtBiologyChemistry.m_BlnReadOnly = false;
            this.txtBiologyChemistry.m_BlnUnderLineDST = false;
            this.txtBiologyChemistry.m_ClrDST = System.Drawing.Color.Red;
            this.txtBiologyChemistry.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBiologyChemistry.m_IntCanModifyTime = 6;
            this.txtBiologyChemistry.m_IntPartControlLength = 0;
            this.txtBiologyChemistry.m_IntPartControlStartIndex = 0;
            this.txtBiologyChemistry.m_StrUserID = "";
            this.txtBiologyChemistry.m_StrUserName = "";
            this.txtBiologyChemistry.Name = "txtBiologyChemistry";
            this.txtBiologyChemistry.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBiologyChemistry.Size = new System.Drawing.Size(408, 44);
            this.txtBiologyChemistry.TabIndex = 610;
            this.txtBiologyChemistry.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 1305;
            this.label6.Text = "血        液:";
            // 
            // txtBlood
            // 
            this.txtBlood.AccessibleDescription = "血液";
            this.txtBlood.BackColor = System.Drawing.Color.White;
            this.txtBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBlood.ForeColor = System.Drawing.Color.Black;
            this.txtBlood.Location = new System.Drawing.Point(7, 240);
            this.txtBlood.m_BlnPartControl = false;
            this.txtBlood.m_BlnReadOnly = false;
            this.txtBlood.m_BlnUnderLineDST = false;
            this.txtBlood.m_ClrDST = System.Drawing.Color.Red;
            this.txtBlood.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBlood.m_IntCanModifyTime = 6;
            this.txtBlood.m_IntPartControlLength = 0;
            this.txtBlood.m_IntPartControlStartIndex = 0;
            this.txtBlood.m_StrUserID = "";
            this.txtBlood.m_StrUserName = "";
            this.txtBlood.Name = "txtBlood";
            this.txtBlood.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBlood.Size = new System.Drawing.Size(328, 44);
            this.txtBlood.TabIndex = 611;
            this.txtBlood.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(340, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 1307;
            this.label7.Text = "X         光:";
            // 
            // txtXRay
            // 
            this.txtXRay.AccessibleDescription = "X光";
            this.txtXRay.BackColor = System.Drawing.Color.White;
            this.txtXRay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXRay.ForeColor = System.Drawing.Color.Black;
            this.txtXRay.Location = new System.Drawing.Point(340, 240);
            this.txtXRay.m_BlnPartControl = false;
            this.txtXRay.m_BlnReadOnly = false;
            this.txtXRay.m_BlnUnderLineDST = false;
            this.txtXRay.m_ClrDST = System.Drawing.Color.Red;
            this.txtXRay.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtXRay.m_IntCanModifyTime = 6;
            this.txtXRay.m_IntPartControlLength = 0;
            this.txtXRay.m_IntPartControlStartIndex = 0;
            this.txtXRay.m_StrUserID = "";
            this.txtXRay.m_StrUserName = "";
            this.txtXRay.Name = "txtXRay";
            this.txtXRay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtXRay.Size = new System.Drawing.Size(408, 44);
            this.txtXRay.TabIndex = 612;
            this.txtXRay.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(1, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 1309;
            this.label8.Text = "细 菌 血 清: ";
            // 
            // txtBloodSerum
            // 
            this.txtBloodSerum.AccessibleDescription = "细菌血清";
            this.txtBloodSerum.BackColor = System.Drawing.Color.White;
            this.txtBloodSerum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBloodSerum.ForeColor = System.Drawing.Color.Black;
            this.txtBloodSerum.Location = new System.Drawing.Point(7, 308);
            this.txtBloodSerum.m_BlnPartControl = false;
            this.txtBloodSerum.m_BlnReadOnly = false;
            this.txtBloodSerum.m_BlnUnderLineDST = false;
            this.txtBloodSerum.m_ClrDST = System.Drawing.Color.Red;
            this.txtBloodSerum.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBloodSerum.m_IntCanModifyTime = 6;
            this.txtBloodSerum.m_IntPartControlLength = 0;
            this.txtBloodSerum.m_IntPartControlStartIndex = 0;
            this.txtBloodSerum.m_StrUserID = "";
            this.txtBloodSerum.m_StrUserName = "";
            this.txtBloodSerum.Name = "txtBloodSerum";
            this.txtBloodSerum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBloodSerum.Size = new System.Drawing.Size(328, 44);
            this.txtBloodSerum.TabIndex = 613;
            this.txtBloodSerum.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(341, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 14);
            this.label9.TabIndex = 1311;
            this.label9.Text = "其       他: ";
            // 
            // txtOther
            // 
            this.txtOther.AccessibleDescription = "其他";
            this.txtOther.BackColor = System.Drawing.Color.White;
            this.txtOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOther.ForeColor = System.Drawing.Color.Black;
            this.txtOther.Location = new System.Drawing.Point(339, 308);
            this.txtOther.m_BlnPartControl = false;
            this.txtOther.m_BlnReadOnly = false;
            this.txtOther.m_BlnUnderLineDST = false;
            this.txtOther.m_ClrDST = System.Drawing.Color.Red;
            this.txtOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOther.m_IntCanModifyTime = 6;
            this.txtOther.m_IntPartControlLength = 0;
            this.txtOther.m_IntPartControlStartIndex = 0;
            this.txtOther.m_StrUserID = "";
            this.txtOther.m_StrUserName = "";
            this.txtOther.Name = "txtOther";
            this.txtOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOther.Size = new System.Drawing.Size(408, 44);
            this.txtOther.TabIndex = 614;
            this.txtOther.Text = "";
            // 
            // txtClinicalDignose
            // 
            this.txtClinicalDignose.AccessibleDescription = "临床诊断";
            this.txtClinicalDignose.BackColor = System.Drawing.Color.White;
            this.txtClinicalDignose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalDignose.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalDignose.Location = new System.Drawing.Point(7, 376);
            this.txtClinicalDignose.m_BlnPartControl = false;
            this.txtClinicalDignose.m_BlnReadOnly = false;
            this.txtClinicalDignose.m_BlnUnderLineDST = false;
            this.txtClinicalDignose.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalDignose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalDignose.m_IntCanModifyTime = 6;
            this.txtClinicalDignose.m_IntPartControlLength = 0;
            this.txtClinicalDignose.m_IntPartControlStartIndex = 0;
            this.txtClinicalDignose.m_StrUserID = "";
            this.txtClinicalDignose.m_StrUserName = "";
            this.txtClinicalDignose.Name = "txtClinicalDignose";
            this.txtClinicalDignose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalDignose.Size = new System.Drawing.Size(740, 44);
            this.txtClinicalDignose.TabIndex = 615;
            this.txtClinicalDignose.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(4, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 1314;
            this.label10.Text = "临 床 诊 断: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 1315;
            this.label11.Text = "病理诊断: ";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(9, 432);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 36);
            this.label12.TabIndex = 1316;
            this.label12.Text = "（以上各栏由）送检人填写";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(105, 432);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(476, 14);
            this.label16.TabIndex = 1320;
            this.label16.Text = "(若系再次送验的病例，请注明以前报告的病理诊断和医检列号，以便查对) ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(8, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 1321;
            this.label17.Text = "送诊日期: ";
            // 
            // dtpSendDate
            // 
            this.dtpSendDate.BorderColor = System.Drawing.Color.Black;
            this.dtpSendDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpSendDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpSendDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpSendDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpSendDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpSendDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpSendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSendDate.Location = new System.Drawing.Point(93, 9);
            this.dtpSendDate.m_BlnOnlyTime = false;
            this.dtpSendDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpSendDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpSendDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSendDate.Name = "dtpSendDate";
            this.dtpSendDate.ReadOnly = false;
            this.dtpSendDate.Size = new System.Drawing.Size(214, 22);
            this.dtpSendDate.TabIndex = 620;
            this.dtpSendDate.TextBackColor = System.Drawing.Color.White;
            this.dtpSendDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(315, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 14);
            this.label18.TabIndex = 3002;
            this.label18.Text = "本室收到日期: ";
            // 
            // dtpReceiveDate
            // 
            this.dtpReceiveDate.BorderColor = System.Drawing.Color.Black;
            this.dtpReceiveDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpReceiveDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpReceiveDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpReceiveDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpReceiveDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpReceiveDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiveDate.Location = new System.Drawing.Point(429, 9);
            this.dtpReceiveDate.m_BlnOnlyTime = false;
            this.dtpReceiveDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpReceiveDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReceiveDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReceiveDate.Name = "dtpReceiveDate";
            this.dtpReceiveDate.ReadOnly = false;
            this.dtpReceiveDate.Size = new System.Drawing.Size(214, 22);
            this.dtpReceiveDate.TabIndex = 625;
            this.dtpReceiveDate.TextBackColor = System.Drawing.Color.White;
            this.dtpReceiveDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(8, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 3004;
            this.label19.Text = "加切加染: ";
            // 
            // txtColorAndSlice
            // 
            this.txtColorAndSlice.AccessibleDescription = "加切加染";
            this.txtColorAndSlice.BackColor = System.Drawing.Color.White;
            this.txtColorAndSlice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtColorAndSlice.ForeColor = System.Drawing.Color.Black;
            this.txtColorAndSlice.Location = new System.Drawing.Point(8, 178);
            this.txtColorAndSlice.m_BlnPartControl = false;
            this.txtColorAndSlice.m_BlnReadOnly = false;
            this.txtColorAndSlice.m_BlnUnderLineDST = false;
            this.txtColorAndSlice.m_ClrDST = System.Drawing.Color.Red;
            this.txtColorAndSlice.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtColorAndSlice.m_IntCanModifyTime = 6;
            this.txtColorAndSlice.m_IntPartControlLength = 0;
            this.txtColorAndSlice.m_IntPartControlStartIndex = 0;
            this.txtColorAndSlice.m_StrUserID = "";
            this.txtColorAndSlice.m_StrUserName = "";
            this.txtColorAndSlice.Name = "txtColorAndSlice";
            this.txtColorAndSlice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtColorAndSlice.Size = new System.Drawing.Size(368, 50);
            this.txtColorAndSlice.TabIndex = 700;
            this.txtColorAndSlice.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(380, 156);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 14);
            this.label20.TabIndex = 3006;
            this.label20.Text = "肉眼检查: ";
            // 
            // txtEyeCheck
            // 
            this.txtEyeCheck.AccessibleDescription = "肉眼检查";
            this.txtEyeCheck.BackColor = System.Drawing.Color.White;
            this.txtEyeCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEyeCheck.ForeColor = System.Drawing.Color.Black;
            this.txtEyeCheck.Location = new System.Drawing.Point(380, 178);
            this.txtEyeCheck.m_BlnPartControl = false;
            this.txtEyeCheck.m_BlnReadOnly = false;
            this.txtEyeCheck.m_BlnUnderLineDST = false;
            this.txtEyeCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtEyeCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtEyeCheck.m_IntCanModifyTime = 6;
            this.txtEyeCheck.m_IntPartControlLength = 0;
            this.txtEyeCheck.m_IntPartControlStartIndex = 0;
            this.txtEyeCheck.m_StrUserID = "";
            this.txtEyeCheck.m_StrUserName = "";
            this.txtEyeCheck.Name = "txtEyeCheck";
            this.txtEyeCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtEyeCheck.Size = new System.Drawing.Size(368, 50);
            this.txtEyeCheck.TabIndex = 701;
            this.txtEyeCheck.Text = "";
            // 
            // dtgChecker
            // 
            this.dtgChecker.AllowSorting = false;
            this.dtgChecker.BackgroundColor = System.Drawing.Color.White;
            this.dtgChecker.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgChecker.CaptionForeColor = System.Drawing.Color.Black;
            this.dtgChecker.CaptionText = "检查人";
            this.dtgChecker.DataMember = "";
            this.dtgChecker.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgChecker.ForeColor = System.Drawing.Color.Black;
            this.dtgChecker.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgChecker.Location = new System.Drawing.Point(8, 228);
            this.dtgChecker.Name = "dtgChecker";
            this.dtgChecker.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgChecker.PreferredColumnWidth = 100;
            this.dtgChecker.RowHeaderWidth = 40;
            this.dtgChecker.Size = new System.Drawing.Size(364, 132);
            this.dtgChecker.TabIndex = 800;
            this.dtgChecker.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbCheckerStyle});
            this.dtgChecker.CurrentCellChanged += new System.EventHandler(this.dtgChecker_CurrentCellChanged);
            // 
            // dtbCheckerStyle
            // 
            this.dtbCheckerStyle.AllowSorting = false;
            this.dtbCheckerStyle.DataGrid = this.dtgChecker;
            this.dtbCheckerStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmCheckerID,
            this.dcmCheckerName});
            this.dtbCheckerStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbCheckerStyle.MappingName = "dtbChecker";
            this.dtbCheckerStyle.PreferredColumnWidth = 100;
            // 
            // dcmCheckerID
            // 
            this.dcmCheckerID.Format = "";
            this.dcmCheckerID.FormatInfo = null;
            this.dcmCheckerID.HeaderText = "检查人ID";
            this.dcmCheckerID.MappingName = "检查人ID";
            this.dcmCheckerID.NullText = "";
            this.dcmCheckerID.Width = 150;
            // 
            // dcmCheckerName
            // 
            this.dcmCheckerName.Format = "";
            this.dcmCheckerName.FormatInfo = null;
            this.dcmCheckerName.HeaderText = "姓名";
            this.dcmCheckerName.MappingName = "检查人姓名";
            this.dcmCheckerName.NullText = "";
            this.dcmCheckerName.ReadOnly = true;
            this.dcmCheckerName.Width = 75;
            // 
            // dtgMaker
            // 
            this.dtgMaker.AllowSorting = false;
            this.dtgMaker.BackgroundColor = System.Drawing.Color.White;
            this.dtgMaker.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgMaker.CaptionForeColor = System.Drawing.Color.Black;
            this.dtgMaker.CaptionText = "制片人";
            this.dtgMaker.DataMember = "";
            this.dtgMaker.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgMaker.ForeColor = System.Drawing.Color.Black;
            this.dtgMaker.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgMaker.Location = new System.Drawing.Point(380, 228);
            this.dtgMaker.Name = "dtgMaker";
            this.dtgMaker.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgMaker.PreferredColumnWidth = 100;
            this.dtgMaker.RowHeaderWidth = 20;
            this.dtgMaker.Size = new System.Drawing.Size(368, 132);
            this.dtgMaker.TabIndex = 900;
            this.dtgMaker.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbMakerStyle});
            this.dtgMaker.CurrentCellChanged += new System.EventHandler(this.dtgMaker_CurrentCellChanged);
            // 
            // dtbMakerStyle
            // 
            this.dtbMakerStyle.AllowSorting = false;
            this.dtbMakerStyle.DataGrid = this.dtgMaker;
            this.dtbMakerStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmMakerID,
            this.dcmMakerName});
            this.dtbMakerStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbMakerStyle.MappingName = "dtbMaker";
            this.dtbMakerStyle.PreferredColumnWidth = 100;
            // 
            // dcmMakerID
            // 
            this.dcmMakerID.Format = "";
            this.dcmMakerID.FormatInfo = null;
            this.dcmMakerID.HeaderText = "制片人ID";
            this.dcmMakerID.MappingName = "制片人ID";
            this.dcmMakerID.NullText = "";
            this.dcmMakerID.Width = 150;
            // 
            // dcmMakerName
            // 
            this.dcmMakerName.Format = "";
            this.dcmMakerName.FormatInfo = null;
            this.dcmMakerName.HeaderText = "姓名";
            this.dcmMakerName.MappingName = "制片人姓名";
            this.dcmMakerName.NullText = "";
            this.dcmMakerName.ReadOnly = true;
            this.dcmMakerName.Width = 75;
            // 
            // grpOrg
            // 
            this.grpOrg.Controls.Add(this.rdbEyeSample);
            this.grpOrg.Controls.Add(this.rdbOrganiseStay);
            this.grpOrg.Controls.Add(this.rdbOrganiseBuryFull);
            this.grpOrg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpOrg.Location = new System.Drawing.Point(8, 360);
            this.grpOrg.Name = "grpOrg";
            this.grpOrg.Size = new System.Drawing.Size(740, 48);
            this.grpOrg.TabIndex = 999;
            this.grpOrg.TabStop = false;
            // 
            // rdbEyeSample
            // 
            this.rdbEyeSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbEyeSample.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbEyeSample.Location = new System.Drawing.Point(592, 20);
            this.rdbEyeSample.Name = "rdbEyeSample";
            this.rdbEyeSample.Size = new System.Drawing.Size(140, 24);
            this.rdbEyeSample.TabIndex = 1002;
            this.rdbEyeSample.TabStop = true;
            this.rdbEyeSample.Text = "留肉眼标本";
            // 
            // rdbOrganiseStay
            // 
            this.rdbOrganiseStay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbOrganiseStay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbOrganiseStay.Location = new System.Drawing.Point(292, 20);
            this.rdbOrganiseStay.Name = "rdbOrganiseStay";
            this.rdbOrganiseStay.Size = new System.Drawing.Size(138, 24);
            this.rdbOrganiseStay.TabIndex = 1001;
            this.rdbOrganiseStay.TabStop = true;
            this.rdbOrganiseStay.Text = "暂留组织块";
            // 
            // rdbOrganiseBuryFull
            // 
            this.rdbOrganiseBuryFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbOrganiseBuryFull.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbOrganiseBuryFull.Location = new System.Drawing.Point(4, 20);
            this.rdbOrganiseBuryFull.Name = "rdbOrganiseBuryFull";
            this.rdbOrganiseBuryFull.Size = new System.Drawing.Size(138, 24);
            this.rdbOrganiseBuryFull.TabIndex = 1000;
            this.rdbOrganiseBuryFull.TabStop = true;
            this.rdbOrganiseBuryFull.Text = "组织块已全埋";
            // 
            // txtPathologyDignose
            // 
            this.txtPathologyDignose.AccessibleDescription = "病理诊断";
            this.txtPathologyDignose.BackColor = System.Drawing.Color.White;
            this.txtPathologyDignose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPathologyDignose.ForeColor = System.Drawing.Color.Black;
            this.txtPathologyDignose.Location = new System.Drawing.Point(8, 36);
            this.txtPathologyDignose.m_BlnPartControl = false;
            this.txtPathologyDignose.m_BlnReadOnly = false;
            this.txtPathologyDignose.m_BlnUnderLineDST = false;
            this.txtPathologyDignose.m_ClrDST = System.Drawing.Color.Red;
            this.txtPathologyDignose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtPathologyDignose.m_IntCanModifyTime = 6;
            this.txtPathologyDignose.m_IntPartControlLength = 0;
            this.txtPathologyDignose.m_IntPartControlStartIndex = 0;
            this.txtPathologyDignose.m_StrUserID = "";
            this.txtPathologyDignose.m_StrUserName = "";
            this.txtPathologyDignose.Name = "txtPathologyDignose";
            this.txtPathologyDignose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtPathologyDignose.Size = new System.Drawing.Size(736, 204);
            this.txtPathologyDignose.TabIndex = 1100;
            this.txtPathologyDignose.Text = "";
            // 
            // dtgReporter
            // 
            this.dtgReporter.AllowSorting = false;
            this.dtgReporter.BackgroundColor = System.Drawing.Color.White;
            this.dtgReporter.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgReporter.CaptionForeColor = System.Drawing.Color.Black;
            this.dtgReporter.CaptionText = "报告者";
            this.dtgReporter.DataMember = "";
            this.dtgReporter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgReporter.ForeColor = System.Drawing.Color.Black;
            this.dtgReporter.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgReporter.Location = new System.Drawing.Point(8, 248);
            this.dtgReporter.Name = "dtgReporter";
            this.dtgReporter.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgReporter.PreferredColumnWidth = 100;
            this.dtgReporter.RowHeaderWidth = 20;
            this.dtgReporter.Size = new System.Drawing.Size(294, 154);
            this.dtgReporter.TabIndex = 1200;
            this.dtgReporter.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbReporterStyle});
            this.dtgReporter.CurrentCellChanged += new System.EventHandler(this.dtgReporter_CurrentCellChanged);
            // 
            // dtbReporterStyle
            // 
            this.dtbReporterStyle.AllowSorting = false;
            this.dtbReporterStyle.DataGrid = this.dtgReporter;
            this.dtbReporterStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmReporterID,
            this.dcmReporterName});
            this.dtbReporterStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbReporterStyle.MappingName = "dtbReporter";
            this.dtbReporterStyle.PreferredColumnWidth = 100;
            // 
            // dcmReporterID
            // 
            this.dcmReporterID.Format = "";
            this.dcmReporterID.FormatInfo = null;
            this.dcmReporterID.HeaderText = "报告者ID";
            this.dcmReporterID.MappingName = "报告者ID";
            this.dcmReporterID.NullText = "";
            this.dcmReporterID.Width = 150;
            // 
            // dcmReporterName
            // 
            this.dcmReporterName.Format = "";
            this.dcmReporterName.FormatInfo = null;
            this.dcmReporterName.HeaderText = "姓名";
            this.dcmReporterName.MappingName = "报告者姓名";
            this.dcmReporterName.NullText = "";
            this.dcmReporterName.ReadOnly = true;
            this.dcmReporterName.Width = 75;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(452, 336);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 3014;
            this.label21.Text = "报告日期: ";
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.BorderColor = System.Drawing.Color.Black;
            this.dtpReportDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpReportDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpReportDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpReportDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpReportDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpReportDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(528, 332);
            this.dtpReportDate.m_BlnOnlyTime = false;
            this.dtpReportDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpReportDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReportDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.ReadOnly = false;
            this.dtpReportDate.Size = new System.Drawing.Size(212, 22);
            this.dtpReportDate.TabIndex = 1300;
            this.dtpReportDate.TextBackColor = System.Drawing.Color.White;
            this.dtpReportDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(247, 191);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 14);
            this.label22.TabIndex = 3016;
            this.label22.Text = "籍贯:";
            this.label22.Visible = false;
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNativePlace.Location = new System.Drawing.Point(148, 202);
            this.lblNativePlace.Name = "lblNativePlace";
            this.lblNativePlace.Size = new System.Drawing.Size(148, 23);
            this.lblNativePlace.TabIndex = 3017;
            this.lblNativePlace.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(229, 216);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 3018;
            this.label23.Text = "职业:";
            this.label23.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOccupation.Location = new System.Drawing.Point(148, 225);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(208, 23);
            this.lblOccupation.TabIndex = 3019;
            this.lblOccupation.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(199, 215);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 14);
            this.label24.TabIndex = 3020;
            this.label24.Text = "婚姻:";
            this.label24.Visible = false;
            // 
            // lblMarrige
            // 
            this.lblMarrige.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMarrige.Location = new System.Drawing.Point(213, 199);
            this.lblMarrige.Name = "lblMarrige";
            this.lblMarrige.Size = new System.Drawing.Size(76, 23);
            this.lblMarrige.TabIndex = 3021;
            this.lblMarrige.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMarrige.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(247, 195);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 14);
            this.label25.TabIndex = 3022;
            this.label25.Text = "科别:";
            this.label25.Visible = false;
            // 
            // lblDept_Local
            // 
            this.lblDept_Local.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept_Local.Location = new System.Drawing.Point(268, 194);
            this.lblDept_Local.Name = "lblDept_Local";
            this.lblDept_Local.Size = new System.Drawing.Size(28, 20);
            this.lblDept_Local.TabIndex = 3023;
            this.lblDept_Local.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(335, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 3024;
            this.label26.Text = "送检医院:";
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.AccessibleDescription = "送检医院";
            this.txtHospitalName.BackColor = System.Drawing.Color.White;
            this.txtHospitalName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHospitalName.ForeColor = System.Drawing.Color.Black;
            this.txtHospitalName.Location = new System.Drawing.Point(404, 60);
            this.txtHospitalName.m_BlnPartControl = false;
            this.txtHospitalName.m_BlnReadOnly = false;
            this.txtHospitalName.m_BlnUnderLineDST = false;
            this.txtHospitalName.m_ClrDST = System.Drawing.Color.Red;
            this.txtHospitalName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtHospitalName.m_IntCanModifyTime = 6;
            this.txtHospitalName.m_IntPartControlLength = 0;
            this.txtHospitalName.m_IntPartControlStartIndex = 0;
            this.txtHospitalName.m_StrUserID = "";
            this.txtHospitalName.m_StrUserName = "";
            this.txtHospitalName.Multiline = false;
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(108, 21);
            this.txtHospitalName.TabIndex = 600;
            this.txtHospitalName.Text = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(2, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 14);
            this.label27.TabIndex = 3026;
            this.label27.Text = "上次医检列号:";
            // 
            // txtLastCheckNumber
            // 
            this.txtLastCheckNumber.AccessibleDescription = "上次医检列号";
            this.txtLastCheckNumber.BackColor = System.Drawing.Color.White;
            this.txtLastCheckNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLastCheckNumber.ForeColor = System.Drawing.Color.Black;
            this.txtLastCheckNumber.Location = new System.Drawing.Point(99, 3);
            this.txtLastCheckNumber.m_BlnPartControl = false;
            this.txtLastCheckNumber.m_BlnReadOnly = false;
            this.txtLastCheckNumber.m_BlnUnderLineDST = false;
            this.txtLastCheckNumber.m_ClrDST = System.Drawing.Color.Red;
            this.txtLastCheckNumber.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtLastCheckNumber.m_IntCanModifyTime = 6;
            this.txtLastCheckNumber.m_IntPartControlLength = 0;
            this.txtLastCheckNumber.m_IntPartControlStartIndex = 0;
            this.txtLastCheckNumber.m_StrUserID = "";
            this.txtLastCheckNumber.m_StrUserName = "";
            this.txtLastCheckNumber.Multiline = false;
            this.txtLastCheckNumber.Name = "txtLastCheckNumber";
            this.txtLastCheckNumber.Size = new System.Drawing.Size(108, 21);
            this.txtLastCheckNumber.TabIndex = 601;
            this.txtLastCheckNumber.Text = "";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(396, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 3028;
            this.label28.Text = "检 验 物:";
            // 
            // txtSendThing
            // 
            this.txtSendThing.AccessibleDescription = "送检物";
            this.txtSendThing.BackColor = System.Drawing.Color.White;
            this.txtSendThing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSendThing.ForeColor = System.Drawing.Color.Black;
            this.txtSendThing.Location = new System.Drawing.Point(468, 3);
            this.txtSendThing.m_BlnPartControl = false;
            this.txtSendThing.m_BlnReadOnly = false;
            this.txtSendThing.m_BlnUnderLineDST = false;
            this.txtSendThing.m_ClrDST = System.Drawing.Color.Red;
            this.txtSendThing.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSendThing.m_IntCanModifyTime = 6;
            this.txtSendThing.m_IntPartControlLength = 0;
            this.txtSendThing.m_IntPartControlStartIndex = 0;
            this.txtSendThing.m_StrUserID = "";
            this.txtSendThing.m_StrUserName = "";
            this.txtSendThing.Multiline = false;
            this.txtSendThing.Name = "txtSendThing";
            this.txtSendThing.Size = new System.Drawing.Size(108, 21);
            this.txtSendThing.TabIndex = 602;
            this.txtSendThing.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(582, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(98, 14);
            this.label29.TabIndex = 3030;
            this.label29.Text = "取自身体何处:";
            // 
            // txtFromBody
            // 
            this.txtFromBody.AccessibleDescription = "取自身体何处";
            this.txtFromBody.BackColor = System.Drawing.Color.White;
            this.txtFromBody.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFromBody.ForeColor = System.Drawing.Color.Black;
            this.txtFromBody.Location = new System.Drawing.Point(682, 3);
            this.txtFromBody.m_BlnPartControl = false;
            this.txtFromBody.m_BlnReadOnly = false;
            this.txtFromBody.m_BlnUnderLineDST = false;
            this.txtFromBody.m_ClrDST = System.Drawing.Color.Red;
            this.txtFromBody.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtFromBody.m_IntCanModifyTime = 6;
            this.txtFromBody.m_IntPartControlLength = 0;
            this.txtFromBody.m_IntPartControlStartIndex = 0;
            this.txtFromBody.m_StrUserID = "";
            this.txtFromBody.m_StrUserName = "";
            this.txtFromBody.Multiline = false;
            this.txtFromBody.Name = "txtFromBody";
            this.txtFromBody.Size = new System.Drawing.Size(108, 21);
            this.txtFromBody.TabIndex = 603;
            this.txtFromBody.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(515, 63);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 14);
            this.label30.TabIndex = 3032;
            this.label30.Text = "患病久暂:";
            // 
            // txtSickenPeriod
            // 
            this.txtSickenPeriod.AccessibleDescription = "患病久暂";
            this.txtSickenPeriod.BackColor = System.Drawing.Color.White;
            this.txtSickenPeriod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSickenPeriod.ForeColor = System.Drawing.Color.Black;
            this.txtSickenPeriod.Location = new System.Drawing.Point(584, 60);
            this.txtSickenPeriod.m_BlnPartControl = false;
            this.txtSickenPeriod.m_BlnReadOnly = false;
            this.txtSickenPeriod.m_BlnUnderLineDST = false;
            this.txtSickenPeriod.m_ClrDST = System.Drawing.Color.Red;
            this.txtSickenPeriod.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSickenPeriod.m_IntCanModifyTime = 6;
            this.txtSickenPeriod.m_IntPartControlLength = 0;
            this.txtSickenPeriod.m_IntPartControlStartIndex = 0;
            this.txtSickenPeriod.m_StrUserID = "";
            this.txtSickenPeriod.m_StrUserName = "";
            this.txtSickenPeriod.Multiline = false;
            this.txtSickenPeriod.Name = "txtSickenPeriod";
            this.txtSickenPeriod.Size = new System.Drawing.Size(108, 21);
            this.txtSickenPeriod.TabIndex = 604;
            this.txtSickenPeriod.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(229, 182);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 14);
            this.label31.TabIndex = 3034;
            this.label31.Text = "病房号:";
            this.label31.Visible = false;
            // 
            // lblSickRoom
            // 
            this.lblSickRoom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSickRoom.Location = new System.Drawing.Point(541, 127);
            this.lblSickRoom.Name = "lblSickRoom";
            this.lblSickRoom.Size = new System.Drawing.Size(28, 20);
            this.lblSickRoom.TabIndex = 3035;
            this.lblSickRoom.Visible = false;
            // 
            // lsvLike
            // 
            this.lsvLike.BackColor = System.Drawing.Color.White;
            this.lsvLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvLike.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeID,
            this.clmEmployeeName});
            this.lsvLike.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvLike.FullRowSelect = true;
            this.lsvLike.GridLines = true;
            this.lsvLike.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvLike.Location = new System.Drawing.Point(12, 256);
            this.lsvLike.Name = "lsvLike";
            this.lsvLike.Size = new System.Drawing.Size(150, 106);
            this.lsvLike.TabIndex = 30037;
            this.lsvLike.UseCompatibleStateImageBehavior = false;
            this.lsvLike.View = System.Windows.Forms.View.Details;
            this.lsvLike.Visible = false;
            this.lsvLike.DoubleClick += new System.EventHandler(this.lsvLike_DoubleClick);
            // 
            // clmEmployeeID
            // 
            this.clmEmployeeID.Width = 0;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 150;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(8, 32);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 14);
            this.label33.TabIndex = 30038;
            this.label33.Text = "组织图块: ";
            // 
            // grpMap
            // 
            this.grpMap.Controls.Add(this.pictureBox7);
            this.grpMap.Controls.Add(this.pictureBox6);
            this.grpMap.Controls.Add(this.pictureBox5);
            this.grpMap.Controls.Add(this.pictureBox4);
            this.grpMap.Controls.Add(this.pictureBox3);
            this.grpMap.Controls.Add(this.pictureBox2);
            this.grpMap.Controls.Add(this.pictureBox1);
            this.grpMap.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpMap.Location = new System.Drawing.Point(8, 48);
            this.grpMap.Name = "grpMap";
            this.grpMap.Size = new System.Drawing.Size(740, 108);
            this.grpMap.TabIndex = 30039;
            this.grpMap.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(548, 24);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(76, 76);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(459, 24);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(76, 76);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(370, 24);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(76, 76);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(281, 24);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(76, 76);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(192, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 76);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(103, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 76);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 76);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(213, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 14);
            this.label34.TabIndex = 30040;
            this.label34.Text = "医检列号:";
            // 
            // txtMedicalCheckNo
            // 
            this.txtMedicalCheckNo.AccessibleDescription = "医检列号";
            this.txtMedicalCheckNo.BackColor = System.Drawing.Color.White;
            this.txtMedicalCheckNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMedicalCheckNo.ForeColor = System.Drawing.Color.Black;
            this.txtMedicalCheckNo.Location = new System.Drawing.Point(282, 3);
            this.txtMedicalCheckNo.m_BlnPartControl = false;
            this.txtMedicalCheckNo.m_BlnReadOnly = false;
            this.txtMedicalCheckNo.m_BlnUnderLineDST = false;
            this.txtMedicalCheckNo.m_ClrDST = System.Drawing.Color.Red;
            this.txtMedicalCheckNo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtMedicalCheckNo.m_IntCanModifyTime = 6;
            this.txtMedicalCheckNo.m_IntPartControlLength = 0;
            this.txtMedicalCheckNo.m_IntPartControlStartIndex = 0;
            this.txtMedicalCheckNo.m_StrUserID = "";
            this.txtMedicalCheckNo.m_StrUserName = "";
            this.txtMedicalCheckNo.Multiline = false;
            this.txtMedicalCheckNo.Name = "txtMedicalCheckNo";
            this.txtMedicalCheckNo.Size = new System.Drawing.Size(108, 21);
            this.txtMedicalCheckNo.TabIndex = 605;
            this.txtMedicalCheckNo.Text = "";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(576, 372);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(56, 24);
            this.m_cmdEmployeeSign.TabIndex = 10000095;
            this.m_cmdEmployeeSign.Tag = "";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // m_cmdDoctor
            // 
            this.m_cmdDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctor.DefaultScheme = true;
            this.m_cmdDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctor.Hint = "";
            this.m_cmdDoctor.Location = new System.Drawing.Point(568, 432);
            this.m_cmdDoctor.Name = "m_cmdDoctor";
            this.m_cmdDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctor.Size = new System.Drawing.Size(80, 24);
            this.m_cmdDoctor.TabIndex = 616;
            this.m_cmdDoctor.Tag = "1";
            this.m_cmdDoctor.Text = "医师签名:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_txtDoctor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtHistory);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBiologyChemistry);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtClinicalInfo);
            this.panel1.Controls.Add(this.m_cmdDoctor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtXRay);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtBloodSerum);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtOther);
            this.panel1.Controls.Add(this.txtOperationInfo);
            this.panel1.Controls.Add(this.txtClinicalDignose);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCheckAim);
            this.panel1.Controls.Add(this.txtBlood);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 494);
            this.panel1.TabIndex = 10000099;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.dtgMaker);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.dtpSendDate);
            this.panel2.Controls.Add(this.dtpReceiveDate);
            this.panel2.Controls.Add(this.txtColorAndSlice);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtEyeCheck);
            this.panel2.Controls.Add(this.grpMap);
            this.panel2.Controls.Add(this.grpOrg);
            this.panel2.Controls.Add(this.lsvLike);
            this.panel2.Controls.Add(this.dtgChecker);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 494);
            this.panel2.TabIndex = 30040;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_txtSign);
            this.panel3.Controls.Add(this.lsvLike1);
            this.panel3.Controls.Add(this.txtPathologyDignose);
            this.panel3.Controls.Add(this.dtgReporter);
            this.panel3.Controls.Add(this.m_cmdEmployeeSign);
            this.panel3.Controls.Add(this.dtpReportDate);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 494);
            this.panel3.TabIndex = 10000096;
            // 
            // lsvLike1
            // 
            this.lsvLike1.BackColor = System.Drawing.Color.White;
            this.lsvLike1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvLike1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvLike1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvLike1.FullRowSelect = true;
            this.lsvLike1.GridLines = true;
            this.lsvLike1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvLike1.Location = new System.Drawing.Point(16, 276);
            this.lsvLike1.Name = "lsvLike1";
            this.lsvLike1.Size = new System.Drawing.Size(150, 106);
            this.lsvLike1.TabIndex = 10000096;
            this.lsvLike1.UseCompatibleStateImageBehavior = false;
            this.lsvLike1.View = System.Windows.Forms.View.Details;
            this.lsvLike1.Visible = false;
            this.lsvLike1.DoubleClick += new System.EventHandler(this.lsvLike1_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 150;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(5, 127);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 2;
            this.tabControl2.SelectedTab = this.tabPage6;
            this.tabControl2.Size = new System.Drawing.Size(798, 520);
            this.tabControl2.TabIndex = 10000100;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4,
            this.tabPage5,
            this.tabPage6});
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.ImageIndex = 2;
            this.tabPage6.ImageList = this.imageList1;
            this.tabPage6.Location = new System.Drawing.Point(0, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(798, 494);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Title = "病理诊断";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(798, 494);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "病历";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel2);
            this.tabPage5.ImageIndex = 1;
            this.tabPage5.ImageList = this.imageList1;
            this.tabPage5.Location = new System.Drawing.Point(0, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(798, 494);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Title = "组织";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtMedicalCheckNo);
            this.panel4.Controls.Add(this.txtLastCheckNumber);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.label34);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Controls.Add(this.txtSendThing);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.txtFromBody);
            this.panel4.Location = new System.Drawing.Point(5, 95);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 29);
            this.panel4.TabIndex = 10000101;
            // 
            // m_txtDoctor
            // 
            this.m_txtDoctor.Location = new System.Drawing.Point(654, 432);
            this.m_txtDoctor.Name = "m_txtDoctor";
            this.m_txtDoctor.ReadOnly = true;
            this.m_txtDoctor.Size = new System.Drawing.Size(88, 24);
            this.m_txtDoctor.TabIndex = 1321;
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(638, 372);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(100, 24);
            this.m_txtSign.TabIndex = 10000097;
            // 
            // frmPathologyOrgCheckOrder
            // 
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(815, 673);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblSickRoom);
            this.Controls.Add(this.lblDept_Local);
            this.Controls.Add(this.lblMarrige);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.lblNativePlace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPathologyOrgCheckOrder";
            this.Text = "病理活体组织送验单";
            this.Load += new System.EventHandler(this.frmPathologyOrgCheckOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblMarrige, 0);
            this.Controls.SetChildIndex(this.lblDept_Local, 0);
            this.Controls.SetChildIndex(this.lblSickRoom, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label31, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChecker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaker)).EndInit();
            this.grpOrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporter)).EndInit();
            this.grpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Control Event
		private void frmPathologyOrgCheckOrder_Load(object sender, System.EventArgs e)
		{
			this.m_lsvInPatientID.Visible =false;
			TreeNode trnNode = new TreeNode("记录日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

//			lblDoctor.Text = MDIParent.strOperatorName;

			trvTime.Focus();

			#region 日期格式
			this.dtpSendDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpReceiveDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpSendDate.m_mthResetSize();
			this.dtpReceiveDate.m_mthResetSize();
			#endregion
		}

		private void lsvLike_DoubleClick(object sender, System.EventArgs e)
		{
			if(lsvLike.SelectedItems.Count>0)
			{
				ListViewItem lsvItem =lsvLike.SelectedItems[0];
					
				//				if(!m_blnCheckEmployeeSign(lsvItem.SubItems[0].Text,lsvItem.SubItems[1].Text))
				//					return;
						
				object[] objRow = new object[2];
				if(m_strSenderName == "Checker")
				{
					//					if(m_arlChecker.Contains(lsvItem.SubItems[0].Text))
					//					{
					//						clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
					//						return ;
					//					}

					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					dtbChecker.Rows[m_intRowNumber][0] = objRow[0];   
					dtbChecker.Rows[m_intRowNumber][1] = objRow[1]; 

					//					m_arlChecker.Add(lsvItem.SubItems[0].Text);

					dtgChecker.Focus();
				}
				else if(m_strSenderName == "Maker")
				{
					//					if(m_arlMaker.Contains(lsvItem.SubItems[0].Text))
					//					{
					//						clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
					//						return ;
					//					}

					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					dtbMaker.Rows[m_intRowNumber][1] = objRow[1];   
					dtbMaker.Rows[m_intRowNumber][0] = objRow[0]; 

					//					m_arlMaker.Add(lsvItem.SubItems[0].Text);

					dtgMaker.Focus();
				}
				else if(m_strSenderName == "Reporter")
				{
					//					if(m_arlReporter.Contains(lsvItem.SubItems[0].Text))
					//					{
					//						clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
					//						return ;
					//					}

					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					dtbReporter.Rows[m_intRowNumber][1] = objRow[1];   
					dtbReporter.Rows[m_intRowNumber][0] = objRow[0]; 

					//					m_arlReporter.Add(lsvItem.SubItems[0].Text);

					dtgReporter.Focus();
				}

				lsvLike.Visible = false;
			}
		}

		private void lsvLike1_DoubleClick(object sender, System.EventArgs e)
		{
			if(lsvLike1.SelectedItems.Count>0)
			{
				ListViewItem lsvItem =lsvLike1.SelectedItems[0];
					
				//				if(!m_blnCheckEmployeeSign(lsvItem.SubItems[0].Text,lsvItem.SubItems[1].Text))
				//					return;
						
				object[] objRow = new object[2];
				
				
				if(m_strSenderName == "Reporter")
				{
					//					if(m_arlReporter.Contains(lsvItem.SubItems[0].Text))
					//					{
					//						clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
					//						return ;
					//					}

					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					dtbReporter.Rows[m_intRowNumber][1] = objRow[1];   
					dtbReporter.Rows[m_intRowNumber][0] = objRow[0]; 

					//					m_arlReporter.Add(lsvItem.SubItems[0].Text);

					dtgReporter.Focus();
				}

				lsvLike1.Visible = false;
			}

		}

		private void dtgChecker_CurrentCellChanged(object sender, System.EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			
			m_strSenderName = "Checker";
			lsvLike.Items.Clear();
		}

		private void dtgMaker_CurrentCellChanged(object sender, System.EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			
			m_strSenderName = "Maker";
			lsvLike.Items.Clear();
		}

		private void dtgReporter_CurrentCellChanged(object sender, System.EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
						
			m_strSenderName = "Reporter";
			lsvLike1.Items.Clear();
		}
	
		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName")
						ctlText.Enabled=false;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name != "dtpReportDate") 
						((ctlTimePicker)ctlText).Enabled=false;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = true;
					if(typeName == "DataGrid") ((DataGrid)ctlText).ReadOnly=true;
					
					
				}
				blnCanDelete=false;
			}
			else
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
					
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID")
						ctlText.Enabled=true;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name != "dtpReportDate") 
						((ctlTimePicker)ctlText).Enabled=true;
					if(typeName == "ctlRichTextBox") ((ctlRichTextBox)ctlText).m_BlnReadOnly=false;
					if(typeName == "DataGrid") ((DataGrid)ctlText).ReadOnly=false;
										
				}
				blnCanDelete=true;

			}
		}

		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpRecord();

			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			{

				m_objPathologyOrgCheckOrder=null;
				
				this.dtpSendDate.Enabled=true;
				m_mthReadOnly(false);

				if(m_strInPatientID != null && m_strInPatientDate != null)
				{
					m_mthSetDefaultValue(new clsPatient(m_strInPatientID));
				}
				
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);

			}
			else
			{
				this.dtpSendDate.Enabled=false;
				m_strCreateDate = ((DateTime)trvTime.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss");
				
				m_objPathologyOrgCheckOrder = m_objDomain.m_objGetPathologyOrgCheckOrder(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				m_objOperator = m_objDomain.m_objGetOperatorIDArr(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				if(m_objPathologyOrgCheckOrder!=null)
				{
					m_mthReadOnly(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objPathologyOrgCheckOrder.m_strCreateUserID.Trim());
				}
				m_mthDisplay();
				m_mthDisplayOperator();

				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}

			m_mthAddFormStatusForClosingSave();
		}
		#endregion

		#region Tools
		private void m_mthChecker_GotFocus(object sender, EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Checker";
			lsvLike.Items.Clear();
		}

		private void m_mthMaker_GotFocus(object sender, EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Maker";
			lsvLike.Items.Clear();
		}

		private void m_mthReporter_GotFocus(object sender, EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Reporter";
			lsvLike1.Items.Clear();
		}

		/// <summary>
		/// 把模糊查询的结果放在lsvLike中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_objAddListViewItemArr(object sender,EventArgs e)
		{
			lsvLike.BringToFront();

			clsOperationEqipmentQtyDomain m_objOEQDomain = new clsOperationEqipmentQtyDomain();
			try
			{
				lsvLike.Items.Clear();
				bool blnSuccess=false;
			
				ListViewItem[] lsvItemArr=null;

				if(m_strSenderName == "Checker")
				{
					lsvItemArr = null;
					if(m_objGridListView0==null||m_objGridListView0.strGetCurrentText()==null||m_objGridListView0.strGetCurrentText()=="")return;				
					lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_objGridListView0.strGetCurrentText(),ref blnSuccess);					

				}

				if(m_strSenderName == "Maker")
				{
					lsvItemArr = null;
					if(m_objGridListView1==null||m_objGridListView1.strGetCurrentText()==null||m_objGridListView1.strGetCurrentText()=="")return;				
					lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_objGridListView1.strGetCurrentText(),ref blnSuccess);					

				}

				if(m_strSenderName == "Reporter")
				{
					lsvItemArr = null;
					if(m_objGridListView2==null||m_objGridListView2.strGetCurrentText()==null||m_objGridListView2.strGetCurrentText()=="")return;				
					lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_objGridListView2.strGetCurrentText(),ref blnSuccess);					
					if(blnSuccess==false)
						return;
					for (int i=0; i<lsvItemArr.Length; i++)
					{
						lsvLike1.Items.AddRange(new ListViewItem[]{lsvItemArr[i]});
					}	

					m_mthChangeListViewLastColumnWidth(lsvLike1);
					return;
				
				}

				if(blnSuccess==false)
					return;
				for (int i=0; i<lsvItemArr.Length; i++)
				{
					lsvLike.Items.AddRange(new ListViewItem[]{lsvItemArr[i]});
				}	

				m_mthChangeListViewLastColumnWidth(lsvLike);
			}
			catch{}
		}

		/// <summary>
		/// tag 0 根 
		/// </summary>
		/// <param name="p_strPatientID"></param>
		/// <param name="p_strPatientDate"></param>
		private void m_mthLoadAllRecordTimeOfAPatient(string p_strPatientID,string p_strPatientDate)
		{
			m_mthClearUpRecord();

			if(p_strPatientID ==null || p_strPatientID =="") 
				return ;


			this.trvTime.Nodes[0].Nodes.Clear();

			DateTime [] m_dtmArr= m_objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strPatientID ,p_strPatientDate);

			if(m_dtmArr==null) 
			{
				m_mthSetDefaultValue(m_objSelectedPatient);
				return ;
			}

			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}

		private void m_mthClearUpRecord()
		{
			//报告者不需默认值
			this.m_txtSign.Text="";
			
			m_mthClear_Recursive(this.tabControl2,null);
			
				//清除RichTextBox 的内容
			foreach(Control ctlControl in this.Controls )
			{
				string typeName = ctlControl.GetType().Name;
				if(typeName == "ctlRichTextBox" )
				{
					((ctlRichTextBox)ctlControl).m_mthClearText();
				}

				if(typeName == "GroupBox")
				{
					foreach(Control ctlSubControl in ctlControl.Controls)
					{
						string strSubTypeName = ctlSubControl.GetType().Name;
						if(strSubTypeName == "RadioButton")
						{
							((RadioButton)ctlSubControl).Checked = false;
						}
					}
				}
			}
			
			this.dtpSendDate.Enabled =true;
			m_mthReadOnly(false);
			dtgChecker.CurrentRowIndex = 0;
			dtbChecker.Rows.Clear();

			dtgMaker.CurrentRowIndex = 0;
			dtbMaker.Rows.Clear();

			dtgReporter.CurrentRowIndex = 0;
			dtbReporter.Rows.Clear();

			dtpReceiveDate.Value = DateTime.Now;
			dtpSendDate.Value = DateTime.Now;
			dtpReportDate.Value = DateTime.Now;

			//			m_arlChecker.Clear();
			//			m_arlMaker.Clear();
			//			m_arlReporter.Clear();
			////
			m_strCreateDate = "";
		}
		#endregion

		#region Public Function
		public void Copy()
		{
			m_lngCopy();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Cut()
		{
			m_lngCut();
		}

		public void Delete()
		{
			m_lngDelete();
		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Print()
		{
			this.m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			this.m_lngSave();
		}

		public void Undo()
		{
		
		}
		#endregion

		#region Override
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return m_blnCanSearch;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return (m_strCreateDate == ""|| m_strCreateDate == null);
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
            //m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID ,m_strInPatientDate);			
		}

		protected override void m_mthSetPatientBaseInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_blnCanSearch = false;

			m_objSelectedPatient = p_objSelectedPatient;

			m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
            m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

			txtInPatientID.Text = p_objSelectedPatient.m_StrInPatientID;
			txtInPatientID.Tag=m_strInPatientDate;
			m_txtPatientName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName.Trim();
			lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
			m_blnCanAreaSelectIndexChangeEventTakePlace = false;
			m_cboArea.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
			m_blnCanAreaSelectIndexChangeEventTakePlace = true;
			lblDept_Local .Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName;
			m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
			lblSickRoom.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomName;

			lblNativePlace.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNativePlace;
			lblMarrige.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
			lblOccupation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;

//			m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
//			m_cboDept.SelectedIndex=0;
//			clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
//			m_cboArea.AddItem(objInPatientArea);
//			m_cboArea.SelectedIndex=0;
			//使用新表 modified by tfzhang at 2005年10月17日 16:02:29
			//清空
			m_cboDept.ClearItem();
			
			//获取科室
			string str1=p_objSelectedPatient.m_strDeptNewID;
			string str2;
			clsHospitalManagerDomain objDomain =new clsHospitalManagerDomain();
			clsEmrDept_VO objDeptNew;
			objDomain.m_lngGetSpecialDeptInfo(str1,out objDeptNew);
			str1=objDeptNew.m_strSHORTNO_CHR.Trim();
			str2=objDeptNew.m_strDEPTNAME_VCHR.Trim();
			string str11=objDeptNew.m_strDEPTID_CHR.Trim();
			clsDepartment objDeptTemp= new clsDepartment(str1,str2);
			//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
			objDeptTemp.m_strDeptNewID=str11;
			m_cboDept.AddItem(objDeptTemp);
			m_cboDept.SelectedIndex=0;

			//获取病区
			m_cboArea.ClearItem();
			string str3=p_objSelectedPatient.m_strAreaNewID;
			if (str3.Trim().Length!=0)//病区不为空
			{
				string str4;
				clsEmrDept_VO objAreNew;
				objDomain.m_lngGetSpecialAreaInfo(str3,out objAreNew);
				str3=objAreNew.m_strSHORTNO_CHR;
				str4=objAreNew.m_strDEPTNAME_VCHR;
				clsInPatientArea objInPatientArea =new clsInPatientArea(str3,str4,str3);
				//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
				objInPatientArea.m_strAreaNewID=objAreNew.m_strDEPTID_CHR;
				m_cboArea.AddItem(objInPatientArea);
				m_cboArea.SelectedIndex=0;
			}
							
			m_txtBedNO.Text =p_objSelectedPatient.m_strBedCode;			
			m_blnCanSearch = true;
		}

		protected override void m_mthClearPatientBaseInfo()
		{
			base.m_mthClearPatientBaseInfo();			
			m_strInPatientID = "";
			m_strInPatientDate = "";
					
			this.lblSickRoom.Text = "";
			this.lblMarrige.Text = "";
			this.lblOccupation.Text = "";
			this.lblDept_Local .Text = "";
//			this.lblDoctor.Text = MDIParent.strOperatorName;
			this.lblNativePlace.Text="";
            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
		}

		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox();
		}

		protected override long m_lngSubModify()
		{
			return m_lngSaveWithMessageBox();
		}

		protected override long m_lngSubPrint()
		{
			//			if(m_strInPatientID == null || m_strInPatientID == "")
			//				return 0;
			//
			//			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			//			{
			//				return 0;
			//			}

			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath + "rptPathologyOrgCheckOrder.rpt");
			}

			AddNewDataFordtsPathologyOrgCheckOrderDataSet(m_dtsRept);

			if(m_blnDirectPrint)
			{				
				m_rpdOrderRept.PrintToPrinter(1,true,1,1);
				if(clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint,MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					m_rpdOrderRept.PrintToPrinter(1,true,2,2);
				}
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
			if(m_objPathologyOrgCheckOrder==null || m_objSelectedPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objPathologyOrgCheckOrder.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objPathologyOrgCheckOrder.m_strInPatientID,m_objPathologyOrgCheckOrder.m_strInPatientDate,m_objPathologyOrgCheckOrder.m_strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objPathologyOrgCheckOrder.m_strCreateDate)
					{
						trnNode.Remove();
						
						break;
					}
				}
				this.trvTime.SelectedNode=this.trvTime.Nodes[0];
				m_mthClearUpRecord();
			}
			return lngRes ;
		}
		
		#endregion

		#region Save
		private long m_lngSaveWithMessageBox()
		{
			if(m_strCreateDate!="")
			{
				//				if(!m_bolShowIfModify()) return -1;
				if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objPathologyOrgCheckOrder.m_strCreateUserID.Trim())
				{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
					clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
					return -1;
				}
			}

			long lngRes=m_lngSaveWithoutMessageBox();
            if (true)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功");
            }
			else if(lngRes==-11)
			{
				clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");				
			}
			else if(lngRes==-21)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
			}
			else if(lngRes==-31)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，本记录已被他人修改，请重新读取一次！");
			}
			return lngRes;
		}

		private long m_lngSaveWithoutMessageBox()
		{
			if(m_strInPatientID == null || m_strInPatientID == "")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，请输入病人住院编号！");
				return 0;
			}

			string strCurrentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


			//dick 2003-3-27 
			DataTable[] dtbArr=new DataTable[3];
			dtbArr[0]=dtbChecker;
			dtbArr[1]=dtbMaker ;
			dtbArr[2]=dtbReporter ;
			if(m_blnCheckDuplicate(dtbArr))
			{
				clsPublicFunction.ShowInformationMessageBox("请检查输入的员工编号，人员不能重复！");
				return 0;
			}
			
			//从表 -- checker,maker,reporter
			int intRightCount=m_intGetRightOperator(dtbArr);
			clsPathologyOrgCheckOperatorID[] objOperatorArr=null;
			if(intRightCount>=0)
			{
				//				intRightCount=intRightCount==1? 0:intRightCount ;
				objOperatorArr = new clsPathologyOrgCheckOperatorID[intRightCount];
				int k=0;
				for(int i = 0; i < dtbChecker.Rows.Count; i++)
				{
					clsEmployee objEmployee=new clsEmployee(dtbChecker.Rows[i][0].ToString());
					if(objEmployee !=null && objEmployee.m_StrLastName !=null)
						if(objEmployee.m_StrLastName.Trim()==dtbChecker.Rows[i][1].ToString().Trim())
						{
							objOperatorArr[k] = new clsPathologyOrgCheckOperatorID();

							objOperatorArr[k].m_strOperatorID = dtbChecker.Rows[i][0].ToString();
							objOperatorArr[k].m_strOperatorFlag = "0";
 
							objOperatorArr[k].m_strInPatientID = m_strInPatientID;
							objOperatorArr[k].m_strInPatientDate = m_strInPatientDate;
							objOperatorArr[k].m_strCreateDate = (m_strCreateDate == "") ? dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
							objOperatorArr[k].m_strModifyDate = strCurrentDate;
							k++;
						}
				}

				for(int i = 0; i < dtbMaker.Rows.Count; i++)
				{
					clsEmployee objEmployee=new clsEmployee(dtbMaker.Rows[i][0].ToString());
					if(objEmployee !=null && objEmployee.m_StrLastName !=null)
						if(objEmployee.m_StrLastName.Trim()==dtbMaker.Rows[i][1].ToString().Trim())
						{
							objOperatorArr[k] = new clsPathologyOrgCheckOperatorID();

							objOperatorArr[k].m_strOperatorID = dtbMaker.Rows[i][0].ToString();
							objOperatorArr[k].m_strOperatorFlag = "1";

							objOperatorArr[k].m_strInPatientID = m_strInPatientID;
							objOperatorArr[k].m_strInPatientDate = m_strInPatientDate;
							objOperatorArr[k].m_strCreateDate = (m_strCreateDate == "") ? dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
							objOperatorArr[k].m_strModifyDate = strCurrentDate;
							k++;
						
						}
				
				}

				for(int i = 0; i < dtbReporter.Rows.Count; i++)
				{
					clsEmployee objEmployee=new clsEmployee(dtbReporter.Rows[i][0].ToString());
					if(objEmployee !=null && objEmployee.m_StrLastName !=null)
						if(objEmployee.m_StrLastName.Trim()==dtbReporter.Rows[i][1].ToString())
						{

							objOperatorArr[k] = new clsPathologyOrgCheckOperatorID();

							objOperatorArr[k].m_strOperatorID = dtbReporter.Rows[i][0].ToString();
							objOperatorArr[k].m_strOperatorFlag = "2";

							objOperatorArr[k].m_strInPatientID = m_strInPatientID;
							objOperatorArr[k].m_strInPatientDate = m_strInPatientDate;
							objOperatorArr[k].m_strCreateDate = (m_strCreateDate == "") ? dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
							objOperatorArr[k].m_strModifyDate = strCurrentDate;
							k++;
						}
				}
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("请检查输入的员工，人员不能为空或输入有误！");
				return 0;

			}


			//主表
			clsPathologyOrgCheckOrderInfo objPathologyOrgCheckOrder = new clsPathologyOrgCheckOrderInfo();

			objPathologyOrgCheckOrder.m_strMedicalCheckNo = txtMedicalCheckNo.Text;
			objPathologyOrgCheckOrder.m_strHospitalName = txtHospitalName.Text;
			objPathologyOrgCheckOrder.m_strLastCheckNumber =txtLastCheckNumber.Text;
			objPathologyOrgCheckOrder.m_strSendThings = txtSendThing.Text;
			objPathologyOrgCheckOrder.m_strFromBody = txtFromBody.Text;
			objPathologyOrgCheckOrder.m_strSickenPeriod = txtSickenPeriod.Text;
			objPathologyOrgCheckOrder.m_strHistory = txtHistory.Text;
			objPathologyOrgCheckOrder.m_strClinicalInfo = txtClinicalInfo.Text;
			objPathologyOrgCheckOrder.m_strOperationInfo = txtOperationInfo.Text;
			objPathologyOrgCheckOrder.m_strCheckAim = txtCheckAim.Text;
			objPathologyOrgCheckOrder.m_strBiologyChemistry = txtBiologyChemistry.Text;
			objPathologyOrgCheckOrder.m_strBlood = txtBlood.Text;
			objPathologyOrgCheckOrder.m_strXRay = txtXRay.Text;
			objPathologyOrgCheckOrder.m_strBloodSerum = txtBloodSerum.Text;
			objPathologyOrgCheckOrder.m_strOther = txtOther.Text;
			objPathologyOrgCheckOrder.m_strClinicalDignose = txtClinicalDignose.Text;
			objPathologyOrgCheckOrder.m_strSendDate = dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objPathologyOrgCheckOrder.m_strReceiveDate = dtpReceiveDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objPathologyOrgCheckOrder.m_strColorAndSlice = txtColorAndSlice.Text;
			objPathologyOrgCheckOrder.m_strEyeCheck = txtEyeCheck.Text;
			objPathologyOrgCheckOrder.m_strOrganiseBuryFull = (rdbOrganiseBuryFull.Checked) ? "1" : "0";
			objPathologyOrgCheckOrder.m_strOrganiseStay = (rdbOrganiseStay.Checked) ? "1" : "0";
			objPathologyOrgCheckOrder.m_strEyeSample = (rdbEyeSample.Checked) ? "1" : "0";
			objPathologyOrgCheckOrder.m_strPathologyDignose = txtPathologyDignose.Text;
			objPathologyOrgCheckOrder.m_strReportDate = dtpReportDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			

			objPathologyOrgCheckOrder.m_strInPatientID = m_strInPatientID;
			objPathologyOrgCheckOrder.m_strInPatientDate = m_strInPatientDate;

			objPathologyOrgCheckOrder.m_strCreateDate = (m_strCreateDate == "") ? dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
			objPathologyOrgCheckOrder.m_strModifyDate = strCurrentDate;
			objPathologyOrgCheckOrder.m_strStatus = "0";
			objPathologyOrgCheckOrder.m_strCreateUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
			objPathologyOrgCheckOrder.m_strIfConfirm = "1";
			//添加签名 tfzhang 2005-7-8 17:25
            if (m_txtSign.Tag is clsEmrEmployeeBase_VO)
			{
                objPathologyOrgCheckOrder.m_strDoctorID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
			}
			objPathologyOrgCheckOrder.m_strDoctorName=m_txtSign.Text.Trim();

			

			//			bool blnNewRecord = false;
			//			if(m_strCreateDate == "")
			//			{
			//				blnNewRecord = true;
			//			}
			//			else
			//			{
			//				blnNewRecord = false;
			//			}

			long lngRes = m_objDomain.m_lngSave(objPathologyOrgCheckOrder,objOperatorArr);
			if(lngRes<=0)
			{
				return -21;
			}
			else
			{
				if(m_strCreateDate == "")
				{
					int intNodeIndex = -1;
					for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
					{
						if(DateTime.Parse(dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss")) == (DateTime)(trvTime.Nodes[0].Nodes[i].Tag))
						{
							intNodeIndex = i;
							break;
						}
					}

					if(intNodeIndex == -1)
					{
						m_mthAddNodeToTrv(dtpSendDate.Value);
						//						TreeNode m_trnNewNode = new TreeNode(dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_trnNewNode.Tag = DateTime.Parse(dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_strCreateDate = dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						//						trvTime.Nodes[0].Nodes.Add(m_trnNewNode);
						//						trvTime.SelectedNode = trvTime.Nodes[0];
						//						trvTime.SelectedNode = m_trnNewNode;
					}
					else
					{
						m_strCreateDate = dtpSendDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						trvTime.SelectedNode = trvTime.Nodes[0].Nodes[intNodeIndex];
					}
					
				}
				else
				{
					TreeNode m_trnTempNode = trvTime.SelectedNode;
					trvTime.SelectedNode = trvTime.Nodes[0];
					trvTime.SelectedNode = m_trnTempNode;
				}
			}
			return 1;
		}
		
		private bool m_blnCheckDuplicate(DataTable[] dtbSign)
		{ /*判断员工是否重复 2003-3-27*/ 
			if(dtbSign==null) return false;
			ArrayList arlSign=new ArrayList();
			for(int j=0;j<dtbSign.Length-1;j++)
			{
				for(int i = 0; i < dtbSign[j].Rows.Count; i++)
				{
					if(arlSign.Contains(dtbSign[j].Rows[i].ItemArray[1].ToString()))
						return true;
					else if(dtbSign[j].Rows[i].ItemArray[1].ToString()!="")
					{
						arlSign.Add(dtbSign[j].Rows[i].ItemArray[1].ToString());
					}
				}
			}
			return false;

		}
		private int m_intGetRightOperator(DataTable[] dtbSign)
		{/*判断员工是否为空*/
			if(dtbSign==null) return 0;
			int Count=0;
			for(int j=0;j<dtbSign.Length;j++)
			{
				for(int i = 0; i < dtbSign[j].Rows.Count; i++)
				{
					clsEmployee objEmployee=new clsEmployee(dtbSign[j].Rows[i][0].ToString());
					if(objEmployee !=null && objEmployee.m_StrLastName !=null)
						if(objEmployee.m_StrLastName.Trim()==dtbSign[j].Rows[i][1].ToString().Trim())
							Count++;
					
				}
			}
			return Count;
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
				
		#endregion

		#region Display
		private void m_mthDisplay()
		{
			txtMedicalCheckNo.Text = m_objPathologyOrgCheckOrder.m_strMedicalCheckNo;
			txtHospitalName.Text  = m_objPathologyOrgCheckOrder.m_strHospitalName;
			txtLastCheckNumber.Text = m_objPathologyOrgCheckOrder.m_strLastCheckNumber;
			txtSendThing.Text = m_objPathologyOrgCheckOrder.m_strSendThings;
			txtFromBody.Text = m_objPathologyOrgCheckOrder.m_strFromBody;
			txtSickenPeriod.Text = m_objPathologyOrgCheckOrder.m_strSickenPeriod;
			txtHistory.Text = m_objPathologyOrgCheckOrder.m_strHistory;
			txtClinicalInfo.Text = m_objPathologyOrgCheckOrder.m_strClinicalInfo;
			txtOperationInfo.Text = m_objPathologyOrgCheckOrder.m_strOperationInfo;
			txtBiologyChemistry.Text = m_objPathologyOrgCheckOrder.m_strBiologyChemistry;
			txtBlood.Text = m_objPathologyOrgCheckOrder.m_strBlood;
			txtXRay.Text = m_objPathologyOrgCheckOrder.m_strXRay;
			txtBloodSerum.Text = m_objPathologyOrgCheckOrder.m_strBloodSerum;
			txtOther.Text = m_objPathologyOrgCheckOrder.m_strOther;
			txtClinicalDignose.Text = m_objPathologyOrgCheckOrder.m_strClinicalDignose;

			dtpSendDate.Value = DateTime.Parse(m_objPathologyOrgCheckOrder.m_strSendDate);
			dtpReceiveDate.Value = DateTime.Parse(m_objPathologyOrgCheckOrder.m_strReceiveDate);

			txtColorAndSlice.Text = m_objPathologyOrgCheckOrder.m_strColorAndSlice;
			txtEyeCheck.Text = m_objPathologyOrgCheckOrder.m_strEyeCheck;
			txtPathologyDignose.Text = m_objPathologyOrgCheckOrder.m_strPathologyDignose;

            //clsEmployee objEmployee = new clsEmployee(m_objPathologyOrgCheckOrder.m_strCreateUserID);
            //if(objEmployee !=null && objEmployee.m_StrLastName !=null)
            //    m_txtDoctor.Text = objEmployee.m_StrLastName.Trim();

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objPathologyOrgCheckOrder.m_strCreateUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtDoctor.Tag = objEmpVO;
            }

//			rdbOrganiseBuryFull.Checked = bool.Parse(m_objPathologyOrgCheckOrder.m_strOrganiseBuryFull);
//			rdbOrganiseStay.Checked = bool.Parse(m_objPathologyOrgCheckOrder.m_strOrganiseStay);;
//			rdbEyeSample.Checked = bool.Parse(m_objPathologyOrgCheckOrder.m_strEyeSample);
			rdbOrganiseBuryFull.Checked = (m_objPathologyOrgCheckOrder.m_strOrganiseBuryFull == "1"?true:false);
			rdbOrganiseStay.Checked = (m_objPathologyOrgCheckOrder.m_strOrganiseStay == "1"?true:false);;
			rdbEyeSample.Checked = (m_objPathologyOrgCheckOrder.m_strEyeSample == "1"?true:false);

			txtCheckAim.Text = m_objPathologyOrgCheckOrder.m_strCheckAim;
			//添加签名 tfzhang 2005-7-8 17:25
            //m_txtSign.Text=m_objPathologyOrgCheckOrder.m_strDoctorName;

            clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objPathologyOrgCheckOrder.m_strDoctorID, out objEmpVO1);
            if (objEmpVO1 != null)
            {
                m_txtSign.Text = objEmpVO1.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO1;
            }
		}

		private void m_mthDisplayOperator()
		{
			if(m_objOperator == null || m_objOperator.Length == 0)
				return;

			ArrayList arlChecker = new ArrayList();
			ArrayList arlMaker = new ArrayList();
			ArrayList arlReporter = new ArrayList();

			for(int i = 0; i < m_objOperator.Length; i++)
			{
				switch(m_objOperator[i].m_strOperatorFlag)
				{
					case "0":
						arlChecker.Add(m_objOperator[i]);
						break;

					case "1":
						arlMaker.Add(m_objOperator[i]);
						break;

					case "2":
						arlReporter.Add(m_objOperator[i]);
						break;
				}//end switch
			}//end for

			//display checker
			for(int i = 0; i < arlChecker.Count; i++)
			{
				Object [] objRows=new object[2];
				for(int j = 0;j < 2;j++)
				{
					objRows[j]="";

				}
				dtbChecker.Rows.Add(objRows);
			}

            for (int i = 0; i < arlChecker.Count; i++)
            {
                clsEmployee objEmployee = new clsEmployee(((clsPathologyOrgCheckOperatorID)arlChecker[i]).m_strOperatorID);
                if (objEmployee != null && objEmployee.m_StrLastName != null)
                    dtbChecker.Rows[i][1] = objEmployee.m_StrLastName.Trim();

                else
                    dtbChecker.Rows[i][1] = "";
                dtbChecker.Rows[i][0] = ((clsPathologyOrgCheckOperatorID)arlChecker[i]).m_strOperatorID;

                //				m_arlChecker.Add(((clsPathologyOrgCheckOperatorID)arlChecker[i]).m_strOperatorID);
            }

            //display maker
            for (int i = 0; i < arlMaker.Count; i++)
            {
                Object[] objRows = new object[2];
                for (int j = 0; j < 2; j++)
                {
                    objRows[j] = "";

                }
                dtbMaker.Rows.Add(objRows);
            }

            for (int i = 0; i < arlMaker.Count; i++)
            {
                clsEmployee objEmployee = new clsEmployee(((clsPathologyOrgCheckOperatorID)arlMaker[i]).m_strOperatorID);
                if (objEmployee != null && objEmployee.m_StrLastName != null)
                    dtbMaker.Rows[i][1] = objEmployee.m_StrLastName.Trim();

                else
                    dtbMaker.Rows[i][1] = "";
                dtbMaker.Rows[i][0] = ((clsPathologyOrgCheckOperatorID)arlMaker[i]).m_strOperatorID;

                //				m_arlMaker.Add(((clsPathologyOrgCheckOperatorID)arlMaker[i]).m_strOperatorID);
            }

            //display reporter
            for (int i = 0; i < arlReporter.Count; i++)
            {
                Object[] objRows = new object[2];
                for (int j = 0; j < 2; j++)
                {
                    objRows[j] = "";

                }
                dtbReporter.Rows.Add(objRows);
            }

            for (int i = 0; i < arlReporter.Count; i++)
            {
                clsEmployee objEmployee = new clsEmployee(((clsPathologyOrgCheckOperatorID)arlReporter[i]).m_strOperatorID);
                if (objEmployee != null && objEmployee.m_StrLastName != null)
                    dtbReporter.Rows[i][1] = objEmployee.m_StrLastName.Trim();

                else dtbReporter.Rows[i][1] = "";
				dtbReporter.Rows[i][0] = ((clsPathologyOrgCheckOperatorID)arlReporter[i]).m_strOperatorID;

				//				m_arlReporter.Add(((clsPathologyOrgCheckOperatorID)arlReporter[i]).m_strOperatorID);
			}
		}
		#endregion

		#region Print
		/*
		* DataSet : dtsPathologyOrgCheckOrder
		* DataTable : MainRecord
		* 	DataColumn0 : InPatientID(string)
		* 	DataColumn1 : InPatientDate(string)
		* 	DataColumn2 : CreateDate(string)
		* 	DataColumn3 : ModifyDate(string)
		* 	DataColumn4 : CreateUserID(string)
		* 	DataColumn5 : MedicalCheckNo(string)
		* 	DataColumn6 : HospitalName(string)
		* 	DataColumn7 : LastCheckNumber(string)
		* 	DataColumn8 : SendThings(string)
		* 	DataColumn9 : FromBody(string)
		* 	DataColumn10 : SickenPeriod(string)
		* 	DataColumn11 : History(string)
		* 	DataColumn12 : ClinicalInfo(string)
		* 	DataColumn13 : OperationInfo(string)
		* 	DataColumn14 : CheckAim(string)
		* 	DataColumn15 : BiologyChemistry(string)
		* 	DataColumn16 : Blood(string)
		* 	DataColumn17 : XRay(string)
		* 	DataColumn18 : BloodSerum(string)
		* 	DataColumn19 : Other(string)
		* 	DataColumn20 : ClinicalDignose(string)
		* 	DataColumn21 : SendDate(string)
		* 	DataColumn22 : ReceiveDate(string)
		* 	DataColumn23 : ColorAndSlice(string)
		* 	DataColumn24 : EyeCheck(string)
		* 	DataColumn25 : OrganiseBuryFull(string)
		* 	DataColumn26 : OrganiseStay(string)
		* 	DataColumn27 : EyeSample(string)
		* 	DataColumn28 : PathologyDignose(string)
		* 	DataColumn29 : ReportDate(string)
		* 	DataColumn30 : PatientName(string)
		* 	DataColumn31 : PatientSex(string)
		* 	DataColumn32 : PatientAge(string)
		* 	DataColumn33 : NativePlace(string)
		* 	DataColumn34 : Marriage (string)
		* 	DataColumn35 : Occupation(string)
		* 	DataColumn36 : PatientDepartment(string)
		* 	DataColumn37 : PatientSickRoom(string)
		* 	DataColumn38 : Maker(string)
		* 	DataColumn39 : Checker(string)
		* 	DataColumn40 : Reserved1(string)
		* 	DataColumn41 : Reserved2(string)
		* 	DataColumn42 : Reserved3(string)
		*/ 
		private DataSet InitdtsPathologyOrgCheckOrderDataSet()
		{
			DataSet dsdtsPathologyOrgCheckOrder = new DataSet("dtsPathologyOrgCheckOrder");

			DataTable dtMainRecord = new DataTable("MainRecord");

			DataColumn dcMainRecordInPatientID = new DataColumn("InPatientID",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordInPatientID);

			DataColumn dcMainRecordInPatientDate = new DataColumn("InPatientDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordInPatientDate);

			DataColumn dcMainRecordCreateDate = new DataColumn("CreateDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordCreateDate);

			DataColumn dcMainRecordModifyDate = new DataColumn("ModifyDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordModifyDate);

			DataColumn dcMainRecordCreateUserID = new DataColumn("CreateUserID",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordCreateUserID);

			DataColumn dcMainRecordMedicalCheckNo = new DataColumn("MedicalCheckNo",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordMedicalCheckNo);

			DataColumn dcMainRecordHospitalName = new DataColumn("HospitalName",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordHospitalName);

			DataColumn dcMainRecordLastCheckNumber = new DataColumn("LastCheckNumber",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordLastCheckNumber);

			DataColumn dcMainRecordSendThings = new DataColumn("SendThings",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordSendThings);

			DataColumn dcMainRecordFromBody = new DataColumn("FromBody",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordFromBody);

			DataColumn dcMainRecordSickenPeriod = new DataColumn("SickenPeriod",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordSickenPeriod);

			DataColumn dcMainRecordHistory = new DataColumn("History",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordHistory);

			DataColumn dcMainRecordClinicalInfo = new DataColumn("ClinicalInfo",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordClinicalInfo);

			DataColumn dcMainRecordOperationInfo = new DataColumn("OperationInfo",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordOperationInfo);

			DataColumn dcMainRecordCheckAim = new DataColumn("CheckAim",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordCheckAim);

			DataColumn dcMainRecordBiologyChemistry = new DataColumn("BiologyChemistry",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordBiologyChemistry);

			DataColumn dcMainRecordBlood = new DataColumn("Blood",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordBlood);

			DataColumn dcMainRecordXRay = new DataColumn("XRay",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordXRay);

			DataColumn dcMainRecordBloodSerum = new DataColumn("BloodSerum",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordBloodSerum);

			DataColumn dcMainRecordOther = new DataColumn("Other",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordOther);

			DataColumn dcMainRecordClinicalDignose = new DataColumn("ClinicalDignose",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordClinicalDignose);

			DataColumn dcMainRecordSendDate = new DataColumn("SendDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordSendDate);

			DataColumn dcMainRecordReceiveDate = new DataColumn("ReceiveDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordReceiveDate);

			DataColumn dcMainRecordColorAndSlice = new DataColumn("ColorAndSlice",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordColorAndSlice);

			DataColumn dcMainRecordEyeCheck = new DataColumn("EyeCheck",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordEyeCheck);

			DataColumn dcMainRecordOrganiseBuryFull = new DataColumn("OrganiseBuryFull",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordOrganiseBuryFull);

			DataColumn dcMainRecordOrganiseStay = new DataColumn("OrganiseStay",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordOrganiseStay);

			DataColumn dcMainRecordEyeSample = new DataColumn("EyeSample",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordEyeSample);

			DataColumn dcMainRecordPathologyDignose = new DataColumn("PathologyDignose",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPathologyDignose);

			DataColumn dcMainRecordReportDate = new DataColumn("ReportDate",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordReportDate);

			DataColumn dcMainRecordPatientName = new DataColumn("PatientName",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPatientName);

			DataColumn dcMainRecordPatientSex = new DataColumn("PatientSex",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPatientSex);

			DataColumn dcMainRecordPatientAge = new DataColumn("PatientAge",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPatientAge);

			DataColumn dcMainRecordNativePlace = new DataColumn("NativePlace",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordNativePlace);

			DataColumn dcMainRecordMarriage  = new DataColumn("Marriage ",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordMarriage );

			DataColumn dcMainRecordOccupation = new DataColumn("Occupation",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordOccupation);

			DataColumn dcMainRecordPatientDepartment = new DataColumn("PatientDepartment",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPatientDepartment);

			DataColumn dcMainRecordPatientSickRoom = new DataColumn("PatientSickRoom",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordPatientSickRoom);

			DataColumn dcMainRecordMaker = new DataColumn("Maker",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordMaker);

			DataColumn dcMainRecordChecker = new DataColumn("Checker",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordChecker);

			DataColumn dcMainRecordReserved1 = new DataColumn("Reserved1",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordReserved1);

			DataColumn dcMainRecordReserved2 = new DataColumn("Reserved2",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordReserved2);

			DataColumn dcMainRecordReserved3 = new DataColumn("Reserved3",typeof(string));

			dtMainRecord.Columns.Add(dcMainRecordReserved3);

			dsdtsPathologyOrgCheckOrder.Tables.Add(dtMainRecord);

			return dsdtsPathologyOrgCheckOrder;
		}

		/*
		* DataSet : dtsPathologyOrgCheckOrder
		* DataTable : MainRecord
		* 	DataColumn 0: InPatientID(string)
		* 	DataColumn 1: InPatientDate(string)
		* 	DataColumn 2: CreateDate(string)
		* 	DataColumn 3: ModifyDate(string)
		* 	DataColumn 4: CreateUserID(string)
		* 	DataColumn 5: MedicalCheckNo(string)
		* 	DataColumn 6: HospitalName(string)
		* 	DataColumn 7: LastCheckNumber(string)
		* 	DataColumn 8: SendThings(string)
		* 	DataColumn 9: FromBody(string)
		* 	DataColumn 10: SickenPeriod(string)
		* 	DataColumn 11: History(string)
		* 	DataColumn 12: ClinicalInfo(string)
		* 	DataColumn 13: OperationInfo(string)
		* 	DataColumn 14: CheckAim(string)
		* 	DataColumn 15: BiologyChemistry(string)
		* 	DataColumn 16: Blood(string)
		* 	DataColumn 17: XRay(string)
		* 	DataColumn 18: BloodSerum(string)
		* 	DataColumn 19: Other(string)
		* 	DataColumn 20: ClinicalDignose(string)
		* 	DataColumn 21: SendDate(string)
		* 	DataColumn 22: ReceiveDate(string)
		* 	DataColumn 23: ColorAndSlice(string)
		* 	DataColumn 24: EyeCheck(string)
		* 	DataColumn 25: OrganiseBuryFull(string)
		* 	DataColumn 26: OrganiseStay(string)
		* 	DataColumn 27: EyeSample(string)
		* 	DataColumn 28: PathologyDignose(string)
		* 	DataColumn 29: ReportDate(string)
		* 	DataColumn 30: PatientName(string)
		* 	DataColumn 31: PatientSex(string)
		* 	DataColumn 32: PatientAge(string)
		* 	DataColumn 33: NativePlace(string)
		* 	DataColumn 34: Marriage (string)
		* 	DataColumn 35: Occupation(string)
		* 	DataColumn 36: PatientDepartment(string)
		* 	DataColumn 37: PatientSickRoom(string)
		* 	DataColumn 38: Maker(string)
		* 	DataColumn 39: Checker(string)
		* 	DataColumn 40: Reserved1(string)
		* 	DataColumn 41: Reserved2(string)
		* 	DataColumn 42: Reserved3(string)
		*/ 
		private void AddNewDataFordtsPathologyOrgCheckOrderDataSet(DataSet dsdtsPathologyOrgCheckOrder)
		{
			//Checker
			string strChecker = "";
			for(int i = 0; i < dtbChecker.Rows.Count; i++)
			{
				strChecker += dtbChecker.Rows[i][1].ToString() + " ";
			}

			//Maker
			string strMaker = "";
			for(int i = 0; i < dtbMaker.Rows.Count; i++)
			{
				strMaker += dtbMaker.Rows[i][1].ToString() + " ";
			}

			//Reporter
			string strReporter = "";
			for(int i = 0; i < dtbReporter.Rows.Count; i++)
			{
				strReporter += dtbReporter.Rows[i][1].ToString() + " ";
			}

			//Send Date
			string strSendDate = "";
			if(m_strInPatientID != null && m_strInPatientID != "")
			{
				if(dtpSendDate.Value.Hour > 12)
				{
					strSendDate = dtpSendDate.Value.ToString("D") + " 下午";
				}
				else
				{
					strSendDate = dtpSendDate.Value.ToString("D") + " 上午";
				}
			}

			DataTable dtMainRecord = dsdtsPathologyOrgCheckOrder.Tables["MAINRECORD"];
			dtMainRecord.Rows.Clear();

			object [] objMainRecordDatas = new object[43];

            if (m_ObjCurrentEmrPatientSession != null)
            {
                objMainRecordDatas[0] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
            }
            else
            {
                objMainRecordDatas[0] = string.Empty;
            }
            //objMainRecordDatas[0] = m_strInPatientID;
			//objMainRecordDatas[1] = ;
			//objMainRecordDatas[2] = ;
			//objMainRecordDatas[3] = ;
			objMainRecordDatas[4] = (m_strInPatientID != null && m_strInPatientID != "") ? m_txtDoctor.Text : "";
			objMainRecordDatas[5] = txtMedicalCheckNo.Text;
			objMainRecordDatas[6] = txtHospitalName.Text;
			objMainRecordDatas[7] = txtLastCheckNumber.Text;
			objMainRecordDatas[8] = txtSendThing.Text;
			objMainRecordDatas[9] = txtFromBody.Text;
			objMainRecordDatas[10] = txtSickenPeriod.Text;
			objMainRecordDatas[11] = txtHistory.Text;
			objMainRecordDatas[12] = txtClinicalInfo.Text;
			objMainRecordDatas[13] = txtOperationInfo.Text;
			objMainRecordDatas[14] = txtCheckAim.Text;
			objMainRecordDatas[15] = txtBiologyChemistry.Text;
			objMainRecordDatas[16] = txtBlood.Text;
			objMainRecordDatas[17] = txtXRay.Text;
			objMainRecordDatas[18] = txtBloodSerum.Text;
			objMainRecordDatas[19] = txtOther.Text;
			objMainRecordDatas[20] = txtClinicalDignose.Text;
//			objMainRecordDatas[21] = strSendDate;
//			objMainRecordDatas[22] = (m_strInPatientID != null && m_strInPatientID != "") ? dtpReceiveDate.Value.ToString("D") : "";
			objMainRecordDatas[23] = txtColorAndSlice.Text;
			objMainRecordDatas[24] = txtEyeCheck.Text;
			objMainRecordDatas[25] = (rdbOrganiseBuryFull.Checked) ? "√" : "";
			objMainRecordDatas[26] = (rdbOrganiseStay.Checked) ? "√" : "";
			objMainRecordDatas[27] = (rdbEyeSample.Checked) ? "√" : "";
			objMainRecordDatas[28] = txtPathologyDignose.Text;
			objMainRecordDatas[29] = (m_strInPatientID != null && m_strInPatientID != "") ? dtpReportDate.Value.ToString("D") : "";
            if (m_objSelectedPatient != null)
            {
                objMainRecordDatas[30] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrLastName; ;
			    objMainRecordDatas[31] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			    objMainRecordDatas[32] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
			    objMainRecordDatas[33] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNativePlace;
			    objMainRecordDatas[34] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
			    objMainRecordDatas[35] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
            }
            else
            {
                objMainRecordDatas[30] = string.Empty;
                objMainRecordDatas[31] = string.Empty;
                objMainRecordDatas[32] = string.Empty;
                objMainRecordDatas[33] = string.Empty;
                objMainRecordDatas[34] = string.Empty;
                objMainRecordDatas[35] = string.Empty;
            }
            if (m_ObjCurrentEmrPatientSession != null)
            {
                objMainRecordDatas[36] = m_ObjCurrentEmrPatientSession.m_strAreaName;
            }
            else
            {
                objMainRecordDatas[36] = string.Empty;
            }
            if (m_ObjCurrentBed != null)
            {
                objMainRecordDatas[37] = m_ObjCurrentBed.m_strCODE_CHR;
            }
            else
            {
                objMainRecordDatas[37] = string.Empty;
            }
			objMainRecordDatas[38] = strMaker;
			objMainRecordDatas[39] = strChecker;
			objMainRecordDatas[40] = strReporter;
			//objMainRecordDatas[41] = ;
			//objMainRecordDatas[42] = ;
			dtMainRecord.Rows.Add(objMainRecordDatas);
			m_rpdOrderRept.Database.Tables["MAINRECORD"].SetDataSource(dtMainRecord);
			m_rpdOrderRept.Refresh();

		}
		#endregion

		#region 添加键盘快捷键
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
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter	
				
					//					if(sender.GetType().Name=="ctlBorderTextBox" && ((ctlBorderTextBox)sender).Name=="txtInPatientID")
					//					{
					//						if(m_lsvInPatientID.Items.Count==1 && txtInPatientID.Text.Length==7)
					//						{
					//							m_mthClearPatientBaseInfo();
					//							this.m_lsvInPatientID.Visible=false;
					//							
					//						}
					//					}
					//					
					//					else if(sender.GetType().Name=="ListView" && ((ListView)sender).Name=="m_lsvInPatientID")
					//					{
					//						if(m_lsvInPatientID.SelectedItems.Count <= 0)
					//							return;
					//
					//						m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
					//							
					//					}
				
					if(((Control)sender).Name!="txtHistory" &&
						((Control)sender).Name!="txtClinicalInfo" &&
						((Control)sender).Name!="txtOperationInfo" &&
						((Control)sender).Name!="txtCheckAim" &&
						((Control)sender).Name!="txtBlood" &&
						((Control)sender).Name!="txtXRay" &&
						((Control)sender).Name!="txtBloodSerum" &&
						((Control)sender).Name!="txtOther" &&
						((Control)sender).Name!="txtClinicalDignose" &&
						((Control)sender).Name!="txtColorAndSlice" &&
						((Control)sender).Name!="txtEyeCheck" &&
						((Control)sender).Name!="m_txtSign" &&
						((Control)sender).Name!="m_txtDoctor" &&
						((Control)sender).Name!="m_lsvEmployee" &&
						((Control)sender).Name!="txtPathologyDignose")
						SendKeys.Send(  "{tab}"); //注意:如果是button控件,则不能send "Tab" 而应该是"Enter",如果是Text控件且允许多行编辑，也不能send "Tab"
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
					m_blnCanSearch =false;
									
					m_mthClearPatientBaseInfo();
					this.dtpReceiveDate.Value = DateTime.Now;
					this.dtpSendDate.Value = DateTime.Now;
					this.dtpReportDate.Value = DateTime.Now;

					m_blnCanSearch =true;
					m_mthClearUpRecord();
                    
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion


		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//签名默认值
            //m_objSignTool2.m_mthSetDefaulEmployee();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtHistory.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.txtClinicalDignose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				txtClinicalInfo.Text = objInPatientCaseDefaultValue[0].m_strProfessionalCheck;
//			}				
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthClearUpRecord();
            m_strInPatientID = string.Empty;
            m_strInPatientDate = string.Empty;

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objSelectedPatient = m_objBaseCurrentPatient;

            m_objSelectedPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objSelectedPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objSelectedPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objSelectedPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_strInPatientID = p_objSelectedSession.m_strEMRInpatientId;
            m_strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID, m_strInPatientDate);
        }	
	
	}
}

