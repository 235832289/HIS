namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmGenerateAsk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateAsk));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_cboStorage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMedSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnGenerate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_cbkFilter = new System.Windows.Forms.CheckBox();
            this.m_datEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_datBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_cbLimit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAbateBeginDate = new System.Windows.Forms.Label();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.lblAbateEndDate = new System.Windows.Forms.Label();
            this.m_lblSelected = new System.Windows.Forms.Label();
            this.m_dgvDrugStorage = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_cboStorage,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.tsbMedSend,
            this.toolStripSeparator3,
            this.m_btnQuery,
            this.toolStripSeparator6,
            this.m_btnGenerate,
            this.toolStripSeparator2,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1170, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 45);
            this.toolStripLabel1.Text = "药房";
            this.toolStripLabel1.Visible = false;
            // 
            // m_cboStorage
            // 
            this.m_cboStorage.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.m_cboStorage.Name = "m_cboStorage";
            this.m_cboStorage.Size = new System.Drawing.Size(121, 48);
            this.m_cboStorage.Visible = false;
            this.m_cboStorage.SelectedIndexChanged += new System.EventHandler(this.m_cboStorage_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(686, 45);
            this.toolStripLabel2.Text = "                                                                                 " +
                "                ";
            this.toolStripLabel2.ToolTipText = "                                              ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbMedSend
            // 
            this.tsbMedSend.Image = ((System.Drawing.Image)(resources.GetObject("tsbMedSend.Image")));
            this.tsbMedSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMedSend.Name = "tsbMedSend";
            this.tsbMedSend.Size = new System.Drawing.Size(83, 45);
            this.tsbMedSend.Text = "发药汇总";
            this.tsbMedSend.Click += new System.EventHandler(this.tsbMedSend_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
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
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 48);
            // 
            // m_btnGenerate
            // 
            this.m_btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("m_btnGenerate.Image")));
            this.m_btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnGenerate.Name = "m_btnGenerate";
            this.m_btnGenerate.Size = new System.Drawing.Size(76, 45);
            this.m_btnGenerate.Text = "生成(&N)";
            this.m_btnGenerate.Click += new System.EventHandler(this.m_btnGenerate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
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
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_cbkFilter);
            this.gradientPanel1.Controls.Add(this.m_datEndDate);
            this.gradientPanel1.Controls.Add(this.m_datBeginDate);
            this.gradientPanel1.Controls.Add(this.m_cbLimit);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.lblAbateBeginDate);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.lblAbateEndDate);
            this.gradientPanel1.Flip = true;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gradientPanel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(6, -1);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(689, 48);
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_cbkFilter
            // 
            this.m_cbkFilter.AutoSize = true;
            this.m_cbkFilter.BackColor = System.Drawing.Color.Transparent;
            this.m_cbkFilter.Checked = true;
            this.m_cbkFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_cbkFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cbkFilter.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cbkFilter.Location = new System.Drawing.Point(574, 25);
            this.m_cbkFilter.Name = "m_cbkFilter";
            this.m_cbkFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_cbkFilter.Size = new System.Drawing.Size(107, 18);
            this.m_cbkFilter.TabIndex = 29;
            this.m_cbkFilter.Text = "消耗大于库存";
            this.m_cbkFilter.UseVisualStyleBackColor = false;
            // 
            // m_datEndDate
            // 
            this.m_datEndDate.Font = new System.Drawing.Font("宋体", 9F);
            this.m_datEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_datEndDate.Location = new System.Drawing.Point(253, 13);
            this.m_datEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HH时mm分;
            this.m_datEndDate.Mask = "0000年90月90日 90:90:90";
            this.m_datEndDate.Name = "m_datEndDate";
            this.m_datEndDate.Size = new System.Drawing.Size(165, 21);
            this.m_datEndDate.TabIndex = 28;
            this.m_datEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_datBeginDate
            // 
            this.m_datBeginDate.Font = new System.Drawing.Font("宋体", 9F);
            this.m_datBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_datBeginDate.Location = new System.Drawing.Point(67, 13);
            this.m_datBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HH时mm分;
            this.m_datBeginDate.Mask = "0000年90月90日 90时90分";
            this.m_datBeginDate.Name = "m_datBeginDate";
            this.m_datBeginDate.Size = new System.Drawing.Size(165, 21);
            this.m_datBeginDate.TabIndex = 27;
            this.m_datBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_cbLimit
            // 
            this.m_cbLimit.AutoSize = true;
            this.m_cbLimit.BackColor = System.Drawing.Color.Transparent;
            this.m_cbLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cbLimit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cbLimit.Location = new System.Drawing.Point(588, 5);
            this.m_cbLimit.Name = "m_cbLimit";
            this.m_cbLimit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_cbLimit.Size = new System.Drawing.Size(93, 18);
            this.m_cbLimit.TabIndex = 3;
            this.m_cbLimit.Text = "限量起作用";
            this.m_cbLimit.UseVisualStyleBackColor = false;
            this.m_cbLimit.CheckedChanged += new System.EventHandler(this.m_cbLimit_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(418, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "分类";
            // 
            // lblAbateBeginDate
            // 
            this.lblAbateBeginDate.AutoSize = true;
            this.lblAbateBeginDate.BackColor = System.Drawing.Color.Transparent;
            this.lblAbateBeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateBeginDate.Location = new System.Drawing.Point(4, 16);
            this.lblAbateBeginDate.Name = "lblAbateBeginDate";
            this.lblAbateBeginDate.Size = new System.Drawing.Size(63, 14);
            this.lblAbateBeginDate.TabIndex = 25;
            this.lblAbateBeginDate.Text = "消耗日期";
            // 
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtTypecode.Location = new System.Drawing.Point(453, 12);
            this.txtTypecode.m_blnFocuseShow = true;
            this.txtTypecode.m_blnPagination = false;
            this.txtTypecode.m_dtbDataSourse = null;
            this.txtTypecode.m_intDelayTime = 100;
            this.txtTypecode.m_intPageRows = 10;
            this.txtTypecode.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtTypecode.m_listViewSize = new System.Drawing.Point(163, 150);
            this.txtTypecode.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtTypecode.m_strSaveField = "medicinetypeid_chr";
            this.txtTypecode.m_strShowField = "medicinetypename_vchr";
            this.txtTypecode.m_strSQL = null;
            this.txtTypecode.Name = "txtTypecode";
            this.txtTypecode.Size = new System.Drawing.Size(113, 23);
            this.txtTypecode.TabIndex = 2;
            // 
            // lblAbateEndDate
            // 
            this.lblAbateEndDate.AutoSize = true;
            this.lblAbateEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblAbateEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateEndDate.Location = new System.Drawing.Point(232, 16);
            this.lblAbateEndDate.Name = "lblAbateEndDate";
            this.lblAbateEndDate.Size = new System.Drawing.Size(21, 14);
            this.lblAbateEndDate.TabIndex = 26;
            this.lblAbateEndDate.Text = "至";
            // 
            // m_lblSelected
            // 
            this.m_lblSelected.BackColor = System.Drawing.Color.Transparent;
            this.m_lblSelected.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.m_lblSelected.Location = new System.Drawing.Point(1, 49);
            this.m_lblSelected.Name = "m_lblSelected";
            this.m_lblSelected.Size = new System.Drawing.Size(20, 30);
            this.m_lblSelected.TabIndex = 2;
            this.m_lblSelected.Tag = "False";
            this.m_lblSelected.Text = "全选";
            this.m_lblSelected.MouseLeave += new System.EventHandler(this.m_lblSelected_MouseLeave);
            this.m_lblSelected.Click += new System.EventHandler(this.m_lblSelected_Click);
            this.m_lblSelected.MouseEnter += new System.EventHandler(this.m_lblSelected_MouseEnter);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDrugStorage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDrugStorage.ColumnHeadersHeight = 34;
            this.m_dgvDrugStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDrugStorage.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvDrugStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrugStorage.Location = new System.Drawing.Point(0, 48);
            this.m_dgvDrugStorage.MultiSelect = false;
            this.m_dgvDrugStorage.Name = "m_dgvDrugStorage";
            this.m_dgvDrugStorage.RowHeadersVisible = false;
            this.m_dgvDrugStorage.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDrugStorage.RowTemplate.Height = 23;
            this.m_dgvDrugStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrugStorage.Size = new System.Drawing.Size(1170, 424);
            this.m_dgvDrugStorage.StandardTab = true;
            this.m_dgvDrugStorage.TabIndex = 11;
            this.m_dgvDrugStorage.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDrugStorage_RowsAdded);
            this.m_dgvDrugStorage.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellEndEdit);
            this.m_dgvDrugStorage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDrugStorage_DataError);
            this.m_dgvDrugStorage.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellEnter);
            // 
            // frmGenerateAsk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 472);
            this.Controls.Add(this.m_lblSelected);
            this.Controls.Add(this.m_dgvDrugStorage);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerateAsk";
            this.Text = "生成请领单";
            this.Load += new System.EventHandler(this.frmGenerateAsk_Load);
            this.Shown += new System.EventHandler(this.frmGenerateAsk_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton m_btnGenerate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal GradientPanel gradientPanel1;
        private System.Windows.Forms.Label lblAbateEndDate;
        private System.Windows.Forms.Label lblAbateBeginDate;
        internal System.Windows.Forms.Label m_lblSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripComboBox m_cboStorage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
        internal ControlLibrary.txtListView1 txtTypecode;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView m_dgvDrugStorage;
        internal System.Windows.Forms.CheckBox m_cbLimit;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_datEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_datBeginDate;
        internal System.Windows.Forms.CheckBox m_cbkFilter;
        internal System.Windows.Forms.ToolStripButton tsbMedSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}