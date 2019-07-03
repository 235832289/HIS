namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmTreatRecipeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreatRecipeInfo));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.Reports.GradientPanel();
            this.m_dtpEnd = new NullableDateControls.MaskDateEdit();
            this.m_dtpBegin = new NullableDateControls.MaskDateEdit();
            this.m_ctbEmpList = new com.digitalwave.controls.ctlTextBoxFind();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboMedicineName = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lsvRecipeInfo = new System.Windows.Forms.ListView();
            this.TreatTime = new System.Windows.Forms.ColumnHeader();
            this.m_lsvRecipeNo = new System.Windows.Forms.ColumnHeader();
            this.patientcardid_chr = new System.Windows.Forms.ColumnHeader();
            this.patientname = new System.Windows.Forms.ColumnHeader();
            this.invoiceno_vchr = new System.Windows.Forms.ColumnHeader();
            this.m_lsvDiagdr = new System.Windows.Forms.ColumnHeader();
            this.m_lsvDiagdept = new System.Windows.Forms.ColumnHeader();
            this.m_lsvTreatName = new System.Windows.Forms.ColumnHeader();
            this.m_lsvSendName = new System.Windows.Forms.ColumnHeader();
            this.m_lsvMedstoreName = new System.Windows.Forms.ColumnHeader();
            this.m_lsvTreatWindow = new System.Windows.Forms.ColumnHeader();
            this.m_lsvSendWin = new System.Windows.Forms.ColumnHeader();
            this.m_lsvRecipeDetailInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtCartNo = new System.Windows.Forms.TextBox();
            this.m_txtPatientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtInvoiceno = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lsvRecipeInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lsvRecipeDetailInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 587);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 4;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_txtInvoiceno);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.m_txtPatientName);
            this.gradientPanel1.Controls.Add(this.m_txtCartNo);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.m_dtpEnd);
            this.gradientPanel1.Controls.Add(this.m_dtpBegin);
            this.gradientPanel1.Controls.Add(this.m_ctbEmpList);
            this.gradientPanel1.Controls.Add(this.m_cmdClose);
            this.gradientPanel1.Controls.Add(this.m_cmdQuery);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.m_cboMedicineName);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = false;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1015, 77);
            this.gradientPanel1.TabIndex = 3;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_dtpEnd
            // 
            this.m_dtpEnd.Location = new System.Drawing.Point(621, 14);
            this.m_dtpEnd.Mask = "yyyy年MM月dd日";
            this.m_dtpEnd.Name = "m_dtpEnd";
            this.m_dtpEnd.Size = new System.Drawing.Size(121, 23);
            this.m_dtpEnd.TabIndex = 3;
            this.m_dtpEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dtpEnd_KeyPress);
            // 
            // m_dtpBegin
            // 
            this.m_dtpBegin.Location = new System.Drawing.Point(471, 14);
            this.m_dtpBegin.Mask = "yyyy年MM月dd日";
            this.m_dtpBegin.Name = "m_dtpBegin";
            this.m_dtpBegin.Size = new System.Drawing.Size(121, 23);
            this.m_dtpBegin.TabIndex = 2;
            this.m_dtpBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dtpBegin_KeyPress);
            // 
            // m_ctbEmpList
            // 
            this.m_ctbEmpList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctbEmpList.intHeight = 200;
            this.m_ctbEmpList.IsEnterShow = true;
            this.m_ctbEmpList.isHide = 2;
            this.m_ctbEmpList.isTxt = 1;
            this.m_ctbEmpList.isUpOrDn = 0;
            this.m_ctbEmpList.isValuse = 2;
            this.m_ctbEmpList.Location = new System.Drawing.Point(266, 14);
            this.m_ctbEmpList.m_IsHaveParent = false;
            this.m_ctbEmpList.m_strParentName = "";
            this.m_ctbEmpList.Name = "m_ctbEmpList";
            this.m_ctbEmpList.nextCtl = null;
            this.m_ctbEmpList.Size = new System.Drawing.Size(119, 22);
            this.m_ctbEmpList.TabIndex = 1;
            this.m_ctbEmpList.txtValuse = "";
            this.m_ctbEmpList.VsLeftOrRight = 1;
            this.m_ctbEmpList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_ctbEmpList_KeyPress);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdClose.Image")));
            this.m_cmdClose.Location = new System.Drawing.Point(882, 10);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.m_cmdClose.Size = new System.Drawing.Size(100, 31);
            this.m_cmdClose.TabIndex = 79;
            this.m_cmdClose.Text = "关 闭(&C)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdQuery.Image")));
            this.m_cmdQuery.Location = new System.Drawing.Point(769, 10);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.m_cmdQuery.Size = new System.Drawing.Size(100, 31);
            this.m_cmdQuery.TabIndex = 7;
            this.m_cmdQuery.Text = "查 询(&S)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(596, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 77;
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(407, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 73;
            this.label3.Text = "配药时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(200, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 71;
            this.label2.Text = "配药员工";
            // 
            // m_cboMedicineName
            // 
            this.m_cboMedicineName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineName.Location = new System.Drawing.Point(73, 14);
            this.m_cboMedicineName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboMedicineName.Name = "m_cboMedicineName";
            this.m_cboMedicineName.Size = new System.Drawing.Size(118, 22);
            this.m_cboMedicineName.TabIndex = 0;
            this.m_cboMedicineName.SelectedIndexChanged += new System.EventHandler(this.m_cboMedicineName_SelectedIndexChanged);
            this.m_cboMedicineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_cboMedicineName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "药房名称";
            // 
            // m_lsvRecipeInfo
            // 
            this.m_lsvRecipeInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TreatTime,
            this.patientcardid_chr,
            this.patientname,
            this.invoiceno_vchr,
            this.m_lsvRecipeNo,
            this.m_lsvDiagdr,
            this.m_lsvDiagdept,
            this.m_lsvTreatName,
            this.m_lsvSendName,
            this.m_lsvMedstoreName,
            this.m_lsvTreatWindow,
            this.m_lsvSendWin});
            this.m_lsvRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvRecipeInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvRecipeInfo.FullRowSelect = true;
            this.m_lsvRecipeInfo.GridLines = true;
            this.m_lsvRecipeInfo.Location = new System.Drawing.Point(0, 0);
            this.m_lsvRecipeInfo.MultiSelect = false;
            this.m_lsvRecipeInfo.Name = "m_lsvRecipeInfo";
            this.m_lsvRecipeInfo.Size = new System.Drawing.Size(304, 587);
            this.m_lsvRecipeInfo.TabIndex = 1;
            this.m_lsvRecipeInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvRecipeInfo.View = System.Windows.Forms.View.Details;
            this.m_lsvRecipeInfo.SelectedIndexChanged += new System.EventHandler(this.m_lsvRecipeInfo_SelectedIndexChanged);
            // 
            // TreatTime
            // 
            this.TreatTime.Text = "配药时间";
            this.TreatTime.Width = 140;
            // 
            // m_lsvRecipeNo
            // 
            this.m_lsvRecipeNo.Text = "门诊处方号";
            this.m_lsvRecipeNo.Width = 160;
            // 
            // patientcardid_chr
            // 
            this.patientcardid_chr.Text = "病人卡号";
            this.patientcardid_chr.Width = 92;
            // 
            // patientname
            // 
            this.patientname.Text = "病人姓名";
            this.patientname.Width = 80;
            // 
            // invoiceno_vchr
            // 
            this.invoiceno_vchr.Text = "处方发票号";
            this.invoiceno_vchr.Width = 96;
            // 
            // m_lsvDiagdr
            // 
            this.m_lsvDiagdr.Text = "医生";
            this.m_lsvDiagdr.Width = 90;
            // 
            // m_lsvDiagdept
            // 
            this.m_lsvDiagdept.Text = "科室";
            this.m_lsvDiagdept.Width = 80;
            // 
            // m_lsvTreatName
            // 
            this.m_lsvTreatName.Text = "配药人";
            this.m_lsvTreatName.Width = 63;
            // 
            // m_lsvSendName
            // 
            this.m_lsvSendName.Text = "发药人";
            this.m_lsvSendName.Width = 90;
            // 
            // m_lsvMedstoreName
            // 
            this.m_lsvMedstoreName.Text = "药房";
            this.m_lsvMedstoreName.Width = 83;
            // 
            // m_lsvTreatWindow
            // 
            this.m_lsvTreatWindow.Text = "配药窗口";
            this.m_lsvTreatWindow.Width = 80;
            // 
            // m_lsvSendWin
            // 
            this.m_lsvSendWin.Text = "发药窗口";
            this.m_lsvSendWin.Width = 80;
            // 
            // m_lsvRecipeDetailInfo
            // 
            this.m_lsvRecipeDetailInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.m_lsvRecipeDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvRecipeDetailInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvRecipeDetailInfo.FullRowSelect = true;
            this.m_lsvRecipeDetailInfo.GridLines = true;
            this.m_lsvRecipeDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.m_lsvRecipeDetailInfo.Name = "m_lsvRecipeDetailInfo";
            this.m_lsvRecipeDetailInfo.Size = new System.Drawing.Size(707, 587);
            this.m_lsvRecipeDetailInfo.TabIndex = 1;
            this.m_lsvRecipeDetailInfo.TileSize = new System.Drawing.Size(148, 36);
            this.m_lsvRecipeDetailInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvRecipeDetailInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目名称";
            this.columnHeader1.Width = 184;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目规格";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "剂量";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单位";
            this.columnHeader4.Width = 55;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "用法";
            this.columnHeader5.Width = 93;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "频率";
            this.columnHeader6.Width = 55;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "天数";
            this.columnHeader7.Width = 53;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "总数";
            this.columnHeader8.Width = 59;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "单位";
            this.columnHeader9.Width = 53;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "单价";
            this.columnHeader10.Width = 55;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "金额";
            this.columnHeader11.Width = 70;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "编码";
            this.columnHeader12.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "生产厂家";
            this.columnHeader13.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 80;
            this.label5.Text = "诊疗卡号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(200, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 81;
            this.label6.Text = "病人姓名";
            // 
            // m_txtCartNo
            // 
            this.m_txtCartNo.Location = new System.Drawing.Point(73, 45);
            this.m_txtCartNo.Name = "m_txtCartNo";
            this.m_txtCartNo.Size = new System.Drawing.Size(118, 23);
            this.m_txtCartNo.TabIndex = 4;
            this.m_txtCartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCartNo_KeyDown);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(266, 45);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.Size = new System.Drawing.Size(119, 23);
            this.m_txtPatientName.TabIndex = 5;
            this.m_txtPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatientName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(407, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 85;
            this.label7.Text = "发 票 号";
            // 
            // m_txtInvoiceno
            // 
            this.m_txtInvoiceno.Location = new System.Drawing.Point(471, 45);
            this.m_txtInvoiceno.Name = "m_txtInvoiceno";
            this.m_txtInvoiceno.Size = new System.Drawing.Size(271, 23);
            this.m_txtInvoiceno.TabIndex = 6;
            this.m_txtInvoiceno.Leave += new System.EventHandler(this.m_txtInvoiceno_Leave);
            this.m_txtInvoiceno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dtpBegin_KeyPress);
            // 
            // frmTreatRecipeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 664);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTreatRecipeInfo";
            this.Text = "已配药处方查询";
            this.Load += new System.EventHandler(this.frmTreatRecipeInfo_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private com.digitalwave.iCare.gui.HIS.Reports.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        internal exComboBox m_cboMedicineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal com.digitalwave.controls.ctlTextBoxFind m_ctbEmpList;
        internal NullableDateControls.MaskDateEdit m_dtpBegin;
        internal NullableDateControls.MaskDateEdit m_dtpEnd;
        internal System.Windows.Forms.ListView m_lsvRecipeInfo;
        private System.Windows.Forms.ColumnHeader TreatTime;
        private System.Windows.Forms.ColumnHeader m_lsvRecipeNo;
        private System.Windows.Forms.ColumnHeader patientcardid_chr;
        private System.Windows.Forms.ColumnHeader patientname;
        private System.Windows.Forms.ColumnHeader invoiceno_vchr;
        private System.Windows.Forms.ColumnHeader m_lsvDiagdr;
        private System.Windows.Forms.ColumnHeader m_lsvDiagdept;
        private System.Windows.Forms.ColumnHeader m_lsvTreatName;
        private System.Windows.Forms.ColumnHeader m_lsvSendName;
        private System.Windows.Forms.ColumnHeader m_lsvMedstoreName;
        private System.Windows.Forms.ColumnHeader m_lsvTreatWindow;
        private System.Windows.Forms.ColumnHeader m_lsvSendWin;
        internal System.Windows.Forms.ListView m_lsvRecipeDetailInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox m_txtPatientName;
        internal System.Windows.Forms.TextBox m_txtCartNo;
        private System.Windows.Forms.Label label7;
        internal PinkieControls.ButtonXP m_cmdQuery;
        internal System.Windows.Forms.TextBox m_txtInvoiceno;





    }
}