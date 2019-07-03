namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmSetting
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
            this.dateTimeAutoUpdata = new System.Windows.Forms.DateTimePicker();
            this.butStartExe = new System.Windows.Forms.Button();
            this.labset = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewUpdata = new System.Windows.Forms.DataGridView();
            this.timerToRun = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlsLastExcutTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNextTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.AutoUpdataTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAutoUpdata = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdata)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeAutoUpdata
            // 
            this.dateTimeAutoUpdata.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeAutoUpdata.Location = new System.Drawing.Point(62, 375);
            this.dateTimeAutoUpdata.Name = "dateTimeAutoUpdata";
            this.dateTimeAutoUpdata.Size = new System.Drawing.Size(86, 23);
            this.dateTimeAutoUpdata.TabIndex = 0;
            // 
            // butStartExe
            // 
            this.butStartExe.Location = new System.Drawing.Point(249, 373);
            this.butStartExe.Name = "butStartExe";
            this.butStartExe.Size = new System.Drawing.Size(85, 27);
            this.butStartExe.TabIndex = 1;
            this.butStartExe.Text = "自动上传";
            this.butStartExe.UseVisualStyleBackColor = true;
            this.butStartExe.Click += new System.EventHandler(this.butStartExe_Click);
            // 
            // labset
            // 
            this.labset.AutoSize = true;
            this.labset.Location = new System.Drawing.Point(25, 379);
            this.labset.Name = "labset";
            this.labset.Size = new System.Drawing.Size(35, 14);
            this.labset.TabIndex = 2;
            this.labset.Text = "将于";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "执行上传程序";
            // 
            // dataGridViewUpdata
            // 
            this.dataGridViewUpdata.AllowUserToAddRows = false;
            this.dataGridViewUpdata.AllowUserToDeleteRows = false;
            this.dataGridViewUpdata.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewUpdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUpdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutoUpdataTableName,
            this.isAutoUpdata});
            this.dataGridViewUpdata.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewUpdata.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUpdata.Name = "dataGridViewUpdata";
            this.dataGridViewUpdata.ReadOnly = true;
            this.dataGridViewUpdata.RowHeadersWidth = 25;
            this.dataGridViewUpdata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUpdata.RowTemplate.Height = 23;
            this.dataGridViewUpdata.Size = new System.Drawing.Size(582, 349);
            this.dataGridViewUpdata.TabIndex = 4;
            this.dataGridViewUpdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUpdata_CellClick);
            // 
            // timerToRun
            // 
            this.timerToRun.Interval = 1000;
            this.timerToRun.Tick += new System.EventHandler(this.timerToRun_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsLastExcutTime,
            this.tlsNextTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlsLastExcutTime
            // 
            this.tlsLastExcutTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tlsLastExcutTime.Name = "tlsLastExcutTime";
            this.tlsLastExcutTime.Size = new System.Drawing.Size(283, 17);
            this.tlsLastExcutTime.Spring = true;
            this.tlsLastExcutTime.Text = "上次执行时间:";
            this.tlsLastExcutTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsNextTime
            // 
            this.tlsNextTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tlsNextTime.Name = "tlsNextTime";
            this.tlsNextTime.Size = new System.Drawing.Size(283, 17);
            this.tlsNextTime.Spring = true;
            this.tlsNextTime.Text = "距离下一次执行还有:";
            this.tlsNextTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(350, 373);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 27);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "手工上传";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // AutoUpdataTableName
            // 
            this.AutoUpdataTableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AutoUpdataTableName.DataPropertyName = "UpdataTableName";
            this.AutoUpdataTableName.HeaderText = "接口功能名称";
            this.AutoUpdataTableName.Name = "AutoUpdataTableName";
            this.AutoUpdataTableName.ReadOnly = true;
            // 
            // isAutoUpdata
            // 
            this.isAutoUpdata.DataPropertyName = "isAutoUpdata";
            this.isAutoUpdata.FillWeight = 150F;
            this.isAutoUpdata.HeaderText = "是否自动上传";
            this.isAutoUpdata.Name = "isAutoUpdata";
            this.isAutoUpdata.ReadOnly = true;
            this.isAutoUpdata.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isAutoUpdata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isAutoUpdata.Width = 150;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 428);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewUpdata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labset);
            this.Controls.Add(this.butStartExe);
            this.Controls.Add(this.dateTimeAutoUpdata);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.Text = "嵌入式社保接口上传配置程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdata)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeAutoUpdata;
        private System.Windows.Forms.Button butStartExe;
        private System.Windows.Forms.Label labset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewUpdata;
        private System.Windows.Forms.Timer timerToRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlsLastExcutTime;
        private System.Windows.Forms.ToolStripStatusLabel tlsNextTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoUpdataTableName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAutoUpdata;
        private System.Windows.Forms.Button btnOpen;
    }
}

