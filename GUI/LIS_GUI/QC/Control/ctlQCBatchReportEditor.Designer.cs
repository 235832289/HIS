namespace com.digitalwave.iCare.gui.LIS
{
    partial class ctlQCBatchReportEditor
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdPreview = new PinkieControls.ButtonXP();
            this.m_cmdModify = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_lsvReport = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.m_cmdPreview);
            this.panel1.Controls.Add(this.m_cmdModify);
            this.panel1.Controls.Add(this.m_cmdDelete);
            this.panel1.Controls.Add(this.m_cmdNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(471, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 452);
            this.panel1.TabIndex = 0;
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(36, 204);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(96, 33);
            this.m_cmdPrint.TabIndex = 4;
            this.m_cmdPrint.Text = "打印";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdPreview
            // 
            this.m_cmdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPreview.DefaultScheme = true;
            this.m_cmdPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdPreview.Hint = "";
            this.m_cmdPreview.Location = new System.Drawing.Point(36, 160);
            this.m_cmdPreview.Name = "m_cmdPreview";
            this.m_cmdPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPreview.Size = new System.Drawing.Size(96, 33);
            this.m_cmdPreview.TabIndex = 3;
            this.m_cmdPreview.Text = "预览";
            this.m_cmdPreview.Click += new System.EventHandler(this.m_cmdPreview_Click);
            // 
            // m_cmdModify
            // 
            this.m_cmdModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModify.DefaultScheme = true;
            this.m_cmdModify.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdModify.Hint = "";
            this.m_cmdModify.Location = new System.Drawing.Point(36, 116);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModify.Size = new System.Drawing.Size(96, 33);
            this.m_cmdModify.TabIndex = 2;
            this.m_cmdModify.Text = "修改";
            this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(36, 68);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(96, 33);
            this.m_cmdDelete.TabIndex = 1;
            this.m_cmdDelete.Text = "删除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(36, 20);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(96, 33);
            this.m_cmdNew.TabIndex = 0;
            this.m_cmdNew.Text = "新增";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // m_lsvReport
            // 
            this.m_lsvReport.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.m_lsvReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvReport.FullRowSelect = true;
            this.m_lsvReport.GridLines = true;
            this.m_lsvReport.HideSelection = false;
            this.m_lsvReport.Location = new System.Drawing.Point(0, 0);
            this.m_lsvReport.MultiSelect = false;
            this.m_lsvReport.Name = "m_lsvReport";
            this.m_lsvReport.Size = new System.Drawing.Size(471, 452);
            this.m_lsvReport.TabIndex = 3;
            this.m_lsvReport.UseCompatibleStateImageBehavior = false;
            this.m_lsvReport.View = System.Windows.Forms.View.Details;
            this.m_lsvReport.ItemActivate += new System.EventHandler(this.m_lsvReport_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "报告日期";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "质控状态";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "违反规则";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "报告人员";
            this.columnHeader4.Width = 118;
            // 
            // ctlQCBatchReportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lsvReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ctlQCBatchReportEditor";
            this.Size = new System.Drawing.Size(638, 452);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView m_lsvReport;
        private PinkieControls.ButtonXP m_cmdNew;
        private PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private PinkieControls.ButtonXP m_cmdPreview;
        private PinkieControls.ButtonXP m_cmdModify;
        private PinkieControls.ButtonXP m_cmdPrint;
    }
}
