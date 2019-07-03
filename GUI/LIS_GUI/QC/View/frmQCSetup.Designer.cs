using com.digitalwave.iCare.ValueObject;
using System.Collections.Generic;
namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSetup = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtDeviceId = new System.Windows.Forms.TextBox();
            this.m_txtCheckItemsID = new System.Windows.Forms.TextBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtWaveLength = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpEnddate = new System.Windows.Forms.DateTimePicker();
            this.dtpBegindate = new System.Windows.Forms.DateTimePicker();
            this.txtSortNum = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.txtBValue = new System.Windows.Forms.TextBox();
            this.txtSD = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.txtGroupNum = new System.Windows.Forms.TextBox();
            this.txtItems = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCV = new System.Windows.Forms.Label();
            this.lblBValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboExamineMethod = new com.digitalwave.iCare.gui.LIS.ctlCheckMethodCombox();
            this.cboApparatusType = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.cboConcentration = new com.digitalwave.iCare.gui.LIS.ctlConcentrationCombox();
            this.itemsname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wavelength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concentration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begindate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkitemsid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_strDeviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboManOrigin = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetup)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 270);
            this.panel1.TabIndex = 0;
            // 
            // dgvSetup
            // 
            this.dgvSetup.AllowUserToAddRows = false;
            this.dgvSetup.AllowUserToDeleteRows = false;
            this.dgvSetup.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvSetup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSetup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvSetup.ColumnHeadersHeight = 40;
            this.dgvSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemsname,
            this.unit,
            this.sortNum,
            this.method,
            this.type,
            this.wavelength,
            this.source,
            this.groupnum,
            this.Concentration,
            this.code,
            this.begindate,
            this.enddate,
            this.BValue,
            this.sd,
            this.cv,
            this.intSeq,
            this.checkitemsid,
            this.m_strDeviceId});
            this.dgvSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSetup.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSetup.Location = new System.Drawing.Point(0, 0);
            this.dgvSetup.MultiSelect = false;
            this.dgvSetup.Name = "dgvSetup";
            this.dgvSetup.ReadOnly = true;
            this.dgvSetup.RowHeadersVisible = false;
            this.dgvSetup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSetup.RowTemplate.Height = 23;
            this.dgvSetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSetup.Size = new System.Drawing.Size(942, 270);
            this.dgvSetup.TabIndex = 0;
            this.dgvSetup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetup_CellClick);
            this.dgvSetup.SelectionChanged += new System.EventHandler(this.dgvSetup_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 238);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboManOrigin);
            this.groupBox1.Controls.Add(this.cboExamineMethod);
            this.groupBox1.Controls.Add(this.cboApparatusType);
            this.groupBox1.Controls.Add(this.m_txtDeviceId);
            this.groupBox1.Controls.Add(this.m_txtCheckItemsID);
            this.groupBox1.Controls.Add(this.cboConcentration);
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Controls.Add(this.cmdExit);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.txtWaveLength);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtpEnddate);
            this.groupBox1.Controls.Add(this.dtpBegindate);
            this.groupBox1.Controls.Add(this.txtSortNum);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCV);
            this.groupBox1.Controls.Add(this.txtBValue);
            this.groupBox1.Controls.Add(this.txtSD);
            this.groupBox1.Controls.Add(this.txtSeq);
            this.groupBox1.Controls.Add(this.txtGroupNum);
            this.groupBox1.Controls.Add(this.txtItems);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCV);
            this.groupBox1.Controls.Add(this.lblBValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "质控设置";
            // 
            // m_txtDeviceId
            // 
            this.m_txtDeviceId.Location = new System.Drawing.Point(440, 16);
            this.m_txtDeviceId.Name = "m_txtDeviceId";
            this.m_txtDeviceId.Size = new System.Drawing.Size(100, 21);
            this.m_txtDeviceId.TabIndex = 40;
            this.m_txtDeviceId.Visible = false;
            // 
            // m_txtCheckItemsID
            // 
            this.m_txtCheckItemsID.Location = new System.Drawing.Point(292, 16);
            this.m_txtCheckItemsID.Name = "m_txtCheckItemsID";
            this.m_txtCheckItemsID.Size = new System.Drawing.Size(100, 21);
            this.m_txtCheckItemsID.TabIndex = 39;
            this.m_txtCheckItemsID.Visible = false;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNotice.Location = new System.Drawing.Point(736, 164);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(161, 12);
            this.lblNotice.TabIndex = 36;
            this.lblNotice.Text = "要新增质控请到新增项目界面";
            this.lblNotice.MouseLeave += new System.EventHandler(this.lblNotice_MouseLeave);
            this.lblNotice.MouseEnter += new System.EventHandler(this.lblNotice_MouseEnter);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdExit.Location = new System.Drawing.Point(764, 92);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(107, 33);
            this.cmdExit.TabIndex = 35;
            this.cmdExit.Text = "确定(ESC)";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdSave.Location = new System.Drawing.Point(764, 48);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(107, 33);
            this.cmdSave.TabIndex = 34;
            this.cmdSave.Text = "保存(F3)";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(584, 88);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(120, 21);
            this.txtUnit.TabIndex = 30;
            // 
            // txtWaveLength
            // 
            this.txtWaveLength.Location = new System.Drawing.Point(584, 52);
            this.txtWaveLength.Name = "txtWaveLength";
            this.txtWaveLength.Size = new System.Drawing.Size(120, 21);
            this.txtWaveLength.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(500, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "质控物来源";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(514, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 27;
            this.label13.Text = "检测方法";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(514, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 26;
            this.label14.Text = "检测仪器";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(542, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 25;
            this.label15.Text = "单位";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(542, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 14);
            this.label16.TabIndex = 24;
            this.label16.Text = "波长";
            // 
            // dtpEnddate
            // 
            this.dtpEnddate.CustomFormat = "yyyy-MM-dd";
            this.dtpEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnddate.Location = new System.Drawing.Point(360, 196);
            this.dtpEnddate.Name = "dtpEnddate";
            this.dtpEnddate.Size = new System.Drawing.Size(99, 21);
            this.dtpEnddate.TabIndex = 23;
            // 
            // dtpBegindate
            // 
            this.dtpBegindate.CustomFormat = "yyyy-MM-dd";
            this.dtpBegindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegindate.Location = new System.Drawing.Point(360, 156);
            this.dtpBegindate.Name = "dtpBegindate";
            this.dtpBegindate.Size = new System.Drawing.Size(99, 21);
            this.dtpBegindate.TabIndex = 22;
            // 
            // txtSortNum
            // 
            this.txtSortNum.Location = new System.Drawing.Point(360, 124);
            this.txtSortNum.Name = "txtSortNum";
            this.txtSortNum.Size = new System.Drawing.Size(99, 21);
            this.txtSortNum.TabIndex = 21;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(360, 88);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(99, 21);
            this.txtCode.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(280, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "结束日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(280, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "开始日期";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(294, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "排序号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(252, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "仪器接收编码";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(308, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "浓度";
            // 
            // txtCV
            // 
            this.txtCV.Location = new System.Drawing.Point(116, 200);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(111, 21);
            this.txtCV.TabIndex = 11;
            this.txtCV.Enter += new System.EventHandler(this.txtCV_Enter);
            // 
            // txtBValue
            // 
            this.txtBValue.Location = new System.Drawing.Point(116, 128);
            this.txtBValue.Name = "txtBValue";
            this.txtBValue.Size = new System.Drawing.Size(111, 21);
            this.txtBValue.TabIndex = 10;
            // 
            // txtSD
            // 
            this.txtSD.Location = new System.Drawing.Point(116, 164);
            this.txtSD.Name = "txtSD";
            this.txtSD.Size = new System.Drawing.Size(111, 21);
            this.txtSD.TabIndex = 9;
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(116, 92);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(111, 21);
            this.txtSeq.TabIndex = 8;
            // 
            // txtGroupNum
            // 
            this.txtGroupNum.Location = new System.Drawing.Point(116, 56);
            this.txtGroupNum.Name = "txtGroupNum";
            this.txtGroupNum.ReadOnly = true;
            this.txtGroupNum.Size = new System.Drawing.Size(112, 21);
            this.txtGroupNum.TabIndex = 7;
            // 
            // txtItems
            // 
            this.txtItems.Location = new System.Drawing.Point(116, 24);
            this.txtItems.Name = "txtItems";
            this.txtItems.ReadOnly = true;
            this.txtItems.Size = new System.Drawing.Size(111, 21);
            this.txtItems.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "变异系数";
            // 
            // lblCV
            // 
            this.lblCV.AutoSize = true;
            this.lblCV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCV.Location = new System.Drawing.Point(46, 168);
            this.lblCV.Name = "lblCV";
            this.lblCV.Size = new System.Drawing.Size(49, 14);
            this.lblCV.TabIndex = 4;
            this.lblCV.Text = "标准差";
            // 
            // lblBValue
            // 
            this.lblBValue.AutoSize = true;
            this.lblBValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBValue.Location = new System.Drawing.Point(60, 134);
            this.lblBValue.Name = "lblBValue";
            this.lblBValue.Size = new System.Drawing.Size(35, 14);
            this.lblBValue.TabIndex = 3;
            this.lblBValue.Text = "靶值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "质控批序号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "质控批号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(60, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Column1";
            this.dataGridViewTextBoxColumn1.HeaderText = "项目";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 327;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Column2";
            this.dataGridViewTextBoxColumn2.HeaderText = "单位";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Column3";
            this.dataGridViewTextBoxColumn3.HeaderText = "排序号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Column4";
            this.dataGridViewTextBoxColumn4.HeaderText = "检测方法";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Column5";
            this.dataGridViewTextBoxColumn5.HeaderText = "仪器型号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Column6";
            this.dataGridViewTextBoxColumn6.HeaderText = "检测波长";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Column7";
            this.dataGridViewTextBoxColumn7.HeaderText = "质控物来源";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Column8";
            this.dataGridViewTextBoxColumn8.HeaderText = "质控批号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Column9";
            this.dataGridViewTextBoxColumn9.HeaderText = "浓度";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 45;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Column10";
            this.dataGridViewTextBoxColumn10.HeaderText = "仪器接收编码";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 140;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Column11";
            this.dataGridViewTextBoxColumn11.HeaderText = "启用日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Column12";
            this.dataGridViewTextBoxColumn12.HeaderText = "结束日期";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Column13";
            this.dataGridViewTextBoxColumn13.HeaderText = "靶值";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Column14";
            this.dataGridViewTextBoxColumn14.HeaderText = "标准差（SD）";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Column15";
            this.dataGridViewTextBoxColumn15.HeaderText = "变异系数（CV）";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 132;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "intSeq";
            this.dataGridViewTextBoxColumn16.HeaderText = "质控批序号";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "checkitemsid";
            this.dataGridViewTextBoxColumn17.HeaderText = "检验项目ID";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "m_strDeviceId";
            this.dataGridViewTextBoxColumn18.HeaderText = "仪器ID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // cboExamineMethod
            // 
            this.cboExamineMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExamineMethod.FormattingEnabled = true;
            this.cboExamineMethod.Location = new System.Drawing.Point(584, 160);
            this.cboExamineMethod.Name = "cboExamineMethod";
            this.cboExamineMethod.Size = new System.Drawing.Size(120, 20);
            this.cboExamineMethod.TabIndex = 42;
            // 
            // cboApparatusType
            // 
            this.cboApparatusType.FormattingEnabled = true;
            this.cboApparatusType.Location = new System.Drawing.Point(584, 124);
            this.cboApparatusType.Name = "cboApparatusType";
            this.cboApparatusType.Size = new System.Drawing.Size(120, 20);
            this.cboApparatusType.TabIndex = 41;
            // 
            // cboConcentration
            // 
            this.cboConcentration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConcentration.FormattingEnabled = true;
            this.cboConcentration.Location = new System.Drawing.Point(360, 52);
            this.cboConcentration.Name = "cboConcentration";
            this.cboConcentration.Size = new System.Drawing.Size(100, 20);
            this.cboConcentration.TabIndex = 38;
            this.cboConcentration.Value = -2147483648;
            // 
            // itemsname
            // 
            this.itemsname.DataPropertyName = "itemsname";
            this.itemsname.HeaderText = "项目";
            this.itemsname.MaxInputLength = 327;
            this.itemsname.Name = "itemsname";
            this.itemsname.ReadOnly = true;
            this.itemsname.Width = 80;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 60;
            // 
            // sortNum
            // 
            this.sortNum.DataPropertyName = "sortNum";
            this.sortNum.HeaderText = "序号";
            this.sortNum.Name = "sortNum";
            this.sortNum.ReadOnly = true;
            this.sortNum.Width = 45;
            // 
            // method
            // 
            this.method.DataPropertyName = "method";
            this.method.HeaderText = "检测方法";
            this.method.Name = "method";
            this.method.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "检测仪器";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // wavelength
            // 
            this.wavelength.DataPropertyName = "wavelength";
            this.wavelength.HeaderText = "检测波长";
            this.wavelength.Name = "wavelength";
            this.wavelength.ReadOnly = true;
            this.wavelength.Visible = false;
            // 
            // source
            // 
            this.source.DataPropertyName = "source";
            this.source.HeaderText = "质控物来源";
            this.source.Name = "source";
            this.source.ReadOnly = true;
            this.source.Width = 120;
            // 
            // groupnum
            // 
            this.groupnum.DataPropertyName = "groupnum";
            this.groupnum.HeaderText = "质控批号";
            this.groupnum.Name = "groupnum";
            this.groupnum.ReadOnly = true;
            this.groupnum.Width = 45;
            // 
            // Concentration
            // 
            this.Concentration.DataPropertyName = "Concentration";
            this.Concentration.HeaderText = "浓度";
            this.Concentration.Name = "Concentration";
            this.Concentration.ReadOnly = true;
            this.Concentration.Width = 45;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "仪器接收编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 65;
            // 
            // begindate
            // 
            this.begindate.DataPropertyName = "begindate";
            this.begindate.HeaderText = "启用日期";
            this.begindate.Name = "begindate";
            this.begindate.ReadOnly = true;
            // 
            // enddate
            // 
            this.enddate.DataPropertyName = "enddate";
            this.enddate.HeaderText = "结束日期";
            this.enddate.Name = "enddate";
            this.enddate.ReadOnly = true;
            // 
            // BValue
            // 
            this.BValue.DataPropertyName = "BValue";
            this.BValue.HeaderText = "靶值(X)";
            this.BValue.Name = "BValue";
            this.BValue.ReadOnly = true;
            this.BValue.Width = 80;
            // 
            // sd
            // 
            this.sd.DataPropertyName = "sd";
            this.sd.HeaderText = "标准差(SD)";
            this.sd.Name = "sd";
            this.sd.ReadOnly = true;
            this.sd.Width = 80;
            // 
            // cv
            // 
            this.cv.DataPropertyName = "cv";
            this.cv.HeaderText = "变异系数(CV)";
            this.cv.Name = "cv";
            this.cv.ReadOnly = true;
            this.cv.Width = 90;
            // 
            // intSeq
            // 
            this.intSeq.DataPropertyName = "intSeq";
            this.intSeq.HeaderText = "质控批序号";
            this.intSeq.Name = "intSeq";
            this.intSeq.ReadOnly = true;
            this.intSeq.Visible = false;
            // 
            // checkitemsid
            // 
            this.checkitemsid.DataPropertyName = "checkitemsid";
            this.checkitemsid.HeaderText = "检验项目ID";
            this.checkitemsid.Name = "checkitemsid";
            this.checkitemsid.ReadOnly = true;
            this.checkitemsid.Visible = false;
            // 
            // m_strDeviceId
            // 
            this.m_strDeviceId.DataPropertyName = "m_strDeviceId";
            this.m_strDeviceId.HeaderText = "仪器ID";
            this.m_strDeviceId.Name = "m_strDeviceId";
            this.m_strDeviceId.ReadOnly = true;
            this.m_strDeviceId.Visible = false;
            // 
            // cboManOrigin
            // 
            this.cboManOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManOrigin.FormattingEnabled = true;
            this.cboManOrigin.Location = new System.Drawing.Point(584, 196);
            this.cboManOrigin.Name = "cboManOrigin";
            this.cboManOrigin.Size = new System.Drawing.Size(120, 20);
            this.cboManOrigin.TabIndex = 43;
            // 
            // frmQCSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmQCSetup";
            this.Text = "检验质控设置";
            this.Load += new System.EventHandler(this.frmQCSetup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQCSetup_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetup)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSetup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsname;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn wavelength;
        private System.Windows.Forms.DataGridViewTextBoxColumn source;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concentration;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn begindate;
        private System.Windows.Forms.DataGridViewTextBoxColumn enddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cv;
        private System.Windows.Forms.DataGridViewTextBoxColumn intSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkitemsid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_strDeviceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtWaveLength;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpEnddate;
        private System.Windows.Forms.DateTimePicker dtpBegindate;
        private System.Windows.Forms.TextBox txtSortNum;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.TextBox txtBValue;
        private System.Windows.Forms.TextBox txtSD;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.TextBox txtGroupNum;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCV;
        private System.Windows.Forms.Label lblBValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal List<clsLisQCBatchVO> m_objBatchSets;
        internal List<clsLisQCConcentrationVO> m_objConcentrations;
        internal ctlConcentrationCombox cboConcentration;
        private System.Windows.Forms.TextBox m_txtDeviceId;
        private System.Windows.Forms.TextBox m_txtCheckItemsID;
        private ctlCheckMethodCombox cboExamineMethod;
        private ctlLISDeviceComboBox cboApparatusType;
        private ctlVendorCombox cboManOrigin;

    }
}