namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBRegisterZY
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsvItemICD = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCyyy = new System.Windows.Forms.ComboBox();
            this.cboBzlx = new System.Windows.Forms.ComboBox();
            this.cboZyyy = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSecDiag2 = new System.Windows.Forms.TextBox();
            this.txtSecDiag1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMainDiag = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnYBModifyReg = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnYBCancelReg = new PinkieControls.ButtonXP();
            this.patientinto = new System.Windows.Forms.GroupBox();
            this.btnCbd = new PinkieControls.ButtonXP();
            this.txtZQQRSBH = new System.Windows.Forms.TextBox();
            this.cobRYDYZDBY = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtmOutHospitalDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.txtcyks = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCbdtcqbm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCYBZ = new System.Windows.Forms.ComboBox();
            this.lblcybz = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboWSBZ = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboZQQRQK = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboJZLB = new System.Windows.Forms.ComboBox();
            this.txtBedno = new ControlLibrary.txtListView(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZYH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJZJLH = new System.Windows.Forms.TextBox();
            this.cboZYLB = new System.Windows.Forms.ComboBox();
            this.dtmInHospitalDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDoctor = new ControlLibrary.txtListView(this.components);
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtDept = new ControlLibrary.txtListView(this.components);
            this.txtDiagnsis = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnYBReg = new PinkieControls.ButtonXP();
            this.btnKsydkjq = new PinkieControls.ButtonXP();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.patientinto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvItemICD
            // 
            this.lsvItemICD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvItemICD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lsvItemICD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvItemICD.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lsvItemICD.FullRowSelect = true;
            this.lsvItemICD.GridLines = true;
            this.lsvItemICD.Location = new System.Drawing.Point(0, 596);
            this.lsvItemICD.MultiSelect = false;
            this.lsvItemICD.Name = "lsvItemICD";
            this.lsvItemICD.Size = new System.Drawing.Size(840, 15);
            this.lsvItemICD.TabIndex = 167;
            this.lsvItemICD.UseCompatibleStateImageBehavior = false;
            this.lsvItemICD.View = System.Windows.Forms.View.Details;
            this.lsvItemICD.DoubleClick += new System.EventHandler(this.lsvItemICD_DoubleClick);
            this.lsvItemICD.Leave += new System.EventHandler(this.lsvItemICD_Leave);
            this.lsvItemICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvItemICD_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ICD10代码";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ICD10名称";
            this.columnHeader3.Width = 586;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCyyy);
            this.groupBox1.Controls.Add(this.cboBzlx);
            this.groupBox1.Controls.Add(this.cboZyyy);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtSecDiag2);
            this.groupBox1.Controls.Add(this.txtSecDiag1);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtMainDiag);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 153);
            this.groupBox1.TabIndex = 166;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "异地医保资料";
            // 
            // cboCyyy
            // 
            this.cboCyyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCyyy.FormattingEnabled = true;
            this.cboCyyy.Items.AddRange(new object[] {
            "",
            "1-治愈",
            "2-好转",
            "3-未愈",
            "4-死亡",
            "5-转院",
            "6-转外 ",
            "9-其他"});
            this.cboCyyy.Location = new System.Drawing.Point(588, 112);
            this.cboCyyy.Name = "cboCyyy";
            this.cboCyyy.Size = new System.Drawing.Size(210, 22);
            this.cboCyyy.TabIndex = 201;
            // 
            // cboBzlx
            // 
            this.cboBzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBzlx.FormattingEnabled = true;
            this.cboBzlx.Items.AddRange(new object[] {
            "",
            "1-普通",
            "2-抢救期间",
            "3-非抢救期间"});
            this.cboBzlx.Location = new System.Drawing.Point(588, 72);
            this.cboBzlx.Name = "cboBzlx";
            this.cboBzlx.Size = new System.Drawing.Size(210, 22);
            this.cboBzlx.TabIndex = 194;
            // 
            // cboZyyy
            // 
            this.cboZyyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZyyy.FormattingEnabled = true;
            this.cboZyyy.Items.AddRange(new object[] {
            "",
            "0-普通原因住院",
            "1-恶性肿瘤住院",
            "2-心脑疾病手术治疗住院",
            "3-肝、肾和骨髓移植住院",
            "4-外伤住院",
            "5-生育住院",
            "6-安胎住院"});
            this.cboZyyy.Location = new System.Drawing.Point(588, 32);
            this.cboZyyy.Name = "cboZyyy";
            this.cboZyyy.Size = new System.Drawing.Size(210, 22);
            this.cboZyyy.TabIndex = 193;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(540, 116);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 202;
            this.label28.Text = "(必填)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(476, 116);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 14);
            this.label29.TabIndex = 200;
            this.label29.Text = "出院原因：";
            // 
            // txtSecDiag2
            // 
            this.txtSecDiag2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSecDiag2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtSecDiag2.Location = new System.Drawing.Point(143, 112);
            this.txtSecDiag2.Name = "txtSecDiag2";
            this.txtSecDiag2.Size = new System.Drawing.Size(329, 23);
            this.txtSecDiag2.TabIndex = 199;
            this.txtSecDiag2.DoubleClick += new System.EventHandler(this.txtSecDiag2_DoubleClick);
            this.txtSecDiag2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecDiag2_KeyDown);
            this.txtSecDiag2.Enter += new System.EventHandler(this.txtSecDiag2_Enter);
            // 
            // txtSecDiag1
            // 
            this.txtSecDiag1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSecDiag1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtSecDiag1.Location = new System.Drawing.Point(143, 72);
            this.txtSecDiag1.Name = "txtSecDiag1";
            this.txtSecDiag1.Size = new System.Drawing.Size(329, 23);
            this.txtSecDiag1.TabIndex = 198;
            this.txtSecDiag1.DoubleClick += new System.EventHandler(this.txtSecDiag1_DoubleClick);
            this.txtSecDiag1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecDiag1_KeyDown);
            this.txtSecDiag1.Enter += new System.EventHandler(this.txtSecDiag1_Enter);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(540, 76);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 197;
            this.label25.Text = "(必填)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(540, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 14);
            this.label22.TabIndex = 196;
            this.label22.Text = "(必填)";
            // 
            // txtMainDiag
            // 
            this.txtMainDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMainDiag.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtMainDiag.Location = new System.Drawing.Point(143, 32);
            this.txtMainDiag.Name = "txtMainDiag";
            this.txtMainDiag.Size = new System.Drawing.Size(329, 23);
            this.txtMainDiag.TabIndex = 195;
            this.txtMainDiag.DoubleClick += new System.EventHandler(this.txtMainDiag_DoubleClick);
            this.txtMainDiag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainDiag_KeyDown);
            this.txtMainDiag.Enter += new System.EventHandler(this.txtMainDiag_Enter);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(3, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(126, 14);
            this.label27.TabIndex = 192;
            this.label27.Text = "入院次要诊断(2)：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(97, 36);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 14);
            this.label26.TabIndex = 191;
            this.label26.Text = "(必填)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(476, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 14);
            this.label24.TabIndex = 189;
            this.label24.Text = "补助类型：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(3, 76);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 14);
            this.label23.TabIndex = 188;
            this.label23.Text = "入院次要诊断(1)：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(476, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 186;
            this.label21.Text = "住院原因：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(3, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 14);
            this.label20.TabIndex = 185;
            this.label20.Text = "入院主要诊断：";
            // 
            // btnYBModifyReg
            // 
            this.btnYBModifyReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnYBModifyReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYBModifyReg.DefaultScheme = true;
            this.btnYBModifyReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnYBModifyReg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBModifyReg.Hint = "";
            this.btnYBModifyReg.Location = new System.Drawing.Point(452, 561);
            this.btnYBModifyReg.Name = "btnYBModifyReg";
            this.btnYBModifyReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnYBModifyReg.Size = new System.Drawing.Size(88, 35);
            this.btnYBModifyReg.TabIndex = 165;
            this.btnYBModifyReg.Text = "修改登记";
            this.btnYBModifyReg.Click += new System.EventHandler(this.btnYBModifyReg_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(728, 561);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(88, 35);
            this.btnClose.TabIndex = 163;
            this.btnClose.Text = "完成";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnYBCancelReg
            // 
            this.btnYBCancelReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnYBCancelReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYBCancelReg.DefaultScheme = true;
            this.btnYBCancelReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnYBCancelReg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBCancelReg.Hint = "";
            this.btnYBCancelReg.Location = new System.Drawing.Point(590, 561);
            this.btnYBCancelReg.Name = "btnYBCancelReg";
            this.btnYBCancelReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnYBCancelReg.Size = new System.Drawing.Size(88, 35);
            this.btnYBCancelReg.TabIndex = 162;
            this.btnYBCancelReg.Text = "取消登记";
            this.btnYBCancelReg.Click += new System.EventHandler(this.btnYBCancelReg_Click);
            // 
            // patientinto
            // 
            this.patientinto.Controls.Add(this.btnCbd);
            this.patientinto.Controls.Add(this.txtZQQRSBH);
            this.patientinto.Controls.Add(this.cobRYDYZDBY);
            this.patientinto.Controls.Add(this.label19);
            this.patientinto.Controls.Add(this.dtmOutHospitalDate);
            this.patientinto.Controls.Add(this.label18);
            this.patientinto.Controls.Add(this.txtcyks);
            this.patientinto.Controls.Add(this.label15);
            this.patientinto.Controls.Add(this.txtCbdtcqbm);
            this.patientinto.Controls.Add(this.label4);
            this.patientinto.Controls.Add(this.cboCYBZ);
            this.patientinto.Controls.Add(this.lblcybz);
            this.patientinto.Controls.Add(this.lblTitle);
            this.patientinto.Controls.Add(this.cboWSBZ);
            this.patientinto.Controls.Add(this.label12);
            this.patientinto.Controls.Add(this.cboZQQRQK);
            this.patientinto.Controls.Add(this.label17);
            this.patientinto.Controls.Add(this.label14);
            this.patientinto.Controls.Add(this.cboJZLB);
            this.patientinto.Controls.Add(this.txtBedno);
            this.patientinto.Controls.Add(this.label7);
            this.patientinto.Controls.Add(this.txtIDCard);
            this.patientinto.Controls.Add(this.label3);
            this.patientinto.Controls.Add(this.txtZYH);
            this.patientinto.Controls.Add(this.label2);
            this.patientinto.Controls.Add(this.txtJZJLH);
            this.patientinto.Controls.Add(this.cboZYLB);
            this.patientinto.Controls.Add(this.dtmInHospitalDate);
            this.patientinto.Controls.Add(this.label13);
            this.patientinto.Controls.Add(this.txtDoctor);
            this.patientinto.Controls.Add(this.txtPhone);
            this.patientinto.Controls.Add(this.txtDept);
            this.patientinto.Controls.Add(this.txtDiagnsis);
            this.patientinto.Controls.Add(this.txtName);
            this.patientinto.Controls.Add(this.label5);
            this.patientinto.Controls.Add(this.label6);
            this.patientinto.Controls.Add(this.label11);
            this.patientinto.Controls.Add(this.label10);
            this.patientinto.Controls.Add(this.label9);
            this.patientinto.Controls.Add(this.label8);
            this.patientinto.Controls.Add(this.label1);
            this.patientinto.Controls.Add(this.label16);
            this.patientinto.Location = new System.Drawing.Point(12, 12);
            this.patientinto.Name = "patientinto";
            this.patientinto.Size = new System.Drawing.Size(816, 384);
            this.patientinto.TabIndex = 160;
            this.patientinto.TabStop = false;
            // 
            // btnCbd
            // 
            this.btnCbd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCbd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCbd.DefaultScheme = true;
            this.btnCbd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCbd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCbd.Hint = "";
            this.btnCbd.Location = new System.Drawing.Point(296, 301);
            this.btnCbd.Name = "btnCbd";
            this.btnCbd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCbd.Size = new System.Drawing.Size(24, 28);
            this.btnCbd.TabIndex = 169;
            this.btnCbd.Text = "▼";
            this.btnCbd.Click += new System.EventHandler(this.btnCbd_Click);
            // 
            // txtZQQRSBH
            // 
            this.txtZQQRSBH.BackColor = System.Drawing.SystemColors.Info;
            this.txtZQQRSBH.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZQQRSBH.Location = new System.Drawing.Point(404, 183);
            this.txtZQQRSBH.MaxLength = 20;
            this.txtZQQRSBH.Name = "txtZQQRSBH";
            this.txtZQQRSBH.Size = new System.Drawing.Size(165, 24);
            this.txtZQQRSBH.TabIndex = 171;
            // 
            // cobRYDYZDBY
            // 
            this.cobRYDYZDBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobRYDYZDBY.FormattingEnabled = true;
            this.cobRYDYZDBY.Location = new System.Drawing.Point(127, 344);
            this.cobRYDYZDBY.Name = "cobRYDYZDBY";
            this.cobRYDYZDBY.Size = new System.Drawing.Size(277, 22);
            this.cobRYDYZDBY.TabIndex = 183;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(3, 347);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 14);
            this.label19.TabIndex = 184;
            this.label19.Text = "入院第一诊断病因：";
            // 
            // dtmOutHospitalDate
            // 
            this.dtmOutHospitalDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtmOutHospitalDate.Enabled = false;
            this.dtmOutHospitalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmOutHospitalDate.Location = new System.Drawing.Point(404, 263);
            this.dtmOutHospitalDate.Name = "dtmOutHospitalDate";
            this.dtmOutHospitalDate.Size = new System.Drawing.Size(165, 23);
            this.dtmOutHospitalDate.TabIndex = 182;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(294, 267);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 14);
            this.label18.TabIndex = 181;
            this.label18.Text = "就诊(出院)日期：";
            // 
            // txtcyks
            // 
            this.txtcyks.BackColor = System.Drawing.SystemColors.Info;
            this.txtcyks.Enabled = false;
            this.txtcyks.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcyks.Location = new System.Drawing.Point(648, 222);
            this.txtcyks.MaxLength = 200;
            this.txtcyks.Name = "txtcyks";
            this.txtcyks.ReadOnly = true;
            this.txtcyks.Size = new System.Drawing.Size(150, 24);
            this.txtcyks.TabIndex = 180;
            this.txtcyks.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(581, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 14);
            this.label15.TabIndex = 179;
            this.label15.Text = "出院科室：";
            this.label15.Visible = false;
            // 
            // txtCbdtcqbm
            // 
            this.txtCbdtcqbm.BackColor = System.Drawing.SystemColors.Info;
            this.txtCbdtcqbm.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCbdtcqbm.Location = new System.Drawing.Point(128, 303);
            this.txtCbdtcqbm.MaxLength = 30;
            this.txtCbdtcqbm.Name = "txtCbdtcqbm";
            this.txtCbdtcqbm.Size = new System.Drawing.Size(165, 24);
            this.txtCbdtcqbm.TabIndex = 178;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 177;
            this.label4.Text = "参保地统筹区编码：";
            // 
            // cboCYBZ
            // 
            this.cboCYBZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCYBZ.FormattingEnabled = true;
            this.cboCYBZ.Items.AddRange(new object[] {
            "1-在院",
            "2-出院",
            "3-取消入院"});
            this.cboCYBZ.Location = new System.Drawing.Point(648, 185);
            this.cboCYBZ.Name = "cboCYBZ";
            this.cboCYBZ.Size = new System.Drawing.Size(150, 22);
            this.cboCYBZ.TabIndex = 176;
            // 
            // lblcybz
            // 
            this.lblcybz.AutoSize = true;
            this.lblcybz.Location = new System.Drawing.Point(581, 188);
            this.lblcybz.Name = "lblcybz";
            this.lblcybz.Size = new System.Drawing.Size(77, 14);
            this.lblcybz.TabIndex = 175;
            this.lblcybz.Text = "出院标志：";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(332, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 22);
            this.lblTitle.TabIndex = 174;
            this.lblTitle.Text = "医保病人住院登记";
            // 
            // cboWSBZ
            // 
            this.cboWSBZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWSBZ.FormattingEnabled = true;
            this.cboWSBZ.Items.AddRange(new object[] {
            "0-非外伤",
            "1-外伤"});
            this.cboWSBZ.Location = new System.Drawing.Point(783, 16);
            this.cboWSBZ.Name = "cboWSBZ";
            this.cboWSBZ.Size = new System.Drawing.Size(27, 22);
            this.cboWSBZ.TabIndex = 173;
            this.cboWSBZ.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 14);
            this.label12.TabIndex = 172;
            this.label12.Text = "知情确认书编号：";
            // 
            // cboZQQRQK
            // 
            this.cboZQQRQK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZQQRQK.FormattingEnabled = true;
            this.cboZQQRQK.Items.AddRange(new object[] {
            "1-同意",
            "2-不同意"});
            this.cboZQQRQK.Location = new System.Drawing.Point(127, 185);
            this.cboZQQRQK.Name = "cboZQQRQK";
            this.cboZQQRQK.Size = new System.Drawing.Size(165, 22);
            this.cboZQQRQK.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 14);
            this.label17.TabIndex = 169;
            this.label17.Text = "知情确认情况：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(707, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 167;
            this.label14.Text = "外伤标志：";
            this.label14.Visible = false;
            // 
            // cboJZLB
            // 
            this.cboJZLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJZLB.FormattingEnabled = true;
            this.cboJZLB.Items.AddRange(new object[] {
            "11-普通住院",
            "13-家庭病床",
            "22-急诊住院",
            "23-转院住院",
            "24-市外继续治疗",
            "31-住院康复",
            "41-生育引起疾病住院",
            "71-生育",
            "72-生育剖腹产待遇",
            "73-产前检查",
            "74-分娩",
            "75-终止妊娠",
            "76-妊娠合并症（并发症）",
            "81-公务员体检",
            "91-重流疾病",
            "101-医学检查",
            "111-（异地平台）特殊病种住院",
            "112-（异地平台）异地住院",
            "113-（异地平台）失业住院"});
            this.cboJZLB.Location = new System.Drawing.Point(128, 224);
            this.cboJZLB.Name = "cboJZLB";
            this.cboJZLB.Size = new System.Drawing.Size(165, 22);
            this.cboJZLB.TabIndex = 8;
            // 
            // txtBedno
            // 
            this.txtBedno.BackColor = System.Drawing.SystemColors.Info;
            this.txtBedno.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.txtBedno.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBedno.Location = new System.Drawing.Point(404, 105);
            this.txtBedno.m_blnFocuseShow = true;
            this.txtBedno.m_blnPagination = false;
            this.txtBedno.m_dtbDataSourse = null;
            this.txtBedno.m_intDelayTime = 100;
            this.txtBedno.m_intPageRows = 10;
            this.txtBedno.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.RightBottom;
            this.txtBedno.m_listViewSize = new System.Drawing.Point(150, 100);
            this.txtBedno.m_strFieldsArr = new string[] {
        "areaid_chr",
        "bedid_chr",
        "code_chr"};
            this.txtBedno.m_strSaveField = "bedid_chr";
            this.txtBedno.m_strShowField = "code_chr";
            this.txtBedno.m_strSQL = null;
            this.txtBedno.Name = "txtBedno";
            this.txtBedno.Size = new System.Drawing.Size(165, 24);
            this.txtBedno.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 164;
            this.label7.Text = "床 位 号：";
            // 
            // txtIDCard
            // 
            this.txtIDCard.BackColor = System.Drawing.SystemColors.Info;
            this.txtIDCard.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCard.Location = new System.Drawing.Point(648, 64);
            this.txtIDCard.MaxLength = 18;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(150, 24);
            this.txtIDCard.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 162;
            this.label3.Text = "身份证号：";
            // 
            // txtZYH
            // 
            this.txtZYH.BackColor = System.Drawing.SystemColors.Info;
            this.txtZYH.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZYH.Location = new System.Drawing.Point(127, 64);
            this.txtZYH.MaxLength = 50;
            this.txtZYH.Name = "txtZYH";
            this.txtZYH.Size = new System.Drawing.Size(165, 24);
            this.txtZYH.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 131;
            this.label2.Text = "住 院 号：";
            // 
            // txtJZJLH
            // 
            this.txtJZJLH.BackColor = System.Drawing.SystemColors.Info;
            this.txtJZJLH.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJZJLH.Location = new System.Drawing.Point(404, 222);
            this.txtJZJLH.MaxLength = 200;
            this.txtJZJLH.Name = "txtJZJLH";
            this.txtJZJLH.ReadOnly = true;
            this.txtJZJLH.Size = new System.Drawing.Size(165, 24);
            this.txtJZJLH.TabIndex = 14;
            // 
            // cboZYLB
            // 
            this.cboZYLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZYLB.FormattingEnabled = true;
            this.cboZYLB.Items.AddRange(new object[] {
            "1-医疗住院",
            "2-工伤住院",
            "4-生育住院"});
            this.cboZYLB.Location = new System.Drawing.Point(127, 146);
            this.cboZYLB.Name = "cboZYLB";
            this.cboZYLB.Size = new System.Drawing.Size(165, 22);
            this.cboZYLB.TabIndex = 7;
            this.cboZYLB.SelectedIndexChanged += new System.EventHandler(this.cboZYLB_SelectedIndexChanged);
            // 
            // dtmInHospitalDate
            // 
            this.dtmInHospitalDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtmInHospitalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmInHospitalDate.Location = new System.Drawing.Point(127, 263);
            this.dtmInHospitalDate.Name = "dtmInHospitalDate";
            this.dtmInHospitalDate.Size = new System.Drawing.Size(165, 23);
            this.dtmInHospitalDate.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 44;
            this.label13.Text = "住院类别：";
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.SystemColors.Info;
            this.txtDoctor.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.txtDoctor.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor.Location = new System.Drawing.Point(648, 105);
            this.txtDoctor.m_blnFocuseShow = true;
            this.txtDoctor.m_blnPagination = false;
            this.txtDoctor.m_dtbDataSourse = null;
            this.txtDoctor.m_intDelayTime = 100;
            this.txtDoctor.m_intPageRows = 10;
            this.txtDoctor.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.RightBottom;
            this.txtDoctor.m_listViewSize = new System.Drawing.Point(210, 100);
            this.txtDoctor.m_strFieldsArr = new string[] {
        "empno_chr",
        "pycode_chr",
        "doctorname"};
            this.txtDoctor.m_strSaveField = "empno_chr";
            this.txtDoctor.m_strShowField = "doctorname";
            this.txtDoctor.m_strSQL = null;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(150, 24);
            this.txtDoctor.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.Info;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(404, 144);
            this.txtPhone.MaxLength = 30;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(165, 24);
            this.txtPhone.TabIndex = 11;
            // 
            // txtDept
            // 
            this.txtDept.BackColor = System.Drawing.SystemColors.Info;
            this.txtDept.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.txtDept.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Location = new System.Drawing.Point(127, 105);
            this.txtDept.m_blnFocuseShow = true;
            this.txtDept.m_blnPagination = false;
            this.txtDept.m_dtbDataSourse = null;
            this.txtDept.m_intDelayTime = 100;
            this.txtDept.m_intPageRows = 10;
            this.txtDept.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.txtDept.m_listViewSize = new System.Drawing.Point(260, 100);
            this.txtDept.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.txtDept.m_strSaveField = "deptid_chr";
            this.txtDept.m_strShowField = "deptname_vchr";
            this.txtDept.m_strSQL = null;
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(165, 24);
            this.txtDept.TabIndex = 4;
            this.txtDept.Leave += new System.EventHandler(this.txtDept_Leave);
            // 
            // txtDiagnsis
            // 
            this.txtDiagnsis.BackColor = System.Drawing.SystemColors.Info;
            this.txtDiagnsis.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnsis.Location = new System.Drawing.Point(404, 303);
            this.txtDiagnsis.MaxLength = 100;
            this.txtDiagnsis.Name = "txtDiagnsis";
            this.txtDiagnsis.Size = new System.Drawing.Size(394, 24);
            this.txtDiagnsis.TabIndex = 13;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(404, 64);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 24);
            this.txtName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "就诊(入院)日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(581, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "主治医生：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "联系电话：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "就诊类别：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "科室名称：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "诊断信息：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓    名：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(322, 227);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 14);
            this.label16.TabIndex = 101;
            this.label16.Text = "就诊记录号：";
            // 
            // btnYBReg
            // 
            this.btnYBReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnYBReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYBReg.DefaultScheme = true;
            this.btnYBReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnYBReg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBReg.Hint = "";
            this.btnYBReg.Location = new System.Drawing.Point(314, 561);
            this.btnYBReg.Name = "btnYBReg";
            this.btnYBReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnYBReg.Size = new System.Drawing.Size(88, 35);
            this.btnYBReg.TabIndex = 164;
            this.btnYBReg.Text = "医保登记";
            this.btnYBReg.Click += new System.EventHandler(this.btnYBReg_Click);
            // 
            // btnKsydkjq
            // 
            this.btnKsydkjq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnKsydkjq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKsydkjq.DefaultScheme = true;
            this.btnKsydkjq.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKsydkjq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnKsydkjq.Hint = "";
            this.btnKsydkjq.Location = new System.Drawing.Point(20, 561);
            this.btnKsydkjq.Name = "btnKsydkjq";
            this.btnKsydkjq.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnKsydkjq.Size = new System.Drawing.Size(120, 35);
            this.btnKsydkjq.TabIndex = 168;
            this.btnKsydkjq.Text = "跨省异地卡鉴权";
            this.btnKsydkjq.Click += new System.EventHandler(this.btnKsydkjq_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmYBRegisterZY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 611);
            this.Controls.Add(this.lsvItemICD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnYBModifyReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnYBCancelReg);
            this.Controls.Add(this.patientinto);
            this.Controls.Add(this.btnYBReg);
            this.Controls.Add(this.btnKsydkjq);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "frmYBRegisterZY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保住院登记";
            this.Load += new System.EventHandler(this.frmZYYBRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.patientinto.ResumeLayout(false);
            this.patientinto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPhone;
        internal ControlLibrary.txtListView txtDept;
        internal System.Windows.Forms.TextBox txtDiagnsis;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        internal PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtZYH;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtJZJLH;
        internal PinkieControls.ButtonXP btnYBReg;
        internal PinkieControls.ButtonXP btnYBCancelReg;
        internal System.Windows.Forms.ComboBox cboZYLB;
        internal System.Windows.Forms.DateTimePicker dtmInHospitalDate;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.GroupBox patientinto;
        internal System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Label label3;
        internal ControlLibrary.txtListView txtBedno;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cboZQQRQK;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox cboJZLB;
        internal ControlLibrary.txtListView txtDoctor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtZQQRSBH;
        internal System.Windows.Forms.ComboBox cboWSBZ;
        internal PinkieControls.ButtonXP btnYBModifyReg;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblcybz;
        internal System.Windows.Forms.ComboBox cboCYBZ;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCbdtcqbm;
        internal System.Windows.Forms.TextBox txtcyks;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.DateTimePicker dtmOutHospitalDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox cobRYDYZDBY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        internal System.Windows.Forms.ComboBox cboZyyy;
        internal System.Windows.Forms.ComboBox cboBzlx;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ListView lsvItemICD;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        internal System.Windows.Forms.TextBox txtSecDiag2;
        internal System.Windows.Forms.TextBox txtSecDiag1;
        internal System.Windows.Forms.TextBox txtMainDiag;
        internal System.Windows.Forms.ComboBox cboCyyy;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        internal PinkieControls.ButtonXP btnKsydkjq;
        internal PinkieControls.ButtonXP btnCbd;
        private System.Windows.Forms.Timer timer;
    }
}