namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOrderBooking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dgvBookingList = new System.Windows.Forms.DataGridView();
            this.bookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inpatientNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ctmPrint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpBeginDate = new NullableDateControls.MaskDateEdit();
            this.m_dtpEndDate = new NullableDateControls.MaskDateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtArea = new ControlLibrary.txtListView(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmbPrintFlag = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdReplyForm = new PinkieControls.ButtonXP();
            this.m_cmdBed = new PinkieControls.ButtonXP();
            this.m_cmdPrintForAll = new PinkieControls.ButtonXP();
            this.m_cmdPrintForPat = new PinkieControls.ButtonXP();
            this.m_cmdPrintForArea = new PinkieControls.ButtonXP();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBookingList)).BeginInit();
            this.m_ctmPrint.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.m_dgvBookingList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 506);
            this.panel1.TabIndex = 35;
            // 
            // m_dgvBookingList
            // 
            this.m_dgvBookingList.AllowUserToAddRows = false;
            this.m_dgvBookingList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvBookingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvBookingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookId,
            this.depart,
            this.bedNo,
            this.patName,
            this.inpatientNo,
            this.sex,
            this.orderName,
            this.bookStatus,
            this.bookDate,
            this.bookRemark,
            this.printFlag,
            this.operateDate,
            this.sender,
            this.orderId});
            this.m_dgvBookingList.ContextMenuStrip = this.m_ctmPrint;
            this.m_dgvBookingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvBookingList.Location = new System.Drawing.Point(0, 0);
            this.m_dgvBookingList.Name = "m_dgvBookingList";
            this.m_dgvBookingList.ReadOnly = true;
            this.m_dgvBookingList.RowHeadersVisible = false;
            this.m_dgvBookingList.RowTemplate.Height = 23;
            this.m_dgvBookingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvBookingList.Size = new System.Drawing.Size(1028, 506);
            this.m_dgvBookingList.TabIndex = 28;
            // 
            // bookId
            // 
            this.bookId.HeaderText = "Id";
            this.bookId.Name = "bookId";
            this.bookId.ReadOnly = true;
            this.bookId.Visible = false;
            // 
            // depart
            // 
            this.depart.HeaderText = "科室";
            this.depart.Name = "depart";
            this.depart.ReadOnly = true;
            // 
            // bedNo
            // 
            this.bedNo.HeaderText = "床号";
            this.bedNo.Name = "bedNo";
            this.bedNo.ReadOnly = true;
            this.bedNo.Width = 50;
            // 
            // patName
            // 
            this.patName.HeaderText = "姓名";
            this.patName.Name = "patName";
            this.patName.ReadOnly = true;
            this.patName.Width = 80;
            // 
            // inpatientNo
            // 
            this.inpatientNo.HeaderText = "住院号";
            this.inpatientNo.Name = "inpatientNo";
            this.inpatientNo.ReadOnly = true;
            this.inpatientNo.Width = 80;
            // 
            // sex
            // 
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 50;
            // 
            // orderName
            // 
            this.orderName.HeaderText = "医嘱名称";
            this.orderName.Name = "orderName";
            this.orderName.ReadOnly = true;
            this.orderName.Width = 180;
            // 
            // bookStatus
            // 
            this.bookStatus.HeaderText = "预约状态";
            this.bookStatus.Name = "bookStatus";
            this.bookStatus.ReadOnly = true;
            // 
            // bookDate
            // 
            this.bookDate.HeaderText = "预约批准时间";
            this.bookDate.Name = "bookDate";
            this.bookDate.ReadOnly = true;
            this.bookDate.Width = 140;
            // 
            // bookRemark
            // 
            this.bookRemark.HeaderText = "注意事项";
            this.bookRemark.Name = "bookRemark";
            this.bookRemark.ReadOnly = true;
            this.bookRemark.Width = 150;
            // 
            // printFlag
            // 
            this.printFlag.HeaderText = "打印标志";
            this.printFlag.Name = "printFlag";
            this.printFlag.ReadOnly = true;
            this.printFlag.Width = 60;
            // 
            // operateDate
            // 
            this.operateDate.HeaderText = "操作时间";
            this.operateDate.Name = "operateDate";
            this.operateDate.ReadOnly = true;
            this.operateDate.Width = 140;
            // 
            // sender
            // 
            this.sender.HeaderText = "执行人";
            this.sender.Name = "sender";
            this.sender.ReadOnly = true;
            this.sender.Visible = false;
            // 
            // orderId
            // 
            this.orderId.HeaderText = "医嘱Id";
            this.orderId.Name = "orderId";
            this.orderId.ReadOnly = true;
            this.orderId.Visible = false;
            // 
            // m_ctmPrint
            // 
            this.m_ctmPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctmPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.m_ctmPrint.Name = "m_ctmPrint";
            this.m_ctmPrint.Size = new System.Drawing.Size(145, 26);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItem.Text = "打印申请单";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "从";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "至";
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Location = new System.Drawing.Point(22, 14);
            this.m_dtpBeginDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpBeginDate.TabIndex = 0;
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(177, 14);
            this.m_dtpEndDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpEndDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "病区：";
            // 
            // m_txtArea
            // 
            this.m_txtArea.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtArea.Location = new System.Drawing.Point(354, 14);
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
            this.m_txtArea.Size = new System.Drawing.Size(87, 23);
            this.m_txtArea.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "状态：";
            // 
            // m_cmbStatus
            // 
            this.m_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatus.FormattingEnabled = true;
            this.m_cmbStatus.Items.AddRange(new object[] {
            "全部",
            "预约未确认",
            "预约通过",
            "预约未通过"});
            this.m_cmbStatus.Location = new System.Drawing.Point(484, 15);
            this.m_cmbStatus.Name = "m_cmbStatus";
            this.m_cmbStatus.Size = new System.Drawing.Size(96, 22);
            this.m_cmbStatus.TabIndex = 3;
            this.m_cmbStatus.SelectedIndexChanged += new System.EventHandler(this.m_cmbStatus_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmbPrintFlag);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.m_dtpBeginDate);
            this.panel2.Controls.Add(this.m_dtpEndDate);
            this.panel2.Controls.Add(this.m_cmbStatus);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_txtArea);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 99);
            this.panel2.TabIndex = 41;
            // 
            // m_cmbPrintFlag
            // 
            this.m_cmbPrintFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbPrintFlag.FormattingEnabled = true;
            this.m_cmbPrintFlag.Items.AddRange(new object[] {
            "全部",
            "未打印",
            "已打印"});
            this.m_cmbPrintFlag.Location = new System.Drawing.Point(665, 14);
            this.m_cmbPrintFlag.Name = "m_cmbPrintFlag";
            this.m_cmbPrintFlag.Size = new System.Drawing.Size(85, 22);
            this.m_cmbPrintFlag.TabIndex = 41;
            this.m_cmbPrintFlag.SelectedIndexChanged += new System.EventHandler(this.m_cmbPrintFlag_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "打印标志:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdReplyForm);
            this.groupBox1.Controls.Add(this.m_cmdBed);
            this.groupBox1.Controls.Add(this.m_cmdPrintForAll);
            this.groupBox1.Controls.Add(this.m_cmdPrintForPat);
            this.groupBox1.Controls.Add(this.m_cmdPrintForArea);
            this.groupBox1.Controls.Add(this.m_cmdSearch);
            this.groupBox1.Controls.Add(this.m_cmdExit);
            this.groupBox1.Location = new System.Drawing.Point(1, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 48);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // m_cmdReplyForm
            // 
            this.m_cmdReplyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReplyForm.DefaultScheme = true;
            this.m_cmdReplyForm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReplyForm.Hint = "";
            this.m_cmdReplyForm.Location = new System.Drawing.Point(580, 12);
            this.m_cmdReplyForm.Name = "m_cmdReplyForm";
            this.m_cmdReplyForm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReplyForm.Size = new System.Drawing.Size(72, 32);
            this.m_cmdReplyForm.TabIndex = 52;
            this.m_cmdReplyForm.Text = "申请单(&R)";
            this.m_cmdReplyForm.Click += new System.EventHandler(this.m_cmdReplyForm_Click);
            // 
            // m_cmdBed
            // 
            this.m_cmdBed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdBed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdBed.DefaultScheme = true;
            this.m_cmdBed.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBed.Hint = "";
            this.m_cmdBed.Location = new System.Drawing.Point(505, 12);
            this.m_cmdBed.Name = "m_cmdBed";
            this.m_cmdBed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBed.Size = new System.Drawing.Size(72, 32);
            this.m_cmdBed.TabIndex = 44;
            this.m_cmdBed.Text = "床位(&B)";
            this.m_cmdBed.Click += new System.EventHandler(this.m_cmdBed_Click);
            // 
            // m_cmdPrintForAll
            // 
            this.m_cmdPrintForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrintForAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrintForAll.DefaultScheme = true;
            this.m_cmdPrintForAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintForAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrintForAll.Hint = "";
            this.m_cmdPrintForAll.Location = new System.Drawing.Point(863, 12);
            this.m_cmdPrintForAll.Name = "m_cmdPrintForAll";
            this.m_cmdPrintForAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintForAll.Size = new System.Drawing.Size(89, 32);
            this.m_cmdPrintForAll.TabIndex = 42;
            this.m_cmdPrintForAll.Text = "批量打印(&L)";
            this.m_cmdPrintForAll.Click += new System.EventHandler(this.m_cmdPrintForAll_Click);
            // 
            // m_cmdPrintForPat
            // 
            this.m_cmdPrintForPat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrintForPat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrintForPat.DefaultScheme = true;
            this.m_cmdPrintForPat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintForPat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrintForPat.Hint = "";
            this.m_cmdPrintForPat.Location = new System.Drawing.Point(759, 12);
            this.m_cmdPrintForPat.Name = "m_cmdPrintForPat";
            this.m_cmdPrintForPat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintForPat.Size = new System.Drawing.Size(101, 32);
            this.m_cmdPrintForPat.TabIndex = 41;
            this.m_cmdPrintForPat.Text = "按个人打印(&O)";
            this.m_cmdPrintForPat.Click += new System.EventHandler(this.m_cmdPrintForPat_Click);
            // 
            // m_cmdPrintForArea
            // 
            this.m_cmdPrintForArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrintForArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrintForArea.DefaultScheme = true;
            this.m_cmdPrintForArea.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintForArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrintForArea.Hint = "";
            this.m_cmdPrintForArea.Location = new System.Drawing.Point(655, 12);
            this.m_cmdPrintForArea.Name = "m_cmdPrintForArea";
            this.m_cmdPrintForArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintForArea.Size = new System.Drawing.Size(101, 32);
            this.m_cmdPrintForArea.TabIndex = 40;
            this.m_cmdPrintForArea.Text = "按科室打印(&P)";
            this.m_cmdPrintForArea.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(430, 12);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(72, 32);
            this.m_cmdSearch.TabIndex = 39;
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
            this.m_cmdExit.Location = new System.Drawing.Point(955, 12);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(68, 32);
            this.m_cmdExit.TabIndex = 43;
            this.m_cmdExit.Text = "关闭(&E)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // frmOrderBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmOrderBooking";
            this.Text = "病区检查预约查询";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderBooking_KeyDown);
            this.Load += new System.EventHandler(this.frmOrderBooking_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBookingList)).EndInit();
            this.m_ctmPrint.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal NullableDateControls.MaskDateEdit m_dtpBeginDate;
        internal NullableDateControls.MaskDateEdit m_dtpEndDate;
        private System.Windows.Forms.Label label3;
        internal ControlLibrary.txtListView m_txtArea;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cmbStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private PinkieControls.ButtonXP m_cmdBed;
        private PinkieControls.ButtonXP m_cmdPrintForAll;
        private PinkieControls.ButtonXP m_cmdPrintForPat;
        private PinkieControls.ButtonXP m_cmdPrintForArea;
        private PinkieControls.ButtonXP m_cmdSearch;
        private PinkieControls.ButtonXP m_cmdExit;
        internal System.Windows.Forms.ComboBox m_cmbPrintFlag;
        private System.Windows.Forms.Label label5;
        private PinkieControls.ButtonXP m_cmdReplyForm;
        internal System.Windows.Forms.DataGridView m_dgvBookingList;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn depart;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn patName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpatientNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn printFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn operateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        internal System.Windows.Forms.ContextMenuStrip m_ctmPrint;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
    }
}