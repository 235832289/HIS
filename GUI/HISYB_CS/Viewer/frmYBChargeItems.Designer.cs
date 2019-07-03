namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBChargeItems
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
            this.lsvJZXM = new System.Windows.Forms.ListView();
            this.check = new System.Windows.Forms.ColumnHeader();
            this.JZSJ = new System.Windows.Forms.ColumnHeader();
            this.FYRQ = new System.Windows.Forms.ColumnHeader();
            this.ZYH = new System.Windows.Forms.ColumnHeader();
            this.XMXH = new System.Windows.Forms.ColumnHeader();
            this.YYXMBM = new System.Windows.Forms.ColumnHeader();
            this.XMMC = new System.Windows.Forms.ColumnHeader();
            this.FLDM = new System.Windows.Forms.ColumnHeader();
            this.YBXMBM = new System.Windows.Forms.ColumnHeader();
            this.CFXMWYH = new System.Windows.Forms.ColumnHeader();
            this.JG = new System.Windows.Forms.ColumnHeader();
            this.MCYL = new System.Windows.Forms.ColumnHeader();
            this.JE = new System.Windows.Forms.ColumnHeader();
            this.XZSYBZ = new System.Windows.Forms.ColumnHeader();
            this.FHXZBZ = new System.Windows.Forms.ColumnHeader();
            this.DYBZ = new System.Windows.Forms.ColumnHeader();
            this.ZFEIBL = new System.Windows.Forms.ColumnHeader();
            this.ZFEIJE = new System.Windows.Forms.ColumnHeader();
            this.GWYBZBL = new System.Windows.Forms.ColumnHeader();
            this.gpbCondition = new System.Windows.Forms.GroupBox();
            this.rdbUnall = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStarTime = new System.Windows.Forms.DateTimePicker();
            this.txtJZJLH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gpbCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvJZXM
            // 
            this.lsvJZXM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.check,
            this.JZSJ,
            this.FYRQ,
            this.ZYH,
            this.XMXH,
            this.YYXMBM,
            this.XMMC,
            this.FLDM,
            this.YBXMBM,
            this.CFXMWYH,
            this.JG,
            this.MCYL,
            this.JE,
            this.XZSYBZ,
            this.FHXZBZ,
            this.DYBZ,
            this.ZFEIBL,
            this.ZFEIJE,
            this.GWYBZBL});
            this.lsvJZXM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvJZXM.FullRowSelect = true;
            this.lsvJZXM.GridLines = true;
            this.lsvJZXM.Location = new System.Drawing.Point(0, 85);
            this.lsvJZXM.Name = "lsvJZXM";
            this.lsvJZXM.Size = new System.Drawing.Size(847, 377);
            this.lsvJZXM.TabIndex = 1;
            this.lsvJZXM.UseCompatibleStateImageBehavior = false;
            this.lsvJZXM.View = System.Windows.Forms.View.Details;
            // 
            // check
            // 
            this.check.Text = "选择";
            this.check.Width = 0;
            // 
            // JZSJ
            // 
            this.JZSJ.Text = "记账时间";
            this.JZSJ.Width = 80;
            // 
            // FYRQ
            // 
            this.FYRQ.Text = "费用日期 ";
            this.FYRQ.Width = 80;
            // 
            // ZYH
            // 
            this.ZYH.Text = "住院号";
            // 
            // XMXH
            // 
            this.XMXH.Text = "项目序号";
            this.XMXH.Width = 80;
            // 
            // YYXMBM
            // 
            this.YYXMBM.Text = "医院项目编码 ";
            this.YYXMBM.Width = 80;
            // 
            // XMMC
            // 
            this.XMMC.Text = "项目名称 ";
            this.XMMC.Width = 130;
            // 
            // FLDM
            // 
            this.FLDM.Text = "分类代码 ";
            // 
            // YBXMBM
            // 
            this.YBXMBM.Text = "医保项目编码 ";
            this.YBXMBM.Width = 100;
            // 
            // CFXMWYH
            // 
            this.CFXMWYH.Text = "处方项目唯一号";
            this.CFXMWYH.Width = 120;
            // 
            // JG
            // 
            this.JG.Text = "价格 ";
            // 
            // MCYL
            // 
            this.MCYL.Text = "数量 ";
            // 
            // JE
            // 
            this.JE.Text = "费用总额 ";
            this.JE.Width = 80;
            // 
            // XZSYBZ
            // 
            this.XZSYBZ.Text = "限制性用药标志 ";
            // 
            // FHXZBZ
            // 
            this.FHXZBZ.Text = "适应症使用标志 ";
            // 
            // DYBZ
            // 
            this.DYBZ.Text = "对应标志";
            // 
            // ZFEIBL
            // 
            this.ZFEIBL.Text = "自费比例 ";
            this.ZFEIBL.Width = 80;
            // 
            // ZFEIJE
            // 
            this.ZFEIJE.Text = "自费金额 ";
            this.ZFEIJE.Width = 80;
            // 
            // GWYBZBL
            // 
            this.GWYBZBL.Text = "纯自费比例";
            this.GWYBZBL.Width = 80;
            // 
            // gpbCondition
            // 
            this.gpbCondition.Controls.Add(this.btnClose);
            this.gpbCondition.Controls.Add(this.rdbUnall);
            this.gpbCondition.Controls.Add(this.rdbAll);
            this.gpbCondition.Controls.Add(this.btnDelete);
            this.gpbCondition.Controls.Add(this.btnQuery);
            this.gpbCondition.Controls.Add(this.label3);
            this.gpbCondition.Controls.Add(this.label2);
            this.gpbCondition.Controls.Add(this.dtpEndTime);
            this.gpbCondition.Controls.Add(this.dtpStarTime);
            this.gpbCondition.Controls.Add(this.txtJZJLH);
            this.gpbCondition.Controls.Add(this.label1);
            this.gpbCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCondition.Location = new System.Drawing.Point(0, 0);
            this.gpbCondition.Name = "gpbCondition";
            this.gpbCondition.Size = new System.Drawing.Size(847, 85);
            this.gpbCondition.TabIndex = 0;
            this.gpbCondition.TabStop = false;
            // 
            // rdbUnall
            // 
            this.rdbUnall.AutoSize = true;
            this.rdbUnall.Location = new System.Drawing.Point(61, 64);
            this.rdbUnall.Name = "rdbUnall";
            this.rdbUnall.Size = new System.Drawing.Size(53, 18);
            this.rdbUnall.TabIndex = 9;
            this.rdbUnall.TabStop = true;
            this.rdbUnall.Text = "反选";
            this.rdbUnall.UseVisualStyleBackColor = true;
            this.rdbUnall.Visible = false;
            this.rdbUnall.Click += new System.EventHandler(this.rdbUnall_Click);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(6, 64);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(53, 18);
            this.rdbAll.TabIndex = 8;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "全选";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.Visible = false;
            this.rdbAll.Click += new System.EventHandler(this.rdbAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(380, 43);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "批量删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(181, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "记账时间:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(584, 13);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(200, 23);
            this.dtpEndTime.TabIndex = 3;
            // 
            // dtpStarTime
            // 
            this.dtpStarTime.Location = new System.Drawing.Point(353, 12);
            this.dtpStarTime.Name = "dtpStarTime";
            this.dtpStarTime.Size = new System.Drawing.Size(200, 23);
            this.dtpStarTime.TabIndex = 2;
            // 
            // txtJZJLH
            // 
            this.txtJZJLH.Location = new System.Drawing.Point(106, 13);
            this.txtJZJLH.Name = "txtJZJLH";
            this.txtJZJLH.Size = new System.Drawing.Size(150, 23);
            this.txtJZJLH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "就诊记录号:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(549, 43);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmYBChargeItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 462);
            this.Controls.Add(this.lsvJZXM);
            this.Controls.Add(this.gpbCondition);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmYBChargeItems";
            this.Text = "住院记帐处方项目";
            this.Load += new System.EventHandler(this.frmYBChargeItems_Load);
            this.gpbCondition.ResumeLayout(false);
            this.gpbCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ColumnHeader JZSJ;
        private System.Windows.Forms.ColumnHeader FYRQ;
        private System.Windows.Forms.ColumnHeader ZYH;
        private System.Windows.Forms.ColumnHeader XMXH;
        private System.Windows.Forms.ColumnHeader YYXMBM;
        private System.Windows.Forms.ColumnHeader XMMC;
        private System.Windows.Forms.ColumnHeader FLDM;
        private System.Windows.Forms.ColumnHeader YBXMBM;
        private System.Windows.Forms.ColumnHeader CFXMWYH;
        private System.Windows.Forms.ColumnHeader JG;
        private System.Windows.Forms.ColumnHeader MCYL;
        private System.Windows.Forms.ColumnHeader JE;
        private System.Windows.Forms.ColumnHeader XZSYBZ;
        private System.Windows.Forms.ColumnHeader FHXZBZ;
        private System.Windows.Forms.ColumnHeader DYBZ;
        private System.Windows.Forms.ColumnHeader ZFEIBL;
        private System.Windows.Forms.ColumnHeader ZFEIJE;
        private System.Windows.Forms.ColumnHeader GWYBZBL;
        internal System.Windows.Forms.TextBox txtJZJLH;
        internal System.Windows.Forms.DateTimePicker dtpStarTime;
        internal System.Windows.Forms.DateTimePicker dtpEndTime;
        internal System.Windows.Forms.ListView lsvJZXM;
        private System.Windows.Forms.ColumnHeader check;
        private System.Windows.Forms.RadioButton rdbUnall;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.Button btnClose;
    }
}