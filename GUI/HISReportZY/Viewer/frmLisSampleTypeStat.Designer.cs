namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmLisSampleTypeStat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClear = new PinkieControls.ButtonXP();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxGroup = new System.Windows.Forms.ComboBox();
            this.cboPatType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteRq1 = new System.Windows.Forms.DateTimePicker();
            this.btnByDept = new PinkieControls.ButtonXP();
            this.dteRq2 = new System.Windows.Forms.DateTimePicker();
            this.dgvCheckItem = new System.Windows.Forms.DataGridView();
            this.btnExport = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExite = new PinkieControls.ButtonXP();
            this.tabContorl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTabClose = new PinkieControls.ButtonXP();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.tabColse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckItem)).BeginInit();
            this.tabContorl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.cbxGroup);
            this.splitContainer1.Panel1.Controls.Add(this.cboPatType);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dteRq1);
            this.splitContainer1.Panel1.Controls.Add(this.btnByDept);
            this.splitContainer1.Panel1.Controls.Add(this.dteRq2);
            this.splitContainer1.Panel1.Controls.Add(this.dgvCheckItem);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnExite);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabContorl);
            this.splitContainer1.Panel2.Controls.Add(this.dwRep);
            this.splitContainer1.Panel2.Controls.Add(this.dgvData);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 605);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 167;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClear.DefaultScheme = true;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.Hint = "";
            this.btnClear.Location = new System.Drawing.Point(84, 224);
            this.btnClear.Name = "btnClear";
            this.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClear.Size = new System.Drawing.Size(124, 27);
            this.btnClear.TabIndex = 172;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(4, 16);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(64, 27);
            this.btnQuery.TabIndex = 163;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(4, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 170;
            this.label8.Text = "病人类型：";
            // 
            // cbxGroup
            // 
            this.cbxGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxGroup.FormattingEnabled = true;
            this.cbxGroup.Items.AddRange(new object[] {
            ""});
            this.cbxGroup.Location = new System.Drawing.Point(72, 196);
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.Size = new System.Drawing.Size(132, 22);
            this.cbxGroup.TabIndex = 15;
            this.cbxGroup.SelectedIndexChanged += new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
            this.cbxGroup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbxGroup_MouseDown);
            // 
            // cboPatType
            // 
            this.cboPatType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPatType.FormattingEnabled = true;
            this.cboPatType.Items.AddRange(new object[] {
            ""});
            this.cboPatType.Location = new System.Drawing.Point(84, 168);
            this.cboPatType.Name = "cboPatType";
            this.cboPatType.Size = new System.Drawing.Size(120, 22);
            this.cboPatType.TabIndex = 171;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(4, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "专业组：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(4, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 167;
            this.label6.Text = "检验项目：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(46, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(4, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 165;
            this.label1.Text = "科室：";
            // 
            // dteRq1
            // 
            this.dteRq1.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dteRq1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dteRq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq1.Location = new System.Drawing.Point(72, 58);
            this.dteRq1.Name = "dteRq1";
            this.dteRq1.Size = new System.Drawing.Size(136, 23);
            this.dteRq1.TabIndex = 6;
            this.dteRq1.Value = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            // 
            // btnByDept
            // 
            this.btnByDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnByDept.DefaultScheme = true;
            this.btnByDept.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnByDept.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnByDept.Hint = "";
            this.btnByDept.Location = new System.Drawing.Point(70, 132);
            this.btnByDept.Name = "btnByDept";
            this.btnByDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnByDept.Size = new System.Drawing.Size(136, 27);
            this.btnByDept.TabIndex = 164;
            this.btnByDept.Text = "选择科室▼";
            this.btnByDept.Click += new System.EventHandler(this.btnByDept_Click);
            // 
            // dteRq2
            // 
            this.dteRq2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dteRq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq2.Location = new System.Drawing.Point(74, 91);
            this.dteRq2.Name = "dteRq2";
            this.dteRq2.Size = new System.Drawing.Size(135, 23);
            this.dteRq2.TabIndex = 8;
            // 
            // dgvCheckItem
            // 
            this.dgvCheckItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCheckItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcode,
            this.itemname});
            this.dgvCheckItem.Location = new System.Drawing.Point(4, 256);
            this.dgvCheckItem.Name = "dgvCheckItem";
            this.dgvCheckItem.ReadOnly = true;
            this.dgvCheckItem.RowHeadersVisible = false;
            this.dgvCheckItem.RowTemplate.Height = 23;
            this.dgvCheckItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckItem.Size = new System.Drawing.Size(212, 340);
            this.dgvCheckItem.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(76, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(64, 27);
            this.btnExport.TabIndex = 159;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(2, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "报告日期:";
            // 
            // btnExite
            // 
            this.btnExite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExite.DefaultScheme = true;
            this.btnExite.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExite.Hint = "";
            this.btnExite.Location = new System.Drawing.Point(148, 16);
            this.btnExite.Name = "btnExite";
            this.btnExite.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExite.Size = new System.Drawing.Size(64, 27);
            this.btnExite.TabIndex = 157;
            this.btnExite.Text = "退出";
            this.btnExite.Click += new System.EventHandler(this.btnExite_Click);
            // 
            // tabContorl
            // 
            this.tabContorl.Controls.Add(this.tabPage1);
            this.tabContorl.Location = new System.Drawing.Point(4, 12);
            this.tabContorl.Name = "tabContorl";
            this.tabContorl.SelectedIndex = 0;
            this.tabContorl.Size = new System.Drawing.Size(312, 508);
            this.tabContorl.TabIndex = 180;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTabClose);
            this.tabPage1.Controls.Add(this.dgvItem);
            this.tabPage1.Controls.Add(this.tabColse);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtSearchName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(304, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTabClose
            // 
            this.btnTabClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnTabClose.DefaultScheme = true;
            this.btnTabClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTabClose.Hint = "";
            this.btnTabClose.Location = new System.Drawing.Point(239, 448);
            this.btnTabClose.Name = "btnTabClose";
            this.btnTabClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnTabClose.Size = new System.Drawing.Size(64, 27);
            this.btnTabClose.TabIndex = 179;
            this.btnTabClose.Text = "关闭";
            this.btnTabClose.Click += new System.EventHandler(this.btnTabClose_Click);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvItem.Location = new System.Drawing.Point(3, 3);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersWidth = 25;
            this.dgvItem.RowTemplate.Height = 23;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(298, 433);
            this.dgvItem.TabIndex = 0;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // tabColse
            // 
            this.tabColse.Location = new System.Drawing.Point(348, 444);
            this.tabColse.Name = "tabColse";
            this.tabColse.Size = new System.Drawing.Size(61, 23);
            this.tabColse.TabIndex = 4;
            this.tabColse.Text = "关闭";
            this.tabColse.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtSearchName.Location = new System.Drawing.Point(80, 448);
            this.txtSearchName.MaxLength = 50;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(156, 23);
            this.txtSearchName.TabIndex = 2;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(2, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "名称检索:";
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(879, 605);
            this.dwRep.TabIndex = 13;
            this.dwRep.Text = "dataWindowControl1";
            this.dwRep.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(879, 605);
            this.dgvData.TabIndex = 181;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "检验项目编号";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            this.itemcode.Width = 60;
            // 
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "检验项目名称";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            this.itemname.Width = 145;
            // 
            // frmLisSampleTypeStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 605);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmLisSampleTypeStat";
            this.Text = "临床病原微生物标本送检情况";
            this.Load += new System.EventHandler(this.frmLisSampleTypeStat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckItem)).EndInit();
            this.tabContorl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Sybase.DataWindow.DataWindowControl dwRep;
        internal PinkieControls.ButtonXP btnClear;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cboPatType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP btnByDept;
        internal PinkieControls.ButtonXP btnQuery;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnExite;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DataGridView dgvCheckItem;
        internal System.Windows.Forms.DateTimePicker dteRq2;
        internal System.Windows.Forms.DateTimePicker dteRq1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cbxGroup;
        internal System.Windows.Forms.TabControl tabContorl;
        private System.Windows.Forms.TabPage tabPage1;
        internal PinkieControls.ButtonXP btnTabClose;
        internal System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button tabColse;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
    }
}