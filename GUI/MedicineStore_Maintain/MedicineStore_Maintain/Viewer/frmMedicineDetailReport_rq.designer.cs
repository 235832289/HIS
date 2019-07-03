namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineDetailReport_rq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineDetailReport_rq));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetItem = new System.ComponentModel.BackgroundWorker();
            this.m_bgwGetIDList = new System.ComponentModel.BackgroundWorker();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.p_cmbToExcel = new System.Windows.Forms.Button();
            this.m_cboMedicineType = new System.Windows.Forms.ComboBox();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtMedicine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 017.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 023.ico");
            // 
            // m_bgwGetItem
            // 
            this.m_bgwGetItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetItem_DoWork);
            this.m_bgwGetItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetItem_RunWorkerCompleted);
            
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList2.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList2.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList2.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList2.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList2.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList2.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList2.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList2.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // p_cmbToExcel
            // 
            this.p_cmbToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p_cmbToExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_cmbToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.p_cmbToExcel.ImageIndex = 3;
            this.p_cmbToExcel.ImageList = this.imageList2;
            this.p_cmbToExcel.Location = new System.Drawing.Point(915, 5);
            this.p_cmbToExcel.Name = "p_cmbToExcel";
            this.p_cmbToExcel.Size = new System.Drawing.Size(94, 28);
            this.p_cmbToExcel.TabIndex = 195;
            this.p_cmbToExcel.Text = "导出(&D)";
            this.p_cmbToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.p_cmbToExcel.UseVisualStyleBackColor = false;
            this.p_cmbToExcel.Click += new System.EventHandler(this.p_cmbToExcel_Click);
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.FormattingEnabled = true;
            this.m_cboMedicineType.Location = new System.Drawing.Point(641, 8);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(85, 22);
            this.m_cboMedicineType.TabIndex = 192;
            this.m_cboMedicineType.SelectedIndexChanged += new System.EventHandler(this.m_cboMedicineType_SelectedIndexChanged);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 1;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(729, 5);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSearch.TabIndex = 191;
            this.m_cmdSearch.Text = "查询(&F)";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 0;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(822, 5);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 191;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "类型:";
            // 
            // m_txtMedicine
            // 
            this.m_txtMedicine.Location = new System.Drawing.Point(460, 8);
            this.m_txtMedicine.Name = "m_txtMedicine";
            this.m_txtMedicine.Size = new System.Drawing.Size(138, 23);
            this.m_txtMedicine.TabIndex = 5;
            this.m_txtMedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicine_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "药品:";
            // 
            // datWindow
            // 
            this.datWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datWindow.DataWindowObject = "ms_account_detail2";
            this.datWindow.LibraryList = "";
            this.datWindow.Location = new System.Drawing.Point(5, 39);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(1017, 591);
            this.datWindow.TabIndex = 193;
            this.datWindow.Text = "dataWindowControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(205, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 199;
            this.label1.Text = "~";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(27, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 198;
            this.label4.Text = "日期:";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(219, 7);
            this.m_dtpEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDate.Mask = "0000年90月90日";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpEndDate.TabIndex = 197;
            this.m_dtpEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(75, 7);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDate.Mask = "0000年90月90日";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpBeginDate.TabIndex = 196;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // frmMedicineDetailReport_rq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_dtpEndDate);
            this.Controls.Add(this.m_dtpBeginDate);
            this.Controls.Add(this.p_cmbToExcel);
            this.Controls.Add(this.m_cboMedicineType);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtMedicine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datWindow);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineDetailReport_rq";
            this.Text = "药品明细帐表";
            this.Load += new System.EventHandler(this.frmMedicineDetailReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.TextBox m_txtMedicine;
        internal System.Windows.Forms.ComboBox m_cboMedicineType;
        private System.ComponentModel.BackgroundWorker m_bgwGetItem;
        internal System.Windows.Forms.Button m_cmdSearch;
        private System.ComponentModel.BackgroundWorker m_bgwGetIDList;
        public Sybase.DataWindow.DataWindowControl datWindow;
        internal System.Windows.Forms.Button p_cmbToExcel;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpBeginDate;
    }
}