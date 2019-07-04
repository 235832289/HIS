namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class frmCommunityTran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommunityTran));
            this.cmdExit = new PinkieControls.ButtonXP();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdTran = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvInfor = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lblInfor = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(510, 12);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(93, 35);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "关闭(&E)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // dtpTime
            // 
            this.dtpTime.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpTime.CustomFormat = "yyyy年MM月dd日";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(67, 18);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(129, 23);
            this.dtpTime.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpTime);
            this.panel1.Controls.Add(this.cmdTran);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 64);
            this.panel1.TabIndex = 7;
            // 
            // cmdTran
            // 
            this.cmdTran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdTran.DefaultScheme = true;
            this.cmdTran.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTran.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdTran.Hint = "";
            this.cmdTran.Location = new System.Drawing.Point(215, 12);
            this.cmdTran.Name = "cmdTran";
            this.cmdTran.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTran.Size = new System.Drawing.Size(120, 35);
            this.cmdTran.TabIndex = 9;
            this.cmdTran.Text = "上传数据>>";
            this.cmdTran.Click += new System.EventHandler(this.cmdTran_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "上传日期：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lsvInfor);
            this.panel2.Controls.Add(this.lblInfor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 365);
            this.panel2.TabIndex = 8;
            // 
            // lsvInfor
            // 
            this.lsvInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvInfor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvInfor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvInfor.HideSelection = false;
            this.lsvInfor.Location = new System.Drawing.Point(0, 24);
            this.lsvInfor.Name = "lsvInfor";
            this.lsvInfor.Size = new System.Drawing.Size(636, 337);
            this.lsvInfor.TabIndex = 1;
            this.lsvInfor.UseCompatibleStateImageBehavior = false;
            this.lsvInfor.View = System.Windows.Forms.View.Details;
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
            // lblInfor
            // 
            this.lblInfor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInfor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfor.Location = new System.Drawing.Point(0, 0);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(636, 24);
            this.lblInfor.TabIndex = 0;
            this.lblInfor.Text = "Pro";
            this.lblInfor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCommunityTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCommunityTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "东莞市卫生信息公共接口(住院)";
            this.Load += new System.EventHandler(this.frmCommunityTran_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PinkieControls.ButtonXP cmdExit;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP cmdTran;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.ListView lsvInfor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer timer1;
    }
}

