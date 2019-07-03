namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineGrossProfitRateSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineGrossProfitRateSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.m_cmdReset = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_dgvRateSet = new System.Windows.Forms.DataGridView();
            this.m_dtvtxtMedicineTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvRateSet)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList1;
            this.m_cmdClose.Location = new System.Drawing.Point(265, 379);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 32);
            this.m_cmdClose.TabIndex = 1;
            this.m_cmdClose.Text = "关闭(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdReset
            // 
            this.m_cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdReset.ImageIndex = 5;
            this.m_cmdReset.ImageList = this.imageList1;
            this.m_cmdReset.Location = new System.Drawing.Point(156, 379);
            this.m_cmdReset.Name = "m_cmdReset";
            this.m_cmdReset.Size = new System.Drawing.Size(94, 32);
            this.m_cmdReset.TabIndex = 1;
            this.m_cmdReset.Text = "重置(&R)";
            this.m_cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdReset.UseVisualStyleBackColor = true;
            this.m_cmdReset.Click += new System.EventHandler(this.m_cmdReset_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(46, 379);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 32);
            this.m_cmdSave.TabIndex = 1;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_dgvRateSet
            // 
            this.m_dgvRateSet.AllowUserToAddRows = false;
            this.m_dgvRateSet.AllowUserToDeleteRows = false;
            this.m_dgvRateSet.AllowUserToResizeRows = false;
            this.m_dgvRateSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvRateSet.ColumnHeadersHeight = 40;
            this.m_dgvRateSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dtvtxtMedicineTypeName,
            this.m_dgvtxtRate,
            this.m_dgvtxtMedicineTypeID,
            this.m_dgvtxtStatus});
            this.m_dgvRateSet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvRateSet.Location = new System.Drawing.Point(1, 1);
            this.m_dgvRateSet.Name = "m_dgvRateSet";
            this.m_dgvRateSet.RowHeadersVisible = false;
            this.m_dgvRateSet.RowTemplate.Height = 23;
            this.m_dgvRateSet.Size = new System.Drawing.Size(421, 367);
            this.m_dgvRateSet.TabIndex = 0;
            // 
            // m_dtvtxtMedicineTypeName
            // 
            this.m_dtvtxtMedicineTypeName.DataPropertyName = "Name";
            this.m_dtvtxtMedicineTypeName.HeaderText = "药品类型";
            this.m_dtvtxtMedicineTypeName.Name = "m_dtvtxtMedicineTypeName";
            this.m_dtvtxtMedicineTypeName.ReadOnly = true;
            this.m_dtvtxtMedicineTypeName.Width = 300;
            // 
            // m_dgvtxtRate
            // 
            this.m_dgvtxtRate.DataPropertyName = "Rate";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtRate.HeaderText = "毛利率%";
            this.m_dgvtxtRate.MaxInputLength = 5;
            this.m_dgvtxtRate.Name = "m_dgvtxtRate";
            // 
            // m_dgvtxtMedicineTypeID
            // 
            this.m_dgvtxtMedicineTypeID.DataPropertyName = "ID";
            this.m_dgvtxtMedicineTypeID.HeaderText = "药品类型ID";
            this.m_dgvtxtMedicineTypeID.Name = "m_dgvtxtMedicineTypeID";
            this.m_dgvtxtMedicineTypeID.ReadOnly = true;
            this.m_dgvtxtMedicineTypeID.Visible = false;
            // 
            // m_dgvtxtStatus
            // 
            this.m_dgvtxtStatus.DataPropertyName = "status";
            this.m_dgvtxtStatus.HeaderText = "是否已存在";
            this.m_dgvtxtStatus.Name = "m_dgvtxtStatus";
            this.m_dgvtxtStatus.Visible = false;
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "药品类型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "毛利率";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "药品类型ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // frmMedicineGrossProfitRateSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(424, 417);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdReset);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_dgvRateSet);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedicineGrossProfitRateSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品毛利率设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedicineGrossProfitRateSet_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvRateSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.Button m_cmdReset;
        private System.Windows.Forms.Button m_cmdClose;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvtxtMedicineTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStatus;
        internal System.Windows.Forms.DataGridView m_dgvRateSet;
    }
}