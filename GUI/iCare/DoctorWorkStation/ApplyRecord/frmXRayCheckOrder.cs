using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using iCareData;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	public class frmXRayCheckOrder : frmHRPBaseForm,PublicFunction
	{
		#region Variable
		private System.Windows.Forms.TreeView trvTime;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplicateDate;
		private com.digitalwave.controls.ctlRichTextBox txtHistory;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label label2;
		protected System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label4;
		protected System.Windows.Forms.Label label5;
		protected System.Windows.Forms.Label label6;
		protected System.Windows.Forms.Label label8;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label10;
		protected System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label label12;
		protected System.Windows.Forms.Label label13;
		private com.digitalwave.controls.ctlRichTextBox txtCheckAndResult;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalDignose;
		private com.digitalwave.controls.ctlRichTextBox txtCheckAim;
		public com.digitalwave.controls.ctlRichTextBox txtCheckPlace;
		public com.digitalwave.controls.ctlRichTextBox txtClairvoyance;
		public com.digitalwave.controls.ctlRichTextBox txtPhoto;
		public com.digitalwave.controls.ctlRichTextBox txtHavePhoto;
		public com.digitalwave.controls.ctlRichTextBox txtHavePhotoOut;
		private System.Windows.Forms.DataGrid dtgCommonRecord;
		private System.Windows.Forms.DataGridTableStyle dtbCommonRecordStyle;
		private System.Windows.Forms.DataGridTextBoxColumn dcmCheckPlace;
		private System.Windows.Forms.DataGridTextBoxColumn dcmMappingPlace;
		private System.Windows.Forms.DataGridTextBoxColumn dcmPhotoArea;
		private System.Windows.Forms.DataGridTextBoxColumn dcmPhotoThickness;
		private System.Windows.Forms.DataGridTextBoxColumn dcmDistance;
		private System.Windows.Forms.DataGridTextBoxColumn dcmVoltage;
		private System.Windows.Forms.DataGridTextBoxColumn dcmElectricity;
		private System.Windows.Forms.DataGridTextBoxColumn dcmTime;
		private System.Windows.Forms.DataGridTextBoxColumn dcmBucky;
		protected System.Windows.Forms.Label label15;
		protected System.Windows.Forms.Label lblSickRoom;
		protected System.Windows.Forms.Label label16;
		protected System.Windows.Forms.Label label17;
		public com.digitalwave.controls.ctlRichTextBox txtNotHavePhoto;
		public com.digitalwave.controls.ctlRichTextBox txtCharge;
		public com.digitalwave.controls.ctlRichTextBox txtAdditionCharge;
		private System.Windows.Forms.DataGridTableStyle dtbSpecialRecordStyle;
		private System.Windows.Forms.DataGrid dtgSpecialRecord;
		private System.Windows.Forms.DataGridTextBoxColumn dcmOperator;
		private System.Windows.Forms.DataGridTextBoxColumn dcmCheckPlaceSpecial;
		private System.Windows.Forms.DataGridTextBoxColumn dcmPhotoSeq;
		private System.Windows.Forms.DataGridTextBoxColumn dcmTimeOfAfterInject;
		private System.Windows.Forms.DataGridTextBoxColumn dcmRemark;
		private System.Windows.Forms.DataGridTableStyle dtbOperatorStyle;
		private System.Windows.Forms.DataGrid dtgOperator;
		private System.Windows.Forms.DataGridTextBoxColumn dcmOperatorID;
		private System.Windows.Forms.DataGridTextBoxColumn dcmOperatorName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dcmPhotoID;
		private System.Windows.Forms.DataGridTextBoxColumn dcmPhotoIDSpecial;
		private System.Windows.Forms.ListView lsvLike;
		private System.Windows.Forms.ColumnHeader clmEmployeeID;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dcmOperatorIDSpecial;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		protected System.Windows.Forms.Label label7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox ctlBorderTextBox1;
		protected System.Windows.Forms.Label label18;
		private System.Windows.Forms.Panel pnlCheckBoxs;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		protected System.Windows.Forms.Label lblDoctor;
		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.CheckBox m_chkCheckPart61;
		private System.Windows.Forms.CheckBox m_chkCheckPart58;
		private System.Windows.Forms.CheckBox m_chkCheckPart60;
		private System.Windows.Forms.CheckBox m_chkCheckPart59;
		private System.Windows.Forms.CheckBox m_chkCheckPart57;
		private System.Windows.Forms.CheckBox m_chkCheckPart54;
		private System.Windows.Forms.CheckBox m_chkCheckPart56;
		private System.Windows.Forms.CheckBox m_chkCheckPart55;
		private System.Windows.Forms.CheckBox m_chkCheckPart53;
		private System.Windows.Forms.CheckBox m_chkCheckPart50;
		private System.Windows.Forms.CheckBox m_chkCheckPart52;
		private System.Windows.Forms.CheckBox m_chkCheckPart51;
		private System.Windows.Forms.CheckBox m_chkCheckPart49;
		private System.Windows.Forms.CheckBox m_chkCheckPart48;
		private System.Windows.Forms.CheckBox m_chkCheckPart45;
		private System.Windows.Forms.CheckBox m_chkCheckPart47;
		private System.Windows.Forms.CheckBox m_chkCheckPart46;
		private System.Windows.Forms.CheckBox m_chkCheckPart42;
		private System.Windows.Forms.CheckBox m_chkCheckPart44;
		private System.Windows.Forms.CheckBox m_chkCheckPart43;
		private System.Windows.Forms.CheckBox m_chkCheckPart41;
		private System.Windows.Forms.CheckBox m_chkCheckPart38;
		private System.Windows.Forms.CheckBox m_chkCheckPart40;
		private System.Windows.Forms.CheckBox m_chkCheckPart39;
		private System.Windows.Forms.CheckBox m_chkCheckPart37;
		private System.Windows.Forms.CheckBox m_chkCheckPart36;
		private System.Windows.Forms.CheckBox m_chkCheckPart33;
		private System.Windows.Forms.CheckBox m_chkCheckPart35;
		private System.Windows.Forms.CheckBox m_chkCheckPart34;
		private System.Windows.Forms.CheckBox m_chkCheckPart32;
		private System.Windows.Forms.CheckBox m_chkCheckPart31;
		private System.Windows.Forms.CheckBox m_chkCheckPart28;
		private System.Windows.Forms.CheckBox m_chkCheckPart30;
		private System.Windows.Forms.CheckBox m_chkCheckPart29;
		private System.Windows.Forms.CheckBox m_chkCheckPart27;
		private System.Windows.Forms.CheckBox m_chkCheckPart26;
		private System.Windows.Forms.CheckBox m_chkCheckPart23;
		private System.Windows.Forms.CheckBox m_chkCheckPart25;
		private System.Windows.Forms.CheckBox m_chkCheckPart24;
		private System.Windows.Forms.CheckBox m_chkCheckPart22;
		private System.Windows.Forms.CheckBox m_chkCheckPart21;
		private System.Windows.Forms.CheckBox m_chkCheckPart20;
		private System.Windows.Forms.CheckBox m_chkCheckPart19;
		private System.Windows.Forms.CheckBox m_chkCheckPart16;
		private System.Windows.Forms.CheckBox m_chkCheckPart18;
		private System.Windows.Forms.CheckBox m_chkCheckPart17;
		private System.Windows.Forms.CheckBox m_chkCheckPart15;
		private System.Windows.Forms.CheckBox m_chkCheckPart14;
		private System.Windows.Forms.CheckBox m_chkCheckPart11;
		private System.Windows.Forms.CheckBox m_chkCheckPart13;
		private System.Windows.Forms.CheckBox m_chkCheckPart12;
		private System.Windows.Forms.CheckBox m_chkCheckPart10;
		private System.Windows.Forms.CheckBox m_chkCheckPart09;
		private System.Windows.Forms.CheckBox m_chkCheckPart06;
		private System.Windows.Forms.CheckBox m_chkCheckPart08;
		private System.Windows.Forms.CheckBox m_chkCheckPart07;
		private System.Windows.Forms.CheckBox m_chkCheckPart04;
		private System.Windows.Forms.CheckBox m_chkCheckPart02;
		private System.Windows.Forms.CheckBox m_chkCheckPart05;
		private System.Windows.Forms.CheckBox m_chkCheckPart01;
		private System.Windows.Forms.CheckBox m_chkCheckPart03;
		protected System.Windows.Forms.Label lblXRayNo;
		protected System.Windows.Forms.Label lblInsuranceNo;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtXRayNo;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtInsuranceNo;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtOtherCheckInfo;
		protected System.Windows.Forms.Label m_lblBlank;
		protected System.Windows.Forms.Label lblContact;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtContactInfo;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtApplicationID;
		protected System.Windows.Forms.Label label26;
		private PinkieControls.ButtonXP m_cmdSign;
		private const int CHECKBOXS=61;
		private System.Windows.Forms.CheckBox m_chkNeedRequire;
        protected System.Windows.Forms.RichTextBox m_txtApplicationComment;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
        private TextBox m_txtSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
		#endregion

		#region Contructor
		public frmXRayCheckOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

			m_objDomain = new clsXRayCheckOrderDomain();

			#region White Border
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlBorder(m_txtApplicationComment);

            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlControl ,
            //        });
					
            //    }
            //}
			#endregion

			#region 初始化DataGrid
			this.dtbCommonRecord = new DataTable("dtbCommonRecord");
			this.dtbSpecialRecord = new DataTable("dtbSpecialRecord");
			this.dtbOperator = new DataTable("dtbOperator");

			this.dtbCommonRecord.Columns.Add("检查部位");
			this.dtbCommonRecord.Columns.Add("投照位置");
			this.dtbCommonRecord.Columns.Add("照片面积");
			this.dtbCommonRecord.Columns.Add("厚度");
			this.dtbCommonRecord.Columns.Add("距离");
			this.dtbCommonRecord.Columns.Add("KV");
			this.dtbCommonRecord.Columns.Add("mA");
			this.dtbCommonRecord.Columns.Add("时间");
			this.dtbCommonRecord.Columns.Add("Bucky");
			this.dtbCommonRecord.Columns.Add("照片ID");
			this.dtgCommonRecord.DataSource = dtbCommonRecord;

			
			this.dtbSpecialRecord.Columns.Add("术者");
			this.dtbSpecialRecord.Columns.Add("检查部位");
			this.dtbSpecialRecord.Columns.Add("照片次序");
			this.dtbSpecialRecord.Columns.Add("注射药后早片时间");
			this.dtbSpecialRecord.Columns.Add("附记");
			this.dtbSpecialRecord.Columns.Add("照片ID");
			this.dtbSpecialRecord.Columns.Add("术者ID");
			this.dtgSpecialRecord.DataSource = dtbSpecialRecord;
			
			this.dtbOperator.Columns.Add("术者ID");
			this.dtbOperator.Columns.Add("术者签名");
			this.dtgOperator.DataSource = dtbOperator;

			m_objGridListView0 = new clsGridListView(dtgSpecialRecord,dcmOperatorIDSpecial,lsvLike,new EventHandler(m_objAddListViewItemArr));
			m_objGridListView1 = new clsGridListView(dtgOperator,dcmOperatorID,lsvLike,new EventHandler(m_objAddListViewItemArr));

			dtgSpecialRecord.GotFocus += new EventHandler(m_mthSpecial_GotFocus);
			dtgOperator.GotFocus += new EventHandler(m_mthOperator_GotFocus);

			this.dtgCommonRecord.Focus();
			this.txtInPatientID.Focus();
			this.dtgSpecialRecord.Focus();
			this.txtInPatientID.Focus();
			this.dtgOperator.Focus();
			this.txtInPatientID.Focus();
			#endregion

			m_dtsRept = m_dtsInitXRayReportSetDataSet();

			//			m_rpdOrderRept = new ReportDocument();
			//			m_rpdOrderRept.Load(m_strTemplatePath + "rptXRayCheckOrder.rpt");

			//			m_arlOperatorFirst = new ArrayList();
			//			m_arlOperatorSecond = new ArrayList();

			m_mthSetQuickKeys();

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}
		#endregion

		#region Member
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private clsBorderTool  m_objBorderTool;

		private DataTable dtbCommonRecord;
		private DataTable dtbSpecialRecord;
		private DataTable dtbOperator;

		private bool m_blnCanSearch = true;

		private clsPatient m_objSelectedPatient;

		private string m_strInPatientID;

		private string m_strInPatientDate;

		private clsXRayCheckOrderDomain m_objDomain;

		private clsXRayCheckOrder m_objXRayCheckOrder;
		private clsXRayCommonRecord[] m_objXRayCommonRecord;
		private clsXRaySpecialRecord[] m_objXRaySpecialRecord;
		private clsXRayOperatorID[] m_objXRayOperatorID;

		private string m_strCreateDate = "";

		private int m_intRowNumber = 0; //保存当前dataGrid选定的行号
		private int m_intColumnNumber = 0;//保存当前dataGrid选定的列号
		private string m_strSenderName = "Special";

		private clsGridListView m_objGridListView0;
		private clsGridListView m_objGridListView1;

		private bool blnCanDelete=true;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXRayCheckOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.dtpApplicateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.txtHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheckAndResult = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClinicalDignose = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckAim = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckPlace = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClairvoyance = new com.digitalwave.controls.ctlRichTextBox();
            this.txtPhoto = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHavePhoto = new com.digitalwave.controls.ctlRichTextBox();
            this.txtHavePhotoOut = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtgCommonRecord = new System.Windows.Forms.DataGrid();
            this.dtbCommonRecordStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmCheckPlace = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmMappingPlace = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmPhotoArea = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmPhotoThickness = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmDistance = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmVoltage = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmElectricity = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmBucky = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmPhotoID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSickRoom = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNotHavePhoto = new com.digitalwave.controls.ctlRichTextBox();
            this.txtCharge = new com.digitalwave.controls.ctlRichTextBox();
            this.txtAdditionCharge = new com.digitalwave.controls.ctlRichTextBox();
            this.dtgSpecialRecord = new System.Windows.Forms.DataGrid();
            this.dtbSpecialRecordStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmCheckPlaceSpecial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmPhotoSeq = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmTimeOfAfterInject = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmRemark = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmPhotoIDSpecial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmOperatorIDSpecial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmOperator = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgOperator = new System.Windows.Forms.DataGrid();
            this.dtbOperatorStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmOperatorID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmOperatorName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lsvLike = new System.Windows.Forms.ListView();
            this.clmEmployeeID = new System.Windows.Forms.ColumnHeader();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.ctlBorderTextBox1 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlCheckBoxs = new System.Windows.Forms.Panel();
            this.txtOtherCheckInfo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_chkCheckPart61 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart58 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart60 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart59 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart57 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart54 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart56 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart55 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_chkCheckPart53 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart50 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart52 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart51 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart49 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart48 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart45 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart47 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart46 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart42 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart44 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart43 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_chkCheckPart41 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart38 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart40 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart39 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart37 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart36 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart33 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart35 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart34 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart32 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart31 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart28 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart30 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart29 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart27 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart26 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart23 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart25 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart24 = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_chkCheckPart22 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart21 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart20 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart19 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart16 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart18 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart17 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart15 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart14 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart11 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart13 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart12 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart10 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart09 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart06 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart08 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart07 = new System.Windows.Forms.CheckBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.m_chkCheckPart04 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart02 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart05 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart01 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckPart03 = new System.Windows.Forms.CheckBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContactInfo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblXRayNo = new System.Windows.Forms.Label();
            this.lblInsuranceNo = new System.Windows.Forms.Label();
            this.txtXRayNo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtInsuranceNo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblBlank = new System.Windows.Forms.Label();
            this.m_txtApplicationID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_chkNeedRequire = new System.Windows.Forms.CheckBox();
            this.m_txtApplicationComment = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommonRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperator)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCheckBoxs.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(49, 237);
            this.lblSex.Size = new System.Drawing.Size(24, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(186, 184);
            this.lblAge.Size = new System.Drawing.Size(28, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(47, 200);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(47, 223);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(102, 191);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(47, 140);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(87, 212);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(47, 168);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lsvInPatientID.Location = new System.Drawing.Point(79, 151);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(80, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInPatientID.Location = new System.Drawing.Point(114, 195);
            this.txtInPatientID.Size = new System.Drawing.Size(80, 23);
            this.txtInPatientID.TabIndex = 300;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(135, 168);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientName.TabIndex = 200;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(88, 192);
            this.m_txtBedNO.Size = new System.Drawing.Size(56, 23);
            this.m_txtBedNO.TabIndex = 100;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(50, 185);
            this.m_cboArea.TabIndex = 9999999;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lsvPatientName.Location = new System.Drawing.Point(67, 171);
            this.m_lsvPatientName.Size = new System.Drawing.Size(92, 84);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lsvBedNO.Location = new System.Drawing.Point(79, 171);
            this.m_lsvBedNO.Size = new System.Drawing.Size(80, 84);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(50, 212);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(47, 154);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(75, 195);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(99, 199);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(165, 165);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(90, 192);
            this.m_lblForTitle.Text = "X 线 检 查 申 请 单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(272, 187);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 38);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.label17);
            this.m_pnlNewBase.Controls.Add(this.label16);
            this.m_pnlNewBase.Controls.Add(this.txtCharge);
            this.m_pnlNewBase.Controls.Add(this.txtAdditionCharge);
            this.m_pnlNewBase.Controls.Add(this.lblInsuranceNo);
            this.m_pnlNewBase.Controls.Add(this.lblXRayNo);
            this.m_pnlNewBase.Controls.Add(this.label26);
            this.m_pnlNewBase.Controls.Add(this.m_txtApplicationID);
            this.m_pnlNewBase.Controls.Add(this.txtXRayNo);
            this.m_pnlNewBase.Controls.Add(this.txtInsuranceNo);
            this.m_pnlNewBase.Controls.Add(this.dtpApplicateDate);
            this.m_pnlNewBase.Controls.Add(this.lblOperationBeginTimeTitle);
            this.m_pnlNewBase.Controls.Add(this.trvTime);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(796, 110);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.trvTime, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblOperationBeginTimeTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.dtpApplicateDate, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtInsuranceNo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtXRayNo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtApplicationID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label26, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblXRayNo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblInsuranceNo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtAdditionCharge, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtCharge, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label16, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label17, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(192, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(602, 80);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(0, 31);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(190, 75);
            this.trvTime.TabIndex = 400;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(194, 62);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 521;
            this.lblOperationBeginTimeTitle.Text = "申请日期:";
            // 
            // dtpApplicateDate
            // 
            this.dtpApplicateDate.BorderColor = System.Drawing.Color.Black;
            this.dtpApplicateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplicateDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplicateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplicateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplicateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplicateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpApplicateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplicateDate.Location = new System.Drawing.Point(259, 58);
            this.dtpApplicateDate.m_BlnOnlyTime = false;
            this.dtpApplicateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplicateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplicateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplicateDate.Name = "dtpApplicateDate";
            this.dtpApplicateDate.ReadOnly = false;
            this.dtpApplicateDate.Size = new System.Drawing.Size(144, 22);
            this.dtpApplicateDate.TabIndex = 5;
            this.dtpApplicateDate.TextBackColor = System.Drawing.Color.White;
            this.dtpApplicateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // txtHistory
            // 
            this.txtHistory.AccessibleDescription = "病历";
            this.txtHistory.BackColor = System.Drawing.Color.White;
            this.txtHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHistory.ForeColor = System.Drawing.Color.White;
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
            this.txtHistory.Size = new System.Drawing.Size(744, 148);
            this.txtHistory.TabIndex = 700;
            this.txtHistory.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1294;
            this.label1.Text = "病历:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 1295;
            this.label2.Text = "临床检查及化验结果:";
            // 
            // txtCheckAndResult
            // 
            this.txtCheckAndResult.AccessibleDescription = "临床检查及化验结果";
            this.txtCheckAndResult.BackColor = System.Drawing.Color.White;
            this.txtCheckAndResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckAndResult.ForeColor = System.Drawing.Color.Black;
            this.txtCheckAndResult.Location = new System.Drawing.Point(8, 200);
            this.txtCheckAndResult.m_BlnPartControl = false;
            this.txtCheckAndResult.m_BlnReadOnly = false;
            this.txtCheckAndResult.m_BlnUnderLineDST = false;
            this.txtCheckAndResult.m_ClrDST = System.Drawing.Color.Red;
            this.txtCheckAndResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCheckAndResult.m_IntCanModifyTime = 6;
            this.txtCheckAndResult.m_IntPartControlLength = 0;
            this.txtCheckAndResult.m_IntPartControlStartIndex = 0;
            this.txtCheckAndResult.m_StrUserID = "";
            this.txtCheckAndResult.m_StrUserName = "";
            this.txtCheckAndResult.Name = "txtCheckAndResult";
            this.txtCheckAndResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCheckAndResult.Size = new System.Drawing.Size(744, 124);
            this.txtCheckAndResult.TabIndex = 800;
            this.txtCheckAndResult.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 1297;
            this.label3.Text = "临床诊断:";
            // 
            // txtClinicalDignose
            // 
            this.txtClinicalDignose.AccessibleDescription = "临床诊断";
            this.txtClinicalDignose.BackColor = System.Drawing.Color.White;
            this.txtClinicalDignose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalDignose.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalDignose.Location = new System.Drawing.Point(8, 352);
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
            this.txtClinicalDignose.Size = new System.Drawing.Size(348, 92);
            this.txtClinicalDignose.TabIndex = 900;
            this.txtClinicalDignose.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(360, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1299;
            this.label4.Text = "检查目的:";
            // 
            // txtCheckAim
            // 
            this.txtCheckAim.AccessibleDescription = "检查目的";
            this.txtCheckAim.BackColor = System.Drawing.Color.White;
            this.txtCheckAim.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckAim.ForeColor = System.Drawing.Color.Black;
            this.txtCheckAim.Location = new System.Drawing.Point(364, 352);
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
            this.txtCheckAim.Size = new System.Drawing.Size(388, 92);
            this.txtCheckAim.TabIndex = 1000;
            this.txtCheckAim.Text = "";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(147, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 8);
            this.label5.TabIndex = 1301;
            this.label5.Text = "检查部位:";
            this.label5.Visible = false;
            // 
            // txtCheckPlace
            // 
            this.txtCheckPlace.AccessibleDescription = "检查部位";
            this.txtCheckPlace.BackColor = System.Drawing.Color.White;
            this.txtCheckPlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckPlace.ForeColor = System.Drawing.Color.Black;
            this.txtCheckPlace.Location = new System.Drawing.Point(200, 588);
            this.txtCheckPlace.m_BlnPartControl = false;
            this.txtCheckPlace.m_BlnReadOnly = false;
            this.txtCheckPlace.m_BlnUnderLineDST = false;
            this.txtCheckPlace.m_ClrDST = System.Drawing.Color.Red;
            this.txtCheckPlace.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCheckPlace.m_IntCanModifyTime = 6;
            this.txtCheckPlace.m_IntPartControlLength = 0;
            this.txtCheckPlace.m_IntPartControlStartIndex = 0;
            this.txtCheckPlace.m_StrUserID = "";
            this.txtCheckPlace.m_StrUserName = "";
            this.txtCheckPlace.Multiline = false;
            this.txtCheckPlace.Name = "txtCheckPlace";
            this.txtCheckPlace.Size = new System.Drawing.Size(168, 20);
            this.txtCheckPlace.TabIndex = 10;
            this.txtCheckPlace.Text = "";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(80, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 8);
            this.label6.TabIndex = 30008;
            this.label6.Text = "透    视:";
            // 
            // txtClairvoyance
            // 
            this.txtClairvoyance.AccessibleDescription = "透视";
            this.txtClairvoyance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtClairvoyance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClairvoyance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClairvoyance.ForeColor = System.Drawing.Color.White;
            this.txtClairvoyance.Location = new System.Drawing.Point(4, 0);
            this.txtClairvoyance.m_BlnPartControl = false;
            this.txtClairvoyance.m_BlnReadOnly = false;
            this.txtClairvoyance.m_BlnUnderLineDST = false;
            this.txtClairvoyance.m_ClrDST = System.Drawing.Color.Red;
            this.txtClairvoyance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClairvoyance.m_IntCanModifyTime = 6;
            this.txtClairvoyance.m_IntPartControlLength = 0;
            this.txtClairvoyance.m_IntPartControlStartIndex = 0;
            this.txtClairvoyance.m_StrUserID = "";
            this.txtClairvoyance.m_StrUserName = "";
            this.txtClairvoyance.Multiline = false;
            this.txtClairvoyance.Name = "txtClairvoyance";
            this.txtClairvoyance.Size = new System.Drawing.Size(12, 20);
            this.txtClairvoyance.TabIndex = 12;
            this.txtClairvoyance.Text = "";
            // 
            // txtPhoto
            // 
            this.txtPhoto.AccessibleDescription = "照片";
            this.txtPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtPhoto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhoto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhoto.ForeColor = System.Drawing.Color.White;
            this.txtPhoto.Location = new System.Drawing.Point(156, 8);
            this.txtPhoto.m_BlnPartControl = false;
            this.txtPhoto.m_BlnReadOnly = false;
            this.txtPhoto.m_BlnUnderLineDST = false;
            this.txtPhoto.m_ClrDST = System.Drawing.Color.Red;
            this.txtPhoto.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtPhoto.m_IntCanModifyTime = 6;
            this.txtPhoto.m_IntPartControlLength = 0;
            this.txtPhoto.m_IntPartControlStartIndex = 0;
            this.txtPhoto.m_StrUserID = "";
            this.txtPhoto.m_StrUserName = "";
            this.txtPhoto.Multiline = false;
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(12, 20);
            this.txtPhoto.TabIndex = 14;
            this.txtPhoto.Text = "";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(64, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 8);
            this.label8.TabIndex = 30012;
            this.label8.Text = "未 照 过  片（";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(40, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 8);
            this.label9.TabIndex = 30013;
            this.label9.Text = "照   过   片（";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(20, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 8);
            this.label10.TabIndex = 30014;
            this.label10.Text = "在院外照过片（";
            // 
            // txtHavePhoto
            // 
            this.txtHavePhoto.AccessibleDescription = "照过片";
            this.txtHavePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtHavePhoto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHavePhoto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHavePhoto.ForeColor = System.Drawing.Color.White;
            this.txtHavePhoto.Location = new System.Drawing.Point(128, 0);
            this.txtHavePhoto.m_BlnPartControl = false;
            this.txtHavePhoto.m_BlnReadOnly = false;
            this.txtHavePhoto.m_BlnUnderLineDST = false;
            this.txtHavePhoto.m_ClrDST = System.Drawing.Color.Red;
            this.txtHavePhoto.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtHavePhoto.m_IntCanModifyTime = 6;
            this.txtHavePhoto.m_IntPartControlLength = 0;
            this.txtHavePhoto.m_IntPartControlStartIndex = 0;
            this.txtHavePhoto.m_StrUserID = "";
            this.txtHavePhoto.m_StrUserName = "";
            this.txtHavePhoto.Multiline = false;
            this.txtHavePhoto.Name = "txtHavePhoto";
            this.txtHavePhoto.Size = new System.Drawing.Size(10, 20);
            this.txtHavePhoto.TabIndex = 13;
            this.txtHavePhoto.Text = "";
            // 
            // txtHavePhotoOut
            // 
            this.txtHavePhotoOut.AccessibleDescription = "在院外照过片";
            this.txtHavePhotoOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtHavePhotoOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHavePhotoOut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHavePhotoOut.ForeColor = System.Drawing.Color.White;
            this.txtHavePhotoOut.Location = new System.Drawing.Point(140, 0);
            this.txtHavePhotoOut.m_BlnPartControl = false;
            this.txtHavePhotoOut.m_BlnReadOnly = false;
            this.txtHavePhotoOut.m_BlnUnderLineDST = false;
            this.txtHavePhotoOut.m_ClrDST = System.Drawing.Color.Red;
            this.txtHavePhotoOut.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtHavePhotoOut.m_IntCanModifyTime = 6;
            this.txtHavePhotoOut.m_IntPartControlLength = 0;
            this.txtHavePhotoOut.m_IntPartControlStartIndex = 0;
            this.txtHavePhotoOut.m_StrUserID = "";
            this.txtHavePhotoOut.m_StrUserName = "";
            this.txtHavePhotoOut.Multiline = false;
            this.txtHavePhotoOut.Name = "txtHavePhotoOut";
            this.txtHavePhotoOut.Size = new System.Drawing.Size(10, 20);
            this.txtHavePhotoOut.TabIndex = 15;
            this.txtHavePhotoOut.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(84, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 30018;
            this.label11.Text = "）";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(64, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 30019;
            this.label12.Text = "）";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(88, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 30020;
            this.label13.Text = "）";
            // 
            // dtgCommonRecord
            // 
            this.dtgCommonRecord.AllowSorting = false;
            this.dtgCommonRecord.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dtgCommonRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCommonRecord.CaptionBackColor = System.Drawing.SystemColors.Desktop;
            this.dtgCommonRecord.CaptionText = "普通照片检查记录";
            this.dtgCommonRecord.DataMember = "";
            this.dtgCommonRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgCommonRecord.ForeColor = System.Drawing.Color.Black;
            this.dtgCommonRecord.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgCommonRecord.Location = new System.Drawing.Point(8, 4);
            this.dtgCommonRecord.Name = "dtgCommonRecord";
            this.dtgCommonRecord.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgCommonRecord.RowHeaderWidth = 40;
            this.dtgCommonRecord.Size = new System.Drawing.Size(24, 20);
            this.dtgCommonRecord.TabIndex = 16;
            this.dtgCommonRecord.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbCommonRecordStyle});
            this.dtgCommonRecord.Visible = false;
            this.dtgCommonRecord.Leave += new System.EventHandler(this.dtgCommonRecord_Leave);
            // 
            // dtbCommonRecordStyle
            // 
            this.dtbCommonRecordStyle.AllowSorting = false;
            this.dtbCommonRecordStyle.DataGrid = this.dtgCommonRecord;
            this.dtbCommonRecordStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmCheckPlace,
            this.dcmMappingPlace,
            this.dcmPhotoArea,
            this.dcmPhotoThickness,
            this.dcmDistance,
            this.dcmVoltage,
            this.dcmElectricity,
            this.dcmTime,
            this.dcmBucky,
            this.dcmPhotoID});
            this.dtbCommonRecordStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbCommonRecordStyle.MappingName = "dtbCommonRecord";
            // 
            // dcmCheckPlace
            // 
            this.dcmCheckPlace.Format = "";
            this.dcmCheckPlace.FormatInfo = null;
            this.dcmCheckPlace.HeaderText = "检查部位";
            this.dcmCheckPlace.MappingName = "检查部位";
            this.dcmCheckPlace.NullText = "";
            this.dcmCheckPlace.Width = 75;
            // 
            // dcmMappingPlace
            // 
            this.dcmMappingPlace.Format = "";
            this.dcmMappingPlace.FormatInfo = null;
            this.dcmMappingPlace.HeaderText = "投照位置";
            this.dcmMappingPlace.MappingName = "投照位置";
            this.dcmMappingPlace.NullText = "";
            this.dcmMappingPlace.Width = 75;
            // 
            // dcmPhotoArea
            // 
            this.dcmPhotoArea.Format = "";
            this.dcmPhotoArea.FormatInfo = null;
            this.dcmPhotoArea.HeaderText = "照片面积";
            this.dcmPhotoArea.MappingName = "照片面积";
            this.dcmPhotoArea.NullText = "";
            this.dcmPhotoArea.Width = 75;
            // 
            // dcmPhotoThickness
            // 
            this.dcmPhotoThickness.Format = "";
            this.dcmPhotoThickness.FormatInfo = null;
            this.dcmPhotoThickness.HeaderText = "厚度";
            this.dcmPhotoThickness.MappingName = "厚度";
            this.dcmPhotoThickness.NullText = "";
            this.dcmPhotoThickness.Width = 75;
            // 
            // dcmDistance
            // 
            this.dcmDistance.Format = "";
            this.dcmDistance.FormatInfo = null;
            this.dcmDistance.HeaderText = "距离";
            this.dcmDistance.MappingName = "距离";
            this.dcmDistance.NullText = "";
            this.dcmDistance.Width = 75;
            // 
            // dcmVoltage
            // 
            this.dcmVoltage.Format = "";
            this.dcmVoltage.FormatInfo = null;
            this.dcmVoltage.HeaderText = "KV";
            this.dcmVoltage.MappingName = "KV";
            this.dcmVoltage.NullText = "";
            this.dcmVoltage.Width = 75;
            // 
            // dcmElectricity
            // 
            this.dcmElectricity.Format = "";
            this.dcmElectricity.FormatInfo = null;
            this.dcmElectricity.HeaderText = "mA";
            this.dcmElectricity.MappingName = "mA";
            this.dcmElectricity.NullText = "";
            this.dcmElectricity.Width = 75;
            // 
            // dcmTime
            // 
            this.dcmTime.Format = "";
            this.dcmTime.FormatInfo = null;
            this.dcmTime.HeaderText = "时间";
            this.dcmTime.MappingName = "时间";
            this.dcmTime.NullText = "";
            this.dcmTime.Width = 75;
            // 
            // dcmBucky
            // 
            this.dcmBucky.Format = "";
            this.dcmBucky.FormatInfo = null;
            this.dcmBucky.HeaderText = "Bucky";
            this.dcmBucky.MappingName = "Bucky";
            this.dcmBucky.NullText = "";
            this.dcmBucky.Width = 75;
            // 
            // dcmPhotoID
            // 
            this.dcmPhotoID.Format = "";
            this.dcmPhotoID.FormatInfo = null;
            this.dcmPhotoID.HeaderText = "照片ID";
            this.dcmPhotoID.MappingName = "照片ID";
            this.dcmPhotoID.NullText = "";
            this.dcmPhotoID.Width = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(85, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 30027;
            this.label15.Text = "病室:";
            this.label15.Visible = false;
            // 
            // lblSickRoom
            // 
            this.lblSickRoom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSickRoom.Location = new System.Drawing.Point(129, 191);
            this.lblSickRoom.Name = "lblSickRoom";
            this.lblSickRoom.Size = new System.Drawing.Size(76, 23);
            this.lblSickRoom.TabIndex = 30028;
            this.lblSickRoom.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(411, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 14);
            this.label16.TabIndex = 30030;
            this.label16.Text = "收费:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(550, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 30031;
            this.label17.Text = "加收:";
            // 
            // txtNotHavePhoto
            // 
            this.txtNotHavePhoto.AccessibleDescription = "未照过片";
            this.txtNotHavePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtNotHavePhoto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotHavePhoto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNotHavePhoto.ForeColor = System.Drawing.Color.White;
            this.txtNotHavePhoto.Location = new System.Drawing.Point(116, 8);
            this.txtNotHavePhoto.m_BlnPartControl = false;
            this.txtNotHavePhoto.m_BlnReadOnly = false;
            this.txtNotHavePhoto.m_BlnUnderLineDST = false;
            this.txtNotHavePhoto.m_ClrDST = System.Drawing.Color.Red;
            this.txtNotHavePhoto.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtNotHavePhoto.m_IntCanModifyTime = 6;
            this.txtNotHavePhoto.m_IntPartControlLength = 0;
            this.txtNotHavePhoto.m_IntPartControlStartIndex = 0;
            this.txtNotHavePhoto.m_StrUserID = "";
            this.txtNotHavePhoto.m_StrUserName = "";
            this.txtNotHavePhoto.Multiline = false;
            this.txtNotHavePhoto.Name = "txtNotHavePhoto";
            this.txtNotHavePhoto.Size = new System.Drawing.Size(10, 20);
            this.txtNotHavePhoto.TabIndex = 11;
            this.txtNotHavePhoto.Text = "";
            // 
            // txtCharge
            // 
            this.txtCharge.BackColor = System.Drawing.Color.White;
            this.txtCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.ForeColor = System.Drawing.Color.Black;
            this.txtCharge.Location = new System.Drawing.Point(460, 59);
            this.txtCharge.m_BlnPartControl = false;
            this.txtCharge.m_BlnReadOnly = false;
            this.txtCharge.m_BlnUnderLineDST = false;
            this.txtCharge.m_ClrDST = System.Drawing.Color.Red;
            this.txtCharge.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCharge.m_IntCanModifyTime = 6;
            this.txtCharge.m_IntPartControlLength = 0;
            this.txtCharge.m_IntPartControlStartIndex = 0;
            this.txtCharge.m_StrUserID = "";
            this.txtCharge.m_StrUserName = "";
            this.txtCharge.Multiline = false;
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(88, 20);
            this.txtCharge.TabIndex = 3;
            this.txtCharge.Text = "0.00";
            this.txtCharge.LostFocus += new System.EventHandler(this.txtCharge_LostFocus);
            // 
            // txtAdditionCharge
            // 
            this.txtAdditionCharge.BackColor = System.Drawing.Color.White;
            this.txtAdditionCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAdditionCharge.ForeColor = System.Drawing.Color.Black;
            this.txtAdditionCharge.Location = new System.Drawing.Point(597, 59);
            this.txtAdditionCharge.m_BlnPartControl = false;
            this.txtAdditionCharge.m_BlnReadOnly = false;
            this.txtAdditionCharge.m_BlnUnderLineDST = false;
            this.txtAdditionCharge.m_ClrDST = System.Drawing.Color.Red;
            this.txtAdditionCharge.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAdditionCharge.m_IntCanModifyTime = 6;
            this.txtAdditionCharge.m_IntPartControlLength = 0;
            this.txtAdditionCharge.m_IntPartControlStartIndex = 0;
            this.txtAdditionCharge.m_StrUserID = "";
            this.txtAdditionCharge.m_StrUserName = "";
            this.txtAdditionCharge.Multiline = false;
            this.txtAdditionCharge.Name = "txtAdditionCharge";
            this.txtAdditionCharge.Size = new System.Drawing.Size(84, 20);
            this.txtAdditionCharge.TabIndex = 4;
            this.txtAdditionCharge.Text = "0.00";
            this.txtAdditionCharge.LostFocus += new System.EventHandler(this.txtAdditionCharge_LostFocus);
            // 
            // dtgSpecialRecord
            // 
            this.dtgSpecialRecord.AllowSorting = false;
            this.dtgSpecialRecord.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dtgSpecialRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSpecialRecord.CaptionBackColor = System.Drawing.SystemColors.Desktop;
            this.dtgSpecialRecord.CaptionText = "特殊造影记录";
            this.dtgSpecialRecord.DataMember = "";
            this.dtgSpecialRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgSpecialRecord.ForeColor = System.Drawing.Color.White;
            this.dtgSpecialRecord.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgSpecialRecord.Location = new System.Drawing.Point(-4, 12);
            this.dtgSpecialRecord.Name = "dtgSpecialRecord";
            this.dtgSpecialRecord.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgSpecialRecord.RowHeaderWidth = 40;
            this.dtgSpecialRecord.Size = new System.Drawing.Size(28, 20);
            this.dtgSpecialRecord.TabIndex = 17;
            this.dtgSpecialRecord.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbSpecialRecordStyle});
            this.dtgSpecialRecord.CurrentCellChanged += new System.EventHandler(this.dtgSpecialRecord_CurrentCellChanged);
            this.dtgSpecialRecord.Leave += new System.EventHandler(this.dtgSpecialRecord_Leave);
            // 
            // dtbSpecialRecordStyle
            // 
            this.dtbSpecialRecordStyle.AllowSorting = false;
            this.dtbSpecialRecordStyle.DataGrid = this.dtgSpecialRecord;
            this.dtbSpecialRecordStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmCheckPlaceSpecial,
            this.dcmPhotoSeq,
            this.dcmTimeOfAfterInject,
            this.dcmRemark,
            this.dcmPhotoIDSpecial,
            this.dcmOperatorIDSpecial,
            this.dcmOperator});
            this.dtbSpecialRecordStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbSpecialRecordStyle.MappingName = "dtbSpecialRecord";
            // 
            // dcmCheckPlaceSpecial
            // 
            this.dcmCheckPlaceSpecial.Format = "";
            this.dcmCheckPlaceSpecial.FormatInfo = null;
            this.dcmCheckPlaceSpecial.HeaderText = "检查部位";
            this.dcmCheckPlaceSpecial.MappingName = "检查部位";
            this.dcmCheckPlaceSpecial.NullText = "";
            this.dcmCheckPlaceSpecial.Width = 75;
            // 
            // dcmPhotoSeq
            // 
            this.dcmPhotoSeq.Format = "";
            this.dcmPhotoSeq.FormatInfo = null;
            this.dcmPhotoSeq.HeaderText = "照片次序";
            this.dcmPhotoSeq.MappingName = "照片次序";
            this.dcmPhotoSeq.NullText = "";
            this.dcmPhotoSeq.Width = 75;
            // 
            // dcmTimeOfAfterInject
            // 
            this.dcmTimeOfAfterInject.Format = "";
            this.dcmTimeOfAfterInject.FormatInfo = null;
            this.dcmTimeOfAfterInject.HeaderText = "注射药后照片时间";
            this.dcmTimeOfAfterInject.MappingName = "注射药后早片时间";
            this.dcmTimeOfAfterInject.NullText = "";
            this.dcmTimeOfAfterInject.Width = 75;
            // 
            // dcmRemark
            // 
            this.dcmRemark.Format = "";
            this.dcmRemark.FormatInfo = null;
            this.dcmRemark.HeaderText = "附记";
            this.dcmRemark.MappingName = "附记";
            this.dcmRemark.NullText = "";
            this.dcmRemark.Width = 75;
            // 
            // dcmPhotoIDSpecial
            // 
            this.dcmPhotoIDSpecial.Format = "";
            this.dcmPhotoIDSpecial.FormatInfo = null;
            this.dcmPhotoIDSpecial.HeaderText = "照片ID";
            this.dcmPhotoIDSpecial.MappingName = "照片ID";
            this.dcmPhotoIDSpecial.NullText = "";
            this.dcmPhotoIDSpecial.Width = 0;
            // 
            // dcmOperatorIDSpecial
            // 
            this.dcmOperatorIDSpecial.Format = "";
            this.dcmOperatorIDSpecial.FormatInfo = null;
            this.dcmOperatorIDSpecial.HeaderText = "术者ID";
            this.dcmOperatorIDSpecial.MappingName = "术者ID";
            this.dcmOperatorIDSpecial.NullText = "";
            this.dcmOperatorIDSpecial.Width = 150;
            // 
            // dcmOperator
            // 
            this.dcmOperator.Format = "";
            this.dcmOperator.FormatInfo = null;
            this.dcmOperator.HeaderText = "术者";
            this.dcmOperator.MappingName = "术者";
            this.dcmOperator.NullText = "";
            this.dcmOperator.ReadOnly = true;
            this.dcmOperator.Width = 80;
            // 
            // dtgOperator
            // 
            this.dtgOperator.AllowSorting = false;
            this.dtgOperator.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dtgOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgOperator.CaptionBackColor = System.Drawing.SystemColors.Desktop;
            this.dtgOperator.CaptionText = "术者";
            this.dtgOperator.DataMember = "";
            this.dtgOperator.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOperator.ForeColor = System.Drawing.Color.White;
            this.dtgOperator.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgOperator.Location = new System.Drawing.Point(16, 4);
            this.dtgOperator.Name = "dtgOperator";
            this.dtgOperator.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOperator.RowHeaderWidth = 20;
            this.dtgOperator.Size = new System.Drawing.Size(28, 24);
            this.dtgOperator.TabIndex = 18;
            this.dtgOperator.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbOperatorStyle});
            this.dtgOperator.CurrentCellChanged += new System.EventHandler(this.dtgOperator_CurrentCellChanged);
            // 
            // dtbOperatorStyle
            // 
            this.dtbOperatorStyle.AllowSorting = false;
            this.dtbOperatorStyle.DataGrid = this.dtgOperator;
            this.dtbOperatorStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmOperatorID,
            this.dcmOperatorName});
            this.dtbOperatorStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbOperatorStyle.MappingName = "dtbOperator";
            // 
            // dcmOperatorID
            // 
            this.dcmOperatorID.Format = "";
            this.dcmOperatorID.FormatInfo = null;
            this.dcmOperatorID.HeaderText = "术者ID";
            this.dcmOperatorID.MappingName = "术者ID";
            this.dcmOperatorID.NullText = "";
            this.dcmOperatorID.Width = 150;
            // 
            // dcmOperatorName
            // 
            this.dcmOperatorName.Format = "";
            this.dcmOperatorName.FormatInfo = null;
            this.dcmOperatorName.HeaderText = "术者签名";
            this.dcmOperatorName.MappingName = "术者签名";
            this.dcmOperatorName.NullText = "";
            this.dcmOperatorName.ReadOnly = true;
            this.dcmOperatorName.Width = 80;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "照片ID";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // lsvLike
            // 
            this.lsvLike.BackColor = System.Drawing.Color.White;
            this.lsvLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvLike.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeID,
            this.clmEmployeeName});
            this.lsvLike.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvLike.FullRowSelect = true;
            this.lsvLike.GridLines = true;
            this.lsvLike.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvLike.Location = new System.Drawing.Point(24, 0);
            this.lsvLike.Name = "lsvLike";
            this.lsvLike.Size = new System.Drawing.Size(20, 32);
            this.lsvLike.TabIndex = 30036;
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
            this.clmEmployeeName.Width = 160;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "术者ID";
            this.dataGridTextBoxColumn2.MappingName = "术者ID";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgOperator);
            this.panel1.Controls.Add(this.lsvLike);
            this.panel1.Controls.Add(this.dtgCommonRecord);
            this.panel1.Controls.Add(this.dtgSpecialRecord);
            this.panel1.Location = new System.Drawing.Point(456, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 36);
            this.panel1.TabIndex = 10000091;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNotHavePhoto);
            this.panel2.Controls.Add(this.txtHavePhoto);
            this.panel2.Controls.Add(this.txtHavePhotoOut);
            this.panel2.Controls.Add(this.txtPhoto);
            this.panel2.Controls.Add(this.txtClairvoyance);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.ctlBorderTextBox1);
            this.panel2.Location = new System.Drawing.Point(280, 576);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 32);
            this.panel2.TabIndex = 10000092;
            this.panel2.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(95, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 5);
            this.label7.TabIndex = 30015;
            this.label7.Text = "照片:";
            // 
            // ctlBorderTextBox1
            // 
            this.ctlBorderTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.ctlBorderTextBox1.BorderColor = System.Drawing.Color.White;
            this.ctlBorderTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlBorderTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlBorderTextBox1.ForeColor = System.Drawing.Color.White;
            this.ctlBorderTextBox1.Location = new System.Drawing.Point(-20, 8);
            this.ctlBorderTextBox1.Name = "ctlBorderTextBox1";
            this.ctlBorderTextBox1.Size = new System.Drawing.Size(100, 26);
            this.ctlBorderTextBox1.TabIndex = 1010;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(8, 592);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(196, 14);
            this.label18.TabIndex = 10000093;
            this.label18.Text = "检查部位:(请注明左右或双侧)";
            // 
            // pnlCheckBoxs
            // 
            this.pnlCheckBoxs.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlCheckBoxs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckBoxs.Controls.Add(this.txtOtherCheckInfo);
            this.pnlCheckBoxs.Controls.Add(this.label24);
            this.pnlCheckBoxs.Controls.Add(this.label23);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart61);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart58);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart60);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart59);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart57);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart54);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart56);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart55);
            this.pnlCheckBoxs.Controls.Add(this.label22);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart53);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart50);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart52);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart51);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart49);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart48);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart45);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart47);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart46);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart42);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart44);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart43);
            this.pnlCheckBoxs.Controls.Add(this.label21);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart41);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart38);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart40);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart39);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart37);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart36);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart33);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart35);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart34);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart32);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart31);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart28);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart30);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart29);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart27);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart26);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart23);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart25);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart24);
            this.pnlCheckBoxs.Controls.Add(this.label20);
            this.pnlCheckBoxs.Controls.Add(this.label19);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart22);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart21);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart20);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart19);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart16);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart18);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart17);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart15);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart14);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart11);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart13);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart12);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart10);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart09);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart06);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart08);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart07);
            this.pnlCheckBoxs.Controls.Add(this.lblDoctor);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart04);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart02);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart05);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart01);
            this.pnlCheckBoxs.Controls.Add(this.m_chkCheckPart03);
            this.pnlCheckBoxs.Location = new System.Drawing.Point(12, 0);
            this.pnlCheckBoxs.Name = "pnlCheckBoxs";
            this.pnlCheckBoxs.Size = new System.Drawing.Size(771, 440);
            this.pnlCheckBoxs.TabIndex = 10000094;
            // 
            // txtOtherCheckInfo
            // 
            this.txtOtherCheckInfo.BackColor = System.Drawing.Color.White;
            this.txtOtherCheckInfo.BorderColor = System.Drawing.Color.Transparent;
            this.txtOtherCheckInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOtherCheckInfo.ForeColor = System.Drawing.Color.Black;
            this.txtOtherCheckInfo.Location = new System.Drawing.Point(384, 332);
            this.txtOtherCheckInfo.MaxLength = 100;
            this.txtOtherCheckInfo.Multiline = true;
            this.txtOtherCheckInfo.Name = "txtOtherCheckInfo";
            this.txtOtherCheckInfo.Size = new System.Drawing.Size(344, 104);
            this.txtOtherCheckInfo.TabIndex = 10000227;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(388, 308);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(287, 14);
            this.label24.TabIndex = 10000233;
            this.label24.Text = "请注明照片部位及体位并到放射科登记室定价";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(388, 288);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 14);
            this.label23.TabIndex = 10000232;
            this.label23.Text = "其它检查：";
            // 
            // m_chkCheckPart61
            // 
            this.m_chkCheckPart61.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart61.Location = new System.Drawing.Point(520, 265);
            this.m_chkCheckPart61.Name = "m_chkCheckPart61";
            this.m_chkCheckPart61.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart61.TabIndex = 10000226;
            this.m_chkCheckPart61.Tag = "61";
            this.m_chkCheckPart61.Text = "61. 内窥镜下胰胆管造影";
            // 
            // m_chkCheckPart58
            // 
            this.m_chkCheckPart58.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart58.Location = new System.Drawing.Point(520, 199);
            this.m_chkCheckPart58.Name = "m_chkCheckPart58";
            this.m_chkCheckPart58.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart58.TabIndex = 10000223;
            this.m_chkCheckPart58.Tag = "58";
            this.m_chkCheckPart58.Text = "58. 瘘管造影";
            // 
            // m_chkCheckPart60
            // 
            this.m_chkCheckPart60.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart60.Location = new System.Drawing.Point(520, 243);
            this.m_chkCheckPart60.Name = "m_chkCheckPart60";
            this.m_chkCheckPart60.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart60.TabIndex = 10000225;
            this.m_chkCheckPart60.Tag = "60";
            this.m_chkCheckPart60.Text = "60. T管造影";
            // 
            // m_chkCheckPart59
            // 
            this.m_chkCheckPart59.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart59.Location = new System.Drawing.Point(520, 221);
            this.m_chkCheckPart59.Name = "m_chkCheckPart59";
            this.m_chkCheckPart59.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart59.TabIndex = 10000224;
            this.m_chkCheckPart59.Tag = "59";
            this.m_chkCheckPart59.Text = "59. 脊髓碘造影";
            // 
            // m_chkCheckPart57
            // 
            this.m_chkCheckPart57.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart57.Location = new System.Drawing.Point(520, 177);
            this.m_chkCheckPart57.Name = "m_chkCheckPart57";
            this.m_chkCheckPart57.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart57.TabIndex = 10000222;
            this.m_chkCheckPart57.Tag = "57";
            this.m_chkCheckPart57.Text = "57. 经皮肾穿刺术";
            // 
            // m_chkCheckPart54
            // 
            this.m_chkCheckPart54.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart54.Location = new System.Drawing.Point(520, 111);
            this.m_chkCheckPart54.Name = "m_chkCheckPart54";
            this.m_chkCheckPart54.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart54.TabIndex = 10000219;
            this.m_chkCheckPart54.Tag = "54";
            this.m_chkCheckPart54.Text = "54. 尿道造影";
            // 
            // m_chkCheckPart56
            // 
            this.m_chkCheckPart56.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart56.Location = new System.Drawing.Point(520, 155);
            this.m_chkCheckPart56.Name = "m_chkCheckPart56";
            this.m_chkCheckPart56.Size = new System.Drawing.Size(220, 22);
            this.m_chkCheckPart56.TabIndex = 10000221;
            this.m_chkCheckPart56.Tag = "56";
            this.m_chkCheckPart56.Text = "56. 经皮肝穿胆道造影术(PTC)";
            // 
            // m_chkCheckPart55
            // 
            this.m_chkCheckPart55.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart55.Location = new System.Drawing.Point(520, 133);
            this.m_chkCheckPart55.Name = "m_chkCheckPart55";
            this.m_chkCheckPart55.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart55.TabIndex = 10000220;
            this.m_chkCheckPart55.Tag = "55";
            this.m_chkCheckPart55.Text = "55. 食道异物吞钡透视";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(520, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 14);
            this.label22.TabIndex = 10000231;
            this.label22.Text = "特殊检查项目：";
            // 
            // m_chkCheckPart53
            // 
            this.m_chkCheckPart53.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart53.Location = new System.Drawing.Point(520, 89);
            this.m_chkCheckPart53.Name = "m_chkCheckPart53";
            this.m_chkCheckPart53.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart53.TabIndex = 10000218;
            this.m_chkCheckPart53.Tag = "53";
            this.m_chkCheckPart53.Text = "53. 膀胱造影";
            // 
            // m_chkCheckPart50
            // 
            this.m_chkCheckPart50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart50.Location = new System.Drawing.Point(520, 24);
            this.m_chkCheckPart50.Name = "m_chkCheckPart50";
            this.m_chkCheckPart50.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart50.TabIndex = 10000215;
            this.m_chkCheckPart50.Tag = "50";
            this.m_chkCheckPart50.Text = "50. 上消化道钡餐造影";
            // 
            // m_chkCheckPart52
            // 
            this.m_chkCheckPart52.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart52.Location = new System.Drawing.Point(520, 67);
            this.m_chkCheckPart52.Name = "m_chkCheckPart52";
            this.m_chkCheckPart52.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart52.TabIndex = 10000217;
            this.m_chkCheckPart52.Tag = "52";
            this.m_chkCheckPart52.Text = "52. 静脉肾盂造影";
            // 
            // m_chkCheckPart51
            // 
            this.m_chkCheckPart51.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart51.Location = new System.Drawing.Point(520, 45);
            this.m_chkCheckPart51.Name = "m_chkCheckPart51";
            this.m_chkCheckPart51.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart51.TabIndex = 10000216;
            this.m_chkCheckPart51.Tag = "51";
            this.m_chkCheckPart51.Text = "51. 结肠气钡双重造影";
            // 
            // m_chkCheckPart49
            // 
            this.m_chkCheckPart49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart49.Location = new System.Drawing.Point(376, 265);
            this.m_chkCheckPart49.Name = "m_chkCheckPart49";
            this.m_chkCheckPart49.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart49.TabIndex = 10000214;
            this.m_chkCheckPart49.Tag = "49";
            this.m_chkCheckPart49.Text = "49. 颧骨(弓)照片";
            // 
            // m_chkCheckPart48
            // 
            this.m_chkCheckPart48.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart48.Location = new System.Drawing.Point(376, 243);
            this.m_chkCheckPart48.Name = "m_chkCheckPart48";
            this.m_chkCheckPart48.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart48.TabIndex = 10000213;
            this.m_chkCheckPart48.Tag = "48";
            this.m_chkCheckPart48.Text = "48. 颅底照片";
            // 
            // m_chkCheckPart45
            // 
            this.m_chkCheckPart45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart45.Location = new System.Drawing.Point(376, 177);
            this.m_chkCheckPart45.Name = "m_chkCheckPart45";
            this.m_chkCheckPart45.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart45.TabIndex = 10000210;
            this.m_chkCheckPart45.Tag = "45";
            this.m_chkCheckPart45.Text = "45. 鼻骨侧位";
            // 
            // m_chkCheckPart47
            // 
            this.m_chkCheckPart47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart47.Location = new System.Drawing.Point(376, 221);
            this.m_chkCheckPart47.Name = "m_chkCheckPart47";
            this.m_chkCheckPart47.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart47.TabIndex = 10000212;
            this.m_chkCheckPart47.Tag = "47";
            this.m_chkCheckPart47.Text = "47. 下颌骨照片";
            // 
            // m_chkCheckPart46
            // 
            this.m_chkCheckPart46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart46.Location = new System.Drawing.Point(376, 199);
            this.m_chkCheckPart46.Name = "m_chkCheckPart46";
            this.m_chkCheckPart46.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart46.TabIndex = 10000211;
            this.m_chkCheckPart46.Tag = "46";
            this.m_chkCheckPart46.Text = "46. 颞颌关节";
            // 
            // m_chkCheckPart42
            // 
            this.m_chkCheckPart42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart42.Location = new System.Drawing.Point(376, 111);
            this.m_chkCheckPart42.Name = "m_chkCheckPart42";
            this.m_chkCheckPart42.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart42.TabIndex = 10000207;
            this.m_chkCheckPart42.Tag = "42";
            this.m_chkCheckPart42.Text = "42. 蝶鞍照片";
            // 
            // m_chkCheckPart44
            // 
            this.m_chkCheckPart44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart44.Location = new System.Drawing.Point(376, 155);
            this.m_chkCheckPart44.Name = "m_chkCheckPart44";
            this.m_chkCheckPart44.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart44.TabIndex = 10000209;
            this.m_chkCheckPart44.Tag = "44";
            this.m_chkCheckPart44.Text = "44. 视神经孔照片";
            // 
            // m_chkCheckPart43
            // 
            this.m_chkCheckPart43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart43.Location = new System.Drawing.Point(376, 133);
            this.m_chkCheckPart43.Name = "m_chkCheckPart43";
            this.m_chkCheckPart43.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart43.TabIndex = 10000208;
            this.m_chkCheckPart43.Tag = "43";
            this.m_chkCheckPart43.Text = "43. 眼眶照片";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(380, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 14);
            this.label21.TabIndex = 10000230;
            this.label21.Text = "头颅：";
            // 
            // m_chkCheckPart41
            // 
            this.m_chkCheckPart41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart41.Location = new System.Drawing.Point(376, 89);
            this.m_chkCheckPart41.Name = "m_chkCheckPart41";
            this.m_chkCheckPart41.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart41.TabIndex = 10000206;
            this.m_chkCheckPart41.Tag = "41";
            this.m_chkCheckPart41.Text = "41. 乳突照片(双侧)";
            // 
            // m_chkCheckPart38
            // 
            this.m_chkCheckPart38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart38.Location = new System.Drawing.Point(376, 24);
            this.m_chkCheckPart38.Name = "m_chkCheckPart38";
            this.m_chkCheckPart38.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart38.TabIndex = 10000203;
            this.m_chkCheckPart38.Tag = "38";
            this.m_chkCheckPart38.Text = "38. 头颅正侧位";
            // 
            // m_chkCheckPart40
            // 
            this.m_chkCheckPart40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart40.Location = new System.Drawing.Point(376, 67);
            this.m_chkCheckPart40.Name = "m_chkCheckPart40";
            this.m_chkCheckPart40.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart40.TabIndex = 10000205;
            this.m_chkCheckPart40.Tag = "40";
            this.m_chkCheckPart40.Text = "40. 乳突照片(单侧)";
            // 
            // m_chkCheckPart39
            // 
            this.m_chkCheckPart39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart39.Location = new System.Drawing.Point(376, 45);
            this.m_chkCheckPart39.Name = "m_chkCheckPart39";
            this.m_chkCheckPart39.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart39.TabIndex = 10000204;
            this.m_chkCheckPart39.Tag = "39";
            this.m_chkCheckPart39.Text = "39. 全副鼻窦正侧位";
            // 
            // m_chkCheckPart37
            // 
            this.m_chkCheckPart37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart37.Location = new System.Drawing.Point(204, 416);
            this.m_chkCheckPart37.Name = "m_chkCheckPart37";
            this.m_chkCheckPart37.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart37.TabIndex = 10000202;
            this.m_chkCheckPart37.Tag = "37";
            this.m_chkCheckPart37.Text = "37. 桡尺骨正侧位";
            // 
            // m_chkCheckPart36
            // 
            this.m_chkCheckPart36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart36.Location = new System.Drawing.Point(204, 392);
            this.m_chkCheckPart36.Name = "m_chkCheckPart36";
            this.m_chkCheckPart36.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart36.TabIndex = 10000201;
            this.m_chkCheckPart36.Tag = "36";
            this.m_chkCheckPart36.Text = "36. 肘关节正侧位";
            // 
            // m_chkCheckPart33
            // 
            this.m_chkCheckPart33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart33.Location = new System.Drawing.Point(204, 328);
            this.m_chkCheckPart33.Name = "m_chkCheckPart33";
            this.m_chkCheckPart33.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart33.TabIndex = 10000198;
            this.m_chkCheckPart33.Tag = "33";
            this.m_chkCheckPart33.Text = "33. 肩关节正位";
            // 
            // m_chkCheckPart35
            // 
            this.m_chkCheckPart35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart35.Location = new System.Drawing.Point(204, 372);
            this.m_chkCheckPart35.Name = "m_chkCheckPart35";
            this.m_chkCheckPart35.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart35.TabIndex = 10000200;
            this.m_chkCheckPart35.Tag = "35";
            this.m_chkCheckPart35.Text = "35. 肱骨正侧位";
            // 
            // m_chkCheckPart34
            // 
            this.m_chkCheckPart34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart34.Location = new System.Drawing.Point(204, 348);
            this.m_chkCheckPart34.Name = "m_chkCheckPart34";
            this.m_chkCheckPart34.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart34.TabIndex = 10000199;
            this.m_chkCheckPart34.Tag = "34";
            this.m_chkCheckPart34.Text = "34. 肩胛骨正位";
            // 
            // m_chkCheckPart32
            // 
            this.m_chkCheckPart32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart32.Location = new System.Drawing.Point(204, 304);
            this.m_chkCheckPart32.Name = "m_chkCheckPart32";
            this.m_chkCheckPart32.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart32.TabIndex = 10000197;
            this.m_chkCheckPart32.Tag = "32";
            this.m_chkCheckPart32.Text = "32. 全骨盆正蛙位";
            // 
            // m_chkCheckPart31
            // 
            this.m_chkCheckPart31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart31.Location = new System.Drawing.Point(204, 284);
            this.m_chkCheckPart31.Name = "m_chkCheckPart31";
            this.m_chkCheckPart31.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart31.TabIndex = 10000196;
            this.m_chkCheckPart31.Tag = "31";
            this.m_chkCheckPart31.Text = "31. 全骨盆正位";
            // 
            // m_chkCheckPart28
            // 
            this.m_chkCheckPart28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart28.Location = new System.Drawing.Point(204, 221);
            this.m_chkCheckPart28.Name = "m_chkCheckPart28";
            this.m_chkCheckPart28.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart28.TabIndex = 10000193;
            this.m_chkCheckPart28.Tag = "28";
            this.m_chkCheckPart28.Text = "28. 股骨正侧位";
            // 
            // m_chkCheckPart30
            // 
            this.m_chkCheckPart30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart30.Location = new System.Drawing.Point(204, 265);
            this.m_chkCheckPart30.Name = "m_chkCheckPart30";
            this.m_chkCheckPart30.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart30.TabIndex = 10000195;
            this.m_chkCheckPart30.Tag = "30";
            this.m_chkCheckPart30.Text = "30. 髋关节正蛙位(一侧)";
            // 
            // m_chkCheckPart29
            // 
            this.m_chkCheckPart29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart29.Location = new System.Drawing.Point(204, 243);
            this.m_chkCheckPart29.Name = "m_chkCheckPart29";
            this.m_chkCheckPart29.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart29.TabIndex = 10000194;
            this.m_chkCheckPart29.Tag = "29";
            this.m_chkCheckPart29.Text = "29. 髋关节正位(一侧)";
            // 
            // m_chkCheckPart27
            // 
            this.m_chkCheckPart27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart27.Location = new System.Drawing.Point(204, 199);
            this.m_chkCheckPart27.Name = "m_chkCheckPart27";
            this.m_chkCheckPart27.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart27.TabIndex = 10000192;
            this.m_chkCheckPart27.Tag = "27";
            this.m_chkCheckPart27.Text = "27. 胫腓骨正侧位";
            // 
            // m_chkCheckPart26
            // 
            this.m_chkCheckPart26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart26.Location = new System.Drawing.Point(204, 177);
            this.m_chkCheckPart26.Name = "m_chkCheckPart26";
            this.m_chkCheckPart26.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart26.TabIndex = 10000191;
            this.m_chkCheckPart26.Tag = "26";
            this.m_chkCheckPart26.Text = "26. 双膝关节正侧位";
            // 
            // m_chkCheckPart23
            // 
            this.m_chkCheckPart23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart23.Location = new System.Drawing.Point(204, 111);
            this.m_chkCheckPart23.Name = "m_chkCheckPart23";
            this.m_chkCheckPart23.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart23.TabIndex = 10000188;
            this.m_chkCheckPart23.Tag = "23";
            this.m_chkCheckPart23.Text = "23. 腕关节正侧位";
            // 
            // m_chkCheckPart25
            // 
            this.m_chkCheckPart25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart25.Location = new System.Drawing.Point(204, 155);
            this.m_chkCheckPart25.Name = "m_chkCheckPart25";
            this.m_chkCheckPart25.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart25.TabIndex = 10000190;
            this.m_chkCheckPart25.Tag = "25";
            this.m_chkCheckPart25.Text = "25. 膝关节正侧位";
            // 
            // m_chkCheckPart24
            // 
            this.m_chkCheckPart24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart24.Location = new System.Drawing.Point(204, 133);
            this.m_chkCheckPart24.Name = "m_chkCheckPart24";
            this.m_chkCheckPart24.Size = new System.Drawing.Size(180, 22);
            this.m_chkCheckPart24.TabIndex = 10000189;
            this.m_chkCheckPart24.Tag = "24";
            this.m_chkCheckPart24.Text = "24. 踝关节正侧位";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(240, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 14);
            this.label20.TabIndex = 10000229;
            this.label20.Text = "四肢：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(52, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 14);
            this.label19.TabIndex = 10000228;
            this.label19.Text = "躯干部：";
            // 
            // m_chkCheckPart22
            // 
            this.m_chkCheckPart22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart22.Location = new System.Drawing.Point(204, 89);
            this.m_chkCheckPart22.Name = "m_chkCheckPart22";
            this.m_chkCheckPart22.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart22.TabIndex = 10000187;
            this.m_chkCheckPart22.Tag = "22";
            this.m_chkCheckPart22.Text = "22. 足背正斜位";
            // 
            // m_chkCheckPart21
            // 
            this.m_chkCheckPart21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart21.Location = new System.Drawing.Point(204, 67);
            this.m_chkCheckPart21.Name = "m_chkCheckPart21";
            this.m_chkCheckPart21.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart21.TabIndex = 10000186;
            this.m_chkCheckPart21.Tag = "21";
            this.m_chkCheckPart21.Text = "21. 掌指关节正斜位";
            // 
            // m_chkCheckPart20
            // 
            this.m_chkCheckPart20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart20.Location = new System.Drawing.Point(204, 45);
            this.m_chkCheckPart20.Name = "m_chkCheckPart20";
            this.m_chkCheckPart20.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart20.TabIndex = 10000185;
            this.m_chkCheckPart20.Tag = "20";
            this.m_chkCheckPart20.Text = "20. 脚趾正斜位";
            // 
            // m_chkCheckPart19
            // 
            this.m_chkCheckPart19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart19.Location = new System.Drawing.Point(204, 24);
            this.m_chkCheckPart19.Name = "m_chkCheckPart19";
            this.m_chkCheckPart19.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart19.TabIndex = 10000184;
            this.m_chkCheckPart19.Tag = "19";
            this.m_chkCheckPart19.Text = "19. 手指正斜位";
            // 
            // m_chkCheckPart16
            // 
            this.m_chkCheckPart16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart16.Location = new System.Drawing.Point(16, 353);
            this.m_chkCheckPart16.Name = "m_chkCheckPart16";
            this.m_chkCheckPart16.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart16.TabIndex = 10000181;
            this.m_chkCheckPart16.Tag = "16";
            this.m_chkCheckPart16.Text = "16. 胸骨正位";
            // 
            // m_chkCheckPart18
            // 
            this.m_chkCheckPart18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart18.Location = new System.Drawing.Point(16, 398);
            this.m_chkCheckPart18.Name = "m_chkCheckPart18";
            this.m_chkCheckPart18.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart18.TabIndex = 10000183;
            this.m_chkCheckPart18.Tag = "18";
            this.m_chkCheckPart18.Text = "18. 胸锁关节";
            // 
            // m_chkCheckPart17
            // 
            this.m_chkCheckPart17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart17.Location = new System.Drawing.Point(16, 375);
            this.m_chkCheckPart17.Name = "m_chkCheckPart17";
            this.m_chkCheckPart17.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart17.TabIndex = 10000182;
            this.m_chkCheckPart17.Tag = "17";
            this.m_chkCheckPart17.Text = "17. 胸骨侧位";
            // 
            // m_chkCheckPart15
            // 
            this.m_chkCheckPart15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart15.Location = new System.Drawing.Point(16, 331);
            this.m_chkCheckPart15.Name = "m_chkCheckPart15";
            this.m_chkCheckPart15.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart15.TabIndex = 10000180;
            this.m_chkCheckPart15.Tag = "15";
            this.m_chkCheckPart15.Text = "15. 骶尾椎正侧位";
            // 
            // m_chkCheckPart14
            // 
            this.m_chkCheckPart14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart14.Location = new System.Drawing.Point(16, 309);
            this.m_chkCheckPart14.Name = "m_chkCheckPart14";
            this.m_chkCheckPart14.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart14.TabIndex = 10000179;
            this.m_chkCheckPart14.Tag = "14";
            this.m_chkCheckPart14.Text = "14. 腰骶椎正侧位";
            // 
            // m_chkCheckPart11
            // 
            this.m_chkCheckPart11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart11.Location = new System.Drawing.Point(16, 243);
            this.m_chkCheckPart11.Name = "m_chkCheckPart11";
            this.m_chkCheckPart11.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart11.TabIndex = 10000176;
            this.m_chkCheckPart11.Tag = "11";
            this.m_chkCheckPart11.Text = "11. 胸椎正侧位";
            // 
            // m_chkCheckPart13
            // 
            this.m_chkCheckPart13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart13.Location = new System.Drawing.Point(16, 287);
            this.m_chkCheckPart13.Name = "m_chkCheckPart13";
            this.m_chkCheckPart13.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart13.TabIndex = 10000178;
            this.m_chkCheckPart13.Tag = "13";
            this.m_chkCheckPart13.Text = "13. 腰椎斜位";
            // 
            // m_chkCheckPart12
            // 
            this.m_chkCheckPart12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart12.Location = new System.Drawing.Point(16, 265);
            this.m_chkCheckPart12.Name = "m_chkCheckPart12";
            this.m_chkCheckPart12.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart12.TabIndex = 10000177;
            this.m_chkCheckPart12.Tag = "12";
            this.m_chkCheckPart12.Text = "12. 腰椎正侧位";
            // 
            // m_chkCheckPart10
            // 
            this.m_chkCheckPart10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart10.Location = new System.Drawing.Point(16, 221);
            this.m_chkCheckPart10.Name = "m_chkCheckPart10";
            this.m_chkCheckPart10.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart10.TabIndex = 10000175;
            this.m_chkCheckPart10.Tag = "10";
            this.m_chkCheckPart10.Text = "10. 第一二颈椎开口位";
            // 
            // m_chkCheckPart09
            // 
            this.m_chkCheckPart09.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart09.Location = new System.Drawing.Point(16, 199);
            this.m_chkCheckPart09.Name = "m_chkCheckPart09";
            this.m_chkCheckPart09.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart09.TabIndex = 10000174;
            this.m_chkCheckPart09.Tag = "9";
            this.m_chkCheckPart09.Text = "09. 颈椎正侧斜位";
            // 
            // m_chkCheckPart06
            // 
            this.m_chkCheckPart06.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart06.Location = new System.Drawing.Point(16, 133);
            this.m_chkCheckPart06.Name = "m_chkCheckPart06";
            this.m_chkCheckPart06.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart06.TabIndex = 10000171;
            this.m_chkCheckPart06.Tag = "6";
            this.m_chkCheckPart06.Text = "06. 腹部正侧位";
            // 
            // m_chkCheckPart08
            // 
            this.m_chkCheckPart08.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart08.Location = new System.Drawing.Point(16, 177);
            this.m_chkCheckPart08.Name = "m_chkCheckPart08";
            this.m_chkCheckPart08.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart08.TabIndex = 10000173;
            this.m_chkCheckPart08.Tag = "8";
            this.m_chkCheckPart08.Text = "08. 颈椎正侧位";
            // 
            // m_chkCheckPart07
            // 
            this.m_chkCheckPart07.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart07.Location = new System.Drawing.Point(16, 155);
            this.m_chkCheckPart07.Name = "m_chkCheckPart07";
            this.m_chkCheckPart07.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart07.TabIndex = 10000172;
            this.m_chkCheckPart07.Tag = "7";
            this.m_chkCheckPart07.Text = "07. 颈部侧位";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctor.Location = new System.Drawing.Point(476, 89);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(0, 14);
            this.lblDoctor.TabIndex = 10000227;
            this.lblDoctor.Visible = false;
            // 
            // m_chkCheckPart04
            // 
            this.m_chkCheckPart04.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart04.Location = new System.Drawing.Point(16, 89);
            this.m_chkCheckPart04.Name = "m_chkCheckPart04";
            this.m_chkCheckPart04.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart04.TabIndex = 10000169;
            this.m_chkCheckPart04.Tag = "4";
            this.m_chkCheckPart04.Text = "04. 胸部正侧位(含激光片)";
            // 
            // m_chkCheckPart02
            // 
            this.m_chkCheckPart02.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart02.Location = new System.Drawing.Point(16, 45);
            this.m_chkCheckPart02.Name = "m_chkCheckPart02";
            this.m_chkCheckPart02.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart02.TabIndex = 10000167;
            this.m_chkCheckPart02.Tag = "2";
            this.m_chkCheckPart02.Text = "02. 胸部正侧位";
            // 
            // m_chkCheckPart05
            // 
            this.m_chkCheckPart05.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart05.Location = new System.Drawing.Point(16, 111);
            this.m_chkCheckPart05.Name = "m_chkCheckPart05";
            this.m_chkCheckPart05.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart05.TabIndex = 10000170;
            this.m_chkCheckPart05.Tag = "5";
            this.m_chkCheckPart05.Text = "05. 腹部平片";
            // 
            // m_chkCheckPart01
            // 
            this.m_chkCheckPart01.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart01.Location = new System.Drawing.Point(16, 24);
            this.m_chkCheckPart01.Name = "m_chkCheckPart01";
            this.m_chkCheckPart01.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart01.TabIndex = 10000166;
            this.m_chkCheckPart01.Tag = "1";
            this.m_chkCheckPart01.Text = "01. 胸部正位";
            // 
            // m_chkCheckPart03
            // 
            this.m_chkCheckPart03.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkCheckPart03.Location = new System.Drawing.Point(16, 67);
            this.m_chkCheckPart03.Name = "m_chkCheckPart03";
            this.m_chkCheckPart03.Size = new System.Drawing.Size(196, 22);
            this.m_chkCheckPart03.TabIndex = 10000168;
            this.m_chkCheckPart03.Tag = "3";
            this.m_chkCheckPart03.Text = "03. 胸部正位(含激光片)";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContact.Location = new System.Drawing.Point(8, 448);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(161, 14);
            this.lblContact.TabIndex = 10000237;
            this.lblContact.Text = "受检者住址及联系电话：";
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.BackColor = System.Drawing.Color.White;
            this.txtContactInfo.BorderColor = System.Drawing.Color.Transparent;
            this.txtContactInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContactInfo.ForeColor = System.Drawing.Color.Black;
            this.txtContactInfo.Location = new System.Drawing.Point(172, 444);
            this.txtContactInfo.MaxLength = 50;
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(580, 23);
            this.txtContactInfo.TabIndex = 10000228;
            // 
            // lblXRayNo
            // 
            this.lblXRayNo.AutoSize = true;
            this.lblXRayNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXRayNo.Location = new System.Drawing.Point(404, 87);
            this.lblXRayNo.Name = "lblXRayNo";
            this.lblXRayNo.Size = new System.Drawing.Size(49, 14);
            this.lblXRayNo.TabIndex = 10000096;
            this.lblXRayNo.Text = "X光号:";
            // 
            // lblInsuranceNo
            // 
            this.lblInsuranceNo.AutoSize = true;
            this.lblInsuranceNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInsuranceNo.Location = new System.Drawing.Point(194, 87);
            this.lblInsuranceNo.Name = "lblInsuranceNo";
            this.lblInsuranceNo.Size = new System.Drawing.Size(70, 14);
            this.lblInsuranceNo.TabIndex = 10000098;
            this.lblInsuranceNo.Text = "医保号码:";
            // 
            // txtXRayNo
            // 
            this.txtXRayNo.BackColor = System.Drawing.Color.White;
            this.txtXRayNo.BorderColor = System.Drawing.Color.Transparent;
            this.txtXRayNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXRayNo.ForeColor = System.Drawing.Color.Black;
            this.txtXRayNo.Location = new System.Drawing.Point(460, 83);
            this.txtXRayNo.Name = "txtXRayNo";
            this.txtXRayNo.Size = new System.Drawing.Size(88, 23);
            this.txtXRayNo.TabIndex = 500;
            // 
            // txtInsuranceNo
            // 
            this.txtInsuranceNo.BackColor = System.Drawing.Color.White;
            this.txtInsuranceNo.BorderColor = System.Drawing.Color.Transparent;
            this.txtInsuranceNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInsuranceNo.ForeColor = System.Drawing.Color.Black;
            this.txtInsuranceNo.Location = new System.Drawing.Point(266, 83);
            this.txtInsuranceNo.Name = "txtInsuranceNo";
            this.txtInsuranceNo.Size = new System.Drawing.Size(137, 23);
            this.txtInsuranceNo.TabIndex = 600;
            // 
            // m_lblBlank
            // 
            this.m_lblBlank.BackColor = System.Drawing.Color.Transparent;
            this.m_lblBlank.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBlank.ForeColor = System.Drawing.Color.Black;
            this.m_lblBlank.Location = new System.Drawing.Point(8, 704);
            this.m_lblBlank.Name = "m_lblBlank";
            this.m_lblBlank.Size = new System.Drawing.Size(904, 32);
            this.m_lblBlank.TabIndex = 30037;
            // 
            // m_txtApplicationID
            // 
            this.m_txtApplicationID.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationID.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtApplicationID.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationID.Location = new System.Drawing.Point(622, 82);
            this.m_txtApplicationID.Name = "m_txtApplicationID";
            this.m_txtApplicationID.ReadOnly = true;
            this.m_txtApplicationID.Size = new System.Drawing.Size(84, 23);
            this.m_txtApplicationID.TabIndex = 650;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(550, 86);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 10000096;
            this.label26.Text = "申请单号:";
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(568, 623);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(84, 24);
            this.m_cmdSign.TabIndex = 1019;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "医师签名:";
            // 
            // m_chkNeedRequire
            // 
            this.m_chkNeedRequire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkNeedRequire.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkNeedRequire.Location = new System.Drawing.Point(8, 448);
            this.m_chkNeedRequire.Name = "m_chkNeedRequire";
            this.m_chkNeedRequire.Size = new System.Drawing.Size(108, 24);
            this.m_chkNeedRequire.TabIndex = 10000099;
            this.m_chkNeedRequire.Text = "需要预约答复";
            this.m_chkNeedRequire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.CheckedChanged += new System.EventHandler(this.m_chkNeedRequire_CheckedChanged);
            // 
            // m_txtApplicationComment
            // 
            this.m_txtApplicationComment.AccessibleDescription = "申请检查部位";
            this.m_txtApplicationComment.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationComment.Enabled = false;
            this.m_txtApplicationComment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplicationComment.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationComment.Location = new System.Drawing.Point(124, 448);
            this.m_txtApplicationComment.MaxLength = 150;
            this.m_txtApplicationComment.Multiline = false;
            this.m_txtApplicationComment.Name = "m_txtApplicationComment";
            this.m_txtApplicationComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtApplicationComment.Size = new System.Drawing.Size(628, 22);
            this.m_txtApplicationComment.TabIndex = 10000100;
            this.m_txtApplicationComment.Text = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtCheckAim);
            this.panel3.Controls.Add(this.txtCheckAndResult);
            this.panel3.Controls.Add(this.m_chkNeedRequire);
            this.panel3.Controls.Add(this.m_txtApplicationComment);
            this.panel3.Controls.Add(this.txtClinicalDignose);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtHistory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 475);
            this.panel3.TabIndex = 10000101;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblContact);
            this.panel4.Controls.Add(this.txtContactInfo);
            this.panel4.Controls.Add(this.pnlCheckBoxs);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(796, 475);
            this.panel4.TabIndex = 10000234;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.ImageList = this.imageList1;
            this.tabControl2.Location = new System.Drawing.Point(5, 120);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 1;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(796, 501);
            this.tabControl2.TabIndex = 10000102;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(796, 475);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "诊断";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(796, 475);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "检查部位";
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(657, 624);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 10000103;
            // 
            // frmXRayCheckOrder
            // 
            this.AccessibleDescription = "X 线 检 查 申 请 单";
            this.ClientSize = new System.Drawing.Size(803, 658);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_lblBlank);
            this.Controls.Add(this.lblSickRoom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCheckPlace);
            this.Controls.Add(this.label18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXRayCheckOrder";
            this.Text = "X 线 检 查 申 请 单";
            this.Load += new System.EventHandler(this.frmXRayCheckOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtCheckPlace, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblSickRoom, 0);
            this.Controls.SetChildIndex(this.m_lblBlank, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommonRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperator)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCheckBoxs.ResumeLayout(false);
            this.pnlCheckBoxs.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Control Event
		private void frmXRayCheckOrder_Load(object sender, System.EventArgs e)
		{
			this.m_lsvInPatientID.Visible =false;
			TreeNode trnNode = new TreeNode("记录日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			lblDoctor.Text = MDIParent.strOperatorName;
			trvTime.Focus();

			this.dtpApplicateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            //this.dtpApplicateDate.m_mthResetSize();
		}

		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && 
						ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName" && 
						ctlText.Name != "m_txtApplicationID")
						ctlText.Enabled=false;
					//			if(typeName == "ctlTimePicker") 
					//			((ctlTimePicker)ctlText).Enabled=false;
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
					//	if(typeName == "ctlTimePicker") 
					//		((ctlTimePicker)ctlText).Enabled=true;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = false;
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
				m_objXRayCheckOrder=null;
				this.dtpApplicateDate.Enabled=true;
				m_mthReadOnly(false);

				if(m_strInPatientID != null && m_strInPatientDate != null)
				{
					m_mthSetDefaultValue(new clsPatient(m_strInPatientID) );
				}
				
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			}
			else
			{
				this.dtpApplicateDate.Enabled=false;
				
				m_strCreateDate = ((DateTime)trvTime.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss");
				
				m_objXRayCheckOrder = m_objDomain.m_objGetXRayCheckOrder(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				m_objXRayCommonRecord = m_objDomain.m_objGetCommonRecordArr(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				m_objXRaySpecialRecord = m_objDomain.m_objGetSpecialRecordArr(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				m_objXRayOperatorID = m_objDomain.m_objGetOperatorIDArr(m_strInPatientID,m_strInPatientDate,m_strCreateDate);

				m_mthDisplay();
				m_mthDisplayCommonRecord();
				m_mthDisplaySpecialRecord();
				m_mthDisplayOperator();
				if(m_objXRayCheckOrder!=null)
				{
					m_mthReadOnly(clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim()!=m_objXRayCheckOrder.m_strCreateUserID.Trim());
				}
				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}

			m_mthAddFormStatusForClosingSave();
		}

		//		private ArrayList m_arlOperatorFirst;
		//		private ArrayList m_arlOperatorSecond;
		private void lsvLike_DoubleClick(object sender, System.EventArgs e)
		{
			if(lsvLike.SelectedItems.Count>0)
			{
				ListViewItem lsvItem =lsvLike.SelectedItems[0];
						
				//				if(!m_blnCheckEmployeeSign(lsvItem.SubItems[0].Text,lsvItem.SubItems[1].Text))
				//					return;
						
				object[] objRow = new object[2];
				if(m_strSenderName == "Special")
				{
					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					for(int i=0;i<dtbSpecialRecord.Rows.Count;i++)
					{
						if(dtbSpecialRecord.Rows[i][6].ToString()==objRow[0].ToString())
						{
							clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
							
							dtgSpecialRecord.Focus();
							dtbSpecialRecord.Rows[m_intRowNumber][0] = ""; //消除对应行中名称的显示							
							return ;
						}
					}

					dtbSpecialRecord.Rows[m_intRowNumber][0] = objRow[1];   
					dtbSpecialRecord.Rows[m_intRowNumber][6] = objRow[0]; 
				}
				else if(m_strSenderName == "Operator")
				{
					objRow[0]=lsvItem.SubItems[0].Text;	
					objRow[1]=lsvItem.SubItems[1].Text;	

					for(int i=0;i<dtbOperator.Rows.Count;i++)
					{
						if(dtbOperator.Rows[i][0].ToString()==objRow[0].ToString())
						{
							clsPublicFunction.ShowInformationMessageBox("请检查输入的员工号，不能重复！");
							dtgOperator.Focus();
							dtbOperator.Rows[m_intRowNumber][1] = ""; //消除对应行中名称的显示
							return ;
						}
					}

					dtbOperator.Rows[m_intRowNumber][1] = objRow[1];   
					dtbOperator.Rows[m_intRowNumber][0] = objRow[0]; 
				}
			}
			m_lblBlank.Focus();
		}

		private void dtgOperator_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(dtbSpecialRecord.Rows.Count > 0)
			{
				dcmOperatorName.ReadOnly = false;
			}
			else
			{
				dcmOperatorName.ReadOnly = true;
			}

			m_strSenderName = "Operator";

			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;

			lsvLike.Items.Clear();
		}

		private void dtgSpecialRecord_CurrentCellChanged(object sender, System.EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Special";
			lsvLike.Items.Clear();

		}

		private void dtgCommonRecord_Leave(object sender, System.EventArgs e)
		{
			if(dtbCommonRecord.Rows.Count == 0)
				return;

			for(int i = 0; i < dtbCommonRecord.Rows.Count; i ++)
			{
				if(dtbCommonRecord.Rows[i][9].ToString() == "")
					dtbCommonRecord.Rows[i][9] = (i+1).ToString();
			}
		}

		private void dtgSpecialRecord_Leave(object sender, System.EventArgs e)
		{
			if(dtbSpecialRecord.Rows.Count == 0)
				return;

			for(int i = 0; i < dtbSpecialRecord.Rows.Count; i++)
			{
				if(dtbSpecialRecord.Rows[i][5].ToString() == "")
					dtbSpecialRecord.Rows[i][5] = (i+1).ToString();
			}
		}

		#endregion

		#region Tools
		private void m_mthSpecial_GotFocus(object sender, EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Special";

			lsvLike.Items.Clear();
		}

		private void m_mthOperator_GotFocus(object sender, EventArgs e)
		{
			m_intColumnNumber = ((DataGrid)sender).CurrentCell.ColumnNumber;
			m_intRowNumber = ((DataGrid)sender).CurrentCell.RowNumber;
			m_strSenderName = "Operator";

			lsvLike.Items.Clear();
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
				m_mthSetDefaultValue(m_objSelectedPatient );
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
			//清除RichTextBox 的内容
			foreach(Control ctlControl in this.Controls )
			{
				string typeName = ctlControl.GetType().FullName;
                if (typeName == "com.digitalwave.controls.ctlRichTextBox")
				{
                    ((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_mthClearText();
				}
			}
			foreach(Control ctlControl in this.pnlCheckBoxs.Controls)
			{
				string typeName = ctlControl.GetType().Name;
				if(typeName=="CheckBox")
				{
					 ((CheckBox)ctlControl).Checked=false;
				}
			}
			m_mthClear_Recursive(this.tabControl2,null);
			m_strCreateDate = "";

			dtgCommonRecord.CurrentRowIndex = 0;
			dtbCommonRecord.Rows.Clear();

			dtgSpecialRecord.CurrentRowIndex = 0;
			dtbSpecialRecord.Rows.Clear();

			dtgOperator.CurrentRowIndex = 0;
			dtbOperator.Rows.Clear();

			//			m_arlOperatorFirst.Clear();
			//			m_arlOperatorSecond.Clear();

			dtpApplicateDate.Value = DateTime.Now;

			dtpApplicateDate.Enabled=true;
			m_mthReadOnly(false);
			this.txtCharge.Text="0.00";
			this.txtAdditionCharge.Text ="0.00";

			m_txtApplicationID.Text = "";

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
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

				if(m_strSenderName == "Special")
				{
					if(m_objGridListView0==null||m_objGridListView0.strGetCurrentText()==null||m_objGridListView0.strGetCurrentText()=="")return;				
					lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_objGridListView0.strGetCurrentText(),ref blnSuccess);					

				}

				if(m_strSenderName == "Operator")
				{
					if(m_objGridListView1==null||m_objGridListView1.strGetCurrentText()==null||m_objGridListView1.strGetCurrentText()=="")return;				
					lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_objGridListView1.strGetCurrentText(),ref blnSuccess);					

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
				return dtpApplicateDate.Enabled;//(m_strCreateDate == ""|| m_strCreateDate == null);
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

        
		protected override void m_mthSetPatientBaseInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_blnCanSearch = false;

			m_objSelectedPatient = p_objSelectedPatient;

			m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
            m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

            //txtInPatientID.Text = p_objSelectedPatient.m_StrInPatientID;
            //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

			txtContactInfo.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress+ "  " +
								p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;

			m_txtPatientName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
			m_blnCanAreaSelectIndexChangeEventTakePlace = false;
			m_cboArea.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
			m_blnCanAreaSelectIndexChangeEventTakePlace = true;
			m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;

//			m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
//			m_cboDept.SelectedIndex=0;
//			clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
//			m_cboArea.AddItem(objInPatientArea);
//			m_cboArea.SelectedIndex=0;
			//使用新表 modified by tfzhang at 2005年10月17日 16:02:29
			//清空
			m_cboDept.ClearItem();
			m_cboArea.ClearItem();
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

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
            //m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID ,m_strInPatientDate);			
		}

		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox(true);
		}

		protected override long m_lngSubModify()
		{
			return m_lngSaveWithMessageBox(false);
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
				m_rpdOrderRept.Load(m_strTemplatePath + "rptXRayCheckOrderReport.rpt");
			}

			m_mthAddNewDataForXRayReportSetDataSet(m_dtsRept);

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
			if(m_objXRayCheckOrder==null || m_objSelectedPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objXRayCheckOrder.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objXRayCheckOrder.m_strInPatientID,m_objXRayCheckOrder.m_strInPatientDate,m_objXRayCheckOrder.m_strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objXRayCheckOrder.m_strCreateDate)
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

		#region Public Function
		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Delete()
		{
			m_lngDelete ();
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

		#region Save
		private long m_lngSaveWithMessageBox(bool p_bnlIsNew)
		{
			if(m_strCreateDate!="")
			{
				//				if(!m_bolShowIfModify()) return -1;
				if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objXRayCheckOrder.m_strCreateUserID.Trim())
				{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
					clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
					return -1;
				}
			}

			long lngRes=m_lngSaveWithoutMessageBox(p_bnlIsNew);
            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功！");		
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


		//将从数据库读取过来的由0，1组成的字符串赋给相应的CheckBox控件
		private long m_lngSetControlValFromCheckPartSelectionStr(string p_strCheckPartSelection)
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
					
					foreach(Control objCheckBox in this.pnlCheckBoxs.Controls )
					{
						if (objCheckBox.GetType()==typeof(CheckBox))
						{
							bool mValue=false;
							if(m_CheckPartSelection[int.Parse((string)(objCheckBox.Tag))-1]=='1')
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

		private string m_strForComboBox="检查部位(";
		private long m_lngGetCheckPartSelectionStrFromControl(int p_lngLength,out string[] p_strCheckPartSelection)
		{
			try
			{

				string[] m_strCheckPartSelection=new string[p_lngLength];
				for(int i=0;i<CHECKBOXS;i++)
					m_strCheckPartSelection[i]="0";
				
//				Control objCheckBox;
				foreach(Control objCheckBox in this.pnlCheckBoxs.Controls)
				{
					if(objCheckBox.GetType()==typeof(CheckBox))
					{
						string mValue="0";
						if(((CheckBox)(objCheckBox)).Checked)
						{
							mValue="1";			    
							m_strCheckPartSelection[int.Parse((string)(objCheckBox.Tag))-1]=mValue;
							m_strForComboBox+=((CheckBox)objCheckBox).Text+"、";
						}
						
												
					}
				}
				m_strForComboBox+=")";
				p_strCheckPartSelection=m_strCheckPartSelection;
				return 1;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
				p_strCheckPartSelection=new string[CHECKBOXS];
				return 0;
			}
			
		}

		private long m_lngSaveWithoutMessageBox(bool p_bnlIsNew)
		{
			if(m_strInPatientID == null || m_strInPatientID == "")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，请输入病人住院编号！");
				return 0;
			}

            if (m_txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请医师签名");
				return 0;
            }
			string strCurrentDate = new clsPublicDomain().m_strGetServerTime();//.ToString("yyyy-MM-dd HH:mm:ss");
			//            //dick 2003-3-27
			//			if(m_blnCheckDuplicate(dtbOperator))
			//			{
			//				clsPublicFunction.ShowInformationMessageBox("请检查输入的操作者，不能重复！");
			//				return 0;
			//			}

			//主表

			string[] m_CheckPartSelection;
			long mReturn=-1;

			mReturn=this.m_lngGetCheckPartSelectionStrFromControl(CHECKBOXS,out m_CheckPartSelection);
			if (m_objXRayCheckOrder==null)
				m_objXRayCheckOrder = new clsXRayCheckOrder();

			m_objXRayCheckOrder.m_strHistory = txtHistory.Text;
			m_objXRayCheckOrder.m_strClinicalCheckAndResult = txtCheckAndResult.Text;
			m_objXRayCheckOrder.m_strClinicalDignose = txtClinicalDignose.Text;
			m_objXRayCheckOrder.m_strCheckAim = txtCheckAim.Text;
			m_objXRayCheckOrder.m_strCheckPlace = txtCheckPlace.Text;
			m_objXRayCheckOrder.m_strClairvoyance = txtClairvoyance.Text;
			m_objXRayCheckOrder.m_strPhoto = txtPhoto.Text;
			m_objXRayCheckOrder.m_strNotHaveOldPhoto = txtNotHavePhoto.Text;
			m_objXRayCheckOrder.m_strHaveOldPhoto = txtHavePhoto.Text;
			m_objXRayCheckOrder.m_strHaveOldPhotoOut = txtHavePhotoOut.Text;
			m_objXRayCheckOrder.m_strCharge = txtCharge.Text;
			m_objXRayCheckOrder.m_strAdditionCharge = txtAdditionCharge.Text;
			m_objXRayCheckOrder.m_strCheckPartSelection=string.Join("",m_CheckPartSelection);

            m_objXRayCheckOrder.m_strInPatientID = m_strInPatientID;
			m_objXRayCheckOrder.m_strInPatientDate = m_strInPatientDate;

			m_objXRayCheckOrder.m_strXRayNo = this.txtXRayNo.Text.Trim();
			m_objXRayCheckOrder.m_strInsuranceNo = this.txtInsuranceNo.Text.Trim();
			m_objXRayCheckOrder.m_strOtherCheckInfo = this.txtOtherCheckInfo.Text.Trim();
			m_objXRayCheckOrder.m_strContactInfo= this.txtContactInfo.Text.Trim();

			m_objXRayCheckOrder.m_strCreateDate = (m_strCreateDate == "") ? dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
			m_objXRayCheckOrder.m_strModifyDate = strCurrentDate;
			m_objXRayCheckOrder.m_strStatus = "0";
            m_objXRayCheckOrder.m_strCreateUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
			m_objXRayCheckOrder.m_strIfConfirm = "1";

			//// 将X光数据记录入影像表
			///
			//构建ApplicationInfo
			string strApplicationInfo="";
			if(this.txtHistory.Text.Trim()!="")
				strApplicationInfo="病史:"+this.txtHistory.Text.Trim()+","+"\n\r";
			if(this.txtCheckAndResult.Text.Trim()!="")
				strApplicationInfo+="临床检查化验结果:"+this.txtCheckAndResult.Text.Trim()+","+"\n\r";
			if(this.txtOtherCheckInfo.Text.Trim()!="")
				strApplicationInfo+="其他检查:"+this.txtOtherCheckInfo.Text.Trim()+","+"\n\r";
			
			strApplicationInfo+=m_strForComboBox;

			ImageRequest m_objImageRequest=new ImageRequest();
			m_objImageRequest.m_strApplicationInfo=strApplicationInfo;
			m_objImageRequest.m_strApplicationType="0";		//X光
            if (m_ObjCurrentBed != null)
            {
                m_objImageRequest.m_strBedName = m_ObjCurrentBed.m_strCODE_CHR;
            }
            else
            {
                m_objImageRequest.m_strBedName = string.Empty;
            }
			m_objImageRequest.m_strCheckPart=m_objXRayCheckOrder.m_strCheckPlace;;	//检查部位
			m_objImageRequest.m_strCheckPurpose=m_objXRayCheckOrder.m_strCheckAim ;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                m_objImageRequest.m_strDeptID = m_ObjCurrentEmrPatientSession.m_strAreaId;
                m_objImageRequest.m_strDeptName = m_ObjCurrentEmrPatientSession.m_strAreaName;
            }
			
			m_objImageRequest.m_strDiagnose=m_objXRayCheckOrder.m_strClinicalDignose;
			m_objImageRequest.m_strDoctorID =m_objXRayCheckOrder.m_strCreateUserID;
			m_objImageRequest.m_strDoctorName  =m_txtSign.Text ;
			m_objImageRequest.m_strInPatientID =MDIParent.s_ObjCurrentPatient.m_StrInPatientID ;
			m_objImageRequest.m_strPatientBirth =MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy-MM-dd HH:mm:ss");
			m_objImageRequest.m_strPatientName =MDIParent.s_ObjCurrentPatient.m_StrName;
			m_objImageRequest.m_strPatientSex  =MDIParent.s_ObjCurrentPatient.m_StrSex ;
			m_objImageRequest.m_strRequestDateTime  =m_objXRayCheckOrder.m_strCreateDate;
			m_objImageRequest.m_blnIfNeedRequire = m_chkNeedRequire.Checked;
			if(m_objImageRequest.m_blnIfNeedRequire)
			{
				m_objImageRequest.m_strApplicationComment = m_txtApplicationComment.Text;
			}
			else
			{
				m_objImageRequest.m_strApplicationComment = "";
			}

			string m_strApplicationID="";
			m_strApplicationID=m_objXRayCheckOrder.m_strApplicationID;

			//从表 -- CommonRecord
			clsXRayCommonRecord[] objXRayCommonRecordArr = new clsXRayCommonRecord[dtbCommonRecord.Rows.Count];
			for(int i = 0; i < dtbCommonRecord.Rows.Count; i++)
			{
				objXRayCommonRecordArr[i] = new clsXRayCommonRecord();

				objXRayCommonRecordArr[i].m_strCheckPlace = dtbCommonRecord.Rows[i][0].ToString();
				objXRayCommonRecordArr[i].m_strMappingPlace = dtbCommonRecord.Rows[i][1].ToString();
				objXRayCommonRecordArr[i].m_strPhotoArea = dtbCommonRecord.Rows[i][2].ToString();
				objXRayCommonRecordArr[i].m_strPhotoThickness = dtbCommonRecord.Rows[i][3].ToString();
				objXRayCommonRecordArr[i].m_strDistance = dtbCommonRecord.Rows[i][4].ToString();
				objXRayCommonRecordArr[i].m_strVoltage = dtbCommonRecord.Rows[i][5].ToString();
				objXRayCommonRecordArr[i].m_strElectricity = dtbCommonRecord.Rows[i][6].ToString();
				objXRayCommonRecordArr[i].m_strDisposeTime = dtbCommonRecord.Rows[i][7].ToString();
				objXRayCommonRecordArr[i].m_strBucky = dtbCommonRecord.Rows[i][8].ToString();
				objXRayCommonRecordArr[i].m_strPhotoID = dtbCommonRecord.Rows[i][9].ToString();

				objXRayCommonRecordArr[i].m_strInPatientID = m_strInPatientID;
				objXRayCommonRecordArr[i].m_strInPatientDate =m_strInPatientDate;
				objXRayCommonRecordArr[i].m_strCreateDate = (m_strCreateDate == "") ? dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
				objXRayCommonRecordArr[i].m_strModifyDate = strCurrentDate;
			}


			//从表 -- SpecialRecord
			clsXRaySpecialRecord[] objXRaySpecialRecordArr = new clsXRaySpecialRecord[dtbSpecialRecord.Rows.Count];
			for(int i = 0; i < dtbSpecialRecord.Rows.Count; i++)
			{
				objXRaySpecialRecordArr[i] = new clsXRaySpecialRecord();
				//liyi 2003-7-9 注释员工的输入判断，否则员工不能存盘
				//				if(new clsEmployee(dtbSpecialRecord.Rows[i][6].ToString()).m_StrFirstName==dtbSpecialRecord.Rows[i][0].ToString())
				//				{
				objXRaySpecialRecordArr[i].m_strFisrtOperatorID = dtbSpecialRecord.Rows[i][6].ToString();
				//				}
				//				else
				//					objXRaySpecialRecordArr[i].m_strFisrtOperatorID="";


				objXRaySpecialRecordArr[i].m_strCheckPlace = dtbSpecialRecord.Rows[i][1].ToString();
				objXRaySpecialRecordArr[i].m_strPhotoSeq = dtbSpecialRecord.Rows[i][2].ToString();
				objXRaySpecialRecordArr[i].m_strTimeOfAfterInject = dtbSpecialRecord.Rows[i][3].ToString();
				objXRaySpecialRecordArr[i].m_strRemark = dtbSpecialRecord.Rows[i][4].ToString();
				objXRaySpecialRecordArr[i].m_strPhotoID = dtbSpecialRecord.Rows[i][5].ToString();

				objXRaySpecialRecordArr[i].m_strInPatientID = m_strInPatientID;
				objXRaySpecialRecordArr[i].m_strInPatientDate = m_strInPatientDate;
				objXRaySpecialRecordArr[i].m_strCreateDate = (m_strCreateDate == "") ? dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
				objXRaySpecialRecordArr[i].m_strModifyDate = strCurrentDate;
			}


			//liyi 2003-7-9 注释员工的输入判断，否则员工不能存盘
			//从表 --  Operator
			//			int intCount=0;
			//			for(int j=0;j<dtbOperator.Rows.Count;j++)
			//			{
			//				
			//				if(new clsEmployee(dtbOperator.Rows[j][0].ToString()).m_StrFirstName==dtbOperator.Rows[j][1].ToString())
			//					intCount++;
			//
			//			}
			clsXRayOperatorID[] objOperatorIDArr = new clsXRayOperatorID[dtbOperator.Rows.Count];
			int k=0;
			for(int i = 0; i < dtbOperator.Rows.Count; i++)
			{
				//				if(new clsEmployee(dtbOperator.Rows[i][0].ToString()).m_StrFirstName==dtbOperator.Rows[i][1].ToString())
				//				{
				objOperatorIDArr[k] = new clsXRayOperatorID();
				objOperatorIDArr[k].m_strOperatorID = dtbOperator.Rows[i][0].ToString();

				objOperatorIDArr[k].m_strInPatientID = m_strInPatientID;
				objOperatorIDArr[k].m_strInPatientDate = m_strInPatientDate;
				objOperatorIDArr[k].m_strCreateDate = (m_strCreateDate == "") ? dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
				objOperatorIDArr[k].m_strModifyDate = strCurrentDate;
				k++;
				//				}
			}


			//			bool blnNewRecord = false;
			//			if(m_strCreateDate == "")
			//			{
			//				blnNewRecord = true;
			//			}
			//			else
			//			{
			//				blnNewRecord = false;
			//			}

			long lngRes = m_objDomain.m_lngSave(m_objXRayCheckOrder,objXRayCommonRecordArr,objXRaySpecialRecordArr,objOperatorIDArr,m_objImageRequest, ref m_strApplicationID,p_bnlIsNew);
			if(lngRes<=0)
			{
				return -21;
			}
			else
			{
				m_objXRayCheckOrder.m_strApplicationID = m_strApplicationID;
				m_txtApplicationID.Text = m_strApplicationID;

				string strBookingInfo = "申请单号："+m_strApplicationID+"\r\n姓名："+m_objImageRequest.m_strPatientName+"\r\n住院号："+m_objImageRequest.m_strInPatientID+"\r\n检查目的："+m_objImageRequest.m_strCheckPurpose+"\r\n检查部位："+m_objImageRequest.m_strCheckPart;

				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(0),strBookingInfo);	
			
				if(!blnSendRes)
					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

				if(m_strCreateDate == "")
				{
					int intNodeIndex = -1;
					for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
					{
						if(DateTime.Parse(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")) == (DateTime)(trvTime.Nodes[0].Nodes[i].Tag))
						{
							intNodeIndex = i;
							break;
						}
					}

					if(intNodeIndex == -1)
					{
						m_mthAddNodeToTrv(dtpApplicateDate.Value);
						//						TreeNode m_trnNewNode = new TreeNode(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_trnNewNode.Tag = DateTime.Parse(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_strCreateDate = dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						//						trvTime.Nodes[0].Nodes.Add(m_trnNewNode);
						//						trvTime.SelectedNode = trvTime.Nodes[0];
						//						trvTime.SelectedNode = m_trnNewNode;
					}
					else
					{
						m_strCreateDate = dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
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
		private void m_mthDisplayCommonRecord()
		{
			if(m_objXRayCommonRecord == null)
				return;

			for(int i = 0; i < m_objXRayCommonRecord.Length; i++)
			{
				Object [] objRows=new object[10];
				for(int j = 0;j < 10;j++)
				{
					objRows[j]="";

				}
				dtbCommonRecord.Rows.Add(objRows);
			}

			for(int i = 0; i< m_objXRayCommonRecord.Length; i++)
			{
				dtbCommonRecord.Rows[i][0] = m_objXRayCommonRecord[i].m_strCheckPlace;
				dtbCommonRecord.Rows[i][1] = m_objXRayCommonRecord[i].m_strMappingPlace;
				dtbCommonRecord.Rows[i][2] = m_objXRayCommonRecord[i].m_strPhotoArea;
				dtbCommonRecord.Rows[i][3] = m_objXRayCommonRecord[i].m_strPhotoThickness;
				dtbCommonRecord.Rows[i][4] = m_objXRayCommonRecord[i].m_strDistance;
				dtbCommonRecord.Rows[i][5] = m_objXRayCommonRecord[i].m_strVoltage;
				dtbCommonRecord.Rows[i][6] = m_objXRayCommonRecord[i].m_strElectricity;
				dtbCommonRecord.Rows[i][7] = m_objXRayCommonRecord[i].m_strDisposeTime;
				dtbCommonRecord.Rows[i][8] = m_objXRayCommonRecord[i].m_strBucky;
				dtbCommonRecord.Rows[i][9] = m_objXRayCommonRecord[i].m_strPhotoID;
			}
		}

		private void m_mthDisplaySpecialRecord()
		{
			if(m_objXRaySpecialRecord == null)
				return;

			for(int i = 0; i < m_objXRaySpecialRecord.Length; i++)
			{
				Object [] objRows=new object[7];
				for(int j = 0;j < 7;j++)
				{
					objRows[j]="";

				}
				dtbSpecialRecord.Rows.Add(objRows);
			}

			for(int i = 0; i< m_objXRaySpecialRecord.Length; i++)
			{
				clsEmployee objEmployee = new clsEmployee(m_objXRaySpecialRecord[i].m_strFisrtOperatorID);

				dtbSpecialRecord.Rows[i][0] = objEmployee.m_StrLastName;
				dtbSpecialRecord.Rows[i][1] = m_objXRaySpecialRecord[i].m_strCheckPlace;
				dtbSpecialRecord.Rows[i][2] = m_objXRaySpecialRecord[i].m_strPhotoSeq;
				dtbSpecialRecord.Rows[i][3] = m_objXRaySpecialRecord[i].m_strTimeOfAfterInject;
				dtbSpecialRecord.Rows[i][4] = m_objXRaySpecialRecord[i].m_strRemark;
				dtbSpecialRecord.Rows[i][5] = m_objXRaySpecialRecord[i].m_strPhotoID;
				dtbSpecialRecord.Rows[i][6] = m_objXRaySpecialRecord[i].m_strFisrtOperatorID;

				//				m_arlOperatorFirst.Add(m_objXRaySpecialRecord[i].m_strFisrtOperatorID);
			}
		}

		private void m_mthDisplayOperator()
		{
			if(m_objXRayOperatorID == null)
				return;

			for(int i = 0; i < m_objXRayOperatorID.Length; i++)
			{
				Object [] objRows=new object[2];
				for(int j = 0;j < 2;j++)
				{
					objRows[j]="";

				}
				dtbOperator.Rows.Add(objRows);
			}

			for(int i = 0; i< m_objXRayOperatorID.Length; i++)
			{
				clsEmployee objEmployee = new clsEmployee(m_objXRayOperatorID[i].m_strOperatorID);

				dtbOperator.Rows[i][1] = objEmployee.m_StrLastName;
				dtbOperator.Rows[i][0] = m_objXRayOperatorID[i].m_strOperatorID;

				//				m_arlOperatorSecond.Add(m_objXRayOperatorID[i].m_strOperatorID);
			}
		}

		private void m_mthDisplay()
		{
			dtpApplicateDate.Value = DateTime.Parse(m_objXRayCheckOrder.m_strCreateDate);

			m_txtApplicationID.Text = m_objXRayCheckOrder.m_strApplicationID;
			txtHistory.Text = m_objXRayCheckOrder.m_strHistory;
			txtCheckAndResult.Text = m_objXRayCheckOrder.m_strClinicalCheckAndResult;
			txtClinicalDignose.Text = m_objXRayCheckOrder.m_strClinicalDignose;
			txtCheckAim.Text = m_objXRayCheckOrder.m_strCheckAim;
			txtCheckPlace.Text = m_objXRayCheckOrder.m_strCheckPlace;
			txtClairvoyance.Text = m_objXRayCheckOrder.m_strClairvoyance;
			txtPhoto.Text = m_objXRayCheckOrder.m_strPhoto;
			txtNotHavePhoto.Text = m_objXRayCheckOrder.m_strNotHaveOldPhoto;
			txtHavePhoto.Text = m_objXRayCheckOrder.m_strHaveOldPhoto;
			txtHavePhotoOut.Text = m_objXRayCheckOrder.m_strHaveOldPhotoOut;
			txtCharge.Text = m_objXRayCheckOrder.m_strCharge;
			txtAdditionCharge.Text = m_objXRayCheckOrder.m_strAdditionCharge;
			
			this.txtXRayNo.Text=m_objXRayCheckOrder.m_strXRayNo;
			this.txtInsuranceNo.Text=m_objXRayCheckOrder.m_strInsuranceNo;
			this.txtOtherCheckInfo.Text=m_objXRayCheckOrder.m_strOtherCheckInfo;
			//this.txtContactInfo.Text=m_objXRayCheckOrder.m_strContactInfo;

			//设置各CheckBox控件的值
			long mReturn;
			mReturn=this.m_lngSetControlValFromCheckPartSelectionStr(m_objXRayCheckOrder.m_strCheckPartSelection);
			
            //clsEmployee objEmployee = new clsEmployee(m_objXRayCheckOrder.m_strCreateUserID);

            //lblDoctor.Text = objEmployee.m_StrLastName;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objXRayCheckOrder.m_strCreateUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO;
            }

            //m_objSignTool.m_mtSetSpecialEmployee(m_objXRayCheckOrder.m_strCreateUserID);

			m_chkNeedRequire.Checked = false;
			m_txtApplicationComment.Text = "";
		}
		#endregion

		private void txtCharge_LostFocus(object sender, System.EventArgs e)
		{
			try
			{
				float.Parse(this.txtCharge.Text);
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("请输入正确的数字格式。"); 
				txtCharge.Text ="0.00";
				txtCharge.Focus(); 
			}
		}
		private void txtAdditionCharge_LostFocus(object sender, System.EventArgs e)
		{
			try
			{
				float.Parse(this.txtAdditionCharge.Text);
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("请输入正确的数字格式。"); 
				txtAdditionCharge.Text ="0.00";
				txtAdditionCharge.Focus(); 				
			}
		}

		//        //dick 2003-3-27 检查是否签名重复
		//		private bool m_blnCheckDuplicate(DataTable dtbSign)
		//		{
		//			if(dtbSign==null) return false;
		//			ArrayList arlSign=new ArrayList();
		//			for(int i = 0; i < dtbSign.Rows.Count; i++)
		//			{
		//				if(arlSign.Contains(dtbSign.Rows[i].ItemArray[1].ToString()))
		//					return true;
		//				else if(dtbSign.Rows[i].ItemArray[1].ToString()!="")
		//				{
		//					arlSign.Add(dtbSign.Rows[i].ItemArray[1].ToString());
		//				}
		//			}
		//		
		//			return false;
		//
		//		}
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
						((Control)sender).Name!="txtCheckAndResult" &&
						((Control)sender).Name!="txtClinicalDignose" &&
						((Control)sender).Name!="txtCheckAim" &&
						((Control)sender).Name!="m_txtSign" &&
						((Control)sender).Name!="m_txtPatientName" &&
						((Control)sender).Name!="txtInPatientID")//Ben 2003-4-29
						SendKeys.Send(  "{tab}"); //注意:如果是button控件,则不能send "Tab" 而应该是"Enter",如果是Text控件且允许多行编辑，也不能send "Tab"
					break;
					
					//				case 38:
					//				case 40:					
					//					if(sender.GetType().Name=="ctlBorderTextBox" && ((ctlBorderTextBox)sender).Name=="txtInPatientID")
					//					{
					//						m_lsvInPatientID.Visible=true;
					//						SendKeys.Send(  "{tab}");
					//						if( m_lsvInPatientID.Items.Count>0)
					//						{
					//							m_lsvInPatientID.Items[0].Selected=true;
					//							m_lsvInPatientID.Items[0].Focused=true;
					//						}							
					//					}
					//					break;	
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

					m_strInPatientID = "";
					m_strInPatientDate = "";

					this.txtInPatientID.Text ="";
					this.lblAge.Text = "";
					this.lblSex.Text = "";
					this.m_cboArea.Text = "";
					this.m_txtBedNO.Text = "";
					this.m_txtPatientName.Text = "";
					this.lblSickRoom.Text = "";
					this.dtpApplicateDate.Value = DateTime.Now;

					m_blnCanSearch =true;
					m_mthClearUpRecord();
                    
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion

		#region Old Print
		#region Print
		/*
* DataSet : XRayReportSet
* DataTable : XRayReportBase
* 	DataColumn : ChargeFee(string)
* 	DataColumn : AddFee(string)
* 	DataColumn : XRayNo(string)
* 	DataColumn : MedicalNo(string)
* 	DataColumn : PatientName(string)
* 	DataColumn : PatientSex(string)
* 	DataColumn : PatientAge(string)
* 	DataColumn : Section(string)
* 	DataColumn : BedNo(string)
* 	DataColumn : InHospitalNo(string)
* 	DataColumn : RequestYear(string)
* 	DataColumn : RequestMonth(string)
* 	DataColumn : RequestDate(string)
* 	DataColumn : CaseHistory(string)
* 	DataColumn : ClinicResult(string)
* 	DataColumn : ClinicDiagnose(string)
* 	DataColumn : ExaminePurpose(string)
* 	DataColumn : ExamineSection(string)
* 	DataColumn : RequestDoctor(string)
* 	DataColumn : BodySection01(string)
* 	DataColumn : BodySection02(string)
* 	DataColumn : BodySection03(string)
* 	DataColumn : BodySection04(string)
* 	DataColumn : BodySection05(string)
* 	DataColumn : BodySection06(string)
* 	DataColumn : BodySection07(string)
* 	DataColumn : BodySection08(string)
* 	DataColumn : BodySection09(string)
* 	DataColumn : BodySection10(string)
* 	DataColumn : BodySection11(string)
* 	DataColumn : BodySection12(string)
* 	DataColumn : BodySection13(string)
* 	DataColumn : BodySection14(string)
* 	DataColumn : BodySection15(string)
* 	DataColumn : BodySection16(string)
* 	DataColumn : BodySection17(string)
* 	DataColumn : BodySection18(string)
* 	DataColumn : BodySection19(string)
* 	DataColumn : BodySection20(string)
* 	DataColumn : BodySection21(string)
* 	DataColumn : BodySection22(string)
* 	DataColumn : BodySection23(string)
* 	DataColumn : BodySection24(string)
* 	DataColumn : BodySection25(string)
* 	DataColumn : BodySection26(string)
* 	DataColumn : BodySection27(string)
* 	DataColumn : BodySection28(string)
* 	DataColumn : BodySection29(string)
* 	DataColumn : BodySection30(string)
* 	DataColumn : BodySection31(string)
* 	DataColumn : BodySection32(string)
* 	DataColumn : BodySection33(string)
* 	DataColumn : BodySection34(string)
* 	DataColumn : BodySection35(string)
* 	DataColumn : BodySection36(string)
* 	DataColumn : BodySection37(string)
* 	DataColumn : BodySection38(string)
* 	DataColumn : BodySection39(string)
* 	DataColumn : BodySection40(string)
* 	DataColumn : BodySection41(string)
* 	DataColumn : BodySection42(string)
* 	DataColumn : BodySection43(string)
* 	DataColumn : BodySection44(string)
* 	DataColumn : BodySection45(string)
* 	DataColumn : BodySection46(string)
* 	DataColumn : BodySection47(string)
* 	DataColumn : BodySection48(string)
* 	DataColumn : BodySection49(string)
* 	DataColumn : BodySection50(string)
* 	DataColumn : BodySection51(string)
* 	DataColumn : BodySection52(string)
* 	DataColumn : BodySection53(string)
* 	DataColumn : BodySection54(string)
* 	DataColumn : BodySection55(string)
* 	DataColumn : BodySection56(string)
* 	DataColumn : BodySection57(string)
* 	DataColumn : BodySection58(string)
* 	DataColumn : BodySection59(string)
* 	DataColumn : BodySection60(string)
* 	DataColumn : BodySection61(string)
* 	DataColumn : OtherExamine(string)
* 	DataColumn : TelAndAddress(string)
* DataTable : XRayReportReserve
* 	DataColumn : ReserveField1(string)
* 	DataColumn : ReserveField2(string)
* 	DataColumn : ReserveField3(string)
* 	DataColumn : ReserveField4(string)
* 	DataColumn : ReserveField5(string)
* 	DataColumn : ReserveField6(string)
* 	DataColumn : ReserveField7(string)
* 	DataColumn : ReserveField8(string)
* 	DataColumn : ReserveField9(string)
* 	DataColumn : ReserveField10(string)
*/ 
		private DataSet m_dtsInitXRayReportSetDataSet()
		{
			DataSet dsXRayReportSet = new DataSet("XRayReportSet");

			DataTable dtXRayReportBase = new DataTable("XRayReportBase");

			DataColumn dcXRayReportBaseChargeFee = new DataColumn("ChargeFee",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseChargeFee);

			DataColumn dcXRayReportBaseAddFee = new DataColumn("AddFee",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseAddFee);

			DataColumn dcXRayReportBaseXRayNo = new DataColumn("XRayNo",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseXRayNo);

			DataColumn dcXRayReportBaseMedicalNo = new DataColumn("MedicalNo",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseMedicalNo);

			DataColumn dcXRayReportBasePatientName = new DataColumn("PatientName",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBasePatientName);

			DataColumn dcXRayReportBasePatientSex = new DataColumn("PatientSex",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBasePatientSex);

			DataColumn dcXRayReportBasePatientAge = new DataColumn("PatientAge",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBasePatientAge);

			DataColumn dcXRayReportBaseSection = new DataColumn("Section",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseSection);

			DataColumn dcXRayReportBaseBedNo = new DataColumn("BedNo",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBedNo);

			DataColumn dcXRayReportBaseInHospitalNo = new DataColumn("InHospitalNo",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseInHospitalNo);

			DataColumn dcXRayReportBaseRequestYear = new DataColumn("RequestYear",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseRequestYear);

			DataColumn dcXRayReportBaseRequestMonth = new DataColumn("RequestMonth",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseRequestMonth);

			DataColumn dcXRayReportBaseRequestDate = new DataColumn("RequestDate",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseRequestDate);

			DataColumn dcXRayReportBaseCaseHistory = new DataColumn("CaseHistory",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseCaseHistory);

			DataColumn dcXRayReportBaseClinicResult = new DataColumn("ClinicResult",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseClinicResult);

			DataColumn dcXRayReportBaseClinicDiagnose = new DataColumn("ClinicDiagnose",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseClinicDiagnose);

			DataColumn dcXRayReportBaseExaminePurpose = new DataColumn("ExaminePurpose",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseExaminePurpose);

			DataColumn dcXRayReportBaseExamineSection = new DataColumn("ExamineSection",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseExamineSection);

			DataColumn dcXRayReportBaseRequestDoctor = new DataColumn("RequestDoctor",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseRequestDoctor);

			DataColumn dcXRayReportBaseBodySection01 = new DataColumn("BodySection01",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection01);

			DataColumn dcXRayReportBaseBodySection02 = new DataColumn("BodySection02",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection02);

			DataColumn dcXRayReportBaseBodySection03 = new DataColumn("BodySection03",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection03);

			DataColumn dcXRayReportBaseBodySection04 = new DataColumn("BodySection04",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection04);

			DataColumn dcXRayReportBaseBodySection05 = new DataColumn("BodySection05",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection05);

			DataColumn dcXRayReportBaseBodySection06 = new DataColumn("BodySection06",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection06);

			DataColumn dcXRayReportBaseBodySection07 = new DataColumn("BodySection07",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection07);

			DataColumn dcXRayReportBaseBodySection08 = new DataColumn("BodySection08",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection08);

			DataColumn dcXRayReportBaseBodySection09 = new DataColumn("BodySection09",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection09);

			DataColumn dcXRayReportBaseBodySection10 = new DataColumn("BodySection10",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection10);

			DataColumn dcXRayReportBaseBodySection11 = new DataColumn("BodySection11",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection11);

			DataColumn dcXRayReportBaseBodySection12 = new DataColumn("BodySection12",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection12);

			DataColumn dcXRayReportBaseBodySection13 = new DataColumn("BodySection13",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection13);

			DataColumn dcXRayReportBaseBodySection14 = new DataColumn("BodySection14",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection14);

			DataColumn dcXRayReportBaseBodySection15 = new DataColumn("BodySection15",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection15);

			DataColumn dcXRayReportBaseBodySection16 = new DataColumn("BodySection16",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection16);

			DataColumn dcXRayReportBaseBodySection17 = new DataColumn("BodySection17",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection17);

			DataColumn dcXRayReportBaseBodySection18 = new DataColumn("BodySection18",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection18);

			DataColumn dcXRayReportBaseBodySection19 = new DataColumn("BodySection19",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection19);

			DataColumn dcXRayReportBaseBodySection20 = new DataColumn("BodySection20",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection20);

			DataColumn dcXRayReportBaseBodySection21 = new DataColumn("BodySection21",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection21);

			DataColumn dcXRayReportBaseBodySection22 = new DataColumn("BodySection22",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection22);

			DataColumn dcXRayReportBaseBodySection23 = new DataColumn("BodySection23",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection23);

			DataColumn dcXRayReportBaseBodySection24 = new DataColumn("BodySection24",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection24);

			DataColumn dcXRayReportBaseBodySection25 = new DataColumn("BodySection25",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection25);

			DataColumn dcXRayReportBaseBodySection26 = new DataColumn("BodySection26",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection26);

			DataColumn dcXRayReportBaseBodySection27 = new DataColumn("BodySection27",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection27);

			DataColumn dcXRayReportBaseBodySection28 = new DataColumn("BodySection28",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection28);

			DataColumn dcXRayReportBaseBodySection29 = new DataColumn("BodySection29",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection29);

			DataColumn dcXRayReportBaseBodySection30 = new DataColumn("BodySection30",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection30);

			DataColumn dcXRayReportBaseBodySection31 = new DataColumn("BodySection31",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection31);

			DataColumn dcXRayReportBaseBodySection32 = new DataColumn("BodySection32",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection32);

			DataColumn dcXRayReportBaseBodySection33 = new DataColumn("BodySection33",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection33);

			DataColumn dcXRayReportBaseBodySection34 = new DataColumn("BodySection34",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection34);

			DataColumn dcXRayReportBaseBodySection35 = new DataColumn("BodySection35",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection35);

			DataColumn dcXRayReportBaseBodySection36 = new DataColumn("BodySection36",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection36);

			DataColumn dcXRayReportBaseBodySection37 = new DataColumn("BodySection37",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection37);

			DataColumn dcXRayReportBaseBodySection38 = new DataColumn("BodySection38",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection38);

			DataColumn dcXRayReportBaseBodySection39 = new DataColumn("BodySection39",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection39);

			DataColumn dcXRayReportBaseBodySection40 = new DataColumn("BodySection40",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection40);

			DataColumn dcXRayReportBaseBodySection41 = new DataColumn("BodySection41",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection41);

			DataColumn dcXRayReportBaseBodySection42 = new DataColumn("BodySection42",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection42);

			DataColumn dcXRayReportBaseBodySection43 = new DataColumn("BodySection43",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection43);

			DataColumn dcXRayReportBaseBodySection44 = new DataColumn("BodySection44",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection44);

			DataColumn dcXRayReportBaseBodySection45 = new DataColumn("BodySection45",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection45);

			DataColumn dcXRayReportBaseBodySection46 = new DataColumn("BodySection46",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection46);

			DataColumn dcXRayReportBaseBodySection47 = new DataColumn("BodySection47",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection47);

			DataColumn dcXRayReportBaseBodySection48 = new DataColumn("BodySection48",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection48);

			DataColumn dcXRayReportBaseBodySection49 = new DataColumn("BodySection49",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection49);

			DataColumn dcXRayReportBaseBodySection50 = new DataColumn("BodySection50",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection50);

			DataColumn dcXRayReportBaseBodySection51 = new DataColumn("BodySection51",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection51);

			DataColumn dcXRayReportBaseBodySection52 = new DataColumn("BodySection52",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection52);

			DataColumn dcXRayReportBaseBodySection53 = new DataColumn("BodySection53",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection53);

			DataColumn dcXRayReportBaseBodySection54 = new DataColumn("BodySection54",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection54);

			DataColumn dcXRayReportBaseBodySection55 = new DataColumn("BodySection55",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection55);

			DataColumn dcXRayReportBaseBodySection56 = new DataColumn("BodySection56",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection56);

			DataColumn dcXRayReportBaseBodySection57 = new DataColumn("BodySection57",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection57);

			DataColumn dcXRayReportBaseBodySection58 = new DataColumn("BodySection58",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection58);

			DataColumn dcXRayReportBaseBodySection59 = new DataColumn("BodySection59",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection59);

			DataColumn dcXRayReportBaseBodySection60 = new DataColumn("BodySection60",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection60);

			DataColumn dcXRayReportBaseBodySection61 = new DataColumn("BodySection61",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseBodySection61);

			DataColumn dcXRayReportBaseOtherExamine = new DataColumn("OtherExamine",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseOtherExamine);

			DataColumn dcXRayReportBaseTelAndAddress = new DataColumn("TelAndAddress",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseTelAndAddress);

			DataColumn dcXRayReportBaseTelApplicationID = new DataColumn("ApplicationID",typeof(string));

			dtXRayReportBase.Columns.Add(dcXRayReportBaseTelApplicationID);

			dsXRayReportSet.Tables.Add(dtXRayReportBase);

//			DataTable dtXRayReportReserve = new DataTable("XRayReportReserve");
//
//			DataColumn dcXRayReportReserveReserveField1 = new DataColumn("ReserveField1",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField1);
//
//			DataColumn dcXRayReportReserveReserveField2 = new DataColumn("ReserveField2",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField2);
//
//			DataColumn dcXRayReportReserveReserveField3 = new DataColumn("ReserveField3",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField3);
//
//			DataColumn dcXRayReportReserveReserveField4 = new DataColumn("ReserveField4",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField4);
//
//			DataColumn dcXRayReportReserveReserveField5 = new DataColumn("ReserveField5",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField5);
//
//			DataColumn dcXRayReportReserveReserveField6 = new DataColumn("ReserveField6",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField6);
//
//			DataColumn dcXRayReportReserveReserveField7 = new DataColumn("ReserveField7",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField7);
//
//			DataColumn dcXRayReportReserveReserveField8 = new DataColumn("ReserveField8",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField8);
//
//			DataColumn dcXRayReportReserveReserveField9 = new DataColumn("ReserveField9",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField9);
//
//			DataColumn dcXRayReportReserveReserveField10 = new DataColumn("ReserveField10",typeof(string));
//
//			dtXRayReportReserve.Columns.Add(dcXRayReportReserveReserveField10);
//
//			dsXRayReportSet.Tables.Add(dtXRayReportReserve);

			return dsXRayReportSet;
		}

		/*
		* DataSet : XRayReportSet
		* DataTable : XRayReportBase
		* 	DataColumn : ChargeFee(string)
		* 	DataColumn : AddFee(string)
		* 	DataColumn : XRayNo(string)
		* 	DataColumn : MedicalNo(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : Section(string)
		* 	DataColumn : BedNo(string)
		* 	DataColumn : InHospitalNo(string)
		* 	DataColumn : RequestYear(string)
		* 	DataColumn : RequestMonth(string)
		* 	DataColumn : RequestDate(string)
		* 	DataColumn : CaseHistory(string)
		* 	DataColumn : ClinicResult(string)
		* 	DataColumn : ClinicDiagnose(string)
		* 	DataColumn : ExaminePurpose(string)
		* 	DataColumn : ExamineSection(string)
		* 	DataColumn : RequestDoctor(string)
		* 	DataColumn : BodySection01(string)
		* 	DataColumn : BodySection02(string)
		* 	DataColumn : BodySection03(string)
		* 	DataColumn : BodySection04(string)
		* 	DataColumn : BodySection05(string)
		* 	DataColumn : BodySection06(string)
		* 	DataColumn : BodySection07(string)
		* 	DataColumn : BodySection08(string)
		* 	DataColumn : BodySection09(string)
		* 	DataColumn : BodySection10(string)
		* 	DataColumn : BodySection11(string)
		* 	DataColumn : BodySection12(string)
		* 	DataColumn : BodySection13(string)
		* 	DataColumn : BodySection14(string)
		* 	DataColumn : BodySection15(string)
		* 	DataColumn : BodySection16(string)
		* 	DataColumn : BodySection17(string)
		* 	DataColumn : BodySection18(string)
		* 	DataColumn : BodySection19(string)
		* 	DataColumn : BodySection20(string)
		* 	DataColumn : BodySection21(string)
		* 	DataColumn : BodySection22(string)
		* 	DataColumn : BodySection23(string)
		* 	DataColumn : BodySection24(string)
		* 	DataColumn : BodySection25(string)
		* 	DataColumn : BodySection26(string)
		* 	DataColumn : BodySection27(string)
		* 	DataColumn : BodySection28(string)
		* 	DataColumn : BodySection29(string)
		* 	DataColumn : BodySection30(string)
		* 	DataColumn : BodySection31(string)
		* 	DataColumn : BodySection32(string)
		* 	DataColumn : BodySection33(string)
		* 	DataColumn : BodySection34(string)
		* 	DataColumn : BodySection35(string)
		* 	DataColumn : BodySection36(string)
		* 	DataColumn : BodySection37(string)
		* 	DataColumn : BodySection38(string)
		* 	DataColumn : BodySection39(string)
		* 	DataColumn : BodySection40(string)
		* 	DataColumn : BodySection41(string)
		* 	DataColumn : BodySection42(string)
		* 	DataColumn : BodySection43(string)
		* 	DataColumn : BodySection44(string)
		* 	DataColumn : BodySection45(string)
		* 	DataColumn : BodySection46(string)
		* 	DataColumn : BodySection47(string)
		* 	DataColumn : BodySection48(string)
		* 	DataColumn : BodySection49(string)
		* 	DataColumn : BodySection50(string)
		* 	DataColumn : BodySection51(string)
		* 	DataColumn : BodySection52(string)
		* 	DataColumn : BodySection53(string)
		* 	DataColumn : BodySection54(string)
		* 	DataColumn : BodySection55(string)
		* 	DataColumn : BodySection56(string)
		* 	DataColumn : BodySection57(string)
		* 	DataColumn : BodySection58(string)
		* 	DataColumn : BodySection59(string)
		* 	DataColumn : BodySection60(string)
		* 	DataColumn : BodySection61(string)
		* 	DataColumn : OtherExamine(string)
		* 	DataColumn : TelAndAddress(string)
		* DataTable : XRayReportReserve
		* 	DataColumn : ReserveField1(string)
		* 	DataColumn : ReserveField2(string)
		* 	DataColumn : ReserveField3(string)
		* 	DataColumn : ReserveField4(string)
		* 	DataColumn : ReserveField5(string)
		* 	DataColumn : ReserveField6(string)
		* 	DataColumn : ReserveField7(string)
		* 	DataColumn : ReserveField8(string)
		* 	DataColumn : ReserveField9(string)
		* 	DataColumn : ReserveField10(string)
		*/ 
		private void m_mthAddNewDataForXRayReportSetDataSet(DataSet dsXRayReportSet)
		{
			if(m_strCreateDate == "")
				return;//打印空报表

			DataTable dtXRayReportBase = dsXRayReportSet.Tables["XRAYREPORTBASE"];
			dtXRayReportBase.Rows.Clear();

			object [] objXRayReportBaseDatas = new object[83];

			objXRayReportBaseDatas[0] = txtCharge.Text.Trim();//ChargeFee:收费
			objXRayReportBaseDatas[1] = txtAdditionCharge.Text.Trim();//AddFee:加收
			objXRayReportBaseDatas[2] = txtXRayNo.Text.Trim();// XRayNo:X线号
			objXRayReportBaseDatas[3] = txtInsuranceNo.Text.Trim();//MedicalNo:医保号码
            if (m_objSelectedPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                objXRayReportBaseDatas[4] = m_objSelectedPatient.m_StrName;//PatientName:姓名
			    objXRayReportBaseDatas[5] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;//PatientSex:性别
			    objXRayReportBaseDatas[6] = m_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;//PatientAge:年龄
                objXRayReportBaseDatas[7] = m_ObjCurrentEmrPatientSession.m_strAreaName;//Section:科别
                objXRayReportBaseDatas[9] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;//InHospitalNo:住院号
            }
            else
            {
                objXRayReportBaseDatas[4] = string.Empty;//PatientName:姓名
                objXRayReportBaseDatas[5] = string.Empty;//PatientSex:性别
                objXRayReportBaseDatas[6] = string.Empty;//PatientAge:年龄
                objXRayReportBaseDatas[7] = string.Empty;//Section:科别
                objXRayReportBaseDatas[9] = string.Empty;
            }
            if (m_ObjCurrentBed != null)
            {
                objXRayReportBaseDatas[8] = m_ObjCurrentBed.m_strCODE_CHR;
            }
            else
            {
                objXRayReportBaseDatas[8] = string.Empty;
            }
			objXRayReportBaseDatas[10] = dtpApplicateDate.Value.Year.ToString();//RequestYear:申请年
			objXRayReportBaseDatas[11] = dtpApplicateDate.Value.Month.ToString();// RequestMonth:申请月
			objXRayReportBaseDatas[12] = dtpApplicateDate.Value.Day.ToString();//RequestDate:申请日
			objXRayReportBaseDatas[13] = txtHistory.Text.Trim();//CaseHistory:病史
			objXRayReportBaseDatas[14] = txtCheckAndResult.Text.Trim();// ClinicResult:临床检查化验结果
			objXRayReportBaseDatas[15] = txtClinicalDignose.Text.Trim();//ClinicDiagnose:临床诊断
			objXRayReportBaseDatas[16] = txtCheckAim.Text.Trim();//ExaminePurpose:检查目的
			objXRayReportBaseDatas[17] = txtCheckPlace.Text.Trim();// ExamineSection:检查部位
			objXRayReportBaseDatas[18] = (m_strInPatientID != null && m_strInPatientID != "") ? m_txtSign.Text : "";//RequestDoctor:申请医师
			objXRayReportBaseDatas[19] = m_chkCheckPart01.Checked? "√":"";//BodySection01
			objXRayReportBaseDatas[20] = m_chkCheckPart02.Checked? "√":"";//BodySection02
			objXRayReportBaseDatas[21] = m_chkCheckPart03.Checked? "√":"";//BodySection03
			objXRayReportBaseDatas[22] = m_chkCheckPart04.Checked? "√":"";//BodySection04
			objXRayReportBaseDatas[23] = m_chkCheckPart05.Checked? "√":"";//BodySection05
			objXRayReportBaseDatas[24] = m_chkCheckPart06.Checked? "√":"";//BodySection06
			objXRayReportBaseDatas[25] = m_chkCheckPart07.Checked? "√":"";//BodySection07
			objXRayReportBaseDatas[26] = m_chkCheckPart08.Checked? "√":"";//BodySection08
			objXRayReportBaseDatas[27] = m_chkCheckPart09.Checked? "√":"";//BodySection09
			objXRayReportBaseDatas[28] = m_chkCheckPart10.Checked? "√":"";//BodySection10
			objXRayReportBaseDatas[29] = m_chkCheckPart11.Checked? "√":"";//BodySection11
			objXRayReportBaseDatas[30] = m_chkCheckPart12.Checked? "√":"";//BodySection12
			objXRayReportBaseDatas[31] = m_chkCheckPart13.Checked? "√":"";//BodySection13
			objXRayReportBaseDatas[32] = m_chkCheckPart14.Checked? "√":"";//BodySection14
			objXRayReportBaseDatas[33] = m_chkCheckPart15.Checked? "√":"";//BodySection15
			objXRayReportBaseDatas[34] = m_chkCheckPart16.Checked? "√":"";//BodySection16
			objXRayReportBaseDatas[35] = m_chkCheckPart17.Checked? "√":"";//BodySection17
			objXRayReportBaseDatas[36] = m_chkCheckPart18.Checked? "√":"";//BodySection18
			objXRayReportBaseDatas[37] = m_chkCheckPart19.Checked? "√":"";//BodySection19
			objXRayReportBaseDatas[38] = m_chkCheckPart20.Checked? "√":"";//BodySection20
			objXRayReportBaseDatas[39] = m_chkCheckPart21.Checked? "√":"";//BodySection21
			objXRayReportBaseDatas[40] = m_chkCheckPart22.Checked? "√":"";//BodySection22
			objXRayReportBaseDatas[41] = m_chkCheckPart23.Checked? "√":"";//BodySection23
			objXRayReportBaseDatas[42] = m_chkCheckPart24.Checked? "√":"";//BodySection24
			objXRayReportBaseDatas[43] = m_chkCheckPart25.Checked? "√":"";//BodySection25
			objXRayReportBaseDatas[44] = m_chkCheckPart26.Checked? "√":"";//BodySection26
			objXRayReportBaseDatas[45] = m_chkCheckPart27.Checked? "√":"";//BodySection27
			objXRayReportBaseDatas[46] = m_chkCheckPart28.Checked? "√":"";//BodySection28
			objXRayReportBaseDatas[47] = m_chkCheckPart29.Checked? "√":"";//BodySection29
			objXRayReportBaseDatas[48] = m_chkCheckPart30.Checked? "√":"";//BodySection30
			objXRayReportBaseDatas[49] = m_chkCheckPart31.Checked? "√":"";//BodySection31
			objXRayReportBaseDatas[50] = m_chkCheckPart32.Checked? "√":"";//BodySection32
			objXRayReportBaseDatas[51] = m_chkCheckPart33.Checked? "√":"";//BodySection33
			objXRayReportBaseDatas[52] = m_chkCheckPart34.Checked? "√":"";//BodySection34
			objXRayReportBaseDatas[53] = m_chkCheckPart35.Checked? "√":"";//BodySection35
			objXRayReportBaseDatas[54] = m_chkCheckPart36.Checked? "√":"";//BodySection36
			objXRayReportBaseDatas[55] = m_chkCheckPart37.Checked? "√":"";//BodySection37
			objXRayReportBaseDatas[56] = m_chkCheckPart38.Checked? "√":"";//BodySection38
			objXRayReportBaseDatas[57] = m_chkCheckPart39.Checked? "√":"";//BodySection39
			objXRayReportBaseDatas[58] = m_chkCheckPart40.Checked? "√":"";//BodySection40
			objXRayReportBaseDatas[59] = m_chkCheckPart41.Checked? "√":"";//BodySection41
			objXRayReportBaseDatas[60] = m_chkCheckPart42.Checked? "√":"";//BodySection42
			objXRayReportBaseDatas[61] = m_chkCheckPart43.Checked? "√":"";//BodySection43
			objXRayReportBaseDatas[62] = m_chkCheckPart44.Checked? "√":"";//BodySection44
			objXRayReportBaseDatas[63] = m_chkCheckPart45.Checked? "√":"";//BodySection45
			objXRayReportBaseDatas[64] = m_chkCheckPart46.Checked? "√":"";//BodySection46
			objXRayReportBaseDatas[65] = m_chkCheckPart47.Checked? "√":"";//BodySection47
			objXRayReportBaseDatas[66] = m_chkCheckPart48.Checked? "√":"";//BodySection48
			objXRayReportBaseDatas[67] = m_chkCheckPart49.Checked? "√":"";//BodySection49
			objXRayReportBaseDatas[68] = m_chkCheckPart50.Checked? "√":"";//BodySection50
			objXRayReportBaseDatas[69] = m_chkCheckPart51.Checked? "√":"";//BodySection51
			objXRayReportBaseDatas[70] = m_chkCheckPart52.Checked? "√":"";//BodySection52
			objXRayReportBaseDatas[71] = m_chkCheckPart53.Checked? "√":"";//BodySection53
			objXRayReportBaseDatas[72] = m_chkCheckPart54.Checked? "√":"";//BodySection54
			objXRayReportBaseDatas[73] = m_chkCheckPart55.Checked? "√":"";//BodySection55
			objXRayReportBaseDatas[74] = m_chkCheckPart56.Checked? "√":"";//BodySection56
			objXRayReportBaseDatas[75] = m_chkCheckPart57.Checked? "√":"";//BodySection57
			objXRayReportBaseDatas[76] = m_chkCheckPart58.Checked? "√":"";//BodySection58
			objXRayReportBaseDatas[77] = m_chkCheckPart59.Checked? "√":"";//BodySection59
			objXRayReportBaseDatas[78] = m_chkCheckPart60.Checked? "√":"";//BodySection60
			objXRayReportBaseDatas[79] = m_chkCheckPart61.Checked? "√":"";//BodySection61
			objXRayReportBaseDatas[80] = txtOtherCheckInfo.Text;//OtherExamine:其它检查
			objXRayReportBaseDatas[81] = txtContactInfo.Text;//TelAndAddress:受检查住址及联系电话
			objXRayReportBaseDatas[82] = m_txtApplicationID.Text;//申请单号
			dtXRayReportBase.Rows.Add(objXRayReportBaseDatas);
			m_rpdOrderRept.Database.Tables["XRAYREPORTBASE"].SetDataSource(dtXRayReportBase);
			m_rpdOrderRept.Refresh();
			
//			DataTable dtXRayReportReserve = dsXRayReportSet.Tables["XRAYREPORTRESERVE"];
//			dtXRayReportReserve.Rows.Clear();
//
//			object [] objXRayReportReserveDatas = new object[10];
//
//			objXRayReportReserveDatas[0] = m_txtApplicationID.Text;
//			objXRayReportReserveDatas[1] = "";
//			objXRayReportReserveDatas[2] = "";
//			objXRayReportReserveDatas[3] = "";
//			objXRayReportReserveDatas[4] = "";
//			objXRayReportReserveDatas[5] = "";
//			objXRayReportReserveDatas[6] = "";
//			objXRayReportReserveDatas[7] = "";
//			objXRayReportReserveDatas[8] = "";
//			objXRayReportReserveDatas[9] = "";
//			dtXRayReportReserve.Rows.Add(objXRayReportReserveDatas);
//			m_rpdOrderRept.Database.Tables["XRAYREPORTRESERVE"].SetDataSource(dtXRayReportReserve);

			m_rpdOrderRept.Refresh();			
		}

//		/*
//		* DataSet : dtsXRayCheckOrder
//		* DataTable : Header
//		* 	DataColumn 0: InPatientID(string)
//		* 	DataColumn 1: InPatientDate(string)
//		* 	DataColumn 2: CreateDate(string)
//		* 	DataColumn 3: ModifyDate(string)
//		* 	DataColumn 4: History(string)
//		* 	DataColumn 5: ClinicalCheckAndResult(string)
//		* 	DataColumn 6: ClinicalDignose(string)
//		* 	DataColumn 7: CheckAim(string)
//		* 	DataColumn 8: CheckPlace(string)
//		* 	DataColumn 9: Clairvoyance(string)
//		* 	DataColumn 10: Photo(string)
//		* 	DataColumn 11: NotHaveOldPhoto(string)
//		* 	DataColumn 12: HaveOldPhoto(string)
//		* 	DataColumn 13: HaveOldPhotoOut(string)
//		* 	DataColumn 14: Charge(string)
//		* 	DataColumn 15: AdditionCharge(string)
//		* 	DataColumn 16: Operator(string)
//		* 	DataColumn 17: PatientName(string)
//		* 	DataColumn 18: PatientSex(string)
//		* 	DataColumn 19: PatientAge(string)
//		* 	DataColumn 20: PatientDept(string)
//		* 	DataColumn 21: SickRoom(string)
//		* 	DataColumn 22: InhospitalNo(string)
//		* DataTable : CommonRecord
//		* 	DataColumn 0: InPatientID(string)
//		* 	DataColumn 1: InPatientDate(string)
//		* 	DataColumn 2: CreateDate(string)
//		* 	DataColumn 3: ModifyDate(string)
//		* 	DataColumn 4: PhotoID(string)
//		* 	DataColumn 5: CheckPlace(string)
//		* 	DataColumn 6: MappingPlace(string)
//		* 	DataColumn 7: PhotoArea(string)
//		* 	DataColumn 8: PhotoThickness(string)
//		* 	DataColumn 9: Distance(string)
//		* 	DataColumn 10: Voltage(string)
//		* 	DataColumn 11: Electricity(string)
//		* 	DataColumn 12: DisposeTime(string)
//		* 	DataColumn 13: Bucky(string)
//		* DataTable : SpecialRecord
//		* 	DataColumn 0: InPatientID(string)
//		* 	DataColumn 1: InPatientDate(string)
//		* 	DataColumn 2: CreateDate(string)
//		* 	DataColumn 3: ModifyDate(string)
//		* 	DataColumn 4: PhotoID(string)
//		* 	DataColumn 5: PhotoSeq(string)
//		* 	DataColumn 6: CheckPlace(string)
//		* 	DataColumn 7: TimeOfAfterInject(string)
//		* 	DataColumn 8: FisrtOperatorID(string)
//		* 	DataColumn 9: Remark(string)
//		*/ 
//		private void AddNewDataFordtsXRayCheckOrderDataSet(DataSet dsdtsXRayCheckOrder)
//		{
//			//术者
//			string strOperator = "";
//			for(int i = 0; i < dtbOperator.Rows.Count; i++)
//			{
//				strOperator += dtbOperator.Rows[i][1].ToString() + " ";
//			}
//
//			DataTable dtHeader = dsdtsXRayCheckOrder.Tables["HEADER"];
//			dtHeader.Rows.Clear();
//
//			object [] objHeaderDatas = new object[23];
//
//			objHeaderDatas[0] =  txtInPatientID.Text.Trim();
//			//objHeaderDatas[1] = ;
//			objHeaderDatas[2] = (m_strInPatientID != null && m_strInPatientID != "") ? dtpApplicateDate.Value.ToString("D") : "";
//			//objHeaderDatas[3] = ;
//			objHeaderDatas[4] = txtHistory.Text.Trim();
//			objHeaderDatas[5] = txtCheckAndResult.Text.Trim();
//			objHeaderDatas[6] = txtClinicalDignose.Text.Trim();
//			objHeaderDatas[7] = txtCheckAim.Text.Trim();
//			objHeaderDatas[8] = txtCheckPlace.Text.Trim();
//			objHeaderDatas[9] = txtClairvoyance.Text.Trim();
//			objHeaderDatas[10] = txtPhoto.Text.Trim();
//			objHeaderDatas[11] = txtNotHavePhoto.Text.Trim();
//			objHeaderDatas[12] = txtHavePhoto.Text.Trim();
//			objHeaderDatas[13] = txtHavePhotoOut.Text.Trim();
//			objHeaderDatas[14] = txtCharge.Text.Trim();
//			objHeaderDatas[15] = txtAdditionCharge.Text.Trim();
//			objHeaderDatas[16] = (m_strInPatientID != null && m_strInPatientID != "") ? lblDoctor.Text.Trim() : "";
//			objHeaderDatas[17] = m_txtPatientName.Text.Trim();
//			objHeaderDatas[18] = lblSex.Text.Trim();
//			objHeaderDatas[19] = lblAge.Text.Trim();
//			objHeaderDatas[20] = m_cboArea.Text.Trim();
//			objHeaderDatas[21] = lblSickRoom.Text.Trim();
//			objHeaderDatas[22] = m_txtBedNO.Text.Trim();
//			dtHeader.Rows.Add(objHeaderDatas);
//			m_rpdOrderRept.Database.Tables["HEADER"].SetDataSource(dtHeader);
//			m_rpdOrderRept.Refresh();
//
//			int intMaxRow = (dtbCommonRecord.Rows.Count > dtbSpecialRecord.Rows.Count) ? dtbCommonRecord.Rows.Count : dtbSpecialRecord.Rows.Count;
//
//			DataTable dtCommonRecord = dsdtsXRayCheckOrder.Tables["COMMONRECORD"];
//			dtCommonRecord.Rows.Clear();
//
//			for(int i = 0; i < intMaxRow; i++)
//			{
//				object [] objCommonRecordDatas = new object[14];
//
//				if(i < dtbCommonRecord.Rows.Count)
//				{
//					//objCommonRecordDatas[0] = ;
//					//objCommonRecordDatas[1] = ;
//					//objCommonRecordDatas[2] = ;
//					//objCommonRecordDatas[3] = ;
//					objCommonRecordDatas[4] = dtbCommonRecord.Rows[i][9].ToString();
//					objCommonRecordDatas[5] = dtbCommonRecord.Rows[i][0].ToString();
//					objCommonRecordDatas[6] = dtbCommonRecord.Rows[i][1].ToString();
//					objCommonRecordDatas[7] = dtbCommonRecord.Rows[i][2].ToString();
//					objCommonRecordDatas[8] = dtbCommonRecord.Rows[i][3].ToString();
//					objCommonRecordDatas[9] = dtbCommonRecord.Rows[i][4].ToString();
//					objCommonRecordDatas[10] = dtbCommonRecord.Rows[i][5].ToString();
//					objCommonRecordDatas[11] = dtbCommonRecord.Rows[i][6].ToString();
//					objCommonRecordDatas[12] = dtbCommonRecord.Rows[i][7].ToString();
//					objCommonRecordDatas[13] = dtbCommonRecord.Rows[i][8].ToString();
//				}
//				else
//				{
//					objCommonRecordDatas[4] = " ";
//					objCommonRecordDatas[5] = " ";
//					objCommonRecordDatas[6] = " ";
//					objCommonRecordDatas[7] = " ";
//					objCommonRecordDatas[8] = " ";
//					objCommonRecordDatas[9] = " ";
//					objCommonRecordDatas[10] = " ";
//					objCommonRecordDatas[11] = " ";
//					objCommonRecordDatas[12] = " ";
//					objCommonRecordDatas[13] = " ";
//				}
//				dtCommonRecord.Rows.Add(objCommonRecordDatas);
//			}
//			if(dtCommonRecord.Rows.Count == 0)
//			{
//				object[] objBlank = new object[14];
//				
//				dtCommonRecord.Rows.Add(objBlank);
//			}
//
//			m_rpdOrderRept.Database.Tables["COMMONRECORD"].SetDataSource(dtCommonRecord);
//			m_rpdOrderRept.Refresh();
//
//			DataTable dtSpecialRecord = dsdtsXRayCheckOrder.Tables["SPECIALRECORD"];
//			dtSpecialRecord.Rows.Clear();
//
//			for(int i = 0; i < intMaxRow; i++)
//			{
//				object [] objSpecialRecordDatas = new object[10];
//
//				if(i < dtbSpecialRecord.Rows.Count)
//				{
//					//objSpecialRecordDatas[0] = ;
//					//objSpecialRecordDatas[1] = ;
//					//objSpecialRecordDatas[2] = ;
//					objSpecialRecordDatas[3] = strOperator;
//					objSpecialRecordDatas[4] = dtbSpecialRecord.Rows[i][5].ToString();
//					objSpecialRecordDatas[5] = dtbSpecialRecord.Rows[i][2].ToString();
//					objSpecialRecordDatas[6] = dtbSpecialRecord.Rows[i][1].ToString();
//					objSpecialRecordDatas[7] = dtbSpecialRecord.Rows[i][3].ToString();
//					objSpecialRecordDatas[8] = dtbSpecialRecord.Rows[i][0].ToString();
//					objSpecialRecordDatas[9] = dtbSpecialRecord.Rows[i][4].ToString();
//				}
//				else
//				{
//					objSpecialRecordDatas[3] = strOperator;
//					objSpecialRecordDatas[4] = " ";
//					objSpecialRecordDatas[5] = " ";
//					objSpecialRecordDatas[6] = " ";
//					objSpecialRecordDatas[7] = " ";
//					objSpecialRecordDatas[8] = " ";
//					objSpecialRecordDatas[9] = " ";
//				}
//				dtSpecialRecord.Rows.Add(objSpecialRecordDatas);
//			}
//			if(dtSpecialRecord.Rows.Count == 0)
//			{
//				object[] objBlankSpecial = new object[10];
//				
//				dtSpecialRecord.Rows.Add(objBlankSpecial);
//			}
//			m_rpdOrderRept.Database.Tables["SPECIALRECORD"].SetDataSource(dtSpecialRecord);
//			m_rpdOrderRept.Refresh();
//
//		}
		#endregion


		#endregion
		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtHistory.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.txtClinicalDignose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				txtCheckAndResult.Text = objInPatientCaseDefaultValue[0].m_strProfessionalCheck;
//			}				
		}

		private void m_chkNeedRequire_CheckedChanged(object sender, System.EventArgs e)
		{
			m_txtApplicationComment.Enabled = m_chkNeedRequire.Checked;
		}

		private void tabControl2_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthClearUpRecord();

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

