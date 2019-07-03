namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCBatchManager
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
            this.m_pnlBottom = new System.Windows.Forms.Panel();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_cmdDeleteQCBatch = new PinkieControls.ButtonXP();
            this.m_cmdConcentrationSet = new PinkieControls.ButtonXP();
            this.m_cmdQCBatchSet = new PinkieControls.ButtonXP();
            this.m_cmdNewQCBatch = new PinkieControls.ButtonXP();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.splitContainerWork = new System.Windows.Forms.SplitContainer();
            this.m_tabList = new System.Windows.Forms.TabControl();
            this.m_tbpQCBatchList = new System.Windows.Forms.TabPage();
            this.m_lsvQCBatch = new System.Windows.Forms.ListView();
            this.chQCSampleLotNO = new System.Windows.Forms.ColumnHeader();
            this.chCheckItem = new System.Windows.Forms.ColumnHeader();
            this.chDevice = new System.Windows.Forms.ColumnHeader();
            this.chWorkGroup = new System.Windows.Forms.ColumnHeader();
            this.chBeginDate = new System.Windows.Forms.ColumnHeader();
            this.chEndDate = new System.Windows.Forms.ColumnHeader();
            this.chQCBatchSeq = new System.Windows.Forms.ColumnHeader();
            this.m_tbpQuery = new System.Windows.Forms.TabPage();
            this.m_ctlQCBatchQuery = new com.digitalwave.iCare.gui.LIS.ctlQCBatchQuery();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbAppend = new System.Windows.Forms.RadioButton();
            this.m_rdbReplace = new System.Windows.Forms.RadioButton();
            this.m_ctlDateSelector = new com.digitalwave.iCare.gui.LIS.ctlDateSelector();
            this.m_tabWork = new System.Windows.Forms.TabControl();
            this.tabQCData = new System.Windows.Forms.TabPage();
            this.m_ctlDataEditor = new com.digitalwave.iCare.gui.LIS.ctlQCDataEditor();
            this.tabDiagram = new System.Windows.Forms.TabPage();
            this.m_ctlChart = new com.digitalwave.iCare.gui.LIS.QC.Control.ctlQCChart();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.m_ctlQCBatchReportEditor = new com.digitalwave.iCare.gui.LIS.ctlQCBatchReportEditor();
            this.m_pnlBottom.SuspendLayout();
            this.splitContainerWork.Panel1.SuspendLayout();
            this.splitContainerWork.Panel2.SuspendLayout();
            this.splitContainerWork.SuspendLayout();
            this.m_tabList.SuspendLayout();
            this.m_tbpQCBatchList.SuspendLayout();
            this.m_tbpQuery.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_tabWork.SuspendLayout();
            this.tabQCData.SuspendLayout();
            this.tabDiagram.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBottom
            // 
            this.m_pnlBottom.Controls.Add(this.btnExit);
            this.m_pnlBottom.Controls.Add(this.m_cmdDeleteQCBatch);
            this.m_pnlBottom.Controls.Add(this.m_cmdConcentrationSet);
            this.m_pnlBottom.Controls.Add(this.m_cmdQCBatchSet);
            this.m_pnlBottom.Controls.Add(this.m_cmdNewQCBatch);
            this.m_pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnlBottom.Location = new System.Drawing.Point(0, 399);
            this.m_pnlBottom.Name = "m_pnlBottom";
            this.m_pnlBottom.Size = new System.Drawing.Size(676, 70);
            this.m_pnlBottom.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(556, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(96, 33);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_cmdDeleteQCBatch
            // 
            this.m_cmdDeleteQCBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDeleteQCBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDeleteQCBatch.DefaultScheme = true;
            this.m_cmdDeleteQCBatch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdDeleteQCBatch.Hint = "";
            this.m_cmdDeleteQCBatch.Location = new System.Drawing.Point(448, 16);
            this.m_cmdDeleteQCBatch.Name = "m_cmdDeleteQCBatch";
            this.m_cmdDeleteQCBatch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDeleteQCBatch.Size = new System.Drawing.Size(96, 33);
            this.m_cmdDeleteQCBatch.TabIndex = 8;
            this.m_cmdDeleteQCBatch.Text = "删除";
            this.m_cmdDeleteQCBatch.Click += new System.EventHandler(this.m_cmdDeleteQCBatch_Click);
            // 
            // m_cmdConcentrationSet
            // 
            this.m_cmdConcentrationSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdConcentrationSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdConcentrationSet.DefaultScheme = true;
            this.m_cmdConcentrationSet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdConcentrationSet.Hint = "";
            this.m_cmdConcentrationSet.Location = new System.Drawing.Point(340, 16);
            this.m_cmdConcentrationSet.Name = "m_cmdConcentrationSet";
            this.m_cmdConcentrationSet.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdConcentrationSet.Size = new System.Drawing.Size(96, 33);
            this.m_cmdConcentrationSet.TabIndex = 7;
            this.m_cmdConcentrationSet.Text = "浓度设置";
            this.m_cmdConcentrationSet.Click += new System.EventHandler(this.m_cmdConcentrationSet_Click);
            // 
            // m_cmdQCBatchSet
            // 
            this.m_cmdQCBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdQCBatchSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQCBatchSet.DefaultScheme = true;
            this.m_cmdQCBatchSet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdQCBatchSet.Hint = "";
            this.m_cmdQCBatchSet.Location = new System.Drawing.Point(232, 16);
            this.m_cmdQCBatchSet.Name = "m_cmdQCBatchSet";
            this.m_cmdQCBatchSet.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQCBatchSet.Size = new System.Drawing.Size(96, 33);
            this.m_cmdQCBatchSet.TabIndex = 6;
            this.m_cmdQCBatchSet.Text = "常规设置";
            this.m_cmdQCBatchSet.Click += new System.EventHandler(this.m_cmdQCBatchSet_Click);
            // 
            // m_cmdNewQCBatch
            // 
            this.m_cmdNewQCBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdNewQCBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdNewQCBatch.DefaultScheme = true;
            this.m_cmdNewQCBatch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdNewQCBatch.Hint = "";
            this.m_cmdNewQCBatch.Location = new System.Drawing.Point(124, 16);
            this.m_cmdNewQCBatch.Name = "m_cmdNewQCBatch";
            this.m_cmdNewQCBatch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNewQCBatch.Size = new System.Drawing.Size(96, 33);
            this.m_cmdNewQCBatch.TabIndex = 5;
            this.m_cmdNewQCBatch.Text = "新增";
            this.m_cmdNewQCBatch.Click += new System.EventHandler(this.m_cmdNewQCBatch_Click);
            // 
            // pnlHead
            // 
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(676, 8);
            this.pnlHead.TabIndex = 1;
            // 
            // splitContainerWork
            // 
            this.splitContainerWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWork.Location = new System.Drawing.Point(0, 8);
            this.splitContainerWork.Name = "splitContainerWork";
            // 
            // splitContainerWork.Panel1
            // 
            this.splitContainerWork.Panel1.Controls.Add(this.m_tabList);
            // 
            // splitContainerWork.Panel2
            // 
            this.splitContainerWork.Panel2.Controls.Add(this.m_ctlDateSelector);
            this.splitContainerWork.Panel2.Controls.Add(this.m_tabWork);
            this.splitContainerWork.Size = new System.Drawing.Size(676, 391);
            this.splitContainerWork.SplitterDistance = 187;
            this.splitContainerWork.SplitterWidth = 3;
            this.splitContainerWork.TabIndex = 2;
            // 
            // m_tabList
            // 
            this.m_tabList.Controls.Add(this.m_tbpQCBatchList);
            this.m_tabList.Controls.Add(this.m_tbpQuery);
            this.m_tabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabList.Location = new System.Drawing.Point(0, 0);
            this.m_tabList.Name = "m_tabList";
            this.m_tabList.SelectedIndex = 0;
            this.m_tabList.Size = new System.Drawing.Size(187, 391);
            this.m_tabList.TabIndex = 0;
            // 
            // m_tbpQCBatchList
            // 
            this.m_tbpQCBatchList.Controls.Add(this.m_lsvQCBatch);
            this.m_tbpQCBatchList.Location = new System.Drawing.Point(4, 23);
            this.m_tbpQCBatchList.Name = "m_tbpQCBatchList";
            this.m_tbpQCBatchList.Padding = new System.Windows.Forms.Padding(3);
            this.m_tbpQCBatchList.Size = new System.Drawing.Size(179, 364);
            this.m_tbpQCBatchList.TabIndex = 0;
            this.m_tbpQCBatchList.Text = "列表";
            this.m_tbpQCBatchList.UseVisualStyleBackColor = true;
            // 
            // m_lsvQCBatch
            // 
            this.m_lsvQCBatch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQCSampleLotNO,
            this.chCheckItem,
            this.chDevice,
            this.chWorkGroup,
            this.chBeginDate,
            this.chEndDate,
            this.chQCBatchSeq});
            this.m_lsvQCBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvQCBatch.FullRowSelect = true;
            this.m_lsvQCBatch.GridLines = true;
            this.m_lsvQCBatch.HideSelection = false;
            this.m_lsvQCBatch.Location = new System.Drawing.Point(3, 3);
            this.m_lsvQCBatch.MultiSelect = false;
            this.m_lsvQCBatch.Name = "m_lsvQCBatch";
            this.m_lsvQCBatch.Size = new System.Drawing.Size(173, 358);
            this.m_lsvQCBatch.TabIndex = 1;
            this.m_lsvQCBatch.UseCompatibleStateImageBehavior = false;
            this.m_lsvQCBatch.View = System.Windows.Forms.View.Details;
            this.m_lsvQCBatch.SelectedIndexChanged += new System.EventHandler(this.m_lsvQCBatch_SelectedIndexChanged);
            // 
            // chQCSampleLotNO
            // 
            this.chQCSampleLotNO.Text = "质控品批号";
            this.chQCSampleLotNO.Width = 96;
            // 
            // chCheckItem
            // 
            this.chCheckItem.Text = "质控项目";
            this.chCheckItem.Width = 86;
            // 
            // chDevice
            // 
            this.chDevice.Text = "仪器";
            this.chDevice.Width = 86;
            // 
            // chWorkGroup
            // 
            this.chWorkGroup.Text = "工作组";
            // 
            // chBeginDate
            // 
            this.chBeginDate.Text = "开始时间";
            this.chBeginDate.Width = 72;
            // 
            // chEndDate
            // 
            this.chEndDate.Text = "结束时间";
            this.chEndDate.Width = 70;
            // 
            // chQCBatchSeq
            // 
            this.chQCBatchSeq.Text = "质控批序号";
            this.chQCBatchSeq.Width = 84;
            // 
            // m_tbpQuery
            // 
            this.m_tbpQuery.Controls.Add(this.m_ctlQCBatchQuery);
            this.m_tbpQuery.Controls.Add(this.panel2);
            this.m_tbpQuery.Location = new System.Drawing.Point(4, 21);
            this.m_tbpQuery.Name = "m_tbpQuery";
            this.m_tbpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.m_tbpQuery.Size = new System.Drawing.Size(179, 366);
            this.m_tbpQuery.TabIndex = 1;
            this.m_tbpQuery.Text = "查询";
            this.m_tbpQuery.UseVisualStyleBackColor = true;
            // 
            // m_ctlQCBatchQuery
            // 
            this.m_ctlQCBatchQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ctlQCBatchQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlQCBatchQuery.Location = new System.Drawing.Point(3, 52);
            this.m_ctlQCBatchQuery.Name = "m_ctlQCBatchQuery";
            this.m_ctlQCBatchQuery.Size = new System.Drawing.Size(173, 201);
            this.m_ctlQCBatchQuery.TabIndex = 0;
            this.m_ctlQCBatchQuery.QuerySucceed += new com.digitalwave.iCare.gui.LIS.ctlQCBatchQuery.QuerySucceedEventHandler(this.m_ctlQCBatchQuery_QuerySucceed);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 49);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdbAppend);
            this.groupBox1.Controls.Add(this.m_rdbReplace);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_rdbAppend
            // 
            this.m_rdbAppend.AutoSize = true;
            this.m_rdbAppend.Location = new System.Drawing.Point(88, 20);
            this.m_rdbAppend.Name = "m_rdbAppend";
            this.m_rdbAppend.Size = new System.Drawing.Size(53, 18);
            this.m_rdbAppend.TabIndex = 1;
            this.m_rdbAppend.Text = "追加";
            this.m_rdbAppend.UseVisualStyleBackColor = true;
            // 
            // m_rdbReplace
            // 
            this.m_rdbReplace.AutoSize = true;
            this.m_rdbReplace.Checked = true;
            this.m_rdbReplace.Location = new System.Drawing.Point(20, 20);
            this.m_rdbReplace.Name = "m_rdbReplace";
            this.m_rdbReplace.Size = new System.Drawing.Size(53, 18);
            this.m_rdbReplace.TabIndex = 0;
            this.m_rdbReplace.TabStop = true;
            this.m_rdbReplace.Text = "取代";
            this.m_rdbReplace.UseVisualStyleBackColor = true;
            // 
            // m_ctlDateSelector
            // 
            this.m_ctlDateSelector.DateSelectStyle = com.digitalwave.iCare.gui.LIS.ctlDateSelector.SelectStyle.MonthStyle;
            this.m_ctlDateSelector.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlDateSelector.Location = new System.Drawing.Point(212, 0);
            this.m_ctlDateSelector.Name = "m_ctlDateSelector";
            this.m_ctlDateSelector.Size = new System.Drawing.Size(204, 20);
            this.m_ctlDateSelector.TabIndex = 11;
            this.m_ctlDateSelector.ValueChanged += new System.EventHandler(this.m_ctlDateSelector_ValueChanged);
            // 
            // m_tabWork
            // 
            this.m_tabWork.Controls.Add(this.tabQCData);
            this.m_tabWork.Controls.Add(this.tabDiagram);
            this.m_tabWork.Controls.Add(this.tabReport);
            this.m_tabWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabWork.Location = new System.Drawing.Point(0, 0);
            this.m_tabWork.Name = "m_tabWork";
            this.m_tabWork.SelectedIndex = 0;
            this.m_tabWork.Size = new System.Drawing.Size(486, 391);
            this.m_tabWork.TabIndex = 0;
            // 
            // tabQCData
            // 
            this.tabQCData.Controls.Add(this.m_ctlDataEditor);
            this.tabQCData.Location = new System.Drawing.Point(4, 23);
            this.tabQCData.Name = "tabQCData";
            this.tabQCData.Padding = new System.Windows.Forms.Padding(3);
            this.tabQCData.Size = new System.Drawing.Size(478, 364);
            this.tabQCData.TabIndex = 0;
            this.tabQCData.Text = "质控数据";
            this.tabQCData.UseVisualStyleBackColor = true;
            // 
            // m_ctlDataEditor
            // 
            this.m_ctlDataEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlDataEditor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlDataEditor.Location = new System.Drawing.Point(3, 3);
            this.m_ctlDataEditor.Name = "m_ctlDataEditor";
            this.m_ctlDataEditor.Size = new System.Drawing.Size(472, 358);
            this.m_ctlDataEditor.TabIndex = 0;
            // 
            // tabDiagram
            // 
            this.tabDiagram.Controls.Add(this.m_ctlChart);
            this.tabDiagram.Location = new System.Drawing.Point(4, 21);
            this.tabDiagram.Name = "tabDiagram";
            this.tabDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagram.Size = new System.Drawing.Size(478, 366);
            this.tabDiagram.TabIndex = 1;
            this.tabDiagram.Text = "质控图";
            this.tabDiagram.UseVisualStyleBackColor = true;
            // 
            // m_ctlChart
            // 
            this.m_ctlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlChart.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlChart.Location = new System.Drawing.Point(3, 3);
            this.m_ctlChart.Name = "m_ctlChart";
            this.m_ctlChart.Size = new System.Drawing.Size(472, 360);
            this.m_ctlChart.TabIndex = 0;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.m_ctlQCBatchReportEditor);
            this.tabReport.Location = new System.Drawing.Point(4, 21);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(478, 366);
            this.tabReport.TabIndex = 2;
            this.tabReport.Text = "质控报告";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // m_ctlQCBatchReportEditor
            // 
            this.m_ctlQCBatchReportEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlQCBatchReportEditor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlQCBatchReportEditor.Location = new System.Drawing.Point(3, 3);
            this.m_ctlQCBatchReportEditor.Name = "m_ctlQCBatchReportEditor";
            this.m_ctlQCBatchReportEditor.Size = new System.Drawing.Size(472, 360);
            this.m_ctlQCBatchReportEditor.TabIndex = 0;
            // 
            // frmQCBatchManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 469);
            this.Controls.Add(this.splitContainerWork);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.m_pnlBottom);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmQCBatchManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控批管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.m_pnlBottom.ResumeLayout(false);
            this.splitContainerWork.Panel1.ResumeLayout(false);
            this.splitContainerWork.Panel2.ResumeLayout(false);
            this.splitContainerWork.ResumeLayout(false);
            this.m_tabList.ResumeLayout(false);
            this.m_tbpQCBatchList.ResumeLayout(false);
            this.m_tbpQuery.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_tabWork.ResumeLayout(false);
            this.tabQCData.ResumeLayout(false);
            this.tabDiagram.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlBottom;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.SplitContainer splitContainerWork;
        private System.Windows.Forms.TabControl m_tabList;
        private System.Windows.Forms.TabPage m_tbpQCBatchList;
        private System.Windows.Forms.TabPage m_tbpQuery;
        private System.Windows.Forms.TabControl m_tabWork;
        private System.Windows.Forms.TabPage tabQCData;
        private System.Windows.Forms.TabPage tabDiagram;
        private System.Windows.Forms.TabPage tabReport;
        private PinkieControls.ButtonXP m_cmdDeleteQCBatch;
        private PinkieControls.ButtonXP m_cmdConcentrationSet;
        private PinkieControls.ButtonXP m_cmdQCBatchSet;
        private PinkieControls.ButtonXP m_cmdNewQCBatch;
        private System.Windows.Forms.ListView m_lsvQCBatch;
        private System.Windows.Forms.ColumnHeader chCheckItem;
        private System.Windows.Forms.ColumnHeader chQCSampleLotNO;
        private System.Windows.Forms.ColumnHeader chDevice;
        private System.Windows.Forms.ColumnHeader chWorkGroup;
        private System.Windows.Forms.ColumnHeader chBeginDate;
        private System.Windows.Forms.ColumnHeader chEndDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rdbAppend;
        private System.Windows.Forms.RadioButton m_rdbReplace;
        private System.Windows.Forms.ColumnHeader chQCBatchSeq;
        private ctlDateSelector m_ctlDateSelector;
        private ctlQCBatchQuery m_ctlQCBatchQuery;
        private ctlQCBatchReportEditor m_ctlQCBatchReportEditor;
        private ctlQCDataEditor m_ctlDataEditor;
        private com.digitalwave.iCare.gui.LIS.QC.Control.ctlQCChart m_ctlChart;
        private PinkieControls.ButtonXP btnExit;
    }
}