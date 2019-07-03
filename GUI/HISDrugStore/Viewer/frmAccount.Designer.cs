namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_txtBeginTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.m_txtEndTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.m_txtRemark = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnValid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnGenerate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblOUTSTORAGERETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_lblRECIPERETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.m_lblBEGINRETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.m_lblINSTORAGERETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.m_lblENDRETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_lblADJUSTRETAILFIGURE_INT = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_lblPutMed = new System.Windows.Forms.Label();
            this.m_bgwGenerateAccount = new System.ComponentModel.BackgroundWorker();
            this.ds = new Sybase.DataWindow.DataStore(this.components);
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_txtBeginTime,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.m_txtEndTime,
            this.toolStripSeparator4,
            this.m_btnQuery,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.m_txtRemark,
            this.toolStripSeparator5,
            this.m_btnValid,
            this.toolStripSeparator6,
            this.m_btnGenerate,
            this.toolStripSeparator1,
            this.m_cmdPrint,
            this.toolStripSeparator7,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 47);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 36);
            this.toolStripLabel1.Text = "帐务期时间：";
            // 
            // m_txtBeginTime
            // 
            this.m_txtBeginTime.AutoSize = false;
            this.m_txtBeginTime.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtBeginTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeginTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_txtBeginTime.Name = "m_txtBeginTime";
            this.m_txtBeginTime.Size = new System.Drawing.Size(195, 39);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(0, 44);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 36);
            this.toolStripLabel2.Text = "～";
            // 
            // m_txtEndTime
            // 
            this.m_txtEndTime.AutoSize = false;
            this.m_txtEndTime.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtEndTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEndTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_txtEndTime.Name = "m_txtEndTime";
            this.m_txtEndTime.Size = new System.Drawing.Size(195, 23);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(78, 36);
            this.m_btnQuery.Text = "查询(&Q)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(0, 44);
            this.toolStripLabel3.Text = "备注";
            this.toolStripLabel3.Visible = false;
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.AutoSize = false;
            this.m_txtRemark.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtRemark.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(0, 25);
            this.m_txtRemark.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 47);
            // 
            // m_btnValid
            // 
            this.m_btnValid.AutoSize = false;
            this.m_btnValid.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValid.Image")));
            this.m_btnValid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnValid.Name = "m_btnValid";
            this.m_btnValid.Size = new System.Drawing.Size(85, 36);
            this.m_btnValid.Text = "验证(&V)";
            this.m_btnValid.Click += new System.EventHandler(this.m_btnValid_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 47);
            // 
            // m_btnGenerate
            // 
            this.m_btnGenerate.AutoSize = false;
            this.m_btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("m_btnGenerate.Image")));
            this.m_btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnGenerate.Name = "m_btnGenerate";
            this.m_btnGenerate.Size = new System.Drawing.Size(85, 36);
            this.m_btnGenerate.Text = "结转(&T)";
            this.m_btnGenerate.Click += new System.EventHandler(this.m_btnGenerate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrint.Image")));
            this.m_cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(76, 44);
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 47);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(85, 33);
            this.m_btnExit.Text = "关闭(&E)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.tableLayoutPanel2);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.DarkGray;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 47);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(984, 111);
            this.gradientPanel2.TabIndex = 3;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.062768F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2972F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2972F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.29721F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2972F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2972F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40773F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04348F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_lblOUTSTORAGERETAILFIGURE_INT, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label21, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label22, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_lblRECIPERETAILFIGURE_INT, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_lblBEGINRETAILFIGURE_INT, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_lblINSTORAGERETAILFIGURE_INT, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_lblENDRETAILFIGURE_INT, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.label24, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_lblADJUSTRETAILFIGURE_INT, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label23, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_lblPutMed, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.18182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.81818F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(984, 111);
            this.tableLayoutPanel2.TabIndex = 10026;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(601, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 40);
            this.label2.TabIndex = 18;
            this.label2.Text = "本期摆药";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblOUTSTORAGERETAILFIGURE_INT
            // 
            this.m_lblOUTSTORAGERETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblOUTSTORAGERETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblOUTSTORAGERETAILFIGURE_INT.Location = new System.Drawing.Point(341, 44);
            this.m_lblOUTSTORAGERETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblOUTSTORAGERETAILFIGURE_INT.Name = "m_lblOUTSTORAGERETAILFIGURE_INT";
            this.m_lblOUTSTORAGERETAILFIGURE_INT.Size = new System.Drawing.Size(128, 65);
            this.m_lblOUTSTORAGERETAILFIGURE_INT.TabIndex = 4;
            this.m_lblOUTSTORAGERETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(2, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 65);
            this.label4.TabIndex = 14;
            this.label4.Text = "零售金额";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(5, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 40);
            this.label18.TabIndex = 1;
            this.label18.Text = "摘    要";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(84, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 40);
            this.label19.TabIndex = 5;
            this.label19.Text = "期    初";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(214, 2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 40);
            this.label20.TabIndex = 6;
            this.label20.Text = "本期入库";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(344, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 40);
            this.label21.TabIndex = 7;
            this.label21.Text = "本期出库";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(474, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 40);
            this.label22.TabIndex = 8;
            this.label22.Text = "本期处方";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblRECIPERETAILFIGURE_INT
            // 
            this.m_lblRECIPERETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblRECIPERETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblRECIPERETAILFIGURE_INT.Location = new System.Drawing.Point(471, 44);
            this.m_lblRECIPERETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblRECIPERETAILFIGURE_INT.Name = "m_lblRECIPERETAILFIGURE_INT";
            this.m_lblRECIPERETAILFIGURE_INT.Size = new System.Drawing.Size(128, 65);
            this.m_lblRECIPERETAILFIGURE_INT.TabIndex = 12;
            this.m_lblRECIPERETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblBEGINRETAILFIGURE_INT
            // 
            this.m_lblBEGINRETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblBEGINRETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblBEGINRETAILFIGURE_INT.Location = new System.Drawing.Point(81, 44);
            this.m_lblBEGINRETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblBEGINRETAILFIGURE_INT.Name = "m_lblBEGINRETAILFIGURE_INT";
            this.m_lblBEGINRETAILFIGURE_INT.Size = new System.Drawing.Size(128, 65);
            this.m_lblBEGINRETAILFIGURE_INT.TabIndex = 15;
            this.m_lblBEGINRETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblINSTORAGERETAILFIGURE_INT
            // 
            this.m_lblINSTORAGERETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblINSTORAGERETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblINSTORAGERETAILFIGURE_INT.Location = new System.Drawing.Point(211, 44);
            this.m_lblINSTORAGERETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblINSTORAGERETAILFIGURE_INT.Name = "m_lblINSTORAGERETAILFIGURE_INT";
            this.m_lblINSTORAGERETAILFIGURE_INT.Size = new System.Drawing.Size(128, 65);
            this.m_lblINSTORAGERETAILFIGURE_INT.TabIndex = 16;
            this.m_lblINSTORAGERETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblINSTORAGERETAILFIGURE_INT.Click += new System.EventHandler(this.m_lblINSTORAGERETAILFIGURE_INT_Click);
            // 
            // m_lblENDRETAILFIGURE_INT
            // 
            this.m_lblENDRETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblENDRETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblENDRETAILFIGURE_INT.Location = new System.Drawing.Point(852, 44);
            this.m_lblENDRETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblENDRETAILFIGURE_INT.Name = "m_lblENDRETAILFIGURE_INT";
            this.m_lblENDRETAILFIGURE_INT.Size = new System.Drawing.Size(130, 65);
            this.m_lblENDRETAILFIGURE_INT.TabIndex = 11;
            this.m_lblENDRETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(855, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(124, 40);
            this.label24.TabIndex = 10;
            this.label24.Text = "期    末";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblADJUSTRETAILFIGURE_INT
            // 
            this.m_lblADJUSTRETAILFIGURE_INT.BackColor = System.Drawing.Color.White;
            this.m_lblADJUSTRETAILFIGURE_INT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblADJUSTRETAILFIGURE_INT.Location = new System.Drawing.Point(731, 44);
            this.m_lblADJUSTRETAILFIGURE_INT.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblADJUSTRETAILFIGURE_INT.Name = "m_lblADJUSTRETAILFIGURE_INT";
            this.m_lblADJUSTRETAILFIGURE_INT.Size = new System.Drawing.Size(119, 65);
            this.m_lblADJUSTRETAILFIGURE_INT.TabIndex = 13;
            this.m_lblADJUSTRETAILFIGURE_INT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(734, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 40);
            this.label23.TabIndex = 9;
            this.label23.Text = "本期调价";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblPutMed
            // 
            this.m_lblPutMed.BackColor = System.Drawing.Color.White;
            this.m_lblPutMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblPutMed.Location = new System.Drawing.Point(601, 44);
            this.m_lblPutMed.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblPutMed.Name = "m_lblPutMed";
            this.m_lblPutMed.Size = new System.Drawing.Size(128, 65);
            this.m_lblPutMed.TabIndex = 17;
            this.m_lblPutMed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_bgwGenerateAccount
            // 
            this.m_bgwGenerateAccount.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGenerateAccount_DoWork_1);
            this.m_bgwGenerateAccount.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGenerateAccount_RunWorkerCompleted_1);
            // 
            // ds
            // 
            this.ds.DataWindowObject = null;
            this.ds.LibraryList = null;
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 158);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帐务期结转";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal GradientPanel gradientPanel2;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_btnExit;
        internal System.Windows.Forms.ToolStripLabel toolStripSeparator3;
        internal System.Windows.Forms.ToolStripLabel toolStripLabel2;
        internal System.Windows.Forms.ToolStripButton m_btnGenerate;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel toolStripLabel3;
        internal System.Windows.Forms.ToolStripTextBox m_txtRemark;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.Label m_lblOUTSTORAGERETAILFIGURE_INT;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label m_lblINSTORAGERETAILFIGURE_INT;
        internal System.Windows.Forms.Label m_lblBEGINRETAILFIGURE_INT;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label m_lblADJUSTRETAILFIGURE_INT;
        internal System.Windows.Forms.Label m_lblRECIPERETAILFIGURE_INT;
        private System.ComponentModel.BackgroundWorker m_bgwGenerateAccount;
        internal System.Windows.Forms.ToolStripLabel m_txtBeginTime;
        internal System.Windows.Forms.ToolStripLabel m_txtEndTime;
        internal System.Windows.Forms.ToolStripButton m_btnValid;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.Label m_lblENDRETAILFIGURE_INT;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label m_lblPutMed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        internal System.Windows.Forms.ToolStripButton m_cmdPrint;
        internal Sybase.DataWindow.DataStore ds;
    }
}