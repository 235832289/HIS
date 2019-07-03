namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYbdeaDefChargeitem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYbdeaDefChargeitem));
            this.m_tvDisease = new System.Windows.Forms.TreeView();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAccordItem = new System.Windows.Forms.TabPage();
            this.m_DelButton = new PinkieControls.ButtonXP();
            this.m_dgvAccordItem = new System.Windows.Forms.DataGridView();
            this.YBItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItemSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItemPYCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItmeWBCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAllItem = new System.Windows.Forms.TabPage();
            this.m_addButton = new PinkieControls.ButtonXP();
            this.m_dgvAllItem = new System.Windows.Forms.DataGridView();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPYCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemWBCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_saveButton = new PinkieControls.ButtonXP();
            this.buttonClose = new PinkieControls.ButtonXP();
            this.m_cmbFilterType = new System.Windows.Forms.ComboBox();
            this.m_filterText = new System.Windows.Forms.TextBox();
            this.FilterButton = new PinkieControls.ButtonXP();
            this.m_resetButton = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageAccordItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccordItem)).BeginInit();
            this.tabPageAllItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAllItem)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tvDisease
            // 
            this.m_tvDisease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_tvDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tvDisease.HideSelection = false;
            this.m_tvDisease.Location = new System.Drawing.Point(8, 15);
            this.m_tvDisease.Name = "m_tvDisease";
            this.m_tvDisease.Size = new System.Drawing.Size(205, 519);
            this.m_tvDisease.TabIndex = 1;
            this.m_tvDisease.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvDisease_AfterSelect);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageAccordItem);
            this.tabControlMain.Controls.Add(this.tabPageAllItem);
            this.tabControlMain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMain.Location = new System.Drawing.Point(225, 67);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(729, 477);
            this.tabControlMain.TabIndex = 2;
            // 
            // tabPageAccordItem
            // 
            this.tabPageAccordItem.Controls.Add(this.m_DelButton);
            this.tabPageAccordItem.Controls.Add(this.m_dgvAccordItem);
            this.tabPageAccordItem.Location = new System.Drawing.Point(4, 23);
            this.tabPageAccordItem.Name = "tabPageAccordItem";
            this.tabPageAccordItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccordItem.Size = new System.Drawing.Size(721, 450);
            this.tabPageAccordItem.TabIndex = 0;
            this.tabPageAccordItem.Text = "特种病收费项目";
            this.tabPageAccordItem.UseVisualStyleBackColor = true;
            // 
            // m_DelButton
            // 
            this.m_DelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_DelButton.DefaultScheme = true;
            this.m_DelButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_DelButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_DelButton.Hint = "";
            this.m_DelButton.Location = new System.Drawing.Point(630, 12);
            this.m_DelButton.Name = "m_DelButton";
            this.m_DelButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_DelButton.Size = new System.Drawing.Size(68, 26);
            this.m_DelButton.TabIndex = 114;
            this.m_DelButton.Text = "删除(&D)";
            this.m_DelButton.Click += new System.EventHandler(this.m_DelButton_Click);
            // 
            // m_dgvAccordItem
            // 
            this.m_dgvAccordItem.AllowUserToAddRows = false;
            this.m_dgvAccordItem.AllowUserToDeleteRows = false;
            this.m_dgvAccordItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvAccordItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvAccordItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YBItemCode,
            this.YBItemName,
            this.YBItemSpec,
            this.YBItemPrice,
            this.YBItemPYCode,
            this.YBItmeWBCode,
            this.YBItemID});
            this.m_dgvAccordItem.Location = new System.Drawing.Point(6, 48);
            this.m_dgvAccordItem.Name = "m_dgvAccordItem";
            this.m_dgvAccordItem.ReadOnly = true;
            this.m_dgvAccordItem.RowTemplate.Height = 23;
            this.m_dgvAccordItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAccordItem.Size = new System.Drawing.Size(709, 394);
            this.m_dgvAccordItem.TabIndex = 0;
            // 
            // YBItemCode
            // 
            this.YBItemCode.HeaderText = "项目编码";
            this.YBItemCode.Name = "YBItemCode";
            this.YBItemCode.ReadOnly = true;
            // 
            // YBItemName
            // 
            this.YBItemName.HeaderText = "项目名称";
            this.YBItemName.Name = "YBItemName";
            this.YBItemName.ReadOnly = true;
            this.YBItemName.Width = 200;
            // 
            // YBItemSpec
            // 
            this.YBItemSpec.HeaderText = "项目规格";
            this.YBItemSpec.Name = "YBItemSpec";
            this.YBItemSpec.ReadOnly = true;
            // 
            // YBItemPrice
            // 
            this.YBItemPrice.HeaderText = "项目价格";
            this.YBItemPrice.Name = "YBItemPrice";
            this.YBItemPrice.ReadOnly = true;
            // 
            // YBItemPYCode
            // 
            this.YBItemPYCode.HeaderText = "拼音码";
            this.YBItemPYCode.Name = "YBItemPYCode";
            this.YBItemPYCode.ReadOnly = true;
            // 
            // YBItmeWBCode
            // 
            this.YBItmeWBCode.HeaderText = "五笔码";
            this.YBItmeWBCode.Name = "YBItmeWBCode";
            this.YBItmeWBCode.ReadOnly = true;
            // 
            // YBItemID
            // 
            this.YBItemID.HeaderText = "项目ID";
            this.YBItemID.Name = "YBItemID";
            this.YBItemID.ReadOnly = true;
            this.YBItemID.Visible = false;
            // 
            // tabPageAllItem
            // 
            this.tabPageAllItem.Controls.Add(this.m_addButton);
            this.tabPageAllItem.Controls.Add(this.m_dgvAllItem);
            this.tabPageAllItem.Location = new System.Drawing.Point(4, 23);
            this.tabPageAllItem.Name = "tabPageAllItem";
            this.tabPageAllItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllItem.Size = new System.Drawing.Size(721, 450);
            this.tabPageAllItem.TabIndex = 1;
            this.tabPageAllItem.Text = "所有收费项目";
            this.tabPageAllItem.UseVisualStyleBackColor = true;
            this.tabPageAllItem.Enter += new System.EventHandler(this.tabPageAllItem_Enter);
            // 
            // m_addButton
            // 
            this.m_addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_addButton.DefaultScheme = true;
            this.m_addButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_addButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_addButton.Hint = "";
            this.m_addButton.Location = new System.Drawing.Point(630, 12);
            this.m_addButton.Name = "m_addButton";
            this.m_addButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_addButton.Size = new System.Drawing.Size(68, 26);
            this.m_addButton.TabIndex = 113;
            this.m_addButton.Text = "增加(&A)";
            this.m_addButton.Click += new System.EventHandler(this.m_addButton_Click);
            // 
            // m_dgvAllItem
            // 
            this.m_dgvAllItem.AllowUserToAddRows = false;
            this.m_dgvAllItem.AllowUserToDeleteRows = false;
            this.m_dgvAllItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvAllItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvAllItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemName,
            this.ItemSpec,
            this.ItemPrice,
            this.ItemPYCode,
            this.ItemWBCode,
            this.ItemID});
            this.m_dgvAllItem.Location = new System.Drawing.Point(6, 48);
            this.m_dgvAllItem.Name = "m_dgvAllItem";
            this.m_dgvAllItem.ReadOnly = true;
            this.m_dgvAllItem.RowTemplate.Height = 23;
            this.m_dgvAllItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAllItem.Size = new System.Drawing.Size(709, 409);
            this.m_dgvAllItem.TabIndex = 1;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "项目编码";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "项目名称";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // ItemSpec
            // 
            this.ItemSpec.HeaderText = "项目规格";
            this.ItemSpec.Name = "ItemSpec";
            this.ItemSpec.ReadOnly = true;
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "项目价格";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            // 
            // ItemPYCode
            // 
            this.ItemPYCode.HeaderText = "拼音码";
            this.ItemPYCode.Name = "ItemPYCode";
            this.ItemPYCode.ReadOnly = true;
            // 
            // ItemWBCode
            // 
            this.ItemWBCode.HeaderText = "五笔码";
            this.ItemWBCode.Name = "ItemWBCode";
            this.ItemWBCode.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "项目ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // m_saveButton
            // 
            this.m_saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_saveButton.DefaultScheme = true;
            this.m_saveButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_saveButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_saveButton.Hint = "";
            this.m_saveButton.Location = new System.Drawing.Point(804, 23);
            this.m_saveButton.Name = "m_saveButton";
            this.m_saveButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_saveButton.Size = new System.Drawing.Size(68, 26);
            this.m_saveButton.TabIndex = 111;
            this.m_saveButton.Text = "保存(&S)";
            this.m_saveButton.Click += new System.EventHandler(this.m_saveButton_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonClose.DefaultScheme = true;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonClose.Hint = "";
            this.buttonClose.Location = new System.Drawing.Point(880, 23);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonClose.Size = new System.Drawing.Size(68, 26);
            this.buttonClose.TabIndex = 110;
            this.buttonClose.Text = "关闭(&E)";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // m_cmbFilterType
            // 
            this.m_cmbFilterType.FormattingEnabled = true;
            this.m_cmbFilterType.Items.AddRange(new object[] {
            "项目编码",
            "项目名称",
            "拼音码",
            "五笔码"});
            this.m_cmbFilterType.Location = new System.Drawing.Point(238, 26);
            this.m_cmbFilterType.Name = "m_cmbFilterType";
            this.m_cmbFilterType.Size = new System.Drawing.Size(121, 20);
            this.m_cmbFilterType.TabIndex = 114;
            // 
            // m_filterText
            // 
            this.m_filterText.Location = new System.Drawing.Point(369, 25);
            this.m_filterText.Name = "m_filterText";
            this.m_filterText.Size = new System.Drawing.Size(209, 21);
            this.m_filterText.TabIndex = 115;
            // 
            // FilterButton
            // 
            this.FilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.FilterButton.DefaultScheme = true;
            this.FilterButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.FilterButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FilterButton.Hint = "";
            this.FilterButton.Location = new System.Drawing.Point(584, 23);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.FilterButton.Size = new System.Drawing.Size(68, 26);
            this.FilterButton.TabIndex = 116;
            this.FilterButton.Text = "过滤(&F)";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // m_resetButton
            // 
            this.m_resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_resetButton.DefaultScheme = true;
            this.m_resetButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_resetButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_resetButton.Hint = "";
            this.m_resetButton.Location = new System.Drawing.Point(659, 23);
            this.m_resetButton.Name = "m_resetButton";
            this.m_resetButton.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_resetButton.Size = new System.Drawing.Size(68, 26);
            this.m_resetButton.TabIndex = 117;
            this.m_resetButton.Text = "重置(&R)";
            this.m_resetButton.Click += new System.EventHandler(this.m_resetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(229, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 49);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // frmYbdeaDefChargeitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 548);
            this.Controls.Add(this.m_resetButton);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.m_filterText);
            this.Controls.Add(this.m_cmbFilterType);
            this.Controls.Add(this.m_saveButton);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.m_tvDisease);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYbdeaDefChargeitem";
            this.Text = "医保特种病-收费项目(药品)对应维护";
            this.Load += new System.EventHandler(this.frmYbdeaDefChargeitem_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAccordItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccordItem)).EndInit();
            this.tabPageAllItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAllItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView m_tvDisease;
        private System.Windows.Forms.TabPage tabPageAccordItem;
        private System.Windows.Forms.TabPage tabPageAllItem;
        internal PinkieControls.ButtonXP m_saveButton;
        internal PinkieControls.ButtonXP buttonClose;
        internal System.Windows.Forms.DataGridView m_dgvAllItem;
        internal System.Windows.Forms.TabControl tabControlMain;
        internal System.Windows.Forms.DataGridView m_dgvAccordItem;
        internal PinkieControls.ButtonXP m_addButton;
        internal PinkieControls.ButtonXP m_DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemPYCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItmeWBCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPYCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemWBCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        internal PinkieControls.ButtonXP FilterButton;
        internal PinkieControls.ButtonXP m_resetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox m_cmbFilterType;
        internal System.Windows.Forms.TextBox m_filterText;
    }
}