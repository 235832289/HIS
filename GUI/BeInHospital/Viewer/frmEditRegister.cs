using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Xml;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 入院登记资料修改 -- 界面
    /// </summary>
    public class frmEditRegister : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        #region 全局变量
        /// <summary>
        /// 新病人入院登记ID (床位管理调出入院登记时用到)
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// 用于协助下拉框的显示
        /// </summary>
        Timer m_timer;
        /// <summary>
        /// 用于初始化数据
        /// </summary>
        Timer m_initTimer;
        /// <summary>
        /// 用于协助下拉框的显示
        /// </summary>
        ComboBox m_comBox;
        #endregion

        internal string m_strOpentParm = "0";

        #region 控件申明

        private System.Windows.Forms.Label label34;
        internal System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        internal System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.Label label37;
        internal System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        internal System.Windows.Forms.ComboBox txtNationality;
        internal System.Windows.Forms.TextBox txtHomepc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtContactpersonpc;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtContactpersonAddress;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.TextBox txtContactpersonPhone;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txtContactpersonFirstaName;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.TextBox txtOfficeAddress;
        internal System.Windows.Forms.TextBox txtEmployer;
        internal System.Windows.Forms.TextBox txtOfficepc;
        internal System.Windows.Forms.TextBox txtOfficephone;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        internal System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lbAddress;
        internal System.Windows.Forms.ComboBox cobMarried;
        internal System.Windows.Forms.ComboBox cboIsemployee;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        internal System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        internal System.Windows.Forms.TextBox txtPATIENTCARDID;
        private System.Windows.Forms.GroupBox groupBox3;
        internal PinkieControls.ButtonXP cmdEmpty;
        internal PinkieControls.ButtonXP cmdSaveBihRegister;
        internal System.Windows.Forms.ComboBox m_cboTYPE_INT;
        internal System.Windows.Forms.ComboBox m_cboSTATE_INT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP cmdClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label m_lblPStatusName;
        private PinkieControls.ButtonXP cmdRefurbish;
        internal System.Windows.Forms.TextBox m_txtCareInfo;
        internal System.Windows.Forms.TextBox m_txtFoodInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label39;
        internal System.Windows.Forms.TextBox m_lblOperatorName;
        internal System.Windows.Forms.TextBox m_txtLIMITRATE_MNY;
        private System.Windows.Forms.Label label25;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.ComboBox m_cboInpatientNoType;
        private System.Windows.Forms.Label label49;
        internal System.Windows.Forms.TextBox txtOperatorid;
        internal System.Windows.Forms.TextBox txtModifydate;
        private System.Windows.Forms.Label label46;
        internal System.Windows.Forms.TextBox txtDeactivateDate;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        internal GroupBox groupBox2;
        internal GroupBox groupBox5;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox m_txtRemark;
        private System.Windows.Forms.Label label52;
        internal System.Windows.Forms.DateTimePicker m_dateInHosp;
        internal PinkieControls.ButtonXP m_cmdFindPatient;
        internal ControlLibrary.txtListView m_txtMaindoctor;
        internal ControlLibrary.txtListView m_txtAREAID;
        private Label label65;
        private Label label62;
        private Label label69;
        private Label label71;
        private Label label70;
        private Label label72;
        private Label label12;
        internal TextBox m_txtinsuranceid;
        internal TextBox m_txtFindText;
        private GroupBox groupBox1;
        internal ComboBox m_cmbFindType;
        private Label label53;
        private Label label51;
        private Label label50;
        private Label label56;
        private Label label55;
        private Label label54;
        private Label label57;
        private Label label61;
        internal TextBox m_txtGOVCARD_CHR;
        internal TextBox m_txtAge;
        internal ControlLibrary.txtListView m_txtRace;
        internal ControlLibrary.txtListView m_txtPaytype;
        internal ControlLibrary.txtListView m_txtOccupation;
        internal ControlLibrary.txtListView m_txtRelation;
        internal NullableDateControls.MaskDateEdit m_dtpBirthDate;
        private Label label6;
        private Label label18;
        internal TextBox m_txtBedCode;
        private Label label10;
        internal TextBox m_txtInPatienID;
        internal TextBox m_txtInsuredPayScale;
        private Label label63;
        internal TextBox m_txtInsuredPayTime;
        private Label label60;
        internal TextBox m_txtInsuredPayMoney;
        private Label label59;
        internal TextBox m_txtInsuredTotalMoney;
        private Label label58;
        internal TextBox m_txttNativeplace;
        private Label label74;
        private Label label68;
        private Label label67;
        internal TextBox txtResidenceplace;
        internal TextBox txtBirthPlace;
        private Label label78;
        internal ComboBox m_cboPatientSource;
        private Label label77;
        internal PinkieControls.ButtonXP btnYBReg;
        internal PinkieControls.ButtonXP btnReadIDCard;
        private Label label64;
        internal TextBox txtConsigneeAddr;
        private Label label66;
        private Label label73;
        internal TextBox m_txtMZDiagnose;

        #endregion

        #region 构造函数
        public frmEditRegister()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            m_timer = new Timer();
            m_timer.Interval = 100;
            m_timer.Tick += new EventHandler(m_timer_Tick);
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //			
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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditRegister));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmbFindType = new System.Windows.Forms.ComboBox();
            this.m_cmdFindPatient = new PinkieControls.ButtonXP();
            this.m_txtFindText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReadIDCard = new PinkieControls.ButtonXP();
            this.btnYBReg = new PinkieControls.ButtonXP();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdEmpty = new PinkieControls.ButtonXP();
            this.cmdSaveBihRegister = new PinkieControls.ButtonXP();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.m_lblPStatusName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label73 = new System.Windows.Forms.Label();
            this.txtConsigneeAddr = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.m_cboPatientSource = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.txtResidenceplace = new System.Windows.Forms.TextBox();
            this.txtBirthPlace = new System.Windows.Forms.TextBox();
            this.m_txttNativeplace = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.m_txtInsuredPayScale = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.m_txtInsuredPayTime = new System.Windows.Forms.TextBox();
            this.m_txtInsuredPayMoney = new System.Windows.Forms.TextBox();
            this.m_txtInsuredTotalMoney = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.m_dtpBirthDate = new NullableDateControls.MaskDateEdit();
            this.m_txtRelation = new ControlLibrary.txtListView(this.components);
            this.m_txtOccupation = new ControlLibrary.txtListView(this.components);
            this.m_txtPaytype = new ControlLibrary.txtListView(this.components);
            this.m_txtRace = new ControlLibrary.txtListView(this.components);
            this.m_txtAge = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.m_txtGOVCARD_CHR = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.m_txtinsuranceid = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.ComboBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtPATIENTCARDID = new System.Windows.Forms.TextBox();
            this.m_cboInpatientNoType = new System.Windows.Forms.ComboBox();
            this.cobMarried = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtOfficepc = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.txtHomepc = new System.Windows.Forms.TextBox();
            this.txtContactpersonFirstaName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtOfficeAddress = new System.Windows.Forms.TextBox();
            this.txtContactpersonAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtContactpersonPhone = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtContactpersonpc = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboIsemployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblOperatorName = new System.Windows.Forms.TextBox();
            this.m_txtFoodInfo = new System.Windows.Forms.TextBox();
            this.m_txtCareInfo = new System.Windows.Forms.TextBox();
            this.txtDeactivateDate = new System.Windows.Forms.TextBox();
            this.txtOperatorid = new System.Windows.Forms.TextBox();
            this.txtModifydate = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtBedCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtInPatienID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtMZDiagnose = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.m_txtAREAID = new ControlLibrary.txtListView(this.components);
            this.m_txtMaindoctor = new ControlLibrary.txtListView(this.components);
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_dateInHosp = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.m_cboSTATE_INT = new System.Windows.Forms.ComboBox();
            this.m_cboTYPE_INT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.m_txtLIMITRATE_MNY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOfficephone = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmbFindType);
            this.groupBox1.Controls.Add(this.m_cmdFindPatient);
            this.groupBox1.Controls.Add(this.m_txtFindText);
            this.groupBox1.Location = new System.Drawing.Point(649, 548);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询病人";
            // 
            // m_cmbFindType
            // 
            this.m_cmbFindType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFindType.FormattingEnabled = true;
            this.m_cmbFindType.Items.AddRange(new object[] {
            "1-诊疗卡号",
            "2-住院号",
            "3-社保卡号"});
            this.m_cmbFindType.Location = new System.Drawing.Point(13, 23);
            this.m_cmbFindType.Name = "m_cmbFindType";
            this.m_cmbFindType.Size = new System.Drawing.Size(101, 22);
            this.m_cmbFindType.TabIndex = 288;
            // 
            // m_cmdFindPatient
            // 
            this.m_cmdFindPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdFindPatient.DefaultScheme = true;
            this.m_cmdFindPatient.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFindPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFindPatient.Hint = "";
            this.m_cmdFindPatient.Location = new System.Drawing.Point(238, 16);
            this.m_cmdFindPatient.Name = "m_cmdFindPatient";
            this.m_cmdFindPatient.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFindPatient.Size = new System.Drawing.Size(106, 33);
            this.m_cmdFindPatient.TabIndex = 66;
            this.m_cmdFindPatient.Text = "查找病人...";
            this.m_cmdFindPatient.Click += new System.EventHandler(this.m_cmdFindPatient_Click);
            // 
            // m_txtFindText
            // 
            this.m_txtFindText.Location = new System.Drawing.Point(120, 22);
            this.m_txtFindText.Name = "m_txtFindText";
            this.m_txtFindText.Size = new System.Drawing.Size(103, 23);
            this.m_txtFindText.TabIndex = 0;
            this.m_txtFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindText_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReadIDCard);
            this.groupBox3.Controls.Add(this.btnYBReg);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cmdEmpty);
            this.groupBox3.Controls.Add(this.cmdSaveBihRegister);
            this.groupBox3.Controls.Add(this.cmdClose);
            this.groupBox3.Controls.Add(this.cmdRefurbish);
            this.groupBox3.Controls.Add(this.m_lblPStatusName);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(9, 544);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(628, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "功能区域";
            // 
            // btnReadIDCard
            // 
            this.btnReadIDCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnReadIDCard.DefaultScheme = true;
            this.btnReadIDCard.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReadIDCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadIDCard.Hint = "";
            this.btnReadIDCard.Location = new System.Drawing.Point(448, 14);
            this.btnReadIDCard.Name = "btnReadIDCard";
            this.btnReadIDCard.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReadIDCard.Size = new System.Drawing.Size(92, 40);
            this.btnReadIDCard.TabIndex = 69;
            this.btnReadIDCard.Text = "读身份证 &R";
            this.btnReadIDCard.Click += new System.EventHandler(this.btnReadIDCard_Click);
            // 
            // btnYBReg
            // 
            this.btnYBReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnYBReg.DefaultScheme = true;
            this.btnYBReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnYBReg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBReg.Hint = "";
            this.btnYBReg.Location = new System.Drawing.Point(154, 14);
            this.btnYBReg.Name = "btnYBReg";
            this.btnYBReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnYBReg.Size = new System.Drawing.Size(74, 40);
            this.btnYBReg.TabIndex = 68;
            this.btnYBReg.Text = "医保修改";
            this.btnYBReg.Click += new System.EventHandler(this.btnYBReg_Click);
            // 
            // label15
            // 
            this.label15.AllowDrop = true;
            this.label15.Location = new System.Drawing.Point(8, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 16);
            this.label15.TabIndex = 15;
            this.label15.Text = "状态：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdEmpty
            // 
            this.cmdEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdEmpty.DefaultScheme = true;
            this.cmdEmpty.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdEmpty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdEmpty.Hint = "";
            this.cmdEmpty.Location = new System.Drawing.Point(374, 14);
            this.cmdEmpty.Name = "cmdEmpty";
            this.cmdEmpty.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdEmpty.Size = new System.Drawing.Size(74, 40);
            this.cmdEmpty.TabIndex = 63;
            this.cmdEmpty.Text = "清屏(F6)";
            this.cmdEmpty.Click += new System.EventHandler(this.cmdEmpty_Click);
            // 
            // cmdSaveBihRegister
            // 
            this.cmdSaveBihRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdSaveBihRegister.DefaultScheme = true;
            this.cmdSaveBihRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSaveBihRegister.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdSaveBihRegister.Hint = "";
            this.cmdSaveBihRegister.Location = new System.Drawing.Point(228, 14);
            this.cmdSaveBihRegister.Name = "cmdSaveBihRegister";
            this.cmdSaveBihRegister.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSaveBihRegister.Size = new System.Drawing.Size(74, 40);
            this.cmdSaveBihRegister.TabIndex = 60;
            this.cmdSaveBihRegister.Text = "保存(F2)";
            this.cmdSaveBihRegister.Click += new System.EventHandler(this.cmdSaveBihRegister_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(540, 14);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(76, 40);
            this.cmdClose.TabIndex = 65;
            this.cmdClose.Text = "退出(Esc)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(301, 14);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(74, 40);
            this.cmdRefurbish.TabIndex = 62;
            this.cmdRefurbish.Text = "刷新(F5)";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // m_lblPStatusName
            // 
            this.m_lblPStatusName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPStatusName.ForeColor = System.Drawing.Color.Red;
            this.m_lblPStatusName.Location = new System.Drawing.Point(50, 18);
            this.m_lblPStatusName.Name = "m_lblPStatusName";
            this.m_lblPStatusName.Size = new System.Drawing.Size(100, 27);
            this.m_lblPStatusName.TabIndex = 16;
            this.m_lblPStatusName.Text = "入院次数";
            this.m_lblPStatusName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label73);
            this.groupBox2.Controls.Add(this.txtConsigneeAddr);
            this.groupBox2.Controls.Add(this.label66);
            this.groupBox2.Controls.Add(this.label64);
            this.groupBox2.Controls.Add(this.label78);
            this.groupBox2.Controls.Add(this.m_cboPatientSource);
            this.groupBox2.Controls.Add(this.label77);
            this.groupBox2.Controls.Add(this.label68);
            this.groupBox2.Controls.Add(this.txtMobile);
            this.groupBox2.Controls.Add(this.label67);
            this.groupBox2.Controls.Add(this.txtResidenceplace);
            this.groupBox2.Controls.Add(this.txtBirthPlace);
            this.groupBox2.Controls.Add(this.m_txttNativeplace);
            this.groupBox2.Controls.Add(this.label74);
            this.groupBox2.Controls.Add(this.m_txtInsuredPayScale);
            this.groupBox2.Controls.Add(this.label63);
            this.groupBox2.Controls.Add(this.m_txtInsuredPayTime);
            this.groupBox2.Controls.Add(this.m_txtInsuredPayMoney);
            this.groupBox2.Controls.Add(this.m_txtInsuredTotalMoney);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.m_dtpBirthDate);
            this.groupBox2.Controls.Add(this.m_txtRelation);
            this.groupBox2.Controls.Add(this.m_txtOccupation);
            this.groupBox2.Controls.Add(this.m_txtPaytype);
            this.groupBox2.Controls.Add(this.m_txtRace);
            this.groupBox2.Controls.Add(this.m_txtAge);
            this.groupBox2.Controls.Add(this.label61);
            this.groupBox2.Controls.Add(this.m_txtGOVCARD_CHR);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.label53);
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.label72);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label71);
            this.groupBox2.Controls.Add(this.m_txtinsuranceid);
            this.groupBox2.Controls.Add(this.label70);
            this.groupBox2.Controls.Add(this.label65);
            this.groupBox2.Controls.Add(this.label62);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txtEmployer);
            this.groupBox2.Controls.Add(this.txtNationality);
            this.groupBox2.Controls.Add(this.txtIDCard);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.cboSex);
            this.groupBox2.Controls.Add(this.txtPatientName);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label49);
            this.groupBox2.Controls.Add(this.txtPATIENTCARDID);
            this.groupBox2.Controls.Add(this.m_cboInpatientNoType);
            this.groupBox2.Controls.Add(this.cobMarried);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtOfficepc);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.lbAddress);
            this.groupBox2.Controls.Add(this.txtHomepc);
            this.groupBox2.Controls.Add(this.txtContactpersonFirstaName);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtOfficeAddress);
            this.groupBox2.Controls.Add(this.txtContactpersonAddress);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtContactpersonPhone);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.txtContactpersonpc);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.cboIsemployee);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_lblOperatorName);
            this.groupBox2.Controls.Add(this.m_txtFoodInfo);
            this.groupBox2.Controls.Add(this.m_txtCareInfo);
            this.groupBox2.Controls.Add(this.txtDeactivateDate);
            this.groupBox2.Controls.Add(this.txtOperatorid);
            this.groupBox2.Controls.Add(this.txtModifydate);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 371);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label73.ForeColor = System.Drawing.Color.Blue;
            this.label73.Location = new System.Drawing.Point(29, 264);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(52, 14);
            this.label73.TabIndex = 321;
            this.label73.Text = "收件人";
            // 
            // txtConsigneeAddr
            // 
            this.txtConsigneeAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsigneeAddr.ForeColor = System.Drawing.Color.Blue;
            this.txtConsigneeAddr.Location = new System.Drawing.Point(336, 328);
            this.txtConsigneeAddr.MaxLength = 20;
            this.txtConsigneeAddr.Name = "txtConsigneeAddr";
            this.txtConsigneeAddr.Size = new System.Drawing.Size(648, 23);
            this.txtConsigneeAddr.TabIndex = 33;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.ForeColor = System.Drawing.Color.Blue;
            this.label66.Location = new System.Drawing.Point(256, 327);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(74, 24);
            this.label66.TabIndex = 320;
            this.label66.Text = "收件地址";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.ForeColor = System.Drawing.Color.Blue;
            this.label64.Location = new System.Drawing.Point(6, 321);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(74, 33);
            this.label64.TabIndex = 318;
            this.label64.Text = "移动电话收件电话";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(770, 106);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(63, 14);
            this.label78.TabIndex = 317;
            this.label78.Text = "病人来源";
            // 
            // m_cboPatientSource
            // 
            this.m_cboPatientSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientSource.FormattingEnabled = true;
            this.m_cboPatientSource.Location = new System.Drawing.Point(836, 103);
            this.m_cboPatientSource.Name = "m_cboPatientSource";
            this.m_cboPatientSource.Size = new System.Drawing.Size(148, 22);
            this.m_cboPatientSource.TabIndex = 15;
            this.m_cboPatientSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPatientSource_KeyDown);
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.Location = new System.Drawing.Point(754, 102);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(15, 18);
            this.label77.TabIndex = 316;
            this.label77.Text = "*";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(519, 143);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(63, 14);
            this.label68.TabIndex = 314;
            this.label68.Text = "户口地址";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtMobile.ForeColor = System.Drawing.Color.Blue;
            this.txtMobile.Location = new System.Drawing.Point(83, 327);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Multiline = true;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(148, 23);
            this.txtMobile.TabIndex = 32;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(30, 143);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(49, 14);
            this.label67.TabIndex = 313;
            this.label67.Text = "出生地";
            // 
            // txtResidenceplace
            // 
            this.txtResidenceplace.Location = new System.Drawing.Point(583, 140);
            this.txtResidenceplace.MaxLength = 60;
            this.txtResidenceplace.Name = "txtResidenceplace";
            this.txtResidenceplace.Size = new System.Drawing.Size(402, 23);
            this.txtResidenceplace.TabIndex = 17;
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.Location = new System.Drawing.Point(83, 140);
            this.txtBirthPlace.MaxLength = 50;
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(401, 23);
            this.txtBirthPlace.TabIndex = 16;
            // 
            // m_txttNativeplace
            // 
            this.m_txttNativeplace.Location = new System.Drawing.Point(662, 66);
            this.m_txttNativeplace.Name = "m_txttNativeplace";
            this.m_txttNativeplace.Size = new System.Drawing.Size(74, 23);
            this.m_txttNativeplace.TabIndex = 9;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(631, 70);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 14);
            this.label74.TabIndex = 310;
            this.label74.Text = "籍贯";
            // 
            // m_txtInsuredPayScale
            // 
            this.m_txtInsuredPayScale.Location = new System.Drawing.Point(99, 376);
            this.m_txtInsuredPayScale.MaxLength = 25;
            this.m_txtInsuredPayScale.Name = "m_txtInsuredPayScale";
            this.m_txtInsuredPayScale.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredPayScale.TabIndex = 32;
            this.m_txtInsuredPayScale.Visible = false;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(11, 381);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(91, 14);
            this.label63.TabIndex = 308;
            this.label63.Text = "医保支付比例";
            this.label63.Visible = false;
            // 
            // m_txtInsuredPayTime
            // 
            this.m_txtInsuredPayTime.Location = new System.Drawing.Point(584, 288);
            this.m_txtInsuredPayTime.MaxLength = 25;
            this.m_txtInsuredPayTime.Name = "m_txtInsuredPayTime";
            this.m_txtInsuredPayTime.Size = new System.Drawing.Size(147, 23);
            this.m_txtInsuredPayTime.TabIndex = 30;
            this.m_txtInsuredPayTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredPayTime_KeyPress);
            // 
            // m_txtInsuredPayMoney
            // 
            this.m_txtInsuredPayMoney.Location = new System.Drawing.Point(836, 288);
            this.m_txtInsuredPayMoney.MaxLength = 25;
            this.m_txtInsuredPayMoney.Name = "m_txtInsuredPayMoney";
            this.m_txtInsuredPayMoney.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredPayMoney.TabIndex = 31;
            this.m_txtInsuredPayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredPayMoney_KeyPress);
            // 
            // m_txtInsuredTotalMoney
            // 
            this.m_txtInsuredTotalMoney.Location = new System.Drawing.Point(336, 288);
            this.m_txtInsuredTotalMoney.MaxLength = 25;
            this.m_txtInsuredTotalMoney.Name = "m_txtInsuredTotalMoney";
            this.m_txtInsuredTotalMoney.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredTotalMoney.TabIndex = 29;
            this.m_txtInsuredTotalMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredTotalMoney_KeyPress);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(245, 292);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(91, 14);
            this.label58.TabIndex = 302;
            this.label58.Text = "医保剩余金额";
            // 
            // m_dtpBirthDate
            // 
            this.m_dtpBirthDate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtpBirthDate.Location = new System.Drawing.Point(583, 29);
            this.m_dtpBirthDate.Mask = "yyyy-MM-dd";
            this.m_dtpBirthDate.Name = "m_dtpBirthDate";
            this.m_dtpBirthDate.Size = new System.Drawing.Size(91, 23);
            this.m_dtpBirthDate.TabIndex = 3;
            this.m_dtpBirthDate.TextChanged += new System.EventHandler(this.m_dtpBirthDate_TextChanged);
            // 
            // m_txtRelation
            // 
            this.m_txtRelation.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtRelation.Location = new System.Drawing.Point(336, 251);
            this.m_txtRelation.m_blnFocuseShow = true;
            this.m_txtRelation.m_blnPagination = false;
            this.m_txtRelation.m_dtbDataSourse = null;
            this.m_txtRelation.m_intDelayTime = 100;
            this.m_txtRelation.m_intPageRows = 5;
            this.m_txtRelation.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtRelation.m_listViewSize = new System.Drawing.Point(180, 100);
            this.m_txtRelation.m_strFieldsArr = new string[] {
        "dictdefinecode_vchr",
        "pycode_chr",
        "dictname_vchr"};
            this.m_txtRelation.m_strSaveField = "dictname_vchr";
            this.m_txtRelation.m_strShowField = "dictname_vchr";
            this.m_txtRelation.m_strSQL = null;
            this.m_txtRelation.Name = "m_txtRelation";
            this.m_txtRelation.Size = new System.Drawing.Size(148, 23);
            this.m_txtRelation.TabIndex = 26;
            // 
            // m_txtOccupation
            // 
            this.m_txtOccupation.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtOccupation.Location = new System.Drawing.Point(83, 214);
            this.m_txtOccupation.m_blnFocuseShow = true;
            this.m_txtOccupation.m_blnPagination = false;
            this.m_txtOccupation.m_dtbDataSourse = null;
            this.m_txtOccupation.m_intDelayTime = 100;
            this.m_txtOccupation.m_intPageRows = 5;
            this.m_txtOccupation.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtOccupation.m_listViewSize = new System.Drawing.Point(180, 100);
            this.m_txtOccupation.m_strFieldsArr = new string[] {
        "dictdefinecode_vchr",
        "pycode_chr",
        "dictname_vchr"};
            this.m_txtOccupation.m_strSaveField = "dictname_vchr";
            this.m_txtOccupation.m_strShowField = "dictname_vchr";
            this.m_txtOccupation.m_strSQL = null;
            this.m_txtOccupation.Name = "m_txtOccupation";
            this.m_txtOccupation.Size = new System.Drawing.Size(148, 23);
            this.m_txtOccupation.TabIndex = 21;
            // 
            // m_txtPaytype
            // 
            this.m_txtPaytype.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtPaytype.Location = new System.Drawing.Point(83, 103);
            this.m_txtPaytype.m_blnFocuseShow = true;
            this.m_txtPaytype.m_blnPagination = false;
            this.m_txtPaytype.m_dtbDataSourse = null;
            this.m_txtPaytype.m_intDelayTime = 100;
            this.m_txtPaytype.m_intPageRows = 5;
            this.m_txtPaytype.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtPaytype.m_listViewSize = new System.Drawing.Point(200, 100);
            this.m_txtPaytype.m_strFieldsArr = new string[] {
        "paytypeno_vchr",
        "paytypename_vchr"};
            this.m_txtPaytype.m_strSaveField = "paytypeid_chr";
            this.m_txtPaytype.m_strShowField = "paytypename_vchr";
            this.m_txtPaytype.m_strSQL = null;
            this.m_txtPaytype.Name = "m_txtPaytype";
            this.m_txtPaytype.Size = new System.Drawing.Size(148, 23);
            this.m_txtPaytype.TabIndex = 12;
            this.m_txtPaytype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            this.m_txtPaytype.ItemSelectedOK += new ControlLibrary.txtListView.EventItemSelectedOK(this.m_txtPaytype_ItemSelectedOK);
            // 
            // m_txtRace
            // 
            this.m_txtRace.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtRace.Location = new System.Drawing.Point(83, 66);
            this.m_txtRace.m_blnFocuseShow = true;
            this.m_txtRace.m_blnPagination = false;
            this.m_txtRace.m_dtbDataSourse = null;
            this.m_txtRace.m_intDelayTime = 100;
            this.m_txtRace.m_intPageRows = 5;
            this.m_txtRace.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtRace.m_listViewSize = new System.Drawing.Point(180, 100);
            this.m_txtRace.m_strFieldsArr = new string[] {
        "dictdefinecode_vchr",
        "pycode_chr",
        "dictname_vchr"};
            this.m_txtRace.m_strSaveField = "dictname_vchr";
            this.m_txtRace.m_strShowField = "dictname_vchr";
            this.m_txtRace.m_strSQL = null;
            this.m_txtRace.Name = "m_txtRace";
            this.m_txtRace.Size = new System.Drawing.Size(148, 23);
            this.m_txtRace.TabIndex = 6;
            this.m_txtRace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // m_txtAge
            // 
            this.m_txtAge.Enabled = false;
            this.m_txtAge.Location = new System.Drawing.Point(673, 29);
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.Size = new System.Drawing.Size(64, 23);
            this.m_txtAge.TabIndex = 4;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(770, 70);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(63, 14);
            this.label61.TabIndex = 294;
            this.label61.Text = "医疗证号";
            // 
            // m_txtGOVCARD_CHR
            // 
            this.m_txtGOVCARD_CHR.Location = new System.Drawing.Point(836, 66);
            this.m_txtGOVCARD_CHR.Name = "m_txtGOVCARD_CHR";
            this.m_txtGOVCARD_CHR.Size = new System.Drawing.Size(148, 23);
            this.m_txtGOVCARD_CHR.TabIndex = 10;
            this.m_txtGOVCARD_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmployeeEmptyItem_KeyDown);
            this.m_txtGOVCARD_CHR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMONEY_DEC_KeyPress);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(519, 70);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(63, 14);
            this.label57.TabIndex = 292;
            this.label57.Text = "是否职工";
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(502, 31);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(15, 18);
            this.label53.TabIndex = 291;
            this.label53.Text = "*";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.Location = new System.Drawing.Point(254, 68);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(15, 18);
            this.label51.TabIndex = 290;
            this.label51.Text = "*";
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(254, 31);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(15, 18);
            this.label50.TabIndex = 289;
            this.label50.Text = "*";
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(4, 103);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(15, 18);
            this.label72.TabIndex = 286;
            this.label72.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(272, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 288;
            this.label12.Text = "医 保 号";
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(754, 31);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(17, 18);
            this.label71.TabIndex = 286;
            this.label71.Text = "*";
            // 
            // m_txtinsuranceid
            // 
            this.m_txtinsuranceid.Location = new System.Drawing.Point(336, 103);
            this.m_txtinsuranceid.MaxLength = 30;
            this.m_txtinsuranceid.Name = "m_txtinsuranceid";
            this.m_txtinsuranceid.Size = new System.Drawing.Size(148, 23);
            this.m_txtinsuranceid.TabIndex = 13;
            this.m_txtinsuranceid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTinsuranceEmptyItem_KeyDown);
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(4, 68);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(17, 18);
            this.label70.TabIndex = 285;
            this.label70.Text = "*";
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(4, 177);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(15, 18);
            this.label65.TabIndex = 281;
            this.label65.Text = "*";
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(4, 31);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(15, 18);
            this.label62.TabIndex = 279;
            this.label62.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 516);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 84;
            this.label8.Text = "入院科别";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(715, 572);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 14);
            this.label46.TabIndex = 276;
            this.label46.Text = "操作人员";
            this.label46.Visible = false;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(44, 548);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(63, 14);
            this.label47.TabIndex = 277;
            this.label47.Text = "作废日期";
            this.label47.Visible = false;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(835, 572);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 14);
            this.label48.TabIndex = 275;
            this.label48.Text = "更新日期";
            this.label48.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(576, 572);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 14);
            this.label39.TabIndex = 108;
            this.label39.Text = "备注";
            this.label39.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(36, 572);
            this.label32.Name = "label32";
            this.label32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label32.Size = new System.Drawing.Size(35, 14);
            this.label32.TabIndex = 51;
            this.label32.Text = "籍贯";
            this.label32.Visible = false;
            // 
            // txtEmployer
            // 
            this.txtEmployer.Location = new System.Drawing.Point(336, 214);
            this.txtEmployer.MaxLength = 30;
            this.txtEmployer.Name = "txtEmployer";
            this.txtEmployer.Size = new System.Drawing.Size(148, 23);
            this.txtEmployer.TabIndex = 22;
            this.txtEmployer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageTinsuranceEmptyItem_KeyDown);
            // 
            // txtNationality
            // 
            this.txtNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtNationality.Location = new System.Drawing.Point(336, 66);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(148, 22);
            this.txtNationality.TabIndex = 7;
            this.txtNationality.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            this.txtNationality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(583, 103);
            this.txtIDCard.MaxLength = 50;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(148, 23);
            this.txtIDCard.TabIndex = 14;
            this.txtIDCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageIdentity_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(18, 106);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 14);
            this.label40.TabIndex = 65;
            this.label40.Text = "费用类别";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(444, 572);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 14);
            this.label34.TabIndex = 34;
            this.label34.Text = "医保编号";
            this.label34.Visible = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(312, 572);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(63, 14);
            this.label35.TabIndex = 42;
            this.label35.Text = "联系电话";
            this.label35.Visible = false;
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Location = new System.Drawing.Point(336, 29);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(148, 22);
            this.cboSex.TabIndex = 2;
            this.cboSex.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(83, 29);
            this.txtPatientName.MaxLength = 25;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(81, 23);
            this.txtPatientName.TabIndex = 0;
            this.txtPatientName.TextChanged += new System.EventHandler(this.txtPatientName_TextChanged);
            this.txtPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(18, 32);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 14);
            this.label38.TabIndex = 35;
            this.label38.Text = "姓　　名";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(519, 32);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(63, 14);
            this.label41.TabIndex = 22;
            this.label41.Text = "出生日期";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(176, 572);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 20);
            this.label49.TabIndex = 94;
            this.label49.Text = "诊疗卡号";
            this.label49.Visible = false;
            // 
            // txtPATIENTCARDID
            // 
            this.txtPATIENTCARDID.Location = new System.Drawing.Point(132, 568);
            this.txtPATIENTCARDID.MaxLength = 10;
            this.txtPATIENTCARDID.Name = "txtPATIENTCARDID";
            this.txtPATIENTCARDID.Size = new System.Drawing.Size(136, 23);
            this.txtPATIENTCARDID.TabIndex = 40;
            this.txtPATIENTCARDID.TabStop = false;
            this.txtPATIENTCARDID.Visible = false;
            // 
            // m_cboInpatientNoType
            // 
            this.m_cboInpatientNoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInpatientNoType.Enabled = false;
            this.m_cboInpatientNoType.Items.AddRange(new object[] {
            "1-正式",
            "2-留观"});
            this.m_cboInpatientNoType.Location = new System.Drawing.Point(166, 29);
            this.m_cboInpatientNoType.Name = "m_cboInpatientNoType";
            this.m_cboInpatientNoType.Size = new System.Drawing.Size(65, 22);
            this.m_cboInpatientNoType.TabIndex = 1;
            // 
            // cobMarried
            // 
            this.cobMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMarried.Location = new System.Drawing.Point(836, 29);
            this.cobMarried.Name = "cobMarried";
            this.cobMarried.Size = new System.Drawing.Size(148, 22);
            this.cobMarried.TabIndex = 5;
            this.cobMarried.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 218);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 14);
            this.label31.TabIndex = 52;
            this.label31.Text = "职　　业";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 70);
            this.label33.Name = "label33";
            this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label33.Size = new System.Drawing.Size(63, 14);
            this.label33.TabIndex = 50;
            this.label33.Text = "民　　族";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(272, 70);
            this.label29.Name = "label29";
            this.label29.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 49;
            this.label29.Text = "国    籍";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(583, 177);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(153, 23);
            this.txtPhone.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(519, 180);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 14);
            this.label30.TabIndex = 55;
            this.label30.Text = "联系电话";
            // 
            // txtOfficepc
            // 
            this.txtOfficepc.Location = new System.Drawing.Point(836, 214);
            this.txtOfficepc.MaxLength = 6;
            this.txtOfficepc.Name = "txtOfficepc";
            this.txtOfficepc.Size = new System.Drawing.Size(148, 23);
            this.txtOfficepc.TabIndex = 24;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(83, 177);
            this.txtAddress.MaxLength = 60;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(401, 23);
            this.txtAddress.TabIndex = 18;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(18, 180);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(63, 14);
            this.lbAddress.TabIndex = 81;
            this.lbAddress.Text = "家庭地址";
            // 
            // txtHomepc
            // 
            this.txtHomepc.Location = new System.Drawing.Point(836, 177);
            this.txtHomepc.MaxLength = 6;
            this.txtHomepc.Name = "txtHomepc";
            this.txtHomepc.Size = new System.Drawing.Size(148, 23);
            this.txtHomepc.TabIndex = 20;
            // 
            // txtContactpersonFirstaName
            // 
            this.txtContactpersonFirstaName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtContactpersonFirstaName.ForeColor = System.Drawing.Color.Blue;
            this.txtContactpersonFirstaName.Location = new System.Drawing.Point(83, 251);
            this.txtContactpersonFirstaName.MaxLength = 25;
            this.txtContactpersonFirstaName.Name = "txtContactpersonFirstaName";
            this.txtContactpersonFirstaName.Size = new System.Drawing.Size(148, 23);
            this.txtContactpersonFirstaName.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(29, 247);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 14);
            this.label23.TabIndex = 44;
            this.label23.Text = "联系人";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(519, 218);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 57;
            this.label27.Text = "办公地址";
            // 
            // txtOfficeAddress
            // 
            this.txtOfficeAddress.Location = new System.Drawing.Point(583, 214);
            this.txtOfficeAddress.MaxLength = 60;
            this.txtOfficeAddress.Name = "txtOfficeAddress";
            this.txtOfficeAddress.Size = new System.Drawing.Size(153, 23);
            this.txtOfficeAddress.TabIndex = 23;
            // 
            // txtContactpersonAddress
            // 
            this.txtContactpersonAddress.Location = new System.Drawing.Point(583, 251);
            this.txtContactpersonAddress.MaxLength = 100;
            this.txtContactpersonAddress.Name = "txtContactpersonAddress";
            this.txtContactpersonAddress.Size = new System.Drawing.Size(401, 23);
            this.txtContactpersonAddress.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(505, 254);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 47;
            this.label19.Text = "联系人地址";
            // 
            // txtContactpersonPhone
            // 
            this.txtContactpersonPhone.Location = new System.Drawing.Point(83, 288);
            this.txtContactpersonPhone.MaxLength = 20;
            this.txtContactpersonPhone.Name = "txtContactpersonPhone";
            this.txtContactpersonPhone.Size = new System.Drawing.Size(148, 23);
            this.txtContactpersonPhone.TabIndex = 28;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(840, 548);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(77, 14);
            this.label20.TabIndex = 46;
            this.label20.Text = "联系人邮编";
            this.label20.Visible = false;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(164, 548);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(63, 14);
            this.label44.TabIndex = 83;
            this.label44.Text = "移动电话";
            this.label44.Visible = false;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(564, 548);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(63, 14);
            this.label45.TabIndex = 84;
            this.label45.Text = "有效状态";
            this.label45.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(712, 548);
            this.label28.Name = "label28";
            this.label28.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 36;
            this.label28.Text = "电子邮箱";
            this.label28.Visible = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(308, 548);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(63, 14);
            this.label43.TabIndex = 80;
            this.label43.Text = "是否员工";
            this.label43.Visible = false;
            // 
            // txtContactpersonpc
            // 
            this.txtContactpersonpc.Location = new System.Drawing.Point(812, 544);
            this.txtContactpersonpc.MaxLength = 6;
            this.txtContactpersonpc.Name = "txtContactpersonpc";
            this.txtContactpersonpc.Size = new System.Drawing.Size(136, 23);
            this.txtContactpersonpc.TabIndex = 170;
            this.txtContactpersonpc.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(676, 544);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(136, 23);
            this.txtEmail.TabIndex = 175;
            this.txtEmail.Visible = false;
            // 
            // cboIsemployee
            // 
            this.cboIsemployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsemployee.Items.AddRange(new object[] {
            "1-否",
            "2-是"});
            this.cboIsemployee.Location = new System.Drawing.Point(583, 66);
            this.cboIsemployee.Name = "cboIsemployee";
            this.cboIsemployee.Size = new System.Drawing.Size(48, 22);
            this.cboIsemployee.TabIndex = 8;
            this.cboIsemployee.SelectedIndexChanged += new System.EventHandler(this.cboIsemployee_SelectedIndexChanged);
            this.cboIsemployee.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 76;
            this.label1.Text = "住院号";
            this.label1.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(428, 516);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(72, 23);
            this.label16.TabIndex = 107;
            this.label16.Text = "主治医师";
            this.label16.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(564, 520);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 106;
            this.label14.Text = "饮食类型";
            this.label14.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 520);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "是否预约";
            this.label3.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(304, 520);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 105;
            this.label13.Text = "护理类型";
            this.label13.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(852, 520);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 96;
            this.label4.Text = "操作人";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // m_lblOperatorName
            // 
            this.m_lblOperatorName.Enabled = false;
            this.m_lblOperatorName.Location = new System.Drawing.Point(812, 516);
            this.m_lblOperatorName.Name = "m_lblOperatorName";
            this.m_lblOperatorName.Size = new System.Drawing.Size(136, 23);
            this.m_lblOperatorName.TabIndex = 235;
            this.m_lblOperatorName.TabStop = false;
            this.m_lblOperatorName.Visible = false;
            // 
            // m_txtFoodInfo
            // 
            this.m_txtFoodInfo.Enabled = false;
            this.m_txtFoodInfo.Location = new System.Drawing.Point(540, 516);
            this.m_txtFoodInfo.Name = "m_txtFoodInfo";
            this.m_txtFoodInfo.Size = new System.Drawing.Size(136, 23);
            this.m_txtFoodInfo.TabIndex = 250;
            this.m_txtFoodInfo.TabStop = false;
            this.m_txtFoodInfo.Visible = false;
            // 
            // m_txtCareInfo
            // 
            this.m_txtCareInfo.Enabled = false;
            this.m_txtCareInfo.Location = new System.Drawing.Point(268, 516);
            this.m_txtCareInfo.Name = "m_txtCareInfo";
            this.m_txtCareInfo.Size = new System.Drawing.Size(136, 23);
            this.m_txtCareInfo.TabIndex = 230;
            this.m_txtCareInfo.TabStop = false;
            this.m_txtCareInfo.Visible = false;
            // 
            // txtDeactivateDate
            // 
            this.txtDeactivateDate.Enabled = false;
            this.txtDeactivateDate.Location = new System.Drawing.Point(8, 544);
            this.txtDeactivateDate.Name = "txtDeactivateDate";
            this.txtDeactivateDate.Size = new System.Drawing.Size(120, 23);
            this.txtDeactivateDate.TabIndex = 272;
            this.txtDeactivateDate.Visible = false;
            // 
            // txtOperatorid
            // 
            this.txtOperatorid.Enabled = false;
            this.txtOperatorid.Location = new System.Drawing.Point(676, 568);
            this.txtOperatorid.Name = "txtOperatorid";
            this.txtOperatorid.Size = new System.Drawing.Size(136, 23);
            this.txtOperatorid.TabIndex = 273;
            this.txtOperatorid.Visible = false;
            // 
            // txtModifydate
            // 
            this.txtModifydate.Enabled = false;
            this.txtModifydate.Location = new System.Drawing.Point(812, 568);
            this.txtModifydate.Name = "txtModifydate";
            this.txtModifydate.Size = new System.Drawing.Size(136, 23);
            this.txtModifydate.TabIndex = 274;
            this.txtModifydate.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(519, 106);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 14);
            this.label36.TabIndex = 41;
            this.label36.Text = "身份证号";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(770, 32);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(63, 14);
            this.label42.TabIndex = 82;
            this.label42.Text = "婚　　否";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(770, 218);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 59;
            this.label26.Text = "办公邮编";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(770, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 60;
            this.label17.Text = "地址邮编";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 292);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(77, 14);
            this.label22.TabIndex = 45;
            this.label22.Text = "联系人电话";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(272, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 14);
            this.label37.TabIndex = 6;
            this.label37.Text = "性　　别";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(272, 218);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 58;
            this.label24.Text = "工作单位";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(272, 254);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 14);
            this.label21.TabIndex = 54;
            this.label21.Text = "关　　系";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(483, 292);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(105, 14);
            this.label60.TabIndex = 306;
            this.label60.Text = "医保已报销次数";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(734, 292);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(105, 14);
            this.label59.TabIndex = 304;
            this.label59.Text = "医保已报销金额";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.m_txtBedCode);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.m_txtInPatienID);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.m_txtMZDiagnose);
            this.groupBox5.Controls.Add(this.label56);
            this.groupBox5.Controls.Add(this.label55);
            this.groupBox5.Controls.Add(this.label54);
            this.groupBox5.Controls.Add(this.label69);
            this.groupBox5.Controls.Add(this.m_txtAREAID);
            this.groupBox5.Controls.Add(this.m_txtMaindoctor);
            this.groupBox5.Controls.Add(this.m_txtRemark);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.m_dateInHosp);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.m_cboSTATE_INT);
            this.groupBox5.Controls.Add(this.m_cboTYPE_INT);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.m_txtLIMITRATE_MNY);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(9, 380);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1008, 156);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "住院信息";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(270, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 296;
            this.label18.Text = "床    号";
            // 
            // m_txtBedCode
            // 
            this.m_txtBedCode.Location = new System.Drawing.Point(336, 67);
            this.m_txtBedCode.Name = "m_txtBedCode";
            this.m_txtBedCode.ReadOnly = true;
            this.m_txtBedCode.Size = new System.Drawing.Size(145, 23);
            this.m_txtBedCode.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 294;
            this.label10.Text = "住 院 号";
            // 
            // m_txtInPatienID
            // 
            this.m_txtInPatienID.Location = new System.Drawing.Point(84, 27);
            this.m_txtInPatienID.Name = "m_txtInPatienID";
            this.m_txtInPatienID.ReadOnly = true;
            this.m_txtInPatienID.Size = new System.Drawing.Size(148, 23);
            this.m_txtInPatienID.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 292;
            this.label6.Text = "门诊诊断";
            // 
            // m_txtMZDiagnose
            // 
            this.m_txtMZDiagnose.Location = new System.Drawing.Point(84, 107);
            this.m_txtMZDiagnose.Name = "m_txtMZDiagnose";
            this.m_txtMZDiagnose.Size = new System.Drawing.Size(398, 23);
            this.m_txtMZDiagnose.TabIndex = 8;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(499, 68);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(15, 18);
            this.label56.TabIndex = 288;
            this.label56.Text = "*";
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(499, 30);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(15, 18);
            this.label55.TabIndex = 287;
            this.label55.Text = "*";
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(253, 29);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(15, 18);
            this.label54.TabIndex = 286;
            this.label54.Text = "*";
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(3, 68);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(17, 18);
            this.label69.TabIndex = 285;
            this.label69.Text = "*";
            // 
            // m_txtAREAID
            // 
            this.m_txtAREAID.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtAREAID.Location = new System.Drawing.Point(84, 67);
            this.m_txtAREAID.m_blnFocuseShow = true;
            this.m_txtAREAID.m_blnPagination = false;
            this.m_txtAREAID.m_dtbDataSourse = null;
            this.m_txtAREAID.m_intDelayTime = 100;
            this.m_txtAREAID.m_intPageRows = 10;
            this.m_txtAREAID.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtAREAID.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtAREAID.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtAREAID.m_strSaveField = "deptid_chr";
            this.m_txtAREAID.m_strShowField = "deptname_vchr";
            this.m_txtAREAID.m_strSQL = null;
            this.m_txtAREAID.Name = "m_txtAREAID";
            this.m_txtAREAID.Size = new System.Drawing.Size(148, 23);
            this.m_txtAREAID.TabIndex = 4;
            this.m_txtAREAID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // m_txtMaindoctor
            // 
            this.m_txtMaindoctor.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtMaindoctor.Location = new System.Drawing.Point(583, 67);
            this.m_txtMaindoctor.m_blnFocuseShow = true;
            this.m_txtMaindoctor.m_blnPagination = false;
            this.m_txtMaindoctor.m_dtbDataSourse = null;
            this.m_txtMaindoctor.m_intDelayTime = 100;
            this.m_txtMaindoctor.m_intPageRows = 10;
            this.m_txtMaindoctor.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtMaindoctor.m_listViewSize = new System.Drawing.Point(210, 100);
            this.m_txtMaindoctor.m_strFieldsArr = new string[] {
        "empno_chr",
        "pycode_chr",
        "doctorname"};
            this.m_txtMaindoctor.m_strSaveField = "empid_chr";
            this.m_txtMaindoctor.m_strShowField = "doctorname";
            this.m_txtMaindoctor.m_strSQL = null;
            this.m_txtMaindoctor.Name = "m_txtMaindoctor";
            this.m_txtMaindoctor.Size = new System.Drawing.Size(148, 23);
            this.m_txtMaindoctor.TabIndex = 6;
            this.m_txtMaindoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(583, 107);
            this.m_txtRemark.MaxLength = 100;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(401, 23);
            this.m_txtRemark.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(754, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 98;
            this.label9.Text = "入院时情况";
            // 
            // m_dateInHosp
            // 
            this.m_dateInHosp.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.m_dateInHosp.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dateInHosp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dateInHosp.Location = new System.Drawing.Point(336, 27);
            this.m_dateInHosp.Name = "m_dateInHosp";
            this.m_dateInHosp.Size = new System.Drawing.Size(145, 23);
            this.m_dateInHosp.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(516, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 118;
            this.label25.Text = "门诊医生";
            // 
            // m_cboSTATE_INT
            // 
            this.m_cboSTATE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSTATE_INT.Items.AddRange(new object[] {
            "1-危",
            "2-急",
            "3-普通"});
            this.m_cboSTATE_INT.Location = new System.Drawing.Point(836, 27);
            this.m_cboSTATE_INT.Name = "m_cboSTATE_INT";
            this.m_cboSTATE_INT.Size = new System.Drawing.Size(148, 22);
            this.m_cboSTATE_INT.TabIndex = 3;
            this.m_cboSTATE_INT.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            this.m_cboSTATE_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // m_cboTYPE_INT
            // 
            this.m_cboTYPE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboTYPE_INT.Items.AddRange(new object[] {
            "1-门诊",
            "2-急诊",
            "3-他院转入",
            "4-他科转入"});
            this.m_cboTYPE_INT.Location = new System.Drawing.Point(583, 27);
            this.m_cboTYPE_INT.Name = "m_cboTYPE_INT";
            this.m_cboTYPE_INT.Size = new System.Drawing.Size(148, 22);
            this.m_cboTYPE_INT.TabIndex = 2;
            this.m_cboTYPE_INT.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 82;
            this.label2.Text = "入院日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 86;
            this.label7.Text = "病　　区";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "转入方式";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(516, 110);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 14);
            this.label52.TabIndex = 86;
            this.label52.Text = "备　　注";
            // 
            // m_txtLIMITRATE_MNY
            // 
            this.m_txtLIMITRATE_MNY.Location = new System.Drawing.Point(836, 67);
            this.m_txtLIMITRATE_MNY.MaxLength = 10;
            this.m_txtLIMITRATE_MNY.Name = "m_txtLIMITRATE_MNY";
            this.m_txtLIMITRATE_MNY.Size = new System.Drawing.Size(148, 23);
            this.m_txtLIMITRATE_MNY.TabIndex = 7;
            this.m_txtLIMITRATE_MNY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMONEY_DEC_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(767, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 94;
            this.label11.Text = "费用下限";
            // 
            // txtOfficephone
            // 
            this.txtOfficephone.Location = new System.Drawing.Point(588, 132);
            this.txtOfficephone.MaxLength = 20;
            this.txtOfficephone.Name = "txtOfficephone";
            this.txtOfficephone.Size = new System.Drawing.Size(148, 21);
            this.txtOfficephone.TabIndex = 17;
            // 
            // frmEditRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 613);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmEditRegister";
            this.Text = "登记资料修改";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditRegister_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegister_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_EditRegister();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strParm"></param>
        public void ShowWithParm(string p_strParm)
        {
            this.m_strOpentParm = p_strParm;
            this.Show();
        }

        #region 初始化数据
        private void frmRegister_Load(object sender, System.EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtRace, m_txtPaytype, m_txtOccupation, m_txtRelation, m_txtAREAID, m_txtMaindoctor, m_txtFindText });
            m_initTimer = new Timer();
            m_initTimer.Interval = 10;
            m_initTimer.Tick += new EventHandler(m_initTimer_Tick);
            m_initTimer.Start();
            ((clsCtl_EditRegister)this.objController).m_mthInitYB();
        }
        private void m_initTimer_Tick(object sender, EventArgs e)
        {
            m_initTimer.Stop();
            m_initTimer=null;
            ((clsCtl_EditRegister)this.objController).m_mthInit();

        }
        #endregion

        #region 保存
        private void cmdSaveBihRegister_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_mthSaveRegister();
        }
        #endregion

        #region 清空
        private void cmdEmpty_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_EmptyAndInitialization();
        }
        #endregion

        #region 刷新
        private void cmdRefurbish_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_mthFresh();
        }
        #endregion

        #region 快捷键
        /// <summary>
        /// 切换光标标志
        /// </summary>
        int flag = 0;
        private void frmRegister_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //if (MessageBox.Show(this, "确认要退出吗?", "入院登记", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                        this.Close();
                    //}
                    break;
                case Keys.F2:
                    ((clsCtl_EditRegister)objController).m_mthSaveRegister();
                    break;
                case Keys.F3:
                    ((clsCtl_EditRegister)objController).m_mthFindPatient();
                    break;
                case Keys.F5:
                    cmdRefurbish_Click(sender, e);
                    break;
                case Keys.F6:
                    cmdEmpty_Click(sender, e);
                    break;
                case Keys.F9:
                    #region  在基本信息与住院信息间切换焦点
                    if (flag == 0)
                    {
                        this.groupBox5.Focus();
                        SendKeys.SendWait("{TAB}");
                        flag = 1;
                    }
                    else
                    {
                        this.groupBox2.Focus();
                        SendKeys.SendWait("{TAB}");
                        flag = 0;
                    }
                    break;
                    #endregion
                    break;
                case Keys.Enter:
                    m_mthSetKeyTab(e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 退出
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查找病人
        private void m_cmdFindPatient_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_mthFindPatient();
        }
        #endregion

        #region 控制预交金只可输入数字
        private void m_txtMONEY_DEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if ((ASCII >= 48 && ASCII <= 57) || ASCII == 8 || ASCII == 88 || ASCII == 120)
            {
                if (ASCII == 88 || ASCII == 120)
                {
                    if (txtIDCard.Text.Trim().Length != 14 && txtIDCard.Text.Trim().Length != 17)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 设置联系人
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            txtContactpersonFirstaName.Text = txtPatientName.Text.Trim();
        }
        #endregion

        #region 根据病人诊疗卡号或住院号获取病人ID
        private void m_txtFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_EditRegister)this.objController).m_mthGetPatientIDByCarIDOrInPatientID();
            }
        }
        #endregion

        #region 是否职工
        private void cboIsemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboIsemployee.SelectedIndex == 1)
            {
                m_txtGOVCARD_CHR.Text = "";
                m_txtGOVCARD_CHR.Enabled = true;
            }
            else
            {
                m_txtGOVCARD_CHR.Text = "";
                m_txtGOVCARD_CHR.Enabled = false;
            }
        }
        #endregion

        #region 设置费用类型
        private void m_txtPaytype_ItemSelectedOK(object s, EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_mthSetPatType();
        }
        #endregion

        // 对用用户输入操作的控制
        #region 处理带*号不能为空的项
        private void ManageEmptyItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_EditRegister)objController).m_mthManageEmptyItem(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 处理医保病人不能为空的项
        private void ManageTinsuranceEmptyItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_EditRegister)objController).m_mthManagTinsuranceEmpty(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 处理职工病人不能为空的项
        private void ManageEmployeeEmptyItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_EditRegister)objController).m_mthManagEmployeeEmpty(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 身份证号输入控制
        private void ManageIdentity_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_EditRegister)objController).m_mthManageIdentity();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 对家庭地址输入控制
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_EditRegister)objController).m_mthAddressIdentity();
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region 对病人来源输入控制
        private void m_cboPatientSource_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_Register)objController).m_mthManageEmptyItem(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion  
        #region 用于控制显示下拉框
        private void m_cboInpatientNoType_Enter(object sender, EventArgs e)
        {
            m_comBox = ((ComboBox)sender);
            m_timer.Start();
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            m_timer.Stop();
            if (m_comBox != null && !m_comBox.DroppedDown)
            {
                m_comBox.DroppedDown = true;
            }
        }
        #endregion

        #region 计算年龄
        private void m_dtpBirthDate_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_EditRegister)objController).m_mthCalculateAge();
        }
        #endregion

        private void frmEditRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "确认要退出吗？", "入院登记资料修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

   
        private void m_txtInsuredTotalMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void m_txtInsuredPayTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void m_txtInsuredPayMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        //加入嵌入式社保调用登记窗体
        private void btnYBReg_Click(object sender, EventArgs e)
        {
            ((clsCtl_EditRegister)this.objController).m_mthYBPatient();
        }

        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            Hisitf.EntityIDCard idCardVo = Hisitf.IDCardItf.ReadIDCard();
            if (idCardVo != null)
            {
                if (string.IsNullOrEmpty(idCardVo.error))
                {
                    this.txtPatientName.Text = idCardVo.name;
                    this.cboSex.Text = idCardVo.sex;
                    this.m_dtpBirthDate.Text = Convert.ToDateTime(idCardVo.birthday).ToString("yyyy-MM-dd");
                    this.txtIDCard.Text = idCardVo.idNo;
                    this.txtResidenceplace.Text = idCardVo.addr;
                    //this.txtAddress.Text = idCardVo.addr;
                    this.m_txtRace.Text = idCardVo.nation;
                    //this.picPhoto.Image = idCardVo.photo;
                    this.cobMarried.Focus();
                }
                else
                {
                    MessageBox.Show(idCardVo.error);
                }
            }
        }
 
    }
}
