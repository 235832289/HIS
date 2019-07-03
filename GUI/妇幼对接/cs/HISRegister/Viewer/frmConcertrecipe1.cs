using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmConcertrecipe1 的摘要说明。
    /// </summary>
    public class frmConcertrecipe1 : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox m_txtCode;
        internal System.Windows.Forms.TextBox m_txtPy;
        internal System.Windows.Forms.TextBox m_txtWb;
        internal System.Windows.Forms.TextBox m_txtType;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox m_txtSpace;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox m_txtItemName;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox m_txtUnprir;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        internal PinkieControls.ButtonXP buttonXP2;
        internal System.Windows.Forms.TextBox m_txtFrequency;
        internal System.Windows.Forms.TextBox m_txtUse;
        internal System.Windows.Forms.Panel panel3;
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgConcertrecipeDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgConcertrecipe;
        internal PinkieControls.ButtonXP btnAdd;
        internal PinkieControls.ButtonXP btnClear;
        internal System.Windows.Forms.RadioButton RdbtnFaculty;
        internal System.Windows.Forms.RadioButton RadtnPrivy;
        internal System.Windows.Forms.RadioButton RdbtnUse;
        internal PinkieControls.ButtonXP btnDele;
        internal PinkieControls.ButtonXP btnFind;
        internal PinkieControls.ButtonXP m_btnSave;
        internal PinkieControls.ButtonXP m_btnAddNew;
        internal com.digitalwave.controls.datagrid.ctlDataGrid DgItem;
        internal System.Windows.Forms.TextBox m_txtFindTtem;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Panel pnldg;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Panel m_pnlAllPlan;
        internal System.Windows.Forms.ListView m_lsvAllpay;
        internal System.Windows.Forms.ListView m_lsvAlldoc;
        internal System.Windows.Forms.ListView m_lsvAlldept;
        internal System.Windows.Forms.ListView m_lsvAllregtype;
        internal System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        internal PinkieControls.ButtonXP btnFindData;
        internal PinkieControls.ButtonXP btnReturn;
        internal System.Windows.Forms.TextBox m_txtNamefind;
        internal System.Windows.Forms.TextBox m_txtCodeHelp;
        internal System.Windows.Forms.TextBox m_txtFindPy;
        internal System.Windows.Forms.TextBox m_txtWBCode;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtTQY;
        internal System.Windows.Forms.Label lblUnit;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtDOSAGEQTY;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label labSageUnit;
        private System.Windows.Forms.Label label18;
        internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboPatType;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtDay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric textBoxTypedNumeric1;
        internal PinkieControls.ButtonXP buttonXP1;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label label24;
        internal com.digitalwave.controls.ctlTextBoxFind m_ctlPark;
        internal com.digitalwave.controls.ctlTextBoxFind ctlTextBoxFind1;
        internal PinkieControls.ButtonXP buttonXP3;
        internal System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ColumnHeader ID;
        private IContainer components;
        private Label label25;
        internal TextBox txtTjtc;
        internal ListView lsvItemTc;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;

        /// <summary>
        /// 标志当前用户是否有编辑公用处方的权限
        /// </summary>
        public bool isPublic = false;

        public frmConcertrecipe1()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            clsDomainConrol_ConcertreCipe doMain = new clsDomainConrol_ConcertreCipe();
            doMain.m_lngGetPublic(this.LoginInfo.m_strEmpID, out isPublic);
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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConcertrecipe1));
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo23 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo24 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo25 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo26 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo27 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo28 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo29 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo30 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo31 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo32 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo33 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo34 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo35 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo36 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo37 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo38 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo39 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo40 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo41 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo42 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo43 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo44 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTjtc = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RdbtnFaculty = new System.Windows.Forms.RadioButton();
            this.RadtnPrivy = new System.Windows.Forms.RadioButton();
            this.RdbtnUse = new System.Windows.Forms.RadioButton();
            this.m_txtWb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtPy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_ctlPark = new com.digitalwave.controls.ctlTextBoxFind();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.btnClear = new PinkieControls.ButtonXP();
            this.textBoxTypedNumeric1 = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtUnprir = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtDay = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_cboPatType = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.labSageUnit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtTQY = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtFindTtem = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtFrequency = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtUse = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtDOSAGEQTY = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.lblUnit = new System.Windows.Forms.Label();
            this.m_txtType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtSpace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtItemName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDele = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnAddNew = new PinkieControls.ButtonXP();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_dtgConcertrecipeDetail = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.DgItem = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReturn = new PinkieControls.ButtonXP();
            this.btnFindData = new PinkieControls.ButtonXP();
            this.m_txtWBCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtFindPy = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtCodeHelp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtNamefind = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_dtgConcertrecipe = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.pnldg = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.ctlTextBoxFind1 = new com.digitalwave.controls.ctlTextBoxFind();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.m_pnlAllPlan = new System.Windows.Forms.Panel();
            this.m_lsvAllpay = new System.Windows.Forms.ListView();
            this.m_lsvAlldoc = new System.Windows.Forms.ListView();
            this.m_lsvAlldept = new System.Windows.Forms.ListView();
            this.m_lsvAllregtype = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lsvItemTc = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipeDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipe)).BeginInit();
            this.pnldg.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_pnlAllPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtTjtc);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.m_txtWb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtPy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtTjtc
            // 
            this.txtTjtc.BackColor = System.Drawing.SystemColors.Window;
            this.txtTjtc.Location = new System.Drawing.Point(72, 116);
            this.txtTjtc.MaxLength = 30;
            this.txtTjtc.Name = "txtTjtc";
            this.txtTjtc.Size = new System.Drawing.Size(360, 23);
            this.txtTjtc.TabIndex = 80;
            this.txtTjtc.DoubleClick += new System.EventHandler(this.txtTjtc_DoubleClick);
            this.txtTjtc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTjtc_KeyDown);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 116);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 79;
            this.label25.Text = "体检套餐";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(72, 72);
            this.textBox1.MaxLength = 1000;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(360, 40);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 23);
            this.label22.TabIndex = 9;
            this.label22.Text = "备    注";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.RdbtnFaculty);
            this.panel2.Controls.Add(this.RadtnPrivy);
            this.panel2.Controls.Add(this.RdbtnUse);
            this.panel2.Location = new System.Drawing.Point(440, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 128);
            this.panel2.TabIndex = 8;
            // 
            // RdbtnFaculty
            // 
            this.RdbtnFaculty.Location = new System.Drawing.Point(8, 88);
            this.RdbtnFaculty.Name = "RdbtnFaculty";
            this.RdbtnFaculty.Size = new System.Drawing.Size(104, 24);
            this.RdbtnFaculty.TabIndex = 2;
            this.RdbtnFaculty.Text = "科室";
            this.RdbtnFaculty.CheckedChanged += new System.EventHandler(this.RdbtnUse_CheckedChanged);
            this.RdbtnFaculty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RdbtnFaculty_KeyDown);
            // 
            // RadtnPrivy
            // 
            this.RadtnPrivy.Checked = true;
            this.RadtnPrivy.Location = new System.Drawing.Point(8, 8);
            this.RadtnPrivy.Name = "RadtnPrivy";
            this.RadtnPrivy.Size = new System.Drawing.Size(104, 24);
            this.RadtnPrivy.TabIndex = 0;
            this.RadtnPrivy.TabStop = true;
            this.RadtnPrivy.Text = "私用";
            this.RadtnPrivy.CheckedChanged += new System.EventHandler(this.RdbtnUse_CheckedChanged);
            this.RadtnPrivy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadtnPrivy_KeyDown);
            // 
            // RdbtnUse
            // 
            this.RdbtnUse.Location = new System.Drawing.Point(8, 48);
            this.RdbtnUse.Name = "RdbtnUse";
            this.RdbtnUse.Size = new System.Drawing.Size(104, 24);
            this.RdbtnUse.TabIndex = 1;
            this.RdbtnUse.Text = "公用";
            this.RdbtnUse.CheckedChanged += new System.EventHandler(this.RdbtnUse_CheckedChanged);
            this.RdbtnUse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RdbtnUse_KeyDown);
            // 
            // m_txtWb
            // 
            this.m_txtWb.Enabled = false;
            this.m_txtWb.Location = new System.Drawing.Point(360, 45);
            this.m_txtWb.Name = "m_txtWb";
            this.m_txtWb.ReadOnly = true;
            this.m_txtWb.Size = new System.Drawing.Size(72, 23);
            this.m_txtWb.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(312, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "五笔码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPy
            // 
            this.m_txtPy.Enabled = false;
            this.m_txtPy.Location = new System.Drawing.Point(240, 45);
            this.m_txtPy.Name = "m_txtPy";
            this.m_txtPy.ReadOnly = true;
            this.m_txtPy.Size = new System.Drawing.Size(72, 23);
            this.m_txtPy.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "拼音码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCode
            // 
            this.m_txtCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.m_txtCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtCode.Location = new System.Drawing.Point(72, 45);
            this.m_txtCode.MaxLength = 10;
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(112, 23);
            this.m_txtCode.TabIndex = 1;
            this.m_txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCode_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "助 记 码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtName
            // 
            this.m_txtName.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtName.Location = new System.Drawing.Point(72, 16);
            this.m_txtName.MaxLength = 30;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(360, 23);
            this.m_txtName.TabIndex = 0;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            this.m_txtName.Leave += new System.EventHandler(this.m_txtName_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "处方名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.m_ctlPark);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.textBoxTypedNumeric1);
            this.groupBox2.Controls.Add(this.m_txtUnprir);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.m_txtDay);
            this.groupBox2.Controls.Add(this.m_cboPatType);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.labSageUnit);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txtTQY);
            this.groupBox2.Controls.Add(this.m_txtFindTtem);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.m_txtFrequency);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.m_txtUse);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_txtDOSAGEQTY);
            this.groupBox2.Controls.Add(this.lblUnit);
            this.groupBox2.Controls.Add(this.m_txtType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.m_txtSpace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.m_txtItemName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(4, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 144);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // m_ctlPark
            // 
            this.m_ctlPark.Enabled = false;
            this.m_ctlPark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctlPark.intHeight = 100;
            this.m_ctlPark.IsEnterShow = true;
            this.m_ctlPark.isHide = 3;
            this.m_ctlPark.isTxt = 0;
            this.m_ctlPark.isUpOrDn = 1;
            this.m_ctlPark.isValuse = 3;
            this.m_ctlPark.Location = new System.Drawing.Point(384, 112);
            this.m_ctlPark.m_IsHaveParent = false;
            this.m_ctlPark.m_strParentName = "";
            this.m_ctlPark.Name = "m_ctlPark";
            this.m_ctlPark.nextCtl = null;
            this.m_ctlPark.Size = new System.Drawing.Size(112, 24);
            this.m_ctlPark.TabIndex = 25;
            this.m_ctlPark.txtValuse = "";
            this.m_ctlPark.VsLeftOrRight = 1;
            this.m_ctlPark.Leave += new System.EventHandler(this.m_ctlPark_Leave);
            this.m_ctlPark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_ctlPark_KeyDown);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(296, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 23);
            this.label24.TabIndex = 53;
            this.label24.Text = "天";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(344, 113);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 51;
            this.label23.Text = "部位";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAdd);
            this.groupBox5.Controls.Add(this.buttonXP1);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Location = new System.Drawing.Point(508, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(124, 76);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(4, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAdd.Size = new System.Drawing.Size(120, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "增加明细(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(4, 48);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(60, 23);
            this.buttonXP1.TabIndex = 49;
            this.buttonXP1.Text = "删除(&M)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClear.DefaultScheme = true;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.Hint = "";
            this.btnClear.Location = new System.Drawing.Point(64, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "清空(&B)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxTypedNumeric1
            // 
            this.textBoxTypedNumeric1.EnableAutoValidation = false;
            this.textBoxTypedNumeric1.EnableEnterKeyValidate = true;
            this.textBoxTypedNumeric1.EnableEscapeKeyUndo = true;
            this.textBoxTypedNumeric1.EnableLastValidValue = true;
            this.textBoxTypedNumeric1.ErrorProvider = null;
            this.textBoxTypedNumeric1.ErrorProviderMessage = "Invalid value";
            this.textBoxTypedNumeric1.ForceFormatText = true;
            this.textBoxTypedNumeric1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxTypedNumeric1.Location = new System.Drawing.Point(456, 48);
            this.textBoxTypedNumeric1.MaxLength = 2;
            this.textBoxTypedNumeric1.Name = "textBoxTypedNumeric1";
            this.textBoxTypedNumeric1.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.textBoxTypedNumeric1.Size = new System.Drawing.Size(40, 23);
            this.textBoxTypedNumeric1.TabIndex = 13;
            this.textBoxTypedNumeric1.Text = "0";
            this.textBoxTypedNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTypedNumeric1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTypedNumeric1_KeyDown);
            this.textBoxTypedNumeric1.Leave += new System.EventHandler(this.textBoxTypedNumeric1_Leave);
            this.textBoxTypedNumeric1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTypedNumeric1_KeyPress);
            // 
            // m_txtUnprir
            // 
            this.m_txtUnprir.Location = new System.Drawing.Point(384, 48);
            this.m_txtUnprir.Name = "m_txtUnprir";
            this.m_txtUnprir.ReadOnly = true;
            this.m_txtUnprir.Size = new System.Drawing.Size(40, 23);
            this.m_txtUnprir.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(424, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 23);
            this.label21.TabIndex = 48;
            this.label21.Text = "方号";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(184, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 47;
            this.label20.Text = "天    数";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDay
            // 
            this.m_txtDay.EnableAutoValidation = false;
            this.m_txtDay.EnableEnterKeyValidate = true;
            this.m_txtDay.EnableEscapeKeyUndo = true;
            this.m_txtDay.EnableLastValidValue = true;
            this.m_txtDay.ErrorProvider = null;
            this.m_txtDay.ErrorProviderMessage = "Invalid value";
            this.m_txtDay.ForceFormatText = true;
            this.m_txtDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtDay.Location = new System.Drawing.Point(248, 113);
            this.m_txtDay.MaxLength = 10;
            this.m_txtDay.Name = "m_txtDay";
            this.m_txtDay.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtDay.Size = new System.Drawing.Size(48, 23);
            this.m_txtDay.TabIndex = 24;
            this.m_txtDay.Text = "0";
            this.m_txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDay_KeyDown);
            this.m_txtDay.Leave += new System.EventHandler(this.m_txtDay_Leave);
            // 
            // m_cboPatType
            // 
            this.m_cboPatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatType.Location = new System.Drawing.Point(72, 16);
            this.m_cboPatType.Name = "m_cboPatType";
            this.m_cboPatType.Size = new System.Drawing.Size(104, 22);
            this.m_cboPatType.TabIndex = 44;
            this.m_cboPatType.SelectedIndexChanged += new System.EventHandler(this.m_cboOPInv_SelectedIndexChanged);
            this.m_cboPatType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPatType_KeyDown);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 31;
            this.label18.Text = "病人类别";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labSageUnit
            // 
            this.labSageUnit.Location = new System.Drawing.Point(128, 80);
            this.labSageUnit.Name = "labSageUnit";
            this.labSageUnit.Size = new System.Drawing.Size(48, 23);
            this.labSageUnit.TabIndex = 30;
            this.labSageUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "剂    量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTQY
            // 
            this.m_txtTQY.EnableAutoValidation = false;
            this.m_txtTQY.EnableEnterKeyValidate = true;
            this.m_txtTQY.EnableEscapeKeyUndo = true;
            this.m_txtTQY.EnableLastValidValue = true;
            this.m_txtTQY.ErrorProvider = null;
            this.m_txtTQY.ErrorProviderMessage = "Invalid value";
            this.m_txtTQY.ForceFormatText = true;
            this.m_txtTQY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtTQY.Location = new System.Drawing.Point(248, 80);
            this.m_txtTQY.MaxLength = 10;
            this.m_txtTQY.Name = "m_txtTQY";
            this.m_txtTQY.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtTQY.Size = new System.Drawing.Size(48, 23);
            this.m_txtTQY.TabIndex = 28;
            this.m_txtTQY.Text = "0";
            this.m_txtTQY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtTQY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtTQY_KeyDown);
            // 
            // m_txtFindTtem
            // 
            this.m_txtFindTtem.Location = new System.Drawing.Point(248, 16);
            this.m_txtFindTtem.Name = "m_txtFindTtem";
            this.m_txtFindTtem.Size = new System.Drawing.Size(88, 23);
            this.m_txtFindTtem.TabIndex = 27;
            this.m_txtFindTtem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindTtem_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(184, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 26;
            this.label13.Text = "项目查找";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtFrequency
            // 
            this.m_txtFrequency.Location = new System.Drawing.Point(72, 113);
            this.m_txtFrequency.Name = "m_txtFrequency";
            this.m_txtFrequency.Size = new System.Drawing.Size(112, 23);
            this.m_txtFrequency.TabIndex = 23;
            this.m_txtFrequency.TextChanged += new System.EventHandler(this.m_txtFrequency_TextChanged);
            this.m_txtFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFrequency_KeyDown);
            this.m_txtFrequency.Leave += new System.EventHandler(this.m_txtFrequency_Leave);
            this.m_txtFrequency.Enter += new System.EventHandler(this.m_txtFrequency_Enter);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "频    率";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtUse
            // 
            this.m_txtUse.Location = new System.Drawing.Point(384, 80);
            this.m_txtUse.Name = "m_txtUse";
            this.m_txtUse.Size = new System.Drawing.Size(112, 23);
            this.m_txtUse.TabIndex = 21;
            this.m_txtUse.TextChanged += new System.EventHandler(this.m_txtUse_TextChanged);
            this.m_txtUse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUse_KeyDown);
            this.m_txtUse.Leave += new System.EventHandler(this.m_txtUse_Leave);
            this.m_txtUse.Enter += new System.EventHandler(this.m_txtUse_Enter);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(344, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "用法";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(184, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 18;
            this.label12.Text = "数    量";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(344, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "单价";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDOSAGEQTY
            // 
            this.m_txtDOSAGEQTY.EnableAutoValidation = false;
            this.m_txtDOSAGEQTY.EnableEnterKeyValidate = true;
            this.m_txtDOSAGEQTY.EnableEscapeKeyUndo = true;
            this.m_txtDOSAGEQTY.EnableLastValidValue = true;
            this.m_txtDOSAGEQTY.ErrorProvider = null;
            this.m_txtDOSAGEQTY.ErrorProviderMessage = "Invalid value";
            this.m_txtDOSAGEQTY.ForceFormatText = true;
            this.m_txtDOSAGEQTY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtDOSAGEQTY.Location = new System.Drawing.Point(72, 80);
            this.m_txtDOSAGEQTY.Name = "m_txtDOSAGEQTY";
            this.m_txtDOSAGEQTY.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtDOSAGEQTY.Size = new System.Drawing.Size(56, 23);
            this.m_txtDOSAGEQTY.TabIndex = 15;
            this.m_txtDOSAGEQTY.Text = "0";
            this.m_txtDOSAGEQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDOSAGEQTY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDOSAGEQTY_KeyDown);
            this.m_txtDOSAGEQTY.Leave += new System.EventHandler(this.m_txtDOSAGEQTY_Leave);
            // 
            // lblUnit
            // 
            this.lblUnit.Location = new System.Drawing.Point(304, 80);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 23);
            this.lblUnit.TabIndex = 14;
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtType
            // 
            this.m_txtType.Location = new System.Drawing.Point(248, 48);
            this.m_txtType.Name = "m_txtType";
            this.m_txtType.ReadOnly = true;
            this.m_txtType.Size = new System.Drawing.Size(88, 23);
            this.m_txtType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(184, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "类    型";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSpace
            // 
            this.m_txtSpace.Location = new System.Drawing.Point(72, 48);
            this.m_txtSpace.Name = "m_txtSpace";
            this.m_txtSpace.ReadOnly = true;
            this.m_txtSpace.Size = new System.Drawing.Size(104, 23);
            this.m_txtSpace.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "规    格";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtItemName
            // 
            this.m_txtItemName.Location = new System.Drawing.Point(384, 16);
            this.m_txtItemName.Name = "m_txtItemName";
            this.m_txtItemName.ReadOnly = true;
            this.m_txtItemName.Size = new System.Drawing.Size(112, 23);
            this.m_txtItemName.TabIndex = 9;
            this.m_txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtItemName_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(336, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "名称";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDele);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnAddNew);
            this.panel1.Location = new System.Drawing.Point(384, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 40);
            this.panel1.TabIndex = 48;
            // 
            // btnDele
            // 
            this.btnDele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDele.DefaultScheme = true;
            this.btnDele.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDele.Hint = "";
            this.btnDele.Location = new System.Drawing.Point(272, 3);
            this.btnDele.Name = "btnDele";
            this.btnDele.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDele.Size = new System.Drawing.Size(88, 32);
            this.btnDele.TabIndex = 12;
            this.btnDele.Text = "删除(&D)";
            this.btnDele.Click += new System.EventHandler(this.btnDele_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(394, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(84, 32);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "查找(&C)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(512, 3);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(88, 32);
            this.buttonXP2.TabIndex = 9;
            this.buttonXP2.Text = "退出(ESC)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(154, 3);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(84, 32);
            this.m_btnSave.TabIndex = 8;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnAddNew
            // 
            this.m_btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnAddNew.DefaultScheme = true;
            this.m_btnAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddNew.Hint = "";
            this.m_btnAddNew.Location = new System.Drawing.Point(32, 3);
            this.m_btnAddNew.Name = "m_btnAddNew";
            this.m_btnAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddNew.Size = new System.Drawing.Size(88, 32);
            this.m_btnAddNew.TabIndex = 7;
            this.m_btnAddNew.Text = "新建(&N)";
            this.m_btnAddNew.Click += new System.EventHandler(this.m_btnAddNew_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_dtgConcertrecipeDetail);
            this.panel3.Location = new System.Drawing.Point(384, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 264);
            this.panel3.TabIndex = 49;
            // 
            // m_dtgConcertrecipeDetail
            // 
            this.m_dtgConcertrecipeDetail.AllowAddNew = false;
            this.m_dtgConcertrecipeDetail.AllowDelete = false;
            this.m_dtgConcertrecipeDetail.AutoAppendRow = false;
            this.m_dtgConcertrecipeDetail.AutoScroll = true;
            this.m_dtgConcertrecipeDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dtgConcertrecipeDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgConcertrecipeDetail.CaptionText = "";
            this.m_dtgConcertrecipeDetail.CaptionVisible = false;
            this.m_dtgConcertrecipeDetail.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "Column1";
            clsColumnInfo1.ColumnWidth = 0;
            clsColumnInfo1.Enabled = true;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "Column1";
            clsColumnInfo1.ReadOnly = false;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "ROWNO_CHR";
            clsColumnInfo2.ColumnWidth = 40;
            clsColumnInfo2.Enabled = true;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "方号";
            clsColumnInfo2.ReadOnly = false;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "ITEMNAME_VCHR";
            clsColumnInfo3.ColumnWidth = 150;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "项目名称";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "ITEMSPEC_VCHR";
            clsColumnInfo4.ColumnWidth = 75;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "规格";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "ItemType";
            clsColumnInfo5.ColumnWidth = 40;
            clsColumnInfo5.Enabled = false;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "类型";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "ITEMPRICE_MNY";
            clsColumnInfo6.ColumnWidth = 75;
            clsColumnInfo6.Enabled = false;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "单价";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "剂量";
            clsColumnInfo7.ColumnWidth = 50;
            clsColumnInfo7.Enabled = false;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "剂量";
            clsColumnInfo7.ReadOnly = true;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "剂量单位";
            clsColumnInfo8.ColumnWidth = 75;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "剂量单位";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "QTY_DEC";
            clsColumnInfo9.ColumnWidth = 50;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "数量";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "ITEMOPUNIT_CHR";
            clsColumnInfo10.ColumnWidth = 40;
            clsColumnInfo10.Enabled = false;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "单位";
            clsColumnInfo10.ReadOnly = true;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "usagename_vchr";
            clsColumnInfo11.ColumnWidth = 75;
            clsColumnInfo11.Enabled = false;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "用法";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 11;
            clsColumnInfo12.ColumnName = "freqname_chr";
            clsColumnInfo12.ColumnWidth = 75;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "频率";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 12;
            clsColumnInfo13.ColumnName = "PARTORTYPENAME_VCHR";
            clsColumnInfo13.ColumnWidth = 75;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "部位/样本";
            clsColumnInfo13.ReadOnly = true;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 13;
            clsColumnInfo14.ColumnName = "RECIPEID_CHR";
            clsColumnInfo14.ColumnWidth = 0;
            clsColumnInfo14.Enabled = true;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "协处方ID";
            clsColumnInfo14.ReadOnly = false;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo15.ColumnIndex = 14;
            clsColumnInfo15.ColumnName = "DETAILID_CHR";
            clsColumnInfo15.ColumnWidth = 0;
            clsColumnInfo15.Enabled = true;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "明细ID";
            clsColumnInfo15.ReadOnly = false;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 15;
            clsColumnInfo16.ColumnName = "ITEMID_CHR";
            clsColumnInfo16.ColumnWidth = 0;
            clsColumnInfo16.Enabled = true;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "项目ID";
            clsColumnInfo16.ReadOnly = false;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo17.ColumnIndex = 16;
            clsColumnInfo17.ColumnName = "DOSETYPE_CHR";
            clsColumnInfo17.ColumnWidth = 0;
            clsColumnInfo17.Enabled = true;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "用法ID";
            clsColumnInfo17.ReadOnly = false;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 17;
            clsColumnInfo18.ColumnName = "FREQID_CHR";
            clsColumnInfo18.ColumnWidth = 0;
            clsColumnInfo18.Enabled = true;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "执行频率id";
            clsColumnInfo18.ReadOnly = false;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 18;
            clsColumnInfo19.ColumnName = "day";
            clsColumnInfo19.ColumnWidth = 80;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "天数";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo20.ColumnIndex = 19;
            clsColumnInfo20.ColumnName = "tolMeny";
            clsColumnInfo20.ColumnWidth = 75;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "合计金额";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 20;
            clsColumnInfo21.ColumnName = "PARTORTYPE_VCHR";
            clsColumnInfo21.ColumnWidth = 0;
            clsColumnInfo21.Enabled = false;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "PARTORTYPE_VCHR";
            clsColumnInfo21.ReadOnly = false;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 21;
            clsColumnInfo22.ColumnName = "FLAG_INT";
            clsColumnInfo22.ColumnWidth = 0;
            clsColumnInfo22.Enabled = true;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "FLAG_INT";
            clsColumnInfo22.ReadOnly = false;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo1);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo2);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo3);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo4);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo5);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo6);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo7);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo8);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo9);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo10);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo11);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo12);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo13);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo14);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo15);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo16);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo17);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo18);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo19);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo20);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo21);
            this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo22);
            this.m_dtgConcertrecipeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgConcertrecipeDetail.FullRowSelect = true;
            this.m_dtgConcertrecipeDetail.Location = new System.Drawing.Point(0, 0);
            this.m_dtgConcertrecipeDetail.MultiSelect = false;
            this.m_dtgConcertrecipeDetail.Name = "m_dtgConcertrecipeDetail";
            this.m_dtgConcertrecipeDetail.ReadOnly = false;
            this.m_dtgConcertrecipeDetail.RowHeadersVisible = false;
            this.m_dtgConcertrecipeDetail.RowHeaderWidth = 35;
            this.m_dtgConcertrecipeDetail.SelectedRowBackColor = System.Drawing.SystemColors.Desktop;
            this.m_dtgConcertrecipeDetail.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_dtgConcertrecipeDetail.Size = new System.Drawing.Size(832, 260);
            this.m_dtgConcertrecipeDetail.TabIndex = 2;
            this.m_dtgConcertrecipeDetail.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgConcertrecipeDetail_m_evtCurrentCellChanged);
            // 
            // DgItem
            // 
            this.DgItem.AllowAddNew = false;
            this.DgItem.AllowDelete = false;
            this.DgItem.AutoAppendRow = false;
            this.DgItem.AutoScroll = true;
            this.DgItem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgItem.CaptionText = "";
            this.DgItem.CaptionVisible = false;
            this.DgItem.ColumnHeadersVisible = true;
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo23.ColumnIndex = 0;
            clsColumnInfo23.ColumnName = "ITEMCODE_VCHR";
            clsColumnInfo23.ColumnWidth = 80;
            clsColumnInfo23.Enabled = false;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo23.HeadText = "项目代码";
            clsColumnInfo23.ReadOnly = true;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 1;
            clsColumnInfo24.ColumnName = "ITEMNAME_VCHR";
            clsColumnInfo24.ColumnWidth = 110;
            clsColumnInfo24.Enabled = false;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "项目名称";
            clsColumnInfo24.ReadOnly = true;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo25.ColumnIndex = 2;
            clsColumnInfo25.ColumnName = "ITEMENGNAME_VCHR";
            clsColumnInfo25.ColumnWidth = 75;
            clsColumnInfo25.Enabled = false;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo25.HeadText = "英文名称";
            clsColumnInfo25.ReadOnly = true;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 3;
            clsColumnInfo26.ColumnName = "ItemType";
            clsColumnInfo26.ColumnWidth = 40;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "类型";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 4;
            clsColumnInfo27.ColumnName = "ITEMSPEC_VCHR";
            clsColumnInfo27.ColumnWidth = 150;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "规格";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 5;
            clsColumnInfo28.ColumnName = "ITEMOPUNIT_CHR";
            clsColumnInfo28.ColumnWidth = 60;
            clsColumnInfo28.Enabled = false;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "单位";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo29.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo29.BackColor = System.Drawing.Color.White;
            clsColumnInfo29.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo29.ColumnIndex = 6;
            clsColumnInfo29.ColumnName = "precent";
            clsColumnInfo29.ColumnWidth = 75;
            clsColumnInfo29.Enabled = false;
            clsColumnInfo29.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo29.HeadText = "自付比例";
            clsColumnInfo29.ReadOnly = true;
            clsColumnInfo29.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo30.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo30.BackColor = System.Drawing.Color.White;
            clsColumnInfo30.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo30.ColumnIndex = 7;
            clsColumnInfo30.ColumnName = "submoney";
            clsColumnInfo30.ColumnWidth = 60;
            clsColumnInfo30.Enabled = false;
            clsColumnInfo30.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo30.HeadText = "单价";
            clsColumnInfo30.ReadOnly = true;
            clsColumnInfo30.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo31.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo31.BackColor = System.Drawing.Color.White;
            clsColumnInfo31.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo31.ColumnIndex = 8;
            clsColumnInfo31.ColumnName = "ITEMPYCODE_CHR";
            clsColumnInfo31.ColumnWidth = 60;
            clsColumnInfo31.Enabled = false;
            clsColumnInfo31.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo31.HeadText = "拼音码";
            clsColumnInfo31.ReadOnly = true;
            clsColumnInfo31.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo32.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo32.BackColor = System.Drawing.Color.White;
            clsColumnInfo32.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo32.ColumnIndex = 9;
            clsColumnInfo32.ColumnName = "ITEMWBCODE_CHR";
            clsColumnInfo32.ColumnWidth = 60;
            clsColumnInfo32.Enabled = false;
            clsColumnInfo32.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo32.HeadText = "五笔码";
            clsColumnInfo32.ReadOnly = true;
            clsColumnInfo32.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo33.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo33.BackColor = System.Drawing.Color.White;
            clsColumnInfo33.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo33.ColumnIndex = 10;
            clsColumnInfo33.ColumnName = "GROUPID_CHR";
            clsColumnInfo33.ColumnWidth = 0;
            clsColumnInfo33.Enabled = false;
            clsColumnInfo33.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo33.HeadText = "GROUPID_CHR";
            clsColumnInfo33.ReadOnly = true;
            clsColumnInfo33.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo34.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo34.BackColor = System.Drawing.Color.White;
            clsColumnInfo34.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo34.ColumnIndex = 11;
            clsColumnInfo34.ColumnName = "itemsrcid_vchr";
            clsColumnInfo34.ColumnWidth = 0;
            clsColumnInfo34.Enabled = false;
            clsColumnInfo34.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo34.HeadText = "itemsrcid_vchr";
            clsColumnInfo34.ReadOnly = true;
            clsColumnInfo34.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo35.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo35.BackColor = System.Drawing.Color.White;
            clsColumnInfo35.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo35.ColumnIndex = 12;
            clsColumnInfo35.ColumnName = "PARTORTYPENAME_VCHR";
            clsColumnInfo35.ColumnWidth = 0;
            clsColumnInfo35.Enabled = false;
            clsColumnInfo35.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo35.HeadText = "partname";
            clsColumnInfo35.ReadOnly = true;
            clsColumnInfo35.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo36.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo36.BackColor = System.Drawing.Color.White;
            clsColumnInfo36.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo36.ColumnIndex = 13;
            clsColumnInfo36.ColumnName = "ITEMCHECKTYPE_CHR";
            clsColumnInfo36.ColumnWidth = 75;
            clsColumnInfo36.Enabled = false;
            clsColumnInfo36.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo36.HeadText = "ITEMCHECKTYPE_CHR";
            clsColumnInfo36.ReadOnly = true;
            clsColumnInfo36.TextFont = new System.Drawing.Font("宋体", 10F);
            this.DgItem.Columns.Add(clsColumnInfo23);
            this.DgItem.Columns.Add(clsColumnInfo24);
            this.DgItem.Columns.Add(clsColumnInfo25);
            this.DgItem.Columns.Add(clsColumnInfo26);
            this.DgItem.Columns.Add(clsColumnInfo27);
            this.DgItem.Columns.Add(clsColumnInfo28);
            this.DgItem.Columns.Add(clsColumnInfo29);
            this.DgItem.Columns.Add(clsColumnInfo30);
            this.DgItem.Columns.Add(clsColumnInfo31);
            this.DgItem.Columns.Add(clsColumnInfo32);
            this.DgItem.Columns.Add(clsColumnInfo33);
            this.DgItem.Columns.Add(clsColumnInfo34);
            this.DgItem.Columns.Add(clsColumnInfo35);
            this.DgItem.Columns.Add(clsColumnInfo36);
            this.DgItem.FullRowSelect = true;
            this.DgItem.Location = new System.Drawing.Point(0, 0);
            this.DgItem.MultiSelect = false;
            this.DgItem.Name = "DgItem";
            this.DgItem.ReadOnly = false;
            this.DgItem.RowHeadersVisible = false;
            this.DgItem.RowHeaderWidth = 35;
            this.DgItem.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.DgItem.SelectedRowForeColor = System.Drawing.Color.White;
            this.DgItem.Size = new System.Drawing.Size(640, 160);
            this.DgItem.TabIndex = 3;
            this.DgItem.Load += new System.EventHandler(this.DgItem_Load);
            this.DgItem.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.DgItem_m_evtDoubleClickCell);
            this.DgItem.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.DgItem_m_evtDataGridKeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.m_dtgConcertrecipe);
            this.groupBox3.Location = new System.Drawing.Point(0, -5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 616);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.btnReturn);
            this.groupBox4.Controls.Add(this.btnFindData);
            this.groupBox4.Controls.Add(this.m_txtWBCode);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.m_txtFindPy);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.m_txtCodeHelp);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.m_txtNamefind);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(0, 504);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 112);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查找数据";
            this.groupBox4.Visible = false;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnReturn.DefaultScheme = true;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.Hint = "";
            this.btnReturn.Location = new System.Drawing.Point(280, 72);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReturn.Size = new System.Drawing.Size(88, 32);
            this.btnReturn.TabIndex = 13;
            this.btnReturn.Text = "返回(&R)";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnFindData
            // 
            this.btnFindData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnFindData.DefaultScheme = true;
            this.btnFindData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFindData.Hint = "";
            this.btnFindData.Location = new System.Drawing.Point(184, 72);
            this.btnFindData.Name = "btnFindData";
            this.btnFindData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFindData.Size = new System.Drawing.Size(88, 32);
            this.btnFindData.TabIndex = 12;
            this.btnFindData.Text = "查找(&F)";
            this.btnFindData.Click += new System.EventHandler(this.btnFindData_Click);
            // 
            // m_txtWBCode
            // 
            this.m_txtWBCode.Location = new System.Drawing.Point(80, 80);
            this.m_txtWBCode.MaxLength = 10;
            this.m_txtWBCode.Name = "m_txtWBCode";
            this.m_txtWBCode.Size = new System.Drawing.Size(88, 23);
            this.m_txtWBCode.TabIndex = 11;
            this.m_txtWBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtWBCode_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 23);
            this.label16.TabIndex = 10;
            this.label16.Text = "五 笔 码";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtFindPy
            // 
            this.m_txtFindPy.Location = new System.Drawing.Point(80, 52);
            this.m_txtFindPy.MaxLength = 10;
            this.m_txtFindPy.Name = "m_txtFindPy";
            this.m_txtFindPy.Size = new System.Drawing.Size(88, 23);
            this.m_txtFindPy.TabIndex = 9;
            this.m_txtFindPy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindPy_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 23);
            this.label17.TabIndex = 8;
            this.label17.Text = "拼 音 码";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCodeHelp
            // 
            this.m_txtCodeHelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.m_txtCodeHelp.Location = new System.Drawing.Point(240, 24);
            this.m_txtCodeHelp.MaxLength = 10;
            this.m_txtCodeHelp.Name = "m_txtCodeHelp";
            this.m_txtCodeHelp.Size = new System.Drawing.Size(128, 23);
            this.m_txtCodeHelp.TabIndex = 7;
            this.m_txtCodeHelp.TextChanged += new System.EventHandler(this.m_txtCodeHelp_TextChanged);
            this.m_txtCodeHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCodeHelp_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(176, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 6;
            this.label14.Text = "助记码";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtNamefind
            // 
            this.m_txtNamefind.Location = new System.Drawing.Point(80, 24);
            this.m_txtNamefind.MaxLength = 20;
            this.m_txtNamefind.Name = "m_txtNamefind";
            this.m_txtNamefind.Size = new System.Drawing.Size(88, 23);
            this.m_txtNamefind.TabIndex = 5;
            this.m_txtNamefind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtNamefind_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 4;
            this.label15.Text = "处方名称";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtgConcertrecipe
            // 
            this.m_dtgConcertrecipe.AllowAddNew = false;
            this.m_dtgConcertrecipe.AllowDelete = false;
            this.m_dtgConcertrecipe.AutoAppendRow = true;
            this.m_dtgConcertrecipe.AutoScroll = true;
            this.m_dtgConcertrecipe.BackColor = System.Drawing.Color.White;
            this.m_dtgConcertrecipe.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgConcertrecipe.CaptionText = "";
            this.m_dtgConcertrecipe.CaptionVisible = false;
            this.m_dtgConcertrecipe.ColumnHeadersVisible = true;
            clsColumnInfo37.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo37.BackColor = System.Drawing.Color.White;
            clsColumnInfo37.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo37.ColumnIndex = 0;
            clsColumnInfo37.ColumnName = "Column1";
            clsColumnInfo37.ColumnWidth = 0;
            clsColumnInfo37.Enabled = false;
            clsColumnInfo37.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo37.HeadText = "Column1";
            clsColumnInfo37.ReadOnly = true;
            clsColumnInfo37.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo38.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo38.BackColor = System.Drawing.Color.White;
            clsColumnInfo38.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo38.ColumnIndex = 1;
            clsColumnInfo38.ColumnName = "USERCODE_CHR";
            clsColumnInfo38.ColumnWidth = 60;
            clsColumnInfo38.Enabled = false;
            clsColumnInfo38.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo38.HeadText = "助记码";
            clsColumnInfo38.ReadOnly = true;
            clsColumnInfo38.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo39.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo39.BackColor = System.Drawing.Color.White;
            clsColumnInfo39.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo39.ColumnIndex = 2;
            clsColumnInfo39.ColumnName = "RECIPENAME_CHR";
            clsColumnInfo39.ColumnWidth = 110;
            clsColumnInfo39.Enabled = false;
            clsColumnInfo39.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo39.HeadText = "处方名称";
            clsColumnInfo39.ReadOnly = true;
            clsColumnInfo39.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo40.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo40.BackColor = System.Drawing.Color.White;
            clsColumnInfo40.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo40.ColumnIndex = 3;
            clsColumnInfo40.ColumnName = "strPRIVILEGE";
            clsColumnInfo40.ColumnWidth = 40;
            clsColumnInfo40.Enabled = false;
            clsColumnInfo40.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo40.HeadText = "使用";
            clsColumnInfo40.ReadOnly = true;
            clsColumnInfo40.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo41.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo41.BackColor = System.Drawing.Color.White;
            clsColumnInfo41.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo41.ColumnIndex = 4;
            clsColumnInfo41.ColumnName = "WBCODE_CHR";
            clsColumnInfo41.ColumnWidth = 60;
            clsColumnInfo41.Enabled = false;
            clsColumnInfo41.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo41.HeadText = "五笔码";
            clsColumnInfo41.ReadOnly = true;
            clsColumnInfo41.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo42.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo42.BackColor = System.Drawing.Color.White;
            clsColumnInfo42.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo42.ColumnIndex = 5;
            clsColumnInfo42.ColumnName = "PYCODE_CHR";
            clsColumnInfo42.ColumnWidth = 60;
            clsColumnInfo42.Enabled = false;
            clsColumnInfo42.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo42.HeadText = "拼音码";
            clsColumnInfo42.ReadOnly = true;
            clsColumnInfo42.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo43.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo43.BackColor = System.Drawing.Color.White;
            clsColumnInfo43.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo43.ColumnIndex = 6;
            clsColumnInfo43.ColumnName = "LASTNAME_VCHR";
            clsColumnInfo43.ColumnWidth = 0;
            clsColumnInfo43.Enabled = false;
            clsColumnInfo43.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo43.HeadText = "创建人名称";
            clsColumnInfo43.ReadOnly = true;
            clsColumnInfo43.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo44.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo44.BackColor = System.Drawing.Color.White;
            clsColumnInfo44.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo44.ColumnIndex = 7;
            clsColumnInfo44.ColumnName = "DISEASENAME_VCHR";
            clsColumnInfo44.ColumnWidth = 100;
            clsColumnInfo44.Enabled = false;
            clsColumnInfo44.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo44.HeadText = "备注";
            clsColumnInfo44.ReadOnly = true;
            clsColumnInfo44.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo37);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo38);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo39);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo40);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo41);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo42);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo43);
            this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo44);
            this.m_dtgConcertrecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgConcertrecipe.FullRowSelect = true;
            this.m_dtgConcertrecipe.Location = new System.Drawing.Point(3, 19);
            this.m_dtgConcertrecipe.MultiSelect = false;
            this.m_dtgConcertrecipe.Name = "m_dtgConcertrecipe";
            this.m_dtgConcertrecipe.ReadOnly = false;
            this.m_dtgConcertrecipe.RowHeadersVisible = false;
            this.m_dtgConcertrecipe.RowHeaderWidth = 35;
            this.m_dtgConcertrecipe.SelectedRowBackColor = System.Drawing.SystemColors.Desktop;
            this.m_dtgConcertrecipe.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_dtgConcertrecipe.Size = new System.Drawing.Size(378, 594);
            this.m_dtgConcertrecipe.TabIndex = 1;
            this.m_dtgConcertrecipe.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgConcertrecipe_m_evtCurrentCellChanged);
            this.m_dtgConcertrecipe.m_evtClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dtgConcertrecipe_m_evtClickCell);
            // 
            // pnldg
            // 
            this.pnldg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnldg.Controls.Add(this.DgItem);
            this.pnldg.Location = new System.Drawing.Point(384, 104);
            this.pnldg.Name = "pnldg";
            this.pnldg.Size = new System.Drawing.Size(640, 160);
            this.pnldg.TabIndex = 52;
            this.pnldg.Visible = false;
            this.pnldg.Leave += new System.EventHandler(this.pnldg_Leave);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.Controls.Add(this.listView2);
            this.panel4.Controls.Add(this.ctlTextBoxFind1);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.buttonXP3);
            this.panel4.Location = new System.Drawing.Point(384, 264);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(656, 296);
            this.panel4.TabIndex = 0;
            // 
            // listView2
            // 
            this.listView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.ID});
            this.listView2.ContextMenu = this.contextMenu1;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(512, 32);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(128, 184);
            this.listView2.TabIndex = 54;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室名称";
            this.columnHeader1.Width = 100;
            // 
            // ID
            // 
            this.ID.Width = 0;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "删除";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // ctlTextBoxFind1
            // 
            this.ctlTextBoxFind1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ctlTextBoxFind1.Enabled = false;
            this.ctlTextBoxFind1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlTextBoxFind1.intHeight = 200;
            this.ctlTextBoxFind1.IsEnterShow = false;
            this.ctlTextBoxFind1.isHide = 4;
            this.ctlTextBoxFind1.isTxt = 1;
            this.ctlTextBoxFind1.isUpOrDn = 0;
            this.ctlTextBoxFind1.isValuse = 4;
            this.ctlTextBoxFind1.Location = new System.Drawing.Point(512, 7);
            this.ctlTextBoxFind1.m_IsHaveParent = false;
            this.ctlTextBoxFind1.m_strParentName = "";
            this.ctlTextBoxFind1.Name = "ctlTextBoxFind1";
            this.ctlTextBoxFind1.nextCtl = null;
            this.ctlTextBoxFind1.Size = new System.Drawing.Size(72, 24);
            this.ctlTextBoxFind1.TabIndex = 48;
            this.ctlTextBoxFind1.txtValuse = "";
            this.ctlTextBoxFind1.VsLeftOrRight = 0;
            this.ctlTextBoxFind1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlTextBoxFind1_KeyDown);
            // 
            // buttonXP3
            // 
            this.buttonXP3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(584, 7);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(56, 23);
            this.buttonXP3.TabIndex = 50;
            this.buttonXP3.Text = "确定(&O)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // m_pnlAllPlan
            // 
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllpay);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAlldoc);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAlldept);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllregtype);
            this.m_pnlAllPlan.Location = new System.Drawing.Point(200, 206);
            this.m_pnlAllPlan.Name = "m_pnlAllPlan";
            this.m_pnlAllPlan.Size = new System.Drawing.Size(144, 200);
            this.m_pnlAllPlan.TabIndex = 302;
            this.m_pnlAllPlan.Visible = false;
            // 
            // m_lsvAllpay
            // 
            this.m_lsvAllpay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllpay.FullRowSelect = true;
            this.m_lsvAllpay.GridLines = true;
            this.m_lsvAllpay.HideSelection = false;
            this.m_lsvAllpay.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllpay.MultiSelect = false;
            this.m_lsvAllpay.Name = "m_lsvAllpay";
            this.m_lsvAllpay.Size = new System.Drawing.Size(144, 200);
            this.m_lsvAllpay.TabIndex = 3;
            this.m_lsvAllpay.TabStop = false;
            this.m_lsvAllpay.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllpay.View = System.Windows.Forms.View.Details;
            this.m_lsvAllpay.Click += new System.EventHandler(this.m_lsvAllpay_Click);
            // 
            // m_lsvAlldoc
            // 
            this.m_lsvAlldoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAlldoc.FullRowSelect = true;
            this.m_lsvAlldoc.GridLines = true;
            this.m_lsvAlldoc.HideSelection = false;
            this.m_lsvAlldoc.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAlldoc.MultiSelect = false;
            this.m_lsvAlldoc.Name = "m_lsvAlldoc";
            this.m_lsvAlldoc.Size = new System.Drawing.Size(144, 200);
            this.m_lsvAlldoc.TabIndex = 3;
            this.m_lsvAlldoc.TabStop = false;
            this.m_lsvAlldoc.UseCompatibleStateImageBehavior = false;
            this.m_lsvAlldoc.View = System.Windows.Forms.View.Details;
            // 
            // m_lsvAlldept
            // 
            this.m_lsvAlldept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAlldept.FullRowSelect = true;
            this.m_lsvAlldept.GridLines = true;
            this.m_lsvAlldept.HideSelection = false;
            this.m_lsvAlldept.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAlldept.MultiSelect = false;
            this.m_lsvAlldept.Name = "m_lsvAlldept";
            this.m_lsvAlldept.Size = new System.Drawing.Size(144, 200);
            this.m_lsvAlldept.TabIndex = 3;
            this.m_lsvAlldept.TabStop = false;
            this.m_lsvAlldept.UseCompatibleStateImageBehavior = false;
            this.m_lsvAlldept.View = System.Windows.Forms.View.Details;
            // 
            // m_lsvAllregtype
            // 
            this.m_lsvAllregtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllregtype.FullRowSelect = true;
            this.m_lsvAllregtype.GridLines = true;
            this.m_lsvAllregtype.HideSelection = false;
            this.m_lsvAllregtype.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllregtype.MultiSelect = false;
            this.m_lsvAllregtype.Name = "m_lsvAllregtype";
            this.m_lsvAllregtype.Size = new System.Drawing.Size(144, 200);
            this.m_lsvAllregtype.TabIndex = 3;
            this.m_lsvAllregtype.TabStop = false;
            this.m_lsvAllregtype.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllregtype.View = System.Windows.Forms.View.Details;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lsvItemTc
            // 
            this.lsvItemTc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvItemTc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lsvItemTc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvItemTc.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lsvItemTc.FullRowSelect = true;
            this.lsvItemTc.GridLines = true;
            this.lsvItemTc.Location = new System.Drawing.Point(0, 613);
            this.lsvItemTc.MultiSelect = false;
            this.lsvItemTc.Name = "lsvItemTc";
            this.lsvItemTc.Size = new System.Drawing.Size(1216, 0);
            this.lsvItemTc.TabIndex = 303;
            this.lsvItemTc.UseCompatibleStateImageBehavior = false;
            this.lsvItemTc.View = System.Windows.Forms.View.Details;
            this.lsvItemTc.DoubleClick += new System.EventHandler(this.lsvItemTc_DoubleClick);
            this.lsvItemTc.Leave += new System.EventHandler(this.lsvItemTc_Leave);
            this.lsvItemTc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvItemTc_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "体检套餐代码";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "体检套餐名称";
            this.columnHeader4.Width = 810;
            // 
            // frmConcertrecipe1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1216, 613);
            this.Controls.Add(this.lsvItemTc);
            this.Controls.Add(this.pnldg);
            this.Controls.Add(this.m_pnlAllPlan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmConcertrecipe1";
            this.Text = "门诊临床路径";
            this.Load += new System.EventHandler(this.frmConcertrecipe1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmConcertrecipe1_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConcertrecipe1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipeDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipe)).EndInit();
            this.pnldg.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.m_pnlAllPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlConcertreCipe1();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmConcertrecipe1_Load(object sender, System.EventArgs e)
        {
            if (isPublic == false)
            {
                RadtnPrivy.Checked = true;
                RdbtnUse.Enabled = false;
                RdbtnFaculty.Enabled = false;
            }
            ((clsControlConcertreCipe1)this.objController).m_lngGetConcertreCipeByEmpID();
            ((clsControlConcertreCipe1)this.objController).FillDept();
            ctlTextBoxFind1.nextCtl = m_cboPatType;
        }
        public void m_mthShow(string strFlag)
        {
            if (strFlag == "1")
            {
                this.Text = "门诊收费组合";
                ((clsControlConcertreCipe1)this.objController).m_GetFLAG = 1;
                ((clsControlConcertreCipe1)this.objController).Init();
            }
            else
            {
                ((clsControlConcertreCipe1)this.objController).m_GetFLAG = 0;
            }
            this.Show();
        }

        private void m_dtgConcertrecipe_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_lngGetConcertreCipeDeByID();
        }
        private void m_dtgConcertrecipeDetail_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).ConcertreCipeDeFillBox();
        }

        private void m_btnSave_Click(object sender, System.EventArgs e)
        {
            if (m_txtName.Text == "")
            {
                errorProvider1.SetError(m_txtName, "必需输入名称");
                m_txtName.Focus();
                return;
            }
            if (m_txtCode.Text == "")
            {
                errorProvider1.SetError(m_txtCode, "必需助记码");
                m_txtCode.Focus();
                return;
            }
            if (m_dtgConcertrecipeDetail.RowCount == 0)
            {
                m_txtFindTtem.Focus();
                return;
            }
            m_txtName.Focus();
            ((clsControlConcertreCipe1)this.objController).SaveClick();
            errorProvider1.SetError(m_txtName, "");
            errorProvider1.SetError(m_txtCode, "");

        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (m_txtTQY.Enabled == false)
                m_txtTQY.Text = ((clsControlConcertreCipe1)this.objController).m_mthGetCountNumber();
            if (m_txtItemName.Tag == null || m_txtItemName.Text == "")
            {
                errorProvider1.SetError(m_txtItemName, "请选择项目明细");
                m_txtFindTtem.Focus();
                return;
            }
            if (m_txtType.Tag != null && (string)m_txtType.Tag != "")
            {
                if (m_txtTQY.Text == "")
                {
                    errorProvider1.SetError(m_txtTQY, "请输入数量");
                    m_txtTQY.Focus();
                    return;
                }
                if (label11.Tag != null && m_txtUse.Text == "")
                {
                    errorProvider1.SetError(m_txtUse, "请输入用法");
                    m_txtUse.Focus();
                    return;
                }
                if (label10.Tag != null && m_txtFrequency.Text == "")
                {
                    errorProvider1.SetError(m_txtFrequency, "请输入频率");
                    m_txtFrequency.Focus();
                    return;
                }
            }
            ((clsControlConcertreCipe1)this.objController).AddNewClick();
            errorProvider1.SetError(m_txtItemName, "");
            errorProvider1.SetError(m_txtTQY, "");
            errorProvider1.SetError(m_txtUse, "");
            errorProvider1.SetError(m_txtFrequency, "");
            this.m_txtUse.Enabled = true;
            this.m_txtFrequency.Enabled = true;
            this.m_txtDay.Enabled = true;
            m_txtFindTtem.Focus();
        }

        private void m_txtItemName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void m_txtFindTtem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pnldg.Visible == false)
                    ((clsControlConcertreCipe1)this.objController).FindItemData();
            }
        }

        private void m_txtUse_Enter(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_ShowDept(sender);
            ((clsControlConcertreCipe1)this.objController).m_GetlvwItem(this.m_lsvAllpay);
            if (this.m_lsvAllpay.SelectedItems.Count > 0)
                this.m_lsvAllpay.SelectedItems[0].EnsureVisible();
            this.m_lsvAllpay.BringToFront();
            if (this.m_txtUse.Text.Trim() != "")
            {
                ((clsControlConcertreCipe1)this.objController).m_FindLvw(this.m_txtUse.Text.Trim(), this.m_lsvAllpay, 0);
            }
        }

        private void m_txtUse_TextChanged(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_txtChange();
        }
        private void m_lvItem_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_lvwItemClick((ListView)sender, 1);
        }

        private void m_txtUse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (m_lsvAllpay.Items.Count != 0)
                {
                    this.m_lvItem_Click(this.m_lsvAllpay, e);
                }
                else
                {
                    ((TextBox)sender).Text = "";
                }
                //				this.m_pnlAllPlan.Visible = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                int index = -1;
                for (int i = 0; i < this.m_lsvAllpay.Items.Count; i++)
                {
                    if (this.m_lsvAllpay.Items[i].Selected)
                    {
                        index = i;
                    }
                }
                ((clsControlConcertreCipe1)this.objController).m_UpDown(index, e, (object)this.m_lsvAllpay);
            }
        }

        private void m_txtUse_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (this.ActiveControl.Name != "m_txtUse" && this.ActiveControl.Name != "m_lsvAllpay")
                {
                    m_lsvAllpay.Clear();
                    this.m_pnlAllPlan.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void m_txtFrequency_Enter(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_ShowDept(sender);
            ((clsControlConcertreCipe1)this.objController).m_GetlvwItem(this.m_lsvAllpay);
            if (this.m_lsvAllpay.SelectedItems.Count > 0)
                this.m_lsvAllpay.SelectedItems[0].EnsureVisible();
            this.m_lsvAllpay.BringToFront();
            if (this.m_txtUse.Text.Trim() != "")
            {
                ((clsControlConcertreCipe1)this.objController).m_FindLvw(this.m_txtUse.Text.Trim(), this.m_lsvAllpay, 0);
            }

        }

        private void m_txtFrequency_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (m_lsvAllpay.Items.Count != 0)
                {
                    this.m_lvItem_Click(this.m_lsvAllpay, e);
                }
                else
                {
                    ((TextBox)sender).Text = "";
                }
                this.m_pnlAllPlan.Visible = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                int index = -1;
                for (int i = 0; i < this.m_lsvAllpay.Items.Count; i++)
                {
                    if (this.m_lsvAllpay.Items[i].Selected)
                    {
                        index = i;
                    }
                }
                ((clsControlConcertreCipe1)this.objController).m_UpDown(index, e, (object)this.m_lsvAllpay);
            }
        }

        private void m_txtFrequency_TextChanged(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_txtChange();

        }

        private void m_lsvAllpay_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_lvwItemClick((ListView)sender, 1);
        }
        int currRow = 0;
        private void DgDep_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                m_cboPatType.Focus();
            }
        }

        private void m_btnAddNew_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).ClearData(1);
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).ClearData(0);
            m_txtFindTtem.Focus();
        }

        private void m_txtTQY_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_txtUse.Enabled == true)
                {
                    m_txtUse.Focus();
                }
                else if (m_ctlPark.Enabled == true)
                {
                    m_ctlPark.Focus();
                }
                else
                {
                    btnAdd.Focus();
                }
            }
        }

        private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtCode.Focus();
            }
        }

        private void m_txtCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox1.Focus();
        }

        private void RdbtnFaculty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void btnDele_Click(object sender, System.EventArgs e)
        {

            if (MessageBox.Show("是否要删除协定处方？", "icare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ((clsControlConcertreCipe1)this.objController).DeleData(0);
        }
        /// <summary>
        /// 判断用户最后点的是那个表
        /// </summary>
        private void m_dtgConcertrecipe_m_evtClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            btnDele.Text = "删除处方(&D)";
        }

        private void buttonXP2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnFindData_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).findClick();
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).Return();
            m_dtgConcertrecipe.Height += this.groupBox4.Height;
            this.groupBox4.Visible = false;
        }

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            if (this.groupBox4.Visible == true)
                return;
            this.groupBox4.Visible = true;
            m_txtNamefind.Focus();
            m_dtgConcertrecipe.Height -= this.groupBox4.Height;
        }

        private void RdbtnUse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                RdbtnFaculty.Focus();
        }
        private void RadtnPrivy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                m_cboPatType.Focus();
            }
        }
        private void frmConcertrecipe1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_dtgConcertrecipe.m_mthDeleteAllRow();
            m_dtgConcertrecipeDetail.m_mthDeleteAllRow();
            m_txtName.Focus();
        }

        private void DgItem_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ((clsControlConcertreCipe1)this.objController).seleItem();

        }

        private void frmConcertrecipe1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {

                if (pnldg.Visible == true)
                {
                    pnldg.Visible = false;
                    m_txtFindTtem.Focus();
                }
                else
                {
                    if (MessageBox.Show("是否要退出协定处方管理系统？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        this.Close();
                }
            }
        }

        private void pnldg_Leave(object sender, System.EventArgs e)
        {
            pnldg.Visible = false;
        }

        private void m_txtFrequency_Leave(object sender, System.EventArgs e)
        {
            m_txtDOSAGEQTY_Leave(null, null);
            try
            {
                if (this.ActiveControl.Name != "m_txtFrequency" && this.ActiveControl.Name != "m_lsvAllpay")
                {
                    m_lsvAllpay.Clear();
                    this.m_pnlAllPlan.Visible = false;
                }
            }
            catch
            {
            }

        }

        private void m_txtNamefind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_txtCodeHelp.Focus();
        }

        private void m_txtCodeHelp_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void m_txtCodeHelp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_txtFindPy.Focus();

        }

        private void m_txtFindPy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_txtWBCode.Focus();

        }

        private void m_txtWBCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFindData.Focus();

        }

        private void m_txtName_Leave(object sender, System.EventArgs e)
        {
            com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();
            string wb = Ccode.m_strCreateChinaCode(m_txtName.Text.Trim(), ChinaCode.WB);
            string py = Ccode.m_strCreateChinaCode(m_txtName.Text.Trim(), ChinaCode.PY);
            m_txtPy.Text = py;
            m_txtWb.Text = wb;
        }

        private void DgItem_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).seleItem();
        }

        private void m_txtDOSAGEQTY_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_txtTQY.Enabled == true)
                    m_txtTQY.Focus();
                else
                    if (m_txtUse.Enabled == true)
                    {
                        m_txtUse.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
            }
        }

        private void m_cboOPInv_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_mthSeleChang();
        }

        private void m_txtDay_Leave(object sender, System.EventArgs e)
        {
            if (m_txtDay.Text != "" && m_txtDay.Tag != null)
            {
                try
                {
                    if (btnAdd.Text == "增加明细(&A)")
                    {
                        if (Convert.ToInt32(m_txtDay.Text) % Convert.ToInt32(m_txtDay.Tag.ToString()) != 0)
                        {
                            MessageBox.Show("天数必需是频率的倍数！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            m_txtDay.Focus();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("天数必需是频率的倍数！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txtDay.Focus();
                }
            }
            m_txtDOSAGEQTY_Leave(null, null);
        }

        private void m_txtDay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_ctlPark.Enabled == true)
                {
                    m_ctlPark.Focus();
                }
                else
                {
                    btnAdd.Focus();
                }
            }
        }

        private void m_cboPatType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_txtFindTtem.Focus();
        }

        private void DgItem_Load(object sender, System.EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, System.EventArgs e)
        {

        }

        private void textBoxTypedNumeric1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_txtDOSAGEQTY.Focus();
        }

        private void textBoxTypedNumeric1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void textBoxTypedNumeric1_Leave(object sender, System.EventArgs e)
        {
            if (textBoxTypedNumeric1.Text != "")
            {
                ((clsControlConcertreCipe1)this.objController).m_mthFindRowNo(textBoxTypedNumeric1.Text.Trim());
            }
        }

        private void groupBox2_Enter(object sender, System.EventArgs e)
        {

        }

        private void buttonXP1_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("是否要删除协定处方明细？", "icare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((clsControlConcertreCipe1)this.objController).DeleData(1);
                ((clsControlConcertreCipe1)this.objController).ClearData(0);
                m_txtFindTtem.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isPublic == true)
                    RadtnPrivy.Focus();
                else
                    m_cboPatType.Focus();
            }
        }

        private void m_ctlPark_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.Focus();
        }

        private void m_ctlPark_Leave(object sender, System.EventArgs e)
        {
            btnAdd.Focus();
        }

        private void buttonXP3_Click(object sender, System.EventArgs e)
        {
            if (ctlTextBoxFind1.txtValuse == "" || ctlTextBoxFind1.Tag == null)
            {
                MessageBox.Show("请先选择部门！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlTextBoxFind1.Focus();
            }
            else
            {
                ((clsControlConcertreCipe1)this.objController).m_mthAddDep();
                ctlTextBoxFind1.txtValuse = "";
                ctlTextBoxFind1.Tag = null;
                this.ctlTextBoxFind1.Focus();
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).m_mthDeleDep();
        }

        private void RdbtnUse_CheckedChanged(object sender, System.EventArgs e)
        {
            m_mthRdCheck(sender);
        }
        private void m_mthRdCheck(object sender)
        {
            System.Windows.Forms.RadioButton currRad = (System.Windows.Forms.RadioButton)sender;
            listView2.Items.Clear();
            switch (currRad.Name)
            {
                case "RdbtnUse":
                    if (currRad.Checked == true)
                    {
                        ctlTextBoxFind1.Enabled = false;
                    }
                    break;
                case "RadtnPrivy":
                    if (currRad.Checked == true)
                    {
                        ctlTextBoxFind1.Enabled = false;
                    }
                    break;
                case "RdbtnFaculty":
                    if (currRad.Checked == true)
                    {
                        ctlTextBoxFind1.Enabled = true;
                        ((clsControlConcertreCipe1)this.objController).m_mthFindDep();
                    }
                    break;
            }

        }

        private void ctlTextBoxFind1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                m_cboPatType.Focus();
            }
        }

        private void m_txtDOSAGEQTY_Leave(object sender, System.EventArgs e)
        {
            if (m_txtTQY.Enabled == false)
                m_txtTQY.Text = ((clsControlConcertreCipe1)this.objController).m_mthGetCountNumber();
        }

        private void txtTjtc_DoubleClick(object sender, EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).FindPeCluster(this.txtTjtc.Text.Trim());
        }

        private void txtTjtc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlConcertreCipe1)this.objController).FindPeCluster(this.txtTjtc.Text.Trim());
            }
        }

        private void lsvItemTc_DoubleClick(object sender, EventArgs e)
        {
            ((clsControlConcertreCipe1)this.objController).SelectPeCluster();
        }

        private void lsvItemTc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlConcertreCipe1)this.objController).SelectPeCluster();
            }
        }

        private void lsvItemTc_Leave(object sender, EventArgs e)
        {
            this.lsvItemTc.Height = 0;
        }
    }
}
