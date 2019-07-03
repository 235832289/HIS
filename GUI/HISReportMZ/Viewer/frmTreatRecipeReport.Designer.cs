namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmTreatRecipeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreatRecipeReport));
            this.dataStore1 = new Sybase.DataWindow.DataStore(this.components);
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.Reports.GradientPanel();
            this.m_ctbEmpList = new com.digitalwave.controls.ctlTextBoxFind();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.m_dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cboMedStore = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_cmdQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExcel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdClose = new System.Windows.Forms.ToolStripButton();
            this.m_dwReport = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvTreatRecipe = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtempno_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtlastname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttotalrecipenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttotaltreatnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttotaltimesnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttotalmedicinenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTreatRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // dataStore1
            // 
            this.dataStore1.DataWindowObject = null;
            this.dataStore1.LibraryList = null;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_ctbEmpList);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.m_dtpBegin);
            this.gradientPanel1.Controls.Add(this.label8);
            this.gradientPanel1.Controls.Add(this.m_dtpEnd);
            this.gradientPanel1.Controls.Add(this.label9);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = true;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1015, 48);
            this.gradientPanel1.TabIndex = 10060;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_ctbEmpList
            // 
            this.m_ctbEmpList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctbEmpList.intHeight = 200;
            this.m_ctbEmpList.IsEnterShow = true;
            this.m_ctbEmpList.isHide = 2;
            this.m_ctbEmpList.isTxt = 1;
            this.m_ctbEmpList.isUpOrDn = 0;
            this.m_ctbEmpList.isValuse = 2;
            this.m_ctbEmpList.Location = new System.Drawing.Point(590, 13);
            this.m_ctbEmpList.m_IsHaveParent = false;
            this.m_ctbEmpList.m_strParentName = "";
            this.m_ctbEmpList.Name = "m_ctbEmpList";
            this.m_ctbEmpList.nextCtl = null;
            this.m_ctbEmpList.Size = new System.Drawing.Size(153, 22);
            this.m_ctbEmpList.TabIndex = 10054;
            this.m_ctbEmpList.txtValuse = "";
            this.m_ctbEmpList.VsLeftOrRight = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(524, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10055;
            this.label2.Text = "配药员工";
            // 
            // m_dtpBegin
            // 
            this.m_dtpBegin.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpBegin.Location = new System.Drawing.Point(80, 12);
            this.m_dtpBegin.Name = "m_dtpBegin";
            this.m_dtpBegin.Size = new System.Drawing.Size(203, 23);
            this.m_dtpBegin.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 10047;
            this.label8.Text = "统计时间：";
            // 
            // m_dtpEnd
            // 
            this.m_dtpEnd.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEnd.Location = new System.Drawing.Point(313, 12);
            this.m_dtpEnd.Name = "m_dtpEnd";
            this.m_dtpEnd.Size = new System.Drawing.Size(205, 23);
            this.m_dtpEnd.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(288, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 10048;
            this.label9.Text = "至";
            // 
            // m_cboMedStore
            // 
            this.m_cboMedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedStore.Location = new System.Drawing.Point(604, 6);
            this.m_cboMedStore.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboMedStore.Name = "m_cboMedStore";
            this.m_cboMedStore.Size = new System.Drawing.Size(166, 22);
            this.m_cboMedStore.TabIndex = 4;
            this.m_cboMedStore.Visible = false;
            this.m_cboMedStore.SelectedValueChanged += new System.EventHandler(this.m_cboMedStore_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(539, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10053;
            this.label6.Text = "药房名称：";
            this.label6.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdQuery,
            this.toolStripSeparator4,
            this.m_btnPreview,
            this.toolStripSeparator2,
            this.m_cmdPrint,
            this.toolStripSeparator1,
            this.m_cmdExcel,
            this.toolStripSeparator3,
            this.m_cmdClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1015, 38);
            this.toolStrip1.TabIndex = 10059;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.AutoSize = false;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdQuery.Image")));
            this.m_cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Size = new System.Drawing.Size(90, 35);
            this.m_cmdQuery.Text = "查 询(&Q)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.AutoSize = false;
            this.m_btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPreview.Image")));
            this.m_btnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPreview.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Size = new System.Drawing.Size(90, 35);
            this.m_btnPreview.Text = "预 览(&V)";
            this.m_btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.AutoSize = false;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrint.Image")));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(90, 35);
            this.m_cmdPrint.Text = "打 印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdExcel
            // 
            this.m_cmdExcel.AutoSize = false;
            this.m_cmdExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExcel.Image")));
            this.m_cmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdExcel.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdExcel.Name = "m_cmdExcel";
            this.m_cmdExcel.Size = new System.Drawing.Size(90, 35);
            this.m_cmdExcel.Text = "导 出(&E)";
            this.m_cmdExcel.Click += new System.EventHandler(this.m_cmdExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AutoSize = false;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdClose.Image")));
            this.m_cmdClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(90, 35);
            this.m_cmdClose.Text = "关 闭(&C)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_dwReport
            // 
            this.m_dwReport.DataWindowObject = "";
            this.m_dwReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwReport.LibraryList = "";
            this.m_dwReport.Location = new System.Drawing.Point(0, 86);
            this.m_dwReport.Name = "m_dwReport";
            this.m_dwReport.Size = new System.Drawing.Size(1015, 456);
            this.m_dwReport.TabIndex = 10061;
            this.m_dwReport.Text = "dataWindowControl1";
            // 
            // m_dgvTreatRecipe
            // 
            this.m_dgvTreatRecipe.AllowUserToAddRows = false;
            this.m_dgvTreatRecipe.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvTreatRecipe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvTreatRecipe.ColumnHeadersHeight = 25;
            this.m_dgvTreatRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvTreatRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtempno_chr,
            this.m_dgvtxtlastname_vchr,
            this.m_dgvtxttotalrecipenum,
            this.m_dgvtxttotaltreatnum,
            this.m_dgvtxttotaltimesnum,
            this.m_dgvtxttotalmedicinenum});
            this.m_dgvTreatRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvTreatRecipe.Location = new System.Drawing.Point(0, 86);
            this.m_dgvTreatRecipe.Name = "m_dgvTreatRecipe";
            this.m_dgvTreatRecipe.ReadOnly = true;
            this.m_dgvTreatRecipe.RowHeadersVisible = false;
            this.m_dgvTreatRecipe.RowTemplate.Height = 23;
            this.m_dgvTreatRecipe.Size = new System.Drawing.Size(1015, 456);
            this.m_dgvTreatRecipe.TabIndex = 10062;
            // 
            // m_dgvtxtempno_chr
            // 
            this.m_dgvtxtempno_chr.DataPropertyName = "empno_chr";
            this.m_dgvtxtempno_chr.HeaderText = "员工工号";
            this.m_dgvtxtempno_chr.Name = "m_dgvtxtempno_chr";
            this.m_dgvtxtempno_chr.ReadOnly = true;
            this.m_dgvtxtempno_chr.Width = 170;
            // 
            // m_dgvtxtlastname_vchr
            // 
            this.m_dgvtxtlastname_vchr.DataPropertyName = "lastname_vchr";
            this.m_dgvtxtlastname_vchr.HeaderText = "员工姓名";
            this.m_dgvtxtlastname_vchr.Name = "m_dgvtxtlastname_vchr";
            this.m_dgvtxtlastname_vchr.ReadOnly = true;
            this.m_dgvtxtlastname_vchr.Width = 170;
            // 
            // m_dgvtxttotalrecipenum
            // 
            this.m_dgvtxttotalrecipenum.DataPropertyName = "totalrecipenum";
            this.m_dgvtxttotalrecipenum.HeaderText = "处方张数";
            this.m_dgvtxttotalrecipenum.Name = "m_dgvtxttotalrecipenum";
            this.m_dgvtxttotalrecipenum.ReadOnly = true;
            this.m_dgvtxttotalrecipenum.Width = 170;
            // 
            // m_dgvtxttotaltreatnum
            // 
            this.m_dgvtxttotaltreatnum.DataPropertyName = "totaltreatnum";
            this.m_dgvtxttotaltreatnum.HeaderText = "药品种数";
            this.m_dgvtxttotaltreatnum.Name = "m_dgvtxttotaltreatnum";
            this.m_dgvtxttotaltreatnum.ReadOnly = true;
            this.m_dgvtxttotaltreatnum.Width = 170;
            // 
            // m_dgvtxttotaltimesnum
            // 
            this.m_dgvtxttotaltimesnum.DataPropertyName = "totaltimesnum";
            this.m_dgvtxttotaltimesnum.HeaderText = "剂数";
            this.m_dgvtxttotaltimesnum.Name = "m_dgvtxttotaltimesnum";
            this.m_dgvtxttotaltimesnum.ReadOnly = true;
            this.m_dgvtxttotaltimesnum.Width = 170;
            // 
            // m_dgvtxttotalmedicinenum
            // 
            this.m_dgvtxttotalmedicinenum.DataPropertyName = "totalmedicinenum";
            this.m_dgvtxttotalmedicinenum.HeaderText = "药品总数";
            this.m_dgvtxttotalmedicinenum.Name = "m_dgvtxttotalmedicinenum";
            this.m_dgvtxttotalmedicinenum.ReadOnly = true;
            this.m_dgvtxttotalmedicinenum.Width = 170;
            // 
            // frmTreatRecipeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 542);
            this.Controls.Add(this.m_dgvTreatRecipe);
            this.Controls.Add(this.m_dwReport);
            this.Controls.Add(this.m_cboMedStore);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTreatRecipeReport";
            this.Text = "门诊药房配药工作量统计报表";
            this.Load += new System.EventHandler(this.frmTreatRecipeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTreatRecipe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sybase.DataWindow.DataStore dataStore1;
        internal com.digitalwave.iCare.gui.HIS.Reports.GradientPanel gradientPanel1;
        internal exComboBox m_cboMedStore;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker m_dtpBegin;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker m_dtpEnd;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_cmdQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_cmdPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel m_cmdExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_cmdClose;
        internal Sybase.DataWindow.DataWindowControl m_dwReport;
        internal com.digitalwave.controls.ctlTextBoxFind m_ctbEmpList;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView m_dgvTreatRecipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaltimesnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtempno_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtlastname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttotalrecipenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttotaltreatnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttotaltimesnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttotalmedicinenum;
    }
}