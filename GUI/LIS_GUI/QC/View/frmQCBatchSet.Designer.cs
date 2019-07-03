namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCBatchSet
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
            this.m_pnlInfo = new System.Windows.Forms.Panel();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_chkIsMachine = new System.Windows.Forms.CheckBox();
            this.ctlLISDeviceComboBox1 = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_dtgQCRules = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_txtSummary = new System.Windows.Forms.TextBox();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.m_txtResultUnit = new System.Windows.Forms.TextBox();
            this.m_txtWaveLength = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cboCheckMethod = new com.digitalwave.iCare.gui.LIS.ctlCheckMethodCombox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cboReagentVendor = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtReagentLotNO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboQCSqmpleVendor = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.m_cboQCSampleSource = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtQCSampleLotNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.m_txtQCCheckItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboWorkGroup = new com.digitalwave.iCare.gui.LIS.ctlWorkGroupCombox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtQCBatchSeq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_pnlBottom = new System.Windows.Forms.Panel();
            this.m_cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgQCRules)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlInfo
            // 
            this.m_pnlInfo.Controls.Add(this.m_txtAppDoct);
            this.m_pnlInfo.Controls.Add(this.m_chkIsMachine);
            this.m_pnlInfo.Controls.Add(this.ctlLISDeviceComboBox1);
            this.m_pnlInfo.Controls.Add(this.label21);
            this.m_pnlInfo.Controls.Add(this.label20);
            this.m_pnlInfo.Controls.Add(this.m_dtgQCRules);
            this.m_pnlInfo.Controls.Add(this.m_txtSummary);
            this.m_pnlInfo.Controls.Add(this.m_dtpEndDate);
            this.m_pnlInfo.Controls.Add(this.m_dtpBeginDate);
            this.m_pnlInfo.Controls.Add(this.m_txtResultUnit);
            this.m_pnlInfo.Controls.Add(this.m_txtWaveLength);
            this.m_pnlInfo.Controls.Add(this.label19);
            this.m_pnlInfo.Controls.Add(this.label18);
            this.m_pnlInfo.Controls.Add(this.label17);
            this.m_pnlInfo.Controls.Add(this.label16);
            this.m_pnlInfo.Controls.Add(this.label15);
            this.m_pnlInfo.Controls.Add(this.label11);
            this.m_pnlInfo.Controls.Add(this.label10);
            this.m_pnlInfo.Controls.Add(this.m_cboCheckMethod);
            this.m_pnlInfo.Controls.Add(this.label9);
            this.m_pnlInfo.Controls.Add(this.m_cboReagentVendor);
            this.m_pnlInfo.Controls.Add(this.label7);
            this.m_pnlInfo.Controls.Add(this.m_txtReagentLotNO);
            this.m_pnlInfo.Controls.Add(this.label8);
            this.m_pnlInfo.Controls.Add(this.m_cboQCSqmpleVendor);
            this.m_pnlInfo.Controls.Add(this.m_cboQCSampleSource);
            this.m_pnlInfo.Controls.Add(this.label6);
            this.m_pnlInfo.Controls.Add(this.label5);
            this.m_pnlInfo.Controls.Add(this.m_txtQCSampleLotNO);
            this.m_pnlInfo.Controls.Add(this.label4);
            this.m_pnlInfo.Controls.Add(this.button1);
            this.m_pnlInfo.Controls.Add(this.m_txtQCCheckItem);
            this.m_pnlInfo.Controls.Add(this.label3);
            this.m_pnlInfo.Controls.Add(this.m_cboWorkGroup);
            this.m_pnlInfo.Controls.Add(this.label2);
            this.m_pnlInfo.Controls.Add(this.m_txtQCBatchSeq);
            this.m_pnlInfo.Controls.Add(this.label1);
            this.m_pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlInfo.Location = new System.Drawing.Point(3, 19);
            this.m_pnlInfo.Name = "m_pnlInfo";
            this.m_pnlInfo.Size = new System.Drawing.Size(617, 407);
            this.m_pnlInfo.TabIndex = 0;
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDoct.Location = new System.Drawing.Point(92, 364);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "*";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.Size = new System.Drawing.Size(120, 23);
            this.m_txtAppDoct.TabIndex = 17;
            // 
            // m_chkIsMachine
            // 
            this.m_chkIsMachine.AutoSize = true;
            this.m_chkIsMachine.Location = new System.Drawing.Point(196, 80);
            this.m_chkIsMachine.Name = "m_chkIsMachine";
            this.m_chkIsMachine.Size = new System.Drawing.Size(15, 14);
            this.m_chkIsMachine.TabIndex = 43;
            this.m_chkIsMachine.UseVisualStyleBackColor = true;
            this.m_chkIsMachine.CheckedChanged += new System.EventHandler(this.m_chkIsMachine_CheckedChanged);
            // 
            // ctlLISDeviceComboBox1
            // 
            this.ctlLISDeviceComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlLISDeviceComboBox1.Enabled = false;
            this.ctlLISDeviceComboBox1.FormattingEnabled = true;
            this.ctlLISDeviceComboBox1.Location = new System.Drawing.Point(92, 76);
            this.ctlLISDeviceComboBox1.Name = "ctlLISDeviceComboBox1";
            this.ctlLISDeviceComboBox1.Size = new System.Drawing.Size(100, 22);
            this.ctlLISDeviceComboBox1.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 40;
            this.label21.Text = "检测仪器：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(192, 272);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 0;
            this.label20.Text = "nm";
            // 
            // m_dtgQCRules
            // 
            this.m_dtgQCRules.AllowUserToAddRows = false;
            this.m_dtgQCRules.AllowUserToDeleteRows = false;
            this.m_dtgQCRules.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgQCRules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgQCRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtgQCRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.m_dtgQCRules.Location = new System.Drawing.Point(244, 132);
            this.m_dtgQCRules.MultiSelect = false;
            this.m_dtgQCRules.Name = "m_dtgQCRules";
            this.m_dtgQCRules.RowHeadersVisible = false;
            this.m_dtgQCRules.RowTemplate.Height = 23;
            this.m_dtgQCRules.Size = new System.Drawing.Size(356, 256);
            this.m_dtgQCRules.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ruleName";
            this.Column1.HeaderText = "质控规则";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ruleChoice";
            this.Column2.HeaderText = "选择";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ruleWarning";
            this.Column3.HeaderText = "报警";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSummary.Location = new System.Drawing.Point(244, 20);
            this.m_txtSummary.MaxLength = 100;
            this.m_txtSummary.Multiline = true;
            this.m_txtSummary.Name = "m_txtSummary";
            this.m_txtSummary.Size = new System.Drawing.Size(360, 92);
            this.m_txtSummary.TabIndex = 18;
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(92, 340);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(120, 23);
            this.m_dtpEndDate.TabIndex = 16;
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Location = new System.Drawing.Point(92, 316);
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(120, 23);
            this.m_dtpBeginDate.TabIndex = 15;
            // 
            // m_txtResultUnit
            // 
            this.m_txtResultUnit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtResultUnit.Location = new System.Drawing.Point(92, 292);
            this.m_txtResultUnit.MaxLength = 10;
            this.m_txtResultUnit.Name = "m_txtResultUnit";
            this.m_txtResultUnit.Size = new System.Drawing.Size(120, 23);
            this.m_txtResultUnit.TabIndex = 14;
            // 
            // m_txtWaveLength
            // 
            this.m_txtWaveLength.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtWaveLength.Location = new System.Drawing.Point(92, 268);
            this.m_txtWaveLength.MaxLength = 6;
            this.m_txtWaveLength.Name = "m_txtWaveLength";
            this.m_txtWaveLength.Size = new System.Drawing.Size(100, 23);
            this.m_txtWaveLength.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(34, 368);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 14);
            this.label19.TabIndex = 28;
            this.label19.Text = "操作者：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(240, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 14);
            this.label18.TabIndex = 27;
            this.label18.Text = "备注：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 344);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 26;
            this.label17.Text = "结束日期：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 25;
            this.label16.Text = "开始日期：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 14);
            this.label15.TabIndex = 24;
            this.label15.Text = "结果单位：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "质控规则组：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "检测波长：";
            // 
            // m_cboCheckMethod
            // 
            this.m_cboCheckMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMethod.FormattingEnabled = true;
            this.m_cboCheckMethod.Location = new System.Drawing.Point(92, 244);
            this.m_cboCheckMethod.Name = "m_cboCheckMethod";
            this.m_cboCheckMethod.Size = new System.Drawing.Size(120, 22);
            this.m_cboCheckMethod.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "检测方法：";
            // 
            // m_cboReagentVendor
            // 
            this.m_cboReagentVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboReagentVendor.FormattingEnabled = true;
            this.m_cboReagentVendor.Location = new System.Drawing.Point(92, 220);
            this.m_cboReagentVendor.Name = "m_cboReagentVendor";
            this.m_cboReagentVendor.Size = new System.Drawing.Size(120, 22);
            this.m_cboReagentVendor.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "试剂厂商：";
            // 
            // m_txtReagentLotNO
            // 
            this.m_txtReagentLotNO.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtReagentLotNO.Location = new System.Drawing.Point(92, 196);
            this.m_txtReagentLotNO.MaxLength = 25;
            this.m_txtReagentLotNO.Name = "m_txtReagentLotNO";
            this.m_txtReagentLotNO.Size = new System.Drawing.Size(120, 23);
            this.m_txtReagentLotNO.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "试剂批号：";
            // 
            // m_cboQCSqmpleVendor
            // 
            this.m_cboQCSqmpleVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboQCSqmpleVendor.FormattingEnabled = true;
            this.m_cboQCSqmpleVendor.Location = new System.Drawing.Point(92, 172);
            this.m_cboQCSqmpleVendor.Name = "m_cboQCSqmpleVendor";
            this.m_cboQCSqmpleVendor.Size = new System.Drawing.Size(120, 22);
            this.m_cboQCSqmpleVendor.TabIndex = 6;
            // 
            // m_cboQCSampleSource
            // 
            this.m_cboQCSampleSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboQCSampleSource.FormattingEnabled = true;
            this.m_cboQCSampleSource.Location = new System.Drawing.Point(92, 148);
            this.m_cboQCSampleSource.Name = "m_cboQCSampleSource";
            this.m_cboQCSampleSource.Size = new System.Drawing.Size(120, 22);
            this.m_cboQCSampleSource.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "质控品厂商：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "质控品来源：";
            // 
            // m_txtQCSampleLotNO
            // 
            this.m_txtQCSampleLotNO.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtQCSampleLotNO.Location = new System.Drawing.Point(92, 124);
            this.m_txtQCSampleLotNO.MaxLength = 25;
            this.m_txtQCSampleLotNO.Name = "m_txtQCSampleLotNO";
            this.m_txtQCSampleLotNO.Size = new System.Drawing.Size(120, 23);
            this.m_txtQCSampleLotNO.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "质控品批号：";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(192, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "┅";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_txtQCCheckItem
            // 
            this.m_txtQCCheckItem.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtQCCheckItem.Location = new System.Drawing.Point(92, 100);
            this.m_txtQCCheckItem.Name = "m_txtQCCheckItem";
            this.m_txtQCCheckItem.ReadOnly = true;
            this.m_txtQCCheckItem.Size = new System.Drawing.Size(100, 23);
            this.m_txtQCCheckItem.TabIndex = 100;
            this.m_txtQCCheckItem.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "质控项目：";
            // 
            // m_cboWorkGroup
            // 
            this.m_cboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWorkGroup.FormattingEnabled = true;
            this.m_cboWorkGroup.Location = new System.Drawing.Point(92, 52);
            this.m_cboWorkGroup.Name = "m_cboWorkGroup";
            this.m_cboWorkGroup.Size = new System.Drawing.Size(120, 22);
            this.m_cboWorkGroup.TabIndex = 1;
            this.m_cboWorkGroup.Value = -2147483648;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "工作组：";
            // 
            // m_txtQCBatchSeq
            // 
            this.m_txtQCBatchSeq.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtQCBatchSeq.Location = new System.Drawing.Point(92, 28);
            this.m_txtQCBatchSeq.MaxLength = 6;
            this.m_txtQCBatchSeq.Name = "m_txtQCBatchSeq";
            this.m_txtQCBatchSeq.ReadOnly = true;
            this.m_txtQCBatchSeq.Size = new System.Drawing.Size(120, 23);
            this.m_txtQCBatchSeq.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "序号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_pnlInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 429);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // m_pnlBottom
            // 
            this.m_pnlBottom.Controls.Add(this.m_cmdConfirm);
            this.m_pnlBottom.Controls.Add(this.m_cmdCancel);
            this.m_pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnlBottom.Location = new System.Drawing.Point(0, 429);
            this.m_pnlBottom.Name = "m_pnlBottom";
            this.m_pnlBottom.Size = new System.Drawing.Size(623, 60);
            this.m_pnlBottom.TabIndex = 2;
            // 
            // m_cmdConfirm
            // 
            this.m_cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdConfirm.DefaultScheme = true;
            this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdConfirm.Hint = "";
            this.m_cmdConfirm.Location = new System.Drawing.Point(380, 12);
            this.m_cmdConfirm.Name = "m_cmdConfirm";
            this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdConfirm.Size = new System.Drawing.Size(98, 33);
            this.m_cmdConfirm.TabIndex = 17;
            this.m_cmdConfirm.Text = "确定";
            this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(492, 12);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(98, 33);
            this.m_cmdCancel.TabIndex = 18;
            this.m_cmdCancel.Text = "取消(ESC)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // frmQCBatchSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(623, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_pnlBottom);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQCBatchSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控批设置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQCBatch_KeyDown);
            this.Load += new System.EventHandler(this.frmQCBatchSet_Load);
            this.m_pnlInfo.ResumeLayout(false);
            this.m_pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgQCRules)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.m_pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlInfo;
        private System.Windows.Forms.TextBox m_txtQCBatchSeq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtQCCheckItem;
        private System.Windows.Forms.Label label3;
        private ctlWorkGroupCombox m_cboWorkGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txtQCSampleLotNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private ctlVendorCombox m_cboQCSampleSource;
        private ctlVendorCombox m_cboReagentVendor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txtReagentLotNO;
        private System.Windows.Forms.Label label8;
        private ctlVendorCombox m_cboQCSqmpleVendor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private ctlCheckMethodCombox m_cboCheckMethod;
        private System.Windows.Forms.DateTimePicker m_dtpBeginDate;
        private System.Windows.Forms.TextBox m_txtResultUnit;
        private System.Windows.Forms.TextBox m_txtWaveLength;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox m_txtSummary;
        private System.Windows.Forms.DateTimePicker m_dtpEndDate;
        private System.Windows.Forms.DataGridView m_dtgQCRules;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel m_pnlBottom;
        private PinkieControls.ButtonXP m_cmdConfirm;
        private PinkieControls.ButtonXP m_cmdCancel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox m_chkIsMachine;
        private ctlLISDeviceComboBox ctlLISDeviceComboBox1;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    }
}