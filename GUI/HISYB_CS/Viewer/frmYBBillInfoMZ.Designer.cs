namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBBillInfoMZ
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBillDetail = new System.Windows.Forms.DataGridView();
            this.GMSFHM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YYBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YYMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZYJSLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JZLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JSRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RYRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CYRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CYZD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JZJLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDYWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YLFYZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCZF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRZFZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KSMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YYRYKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MZYFBXJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCYLTCZF1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCYLTCZF2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCYLTCZF3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCYLTCZF4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTZHIFU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.cboPatientType = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBillDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(985, 549);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细信息";
            // 
            // dgvBillDetail
            // 
            this.dgvBillDetail.AllowUserToAddRows = false;
            this.dgvBillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GMSFHM,
            this.GRBH,
            this.XM,
            this.YYBH,
            this.YYMC,
            this.ZYJSLB,
            this.JZLB,
            this.JSRQ,
            this.RYRQ,
            this.CYRQ,
            this.CYZD,
            this.JZJLH,
            this.SDYWH,
            this.CFH,
            this.ZH,
            this.YLFYZE,
            this.TCZF,
            this.GRZFZE,
            this.KSMC,
            this.YYRYKS,
            this.MZYFBXJE,
            this.BCYLTCZF1,
            this.BCYLTCZF2,
            this.BCYLTCZF3,
            this.BCYLTCZF4,
            this.QTZHIFU});
            this.dgvBillDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvBillDetail.Name = "dgvBillDetail";
            this.dgvBillDetail.ReadOnly = true;
            this.dgvBillDetail.RowTemplate.Height = 23;
            this.dgvBillDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillDetail.Size = new System.Drawing.Size(979, 527);
            this.dgvBillDetail.TabIndex = 0;
            // 
            // GMSFHM
            // 
            this.GMSFHM.HeaderText = "公民身份号码";
            this.GMSFHM.Name = "GMSFHM";
            this.GMSFHM.ReadOnly = true;
            // 
            // GRBH
            // 
            this.GRBH.HeaderText = "个人编号";
            this.GRBH.Name = "GRBH";
            this.GRBH.ReadOnly = true;
            // 
            // XM
            // 
            this.XM.HeaderText = "姓名";
            this.XM.Name = "XM";
            this.XM.ReadOnly = true;
            // 
            // YYBH
            // 
            this.YYBH.HeaderText = "医院编号";
            this.YYBH.Name = "YYBH";
            this.YYBH.ReadOnly = true;
            // 
            // YYMC
            // 
            this.YYMC.HeaderText = "医院名称";
            this.YYMC.Name = "YYMC";
            this.YYMC.ReadOnly = true;
            // 
            // ZYJSLB
            // 
            this.ZYJSLB.HeaderText = "住院类别";
            this.ZYJSLB.Name = "ZYJSLB";
            this.ZYJSLB.ReadOnly = true;
            // 
            // JZLB
            // 
            this.JZLB.HeaderText = "就诊类别";
            this.JZLB.Name = "JZLB";
            this.JZLB.ReadOnly = true;
            // 
            // JSRQ
            // 
            this.JSRQ.HeaderText = "结算日期";
            this.JSRQ.Name = "JSRQ";
            this.JSRQ.ReadOnly = true;
            // 
            // RYRQ
            // 
            this.RYRQ.HeaderText = "入院日期";
            this.RYRQ.Name = "RYRQ";
            this.RYRQ.ReadOnly = true;
            // 
            // CYRQ
            // 
            this.CYRQ.HeaderText = "出院日期";
            this.CYRQ.Name = "CYRQ";
            this.CYRQ.ReadOnly = true;
            // 
            // CYZD
            // 
            this.CYZD.HeaderText = "出院诊断";
            this.CYZD.Name = "CYZD";
            this.CYZD.ReadOnly = true;
            // 
            // JZJLH
            // 
            this.JZJLH.HeaderText = "就诊记录号";
            this.JZJLH.Name = "JZJLH";
            this.JZJLH.ReadOnly = true;
            // 
            // SDYWH
            // 
            this.SDYWH.HeaderText = "结算序号";
            this.SDYWH.Name = "SDYWH";
            this.SDYWH.ReadOnly = true;
            // 
            // CFH
            // 
            this.CFH.HeaderText = "处方号";
            this.CFH.Name = "CFH";
            this.CFH.ReadOnly = true;
            // 
            // ZH
            // 
            this.ZH.HeaderText = "诊号";
            this.ZH.Name = "ZH";
            this.ZH.ReadOnly = true;
            // 
            // YLFYZE
            // 
            this.YLFYZE.HeaderText = "本次医疗费用";
            this.YLFYZE.Name = "YLFYZE";
            this.YLFYZE.ReadOnly = true;
            // 
            // TCZF
            // 
            this.TCZF.HeaderText = "医疗统筹支付金额";
            this.TCZF.Name = "TCZF";
            this.TCZF.ReadOnly = true;
            // 
            // GRZFZE
            // 
            this.GRZFZE.HeaderText = "个人自负总额";
            this.GRZFZE.Name = "GRZFZE";
            this.GRZFZE.ReadOnly = true;
            // 
            // KSMC
            // 
            this.KSMC.HeaderText = "科室名称";
            this.KSMC.Name = "KSMC";
            this.KSMC.ReadOnly = true;
            // 
            // YYRYKS
            // 
            this.YYRYKS.HeaderText = "医院科室";
            this.YYRYKS.Name = "YYRYKS";
            this.YYRYKS.ReadOnly = true;
            // 
            // MZYFBXJE
            // 
            this.MZYFBXJE.HeaderText = "民政优抚报销金额";
            this.MZYFBXJE.Name = "MZYFBXJE";
            this.MZYFBXJE.ReadOnly = true;
            // 
            // BCYLTCZF1
            // 
            this.BCYLTCZF1.HeaderText = "补充医疗（1）统筹支付";
            this.BCYLTCZF1.Name = "BCYLTCZF1";
            this.BCYLTCZF1.ReadOnly = true;
            // 
            // BCYLTCZF2
            // 
            this.BCYLTCZF2.HeaderText = "补充医疗（2）统筹支付";
            this.BCYLTCZF2.Name = "BCYLTCZF2";
            this.BCYLTCZF2.ReadOnly = true;
            // 
            // BCYLTCZF3
            // 
            this.BCYLTCZF3.HeaderText = "补充医疗（3）统筹支付";
            this.BCYLTCZF3.Name = "BCYLTCZF3";
            this.BCYLTCZF3.ReadOnly = true;
            // 
            // BCYLTCZF4
            // 
            this.BCYLTCZF4.HeaderText = "补充医疗（4）统筹支付";
            this.BCYLTCZF4.Name = "BCYLTCZF4";
            this.BCYLTCZF4.ReadOnly = true;
            // 
            // QTZHIFU
            // 
            this.QTZHIFU.HeaderText = "其他支付";
            this.QTZHIFU.Name = "QTZHIFU";
            this.QTZHIFU.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Controls.Add(this.cboPatientType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(844, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "退　出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(724, 25);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(82, 29);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查　询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy年MM月dd日";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(562, 27);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpEnd.TabIndex = 4;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy年MM月dd日";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(407, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(126, 23);
            this.dtpStart.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "起止时间：";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(153, 28);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(154, 23);
            this.txtCardNo.TabIndex = 1;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // cboPatientType
            // 
            this.cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientType.FormattingEnabled = true;
            this.cboPatientType.Items.AddRange(new object[] {
            "1 - 病人卡号",
            "2 - 身份证号"});
            this.cboPatientType.Location = new System.Drawing.Point(21, 29);
            this.cboPatientType.Name = "cboPatientType";
            this.cboPatientType.Size = new System.Drawing.Size(124, 22);
            this.cboPatientType.TabIndex = 0;
            // 
            // frmYBBillInfoMZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmYBBillInfoMZ";
            this.Text = "门诊结算信息查询";
            this.Load += new System.EventHandler(this.frmYBBillInfoMZ_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmYBBillInfoMZ_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.DateTimePicker dtpStart;
        internal System.Windows.Forms.ComboBox cboPatientType;
        internal System.Windows.Forms.DateTimePicker dtpEnd;
        internal System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMSFHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn XM;
        private System.Windows.Forms.DataGridViewTextBoxColumn YYBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn YYMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZYJSLB;
        private System.Windows.Forms.DataGridViewTextBoxColumn JZLB;
        private System.Windows.Forms.DataGridViewTextBoxColumn JSRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RYRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CYRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CYZD;
        private System.Windows.Forms.DataGridViewTextBoxColumn JZJLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDYWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZH;
        private System.Windows.Forms.DataGridViewTextBoxColumn YLFYZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCZF;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRZFZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn KSMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn YYRYKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MZYFBXJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCYLTCZF1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCYLTCZF2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCYLTCZF3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCYLTCZF4;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTZHIFU;
        internal System.Windows.Forms.DataGridView dgvBillDetail;
    }
}