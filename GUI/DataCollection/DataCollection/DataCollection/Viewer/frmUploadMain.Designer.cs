namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class frmUploadMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadMain));
            this.btnDiagInfoUpload = new PinkieControls.ButtonXP();
            this.btnOpfeeUpload = new PinkieControls.ButtonXP();
            this.btnRecInfoUpload = new PinkieControls.ButtonXP();
            this.btnClose = new System.Windows.Forms.Button();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.cmdDrugUpload = new PinkieControls.ButtonXP();
            this.m_cmdCheckRecordUpload = new PinkieControls.ButtonXP();
            this.btnEmrUpload = new PinkieControls.ButtonXP();
            this.btnLisUpload = new PinkieControls.ButtonXP();
            this.btnOPInfoUpload = new PinkieControls.ButtonXP();
            this.lsvInfor = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTran = new PinkieControls.ButtonXP();
            this.lblCurrentInfo = new System.Windows.Forms.Label();
            this.pgbTask = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDiagInfoUpload
            // 
            this.btnDiagInfoUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDiagInfoUpload.DefaultScheme = true;
            this.btnDiagInfoUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDiagInfoUpload.Hint = "";
            this.btnDiagInfoUpload.Location = new System.Drawing.Point(253, 189);
            this.btnDiagInfoUpload.Name = "btnDiagInfoUpload";
            this.btnDiagInfoUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDiagInfoUpload.Size = new System.Drawing.Size(18, 14);
            this.btnDiagInfoUpload.TabIndex = 0;
            this.btnDiagInfoUpload.Text = "门诊就诊信息上报";
            this.btnDiagInfoUpload.Visible = false;
            this.btnDiagInfoUpload.Click += new System.EventHandler(this.btnDiagInfoUpload_Click);
            // 
            // btnOpfeeUpload
            // 
            this.btnOpfeeUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOpfeeUpload.DefaultScheme = true;
            this.btnOpfeeUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOpfeeUpload.Hint = "";
            this.btnOpfeeUpload.Location = new System.Drawing.Point(253, 209);
            this.btnOpfeeUpload.Name = "btnOpfeeUpload";
            this.btnOpfeeUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOpfeeUpload.Size = new System.Drawing.Size(18, 14);
            this.btnOpfeeUpload.TabIndex = 1;
            this.btnOpfeeUpload.Text = "门诊费用信息上报";
            this.btnOpfeeUpload.Visible = false;
            this.btnOpfeeUpload.Click += new System.EventHandler(this.btnOpfeeUpload_Click);
            // 
            // btnRecInfoUpload
            // 
            this.btnRecInfoUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRecInfoUpload.DefaultScheme = true;
            this.btnRecInfoUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRecInfoUpload.Hint = "";
            this.btnRecInfoUpload.Location = new System.Drawing.Point(253, 229);
            this.btnRecInfoUpload.Name = "btnRecInfoUpload";
            this.btnRecInfoUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRecInfoUpload.Size = new System.Drawing.Size(18, 14);
            this.btnRecInfoUpload.TabIndex = 2;
            this.btnRecInfoUpload.Text = "门诊处方信息上报";
            this.btnRecInfoUpload.Visible = false;
            this.btnRecInfoUpload.Click += new System.EventHandler(this.btnRecInfoUpload_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(204, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 27);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = " 关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.Bisque;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BorderColor = System.Drawing.Color.SteelBlue;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.cmdDrugUpload);
            this.grouper1.Controls.Add(this.m_cmdCheckRecordUpload);
            this.grouper1.Controls.Add(this.btnEmrUpload);
            this.grouper1.Controls.Add(this.btnLisUpload);
            this.grouper1.Controls.Add(this.btnOPInfoUpload);
            this.grouper1.Controls.Add(this.lsvInfor);
            this.grouper1.Controls.Add(this.dtpTime);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.Controls.Add(this.cmdTran);
            this.grouper1.Controls.Add(this.lblCurrentInfo);
            this.grouper1.Controls.Add(this.pgbTask);
            this.grouper1.Controls.Add(this.btnDiagInfoUpload);
            this.grouper1.Controls.Add(this.btnClose);
            this.grouper1.Controls.Add(this.btnOpfeeUpload);
            this.grouper1.Controls.Add(this.btnRecInfoUpload);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "";
            this.grouper1.Location = new System.Drawing.Point(1, -6);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(300, 405);
            this.grouper1.TabIndex = 5;
            this.grouper1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grouper1_MouseDown);
            // 
            // cmdDrugUpload
            // 
            this.cmdDrugUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdDrugUpload.DefaultScheme = true;
            this.cmdDrugUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdDrugUpload.Hint = "";
            this.cmdDrugUpload.Location = new System.Drawing.Point(53, 112);
            this.cmdDrugUpload.Name = "cmdDrugUpload";
            this.cmdDrugUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdDrugUpload.Size = new System.Drawing.Size(169, 36);
            this.cmdDrugUpload.TabIndex = 15;
            this.cmdDrugUpload.Text = "药品数据上传";
            this.cmdDrugUpload.Click += new System.EventHandler(this.cmdDrugUpload_Click);
            // 
            // m_cmdCheckRecordUpload
            // 
            this.m_cmdCheckRecordUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_cmdCheckRecordUpload.DefaultScheme = true;
            this.m_cmdCheckRecordUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCheckRecordUpload.Hint = "";
            this.m_cmdCheckRecordUpload.Location = new System.Drawing.Point(53, 253);
            this.m_cmdCheckRecordUpload.Name = "m_cmdCheckRecordUpload";
            this.m_cmdCheckRecordUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCheckRecordUpload.Size = new System.Drawing.Size(169, 36);
            this.m_cmdCheckRecordUpload.TabIndex = 14;
            this.m_cmdCheckRecordUpload.Text = "检查数据上传";
            this.m_cmdCheckRecordUpload.Click += new System.EventHandler(this.m_cmdCheckRecordUpload_Click);
            // 
            // btnEmrUpload
            // 
            this.btnEmrUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEmrUpload.DefaultScheme = true;
            this.btnEmrUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEmrUpload.Hint = "";
            this.btnEmrUpload.Location = new System.Drawing.Point(53, 300);
            this.btnEmrUpload.Name = "btnEmrUpload";
            this.btnEmrUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEmrUpload.Size = new System.Drawing.Size(169, 36);
            this.btnEmrUpload.TabIndex = 12;
            this.btnEmrUpload.Text = "病案首页上报";
            this.btnEmrUpload.Click += new System.EventHandler(this.btnEmrUpload_Click);
            // 
            // btnLisUpload
            // 
            this.btnLisUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLisUpload.DefaultScheme = true;
            this.btnLisUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLisUpload.Hint = "";
            this.btnLisUpload.Location = new System.Drawing.Point(53, 206);
            this.btnLisUpload.Name = "btnLisUpload";
            this.btnLisUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnLisUpload.Size = new System.Drawing.Size(169, 36);
            this.btnLisUpload.TabIndex = 10;
            this.btnLisUpload.Text = "检验数据上传";
            this.btnLisUpload.Click += new System.EventHandler(this.btnLisUpload_Click);
            // 
            // btnOPInfoUpload
            // 
            this.btnOPInfoUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOPInfoUpload.DefaultScheme = true;
            this.btnOPInfoUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOPInfoUpload.Hint = "";
            this.btnOPInfoUpload.Location = new System.Drawing.Point(53, 65);
            this.btnOPInfoUpload.Name = "btnOPInfoUpload";
            this.btnOPInfoUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOPInfoUpload.Size = new System.Drawing.Size(169, 36);
            this.btnOPInfoUpload.TabIndex = 4;
            this.btnOPInfoUpload.Text = "门诊数据上传";
            this.btnOPInfoUpload.Click += new System.EventHandler(this.btnOPInfoUpload_Click);
            // 
            // lsvInfor
            // 
            this.lsvInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvInfor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvInfor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvInfor.HideSelection = false;
            this.lsvInfor.Location = new System.Drawing.Point(207, 273);
            this.lsvInfor.Name = "lsvInfor";
            this.lsvInfor.Size = new System.Drawing.Size(69, 36);
            this.lsvInfor.TabIndex = 11;
            this.lsvInfor.UseCompatibleStateImageBehavior = false;
            this.lsvInfor.View = System.Windows.Forms.View.Details;
            this.lsvInfor.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NO";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 450;
            // 
            // dtpTime
            // 
            this.dtpTime.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpTime.CustomFormat = "yyyy年MM月dd日";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(75, 16);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(121, 23);
            this.dtpTime.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "上传日期：";
            // 
            // cmdTran
            // 
            this.cmdTran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdTran.DefaultScheme = true;
            this.cmdTran.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTran.Hint = "";
            this.cmdTran.Location = new System.Drawing.Point(53, 159);
            this.cmdTran.Name = "cmdTran";
            this.cmdTran.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTran.Size = new System.Drawing.Size(169, 36);
            this.cmdTran.TabIndex = 7;
            this.cmdTran.Text = "住院数据上传";
            this.cmdTran.Click += new System.EventHandler(this.cmdTran_Click);
            // 
            // lblCurrentInfo
            // 
            this.lblCurrentInfo.Location = new System.Drawing.Point(9, 344);
            this.lblCurrentInfo.Name = "lblCurrentInfo";
            this.lblCurrentInfo.Size = new System.Drawing.Size(261, 15);
            this.lblCurrentInfo.TabIndex = 6;
            // 
            // pgbTask
            // 
            this.pgbTask.BackColor = System.Drawing.Color.MintCream;
            this.pgbTask.Location = new System.Drawing.Point(9, 364);
            this.pgbTask.Name = "pgbTask";
            this.pgbTask.Size = new System.Drawing.Size(262, 22);
            this.pgbTask.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmUploadMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 409);
            this.Controls.Add(this.grouper1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUploadMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊数据采集主界面";
            this.Load += new System.EventHandler(this.frmUploadMain_Load);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        private PinkieControls.ButtonXP btnDiagInfoUpload;
        private PinkieControls.ButtonXP btnOpfeeUpload;
        private PinkieControls.ButtonXP btnRecInfoUpload;
        private System.Windows.Forms.Button btnClose;
        private CodeVendor.Controls.Grouper grouper1;
        internal System.Windows.Forms.Label lblCurrentInfo;
        internal System.Windows.Forms.ProgressBar pgbTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvInfor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal PinkieControls.ButtonXP cmdTran;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.DateTimePicker dtpTime;
        private PinkieControls.ButtonXP btnOPInfoUpload;
        private PinkieControls.ButtonXP btnEmrUpload;
        private PinkieControls.ButtonXP btnLisUpload;
        private PinkieControls.ButtonXP m_cmdCheckRecordUpload;
        private PinkieControls.ButtonXP cmdDrugUpload;
    }
}