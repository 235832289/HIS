namespace iCare
{
    partial class frmCaseHistoryStat_CataLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistoryStat_CataLoad));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpOutDate2 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_dtpOutDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkDetailStat = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdStat = new PinkieControls.ButtonXP();
            this.m_lblCatalogCase = new System.Windows.Forms.Label();
            this.m_lblVIPCase = new System.Windows.Forms.Label();
            this.m_lblDeadCase = new System.Windows.Forms.Label();
            this.m_lblCatalogOp = new System.Windows.Forms.Label();
            this.m_lblCatalogOpType = new System.Windows.Forms.Label();
            this.m_lblNewOp = new System.Windows.Forms.Label();
            this.m_lblCatalogDiag = new System.Windows.Forms.Label();
            this.m_lblCatalogDiagType = new System.Windows.Forms.Label();
            this.m_lblCatalogMDiag = new System.Windows.Forms.Label();
            this.m_lblCatalogVDiag = new System.Windows.Forms.Label();
            this.m_lblCatalogEDiag = new System.Windows.Forms.Label();
            this.m_lblDieaseType = new System.Windows.Forms.Label();
            this.m_lblNewDiag = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkDetailStat);
            this.groupBox1.Controls.Add(this.m_dtpOutDate2);
            this.groupBox1.Controls.Add(this.m_dtpOutDate1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "统计日期";
            // 
            // m_dtpOutDate2
            // 
            this.m_dtpOutDate2.AccessibleDescription = "出院日期2";
            this.m_dtpOutDate2.BackColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOutDate2.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOutDate2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpOutDate2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOutDate2.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOutDate2.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate2.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate2.ForeColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutDate2.Location = new System.Drawing.Point(261, 27);
            this.m_dtpOutDate2.m_BlnOnlyTime = false;
            this.m_dtpOutDate2.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate2.Name = "m_dtpOutDate2";
            this.m_dtpOutDate2.ReadOnly = false;
            this.m_dtpOutDate2.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate2.TabIndex = 9;
            this.m_dtpOutDate2.Tag = "1";
            this.m_dtpOutDate2.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_dtpOutDate1
            // 
            this.m_dtpOutDate1.AccessibleDescription = "出院日期1";
            this.m_dtpOutDate1.BackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOutDate1.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOutDate1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpOutDate1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOutDate1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOutDate1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate1.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate1.ForeColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutDate1.Location = new System.Drawing.Point(107, 27);
            this.m_dtpOutDate1.m_BlnOnlyTime = false;
            this.m_dtpOutDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate1.Name = "m_dtpOutDate1";
            this.m_dtpOutDate1.ReadOnly = false;
            this.m_dtpOutDate1.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate1.TabIndex = 8;
            this.m_dtpOutDate1.Tag = "1";
            this.m_dtpOutDate1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(245, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "~";
            // 
            // m_chkDetailStat
            // 
            this.m_chkDetailStat.AutoSize = true;
            this.m_chkDetailStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkDetailStat.Location = new System.Drawing.Point(567, 29);
            this.m_chkDetailStat.Name = "m_chkDetailStat";
            this.m_chkDetailStat.Size = new System.Drawing.Size(88, 20);
            this.m_chkDetailStat.TabIndex = 11;
            this.m_chkDetailStat.Text = "详细统计";
            this.m_chkDetailStat.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lblNewOp);
            this.groupBox2.Controls.Add(this.m_lblCatalogOpType);
            this.groupBox2.Controls.Add(this.m_lblCatalogOp);
            this.groupBox2.Controls.Add(this.m_lblDeadCase);
            this.groupBox2.Controls.Add(this.m_lblVIPCase);
            this.groupBox2.Controls.Add(this.m_lblNewDiag);
            this.groupBox2.Controls.Add(this.m_lblDieaseType);
            this.groupBox2.Controls.Add(this.m_lblCatalogEDiag);
            this.groupBox2.Controls.Add(this.m_lblCatalogVDiag);
            this.groupBox2.Controls.Add(this.m_lblCatalogMDiag);
            this.groupBox2.Controls.Add(this.m_lblCatalogDiagType);
            this.groupBox2.Controls.Add(this.m_lblCatalogDiag);
            this.groupBox2.Controls.Add(this.m_lblCatalogCase);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "编目病案数:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "其中:VIP病案数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "死亡病案数:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "编目诊断总数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "编目诊断种类数:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "其中:M码种类数:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "V码种类数:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "E码种类数:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "编目手术总数:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "编目手术种类数:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "新建手术编码数:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(375, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "病症/部位码种类数:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(399, 311);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "新建疾病编码数:";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AccessibleDescription = "关闭";
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(675, 458);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClose.TabIndex = 18816;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.AccessibleDescription = "清屏";
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(597, 458);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClear.TabIndex = 18815;
            this.m_cmdClear.Text = "清屏";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdStat
            // 
            this.m_cmdStat.AccessibleDescription = "统计";
            this.m_cmdStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdStat.DefaultScheme = true;
            this.m_cmdStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdStat.Hint = "";
            this.m_cmdStat.Location = new System.Drawing.Point(519, 458);
            this.m_cmdStat.Name = "m_cmdStat";
            this.m_cmdStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdStat.Size = new System.Drawing.Size(71, 33);
            this.m_cmdStat.TabIndex = 18814;
            this.m_cmdStat.Text = "统计";
            this.m_cmdStat.Click += new System.EventHandler(this.m_cmdStat_Click);
            // 
            // m_lblCatalogCase
            // 
            this.m_lblCatalogCase.AutoSize = true;
            this.m_lblCatalogCase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogCase.Location = new System.Drawing.Point(196, 35);
            this.m_lblCatalogCase.Name = "m_lblCatalogCase";
            this.m_lblCatalogCase.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogCase.TabIndex = 1;
            this.m_lblCatalogCase.Text = "0";
            // 
            // m_lblVIPCase
            // 
            this.m_lblVIPCase.AutoSize = true;
            this.m_lblVIPCase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblVIPCase.Location = new System.Drawing.Point(196, 81);
            this.m_lblVIPCase.Name = "m_lblVIPCase";
            this.m_lblVIPCase.Size = new System.Drawing.Size(16, 16);
            this.m_lblVIPCase.TabIndex = 1;
            this.m_lblVIPCase.Text = "0";
            // 
            // m_lblDeadCase
            // 
            this.m_lblDeadCase.AutoSize = true;
            this.m_lblDeadCase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblDeadCase.Location = new System.Drawing.Point(196, 127);
            this.m_lblDeadCase.Name = "m_lblDeadCase";
            this.m_lblDeadCase.Size = new System.Drawing.Size(16, 16);
            this.m_lblDeadCase.TabIndex = 1;
            this.m_lblDeadCase.Text = "0";
            // 
            // m_lblCatalogOp
            // 
            this.m_lblCatalogOp.AutoSize = true;
            this.m_lblCatalogOp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogOp.Location = new System.Drawing.Point(196, 219);
            this.m_lblCatalogOp.Name = "m_lblCatalogOp";
            this.m_lblCatalogOp.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogOp.TabIndex = 1;
            this.m_lblCatalogOp.Text = "0";
            // 
            // m_lblCatalogOpType
            // 
            this.m_lblCatalogOpType.AutoSize = true;
            this.m_lblCatalogOpType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogOpType.Location = new System.Drawing.Point(196, 265);
            this.m_lblCatalogOpType.Name = "m_lblCatalogOpType";
            this.m_lblCatalogOpType.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogOpType.TabIndex = 1;
            this.m_lblCatalogOpType.Text = "0";
            // 
            // m_lblNewOp
            // 
            this.m_lblNewOp.AutoSize = true;
            this.m_lblNewOp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblNewOp.Location = new System.Drawing.Point(196, 313);
            this.m_lblNewOp.Name = "m_lblNewOp";
            this.m_lblNewOp.Size = new System.Drawing.Size(16, 16);
            this.m_lblNewOp.TabIndex = 1;
            this.m_lblNewOp.Text = "0";
            // 
            // m_lblCatalogDiag
            // 
            this.m_lblCatalogDiag.AutoSize = true;
            this.m_lblCatalogDiag.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogDiag.Location = new System.Drawing.Point(549, 35);
            this.m_lblCatalogDiag.Name = "m_lblCatalogDiag";
            this.m_lblCatalogDiag.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogDiag.TabIndex = 1;
            this.m_lblCatalogDiag.Text = "0";
            // 
            // m_lblCatalogDiagType
            // 
            this.m_lblCatalogDiagType.AutoSize = true;
            this.m_lblCatalogDiagType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogDiagType.Location = new System.Drawing.Point(549, 81);
            this.m_lblCatalogDiagType.Name = "m_lblCatalogDiagType";
            this.m_lblCatalogDiagType.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogDiagType.TabIndex = 1;
            this.m_lblCatalogDiagType.Text = "0";
            // 
            // m_lblCatalogMDiag
            // 
            this.m_lblCatalogMDiag.AutoSize = true;
            this.m_lblCatalogMDiag.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogMDiag.Location = new System.Drawing.Point(549, 127);
            this.m_lblCatalogMDiag.Name = "m_lblCatalogMDiag";
            this.m_lblCatalogMDiag.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogMDiag.TabIndex = 1;
            this.m_lblCatalogMDiag.Text = "0";
            // 
            // m_lblCatalogVDiag
            // 
            this.m_lblCatalogVDiag.AutoSize = true;
            this.m_lblCatalogVDiag.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogVDiag.Location = new System.Drawing.Point(549, 173);
            this.m_lblCatalogVDiag.Name = "m_lblCatalogVDiag";
            this.m_lblCatalogVDiag.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogVDiag.TabIndex = 1;
            this.m_lblCatalogVDiag.Text = "0";
            // 
            // m_lblCatalogEDiag
            // 
            this.m_lblCatalogEDiag.AutoSize = true;
            this.m_lblCatalogEDiag.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblCatalogEDiag.Location = new System.Drawing.Point(549, 219);
            this.m_lblCatalogEDiag.Name = "m_lblCatalogEDiag";
            this.m_lblCatalogEDiag.Size = new System.Drawing.Size(16, 16);
            this.m_lblCatalogEDiag.TabIndex = 1;
            this.m_lblCatalogEDiag.Text = "0";
            // 
            // m_lblDieaseType
            // 
            this.m_lblDieaseType.AutoSize = true;
            this.m_lblDieaseType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblDieaseType.Location = new System.Drawing.Point(549, 265);
            this.m_lblDieaseType.Name = "m_lblDieaseType";
            this.m_lblDieaseType.Size = new System.Drawing.Size(16, 16);
            this.m_lblDieaseType.TabIndex = 1;
            this.m_lblDieaseType.Text = "0";
            // 
            // m_lblNewDiag
            // 
            this.m_lblNewDiag.AutoSize = true;
            this.m_lblNewDiag.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblNewDiag.Location = new System.Drawing.Point(549, 313);
            this.m_lblNewDiag.Name = "m_lblNewDiag";
            this.m_lblNewDiag.Size = new System.Drawing.Size(16, 16);
            this.m_lblNewDiag.TabIndex = 1;
            this.m_lblNewDiag.Text = "0";
            // 
            // frmCaseHistoryStat_CataLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdStat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistoryStat_CataLoad";
            this.Text = "编目工作量统计";
            this.Load += new System.EventHandler(this.frmCaseHistoryStat_CataLoad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate2;
        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_chkDetailStat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label m_lblNewOp;
        private System.Windows.Forms.Label m_lblCatalogOpType;
        private System.Windows.Forms.Label m_lblCatalogOp;
        private System.Windows.Forms.Label m_lblDeadCase;
        private System.Windows.Forms.Label m_lblVIPCase;
        private System.Windows.Forms.Label m_lblNewDiag;
        private System.Windows.Forms.Label m_lblDieaseType;
        private System.Windows.Forms.Label m_lblCatalogEDiag;
        private System.Windows.Forms.Label m_lblCatalogVDiag;
        private System.Windows.Forms.Label m_lblCatalogMDiag;
        private System.Windows.Forms.Label m_lblCatalogDiagType;
        private System.Windows.Forms.Label m_lblCatalogDiag;
        private System.Windows.Forms.Label m_lblCatalogCase;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdStat;
    }
}