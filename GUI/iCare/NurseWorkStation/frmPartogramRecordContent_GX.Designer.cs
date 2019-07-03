namespace iCare
{
    partial class frmPartogramRecordContent_GX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartogramRecordContent_GX));
            this.m_cmdOK = new ExternalControlsLib.XPButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmdCancel = new ExternalControlsLib.XPButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtUterineContractionMin = new com.digitalwave.Controls.ctlMaskedNumber();
            this.m_txtDiastolicPressure = new com.digitalwave.Controls.ctlMaskedNumber();
            this.m_txtUterineContraction = new com.digitalwave.Controls.ctlMaskedNumber();
            this.m_txtSystolicPressure = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtFe = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkChildbearingPoint = new com.digitalwave.Controls.ctlCheckBox();
            this.m_lsvU = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_numUtricm = new System.Windows.Forms.NumericUpDown();
            this.m_txtMin1 = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_cmdAddU = new ExternalControlsLib.XPButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_numDown = new System.Windows.Forms.NumericUpDown();
            this.m_lsvDown = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mniDelete2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txtMin2 = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cmdAddDown = new ExternalControlsLib.XPButton();
            this.m_cmdSign = new ExternalControlsLib.XPButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_txtProsses = new com.digitalwave.controls.ctlRichTextBox();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lblGiveBirthDate = new System.Windows.Forms.Label();
            this.m_dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.m_cboHours = new com.digitalwave.Controls.ctlComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUtricm)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDown)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(299, -55);
            this.m_trvCreateDate.Size = new System.Drawing.Size(40, 10);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(17, 9);
            this.lblCreateDateTitle.Text = "检查时间:";
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(91, -35);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(224, 22);
            this.m_dtpCreateDate.TabIndex = 0;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(336, -39);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(30, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(296, -21);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(184, -29);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(310, -29);
            this.lblAge.Size = new System.Drawing.Size(61, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(214, -59);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(200, -22);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(285, -54);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(128, -29);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(254, -29);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(83, -26);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(327, 79);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(266, -27);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(336, -59);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(266, -64);
            this.m_txtBedNO.Size = new System.Drawing.Size(10, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(131, -29);
            this.m_cboArea.Size = new System.Drawing.Size(30, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(527, 42);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(327, -64);
            this.m_lsvBedNO.Size = new System.Drawing.Size(34, 29);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(131, -58);
            this.m_cboDept.Size = new System.Drawing.Size(30, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(83, -54);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 56);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(167, -31);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(167, -59);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(256, -59);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(13, 312);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(86, 19);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(475, -35);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdOK.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdOK.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdOK.Location = new System.Drawing.Point(514, 308);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(75, 30);
            this.m_cmdOK.TabIndex = 7;
            this.m_cmdOK.Text = "确定(&O)";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "血  压:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10000007;
            this.label2.Text = "mmHg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000007;
            this.label3.Text = "秒/分";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 10000007;
            this.label4.Text = "宫  缩:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000007;
            this.label5.Text = "次/分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 10000007;
            this.label6.Text = "胎心率:";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdCancel.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdCancel.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdCancel.Location = new System.Drawing.Point(610, 308);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 30);
            this.m_cmdCancel.TabIndex = 8;
            this.m_cmdCancel.Text = "取消(&C)";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 10000007;
            this.label8.Text = "临产开始时间:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "第";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 10000007;
            this.label12.Text = "小时";
            this.label12.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtUterineContractionMin);
            this.groupBox1.Controls.Add(this.m_txtDiastolicPressure);
            this.groupBox1.Controls.Add(this.m_txtUterineContraction);
            this.groupBox1.Controls.Add(this.m_txtSystolicPressure);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.m_txtFe);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // m_txtUterineContractionMin
            // 
            this.m_txtUterineContractionMin.AccessibleDescription = "宫缩>>分";
            this.m_txtUterineContractionMin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtUterineContractionMin.Location = new System.Drawing.Point(106, 49);
            this.m_txtUterineContractionMin.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtUterineContractionMin.m_DcmMaxNumber = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_txtUterineContractionMin.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtUterineContractionMin.Mask = "99";
            this.m_txtUterineContractionMin.Name = "m_txtUterineContractionMin";
            this.m_txtUterineContractionMin.PromptChar = ' ';
            this.m_txtUterineContractionMin.Size = new System.Drawing.Size(27, 23);
            this.m_txtUterineContractionMin.TabIndex = 3;
            this.m_txtUterineContractionMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtUterineContractionMin.ValidatingType = typeof(decimal);
            // 
            // m_txtDiastolicPressure
            // 
            this.m_txtDiastolicPressure.AccessibleDescription = "舒张压";
            this.m_txtDiastolicPressure.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtDiastolicPressure.Location = new System.Drawing.Point(106, 16);
            this.m_txtDiastolicPressure.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtDiastolicPressure.m_DcmMaxNumber = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_txtDiastolicPressure.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtDiastolicPressure.Mask = "999";
            this.m_txtDiastolicPressure.Name = "m_txtDiastolicPressure";
            this.m_txtDiastolicPressure.PromptChar = ' ';
            this.m_txtDiastolicPressure.Size = new System.Drawing.Size(27, 23);
            this.m_txtDiastolicPressure.TabIndex = 1;
            this.m_txtDiastolicPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDiastolicPressure.ValidatingType = typeof(decimal);
            // 
            // m_txtUterineContraction
            // 
            this.m_txtUterineContraction.AccessibleDescription = "宫缩>>次数";
            this.m_txtUterineContraction.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtUterineContraction.Location = new System.Drawing.Point(67, 49);
            this.m_txtUterineContraction.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtUterineContraction.m_DcmMaxNumber = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_txtUterineContraction.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtUterineContraction.Mask = "999";
            this.m_txtUterineContraction.Name = "m_txtUterineContraction";
            this.m_txtUterineContraction.PromptChar = ' ';
            this.m_txtUterineContraction.Size = new System.Drawing.Size(27, 23);
            this.m_txtUterineContraction.TabIndex = 2;
            this.m_txtUterineContraction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtUterineContraction.ValidatingType = typeof(decimal);
            // 
            // m_txtSystolicPressure
            // 
            this.m_txtSystolicPressure.AccessibleDescription = "收缩压";
            this.m_txtSystolicPressure.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtSystolicPressure.Location = new System.Drawing.Point(67, 16);
            this.m_txtSystolicPressure.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtSystolicPressure.m_DcmMaxNumber = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_txtSystolicPressure.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtSystolicPressure.Mask = "999";
            this.m_txtSystolicPressure.Name = "m_txtSystolicPressure";
            this.m_txtSystolicPressure.PromptChar = ' ';
            this.m_txtSystolicPressure.Size = new System.Drawing.Size(27, 23);
            this.m_txtSystolicPressure.TabIndex = 0;
            this.m_txtSystolicPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtSystolicPressure.ValidatingType = typeof(decimal);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(93, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 14);
            this.label20.TabIndex = 10000007;
            this.label20.Text = "/";
            // 
            // m_txtFe
            // 
            this.m_txtFe.AccessibleDescription = "胎心率";
            this.m_txtFe.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtFe.Location = new System.Drawing.Point(67, 82);
            this.m_txtFe.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtFe.m_DcmMaxNumber = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_txtFe.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtFe.Mask = "999";
            this.m_txtFe.Name = "m_txtFe";
            this.m_txtFe.PromptChar = ' ';
            this.m_txtFe.Size = new System.Drawing.Size(66, 23);
            this.m_txtFe.TabIndex = 4;
            this.m_txtFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtFe.ValidatingType = typeof(decimal);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(93, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 10000007;
            this.label19.Text = "/";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkChildbearingPoint);
            this.groupBox2.Controls.Add(this.m_lsvU);
            this.groupBox2.Controls.Add(this.m_numUtricm);
            this.groupBox2.Controls.Add(this.m_txtMin1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.m_cmdAddU);
            this.groupBox2.Location = new System.Drawing.Point(211, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "宫颈口开大:";
            // 
            // m_chkChildbearingPoint
            // 
            this.m_chkChildbearingPoint.AutoSize = true;
            this.m_chkChildbearingPoint.Location = new System.Drawing.Point(8, 102);
            this.m_chkChildbearingPoint.Name = "m_chkChildbearingPoint";
            this.m_chkChildbearingPoint.Size = new System.Drawing.Size(68, 18);
            this.m_chkChildbearingPoint.TabIndex = 10000236;
            this.m_chkChildbearingPoint.Text = "分娩点";
            this.m_chkChildbearingPoint.UseVisualStyleBackColor = true;
            // 
            // m_lsvU
            // 
            this.m_lsvU.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvU.ContextMenuStrip = this.contextMenuStrip1;
            this.m_lsvU.FullRowSelect = true;
            this.m_lsvU.GridLines = true;
            this.m_lsvU.Location = new System.Drawing.Point(79, 20);
            this.m_lsvU.Name = "m_lsvU";
            this.m_lsvU.Size = new System.Drawing.Size(154, 100);
            this.m_lsvU.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_lsvU.TabIndex = 3;
            this.m_lsvU.UseCompatibleStateImageBehavior = false;
            this.m_lsvU.View = System.Windows.Forms.View.Details;
            this.m_lsvU.DoubleClick += new System.EventHandler(this.m_lsvU_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "开大(cm)";
            this.columnHeader2.Width = 69;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mniDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // m_mniDelete
            // 
            this.m_mniDelete.Name = "m_mniDelete";
            this.m_mniDelete.Size = new System.Drawing.Size(98, 22);
            this.m_mniDelete.Text = "删除";
            this.m_mniDelete.Click += new System.EventHandler(this.m_mniDelete_Click);
            // 
            // m_numUtricm
            // 
            this.m_numUtricm.DecimalPlaces = 1;
            this.m_numUtricm.Location = new System.Drawing.Point(9, 41);
            this.m_numUtricm.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_numUtricm.Name = "m_numUtricm";
            this.m_numUtricm.Size = new System.Drawing.Size(52, 23);
            this.m_numUtricm.TabIndex = 10000235;
            // 
            // m_txtMin1
            // 
            this.m_txtMin1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtMin1.Location = new System.Drawing.Point(132, 33);
            this.m_txtMin1.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtMin1.m_DcmMaxNumber = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_txtMin1.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtMin1.Mask = "99";
            this.m_txtMin1.Name = "m_txtMin1";
            this.m_txtMin1.PromptChar = ' ';
            this.m_txtMin1.Size = new System.Drawing.Size(31, 23);
            this.m_txtMin1.TabIndex = 0;
            this.m_txtMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtMin1.ValidatingType = typeof(decimal);
            this.m_txtMin1.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 10000007;
            this.label15.Text = "开大";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "cm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(165, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000007;
            this.label13.Text = "分钟 ";
            this.label13.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(111, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "第";
            this.label16.Visible = false;
            // 
            // m_cmdAddU
            // 
            this.m_cmdAddU.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddU.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddU.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAddU.Location = new System.Drawing.Point(7, 68);
            this.m_cmdAddU.Name = "m_cmdAddU";
            this.m_cmdAddU.Size = new System.Drawing.Size(69, 30);
            this.m_cmdAddU.TabIndex = 2;
            this.m_cmdAddU.Text = "添加 >>";
            this.m_cmdAddU.UseVisualStyleBackColor = true;
            this.m_cmdAddU.Click += new System.EventHandler(this.m_cmdAddU_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_numDown);
            this.groupBox3.Controls.Add(this.m_lsvDown);
            this.groupBox3.Controls.Add(this.m_txtMin2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.m_cmdAddDown);
            this.groupBox3.Location = new System.Drawing.Point(456, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 126);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "胎儿头下降:";
            // 
            // m_numDown
            // 
            this.m_numDown.DecimalPlaces = 1;
            this.m_numDown.Location = new System.Drawing.Point(6, 39);
            this.m_numDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_numDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.m_numDown.Name = "m_numDown";
            this.m_numDown.Size = new System.Drawing.Size(63, 23);
            this.m_numDown.TabIndex = 10000236;
            // 
            // m_lsvDown
            // 
            this.m_lsvDown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvDown.ContextMenuStrip = this.contextMenuStrip2;
            this.m_lsvDown.FullRowSelect = true;
            this.m_lsvDown.GridLines = true;
            this.m_lsvDown.Location = new System.Drawing.Point(75, 20);
            this.m_lsvDown.Name = "m_lsvDown";
            this.m_lsvDown.Size = new System.Drawing.Size(147, 85);
            this.m_lsvDown.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_lsvDown.TabIndex = 3;
            this.m_lsvDown.UseCompatibleStateImageBehavior = false;
            this.m_lsvDown.View = System.Windows.Forms.View.Details;
            this.m_lsvDown.DoubleClick += new System.EventHandler(this.m_lsvDown_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.Width = 73;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下降";
            this.columnHeader4.Width = 70;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mniDelete2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(99, 26);
            // 
            // m_mniDelete2
            // 
            this.m_mniDelete2.Name = "m_mniDelete2";
            this.m_mniDelete2.Size = new System.Drawing.Size(98, 22);
            this.m_mniDelete2.Text = "删除";
            this.m_mniDelete2.Click += new System.EventHandler(this.m_mniDelete2_Click);
            // 
            // m_txtMin2
            // 
            this.m_txtMin2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtMin2.Location = new System.Drawing.Point(128, 38);
            this.m_txtMin2.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtMin2.m_DcmMaxNumber = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_txtMin2.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtMin2.Mask = "99";
            this.m_txtMin2.Name = "m_txtMin2";
            this.m_txtMin2.PromptChar = ' ';
            this.m_txtMin2.Size = new System.Drawing.Size(31, 23);
            this.m_txtMin2.TabIndex = 0;
            this.m_txtMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtMin2.ValidatingType = typeof(decimal);
            this.m_txtMin2.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000007;
            this.label7.Text = "下降";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(161, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 10000007;
            this.label17.Text = "分钟 ";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(107, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 14);
            this.label18.TabIndex = 10000007;
            this.label18.Text = "第";
            this.label18.Visible = false;
            // 
            // m_cmdAddDown
            // 
            this.m_cmdAddDown.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddDown.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddDown.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAddDown.Location = new System.Drawing.Point(3, 73);
            this.m_cmdAddDown.Name = "m_cmdAddDown";
            this.m_cmdAddDown.Size = new System.Drawing.Size(67, 30);
            this.m_cmdAddDown.TabIndex = 2;
            this.m_cmdAddDown.Text = "添加 >>";
            this.m_cmdAddDown.UseVisualStyleBackColor = true;
            this.m_cmdAddDown.Click += new System.EventHandler(this.m_cmdAddDown_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdSign.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdSign.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdSign.Location = new System.Drawing.Point(101, 308);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Size = new System.Drawing.Size(69, 30);
            this.m_cmdSign.TabIndex = 6;
            this.m_cmdSign.Text = "签名(&S)";
            this.m_cmdSign.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_txtProsses);
            this.groupBox4.Location = new System.Drawing.Point(12, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(675, 123);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "处理:";
            // 
            // m_txtProsses
            // 
            this.m_txtProsses.AccessibleDescription = "处理";
            this.m_txtProsses.BackColor = System.Drawing.Color.White;
            this.m_txtProsses.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProsses.ForeColor = System.Drawing.Color.Black;
            this.m_txtProsses.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtProsses.Location = new System.Drawing.Point(9, 20);
            this.m_txtProsses.m_BlnIgnoreUserInfo = false;
            this.m_txtProsses.m_BlnPartControl = false;
            this.m_txtProsses.m_BlnReadOnly = false;
            this.m_txtProsses.m_BlnUnderLineDST = false;
            this.m_txtProsses.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtProsses.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtProsses.m_IntCanModifyTime = 99;
            this.m_txtProsses.m_IntPartControlLength = 0;
            this.m_txtProsses.m_IntPartControlStartIndex = 0;
            this.m_txtProsses.m_StrUserID = "";
            this.m_txtProsses.m_StrUserName = "";
            this.m_txtProsses.Name = "m_txtProsses";
            this.m_txtProsses.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtProsses.Size = new System.Drawing.Size(659, 97);
            this.m_txtProsses.TabIndex = 0;
            this.m_txtProsses.Text = "";
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(170, 310);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(326, 28);
            this.lsvSign.TabIndex = 10000231;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 55;
            // 
            // lblGiveBirthDate
            // 
            this.lblGiveBirthDate.Location = new System.Drawing.Point(444, 9);
            this.lblGiveBirthDate.Name = "lblGiveBirthDate";
            this.lblGiveBirthDate.Size = new System.Drawing.Size(224, 14);
            this.lblGiveBirthDate.TabIndex = 10000007;
            // 
            // m_dtpCheckDate
            // 
            this.m_dtpCheckDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCheckDate.Location = new System.Drawing.Point(86, 5);
            this.m_dtpCheckDate.Name = "m_dtpCheckDate";
            this.m_dtpCheckDate.Size = new System.Drawing.Size(186, 23);
            this.m_dtpCheckDate.TabIndex = 10000232;
            this.m_dtpCheckDate.ValueChanged += new System.EventHandler(this.m_dtpCheckDate_ValueChanged);
            // 
            // m_cboHours
            // 
            this.m_cboHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboHours.FormattingEnabled = true;
            this.m_cboHours.Location = new System.Drawing.Point(44, 42);
            this.m_cboHours.m_BlnEnableItemEventMenu = true;
            this.m_cboHours.Name = "m_cboHours";
            this.m_cboHours.Size = new System.Drawing.Size(55, 22);
            this.m_cboHours.TabIndex = 1;
            this.m_cboHours.Visible = false;
            this.m_cboHours.SelectedIndexChanged += new System.EventHandler(this.m_cboHours_SelectedIndexChanged);
            // 
            // frmPartogramRecordContent_GX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 352);
            this.Controls.Add(this.m_dtpCheckDate);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.lblGiveBirthDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_cboHours);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPartogramRecordContent_GX";
            this.Text = "产程图记录";
            this.Load += new System.EventHandler(this.frmPartogramRecordContent_GX_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_cboHours, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblGiveBirthDate, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_dtpCheckDate, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUtricm)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDown)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExternalControlsLib.XPButton m_cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtFe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ExternalControlsLib.XPButton m_cmdCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private com.digitalwave.Controls.ctlComboBox m_cboHours;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtMin1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView m_lsvU;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label15;
        private ExternalControlsLib.XPButton m_cmdAddU;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView m_lsvDown;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtMin2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private ExternalControlsLib.XPButton m_cmdAddDown;
        private com.digitalwave.controls.ctlRichTextBox m_txtProsses;
        private ExternalControlsLib.XPButton m_cmdSign;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_mniDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem m_mniDelete2;
        protected System.Windows.Forms.ListView lsvSign;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtUterineContractionMin;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtDiastolicPressure;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtUterineContraction;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtSystolicPressure;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown m_numUtricm;
        private System.Windows.Forms.NumericUpDown m_numDown;
        private System.Windows.Forms.Label lblGiveBirthDate;
        private System.Windows.Forms.DateTimePicker m_dtpCheckDate;
        private com.digitalwave.Controls.ctlCheckBox m_chkChildbearingPoint;
    }
}