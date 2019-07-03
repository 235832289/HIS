namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmPackConversion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackConversion));
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtPackPrice = new System.Windows.Forms.TextBox();
            this.m_txtConversion = new System.Windows.Forms.TextBox();
            this.m_txtPackUnit = new System.Windows.Forms.TextBox();
            this.m_txtPackAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_bgwGetPrice = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Location = new System.Drawing.Point(162, 140);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.m_cmdCancel.TabIndex = 30;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.Location = new System.Drawing.Point(80, 140);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(75, 23);
            this.m_cmdOK.TabIndex = 25;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 1000;
            this.label6.Text = "(包装单位)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 1000;
            this.label5.Text = "购入单价:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 1000;
            this.label4.Text = "{0}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 1000;
            this.label3.Text = "包 装 量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1000;
            this.label2.Text = "包装单位:";
            // 
            // m_txtPackPrice
            // 
            this.m_txtPackPrice.Location = new System.Drawing.Point(80, 105);
            this.m_txtPackPrice.Name = "m_txtPackPrice";
            this.m_txtPackPrice.Size = new System.Drawing.Size(157, 23);
            this.m_txtPackPrice.TabIndex = 20;
            // 
            // m_txtConversion
            // 
            this.m_txtConversion.Location = new System.Drawing.Point(81, 72);
            this.m_txtConversion.Name = "m_txtConversion";
            this.m_txtConversion.Size = new System.Drawing.Size(120, 23);
            this.m_txtConversion.TabIndex = 15;
            // 
            // m_txtPackUnit
            // 
            this.m_txtPackUnit.Location = new System.Drawing.Point(81, 38);
            this.m_txtPackUnit.Name = "m_txtPackUnit";
            this.m_txtPackUnit.Size = new System.Drawing.Size(161, 23);
            this.m_txtPackUnit.TabIndex = 10;
            // 
            // m_txtPackAmount
            // 
            this.m_txtPackAmount.Location = new System.Drawing.Point(81, 5);
            this.m_txtPackAmount.Name = "m_txtPackAmount";
            this.m_txtPackAmount.Size = new System.Drawing.Size(161, 23);
            this.m_txtPackAmount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1000;
            this.label1.Text = "包装数量:";
            // 
            // m_bgwGetPrice
            // 
            this.m_bgwGetPrice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetPrice_DoWork);
            this.m_bgwGetPrice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetPrice_RunWorkerCompleted);
            // 
            // frmPackConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(253, 173);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtPackPrice);
            this.Controls.Add(this.m_txtConversion);
            this.Controls.Add(this.m_txtPackUnit);
            this.Controls.Add(this.m_txtPackAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPackConversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "包装数量换算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtPackAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtPackUnit;
        private System.Windows.Forms.TextBox m_txtConversion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txtPackPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_cmdOK;
        private System.Windows.Forms.Button m_cmdCancel;
        private System.ComponentModel.BackgroundWorker m_bgwGetPrice;
    }
}