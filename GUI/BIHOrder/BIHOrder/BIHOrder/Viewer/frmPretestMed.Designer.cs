namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmPretestMed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle96 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle114 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle97 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle98 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle99 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle100 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle101 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle102 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle103 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle104 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle105 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle106 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle107 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle108 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle109 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle110 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle111 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle112 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle113 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.sortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPretestCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.freqName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recopername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putMedId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDicId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plDate = new System.Windows.Forms.Panel();
            this.chkHsNo = new System.Windows.Forms.CheckBox();
            this.chkSfNo = new System.Windows.Forms.CheckBox();
            this.chkHsYes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSfYes = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSum = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.dtmBegin = new System.Windows.Forms.DateTimePicker();
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTimeSpan2 = new System.Windows.Forms.Label();
            this.plDept = new System.Windows.Forms.Panel();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnRec = new PinkieControls.ButtonXP();
            this.cboDateType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.plDate.SuspendLayout();
            this.plDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle96.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle96.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle96.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle96.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle96.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle96.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle96;
            this.dgvData.ColumnHeadersHeight = 38;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sortNo,
            this.isPretestCharge,
            this.orderstatus,
            this.deptName,
            this.bedNo,
            this.patName,
            this.preDate,
            this.nurse,
            this.orderName,
            this.usageName,
            this.freqName,
            this.preAmount,
            this.unit,
            this.recStatus,
            this.recopername,
            this.recdate,
            this.recremark,
            this.putMedId,
            this.deptId,
            this.orderId,
            this.orderDicId});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 64);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 22;
            dataGridViewCellStyle114.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle114.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle114.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle114;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1495, 581);
            this.dgvData.TabIndex = 6;
            // 
            // sortNo
            // 
            this.sortNo.DataPropertyName = "sortNo";
            dataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sortNo.DefaultCellStyle = dataGridViewCellStyle97;
            this.sortNo.HeaderText = "序号";
            this.sortNo.Name = "sortNo";
            this.sortNo.ReadOnly = true;
            this.sortNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sortNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sortNo.Width = 50;
            // 
            // isPretestCharge
            // 
            this.isPretestCharge.DataPropertyName = "isPretestCharge";
            dataGridViewCellStyle98.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.isPretestCharge.DefaultCellStyle = dataGridViewCellStyle98;
            this.isPretestCharge.HeaderText = "是否收费";
            this.isPretestCharge.Name = "isPretestCharge";
            this.isPretestCharge.ReadOnly = true;
            this.isPretestCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.isPretestCharge.Width = 42;
            // 
            // orderstatus
            // 
            this.orderstatus.DataPropertyName = "orderStatus";
            dataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.orderstatus.DefaultCellStyle = dataGridViewCellStyle99;
            this.orderstatus.HeaderText = "医嘱状态";
            this.orderstatus.Name = "orderstatus";
            this.orderstatus.ReadOnly = true;
            this.orderstatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderstatus.Width = 70;
            // 
            // deptName
            // 
            this.deptName.DataPropertyName = "deptName";
            dataGridViewCellStyle100.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.deptName.DefaultCellStyle = dataGridViewCellStyle100;
            this.deptName.HeaderText = "科室名称";
            this.deptName.Name = "deptName";
            this.deptName.ReadOnly = true;
            this.deptName.Width = 110;
            // 
            // bedNo
            // 
            this.bedNo.DataPropertyName = "bedNo";
            dataGridViewCellStyle101.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bedNo.DefaultCellStyle = dataGridViewCellStyle101;
            this.bedNo.HeaderText = "床号";
            this.bedNo.Name = "bedNo";
            this.bedNo.ReadOnly = true;
            this.bedNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bedNo.Width = 50;
            // 
            // patName
            // 
            this.patName.DataPropertyName = "patName";
            dataGridViewCellStyle102.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.patName.DefaultCellStyle = dataGridViewCellStyle102;
            this.patName.HeaderText = "姓名";
            this.patName.Name = "patName";
            this.patName.ReadOnly = true;
            this.patName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patName.Width = 80;
            // 
            // preDate
            // 
            this.preDate.DataPropertyName = "preDate";
            dataGridViewCellStyle103.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.preDate.DefaultCellStyle = dataGridViewCellStyle103;
            this.preDate.HeaderText = "预发时间";
            this.preDate.Name = "preDate";
            this.preDate.ReadOnly = true;
            this.preDate.Width = 130;
            // 
            // nurse
            // 
            this.nurse.DataPropertyName = "nurse";
            dataGridViewCellStyle104.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nurse.DefaultCellStyle = dataGridViewCellStyle104;
            this.nurse.HeaderText = "预发护士";
            this.nurse.Name = "nurse";
            this.nurse.ReadOnly = true;
            this.nurse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nurse.Width = 80;
            // 
            // orderName
            // 
            this.orderName.DataPropertyName = "orderName";
            dataGridViewCellStyle105.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.orderName.DefaultCellStyle = dataGridViewCellStyle105;
            this.orderName.HeaderText = "医嘱名称";
            this.orderName.Name = "orderName";
            this.orderName.ReadOnly = true;
            this.orderName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderName.Width = 250;
            // 
            // usageName
            // 
            this.usageName.DataPropertyName = "usageName";
            dataGridViewCellStyle106.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usageName.DefaultCellStyle = dataGridViewCellStyle106;
            this.usageName.HeaderText = "用法";
            this.usageName.Name = "usageName";
            this.usageName.ReadOnly = true;
            this.usageName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usageName.Width = 80;
            // 
            // freqName
            // 
            this.freqName.DataPropertyName = "freqName";
            dataGridViewCellStyle107.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.freqName.DefaultCellStyle = dataGridViewCellStyle107;
            this.freqName.HeaderText = "频率";
            this.freqName.Name = "freqName";
            this.freqName.ReadOnly = true;
            this.freqName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.freqName.Width = 70;
            // 
            // preAmount
            // 
            this.preAmount.DataPropertyName = "preAmount";
            dataGridViewCellStyle108.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.preAmount.DefaultCellStyle = dataGridViewCellStyle108;
            this.preAmount.HeaderText = "预发量";
            this.preAmount.Name = "preAmount";
            this.preAmount.ReadOnly = true;
            this.preAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.preAmount.Width = 70;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            dataGridViewCellStyle109.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.unit.DefaultCellStyle = dataGridViewCellStyle109;
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 45;
            // 
            // recStatus
            // 
            this.recStatus.DataPropertyName = "recStatus";
            dataGridViewCellStyle110.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recStatus.DefaultCellStyle = dataGridViewCellStyle110;
            this.recStatus.HeaderText = "回收状态";
            this.recStatus.Name = "recStatus";
            this.recStatus.ReadOnly = true;
            this.recStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recStatus.Width = 50;
            // 
            // recopername
            // 
            this.recopername.DataPropertyName = "recOperName";
            dataGridViewCellStyle111.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recopername.DefaultCellStyle = dataGridViewCellStyle111;
            this.recopername.HeaderText = "回收人";
            this.recopername.Name = "recopername";
            this.recopername.ReadOnly = true;
            this.recopername.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recopername.Width = 80;
            // 
            // recdate
            // 
            this.recdate.DataPropertyName = "recDate";
            dataGridViewCellStyle112.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recdate.DefaultCellStyle = dataGridViewCellStyle112;
            this.recdate.HeaderText = "回收时间";
            this.recdate.Name = "recdate";
            this.recdate.ReadOnly = true;
            this.recdate.Width = 130;
            // 
            // recremark
            // 
            this.recremark.DataPropertyName = "recRemark";
            dataGridViewCellStyle113.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.recremark.DefaultCellStyle = dataGridViewCellStyle113;
            this.recremark.HeaderText = "回收备注";
            this.recremark.Name = "recremark";
            this.recremark.ReadOnly = true;
            this.recremark.Width = 200;
            // 
            // putMedId
            // 
            this.putMedId.DataPropertyName = "putMedId";
            this.putMedId.HeaderText = "摆药ID";
            this.putMedId.Name = "putMedId";
            this.putMedId.ReadOnly = true;
            this.putMedId.Visible = false;
            // 
            // deptId
            // 
            this.deptId.DataPropertyName = "deptId";
            this.deptId.HeaderText = "deptId";
            this.deptId.Name = "deptId";
            this.deptId.ReadOnly = true;
            this.deptId.Visible = false;
            // 
            // orderId
            // 
            this.orderId.DataPropertyName = "orderId";
            this.orderId.HeaderText = "orderId";
            this.orderId.Name = "orderId";
            this.orderId.ReadOnly = true;
            this.orderId.Visible = false;
            // 
            // orderDicId
            // 
            this.orderDicId.DataPropertyName = "orderDicId";
            this.orderDicId.HeaderText = "orderDicId";
            this.orderDicId.Name = "orderDicId";
            this.orderDicId.ReadOnly = true;
            this.orderDicId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.plDate);
            this.panel1.Controls.Add(this.plDept);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnRec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1495, 64);
            this.panel1.TabIndex = 5;
            // 
            // plDate
            // 
            this.plDate.Controls.Add(this.cboDateType);
            this.plDate.Controls.Add(this.chkHsNo);
            this.plDate.Controls.Add(this.chkSfNo);
            this.plDate.Controls.Add(this.chkHsYes);
            this.plDate.Controls.Add(this.label4);
            this.plDate.Controls.Add(this.cboSum);
            this.plDate.Controls.Add(this.label3);
            this.plDate.Controls.Add(this.chkSfYes);
            this.plDate.Controls.Add(this.cboSelect);
            this.plDate.Controls.Add(this.label6);
            this.plDate.Controls.Add(this.label2);
            this.plDate.Controls.Add(this.btnQuery);
            this.plDate.Controls.Add(this.dtmBegin);
            this.plDate.Controls.Add(this.lblTimeSpan);
            this.plDate.Controls.Add(this.dtmEnd);
            this.plDate.Controls.Add(this.lblTimeSpan2);
            this.plDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.plDate.Location = new System.Drawing.Point(204, 0);
            this.plDate.Name = "plDate";
            this.plDate.Size = new System.Drawing.Size(680, 64);
            this.plDate.TabIndex = 97;
            // 
            // chkHsNo
            // 
            this.chkHsNo.AutoSize = true;
            this.chkHsNo.Font = new System.Drawing.Font("宋体", 10F);
            this.chkHsNo.Location = new System.Drawing.Point(93, 40);
            this.chkHsNo.Name = "chkHsNo";
            this.chkHsNo.Size = new System.Drawing.Size(40, 18);
            this.chkHsNo.TabIndex = 101;
            this.chkHsNo.Text = "否";
            this.chkHsNo.UseVisualStyleBackColor = true;
            this.chkHsNo.CheckedChanged += new System.EventHandler(this.chkHsNo_CheckedChanged);
            // 
            // chkSfNo
            // 
            this.chkSfNo.AutoSize = true;
            this.chkSfNo.Font = new System.Drawing.Font("宋体", 10F);
            this.chkSfNo.Location = new System.Drawing.Point(492, 12);
            this.chkSfNo.Name = "chkSfNo";
            this.chkSfNo.Size = new System.Drawing.Size(40, 18);
            this.chkSfNo.TabIndex = 106;
            this.chkSfNo.Text = "否";
            this.chkSfNo.UseVisualStyleBackColor = true;
            this.chkSfNo.CheckedChanged += new System.EventHandler(this.chkSfNo_CheckedChanged);
            // 
            // chkHsYes
            // 
            this.chkHsYes.AutoSize = true;
            this.chkHsYes.Font = new System.Drawing.Font("宋体", 10F);
            this.chkHsYes.Location = new System.Drawing.Point(143, 40);
            this.chkHsYes.Name = "chkHsYes";
            this.chkHsYes.Size = new System.Drawing.Size(40, 18);
            this.chkHsYes.TabIndex = 100;
            this.chkHsYes.Text = "是";
            this.chkHsYes.UseVisualStyleBackColor = true;
            this.chkHsYes.CheckedChanged += new System.EventHandler(this.chkHsYes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 95;
            this.label4.Text = "是否已回收：";
            // 
            // chkSfYes
            // 
            this.chkSfYes.AutoSize = true;
            this.chkSfYes.Font = new System.Drawing.Font("宋体", 10F);
            this.chkSfYes.Location = new System.Drawing.Point(542, 12);
            this.chkSfYes.Name = "chkSfYes";
            this.chkSfYes.Size = new System.Drawing.Size(40, 18);
            this.chkSfYes.TabIndex = 105;
            this.chkSfYes.Text = "是";
            this.chkSfYes.UseVisualStyleBackColor = true;
            this.chkSfYes.CheckedChanged += new System.EventHandler(this.chkSfYes_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.Location = new System.Drawing.Point(395, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 104;
            this.label6.Text = "是否已收费：";
            // 
            // cboSum
            // 
            this.cboSum.BackColor = System.Drawing.Color.White;
            this.cboSum.DropDownHeight = 200;
            this.cboSum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSum.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboSum.FormattingEnabled = true;
            this.cboSum.IntegralHeight = false;
            this.cboSum.Items.AddRange(new object[] {
            "全部明细",
            "按患者汇总",
            "按科室汇总",
            "按项目汇总"});
            this.cboSum.Location = new System.Drawing.Point(242, 9);
            this.cboSum.Name = "cboSum";
            this.cboSum.Size = new System.Drawing.Size(112, 22);
            this.cboSum.TabIndex = 98;
            this.cboSum.SelectedIndexChanged += new System.EventHandler(this.cboSum_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(196, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 99;
            this.label3.Text = "汇总：";
            // 
            // cboSelect
            // 
            this.cboSelect.BackColor = System.Drawing.Color.White;
            this.cboSelect.DropDownHeight = 200;
            this.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelect.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboSelect.FormattingEnabled = true;
            this.cboSelect.IntegralHeight = false;
            this.cboSelect.Items.AddRange(new object[] {
            "取消",
            "全选",
            "反选"});
            this.cboSelect.Location = new System.Drawing.Point(64, 9);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Size = new System.Drawing.Size(112, 22);
            this.cboSelect.TabIndex = 96;
            this.cboSelect.SelectedIndexChanged += new System.EventHandler(this.cboSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 97;
            this.label2.Text = "行选择：";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(600, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(74, 56);
            this.btnQuery.TabIndex = 46;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.TextColor = System.Drawing.Color.Black;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtmBegin
            // 
            this.dtmBegin.CustomFormat = "yyyy-MM-dd";
            this.dtmBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtmBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmBegin.Location = new System.Drawing.Point(330, 36);
            this.dtmBegin.Name = "dtmBegin";
            this.dtmBegin.Size = new System.Drawing.Size(112, 23);
            this.dtmBegin.TabIndex = 93;
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTimeSpan.Location = new System.Drawing.Point(305, 39);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(21, 14);
            this.lblTimeSpan.TabIndex = 92;
            this.lblTimeSpan.Text = "从";
            // 
            // dtmEnd
            // 
            this.dtmEnd.CustomFormat = "yyyy-MM-dd";
            this.dtmEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmEnd.Location = new System.Drawing.Point(470, 36);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(112, 23);
            this.dtmEnd.TabIndex = 94;
            // 
            // lblTimeSpan2
            // 
            this.lblTimeSpan2.AutoSize = true;
            this.lblTimeSpan2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblTimeSpan2.Location = new System.Drawing.Point(446, 39);
            this.lblTimeSpan2.Name = "lblTimeSpan2";
            this.lblTimeSpan2.Size = new System.Drawing.Size(21, 14);
            this.lblTimeSpan2.TabIndex = 95;
            this.lblTimeSpan2.Text = "至";
            // 
            // plDept
            // 
            this.plDept.Controls.Add(this.cboOrderStatus);
            this.plDept.Controls.Add(this.label5);
            this.plDept.Controls.Add(this.cboDept);
            this.plDept.Controls.Add(this.label1);
            this.plDept.Dock = System.Windows.Forms.DockStyle.Left;
            this.plDept.Location = new System.Drawing.Point(0, 0);
            this.plDept.Name = "plDept";
            this.plDept.Size = new System.Drawing.Size(204, 64);
            this.plDept.TabIndex = 96;
            // 
            // cboOrderStatus
            // 
            this.cboOrderStatus.BackColor = System.Drawing.Color.White;
            this.cboOrderStatus.DropDownHeight = 200;
            this.cboOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboOrderStatus.FormattingEnabled = true;
            this.cboOrderStatus.IntegralHeight = false;
            this.cboOrderStatus.Items.AddRange(new object[] {
            "",
            "审核停止",
            "未停止"});
            this.cboOrderStatus.Location = new System.Drawing.Point(79, 37);
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.Size = new System.Drawing.Size(117, 22);
            this.cboOrderStatus.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(5, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 95;
            this.label5.Text = "医嘱状态：";
            // 
            // cboDept
            // 
            this.cboDept.BackColor = System.Drawing.Color.White;
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(79, 9);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(117, 22);
            this.cboDept.TabIndex = 94;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 93;
            this.label1.Text = "科室列表：";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(1412, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(74, 32);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "关闭 (&C)";
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRec
            // 
            this.btnRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRec.DefaultScheme = true;
            this.btnRec.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRec.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRec.Hint = "";
            this.btnRec.Location = new System.Drawing.Point(1305, 4);
            this.btnRec.Name = "btnRec";
            this.btnRec.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRec.Size = new System.Drawing.Size(99, 32);
            this.btnRec.TabIndex = 43;
            this.btnRec.Text = "回收药品(&Y)";
            this.btnRec.TextColor = System.Drawing.Color.ForestGreen;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // cboDateType
            // 
            this.cboDateType.BackColor = System.Drawing.Color.White;
            this.cboDateType.DropDownHeight = 200;
            this.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDateType.FormattingEnabled = true;
            this.cboDateType.IntegralHeight = false;
            this.cboDateType.Items.AddRange(new object[] {
            "按摆药时间",
            "按停嘱时间"});
            this.cboDateType.Location = new System.Drawing.Point(201, 36);
            this.cboDateType.Name = "cboDateType";
            this.cboDateType.Size = new System.Drawing.Size(99, 22);
            this.cboDateType.TabIndex = 107;
            // 
            // frmPretestMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 645);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Name = "frmPretestMed";
            this.Text = "预发药查询";
            this.Load += new System.EventHandler(this.frmPretestMed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.plDate.ResumeLayout(false);
            this.plDate.PerformLayout();
            this.plDept.ResumeLayout(false);
            this.plDept.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker dtmBegin;
        internal System.Windows.Forms.DateTimePicker dtmEnd;
        private System.Windows.Forms.Label lblTimeSpan2;
        private System.Windows.Forms.Label lblTimeSpan;
        internal PinkieControls.ButtonXP btnQuery;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnRec;
        private System.Windows.Forms.Panel plDate;
        internal System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plDept;
        internal System.Windows.Forms.DataGridView dgvData;
        internal System.Windows.Forms.ComboBox cboSelect;
        internal System.Windows.Forms.ComboBox cboSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.CheckBox chkSfNo;
        internal System.Windows.Forms.CheckBox chkSfYes;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox chkHsNo;
        internal System.Windows.Forms.CheckBox chkHsYes;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboOrderStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPretestCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn patName;
        private System.Windows.Forms.DataGridViewTextBoxColumn preDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurse;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn usageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn freqName;
        private System.Windows.Forms.DataGridViewTextBoxColumn preAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn recStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn recopername;
        private System.Windows.Forms.DataGridViewTextBoxColumn recdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn recremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn putMedId;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDicId;
        internal System.Windows.Forms.ComboBox cboDateType;
    }
}