namespace com.digitalwave.iCare.gui.HIS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnZyjzcfsjsc = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pgbTask = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvUpload = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJZJLH = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpTimeEnd);
            this.panel1.Controls.Add(this.dtpTimeBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 37);
            this.panel1.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(207, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "到";
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.CalendarFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.dtpTimeEnd.CustomFormat = "yyyy年MM月dd日";
            this.dtpTimeEnd.Font = new System.Drawing.Font("宋体", 12F);
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEnd.Location = new System.Drawing.Point(231, 6);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(134, 26);
            this.dtpTimeEnd.TabIndex = 41;
            // 
            // dtpTimeBegin
            // 
            this.dtpTimeBegin.CalendarFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.dtpTimeBegin.CustomFormat = "yyyy年MM月dd日";
            this.dtpTimeBegin.Font = new System.Drawing.Font("宋体", 12F);
            this.dtpTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeBegin.Location = new System.Drawing.Point(73, 6);
            this.dtpTimeBegin.Name = "dtpTimeBegin";
            this.dtpTimeBegin.Size = new System.Drawing.Size(134, 26);
            this.dtpTimeBegin.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "上传日期：";
            // 
            // m_btnZyjzcfsjsc
            // 
            this.m_btnZyjzcfsjsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_btnZyjzcfsjsc.Font = new System.Drawing.Font("宋体", 10F);
            this.m_btnZyjzcfsjsc.Location = new System.Drawing.Point(36, 116);
            this.m_btnZyjzcfsjsc.Name = "m_btnZyjzcfsjsc";
            this.m_btnZyjzcfsjsc.Size = new System.Drawing.Size(174, 33);
            this.m_btnZyjzcfsjsc.TabIndex = 41;
            this.m_btnZyjzcfsjsc.Text = "住院记账处方数据上传";
            this.m_btnZyjzcfsjsc.UseVisualStyleBackColor = false;
            this.m_btnZyjzcfsjsc.Click += new System.EventHandler(this.m_btnZyjzcfsjsc_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(448, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(174, 33);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pgbTask
            // 
            this.pgbTask.BackColor = System.Drawing.Color.MintCream;
            this.pgbTask.Location = new System.Drawing.Point(59, 63);
            this.pgbTask.Name = "pgbTask";
            this.pgbTask.Size = new System.Drawing.Size(262, 21);
            this.pgbTask.TabIndex = 43;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCurrentInfo
            // 
            this.lblCurrentInfo.Location = new System.Drawing.Point(59, 93);
            this.lblCurrentInfo.Name = "lblCurrentInfo";
            this.lblCurrentInfo.Size = new System.Drawing.Size(261, 15);
            this.lblCurrentInfo.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtJZJLH);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblCurrentInfo);
            this.panel2.Controls.Add(this.m_btnZyjzcfsjsc);
            this.panel2.Controls.Add(this.pgbTask);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 160);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvUpload);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 304);
            this.panel3.TabIndex = 46;
            // 
            // dgvUpload
            // 
            this.dgvUpload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUpload.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpload.Location = new System.Drawing.Point(0, 0);
            this.dgvUpload.Name = "dgvUpload";
            this.dgvUpload.ReadOnly = true;
            this.dgvUpload.RowTemplate.Height = 23;
            this.dgvUpload.Size = new System.Drawing.Size(645, 304);
            this.dgvUpload.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "日期";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "state";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "上传状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(388, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "就诊记录号：";
            // 
            // txtJZJLH
            // 
            this.txtJZJLH.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtJZJLH.Location = new System.Drawing.Point(484, 24);
            this.txtJZJLH.Name = "txtJZJLH";
            this.txtJZJLH.Size = new System.Drawing.Size(136, 26);
            this.txtJZJLH.TabIndex = 46;
            // 
            // frmUploadMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 464);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmUploadMain";
            this.Text = "住院记账处方数据上传";
            this.Load += new System.EventHandler(this.frmUploadMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtpTimeEnd;
        internal System.Windows.Forms.DateTimePicker dtpTimeBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnZyjzcfsjsc;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.ProgressBar pgbTask;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label lblCurrentInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txtJZJLH;
        private System.Windows.Forms.Label label1;
    }
}