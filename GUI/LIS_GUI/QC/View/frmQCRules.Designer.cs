namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCRules
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cboTypeFlag = new System.Windows.Forms.ComboBox();
            this.m_chkDefaultFlag = new System.Windows.Forms.CheckBox();
            this.m_txtFormula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtSummary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtRuleDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtRuleAliasName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtRuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lsvRules = new System.Windows.Forms.ListView();
            this.m_chRuleName = new System.Windows.Forms.ColumnHeader();
            this.m_chRuleAlias = new System.Windows.Forms.ColumnHeader();
            this.m_chRuleDesc = new System.Windows.Forms.ColumnHeader();
            this.m_chRuleFormula = new System.Windows.Forms.ColumnHeader();
            this.m_chsummary = new System.Windows.Forms.ColumnHeader();
            this.m_chDefaultFlag = new System.Windows.Forms.ColumnHeader();
            this.m_chTypeFlag = new System.Windows.Forms.ColumnHeader();
            this.m_btnDelete = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_cboTypeFlag);
            this.groupBox1.Controls.Add(this.m_chkDefaultFlag);
            this.groupBox1.Controls.Add(this.m_txtFormula);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txtSummary);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtRuleDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtRuleAliasName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtRuleName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "规则类型:";
            // 
            // m_cboTypeFlag
            // 
            this.m_cboTypeFlag.AutoCompleteCustomSource.AddRange(new string[] {
            "失控",
            "警告"});
            this.m_cboTypeFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboTypeFlag.FormattingEnabled = true;
            this.m_cboTypeFlag.Items.AddRange(new object[] {
            "失控",
            "警告"});
            this.m_cboTypeFlag.Location = new System.Drawing.Point(320, 250);
            this.m_cboTypeFlag.Name = "m_cboTypeFlag";
            this.m_cboTypeFlag.Size = new System.Drawing.Size(60, 22);
            this.m_cboTypeFlag.TabIndex = 9;
            // 
            // m_chkDefaultFlag
            // 
            this.m_chkDefaultFlag.AutoSize = true;
            this.m_chkDefaultFlag.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_chkDefaultFlag.Location = new System.Drawing.Point(89, 254);
            this.m_chkDefaultFlag.Name = "m_chkDefaultFlag";
            this.m_chkDefaultFlag.Size = new System.Drawing.Size(138, 18);
            this.m_chkDefaultFlag.TabIndex = 6;
            this.m_chkDefaultFlag.Text = "是否是默认组成员";
            this.m_chkDefaultFlag.UseVisualStyleBackColor = true;
            // 
            // m_txtFormula
            // 
            this.m_txtFormula.AcceptsReturn = true;
            this.m_txtFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormula.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtFormula.Location = new System.Drawing.Point(89, 68);
            this.m_txtFormula.MaxLength = 250;
            this.m_txtFormula.Multiline = true;
            this.m_txtFormula.Name = "m_txtFormula";
            this.m_txtFormula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtFormula.Size = new System.Drawing.Size(685, 152);
            this.m_txtFormula.TabIndex = 4;
            this.m_txtFormula.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(19, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "备   注:";
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSummary.Location = new System.Drawing.Point(89, 222);
            this.m_txtSummary.MaxLength = 250;
            this.m_txtSummary.Name = "m_txtSummary";
            this.m_txtSummary.Size = new System.Drawing.Size(685, 23);
            this.m_txtSummary.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "规则公式:";
            // 
            // m_txtRuleDesc
            // 
            this.m_txtRuleDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRuleDesc.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRuleDesc.Location = new System.Drawing.Point(89, 44);
            this.m_txtRuleDesc.MaxLength = 250;
            this.m_txtRuleDesc.Name = "m_txtRuleDesc";
            this.m_txtRuleDesc.Size = new System.Drawing.Size(685, 23);
            this.m_txtRuleDesc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "规则描述:";
            // 
            // m_txtRuleAliasName
            // 
            this.m_txtRuleAliasName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRuleAliasName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRuleAliasName.Location = new System.Drawing.Point(411, 20);
            this.m_txtRuleAliasName.MaxLength = 25;
            this.m_txtRuleAliasName.Name = "m_txtRuleAliasName";
            this.m_txtRuleAliasName.Size = new System.Drawing.Size(363, 23);
            this.m_txtRuleAliasName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(336, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "规则别名:";
            // 
            // m_txtRuleName
            // 
            this.m_txtRuleName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRuleName.Location = new System.Drawing.Point(89, 20);
            this.m_txtRuleName.MaxLength = 25;
            this.m_txtRuleName.Name = "m_txtRuleName";
            this.m_txtRuleName.Size = new System.Drawing.Size(233, 23);
            this.m_txtRuleName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "规则名称:";
            // 
            // m_lsvRules
            // 
            this.m_lsvRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chRuleName,
            this.m_chRuleAlias,
            this.m_chRuleDesc,
            this.m_chRuleFormula,
            this.m_chsummary,
            this.m_chDefaultFlag,
            this.m_chTypeFlag});
            this.m_lsvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvRules.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lsvRules.FullRowSelect = true;
            this.m_lsvRules.GridLines = true;
            this.m_lsvRules.HideSelection = false;
            this.m_lsvRules.Location = new System.Drawing.Point(0, 280);
            this.m_lsvRules.MultiSelect = false;
            this.m_lsvRules.Name = "m_lsvRules";
            this.m_lsvRules.Size = new System.Drawing.Size(783, 184);
            this.m_lsvRules.TabIndex = 1;
            this.m_lsvRules.TabStop = false;
            this.m_lsvRules.UseCompatibleStateImageBehavior = false;
            this.m_lsvRules.View = System.Windows.Forms.View.Details;
            this.m_lsvRules.Click += new System.EventHandler(this.m_lsvRules_Click);
            // 
            // m_chRuleName
            // 
            this.m_chRuleName.Text = "规则名称";
            this.m_chRuleName.Width = 116;
            // 
            // m_chRuleAlias
            // 
            this.m_chRuleAlias.Text = "规则别名";
            this.m_chRuleAlias.Width = 85;
            // 
            // m_chRuleDesc
            // 
            this.m_chRuleDesc.Text = "规则描述";
            this.m_chRuleDesc.Width = 247;
            // 
            // m_chRuleFormula
            // 
            this.m_chRuleFormula.Text = "规则公式";
            this.m_chRuleFormula.Width = 79;
            // 
            // m_chsummary
            // 
            this.m_chsummary.Text = "备注";
            this.m_chsummary.Width = 74;
            // 
            // m_chDefaultFlag
            // 
            this.m_chDefaultFlag.Text = "默认规则";
            this.m_chDefaultFlag.Width = 72;
            // 
            // m_chTypeFlag
            // 
            this.m_chTypeFlag.Text = "规则类型";
            this.m_chTypeFlag.Width = 106;
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDelete.DefaultScheme = true;
            this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelete.Hint = "";
            this.m_btnDelete.Location = new System.Drawing.Point(495, 24);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelete.Size = new System.Drawing.Size(86, 33);
            this.m_btnDelete.TabIndex = 1;
            this.m_btnDelete.Text = "删除";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(590, 24);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(86, 33);
            this.m_btnSave.TabIndex = 2;
            this.m_btnSave.Text = "保存";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnNew
            // 
            this.m_btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(400, 24);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(86, 33);
            this.m_btnNew.TabIndex = 0;
            this.m_btnNew.Text = "新增";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.m_btnDelete);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 80);
            this.panel1.TabIndex = 144;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(685, 24);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(86, 33);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmQCRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 544);
            this.Controls.Add(this.m_lsvRules);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmQCRules";
            this.Text = "质控规则管理";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQCRules_KeyDown);
            this.Load += new System.EventHandler(this.frmQCRules_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txtFormula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txtSummary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtRuleDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtRuleAliasName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtRuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_chkDefaultFlag;
        private System.Windows.Forms.ListView m_lsvRules;
        private PinkieControls.ButtonXP m_btnDelete;
        private PinkieControls.ButtonXP m_btnSave;
        private PinkieControls.ButtonXP m_btnNew;
        private System.Windows.Forms.ColumnHeader m_chRuleName;
        private System.Windows.Forms.ColumnHeader m_chRuleAlias;
        private System.Windows.Forms.ColumnHeader m_chRuleDesc;
        private System.Windows.Forms.ColumnHeader m_chsummary;
        private System.Windows.Forms.ColumnHeader m_chDefaultFlag;
        private System.Windows.Forms.ColumnHeader m_chTypeFlag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader m_chRuleFormula;
        private System.Windows.Forms.ComboBox m_cboTypeFlag;
        private System.Windows.Forms.Label label6;
        private PinkieControls.ButtonXP btnExit;
    }
}