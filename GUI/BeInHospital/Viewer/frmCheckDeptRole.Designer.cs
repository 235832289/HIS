namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmCheckDeptRole
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
            this.m_lsvCheckDeptRole = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lsvRole = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lsvApplyType = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.m_exit = new PinkieControls.ButtonXP();
            this.m_btnDelete = new PinkieControls.ButtonXP();
            this.m_btnAdd = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lsvCheckDeptRole);
            this.groupBox1.Location = new System.Drawing.Point(284, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 636);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前角色对应的检查单据";
            // 
            // m_lsvCheckDeptRole
            // 
            this.m_lsvCheckDeptRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvCheckDeptRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvCheckDeptRole.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvCheckDeptRole.FullRowSelect = true;
            this.m_lsvCheckDeptRole.GridLines = true;
            this.m_lsvCheckDeptRole.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvCheckDeptRole.HideSelection = false;
            this.m_lsvCheckDeptRole.Location = new System.Drawing.Point(3, 19);
            this.m_lsvCheckDeptRole.MultiSelect = false;
            this.m_lsvCheckDeptRole.Name = "m_lsvCheckDeptRole";
            this.m_lsvCheckDeptRole.Size = new System.Drawing.Size(294, 614);
            this.m_lsvCheckDeptRole.TabIndex = 1;
            this.m_lsvCheckDeptRole.UseCompatibleStateImageBehavior = false;
            this.m_lsvCheckDeptRole.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "检查单类型";
            this.columnHeader2.Width = 310;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "applyTypeId";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "seq";
            this.columnHeader7.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvRole);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 636);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "角色";
            // 
            // m_lsvRole
            // 
            this.m_lsvRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4});
            this.m_lsvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvRole.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvRole.FullRowSelect = true;
            this.m_lsvRole.GridLines = true;
            this.m_lsvRole.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvRole.HideSelection = false;
            this.m_lsvRole.Location = new System.Drawing.Point(3, 19);
            this.m_lsvRole.MultiSelect = false;
            this.m_lsvRole.Name = "m_lsvRole";
            this.m_lsvRole.Size = new System.Drawing.Size(227, 614);
            this.m_lsvRole.TabIndex = 2;
            this.m_lsvRole.UseCompatibleStateImageBehavior = false;
            this.m_lsvRole.View = System.Windows.Forms.View.Details;
            this.m_lsvRole.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.m_lsvRole_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "角色名称";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "角色Id";
            this.columnHeader4.Width = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lsvApplyType);
            this.groupBox3.Location = new System.Drawing.Point(679, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 636);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "所有检查单类型";
            // 
            // m_lsvApplyType
            // 
            this.m_lsvApplyType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5});
            this.m_lsvApplyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvApplyType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvApplyType.FullRowSelect = true;
            this.m_lsvApplyType.GridLines = true;
            this.m_lsvApplyType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvApplyType.HideSelection = false;
            this.m_lsvApplyType.Location = new System.Drawing.Point(3, 19);
            this.m_lsvApplyType.MultiSelect = false;
            this.m_lsvApplyType.Name = "m_lsvApplyType";
            this.m_lsvApplyType.Size = new System.Drawing.Size(308, 614);
            this.m_lsvApplyType.TabIndex = 2;
            this.m_lsvApplyType.UseCompatibleStateImageBehavior = false;
            this.m_lsvApplyType.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "检查单类型";
            this.columnHeader3.Width = 310;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // m_exit
            // 
            this.m_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_exit.DefaultScheme = true;
            this.m_exit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_exit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_exit.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.m_exit.Hint = "";
            this.m_exit.Location = new System.Drawing.Point(588, 267);
            this.m_exit.Name = "m_exit";
            this.m_exit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_exit.Size = new System.Drawing.Size(85, 30);
            this.m_exit.TabIndex = 8;
            this.m_exit.Text = "退出(&E)";
            this.m_exit.Click += new System.EventHandler(this.m_exit_Click);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDelete.DefaultScheme = true;
            this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDelete.Hint = "";
            this.m_btnDelete.Location = new System.Drawing.Point(588, 219);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelete.Size = new System.Drawing.Size(85, 24);
            this.m_btnDelete.TabIndex = 7;
            this.m_btnDelete.Text = "<--";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnAdd.DefaultScheme = true;
            this.m_btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnAdd.ForeColor = System.Drawing.Color.Black;
            this.m_btnAdd.Hint = "";
            this.m_btnAdd.Location = new System.Drawing.Point(588, 177);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAdd.Size = new System.Drawing.Size(85, 24);
            this.m_btnAdd.TabIndex = 6;
            this.m_btnAdd.Text = "-->";
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // frmCheckDeptRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 651);
            this.Controls.Add(this.m_exit);
            this.Controls.Add(this.m_btnDelete);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCheckDeptRole";
            this.Text = "角色检查单对应维护";
            this.Load += new System.EventHandler(this.frmCheckDeptRole_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ListView m_lsvCheckDeptRole;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ListView m_lsvRole;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ListView m_lsvApplyType;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        internal PinkieControls.ButtonXP m_exit;
        internal PinkieControls.ButtonXP m_btnDelete;
        internal PinkieControls.ButtonXP m_btnAdd;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}