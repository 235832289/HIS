namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmReport_DoctorEarningGrouping
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
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.m_txtChoicegroup = new com.digitalwave.controls.ctlFindTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpBeginDat = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dw_doctorearinggrouping = new Sybase.DataWindow.DataWindowControl();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonXP3);
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.m_txtChoicegroup);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.m_cmdQuery);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dtpBeginDat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtpEndDat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 54);
            this.panel1.TabIndex = 0;
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(779, 11);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(76, 31);
            this.buttonXP2.TabIndex = 75;
            this.buttonXP2.Text = "预览(&V)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // m_txtChoicegroup
            // 
            this.m_txtChoicegroup.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtChoicegroup.Location = new System.Drawing.Point(88, 15);
            this.m_txtChoicegroup.Name = "m_txtChoicegroup";
            this.m_txtChoicegroup.Size = new System.Drawing.Size(105, 23);
            this.m_txtChoicegroup.TabIndex = 74;
            this.m_txtChoicegroup.DoubleClick += new System.EventHandler(this.m_txtChoicegroup_DoubleClick);
            this.m_txtChoicegroup.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtChoicegroup_m_evtFindItem);
            this.m_txtChoicegroup.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtChoicegroup_m_evtInitListView);
            this.m_txtChoicegroup.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtChoicegroup_m_evtSelectItem);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 66;
            this.label4.Text = "专业组名称：";
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(942, 11);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(76, 31);
            this.buttonXP1.TabIndex = 65;
            this.buttonXP1.Text = "退出(&X)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(699, 11);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(76, 31);
            this.m_cmdPrint.TabIndex = 64;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(616, 11);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(78, 31);
            this.m_cmdQuery.TabIndex = 63;
            this.m_cmdQuery.Text = "查询(&F)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(209, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 59;
            this.label1.Text = "统计时间:";
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpBeginDat.Location = new System.Drawing.Point(318, 15);
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(124, 23);
            this.m_dtpBeginDat.TabIndex = 58;
            this.m_dtpBeginDat.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(281, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 60;
            this.label2.Text = "开始";
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpEndDat.Location = new System.Drawing.Point(468, 15);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(125, 23);
            this.m_dtpEndDat.TabIndex = 61;
            this.m_dtpEndDat.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(445, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 62;
            this.label3.Text = "至";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dw_doctorearinggrouping);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 540);
            this.panel2.TabIndex = 1;
            // 
            // dw_doctorearinggrouping
            // 
            this.dw_doctorearinggrouping.DataWindowObject = "";
            this.dw_doctorearinggrouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_doctorearinggrouping.LibraryList = "";
            this.dw_doctorearinggrouping.Location = new System.Drawing.Point(0, 0);
            this.dw_doctorearinggrouping.Name = "dw_doctorearinggrouping";
            this.dw_doctorearinggrouping.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_doctorearinggrouping.Size = new System.Drawing.Size(1028, 540);
            this.dw_doctorearinggrouping.TabIndex = 0;
            this.dw_doctorearinggrouping.Text = "dataWindowControl1";
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(860, 12);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(77, 30);
            this.buttonXP3.TabIndex = 76;
            this.buttonXP3.Text = "导出(&E)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // frmReport_DoctorEarningGrouping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 594);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmReport_DoctorEarningGrouping";
            this.Text = "按组统计医生挂号费及诊金汇总表";
            this.Load += new System.EventHandler(this.frmReport_DoctorEarningGrouping_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public PinkieControls.ButtonXP buttonXP1;
        public PinkieControls.ButtonXP m_cmdPrint;
        public PinkieControls.ButtonXP m_cmdQuery;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDat;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal Sybase.DataWindow.DataWindowControl dw_doctorearinggrouping;
        internal com.digitalwave.controls.ctlFindTextBox m_txtChoicegroup;
        public PinkieControls.ButtonXP buttonXP2;
        public PinkieControls.ButtonXP buttonXP3;
    }
}