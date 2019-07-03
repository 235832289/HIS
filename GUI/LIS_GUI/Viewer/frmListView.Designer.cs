namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmListView
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
            this.m_objListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // m_objListView
            // 
            this.m_objListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_objListView.FullRowSelect = true;
            this.m_objListView.GridLines = true;
            this.m_objListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_objListView.Location = new System.Drawing.Point(65, 25);
            this.m_objListView.MultiSelect = false;
            this.m_objListView.Name = "m_objListView";
            this.m_objListView.Size = new System.Drawing.Size(126, 144);
            this.m_objListView.TabIndex = 1;
            this.m_objListView.UseCompatibleStateImageBehavior = false;
            this.m_objListView.View = System.Windows.Forms.View.Details;
            // 
            // frmListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(271, 190);
            this.Controls.Add(this.m_objListView);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmListView";
            this.Deactivate += new System.EventHandler(this.frmListView_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView m_objListView;
    }
}