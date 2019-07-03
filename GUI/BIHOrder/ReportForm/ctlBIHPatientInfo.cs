using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.controls;
using com.digitalwave.controls.datagrid;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using System.Reflection;
using com.digitalwave.iCare.gui;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace com.digitalwave.iCare.BIHOrder.Control
{
    /// <summary>
    /// 病人信息控件	只用于医嘱录入
    /// </summary>
    public class ctlBIHPatientInfo : System.Windows.Forms.UserControl
    {
        #region 控件或变量申明
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public ctlFindTextBox m_txtInHospitalNo;
        public TextBox m_txtPrePayMoney;
        public TextBox m_txtSex;
        public TextBox m_txtName;
        public TextBox m_txtPayType;
        public System.Windows.Forms.TextBox m_txtDiagnose;
        public TextBox m_txtInDays;
        public ctlFindTextBox m_txtArea;
        public TextBox m_txtInHospitalDate;
        private System.Windows.Forms.ListView m_lvwBed;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label m_lblBackground;
        public event EventHandler m_evtPatientChanged;
        public event EventHandler m_evtPatientFromBedAdmin;
        //private clsBIHOrderService m_objService;
        private clsTextFocusHighlight m_objHighlight;
        public clsBIHPatientInfo m_objPatient = null;
        public bool m_blnPrompt = true;
        private System.Windows.Forms.Label label2;
        public TextBox m_txtState;
        com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc m_objChargeSve = null;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox m_txtLIMITRATE_MNY;
        public CheckBox m_chkIsMedicareMan;
        private System.Windows.Forms.ToolTip toolTipDiagnose;
        public ctlFindTextBox m_txtBedNo;
        private TextBox m_txtBedNo3;
        public Button m_btnBedList;
        public TextBox m_txtPreMoney;
        private Label label13;
        public TextBox m_txtUseMoney;
        private Label label14;
        public TextBox m_txtREMARKNAME;
        private Label label15;
        public TextBox m_txtRegisterid;
        private Label label16;
        public TextBox m_txtClearMoney;
        private Label label17;
        public TextBox m_txtAge;
        private Label label18;
        internal PinkieControls.ButtonXP m_btnAddBills;
        internal PinkieControls.ButtonXP m_btnLIMITRATE_MNY;

        private com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo = null;
        #endregion
        internal PictureBox m_imgYellow;
        internal PictureBox m_imgPink;
        internal PinkieControls.ButtonXP btnCpIN;
        internal PinkieControls.ButtonXP btnCpToday;
        private Label label19;
        internal PinkieControls.ButtonXP btnCpOut;
        internal PinkieControls.ButtonXP btnCpVar;
        private Label lblCpHint;

        DataTable CpIcdDataSource { get; set; }

        #region 界面是否可以输入开关
        /// <summary>
        /// 界面是否可以输入开关(TRUE－可以,FALSE－不可以)
        /// </summary>
        internal bool m_blInputEnable = true;
        #endregion

        #region 构造函数
        public ctlBIHPatientInfo()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            // TODO: 在 InitializeComponent 调用后添加任何初始化

            //m_objService=new clsBIHOrderService();
            m_objHighlight = new clsTextFocusHighlight();
        }

        public ctlBIHPatientInfo(bool m_blInput)
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化

            //m_objService=new clsBIHOrderService();

            m_objHighlight = new clsTextFocusHighlight();
            m_blInputEnable = m_blInput;
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
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlBIHPatientInfo));
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtPrePayMoney = new System.Windows.Forms.TextBox();
            this.m_txtSex = new System.Windows.Forms.TextBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_txtPayType = new System.Windows.Forms.TextBox();
            this.m_txtDiagnose = new System.Windows.Forms.TextBox();
            this.m_txtInDays = new System.Windows.Forms.TextBox();
            this.m_txtInHospitalDate = new System.Windows.Forms.TextBox();
            this.m_lvwBed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_lblBackground = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtState = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtLIMITRATE_MNY = new System.Windows.Forms.TextBox();
            this.m_chkIsMedicareMan = new System.Windows.Forms.CheckBox();
            this.toolTipDiagnose = new System.Windows.Forms.ToolTip(this.components);
            this.m_txtBedNo3 = new System.Windows.Forms.TextBox();
            this.m_btnBedList = new System.Windows.Forms.Button();
            this.m_txtPreMoney = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtUseMoney = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtREMARKNAME = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtRegisterid = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtClearMoney = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtAge = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_btnAddBills = new PinkieControls.ButtonXP();
            this.m_btnLIMITRATE_MNY = new PinkieControls.ButtonXP();
            this.btnCpIN = new PinkieControls.ButtonXP();
            this.btnCpToday = new PinkieControls.ButtonXP();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCpOut = new PinkieControls.ButtonXP();
            this.btnCpVar = new PinkieControls.ButtonXP();
            this.m_imgPink = new System.Windows.Forms.PictureBox();
            this.m_imgYellow = new System.Windows.Forms.PictureBox();
            this.lblCpHint = new System.Windows.Forms.Label();
            this.m_txtBedNo = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtInHospitalNo = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtArea = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgPink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgYellow)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label11.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label11.Location = new System.Drawing.Point(4, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "病区:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label10.Location = new System.Drawing.Point(152, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "入院日期:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label9.Location = new System.Drawing.Point(777, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "结余余额";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label8.Location = new System.Drawing.Point(4, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "费别:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label7.Location = new System.Drawing.Point(342, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "住院号:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.DoubleClick += new System.EventHandler(this.label7_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label6.Location = new System.Drawing.Point(492, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "姓名:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label5.Location = new System.Drawing.Point(632, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "性别:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label4.Location = new System.Drawing.Point(156, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "床   号:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label3.Location = new System.Drawing.Point(329, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "住院天数:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(492, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "诊断:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPrePayMoney
            // 
            this.m_txtPrePayMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPrePayMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPrePayMoney.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtPrePayMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrePayMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txtPrePayMoney.Location = new System.Drawing.Point(840, 95);
            this.m_txtPrePayMoney.Name = "m_txtPrePayMoney";
            this.m_txtPrePayMoney.ReadOnly = true;
            this.m_txtPrePayMoney.Size = new System.Drawing.Size(81, 23);
            this.m_txtPrePayMoney.TabIndex = 28;
            this.m_txtPrePayMoney.TabStop = false;
            this.m_txtPrePayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtPrePayMoney_KeyPress);
            this.m_txtPrePayMoney.Enter += new System.EventHandler(this.m_txtPrePayMoney_Enter);
            // 
            // m_txtSex
            // 
            this.m_txtSex.BackColor = System.Drawing.Color.White;
            this.m_txtSex.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtSex.Location = new System.Drawing.Point(669, 7);
            this.m_txtSex.Name = "m_txtSex";
            this.m_txtSex.ReadOnly = true;
            this.m_txtSex.Size = new System.Drawing.Size(44, 23);
            this.m_txtSex.TabIndex = 25;
            this.m_txtSex.TabStop = false;
            this.m_txtSex.Enter += new System.EventHandler(this.m_txtSex_Enter);
            // 
            // m_txtName
            // 
            this.m_txtName.BackColor = System.Drawing.Color.White;
            this.m_txtName.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtName.Location = new System.Drawing.Point(531, 7);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.ReadOnly = true;
            this.m_txtName.Size = new System.Drawing.Size(101, 23);
            this.m_txtName.TabIndex = 23;
            this.m_txtName.TabStop = false;
            this.m_txtName.Enter += new System.EventHandler(this.m_txtName_Enter);
            // 
            // m_txtPayType
            // 
            this.m_txtPayType.BackColor = System.Drawing.Color.White;
            this.m_txtPayType.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtPayType.Location = new System.Drawing.Point(42, 37);
            this.m_txtPayType.Name = "m_txtPayType";
            this.m_txtPayType.ReadOnly = true;
            this.m_txtPayType.Size = new System.Drawing.Size(105, 23);
            this.m_txtPayType.TabIndex = 27;
            this.m_txtPayType.TabStop = false;
            this.m_txtPayType.Enter += new System.EventHandler(this.m_txtPayType_Enter);
            // 
            // m_txtDiagnose
            // 
            this.m_txtDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnose.Location = new System.Drawing.Point(532, 37);
            this.m_txtDiagnose.Name = "m_txtDiagnose";
            this.m_txtDiagnose.Size = new System.Drawing.Size(285, 23);
            this.m_txtDiagnose.TabIndex = 34;
            this.m_txtDiagnose.TabStop = false;
            this.m_txtDiagnose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDiagnose_KeyDown);
            this.m_txtDiagnose.Leave += new System.EventHandler(this.m_txtDiagnose_Leave);
            // 
            // m_txtInDays
            // 
            this.m_txtInDays.BackColor = System.Drawing.Color.White;
            this.m_txtInDays.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtInDays.Location = new System.Drawing.Point(394, 37);
            this.m_txtInDays.Name = "m_txtInDays";
            this.m_txtInDays.ReadOnly = true;
            this.m_txtInDays.Size = new System.Drawing.Size(92, 23);
            this.m_txtInDays.TabIndex = 30;
            this.m_txtInDays.TabStop = false;
            this.m_txtInDays.Enter += new System.EventHandler(this.m_txtInDays_Enter);
            // 
            // m_txtInHospitalDate
            // 
            this.m_txtInHospitalDate.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtInHospitalDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalDate.Location = new System.Drawing.Point(216, 37);
            this.m_txtInHospitalDate.Name = "m_txtInHospitalDate";
            this.m_txtInHospitalDate.ReadOnly = true;
            this.m_txtInHospitalDate.Size = new System.Drawing.Size(98, 23);
            this.m_txtInHospitalDate.TabIndex = 29;
            this.m_txtInHospitalDate.TabStop = false;
            this.m_txtInHospitalDate.Enter += new System.EventHandler(this.m_txtInHospitalDate_Enter);
            // 
            // m_lvwBed
            // 
            this.m_lvwBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lvwBed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lvwBed.FullRowSelect = true;
            this.m_lvwBed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lvwBed.HideSelection = false;
            this.m_lvwBed.Location = new System.Drawing.Point(372, 172);
            this.m_lvwBed.MultiSelect = false;
            this.m_lvwBed.Name = "m_lvwBed";
            this.m_lvwBed.Size = new System.Drawing.Size(150, 152);
            this.m_lvwBed.TabIndex = 33;
            this.m_lvwBed.UseCompatibleStateImageBehavior = false;
            this.m_lvwBed.View = System.Windows.Forms.View.Details;
            this.m_lvwBed.Visible = false;
            this.m_lvwBed.DoubleClick += new System.EventHandler(this.m_lvwBed_DoubleClick);
            this.m_lvwBed.Leave += new System.EventHandler(this.m_lvwBed_Leave);
            this.m_lvwBed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvwBed_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 30;
            // 
            // m_lblBackground
            // 
            this.m_lblBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblBackground.Location = new System.Drawing.Point(622, 142);
            this.m_lblBackground.Name = "m_lblBackground";
            this.m_lblBackground.Size = new System.Drawing.Size(24, 12);
            this.m_lblBackground.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label2.Location = new System.Drawing.Point(183, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 81;
            this.label2.Text = "状态";
            // 
            // m_txtState
            // 
            this.m_txtState.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtState.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtState.Location = new System.Drawing.Point(219, 204);
            this.m_txtState.Name = "m_txtState";
            this.m_txtState.ReadOnly = true;
            this.m_txtState.Size = new System.Drawing.Size(90, 23);
            this.m_txtState.TabIndex = 33;
            this.m_txtState.TabStop = false;
            this.m_txtState.Enter += new System.EventHandler(this.m_txtState_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label12.Location = new System.Drawing.Point(605, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "费用下限:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtLIMITRATE_MNY
            // 
            this.m_txtLIMITRATE_MNY.BackColor = System.Drawing.Color.Gainsboro;
            this.m_txtLIMITRATE_MNY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLIMITRATE_MNY.ForeColor = System.Drawing.Color.Red;
            this.m_txtLIMITRATE_MNY.Location = new System.Drawing.Point(674, 157);
            this.m_txtLIMITRATE_MNY.Name = "m_txtLIMITRATE_MNY";
            this.m_txtLIMITRATE_MNY.Size = new System.Drawing.Size(80, 23);
            this.m_txtLIMITRATE_MNY.TabIndex = 28;
            this.m_txtLIMITRATE_MNY.TabStop = false;
            // 
            // m_chkIsMedicareMan
            // 
            this.m_chkIsMedicareMan.Enabled = false;
            this.m_chkIsMedicareMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIsMedicareMan.Location = new System.Drawing.Point(818, 161);
            this.m_chkIsMedicareMan.Name = "m_chkIsMedicareMan";
            this.m_chkIsMedicareMan.Size = new System.Drawing.Size(94, 24);
            this.m_chkIsMedicareMan.TabIndex = 82;
            this.m_chkIsMedicareMan.Text = "医保";
            this.m_chkIsMedicareMan.Visible = false;
            this.m_chkIsMedicareMan.CheckedChanged += new System.EventHandler(this.m_chkIsMedicareMan_CheckedChanged);
            // 
            // m_txtBedNo3
            // 
            this.m_txtBedNo3.Location = new System.Drawing.Point(70, 189);
            this.m_txtBedNo3.Name = "m_txtBedNo3";
            this.m_txtBedNo3.Size = new System.Drawing.Size(79, 23);
            this.m_txtBedNo3.TabIndex = 32;
            this.m_txtBedNo3.Visible = false;
            this.m_txtBedNo3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBedNo_KeyDown);
            // 
            // m_btnBedList
            // 
            this.m_btnBedList.Location = new System.Drawing.Point(316, 7);
            this.m_btnBedList.Name = "m_btnBedList";
            this.m_btnBedList.Size = new System.Drawing.Size(19, 23);
            this.m_btnBedList.TabIndex = 83;
            this.m_btnBedList.Text = "↓";
            this.m_btnBedList.UseVisualStyleBackColor = true;
            this.m_btnBedList.Click += new System.EventHandler(this.m_btnBedList_Click);
            // 
            // m_txtPreMoney
            // 
            this.m_txtPreMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPreMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPreMoney.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtPreMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPreMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txtPreMoney.Location = new System.Drawing.Point(448, 95);
            this.m_txtPreMoney.Name = "m_txtPreMoney";
            this.m_txtPreMoney.ReadOnly = true;
            this.m_txtPreMoney.Size = new System.Drawing.Size(67, 23);
            this.m_txtPreMoney.TabIndex = 85;
            this.m_txtPreMoney.TabStop = false;
            this.m_txtPreMoney.Enter += new System.EventHandler(this.m_txtPreMoney_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label13.Location = new System.Drawing.Point(385, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 84;
            this.label13.Text = "预交金额";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtUseMoney
            // 
            this.m_txtUseMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtUseMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtUseMoney.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtUseMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUseMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txtUseMoney.Location = new System.Drawing.Point(578, 95);
            this.m_txtUseMoney.Name = "m_txtUseMoney";
            this.m_txtUseMoney.ReadOnly = true;
            this.m_txtUseMoney.Size = new System.Drawing.Size(68, 23);
            this.m_txtUseMoney.TabIndex = 87;
            this.m_txtUseMoney.TabStop = false;
            this.m_txtUseMoney.Enter += new System.EventHandler(this.m_txtUseMoney_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label14.Location = new System.Drawing.Point(515, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 86;
            this.label14.Text = "已用金额";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtREMARKNAME
            // 
            this.m_txtREMARKNAME.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtREMARKNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtREMARKNAME.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtREMARKNAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREMARKNAME.ForeColor = System.Drawing.Color.Red;
            this.m_txtREMARKNAME.Location = new System.Drawing.Point(584, 213);
            this.m_txtREMARKNAME.Name = "m_txtREMARKNAME";
            this.m_txtREMARKNAME.ReadOnly = true;
            this.m_txtREMARKNAME.Size = new System.Drawing.Size(342, 23);
            this.m_txtREMARKNAME.TabIndex = 89;
            this.m_txtREMARKNAME.TabStop = false;
            this.m_txtREMARKNAME.Enter += new System.EventHandler(this.m_txtREMARKNAME_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label15.Location = new System.Drawing.Point(522, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 88;
            this.label15.Text = "备    注";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtRegisterid
            // 
            this.m_txtRegisterid.Location = new System.Drawing.Point(273, 159);
            this.m_txtRegisterid.Name = "m_txtRegisterid";
            this.m_txtRegisterid.Size = new System.Drawing.Size(100, 23);
            this.m_txtRegisterid.TabIndex = 90;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(190, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 91;
            this.label16.Text = "病人登记号";
            // 
            // m_txtClearMoney
            // 
            this.m_txtClearMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtClearMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClearMoney.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtClearMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtClearMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txtClearMoney.Location = new System.Drawing.Point(709, 95);
            this.m_txtClearMoney.Name = "m_txtClearMoney";
            this.m_txtClearMoney.ReadOnly = true;
            this.m_txtClearMoney.Size = new System.Drawing.Size(68, 23);
            this.m_txtClearMoney.TabIndex = 93;
            this.m_txtClearMoney.TabStop = false;
            this.m_txtClearMoney.Enter += new System.EventHandler(this.m_txtClearMoney_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label17.Location = new System.Drawing.Point(646, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 92;
            this.label17.Text = "已结金额";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtAge
            // 
            this.m_txtAge.BackColor = System.Drawing.Color.White;
            this.m_txtAge.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_txtAge.Location = new System.Drawing.Point(755, 7);
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.ReadOnly = true;
            this.m_txtAge.Size = new System.Drawing.Size(62, 23);
            this.m_txtAge.TabIndex = 94;
            this.m_txtAge.TabStop = false;
            this.m_txtAge.Enter += new System.EventHandler(this.m_txtAge_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label18.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label18.Location = new System.Drawing.Point(718, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 95;
            this.label18.Text = "年龄:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_btnAddBills
            // 
            this.m_btnAddBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnAddBills.DefaultScheme = true;
            this.m_btnAddBills.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddBills.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_btnAddBills.Hint = "";
            this.m_btnAddBills.Location = new System.Drawing.Point(823, 5);
            this.m_btnAddBills.Name = "m_btnAddBills";
            this.m_btnAddBills.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddBills.Size = new System.Drawing.Size(52, 28);
            this.m_btnAddBills.TabIndex = 96;
            this.m_btnAddBills.Text = "费用";
            this.m_btnAddBills.Click += new System.EventHandler(this.m_btnAddBills_Click);
            // 
            // m_btnLIMITRATE_MNY
            // 
            this.m_btnLIMITRATE_MNY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnLIMITRATE_MNY.DefaultScheme = true;
            this.m_btnLIMITRATE_MNY.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnLIMITRATE_MNY.Font = new System.Drawing.Font("宋体", 9.5F);
            this.m_btnLIMITRATE_MNY.Hint = "";
            this.m_btnLIMITRATE_MNY.Location = new System.Drawing.Point(823, 34);
            this.m_btnLIMITRATE_MNY.Name = "m_btnLIMITRATE_MNY";
            this.m_btnLIMITRATE_MNY.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnLIMITRATE_MNY.Size = new System.Drawing.Size(52, 28);
            this.m_btnLIMITRATE_MNY.TabIndex = 97;
            this.m_btnLIMITRATE_MNY.Text = "额度";
            this.m_btnLIMITRATE_MNY.Click += new System.EventHandler(this.m_btnLIMITRATE_MNY_Click);
            // 
            // btnCpIN
            // 
            this.btnCpIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCpIN.DefaultScheme = true;
            this.btnCpIN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCpIN.Enabled = false;
            this.btnCpIN.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCpIN.Hint = "";
            this.btnCpIN.Location = new System.Drawing.Point(876, 5);
            this.btnCpIN.Name = "btnCpIN";
            this.btnCpIN.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCpIN.Size = new System.Drawing.Size(52, 28);
            this.btnCpIN.TabIndex = 120;
            this.btnCpIN.Text = "入径";
            this.btnCpIN.Click += new System.EventHandler(this.btnCpIN_Click);
            // 
            // btnCpToday
            // 
            this.btnCpToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCpToday.DefaultScheme = true;
            this.btnCpToday.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCpToday.Enabled = false;
            this.btnCpToday.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCpToday.Hint = "";
            this.btnCpToday.Location = new System.Drawing.Point(929, 5);
            this.btnCpToday.Name = "btnCpToday";
            this.btnCpToday.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCpToday.Size = new System.Drawing.Size(71, 28);
            this.btnCpToday.TabIndex = 121;
            this.btnCpToday.Text = "今日工作";
            this.btnCpToday.Click += new System.EventHandler(this.btnCpToday_Click);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label19.Location = new System.Drawing.Point(1100, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 69);
            this.label19.TabIndex = 122;
            this.label19.Text = "临床路径";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Visible = false;
            // 
            // btnCpOut
            // 
            this.btnCpOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCpOut.DefaultScheme = true;
            this.btnCpOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCpOut.Enabled = false;
            this.btnCpOut.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCpOut.Hint = "";
            this.btnCpOut.Location = new System.Drawing.Point(929, 34);
            this.btnCpOut.Name = "btnCpOut";
            this.btnCpOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCpOut.Size = new System.Drawing.Size(71, 28);
            this.btnCpOut.TabIndex = 124;
            this.btnCpOut.Text = "出径评估";
            this.btnCpOut.Click += new System.EventHandler(this.btnCpOut_Click);
            // 
            // btnCpVar
            // 
            this.btnCpVar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCpVar.DefaultScheme = true;
            this.btnCpVar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCpVar.Enabled = false;
            this.btnCpVar.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCpVar.Hint = "";
            this.btnCpVar.Location = new System.Drawing.Point(876, 34);
            this.btnCpVar.Name = "btnCpVar";
            this.btnCpVar.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCpVar.Size = new System.Drawing.Size(52, 28);
            this.btnCpVar.TabIndex = 123;
            this.btnCpVar.Text = "变异";
            this.btnCpVar.Click += new System.EventHandler(this.btnCpVar_Click);
            // 
            // m_imgPink
            // 
            this.m_imgPink.Image = ((System.Drawing.Image)(resources.GetObject("m_imgPink.Image")));
            this.m_imgPink.Location = new System.Drawing.Point(824, 39);
            this.m_imgPink.Name = "m_imgPink";
            this.m_imgPink.Size = new System.Drawing.Size(16, 16);
            this.m_imgPink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_imgPink.TabIndex = 119;
            this.m_imgPink.TabStop = false;
            this.m_imgPink.Visible = false;
            this.m_imgPink.Click += new System.EventHandler(this.m_imgPink_Click);
            // 
            // m_imgYellow
            // 
            this.m_imgYellow.Image = ((System.Drawing.Image)(resources.GetObject("m_imgYellow.Image")));
            this.m_imgYellow.Location = new System.Drawing.Point(822, 39);
            this.m_imgYellow.Name = "m_imgYellow";
            this.m_imgYellow.Size = new System.Drawing.Size(16, 16);
            this.m_imgYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_imgYellow.TabIndex = 118;
            this.m_imgYellow.TabStop = false;
            this.m_imgYellow.Visible = false;
            // 
            // lblCpHint
            // 
            this.lblCpHint.AutoSize = true;
            this.lblCpHint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCpHint.ForeColor = System.Drawing.Color.Crimson;
            this.lblCpHint.Location = new System.Drawing.Point(880, 62);
            this.lblCpHint.Name = "lblCpHint";
            this.lblCpHint.Size = new System.Drawing.Size(65, 12);
            this.lblCpHint.TabIndex = 125;
            this.lblCpHint.Text = "路径中...";
            this.lblCpHint.Visible = false;
            // 
            // m_txtBedNo
            // 
            this.m_txtBedNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBedNo.Location = new System.Drawing.Point(216, 7);
            this.m_txtBedNo.Name = "m_txtBedNo";
            this.m_txtBedNo.Size = new System.Drawing.Size(98, 23);
            this.m_txtBedNo.TabIndex = 2;
            this.m_txtBedNo.DoubleClick += new System.EventHandler(this.m_txtBedNo_DoubleClick);
            this.m_txtBedNo.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtBedNo2_m_evtSelectItem);
            this.m_txtBedNo.Leave += new System.EventHandler(this.m_txtBedNo_Leave);
            this.m_txtBedNo.Enter += new System.EventHandler(this.m_txtBedNo_Enter);
            this.m_txtBedNo.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtBedNo2_m_evtFindItem);
            this.m_txtBedNo.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtBedNo2_m_evtInitListView);
            // 
            // m_txtInHospitalNo
            // 
            this.m_txtInHospitalNo.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_txtInHospitalNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalNo.Location = new System.Drawing.Point(393, 7);
            this.m_txtInHospitalNo.MaxLength = 12;
            this.m_txtInHospitalNo.Name = "m_txtInHospitalNo";
            this.m_txtInHospitalNo.ReadOnly = true;
            this.m_txtInHospitalNo.Size = new System.Drawing.Size(92, 23);
            this.m_txtInHospitalNo.TabIndex = 22;
            this.m_txtInHospitalNo.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtInHospitalNo_m_evtSelectItem);
            this.m_txtInHospitalNo.Enter += new System.EventHandler(this.m_txtInHospitalNo_Enter);
            this.m_txtInHospitalNo.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtInHospitalNo_m_evtFindItem);
            this.m_txtInHospitalNo.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtInHospitalNo_m_evtInitListView);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Location = new System.Drawing.Point(42, 7);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(105, 23);
            this.m_txtArea.TabIndex = 1;
            this.m_txtArea.DoubleClick += new System.EventHandler(this.m_txtArea_DoubleClick);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            this.m_txtArea.Leave += new System.EventHandler(this.m_txtArea_Leave);
            this.m_txtArea.Enter += new System.EventHandler(this.m_txtArea_Enter);
            this.m_txtArea.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            // 
            // ctlBIHPatientInfo
            // 
            this.Controls.Add(this.m_txtAge);
            this.Controls.Add(this.lblCpHint);
            this.Controls.Add(this.btnCpVar);
            this.Controls.Add(this.btnCpIN);
            this.Controls.Add(this.btnCpOut);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCpToday);
            this.Controls.Add(this.m_imgPink);
            this.Controls.Add(this.m_imgYellow);
            this.Controls.Add(this.m_btnLIMITRATE_MNY);
            this.Controls.Add(this.m_btnAddBills);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_txtClearMoney);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.m_txtRegisterid);
            this.Controls.Add(this.m_txtREMARKNAME);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_txtUseMoney);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_txtPreMoney);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_btnBedList);
            this.Controls.Add(this.m_txtBedNo);
            this.Controls.Add(this.m_txtPrePayMoney);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_chkIsMedicareMan);
            this.Controls.Add(this.m_txtLIMITRATE_MNY);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_txtState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtInHospitalDate);
            this.Controls.Add(this.m_txtInDays);
            this.Controls.Add(this.m_txtPayType);
            this.Controls.Add(this.m_txtName);
            this.Controls.Add(this.m_txtSex);
            this.Controls.Add(this.m_txtInHospitalNo);
            this.Controls.Add(this.m_lvwBed);
            this.Controls.Add(this.m_txtArea);
            this.Controls.Add(this.m_txtDiagnose);
            this.Controls.Add(this.m_txtBedNo3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lblBackground);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ctlBIHPatientInfo";
            this.Size = new System.Drawing.Size(1023, 85);
            this.Load += new System.EventHandler(this.ctlBIHPatientInfo_Load);
            this.Resize += new System.EventHandler(this.ctlBIHPatientInfo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgPink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgYellow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 方法
        public void m_mthSetPatient(string strInHospitalNo)
        {
            m_txtInHospitalNo.Text = strInHospitalNo;
            m_mthGetPatientByInHospitalNo();
        }

        /// <summary>
        /// 获取病人信息	根据住院号
        /// </summary>
        public void m_mthGetPatientByInHospitalNo()
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            string strInHospitalNo = m_txtInHospitalNo.Text.Trim();
            clsBIHPatientInfo objPatient = null;
            int PSTATUS_INT = 0;
            long ret = m_objService.m_lngGetPatientByInHospitalNo(strInHospitalNo, out objPatient, out PSTATUS_INT);
            if (objPatient == null)
            {
                if (PSTATUS_INT == 2 || PSTATUS_INT == 3)
                {
                    MessageBox.Show("该病人已经预出院或出院，请到医嘱查询界面中进行查询!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("当前住院号不存在!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                return;
            }
            m_objPatient = objPatient;
            SetTheCurrentByPatient();
            if (m_evtPatientFromBedAdmin != null)
            {
                this.Refresh();
                m_evtPatientFromBedAdmin(this, new EventArgs());
            }
            m_mthShowPatient();
        }

        public void SetTheCurrentByPatient()
        {
            if (m_objPatient != null)
            {
                clsBIHArea objArea = new clsBIHArea();
                objArea.m_strAreaID = m_objPatient.m_strAreaID;
                objArea.m_strAreaName = m_objPatient.m_strAreaName;
                m_txtArea.Tag = objArea;
                m_txtArea.Text = objArea.m_strAreaName;



                clsBIHBed objBed = new clsBIHBed();
                objBed.m_strAreaID = objArea.m_strAreaID;
                objBed.m_strBedID = m_objPatient.m_strBedID;
                objBed.m_strBedName = m_objPatient.m_strBedName;
                m_txtBedNo.Tag = objBed;
                m_txtBedNo.Text = objBed.m_strBedName;
            }
        }

        /// <summary>
        /// 显示病人信息
        /// </summary>
        public void m_mthShowPatient()
        {
            //黄红灯设置
            m_imgYellow.Visible = false;
            m_imgPink.Visible = false;
            /*<=========================*/
            if (m_objPatient == null)
            {
                m_txtInHospitalNo.Text = "";
                m_txtName.Text = "";
                m_txtSex.Text = "";
                m_txtPayType.Text = "";
                m_txtInHospitalDate.Text = "";
                m_txtInDays.Text = "";

                //m_txtArea.Text="";
                //m_txtArea.Tag="";
                //m_txtBedNo.Text="";
                //m_txtBedNo.Tag="";
                m_txtPrePayMoney.Text = "";		//保留
                m_txtLIMITRATE_MNY.Text = "";
                m_txtDiagnose.Text = "";
                this.m_chkIsMedicareMan.Checked = false; 
                m_txtPreMoney.Text = "";
                m_txtUseMoney.Text = "";
                m_txtPrePayMoney.Text = "";
                m_txtClearMoney.Text = "";
                m_txtREMARKNAME.Text = "";
                m_txtAge.Text = "";
                m_txtArea.Tag = null;
                m_txtArea.Text = "";
                m_txtBedNo.Tag = null;
                m_txtBedNo.Text = ""; 

                this.btnCpIN.Enabled = false;
                this.btnCpToday.Enabled = false;
                this.btnCpVar.Enabled = false;
                this.btnCpOut.Enabled = false;
                this.lblCpHint.Visible = false;
            }
            else
            {
                m_txtInHospitalNo.Text = m_objPatient.m_strInHospitalNo;
                m_txtName.Text = m_objPatient.m_strPatientName;
                m_txtSex.Text = m_objPatient.m_strSex;
                m_txtPayType.Text = m_objPatient.m_strPayTypeName;
                m_txtInHospitalDate.Text = m_objPatient.m_dtInHospital.ToString("yyyy-MM-dd");
                TimeSpan ts = DateTime.Now.Date - m_objPatient.m_dtInHospital.Date;
                int day = ts.Days + 1;
                m_txtInDays.Text = clsConverter.ToString(day);
                m_txtState.Text = m_objPatient.m_strInpatientState;

                //if(m_txtArea.Tag==null)
                //{
                //    m_txtArea.Text="";
                //}
                //else
                //{
                //    m_txtArea.Text=(m_txtArea.Tag as clsBIHArea).m_strAreaName;
                //}

                //if(m_txtBedNo.Tag==null)
                //{
                //    m_txtArea.Text="";
                //}
                //else
                //{
                //    m_txtBedNo.Text=(m_txtBedNo.Tag as clsBIHBed).m_strBedName;
                //}

                m_txtArea.Text = m_objPatient.m_strAreaName;

                m_txtBedNo.Text = m_objPatient.m_strBedName; 
                m_txtPreMoney.Text = m_objPatient.m_decPreMoney.ToString("0.00");
                m_txtUseMoney.Text = m_objPatient.m_decPreUseMoney.ToString("0.00");
                m_txtPrePayMoney.Text = m_objPatient.m_decPrePayMoney.ToString("0.00");
                m_txtClearMoney.Text = Convert.ToDecimal(m_objPatient.m_decClearMoney + m_objPatient.m_decVerticalMoney).ToString("0.00");
                m_txtREMARKNAME.Text = m_objPatient.m_strREMARKNAME_VCHR + " " + m_objPatient.m_strDES_VCHR.Trim();
                /*<=======================================================*/
                m_txtLIMITRATE_MNY.Text = m_objPatient.m_dblLIMITRATE_MNY.ToString("0.00");
                m_txtDiagnose.Text = m_objPatient.m_strDiagnose;
                //m_txtAge.Text= m_objPatient.m_intAge.ToString();
                m_txtAge.Text = m_objPatient.m_strAge;
 
                //#region	诊断提示 
                //string strDiagnose =  "\n   门诊诊断："+m_objPatient.m_strMzdiagnose_vchr+"   \n";
                //strDiagnose += "\n   入院诊断（ICD10）：" + m_objPatient.m_strDiagnose+"   \n";
                //if (m_objPatient.m_strDiagnose_vchr.Length > 0)
                //{
                //    strDiagnose += "\n   入院诊断（医保）：" + m_objPatient.m_strDiagnose_vchr+"   \n";
                //}
                //else
                //{
                //    strDiagnose += "\n   入院诊断（医保）：－   \n";
                //}
                //toolTipDiagnose.SetToolTip(m_txtDiagnose, strDiagnose);
                //#endregion
                //=====================>>
                m_mthSetToolTip(m_txtDiagnose, m_objPatient);
                /*<<====================*/


                //在这里赋值是否医保病人
                try
                {
                    m_chkIsMedicareMan.Checked = new com.digitalwave.iCare.middletier.HIS.clsBIH_INS_Compute().m_IsInsPatient(m_objPatient.m_strPayTypeID.Trim());
                }
                catch //(Exception err)
                {
                    //MessageBox.Show(err.Message,"错误!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                //黄红灯设置
                decimal m_decMoney = m_objPatient.m_decPrePayMoney + m_objPatient.m_decinsuredsum_mny;
                if (m_decMoney < 0)
                {
                    m_imgYellow.Visible = false;
                    m_imgPink.Visible = true;
                }
                else if (m_decMoney > 0 && m_decMoney < decimal.Parse(m_objPatient.m_dblLIMITRATE_MNY.ToString()))
                {
                    m_imgYellow.Visible = true;
                    m_imgPink.Visible = false;
                }

                if (m_objPatient.cpstatus == 1)
                {
                    this.btnCpIN.Enabled = false;
                    this.btnCpToday.Enabled = true;
                    this.btnCpVar.Enabled = true;
                    this.btnCpOut.Enabled = true;
                    this.lblCpHint.Visible = true;
                    this.lblCpHint.Text = "路径中...";
                }
                else
                {
                    this.btnCpIN.Enabled = true;
                    this.btnCpToday.Enabled = false;
                    this.btnCpVar.Enabled = false;
                    this.btnCpOut.Enabled = false;
                    this.lblCpHint.Visible = false;
                    if (m_objPatient.cpstatus == 2)
                    {
                        this.lblCpHint.Visible = true;
                        this.lblCpHint.Text = "路径结束";
                    }
                }
            }
            if (m_evtPatientChanged != null)
            {
                this.Refresh();
                m_evtPatientChanged(this, new EventArgs());
            }
        }

        //add 2007.4.26 zhu.w.t =========================>>
        private void m_mthSetToolTip(TextBox m_txtDiagnose, clsBIHPatientInfo m_objPatient)
        {
            string strDiagnose = "\n   门诊诊断：" + m_objPatient.m_strMzdiagnose_vchr + "   \n";
            strDiagnose += "\n   入院诊断（ICD10）：" + m_objPatient.m_strDiagnose + "   \n";
            if (m_objPatient.m_strDiagnose_vchr.Length > 0)
            {
                strDiagnose += "\n   入院诊断（医保）：" + m_objPatient.m_strDiagnose_vchr + "   \n";
            }
            else
            {
                strDiagnose += "\n   入院诊断（医保）：－   \n";
            }
            toolTipDiagnose.SetToolTip(m_txtDiagnose, strDiagnose);
        }
        /*<<=================================================*/


        /// <summary>
        /// 显示病人信息
        /// </summary>
        public void m_mthClearPatient()
        {
            //黄红灯设置
            m_imgYellow.Visible = false;
            m_imgPink.Visible = false;
            /*<=========================*/

            m_txtInHospitalNo.Text = "";
            m_txtName.Text = "";
            m_txtSex.Text = "";
            m_txtPayType.Text = "";
            m_txtInHospitalDate.Text = "";
            m_txtInDays.Text = "";

            //m_txtArea.Text="";
            //m_txtArea.Tag="";
            //m_txtBedNo.Text="";
            //m_txtBedNo.Tag="";
            m_txtPrePayMoney.Text = "";		//保留
            m_txtLIMITRATE_MNY.Text = "";
            m_txtDiagnose.Text = "";
            this.m_chkIsMedicareMan.Checked = false; 
            m_txtPreMoney.Text = "";
            m_txtUseMoney.Text = "";
            m_txtPrePayMoney.Text = "";
            m_txtClearMoney.Text = "";
            m_txtREMARKNAME.Text = "";
            m_txtAge.Text = ""; 
            ((frmBIHOrderInput)this.ParentForm).m_dtvOrder.Rows.Clear();
            m_objPatient = null;

            this.btnCpIN.Enabled = false;
            this.btnCpToday.Enabled = false;
            this.btnCpVar.Enabled = false;
            this.btnCpOut.Enabled = false;
            this.lblCpHint.Visible = false;
        }

        /// <summary>
        /// 获取病人信息	根据病区 病床
        /// </summary>
        public void m_mthGetPatientByAreaBed()
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            if ((m_txtArea.Tag == null) || (m_txtBedNo.Tag == null)) return;
            if (!(m_txtArea.Tag is clsBIHArea)) return;
            if (!(m_txtBedNo.Tag is clsBIHBed)) return;
            string strAreaID = (m_txtArea.Tag as clsBIHArea).m_strAreaID;
            string strBedID = (m_txtBedNo.Tag as clsBIHBed).m_strBedID;
            clsBIHPatientInfo objPatient;
            long ret = m_objService.m_lngGetPatientByAreaBed(strAreaID, strBedID, out objPatient);
            if ((ret > 0) && (objPatient != null))
            {
                m_objPatient = objPatient;

            }
            else
            {
                m_objPatient = null;
            }
            m_mthShowPatient();
        }

        /// <summary>
        /// 获取病人信息	根据病人ID
        /// </summary>
        public void m_mthGetPatientByPATIENTID(string PATIENTID_CHR)
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            clsBIHPatientInfo objPatient;
            long ret = m_objService.m_lngGetPatientByPATIENTID(PATIENTID_CHR, out objPatient);
            if ((ret > 0) && (objPatient != null))
            {
                m_objPatient = objPatient;
            }
            else
            {
                m_objPatient = null;
            }
            m_mthShowPatient();
            m_evtPatientFromBedAdmin(this, new EventArgs());
        }

        public void m_mthToInputHospitalNo()
        {
            m_txtInHospitalNo.Focus();
            m_txtInHospitalNo.SelectAll();
        }

        private decimal m_dmlGetMoney(string strRegisterID)
        {
            try
            {
                if (m_objChargeSve == null)
                {
                    m_objChargeSve = new clsDcl_GetSvcObject().m_GetBIHChargeSvc();
                }
                double dmlMoney = 0;
                long ret = m_objChargeSve.m_lngGetBalanceMoneyByRegisterID(strRegisterID, out dmlMoney);
                return (decimal)dmlMoney;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void m_mthSetArea(string strAreaID)
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            clsBIHArea objArea;
            long ret = m_objService.m_lngGetAreaByID(strAreaID, out objArea);
            if (objArea == null)
            {
                m_txtArea.Text = "";
                m_txtArea.Tag = null;
            }
            else
            {
                m_txtArea.Text = objArea.m_strAreaName;
                m_txtArea.Tag = objArea;
            }

        }
        #endregion
        #region 床号
        private void m_txtBedNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            if (e.KeyCode == Keys.Enter)
            {
                if (m_txtArea.Tag == null)
                {
                    if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strAreaID = (m_txtArea.Tag as clsBIHArea).m_strAreaID;
                clsBIHBed[] arrBed;
                string strBedNo = m_txtBedNo.Text.Trim();
                long ret = m_objService.m_lngGetBedByArea(strAreaID, strBedNo, out arrBed);
                if ((ret > 0) && (arrBed != null))
                {
                    if (arrBed.Length == 1)
                    {
                        m_txtBedNo.Text = arrBed[0].m_strBedName;
                        m_txtBedNo.Tag = arrBed[0];
                        m_mthGetPatientByAreaBed();
                    }
                    else
                    {
                        m_lvwBed.Items.Clear();
                        for (int i = 0; i < arrBed.Length; i++)
                        { 
                            ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);
                            objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                            objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex);
                            m_lvwBed.Items.Add(objItem); 
                            objItem.Tag = arrBed[i];
                        }
                        if (m_lvwBed.Items.Count > 0)
                        {
                            m_lvwBed.Items[0].Selected = true;
                            m_lvwBed.Items[0].Focused = true;
                        }
                        m_mthShowBedList();
                    }
                }
                else
                {
                }
            }
        }
        private void m_mthInitListView()
        {
            m_lvwBed.Visible = false;
            this.Controls.Remove(m_lvwBed);
            this.ParentForm.Controls.Add(m_lvwBed);

        }

        private void m_mthShowBedList()
        {
            Point ps = new Point(m_txtBedNo.Location.X, m_txtBedNo.Location.Y + m_txtBedNo.Height);
            ps = this.PointToScreen(ps);
            ps = this.ParentForm.PointToClient(ps);
            m_lvwBed.Location = ps;
            m_lvwBed.Visible = true;
            m_lvwBed.BringToFront();
            m_lvwBed.Focus();
        }
        private void m_lvwBed_DoubleClick(object sender, System.EventArgs e)
        {
            if (m_lvwBed.SelectedItems.Count > 0)
            {
                ListViewItem objItem = m_lvwBed.SelectedItems[0];
                m_txtBedNo.Text = objItem.Text;
                m_txtBedNo.Tag = objItem.Tag;
            }
            m_lvwBed.Items.Clear();
            m_lvwBed.Visible = false;
            m_mthGetPatientByAreaBed();
        }
        private void m_lvwBed_Leave(object sender, System.EventArgs e)
        {
            m_lvwBed.Visible = false;
        }
        private void m_lvwBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_lvwBed_DoubleClick(sender, e);
            }
        }
        #endregion

        #region 病区
        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            clsBIHArea[] arrArea;
            long ret = m_objService.m_lngFindArea(strFindCode, out arrArea);
            if ((ret > 0) && (arrArea != null))
            {
                //获取有权限访问的病区ID集合
                if (m_objLoginInfo != null)
                {
                    IList ilUsableAreaID = m_objLoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    arrArea = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(arrArea, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < arrArea.Length; i++)
                {
                    /** @update by xzf (05-09-20)
                     * 
                     */
                    ListViewItem lvi = lvwList.Items.Add(arrArea[i].code);
                    lvi.SubItems.Add(arrArea[i].m_strAreaName);
                    /* <<================================== */
                    lvi.Tag = arrArea[i];
                }
            }
        }

        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            //@lvwList.Columns.Add("",120,HorizontalAlignment.Left);
            //@lvwList.Width=140;
            /** update by xzf (05-09-20) */
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 100, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 180;
            /* <<================================= */
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_txtArea.Tag = lviSelected.Tag;
                m_txtBedNo.Focus();
            }
        }
        #endregion
        #region 住院号
        private void m_txtInHospitalNo_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            //clsT_Opr_Bih_Register_VO[] objItemArr;
            //long ret=new clsDcl_SearchOrderInfo().m_lngFindHospitalNo(strFindCode,out objItemArr);
            //if((ret>0) && (objItemArr!=null))
            //{
            //    //获取有权限访问的病区ID集合
            //    if(m_objLoginInfo!=null)
            //    {
            //        IList ilUsableAreaID = m_objLoginInfo.m_ilUsableAreaID;
            //        clsDcl_InputOrder objInputOrder =new clsDcl_InputOrder();
            //        objItemArr =(clsT_Opr_Bih_Register_VO[])(objInputOrder.GetUsableRegisterObject(objItemArr,ilUsableAreaID)).ToArray(typeof(clsT_Opr_Bih_Register_VO));
            //    }
            //    for(int i=0;i<objItemArr.Length;i++)
            //    {
            //        ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strINPATIENTID_CHR);
            //    }
            //}
            m_mthGetPatientByInHospitalNo();
        }

        private void m_txtInHospitalNo_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("", 100, HorizontalAlignment.Left);
            lvwList.Width = 120;
        }

        private void m_txtInHospitalNo_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            //if(lviSelected!=null)
            //{
            //    m_txtInHospitalNo.Text=lviSelected.Text;
            //    m_mthGetPatientByInHospitalNo();
            //}
        }
        #endregion

        #region 事件
        private void ctlBIHPatientInfo_Load(object sender, System.EventArgs e)
        {
            m_mthInitListView();
            if (m_blInputEnable == false)
            {
                m_objHighlight.m_mthBindControls(new System.Windows.Forms.Control[] { m_txtInHospitalNo, m_txtArea, m_txtBedNo });

                m_btnBedList.Enabled = false;
                m_btnLIMITRATE_MNY.Enabled = false;
                this.m_txtArea.Enabled = false;
                this.m_txtArea.BackColor = Color.White;
                this.m_txtBedNo.Enabled = false;
                this.m_txtBedNo.BackColor = Color.White;
                this.m_txtInHospitalNo.Enabled = false;
                this.m_txtInHospitalNo.BackColor = Color.White;
                m_btnBedList.Enabled = false;
            }

            // cp
            string fileName = Application.StartupPath + "\\cpitf.exe";
            if (System.IO.File.Exists(fileName))
            {
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                CpIcdDataSource = svc.GetCpIcd10(false);
                svc = null;
            }
            else
            {
                CpIcdDataSource = new DataTable();
            }
        }

        private void ctlBIHPatientInfo_Resize(object sender, System.EventArgs e)
        {
            m_lblBackground.Location = new Point(0, 0);
            m_lblBackground.Size = new Size(this.Width - 1, this.Height - 1);
        }

        private void m_txtPrePayMoney_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        /** @add by xzf (05-09-20) */
        private void m_chkIsMedicareMan_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_chkIsMedicareMan.Checked)
            {
                m_chkIsMedicareMan.BackColor = SystemColors.Desktop;
            }
            else
            {
                m_chkIsMedicareMan.BackColor = SystemColors.Control;
            }
        }
        #region 属性
        /// <summary>
        /// 获取登陆信息
        /// </summary>
        public com.digitalwave.iCare.ValueObject.clsLoginInfo LoginInfo
        {
            set { m_objLoginInfo = value; }
        }
        #endregion

        private void m_txtBedNo2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            for (int i1 = 0; i1 < ((frmBIHOrderInput)this.ParentForm).m_dtvOrder.RowCount; i1++)
            {
                if (((frmBIHOrderInput)this.ParentForm).m_dtvOrder.Rows[i1].Tag == null)
                {
                    continue;
                }
                clsBIHOrder order1 = (clsBIHOrder)((frmBIHOrderInput)this.ParentForm).m_dtvOrder.Rows[i1].Tag;
                if (order1.m_intStatus == 0 && order1.m_strCreatorID.Trim().Equals(((frmBIHOrderInput)this.ParentForm).LoginInfo.m_strEmpID))
                {
                    if (MessageBox.Show("当前有未提交的医嘱,确实要更改当前病人吗？", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {

                        if (m_txtBedNo.Tag != null)
                        {
                            m_txtBedNo.Text = ((clsBIHBed)this.m_txtBedNo.Tag).m_strBedName;
                        }
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //this.m_txtBedNo.Tag = null;
            //clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            /*<----------------------------------------*/

            if (m_txtArea.Tag == null)
            {
                if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtArea.Text = "";
                m_txtArea.Tag = null;
                m_txtArea.Focus();
                return;
            }
            string strAreaID = (m_txtArea.Tag as clsBIHArea).m_strAreaID;
            clsBIHBed[] arrBed;
            string strBedNo = m_txtBedNo.Text.Trim();
            long ret = m_objService.m_lngGetBedByArea(strAreaID, strBedNo, out arrBed);
            if ((ret > 0) && (arrBed != null))
            {
                if (arrBed.Length == 0)
                {
                    MessageBox.Show("当前科室没有床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //m_txtArea.Text = "";
                    //m_txtArea.Tag = null;
                    //m_txtArea.Focus();
                    m_txtBedNo.Focus();
                    return;
                }
                for (int i = 0; i < arrBed.Length; i++)
                { 
                    ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex); 
                    objItem.Tag = arrBed[i];
                    lvwList.Items.Add(objItem);

                }

            }


        }

        private void m_txtBedNo2_m_evtInitListView(ListView lvwList)
        {
            //@lvwList.Columns.Add("",120,HorizontalAlignment.Left);
            //@lvwList.Width=140;
            /** update by xzf (05-09-20) */
            lvwList.Columns.Add("床　号", 40, HorizontalAlignment.Left);
            lvwList.Columns.Add("姓　名", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("性　别", 40, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 180;
            /* <<================================= */
        }

        private void m_txtBedNo2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {

            if (lviSelected != null)
            {
                m_txtBedNo.Text = lviSelected.SubItems[0].Text.Trim();
                m_txtBedNo.Tag = lviSelected.Tag;
                //m_mthGetPatientByAreaBed();
                string m_strRegisterID = (lviSelected.Tag as clsBIHBed).m_objPatient.m_strRegisterID;

                if (((frmBIHOrderInput)this.ParentForm).m_intParm1068 != 0)
                {
                    ////////录医嘱前判断病人在门诊是否用未交费用的处方，给出提示
                    string strMessage = "";
                    com.digitalwave.iCare.gui.HIS.clsPublic.m_lngSelectPatientNoPayRecipe(m_strRegisterID, out strMessage);
                    if (!string.IsNullOrEmpty(strMessage))
                    {
                        if (MessageBox.Show("是否允许录入医嘱" + strMessage, "病人门诊费用未清!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    ///////////
                }
                m_mthGetPatientByRegisterID(m_strRegisterID);
            }

        }

        /// <summary>
        /// 获取病人信息	根据病人流水登记号
        /// </summary>
        /// <param name="m_strRegisterID">病人流水登记号</param>
        internal void m_mthGetPatientByRegisterID(string m_strRegisterID)
        { 
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject(); 
            clsBIHPatientInfo objPatient;
            long ret = m_objService.m_lngGetPatientByInRegisterID(m_strRegisterID, out objPatient);
            if ((ret > 0) && (objPatient != null))
            {
                m_objPatient = objPatient;

            }
            else
            {
                m_objPatient = null;
            }
            m_mthShowPatient();
        }

        private void m_btnBedList_Click(object sender, EventArgs e)
        {
            m_txtBedNo.Focus();
            m_txtBedNo_DoubleClick(null, null);

        }



        private void m_txtBedNo_DoubleClick(object sender, EventArgs e)
        {
            m_txtBedNo.Text = "";
            SendKeys.Send("{ENTER}");
        }

        private void m_txtArea_DoubleClick(object sender, EventArgs e)
        {
            m_txtArea.Text = "";
            SendKeys.Send("{ENTER}");
            //m_txtArea.Text = m_strOld;

        }

        private void m_txtInHospitalNo_Enter(object sender, EventArgs e)
        {
            //SetFocus();
        }

        private void SetFocus()
        {
            m_txtLIMITRATE_MNY.Focus();
        }

        private void m_txtName_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtSex_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtPreMoney_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtUseMoney_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtClearMoney_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtPrePayMoney_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtInHospitalDate_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtState_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtInDays_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtPayType_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void m_txtREMARKNAME_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }

        internal void m_btnAddBills_Click(object sender, EventArgs e)
        {
            //if (m_objPatient != null)
            //{
            //    decimal m_decPreMoney, m_decPreUseMoney, m_decClearMoney, m_decVerticalMoney, m_decPrePayMoney;

            //    if (m_blInputEnable == false)
            //    {
            //      long ret=0;
            //      clsBIHOrderService m_objService = clsGenerator.CreateObject(typeof(clsBIHOrderService)) as clsBIHOrderService;
            //      ret = m_objService.m_lngGetPatientChargeMessage(m_objPatient.m_strRegisterID, out  m_decPreMoney, out  m_decPreUseMoney, out  m_decClearMoney, out  m_decVerticalMoney, out  m_decPrePayMoney);
            //      if (ret > 0)
            //      {
            //          m_objPatient.m_decPreMoney = m_decPreMoney;
            //          m_objPatient.m_decPreUseMoney = m_decPreUseMoney;
            //          m_objPatient.m_decClearMoney = m_decClearMoney;
            //          m_objPatient.m_decVerticalMoney = m_decVerticalMoney;
            //          m_objPatient.m_decPrePayMoney = m_decPrePayMoney;
            //      }

            //    }
            //     m_decPreMoney = decimal.Parse(m_objPatient.m_decPreMoney.ToString("0.00"));
            //     m_decPreUseMoney = decimal.Parse(m_objPatient.m_decPreUseMoney.ToString("0.00"));
            //     m_decClearMoney = decimal.Parse(Convert.ToDecimal(m_objPatient.m_decClearMoney + m_objPatient.m_decVerticalMoney).ToString("0.00"));
            //     m_decPrePayMoney = decimal.Parse(m_objPatient.m_decPrePayMoney.ToString("0.00"));

            //    frmSelectBox selectBox = new frmSelectBox(m_decPreMoney,m_decPreUseMoney,m_decClearMoney,m_decPrePayMoney,m_txtREMARKNAME.Text.Trim(), 2);
            //    selectBox.ShowDialog();

            //}
            if (m_objPatient != null)
            {
                frmPatientChargeView m_frmPatientView = new frmPatientChargeView(m_objPatient.m_strRegisterID);
                m_frmPatientView.ShowDialog();
            }
        }

        private void m_btnLIMITRATE_MNY_Click(object sender, EventArgs e)
        {
            if (m_objPatient != null)
            {

                frmSelectBox selectBox = new frmSelectBox(m_objPatient.m_dblLIMITRATE_MNY, 3);
                if (selectBox.ShowDialog() == DialogResult.Yes)
                {
                    //修改费用下限
                    //clsBIHORDERCHARGEDService m_objManager = clsGenerator.CreateObject(typeof(clsBIHORDERCHARGEDService)) as clsBIHORDERCHARGEDService;
                    clsBIHORDERCHARGEDService m_objManager = new clsDcl_GetSvcObject().m_GetBIHORDERCHARGEDSvc();

                    m_objPatient.m_dblLIMITRATE_MNY = selectBox.m_dblLIMITRATE_MNY;
                    long reg = m_objManager.m_lngUpdateLIMITRATE(m_objPatient);
                    if (reg > 0)
                    {
                        MessageBox.Show("更改成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_mthShowPatient();
                    }

                }

            }
        }

        private void m_txtAge_Enter(object sender, EventArgs e)
        {
            SetFocus();
        }



        private void m_txtArea_Enter(object sender, EventArgs e)
        {
            if (m_blInputEnable == false)
            {
                SetFocus();
            }
        }

        private void m_txtBedNo_Enter(object sender, EventArgs e)
        {
            if (m_blInputEnable == false)
            {
                SetFocus();
            }
        }

        //delect 2007.4.26 zhu.w.t
        //private void m_txtDiagnose_Enter(object sender, EventArgs e)
        //{

        //        SetFocus();

        //}

        private void m_txtBedNo_Leave(object sender, EventArgs e)
        {
            if (m_txtBedNo.Tag is clsBIHBed)
            {
                m_txtBedNo.Text = ((clsBIHBed)this.m_txtBedNo.Tag).m_strBedName;
            }
            //if (m_txtBedNo.Text.Trim().Equals("")||m_txtBedNo.Tag==null)
            //{
            //    m_mthClearPatient();

            //}

        }

        private void m_txtArea_Leave(object sender, EventArgs e)
        {
            if (m_txtArea.Tag is clsBIHArea)
            {
                m_txtArea.Text = ((clsBIHArea)this.m_txtArea.Tag).m_strAreaName;
                string m_strAreaID = ((clsBIHArea)this.m_txtArea.Tag).m_strAreaID;
                if (m_txtBedNo.Tag is clsBIHBed)
                {
                    if (!m_strAreaID.Equals(((clsBIHBed)this.m_txtBedNo.Tag).m_strAreaID))//说明病区改变了，就刷新当前界面
                    {
                        m_mthClearPatient();
                        m_txtBedNo.Tag = null;
                        m_txtBedNo.Text = "";
                    }
                }
            }

        }

        private void label7_DoubleClick(object sender, EventArgs e)
        {
            this.m_txtInHospitalNo.ReadOnly = false;
        }

        //add 2007.4.26 zhu.w.t =======================>>
        private void m_txtDiagnose_Leave(object sender, EventArgs e)
        {

            if (m_objPatient == null) return;

            string strDiagnose = m_txtDiagnose.Text.Trim();

            if (!m_objPatient.m_strDiagnose.Equals(strDiagnose))
            {
                if (MessageBox.Show("当前病人入院诊断已经改变，是否保存？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                    string strRegisterID = m_objPatient.m_strRegisterID;
                    long ret = m_objService.m_lngChangePatientDiagnoseByRegisterID(strRegisterID, strDiagnose);
                    m_objPatient.m_strDiagnose = m_txtDiagnose.Text.Trim();
                    m_mthSetToolTip(m_txtDiagnose, m_objPatient);
                    MessageBox.Show("入院诊断更改成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m_txtDiagnose.Text = m_objPatient.m_strDiagnose;
                }
            }
        }

        private void m_txtDiagnose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetFocus();
            }
        }

        private void m_imgPink_Click(object sender, EventArgs e)
        {

        }

        #region 临床路径

        #region CP

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern int SendMessage(
        int hWnd,  //  handle  to  destination  window  
        int Msg,  //  message  
        int wParam,  //  first  message  parameter  
        ref  COPYDATASTRUCT lParam  //  second  message  parameter  
        );
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        static extern int FindWindow(string lpClassName, string lpWindowName);

        void SendMessage(string funcCode)
        {
            int WINDOW_HANDLER = FindWindow(null, "临床路径管理系统");
            if (WINDOW_HANDLER == 0)
            {
                if (funcCode == "start")
                    MessageBox.Show("临床路径管理系统。");
            }
            else
            {
                funcCode = this.Text + "-->" + funcCode;
                byte[] sarr = System.Text.Encoding.Default.GetBytes(funcCode);
                int len = sarr.Length;

                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = funcCode;
                cds.cbData = len + 1;
                SendMessage(WINDOW_HANDLER, 0x004A, 0, ref  cds);
            }
        }

        #endregion

        #region DefWndProc

        /// <summary>
        /// WM_COPYDATA
        /// </summary>
        const int WM_COPYDATA = 0x004A;

        /// <summary>
        /// DefWndProc
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case 0x004A:    // 处理消息    
                    {
                        COPYDATASTRUCT funcCode = new COPYDATASTRUCT();
                        Type mytype = funcCode.GetType();
                        funcCode = (COPYDATASTRUCT)m.GetLParam(mytype);
                        if (funcCode.lpData == "focus")
                        {
                            this.Focus();
                        }
                    }
                    break;
                default:
                    base.DefWndProc(ref m); // 调用基类函数处理非自定义消息。 
                    break;
            }
        }
        #endregion

        private void btnCpIN_Click(object sender, EventArgs e)
        {
            frmCpIn frm = new frmCpIn(m_objPatient);
            frm.CpIcdDataSource = this.CpIcdDataSource;
            frm.ShowDialog();
            if (frm.IsSuccess)
            {
                this.btnCpIN.Enabled = false;
                this.btnCpToday.Enabled = true;
                this.btnCpVar.Enabled = true;
                this.btnCpOut.Enabled = true;
                this.lblCpHint.Visible = true;
            }
        }

        private void btnCpToday_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + @"\cpitf.exe ";
            if (System.IO.File.Exists(file))
            {
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                DataTable dtExecPlan = svc.GetCpExecPlan(this.m_objPatient.m_strRegisterID);
                if (dtExecPlan != null && dtExecPlan.Rows.Count > 0)
                {
                    System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                    Info.FileName = file;
                    Info.Arguments = dtExecPlan.Rows[0]["cpid"].ToString();
                    System.Diagnostics.Process.Start(Info);
                }
            }
            return;

            //clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            //DataTable dtExecPlan = svc.GetCpExecPlan(this.m_objPatient.m_strRegisterID);
            //if (dtExecPlan != null && dtExecPlan.Rows.Count > 0)
            //{
            //    file = Application.StartupPath + "\\cp.api.dll";
            //    if (System.IO.File.Exists(file))
            //    {
            //        Assembly objAsm = Assembly.LoadFrom(file);
            //        object objIns = objAsm.CreateInstance("Cp.Function", true);
            //        MethodInfo objMth = objIns.GetType().GetMethod("CpMaintain");
            //        object[] param = new object[1];
            //        param[0] = Convert.ToInt32(dtExecPlan.Rows[0]["cpid"].ToString());
            //        object r = objMth.Invoke(objIns, param);
            //    }
            //}
        }

        private void btnCpVar_Click(object sender, EventArgs e)
        {
            frmCpVar frm = new frmCpVar(m_objPatient);
            frm.ShowDialog();
            if (frm.IsStopCp)
            {
                this.btnCpIN.Enabled = true;
                this.btnCpToday.Enabled = false;
                this.btnCpVar.Enabled = false;
                this.btnCpOut.Enabled = false;
                this.lblCpHint.Text = "结束路径";
                this.lblCpHint.Visible = true;
            }
        }

        private void btnCpOut_Click(object sender, EventArgs e)
        {
            frmCpOut frm = new frmCpOut(m_objPatient);
            frm.ShowDialog();
            if (frm.IsSuccess)
            {
                this.btnCpIN.Enabled = true;
                this.btnCpToday.Enabled = false;
                this.btnCpVar.Enabled = false;
                this.btnCpOut.Enabled = false;
                this.lblCpHint.Text = "结束路径";
                this.lblCpHint.Visible = true;
            }
        }

        #endregion


        /*<<==========================================*/

    }
}
