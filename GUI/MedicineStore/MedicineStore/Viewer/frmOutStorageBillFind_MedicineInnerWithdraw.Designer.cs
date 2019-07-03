namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmOutStorageBillFind_MedicineInnerWithdraw
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutStorageBillFind_MedicineInnerWithdraw));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtLotNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmdQuit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 023.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 224.ico");
            // 
            // m_cmdFind
            // 
            this.m_cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdFind.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdFind.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdFind.Image")));
            this.m_cmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdFind.Location = new System.Drawing.Point(217, 91);
            this.m_cmdFind.Name = "m_cmdFind";
            this.m_cmdFind.Size = new System.Drawing.Size(94, 32);
            this.m_cmdFind.TabIndex = 111;
            this.m_cmdFind.Text = "查询(&A)";
            this.m_cmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdFind.UseVisualStyleBackColor = true;
            this.m_cmdFind.Click += new System.EventHandler(this.m_cmdFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtLotNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_txtMedicineName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 62);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找内容";
            // 
            // m_txtLotNo
            // 
            this.m_txtLotNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLotNo.Location = new System.Drawing.Point(392, 22);
            this.m_txtLotNo.Name = "m_txtLotNo";
            this.m_txtLotNo.Size = new System.Drawing.Size(203, 23);
            this.m_txtLotNo.TabIndex = 108;
            this.m_txtLotNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtLotNo_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 107;
            this.label7.Text = "批    号";
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineName.Location = new System.Drawing.Point(88, 22);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.Size = new System.Drawing.Size(203, 23);
            this.m_txtMedicineName.TabIndex = 104;
            this.m_txtMedicineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 105;
            this.label5.Text = "药品名称";
            // 
            // m_cmdQuit
            // 
            this.m_cmdQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdQuit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdQuit.ImageKey = "Shell32 028.ico";
            this.m_cmdQuit.ImageList = this.imageList1;
            this.m_cmdQuit.Location = new System.Drawing.Point(326, 91);
            this.m_cmdQuit.Name = "m_cmdQuit";
            this.m_cmdQuit.Size = new System.Drawing.Size(94, 32);
            this.m_cmdQuit.TabIndex = 114;
            this.m_cmdQuit.Text = " 取消(&Q)";
            this.m_cmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdQuit.UseVisualStyleBackColor = true;
            this.m_cmdQuit.Click += new System.EventHandler(this.m_cmdQuit_Click);
            // 
            // frmOutStorageBillFind_MedicineInnerWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdQuit;
            this.ClientSize = new System.Drawing.Size(637, 135);
            this.ControlBox = false;
            this.Controls.Add(this.m_cmdQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdFind);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOutStorageBillFind_MedicineInnerWithdraw";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定位";
            this.Shown += new System.EventHandler(this.frmOutStorageBillFind_MedicineInnerWithdraw_Shown);
            this.Load += new System.EventHandler(this.frmOutStorageBillFind_MedicineInnerWithdraw_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdFind;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox m_txtLotNo;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_cmdQuit;
    }
}