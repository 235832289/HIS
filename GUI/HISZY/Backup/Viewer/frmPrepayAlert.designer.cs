namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrepayAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrepayAlert));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtPayType = new System.Windows.Forms.TextBox();
            this.m_txtPrepay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdReSet = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.m_txtPayType);
            this.groupBox1.Controls.Add(this.m_txtPrepay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 99);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // m_txtPayType
            // 
            this.m_txtPayType.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtPayType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPayType.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPayType.ForeColor = System.Drawing.Color.Red;
            this.m_txtPayType.Location = new System.Drawing.Point(81, 23);
            this.m_txtPayType.Name = "m_txtPayType";
            this.m_txtPayType.ReadOnly = true;
            this.m_txtPayType.Size = new System.Drawing.Size(189, 23);
            this.m_txtPayType.TabIndex = 5;
            // 
            // m_txtPrepay
            // 
            this.m_txtPrepay.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtPrepay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPrepay.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrepay.ForeColor = System.Drawing.Color.Red;
            this.m_txtPrepay.Location = new System.Drawing.Point(81, 60);
            this.m_txtPrepay.Name = "m_txtPrepay";
            this.m_txtPrepay.ReadOnly = true;
            this.m_txtPrepay.Size = new System.Drawing.Size(193, 23);
            this.m_txtPrepay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "预 交 金:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "支付类型:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(63, 109);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(79, 35);
            this.m_cmdOK.TabIndex = 6;
            this.m_cmdOK.Text = "确定(&S)";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdReSet
            // 
            this.m_cmdReSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.m_cmdReSet.DefaultScheme = true;
            this.m_cmdReSet.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReSet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReSet.Hint = "";
            this.m_cmdReSet.Location = new System.Drawing.Point(160, 109);
            this.m_cmdReSet.Name = "m_cmdReSet";
            this.m_cmdReSet.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReSet.Size = new System.Drawing.Size(79, 35);
            this.m_cmdReSet.TabIndex = 7;
            this.m_cmdReSet.Text = "取消(Esc)";
            this.m_cmdReSet.Click += new System.EventHandler(this.m_cmdReSet_Click);
            // 
            // frmPrepayAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(290, 147);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdReSet);
            this.Controls.Add(this.m_cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrepayAlert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预交金提示";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrepayAlert_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txtPrepay;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP m_cmdOK;
        internal PinkieControls.ButtonXP m_cmdReSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtPayType;
    }
}