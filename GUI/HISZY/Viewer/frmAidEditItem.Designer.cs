namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAidEditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAidEditItem));
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtExecArea = new ControlLibrary.txtListView1(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(180, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消 Esc";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(72, 285);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(84, 34);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定 F8";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 366);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "项目代码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "项目名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "执行地点：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblItemCode);
            this.panel1.Location = new System.Drawing.Point(92, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 30);
            this.panel1.TabIndex = 14;
            // 
            // lblItemCode
            // 
            this.lblItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemCode.Location = new System.Drawing.Point(0, 0);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(200, 26);
            this.lblItemCode.TabIndex = 15;
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblItemName);
            this.panel2.Location = new System.Drawing.Point(92, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 30);
            this.panel2.TabIndex = 15;
            // 
            // lblItemName
            // 
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Location = new System.Drawing.Point(0, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(200, 26);
            this.lblItemName.TabIndex = 15;
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.txtAmount.Location = new System.Drawing.Point(92, 155);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(204, 30);
            this.txtAmount.TabIndex = 16;
            // 
            // txtExecArea
            // 
            this.txtExecArea.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtExecArea.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.txtExecArea.Location = new System.Drawing.Point(92, 218);
            this.txtExecArea.m_blnFocuseShow = true;
            this.txtExecArea.m_blnPagination = false;
            this.txtExecArea.m_dtbDataSourse = null;
            this.txtExecArea.m_intDelayTime = 100;
            this.txtExecArea.m_intPageRows = 8;
            this.txtExecArea.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.RightBottom;
            this.txtExecArea.m_listViewSize = new System.Drawing.Point(260, 200);
            this.txtExecArea.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.txtExecArea.m_strSaveField = "deptid_chr";
            this.txtExecArea.m_strShowField = "deptname_vchr";
            this.txtExecArea.m_strSQL = null;
            this.txtExecArea.Name = "txtExecArea";
            this.txtExecArea.Size = new System.Drawing.Size(204, 30);
            this.txtExecArea.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "提示：返回主界面请按<保存>键保存修改后信息。";
            // 
            // frmAidEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 366);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtExecArea);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAidEditItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑窗";
            this.Activated += new System.EventHandler(this.frmAidEditItem_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAidEditItem_KeyDown);
            this.Load += new System.EventHandler(this.frmAidEditItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtAmount;
        internal ControlLibrary.txtListView1 txtExecArea;
        private System.Windows.Forms.Label label6;
    }
}