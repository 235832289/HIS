namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmOrderNurseConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderNurseConfirm));
            this.m_ctMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_ItemCommit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ItemRedrawback = new System.Windows.Forms.ToolStripMenuItem();
            this.m_timerMessage = new System.Windows.Forms.Timer(this.components);
            this.m_cmdToExecute = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdoYET = new System.Windows.Forms.RadioButton();
            this.m_rdoNOT = new System.Windows.Forms.RadioButton();
            this.m_rdoAll = new System.Windows.Forms.RadioButton();
            this.m_cmdEditFeel = new PinkieControls.ButtonXP();
            this.m_btnBedList = new System.Windows.Forms.Button();
            this.m_cboCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.m_cmdRedraw = new PinkieControls.ButtonXP();
            this.m_cmdBack = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dtvChangeList = new System.Windows.Forms.DataGridView();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMSPEC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.get_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xuClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excuteDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPNOQTYFLAG_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiffCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.m_plChargeButtonList = new System.Windows.Forms.Panel();
            this.m_plChargeControl = new System.Windows.Forms.Panel();
            this.m_cmdChargeAdd = new PinkieControls.ButtonXP();
            this.m_cmdChargeModify = new PinkieControls.ButtonXP();
            this.m_cmdChargeDele = new PinkieControls.ButtonXP();
            this.m_btnPatientCharge = new PinkieControls.ButtonXP();
            this.m_chkNeedFeel = new System.Windows.Forms.CheckBox();
            this.m_cmdPrintFeel = new PinkieControls.ButtonXP();
            this.m_lblNewOrderCount = new System.Windows.Forms.Label();
            this.m_txtSameCharge = new System.Windows.Forms.Label();
            this.m_txtChargeSum = new System.Windows.Forms.Label();
            this.m_dtvOrderList = new System.Windows.Forms.DataGridView();
            this.dtv_bedcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inpatientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_RecipeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Case = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ExecuteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ENTRUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Get = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretestdays = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ATTACHTIMES_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATOR_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvPOSTDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvCONFIRMER_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvCONFIRM_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvASSESSORFORSTOP_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvASSESSORFORSTOP_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_UseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvselectCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtv_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_CURAREAName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtBedNo2 = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_ctlPatient = new com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo();
            this.m_ctMenuList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).BeginInit();
            this.m_plChargeButtonList.SuspendLayout();
            this.m_plChargeControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ctMenuList
            // 
            this.m_ctMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ItemCommit,
            this.m_ItemRedrawback});
            this.m_ctMenuList.Name = "m_ctMenuList";
            this.m_ctMenuList.Size = new System.Drawing.Size(153, 70);
            this.m_ctMenuList.Opening += new System.ComponentModel.CancelEventHandler(this.m_ctMenuList_Opening);
            // 
            // m_ItemCommit
            // 
            this.m_ItemCommit.Checked = true;
            this.m_ItemCommit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ItemCommit.Name = "m_ItemCommit";
            this.m_ItemCommit.Size = new System.Drawing.Size(152, 22);
            this.m_ItemCommit.Text = "确认核对";
            this.m_ItemCommit.Click += new System.EventHandler(this.m_ItemCommit_Click);
            // 
            // m_ItemRedrawback
            // 
            this.m_ItemRedrawback.Name = "m_ItemRedrawback";
            this.m_ItemRedrawback.Size = new System.Drawing.Size(152, 22);
            this.m_ItemRedrawback.Text = "撤消核对";
            this.m_ItemRedrawback.Click += new System.EventHandler(this.m_ItemRedrawback_Click);
            // 
            // m_timerMessage
            // 
            this.m_timerMessage.Interval = 5000;
            this.m_timerMessage.Tick += new System.EventHandler(this.m_timerMessage_Tick);
            // 
            // m_cmdToExecute
            // 
            this.m_cmdToExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToExecute.DefaultScheme = true;
            this.m_cmdToExecute.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToExecute.Hint = "";
            this.m_cmdToExecute.Location = new System.Drawing.Point(818, 594);
            this.m_cmdToExecute.Name = "m_cmdToExecute";
            this.m_cmdToExecute.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToExecute.Size = new System.Drawing.Size(100, 29);
            this.m_cmdToExecute.TabIndex = 130;
            this.m_cmdToExecute.Text = "医嘱执行 F6";
            this.m_cmdToExecute.Click += new System.EventHandler(this.m_cmdToExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdoYET);
            this.groupBox1.Controls.Add(this.m_rdoNOT);
            this.groupBox1.Controls.Add(this.m_rdoAll);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(440, 562);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 53);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // m_rdoYET
            // 
            this.m_rdoYET.AutoSize = true;
            this.m_rdoYET.Location = new System.Drawing.Point(88, 22);
            this.m_rdoYET.Name = "m_rdoYET";
            this.m_rdoYET.Size = new System.Drawing.Size(67, 18);
            this.m_rdoYET.TabIndex = 86;
            this.m_rdoYET.Text = "已核对";
            this.m_rdoYET.UseVisualStyleBackColor = true;
            this.m_rdoYET.CheckedChanged += new System.EventHandler(this.m_rdoYET_CheckedChanged);
            // 
            // m_rdoNOT
            // 
            this.m_rdoNOT.AutoSize = true;
            this.m_rdoNOT.Checked = true;
            this.m_rdoNOT.Location = new System.Drawing.Point(10, 22);
            this.m_rdoNOT.Name = "m_rdoNOT";
            this.m_rdoNOT.Size = new System.Drawing.Size(67, 18);
            this.m_rdoNOT.TabIndex = 87;
            this.m_rdoNOT.TabStop = true;
            this.m_rdoNOT.Text = "未核对";
            this.m_rdoNOT.UseVisualStyleBackColor = true;
            this.m_rdoNOT.CheckedChanged += new System.EventHandler(this.m_rdoNOT_CheckedChanged);
            // 
            // m_rdoAll
            // 
            this.m_rdoAll.AutoSize = true;
            this.m_rdoAll.Location = new System.Drawing.Point(169, 48);
            this.m_rdoAll.Name = "m_rdoAll";
            this.m_rdoAll.Size = new System.Drawing.Size(53, 18);
            this.m_rdoAll.TabIndex = 88;
            this.m_rdoAll.Text = "全部";
            this.m_rdoAll.UseVisualStyleBackColor = true;
            this.m_rdoAll.Visible = false;
            this.m_rdoAll.CheckedChanged += new System.EventHandler(this.m_rdoAll_CheckedChanged);
            // 
            // m_cmdEditFeel
            // 
            this.m_cmdEditFeel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdEditFeel.DefaultScheme = true;
            this.m_cmdEditFeel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEditFeel.Hint = "";
            this.m_cmdEditFeel.Location = new System.Drawing.Point(719, 594);
            this.m_cmdEditFeel.Name = "m_cmdEditFeel";
            this.m_cmdEditFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEditFeel.Size = new System.Drawing.Size(100, 29);
            this.m_cmdEditFeel.TabIndex = 129;
            this.m_cmdEditFeel.Text = "编辑皮试 F5";
            this.m_cmdEditFeel.Click += new System.EventHandler(this.m_cmdEditFeel_Click);
            // 
            // m_btnBedList
            // 
            this.m_btnBedList.Location = new System.Drawing.Point(331, 580);
            this.m_btnBedList.Name = "m_btnBedList";
            this.m_btnBedList.Size = new System.Drawing.Size(19, 23);
            this.m_btnBedList.TabIndex = 128;
            this.m_btnBedList.Text = "↓";
            this.m_btnBedList.UseVisualStyleBackColor = true;
            this.m_btnBedList.Click += new System.EventHandler(this.m_btnBedList_Click);
            // 
            // m_cboCode
            // 
            this.m_cboCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCode.Items.AddRange(new object[] {
            "全区",
            "个人"});
            this.m_cboCode.Location = new System.Drawing.Point(169, 581);
            this.m_cboCode.Name = "m_cboCode";
            this.m_cboCode.Size = new System.Drawing.Size(69, 22);
            this.m_cboCode.TabIndex = 125;
            this.m_cboCode.SelectedValueChanged += new System.EventHandler(this.m_cboCode_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 127;
            this.label3.Text = "床号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(617, 594);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(100, 29);
            this.cmdRefurbish.TabIndex = 98;
            this.cmdRefurbish.Text = "刷新 F4";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // m_cmdRedraw
            // 
            this.m_cmdRedraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdRedraw.DefaultScheme = true;
            this.m_cmdRedraw.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRedraw.Hint = "";
            this.m_cmdRedraw.Location = new System.Drawing.Point(718, 562);
            this.m_cmdRedraw.Name = "m_cmdRedraw";
            this.m_cmdRedraw.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRedraw.Size = new System.Drawing.Size(100, 29);
            this.m_cmdRedraw.TabIndex = 97;
            this.m_cmdRedraw.Text = "撤销核对 F2";
            this.m_cmdRedraw.Click += new System.EventHandler(this.m_cmdRedraw_Click);
            // 
            // m_cmdBack
            // 
            this.m_cmdBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdBack.DefaultScheme = true;
            this.m_cmdBack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBack.Hint = "";
            this.m_cmdBack.Location = new System.Drawing.Point(818, 562);
            this.m_cmdBack.Name = "m_cmdBack";
            this.m_cmdBack.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBack.Size = new System.Drawing.Size(100, 29);
            this.m_cmdBack.TabIndex = 96;
            this.m_cmdBack.Text = "退回医嘱 F3";
            this.m_cmdBack.Click += new System.EventHandler(this.m_cmdBack_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(919, 562);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(93, 29);
            this.m_cmdExit.TabIndex = 95;
            this.m_cmdExit.Text = "退 出(Esc)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(617, 562);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(100, 29);
            this.m_cmdToCommit.TabIndex = 93;
            this.m_cmdToCommit.Text = "确认核对 F1";
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(56, 580);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(107, 23);
            this.m_txtArea.TabIndex = 84;
            this.m_txtArea.DoubleClick += new System.EventHandler(this.m_txtArea_DoubleClick);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dtvChangeList);
            this.panel1.Controls.Add(this.collapsibleSplitter1);
            this.panel1.Controls.Add(this.m_plChargeButtonList);
            this.panel1.Controls.Add(this.m_dtvOrderList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 556);
            this.panel1.TabIndex = 83;
            // 
            // m_dtvChangeList
            // 
            this.m_dtvChangeList.AllowUserToAddRows = false;
            this.m_dtvChangeList.AllowUserToDeleteRows = false;
            this.m_dtvChangeList.AllowUserToResizeRows = false;
            this.m_dtvChangeList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvChangeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtvChangeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dtvChangeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvChangeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.chargeName,
            this.ITEMSPEC_VCHR,
            this.ChargeClass,
            this.ChargePrice,
            this.get_count,
            this.countSum,
            this.xuClass,
            this.excuteDept,
            this.YBClass,
            this.IPNOQTYFLAG_INT,
            this.TotalDiffCost});
            this.m_dtvChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtvChangeList.Location = new System.Drawing.Point(0, 414);
            this.m_dtvChangeList.Name = "m_dtvChangeList";
            this.m_dtvChangeList.ReadOnly = true;
            this.m_dtvChangeList.RowHeadersVisible = false;
            this.m_dtvChangeList.RowTemplate.Height = 23;
            this.m_dtvChangeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvChangeList.Size = new System.Drawing.Size(1129, 142);
            this.m_dtvChangeList.TabIndex = 61;
            this.m_dtvChangeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvChangeList_CellDoubleClick);
            // 
            // seq
            // 
            this.seq.HeaderText = "序";
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            this.seq.Width = 30;
            // 
            // chargeName
            // 
            this.chargeName.HeaderText = "项目名称";
            this.chargeName.Name = "chargeName";
            this.chargeName.ReadOnly = true;
            this.chargeName.Width = 190;
            // 
            // ITEMSPEC_VCHR
            // 
            this.ITEMSPEC_VCHR.HeaderText = "规格";
            this.ITEMSPEC_VCHR.Name = "ITEMSPEC_VCHR";
            this.ITEMSPEC_VCHR.ReadOnly = true;
            // 
            // ChargeClass
            // 
            this.ChargeClass.HeaderText = "费用类型";
            this.ChargeClass.Name = "ChargeClass";
            this.ChargeClass.ReadOnly = true;
            this.ChargeClass.Width = 90;
            // 
            // ChargePrice
            // 
            this.ChargePrice.HeaderText = "单价";
            this.ChargePrice.Name = "ChargePrice";
            this.ChargePrice.ReadOnly = true;
            this.ChargePrice.Width = 80;
            // 
            // get_count
            // 
            this.get_count.HeaderText = "每次领量";
            this.get_count.Name = "get_count";
            this.get_count.ReadOnly = true;
            this.get_count.Width = 90;
            // 
            // countSum
            // 
            this.countSum.HeaderText = "合计金额";
            this.countSum.Name = "countSum";
            this.countSum.ReadOnly = true;
            this.countSum.Width = 90;
            // 
            // xuClass
            // 
            this.xuClass.HeaderText = "续用类型";
            this.xuClass.Name = "xuClass";
            this.xuClass.ReadOnly = true;
            this.xuClass.Width = 90;
            // 
            // excuteDept
            // 
            this.excuteDept.HeaderText = "执行科室";
            this.excuteDept.Name = "excuteDept";
            this.excuteDept.ReadOnly = true;
            // 
            // YBClass
            // 
            this.YBClass.HeaderText = "医保类型";
            this.YBClass.Name = "YBClass";
            this.YBClass.ReadOnly = true;
            this.YBClass.Width = 90;
            // 
            // IPNOQTYFLAG_INT
            // 
            this.IPNOQTYFLAG_INT.HeaderText = "药房";
            this.IPNOQTYFLAG_INT.Name = "IPNOQTYFLAG_INT";
            this.IPNOQTYFLAG_INT.ReadOnly = true;
            this.IPNOQTYFLAG_INT.Width = 60;
            // 
            // TotalDiffCost
            // 
            this.TotalDiffCost.HeaderText = "药品让利";
            this.TotalDiffCost.Name = "TotalDiffCost";
            this.TotalDiffCost.ReadOnly = true;
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.collapsibleSplitter1.ControlToHide = this.m_dtvChangeList;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(0, 406);
            this.collapsibleSplitter1.MinExtra = 20;
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(1129, 8);
            this.collapsibleSplitter1.TabIndex = 60;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // m_plChargeButtonList
            // 
            this.m_plChargeButtonList.Controls.Add(this.m_plChargeControl);
            this.m_plChargeButtonList.Controls.Add(this.m_btnPatientCharge);
            this.m_plChargeButtonList.Controls.Add(this.m_chkNeedFeel);
            this.m_plChargeButtonList.Controls.Add(this.m_cmdPrintFeel);
            this.m_plChargeButtonList.Controls.Add(this.m_lblNewOrderCount);
            this.m_plChargeButtonList.Controls.Add(this.m_txtSameCharge);
            this.m_plChargeButtonList.Controls.Add(this.m_txtChargeSum);
            this.m_plChargeButtonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_plChargeButtonList.Location = new System.Drawing.Point(0, 377);
            this.m_plChargeButtonList.Name = "m_plChargeButtonList";
            this.m_plChargeButtonList.Size = new System.Drawing.Size(1129, 29);
            this.m_plChargeButtonList.TabIndex = 62;
            // 
            // m_plChargeControl
            // 
            this.m_plChargeControl.Controls.Add(this.m_cmdChargeAdd);
            this.m_plChargeControl.Controls.Add(this.m_cmdChargeModify);
            this.m_plChargeControl.Controls.Add(this.m_cmdChargeDele);
            this.m_plChargeControl.Location = new System.Drawing.Point(716, 1);
            this.m_plChargeControl.Name = "m_plChargeControl";
            this.m_plChargeControl.Size = new System.Drawing.Size(218, 28);
            this.m_plChargeControl.TabIndex = 98;
            // 
            // m_cmdChargeAdd
            // 
            this.m_cmdChargeAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdChargeAdd.DefaultScheme = true;
            this.m_cmdChargeAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeAdd.Hint = "";
            this.m_cmdChargeAdd.Location = new System.Drawing.Point(3, 0);
            this.m_cmdChargeAdd.Name = "m_cmdChargeAdd";
            this.m_cmdChargeAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeAdd.Size = new System.Drawing.Size(73, 28);
            this.m_cmdChargeAdd.TabIndex = 24;
            this.m_cmdChargeAdd.Text = "新 增(&Z)";
            this.m_cmdChargeAdd.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdChargeModify
            // 
            this.m_cmdChargeModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdChargeModify.DefaultScheme = true;
            this.m_cmdChargeModify.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeModify.Hint = "";
            this.m_cmdChargeModify.Location = new System.Drawing.Point(76, 0);
            this.m_cmdChargeModify.Name = "m_cmdChargeModify";
            this.m_cmdChargeModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeModify.Size = new System.Drawing.Size(73, 28);
            this.m_cmdChargeModify.TabIndex = 25;
            this.m_cmdChargeModify.Text = "修 改(&C)";
            this.m_cmdChargeModify.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // m_cmdChargeDele
            // 
            this.m_cmdChargeDele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdChargeDele.DefaultScheme = true;
            this.m_cmdChargeDele.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeDele.Hint = "";
            this.m_cmdChargeDele.Location = new System.Drawing.Point(150, 0);
            this.m_cmdChargeDele.Name = "m_cmdChargeDele";
            this.m_cmdChargeDele.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeDele.Size = new System.Drawing.Size(65, 28);
            this.m_cmdChargeDele.TabIndex = 26;
            this.m_cmdChargeDele.Text = "删 除(&X)";
            this.m_cmdChargeDele.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // m_btnPatientCharge
            // 
            this.m_btnPatientCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPatientCharge.DefaultScheme = true;
            this.m_btnPatientCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPatientCharge.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnPatientCharge.Hint = "";
            this.m_btnPatientCharge.Location = new System.Drawing.Point(622, 1);
            this.m_btnPatientCharge.Name = "m_btnPatientCharge";
            this.m_btnPatientCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPatientCharge.Size = new System.Drawing.Size(91, 28);
            this.m_btnPatientCharge.TabIndex = 97;
            this.m_btnPatientCharge.Text = "病人费用";
            this.m_btnPatientCharge.Click += new System.EventHandler(this.m_btnPatientCharge_Click);
            // 
            // m_chkNeedFeel
            // 
            this.m_chkNeedFeel.AutoSize = true;
            this.m_chkNeedFeel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.m_chkNeedFeel.Location = new System.Drawing.Point(527, 5);
            this.m_chkNeedFeel.Name = "m_chkNeedFeel";
            this.m_chkNeedFeel.Size = new System.Drawing.Size(82, 18);
            this.m_chkNeedFeel.TabIndex = 31;
            this.m_chkNeedFeel.Text = "皮试过滤";
            this.m_chkNeedFeel.UseVisualStyleBackColor = true;
            this.m_chkNeedFeel.CheckedChanged += new System.EventHandler(this.m_chkNeedFeel_CheckedChanged);
            // 
            // m_cmdPrintFeel
            // 
            this.m_cmdPrintFeel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdPrintFeel.DefaultScheme = true;
            this.m_cmdPrintFeel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintFeel.Hint = "";
            this.m_cmdPrintFeel.Location = new System.Drawing.Point(934, 1);
            this.m_cmdPrintFeel.Name = "m_cmdPrintFeel";
            this.m_cmdPrintFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintFeel.Size = new System.Drawing.Size(74, 28);
            this.m_cmdPrintFeel.TabIndex = 30;
            this.m_cmdPrintFeel.Text = "打印皮试";
            this.m_cmdPrintFeel.Click += new System.EventHandler(this.m_cmdPrintFeel_Click);
            // 
            // m_lblNewOrderCount
            // 
            this.m_lblNewOrderCount.AutoSize = true;
            this.m_lblNewOrderCount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.m_lblNewOrderCount.Location = new System.Drawing.Point(441, 8);
            this.m_lblNewOrderCount.Name = "m_lblNewOrderCount";
            this.m_lblNewOrderCount.Size = new System.Drawing.Size(168, 14);
            this.m_lblNewOrderCount.TabIndex = 29;
            this.m_lblNewOrderCount.Text = "共有 病人有医嘱需要执行";
            this.m_lblNewOrderCount.Visible = false;
            // 
            // m_txtSameCharge
            // 
            this.m_txtSameCharge.AutoSize = true;
            this.m_txtSameCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtSameCharge.ForeColor = System.Drawing.Color.Red;
            this.m_txtSameCharge.Location = new System.Drawing.Point(245, 8);
            this.m_txtSameCharge.Name = "m_txtSameCharge";
            this.m_txtSameCharge.Size = new System.Drawing.Size(112, 14);
            this.m_txtSameCharge.TabIndex = 28;
            this.m_txtSameCharge.Text = "同方费用总计：";
            // 
            // m_txtChargeSum
            // 
            this.m_txtChargeSum.AutoSize = true;
            this.m_txtChargeSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtChargeSum.ForeColor = System.Drawing.Color.Red;
            this.m_txtChargeSum.Location = new System.Drawing.Point(16, 8);
            this.m_txtChargeSum.Name = "m_txtChargeSum";
            this.m_txtChargeSum.Size = new System.Drawing.Size(82, 14);
            this.m_txtChargeSum.TabIndex = 27;
            this.m_txtChargeSum.Text = "费用总计：";
            // 
            // m_dtvOrderList
            // 
            this.m_dtvOrderList.AllowUserToAddRows = false;
            this.m_dtvOrderList.AllowUserToResizeRows = false;
            this.m_dtvOrderList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvOrderList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtvOrderList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dtvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtv_bedcode,
            this.m_dtvLastName,
            this.inpatientid,
            this.dtv_RecipeNo,
            this.dtv_Case,
            this.dtv_ExecuteType,
            this.dtv_Name,
            this.dtv_REMARK,
            this.dtv_ENTRUST,
            this.viewname_vchr,
            this.dtv_Get,
            this.dtv_sum,
            this.pretestdays,
            this.ATTACHTIMES_INT,
            this.CREATOR_CHR,
            this.m_dtvPOSTDATE_DAT,
            this.m_dtvCONFIRMER_VCHR,
            this.m_dtvCONFIRM_DAT,
            this.m_dtvASSESSORFORSTOP_CHR,
            this.m_dtvASSESSORFORSTOP_DAT,
            this.DOCTOR_VCHR,
            this.dtv_Dosage,
            this.dtv_UseType,
            this.dtv_Freq,
            this.dtv_NO,
            this.m_dtvselectCheck,
            this.dtv_method,
            this.dtv_CURAREAName});
            this.m_dtvOrderList.ContextMenuStrip = this.m_ctMenuList;
            this.m_dtvOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dtvOrderList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dtvOrderList.Location = new System.Drawing.Point(0, 0);
            this.m_dtvOrderList.Name = "m_dtvOrderList";
            this.m_dtvOrderList.RowHeadersVisible = false;
            this.m_dtvOrderList.RowTemplate.Height = 23;
            this.m_dtvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvOrderList.Size = new System.Drawing.Size(1129, 377);
            this.m_dtvOrderList.TabIndex = 0;
            this.m_dtvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellDoubleClick);
            this.m_dtvOrderList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dtvOrderList_ColumnHeaderMouseClick);
            this.m_dtvOrderList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellEndEdit);
            this.m_dtvOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellClick);
            this.m_dtvOrderList.CurrentCellChanged += new System.EventHandler(this.m_dtvOrderList_CurrentCellChanged);
            // 
            // dtv_bedcode
            // 
            this.dtv_bedcode.HeaderText = "床号";
            this.dtv_bedcode.Name = "dtv_bedcode";
            this.dtv_bedcode.ReadOnly = true;
            this.dtv_bedcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_bedcode.Width = 35;
            // 
            // m_dtvLastName
            // 
            this.m_dtvLastName.HeaderText = "姓名";
            this.m_dtvLastName.Name = "m_dtvLastName";
            this.m_dtvLastName.ReadOnly = true;
            this.m_dtvLastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dtvLastName.Width = 70;
            // 
            // inpatientid
            // 
            this.inpatientid.HeaderText = "住院号";
            this.inpatientid.Name = "inpatientid";
            this.inpatientid.ReadOnly = true;
            this.inpatientid.Width = 80;
            // 
            // dtv_RecipeNo
            // 
            this.dtv_RecipeNo.HeaderText = "方";
            this.dtv_RecipeNo.Name = "dtv_RecipeNo";
            this.dtv_RecipeNo.ReadOnly = true;
            this.dtv_RecipeNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_RecipeNo.Width = 30;
            // 
            // dtv_Case
            // 
            this.dtv_Case.HeaderText = "状态";
            this.dtv_Case.Name = "dtv_Case";
            this.dtv_Case.ReadOnly = true;
            this.dtv_Case.Width = 30;
            // 
            // dtv_ExecuteType
            // 
            this.dtv_ExecuteType.HeaderText = "类型";
            this.dtv_ExecuteType.Name = "dtv_ExecuteType";
            this.dtv_ExecuteType.ReadOnly = true;
            this.dtv_ExecuteType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_ExecuteType.Width = 60;
            // 
            // dtv_Name
            // 
            this.dtv_Name.HeaderText = "医嘱内容";
            this.dtv_Name.Name = "dtv_Name";
            this.dtv_Name.ReadOnly = true;
            this.dtv_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Name.Width = 300;
            // 
            // dtv_REMARK
            // 
            this.dtv_REMARK.HeaderText = "说明";
            this.dtv_REMARK.Name = "dtv_REMARK";
            this.dtv_REMARK.ReadOnly = true;
            this.dtv_REMARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_REMARK.Width = 80;
            // 
            // dtv_ENTRUST
            // 
            this.dtv_ENTRUST.HeaderText = "嘱托";
            this.dtv_ENTRUST.Name = "dtv_ENTRUST";
            this.dtv_ENTRUST.ReadOnly = true;
            this.dtv_ENTRUST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_ENTRUST.Width = 80;
            // 
            // viewname_vchr
            // 
            this.viewname_vchr.HeaderText = "类别";
            this.viewname_vchr.Name = "viewname_vchr";
            this.viewname_vchr.ReadOnly = true;
            this.viewname_vchr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.viewname_vchr.Width = 60;
            // 
            // dtv_Get
            // 
            this.dtv_Get.HeaderText = "数量";
            this.dtv_Get.Name = "dtv_Get";
            this.dtv_Get.ReadOnly = true;
            this.dtv_Get.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Get.Width = 60;
            // 
            // dtv_sum
            // 
            this.dtv_sum.HeaderText = "总量";
            this.dtv_sum.Name = "dtv_sum";
            this.dtv_sum.ReadOnly = true;
            this.dtv_sum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_sum.Width = 80;
            // 
            // pretestdays
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pretestdays.DefaultCellStyle = dataGridViewCellStyle1;
            this.pretestdays.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.pretestdays.HeaderText = "预发(天)";
            this.pretestdays.Items.AddRange(new object[] {
            "",
            "1"});
            this.pretestdays.Name = "pretestdays";
            this.pretestdays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pretestdays.Width = 45;
            // 
            // ATTACHTIMES_INT
            // 
            this.ATTACHTIMES_INT.HeaderText = "补次";
            this.ATTACHTIMES_INT.Name = "ATTACHTIMES_INT";
            this.ATTACHTIMES_INT.ReadOnly = true;
            this.ATTACHTIMES_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ATTACHTIMES_INT.Visible = false;
            this.ATTACHTIMES_INT.Width = 30;
            // 
            // CREATOR_CHR
            // 
            this.CREATOR_CHR.HeaderText = "医生";
            this.CREATOR_CHR.Name = "CREATOR_CHR";
            this.CREATOR_CHR.ReadOnly = true;
            this.CREATOR_CHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_dtvPOSTDATE_DAT
            // 
            this.m_dtvPOSTDATE_DAT.HeaderText = "提交时间";
            this.m_dtvPOSTDATE_DAT.Name = "m_dtvPOSTDATE_DAT";
            this.m_dtvPOSTDATE_DAT.ReadOnly = true;
            this.m_dtvPOSTDATE_DAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dtvPOSTDATE_DAT.Width = 150;
            // 
            // m_dtvCONFIRMER_VCHR
            // 
            this.m_dtvCONFIRMER_VCHR.HeaderText = "审核人";
            this.m_dtvCONFIRMER_VCHR.Name = "m_dtvCONFIRMER_VCHR";
            this.m_dtvCONFIRMER_VCHR.ReadOnly = true;
            this.m_dtvCONFIRMER_VCHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dtvCONFIRMER_VCHR.Width = 80;
            // 
            // m_dtvCONFIRM_DAT
            // 
            this.m_dtvCONFIRM_DAT.HeaderText = "审核时间";
            this.m_dtvCONFIRM_DAT.Name = "m_dtvCONFIRM_DAT";
            this.m_dtvCONFIRM_DAT.ReadOnly = true;
            this.m_dtvCONFIRM_DAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dtvCONFIRM_DAT.Width = 80;
            // 
            // m_dtvASSESSORFORSTOP_CHR
            // 
            this.m_dtvASSESSORFORSTOP_CHR.HeaderText = "审核停止人";
            this.m_dtvASSESSORFORSTOP_CHR.Name = "m_dtvASSESSORFORSTOP_CHR";
            this.m_dtvASSESSORFORSTOP_CHR.ReadOnly = true;
            this.m_dtvASSESSORFORSTOP_CHR.Width = 80;
            // 
            // m_dtvASSESSORFORSTOP_DAT
            // 
            this.m_dtvASSESSORFORSTOP_DAT.HeaderText = "审核停止时间";
            this.m_dtvASSESSORFORSTOP_DAT.Name = "m_dtvASSESSORFORSTOP_DAT";
            this.m_dtvASSESSORFORSTOP_DAT.ReadOnly = true;
            this.m_dtvASSESSORFORSTOP_DAT.Width = 80;
            // 
            // DOCTOR_VCHR
            // 
            this.DOCTOR_VCHR.HeaderText = "主管医生";
            this.DOCTOR_VCHR.Name = "DOCTOR_VCHR";
            this.DOCTOR_VCHR.ReadOnly = true;
            this.DOCTOR_VCHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOCTOR_VCHR.Visible = false;
            // 
            // dtv_Dosage
            // 
            this.dtv_Dosage.HeaderText = "剂量";
            this.dtv_Dosage.Name = "dtv_Dosage";
            this.dtv_Dosage.ReadOnly = true;
            this.dtv_Dosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Dosage.Visible = false;
            this.dtv_Dosage.Width = 60;
            // 
            // dtv_UseType
            // 
            this.dtv_UseType.HeaderText = "用法";
            this.dtv_UseType.Name = "dtv_UseType";
            this.dtv_UseType.ReadOnly = true;
            this.dtv_UseType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_UseType.Visible = false;
            this.dtv_UseType.Width = 60;
            // 
            // dtv_Freq
            // 
            this.dtv_Freq.HeaderText = "频率";
            this.dtv_Freq.Name = "dtv_Freq";
            this.dtv_Freq.ReadOnly = true;
            this.dtv_Freq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_Freq.Visible = false;
            this.dtv_Freq.Width = 60;
            // 
            // dtv_NO
            // 
            this.dtv_NO.HeaderText = "序";
            this.dtv_NO.Name = "dtv_NO";
            this.dtv_NO.ReadOnly = true;
            this.dtv_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtv_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_NO.Visible = false;
            this.dtv_NO.Width = 30;
            // 
            // m_dtvselectCheck
            // 
            this.m_dtvselectCheck.FalseValue = "0";
            this.m_dtvselectCheck.HeaderText = "";
            this.m_dtvselectCheck.Name = "m_dtvselectCheck";
            this.m_dtvselectCheck.ReadOnly = true;
            this.m_dtvselectCheck.TrueValue = "1";
            this.m_dtvselectCheck.Visible = false;
            this.m_dtvselectCheck.Width = 20;
            // 
            // dtv_method
            // 
            this.dtv_method.HeaderText = "方法";
            this.dtv_method.Name = "dtv_method";
            this.dtv_method.ReadOnly = true;
            this.dtv_method.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_method.Visible = false;
            this.dtv_method.Width = 60;
            // 
            // dtv_CURAREAName
            // 
            this.dtv_CURAREAName.HeaderText = "病区名称";
            this.dtv_CURAREAName.Name = "dtv_CURAREAName";
            this.dtv_CURAREAName.ReadOnly = true;
            this.dtv_CURAREAName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_CURAREAName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 85;
            this.label1.Text = "病 区";
            // 
            // m_chkSelectAll
            // 
            this.m_chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.m_chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSelectAll.Location = new System.Drawing.Point(367, 605);
            this.m_chkSelectAll.Name = "m_chkSelectAll";
            this.m_chkSelectAll.Size = new System.Drawing.Size(60, 24);
            this.m_chkSelectAll.TabIndex = 92;
            this.m_chkSelectAll.Text = "全选";
            this.m_chkSelectAll.UseVisualStyleBackColor = false;
            this.m_chkSelectAll.Visible = false;
            this.m_chkSelectAll.CheckedChanged += new System.EventHandler(this.m_chkSelectAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 582);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 89;
            this.label2.Text = "审核状态";
            // 
            // m_txtBedNo2
            // 
            this.m_txtBedNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBedNo2.Location = new System.Drawing.Point(268, 580);
            this.m_txtBedNo2.Name = "m_txtBedNo2";
            this.m_txtBedNo2.Size = new System.Drawing.Size(63, 23);
            this.m_txtBedNo2.TabIndex = 126;
            this.m_txtBedNo2.DoubleClick += new System.EventHandler(this.m_txtBedNo2_DoubleClick);
            this.m_txtBedNo2.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtBedNo2_m_evtSelectItem);
            this.m_txtBedNo2.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtBedNo2_m_evtFindItem);
            this.m_txtBedNo2.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtBedNo2_m_evtInitListView);
            // 
            // m_ctlPatient
            // 
            this.m_ctlPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ctlPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctlPatient.Location = new System.Drawing.Point(0, 0);
            this.m_ctlPatient.Name = "m_ctlPatient";
            this.m_ctlPatient.Size = new System.Drawing.Size(1016, 73);
            this.m_ctlPatient.TabIndex = 82;
            this.m_ctlPatient.Visible = false;
            // 
            // frmOrderNurseConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 627);
            this.Controls.Add(this.m_cmdToExecute);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdEditFeel);
            this.Controls.Add(this.m_txtBedNo2);
            this.Controls.Add(this.m_btnBedList);
            this.Controls.Add(this.m_cboCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdRefurbish);
            this.Controls.Add(this.m_cmdRedraw);
            this.Controls.Add(this.m_cmdBack);
            this.Controls.Add(this.m_cmdToCommit);
            this.Controls.Add(this.m_txtArea);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_ctlPatient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_chkSelectAll);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOrderNurseConfirm";
            this.Text = "医嘱核对";
            this.Load += new System.EventHandler(this.frmOrderNurseConfirm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderNurseConfirm_KeyDown);
            this.m_ctMenuList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).EndInit();
            this.m_plChargeButtonList.ResumeLayout(false);
            this.m_plChargeButtonList.PerformLayout();
            this.m_plChargeControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.CheckBox m_chkSelectAll;
        internal PinkieControls.ButtonXP m_cmdToCommit;
        internal PinkieControls.ButtonXP m_cmdExit;
        internal PinkieControls.ButtonXP m_cmdBack;
        internal PinkieControls.ButtonXP m_cmdRedraw;
        public System.Windows.Forms.DataGridView m_dtvOrderList;
        public com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo m_ctlPatient;
        public System.Windows.Forms.DataGridView m_dtvChangeList;
        public System.Windows.Forms.RadioButton m_rdoNOT;
        public System.Windows.Forms.RadioButton m_rdoAll;
        public System.Windows.Forms.RadioButton m_rdoYET;
        private System.Windows.Forms.Panel m_plChargeButtonList;
        public System.Windows.Forms.Label m_txtChargeSum;
        public System.Windows.Forms.Label m_txtSameCharge;
        private PinkieControls.ButtonXP cmdRefurbish;
        public System.Windows.Forms.Label m_lblNewOrderCount;
        public com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtBedNo2;
        private System.Windows.Forms.Button m_btnBedList;
        internal System.Windows.Forms.ComboBox m_cboCode;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP m_cmdEditFeel;
        internal PinkieControls.ButtonXP m_cmdChargeAdd;
        internal PinkieControls.ButtonXP m_cmdChargeModify;
        internal PinkieControls.ButtonXP m_cmdChargeDele;
        internal PinkieControls.ButtonXP m_cmdPrintFeel;
        internal System.Windows.Forms.Timer m_timerMessage;
        internal System.Windows.Forms.CheckBox m_chkNeedFeel;
        internal PinkieControls.ButtonXP m_cmdToExecute;
        internal PinkieControls.ButtonXP m_btnPatientCharge;
        internal System.Windows.Forms.Panel m_plChargeControl;
        internal System.Windows.Forms.ContextMenuStrip m_ctMenuList;
        private System.Windows.Forms.ToolStripMenuItem m_ItemRedrawback;
        internal System.Windows.Forms.ToolStripMenuItem m_ItemCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMSPEC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn get_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn countSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn excuteDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPNOQTYFLAG_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiffCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_bedcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpatientid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_RecipeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Case;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_ExecuteType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_ENTRUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Get;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_sum;
        private System.Windows.Forms.DataGridViewComboBoxColumn pretestdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTACHTIMES_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATOR_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvPOSTDATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvCONFIRMER_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvCONFIRM_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvASSESSORFORSTOP_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvASSESSORFORSTOP_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_UseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_NO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dtvselectCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_CURAREAName;
    }
}