namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmDiscountStatistic
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.rbDepart = new System.Windows.Forms.RadioButton();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.rbDoctor = new System.Windows.Forms.RadioButton();
            this.m_cboStatType = new System.Windows.Forms.ComboBox();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.m_datEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new PinkieControls.ButtonXP();
            this.m_datBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtwindow = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.gbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lbID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gbGroup);
            this.panel1.Controls.Add(this.m_cboStatType);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.m_datEndTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.m_datBegin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 83);
            this.panel1.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(72, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(133, 23);
            this.txtID.TabIndex = 48;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(74, 55);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(0, 14);
            this.lbID.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "项目编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "项目名称";
            // 
            // gbGroup
            // 
            this.gbGroup.Controls.Add(this.buttonXP2);
            this.gbGroup.Controls.Add(this.rbDepart);
            this.gbGroup.Controls.Add(this.buttonXP1);
            this.gbGroup.Controls.Add(this.rbDoctor);
            this.gbGroup.Location = new System.Drawing.Point(369, -4);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Size = new System.Drawing.Size(246, 51);
            this.gbGroup.TabIndex = 41;
            this.gbGroup.TabStop = false;
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Enabled = false;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(143, 10);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(97, 37);
            this.buttonXP2.TabIndex = 38;
            this.buttonXP2.Text = "选择科室▼";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // rbDepart
            // 
            this.rbDepart.AutoSize = true;
            this.rbDepart.Location = new System.Drawing.Point(125, 24);
            this.rbDepart.Name = "rbDepart";
            this.rbDepart.Size = new System.Drawing.Size(14, 13);
            this.rbDepart.TabIndex = 1;
            this.rbDepart.UseVisualStyleBackColor = true;
            this.rbDepart.CheckedChanged += new System.EventHandler(this.rbDepart_CheckedChanged);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(23, 10);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(97, 37);
            this.buttonXP1.TabIndex = 36;
            this.buttonXP1.Text = "选择医生▼";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // rbDoctor
            // 
            this.rbDoctor.AutoSize = true;
            this.rbDoctor.Checked = true;
            this.rbDoctor.Location = new System.Drawing.Point(5, 24);
            this.rbDoctor.Name = "rbDoctor";
            this.rbDoctor.Size = new System.Drawing.Size(14, 13);
            this.rbDoctor.TabIndex = 0;
            this.rbDoctor.TabStop = true;
            this.rbDoctor.UseVisualStyleBackColor = true;
            this.rbDoctor.CheckedChanged += new System.EventHandler(this.rbDoctor_CheckedChanged);
            // 
            // m_cboStatType
            // 
            this.m_cboStatType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboStatType.FormattingEnabled = true;
            this.m_cboStatType.Items.AddRange(new object[] {
            "按发票时间",
            "按结算时间"});
            this.m_cboStatType.Location = new System.Drawing.Point(218, 9);
            this.m_cboStatType.Name = "m_cboStatType";
            this.m_cboStatType.Size = new System.Drawing.Size(133, 22);
            this.m_cboStatType.TabIndex = 37;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(713, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(72, 37);
            this.btnPreview.TabIndex = 25;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(870, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(72, 37);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(635, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(72, 37);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.Text = "统计(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(792, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(72, 37);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // m_datEndTime
            // 
            this.m_datEndTime.CustomFormat = "yyyy年MM月dd日";
            this.m_datEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.m_datEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEndTime.Location = new System.Drawing.Point(537, 50);
            this.m_datEndTime.Name = "m_datEndTime";
            this.m_datEndTime.Size = new System.Drawing.Size(134, 24);
            this.m_datEndTime.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(512, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "到";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(949, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(72, 37);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // m_datBegin
            // 
            this.m_datBegin.CustomFormat = "yyyy年MM月dd日";
            this.m_datBegin.Font = new System.Drawing.Font("宋体", 11F);
            this.m_datBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBegin.Location = new System.Drawing.Point(376, 50);
            this.m_datBegin.Name = "m_datBegin";
            this.m_datBegin.Size = new System.Drawing.Size(133, 24);
            this.m_datBegin.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(312, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "日期：从";
            // 
            // dtwindow
            // 
            this.dtwindow.DataWindowObject = "";
            this.dtwindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtwindow.LibraryList = "";
            this.dtwindow.Location = new System.Drawing.Point(0, 83);
            this.dtwindow.Name = "dtwindow";
            this.dtwindow.Size = new System.Drawing.Size(1028, 459);
            this.dtwindow.TabIndex = 3;
            this.dtwindow.Text = "dataWindowControl1";
            // 
            // frmDiscountStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 542);
            this.Controls.Add(this.dtwindow);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmDiscountStatistic";
            this.Text = "打折项目统计";
            this.Load += new System.EventHandler(this.frmDiscountStatistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbGroup.ResumeLayout(false);
            this.gbGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbGroup;
        internal PinkieControls.ButtonXP buttonXP2;
        private System.Windows.Forms.RadioButton rbDepart;
        internal PinkieControls.ButtonXP buttonXP1;
        private System.Windows.Forms.RadioButton rbDoctor;
        internal System.Windows.Forms.ComboBox m_cboStatType;
        internal PinkieControls.ButtonXP btnPreview;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnSelect;
        internal PinkieControls.ButtonXP btnExport;
        internal System.Windows.Forms.DateTimePicker m_datEndTime;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP btnClose;
        internal System.Windows.Forms.DateTimePicker m_datBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        internal Sybase.DataWindow.DataWindowControl dtwindow;
        internal System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtID;
    }
}