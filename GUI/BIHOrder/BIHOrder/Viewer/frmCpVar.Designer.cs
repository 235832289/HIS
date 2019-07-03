namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmCpVar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCpVar));
            this.lblIpNo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPatName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCpName = new System.Windows.Forms.Label();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.chkEva3 = new System.Windows.Forms.CheckBox();
            this.chkEva2 = new System.Windows.Forms.CheckBox();
            this.chkEva1 = new System.Windows.Forms.CheckBox();
            this.dtpVar = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.clstTarget = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            this.lsvItemPath = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblIpNo
            // 
            this.lblIpNo.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblIpNo.Location = new System.Drawing.Point(484, 78);
            this.lblIpNo.Name = "lblIpNo";
            this.lblIpNo.Size = new System.Drawing.Size(112, 14);
            this.lblIpNo.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label9.Location = new System.Drawing.Point(424, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "住院号：";
            // 
            // lblPatName
            // 
            this.lblPatName.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblPatName.Location = new System.Drawing.Point(332, 78);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(88, 14);
            this.lblPatName.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label7.Location = new System.Drawing.Point(284, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "姓名：";
            // 
            // lblBedNo
            // 
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblBedNo.Location = new System.Drawing.Point(220, 78);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(56, 14);
            this.lblBedNo.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label5.Location = new System.Drawing.Point(172, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "床号：";
            // 
            // lblDeptName
            // 
            this.lblDeptName.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblDeptName.Location = new System.Drawing.Point(60, 78);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(108, 14);
            this.lblDeptName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "科室：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(260, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "变异记录单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(632, 1);
            this.label2.TabIndex = 15;
            // 
            // lblCpName
            // 
            this.lblCpName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCpName.Location = new System.Drawing.Point(28, 8);
            this.lblCpName.Name = "lblCpName";
            this.lblCpName.Size = new System.Drawing.Size(564, 31);
            this.lblCpName.TabIndex = 14;
            this.lblCpName.Text = "临床路径名称";
            this.lblCpName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1});
            this.lvHistory.Font = new System.Drawing.Font("宋体", 10F);
            this.lvHistory.Location = new System.Drawing.Point(8, 108);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(156, 592);
            this.lvHistory.TabIndex = 25;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.SelectedIndexChanged += new System.EventHandler(this.lvHistory_SelectedIndexChanged);
            // 
            // col1
            // 
            this.col1.Text = "变异记录";
            this.col1.Width = 135;
            // 
            // chkEva3
            // 
            this.chkEva3.AutoSize = true;
            this.chkEva3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chkEva3.Location = new System.Drawing.Point(404, 148);
            this.chkEva3.Name = "chkEva3";
            this.chkEva3.Size = new System.Drawing.Size(78, 17);
            this.chkEva3.TabIndex = 31;
            this.chkEva3.Text = "终止路径";
            this.chkEva3.UseVisualStyleBackColor = true;
            this.chkEva3.CheckedChanged += new System.EventHandler(this.chkEva3_CheckedChanged);
            // 
            // chkEva2
            // 
            this.chkEva2.AutoSize = true;
            this.chkEva2.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chkEva2.Location = new System.Drawing.Point(331, 148);
            this.chkEva2.Name = "chkEva2";
            this.chkEva2.Size = new System.Drawing.Size(65, 17);
            this.chkEva2.TabIndex = 30;
            this.chkEva2.Text = "新路径";
            this.chkEva2.UseVisualStyleBackColor = true;
            this.chkEva2.CheckedChanged += new System.EventHandler(this.chkEva2_CheckedChanged);
            // 
            // chkEva1
            // 
            this.chkEva1.AutoSize = true;
            this.chkEva1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chkEva1.Location = new System.Drawing.Point(245, 148);
            this.chkEva1.Name = "chkEva1";
            this.chkEva1.Size = new System.Drawing.Size(78, 17);
            this.chkEva1.TabIndex = 29;
            this.chkEva1.Text = "继续路径";
            this.chkEva1.UseVisualStyleBackColor = true;
            this.chkEva1.CheckedChanged += new System.EventHandler(this.chkEva1_CheckedChanged);
            // 
            // dtpVar
            // 
            this.dtpVar.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpVar.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpVar.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpVar.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpVar.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.dtpVar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVar.Location = new System.Drawing.Point(245, 109);
            this.dtpVar.Name = "dtpVar";
            this.dtpVar.Size = new System.Drawing.Size(372, 22);
            this.dtpVar.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label13.Location = new System.Drawing.Point(172, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "变异类型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label11.Location = new System.Drawing.Point(172, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "变异时间：";
            // 
            // txtPathName
            // 
            this.txtPathName.Font = new System.Drawing.Font("宋体", 9.5F);
            this.txtPathName.Location = new System.Drawing.Point(245, 181);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.Size = new System.Drawing.Size(372, 22);
            this.txtPathName.TabIndex = 33;
            this.txtPathName.DoubleClick += new System.EventHandler(this.txtPathName_DoubleClick);
            this.txtPathName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPathName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label4.Location = new System.Drawing.Point(172, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "新 路 径：";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(245, 221);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(372, 295);
            this.txtResult.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label14.Location = new System.Drawing.Point(172, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "变异原因：";
            // 
            // clstTarget
            // 
            this.clstTarget.Font = new System.Drawing.Font("宋体", 9.5F);
            this.clstTarget.FormattingEnabled = true;
            this.clstTarget.Items.AddRange(new object[] {
            "符合诊断依据",
            "同时具有其他疾病，但不影响第一诊断临床路径流程实施",
            "没有并发症"});
            this.clstTarget.Location = new System.Drawing.Point(245, 524);
            this.clstTarget.Name = "clstTarget";
            this.clstTarget.Size = new System.Drawing.Size(372, 174);
            this.clstTarget.TabIndex = 36;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(334, 721);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(109, 28);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnOK.Hint = "";
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(189, 721);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(109, 28);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = " 保存(&S)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.lsvItemPath.Location = new System.Drawing.Point(0, 716);
            this.lsvItemPath.MultiSelect = false;
            this.lsvItemPath.Name = "lsvItemPath";
            this.lsvItemPath.Size = new System.Drawing.Size(652, 51);
            this.lsvItemPath.TabIndex = 39;
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
            this.columnHeader4.Width = 470;
            // 
            // frmCpVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 767);
            this.Controls.Add(this.lsvItemPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clstTarget);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPathName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkEva3);
            this.Controls.Add(this.chkEva2);
            this.Controls.Add(this.chkEva1);
            this.Controls.Add(this.dtpVar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.lblIpNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPatName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBedNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCpName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCpVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "路径变异";
            this.Load += new System.EventHandler(this.frmCpVar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIpNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCpName;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.CheckBox chkEva3;
        private System.Windows.Forms.CheckBox chkEva2;
        private System.Windows.Forms.CheckBox chkEva1;
        private System.Windows.Forms.DateTimePicker dtpVar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPathName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckedListBox clstTarget;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOK;
        internal System.Windows.Forms.ListView lsvItemPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}