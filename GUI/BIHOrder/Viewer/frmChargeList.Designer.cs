namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmChargeList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeList));
            this.m_lvwList = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.m_code = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_MEDICINEPREPTYPENAME_VCHR = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblChargeSum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdAddOrder = new PinkieControls.ButtonXP();
            this.seachClass = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btFind = new PinkieControls.ButtonXP();
            this.m_txtFind = new com.digitalwave.controls.exTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmdTextOrder = new PinkieControls.ButtonXP();
            this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.m_dtvOrderdicCharge = new System.Windows.Forms.DataGridView();
            this.m_plTextOrder = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfo = new com.digitalwave.controls.ctlRichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.itemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChiefItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGE_DEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOSAGEUNIT_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMIPUNIT_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMSPEC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPNOQTYFLAG_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICINEPREPTYPENAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precent_dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicareTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IFSTOP_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenselimit_mny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdicid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderdicCharge)).BeginInit();
            this.m_plTextOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lvwList
            // 
            this.m_lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.m_code,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader4,
            this.m_MEDICINEPREPTYPENAME_VCHR});
            this.m_lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvwList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lvwList.FullRowSelect = true;
            this.m_lvwList.GridLines = true;
            this.m_lvwList.Location = new System.Drawing.Point(0, 43);
            this.m_lvwList.Name = "m_lvwList";
            this.m_lvwList.Size = new System.Drawing.Size(887, 291);
            this.m_lvwList.TabIndex = 0;
            this.m_lvwList.UseCompatibleStateImageBehavior = false;
            this.m_lvwList.View = System.Windows.Forms.View.Details;
            this.m_lvwList.DoubleClick += new System.EventHandler(this.m_lvwList_DoubleClick);
            this.m_lvwList.SelectedIndexChanged += new System.EventHandler(this.m_lvwList_SelectedIndexChanged);
            this.m_lvwList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvwList_KeyDown);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "序号";
            this.columnHeader6.Width = 40;
            // 
            // m_code
            // 
            this.m_code.Text = "编 码";
            this.m_code.Width = 99;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "查 询 码";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "商品名";
            this.columnHeader2.Width = 204;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "通用名";
            this.columnHeader7.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "规    格";
            this.columnHeader3.Width = 169;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "药房";
            this.columnHeader4.Width = 63;
            // 
            // m_MEDICINEPREPTYPENAME_VCHR
            // 
            this.m_MEDICINEPREPTYPENAME_VCHR.Text = "剂型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 62;
            this.label1.Text = "费用合计:";
            // 
            // m_lblChargeSum
            // 
            this.m_lblChargeSum.AutoSize = true;
            this.m_lblChargeSum.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblChargeSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblChargeSum.ForeColor = System.Drawing.Color.Red;
            this.m_lblChargeSum.Location = new System.Drawing.Point(75, 10);
            this.m_lblChargeSum.Name = "m_lblChargeSum";
            this.m_lblChargeSum.Size = new System.Drawing.Size(0, 14);
            this.m_lblChargeSum.TabIndex = 63;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdAddOrder);
            this.panel1.Controls.Add(this.seachClass);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btFind);
            this.panel1.Controls.Add(this.m_txtFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 43);
            this.panel1.TabIndex = 1;
            // 
            // m_cmdAddOrder
            // 
            this.m_cmdAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddOrder.DefaultScheme = true;
            this.m_cmdAddOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddOrder.Hint = "";
            this.m_cmdAddOrder.Location = new System.Drawing.Point(726, 5);
            this.m_cmdAddOrder.Name = "m_cmdAddOrder";
            this.m_cmdAddOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddOrder.Size = new System.Drawing.Size(136, 31);
            this.m_cmdAddOrder.TabIndex = 17;
            this.m_cmdAddOrder.Text = "即时生成医嘱(F4)";
            this.m_cmdAddOrder.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // seachClass
            // 
            this.seachClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.seachClass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.seachClass.FormattingEnabled = true;
            this.seachClass.Items.AddRange(new object[] {
            "拼音码",
            "五笔码",
            "项目名称",
            "用户编码"});
            this.seachClass.Location = new System.Drawing.Point(62, 11);
            this.seachClass.Name = "seachClass";
            this.seachClass.Size = new System.Drawing.Size(100, 22);
            this.seachClass.TabIndex = 2;
            this.seachClass.Text = "拼音码";
            this.seachClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seachClass_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(8, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 4;
            this.label16.Text = "查  询";
            // 
            // btFind
            // 
            this.btFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btFind.DefaultScheme = true;
            this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btFind.Hint = "";
            this.btFind.Location = new System.Drawing.Point(325, 8);
            this.btFind.Name = "btFind";
            this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btFind.Size = new System.Drawing.Size(86, 27);
            this.btFind.TabIndex = 4;
            this.btFind.Text = "查找(F1)";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // m_txtFind
            // 
            this.m_txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.m_txtFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFind.Location = new System.Drawing.Point(166, 11);
            this.m_txtFind.MaxLength = 16;
            this.m_txtFind.Name = "m_txtFind";
            this.m_txtFind.SendTabKey = false;
            this.m_txtFind.SetFocusColor = System.Drawing.Color.White;
            this.m_txtFind.Size = new System.Drawing.Size(153, 23);
            this.m_txtFind.TabIndex = 3;
            this.m_txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFind_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmdTextOrder);
            this.panel2.Controls.Add(this.collapsibleSplitter1);
            this.panel2.Controls.Add(this.m_dtvOrderdicCharge);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_lblChargeSum);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 172);
            this.panel2.TabIndex = 65;
            // 
            // m_cmdTextOrder
            // 
            this.m_cmdTextOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdTextOrder.DefaultScheme = true;
            this.m_cmdTextOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdTextOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdTextOrder.Hint = "";
            this.m_cmdTextOrder.Location = new System.Drawing.Point(776, 1);
            this.m_cmdTextOrder.Name = "m_cmdTextOrder";
            this.m_cmdTextOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdTextOrder.Size = new System.Drawing.Size(86, 28);
            this.m_cmdTextOrder.TabIndex = 17;
            this.m_cmdTextOrder.Text = "确定(F3)";
            this.m_cmdTextOrder.Visible = false;
            this.m_cmdTextOrder.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.collapsibleSplitter1.ControlToHide = this.m_dtvOrderdicCharge;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(0, 31);
            this.collapsibleSplitter1.MinExtra = 10;
            this.collapsibleSplitter1.MinSize = 10;
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(887, 8);
            this.collapsibleSplitter1.TabIndex = 64;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // m_dtvOrderdicCharge
            // 
            this.m_dtvOrderdicCharge.AllowUserToAddRows = false;
            this.m_dtvOrderdicCharge.AllowUserToDeleteRows = false;
            this.m_dtvOrderdicCharge.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dtvOrderdicCharge.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dtvOrderdicCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrderdicCharge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemCode,
            this.ItemName,
            this.IsChiefItem,
            this.QTY_INT,
            this.DOSAGE_DEC,
            this.DOSAGEUNIT_CHR,
            this.ITEMIPUNIT_CHR,
            this.ITEMSPEC_VCHR,
            this.MinPrice,
            this.IPNOQTYFLAG_INT,
            this.MEDICINEPREPTYPENAME_VCHR,
            this.precent_dec,
            this.MedicareTypeName,
            this.IFSTOP_INT,
            this.expenselimit_mny,
            this.orderdicid_chr});
            this.m_dtvOrderdicCharge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_dtvOrderdicCharge.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dtvOrderdicCharge.Location = new System.Drawing.Point(0, 39);
            this.m_dtvOrderdicCharge.Name = "m_dtvOrderdicCharge";
            this.m_dtvOrderdicCharge.ReadOnly = true;
            this.m_dtvOrderdicCharge.RowHeadersVisible = false;
            this.m_dtvOrderdicCharge.RowTemplate.Height = 23;
            this.m_dtvOrderdicCharge.Size = new System.Drawing.Size(887, 133);
            this.m_dtvOrderdicCharge.TabIndex = 65;
            // 
            // m_plTextOrder
            // 
            this.m_plTextOrder.BackColor = System.Drawing.Color.White;
            this.m_plTextOrder.Controls.Add(this.label2);
            this.m_plTextOrder.Controls.Add(this.txtInfo);
            this.m_plTextOrder.Controls.Add(this.pictureBox1);
            this.m_plTextOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_plTextOrder.Location = new System.Drawing.Point(0, 334);
            this.m_plTextOrder.Name = "m_plTextOrder";
            this.m_plTextOrder.Size = new System.Drawing.Size(887, 105);
            this.m_plTextOrder.TabIndex = 66;
            this.m_plTextOrder.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 62);
            this.label2.TabIndex = 5;
            this.label2.Text = "文字医嘱";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.Lavender;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtInfo.Location = new System.Drawing.Point(44, 3);
            this.txtInfo.m_BlnIgnoreUserInfo = true;
            this.txtInfo.m_BlnPartControl = false;
            this.txtInfo.m_BlnReadOnly = false;
            this.txtInfo.m_BlnUnderLineDST = false;
            this.txtInfo.m_ClrDST = System.Drawing.Color.Red;
            this.txtInfo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtInfo.m_IntCanModifyTime = 500;
            this.txtInfo.m_IntPartControlLength = 0;
            this.txtInfo.m_IntPartControlStartIndex = 0;
            this.txtInfo.m_StrUserID = "";
            this.txtInfo.m_StrUserName = "";
            this.txtInfo.MaxLength = 200;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(821, 101);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.TabStop = false;
            this.txtInfo.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // itemCode
            // 
            this.itemCode.HeaderText = "编码";
            this.itemCode.Name = "itemCode";
            this.itemCode.ReadOnly = true;
            this.itemCode.Width = 80;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "收费项目";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // IsChiefItem
            // 
            this.IsChiefItem.DataPropertyName = "IsChiefItem";
            this.IsChiefItem.HeaderText = "主";
            this.IsChiefItem.Name = "IsChiefItem";
            this.IsChiefItem.ReadOnly = true;
            this.IsChiefItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsChiefItem.Width = 30;
            // 
            // QTY_INT
            // 
            this.QTY_INT.DataPropertyName = "QTY_INT";
            this.QTY_INT.HeaderText = "数量";
            this.QTY_INT.Name = "QTY_INT";
            this.QTY_INT.ReadOnly = true;
            this.QTY_INT.Width = 60;
            // 
            // DOSAGE_DEC
            // 
            this.DOSAGE_DEC.DataPropertyName = "DOSAGE_DEC";
            this.DOSAGE_DEC.HeaderText = "剂量";
            this.DOSAGE_DEC.Name = "DOSAGE_DEC";
            this.DOSAGE_DEC.ReadOnly = true;
            this.DOSAGE_DEC.Width = 60;
            // 
            // DOSAGEUNIT_CHR
            // 
            this.DOSAGEUNIT_CHR.DataPropertyName = "DOSAGEUNIT_CHR";
            this.DOSAGEUNIT_CHR.HeaderText = "剂量单位";
            this.DOSAGEUNIT_CHR.Name = "DOSAGEUNIT_CHR";
            this.DOSAGEUNIT_CHR.ReadOnly = true;
            this.DOSAGEUNIT_CHR.Width = 60;
            // 
            // ITEMIPUNIT_CHR
            // 
            this.ITEMIPUNIT_CHR.DataPropertyName = "ITEMIPUNIT_CHR";
            this.ITEMIPUNIT_CHR.HeaderText = "住院单位";
            this.ITEMIPUNIT_CHR.Name = "ITEMIPUNIT_CHR";
            this.ITEMIPUNIT_CHR.ReadOnly = true;
            this.ITEMIPUNIT_CHR.Width = 60;
            // 
            // ITEMSPEC_VCHR
            // 
            this.ITEMSPEC_VCHR.DataPropertyName = "ITEMSPEC_VCHR";
            this.ITEMSPEC_VCHR.HeaderText = "规格";
            this.ITEMSPEC_VCHR.Name = "ITEMSPEC_VCHR";
            this.ITEMSPEC_VCHR.ReadOnly = true;
            this.ITEMSPEC_VCHR.Width = 60;
            // 
            // MinPrice
            // 
            this.MinPrice.DataPropertyName = "MinPrice";
            this.MinPrice.HeaderText = "单价";
            this.MinPrice.Name = "MinPrice";
            this.MinPrice.ReadOnly = true;
            this.MinPrice.Width = 60;
            // 
            // IPNOQTYFLAG_INT
            // 
            this.IPNOQTYFLAG_INT.HeaderText = "药房";
            this.IPNOQTYFLAG_INT.Name = "IPNOQTYFLAG_INT";
            this.IPNOQTYFLAG_INT.ReadOnly = true;
            this.IPNOQTYFLAG_INT.Width = 60;
            // 
            // MEDICINEPREPTYPENAME_VCHR
            // 
            this.MEDICINEPREPTYPENAME_VCHR.HeaderText = "剂型";
            this.MEDICINEPREPTYPENAME_VCHR.Name = "MEDICINEPREPTYPENAME_VCHR";
            this.MEDICINEPREPTYPENAME_VCHR.ReadOnly = true;
            this.MEDICINEPREPTYPENAME_VCHR.Width = 60;
            // 
            // precent_dec
            // 
            this.precent_dec.HeaderText = "自费比例";
            this.precent_dec.Name = "precent_dec";
            this.precent_dec.ReadOnly = true;
            this.precent_dec.Width = 60;
            // 
            // MedicareTypeName
            // 
            this.MedicareTypeName.HeaderText = "医保";
            this.MedicareTypeName.Name = "MedicareTypeName";
            this.MedicareTypeName.ReadOnly = true;
            this.MedicareTypeName.Width = 60;
            // 
            // IFSTOP_INT
            // 
            this.IFSTOP_INT.HeaderText = "停用";
            this.IFSTOP_INT.Name = "IFSTOP_INT";
            this.IFSTOP_INT.ReadOnly = true;
            this.IFSTOP_INT.Width = 60;
            // 
            // expenselimit_mny
            // 
            this.expenselimit_mny.HeaderText = "限报金额";
            this.expenselimit_mny.Name = "expenselimit_mny";
            this.expenselimit_mny.ReadOnly = true;
            // 
            // orderdicid_chr
            // 
            this.orderdicid_chr.DataPropertyName = "orderdicid_chr";
            this.orderdicid_chr.HeaderText = "orderdicid_chr";
            this.orderdicid_chr.Name = "orderdicid_chr";
            this.orderdicid_chr.ReadOnly = true;
            this.orderdicid_chr.Visible = false;
            // 
            // frmChargeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 611);
            this.Controls.Add(this.m_lvwList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_plTextOrder);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChargeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊疗项目列表";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeList_KeyDown);
            this.Load += new System.EventHandler(this.frmChargeList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderdicCharge)).EndInit();
            this.m_plTextOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label m_lblChargeSum;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btFind;
        internal com.digitalwave.controls.exTextBox m_txtFind;
        public System.Windows.Forms.ComboBox seachClass;
        private System.Windows.Forms.Label label16;
        internal PinkieControls.ButtonXP m_cmdAddOrder;
        private System.Windows.Forms.Panel panel2;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        public System.Windows.Forms.DataGridView m_dtvOrderdicCharge;
        private System.Windows.Forms.Panel m_plTextOrder;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.controls.ctlRichTextBox txtInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal PinkieControls.ButtonXP m_cmdTextOrder;
        private System.Windows.Forms.ColumnHeader m_code;
        internal System.Windows.Forms.ListView m_lvwList;
        private System.Windows.Forms.ColumnHeader m_MEDICINEPREPTYPENAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsChiefItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGE_DEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOSAGEUNIT_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMIPUNIT_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMSPEC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPNOQTYFLAG_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICINEPREPTYPENAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn precent_dec;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicareTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IFSTOP_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenselimit_mny;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdicid_chr;
    }
}