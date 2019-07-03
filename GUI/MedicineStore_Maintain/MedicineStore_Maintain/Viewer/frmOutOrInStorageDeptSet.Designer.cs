namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmOutOrInStorageDeptSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutOrInStorageDeptSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lblSelected = new System.Windows.Forms.Label();
            this.m_dgvOutOrInStorageDept = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_cboStorageName = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtQuery = new System.Windows.Forms.TextBox();
            this.m_dgvtxtNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_dgvtxtDeptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtPY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutOrInStorageDept)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdExit);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.m_cmdSave);
            this.groupBox1.Location = new System.Drawing.Point(36, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 592);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lblSelected);
            this.panel2.Controls.Add(this.m_dgvOutOrInStorageDept);
            this.panel2.Location = new System.Drawing.Point(3, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 492);
            this.panel2.TabIndex = 1;
            // 
            // m_lblSelected
            // 
            this.m_lblSelected.BackColor = System.Drawing.Color.Transparent;
            this.m_lblSelected.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.m_lblSelected.Location = new System.Drawing.Point(3, 4);
            this.m_lblSelected.Name = "m_lblSelected";
            this.m_lblSelected.Size = new System.Drawing.Size(18, 28);
            this.m_lblSelected.TabIndex = 1;
            this.m_lblSelected.Tag = "False";
            this.m_lblSelected.Text = "全选";
            this.m_lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblSelected.MouseLeave += new System.EventHandler(this.m_lblSelected_MouseLeave);
            this.m_lblSelected.Click += new System.EventHandler(this.m_lblSelected_Click);
            this.m_lblSelected.MouseEnter += new System.EventHandler(this.m_lblSelected_MouseEnter);
            // 
            // m_dgvOutOrInStorageDept
            // 
            this.m_dgvOutOrInStorageDept.AllowUserToAddRows = false;
            this.m_dgvOutOrInStorageDept.AllowUserToResizeColumns = false;
            this.m_dgvOutOrInStorageDept.AllowUserToResizeRows = false;
            this.m_dgvOutOrInStorageDept.ColumnHeadersHeight = 32;
            this.m_dgvOutOrInStorageDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvOutOrInStorageDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtNo,
            this.m_dgvtxtDeptid,
            this.m_dgvtxtOrderNo,
            this.m_dgvtxtDeptName,
            this.m_dgvtxtPY,
            this.m_dgvtxtCode});
            this.m_dgvOutOrInStorageDept.Location = new System.Drawing.Point(0, 0);
            this.m_dgvOutOrInStorageDept.MultiSelect = false;
            this.m_dgvOutOrInStorageDept.Name = "m_dgvOutOrInStorageDept";
            this.m_dgvOutOrInStorageDept.RowHeadersVisible = false;
            this.m_dgvOutOrInStorageDept.RowTemplate.Height = 23;
            this.m_dgvOutOrInStorageDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvOutOrInStorageDept.Size = new System.Drawing.Size(535, 492);
            this.m_dgvOutOrInStorageDept.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtQuery);
            this.panel1.Controls.Add(this.m_cboStorageName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 45);
            this.panel1.TabIndex = 0;
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList2;
            this.m_cmdExit.Location = new System.Drawing.Point(328, 557);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 10073;
            this.m_cmdExit.Text = "退出(&E)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
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
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 5;
            this.button3.ImageList = this.imageList2;
            this.button3.Location = new System.Drawing.Point(228, 557);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 28);
            this.button3.TabIndex = 10075;
            this.button3.Text = "取消(&C)";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList2;
            this.m_cmdSave.Location = new System.Drawing.Point(128, 557);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 10074;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(98, 13);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(128, 22);
            this.m_cboStorageName.TabIndex = 0;
            this.m_cboStorageName.SelectedIndexChanged += new System.EventHandler(this.m_cboStorageName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 10072;
            this.label3.Text = "出库部门名称：";
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
            this.imageList1.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList1.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList1.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList1.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList1.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // label1
            // 
            this.label1.ImageIndex = 13;
            this.label1.ImageList = this.imageList2;
            this.label1.Location = new System.Drawing.Point(239, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 10074;
            // 
            // m_txtQuery
            // 
            this.m_txtQuery.Location = new System.Drawing.Point(277, 13);
            this.m_txtQuery.Name = "m_txtQuery";
            this.m_txtQuery.Size = new System.Drawing.Size(249, 23);
            this.m_txtQuery.TabIndex = 1;
            this.m_txtQuery.TextChanged += new System.EventHandler(this.m_txtQuery_TextChanged);
            // 
            // m_dgvtxtNo
            // 
            this.m_dgvtxtNo.DataPropertyName = "checkbox_chr";
            this.m_dgvtxtNo.FalseValue = "F";
            this.m_dgvtxtNo.HeaderText = "";
            this.m_dgvtxtNo.Name = "m_dgvtxtNo";
            this.m_dgvtxtNo.TrueValue = "T";
            this.m_dgvtxtNo.Width = 20;
            // 
            // m_dgvtxtDeptid
            // 
            this.m_dgvtxtDeptid.DataPropertyName = "deptid_chr";
            this.m_dgvtxtDeptid.HeaderText = "部门编码";
            this.m_dgvtxtDeptid.Name = "m_dgvtxtDeptid";
            this.m_dgvtxtDeptid.Visible = false;
            // 
            // m_dgvtxtOrderNo
            // 
            this.m_dgvtxtOrderNo.DataPropertyName = "numberno";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtOrderNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtOrderNo.HeaderText = "№";
            this.m_dgvtxtOrderNo.Name = "m_dgvtxtOrderNo";
            this.m_dgvtxtOrderNo.ReadOnly = true;
            this.m_dgvtxtOrderNo.Width = 30;
            // 
            // m_dgvtxtDeptName
            // 
            this.m_dgvtxtDeptName.DataPropertyName = "deptname_vchr";
            this.m_dgvtxtDeptName.HeaderText = "接收入库通知单名称";
            this.m_dgvtxtDeptName.Name = "m_dgvtxtDeptName";
            this.m_dgvtxtDeptName.ReadOnly = true;
            this.m_dgvtxtDeptName.Width = 400;
            // 
            // m_dgvtxtPY
            // 
            this.m_dgvtxtPY.HeaderText = "拼音";
            this.m_dgvtxtPY.Name = "m_dgvtxtPY";
            this.m_dgvtxtPY.Visible = false;
            // 
            // m_dgvtxtCode
            // 
            this.m_dgvtxtCode.HeaderText = "五笔";
            this.m_dgvtxtCode.Name = "m_dgvtxtCode";
            this.m_dgvtxtCode.Visible = false;
            // 
            // frmOutOrInStorageDeptSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 623);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutOrInStorageDeptSet";
            this.Text = "自动接收通知单据设置";
            this.Load += new System.EventHandler(this.frmOutOrInStorageDeptSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutOrInStorageDept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView m_dgvOutOrInStorageDept;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.Button m_cmdExit;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Label m_lblSelected;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtQuery;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dgvtxtNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtDeptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtPY;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCode;
    }
}