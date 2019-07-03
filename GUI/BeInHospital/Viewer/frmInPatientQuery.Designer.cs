namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInPatientQuery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cboPSTATUS_INT = new System.Windows.Forms.ComboBox();
            this.cobPaytypeid2 = new System.Windows.Forms.ComboBox();
            this.m_cboSTATE_INT2 = new System.Windows.Forms.ComboBox();
            this.m_txtSPECREMARK = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtPatientDoctor = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName1 = new System.Windows.Forms.TextBox();
            this.lbINPatient = new System.Windows.Forms.Label();
            this.txtINPatient1 = new System.Windows.Forms.TextBox();
            this.m_dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cbInPatientDate = new System.Windows.Forms.CheckBox();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dw_1 = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvPatientList = new System.Windows.Forms.DataGridView();
            this.m_dtvLASTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvINPATIENTID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvSTATE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvPSTATUS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvDOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvSEX_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtveatdiccate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvnursecate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvPayTypeName_VChr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvREMARKNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPatientList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cboPSTATUS_INT);
            this.groupBox1.Controls.Add(this.cobPaytypeid2);
            this.groupBox1.Controls.Add(this.m_cboSTATE_INT2);
            this.groupBox1.Controls.Add(this.m_txtSPECREMARK);
            this.groupBox1.Controls.Add(this.m_txtPatientDoctor);
            this.groupBox1.Controls.Add(this.m_txtArea);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPatientName1);
            this.groupBox1.Controls.Add(this.lbINPatient);
            this.groupBox1.Controls.Add(this.txtINPatient1);
            this.groupBox1.Controls.Add(this.m_dtpBeginDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_cbInPatientDate);
            this.groupBox1.Controls.Add(this.m_dtpEndDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 132);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // m_cboPSTATUS_INT
            // 
            this.m_cboPSTATUS_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPSTATUS_INT.Location = new System.Drawing.Point(274, 50);
            this.m_cboPSTATUS_INT.Name = "m_cboPSTATUS_INT";
            this.m_cboPSTATUS_INT.Size = new System.Drawing.Size(147, 22);
            this.m_cboPSTATUS_INT.TabIndex = 105;
            this.m_cboPSTATUS_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPSTATUS_INT_KeyDown);
            // 
            // cobPaytypeid2
            // 
            this.cobPaytypeid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPaytypeid2.Location = new System.Drawing.Point(477, 51);
            this.cobPaytypeid2.Name = "cobPaytypeid2";
            this.cobPaytypeid2.Size = new System.Drawing.Size(150, 22);
            this.cobPaytypeid2.TabIndex = 104;
            this.cobPaytypeid2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobPaytypeid2_KeyDown);
            // 
            // m_cboSTATE_INT2
            // 
            this.m_cboSTATE_INT2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSTATE_INT2.Location = new System.Drawing.Point(74, 51);
            this.m_cboSTATE_INT2.Name = "m_cboSTATE_INT2";
            this.m_cboSTATE_INT2.Size = new System.Drawing.Size(134, 22);
            this.m_cboSTATE_INT2.TabIndex = 103;
            this.m_cboSTATE_INT2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSTATE_INT2_KeyDown);
            // 
            // m_txtSPECREMARK
            // 
            this.m_txtSPECREMARK.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtSPECREMARK.Location = new System.Drawing.Point(696, 51);
            this.m_txtSPECREMARK.Name = "m_txtSPECREMARK";
            this.m_txtSPECREMARK.Size = new System.Drawing.Size(150, 23);
            this.m_txtSPECREMARK.TabIndex = 102;
            this.m_txtSPECREMARK.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtSPECREMARK_m_evtFindItem);
            this.m_txtSPECREMARK.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtSPECREMARK_m_evtInitListView);
            this.m_txtSPECREMARK.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.cm_txtSPECREMARK_m_evtSelectItem);
            // 
            // m_txtPatientDoctor
            // 
            this.m_txtPatientDoctor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPatientDoctor.Location = new System.Drawing.Point(696, 18);
            this.m_txtPatientDoctor.Name = "m_txtPatientDoctor";
            this.m_txtPatientDoctor.Size = new System.Drawing.Size(150, 23);
            this.m_txtPatientDoctor.TabIndex = 4;
            this.m_txtPatientDoctor.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtPatientDoctor_m_evtFindItem);
            this.m_txtPatientDoctor.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtPatientDoctor_m_evtInitListView);
            this.m_txtPatientDoctor.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtPatientDoctor_m_evtSelectItem);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(477, 18);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(150, 23);
            this.m_txtArea.TabIndex = 3;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            this.m_txtArea.TextChanged += new System.EventHandler(this.m_txtArea_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonXP3);
            this.panel1.Controls.Add(this.m_cmdQuery);
            this.panel1.Controls.Add(this.m_cmdClear);
            this.panel1.Controls.Add(this.m_cmdCancel);
            this.panel1.Location = new System.Drawing.Point(852, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 114);
            this.panel1.TabIndex = 96;
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(90, 59);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(78, 40);
            this.buttonXP3.TabIndex = 13;
            this.buttonXP3.Text = "退出(&Esc)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(3, 9);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(81, 43);
            this.m_cmdQuery.TabIndex = 10;
            this.m_cmdQuery.Text = "查询(&F)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(90, 8);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(78, 44);
            this.m_cmdClear.TabIndex = 11;
            this.m_cmdClear.Text = "清空(&C)";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(2, 59);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(82, 41);
            this.m_cmdCancel.TabIndex = 12;
            this.m_cmdCancel.Text = "打印(&P)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label2.Location = new System.Drawing.Point(625, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 94;
            this.label2.Text = "特注信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName1
            // 
            this.txtPatientName1.BackColor = System.Drawing.Color.White;
            this.txtPatientName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPatientName1.Location = new System.Drawing.Point(274, 18);
            this.txtPatientName1.MaxLength = 25;
            this.txtPatientName1.Name = "txtPatientName1";
            this.txtPatientName1.Size = new System.Drawing.Size(147, 23);
            this.txtPatientName1.TabIndex = 2;
            this.txtPatientName1.Tag = "";
            this.txtPatientName1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientName1_KeyDown);
            // 
            // lbINPatient
            // 
            this.lbINPatient.AutoSize = true;
            this.lbINPatient.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbINPatient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbINPatient.Location = new System.Drawing.Point(6, 22);
            this.lbINPatient.Name = "lbINPatient";
            this.lbINPatient.Size = new System.Drawing.Size(67, 15);
            this.lbINPatient.TabIndex = 87;
            this.lbINPatient.Text = "住院编号";
            // 
            // txtINPatient1
            // 
            this.txtINPatient1.BackColor = System.Drawing.Color.White;
            this.txtINPatient1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtINPatient1.Location = new System.Drawing.Point(74, 18);
            this.txtINPatient1.MaxLength = 25;
            this.txtINPatient1.Name = "txtINPatient1";
            this.txtINPatient1.Size = new System.Drawing.Size(134, 23);
            this.txtINPatient1.TabIndex = 1;
            this.txtINPatient1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtINPatient1_KeyDown);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Enabled = false;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(105, 87);
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(169, 23);
            this.m_dtpBeginDate.TabIndex = 7;
            this.m_dtpBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpBeginDate_KeyDown);
            // 
            // label8
            // 
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label8.Location = new System.Drawing.Point(422, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "费 别";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label7.Location = new System.Drawing.Point(280, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "至";
            // 
            // m_cbInPatientDate
            // 
            this.m_cbInPatientDate.Location = new System.Drawing.Point(12, 88);
            this.m_cbInPatientDate.Name = "m_cbInPatientDate";
            this.m_cbInPatientDate.Size = new System.Drawing.Size(92, 24);
            this.m_cbInPatientDate.TabIndex = 6;
            this.m_cbInPatientDate.Text = "入院时间:";
            this.m_cbInPatientDate.CheckedChanged += new System.EventHandler(this.m_cbInPatientDate_CheckedChanged);
            this.m_cbInPatientDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cbInPatientDate_KeyDown);
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Enabled = false;
            this.m_dtpEndDate.Location = new System.Drawing.Point(309, 87);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(167, 23);
            this.m_dtpEndDate.TabIndex = 8;
            this.m_dtpEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpEndDate_KeyDown);
            // 
            // label5
            // 
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label5.Location = new System.Drawing.Point(209, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "病人状态";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "病情状态";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label4.Location = new System.Drawing.Point(625, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "主任医师";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label3.Location = new System.Drawing.Point(422, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "病 区";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(205, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dw_1
            // 
            this.dw_1.ControlBox = true;
            this.dw_1.DataWindowObject = "d_inpatientquery";
            this.dw_1.LibraryList = "D:\\icar_ver2\\Code\\bin\\Debug\\pbreport.pbl";
            this.dw_1.Location = new System.Drawing.Point(61, 159);
            this.dw_1.MaximizeBox = true;
            this.dw_1.MinimizeBox = true;
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_1.Size = new System.Drawing.Size(855, 526);
            this.dw_1.TabIndex = 18;
            this.dw_1.Text = "dataWindowControl1";
            this.dw_1.TitleBar = true;
            this.dw_1.Visible = false;
            // 
            // m_dgvPatientList
            // 
            this.m_dgvPatientList.AllowUserToAddRows = false;
            this.m_dgvPatientList.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvPatientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dtvLASTNAME_VCHR,
            this.m_dtvINPATIENTID_CHR,
            this.m_dtvAreaName,
            this.m_dtvSTATE_INT,
            this.m_dtvPSTATUS_INT,
            this.m_dtvDOCTOR_VCHR,
            this.m_dtvSEX_CHR,
            this.m_dtveatdiccate,
            this.m_dtvnursecate,
            this.m_dtvPayTypeName_VChr,
            this.m_dtvREMARKNAME_VCHR});
            this.m_dgvPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvPatientList.Location = new System.Drawing.Point(0, 132);
            this.m_dgvPatientList.Name = "m_dgvPatientList";
            this.m_dgvPatientList.ReadOnly = true;
            this.m_dgvPatientList.RowHeadersVisible = false;
            this.m_dgvPatientList.RowTemplate.Height = 23;
            this.m_dgvPatientList.Size = new System.Drawing.Size(1028, 584);
            this.m_dgvPatientList.TabIndex = 17;
            // 
            // m_dtvLASTNAME_VCHR
            // 
            this.m_dtvLASTNAME_VCHR.HeaderText = "病人姓名";
            this.m_dtvLASTNAME_VCHR.Name = "m_dtvLASTNAME_VCHR";
            this.m_dtvLASTNAME_VCHR.ReadOnly = true;
            // 
            // m_dtvINPATIENTID_CHR
            // 
            this.m_dtvINPATIENTID_CHR.HeaderText = "住院号";
            this.m_dtvINPATIENTID_CHR.Name = "m_dtvINPATIENTID_CHR";
            this.m_dtvINPATIENTID_CHR.ReadOnly = true;
            // 
            // m_dtvAreaName
            // 
            this.m_dtvAreaName.HeaderText = "病区";
            this.m_dtvAreaName.Name = "m_dtvAreaName";
            this.m_dtvAreaName.ReadOnly = true;
            // 
            // m_dtvSTATE_INT
            // 
            this.m_dtvSTATE_INT.HeaderText = "病情状态";
            this.m_dtvSTATE_INT.Name = "m_dtvSTATE_INT";
            this.m_dtvSTATE_INT.ReadOnly = true;
            // 
            // m_dtvPSTATUS_INT
            // 
            this.m_dtvPSTATUS_INT.HeaderText = "住院状态";
            this.m_dtvPSTATUS_INT.Name = "m_dtvPSTATUS_INT";
            this.m_dtvPSTATUS_INT.ReadOnly = true;
            // 
            // m_dtvDOCTOR_VCHR
            // 
            this.m_dtvDOCTOR_VCHR.HeaderText = "主治医师";
            this.m_dtvDOCTOR_VCHR.Name = "m_dtvDOCTOR_VCHR";
            this.m_dtvDOCTOR_VCHR.ReadOnly = true;
            // 
            // m_dtvSEX_CHR
            // 
            this.m_dtvSEX_CHR.HeaderText = "性别";
            this.m_dtvSEX_CHR.Name = "m_dtvSEX_CHR";
            this.m_dtvSEX_CHR.ReadOnly = true;
            this.m_dtvSEX_CHR.Width = 60;
            // 
            // m_dtveatdiccate
            // 
            this.m_dtveatdiccate.HeaderText = "饮食";
            this.m_dtveatdiccate.Name = "m_dtveatdiccate";
            this.m_dtveatdiccate.ReadOnly = true;
            this.m_dtveatdiccate.Width = 60;
            // 
            // m_dtvnursecate
            // 
            this.m_dtvnursecate.HeaderText = "护理级别";
            this.m_dtvnursecate.Name = "m_dtvnursecate";
            this.m_dtvnursecate.ReadOnly = true;
            // 
            // m_dtvPayTypeName_VChr
            // 
            this.m_dtvPayTypeName_VChr.HeaderText = "费用类别";
            this.m_dtvPayTypeName_VChr.Name = "m_dtvPayTypeName_VChr";
            this.m_dtvPayTypeName_VChr.ReadOnly = true;
            // 
            // m_dtvREMARKNAME_VCHR
            // 
            this.m_dtvREMARKNAME_VCHR.HeaderText = "特注信息";
            this.m_dtvREMARKNAME_VCHR.Name = "m_dtvREMARKNAME_VCHR";
            this.m_dtvREMARKNAME_VCHR.ReadOnly = true;
            // 
            // frmInPatientQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 716);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.m_dgvPatientList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmInPatientQuery";
            this.Text = "frmInPatientQuery";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInPatientQuery_KeyDown);
            this.Load += new System.EventHandler(this.frmInPatientQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPatientList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.CheckBox m_cbInPatientDate;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDate;
        private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdCancel;
        public PinkieControls.ButtonXP m_cmdQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPatientName1;
        private System.Windows.Forms.Label lbINPatient;
        internal System.Windows.Forms.TextBox txtINPatient1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private PinkieControls.ButtonXP buttonXP3;
        internal com.digitalwave.controls.ctlFindTextBox m_txtPatientDoctor;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        internal com.digitalwave.controls.ctlFindTextBox m_txtSPECREMARK;
        internal System.Windows.Forms.ComboBox m_cboSTATE_INT2;
        internal System.Windows.Forms.ComboBox cobPaytypeid2;
        internal System.Windows.Forms.ComboBox m_cboPSTATUS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvLASTNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvINPATIENTID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvSTATE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvPSTATUS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvDOCTOR_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvSEX_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtveatdiccate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvnursecate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvPayTypeName_VChr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvREMARKNAME_VCHR;
        public System.Windows.Forms.DataGridView m_dgvPatientList;
        public Sybase.DataWindow.DataWindowControl dw_1;
    }
}