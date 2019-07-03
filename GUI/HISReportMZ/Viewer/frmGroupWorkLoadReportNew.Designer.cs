namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmGroupWorkLoadReportNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupWorkLoadReportNew));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.btExcel = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.btPrint = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_datEnd = new System.Windows.Forms.DateTimePicker();
            this.btOK = new PinkieControls.ButtonXP();
            this.m_datBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dwShow = new Sybase.DataWindow.DataWindowControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.btExcel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_cboDept);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.m_cboCheckMan);
            this.groupBox1.Controls.Add(this.m_datEnd);
            this.groupBox1.Controls.Add(this.btOK);
            this.groupBox1.Controls.Add(this.m_datBegin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 59);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // buttonXP1
            // 
            this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(774, 18);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(80, 32);
            this.buttonXP1.TabIndex = 72;
            this.buttonXP1.Text = "预览(&V)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(943, 18);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(80, 32);
            this.btExcel.TabIndex = 58;
            this.btExcel.Text = "导出(&E)";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 71;
            this.label4.Text = "科室:";
            // 
            // m_cboDept
            // 
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.Location = new System.Drawing.Point(564, 23);
            this.m_cboDept.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.Size = new System.Drawing.Size(118, 22);
            this.m_cboDept.TabIndex = 68;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(859, 18);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(80, 32);
            this.btPrint.TabIndex = 66;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(407, 23);
            this.m_cboCheckMan.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(103, 22);
            this.m_cboCheckMan.TabIndex = 69;
            // 
            // m_datEnd
            // 
            this.m_datEnd.CustomFormat = "yyyy年MM月dd日";
            this.m_datEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEnd.Location = new System.Drawing.Point(221, 23);
            this.m_datEnd.Name = "m_datEnd";
            this.m_datEnd.Size = new System.Drawing.Size(122, 23);
            this.m_datEnd.TabIndex = 64;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(689, 18);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(80, 32);
            this.btOK.TabIndex = 58;
            this.btOK.Text = "检索(&S)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // m_datBegin
            // 
            this.m_datBegin.CustomFormat = "yyyy年MM月dd日";
            this.m_datBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBegin.Location = new System.Drawing.Point(75, 22);
            this.m_datBegin.Name = "m_datBegin";
            this.m_datBegin.Size = new System.Drawing.Size(121, 23);
            this.m_datBegin.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "统计日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 70;
            this.label3.Text = "收费员:";
            // 
            // m_dwShow
            // 
            this.m_dwShow.DataWindowObject = "";
            this.m_dwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwShow.LibraryList = "";
            this.m_dwShow.Location = new System.Drawing.Point(0, 59);
            this.m_dwShow.Name = "m_dwShow";
            this.m_dwShow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwShow.Size = new System.Drawing.Size(1028, 438);
            this.m_dwShow.TabIndex = 64;
            this.m_dwShow.Text = "dataWindowControl1";
            // 
            // frmGroupWorkLoadReportNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 497);
            this.Controls.Add(this.m_dwShow);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGroupWorkLoadReportNew";
            this.Text = "门诊专业组收入统计报表";
            this.Load += new System.EventHandler(this.frmGroupWorkLoadReportNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        internal exComboBox m_cboDept;
        internal PinkieControls.ButtonXP btPrint;
        internal exComboBox m_cboCheckMan;
        internal System.Windows.Forms.DateTimePicker m_datEnd;
        internal PinkieControls.ButtonXP btExcel;
        internal PinkieControls.ButtonXP btOK;
        internal System.Windows.Forms.DateTimePicker m_datBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP buttonXP1;
        public Sybase.DataWindow.DataWindowControl m_dwShow;

    }
}