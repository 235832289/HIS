namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAidEditItem_OutPatientDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAidEditItem_OutPatientDefault));
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRegStatus = new System.Windows.Forms.ComboBox();
            this.cboRecipeType = new System.Windows.Forms.ComboBox();
            this.cboDuty = new System.Windows.Forms.ComboBox();
            this.mskBeginTime = new System.Windows.Forms.MaskedTextBox();
            this.mskEndTime = new System.Windows.Forms.MaskedTextBox();
            this.dgvDept = new System.Windows.Forms.DataGridView();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
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
            this.btnCancel.Location = new System.Drawing.Point(180, 368);
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
            this.btnOk.Location = new System.Drawing.Point(72, 368);
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
            this.label1.Size = new System.Drawing.Size(314, 440);
            this.label1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "项目名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "数量：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblItemName);
            this.panel2.Location = new System.Drawing.Point(92, 19);
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
            this.txtAmount.Location = new System.Drawing.Point(92, 57);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(204, 30);
            this.txtAmount.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "提示：返回主界面请按<保存>键保存修改后信息。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "挂号状态：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "处方类型：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "医生职称：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "时间 从：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "到：";
            // 
            // cboRegStatus
            // 
            this.cboRegStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegStatus.Font = new System.Drawing.Font("宋体", 15F);
            this.cboRegStatus.FormattingEnabled = true;
            this.cboRegStatus.Items.AddRange(new object[] {
            "全部",
            "已挂号",
            "未挂号"});
            this.cboRegStatus.Location = new System.Drawing.Point(92, 94);
            this.cboRegStatus.Name = "cboRegStatus";
            this.cboRegStatus.Size = new System.Drawing.Size(204, 28);
            this.cboRegStatus.TabIndex = 49;
            // 
            // cboRecipeType
            // 
            this.cboRecipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecipeType.Font = new System.Drawing.Font("宋体", 15F);
            this.cboRecipeType.FormattingEnabled = true;
            this.cboRecipeType.Items.AddRange(new object[] {
            "全部",
            "正方",
            "副方"});
            this.cboRecipeType.Location = new System.Drawing.Point(92, 129);
            this.cboRecipeType.Name = "cboRecipeType";
            this.cboRecipeType.Size = new System.Drawing.Size(204, 28);
            this.cboRecipeType.TabIndex = 51;
            // 
            // cboDuty
            // 
            this.cboDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuty.Font = new System.Drawing.Font("宋体", 15F);
            this.cboDuty.FormattingEnabled = true;
            this.cboDuty.Location = new System.Drawing.Point(92, 164);
            this.cboDuty.Name = "cboDuty";
            this.cboDuty.Size = new System.Drawing.Size(204, 28);
            this.cboDuty.TabIndex = 52;
            // 
            // mskBeginTime
            // 
            this.mskBeginTime.Font = new System.Drawing.Font("宋体", 15F);
            this.mskBeginTime.Location = new System.Drawing.Point(92, 200);
            this.mskBeginTime.Mask = "90:00";
            this.mskBeginTime.Name = "mskBeginTime";
            this.mskBeginTime.Size = new System.Drawing.Size(204, 30);
            this.mskBeginTime.TabIndex = 53;
            this.mskBeginTime.ValidatingType = typeof(System.DateTime);
            // 
            // mskEndTime
            // 
            this.mskEndTime.Font = new System.Drawing.Font("宋体", 15F);
            this.mskEndTime.Location = new System.Drawing.Point(92, 238);
            this.mskEndTime.Mask = "90:00";
            this.mskEndTime.Name = "mskEndTime";
            this.mskEndTime.Size = new System.Drawing.Size(204, 30);
            this.mskEndTime.TabIndex = 54;
            this.mskEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // dgvDept
            // 
            this.dgvDept.AllowUserToAddRows = false;
            this.dgvDept.BackgroundColor = System.Drawing.Color.White;
            this.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptName,
            this.colPy,
            this.colWb,
            this.colUserCode,
            this.colID});
            this.dgvDept.Location = new System.Drawing.Point(92, 304);
            this.dgvDept.MultiSelect = false;
            this.dgvDept.Name = "dgvDept";
            this.dgvDept.RowHeadersVisible = false;
            this.dgvDept.RowTemplate.Height = 23;
            this.dgvDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDept.Size = new System.Drawing.Size(204, 138);
            this.dgvDept.TabIndex = 60;
            this.dgvDept.Visible = false;
            this.dgvDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDept_KeyDown);
            this.dgvDept.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDept_CellDoubleClick);
            this.dgvDept.Leave += new System.EventHandler(this.dgvDept_Leave);
            // 
            // colDeptName
            // 
            this.colDeptName.DataPropertyName = "deptname_vchr";
            this.colDeptName.HeaderText = "科室名称";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 180;
            // 
            // colPy
            // 
            this.colPy.DataPropertyName = "pycode_chr";
            this.colPy.HeaderText = "拼音码";
            this.colPy.Name = "colPy";
            this.colPy.ReadOnly = true;
            this.colPy.Visible = false;
            // 
            // colWb
            // 
            this.colWb.DataPropertyName = "wbcode_chr";
            this.colWb.HeaderText = "五笔码";
            this.colWb.Name = "colWb";
            this.colWb.ReadOnly = true;
            this.colWb.Visible = false;
            // 
            // colUserCode
            // 
            this.colUserCode.DataPropertyName = "usercode_vchr";
            this.colUserCode.HeaderText = "助记码";
            this.colUserCode.Name = "colUserCode";
            this.colUserCode.ReadOnly = true;
            this.colUserCode.Visible = false;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "deptid_chr";
            this.colID.HeaderText = "科室ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // txtDept
            // 
            this.txtDept.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDept.Location = new System.Drawing.Point(92, 275);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(204, 29);
            this.txtDept.TabIndex = 59;
            this.txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDept_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "特定科室：";
            // 
            // frmAidEditItem_OutPatientDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 440);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDept);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskEndTime);
            this.Controls.Add(this.mskBeginTime);
            this.Controls.Add(this.cboDuty);
            this.Controls.Add(this.cboRecipeType);
            this.Controls.Add(this.cboRegStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAidEditItem_OutPatientDefault";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑窗";
            this.Activated += new System.EventHandler(this.frmAidEditItem_OutPatientDefault_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAidEditItem_OutPatientDefault_KeyDown);
            this.Load += new System.EventHandler(this.frmAidEditItem_OutPatientDefault_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRegStatus;
        private System.Windows.Forms.ComboBox cboRecipeType;
        private System.Windows.Forms.ComboBox cboDuty;
        private System.Windows.Forms.MaskedTextBox mskBeginTime;
        private System.Windows.Forms.MaskedTextBox mskEndTime;
        private System.Windows.Forms.DataGridView dgvDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        internal System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label2;
    }
}