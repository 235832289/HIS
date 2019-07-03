namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmOrderExecute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderExecute));
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
            this.m_btnPatientCharge = new PinkieControls.ButtonXP();
            this.m_lblNewOrderCount = new System.Windows.Forms.Label();
            this.m_txtSameCharge = new System.Windows.Forms.Label();
            this.m_txtChargeSum = new System.Windows.Forms.Label();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_chkSelectAll = new System.Windows.Forms.CheckBox();
            this.m_dtvOrderList = new System.Windows.Forms.DataGridView();
            this.m_dtvselectCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtv_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_bedcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_RecipeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Case = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ExecuteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Get = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTACHTIMES_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretestdays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATOR_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_UseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvPOSTDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvCONFIRMER_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvCONFIRM_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ENTRUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DEPTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ctMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_ItemComfirmRun = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ctlPatient = new com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboCode = new System.Windows.Forms.ComboBox();
            this.m_cmdMedicineSend = new PinkieControls.ButtonXP();
            this.m_cmdMedicineSee = new PinkieControls.ButtonXP();
            this.m_cmdToRedraw = new PinkieControls.ButtonXP();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rdoYET = new System.Windows.Forms.RadioButton();
            this.m_rdoNOT = new System.Windows.Forms.RadioButton();
            this.m_rdoAll = new System.Windows.Forms.RadioButton();
            this.m_btnBedList = new System.Windows.Forms.Button();
            this.m_txtBedNo2 = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.cmdRefurbish = new PinkieControls.ButtonXP();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.m_plControls = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cboState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkLong = new System.Windows.Forms.CheckBox();
            this.m_chkOut = new System.Windows.Forms.CheckBox();
            this.m_chkShort = new System.Windows.Forms.CheckBox();
            this.m_chkReExcute = new System.Windows.Forms.CheckBox();
            this.m_cmdToCommitAll = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).BeginInit();
            this.m_plChargeButtonList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).BeginInit();
            this.m_ctMenuList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_plControls.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dtvChangeList);
            this.panel1.Controls.Add(this.collapsibleSplitter1);
            this.panel1.Controls.Add(this.m_plChargeButtonList);
            this.panel1.Controls.Add(this.m_dtvOrderList);
            this.panel1.Controls.Add(this.m_ctlPatient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 551);
            this.panel1.TabIndex = 84;
            // 
            // m_dtvChangeList
            // 
            this.m_dtvChangeList.AllowUserToAddRows = false;
            this.m_dtvChangeList.AllowUserToDeleteRows = false;
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
            this.m_dtvChangeList.Location = new System.Drawing.Point(0, 412);
            this.m_dtvChangeList.MultiSelect = false;
            this.m_dtvChangeList.Name = "m_dtvChangeList";
            this.m_dtvChangeList.ReadOnly = true;
            this.m_dtvChangeList.RowHeadersVisible = false;
            this.m_dtvChangeList.RowTemplate.Height = 23;
            this.m_dtvChangeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvChangeList.Size = new System.Drawing.Size(1016, 139);
            this.m_dtvChangeList.TabIndex = 86;
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
            this.chargeName.Width = 200;
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
            this.excuteDept.Width = 90;
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
            this.collapsibleSplitter1.ControlToHide = null;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(0, 404);
            this.collapsibleSplitter1.MinExtra = 20;
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(1016, 8);
            this.collapsibleSplitter1.TabIndex = 85;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // m_plChargeButtonList
            // 
            this.m_plChargeButtonList.Controls.Add(this.m_btnPatientCharge);
            this.m_plChargeButtonList.Controls.Add(this.m_lblNewOrderCount);
            this.m_plChargeButtonList.Controls.Add(this.m_txtSameCharge);
            this.m_plChargeButtonList.Controls.Add(this.m_txtChargeSum);
            this.m_plChargeButtonList.Controls.Add(this.buttonXP3);
            this.m_plChargeButtonList.Controls.Add(this.buttonXP2);
            this.m_plChargeButtonList.Controls.Add(this.buttonXP1);
            this.m_plChargeButtonList.Controls.Add(this.m_chkSelectAll);
            this.m_plChargeButtonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_plChargeButtonList.Location = new System.Drawing.Point(0, 374);
            this.m_plChargeButtonList.Name = "m_plChargeButtonList";
            this.m_plChargeButtonList.Size = new System.Drawing.Size(1016, 30);
            this.m_plChargeButtonList.TabIndex = 87;
            // 
            // m_btnPatientCharge
            // 
            this.m_btnPatientCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPatientCharge.DefaultScheme = true;
            this.m_btnPatientCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPatientCharge.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnPatientCharge.Hint = "";
            this.m_btnPatientCharge.Location = new System.Drawing.Point(896, 2);
            this.m_btnPatientCharge.Name = "m_btnPatientCharge";
            this.m_btnPatientCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPatientCharge.Size = new System.Drawing.Size(107, 28);
            this.m_btnPatientCharge.TabIndex = 123;
            this.m_btnPatientCharge.Text = "病人费用";
            this.m_btnPatientCharge.Click += new System.EventHandler(this.m_btnPatientCharge_Click);
            // 
            // m_lblNewOrderCount
            // 
            this.m_lblNewOrderCount.AutoSize = true;
            this.m_lblNewOrderCount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.m_lblNewOrderCount.Location = new System.Drawing.Point(437, 8);
            this.m_lblNewOrderCount.Name = "m_lblNewOrderCount";
            this.m_lblNewOrderCount.Size = new System.Drawing.Size(168, 14);
            this.m_lblNewOrderCount.TabIndex = 31;
            this.m_lblNewOrderCount.Text = "共有 病人有医嘱需要执行";
            // 
            // m_txtSameCharge
            // 
            this.m_txtSameCharge.AutoSize = true;
            this.m_txtSameCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtSameCharge.ForeColor = System.Drawing.Color.Red;
            this.m_txtSameCharge.Location = new System.Drawing.Point(238, 8);
            this.m_txtSameCharge.Name = "m_txtSameCharge";
            this.m_txtSameCharge.Size = new System.Drawing.Size(112, 14);
            this.m_txtSameCharge.TabIndex = 30;
            this.m_txtSameCharge.Text = "同方费用总计：";
            // 
            // m_txtChargeSum
            // 
            this.m_txtChargeSum.AutoSize = true;
            this.m_txtChargeSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtChargeSum.ForeColor = System.Drawing.Color.Red;
            this.m_txtChargeSum.Location = new System.Drawing.Point(11, 8);
            this.m_txtChargeSum.Name = "m_txtChargeSum";
            this.m_txtChargeSum.Size = new System.Drawing.Size(82, 14);
            this.m_txtChargeSum.TabIndex = 29;
            this.m_txtChargeSum.Text = "费用总计：";
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(930, 2);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(79, 28);
            this.buttonXP3.TabIndex = 26;
            this.buttonXP3.Text = "删 除(&X)";
            this.buttonXP3.Visible = false;
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(842, 2);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(79, 28);
            this.buttonXP2.TabIndex = 25;
            this.buttonXP2.Text = "修 改(&C)";
            this.buttonXP2.Visible = false;
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(757, 2);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(79, 28);
            this.buttonXP1.TabIndex = 24;
            this.buttonXP1.Text = "新 增(&Z)";
            this.buttonXP1.Visible = false;
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_chkSelectAll
            // 
            this.m_chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.m_chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSelectAll.Location = new System.Drawing.Point(663, 4);
            this.m_chkSelectAll.Name = "m_chkSelectAll";
            this.m_chkSelectAll.Size = new System.Drawing.Size(62, 24);
            this.m_chkSelectAll.TabIndex = 122;
            this.m_chkSelectAll.Text = "全选";
            this.m_chkSelectAll.UseVisualStyleBackColor = false;
            this.m_chkSelectAll.Visible = false;
            this.m_chkSelectAll.CheckedChanged += new System.EventHandler(this.m_chkSelectAll_CheckedChanged);
            // 
            // m_dtvOrderList
            // 
            this.m_dtvOrderList.AllowUserToAddRows = false;
            this.m_dtvOrderList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvOrderList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtvOrderList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dtvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dtvselectCheck,
            this.dtv_NO,
            this.dtv_bedcode,
            this.m_dtvLastName,
            this.dtv_RecipeNo,
            this.dtv_Case,
            this.dtv_ExecuteType,
            this.dtv_Name,
            this.dtv_REMARK,
            this.viewname_vchr,
            this.dtv_Get,
            this.dtv_sum,
            this.ATTACHTIMES_INT,
            this.pretestdays,
            this.CREATOR_CHR,
            this.dtv_Dosage,
            this.dtv_UseType,
            this.dtv_Freq,
            this.m_dtvPOSTDATE_DAT,
            this.m_dtvCONFIRMER_VCHR,
            this.m_dtvCONFIRM_DAT,
            this.DOCTOR_VCHR,
            this.dtv_method,
            this.dtv_ENTRUST,
            this.dtv_DEPTNAME_VCHR});
            this.m_dtvOrderList.ContextMenuStrip = this.m_ctMenuList;
            this.m_dtvOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dtvOrderList.Location = new System.Drawing.Point(0, 0);
            this.m_dtvOrderList.Name = "m_dtvOrderList";
            this.m_dtvOrderList.ReadOnly = true;
            this.m_dtvOrderList.RowHeadersVisible = false;
            this.m_dtvOrderList.RowTemplate.Height = 23;
            this.m_dtvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvOrderList.Size = new System.Drawing.Size(1016, 374);
            this.m_dtvOrderList.TabIndex = 84;
            this.m_dtvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellDoubleClick);
            this.m_dtvOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderList_CellClick);
            this.m_dtvOrderList.CurrentCellChanged += new System.EventHandler(this.m_dtvOrderList_CurrentCellChanged);
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
            this.m_dtvLastName.Width = 80;
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
            this.dtv_Case.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // ATTACHTIMES_INT
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ATTACHTIMES_INT.DefaultCellStyle = dataGridViewCellStyle1;
            this.ATTACHTIMES_INT.HeaderText = "补次";
            this.ATTACHTIMES_INT.Name = "ATTACHTIMES_INT";
            this.ATTACHTIMES_INT.ReadOnly = true;
            this.ATTACHTIMES_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ATTACHTIMES_INT.Visible = false;
            this.ATTACHTIMES_INT.Width = 30;
            // 
            // pretestdays
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pretestdays.DefaultCellStyle = dataGridViewCellStyle2;
            this.pretestdays.HeaderText = "预发(天)";
            this.pretestdays.Name = "pretestdays";
            this.pretestdays.ReadOnly = true;
            this.pretestdays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pretestdays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pretestdays.Width = 45;
            // 
            // CREATOR_CHR
            // 
            this.CREATOR_CHR.HeaderText = "医生";
            this.CREATOR_CHR.Name = "CREATOR_CHR";
            this.CREATOR_CHR.ReadOnly = true;
            this.CREATOR_CHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // 
            // m_dtvCONFIRM_DAT
            // 
            this.m_dtvCONFIRM_DAT.HeaderText = "审核时间";
            this.m_dtvCONFIRM_DAT.Name = "m_dtvCONFIRM_DAT";
            this.m_dtvCONFIRM_DAT.ReadOnly = true;
            this.m_dtvCONFIRM_DAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOCTOR_VCHR
            // 
            this.DOCTOR_VCHR.HeaderText = "主管医生";
            this.DOCTOR_VCHR.Name = "DOCTOR_VCHR";
            this.DOCTOR_VCHR.ReadOnly = true;
            this.DOCTOR_VCHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOCTOR_VCHR.Visible = false;
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
            // dtv_ENTRUST
            // 
            this.dtv_ENTRUST.HeaderText = "嘱托";
            this.dtv_ENTRUST.Name = "dtv_ENTRUST";
            this.dtv_ENTRUST.ReadOnly = true;
            this.dtv_ENTRUST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_ENTRUST.Visible = false;
            // 
            // dtv_DEPTNAME_VCHR
            // 
            this.dtv_DEPTNAME_VCHR.HeaderText = "病区名称";
            this.dtv_DEPTNAME_VCHR.Name = "dtv_DEPTNAME_VCHR";
            this.dtv_DEPTNAME_VCHR.ReadOnly = true;
            this.dtv_DEPTNAME_VCHR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtv_DEPTNAME_VCHR.Visible = false;
            // 
            // m_ctMenuList
            // 
            this.m_ctMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ItemComfirmRun});
            this.m_ctMenuList.Name = "m_ctMenuList";
            this.m_ctMenuList.Size = new System.Drawing.Size(125, 26);
            this.m_ctMenuList.Opening += new System.ComponentModel.CancelEventHandler(this.m_ctMenuList_Opening);
            // 
            // m_ItemComfirmRun
            // 
            this.m_ItemComfirmRun.Name = "m_ItemComfirmRun";
            this.m_ItemComfirmRun.Size = new System.Drawing.Size(124, 22);
            this.m_ItemComfirmRun.Text = "确认执行";
            this.m_ItemComfirmRun.Click += new System.EventHandler(this.m_ItemComfirmRun_Click);
            // 
            // m_ctlPatient
            // 
            this.m_ctlPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ctlPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctlPatient.Location = new System.Drawing.Point(0, 0);
            this.m_ctlPatient.Name = "m_ctlPatient";
            this.m_ctlPatient.Size = new System.Drawing.Size(1014, 73);
            this.m_ctlPatient.TabIndex = 83;
            this.m_ctlPatient.Visible = false;
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(897, 32);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(104, 26);
            this.m_cmdCancel.TabIndex = 104;
            this.m_cmdCancel.Text = "退出 Esc";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(640, 7);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(92, 26);
            this.m_cmdToCommit.TabIndex = 103;
            this.m_cmdToCommit.Text = "选择执行 F1";
            this.m_cmdToCommit.Visible = false;
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "执行状态";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 113;
            this.label3.Text = "床号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboCode
            // 
            this.m_cboCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCode.Font = new System.Drawing.Font("宋体", 11F);
            this.m_cboCode.Items.AddRange(new object[] {
            "全区",
            "个人"});
            this.m_cboCode.Location = new System.Drawing.Point(155, 17);
            this.m_cboCode.Name = "m_cboCode";
            this.m_cboCode.Size = new System.Drawing.Size(69, 23);
            this.m_cboCode.TabIndex = 1;
            this.m_cboCode.SelectedValueChanged += new System.EventHandler(this.m_cboCode_SelectedValueChanged);
            this.m_cboCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboCode_KeyDown);
            // 
            // m_cmdMedicineSend
            // 
            this.m_cmdMedicineSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdMedicineSend.DefaultScheme = true;
            this.m_cmdMedicineSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdMedicineSend.Hint = "";
            this.m_cmdMedicineSend.Location = new System.Drawing.Point(829, 7);
            this.m_cmdMedicineSend.Name = "m_cmdMedicineSend";
            this.m_cmdMedicineSend.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdMedicineSend.Size = new System.Drawing.Size(97, 26);
            this.m_cmdMedicineSend.TabIndex = 116;
            this.m_cmdMedicineSend.Text = "摆药申请 F3";
            this.m_cmdMedicineSend.Visible = false;
            this.m_cmdMedicineSend.Click += new System.EventHandler(this.m_cmdSendOrder_Click);
            // 
            // m_cmdMedicineSee
            // 
            this.m_cmdMedicineSee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdMedicineSee.DefaultScheme = true;
            this.m_cmdMedicineSee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdMedicineSee.Hint = "";
            this.m_cmdMedicineSee.Location = new System.Drawing.Point(732, 33);
            this.m_cmdMedicineSee.Name = "m_cmdMedicineSee";
            this.m_cmdMedicineSee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdMedicineSee.Size = new System.Drawing.Size(158, 26);
            this.m_cmdMedicineSee.TabIndex = 117;
            this.m_cmdMedicineSee.Text = "察看全区摆药申请 &S";
            this.m_cmdMedicineSee.Click += new System.EventHandler(this.m_cmdAreaPutStatus_Click);
            // 
            // m_cmdToRedraw
            // 
            this.m_cmdToRedraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToRedraw.DefaultScheme = true;
            this.m_cmdToRedraw.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToRedraw.Hint = "";
            this.m_cmdToRedraw.Location = new System.Drawing.Point(602, 37);
            this.m_cmdToRedraw.Name = "m_cmdToRedraw";
            this.m_cmdToRedraw.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToRedraw.Size = new System.Drawing.Size(98, 26);
            this.m_cmdToRedraw.TabIndex = 118;
            this.m_cmdToRedraw.Text = "取消执行 F3";
            this.m_cmdToRedraw.Visible = false;
            this.m_cmdToRedraw.Click += new System.EventHandler(this.m_cmdToRedraw_Click);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(46, 17);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(107, 23);
            this.m_txtArea.TabIndex = 0;
            this.m_txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtArea_KeyDown);
            this.m_txtArea.DoubleClick += new System.EventHandler(this.m_txtArea_DoubleClick);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 120;
            this.label1.Text = "病 区";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rdoYET);
            this.groupBox2.Controls.Add(this.m_rdoNOT);
            this.groupBox2.Controls.Add(this.m_rdoAll);
            this.groupBox2.Location = new System.Drawing.Point(415, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 42);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // m_rdoYET
            // 
            this.m_rdoYET.AutoSize = true;
            this.m_rdoYET.Location = new System.Drawing.Point(97, 17);
            this.m_rdoYET.Name = "m_rdoYET";
            this.m_rdoYET.Size = new System.Drawing.Size(67, 18);
            this.m_rdoYET.TabIndex = 86;
            this.m_rdoYET.Text = "已执行";
            this.m_rdoYET.UseVisualStyleBackColor = true;
            this.m_rdoYET.CheckedChanged += new System.EventHandler(this.m_rdoYET_CheckedChanged);
            // 
            // m_rdoNOT
            // 
            this.m_rdoNOT.AutoSize = true;
            this.m_rdoNOT.Checked = true;
            this.m_rdoNOT.Location = new System.Drawing.Point(24, 17);
            this.m_rdoNOT.Name = "m_rdoNOT";
            this.m_rdoNOT.Size = new System.Drawing.Size(67, 18);
            this.m_rdoNOT.TabIndex = 87;
            this.m_rdoNOT.TabStop = true;
            this.m_rdoNOT.Text = "未执行";
            this.m_rdoNOT.UseVisualStyleBackColor = true;
            this.m_rdoNOT.CheckedChanged += new System.EventHandler(this.m_rdoNOT_CheckedChanged);
            // 
            // m_rdoAll
            // 
            this.m_rdoAll.AutoSize = true;
            this.m_rdoAll.Location = new System.Drawing.Point(170, 17);
            this.m_rdoAll.Name = "m_rdoAll";
            this.m_rdoAll.Size = new System.Drawing.Size(53, 18);
            this.m_rdoAll.TabIndex = 88;
            this.m_rdoAll.Text = "全部";
            this.m_rdoAll.UseVisualStyleBackColor = true;
            this.m_rdoAll.Visible = false;
            this.m_rdoAll.CheckedChanged += new System.EventHandler(this.m_rdoAll_CheckedChanged);
            // 
            // m_btnBedList
            // 
            this.m_btnBedList.Location = new System.Drawing.Point(325, 16);
            this.m_btnBedList.Name = "m_btnBedList";
            this.m_btnBedList.Size = new System.Drawing.Size(19, 23);
            this.m_btnBedList.TabIndex = 124;
            this.m_btnBedList.Text = "↓";
            this.m_btnBedList.UseVisualStyleBackColor = true;
            this.m_btnBedList.Click += new System.EventHandler(this.m_btnBedList_Click);
            // 
            // m_txtBedNo2
            // 
            this.m_txtBedNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBedNo2.Location = new System.Drawing.Point(262, 16);
            this.m_txtBedNo2.Name = "m_txtBedNo2";
            this.m_txtBedNo2.Size = new System.Drawing.Size(63, 23);
            this.m_txtBedNo2.TabIndex = 2;
            this.m_txtBedNo2.DoubleClick += new System.EventHandler(this.m_txtBedNo2_DoubleClick);
            this.m_txtBedNo2.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtBedNo2_m_evtSelectItem);
            this.m_txtBedNo2.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtBedNo2_m_evtFindItem);
            this.m_txtBedNo2.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtBedNo2_m_evtInitListView);
            // 
            // cmdRefurbish
            // 
            this.cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdRefurbish.DefaultScheme = true;
            this.cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefurbish.Hint = "";
            this.cmdRefurbish.Location = new System.Drawing.Point(897, 5);
            this.cmdRefurbish.Name = "cmdRefurbish";
            this.cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefurbish.Size = new System.Drawing.Size(104, 26);
            this.cmdRefurbish.TabIndex = 125;
            this.cmdRefurbish.Text = "刷新 F4";
            this.cmdRefurbish.Click += new System.EventHandler(this.cmdRefurbish_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // m_plControls
            // 
            this.m_plControls.Controls.Add(this.panel2);
            this.m_plControls.Controls.Add(this.m_chkReExcute);
            this.m_plControls.Controls.Add(this.m_cmdToCommitAll);
            this.m_plControls.Controls.Add(this.cmdRefurbish);
            this.m_plControls.Controls.Add(this.m_txtBedNo2);
            this.m_plControls.Controls.Add(this.m_cmdToRedraw);
            this.m_plControls.Controls.Add(this.m_cmdMedicineSee);
            this.m_plControls.Controls.Add(this.m_cmdMedicineSend);
            this.m_plControls.Controls.Add(this.label2);
            this.m_plControls.Controls.Add(this.m_cmdCancel);
            this.m_plControls.Controls.Add(this.groupBox2);
            this.m_plControls.Controls.Add(this.m_cmdToCommit);
            this.m_plControls.Controls.Add(this.m_btnBedList);
            this.m_plControls.Controls.Add(this.m_cboCode);
            this.m_plControls.Controls.Add(this.label3);
            this.m_plControls.Controls.Add(this.label1);
            this.m_plControls.Controls.Add(this.m_txtArea);
            this.m_plControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_plControls.Location = new System.Drawing.Point(0, 551);
            this.m_plControls.Name = "m_plControls";
            this.m_plControls.Size = new System.Drawing.Size(1016, 63);
            this.m_plControls.TabIndex = 126;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cboState);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_chkLong);
            this.panel2.Controls.Add(this.m_chkOut);
            this.panel2.Controls.Add(this.m_chkShort);
            this.panel2.Location = new System.Drawing.Point(344, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 36);
            this.panel2.TabIndex = 130;
            // 
            // m_cboState
            // 
            this.m_cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboState.Font = new System.Drawing.Font("宋体", 11F);
            this.m_cboState.Items.AddRange(new object[] {
            "全部医嘱",
            "新医嘱口服",
            "新医嘱非口服",
            "旧医嘱口服",
            "旧医嘱非口服"});
            this.m_cboState.Location = new System.Drawing.Point(3, 7);
            this.m_cboState.Name = "m_cboState";
            this.m_cboState.Size = new System.Drawing.Size(121, 23);
            this.m_cboState.TabIndex = 131;
            this.m_cboState.SelectedIndexChanged += new System.EventHandler(this.m_cboState_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(125, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 130;
            this.label4.Text = "状态:";
            // 
            // m_chkLong
            // 
            this.m_chkLong.AutoSize = true;
            this.m_chkLong.Checked = true;
            this.m_chkLong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkLong.Location = new System.Drawing.Point(170, 10);
            this.m_chkLong.Name = "m_chkLong";
            this.m_chkLong.Size = new System.Drawing.Size(40, 18);
            this.m_chkLong.TabIndex = 128;
            this.m_chkLong.Text = "长";
            this.m_chkLong.UseVisualStyleBackColor = true;
            this.m_chkLong.CheckedChanged += new System.EventHandler(this.m_chkLong_CheckedChanged);
            // 
            // m_chkOut
            // 
            this.m_chkOut.AutoSize = true;
            this.m_chkOut.Checked = true;
            this.m_chkOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkOut.Location = new System.Drawing.Point(260, 10);
            this.m_chkOut.Name = "m_chkOut";
            this.m_chkOut.Size = new System.Drawing.Size(40, 18);
            this.m_chkOut.TabIndex = 129;
            this.m_chkOut.Text = "带";
            this.m_chkOut.UseVisualStyleBackColor = true;
            this.m_chkOut.CheckedChanged += new System.EventHandler(this.m_chkOut_CheckedChanged);
            // 
            // m_chkShort
            // 
            this.m_chkShort.AutoSize = true;
            this.m_chkShort.Checked = true;
            this.m_chkShort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkShort.Location = new System.Drawing.Point(215, 10);
            this.m_chkShort.Name = "m_chkShort";
            this.m_chkShort.Size = new System.Drawing.Size(40, 18);
            this.m_chkShort.TabIndex = 128;
            this.m_chkShort.Text = "临";
            this.m_chkShort.UseVisualStyleBackColor = true;
            this.m_chkShort.CheckedChanged += new System.EventHandler(this.m_chkShort_CheckedChanged);
            // 
            // m_chkReExcute
            // 
            this.m_chkReExcute.AutoSize = true;
            this.m_chkReExcute.Checked = true;
            this.m_chkReExcute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkReExcute.ForeColor = System.Drawing.Color.Red;
            this.m_chkReExcute.Location = new System.Drawing.Point(650, 37);
            this.m_chkReExcute.Name = "m_chkReExcute";
            this.m_chkReExcute.Size = new System.Drawing.Size(82, 18);
            this.m_chkReExcute.TabIndex = 127;
            this.m_chkReExcute.Text = "补漏执行";
            this.m_chkReExcute.UseVisualStyleBackColor = true;
            this.m_chkReExcute.CheckedChanged += new System.EventHandler(this.m_chkReExcute_CheckedChanged);
            // 
            // m_cmdToCommitAll
            // 
            this.m_cmdToCommitAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdToCommitAll.DefaultScheme = true;
            this.m_cmdToCommitAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommitAll.Hint = "";
            this.m_cmdToCommitAll.Location = new System.Drawing.Point(732, 6);
            this.m_cmdToCommitAll.Name = "m_cmdToCommitAll";
            this.m_cmdToCommitAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommitAll.Size = new System.Drawing.Size(158, 26);
            this.m_cmdToCommitAll.TabIndex = 126;
            this.m_cmdToCommitAll.Text = "批量执行发送 F2";
            this.m_cmdToCommitAll.Click += new System.EventHandler(this.m_cmdToCommitAll_Click);
            // 
            // frmOrderExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 614);
            this.Controls.Add(this.m_plControls);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOrderExecute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱执行发送";
            this.Load += new System.EventHandler(this.frmOrderExecute_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderExecute_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).EndInit();
            this.m_plChargeButtonList.ResumeLayout(false);
            this.m_plChargeButtonList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderList)).EndInit();
            this.m_ctMenuList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_plControls.ResumeLayout(false);
            this.m_plControls.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP m_cmdCancel;
        internal PinkieControls.ButtonXP m_cmdToCommit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox m_cboCode;
        internal PinkieControls.ButtonXP m_cmdMedicineSend;
        internal PinkieControls.ButtonXP m_cmdMedicineSee;
        internal PinkieControls.ButtonXP m_cmdToRedraw;
        public com.digitalwave.iCare.BIHOrder.Control.ctlBIHPatientInfo m_ctlPatient;
        public System.Windows.Forms.DataGridView m_dtvOrderList;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        public System.Windows.Forms.DataGridView m_dtvChangeList;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox m_chkSelectAll;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton m_rdoYET;
        public System.Windows.Forms.RadioButton m_rdoNOT;
        public System.Windows.Forms.RadioButton m_rdoAll;
        private System.Windows.Forms.Button m_btnBedList;
        public com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtBedNo2;
        private System.Windows.Forms.Panel m_plChargeButtonList;
        private PinkieControls.ButtonXP buttonXP3;
        private PinkieControls.ButtonXP buttonXP2;
        private PinkieControls.ButtonXP buttonXP1;
        public System.Windows.Forms.Label m_txtSameCharge;
        public System.Windows.Forms.Label m_txtChargeSum;
        private PinkieControls.ButtonXP cmdRefurbish;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.Panel m_plControls;
        public System.Windows.Forms.Label m_lblNewOrderCount;
        internal PinkieControls.ButtonXP m_cmdToCommitAll;
        internal System.Windows.Forms.CheckBox m_chkReExcute;
        internal PinkieControls.ButtonXP m_btnPatientCharge;
        internal System.Windows.Forms.ContextMenuStrip m_ctMenuList;
        internal System.Windows.Forms.ToolStripMenuItem m_ItemComfirmRun;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.CheckBox m_chkOut;
        internal System.Windows.Forms.CheckBox m_chkLong;
        internal System.Windows.Forms.CheckBox m_chkShort;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboState;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dtvselectCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_bedcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_RecipeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Case;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_ExecuteType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Get;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTACHTIMES_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretestdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATOR_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_UseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvPOSTDATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvCONFIRMER_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvCONFIRM_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_ENTRUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_DEPTNAME_VCHR;
        //internal System.Windows.Forms.TextBox txtTime;
    }
}