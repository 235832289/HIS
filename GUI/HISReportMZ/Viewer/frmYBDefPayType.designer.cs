namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBDefPayType
    {    /// <summary>
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtTypeId = new System.Windows.Forms.TextBox();
            this.m_cboYBRylxName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboYBJslxName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboTypeName = new System.Windows.Forms.ComboBox();
            this.m_lsvYBPayTypes = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
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
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(992, 128);
            this.panel5.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdDelete);
            this.groupBox1.Controls.Add(this.m_cmdNew);
            this.groupBox1.Controls.Add(this.m_cmdClose);
            this.groupBox1.Controls.Add(this.m_cmdSave);
            this.groupBox1.Location = new System.Drawing.Point(731, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 126);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
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
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
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
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(142, 73);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(97, 40);
            this.m_cmdClose.TabIndex = 12;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_txtTypeId);
            this.panel1.Controls.Add(this.m_cboYBRylxName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.m_cboYBJslxName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_cboTypeName);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 125);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "身份名称";
            // 
            // m_txtTypeId
            // 
            this.m_txtTypeId.Location = new System.Drawing.Point(160, 31);
            this.m_txtTypeId.Name = "m_txtTypeId";
            this.m_txtTypeId.Size = new System.Drawing.Size(137, 26);
            this.m_txtTypeId.TabIndex = 11;
            // 
            // m_cboYBRylxName
            // 
            this.m_cboYBRylxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboYBRylxName.FormattingEnabled = true;
            this.m_cboYBRylxName.Items.AddRange(new object[] {
            "在职",
            "退休",
            "离休"});
            this.m_cboYBRylxName.Location = new System.Drawing.Point(473, 69);
            this.m_cboYBRylxName.Name = "m_cboYBRylxName";
            this.m_cboYBRylxName.Size = new System.Drawing.Size(137, 24);
            this.m_cboYBRylxName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "医保人员类别";
            // 
            // m_cboYBJslxName
            // 
            this.m_cboYBJslxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboYBJslxName.FormattingEnabled = true;
            this.m_cboYBJslxName.Items.AddRange(new object[] {
            "普通住院",
            "离休普通住院",
            "离休住院8折",
            "离休住院危急抢救",
            "离休住院危急非抢救"});
            this.m_cboYBJslxName.Location = new System.Drawing.Point(160, 69);
            this.m_cboYBJslxName.Name = "m_cboYBJslxName";
            this.m_cboYBJslxName.Size = new System.Drawing.Size(137, 24);
            this.m_cboYBJslxName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "医保结算类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "身份编号";
            // 
            // m_cboTypeName
            // 
            this.m_cboTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboTypeName.FormattingEnabled = true;
            this.m_cboTypeName.Items.AddRange(new object[] {
            "公用 ",
            "门诊 ",
            "住院 ",
            "图文工作站",
            "影像"});
            this.m_cboTypeName.Location = new System.Drawing.Point(473, 32);
            this.m_cboTypeName.Name = "m_cboTypeName";
            this.m_cboTypeName.Size = new System.Drawing.Size(137, 24);
            this.m_cboTypeName.TabIndex = 1;
            this.m_cboTypeName.SelectedIndexChanged += new System.EventHandler(this.m_cboTypeName_SelectedIndexChanged);
            // 
            // m_lsvYBPayTypes
            // 
            this.m_lsvYBPayTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvYBPayTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvYBPayTypes.FullRowSelect = true;
            this.m_lsvYBPayTypes.GridLines = true;
            this.m_lsvYBPayTypes.HideSelection = false;
            this.m_lsvYBPayTypes.Location = new System.Drawing.Point(0, 128);
            this.m_lsvYBPayTypes.MultiSelect = false;
            this.m_lsvYBPayTypes.Name = "m_lsvYBPayTypes";
            this.m_lsvYBPayTypes.Size = new System.Drawing.Size(992, 476);
            this.m_lsvYBPayTypes.TabIndex = 8;
            this.m_lsvYBPayTypes.UseCompatibleStateImageBehavior = false;
            this.m_lsvYBPayTypes.View = System.Windows.Forms.View.Details;
            this.m_lsvYBPayTypes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvYBPayTypes_ColumnClick);
            this.m_lsvYBPayTypes.Click += new System.EventHandler(this.m_lsvYBPayTypes_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "身份编号";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "身份名称";
            this.columnHeader5.Width = 161;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "医保结算类型";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "医保人员类别";
            this.columnHeader2.Width = 153;
            // 
            // m_gpbWorkGroup
            // 
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWGSummary);
            this.m_gpbWorkGroup.Controls.Add(this.label2);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWGName);
            this.m_gpbWorkGroup.Controls.Add(this.label1);
            this.m_gpbWorkGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gpbWorkGroup.Location = new System.Drawing.Point(0, 128);
            this.m_gpbWorkGroup.Name = "m_gpbWorkGroup";
            this.m_gpbWorkGroup.Size = new System.Drawing.Size(992, 476);
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
            // frmYBDefPayType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 604);
            this.Controls.Add(this.m_lsvYBPayTypes);
            this.Controls.Add(this.m_gpbWorkGroup);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmYBDefPayType";
            this.Text = "住院-医保身份对应关系维护";
            this.Load += new System.EventHandler(this.frmYBDefPayType_Load);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_gpbWorkGroup.ResumeLayout(false);
            this.m_gpbWorkGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdNew;
        private PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.ListView m_lsvYBPayTypes;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox m_gpbWorkGroup;
        private System.Windows.Forms.TextBox m_txtWGSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtWGName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox m_cboTypeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox m_cboYBJslxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtTypeId;
        private System.Windows.Forms.ComboBox m_cboYBRylxName;
        private System.Windows.Forms.Label label5;

    }
}