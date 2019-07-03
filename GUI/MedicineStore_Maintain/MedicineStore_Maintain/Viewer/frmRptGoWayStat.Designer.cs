namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptGoWayStat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptGoWayStat));
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOutall = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblopramount = new System.Windows.Forms.Label();
            this.m_lboutamountSum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvGoWayStat = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtdeptname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtoutamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtopramount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtputamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayStat)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypecode.Location = new System.Drawing.Point(581, 13);
            this.txtTypecode.m_blnFocuseShow = true;
            this.txtTypecode.m_blnPagination = false;
            this.txtTypecode.m_dtbDataSourse = null;
            this.txtTypecode.m_intDelayTime = 100;
            this.txtTypecode.m_intPageRows = 10;
            this.txtTypecode.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtTypecode.m_listViewSize = new System.Drawing.Point(163, 150);
            this.txtTypecode.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtTypecode.m_strSaveField = "medicinetypeid_chr";
            this.txtTypecode.m_strShowField = "medicinetypename_vchr";
            this.txtTypecode.m_strSQL = null;
            this.txtTypecode.Name = "txtTypecode";
            this.txtTypecode.Size = new System.Drawing.Size(241, 23);
            this.txtTypecode.TabIndex = 2;
            this.txtTypecode.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtTypecode_ItemSelectedOK);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(498, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 10051;
            this.label4.Text = "药品类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10047;
            this.label1.Text = "统计时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(268, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 10048;
            this.label8.Text = "~";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOutall);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_lblopramount);
            this.panel2.Controls.Add(this.m_lboutamountSum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.m_dgvGoWayStat);
            this.panel2.Controls.Add(this.dw);
            this.panel2.Controls.Add(this.gradientPanel1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1012, 741);
            this.panel2.TabIndex = 1;
            // 
            // lblOutall
            // 
            this.lblOutall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutall.AutoSize = true;
            this.lblOutall.BackColor = System.Drawing.Color.Transparent;
            this.lblOutall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutall.ForeColor = System.Drawing.Color.Maroon;
            this.lblOutall.Location = new System.Drawing.Point(803, 723);
            this.lblOutall.Name = "lblOutall";
            this.lblOutall.Size = new System.Drawing.Size(15, 14);
            this.lblOutall.TabIndex = 10081;
            this.lblOutall.Text = "0";
            this.lblOutall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutall.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(763, 723);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 14);
            this.label5.TabIndex = 10080;
            this.label5.Text = "小计：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // m_lblopramount
            // 
            this.m_lblopramount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblopramount.AutoSize = true;
            this.m_lblopramount.BackColor = System.Drawing.Color.Transparent;
            this.m_lblopramount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblopramount.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblopramount.Location = new System.Drawing.Point(561, 723);
            this.m_lblopramount.Name = "m_lblopramount";
            this.m_lblopramount.Size = new System.Drawing.Size(15, 14);
            this.m_lblopramount.TabIndex = 10079;
            this.m_lblopramount.Text = "0";
            this.m_lblopramount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblopramount.Visible = false;
            // 
            // m_lboutamountSum
            // 
            this.m_lboutamountSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lboutamountSum.AutoSize = true;
            this.m_lboutamountSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lboutamountSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lboutamountSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lboutamountSum.Location = new System.Drawing.Point(294, 723);
            this.m_lboutamountSum.Name = "m_lboutamountSum";
            this.m_lboutamountSum.Size = new System.Drawing.Size(15, 14);
            this.m_lboutamountSum.TabIndex = 10078;
            this.m_lboutamountSum.Text = "0";
            this.m_lboutamountSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lboutamountSum.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(222, 723);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 10077;
            this.label2.Text = "单据出库：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(491, 723);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 10075;
            this.label3.Text = "处方出库：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(82, 723);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 14);
            this.label13.TabIndex = 10073;
            this.label13.Text = "合计:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // m_dgvGoWayStat
            // 
            this.m_dgvGoWayStat.AllowUserToAddRows = false;
            this.m_dgvGoWayStat.AllowUserToOrderColumns = true;
            this.m_dgvGoWayStat.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvGoWayStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvGoWayStat.ColumnHeadersHeight = 25;
            this.m_dgvGoWayStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvGoWayStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtdeptname_vchr,
            this.m_dgvtxtoutamount,
            this.m_dgvtxtopramount,
            this.m_dgvtxtputamount,
            this.m_dgvtxtOutall,
            this.m_dgvSortRowNo});
            this.m_dgvGoWayStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvGoWayStat.Location = new System.Drawing.Point(4, 91);
            this.m_dgvGoWayStat.Name = "m_dgvGoWayStat";
            this.m_dgvGoWayStat.ReadOnly = true;
            this.m_dgvGoWayStat.RowHeadersVisible = false;
            this.m_dgvGoWayStat.RowTemplate.Height = 23;
            this.m_dgvGoWayStat.Size = new System.Drawing.Size(1004, 646);
            this.m_dgvGoWayStat.TabIndex = 10030;
            this.m_dgvGoWayStat.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvGoWayStat_ColumnHeaderMouseClick);
            this.m_dgvGoWayStat.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvGoWayStat_ColumnHeaderMouseDoubleClick);
            // 
            // m_dgvtxtdeptname_vchr
            // 
            this.m_dgvtxtdeptname_vchr.DataPropertyName = "deptname_vchr";
            this.m_dgvtxtdeptname_vchr.HeaderText = "                   去向";
            this.m_dgvtxtdeptname_vchr.Name = "m_dgvtxtdeptname_vchr";
            this.m_dgvtxtdeptname_vchr.ReadOnly = true;
            this.m_dgvtxtdeptname_vchr.Width = 300;
            // 
            // m_dgvtxtoutamount
            // 
            this.m_dgvtxtoutamount.DataPropertyName = "outamount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            this.m_dgvtxtoutamount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtoutamount.HeaderText = "      单据出库";
            this.m_dgvtxtoutamount.Name = "m_dgvtxtoutamount";
            this.m_dgvtxtoutamount.ReadOnly = true;
            this.m_dgvtxtoutamount.Width = 170;
            // 
            // m_dgvtxtopramount
            // 
            this.m_dgvtxtopramount.DataPropertyName = "opramount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            this.m_dgvtxtopramount.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtopramount.HeaderText = "      处方出库";
            this.m_dgvtxtopramount.Name = "m_dgvtxtopramount";
            this.m_dgvtxtopramount.ReadOnly = true;
            this.m_dgvtxtopramount.Width = 170;
            // 
            // m_dgvtxtputamount
            // 
            this.m_dgvtxtputamount.DataPropertyName = "putamount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.m_dgvtxtputamount.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtputamount.HeaderText = "      摆药出库";
            this.m_dgvtxtputamount.Name = "m_dgvtxtputamount";
            this.m_dgvtxtputamount.ReadOnly = true;
            this.m_dgvtxtputamount.Width = 170;
            // 
            // m_dgvtxtOutall
            // 
            this.m_dgvtxtOutall.DataPropertyName = "outallamount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            this.m_dgvtxtOutall.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtOutall.HeaderText = "          小计";
            this.m_dgvtxtOutall.Name = "m_dgvtxtOutall";
            this.m_dgvtxtOutall.ReadOnly = true;
            this.m_dgvtxtOutall.Width = 190;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(4, 91);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1004, 646);
            this.dw.TabIndex = 10029;
            this.dw.Text = "dataWindowControl1";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_dtpSearchEndDate);
            this.gradientPanel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.label8);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = false;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(4, 42);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1004, 49);
            this.gradientPanel1.TabIndex = 10028;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(282, 13);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpSearchEndDate.TabIndex = 1;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(81, 13);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpSearchBeginDate.TabIndex = 0;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnQuery,
            this.toolStripSeparator4,
            this.m_btnPreview,
            this.toolStripSeparator2,
            this.m_btnPrint,
            this.toolStripSeparator1,
            this.m_btnExport,
            this.toolStripSeparator3,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(4, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 38);
            this.toolStrip1.TabIndex = 10027;
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
            this.m_btnQuery.Size = new System.Drawing.Size(90, 35);
            this.m_btnQuery.Text = "查 询(&Q)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_cmdSearch_Click);
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
            // m_btnPrint
            // 
            this.m_btnPrint.AutoSize = false;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrint.Image")));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(90, 35);
            this.m_btnPrint.Text = "打 印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExport
            // 
            this.m_btnExport.AutoSize = false;
            this.m_btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExport.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExport.Image")));
            this.m_btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(90, 35);
            this.m_btnExport.Text = "导 出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(90, 35);
            this.m_btnExit.Text = "关 闭(&C)";
            this.m_btnExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // frmRptGoWayStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 741);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptGoWayStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处方耗用按开单科室统计表";
            this.Load += new System.EventHandler(this.frmRptInstorageStat_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayStat)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal ControlLibrary.txtListView1 txtTypecode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel1;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel m_btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvGoWayStat;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label m_lblopramount;
        internal System.Windows.Forms.Label m_lboutamountSum;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lblOutall;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtdeptname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtoutamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtopramount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtputamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutall;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
    }
}