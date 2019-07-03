using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 检验申请单
	/// </summary>
	public class frmLisAppl :com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
        #region 属性
        private clsController_Appl m_objController;
        public static string c_strMessageBoxTitle = "iCare-检验申请";

        public clsLIS_App m_objCurrApp = null;
        public ListViewItem m_lvtCurrApp = null;

        private bool m_blnIsModified = false;
        private clsSealedLisApplyReportPrint m_objPrint = new clsSealedLisApplyReportPrint();

        private bool m_blnIsDialog = false;//窗口是否表现为对话框模式
        private clsLisApplMainVO m_objDialogPatientInfo;//表现为对话框模式时用于存入外部传入的病人信息. 
        private clsDomainController_ApplyUnitManage m_objAppUnitManage = new clsDomainController_ApplyUnitManage();
        #endregion

		#region FormControl

		internal System.Windows.Forms.TextBox m_txtPatCardID;
		internal System.Windows.Forms.Label lblPatCardID;
		internal System.Windows.Forms.ListView m_lsvAppl;
		internal System.Windows.Forms.ColumnHeader m_chdApplID;
		internal System.Windows.Forms.ColumnHeader m_chdPatName;
		internal System.Windows.Forms.ListView m_lsvPatFussQuery;
		internal System.Windows.Forms.ColumnHeader m_chdPatNO;
		internal System.Windows.Forms.ColumnHeader m_chdPatCardID;
		internal System.Windows.Forms.ColumnHeader m_chdPatientName;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_dtpApplBegin;
		internal System.Windows.Forms.DateTimePicker m_dtpApplEnd;
		internal System.Windows.Forms.RadioButton m_rdbNotSend;
		internal System.Windows.Forms.RadioButton m_rdbHaveSended;
		internal System.Windows.Forms.RadioButton m_rdbAll;
		internal System.Windows.Forms.Label lblApplDate;
		internal System.Windows.Forms.ColumnHeader m_chdSendStatus;
		internal System.Windows.Forms.ContextMenu m_ctmSendAppl;
		internal System.Windows.Forms.MenuItem m_miSend;
		internal System.Windows.Forms.GroupBox m_grpPatientInfo;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtInhospNO;
		internal System.Windows.Forms.CheckBox m_chkSpecial;
		internal System.Windows.Forms.CheckBox m_chkEmergency;
		internal System.Windows.Forms.Label label17;
		internal ctlLISPatientTypeComboBox m_cboPatientType;
		internal System.Windows.Forms.ComboBox m_cboAgeUnit;
		internal System.Windows.Forms.RichTextBox m_rtbDiagnose;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtBedNO;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label lbDiagnose;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtAge;
		internal System.Windows.Forms.ComboBox m_cboSex;
		internal System.Windows.Forms.Label m_lblAgeTitle;
		internal System.Windows.Forms.Label lbSex;
		internal System.Windows.Forms.Label m_lblPatientName;
		internal System.Windows.Forms.Label lbApplDept;
		internal System.Windows.Forms.Label lbApplEmp;
		internal System.Windows.Forms.Label label20;
		internal System.Windows.Forms.RichTextBox m_rtbAppSummary;
		internal System.Windows.Forms.TextBox m_txtAppNO;
		private System.Windows.Forms.Label label11;
		internal System.Windows.Forms.TextBox m_txtPatName;
		internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDept;
		internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
		internal PinkieControls.ButtonXP m_btnNew;
		internal PinkieControls.ButtonXP m_btnModify;
		internal PinkieControls.ButtonXP m_btnSave;
		internal PinkieControls.ButtonXP m_btnDelete;
		internal PinkieControls.ButtonXP m_btnSend;
		internal System.Windows.Forms.GroupBox m_gpbQuery;
		private System.Windows.Forms.Panel m_palButtons;
		private System.Windows.Forms.Panel m_palHead;
		private System.Windows.Forms.Panel m_palBottom;
		private System.Windows.Forms.Panel m_palMiddle;
		private System.Windows.Forms.Panel m_palMiddleLeft;
		internal System.Windows.Forms.DateTimePicker m_dtpAppDate;
		internal System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView m_lsvCheckInfo;
		internal PinkieControls.ButtonXP m_btnQuery;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		internal PinkieControls.ButtonXP m_btnNewItem;
		internal PinkieControls.ButtonXP m_btnDeleteItem;
		private System.Windows.Forms.ColumnHeader m_chdInPatientID;
		private System.Windows.Forms.MenuItem menuItem1;
		internal com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox m_cboSampleType;
		internal System.Windows.Forms.TextBox m_txtPatientID;
		internal System.Windows.Forms.Label label7;
		internal PinkieControls.ButtonXP m_btnPint;
		internal PinkieControls.ButtonXP m_btnPreview;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.ListView m_lsvChargeInfo;
		private System.Windows.Forms.TextBox m_txtCheckContent;
		private System.Windows.Forms.GroupBox groupBox2;
		internal PinkieControls.ButtonXP m_btnEsc;
		internal System.Windows.Forms.ColumnHeader chName;
		internal System.Windows.Forms.ColumnHeader chPrice;
		private System.Windows.Forms.ColumnHeader cnSpec;
		private System.Windows.Forms.ColumnHeader chNum;
		private System.Windows.Forms.ColumnHeader chPercent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label m_lblChargeState;//需要修改的申请单的ID

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 构造函数
		public frmLisAppl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		}

		#endregion

		#region override
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

		public override void CreateController()
		{
			this.objController= new com.digitalwave.iCare.gui.LIS.clsController_Appl();
			m_objController = (clsController_Appl)objController;
			this.objController.Set_GUI_Apperance(this);
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_txtPatCardID = new System.Windows.Forms.TextBox();
            this.lblPatCardID = new System.Windows.Forms.Label();
            this.m_lsvAppl = new System.Windows.Forms.ListView();
            this.m_chdApplID = new System.Windows.Forms.ColumnHeader();
            this.m_chdPatName = new System.Windows.Forms.ColumnHeader();
            this.m_chdSendStatus = new System.Windows.Forms.ColumnHeader();
            this.m_ctmSendAppl = new System.Windows.Forms.ContextMenu();
            this.m_miSend = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.m_lsvPatFussQuery = new System.Windows.Forms.ListView();
            this.m_chdPatNO = new System.Windows.Forms.ColumnHeader();
            this.m_chdPatCardID = new System.Windows.Forms.ColumnHeader();
            this.m_chdInPatientID = new System.Windows.Forms.ColumnHeader();
            this.m_chdPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_dtpApplBegin = new System.Windows.Forms.DateTimePicker();
            this.m_dtpApplEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_rdbNotSend = new System.Windows.Forms.RadioButton();
            this.m_rdbHaveSended = new System.Windows.Forms.RadioButton();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.m_gpbQuery = new System.Windows.Forms.GroupBox();
            this.m_txtCheckContent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtPatientID = new System.Windows.Forms.TextBox();
            this.lblApplDate = new System.Windows.Forms.Label();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.m_cboSampleType = new com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox();
            this.m_dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtInhospNO = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label17 = new System.Windows.Forms.Label();
            this.m_cboPatientType = new com.digitalwave.iCare.gui.LIS.ctlLISPatientTypeComboBox();
            this.m_cboAgeUnit = new System.Windows.Forms.ComboBox();
            this.m_rtbDiagnose = new System.Windows.Forms.RichTextBox();
            this.m_txtBedNO = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtAge = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_cboSex = new System.Windows.Forms.ComboBox();
            this.m_lblAgeTitle = new System.Windows.Forms.Label();
            this.lbSex = new System.Windows.Forms.Label();
            this.m_txtPatName = new System.Windows.Forms.TextBox();
            this.m_lblPatientName = new System.Windows.Forms.Label();
            this.m_txtAppDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.lbApplDept = new System.Windows.Forms.Label();
            this.lbApplEmp = new System.Windows.Forms.Label();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_rtbAppSummary = new System.Windows.Forms.RichTextBox();
            this.m_txtAppNO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDiagnose = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_chkSpecial = new System.Windows.Forms.CheckBox();
            this.m_chkEmergency = new System.Windows.Forms.CheckBox();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.m_btnModify = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnDelete = new PinkieControls.ButtonXP();
            this.m_btnSend = new PinkieControls.ButtonXP();
            this.m_palButtons = new System.Windows.Forms.Panel();
            this.m_btnEsc = new PinkieControls.ButtonXP();
            this.m_btnPreview = new PinkieControls.ButtonXP();
            this.m_btnPint = new PinkieControls.ButtonXP();
            this.m_palHead = new System.Windows.Forms.Panel();
            this.m_palBottom = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_palMiddle = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblChargeState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnNewItem = new PinkieControls.ButtonXP();
            this.m_btnDeleteItem = new PinkieControls.ButtonXP();
            this.m_lsvCheckInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_lsvChargeInfo = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.cnSpec = new System.Windows.Forms.ColumnHeader();
            this.chNum = new System.Windows.Forms.ColumnHeader();
            this.chPrice = new System.Windows.Forms.ColumnHeader();
            this.chPercent = new System.Windows.Forms.ColumnHeader();
            this.m_palMiddleLeft = new System.Windows.Forms.Panel();
            this.m_gpbQuery.SuspendLayout();
            this.m_grpPatientInfo.SuspendLayout();
            this.m_palButtons.SuspendLayout();
            this.m_palHead.SuspendLayout();
            this.m_palBottom.SuspendLayout();
            this.m_palMiddle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_palMiddleLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtPatCardID
            // 
            this.m_txtPatCardID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPatCardID.Location = new System.Drawing.Point(772, 16);
            this.m_txtPatCardID.MaxLength = 8;
            this.m_txtPatCardID.Name = "m_txtPatCardID";
            this.m_txtPatCardID.Size = new System.Drawing.Size(96, 23);
            this.m_txtPatCardID.TabIndex = 27;
            this.m_txtPatCardID.Visible = false;
            this.m_txtPatCardID.Leave += new System.EventHandler(this.m_txtPatCardID_Leave);
            this.m_txtPatCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatCardID_KeyDown);
            // 
            // lblPatCardID
            // 
            this.lblPatCardID.AutoSize = true;
            this.lblPatCardID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblPatCardID.Location = new System.Drawing.Point(692, 20);
            this.lblPatCardID.Name = "lblPatCardID";
            this.lblPatCardID.Size = new System.Drawing.Size(63, 14);
            this.lblPatCardID.TabIndex = 0;
            this.lblPatCardID.Text = "就诊卡号";
            this.lblPatCardID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPatCardID.Visible = false;
            // 
            // m_lsvAppl
            // 
            this.m_lsvAppl.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_lsvAppl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvAppl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chdApplID,
            this.m_chdPatName,
            this.m_chdSendStatus});
            this.m_lsvAppl.FullRowSelect = true;
            this.m_lsvAppl.GridLines = true;
            this.m_lsvAppl.HideSelection = false;
            this.m_lsvAppl.Location = new System.Drawing.Point(8, 30);
            this.m_lsvAppl.MultiSelect = false;
            this.m_lsvAppl.Name = "m_lsvAppl";
            this.m_lsvAppl.Size = new System.Drawing.Size(236, 454);
            this.m_lsvAppl.TabIndex = 2;
            this.m_lsvAppl.UseCompatibleStateImageBehavior = false;
            this.m_lsvAppl.View = System.Windows.Forms.View.Details;
            this.m_lsvAppl.SelectedIndexChanged += new System.EventHandler(this.m_lsvAppl_SelectedIndexChanged);
            this.m_lsvAppl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvAppl_MouseUp);
            // 
            // m_chdApplID
            // 
            this.m_chdApplID.Text = "申请单号";
            this.m_chdApplID.Width = 82;
            // 
            // m_chdPatName
            // 
            this.m_chdPatName.Text = "病人姓名";
            this.m_chdPatName.Width = 77;
            // 
            // m_chdSendStatus
            // 
            this.m_chdSendStatus.Text = "状态";
            this.m_chdSendStatus.Width = 58;
            // 
            // m_ctmSendAppl
            // 
            this.m_ctmSendAppl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_miSend,
            this.menuItem1});
            // 
            // m_miSend
            // 
            this.m_miSend.Index = 0;
            this.m_miSend.Text = "发  送";
            this.m_miSend.Click += new System.EventHandler(this.m_miSend_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "删除";
            // 
            // m_lsvPatFussQuery
            // 
            this.m_lsvPatFussQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvPatFussQuery.BackColor = System.Drawing.SystemColors.Info;
            this.m_lsvPatFussQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvPatFussQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chdPatNO,
            this.m_chdPatCardID,
            this.m_chdInPatientID,
            this.m_chdPatientName});
            this.m_lsvPatFussQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lsvPatFussQuery.FullRowSelect = true;
            this.m_lsvPatFussQuery.GridLines = true;
            this.m_lsvPatFussQuery.HideSelection = false;
            this.m_lsvPatFussQuery.Location = new System.Drawing.Point(204, 112);
            this.m_lsvPatFussQuery.MultiSelect = false;
            this.m_lsvPatFussQuery.Name = "m_lsvPatFussQuery";
            this.m_lsvPatFussQuery.Size = new System.Drawing.Size(444, 96);
            this.m_lsvPatFussQuery.TabIndex = 5;
            this.m_lsvPatFussQuery.TabStop = false;
            this.m_lsvPatFussQuery.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatFussQuery.View = System.Windows.Forms.View.Details;
            this.m_lsvPatFussQuery.Visible = false;
            this.m_lsvPatFussQuery.DoubleClick += new System.EventHandler(this.m_lsvPatFussQuery_DoubleClick);
            this.m_lsvPatFussQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvPatFussQuery_KeyDown);
            this.m_lsvPatFussQuery.Leave += new System.EventHandler(this.m_lsvPatFussQuery_Leave);
            // 
            // m_chdPatNO
            // 
            this.m_chdPatNO.Text = "病人编号";
            this.m_chdPatNO.Width = 110;
            // 
            // m_chdPatCardID
            // 
            this.m_chdPatCardID.Text = "就诊卡号";
            this.m_chdPatCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_chdPatCardID.Width = 110;
            // 
            // m_chdInPatientID
            // 
            this.m_chdInPatientID.Text = "住院号";
            this.m_chdInPatientID.Width = 110;
            // 
            // m_chdPatientName
            // 
            this.m_chdPatientName.Text = "病人姓名";
            this.m_chdPatientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_chdPatientName.Width = 100;
            // 
            // m_dtpApplBegin
            // 
            this.m_dtpApplBegin.CustomFormat = "yyyy-MM-dd";
            this.m_dtpApplBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpApplBegin.Location = new System.Drawing.Point(74, 24);
            this.m_dtpApplBegin.Name = "m_dtpApplBegin";
            this.m_dtpApplBegin.Size = new System.Drawing.Size(94, 23);
            this.m_dtpApplBegin.TabIndex = 8;
            // 
            // m_dtpApplEnd
            // 
            this.m_dtpApplEnd.CustomFormat = "yyyy-MM-dd";
            this.m_dtpApplEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpApplEnd.Location = new System.Drawing.Point(204, 24);
            this.m_dtpApplEnd.Name = "m_dtpApplEnd";
            this.m_dtpApplEnd.Size = new System.Drawing.Size(96, 23);
            this.m_dtpApplEnd.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "至";
            // 
            // m_rdbNotSend
            // 
            this.m_rdbNotSend.Checked = true;
            this.m_rdbNotSend.Location = new System.Drawing.Point(316, 24);
            this.m_rdbNotSend.Name = "m_rdbNotSend";
            this.m_rdbNotSend.Size = new System.Drawing.Size(72, 24);
            this.m_rdbNotSend.TabIndex = 10;
            this.m_rdbNotSend.TabStop = true;
            this.m_rdbNotSend.Text = "未发送";
            // 
            // m_rdbHaveSended
            // 
            this.m_rdbHaveSended.Location = new System.Drawing.Point(380, 24);
            this.m_rdbHaveSended.Name = "m_rdbHaveSended";
            this.m_rdbHaveSended.Size = new System.Drawing.Size(72, 24);
            this.m_rdbHaveSended.TabIndex = 10;
            this.m_rdbHaveSended.Text = "已发送";
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.Location = new System.Drawing.Point(444, 24);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(56, 24);
            this.m_rdbAll.TabIndex = 10;
            this.m_rdbAll.Text = "全部";
            // 
            // m_gpbQuery
            // 
            this.m_gpbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbQuery.Controls.Add(this.m_txtCheckContent);
            this.m_gpbQuery.Controls.Add(this.label7);
            this.m_gpbQuery.Controls.Add(this.m_txtPatientID);
            this.m_gpbQuery.Controls.Add(this.lblApplDate);
            this.m_gpbQuery.Controls.Add(this.label1);
            this.m_gpbQuery.Controls.Add(this.m_dtpApplEnd);
            this.m_gpbQuery.Controls.Add(this.m_rdbAll);
            this.m_gpbQuery.Controls.Add(this.m_rdbHaveSended);
            this.m_gpbQuery.Controls.Add(this.m_rdbNotSend);
            this.m_gpbQuery.Controls.Add(this.m_dtpApplBegin);
            this.m_gpbQuery.Controls.Add(this.m_btnQuery);
            this.m_gpbQuery.Controls.Add(this.m_txtPatCardID);
            this.m_gpbQuery.Controls.Add(this.lblPatCardID);
            this.m_gpbQuery.Location = new System.Drawing.Point(12, 12);
            this.m_gpbQuery.Name = "m_gpbQuery";
            this.m_gpbQuery.Size = new System.Drawing.Size(952, 60);
            this.m_gpbQuery.TabIndex = 1;
            this.m_gpbQuery.TabStop = false;
            this.m_gpbQuery.Text = "查询";
            // 
            // m_txtCheckContent
            // 
            this.m_txtCheckContent.Location = new System.Drawing.Point(624, 16);
            this.m_txtCheckContent.Name = "m_txtCheckContent";
            this.m_txtCheckContent.Size = new System.Drawing.Size(56, 23);
            this.m_txtCheckContent.TabIndex = 122;
            this.m_txtCheckContent.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(748, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 121;
            this.label7.Text = "患者ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // m_txtPatientID
            // 
            this.m_txtPatientID.Location = new System.Drawing.Point(828, 20);
            this.m_txtPatientID.Name = "m_txtPatientID";
            this.m_txtPatientID.Size = new System.Drawing.Size(100, 23);
            this.m_txtPatientID.TabIndex = 120;
            this.m_txtPatientID.Visible = false;
            // 
            // lblApplDate
            // 
            this.lblApplDate.Location = new System.Drawing.Point(10, 29);
            this.lblApplDate.Name = "lblApplDate";
            this.lblApplDate.Size = new System.Drawing.Size(64, 16);
            this.lblApplDate.TabIndex = 15;
            this.lblApplDate.Text = "申请日期";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(520, 16);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(80, 32);
            this.m_btnQuery.TabIndex = 119;
            this.m_btnQuery.Text = "查询(F2)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_grpPatientInfo
            // 
            this.m_grpPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_grpPatientInfo.Controls.Add(this.m_cboSampleType);
            this.m_grpPatientInfo.Controls.Add(this.m_dtpAppDate);
            this.m_grpPatientInfo.Controls.Add(this.label3);
            this.m_grpPatientInfo.Controls.Add(this.m_txtInhospNO);
            this.m_grpPatientInfo.Controls.Add(this.label17);
            this.m_grpPatientInfo.Controls.Add(this.m_cboPatientType);
            this.m_grpPatientInfo.Controls.Add(this.m_cboAgeUnit);
            this.m_grpPatientInfo.Controls.Add(this.m_rtbDiagnose);
            this.m_grpPatientInfo.Controls.Add(this.m_txtBedNO);
            this.m_grpPatientInfo.Controls.Add(this.label5);
            this.m_grpPatientInfo.Controls.Add(this.label4);
            this.m_grpPatientInfo.Controls.Add(this.m_txtAge);
            this.m_grpPatientInfo.Controls.Add(this.m_cboSex);
            this.m_grpPatientInfo.Controls.Add(this.m_lblAgeTitle);
            this.m_grpPatientInfo.Controls.Add(this.lbSex);
            this.m_grpPatientInfo.Controls.Add(this.m_txtPatName);
            this.m_grpPatientInfo.Controls.Add(this.m_lblPatientName);
            this.m_grpPatientInfo.Controls.Add(this.m_txtAppDept);
            this.m_grpPatientInfo.Controls.Add(this.lbApplDept);
            this.m_grpPatientInfo.Controls.Add(this.lbApplEmp);
            this.m_grpPatientInfo.Controls.Add(this.m_txtAppDoct);
            this.m_grpPatientInfo.Controls.Add(this.m_rtbAppSummary);
            this.m_grpPatientInfo.Controls.Add(this.m_txtAppNO);
            this.m_grpPatientInfo.Controls.Add(this.label6);
            this.m_grpPatientInfo.Controls.Add(this.lbDiagnose);
            this.m_grpPatientInfo.Controls.Add(this.label11);
            this.m_grpPatientInfo.Controls.Add(this.label20);
            this.m_grpPatientInfo.Controls.Add(this.m_chkSpecial);
            this.m_grpPatientInfo.Controls.Add(this.m_chkEmergency);
            this.m_grpPatientInfo.Location = new System.Drawing.Point(8, 8);
            this.m_grpPatientInfo.Name = "m_grpPatientInfo";
            this.m_grpPatientInfo.Size = new System.Drawing.Size(276, 492);
            this.m_grpPatientInfo.TabIndex = 3;
            this.m_grpPatientInfo.TabStop = false;
            this.m_grpPatientInfo.Text = "患者基本信息";
            // 
            // m_cboSampleType
            // 
            this.m_cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
            this.m_cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSampleType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboSampleType.Location = new System.Drawing.Point(80, 128);
            this.m_cboSampleType.Name = "m_cboSampleType";
            this.m_cboSampleType.Size = new System.Drawing.Size(180, 22);
            this.m_cboSampleType.TabIndex = 5;
            this.m_cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
            // 
            // m_dtpAppDate
            // 
            this.m_dtpAppDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpAppDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAppDate.Location = new System.Drawing.Point(80, 224);
            this.m_dtpAppDate.Name = "m_dtpAppDate";
            this.m_dtpAppDate.Size = new System.Drawing.Size(180, 23);
            this.m_dtpAppDate.TabIndex = 9;
            this.m_dtpAppDate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 119;
            this.label3.Text = "申请日期";
            // 
            // m_txtInhospNO
            // 
            this.m_txtInhospNO.EnableAutoValidation = true;
            this.m_txtInhospNO.EnableEnterKeyValidate = true;
            this.m_txtInhospNO.EnableEscapeKeyUndo = true;
            this.m_txtInhospNO.EnableLastValidValue = true;
            this.m_txtInhospNO.ErrorProvider = null;
            this.m_txtInhospNO.ErrorProviderMessage = "Invalid value";
            this.m_txtInhospNO.ForceFormatText = true;
            this.m_txtInhospNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtInhospNO.Location = new System.Drawing.Point(80, 32);
            this.m_txtInhospNO.MaxLength = 12;
            this.m_txtInhospNO.Name = "m_txtInhospNO";
            this.m_txtInhospNO.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.InfinitySymbol;
            this.m_txtInhospNO.Size = new System.Drawing.Size(180, 23);
            this.m_txtInhospNO.TabIndex = 0;
            this.m_txtInhospNO.Text = "222444555666";
            this.m_txtInhospNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtInhospNO.Leave += new System.EventHandler(this.m_txtInhospNO_Leave);
            this.m_txtInhospNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtInhospNO_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 256);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 114;
            this.label17.Text = "病人类型";
            // 
            // m_cboPatientType
            // 
            this.m_cboPatientType.DisplayMember = "DICTNAME_VCHR";
            this.m_cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientType.Location = new System.Drawing.Point(80, 248);
            this.m_cboPatientType.Name = "m_cboPatientType";
            this.m_cboPatientType.Size = new System.Drawing.Size(180, 22);
            this.m_cboPatientType.TabIndex = 10;
            this.m_cboPatientType.ValueMember = "DICTID_CHR";
            // 
            // m_cboAgeUnit
            // 
            this.m_cboAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboAgeUnit.Location = new System.Drawing.Point(168, 104);
            this.m_cboAgeUnit.Name = "m_cboAgeUnit";
            this.m_cboAgeUnit.Size = new System.Drawing.Size(92, 22);
            this.m_cboAgeUnit.TabIndex = 4;
            // 
            // m_rtbDiagnose
            // 
            this.m_rtbDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtbDiagnose.Location = new System.Drawing.Point(80, 272);
            this.m_rtbDiagnose.MaxLength = 255;
            this.m_rtbDiagnose.Name = "m_rtbDiagnose";
            this.m_rtbDiagnose.Size = new System.Drawing.Size(180, 112);
            this.m_rtbDiagnose.TabIndex = 13;
            this.m_rtbDiagnose.Text = "";
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.EnableAutoValidation = true;
            this.m_txtBedNO.EnableEnterKeyValidate = true;
            this.m_txtBedNO.EnableEscapeKeyUndo = true;
            this.m_txtBedNO.EnableLastValidValue = true;
            this.m_txtBedNO.ErrorProvider = null;
            this.m_txtBedNO.ErrorProviderMessage = "Invalid value";
            this.m_txtBedNO.ForceFormatText = true;
            this.m_txtBedNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtBedNO.Location = new System.Drawing.Point(80, 176);
            this.m_txtBedNO.MaxLength = 4;
            this.m_txtBedNO.Name = "m_txtBedNO";
            this.m_txtBedNO.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.InfinitySymbol;
            this.m_txtBedNO.Size = new System.Drawing.Size(180, 23);
            this.m_txtBedNO.TabIndex = 7;
            this.m_txtBedNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "床号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 89;
            this.label4.Text = "住院号";
            // 
            // m_txtAge
            // 
            this.m_txtAge.EnableAutoValidation = true;
            this.m_txtAge.EnableEnterKeyValidate = true;
            this.m_txtAge.EnableEscapeKeyUndo = true;
            this.m_txtAge.EnableLastValidValue = true;
            this.m_txtAge.ErrorProvider = null;
            this.m_txtAge.ErrorProviderMessage = "Invalid value";
            this.m_txtAge.ForceFormatText = true;
            this.m_txtAge.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtAge.Location = new System.Drawing.Point(80, 104);
            this.m_txtAge.MaxLength = 3;
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtAge.Size = new System.Drawing.Size(88, 23);
            this.m_txtAge.TabIndex = 3;
            this.m_txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_cboSex
            // 
            this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知",
            "未明"});
            this.m_cboSex.Location = new System.Drawing.Point(80, 80);
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(180, 22);
            this.m_cboSex.TabIndex = 2;
            // 
            // m_lblAgeTitle
            // 
            this.m_lblAgeTitle.AutoSize = true;
            this.m_lblAgeTitle.Location = new System.Drawing.Point(36, 112);
            this.m_lblAgeTitle.Name = "m_lblAgeTitle";
            this.m_lblAgeTitle.Size = new System.Drawing.Size(42, 14);
            this.m_lblAgeTitle.TabIndex = 108;
            this.m_lblAgeTitle.Text = "年 龄";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(40, 88);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(35, 14);
            this.lbSex.TabIndex = 107;
            this.lbSex.Text = "性别";
            // 
            // m_txtPatName
            // 
            this.m_txtPatName.Location = new System.Drawing.Point(80, 56);
            this.m_txtPatName.MaxLength = 50;
            this.m_txtPatName.Name = "m_txtPatName";
            this.m_txtPatName.Size = new System.Drawing.Size(180, 23);
            this.m_txtPatName.TabIndex = 1;
            this.m_txtPatName.Leave += new System.EventHandler(this.m_txtPatName_Leave);
            this.m_txtPatName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatName_KeyDown);
            // 
            // m_lblPatientName
            // 
            this.m_lblPatientName.AutoSize = true;
            this.m_lblPatientName.Location = new System.Drawing.Point(12, 64);
            this.m_lblPatientName.Name = "m_lblPatientName";
            this.m_lblPatientName.Size = new System.Drawing.Size(63, 14);
            this.m_lblPatientName.TabIndex = 106;
            this.m_lblPatientName.Text = "患者姓名";
            this.m_lblPatientName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_txtAppDept
            // 
            this.m_txtAppDept.EnableAutoValidation = true;
            this.m_txtAppDept.EnableEnterKeyValidate = true;
            this.m_txtAppDept.EnableEscapeKeyUndo = true;
            this.m_txtAppDept.EnableLastValidValue = true;
            this.m_txtAppDept.ErrorProvider = null;
            this.m_txtAppDept.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDept.ForceFormatText = true;
            this.m_txtAppDept.Location = new System.Drawing.Point(80, 152);
            this.m_txtAppDept.m_StrDeptID = null;
            this.m_txtAppDept.m_StrDeptName = null;
            this.m_txtAppDept.MaxLength = 20;
            this.m_txtAppDept.Name = "m_txtAppDept";
            this.m_txtAppDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDept.Size = new System.Drawing.Size(180, 23);
            this.m_txtAppDept.TabIndex = 6;
            this.m_txtAppDept.evtValueChanged += new com.digitalwave.Utility.dlgExValueChangedEventHandler(this.m_txtAppDept_evtValueChanged);
            // 
            // lbApplDept
            // 
            this.lbApplDept.AutoSize = true;
            this.lbApplDept.Location = new System.Drawing.Point(16, 160);
            this.lbApplDept.Name = "lbApplDept";
            this.lbApplDept.Size = new System.Drawing.Size(63, 14);
            this.lbApplDept.TabIndex = 82;
            this.lbApplDept.Text = "申请科室";
            // 
            // lbApplEmp
            // 
            this.lbApplEmp.AutoSize = true;
            this.lbApplEmp.Location = new System.Drawing.Point(16, 208);
            this.lbApplEmp.Name = "lbApplEmp";
            this.lbApplEmp.Size = new System.Drawing.Size(63, 14);
            this.lbApplEmp.TabIndex = 80;
            this.lbApplEmp.Text = "申请医生";
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.Location = new System.Drawing.Point(80, 200);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "*";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.Size = new System.Drawing.Size(180, 23);
            this.m_txtAppDoct.TabIndex = 8;
            // 
            // m_rtbAppSummary
            // 
            this.m_rtbAppSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rtbAppSummary.Location = new System.Drawing.Point(80, 384);
            this.m_rtbAppSummary.MaxLength = 200;
            this.m_rtbAppSummary.Name = "m_rtbAppSummary";
            this.m_rtbAppSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.m_rtbAppSummary.Size = new System.Drawing.Size(180, 44);
            this.m_rtbAppSummary.TabIndex = 14;
            this.m_rtbAppSummary.Text = "";
            // 
            // m_txtAppNO
            // 
            this.m_txtAppNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAppNO.Enabled = false;
            this.m_txtAppNO.Location = new System.Drawing.Point(80, 428);
            this.m_txtAppNO.MaxLength = 18;
            this.m_txtAppNO.Name = "m_txtAppNO";
            this.m_txtAppNO.Size = new System.Drawing.Size(180, 23);
            this.m_txtAppNO.TabIndex = 15;
            this.m_txtAppNO.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 121;
            this.label6.Text = "样本类型";
            // 
            // lbDiagnose
            // 
            this.lbDiagnose.AutoSize = true;
            this.lbDiagnose.Location = new System.Drawing.Point(16, 278);
            this.lbDiagnose.Name = "lbDiagnose";
            this.lbDiagnose.Size = new System.Drawing.Size(63, 14);
            this.lbDiagnose.TabIndex = 84;
            this.lbDiagnose.Text = "临床诊断";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 432);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 105;
            this.label11.Text = "申请单号";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 396);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 14);
            this.label20.TabIndex = 113;
            this.label20.Text = "附加备注";
            // 
            // m_chkSpecial
            // 
            this.m_chkSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkSpecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkSpecial.Location = new System.Drawing.Point(168, 456);
            this.m_chkSpecial.Name = "m_chkSpecial";
            this.m_chkSpecial.Size = new System.Drawing.Size(88, 24);
            this.m_chkSpecial.TabIndex = 12;
            this.m_chkSpecial.Text = "特殊处理";
            this.m_chkSpecial.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_chkEmergency
            // 
            this.m_chkEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkEmergency.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkEmergency.Location = new System.Drawing.Point(108, 456);
            this.m_chkEmergency.Name = "m_chkEmergency";
            this.m_chkEmergency.Size = new System.Drawing.Size(56, 24);
            this.m_chkEmergency.TabIndex = 11;
            this.m_chkEmergency.Text = "急诊";
            this.m_chkEmergency.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(204, 12);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(76, 32);
            this.m_btnNew.TabIndex = 2;
            this.m_btnNew.Text = "新增(F5)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // m_btnModify
            // 
            this.m_btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnModify.DefaultScheme = true;
            this.m_btnModify.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnModify.Hint = "";
            this.m_btnModify.Location = new System.Drawing.Point(368, 12);
            this.m_btnModify.Name = "m_btnModify";
            this.m_btnModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnModify.Size = new System.Drawing.Size(76, 32);
            this.m_btnModify.TabIndex = 4;
            this.m_btnModify.Text = "修改(F7)";
            this.m_btnModify.Click += new System.EventHandler(this.m_btnModify_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(450, 12);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(76, 32);
            this.m_btnSave.TabIndex = 5;
            this.m_btnSave.Text = "保存(F8)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDelete.DefaultScheme = true;
            this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelete.Hint = "";
            this.m_btnDelete.Location = new System.Drawing.Point(286, 12);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelete.Size = new System.Drawing.Size(76, 32);
            this.m_btnDelete.TabIndex = 3;
            this.m_btnDelete.Text = "删除(F6)";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_btnSend
            // 
            this.m_btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSend.DefaultScheme = true;
            this.m_btnSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSend.Hint = "";
            this.m_btnSend.Location = new System.Drawing.Point(532, 12);
            this.m_btnSend.Name = "m_btnSend";
            this.m_btnSend.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSend.Size = new System.Drawing.Size(76, 32);
            this.m_btnSend.TabIndex = 6;
            this.m_btnSend.Text = "发送(F9)";
            this.m_btnSend.Click += new System.EventHandler(this.m_btnSend_Click);
            // 
            // m_palButtons
            // 
            this.m_palButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_palButtons.Controls.Add(this.m_btnEsc);
            this.m_palButtons.Controls.Add(this.m_btnPreview);
            this.m_palButtons.Controls.Add(this.m_btnNew);
            this.m_palButtons.Controls.Add(this.m_btnDelete);
            this.m_palButtons.Controls.Add(this.m_btnSend);
            this.m_palButtons.Controls.Add(this.m_btnSave);
            this.m_palButtons.Controls.Add(this.m_btnModify);
            this.m_palButtons.Controls.Add(this.m_btnPint);
            this.m_palButtons.Location = new System.Drawing.Point(232, 4);
            this.m_palButtons.Name = "m_palButtons";
            this.m_palButtons.Size = new System.Drawing.Size(704, 56);
            this.m_palButtons.TabIndex = 22;
            // 
            // m_btnEsc
            // 
            this.m_btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnEsc.DefaultScheme = true;
            this.m_btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnEsc.Hint = "";
            this.m_btnEsc.Location = new System.Drawing.Point(616, 12);
            this.m_btnEsc.Name = "m_btnEsc";
            this.m_btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnEsc.Size = new System.Drawing.Size(76, 32);
            this.m_btnEsc.TabIndex = 7;
            this.m_btnEsc.Text = "退出(Esc)";
            this.m_btnEsc.Click += new System.EventHandler(this.m_btnEsc_Click);
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPreview.DefaultScheme = true;
            this.m_btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreview.Enabled = false;
            this.m_btnPreview.Hint = "";
            this.m_btnPreview.Location = new System.Drawing.Point(40, 12);
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreview.Size = new System.Drawing.Size(76, 32);
            this.m_btnPreview.TabIndex = 0;
            this.m_btnPreview.Text = "预览(F3)";
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // m_btnPint
            // 
            this.m_btnPint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPint.DefaultScheme = true;
            this.m_btnPint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPint.Enabled = false;
            this.m_btnPint.Hint = "";
            this.m_btnPint.Location = new System.Drawing.Point(122, 12);
            this.m_btnPint.Name = "m_btnPint";
            this.m_btnPint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPint.Size = new System.Drawing.Size(76, 32);
            this.m_btnPint.TabIndex = 1;
            this.m_btnPint.Text = "打印(F4)";
            this.m_btnPint.Click += new System.EventHandler(this.m_btnPint_Click);
            // 
            // m_palHead
            // 
            this.m_palHead.Controls.Add(this.m_gpbQuery);
            this.m_palHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_palHead.Location = new System.Drawing.Point(0, 0);
            this.m_palHead.Name = "m_palHead";
            this.m_palHead.Size = new System.Drawing.Size(968, 76);
            this.m_palHead.TabIndex = 23;
            // 
            // m_palBottom
            // 
            this.m_palBottom.Controls.Add(this.panel1);
            this.m_palBottom.Controls.Add(this.m_palButtons);
            this.m_palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_palBottom.Location = new System.Drawing.Point(0, 581);
            this.m_palBottom.Name = "m_palBottom";
            this.m_palBottom.Size = new System.Drawing.Size(968, 68);
            this.m_palBottom.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 4);
            this.panel1.TabIndex = 23;
            // 
            // m_palMiddle
            // 
            this.m_palMiddle.Controls.Add(this.m_lsvPatFussQuery);
            this.m_palMiddle.Controls.Add(this.groupBox2);
            this.m_palMiddle.Controls.Add(this.groupBox1);
            this.m_palMiddle.Controls.Add(this.m_palMiddleLeft);
            this.m_palMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palMiddle.Location = new System.Drawing.Point(0, 76);
            this.m_palMiddle.Name = "m_palMiddle";
            this.m_palMiddle.Size = new System.Drawing.Size(968, 505);
            this.m_palMiddle.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.m_lsvAppl);
            this.groupBox2.Location = new System.Drawing.Point(712, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 492);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_lblChargeState);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_btnNewItem);
            this.groupBox1.Controls.Add(this.m_btnDeleteItem);
            this.groupBox1.Controls.Add(this.m_lsvCheckInfo);
            this.groupBox1.Controls.Add(this.m_lsvChargeInfo);
            this.groupBox1.Location = new System.Drawing.Point(296, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 492);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检验内容";
            // 
            // m_lblChargeState
            // 
            this.m_lblChargeState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblChargeState.Location = new System.Drawing.Point(88, 296);
            this.m_lblChargeState.Name = "m_lblChargeState";
            this.m_lblChargeState.Size = new System.Drawing.Size(100, 23);
            this.m_lblChargeState.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "收费状态:";
            // 
            // m_btnNewItem
            // 
            this.m_btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNewItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNewItem.DefaultScheme = true;
            this.m_btnNewItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNewItem.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnNewItem.Hint = "";
            this.m_btnNewItem.Location = new System.Drawing.Point(244, 288);
            this.m_btnNewItem.Name = "m_btnNewItem";
            this.m_btnNewItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNewItem.Size = new System.Drawing.Size(136, 28);
            this.m_btnNewItem.TabIndex = 5;
            this.m_btnNewItem.Text = "检验项目(F12)";
            this.m_btnNewItem.Click += new System.EventHandler(this.m_btnNewItem_Click);
            // 
            // m_btnDeleteItem
            // 
            this.m_btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDeleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDeleteItem.DefaultScheme = true;
            this.m_btnDeleteItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDeleteItem.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnDeleteItem.Hint = "";
            this.m_btnDeleteItem.Location = new System.Drawing.Point(208, 284);
            this.m_btnDeleteItem.Name = "m_btnDeleteItem";
            this.m_btnDeleteItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDeleteItem.Size = new System.Drawing.Size(24, 28);
            this.m_btnDeleteItem.TabIndex = 6;
            this.m_btnDeleteItem.Text = "删除项目";
            this.m_btnDeleteItem.Visible = false;
            // 
            // m_lsvCheckInfo
            // 
            this.m_lsvCheckInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvCheckInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvCheckInfo.FullRowSelect = true;
            this.m_lsvCheckInfo.GridLines = true;
            this.m_lsvCheckInfo.HideSelection = false;
            this.m_lsvCheckInfo.Location = new System.Drawing.Point(12, 30);
            this.m_lsvCheckInfo.Name = "m_lsvCheckInfo";
            this.m_lsvCheckInfo.Size = new System.Drawing.Size(376, 246);
            this.m_lsvCheckInfo.TabIndex = 7;
            this.m_lsvCheckInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvCheckInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验项目";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "空腹";
            this.columnHeader2.Width = 68;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "体检";
            this.columnHeader3.Width = 63;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "预约";
            this.columnHeader4.Width = 65;
            // 
            // m_lsvChargeInfo
            // 
            this.m_lsvChargeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvChargeInfo.BackColor = System.Drawing.SystemColors.Info;
            this.m_lsvChargeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvChargeInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.cnSpec,
            this.chNum,
            this.chPrice,
            this.chPercent});
            this.m_lsvChargeInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lsvChargeInfo.FullRowSelect = true;
            this.m_lsvChargeInfo.GridLines = true;
            this.m_lsvChargeInfo.HideSelection = false;
            this.m_lsvChargeInfo.Location = new System.Drawing.Point(12, 328);
            this.m_lsvChargeInfo.MultiSelect = false;
            this.m_lsvChargeInfo.Name = "m_lsvChargeInfo";
            this.m_lsvChargeInfo.Size = new System.Drawing.Size(376, 156);
            this.m_lsvChargeInfo.TabIndex = 6;
            this.m_lsvChargeInfo.TabStop = false;
            this.m_lsvChargeInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvChargeInfo.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "收费项目";
            this.chName.Width = 110;
            // 
            // cnSpec
            // 
            this.cnSpec.Text = "规格";
            // 
            // chNum
            // 
            this.chNum.Text = "次数";
            // 
            // chPrice
            // 
            this.chPrice.Text = "单价";
            this.chPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPrice.Width = 70;
            // 
            // chPercent
            // 
            this.chPercent.Text = "自付比";
            this.chPercent.Width = 57;
            // 
            // m_palMiddleLeft
            // 
            this.m_palMiddleLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_palMiddleLeft.Controls.Add(this.m_grpPatientInfo);
            this.m_palMiddleLeft.Location = new System.Drawing.Point(0, 0);
            this.m_palMiddleLeft.Name = "m_palMiddleLeft";
            this.m_palMiddleLeft.Size = new System.Drawing.Size(292, 505);
            this.m_palMiddleLeft.TabIndex = 0;
            // 
            // frmLisAppl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(968, 649);
            this.Controls.Add(this.m_palMiddle);
            this.Controls.Add(this.m_palBottom);
            this.Controls.Add(this.m_palHead);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmLisAppl";
            this.Text = "检验申请";
            this.VisibleChanged += new System.EventHandler(this.frmLisAppl_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLisAppl_KeyDown);
            this.Load += new System.EventHandler(this.frmLisAppl_Load);
            this.m_gpbQuery.ResumeLayout(false);
            this.m_gpbQuery.PerformLayout();
            this.m_grpPatientInfo.ResumeLayout(false);
            this.m_grpPatientInfo.PerformLayout();
            this.m_palButtons.ResumeLayout(false);
            this.m_palHead.ResumeLayout(false);
            this.m_palBottom.ResumeLayout(false);
            this.m_palMiddle.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_palMiddleLeft.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 一般设置
		#region 快捷键设置		
		private void m_mthShortCutKey(Keys p_eumKeyCode)
		{
			if(p_eumKeyCode==Keys.F1)
			{
				
			}
			else if(p_eumKeyCode==Keys.F2 && this.m_btnQuery.Enabled && m_btnQuery.Visible)//
			{
				this.m_btnQuery_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F3 && this.m_btnPreview.Enabled && m_btnPreview.Visible)//
			{
				this.m_btnPreview_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F4 && this.m_btnPint.Enabled && m_btnPint.Visible)//
			{
				this.m_btnPint_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F5 && this.m_btnNew.Enabled && m_btnNew.Visible)//
			{
				this.m_btnNew_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F6 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//
			{
				this.m_btnDelete_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F7 && this.m_btnModify.Enabled && m_btnModify.Visible)//
			{
				this.m_btnModify_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F8 && this.m_btnSave.Enabled && m_btnSave.Visible)//
			{
				this.m_btnSave_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F9 && this.m_btnSend.Enabled && m_btnSend.Visible)//
			{
				this.m_btnSend_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.Escape && this.m_btnEsc.Enabled && m_btnEsc.Visible)//
			{
				this.m_btnEsc_Click(null,null);
			}
			else if(p_eumKeyCode==Keys.F12 && this.m_btnNewItem.Enabled && m_btnNewItem.Visible)//
			{
				this.m_btnNewItem_Click(null,null);
			}
		}
		#endregion

		#region Enter 键选择下一个
		private void m_mthEnterHandler(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}
		private void frmLisAppl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{	
			m_mthShortCutKey(e.KeyCode);			
			m_mthSetKeyTab(e);
			HideLsvFussQueryResult();	
		}


		#endregion
		#endregion

		#region 初始化
		private void m_mthInit()
		{
			this.m_mthSetFormControlCanBeNull(this);
			this.m_mthSetEnter2Tab(new Control[]{this.m_txtInhospNO,this.m_txtAppDoct,this.m_txtPatName,
													this.m_txtAppDept,this.m_rtbAppSummary,this.m_rtbDiagnose,
													this.m_lsvPatFussQuery});
			m_mthEnterInitStatus();
		}
		#endregion

		private void frmLisAppl_Load(object sender, System.EventArgs e)
		{
            //设置窗体的控件可以为null
			m_mthSetFormControlCanBeNull(this);
            //Tab键顺序
			m_mthSetEnter2Tab(new System.Windows.Forms.Control[]
					{
						m_dtpApplBegin,m_dtpApplEnd,m_rdbNotSend,m_rdbHaveSended,m_rdbAll,m_btnQuery,
						m_lsvAppl,m_lsvPatFussQuery,m_lsvCheckInfo,m_btnNewItem,m_btnDeleteItem,m_btnNew,this.m_txtAppDept,this.m_txtAppDoct,
						m_btnModify,m_btnDelete,m_btnSave,m_btnSend,m_txtPatName,m_txtPatientID,m_txtPatCardID,m_txtInhospNO});
			if(!this.m_blnIsDialog)
			{
				m_mthInit();
			}
		}


		#region 患者查询
		private void HideLsvFussQueryResult()
		{
			if(this.ActiveControl != this.m_lsvPatFussQuery)
			{
				if(this.m_lsvPatFussQuery.Visible == true)
				{
					this.m_lsvPatFussQuery.Visible = false;
					this.m_lsvPatFussQuery.Items.Clear();
					//					this.txtBedNo.Focus();
					//					this.cboPatientType.Focus();
				}
			}
		}

		private void m_lsvPatFussQuery_Leave(object sender, System.EventArgs e)
		{
			HideLsvFussQueryResult();
		}

		private void m_lsvPatFussQuery_DoubleClick(object sender, System.EventArgs e)
		{
			m_objController.m_mthPickPatInfo(this);			

			this.m_lsvPatFussQuery.Visible=false;
			this.m_lsvPatFussQuery.Items.Clear();
		}

		private void m_lsvPatFussQuery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				com.digitalwave.iCare.gui.LIS.clsController_Appl m_objController=(clsController_Appl)this.m_objController;
				m_objController.m_mthPickPatInfo(this);
	
				m_lsvPatFussQuery.Visible=false;
				this.m_lsvPatFussQuery.Items.Clear();
			}
		}

		private void m_txtPatNO_Leave(object sender, System.EventArgs e)
		{
			HideLsvFussQueryResult();
		}

		private void m_txtPatNO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			bool m_blnIfOK=true;
			for(int i1=0;i1<=9;i1++)
			{
				if (e.KeyChar.ToString()==i1.ToString())
				{
					m_blnIfOK=false;
					break;
				}
			}
			if(e.KeyChar==Convert.ToChar(8))return;
			if (e.KeyChar.ToString()!=Keys.Back.ToString())
				e.Handled=m_blnIfOK;         
		}
			
		private void m_txtPatCardID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				for(int i=0;i<m_txtPatCardID.Text.Length;i++)
				{
					if(m_txtPatCardID.Text[i]>255)                    
						return;
				}

				com.digitalwave.iCare.gui.LIS.clsController_Appl m_objController = (clsController_Appl)this.m_objController;
				m_objController.m_mthFussQueryPat(this,(System.Windows.Forms.Control)sender);

			}
			else if(e.KeyCode == Keys.Escape)
			{
				HideLsvFussQueryResult();											
			}		
		}

		private void m_txtPatCardID_Leave(object sender, System.EventArgs e)
		{
			if(this.m_lsvPatFussQuery.Focused)
			{
			}
			else
			{
				HideLsvFussQueryResult();
			}
		}

		private void m_txtPatName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				com.digitalwave.iCare.gui.LIS.clsController_Appl m_objController = (clsController_Appl)this.m_objController;
				m_objController.m_mthFussQueryPat(this,(System.Windows.Forms.Control)sender);
			}
			else if(e.KeyCode == Keys.Escape)
			{
				HideLsvFussQueryResult();											
			}
		}

		private void m_txtPatName_Leave(object sender, System.EventArgs e)
		{
			HideLsvFussQueryResult();		
		}

		private void m_txtInhospNO_Leave(object sender, System.EventArgs e)
		{
			HideLsvFussQueryResult();		
			
		}

		private void m_txtInhospNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				com.digitalwave.iCare.gui.LIS.clsController_Appl m_objController = (clsController_Appl)this.m_objController;
				m_objController.m_mthFussQueryPat(this,(System.Windows.Forms.Control)sender);
			}
			else if(e.KeyCode == Keys.Escape)
			{
				HideLsvFussQueryResult();											
			}		
		}
		#endregion

		private void m_txtAppDept_evtValueChanged(object sender, com.digitalwave.Utility.clsExValueChangedEventArgs e)
		{
			this.m_txtAppDoct.m_StrDeptID = this.m_txtAppDept.m_StrDeptID;
		}

		private void m_lsvAppl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_blnIsDialog)
				return;
            if (m_lsvAppl.SelectedItems.Count > 0)
            {


                m_mthEnterInitStatus();

                this.m_lvtCurrApp = this.m_lsvAppl.SelectedItems[0];
                clsLisApplMainVO objAppVO = (clsLisApplMainVO)m_lsvAppl.SelectedItems[0].Tag;
                this.m_objCurrApp = new clsLIS_App(objAppVO, true);

                //
                //取得收费信息
                //
                if (objAppVO.m_strPatientType != "1")
                {
                    long lngRes = clsDomainController_ApplicationManage.m_lngGetChargeState(objAppVO.m_strAPPLICATION_ID);
                    switch (lngRes)
                    {
                        case 0:
                            MessageBox.Show(this, "不能联接到收费系统，请与管理员联系！", c_strMessageBoxTitle);
                            objAppVO.m_intChargeState = 0;
                            break;
                        case 1:
                            objAppVO.m_intChargeState = 1;
                            break;
                        case 2:
                            objAppVO.m_intChargeState = 2;
                            break;
                        default:
                            objAppVO.m_intChargeState = 0;
                            break;
                    }
                }
                m_mthShowAppBaseInfo(objAppVO);

                clsLISAppCheckInfoItem[] objItemArr = null;
                this.m_objController.m_mthGetAppCheckInfo(objAppVO.m_strAPPLICATION_ID, out objItemArr);
                if (objItemArr != null)
                {
                    m_mthShowAppCheckInfo(objItemArr);
                }
                this.m_mthSetUIControl(false);
                if (objAppVO.m_intPStatus_int == 1)
                {
                    this.m_btnSend.Enabled = true;
                    this.m_btnSave.Enabled = false;
                    this.m_btnModify.Enabled = true;
                    this.m_btnDelete.Enabled = true;
                    this.m_btnNew.Enabled = true;
                }
                else if (objAppVO.m_intPStatus_int == 2)
                {
                    this.m_btnSend.Enabled = false;
                    this.m_btnSave.Enabled = false;
                    this.m_btnModify.Enabled = false;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnNew.Enabled = true;
                }
                this.m_btnPint.Enabled = true;
                this.m_btnPreview.Enabled = true;
            }
            else
            {
                m_mthEnterInitStatus();//清空数据

            }
		}

		private void m_lsvAppl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.m_lsvAppl.FocusedItem != null)
			{
				this.m_lsvAppl.FocusedItem.Selected = true;
			}
		}
		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			string strMessage;
			this.m_objCurrApp.m_mthDelete();
			this.m_objCurrApp.m_StrOperatorID = m_strGetOp();
			if(this.m_objController.m_blnDeleteApp(out strMessage))
			{
				this.m_blnIsModified = false;
				this.m_objCurrApp = null;
				this.m_lvtCurrApp.Remove();
				this.m_lvtCurrApp = null;

				if(this.m_lsvAppl.Items.Count != 0)
				{
					this.m_lsvAppl.Items[0].Selected = true;
				}
				else
				{
					m_mthEnterInitStatus();
				}
			}
			else
			{
				MessageBox.Show(this,strMessage,c_strMessageBoxTitle);
			}
		}
		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			m_blnSaveApp();
		}

		private void m_btnSend_Click(object sender, System.EventArgs e)
		{
			string strMessage = null;
			if(this.m_objController.m_blnSendApp(out strMessage))
			{
				this.m_lvtCurrApp.SubItems[2].Text = "已发送";
				this.m_btnSend.Enabled = false;
				this.m_btnSave.Enabled = false;
				this.m_btnDelete.Enabled = false;
				this.m_btnModify.Enabled = false;
				this.m_btnNew.Enabled = true;
				this.m_btnNew.Focus();
				if(this.m_blnIsDialog)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}				
			}
			else
			{
				this.m_btnSend.Focus();
				MessageBox.Show(this,strMessage,c_strMessageBoxTitle);
			}
		}
		private void m_btnModify_Click(object sender, System.EventArgs e)
		{
			m_mthSetUIControl(true);

			this.m_blnIsModified = true;
			this.m_btnSend.Enabled = false;
			this.m_btnSave.Enabled = true;
			this.m_btnDelete.Enabled = true;
			this.m_btnModify.Enabled = false;
			this.m_btnNew.Enabled = true;
		}
		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_mthResetAll();
			if(!this.m_blnIsDialog)
			{
				this.m_txtAppDoct.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
			}
			m_mthSetUIControl(true);
			this.m_btnSend.Enabled = false;
			this.m_btnSave.Enabled = true;
			this.m_btnModify.Enabled = false;
			this.m_btnDelete.Enabled = false;
			this.m_btnNew.Enabled = true;

			clsLisApplMainVO objAppVO = new clsLisApplMainVO();
			this.m_objCurrApp = new clsLIS_App(objAppVO);

			objAppVO.m_intPStatus_int = 1;
			objAppVO.m_intForm_int = 1;//等演示过后要改成 1 

			this.m_lvtCurrApp = null;
			this.m_blnIsModified = true;
			this.m_txtInhospNO.Focus();
		}

        private void m_btnQuery_Click(object sender, System.EventArgs e)
        {
            DateTime datFromDate = DateTime.Parse(m_dtpApplBegin.Value.ToShortDateString() + " 00:00:00");
            DateTime datToDate = DateTime.Parse(m_dtpApplEnd.Value.ToShortDateString() + " 23:59:59");
            if (datFromDate > datToDate)
            {
                MessageBox.Show("起始日期不能大于终止日期", "申请检验单", MessageBoxButtons.OK);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            m_objController.m_mthGetAppl(this);
            this.Cursor = Cursors.Default;
        }

		private void m_btnNewItem_Click(object sender, System.EventArgs e)
		{
			frmAppCheckContent frm = new frmAppCheckContent();
			if(frm.ShowDialog() == DialogResult.OK)
			{
				if(frm.m_objController.m_objApps.Count == 0)
					return ;
				if(frm.m_objController.m_objApps.Count > 1)
				{
					MessageBox.Show(this,"您所选择的内容包含在不同的报告内,请重新选择!",c_strMessageBoxTitle);
					return ;
				}
				this.m_lsvCheckInfo.Items.Clear();
				m_objCurrApp.m_ObjAppApplyUnits.Clear();
				m_objCurrApp.m_ObjAppReports.Clear();
				m_objCurrApp.m_ObjAppApplyUnits.AddRange(frm.m_objController.m_objAppApplyUnits);
				m_objCurrApp.m_ObjAppReports.AddRange(frm.m_objController.m_objAppReports);

				m_mthSetSampleTypeFromAppUnitID();

				m_mthShowCheckInfo();

				#region 加入请求收费信息 2005.0716 刘彬
				this.m_lsvChargeInfo.Items.Clear();
				if(this.evnRequestChargeInfo != null && this.m_objCurrApp.m_ObjAppApplyUnits.Count > 0)
				{
					string[] objApplyUnitIDArr = new string[this.m_objCurrApp.m_ObjAppApplyUnits.Count];
					for(int i=0;i<objApplyUnitIDArr.Length;i++)
					{
						objApplyUnitIDArr[i] = this.m_objCurrApp.m_ObjAppApplyUnits[i].m_StrApplyUnitID;
					}
					clsRequestChargeInfoEventArgs ee = new clsRequestChargeInfoEventArgs(objApplyUnitIDArr);
					evnRequestChargeInfo(ee);
					if(ee.ChargeInfoArr != null && ee.ChargeInfoArr.Length != 0)
					{
						//TODO: 再此加入处理收费信息的逻辑
						this.m_mthShowChargeInfo(ee.ChargeInfoArr,false);
					}
				}
				#endregion
			}
			this.m_btnSave.Focus();
		}
		private void m_mthShowChargeInfo(clsTestApplyItme_VO[] p_objChargeInfoArr,bool p_blnAppend)
		{
			if(p_objChargeInfoArr != null)
			{
				this.m_lsvChargeInfo.BeginUpdate();
				if(!p_blnAppend)
					this.m_lsvChargeInfo.Items.Clear();
				foreach(clsTestApplyItme_VO objCharge in p_objChargeInfoArr)
				{
					ListViewItem lvi = new ListViewItem(objCharge.m_strItemName);
					lvi.SubItems.Add(objCharge.m_strSpec);
					lvi.SubItems.Add(objCharge.m_decQty.ToString()+ "" + objCharge.m_strUnit);
					lvi.SubItems.Add(objCharge.m_decTolPrice.ToString());
					lvi.SubItems.Add(objCharge.m_decDiscount.ToString()+"%");
					lvi.Tag = objCharge;
					this.m_lsvChargeInfo.Items.Add(lvi);
				}
				this.m_lsvChargeInfo.EndUpdate();
			}
		}
		private void m_mthShowCheckInfo()
		{
			ArrayList arlObj = new ArrayList();
			foreach(clsLIS_AppApplyUnit obj in m_objCurrApp.m_ObjAppApplyUnits)
			{
				clsLISAppCheckInfoItem objInfoItem = new clsLISAppCheckInfoItem();
				#region 赋值
				if(obj.m_ObjApplyUnit != null && obj.m_ObjApplyUnit.m_ObjDataVO != null)
				{
					objInfoItem.m_StrAppGroupName = obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName;
					if(obj.m_ObjApplyUnit.m_ObjDataVO.strIsNoFoodRequired == "1")
					{
						objInfoItem.m_StrFood = "需要";
						
					}
					else
					{
						objInfoItem.m_StrFood = "不需要";
					}
					if(obj.m_ObjApplyUnit.m_ObjDataVO.strIsPhysicsExamRequired == "1")
					{
						objInfoItem.m_StrMedicalExam = "需要";
						
					}
					else
					{
						objInfoItem.m_StrMedicalExam = "不需要";
					}
					if(obj.m_ObjApplyUnit.m_ObjDataVO.strIsReservationRequired == "1")
					{
						objInfoItem.m_StrReservation = "需要";
					}
					else
					{
						objInfoItem.m_StrReservation = "不需要";
					}
				}
				#endregion
				arlObj.Add(objInfoItem);
			}
			clsLISAppCheckInfoItem[] objInfoItemArr = (clsLISAppCheckInfoItem[])arlObj.ToArray(typeof(clsLISAppCheckInfoItem));
			this.m_mthShowAppCheckInfo(objInfoItemArr);
			this.m_txtCheckContent.Text = this.m_objController.m_strSetCheckContent(m_objCurrApp);
		}

		private void m_btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void m_btnPint_Click(object sender, System.EventArgs e)
		{
			this.m_objPrint.m_mthGetPrintContent(m_objCurrApp.m_StrAppID);
			this.m_objPrint.m_mthPrint();
		}
		private void m_btnPreview_Click(object sender, System.EventArgs e)
		{
			this.m_objPrint.m_mthGetPrintContent(m_objCurrApp.m_StrAppID);
			this.m_objPrint.m_mthPrintPreview();
		}

		private bool m_blnSaveApp()
		{
			if(!m_blnCheckValidate())
				return false;

			this.m_mthCollectData();
			
			string strMessage = null;
			if(this.m_objController.m_blnSaveApp(out strMessage))
			{
				m_mthSetSaveOK();
				
				this.m_btnSend.Focus();
				return true;
			}
			else
			{
				MessageBox.Show(this,strMessage,"iCare-检验申请");
			}
			return false;
		}

		private bool m_blnCheckValidate()
		{
			if(m_txtPatName.Text=="")
			{
				MessageBox.Show("病人姓名不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
				return false;
			}
			if(m_cboSampleType.SelectedValue == null)
			{
				MessageBox.Show("样本类型不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
				return false;
			}
			//			if(this.m_txtApplDep.Text == "")
			//			{
			//				MessageBox.Show("申请科室不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
			//				return;
			//			}
			//			if(this.m_txtApplDoc.Text == "")
			//			{
			//				MessageBox.Show("申请医生不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
			//				return;
			//			}
			if(this.m_lsvCheckInfo.Items.Count == 0)
			{
				MessageBox.Show("检验内容不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
				return false;
			}			
			return true;
		}

		private void m_mthCollectData()
		{
			this.m_objCurrApp.m_StrPatientCardID = this.m_txtPatCardID.Text.Trim();
			if(this.m_txtPatientID.Text.Trim() == "")
			{
				this.m_objCurrApp.m_StrPatientID = "-1";
			}
			else
			{
				this.m_objCurrApp.m_StrPatientID = this.m_txtPatientID.Text.Trim();
			}
			this.m_objCurrApp.m_StrPatientInhospNO = this.m_txtInhospNO.Text.Trim();
			this.m_objCurrApp.m_StrPatientName = this.m_txtPatName.Text.Trim();
			this.m_objCurrApp.m_StrSex = this.m_cboSex.Text.Trim();
			if(this.m_txtAge.Text.Trim() != null)
			{
				this.m_objCurrApp.m_StrAge = this.m_txtAge.Text.Trim() + " " + this.m_cboAgeUnit.Text.Trim();
			}
			else
			{
				this.m_objCurrApp.m_StrAge = null;
			}
			this.m_objCurrApp.m_StrApplEmpID = this.m_txtAppDoct.m_StrEmployeeID;
			this.m_objCurrApp.m_StrApplDeptID = this.m_txtAppDept.m_StrDeptID;
			this.m_objCurrApp.m_StrBedNO = this.m_txtBedNO.Text.Trim();
			this.m_objCurrApp.m_StrPatientType = this.m_cboPatientType.SelectedValue.ToString().Trim();
			if(this.m_chkEmergency.Checked)
			{
				this.m_objCurrApp.m_IntEmergency = 1;
			}
			else
			{
				this.m_objCurrApp.m_IntEmergency = 0;
			}
			if(this.m_chkSpecial.Checked)
			{
				this.m_objCurrApp.m_IntSpecial = 1;
			}
			else
			{
				this.m_objCurrApp.m_IntSpecial = 0;
			}
			this.m_objCurrApp.m_StrDiagnose = this.m_rtbDiagnose.Text.Trim();
			this.m_objCurrApp.m_StrSummary = this.m_rtbAppSummary.Text.Trim();
			this.m_objCurrApp.m_StrOperatorID = m_strGetOp();
			
			this.m_objCurrApp.m_StrAppDat = this.m_dtpAppDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			if(this.m_cboSampleType.SelectedValue != null)
			{
				this.m_objCurrApp.m_ObjDataVO.m_strSampleTypeID = this.m_cboSampleType.SelectedValue.ToString();
				this.m_objCurrApp.m_ObjDataVO.m_strSampleType = this.m_cboSampleType.Text;
			}
			this.m_objCurrApp.m_ObjDataVO.m_strCheckContent = this.m_txtCheckContent.Text;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			foreach(ListViewItem lvi in this.m_lsvChargeInfo.Items)
			{
				for(int i=0;i<lvi.SubItems.Count;i++)
				{
					sb.Append(lvi.SubItems[i].Text);
					sb.Append(">");
				}
				if(sb.Length >0)
				{
					sb.Remove(sb.Length-1,1);
				}
				sb.Append("|");
			}
			if(sb.Length >0)
			{
				sb.Remove(sb.Length-1,1);
			}
			this.m_objCurrApp.m_ObjDataVO.m_strChargeInfo = sb.ToString();
		}

		private void m_mthSetSaveOK()
		{
            string strConfig = "";
            try 
            {
                long lngRes = new clsDomainController_ApplicationManage().m_lngGetCollocate(out strConfig, "4002");
                switch (strConfig)
                {
                    case "0":
                        strConfig = "未发送";
                        break;
                    case "1":
                        strConfig = "已发送";
                        break;
                    case "2":
                        strConfig = "已发送";
                        break;
                    default:
                        strConfig = "未发送";
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            } 

			if(this.m_lvtCurrApp == null)
			{
				ListViewItem lvtItem = new ListViewItem(this.m_objCurrApp.m_StrAppID.Substring(8,10));
				lvtItem.SubItems.Add(this.m_objCurrApp.m_StrPatientName);
                lvtItem.SubItems.Add(strConfig);
				lvtItem.Tag = this.m_objCurrApp.m_ObjDataVO;
				m_lsvAppl.Items.Add(lvtItem);
				this.m_lvtCurrApp = lvtItem;
			}
			this.m_lvtCurrApp.SubItems[0].Text = this.m_objCurrApp.m_StrAppID.Substring(8,10);
			this.m_lvtCurrApp.SubItems[1].Text = this.m_objCurrApp.m_StrPatientName;
            this.m_lvtCurrApp.SubItems[2].Text = strConfig;
			this.m_txtAppNO.Text = m_objCurrApp.m_StrAppID.Substring(8,10);
			
			m_mthSetUIControl(false);

			this.m_blnIsModified = false;
			this.m_btnSend.Enabled = true;
			this.m_btnSave.Enabled = false;
			this.m_btnDelete.Enabled = true;
			this.m_btnModify.Enabled = true;
			this.m_btnNew.Enabled = true;
			this.m_btnPint.Enabled = true;
			this.m_btnPreview.Enabled = true;
			if(!this.m_lvtCurrApp.Selected)
			{
				this.m_lvtCurrApp.Selected = true;
			}
		}



		private void m_mthResetAll()
		{
			m_mthResetAppInfo();
			m_mthResetCheckInfo();
		}
		private void m_mthResetAppInfo()
		{

			m_txtPatientID.Clear();
			m_txtPatCardID.Clear();
			m_txtInhospNO.Clear();
			m_txtPatName.Clear();
			m_cboSex.Text = null;
			m_txtAge.Clear();
			m_cboAgeUnit.Text = "年";
			m_cboSampleType.SelectedItem = null;
			m_cboSampleType.SelectedItem = null;

			m_txtAppDept.m_StrDeptID = null;
			m_txtBedNO.Text = null;
			m_txtAppDoct.m_StrEmployeeID =null;
			m_dtpAppDate.Value =DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			if(m_cboPatientType.Items.Count > 0)
			{
				m_cboPatientType.SelectedIndex = 0;
			}
			this.m_chkEmergency.Checked = false;			
			this.m_chkSpecial.Checked = false;
			
			this.m_rtbDiagnose.Clear();
			this.m_rtbAppSummary.Clear();
			this.m_txtAppNO.Clear();
			this.m_lblChargeState.Text = "";

			this.m_txtCheckContent.Clear();
		}
		private void m_mthResetCheckInfo()
		{
			this.m_lsvCheckInfo.Items.Clear();
			this.m_lsvChargeInfo.Items.Clear();
		}

		public void m_mthEnterInitStatus()
		{
			m_mthResetAll();
			m_mthSetUIControl(false);

			this.m_objCurrApp = null;
			this.m_lvtCurrApp = null;
			this.m_blnIsModified = false;

			this.m_btnSend.Enabled = false;
			this.m_btnSave.Enabled = false;
			this.m_btnDelete.Enabled = false;
			this.m_btnModify.Enabled = false;
			this.m_btnNew.Enabled = true;
			this.m_btnPreview.Enabled = false;
			this.m_btnPint.Enabled = false;
		}


		private void m_mthShowAppCheckInfo(clsLISAppCheckInfoItem[] p_objItemArr)
		{
			if(p_objItemArr != null)
			{
				for(int i=0;i<p_objItemArr.Length;i++)
				{
					if(p_objItemArr[i] != null)
					{
						ListViewItem objItem = new ListViewItem(p_objItemArr[i].m_StrAppGroupName);
						objItem.SubItems.Add(p_objItemArr[i].m_StrFood);
						objItem.SubItems.Add(p_objItemArr[i].m_StrMedicalExam);
						objItem.SubItems.Add(p_objItemArr[i].m_StrReservation);
						this.m_lsvCheckInfo.Items.Add(objItem);
					}
				}
			}
		}

		private void m_mthShowAppBaseInfo(clsLisApplMainVO p_objAppVO)
		{
			if(p_objAppVO != null)
			{
				m_txtPatientID.Text = p_objAppVO.m_strPatientID;
				m_txtPatCardID.Text = p_objAppVO.m_strPatientcardID;
				m_txtInhospNO.Text = p_objAppVO.m_strPatient_inhospitalno_chr;
				m_txtPatName.Text = p_objAppVO.m_strPatient_Name;
				m_cboSex.Text = p_objAppVO.m_strSex;
				m_txtAge.Text = clsAgeConverter.m_strGetAgeNum(p_objAppVO.m_strAge);
				m_cboAgeUnit.Text = clsAgeConverter.m_strGetAgeUnit(p_objAppVO.m_strAge);

				m_txtAppDept.m_StrDeptID = p_objAppVO.m_strAppl_DeptID;
				m_txtBedNO.Text = p_objAppVO.m_strBedNO;
				m_txtAppDoct.m_StrDeptID = p_objAppVO.m_strAppl_DeptID;
				m_txtAppDoct.m_StrEmployeeID = p_objAppVO.m_strAppl_EmpID;
				if(Microsoft.VisualBasic.Information.IsDate(p_objAppVO.m_strAppl_Dat))
				{
					m_dtpAppDate.Value = DateTime.Parse(p_objAppVO.m_strAppl_Dat);
				}
				else
				{
					m_dtpAppDate.Value = DateTime.Now;
				}
				if(p_objAppVO.m_strPatientType == null || p_objAppVO.m_strPatientType.Trim() == "")
				{
					m_cboPatientType.SelectedItem = null;
					m_cboPatientType.SelectedItem = null;
					m_cboPatientType.SelectedItem = null;
					m_cboPatientType.Refresh();
				}
				else
				{
					try
					{
						m_cboPatientType.SelectedValue = p_objAppVO.m_strPatientType;
						m_cboPatientType.SelectedValue = p_objAppVO.m_strPatientType;
						m_cboPatientType.SelectedValue = p_objAppVO.m_strPatientType;
						m_cboPatientType.Refresh();
					}
					catch
					{
						m_cboPatientType.SelectedItem = null;
						m_cboPatientType.SelectedItem = null;
						m_cboPatientType.SelectedItem = null;
						m_cboPatientType.Refresh();
					}
				}

				if(p_objAppVO.m_intEmergency == 1)
				{
					this.m_chkEmergency.Checked = true;
				}
				else
				{
					this.m_chkEmergency.Checked = false;
				}

				if(p_objAppVO.m_intSpecial == 1)
				{
					this.m_chkSpecial.Checked = true;
				}
				else
				{
					this.m_chkSpecial.Checked = false;
				}

				this.m_rtbDiagnose.Text = p_objAppVO.m_strDiagnose;
				this.m_rtbAppSummary.Text = p_objAppVO.m_strSummary;
				try
				{
					this.m_txtAppNO.Text = p_objAppVO.m_strAPPLICATION_ID.Substring(8,10);
				}
				catch{};
	
				this.m_txtCheckContent.Text = p_objAppVO.m_strCheckContent;
				if(p_objAppVO.m_strChargeInfo != null)
				{
					string[] strChargeInfos = p_objAppVO.m_strChargeInfo.Split(new char[]{'|'});
					foreach(string str in strChargeInfos)
					{
						if(str != null && str.Trim() != "")
						{
							ListViewItem lvi = new ListViewItem();
							string[] strItems = str.Split(new char[]{'>'});
							lvi.Text = strItems[0];
							for(int j=1;j<strItems.Length;j++)
							{
								lvi.SubItems.Add(strItems[j]);
							}
							this.m_lsvChargeInfo.Items.Add(lvi);
						}						
					}
				}
				try
				{
					this.m_cboSampleType.SelectedValue = p_objAppVO.m_strSampleTypeID;
					this.m_cboSampleType.SelectedValue = p_objAppVO.m_strSampleTypeID;
					this.m_cboSampleType.Refresh();
				}
				catch
				{
					this.m_cboSampleType.SelectedItem = null;
					this.m_cboSampleType.SelectedItem = null;
					this.m_cboSampleType.Refresh();
				}
				switch(p_objAppVO.m_intChargeState)
				{
					case 0:
						this.m_lblChargeState.Text = "";
						break;
					case 1:
						this.m_lblChargeState.Text = "未收费";
						this.m_lblChargeState.ForeColor = System.Drawing.Color.Red;
						break;
					case 2:
						this.m_lblChargeState.Text = "已收费";
						this.m_lblChargeState.ForeColor = System.Drawing.Color.Black;
						break;
					default:
						this.m_lblChargeState.Text = "";
						break;
				}
			}
		}


		private void m_mthSetUIControl(bool p_blnModify)
		{
			this.m_grpPatientInfo.Enabled = p_blnModify;
			this.m_btnNewItem.Enabled = p_blnModify;
			this.m_btnDeleteItem.Enabled = p_blnModify;
		}

		private bool m_blnAppUnSave()
		{
			return m_blnIsModified;
		}

        //操作人员ID
		public string m_strGetOp()
		{
			return this.LoginInfo.m_strEmpID;
		}

		private void m_miSend_Click(object sender, System.EventArgs e)
		{
			//			if(m_lsvAppl.SelectedItems.Count>0)
			//			{
			//				com.digitalwave.iCare.gui.LIS.clsController_Appl m_objController = (clsController_Appl)this.m_objController;
			//				System.Data.DataRow dtRow=(System.Data.DataRow)m_lsvAppl.SelectedItems[0].Tag;
			//				long lngRes=0;
			//				lngRes=m_objController.m_lngSetApplSendStatus(dtRow["APPLICATION_ID_CHR"].ToString().Trim());	
			//				if(lngRes>0)
			//				{
			//					m_lsvAppl.SelectedItems[0].SubItems[3].Text="已发送";
			//				}
			//			}
			this.DialogResult = DialogResult.OK;
		}


		#region 接口
		#region 查看接口
		public frmLisAppl(string p_strAppID)
		{
			InitializeComponent();
			this.m_palHead.Visible = false;
			this.m_btnQuery.Visible = false;
			this.m_btnDelete.Visible = false;
			this.m_btnNew.Visible = false;
			m_blnIsDialog = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			clsLisApplMainVO[] objAppVOarr= null;
			clsLisApplMainVO objAppVO = null;
			long lngRes = new clsDomainController_ApplicationManage().m_lngGetApplicationInfoByApplicationID(p_strAppID,out objAppVOarr);
			if(lngRes <= 0)
			{
				this.Enabled = false;
				return;
			}
			if(objAppVOarr == null || objAppVOarr.Length == 0)
			{
				m_mthNewAppNoShow(objAppVO);
				return;
			}
			objAppVO = objAppVOarr[0];
			m_objDialogPatientInfo = objAppVO;
			this.VisibleChanged += new EventHandler(frmLisAppl_VisibleChangedShowInfo);
			this.m_objCurrApp = new clsLIS_App(objAppVO,true);


			this.m_mthSetUIControl(false);
			if(objAppVO.m_intPStatus_int == 1)
			{
				this.m_btnSend.Enabled = true;
				this.m_btnSave.Enabled = false;
				this.m_btnModify.Enabled = true;
				this.m_btnDelete.Enabled = true;
				this.m_btnNew.Enabled = true;
			}
			else if(objAppVO.m_intPStatus_int == 2)
			{
				this.m_btnSend.Enabled = false;
				this.m_btnSave.Enabled = false;
				this.m_btnModify.Enabled = false;
				this.m_btnDelete.Enabled = false;
				this.m_btnNew.Enabled = true;
			}
			this.m_btnPint.Enabled = true;
			this.m_btnPreview.Enabled = true;
		}
		private void frmLisAppl_VisibleChangedShowInfo(object sender, EventArgs e)
		{
			this.m_mthShowAppBaseInfo(this.m_objDialogPatientInfo);

			clsLISAppCheckInfoItem[] objItemArr = null;
			this.m_objController.m_mthGetAppCheckInfo(m_objDialogPatientInfo.m_strAPPLICATION_ID,out objItemArr);
			if(objItemArr != null)
			{
				m_mthShowAppCheckInfo(objItemArr);
			}
		}
		#endregion
		
		#region 住院接口[BIH]
        #region old
        public frmLisAppl(iCareData.clsApplyReport_T_VO p_objReportVO)
		{
			InitializeComponent();
			clsLisApplMainVO objPatientInfo = new clsLisApplMainVO();
			objPatientInfo.m_intForm_int = 0;
			objPatientInfo.m_intPStatus_int = 1;
			objPatientInfo.m_strPatientType = "1";
			objPatientInfo.m_strAppl_Dat = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
			objPatientInfo.m_strPatient_Name = p_objReportVO.m_StrPatientName;
			objPatientInfo.m_strAge = p_objReportVO.m_StrPatientAge;
			objPatientInfo.m_strSex = p_objReportVO.m_StrPatientSex;
			objPatientInfo.m_strPatientID = p_objReportVO.m_StrPatientID;
			objPatientInfo.m_strPatient_inhospitalno_chr = p_objReportVO.m_StrInPatientID;
			objPatientInfo.m_strPatientcardID = p_objReportVO.m_StrPatientCardID;
			objPatientInfo.m_strPatient_SubNO = p_objReportVO.m_StrOutPatientID;
			objPatientInfo.m_strAppl_EmpID = p_objReportVO.m_StrDeliverDoctorID;
			objPatientInfo.m_strAppl_DeptID = p_objReportVO.m_StrDeptID;
			objPatientInfo.m_strOperator_ID = p_objReportVO.m_StrDeliverDoctorID;
			objPatientInfo.m_strDiagnose = p_objReportVO.m_StrClinicDiagnose;
			objPatientInfo.m_strBedNO = p_objReportVO.m_StrBedName;
			objPatientInfo.m_strICD = null;
			m_mthNewAppNoShow(objPatientInfo);
		}
		public void m_mthNewAppNoShow(clsLisApplMainVO p_objPatientInfo)
		{
			this.m_palHead.Visible = false;
			this.m_btnQuery.Visible = false;
			this.m_btnDelete.Visible = false;
			this.m_btnNew.Visible = false;
			m_blnIsDialog = true;
			m_objDialogPatientInfo = p_objPatientInfo;
			this.m_btnNew_Click(null,null);	
			this.VisibleChanged += new EventHandler(frmLisAppl_VisibleChanged);
			this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion
        /// <summary>
        /// 接口：传入收费项目;
        /// 申请单元ID放入clsTestApplyItme_VO的 m_strItemID 成员中
        /// </summary>
        /// <param name="p_objPatientInfo">患者基本信息</param>
        /// <param name="p_objChargeInfoArr">收费信息(ItemID成员用来承载申请单元ID);为空则和接口“ 门诊接口：直接打开”功能相同</param>
        /// <returns></returns>
        public DialogResult m_mthNewAppInpatient(clsLisApplMainVO p_objPatientInfo, clsTestApplyItme_VO[] p_objChargeInfoArr, bool p_blnShow)
        {
            return this.m_mthNewApp(p_objPatientInfo, p_objChargeInfoArr, p_blnShow, false);
        }
        #endregion

        #region 门诊接口
        public event dlgRequestChargeInfoEventHandler evnRequestChargeInfo;
		public string m_StrRecordID
		{
			get
			{
				return this.m_objCurrApp.m_StrAppID;
			}
		}

		/// <summary>
		/// 门诊接口：直接打开
		/// </summary>
		/// <param name="p_objPatientInfo">患者基本信息</param>
		/// <returns></returns>
		public DialogResult m_mthNewApp(clsLisApplMainVO p_objPatientInfo)
		{
			this.m_palHead.Visible = false;
			this.m_btnQuery.Visible = false;
			this.m_btnDelete.Visible = false;
			this.m_btnNew.Visible = false;
			m_blnIsDialog = true;
			this.m_btnNew_Click(null,null);	
			m_objDialogPatientInfo = p_objPatientInfo;
			this.VisibleChanged += new EventHandler(frmLisAppl_VisibleChanged);
			this.StartPosition = FormStartPosition.CenterScreen;
			return this.ShowDialog();
		}
        /// <summary>
		/// 门诊接口：传入收费项目;
		/// 收费信息 和 申请单元 为空时功能和接口“ 门诊接口：直接打开”功能相同;
		/// </summary>
		/// <param name="p_objPatientInfo">患者基本信息</param>
		/// <param name="p_objChargeInfoArr">收费信息</param>
		/// <param name="p_strApplyUnitIDArr">申请单元ID</param>
		/// <returns></returns>
        public DialogResult m_mthNewApp(clsLisApplMainVO p_objPatientInfo, clsTestApplyItme_VO[] p_objChargeInfoArr, string[] p_strApplyUnitIDArr, bool p_blnShow)
        {
            return this.m_mthNewApp(p_objPatientInfo, p_objChargeInfoArr, p_strApplyUnitIDArr, p_blnShow, true);
        }
        /// <summary>
		/// 门诊接口：传入收费项目;
		/// 申请单元ID放入clsTestApplyItme_VO的 m_strItemID 成员中
		/// </summary>
		/// <param name="p_objPatientInfo">患者基本信息</param>
		/// <param name="p_objChargeInfoArr">收费信息(ItemID成员用来承载申请单元ID);为空则和接口“ 门诊接口：直接打开”功能相同</param>
		/// <returns></returns>
        public DialogResult m_mthNewApp(clsLisApplMainVO p_objPatientInfo, clsTestApplyItme_VO[] p_objChargeInfoArr, bool p_blnShow)
        {
            string strAge = p_objPatientInfo.m_strAge;
            try
            {
                int intAgeNum = 0;
                int idx = 0;
                if (strAge.Contains("岁"))
                {
                    idx = strAge.IndexOf("岁");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    p_objPatientInfo.m_strAge = intAgeNum.ToString() + " " + "岁";
                }
                else if (strAge.Contains("月"))
                {
                    idx = strAge.IndexOf("月");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    p_objPatientInfo.m_strAge = intAgeNum.ToString() + " " + "月";
                }
                else if (strAge.Contains("天"))
                {
                    idx = strAge.IndexOf("天");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    p_objPatientInfo.m_strAge = intAgeNum.ToString() + " " + "天";
                }
                else if (strAge.Contains("小时"))
                {
                    idx = strAge.IndexOf("小时");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    p_objPatientInfo.m_strAge = intAgeNum.ToString() + " " + "小时";
                }
      
            }
            catch
            {
 
            }
           
            return this.m_mthNewApp(p_objPatientInfo, p_objChargeInfoArr, p_blnShow, true);
        }
		#endregion


		/// <summary>
		/// 接口：传入收费项目;
		/// 收费信息 和 申请单元 为空时功能和接口“ 门诊接口：直接打开”功能相同;
		/// </summary>
		/// <param name="p_objPatientInfo">患者基本信息</param>
		/// <param name="p_objChargeInfoArr">收费信息</param>
		/// <param name="p_strApplyUnitIDArr">申请单元ID</param>
		/// <returns></returns>
		private DialogResult m_mthNewApp(clsLisApplMainVO p_objPatientInfo,clsTestApplyItme_VO[] p_objChargeInfoArr,string[] p_strApplyUnitIDArr,bool p_blnShow,bool p_blnSend)
		{
            if (p_objPatientInfo != null)
            {
                p_objPatientInfo.m_strAge = clsAgeConverter.m_strAgeToAge(p_objPatientInfo.m_strAge);
            }
			if(p_strApplyUnitIDArr != null)
			{//去除重复项
				Hashtable has = new Hashtable();
				foreach(string str in p_strApplyUnitIDArr)
				{
					if(str != null)
					{
						if(!has.ContainsKey(str))
							has.Add(str,str);
					}
				}
				ArrayList arl = new ArrayList();
				arl.AddRange(has.Values);
				p_strApplyUnitIDArr = (string[])arl.ToArray(typeof(string));
			}
			if(!p_blnShow)
			{
				this.m_blnIsNoShow = true;
				return this.m_mthNoShow(p_objPatientInfo,p_objChargeInfoArr,p_strApplyUnitIDArr,p_blnSend);
			}
			this.m_blnIsNoShow = false;

			this.m_palHead.Visible = false;
			this.m_btnQuery.Visible = false;
			this.m_btnDelete.Visible = false;
			this.m_btnNew.Visible = false;
			m_blnIsDialog = true;
			this.m_btnNew_Click(null,null);	
			m_objDialogPatientInfo = p_objPatientInfo;
			this.VisibleChanged += new EventHandler(frmLisAppl_VisibleChanged);
			this.StartPosition = FormStartPosition.CenterScreen;
			
			this.m_mthShowChargeInfo(p_objChargeInfoArr,false);

			if(p_strApplyUnitIDArr != null)
			{
				clsController_AppCheckContent objControllerCheckContent = new clsController_AppCheckContent(null);
				objControllerCheckContent.m_mthGenerateAppContent(p_strApplyUnitIDArr);

				if(objControllerCheckContent.m_objApps.Count == 0)
				{
					MessageBox.Show(this,"无法根据您所选择的内容生成检验申请单,请与管理员联系!",c_strMessageBoxTitle);
					this.DialogResult = DialogResult.Cancel;
					return DialogResult.Cancel;
				}
				if(objControllerCheckContent.m_objApps.Count > 1)
				{
					MessageBox.Show(this,"您所选择的内容包含在不同的报告内,请重新选择!",c_strMessageBoxTitle);
					this.DialogResult = DialogResult.Cancel;
					return DialogResult.Cancel;
				}
				this.m_lsvCheckInfo.Items.Clear();
				m_objCurrApp.m_ObjAppApplyUnits.Clear();
				m_objCurrApp.m_ObjAppReports.Clear();
				m_objCurrApp.m_ObjAppApplyUnits.AddRange(objControllerCheckContent.m_objAppApplyUnits);
				m_objCurrApp.m_ObjAppReports.AddRange(objControllerCheckContent.m_objAppReports);

				if(p_objPatientInfo.m_strSampleTypeID == null || p_objPatientInfo.m_strSampleTypeID.Trim()=="")
				{
					m_mthSetSampleTypeFromAppUnitID();
				}
				else
				{
					m_objCurrApp.m_ObjDataVO.m_strSampleTypeID = p_objPatientInfo.m_strSampleTypeID;
				}
				
				m_mthShowCheckInfo();
				m_objDialogPatientInfo.m_strCheckContent = m_objCurrApp.m_ObjDataVO.m_strCheckContent;
			}
	
			if(p_blnShow || m_objCurrApp == null || m_objCurrApp.m_ObjDataVO.m_strSampleTypeID == null || m_objCurrApp.m_ObjDataVO.m_strSampleTypeID.Trim() == "")
			{
				return this.ShowDialog();
			}
			this.WindowState = FormWindowState.Minimized;
			this.ShowInTaskbar = false;
			this.Show();
			this.Visible = false;
			if(!this.m_blnSaveApp())
			{
				return DialogResult.Cancel;
			}
			string strMessage = null;
            if (p_blnSend)
            {
                if (!this.m_objController.m_blnSendApp(out strMessage))
                {
                    MessageBox.Show(this, strMessage, c_strMessageBoxTitle);
                    this.Close();
                    return DialogResult.Cancel;
                }
            }
			this.Close();
			return DialogResult.OK;
		}

		/// <summary>
		/// 接口：传入收费项目;
		/// 申请单元ID放入clsTestApplyItme_VO的 m_strItemID 成员中
		/// </summary>
		/// <param name="p_objPatientInfo">患者基本信息</param>
		/// <param name="p_objChargeInfoArr">收费信息(ItemID成员用来承载申请单元ID);为空则和接口“ 门诊接口：直接打开”功能相同</param>
		/// <returns></returns>
		private DialogResult m_mthNewApp(clsLisApplMainVO p_objPatientInfo,clsTestApplyItme_VO[] p_objChargeInfoArr,bool p_blnShow,bool p_blnSend)
		{
			ArrayList arlApplyUnit = new ArrayList();
			if(p_objChargeInfoArr != null)
			{
				foreach(clsTestApplyItme_VO objCharge in p_objChargeInfoArr)
				{
					if(objCharge.m_strItemID != null && objCharge.m_strItemID.Trim() != "")
					{
						arlApplyUnit.Add(objCharge.m_strItemID);
					}
				}
			}
			string[] strApplyUnitIDArr = null;
			if(arlApplyUnit.Count >0)
				strApplyUnitIDArr = (string[])arlApplyUnit.ToArray(typeof(string));

            return this.m_mthNewApp(p_objPatientInfo, p_objChargeInfoArr, strApplyUnitIDArr, p_blnShow, p_blnSend);
			
		}
		public clsLISAppResults m_objGetAppResults()
		{
			clsLISAppResults objResult = new clsLISAppResults();
			objResult.m_StrApplicationID = this.m_objCurrApp.m_StrAppID;
			objResult.m_StrAppCheckContentDesc = this.m_objCurrApp.m_ObjDataVO.m_strCheckContent;
			objResult.m_ObjApplyUnitIDArr = new string[this.m_objCurrApp.m_ObjAppApplyUnits.Count];
			objResult.m_strSampleTypeID = this.m_objCurrApp.m_ObjDataVO.m_strSampleTypeID;
			objResult.m_strSampleTypeName = this.m_objCurrApp.m_ObjDataVO.m_strSampleType;
			for(int i=0;i<objResult.m_ObjApplyUnitIDArr.Length;i++)
			{
				objResult.m_ObjApplyUnitIDArr[i] = this.m_objCurrApp.m_ObjAppApplyUnits[i].m_StrApplyUnitID;
			}
			return objResult;
		}
		private void frmLisAppl_VisibleChanged(object sender, EventArgs e)
		{
			if(this.m_objDialogPatientInfo != null)
			{
				this.m_mthShowAppBaseInfo(this.m_objDialogPatientInfo);		
			}
			else
			{
				this.m_btnNew.Focus();
			}
			if(this.m_blnIsDialog && this.Visible)
			{
				this.m_grpPatientInfo.SelectNextControl(this.m_cboAgeUnit,true,true,false,false);
			}
			if(this.m_blnIsDialog)
			{
				try
				{	
					if(m_objCurrApp != null && m_objCurrApp.m_ObjDataVO != null && m_objCurrApp.m_ObjDataVO.m_strSampleTypeID != null)
						this.m_cboSampleType.SelectedValue = m_objCurrApp.m_ObjDataVO.m_strSampleTypeID;
				}
				catch{}
			}
		}

		#region NoShow 接口***********************************************************************

		bool m_blnIsNoShow = false;
		ArrayList arlMutiResults = new ArrayList();

        private DialogResult m_mthNoShow(clsLisApplMainVO p_objPatientInfo, clsTestApplyItme_VO[] p_objChargeInfoArr, string[] p_strApplyUnitIDArr, bool p_blnSend)
        {
            this.arlMutiResults.Clear();

            bool isValid = p_objPatientInfo == null || p_objChargeInfoArr == null  || p_objChargeInfoArr.Length == 0
                                                    || p_strApplyUnitIDArr == null || p_strApplyUnitIDArr.Length == 0;

            if (isValid)  return DialogResult.Cancel;

            p_objPatientInfo.m_intPStatus_int = 1;
            p_objPatientInfo.m_intForm_int = 1;

            clsController_AppCheckContent objControllerCheckContent = new clsController_AppCheckContent(null);
            objControllerCheckContent.m_mthGenerateAppContent(p_strApplyUnitIDArr);

            if (objControllerCheckContent.m_objApps == null) return DialogResult.Cancel;

            ArrayList arl = new ArrayList();
            for (int i = 0; i < objControllerCheckContent.m_objApps.Count; i++)
            {
                string[] strUnits = new string[objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits.Count];
                for (int j = 0; j < objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits.Count; j++)
                {
                    strUnits[j] = objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits[j].m_StrApplyUnitID;
                }
                arl.Add(strUnits);
            }

            ArrayList arlUnits = new ArrayList();
            foreach (string[] strArr in arl)
            {
                clsSeparateCheckApplication objSep = new clsSeparateCheckApplication();
                clsSeparatedApp[]       objSepApps = objSep.m_mthSeparateCheckApplication(strArr);
                foreach (clsSeparatedApp obj in objSepApps)
                {
                    arlUnits.Add(obj.m_strApplyUnits);
                }
            }    
        
            foreach (string[] strUnits in arlUnits)
            {
                clsController_AppCheckContent objContent = new clsController_AppCheckContent(null);
                string[] strAppUnitArr = null;
                long lngRes = m_objAppUnitManage.m_lngQueryAppUnitSeq(strUnits, out strAppUnitArr);
                if (strAppUnitArr != null && strAppUnitArr.Length > 0)
                {
                    objContent.m_mthGenerateAppContent(strAppUnitArr);

                }
                else
                {
                    objContent.m_mthGenerateAppContent(strUnits);

                }
                
                if (objContent.m_objApps == null) return DialogResult.Cancel;

                clsLisApplMainVO objMainVO = new clsLisApplMainVO();
                p_objPatientInfo.m_mthCopyTo(objMainVO);

                clsLIS_App objApp = new clsLIS_App(objMainVO);
                objApp.m_ObjAppApplyUnits.AddRange(objContent.m_objAppApplyUnits);
                objApp.m_ObjAppReports.AddRange(objContent.m_objAppReports);

                if (objApp.m_StrPatientType == "2")
                {
                    foreach (clsTestApplyItme_VO obj in p_objChargeInfoArr)
                    {
                        if (strUnits[0] == obj.m_strItemID)
                        {
                            objApp.m_ObjDataVO.m_strSampleTypeID = obj.m_strSampleId;
                            break;
                        }
                    }
                    if (string.IsNullOrEmpty(objApp.m_ObjDataVO.m_strSampleTypeID))
                    {
                        objApp.m_ObjDataVO.m_strSampleTypeID = m_mthGetSampleType(strUnits);
                    }
                }
                else
                {
                    objApp.m_ObjDataVO.m_strSampleTypeID = m_mthGetSampleType(strUnits);
                }                
                objApp.m_ObjDataVO.m_strAppl_Dat     = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objApp.m_ObjDataVO.m_strSampleType   = this.m_cboSampleType.m_strGetTypeName(objApp.m_ObjDataVO.m_strSampleTypeID);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                ArrayList arlChargeIDs = new ArrayList();
                foreach (clsTestApplyItme_VO objTestVO in p_objChargeInfoArr)
                {
                    foreach (string strUnit in strUnits)
                    {
                        if (strUnit == objTestVO.m_strItemID)
                        {
                            sb.Append(objTestVO.m_strItemName == null ? "" : objTestVO.m_strItemName.Trim());
                            sb.Append(">");
                            sb.Append(objTestVO.m_strSpec == null ? "" : objTestVO.m_strSpec.Trim());
                            sb.Append(">");
                            sb.Append(objTestVO.m_decQty.ToString() + "" + objTestVO.m_strUnit);
                            sb.Append(">");
                            sb.Append(objTestVO.m_decTolPrice.ToString());
                            sb.Append(">");
                            sb.Append(objTestVO.m_decDiscount.ToString() + "%");
                            sb.Append("|");
                            arlChargeIDs.Add(objTestVO.strPartID);
                        }
                    }
                }
                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
                objApp.m_ObjDataVO.m_strChargeInfo = sb.ToString();

                this.m_objController.m_strSetCheckContent(objApp);
                objApp.m_ObjDataVO.m_strOperator_ID = this.m_strGetOp();

                this.m_objCurrApp = objApp;
                string strMessage = null;
                if (!this.m_objController.m_blnSaveApp(out strMessage))
                {
                    return DialogResult.Cancel;
                }
                if (p_blnSend)
                {
                    if (!this.m_objController.m_blnSendApp(out strMessage))
                    {
                        return DialogResult.Cancel;
                    }
                }
                clsLISAppResults objResult = new clsLISAppResults();
                objResult.m_StrApplicationID  = objApp.m_ObjDataVO.m_strAPPLICATION_ID;
                objResult.m_strSampleTypeID   = objApp.m_ObjDataVO.m_strSampleTypeID;
                objResult.m_strSampleTypeName = objApp.m_ObjDataVO.m_strSampleType;
                objResult.m_StrAppCheckContentDesc = objApp.m_ObjDataVO.m_strCheckContent;
                objResult.m_ObjApplyUnitIDArr = new string[objApp.m_ObjAppApplyUnits.Count];
                for (int i = 0; i < objApp.m_ObjAppApplyUnits.Count; i++)
                {
                    objResult.m_ObjApplyUnitIDArr[i] = objApp.m_ObjAppApplyUnits[i].m_ObjDataVO.m_strAPPLY_UNIT_ID_CHR;
                }
                objResult.m_strChargeIDs = (string[])arlChargeIDs.ToArray(typeof(string));
                arlMutiResults.Add(objResult);
            }
            return DialogResult.OK;
        }

		private string m_mthGetSampleType(string[] p_strAppUnitIDs)
		{

			string[] strSampleTypeIDArr = null;
			new clsDomainController_ApplyUnitManage().m_lngGetSampleTypeIDList(p_strAppUnitIDs,out strSampleTypeIDArr);
			if(strSampleTypeIDArr != null && strSampleTypeIDArr.Length >0)
			{
				return strSampleTypeIDArr[0];
			}
			return null;
		}
		public clsLISAppResults[] m_objGetMutiResults()
		{
			return (clsLISAppResults[])arlMutiResults.ToArray(typeof(clsLISAppResults));
		}
	
		#endregion********************************************************************************

        

		#endregion

		private void m_mthSetSampleTypeFromAppUnitID()
		{
			#region 加入样本类型逻辑
			string[] strSampleTypeIDArr;
			string[] strApplyUnitIDArr = new string[m_objCurrApp.m_ObjAppApplyUnits.Count];
			for(int i=0;i<m_objCurrApp.m_ObjAppApplyUnits.Count;i++)
			{
				strApplyUnitIDArr[i] = m_objCurrApp.m_ObjAppApplyUnits[i].m_StrApplyUnitID;
			}
			new clsDomainController_ApplyUnitManage().m_lngGetSampleTypeIDList(strApplyUnitIDArr,out strSampleTypeIDArr);
			if(strSampleTypeIDArr != null && strSampleTypeIDArr.Length >0)
			{
				m_objCurrApp.m_ObjDataVO.m_strSampleTypeID = strSampleTypeIDArr[0];
				try
				{
					this.m_cboSampleType.SelectedValue = m_objCurrApp.m_ObjDataVO.m_strSampleTypeID;
				}
				catch{}
			}
			#endregion
		}

		
	}
	public class clsRequestChargeInfoEventArgs : System.EventArgs
	{
		private string[] m_objApplyUnitIDArr;
		private clsTestApplyItme_VO[] m_objChargeInfoArr;
		/// <summary>
		/// [获取]需要生成收费信息的申请单元ID数组
		/// </summary>
		public string[] ApplyUnitIDArr
		{
			get
			{
				return m_objApplyUnitIDArr;
			}
		}
		/// <summary>
		/// [获取][设置]根据申请单元ID数组生成的收费信息请放入此数组
		/// </summary>
		public clsTestApplyItme_VO[] ChargeInfoArr
		{
			get
			{
				return m_objChargeInfoArr;
			}
			set
			{
				m_objChargeInfoArr = value;
			}
		}
		public clsRequestChargeInfoEventArgs(string[] p_objApplyUnitIDArr)
		{
			this.m_objApplyUnitIDArr = p_objApplyUnitIDArr;
		}
	}
	public delegate void dlgRequestChargeInfoEventHandler(clsRequestChargeInfoEventArgs e);
    public class clsLISAppResults
    {
        /// <summary>
        /// 申请单ID
        /// </summary>
        public string m_StrApplicationID;
        /// <summary>
        /// 申请内容
        /// </summary>
        public string m_StrAppCheckContentDesc;
        /// <summary>
        /// 申请单元数组
        /// </summary>
        public string[] m_ObjApplyUnitIDArr;
        /// <summary>
        /// 样本类型ID
        /// </summary>
        public string m_strSampleTypeID;
        /// <summary>
        /// 样本类型名
        /// </summary>
        public string m_strSampleTypeName;
        /// <summary> 
        /// 收费项目ID
        /// </summary>
        public string[] m_strChargeIDs;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        public string[] m_arrOrderId;
    }
    #region 分单接口
    public class clsLIS_ApplyUnitsCarver
	{
		/// <summary>
        /// 根据传入的申请单元ID数组进行分单。
        /// </summary>
        /// <param name="strApplyUnitIDArr"></param>
        /// <returns>ArrayList中每个元素代表分出的一张单,类型为string[]表示此单所包含的申请单元ID数组.</returns>
        public static ArrayList m_mthMakeResult(string[] strApplyUnitIDArr)
        {
            ArrayList arlUnits = new ArrayList();

            if (strApplyUnitIDArr == null)
            {
                return arlUnits;
            }
            clsController_AppCheckContent objControllerCheckContent = new clsController_AppCheckContent(null);
            objControllerCheckContent.m_mthGenerateAppContent(strApplyUnitIDArr);

            if (objControllerCheckContent.m_objApps == null)
                return arlUnits;

            ArrayList arl = new ArrayList();
            for (int i = 0; i < objControllerCheckContent.m_objApps.Count; i++)
            {
                string[] strUnits = new string[objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits.Count];
                for (int j = 0; j < objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits.Count; j++)
                {
                    strUnits[j] = objControllerCheckContent.m_objApps[i].m_ObjAppApplyUnits[j].m_StrApplyUnitID;
                }
                arl.Add(strUnits);
            }
            foreach (string[] strArr in arl)
            {
                clsSeparateCheckApplication objSep = new clsSeparateCheckApplication();
                clsSeparatedApp[] objSepApps = objSep.m_mthSeparateCheckApplication(strArr);
                foreach (clsSeparatedApp obj in objSepApps)
                {
                    arlUnits.Add(obj.m_strApplyUnits);
                }
            }
            return arlUnits;
        }
        #endregion
	}

}
