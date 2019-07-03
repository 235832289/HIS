namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmStorageRackset
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStorageRackset));
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_txtStoragerackcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_btnNew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtWbcode = new System.Windows.Forms.TextBox();
            this.m_txtPycode = new System.Windows.Forms.TextBox();
            this.m_txtStoragerackname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboStorageid = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lsvMedicineTypeSet = new System.Windows.Forms.ListView();
            this.m_colID = new System.Windows.Forms.ColumnHeader();
            this.m_colName = new System.Windows.Forms.ColumnHeader();
            this.m_STORAGE = new System.Windows.Forms.ColumnHeader();
            this.pycode_chr = new System.Windows.Forms.ColumnHeader();
            this.wbcode_chr = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(119, 43);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(92, 31);
            this.m_cmdExit.TabIndex = 20;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(16, 43);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(92, 31);
            this.m_cmdDelete.TabIndex = 19;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(119, 6);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(92, 31);
            this.m_cmdSave.TabIndex = 18;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_txtStoragerackcode
            // 
            this.m_txtStoragerackcode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtStoragerackcode.Location = new System.Drawing.Point(82, 12);
            this.m_txtStoragerackcode.MaxLength = 20;
            this.m_txtStoragerackcode.Name = "m_txtStoragerackcode";
            this.m_txtStoragerackcode.Size = new System.Drawing.Size(138, 23);
            this.m_txtStoragerackcode.TabIndex = 1;
            this.m_txtStoragerackcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtStoragerackcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "货架编码：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 746);
            this.panel1.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_btnNew);
            this.panel4.Controls.Add(this.m_cmdExit);
            this.panel4.Controls.Add(this.m_cmdDelete);
            this.panel4.Controls.Add(this.m_cmdSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 165);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 388);
            this.panel4.TabIndex = 25;
            // 
            // m_btnNew
            // 
            this.m_btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnNew.ImageIndex = 4;
            this.m_btnNew.ImageList = this.imageList1;
            this.m_btnNew.Location = new System.Drawing.Point(16, 6);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Size = new System.Drawing.Size(92, 31);
            this.m_btnNew.TabIndex = 21;
            this.m_btnNew.Text = "新建(&N)";
            this.m_btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnNew.UseVisualStyleBackColor = true;
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtWbcode);
            this.panel3.Controls.Add(this.m_txtPycode);
            this.panel3.Controls.Add(this.m_txtStoragerackname);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.m_txtStoragerackcode);
            this.panel3.Controls.Add(this.m_cboStorageid);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 165);
            this.panel3.TabIndex = 24;
            // 
            // m_txtWbcode
            // 
            this.m_txtWbcode.Location = new System.Drawing.Point(82, 127);
            this.m_txtWbcode.Name = "m_txtWbcode";
            this.m_txtWbcode.Size = new System.Drawing.Size(138, 23);
            this.m_txtWbcode.TabIndex = 5;
            // 
            // m_txtPycode
            // 
            this.m_txtPycode.Location = new System.Drawing.Point(82, 98);
            this.m_txtPycode.Name = "m_txtPycode";
            this.m_txtPycode.Size = new System.Drawing.Size(138, 23);
            this.m_txtPycode.TabIndex = 4;
            // 
            // m_txtStoragerackname
            // 
            this.m_txtStoragerackname.Location = new System.Drawing.Point(82, 41);
            this.m_txtStoragerackname.Name = "m_txtStoragerackname";
            this.m_txtStoragerackname.Size = new System.Drawing.Size(138, 23);
            this.m_txtStoragerackname.TabIndex = 2;
            this.m_txtStoragerackname.Leave += new System.EventHandler(this.m_txtStoragerackname_Leave);
            this.m_txtStoragerackname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtStoragerackname_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "五笔代码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "货架名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "拼音代码：";
            // 
            // m_cboStorageid
            // 
            this.m_cboStorageid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageid.FormattingEnabled = true;
            this.m_cboStorageid.Location = new System.Drawing.Point(82, 70);
            this.m_cboStorageid.Name = "m_cboStorageid";
            this.m_cboStorageid.Size = new System.Drawing.Size(138, 22);
            this.m_cboStorageid.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "仓库/药房：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lsvMedicineTypeSet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(230, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 746);
            this.panel2.TabIndex = 24;
            // 
            // m_lsvMedicineTypeSet
            // 
            this.m_lsvMedicineTypeSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colID,
            this.m_colName,
            this.m_STORAGE,
            this.pycode_chr,
            this.wbcode_chr});
            this.m_lsvMedicineTypeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvMedicineTypeSet.FullRowSelect = true;
            this.m_lsvMedicineTypeSet.GridLines = true;
            this.m_lsvMedicineTypeSet.HideSelection = false;
            this.m_lsvMedicineTypeSet.Location = new System.Drawing.Point(0, 0);
            this.m_lsvMedicineTypeSet.MultiSelect = false;
            this.m_lsvMedicineTypeSet.Name = "m_lsvMedicineTypeSet";
            this.m_lsvMedicineTypeSet.Size = new System.Drawing.Size(668, 746);
            this.m_lsvMedicineTypeSet.TabIndex = 17;
            this.m_lsvMedicineTypeSet.UseCompatibleStateImageBehavior = false;
            this.m_lsvMedicineTypeSet.View = System.Windows.Forms.View.Details;
            this.m_lsvMedicineTypeSet.DoubleClick += new System.EventHandler(this.m_lsvMedicineTypeSet_DoubleClick);
            this.m_lsvMedicineTypeSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvMedicineTypeSet_MouseUp);
            // 
            // m_colID
            // 
            this.m_colID.Text = "货架编码";
            this.m_colID.Width = 119;
            // 
            // m_colName
            // 
            this.m_colName.Text = "货架名称";
            this.m_colName.Width = 119;
            // 
            // m_STORAGE
            // 
            this.m_STORAGE.Text = "仓库/药房";
            this.m_STORAGE.Width = 114;
            // 
            // pycode_chr
            // 
            this.pycode_chr.Text = "拼音编码";
            this.pycode_chr.Width = 104;
            // 
            // wbcode_chr
            // 
            this.wbcode_chr.Text = "五笔编码";
            this.wbcode_chr.Width = 100;
            // 
            // frmStorageRackset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 746);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStorageRackset";
            this.Text = "货架设置";
            this.Load += new System.EventHandler(this.frmStorageRackset_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader m_colID;
        private System.Windows.Forms.ColumnHeader m_colName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader m_STORAGE;
        public System.Windows.Forms.ListView m_lsvMedicineTypeSet;
        private System.Windows.Forms.ColumnHeader pycode_chr;
        private System.Windows.Forms.ColumnHeader wbcode_chr;
        public System.Windows.Forms.TextBox m_txtStoragerackcode;
        public System.Windows.Forms.ComboBox m_cboStorageid;
        public System.Windows.Forms.TextBox m_txtWbcode;
        public System.Windows.Forms.TextBox m_txtPycode;
        public System.Windows.Forms.TextBox m_txtStoragerackname;
        public System.Windows.Forms.Button m_btnNew;
    }
}