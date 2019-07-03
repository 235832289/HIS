namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmOutStorageStat_WestemMedicineStorage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Sybase.DataWindow.Transaction transactionSQLCA;//用来设置连接信息

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutStorageStat_WestemMedicineStorage));
            this.cmdStat = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdPrint = new System.Windows.Forms.Button();
            this.transactionSQLCA = new Sybase.DataWindow.Transaction(this.components);
            this.dwOutStorageStat = new Sybase.DataWindow.DataWindowControl();
            this.m_txtAskDeptPage1 = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.txtOutStorageEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.txtOutStorageBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.chkPharmacyMedicineCancel = new System.Windows.Forms.CheckBox();
            this.lblAbateEndDate = new System.Windows.Forms.Label();
            this.lblAbateBeginDate = new System.Windows.Forms.Label();
            this.lblStorage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdStat
            // 
            this.cmdStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStat.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStat.ImageIndex = 9;
            this.cmdStat.ImageList = this.imageList1;
            this.cmdStat.Location = new System.Drawing.Point(820, 12);
            this.cmdStat.Name = "cmdStat";
            this.cmdStat.Size = new System.Drawing.Size(94, 32);
            this.cmdStat.TabIndex = 0;
            this.cmdStat.Text = "查询(&A)";
            this.cmdStat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStat.UseVisualStyleBackColor = true;
            this.cmdStat.Click += new System.EventHandler(this.cmdStat_Click);
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
            this.imageList1.Images.SetKeyName(9, "Shell32 023.ico");
            // 
            // cmdPrint
            // 
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.ImageIndex = 6;
            this.cmdPrint.ImageList = this.imageList1;
            this.cmdPrint.Location = new System.Drawing.Point(920, 12);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(94, 32);
            this.cmdPrint.TabIndex = 1;
            this.cmdPrint.TabStop = false;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // dwOutStorageStat
            // 
            this.dwOutStorageStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dwOutStorageStat.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.FixedSingle;
            this.dwOutStorageStat.DataWindowObject = "ms_outstoragedetail";
            this.dwOutStorageStat.LibraryList = "";
            this.dwOutStorageStat.Location = new System.Drawing.Point(10, 84);
            this.dwOutStorageStat.Name = "dwOutStorageStat";
            this.dwOutStorageStat.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwOutStorageStat.Size = new System.Drawing.Size(1006, 607);
            this.dwOutStorageStat.TabIndex = 7;
            this.dwOutStorageStat.Text = "dwOutStorageStat";
            // 
            // m_txtAskDeptPage1
            // 
            this.m_txtAskDeptPage1.Location = new System.Drawing.Point(463, 21);
            this.m_txtAskDeptPage1.m_objTag = null;
            this.m_txtAskDeptPage1.Name = "m_txtAskDeptPage1";
            this.m_txtAskDeptPage1.Size = new System.Drawing.Size(182, 23);
            this.m_txtAskDeptPage1.TabIndex = 38;
            this.m_txtAskDeptPage1.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPreview.Location = new System.Drawing.Point(919, 55);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(82, 18);
            this.chkPreview.TabIndex = 40;
            this.chkPreview.Text = "报表预览";
            this.chkPreview.UseVisualStyleBackColor = true;
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // txtOutStorageEndDate
            // 
            this.txtOutStorageEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOutStorageEndDate.Location = new System.Drawing.Point(246, 21);
            this.txtOutStorageEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.txtOutStorageEndDate.Mask = "0000年90月90日";
            this.txtOutStorageEndDate.Name = "txtOutStorageEndDate";
            this.txtOutStorageEndDate.Size = new System.Drawing.Size(135, 23);
            this.txtOutStorageEndDate.TabIndex = 37;
            this.txtOutStorageEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // txtOutStorageBeginDate
            // 
            this.txtOutStorageBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOutStorageBeginDate.Location = new System.Drawing.Point(75, 21);
            this.txtOutStorageBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.txtOutStorageBeginDate.Mask = "0000年90月90日";
            this.txtOutStorageBeginDate.Name = "txtOutStorageBeginDate";
            this.txtOutStorageBeginDate.Size = new System.Drawing.Size(141, 23);
            this.txtOutStorageBeginDate.TabIndex = 36;
            this.txtOutStorageBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // chkPharmacyMedicineCancel
            // 
            this.chkPharmacyMedicineCancel.AutoSize = true;
            this.chkPharmacyMedicineCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPharmacyMedicineCancel.Location = new System.Drawing.Point(13, 55);
            this.chkPharmacyMedicineCancel.Name = "chkPharmacyMedicineCancel";
            this.chkPharmacyMedicineCancel.Size = new System.Drawing.Size(110, 18);
            this.chkPharmacyMedicineCancel.TabIndex = 39;
            this.chkPharmacyMedicineCancel.Text = "统计药房内退";
            this.chkPharmacyMedicineCancel.UseVisualStyleBackColor = true;
            // 
            // lblAbateEndDate
            // 
            this.lblAbateEndDate.AutoSize = true;
            this.lblAbateEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateEndDate.Location = new System.Drawing.Point(224, 32);
            this.lblAbateEndDate.Name = "lblAbateEndDate";
            this.lblAbateEndDate.Size = new System.Drawing.Size(14, 14);
            this.lblAbateEndDate.TabIndex = 43;
            this.lblAbateEndDate.Text = "~";
            // 
            // lblAbateBeginDate
            // 
            this.lblAbateBeginDate.AutoSize = true;
            this.lblAbateBeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateBeginDate.Location = new System.Drawing.Point(7, 26);
            this.lblAbateBeginDate.Name = "lblAbateBeginDate";
            this.lblAbateBeginDate.Size = new System.Drawing.Size(63, 14);
            this.lblAbateBeginDate.TabIndex = 42;
            this.lblAbateBeginDate.Text = "出库日期";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStorage.Location = new System.Drawing.Point(396, 24);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(63, 14);
            this.lblStorage.TabIndex = 41;
            this.lblStorage.Text = "领料单位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 180;
            this.label4.Text = "类型";
            // 
            // m_cboType
            // 
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(693, 21);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(121, 22);
            this.m_cboType.TabIndex = 179;
            // 
            // frmOutStorageStat_WestemMedicineStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 703);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cboType);
            this.Controls.Add(this.m_txtAskDeptPage1);
            this.Controls.Add(this.chkPreview);
            this.Controls.Add(this.txtOutStorageEndDate);
            this.Controls.Add(this.txtOutStorageBeginDate);
            this.Controls.Add(this.chkPharmacyMedicineCancel);
            this.Controls.Add(this.lblAbateEndDate);
            this.Controls.Add(this.lblAbateBeginDate);
            this.Controls.Add(this.lblStorage);
            this.Controls.Add(this.cmdStat);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.dwOutStorageStat);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutStorageStat_WestemMedicineStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出库统计报表（西药库）";
            this.Load += new System.EventHandler(this.frmOutStorageStat_WestemMedicineStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStat;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.ImageList imageList1;
        private Sybase.DataWindow.DataWindowControl dwOutStorageStat;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtAskDeptPage1;
        private System.Windows.Forms.CheckBox chkPreview;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker txtOutStorageEndDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker txtOutStorageBeginDate;
        private System.Windows.Forms.CheckBox chkPharmacyMedicineCancel;
        private System.Windows.Forms.Label lblAbateEndDate;
        private System.Windows.Forms.Label lblAbateBeginDate;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
    }
}