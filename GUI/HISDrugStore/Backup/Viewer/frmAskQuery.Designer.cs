namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAskQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskQuery));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnReSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_rbtOutID = new System.Windows.Forms.RadioButton();
            this.m_rbtInID = new System.Windows.Forms.RadioButton();
            this.m_rbtAskID = new System.Windows.Forms.RadioButton();
            this.m_cboAskDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_datEnd = new System.Windows.Forms.DateTimePicker();
            this.m_datBegin = new System.Windows.Forms.DateTimePicker();
            this.m_cboExportDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtBillId = new System.Windows.Forms.TextBox();
            this.m_txtMedName = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_cboStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_rbtReTime = new System.Windows.Forms.RadioButton();
            this.m_rbtDrug = new System.Windows.Forms.RadioButton();
            this.m_RbtStorage = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnQuery,
            this.toolStripSeparator6,
            this.m_btnReSet,
            this.toolStripSeparator8,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(80, 33);
            this.m_btnQuery.Text = "查询(&F)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
            // 
            // m_btnReSet
            // 
            this.m_btnReSet.AutoSize = false;
            this.m_btnReSet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnReSet.Image = ((System.Drawing.Image)(resources.GetObject("m_btnReSet.Image")));
            this.m_btnReSet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnReSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnReSet.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnReSet.Name = "m_btnReSet";
            this.m_btnReSet.Size = new System.Drawing.Size(80, 32);
            this.m_btnReSet.Text = "清空(&E)";
            this.m_btnReSet.Click += new System.EventHandler(this.m_btnReSet_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(80, 33);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.panel1);
            this.gradientPanel2.Controls.Add(this.m_rbtOutID);
            this.gradientPanel2.Controls.Add(this.m_rbtInID);
            this.gradientPanel2.Controls.Add(this.m_rbtAskID);
            this.gradientPanel2.Controls.Add(this.m_cboAskDept);
            this.gradientPanel2.Controls.Add(this.m_datEnd);
            this.gradientPanel2.Controls.Add(this.m_datBegin);
            this.gradientPanel2.Controls.Add(this.m_cboExportDept);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.m_txtBillId);
            this.gradientPanel2.Controls.Add(this.m_txtMedName);
            this.gradientPanel2.Controls.Add(this.label28);
            this.gradientPanel2.Controls.Add(this.m_cboStatus);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.label4);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(6, 6);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(350, 368);
            this.gradientPanel2.TabIndex = 0;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_rbtOutID
            // 
            this.m_rbtOutID.AutoSize = true;
            this.m_rbtOutID.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtOutID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtOutID.Location = new System.Drawing.Point(3, 169);
            this.m_rbtOutID.Name = "m_rbtOutID";
            this.m_rbtOutID.Size = new System.Drawing.Size(81, 18);
            this.m_rbtOutID.TabIndex = 103;
            this.m_rbtOutID.Text = "出库单号";
            this.m_rbtOutID.UseVisualStyleBackColor = false;
            // 
            // m_rbtInID
            // 
            this.m_rbtInID.AutoSize = true;
            this.m_rbtInID.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtInID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtInID.Location = new System.Drawing.Point(3, 150);
            this.m_rbtInID.Name = "m_rbtInID";
            this.m_rbtInID.Size = new System.Drawing.Size(81, 18);
            this.m_rbtInID.TabIndex = 103;
            this.m_rbtInID.Text = "入库单号";
            this.m_rbtInID.UseVisualStyleBackColor = false;
            // 
            // m_rbtAskID
            // 
            this.m_rbtAskID.AutoSize = true;
            this.m_rbtAskID.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtAskID.Checked = true;
            this.m_rbtAskID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtAskID.Location = new System.Drawing.Point(3, 133);
            this.m_rbtAskID.Name = "m_rbtAskID";
            this.m_rbtAskID.Size = new System.Drawing.Size(81, 18);
            this.m_rbtAskID.TabIndex = 103;
            this.m_rbtAskID.TabStop = true;
            this.m_rbtAskID.Text = "请领单号";
            this.m_rbtAskID.UseVisualStyleBackColor = false;
            // 
            // m_cboAskDept
            // 
            this.m_cboAskDept.Location = new System.Drawing.Point(84, 241);
            this.m_cboAskDept.Name = "m_cboAskDept";
            this.m_cboAskDept.Size = new System.Drawing.Size(241, 22);
            this.m_cboAskDept.TabIndex = 5;
            this.m_cboAskDept.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboAskDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBillId_KeyDown);
            // 
            // m_datEnd
            // 
            this.m_datEnd.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_datEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEnd.Location = new System.Drawing.Point(117, 64);
            this.m_datEnd.Name = "m_datEnd";
            this.m_datEnd.Size = new System.Drawing.Size(208, 23);
            this.m_datEnd.TabIndex = 1;
            // 
            // m_datBegin
            // 
            this.m_datBegin.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_datBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBegin.Location = new System.Drawing.Point(117, 21);
            this.m_datBegin.Name = "m_datBegin";
            this.m_datBegin.Size = new System.Drawing.Size(208, 23);
            this.m_datBegin.TabIndex = 0;
            // 
            // m_cboExportDept
            // 
            this.m_cboExportDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboExportDept.Location = new System.Drawing.Point(84, 286);
            this.m_cboExportDept.Name = "m_cboExportDept";
            this.m_cboExportDept.Size = new System.Drawing.Size(241, 22);
            this.m_cboExportDept.TabIndex = 6;
            this.m_cboExportDept.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboExportDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboExportDept_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 34);
            this.label3.TabIndex = 102;
            this.label3.Text = "出库部门";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBillId
            // 
            this.m_txtBillId.Location = new System.Drawing.Point(84, 150);
            this.m_txtBillId.Name = "m_txtBillId";
            this.m_txtBillId.Size = new System.Drawing.Size(241, 23);
            this.m_txtBillId.TabIndex = 3;
            this.m_txtBillId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBillId_KeyDown);
            // 
            // m_txtMedName
            // 
            this.m_txtMedName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedName.Location = new System.Drawing.Point(84, 104);
            this.m_txtMedName.Name = "m_txtMedName";
            this.m_txtMedName.Size = new System.Drawing.Size(241, 23);
            this.m_txtMedName.TabIndex = 2;
            this.m_txtMedName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedName_KeyDown);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(8, 107);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 16);
            this.label28.TabIndex = 97;
            this.label28.Text = "药品名称";
            // 
            // m_cboStatus
            // 
            this.m_cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStatus.FormattingEnabled = true;
            this.m_cboStatus.Items.AddRange(new object[] {
            "全部",
            "作废",
            "新制",
            "提交",
            "药库审核",
            "药房审核"});
            this.m_cboStatus.Location = new System.Drawing.Point(84, 196);
            this.m_cboStatus.Name = "m_cboStatus";
            this.m_cboStatus.Size = new System.Drawing.Size(241, 22);
            this.m_cboStatus.TabIndex = 4;
            this.m_cboStatus.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBillId_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 34);
            this.label5.TabIndex = 7;
            this.label5.Text = "请领单状态";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "请领部门";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 380);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_rbtReTime
            // 
            this.m_rbtReTime.AutoSize = true;
            this.m_rbtReTime.Checked = true;
            this.m_rbtReTime.Location = new System.Drawing.Point(3, 20);
            this.m_rbtReTime.Name = "m_rbtReTime";
            this.m_rbtReTime.Size = new System.Drawing.Size(109, 18);
            this.m_rbtReTime.TabIndex = 104;
            this.m_rbtReTime.TabStop = true;
            this.m_rbtReTime.Text = "药房请领时间";
            this.m_rbtReTime.UseVisualStyleBackColor = true;
            // 
            // m_rbtDrug
            // 
            this.m_rbtDrug.AutoSize = true;
            this.m_rbtDrug.Location = new System.Drawing.Point(3, 67);
            this.m_rbtDrug.Name = "m_rbtDrug";
            this.m_rbtDrug.Size = new System.Drawing.Size(109, 18);
            this.m_rbtDrug.TabIndex = 105;
            this.m_rbtDrug.Text = "药库审核时间";
            this.m_rbtDrug.UseVisualStyleBackColor = true;
            // 
            // m_RbtStorage
            // 
            this.m_RbtStorage.AutoSize = true;
            this.m_RbtStorage.Location = new System.Drawing.Point(3, 43);
            this.m_RbtStorage.Name = "m_RbtStorage";
            this.m_RbtStorage.Size = new System.Drawing.Size(109, 18);
            this.m_RbtStorage.TabIndex = 106;
            this.m_RbtStorage.Text = "药房审核时间";
            this.m_RbtStorage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_RbtStorage);
            this.panel1.Controls.Add(this.m_rbtReTime);
            this.panel1.Controls.Add(this.m_rbtDrug);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 100);
            this.panel1.TabIndex = 107;
            // 
            // frmAskQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAskQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房请领单查询";
            this.Load += new System.EventHandler(this.frmAskQuery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton m_btnReSet;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal GradientPanel gradientPanel2;
        internal System.Windows.Forms.DateTimePicker m_datEnd;
        internal System.Windows.Forms.DateTimePicker m_datBegin;
        internal exComboBox m_cboExportDept;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtBillId;
        internal System.Windows.Forms.TextBox m_txtMedName;
        internal System.Windows.Forms.Label label28;
        internal System.Windows.Forms.ComboBox m_cboStatus;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal exComboBox m_cboAskDept;
        internal System.Windows.Forms.RadioButton m_rbtOutID;
        internal System.Windows.Forms.RadioButton m_rbtInID;
        internal System.Windows.Forms.RadioButton m_rbtAskID;
        internal System.Windows.Forms.RadioButton m_RbtStorage;
        internal System.Windows.Forms.RadioButton m_rbtDrug;
        internal System.Windows.Forms.RadioButton m_rbtReTime;
        private System.Windows.Forms.Panel panel1;
    }
}