namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmSelectBox
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblDec = new System.Windows.Forms.Label();
            this.m_lblMoney3 = new System.Windows.Forms.Label();
            this.m_lblMoney2 = new System.Windows.Forms.Label();
            this.m_lblMoney4 = new System.Windows.Forms.Label();
            this.m_lblBackReasion = new System.Windows.Forms.Label();
            this.m_txtLIMITRATE_MNY = new System.Windows.Forms.TextBox();
            this.m_lblMoney1 = new System.Windows.Forms.Label();
            this.m_lblName = new System.Windows.Forms.Label();
            this.m_dtSelectTime = new System.Windows.Forms.DateTimePicker();
            this.cmdSaveBihRegister = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblNewOrderMoney = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.m_lblNewOrderMoney);
            this.groupBox1.Controls.Add(this.m_lblDec);
            this.groupBox1.Controls.Add(this.m_lblMoney3);
            this.groupBox1.Controls.Add(this.m_lblMoney2);
            this.groupBox1.Controls.Add(this.m_lblMoney4);
            this.groupBox1.Controls.Add(this.m_lblBackReasion);
            this.groupBox1.Controls.Add(this.m_txtLIMITRATE_MNY);
            this.groupBox1.Controls.Add(this.m_lblMoney1);
            this.groupBox1.Controls.Add(this.m_lblName);
            this.groupBox1.Controls.Add(this.m_dtSelectTime);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_lblDec
            // 
            this.m_lblDec.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblDec.ForeColor = System.Drawing.Color.Red;
            this.m_lblDec.Location = new System.Drawing.Point(38, 123);
            this.m_lblDec.Name = "m_lblDec";
            this.m_lblDec.Size = new System.Drawing.Size(285, 33);
            this.m_lblDec.TabIndex = 115;
            this.m_lblDec.Text = "备    注 :";
            this.m_lblDec.Visible = false;
            // 
            // m_lblMoney3
            // 
            this.m_lblMoney3.AutoSize = true;
            this.m_lblMoney3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMoney3.ForeColor = System.Drawing.Color.Red;
            this.m_lblMoney3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_lblMoney3.Location = new System.Drawing.Point(38, 71);
            this.m_lblMoney3.Name = "m_lblMoney3";
            this.m_lblMoney3.Size = new System.Drawing.Size(83, 14);
            this.m_lblMoney3.TabIndex = 113;
            this.m_lblMoney3.Text = "已结金额 :";
            this.m_lblMoney3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblMoney3.Visible = false;
            // 
            // m_lblMoney2
            // 
            this.m_lblMoney2.AutoSize = true;
            this.m_lblMoney2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMoney2.ForeColor = System.Drawing.Color.Red;
            this.m_lblMoney2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_lblMoney2.Location = new System.Drawing.Point(38, 44);
            this.m_lblMoney2.Name = "m_lblMoney2";
            this.m_lblMoney2.Size = new System.Drawing.Size(83, 14);
            this.m_lblMoney2.TabIndex = 112;
            this.m_lblMoney2.Text = "已用金额 :";
            this.m_lblMoney2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblMoney2.Visible = false;
            // 
            // m_lblMoney4
            // 
            this.m_lblMoney4.AutoSize = true;
            this.m_lblMoney4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMoney4.ForeColor = System.Drawing.Color.Red;
            this.m_lblMoney4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_lblMoney4.Location = new System.Drawing.Point(38, 99);
            this.m_lblMoney4.Name = "m_lblMoney4";
            this.m_lblMoney4.Size = new System.Drawing.Size(83, 14);
            this.m_lblMoney4.TabIndex = 110;
            this.m_lblMoney4.Text = "结余余额 :";
            this.m_lblMoney4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblMoney4.Visible = false;
            // 
            // m_lblBackReasion
            // 
            this.m_lblBackReasion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBackReasion.ForeColor = System.Drawing.Color.Red;
            this.m_lblBackReasion.Location = new System.Drawing.Point(26, 46);
            this.m_lblBackReasion.Name = "m_lblBackReasion";
            this.m_lblBackReasion.Size = new System.Drawing.Size(288, 91);
            this.m_lblBackReasion.TabIndex = 116;
            this.m_lblBackReasion.Text = "退回原因:";
            this.m_lblBackReasion.Visible = false;
            // 
            // m_txtLIMITRATE_MNY
            // 
            this.m_txtLIMITRATE_MNY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtLIMITRATE_MNY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLIMITRATE_MNY.ForeColor = System.Drawing.Color.Red;
            this.m_txtLIMITRATE_MNY.Location = new System.Drawing.Point(57, 83);
            this.m_txtLIMITRATE_MNY.MaxLength = 10;
            this.m_txtLIMITRATE_MNY.Name = "m_txtLIMITRATE_MNY";
            this.m_txtLIMITRATE_MNY.Size = new System.Drawing.Size(168, 23);
            this.m_txtLIMITRATE_MNY.TabIndex = 114;
            this.m_txtLIMITRATE_MNY.Visible = false;
            this.m_txtLIMITRATE_MNY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtLIMITRATE_MNY_KeyPress);
            this.m_txtLIMITRATE_MNY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtLIMITRATE_MNY_KeyDown);
            // 
            // m_lblMoney1
            // 
            this.m_lblMoney1.AutoSize = true;
            this.m_lblMoney1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMoney1.ForeColor = System.Drawing.Color.Red;
            this.m_lblMoney1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_lblMoney1.Location = new System.Drawing.Point(38, 19);
            this.m_lblMoney1.Name = "m_lblMoney1";
            this.m_lblMoney1.Size = new System.Drawing.Size(83, 14);
            this.m_lblMoney1.TabIndex = 111;
            this.m_lblMoney1.Text = "预交金额 :";
            this.m_lblMoney1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblMoney1.Visible = false;
            // 
            // m_lblName
            // 
            this.m_lblName.AutoSize = true;
            this.m_lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblName.ForeColor = System.Drawing.Color.Red;
            this.m_lblName.Location = new System.Drawing.Point(92, 45);
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(62, 16);
            this.m_lblName.TabIndex = 109;
            this.m_lblName.Text = "label1";
            this.m_lblName.Visible = false;
            // 
            // m_dtSelectTime
            // 
            this.m_dtSelectTime.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.m_dtSelectTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtSelectTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtSelectTime.Location = new System.Drawing.Point(56, 82);
            this.m_dtSelectTime.Name = "m_dtSelectTime";
            this.m_dtSelectTime.Size = new System.Drawing.Size(207, 26);
            this.m_dtSelectTime.TabIndex = 108;
            this.m_dtSelectTime.TabStop = false;
            this.m_dtSelectTime.Visible = false;
            // 
            // cmdSaveBihRegister
            // 
            this.cmdSaveBihRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSaveBihRegister.DefaultScheme = true;
            this.cmdSaveBihRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSaveBihRegister.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdSaveBihRegister.Hint = "";
            this.cmdSaveBihRegister.Location = new System.Drawing.Point(23, 0);
            this.cmdSaveBihRegister.Name = "cmdSaveBihRegister";
            this.cmdSaveBihRegister.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSaveBihRegister.Size = new System.Drawing.Size(85, 33);
            this.cmdSaveBihRegister.TabIndex = 3;
            this.cmdSaveBihRegister.Text = "确定(&S)";
            this.cmdSaveBihRegister.Click += new System.EventHandler(this.cmdSaveBihRegister_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(144, 0);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(85, 33);
            this.buttonXP1.TabIndex = 4;
            this.buttonXP1.Text = "取消(Esc)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSaveBihRegister);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Location = new System.Drawing.Point(43, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 33);
            this.panel1.TabIndex = 2;
            // 
            // m_lblNewOrderMoney
            // 
            this.m_lblNewOrderMoney.AutoSize = true;
            this.m_lblNewOrderMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblNewOrderMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblNewOrderMoney.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_lblNewOrderMoney.Location = new System.Drawing.Point(38, 82);
            this.m_lblNewOrderMoney.Name = "m_lblNewOrderMoney";
            this.m_lblNewOrderMoney.Size = new System.Drawing.Size(113, 14);
            this.m_lblNewOrderMoney.TabIndex = 117;
            this.m_lblNewOrderMoney.Text = "新开医嘱合计 :";
            this.m_lblNewOrderMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lblNewOrderMoney.Visible = false;
            // 
            // frmSelectBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(338, 208);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DotorComfirmBox_KeyDown);
            this.Load += new System.EventHandler(this.frmSelectBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal PinkieControls.ButtonXP cmdSaveBihRegister;
        internal PinkieControls.ButtonXP buttonXP1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblName;
        private System.Windows.Forms.DateTimePicker m_dtSelectTime;
        private System.Windows.Forms.Label m_lblMoney3;
        private System.Windows.Forms.Label m_lblMoney2;
        private System.Windows.Forms.Label m_lblMoney1;
        private System.Windows.Forms.Label m_lblMoney4;
        private System.Windows.Forms.TextBox m_txtLIMITRATE_MNY;
        private System.Windows.Forms.Label m_lblDec;
        private System.Windows.Forms.Label m_lblBackReasion;
        internal System.Windows.Forms.Label m_lblNewOrderMoney;
    }
}