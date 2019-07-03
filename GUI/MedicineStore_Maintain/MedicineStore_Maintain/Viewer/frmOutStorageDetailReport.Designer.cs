namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmOutStorageDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutStorageDetailReport));
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtExportDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.m_labExportDept = new System.Windows.Forms.Label();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.m_chkGetIn = new System.Windows.Forms.CheckBox();
            this.m_bgwGetMedicine = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "出库时间";
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(223, 8);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(123, 23);
            this.m_dtpSearchEndDate.TabIndex = 19;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(78, 8);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(124, 23);
            this.m_dtpSearchBeginDate.TabIndex = 18;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "~";
            // 
            // m_txtExportDept
            // 
            this.m_txtExportDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExportDept.Location = new System.Drawing.Point(423, 8);
            this.m_txtExportDept.m_objTag = null;
            this.m_txtExportDept.Name = "m_txtExportDept";
            this.m_txtExportDept.Size = new System.Drawing.Size(144, 23);
            this.m_txtExportDept.TabIndex = 10009;
            this.m_txtExportDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtExportDept.FocusNextControl += new System.EventHandler(this.m_txtExportDept_FocusNextControl);
            // 
            // m_labExportDept
            // 
            this.m_labExportDept.AutoSize = true;
            this.m_labExportDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_labExportDept.Location = new System.Drawing.Point(358, 14);
            this.m_labExportDept.Name = "m_labExportDept";
            this.m_labExportDept.Size = new System.Drawing.Size(63, 14);
            this.m_labExportDept.TabIndex = 10008;
            this.m_labExportDept.Text = "领料单位";
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(612, 8);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(138, 23);
            this.m_txtMedicineCode.TabIndex = 10010;
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(573, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 10011;
            this.label15.Text = "药品";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 023.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 017.ico");
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 1;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(853, 6);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 10012;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 0;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(760, 6);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSearch.TabIndex = 10012;
            this.m_cmdSearch.Text = "查询(&F)";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_chkGetIn
            // 
            this.m_chkGetIn.AutoSize = true;
            this.m_chkGetIn.Location = new System.Drawing.Point(16, 37);
            this.m_chkGetIn.Name = "m_chkGetIn";
            this.m_chkGetIn.Size = new System.Drawing.Size(110, 18);
            this.m_chkGetIn.TabIndex = 10013;
            this.m_chkGetIn.Text = "统计药房内退";
            this.m_chkGetIn.UseVisualStyleBackColor = true;
            // 
            // m_bgwGetMedicine
            // 
            this.m_bgwGetMedicine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetMedicine_DoWork);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_chkGetIn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.panel1.Controls.Add(this.m_cmdSearch);
            this.panel1.Controls.Add(this.m_dtpSearchEndDate);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtMedicineCode);
            this.panel1.Controls.Add(this.m_labExportDept);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.m_txtExportDept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 67);
            this.panel1.TabIndex = 10015;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datWindow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 401);
            this.panel2.TabIndex = 10016;
            // 
            // datWindow
            // 
            this.datWindow.DataWindowObject = "ms_outstoragedetail";
            this.datWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datWindow.LibraryList = "D:\\icare_ver2\\code\\BIN\\Debug\\pb_ms.pbl";
            this.datWindow.Location = new System.Drawing.Point(0, 0);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(955, 401);
            this.datWindow.TabIndex = 10015;
            this.datWindow.Text = "dataWindowControl1";
            // 
            // frmOutStorageDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmOutStorageDetailReport";
            this.Text = "出库明细报表";
            this.Load += new System.EventHandler(this.frmOutStorageDetailReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        private System.Windows.Forms.Label label8;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtExportDept;
        internal System.Windows.Forms.Label m_labExportDept;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdPrint;
        internal System.Windows.Forms.Button m_cmdSearch;
        private System.ComponentModel.BackgroundWorker m_bgwGetMedicine;
        internal System.Windows.Forms.CheckBox m_chkGetIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public Sybase.DataWindow.DataWindowControl datWindow;
    }
}