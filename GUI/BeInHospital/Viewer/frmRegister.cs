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
    /// 住院登记界面表示层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-09-06
    /// </summary>
    public class frmPatientRecord : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
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

        #region 控件申明

        internal System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
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
        internal System.Windows.Forms.TextBox txtBirthPlace;
        private System.Windows.Forms.Label label18;
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
        internal System.Windows.Forms.DateTimePicker dtpFirstDate;
        private System.Windows.Forms.Label 初诊日期;
        internal System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label44;
        internal System.Windows.Forms.ComboBox cobStatus;
        private System.Windows.Forms.Label label45;
        internal System.Windows.Forms.TextBox txtPATIENTCARDID;
        private System.Windows.Forms.GroupBox groupBox3;
        private PinkieControls.ButtonXP cmdEmpty;
        internal PinkieControls.ButtonXP cmdSaveBihRegister;
        internal System.Windows.Forms.CheckBox m_chkISBOOKING_INT;
        internal System.Windows.Forms.ComboBox m_cboTYPE_INT;
        internal System.Windows.Forms.ComboBox m_cboSTATE_INT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox m_txtINPATIENTID_CHR;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP cmdClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label m_lblPStatusName;
        private PinkieControls.ButtonXP cmdRefurbish;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox m_txtDEPTID_CHR;
        internal System.Windows.Forms.TextBox m_txtCareInfo;
        internal System.Windows.Forms.TextBox m_txtFoodInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label39;
        internal System.Windows.Forms.ListView m_lsvBihTransfer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        internal System.Windows.Forms.ListView m_lsvBihLeave;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        internal System.Windows.Forms.TextBox m_lblOperatorName;
        internal System.Windows.Forms.TextBox m_txtLIMITRATE_MNY;
        internal System.Windows.Forms.RadioButton m_rdbCurrent;
        internal System.Windows.Forms.CheckBox m_ckbTraDEPTAndBED;
        internal System.Windows.Forms.RadioButton m_rdbHistory;
        internal System.Windows.Forms.CheckBox m_ckbTraBed;
        internal System.Windows.Forms.CheckBox m_ckbOutHospital;
        internal System.Windows.Forms.CheckBox m_ckbInhospital;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox m_txtRemark;
        private System.Windows.Forms.Label label52;
        internal System.Windows.Forms.DateTimePicker m_dateInHosp;
        internal PinkieControls.ButtonXP m_cmdFindPatient;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.ListView m_lsvTurnInPation;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        public TextBox m_txtMONEY_DEC;
        private Label label59;
        internal TextBox m_txtPREPAYINV_VCHR;
        private Label label63;
        internal ComboBox m_cboCUYCATE_INT;
        private Label label60;
        private Label label58;
        private Label label10;
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
        internal TextBox m_txtMZDiagnose;
        internal TextBox m_txtInsuredPayMoney;
        internal TextBox m_txtInsuredPayTime;
        internal TextBox m_txtInsuredMoney;
        private Label label73;
        private Label label68;
        private Label label67;
        internal TextBox m_txttNativeplace;
        private Label label74;
        private PictureBox picMobile;
        private LinkLabel llblMobileServer;
        private Label label76;
        private Label label75;
        internal TextBox txtResidenceplace;
        private Label label78;
        internal ComboBox m_cboPatientSource;
        private Label label77;
        internal PinkieControls.ButtonXP btnYBReg;
        internal PinkieControls.ButtonXP btnReadIDCard;
        private Label label64;
        internal TextBox txtConsigneeAddr;
        private Label label66;
        private Label label79;
        internal ComboBox m_cobPrint;

        #endregion

        #region 构造函数
        public frmPatientRecord()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientRecord));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtMZDiagnose = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.m_txtAREAID = new ControlLibrary.txtListView(this.components);
            this.m_txtMaindoctor = new ControlLibrary.txtListView(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.m_cobPrint = new System.Windows.Forms.ComboBox();
            this.m_txtPREPAYINV_VCHR = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.m_cboCUYCATE_INT = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.m_txtMONEY_DEC = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
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
            this.label79 = new System.Windows.Forms.Label();
            this.txtConsigneeAddr = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.m_cboPatientSource = new System.Windows.Forms.ComboBox();
            this.txtResidenceplace = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.llblMobileServer = new System.Windows.Forms.LinkLabel();
            this.picMobile = new System.Windows.Forms.PictureBox();
            this.txtBirthPlace = new System.Windows.Forms.TextBox();
            this.cboIsemployee = new System.Windows.Forms.ComboBox();
            this.m_txttNativeplace = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.m_txtInsuredPayMoney = new System.Windows.Forms.TextBox();
            this.m_txtInsuredPayTime = new System.Windows.Forms.TextBox();
            this.m_txtInsuredMoney = new System.Windows.Forms.TextBox();
            this.m_dtpBirthDate = new NullableDateControls.MaskDateEdit();
            this.m_txtRelation = new ControlLibrary.txtListView(this.components);
            this.m_txtOccupation = new ControlLibrary.txtListView(this.components);
            this.m_txtPaytype = new ControlLibrary.txtListView(this.components);
            this.m_txtRace = new ControlLibrary.txtListView(this.components);
            this.m_txtAge = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
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
            this.初诊日期 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.dtpFirstDate = new System.Windows.Forms.DateTimePicker();
            this.txtContactpersonpc = new System.Windows.Forms.TextBox();
            this.cobStatus = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblOperatorName = new System.Windows.Forms.TextBox();
            this.m_chkISBOOKING_INT = new System.Windows.Forms.CheckBox();
            this.m_txtINPATIENTID_CHR = new System.Windows.Forms.TextBox();
            this.m_txtFoodInfo = new System.Windows.Forms.TextBox();
            this.m_txtCareInfo = new System.Windows.Forms.TextBox();
            this.txtDeactivateDate = new System.Windows.Forms.TextBox();
            this.txtOperatorid = new System.Windows.Forms.TextBox();
            this.txtModifydate = new System.Windows.Forms.TextBox();
            this.m_txtDEPTID_CHR = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_lsvBihTransfer = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_ckbTraDEPTAndBED = new System.Windows.Forms.CheckBox();
            this.m_ckbTraBed = new System.Windows.Forms.CheckBox();
            this.m_ckbOutHospital = new System.Windows.Forms.CheckBox();
            this.m_ckbInhospital = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_rdbCurrent = new System.Windows.Forms.RadioButton();
            this.m_rdbHistory = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_lsvBihLeave = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_lsvTurnInPation = new System.Windows.Forms.ListView();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.txtOfficephone = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMobile)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 637);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1021, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "(1)入院登记";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.m_txtMZDiagnose);
            this.groupBox5.Controls.Add(this.label56);
            this.groupBox5.Controls.Add(this.label55);
            this.groupBox5.Controls.Add(this.label54);
            this.groupBox5.Controls.Add(this.label69);
            this.groupBox5.Controls.Add(this.m_txtAREAID);
            this.groupBox5.Controls.Add(this.m_txtMaindoctor);
            this.groupBox5.Controls.Add(this.label58);
            this.groupBox5.Controls.Add(this.m_cobPrint);
            this.groupBox5.Controls.Add(this.m_txtPREPAYINV_VCHR);
            this.groupBox5.Controls.Add(this.label63);
            this.groupBox5.Controls.Add(this.m_cboCUYCATE_INT);
            this.groupBox5.Controls.Add(this.label60);
            this.groupBox5.Controls.Add(this.m_txtMONEY_DEC);
            this.groupBox5.Controls.Add(this.label59);
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
            this.groupBox5.Location = new System.Drawing.Point(3, 388);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1008, 142);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "住院信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 292;
            this.label6.Text = "门诊诊断";
            // 
            // m_txtMZDiagnose
            // 
            this.m_txtMZDiagnose.Location = new System.Drawing.Point(595, 66);
            this.m_txtMZDiagnose.Name = "m_txtMZDiagnose";
            this.m_txtMZDiagnose.Size = new System.Drawing.Size(148, 23);
            this.m_txtMZDiagnose.TabIndex = 6;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(765, 31);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(15, 18);
            this.label56.TabIndex = 288;
            this.label56.Text = "*";
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(257, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(15, 18);
            this.label55.TabIndex = 287;
            this.label55.Text = "*";
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(4, 31);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(15, 18);
            this.label54.TabIndex = 286;
            this.label54.Text = "*";
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(505, 31);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(17, 18);
            this.label69.TabIndex = 285;
            this.label69.Text = "*";
            // 
            // m_txtAREAID
            // 
            this.m_txtAREAID.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtAREAID.Location = new System.Drawing.Point(595, 29);
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
            this.m_txtAREAID.TabIndex = 2;
            this.m_txtAREAID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            this.m_txtAREAID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtMaindoctor_MouseDown);
            // 
            // m_txtMaindoctor
            // 
            this.m_txtMaindoctor.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtMaindoctor.Location = new System.Drawing.Point(849, 29);
            this.m_txtMaindoctor.m_blnFocuseShow = true;
            this.m_txtMaindoctor.m_blnPagination = false;
            this.m_txtMaindoctor.m_dtbDataSourse = null;
            this.m_txtMaindoctor.m_intDelayTime = 100;
            this.m_txtMaindoctor.m_intPageRows = 10;
            this.m_txtMaindoctor.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.RightBottom;
            this.m_txtMaindoctor.m_listViewSize = new System.Drawing.Point(210, 100);
            this.m_txtMaindoctor.m_strFieldsArr = new string[] {
        "empno_chr",
        "pycode_chr",
        "doctorname"};
            this.m_txtMaindoctor.m_strSaveField = "empid_chr";
            this.m_txtMaindoctor.m_strShowField = "doctorname";
            this.m_txtMaindoctor.m_strSQL = null;
            this.m_txtMaindoctor.Name = "m_txtMaindoctor";
            this.m_txtMaindoctor.Size = new System.Drawing.Size(151, 23);
            this.m_txtMaindoctor.TabIndex = 3;
            this.m_txtMaindoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            this.m_txtMaindoctor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtMaindoctor_MouseDown);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(781, 108);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(63, 14);
            this.label58.TabIndex = 128;
            this.label58.Text = "打印选项";
            // 
            // m_cobPrint
            // 
            this.m_cobPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobPrint.Items.AddRange(new object[] {
            "1-打印预交金收据",
            "2-不打印预交金收据"});
            this.m_cobPrint.Location = new System.Drawing.Point(849, 105);
            this.m_cobPrint.Name = "m_cobPrint";
            this.m_cobPrint.Size = new System.Drawing.Size(151, 22);
            this.m_cobPrint.TabIndex = 11;
            this.m_cobPrint.TabStop = false;
            this.m_cobPrint.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // m_txtPREPAYINV_VCHR
            // 
            this.m_txtPREPAYINV_VCHR.Location = new System.Drawing.Point(595, 105);
            this.m_txtPREPAYINV_VCHR.MaxLength = 40;
            this.m_txtPREPAYINV_VCHR.Name = "m_txtPREPAYINV_VCHR";
            this.m_txtPREPAYINV_VCHR.Size = new System.Drawing.Size(148, 23);
            this.m_txtPREPAYINV_VCHR.TabIndex = 10;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(528, 108);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(63, 14);
            this.label63.TabIndex = 125;
            this.label63.Text = "预交单号";
            // 
            // m_cboCUYCATE_INT
            // 
            this.m_cboCUYCATE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCUYCATE_INT.Items.AddRange(new object[] {
            "1-现金",
            "2-支票",
            "3-银行卡",
            "4-微信2",
            "5-其他",
            "6-支付宝"});
            this.m_cboCUYCATE_INT.Location = new System.Drawing.Point(336, 105);
            this.m_cboCUYCATE_INT.Name = "m_cboCUYCATE_INT";
            this.m_cboCUYCATE_INT.Size = new System.Drawing.Size(148, 22);
            this.m_cboCUYCATE_INT.TabIndex = 9;
            this.m_cboCUYCATE_INT.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(272, 108);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(63, 14);
            this.label60.TabIndex = 123;
            this.label60.Text = "支付类型";
            // 
            // m_txtMONEY_DEC
            // 
            this.m_txtMONEY_DEC.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMONEY_DEC.Location = new System.Drawing.Point(83, 105);
            this.m_txtMONEY_DEC.MaxLength = 10;
            this.m_txtMONEY_DEC.Name = "m_txtMONEY_DEC";
            this.m_txtMONEY_DEC.Size = new System.Drawing.Size(148, 23);
            this.m_txtMONEY_DEC.TabIndex = 8;
            this.m_txtMONEY_DEC.Leave += new System.EventHandler(this.m_txtMONEY_DEC_Leave);
            this.m_txtMONEY_DEC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMONEY_DEC_KeyPress);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(18, 108);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(63, 14);
            this.label59.TabIndex = 121;
            this.label59.Text = "预交金额";
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(849, 66);
            this.m_txtRemark.MaxLength = 100;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(151, 23);
            this.m_txtRemark.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 98;
            this.label9.Text = "入院时情况";
            // 
            // m_dateInHosp
            // 
            this.m_dateInHosp.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dateInHosp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dateInHosp.Location = new System.Drawing.Point(83, 29);
            this.m_dateInHosp.Name = "m_dateInHosp";
            this.m_dateInHosp.Size = new System.Drawing.Size(148, 23);
            this.m_dateInHosp.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(781, 33);
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
            this.m_cboSTATE_INT.Location = new System.Drawing.Point(83, 66);
            this.m_cboSTATE_INT.Name = "m_cboSTATE_INT";
            this.m_cboSTATE_INT.Size = new System.Drawing.Size(148, 22);
            this.m_cboSTATE_INT.TabIndex = 4;
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
            this.m_cboTYPE_INT.Location = new System.Drawing.Point(336, 29);
            this.m_cboTYPE_INT.Name = "m_cboTYPE_INT";
            this.m_cboTYPE_INT.Size = new System.Drawing.Size(148, 22);
            this.m_cboTYPE_INT.TabIndex = 1;
            this.m_cboTYPE_INT.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 82;
            this.label2.Text = "入院日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 86;
            this.label7.Text = "病　　区";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "转入方式";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(781, 68);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 14);
            this.label52.TabIndex = 86;
            this.label52.Text = "备　　注";
            // 
            // m_txtLIMITRATE_MNY
            // 
            this.m_txtLIMITRATE_MNY.Location = new System.Drawing.Point(336, 66);
            this.m_txtLIMITRATE_MNY.MaxLength = 10;
            this.m_txtLIMITRATE_MNY.Name = "m_txtLIMITRATE_MNY";
            this.m_txtLIMITRATE_MNY.Size = new System.Drawing.Size(148, 23);
            this.m_txtLIMITRATE_MNY.TabIndex = 5;
            this.m_txtLIMITRATE_MNY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMONEY_DEC_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 94;
            this.label11.Text = "费用下限";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmbFindType);
            this.groupBox1.Controls.Add(this.m_cmdFindPatient);
            this.groupBox1.Controls.Add(this.m_txtFindText);
            this.groupBox1.Location = new System.Drawing.Point(649, 538);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 68);
            this.groupBox1.TabIndex = 9;
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
            this.m_cmbFindType.Location = new System.Drawing.Point(10, 29);
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
            this.m_cmdFindPatient.Location = new System.Drawing.Point(247, 24);
            this.m_cmdFindPatient.Name = "m_cmdFindPatient";
            this.m_cmdFindPatient.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFindPatient.Size = new System.Drawing.Size(106, 33);
            this.m_cmdFindPatient.TabIndex = 66;
            this.m_cmdFindPatient.Text = "查询(F3)";
            this.m_cmdFindPatient.Click += new System.EventHandler(this.m_cmdFindPatient_Click);
            // 
            // m_txtFindText
            // 
            this.m_txtFindText.Location = new System.Drawing.Point(117, 28);
            this.m_txtFindText.Name = "m_txtFindText";
            this.m_txtFindText.Size = new System.Drawing.Size(118, 23);
            this.m_txtFindText.TabIndex = 287;
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
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(3, 538);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(648, 68);
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
            this.btnReadIDCard.Location = new System.Drawing.Point(452, 19);
            this.btnReadIDCard.Name = "btnReadIDCard";
            this.btnReadIDCard.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReadIDCard.Size = new System.Drawing.Size(92, 40);
            this.btnReadIDCard.TabIndex = 70;
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
            this.btnYBReg.Location = new System.Drawing.Point(164, 19);
            this.btnYBReg.Name = "btnYBReg";
            this.btnYBReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnYBReg.Size = new System.Drawing.Size(72, 40);
            this.btnYBReg.TabIndex = 67;
            this.btnYBReg.Text = "医保登记";
            this.btnYBReg.Click += new System.EventHandler(this.btnYBReg_Click);
            // 
            // label15
            // 
            this.label15.AllowDrop = true;
            this.label15.Location = new System.Drawing.Point(8, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 27);
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
            this.cmdEmpty.Location = new System.Drawing.Point(380, 19);
            this.cmdEmpty.Name = "cmdEmpty";
            this.cmdEmpty.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdEmpty.Size = new System.Drawing.Size(72, 40);
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
            this.cmdSaveBihRegister.Location = new System.Drawing.Point(236, 19);
            this.cmdSaveBihRegister.Name = "cmdSaveBihRegister";
            this.cmdSaveBihRegister.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSaveBihRegister.Size = new System.Drawing.Size(72, 40);
            this.cmdSaveBihRegister.TabIndex = 60;
            this.cmdSaveBihRegister.Text = "入院(F2)";
            this.cmdSaveBihRegister.Click += new System.EventHandler(this.cmdSaveBihRegister_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(544, 19);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(72, 40);
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
            this.cmdRefurbish.Location = new System.Drawing.Point(308, 19);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(72, 40);
            this.cmdRefurbish.TabIndex = 62;
            this.cmdRefurbish.Text = "刷新(F5)";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // m_lblPStatusName
            // 
            this.m_lblPStatusName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPStatusName.ForeColor = System.Drawing.Color.Red;
            this.m_lblPStatusName.Location = new System.Drawing.Point(60, 28);
            this.m_lblPStatusName.Name = "m_lblPStatusName";
            this.m_lblPStatusName.Size = new System.Drawing.Size(158, 27);
            this.m_lblPStatusName.TabIndex = 16;
            this.m_lblPStatusName.Text = "首次入院";
            this.m_lblPStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label79);
            this.groupBox2.Controls.Add(this.txtConsigneeAddr);
            this.groupBox2.Controls.Add(this.label66);
            this.groupBox2.Controls.Add(this.label64);
            this.groupBox2.Controls.Add(this.label78);
            this.groupBox2.Controls.Add(this.txtMobile);
            this.groupBox2.Controls.Add(this.m_cboPatientSource);
            this.groupBox2.Controls.Add(this.txtResidenceplace);
            this.groupBox2.Controls.Add(this.label76);
            this.groupBox2.Controls.Add(this.label75);
            this.groupBox2.Controls.Add(this.llblMobileServer);
            this.groupBox2.Controls.Add(this.picMobile);
            this.groupBox2.Controls.Add(this.txtBirthPlace);
            this.groupBox2.Controls.Add(this.cboIsemployee);
            this.groupBox2.Controls.Add(this.m_txttNativeplace);
            this.groupBox2.Controls.Add(this.label74);
            this.groupBox2.Controls.Add(this.label67);
            this.groupBox2.Controls.Add(this.m_txtInsuredPayMoney);
            this.groupBox2.Controls.Add(this.m_txtInsuredPayTime);
            this.groupBox2.Controls.Add(this.m_txtInsuredMoney);
            this.groupBox2.Controls.Add(this.m_dtpBirthDate);
            this.groupBox2.Controls.Add(this.m_txtRelation);
            this.groupBox2.Controls.Add(this.m_txtOccupation);
            this.groupBox2.Controls.Add(this.m_txtPaytype);
            this.groupBox2.Controls.Add(this.m_txtRace);
            this.groupBox2.Controls.Add(this.m_txtAge);
            this.groupBox2.Controls.Add(this.label77);
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
            this.groupBox2.Controls.Add(this.初诊日期);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.dtpFirstDate);
            this.groupBox2.Controls.Add(this.txtContactpersonpc);
            this.groupBox2.Controls.Add(this.cobStatus);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_lblOperatorName);
            this.groupBox2.Controls.Add(this.m_chkISBOOKING_INT);
            this.groupBox2.Controls.Add(this.m_txtINPATIENTID_CHR);
            this.groupBox2.Controls.Add(this.m_txtFoodInfo);
            this.groupBox2.Controls.Add(this.m_txtCareInfo);
            this.groupBox2.Controls.Add(this.txtDeactivateDate);
            this.groupBox2.Controls.Add(this.txtOperatorid);
            this.groupBox2.Controls.Add(this.txtModifydate);
            this.groupBox2.Controls.Add(this.m_txtDEPTID_CHR);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label73);
            this.groupBox2.Controls.Add(this.label68);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 379);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.ForeColor = System.Drawing.Color.Blue;
            this.label79.Location = new System.Drawing.Point(28, 258);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(52, 14);
            this.label79.TabIndex = 315;
            this.label79.Text = "收件人";
            // 
            // txtConsigneeAddr
            // 
            this.txtConsigneeAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsigneeAddr.ForeColor = System.Drawing.Color.Blue;
            this.txtConsigneeAddr.Location = new System.Drawing.Point(336, 326);
            this.txtConsigneeAddr.MaxLength = 20;
            this.txtConsigneeAddr.Name = "txtConsigneeAddr";
            this.txtConsigneeAddr.Size = new System.Drawing.Size(664, 23);
            this.txtConsigneeAddr.TabIndex = 33;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.ForeColor = System.Drawing.Color.Blue;
            this.label66.Location = new System.Drawing.Point(256, 324);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(74, 24);
            this.label66.TabIndex = 314;
            this.label66.Text = "收件地址";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.ForeColor = System.Drawing.Color.Blue;
            this.label64.Location = new System.Drawing.Point(6, 322);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(74, 33);
            this.label64.TabIndex = 313;
            this.label64.Text = "移动电话收件电话";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(781, 106);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(63, 14);
            this.label78.TabIndex = 312;
            this.label78.Text = "病人来源";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.SystemColors.Window;
            this.txtMobile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtMobile.ForeColor = System.Drawing.Color.Blue;
            this.txtMobile.Location = new System.Drawing.Point(83, 326);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(148, 26);
            this.txtMobile.TabIndex = 32;
            // 
            // m_cboPatientSource
            // 
            this.m_cboPatientSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientSource.FormattingEnabled = true;
            this.m_cboPatientSource.Location = new System.Drawing.Point(849, 103);
            this.m_cboPatientSource.Name = "m_cboPatientSource";
            this.m_cboPatientSource.Size = new System.Drawing.Size(151, 22);
            this.m_cboPatientSource.TabIndex = 15;
            this.m_cboPatientSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPatientSource_KeyDown);
            // 
            // txtResidenceplace
            // 
            this.txtResidenceplace.Location = new System.Drawing.Point(591, 140);
            this.txtResidenceplace.MaxLength = 60;
            this.txtResidenceplace.Name = "txtResidenceplace";
            this.txtResidenceplace.Size = new System.Drawing.Size(410, 23);
            this.txtResidenceplace.TabIndex = 17;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(524, 143);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(63, 14);
            this.label76.TabIndex = 309;
            this.label76.Text = "户口地址";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(32, 143);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(49, 14);
            this.label75.TabIndex = 308;
            this.label75.Text = "出生地";
            // 
            // llblMobileServer
            // 
            this.llblMobileServer.AutoSize = true;
            this.llblMobileServer.ForeColor = System.Drawing.Color.Black;
            this.llblMobileServer.LinkArea = new System.Windows.Forms.LinkArea(0, 12);
            this.llblMobileServer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblMobileServer.LinkColor = System.Drawing.Color.Black;
            this.llblMobileServer.Location = new System.Drawing.Point(819, 294);
            this.llblMobileServer.Name = "llblMobileServer";
            this.llblMobileServer.Size = new System.Drawing.Size(175, 14);
            this.llblMobileServer.TabIndex = 32;
            this.llblMobileServer.TabStop = true;
            this.llblMobileServer.Text = "开通病人手机短信服务套餐";
            this.llblMobileServer.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llblMobileServer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMobileServer_LinkClicked);
            this.llblMobileServer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llblMobileServer_MouseClick);
            // 
            // picMobile
            // 
            this.picMobile.Image = ((System.Drawing.Image)(resources.GetObject("picMobile.Image")));
            this.picMobile.Location = new System.Drawing.Point(792, 293);
            this.picMobile.Name = "picMobile";
            this.picMobile.Size = new System.Drawing.Size(18, 14);
            this.picMobile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMobile.TabIndex = 306;
            this.picMobile.TabStop = false;
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.Location = new System.Drawing.Point(83, 140);
            this.txtBirthPlace.MaxLength = 50;
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(401, 23);
            this.txtBirthPlace.TabIndex = 16;
            // 
            // cboIsemployee
            // 
            this.cboIsemployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsemployee.Items.AddRange(new object[] {
            "1-否",
            "2-是"});
            this.cboIsemployee.Location = new System.Drawing.Point(591, 66);
            this.cboIsemployee.Name = "cboIsemployee";
            this.cboIsemployee.Size = new System.Drawing.Size(51, 22);
            this.cboIsemployee.TabIndex = 8;
            this.cboIsemployee.SelectedIndexChanged += new System.EventHandler(this.cboIsemployee_SelectedIndexChanged);
            this.cboIsemployee.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // m_txttNativeplace
            // 
            this.m_txttNativeplace.Location = new System.Drawing.Point(679, 66);
            this.m_txttNativeplace.Name = "m_txttNativeplace";
            this.m_txttNativeplace.Size = new System.Drawing.Size(63, 23);
            this.m_txttNativeplace.TabIndex = 9;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(643, 69);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 14);
            this.label74.TabIndex = 305;
            this.label74.Text = "籍贯";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(7, 282);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(74, 33);
            this.label67.TabIndex = 302;
            this.label67.Text = "医保剩余金额";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtInsuredPayMoney
            // 
            this.m_txtInsuredPayMoney.Location = new System.Drawing.Point(591, 288);
            this.m_txtInsuredPayMoney.MaxLength = 20;
            this.m_txtInsuredPayMoney.Name = "m_txtInsuredPayMoney";
            this.m_txtInsuredPayMoney.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredPayMoney.TabIndex = 31;
            this.m_txtInsuredPayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredPayMoney_KeyPress);
            // 
            // m_txtInsuredPayTime
            // 
            this.m_txtInsuredPayTime.Location = new System.Drawing.Point(336, 288);
            this.m_txtInsuredPayTime.MaxLength = 20;
            this.m_txtInsuredPayTime.Name = "m_txtInsuredPayTime";
            this.m_txtInsuredPayTime.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredPayTime.TabIndex = 30;
            this.m_txtInsuredPayTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredPayTime_KeyPress);
            // 
            // m_txtInsuredMoney
            // 
            this.m_txtInsuredMoney.Location = new System.Drawing.Point(83, 288);
            this.m_txtInsuredMoney.MaxLength = 20;
            this.m_txtInsuredMoney.Name = "m_txtInsuredMoney";
            this.m_txtInsuredMoney.Size = new System.Drawing.Size(148, 23);
            this.m_txtInsuredMoney.TabIndex = 29;
            this.m_txtInsuredMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtInsuredMoney_KeyPress);
            // 
            // m_dtpBirthDate
            // 
            this.m_dtpBirthDate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtpBirthDate.Location = new System.Drawing.Point(591, 29);
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
            this.m_txtOccupation.m_listViewSize = new System.Drawing.Point(200, 100);
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
            this.m_txtAge.Location = new System.Drawing.Point(681, 29);
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.Size = new System.Drawing.Size(58, 23);
            this.m_txtAge.TabIndex = 4;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.Location = new System.Drawing.Point(765, 103);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(15, 18);
            this.label77.TabIndex = 297;
            this.label77.Text = "*";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(781, 69);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(63, 14);
            this.label61.TabIndex = 294;
            this.label61.Text = "医疗证号";
            // 
            // m_txtGOVCARD_CHR
            // 
            this.m_txtGOVCARD_CHR.Location = new System.Drawing.Point(849, 66);
            this.m_txtGOVCARD_CHR.Name = "m_txtGOVCARD_CHR";
            this.m_txtGOVCARD_CHR.Size = new System.Drawing.Size(151, 23);
            this.m_txtGOVCARD_CHR.TabIndex = 10;
            this.m_txtGOVCARD_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmployeeEmptyItem_KeyDown);
            this.m_txtGOVCARD_CHR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMONEY_DEC_KeyPress);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(524, 69);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(63, 14);
            this.label57.TabIndex = 292;
            this.label57.Text = "是否职工";
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(507, 31);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(15, 18);
            this.label53.TabIndex = 291;
            this.label53.Text = "*";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.Location = new System.Drawing.Point(254, 67);
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
            this.label71.Location = new System.Drawing.Point(765, 31);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(17, 18);
            this.label71.TabIndex = 286;
            this.label71.Text = "*";
            // 
            // m_txtinsuranceid
            // 
            this.m_txtinsuranceid.Location = new System.Drawing.Point(337, 103);
            this.m_txtinsuranceid.MaxLength = 30;
            this.m_txtinsuranceid.Name = "m_txtinsuranceid";
            this.m_txtinsuranceid.Size = new System.Drawing.Size(147, 23);
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
            this.label65.Location = new System.Drawing.Point(4, 179);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(15, 18);
            this.label65.TabIndex = 281;
            this.label65.Text = "*";
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(4, 33);
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
            this.txtNationality.Location = new System.Drawing.Point(337, 66);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(147, 22);
            this.txtNationality.TabIndex = 7;
            this.txtNationality.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            this.txtNationality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageEmptyItem_KeyDown);
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(591, 103);
            this.txtIDCard.MaxLength = 50;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(151, 23);
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
            this.cboSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSex_KeyDown);
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
            this.label38.Location = new System.Drawing.Point(18, 33);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 14);
            this.label38.TabIndex = 35;
            this.label38.Text = "姓　　名";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(524, 33);
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
            this.m_cboInpatientNoType.Items.AddRange(new object[] {
            "1-正式",
            "2-留观"});
            this.m_cboInpatientNoType.Location = new System.Drawing.Point(167, 29);
            this.m_cboInpatientNoType.Name = "m_cboInpatientNoType";
            this.m_cboInpatientNoType.Size = new System.Drawing.Size(64, 22);
            this.m_cboInpatientNoType.TabIndex = 1;
            this.m_cboInpatientNoType.SelectedIndexChanged += new System.EventHandler(this.m_cboInpatientNoType_SelectedIndexChanged);
            this.m_cboInpatientNoType.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // cobMarried
            // 
            this.cobMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMarried.Location = new System.Drawing.Point(849, 29);
            this.cobMarried.Name = "cobMarried";
            this.cobMarried.Size = new System.Drawing.Size(151, 22);
            this.cobMarried.TabIndex = 5;
            this.cobMarried.Enter += new System.EventHandler(this.m_cboInpatientNoType_Enter);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 217);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 14);
            this.label31.TabIndex = 52;
            this.label31.Text = "职　　业";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 69);
            this.label33.Name = "label33";
            this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label33.Size = new System.Drawing.Size(63, 14);
            this.label33.TabIndex = 50;
            this.label33.Text = "民　　族";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(272, 69);
            this.label29.Name = "label29";
            this.label29.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 49;
            this.label29.Text = "国    籍";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(591, 177);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(148, 23);
            this.txtPhone.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(524, 180);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 14);
            this.label30.TabIndex = 55;
            this.label30.Text = "联系电话";
            // 
            // txtOfficepc
            // 
            this.txtOfficepc.Location = new System.Drawing.Point(849, 214);
            this.txtOfficepc.MaxLength = 6;
            this.txtOfficepc.Name = "txtOfficepc";
            this.txtOfficepc.Size = new System.Drawing.Size(151, 23);
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
            this.txtHomepc.Location = new System.Drawing.Point(849, 177);
            this.txtHomepc.MaxLength = 6;
            this.txtHomepc.Name = "txtHomepc";
            this.txtHomepc.Size = new System.Drawing.Size(151, 23);
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
            this.label23.Location = new System.Drawing.Point(28, 240);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 14);
            this.label23.TabIndex = 44;
            this.label23.Text = "联系人";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(524, 217);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 57;
            this.label27.Text = "办公地址";
            // 
            // txtOfficeAddress
            // 
            this.txtOfficeAddress.Location = new System.Drawing.Point(591, 214);
            this.txtOfficeAddress.MaxLength = 60;
            this.txtOfficeAddress.Name = "txtOfficeAddress";
            this.txtOfficeAddress.Size = new System.Drawing.Size(148, 23);
            this.txtOfficeAddress.TabIndex = 23;
            // 
            // txtContactpersonAddress
            // 
            this.txtContactpersonAddress.Location = new System.Drawing.Point(849, 251);
            this.txtContactpersonAddress.MaxLength = 100;
            this.txtContactpersonAddress.Name = "txtContactpersonAddress";
            this.txtContactpersonAddress.Size = new System.Drawing.Size(151, 23);
            this.txtContactpersonAddress.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(781, 254);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(63, 14);
            this.label19.TabIndex = 47;
            this.label19.Text = "联系地址";
            // 
            // txtContactpersonPhone
            // 
            this.txtContactpersonPhone.Location = new System.Drawing.Point(591, 251);
            this.txtContactpersonPhone.MaxLength = 20;
            this.txtContactpersonPhone.Name = "txtContactpersonPhone";
            this.txtContactpersonPhone.Size = new System.Drawing.Size(148, 23);
            this.txtContactpersonPhone.TabIndex = 27;
            // 
            // 初诊日期
            // 
            this.初诊日期.AutoSize = true;
            this.初诊日期.Location = new System.Drawing.Point(444, 548);
            this.初诊日期.Name = "初诊日期";
            this.初诊日期.Size = new System.Drawing.Size(63, 14);
            this.初诊日期.TabIndex = 79;
            this.初诊日期.Text = "初诊日期";
            this.初诊日期.Visible = false;
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
            // dtpFirstDate
            // 
            this.dtpFirstDate.Location = new System.Drawing.Point(404, 544);
            this.dtpFirstDate.Name = "dtpFirstDate";
            this.dtpFirstDate.Size = new System.Drawing.Size(136, 23);
            this.dtpFirstDate.TabIndex = 95;
            this.dtpFirstDate.Visible = false;
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
            // cobStatus
            // 
            this.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobStatus.Items.AddRange(new object[] {
            "",
            "有效",
            "无效",
            "历史"});
            this.cobStatus.Location = new System.Drawing.Point(540, 544);
            this.cobStatus.Name = "cobStatus";
            this.cobStatus.Size = new System.Drawing.Size(136, 22);
            this.cobStatus.TabIndex = 12;
            this.cobStatus.Visible = false;
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
            // m_chkISBOOKING_INT
            // 
            this.m_chkISBOOKING_INT.Location = new System.Drawing.Point(676, 516);
            this.m_chkISBOOKING_INT.Name = "m_chkISBOOKING_INT";
            this.m_chkISBOOKING_INT.Size = new System.Drawing.Size(136, 24);
            this.m_chkISBOOKING_INT.TabIndex = 43;
            this.m_chkISBOOKING_INT.Visible = false;
            // 
            // m_txtINPATIENTID_CHR
            // 
            this.m_txtINPATIENTID_CHR.Enabled = false;
            this.m_txtINPATIENTID_CHR.Location = new System.Drawing.Point(8, 516);
            this.m_txtINPATIENTID_CHR.MaxLength = 12;
            this.m_txtINPATIENTID_CHR.Name = "m_txtINPATIENTID_CHR";
            this.m_txtINPATIENTID_CHR.Size = new System.Drawing.Size(120, 23);
            this.m_txtINPATIENTID_CHR.TabIndex = 195;
            this.m_txtINPATIENTID_CHR.Visible = false;
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
            // m_txtDEPTID_CHR
            // 
            this.m_txtDEPTID_CHR.Enabled = false;
            this.m_txtDEPTID_CHR.Location = new System.Drawing.Point(132, 515);
            this.m_txtDEPTID_CHR.Name = "m_txtDEPTID_CHR";
            this.m_txtDEPTID_CHR.Size = new System.Drawing.Size(136, 23);
            this.m_txtDEPTID_CHR.TabIndex = 215;
            this.m_txtDEPTID_CHR.TabStop = false;
            this.m_txtDEPTID_CHR.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(524, 106);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 14);
            this.label36.TabIndex = 41;
            this.label36.Text = "身份证号";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(781, 33);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(63, 14);
            this.label42.TabIndex = 82;
            this.label42.Text = "婚　　否";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(781, 217);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 59;
            this.label26.Text = "办公邮编";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(781, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 60;
            this.label17.Text = "地址邮编";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(524, 254);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(63, 14);
            this.label22.TabIndex = 45;
            this.label22.Text = "联系电话";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(272, 33);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 14);
            this.label37.TabIndex = 6;
            this.label37.Text = "性　　别";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(272, 217);
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
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(486, 291);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(105, 14);
            this.label73.TabIndex = 304;
            this.label73.Text = "医保已报销金额";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(233, 291);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(105, 14);
            this.label68.TabIndex = 303;
            this.label68.Text = "医保已报销次数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(795, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 81;
            this.label10.Text = "籍    贯";
            this.label10.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(886, 298);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 67;
            this.label18.Text = "出 生 地";
            this.label18.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_lsvBihTransfer);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1020, 586);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "(2)查看流动记录";
            // 
            // m_lsvBihTransfer
            // 
            this.m_lsvBihTransfer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader10,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader33});
            this.m_lsvBihTransfer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lsvBihTransfer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBihTransfer.FullRowSelect = true;
            this.m_lsvBihTransfer.GridLines = true;
            this.m_lsvBihTransfer.Location = new System.Drawing.Point(0, 98);
            this.m_lsvBihTransfer.MultiSelect = false;
            this.m_lsvBihTransfer.Name = "m_lsvBihTransfer";
            this.m_lsvBihTransfer.Size = new System.Drawing.Size(1020, 488);
            this.m_lsvBihTransfer.TabIndex = 3;
            this.m_lsvBihTransfer.UseCompatibleStateImageBehavior = false;
            this.m_lsvBihTransfer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院次序数";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "调转日期";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 178;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "操作类型";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "原科室";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "原病区";
            this.columnHeader3.Width = 96;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "原病床";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "目标科室";
            this.columnHeader5.Width = 92;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "目标病区";
            this.columnHeader6.Width = 93;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "目标病床";
            this.columnHeader7.Width = 74;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "操作人";
            this.columnHeader9.Width = 81;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "备注";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "registerID";
            this.columnHeader33.Width = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_ckbTraDEPTAndBED);
            this.panel2.Controls.Add(this.m_ckbTraBed);
            this.panel2.Controls.Add(this.m_ckbOutHospital);
            this.panel2.Controls.Add(this.m_ckbInhospital);
            this.panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(384, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 40);
            this.panel2.TabIndex = 2;
            // 
            // m_ckbTraDEPTAndBED
            // 
            this.m_ckbTraDEPTAndBED.Checked = true;
            this.m_ckbTraDEPTAndBED.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbTraDEPTAndBED.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ckbTraDEPTAndBED.Location = new System.Drawing.Point(310, 8);
            this.m_ckbTraDEPTAndBED.Name = "m_ckbTraDEPTAndBED";
            this.m_ckbTraDEPTAndBED.Size = new System.Drawing.Size(58, 24);
            this.m_ckbTraDEPTAndBED.TabIndex = 4;
            this.m_ckbTraDEPTAndBED.Text = "转区";
            this.m_ckbTraDEPTAndBED.CheckedChanged += new System.EventHandler(this.m_ckbTraDEPTAndBED_CheckedChanged);
            // 
            // m_ckbTraBed
            // 
            this.m_ckbTraBed.Checked = true;
            this.m_ckbTraBed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbTraBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ckbTraBed.Location = new System.Drawing.Point(212, 8);
            this.m_ckbTraBed.Name = "m_ckbTraBed";
            this.m_ckbTraBed.Size = new System.Drawing.Size(60, 24);
            this.m_ckbTraBed.TabIndex = 3;
            this.m_ckbTraBed.Text = "调床";
            this.m_ckbTraBed.CheckedChanged += new System.EventHandler(this.m_ckbTraBed_CheckedChanged);
            // 
            // m_ckbOutHospital
            // 
            this.m_ckbOutHospital.Checked = true;
            this.m_ckbOutHospital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbOutHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ckbOutHospital.Location = new System.Drawing.Point(114, 8);
            this.m_ckbOutHospital.Name = "m_ckbOutHospital";
            this.m_ckbOutHospital.Size = new System.Drawing.Size(54, 24);
            this.m_ckbOutHospital.TabIndex = 1;
            this.m_ckbOutHospital.Text = "出院";
            this.m_ckbOutHospital.CheckedChanged += new System.EventHandler(this.m_ckbOutHospital_CheckedChanged);
            // 
            // m_ckbInhospital
            // 
            this.m_ckbInhospital.Checked = true;
            this.m_ckbInhospital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbInhospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ckbInhospital.Location = new System.Drawing.Point(16, 8);
            this.m_ckbInhospital.Name = "m_ckbInhospital";
            this.m_ckbInhospital.Size = new System.Drawing.Size(56, 24);
            this.m_ckbInhospital.TabIndex = 0;
            this.m_ckbInhospital.Text = "入院";
            this.m_ckbInhospital.CheckedChanged += new System.EventHandler(this.m_ckbInhospital_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_rdbCurrent);
            this.panel1.Controls.Add(this.m_rdbHistory);
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 40);
            this.panel1.TabIndex = 1;
            // 
            // m_rdbCurrent
            // 
            this.m_rdbCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.m_rdbCurrent.Checked = true;
            this.m_rdbCurrent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdbCurrent.Location = new System.Drawing.Point(8, 8);
            this.m_rdbCurrent.Name = "m_rdbCurrent";
            this.m_rdbCurrent.Size = new System.Drawing.Size(160, 24);
            this.m_rdbCurrent.TabIndex = 5;
            this.m_rdbCurrent.TabStop = true;
            this.m_rdbCurrent.Text = "本次住院的调转记录";
            this.m_rdbCurrent.UseVisualStyleBackColor = false;
            this.m_rdbCurrent.CheckedChanged += new System.EventHandler(this.m_rdbCurrent_CheckedChanged_1);
            // 
            // m_rdbHistory
            // 
            this.m_rdbHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdbHistory.Location = new System.Drawing.Point(184, 8);
            this.m_rdbHistory.Name = "m_rdbHistory";
            this.m_rdbHistory.Size = new System.Drawing.Size(160, 24);
            this.m_rdbHistory.TabIndex = 4;
            this.m_rdbHistory.Text = "历次住院的调转记录";
            this.m_rdbHistory.CheckedChanged += new System.EventHandler(this.m_rdbHistory_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_lsvBihLeave);
            this.tabPage4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1020, 586);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "(3)查看出院记录";
            // 
            // m_lsvBihLeave
            // 
            this.m_lsvBihLeave.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.m_lsvBihLeave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvBihLeave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBihLeave.FullRowSelect = true;
            this.m_lsvBihLeave.GridLines = true;
            this.m_lsvBihLeave.Location = new System.Drawing.Point(0, 0);
            this.m_lsvBihLeave.Name = "m_lsvBihLeave";
            this.m_lsvBihLeave.Size = new System.Drawing.Size(1020, 586);
            this.m_lsvBihLeave.TabIndex = 1;
            this.m_lsvBihLeave.UseCompatibleStateImageBehavior = false;
            this.m_lsvBihLeave.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "入院次序数";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "出院时间";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 200;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "出院类型";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "出院科室";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "出院病区";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "出院病床";
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "操作人";
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "备注";
            this.columnHeader20.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_lsvTurnInPation);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1020, 586);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "(4)门诊转入院";
            // 
            // m_lsvTurnInPation
            // 
            this.m_lsvTurnInPation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32});
            this.m_lsvTurnInPation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvTurnInPation.FullRowSelect = true;
            this.m_lsvTurnInPation.GridLines = true;
            this.m_lsvTurnInPation.Location = new System.Drawing.Point(0, 0);
            this.m_lsvTurnInPation.MultiSelect = false;
            this.m_lsvTurnInPation.Name = "m_lsvTurnInPation";
            this.m_lsvTurnInPation.Size = new System.Drawing.Size(1020, 586);
            this.m_lsvTurnInPation.TabIndex = 0;
            this.m_lsvTurnInPation.UseCompatibleStateImageBehavior = false;
            this.m_lsvTurnInPation.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "诊疗卡号";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "住院号";
            this.columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "病区";
            this.columnHeader24.Width = 120;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "病人姓名";
            this.columnHeader25.Width = 120;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "性别";
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "病情";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "费用类别";
            this.columnHeader28.Width = 110;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "门诊医生";
            this.columnHeader29.Width = 110;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "转入时间";
            this.columnHeader30.Width = 150;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "ArearID";
            this.columnHeader31.Width = 0;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "patientID";
            this.columnHeader32.Width = 0;
            // 
            // txtOfficephone
            // 
            this.txtOfficephone.Location = new System.Drawing.Point(588, 132);
            this.txtOfficephone.MaxLength = 20;
            this.txtOfficephone.Name = "txtOfficephone";
            this.txtOfficephone.Size = new System.Drawing.Size(148, 21);
            this.txtOfficephone.TabIndex = 17;
            // 
            // frmPatientRecord
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPatientRecord";
            this.Text = "住院登记";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.Activated += new System.EventHandler(this.frmPatientRecord_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPatientRecord_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegister_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMobile)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_Register();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化数据
        private void frmRegister_Load(object sender, System.EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtRace, m_txtPaytype, m_txtOccupation, m_txtRelation, m_txtAREAID, m_txtMaindoctor, cboSex, m_txtFindText });
            m_initTimer = new Timer();
            m_initTimer.Interval = 10;
            m_initTimer.Tick += new EventHandler(m_initTimer_Tick);
            m_initTimer.Start();
            ((clsCtl_Register)this.objController).m_mthInitYB();
        }
        private void m_initTimer_Tick(object sender, EventArgs e)
        {
            m_initTimer.Stop();
            m_initTimer = null;
            ((clsCtl_Register)this.objController).m_mthInit();
        }
        #endregion

        #region 事件
        private void cmdSaveBihRegister_Click(object sender, System.EventArgs e)
        {
            this.cmdSaveBihRegister.Enabled = false;
            ((clsCtl_Register)this.objController).m_mthSaveRegister();
            this.cmdSaveBihRegister.Enabled = true;
        }

        private void cmdBihTransfer_Click(object sender, System.EventArgs e)
        {
            //			((clsCtl_Register)this.objController).m_BihTransfer();
        }

        private void cmdBihLeave_Click(object sender, System.EventArgs e)
        {
            //			((clsCtl_Register)this.objController).m_BihLeave();
        }

        private void cmdEmpty_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).m_EmptyAndInitialization();
        }

        private void m_rdbCurrent_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }

        private void cmdRefurbish_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).m_mthFresh();
        }

        /// <summary>
        /// 切换光标标志
        /// </summary>
        int flag = 0;
        private void frmRegister_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //if (MessageBox.Show(this, "确认要退出吗？", "入院登记", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                        this.Close();
                    //}
                    break;
                case Keys.F2:
                    ((clsCtl_Register)objController).m_mthSaveRegister();
                    break;
                case Keys.F3:
                    ((clsCtl_Register)objController).m_mthFindPatient();
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
                case Keys.F8:
                    ((clsCtl_Register)this.objController).m_mthPationRecord();
                    break;
                case Keys.Enter:
                    m_mthSetKeyTab(e);
                    break;
                default:
                    break;
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void m_ckbInhospital_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }

        private void m_ckbOutHospital_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }

        private void m_ckbTraDept_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }

        private void m_ckbTraBed_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }
        #region 科室、病区、床号
        private void m_txtDEPTID_CHR_Leave(object sender, System.EventArgs e)
        {
            m_txtAREAID.Text = "";
        }

        private void m_txtDEPTID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtAREAID.Focus();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                //				this.m_txtDEPTID_CHR.lsvContext.Focus();
            }
        }

        //private void m_txtAREAID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //m_txtBEDID_CHR.Focus();
        //        m_txtDIAGNOSE_VCHR.Focus();
        //    }
        //    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
        //    {
        //        //				this.m_txtAREAID_CHR.lsvContext.Focus();
        //    }
        //}

        private void m_txtBEDID_CHR_Leave(object sender, System.EventArgs e)
        {

        }

        private void m_txtBEDID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_chkISBOOKING_INT.Focus();
            }
        }

        #endregion

        private void m_ckbTraDEPTAndBED_CheckedChanged(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).LoadBihTransfer();
        }

        private void m_rdbHistory_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_rdbHistory.Checked == true)
            {
                ((clsCtl_Register)this.objController).LoadBihTransfer();
                m_rdbCurrent.Checked = false;
            }
        }

        private void m_rdbCurrent_CheckedChanged_1(object sender, System.EventArgs e)
        {
            if (m_rdbCurrent.Checked == true)
            {
                ((clsCtl_Register)this.objController).LoadBihTransfer();
                m_rdbHistory.Checked = false;
            }
        }


        private void m_cmdGetChargeForm_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)objController).m_mthPationRecord();
        }

        #endregion

        #region 查找病人
        private void m_cmdFindPatient_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_Register)this.objController).m_mthFindPatient();
        }
        #endregion

        #region	历史费用查询
        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            if (m_lsvBihTransfer.SelectedItems.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.frmReserve frm = new com.digitalwave.iCare.gui.HIS.frmReserve();
                frm.SetRegisterid(m_lsvBihTransfer.SelectedItems[0].SubItems[11].Text.Trim());
                frm.LoginInfo = this.LoginInfo;
                frm.Show_MDI_Child((System.Windows.Forms.Form)this.ParentForm);
            }
        }

        #endregion

        #region 查询同名病人同时调出病人信息,如果没有同名病人则调出病人登记
        private void cboSex_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_Register)this.objController).m_mthFindPatientInfoByName();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 处理预交金额
        private void m_txtMONEY_DEC_Leave(object sender, EventArgs e)
        {
            ((clsCtl_Register)objController).m_mthSetFocus();
        }
        #endregion

        #region 设置联系人
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
           txtContactpersonFirstaName.Text = txtPatientName.Text.Trim();
       }
        #endregion

        #region 正式留观撤换时刷新入院次数
       private void m_cboInpatientNoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_Register)this.objController).m_mthFreshInTime();
        }
       #endregion

        #region 根据病人诊疗卡号或住院号获取病人ID
        private void m_txtFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Register)this.objController).m_mthGetPatientIDByCarIDOrInPatientID();
            }
        }
        #endregion

        #region 是否职工
        private void cboIsemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboIsemployee.SelectedIndex==1)
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
            ((clsCtl_Register)this.objController).m_mthSetPatType();
        }
        #endregion

        // 对用用户输入操作的控制
        #region 处理带*号不能为空的项
        private void ManageEmptyItem_KeyDown(object sender, KeyEventArgs e)
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

        #region 处理医保病人不能为空的项
        private void ManageTinsuranceEmptyItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_Register)objController).m_mthManagTinsuranceEmpty(sender, e);
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
                    ((clsCtl_Register)objController).m_mthManagEmployeeEmpty(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 控制预交金只可输入数字
        private void m_txtMONEY_DEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 身份证号输入控制
        private void ManageIdentity_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_Register)objController).m_mthManageIdentity();
                    break;
                default:
                    break;
            }
        }

        private void txtIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

        #region 对家庭地址输入控制
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ((clsCtl_Register)objController).m_mthAddressIdentity();
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
            ((clsCtl_Register)objController).m_mthCalculateAge();
        }
        #endregion

        #region 用鼠标点击病区,门诊医生时选中中本
        private void m_txtMaindoctor_MouseDown(object sender, MouseEventArgs e)
        {
            ((ControlLibrary.txtListView)sender).SelectAll();
        }
        #endregion

        #region 激活窗体时重新获取预交金号
        private void frmPatientRecord_Activated(object sender, EventArgs e)
        {
            ((clsCtl_Register)objController).m_strReadInvoiceNO();
        }
        #endregion

        private void frmPatientRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "确认要退出吗？", "入院登记", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void m_txtInsuredMoney_KeyPress(object sender, KeyPressEventArgs e)
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

        private void llblMobileServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("服务套餐正在维护中...", "很抱歉", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                        
            this.m_dateInHosp.Focus();
        }
     
        private void llblMobileServer_MouseClick(object sender, MouseEventArgs e)
        {
            frmMobileServiceOrder f = new frmMobileServiceOrder();
            f.ShowDialog();            
        }
        //加入嵌入式社保调用登记窗体
        private void btnYBReg_Click(object sender, EventArgs e)
        {
            ((clsCtl_Register)objController).m_mthYBPatient();
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

        //#region 对病人来源输入控制
        //private void m_cboPatientSource_Enter(object sender, EventArgs e)
        //{
        //    m_comBox = ((ComboBox)sender);
        //    m_timer.Start();
        //}
        //#endregion         
       
    }

    #region 排序类
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder _order;

        public ListViewItemComparer()
        {
            col = 0;
            this._order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this._order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            if (_order == SortOrder.Descending)
            {
                returnVal *= -1;
            }
            return returnVal;
        }
    }
    #endregion
}
