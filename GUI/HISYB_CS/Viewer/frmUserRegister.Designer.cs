namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmUserRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lsvDetail = new System.Windows.Forms.ListView();
            this.colYYBH = new System.Windows.Forms.ColumnHeader();
            this.colJBR = new System.Windows.Forms.ColumnHeader();
            this.colJBRLX = new System.Windows.Forms.ColumnHeader();
            this.colXM = new System.Windows.Forms.ColumnHeader();
            this.colGMSFHM = new System.Windows.Forms.ColumnHeader();
            this.colSSKS = new System.Windows.Forms.ColumnHeader();
            this.colBGLX = new System.Windows.Forms.ColumnHeader();
            this.colJLSJ = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panjm = new System.Windows.Forms.Panel();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.txtJbr = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtIdcard = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHospitalNO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_UserType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdExit = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnRefresh = new PinkieControls.ButtonXP();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panjm.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "医院经办人注册";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(162)))), ((int)(((byte)(247)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 32);
            this.panel2.TabIndex = 6;
            // 
            // m_lsvDetail
            // 
            this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colYYBH,
            this.colJBR,
            this.colJBRLX,
            this.colXM,
            this.colGMSFHM,
            this.colSSKS,
            this.colBGLX,
            this.colJLSJ});
            this.m_lsvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvDetail.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lsvDetail.FullRowSelect = true;
            this.m_lsvDetail.GridLines = true;
            this.m_lsvDetail.HideSelection = false;
            this.m_lsvDetail.Location = new System.Drawing.Point(0, 0);
            this.m_lsvDetail.MultiSelect = false;
            this.m_lsvDetail.Name = "m_lsvDetail";
            this.m_lsvDetail.Size = new System.Drawing.Size(619, 429);
            this.m_lsvDetail.TabIndex = 4;
            this.m_lsvDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvDetail.SelectedIndexChanged += new System.EventHandler(this.m_lsvDetail_SelectedIndexChanged);
            // 
            // colYYBH
            // 
            this.colYYBH.Text = "医院编号";
            this.colYYBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colYYBH.Width = 0;
            // 
            // colJBR
            // 
            this.colJBR.Text = "员工号";
            // 
            // colJBRLX
            // 
            this.colJBRLX.Text = "经办人类型";
            this.colJBRLX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colJBRLX.Width = 116;
            // 
            // colXM
            // 
            this.colXM.Text = "姓名";
            this.colXM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colXM.Width = 130;
            // 
            // colGMSFHM
            // 
            this.colGMSFHM.Text = "公民身份号码";
            this.colGMSFHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colGMSFHM.Width = 180;
            // 
            // colSSKS
            // 
            this.colSSKS.Text = "所属科室";
            this.colSSKS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSSKS.Width = 100;
            // 
            // colBGLX
            // 
            this.colBGLX.Text = "变更类型";
            this.colBGLX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBGLX.Width = 0;
            // 
            // colJLSJ
            // 
            this.colJLSJ.Text = "记录时间";
            this.colJLSJ.Width = 180;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(940, 32);
            this.panel3.TabIndex = 36;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panjm);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(619, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 429);
            this.panel5.TabIndex = 36;
            // 
            // panjm
            // 
            this.panjm.BackColor = System.Drawing.Color.White;
            this.panjm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panjm.Controls.Add(this.btnRefresh);
            this.panjm.Controls.Add(this.btnAdd);
            this.panjm.Controls.Add(this.txtJbr);
            this.panjm.Controls.Add(this.txtDeptName);
            this.panjm.Controls.Add(this.txtIdcard);
            this.panjm.Controls.Add(this.txtName);
            this.panjm.Controls.Add(this.txtHospitalNO);
            this.panjm.Controls.Add(this.label7);
            this.panjm.Controls.Add(this.label6);
            this.panjm.Controls.Add(this.cmb_UserType);
            this.panjm.Controls.Add(this.label5);
            this.panjm.Controls.Add(this.label4);
            this.panjm.Controls.Add(this.label3);
            this.panjm.Controls.Add(this.cmdExit);
            this.panjm.Controls.Add(this.btnOK);
            this.panjm.Controls.Add(this.label2);
            this.panjm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panjm.Location = new System.Drawing.Point(0, 0);
            this.panjm.Name = "panjm";
            this.panjm.Size = new System.Drawing.Size(321, 429);
            this.panjm.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(66, 308);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAdd.Size = new System.Drawing.Size(88, 32);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtJbr
            // 
            this.txtJbr.Location = new System.Drawing.Point(148, 207);
            this.txtJbr.Name = "txtJbr";
            this.txtJbr.Size = new System.Drawing.Size(129, 21);
            this.txtJbr.TabIndex = 34;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(148, 163);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(129, 21);
            this.txtDeptName.TabIndex = 33;
            // 
            // txtIdcard
            // 
            this.txtIdcard.Location = new System.Drawing.Point(148, 119);
            this.txtIdcard.Name = "txtIdcard";
            this.txtIdcard.Size = new System.Drawing.Size(129, 21);
            this.txtIdcard.TabIndex = 32;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(129, 21);
            this.txtName.TabIndex = 31;
            // 
            // txtHospitalNO
            // 
            this.txtHospitalNO.Enabled = false;
            this.txtHospitalNO.Location = new System.Drawing.Point(148, 31);
            this.txtHospitalNO.Name = "txtHospitalNO";
            this.txtHospitalNO.Size = new System.Drawing.Size(129, 21);
            this.txtHospitalNO.TabIndex = 30;
            this.txtHospitalNO.Text = "111014";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(59, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "所属科室:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(59, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "身份号码:";
            // 
            // cmb_UserType
            // 
            this.cmb_UserType.AutoCompleteCustomSource.AddRange(new string[] {
            "门诊部",
            "住院部"});
            this.cmb_UserType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_UserType.FormattingEnabled = true;
            this.cmb_UserType.Items.AddRange(new object[] {
            "1-普通经办人",
            "2-门诊收费员",
            "3-自助终端"});
            this.cmb_UserType.Location = new System.Drawing.Point(148, 251);
            this.cmb_UserType.Name = "cmb_UserType";
            this.cmb_UserType.Size = new System.Drawing.Size(129, 22);
            this.cmb_UserType.TabIndex = 27;
            this.cmb_UserType.Text = "1-普通经办人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(59, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "姓    名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(45, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "经办人类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "经 办 人:";
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(174, 357);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(88, 32);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "退出";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(174, 308);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(59, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "医院编号:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_lsvDetail);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(940, 429);
            this.panel6.TabIndex = 38;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DefaultScheme = true;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Hint = "";
            this.btnRefresh.Location = new System.Drawing.Point(66, 357);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRefresh.Size = new System.Drawing.Size(88, 32);
            this.btnRefresh.TabIndex = 36;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmUserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 461);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUserRegister_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panjm.ResumeLayout(false);
            this.panjm.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ListView m_lsvDetail;
        private System.Windows.Forms.ColumnHeader colYYBH;
        private System.Windows.Forms.ColumnHeader colJBR;
        private System.Windows.Forms.ColumnHeader colJBRLX;
        private System.Windows.Forms.ColumnHeader colXM;
        private System.Windows.Forms.ColumnHeader colGMSFHM;
        private System.Windows.Forms.ColumnHeader colSSKS;
        private System.Windows.Forms.ColumnHeader colBGLX;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ColumnHeader colJLSJ;
        internal System.Windows.Forms.Panel panjm;
        internal PinkieControls.ButtonXP btnAdd;
        internal System.Windows.Forms.TextBox txtJbr;
        internal System.Windows.Forms.TextBox txtDeptName;
        internal System.Windows.Forms.TextBox txtIdcard;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtHospitalNO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmb_UserType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP cmdExit;
        internal PinkieControls.ButtonXP btnOK;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP btnRefresh;
    }
}