namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmChooseRecipe
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
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.btnPrintOrder = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.cboZyRecipeNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Enabled = false;
            this.chk1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk1.Location = new System.Drawing.Point(16, 32);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(104, 17);
            this.chk1.TabIndex = 0;
            this.chk1.Text = "普通西药处方";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Enabled = false;
            this.chk2.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk2.Location = new System.Drawing.Point(132, 124);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(78, 17);
            this.chk2.TabIndex = 1;
            this.chk2.Text = "中药处方";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.Enabled = false;
            this.chk7.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk7.Location = new System.Drawing.Point(16, 78);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(78, 17);
            this.chk7.TabIndex = 2;
            this.chk7.Text = "儿科处方";
            this.chk7.UseVisualStyleBackColor = true;
            this.chk7.CheckedChanged += new System.EventHandler(this.chk7_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Enabled = false;
            this.chk3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk3.Location = new System.Drawing.Point(16, 124);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(91, 17);
            this.chk3.TabIndex = 3;
            this.chk3.Text = "易制毒处方";
            this.chk3.UseVisualStyleBackColor = true;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Enabled = false;
            this.chk4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk4.Location = new System.Drawing.Point(16, 170);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(78, 17);
            this.chk4.TabIndex = 4;
            this.chk4.Text = "麻醉处方";
            this.chk4.UseVisualStyleBackColor = true;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.Enabled = false;
            this.chk5.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk5.Location = new System.Drawing.Point(132, 32);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(78, 17);
            this.chk5.TabIndex = 5;
            this.chk5.Text = "精神一类";
            this.chk5.UseVisualStyleBackColor = true;
            this.chk5.CheckedChanged += new System.EventHandler(this.chk5_CheckedChanged);
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.Enabled = false;
            this.chk6.Font = new System.Drawing.Font("宋体", 9.5F);
            this.chk6.Location = new System.Drawing.Point(132, 78);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(78, 17);
            this.chk6.TabIndex = 6;
            this.chk6.Text = "精神二类";
            this.chk6.UseVisualStyleBackColor = true;
            this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrintOrder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrintOrder.DefaultScheme = true;
            this.btnPrintOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintOrder.Hint = "";
            this.btnPrintOrder.Location = new System.Drawing.Point(232, 28);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintOrder.Size = new System.Drawing.Size(88, 28);
            this.btnPrintOrder.TabIndex = 48;
            this.btnPrintOrder.Text = "打印";
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(232, 68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(88, 28);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label1.Location = new System.Drawing.Point(135, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "中药处方列表：";
            // 
            // cboZyRecipeNo
            // 
            this.cboZyRecipeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZyRecipeNo.Font = new System.Drawing.Font("宋体", 9.5F);
            this.cboZyRecipeNo.FormattingEnabled = true;
            this.cboZyRecipeNo.Location = new System.Drawing.Point(232, 150);
            this.cboZyRecipeNo.Name = "cboZyRecipeNo";
            this.cboZyRecipeNo.Size = new System.Drawing.Size(88, 21);
            this.cboZyRecipeNo.TabIndex = 51;
            // 
            // frmChooseRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 226);
            this.ControlBox = false;
            this.Controls.Add(this.cboZyRecipeNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmChooseRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择处方";
            this.Load += new System.EventHandler(this.frmChooseRecipe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChooseRecipe_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk7;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.CheckBox chk6;
        private PinkieControls.ButtonXP btnPrintOrder;
        private PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboZyRecipeNo;
    }
}