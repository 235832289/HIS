namespace iCare
{
    partial class frmOPInstrumentSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPInstrumentSet));
            this.m_lsvDict = new System.Windows.Forms.ListView();
            this.m_clmItemName = new System.Windows.Forms.ColumnHeader();
            this.m_clmStatus = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_miActiveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_lsvActiveItem = new System.Windows.Forms.ListView();
            this.m_clmSeq = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_miDeActiveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtSearchDict = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdSaveItem = new System.Windows.Forms.Button();
            this.m_txtItem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtSpecifyLineNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdDown = new System.Windows.Forms.Button();
            this.m_cmdUp = new System.Windows.Forms.Button();
            this.m_cmdSaveModify = new System.Windows.Forms.Button();
            this.m_txtSearchActiveItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lsvDict
            // 
            this.m_lsvDict.AccessibleDescription = "显示字典";
            this.m_lsvDict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvDict.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmItemName,
            this.m_clmStatus});
            this.m_lsvDict.ContextMenuStrip = this.contextMenuStrip1;
            this.m_lsvDict.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvDict.FullRowSelect = true;
            this.m_lsvDict.GridLines = true;
            this.m_lsvDict.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvDict.Location = new System.Drawing.Point(15, 50);
            this.m_lsvDict.Name = "m_lsvDict";
            this.m_lsvDict.Size = new System.Drawing.Size(242, 514);
            this.m_lsvDict.TabIndex = 0;
            this.m_lsvDict.UseCompatibleStateImageBehavior = false;
            this.m_lsvDict.View = System.Windows.Forms.View.Details;
            this.m_lsvDict.DoubleClick += new System.EventHandler(this.m_lsvDict_DoubleClick);
            // 
            // m_clmItemName
            // 
            this.m_clmItemName.Text = "手术器械、敷料名称";
            this.m_clmItemName.Width = 140;
            // 
            // m_clmStatus
            // 
            this.m_clmStatus.Text = "当前状态";
            this.m_clmStatus.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_miActiveItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            // 
            // m_miActiveItem
            // 
            this.m_miActiveItem.Name = "m_miActiveItem";
            this.m_miActiveItem.Size = new System.Drawing.Size(133, 22);
            this.m_miActiveItem.Text = "启用项目";
            this.m_miActiveItem.Click += new System.EventHandler(this.m_miActiveItem_Click);
            // 
            // m_lsvActiveItem
            // 
            this.m_lsvActiveItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvActiveItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmSeq,
            this.columnHeader2});
            this.m_lsvActiveItem.ContextMenuStrip = this.contextMenuStrip2;
            this.m_lsvActiveItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvActiveItem.FullRowSelect = true;
            this.m_lsvActiveItem.GridLines = true;
            this.m_lsvActiveItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvActiveItem.Location = new System.Drawing.Point(15, 50);
            this.m_lsvActiveItem.Name = "m_lsvActiveItem";
            this.m_lsvActiveItem.Size = new System.Drawing.Size(240, 542);
            this.m_lsvActiveItem.TabIndex = 1;
            this.m_lsvActiveItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvActiveItem.View = System.Windows.Forms.View.Details;
            // 
            // m_clmSeq
            // 
            this.m_clmSeq.Text = "序号";
            this.m_clmSeq.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "手术器械、敷料名称";
            this.columnHeader2.Width = 140;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_miDeActiveItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(134, 26);
            // 
            // m_miDeActiveItem
            // 
            this.m_miDeActiveItem.Name = "m_miDeActiveItem";
            this.m_miDeActiveItem.Size = new System.Drawing.Size(133, 22);
            this.m_miDeActiveItem.Text = "停用项目";
            this.m_miDeActiveItem.Click += new System.EventHandler(this.m_miDeActiveItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtSearchDict);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cmdSaveItem);
            this.groupBox1.Controls.Add(this.m_txtItem);
            this.groupBox1.Controls.Add(this.m_lsvDict);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(70, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 599);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字典维护";
            // 
            // m_txtSearchDict
            // 
            this.m_txtSearchDict.AccessibleDescription = "搜索字典";
            this.m_txtSearchDict.Location = new System.Drawing.Point(54, 21);
            this.m_txtSearchDict.Name = "m_txtSearchDict";
            this.m_txtSearchDict.Size = new System.Drawing.Size(203, 23);
            this.m_txtSearchDict.TabIndex = 4;
            this.m_txtSearchDict.TextChanged += new System.EventHandler(this.m_txtSearchDict_TextChanged);
            // 
            // label1
            // 
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 28);
            this.label1.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // m_cmdSaveItem
            // 
            this.m_cmdSaveItem.AccessibleDescription = "添加项目";
            this.m_cmdSaveItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdSaveItem.Location = new System.Drawing.Point(172, 569);
            this.m_cmdSaveItem.Name = "m_cmdSaveItem";
            this.m_cmdSaveItem.Size = new System.Drawing.Size(85, 23);
            this.m_cmdSaveItem.TabIndex = 2;
            this.m_cmdSaveItem.Text = "添加项目";
            this.m_cmdSaveItem.UseVisualStyleBackColor = true;
            this.m_cmdSaveItem.Click += new System.EventHandler(this.m_cmdSaveItem_Click);
            // 
            // m_txtItem
            // 
            this.m_txtItem.AccessibleDescription = "项目名称";
            this.m_txtItem.Location = new System.Drawing.Point(15, 569);
            this.m_txtItem.MaxLength = 25;
            this.m_txtItem.Name = "m_txtItem";
            this.m_txtItem.Size = new System.Drawing.Size(151, 23);
            this.m_txtItem.TabIndex = 1;
            this.m_txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtItem_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txtSpecifyLineNum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_cmdDown);
            this.groupBox2.Controls.Add(this.m_cmdUp);
            this.groupBox2.Controls.Add(this.m_cmdSaveModify);
            this.groupBox2.Controls.Add(this.m_txtSearchActiveItem);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_lsvActiveItem);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(412, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 599);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已启用项目维护";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "行前";
            // 
            // m_txtSpecifyLineNum
            // 
            this.m_txtSpecifyLineNum.AccessibleDescription = "指定行号";
            this.m_txtSpecifyLineNum.Location = new System.Drawing.Point(272, 411);
            this.m_txtSpecifyLineNum.Name = "m_txtSpecifyLineNum";
            this.m_txtSpecifyLineNum.Size = new System.Drawing.Size(58, 23);
            this.m_txtSpecifyLineNum.TabIndex = 8;
            this.m_txtSpecifyLineNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSpecifyLineNum_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(269, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "移动选择项目至第";
            // 
            // m_cmdDown
            // 
            this.m_cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdDown.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDown.Location = new System.Drawing.Point(272, 241);
            this.m_cmdDown.Name = "m_cmdDown";
            this.m_cmdDown.Size = new System.Drawing.Size(34, 44);
            this.m_cmdDown.TabIndex = 6;
            this.m_cmdDown.Text = "↓";
            this.m_cmdDown.UseVisualStyleBackColor = true;
            this.m_cmdDown.Click += new System.EventHandler(this.m_cmdDown_Click);
            // 
            // m_cmdUp
            // 
            this.m_cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdUp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdUp.Location = new System.Drawing.Point(272, 191);
            this.m_cmdUp.Name = "m_cmdUp";
            this.m_cmdUp.Size = new System.Drawing.Size(34, 44);
            this.m_cmdUp.TabIndex = 6;
            this.m_cmdUp.Text = "↑";
            this.m_cmdUp.UseVisualStyleBackColor = true;
            this.m_cmdUp.Click += new System.EventHandler(this.m_cmdUp_Click);
            // 
            // m_cmdSaveModify
            // 
            this.m_cmdSaveModify.AccessibleDescription = "保存设置";
            this.m_cmdSaveModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdSaveModify.Location = new System.Drawing.Point(272, 569);
            this.m_cmdSaveModify.Name = "m_cmdSaveModify";
            this.m_cmdSaveModify.Size = new System.Drawing.Size(85, 23);
            this.m_cmdSaveModify.TabIndex = 5;
            this.m_cmdSaveModify.Text = "保存设置";
            this.m_cmdSaveModify.UseVisualStyleBackColor = true;
            this.m_cmdSaveModify.Click += new System.EventHandler(this.m_cmdSaveModify_Click);
            // 
            // m_txtSearchActiveItem
            // 
            this.m_txtSearchActiveItem.AccessibleDescription = "搜索已启用项目";
            this.m_txtSearchActiveItem.Location = new System.Drawing.Point(52, 21);
            this.m_txtSearchActiveItem.Name = "m_txtSearchActiveItem";
            this.m_txtSearchActiveItem.Size = new System.Drawing.Size(203, 23);
            this.m_txtSearchActiveItem.TabIndex = 4;
            this.m_txtSearchActiveItem.TextChanged += new System.EventHandler(this.m_txtSearchActiveItem_TextChanged);
            // 
            // label2
            // 
            this.label2.ImageIndex = 0;
            this.label2.ImageList = this.imageList1;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 28);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(376, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 602);
            this.label3.TabIndex = 4;
            // 
            // frmOPInstrumentSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 623);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPInstrumentSet";
            this.Text = "手术器械、敷料项目维护";
            this.Load += new System.EventHandler(this.frmOPInstrumentSet_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView m_lsvDict;
        private System.Windows.Forms.ColumnHeader m_clmItemName;
        private System.Windows.Forms.ListView m_lsvActiveItem;
        private System.Windows.Forms.ColumnHeader m_clmSeq;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_cmdSaveItem;
        private System.Windows.Forms.TextBox m_txtItem;
        private System.Windows.Forms.ColumnHeader m_clmStatus;
        private System.Windows.Forms.TextBox m_txtSearchDict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txtSearchActiveItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_cmdDown;
        private System.Windows.Forms.Button m_cmdUp;
        private System.Windows.Forms.Button m_cmdSaveModify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txtSpecifyLineNum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_miActiveItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem m_miDeActiveItem;
    }
}