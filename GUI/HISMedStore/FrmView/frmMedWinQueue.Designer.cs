namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmMedWinQueue
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_dtPickEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dtPickBegin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtBrush = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboWinStyle = new System.Windows.Forms.ComboBox();
            this.m_cboMedStore = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_datGridView = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_datGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_dtPickEnd);
            this.groupBox1.Controls.Add(this.m_dtPickBegin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_dtBrush);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cboWinStyle);
            this.groupBox1.Controls.Add(this.m_cboMedStore);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_dtPickEnd
            // 
            this.m_dtPickEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtPickEnd.Location = new System.Drawing.Point(586, 21);
            this.m_dtPickEnd.Name = "m_dtPickEnd";
            this.m_dtPickEnd.Size = new System.Drawing.Size(119, 23);
            this.m_dtPickEnd.TabIndex = 11;
            this.m_dtPickEnd.ValueChanged += new System.EventHandler(this.m_dtPickEnd_ValueChanged);
            this.m_dtPickEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtPickEnd_KeyDown);
            // 
            // m_dtPickBegin
            // 
            this.m_dtPickBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtPickBegin.Location = new System.Drawing.Point(440, 21);
            this.m_dtPickBegin.Name = "m_dtPickBegin";
            this.m_dtPickBegin.Size = new System.Drawing.Size(120, 23);
            this.m_dtPickBegin.TabIndex = 10;
            this.m_dtPickBegin.ValueChanged += new System.EventHandler(this.m_dtPickBegin_ValueChanged);
            this.m_dtPickBegin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtPickBegin_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(564, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "到";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(401, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "时间";
            // 
            // m_dtBrush
            // 
            this.m_dtBrush.CustomFormat = "mm";
            this.m_dtBrush.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtBrush.Location = new System.Drawing.Point(800, 19);
            this.m_dtBrush.Name = "m_dtBrush";
            this.m_dtBrush.ShowUpDown = true;
            this.m_dtBrush.Size = new System.Drawing.Size(64, 21);
            this.m_dtBrush.TabIndex = 12;
            this.m_dtBrush.Value = new System.DateTime(2006, 2, 13, 11, 30, 0, 0);
            this.m_dtBrush.ValueChanged += new System.EventHandler(this.m_dtBrush_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(865, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(737, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "刷新时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "药房";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(193, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "窗口类型";
            // 
            // m_cboWinStyle
            // 
            this.m_cboWinStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWinStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboWinStyle.FormattingEnabled = true;
            this.m_cboWinStyle.Items.AddRange(new object[] {
            "发药窗口",
            "配药窗口"});
            this.m_cboWinStyle.Location = new System.Drawing.Point(255, 20);
            this.m_cboWinStyle.Name = "m_cboWinStyle";
            this.m_cboWinStyle.Size = new System.Drawing.Size(121, 22);
            this.m_cboWinStyle.TabIndex = 1;
            this.m_cboWinStyle.SelectedIndexChanged += new System.EventHandler(this.m_cboWinStyle_SelectedIndexChanged);
            this.m_cboWinStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboWinStyle_KeyDown);
            // 
            // m_cboMedStore
            // 
            this.m_cboMedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedStore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMedStore.FormattingEnabled = true;
            this.m_cboMedStore.Location = new System.Drawing.Point(62, 20);
            this.m_cboMedStore.Name = "m_cboMedStore";
            this.m_cboMedStore.Size = new System.Drawing.Size(121, 22);
            this.m_cboMedStore.TabIndex = 0;
            this.m_cboMedStore.SelectedIndexChanged += new System.EventHandler(this.m_cboMedStore_SelectedIndexChanged);
            this.m_cboMedStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboMedStore_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.m_datGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(891, 395);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // m_datGridView
            // 
            this.m_datGridView.AllowDrop = true;
            this.m_datGridView.AllowUserToAddRows = false;
            this.m_datGridView.AllowUserToDeleteRows = false;
            this.m_datGridView.AllowUserToResizeColumns = false;
            this.m_datGridView.AllowUserToResizeRows = false;
            this.m_datGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_datGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_datGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.m_datGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_datGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_datGridView.Location = new System.Drawing.Point(3, 17);
            this.m_datGridView.MultiSelect = false;
            this.m_datGridView.Name = "m_datGridView";
            this.m_datGridView.ReadOnly = true;
            this.m_datGridView.RowHeadersVisible = false;
            this.m_datGridView.RowTemplate.Height = 23;
            this.m_datGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.m_datGridView.Size = new System.Drawing.Size(885, 375);
            this.m_datGridView.StandardTab = true;
            this.m_datGridView.TabIndex = 1;
            this.m_datGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_datGridView_MouseDown);
            this.m_datGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.m_datGridView_DragOver);
            this.m_datGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_datGridView_MouseMove);
            this.m_datGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_datGridView_DragEnter);
            this.m_datGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_datGridView_DragDrop);
            this.m_datGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_datGridView_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMedWinQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 498);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMedWinQueue";
            this.Text = "药房窗口队列";
            this.Load += new System.EventHandler(this.frmMedWinQueue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_datGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker m_dtBrush;
        internal System.Windows.Forms.ComboBox m_cboWinStyle;
        internal System.Windows.Forms.ComboBox m_cboMedStore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker m_dtPickBegin;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker m_dtPickEnd;
        internal System.Windows.Forms.DataGridView m_datGridView;
    }
}