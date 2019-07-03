namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_lblContent = new System.Windows.Forms.Label();
            this.m_btnView = new System.Windows.Forms.Button();
            this.m_btnYes = new System.Windows.Forms.Button();
            this.m_btnNo = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_lblContent
            // 
            this.m_lblContent.AutoSize = true;
            this.m_lblContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblContent.Location = new System.Drawing.Point(63, 46);
            this.m_lblContent.Name = "m_lblContent";
            this.m_lblContent.Size = new System.Drawing.Size(245, 12);
            this.m_lblContent.TabIndex = 1;
            this.m_lblContent.Text = "是否把此删除（修改）应用到所有收费项目？";
            // 
            // m_btnView
            // 
            this.m_btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnView.Location = new System.Drawing.Point(181, 74);
            this.m_btnView.Name = "m_btnView";
            this.m_btnView.Size = new System.Drawing.Size(55, 23);
            this.m_btnView.TabIndex = 2;
            this.m_btnView.Text = "查看(&L)";
            this.m_btnView.UseVisualStyleBackColor = true;
            this.m_btnView.Click += new System.EventHandler(this.m_btnView_Click);
            // 
            // m_btnYes
            // 
            this.m_btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnYes.Location = new System.Drawing.Point(55, 74);
            this.m_btnYes.Name = "m_btnYes";
            this.m_btnYes.Size = new System.Drawing.Size(55, 23);
            this.m_btnYes.TabIndex = 0;
            this.m_btnYes.Text = "是(&Y)";
            this.m_btnYes.UseVisualStyleBackColor = true;
            this.m_btnYes.Click += new System.EventHandler(this.m_btnYes_Click);
            // 
            // m_btnNo
            // 
            this.m_btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnNo.Location = new System.Drawing.Point(118, 74);
            this.m_btnNo.Name = "m_btnNo";
            this.m_btnNo.Size = new System.Drawing.Size(55, 23);
            this.m_btnNo.TabIndex = 1;
            this.m_btnNo.Text = "否(&N)";
            this.m_btnNo.UseVisualStyleBackColor = true;
            this.m_btnNo.Click += new System.EventHandler(this.m_btnNo_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(321, 18);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(244, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消(&E)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(313, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.m_btnNo);
            this.Controls.Add(this.m_btnYes);
            this.Controls.Add(this.m_btnView);
            this.Controls.Add(this.m_lblContent);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "确认窗体";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmError_KeyDown);
            this.Load += new System.EventHandler(this.frmError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button m_btnView;
        private System.Windows.Forms.Button m_btnYes;
        private System.Windows.Forms.Button m_btnNo;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label m_lblContent;
        private System.Windows.Forms.Button button1;
    }
}