namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmBIHConfirmCharge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_btnDable = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.m_chkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdoYET = new System.Windows.Forms.RadioButton();
            this.m_rdoNOT = new System.Windows.Forms.RadioButton();
            this.m_rdoAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdComfirm = new PinkieControls.ButtonXP();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.m_dtvChangeList = new System.Windows.Forms.DataGridView();
            this.c_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CHARGEITEMNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UNITPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PSTATUS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_INSURACEDESC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SPEC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ISRICH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ISMEPAY_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_NEEDCONFIRM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_CONFIRMER_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CONFIRM_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtOneSum = new System.Windows.Forms.Label();
            this.m_txtAllSum = new System.Windows.Forms.Label();
            this.m_dtvOrderList = new System.Windows.Forms.DataGridView();
            this.splitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.ucPatientInfo1 = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.m_clmselectCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_clmNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmrecipeno_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmDOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmCREATOR_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmCREATEDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmCONFIRMER_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmCONFIRM_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmORDEREXECID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmSTATUS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(247, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 614);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.m_dtvChangeList);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.m_dtvOrderList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 614);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_btnDable);
            this.panel3.Controls.Add(this.buttonXP2);
            this.panel3.Controls.Add(this.m_cmdToCommit);
            this.panel3.Controls.Add(this.m_chkSelectAll);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.m_cmdComfirm);
            this.panel3.Controls.Add(this.cmdRefurbish);
            this.panel3.Controls.Add(this.buttonXP1);
            this.panel3.Controls.Add(this.cmdCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 534);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 81);
            this.panel3.TabIndex = 1;
            // 
            // m_btnDable
            // 
            this.m_btnDable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDable.DefaultScheme = true;
            this.m_btnDable.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDable.Hint = "";
            this.m_btnDable.Location = new System.Drawing.Point(474, 38);
            this.m_btnDable.Name = "m_btnDable";
            this.m_btnDable.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDable.Size = new System.Drawing.Size(96, 33);
            this.m_btnDable.TabIndex = 107;
            this.m_btnDable.Text = "作废(F2)";
            this.m_btnDable.Click += new System.EventHandler(this.m_btnDable_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(571, 38);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(96, 33);
            this.buttonXP2.TabIndex = 106;
            this.buttonXP2.Text = "重打发票(&P)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(223, 39);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(245, 33);
            this.m_cmdToCommit.TabIndex = 105;
            this.m_cmdToCommit.Text = "发送摆药申请(F2)";
            this.m_cmdToCommit.Visible = false;
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // m_chkSelectAll
            // 
            this.m_chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.m_chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSelectAll.Location = new System.Drawing.Point(270, 18);
            this.m_chkSelectAll.Name = "m_chkSelectAll";
            this.m_chkSelectAll.Size = new System.Drawing.Size(60, 24);
            this.m_chkSelectAll.TabIndex = 95;
            this.m_chkSelectAll.Text = "全选";
            this.m_chkSelectAll.UseVisualStyleBackColor = false;
            this.m_chkSelectAll.CheckedChanged += new System.EventHandler(this.m_chkSelectAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdoYET);
            this.groupBox1.Controls.Add(this.m_rdoNOT);
            this.groupBox1.Controls.Add(this.m_rdoAll);
            this.groupBox1.Location = new System.Drawing.Point(71, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 42);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // m_rdoYET
            // 
            this.m_rdoYET.AutoSize = true;
            this.m_rdoYET.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdoYET.Location = new System.Drawing.Point(122, 17);
            this.m_rdoYET.Name = "m_rdoYET";
            this.m_rdoYET.Size = new System.Drawing.Size(67, 18);
            this.m_rdoYET.TabIndex = 86;
            this.m_rdoYET.Text = "已审核";
            this.m_rdoYET.UseVisualStyleBackColor = true;
            this.m_rdoYET.CheckedChanged += new System.EventHandler(this.m_rdoYET_CheckedChanged);
            // 
            // m_rdoNOT
            // 
            this.m_rdoNOT.AutoSize = true;
            this.m_rdoNOT.Checked = true;
            this.m_rdoNOT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdoNOT.Location = new System.Drawing.Point(57, 17);
            this.m_rdoNOT.Name = "m_rdoNOT";
            this.m_rdoNOT.Size = new System.Drawing.Size(67, 18);
            this.m_rdoNOT.TabIndex = 87;
            this.m_rdoNOT.TabStop = true;
            this.m_rdoNOT.Text = "未审核";
            this.m_rdoNOT.UseVisualStyleBackColor = true;
            this.m_rdoNOT.CheckedChanged += new System.EventHandler(this.m_rdoNOT_CheckedChanged);
            // 
            // m_rdoAll
            // 
            this.m_rdoAll.AutoSize = true;
            this.m_rdoAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdoAll.Location = new System.Drawing.Point(6, 17);
            this.m_rdoAll.Name = "m_rdoAll";
            this.m_rdoAll.Size = new System.Drawing.Size(53, 18);
            this.m_rdoAll.TabIndex = 88;
            this.m_rdoAll.Text = "全部";
            this.m_rdoAll.UseVisualStyleBackColor = true;
            this.m_rdoAll.CheckedChanged += new System.EventHandler(this.m_rdoAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 94;
            this.label2.Text = "审核状态";
            // 
            // m_cmdComfirm
            // 
            this.m_cmdComfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdComfirm.DefaultScheme = true;
            this.m_cmdComfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdComfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdComfirm.Hint = "";
            this.m_cmdComfirm.Location = new System.Drawing.Point(474, 3);
            this.m_cmdComfirm.Name = "m_cmdComfirm";
            this.m_cmdComfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdComfirm.Size = new System.Drawing.Size(96, 33);
            this.m_cmdComfirm.TabIndex = 75;
            this.m_cmdComfirm.Text = "确认记帐(F1)";
            this.m_cmdComfirm.Click += new System.EventHandler(this.m_cmdComfirm_Click);
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(669, 3);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(77, 33);
            this.cmdRefurbish.TabIndex = 74;
            this.cmdRefurbish.Text = "刷新(F4)";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(571, 3);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(97, 33);
            this.buttonXP1.TabIndex = 73;
            this.buttonXP1.Text = "下一病人(F3)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(669, 39);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(77, 32);
            this.cmdCancel.TabIndex = 72;
            this.cmdCancel.Text = "退出(ESC)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // m_dtvChangeList
            // 
            this.m_dtvChangeList.AllowUserToAddRows = false;
            this.m_dtvChangeList.AllowUserToDeleteRows = false;
            this.m_dtvChangeList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dtvChangeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dtvChangeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvChangeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_no,
            this.c_CHARGEITEMNAME,
            this.c_UNITPRICE,
            this.c_AMOUNT,
            this.c_Sum,
            this.c_PSTATUS_INT,
            this.c_INSURACEDESC_VCHR,
            this.c_SPEC_VCHR,
            this.c_ISRICH,
            this.c_ISMEPAY_INT,
            this.c_NEEDCONFIRM,
            this.c_CONFIRMER_VCHR,
            this.c_CONFIRM_DAT});
            this.m_dtvChangeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dtvChangeList.Location = new System.Drawing.Point(0, 339);
            this.m_dtvChangeList.MultiSelect = false;
            this.m_dtvChangeList.Name = "m_dtvChangeList";
            this.m_dtvChangeList.ReadOnly = true;
            this.m_dtvChangeList.RowHeadersVisible = false;
            this.m_dtvChangeList.RowTemplate.Height = 23;
            this.m_dtvChangeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvChangeList.Size = new System.Drawing.Size(769, 195);
            this.m_dtvChangeList.TabIndex = 88;
            // 
            // c_no
            // 
            this.c_no.HeaderText = "序号";
            this.c_no.Name = "c_no";
            this.c_no.ReadOnly = true;
            this.c_no.Width = 60;
            // 
            // c_CHARGEITEMNAME
            // 
            this.c_CHARGEITEMNAME.HeaderText = "收费项目名称";
            this.c_CHARGEITEMNAME.Name = "c_CHARGEITEMNAME";
            this.c_CHARGEITEMNAME.ReadOnly = true;
            this.c_CHARGEITEMNAME.Width = 150;
            // 
            // c_UNITPRICE
            // 
            this.c_UNITPRICE.HeaderText = "单价";
            this.c_UNITPRICE.Name = "c_UNITPRICE";
            this.c_UNITPRICE.ReadOnly = true;
            this.c_UNITPRICE.Width = 80;
            // 
            // c_AMOUNT
            // 
            this.c_AMOUNT.HeaderText = "领量";
            this.c_AMOUNT.Name = "c_AMOUNT";
            this.c_AMOUNT.ReadOnly = true;
            this.c_AMOUNT.Width = 60;
            // 
            // c_Sum
            // 
            this.c_Sum.HeaderText = "合计";
            this.c_Sum.Name = "c_Sum";
            this.c_Sum.ReadOnly = true;
            this.c_Sum.Width = 80;
            // 
            // c_PSTATUS_INT
            // 
            this.c_PSTATUS_INT.HeaderText = "费用状态";
            this.c_PSTATUS_INT.Name = "c_PSTATUS_INT";
            this.c_PSTATUS_INT.ReadOnly = true;
            // 
            // c_INSURACEDESC_VCHR
            // 
            this.c_INSURACEDESC_VCHR.HeaderText = "医保类型";
            this.c_INSURACEDESC_VCHR.Name = "c_INSURACEDESC_VCHR";
            this.c_INSURACEDESC_VCHR.ReadOnly = true;
            // 
            // c_SPEC_VCHR
            // 
            this.c_SPEC_VCHR.HeaderText = "规格";
            this.c_SPEC_VCHR.Name = "c_SPEC_VCHR";
            this.c_SPEC_VCHR.ReadOnly = true;
            this.c_SPEC_VCHR.Width = 80;
            // 
            // c_ISRICH
            // 
            this.c_ISRICH.HeaderText = "贵重";
            this.c_ISRICH.Name = "c_ISRICH";
            this.c_ISRICH.ReadOnly = true;
            this.c_ISRICH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_ISRICH.Width = 60;
            // 
            // c_ISMEPAY_INT
            // 
            this.c_ISMEPAY_INT.HeaderText = "自费";
            this.c_ISMEPAY_INT.Name = "c_ISMEPAY_INT";
            this.c_ISMEPAY_INT.ReadOnly = true;
            this.c_ISMEPAY_INT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_ISMEPAY_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_ISMEPAY_INT.Width = 60;
            // 
            // c_NEEDCONFIRM
            // 
            this.c_NEEDCONFIRM.HeaderText = "需要审核";
            this.c_NEEDCONFIRM.Name = "c_NEEDCONFIRM";
            this.c_NEEDCONFIRM.ReadOnly = true;
            this.c_NEEDCONFIRM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_NEEDCONFIRM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_NEEDCONFIRM.Visible = false;
            // 
            // c_CONFIRMER_VCHR
            // 
            this.c_CONFIRMER_VCHR.HeaderText = "确认人";
            this.c_CONFIRMER_VCHR.Name = "c_CONFIRMER_VCHR";
            this.c_CONFIRMER_VCHR.ReadOnly = true;
            // 
            // c_CONFIRM_DAT
            // 
            this.c_CONFIRM_DAT.HeaderText = "确认时间";
            this.c_CONFIRM_DAT.Name = "c_CONFIRM_DAT";
            this.c_CONFIRM_DAT.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtOneSum);
            this.panel4.Controls.Add(this.m_txtAllSum);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 309);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(769, 30);
            this.panel4.TabIndex = 91;
            // 
            // m_txtOneSum
            // 
            this.m_txtOneSum.AutoSize = true;
            this.m_txtOneSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtOneSum.ForeColor = System.Drawing.Color.Red;
            this.m_txtOneSum.Location = new System.Drawing.Point(28, 6);
            this.m_txtOneSum.Name = "m_txtOneSum";
            this.m_txtOneSum.Size = new System.Drawing.Size(82, 14);
            this.m_txtOneSum.TabIndex = 89;
            this.m_txtOneSum.Text = "当前合计：";
            // 
            // m_txtAllSum
            // 
            this.m_txtAllSum.AutoSize = true;
            this.m_txtAllSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtAllSum.ForeColor = System.Drawing.Color.Red;
            this.m_txtAllSum.Location = new System.Drawing.Point(260, 7);
            this.m_txtAllSum.Name = "m_txtAllSum";
            this.m_txtAllSum.Size = new System.Drawing.Size(82, 14);
            this.m_txtAllSum.TabIndex = 90;
            this.m_txtAllSum.Text = "选中合计：";
            // 
            // m_dtvOrderList
            // 
            this.m_dtvOrderList.AllowUserToAddRows = false;
            this.m_dtvOrderList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dtvOrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dtvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_clmselectCheck,
            this.m_clmNO,
            this.m_clmrecipeno_int,
            this.m_clmname_vchr,
            this.m_clmDOCTOR_VCHR,
            this.m_clmCREATOR_CHR,
            this.m_clmCREATEDATE_DAT,
            this.m_clmCONFIRMER_VCHR,
            this.m_clmCONFIRM_DAT,
            this.m_clmORDEREXECID_CHR,
            this.m_clmSTATUS_INT});
            this.m_dtvOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dtvOrderList.Location = new System.Drawing.Point(0, 0);
            this.m_dtvOrderList.MultiSelect = false;
            this.m_dtvOrderList.Name = "m_dtvOrderList";
            this.m_dtvOrderList.ReadOnly = true;
            this.m_dtvOrderList.RowHeadersVisible = false;
            this.m_dtvOrderList.RowTemplate.Height = 23;
            this.m_dtvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvOrderList.Size = new System.Drawing.Size(769, 309);
            this.m_dtvOrderList.TabIndex = 85;
            this.m_dtvOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellClick);
            this.m_dtvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellDoubleClick);
            this.m_dtvOrderList.CurrentCellChanged += new System.EventHandler(this.m_dtvOrderList_CurrentCellChanged);
            // 
            // splitter1
            // 
            this.splitter1.AnimationDelay = 20;
            this.splitter1.AnimationStep = 20;
            this.splitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.splitter1.ControlToHide = this.ucPatientInfo1;
            this.splitter1.ExpandParentForm = false;
            this.splitter1.Location = new System.Drawing.Point(239, 0);
            this.splitter1.MinExtra = 10;
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 614);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            this.splitter1.UseAnimations = false;
            this.splitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // ucPatientInfo1
            // 
            this.ucPatientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.ucPatientInfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucPatientInfo1.IsChanged = false;
            this.ucPatientInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInfo1.Name = "ucPatientInfo1";
           
            this.ucPatientInfo1.Size = new System.Drawing.Size(239, 614);
            this.ucPatientInfo1.Status = 0;
            this.ucPatientInfo1.TabIndex = 1;
            this.ucPatientInfo1.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.ucPatientInfo1_ZyhChanged);
            this.ucPatientInfo1.CardNOChanged += new com.digitalwave.iCare.gui.HIS.TextCardNOChanged(this.ucPatientInfo1_CardNOChanged);
            // 
            // m_clmselectCheck
            // 
            this.m_clmselectCheck.FalseValue = "0";
            this.m_clmselectCheck.HeaderText = "";
            this.m_clmselectCheck.Name = "m_clmselectCheck";
            this.m_clmselectCheck.ReadOnly = true;
            this.m_clmselectCheck.TrueValue = "1";
            this.m_clmselectCheck.Width = 20;
            // 
            // m_clmNO
            // 
            this.m_clmNO.HeaderText = "序号";
            this.m_clmNO.Name = "m_clmNO";
            this.m_clmNO.ReadOnly = true;
            this.m_clmNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.m_clmNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_clmNO.Width = 60;
            // 
            // m_clmrecipeno_int
            // 
            this.m_clmrecipeno_int.HeaderText = "方号";
            this.m_clmrecipeno_int.Name = "m_clmrecipeno_int";
            this.m_clmrecipeno_int.ReadOnly = true;
            this.m_clmrecipeno_int.Width = 60;
            // 
            // m_clmname_vchr
            // 
            this.m_clmname_vchr.HeaderText = "医嘱名称";
            this.m_clmname_vchr.Name = "m_clmname_vchr";
            this.m_clmname_vchr.ReadOnly = true;
            this.m_clmname_vchr.Width = 150;
            // 
            // m_clmDOCTOR_VCHR
            // 
            this.m_clmDOCTOR_VCHR.HeaderText = "主管医生";
            this.m_clmDOCTOR_VCHR.Name = "m_clmDOCTOR_VCHR";
            this.m_clmDOCTOR_VCHR.ReadOnly = true;
            this.m_clmDOCTOR_VCHR.Visible = false;
            // 
            // m_clmCREATOR_CHR
            // 
            this.m_clmCREATOR_CHR.HeaderText = "执行单创建者";
            this.m_clmCREATOR_CHR.Name = "m_clmCREATOR_CHR";
            this.m_clmCREATOR_CHR.ReadOnly = true;
            this.m_clmCREATOR_CHR.Width = 130;
            // 
            // m_clmCREATEDATE_DAT
            // 
            this.m_clmCREATEDATE_DAT.HeaderText = "执行单创建时间";
            this.m_clmCREATEDATE_DAT.Name = "m_clmCREATEDATE_DAT";
            this.m_clmCREATEDATE_DAT.ReadOnly = true;
            this.m_clmCREATEDATE_DAT.Width = 130;
            // 
            // m_clmCONFIRMER_VCHR
            // 
            this.m_clmCONFIRMER_VCHR.HeaderText = "确认人";
            this.m_clmCONFIRMER_VCHR.Name = "m_clmCONFIRMER_VCHR";
            this.m_clmCONFIRMER_VCHR.ReadOnly = true;
            // 
            // m_clmCONFIRM_DAT
            // 
            this.m_clmCONFIRM_DAT.HeaderText = "确认时间";
            this.m_clmCONFIRM_DAT.Name = "m_clmCONFIRM_DAT";
            this.m_clmCONFIRM_DAT.ReadOnly = true;
            this.m_clmCONFIRM_DAT.Width = 120;
            // 
            // m_clmORDEREXECID_CHR
            // 
            this.m_clmORDEREXECID_CHR.HeaderText = "ORDEREXECID_CHR";
            this.m_clmORDEREXECID_CHR.Name = "m_clmORDEREXECID_CHR";
            this.m_clmORDEREXECID_CHR.ReadOnly = true;
            this.m_clmORDEREXECID_CHR.Visible = false;
            // 
            // m_clmSTATUS_INT
            // 
            this.m_clmSTATUS_INT.HeaderText = "m_clmSTATUS_INT";
            this.m_clmSTATUS_INT.Name = "m_clmSTATUS_INT";
            this.m_clmSTATUS_INT.ReadOnly = true;
            this.m_clmSTATUS_INT.Visible = false;
            // 
            // frmBIHConfirmCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ucPatientInfo1);
            this.Name = "frmBIHConfirmCharge";
            this.Text = "确认记帐";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHConfirmCharge_KeyDown);
            this.Load += new System.EventHandler(this.frmBIHConfirmCharge_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public com.digitalwave.iCare.gui.HIS.ucPatientInfo ucPatientInfo1;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView m_dtvOrderList;
        public System.Windows.Forms.DataGridView m_dtvChangeList;
        private PinkieControls.ButtonXP cmdRefurbish;
        internal PinkieControls.ButtonXP buttonXP1;
        internal PinkieControls.ButtonXP cmdCancel;
        internal PinkieControls.ButtonXP m_cmdComfirm;
        internal System.Windows.Forms.CheckBox m_chkSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton m_rdoYET;
        public System.Windows.Forms.RadioButton m_rdoNOT;
        public System.Windows.Forms.RadioButton m_rdoAll;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP m_cmdToCommit;
        internal PinkieControls.ButtonXP buttonXP2;
        internal PinkieControls.ButtonXP m_btnDable;
        public System.Windows.Forms.Label m_txtAllSum;
        public System.Windows.Forms.Label m_txtOneSum;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CHARGEITEMNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UNITPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PSTATUS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_INSURACEDESC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SPEC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ISRICH;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ISMEPAY_INT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_NEEDCONFIRM;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CONFIRMER_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CONFIRM_DAT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_clmselectCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmrecipeno_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmDOCTOR_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmCREATOR_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmCREATEDATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmCONFIRMER_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmCONFIRM_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmORDEREXECID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmSTATUS_INT;
    }
}