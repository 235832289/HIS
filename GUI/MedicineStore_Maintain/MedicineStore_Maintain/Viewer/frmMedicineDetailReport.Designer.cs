namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineDetailReport));
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
            this.m_lblAccountDate = new System.Windows.Forms.Label();
            this.m_cmdShowAccount = new System.Windows.Forms.Button();
            this.m_txtAccountID = new System.Windows.Forms.TextBox();
            this.m_lsvAccountIDList = new System.Windows.Forms.ListView();
            this.m_clmID = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
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
            // m_bgwGetIDList
            // 
            this.m_bgwGetIDList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetIDList_DoWork);
            this.m_bgwGetIDList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetIDList_RunWorkerCompleted);
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
            // m_lblAccountDate
            // 
            this.m_lblAccountDate.Location = new System.Drawing.Point(194, 11);
            this.m_lblAccountDate.Name = "m_lblAccountDate";
            this.m_lblAccountDate.Size = new System.Drawing.Size(231, 18);
            this.m_lblAccountDate.TabIndex = 3;
            this.m_lblAccountDate.Text = "时间:";
            this.m_lblAccountDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmdShowAccount
            // 
            this.m_cmdShowAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowAccount.Location = new System.Drawing.Point(164, 7);
            this.m_cmdShowAccount.Name = "m_cmdShowAccount";
            this.m_cmdShowAccount.Size = new System.Drawing.Size(21, 23);
            this.m_cmdShowAccount.TabIndex = 2;
            this.m_cmdShowAccount.Text = "↓";
            this.m_cmdShowAccount.UseVisualStyleBackColor = true;
            this.m_cmdShowAccount.Click += new System.EventHandler(this.m_cmdShowAccount_Click);
            // 
            // m_txtAccountID
            // 
            this.m_txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtAccountID.Location = new System.Drawing.Point(65, 7);
            this.m_txtAccountID.Name = "m_txtAccountID";
            this.m_txtAccountID.Size = new System.Drawing.Size(100, 23);
            this.m_txtAccountID.TabIndex = 1;
            // 
            // m_lsvAccountIDList
            // 
            this.m_lsvAccountIDList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvAccountIDList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmID});
            this.m_lsvAccountIDList.GridLines = true;
            this.m_lsvAccountIDList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAccountIDList.HideSelection = false;
            this.m_lsvAccountIDList.Location = new System.Drawing.Point(65, 32);
            this.m_lsvAccountIDList.Name = "m_lsvAccountIDList";
            this.m_lsvAccountIDList.Size = new System.Drawing.Size(305, 97);
            this.m_lsvAccountIDList.TabIndex = 5;
            this.m_lsvAccountIDList.UseCompatibleStateImageBehavior = false;
            this.m_lsvAccountIDList.View = System.Windows.Forms.View.Details;
            this.m_lsvAccountIDList.Visible = false;
            this.m_lsvAccountIDList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_lsvAccountIDList_MouseClick);
            this.m_lsvAccountIDList.Leave += new System.EventHandler(this.m_lsvAccountIDList_Leave);
            // 
            // m_clmID
            // 
            this.m_clmID.Width = 280;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐务期：";
            // 
            // datWindow
            // 
            this.datWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datWindow.DataWindowObject = "ms_account_detail";
            this.datWindow.LibraryList = "";
            this.datWindow.Location = new System.Drawing.Point(5, 39);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(1017, 591);
            this.datWindow.TabIndex = 193;
            this.datWindow.Text = "dataWindowControl1";
            this.datWindow.Click += new System.EventHandler(this.datWindow_Click);
            // 
            // frmMedicineDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 634);
            this.Controls.Add(this.p_cmbToExcel);
            this.Controls.Add(this.m_cboMedicineType);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtMedicine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_lblAccountDate);
            this.Controls.Add(this.m_cmdShowAccount);
            this.Controls.Add(this.m_txtAccountID);
            this.Controls.Add(this.m_lsvAccountIDList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datWindow);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineDetailReport";
            this.Text = "药品明细帐表";
            this.Load += new System.EventHandler(this.frmMedicineDetailReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtAccountID;
        private System.Windows.Forms.Button m_cmdShowAccount;
        private System.Windows.Forms.Label m_lblAccountDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.TextBox m_txtMedicine;
        internal System.Windows.Forms.ComboBox m_cboMedicineType;
        private System.ComponentModel.BackgroundWorker m_bgwGetItem;
        internal System.Windows.Forms.Button m_cmdSearch;
        internal System.Windows.Forms.ListView m_lsvAccountIDList;
        private System.Windows.Forms.ColumnHeader m_clmID;
        private System.ComponentModel.BackgroundWorker m_bgwGetIDList;
        public Sybase.DataWindow.DataWindowControl datWindow;
        internal System.Windows.Forms.Button p_cmbToExcel;
        private System.Windows.Forms.ImageList imageList2;
    }
}