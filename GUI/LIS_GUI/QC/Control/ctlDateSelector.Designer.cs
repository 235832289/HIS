namespace com.digitalwave.iCare.gui.LIS
{
    partial class ctlDateSelector
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_cmd = new System.Windows.Forms.Button();
            this.m_pnlFrm = new System.Windows.Forms.Panel();
            this.m_pnl2 = new System.Windows.Forms.Panel();
            this.m_dtp2 = new System.Windows.Forms.DateTimePicker();
            this.m_dtp3 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_pnl3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtp4 = new System.Windows.Forms.DateTimePicker();
            this.m_dtp5 = new System.Windows.Forms.DateTimePicker();
            this.m_cmdConfirm = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_radMonth = new System.Windows.Forms.RadioButton();
            this.m_radDateSect = new System.Windows.Forms.RadioButton();
            this.m_radMonthSect = new System.Windows.Forms.RadioButton();
            this.m_pnl1 = new System.Windows.Forms.Panel();
            this.m_dtp1 = new System.Windows.Forms.DateTimePicker();
            this.m_pnlFrm.SuspendLayout();
            this.m_pnl2.SuspendLayout();
            this.m_pnl3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmd
            // 
            this.m_cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_cmd.Location = new System.Drawing.Point(0, 0);
            this.m_cmd.Name = "m_cmd";
            this.m_cmd.Size = new System.Drawing.Size(137, 25);
            this.m_cmd.TabIndex = 1;
            this.m_cmd.UseVisualStyleBackColor = true;
            this.m_cmd.Click += new System.EventHandler(this.m_cmd_Click);
            // 
            // m_pnlFrm
            // 
            this.m_pnlFrm.Controls.Add(this.m_pnl2);
            this.m_pnlFrm.Controls.Add(this.m_cmdCancel);
            this.m_pnlFrm.Controls.Add(this.m_pnl3);
            this.m_pnlFrm.Controls.Add(this.m_cmdConfirm);
            this.m_pnlFrm.Controls.Add(this.groupBox1);
            this.m_pnlFrm.Controls.Add(this.m_pnl1);
            this.m_pnlFrm.Location = new System.Drawing.Point(76, 20);
            this.m_pnlFrm.Name = "m_pnlFrm";
            this.m_pnlFrm.Size = new System.Drawing.Size(224, 136);
            this.m_pnlFrm.TabIndex = 2;
            this.m_pnlFrm.Visible = false;
            // 
            // m_pnl2
            // 
            this.m_pnl2.Controls.Add(this.m_dtp2);
            this.m_pnl2.Controls.Add(this.m_dtp3);
            this.m_pnl2.Controls.Add(this.label2);
            this.m_pnl2.Location = new System.Drawing.Point(0, 40);
            this.m_pnl2.Name = "m_pnl2";
            this.m_pnl2.Size = new System.Drawing.Size(224, 52);
            this.m_pnl2.TabIndex = 8;
            // 
            // m_dtp2
            // 
            this.m_dtp2.CustomFormat = "yyyy-MM";
            this.m_dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp2.Location = new System.Drawing.Point(24, 16);
            this.m_dtp2.Name = "m_dtp2";
            this.m_dtp2.Size = new System.Drawing.Size(80, 23);
            this.m_dtp2.TabIndex = 5;
            // 
            // m_dtp3
            // 
            this.m_dtp3.CustomFormat = "yyyy-MM";
            this.m_dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp3.Location = new System.Drawing.Point(120, 16);
            this.m_dtp3.Name = "m_dtp3";
            this.m_dtp3.Size = new System.Drawing.Size(80, 23);
            this.m_dtp3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "-";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(116, 96);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(100, 28);
            this.m_cmdCancel.TabIndex = 13;
            this.m_cmdCancel.Text = "取消(ESC)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_pnl3
            // 
            this.m_pnl3.Controls.Add(this.label1);
            this.m_pnl3.Controls.Add(this.m_dtp4);
            this.m_pnl3.Controls.Add(this.m_dtp5);
            this.m_pnl3.Location = new System.Drawing.Point(0, 40);
            this.m_pnl3.Name = "m_pnl3";
            this.m_pnl3.Size = new System.Drawing.Size(224, 52);
            this.m_pnl3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "-";
            // 
            // m_dtp4
            // 
            this.m_dtp4.CustomFormat = "yyyy-MM-dd";
            this.m_dtp4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp4.Location = new System.Drawing.Point(8, 16);
            this.m_dtp4.Name = "m_dtp4";
            this.m_dtp4.Size = new System.Drawing.Size(96, 23);
            this.m_dtp4.TabIndex = 7;
            // 
            // m_dtp5
            // 
            this.m_dtp5.CustomFormat = "yyyy-MM-dd";
            this.m_dtp5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp5.Location = new System.Drawing.Point(120, 16);
            this.m_dtp5.Name = "m_dtp5";
            this.m_dtp5.Size = new System.Drawing.Size(96, 23);
            this.m_dtp5.TabIndex = 8;
            // 
            // m_cmdConfirm
            // 
            this.m_cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdConfirm.DefaultScheme = true;
            this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdConfirm.Hint = "";
            this.m_cmdConfirm.Location = new System.Drawing.Point(8, 96);
            this.m_cmdConfirm.Name = "m_cmdConfirm";
            this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdConfirm.Size = new System.Drawing.Size(104, 28);
            this.m_cmdConfirm.TabIndex = 12;
            this.m_cmdConfirm.Text = "确定(Enter)";
            this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_radMonth);
            this.groupBox1.Controls.Add(this.m_radDateSect);
            this.groupBox1.Controls.Add(this.m_radMonthSect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // m_radMonth
            // 
            this.m_radMonth.AutoSize = true;
            this.m_radMonth.Checked = true;
            this.m_radMonth.Location = new System.Drawing.Point(8, 16);
            this.m_radMonth.Name = "m_radMonth";
            this.m_radMonth.Size = new System.Drawing.Size(53, 18);
            this.m_radMonth.TabIndex = 0;
            this.m_radMonth.TabStop = true;
            this.m_radMonth.Text = "月份";
            this.m_radMonth.UseVisualStyleBackColor = true;
            this.m_radMonth.CheckedChanged += new System.EventHandler(this.m_radMonth_CheckedChanged);
            // 
            // m_radDateSect
            // 
            this.m_radDateSect.AutoSize = true;
            this.m_radDateSect.Location = new System.Drawing.Point(132, 16);
            this.m_radDateSect.Name = "m_radDateSect";
            this.m_radDateSect.Size = new System.Drawing.Size(67, 18);
            this.m_radDateSect.TabIndex = 2;
            this.m_radDateSect.Text = "时间段";
            this.m_radDateSect.UseVisualStyleBackColor = true;
            this.m_radDateSect.CheckedChanged += new System.EventHandler(this.m_radDateSect_CheckedChanged);
            // 
            // m_radMonthSect
            // 
            this.m_radMonthSect.AutoSize = true;
            this.m_radMonthSect.Location = new System.Drawing.Point(64, 16);
            this.m_radMonthSect.Name = "m_radMonthSect";
            this.m_radMonthSect.Size = new System.Drawing.Size(67, 18);
            this.m_radMonthSect.TabIndex = 1;
            this.m_radMonthSect.Text = "月份段";
            this.m_radMonthSect.UseVisualStyleBackColor = true;
            this.m_radMonthSect.CheckedChanged += new System.EventHandler(this.m_radMonthSect_CheckedChanged);
            // 
            // m_pnl1
            // 
            this.m_pnl1.Controls.Add(this.m_dtp1);
            this.m_pnl1.Location = new System.Drawing.Point(0, 40);
            this.m_pnl1.Name = "m_pnl1";
            this.m_pnl1.Size = new System.Drawing.Size(224, 52);
            this.m_pnl1.TabIndex = 8;
            // 
            // m_dtp1
            // 
            this.m_dtp1.CustomFormat = "yyyy-MM";
            this.m_dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp1.Location = new System.Drawing.Point(76, 16);
            this.m_dtp1.Name = "m_dtp1";
            this.m_dtp1.Size = new System.Drawing.Size(80, 23);
            this.m_dtp1.TabIndex = 4;
            // 
            // ctlDateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_pnlFrm);
            this.Controls.Add(this.m_cmd);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ctlDateSelector";
            this.Size = new System.Drawing.Size(137, 25);
            this.m_pnlFrm.ResumeLayout(false);
            this.m_pnl2.ResumeLayout(false);
            this.m_pnl2.PerformLayout();
            this.m_pnl3.ResumeLayout(false);
            this.m_pnl3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pnl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_cmd;
        private System.Windows.Forms.Panel m_pnlFrm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_radMonth;
        private System.Windows.Forms.RadioButton m_radDateSect;
        private System.Windows.Forms.RadioButton m_radMonthSect;
        private System.Windows.Forms.DateTimePicker m_dtp5;
        private System.Windows.Forms.DateTimePicker m_dtp4;
        private System.Windows.Forms.DateTimePicker m_dtp1;
        private System.Windows.Forms.DateTimePicker m_dtp2;
        private System.Windows.Forms.DateTimePicker m_dtp3;
        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_pnl3;
        private System.Windows.Forms.Panel m_pnl1;
        private System.Windows.Forms.Panel m_pnl2;
        private System.Windows.Forms.Label label2;
    }
}
