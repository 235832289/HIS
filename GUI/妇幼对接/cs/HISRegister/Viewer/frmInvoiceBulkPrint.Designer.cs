namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInvoiceBulkPrint
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHavePrint = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInvoDate_End = new System.Windows.Forms.DateTimePicker();
            this.dtpInvoDate_Start = new System.Windows.Forms.DateTimePicker();
            this.chkInvoDate = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBulkPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvInvoList_NotPrint = new System.Windows.Forms.DataGridView();
            this.colInvoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChargeEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepInvoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInvoCount = new System.Windows.Forms.Label();
            this.lblInvoMoney = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoList_NotPrint)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEmpNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkHavePrint);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpInvoDate_End);
            this.panel1.Controls.Add(this.dtpInvoDate_Start);
            this.panel1.Controls.Add(this.chkInvoDate);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnBulkPrint);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 83);
            this.panel1.TabIndex = 0;
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(609, 31);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(103, 23);
            this.txtEmpNo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "收费员工号:";
            // 
            // chkHavePrint
            // 
            this.chkHavePrint.AutoSize = true;
            this.chkHavePrint.Location = new System.Drawing.Point(20, 32);
            this.chkHavePrint.Name = "chkHavePrint";
            this.chkHavePrint.Size = new System.Drawing.Size(96, 18);
            this.chkHavePrint.TabIndex = 11;
            this.chkHavePrint.Text = "查看已打印";
            this.chkHavePrint.UseVisualStyleBackColor = true;
            this.chkHavePrint.CheckedChanged += new System.EventHandler(this.chkHavePrint_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "～";
            // 
            // dtpInvoDate_End
            // 
            this.dtpInvoDate_End.CalendarFont = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpInvoDate_End.CustomFormat = " yyyy年 MM月 dd日";
            this.dtpInvoDate_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoDate_End.Location = new System.Drawing.Point(379, 30);
            this.dtpInvoDate_End.Name = "dtpInvoDate_End";
            this.dtpInvoDate_End.Size = new System.Drawing.Size(143, 23);
            this.dtpInvoDate_End.TabIndex = 3;
            // 
            // dtpInvoDate_Start
            // 
            this.dtpInvoDate_Start.CalendarFont = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpInvoDate_Start.CustomFormat = " yyyy年 MM月 dd日";
            this.dtpInvoDate_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoDate_Start.Location = new System.Drawing.Point(212, 30);
            this.dtpInvoDate_Start.Name = "dtpInvoDate_Start";
            this.dtpInvoDate_Start.Size = new System.Drawing.Size(141, 23);
            this.dtpInvoDate_Start.TabIndex = 1;
            // 
            // chkInvoDate
            // 
            this.chkInvoDate.AutoSize = true;
            this.chkInvoDate.Checked = true;
            this.chkInvoDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoDate.Location = new System.Drawing.Point(128, 32);
            this.chkInvoDate.Name = "chkInvoDate";
            this.chkInvoDate.Size = new System.Drawing.Size(89, 18);
            this.chkInvoDate.TabIndex = 0;
            this.chkInvoDate.Text = "收费日期:";
            this.chkInvoDate.UseVisualStyleBackColor = true;
            this.chkInvoDate.CheckedChanged += new System.EventHandler(this.chkInvoDate_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(917, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 46);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBulkPrint
            // 
            this.btnBulkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBulkPrint.Location = new System.Drawing.Point(820, 18);
            this.btnBulkPrint.Name = "btnBulkPrint";
            this.btnBulkPrint.Size = new System.Drawing.Size(75, 46);
            this.btnBulkPrint.TabIndex = 9;
            this.btnBulkPrint.Text = "批量打印";
            this.btnBulkPrint.UseVisualStyleBackColor = true;
            this.btnBulkPrint.Click += new System.EventHandler(this.btnBulkPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(731, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 46);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 526);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自助机尚未打印的凭证列表";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvInvoList_NotPrint);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 504);
            this.panel2.TabIndex = 0;
            // 
            // dgvInvoList_NotPrint
            // 
            this.dgvInvoList_NotPrint.AllowUserToAddRows = false;
            this.dgvInvoList_NotPrint.AllowUserToDeleteRows = false;
            this.dgvInvoList_NotPrint.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoList_NotPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInvoList_NotPrint.ColumnHeadersHeight = 30;
            this.dgvInvoList_NotPrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoDate,
            this.colInvoNo,
            this.colChargeEmpName,
            this.colPatientCard,
            this.colPatientName,
            this.colPayTypeName,
            this.colInvoMoney,
            this.colRepInvoNo});
            this.dgvInvoList_NotPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoList_NotPrint.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoList_NotPrint.MultiSelect = false;
            this.dgvInvoList_NotPrint.Name = "dgvInvoList_NotPrint";
            this.dgvInvoList_NotPrint.ReadOnly = true;
            this.dgvInvoList_NotPrint.RowHeadersWidth = 35;
            this.dgvInvoList_NotPrint.RowTemplate.Height = 23;
            this.dgvInvoList_NotPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoList_NotPrint.Size = new System.Drawing.Size(994, 464);
            this.dgvInvoList_NotPrint.TabIndex = 0;
            this.dgvInvoList_NotPrint.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvInvoList_NotPrint_RowPostPaint);
            // 
            // colInvoDate
            // 
            this.colInvoDate.HeaderText = "收费时间";
            this.colInvoDate.Name = "colInvoDate";
            this.colInvoDate.ReadOnly = true;
            this.colInvoDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoDate.Width = 150;
            // 
            // colInvoNo
            // 
            this.colInvoNo.HeaderText = "凭证号码";
            this.colInvoNo.Name = "colInvoNo";
            this.colInvoNo.ReadOnly = true;
            // 
            // colChargeEmpName
            // 
            this.colChargeEmpName.HeaderText = "收费员";
            this.colChargeEmpName.Name = "colChargeEmpName";
            this.colChargeEmpName.ReadOnly = true;
            // 
            // colPatientCard
            // 
            this.colPatientCard.HeaderText = "诊疗卡号";
            this.colPatientCard.Name = "colPatientCard";
            this.colPatientCard.ReadOnly = true;
            this.colPatientCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "病人姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatientName.Width = 120;
            // 
            // colPayTypeName
            // 
            this.colPayTypeName.HeaderText = "病人身份";
            this.colPayTypeName.Name = "colPayTypeName";
            this.colPayTypeName.ReadOnly = true;
            this.colPayTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPayTypeName.Width = 120;
            // 
            // colInvoMoney
            // 
            this.colInvoMoney.HeaderText = "发票金额";
            this.colInvoMoney.Name = "colInvoMoney";
            this.colInvoMoney.ReadOnly = true;
            this.colInvoMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRepInvoNo
            // 
            this.colRepInvoNo.HeaderText = "发票号";
            this.colRepInvoNo.Name = "colRepInvoNo";
            this.colRepInvoNo.ReadOnly = true;
            this.colRepInvoNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRepInvoNo.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblInvoCount);
            this.panel3.Controls.Add(this.lblInvoMoney);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 464);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 36);
            this.panel3.TabIndex = 1;
            // 
            // lblInvoCount
            // 
            this.lblInvoCount.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvoCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInvoCount.Location = new System.Drawing.Point(135, 9);
            this.lblInvoCount.Name = "lblInvoCount";
            this.lblInvoCount.Size = new System.Drawing.Size(191, 19);
            this.lblInvoCount.TabIndex = 1;
            // 
            // lblInvoMoney
            // 
            this.lblInvoMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvoMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInvoMoney.Location = new System.Drawing.Point(462, 9);
            this.lblInvoMoney.Name = "lblInvoMoney";
            this.lblInvoMoney.Size = new System.Drawing.Size(191, 19);
            this.lblInvoMoney.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(371, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "合计金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "合计发票数：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmInvoiceBulkPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 609);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmInvoiceBulkPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自助机发票批量打印";
            this.Shown += new System.EventHandler(this.frmInvoiceBulkPrint_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoList_NotPrint)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBulkPrint;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvInvoList_NotPrint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoCount;
        private System.Windows.Forms.Label lblInvoMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInvoDate_End;
        private System.Windows.Forms.DateTimePicker dtpInvoDate_Start;
        private System.Windows.Forms.CheckBox chkInvoDate;
        private System.Windows.Forms.CheckBox chkHavePrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChargeEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepInvoNo;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label1;
    }
}