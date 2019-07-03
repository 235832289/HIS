namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYbdeadeficd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYbdeadeficd));
            this.m_tvDisease = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_deaDefICDdataGridView = new System.Windows.Forms.DataGridView();
            this.ICDCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICDName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_resetButton = new PinkieControls.ButtonXP();
            this.buttonFilter = new PinkieControls.ButtonXP();
            this.m_textBoxICD = new System.Windows.Forms.TextBox();
            this.m_ICdDataGridView = new System.Windows.Forms.DataGridView();
            this.DeaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeaDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClose = new PinkieControls.ButtonXP();
            this.buttonAdd = new PinkieControls.ButtonXP();
            this.buttonMove = new PinkieControls.ButtonXP();
            this.m_saveButton = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_deaDefICDdataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ICdDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tvDisease
            // 
            this.m_tvDisease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tvDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tvDisease.HideSelection = false;
            this.m_tvDisease.Location = new System.Drawing.Point(12, 39);
            this.m_tvDisease.Name = "m_tvDisease";
            this.m_tvDisease.Size = new System.Drawing.Size(204, 495);
            this.m_tvDisease.TabIndex = 0;
            this.m_tvDisease.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvDisease_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_deaDefICDdataGridView);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(227, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 496);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "对应的ICD10诊断码";
            // 
            // m_deaDefICDdataGridView
            // 
            this.m_deaDefICDdataGridView.AllowUserToAddRows = false;
            this.m_deaDefICDdataGridView.AllowUserToDeleteRows = false;
            this.m_deaDefICDdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_deaDefICDdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_deaDefICDdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ICDCode,
            this.ICDName});
            this.m_deaDefICDdataGridView.Location = new System.Drawing.Point(12, 21);
            this.m_deaDefICDdataGridView.MultiSelect = false;
            this.m_deaDefICDdataGridView.Name = "m_deaDefICDdataGridView";
            this.m_deaDefICDdataGridView.ReadOnly = true;
            this.m_deaDefICDdataGridView.RowTemplate.Height = 23;
            this.m_deaDefICDdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_deaDefICDdataGridView.Size = new System.Drawing.Size(313, 463);
            this.m_deaDefICDdataGridView.TabIndex = 1;
            // 
            // ICDCode
            // 
            this.ICDCode.HeaderText = "疾病码";
            this.ICDCode.Name = "ICDCode";
            this.ICDCode.ReadOnly = true;
            this.ICDCode.Width = 80;
            // 
            // ICDName
            // 
            this.ICDName.HeaderText = "疾病名";
            this.ICDName.Name = "ICDName";
            this.ICDName.ReadOnly = true;
            this.ICDName.Width = 190;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.m_resetButton);
            this.groupBox3.Controls.Add(this.buttonFilter);
            this.groupBox3.Controls.Add(this.m_textBoxICD);
            this.groupBox3.Controls.Add(this.m_ICdDataGridView);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(640, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 487);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ICD10列表";
            // 
            // m_resetButton
            // 
            this.m_resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_resetButton.DefaultScheme = true;
            this.m_resetButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_resetButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_resetButton.Hint = "";
            this.m_resetButton.Location = new System.Drawing.Point(279, 453);
            this.m_resetButton.Name = "m_resetButton";
            this.m_resetButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_resetButton.Size = new System.Drawing.Size(57, 26);
            this.m_resetButton.TabIndex = 111;
            this.m_resetButton.Text = "恢复";
            this.m_resetButton.Click += new System.EventHandler(this.m_resetButton_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonFilter.DefaultScheme = true;
            this.buttonFilter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonFilter.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonFilter.Hint = "";
            this.buttonFilter.Location = new System.Drawing.Point(218, 454);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonFilter.Size = new System.Drawing.Size(57, 26);
            this.buttonFilter.TabIndex = 110;
            this.buttonFilter.Text = "过滤";
            this.buttonFilter.Click += new System.EventHandler(this.buttonFillter_Click);
            // 
            // m_textBoxICD
            // 
            this.m_textBoxICD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxICD.Location = new System.Drawing.Point(11, 454);
            this.m_textBoxICD.Name = "m_textBoxICD";
            this.m_textBoxICD.Size = new System.Drawing.Size(201, 23);
            this.m_textBoxICD.TabIndex = 1;
            // 
            // m_ICdDataGridView
            // 
            this.m_ICdDataGridView.AllowUserToAddRows = false;
            this.m_ICdDataGridView.AllowUserToDeleteRows = false;
            this.m_ICdDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ICdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_ICdDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeaCode,
            this.DeaDesc});
            this.m_ICdDataGridView.Location = new System.Drawing.Point(12, 22);
            this.m_ICdDataGridView.MultiSelect = false;
            this.m_ICdDataGridView.Name = "m_ICdDataGridView";
            this.m_ICdDataGridView.ReadOnly = true;
            this.m_ICdDataGridView.RowTemplate.Height = 23;
            this.m_ICdDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_ICdDataGridView.Size = new System.Drawing.Size(324, 419);
            this.m_ICdDataGridView.TabIndex = 0;
            // 
            // DeaCode
            // 
            this.DeaCode.HeaderText = "疾病码";
            this.DeaCode.Name = "DeaCode";
            this.DeaCode.ReadOnly = true;
            this.DeaCode.Width = 80;
            // 
            // DeaDesc
            // 
            this.DeaDesc.HeaderText = "疾病名";
            this.DeaDesc.Name = "DeaDesc";
            this.DeaDesc.ReadOnly = true;
            this.DeaDesc.Width = 190;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonClose.DefaultScheme = true;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonClose.Hint = "";
            this.buttonClose.Location = new System.Drawing.Point(885, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonClose.Size = new System.Drawing.Size(80, 26);
            this.buttonClose.TabIndex = 106;
            this.buttonClose.Text = "关闭(&E)";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonAdd.DefaultScheme = true;
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonAdd.Hint = "";
            this.buttonAdd.Location = new System.Drawing.Point(577, 131);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonAdd.Size = new System.Drawing.Size(56, 26);
            this.buttonAdd.TabIndex = 107;
            this.buttonAdd.Text = "<<";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonMove.DefaultScheme = true;
            this.buttonMove.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonMove.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonMove.Hint = "";
            this.buttonMove.Location = new System.Drawing.Point(577, 187);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonMove.Size = new System.Drawing.Size(56, 26);
            this.buttonMove.TabIndex = 108;
            this.buttonMove.Text = ">>";
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // m_saveButton
            // 
            this.m_saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_saveButton.DefaultScheme = true;
            this.m_saveButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_saveButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_saveButton.Hint = "";
            this.m_saveButton.Location = new System.Drawing.Point(788, 12);
            this.m_saveButton.Name = "m_saveButton";
            this.m_saveButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_saveButton.Size = new System.Drawing.Size(80, 26);
            this.m_saveButton.TabIndex = 109;
            this.m_saveButton.Text = "保存(&S)";
            this.m_saveButton.Click += new System.EventHandler(this.m_saveButton_Click);
            // 
            // frmYbdeadeficd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 552);
            this.Controls.Add(this.m_saveButton);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_tvDisease);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYbdeadeficd";
            this.Text = "特定病种对应ICD10码间维护";
            this.Load += new System.EventHandler(this.frmYbdeadeficd10_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_deaDefICDdataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ICdDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.DataGridView m_ICdDataGridView;
        internal System.Windows.Forms.TreeView m_tvDisease;
        internal PinkieControls.ButtonXP buttonClose;
        internal PinkieControls.ButtonXP buttonAdd;
        internal PinkieControls.ButtonXP buttonMove;
        internal PinkieControls.ButtonXP m_saveButton;
        internal PinkieControls.ButtonXP m_resetButton;
        internal PinkieControls.ButtonXP buttonFilter;
        internal System.Windows.Forms.DataGridView m_deaDefICDdataGridView;
        internal System.Windows.Forms.TextBox m_textBoxICD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICDCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICDName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeaDesc;
    }
}