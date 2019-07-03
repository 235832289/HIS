namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBSpecialTypeDisease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYBSpecialTypeDisease));
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lvw = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new PinkieControls.ButtonXP();
            this.btnRefresh = new PinkieControls.ButtonXP();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.cboContent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_tbSortNO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnStopUse = new PinkieControls.ButtonXP();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.m_tbComment = new System.Windows.Forms.TextBox();
            this.m_tbYearMoney = new System.Windows.Forms.TextBox();
            this.m_tbDiseName = new System.Windows.Forms.TextBox();
            this.m_tbDiseCode = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lvw);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 509);
            this.panel2.TabIndex = 9;
            // 
            // m_lvw
            // 
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader1});
            this.m_lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvw.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(0, 96);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(478, 413);
            this.m_lvw.TabIndex = 9;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = " 疾病代码";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "疾病名称";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "年度限额";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "排序号";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "备注";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.cboCondition);
            this.panel3.Controls.Add(this.cboContent);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 96);
            this.panel3.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSearch.DefaultScheme = true;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.Hint = "";
            this.btnSearch.Location = new System.Drawing.Point(220, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSearch.Size = new System.Drawing.Size(112, 32);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查找(&F)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnRefresh.DefaultScheme = true;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Hint = "";
            this.btnRefresh.Location = new System.Drawing.Point(344, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRefresh.Size = new System.Drawing.Size(113, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新(&P)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboCondition
            // 
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "疾病代码",
            "疾病名称",
            "年度限额"});
            this.cboCondition.Location = new System.Drawing.Point(84, 17);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(121, 22);
            this.cboCondition.TabIndex = 9;
            // 
            // cboContent
            // 
            this.cboContent.Location = new System.Drawing.Point(84, 50);
            this.cboContent.MaxLength = 4;
            this.cboContent.Name = "cboContent";
            this.cboContent.Size = new System.Drawing.Size(121, 23);
            this.cboContent.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "查找内容：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "查找条件：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_tbSortNO);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.m_btnStopUse);
            this.panel1.Controls.Add(this.m_btnDel);
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnNew);
            this.panel1.Controls.Add(this.m_tbComment);
            this.panel1.Controls.Add(this.m_tbYearMoney);
            this.panel1.Controls.Add(this.m_tbDiseName);
            this.panel1.Controls.Add(this.m_tbDiseCode);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 509);
            this.panel1.TabIndex = 8;
            // 
            // m_tbSortNO
            // 
            this.m_tbSortNO.Location = new System.Drawing.Point(126, 151);
            this.m_tbSortNO.Name = "m_tbSortNO";
            this.m_tbSortNO.Size = new System.Drawing.Size(124, 23);
            this.m_tbSortNO.TabIndex = 8;
            this.m_tbSortNO.TextChanged += new System.EventHandler(this.m_tbSortNO_TextChanged);
            this.m_tbSortNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbDiseCode_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "排 序 号：";
            // 
            // m_btnStopUse
            // 
            this.m_btnStopUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStopUse.DefaultScheme = true;
            this.m_btnStopUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStopUse.Hint = "";
            this.m_btnStopUse.Location = new System.Drawing.Point(101, 373);
            this.m_btnStopUse.Name = "m_btnStopUse";
            this.m_btnStopUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStopUse.Size = new System.Drawing.Size(128, 32);
            this.m_btnStopUse.TabIndex = 12;
            this.m_btnStopUse.Text = "停用(&T)";
            this.m_btnStopUse.Click += new System.EventHandler(this.m_btnStopUse_Click);
            // 
            // m_btnDel
            // 
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(101, 413);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(128, 32);
            this.m_btnDel.TabIndex = 13;
            this.m_btnDel.Text = "删除(&D)";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(101, 451);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(128, 32);
            this.m_btnExit.TabIndex = 14;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(101, 333);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(128, 32);
            this.m_btnSave.TabIndex = 11;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(101, 293);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(128, 32);
            this.m_btnNew.TabIndex = 0;
            this.m_btnNew.Text = "新增(&A)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            this.m_btnNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_btnNew_KeyDown);
            // 
            // m_tbComment
            // 
            this.m_tbComment.Location = new System.Drawing.Point(126, 242);
            this.m_tbComment.Name = "m_tbComment";
            this.m_tbComment.Size = new System.Drawing.Size(124, 23);
            this.m_tbComment.TabIndex = 10;
            this.m_tbComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbDiseCode_KeyDown);
            // 
            // m_tbYearMoney
            // 
            this.m_tbYearMoney.Location = new System.Drawing.Point(126, 196);
            this.m_tbYearMoney.Name = "m_tbYearMoney";
            this.m_tbYearMoney.Size = new System.Drawing.Size(124, 23);
            this.m_tbYearMoney.TabIndex = 9;
            this.m_tbYearMoney.TextChanged += new System.EventHandler(this.m_tbYearMoney_TextChanged);
            this.m_tbYearMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbYearMoney_KeyDown);
            // 
            // m_tbDiseName
            // 
            this.m_tbDiseName.Location = new System.Drawing.Point(126, 108);
            this.m_tbDiseName.Name = "m_tbDiseName";
            this.m_tbDiseName.Size = new System.Drawing.Size(124, 23);
            this.m_tbDiseName.TabIndex = 7;
            this.m_tbDiseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbDiseName_KeyDown);
            // 
            // m_tbDiseCode
            // 
            this.m_tbDiseCode.Location = new System.Drawing.Point(126, 64);
            this.m_tbDiseCode.MaxLength = 4;
            this.m_tbDiseCode.Name = "m_tbDiseCode";
            this.m_tbDiseCode.Size = new System.Drawing.Size(124, 23);
            this.m_tbDiseCode.TabIndex = 6;
            this.m_tbDiseCode.TextChanged += new System.EventHandler(this.m_tbDiseCode_TextChanged);
            this.m_tbDiseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tbDiseCode_KeyDown);
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(123, 27);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(81, 14);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "              ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "备    注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "年度限额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "疾病名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "疾病代码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "状    态：";
            // 
            // frmYBSpecialTypeDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmYBSpecialTypeDisease";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保特种病维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmYBSpecialTypeDisease_KeyDown);
            this.Load += new System.EventHandler(this.frmYBSpecialTypeDisease_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal PinkieControls.ButtonXP m_btnStopUse;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblState;
        internal System.Windows.Forms.TextBox m_tbComment;
        internal System.Windows.Forms.TextBox m_tbYearMoney;
        internal System.Windows.Forms.TextBox m_tbDiseName;
        internal System.Windows.Forms.TextBox m_tbDiseCode;
        internal PinkieControls.ButtonXP m_btnDel;
        internal PinkieControls.ButtonXP m_btnExit;
        internal PinkieControls.ButtonXP m_btnSave;
        internal PinkieControls.ButtonXP m_btnNew;
        internal System.Windows.Forms.TextBox m_tbSortNO;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ListView m_lvw;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel3;
        internal PinkieControls.ButtonXP btnSearch;
        internal PinkieControls.ButtonXP btnRefresh;
        private System.Windows.Forms.ComboBox cboCondition;
        internal System.Windows.Forms.TextBox cboContent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;


    }
}