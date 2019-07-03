using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmChargeCheck 的摘要说明。
    /// </summary>
    public class frmChargeCheck : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private PinkieControls.ButtonXP m_btnBack;
        internal PinkieControls.ButtonXP m_btnQulReg;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.DateTimePicker m_datFirstdate;
        internal System.Windows.Forms.DateTimePicker m_datLastdate;
        private System.Windows.Forms.Label label13;
        internal PinkieControls.ButtonXP btnOther;
        internal PinkieControls.ButtonXP btnESC;
        internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboFildName;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal System.Windows.Forms.ListView LsvChargeDe;
        internal com.digitalwave.controls.ctlDataGridView DgChargeCheck;
        internal PinkieControls.ButtonXP buttonXP1;
        internal System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        internal PinkieControls.ButtonXP buttonXP2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        internal System.Windows.Forms.ComboBox m_cobChang;
        internal PinkieControls.ButtonXP btPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        internal PinkieControls.ButtonXP btnReprintinvo;
        private GroupBox groupBox2;
        private Panel panel2;
        internal Label lblBillNo;
        internal exComboBox m_cboSub1;
        internal exComboBox m_cboSub2;
        public com.digitalwave.controls.clsCardTextBox m_txtValuse;
        public com.digitalwave.controls.clsCardTextBox m_txtVal2;
        public com.digitalwave.controls.clsCardTextBox m_txtVal1;
        private CheckBox ckbOnlySelectVip;
        internal CheckBox chkWechatRePrt;
        private PinkieControls.ButtonXP btnExport;
        private IContainer components;

        public frmChargeCheck()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeCheck));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.LsvChargeDe = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.DgChargeCheck = new com.digitalwave.controls.ctlDataGridView();
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.label11 = new System.Windows.Forms.Label();
            this.m_datFirstdate = new System.Windows.Forms.DateTimePicker();
            this.m_datLastdate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.m_txtVal2 = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtVal1 = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtValuse = new com.digitalwave.controls.clsCardTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_btnBack = new PinkieControls.ButtonXP();
            this.btnOther = new PinkieControls.ButtonXP();
            this.btnESC = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cobChang = new System.Windows.Forms.ComboBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnReprintinvo = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkWechatRePrt = new System.Windows.Forms.CheckBox();
            this.ckbOnlySelectVip = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.btnExport = new PinkieControls.ButtonXP();
            this.m_cboSub2 = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboSub1 = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboFildName = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgChargeCheck)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.LsvChargeDe);
            this.panel1.Controls.Add(this.DgChargeCheck);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 392);
            this.panel1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader9});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(328, 128);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(600, 232);
            this.listView1.TabIndex = 72;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目名称";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "规格";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "产地";
            this.columnHeader3.Width = 64;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单位";
            this.columnHeader4.Width = 64;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "零售价";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "数量";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "总金额";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "处方医生";
            this.columnHeader9.Width = 80;
            // 
            // LsvChargeDe
            // 
            this.LsvChargeDe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.LsvChargeDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LsvChargeDe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.LsvChargeDe.FullRowSelect = true;
            this.LsvChargeDe.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LsvChargeDe.Location = new System.Drawing.Point(368, 168);
            this.LsvChargeDe.MultiSelect = false;
            this.LsvChargeDe.Name = "LsvChargeDe";
            this.LsvChargeDe.Size = new System.Drawing.Size(248, 136);
            this.LsvChargeDe.TabIndex = 56;
            this.LsvChargeDe.UseCompatibleStateImageBehavior = false;
            this.LsvChargeDe.View = System.Windows.Forms.View.Details;
            this.LsvChargeDe.Visible = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "收费项目名称";
            this.columnHeader6.Width = 114;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "金额";
            this.columnHeader7.Width = 114;
            // 
            // DgChargeCheck
            // 
            this.DgChargeCheck.CaptionVisible = false;
            this.DgChargeCheck.DataMember = "";
            this.DgChargeCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgChargeCheck.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DgChargeCheck.Location = new System.Drawing.Point(0, 0);
            this.DgChargeCheck.m_clrBack = System.Drawing.Color.White;
            this.DgChargeCheck.m_clrBackB = System.Drawing.Color.WhiteSmoke;
            this.DgChargeCheck.m_clrFore = System.Drawing.Color.Black;
            this.DgChargeCheck.m_clrForeB = System.Drawing.Color.Black;
            this.DgChargeCheck.Name = "DgChargeCheck";
            this.DgChargeCheck.ReadOnly = true;
            this.DgChargeCheck.RowHeaderWidth = 20;
            this.DgChargeCheck.Size = new System.Drawing.Size(948, 388);
            this.DgChargeCheck.TabIndex = 71;
            this.DgChargeCheck.DoubleClick += new System.EventHandler(this.DgChargeCheck_DoubleClick);
            this.DgChargeCheck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgChargeCheck_MouseDown);
            this.DgChargeCheck.Click += new System.EventHandler(this.DgChargeCheck_Click);
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(100, 83);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(90, 32);
            this.m_btnQulReg.TabIndex = 45;
            this.m_btnQulReg.Text = "查询(&F)";
            this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(3, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 46;
            this.label11.Text = "开始日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_datFirstdate
            // 
            this.m_datFirstdate.Location = new System.Drawing.Point(69, 27);
            this.m_datFirstdate.Name = "m_datFirstdate";
            this.m_datFirstdate.Size = new System.Drawing.Size(121, 23);
            this.m_datFirstdate.TabIndex = 43;
            this.m_datFirstdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_datFirstdate_KeyPress);
            // 
            // m_datLastdate
            // 
            this.m_datLastdate.Location = new System.Drawing.Point(69, 57);
            this.m_datLastdate.Name = "m_datLastdate";
            this.m_datLastdate.Size = new System.Drawing.Size(121, 23);
            this.m_datLastdate.TabIndex = 44;
            this.m_datLastdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_datLastdate_KeyPress);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(3, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 47;
            this.label13.Text = "截止日期";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox7.Controls.Add(this.btnExport);
            this.groupBox7.Controls.Add(this.m_txtVal2);
            this.groupBox7.Controls.Add(this.m_txtVal1);
            this.groupBox7.Controls.Add(this.m_txtValuse);
            this.groupBox7.Controls.Add(this.m_cboSub2);
            this.groupBox7.Controls.Add(this.m_cboSub1);
            this.groupBox7.Controls.Add(this.m_cboFildName);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.m_btnBack);
            this.groupBox7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox7.Location = new System.Drawing.Point(201, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(376, 134);
            this.groupBox7.TabIndex = 49;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "按字段查找";
            // 
            // m_txtVal2
            // 
            this.m_txtVal2.Location = new System.Drawing.Point(274, 65);
            this.m_txtVal2.MaxLength = 18;
            this.m_txtVal2.Name = "m_txtVal2";
            this.m_txtVal2.PatientCard = "";
            this.m_txtVal2.PatientFlag = 0;
            this.m_txtVal2.Size = new System.Drawing.Size(98, 23);
            this.m_txtVal2.TabIndex = 16;
            this.m_txtVal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtVal2.YBCardText = "";
            // 
            // m_txtVal1
            // 
            this.m_txtVal1.Location = new System.Drawing.Point(173, 65);
            this.m_txtVal1.MaxLength = 18;
            this.m_txtVal1.Name = "m_txtVal1";
            this.m_txtVal1.PatientCard = "";
            this.m_txtVal1.PatientFlag = 0;
            this.m_txtVal1.Size = new System.Drawing.Size(98, 23);
            this.m_txtVal1.TabIndex = 15;
            this.m_txtVal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtVal1.YBCardText = "";
            // 
            // m_txtValuse
            // 
            this.m_txtValuse.Location = new System.Drawing.Point(72, 64);
            this.m_txtValuse.MaxLength = 18;
            this.m_txtValuse.Name = "m_txtValuse";
            this.m_txtValuse.PatientCard = "";
            this.m_txtValuse.PatientFlag = 0;
            this.m_txtValuse.Size = new System.Drawing.Size(98, 23);
            this.m_txtValuse.TabIndex = 14;
            this.m_txtValuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtValuse.YBCardText = "";
            this.m_txtValuse.CardKeyDown += new com.digitalwave.controls.clsCardTextBox.TxtKeyDownHandle(this.m_txtValuse1_CardKeyDown);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(5, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 23);
            this.label23.TabIndex = 8;
            this.label23.Text = "查找内容";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(5, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 6;
            this.label22.Text = "查找字段";
            // 
            // m_btnBack
            // 
            this.m_btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnBack.DefaultScheme = true;
            this.m_btnBack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnBack.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnBack.Hint = "";
            this.m_btnBack.Location = new System.Drawing.Point(282, 96);
            this.m_btnBack.Name = "m_btnBack";
            this.m_btnBack.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnBack.Size = new System.Drawing.Size(90, 32);
            this.m_btnBack.TabIndex = 3;
            this.m_btnBack.Text = "查找(&C)";
            this.m_btnBack.Click += new System.EventHandler(this.m_btnBack_Click);
            // 
            // btnOther
            // 
            this.btnOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOther.DefaultScheme = true;
            this.btnOther.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOther.Hint = "";
            this.btnOther.Location = new System.Drawing.Point(562, 32);
            this.btnOther.Name = "btnOther";
            this.btnOther.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOther.Size = new System.Drawing.Size(125, 32);
            this.btnOther.TabIndex = 53;
            this.btnOther.Text = "发票分类明细(&A)";
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnESC
            // 
            this.btnESC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnESC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnESC.DefaultScheme = true;
            this.btnESC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnESC.Hint = "";
            this.btnESC.Location = new System.Drawing.Point(826, 88);
            this.btnESC.Name = "btnESC";
            this.btnESC.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnESC.Size = new System.Drawing.Size(125, 32);
            this.btnESC.TabIndex = 54;
            this.btnESC.Text = "退出(ESC)";
            this.btnESC.Click += new System.EventHandler(this.btnESC_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(826, 32);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(125, 32);
            this.btPrint.TabIndex = 57;
            this.btPrint.Text = "打印明细(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(694, 88);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(125, 32);
            this.buttonXP2.TabIndex = 56;
            this.buttonXP2.Text = "显示处方明细(&D)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(694, 32);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(125, 32);
            this.buttonXP1.TabIndex = 55;
            this.buttonXP1.Text = "生成处方文件(&S)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cobChang
            // 
            this.m_cobChang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobChang.Items.AddRange(new object[] {
            "现金",
            "银行卡",
            "支票",
            "IC卡",
            "微信",
            "支付宝"});
            this.m_cobChang.Location = new System.Drawing.Point(640, 376);
            this.m_cobChang.Name = "m_cobChang";
            this.m_cobChang.Size = new System.Drawing.Size(121, 22);
            this.m_cobChang.TabIndex = 56;
            this.m_cobChang.Visible = false;
            this.m_cobChang.SelectedValueChanged += new System.EventHandler(this.m_cobChang_SelectedValueChanged);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // btnReprintinvo
            // 
            this.btnReprintinvo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprintinvo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnReprintinvo.DefaultScheme = true;
            this.btnReprintinvo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReprintinvo.Hint = "";
            this.btnReprintinvo.Location = new System.Drawing.Point(562, 88);
            this.btnReprintinvo.Name = "btnReprintinvo";
            this.btnReprintinvo.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReprintinvo.Size = new System.Drawing.Size(125, 32);
            this.btnReprintinvo.TabIndex = 58;
            this.btnReprintinvo.Text = "重打发票(&R)";
            this.btnReprintinvo.Click += new System.EventHandler(this.btnReprintinvo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkWechatRePrt);
            this.groupBox2.Controls.Add(this.ckbOnlySelectVip);
            this.groupBox2.Controls.Add(this.m_btnQulReg);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.m_datLastdate);
            this.groupBox2.Controls.Add(this.m_datFirstdate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 134);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "按时间段查询";
            // 
            // chkWechatRePrt
            // 
            this.chkWechatRePrt.AutoSize = true;
            this.chkWechatRePrt.Location = new System.Drawing.Point(8, 116);
            this.chkWechatRePrt.Name = "chkWechatRePrt";
            this.chkWechatRePrt.Size = new System.Drawing.Size(110, 18);
            this.chkWechatRePrt.TabIndex = 49;
            this.chkWechatRePrt.Text = "微信重打发票";
            this.chkWechatRePrt.UseVisualStyleBackColor = true;
            // 
            // ckbOnlySelectVip
            // 
            this.ckbOnlySelectVip.AutoSize = true;
            this.ckbOnlySelectVip.Location = new System.Drawing.Point(8, 92);
            this.ckbOnlySelectVip.Name = "ckbOnlySelectVip";
            this.ckbOnlySelectVip.Size = new System.Drawing.Size(47, 18);
            this.ckbOnlySelectVip.TabIndex = 48;
            this.ckbOnlySelectVip.Text = "VIP";
            this.ckbOnlySelectVip.UseVisualStyleBackColor = true;
            this.ckbOnlySelectVip.CheckedChanged += new System.EventHandler(this.ckbOnlySelectVip_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOther);
            this.panel2.Controls.Add(this.lblBillNo);
            this.panel2.Controls.Add(this.btnESC);
            this.panel2.Controls.Add(this.btPrint);
            this.panel2.Controls.Add(this.btnReprintinvo);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.buttonXP2);
            this.panel2.Controls.Add(this.buttonXP1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 140);
            this.panel2.TabIndex = 57;
            // 
            // lblBillNo
            // 
            this.lblBillNo.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBillNo.ForeColor = System.Drawing.Color.Red;
            this.lblBillNo.Location = new System.Drawing.Point(744, 6);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(208, 20);
            this.lblBillNo.TabIndex = 60;
            this.lblBillNo.Text = "医保记帐单号： 0123456789";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(72, 96);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(125, 32);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出清单(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // m_cboSub2
            // 
            this.m_cboSub2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSub2.FormattingEnabled = true;
            this.m_cboSub2.Location = new System.Drawing.Point(274, 27);
            this.m_cboSub2.Name = "m_cboSub2";
            this.m_cboSub2.Size = new System.Drawing.Size(98, 22);
            this.m_cboSub2.TabIndex = 11;
            // 
            // m_cboSub1
            // 
            this.m_cboSub1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSub1.FormattingEnabled = true;
            this.m_cboSub1.Location = new System.Drawing.Point(173, 27);
            this.m_cboSub1.Name = "m_cboSub1";
            this.m_cboSub1.Size = new System.Drawing.Size(98, 22);
            this.m_cboSub1.TabIndex = 10;
            // 
            // m_cboFildName
            // 
            this.m_cboFildName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFildName.Location = new System.Drawing.Point(72, 27);
            this.m_cboFildName.Name = "m_cboFildName";
            this.m_cboFildName.Size = new System.Drawing.Size(98, 22);
            this.m_cboFildName.TabIndex = 1;
            // 
            // frmChargeCheck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(952, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_cobChang);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChargeCheck";
            this.Text = "门诊收费查询";
            this.Load += new System.EventHandler(this.frmChargeCheck_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeCheck_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgChargeCheck)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlChargeCheck();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 0 收费处 1 收费员
        /// </summary>
        internal string Scope = "0";
        /// <summary>
        /// p_Scope第二位字符，'*'代表不能修改支付类型
        /// </summary>
        private string IsModify = "";
        /// <summary>
        /// 是否只查询符合先诊疗后结算的病人
        /// </summary>
        public bool blnOnlySelectVip = false;

        public void m_mthShow(string p_Scope)
        {
            string s = p_Scope.Trim();
            if (s.Length == 1)
            {
                Scope = s.Trim();
            }
            else if (s.Length == 2)
            {
                Scope = s.Substring(0, 1);
                IsModify = s.Substring(1, 1);
            }

            this.Show();
        }

        public void m_mthShowNew(string p_Scope, string p_strOnlySelectVip)
        {
            string s = p_Scope.Trim();
            if (s.Length == 1)
            {
                Scope = s.Trim();
            }
            else if (s.Length == 2)
            {
                Scope = s.Substring(0, 1);
                IsModify = s.Substring(1, 1);
            }

            if (p_strOnlySelectVip == "0")
            {
                blnOnlySelectVip = false;
                this.ckbOnlySelectVip.Checked = false;
            }
            else if (p_strOnlySelectVip == "1")
            {
                blnOnlySelectVip = true;
                this.ckbOnlySelectVip.Checked = true;
            }

            this.Show();
        }

        bool blis = false;
        private void frmChargeCheck_Load(object sender, System.EventArgs e)
        {
            this.lblBillNo.Text = "";
            ((clsControlChargeCheck)this.objController).m_frmLoad();
            ((System.Windows.Forms.DataGridTextBoxColumn)(this.DgChargeCheck.TableStyles[0].GridColumnStyles[6])).TextBox.Enabled = true;
            ((System.Windows.Forms.DataGridTextBoxColumn)(this.DgChargeCheck.TableStyles[0].GridColumnStyles[6])).TextBox.Enter += new EventHandler(TextBox_Enter);
            blis = clsMain.m_blGetCollocate("0026");
            PrintPreviewControl ppc = null;
            foreach (System.Windows.Forms.Control c in this.printPreviewDialog1.Controls)
            {
                if (c is PrintPreviewControl)
                {
                    ppc = (PrintPreviewControl)c;
                }
            }
            ppc.Zoom = 1;

            if (this.IsModify == "*")
            {
                this.m_cobChang.Enabled = false;
            }

        }

        private void m_btnQulReg_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.DgChargeCheck.CurrentCell.RowNumber >= 0 && this.DgChargeCheck.CurrentCell.ColumnNumber > 11)
            {
                this.DgChargeCheck.CurrentCell = new DataGridCell(0, 1);
            }
            ((clsControlChargeCheck)this.objController).m_frmLoad();
            ((System.Windows.Forms.DataGridTextBoxColumn)(this.DgChargeCheck.TableStyles[0].GridColumnStyles[6])).TextBox.Enabled = true;
            ((System.Windows.Forms.DataGridTextBoxColumn)(this.DgChargeCheck.TableStyles[0].GridColumnStyles[6])).TextBox.Enter += new EventHandler(TextBox_Enter);
            this.buttonXP1.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void btnESC_Click(object sender, System.EventArgs e)
        {
            if (LsvChargeDe.Visible == true)
            {
                LsvChargeDe.Visible = false;
                return;
            }
            if (listView1.Visible == true)
            {
                listView1.Visible = false;
                return;
            }
            this.Close();
        }

        private void m_btnBack_Click(object sender, System.EventArgs e)
        {
            if (m_cboFildName.Text == "诊疗卡号")
            {
                if (this.m_txtValuse.Text.Length < 10 && this.m_txtValuse.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtValuse.Text;
                    this.m_txtValuse.Text = strCardID.Substring(strCardID.Length - 10);
                }
            }
            ((clsControlChargeCheck)this.objController).m_mthFindCharge();
            //string[] m_strArr = new string[2];
            //if (this.m_cboFildName.SelectedIndex >= 0)
            //{
            //    m_strArr[0] = this.m_cboFildName.Text;
            //}
            //else
            //{
            //    m_strArr[0] = "";
            //}
            //if (this.m_cboFildName.Text.Trim() == "记录时间" || this.m_cboFildName.Text.Trim() == "发票日期")
            //{
            //    m_strArr[1] = this.m_datSearch.Value.ToShortDateString();
            //}
            //else
            //{
            //    m_strArr[1] = this.m_txtValuse.Text;
            //}
            //((clsControlChargeCheck)this.objController).m_mthGetChargeInfoByField(m_strArr);
        }

        private void btnOther_Click(object sender, System.EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthShowChargeDe();
        }

        private void DgChargeCheck_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthShowChargeDe();
        }

        private void m_txtValuse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (m_cboFildName.Text == "诊疗卡号" && e.KeyCode == Keys.Enter)
            {
                if (this.m_txtValuse.Text.Length < 10 && this.m_txtValuse.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtValuse.Text;
                    this.m_txtValuse.Text = strCardID.Substring(strCardID.Length - 10);
                }
                m_btnBack.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                m_btnBack.Focus();
            }

        }

        private void buttonXP1_Click(object sender, System.EventArgs e)
        {
            clsCreatFile creatFile = new clsCreatFile(((clsControlChargeCheck)this.objController).m_mthGetAll());
            creatFile.m_mthCreatFile();
        }

        private void buttonXP2_Click(object sender, System.EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthShowRecipeDe();

        }
        public TextBox objTextBox;
        private void TextBox_Enter(object sender, EventArgs e)
        {
            bool isVord = ((clsControlChargeCheck)this.objController).m_blisOver();
            if (blis == true && isVord == false)
            {
                objTextBox = (TextBox)sender;
                objTextBox.Controls.Add(m_cobChang);
                m_cobChang.Dock = System.Windows.Forms.DockStyle.Fill;
                m_cobChang.Visible = true;
                m_cobChang.Focus();
            }
            else
            {
                m_cobChang.Visible = false;
            }
        }

        private void DgChargeCheck_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_cobChang.Focus();
        }

        private void m_cobChang_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthModifiyType();
        }

        private void btPrint_Click(object sender, System.EventArgs e)
        {
            com.digitalwave.iCare.common.frmSelectPrinter
            selectPrinter = new com.digitalwave.iCare.common.frmSelectPrinter();
            if (selectPrinter.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings.PrinterName = selectPrinter.PrinterName;
            }
            else
            {
                return;
            }
            this.printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthBegionPrint(e);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthPrint(e);
        }
        private void DgChargeCheck_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void btnReprintinvo_Click(object sender, EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthReprintinvo();
        }

        private void frmChargeCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (LsvChargeDe.Visible == true)
                {
                    LsvChargeDe.Visible = false;
                    return;
                }
                if (listView1.Visible == true)
                {
                    listView1.Visible = false;
                    return;
                }
            }
        }


        public int count = 0;
        private void m_datSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Right}");
                count++;
                if (count > 2)
                {
                    SendKeys.Send("{TAB}");
                    count = 0;
                }
            }
        }

        private void m_datFirstdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Right}");
                count++;
                if (count > 2)
                {
                    m_datLastdate.Focus();
                    count = 0;
                }
            }
        }

        private void m_datLastdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Right}");
                count++;
                if (count > 2)
                {
                    m_btnQulReg.Focus();
                    count = 0;
                }
            }
        }

        private void m_datFirstdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Right}");
                count++;
                if (count > 2)
                {
                    SendKeys.Send("{TAB}");
                    count = 0;
                }
            }
        }

        private void m_datLastdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Right}");
                count++;
                if (count > 2)
                {
                    SendKeys.Send("{TAB}");
                    count = 0;
                }
            }
        }

        private void DgChargeCheck_Click(object sender, EventArgs e)
        {
            ((clsControlChargeCheck)this.objController).m_mthShowBillNo();
        }

        private void m_txtValuse1_CardKeyDown(object sender, EventArgs e)
        {
            if (m_cboFildName.Text == "诊疗卡号")
            {
                if (this.m_txtValuse.Text.Length < 10 && this.m_txtValuse.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtValuse.Text;
                    this.m_txtValuse.Text = strCardID.Substring(strCardID.Length - 10);
                }
                m_btnBack.Focus();
            }
            m_btnBack.Focus();
        }

        private void ckbOnlySelectVip_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbOnlySelectVip.Checked == true)
            {
                blnOnlySelectVip = true;
            }
            else
            {
                blnOnlySelectVip = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = ((clsControlChargeCheck)this.objController).dtChargeCheck;
            if (dt == null) return;

            DataSet ds = new DataSet();
            ds.Tables.Clear();
            ds.Tables.Add(dt);
            com.digitalwave.iCare.common.ExcelExporter excel = new com.digitalwave.iCare.common.ExcelExporter(ds);
            bool b = excel.m_mthExport();
            if (b)
            {
                MessageBox.Show("导出数据成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("导出数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ds.Tables.Clear();
            dt = null;
            ds = null;
        }
    }
}
