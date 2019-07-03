using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 门诊样本采集界面
    /// </summary>
    public class frmSampleCollection : frmMDI_Child_Base
    {

        #region 私有成员

        public static readonly string MESSAGETITLE = "iCare-样本采集";
        private clsSampleCollectionController m_objController;
        /// <summary>
        /// 申请单样式 0 普通式 1 伦教式
        /// </summary>
        private int BillStyle = 0;
        /// <summary>
        /// 采样人员ID
        /// </summary>
        private string m_strSubmitDoctorId = string.Empty;
        /// <summary>
        /// 是否跳过采集
        /// </summary>
        private int intSkipStyle = 0;

        /// <summary>
        /// 微信推送信息地址
        /// </summary>
        string WechatWebUrl { get; set; }

        #endregion

        #region FormControl
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label lblApplDeptID;
        private System.Windows.Forms.Label lblApplEmpID;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblPatientSubNo;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chApplDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.ColumnHeader chApplNO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblOperatorID;
        private System.Windows.Forms.Label lblSampleType;
        internal System.Windows.Forms.TabControl m_tabControlCollection;
        private PinkieControls.ButtonXP m_btnQuery;
        private System.Windows.Forms.GroupBox m_gpbPatientInfo;
        private System.Windows.Forms.Panel m_palPatientInfo;
        internal System.Windows.Forms.Label lbApplDept;
        private System.Windows.Forms.ColumnHeader chStatus;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
        internal System.Windows.Forms.GroupBox m_grpQuery;
        internal System.Windows.Forms.DateTimePicker m_dtpToDate;
        internal System.Windows.Forms.DateTimePicker m_dtpFromDate;
        internal System.Windows.Forms.RadioButton m_rdbAll;
        internal System.Windows.Forms.RadioButton m_rdbSampled;
        internal System.Windows.Forms.RadioButton m_rdbNotSampled;
        internal System.Windows.Forms.ListView m_lsvApplication;
        internal System.Windows.Forms.TextBox m_txtBedNo;
        internal System.Windows.Forms.TextBox m_txtSex;
        internal System.Windows.Forms.TextBox m_txtAge;
        internal System.Windows.Forms.TextBox m_txtPatientName;
        internal System.Windows.Forms.TextBox m_txtPatientInhosNO;
        internal System.Windows.Forms.TextBox m_txtApplicationID;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtOperatorID;
        internal System.Windows.Forms.TextBox m_txtBarCode;
        internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDeptQuery;
        internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDept;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox m_txtSampleType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker m_dtpSamplingDate;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox m_txtSamplingRule;
        private System.Windows.Forms.GroupBox m_grpWork;
        internal System.Windows.Forms.TabPage m_tabPageApplication;
        private PinkieControls.ButtonXP m_btnConfirm;
        internal System.Windows.Forms.TextBox m_txtCheckContent;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox m_txtFlagSepcial;
        internal System.Windows.Forms.TextBox m_txtFlagEmergency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label m_lblChargeState;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox m_txtPatientType;
        private PinkieControls.ButtonXP btnChangeEmergency;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPatientName;
        private PinkieControls.ButtonXP btnModifyBarCode;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox m_txtChargeItemName;
        private PinkieControls.ButtonXP btnPrintView;
        private PinkieControls.ButtonXP btnPrint;
        private PinkieControls.ButtonXP btnExit;
        private Label label12;
        private Label m_lblSubmitDoctor;
        internal PinkieControls.ButtonXP m_btnLogin;
        internal PinkieControls.ButtonXP m_btnExit;
        internal RadioButton m_rabAll;
        internal RadioButton m_rabUnQualified;
        internal RadioButton m_rabQualified;
        internal RadioButton m_rabAccept;
        internal RadioButton m_rabNotAccept;
        internal RadioButton m_rabAllAccept;
        private ColumnHeader chSampleBackReason;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        internal com.digitalwave.controls.clsCardTextBox txtPatientCardID;
        private ColumnHeader chPrint;
        private System.Windows.Forms.Panel m_palSamplingInfo;
        #endregion

        #region 构造函数
        public frmSampleCollection()
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
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.clsSampleCollectionController();
            this.objController.Set_GUI_Apperance(this);
            m_objController = (clsSampleCollectionController)objController;
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

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleCollection));
            this.m_grpQuery = new System.Windows.Forms.GroupBox();
            this.txtPatientCardID = new com.digitalwave.controls.clsCardTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_rabAll = new System.Windows.Forms.RadioButton();
            this.m_rabQualified = new System.Windows.Forms.RadioButton();
            this.m_rabUnQualified = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rabAllAccept = new System.Windows.Forms.RadioButton();
            this.m_rabAccept = new System.Windows.Forms.RadioButton();
            this.m_rabNotAccept = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.m_rdbNotSampled = new System.Windows.Forms.RadioButton();
            this.m_rdbSampled = new System.Windows.Forms.RadioButton();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbApplDept = new System.Windows.Forms.Label();
            this.m_txtAppDeptQuery = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lsvApplication = new System.Windows.Forms.ListView();
            this.chApplNO = new System.Windows.Forms.ColumnHeader();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chApplDate = new System.Windows.Forms.ColumnHeader();
            this.chStatus = new System.Windows.Forms.ColumnHeader();
            this.chSampleBackReason = new System.Windows.Forms.ColumnHeader();
            this.m_txtBedNo = new System.Windows.Forms.TextBox();
            this.m_txtSex = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.m_txtAge = new System.Windows.Forms.TextBox();
            this.m_txtPatientName = new System.Windows.Forms.TextBox();
            this.lblApplDeptID = new System.Windows.Forms.Label();
            this.lblApplEmpID = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.m_txtPatientInhosNO = new System.Windows.Forms.TextBox();
            this.lblPatientSubNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtApplicationID = new System.Windows.Forms.TextBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnLogin = new PinkieControls.ButtonXP();
            this.m_lblSubmitDoctor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnModifyBarCode = new PinkieControls.ButtonXP();
            this.btnChangeEmergency = new PinkieControls.ButtonXP();
            this.m_lblChargeState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_grpWork = new System.Windows.Forms.GroupBox();
            this.m_palSamplingInfo = new System.Windows.Forms.Panel();
            this.m_dtpSamplingDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrintView = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtSampleType = new System.Windows.Forms.TextBox();
            this.m_btnConfirm = new PinkieControls.ButtonXP();
            this.m_txtOperatorID = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_txtBarCode = new System.Windows.Forms.TextBox();
            this.lblOperatorID = new System.Windows.Forms.Label();
            this.lblSampleType = new System.Windows.Forms.Label();
            this.m_txtSamplingRule = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.m_gpbPatientInfo = new System.Windows.Forms.GroupBox();
            this.m_palPatientInfo = new System.Windows.Forms.Panel();
            this.m_txtChargeItemName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtPatientType = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtFlagSepcial = new System.Windows.Forms.TextBox();
            this.m_txtFlagEmergency = new System.Windows.Forms.TextBox();
            this.m_txtCheckContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtAppDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_tabControlCollection = new System.Windows.Forms.TabControl();
            this.m_tabPageApplication = new System.Windows.Forms.TabPage();
            this.chPrint = new System.Windows.Forms.ColumnHeader();
            this.m_grpQuery.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_grpWork.SuspendLayout();
            this.m_palSamplingInfo.SuspendLayout();
            this.m_gpbPatientInfo.SuspendLayout();
            this.m_palPatientInfo.SuspendLayout();
            this.m_tabControlCollection.SuspendLayout();
            this.m_tabPageApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpQuery
            // 
            this.m_grpQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_grpQuery.Controls.Add(this.txtPatientCardID);
            this.m_grpQuery.Controls.Add(this.groupBox3);
            this.m_grpQuery.Controls.Add(this.groupBox2);
            this.m_grpQuery.Controls.Add(this.groupBox1);
            this.m_grpQuery.Controls.Add(this.txtPatientName);
            this.m_grpQuery.Controls.Add(this.label10);
            this.m_grpQuery.Controls.Add(this.label9);
            this.m_grpQuery.Controls.Add(this.lbApplDept);
            this.m_grpQuery.Controls.Add(this.m_txtAppDeptQuery);
            this.m_grpQuery.Controls.Add(this.m_btnQuery);
            this.m_grpQuery.Controls.Add(this.label3);
            this.m_grpQuery.Controls.Add(this.m_dtpToDate);
            this.m_grpQuery.Controls.Add(this.m_dtpFromDate);
            this.m_grpQuery.Controls.Add(this.label2);
            this.m_grpQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_grpQuery.Location = new System.Drawing.Point(352, 4);
            this.m_grpQuery.Name = "m_grpQuery";
            this.m_grpQuery.Size = new System.Drawing.Size(897, 121);
            this.m_grpQuery.TabIndex = 1;
            this.m_grpQuery.TabStop = false;
            this.m_grpQuery.Text = "查询";
            // 
            // txtPatientCardID
            // 
            this.txtPatientCardID.Location = new System.Drawing.Point(400, 49);
            this.txtPatientCardID.MaxLength = 50;
            this.txtPatientCardID.Name = "txtPatientCardID";
            this.txtPatientCardID.PatientCard = "";
            this.txtPatientCardID.PatientFlag = 0;
            this.txtPatientCardID.Size = new System.Drawing.Size(124, 23);
            this.txtPatientCardID.TabIndex = 9;
            this.txtPatientCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPatientCardID.YBCardText = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_rabAll);
            this.groupBox3.Controls.Add(this.m_rabQualified);
            this.groupBox3.Controls.Add(this.m_rabUnQualified);
            this.groupBox3.Location = new System.Drawing.Point(426, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 46);
            this.groupBox3.TabIndex = 232;
            this.groupBox3.TabStop = false;
            // 
            // m_rabAll
            // 
            this.m_rabAll.Location = new System.Drawing.Point(140, 14);
            this.m_rabAll.Name = "m_rabAll";
            this.m_rabAll.Size = new System.Drawing.Size(56, 24);
            this.m_rabAll.TabIndex = 11;
            this.m_rabAll.Text = "全部";
            this.m_rabAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rabQualified
            // 
            this.m_rabQualified.Checked = true;
            this.m_rabQualified.Location = new System.Drawing.Point(6, 14);
            this.m_rabQualified.Name = "m_rabQualified";
            this.m_rabQualified.Size = new System.Drawing.Size(54, 24);
            this.m_rabQualified.TabIndex = 9;
            this.m_rabQualified.TabStop = true;
            this.m_rabQualified.Text = "合格";
            this.m_rabQualified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rabUnQualified
            // 
            this.m_rabUnQualified.Location = new System.Drawing.Point(61, 14);
            this.m_rabUnQualified.Name = "m_rabUnQualified";
            this.m_rabUnQualified.Size = new System.Drawing.Size(72, 24);
            this.m_rabUnQualified.TabIndex = 10;
            this.m_rabUnQualified.Text = "不合格";
            this.m_rabUnQualified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rabAllAccept);
            this.groupBox2.Controls.Add(this.m_rabAccept);
            this.groupBox2.Controls.Add(this.m_rabNotAccept);
            this.groupBox2.Location = new System.Drawing.Point(221, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 46);
            this.groupBox2.TabIndex = 231;
            this.groupBox2.TabStop = false;
            // 
            // m_rabAllAccept
            // 
            this.m_rabAllAccept.Location = new System.Drawing.Point(142, 14);
            this.m_rabAllAccept.Name = "m_rabAllAccept";
            this.m_rabAllAccept.Size = new System.Drawing.Size(56, 24);
            this.m_rabAllAccept.TabIndex = 7;
            this.m_rabAllAccept.Text = "全部";
            this.m_rabAllAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rabAccept
            // 
            this.m_rabAccept.Location = new System.Drawing.Point(70, 14);
            this.m_rabAccept.Name = "m_rabAccept";
            this.m_rabAccept.Size = new System.Drawing.Size(72, 24);
            this.m_rabAccept.TabIndex = 9;
            this.m_rabAccept.Text = "已核收";
            this.m_rabAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rabNotAccept
            // 
            this.m_rabNotAccept.Checked = true;
            this.m_rabNotAccept.Location = new System.Drawing.Point(3, 14);
            this.m_rabNotAccept.Name = "m_rabNotAccept";
            this.m_rabNotAccept.Size = new System.Drawing.Size(72, 24);
            this.m_rabNotAccept.TabIndex = 8;
            this.m_rabNotAccept.TabStop = true;
            this.m_rabNotAccept.Text = "未核收";
            this.m_rabNotAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdbAll);
            this.groupBox1.Controls.Add(this.m_rdbNotSampled);
            this.groupBox1.Controls.Add(this.m_rdbSampled);
            this.groupBox1.Location = new System.Drawing.Point(10, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 46);
            this.groupBox1.TabIndex = 230;
            this.groupBox1.TabStop = false;
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.Checked = true;
            this.m_rdbAll.Location = new System.Drawing.Point(145, 14);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(57, 24);
            this.m_rdbAll.TabIndex = 6;
            this.m_rdbAll.TabStop = true;
            this.m_rdbAll.Text = "全部";
            this.m_rdbAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rdbNotSampled
            // 
            this.m_rdbNotSampled.Location = new System.Drawing.Point(5, 14);
            this.m_rdbNotSampled.Name = "m_rdbNotSampled";
            this.m_rdbNotSampled.Size = new System.Drawing.Size(68, 24);
            this.m_rdbNotSampled.TabIndex = 4;
            this.m_rdbNotSampled.Text = "未采样";
            this.m_rdbNotSampled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_rdbSampled
            // 
            this.m_rdbSampled.Location = new System.Drawing.Point(75, 14);
            this.m_rdbSampled.Name = "m_rdbSampled";
            this.m_rdbSampled.Size = new System.Drawing.Size(72, 24);
            this.m_rdbSampled.TabIndex = 5;
            this.m_rdbSampled.Text = "已采样";
            this.m_rdbSampled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(400, 20);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(123, 23);
            this.txtPatientName.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 99;
            this.label10.Text = "病人诊疗卡号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(333, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 98;
            this.label9.Text = "病人姓名";
            // 
            // lbApplDept
            // 
            this.lbApplDept.AutoSize = true;
            this.lbApplDept.Location = new System.Drawing.Point(12, 52);
            this.lbApplDept.Name = "lbApplDept";
            this.lbApplDept.Size = new System.Drawing.Size(63, 14);
            this.lbApplDept.TabIndex = 97;
            this.lbApplDept.Text = "申请科室";
            // 
            // m_txtAppDeptQuery
            // 
            this.m_txtAppDeptQuery.EnableAutoValidation = true;
            this.m_txtAppDeptQuery.EnableEnterKeyValidate = true;
            this.m_txtAppDeptQuery.EnableEscapeKeyUndo = true;
            this.m_txtAppDeptQuery.EnableLastValidValue = true;
            this.m_txtAppDeptQuery.ErrorProvider = null;
            this.m_txtAppDeptQuery.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDeptQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDeptQuery.ForceFormatText = true;
            this.m_txtAppDeptQuery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDeptQuery.Location = new System.Drawing.Point(76, 44);
            this.m_txtAppDeptQuery.m_StrDeptID = null;
            this.m_txtAppDeptQuery.m_StrDeptName = null;
            this.m_txtAppDeptQuery.MaxLength = 20;
            this.m_txtAppDeptQuery.Name = "m_txtAppDeptQuery";
            this.m_txtAppDeptQuery.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDeptQuery.Size = new System.Drawing.Size(220, 23);
            this.m_txtAppDeptQuery.TabIndex = 3;
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(531, 38);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(87, 28);
            this.m_btnQuery.TabIndex = 10;
            this.m_btnQuery.Text = "查询(F5)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(176, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 92;
            this.label3.Text = "至";
            // 
            // m_dtpToDate
            // 
            this.m_dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpToDate.Location = new System.Drawing.Point(200, 20);
            this.m_dtpToDate.Name = "m_dtpToDate";
            this.m_dtpToDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpToDate.TabIndex = 2;
            // 
            // m_dtpFromDate
            // 
            this.m_dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFromDate.Location = new System.Drawing.Point(76, 20);
            this.m_dtpFromDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.m_dtpFromDate.Name = "m_dtpFromDate";
            this.m_dtpFromDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpFromDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 89;
            this.label2.Text = "申请日期";
            // 
            // m_lsvApplication
            // 
            this.m_lsvApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvApplication.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chApplNO,
            this.chName,
            this.chApplDate,
            this.chPrint,
            this.chStatus,
            this.chSampleBackReason});
            this.m_lsvApplication.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lsvApplication.FullRowSelect = true;
            this.m_lsvApplication.GridLines = true;
            this.m_lsvApplication.HideSelection = false;
            this.m_lsvApplication.Location = new System.Drawing.Point(4, 24);
            this.m_lsvApplication.Name = "m_lsvApplication";
            this.m_lsvApplication.Size = new System.Drawing.Size(336, 501);
            this.m_lsvApplication.TabIndex = 2;
            this.m_lsvApplication.UseCompatibleStateImageBehavior = false;
            this.m_lsvApplication.View = System.Windows.Forms.View.Details;
            this.m_lsvApplication.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvApplication_MouseUp);
            this.m_lsvApplication.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvApplication_KeyDown);
            this.m_lsvApplication.Click += new System.EventHandler(this.m_lsvApplication_Click);
            // 
            // chApplNO
            // 
            this.chApplNO.Text = "申请单号";
            this.chApplNO.Width = 80;
            // 
            // chName
            // 
            this.chName.Text = "患者姓名";
            this.chName.Width = 80;
            // 
            // chApplDate
            // 
            this.chApplDate.Text = "申请日期";
            this.chApplDate.Width = 100;
            // 
            // chStatus
            // 
            this.chStatus.Text = "状态";
            this.chStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chStatus.Width = 48;
            // 
            // chSampleBackReason
            // 
            this.chSampleBackReason.Text = "拒收标本原因";
            this.chSampleBackReason.Width = 100;
            // 
            // m_txtBedNo
            // 
            this.m_txtBedNo.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtBedNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBedNo.Location = new System.Drawing.Point(496, 36);
            this.m_txtBedNo.Name = "m_txtBedNo";
            this.m_txtBedNo.ReadOnly = true;
            this.m_txtBedNo.Size = new System.Drawing.Size(108, 23);
            this.m_txtBedNo.TabIndex = 76;
            this.m_txtBedNo.TabStop = false;
            // 
            // m_txtSex
            // 
            this.m_txtSex.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtSex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSex.Location = new System.Drawing.Point(316, 36);
            this.m_txtSex.Name = "m_txtSex";
            this.m_txtSex.ReadOnly = true;
            this.m_txtSex.Size = new System.Drawing.Size(108, 23);
            this.m_txtSex.TabIndex = 75;
            this.m_txtSex.TabStop = false;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(280, 40);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(35, 14);
            this.lblSex.TabIndex = 74;
            this.lblSex.Text = "性别";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBedNo
            // 
            this.lblBedNo.AutoSize = true;
            this.lblBedNo.Location = new System.Drawing.Point(456, 40);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(35, 14);
            this.lblBedNo.TabIndex = 73;
            this.lblBedNo.Text = "床号";
            this.lblBedNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtAge
            // 
            this.m_txtAge.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtAge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAge.Location = new System.Drawing.Point(316, 60);
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.ReadOnly = true;
            this.m_txtAge.Size = new System.Drawing.Size(108, 23);
            this.m_txtAge.TabIndex = 70;
            this.m_txtAge.TabStop = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtPatientName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientName.Location = new System.Drawing.Point(316, 12);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.ReadOnly = true;
            this.m_txtPatientName.Size = new System.Drawing.Size(108, 23);
            this.m_txtPatientName.TabIndex = 67;
            this.m_txtPatientName.TabStop = false;
            // 
            // lblApplDeptID
            // 
            this.lblApplDeptID.AutoSize = true;
            this.lblApplDeptID.Location = new System.Drawing.Point(428, 16);
            this.lblApplDeptID.Name = "lblApplDeptID";
            this.lblApplDeptID.Size = new System.Drawing.Size(63, 14);
            this.lblApplDeptID.TabIndex = 66;
            this.lblApplDeptID.Text = "申请科室";
            this.lblApplDeptID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApplEmpID
            // 
            this.lblApplEmpID.AutoSize = true;
            this.lblApplEmpID.Location = new System.Drawing.Point(428, 64);
            this.lblApplEmpID.Name = "lblApplEmpID";
            this.lblApplEmpID.Size = new System.Drawing.Size(63, 14);
            this.lblApplEmpID.TabIndex = 65;
            this.lblApplEmpID.Text = "申请医生";
            this.lblApplEmpID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(280, 16);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(35, 14);
            this.lblPatientName.TabIndex = 63;
            this.lblPatientName.Text = "姓名";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(280, 64);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(35, 14);
            this.lblAge.TabIndex = 62;
            this.lblAge.Text = "年龄";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPatientInhosNO
            // 
            this.m_txtPatientInhosNO.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtPatientInhosNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientInhosNO.Location = new System.Drawing.Point(84, 12);
            this.m_txtPatientInhosNO.Name = "m_txtPatientInhosNO";
            this.m_txtPatientInhosNO.ReadOnly = true;
            this.m_txtPatientInhosNO.Size = new System.Drawing.Size(184, 23);
            this.m_txtPatientInhosNO.TabIndex = 61;
            this.m_txtPatientInhosNO.TabStop = false;
            // 
            // lblPatientSubNo
            // 
            this.lblPatientSubNo.AutoSize = true;
            this.lblPatientSubNo.Location = new System.Drawing.Point(4, 16);
            this.lblPatientSubNo.Name = "lblPatientSubNo";
            this.lblPatientSubNo.Size = new System.Drawing.Size(77, 14);
            this.lblPatientSubNo.TabIndex = 58;
            this.lblPatientSubNo.Text = "门诊住院号";
            this.lblPatientSubNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 16);
            this.label1.TabIndex = 90;
            this.label1.Text = "检验申请单";
            // 
            // m_txtApplicationID
            // 
            this.m_txtApplicationID.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtApplicationID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtApplicationID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtApplicationID.Location = new System.Drawing.Point(84, 36);
            this.m_txtApplicationID.Name = "m_txtApplicationID";
            this.m_txtApplicationID.ReadOnly = true;
            this.m_txtApplicationID.Size = new System.Drawing.Size(184, 23);
            this.m_txtApplicationID.TabIndex = 55;
            this.m_txtApplicationID.TabStop = false;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblApplicationID.Location = new System.Drawing.Point(32, 40);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(49, 14);
            this.lblApplicationID.TabIndex = 54;
            this.lblApplicationID.Text = "申请号";
            this.lblApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_btnLogin);
            this.panel1.Controls.Add(this.m_lblSubmitDoctor);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnModifyBarCode);
            this.panel1.Controls.Add(this.btnChangeEmergency);
            this.panel1.Controls.Add(this.m_lblChargeState);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.m_grpWork);
            this.panel1.Controls.Add(this.m_gpbPatientInfo);
            this.panel1.Controls.Add(this.m_grpQuery);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_lsvApplication);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 535);
            this.panel1.TabIndex = 102;
            // 
            // m_btnExit
            // 
            this.m_btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(857, 132);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(62, 28);
            this.m_btnExit.TabIndex = 229;
            this.m_btnExit.Text = "退出(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnLogin
            // 
            this.m_btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnLogin.DefaultScheme = true;
            this.m_btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnLogin.Hint = "";
            this.m_btnLogin.Location = new System.Drawing.Point(785, 132);
            this.m_btnLogin.Name = "m_btnLogin";
            this.m_btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnLogin.Size = new System.Drawing.Size(67, 28);
            this.m_btnLogin.TabIndex = 228;
            this.m_btnLogin.Text = "登录(&W)";
            this.m_btnLogin.Click += new System.EventHandler(this.m_btnLogin_Click);
            // 
            // m_lblSubmitDoctor
            // 
            this.m_lblSubmitDoctor.AutoSize = true;
            this.m_lblSubmitDoctor.Location = new System.Drawing.Point(441, 154);
            this.m_lblSubmitDoctor.Name = "m_lblSubmitDoctor";
            this.m_lblSubmitDoctor.Size = new System.Drawing.Size(35, 14);
            this.m_lblSubmitDoctor.TabIndex = 227;
            this.m_lblSubmitDoctor.Text = "(空)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(358, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 14);
            this.label12.TabIndex = 226;
            this.label12.Text = "登录采样人：";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(1187, 132);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(60, 28);
            this.btnExit.TabIndex = 225;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(1114, 132);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(68, 28);
            this.btnPrint.TabIndex = 224;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnModifyBarCode
            // 
            this.btnModifyBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnModifyBarCode.DefaultScheme = true;
            this.btnModifyBarCode.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnModifyBarCode.Hint = "";
            this.btnModifyBarCode.Location = new System.Drawing.Point(924, 132);
            this.btnModifyBarCode.Name = "btnModifyBarCode";
            this.btnModifyBarCode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnModifyBarCode.Size = new System.Drawing.Size(87, 28);
            this.btnModifyBarCode.TabIndex = 223;
            this.btnModifyBarCode.Text = "修改条码号";
            this.btnModifyBarCode.Click += new System.EventHandler(this.btnModifyBarCode_Click);
            // 
            // btnChangeEmergency
            // 
            this.btnChangeEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeEmergency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnChangeEmergency.DefaultScheme = true;
            this.btnChangeEmergency.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChangeEmergency.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeEmergency.Hint = "";
            this.btnChangeEmergency.Location = new System.Drawing.Point(1016, 132);
            this.btnChangeEmergency.Name = "btnChangeEmergency";
            this.btnChangeEmergency.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnChangeEmergency.Size = new System.Drawing.Size(93, 28);
            this.btnChangeEmergency.TabIndex = 94;
            this.btnChangeEmergency.Text = "改变急诊状态";
            this.btnChangeEmergency.Click += new System.EventHandler(this.btnChangeEmergency_Click);
            // 
            // m_lblChargeState
            // 
            this.m_lblChargeState.Location = new System.Drawing.Point(435, 124);
            this.m_lblChargeState.Name = "m_lblChargeState";
            this.m_lblChargeState.Size = new System.Drawing.Size(229, 23);
            this.m_lblChargeState.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 91;
            this.label8.Text = "收费状态:";
            // 
            // m_grpWork
            // 
            this.m_grpWork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_grpWork.Controls.Add(this.m_palSamplingInfo);
            this.m_grpWork.Location = new System.Drawing.Point(352, 352);
            this.m_grpWork.Name = "m_grpWork";
            this.m_grpWork.Size = new System.Drawing.Size(893, 177);
            this.m_grpWork.TabIndex = 3;
            this.m_grpWork.TabStop = false;
            this.m_grpWork.Text = "采样";
            // 
            // m_palSamplingInfo
            // 
            this.m_palSamplingInfo.Controls.Add(this.m_dtpSamplingDate);
            this.m_palSamplingInfo.Controls.Add(this.btnPrintView);
            this.m_palSamplingInfo.Controls.Add(this.label5);
            this.m_palSamplingInfo.Controls.Add(this.m_txtSampleType);
            this.m_palSamplingInfo.Controls.Add(this.m_btnConfirm);
            this.m_palSamplingInfo.Controls.Add(this.m_txtOperatorID);
            this.m_palSamplingInfo.Controls.Add(this.m_txtBarCode);
            this.m_palSamplingInfo.Controls.Add(this.lblOperatorID);
            this.m_palSamplingInfo.Controls.Add(this.lblSampleType);
            this.m_palSamplingInfo.Controls.Add(this.m_txtSamplingRule);
            this.m_palSamplingInfo.Controls.Add(this.label6);
            this.m_palSamplingInfo.Controls.Add(this.lblBarCode);
            this.m_palSamplingInfo.Enabled = false;
            this.m_palSamplingInfo.Location = new System.Drawing.Point(4, 28);
            this.m_palSamplingInfo.Name = "m_palSamplingInfo";
            this.m_palSamplingInfo.Size = new System.Drawing.Size(608, 144);
            this.m_palSamplingInfo.TabIndex = 104;
            // 
            // m_dtpSamplingDate
            // 
            this.m_dtpSamplingDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dtpSamplingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSamplingDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_dtpSamplingDate.Location = new System.Drawing.Point(256, 32);
            this.m_dtpSamplingDate.Name = "m_dtpSamplingDate";
            this.m_dtpSamplingDate.Size = new System.Drawing.Size(184, 23);
            this.m_dtpSamplingDate.TabIndex = 4;
            this.m_dtpSamplingDate.TabStop = false;
            // 
            // btnPrintView
            // 
            this.btnPrintView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrintView.DefaultScheme = true;
            this.btnPrintView.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintView.Hint = "";
            this.btnPrintView.Location = new System.Drawing.Point(463, 56);
            this.btnPrintView.Name = "btnPrintView";
            this.btnPrintView.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintView.Size = new System.Drawing.Size(77, 28);
            this.btnPrintView.TabIndex = 95;
            this.btnPrintView.Text = "申请单预览";
            this.btnPrintView.Visible = false;
            this.btnPrintView.Click += new System.EventHandler(this.btnPrintView_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 222;
            this.label5.Text = "采样时间";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSampleType
            // 
            this.m_txtSampleType.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtSampleType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtSampleType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSampleType.Location = new System.Drawing.Point(76, 8);
            this.m_txtSampleType.Name = "m_txtSampleType";
            this.m_txtSampleType.ReadOnly = true;
            this.m_txtSampleType.Size = new System.Drawing.Size(112, 23);
            this.m_txtSampleType.TabIndex = 1;
            this.m_txtSampleType.TabStop = false;
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnConfirm.DefaultScheme = true;
            this.m_btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnConfirm.Hint = "";
            this.m_btnConfirm.Location = new System.Drawing.Point(446, 8);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirm.Size = new System.Drawing.Size(87, 28);
            this.m_btnConfirm.TabIndex = 6;
            this.m_btnConfirm.Text = "确定(F4)";
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // m_txtOperatorID
            // 
            this.m_txtOperatorID.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtOperatorID.EnableAutoValidation = true;
            this.m_txtOperatorID.EnableEnterKeyValidate = true;
            this.m_txtOperatorID.EnableEscapeKeyUndo = true;
            this.m_txtOperatorID.EnableLastValidValue = true;
            this.m_txtOperatorID.ErrorProvider = null;
            this.m_txtOperatorID.ErrorProviderMessage = "Invalid value";
            this.m_txtOperatorID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperatorID.ForceFormatText = true;
            this.m_txtOperatorID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOperatorID.Location = new System.Drawing.Point(76, 32);
            this.m_txtOperatorID.m_intShowOtherEmp = 0;
            this.m_txtOperatorID.m_StrDeptID = "*";
            this.m_txtOperatorID.m_StrEmployeeID = null;
            this.m_txtOperatorID.m_StrEmployeeName = null;
            this.m_txtOperatorID.MaxLength = 7;
            this.m_txtOperatorID.Name = "m_txtOperatorID";
            this.m_txtOperatorID.ReadOnly = true;
            this.m_txtOperatorID.Size = new System.Drawing.Size(112, 23);
            this.m_txtOperatorID.TabIndex = 2;
            this.m_txtOperatorID.TabStop = false;
            // 
            // m_txtBarCode
            // 
            this.m_txtBarCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtBarCode.Location = new System.Drawing.Point(256, 8);
            this.m_txtBarCode.MaxLength = 100;
            this.m_txtBarCode.Name = "m_txtBarCode";
            this.m_txtBarCode.Size = new System.Drawing.Size(184, 23);
            this.m_txtBarCode.TabIndex = 3;
            this.m_txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBarCode_KeyDown);
            // 
            // lblOperatorID
            // 
            this.lblOperatorID.AutoSize = true;
            this.lblOperatorID.Location = new System.Drawing.Point(8, 36);
            this.lblOperatorID.Name = "lblOperatorID";
            this.lblOperatorID.Size = new System.Drawing.Size(63, 14);
            this.lblOperatorID.TabIndex = 89;
            this.lblOperatorID.Text = "采样人员";
            this.lblOperatorID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSampleType
            // 
            this.lblSampleType.AutoSize = true;
            this.lblSampleType.Location = new System.Drawing.Point(8, 12);
            this.lblSampleType.Name = "lblSampleType";
            this.lblSampleType.Size = new System.Drawing.Size(63, 14);
            this.lblSampleType.TabIndex = 87;
            this.lblSampleType.Text = "样品类别";
            this.lblSampleType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSamplingRule
            // 
            this.m_txtSamplingRule.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtSamplingRule.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtSamplingRule.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSamplingRule.Location = new System.Drawing.Point(76, 56);
            this.m_txtSamplingRule.Multiline = true;
            this.m_txtSamplingRule.Name = "m_txtSamplingRule";
            this.m_txtSamplingRule.ReadOnly = true;
            this.m_txtSamplingRule.Size = new System.Drawing.Size(364, 72);
            this.m_txtSamplingRule.TabIndex = 5;
            this.m_txtSamplingRule.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "采样说明";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(188, 12);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(63, 14);
            this.lblBarCode.TabIndex = 90;
            this.lblBarCode.Text = "样本条码";
            this.lblBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_gpbPatientInfo
            // 
            this.m_gpbPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbPatientInfo.Controls.Add(this.m_palPatientInfo);
            this.m_gpbPatientInfo.Location = new System.Drawing.Point(352, 175);
            this.m_gpbPatientInfo.Name = "m_gpbPatientInfo";
            this.m_gpbPatientInfo.Size = new System.Drawing.Size(893, 172);
            this.m_gpbPatientInfo.TabIndex = 2;
            this.m_gpbPatientInfo.TabStop = false;
            this.m_gpbPatientInfo.Text = "患者基本信息";
            // 
            // m_palPatientInfo
            // 
            this.m_palPatientInfo.Controls.Add(this.m_txtChargeItemName);
            this.m_palPatientInfo.Controls.Add(this.label11);
            this.m_palPatientInfo.Controls.Add(this.m_txtPatientType);
            this.m_palPatientInfo.Controls.Add(this.label17);
            this.m_palPatientInfo.Controls.Add(this.label7);
            this.m_palPatientInfo.Controls.Add(this.m_txtFlagSepcial);
            this.m_palPatientInfo.Controls.Add(this.m_txtFlagEmergency);
            this.m_palPatientInfo.Controls.Add(this.m_txtPatientName);
            this.m_palPatientInfo.Controls.Add(this.m_txtCheckContent);
            this.m_palPatientInfo.Controls.Add(this.label4);
            this.m_palPatientInfo.Controls.Add(this.m_txtPatientInhosNO);
            this.m_palPatientInfo.Controls.Add(this.lblPatientSubNo);
            this.m_palPatientInfo.Controls.Add(this.m_txtApplicationID);
            this.m_palPatientInfo.Controls.Add(this.lblApplicationID);
            this.m_palPatientInfo.Controls.Add(this.lblPatientName);
            this.m_palPatientInfo.Controls.Add(this.lblAge);
            this.m_palPatientInfo.Controls.Add(this.m_txtAge);
            this.m_palPatientInfo.Controls.Add(this.m_txtSex);
            this.m_palPatientInfo.Controls.Add(this.lblSex);
            this.m_palPatientInfo.Controls.Add(this.lblApplEmpID);
            this.m_palPatientInfo.Controls.Add(this.lblBedNo);
            this.m_palPatientInfo.Controls.Add(this.m_txtBedNo);
            this.m_palPatientInfo.Controls.Add(this.lblApplDeptID);
            this.m_palPatientInfo.Controls.Add(this.m_txtAppDept);
            this.m_palPatientInfo.Controls.Add(this.m_txtAppDoct);
            this.m_palPatientInfo.Location = new System.Drawing.Point(8, 20);
            this.m_palPatientInfo.Name = "m_palPatientInfo";
            this.m_palPatientInfo.Size = new System.Drawing.Size(608, 140);
            this.m_palPatientInfo.TabIndex = 0;
            // 
            // m_txtChargeItemName
            // 
            this.m_txtChargeItemName.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtChargeItemName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtChargeItemName.Location = new System.Drawing.Point(84, 108);
            this.m_txtChargeItemName.Name = "m_txtChargeItemName";
            this.m_txtChargeItemName.ReadOnly = true;
            this.m_txtChargeItemName.Size = new System.Drawing.Size(520, 23);
            this.m_txtChargeItemName.TabIndex = 119;
            this.m_txtChargeItemName.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 118;
            this.label11.Text = "收费项目";
            // 
            // m_txtPatientType
            // 
            this.m_txtPatientType.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtPatientType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPatientType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientType.Location = new System.Drawing.Point(84, 60);
            this.m_txtPatientType.Name = "m_txtPatientType";
            this.m_txtPatientType.ReadOnly = true;
            this.m_txtPatientType.Size = new System.Drawing.Size(184, 23);
            this.m_txtPatientType.TabIndex = 117;
            this.m_txtPatientType.TabStop = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 116;
            this.label17.Text = "病人类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 89;
            this.label7.Text = "样本标志";
            // 
            // m_txtFlagSepcial
            // 
            this.m_txtFlagSepcial.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtFlagSepcial.ForeColor = System.Drawing.Color.Red;
            this.m_txtFlagSepcial.Location = new System.Drawing.Point(140, 84);
            this.m_txtFlagSepcial.Name = "m_txtFlagSepcial";
            this.m_txtFlagSepcial.ReadOnly = true;
            this.m_txtFlagSepcial.Size = new System.Drawing.Size(128, 23);
            this.m_txtFlagSepcial.TabIndex = 88;
            this.m_txtFlagSepcial.TabStop = false;
            // 
            // m_txtFlagEmergency
            // 
            this.m_txtFlagEmergency.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtFlagEmergency.ForeColor = System.Drawing.Color.Red;
            this.m_txtFlagEmergency.Location = new System.Drawing.Point(84, 84);
            this.m_txtFlagEmergency.Name = "m_txtFlagEmergency";
            this.m_txtFlagEmergency.ReadOnly = true;
            this.m_txtFlagEmergency.Size = new System.Drawing.Size(56, 23);
            this.m_txtFlagEmergency.TabIndex = 87;
            this.m_txtFlagEmergency.TabStop = false;
            // 
            // m_txtCheckContent
            // 
            this.m_txtCheckContent.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtCheckContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtCheckContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCheckContent.Location = new System.Drawing.Point(316, 84);
            this.m_txtCheckContent.Name = "m_txtCheckContent";
            this.m_txtCheckContent.ReadOnly = true;
            this.m_txtCheckContent.Size = new System.Drawing.Size(288, 23);
            this.m_txtCheckContent.TabIndex = 86;
            this.m_txtCheckContent.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(280, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 85;
            this.label4.Text = "内容";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtAppDept
            // 
            this.m_txtAppDept.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtAppDept.EnableAutoValidation = true;
            this.m_txtAppDept.EnableEnterKeyValidate = true;
            this.m_txtAppDept.EnableEscapeKeyUndo = true;
            this.m_txtAppDept.EnableLastValidValue = true;
            this.m_txtAppDept.ErrorProvider = null;
            this.m_txtAppDept.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDept.ForceFormatText = true;
            this.m_txtAppDept.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDept.Location = new System.Drawing.Point(496, 12);
            this.m_txtAppDept.m_StrDeptID = null;
            this.m_txtAppDept.m_StrDeptName = null;
            this.m_txtAppDept.MaxLength = 20;
            this.m_txtAppDept.Name = "m_txtAppDept";
            this.m_txtAppDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDept.Size = new System.Drawing.Size(108, 23);
            this.m_txtAppDept.TabIndex = 83;
            this.m_txtAppDept.TabStop = false;
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDoct.Location = new System.Drawing.Point(496, 60);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.ReadOnly = true;
            this.m_txtAppDoct.Size = new System.Drawing.Size(108, 23);
            this.m_txtAppDoct.TabIndex = 84;
            this.m_txtAppDoct.TabStop = false;
            // 
            // m_tabControlCollection
            // 
            this.m_tabControlCollection.Controls.Add(this.m_tabPageApplication);
            this.m_tabControlCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControlCollection.ItemSize = new System.Drawing.Size(68, 0);
            this.m_tabControlCollection.Location = new System.Drawing.Point(0, 0);
            this.m_tabControlCollection.Name = "m_tabControlCollection";
            this.m_tabControlCollection.SelectedIndex = 0;
            this.m_tabControlCollection.Size = new System.Drawing.Size(1261, 563);
            this.m_tabControlCollection.TabIndex = 103;
            // 
            // m_tabPageApplication
            // 
            this.m_tabPageApplication.Controls.Add(this.panel1);
            this.m_tabPageApplication.Location = new System.Drawing.Point(4, 24);
            this.m_tabPageApplication.Name = "m_tabPageApplication";
            this.m_tabPageApplication.Size = new System.Drawing.Size(1253, 535);
            this.m_tabPageApplication.TabIndex = 0;
            this.m_tabPageApplication.Text = "样本采集";
            // 
            // chPrint
            // 
            this.chPrint.Text = "打印";
            this.chPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPrint.Width = 48;
            // 
            // frmSampleCollection
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1261, 563);
            this.Controls.Add(this.m_tabControlCollection);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSampleCollection";
            this.Text = "样本采集";
            this.Load += new System.EventHandler(this.frmSampleCollection_Load);
            this.Validated += new System.EventHandler(this.frmSampleCollection_Validated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSampleCollection_KeyDown);
            this.m_grpQuery.ResumeLayout(false);
            this.m_grpQuery.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_grpWork.ResumeLayout(false);
            this.m_palSamplingInfo.ResumeLayout(false);
            this.m_palSamplingInfo.PerformLayout();
            this.m_gpbPatientInfo.ResumeLayout(false);
            this.m_palPatientInfo.ResumeLayout(false);
            this.m_palPatientInfo.PerformLayout();
            this.m_tabControlCollection.ResumeLayout(false);
            this.m_tabPageApplication.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 一般设置

        #region 快捷键设置
        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.F2)
            {

            }
            else if (p_eumKeyCode == Keys.F4 && this.m_btnConfirm.Enabled && m_btnConfirm.Visible)//
            {
                this.m_btnConfirm_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F5 && this.m_btnQuery.Enabled && m_btnQuery.Visible)		//
            {
                this.m_btnQuery_Click(null, null);
            }
        }
        #endregion

        #region Enter 键选择下一个
        private void frmSampleCollection_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            m_mthSetKeyTab(e);
        }
        #endregion

        #endregion

        #region 初始化

        private void frmSampleCollection_Load(object sender, System.EventArgs e)
        {
            m_mthSetFormControlCanBeNull(this);
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { });

            //get parm value
            BillStyle = clsPublic.m_intGetSysParm("4009");
            intSkipStyle = clsPublic.m_intGetSysParm("4002");

            #region Wechat
            string tmpStr = clsPublic.m_strGetSysparm("1010");
            if (!string.IsNullOrEmpty(tmpStr) && tmpStr.Trim() != "")
            {
                this.WechatWebUrl = tmpStr.Trim();
            }
            #endregion
        }

        #endregion

        #region 公用方法

        /// <summary>
        /// 获取样本VO
        /// </summary>
        private clsT_OPR_LIS_SAMPLE_VO GetSampleVO(clsLisApplMainVO objAppVO)
        {
            clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();
            objSampleVO.m_strAPPL_DAT = objAppVO.m_strAppl_Dat;

            objSampleVO.m_strSEX_CHR = objAppVO.m_strSex;
            objSampleVO.m_strPATIENT_NAME_VCHR = objAppVO.m_strPatient_Name;
            objSampleVO.m_strPATIENT_SUBNO_CHR = objAppVO.m_strPatient_SubNO;
            objSampleVO.m_strAGE_CHR = objAppVO.m_strAge;
            objSampleVO.m_strPATIENT_TYPE_CHR = objAppVO.m_strPatientType;
            objSampleVO.m_strDIAGNOSE_VCHR = objAppVO.m_strDiagnose;
            objSampleVO.m_strBEDNO_CHR = objAppVO.m_strBedNO;
            objSampleVO.m_strICD_VCHR = objAppVO.m_strICD;
            objSampleVO.m_strPATIENTCARDID_CHR = objAppVO.m_strPatientcardID;
            objSampleVO.m_strPATIENTID_CHR = objAppVO.m_strPatientID;
            objSampleVO.m_strAPPL_EMPID_CHR = objAppVO.m_strAppl_EmpID;
            objSampleVO.m_strAPPL_DEPTID_CHR = objAppVO.m_strAppl_DeptID;
            objSampleVO.m_strAPPLICATION_ID_CHR = objAppVO.m_strAPPLICATION_ID;
            objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = objAppVO.m_strPatient_inhospitalno_chr;
            objSampleVO.m_strSAMPLE_TYPE_ID_CHR = objAppVO.m_strSampleID;
            objSampleVO.m_strSAMPLETYPE_VCHR = objAppVO.m_strSampleType;

            //已采集标志				
            objSampleVO.m_intSTATUS_INT = 2;
            objSampleVO.m_strQCSAMPLEID_CHR = "-1";
            objSampleVO.m_strSAMPLEKIND_CHR = "1";

            objSampleVO.m_strSAMPLE_ID_CHR = null;

            objSampleVO.m_strSAMPLESTATE_VCHR = null;

            objSampleVO.m_strBARCODE_VCHR = this.m_txtBarCode.Text.Trim();

            objSampleVO.m_strOPERATOR_ID_CHR = this.LoginInfo.m_strEmpID;

            objSampleVO.m_strSAMPLING_DATE_DAT = this.m_dtpSamplingDate.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim();
            if (string.IsNullOrEmpty(m_strSubmitDoctorId))
            {
                objSampleVO.m_strCOLLECTOR_ID_CHR = this.LoginInfo.m_strEmpID;
            }
            else
            {
                objSampleVO.m_strCOLLECTOR_ID_CHR = this.m_strSubmitDoctorId;
            }

            return objSampleVO;
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void m_mthQuery()
        {
            clsLisApplMainVO[] objAppVOArr = null;
            string strFromDate = this.m_dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
            string strToDate = this.m_dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");
            string strAppDeptID = this.m_txtAppDeptQuery.m_StrDeptID;
            int intStatus = 0;
            if (this.m_rdbSampled.Checked)
            {
                intStatus = 2;
            }
            else if (this.m_rdbNotSampled.Checked)
            {
                intStatus = 1;
            }
            else
            {
                intStatus = 0;
            }
            string m_strAccept = null;
            if (m_rabAccept.Checked)
            {
                m_strAccept = "1";
            }
            else if (m_rabNotAccept.Checked)
            {
                m_strAccept = "0";
            }
            else if (m_rabAllAccept.Checked)
            {
                m_strAccept = "2";
            }
            int intIsSampleBack = 2;
            if (m_rabQualified.Checked)
            {
                intIsSampleBack = 0;
            }
            if (m_rabUnQualified.Checked)
            {
                intIsSampleBack = 1;
            }

            string strPatientName = "%" + this.txtPatientName.Text.Trim() + "%";
            string strPatientCardID = this.txtPatientCardID.Text.Trim();

            long lngRes = this.m_objController.m_lngQuery(strFromDate, strToDate, strAppDeptID, intStatus, strPatientName, strPatientCardID, m_strAccept, intIsSampleBack, out objAppVOArr);

            if (lngRes > 0)
            {
                if (objAppVOArr != null && objAppVOArr.Length > 0)
                {
                    m_lsvApplication.Items.Clear();
                    m_mthResetAll();
                    for (int i = 0; i < objAppVOArr.Length; i++)
                    {
                        ListViewItem objlsvItem = new ListViewItem();
                        //只取门诊类型
                        if (objAppVOArr[i].m_strPatientType != "2")
                        {
                            continue;
                        }

                        objlsvItem.Text = objAppVOArr[i].m_strAPPLICATION_ID.Substring(10, 8);
                        objlsvItem.SubItems.Add(objAppVOArr[i].m_strPatient_Name);
                        string strAppDate = "";
                        try
                        {
                            DateTime dtmAppDate = DateTime.Parse(objAppVOArr[i].m_strAppl_Dat);
                            strAppDate = dtmAppDate.ToString("yyyy-MM-dd");
                        }
                        catch { }

                        objlsvItem.SubItems.Add(strAppDate);
                        // 是否已打印条码
                        objlsvItem.SubItems.Add(objAppVOArr[i].m_isPrinted ? "√" : "");

                        bool isSampleStatus = objAppVOArr[i].m_intSampleStatus == 2 || objAppVOArr[i].m_intSampleStatus == 3 ||
                                            objAppVOArr[i].m_intSampleStatus == 5 || objAppVOArr[i].m_intSampleStatus == 6;
                        if (isSampleStatus)
                        {
                            objlsvItem.SubItems.Add("√");
                        }
                        else
                        {
                            objlsvItem.SubItems.Add("");
                        }
                        if (objAppVOArr[i].m_intEmergency == 1)
                        {
                            objlsvItem.ForeColor = Color.Red;
                        }
                        //绿色通道，是先诊疗后结算
                        if (objAppVOArr[i].m_intIsGreen == 1)
                        {
                            objlsvItem.BackColor = Color.Orange;
                        }

                        objlsvItem.SubItems.Add(objAppVOArr[i].m_strSample_Back_Reason);
                        objlsvItem.Tag = objAppVOArr[i];
                        m_lsvApplication.Items.Add(objlsvItem);
                    }

                    if (m_lsvApplication.Items.Count > 0)
                    {
                        m_lsvApplication.Items[0].Focused = true;
                        m_lsvApplication.Items[0].Selected = true;
                    }

                    this.m_palSamplingInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show(this, "没有符合条件的结果!", MESSAGETITLE);
                }
            }
            else
            {
                MessageBox.Show(this, "操作失败!", MESSAGETITLE);
            }

            #region 此方法暂不添加 －－住院的申请单
            /*
            clsLisApplMainVO[] objBihVO = null;
            lngRes = this.m_objController.m_lngQuery(strFromDate, strToDate, "", intStatus, strPatientName, strPatientCardID, "", "", out objBihVO);
            if (lngRes > 0)
            {
                for (int i = 0; i < objBihVO.Length; i++)
                {
                    ListViewItem objlsvItem = new ListViewItem();
                    //只取门诊类型
                    //if (objBihVO[i].m_strPatientType != "2")
                    //{
                    //    continue;
                    //}

                    objlsvItem.Text = objBihVO[i].m_strAPPLICATION_ID.Substring(10, 8);
                    objlsvItem.SubItems.Add(objBihVO[i].m_strPatient_Name);
                    string strAppDate = "";
                    try
                    {
                        DateTime dtmAppDate = DateTime.Parse(objBihVO[i].m_strAppl_Dat);
                        strAppDate = dtmAppDate.ToString("yyyy-MM-dd");
                    }
                    catch { }

                    objlsvItem.SubItems.Add(strAppDate);

                    bool isSampleStatus = objBihVO[i].m_intSampleStatus == 2 || objBihVO[i].m_intSampleStatus == 3 ||
                                        objBihVO[i].m_intSampleStatus == 5 || objBihVO[i].m_intSampleStatus == 6;
                    if (isSampleStatus)
                    {
                        objlsvItem.SubItems.Add("√");
                    }
                    else
                    {
                        objlsvItem.SubItems.Add("");
                    }
                    if (objBihVO[i].m_intEmergency == 1)
                    {
                        objlsvItem.ForeColor = Color.Red;
                    }
                    objlsvItem.Tag = objBihVO[i];
                    m_lsvApplication.Items.Add(objlsvItem);
                }

                if (m_lsvApplication.Items.Count > 0)
                {
                    m_lsvApplication.Items[0].Focused = true;
                    m_lsvApplication.Items[0].Selected = true;
                }

                this.m_palSamplingInfo.Enabled = true;
            }
            */
            #endregion
        }

        //样本采集
        private void m_mthConfirm()
        {
            if (m_lsvApplication.SelectedItems.Count == 0)
            {
                MessageBox.Show("请输入申请单号!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;

            if (m_txtBarCode.Text.ToString().Trim() == "")
            {
                MessageBox.Show(this, "条形码 不能为空！", MESSAGETITLE);
                this.m_btnConfirm.Enabled = true;
                this.m_txtBarCode.Focus();
                this.m_txtBarCode.SelectAll();
            }
            else
            {
                if (this.m_objController.m_blnBarCodeExsit(m_txtBarCode.Text.ToString().Trim()))
                {
                    MessageBox.Show(this, "此条形码 已存在", MESSAGETITLE);
                    this.m_btnConfirm.Enabled = true;
                    this.m_txtBarCode.Focus();
                    this.m_txtBarCode.SelectAll();
                }
                else
                {
                    clsT_OPR_LIS_SAMPLE_VO objSampleVO = GetSampleVO(objAppVO);

                    long lngRes = this.m_objController.m_lngSave(objAppVO.m_strAPPLICATION_ID, ref objSampleVO);
                    this.m_btnConfirm.Enabled = true;
                    if (lngRes <= 0)
                    {
                        MessageBox.Show(this, "操作失败!", MESSAGETITLE);
                        this.m_btnConfirm.Focus();
                    }
                    else
                    {
                        this.m_lsvApplication.SelectedItems[0].SubItems[3].Text = "√";
                        objAppVO.m_strSampleID = objSampleVO.m_strSAMPLE_ID_CHR;
                        objAppVO.m_intSampleStatus = 2;
                        //						this.m_palSamplingInfo.Enabled = false;
                        //xing.chen add for modify sample barcode
                        this.m_txtSampleType.Enabled = false;
                        this.m_txtBarCode.Enabled = false;
                        this.m_txtOperatorID.Enabled = false;
                        this.m_dtpSamplingDate.Enabled = false;
                        this.m_txtSamplingRule.Enabled = false;
                        this.m_btnConfirm.Enabled = false;
                        int intCurrApp = this.m_lsvApplication.SelectedIndices[0];
                        if (intCurrApp < this.m_lsvApplication.Items.Count - 1)
                        {
                            this.m_lsvApplication.Focus();
                            if (intCurrApp < this.m_lsvApplication.Items.Count - 1)
                            {
                                this.m_lsvApplication.Items[intCurrApp + 1].Selected = true;
                                this.m_lsvApplication.Items[intCurrApp + 1].Focused = true;
                                this.m_lsvApplication.Items[intCurrApp + 1].EnsureVisible();
                                this.m_mthSelectApp();
                            }
                        }
                        else
                        {
                            this.m_lsvApplication.Items[intCurrApp].Focused = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取收费状态
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        private bool IsPay(string applicationId)
        {
            clsChargeStatusVO chargeStatusVO = null;
            clsChargeInfoStatusSmp.s_obj.m_lngFind(applicationId, out chargeStatusVO);
            if (chargeStatusVO == null)
            {
                return false;
            }

            if (chargeStatusVO.m_intChargeStatus == 1)
            {
                return true;
            }

            return false;
        }

        private void m_mthSelectApp()
        {
            m_mthResetAll();
            if (this.m_lsvApplication.Items.Count <= 0)
            {
                return;
            }
            clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;


            #region 取得收费信息

            switch (objAppVO.m_intChargeState)
            {
                case 1:
                    this.m_lblChargeState.Text = "已收费" + objAppVO.ChargeDesc;
                    this.m_lblChargeState.ForeColor = System.Drawing.Color.Black;
                    break;
                default:
                    this.m_lblChargeState.Text = "未收费";
                    this.m_lblChargeState.ForeColor = System.Drawing.Color.Red;
                    break;
            }

            if (objAppVO.m_intIsGreen == 1)
            {
                this.m_lblChargeState.Text = "先诊疗后结算" + objAppVO.ChargeDesc;
                this.m_lblChargeState.ForeColor = System.Drawing.Color.Orange;
            }

            #endregion

            #region 病人信息赋值

            if (objAppVO.m_strPatientType == "2")
            {
                this.m_txtPatientInhosNO.Text = objAppVO.m_strPatientcardID;
            }
            else
            {
                this.m_txtPatientInhosNO.Text = objAppVO.m_strPatient_inhospitalno_chr;
            }
            this.m_txtApplicationID.Text = objAppVO.m_strAPPLICATION_ID.Substring(10, 8);
            this.m_txtCheckContent.Text = objAppVO.m_strCheckContent;

            this.m_txtPatientName.Text = objAppVO.m_strPatient_Name;
            this.m_txtSex.Text = objAppVO.m_strSex;
            this.m_txtAge.Text = objAppVO.m_strAge;

            this.m_txtAppDept.m_StrDeptID = objAppVO.m_strAppl_DeptID;
            this.m_txtBedNo.Text = objAppVO.m_strBedNO;
            this.m_txtAppDoct.m_StrEmployeeID = objAppVO.m_strAppl_EmpID;

            if (objAppVO.m_intSpecial == 1)
            {
                this.m_txtFlagSepcial.Text = "特殊处理";
            }
            else
            {
                this.m_txtFlagSepcial.Text = "";
            }
            if (objAppVO.m_intEmergency == 1)
            {
                this.m_txtFlagEmergency.Text = "急诊";
            }
            else
            {
                this.m_txtFlagEmergency.Text = "";
            }
            switch (objAppVO.m_strPatientType)
            {
                case "1":
                    this.m_txtPatientType.Text = "住院";
                    break;
                case "2":
                    this.m_txtPatientType.Text = "门诊";
                    break;
                case "3":
                    this.m_txtPatientType.Text = "体检";
                    break;
                default:
                    this.m_txtPatientType.Text = "";
                    break;

            }

            //bool isBihOrder = false; //是否是诊疗项目模式
            //clsLisMainSmp.s_obj.GetSystemSetting("9000", out isBihOrder);

            // 【读取系统设置-9000:门诊系统采用何种收费模式 0:收费明细模式 1:诊疗项目模式】
            //if (!isBihOrder)
            //{
            this.m_txtChargeItemName.Text = objAppVO.m_strChargeInfo;
            //}

            #endregion

            this.m_txtSampleType.Text = objAppVO.m_strSampleType;

            clsSampleGroup_VO[] objSampleGroupVOArr = null;

            long lngResExt = 0;
            lngResExt = this.m_objController.m_lngGetSampleRemark(objAppVO.m_strAPPLICATION_ID, out objSampleGroupVOArr);
            if (lngResExt > 0 && objSampleGroupVOArr != null)
            {
                string strSampleRule = "";
                for (int i = 0; i < objSampleGroupVOArr.Length; i++)
                {
                    strSampleRule += objSampleGroupVOArr[i].strSampleGroupName + ": " + objSampleGroupVOArr[i].strRemark + "\r\n";
                }
                this.m_txtSamplingRule.Text = strSampleRule;
            }

            #region UI 控制
            if (objAppVO.m_intSampleStatus == 2
                || objAppVO.m_intSampleStatus == 3
                || objAppVO.m_intSampleStatus == 5
                || objAppVO.m_intSampleStatus == 6)
            {
                clsT_OPR_LIS_SAMPLE_VO objSample = null;
                long lngRes = this.m_objController.m_lngGetSampleBySampleID(objAppVO.m_strSampleID, out objSample);
                if (lngRes > 0 && objSample != null)
                {
                    this.m_txtOperatorID.m_StrEmployeeID = (objSample.m_strCOLLECTOR_ID_CHR == "" ? null : objSample.m_strCOLLECTOR_ID_CHR);
                    this.m_txtBarCode.Text = objSample.m_strBARCODE_VCHR;
                    try
                    {
                        this.m_dtpSamplingDate.Value = DateTime.Parse(objSample.m_strSAMPLING_DATE_DAT);
                    }
                    catch
                    {
                        this.m_dtpSamplingDate.Value = DateTime.Parse("1900-01-01 00:00:00");
                    }
                }
                else if (lngRes > 0)
                {
                    MessageBox.Show(this, "样本不存在!", MESSAGETITLE);
                }
                else
                {
                    this.m_dtpSamplingDate.Value = DateTime.Parse("1900-01-01 00:00:00");
                    MessageBox.Show(this, "操作失败!", MESSAGETITLE);
                }
                //				this.m_palSamplingInfo.Enabled = false;
                //xing.chen add for modify sample barcode
                this.m_txtSampleType.Enabled = false;
                this.m_txtBarCode.Enabled = false;
                this.m_txtOperatorID.Enabled = false;
                this.m_dtpSamplingDate.Enabled = false;
                this.m_txtSamplingRule.Enabled = false;
                this.m_btnConfirm.Enabled = false;
                this.m_lsvApplication.SelectedItems[0].Focused = true;
            }
            else
            {
                this.m_txtOperatorID.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
                this.m_palSamplingInfo.Enabled = true;
                //xing.chen add for modify sample barcode
                this.m_txtSampleType.Enabled = true;
                this.m_txtBarCode.Enabled = true;
                this.m_txtOperatorID.Enabled = true;
                this.m_dtpSamplingDate.Enabled = true;
                this.m_txtSamplingRule.Enabled = true;
                this.m_btnConfirm.Enabled = true;
                this.m_txtBarCode.Focus();
            }
            #endregion
        }

        private void m_mthResetAll()
        {
            com.digitalwave.Utility.clsControlCleanUpUtil objCleanUp = new com.digitalwave.Utility.clsControlCleanUpUtil();
            objCleanUp.m_mthCleanUp(this.m_palPatientInfo, new clsControlCleanUpUtil_TypePara(null, new Type[] { typeof(Label) }));
            this.m_txtSampleType.Clear();
            this.m_txtSamplingRule.Clear();
            this.m_txtBarCode.Clear();
            this.m_txtOperatorID.m_mthClear();
            this.m_dtpSamplingDate.Value = DateTime.Now;
            this.m_lblChargeState.Text = "";
            this.m_txtPatientType.Clear();
        }

        #endregion

        #region 事件实现

        private void frmSampleCollection_Validated(object sender, System.EventArgs e)
        {
            //窗口获得焦点自动刷新检验申请单信息
            //			this.m_mthRefreshApplicationList();
        }

        private void m_lsvApplication_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.m_lsvApplication.FocusedItem != null)
            {
                this.m_lsvApplication.FocusedItem.Selected = true;
            }
        }

        private void m_lsvApplication_Click(object sender, System.EventArgs e)
        {
            if (m_lsvApplication.SelectedItems.Count <= 0)
                return;
            m_mthSelectApp();
        }

        private void m_lsvApplication_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (m_lsvApplication.SelectedItems.Count <= 0)
                return;
            m_mthSelectApp();
        }

        private void btnChangeEmergency_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvApplication.SelectedItems.Count <= 0)
            {
                return;
            }
            if ((clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag != null)
            {
                clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;

                if (objAppVO.m_intEmergency == 1)
                {
                    objAppVO.m_intEmergency = 0;
                }
                else if (objAppVO.m_intEmergency == 0)
                {
                    objAppVO.m_intEmergency = 1;
                }

                long lngRes = m_objController.m_lngChangeEmergency(objAppVO);
                if (lngRes > 0)
                {
                    this.m_lsvApplication.SelectedItems[0].Tag = objAppVO;


                    if (objAppVO.m_intEmergency == 1)
                    {
                        this.m_lsvApplication.SelectedItems[0].ForeColor = Color.Red;
                        this.m_txtFlagEmergency.Text = "急诊";
                    }
                    else if (objAppVO.m_intIsGreen == 1)
                    {
                        this.m_lsvApplication.SelectedItems[0].BackColor = Color.Orange;
                        this.m_txtFlagEmergency.Text = "";
                    }
                    else
                    {
                        this.m_lsvApplication.SelectedItems[0].ForeColor = Color.Black;
                        this.m_txtFlagEmergency.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("更新急诊标志失败。");
                }
            }
        }

        //xing.chen add for 佛山需求
        private void m_txtBarCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{ENTER}");
            }
        }

        private void btnModifyBarCode_Click(object sender, System.EventArgs e)
        {
            if (m_lsvApplication.SelectedItems.Count <= 0)
            {
                return;
            }
            if (MessageBox.Show("此样本的条码将被修改！", "iCare-LIS", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            if (this.m_lsvApplication.SelectedItems != null)
            {
                if ((clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag != null)
                {
                    clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;
                    long lngRes = 0;
                    int intStatus;
                    lngRes = this.m_objController.m_lngFindStatusBySampleID(objAppVO.m_strSampleID, out intStatus);
                    if (lngRes < 0)
                    {
                        MessageBox.Show(this, "操作失败！", "检验采集信息提示");
                    }
                    if (intStatus != 8)
                    {
                        if (intStatus >= 3 && intStatus <= 6)
                        {
                            MessageBox.Show(this, "该样本已核收，不允许修改！", "检验采集信息提示");
                        }
                        else
                        {
                            lngRes = 0;
                            lngRes = this.m_objController.m_lngModifyBarCode(objAppVO.m_strSampleID, objAppVO.m_strAPPLICATION_ID);
                            if (lngRes < 0)
                            {
                                MessageBox.Show(this, "删除原有信息失败！", "检验采集信息提示");
                            }

                            objAppVO.m_intSampleStatus = 1;
                            objAppVO.m_strSampleID = "";
                            this.m_lsvApplication.SelectedItems[0].SubItems[3].Text = "";
                            this.m_lsvApplication_Click(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "读取样本状态信息失败", "检验采集信息提示");
                    }
                }
            }
        }

        private void btnPrintView_Click(object sender, System.EventArgs e)
        {
            clsSealedLisApplyReportPrint m_objPrint = new clsSealedLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;
                m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID, this.m_txtBarCode.Text);
                if (BillStyle == 0)
                {
                    m_objPrint.m_mthPrintPreview();
                }
                else if (BillStyle == 1)
                {
                    m_objPrint.m_mthReport(1);
                }
            }
            else
            {
                MessageBox.Show(this, "请选择要预览的申请", "检验采集信息提示");
            }
        }

        private void m_btnQuery_Click(object sender, System.EventArgs e)
        {
            m_lsvApplication.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnQuery.Enabled = false;

            this.m_mthQuery();
            this.m_mthSelectApp();

            this.m_btnQuery.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnConfirm_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnConfirm.Enabled = false;

            this.m_mthConfirm();
            Cursor.Current = Cursors.Default;
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsSealedLisApplyReportPrint m_objPrint = new clsSealedLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                for (int i = 0; i < m_lsvApplication.SelectedItems.Count; i++)
                {
                    clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[i].Tag;
                    m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID);
                    //if (BillStyle == 0)
                    //{
                    //    m_objPrint.m_mthPrintPreview();
                    //}
                    //else if (BillStyle == 1)
                    //{
                    //    m_objPrint.m_mthReport(0);
                    //}
                    m_objPrint.PrintNew();

                    string strEmpID = null;
                    if (!string.IsNullOrEmpty(m_strSubmitDoctorId))
                    {
                        strEmpID = m_strSubmitDoctorId;
                    }
                    else
                    {
                        strEmpID = this.LoginInfo.m_strEmpID;
                    }
                    m_objController.m_mthUpdateCollector(strEmpID, objAppVO.m_strSampleID, objAppVO.m_strAPPLICATION_ID);

                    // 微信推送消息
                    WechatPost(objAppVO.m_strAPPLICATION_ID);

                }
            }
            else
            {
                MessageBox.Show(this, "请选择要打印的申请单", "检验采集信息提示");
            }
        }

        #region WechatPost
        /// <summary>
        /// WechatPost
        /// </summary>
        void WechatPost(string applicationId)
        {
            try
            {
                if (string.IsNullOrEmpty(this.WechatWebUrl) || string.IsNullOrEmpty(applicationId)) return;
                clsDomainController_ApplicationManage doMain = new clsDomainController_ApplicationManage();
                DataTable dt = doMain.GetWechatSampleInfo(applicationId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (doMain.IsWechatBanding(dr["patientcardid_chr"].ToString()))
                    {

                        string xmlData = string.Empty;
                        xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                        xmlData += "<req>" + Environment.NewLine;
                        xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004414") + Environment.NewLine;
                        xmlData += string.Format("<eventType>{0}</eventType>", "customMessage") + Environment.NewLine;
                        xmlData += "<eventData>" + Environment.NewLine;
                        xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", dr["patientcardid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<patientId>{0}</patientId>", dr["patientid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<title>{0}</title>", "检验科温馨提示") + Environment.NewLine;
                        xmlData += string.Format("<message>检验报告将于{0}后出具</message>", "X小时") + Environment.NewLine;
                        xmlData += "</eventData>" + Environment.NewLine;
                        xmlData += "</req>" + Environment.NewLine;

                        byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                        //创建请求
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.WechatWebUrl);
                        request.Method = "POST";
                        request.ContentLength = dataArray.Length;
                        //创建输入流
                        Stream dataStream = null;
                        try
                        {
                            dataStream = request.GetRequestStream();
                        }
                        catch
                        {
                            return;
                        }
                        //发送请求
                        dataStream.Write(dataArray, 0, dataArray.Length);
                        dataStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void txtPatientCardID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPatientCardID.Text = this.txtPatientCardID.Text.Trim().PadLeft(10, '0');
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnLogin_Click(object sender, EventArgs e)
        {
            SubmitLogin();
        }
        private void SubmitLogin()
        {
            string empid = "";

            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empid);
            if (dlg == DialogResult.Yes)
            {
                this.m_strSubmitDoctorId = empid;
                ctlEmpTextBox emp = new ctlEmpTextBox();
                emp.m_StrEmployeeID = m_strSubmitDoctorId;
                this.m_lblSubmitDoctor.Text = emp.m_StrEmployeeName;
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.m_strSubmitDoctorId = string.Empty;
            this.m_lblSubmitDoctor.Text = "(空)";
            SubmitLogin();
        }
    }
}
