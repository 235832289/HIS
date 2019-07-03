namespace iCare.FormUtility
{
    partial class frmInpatMedRecSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInpatMedRecSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lstForm = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_lstArea = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdSaveType = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormName = new System.Windows.Forms.TextBox();
            this.m_txtTypeID = new System.Windows.Forms.TextBox();
            this.m_lstDept = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lstForm);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "专科病历表单";
            // 
            // m_lstForm
            // 
            this.m_lstForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lstForm.FormattingEnabled = true;
            this.m_lstForm.ItemHeight = 14;
            this.m_lstForm.Location = new System.Drawing.Point(6, 22);
            this.m_lstForm.Name = "m_lstForm";
            this.m_lstForm.Size = new System.Drawing.Size(212, 256);
            this.m_lstForm.TabIndex = 0;
            this.m_lstForm.SelectedIndexChanged += new System.EventHandler(this.m_lstForm_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_lstArea);
            this.groupBox4.Location = new System.Drawing.Point(224, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 118);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "病区";
            this.groupBox4.Visible = false;
            // 
            // m_lstArea
            // 
            this.m_lstArea.CheckOnClick = true;
            this.m_lstArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstArea.FormattingEnabled = true;
            this.m_lstArea.Location = new System.Drawing.Point(3, 19);
            this.m_lstArea.Name = "m_lstArea";
            this.m_lstArea.Size = new System.Drawing.Size(258, 94);
            this.m_lstArea.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cmdDelete);
            this.groupBox2.Controls.Add(this.m_cmdSaveType);
            this.groupBox2.Controls.Add(this.m_cmdNew);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txtFormName);
            this.groupBox2.Controls.Add(this.m_txtTypeID);
            this.groupBox2.Location = new System.Drawing.Point(3, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "专科病历表单维护";
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(407, 54);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(83, 30);
            this.m_cmdDelete.TabIndex = 2;
            this.m_cmdDelete.Text = "删  除";
            this.m_cmdDelete.Visible = false;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdSaveType
            // 
            this.m_cmdSaveType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSaveType.DefaultScheme = true;
            this.m_cmdSaveType.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSaveType.Hint = "";
            this.m_cmdSaveType.Location = new System.Drawing.Point(309, 54);
            this.m_cmdSaveType.Name = "m_cmdSaveType";
            this.m_cmdSaveType.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSaveType.Size = new System.Drawing.Size(83, 30);
            this.m_cmdSaveType.TabIndex = 2;
            this.m_cmdSaveType.Text = "保  存";
            this.m_cmdSaveType.Click += new System.EventHandler(this.m_cmdSaveType_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(211, 54);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(83, 30);
            this.m_cmdNew.TabIndex = 2;
            this.m_cmdNew.Text = "新  增";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "描 述:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "表单类型:";
            // 
            // m_txtFormName
            // 
            this.m_txtFormName.Location = new System.Drawing.Point(309, 22);
            this.m_txtFormName.Name = "m_txtFormName";
            this.m_txtFormName.Size = new System.Drawing.Size(181, 23);
            this.m_txtFormName.TabIndex = 0;
            // 
            // m_txtTypeID
            // 
            this.m_txtTypeID.Location = new System.Drawing.Point(80, 22);
            this.m_txtTypeID.Name = "m_txtTypeID";
            this.m_txtTypeID.Size = new System.Drawing.Size(168, 23);
            this.m_txtTypeID.TabIndex = 0;
            // 
            // m_lstDept
            // 
            this.m_lstDept.CheckOnClick = true;
            this.m_lstDept.FormattingEnabled = true;
            this.m_lstDept.Location = new System.Drawing.Point(6, 22);
            this.m_lstDept.Name = "m_lstDept";
            this.m_lstDept.Size = new System.Drawing.Size(252, 256);
            this.m_lstDept.TabIndex = 2;
            this.m_lstDept.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_lstDept_ItemCheck);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lstDept);
            this.groupBox3.Location = new System.Drawing.Point(235, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 285);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "使用科室";
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(410, 350);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(83, 30);
            this.buttonXP1.TabIndex = 2;
            this.buttonXP1.Text = "退  出";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // frmInpatMedRecSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 398);
            this.Controls.Add(this.buttonXP1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInpatMedRecSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "专科病历表单设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInpatMedRecSetting_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox m_lstForm;
        private System.Windows.Forms.CheckedListBox m_lstDept;
        private PinkieControls.ButtonXP m_cmdDelete;
        private PinkieControls.ButtonXP m_cmdSaveType;
        private PinkieControls.ButtonXP m_cmdNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtFormName;
        private System.Windows.Forms.TextBox m_txtTypeID;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox m_lstArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private PinkieControls.ButtonXP buttonXP1;
    }
}