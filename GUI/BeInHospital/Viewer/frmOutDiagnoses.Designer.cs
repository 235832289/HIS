namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOutDiagnoses
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_checkBoxArea = new System.Windows.Forms.CheckBox();
            this.m_dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.m_buttonExit = new PinkieControls.ButtonXP();
            this.m_buttonPrint = new PinkieControls.ButtonXP();
            this.m_buttonFind = new PinkieControls.ButtonXP();
            this.m_ckbType = new System.Windows.Forms.CheckBox();
            this.m_txtDiagnose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.m_labelTo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dwOutDiagnoses = new Sybase.DataWindow.DataWindowControl();
            this.m_btnExport = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnExport);
            this.panel1.Controls.Add(this.m_checkBoxArea);
            this.panel1.Controls.Add(this.m_dateTimePickerFrom);
            this.panel1.Controls.Add(this.m_buttonExit);
            this.panel1.Controls.Add(this.m_buttonPrint);
            this.panel1.Controls.Add(this.m_buttonFind);
            this.panel1.Controls.Add(this.m_ckbType);
            this.panel1.Controls.Add(this.m_txtDiagnose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dateTimePickerTo);
            this.panel1.Controls.Add(this.m_labelTo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 60);
            this.panel1.TabIndex = 0;
            // 
            // m_checkBoxArea
            // 
            this.m_checkBoxArea.AutoSize = true;
            this.m_checkBoxArea.Location = new System.Drawing.Point(12, 19);
            this.m_checkBoxArea.Name = "m_checkBoxArea";
            this.m_checkBoxArea.Size = new System.Drawing.Size(54, 18);
            this.m_checkBoxArea.TabIndex = 0;
            this.m_checkBoxArea.Text = "病区";
            this.m_checkBoxArea.UseVisualStyleBackColor = true;
            this.m_checkBoxArea.CheckedChanged += new System.EventHandler(this.m_checkBoxArea_CheckedChanged);
            // 
            // m_dateTimePickerFrom
            // 
            this.m_dateTimePickerFrom.Location = new System.Drawing.Point(133, 17);
            this.m_dateTimePickerFrom.Name = "m_dateTimePickerFrom";
            this.m_dateTimePickerFrom.Size = new System.Drawing.Size(119, 23);
            this.m_dateTimePickerFrom.TabIndex = 1;
            // 
            // m_buttonExit
            // 
            this.m_buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonExit.DefaultScheme = true;
            this.m_buttonExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonExit.Hint = "";
            this.m_buttonExit.Location = new System.Drawing.Point(928, 14);
            this.m_buttonExit.Name = "m_buttonExit";
            this.m_buttonExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonExit.Size = new System.Drawing.Size(75, 28);
            this.m_buttonExit.TabIndex = 7;
            this.m_buttonExit.Text = "退出(&E)";
            this.m_buttonExit.Click += new System.EventHandler(this.m_buttonExit_Click);
            // 
            // m_buttonPrint
            // 
            this.m_buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonPrint.DefaultScheme = true;
            this.m_buttonPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonPrint.Hint = "";
            this.m_buttonPrint.Location = new System.Drawing.Point(770, 14);
            this.m_buttonPrint.Name = "m_buttonPrint";
            this.m_buttonPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonPrint.Size = new System.Drawing.Size(75, 28);
            this.m_buttonPrint.TabIndex = 6;
            this.m_buttonPrint.Text = "打印(&P)";
            this.m_buttonPrint.Click += new System.EventHandler(this.m_buttonPrint_Click);
            // 
            // m_buttonFind
            // 
            this.m_buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonFind.DefaultScheme = true;
            this.m_buttonFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonFind.Hint = "";
            this.m_buttonFind.Location = new System.Drawing.Point(691, 14);
            this.m_buttonFind.Name = "m_buttonFind";
            this.m_buttonFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonFind.Size = new System.Drawing.Size(75, 28);
            this.m_buttonFind.TabIndex = 5;
            this.m_buttonFind.Text = "查询(&F)";
            this.m_buttonFind.Click += new System.EventHandler(this.m_buttonFind_Click);
            // 
            // m_ckbType
            // 
            this.m_ckbType.AutoSize = true;
            this.m_ckbType.Location = new System.Drawing.Point(613, 19);
            this.m_ckbType.Name = "m_ckbType";
            this.m_ckbType.Size = new System.Drawing.Size(82, 18);
            this.m_ckbType.TabIndex = 4;
            this.m_ckbType.Text = "特殊病种";
            this.m_ckbType.UseVisualStyleBackColor = true;
            this.m_ckbType.CheckedChanged += new System.EventHandler(this.m_ckbType_CheckedChanged);
            // 
            // m_txtDiagnose
            // 
            this.m_txtDiagnose.Location = new System.Drawing.Point(461, 17);
            this.m_txtDiagnose.Name = "m_txtDiagnose";
            this.m_txtDiagnose.Size = new System.Drawing.Size(149, 23);
            this.m_txtDiagnose.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 55;
            this.label2.Text = "疾病名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 54;
            this.label1.Text = "出院日期";
            // 
            // m_dateTimePickerTo
            // 
            this.m_dateTimePickerTo.Location = new System.Drawing.Point(270, 17);
            this.m_dateTimePickerTo.Name = "m_dateTimePickerTo";
            this.m_dateTimePickerTo.Size = new System.Drawing.Size(121, 23);
            this.m_dateTimePickerTo.TabIndex = 2;
            // 
            // m_labelTo
            // 
            this.m_labelTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_labelTo.Location = new System.Drawing.Point(251, 20);
            this.m_labelTo.Name = "m_labelTo";
            this.m_labelTo.Size = new System.Drawing.Size(22, 20);
            this.m_labelTo.TabIndex = 53;
            this.m_labelTo.Text = "至";
            this.m_labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dwOutDiagnoses);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 601);
            this.panel2.TabIndex = 1;
            // 
            // m_dwOutDiagnoses
            // 
            this.m_dwOutDiagnoses.DataWindowObject = "";
            this.m_dwOutDiagnoses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwOutDiagnoses.LibraryList = "";
            this.m_dwOutDiagnoses.Location = new System.Drawing.Point(0, 0);
            this.m_dwOutDiagnoses.Name = "m_dwOutDiagnoses";
            this.m_dwOutDiagnoses.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwOutDiagnoses.Size = new System.Drawing.Size(1012, 601);
            this.m_dwOutDiagnoses.TabIndex = 0;
            this.m_dwOutDiagnoses.Text = "dataWindowControl1";
            // 
            // m_btnExport
            // 
            this.m_btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExport.DefaultScheme = true;
            this.m_btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExport.Hint = "";
            this.m_btnExport.Location = new System.Drawing.Point(849, 14);
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExport.Size = new System.Drawing.Size(75, 28);
            this.m_btnExport.TabIndex = 56;
            this.m_btnExport.Text = "导出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // frmOutDiagnoses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmOutDiagnoses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutDiagnoses";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOutDiagnoses_KeyDown);
            this.Load += new System.EventHandler(this.frmOutDiagnoses_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DateTimePicker m_dateTimePickerTo;
        internal System.Windows.Forms.DateTimePicker m_dateTimePickerFrom;
        private System.Windows.Forms.Label m_labelTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP m_buttonExit;
        internal PinkieControls.ButtonXP m_buttonPrint;
        internal PinkieControls.ButtonXP m_buttonFind;
        internal System.Windows.Forms.CheckBox m_checkBoxArea;
        internal System.Windows.Forms.TextBox m_txtDiagnose;
        internal Sybase.DataWindow.DataWindowControl m_dwOutDiagnoses;
        internal System.Windows.Forms.CheckBox m_ckbType;
        internal PinkieControls.ButtonXP m_btnExport;
    }
}