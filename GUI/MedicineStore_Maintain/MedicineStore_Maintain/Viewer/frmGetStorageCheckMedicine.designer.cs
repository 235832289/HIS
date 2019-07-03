namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmGetStorageCheckMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetStorageCheckMedicine));
            this.m_rdbCheckSortNum = new System.Windows.Forms.RadioButton();
            this.m_rdbMedicineCode = new System.Windows.Forms.RadioButton();
            this.m_rdbMedicinePreptype = new System.Windows.Forms.RadioButton();
            this.m_rdbRackNum = new System.Windows.Forms.RadioButton();
            this.m_txtCheckSortNum1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtCheckSortNum2 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineCode1 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineCode2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboMediciePreptype = new System.Windows.Forms.ComboBox();
            this.m_txtRackNum1 = new System.Windows.Forms.TextBox();
            this.m_txtRackNum2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // m_rdbCheckSortNum
            // 
            this.m_rdbCheckSortNum.AutoSize = true;
            this.m_rdbCheckSortNum.Location = new System.Drawing.Point(12, 248);
            this.m_rdbCheckSortNum.Name = "m_rdbCheckSortNum";
            this.m_rdbCheckSortNum.Size = new System.Drawing.Size(95, 18);
            this.m_rdbCheckSortNum.TabIndex = 1000;
            this.m_rdbCheckSortNum.Text = "盘点顺序号";
            this.m_rdbCheckSortNum.UseVisualStyleBackColor = true;
            this.m_rdbCheckSortNum.CheckedChanged += new System.EventHandler(this.m_rdbCheckSortNum_CheckedChanged);
            // 
            // m_rdbMedicineCode
            // 
            this.m_rdbMedicineCode.AutoSize = true;
            this.m_rdbMedicineCode.Location = new System.Drawing.Point(12, 12);
            this.m_rdbMedicineCode.Name = "m_rdbMedicineCode";
            this.m_rdbMedicineCode.Size = new System.Drawing.Size(81, 18);
            this.m_rdbMedicineCode.TabIndex = 1000;
            this.m_rdbMedicineCode.Text = "药品代码";
            this.m_rdbMedicineCode.UseVisualStyleBackColor = true;
            this.m_rdbMedicineCode.CheckedChanged += new System.EventHandler(this.m_rdbMedicineCode_CheckedChanged);
            // 
            // m_rdbMedicinePreptype
            // 
            this.m_rdbMedicinePreptype.AutoSize = true;
            this.m_rdbMedicinePreptype.Location = new System.Drawing.Point(12, 55);
            this.m_rdbMedicinePreptype.Name = "m_rdbMedicinePreptype";
            this.m_rdbMedicinePreptype.Size = new System.Drawing.Size(53, 18);
            this.m_rdbMedicinePreptype.TabIndex = 1000;
            this.m_rdbMedicinePreptype.Text = "剂型";
            this.m_rdbMedicinePreptype.UseVisualStyleBackColor = true;
            this.m_rdbMedicinePreptype.CheckedChanged += new System.EventHandler(this.m_rdbMedicineType_CheckedChanged);
            // 
            // m_rdbRackNum
            // 
            this.m_rdbRackNum.AutoSize = true;
            this.m_rdbRackNum.Location = new System.Drawing.Point(12, 218);
            this.m_rdbRackNum.Name = "m_rdbRackNum";
            this.m_rdbRackNum.Size = new System.Drawing.Size(67, 18);
            this.m_rdbRackNum.TabIndex = 1000;
            this.m_rdbRackNum.Text = "货架号";
            this.m_rdbRackNum.UseVisualStyleBackColor = true;
            this.m_rdbRackNum.CheckedChanged += new System.EventHandler(this.m_rdbRackNum_CheckedChanged);
            // 
            // m_txtCheckSortNum1
            // 
            this.m_txtCheckSortNum1.Enabled = false;
            this.m_txtCheckSortNum1.Location = new System.Drawing.Point(112, 245);
            this.m_txtCheckSortNum1.Name = "m_txtCheckSortNum1";
            this.m_txtCheckSortNum1.Size = new System.Drawing.Size(128, 23);
            this.m_txtCheckSortNum1.TabIndex = 5;
            this.m_txtCheckSortNum1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCheckSortNum1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "~";
            // 
            // m_txtCheckSortNum2
            // 
            this.m_txtCheckSortNum2.Enabled = false;
            this.m_txtCheckSortNum2.Location = new System.Drawing.Point(266, 245);
            this.m_txtCheckSortNum2.Name = "m_txtCheckSortNum2";
            this.m_txtCheckSortNum2.Size = new System.Drawing.Size(128, 23);
            this.m_txtCheckSortNum2.TabIndex = 10;
            this.m_txtCheckSortNum2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCheckSortNum2_KeyDown);
            // 
            // m_txtMedicineCode1
            // 
            this.m_txtMedicineCode1.Enabled = false;
            this.m_txtMedicineCode1.Location = new System.Drawing.Point(112, 9);
            this.m_txtMedicineCode1.Name = "m_txtMedicineCode1";
            this.m_txtMedicineCode1.Size = new System.Drawing.Size(128, 23);
            this.m_txtMedicineCode1.TabIndex = 15;
            this.m_txtMedicineCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode1_KeyDown);
            // 
            // m_txtMedicineCode2
            // 
            this.m_txtMedicineCode2.Enabled = false;
            this.m_txtMedicineCode2.Location = new System.Drawing.Point(266, 9);
            this.m_txtMedicineCode2.Name = "m_txtMedicineCode2";
            this.m_txtMedicineCode2.Size = new System.Drawing.Size(128, 23);
            this.m_txtMedicineCode2.TabIndex = 20;
            this.m_txtMedicineCode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            // 
            // m_cboMediciePreptype
            // 
            this.m_cboMediciePreptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMediciePreptype.Enabled = false;
            this.m_cboMediciePreptype.FormattingEnabled = true;
            this.m_cboMediciePreptype.Location = new System.Drawing.Point(112, 53);
            this.m_cboMediciePreptype.Name = "m_cboMediciePreptype";
            this.m_cboMediciePreptype.Size = new System.Drawing.Size(128, 22);
            this.m_cboMediciePreptype.TabIndex = 25;
            // 
            // m_txtRackNum1
            // 
            this.m_txtRackNum1.Enabled = false;
            this.m_txtRackNum1.Location = new System.Drawing.Point(112, 216);
            this.m_txtRackNum1.Name = "m_txtRackNum1";
            this.m_txtRackNum1.Size = new System.Drawing.Size(128, 23);
            this.m_txtRackNum1.TabIndex = 30;
            this.m_txtRackNum1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRackNum1_KeyDown);
            // 
            // m_txtRackNum2
            // 
            this.m_txtRackNum2.Enabled = false;
            this.m_txtRackNum2.Location = new System.Drawing.Point(266, 216);
            this.m_txtRackNum2.Name = "m_txtRackNum2";
            this.m_txtRackNum2.Size = new System.Drawing.Size(128, 23);
            this.m_txtRackNum2.TabIndex = 35;
            this.m_txtRackNum2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRackNum2_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "~";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.Location = new System.Drawing.Point(112, 115);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(75, 23);
            this.m_cmdOK.TabIndex = 40;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Location = new System.Drawing.Point(217, 115);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.m_cmdCancel.TabIndex = 45;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.AutoSize = true;
            this.m_rdbAll.Checked = true;
            this.m_rdbAll.Location = new System.Drawing.Point(10, 94);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(81, 18);
            this.m_rdbAll.TabIndex = 1001;
            this.m_rdbAll.TabStop = true;
            this.m_rdbAll.Text = "所有药品";
            this.m_rdbAll.UseVisualStyleBackColor = true;
            // 
            // frmGetStorageCheckMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(412, 159);
            this.Controls.Add(this.m_rdbAll);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cboMediciePreptype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtRackNum2);
            this.Controls.Add(this.m_txtRackNum1);
            this.Controls.Add(this.m_txtMedicineCode2);
            this.Controls.Add(this.m_txtMedicineCode1);
            this.Controls.Add(this.m_txtCheckSortNum2);
            this.Controls.Add(this.m_txtCheckSortNum1);
            this.Controls.Add(this.m_rdbRackNum);
            this.Controls.Add(this.m_rdbMedicinePreptype);
            this.Controls.Add(this.m_rdbMedicineCode);
            this.Controls.Add(this.m_rdbCheckSortNum);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetStorageCheckMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取盘点药品";
            this.Load += new System.EventHandler(this.frmGetStorageCheckMedicine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_cmdOK;
        private System.Windows.Forms.Button m_cmdCancel;
        internal System.Windows.Forms.RadioButton m_rdbCheckSortNum;
        internal System.Windows.Forms.RadioButton m_rdbMedicineCode;
        internal System.Windows.Forms.RadioButton m_rdbMedicinePreptype;
        internal System.Windows.Forms.RadioButton m_rdbRackNum;
        internal System.Windows.Forms.TextBox m_txtCheckSortNum1;
        internal System.Windows.Forms.TextBox m_txtCheckSortNum2;
        internal System.Windows.Forms.TextBox m_txtMedicineCode1;
        internal System.Windows.Forms.TextBox m_txtMedicineCode2;
        internal System.Windows.Forms.ComboBox m_cboMediciePreptype;
        internal System.Windows.Forms.TextBox m_txtRackNum1;
        internal System.Windows.Forms.TextBox m_txtRackNum2;
        internal System.Windows.Forms.RadioButton m_rdbAll;
    }
}