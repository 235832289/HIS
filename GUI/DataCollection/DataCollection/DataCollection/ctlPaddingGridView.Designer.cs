namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class ctlPaddingGridView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblPadding = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboPadding = new System.Windows.Forms.ComboBox();
            this.m_btnLast = new System.Windows.Forms.Button();
            this.m_btnNext = new System.Windows.Forms.Button();
            this.m_btnPrevious = new System.Windows.Forms.Button();
            this.m_btnFirst = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblPadding);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cboPadding);
            this.panel1.Controls.Add(this.m_btnLast);
            this.panel1.Controls.Add(this.m_btnNext);
            this.panel1.Controls.Add(this.m_btnPrevious);
            this.panel1.Controls.Add(this.m_btnFirst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 30);
            this.panel1.TabIndex = 0;
            // 
            // m_lblPadding
            // 
            this.m_lblPadding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPadding.AutoSize = true;
            this.m_lblPadding.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPadding.Location = new System.Drawing.Point(698, 9);
            this.m_lblPadding.Name = "m_lblPadding";
            this.m_lblPadding.Size = new System.Drawing.Size(70, 14);
            this.m_lblPadding.TabIndex = 7;
            this.m_lblPadding.Text = "/ 共 0 页";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(678, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "页";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(550, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "跳转到第";
            // 
            // m_cboPadding
            // 
            this.m_cboPadding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cboPadding.FormattingEnabled = true;
            this.m_cboPadding.Location = new System.Drawing.Point(616, 6);
            this.m_cboPadding.Name = "m_cboPadding";
            this.m_cboPadding.Size = new System.Drawing.Size(60, 20);
            this.m_cboPadding.TabIndex = 4;
            this.m_cboPadding.SelectedIndexChanged += new System.EventHandler(this.m_cboPadding_SelectedIndexChanged);
            this.m_cboPadding.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_cboPadding_KeyPress);
            // 
            // m_btnLast
            // 
            this.m_btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLast.Location = new System.Drawing.Point(488, 4);
            this.m_btnLast.Margin = new System.Windows.Forms.Padding(1);
            this.m_btnLast.Name = "m_btnLast";
            this.m_btnLast.Size = new System.Drawing.Size(50, 23);
            this.m_btnLast.TabIndex = 3;
            this.m_btnLast.Text = "尾页";
            this.m_btnLast.UseVisualStyleBackColor = true;
            this.m_btnLast.Click += new System.EventHandler(this.m_btnLast_Click);
            // 
            // m_btnNext
            // 
            this.m_btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNext.Location = new System.Drawing.Point(436, 4);
            this.m_btnNext.Margin = new System.Windows.Forms.Padding(1);
            this.m_btnNext.Name = "m_btnNext";
            this.m_btnNext.Size = new System.Drawing.Size(50, 23);
            this.m_btnNext.TabIndex = 2;
            this.m_btnNext.Text = "下一页";
            this.m_btnNext.UseVisualStyleBackColor = true;
            this.m_btnNext.Click += new System.EventHandler(this.m_btnNext_Click);
            // 
            // m_btnPrevious
            // 
            this.m_btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrevious.Location = new System.Drawing.Point(384, 4);
            this.m_btnPrevious.Margin = new System.Windows.Forms.Padding(1);
            this.m_btnPrevious.Name = "m_btnPrevious";
            this.m_btnPrevious.Size = new System.Drawing.Size(50, 23);
            this.m_btnPrevious.TabIndex = 1;
            this.m_btnPrevious.Text = "上一页";
            this.m_btnPrevious.UseVisualStyleBackColor = true;
            this.m_btnPrevious.Click += new System.EventHandler(this.m_btnPrevious_Click);
            // 
            // m_btnFirst
            // 
            this.m_btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFirst.Location = new System.Drawing.Point(332, 4);
            this.m_btnFirst.Margin = new System.Windows.Forms.Padding(1);
            this.m_btnFirst.Name = "m_btnFirst";
            this.m_btnFirst.Size = new System.Drawing.Size(50, 23);
            this.m_btnFirst.TabIndex = 0;
            this.m_btnFirst.Text = "首页";
            this.m_btnFirst.UseVisualStyleBackColor = true;
            this.m_btnFirst.Click += new System.EventHandler(this.m_btnFirst_Click);
            // 
            // ctlPaddingGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctlPaddingGridView";
            this.Size = new System.Drawing.Size(799, 30);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cboPadding;
        private System.Windows.Forms.Button m_btnLast;
        private System.Windows.Forms.Button m_btnNext;
        private System.Windows.Forms.Button m_btnPrevious;
        private System.Windows.Forms.Button m_btnFirst;
        private System.Windows.Forms.Label m_lblPadding;
    }
}
