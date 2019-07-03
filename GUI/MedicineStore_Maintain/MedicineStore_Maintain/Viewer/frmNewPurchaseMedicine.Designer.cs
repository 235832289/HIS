namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmNewPurchaseMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewPurchaseMedicine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboDoseType = new System.Windows.Forms.ComboBox();
            this.m_txtProviderName = new System.Windows.Forms.TextBox();
            this.m_txtBillNumber = new System.Windows.Forms.TextBox();
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dgvNewMedicine = new System.Windows.Forms.DataGridView();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNewMedicine)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdQuery
            // 
            this.cmdQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuery.Image")));
            this.cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuery.Location = new System.Drawing.Point(3, 12);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(87, 32);
            this.cmdQuery.TabIndex = 16;
            this.cmdQuery.Text = "查询(&A)";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(912, 12);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(87, 32);
            this.cmdExit.TabIndex = 18;
            this.cmdExit.TabStop = false;
            this.cmdExit.Text = "退出(&Q)";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(90, 12);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(87, 32);
            this.cmdPrint.TabIndex = 17;
            this.cmdPrint.TabStop = false;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cboDoseType);
            this.panel1.Controls.Add(this.m_txtProviderName);
            this.panel1.Controls.Add(this.m_txtBillNumber);
            this.panel1.Controls.Add(this.m_txtMedicineName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtpSearchEndDate);
            this.panel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 65);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "购买时间";
            // 
            // m_cboDoseType
            // 
            this.m_cboDoseType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDoseType.FormattingEnabled = true;
            this.m_cboDoseType.Location = new System.Drawing.Point(753, 5);
            this.m_cboDoseType.Name = "m_cboDoseType";
            this.m_cboDoseType.Size = new System.Drawing.Size(92, 22);
            this.m_cboDoseType.TabIndex = 40;
            // 
            // m_txtProviderName
            // 
            this.m_txtProviderName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProviderName.Location = new System.Drawing.Point(423, 5);
            this.m_txtProviderName.Name = "m_txtProviderName";
            this.m_txtProviderName.Size = new System.Drawing.Size(255, 23);
            this.m_txtProviderName.TabIndex = 20;
            this.m_txtProviderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtProviderName_KeyDown);
            // 
            // m_txtBillNumber
            // 
            this.m_txtBillNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBillNumber.Location = new System.Drawing.Point(423, 32);
            this.m_txtBillNumber.Name = "m_txtBillNumber";
            this.m_txtBillNumber.Size = new System.Drawing.Size(255, 23);
            this.m_txtBillNumber.TabIndex = 45;
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineName.Location = new System.Drawing.Point(67, 32);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.Size = new System.Drawing.Size(283, 23);
            this.m_txtMedicineName.TabIndex = 35;
            this.m_txtMedicineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "供应商名";
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(220, 5);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpSearchEndDate.TabIndex = 15;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(67, 5);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(128, 23);
            this.m_dtpSearchBeginDate.TabIndex = 10;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "药品名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "入库单号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(684, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "药品类型";
            // 
            // m_dgvNewMedicine
            // 
            this.m_dgvNewMedicine.AllowUserToAddRows = false;
            this.m_dgvNewMedicine.AllowUserToDeleteRows = false;
            this.m_dgvNewMedicine.AllowUserToResizeRows = false;
            this.m_dgvNewMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvNewMedicine.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dgvNewMedicine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvNewMedicine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvNewMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvNewMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvNewMedicine.Location = new System.Drawing.Point(3, 121);
            this.m_dgvNewMedicine.MultiSelect = false;
            this.m_dgvNewMedicine.Name = "m_dgvNewMedicine";
            this.m_dgvNewMedicine.ReadOnly = true;
            this.m_dgvNewMedicine.RowHeadersVisible = false;
            this.m_dgvNewMedicine.RowTemplate.Height = 23;
            this.m_dgvNewMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvNewMedicine.Size = new System.Drawing.Size(1024, 630);
            this.m_dgvNewMedicine.StandardTab = true;
            this.m_dgvNewMedicine.TabIndex = 20;
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // frmNewPurchaseMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 753);
            this.Controls.Add(this.m_dgvNewMedicine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdPrint);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewPurchaseMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新药通知单查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNewPurchaseMedicine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNewMedicine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdPrint;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox m_cboDoseType;
        internal System.Windows.Forms.TextBox m_txtProviderName;
        internal System.Windows.Forms.TextBox m_txtBillNumber;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.DataGridView m_dgvNewMedicine;

    }
}