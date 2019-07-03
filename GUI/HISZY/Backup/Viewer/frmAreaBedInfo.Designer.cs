namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAreaBedInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAreaBedInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvArea = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.dgBed = new System.Windows.Forms.DataGridView();
            this.Rowno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zycs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rysj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 623);
            this.panel1.TabIndex = 0;
            // 
            // tvArea
            // 
            this.tvArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvArea.ImageIndex = 1;
            this.tvArea.ImageList = this.imageList1;
            this.tvArea.ItemHeight = 22;
            this.tvArea.Location = new System.Drawing.Point(0, 0);
            this.tvArea.Name = "tvArea";
            this.tvArea.SelectedImageIndex = 3;
            this.tvArea.Size = new System.Drawing.Size(260, 623);
            this.tvArea.StateImageList = this.imageList1;
            this.tvArea.TabIndex = 0;
            this.tvArea.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArea_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "10.gif");
            this.imageList1.Images.SetKeyName(1, "in_4_2.gif");
            this.imageList1.Images.SetKeyName(2, "31.gif");
            this.imageList1.Images.SetKeyName(3, "a1.bmp");
            this.imageList1.Images.SetKeyName(4, "30.gif");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.dgBed);
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(260, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 623);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(492, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(372, 590);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(78, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dgBed
            // 
            this.dgBed.AllowUserToAddRows = false;
            this.dgBed.AllowUserToDeleteRows = false;
            this.dgBed.AllowUserToResizeRows = false;
            this.dgBed.BackgroundColor = System.Drawing.Color.White;
            this.dgBed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgBed.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgBed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBed.ColumnHeadersHeight = 25;
            this.dgBed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rowno,
            this.BedID,
            this.bedcode,
            this.zyh,
            this.zycs,
            this.name,
            this.sex,
            this.age,
            this.rysj,
            this.registerid,
            this.patientid});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBed.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgBed.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgBed.Location = new System.Drawing.Point(0, 0);
            this.dgBed.MultiSelect = false;
            this.dgBed.Name = "dgBed";
            this.dgBed.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBed.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgBed.RowHeadersVisible = false;
            this.dgBed.RowTemplate.Height = 23;
            this.dgBed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBed.Size = new System.Drawing.Size(612, 586);
            this.dgBed.TabIndex = 1;
            this.dgBed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBed_CellClick);
            this.dgBed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBed_CellDoubleClick);
            // 
            // Rowno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rowno.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rowno.HeaderText = "序号";
            this.Rowno.Name = "Rowno";
            this.Rowno.ReadOnly = true;
            this.Rowno.Width = 45;
            // 
            // BedID
            // 
            this.BedID.HeaderText = "床位ID";
            this.BedID.Name = "BedID";
            this.BedID.ReadOnly = true;
            this.BedID.Visible = false;
            // 
            // bedcode
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bedcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.bedcode.HeaderText = "床位号";
            this.bedcode.Name = "bedcode";
            this.bedcode.ReadOnly = true;
            this.bedcode.Width = 70;
            // 
            // zyh
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zyh.DefaultCellStyle = dataGridViewCellStyle4;
            this.zyh.HeaderText = "住院号";
            this.zyh.Name = "zyh";
            this.zyh.ReadOnly = true;
            this.zyh.Width = 80;
            // 
            // zycs
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zycs.DefaultCellStyle = dataGridViewCellStyle5;
            this.zycs.HeaderText = "住院次数";
            this.zycs.Name = "zycs";
            this.zycs.ReadOnly = true;
            this.zycs.Width = 70;
            // 
            // name
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.name.DefaultCellStyle = dataGridViewCellStyle6;
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            // 
            // sex
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.sex.DefaultCellStyle = dataGridViewCellStyle7;
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 45;
            // 
            // age
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.age.DefaultCellStyle = dataGridViewCellStyle8;
            this.age.HeaderText = "年龄";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            this.age.Width = 50;
            // 
            // rysj
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.rysj.DefaultCellStyle = dataGridViewCellStyle9;
            this.rysj.HeaderText = "入院时间";
            this.rysj.Name = "rysj";
            this.rysj.ReadOnly = true;
            this.rysj.Width = 150;
            // 
            // registerid
            // 
            this.registerid.HeaderText = "入院登记流水号";
            this.registerid.Name = "registerid";
            this.registerid.ReadOnly = true;
            this.registerid.Visible = false;
            // 
            // patientid
            // 
            this.patientid.HeaderText = "病人ID";
            this.patientid.Name = "patientid";
            this.patientid.ReadOnly = true;
            this.patientid.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.Font = new System.Drawing.Font("楷体_GB2312", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(192, 236);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(252, 60);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "无记录";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Visible = false;
            // 
            // frmAreaBedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 623);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAreaBedInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病区床位使用一览表";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAreaBedInfo_KeyDown);
            this.Load += new System.EventHandler(this.frmAreaBedInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgBed;
        internal System.Windows.Forms.TreeView tvArea;
        private System.Windows.Forms.ImageList imageList1;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rowno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn zyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zycs;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn rysj;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientid;
        internal System.Windows.Forms.Label lblInfo;
    }
}