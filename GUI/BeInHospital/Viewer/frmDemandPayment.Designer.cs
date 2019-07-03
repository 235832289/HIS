namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmDemandPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemandPayment));
            this.m_dgvDetail = new System.Windows.Forms.DataGridView();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPATIENTID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENTCARDID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LASTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYCARDDESC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitClearFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitChargeFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrepayMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIMITRATE_MNY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.dw_1 = new Sybase.DataWindow.DataWindowControl();
            this.m_cmdPrintList = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMaxMoney = new System.Windows.Forms.TextBox();
            this.m_cmdPrtOne = new PinkieControls.ButtonXP();
            this.m_cmdPrtAll = new PinkieControls.ButtonXP();
            this.m_ckbLeft = new System.Windows.Forms.CheckBox();
            this.m_cmbStatus = new System.Windows.Forms.ComboBox();
            this.m_lblStatus = new System.Windows.Forms.Label();
            this.m_txtArea = new ControlLibrary.txtListView(this.components);
            this.m_ckbInclude = new System.Windows.Forms.CheckBox();
            this.m_ckbWaitCharge = new System.Windows.Forms.CheckBox();
            this.m_cmdEveryDayBill = new PinkieControls.ButtonXP();
            this.m_cmdEveryDayBillForPer = new PinkieControls.ButtonXP();
            this.dwEveryDayBill = new Sybase.DataWindow.DataWindowControl();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dteBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dteEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblCysj = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvDetail
            // 
            this.m_dgvDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AreaName,
            this.CaseDoctor,
            this.CODE_CHR,
            this.INPATIENTID_CHR,
            this.PATIENTCARDID_CHR,
            this.LASTNAME_VCHR,
            this.PAYCARDDESC_VCHR,
            this.DAYS,
            this.totalFee,
            this.WaitClearFee,
            this.WaitChargeFee,
            this.PrepayMoney,
            this.BalanceFee,
            this.LIMITRATE_MNY,
            this.REMARKNAME_VCHR,
            this.des,
            this.registerId});
            this.m_dgvDetail.Location = new System.Drawing.Point(0, 80);
            this.m_dgvDetail.Name = "m_dgvDetail";
            this.m_dgvDetail.ReadOnly = true;
            this.m_dgvDetail.RowHeadersVisible = false;
            this.m_dgvDetail.RowTemplate.Height = 23;
            this.m_dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDetail.Size = new System.Drawing.Size(989, 569);
            this.m_dgvDetail.TabIndex = 0;
            // 
            // AreaName
            // 
            this.AreaName.HeaderText = "病区名称";
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            // 
            // CaseDoctor
            // 
            this.CaseDoctor.HeaderText = "主治医生";
            this.CaseDoctor.Name = "CaseDoctor";
            this.CaseDoctor.ReadOnly = true;
            // 
            // CODE_CHR
            // 
            this.CODE_CHR.HeaderText = "床号";
            this.CODE_CHR.Name = "CODE_CHR";
            this.CODE_CHR.ReadOnly = true;
            this.CODE_CHR.Width = 60;
            // 
            // INPATIENTID_CHR
            // 
            this.INPATIENTID_CHR.HeaderText = "住院号";
            this.INPATIENTID_CHR.Name = "INPATIENTID_CHR";
            this.INPATIENTID_CHR.ReadOnly = true;
            this.INPATIENTID_CHR.Width = 80;
            // 
            // PATIENTCARDID_CHR
            // 
            this.PATIENTCARDID_CHR.HeaderText = "诊疗卡号";
            this.PATIENTCARDID_CHR.Name = "PATIENTCARDID_CHR";
            this.PATIENTCARDID_CHR.ReadOnly = true;
            this.PATIENTCARDID_CHR.Visible = false;
            // 
            // LASTNAME_VCHR
            // 
            this.LASTNAME_VCHR.HeaderText = "姓名";
            this.LASTNAME_VCHR.Name = "LASTNAME_VCHR";
            this.LASTNAME_VCHR.ReadOnly = true;
            this.LASTNAME_VCHR.Width = 80;
            // 
            // PAYCARDDESC_VCHR
            // 
            this.PAYCARDDESC_VCHR.HeaderText = "费用类别";
            this.PAYCARDDESC_VCHR.Name = "PAYCARDDESC_VCHR";
            this.PAYCARDDESC_VCHR.ReadOnly = true;
            // 
            // DAYS
            // 
            this.DAYS.HeaderText = "住院天数";
            this.DAYS.Name = "DAYS";
            this.DAYS.ReadOnly = true;
            this.DAYS.Visible = false;
            // 
            // totalFee
            // 
            this.totalFee.HeaderText = "总费用";
            this.totalFee.Name = "totalFee";
            this.totalFee.ReadOnly = true;
            this.totalFee.Visible = false;
            this.totalFee.Width = 80;
            // 
            // WaitClearFee
            // 
            this.WaitClearFee.HeaderText = "待清费用";
            this.WaitClearFee.Name = "WaitClearFee";
            this.WaitClearFee.ReadOnly = true;
            // 
            // WaitChargeFee
            // 
            this.WaitChargeFee.HeaderText = "待结费用";
            this.WaitChargeFee.Name = "WaitChargeFee";
            this.WaitChargeFee.ReadOnly = true;
            // 
            // PrepayMoney
            // 
            this.PrepayMoney.HeaderText = "预交款";
            this.PrepayMoney.Name = "PrepayMoney";
            this.PrepayMoney.ReadOnly = true;
            this.PrepayMoney.Width = 80;
            // 
            // BalanceFee
            // 
            this.BalanceFee.HeaderText = "结余";
            this.BalanceFee.Name = "BalanceFee";
            this.BalanceFee.ReadOnly = true;
            this.BalanceFee.Width = 80;
            // 
            // LIMITRATE_MNY
            // 
            this.LIMITRATE_MNY.HeaderText = "费用下限";
            this.LIMITRATE_MNY.Name = "LIMITRATE_MNY";
            this.LIMITRATE_MNY.ReadOnly = true;
            // 
            // REMARKNAME_VCHR
            // 
            this.REMARKNAME_VCHR.HeaderText = "特注信息";
            this.REMARKNAME_VCHR.Name = "REMARKNAME_VCHR";
            this.REMARKNAME_VCHR.ReadOnly = true;
            this.REMARKNAME_VCHR.Width = 200;
            // 
            // des
            // 
            this.des.HeaderText = "备注";
            this.des.Name = "des";
            this.des.ReadOnly = true;
            // 
            // registerId
            // 
            this.registerId.HeaderText = "住院登记号";
            this.registerId.Name = "registerId";
            this.registerId.ReadOnly = true;
            this.registerId.Visible = false;
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(495, 8);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(85, 31);
            this.m_cmdSearch.TabIndex = 4;
            this.m_cmdSearch.Text = "查询(&S)";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(902, 8);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(85, 31);
            this.m_cmdExit.TabIndex = 3;
            this.m_cmdExit.Text = "关闭(&E)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "病区：";
            // 
            // dw_1
            // 
            this.dw_1.ControlBox = true;
            this.dw_1.DataWindowObject = "d_demandpayment";
            this.dw_1.LibraryList = ".\\\\pbreport.pbl";
            this.dw_1.Location = new System.Drawing.Point(41, 403);
            this.dw_1.MaximizeBox = true;
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_1.Size = new System.Drawing.Size(121, 95);
            this.dw_1.TabIndex = 25;
            this.dw_1.Text = "打印";
            this.dw_1.TitleBar = true;
            this.dw_1.Visible = false;
            // 
            // m_cmdPrintList
            // 
            this.m_cmdPrintList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrintList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrintList.DefaultScheme = true;
            this.m_cmdPrintList.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrintList.Hint = "";
            this.m_cmdPrintList.Location = new System.Drawing.Point(585, 8);
            this.m_cmdPrintList.Name = "m_cmdPrintList";
            this.m_cmdPrintList.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintList.Size = new System.Drawing.Size(109, 31);
            this.m_cmdPrintList.TabIndex = 26;
            this.m_cmdPrintList.Text = "打印病区催款单";
            this.m_cmdPrintList.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "催款限额：";
            // 
            // m_txtMaxMoney
            // 
            this.m_txtMaxMoney.Location = new System.Drawing.Point(441, 48);
            this.m_txtMaxMoney.Name = "m_txtMaxMoney";
            this.m_txtMaxMoney.Size = new System.Drawing.Size(79, 23);
            this.m_txtMaxMoney.TabIndex = 3;
            this.m_txtMaxMoney.Enter += new System.EventHandler(this.m_txtMaxMoney_Enter);
            this.m_txtMaxMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMaxMoney_KeyDown);
            // 
            // m_cmdPrtOne
            // 
            this.m_cmdPrtOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrtOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrtOne.DefaultScheme = true;
            this.m_cmdPrtOne.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrtOne.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrtOne.Hint = "";
            this.m_cmdPrtOne.Location = new System.Drawing.Point(699, 8);
            this.m_cmdPrtOne.Name = "m_cmdPrtOne";
            this.m_cmdPrtOne.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrtOne.Size = new System.Drawing.Size(109, 31);
            this.m_cmdPrtOne.TabIndex = 29;
            this.m_cmdPrtOne.Text = "打印个人催款单";
            this.m_cmdPrtOne.Click += new System.EventHandler(this.m_cmdPrtOne_Click);
            // 
            // m_cmdPrtAll
            // 
            this.m_cmdPrtAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrtAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrtAll.DefaultScheme = true;
            this.m_cmdPrtAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrtAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrtAll.Hint = "";
            this.m_cmdPrtAll.Location = new System.Drawing.Point(812, 8);
            this.m_cmdPrtAll.Name = "m_cmdPrtAll";
            this.m_cmdPrtAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrtAll.Size = new System.Drawing.Size(85, 31);
            this.m_cmdPrtAll.TabIndex = 30;
            this.m_cmdPrtAll.Text = "批量打印";
            this.m_cmdPrtAll.Click += new System.EventHandler(this.m_cmdPrtAll_Click);
            // 
            // m_ckbLeft
            // 
            this.m_ckbLeft.AutoSize = true;
            this.m_ckbLeft.Enabled = false;
            this.m_ckbLeft.Location = new System.Drawing.Point(64, 15);
            this.m_ckbLeft.Name = "m_ckbLeft";
            this.m_ckbLeft.Size = new System.Drawing.Size(68, 18);
            this.m_ckbLeft.TabIndex = 31;
            this.m_ckbLeft.Text = "已出院";
            this.m_ckbLeft.UseVisualStyleBackColor = true;
            this.m_ckbLeft.Visible = false;
            this.m_ckbLeft.CheckedChanged += new System.EventHandler(this.m_ckbLeft_CheckedChanged);
            // 
            // m_cmbStatus
            // 
            this.m_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatus.FormattingEnabled = true;
            this.m_cmbStatus.Items.AddRange(new object[] {
            "全部",
            "已欠",
            "将欠"});
            this.m_cmbStatus.Location = new System.Drawing.Point(411, 12);
            this.m_cmbStatus.Name = "m_cmbStatus";
            this.m_cmbStatus.Size = new System.Drawing.Size(64, 22);
            this.m_cmbStatus.TabIndex = 2;
            this.m_cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmbStatus_KeyDown);
            // 
            // m_lblStatus
            // 
            this.m_lblStatus.AutoSize = true;
            this.m_lblStatus.Location = new System.Drawing.Point(345, 16);
            this.m_lblStatus.Name = "m_lblStatus";
            this.m_lblStatus.Size = new System.Drawing.Size(63, 14);
            this.m_lblStatus.TabIndex = 33;
            this.m_lblStatus.Text = "欠费状态";
            // 
            // m_txtArea
            // 
            this.m_txtArea.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtArea.Location = new System.Drawing.Point(45, 12);
            this.m_txtArea.m_blnFocuseShow = true;
            this.m_txtArea.m_blnPagination = false;
            this.m_txtArea.m_dtbDataSourse = null;
            this.m_txtArea.m_intDelayTime = 100;
            this.m_txtArea.m_intPageRows = 10;
            this.m_txtArea.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtArea.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtArea.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtArea.m_strSaveField = "deptid_chr";
            this.m_txtArea.m_strShowField = "deptname_vchr";
            this.m_txtArea.m_strSQL = null;
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(123, 23);
            this.m_txtArea.TabIndex = 1;
            // 
            // m_ckbInclude
            // 
            this.m_ckbInclude.AutoSize = true;
            this.m_ckbInclude.Checked = true;
            this.m_ckbInclude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbInclude.Location = new System.Drawing.Point(184, 14);
            this.m_ckbInclude.Name = "m_ckbInclude";
            this.m_ckbInclude.Size = new System.Drawing.Size(82, 18);
            this.m_ckbInclude.TabIndex = 34;
            this.m_ckbInclude.Text = "含无费用";
            this.m_ckbInclude.UseVisualStyleBackColor = true;
            // 
            // m_ckbWaitCharge
            // 
            this.m_ckbWaitCharge.AutoSize = true;
            this.m_ckbWaitCharge.Checked = true;
            this.m_ckbWaitCharge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbWaitCharge.Location = new System.Drawing.Point(272, 14);
            this.m_ckbWaitCharge.Name = "m_ckbWaitCharge";
            this.m_ckbWaitCharge.Size = new System.Drawing.Size(68, 18);
            this.m_ckbWaitCharge.TabIndex = 35;
            this.m_ckbWaitCharge.Text = "含未结";
            this.m_ckbWaitCharge.UseVisualStyleBackColor = true;
            // 
            // m_cmdEveryDayBill
            // 
            this.m_cmdEveryDayBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdEveryDayBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdEveryDayBill.DefaultScheme = true;
            this.m_cmdEveryDayBill.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEveryDayBill.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEveryDayBill.Hint = "";
            this.m_cmdEveryDayBill.Location = new System.Drawing.Point(764, 46);
            this.m_cmdEveryDayBill.Name = "m_cmdEveryDayBill";
            this.m_cmdEveryDayBill.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEveryDayBill.Size = new System.Drawing.Size(109, 31);
            this.m_cmdEveryDayBill.TabIndex = 36;
            this.m_cmdEveryDayBill.Text = "病区每日清单";
            this.m_cmdEveryDayBill.Click += new System.EventHandler(this.m_cmdEveryDayBill_Click);
            // 
            // m_cmdEveryDayBillForPer
            // 
            this.m_cmdEveryDayBillForPer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdEveryDayBillForPer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdEveryDayBillForPer.DefaultScheme = true;
            this.m_cmdEveryDayBillForPer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEveryDayBillForPer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEveryDayBillForPer.Hint = "";
            this.m_cmdEveryDayBillForPer.Location = new System.Drawing.Point(878, 46);
            this.m_cmdEveryDayBillForPer.Name = "m_cmdEveryDayBillForPer";
            this.m_cmdEveryDayBillForPer.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEveryDayBillForPer.Size = new System.Drawing.Size(109, 31);
            this.m_cmdEveryDayBillForPer.TabIndex = 37;
            this.m_cmdEveryDayBillForPer.Text = "个人每日清单";
            this.m_cmdEveryDayBillForPer.Click += new System.EventHandler(this.m_cmdEveryDayBillForPer_Click);
            // 
            // dwEveryDayBill
            // 
            this.dwEveryDayBill.ControlBox = true;
            this.dwEveryDayBill.DataWindowObject = "d_everydaybill";
            this.dwEveryDayBill.LibraryList = "pbreport.pbl";
            this.dwEveryDayBill.Location = new System.Drawing.Point(201, 93);
            this.dwEveryDayBill.MaximizeBox = true;
            this.dwEveryDayBill.Name = "dwEveryDayBill";
            this.dwEveryDayBill.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwEveryDayBill.Size = new System.Drawing.Size(74, 61);
            this.dwEveryDayBill.TabIndex = 38;
            this.dwEveryDayBill.Text = "打印EveryDayBill";
            this.dwEveryDayBill.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "每日一清日期:";
            // 
            // m_dtpDate
            // 
            this.m_dtpDate.CustomFormat = "yyyy年MM月dd日";
            this.m_dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDate.Location = new System.Drawing.Point(628, 50);
            this.m_dtpDate.Name = "m_dtpDate";
            this.m_dtpDate.Size = new System.Drawing.Size(121, 23);
            this.m_dtpDate.TabIndex = 40;
            this.m_dtpDate.Value = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            // 
            // dteBeginDate
            // 
            this.dteBeginDate.CustomFormat = "yyyy年MM月dd日";
            this.dteBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteBeginDate.Location = new System.Drawing.Point(93, 48);
            this.dteBeginDate.Name = "dteBeginDate";
            this.dteBeginDate.Size = new System.Drawing.Size(121, 23);
            this.dteBeginDate.TabIndex = 41;
            this.dteBeginDate.Value = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.dteBeginDate.Visible = false;
            // 
            // dteEndDate
            // 
            this.dteEndDate.CustomFormat = "yyyy年MM月dd日";
            this.dteEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteEndDate.Location = new System.Drawing.Point(239, 48);
            this.dteEndDate.Name = "dteEndDate";
            this.dteEndDate.Size = new System.Drawing.Size(121, 23);
            this.dteEndDate.TabIndex = 42;
            this.dteEndDate.Value = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.dteEndDate.Visible = false;
            // 
            // lblCysj
            // 
            this.lblCysj.AutoSize = true;
            this.lblCysj.Location = new System.Drawing.Point(2, 51);
            this.lblCysj.Name = "lblCysj";
            this.lblCysj.Size = new System.Drawing.Size(91, 14);
            this.lblCysj.TabIndex = 43;
            this.lblCysj.Text = "出院时间：从";
            this.lblCysj.Visible = false;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(217, 51);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(21, 14);
            this.lblToDate.TabIndex = 44;
            this.lblToDate.Text = "到";
            this.lblToDate.Visible = false;
            // 
            // frmDemandPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 649);
            this.Controls.Add(this.m_txtArea);
            this.Controls.Add(this.m_dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cmdEveryDayBillForPer);
            this.Controls.Add(this.m_cmdEveryDayBill);
            this.Controls.Add(this.m_ckbWaitCharge);
            this.Controls.Add(this.m_ckbInclude);
            this.Controls.Add(this.m_cmbStatus);
            this.Controls.Add(this.m_lblStatus);
            this.Controls.Add(this.m_ckbLeft);
            this.Controls.Add(this.m_cmdPrtAll);
            this.Controls.Add(this.m_cmdPrtOne);
            this.Controls.Add(this.m_txtMaxMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cmdPrintList);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_dgvDetail);
            this.Controls.Add(this.dwEveryDayBill);
            this.Controls.Add(this.lblCysj);
            this.Controls.Add(this.dteBeginDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dteEndDate);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDemandPayment";
            this.Text = "催款查询";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmDemandPayment_Layout);
            this.Load += new System.EventHandler(this.frmDemandPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView m_dgvDetail;
        private PinkieControls.ButtonXP m_cmdSearch;
        private PinkieControls.ButtonXP m_cmdExit;
        private System.Windows.Forms.Label label1;
        internal Sybase.DataWindow.DataWindowControl dw_1;
        private PinkieControls.ButtonXP m_cmdPrintList;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox m_txtMaxMoney;
        private PinkieControls.ButtonXP m_cmdPrtOne;
        private PinkieControls.ButtonXP m_cmdPrtAll;
        internal System.Windows.Forms.CheckBox m_ckbLeft;
        private System.Windows.Forms.Label m_lblStatus;
        internal System.Windows.Forms.ComboBox m_cmbStatus;
        internal ControlLibrary.txtListView m_txtArea;
        internal System.Windows.Forms.CheckBox m_ckbInclude;
        internal System.Windows.Forms.CheckBox m_ckbWaitCharge;
        private PinkieControls.ButtonXP m_cmdEveryDayBillForPer;
        internal PinkieControls.ButtonXP m_cmdEveryDayBill;
        internal Sybase.DataWindow.DataWindowControl dwEveryDayBill;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker m_dtpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENTID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENTCARDID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LASTNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYCARDDESC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAYS;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitClearFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitChargeFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrepayMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIMITRATE_MNY;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn des;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerId;
        internal System.Windows.Forms.DateTimePicker dteBeginDate;
        internal System.Windows.Forms.DateTimePicker dteEndDate;
        internal System.Windows.Forms.Label lblCysj;
        internal System.Windows.Forms.Label lblToDate;

    }
}