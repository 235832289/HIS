namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAskForMedicine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskForMedicine));
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_btnFind = new PinkieControls.ButtonXP();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lblSelected = new System.Windows.Forms.Label();
            this.m_dgvMain = new System.Windows.Forms.DataGridView();
            this.m_chkSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_txtBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtAskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtAskDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtAskDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtCommiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtCommitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtAskerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtDeptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvDetail = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtNum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtIPAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtIPUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtOPAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtOPUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtPackQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_datEnd = new System.Windows.Forms.DateTimePicker();
            this.m_datBegin = new System.Windows.Forms.DateTimePicker();
            this.m_cboExportDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtBillId = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.m_txtMedName = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_cboStatus = new System.Windows.Forms.ComboBox();
            this.m_txtApplyDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnCommit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.m_bgwGetMedData = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_btnFind
            // 
            this.m_btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnFind.DefaultScheme = true;
            this.m_btnFind.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnFind.Hint = "";
            this.m_btnFind.Location = new System.Drawing.Point(885, 44);
            this.m_btnFind.Name = "m_btnFind";
            this.m_btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnFind.Size = new System.Drawing.Size(111, 29);
            this.m_btnFind.TabIndex = 7;
            this.m_btnFind.Text = "查 询(&F)";
            this.m_btnFind.Click += new System.EventHandler(this.m_btnFind_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 117);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lblSelected);
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 528);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_lblSelected
            // 
            this.m_lblSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.m_lblSelected.Location = new System.Drawing.Point(6, 4);
            this.m_lblSelected.Name = "m_lblSelected";
            this.m_lblSelected.Size = new System.Drawing.Size(20, 29);
            this.m_lblSelected.TabIndex = 0;
            this.m_lblSelected.Tag = "False";
            this.m_lblSelected.Text = "全选";
            this.m_lblSelected.MouseLeave += new System.EventHandler(this.m_lblSelected_MouseLeave);
            this.m_lblSelected.Click += new System.EventHandler(this.m_lblSelected_Click);
            this.m_lblSelected.MouseEnter += new System.EventHandler(this.m_lblSelected_MouseEnter);
            // 
            // m_dgvMain
            // 
            this.m_dgvMain.AllowUserToAddRows = false;
            this.m_dgvMain.AllowUserToDeleteRows = false;
            this.m_dgvMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.m_dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.m_dgvMain.ColumnHeadersHeight = 35;
            this.m_dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_chkSelected,
            this.m_txtBillNo,
            this.m_txtStatus,
            this.m_txtAskName,
            this.m_txtAskDate,
            this.m_txtAskDeptName,
            this.m_txtCommiter,
            this.m_txtCommitDate,
            this.m_txtComment,
            this.m_txtSeq,
            this.m_txtAskerid,
            this.m_txtDeptid});
            this.m_dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMain.Location = new System.Drawing.Point(0, 0);
            this.m_dgvMain.Margin = new System.Windows.Forms.Padding(0);
            this.m_dgvMain.MultiSelect = false;
            this.m_dgvMain.Name = "m_dgvMain";
            this.m_dgvMain.RowHeadersVisible = false;
            this.m_dgvMain.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.m_dgvMain.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.m_dgvMain.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvMain.RowTemplate.Height = 23;
            this.m_dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvMain.Size = new System.Drawing.Size(450, 524);
            this.m_dgvMain.TabIndex = 0;
            this.m_dgvMain.CurrentCellChanged += new System.EventHandler(this.m_dgvMain_CurrentCellChanged);
            this.m_dgvMain.DoubleClick += new System.EventHandler(this.m_dgvMain_DoubleClick);
            // 
            // m_chkSelected
            // 
            this.m_chkSelected.FalseValue = "False";
            this.m_chkSelected.Frozen = true;
            this.m_chkSelected.HeaderText = "";
            this.m_chkSelected.Name = "m_chkSelected";
            this.m_chkSelected.TrueValue = "True";
            this.m_chkSelected.Width = 30;
            // 
            // m_txtBillNo
            // 
            this.m_txtBillNo.DataPropertyName = "askid_vchr";
            this.m_txtBillNo.HeaderText = "单据号";
            this.m_txtBillNo.Name = "m_txtBillNo";
            this.m_txtBillNo.ReadOnly = true;
            // 
            // m_txtStatus
            // 
            this.m_txtStatus.DataPropertyName = "status_int";
            this.m_txtStatus.HeaderText = "状态";
            this.m_txtStatus.Name = "m_txtStatus";
            this.m_txtStatus.ReadOnly = true;
            this.m_txtStatus.Width = 60;
            // 
            // m_txtAskName
            // 
            this.m_txtAskName.DataPropertyName = "askername";
            this.m_txtAskName.HeaderText = "制单人";
            this.m_txtAskName.Name = "m_txtAskName";
            this.m_txtAskName.ReadOnly = true;
            this.m_txtAskName.Width = 80;
            // 
            // m_txtAskDate
            // 
            this.m_txtAskDate.DataPropertyName = "askdate_dat";
            dataGridViewCellStyle18.Format = "d";
            dataGridViewCellStyle18.NullValue = null;
            this.m_txtAskDate.DefaultCellStyle = dataGridViewCellStyle18;
            this.m_txtAskDate.HeaderText = "请领时间";
            this.m_txtAskDate.Name = "m_txtAskDate";
            this.m_txtAskDate.ReadOnly = true;
            this.m_txtAskDate.Width = 90;
            // 
            // m_txtAskDeptName
            // 
            this.m_txtAskDeptName.DataPropertyName = "askdeptname";
            this.m_txtAskDeptName.HeaderText = "请领单位";
            this.m_txtAskDeptName.Name = "m_txtAskDeptName";
            this.m_txtAskDeptName.ReadOnly = true;
            this.m_txtAskDeptName.Width = 90;
            // 
            // m_txtCommiter
            // 
            this.m_txtCommiter.DataPropertyName = "commitername";
            this.m_txtCommiter.HeaderText = "提交人";
            this.m_txtCommiter.Name = "m_txtCommiter";
            this.m_txtCommiter.ReadOnly = true;
            // 
            // m_txtCommitDate
            // 
            this.m_txtCommitDate.DataPropertyName = "commit_dat";
            dataGridViewCellStyle19.Format = "d";
            dataGridViewCellStyle19.NullValue = null;
            this.m_txtCommitDate.DefaultCellStyle = dataGridViewCellStyle19;
            this.m_txtCommitDate.HeaderText = "提交日期";
            this.m_txtCommitDate.Name = "m_txtCommitDate";
            this.m_txtCommitDate.ReadOnly = true;
            this.m_txtCommitDate.Width = 90;
            // 
            // m_txtComment
            // 
            this.m_txtComment.DataPropertyName = "comment_vchr";
            this.m_txtComment.HeaderText = "备注";
            this.m_txtComment.Name = "m_txtComment";
            this.m_txtComment.ReadOnly = true;
            this.m_txtComment.Width = 150;
            // 
            // m_txtSeq
            // 
            this.m_txtSeq.DataPropertyName = "SERIESID_INT";
            this.m_txtSeq.HeaderText = "流水号";
            this.m_txtSeq.Name = "m_txtSeq";
            this.m_txtSeq.ReadOnly = true;
            this.m_txtSeq.Visible = false;
            // 
            // m_txtAskerid
            // 
            this.m_txtAskerid.DataPropertyName = "askerid_chr";
            this.m_txtAskerid.HeaderText = "制单人id";
            this.m_txtAskerid.Name = "m_txtAskerid";
            this.m_txtAskerid.ReadOnly = true;
            this.m_txtAskerid.Visible = false;
            // 
            // m_txtDeptid
            // 
            this.m_txtDeptid.DataPropertyName = "askdept_chr";
            this.m_txtDeptid.HeaderText = "请领科室id";
            this.m_txtDeptid.Name = "m_txtDeptid";
            this.m_txtDeptid.ReadOnly = true;
            this.m_txtDeptid.Visible = false;
            // 
            // m_dgvDetail
            // 
            this.m_dgvDetail.AllowUserToAddRows = false;
            this.m_dgvDetail.AllowUserToDeleteRows = false;
            this.m_dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.OldLace;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle20;
            this.m_dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.m_dgvDetail.ColumnHeadersHeight = 35;
            this.m_dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtNum1,
            this.m_dgvtxtMedicineCode1,
            this.m_dgvtxtMedicineName1,
            this.m_dgvtxtMedicineSpec1,
            this.m_txtIPAmount,
            this.m_txtIPUnit,
            this.m_txtOPAmount,
            this.m_txtOPUnit,
            this.m_txtPackQty});
            this.m_dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.m_dgvDetail.Name = "m_dgvDetail";
            this.m_dgvDetail.ReadOnly = true;
            this.m_dgvDetail.RowHeadersVisible = false;
            this.m_dgvDetail.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDetail.RowTemplate.Height = 23;
            this.m_dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDetail.Size = new System.Drawing.Size(556, 524);
            this.m_dgvDetail.TabIndex = 1;
            this.m_dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDetail_RowsAdded);
            this.m_dgvDetail.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvDetail_RowsRemoved);
            // 
            // m_dgvtxtNum1
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtNum1.DefaultCellStyle = dataGridViewCellStyle22;
            this.m_dgvtxtNum1.Frozen = true;
            this.m_dgvtxtNum1.HeaderText = "No.";
            this.m_dgvtxtNum1.Name = "m_dgvtxtNum1";
            this.m_dgvtxtNum1.ReadOnly = true;
            this.m_dgvtxtNum1.Width = 35;
            // 
            // m_dgvtxtMedicineCode1
            // 
            this.m_dgvtxtMedicineCode1.DataPropertyName = "assistcode_chr";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtMedicineCode1.DefaultCellStyle = dataGridViewCellStyle23;
            this.m_dgvtxtMedicineCode1.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode1.Name = "m_dgvtxtMedicineCode1";
            this.m_dgvtxtMedicineCode1.ReadOnly = true;
            // 
            // m_dgvtxtMedicineName1
            // 
            this.m_dgvtxtMedicineName1.DataPropertyName = "medicinename_vchr";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtMedicineName1.DefaultCellStyle = dataGridViewCellStyle24;
            this.m_dgvtxtMedicineName1.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName1.Name = "m_dgvtxtMedicineName1";
            this.m_dgvtxtMedicineName1.ReadOnly = true;
            this.m_dgvtxtMedicineName1.Width = 180;
            // 
            // m_dgvtxtMedicineSpec1
            // 
            this.m_dgvtxtMedicineSpec1.DataPropertyName = "medspec_vchr";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtMedicineSpec1.DefaultCellStyle = dataGridViewCellStyle25;
            this.m_dgvtxtMedicineSpec1.HeaderText = "药品规格";
            this.m_dgvtxtMedicineSpec1.Name = "m_dgvtxtMedicineSpec1";
            this.m_dgvtxtMedicineSpec1.ReadOnly = true;
            // 
            // m_txtIPAmount
            // 
            this.m_txtIPAmount.DataPropertyName = "opamount_int";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.NullValue = null;
            this.m_txtIPAmount.DefaultCellStyle = dataGridViewCellStyle26;
            this.m_txtIPAmount.HeaderText = "数量";
            this.m_txtIPAmount.Name = "m_txtIPAmount";
            this.m_txtIPAmount.ReadOnly = true;
            this.m_txtIPAmount.Width = 60;
            // 
            // m_txtIPUnit
            // 
            this.m_txtIPUnit.DataPropertyName = "opunit_chr";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_txtIPUnit.DefaultCellStyle = dataGridViewCellStyle27;
            this.m_txtIPUnit.HeaderText = "单位(基本)";
            this.m_txtIPUnit.Name = "m_txtIPUnit";
            this.m_txtIPUnit.ReadOnly = true;
            this.m_txtIPUnit.Width = 110;
            // 
            // m_txtOPAmount
            // 
            this.m_txtOPAmount.DataPropertyName = "ipamount_int";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.NullValue = null;
            this.m_txtOPAmount.DefaultCellStyle = dataGridViewCellStyle28;
            this.m_txtOPAmount.HeaderText = "数量";
            this.m_txtOPAmount.Name = "m_txtOPAmount";
            this.m_txtOPAmount.ReadOnly = true;
            this.m_txtOPAmount.Width = 60;
            // 
            // m_txtOPUnit
            // 
            this.m_txtOPUnit.DataPropertyName = "ipunit_chr";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_txtOPUnit.DefaultCellStyle = dataGridViewCellStyle29;
            this.m_txtOPUnit.HeaderText = "单位(最小)";
            this.m_txtOPUnit.Name = "m_txtOPUnit";
            this.m_txtOPUnit.ReadOnly = true;
            this.m_txtOPUnit.Width = 110;
            // 
            // m_txtPackQty
            // 
            this.m_txtPackQty.DataPropertyName = "packqty_dec";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_txtPackQty.DefaultCellStyle = dataGridViewCellStyle30;
            this.m_txtPackQty.HeaderText = "包装量";
            this.m_txtPackQty.Name = "m_txtPackQty";
            this.m_txtPackQty.ReadOnly = true;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_datEnd);
            this.gradientPanel2.Controls.Add(this.m_datBegin);
            this.gradientPanel2.Controls.Add(this.m_cboExportDept);
            this.gradientPanel2.Controls.Add(this.label2);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.m_btnFind);
            this.gradientPanel2.Controls.Add(this.m_txtBillId);
            this.gradientPanel2.Controls.Add(this.label24);
            this.gradientPanel2.Controls.Add(this.m_txtMedName);
            this.gradientPanel2.Controls.Add(this.label28);
            this.gradientPanel2.Controls.Add(this.m_cboStatus);
            this.gradientPanel2.Controls.Add(this.m_txtApplyDept);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.label4);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 35);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(1016, 82);
            this.gradientPanel2.TabIndex = 0;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_datEnd
            // 
            this.m_datEnd.CustomFormat = "yyyy年MM月dd日";
            this.m_datEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEnd.Location = new System.Drawing.Point(229, 15);
            this.m_datEnd.Name = "m_datEnd";
            this.m_datEnd.Size = new System.Drawing.Size(126, 23);
            this.m_datEnd.TabIndex = 1;
            this.m_datEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datBegin_KeyDown);
            // 
            // m_datBegin
            // 
            this.m_datBegin.CustomFormat = "yyyy年MM月dd日";
            this.m_datBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBegin.Location = new System.Drawing.Point(76, 14);
            this.m_datBegin.Name = "m_datBegin";
            this.m_datBegin.Size = new System.Drawing.Size(126, 23);
            this.m_datBegin.TabIndex = 0;
            this.m_datBegin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datBegin_KeyDown);
            // 
            // m_cboExportDept
            // 
            this.m_cboExportDept.Location = new System.Drawing.Point(683, 14);
            this.m_cboExportDept.Name = "m_cboExportDept";
            this.m_cboExportDept.Size = new System.Drawing.Size(158, 22);
            this.m_cboExportDept.TabIndex = 3;
            this.m_cboExportDept.Enter += new System.EventHandler(this.m_cboExportDept_Enter);
            this.m_cboExportDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datBegin_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(205, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(611, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 102;
            this.label3.Text = "出库部门";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBillId
            // 
            this.m_txtBillId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtBillId.Location = new System.Drawing.Point(439, 47);
            this.m_txtBillId.Name = "m_txtBillId";
            this.m_txtBillId.Size = new System.Drawing.Size(166, 23);
            this.m_txtBillId.TabIndex = 6;
            this.m_txtBillId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datBegin_KeyDown);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(372, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 100;
            this.label24.Text = "单 据 号";
            // 
            // m_txtMedName
            // 
            this.m_txtMedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtMedName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedName.Location = new System.Drawing.Point(75, 47);
            this.m_txtMedName.Name = "m_txtMedName";
            this.m_txtMedName.Size = new System.Drawing.Size(280, 23);
            this.m_txtMedName.TabIndex = 5;
            this.m_txtMedName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedName_KeyDown);
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(9, 53);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 97;
            this.label28.Text = "药品名称";
            // 
            // m_cboStatus
            // 
            this.m_cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboStatus.FormattingEnabled = true;
            this.m_cboStatus.Items.AddRange(new object[] {
            "全部",
            "作废",
            "新制",
            "提交",
            "药库审核",
            "药房审核"});
            this.m_cboStatus.Location = new System.Drawing.Point(886, 13);
            this.m_cboStatus.Name = "m_cboStatus";
            this.m_cboStatus.Size = new System.Drawing.Size(111, 22);
            this.m_cboStatus.TabIndex = 4;
            this.m_cboStatus.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboStatus_KeyDown);
            // 
            // m_txtApplyDept
            // 
            this.m_txtApplyDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtApplyDept.Location = new System.Drawing.Point(439, 13);
            this.m_txtApplyDept.m_objTag = null;
            this.m_txtApplyDept.Name = "m_txtApplyDept";
            this.m_txtApplyDept.Size = new System.Drawing.Size(166, 23);
            this.m_txtApplyDept.TabIndex = 2;
            this.m_txtApplyDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtApplyDept.Enter += new System.EventHandler(this.m_txtApplyDept_Enter);
            this.m_txtApplyDept.FocusNextControl += new System.EventHandler(this.m_txtApplyDept_FocusNextControl);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(847, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "状态";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(371, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "请领部门";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "请领时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnNew,
            this.toolStripSeparator1,
            this.m_btnModify,
            this.toolStripSeparator2,
            this.m_btnDelete,
            this.toolStripSeparator4,
            this.m_btnCommit,
            this.toolStripSeparator3,
            this.m_btnExam,
            this.toolStripSeparator6,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnNew
            // 
            this.m_btnNew.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNew.Image")));
            this.m_btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Size = new System.Drawing.Size(76, 32);
            this.m_btnNew.Text = "新制(&N)";
            this.m_btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnModify
            // 
            this.m_btnModify.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnModify.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModify.Image")));
            this.m_btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnModify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnModify.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnModify.Name = "m_btnModify";
            this.m_btnModify.Size = new System.Drawing.Size(76, 32);
            this.m_btnModify.Text = "修改(&E)";
            this.m_btnModify.Click += new System.EventHandler(this.m_btnModify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDelete.Image")));
            this.m_btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnDelete.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(76, 32);
            this.m_btnDelete.Text = "删除(&E)";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnCommit
            // 
            this.m_btnCommit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnCommit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCommit.Image")));
            this.m_btnCommit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnCommit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnCommit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnCommit.Name = "m_btnCommit";
            this.m_btnCommit.Size = new System.Drawing.Size(76, 32);
            this.m_btnCommit.Text = "提交(&I)";
            this.m_btnCommit.Click += new System.EventHandler(this.m_btnCommit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnExam
            // 
            this.m_btnExam.Enabled = false;
            this.m_btnExam.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExam.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExam.Image")));
            this.m_btnExam.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnExam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExam.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExam.Name = "m_btnExam";
            this.m_btnExam.Size = new System.Drawing.Size(104, 32);
            this.m_btnExam.Text = "药房审核(&A)";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnExit
            // 
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(76, 32);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_bgwGetMedData
            // 
            this.m_bgwGetMedData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetMedData_DoWork);
            // 
            // frmAskForMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnFind;
            this.ClientSize = new System.Drawing.Size(1016, 645);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAskForMedicine";
            this.Text = "门诊药房领药申请";
            this.Load += new System.EventHandler(this.frmAskForMedicine_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_btnModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnCommit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal GradientPanel gradientPanel2;
        internal System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP m_btnFind;
        internal System.Windows.Forms.TextBox m_txtBillId;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.TextBox m_txtMedName;
        internal System.Windows.Forms.Label label28;
        internal System.Windows.Forms.ComboBox m_cboStatus;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtApplyDept;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Label m_lblSelected;
        internal System.Windows.Forms.DataGridView m_dgvMain;
        internal System.Windows.Forms.DataGridView m_dgvDetail;
        internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboExportDept;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.DateTimePicker m_datEnd;
        internal System.Windows.Forms.DateTimePicker m_datBegin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_chkSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtAskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtAskDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtAskDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtCommiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtCommitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtAskerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtDeptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtNum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtIPAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtIPUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtOPAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtOPUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtPackQty;
        private System.Windows.Forms.ToolStripButton m_btnExam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.ComponentModel.BackgroundWorker m_bgwGetMedData;
    }
}

