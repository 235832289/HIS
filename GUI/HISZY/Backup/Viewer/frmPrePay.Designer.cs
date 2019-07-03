namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrePay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrePay));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStrike = new PinkieControls.ButtonXP();
            this.btnRepeatPrn = new PinkieControls.ButtonXP();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucPatientInfo = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnRefundment = new PinkieControls.ButtonXP();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnCharge = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.btnNew = new PinkieControls.ButtonXP();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblpretype = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprebillno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbopaytype = new System.Windows.Forms.ComboBox();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResume = new PinkieControls.ButtonXP();
            this.btnSwitch = new PinkieControls.ButtonXP();
            this.panelTop = new System.Windows.Forms.Panel();
            this.dtgHistory = new System.Windows.Forms.DataGridView();
            this.serno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paytype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gathername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gatherdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isrec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clearflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStrike
            // 
            this.btnStrike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStrike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnStrike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStrike.DefaultScheme = true;
            this.btnStrike.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStrike.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStrike.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStrike.Hint = "";
            this.btnStrike.Location = new System.Drawing.Point(692, 168);
            this.btnStrike.Name = "btnStrike";
            this.btnStrike.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnStrike.Size = new System.Drawing.Size(76, 32);
            this.btnStrike.TabIndex = 15;
            this.btnStrike.Text = "冲单(&C)";
            this.toolTip1.SetToolTip(this.btnStrike, "请选择历史缴费记录重打按金收据");
            this.btnStrike.Click += new System.EventHandler(this.btnStrike_Click);
            // 
            // btnRepeatPrn
            // 
            this.btnRepeatPrn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepeatPrn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnRepeatPrn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepeatPrn.DefaultScheme = true;
            this.btnRepeatPrn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRepeatPrn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepeatPrn.Hint = "";
            this.btnRepeatPrn.Location = new System.Drawing.Point(692, 206);
            this.btnRepeatPrn.Name = "btnRepeatPrn";
            this.btnRepeatPrn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRepeatPrn.Size = new System.Drawing.Size(76, 32);
            this.btnRepeatPrn.TabIndex = 12;
            this.btnRepeatPrn.Text = "重打(&P)";
            this.toolTip1.SetToolTip(this.btnRepeatPrn, "请选择历史缴费记录重打按金收据");
            this.btnRepeatPrn.Click += new System.EventHandler(this.btnRepeatPrn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 632);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.ucPatientInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 632);
            this.panel4.TabIndex = 2;
            // 
            // ucPatientInfo
            // 
            this.ucPatientInfo.AutoSize = true;
            this.ucPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.ucPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientInfo.FeeCheckStatus = 0;
            this.ucPatientInfo.IsChanged = false;
            this.ucPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInfo.Margin = new System.Windows.Forms.Padding(0);
            this.ucPatientInfo.Name = "ucPatientInfo";
            this.ucPatientInfo.ShowFeeCheckStatusFlag = false;
            this.ucPatientInfo.Size = new System.Drawing.Size(220, 628);
            this.ucPatientInfo.Status = 0;
            this.ucPatientInfo.TabIndex = 1;
            this.ucPatientInfo.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.ucPatientInfo_ZyhChanged);
            this.ucPatientInfo.CardNOChanged += new com.digitalwave.iCare.gui.HIS.TextCardNOChanged(this.ucPatientInfo_CardNOChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 632);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panelBottom);
            this.panel3.Controls.Add(this.panelTop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(789, 632);
            this.panel3.TabIndex = 5;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnStrike);
            this.panelBottom.Controls.Add(this.btnRefundment);
            this.panelBottom.Controls.Add(this.btnRepeatPrn);
            this.panelBottom.Controls.Add(this.lblInfo);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.btnCharge);
            this.panelBottom.Controls.Add(this.btnFind);
            this.panelBottom.Controls.Add(this.btnNew);
            this.panelBottom.Controls.Add(this.tableLayoutPanel1);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.btnResume);
            this.panelBottom.Controls.Add(this.btnSwitch);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 314);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(785, 314);
            this.panelBottom.TabIndex = 6;
            // 
            // btnRefundment
            // 
            this.btnRefundment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefundment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnRefundment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefundment.DefaultScheme = true;
            this.btnRefundment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefundment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefundment.Hint = "";
            this.btnRefundment.Location = new System.Drawing.Point(692, 131);
            this.btnRefundment.Name = "btnRefundment";
            this.btnRefundment.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRefundment.Size = new System.Drawing.Size(76, 32);
            this.btnRefundment.TabIndex = 13;
            this.btnRefundment.Text = "退款(&R)";
            this.btnRefundment.Click += new System.EventHandler(this.btnRefundment_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInfo.Location = new System.Drawing.Point(552, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(240, 12);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "<- 预交单号请与当前打印单据号保持相同";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(692, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(76, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退出(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCharge
            // 
            this.btnCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnCharge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCharge.DefaultScheme = true;
            this.btnCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCharge.Hint = "";
            this.btnCharge.Location = new System.Drawing.Point(692, 95);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCharge.Size = new System.Drawing.Size(76, 32);
            this.btnCharge.TabIndex = 9;
            this.btnCharge.Text = "收费(F8)";
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(692, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(76, 32);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "查找(F3)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.DefaultScheme = true;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Hint = "";
            this.btnNew.Location = new System.Drawing.Point(692, 57);
            this.btnNew.Name = "btnNew";
            this.btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnNew.Size = new System.Drawing.Size(76, 32);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "新建(&N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.49271F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.50729F));
            this.tableLayoutPanel1.Controls.Add(this.lblpretype, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMoney, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtprebillno, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbopaytype, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtnote, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 292);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblpretype
            // 
            this.lblpretype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblpretype.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpretype.ForeColor = System.Drawing.Color.Red;
            this.lblpretype.Location = new System.Drawing.Point(122, 104);
            this.lblpretype.Margin = new System.Windows.Forms.Padding(0);
            this.lblpretype.Name = "lblpretype";
            this.lblpretype.Size = new System.Drawing.Size(560, 32);
            this.lblpretype.TabIndex = 8;
            this.lblpretype.Text = "正常预交";
            this.lblpretype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoney
            // 
            this.txtMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoney.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtMoney.Location = new System.Drawing.Point(122, 36);
            this.txtMoney.Margin = new System.Windows.Forms.Padding(0);
            this.txtMoney.MaxLength = 9;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(560, 32);
            this.txtMoney.TabIndex = 2;
            this.txtMoney.Leave += new System.EventHandler(this.txtMoney_Leave);
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            this.txtMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMoney_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "预交单号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "预交金额";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "预交类型";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "备注";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtprebillno
            // 
            this.txtprebillno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtprebillno.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprebillno.Location = new System.Drawing.Point(122, 2);
            this.txtprebillno.Margin = new System.Windows.Forms.Padding(0);
            this.txtprebillno.Name = "txtprebillno";
            this.txtprebillno.Size = new System.Drawing.Size(560, 32);
            this.txtprebillno.TabIndex = 0;
            this.txtprebillno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprebillno_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "支付类型";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbopaytype
            // 
            this.cbopaytype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbopaytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopaytype.Font = new System.Drawing.Font("宋体", 17F);
            this.cbopaytype.FormattingEnabled = true;
            this.cbopaytype.Items.AddRange(new object[] {
            "1-现金",
            "2-支票",
            "3-银行卡",
            "4-其他"});
            this.cbopaytype.Location = new System.Drawing.Point(122, 70);
            this.cbopaytype.Margin = new System.Windows.Forms.Padding(0);
            this.cbopaytype.Name = "cbopaytype";
            this.cbopaytype.Size = new System.Drawing.Size(560, 31);
            this.cbopaytype.TabIndex = 10;
            this.cbopaytype.Enter += new System.EventHandler(this.cbopaytype_Enter);
            this.cbopaytype.SelectedIndexChanged += new System.EventHandler(this.cbopaytype_SelectedIndexChanged);
            this.cbopaytype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopaytype_KeyDown);
            // 
            // txtnote
            // 
            this.txtnote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnote.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnote.Location = new System.Drawing.Point(122, 138);
            this.txtnote.Margin = new System.Windows.Forms.Padding(0);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtnote.Size = new System.Drawing.Size(560, 152);
            this.txtnote.TabIndex = 7;
            this.txtnote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnote_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(785, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "编辑栏";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnResume
            // 
            this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResume.DefaultScheme = true;
            this.btnResume.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnResume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResume.Hint = "";
            this.btnResume.Location = new System.Drawing.Point(692, 279);
            this.btnResume.Name = "btnResume";
            this.btnResume.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnResume.Size = new System.Drawing.Size(76, 32);
            this.btnResume.TabIndex = 14;
            this.btnResume.Text = "恢复(&M)";
            this.btnResume.Visible = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitch.DefaultScheme = true;
            this.btnSwitch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSwitch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitch.Hint = "";
            this.btnSwitch.Location = new System.Drawing.Point(692, 58);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSwitch.Size = new System.Drawing.Size(76, 32);
            this.btnSwitch.TabIndex = 10;
            this.btnSwitch.Text = "切换(&S)";
            this.btnSwitch.Visible = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.dtgHistory);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(785, 314);
            this.panelTop.TabIndex = 5;
            // 
            // dtgHistory
            // 
            this.dtgHistory.AllowUserToAddRows = false;
            this.dtgHistory.AllowUserToDeleteRows = false;
            this.dtgHistory.AllowUserToResizeRows = false;
            this.dtgHistory.BackgroundColor = System.Drawing.Color.White;
            this.dtgHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHistory.ColumnHeadersHeight = 25;
            this.dtgHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serno,
            this.preno,
            this.paytype,
            this.total,
            this.status,
            this.gathername,
            this.gatherdate,
            this.pretype,
            this.isrec,
            this.clearflag,
            this.confirmemp,
            this.note});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistory.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtgHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHistory.Location = new System.Drawing.Point(0, 0);
            this.dtgHistory.MultiSelect = false;
            this.dtgHistory.Name = "dtgHistory";
            this.dtgHistory.RowHeadersVisible = false;
            this.dtgHistory.RowTemplate.Height = 23;
            this.dtgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistory.Size = new System.Drawing.Size(785, 314);
            this.dtgHistory.TabIndex = 0;
            // 
            // serno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serno.DefaultCellStyle = dataGridViewCellStyle2;
            this.serno.HeaderText = "No.";
            this.serno.Name = "serno";
            this.serno.ReadOnly = true;
            this.serno.Width = 35;
            // 
            // preno
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.preno.DefaultCellStyle = dataGridViewCellStyle3;
            this.preno.HeaderText = "预交单号";
            this.preno.Name = "preno";
            this.preno.ReadOnly = true;
            this.preno.Width = 80;
            // 
            // paytype
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.paytype.DefaultCellStyle = dataGridViewCellStyle4;
            this.paytype.HeaderText = "支付方式";
            this.paytype.Name = "paytype";
            this.paytype.ReadOnly = true;
            this.paytype.Width = 75;
            // 
            // total
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.total.DefaultCellStyle = dataGridViewCellStyle5;
            this.total.HeaderText = "金额";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // status
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle6;
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 50;
            // 
            // gathername
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gathername.DefaultCellStyle = dataGridViewCellStyle7;
            this.gathername.HeaderText = "收款人";
            this.gathername.Name = "gathername";
            this.gathername.ReadOnly = true;
            this.gathername.Width = 55;
            // 
            // gatherdate
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gatherdate.DefaultCellStyle = dataGridViewCellStyle8;
            this.gatherdate.HeaderText = "收款日期";
            this.gatherdate.Name = "gatherdate";
            this.gatherdate.ReadOnly = true;
            this.gatherdate.Width = 155;
            // 
            // pretype
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pretype.DefaultCellStyle = dataGridViewCellStyle9;
            this.pretype.HeaderText = "预交类型";
            this.pretype.Name = "pretype";
            this.pretype.ReadOnly = true;
            this.pretype.Width = 70;
            // 
            // isrec
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.isrec.DefaultCellStyle = dataGridViewCellStyle10;
            this.isrec.HeaderText = "日结";
            this.isrec.Name = "isrec";
            this.isrec.ReadOnly = true;
            this.isrec.Width = 50;
            // 
            // clearflag
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearflag.DefaultCellStyle = dataGridViewCellStyle11;
            this.clearflag.HeaderText = "冲帐";
            this.clearflag.Name = "clearflag";
            this.clearflag.ReadOnly = true;
            this.clearflag.Width = 50;
            // 
            // confirmemp
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmemp.DefaultCellStyle = dataGridViewCellStyle12;
            this.confirmemp.HeaderText = "审核人";
            this.confirmemp.Name = "confirmemp";
            this.confirmemp.ReadOnly = true;
            this.confirmemp.Width = 55;
            // 
            // note
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.note.DefaultCellStyle = dataGridViewCellStyle13;
            this.note.HeaderText = "备注";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 600;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 2);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1014, 22);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmPrePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 634);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrePay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预交金管理";
            this.Activated += new System.EventHandler(this.frmPrePay_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrePay_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrePay_KeyDown);
            this.Load += new System.EventHandler(this.frmPrePay_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal ucPatientInfo ucPatientInfo;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        internal PinkieControls.ButtonXP btnCharge;
        internal PinkieControls.ButtonXP btnFind;
        internal PinkieControls.ButtonXP btnNew;
        internal System.Windows.Forms.DataGridView dtgHistory;
        internal System.Windows.Forms.TextBox txtprebillno;
        internal System.Windows.Forms.ComboBox cbopaytype;
        internal System.Windows.Forms.Label lblpretype;
        internal System.Windows.Forms.TextBox txtnote;
        internal PinkieControls.ButtonXP btnSwitch;
        internal System.Windows.Forms.TextBox txtMoney;
        internal System.Windows.Forms.Label lblInfo;
        internal PinkieControls.ButtonXP btnRepeatPrn;
        private System.Windows.Forms.ToolTip toolTip1;
        internal PinkieControls.ButtonXP btnResume;
        internal PinkieControls.ButtonXP btnRefundment;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal PinkieControls.ButtonXP btnStrike;
        private System.Windows.Forms.DataGridViewTextBoxColumn serno;
        private System.Windows.Forms.DataGridViewTextBoxColumn preno;
        private System.Windows.Forms.DataGridViewTextBoxColumn paytype;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn gathername;
        private System.Windows.Forms.DataGridViewTextBoxColumn gatherdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretype;
        private System.Windows.Forms.DataGridViewTextBoxColumn isrec;
        private System.Windows.Forms.DataGridViewTextBoxColumn clearflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}