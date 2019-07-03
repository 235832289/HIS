namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmCSYBShiyingzheng
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSYBShiyingzheng));
            this.cobSFLB = new System.Windows.Forms.ComboBox();
            this.chkSum = new System.Windows.Forms.CheckBox();
            this.cobSum = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdOK = new PinkieControls.ButtonXP();
            this.m_dgvItem = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcreatdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colamoun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatchamoun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsflb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // cobSFLB
            // 
            this.cobSFLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSFLB.Enabled = false;
            this.cobSFLB.FormattingEnabled = true;
            this.cobSFLB.Items.AddRange(new object[] {
            "2符合",
            "3不符合"});
            this.cobSFLB.Location = new System.Drawing.Point(592, 27);
            this.cobSFLB.Name = "cobSFLB";
            this.cobSFLB.Size = new System.Drawing.Size(98, 22);
            this.cobSFLB.TabIndex = 19;
            this.cobSFLB.Leave += new System.EventHandler(this.cobSFLB_Leave);
            // 
            // chkSum
            // 
            this.chkSum.AutoSize = true;
            this.chkSum.Location = new System.Drawing.Point(10, 11);
            this.chkSum.Name = "chkSum";
            this.chkSum.Size = new System.Drawing.Size(82, 18);
            this.chkSum.TabIndex = 16;
            this.chkSum.Text = "批量修改";
            this.chkSum.UseVisualStyleBackColor = true;
            this.chkSum.Visible = false;
            this.chkSum.CheckedChanged += new System.EventHandler(this.chkSum_CheckedChanged);
            // 
            // cobSum
            // 
            this.cobSum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSum.Enabled = false;
            this.cobSum.FormattingEnabled = true;
            this.cobSum.Items.AddRange(new object[] {
            "2符合",
            "3不符合"});
            this.cobSum.Location = new System.Drawing.Point(95, 9);
            this.cobSum.Name = "cobSum";
            this.cobSum.Size = new System.Drawing.Size(121, 22);
            this.cobSum.TabIndex = 17;
            this.cobSum.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cobSum);
            this.panel1.Controls.Add(this.chkSum);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 43);
            this.panel1.TabIndex = 17;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(593, 2);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(91, 36);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "关闭(&C)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdOK.DefaultScheme = true;
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdOK.Hint = "";
            this.cmdOK.Location = new System.Drawing.Point(481, 2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdOK.Size = new System.Drawing.Size(91, 36);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "确定(&O)";
            this.cmdOK.Visible = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // m_dgvItem
            // 
            this.m_dgvItem.AllowUserToAddRows = false;
            this.m_dgvItem.AllowUserToDeleteRows = false;
            this.m_dgvItem.AllowUserToResizeRows = false;
            this.m_dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dgvItem.ColumnHeadersHeight = 25;
            this.m_dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colItemCode,
            this.colItemName,
            this.colcreatdat,
            this.colamoun,
            this.colPatchamoun,
            this.colsflb});
            this.m_dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvItem.Location = new System.Drawing.Point(0, 0);
            this.m_dgvItem.MultiSelect = false;
            this.m_dgvItem.Name = "m_dgvItem";
            this.m_dgvItem.ReadOnly = true;
            this.m_dgvItem.RowHeadersVisible = false;
            this.m_dgvItem.RowTemplate.Height = 23;
            this.m_dgvItem.Size = new System.Drawing.Size(707, 523);
            this.m_dgvItem.TabIndex = 18;
            this.m_dgvItem.CurrentCellChanged += new System.EventHandler(this.m_dgvItem_CurrentCellChanged);
            // 
            // colNo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNo.HeaderText = "NO.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNo.Width = 30;
            // 
            // colItemCode
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.colItemCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItemCode.HeaderText = "编码";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            this.colItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colItemCode.Width = 90;
            // 
            // colItemName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.HeaderText = "名称";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colItemName.Width = 170;
            // 
            // colcreatdat
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            this.colcreatdat.DefaultCellStyle = dataGridViewCellStyle4;
            this.colcreatdat.HeaderText = "发生时间";
            this.colcreatdat.Name = "colcreatdat";
            this.colcreatdat.ReadOnly = true;
            this.colcreatdat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colcreatdat.Width = 140;
            // 
            // colamoun
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            this.colamoun.DefaultCellStyle = dataGridViewCellStyle5;
            this.colamoun.HeaderText = "数量";
            this.colamoun.Name = "colamoun";
            this.colamoun.ReadOnly = true;
            this.colamoun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colamoun.Width = 70;
            // 
            // colPatchamoun
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Maroon;
            this.colPatchamoun.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPatchamoun.HeaderText = "已退数量";
            this.colPatchamoun.Name = "colPatchamoun";
            this.colPatchamoun.ReadOnly = true;
            this.colPatchamoun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatchamoun.Width = 88;
            // 
            // colsflb
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            this.colsflb.DefaultCellStyle = dataGridViewCellStyle7;
            this.colsflb.HeaderText = "是否符合";
            this.colsflb.Name = "colsflb";
            this.colsflb.ReadOnly = true;
            this.colsflb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmCSYBShiyingzheng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 523);
            this.Controls.Add(this.cobSFLB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_dgvItem);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCSYBShiyingzheng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "适应症修改";
            this.Load += new System.EventHandler(this.frmCSYBShiyingzheng_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cobSFLB;
        private System.Windows.Forms.CheckBox chkSum;
        private System.Windows.Forms.ComboBox cobSum;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP cmdCancel;
        internal PinkieControls.ButtonXP cmdOK;
        private System.Windows.Forms.DataGridView m_dgvItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcreatdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colamoun;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchamoun;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsflb;
    }
}