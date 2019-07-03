namespace com.digitalwave.iCare.gui.HIS
{
    partial class SpecialRemarkDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialRemarkDictionary));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_dgvSpecialRemarkDic = new System.Windows.Forms.DataGridView();
            this.REMARKID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERCODE_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargectl_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnSearch = new PinkieControls.ButtonXP();
            this.m_btnRefresh = new PinkieControls.ButtonXP();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.m_txtSearchContent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnDelete = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnAdd = new PinkieControls.ButtonXP();
            this.m_cboDebtControl = new System.Windows.Forms.ComboBox();
            this.m_txtUserCode = new System.Windows.Forms.TextBox();
            this.m_txtRemarkContent = new System.Windows.Forms.TextBox();
            this.m_txtRemarkID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSpecialRemarkDic)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 507);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_dgvSpecialRemarkDic);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 507);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // m_dgvSpecialRemarkDic
            // 
            this.m_dgvSpecialRemarkDic.AllowUserToAddRows = false;
            this.m_dgvSpecialRemarkDic.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvSpecialRemarkDic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvSpecialRemarkDic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvSpecialRemarkDic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvSpecialRemarkDic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.REMARKID_CHR,
            this.REMARKNAME_VCHR,
            this.USERCODE_VCHR,
            this.chargectl_status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvSpecialRemarkDic.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvSpecialRemarkDic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvSpecialRemarkDic.Location = new System.Drawing.Point(3, 91);
            this.m_dgvSpecialRemarkDic.MultiSelect = false;
            this.m_dgvSpecialRemarkDic.Name = "m_dgvSpecialRemarkDic";
            this.m_dgvSpecialRemarkDic.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvSpecialRemarkDic.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvSpecialRemarkDic.RowHeadersVisible = false;
            this.m_dgvSpecialRemarkDic.RowHeadersWidth = 15;
            this.m_dgvSpecialRemarkDic.RowTemplate.Height = 23;
            this.m_dgvSpecialRemarkDic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvSpecialRemarkDic.Size = new System.Drawing.Size(466, 413);
            this.m_dgvSpecialRemarkDic.TabIndex = 6;
            this.m_dgvSpecialRemarkDic.CurrentCellChanged += new System.EventHandler(this.m_dgvSpecialRemarkDic_CurrentCellChanged);
            // 
            // REMARKID_CHR
            // 
            this.REMARKID_CHR.DataPropertyName = "REMARKID_CHR";
            this.REMARKID_CHR.HeaderText = "注释编码";
            this.REMARKID_CHR.Name = "REMARKID_CHR";
            this.REMARKID_CHR.ReadOnly = true;
            // 
            // REMARKNAME_VCHR
            // 
            this.REMARKNAME_VCHR.DataPropertyName = "REMARKNAME_VCHR";
            this.REMARKNAME_VCHR.HeaderText = "注释内容";
            this.REMARKNAME_VCHR.Name = "REMARKNAME_VCHR";
            this.REMARKNAME_VCHR.ReadOnly = true;
            this.REMARKNAME_VCHR.Width = 150;
            // 
            // USERCODE_VCHR
            // 
            this.USERCODE_VCHR.DataPropertyName = "USERCODE_VCHR";
            this.USERCODE_VCHR.HeaderText = "用户编码";
            this.USERCODE_VCHR.Name = "USERCODE_VCHR";
            this.USERCODE_VCHR.ReadOnly = true;
            // 
            // chargectl_status
            // 
            this.chargectl_status.DataPropertyName = "chargectl_status";
            this.chargectl_status.HeaderText = "允许欠费";
            this.chargectl_status.Name = "chargectl_status";
            this.chargectl_status.ReadOnly = true;
            this.chargectl_status.Width = 110;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnSearch);
            this.panel2.Controls.Add(this.m_btnRefresh);
            this.panel2.Controls.Add(this.cboCondition);
            this.panel2.Controls.Add(this.m_txtSearchContent);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 74);
            this.panel2.TabIndex = 5;
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSearch.DefaultScheme = true;
            this.m_btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSearch.Hint = "";
            this.m_btnSearch.Location = new System.Drawing.Point(214, 18);
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSearch.Size = new System.Drawing.Size(112, 32);
            this.m_btnSearch.TabIndex = 17;
            this.m_btnSearch.Text = "查询(&F)";
            this.m_btnSearch.Click += new System.EventHandler(this.m_btnSearch_Click);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRefresh.DefaultScheme = true;
            this.m_btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRefresh.Hint = "";
            this.m_btnRefresh.Location = new System.Drawing.Point(338, 18);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRefresh.Size = new System.Drawing.Size(113, 32);
            this.m_btnRefresh.TabIndex = 16;
            this.m_btnRefresh.Text = "刷新(&R)";
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // cboCondition
            // 
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "注释编码",
            "注释内容",
            "用户编码",
            "欠费控制"});
            this.cboCondition.Location = new System.Drawing.Point(78, 7);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(121, 22);
            this.cboCondition.TabIndex = 15;
            // 
            // m_txtSearchContent
            // 
            this.m_txtSearchContent.Location = new System.Drawing.Point(78, 40);
            this.m_txtSearchContent.MaxLength = 4;
            this.m_txtSearchContent.Name = "m_txtSearchContent";
            this.m_txtSearchContent.Size = new System.Drawing.Size(121, 23);
            this.m_txtSearchContent.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "查询内容：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "查询条件：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnExit);
            this.groupBox2.Controls.Add(this.m_btnDelete);
            this.groupBox2.Controls.Add(this.m_btnSave);
            this.groupBox2.Controls.Add(this.m_btnAdd);
            this.groupBox2.Controls.Add(this.m_cboDebtControl);
            this.groupBox2.Controls.Add(this.m_txtUserCode);
            this.groupBox2.Controls.Add(this.m_txtRemarkContent);
            this.groupBox2.Controls.Add(this.m_txtRemarkID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 507);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(559, 423);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(108, 32);
            this.m_btnExit.TabIndex = 11;
            this.m_btnExit.Text = "退出(&E)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDelete.DefaultScheme = true;
            this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDelete.Hint = "";
            this.m_btnDelete.Location = new System.Drawing.Point(559, 374);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelete.Size = new System.Drawing.Size(108, 32);
            this.m_btnDelete.TabIndex = 10;
            this.m_btnDelete.Text = "删除(&D)";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(559, 320);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(108, 32);
            this.m_btnSave.TabIndex = 6;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnAdd.DefaultScheme = true;
            this.m_btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnAdd.Hint = "";
            this.m_btnAdd.Location = new System.Drawing.Point(559, 266);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAdd.Size = new System.Drawing.Size(108, 32);
            this.m_btnAdd.TabIndex = 5;
            this.m_btnAdd.Text = "新增(&A)";
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_cboDebtControl
            // 
            this.m_cboDebtControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDebtControl.FormattingEnabled = true;
            this.m_cboDebtControl.Items.AddRange(new object[] {
            "不允许",
            "允许"});
            this.m_cboDebtControl.Location = new System.Drawing.Point(578, 196);
            this.m_cboDebtControl.Name = "m_cboDebtControl";
            this.m_cboDebtControl.Size = new System.Drawing.Size(121, 24);
            this.m_cboDebtControl.TabIndex = 3;
            this.m_cboDebtControl.SelectedIndexChanged += new System.EventHandler(this.m_cboDebtControl_SelectedIndexChanged);
            this.m_cboDebtControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboDebtControl_KeyDown);
            // 
            // m_txtUserCode
            // 
            this.m_txtUserCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUserCode.Location = new System.Drawing.Point(577, 150);
            this.m_txtUserCode.MaxLength = 10;
            this.m_txtUserCode.Name = "m_txtUserCode";
            this.m_txtUserCode.Size = new System.Drawing.Size(122, 23);
            this.m_txtUserCode.TabIndex = 2;
            this.m_txtUserCode.TextChanged += new System.EventHandler(this.m_txtUserCode_TextChanged);
            this.m_txtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUserCode_KeyDown);
            // 
            // m_txtRemarkContent
            // 
            this.m_txtRemarkContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRemarkContent.Location = new System.Drawing.Point(577, 105);
            this.m_txtRemarkContent.MaxLength = 50;
            this.m_txtRemarkContent.Name = "m_txtRemarkContent";
            this.m_txtRemarkContent.Size = new System.Drawing.Size(122, 23);
            this.m_txtRemarkContent.TabIndex = 1;
            this.m_txtRemarkContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRemarkContent_KeyDown);
            // 
            // m_txtRemarkID
            // 
            this.m_txtRemarkID.BackColor = System.Drawing.Color.White;
            this.m_txtRemarkID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRemarkID.Location = new System.Drawing.Point(577, 57);
            this.m_txtRemarkID.Name = "m_txtRemarkID";
            this.m_txtRemarkID.ReadOnly = true;
            this.m_txtRemarkID.Size = new System.Drawing.Size(122, 23);
            this.m_txtRemarkID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(499, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "用户编码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "允许欠费:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "注释内容:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "注释编码:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询方式:";
            // 
            // SpecialRemarkDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpecialRemarkDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特别注释字典维护";
            this.Load += new System.EventHandler(this.SpecialRemarkDictionary_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSpecialRemarkDic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP m_btnSearch;
        internal PinkieControls.ButtonXP m_btnRefresh;
        internal System.Windows.Forms.TextBox m_txtSearchContent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP m_btnDelete;
        internal PinkieControls.ButtonXP m_btnSave;
        internal PinkieControls.ButtonXP m_btnAdd;
        internal PinkieControls.ButtonXP m_btnExit;
        internal System.Windows.Forms.DataGridView m_dgvSpecialRemarkDic;
        internal System.Windows.Forms.ComboBox cboCondition;
        internal System.Windows.Forms.TextBox m_txtUserCode;
        internal System.Windows.Forms.TextBox m_txtRemarkContent;
        internal System.Windows.Forms.TextBox m_txtRemarkID;
        internal System.Windows.Forms.ComboBox m_cboDebtControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERCODE_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargectl_status;
    }
}