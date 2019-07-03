namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrintLeaveNotice
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
            this.m_crReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_dw = new Sybase.DataWindow.DataWindowControl();
            this.SuspendLayout();
            // 
            // m_crReport
            // 
            this.m_crReport.ActiveViewIndex = -1;
            this.m_crReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_crReport.DisplayGroupTree = false;
            this.m_crReport.DisplayStatusBar = false;
            this.m_crReport.Location = new System.Drawing.Point(12, 12);
            this.m_crReport.Name = "m_crReport";
            this.m_crReport.SelectionFormula = "";
            this.m_crReport.ShowGroupTreeButton = false;
            this.m_crReport.Size = new System.Drawing.Size(77, 30);
            this.m_crReport.TabIndex = 0;
            this.m_crReport.ViewTimeSelectionFormula = "";
            this.m_crReport.Visible = false;
            this.m_crReport.Load += new System.EventHandler(this.m_crReport_Load);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(214, 385);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(96, 32);
            this.m_cmdCancel.TabIndex = 3;
            this.m_cmdCancel.Text = "关闭(Esc)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(85, 385);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(96, 32);
            this.m_cmdPrint.TabIndex = 4;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_dw
            // 
            this.m_dw.DataWindowObject = "d_out_notice";
            this.m_dw.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.m_dw.Location = new System.Drawing.Point(12, 12);
            this.m_dw.Name = "m_dw";
            this.m_dw.Size = new System.Drawing.Size(406, 362);
            this.m_dw.TabIndex = 5;
            this.m_dw.Text = "dataWindowControl1";
            // 
            // frmPrintLeaveNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 432);
            this.Controls.Add(this.m_dw);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_crReport);
            this.MaximizeBox = false;
            this.Name = "frmPrintLeaveNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印出院通知单";
            this.Load += new System.EventHandler(this.frmPrintLeaveNotice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer m_crReport;
        private PinkieControls.ButtonXP m_cmdCancel;
        internal PinkieControls.ButtonXP m_cmdPrint;
        private Sybase.DataWindow.DataWindowControl m_dw;
    }
}