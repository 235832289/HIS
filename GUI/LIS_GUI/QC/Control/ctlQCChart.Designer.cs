namespace com.digitalwave.iCare.gui.LIS.QC.Control
{
    partial class ctlQCChart
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdAnalysis = new PinkieControls.ButtonXP();
            this.m_lsvQCResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_zedChart = new ZedGraph.ZedGraphControl();
            this.m_gpbChartStyle = new System.Windows.Forms.GroupBox();
            this.m_rdbYoudenChart = new System.Windows.Forms.RadioButton();
            this.m_rdbZChart = new System.Windows.Forms.RadioButton();
            this.m_rdbLeveyChart = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_gpbChartStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cmdAnalysis);
            this.panel1.Controls.Add(this.m_lsvQCResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(595, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 538);
            this.panel1.TabIndex = 5;
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(24, 19);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(143, 33);
            this.m_cmdPrint.TabIndex = 10;
            this.m_cmdPrint.Text = "打印预览";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(15, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "分析结果:";
            // 
            // m_cmdAnalysis
            // 
            this.m_cmdAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAnalysis.DefaultScheme = true;
            this.m_cmdAnalysis.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAnalysis.Hint = "";
            this.m_cmdAnalysis.Location = new System.Drawing.Point(24, 58);
            this.m_cmdAnalysis.Name = "m_cmdAnalysis";
            this.m_cmdAnalysis.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAnalysis.Size = new System.Drawing.Size(143, 33);
            this.m_cmdAnalysis.TabIndex = 8;
            this.m_cmdAnalysis.Text = "质控分析";
            this.m_cmdAnalysis.Click += new System.EventHandler(this.m_cmdAnalysis_Click);
            // 
            // m_lsvQCResult
            // 
            this.m_lsvQCResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_lsvQCResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvQCResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvQCResult.ForeColor = System.Drawing.Color.Blue;
            this.m_lsvQCResult.GridLines = true;
            this.m_lsvQCResult.Location = new System.Drawing.Point(15, 119);
            this.m_lsvQCResult.Name = "m_lsvQCResult";
            this.m_lsvQCResult.Size = new System.Drawing.Size(162, 419);
            this.m_lsvQCResult.TabIndex = 6;
            this.m_lsvQCResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvQCResult.View = System.Windows.Forms.View.Details;
            this.m_lsvQCResult.SelectedIndexChanged += new System.EventHandler(this.m_lsvQCResult_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "违反规则";
            this.columnHeader1.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_zedChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 483);
            this.panel2.TabIndex = 6;
            // 
            // m_zedChart
            // 
            this.m_zedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_zedChart.IsAutoScrollRange = false;
            this.m_zedChart.IsEnableHPan = true;
            this.m_zedChart.IsEnableHZoom = true;
            this.m_zedChart.IsEnableVPan = true;
            this.m_zedChart.IsEnableVZoom = true;
            this.m_zedChart.IsPrintFillPage = true;
            this.m_zedChart.IsPrintKeepAspectRatio = true;
            this.m_zedChart.IsScrollY2 = false;
            this.m_zedChart.IsShowContextMenu = true;
            this.m_zedChart.IsShowCopyMessage = true;
            this.m_zedChart.IsShowCursorValues = false;
            this.m_zedChart.IsShowHScrollBar = false;
            this.m_zedChart.IsShowPointValues = true;
            this.m_zedChart.IsShowVScrollBar = false;
            this.m_zedChart.IsZoomOnMouseCenter = false;
            this.m_zedChart.Location = new System.Drawing.Point(0, 0);
            this.m_zedChart.Name = "m_zedChart";
            this.m_zedChart.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.m_zedChart.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.m_zedChart.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.m_zedChart.PointDateFormat = "g";
            this.m_zedChart.PointValueFormat = "G";
            this.m_zedChart.ScrollMaxX = 0;
            this.m_zedChart.ScrollMaxY = 0;
            this.m_zedChart.ScrollMaxY2 = 0;
            this.m_zedChart.ScrollMinX = 0;
            this.m_zedChart.ScrollMinY = 0;
            this.m_zedChart.ScrollMinY2 = 0;
            this.m_zedChart.Size = new System.Drawing.Size(595, 483);
            this.m_zedChart.TabIndex = 6;
            this.m_zedChart.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.m_zedChart.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.m_zedChart.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.m_zedChart.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.m_zedChart.ZoomStepFraction = 0.1;
            // 
            // m_gpbChartStyle
            // 
            this.m_gpbChartStyle.Controls.Add(this.m_rdbYoudenChart);
            this.m_gpbChartStyle.Controls.Add(this.m_rdbZChart);
            this.m_gpbChartStyle.Controls.Add(this.m_rdbLeveyChart);
            this.m_gpbChartStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_gpbChartStyle.Location = new System.Drawing.Point(0, 0);
            this.m_gpbChartStyle.Name = "m_gpbChartStyle";
            this.m_gpbChartStyle.Size = new System.Drawing.Size(595, 55);
            this.m_gpbChartStyle.TabIndex = 7;
            this.m_gpbChartStyle.TabStop = false;
            this.m_gpbChartStyle.Text = "质控图类型选择";
            // 
            // m_rdbYoudenChart
            // 
            this.m_rdbYoudenChart.AutoSize = true;
            this.m_rdbYoudenChart.Location = new System.Drawing.Point(297, 22);
            this.m_rdbYoudenChart.Name = "m_rdbYoudenChart";
            this.m_rdbYoudenChart.Size = new System.Drawing.Size(67, 18);
            this.m_rdbYoudenChart.TabIndex = 2;
            this.m_rdbYoudenChart.Text = "Youden";
            this.m_rdbYoudenChart.UseVisualStyleBackColor = true;
            this.m_rdbYoudenChart.CheckedChanged += new System.EventHandler(this.m_rdbYouDen_CheckedChanged);
            // 
            // m_rdbZChart
            // 
            this.m_rdbZChart.AutoSize = true;
            this.m_rdbZChart.Checked = true;
            this.m_rdbZChart.Location = new System.Drawing.Point(168, 22);
            this.m_rdbZChart.Name = "m_rdbZChart";
            this.m_rdbZChart.Size = new System.Drawing.Size(81, 18);
            this.m_rdbZChart.TabIndex = 1;
            this.m_rdbZChart.TabStop = true;
            this.m_rdbZChart.Text = "Z-分数图";
            this.m_rdbZChart.UseVisualStyleBackColor = true;
            this.m_rdbZChart.CheckedChanged += new System.EventHandler(this.m_rdbZ_CheckedChanged);
            // 
            // m_rdbLeveyChart
            // 
            this.m_rdbLeveyChart.AutoSize = true;
            this.m_rdbLeveyChart.Location = new System.Drawing.Point(27, 22);
            this.m_rdbLeveyChart.Name = "m_rdbLeveyChart";
            this.m_rdbLeveyChart.Size = new System.Drawing.Size(123, 18);
            this.m_rdbLeveyChart.TabIndex = 0;
            this.m_rdbLeveyChart.Text = "Levey-Jennings";
            this.m_rdbLeveyChart.UseVisualStyleBackColor = true;
            this.m_rdbLeveyChart.CheckedChanged += new System.EventHandler(this.m_rdbLevey_CheckedChanged);
            // 
            // ctlQCChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_gpbChartStyle);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ctlQCChart";
            this.Size = new System.Drawing.Size(787, 538);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_gpbChartStyle.ResumeLayout(false);
            this.m_gpbChartStyle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_cmdAnalysis;
        private System.Windows.Forms.ListView m_lsvQCResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox m_gpbChartStyle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RadioButton m_rdbYoudenChart;
        private System.Windows.Forms.RadioButton m_rdbZChart;
        private System.Windows.Forms.RadioButton m_rdbLeveyChart;
        private ZedGraph.ZedGraphControl m_zedChart;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_cmdPrint;

    }
}
