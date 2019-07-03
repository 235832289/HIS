namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPatientRecipeNoPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientRecipeNoPay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_pnlTop = new System.Windows.Forms.Panel();
            this.m_lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_cmdSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdAssociate = new System.Windows.Forms.ToolStripButton();
            this.m_cmdReSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_lblReminder = new System.Windows.Forms.ToolStripLabel();
            this.m_lblSex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtPatientNo = new System.Windows.Forms.TextBox();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.m_pnlMid = new System.Windows.Forms.Panel();
            this.m_dgvResult = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRegisterid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutpatrecipeno_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecipeflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecorddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.m_pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // m_pnlTop
            // 
            this.m_pnlTop.Controls.Add(this.m_lblName);
            this.m_pnlTop.Controls.Add(this.label2);
            this.m_pnlTop.Controls.Add(this.panel1);
            this.m_pnlTop.Controls.Add(this.m_lblSex);
            this.m_pnlTop.Controls.Add(this.label1);
            this.m_pnlTop.Controls.Add(this.m_txtPatientNo);
            this.m_pnlTop.Controls.Add(this.m_cboType);
            this.m_pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_pnlTop.Location = new System.Drawing.Point(0, 0);
            this.m_pnlTop.Name = "m_pnlTop";
            this.m_pnlTop.Size = new System.Drawing.Size(595, 81);
            this.m_pnlTop.TabIndex = 0;
            // 
            // m_lblName
            // 
            this.m_lblName.AutoSize = true;
            this.m_lblName.Location = new System.Drawing.Point(282, 10);
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(0, 14);
            this.m_lblName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "姓名:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 45);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdSelect,
            this.toolStripSeparator1,
            this.m_cmdAssociate,
            this.m_cmdReSet,
            this.toolStripSeparator2,
            this.m_cmdExit,
            this.toolStripSeparator3,
            this.m_lblReminder});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(595, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_cmdSelect
            // 
            this.m_cmdSelect.AutoSize = false;
            this.m_cmdSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdSelect.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdSelect.Image")));
            this.m_cmdSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdSelect.Name = "m_cmdSelect";
            this.m_cmdSelect.Size = new System.Drawing.Size(70, 42);
            this.m_cmdSelect.Text = "查询";
            this.m_cmdSelect.Click += new System.EventHandler(this.m_cmdSelect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdAssociate
            // 
            this.m_cmdAssociate.AutoSize = false;
            this.m_cmdAssociate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdAssociate.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdAssociate.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdAssociate.Image")));
            this.m_cmdAssociate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdAssociate.Name = "m_cmdAssociate";
            this.m_cmdAssociate.Size = new System.Drawing.Size(70, 45);
            this.m_cmdAssociate.Text = "关联";
            this.m_cmdAssociate.Click += new System.EventHandler(this.m_cmdAssociate_Click);
            // 
            // m_cmdReSet
            // 
            this.m_cmdReSet.AutoSize = false;
            this.m_cmdReSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdReSet.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdReSet.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdReSet.Image")));
            this.m_cmdReSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdReSet.Name = "m_cmdReSet";
            this.m_cmdReSet.Size = new System.Drawing.Size(70, 45);
            this.m_cmdReSet.Text = "重算";
            this.m_cmdReSet.Click += new System.EventHandler(this.m_cmdReSet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.AutoSize = false;
            this.m_cmdExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExit.Image")));
            this.m_cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(70, 42);
            this.m_cmdExit.Text = "关闭";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // m_lblReminder
            // 
            this.m_lblReminder.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblReminder.ForeColor = System.Drawing.Color.Red;
            this.m_lblReminder.Name = "m_lblReminder";
            this.m_lblReminder.Size = new System.Drawing.Size(189, 42);
            this.m_lblReminder.Text = "门诊有未交费用处方，请关联";
            this.m_lblReminder.Visible = false;
            // 
            // m_lblSex
            // 
            this.m_lblSex.AutoSize = true;
            this.m_lblSex.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lblSex.Location = new System.Drawing.Point(416, 10);
            this.m_lblSex.Name = "m_lblSex";
            this.m_lblSex.Size = new System.Drawing.Size(0, 14);
            this.m_lblSex.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "性别:";
            // 
            // m_txtPatientNo
            // 
            this.m_txtPatientNo.Location = new System.Drawing.Point(105, 7);
            this.m_txtPatientNo.Name = "m_txtPatientNo";
            this.m_txtPatientNo.Size = new System.Drawing.Size(123, 23);
            this.m_txtPatientNo.TabIndex = 1;
            this.m_txtPatientNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatientNo_KeyDown);
            // 
            // m_cboType
            // 
            this.m_cboType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Items.AddRange(new object[] {
            "---------",
            "1-住院号",
            "2-诊疗号"});
            this.m_cboType.Location = new System.Drawing.Point(9, 7);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(90, 21);
            this.m_cboType.TabIndex = 0;
            // 
            // m_pnlMid
            // 
            this.m_pnlMid.Controls.Add(this.m_dgvResult);
            this.m_pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlMid.Location = new System.Drawing.Point(0, 81);
            this.m_pnlMid.Name = "m_pnlMid";
            this.m_pnlMid.Size = new System.Drawing.Size(595, 296);
            this.m_pnlMid.TabIndex = 1;
            // 
            // m_dgvResult
            // 
            this.m_dgvResult.AllowUserToAddRows = false;
            this.m_dgvResult.AllowUserToDeleteRows = false;
            this.m_dgvResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.m_dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colRegisterid,
            this.colOutpatrecipeno_vchr,
            this.colRecipeflag,
            this.colRecorddate});
            this.m_dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvResult.Location = new System.Drawing.Point(0, 0);
            this.m_dgvResult.MultiSelect = false;
            this.m_dgvResult.Name = "m_dgvResult";
            this.m_dgvResult.RowHeadersVisible = false;
            this.m_dgvResult.RowTemplate.Height = 23;
            this.m_dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvResult.Size = new System.Drawing.Size(595, 296);
            this.m_dgvResult.TabIndex = 0;
            this.m_dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvResult_CellClick);
            this.m_dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvResult_CellDoubleClick);
            // 
            // colCheck
            // 
            this.colCheck.FalseValue = "F";
            this.colCheck.HeaderText = "※";
            this.colCheck.Name = "colCheck";
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "T";
            this.colCheck.Width = 30;
            // 
            // colRegisterid
            // 
            this.colRegisterid.HeaderText = "挂号";
            this.colRegisterid.Name = "colRegisterid";
            this.colRegisterid.ReadOnly = true;
            // 
            // colOutpatrecipeno_vchr
            // 
            this.colOutpatrecipeno_vchr.HeaderText = "处方号";
            this.colOutpatrecipeno_vchr.Name = "colOutpatrecipeno_vchr";
            this.colOutpatrecipeno_vchr.ReadOnly = true;
            this.colOutpatrecipeno_vchr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOutpatrecipeno_vchr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOutpatrecipeno_vchr.Width = 150;
            // 
            // colRecipeflag
            // 
            this.colRecipeflag.HeaderText = "正/副方";
            this.colRecipeflag.Name = "colRecipeflag";
            this.colRecipeflag.ReadOnly = true;
            this.colRecipeflag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRecipeflag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRecipeflag.Width = 50;
            // 
            // colRecorddate
            // 
            this.colRecorddate.HeaderText = "记录时间";
            this.colRecorddate.Name = "colRecorddate";
            this.colRecorddate.ReadOnly = true;
            this.colRecorddate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRecorddate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRecorddate.Width = 250;
            // 
            // frmPatientRecipeNoPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(595, 377);
            this.Controls.Add(this.m_pnlMid);
            this.Controls.Add(this.m_pnlTop);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPatientRecipeNoPay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病人门诊处方未交费列表";
            this.Load += new System.EventHandler(this.frmPatientRecipeNoPay_Load);
            this.m_pnlTop.ResumeLayout(false);
            this.m_pnlTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.m_pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlTop;
        private System.Windows.Forms.Panel m_pnlMid;
        internal System.Windows.Forms.ComboBox m_cboType;
        internal System.Windows.Forms.Label m_lblSex;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView m_dgvResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_cmdReSet;
        private System.Windows.Forms.ToolStripButton m_cmdExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.TextBox m_txtPatientNo;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label m_lblName;
        internal System.Windows.Forms.ToolStripButton m_cmdAssociate;
        internal System.Windows.Forms.ToolStripButton m_cmdSelect;
        internal System.Windows.Forms.ToolStripLabel m_lblReminder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisterid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutpatrecipeno_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecipeflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecorddate;
    }
}