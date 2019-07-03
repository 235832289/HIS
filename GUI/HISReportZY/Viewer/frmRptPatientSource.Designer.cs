namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmRptPatientSource
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
            this.m_chbInHospital = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chbOutHospital = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tim_IHStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tim_IHEnd = new System.Windows.Forms.DateTimePicker();
            this.tim_OHStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tim_OHEnd = new System.Windows.Forms.DateTimePicker();
            this.cmd_select = new PinkieControls.ButtonXP();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmd_close = new PinkieControls.ButtonXP();
            this.cmd_Print = new PinkieControls.ButtonXP();
            this.cmd_Export = new PinkieControls.ButtonXP();
            this.cmd_Preview = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chbInHospital
            // 
            this.m_chbInHospital.AutoSize = true;
            this.m_chbInHospital.Checked = true;
            this.m_chbInHospital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbInHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chbInHospital.Location = new System.Drawing.Point(22, 13);
            this.m_chbInHospital.Name = "m_chbInHospital";
            this.m_chbInHospital.Size = new System.Drawing.Size(82, 18);
            this.m_chbInHospital.TabIndex = 0;
            this.m_chbInHospital.Text = "入院时间";
            this.m_chbInHospital.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "从";
            // 
            // m_chbOutHospital
            // 
            this.m_chbOutHospital.AutoSize = true;
            this.m_chbOutHospital.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chbOutHospital.Location = new System.Drawing.Point(22, 44);
            this.m_chbOutHospital.Name = "m_chbOutHospital";
            this.m_chbOutHospital.Size = new System.Drawing.Size(82, 18);
            this.m_chbOutHospital.TabIndex = 2;
            this.m_chbOutHospital.Text = "出院时间";
            this.m_chbOutHospital.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(106, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "从";
            // 
            // tim_IHStart
            // 
            this.tim_IHStart.CustomFormat = "yyyy年MM月dd日";
            this.tim_IHStart.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tim_IHStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tim_IHStart.Location = new System.Drawing.Point(135, 10);
            this.tim_IHStart.Name = "tim_IHStart";
            this.tim_IHStart.Size = new System.Drawing.Size(132, 25);
            this.tim_IHStart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(273, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "到";
            // 
            // tim_IHEnd
            // 
            this.tim_IHEnd.CustomFormat = "yyyy年MM月dd日";
            this.tim_IHEnd.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tim_IHEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tim_IHEnd.Location = new System.Drawing.Point(295, 10);
            this.tim_IHEnd.Name = "tim_IHEnd";
            this.tim_IHEnd.Size = new System.Drawing.Size(132, 25);
            this.tim_IHEnd.TabIndex = 6;
            // 
            // tim_OHStart
            // 
            this.tim_OHStart.CustomFormat = "yyyy年MM月dd日";
            this.tim_OHStart.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tim_OHStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tim_OHStart.Location = new System.Drawing.Point(135, 41);
            this.tim_OHStart.Name = "tim_OHStart";
            this.tim_OHStart.Size = new System.Drawing.Size(132, 25);
            this.tim_OHStart.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(273, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "到";
            // 
            // tim_OHEnd
            // 
            this.tim_OHEnd.CustomFormat = "yyyy年MM月dd日";
            this.tim_OHEnd.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tim_OHEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tim_OHEnd.Location = new System.Drawing.Point(295, 41);
            this.tim_OHEnd.Name = "tim_OHEnd";
            this.tim_OHEnd.Size = new System.Drawing.Size(132, 25);
            this.tim_OHEnd.TabIndex = 9;
            // 
            // cmd_select
            // 
            this.cmd_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmd_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_select.DefaultScheme = true;
            this.cmd_select.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_select.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmd_select.Hint = "";
            this.cmd_select.Location = new System.Drawing.Point(447, 20);
            this.cmd_select.Name = "cmd_select";
            this.cmd_select.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_select.Size = new System.Drawing.Size(76, 32);
            this.cmd_select.TabIndex = 10;
            this.cmd_select.Text = "检索(&S)";
            this.cmd_select.Click += new System.EventHandler(this.cmd_select_Click);
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(942, 446);
            this.dwRep.TabIndex = 11;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmd_close);
            this.panel1.Controls.Add(this.cmd_Print);
            this.panel1.Controls.Add(this.cmd_Export);
            this.panel1.Controls.Add(this.cmd_Preview);
            this.panel1.Controls.Add(this.tim_IHEnd);
            this.panel1.Controls.Add(this.m_chbInHospital);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_chbOutHospital);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tim_IHStart);
            this.panel1.Controls.Add(this.cmd_select);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tim_OHEnd);
            this.panel1.Controls.Add(this.tim_OHStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 72);
            this.panel1.TabIndex = 12;
            // 
            // cmd_close
            // 
            this.cmd_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmd_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_close.DefaultScheme = true;
            this.cmd_close.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_close.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmd_close.Hint = "";
            this.cmd_close.Location = new System.Drawing.Point(843, 20);
            this.cmd_close.Name = "cmd_close";
            this.cmd_close.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_close.Size = new System.Drawing.Size(76, 32);
            this.cmd_close.TabIndex = 11;
            this.cmd_close.Text = "关闭(&C)";
            this.cmd_close.Click += new System.EventHandler(this.cmd_close_Click);
            // 
            // cmd_Print
            // 
            this.cmd_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmd_Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_Print.DefaultScheme = true;
            this.cmd_Print.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_Print.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmd_Print.Hint = "";
            this.cmd_Print.Location = new System.Drawing.Point(744, 20);
            this.cmd_Print.Name = "cmd_Print";
            this.cmd_Print.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_Print.Size = new System.Drawing.Size(76, 32);
            this.cmd_Print.TabIndex = 11;
            this.cmd_Print.Text = "打印(&P)";
            this.cmd_Print.Click += new System.EventHandler(this.cmd_Print_Click);
            // 
            // cmd_Export
            // 
            this.cmd_Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmd_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_Export.DefaultScheme = true;
            this.cmd_Export.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_Export.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmd_Export.Hint = "";
            this.cmd_Export.Location = new System.Drawing.Point(645, 20);
            this.cmd_Export.Name = "cmd_Export";
            this.cmd_Export.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_Export.Size = new System.Drawing.Size(76, 32);
            this.cmd_Export.TabIndex = 11;
            this.cmd_Export.Text = "导出(&E)";
            this.cmd_Export.Click += new System.EventHandler(this.cmd_Export_Click);
            // 
            // cmd_Preview
            // 
            this.cmd_Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmd_Preview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_Preview.DefaultScheme = true;
            this.cmd_Preview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_Preview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmd_Preview.Hint = "";
            this.cmd_Preview.Location = new System.Drawing.Point(546, 20);
            this.cmd_Preview.Name = "cmd_Preview";
            this.cmd_Preview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_Preview.Size = new System.Drawing.Size(76, 32);
            this.cmd_Preview.TabIndex = 11;
            this.cmd_Preview.Text = "预览(&V)";
            this.cmd_Preview.Click += new System.EventHandler(this.cmd_Preview_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dwRep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 450);
            this.panel2.TabIndex = 13;
            // 
            // frmRptPatientSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmRptPatientSource";
            this.Text = "病人来源统计";
            this.Load += new System.EventHandler(this.frmRptPatientSource_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox m_chbInHospital;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_chbOutHospital;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tim_IHStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tim_IHEnd;
        private System.Windows.Forms.DateTimePicker tim_OHStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tim_OHEnd;
        internal PinkieControls.ButtonXP cmd_select;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PinkieControls.ButtonXP cmd_Preview;
        private PinkieControls.ButtonXP cmd_close;
        private PinkieControls.ButtonXP cmd_Print;
        private PinkieControls.ButtonXP cmd_Export;
    }
}