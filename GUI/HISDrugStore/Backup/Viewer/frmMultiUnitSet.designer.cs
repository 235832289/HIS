namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmMultiUnitSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiUnitSet));
            this.grUnitDetial = new System.Windows.Forms.GroupBox();
            this.lblProductor = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.ckbCurruseFlag = new System.Windows.Forms.CheckBox();
            this.labMedicineName = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.dtgMultiUnitList = new System.Windows.Forms.DataGridView();
            this.ColumnItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurruseFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grUnitMessage = new System.Windows.Forms.GroupBox();
            this.cmdExit = new PinkieControls.ButtonXP();
            this.cmdDelete = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdSave = new PinkieControls.ButtonXP();
            this.cmdNew = new PinkieControls.ButtonXP();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.labPackage = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.labUnitName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grUnitDetial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMultiUnitList)).BeginInit();
            this.grUnitMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grUnitDetial
            // 
            this.grUnitDetial.Controls.Add(this.lblName);
            this.grUnitDetial.Controls.Add(this.lblProductor);
            this.grUnitDetial.Controls.Add(this.lblSpec);
            this.grUnitDetial.Controls.Add(this.label1);
            this.grUnitDetial.Controls.Add(this.cboStatus);
            this.grUnitDetial.Controls.Add(this.ckbCurruseFlag);
            this.grUnitDetial.Controls.Add(this.labMedicineName);
            this.grUnitDetial.Controls.Add(this.labState);
            this.grUnitDetial.Controls.Add(this.dtgMultiUnitList);
            this.grUnitDetial.Controls.Add(this.grUnitMessage);
            this.grUnitDetial.Controls.Add(this.txtPackage);
            this.grUnitDetial.Controls.Add(this.labPackage);
            this.grUnitDetial.Controls.Add(this.txtUnitName);
            this.grUnitDetial.Controls.Add(this.labUnitName);
            this.grUnitDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grUnitDetial.Location = new System.Drawing.Point(0, 0);
            this.grUnitDetial.Name = "grUnitDetial";
            this.grUnitDetial.Size = new System.Drawing.Size(437, 437);
            this.grUnitDetial.TabIndex = 1;
            this.grUnitDetial.TabStop = false;
            // 
            // lblProductor
            // 
            this.lblProductor.AutoSize = true;
            this.lblProductor.Location = new System.Drawing.Point(9, 81);
            this.lblProductor.Name = "lblProductor";
            this.lblProductor.Size = new System.Drawing.Size(49, 14);
            this.lblProductor.TabIndex = 12;
            this.lblProductor.Text = "厂家：";
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(9, 52);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(49, 14);
            this.lblSpec.TabIndex = 11;
            this.lblSpec.Text = "规格：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "启用标志：";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownHeight = 100;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.IntegralHeight = false;
            this.cboStatus.Items.AddRange(new object[] {
            "停用",
            "启用"});
            this.cboStatus.Location = new System.Drawing.Point(312, 150);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(96, 22);
            this.cboStatus.TabIndex = 9;
            // 
            // ckbCurruseFlag
            // 
            this.ckbCurruseFlag.AutoSize = true;
            this.ckbCurruseFlag.Location = new System.Drawing.Point(186, 154);
            this.ckbCurruseFlag.Name = "ckbCurruseFlag";
            this.ckbCurruseFlag.Size = new System.Drawing.Size(15, 14);
            this.ckbCurruseFlag.TabIndex = 6;
            this.ckbCurruseFlag.UseVisualStyleBackColor = true;
            // 
            // labMedicineName
            // 
            this.labMedicineName.AutoSize = true;
            this.labMedicineName.Location = new System.Drawing.Point(8, 23);
            this.labMedicineName.Name = "labMedicineName";
            this.labMedicineName.Size = new System.Drawing.Size(77, 14);
            this.labMedicineName.TabIndex = 8;
            this.labMedicineName.Text = "药品名称：";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(28, 154);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(147, 14);
            this.labState.TabIndex = 7;
            this.labState.Text = "是否为当前药品单位：";
            // 
            // dtgMultiUnitList
            // 
            this.dtgMultiUnitList.AllowUserToAddRows = false;
            this.dtgMultiUnitList.AllowUserToDeleteRows = false;
            this.dtgMultiUnitList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgMultiUnitList.BackgroundColor = System.Drawing.Color.White;
            this.dtgMultiUnitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgMultiUnitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemID,
            this.ColumnUnitName,
            this.ColumnPackageNum,
            this.ColumnCurruseFlag,
            this.Status});
            this.dtgMultiUnitList.Location = new System.Drawing.Point(3, 254);
            this.dtgMultiUnitList.MultiSelect = false;
            this.dtgMultiUnitList.Name = "dtgMultiUnitList";
            this.dtgMultiUnitList.ReadOnly = true;
            this.dtgMultiUnitList.RowHeadersVisible = false;
            this.dtgMultiUnitList.RowTemplate.Height = 23;
            this.dtgMultiUnitList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMultiUnitList.Size = new System.Drawing.Size(431, 180);
            this.dtgMultiUnitList.TabIndex = 5;
            this.dtgMultiUnitList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgMultiUnitList_KeyDown);
            this.dtgMultiUnitList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMultiUnitList_RowEnter);
            this.dtgMultiUnitList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgMultiUnitList_RowsAdded);
            this.dtgMultiUnitList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgMultiUnitList_CellMouseClick);
            this.dtgMultiUnitList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMultiUnitList_CellContentClick);
            // 
            // ColumnItemID
            // 
            this.ColumnItemID.DataPropertyName = "itemid_chr";
            this.ColumnItemID.HeaderText = "ItemID";
            this.ColumnItemID.Name = "ColumnItemID";
            this.ColumnItemID.ReadOnly = true;
            this.ColumnItemID.Visible = false;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "unit_vchr";
            this.ColumnUnitName.HeaderText = "单位名称";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 120;
            // 
            // ColumnPackageNum
            // 
            this.ColumnPackageNum.DataPropertyName = "package_dec";
            this.ColumnPackageNum.HeaderText = "包装量";
            this.ColumnPackageNum.Name = "ColumnPackageNum";
            this.ColumnPackageNum.ReadOnly = true;
            this.ColumnPackageNum.Width = 88;
            // 
            // ColumnCurruseFlag
            // 
            this.ColumnCurruseFlag.DataPropertyName = "curruseflag_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnCurruseFlag.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnCurruseFlag.HeaderText = "当前单位";
            this.ColumnCurruseFlag.Name = "ColumnCurruseFlag";
            this.ColumnCurruseFlag.ReadOnly = true;
            this.ColumnCurruseFlag.Width = 88;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle2;
            this.Status.HeaderText = "是否启用";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 88;
            // 
            // grUnitMessage
            // 
            this.grUnitMessage.Controls.Add(this.cmdExit);
            this.grUnitMessage.Controls.Add(this.cmdDelete);
            this.grUnitMessage.Controls.Add(this.cmdCancel);
            this.grUnitMessage.Controls.Add(this.cmdSave);
            this.grUnitMessage.Controls.Add(this.cmdNew);
            this.grUnitMessage.Location = new System.Drawing.Point(6, 181);
            this.grUnitMessage.Name = "grUnitMessage";
            this.grUnitMessage.Size = new System.Drawing.Size(423, 67);
            this.grUnitMessage.TabIndex = 4;
            this.grUnitMessage.TabStop = false;
            this.grUnitMessage.Text = "多单位药品维护";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(346, 22);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(70, 33);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "退出(X)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdDelete.DefaultScheme = true;
            this.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdDelete.Hint = "";
            this.cmdDelete.Location = new System.Drawing.Point(261, 22);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdDelete.Size = new System.Drawing.Size(70, 33);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "删除(&D)";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Enabled = false;
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(176, 22);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(70, 33);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "放弃(&C)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSave.DefaultScheme = true;
            this.cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSave.Hint = "";
            this.cmdSave.Location = new System.Drawing.Point(91, 22);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSave.Size = new System.Drawing.Size(70, 33);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "保存(&S)";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdNew.DefaultScheme = true;
            this.cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdNew.Enabled = false;
            this.cmdNew.Hint = "";
            this.cmdNew.Location = new System.Drawing.Point(6, 22);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdNew.Size = new System.Drawing.Size(70, 33);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "新增(&N)";
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(312, 110);
            this.txtPackage.MaxLength = 3;
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(96, 23);
            this.txtPackage.TabIndex = 3;
            this.txtPackage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackage_KeyPress);
            // 
            // labPackage
            // 
            this.labPackage.AutoSize = true;
            this.labPackage.Location = new System.Drawing.Point(243, 114);
            this.labPackage.Name = "labPackage";
            this.labPackage.Size = new System.Drawing.Size(63, 14);
            this.labPackage.TabIndex = 2;
            this.labPackage.Text = "包装量：";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(104, 111);
            this.txtUnitName.MaxLength = 18;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(96, 23);
            this.txtUnitName.TabIndex = 1;
            this.txtUnitName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitName_KeyPress);
            // 
            // labUnitName
            // 
            this.labUnitName.AutoSize = true;
            this.labUnitName.Location = new System.Drawing.Point(29, 113);
            this.labUnitName.Name = "labUnitName";
            this.labUnitName.Size = new System.Drawing.Size(77, 14);
            this.labUnitName.TabIndex = 0;
            this.labUnitName.Text = "单位名称：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 16F);
            this.lblName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblName.Location = new System.Drawing.Point(75, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(351, 22);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "阿莫西林克拉维酸钾分散片$￡&∮◆";
            // 
            // frmMultiUnitSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 437);
            this.Controls.Add(this.grUnitDetial);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMultiUnitSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多单位药品收费项目管理";
            this.Load += new System.EventHandler(this.frmMultiunit_drug_Load);
            this.grUnitDetial.ResumeLayout(false);
            this.grUnitDetial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMultiUnitList)).EndInit();
            this.grUnitMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grUnitDetial;
        internal System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label labUnitName;
        internal System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.Label labPackage;
        private System.Windows.Forms.GroupBox grUnitMessage;
        internal System.Windows.Forms.DataGridView dtgMultiUnitList;
        internal PinkieControls.ButtonXP cmdDelete;
        internal PinkieControls.ButtonXP cmdCancel;
        internal PinkieControls.ButtonXP cmdSave;
        internal PinkieControls.ButtonXP cmdNew;
        internal PinkieControls.ButtonXP cmdExit;
        private System.Windows.Forms.Label labState;
        internal System.Windows.Forms.CheckBox ckbCurruseFlag;
        internal System.Windows.Forms.Label labMedicineName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackageNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurruseFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.Label lblProductor;
        internal System.Windows.Forms.Label lblSpec;
        internal System.Windows.Forms.Label lblName;
    }
}

