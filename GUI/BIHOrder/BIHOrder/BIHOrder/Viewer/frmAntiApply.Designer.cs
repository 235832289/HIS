namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmAntiApply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntiApply));
            this.btnDel = new PinkieControls.ButtonXP();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.lvExperts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConfirmDesc = new System.Windows.Forms.TextBox();
            this.txtApplyDesc = new System.Windows.Forms.TextBox();
            this.txtIllNess = new System.Windows.Forms.TextBox();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.dtpConfirmDate = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmDoct = new PinkieControls.ButtonXP();
            this.txtConfirmDoct = new System.Windows.Forms.TextBox();
            this.btnApplyDoct = new PinkieControls.ButtonXP();
            this.txtApplyDoct = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNoDesc = new System.Windows.Forms.TextBox();
            this.chkNo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkYes = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMedName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAge = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIpNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDel.DefaultScheme = true;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.Hint = "";
            this.btnDel.Location = new System.Drawing.Point(786, 364);
            this.btnDel.Name = "btnDel";
            this.btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDel.Size = new System.Drawing.Size(52, 24);
            this.btnDel.TabIndex = 204;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(724, 364);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAdd.Size = new System.Drawing.Size(52, 24);
            this.btnAdd.TabIndex = 203;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvExperts
            // 
            this.lvExperts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvExperts.Location = new System.Drawing.Point(660, 392);
            this.lvExperts.Name = "lvExperts";
            this.lvExperts.Size = new System.Drawing.Size(178, 160);
            this.lvExperts.TabIndex = 202;
            this.lvExperts.UseCompatibleStateImageBehavior = false;
            this.lvExperts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "专家";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(660, 373);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 201;
            this.label16.Text = "邀请专家:";
            // 
            // txtConfirmDesc
            // 
            this.txtConfirmDesc.Font = new System.Drawing.Font("宋体", 10F);
            this.txtConfirmDesc.Location = new System.Drawing.Point(240, 600);
            this.txtConfirmDesc.Multiline = true;
            this.txtConfirmDesc.Name = "txtConfirmDesc";
            this.txtConfirmDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfirmDesc.Size = new System.Drawing.Size(598, 80);
            this.txtConfirmDesc.TabIndex = 200;
            // 
            // txtApplyDesc
            // 
            this.txtApplyDesc.Font = new System.Drawing.Font("宋体", 10F);
            this.txtApplyDesc.Location = new System.Drawing.Point(240, 370);
            this.txtApplyDesc.Multiline = true;
            this.txtApplyDesc.Name = "txtApplyDesc";
            this.txtApplyDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplyDesc.Size = new System.Drawing.Size(416, 182);
            this.txtApplyDesc.TabIndex = 199;
            // 
            // txtIllNess
            // 
            this.txtIllNess.Font = new System.Drawing.Font("宋体", 10F);
            this.txtIllNess.Location = new System.Drawing.Point(240, 250);
            this.txtIllNess.Multiline = true;
            this.txtIllNess.Name = "txtIllNess";
            this.txtIllNess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIllNess.Size = new System.Drawing.Size(598, 110);
            this.txtIllNess.TabIndex = 198;
            // 
            // txtDiag
            // 
            this.txtDiag.Font = new System.Drawing.Font("宋体", 10F);
            this.txtDiag.Location = new System.Drawing.Point(240, 160);
            this.txtDiag.Multiline = true;
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiag.Size = new System.Drawing.Size(598, 80);
            this.txtDiag.TabIndex = 197;
            // 
            // dtpConfirmDate
            // 
            this.dtpConfirmDate.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpConfirmDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpConfirmDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpConfirmDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpConfirmDate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.dtpConfirmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConfirmDate.Location = new System.Drawing.Point(656, 696);
            this.dtpConfirmDate.Name = "dtpConfirmDate";
            this.dtpConfirmDate.Size = new System.Drawing.Size(172, 23);
            this.dtpConfirmDate.TabIndex = 196;
            // 
            // btnConfirmDoct
            // 
            this.btnConfirmDoct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnConfirmDoct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmDoct.DefaultScheme = true;
            this.btnConfirmDoct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirmDoct.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmDoct.Hint = "";
            this.btnConfirmDoct.Location = new System.Drawing.Point(560, 693);
            this.btnConfirmDoct.Name = "btnConfirmDoct";
            this.btnConfirmDoct.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnConfirmDoct.Size = new System.Drawing.Size(20, 28);
            this.btnConfirmDoct.TabIndex = 195;
            this.btnConfirmDoct.Text = "▼";
            // 
            // txtConfirmDoct
            // 
            this.txtConfirmDoct.Font = new System.Drawing.Font("宋体", 10F);
            this.txtConfirmDoct.Location = new System.Drawing.Point(464, 695);
            this.txtConfirmDoct.Name = "txtConfirmDoct";
            this.txtConfirmDoct.ReadOnly = true;
            this.txtConfirmDoct.Size = new System.Drawing.Size(95, 23);
            this.txtConfirmDoct.TabIndex = 194;
            // 
            // btnApplyDoct
            // 
            this.btnApplyDoct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnApplyDoct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyDoct.DefaultScheme = true;
            this.btnApplyDoct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnApplyDoct.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDoct.Hint = "";
            this.btnApplyDoct.Location = new System.Drawing.Point(560, 563);
            this.btnApplyDoct.Name = "btnApplyDoct";
            this.btnApplyDoct.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnApplyDoct.Size = new System.Drawing.Size(20, 28);
            this.btnApplyDoct.TabIndex = 193;
            this.btnApplyDoct.Text = "▼";
            // 
            // txtApplyDoct
            // 
            this.txtApplyDoct.Font = new System.Drawing.Font("宋体", 10F);
            this.txtApplyDoct.Location = new System.Drawing.Point(464, 565);
            this.txtApplyDoct.Name = "txtApplyDoct";
            this.txtApplyDoct.ReadOnly = true;
            this.txtApplyDoct.Size = new System.Drawing.Size(95, 23);
            this.txtApplyDoct.TabIndex = 192;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(593, 700);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 191;
            this.label13.Text = "审核日期:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 700);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 190;
            this.label2.Text = "科主任签名:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(174, 601);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 32);
            this.label11.TabIndex = 189;
            this.label11.Text = "科主任审核意见:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 188;
            this.label3.Text = "申请人:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 187;
            this.label9.Text = "申请理由:";
            // 
            // txtNoDesc
            // 
            this.txtNoDesc.Font = new System.Drawing.Font("宋体", 10F);
            this.txtNoDesc.Location = new System.Drawing.Point(368, 124);
            this.txtNoDesc.Name = "txtNoDesc";
            this.txtNoDesc.Size = new System.Drawing.Size(470, 23);
            this.txtNoDesc.TabIndex = 186;
            // 
            // chkNo
            // 
            this.chkNo.AutoSize = true;
            this.chkNo.Location = new System.Drawing.Point(264, 128);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(48, 16);
            this.chkNo.TabIndex = 185;
            this.chkNo.Text = "未做";
            this.chkNo.UseVisualStyleBackColor = true;
            this.chkNo.CheckedChanged += new System.EventHandler(this.chkNo_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 184;
            this.label5.Text = "临床诊断:";
            // 
            // chkYes
            // 
            this.chkYes.AutoSize = true;
            this.chkYes.Location = new System.Drawing.Point(324, 128);
            this.chkYes.Name = "chkYes";
            this.chkYes.Size = new System.Drawing.Size(36, 16);
            this.chkYes.TabIndex = 183;
            this.chkYes.Text = "做";
            this.chkYes.UseVisualStyleBackColor = true;
            this.chkYes.CheckedChanged += new System.EventHandler(this.chkYes_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 182;
            this.label7.Text = "病原体检查:";
            // 
            // txtMedName
            // 
            this.txtMedName.Font = new System.Drawing.Font("宋体", 10F);
            this.txtMedName.Location = new System.Drawing.Point(324, 90);
            this.txtMedName.Name = "txtMedName";
            this.txtMedName.Size = new System.Drawing.Size(514, 23);
            this.txtMedName.TabIndex = 181;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(174, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 12);
            this.label14.TabIndex = 180;
            this.label14.Text = "申请使用抗菌药物通用名:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(593, 570);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 176;
            this.label17.Text = "申请日期:";
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplyDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpApplyDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpApplyDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpApplyDate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.dtpApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyDate.Location = new System.Drawing.Point(656, 564);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(172, 23);
            this.dtpApplyDate.TabIndex = 175;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(169, 251);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 40);
            this.label18.TabIndex = 174;
            this.label18.Text = "病史及诊疗情况摘要:";
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1});
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvHistory.Font = new System.Drawing.Font("宋体", 10F);
            this.lvHistory.Location = new System.Drawing.Point(0, 76);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(160, 654);
            this.lvHistory.TabIndex = 7;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.SelectedIndexChanged += new System.EventHandler(this.lvHistory_SelectedIndexChanged);
            // 
            // col1
            // 
            this.col1.Text = "申请记录";
            this.col1.Width = 135;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAge);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblSex);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblIpNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblBedNo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblAreaName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblPatName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLt);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 37);
            this.panel1.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAge.ForeColor = System.Drawing.Color.Blue;
            this.lblAge.Location = new System.Drawing.Point(608, 13);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(0, 14);
            this.lblAge.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(568, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "年龄:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.ForeColor = System.Drawing.Color.Blue;
            this.lblSex.Location = new System.Drawing.Point(532, 13);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(0, 14);
            this.lblSex.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(496, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "性别:";
            // 
            // lblIpNo
            // 
            this.lblIpNo.AutoSize = true;
            this.lblIpNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIpNo.ForeColor = System.Drawing.Color.Blue;
            this.lblIpNo.Location = new System.Drawing.Point(420, 13);
            this.lblIpNo.Name = "lblIpNo";
            this.lblIpNo.Size = new System.Drawing.Size(0, 14);
            this.lblIpNo.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "住院号:";
            // 
            // lblBedNo
            // 
            this.lblBedNo.AutoSize = true;
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.ForeColor = System.Drawing.Color.Blue;
            this.lblBedNo.Location = new System.Drawing.Point(304, 13);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(0, 14);
            this.lblBedNo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "床号:";
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaName.ForeColor = System.Drawing.Color.Blue;
            this.lblAreaName.Location = new System.Drawing.Point(156, 13);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(0, 14);
            this.lblAreaName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "病区:";
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatName.ForeColor = System.Drawing.Color.Blue;
            this.lblPatName.Location = new System.Drawing.Point(46, 13);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(0, 14);
            this.lblPatName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // txtLt
            // 
            this.txtLt.Font = new System.Drawing.Font("宋体", 10F);
            this.txtLt.Location = new System.Drawing.Point(784, 8);
            this.txtLt.Name = "txtLt";
            this.txtLt.ReadOnly = true;
            this.txtLt.Size = new System.Drawing.Size(56, 23);
            this.txtLt.TabIndex = 179;
            this.txtLt.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(718, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 178;
            this.label15.Text = "申请科室:";
            this.label15.Visible = false;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbDel,
            this.toolStripSeparator3,
            this.tsbConfirm,
            this.toolStripSeparator4,
            this.tsbPrint,
            this.toolStripSeparator6,
            this.tsbClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(861, 39);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "工具栏";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(65, 36);
            this.tsbNew.Text = "新建";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(65, 36);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(65, 36);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbConfirm
            // 
            this.tsbConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfirm.Image")));
            this.tsbConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfirm.Name = "tsbConfirm";
            this.tsbConfirm.Size = new System.Drawing.Size(65, 36);
            this.tsbConfirm.Text = "审核";
            this.tsbConfirm.Click += new System.EventHandler(this.tsbConfirm_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(65, 36);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(65, 36);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // frmAntiApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 730);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvExperts);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtConfirmDesc);
            this.Controls.Add(this.txtApplyDesc);
            this.Controls.Add(this.txtIllNess);
            this.Controls.Add(this.txtDiag);
            this.Controls.Add(this.dtpConfirmDate);
            this.Controls.Add(this.btnConfirmDoct);
            this.Controls.Add(this.txtConfirmDoct);
            this.Controls.Add(this.btnApplyDoct);
            this.Controls.Add(this.txtApplyDoct);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNoDesc);
            this.Controls.Add(this.chkNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkYes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMedName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtpApplyDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmAntiApply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊抗菌药会诊申请";
            this.Load += new System.EventHandler(this.frmAntiApply_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbConfirm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIpNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.TextBox txtConfirmDesc;
        private System.Windows.Forms.TextBox txtApplyDesc;
        private System.Windows.Forms.TextBox txtIllNess;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.DateTimePicker dtpConfirmDate;
        internal PinkieControls.ButtonXP btnConfirmDoct;
        private System.Windows.Forms.TextBox txtConfirmDoct;
        internal PinkieControls.ButtonXP btnApplyDoct;
        private System.Windows.Forms.TextBox txtApplyDoct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNoDesc;
        private System.Windows.Forms.CheckBox chkNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkYes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMedName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpApplyDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private PinkieControls.ButtonXP btnAdd;
        private System.Windows.Forms.ListView lvExperts;
        private PinkieControls.ButtonXP btnDel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}