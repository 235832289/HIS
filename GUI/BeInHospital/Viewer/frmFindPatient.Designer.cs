namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmFindPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindPatient));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnReturn = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.btnNew = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user.ico");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 530);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1004, 675);
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
            this.lsvPatient.DoubleClick += new System.EventHandler(this.btnOk_Click);
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
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.DefaultScheme = true;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Hint = "";
            this.btnReturn.Location = new System.Drawing.Point(28, 161);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReturn.Size = new System.Drawing.Size(110, 32);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "取 消(&C)";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10F);
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(28, 57);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "选 中(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.DefaultScheme = true;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Hint = "";
            this.btnNew.Location = new System.Drawing.Point(28, 112);
            this.btnNew.Name = "btnNew";
            this.btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnNew.Size = new System.Drawing.Size(110, 32);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "新病人(&N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmFindPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1004, 675);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lsvPatient);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmFindPatient";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "历史病人信息";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFindPatient_KeyDown);
            this.Load += new System.EventHandler(this.frmCommonFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        internal System.Windows.Forms.ListView lsvPatient;
        internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colfee;
        private System.Windows.Forms.ColumnHeader colWorklnc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader colCardNo;
        internal PinkieControls.ButtonXP btnReturn;
        internal PinkieControls.ButtonXP btnOk;
        internal PinkieControls.ButtonXP btnNew;

    }
}