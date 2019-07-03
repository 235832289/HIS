namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmModifyZyh : com.digitalwave.GUI_Base.frmMDI_Child_Base 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyZyh));
            this.btnFind = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUnion = new System.Windows.Forms.CheckBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnFindOldNO = new PinkieControls.ButtonXP();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewNO = new System.Windows.Forms.TextBox();
            this.lblNewNO = new System.Windows.Forms.Label();
            this.btnModify = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblzyh1 = new System.Windows.Forms.Label();
            this.lblzycs1 = new System.Windows.Forms.Label();
            this.lblname1 = new System.Windows.Forms.Label();
            this.lblsex1 = new System.Windows.Forms.Label();
            this.lblbirthday1 = new System.Windows.Forms.Label();
            this.lblidcard1 = new System.Windows.Forms.Label();
            this.lbladdress1 = new System.Windows.Forms.Label();
            this.lblintype1 = new System.Windows.Forms.Label();
            this.lblindate1 = new System.Windows.Forms.Label();
            this.lblarea1 = new System.Windows.Forms.Label();
            this.lblbed1 = new System.Windows.Forms.Label();
            this.lblstatus1 = new System.Windows.Forms.Label();
            this.lblzycs2 = new System.Windows.Forms.Label();
            this.lblzyh2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblsex2 = new System.Windows.Forms.Label();
            this.lblname2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblidcard2 = new System.Windows.Forms.Label();
            this.lblbirthday2 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lbladdress2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblindate2 = new System.Windows.Forms.Label();
            this.lblintype2 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblbed2 = new System.Windows.Forms.Label();
            this.lblarea2 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lbloutarea = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lbloutdate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(703, 18);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(76, 36);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(779, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(76, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 524);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "本次住院信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(433, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 524);
            this.label3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnion);
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.btnFindOldNO);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNewNO);
            this.groupBox1.Controls.Add(this.lblNewNO);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(2, 524);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 66);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chkUnion
            // 
            this.chkUnion.AutoSize = true;
            this.chkUnion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUnion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUnion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUnion.Location = new System.Drawing.Point(574, 28);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Size = new System.Drawing.Size(46, 16);
            this.chkUnion.TabIndex = 10;
            this.chkUnion.Text = "合并";
            this.chkUnion.UseVisualStyleBackColor = true;
            this.chkUnion.CheckedChanged += new System.EventHandler(this.chkUnion_CheckedChanged);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAuto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAuto.Location = new System.Drawing.Point(502, 28);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(70, 16);
            this.chkAuto.TabIndex = 9;
            this.chkAuto.Text = "自动生成";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // btnFindOldNO
            // 
            this.btnFindOldNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFindOldNO.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFindOldNO.DefaultScheme = true;
            this.btnFindOldNO.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFindOldNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindOldNO.Hint = "";
            this.btnFindOldNO.Location = new System.Drawing.Point(208, 18);
            this.btnFindOldNO.Name = "btnFindOldNO";
            this.btnFindOldNO.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFindOldNO.Size = new System.Drawing.Size(76, 36);
            this.btnFindOldNO.TabIndex = 1;
            this.btnFindOldNO.Text = "找旧号";
            this.btnFindOldNO.Click += new System.EventHandler(this.btnFindOldNO_Click);
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.SystemColors.Control;
            this.cboType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.Font = new System.Drawing.Font("宋体", 11.5F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "住院号->住院号",
            "住院号->留观号",
            "留观号->留观号",
            "留观号->住院号"});
            this.cboType.Location = new System.Drawing.Point(71, 24);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(134, 23);
            this.cboType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(2, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "修改类型:";
            // 
            // txtNewNO
            // 
            this.txtNewNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewNO.Enabled = false;
            this.txtNewNO.Font = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtNewNO.Location = new System.Drawing.Point(399, 24);
            this.txtNewNO.Name = "txtNewNO";
            this.txtNewNO.Size = new System.Drawing.Size(97, 26);
            this.txtNewNO.TabIndex = 0;
            // 
            // lblNewNO
            // 
            this.lblNewNO.AutoSize = true;
            this.lblNewNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNewNO.Location = new System.Drawing.Point(289, 28);
            this.lblNewNO.Name = "lblNewNO";
            this.lblNewNO.Size = new System.Drawing.Size(112, 14);
            this.lblNewNO.TabIndex = 6;
            this.lblNewNO.Text = "新住院(留观)号:";
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnModify.DefaultScheme = true;
            this.btnModify.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnModify.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.Hint = "";
            this.btnModify.Location = new System.Drawing.Point(624, 18);
            this.btnModify.Name = "btnModify";
            this.btnModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnModify.Size = new System.Drawing.Size(76, 36);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "更改(&M)";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "住院(留观)号:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(68, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "姓名:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(40, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "出生日期:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(40, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "家庭地址:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(216, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "住院次数:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(244, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "性别:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(216, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 12;
            this.label11.Text = "身份证号:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(40, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "入院类型:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(216, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 14;
            this.label13.Text = "入院时间:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(40, 362);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 15;
            this.label14.Text = "入院病区:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(230, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 14);
            this.label15.TabIndex = 16;
            this.label15.Text = "床位号:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(68, 420);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 14);
            this.label16.TabIndex = 17;
            this.label16.Text = "状态:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(446, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 14);
            this.label17.TabIndex = 18;
            this.label17.Text = "旧号最近历史住院信息";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblzyh1
            // 
            this.lblzyh1.AutoSize = true;
            this.lblzyh1.BackColor = System.Drawing.Color.White;
            this.lblzyh1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzyh1.ForeColor = System.Drawing.Color.Red;
            this.lblzyh1.Location = new System.Drawing.Point(113, 72);
            this.lblzyh1.Name = "lblzyh1";
            this.lblzyh1.Size = new System.Drawing.Size(0, 14);
            this.lblzyh1.TabIndex = 19;
            this.lblzyh1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblzycs1
            // 
            this.lblzycs1.AutoSize = true;
            this.lblzycs1.BackColor = System.Drawing.Color.White;
            this.lblzycs1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzycs1.ForeColor = System.Drawing.Color.Red;
            this.lblzycs1.Location = new System.Drawing.Point(285, 72);
            this.lblzycs1.Name = "lblzycs1";
            this.lblzycs1.Size = new System.Drawing.Size(0, 14);
            this.lblzycs1.TabIndex = 20;
            this.lblzycs1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblname1
            // 
            this.lblname1.AutoSize = true;
            this.lblname1.BackColor = System.Drawing.Color.White;
            this.lblname1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname1.ForeColor = System.Drawing.Color.Red;
            this.lblname1.Location = new System.Drawing.Point(113, 130);
            this.lblname1.Name = "lblname1";
            this.lblname1.Size = new System.Drawing.Size(0, 14);
            this.lblname1.TabIndex = 21;
            this.lblname1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsex1
            // 
            this.lblsex1.AutoSize = true;
            this.lblsex1.BackColor = System.Drawing.Color.White;
            this.lblsex1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsex1.ForeColor = System.Drawing.Color.Black;
            this.lblsex1.Location = new System.Drawing.Point(285, 130);
            this.lblsex1.Name = "lblsex1";
            this.lblsex1.Size = new System.Drawing.Size(0, 14);
            this.lblsex1.TabIndex = 22;
            this.lblsex1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblbirthday1
            // 
            this.lblbirthday1.AutoSize = true;
            this.lblbirthday1.BackColor = System.Drawing.Color.White;
            this.lblbirthday1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbirthday1.ForeColor = System.Drawing.Color.Black;
            this.lblbirthday1.Location = new System.Drawing.Point(113, 188);
            this.lblbirthday1.Name = "lblbirthday1";
            this.lblbirthday1.Size = new System.Drawing.Size(0, 14);
            this.lblbirthday1.TabIndex = 23;
            this.lblbirthday1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblidcard1
            // 
            this.lblidcard1.AutoSize = true;
            this.lblidcard1.BackColor = System.Drawing.Color.White;
            this.lblidcard1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblidcard1.ForeColor = System.Drawing.Color.Black;
            this.lblidcard1.Location = new System.Drawing.Point(285, 188);
            this.lblidcard1.Name = "lblidcard1";
            this.lblidcard1.Size = new System.Drawing.Size(0, 14);
            this.lblidcard1.TabIndex = 24;
            this.lblidcard1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbladdress1
            // 
            this.lbladdress1.AutoSize = true;
            this.lbladdress1.BackColor = System.Drawing.Color.White;
            this.lbladdress1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbladdress1.ForeColor = System.Drawing.Color.Black;
            this.lbladdress1.Location = new System.Drawing.Point(113, 246);
            this.lbladdress1.Name = "lbladdress1";
            this.lbladdress1.Size = new System.Drawing.Size(0, 14);
            this.lbladdress1.TabIndex = 25;
            this.lbladdress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblintype1
            // 
            this.lblintype1.AutoSize = true;
            this.lblintype1.BackColor = System.Drawing.Color.White;
            this.lblintype1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblintype1.ForeColor = System.Drawing.Color.Red;
            this.lblintype1.Location = new System.Drawing.Point(113, 304);
            this.lblintype1.Name = "lblintype1";
            this.lblintype1.Size = new System.Drawing.Size(0, 14);
            this.lblintype1.TabIndex = 26;
            this.lblintype1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblindate1
            // 
            this.lblindate1.AutoSize = true;
            this.lblindate1.BackColor = System.Drawing.Color.White;
            this.lblindate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblindate1.ForeColor = System.Drawing.Color.Black;
            this.lblindate1.Location = new System.Drawing.Point(285, 304);
            this.lblindate1.Name = "lblindate1";
            this.lblindate1.Size = new System.Drawing.Size(0, 14);
            this.lblindate1.TabIndex = 27;
            this.lblindate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblarea1
            // 
            this.lblarea1.AutoSize = true;
            this.lblarea1.BackColor = System.Drawing.Color.White;
            this.lblarea1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblarea1.ForeColor = System.Drawing.Color.Black;
            this.lblarea1.Location = new System.Drawing.Point(113, 362);
            this.lblarea1.Name = "lblarea1";
            this.lblarea1.Size = new System.Drawing.Size(0, 14);
            this.lblarea1.TabIndex = 28;
            this.lblarea1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblbed1
            // 
            this.lblbed1.AutoSize = true;
            this.lblbed1.BackColor = System.Drawing.Color.White;
            this.lblbed1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbed1.ForeColor = System.Drawing.Color.Black;
            this.lblbed1.Location = new System.Drawing.Point(285, 362);
            this.lblbed1.Name = "lblbed1";
            this.lblbed1.Size = new System.Drawing.Size(0, 14);
            this.lblbed1.TabIndex = 29;
            this.lblbed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblstatus1
            // 
            this.lblstatus1.AutoSize = true;
            this.lblstatus1.BackColor = System.Drawing.Color.White;
            this.lblstatus1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblstatus1.ForeColor = System.Drawing.Color.Black;
            this.lblstatus1.Location = new System.Drawing.Point(113, 420);
            this.lblstatus1.Name = "lblstatus1";
            this.lblstatus1.Size = new System.Drawing.Size(0, 14);
            this.lblstatus1.TabIndex = 30;
            this.lblstatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblzycs2
            // 
            this.lblzycs2.AutoSize = true;
            this.lblzycs2.BackColor = System.Drawing.Color.White;
            this.lblzycs2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzycs2.ForeColor = System.Drawing.Color.Blue;
            this.lblzycs2.Location = new System.Drawing.Point(719, 72);
            this.lblzycs2.Name = "lblzycs2";
            this.lblzycs2.Size = new System.Drawing.Size(0, 14);
            this.lblzycs2.TabIndex = 34;
            this.lblzycs2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblzyh2
            // 
            this.lblzyh2.AutoSize = true;
            this.lblzyh2.BackColor = System.Drawing.Color.White;
            this.lblzyh2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzyh2.ForeColor = System.Drawing.Color.Blue;
            this.lblzyh2.Location = new System.Drawing.Point(547, 72);
            this.lblzyh2.Name = "lblzyh2";
            this.lblzyh2.Size = new System.Drawing.Size(0, 14);
            this.lblzyh2.TabIndex = 33;
            this.lblzyh2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(650, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 14);
            this.label20.TabIndex = 32;
            this.label20.Text = "住院次数:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(446, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 14);
            this.label21.TabIndex = 31;
            this.label21.Text = "住院(留观)号:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblsex2
            // 
            this.lblsex2.AutoSize = true;
            this.lblsex2.BackColor = System.Drawing.Color.White;
            this.lblsex2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsex2.ForeColor = System.Drawing.Color.Black;
            this.lblsex2.Location = new System.Drawing.Point(719, 130);
            this.lblsex2.Name = "lblsex2";
            this.lblsex2.Size = new System.Drawing.Size(0, 14);
            this.lblsex2.TabIndex = 38;
            this.lblsex2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblname2
            // 
            this.lblname2.AutoSize = true;
            this.lblname2.BackColor = System.Drawing.Color.White;
            this.lblname2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname2.ForeColor = System.Drawing.Color.Blue;
            this.lblname2.Location = new System.Drawing.Point(547, 130);
            this.lblname2.Name = "lblname2";
            this.lblname2.Size = new System.Drawing.Size(0, 14);
            this.lblname2.TabIndex = 37;
            this.lblname2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(678, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 14);
            this.label24.TabIndex = 36;
            this.label24.Text = "性别:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(502, 130);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 14);
            this.label25.TabIndex = 35;
            this.label25.Text = "姓名:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblidcard2
            // 
            this.lblidcard2.AutoSize = true;
            this.lblidcard2.BackColor = System.Drawing.Color.White;
            this.lblidcard2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblidcard2.ForeColor = System.Drawing.Color.Black;
            this.lblidcard2.Location = new System.Drawing.Point(719, 188);
            this.lblidcard2.Name = "lblidcard2";
            this.lblidcard2.Size = new System.Drawing.Size(0, 14);
            this.lblidcard2.TabIndex = 42;
            this.lblidcard2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblbirthday2
            // 
            this.lblbirthday2.AutoSize = true;
            this.lblbirthday2.BackColor = System.Drawing.Color.White;
            this.lblbirthday2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbirthday2.ForeColor = System.Drawing.Color.Black;
            this.lblbirthday2.Location = new System.Drawing.Point(547, 188);
            this.lblbirthday2.Name = "lblbirthday2";
            this.lblbirthday2.Size = new System.Drawing.Size(0, 14);
            this.lblbirthday2.TabIndex = 41;
            this.lblbirthday2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.White;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(650, 188);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 40;
            this.label28.Text = "身份证号:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(474, 188);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 14);
            this.label29.TabIndex = 39;
            this.label29.Text = "出生日期:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbladdress2
            // 
            this.lbladdress2.AutoSize = true;
            this.lbladdress2.BackColor = System.Drawing.Color.White;
            this.lbladdress2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbladdress2.ForeColor = System.Drawing.Color.Black;
            this.lbladdress2.Location = new System.Drawing.Point(547, 246);
            this.lbladdress2.Name = "lbladdress2";
            this.lbladdress2.Size = new System.Drawing.Size(0, 14);
            this.lbladdress2.TabIndex = 44;
            this.lbladdress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.White;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(474, 246);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(70, 14);
            this.label31.TabIndex = 43;
            this.label31.Text = "家庭地址:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblindate2
            // 
            this.lblindate2.AutoSize = true;
            this.lblindate2.BackColor = System.Drawing.Color.White;
            this.lblindate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblindate2.ForeColor = System.Drawing.Color.Black;
            this.lblindate2.Location = new System.Drawing.Point(719, 304);
            this.lblindate2.Name = "lblindate2";
            this.lblindate2.Size = new System.Drawing.Size(0, 14);
            this.lblindate2.TabIndex = 48;
            this.lblindate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblintype2
            // 
            this.lblintype2.AutoSize = true;
            this.lblintype2.BackColor = System.Drawing.Color.White;
            this.lblintype2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblintype2.ForeColor = System.Drawing.Color.Blue;
            this.lblintype2.Location = new System.Drawing.Point(547, 304);
            this.lblintype2.Name = "lblintype2";
            this.lblintype2.Size = new System.Drawing.Size(0, 14);
            this.lblintype2.TabIndex = 47;
            this.lblintype2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(650, 304);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 14);
            this.label34.TabIndex = 46;
            this.label34.Text = "入院时间:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.White;
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(474, 304);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 14);
            this.label35.TabIndex = 45;
            this.label35.Text = "入院类型:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblbed2
            // 
            this.lblbed2.AutoSize = true;
            this.lblbed2.BackColor = System.Drawing.Color.White;
            this.lblbed2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbed2.ForeColor = System.Drawing.Color.Black;
            this.lblbed2.Location = new System.Drawing.Point(547, 420);
            this.lblbed2.Name = "lblbed2";
            this.lblbed2.Size = new System.Drawing.Size(0, 14);
            this.lblbed2.TabIndex = 52;
            this.lblbed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblarea2
            // 
            this.lblarea2.AutoSize = true;
            this.lblarea2.BackColor = System.Drawing.Color.White;
            this.lblarea2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblarea2.ForeColor = System.Drawing.Color.Black;
            this.lblarea2.Location = new System.Drawing.Point(547, 362);
            this.lblarea2.Name = "lblarea2";
            this.lblarea2.Size = new System.Drawing.Size(0, 14);
            this.lblarea2.TabIndex = 51;
            this.lblarea2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.White;
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(650, 362);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(70, 14);
            this.label38.TabIndex = 50;
            this.label38.Text = "出院病区:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(474, 362);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 14);
            this.label39.TabIndex = 49;
            this.label39.Text = "入院病区:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbloutarea
            // 
            this.lbloutarea.AutoSize = true;
            this.lbloutarea.BackColor = System.Drawing.Color.White;
            this.lbloutarea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbloutarea.ForeColor = System.Drawing.Color.Black;
            this.lbloutarea.Location = new System.Drawing.Point(719, 362);
            this.lbloutarea.Name = "lbloutarea";
            this.lbloutarea.Size = new System.Drawing.Size(0, 14);
            this.lbloutarea.TabIndex = 54;
            this.lbloutarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.White;
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(460, 420);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(84, 14);
            this.label41.TabIndex = 53;
            this.label41.Text = "出院床位号:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.White;
            this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(650, 420);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 14);
            this.label42.TabIndex = 55;
            this.label42.Text = "出院时间:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbloutdate
            // 
            this.lbloutdate.AutoSize = true;
            this.lbloutdate.BackColor = System.Drawing.Color.White;
            this.lbloutdate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbloutdate.ForeColor = System.Drawing.Color.Black;
            this.lbloutdate.Location = new System.Drawing.Point(719, 420);
            this.lbloutdate.Name = "lbloutdate";
            this.lbloutdate.Size = new System.Drawing.Size(0, 14);
            this.lbloutdate.TabIndex = 56;
            this.lbloutdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmModifyZyh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 595);
            this.Controls.Add(this.lbloutdate);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.lbloutarea);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.lblbed2);
            this.Controls.Add(this.lblarea2);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.lblindate2);
            this.Controls.Add(this.lblintype2);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.lbladdress2);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblidcard2);
            this.Controls.Add(this.lblbirthday2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblsex2);
            this.Controls.Add(this.lblname2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblzycs2);
            this.Controls.Add(this.lblzyh2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblstatus1);
            this.Controls.Add(this.lblbed1);
            this.Controls.Add(this.lblarea1);
            this.Controls.Add(this.lblindate1);
            this.Controls.Add(this.lblintype1);
            this.Controls.Add(this.lbladdress1);
            this.Controls.Add(this.lblidcard1);
            this.Controls.Add(this.lblbirthday1);
            this.Controls.Add(this.lblsex1);
            this.Controls.Add(this.lblname1);
            this.Controls.Add(this.lblzycs1);
            this.Controls.Add(this.lblzyh1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmModifyZyh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改住院(留观)号";
            this.Load += new System.EventHandler(this.frmModifyZyh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModifyZyh_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnFind;
        internal PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        internal PinkieControls.ButtonXP btnModify;
        internal System.Windows.Forms.Label lblNewNO;
        internal System.Windows.Forms.TextBox txtNewNO;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label lblzyh1;
        internal System.Windows.Forms.Label lblname1;
        internal System.Windows.Forms.Label lblsex1;
        internal System.Windows.Forms.Label lblbirthday1;
        internal System.Windows.Forms.Label lblidcard1;
        internal System.Windows.Forms.Label lbladdress1;
        internal System.Windows.Forms.Label lblintype1;
        internal System.Windows.Forms.Label lblindate1;
        internal System.Windows.Forms.Label lblarea1;
        internal System.Windows.Forms.Label lblbed1;
        internal System.Windows.Forms.Label lblstatus1;
        internal System.Windows.Forms.Label lblzyh2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label lblsex2;
        internal System.Windows.Forms.Label lblname2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        internal System.Windows.Forms.Label lblidcard2;
        internal System.Windows.Forms.Label lblbirthday2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.Label lbladdress2;
        private System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label lblindate2;
        internal System.Windows.Forms.Label lblintype2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        internal System.Windows.Forms.Label lblbed2;
        internal System.Windows.Forms.Label lblarea2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        internal System.Windows.Forms.Label lbloutarea;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        internal System.Windows.Forms.Label lbloutdate;
        internal System.Windows.Forms.Label lblzycs1;
        internal System.Windows.Forms.Label lblzycs2;
        internal PinkieControls.ButtonXP btnFindOldNO;
        internal System.Windows.Forms.CheckBox chkAuto;
        internal System.Windows.Forms.CheckBox chkUnion;
    }
}