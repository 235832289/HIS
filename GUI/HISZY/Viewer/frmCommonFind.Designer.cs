namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmCommonFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommonFind));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkMZ = new System.Windows.Forms.CheckBox();
            this.chkUnionOr = new System.Windows.Forms.CheckBox();
            this.dtEnd_in = new System.Windows.Forms.DateTimePicker();
            this.dtBegin_in = new System.Windows.Forms.DateTimePicker();
            this.chkMatch = new System.Windows.Forms.CheckBox();
            this.chkUnionAnd = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.lblZyh = new System.Windows.Forms.Label();
            this.btnArea = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvPatient = new System.Windows.Forms.ListView();
            this.colNo = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colfee = new System.Windows.Forms.ColumnHeader();
            this.colZyh = new System.Windows.Forms.ColumnHeader();
            this.colZycs = new System.Windows.Forms.ColumnHeader();
            this.colArea = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colSex = new System.Windows.Forms.ColumnHeader();
            this.colAge = new System.Windows.Forms.ColumnHeader();
            this.colBirthday = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colWorklnc = new System.Windows.Forms.ColumnHeader();
            this.colIndate = new System.Windows.Forms.ColumnHeader();
            this.colOutdate = new System.Windows.Forms.ColumnHeader();
            this.colCardNo = new System.Windows.Forms.ColumnHeader();
            this.colregisterid = new System.Windows.Forms.ColumnHeader();
            this.colpid = new System.Windows.Forms.ColumnHeader();
            this.lblInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnReturn = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.btnPre = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEnd_out = new System.Windows.Forms.DateTimePicker();
            this.dtBegin_out = new System.Windows.Forms.DateTimePicker();
            this.chkInDate = new System.Windows.Forms.CheckBox();
            this.chkOutDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "m_52.gif");
            this.imageList1.Images.SetKeyName(1, "user.ico");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "到:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "从:";
            // 
            // chkMZ
            // 
            this.chkMZ.AutoSize = true;
            this.chkMZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMZ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkMZ.ForeColor = System.Drawing.Color.White;
            this.chkMZ.Location = new System.Drawing.Point(10, 383);
            this.chkMZ.Name = "chkMZ";
            this.chkMZ.Size = new System.Drawing.Size(88, 19);
            this.chkMZ.TabIndex = 18;
            this.chkMZ.Text = "门诊信息";
            this.chkMZ.UseVisualStyleBackColor = true;
            // 
            // chkUnionOr
            // 
            this.chkUnionOr.AutoSize = true;
            this.chkUnionOr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnionOr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUnionOr.ForeColor = System.Drawing.Color.White;
            this.chkUnionOr.Location = new System.Drawing.Point(10, 359);
            this.chkUnionOr.Name = "chkUnionOr";
            this.chkUnionOr.Size = new System.Drawing.Size(144, 19);
            this.chkUnionOr.TabIndex = 17;
            this.chkUnionOr.Text = "组合查找(或关系)";
            this.chkUnionOr.UseVisualStyleBackColor = true;
            this.chkUnionOr.CheckedChanged += new System.EventHandler(this.chkUnionOr_CheckedChanged);
            // 
            // dtEnd_in
            // 
            this.dtEnd_in.CustomFormat = "yyyy-MM-dd";
            this.dtEnd_in.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd_in.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd_in.Location = new System.Drawing.Point(41, 201);
            this.dtEnd_in.Name = "dtEnd_in";
            this.dtEnd_in.Size = new System.Drawing.Size(110, 23);
            this.dtEnd_in.TabIndex = 4;
            // 
            // dtBegin_in
            // 
            this.dtBegin_in.CustomFormat = "yyyy-MM-dd";
            this.dtBegin_in.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBegin_in.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin_in.Location = new System.Drawing.Point(41, 176);
            this.dtBegin_in.Name = "dtBegin_in";
            this.dtBegin_in.Size = new System.Drawing.Size(110, 23);
            this.dtBegin_in.TabIndex = 3;
            // 
            // chkMatch
            // 
            this.chkMatch.AutoSize = true;
            this.chkMatch.Checked = true;
            this.chkMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMatch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkMatch.ForeColor = System.Drawing.Color.White;
            this.chkMatch.Location = new System.Drawing.Point(10, 311);
            this.chkMatch.Name = "chkMatch";
            this.chkMatch.Size = new System.Drawing.Size(88, 19);
            this.chkMatch.TabIndex = 15;
            this.chkMatch.Text = "模糊查找";
            this.chkMatch.UseVisualStyleBackColor = true;
            // 
            // chkUnionAnd
            // 
            this.chkUnionAnd.AutoSize = true;
            this.chkUnionAnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnionAnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUnionAnd.ForeColor = System.Drawing.Color.White;
            this.chkUnionAnd.Location = new System.Drawing.Point(10, 335);
            this.chkUnionAnd.Name = "chkUnionAnd";
            this.chkUnionAnd.Size = new System.Drawing.Size(144, 19);
            this.chkUnionAnd.TabIndex = 14;
            this.chkUnionAnd.Text = "组合查找(与关系)";
            this.chkUnionAnd.UseVisualStyleBackColor = true;
            this.chkUnionAnd.CheckedChanged += new System.EventHandler(this.chkUnionAnd_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(9, 123);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 23);
            this.txtName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "按姓名:";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardNo.Location = new System.Drawing.Point(9, 73);
            this.txtCardNo.MaxLength = 10;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(142, 23);
            this.txtCardNo.TabIndex = 1;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCardNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCardNo.ForeColor = System.Drawing.Color.White;
            this.lblCardNo.Location = new System.Drawing.Point(7, 55);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(84, 14);
            this.lblCardNo.TabIndex = 10;
            this.lblCardNo.Text = "按诊疗卡号:";
            this.lblCardNo.MouseLeave += new System.EventHandler(this.lblCardNo_MouseLeave);
            this.lblCardNo.Click += new System.EventHandler(this.lblCardNo_Click);
            this.lblCardNo.MouseEnter += new System.EventHandler(this.lblCardNo_MouseEnter);
            // 
            // txtZyh
            // 
            this.txtZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZyh.Location = new System.Drawing.Point(9, 25);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(142, 23);
            this.txtZyh.TabIndex = 0;
            // 
            // lblZyh
            // 
            this.lblZyh.AutoSize = true;
            this.lblZyh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.ForeColor = System.Drawing.Color.White;
            this.lblZyh.Location = new System.Drawing.Point(7, 7);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(70, 14);
            this.lblZyh.TabIndex = 8;
            this.lblZyh.Text = "按住院号:";
            this.lblZyh.MouseLeave += new System.EventHandler(this.lblZyh_MouseLeave);
            this.lblZyh.Click += new System.EventHandler(this.lblZyh_Click);
            this.lblZyh.MouseEnter += new System.EventHandler(this.lblZyh_MouseEnter);
            // 
            // btnArea
            // 
            this.btnArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArea.DefaultScheme = true;
            this.btnArea.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnArea.Hint = "";
            this.btnArea.Location = new System.Drawing.Point(27, 480);
            this.btnArea.Name = "btnArea";
            this.btnArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnArea.Size = new System.Drawing.Size(110, 32);
            this.btnArea.TabIndex = 7;
            this.btnArea.Text = "浏览病区      ";
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(27, 410);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(110, 32);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "查找   F3";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 586);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 655);
            this.label1.TabIndex = 4;
            // 
            // lsvPatient
            // 
            this.lsvPatient.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colStatus,
            this.colfee,
            this.colZyh,
            this.colZycs,
            this.colArea,
            this.colName,
            this.colSex,
            this.colAge,
            this.colBirthday,
            this.colAddress,
            this.colWorklnc,
            this.colIndate,
            this.colOutdate,
            this.colCardNo,
            this.colregisterid,
            this.colpid});
            this.lsvPatient.Dock = System.Windows.Forms.DockStyle.Right;
            this.lsvPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvPatient.FullRowSelect = true;
            this.lsvPatient.Location = new System.Drawing.Point(160, 0);
            this.lsvPatient.MultiSelect = false;
            this.lsvPatient.Name = "lsvPatient";
            this.lsvPatient.Size = new System.Drawing.Size(844, 655);
            this.lsvPatient.SmallImageList = this.imageList1;
            this.lsvPatient.TabIndex = 3;
            this.lsvPatient.UseCompatibleStateImageBehavior = false;
            this.lsvPatient.View = System.Windows.Forms.View.Details;
            this.lsvPatient.DoubleClick += new System.EventHandler(this.lsvPatient_DoubleClick);
            this.lsvPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvPatient_KeyDown);
            this.lsvPatient.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvPatient_ColumnClick);
            // 
            // colNo
            // 
            this.colNo.Text = "序号";
            this.colNo.Width = 41;
            // 
            // colStatus
            // 
            this.colStatus.Text = "状态";
            this.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStatus.Width = 45;
            // 
            // colfee
            // 
            this.colfee.Text = "费用";
            this.colfee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colfee.Width = 63;
            // 
            // colZyh
            // 
            this.colZyh.Text = "住院号";
            this.colZyh.Width = 73;
            // 
            // colZycs
            // 
            this.colZycs.Text = "次数";
            this.colZycs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colZycs.Width = 42;
            // 
            // colArea
            // 
            this.colArea.Text = "病区";
            this.colArea.Width = 102;
            // 
            // colName
            // 
            this.colName.Text = "姓名";
            this.colName.Width = 69;
            // 
            // colSex
            // 
            this.colSex.Text = "性别";
            this.colSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSex.Width = 40;
            // 
            // colAge
            // 
            this.colAge.Text = "年龄";
            this.colAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAge.Width = 40;
            // 
            // colBirthday
            // 
            this.colBirthday.Text = "出生日期";
            this.colBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBirthday.Width = 101;
            // 
            // colAddress
            // 
            this.colAddress.Text = "地址";
            this.colAddress.Width = 200;
            // 
            // colWorklnc
            // 
            this.colWorklnc.Text = "工作单位";
            this.colWorklnc.Width = 77;
            // 
            // colIndate
            // 
            this.colIndate.Text = "入院时间";
            this.colIndate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIndate.Width = 114;
            // 
            // colOutdate
            // 
            this.colOutdate.Text = "出院时间";
            this.colOutdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOutdate.Width = 110;
            // 
            // colCardNo
            // 
            this.colCardNo.Text = "诊疗卡号";
            this.colCardNo.Width = 150;
            // 
            // colregisterid
            // 
            this.colregisterid.Text = "";
            this.colregisterid.Width = 0;
            // 
            // colpid
            // 
            this.colpid.Width = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Location = new System.Drawing.Point(0, 655);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1004, 20);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "按[F5]键查看前一次查找到的病人资料";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.DefaultScheme = true;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Hint = "";
            this.btnReturn.Location = new System.Drawing.Point(27, 550);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReturn.Size = new System.Drawing.Size(110, 32);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "返回  Esc";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(27, 515);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "确定Enter";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnPre
            // 
            this.btnPre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnPre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPre.DefaultScheme = true;
            this.btnPre.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPre.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPre.Hint = "";
            this.btnPre.Location = new System.Drawing.Point(27, 445);
            this.btnPre.Name = "btnPre";
            this.btnPre.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPre.Size = new System.Drawing.Size(110, 32);
            this.btnPre.TabIndex = 23;
            this.btnPre.Text = "前一个 F5";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "到:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "从:";
            // 
            // dtEnd_out
            // 
            this.dtEnd_out.CustomFormat = "yyyy-MM-dd";
            this.dtEnd_out.Enabled = false;
            this.dtEnd_out.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd_out.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd_out.Location = new System.Drawing.Point(41, 278);
            this.dtEnd_out.Name = "dtEnd_out";
            this.dtEnd_out.Size = new System.Drawing.Size(110, 23);
            this.dtEnd_out.TabIndex = 25;
            // 
            // dtBegin_out
            // 
            this.dtBegin_out.CustomFormat = "yyyy-MM-dd";
            this.dtBegin_out.Enabled = false;
            this.dtBegin_out.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBegin_out.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin_out.Location = new System.Drawing.Point(41, 253);
            this.dtBegin_out.Name = "dtBegin_out";
            this.dtBegin_out.Size = new System.Drawing.Size(110, 23);
            this.dtBegin_out.TabIndex = 24;
            // 
            // chkInDate
            // 
            this.chkInDate.AutoSize = true;
            this.chkInDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkInDate.ForeColor = System.Drawing.Color.White;
            this.chkInDate.Location = new System.Drawing.Point(10, 154);
            this.chkInDate.Name = "chkInDate";
            this.chkInDate.Size = new System.Drawing.Size(96, 18);
            this.chkInDate.TabIndex = 29;
            this.chkInDate.Text = "按入院时间";
            this.chkInDate.UseVisualStyleBackColor = true;
            this.chkInDate.CheckedChanged += new System.EventHandler(this.chkInDate_CheckedChanged);
            // 
            // chkOutDate
            // 
            this.chkOutDate.AutoSize = true;
            this.chkOutDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOutDate.ForeColor = System.Drawing.Color.White;
            this.chkOutDate.Location = new System.Drawing.Point(10, 232);
            this.chkOutDate.Name = "chkOutDate";
            this.chkOutDate.Size = new System.Drawing.Size(96, 18);
            this.chkOutDate.TabIndex = 30;
            this.chkOutDate.Text = "按出院时间";
            this.chkOutDate.UseVisualStyleBackColor = true;
            this.chkOutDate.CheckedChanged += new System.EventHandler(this.chkOutDate_CheckedChanged);
            // 
            // frmCommonFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1004, 675);
            this.Controls.Add(this.chkOutDate);
            this.Controls.Add(this.chkInDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtEnd_out);
            this.Controls.Add(this.dtBegin_out);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkMZ);
            this.Controls.Add(this.chkUnionOr);
            this.Controls.Add(this.dtEnd_in);
            this.Controls.Add(this.dtBegin_in);
            this.Controls.Add(this.chkMatch);
            this.Controls.Add(this.chkUnionAnd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblCardNo);
            this.Controls.Add(this.txtZyh);
            this.Controls.Add(this.lblZyh);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvPatient);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCommonFind";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找病人信息";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommonFind_KeyDown);
            this.Load += new System.EventHandler(this.frmCommonFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colZyh;
        private System.Windows.Forms.ColumnHeader colZycs;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSex;
        private System.Windows.Forms.ColumnHeader colBirthday;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colIndate;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colAge;
        private System.Windows.Forms.ColumnHeader colOutdate;
        private System.Windows.Forms.ColumnHeader colregisterid;
        private System.Windows.Forms.ColumnHeader colpid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ListView lsvPatient;
        internal System.Windows.Forms.TextBox txtZyh;
        internal System.Windows.Forms.TextBox txtCardNo;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.DateTimePicker dtBegin_in;
        internal System.Windows.Forms.DateTimePicker dtEnd_in;
        internal System.Windows.Forms.CheckBox chkMatch;
        internal System.Windows.Forms.CheckBox chkUnionAnd;
        internal PinkieControls.ButtonXP btnFind;
        internal PinkieControls.ButtonXP btnArea;
        internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader colStatus;
        internal System.Windows.Forms.CheckBox chkUnionOr;
        internal System.Windows.Forms.CheckBox chkMZ;
        private System.Windows.Forms.ColumnHeader colfee;
        private System.Windows.Forms.ColumnHeader colWorklnc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader colCardNo;
        internal PinkieControls.ButtonXP btnReturn;
        internal PinkieControls.ButtonXP btnOk;
        internal PinkieControls.ButtonXP btnPre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtEnd_out;
        internal System.Windows.Forms.DateTimePicker dtBegin_out;
        internal System.Windows.Forms.CheckBox chkInDate;
        internal System.Windows.Forms.CheckBox chkOutDate;

    }
}