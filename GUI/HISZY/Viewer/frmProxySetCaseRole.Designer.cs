namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmProxySetCaseRole
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lsvQueryRole = new System.Windows.Forms.ListView();
            this.rolenane = new System.Windows.Forms.ColumnHeader();
            this.roledesc = new System.Windows.Forms.ColumnHeader();
            this.gvRole = new System.Windows.Forms.DataGridView();
            this.statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giveopername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.givetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recycleopername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recycledate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giveoperid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recycleoperid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoctCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnDel = new PinkieControls.ButtonXP();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvQueryRole
            // 
            this.lsvQueryRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rolenane,
            this.roledesc});
            this.lsvQueryRole.Font = new System.Drawing.Font("宋体", 11F);
            this.lsvQueryRole.FullRowSelect = true;
            this.lsvQueryRole.GridLines = true;
            this.lsvQueryRole.Location = new System.Drawing.Point(634, 36);
            this.lsvQueryRole.Name = "lsvQueryRole";
            this.lsvQueryRole.Size = new System.Drawing.Size(272, 392);
            this.lsvQueryRole.TabIndex = 6;
            this.lsvQueryRole.UseCompatibleStateImageBehavior = false;
            this.lsvQueryRole.View = System.Windows.Forms.View.Details;
            this.lsvQueryRole.Visible = false;
            this.lsvQueryRole.DoubleClick += new System.EventHandler(this.lsvQueryRole_DoubleClick);
            this.lsvQueryRole.Leave += new System.EventHandler(this.lsvQueryRole_Leave);
            this.lsvQueryRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvQueryRole_KeyDown);
            // 
            // rolenane
            // 
            this.rolenane.Text = "角色名称";
            this.rolenane.Width = 104;
            // 
            // roledesc
            // 
            this.roledesc.Text = "角色描述";
            this.roledesc.Width = 162;
            // 
            // gvRole
            // 
            this.gvRole.AllowUserToAddRows = false;
            this.gvRole.AllowUserToDeleteRows = false;
            this.gvRole.AllowUserToResizeRows = false;
            this.gvRole.BackgroundColor = System.Drawing.Color.White;
            this.gvRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvRole.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gvRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvRole.ColumnHeadersHeight = 30;
            this.gvRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusname,
            this.areaname,
            this.empname,
            this.rolename,
            this.giveopername,
            this.givetime,
            this.recycleopername,
            this.recycledate,
            this.serno,
            this.mapid,
            this.empid,
            this.roleid,
            this.areaid,
            this.giveoperid,
            this.recycleoperid,
            this.status});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRole.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRole.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvRole.Location = new System.Drawing.Point(0, 40);
            this.gvRole.MultiSelect = false;
            this.gvRole.Name = "gvRole";
            this.gvRole.RowHeadersVisible = false;
            this.gvRole.RowTemplate.Height = 33;
            this.gvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRole.ShowCellErrors = false;
            this.gvRole.ShowRowErrors = false;
            this.gvRole.Size = new System.Drawing.Size(1016, 657);
            this.gvRole.TabIndex = 3;
            // 
            // statusname
            // 
            this.statusname.DataPropertyName = "statusname";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            this.statusname.DefaultCellStyle = dataGridViewCellStyle2;
            this.statusname.HeaderText = "状态";
            this.statusname.Name = "statusname";
            this.statusname.ReadOnly = true;
            this.statusname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.statusname.Width = 70;
            // 
            // areaname
            // 
            this.areaname.DataPropertyName = "areaname";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F);
            this.areaname.DefaultCellStyle = dataGridViewCellStyle3;
            this.areaname.HeaderText = "病区";
            this.areaname.Name = "areaname";
            this.areaname.ReadOnly = true;
            this.areaname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.areaname.Width = 120;
            // 
            // empname
            // 
            this.empname.DataPropertyName = "empname";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            this.empname.DefaultCellStyle = dataGridViewCellStyle4;
            this.empname.HeaderText = "医师";
            this.empname.Name = "empname";
            this.empname.ReadOnly = true;
            this.empname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.empname.Width = 90;
            // 
            // rolename
            // 
            this.rolename.DataPropertyName = "rolename";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F);
            this.rolename.DefaultCellStyle = dataGridViewCellStyle5;
            this.rolename.HeaderText = "授权角色";
            this.rolename.Name = "rolename";
            this.rolename.ReadOnly = true;
            this.rolename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rolename.Width = 160;
            // 
            // giveopername
            // 
            this.giveopername.DataPropertyName = "giveopername";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 12F);
            this.giveopername.DefaultCellStyle = dataGridViewCellStyle6;
            this.giveopername.HeaderText = "授权人";
            this.giveopername.Name = "giveopername";
            this.giveopername.ReadOnly = true;
            this.giveopername.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.giveopername.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // givetime
            // 
            this.givetime.DataPropertyName = "givetime";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F);
            this.givetime.DefaultCellStyle = dataGridViewCellStyle7;
            this.givetime.HeaderText = "授权时间";
            this.givetime.Name = "givetime";
            this.givetime.ReadOnly = true;
            this.givetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.givetime.Width = 180;
            // 
            // recycleopername
            // 
            this.recycleopername.DataPropertyName = "recycleopername";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F);
            this.recycleopername.DefaultCellStyle = dataGridViewCellStyle8;
            this.recycleopername.HeaderText = "回收人";
            this.recycleopername.Name = "recycleopername";
            this.recycleopername.ReadOnly = true;
            this.recycleopername.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // recycledate
            // 
            this.recycledate.DataPropertyName = "recycledate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F);
            this.recycledate.DefaultCellStyle = dataGridViewCellStyle9;
            this.recycledate.HeaderText = "回收时间";
            this.recycledate.Name = "recycledate";
            this.recycledate.ReadOnly = true;
            this.recycledate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recycledate.Width = 180;
            // 
            // serno
            // 
            this.serno.DataPropertyName = "serno";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 14.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.serno.DefaultCellStyle = dataGridViewCellStyle10;
            this.serno.HeaderText = "serno";
            this.serno.Name = "serno";
            this.serno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serno.Visible = false;
            // 
            // mapid
            // 
            this.mapid.DataPropertyName = "mapid";
            this.mapid.HeaderText = "mapid";
            this.mapid.Name = "mapid";
            this.mapid.ReadOnly = true;
            this.mapid.Visible = false;
            // 
            // empid
            // 
            this.empid.DataPropertyName = "empid";
            this.empid.HeaderText = "empid";
            this.empid.Name = "empid";
            this.empid.ReadOnly = true;
            this.empid.Visible = false;
            // 
            // roleid
            // 
            this.roleid.DataPropertyName = "roleid";
            this.roleid.HeaderText = "roleid";
            this.roleid.Name = "roleid";
            this.roleid.ReadOnly = true;
            this.roleid.Visible = false;
            // 
            // areaid
            // 
            this.areaid.DataPropertyName = "areaid";
            this.areaid.HeaderText = "areaid";
            this.areaid.Name = "areaid";
            this.areaid.ReadOnly = true;
            this.areaid.Visible = false;
            // 
            // giveoperid
            // 
            this.giveoperid.DataPropertyName = "giveoperid";
            this.giveoperid.HeaderText = "giveoperid";
            this.giveoperid.Name = "giveoperid";
            this.giveoperid.ReadOnly = true;
            this.giveoperid.Visible = false;
            // 
            // recycleoperid
            // 
            this.recycleoperid.DataPropertyName = "recycleoperid";
            this.recycleoperid.HeaderText = "recycleoperid";
            this.recycleoperid.Name = "recycleoperid";
            this.recycleoperid.ReadOnly = true;
            this.recycleoperid.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.dteEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dteStart);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 40);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRole);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDoctCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(438, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 46);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // txtRole
            // 
            this.txtRole.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.ForeColor = System.Drawing.Color.Blue;
            this.txtRole.Location = new System.Drawing.Point(196, 12);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(109, 29);
            this.txtRole.TabIndex = 26;
            this.txtRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRole_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(152, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "角色:";
            // 
            // txtDoctCode
            // 
            this.txtDoctCode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctCode.ForeColor = System.Drawing.Color.Blue;
            this.txtDoctCode.Location = new System.Drawing.Point(76, 12);
            this.txtDoctCode.Name = "txtDoctCode";
            this.txtDoctCode.Size = new System.Drawing.Size(69, 29);
            this.txtDoctCode.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "医师工号:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(310, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "添加角色(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(946, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(68, 32);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.DefaultScheme = true;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Hint = "";
            this.btnDel.Location = new System.Drawing.Point(851, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 18;
            this.btnDel.Text = "回收角色(&D)";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(368, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(68, 32);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dteEnd
            // 
            this.dteEnd.CustomFormat = "yyyy-MM-dd";
            this.dteEnd.Font = new System.Drawing.Font("宋体", 11F);
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteEnd.Location = new System.Drawing.Point(241, 9);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(121, 24);
            this.dteEnd.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(219, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "到";
            // 
            // dteStart
            // 
            this.dteStart.CustomFormat = "yyyy-MM-dd";
            this.dteStart.Font = new System.Drawing.Font("宋体", 11F);
            this.dteStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteStart.Location = new System.Drawing.Point(96, 9);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(121, 24);
            this.dteStart.TabIndex = 13;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(4, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(91, 14);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "授权日期：从";
            // 
            // frmProxySetCaseRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 697);
            this.Controls.Add(this.lsvQueryRole);
            this.Controls.Add(this.gvRole);
            this.Controls.Add(this.panel1);
            this.Name = "frmProxySetCaseRole";
            this.Text = "病历借阅修改角色设置";
            this.Load += new System.EventHandler(this.frmProxySetCaseRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView gvRole;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnAdd;
        internal PinkieControls.ButtonXP btnDel;
        internal PinkieControls.ButtonXP btnQuery;
        internal System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ListView lsvQueryRole;
        private System.Windows.Forms.ColumnHeader rolenane;
        private System.Windows.Forms.ColumnHeader roledesc;
        internal System.Windows.Forms.TextBox txtDoctCode;
        internal System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empname;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolename;
        private System.Windows.Forms.DataGridViewTextBoxColumn giveopername;
        private System.Windows.Forms.DataGridViewTextBoxColumn givetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn recycleopername;
        private System.Windows.Forms.DataGridViewTextBoxColumn recycledate;
        private System.Windows.Forms.DataGridViewTextBoxColumn serno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn empid;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn giveoperid;
        private System.Windows.Forms.DataGridViewTextBoxColumn recycleoperid;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}