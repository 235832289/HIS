namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmStatSampleBcak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPatType = new System.Windows.Forms.ComboBox();
            this.cboSampleType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dteRq1 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.dteRq2 = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new PinkieControls.ButtonXP();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cboPatType);
            this.panel3.Controls.Add(this.cboSampleType);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dteRq1);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSelect);
            this.panel3.Controls.Add(this.dteRq2);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1315, 68);
            this.panel3.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(272, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 172;
            this.label8.Text = "病人类型：";
            // 
            // cboPatType
            // 
            this.cboPatType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPatType.FormattingEnabled = true;
            this.cboPatType.Items.AddRange(new object[] {
            ""});
            this.cboPatType.Location = new System.Drawing.Point(352, 36);
            this.cboPatType.Name = "cboPatType";
            this.cboPatType.Size = new System.Drawing.Size(144, 22);
            this.cboPatType.TabIndex = 173;
            // 
            // cboSampleType
            // 
            this.cboSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSampleType.FormattingEnabled = true;
            this.cboSampleType.Location = new System.Drawing.Point(352, 8);
            this.cboSampleType.Name = "cboSampleType";
            this.cboSampleType.Size = new System.Drawing.Size(144, 22);
            this.cboSampleType.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "统计日期：从";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(272, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "检验类型:";
            // 
            // dteRq1
            // 
            this.dteRq1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq1.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq1.Location = new System.Drawing.Point(105, 7);
            this.dteRq1.Name = "dteRq1";
            this.dteRq1.Size = new System.Drawing.Size(155, 24);
            this.dteRq1.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(768, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(76, 32);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(80, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "到";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(524, 16);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(76, 32);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "检索(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dteRq2
            // 
            this.dteRq2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq2.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq2.Location = new System.Drawing.Point(108, 36);
            this.dteRq2.Name = "dteRq2";
            this.dteRq2.Size = new System.Drawing.Size(152, 24);
            this.dteRq2.TabIndex = 15;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(668, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(76, 32);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvData);
            this.panel4.Controls.Add(this.dwRep);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1315, 485);
            this.panel4.TabIndex = 15;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1315, 485);
            this.dgvData.TabIndex = 13;
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(1315, 485);
            this.dwRep.TabIndex = 15;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // frmStatSampleBcak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 553);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "frmStatSampleBcak";
            this.Text = "东莞茶山医院标本质量统计分析表";
            this.Load += new System.EventHandler(this.frmStatSampleBcak_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboSampleType;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP btnSelect;
        internal PinkieControls.ButtonXP btnExport;
        internal System.Windows.Forms.DateTimePicker dteRq2;
        private System.Windows.Forms.Label label4;
        internal PinkieControls.ButtonXP btnClose;
        internal System.Windows.Forms.DateTimePicker dteRq1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvData;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cboPatType;
    }
}