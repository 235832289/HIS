namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmStorageSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStorageSet));
            this.m_dgvDrugStorage = new System.Windows.Forms.DataGridView();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_rbtLack = new System.Windows.Forms.RadioButton();
            this.m_rbtStop = new System.Windows.Forms.RadioButton();
            this.m_rbtNormal = new System.Windows.Forms.RadioButton();
            this.m_rbtAll = new System.Windows.Forms.RadioButton();
            this.m_cboStorage = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboMedicineType = new System.Windows.Forms.ComboBox();
            this.lblJx = new System.Windows.Forms.Label();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.lblStorage = new System.Windows.Forms.Label();
            this.lblLeechdom = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnLocate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvDrugStorage
            // 
            this.m_dgvDrugStorage.AllowUserToAddRows = false;
            this.m_dgvDrugStorage.AllowUserToDeleteRows = false;
            this.m_dgvDrugStorage.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
            this.m_dgvDrugStorage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDrugStorage.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dgvDrugStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvDrugStorage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvDrugStorage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDrugStorage.ColumnHeadersHeight = 40;
            this.m_dgvDrugStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDrugStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrugStorage.Location = new System.Drawing.Point(0, 73);
            this.m_dgvDrugStorage.MultiSelect = false;
            this.m_dgvDrugStorage.Name = "m_dgvDrugStorage";
            this.m_dgvDrugStorage.RowHeadersVisible = false;
            this.m_dgvDrugStorage.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDrugStorage.RowTemplate.Height = 23;
            this.m_dgvDrugStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrugStorage.Size = new System.Drawing.Size(1016, 680);
            this.m_dgvDrugStorage.StandardTab = true;
            this.m_dgvDrugStorage.TabIndex = 9;
            this.m_dgvDrugStorage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellClick);
            this.m_dgvDrugStorage.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_RowEnter);
            this.m_dgvDrugStorage.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDrugStorage_RowsAdded);
            this.m_dgvDrugStorage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.m_dgvDrugStorage_CellFormatting);
            this.m_dgvDrugStorage.Sorted += new System.EventHandler(this.m_dgvDrugStorage_Sorted);
            this.m_dgvDrugStorage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellValueChanged);
            this.m_dgvDrugStorage.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvDrugStorage_CellMouseDoubleClick);
            this.m_dgvDrugStorage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDrugStorage_DataError);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_rbtLack);
            this.gradientPanel1.Controls.Add(this.m_rbtStop);
            this.gradientPanel1.Controls.Add(this.m_rbtNormal);
            this.gradientPanel1.Controls.Add(this.m_rbtAll);
            this.gradientPanel1.Controls.Add(this.m_cboStorage);
            this.gradientPanel1.Controls.Add(this.m_cboMedicineType);
            this.gradientPanel1.Controls.Add(this.lblJx);
            this.gradientPanel1.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel1.Controls.Add(this.lblStorage);
            this.gradientPanel1.Controls.Add(this.lblLeechdom);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = true;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1016, 35);
            this.gradientPanel1.TabIndex = 3;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_rbtLack
            // 
            this.m_rbtLack.AutoSize = true;
            this.m_rbtLack.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtLack.Location = new System.Drawing.Point(931, 7);
            this.m_rbtLack.Name = "m_rbtLack";
            this.m_rbtLack.Size = new System.Drawing.Size(53, 18);
            this.m_rbtLack.TabIndex = 28;
            this.m_rbtLack.Text = "缺药";
            this.m_rbtLack.UseVisualStyleBackColor = false;
            this.m_rbtLack.CheckedChanged += new System.EventHandler(this.m_rbtAll_CheckedChanged);
            // 
            // m_rbtStop
            // 
            this.m_rbtStop.AutoSize = true;
            this.m_rbtStop.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtStop.Location = new System.Drawing.Point(854, 7);
            this.m_rbtStop.Name = "m_rbtStop";
            this.m_rbtStop.Size = new System.Drawing.Size(53, 18);
            this.m_rbtStop.TabIndex = 28;
            this.m_rbtStop.Text = "停用";
            this.m_rbtStop.UseVisualStyleBackColor = false;
            this.m_rbtStop.CheckedChanged += new System.EventHandler(this.m_rbtAll_CheckedChanged);
            // 
            // m_rbtNormal
            // 
            this.m_rbtNormal.AutoSize = true;
            this.m_rbtNormal.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtNormal.Location = new System.Drawing.Point(777, 7);
            this.m_rbtNormal.Name = "m_rbtNormal";
            this.m_rbtNormal.Size = new System.Drawing.Size(53, 18);
            this.m_rbtNormal.TabIndex = 28;
            this.m_rbtNormal.Text = "正常";
            this.m_rbtNormal.UseVisualStyleBackColor = false;
            this.m_rbtNormal.CheckedChanged += new System.EventHandler(this.m_rbtAll_CheckedChanged);
            // 
            // m_rbtAll
            // 
            this.m_rbtAll.AutoSize = true;
            this.m_rbtAll.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtAll.Checked = true;
            this.m_rbtAll.Location = new System.Drawing.Point(700, 7);
            this.m_rbtAll.Name = "m_rbtAll";
            this.m_rbtAll.Size = new System.Drawing.Size(53, 18);
            this.m_rbtAll.TabIndex = 28;
            this.m_rbtAll.TabStop = true;
            this.m_rbtAll.Text = "全部";
            this.m_rbtAll.UseVisualStyleBackColor = false;
            this.m_rbtAll.CheckedChanged += new System.EventHandler(this.m_rbtAll_CheckedChanged);
            // 
            // m_cboStorage
            // 
            this.m_cboStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboStorage.FormattingEnabled = true;
            this.m_cboStorage.Location = new System.Drawing.Point(49, 6);
            this.m_cboStorage.Name = "m_cboStorage";
            this.m_cboStorage.Size = new System.Drawing.Size(119, 22);
            this.m_cboStorage.TabIndex = 0;
            this.m_cboStorage.SelectedIndexChanged += new System.EventHandler(this.m_cboStorage_SelectedIndexChanged);
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboMedicineType.FormattingEnabled = true;
            this.m_cboMedicineType.Location = new System.Drawing.Point(545, 5);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(121, 22);
            this.m_cboMedicineType.TabIndex = 4;
            // 
            // lblJx
            // 
            this.lblJx.AutoSize = true;
            this.lblJx.BackColor = System.Drawing.Color.Transparent;
            this.lblJx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJx.Location = new System.Drawing.Point(482, 9);
            this.lblJx.Name = "lblJx";
            this.lblJx.Size = new System.Drawing.Size(63, 14);
            this.lblJx.TabIndex = 27;
            this.lblJx.Text = "药品类型";
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(203, 6);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(279, 23);
            this.m_txtMedicineCode.TabIndex = 3;
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.BackColor = System.Drawing.Color.Transparent;
            this.lblStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStorage.Location = new System.Drawing.Point(14, 9);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(35, 14);
            this.lblStorage.TabIndex = 21;
            this.lblStorage.Text = "药房";
            // 
            // lblLeechdom
            // 
            this.lblLeechdom.AutoSize = true;
            this.lblLeechdom.BackColor = System.Drawing.Color.Transparent;
            this.lblLeechdom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeechdom.Location = new System.Drawing.Point(168, 9);
            this.lblLeechdom.Name = "lblLeechdom";
            this.lblLeechdom.Size = new System.Drawing.Size(35, 14);
            this.lblLeechdom.TabIndex = 23;
            this.lblLeechdom.Text = "药品";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnQuery,
            this.toolStripSeparator6,
            this.m_btnLocate,
            this.toolStripSeparator3,
            this.m_btnSave,
            this.toolStripSeparator2,
            this.m_btnPrint,
            this.toolStripSeparator8,
            this.m_btnExport,
            this.toolStripSeparator1,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(80, 33);
            this.m_btnQuery.Text = "查询(&F)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnLocate
            // 
            this.m_btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLocate.Image")));
            this.m_btnLocate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnLocate.Name = "m_btnLocate";
            this.m_btnLocate.Size = new System.Drawing.Size(76, 35);
            this.m_btnLocate.Text = "定位(&L)";
            this.m_btnLocate.Click += new System.EventHandler(this.m_btnLocate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(76, 35);
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.AutoSize = false;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrint.Image")));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(80, 32);
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExport
            // 
            this.m_btnExport.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExport.Image")));
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(76, 35);
            this.m_btnExport.Text = "导出(&O)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(80, 33);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // frmStorageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 753);
            this.Controls.Add(this.m_dgvDrugStorage);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStorageSet";
            this.Text = "药房停缺标志维护设置";
            this.Load += new System.EventHandler(this.frmStorageSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton m_btnExport;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private System.Windows.Forms.Label lblJx;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label lblLeechdom;
        internal exComboBox m_cboStorage;
        internal System.Windows.Forms.ComboBox m_cboMedicineType;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal GradientPanel gradientPanel1;
        internal System.Windows.Forms.DataGridView m_dgvDrugStorage;
        private System.Windows.Forms.ToolStripButton m_btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_btnLocate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.RadioButton m_rbtLack;
        internal System.Windows.Forms.RadioButton m_rbtStop;
        internal System.Windows.Forms.RadioButton m_rbtNormal;
        internal System.Windows.Forms.RadioButton m_rbtAll;
    }
}