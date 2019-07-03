namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPATSPECREMARK
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_ckbChargeCtl = new System.Windows.Forms.CheckBox();
            this.m_txtDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtREMARK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdSPECREMARKDel = new PinkieControls.ButtonXP();
            this.cmdSPECREMARKSave = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERCODE_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGECTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGECTL_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.ucPatientInfo1 = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(247, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 653);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_ckbChargeCtl);
            this.panel2.Controls.Add(this.m_txtDes);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_txtREMARK);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 304);
            this.panel2.TabIndex = 1;
            // 
            // m_ckbChargeCtl
            // 
            this.m_ckbChargeCtl.AutoSize = true;
            this.m_ckbChargeCtl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ckbChargeCtl.ForeColor = System.Drawing.Color.Blue;
            this.m_ckbChargeCtl.Location = new System.Drawing.Point(459, 23);
            this.m_ckbChargeCtl.Name = "m_ckbChargeCtl";
            this.m_ckbChargeCtl.Size = new System.Drawing.Size(82, 18);
            this.m_ckbChargeCtl.TabIndex = 5;
            this.m_ckbChargeCtl.Text = "允许欠费";
            this.m_ckbChargeCtl.UseVisualStyleBackColor = true;
            // 
            // m_txtDes
            // 
            this.m_txtDes.Location = new System.Drawing.Point(8, 69);
            this.m_txtDes.MaxLength = 100;
            this.m_txtDes.Multiline = true;
            this.m_txtDes.Name = "m_txtDes";
            this.m_txtDes.Size = new System.Drawing.Size(539, 181);
            this.m_txtDes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "备注信息:";
            // 
            // m_txtREMARK
            // 
            this.m_txtREMARK.Location = new System.Drawing.Point(81, 21);
            this.m_txtREMARK.MaxLength = 25;
            this.m_txtREMARK.Name = "m_txtREMARK";
            this.m_txtREMARK.Size = new System.Drawing.Size(372, 21);
            this.m_txtREMARK.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "特别注释:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdRefurbish);
            this.groupBox2.Controls.Add(this.buttonXP1);
            this.groupBox2.Controls.Add(this.cmdCancel);
            this.groupBox2.Controls.Add(this.cmdSPECREMARKDel);
            this.groupBox2.Controls.Add(this.cmdSPECREMARKSave);
            this.groupBox2.Location = new System.Drawing.Point(553, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 245);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(42, 164);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(132, 33);
            this.cmdRefurbish.TabIndex = 71;
            this.cmdRefurbish.Text = "刷  新(F4)";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(42, 117);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(132, 33);
            this.buttonXP1.TabIndex = 70;
            this.buttonXP1.Text = "下一病人(F3)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(42, 207);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(132, 32);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "退  出(ESC)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSPECREMARKDel
            // 
            this.cmdSPECREMARKDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSPECREMARKDel.DefaultScheme = true;
            this.cmdSPECREMARKDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSPECREMARKDel.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdSPECREMARKDel.Hint = "";
            this.cmdSPECREMARKDel.Location = new System.Drawing.Point(38, 69);
            this.cmdSPECREMARKDel.Name = "cmdSPECREMARKDel";
            this.cmdSPECREMARKDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSPECREMARKDel.Size = new System.Drawing.Size(136, 32);
            this.cmdSPECREMARKDel.TabIndex = 6;
            this.cmdSPECREMARKDel.Text = "取消特别注释(F2)";
            this.cmdSPECREMARKDel.Click += new System.EventHandler(this.cmdSPECREMARKDel_Click);
            // 
            // cmdSPECREMARKSave
            // 
            this.cmdSPECREMARKSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSPECREMARKSave.DefaultScheme = true;
            this.cmdSPECREMARKSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSPECREMARKSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdSPECREMARKSave.Hint = "";
            this.cmdSPECREMARKSave.Location = new System.Drawing.Point(38, 19);
            this.cmdSPECREMARKSave.Name = "cmdSPECREMARKSave";
            this.cmdSPECREMARKSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSPECREMARKSave.Size = new System.Drawing.Size(136, 32);
            this.cmdSPECREMARKSave.TabIndex = 5;
            this.cmdSPECREMARKSave.Text = "保存特别注释(F1)";
            this.cmdSPECREMARKSave.Click += new System.EventHandler(this.cmdSPECREMARKSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 329);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.REMARKID_CHR,
            this.REMARKNAME_VCHR,
            this.USERCODE_VCHR,
            this.CHARGECTL,
            this.CHARGECTL_INT});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(771, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "序号";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.Width = 60;
            // 
            // REMARKID_CHR
            // 
            this.REMARKID_CHR.DataPropertyName = "REMARKID_CHR";
            this.REMARKID_CHR.HeaderText = "特别注释ID";
            this.REMARKID_CHR.Name = "REMARKID_CHR";
            this.REMARKID_CHR.ReadOnly = true;
            this.REMARKID_CHR.Visible = false;
            // 
            // REMARKNAME_VCHR
            // 
            this.REMARKNAME_VCHR.DataPropertyName = "REMARKNAME_VCHR";
            this.REMARKNAME_VCHR.HeaderText = "特别注释内容";
            this.REMARKNAME_VCHR.Name = "REMARKNAME_VCHR";
            this.REMARKNAME_VCHR.ReadOnly = true;
            this.REMARKNAME_VCHR.Width = 300;
            // 
            // USERCODE_VCHR
            // 
            this.USERCODE_VCHR.DataPropertyName = "USERCODE_VCHR";
            this.USERCODE_VCHR.HeaderText = "助记码";
            this.USERCODE_VCHR.Name = "USERCODE_VCHR";
            this.USERCODE_VCHR.ReadOnly = true;
            // 
            // CHARGECTL
            // 
            this.CHARGECTL.HeaderText = "CHARGECTL";
            this.CHARGECTL.Name = "CHARGECTL";
            this.CHARGECTL.ReadOnly = true;
            this.CHARGECTL.Visible = false;
            // 
            // CHARGECTL_INT
            // 
            this.CHARGECTL_INT.DataPropertyName = "CHARGECTL_INT";
            this.CHARGECTL_INT.HeaderText = "允许欠费";
            this.CHARGECTL_INT.Name = "CHARGECTL_INT";
            this.CHARGECTL_INT.ReadOnly = true;
            this.CHARGECTL_INT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHARGECTL_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitter1
            // 
            this.splitter1.AnimationDelay = 20;
            this.splitter1.AnimationStep = 20;
            this.splitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.splitter1.ControlToHide = this.ucPatientInfo1;
            this.splitter1.ExpandParentForm = false;
            this.splitter1.Location = new System.Drawing.Point(239, 0);
            this.splitter1.MinExtra = 10;
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 653);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            this.splitter1.UseAnimations = false;
            this.splitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // ucPatientInfo1
            // 
            this.ucPatientInfo1.AutoScroll = true;
            this.ucPatientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.ucPatientInfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucPatientInfo1.IsChanged = false;
            this.ucPatientInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInfo1.Name = "ucPatientInfo1";
            this.ucPatientInfo1.Size = new System.Drawing.Size(239, 653);
            this.ucPatientInfo1.Status = 0;
            this.ucPatientInfo1.TabIndex = 0;
            this.ucPatientInfo1.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.ucPatientInfo1_ZyhChanged);
            this.ucPatientInfo1.CardNOChanged += new com.digitalwave.iCare.gui.HIS.TextCardNOChanged(this.ucPatientInfo1_CardNOChanged);
            // 
            // frmPATSPECREMARK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ucPatientInfo1);
            this.KeyPreview = true;
            this.Name = "frmPATSPECREMARK";
            this.Text = "特注处理";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmPATSPECREMARK_Layout);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPATSPECREMARK_KeyDown);
            this.Load += new System.EventHandler(this.frmPATSPECREMARK_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private com.digitalwave.Utility.Controls.CollapsibleSplitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP cmdCancel;
        internal PinkieControls.ButtonXP cmdSPECREMARKDel;
        internal PinkieControls.ButtonXP cmdSPECREMARKSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP buttonXP1;
        private PinkieControls.ButtonXP cmdRefurbish;
        public System.Windows.Forms.TextBox m_txtREMARK;
        public System.Windows.Forms.TextBox m_txtDes;
        public ucPatientInfo ucPatientInfo1;
        internal System.Windows.Forms.CheckBox m_ckbChargeCtl;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERCODE_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGECTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGECTL_INT;
    }
}