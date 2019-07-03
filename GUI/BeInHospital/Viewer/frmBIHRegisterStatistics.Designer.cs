namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmBIHRegisterStatistics
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtProtectType = new ControlLibrary.txtListView(this.components);
            this.btnExit = new PinkieControls.ButtonXP();
            this.btnPrintRpt = new PinkieControls.ButtonXP();
            this.btnGenerRpt = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStatDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.crvBIHRegisterStat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_txtProtectType);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPrintRpt);
            this.panel1.Controls.Add(this.btnGenerRpt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtpEnd);
            this.panel1.Controls.Add(this.m_dtpStatDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 61);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(391, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "收费类别：";
            // 
            // m_txtProtectType
            // 
            this.m_txtProtectType.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtProtectType.Location = new System.Drawing.Point(475, 19);
            this.m_txtProtectType.m_blnFocuseShow = true;
            this.m_txtProtectType.m_blnPagination = false;
            this.m_txtProtectType.m_dtbDataSourse = null;
            this.m_txtProtectType.m_intDelayTime = 100;
            this.m_txtProtectType.m_intPageRows = 10;
            this.m_txtProtectType.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtProtectType.m_listViewSize = new System.Drawing.Point(200, 100);
            this.m_txtProtectType.m_strFieldsArr = new string[] {
        "PAYTYPENO_VCHR",
        "PAYTYPENAME_VCHR"};
            this.m_txtProtectType.m_strSaveField = "PAYTYPEID_CHR";
            this.m_txtProtectType.m_strShowField = "PAYTYPENAME_VCHR";
            this.m_txtProtectType.m_strSQL = null;
            this.m_txtProtectType.Name = "m_txtProtectType";
            this.m_txtProtectType.Size = new System.Drawing.Size(131, 23);
            this.m_txtProtectType.TabIndex = 27;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(860, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(98, 36);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrintRpt
            // 
            this.btnPrintRpt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrintRpt.DefaultScheme = true;
            this.btnPrintRpt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintRpt.Enabled = false;
            this.btnPrintRpt.Hint = "";
            this.btnPrintRpt.Location = new System.Drawing.Point(756, 12);
            this.btnPrintRpt.Name = "btnPrintRpt";
            this.btnPrintRpt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintRpt.Size = new System.Drawing.Size(98, 36);
            this.btnPrintRpt.TabIndex = 20;
            this.btnPrintRpt.Text = "打印报表(&P)";
            this.btnPrintRpt.Click += new System.EventHandler(this.btnPrintRpt_Click);
            // 
            // btnGenerRpt
            // 
            this.btnGenerRpt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnGenerRpt.DefaultScheme = true;
            this.btnGenerRpt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGenerRpt.Hint = "";
            this.btnGenerRpt.Location = new System.Drawing.Point(652, 12);
            this.btnGenerRpt.Name = "btnGenerRpt";
            this.btnGenerRpt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnGenerRpt.Size = new System.Drawing.Size(98, 36);
            this.btnGenerRpt.TabIndex = 19;
            this.btnGenerRpt.Text = "生成报表(&D)";
            this.btnGenerRpt.Click += new System.EventHandler(this.btnGenerRpt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(221, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "至";
            // 
            // m_dtpEnd
            // 
            this.m_dtpEnd.Location = new System.Drawing.Point(247, 19);
            this.m_dtpEnd.Name = "m_dtpEnd";
            this.m_dtpEnd.Size = new System.Drawing.Size(128, 23);
            this.m_dtpEnd.TabIndex = 18;
            this.m_dtpEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpEnd_KeyDown);
            // 
            // m_dtpStatDate
            // 
            this.m_dtpStatDate.Location = new System.Drawing.Point(86, 19);
            this.m_dtpStatDate.Name = "m_dtpStatDate";
            this.m_dtpStatDate.Size = new System.Drawing.Size(129, 23);
            this.m_dtpStatDate.TabIndex = 17;
            this.m_dtpStatDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpStatDate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "统计日期：";
            // 
            // crvBIHRegisterStat
            // 
            this.crvBIHRegisterStat.ActiveViewIndex = -1;
            this.crvBIHRegisterStat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBIHRegisterStat.DisplayGroupTree = false;
            this.crvBIHRegisterStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBIHRegisterStat.Location = new System.Drawing.Point(0, 61);
            this.crvBIHRegisterStat.Name = "crvBIHRegisterStat";
            this.crvBIHRegisterStat.SelectionFormula = "";
            this.crvBIHRegisterStat.Size = new System.Drawing.Size(961, 504);
            this.crvBIHRegisterStat.TabIndex = 2;
            this.crvBIHRegisterStat.ViewTimeSelectionFormula = "";
            // 
            // frmBIHRegisterStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 565);
            this.Controls.Add(this.crvBIHRegisterStat);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmBIHRegisterStatistics";
            this.Text = "病人入院单统计表";
            this.Load += new System.EventHandler(this.frmBIHRegisterStatistics_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP btnExit;
        internal  PinkieControls.ButtonXP btnPrintRpt;
        private PinkieControls.ButtonXP btnGenerRpt;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_dtpEnd;
        internal System.Windows.Forms.DateTimePicker m_dtpStatDate;
        private System.Windows.Forms.Label label1;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvBIHRegisterStat;
        private System.Windows.Forms.Label label3;
        internal ControlLibrary.txtListView m_txtProtectType;
    }
}