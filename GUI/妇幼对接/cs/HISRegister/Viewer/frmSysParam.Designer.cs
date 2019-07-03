namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmSysParam
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_chkShowDeleted = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdCancelDelete = new PinkieControls.ButtonXP();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtNote = new System.Windows.Forms.TextBox();
            this.m_txtParamValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtParamDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtPramCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboSysModule = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lsvSysParams = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.m_gpbWorkGroup = new System.Windows.Forms.GroupBox();
            this.m_txtWGSummary = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtWGName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_gpbWorkGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_chkShowDeleted);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(992, 125);
            this.panel5.TabIndex = 5;
            // 
            // m_chkShowDeleted
            // 
            this.m_chkShowDeleted.AutoSize = true;
            this.m_chkShowDeleted.Location = new System.Drawing.Point(598, 92);
            this.m_chkShowDeleted.Name = "m_chkShowDeleted";
            this.m_chkShowDeleted.Size = new System.Drawing.Size(110, 18);
            this.m_chkShowDeleted.TabIndex = 0;
            this.m_chkShowDeleted.Text = "显示已删除项";
            this.m_chkShowDeleted.UseVisualStyleBackColor = true;
            this.m_chkShowDeleted.CheckedChanged += new System.EventHandler(this.m_chkShowDeleted_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdDelete);
            this.groupBox1.Controls.Add(this.m_cmdNew);
            this.groupBox1.Controls.Add(this.m_cmdClose);
            this.groupBox1.Controls.Add(this.m_cmdSave);
            this.groupBox1.Controls.Add(this.m_cmdCancelDelete);
            this.groupBox1.Location = new System.Drawing.Point(731, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 126);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(142, 22);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(97, 40);
            this.m_cmdDelete.TabIndex = 4;
            this.m_cmdDelete.Text = "删除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(25, 22);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(97, 40);
            this.m_cmdNew.TabIndex = 2;
            this.m_cmdNew.Text = "新增";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(142, 73);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(97, 40);
            this.m_cmdClose.TabIndex = 12;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.buttonXP5_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(25, 73);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(97, 40);
            this.m_cmdSave.TabIndex = 3;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdCancelDelete
            // 
            this.m_cmdCancelDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancelDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancelDelete.DefaultScheme = true;
            this.m_cmdCancelDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancelDelete.Hint = "";
            this.m_cmdCancelDelete.Location = new System.Drawing.Point(77, 22);
            this.m_cmdCancelDelete.Name = "m_cmdCancelDelete";
            this.m_cmdCancelDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancelDelete.Size = new System.Drawing.Size(97, 40);
            this.m_cmdCancelDelete.TabIndex = 1;
            this.m_cmdCancelDelete.Text = "取消删除";
            this.m_cmdCancelDelete.Visible = false;
            this.m_cmdCancelDelete.Click += new System.EventHandler(this.m_cmdCancelDelete_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "描  述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "参数代码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "系统模块";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtNote);
            this.panel1.Controls.Add(this.m_txtParamValue);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.m_txtParamDesc);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.m_txtPramCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.m_cboSysModule);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 124);
            this.panel1.TabIndex = 6;
            // 
            // m_txtNote
            // 
            this.m_txtNote.Location = new System.Drawing.Point(82, 89);
            this.m_txtNote.Name = "m_txtNote";
            this.m_txtNote.Size = new System.Drawing.Size(490, 23);
            this.m_txtNote.TabIndex = 10;
            // 
            // m_txtParamValue
            // 
            this.m_txtParamValue.Location = new System.Drawing.Point(82, 63);
            this.m_txtParamValue.Name = "m_txtParamValue";
            this.m_txtParamValue.Size = new System.Drawing.Size(630, 23);
            this.m_txtParamValue.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "参数值";
            // 
            // m_txtParamDesc
            // 
            this.m_txtParamDesc.Location = new System.Drawing.Point(82, 38);
            this.m_txtParamDesc.Name = "m_txtParamDesc";
            this.m_txtParamDesc.Size = new System.Drawing.Size(630, 23);
            this.m_txtParamDesc.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "参数描述";
            // 
            // m_txtPramCode
            // 
            this.m_txtPramCode.Location = new System.Drawing.Point(308, 13);
            this.m_txtPramCode.Name = "m_txtPramCode";
            this.m_txtPramCode.Size = new System.Drawing.Size(404, 23);
            this.m_txtPramCode.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "参数代码";
            // 
            // m_cboSysModule
            // 
            this.m_cboSysModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSysModule.FormattingEnabled = true;
            this.m_cboSysModule.Items.AddRange(new object[] {
            "公用 ",
            "门诊 ",
            "住院 ",
            "图文工作站",
            "影像"});
            this.m_cboSysModule.Location = new System.Drawing.Point(83, 13);
            this.m_cboSysModule.Name = "m_cboSysModule";
            this.m_cboSysModule.Size = new System.Drawing.Size(137, 22);
            this.m_cboSysModule.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "系统模块";
            // 
            // m_lsvSysParams
            // 
            this.m_lsvSysParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.m_lsvSysParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvSysParams.FullRowSelect = true;
            this.m_lsvSysParams.GridLines = true;
            this.m_lsvSysParams.HideSelection = false;
            this.m_lsvSysParams.Location = new System.Drawing.Point(0, 125);
            this.m_lsvSysParams.MultiSelect = false;
            this.m_lsvSysParams.Name = "m_lsvSysParams";
            this.m_lsvSysParams.Size = new System.Drawing.Size(992, 479);
            this.m_lsvSysParams.TabIndex = 8;
            this.m_lsvSysParams.UseCompatibleStateImageBehavior = false;
            this.m_lsvSysParams.View = System.Windows.Forms.View.Details;
            this.m_lsvSysParams.SelectedIndexChanged += new System.EventHandler(this.m_lsvSysParams_Click);
            this.m_lsvSysParams.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvSysParams_ColumnClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "系统模块";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "参数代码";
            this.columnHeader5.Width = 161;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "参数描述";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "参数值";
            this.columnHeader2.Width = 153;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "备注";
            this.columnHeader6.Width = 410;
            // 
            // m_gpbWorkGroup
            // 
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWGSummary);
            this.m_gpbWorkGroup.Controls.Add(this.label2);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWGName);
            this.m_gpbWorkGroup.Controls.Add(this.label1);
            this.m_gpbWorkGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gpbWorkGroup.Location = new System.Drawing.Point(0, 125);
            this.m_gpbWorkGroup.Name = "m_gpbWorkGroup";
            this.m_gpbWorkGroup.Size = new System.Drawing.Size(992, 479);
            this.m_gpbWorkGroup.TabIndex = 6;
            this.m_gpbWorkGroup.TabStop = false;
            // 
            // m_txtWGSummary
            // 
            this.m_txtWGSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWGSummary.Location = new System.Drawing.Point(119, 57);
            this.m_txtWGSummary.MaxLength = 100;
            this.m_txtWGSummary.Name = "m_txtWGSummary";
            this.m_txtWGSummary.Size = new System.Drawing.Size(363, 23);
            this.m_txtWGSummary.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "备注";
            // 
            // m_txtWGName
            // 
            this.m_txtWGName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWGName.Location = new System.Drawing.Point(119, 29);
            this.m_txtWGName.MaxLength = 25;
            this.m_txtWGName.Name = "m_txtWGName";
            this.m_txtWGName.Size = new System.Drawing.Size(363, 23);
            this.m_txtWGName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作组名称";
            // 
            // frmSysParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 604);
            this.Controls.Add(this.m_lsvSysParams);
            this.Controls.Add(this.m_gpbWorkGroup);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmSysParam";
            this.Text = "系统参数表";
            this.Load += new System.EventHandler(this.frmSysParam_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_gpbWorkGroup.ResumeLayout(false);
            this.m_gpbWorkGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox m_chkShowDeleted;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdNew;
        private PinkieControls.ButtonXP m_cmdCancelDelete;
        private PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.ListView m_lsvSysParams;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox m_gpbWorkGroup;
        private System.Windows.Forms.TextBox m_txtWGSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtWGName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox m_txtPramCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_cboSysModule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox m_txtParamValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox m_txtParamDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txtNote;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}