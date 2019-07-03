namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmDiagnoses
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
            this.m_dwDisease = new Sybase.DataWindow.DataWindowControl();
            this.m_txtFind = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdFind = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtDiagnoses = new System.Windows.Forms.TextBox();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdOk = new PinkieControls.ButtonXP();
            this.chkDiseasetype = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dwDisease
            // 
            this.m_dwDisease.DataWindowObject = "d_insurancedisease";
            this.m_dwDisease.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.m_dwDisease.Location = new System.Drawing.Point(6, 18);
            this.m_dwDisease.Name = "m_dwDisease";
            this.m_dwDisease.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwDisease.Size = new System.Drawing.Size(326, 376);
            this.m_dwDisease.TabIndex = 0;
            this.m_dwDisease.Text = "dataWindowControl1";
            this.m_dwDisease.DataWindowCreated += new Sybase.DataWindow.DataWindowCreatedEventHandler(this.m_dwDisease_DataWindowCreated);
            this.m_dwDisease.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.m_dwDisease_RowFocusChanged);
            this.m_dwDisease.DoubleClick += new System.EventHandler(this.m_dwDisease_DoubleClick);
            // 
            // m_txtFind
            // 
            this.m_txtFind.Location = new System.Drawing.Point(6, 413);
            this.m_txtFind.Name = "m_txtFind";
            this.m_txtFind.Size = new System.Drawing.Size(210, 23);
            this.m_txtFind.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdFind);
            this.groupBox1.Controls.Add(this.m_dwDisease);
            this.groupBox1.Controls.Add(this.m_txtFind);
            this.groupBox1.Location = new System.Drawing.Point(14, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 453);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "疾病字典";
            // 
            // m_cmdFind
            // 
            this.m_cmdFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdFind.DefaultScheme = true;
            this.m_cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFind.Hint = "";
            this.m_cmdFind.Location = new System.Drawing.Point(222, 412);
            this.m_cmdFind.Name = "m_cmdFind";
            this.m_cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFind.Size = new System.Drawing.Size(74, 27);
            this.m_cmdFind.TabIndex = 11;
            this.m_cmdFind.Text = "查询(&F)";
            this.m_cmdFind.Click += new System.EventHandler(this.m_cmdFind_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtDiagnoses);
            this.groupBox2.Location = new System.Drawing.Point(358, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 398);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "诊断内容";
            // 
            // m_txtDiagnoses
            // 
            this.m_txtDiagnoses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtDiagnoses.Location = new System.Drawing.Point(3, 19);
            this.m_txtDiagnoses.Multiline = true;
            this.m_txtDiagnoses.Name = "m_txtDiagnoses";
            this.m_txtDiagnoses.Size = new System.Drawing.Size(300, 376);
            this.m_txtDiagnoses.TabIndex = 3;
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(587, 412);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(74, 27);
            this.m_cmdCancel.TabIndex = 9;
            this.m_cmdCancel.Text = "取消(Esc)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOk
            // 
            this.m_cmdOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOk.DefaultScheme = true;
            this.m_cmdOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOk.Hint = "";
            this.m_cmdOk.Location = new System.Drawing.Point(507, 412);
            this.m_cmdOk.Name = "m_cmdOk";
            this.m_cmdOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOk.Size = new System.Drawing.Size(74, 27);
            this.m_cmdOk.TabIndex = 10;
            this.m_cmdOk.Text = "确定(&O)";
            this.m_cmdOk.Click += new System.EventHandler(this.m_cmdOk_Click);
            // 
            // chkDiseasetype
            // 
            this.chkDiseasetype.AutoSize = true;
            this.chkDiseasetype.Location = new System.Drawing.Point(378, 416);
            this.chkDiseasetype.Name = "chkDiseasetype";
            this.chkDiseasetype.Size = new System.Drawing.Size(110, 18);
            this.chkDiseasetype.TabIndex = 11;
            this.chkDiseasetype.Text = "是否特殊病种";
            this.chkDiseasetype.UseVisualStyleBackColor = true;
            // 
            // frmDiagnoses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 462);
            this.Controls.Add(this.chkDiseasetype);
            this.Controls.Add(this.m_cmdOk);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "frmDiagnoses";
            this.Text = "出院诊断";
            this.Load += new System.EventHandler(this.frmDiagnoses_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sybase.DataWindow.DataWindowControl m_dwDisease;
        private System.Windows.Forms.TextBox m_txtFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdOk;
        private PinkieControls.ButtonXP m_cmdFind;
        internal System.Windows.Forms.TextBox m_txtDiagnoses;
        internal System.Windows.Forms.CheckBox chkDiseasetype;
    }
}