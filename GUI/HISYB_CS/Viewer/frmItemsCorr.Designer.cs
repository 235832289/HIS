namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmItemsCorr
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
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstHospital = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstYBItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstItemsCorr = new System.Windows.Forms.ListView();
            this.colHosp = new System.Windows.Forms.ColumnHeader();
            this.colHospName = new System.Windows.Forms.ColumnHeader();
            this.colYBID = new System.Windows.Forms.ColumnHeader();
            this.colYBName = new System.Windows.Forms.ColumnHeader();
            this.btnsSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "科室对应",
            "病人身份对应"});
            this.cboType.Location = new System.Drawing.Point(93, 18);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(159, 20);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "对应类别：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstHospital);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 464);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "医院的项目";
            // 
            // lstHospital
            // 
            this.lstHospital.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.colID,
            this.colName});
            this.lstHospital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHospital.FullRowSelect = true;
            this.lstHospital.GridLines = true;
            this.lstHospital.Location = new System.Drawing.Point(3, 17);
            this.lstHospital.MultiSelect = false;
            this.lstHospital.Name = "lstHospital";
            this.lstHospital.Size = new System.Drawing.Size(229, 444);
            this.lstHospital.TabIndex = 0;
            this.lstHospital.UseCompatibleStateImageBehavior = false;
            this.lstHospital.View = System.Windows.Forms.View.Details;
            this.lstHospital.Validated += new System.EventHandler(this.lstHospital_Validated);
            this.lstHospital.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstHospital_ItemSelectionChanged);
            // 
            // colID
            // 
            this.colID.DisplayIndex = 0;
            this.colID.Text = "项目ID";
            this.colID.Width = 94;
            // 
            // colName
            // 
            this.colName.DisplayIndex = 1;
            this.colName.Text = "项目名称";
            this.colName.Width = 130;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstYBItems);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(235, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 464);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "社保的项目";
            // 
            // lstYBItems
            // 
            this.lstYBItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
            this.lstYBItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstYBItems.FullRowSelect = true;
            this.lstYBItems.GridLines = true;
            this.lstYBItems.Location = new System.Drawing.Point(3, 17);
            this.lstYBItems.MultiSelect = false;
            this.lstYBItems.Name = "lstYBItems";
            this.lstYBItems.Size = new System.Drawing.Size(241, 444);
            this.lstYBItems.TabIndex = 1;
            this.lstYBItems.UseCompatibleStateImageBehavior = false;
            this.lstYBItems.View = System.Windows.Forms.View.Details;
            this.lstYBItems.Validated += new System.EventHandler(this.lstYBItems_Validated);
            this.lstYBItems.SelectedIndexChanged += new System.EventHandler(this.lstYBItems_SelectedIndexChanged);
            this.lstYBItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstYBItems_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "项目ID";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 143;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lstItemsCorr);
            this.groupBox4.Location = new System.Drawing.Point(562, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(458, 463);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "对应后";
            // 
            // lstItemsCorr
            // 
            this.lstItemsCorr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.colHosp,
            this.colHospName,
            this.colYBID,
            this.colYBName});
            this.lstItemsCorr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItemsCorr.FullRowSelect = true;
            this.lstItemsCorr.GridLines = true;
            this.lstItemsCorr.Location = new System.Drawing.Point(3, 17);
            this.lstItemsCorr.MultiSelect = false;
            this.lstItemsCorr.Name = "lstItemsCorr";
            this.lstItemsCorr.Size = new System.Drawing.Size(452, 443);
            this.lstItemsCorr.TabIndex = 2;
            this.lstItemsCorr.UseCompatibleStateImageBehavior = false;
            this.lstItemsCorr.View = System.Windows.Forms.View.Details;
            // 
            // colHosp
            // 
            this.colHosp.DisplayIndex = 0;
            this.colHosp.Text = "医院项目ID";
            this.colHosp.Width = 94;
            // 
            // colHospName
            // 
            this.colHospName.DisplayIndex = 1;
            this.colHospName.Text = "医院项目名称";
            this.colHospName.Width = 123;
            // 
            // colYBID
            // 
            this.colYBID.DisplayIndex = 2;
            this.colYBID.Text = "社保项目ID";
            this.colYBID.Width = 82;
            // 
            // colYBName
            // 
            this.colYBName.DisplayIndex = 3;
            this.colYBName.Text = "社保项目名称";
            this.colYBName.Width = 147;
            // 
            // btnsSave
            // 
            this.btnsSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnsSave.Font = new System.Drawing.Font("宋体", 20F);
            this.btnsSave.Location = new System.Drawing.Point(485, 188);
            this.btnsSave.Name = "btnsSave";
            this.btnsSave.Size = new System.Drawing.Size(75, 31);
            this.btnsSave.TabIndex = 4;
            this.btnsSave.Text = "→";
            this.btnsSave.UseVisualStyleBackColor = true;
            this.btnsSave.Click += new System.EventHandler(this.btnsSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDel.Font = new System.Drawing.Font("宋体", 20F);
            this.btnDel.Location = new System.Drawing.Point(485, 277);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 31);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "←";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 2;
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Width = 0;
            // 
            // frmItemsCorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 514);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnsSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmItemsCorr";
            this.Text = "项目对应设置";
            this.Load += new System.EventHandler(this.frmItemsCorr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnsSave;
        private System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.ListView lstHospital;
        internal System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        internal System.Windows.Forms.ListView lstYBItems;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.ListView lstItemsCorr;
        internal System.Windows.Forms.ColumnHeader colHosp;
        private System.Windows.Forms.ColumnHeader colHospName;
        private System.Windows.Forms.ColumnHeader colYBID;
        private System.Windows.Forms.ColumnHeader colYBName;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}