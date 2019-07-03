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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plDate = new System.Windows.Forms.Panel();
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
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnRec = new PinkieControls.ButtonXP();
            this.sortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 38;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sortNo,
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
            this.dgvData.Location = new System.Drawing.Point(0, 41);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 22;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1495, 604);
            this.dgvData.TabIndex = 6;
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
            this.panel1.Size = new System.Drawing.Size(1495, 41);
            this.panel1.TabIndex = 5;
            // 
            // plDate
            // 
            this.plDate.Controls.Add(this.cboSum);
            this.plDate.Controls.Add(this.label3);
            this.plDate.Controls.Add(this.cboSelect);
            this.plDate.Controls.Add(this.label2);
            this.plDate.Controls.Add(this.btnQuery);
            this.plDate.Controls.Add(this.dtmBegin);
            this.plDate.Controls.Add(this.lblTimeSpan);
            this.plDate.Controls.Add(this.dtmEnd);
            this.plDate.Controls.Add(this.lblTimeSpan2);
            this.plDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.plDate.Location = new System.Drawing.Point(204, 0);
            this.plDate.Name = "plDate";
            this.plDate.Size = new System.Drawing.Size(708, 41);
            this.plDate.TabIndex = 97;
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
            this.cboSum.Location = new System.Drawing.Point(185, 9);
            this.cboSum.Name = "cboSum";
            this.cboSum.Size = new System.Drawing.Size(96, 22);
            this.cboSum.TabIndex = 98;
            this.cboSum.SelectedIndexChanged += new System.EventHandler(this.cboSum_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(139, 13);
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
            this.cboSelect.Size = new System.Drawing.Size(66, 22);
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
            this.btnQuery.Location = new System.Drawing.Point(622, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(74, 32);
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
            this.dtmBegin.Location = new System.Drawing.Point(361, 9);
            this.dtmBegin.Name = "dtmBegin";
            this.dtmBegin.Size = new System.Drawing.Size(112, 23);
            this.dtmBegin.TabIndex = 93;
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTimeSpan.Location = new System.Drawing.Point(293, 12);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(63, 14);
            this.lblTimeSpan.TabIndex = 92;
            this.lblTimeSpan.Text = "日期：从";
            // 
            // dtmEnd
            // 
            this.dtmEnd.CustomFormat = "yyyy-MM-dd";
            this.dtmEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmEnd.Location = new System.Drawing.Point(501, 9);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(112, 23);
            this.dtmEnd.TabIndex = 94;
            // 
            // lblTimeSpan2
            // 
            this.lblTimeSpan2.AutoSize = true;
            this.lblTimeSpan2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblTimeSpan2.Location = new System.Drawing.Point(477, 12);
            this.lblTimeSpan2.Name = "lblTimeSpan2";
            this.lblTimeSpan2.Size = new System.Drawing.Size(21, 14);
            this.lblTimeSpan2.TabIndex = 95;
            this.lblTimeSpan2.Text = "至";
            // 
            // plDept
            // 
            this.plDept.Controls.Add(this.cboDept);
            this.plDept.Controls.Add(this.label1);
            this.plDept.Dock = System.Windows.Forms.DockStyle.Left;
            this.plDept.Location = new System.Drawing.Point(0, 0);
            this.plDept.Name = "plDept";
            this.plDept.Size = new System.Drawing.Size(204, 41);
            this.plDept.TabIndex = 96;
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
            // sortNo
            // 
            this.sortNo.DataPropertyName = "sortNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sortNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.sortNo.HeaderText = "序号";
            this.sortNo.Name = "sortNo";
            this.sortNo.ReadOnly = true;
            this.sortNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sortNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sortNo.Width = 50;
            // 
            // orderstatus
            // 
            this.orderstatus.DataPropertyName = "orderStatus";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.orderstatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderstatus.HeaderText = "医嘱状态";
            this.orderstatus.Name = "orderstatus";
            this.orderstatus.ReadOnly = true;
            this.orderstatus.Width = 50;
            // 
            // deptName
            // 
            this.deptName.DataPropertyName = "deptName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.deptName.DefaultCellStyle = dataGridViewCellStyle4;
            this.deptName.HeaderText = "科室名称";
            this.deptName.Name = "deptName";
            this.deptName.ReadOnly = true;
            this.deptName.Width = 110;
            // 
            // bedNo
            // 
            this.bedNo.DataPropertyName = "bedNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bedNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.bedNo.HeaderText = "床号";
            this.bedNo.Name = "bedNo";
            this.bedNo.ReadOnly = true;
            this.bedNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bedNo.Width = 50;
            // 
            // patName
            // 
            this.patName.DataPropertyName = "patName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.patName.DefaultCellStyle = dataGridViewCellStyle6;
            this.patName.HeaderText = "姓名";
            this.patName.Name = "patName";
            this.patName.ReadOnly = true;
            this.patName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patName.Width = 80;
            // 
            // preDate
            // 
            this.preDate.DataPropertyName = "preDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.preDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.preDate.HeaderText = "预发时间";
            this.preDate.Name = "preDate";
            this.preDate.ReadOnly = true;
            this.preDate.Width = 130;
            // 
            // nurse
            // 
            this.nurse.DataPropertyName = "nurse";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nurse.DefaultCellStyle = dataGridViewCellStyle6;
            this.nurse.HeaderText = "预发护士";
            this.nurse.Name = "nurse";
            this.nurse.ReadOnly = true;
            this.nurse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nurse.Width = 80;
            // 
            // orderName
            // 
            this.orderName.DataPropertyName = "orderName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.orderName.DefaultCellStyle = dataGridViewCellStyle9;
            this.orderName.HeaderText = "医嘱名称";
            this.orderName.Name = "orderName";
            this.orderName.ReadOnly = true;
            this.orderName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderName.Width = 250;
            // 
            // usageName
            // 
            this.usageName.DataPropertyName = "usageName";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usageName.DefaultCellStyle = dataGridViewCellStyle10;
            this.usageName.HeaderText = "用法";
            this.usageName.Name = "usageName";
            this.usageName.ReadOnly = true;
            this.usageName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usageName.Width = 80;
            // 
            // freqName
            // 
            this.freqName.DataPropertyName = "freqName";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.freqName.DefaultCellStyle = dataGridViewCellStyle11;
            this.freqName.HeaderText = "频率";
            this.freqName.Name = "freqName";
            this.freqName.ReadOnly = true;
            this.freqName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.freqName.Width = 70;
            // 
            // preAmount
            // 
            this.preAmount.DataPropertyName = "preAmount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.preAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.preAmount.HeaderText = "预发量";
            this.preAmount.Name = "preAmount";
            this.preAmount.ReadOnly = true;
            this.preAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.preAmount.Width = 70;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.unit.DefaultCellStyle = dataGridViewCellStyle13;
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 45;
            // 
            // recStatus
            // 
            this.recStatus.DataPropertyName = "recStatus";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recStatus.DefaultCellStyle = dataGridViewCellStyle14;
            this.recStatus.HeaderText = "回收状态";
            this.recStatus.Name = "recStatus";
            this.recStatus.ReadOnly = true;
            this.recStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recStatus.Width = 50;
            // 
            // recopername
            // 
            this.recopername.DataPropertyName = "recOperName";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recopername.DefaultCellStyle = dataGridViewCellStyle15;
            this.recopername.HeaderText = "回收人";
            this.recopername.Name = "recopername";
            this.recopername.ReadOnly = true;
            this.recopername.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recopername.Width = 80;
            // 
            // recdate
            // 
            this.recdate.DataPropertyName = "recDate";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.recdate.DefaultCellStyle = dataGridViewCellStyle16;
            this.recdate.HeaderText = "回收时间";
            this.recdate.Name = "recdate";
            this.recdate.ReadOnly = true;
            this.recdate.Width = 130;
            // 
            // recremark
            // 
            this.recremark.DataPropertyName = "recRemark";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.recremark.DefaultCellStyle = dataGridViewCellStyle17;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn sortNo;
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
    }
}