namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRptEveryDayBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptEveryDayBill));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBedID = new System.Windows.Forms.TextBox();
            this.btnExport = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.m_txtAREAID = new ControlLibrary.txtListView(this.components);
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnStat = new PinkieControls.ButtonXP();
            this.dteRq = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvBed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.rdoZyh = new System.Windows.Forms.RadioButton();
            this.rdoBed = new System.Windows.Forms.RadioButton();
            this.rdoArea = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dwRep);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 601);
            this.panel1.TabIndex = 2;
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "d_everydaybill_diff";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "D:\\ICARE_VER2005\\Code\\bin\\Debug\\pbreport.pbl";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(760, 597);
            this.dwRep.TabIndex = 1;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("宋体", 11F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "按明细",
            "按分类",
            "按类别"});
            this.cboType.Location = new System.Drawing.Point(96, 339);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(88, 23);
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "统计类型：";
            // 
            // txtBedID
            // 
            this.txtBedID.Location = new System.Drawing.Point(96, 140);
            this.txtBedID.Name = "txtBedID";
            this.txtBedID.Size = new System.Drawing.Size(132, 23);
            this.txtBedID.TabIndex = 1;
            this.txtBedID.Visible = false;
            this.txtBedID.TextChanged += new System.EventHandler(this.txtBedID_TextChanged);
            this.txtBedID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBedID_KeyDown);
            this.txtBedID.Leave += new System.EventHandler(this.txtBedID_Leave);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(68, 502);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(116, 32);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(68, 462);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(116, 32);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // m_txtAREAID
            // 
            this.m_txtAREAID.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtAREAID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAREAID.Location = new System.Drawing.Point(96, 64);
            this.m_txtAREAID.m_blnFocuseShow = true;
            this.m_txtAREAID.m_blnPagination = false;
            this.m_txtAREAID.m_dtbDataSourse = null;
            this.m_txtAREAID.m_intDelayTime = 100;
            this.m_txtAREAID.m_intPageRows = 10;
            this.m_txtAREAID.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.RightBottom;
            this.m_txtAREAID.m_listViewSize = new System.Drawing.Point(260, 200);
            this.m_txtAREAID.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtAREAID.m_strSaveField = "deptid_chr";
            this.m_txtAREAID.m_strShowField = "deptname_vchr";
            this.m_txtAREAID.m_strSQL = null;
            this.m_txtAREAID.Name = "m_txtAREAID";
            this.m_txtAREAID.Size = new System.Drawing.Size(132, 23);
            this.m_txtAREAID.TabIndex = 0;
            this.m_txtAREAID.ItemSelectedOK += new ControlLibrary.txtListView.EventItemSelectedOK(this.m_txtAREAID_ItemSelectedOK);
            this.m_txtAREAID.TextChanged += new System.EventHandler(this.m_txtAREAID_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(68, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(116, 32);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(68, 422);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(116, 32);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStat
            // 
            this.btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStat.DefaultScheme = true;
            this.btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStat.Hint = "";
            this.btnStat.Location = new System.Drawing.Point(68, 382);
            this.btnStat.Name = "btnStat";
            this.btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnStat.Size = new System.Drawing.Size(116, 32);
            this.btnStat.TabIndex = 4;
            this.btnStat.Text = "统计(&S)";
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // dteRq
            // 
            this.dteRq.CustomFormat = "yyyy年MM月dd日";
            this.dteRq.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq.Location = new System.Drawing.Point(96, 25);
            this.dteRq.Name = "dteRq";
            this.dteRq.Size = new System.Drawing.Size(132, 24);
            this.dteRq.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "住院时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lsvBed);
            this.groupBox1.Controls.Add(this.m_txtAREAID);
            this.groupBox1.Controls.Add(this.txtBedID);
            this.groupBox1.Controls.Add(this.txtZyh);
            this.groupBox1.Controls.Add(this.rdoZyh);
            this.groupBox1.Controls.Add(this.rdoBed);
            this.groupBox1.Controls.Add(this.rdoArea);
            this.groupBox1.Controls.Add(this.btnStat);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dteRq);
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 592);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // lsvBed
            // 
            this.lsvBed.CheckBoxes = true;
            this.lsvBed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvBed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvBed.Location = new System.Drawing.Point(16, 172);
            this.lsvBed.Name = "lsvBed";
            this.lsvBed.Size = new System.Drawing.Size(212, 158);
            this.lsvBed.TabIndex = 22;
            this.lsvBed.UseCompatibleStateImageBehavior = false;
            this.lsvBed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 22;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "床号";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.Width = 88;
            // 
            // txtZyh
            // 
            this.txtZyh.Location = new System.Drawing.Point(96, 102);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(132, 23);
            this.txtZyh.TabIndex = 18;
            // 
            // rdoZyh
            // 
            this.rdoZyh.AutoSize = true;
            this.rdoZyh.Location = new System.Drawing.Point(12, 104);
            this.rdoZyh.Name = "rdoZyh";
            this.rdoZyh.Size = new System.Drawing.Size(88, 18);
            this.rdoZyh.TabIndex = 21;
            this.rdoZyh.TabStop = true;
            this.rdoZyh.Text = "按住院号:";
            this.rdoZyh.UseVisualStyleBackColor = true;
            this.rdoZyh.CheckedChanged += new System.EventHandler(this.rdoZyh_CheckedChanged);
            // 
            // rdoBed
            // 
            this.rdoBed.AutoSize = true;
            this.rdoBed.Location = new System.Drawing.Point(12, 142);
            this.rdoBed.Name = "rdoBed";
            this.rdoBed.Size = new System.Drawing.Size(74, 18);
            this.rdoBed.TabIndex = 20;
            this.rdoBed.TabStop = true;
            this.rdoBed.Text = "按床号:";
            this.rdoBed.UseVisualStyleBackColor = true;
            this.rdoBed.CheckedChanged += new System.EventHandler(this.rdoBed_CheckedChanged);
            // 
            // rdoArea
            // 
            this.rdoArea.AutoSize = true;
            this.rdoArea.Location = new System.Drawing.Point(12, 66);
            this.rdoArea.Name = "rdoArea";
            this.rdoArea.Size = new System.Drawing.Size(74, 18);
            this.rdoArea.TabIndex = 19;
            this.rdoArea.TabStop = true;
            this.rdoArea.Text = "按病区:";
            this.rdoArea.UseVisualStyleBackColor = true;
            this.rdoArea.CheckedChanged += new System.EventHandler(this.rdoArea_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(764, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 601);
            this.panel2.TabIndex = 3;
            // 
            // frmRptEveryDayBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptEveryDayBill";
            this.Text = "费用每日清单";
            this.Load += new System.EventHandler(this.frmRptEveryDayBill_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dteRq;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP btnStat;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        internal ControlLibrary.txtListView m_txtAREAID;
        internal PinkieControls.ButtonXP btnPreview;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btnExport;
        private System.Windows.Forms.ComboBox cboType;
        internal System.Windows.Forms.TextBox txtBedID;
        private System.Windows.Forms.Label label3;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtZyh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoArea;
        private System.Windows.Forms.RadioButton rdoZyh;
        private System.Windows.Forms.RadioButton rdoBed;
        internal System.Windows.Forms.ListView lsvBed;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}