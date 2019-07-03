using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.Utility;
namespace com.digitalwave.iCare.gui.LIS
{
    public class frmSampleReceive : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 是否自动接收样本
        /// </summary>
        bool blnAutoReceive = false;
        /// <summary>
        /// 申请单样式 0 普通式 1 条码样式
        /// </summary>
        private int BillStyle = 0;
        /// <summary>
        /// 核收医生ID
        /// </summary>
        internal string m_strSubmitDoctorId = string.Empty;

        internal int intSendPepoleID = 0;

        #region Controls
        private System.Windows.Forms.Label m_lbBarCode;
        internal System.Windows.Forms.TextBox m_txtBarCode;
        private System.Windows.Forms.Label m_lbSampleType;
        private System.Windows.Forms.Label m_lbCheckContent;
        internal System.Windows.Forms.TextBox m_txtCheckContent;
        private System.Windows.Forms.Label m_lbPatientType;
        private System.Windows.Forms.Label m_lbReceiveEmp;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtReceiveEmp;
        private System.Windows.Forms.Label m_lbReceiveDat;
        internal System.Windows.Forms.DateTimePicker m_dtpReceiveDat;
        private System.Windows.Forms.GroupBox m_gpbBaseInfo;
        private System.Windows.Forms.Label m_lbQryReceiveEmp;
        private System.Windows.Forms.Label m_lbDatRange;
        internal System.Windows.Forms.DateTimePicker m_dtpDatFrom;
        private System.Windows.Forms.Label m_lbDatTo;
        internal System.Windows.Forms.DateTimePicker m_dtpDatTo;
        private System.Windows.Forms.GroupBox m_gpbQurey;
        internal PinkieControls.ButtonXP m_btnReceiveSample;
        internal PinkieControls.ButtonXP m_btnQuery;
        internal System.Windows.Forms.ListView m_lsvReceiveSampleList;
        private System.Windows.Forms.Label m_lbQrySampleType;
        internal System.Windows.Forms.ComboBox m_cboQrySampleType;
        private System.Windows.Forms.ColumnHeader m_chBarCode;
        private System.Windows.Forms.ColumnHeader m_chSampleType;
        private System.Windows.Forms.ColumnHeader m_chCheckContent;
        private System.Windows.Forms.ColumnHeader m_chPatientType;
        private System.Windows.Forms.ColumnHeader m_chReceiveDat;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ColumnHeader m_chIsEmergency;
        private System.Windows.Forms.ColumnHeader m_chIsSpecial;
        private System.Windows.Forms.Label m_lbReceiveSample;
        private System.Windows.Forms.ColumnHeader m_chReceiveEmp;
        internal PinkieControls.ButtonXP m_btnClear;
        internal System.Windows.Forms.TextBox m_txtFlagEmergency;
        internal System.Windows.Forms.TextBox m_txtFlagSepcial;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtSampleType;
        internal System.Windows.Forms.TextBox m_txtPatientType;
        private System.Windows.Forms.ColumnHeader m_chPatientName;
        internal System.Windows.Forms.TextBox m_txtPatientName;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox m_txtChargeState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox m_txtPatientNameForSearch;
        internal System.Windows.Forms.TextBox m_txtBarCodeForSearch;
        private PinkieControls.ButtonXP btnPrintView;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtQryReceiveEmp;
        internal ComboBox cboCheckCategory;
        private PinkieControls.ButtonXP btnExit;
        private PinkieControls.ButtonXP btnPrint;
        internal TabControl m_tabSampleList;
        internal TabPage tabUnReceive;
        internal ListView m_lstUnReceive;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        internal TabPage tabReceive;
        private Label label8;
        private Label label9;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtSendPeople;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtSendPeopleForSearch;
        internal PinkieControls.ButtonXP m_btnExit;
        internal PinkieControls.ButtonXP m_btnLogin;
        private Label label10;
        private Label m_lblSubmitDoctor;
        private ColumnHeader m_chSendSampleEmp;
        internal ComboBox m_cboSampleBackReason;
        private Label label11;
        internal PinkieControls.ButtonXP m_btnSampleBack;
        internal TextBox m_txtInPatientNum;
        private Label label12;
        internal com.digitalwave.controls.clsCardTextBox m_txtPatientCardID;
        internal PinkieControls.ButtonXP btnTj;
        internal PinkieControls.ButtonXP btnIp;
        internal PinkieControls.ButtonXP btnRPrintBarCode;
        clsController_SampleReceive m_objController;
        #endregion

        #region constructMethod
        public frmSampleReceive()
        {
            // 该调用是 Windows 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化
        }

        /// <summary>
        /// 清理所有正在使用的资源。
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

        #region 设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_lblSubmitDoctor = new System.Windows.Forms.Label();
            this.m_btnLogin = new PinkieControls.ButtonXP();
            this.label10 = new System.Windows.Forms.Label();
            this.m_tabSampleList = new System.Windows.Forms.TabControl();
            this.tabUnReceive = new System.Windows.Forms.TabPage();
            this.m_lstUnReceive = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.tabReceive = new System.Windows.Forms.TabPage();
            this.m_lsvReceiveSampleList = new System.Windows.Forms.ListView();
            this.m_chBarCode = new System.Windows.Forms.ColumnHeader();
            this.m_chPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_chSampleType = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckContent = new System.Windows.Forms.ColumnHeader();
            this.m_chPatientType = new System.Windows.Forms.ColumnHeader();
            this.m_chReceiveDat = new System.Windows.Forms.ColumnHeader();
            this.m_chIsEmergency = new System.Windows.Forms.ColumnHeader();
            this.m_chIsSpecial = new System.Windows.Forms.ColumnHeader();
            this.m_chReceiveEmp = new System.Windows.Forms.ColumnHeader();
            this.m_chSendSampleEmp = new System.Windows.Forms.ColumnHeader();
            this.m_lbReceiveSample = new System.Windows.Forms.Label();
            this.m_gpbQurey = new System.Windows.Forms.GroupBox();
            this.btnRPrintBarCode = new PinkieControls.ButtonXP();
            this.btnIp = new PinkieControls.ButtonXP();
            this.btnTj = new PinkieControls.ButtonXP();
            this.m_txtPatientCardID = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtInPatientNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtSendPeopleForSearch = new com.digitalwave.Utility.ctlEmpTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExit = new PinkieControls.ButtonXP();
            this.cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.m_txtQryReceiveEmp = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_txtBarCodeForSearch = new System.Windows.Forms.TextBox();
            this.m_txtPatientNameForSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboQrySampleType = new System.Windows.Forms.ComboBox();
            this.m_lbQrySampleType = new System.Windows.Forms.Label();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_lbDatTo = new System.Windows.Forms.Label();
            this.m_dtpDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_lbDatRange = new System.Windows.Forms.Label();
            this.m_dtpDatFrom = new System.Windows.Forms.DateTimePicker();
            this.m_lbQryReceiveEmp = new System.Windows.Forms.Label();
            this.m_gpbBaseInfo = new System.Windows.Forms.GroupBox();
            this.m_btnSampleBack = new PinkieControls.ButtonXP();
            this.m_cboSampleBackReason = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtSendPeople = new com.digitalwave.Utility.ctlEmpTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnPrintView = new PinkieControls.ButtonXP();
            this.m_txtSampleType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFlagSepcial = new System.Windows.Forms.TextBox();
            this.m_txtFlagEmergency = new System.Windows.Forms.TextBox();
            this.m_lbSampleType = new System.Windows.Forms.Label();
            this.m_lbPatientType = new System.Windows.Forms.Label();
            this.m_txtReceiveEmp = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_lbReceiveEmp = new System.Windows.Forms.Label();
            this.m_lbCheckContent = new System.Windows.Forms.Label();
            this.m_txtCheckContent = new System.Windows.Forms.TextBox();
            this.m_btnClear = new PinkieControls.ButtonXP();
            this.m_txtBarCode = new System.Windows.Forms.TextBox();
            this.m_btnReceiveSample = new PinkieControls.ButtonXP();
            this.m_txtPatientType = new System.Windows.Forms.TextBox();
            this.m_lbBarCode = new System.Windows.Forms.Label();
            this.m_txtChargeState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtPatientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpReceiveDat = new System.Windows.Forms.DateTimePicker();
            this.m_lbReceiveDat = new System.Windows.Forms.Label();
            this.m_tabSampleList.SuspendLayout();
            this.tabUnReceive.SuspendLayout();
            this.tabReceive.SuspendLayout();
            this.m_gpbQurey.SuspendLayout();
            this.m_gpbBaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(243, 220);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(62, 25);
            this.m_btnExit.TabIndex = 40;
            this.m_btnExit.Text = "退出";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_lblSubmitDoctor
            // 
            this.m_lblSubmitDoctor.AutoSize = true;
            this.m_lblSubmitDoctor.Location = new System.Drawing.Point(91, 224);
            this.m_lblSubmitDoctor.Name = "m_lblSubmitDoctor";
            this.m_lblSubmitDoctor.Size = new System.Drawing.Size(35, 14);
            this.m_lblSubmitDoctor.TabIndex = 26;
            this.m_lblSubmitDoctor.Text = "(空)";
            // 
            // m_btnLogin
            // 
            this.m_btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnLogin.DefaultScheme = true;
            this.m_btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnLogin.Hint = "";
            this.m_btnLogin.Location = new System.Drawing.Point(175, 220);
            this.m_btnLogin.Name = "m_btnLogin";
            this.m_btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnLogin.Size = new System.Drawing.Size(62, 25);
            this.m_btnLogin.TabIndex = 39;
            this.m_btnLogin.Text = "登录";
            this.m_btnLogin.Click += new System.EventHandler(this.m_btnLogin_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(8, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "登录核收人：";
            // 
            // m_tabSampleList
            // 
            this.m_tabSampleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabSampleList.Controls.Add(this.tabUnReceive);
            this.m_tabSampleList.Controls.Add(this.tabReceive);
            this.m_tabSampleList.Location = new System.Drawing.Point(4, 242);
            this.m_tabSampleList.Name = "m_tabSampleList";
            this.m_tabSampleList.SelectedIndex = 0;
            this.m_tabSampleList.Size = new System.Drawing.Size(988, 308);
            this.m_tabSampleList.TabIndex = 24;
            this.m_tabSampleList.SelectedIndexChanged += new System.EventHandler(this.tabSample_SelectedIndexChanged);
            // 
            // tabUnReceive
            // 
            this.tabUnReceive.Controls.Add(this.m_lstUnReceive);
            this.tabUnReceive.Location = new System.Drawing.Point(4, 24);
            this.tabUnReceive.Name = "tabUnReceive";
            this.tabUnReceive.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnReceive.Size = new System.Drawing.Size(980, 280);
            this.tabUnReceive.TabIndex = 0;
            this.tabUnReceive.Text = "未核收标本";
            this.tabUnReceive.UseVisualStyleBackColor = true;
            // 
            // m_lstUnReceive
            // 
            this.m_lstUnReceive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.m_lstUnReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstUnReceive.FullRowSelect = true;
            this.m_lstUnReceive.GridLines = true;
            this.m_lstUnReceive.Location = new System.Drawing.Point(3, 3);
            this.m_lstUnReceive.MultiSelect = false;
            this.m_lstUnReceive.Name = "m_lstUnReceive";
            this.m_lstUnReceive.Size = new System.Drawing.Size(974, 274);
            this.m_lstUnReceive.TabIndex = 4;
            this.m_lstUnReceive.UseCompatibleStateImageBehavior = false;
            this.m_lstUnReceive.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "样本条码";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "患者姓名";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "标本类型";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "检验内容";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "病人类型";
            this.columnHeader6.Width = 73;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "采样时间";
            this.columnHeader7.Width = 145;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "急诊";
            this.columnHeader8.Width = 44;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "特殊处理";
            this.columnHeader9.Width = 73;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "采集人员";
            this.columnHeader10.Width = 73;
            // 
            // tabReceive
            // 
            this.tabReceive.Controls.Add(this.m_lsvReceiveSampleList);
            this.tabReceive.Location = new System.Drawing.Point(4, 22);
            this.tabReceive.Name = "tabReceive";
            this.tabReceive.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceive.Size = new System.Drawing.Size(980, 282);
            this.tabReceive.TabIndex = 1;
            this.tabReceive.Text = "已核收标本";
            this.tabReceive.UseVisualStyleBackColor = true;
            // 
            // m_lsvReceiveSampleList
            // 
            this.m_lsvReceiveSampleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chBarCode,
            this.m_chPatientName,
            this.m_chSampleType,
            this.m_chCheckContent,
            this.m_chPatientType,
            this.m_chReceiveDat,
            this.m_chIsEmergency,
            this.m_chIsSpecial,
            this.m_chReceiveEmp,
            this.m_chSendSampleEmp});
            this.m_lsvReceiveSampleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvReceiveSampleList.FullRowSelect = true;
            this.m_lsvReceiveSampleList.GridLines = true;
            this.m_lsvReceiveSampleList.Location = new System.Drawing.Point(3, 3);
            this.m_lsvReceiveSampleList.MultiSelect = false;
            this.m_lsvReceiveSampleList.Name = "m_lsvReceiveSampleList";
            this.m_lsvReceiveSampleList.Size = new System.Drawing.Size(974, 276);
            this.m_lsvReceiveSampleList.TabIndex = 22;
            this.m_lsvReceiveSampleList.UseCompatibleStateImageBehavior = false;
            this.m_lsvReceiveSampleList.View = System.Windows.Forms.View.Details;
            this.m_lsvReceiveSampleList.DoubleClick += new System.EventHandler(this.m_lsvReceiveSampleList_DoubleClick);
            // 
            // m_chBarCode
            // 
            this.m_chBarCode.Text = "样本条码";
            this.m_chBarCode.Width = 135;
            // 
            // m_chPatientName
            // 
            this.m_chPatientName.Text = "患者姓名";
            this.m_chPatientName.Width = 80;
            // 
            // m_chSampleType
            // 
            this.m_chSampleType.Text = "标本类型";
            this.m_chSampleType.Width = 77;
            // 
            // m_chCheckContent
            // 
            this.m_chCheckContent.Text = "检验内容";
            this.m_chCheckContent.Width = 206;
            // 
            // m_chPatientType
            // 
            this.m_chPatientType.Text = "病人类型";
            this.m_chPatientType.Width = 73;
            // 
            // m_chReceiveDat
            // 
            this.m_chReceiveDat.Text = "核收时间";
            this.m_chReceiveDat.Width = 163;
            // 
            // m_chIsEmergency
            // 
            this.m_chIsEmergency.Text = "急诊";
            this.m_chIsEmergency.Width = 44;
            // 
            // m_chIsSpecial
            // 
            this.m_chIsSpecial.Text = "特殊处理";
            this.m_chIsSpecial.Width = 70;
            // 
            // m_chReceiveEmp
            // 
            this.m_chReceiveEmp.Text = "核收人员";
            this.m_chReceiveEmp.Width = 73;
            // 
            // m_chSendSampleEmp
            // 
            this.m_chSendSampleEmp.Text = "送检人员";
            this.m_chSendSampleEmp.Width = 73;
            // 
            // m_lbReceiveSample
            // 
            this.m_lbReceiveSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbReceiveSample.BackColor = System.Drawing.Color.LightSteelBlue;
            this.m_lbReceiveSample.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lbReceiveSample.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lbReceiveSample.Location = new System.Drawing.Point(311, 222);
            this.m_lbReceiveSample.Name = "m_lbReceiveSample";
            this.m_lbReceiveSample.Size = new System.Drawing.Size(677, 23);
            this.m_lbReceiveSample.TabIndex = 23;
            this.m_lbReceiveSample.Text = "已核收标本(按 F4 打印结果)";
            // 
            // m_gpbQurey
            // 
            this.m_gpbQurey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbQurey.Controls.Add(this.btnRPrintBarCode);
            this.m_gpbQurey.Controls.Add(this.btnIp);
            this.m_gpbQurey.Controls.Add(this.btnTj);
            this.m_gpbQurey.Controls.Add(this.m_txtPatientCardID);
            this.m_gpbQurey.Controls.Add(this.m_txtInPatientNum);
            this.m_gpbQurey.Controls.Add(this.label12);
            this.m_gpbQurey.Controls.Add(this.m_txtSendPeopleForSearch);
            this.m_gpbQurey.Controls.Add(this.label9);
            this.m_gpbQurey.Controls.Add(this.btnExit);
            this.m_gpbQurey.Controls.Add(this.cboCheckCategory);
            this.m_gpbQurey.Controls.Add(this.m_txtQryReceiveEmp);
            this.m_gpbQurey.Controls.Add(this.m_txtBarCodeForSearch);
            this.m_gpbQurey.Controls.Add(this.m_txtPatientNameForSearch);
            this.m_gpbQurey.Controls.Add(this.label6);
            this.m_gpbQurey.Controls.Add(this.label5);
            this.m_gpbQurey.Controls.Add(this.label4);
            this.m_gpbQurey.Controls.Add(this.m_cboQrySampleType);
            this.m_gpbQurey.Controls.Add(this.m_lbQrySampleType);
            this.m_gpbQurey.Controls.Add(this.m_btnQuery);
            this.m_gpbQurey.Controls.Add(this.m_lbDatTo);
            this.m_gpbQurey.Controls.Add(this.m_dtpDatTo);
            this.m_gpbQurey.Controls.Add(this.m_lbDatRange);
            this.m_gpbQurey.Controls.Add(this.m_dtpDatFrom);
            this.m_gpbQurey.Controls.Add(this.m_lbQryReceiveEmp);
            this.m_gpbQurey.Location = new System.Drawing.Point(560, 2);
            this.m_gpbQurey.Name = "m_gpbQurey";
            this.m_gpbQurey.Size = new System.Drawing.Size(432, 212);
            this.m_gpbQurey.TabIndex = 21;
            this.m_gpbQurey.TabStop = false;
            this.m_gpbQurey.Text = "查询";
            // 
            // btnRPrintBarCode
            // 
            this.btnRPrintBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRPrintBarCode.DefaultScheme = true;
            this.btnRPrintBarCode.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRPrintBarCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRPrintBarCode.Hint = "";
            this.btnRPrintBarCode.Location = new System.Drawing.Point(226, 174);
            this.btnRPrintBarCode.Name = "btnRPrintBarCode";
            this.btnRPrintBarCode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRPrintBarCode.Size = new System.Drawing.Size(178, 32);
            this.btnRPrintBarCode.TabIndex = 44;
            this.btnRPrintBarCode.Text = "重打条码 (&R)";
            this.btnRPrintBarCode.TextColor = System.Drawing.Color.Black;
            this.btnRPrintBarCode.Click += new System.EventHandler(this.btnRPrintBarCode_Click);
            // 
            // btnIp
            // 
            this.btnIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnIp.DefaultScheme = true;
            this.btnIp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIp.ForeColor = System.Drawing.Color.Blue;
            this.btnIp.Hint = "";
            this.btnIp.Location = new System.Drawing.Point(226, 104);
            this.btnIp.Name = "btnIp";
            this.btnIp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnIp.Size = new System.Drawing.Size(178, 32);
            this.btnIp.TabIndex = 43;
            this.btnIp.Text = "住院核收 (&I)";
            this.btnIp.TextColor = System.Drawing.Color.Blue;
            this.btnIp.Click += new System.EventHandler(this.btnIp_Click);
            // 
            // btnTj
            // 
            this.btnTj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnTj.DefaultScheme = true;
            this.btnTj.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTj.Hint = "";
            this.btnTj.Location = new System.Drawing.Point(226, 139);
            this.btnTj.Name = "btnTj";
            this.btnTj.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnTj.Size = new System.Drawing.Size(178, 32);
            this.btnTj.TabIndex = 42;
            this.btnTj.Text = "体检核收 (&T)";
            this.btnTj.TextColor = System.Drawing.Color.OrangeRed;
            this.btnTj.Click += new System.EventHandler(this.btnTj_Click);
            // 
            // m_txtPatientCardID
            // 
            this.m_txtPatientCardID.Location = new System.Drawing.Point(76, 91);
            this.m_txtPatientCardID.MaxLength = 50;
            this.m_txtPatientCardID.Name = "m_txtPatientCardID";
            this.m_txtPatientCardID.PatientCard = "";
            this.m_txtPatientCardID.PatientFlag = 0;
            this.m_txtPatientCardID.Size = new System.Drawing.Size(120, 23);
            this.m_txtPatientCardID.TabIndex = 30;
            this.m_txtPatientCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPatientCardID.YBCardText = "";
            // 
            // m_txtInPatientNum
            // 
            this.m_txtInPatientNum.Location = new System.Drawing.Point(76, 167);
            this.m_txtInPatientNum.Name = "m_txtInPatientNum";
            this.m_txtInPatientNum.Size = new System.Drawing.Size(120, 23);
            this.m_txtInPatientNum.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 40;
            this.label12.Text = "住院号";
            // 
            // m_txtSendPeopleForSearch
            // 
            this.m_txtSendPeopleForSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtSendPeopleForSearch.EnableAutoValidation = true;
            this.m_txtSendPeopleForSearch.EnableEnterKeyValidate = true;
            this.m_txtSendPeopleForSearch.EnableEscapeKeyUndo = true;
            this.m_txtSendPeopleForSearch.EnableLastValidValue = true;
            this.m_txtSendPeopleForSearch.ErrorProvider = null;
            this.m_txtSendPeopleForSearch.ErrorProviderMessage = "Invalid value";
            this.m_txtSendPeopleForSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSendPeopleForSearch.ForceFormatText = true;
            this.m_txtSendPeopleForSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSendPeopleForSearch.Location = new System.Drawing.Point(76, 141);
            this.m_txtSendPeopleForSearch.m_intShowOtherEmp = 0;
            this.m_txtSendPeopleForSearch.m_StrDeptID = "*";
            this.m_txtSendPeopleForSearch.m_StrEmployeeID = null;
            this.m_txtSendPeopleForSearch.m_StrEmployeeName = null;
            this.m_txtSendPeopleForSearch.MaxLength = 20;
            this.m_txtSendPeopleForSearch.Name = "m_txtSendPeopleForSearch";
            this.m_txtSendPeopleForSearch.Size = new System.Drawing.Size(120, 23);
            this.m_txtSendPeopleForSearch.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 38;
            this.label9.Text = "送检人";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(320, 70);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(84, 32);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "退出(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboCheckCategory
            // 
            this.cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckCategory.FormattingEnabled = true;
            this.cboCheckCategory.Location = new System.Drawing.Point(264, 44);
            this.cboCheckCategory.Name = "cboCheckCategory";
            this.cboCheckCategory.Size = new System.Drawing.Size(120, 22);
            this.cboCheckCategory.TabIndex = 34;
            // 
            // m_txtQryReceiveEmp
            // 
            this.m_txtQryReceiveEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtQryReceiveEmp.EnableAutoValidation = true;
            this.m_txtQryReceiveEmp.EnableEnterKeyValidate = true;
            this.m_txtQryReceiveEmp.EnableEscapeKeyUndo = true;
            this.m_txtQryReceiveEmp.EnableLastValidValue = true;
            this.m_txtQryReceiveEmp.ErrorProvider = null;
            this.m_txtQryReceiveEmp.ErrorProviderMessage = "Invalid value";
            this.m_txtQryReceiveEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtQryReceiveEmp.ForceFormatText = true;
            this.m_txtQryReceiveEmp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtQryReceiveEmp.Location = new System.Drawing.Point(256, 112);
            this.m_txtQryReceiveEmp.m_intShowOtherEmp = 0;
            this.m_txtQryReceiveEmp.m_StrDeptID = "*";
            this.m_txtQryReceiveEmp.m_StrEmployeeID = null;
            this.m_txtQryReceiveEmp.m_StrEmployeeName = null;
            this.m_txtQryReceiveEmp.MaxLength = 20;
            this.m_txtQryReceiveEmp.Name = "m_txtQryReceiveEmp";
            this.m_txtQryReceiveEmp.Size = new System.Drawing.Size(120, 23);
            this.m_txtQryReceiveEmp.TabIndex = 32;
            this.m_txtQryReceiveEmp.Visible = false;
            // 
            // m_txtBarCodeForSearch
            // 
            this.m_txtBarCodeForSearch.Location = new System.Drawing.Point(76, 115);
            this.m_txtBarCodeForSearch.Name = "m_txtBarCodeForSearch";
            this.m_txtBarCodeForSearch.Size = new System.Drawing.Size(120, 23);
            this.m_txtBarCodeForSearch.TabIndex = 31;
            // 
            // m_txtPatientNameForSearch
            // 
            this.m_txtPatientNameForSearch.Location = new System.Drawing.Point(76, 67);
            this.m_txtPatientNameForSearch.Name = "m_txtPatientNameForSearch";
            this.m_txtPatientNameForSearch.Size = new System.Drawing.Size(120, 23);
            this.m_txtPatientNameForSearch.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "样本编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "诊疗卡号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "患者姓名";
            // 
            // m_cboQrySampleType
            // 
            this.m_cboQrySampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboQrySampleType.Location = new System.Drawing.Point(76, 44);
            this.m_cboQrySampleType.Name = "m_cboQrySampleType";
            this.m_cboQrySampleType.Size = new System.Drawing.Size(120, 22);
            this.m_cboQrySampleType.TabIndex = 25;
            // 
            // m_lbQrySampleType
            // 
            this.m_lbQrySampleType.AutoSize = true;
            this.m_lbQrySampleType.Location = new System.Drawing.Point(12, 48);
            this.m_lbQrySampleType.Name = "m_lbQrySampleType";
            this.m_lbQrySampleType.Size = new System.Drawing.Size(63, 14);
            this.m_lbQrySampleType.TabIndex = 24;
            this.m_lbQrySampleType.Text = "样本类型";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(226, 70);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(84, 32);
            this.m_btnQuery.TabIndex = 23;
            this.m_btnQuery.Text = "查询(F5)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_lbDatTo
            // 
            this.m_lbDatTo.AutoSize = true;
            this.m_lbDatTo.Location = new System.Drawing.Point(220, 24);
            this.m_lbDatTo.Name = "m_lbDatTo";
            this.m_lbDatTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbDatTo.TabIndex = 19;
            this.m_lbDatTo.Text = "至";
            // 
            // m_dtpDatTo
            // 
            this.m_dtpDatTo.Location = new System.Drawing.Point(264, 20);
            this.m_dtpDatTo.Name = "m_dtpDatTo";
            this.m_dtpDatTo.Size = new System.Drawing.Size(120, 23);
            this.m_dtpDatTo.TabIndex = 20;
            // 
            // m_lbDatRange
            // 
            this.m_lbDatRange.AutoSize = true;
            this.m_lbDatRange.Location = new System.Drawing.Point(12, 24);
            this.m_lbDatRange.Name = "m_lbDatRange";
            this.m_lbDatRange.Size = new System.Drawing.Size(63, 14);
            this.m_lbDatRange.TabIndex = 17;
            this.m_lbDatRange.Text = "核收时间";
            // 
            // m_dtpDatFrom
            // 
            this.m_dtpDatFrom.Location = new System.Drawing.Point(76, 20);
            this.m_dtpDatFrom.Name = "m_dtpDatFrom";
            this.m_dtpDatFrom.Size = new System.Drawing.Size(120, 23);
            this.m_dtpDatFrom.TabIndex = 18;
            // 
            // m_lbQryReceiveEmp
            // 
            this.m_lbQryReceiveEmp.AutoSize = true;
            this.m_lbQryReceiveEmp.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lbQryReceiveEmp.Location = new System.Drawing.Point(200, 48);
            this.m_lbQryReceiveEmp.Name = "m_lbQryReceiveEmp";
            this.m_lbQryReceiveEmp.Size = new System.Drawing.Size(65, 12);
            this.m_lbQryReceiveEmp.TabIndex = 15;
            this.m_lbQryReceiveEmp.Text = "核收人员组";
            // 
            // m_gpbBaseInfo
            // 
            this.m_gpbBaseInfo.Controls.Add(this.m_btnSampleBack);
            this.m_gpbBaseInfo.Controls.Add(this.m_cboSampleBackReason);
            this.m_gpbBaseInfo.Controls.Add(this.label11);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtSendPeople);
            this.m_gpbBaseInfo.Controls.Add(this.label8);
            this.m_gpbBaseInfo.Controls.Add(this.btnPrint);
            this.m_gpbBaseInfo.Controls.Add(this.btnPrintView);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtSampleType);
            this.m_gpbBaseInfo.Controls.Add(this.label1);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtFlagSepcial);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtFlagEmergency);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbSampleType);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbPatientType);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtReceiveEmp);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbReceiveEmp);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbCheckContent);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtCheckContent);
            this.m_gpbBaseInfo.Controls.Add(this.m_btnClear);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtBarCode);
            this.m_gpbBaseInfo.Controls.Add(this.m_btnReceiveSample);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtPatientType);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbBarCode);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtChargeState);
            this.m_gpbBaseInfo.Controls.Add(this.label3);
            this.m_gpbBaseInfo.Controls.Add(this.m_txtPatientName);
            this.m_gpbBaseInfo.Controls.Add(this.label2);
            this.m_gpbBaseInfo.Controls.Add(this.m_dtpReceiveDat);
            this.m_gpbBaseInfo.Controls.Add(this.m_lbReceiveDat);
            this.m_gpbBaseInfo.Location = new System.Drawing.Point(4, 2);
            this.m_gpbBaseInfo.Name = "m_gpbBaseInfo";
            this.m_gpbBaseInfo.Size = new System.Drawing.Size(548, 212);
            this.m_gpbBaseInfo.TabIndex = 14;
            this.m_gpbBaseInfo.TabStop = false;
            this.m_gpbBaseInfo.Text = "基本信息";
            // 
            // m_btnSampleBack
            // 
            this.m_btnSampleBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSampleBack.DefaultScheme = true;
            this.m_btnSampleBack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSampleBack.Hint = "";
            this.m_btnSampleBack.Location = new System.Drawing.Point(439, 175);
            this.m_btnSampleBack.Name = "m_btnSampleBack";
            this.m_btnSampleBack.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSampleBack.Size = new System.Drawing.Size(105, 28);
            this.m_btnSampleBack.TabIndex = 41;
            this.m_btnSampleBack.Text = "拒收标本";
            this.m_btnSampleBack.Click += new System.EventHandler(this.m_btnSampleBack_Click);
            // 
            // m_cboSampleBackReason
            // 
            this.m_cboSampleBackReason.BackColor = System.Drawing.SystemColors.Info;
            this.m_cboSampleBackReason.FormattingEnabled = true;
            this.m_cboSampleBackReason.Items.AddRange(new object[] {
            "溶血",
            "标本量少",
            "标本量多",
            "资料不相符",
            "用错试管"});
            this.m_cboSampleBackReason.Location = new System.Drawing.Point(76, 173);
            this.m_cboSampleBackReason.MaxLength = 50;
            this.m_cboSampleBackReason.Name = "m_cboSampleBackReason";
            this.m_cboSampleBackReason.Size = new System.Drawing.Size(344, 22);
            this.m_cboSampleBackReason.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 39;
            this.label11.Text = "拒收标本";
            // 
            // m_txtSendPeople
            // 
            this.m_txtSendPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtSendPeople.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtSendPeople.EnableAutoValidation = true;
            this.m_txtSendPeople.EnableEnterKeyValidate = true;
            this.m_txtSendPeople.EnableEscapeKeyUndo = true;
            this.m_txtSendPeople.EnableLastValidValue = true;
            this.m_txtSendPeople.ErrorProvider = null;
            this.m_txtSendPeople.ErrorProviderMessage = "Invalid value";
            this.m_txtSendPeople.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSendPeople.ForceFormatText = true;
            this.m_txtSendPeople.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSendPeople.Location = new System.Drawing.Point(76, 147);
            this.m_txtSendPeople.m_intShowOtherEmp = 0;
            this.m_txtSendPeople.m_StrDeptID = "*";
            this.m_txtSendPeople.m_StrEmployeeID = null;
            this.m_txtSendPeople.m_StrEmployeeName = null;
            this.m_txtSendPeople.MaxLength = 20;
            this.m_txtSendPeople.Name = "m_txtSendPeople";
            this.m_txtSendPeople.Size = new System.Drawing.Size(344, 23);
            this.m_txtSendPeople.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 37;
            this.label8.Text = "送检人";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(439, 136);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(105, 28);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "申请单打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintView
            // 
            this.btnPrintView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrintView.DefaultScheme = true;
            this.btnPrintView.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintView.Hint = "";
            this.btnPrintView.Location = new System.Drawing.Point(439, 97);
            this.btnPrintView.Name = "btnPrintView";
            this.btnPrintView.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintView.Size = new System.Drawing.Size(105, 28);
            this.btnPrintView.TabIndex = 36;
            this.btnPrintView.Text = "申请单预览";
            this.btnPrintView.Click += new System.EventHandler(this.btnPrintView_Click);
            // 
            // m_txtSampleType
            // 
            this.m_txtSampleType.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtSampleType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSampleType.Location = new System.Drawing.Point(76, 97);
            this.m_txtSampleType.Name = "m_txtSampleType";
            this.m_txtSampleType.ReadOnly = true;
            this.m_txtSampleType.Size = new System.Drawing.Size(140, 23);
            this.m_txtSampleType.TabIndex = 30;
            this.m_txtSampleType.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "样本标志";
            // 
            // m_txtFlagSepcial
            // 
            this.m_txtFlagSepcial.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtFlagSepcial.ForeColor = System.Drawing.Color.Red;
            this.m_txtFlagSepcial.Location = new System.Drawing.Point(340, 97);
            this.m_txtFlagSepcial.Name = "m_txtFlagSepcial";
            this.m_txtFlagSepcial.ReadOnly = true;
            this.m_txtFlagSepcial.Size = new System.Drawing.Size(80, 23);
            this.m_txtFlagSepcial.TabIndex = 28;
            this.m_txtFlagSepcial.TabStop = false;
            // 
            // m_txtFlagEmergency
            // 
            this.m_txtFlagEmergency.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtFlagEmergency.ForeColor = System.Drawing.Color.Red;
            this.m_txtFlagEmergency.Location = new System.Drawing.Point(284, 97);
            this.m_txtFlagEmergency.Name = "m_txtFlagEmergency";
            this.m_txtFlagEmergency.ReadOnly = true;
            this.m_txtFlagEmergency.Size = new System.Drawing.Size(56, 23);
            this.m_txtFlagEmergency.TabIndex = 27;
            this.m_txtFlagEmergency.TabStop = false;
            // 
            // m_lbSampleType
            // 
            this.m_lbSampleType.AutoSize = true;
            this.m_lbSampleType.Location = new System.Drawing.Point(12, 101);
            this.m_lbSampleType.Name = "m_lbSampleType";
            this.m_lbSampleType.Size = new System.Drawing.Size(63, 14);
            this.m_lbSampleType.TabIndex = 2;
            this.m_lbSampleType.Text = "样本类型";
            // 
            // m_lbPatientType
            // 
            this.m_lbPatientType.AutoSize = true;
            this.m_lbPatientType.Location = new System.Drawing.Point(220, 53);
            this.m_lbPatientType.Name = "m_lbPatientType";
            this.m_lbPatientType.Size = new System.Drawing.Size(63, 14);
            this.m_lbPatientType.TabIndex = 6;
            this.m_lbPatientType.Text = "病人类型";
            // 
            // m_txtReceiveEmp
            // 
            this.m_txtReceiveEmp.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtReceiveEmp.EnableAutoValidation = true;
            this.m_txtReceiveEmp.EnableEnterKeyValidate = true;
            this.m_txtReceiveEmp.EnableEscapeKeyUndo = true;
            this.m_txtReceiveEmp.EnableLastValidValue = true;
            this.m_txtReceiveEmp.ErrorProvider = null;
            this.m_txtReceiveEmp.ErrorProviderMessage = "Invalid value";
            this.m_txtReceiveEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReceiveEmp.ForceFormatText = true;
            this.m_txtReceiveEmp.Location = new System.Drawing.Point(76, 73);
            this.m_txtReceiveEmp.m_intShowOtherEmp = 0;
            this.m_txtReceiveEmp.m_StrDeptID = "*";
            this.m_txtReceiveEmp.m_StrEmployeeID = null;
            this.m_txtReceiveEmp.m_StrEmployeeName = null;
            this.m_txtReceiveEmp.Name = "m_txtReceiveEmp";
            this.m_txtReceiveEmp.ReadOnly = true;
            this.m_txtReceiveEmp.Size = new System.Drawing.Size(140, 23);
            this.m_txtReceiveEmp.TabIndex = 2;
            this.m_txtReceiveEmp.TabStop = false;
            // 
            // m_lbReceiveEmp
            // 
            this.m_lbReceiveEmp.AutoSize = true;
            this.m_lbReceiveEmp.Location = new System.Drawing.Point(12, 77);
            this.m_lbReceiveEmp.Name = "m_lbReceiveEmp";
            this.m_lbReceiveEmp.Size = new System.Drawing.Size(63, 14);
            this.m_lbReceiveEmp.TabIndex = 10;
            this.m_lbReceiveEmp.Text = "核收人员";
            // 
            // m_lbCheckContent
            // 
            this.m_lbCheckContent.AutoSize = true;
            this.m_lbCheckContent.Location = new System.Drawing.Point(12, 125);
            this.m_lbCheckContent.Name = "m_lbCheckContent";
            this.m_lbCheckContent.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckContent.TabIndex = 4;
            this.m_lbCheckContent.Text = "检验内容";
            // 
            // m_txtCheckContent
            // 
            this.m_txtCheckContent.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtCheckContent.Location = new System.Drawing.Point(76, 121);
            this.m_txtCheckContent.Name = "m_txtCheckContent";
            this.m_txtCheckContent.ReadOnly = true;
            this.m_txtCheckContent.Size = new System.Drawing.Size(344, 23);
            this.m_txtCheckContent.TabIndex = 5;
            this.m_txtCheckContent.TabStop = false;
            // 
            // m_btnClear
            // 
            this.m_btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnClear.DefaultScheme = true;
            this.m_btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClear.Hint = "";
            this.m_btnClear.Location = new System.Drawing.Point(439, 58);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClear.Size = new System.Drawing.Size(105, 28);
            this.m_btnClear.TabIndex = 5;
            this.m_btnClear.Text = "清空(F2)";
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_txtBarCode
            // 
            this.m_txtBarCode.Location = new System.Drawing.Point(76, 25);
            this.m_txtBarCode.Name = "m_txtBarCode";
            this.m_txtBarCode.Size = new System.Drawing.Size(140, 23);
            this.m_txtBarCode.TabIndex = 0;
            this.m_txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBarCode_KeyDown);
            // 
            // m_btnReceiveSample
            // 
            this.m_btnReceiveSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnReceiveSample.DefaultScheme = true;
            this.m_btnReceiveSample.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnReceiveSample.Hint = "";
            this.m_btnReceiveSample.Location = new System.Drawing.Point(439, 19);
            this.m_btnReceiveSample.Name = "m_btnReceiveSample";
            this.m_btnReceiveSample.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnReceiveSample.Size = new System.Drawing.Size(105, 28);
            this.m_btnReceiveSample.TabIndex = 4;
            this.m_btnReceiveSample.Text = "核收标本(F3)";
            this.m_btnReceiveSample.Click += new System.EventHandler(this.m_btnReceiveSample_Click);
            // 
            // m_txtPatientType
            // 
            this.m_txtPatientType.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtPatientType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientType.Location = new System.Drawing.Point(284, 49);
            this.m_txtPatientType.Name = "m_txtPatientType";
            this.m_txtPatientType.ReadOnly = true;
            this.m_txtPatientType.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientType.TabIndex = 31;
            this.m_txtPatientType.TabStop = false;
            // 
            // m_lbBarCode
            // 
            this.m_lbBarCode.AutoSize = true;
            this.m_lbBarCode.Location = new System.Drawing.Point(12, 29);
            this.m_lbBarCode.Name = "m_lbBarCode";
            this.m_lbBarCode.Size = new System.Drawing.Size(63, 14);
            this.m_lbBarCode.TabIndex = 0;
            this.m_lbBarCode.Text = "样本条码";
            // 
            // m_txtChargeState
            // 
            this.m_txtChargeState.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtChargeState.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtChargeState.Location = new System.Drawing.Point(284, 73);
            this.m_txtChargeState.Name = "m_txtChargeState";
            this.m_txtChargeState.ReadOnly = true;
            this.m_txtChargeState.Size = new System.Drawing.Size(136, 23);
            this.m_txtChargeState.TabIndex = 35;
            this.m_txtChargeState.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "收费状态";
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtPatientName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPatientName.Location = new System.Drawing.Point(284, 25);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.ReadOnly = true;
            this.m_txtPatientName.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientName.TabIndex = 33;
            this.m_txtPatientName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "患者姓名";
            // 
            // m_dtpReceiveDat
            // 
            this.m_dtpReceiveDat.Enabled = false;
            this.m_dtpReceiveDat.Location = new System.Drawing.Point(76, 49);
            this.m_dtpReceiveDat.Name = "m_dtpReceiveDat";
            this.m_dtpReceiveDat.Size = new System.Drawing.Size(140, 23);
            this.m_dtpReceiveDat.TabIndex = 3;
            // 
            // m_lbReceiveDat
            // 
            this.m_lbReceiveDat.AutoSize = true;
            this.m_lbReceiveDat.Location = new System.Drawing.Point(12, 53);
            this.m_lbReceiveDat.Name = "m_lbReceiveDat";
            this.m_lbReceiveDat.Size = new System.Drawing.Size(63, 14);
            this.m_lbReceiveDat.TabIndex = 12;
            this.m_lbReceiveDat.Text = "核收时间";
            // 
            // frmSampleReceive
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1000, 553);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_lblSubmitDoctor);
            this.Controls.Add(this.m_btnLogin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_tabSampleList);
            this.Controls.Add(this.m_lbReceiveSample);
            this.Controls.Add(this.m_gpbQurey);
            this.Controls.Add(this.m_gpbBaseInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmSampleReceive";
            this.Text = "标本签收";
            this.Load += new System.EventHandler(this.frmSampleReceive_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEnterHandler);
            this.m_tabSampleList.ResumeLayout(false);
            this.tabUnReceive.ResumeLayout(false);
            this.tabReceive.ResumeLayout(false);
            this.m_gpbQurey.ResumeLayout(false);
            this.m_gpbQurey.PerformLayout();
            this.m_gpbBaseInfo.ResumeLayout(false);
            this.m_gpbBaseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 一般设置
        #region 快捷键设置
        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.F6)
            {

            }
            else if (p_eumKeyCode == Keys.F2 && this.m_btnClear.Enabled && m_btnClear.Visible)//
            {
                this.m_btnClear_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F3 && this.m_btnReceiveSample.Enabled && m_btnReceiveSample.Visible)//
            {
                this.m_btnReceiveSample_Click(null, null);
            }
            else if (p_eumKeyCode == Keys.F4)   //打印查询结果 baojian.mo 2007.09.10 add
            {
                this.m_mthPreview();
            }
            else if (p_eumKeyCode == Keys.F5 && this.m_btnQuery.Enabled && m_btnQuery.Visible)		//
            {
                this.m_btnQuery_Click(null, null);
            }
        }
        #endregion
        #region Enter 键选择下一个
        private void m_mthEnterHandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            this.m_mthSetKeyTab(e);
        }

        #endregion

        #endregion

        #region FormLoadEvent
        private void frmSampleReceive_Load(object sender, System.EventArgs e)
        {
            m_objController.m_mthViewerInital();
            this.m_mthSetFormControlCanBeNull(this);
            this.m_mthSetEnter2Tab(new Control[] { this.m_txtBarCode });

            m_tabSampleList.SelectedTab = tabReceive;
            //get parm value
            BillStyle = clsPublic.m_intGetSysParm("4009");
            intSendPepoleID = clsPublic.m_intGetSysParm("4022");

            try
            {
                this.blnAutoReceive = true;

                //string strAutoReceive = System.Configuration.ConfigurationSettings.AppSettings["LIS_AutoReceiveSample"];
                //if (strAutoReceive == "1")
                //{
                //    this.blnAutoReceive = true;
                //}
            }
            catch { }
            m_strSubmitDoctorId = this.LoginInfo.m_strEmpID;
        }
        #endregion

        #region CreateController
        public override void CreateController()
        {
            m_objController = new clsController_SampleReceive();
            this.objController = m_objController;
            m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region BarCodeEvent
        private void m_txtBarCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool isFinish = m_objController.m_mthGetUnreceivedSampleInfoByBarCode();
                if (isFinish)
                {
                    this.m_btnReceiveSample.Focus();
                    if (blnAutoReceive)
                    {
                        SendKeys.SendWait("{ENTER}");		//xing.chen add for 佛山需求
                    }
                }
                else
                {
                    if (this.m_txtBarCode.Text != "")
                    {
                        this.m_txtBarCode.Focus();
                        this.m_txtBarCode.Select(0, this.m_txtBarCode.Text.Length);
                    }
                }
            }
        }
        #endregion

        #region Query
        private void m_btnQuery_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            m_objController.m_mthQryReceivedSample();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 接收标本
        private void m_btnReceiveSample_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            m_btnReceiveSample.Enabled = false;

            m_objController.m_mthReceiveSample();

            Cursor.Current = Cursors.Default;
            m_btnReceiveSample.Enabled = true;

            this.m_txtBarCode.Focus();
            this.m_txtBarCode.SelectionStart = 0;
            this.m_txtBarCode.SelectionLength = this.m_txtBarCode.Text.Length;
        }
        #endregion

        #region 选中已接收标本
        private void m_lsvReceiveSampleList_DoubleClick(object sender, System.EventArgs e)
        {
            m_objController.m_mthShowLsvSampleInfo();
        }
        #endregion

        #region Clear
        private void m_btnClear_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthClearAll();
        }
        #endregion

        //测试检验申请用
        private void button1_Click(object sender, System.EventArgs e)
        {
            //			clsLisApplMainVO obj = new clsLisApplMainVO();
            //			obj.m_strPatient_Name = "test1111";
            //			obj.m_strPatientType = "3";
            //			obj.m_strSex = "女";
            //			obj.m_strAge = "12 岁";
            //			obj.m_strBedNO = "34";
            //			frmLisAppl frm = new frmLisAppl();
            //			clsLISAppResults objR;
            //			if(frm.m_mthNewApp(obj) == DialogResult.OK)
            //			{
            //				objR = frm.m_objGetAppResults();
            //			}

            clsLisApplMainVO obj = new clsLisApplMainVO();
            obj.m_strPatient_Name = "test1111";
            obj.m_strPatientType = "3";
            obj.m_strSex = "女";
            obj.m_strAge = "12 岁";
            obj.m_strBedNO = "34";
            //			obj.m_strSampleTypeID = "000001";
            frmLisAppl frm = new frmLisAppl();
            clsLISAppResults objR;
            clsTestApplyItme_VO[] objArr = new clsTestApplyItme_VO[3];
            for (int i = 0; i < objArr.Length; i++)
            {
                objArr[i] = new clsTestApplyItme_VO();
                objArr[i].m_strItemName = i.ToString();
                objArr[i].m_decPrice = i + (decimal)0.5;
            }
            objArr[0].m_strItemID = "000019";
            objArr[1].m_strItemID = "000080";
            objArr[2].m_strItemID = "000081";
            //			string[] strIDarr = new string[]{"000019","000080","000081"};
            if (frm.m_mthNewApp(obj, objArr, true) == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("false");
            }


            //			frmLisAppl frm = new frmLisAppl("000000000000118557");
            //			frm.ShowDialog();
        }

        private void btnPrintView_Click(object sender, System.EventArgs e)
        {
            if (this.m_lsvReceiveSampleList.SelectedItems.Count > 0)
            {
                clsSampleReceive_VO objSample = (clsSampleReceive_VO)this.m_lsvReceiveSampleList.SelectedItems[0].Tag;
                if (objSample.m_strApplicationID != null && objSample.m_strApplicationID.Trim() != "")
                {
                    m_mthPrint(objSample, 1);
                    //m_objPrint.m_mthGetPrintContent(objSample.m_strApplicationID,objSample.m_strBarCode);
                    //m_objPrint.m_mthReport(1);
                }
                //else
                //{
                //    long lngRes = 0;
                //    clsT_OPR_LIS_SAMPLE_VO[] objSampleVO = null;
                //    lngRes = this.m_objController.m_lngFindSampleVOByBarCode(objSample.m_strBarCode,out objSampleVO);
                //    if( lngRes < 0 )
                //    {
                //        MessageBox.Show(this,"获取申请信息失败","检验核收信息提示");
                //        return;
                //    }
                //    if( objSampleVO != null && objSampleVO.Length > 0 )
                //    {
                //        m_mthPrint(objSampleVO[0], 1);
                //        //m_objPrint.m_mthGetPrintContent(objSampleVO[0].m_strAPPLICATION_ID_CHR, objSample.m_strBarCode);
                //        //m_objPrint.m_mthReport(1);
                //    }
                //}
            }
            else
            {
                MessageBox.Show(this, "请选择要预览的申请", "检验核收信息提示");
            }
        }

        #region 预览查询结果
        /// <summary>
        /// 预览查询结果
        /// baojian.mo 2007.09.10 add
        /// </summary>
        private void m_mthPreview()
        {
            if (this.m_lsvReceiveSampleList.Items.Count == 0)
            {
                MessageBox.Show("没有要打印的查询结果", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ((clsController_SampleReceive)this.m_objController).m_mthReport();
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.m_lsvReceiveSampleList.SelectedItems.Count > 0)
            {
                clsSampleReceive_VO objSample = m_lsvReceiveSampleList.SelectedItems[0].Tag as clsSampleReceive_VO;
                if (objSample != null)
                {
                    m_mthPrint(objSample, 0);
                }
                else
                {
                    MessageBox.Show(this, "请选择申请单！", "检验核收信息提示");
                }
            }
            else
            {
                MessageBox.Show(this, "请选择申请单！", "检验核收信息提示");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objReceiveSample"></param>
        /// <param name="p_intModule">0 直接打印 1 预览</param>
        private void m_mthPrint(clsSampleReceive_VO p_objReceiveSample, int p_intModule)
        {
            clsSealedLisApplyReportPrint m_objPrint = new clsSealedLisApplyReportPrint();
            m_objPrint.m_mthGetPrintContent(p_objReceiveSample.m_strApplicationID);

            if (BillStyle == 0)
            {
                if (p_intModule == 0)
                {
                    m_objPrint.m_mthPrint();
                }
                else
                {
                    m_objPrint.m_mthPrintPreview();
                }
            }
            else
            {
                m_objPrint.m_mthReport(p_intModule);
            }
        }

        private void tabSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_tabSampleList.SelectedTab == tabUnReceive)
            {
                m_lbDatRange.Text = "采样时间";
                m_lbQryReceiveEmp.Text = "采样人员";
            }
            else
            {
                m_lbDatRange.Text = "核收时间";
                m_lbQryReceiveEmp.Text = "核收人员";
            }
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
                m_txtReceiveEmp.Text = emp.m_StrEmployeeName;
                m_txtReceiveEmp.m_StrEmployeeID = empid;
                m_txtReceiveEmp.m_StrEmployeeName = emp.m_StrEmployeeName;
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.m_strSubmitDoctorId = this.LoginInfo.m_strEmpID;
            this.m_lblSubmitDoctor.Text = this.LoginInfo.m_strEmpName;
            SubmitLogin();
        }

        private void m_btnSampleBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_cboSampleBackReason.Text))
            {
                MessageBox.Show(this, "请输入拒收标本原因", "标本拒收提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            m_objController.m_mthSampleFeedBack();
        }

        private void btnTj_Click(object sender, EventArgs e)
        {
            frmSampleCheck frm = new frmSampleCheck(0);
            frm.ShowDialog();
        }

        private void btnIp_Click(object sender, EventArgs e)
        {
            frmSampleCheck frm = new frmSampleCheck(1);
            frm.ShowDialog();
        }

        private void btnRPrintBarCode_Click(object sender, EventArgs e)
        {
            frmSampleQuery frm = new frmSampleQuery();
            frm.PatchPrint = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //if (!string.IsNullOrEmpty(frm.BarCode))
                //{
                //    clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                //    string appId = domain.GetApplicationIdByBarcode(frm.BarCode);
                //    domain = null;
                //    if (!string.IsNullOrEmpty(appId))
                //    {
                //        //生成条型码
                //        string png = string.Empty;
                //        clsBarcodeMaker objBarcode = new clsBarcodeMaker();
                //        objBarcode.CreateBarcodeBMP(frm.BarCode, out png);
                //        objBarcode = null;

                //        clsSealedBIHLisApplyReportPrint printTool = new clsSealedBIHLisApplyReportPrint();
                //        printTool.m_mthGetPrintContent(appId, frm.BarCode);
                //        printTool.m_mthReport(0, "");
                //    }
                //}
            }
        }
    }
}

