namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmShiying
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiying));
            this.btnEmpty = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnDel = new PinkieControls.ButtonXP();
            this.btnSave = new PinkieControls.ButtonXP();
            this.txtHosCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtYbCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYxbz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNameEG = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJixing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXzsybz = new System.Windows.Forms.TextBox();
            this.txtXzsysm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colHosCode = new System.Windows.Forms.ColumnHeader();
            this.colYbCode = new System.Windows.Forms.ColumnHeader();
            this.colItemType = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colNameEG = new System.Windows.Forms.ColumnHeader();
            this.colJixing = new System.Windows.Forms.ColumnHeader();
            this.colXzsyBz = new System.Windows.Forms.ColumnHeader();
            this.colXzsySm = new System.Windows.Forms.ColumnHeader();
            this.colYxbz = new System.Windows.Forms.ColumnHeader();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEmpty
            // 
            this.btnEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEmpty.DefaultScheme = true;
            this.btnEmpty.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEmpty.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpty.Hint = "";
            this.btnEmpty.Location = new System.Drawing.Point(790, 380);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEmpty.Size = new System.Drawing.Size(81, 33);
            this.btnEmpty.TabIndex = 149;
            this.btnEmpty.Text = "新增";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(882, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 148;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnDel.DefaultScheme = true;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Hint = "";
            this.btnDel.Location = new System.Drawing.Point(790, 420);
            this.btnDel.Name = "btnDel";
            this.btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDel.Size = new System.Drawing.Size(81, 33);
            this.btnDel.TabIndex = 147;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(882, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 146;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHosCode
            // 
            this.txtHosCode.Location = new System.Drawing.Point(118, 372);
            this.txtHosCode.Name = "txtHosCode";
            this.txtHosCode.Size = new System.Drawing.Size(155, 23);
            this.txtHosCode.TabIndex = 145;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 14);
            this.label10.TabIndex = 144;
            this.label10.Text = "医院项目编码：";
            // 
            // txtYbCode
            // 
            this.txtYbCode.Location = new System.Drawing.Point(393, 372);
            this.txtYbCode.Name = "txtYbCode";
            this.txtYbCode.Size = new System.Drawing.Size(155, 23);
            this.txtYbCode.TabIndex = 143;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 142;
            this.label9.Text = "医保项目编码：";
            // 
            // txtItemType
            // 
            this.txtItemType.Location = new System.Drawing.Point(651, 372);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(100, 23);
            this.txtItemType.TabIndex = 141;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(579, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 140;
            this.label8.Text = "项目类别：";
            // 
            // txtYxbz
            // 
            this.txtYxbz.Location = new System.Drawing.Point(651, 434);
            this.txtYxbz.Name = "txtYxbz";
            this.txtYxbz.Size = new System.Drawing.Size(100, 23);
            this.txtYxbz.TabIndex = 139;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(579, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 138;
            this.label7.Text = "有效标志：";
            // 
            // txtNameEG
            // 
            this.txtNameEG.Location = new System.Drawing.Point(393, 403);
            this.txtNameEG.Name = "txtNameEG";
            this.txtNameEG.Size = new System.Drawing.Size(155, 23);
            this.txtNameEG.TabIndex = 137;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 403);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 23);
            this.txtName.TabIndex = 135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 134;
            this.label5.Text = "英文名称：";
            // 
            // txtJixing
            // 
            this.txtJixing.Location = new System.Drawing.Point(651, 403);
            this.txtJixing.Name = "txtJixing";
            this.txtJixing.Size = new System.Drawing.Size(100, 23);
            this.txtJixing.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 132;
            this.label4.Text = "剂型：";
            // 
            // txtXzsybz
            // 
            this.txtXzsybz.Location = new System.Drawing.Point(118, 434);
            this.txtXzsybz.Name = "txtXzsybz";
            this.txtXzsybz.Size = new System.Drawing.Size(155, 23);
            this.txtXzsybz.TabIndex = 131;
            // 
            // txtXzsysm
            // 
            this.txtXzsysm.Location = new System.Drawing.Point(393, 434);
            this.txtXzsysm.Name = "txtXzsysm";
            this.txtXzsysm.Size = new System.Drawing.Size(155, 23);
            this.txtXzsysm.TabIndex = 129;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 128;
            this.label2.Text = "限制使用说明：";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHosCode,
            this.colYbCode,
            this.colItemType,
            this.colName,
            this.colNameEG,
            this.colJixing,
            this.colXzsyBz,
            this.colXzsySm,
            this.colYxbz});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(1, 42);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(973, 319);
            this.listView1.TabIndex = 127;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colHosCode
            // 
            this.colHosCode.Text = "医院项目编码";
            this.colHosCode.Width = 98;
            // 
            // colYbCode
            // 
            this.colYbCode.Text = "医保项目编码";
            this.colYbCode.Width = 113;
            // 
            // colItemType
            // 
            this.colItemType.Text = "项目类别";
            this.colItemType.Width = 69;
            // 
            // colName
            // 
            this.colName.Text = "中文名称";
            this.colName.Width = 176;
            // 
            // colNameEG
            // 
            this.colNameEG.Text = "英文名称";
            this.colNameEG.Width = 93;
            // 
            // colJixing
            // 
            this.colJixing.Text = "剂型";
            this.colJixing.Width = 74;
            // 
            // colXzsyBz
            // 
            this.colXzsyBz.Text = "限制使用标志";
            this.colXzsyBz.Width = 100;
            // 
            // colXzsySm
            // 
            this.colXzsySm.Text = "限制使用说明";
            this.colXzsySm.Width = 175;
            // 
            // colYxbz
            // 
            this.colYxbz.Text = "有效标志";
            this.colYxbz.Width = 69;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(82, 8);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(100, 23);
            this.txtQuery.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 125;
            this.label1.Text = "查询条件";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(205, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(77, 28);
            this.btnQuery.TabIndex = 124;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 136;
            this.label6.Text = "中文名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 130;
            this.label3.Text = "限制使用标志：";
            // 
            // frmShiying
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 463);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHosCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtYbCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtYxbz);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNameEG);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJixing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtXzsybz);
            this.Controls.Add(this.txtXzsysm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmShiying";
            this.Text = "适应症目录维护";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colHosCode;
        private System.Windows.Forms.ColumnHeader colYbCode;
        private System.Windows.Forms.ColumnHeader colItemType;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colNameEG;
        private System.Windows.Forms.ColumnHeader colJixing;
        private System.Windows.Forms.ColumnHeader colXzsyBz;
        private System.Windows.Forms.ColumnHeader colXzsySm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal PinkieControls.ButtonXP btnSave;
        internal PinkieControls.ButtonXP btnDel;
        internal PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.ColumnHeader colYxbz;
        internal PinkieControls.ButtonXP btnEmpty;
        internal System.Windows.Forms.TextBox txtQuery;
        internal System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.TextBox txtXzsysm;
        internal System.Windows.Forms.TextBox txtXzsybz;
        internal System.Windows.Forms.TextBox txtJixing;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtNameEG;
        internal System.Windows.Forms.TextBox txtYxbz;
        internal System.Windows.Forms.TextBox txtItemType;
        internal System.Windows.Forms.TextBox txtYbCode;
        internal System.Windows.Forms.TextBox txtHosCode;
    }
}