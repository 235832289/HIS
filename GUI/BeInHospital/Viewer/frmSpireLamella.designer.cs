namespace SpireLamella
{
    partial class frmSpireLamella
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.lblPatName = new System.Windows.Forms.Label();
            this.lblIpNo = new System.Windows.Forms.Label();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboGlGm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 355);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印 &P";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "住院号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "床号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "科室：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "佩戴：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "核对：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭 &C";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptName.ForeColor = System.Drawing.Color.Crimson;
            this.lblDeptName.Location = new System.Drawing.Point(72, 185);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(49, 13);
            this.lblDeptName.TabIndex = 13;
            this.lblDeptName.Text = "科室：";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSex.ForeColor = System.Drawing.Color.Crimson;
            this.lblSex.Location = new System.Drawing.Point(72, 119);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(49, 13);
            this.lblSex.TabIndex = 12;
            this.lblSex.Text = "性别：";
            // 
            // lblBedNo
            // 
            this.lblBedNo.AutoSize = true;
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBedNo.ForeColor = System.Drawing.Color.Crimson;
            this.lblBedNo.Location = new System.Drawing.Point(72, 53);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(49, 13);
            this.lblBedNo.TabIndex = 11;
            this.lblBedNo.Text = "床号：";
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPatName.ForeColor = System.Drawing.Color.Crimson;
            this.lblPatName.Location = new System.Drawing.Point(72, 86);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(49, 13);
            this.lblPatName.TabIndex = 10;
            this.lblPatName.Text = "姓名：";
            // 
            // lblIpNo
            // 
            this.lblIpNo.AutoSize = true;
            this.lblIpNo.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIpNo.ForeColor = System.Drawing.Color.Crimson;
            this.lblIpNo.Location = new System.Drawing.Point(72, 20);
            this.lblIpNo.Name = "lblIpNo";
            this.lblIpNo.Size = new System.Drawing.Size(63, 13);
            this.lblIpNo.TabIndex = 9;
            this.lblIpNo.Text = "住院号：";
            // 
            // txtOper
            // 
            this.txtOper.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtOper.ForeColor = System.Drawing.Color.Crimson;
            this.txtOper.Location = new System.Drawing.Point(72, 213);
            this.txtOper.Name = "txtOper";
            this.txtOper.Size = new System.Drawing.Size(100, 22);
            this.txtOper.TabIndex = 14;
            // 
            // txtCheck
            // 
            this.txtCheck.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtCheck.ForeColor = System.Drawing.Color.Crimson;
            this.txtCheck.Location = new System.Drawing.Point(72, 247);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(100, 22);
            this.txtCheck.TabIndex = 15;
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Checked = true;
            this.rdoYes.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoYes.Location = new System.Drawing.Point(78, 317);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(36, 16);
            this.rdoYes.TabIndex = 16;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "是";
            this.rdoYes.UseVisualStyleBackColor = true;
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoNo.Location = new System.Drawing.Point(128, 317);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(36, 16);
            this.rdoNo.TabIndex = 17;
            this.rdoNo.Text = "否";
            this.rdoNo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "成人带：";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAge.ForeColor = System.Drawing.Color.Crimson;
            this.lblAge.Location = new System.Drawing.Point(72, 152);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(49, 13);
            this.lblAge.TabIndex = 20;
            this.lblAge.Text = "性别：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "年龄：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "GL/GM：";
            // 
            // cboGlGm
            // 
            this.cboGlGm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGlGm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboGlGm.FormattingEnabled = true;
            this.cboGlGm.Items.AddRange(new object[] {
            "",
            "GL",
            "GM",
            "GL/GM"});
            this.cboGlGm.Location = new System.Drawing.Point(72, 280);
            this.cboGlGm.Name = "cboGlGm";
            this.cboGlGm.Size = new System.Drawing.Size(100, 20);
            this.cboGlGm.TabIndex = 22;
            // 
            // frmSpireLamella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 401);
            this.Controls.Add(this.cboGlGm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdoNo);
            this.Controls.Add(this.rdoYes);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.txtOper);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBedNo);
            this.Controls.Add(this.lblPatName);
            this.Controls.Add(this.lblIpNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpireLamella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "腕带打印";
            this.Load += new System.EventHandler(this.frmSpireLamella_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Label lblIpNo;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboGlGm;
    }
}

