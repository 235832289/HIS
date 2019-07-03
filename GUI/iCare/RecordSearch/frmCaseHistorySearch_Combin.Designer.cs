namespace iCare
{
    partial class frmCaseHistorySearch_Combin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistorySearch_Combin));
            this.m_trvMain = new System.Windows.Forms.TreeView();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdAddCondition = new PinkieControls.ButtonXP();
            this.m_cmdClearCondition = new PinkieControls.ButtonXP();
            this.m_pnlTrueFalse = new System.Windows.Forms.Panel();
            this.m_chkTrueFalseFalse = new System.Windows.Forms.CheckBox();
            this.m_chkTrueFalseTrue = new System.Windows.Forms.CheckBox();
            this.m_pnlNumber = new System.Windows.Forms.Panel();
            this.m_txtNumberTo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNumberFrom = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblNumberFrom = new System.Windows.Forms.Label();
            this.m_lblNumberTo = new System.Windows.Forms.Label();
            this.m_cboNumberConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblNumberConditionType = new System.Windows.Forms.Label();
            this.m_pnlDate = new System.Windows.Forms.Panel();
            this.m_dtpSecond = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblDateTo = new System.Windows.Forms.Label();
            this.m_cboDateConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblDateConditionType = new System.Windows.Forms.Label();
            this.m_dtpFirst = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblDateFrom = new System.Windows.Forms.Label();
            this.m_cboConn = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_pnlLongText = new System.Windows.Forms.Panel();
            this.m_cboLongTextConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblLongTextConditionType = new System.Windows.Forms.Label();
            this.m_txtLongTextContent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lstConditionList = new System.Windows.Forms.ListBox();
            this.m_lsvResultList = new System.Windows.Forms.ListView();
            this.m_clmInPatienID = new System.Windows.Forms.ColumnHeader();
            this.m_clmPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_clmPatientSex = new System.Windows.Forms.ColumnHeader();
            this.m_clmInPatientDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutPatientDate = new System.Windows.Forms.ColumnHeader();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdClearResult = new PinkieControls.ButtonXP();
            this.m_lblResultNums = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.m_pnlTrueFalse.SuspendLayout();
            this.m_pnlNumber.SuspendLayout();
            this.m_pnlDate.SuspendLayout();
            this.m_pnlLongText.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvMain
            // 
            this.m_trvMain.BackColor = System.Drawing.Color.White;
            this.m_trvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_trvMain.ForeColor = System.Drawing.Color.Black;
            this.m_trvMain.HotTracking = true;
            this.m_trvMain.ImageIndex = 0;
            this.m_trvMain.ImageList = this.imlMain;
            this.m_trvMain.Location = new System.Drawing.Point(12, 12);
            this.m_trvMain.Name = "m_trvMain";
            this.m_trvMain.PathSeparator = ">>";
            this.m_trvMain.SelectedImageIndex = 3;
            this.m_trvMain.ShowNodeToolTips = true;
            this.m_trvMain.Size = new System.Drawing.Size(248, 584);
            this.m_trvMain.TabIndex = 1;
            this.m_trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvMain_AfterSelect);
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "");
            this.imlMain.Images.SetKeyName(1, "");
            this.imlMain.Images.SetKeyName(2, "");
            this.imlMain.Images.SetKeyName(3, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdAddCondition);
            this.groupBox1.Controls.Add(this.m_cmdClearCondition);
            this.groupBox1.Controls.Add(this.m_pnlTrueFalse);
            this.groupBox1.Controls.Add(this.m_pnlNumber);
            this.groupBox1.Controls.Add(this.m_pnlDate);
            this.groupBox1.Controls.Add(this.m_cboConn);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.m_pnlLongText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(266, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // m_cmdAddCondition
            // 
            this.m_cmdAddCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddCondition.DefaultScheme = true;
            this.m_cmdAddCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddCondition.Hint = "";
            this.m_cmdAddCondition.Location = new System.Drawing.Point(50, 178);
            this.m_cmdAddCondition.Name = "m_cmdAddCondition";
            this.m_cmdAddCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddCondition.Size = new System.Drawing.Size(76, 28);
            this.m_cmdAddCondition.TabIndex = 18817;
            this.m_cmdAddCondition.Text = "添加条件";
            this.m_cmdAddCondition.Click += new System.EventHandler(this.m_cmdAddCondition_Click);
            // 
            // m_cmdClearCondition
            // 
            this.m_cmdClearCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearCondition.DefaultScheme = true;
            this.m_cmdClearCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearCondition.Hint = "";
            this.m_cmdClearCondition.Location = new System.Drawing.Point(169, 178);
            this.m_cmdClearCondition.Name = "m_cmdClearCondition";
            this.m_cmdClearCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearCondition.Size = new System.Drawing.Size(80, 28);
            this.m_cmdClearCondition.TabIndex = 18818;
            this.m_cmdClearCondition.Text = "清空条件";
            this.m_cmdClearCondition.Click += new System.EventHandler(this.m_cmdClearCondition_Click);
            // 
            // m_pnlTrueFalse
            // 
            this.m_pnlTrueFalse.Controls.Add(this.m_chkTrueFalseFalse);
            this.m_pnlTrueFalse.Controls.Add(this.m_chkTrueFalseTrue);
            this.m_pnlTrueFalse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_pnlTrueFalse.Location = new System.Drawing.Point(11, 58);
            this.m_pnlTrueFalse.Name = "m_pnlTrueFalse";
            this.m_pnlTrueFalse.Size = new System.Drawing.Size(276, 108);
            this.m_pnlTrueFalse.TabIndex = 18816;
            // 
            // m_chkTrueFalseFalse
            // 
            this.m_chkTrueFalseFalse.AutoSize = true;
            this.m_chkTrueFalseFalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkTrueFalseFalse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_chkTrueFalseFalse.Location = new System.Drawing.Point(8, 52);
            this.m_chkTrueFalseFalse.Name = "m_chkTrueFalseFalse";
            this.m_chkTrueFalseFalse.Size = new System.Drawing.Size(93, 18);
            this.m_chkTrueFalseFalse.TabIndex = 421;
            this.m_chkTrueFalseFalse.Text = "条件不成立";
            this.m_chkTrueFalseFalse.UseVisualStyleBackColor = true;
            this.m_chkTrueFalseFalse.CheckedChanged += new System.EventHandler(this.m_chkTrueFalseFalse_CheckedChanged);
            // 
            // m_chkTrueFalseTrue
            // 
            this.m_chkTrueFalseTrue.AutoSize = true;
            this.m_chkTrueFalseTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkTrueFalseTrue.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_chkTrueFalseTrue.Location = new System.Drawing.Point(8, 12);
            this.m_chkTrueFalseTrue.Name = "m_chkTrueFalseTrue";
            this.m_chkTrueFalseTrue.Size = new System.Drawing.Size(79, 18);
            this.m_chkTrueFalseTrue.TabIndex = 421;
            this.m_chkTrueFalseTrue.Text = "条件成立";
            this.m_chkTrueFalseTrue.UseVisualStyleBackColor = true;
            this.m_chkTrueFalseTrue.CheckedChanged += new System.EventHandler(this.m_chkTrueFalseTrue_CheckedChanged);
            // 
            // m_pnlNumber
            // 
            this.m_pnlNumber.Controls.Add(this.m_txtNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_txtNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_cboNumberConditionType);
            this.m_pnlNumber.Controls.Add(this.lblNumberConditionType);
            this.m_pnlNumber.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_pnlNumber.Location = new System.Drawing.Point(11, 58);
            this.m_pnlNumber.Name = "m_pnlNumber";
            this.m_pnlNumber.Size = new System.Drawing.Size(276, 108);
            this.m_pnlNumber.TabIndex = 18815;
            // 
            // m_txtNumberTo
            // 
            this.m_txtNumberTo.BackColor = System.Drawing.Color.White;
            this.m_txtNumberTo.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtNumberTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNumberTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberTo.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberTo.Location = new System.Drawing.Point(192, 52);
            this.m_txtNumberTo.Name = "m_txtNumberTo";
            this.m_txtNumberTo.Size = new System.Drawing.Size(72, 23);
            this.m_txtNumberTo.TabIndex = 320;
            this.m_txtNumberTo.Visible = false;
            // 
            // m_txtNumberFrom
            // 
            this.m_txtNumberFrom.BackColor = System.Drawing.Color.White;
            this.m_txtNumberFrom.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtNumberFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberFrom.Location = new System.Drawing.Point(96, 52);
            this.m_txtNumberFrom.Name = "m_txtNumberFrom";
            this.m_txtNumberFrom.Size = new System.Drawing.Size(72, 23);
            this.m_txtNumberFrom.TabIndex = 310;
            // 
            // m_lblNumberFrom
            // 
            this.m_lblNumberFrom.AutoSize = true;
            this.m_lblNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblNumberFrom.Location = new System.Drawing.Point(36, 52);
            this.m_lblNumberFrom.Name = "m_lblNumberFrom";
            this.m_lblNumberFrom.Size = new System.Drawing.Size(42, 14);
            this.m_lblNumberFrom.TabIndex = 10000004;
            this.m_lblNumberFrom.Text = "数值:";
            // 
            // m_lblNumberTo
            // 
            this.m_lblNumberTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblNumberTo.Location = new System.Drawing.Point(172, 56);
            this.m_lblNumberTo.Name = "m_lblNumberTo";
            this.m_lblNumberTo.Size = new System.Drawing.Size(16, 24);
            this.m_lblNumberTo.TabIndex = 10000004;
            this.m_lblNumberTo.Text = "~";
            this.m_lblNumberTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblNumberTo.Visible = false;
            // 
            // m_cboNumberConditionType
            // 
            this.m_cboNumberConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboNumberConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNumberConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboNumberConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboNumberConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboNumberConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboNumberConditionType.ForeColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboNumberConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.Location = new System.Drawing.Point(96, 8);
            this.m_cboNumberConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboNumberConditionType.Name = "m_cboNumberConditionType";
            this.m_cboNumberConditionType.SelectedIndex = -1;
            this.m_cboNumberConditionType.SelectedItem = null;
            //this.m_cboNumberConditionType.SelectionStart = 0;
            this.m_cboNumberConditionType.Size = new System.Drawing.Size(168, 23);
            this.m_cboNumberConditionType.TabIndex = 3000;
            this.m_cboNumberConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.SelectedIndexChanged += new System.EventHandler(this.m_cboNumberConditionType_SelectedIndexChanged);
            // 
            // lblNumberConditionType
            // 
            this.lblNumberConditionType.AutoSize = true;
            this.lblNumberConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblNumberConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblNumberConditionType.Name = "lblNumberConditionType";
            this.lblNumberConditionType.Size = new System.Drawing.Size(70, 14);
            this.lblNumberConditionType.TabIndex = 10000004;
            this.lblNumberConditionType.Text = "条件类型:";
            // 
            // m_pnlDate
            // 
            this.m_pnlDate.Controls.Add(this.m_dtpSecond);
            this.m_pnlDate.Controls.Add(this.m_lblDateTo);
            this.m_pnlDate.Controls.Add(this.m_cboDateConditionType);
            this.m_pnlDate.Controls.Add(this.lblDateConditionType);
            this.m_pnlDate.Controls.Add(this.m_dtpFirst);
            this.m_pnlDate.Controls.Add(this.m_lblDateFrom);
            this.m_pnlDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_pnlDate.Location = new System.Drawing.Point(11, 58);
            this.m_pnlDate.Name = "m_pnlDate";
            this.m_pnlDate.Size = new System.Drawing.Size(276, 108);
            this.m_pnlDate.TabIndex = 18814;
            // 
            // m_dtpSecond
            // 
            this.m_dtpSecond.BorderColor = System.Drawing.Color.Black;
            this.m_dtpSecond.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpSecond.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpSecond.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpSecond.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpSecond.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpSecond.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpSecond.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSecond.Location = new System.Drawing.Point(96, 66);
            this.m_dtpSecond.m_BlnOnlyTime = false;
            this.m_dtpSecond.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpSecond.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpSecond.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpSecond.Name = "m_dtpSecond";
            this.m_dtpSecond.ReadOnly = false;
            this.m_dtpSecond.Size = new System.Drawing.Size(140, 22);
            this.m_dtpSecond.TabIndex = 220;
            this.m_dtpSecond.TextBackColor = System.Drawing.Color.White;
            this.m_dtpSecond.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpSecond.Visible = false;
            // 
            // m_lblDateTo
            // 
            this.m_lblDateTo.AutoSize = true;
            this.m_lblDateTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateTo.Location = new System.Drawing.Point(50, 68);
            this.m_lblDateTo.Name = "m_lblDateTo";
            this.m_lblDateTo.Size = new System.Drawing.Size(28, 14);
            this.m_lblDateTo.TabIndex = 10000004;
            this.m_lblDateTo.Text = "到:";
            this.m_lblDateTo.Visible = false;
            // 
            // m_cboDateConditionType
            // 
            this.m_cboDateConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboDateConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDateConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDateConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDateConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboDateConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboDateConditionType.ForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDateConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.Location = new System.Drawing.Point(96, 8);
            this.m_cboDateConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboDateConditionType.Name = "m_cboDateConditionType";
            this.m_cboDateConditionType.SelectedIndex = -1;
            this.m_cboDateConditionType.SelectedItem = null;
            //this.m_cboDateConditionType.SelectionStart = 0;
            this.m_cboDateConditionType.Size = new System.Drawing.Size(140, 23);
            this.m_cboDateConditionType.TabIndex = 3000;
            this.m_cboDateConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.SelectedIndexChanged += new System.EventHandler(this.m_cboDateConditionType_SelectedIndexChanged);
            // 
            // lblDateConditionType
            // 
            this.lblDateConditionType.AutoSize = true;
            this.lblDateConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblDateConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblDateConditionType.Name = "lblDateConditionType";
            this.lblDateConditionType.Size = new System.Drawing.Size(70, 14);
            this.lblDateConditionType.TabIndex = 10000008;
            this.lblDateConditionType.Text = "条件类型:";
            // 
            // m_dtpFirst
            // 
            this.m_dtpFirst.BorderColor = System.Drawing.Color.Black;
            this.m_dtpFirst.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpFirst.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpFirst.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpFirst.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpFirst.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpFirst.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFirst.Location = new System.Drawing.Point(96, 40);
            this.m_dtpFirst.m_BlnOnlyTime = false;
            this.m_dtpFirst.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpFirst.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpFirst.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpFirst.Name = "m_dtpFirst";
            this.m_dtpFirst.ReadOnly = false;
            this.m_dtpFirst.Size = new System.Drawing.Size(140, 22);
            this.m_dtpFirst.TabIndex = 210;
            this.m_dtpFirst.TextBackColor = System.Drawing.Color.White;
            this.m_dtpFirst.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lblDateFrom
            // 
            this.m_lblDateFrom.AutoSize = true;
            this.m_lblDateFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateFrom.Location = new System.Drawing.Point(50, 44);
            this.m_lblDateFrom.Name = "m_lblDateFrom";
            this.m_lblDateFrom.Size = new System.Drawing.Size(28, 14);
            this.m_lblDateFrom.TabIndex = 10000004;
            this.m_lblDateFrom.Text = "从:";
            this.m_lblDateFrom.Visible = false;
            // 
            // m_cboConn
            // 
            this.m_cboConn.AccessibleDescription = "连接类型";
            this.m_cboConn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboConn.FormattingEnabled = true;
            this.m_cboConn.Items.AddRange(new object[] {
            "并且",
            "或"});
            this.m_cboConn.Location = new System.Drawing.Point(107, 28);
            this.m_cboConn.Name = "m_cboConn";
            this.m_cboConn.Size = new System.Drawing.Size(91, 22);
            this.m_cboConn.TabIndex = 18812;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(106, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(93, 24);
            this.panel2.TabIndex = 18813;
            // 
            // m_pnlLongText
            // 
            this.m_pnlLongText.Controls.Add(this.m_cboLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.lblLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.m_txtLongTextContent);
            this.m_pnlLongText.Location = new System.Drawing.Point(11, 58);
            this.m_pnlLongText.Name = "m_pnlLongText";
            this.m_pnlLongText.Size = new System.Drawing.Size(276, 108);
            this.m_pnlLongText.TabIndex = 18811;
            // 
            // m_cboLongTextConditionType
            // 
            this.m_cboLongTextConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboLongTextConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLongTextConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLongTextConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLongTextConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboLongTextConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboLongTextConditionType.ForeColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboLongTextConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.Location = new System.Drawing.Point(96, 8);
            this.m_cboLongTextConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboLongTextConditionType.Name = "m_cboLongTextConditionType";
            this.m_cboLongTextConditionType.SelectedIndex = -1;
            this.m_cboLongTextConditionType.SelectedItem = null;
            //this.m_cboLongTextConditionType.SelectionStart = 0;
            this.m_cboLongTextConditionType.Size = new System.Drawing.Size(168, 23);
            this.m_cboLongTextConditionType.TabIndex = 3000;
            this.m_cboLongTextConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblLongTextConditionType
            // 
            this.lblLongTextConditionType.AutoSize = true;
            this.lblLongTextConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblLongTextConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblLongTextConditionType.Name = "lblLongTextConditionType";
            this.lblLongTextConditionType.Size = new System.Drawing.Size(77, 14);
            this.lblLongTextConditionType.TabIndex = 10000006;
            this.lblLongTextConditionType.Text = "条件类型：";
            // 
            // m_txtLongTextContent
            // 
            this.m_txtLongTextContent.BackColor = System.Drawing.Color.White;
            this.m_txtLongTextContent.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtLongTextContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtLongTextContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtLongTextContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtLongTextContent.Location = new System.Drawing.Point(8, 48);
            this.m_txtLongTextContent.Name = "m_txtLongTextContent";
            this.m_txtLongTextContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtLongTextContent.Size = new System.Drawing.Size(256, 23);
            this.m_txtLongTextContent.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lstConditionList);
            this.groupBox2.Location = new System.Drawing.Point(570, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 225);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条件列表";
            // 
            // m_lstConditionList
            // 
            this.m_lstConditionList.BackColor = System.Drawing.Color.White;
            this.m_lstConditionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lstConditionList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lstConditionList.ForeColor = System.Drawing.Color.Black;
            this.m_lstConditionList.HorizontalScrollbar = true;
            this.m_lstConditionList.ItemHeight = 14;
            this.m_lstConditionList.Location = new System.Drawing.Point(3, 24);
            this.m_lstConditionList.Name = "m_lstConditionList";
            this.m_lstConditionList.Size = new System.Drawing.Size(255, 198);
            this.m_lstConditionList.TabIndex = 1104;
            this.m_lstConditionList.DoubleClick += new System.EventHandler(this.m_lstConditionList_DoubleClick);
            // 
            // m_lsvResultList
            // 
            this.m_lsvResultList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvResultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmInPatienID,
            this.m_clmPatientName,
            this.m_clmPatientSex,
            this.m_clmInPatientDate,
            this.m_clmOutPatientDate});
            this.m_lsvResultList.GridLines = true;
            this.m_lsvResultList.Location = new System.Drawing.Point(266, 277);
            this.m_lsvResultList.Name = "m_lsvResultList";
            this.m_lsvResultList.Size = new System.Drawing.Size(565, 319);
            this.m_lsvResultList.TabIndex = 4;
            this.m_lsvResultList.UseCompatibleStateImageBehavior = false;
            this.m_lsvResultList.View = System.Windows.Forms.View.Details;
            this.m_lsvResultList.DoubleClick += new System.EventHandler(this.m_lsvResultList_DoubleClick);
            // 
            // m_clmInPatienID
            // 
            this.m_clmInPatienID.Text = "住院号";
            this.m_clmInPatienID.Width = 80;
            // 
            // m_clmPatientName
            // 
            this.m_clmPatientName.Text = "姓名";
            this.m_clmPatientName.Width = 100;
            // 
            // m_clmPatientSex
            // 
            this.m_clmPatientSex.Text = "性别";
            // 
            // m_clmInPatientDate
            // 
            this.m_clmInPatientDate.Text = "入院日期";
            this.m_clmInPatientDate.Width = 150;
            // 
            // m_clmOutPatientDate
            // 
            this.m_clmOutPatientDate.Text = "出院日期";
            this.m_clmOutPatientDate.Width = 150;
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(316, 243);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(76, 28);
            this.m_cmdSearch.TabIndex = 10000007;
            this.m_cmdSearch.Text = "查  询";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdClearResult
            // 
            this.m_cmdClearResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearResult.DefaultScheme = true;
            this.m_cmdClearResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearResult.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdClearResult.Hint = "";
            this.m_cmdClearResult.Location = new System.Drawing.Point(439, 243);
            this.m_cmdClearResult.Name = "m_cmdClearResult";
            this.m_cmdClearResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearResult.Size = new System.Drawing.Size(76, 28);
            this.m_cmdClearResult.TabIndex = 10000008;
            this.m_cmdClearResult.Text = "清空列表";
            this.m_cmdClearResult.Click += new System.EventHandler(this.m_cmdClearResult_Click);
            // 
            // m_lblResultNums
            // 
            this.m_lblResultNums.AutoSize = true;
            this.m_lblResultNums.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblResultNums.Location = new System.Drawing.Point(643, 250);
            this.m_lblResultNums.Name = "m_lblResultNums";
            this.m_lblResultNums.Size = new System.Drawing.Size(112, 14);
            this.m_lblResultNums.TabIndex = 10000009;
            this.m_lblResultNums.Text = "共检索出0条记录";
            // 
            // frmCaseHistorySearch_Combin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 623);
            this.Controls.Add(this.m_lblResultNums);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_cmdClearResult);
            this.Controls.Add(this.m_lsvResultList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_trvMain);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistorySearch_Combin";
            this.Text = "组合查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pnlTrueFalse.ResumeLayout(false);
            this.m_pnlTrueFalse.PerformLayout();
            this.m_pnlNumber.ResumeLayout(false);
            this.m_pnlNumber.PerformLayout();
            this.m_pnlDate.ResumeLayout(false);
            this.m_pnlDate.PerformLayout();
            this.m_pnlLongText.ResumeLayout(false);
            this.m_pnlLongText.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView m_trvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel m_pnlLongText;
        internal com.digitalwave.Utility.Controls.ctlComboBox m_cboLongTextConditionType;
        internal System.Windows.Forms.Label lblLongTextConditionType;
        internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLongTextContent;
        private System.Windows.Forms.ComboBox m_cboConn;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel m_pnlDate;
        internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSecond;
        internal System.Windows.Forms.Label m_lblDateTo;
        internal com.digitalwave.Utility.Controls.ctlComboBox m_cboDateConditionType;
        internal System.Windows.Forms.Label lblDateConditionType;
        internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFirst;
        internal System.Windows.Forms.Label m_lblDateFrom;
        internal System.Windows.Forms.Panel m_pnlNumber;
        internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberTo;
        internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberFrom;
        internal System.Windows.Forms.Label m_lblNumberFrom;
        internal System.Windows.Forms.Label m_lblNumberTo;
        internal com.digitalwave.Utility.Controls.ctlComboBox m_cboNumberConditionType;
        internal System.Windows.Forms.Label lblNumberConditionType;
        internal System.Windows.Forms.Panel m_pnlTrueFalse;
        private System.Windows.Forms.CheckBox m_chkTrueFalseFalse;
        private System.Windows.Forms.CheckBox m_chkTrueFalseTrue;
        private PinkieControls.ButtonXP m_cmdAddCondition;
        private PinkieControls.ButtonXP m_cmdClearCondition;
        internal System.Windows.Forms.ListBox m_lstConditionList;
        private System.Windows.Forms.ListView m_lsvResultList;
        private System.Windows.Forms.ColumnHeader m_clmInPatienID;
        private System.Windows.Forms.ColumnHeader m_clmPatientName;
        private System.Windows.Forms.ColumnHeader m_clmPatientSex;
        private System.Windows.Forms.ColumnHeader m_clmInPatientDate;
        private System.Windows.Forms.ColumnHeader m_clmOutPatientDate;
        private PinkieControls.ButtonXP m_cmdSearch;
        private PinkieControls.ButtonXP m_cmdClearResult;
        private System.Windows.Forms.Label m_lblResultNums;
        private System.Windows.Forms.ImageList imlMain;
    }
}