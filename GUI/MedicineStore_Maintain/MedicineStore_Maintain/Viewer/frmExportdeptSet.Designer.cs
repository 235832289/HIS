namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmExportdeptSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportdeptSet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dgvExportdept = new System.Windows.Forms.DataGridView();
            this.colExpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdDownToLast = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdUpToFirst = new System.Windows.Forms.Button();
            this.m_cmdDown = new System.Windows.Forms.Button();
            this.m_cmdUp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.m_txtQuery = new System.Windows.Forms.TextBox();
            this.m_dgvExportdeptAll = new System.Windows.Forms.DataGridView();
            this.deptid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cmdAdd = new System.Windows.Forms.Button();
            this.m_cmdDel = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvExportdept)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvExportdeptAll)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(131, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 550);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "领用部门列表";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dgvExportdept);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 497);
            this.panel2.TabIndex = 3;
            // 
            // m_dgvExportdept
            // 
            this.m_dgvExportdept.AllowUserToAddRows = false;
            this.m_dgvExportdept.AllowUserToResizeColumns = false;
            this.m_dgvExportdept.AllowUserToResizeRows = false;
            this.m_dgvExportdept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvExportdept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExpID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.cboFlag});
            this.m_dgvExportdept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvExportdept.Location = new System.Drawing.Point(0, 0);
            this.m_dgvExportdept.MultiSelect = false;
            this.m_dgvExportdept.Name = "m_dgvExportdept";
            this.m_dgvExportdept.RowHeadersVisible = false;
            this.m_dgvExportdept.RowTemplate.Height = 23;
            this.m_dgvExportdept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvExportdept.Size = new System.Drawing.Size(329, 497);
            this.m_dgvExportdept.TabIndex = 1000;
            this.m_dgvExportdept.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.m_dgvExportdept_RowPostPaint);
            this.m_dgvExportdept.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvExportdept_CellClick);
            this.m_dgvExportdept.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvExportdept_DataError);
            // 
            // colExpID
            // 
            this.colExpID.HeaderText = "序号";
            this.colExpID.Name = "colExpID";
            this.colExpID.ReadOnly = true;
            this.colExpID.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "deptid_chr";
            this.dataGridViewTextBoxColumn1.HeaderText = "部门编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "deptname_vchr";
            this.dataGridViewTextBoxColumn2.HeaderText = "部门名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // cboFlag
            // 
            this.cboFlag.DataPropertyName = "storageflag_int";
            this.cboFlag.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboFlag.HeaderText = "库房设置";
            this.cboFlag.Name = "cboFlag";
            this.cboFlag.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdDownToLast);
            this.panel1.Controls.Add(this.m_cmdUpToFirst);
            this.panel1.Controls.Add(this.m_cmdDown);
            this.panel1.Controls.Add(this.m_cmdUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 31);
            this.panel1.TabIndex = 2;
            // 
            // m_cmdDownToLast
            // 
            this.m_cmdDownToLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDownToLast.ImageIndex = 4;
            this.m_cmdDownToLast.ImageList = this.imageList1;
            this.m_cmdDownToLast.Location = new System.Drawing.Point(107, 3);
            this.m_cmdDownToLast.Name = "m_cmdDownToLast";
            this.m_cmdDownToLast.Size = new System.Drawing.Size(23, 25);
            this.m_cmdDownToLast.TabIndex = 202;
            this.m_cmdDownToLast.UseVisualStyleBackColor = true;
            this.m_cmdDownToLast.Click += new System.EventHandler(this.m_cmdDownToLast_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // m_cmdUpToFirst
            // 
            this.m_cmdUpToFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdUpToFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_cmdUpToFirst.ImageIndex = 3;
            this.m_cmdUpToFirst.ImageList = this.imageList1;
            this.m_cmdUpToFirst.Location = new System.Drawing.Point(20, 3);
            this.m_cmdUpToFirst.Name = "m_cmdUpToFirst";
            this.m_cmdUpToFirst.Size = new System.Drawing.Size(23, 25);
            this.m_cmdUpToFirst.TabIndex = 201;
            this.m_cmdUpToFirst.UseVisualStyleBackColor = true;
            this.m_cmdUpToFirst.Click += new System.EventHandler(this.m_cmdUpToFirst_Click);
            // 
            // m_cmdDown
            // 
            this.m_cmdDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDown.ImageIndex = 2;
            this.m_cmdDown.ImageList = this.imageList1;
            this.m_cmdDown.Location = new System.Drawing.Point(78, 3);
            this.m_cmdDown.Name = "m_cmdDown";
            this.m_cmdDown.Size = new System.Drawing.Size(23, 25);
            this.m_cmdDown.TabIndex = 203;
            this.m_cmdDown.UseVisualStyleBackColor = true;
            this.m_cmdDown.Click += new System.EventHandler(this.m_cmdDown_Click);
            // 
            // m_cmdUp
            // 
            this.m_cmdUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdUp.ImageIndex = 1;
            this.m_cmdUp.ImageList = this.imageList1;
            this.m_cmdUp.Location = new System.Drawing.Point(49, 3);
            this.m_cmdUp.Name = "m_cmdUp";
            this.m_cmdUp.Size = new System.Drawing.Size(23, 25);
            this.m_cmdUp.TabIndex = 200;
            this.m_cmdUp.UseVisualStyleBackColor = true;
            this.m_cmdUp.Click += new System.EventHandler(this.m_cmdUp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txtQuery);
            this.groupBox2.Controls.Add(this.m_dgvExportdeptAll);
            this.groupBox2.Location = new System.Drawing.Point(560, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 547);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "医院部门列表";
            // 
            // label1
            // 
            this.label1.ImageIndex = 13;
            this.label1.ImageList = this.imageList2;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 25);
            this.label1.TabIndex = 2;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList2.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList2.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList2.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList2.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList2.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList2.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList2.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList2.Images.SetKeyName(8, "Shell32 136.ico");
            this.imageList2.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList2.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList2.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList2.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList2.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // m_txtQuery
            // 
            this.m_txtQuery.Location = new System.Drawing.Point(44, 21);
            this.m_txtQuery.Name = "m_txtQuery";
            this.m_txtQuery.Size = new System.Drawing.Size(260, 23);
            this.m_txtQuery.TabIndex = 1;
            this.m_txtQuery.TextChanged += new System.EventHandler(this.m_txtQuery_TextChanged);
            // 
            // m_dgvExportdeptAll
            // 
            this.m_dgvExportdeptAll.AllowUserToAddRows = false;
            this.m_dgvExportdeptAll.AllowUserToResizeRows = false;
            this.m_dgvExportdeptAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvExportdeptAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvExportdeptAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deptid_chr,
            this.deptname_vchr});
            this.m_dgvExportdeptAll.Location = new System.Drawing.Point(3, 50);
            this.m_dgvExportdeptAll.MultiSelect = false;
            this.m_dgvExportdeptAll.Name = "m_dgvExportdeptAll";
            this.m_dgvExportdeptAll.RowHeadersVisible = false;
            this.m_dgvExportdeptAll.RowTemplate.Height = 23;
            this.m_dgvExportdeptAll.Size = new System.Drawing.Size(325, 494);
            this.m_dgvExportdeptAll.TabIndex = 1000;
            this.m_dgvExportdeptAll.DoubleClick += new System.EventHandler(this.m_dgvExportdeptAll_DoubleClick);
            // 
            // deptid_chr
            // 
            this.deptid_chr.DataPropertyName = "deptid_chr";
            this.deptid_chr.HeaderText = "部门编号";
            this.deptid_chr.Name = "deptid_chr";
            this.deptid_chr.Visible = false;
            // 
            // deptname_vchr
            // 
            this.deptname_vchr.DataPropertyName = "deptname_vchr";
            this.deptname_vchr.HeaderText = "部门名称";
            this.deptname_vchr.Name = "deptname_vchr";
            this.deptname_vchr.ReadOnly = true;
            this.deptname_vchr.Width = 300;
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAdd.ImageIndex = 5;
            this.m_cmdAdd.Location = new System.Drawing.Point(490, 184);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Size = new System.Drawing.Size(50, 28);
            this.m_cmdAdd.TabIndex = 194;
            this.m_cmdAdd.Text = "＜＜";
            this.m_cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAdd.UseVisualStyleBackColor = true;
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // m_cmdDel
            // 
            this.m_cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDel.ImageIndex = 5;
            this.m_cmdDel.Location = new System.Drawing.Point(490, 230);
            this.m_cmdDel.Name = "m_cmdDel";
            this.m_cmdDel.Size = new System.Drawing.Size(50, 28);
            this.m_cmdDel.TabIndex = 195;
            this.m_cmdDel.Text = "＞＞";
            this.m_cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDel.UseVisualStyleBackColor = true;
            this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList2;
            this.m_cmdSave.Location = new System.Drawing.Point(364, 568);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 197;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 5;
            this.button3.ImageList = this.imageList2;
            this.button3.Location = new System.Drawing.Point(464, 568);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 28);
            this.button3.TabIndex = 198;
            this.button3.Text = "取消(&C)";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList2;
            this.m_cmdExit.Location = new System.Drawing.Point(564, 568);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 0;
            this.m_cmdExit.Text = "退出(&E)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // frmExportdeptSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 623);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdDel);
            this.Controls.Add(this.m_cmdAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmExportdeptSet";
            this.Text = "领用部门列表设置";
            this.Load += new System.EventHandler(this.frmExportdeptSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvExportdept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvExportdeptAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button m_cmdAdd;
        internal System.Windows.Forms.Button m_cmdDel;
        private System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button m_cmdExit;
        internal System.Windows.Forms.DataGridView m_dgvExportdeptAll;
        internal System.Windows.Forms.DataGridView m_dgvExportdept;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptname_vchr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdDownToLast;
        private System.Windows.Forms.Button m_cmdDown;
        private System.Windows.Forms.Button m_cmdUp;
        private System.Windows.Forms.Button m_cmdUpToFirst;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox m_txtQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal System.Windows.Forms.DataGridViewComboBoxColumn cboFlag;
    }
}