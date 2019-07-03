namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmSamplePacktstat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkChecked = new System.Windows.Forms.CheckBox();
            this.chkUnchecked = new System.Windows.Forms.CheckBox();
            this.chkRefuseCheck = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPeno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSampleType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDeptSelect = new System.Windows.Forms.CheckBox();
            this.btnDeptSelect = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.dteRq2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dteRq1 = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.cboTimeType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTimeType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkChecked);
            this.panel1.Controls.Add(this.chkUnchecked);
            this.panel1.Controls.Add(this.chkRefuseCheck);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPeno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPatName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboSampleType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkDeptSelect);
            this.panel1.Controls.Add(this.btnDeptSelect);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.dteRq2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dteRq1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 68);
            this.panel1.TabIndex = 0;
            // 
            // chkChecked
            // 
            this.chkChecked.AutoSize = true;
            this.chkChecked.Location = new System.Drawing.Point(789, 45);
            this.chkChecked.Name = "chkChecked";
            this.chkChecked.Size = new System.Drawing.Size(60, 16);
            this.chkChecked.TabIndex = 33;
            this.chkChecked.Text = "已核收";
            this.chkChecked.UseVisualStyleBackColor = true;
            this.chkChecked.CheckedChanged += new System.EventHandler(this.chkChecked_CheckedChanged);
            // 
            // chkUnchecked
            // 
            this.chkUnchecked.AutoSize = true;
            this.chkUnchecked.Location = new System.Drawing.Point(849, 45);
            this.chkUnchecked.Name = "chkUnchecked";
            this.chkUnchecked.Size = new System.Drawing.Size(60, 16);
            this.chkUnchecked.TabIndex = 34;
            this.chkUnchecked.Text = "未核收";
            this.chkUnchecked.UseVisualStyleBackColor = true;
            this.chkUnchecked.CheckedChanged += new System.EventHandler(this.chkUnchecked_CheckedChanged);
            // 
            // chkRefuseCheck
            // 
            this.chkRefuseCheck.AutoSize = true;
            this.chkRefuseCheck.Location = new System.Drawing.Point(909, 45);
            this.chkRefuseCheck.Name = "chkRefuseCheck";
            this.chkRefuseCheck.Size = new System.Drawing.Size(48, 16);
            this.chkRefuseCheck.TabIndex = 35;
            this.chkRefuseCheck.Text = "拒收";
            this.chkRefuseCheck.UseVisualStyleBackColor = true;
            this.chkRefuseCheck.CheckedChanged += new System.EventHandler(this.chkRefuseCheck_CheckedChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBarcode.Location = new System.Drawing.Point(433, 40);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 23);
            this.txtBarcode.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(374, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 31;
            this.label5.Text = "条码号:";
            // 
            // txtPeno
            // 
            this.txtPeno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPeno.Location = new System.Drawing.Point(654, 40);
            this.txtPeno.Name = "txtPeno";
            this.txtPeno.Size = new System.Drawing.Size(116, 23);
            this.txtPeno.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(542, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 29;
            this.label4.Text = "体检号/住院号:";
            // 
            // txtPatName
            // 
            this.txtPatName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatName.Location = new System.Drawing.Point(255, 40);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size(112, 23);
            this.txtPatName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(179, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "患者姓名:";
            // 
            // cboSampleType
            // 
            this.cboSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSampleType.FormattingEnabled = true;
            this.cboSampleType.Location = new System.Drawing.Point(84, 40);
            this.cboSampleType.Name = "cboSampleType";
            this.cboSampleType.Size = new System.Drawing.Size(88, 22);
            this.cboSampleType.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "样本类型:";
            // 
            // chkDeptSelect
            // 
            this.chkDeptSelect.AutoSize = true;
            this.chkDeptSelect.Location = new System.Drawing.Point(12, 12);
            this.chkDeptSelect.Name = "chkDeptSelect";
            this.chkDeptSelect.Size = new System.Drawing.Size(15, 14);
            this.chkDeptSelect.TabIndex = 24;
            this.chkDeptSelect.UseVisualStyleBackColor = true;
            // 
            // btnDeptSelect
            // 
            this.btnDeptSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnDeptSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeptSelect.DefaultScheme = true;
            this.btnDeptSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeptSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeptSelect.Hint = "";
            this.btnDeptSelect.Location = new System.Drawing.Point(32, 4);
            this.btnDeptSelect.Name = "btnDeptSelect";
            this.btnDeptSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDeptSelect.Size = new System.Drawing.Size(88, 32);
            this.btnDeptSelect.TabIndex = 23;
            this.btnDeptSelect.Text = "选择科室";
            this.btnDeptSelect.Click += new System.EventHandler(this.btnDeptSelect_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(868, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(72, 32);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(700, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(72, 32);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "检索(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(784, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(72, 32);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dteRq2
            // 
            this.dteRq2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq2.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq2.Location = new System.Drawing.Point(541, 5);
            this.dteRq2.Name = "dteRq2";
            this.dteRq2.Size = new System.Drawing.Size(156, 24);
            this.dteRq2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(521, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "到";
            // 
            // dteRq1
            // 
            this.dteRq1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dteRq1.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq1.Location = new System.Drawing.Point(361, 5);
            this.dteRq1.Name = "dteRq1";
            this.dteRq1.Size = new System.Drawing.Size(156, 24);
            this.dteRq1.TabIndex = 14;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(265, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(91, 14);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "查询日期：从";
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 68);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(1167, 485);
            this.dwRep.TabIndex = 12;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // cboTimeType
            // 
            this.cboTimeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTimeType.FormattingEnabled = true;
            this.cboTimeType.Location = new System.Drawing.Point(157, 7);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Size = new System.Drawing.Size(88, 22);
            this.cboTimeType.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(126, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "按:";
            // 
            // frmSamplePacktstat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 553);
            this.Controls.Add(this.dwRep);
            this.Controls.Add(this.panel1);
            this.Name = "frmSamplePacktstat";
            this.Text = "检验标本打包、核收及项目统计";
            this.Load += new System.EventHandler(this.frmSamplePacktstat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnSelect;
        internal PinkieControls.ButtonXP btnExport;
        internal System.Windows.Forms.DateTimePicker dteRq2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dteRq1;
        private System.Windows.Forms.Label lblDate;
        internal PinkieControls.ButtonXP btnDeptSelect;
        private System.Windows.Forms.CheckBox chkDeptSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSampleType;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkChecked;
        private System.Windows.Forms.CheckBox chkUnchecked;
        private System.Windows.Forms.CheckBox chkRefuseCheck;
        private System.Windows.Forms.ComboBox cboTimeType;
        private System.Windows.Forms.Label label6;
    }
}