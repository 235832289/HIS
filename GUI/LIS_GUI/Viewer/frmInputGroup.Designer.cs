namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmInputGroup
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
            this.dtgList = new System.Windows.Forms.DataGridView();
            this.clmApplyUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApplyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInputGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgList
            // 
            this.dtgList.AllowUserToAddRows = false;
            this.dtgList.AllowUserToDeleteRows = false;
            this.dtgList.AllowUserToResizeColumns = false;
            this.dtgList.AllowUserToResizeRows = false;
            this.dtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmApplyUnit,
            this.clmApplyName,
            this.clmInputGroup});
            this.dtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgList.Location = new System.Drawing.Point(0, 0);
            this.dtgList.Name = "dtgList";
            this.dtgList.RowHeadersVisible = false;
            this.dtgList.RowTemplate.Height = 23;
            this.dtgList.ShowCellErrors = false;
            this.dtgList.ShowCellToolTips = false;
            this.dtgList.ShowEditingIcon = false;
            this.dtgList.ShowRowErrors = false;
            this.dtgList.Size = new System.Drawing.Size(344, 342);
            this.dtgList.TabIndex = 0;
            this.dtgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgList_CellFormatting);
            this.dtgList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgList_DataError);
            this.dtgList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgList_CellEnter);
            // 
            // clmApplyUnit
            // 
            this.clmApplyUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clmApplyUnit.HeaderText = "申请单元ID";
            this.clmApplyUnit.Name = "clmApplyUnit";
            this.clmApplyUnit.ReadOnly = true;
            this.clmApplyUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmApplyUnit.Visible = false;
            // 
            // clmApplyName
            // 
            this.clmApplyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clmApplyName.HeaderText = "申请单元";
            this.clmApplyName.Name = "clmApplyName";
            this.clmApplyName.ReadOnly = true;
            this.clmApplyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmApplyName.Width = 69;
            // 
            // clmInputGroup
            // 
            this.clmInputGroup.AutoComplete = false;
            this.clmInputGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clmInputGroup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clmInputGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmInputGroup.HeaderText = "录入组合";
            this.clmInputGroup.MaxDropDownItems = 12;
            this.clmInputGroup.Name = "clmInputGroup";
            this.clmInputGroup.Width = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 66);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(104, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(110, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(220, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(110, 42);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmInputGroup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 408);
            this.ControlBox = false;
            this.Controls.Add(this.dtgList);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入组合选择";
            this.Load += new System.EventHandler(this.frmInputGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgList;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApplyUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApplyName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmInputGroup;

    }
}