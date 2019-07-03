namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmBadCharge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBadCharge));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucPatientInfo = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRight2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblPrepayMoney = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgDetail = new System.Windows.Forms.DataGridView();
            this.serno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colksmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfldm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colflmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colhjje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colftje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colksid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDeptClass = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRepeatPrt = new PinkieControls.ButtonXP();
            this.btnCompute = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.btnCharge = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerInvo = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelRight2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetail)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.ucPatientInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(994, 634);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucPatientInfo
            // 
            this.ucPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.ucPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientInfo.FeeCheckStatus = 0;
            this.ucPatientInfo.IsChanged = false;
            this.ucPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInfo.Name = "ucPatientInfo";
            this.ucPatientInfo.ShowFeeCheckStatusFlag = false;
            this.ucPatientInfo.Size = new System.Drawing.Size(220, 630);
            this.ucPatientInfo.Status = 0;
            this.ucPatientInfo.TabIndex = 0;
            this.ucPatientInfo.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.ucPatientInfo_ZyhChanged);
            this.ucPatientInfo.CardNOChanged += new com.digitalwave.iCare.gui.HIS.TextCardNOChanged(this.ucPatientInfo_CardNOChanged);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelRight2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(765, 592);
            this.panelRight.TabIndex = 4;
            // 
            // panelRight2
            // 
            this.panelRight2.Controls.Add(this.tableLayoutPanel1);
            this.panelRight2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight2.Location = new System.Drawing.Point(0, 0);
            this.panelRight2.Name = "panelRight2";
            this.panelRight2.Size = new System.Drawing.Size(765, 592);
            this.panelRight2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.06897F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.93104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 479F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDeptClass, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 592);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 179);
            this.label3.TabIndex = 5;
            this.label3.Text = "　科   室   分   配";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(27, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 32);
            this.panel3.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblPrepayMoney);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(172, 32);
            this.panel5.TabIndex = 0;
            // 
            // lblPrepayMoney
            // 
            this.lblPrepayMoney.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrepayMoney.ForeColor = System.Drawing.Color.Black;
            this.lblPrepayMoney.Location = new System.Drawing.Point(69, 4);
            this.lblPrepayMoney.Name = "lblPrepayMoney";
            this.lblPrepayMoney.Size = new System.Drawing.Size(241, 26);
            this.lblPrepayMoney.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "预交金：";
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.dtgDetail);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(27, 36);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(736, 554);
            this.panel4.TabIndex = 8;
            // 
            // dtgDetail
            // 
            this.dtgDetail.AllowUserToAddRows = false;
            this.dtgDetail.AllowUserToDeleteRows = false;
            this.dtgDetail.AllowUserToResizeRows = false;
            this.dtgDetail.BackgroundColor = System.Drawing.Color.White;
            this.dtgDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtgDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDetail.ColumnHeadersHeight = 22;
            this.dtgDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serno,
            this.colksmc,
            this.colfldm,
            this.colflmc,
            this.colhjje,
            this.colftje,
            this.colksid});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtgDetail.Location = new System.Drawing.Point(0, 0);
            this.dtgDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDetail.MultiSelect = false;
            this.dtgDetail.Name = "dtgDetail";
            this.dtgDetail.RowHeadersVisible = false;
            this.dtgDetail.RowTemplate.Height = 23;
            this.dtgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetail.ShowCellErrors = false;
            this.dtgDetail.ShowRowErrors = false;
            this.dtgDetail.Size = new System.Drawing.Size(736, 554);
            this.dtgDetail.TabIndex = 1;
            // 
            // serno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            this.serno.DefaultCellStyle = dataGridViewCellStyle2;
            this.serno.HeaderText = "序号";
            this.serno.Name = "serno";
            this.serno.ReadOnly = true;
            this.serno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serno.Width = 50;
            // 
            // colksmc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10F);
            this.colksmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.colksmc.HeaderText = "科室名称";
            this.colksmc.Name = "colksmc";
            this.colksmc.ReadOnly = true;
            this.colksmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colksmc.Width = 210;
            // 
            // colfldm
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10F);
            this.colfldm.DefaultCellStyle = dataGridViewCellStyle4;
            this.colfldm.HeaderText = "分类代码";
            this.colfldm.Name = "colfldm";
            this.colfldm.ReadOnly = true;
            this.colfldm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colfldm.Width = 90;
            // 
            // colflmc
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10F);
            this.colflmc.DefaultCellStyle = dataGridViewCellStyle5;
            this.colflmc.HeaderText = "核算分类名称";
            this.colflmc.Name = "colflmc";
            this.colflmc.ReadOnly = true;
            this.colflmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colflmc.Width = 135;
            // 
            // colhjje
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10F);
            this.colhjje.DefaultCellStyle = dataGridViewCellStyle6;
            this.colhjje.HeaderText = "合计金额";
            this.colhjje.Name = "colhjje";
            this.colhjje.ReadOnly = true;
            this.colhjje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colhjje.Width = 120;
            // 
            // colftje
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.colftje.DefaultCellStyle = dataGridViewCellStyle7;
            this.colftje.HeaderText = "分摊金额";
            this.colftje.Name = "colftje";
            this.colftje.ReadOnly = true;
            this.colftje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colftje.Width = 120;
            // 
            // colksid
            // 
            this.colksid.HeaderText = "科室ID";
            this.colksid.Name = "colksid";
            this.colksid.ReadOnly = true;
            this.colksid.Visible = false;
            this.colksid.Width = 5;
            // 
            // cboDeptClass
            // 
            this.cboDeptClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDeptClass.BackColor = System.Drawing.SystemColors.Control;
            this.cboDeptClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDeptClass.FormattingEnabled = true;
            this.cboDeptClass.Items.AddRange(new object[] {
            "按执行科室",
            "按开单科室",
            "按所在病区"});
            this.cboDeptClass.Location = new System.Drawing.Point(286, 7);
            this.cboDeptClass.Name = "cboDeptClass";
            this.cboDeptClass.Size = new System.Drawing.Size(474, 22);
            this.cboDeptClass.TabIndex = 10;
            this.cboDeptClass.SelectedIndexChanged += new System.EventHandler(this.cboDeptClass_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(201, 2);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(80, 32);
            this.panel6.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "科室分类";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRepeatPrt);
            this.panel2.Controls.Add(this.btnCompute);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.btnCharge);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 592);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 38);
            this.panel2.TabIndex = 7;
            // 
            // btnRepeatPrt
            // 
            this.btnRepeatPrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepeatPrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRepeatPrt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepeatPrt.DefaultScheme = true;
            this.btnRepeatPrt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRepeatPrt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepeatPrt.Hint = "";
            this.btnRepeatPrt.Location = new System.Drawing.Point(544, 3);
            this.btnRepeatPrt.Name = "btnRepeatPrt";
            this.btnRepeatPrt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRepeatPrt.Size = new System.Drawing.Size(95, 32);
            this.btnRepeatPrt.TabIndex = 8;
            this.btnRepeatPrt.Text = "重打发票(&F)";
            this.btnRepeatPrt.Click += new System.EventHandler(this.btnRepeatPrt_Click);
            // 
            // btnCompute
            // 
            this.btnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCompute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompute.DefaultScheme = true;
            this.btnCompute.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCompute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCompute.Hint = "";
            this.btnCompute.Location = new System.Drawing.Point(304, 3);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCompute.Size = new System.Drawing.Size(95, 32);
            this.btnCompute.TabIndex = 7;
            this.btnCompute.Text = "分摊(&P)";
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(16, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(100, 32);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "查找(F3)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCharge
            // 
            this.btnCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCharge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCharge.DefaultScheme = true;
            this.btnCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCharge.Hint = "";
            this.btnCharge.Location = new System.Drawing.Point(424, 3);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCharge.Size = new System.Drawing.Size(95, 32);
            this.btnCharge.TabIndex = 6;
            this.btnCharge.Text = "结算(F8)";
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(664, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(95, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 2);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(994, 22);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerInvo
            // 
            this.timerInvo.Tick += new System.EventHandler(this.timerInvo_Tick);
            // 
            // frmBadCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.KeyPreview = true;
            this.Name = "frmBadCharge";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "呆帐(逃费)病人结算";
            this.Load += new System.EventHandler(this.frmBadCharge_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBadCharge_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetail)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnCharge;
        internal PinkieControls.ButtonXP btnFind;
        private System.Windows.Forms.Panel panel2;
        internal ucPatientInfo ucPatientInfo;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelRight2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.DataGridView dtgDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label lblPrepayMoney;
        internal System.Windows.Forms.ComboBox cboDeptClass;
        internal PinkieControls.ButtonXP btnCompute;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn serno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colksmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfldm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colflmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colhjje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colftje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colksid;
        internal PinkieControls.ButtonXP btnRepeatPrt;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerInvo;
    }
}