namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmCpIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCpIn));
            this.lblPatName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.clstDiagRef = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpCp = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMainDiag = new System.Windows.Forms.TextBox();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.txtZyzx = new System.Windows.Forms.TextBox();
            this.lsvItemICD = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lsvItemPath = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lsvItemSyn = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPatName.Location = new System.Drawing.Point(252, 22);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(72, 19);
            this.lblPatName.TabIndex = 1;
            this.lblPatName.Text = "张三娃";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 1);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "主要诊断：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label4.Location = new System.Drawing.Point(16, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "标准路径：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label5.Location = new System.Drawing.Point(16, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "中医症型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label6.Location = new System.Drawing.Point(16, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "诊断依据：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label7.Location = new System.Drawing.Point(16, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "入径描述：";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 9.5F);
            this.txtRemark.Location = new System.Drawing.Point(88, 332);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(372, 176);
            this.txtRemark.TabIndex = 6;
            // 
            // clstDiagRef
            // 
            this.clstDiagRef.Font = new System.Drawing.Font("宋体", 9.5F);
            this.clstDiagRef.FormattingEnabled = true;
            this.clstDiagRef.Items.AddRange(new object[] {
            "符合诊断依据",
            "同时具有其他疾病，但不影响第一诊断临床路径流程实施",
            "没有并发症"});
            this.clstDiagRef.Location = new System.Drawing.Point(88, 248);
            this.clstDiagRef.Name = "clstDiagRef";
            this.clstDiagRef.Size = new System.Drawing.Size(372, 72);
            this.clstDiagRef.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(272, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(109, 28);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnOK.Hint = "";
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(127, 520);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(109, 28);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "进入路径(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dtpCp
            // 
            this.dtpCp.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpCp.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpCp.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpCp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCp.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.dtpCp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCp.Location = new System.Drawing.Point(88, 105);
            this.dtpCp.Name = "dtpCp";
            this.dtpCp.Size = new System.Drawing.Size(372, 22);
            this.dtpCp.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label11.Location = new System.Drawing.Point(16, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "入径时间：";
            // 
            // txtMainDiag
            // 
            this.txtMainDiag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMainDiag.Font = new System.Drawing.Font("宋体", 9.5F);
            this.txtMainDiag.Location = new System.Drawing.Point(88, 140);
            this.txtMainDiag.Name = "txtMainDiag";
            this.txtMainDiag.Size = new System.Drawing.Size(372, 22);
            this.txtMainDiag.TabIndex = 2;
            this.txtMainDiag.DoubleClick += new System.EventHandler(this.txtMainDiag_DoubleClick);
            this.txtMainDiag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainDiag_KeyDown);
            // 
            // txtPathName
            // 
            this.txtPathName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPathName.Font = new System.Drawing.Font("宋体", 9.5F);
            this.txtPathName.Location = new System.Drawing.Point(88, 176);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.Size = new System.Drawing.Size(372, 22);
            this.txtPathName.TabIndex = 3;
            this.txtPathName.DoubleClick += new System.EventHandler(this.txtPathName_DoubleClick);
            this.txtPathName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPathName_KeyDown);
            // 
            // txtZyzx
            // 
            this.txtZyzx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZyzx.Font = new System.Drawing.Font("宋体", 9.5F);
            this.txtZyzx.Location = new System.Drawing.Point(88, 212);
            this.txtZyzx.Name = "txtZyzx";
            this.txtZyzx.Size = new System.Drawing.Size(372, 22);
            this.txtZyzx.TabIndex = 4;
            this.txtZyzx.DoubleClick += new System.EventHandler(this.txtZyzx_DoubleClick);
            this.txtZyzx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtZyzx_KeyDown);
            // 
            // lsvItemICD
            // 
            this.lsvItemICD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvItemICD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lsvItemICD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvItemICD.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lsvItemICD.FullRowSelect = true;
            this.lsvItemICD.GridLines = true;
            this.lsvItemICD.Location = new System.Drawing.Point(0, 516);
            this.lsvItemICD.MultiSelect = false;
            this.lsvItemICD.Name = "lsvItemICD";
            this.lsvItemICD.Size = new System.Drawing.Size(487, 46);
            this.lsvItemICD.TabIndex = 30;
            this.lsvItemICD.UseCompatibleStateImageBehavior = false;
            this.lsvItemICD.View = System.Windows.Forms.View.Details;
            this.lsvItemICD.DoubleClick += new System.EventHandler(this.lsvItemICD_DoubleClick);
            this.lsvItemICD.Leave += new System.EventHandler(this.lsvItemICD_Leave);
            this.lsvItemICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvItemICD_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ICD10代码";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ICD10名称";
            this.columnHeader3.Width = 310;
            // 
            // lsvItemPath
            // 
            this.lsvItemPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvItemPath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4});
            this.lsvItemPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvItemPath.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lsvItemPath.FullRowSelect = true;
            this.lsvItemPath.GridLines = true;
            this.lsvItemPath.Location = new System.Drawing.Point(0, 470);
            this.lsvItemPath.MultiSelect = false;
            this.lsvItemPath.Name = "lsvItemPath";
            this.lsvItemPath.Size = new System.Drawing.Size(487, 46);
            this.lsvItemPath.TabIndex = 31;
            this.lsvItemPath.UseCompatibleStateImageBehavior = false;
            this.lsvItemPath.View = System.Windows.Forms.View.Details;
            this.lsvItemPath.DoubleClick += new System.EventHandler(this.lsvItemPath_DoubleClick);
            this.lsvItemPath.Leave += new System.EventHandler(this.lsvItemPath_Leave);
            this.lsvItemPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvItemPath_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "路径代码";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "路径名称";
            this.columnHeader4.Width = 310;
            // 
            // lsvItemSyn
            // 
            this.lsvItemSyn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvItemSyn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lsvItemSyn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvItemSyn.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lsvItemSyn.FullRowSelect = true;
            this.lsvItemSyn.GridLines = true;
            this.lsvItemSyn.Location = new System.Drawing.Point(0, 424);
            this.lsvItemSyn.MultiSelect = false;
            this.lsvItemSyn.Name = "lsvItemSyn";
            this.lsvItemSyn.Size = new System.Drawing.Size(487, 46);
            this.lsvItemSyn.TabIndex = 32;
            this.lsvItemSyn.UseCompatibleStateImageBehavior = false;
            this.lsvItemSyn.View = System.Windows.Forms.View.Details;
            this.lsvItemSyn.DoubleClick += new System.EventHandler(this.lsvItemSyn_DoubleClick);
            this.lsvItemSyn.Leave += new System.EventHandler(this.lsvItemSyn_Leave);
            this.lsvItemSyn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvItemSyn_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "症型名称";
            this.columnHeader5.Width = 450;
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Checked = true;
            this.rdoYes.Location = new System.Drawing.Point(243, 76);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(47, 16);
            this.rdoYes.TabIndex = 33;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "符合";
            this.rdoYes.UseVisualStyleBackColor = true;
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Location = new System.Drawing.Point(304, 76);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(59, 16);
            this.rdoNo.TabIndex = 34;
            this.rdoNo.Text = "不符合";
            this.rdoNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label1.Location = new System.Drawing.Point(16, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "当前患者的诊断是否临床路径标准：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnSave.Hint = "";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(380, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCpIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 562);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoNo);
            this.Controls.Add(this.rdoYes);
            this.Controls.Add(this.lsvItemSyn);
            this.Controls.Add(this.lsvItemPath);
            this.Controls.Add(this.lsvItemICD);
            this.Controls.Add(this.txtZyzx);
            this.Controls.Add(this.txtPathName);
            this.Controls.Add(this.txtMainDiag);
            this.Controls.Add(this.dtpCp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clstDiagRef);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPatName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCpIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入径评估";
            this.Load += new System.EventHandler(this.frmCpIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.CheckedListBox clstDiagRef;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOK;
        private System.Windows.Forms.DateTimePicker dtpCp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMainDiag;
        private System.Windows.Forms.TextBox txtPathName;
        private System.Windows.Forms.TextBox txtZyzx;
        internal System.Windows.Forms.ListView lsvItemICD;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        internal System.Windows.Forms.ListView lsvItemPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.ListView lsvItemSyn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP btnSave;
    }
}